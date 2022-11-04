using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

internal class frmReset : Form
{
    private IContainer icontainer_0;
    private LinkLabel linkBMTune;
    private LinkLabel linkForum;
    private Button okButton;
    private Label label1;
    private TextBox textBoxDescription;

    public frmReset()
    {
        this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReset));
            this.linkBMTune = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.linkForum = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkBMTune
            // 
            this.linkBMTune.AutoSize = true;
            this.linkBMTune.Location = new System.Drawing.Point(16, 302);
            this.linkBMTune.Name = "linkBMTune";
            this.linkBMTune.Size = new System.Drawing.Size(50, 14);
            this.linkBMTune.TabIndex = 29;
            this.linkBMTune.TabStop = true;
            this.linkBMTune.Text = "Website";
            this.linkBMTune.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBMTune_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.AutoSize = true;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(326, 297);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 25);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&Close";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.Location = new System.Drawing.Point(10, 47);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(403, 245);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            // 
            // linkForum
            // 
            this.linkForum.AutoSize = true;
            this.linkForum.Location = new System.Drawing.Point(99, 302);
            this.linkForum.Name = "linkForum";
            this.linkForum.Size = new System.Drawing.Size(89, 14);
            this.linkForum.TabIndex = 30;
            this.linkForum.TabStop = true;
            this.linkForum.Text = "Facebook Page";
            this.linkForum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForum_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(72, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 24);
            this.label1.TabIndex = 31;
            this.label1.Text = "* IMPORTANT *\r\nPLEASE READ THE RESET REQUEST CAREFULLY\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmReset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 327);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.linkBMTune);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.linkForum);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReset";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Reset Request";
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void linkBMTune_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start("http://www.bmtune.com/");
    }

    private void linkForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start("https://www.facebook.com/BMTuneSoftware/");
    }

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }
}

