using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmAc : UserControl
{
    private bool bool_0;
    private CheckBox chkAcCut;
    private CheckBox chkDisable;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private Label label7;
    private Label label8;
    private IContainer components;
    private GroupBox groupBox1;
    private NumericUpDown txtbCutTps;
    private NumericUpDown txtbCutRpm;
    private NumericUpDown txtbIdleCut;
    private NumericUpDown txtbIdleRes;
    private Panel panel2;
    private NumericUpDown numericUpDown1;
    private Label label3;
    private Panel panel1;

    public parmAc(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();
        if (this.class18_0.RomVersion < 110)
        {
            panel2.Visible = false;
        }
        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkAcCut_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkAcCut.Checked)
        {
            this.txtbCutTps.Enabled = true;
            this.txtbCutRpm.Enabled = true;
            this.numericUpDown1.Enabled = true;
        }
        else
        {
            this.txtbCutRpm.Enabled = false;
            this.txtbCutTps.Enabled = false;
            this.numericUpDown1.Enabled = false;
        }
        if (!this.bool_0)
        {
            this.method_1();
            this.parmAc_Load(null, null);
        }
    }

    private void chkDisable_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
        this.parmAc_Load(null, null);
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
            this.chkDisable = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbCutTps = new System.Windows.Forms.NumericUpDown();
            this.txtbCutRpm = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAcCut = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbIdleCut = new System.Windows.Forms.NumericUpDown();
            this.txtbIdleRes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutTps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutRpm)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIdleCut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIdleRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDisable
            // 
            this.chkDisable.AutoSize = true;
            this.chkDisable.Location = new System.Drawing.Point(16, 19);
            this.chkDisable.Name = "chkDisable";
            this.chkDisable.Size = new System.Drawing.Size(84, 18);
            this.chkDisable.TabIndex = 1;
            this.chkDisable.Text = "Disable AC";
            this.chkDisable.UseVisualStyleBackColor = true;
            this.chkDisable.CheckedChanged += new System.EventHandler(this.chkDisable_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.txtbCutTps);
            this.groupBox3.Controls.Add(this.txtbCutRpm);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chkAcCut);
            this.groupBox3.Location = new System.Drawing.Point(10, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 112);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AC Cutoff";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(1, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 24);
            this.panel2.TabIndex = 7;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(124, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Click += new System.EventHandler(this.txtbIdleCut_Validated);
            this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIdleCut_KeyPress);
            this.numericUpDown1.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIdleCut_Validating);
            this.numericUpDown1.Validated += new System.EventHandler(this.txtbIdleCut_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Above Speed:";
            // 
            // txtbCutTps
            // 
            this.txtbCutTps.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbCutTps.Location = new System.Drawing.Point(125, 61);
            this.txtbCutTps.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbCutTps.Name = "txtbCutTps";
            this.txtbCutTps.Size = new System.Drawing.Size(62, 20);
            this.txtbCutTps.TabIndex = 10;
            this.txtbCutTps.Click += new System.EventHandler(this.txtbIdleCut_Validated);
            this.txtbCutTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIdleCut_KeyPress);
            this.txtbCutTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIdleCut_Validating);
            this.txtbCutTps.Validated += new System.EventHandler(this.txtbIdleCut_Validated);
            // 
            // txtbCutRpm
            // 
            this.txtbCutRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbCutRpm.Location = new System.Drawing.Point(125, 37);
            this.txtbCutRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbCutRpm.Name = "txtbCutRpm";
            this.txtbCutRpm.Size = new System.Drawing.Size(62, 20);
            this.txtbCutRpm.TabIndex = 9;
            this.txtbCutRpm.Click += new System.EventHandler(this.txtbIdleCut_Validated);
            this.txtbCutRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIdleCut_KeyPress);
            this.txtbCutRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIdleCut_Validating);
            this.txtbCutRpm.Validated += new System.EventHandler(this.txtbIdleCut_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "Above TPS:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "Above RPM:";
            // 
            // chkAcCut
            // 
            this.chkAcCut.AutoSize = true;
            this.chkAcCut.Location = new System.Drawing.Point(6, 19);
            this.chkAcCut.Name = "chkAcCut";
            this.chkAcCut.Size = new System.Drawing.Size(117, 18);
            this.chkAcCut.TabIndex = 6;
            this.chkAcCut.Text = "Enable AC Cutoff";
            this.chkAcCut.UseVisualStyleBackColor = true;
            this.chkAcCut.CheckedChanged += new System.EventHandler(this.chkAcCut_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbIdleCut);
            this.groupBox2.Controls.Add(this.txtbIdleRes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(10, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 60);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Idle Recovery";
            // 
            // txtbIdleCut
            // 
            this.txtbIdleCut.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbIdleCut.Location = new System.Drawing.Point(125, 11);
            this.txtbIdleCut.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbIdleCut.Name = "txtbIdleCut";
            this.txtbIdleCut.Size = new System.Drawing.Size(62, 20);
            this.txtbIdleCut.TabIndex = 11;
            this.txtbIdleCut.Click += new System.EventHandler(this.txtbIdleCut_Validated);
            this.txtbIdleCut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIdleCut_KeyPress);
            this.txtbIdleCut.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIdleCut_Validating);
            this.txtbIdleCut.Validated += new System.EventHandler(this.txtbIdleCut_Validated);
            // 
            // txtbIdleRes
            // 
            this.txtbIdleRes.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbIdleRes.Location = new System.Drawing.Point(125, 34);
            this.txtbIdleRes.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbIdleRes.Name = "txtbIdleRes";
            this.txtbIdleRes.Size = new System.Drawing.Size(62, 20);
            this.txtbIdleRes.TabIndex = 12;
            this.txtbIdleRes.Click += new System.EventHandler(this.txtbIdleCut_Validated);
            this.txtbIdleRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIdleCut_KeyPress);
            this.txtbIdleRes.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIdleCut_Validating);
            this.txtbIdleRes.Validated += new System.EventHandler(this.txtbIdleCut_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Resume Above RPM:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cut Below RPM:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDisable);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 226);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AC Settings";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 296);
            this.panel1.TabIndex = 7;
            // 
            // parmAc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "parmAc";
            this.Size = new System.Drawing.Size(236, 296);
            this.Load += new System.EventHandler(this.parmAc_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutTps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutRpm)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIdleCut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIdleRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmAc_Load(null, null);
        }
    }

    private void method_1()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("AC settings");
            if (this.chkAcCut.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_123, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_123, 0);
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_124, this.class18_0.method_219(int.Parse(this.txtbCutRpm.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_121, this.class18_0.method_219(int.Parse(this.txtbIdleCut.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_122, this.class18_0.method_219(int.Parse(this.txtbIdleRes.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_125, this.class18_0.method_228(int.Parse(this.txtbCutTps.Text)));
            if (this.chkDisable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_77, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_77, 0);
            }

            if (this.class18_0.RomVersion < 110)
            {
                panel2.Visible = false;
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_475, this.class18_0.method_233(int.Parse(this.numericUpDown1.Text)));
            }
            this.parmAc_Load(null, null);
            this.class18_0.method_153();
        }
    }

    private void parmAc_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.chkAcCut.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_123) == 0xff;
        this.txtbCutRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_124)).ToString();
        this.txtbIdleCut.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_121)).ToString();
        this.txtbIdleRes.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_122)).ToString();
        this.txtbCutTps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_125)).ToString();
        this.chkDisable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_77) == 0xff;

        if (this.chkDisable.Checked)
        {
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
        }
        else
        {
            this.groupBox2.Enabled = true;
            this.groupBox3.Enabled = true;
        }
        if (this.chkAcCut.Checked)
        {
            this.txtbCutTps.Enabled = true;
            this.txtbCutRpm.Enabled = true;
            this.numericUpDown1.Enabled = true;
        }
        else
        {
            this.txtbCutRpm.Enabled = false;
            this.txtbCutTps.Enabled = false;
            this.numericUpDown1.Enabled = false;
        }

        if (this.class18_0.RomVersion < 110)
        {
            panel2.Visible = false;
        }
        else
        {
            this.numericUpDown1.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_475)).ToString();
        }
        this.bool_0 = false;
    }

    private void txtbIdleCut_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_1();
            }
            control.Focus();
        }
    }

    private void txtbIdleCut_Validated(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbIdleCut_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        this.groupBox1.Focus();
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
        if (!e.Cancel && ((control.Name == "txtbIdleCut") || (control.Name == "txtbIdleRes")))
        {
            if (int.Parse(this.txtbIdleCut.Text) >= int.Parse(this.txtbIdleRes.Text))
            {
                this.errorProvider_0.SetError(control, "Idle cut should be higer then idle resume!");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider_0.SetError(control, "");
            }
        }
    }
}

