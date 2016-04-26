using System;
using System.IO;

namespace WaveEdit
{
	/// <summary>
	/// Summary description for WaveReader.
	/// </summary>
	public class WaveFileReader 
	{
		private BinaryReader reader;
		private riffChunk mainfile;
		private fmtChunk format;
		private factChunk fact;
		private dataChunk data;

		public WaveFileReader(string filename)
		{
			reader = new BinaryReader(new FileStream(filename, 
				FileMode.Open, FileAccess.Read, FileShare.Read));
		}

		public long GetPosition() 
		{ 
			return reader.BaseStream.Position; 
		}

		public string GetChunkName() 
		{ 
			return new string(reader.ReadChars(4)); 
		}

		public void AdvanceToNext() 
		{
			//Get next chunk offset
			long NextOffset = (long) reader.ReadUInt32();
			//Seek to the next offset from current position
			reader.BaseStream.Seek(NextOffset,SeekOrigin.Current);
		}

		public dataChunk ReadDataHeader()
		{
			long count;
			data = new dataChunk();

			data.sChunkID = "data";
			data.dwChunkSize = reader.ReadUInt32();
			//ReadUInt32 is the most important function here.

			//Once we've read in the ChunkSize, 
			//we're at the start of the actual data.
			data.lFilePosition = reader.BaseStream.Position;

			//If the fact chunk exists, we don't have to calculate 
			//the number of samples ourselves.
				data.dwNumSamples = data.dwChunkSize / 
					((uint)format.dwBitsPerSample/8 * format.wChannels);
			//The above could be written as data.dwChunkSize / format.wBlockAlign, 
			//but I want to emphasize
			//what the frames look like.

			data.dwMinLength = (data.dwChunkSize / format.dwAvgBytesPerSec) / 60;
			data.dSecLength = ((double)data.dwChunkSize / 
				(double)format.dwAvgBytesPerSec) - 
				(double)data.dwMinLength*60;

			count = 0;
			if (format.dwBitsPerSample == 16)
			{
				data.shortArray = new short[data.dwNumSamples];
			}
			else if (format.dwBitsPerSample == 8)
			{
				data.byteArray = new byte[data.dwNumSamples];
			}			
			while (count < data.dwNumSamples)
			{
				if (format.dwBitsPerSample == 16)
				{
					data.shortArray[count] = reader.ReadInt16();
				}
				else if (format.dwBitsPerSample == 8)
				{
					data.byteArray[count] = reader.ReadByte();
				}
				count++;
			}
			return data;
		}

		public fmtChunk ReadFormatHeader()
		{
			format = new fmtChunk();

			format.sChunkID = "fmt ";
			format.dwChunkSize = reader.ReadUInt32();
			//ReadUInt32 is the most important function here.

			format.wFormatTag = reader.ReadUInt16();
			format.wChannels = reader.ReadUInt16();
			format.dwSamplesPerSec = reader.ReadUInt32();
			format.dwAvgBytesPerSec = reader.ReadUInt32();
			format.wBlockAlign = reader.ReadUInt16();
			format.dwBitsPerSample = reader.ReadUInt32();
			return format;
		}
	

		public factChunk ReadFactHeader()
		{
			fact = new factChunk();

			fact.sChunkID = "fact";
			fact.dwChunkSize = reader.ReadUInt32();

			fact.dwNumSamples = reader.ReadUInt32();
			return fact;
		}

		public riffChunk ReadMainFileHeader()
		{
			mainfile = new riffChunk();

			mainfile.sGroupID = new string(reader.ReadChars(4));
			mainfile.dwFileLength = reader.ReadUInt32();
			mainfile.sRiffType = new string(reader.ReadChars(4));

			return mainfile;
		}
	}
}
