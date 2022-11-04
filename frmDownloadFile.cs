using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using IWshRuntimeLibrary;

internal class frmDownloadFile : Form
{
    private PictureBox pictureBox1;
    private Label label1;
    public ProgressBar progressBar1;
    private IContainer icontainer_0;
    private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    string String_Url = "";
    string String_Name = "";

    public frmDownloadFile(string FileURL, string Filename)
    {
        this.InitializeComponent();

        String_Url = FileURL;
        String_Name = Filename;

        label1.Text = "DOWNLOADING " + String_Name;

        LoopTimer.Interval = 1000;
        LoopTimer.Tick += DoThisAllTheTime;
        LoopTimer.Start();

        /*foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }*/
    }

    void UpdateFiles()
    {
        try
        {
            WebClient webClient = new WebClient();

            webClient.Credentials = new NetworkCredential("bouletmarc", "2f5dc911fb114c165bf46dd4964d3b4b45bff8e0");
            webClient.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs e) { this.progressBar1.Value = e.ProgressPercentage; };
            webClient.DownloadFileAsync(new Uri(String_Url), Application.StartupPath + @"\" + String_Name);
            while (webClient.IsBusy) { Application.DoEvents(); }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch(Exception mess)
        {
            //Console.WriteLine("error downloading file: " + mess);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    void DoThisAllTheTime(object sender, EventArgs e)
    {
        LoopTimer.Stop();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadFile));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Properties.Resources.BMTune_Logo_150x901;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 26);
            this.label1.TabIndex = 28;
            this.label1.Text = "DOWNLOADING !";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(10, 225);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(376, 23);
            this.progressBar1.TabIndex = 29;
            // 
            // frmDownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 258);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadFile";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updating";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

    

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

  
}

