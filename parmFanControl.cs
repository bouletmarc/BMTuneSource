using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmFanControl : UserControl
{
    private bool bool_0;
    private bool bool_1;
    private CheckBox chkFanEnable;
    private Class18 class18_0;
    private CtrlOutputSelector ctrlOutputSelector1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label2;
    private Label label1;
    private Label lblEct;
    private Panel panel1;
    private NumericUpDown txtbFanEct;
    private Panel panel2;
    private NumericUpDown numericUpDown1;
    private Label label3;
    private IContainer components;

    public parmFanControl(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.InitializeComponent();
        
        this.ctrlOutputSelector1.method_1(false);
        this.ctrlOutputSelector1.method_3(true);
        this.ctrlOutputSelector1.method_7(true);
        this.ctrlOutputSelector1.method_Output_location(this.class18_0.class13_u_0.long_110);

        this.ctrlOutputSelector1.method_9(ref this.class18_0);
        this.ctrlOutputSelector1.delegate37_0 += new CtrlOutputSelector.Delegate37(this.method_1);
        this.ctrlOutputSelector1.delegate36_0 += new CtrlOutputSelector.Delegate36(this.method_0);
        this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_110, this.class18_0.class13_u_0.long_106 });
        bool enabled = this.groupBox1.Enabled;

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

    private void chkFanEnable_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_2();
        }
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbFanEct = new System.Windows.Forms.NumericUpDown();
            this.lblEct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlOutputSelector1 = new CtrlOutputSelector();
            this.chkFanEnable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFanEct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.txtbFanEct);
            this.groupBox1.Controls.Add(this.lblEct);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctrlOutputSelector1);
            this.groupBox1.Controls.Add(this.chkFanEnable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fan Control";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(4, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 24);
            this.panel2.TabIndex = 25;
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
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Click += new System.EventHandler(this.txtbFanEct_Validated);
            this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFanEct_KeyPress);
            this.numericUpDown1.Validating += new System.ComponentModel.CancelEventHandler(this.txtbFanEct_Validating);
            this.numericUpDown1.Validated += new System.EventHandler(this.txtbFanEct_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bellow Speed:";
            // 
            // txtbFanEct
            // 
            this.txtbFanEct.Location = new System.Drawing.Point(128, 46);
            this.txtbFanEct.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.txtbFanEct.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.txtbFanEct.Name = "txtbFanEct";
            this.txtbFanEct.Size = new System.Drawing.Size(56, 20);
            this.txtbFanEct.TabIndex = 2;
            this.txtbFanEct.Click += new System.EventHandler(this.txtbFanEct_Validated);
            this.txtbFanEct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFanEct_KeyPress);
            this.txtbFanEct.Validating += new System.ComponentModel.CancelEventHandler(this.txtbFanEct_Validating);
            this.txtbFanEct.Validated += new System.EventHandler(this.txtbFanEct_Validated);
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(192, 50);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 24;
            this.lblEct.Text = "C";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fan Output:";
            // 
            // ctrlOutputSelector1
            // 
            this.ctrlOutputSelector1.Location = new System.Drawing.Point(8, 113);
            this.ctrlOutputSelector1.Name = "ctrlOutputSelector1";
            this.ctrlOutputSelector1.Size = new System.Drawing.Size(215, 50);
            this.ctrlOutputSelector1.TabIndex = 4;
            // 
            // chkFanEnable
            // 
            this.chkFanEnable.AutoSize = true;
            this.chkFanEnable.Location = new System.Drawing.Point(14, 23);
            this.chkFanEnable.Name = "chkFanEnable";
            this.chkFanEnable.Size = new System.Drawing.Size(127, 18);
            this.chkFanEnable.TabIndex = 2;
            this.chkFanEnable.Text = "Enable Fan Control";
            this.chkFanEnable.UseVisualStyleBackColor = true;
            this.chkFanEnable.CheckedChanged += new System.EventHandler(this.chkFanEnable_CheckedChanged);
            this.chkFanEnable.Validated += new System.EventHandler(this.parmFanControl_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Above ECT:";
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
            this.panel1.Size = new System.Drawing.Size(281, 227);
            this.panel1.TabIndex = 1;
            // 
            // parmFanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmFanControl";
            this.Size = new System.Drawing.Size(281, 227);
            this.Load += new System.EventHandler(this.parmFanControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFanEct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Fan Control Output Invert");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_111, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Fan Control Output");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_110, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_2()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Fan Control settings");
            if (this.chkFanEnable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_105, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_105, 0);
            }
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_106, this.class18_0.method_230(double.Parse(this.txtbFanEct.Text)));


            if (this.class18_0.RomVersion < 110)
            {
                panel2.Visible = false;
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_474, this.class18_0.method_233(int.Parse(this.numericUpDown1.Text)));
            }


            this.class18_0.method_153();
            this.parmFanControl_Load(null, null);
        }
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmFanControl_Load(null, null);
        }
    }

    private void parmFanControl_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();
        this.ctrlOutputSelector1.method_10(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_110));
        this.ctrlOutputSelector1.method_1(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_111) != 0);
        this.chkFanEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_105) == 0xff;
        this.txtbFanEct.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_106)).ToString();

        if (!this.chkFanEnable.Checked)
        {
            this.txtbFanEct.Enabled = false;
            this.ctrlOutputSelector1.Enabled = false;
        }
        else
        {
            this.txtbFanEct.Enabled = true;
            this.ctrlOutputSelector1.Enabled = true;
        }

        if (this.class18_0.RomVersion < 110)
        {
            panel2.Visible = false;
        }
        else
        {
            this.numericUpDown1.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_474)).ToString();
        }
        this.bool_0 = false;
    }

    private void txtbFanEct_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            this.bool_1 = true;
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_2();
            }
            control.Focus();
        }
        this.bool_1 = false;
    }

    private void txtbFanEct_Validated(object sender, EventArgs e)
    {
        if (!this.bool_0 && !this.bool_1)
        {
            this.method_2();
        }
    }

    private void txtbFanEct_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_255(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Int required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

