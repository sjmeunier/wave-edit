using System;

namespace WaveEdit
{
	/// <summary>
	/// Summary description for WaveFile.
	/// </summary>
	public class WaveFile
	{
		WaveFileReader reader;
		public riffChunk MainData = new riffChunk();
		public fmtChunk FormatData = new fmtChunk();
		public factChunk FactData = new factChunk();
		public dataChunk WaveData = new dataChunk();

		public WaveFile(string psFilename)
		{
			string temp = "";
			reader = new WaveFileReader(psFilename);
			MainData = reader.ReadMainFileHeader();

			while (reader.GetPosition() < (long) MainData.dwFileLength)
			{
				temp = reader.GetChunkName();
				if (temp=="fmt ")
				{
					FormatData = reader.ReadFormatHeader();
					if (reader.GetPosition() + 
						FormatData.dwChunkSize == MainData.dwFileLength)
						break;
				}
				else if (temp=="fact")
				{
					FactData = reader.ReadFactHeader();
					if (reader.GetPosition() + 
						FactData.dwChunkSize == MainData.dwFileLength)
						break;
				}
				else if (temp=="data")
				{
					WaveData = reader.ReadDataHeader();
					if (reader.GetPosition() + 
						WaveData.dwChunkSize == MainData.dwFileLength)
						break;
				}
				else
				{    //This provides the required skipping of unsupported chunks.
					reader.AdvanceToNext();
				}
			}
		}

		public void WriteFile(string psFilename)
		{
			WaveFileWriter WaveWriter = new WaveFileWriter();
			WaveWriter.SetMainHeader(MainData);
			WaveWriter.SetFormatHeader(FormatData);
			WaveWriter.SetData(WaveData);
			WaveWriter.WriteFile(psFilename);
		}

		public void ChangeVolume(double fPercentage)
		{
			ulong i;
			short iTemp;
			byte bTemp;

			for (i = 0; i < WaveData.dwNumSamples; i++)
			{
				if (FormatData.dwBitsPerSample == 16)
				{
					iTemp = (short)Math.Round((double)WaveData.shortArray[i] * fPercentage);
					if (fPercentage > 1.0)
					{
						if ((iTemp < WaveData.shortArray[i]) && (WaveData.shortArray[i] > 0))
						{
							//Correct for maxed out value
							iTemp = 32766;
						}
						if ((iTemp > WaveData.shortArray[i]) && (WaveData.shortArray[i] < 0))
						{
							//Correct for maxed out value
							iTemp = -32766;
						}
					}
					WaveData.shortArray[i] = iTemp;
				}
				else if (FormatData.dwBitsPerSample == 8)
				{
					bTemp = (byte)Math.Round((double)WaveData.byteArray[i] * fPercentage);
					if (fPercentage > 1.0)
					{
						if (bTemp < WaveData.byteArray[i])
						{
							//Correct for maxed out value
							iTemp = 255;
						}
					}
					WaveData.byteArray[i] = bTemp;
				}			
			}
		}

		public void Normalize(int iPeak)
		{
			uint i;
			double fRatio = 0;

			if (FormatData.dwBitsPerSample == 16)
			{
				short iMax = 0;
				for (i = 0; i < WaveData.dwNumSamples; i++)
				{
					if (WaveData.shortArray[i] > iMax)
					{
						iMax = WaveData.shortArray[i];
					}
				}
				fRatio = (double)iPeak / (double)iMax;
			}
			else if (FormatData.dwBitsPerSample == 8)
			{
				byte bMax = 0;

				for (i = 0; i < WaveData.dwNumSamples; i++)
				{
					if (WaveData.byteArray[i] > bMax)
					{
						bMax = WaveData.byteArray[i];
					}
				}
				fRatio = (double)iPeak / (double)bMax;
			}

			ChangeVolume(fRatio);
		}

		public void RemoveSilenceStart(int iThreshold)
		{
			uint i;
			uint j;
			bool bSilent = true;

			if (FormatData.dwBitsPerSample == 16)
			{
				short [] iTemp = new short[WaveData.dwNumSamples];
				j = 0;

				for (i = 0; i < WaveData.dwNumSamples; i++)
				{
					if (bSilent)
					{
						if(WaveData.shortArray[i] > (short)iThreshold)
						{
							bSilent = false;
						}
					}
					else
					{
						iTemp[j] = WaveData.shortArray[i];
						j++;
					}
				}
				WaveData.dwNumSamples = j;
				WaveData.dwChunkSize = j * 2;
				for(i = 0; i < WaveData.dwNumSamples; i++)
				{
					WaveData.shortArray[i] = iTemp[i];
				}
			}
			else
			{
				byte [] bTemp = new byte[WaveData.dwNumSamples];
				j = 0;

				for (i = 0; i < WaveData.dwNumSamples; i++)
				{
					if (bSilent)
					{
						if(WaveData.byteArray[i] > (byte)iThreshold)
						{
							bSilent = false;
						}
					}
					else
					{
						bTemp[j] = WaveData.byteArray[i];
						j++;
					}
				}
				WaveData.dwNumSamples = j;
				WaveData.dwChunkSize = j;
				for(i = 0; i < WaveData.dwNumSamples; i++)
				{
					WaveData.byteArray[i] = bTemp[i];
				}
			}
		}

