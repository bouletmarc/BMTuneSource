using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmCPR : UserControl
{
    private bool bool_0;
    private CheckBox chkEnable;
    private CheckBox chkFullySync;
    private CheckBox chkDontFire;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private IContainer components;
    private Panel panel1;

    internal parmCPR(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_2);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_2);
        this.InitializeComponent();


        if (this.class18_0.RomVersion < 116)
        {
            groupBox1.Enabled = false;
            groupBox1.Text += " *1.16++ Rom ONLY*";
        }

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        this.method_3();
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDontFire = new System.Windows.Forms.CheckBox();
            this.chkFullySync = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDontFire);
            this.groupBox1.Controls.Add(this.chkFullySync);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPR - Coil on Plugs Retrofit";
            // 
            // chkDontFire
            // 
            this.chkDontFire.AutoSize = true;
            this.chkDontFire.Location = new System.Drawing.Point(7, 70);
            this.chkDontFire.Name = "chkDontFire";
            this.chkDontFire.Size = new System.Drawing.Size(257, 18);
            this.chkDontFire.TabIndex = 3;
            this.chkDontFire.Text = "Don\'t fire injectors before synchronization";
            this.chkDontFire.UseVisualStyleBackColor = true;
            this.chkDontFire.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // chkFullySync
            // 
            this.chkFullySync.AutoSize = true;
            this.chkFullySync.Location = new System.Drawing.Point(7, 45);
            this.chkFullySync.Name = "chkFullySync";
            this.chkFullySync.Size = new System.Drawing.Size(207, 18);
            this.chkFullySync.TabIndex = 2;
            this.chkFullySync.Text = "Fully synchronize when cranking";
            this.chkFullySync.UseVisualStyleBackColor = true;
            this.chkFullySync.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(7, 20);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(228, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable ignition SYNC Output on ALTC";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 114);
            this.panel1.TabIndex = 1;
            // 
            // parmCPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmCPR";
            this.Size = new System.Drawing.Size(299, 114);
            this.Load += new System.EventHandler(this.parmCPR_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_2()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmCPR_Load(null, null);
        }
    }

    private void method_3()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("CPR Settings");
            if (this.chkEnable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_521, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_521, 0);

            if (this.chkFullySync.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_522, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_522, 0);

            if (this.chkDontFire.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_523, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_523, 0);

            this.class18_0.method_153();
            this.parmCPR_Load(null, null);
        }
    }

    private void parmCPR_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_521) == 0xff;
        if (this.chkEnable.Checked)
        {
            this.chkFullySync.Enabled = true;
            this.chkDontFire.Enabled = true;
        }
        else
        {
            this.chkFullySync.Enabled = false;
            this.chkDontFire.Enabled = false;
        }

        this.chkFullySync.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_522) == 0xff;
        this.chkDontFire.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_523) == 0xff;

        this.bool_0 = false;
    }
}

