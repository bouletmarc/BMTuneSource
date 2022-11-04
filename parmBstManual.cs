using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmBstManual : UserControl
{
    private bool bool_0;
    private CheckBox chkFtl;
    private CheckBox chkMil;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInput;
    private CtrlOutputSelector ctrlStage2;
    private CtrlOutputSelector ctrlStage3;
    private CtrlOutputSelector ctrlStage4;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox2;
    private GroupBox groupBox4;
    private GroupBox groupBox5;
    private GroupBox groupBox6;
    private IContainer icontainer_0;
    private IContainer components;
    private Label label12;
    private Label label10;
    private GroupBox groupBox1;
    private Label lblVSS;
    private Label lblVSS3;
    private Label lblVSS2;
    private Panel panel1;
    private NumericUpDown txtbStage4Vss;
    private NumericUpDown txtbStage3Vss;
    private NumericUpDown txtbStage2Vss;
    private Label label8;

    public parmBstManual(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_8);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_8);
        this.InitializeComponent();

        this.ctrlInput.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInput.method_3_CustomInput("Enable");
        this.ctrlInput.method_11_Add_Disabled_In_Selection(true);
        this.ctrlInput.method_5(false);
        //this.ctrlInput.method_1(0);
        this.ctrlInput.method_Input_location(this.class18_0.class13_u_0.long_357);

        this.ctrlStage4.method_1(false);
        this.ctrlStage4.method_3(false);
        this.ctrlStage4.method_7(true);
        this.ctrlStage4.method_Output_location(this.class18_0.class13_u_0.long_368);


        this.ctrlStage3.method_1(false);
        this.ctrlStage3.method_3(false);
        this.ctrlStage3.method_7(true);
        this.ctrlStage3.method_Output_location(this.class18_0.class13_u_0.long_366);

        this.ctrlStage2.method_1(false);
        this.ctrlStage2.method_3(false);
        this.ctrlStage2.method_7(true);
        this.ctrlStage2.method_Output_location(this.class18_0.class13_u_0.long_364);


        this.ctrlInput.method_14(ref this.class18_0);
        this.ctrlInput.method_12();
        this.ctrlInput.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_7);
        this.ctrlInput.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_6);
        this.ctrlStage2.method_9(ref this.class18_0);
        this.ctrlStage2.method_3(false);
        this.ctrlStage3.method_8();
        this.ctrlStage2.delegate37_0 += new CtrlOutputSelector.Delegate37(this.method_5);
        this.ctrlStage2.delegate36_0 += new CtrlOutputSelector.Delegate36(this.method_4);
        this.ctrlStage3.method_9(ref this.class18_0);
        this.ctrlStage3.method_3(false);
        this.ctrlStage3.method_8();
        this.ctrlStage3.delegate37_0 += new CtrlOutputSelector.Delegate37(this.method_3);
        this.ctrlStage3.delegate36_0 += new CtrlOutputSelector.Delegate36(this.method_2);
        this.ctrlStage4.method_9(ref this.class18_0);
        this.ctrlStage4.method_3(false);
        this.ctrlStage3.method_8();
        this.ctrlStage4.delegate37_0 += new CtrlOutputSelector.Delegate37(this.method_1);
        this.ctrlStage4.delegate36_0 += new CtrlOutputSelector.Delegate36(this.method_0);

        this.groupBox1.Enabled = true;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkMil_CheckedChanged(object sender, EventArgs e)
    {
        this.method_9();
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtbStage4Vss = new System.Windows.Forms.NumericUpDown();
            this.lblVSS3 = new System.Windows.Forms.Label();
            this.ctrlStage4 = new CtrlOutputSelector();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtbStage3Vss = new System.Windows.Forms.NumericUpDown();
            this.lblVSS2 = new System.Windows.Forms.Label();
            this.ctrlStage3 = new CtrlOutputSelector();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtbStage2Vss = new System.Windows.Forms.NumericUpDown();
            this.lblVSS = new System.Windows.Forms.Label();
            this.ctrlStage2 = new CtrlOutputSelector();
            this.label8 = new System.Windows.Forms.Label();
            this.chkFtl = new System.Windows.Forms.CheckBox();
            this.chkMil = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlInput = new CtrlInputSelector();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStage4Vss)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStage3Vss)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStage2Vss)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtbStage4Vss);
            this.groupBox6.Controls.Add(this.lblVSS3);
            this.groupBox6.Controls.Add(this.ctrlStage4);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(10, 373);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(227, 101);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Fourth Stage";
            // 
            // txtbStage4Vss
            // 
            this.txtbStage4Vss.Location = new System.Drawing.Point(96, 18);
            this.txtbStage4Vss.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbStage4Vss.Name = "txtbStage4Vss";
            this.txtbStage4Vss.Size = new System.Drawing.Size(52, 20);
            this.txtbStage4Vss.TabIndex = 27;
            this.txtbStage4Vss.Click += new System.EventHandler(this.txtbRpm_Validated);
            this.txtbStage4Vss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpm_KeyPress);
            this.txtbStage4Vss.Validating += new System.ComponentModel.CancelEventHandler(this.txtbStage2Vss_Validating);
            this.txtbStage4Vss.Validated += new System.EventHandler(this.txtbRpm_Validated);
            // 
            // lblVSS3
            // 
            this.lblVSS3.AutoSize = true;
            this.lblVSS3.Location = new System.Drawing.Point(151, 20);
            this.lblVSS3.Name = "lblVSS3";
            this.lblVSS3.Size = new System.Drawing.Size(29, 14);
            this.lblVSS3.TabIndex = 26;
            this.lblVSS3.Text = "kmh";
            // 
            // ctrlStage4
            // 
            this.ctrlStage4.Location = new System.Drawing.Point(7, 41);
            this.ctrlStage4.Name = "ctrlStage4";
            this.ctrlStage4.Size = new System.Drawing.Size(216, 53);
            this.ctrlStage4.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 14);
            this.label12.TabIndex = 11;
            this.label12.Text = "Above Speed:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtbStage3Vss);
            this.groupBox5.Controls.Add(this.lblVSS2);
            this.groupBox5.Controls.Add(this.ctrlStage3);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(10, 265);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(227, 101);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Third Stage";
            // 
            // txtbStage3Vss
            // 
            this.txtbStage3Vss.Location = new System.Drawing.Point(96, 18);
            this.txtbStage3Vss.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbStage3Vss.Name = "txtbStage3Vss";
            this.txtbStage3Vss.Size = new System.Drawing.Size(52, 20);
            this.txtbStage3Vss.TabIndex = 26;
            this.txtbStage3Vss.Click += new System.EventHandler(this.txtbRpm_Validated);
            this.txtbStage3Vss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpm_KeyPress);
            this.txtbStage3Vss.Validating += new System.ComponentModel.CancelEventHandler(this.txtbStage2Vss_Validating);
            this.txtbStage3Vss.Validated += new System.EventHandler(this.txtbRpm_Validated);
            // 
            // lblVSS2
            // 
            this.lblVSS2.AutoSize = true;
            this.lblVSS2.Location = new System.Drawing.Point(154, 20);
            this.lblVSS2.Name = "lblVSS2";
            this.lblVSS2.Size = new System.Drawing.Size(28, 17);
            this.lblVSS2.TabIndex = 25;
            this.lblVSS2.Text = "kmh";
            this.lblVSS2.UseCompatibleTextRendering = true;
            // 
            // ctrlStage3
            // 
            this.ctrlStage3.Location = new System.Drawing.Point(7, 41);
            this.ctrlStage3.Name = "ctrlStage3";
            this.ctrlStage3.Size = new System.Drawing.Size(216, 53);
            this.ctrlStage3.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 14);
            this.label10.TabIndex = 11;
            this.label10.Text = "Above Speed:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtbStage2Vss);
            this.groupBox4.Controls.Add(this.lblVSS);
            this.groupBox4.Controls.Add(this.ctrlStage2);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(10, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(227, 101);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Second Stage";
            // 
            // txtbStage2Vss
            // 
            this.txtbStage2Vss.Location = new System.Drawing.Point(96, 18);
            this.txtbStage2Vss.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbStage2Vss.Name = "txtbStage2Vss";
            this.txtbStage2Vss.Size = new System.Drawing.Size(52, 20);
            this.txtbStage2Vss.TabIndex = 25;
            this.txtbStage2Vss.Click += new System.EventHandler(this.txtbRpm_Validated);
            this.txtbStage2Vss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpm_KeyPress);
            this.txtbStage2Vss.Validating += new System.ComponentModel.CancelEventHandler(this.txtbStage2Vss_Validating);
            this.txtbStage2Vss.Validated += new System.EventHandler(this.txtbRpm_Validated);
            // 
            // lblVSS
            // 
            this.lblVSS.AutoSize = true;
            this.lblVSS.Location = new System.Drawing.Point(151, 20);
            this.lblVSS.Name = "lblVSS";
            this.lblVSS.Size = new System.Drawing.Size(29, 14);
            this.lblVSS.TabIndex = 24;
            this.lblVSS.Text = "kmh";
            // 
            // ctrlStage2
            // 
            this.ctrlStage2.Location = new System.Drawing.Point(7, 41);
            this.ctrlStage2.Name = "ctrlStage2";
            this.ctrlStage2.Size = new System.Drawing.Size(216, 53);
            this.ctrlStage2.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "Above Speed:";
            // 
            // chkFtl
            // 
            this.chkFtl.AutoSize = true;
            this.chkFtl.Location = new System.Drawing.Point(21, 45);
            this.chkFtl.Name = "chkFtl";
            this.chkFtl.Size = new System.Drawing.Size(210, 18);
            this.chkFtl.TabIndex = 6;
            this.chkFtl.Text = "Disable If Ftl/Fts/Boost Cut active";
            this.chkFtl.UseVisualStyleBackColor = true;
            this.chkFtl.CheckedChanged += new System.EventHandler(this.chkMil_CheckedChanged);
            this.chkFtl.Validated += new System.EventHandler(this.parmBstManual_Load);
            // 
            // chkMil
            // 
            this.chkMil.AutoSize = true;
            this.chkMil.Location = new System.Drawing.Point(21, 20);
            this.chkMil.Name = "chkMil";
            this.chkMil.Size = new System.Drawing.Size(129, 18);
            this.chkMil.TabIndex = 5;
            this.chkMil.Text = "Disable If MIL Code";
            this.chkMil.UseVisualStyleBackColor = true;
            this.chkMil.CheckedChanged += new System.EventHandler(this.chkMil_CheckedChanged);
            this.chkMil.Validated += new System.EventHandler(this.parmBstManual_Load);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlInput);
            this.groupBox2.Location = new System.Drawing.Point(10, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 76);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activate Input";
            // 
            // ctrlInput
            // 
            this.ctrlInput.Location = new System.Drawing.Point(7, 20);
            this.ctrlInput.Name = "ctrlInput";
            this.ctrlInput.Size = new System.Drawing.Size(216, 53);
            this.ctrlInput.TabIndex = 0;
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMil);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkFtl);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 482);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Boost Controller";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 434);
            this.panel1.TabIndex = 8;
            // 
            // parmBstManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmBstManual";
            this.Size = new System.Drawing.Size(311, 434);
            this.Load += new System.EventHandler(this.parmBstManual_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStage4Vss)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStage3Vss)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStage2Vss)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Boost Stage 4 output");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_368, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_2(byte byte_0)
    {
    }

    private void method_3(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Boost Stage 3 output");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_366, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_4(byte byte_0)
    {
    }

    private void method_5(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Boost Stage 2 output");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_364, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_6(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Boost Input Invert");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_358, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_7(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Boost Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_357, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_8()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmBstManual_Load(null, null);
        }
    }

    private void method_9()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Manual Boost Ctrl settings");
            if (this.chkFtl.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_360, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_360, 0);
            }
            if (this.chkMil.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_359, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_359, 0);
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_361, this.class18_0.method_219(1000));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_362, this.class18_0.method_228(3));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_363, this.class18_0.method_230(-26.0));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_365, this.class18_0.method_233(int.Parse(this.txtbStage2Vss.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_367, this.class18_0.method_233(int.Parse(this.txtbStage3Vss.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_369, this.class18_0.method_233(int.Parse(this.txtbStage4Vss.Text)));
            this.class18_0.method_153();
            this.parmBstManual_Load(null, null);
        }
    }

    private void parmBstManual_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.ctrlInput.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_357));
        this.ctrlInput.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_358) == 0xff);
        this.ctrlStage2.method_10(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_364));
        this.ctrlStage3.method_10(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_366));
        this.ctrlStage4.method_10(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_368));
        this.txtbStage2Vss.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_365)).ToString();
        this.txtbStage3Vss.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_367)).ToString();
        this.txtbStage4Vss.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_369)).ToString();
        this.chkFtl.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_360) == 0xff;
        this.chkMil.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_359) == 0xff;

        this.lblVSS.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();
        this.lblVSS2.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();
        this.lblVSS3.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();

        this.bool_0 = false;
    }

    private void txtbRpm_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_9();
            }
            control.Focus();
        }
    }

    private void txtbRpm_Validated(object sender, EventArgs e)
    {
        this.method_9();
    }

    private void txtbStage2Vss_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        this.groupBox1.Focus();
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

