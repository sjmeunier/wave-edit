using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WaveEdit
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class WaveEdit : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtBits;
		private System.Windows.Forms.Button cmdLoad;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtFormat;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLength;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtChannels;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSampleRate;
		private System.Windows.Forms.TextBox txtVolume;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdDoit;
		private System.Windows.Forms.Button cmdBrowse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.TextBox txtNewFile;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox txtSamples;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox chkRemoveStart;
		private System.Windows.Forms.CheckBox chkRemoveEnd;
		private System.Windows.Forms.TextBox txtThreshold;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button cmdNorm;
		private System.Windows.Forms.TextBox txtPeak;
		private System.Windows.Forms.Label label11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WaveEdit()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label7 = new System.Windows.Forms.Label();
			this.txtBits = new System.Windows.Forms.TextBox();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtFormat = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLength = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtChannels = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSampleRate = new System.Windows.Forms.TextBox();
			this.txtVolume = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmdDoit = new System.Windows.Forms.Button();
			this.cmdBrowse = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.txtNewFile = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.txtSamples = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.chkRemoveStart = new System.Windows.Forms.CheckBox();
			this.chkRemoveEnd = new System.Windows.Forms.CheckBox();
			this.txtThreshold = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cmdNorm = new System.Windows.Forms.Button();
			this.txtPeak = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 37;
			this.label7.Text = "Bits";
			// 
			// txtBits
			// 
			this.txtBits.Location = new System.Drawing.Point(96, 144);
			this.txtBits.Name = "txtBits";
			this.txtBits.Size = new System.Drawing.Size(112, 20);
			this.txtBits.TabIndex = 36;
			this.txtBits.Text = "";
			// 
			// cmdLoad
			// 
			this.cmdLoad.Location = new System.Drawing.Point(392, 40);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.Size = new System.Drawing.Size(56, 24);
			this.cmdLoad.TabIndex = 35;
			this.cmdLoad.Text = "&Load";
			this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 34;
			this.label6.Text = "Format";
			// 
			// txtFormat
			// 
			this.txtFormat.Location = new System.Drawing.Point(96, 120);
			this.txtFormat.Name = "txtFormat";
			this.txtFormat.Size = new System.Drawing.Size(112, 20);
			this.txtFormat.TabIndex = 33;
			this.txtFormat.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 32;
			this.label5.Text = "Length";
			// 
			// txtLength
			// 
			this.txtLength.Location = new System.Drawing.Point(96, 96);
			this.txtLength.Name = "txtLength";
			this.txtLength.Size = new System.Drawing.Size(112, 20);
			this.txtLength.TabIndex = 31;
			this.txtLength.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 30;
			this.label4.Text = "Channels";
			// 
			// txtChannels
			// 
			this.txtChannels.Location = new System.Drawing.Point(96, 72);
			this.txtChannels.Name = "txtChannels";
			this.txtChannels.Size = new System.Drawing.Size(112, 20);
			this.txtChannels.TabIndex = 29;
			this.txtChannels.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 28;
			this.label3.Text = "Sample Rate";
			// 
			// txtSampleRate
			// 
			this.txtSampleRate.Location = new System.Drawing.Point(96, 48);
			this.txtSampleRate.Name = "txtSampleRate";
			this.txtSampleRate.Size = new System.Drawing.Size(112, 20);
			this.txtSampleRate.TabIndex = 27;
			this.txtSampleRate.Text = "";
			// 
			// txtVolume
			// 
			this.txtVolume.Location = new System.Drawing.Point(96, 240);
			this.txtVolume.Name = "txtVolume";
			this.txtVolume.Size = new System.Drawing.Size(40, 20);
			this.txtVolume.TabIndex = 26;
			this.txtVolume.Text = "0.5";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 240);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 25;
			this.label2.Text = "Volume";
			// 
			// cmdDoit
			// 
			this.cmdDoit.Location = new System.Drawing.Point(392, 216);
			this.cmdDoit.Name = "cmdDoit";
			this.cmdDoit.Size = new System.Drawing.Size(56, 24);
			this.cmdDoit.TabIndex = 23;
			this.cmdDoit.Text = "&Do it";
			this.cmdDoit.Click += new System.EventHandler(this.cmdDoit_Click);
			// 
			// cmdBrowse
			// 
			this.cmdBrowse.Location = new System.Drawing.Point(392, 8);
			this.cmdBrowse.Name = "cmdBrowse";
			this.cmdBrowse.Size = new System.Drawing.Size(56, 24);
			this.cmdBrowse.TabIndex = 22;
			this.cmdBrowse.Text = "&Browse";
			this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 21;
			this.label1.Text = "File";
			// 
			// txtFile
			// 
			this.txtFile.Location = new System.Drawing.Point(96, 8);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(288, 20);
			this.txtFile.TabIndex = 20;
			this.txtFile.Text = "";
			// 
			// txtNewFile
			// 
			this.txtNewFile.Location = new System.Drawing.Point(96, 216);
			this.txtNewFile.Name = "txtNewFile";
			this.txtNewFile.Size = new System.Drawing.Size(288, 20);
			this.txtNewFile.TabIndex = 40;
			this.txtNewFile.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 216);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 41;
			this.label9.Text = "New Filename";
			// 
			// txtSamples
			// 
			this.txtSamples.Location = new System.Drawing.Point(96, 168);
			this.txtSamples.Name = "txtSamples";
			this.txtSamples.Size = new System.Drawing.Size(112, 20);
			this.txtSamples.TabIndex = 43;
			this.txtSamples.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 168);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.TabIndex = 42;
			this.label10.Text = "Samples";
			// 
			// chkRemoveStart
			// 
			this.chkRemoveStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkRemoveStart.Location = new System.Drawing.Point(16, 280);
			this.chkRemoveStart.Name = "chkRemoveStart";
			this.chkRemoveStart.Size = new System.Drawing.Size(192, 16);
			this.chkRemoveStart.TabIndex = 44;
			this.chkRemoveStart.Text = "Remove Silence From Beginning";
			// 
			// chkRemoveEnd
			// 
			this.chkRemoveEnd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkRemoveEnd.Location = new System.Drawing.Point(16, 296);
			this.chkRemoveEnd.Name = "chkRemoveEnd";
			this.chkRemoveEnd.Size = new System.Drawing.Size(192, 16);
			this.chkRemoveEnd.TabIndex = 45;
			this.chkRemoveEnd.Text = "Remove Silence From End";
			// 
			// txtThreshold
			// 
			this.txtThreshold.Location = new System.Drawing.Point(96, 320);
			this.txtThreshold.Name = "txtThreshold";
			this.txtThreshold.Size = new System.Drawing.Size(40, 20);
			this.txtThreshold.TabIndex = 46;
			this.txtThreshold.Text = "10";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 320);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 16);
			this.label8.TabIndex = 47;
			this.label8.Text = "Threshold";
			// 
			// cmdNorm
			// 
			this.cmdNorm.Location = new System.Drawing.Point(392, 384);
			this.cmdNorm.Name = "cmdNorm";
			this.cmdNorm.Size = new System.Drawing.Size(64, 24);
			this.cmdNorm.TabIndex = 48;
			this.cmdNorm.Text = "Normalize";
			this.cmdNorm.Click += new System.EventHandler(this.cmdNorm_Click);
			// 
			// txtPeak
			// 
			this.txtPeak.Location = new System.Drawing.Point(96, 384);
			this.txtPeak.Name = "txtPeak";
			this.txtPeak.Size = new System.Drawing.Size(80, 20);
			this.txtPeak.TabIndex = 49;
			this.txtPeak.Text = "30000";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 384);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 16);
			this.label11.TabIndex = 50;
			this.label11.Text = "Peak";
			// 
			// WaveEdit
			// 
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txtPeak);
			this.Controls.Add(this.cmdNorm);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtThreshold);
			this.Controls.Add(this.chkRemoveEnd);
			this.Controls.Add(this.chkRemoveStart);
			this.Controls.Add(this.txtSamples);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtNewFile);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtBits);
			this.Controls.Add(this.cmdLoad);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtFormat);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtLength);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtChannels);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtSampleRate);
			this.Controls.Add(this.txtVolume);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmdDoit);
			this.Controls.Add(this.cmdBrowse);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtFile);
			this.Name = "WaveEdit";
			this.Size = new System.Drawing.Size(472, 416);
			this.Load += new System.EventHandler(this.WaveEdit_Load);
			this.ResumeLayout(false);

		}
		#endregion

		WaveFile oWave;

		private void WaveEdit_Load(object sender, System.EventArgs e)
		{
		
		}

		private void cmdLoad_Click(object sender, System.EventArgs e)
		{
			oWave = new WaveFile(txtFile.Text);
			txtSampleRate.Text = oWave.FormatData.dwSamplesPerSec.ToString();
			txtBits.Text = oWave.FormatData.dwBitsPerSample.ToString();
			txtChannels.Text = oWave.FormatData.wChannels.ToString();
			txtFormat.Text = oWave.FormatData.wFormatTag.ToString();
			txtLength.Text = oWave.MainData.dwFileLength.ToString();
			txtSamples.Text = oWave.WaveData.dwNumSamples.ToString();
			txtNewFile.Text = txtFile.Text;
		}

		private void cmdDoit_Click(object sender, System.EventArgs e)
		{
			oWave.ChangeVolume(Convert.ToDouble(txtVolume.Text));
			if (chkRemoveEnd.Checked)
			{
				oWave.RemoveSilenceStart(Convert.ToInt16(txtThreshold.Text));
			}
			if (chkRemoveStart.Checked)
			{
				oWave.RemoveSilenceEnd(Convert.ToInt16(txtThreshold.Text));
			}

			oWave.WriteFile(txtNewFile.Text);
		}

		private void cmdBrowse_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.ShowDialog();
			txtFile.Text = openFileDialog1.FileName;
		}

		private void cmdNorm_Click(object sender, System.EventArgs e)
		{
			oWave.Normalize(Convert.ToInt16(txtPeak.Text));
			oWave.WriteFile(txtNewFile.Text);
		}
	}
}
