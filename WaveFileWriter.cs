using System;
using System.IO;

namespace WaveEdit
{
	/// <summary>
	/// Summary description for WaveFileWriter.
	/// </summary>
	public class WaveFileWriter
	{
		private riffChunk main = new riffChunk();
		private fmtChunk format = new fmtChunk();
		private factChunk fact = new factChunk();
		private dataChunk data = new dataChunk();

		bool hasRiff = false, hasFmt = false, hasFact = false, hasData = false;
		
		public WaveFileWriter()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void SetMainHeader(riffChunk pmain)
		{
			main = pmain;
			hasRiff = true;
		}

		public void SetFormatHeader(fmtChunk pformat)
		{
			format = pformat;
			hasFmt = true;
		}

		public void SetFactHeader(factChunk pfact)
		{
			fact = pfact;
			hasFact = true;
		}

		public void SetData(dataChunk pdata)
		{
			data = pdata;
			hasData = true;
		}

		public void WriteFile(string psFilename)
		{
			FileStream stream = new FileStream(psFilename, FileMode.Create);
			BinaryWriter writer = new BinaryWriter(stream);
			int i;

			uint lFileLen = 0;
			if (hasRiff)
			{
				for (i = 0; i < 4; i++)
				{
					writer.Write(main.sGroupID[i]);
				}
				lFileLen = 12;
				if (hasFmt)
				{
					lFileLen += format.dwChunkSize + 8;
				}
				if (hasFact)
				{
					lFileLen += fact.dwChunkSize + 8;
				}
				if (hasData)
				{
					lFileLen += data.dwChunkSize +8;
				}
				writer.Write(lFileLen);
				for (i = 0; i < 4; i++)
				{
					writer.Write(main.sRiffType[i]);
				}
			}

			if (hasFmt)
			{
				for (i = 0; i < 4; i++)
				{
					writer.Write(format.sChunkID[i]);
				}
				writer.Write(format.dwChunkSize);
				writer.Write(format.wFormatTag);
				writer.Write(format.wChannels);
				writer.Write(format.dwSamplesPerSec);
				writer.Write(format.dwAvgBytesPerSec);
				writer.Write(format.wBlockAlign);
				writer.Write(format.dwBitsPerSample);
			}

			if (hasFact)
			{
				for (i = 0; i < 4; i++)
				{
					writer.Write(fact.sChunkID[i]);
				}
				writer.Write(fact.dwChunkSize);
				writer.Write(fact.dwNumSamples);
			}

			if (hasData)
			{
				ulong j;
				for (i = 0; i < 4; i++)
				{
					writer.Write(data.sChunkID[i]);
				}
				writer.Write(data.dwChunkSize);
				for (j = 0; j < data.dwNumSamples; j++)
				{
					if (format.dwBitsPerSample == 16)
					{
						writer.Write(data.shortArray[j]);
					}
					else if (format.dwBitsPerSample == 8)
					{
						writer.Write(data.byteArray[j]);
					}
				}
			}
			writer.Close();
			stream.Close();
		}

	}
}
