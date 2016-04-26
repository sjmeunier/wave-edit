using System;

namespace WaveEdit
{
	/// <summary>
	/// Summary description for Structs.
	/// </summary>
	public class riffChunk 
	{
		public string sGroupID;         //RIFF
		public uint   dwFileLength;     //In bytes, measured from offset 8
		public string sRiffType;        //WAVE, usually
	}

	public class fmtChunk
	{
		public string  sChunkID;        //Four bytes: "fmt "
		public uint    dwChunkSize;     //Length of header in bytes
		public ushort  wFormatTag;      //1 if uncompressed Microsoft PCM audio
		public ushort  wChannels;       //Number of channels
		public uint    dwSamplesPerSec; //Frequency of the audio in Hz
		public uint    dwAvgBytesPerSec;//For estimating RAM allocation
		public ushort  wBlockAlign;     //Sample frame size in bytes
		public uint  dwBitsPerSample; //Bits per sample
	}

	public class dataChunk 
	{
		public string sChunkID;          //Four bytes: "data"
		public uint   dwChunkSize;       //Length of header
		public long   lFilePosition;     //Position of data chunk in file
		public uint   dwMinLength;       //Length of audio in minutes
		public double dSecLength;        //Length of audio in seconds
		public uint   dwNumSamples;      //Number of audio frames
		public byte  []byteArray;     //8 bit unsigned data; or...
		public short []shortArray;    //16 bit signed data
	}

	public class factChunk
	{
		public string sChunkID;            //Four bytes: "fact"
		public uint   dwChunkSize;         //Length of header
		public uint   dwNumSamples;        //Number of audio frames
	}
}
