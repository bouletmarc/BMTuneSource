using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmEctProtection : UserControl
{
    private bool bool_0;
    private CheckBox chkEnable;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label2;
    private Label label6;
    private IContainer components;
    private Label lblEct;
    private NumericUpDown txtbRpm;
    private NumericUpDown txtbEct;
    private Panel panel1;

    public parmEctProtection(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

        this.groupBox1.Enabled = true;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
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
            this.lblEct = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbRpm = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbEct = new System.Windows.Forms.NumericUpDown();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbEct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEct);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtbRpm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtbEct);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ECT Protection";
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(160, 58);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 24;
            this.lblEct.Text = "C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Limit RPM to:";
            // 
            // txtbRpm
            // 
            this.txtbRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbRpm.Location = new System.Drawing.Point(92, 82);
            this.txtbRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbRpm.Name = "txtbRpm";
            this.txtbRpm.Size = new System.Drawing.Size(62, 20);
            this.txtbRpm.TabIndex = 2;
            this.txtbRpm.Click += new System.EventHandler(this.txtbEct_Validated);
            this.txtbRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEct_KeyPress);
            this.txtbRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEct_Validating);
            this.txtbRpm.Validated += new System.EventHandler(this.txtbEct_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Above ECT:";
            // 
            // txtbEct
            // 
            this.txtbEct.Location = new System.Drawing.Point(92, 56);
            this.txtbEct.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.txtbEct.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.txtbEct.Name = "txtbEct";
            this.txtbEct.Size = new System.Drawing.Size(62, 20);
            this.txtbEct.TabIndex = 1;
            this.txtbEct.Click += new System.EventHandler(this.txtbEct_Validated);
            this.txtbEct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEct_KeyPress);
            this.txtbEct.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEct_Validating);
            this.txtbEct.Validated += new System.EventHandler(this.txtbEct_Validated);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(9, 23);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(145, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable ECT Protection";
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
            this.panel1.Size = new System.Drawing.Size(236, 234);
            this.panel1.TabIndex = 1;
            // 
            // parmEctProtection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmEctProtection";
            this.Size = new System.Drawing.Size(236, 234);
            this.Load += new System.EventHandler(this.parmEctProtection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbEct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmEctProtection_Load(null, null);
        }
    }

    private void method_1()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("Overheat Protection", false);
            if (this.class18_0.class13_u_0.long_133 != 0L)
            {
                if (this.chkEnable.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_133, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_133, 0);
                }
            }
            if (this.class18_0.class13_u_0.long_132 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_132, this.class18_0.method_230(double.Parse(this.txtbEct.Text)));
            }
            if (this.class18_0.class13_u_0.long_135 != 0L)
            {
                this.class18_0.method_151(this.class18_0.class13_u_0.long_135, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)));
            }
            this.class18_0.method_153();
            this.parmEctProtection_Load(null, null);
        }
    }

    private void parmEctProtection_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;

        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();

        if (this.class18_0.class13_u_0.long_133 == 0L)
        {
            this.chkEnable.Enabled = false;
        }
        else
        {
            this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_133) != 0;
        }
        if (this.chkEnable.Checked)
        {
            this.txtbEct.Enabled = this.class18_0.class13_u_0.long_132 != 0L;
            this.txtbRpm.Enabled = this.class18_0.class13_u_0.long_135 != 0L;
        }
        else
        {
            this.txtbEct.Enabled = false;
            this.txtbRpm.Enabled = false;
        }
        if (this.class18_0.class13_u_0.long_132 != 0L) this.txtbEct.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_132)).ToString();
        if (this.class18_0.class13_u_0.long_135 != 0L) this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_135)).ToString();
        this.bool_0 = false;
    }

    private void txtbEct_KeyPress(object sender, KeyPressEventArgs e)
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

    private void txtbEct_Validated(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbEct_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

