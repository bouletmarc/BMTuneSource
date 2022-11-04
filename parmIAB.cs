using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmIAB : UserControl
{
    private bool bool_0;
    private CheckBox chkEnable;
    private CheckBox chkIabOutput;
    private CheckBox chkInv;
    private Class18 class18_0;
    private CtrlOutputSelector ctrlOutputIabAlt;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox4;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private IContainer components;
    private Label label4;
    private Label label3;
    private NumericUpDown txtbReset;
    private NumericUpDown txtbSet;
    private Panel panel1;

    internal parmIAB(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_2);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_2);
        this.InitializeComponent();

        this.ctrlOutputIabAlt.method_1(false);
        this.ctrlOutputIabAlt.method_3(true);
        this.ctrlOutputIabAlt.method_7(true);
        this.ctrlOutputIabAlt.method_Output_location(this.class18_0.class13_u_0.long_239);

        this.ctrlOutputIabAlt.method_9(ref this.class18_0);
        this.ctrlOutputIabAlt.method_8();
        this.ctrlOutputIabAlt.delegate37_0 += new CtrlOutputSelector.Delegate37(this.method_1);
        this.ctrlOutputIabAlt.delegate36_0 += new CtrlOutputSelector.Delegate36(this.method_0);

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
            this.txtbReset = new System.Windows.Forms.NumericUpDown();
            this.txtbSet = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ctrlOutputIabAlt = new CtrlOutputSelector();
            this.label2 = new System.Windows.Forms.Label();
            this.chkInv = new System.Windows.Forms.CheckBox();
            this.chkIabOutput = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSet)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbReset);
            this.groupBox1.Controls.Add(this.txtbSet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkInv);
            this.groupBox1.Controls.Add(this.chkIabOutput);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IAB Activation";
            // 
            // txtbReset
            // 
            this.txtbReset.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbReset.Location = new System.Drawing.Point(80, 124);
            this.txtbReset.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbReset.Name = "txtbReset";
            this.txtbReset.Size = new System.Drawing.Size(61, 20);
            this.txtbReset.TabIndex = 11;
            this.txtbReset.Click += new System.EventHandler(this.txtbReset_Validated);
            this.txtbReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbReset_KeyPress);
            this.txtbReset.Validating += new System.ComponentModel.CancelEventHandler(this.txtbReset_Validating);
            this.txtbReset.Validated += new System.EventHandler(this.txtbReset_Validated);
            // 
            // txtbSet
            // 
            this.txtbSet.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbSet.Location = new System.Drawing.Point(80, 96);
            this.txtbSet.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbSet.Name = "txtbSet";
            this.txtbSet.Size = new System.Drawing.Size(61, 20);
            this.txtbSet.TabIndex = 10;
            this.txtbSet.Click += new System.EventHandler(this.txtbReset_Validated);
            this.txtbSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbReset_KeyPress);
            this.txtbSet.Validating += new System.ComponentModel.CancelEventHandler(this.txtbReset_Validating);
            this.txtbSet.Validated += new System.EventHandler(this.txtbReset_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "rpm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "rpm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Engage:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ctrlOutputIabAlt);
            this.groupBox4.Location = new System.Drawing.Point(7, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(227, 81);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Alternate IAB Output:";
            // 
            // ctrlOutputIabAlt
            // 
            this.ctrlOutputIabAlt.Enabled = false;
            this.ctrlOutputIabAlt.Location = new System.Drawing.Point(7, 20);
            this.ctrlOutputIabAlt.Name = "ctrlOutputIabAlt";
            this.ctrlOutputIabAlt.Size = new System.Drawing.Size(216, 50);
            this.ctrlOutputIabAlt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Disengage:";
            // 
            // chkInv
            // 
            this.chkInv.AutoSize = true;
            this.chkInv.Location = new System.Drawing.Point(7, 70);
            this.chkInv.Name = "chkInv";
            this.chkInv.Size = new System.Drawing.Size(119, 18);
            this.chkInv.TabIndex = 3;
            this.chkInv.Text = "Invert IAB Output";
            this.chkInv.UseVisualStyleBackColor = true;
            this.chkInv.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // chkIabOutput
            // 
            this.chkIabOutput.AutoSize = true;
            this.chkIabOutput.Location = new System.Drawing.Point(7, 45);
            this.chkIabOutput.Name = "chkIabOutput";
            this.chkIabOutput.Size = new System.Drawing.Size(83, 18);
            this.chkIabOutput.TabIndex = 2;
            this.chkIabOutput.Text = "USDM ECU";
            this.chkIabOutput.UseVisualStyleBackColor = true;
            this.chkIabOutput.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(7, 20);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(82, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable IAB";
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
            this.panel1.Size = new System.Drawing.Size(280, 259);
            this.panel1.TabIndex = 1;
            // 
            // parmIAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmIAB";
            this.Size = new System.Drawing.Size(280, 259);
            this.Load += new System.EventHandler(this.parmIAB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSet)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("IAB Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_240, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("IAB Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_239, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_2()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmIAB_Load(null, null);
        }
    }

    private void method_3()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("IAB Settings");
            if (this.chkEnable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_234, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_234, 0);
            }
            if (this.chkIabOutput.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_236, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_236, 0);
            }
            int ByteLocationDifference = 1;
            //if (this.class18_0.RomVersion >= 111) ByteLocationDifference = 2;

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_235, this.class18_0.method_216(int.Parse(this.txtbReset.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_235 + ByteLocationDifference, this.class18_0.method_216(int.Parse(this.txtbSet.Text)));
            if (this.class18_0.class13_u_0.long_237 != 0L)
            {
                if (this.chkInv.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_237, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_237, 0);
                }
            }
            this.class18_0.method_153();
            this.parmIAB_Load(null, null);
        }
    }

    private void parmIAB_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_234) == 0xff;
        if (this.chkEnable.Checked)
        {
            this.chkIabOutput.Enabled = true;
            this.chkInv.Enabled = true;
            this.txtbReset.Enabled = true;
            this.txtbSet.Enabled = true;
        }
        else
        {
            this.chkIabOutput.Enabled = false;
            this.chkInv.Enabled = false;
            this.txtbReset.Enabled = false;
            this.txtbSet.Enabled = false;
        }
        int ByteLocationDifference = 1;
        //if (this.class18_0.RomVersion >= 111) ByteLocationDifference = 2;

        this.chkIabOutput.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_236) == 0xff;
        this.txtbReset.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_235)).ToString();
        this.txtbSet.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_235 + ByteLocationDifference)).ToString();
        if (this.class18_0.class13_u_0.long_237 != 0L)
        {
            this.chkInv.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_237) == 0xff;
        }
        this.groupBox4.Enabled = (this.class18_0.class13_u_0.long_239 != 0L) && this.chkEnable.Checked;
        if (this.class18_0.class13_u_0.long_239 != 0L)
        {
            this.ctrlOutputIabAlt.method_10(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_239));
            this.ctrlOutputIabAlt.method_1(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_240) == 0xff);
            this.ctrlOutputIabAlt.Enabled = true;
        }
        this.bool_0 = false;
    }

    private void txtbReset_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_3();
            }
            control.Focus();
        }
    }

    private void txtbReset_Validated(object sender, EventArgs e)
    {
        this.method_3();
    }

    private void txtbReset_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
        if (!e.Cancel && ((control.Name == "txtbSet") || (control.Name == "txtbReset")))
        {
            if (int.Parse(this.txtbSet.Text) <= int.Parse(this.txtbReset.Text))
            {
                this.errorProvider_0.SetError(control, "IAB set should be higher then reset!");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider_0.SetError(control, "");
            }
        }
    }
}

