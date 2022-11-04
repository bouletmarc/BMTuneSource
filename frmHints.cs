using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using IWshRuntimeLibrary;

internal class frmHints : Form
{
    private Label label1;
    public ProgressBar progressBar1;
    private IContainer icontainer_0;
    private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    string String_Url = "";
    private Label labelHint;
    private Button buttonOk;
    private Panel panel1;
    private Panel panel2;
    private PictureBox pictureBoxLeft;
    private PictureBox pictureBoxRight;
    int HintShownTime = -1;
    int CurrentTime = 0;

    public frmHints(string ThisHint, bool IsLeft, int ShownTime, Point ThisLocation)
    {
        this.InitializeComponent();

        this.labelHint.Text = ThisHint;
        if (IsLeft)
        {
            this.pictureBoxLeft.Visible = true;
            this.pictureBoxRight.Visible = false;
        }
        else
        {
            this.pictureBoxLeft.Visible = false;
            this.pictureBoxRight.Visible = true;
        }

        this.Location = new Point(ThisLocation.X, ThisLocation.Y);

        HintShownTime = ShownTime * 60;

        if (HintShownTime > 0)
        {
            LoopTimer.Interval = 1;
            LoopTimer.Tick += DoThisAllTheTime;
            LoopTimer.Start();
        }
        else
        {
            this.progressBar1.Visible = false;
        }

        /*foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }*/
    }

    void DoThisAllTheTime(object sender, EventArgs e)
    {
        int Progress = (int)((CurrentTime * 100) / HintShownTime);
        if (Progress < 0) Progress = 0;
        else if (Progress > 100) Progress = 100;
        this.progressBar1.Value = Progress;

        this.Invalidate(true);
        //this.Refresh();
        //this.PerformLayout();
        //Application.DoEvents();

        if (Progress >= 100)
        {
            this.DialogResult = DialogResult.Cancel;
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        CurrentTime++;
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHints));
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelHint = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "Did you know?\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(4, 96);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(388, 10);
            this.progressBar1.TabIndex = 29;
            // 
            // labelHint
            // 
            this.labelHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHint.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHint.Location = new System.Drawing.Point(4, 26);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(388, 29);
            this.labelHint.TabIndex = 30;
            this.labelHint.Text = "You can Customize the gauges layout\r\nline#2";
            this.labelHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(149, 1);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 31;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 25);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Properties.Resources.Help_symbol;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(105, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(24, 24);
            this.panel2.TabIndex = 33;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackgroundImage = global::Properties.Resources.control_180;
            this.pictureBoxLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxLeft.TabIndex = 34;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackgroundImage = global::Properties.Resources.control;
            this.pictureBoxRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRight.Location = new System.Drawing.Point(364, 0);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxRight.TabIndex = 35;
            this.pictureBoxRight.TabStop = false;
            // 
            // frmHints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 110);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHints";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hints";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);

    }

    

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }
}