		public void RemoveSilenceEnd(int iThreshold)
		{
			uint i;

			for(i = (WaveData.dwNumSamples - 1); i >= 0; i--)
			{
				if (FormatData.dwBitsPerSample == 16)
				{
					if (WaveData.shortArray[i] > (short)iThreshold)
					{
						WaveData.dwNumSamples = i;
						WaveData.dwChunkSize = i * 2;
						break;
					}
				}
				else if (FormatData.dwBitsPerSample == 8)
				{
					if (WaveData.byteArray[i] > (byte)iThreshold)
					{
						WaveData.dwNumSamples = i;
						WaveData.dwChunkSize = i;
						break;
					}
				}
			}
		}
		public void ChangeTempo(int iPercentage)
		{
			uint i, j;
			int iCount, iMax;

			if (iPercentage < 100)
			{
				//Gotta fix iMax;
				iMax = iPercentage / 100;

				if (FormatData.dwBitsPerSample == 16)
				{
					i = 0;
					j = 0;
					iCount = 0;
					short [] iTemp = new short[65535];
					//short [] iTemp = new short[MAXINT];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						if ((iCount % iMax) != 0)
						{
							iTemp[j] = WaveData.shortArray[i];
							j++;
						}
						else
						{
							iTemp[j] = WaveData.shortArray[i];
							j++;
							if ((i +1) < WaveData.dwNumSamples)
							{
								i++;
								iTemp[j] = WaveData.shortArray[i];
								j++;
							}
						}
						iCount++;
					}
					WaveData.dwNumSamples = j;
					WaveData.dwChunkSize = j * 2;
					WaveData.shortArray = new short[j];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						WaveData.shortArray[i] = iTemp[i];
					}
				}
				else if (FormatData.dwBitsPerSample == 8)
				{
					i = 0;
					j = 0;
					iCount = 0;
					byte [] bTemp = new byte[65535];
				//	byte [] bTemp = new byte[MAX INT];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						if ((iCount % iMax) != 0)
						{
							bTemp[j] = WaveData.byteArray[i];
							j++;
						}
						else
						{
							bTemp[j] = WaveData.byteArray[i];
							j++;
							if ((i +1) < WaveData.dwNumSamples)
							{
								i++;
								bTemp[j] = WaveData.byteArray[i];
								j++;
							}
						}
						iCount++;
					}
					WaveData.dwNumSamples = j;
					WaveData.dwChunkSize = j;
					WaveData.byteArray = new byte[j];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						WaveData.byteArray[i] = bTemp[i];
					}
				}				
			}
			else if (iPercentage > 100)
			{
				//Gotta fix iMax;
				iMax = iPercentage/ 100;

				if (FormatData.dwBitsPerSample == 16)
				{
					i = 0;
					j = 0;
					iCount = 0;
					//short [] iTemp = new short[MAXINT];
					short [] iTemp = new short[65535];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						if ((iCount % iMax) != 0)
						{
							iTemp[j] = WaveData.shortArray[i];
							j++;
						}
						iCount++;
					}
					WaveData.dwNumSamples = j;
					WaveData.dwChunkSize = j * 2;
					WaveData.shortArray = new short[j];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						WaveData.shortArray[i] = iTemp[i];
					}
				}
				else if (FormatData.dwBitsPerSample == 8)
				{
					i = 0;
					j = 0;
					iCount = 0;
					//byte [] bTemp = new byte[MAXINT];
					byte [] bTemp = new byte[65535];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						if ((iCount % iMax) != 0)
						{
							bTemp[j] = WaveData.byteArray[i];
							j++;
						}
						iCount++;
					}
					WaveData.dwNumSamples = j;
					WaveData.dwChunkSize = j;
					WaveData.byteArray = new byte[j];
					for (i = 0; i < WaveData.dwNumSamples; i++)
					{
						WaveData.byteArray[i] = bTemp[i];
					}
				}
			}
			
		}

	}




}
