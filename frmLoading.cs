using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

internal class frmLoading : Form
{
    public ProgressBar progressBar1;
    private IContainer icontainer_0;
    private Label label1;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;

    //private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    private List<string> InfoList = new List<string>();

    public frmLoading()
    {
        this.InitializeComponent();
        
        //this.Location = new Point(this.Location.X, this.Location.Y / 2);

        InfoList.Add("Realtime Tuning");
        InfoList.Add("Chip Burning");
        InfoList.Add("Read Chip");
        InfoList.Add("Write Chip");
        InfoList.Add("Erase Chip");
        InfoList.Add("Upload to Emulator");
        InfoList.Add("Download from Emulator");
        InfoList.Add("Datalog Engine Datas");
        InfoList.Add("Antitheft Protection");
        InfoList.Add("Popcorn Mod");
        InfoList.Add("Ajustable Launch Control");
        InfoList.Add("Full Throttle Shift");
        InfoList.Add("Rolling Antilag (FTS)");
        InfoList.Add("Ignition Cut Mod");
        InfoList.Add("Closeloop with Wideband");
        InfoList.Add("Air/Fuel Target");
        InfoList.Add("Record Datalog");
        InfoList.Add("Save Tunes as .bin");
        InfoList.Add("Unlimited Tunes");
        InfoList.Add("Premade Calibrations");
        InfoList.Add("Internet Calibrations");
        InfoList.Add("Biggest List of Baseroms");
        InfoList.Add("CEL Shift Light");
        InfoList.Add("Injectors Selection");
        InfoList.Add("Wideband Selection");
        InfoList.Add("TPS Calibration");
        InfoList.Add("Ignition Sync");
        InfoList.Add("Realtime Datalog");
        InfoList.Add("Map Tracing");
        InfoList.Add("2D Tables Graph");
        InfoList.Add("3D Tables Graph");
        InfoList.Add("Injectors Phasing");
        InfoList.Add("Password Protection");
        InfoList.Add("ECT Temp Protection");
        InfoList.Add("Friendly user GUI");
        InfoList.Add("Debug Logging");
        InfoList.Add("Create new basemap");
        InfoList.Add("Gauges Display");
        InfoList.Add("Graph Display");
        InfoList.Add("Datas Display");
        InfoList.Add("Customize Graph");
        InfoList.Add("Customize Gauge");
        InfoList.Add("Customize Layout");
        InfoList.Add("Customize Color");
        InfoList.Add("Full Analogs Gesture");
        InfoList.Add("Electronic Boost Control");
        InfoList.Add("Boost Cut Protection");
        InfoList.Add("Fuel cut on Decel");
        InfoList.Add("Moates Ostrich2.0");
        InfoList.Add("Moates Ostrich1.0");
        InfoList.Add("Moates Demon1");
        InfoList.Add("Moates Demon2");
        InfoList.Add("Moates Hulog");
        InfoList.Add("Bluetooth Datalog");
        InfoList.Add("Bluetooth HC05");
        InfoList.Add("FTDI FT232RL");
        InfoList.Add("RS232 USB to TLL");
        InfoList.Add("EasyRTP Emulator");
        InfoList.Add("BMBurner");
        InfoList.Add("BMLogger");
        InfoList.Add("BM2Step");
        InfoList.Add("BMulator");
        InfoList.Add("BM2Timer"); ;
        InfoList.Add("BMSimulator");
        InfoList.Add("BMDatalogger");
        InfoList.Add("BMulator");
        InfoList.Add("BMCOP");
        InfoList.Add("BMFlexFuel");
        InfoList.Add("BMDevs");
        InfoList.Add("ISR Datalog Protocol");
        InfoList.Add("OBD1 Ecu Tuning");
        //InfoList.Add("OBD0-1-2 Ecu Tuning");
        InfoList.Add("Honda/Acura Tuning Software");
        //InfoList.Add("Made by Bouletmarc");
        //InfoList.Add("Made by BMDevs");
        InfoList.Add("Universal Baserom Editor");
        InfoList.Add("XDF/XML File Editor");
        InfoList.Add("Bosch Motronic Ecu Tuning");
        InfoList.Add("ME7.X Ecu Tuning");
        InfoList.Add("Volks/Audi Tuning Software");
        InfoList.Add("Realtime Datalogging");
        //InfoList.Add("J2334 OBDII Interface");
        //InfoList.Add("CanBUS Interface");
        InfoList.Add("B-D-F-H Serie Ecu Tuning");
        InfoList.Add("Created in 2017");
        InfoList.Add("Live Graphing");
        //InfoList.Add("");

        /*LoopTimer.Interval = 50;
        LoopTimer.Tick += DoThisAllTheTime;
        LoopTimer.Start();*/
    }

    void DoThisAllTheTime(object sender, EventArgs e)
    {
        /*Random rnd = new Random();
        this.label1.Text = InfoList[rnd.Next(0, InfoList.Count - 1)];
        this.Refresh();*/
    }

    public void SetPercent(int Percent)
    {
        this.progressBar1.Value = Percent;

        Random rnd = new Random();
        this.label1.Text = InfoList[rnd.Next(0, InfoList.Count - 1)];
        this.Refresh();

        if (Percent == 100) this.Close();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(10, 154);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(355, 11);
            this.progressBar1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 31);
            this.label1.TabIndex = 32;
            this.label1.Text = "LOADING !";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Properties.Resources.Piston_Animation_Small;
            this.pictureBox1.Location = new System.Drawing.Point(303, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::Properties.Resources.Piston_Animation_Small;
            this.pictureBox2.Location = new System.Drawing.Point(2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 119);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = global::Properties.Resources.BMTune_Logo_150x901;
            this.pictureBox3.Location = new System.Drawing.Point(70, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(234, 119);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(375, 175);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoading";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updating";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

    }
}

