using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmDualMap : UserControl
{
    private bool bool_0;
    private CheckBox chkLoad;
    private CheckBox chkRpm;
    private CheckBox chkTps;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInputSelector1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox grpCross;
    private GroupBox grpInputSw;
    private GroupBox grpSet;
    private IContainer icontainer_0;
    private Label label3;
    private Label lblLoad;
    private RadioButton rbDis;
    private RadioButton rbInput;
    private RadioButton rdCross;
    private IContainer components;
    private Panel panel1;
    private NumericUpDown txtbRpm;
    private NumericUpDown txtbTps;
    private NumericUpDown txtbLoad;

    public parmDualMap(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInputSelector1.method_3_CustomInput("Always On");
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(true);
        this.ctrlInputSelector1.method_5(false);
        //this.ctrlInputSelector1.method_1(0);
        this.ctrlInputSelector1.method_Input_location(this.class18_0.class13_u_0.long_283);

        this.ctrlInputSelector1.method_14(ref this.class18_0);
        this.ctrlInputSelector1.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_2);
        this.ctrlInputSelector1.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_1);
        //this.ctrlInputSelector1.method_1(1);
        this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_282, this.class18_0.class13_u_0.long_290 });
        if (this.groupBox1.Enabled)
        {
            this.ctrlInputSelector1.method_12();
        }

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkLoad_CheckedChanged(object sender, EventArgs e)
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
            this.grpSet = new System.Windows.Forms.GroupBox();
            this.rbDis = new System.Windows.Forms.RadioButton();
            this.rdCross = new System.Windows.Forms.RadioButton();
            this.rbInput = new System.Windows.Forms.RadioButton();
            this.grpInputSw = new System.Windows.Forms.GroupBox();
            this.ctrlInputSelector1 = new CtrlInputSelector();
            this.grpCross = new System.Windows.Forms.GroupBox();
            this.txtbRpm = new System.Windows.Forms.NumericUpDown();
            this.chkRpm = new System.Windows.Forms.CheckBox();
            this.txtbTps = new System.Windows.Forms.NumericUpDown();
            this.chkTps = new System.Windows.Forms.CheckBox();
            this.txtbLoad = new System.Windows.Forms.NumericUpDown();
            this.chkLoad = new System.Windows.Forms.CheckBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.grpSet.SuspendLayout();
            this.grpInputSw.SuspendLayout();
            this.grpCross.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpSet);
            this.groupBox1.Controls.Add(this.grpInputSw);
            this.groupBox1.Controls.Add(this.grpCross);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secondary Map Settings";
            // 
            // grpSet
            // 
            this.grpSet.Controls.Add(this.rbDis);
            this.grpSet.Controls.Add(this.rdCross);
            this.grpSet.Controls.Add(this.rbInput);
            this.grpSet.Location = new System.Drawing.Point(7, 20);
            this.grpSet.Name = "grpSet";
            this.grpSet.Size = new System.Drawing.Size(233, 94);
            this.grpSet.TabIndex = 1;
            this.grpSet.TabStop = false;
            this.grpSet.Text = "Activation";
            // 
            // rbDis
            // 
            this.rbDis.AutoSize = true;
            this.rbDis.Location = new System.Drawing.Point(17, 17);
            this.rbDis.Name = "rbDis";
            this.rbDis.Size = new System.Drawing.Size(95, 18);
            this.rbDis.TabIndex = 1;
            this.rbDis.TabStop = true;
            this.rbDis.Text = "Normal Mode";
            this.rbDis.UseVisualStyleBackColor = true;
            this.rbDis.CheckedChanged += new System.EventHandler(this.rbInput_CheckedChanged);
            // 
            // rdCross
            // 
            this.rdCross.AutoSize = true;
            this.rdCross.Location = new System.Drawing.Point(17, 67);
            this.rdCross.Name = "rdCross";
            this.rdCross.Size = new System.Drawing.Size(111, 18);
            this.rdCross.TabIndex = 2;
            this.rdCross.TabStop = true;
            this.rdCross.Text = "Condition Mode";
            this.rdCross.UseVisualStyleBackColor = true;
            this.rdCross.CheckedChanged += new System.EventHandler(this.rbInput_CheckedChanged);
            // 
            // rbInput
            // 
            this.rbInput.AutoSize = true;
            this.rbInput.Location = new System.Drawing.Point(17, 42);
            this.rbInput.Name = "rbInput";
            this.rbInput.Size = new System.Drawing.Size(86, 18);
            this.rbInput.TabIndex = 1;
            this.rbInput.TabStop = true;
            this.rbInput.Text = "Input Mode";
            this.rbInput.UseVisualStyleBackColor = true;
            this.rbInput.CheckedChanged += new System.EventHandler(this.rbInput_CheckedChanged);
            // 
            // grpInputSw
            // 
            this.grpInputSw.Controls.Add(this.ctrlInputSelector1);
            this.grpInputSw.Location = new System.Drawing.Point(7, 121);
            this.grpInputSw.Name = "grpInputSw";
            this.grpInputSw.Size = new System.Drawing.Size(233, 81);
            this.grpInputSw.TabIndex = 1;
            this.grpInputSw.TabStop = false;
            this.grpInputSw.Text = "Input Mode";
            // 
            // ctrlInputSelector1
            // 
            this.ctrlInputSelector1.Location = new System.Drawing.Point(7, 20);
            this.ctrlInputSelector1.Name = "ctrlInputSelector1";
            this.ctrlInputSelector1.Size = new System.Drawing.Size(215, 53);
            this.ctrlInputSelector1.TabIndex = 0;
            // 
            // grpCross
            // 
            this.grpCross.Controls.Add(this.txtbRpm);
            this.grpCross.Controls.Add(this.chkRpm);
            this.grpCross.Controls.Add(this.txtbTps);
            this.grpCross.Controls.Add(this.chkTps);
            this.grpCross.Controls.Add(this.txtbLoad);
            this.grpCross.Controls.Add(this.chkLoad);
            this.grpCross.Controls.Add(this.lblLoad);
            this.grpCross.Controls.Add(this.label3);
            this.grpCross.Location = new System.Drawing.Point(7, 208);
            this.grpCross.Name = "grpCross";
            this.grpCross.Size = new System.Drawing.Size(233, 103);
            this.grpCross.TabIndex = 2;
            this.grpCross.TabStop = false;
            this.grpCross.Text = "Condition Mode";
            // 
            // txtbRpm
            // 
            this.txtbRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbRpm.Location = new System.Drawing.Point(116, 77);
            this.txtbRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbRpm.Name = "txtbRpm";
            this.txtbRpm.Size = new System.Drawing.Size(56, 20);
            this.txtbRpm.TabIndex = 3;
            this.txtbRpm.Click += new System.EventHandler(this.txtbLoad_Validated);
            this.txtbRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbLoad_KeyPress);
            this.txtbRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbRpm_Validating);
            this.txtbRpm.Validated += new System.EventHandler(this.txtbLoad_Validated);
            // 
            // chkRpm
            // 
            this.chkRpm.AutoSize = true;
            this.chkRpm.Location = new System.Drawing.Point(11, 79);
            this.chkRpm.Name = "chkRpm";
            this.chkRpm.Size = new System.Drawing.Size(90, 18);
            this.chkRpm.TabIndex = 4;
            this.chkRpm.Text = "Above Rpm:";
            this.chkRpm.UseVisualStyleBackColor = true;
            this.chkRpm.CheckedChanged += new System.EventHandler(this.chkLoad_CheckedChanged);
            // 
            // txtbTps
            // 
            this.txtbTps.Location = new System.Drawing.Point(116, 49);
            this.txtbTps.Name = "txtbTps";
            this.txtbTps.Size = new System.Drawing.Size(56, 20);
            this.txtbTps.TabIndex = 2;
            this.txtbTps.Click += new System.EventHandler(this.txtbLoad_Validated);
            this.txtbTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbLoad_KeyPress);
            this.txtbTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLoad_Validating);
            this.txtbTps.Validated += new System.EventHandler(this.txtbLoad_Validated);
            // 
            // chkTps
            // 
            this.chkTps.AutoSize = true;
            this.chkTps.Location = new System.Drawing.Point(11, 51);
            this.chkTps.Name = "chkTps";
            this.chkTps.Size = new System.Drawing.Size(87, 18);
            this.chkTps.TabIndex = 2;
            this.chkTps.Text = "Above TPS:";
            this.chkTps.UseVisualStyleBackColor = true;
            this.chkTps.CheckedChanged += new System.EventHandler(this.chkLoad_CheckedChanged);
            // 
            // txtbLoad
            // 
            this.txtbLoad.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtbLoad.Location = new System.Drawing.Point(116, 21);
            this.txtbLoad.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbLoad.Name = "txtbLoad";
            this.txtbLoad.Size = new System.Drawing.Size(56, 20);
            this.txtbLoad.TabIndex = 1;
            this.txtbLoad.Click += new System.EventHandler(this.txtbLoad_Validated);
            this.txtbLoad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbLoad_KeyPress);
            this.txtbLoad.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLoad_Validating);
            this.txtbLoad.Validated += new System.EventHandler(this.txtbLoad_Validated);
            // 
            // chkLoad
            // 
            this.chkLoad.AutoSize = true;
            this.chkLoad.Location = new System.Drawing.Point(11, 23);
            this.chkLoad.Name = "chkLoad";
            this.chkLoad.Size = new System.Drawing.Size(93, 18);
            this.chkLoad.TabIndex = 0;
            this.chkLoad.Text = "Above Load:";
            this.chkLoad.UseVisualStyleBackColor = true;
            this.chkLoad.CheckedChanged += new System.EventHandler(this.chkLoad_CheckedChanged);
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(180, 24);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(33, 14);
            this.lblLoad.TabIndex = 5;
            this.lblLoad.Text = "mbar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
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
            this.panel1.Size = new System.Drawing.Size(295, 339);
            this.panel1.TabIndex = 1;
            // 
            // parmDualMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmDualMap";
            this.Size = new System.Drawing.Size(295, 339);
            this.Load += new System.EventHandler(this.parmDualMap_Load);
            this.groupBox1.ResumeLayout(false);
            this.grpSet.ResumeLayout(false);
            this.grpSet.PerformLayout();
            this.grpInputSw.ResumeLayout(false);
            this.grpCross.ResumeLayout(false);
            this.grpCross.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmDualMap_Load(null, null);
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Secondary Map Settings Input Switch");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_284, byte_0);
            this.class18_0.method_153();
            this.parmDualMap_Load(null, null);
        }
    }

    private void method_2(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Secondary Map Settings Input Switch");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_283, byte_0);
            this.class18_0.method_153();
            this.parmDualMap_Load(null, null);
        }
    }

    private void method_3()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Secondary Map Settings");
            if (this.rbDis.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_282, 0);
            }
            else if (this.rbInput.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_282, 1);
            }
            else if (this.rdCross.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_282, 2);
            }
            if (this.chkLoad.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_290, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_290, 0);
            }
            if (this.chkRpm.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_286, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_286, 0);
            }
            if (this.chkTps.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_288, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_288, 0);
            }
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_287, this.class18_0.method_228(int.Parse(this.txtbTps.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_289, this.class18_0.method_226(int.Parse(this.txtbLoad.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_285, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)));
            this.class18_0.method_153();
            this.parmDualMap_Load(null, null);
        }
    }

    private void parmDualMap_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_282) == 0)
        {
            this.rbDis.Checked = true;
        }
        else if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_282) == 1)
        {
            this.rbInput.Checked = true;
        }
        else if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_282) == 2)
        {
            this.rdCross.Checked = true;
        }
        this.chkLoad.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_290) == 0xff;
        this.chkRpm.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_286) == 0xff;
        this.chkTps.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_288) == 0xff;
        this.txtbLoad.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_289)).ToString();
        this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_285)).ToString();
        this.txtbTps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_287)).ToString();
        this.txtbLoad.Enabled = this.chkLoad.Checked;
        this.txtbRpm.Enabled = this.chkRpm.Checked;
        this.txtbTps.Enabled = this.chkTps.Checked;
        this.ctrlInputSelector1.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_283));
        this.ctrlInputSelector1.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_284) == 0xff);
        this.bool_0 = false;
    }

    private void rbInput_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbDis.Checked)
        {
            this.grpInputSw.Enabled = false;
            this.grpCross.Enabled = false;
        }
        else if (this.rbInput.Checked)
        {
            this.grpInputSw.Enabled = true;
            this.grpCross.Enabled = false;
        }
        else if (this.rdCross.Checked)
        {
            this.grpInputSw.Enabled = false;
            this.grpCross.Enabled = true;
        }
        this.method_3();
    }

    private void txtbLoad_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox)sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_3();
            }
            control.Focus();
        }
    }

    private void txtbLoad_Validated(object sender, EventArgs e)
    {
        this.method_3();
    }

    private void txtbLoad_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
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

    private void txtbRpm_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Int positive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

