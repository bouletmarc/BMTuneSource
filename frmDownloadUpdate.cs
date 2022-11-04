using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using IWshRuntimeLibrary;

internal class frmDownloadUpdate : Form
{
    public ProgressBar progressBar1;
    private IContainer icontainer_0;
    private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    private Class15 Class15_0;
    private FrmMain FrmMain_0;
    string String_00 = "";
    private Label label1;
    private PictureBox pictureBox3;
    private PictureBox pictureBox2;
    private PictureBox pictureBox4;

    bool DownloadingFromGithub = false;

    public frmDownloadUpdate(ref FrmMain FrmMain_1, ref Class15 Class15_1)
    {
        this.InitializeComponent();

        FrmMain_0 = FrmMain_1;
        Class15_0 = Class15_1;

        LoopTimer.Interval = 100;
        LoopTimer.Tick += DoThisAllTheTime;
        LoopTimer.Start();
    }

    private string DLStringFromURL(WebClient webpage, string ThisURL)
    {
        string ThisStr = "";
        try
        {
            ThisStr = webpage.DownloadString(ThisURL);
        }
        catch { }
        return ThisStr;
    }

    private void GetUpdate()
    {
        bool BMTuneUpdated = true;

        double LastVersion = 0;
        double CurrentVersion = double.Parse(this.Class15_0.CurrentBMTuneVersion.Substring(1).Replace(".", ""));
        if (CurrentVersion > 1000) CurrentVersion = CurrentVersion / 10;

        //############################################################################
        //Getting Normal Version
        try
        {
            using (var webpage = new WebClient())
            {
                webpage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:25.0;  WOW64) Gecko/20100101 Firefox/25.0 AppleWebKit/535.2 (KHTML, like Gecko)  Chrome/15.0.874.121 Safari/535.2");
                
                if (String_00 == "") String_00 = DLStringFromURL(webpage, "https://raw.githubusercontent.com/MarcDevs/bmbuild/master/Version.txt");
                if (String_00 != "") DownloadingFromGithub = true;
                if (String_00 == "") String_00 = DLStringFromURL(webpage, "http://www.bmtune.com/build/Version.txt");

                webpage.Dispose();
            }

            LastVersion = double.Parse(String_00.Substring(1).Replace(".", ""));
            if (LastVersion > 1000) LastVersion = LastVersion / 10;
        }
        catch
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        if (CurrentVersion < LastVersion) BMTuneUpdated = false;
        if (!BMTuneUpdated) label1.Text = "UPDATING to " + String_00;
        this.Refresh();
    }

    /*private class WebClient : System.Net.WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            if (Timeout < 300) Timeout = 6000;

            WebRequest lWebRequest = base.GetWebRequest(uri);
            lWebRequest.Timeout = Timeout;
            ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
            return lWebRequest;
        }
    }*/

    private void UpdateFiles()
    {
        try
        {
            string DLink = "http://www.bmtune.com/build/BMTune.zip";
            if (DownloadingFromGithub) DLink = "https://github.com/MarcDevs/bmbuild/raw/master/BMTune.exe";

            if (System.IO.File.Exists(Application.StartupPath + @"\BMTune.zip")) System.IO.File.Delete(Application.StartupPath + @"\BMTune.zip");

            //#############################################################
            //#############################################################
            //#############################################################
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)");
            using (Stream webStream = webClient.OpenRead(DLink))
            using (FileStream fileStream = new FileStream(Application.StartupPath + @"\BMTuneUpdate.exe", FileMode.Create))
            {
                var buffer = new byte[32768];
                int bytesRead;
                Int64 bytesReadComplete = 0;  // Use Int64 for files larger than 2 gb
                Int64 bytesTotal = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);

                while ((bytesRead = webStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bytesReadComplete += bytesRead;
                    fileStream.Write(buffer, 0, bytesRead);

                    this.progressBar1.Value = (int)((bytesReadComplete * 100.0) / bytesTotal);
                }
            }
            //#############################################################
            /*WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)");
            webClient.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs e) { this.progressBar1.Value = e.ProgressPercentage; };
            //webClient.Timeout = 6000;

            //Download the File
            if (!DownloadingFromGithub)
            {
                webClient.DownloadFileAsync(new Uri(DLink), Application.StartupPath + @"\BMTune.zip");
            }
            else
            {
                webClient.DownloadFileAsync(new Uri(DLink), Application.StartupPath + @"\BMTuneUpdate.exe");
            }
            while (webClient.IsBusy) { Application.DoEvents(); }*/
            //#############################################################
            //#############################################################
            //#############################################################


            //Unzip
            if (!DownloadingFromGithub)
            {
                if (System.IO.File.Exists(Application.StartupPath + @"\BMTuneUpdate" + ".exe")) System.IO.File.Delete(Application.StartupPath + @"\BMTuneUpdate" + ".exe");
                this.FrmMain_0.Class34_Zip_0.UnZipFileFromThisZIP("BMTuneUpdate" + ".exe", Application.StartupPath + @"\BMTune.zip");
                if (System.IO.File.Exists(Application.StartupPath + @"\BMTune.zip")) System.IO.File.Delete(Application.StartupPath + @"\BMTune.zip");
            }

            //Launch BMTuneUpdate.exe
            if (System.IO.File.Exists(Application.StartupPath + @"\BMTuneUpdate" + ".exe"))
            {
                Process.Start(Application.StartupPath + @"\BMTuneUpdate" + ".exe");
                Environment.Exit(0);
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        catch (Exception mess)
        {
            //MessageBox.Show("Cant update BMTune with error:" + mess, "ERROR");
            //Console.WriteLine("Cant update BMTune with error:" + mess);

            if (System.IO.File.Exists(Application.StartupPath + @"\BMTuneUpdate" + ".exe")) System.IO.File.Delete(Application.StartupPath + @"\BMTuneUpdate" + ".exe");
            if (System.IO.File.Exists(Application.StartupPath + @"\BMTune.zip")) System.IO.File.Delete(Application.StartupPath + @"\BMTune.zip");

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    void DoThisAllTheTime(object sender, EventArgs e)
    {
        LoopTimer.Stop();
        GetUpdate();
        UpdateFiles();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadUpdate));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(10, 147);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(351, 10);
            this.progressBar1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 26);
            this.label1.TabIndex = 30;
            this.label1.Text = "UPDATING !";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = global::Properties.Resources.BMTune_Logo_150x901;
            this.pictureBox3.Location = new System.Drawing.Point(68, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(234, 119);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::Properties.Resources.Piston_Animation_Small;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 119);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = global::Properties.Resources.Piston_Animation_Small;
            this.pictureBox4.Location = new System.Drawing.Point(301, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 119);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            // 
            // frmDownloadUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(371, 167);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadUpdate";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updating";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

    }

    

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

  
}

