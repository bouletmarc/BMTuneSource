using Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmVtec : UserControl
{
    private bool bool_0;
    private CheckBox checkBox_0;
    private CheckBox chkEctChk;
    private CheckBox chkEnable;
    private CheckBox chkErrorChk;
    private CheckBox chkVtp;
    private CheckBox chkVtsOutput;
    private Class18 class18_0;
    private ctrlMapValue ctrlMapValue1;
    private CtrlOutputSelector ctrlOutputVtec;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private IContainer icontainer_0;
    private Label label1;
    private Label label10;
    private Label label13;
    private Label label15;
    private Label label2;
    private Label label5;
    private Label label6;
    private IContainer components;
    private Label label3;
    private TrackBar trackBar1;
    private Label label8;
    private Label label7;
    private Label label4;
    private Label label9;
    private Label lblEct;
    private NumericUpDown txtbMinVss;
    private NumericUpDown txtbMinEct;
    private NumericUpDown txtbDisDiff;
    private NumericUpDown txtbHighLoadRpm;
    private NumericUpDown txtbLowLoadRpm;
    private Panel panel1;

    internal parmVtec(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_2);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_2);
        this.InitializeComponent();

        this.ctrlOutputVtec.method_1(false);
        this.ctrlOutputVtec.method_3(true);
        this.ctrlOutputVtec.method_7(true);
        this.ctrlOutputVtec.method_Output_location(this.class18_0.class13_u_0.long_232);

        this.ctrlOutputVtec.method_9(ref this.class18_0);
        this.ctrlOutputVtec.method_8();
        this.ctrlOutputVtec.delegate37_0 += new CtrlOutputSelector.Delegate37(this.method_1);
        this.ctrlOutputVtec.delegate36_0 += new CtrlOutputSelector.Delegate36(this.method_0);
        this.ctrlMapValue1.method_0(ref this.class18_0);
        this.ctrlMapValue1.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_4);

        this.groupBox4.Enabled= true;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void checkBox_0_CheckedChanged(object sender, EventArgs e)
    {
        this.method_5();
        this.parmVtec_Load(null, null);
    }

    private void chkVtsOutput_CheckedChanged(object sender, EventArgs e)
    {
        this.ctrlOutputVtec.Enabled = this.chkVtsOutput.Checked;
        this.method_5();
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
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ctrlOutputVtec = new CtrlOutputSelector();
            this.chkVtsOutput = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_0 = new System.Windows.Forms.CheckBox();
            this.chkEctChk = new System.Windows.Forms.CheckBox();
            this.chkErrorChk = new System.Windows.Forms.CheckBox();
            this.chkVtp = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbMinVss = new System.Windows.Forms.NumericUpDown();
            this.txtbMinEct = new System.Windows.Forms.NumericUpDown();
            this.txtbDisDiff = new System.Windows.Forms.NumericUpDown();
            this.txtbHighLoadRpm = new System.Windows.Forms.NumericUpDown();
            this.txtbLowLoadRpm = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEct = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlMapValue1 = new Controls.ctrlMapValue();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMinVss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMinEct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDisDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighLoadRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLowLoadRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 499);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VTEC Settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ctrlOutputVtec);
            this.groupBox4.Controls.Add(this.chkVtsOutput);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(7, 398);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(273, 95);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Alternative Output";
            // 
            // ctrlOutputVtec
            // 
            this.ctrlOutputVtec.Location = new System.Drawing.Point(7, 39);
            this.ctrlOutputVtec.Name = "ctrlOutputVtec";
            this.ctrlOutputVtec.Size = new System.Drawing.Size(216, 53);
            this.ctrlOutputVtec.TabIndex = 15;
            // 
            // chkVtsOutput
            // 
            this.chkVtsOutput.AutoSize = true;
            this.chkVtsOutput.Location = new System.Drawing.Point(10, 20);
            this.chkVtsOutput.Name = "chkVtsOutput";
            this.chkVtsOutput.Size = new System.Drawing.Size(165, 18);
            this.chkVtsOutput.TabIndex = 14;
            this.chkVtsOutput.Text = "Enable Alternative Output";
            this.chkVtsOutput.UseVisualStyleBackColor = true;
            this.chkVtsOutput.CheckedChanged += new System.EventHandler(this.chkVtsOutput_CheckedChanged);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(20, 25);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(93, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable VTEC";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.checkBox_0_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_0);
            this.groupBox2.Controls.Add(this.chkEctChk);
            this.groupBox2.Controls.Add(this.chkErrorChk);
            this.groupBox2.Controls.Add(this.chkVtp);
            this.groupBox2.Location = new System.Drawing.Point(7, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 122);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VTEC Options:";
            // 
            // checkBox_0
            // 
            this.checkBox_0.AutoSize = true;
            this.checkBox_0.Location = new System.Drawing.Point(7, 20);
            this.checkBox_0.Name = "checkBox_0";
            this.checkBox_0.Size = new System.Drawing.Size(173, 18);
            this.checkBox_0.TabIndex = 1;
            this.checkBox_0.Text = "Disable VTEC Speed Check";
            this.checkBox_0.UseVisualStyleBackColor = true;
            this.checkBox_0.CheckedChanged += new System.EventHandler(this.checkBox_0_CheckedChanged);
            // 
            // chkEctChk
            // 
            this.chkEctChk.AutoSize = true;
            this.chkEctChk.Location = new System.Drawing.Point(7, 45);
            this.chkEctChk.Name = "chkEctChk";
            this.chkEctChk.Size = new System.Drawing.Size(168, 18);
            this.chkEctChk.TabIndex = 2;
            this.chkEctChk.Text = "Disable VTEC Temp Check";
            this.chkEctChk.UseVisualStyleBackColor = true;
            this.chkEctChk.CheckedChanged += new System.EventHandler(this.checkBox_0_CheckedChanged);
            // 
            // chkErrorChk
            // 
            this.chkErrorChk.AutoSize = true;
            this.chkErrorChk.Location = new System.Drawing.Point(7, 95);
            this.chkErrorChk.Name = "chkErrorChk";
            this.chkErrorChk.Size = new System.Drawing.Size(163, 18);
            this.chkErrorChk.TabIndex = 5;
            this.chkErrorChk.Text = "Disable VTEC Error Check";
            this.chkErrorChk.UseVisualStyleBackColor = true;
            this.chkErrorChk.CheckedChanged += new System.EventHandler(this.checkBox_0_CheckedChanged);
            // 
            // chkVtp
            // 
            this.chkVtp.AutoSize = true;
            this.chkVtp.Location = new System.Drawing.Point(7, 70);
            this.chkVtp.Name = "chkVtp";
            this.chkVtp.Size = new System.Drawing.Size(187, 18);
            this.chkVtp.TabIndex = 3;
            this.chkVtp.Text = "Disable VTEC Pressure Switch";
            this.chkVtp.UseVisualStyleBackColor = true;
            this.chkVtp.CheckedChanged += new System.EventHandler(this.checkBox_0_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbMinVss);
            this.groupBox3.Controls.Add(this.txtbMinEct);
            this.groupBox3.Controls.Add(this.txtbDisDiff);
            this.groupBox3.Controls.Add(this.txtbHighLoadRpm);
            this.groupBox3.Controls.Add(this.txtbLowLoadRpm);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblEct);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ctrlMapValue1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(7, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 206);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "VTEC RPM";
            // 
            // txtbMinVss
            // 
            this.txtbMinVss.Location = new System.Drawing.Point(119, 176);
            this.txtbMinVss.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbMinVss.Name = "txtbMinVss";
            this.txtbMinVss.Size = new System.Drawing.Size(65, 20);
            this.txtbMinVss.TabIndex = 32;
            this.txtbMinVss.Click += new System.EventHandler(this.txtbMinEct_Validated);
            this.txtbMinVss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinEct_KeyPress);
            this.txtbMinVss.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinEct_Validating);
            this.txtbMinVss.Validated += new System.EventHandler(this.txtbMinEct_Validated);
            // 
            // txtbMinEct
            // 
            this.txtbMinEct.Location = new System.Drawing.Point(119, 148);
            this.txtbMinEct.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.txtbMinEct.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.txtbMinEct.Name = "txtbMinEct";
            this.txtbMinEct.Size = new System.Drawing.Size(65, 20);
            this.txtbMinEct.TabIndex = 31;
            this.txtbMinEct.Click += new System.EventHandler(this.txtbMinEct_Validated);
            this.txtbMinEct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinEct_KeyPress);
            this.txtbMinEct.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinEct_Validating);
            this.txtbMinEct.Validated += new System.EventHandler(this.txtbMinEct_Validated);
            // 
            // txtbDisDiff
            // 
            this.txtbDisDiff.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbDisDiff.Location = new System.Drawing.Point(119, 71);
            this.txtbDisDiff.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.txtbDisDiff.Name = "txtbDisDiff";
            this.txtbDisDiff.Size = new System.Drawing.Size(65, 20);
            this.txtbDisDiff.TabIndex = 30;
            this.txtbDisDiff.Click += new System.EventHandler(this.txtbMinEct_Validated);
            this.txtbDisDiff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinEct_KeyPress);
            this.txtbDisDiff.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinEct_Validating);
            this.txtbDisDiff.Validated += new System.EventHandler(this.txtbMinEct_Validated);
            // 
            // txtbHighLoadRpm
            // 
            this.txtbHighLoadRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbHighLoadRpm.Location = new System.Drawing.Point(119, 43);
            this.txtbHighLoadRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbHighLoadRpm.Name = "txtbHighLoadRpm";
            this.txtbHighLoadRpm.Size = new System.Drawing.Size(65, 20);
            this.txtbHighLoadRpm.TabIndex = 29;
            this.txtbHighLoadRpm.Click += new System.EventHandler(this.txtbMinEct_Validated);
            this.txtbHighLoadRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinEct_KeyPress);
            this.txtbHighLoadRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinEct_Validating);
            this.txtbHighLoadRpm.Validated += new System.EventHandler(this.txtbMinEct_Validated);
            // 
            // txtbLowLoadRpm
            // 
            this.txtbLowLoadRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbLowLoadRpm.Location = new System.Drawing.Point(119, 15);
            this.txtbLowLoadRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbLowLoadRpm.Name = "txtbLowLoadRpm";
            this.txtbLowLoadRpm.Size = new System.Drawing.Size(65, 20);
            this.txtbLowLoadRpm.TabIndex = 28;
            this.txtbLowLoadRpm.Click += new System.EventHandler(this.txtbMinEct_Validated);
            this.txtbLowLoadRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinEct_KeyPress);
            this.txtbLowLoadRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinEct_Validating);
            this.txtbLowLoadRpm.Validated += new System.EventHandler(this.txtbMinEct_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 14);
            this.label9.TabIndex = 27;
            this.label9.Text = "kmh";
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(190, 152);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 26;
            this.lblEct.Text = "C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 14);
            this.label8.TabIndex = 25;
            this.label8.Text = "rpm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 14);
            this.label7.TabIndex = 24;
            this.label7.Text = "rpm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "rpm";
            // 
            // ctrlMapValue1
            // 
            this.ctrlMapValue1.Location = new System.Drawing.Point(119, 121);
            this.ctrlMapValue1.Name = "ctrlMapValue1";
            this.ctrlMapValue1.rawValue = ((byte)(0));
            this.ctrlMapValue1.Size = new System.Drawing.Size(133, 23);
            this.ctrlMapValue1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "TPS Threshold:";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(108, 98);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(108, 22);
            this.trackBar1.TabIndex = 21;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 18;
            this.label10.Text = "100%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 14);
            this.label15.TabIndex = 15;
            this.label15.Text = "Disengage Delay:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 14);
            this.label13.TabIndex = 12;
            this.label13.Text = "Minimum Speed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "High Load Engage:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Low Load Engage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Minimum ECT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Min Load:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 465);
            this.panel1.TabIndex = 4;
            // 
            // parmVtec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmVtec";
            this.Size = new System.Drawing.Size(325, 465);
            this.Load += new System.EventHandler(this.parmVtec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMinVss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMinEct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDisDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighLoadRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLowLoadRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("VTEC Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_233, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("VTEC Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_232, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_2()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmVtec_Load(null, null);
        }
    }

    private void method_3(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void method_4(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("VTEC Settings", false);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_227, byte_0);
            this.class18_0.method_153();
            this.parmVtec_Load(null, null);
        }
    }

    private void method_5()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("VTEC Settings", false);
            if (this.chkEnable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_218, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_218, 0);
            }
            if (this.checkBox_0.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_219, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_219, 0);
            }
            if (this.class18_0.class13_u_0.long_230 != 0L)
            {
                byte num = this.class18_0.method_216(0x1194);
                byte num2 = this.class18_0.method_216(0x1194 - int.Parse(this.txtbDisDiff.Text));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_230, (byte) (num - num2));
            }
            if (this.class18_0.class13_u_0.long_220 != 0L)
            {
                if (this.chkEctChk.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_220, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_220, 0);
                }
            }
            if (this.class18_0.class13_u_0.long_224 != 0L)
            {
                if (this.chkVtp.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_224, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_224, 0);
                }
            }
            if (this.class18_0.class13_u_0.long_225 != 0L)
            {
                if (this.chkErrorChk.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_225, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_225, 0);
                }
            }
            if (this.class18_0.class13_u_0.long_223 != 0L)
            {
                if (this.chkErrorChk.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_223, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_223, 0);
                }
            }
            if (this.class18_0.class13_u_0.long_228 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_228, this.class18_0.method_230(double.Parse(this.txtbMinEct.Text)));
            }
            if (this.class18_0.class13_u_0.long_229 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_229, this.class18_0.method_233(int.Parse(this.txtbMinVss.Text)));
            }
            if (this.class18_0.class13_u_0.long_221 != 0L)
            {
                /*if (int.Parse(this.txtbLowLoadTps.Text) >= int.Parse(this.txtbHighLoadTps.Text))
                {
                    this.txtbHighLoadTps.Text = (int.Parse(this.txtbLowLoadTps.Text) + 1).ToString();
                }*/
                int ValueTPSHigh = this.trackBar1.Value + 8;
                if (ValueTPSHigh > 100) ValueTPSHigh = 100;
                int ValueTPSLow = ValueTPSHigh - 16;
                if (ValueTPSLow < 0) ValueTPSLow = 0;
                if (ValueTPSHigh <= 0) ValueTPSHigh = 1;
                this.label10.Text = this.trackBar1.Value.ToString() + "%";
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_221 + 2L, this.class18_0.method_228(ValueTPSLow));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_221, this.class18_0.method_228(ValueTPSHigh));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_221 + 1L, this.class18_0.method_216(int.Parse(this.txtbHighLoadRpm.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_221 + 3L, this.class18_0.method_216(int.Parse(this.txtbLowLoadRpm.Text)));
            }
            if (this.class18_0.class13_u_0.long_231 != 0L)
            {
                if (this.chkVtsOutput.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_231, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_232, 8);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_231, 0);
                }
            }
            this.class18_0.method_153();
            this.parmVtec_Load(null, null);
        }
    }

    private void method_6(object sender, EventArgs e)
    {
        this.parmVtec_Load(null, null);
    }

    private void method_7(object sender, EventArgs e)
    {
        if (this.chkEnable.Checked)
        {
            this.groupBox2.Enabled = true;
            this.groupBox3.Enabled = true;
            this.groupBox4.Enabled= true;
        }
        else
        {
            this.groupBox4.Enabled = false;
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
        }
    }

    private void parmVtec_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;

        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();
        this.label9.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();

        this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_218) == 0xff;
        if (this.chkEnable.Checked)
        {
            this.groupBox2.Enabled = true;
            this.groupBox3.Enabled = true;
            this.groupBox4.Enabled= true;
        }
        else
        {
            this.groupBox4.Enabled = false;
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
        }
        if (this.class18_0.class13_u_0.long_227 != 0L)
        {
            this.ctrlMapValue1.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_227);
        }
        this.checkBox_0.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_219) == 0xff;
        if (this.class18_0.class13_u_0.long_230 != 0L)
        {
            int num = this.class18_0.method_186(200);
            int num2 = this.class18_0.method_186(200 - this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_230));
            this.txtbDisDiff.Text = (num - num2).ToString();
        }
        if (this.class18_0.class13_u_0.long_220 != 0L)
        {
            this.chkEctChk.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_220) == 0xff;
        }
        if (this.class18_0.class13_u_0.long_224 != 0L)
        {
            this.chkVtp.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_224) == 0xff;
        }
        if (this.class18_0.class13_u_0.long_223 != 0L)
        {
            this.chkErrorChk.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_223) == 0xff;
        }
        if (this.class18_0.class13_u_0.long_228 != 0L)
        {
            this.txtbMinEct.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_228)).ToString();
        }
        if (this.class18_0.class13_u_0.long_229 != 0L)
        {
            this.txtbMinVss.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_229)).ToString();
        }
        if (this.class18_0.class13_u_0.long_221 != 0L)
        {
            int ValueTPSHigh = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_221));
            int ValueTPSLow = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_221 + 2L));
            int Mid = ((ValueTPSHigh - ValueTPSLow) / 2) + ValueTPSLow;
            this.trackBar1.Value = Mid;
            this.label10.Text = this.trackBar1.Value.ToString() + "%";
            this.txtbHighLoadRpm.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_221 + 1L)).ToString();
            this.txtbLowLoadRpm.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_221 + 3L)).ToString();
        }
        this.groupBox4.Enabled = (this.class18_0.class13_u_0.long_231 != 0L) && this.chkEnable.Checked;
        if (this.class18_0.class13_u_0.long_231 != 0L)
        {
            this.ctrlOutputVtec.method_10(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_232));
            this.ctrlOutputVtec.method_1(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_233) == 0xff);
            this.chkVtsOutput.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_231) == 0xff;
            this.ctrlOutputVtec.Enabled = this.chkVtsOutput.Checked;
        }

        this.bool_0 = false;
    }

    private void txtbMinEct_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_5();
            }
            control.Focus();
        }
    }

    private void txtbMinEct_Validated(object sender, EventArgs e)
    {
        this.method_5();
    }

    private void txtbMinEct_Validating(object sender, CancelEventArgs e)
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

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        this.label10.Text = this.trackBar1.Value.ToString() + "%";
    }

    private void trackBar1_MouseUp(object sender, MouseEventArgs e)
    {
        this.method_5();
        this.parmVtec_Load(null, null);
    }
}

