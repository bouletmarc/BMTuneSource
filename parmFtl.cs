using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmFtl : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInputSelector1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox grpTps;
    private IContainer icontainer_0;
    private Label label1;
    private Label label12;
    private Label label4;
    private Label label6;
    private Label label7;
    private IContainer components;
    private ComboBox comboBox1;
    private Label label8;
    private Label label5;
    private Label label3;
    private Label label2;
    private GroupBox groupBox3;
    private Label label9;
    private CheckBox chkEnable;
    private Label label10;
    private Label labelTPS;
    private Label label11;
    private CheckBox chkSatic;
    private TrackBar trackBar1;
    private Label label13;
    private Panel panel1;
    private NumericUpDown txtbRetard;
    private NumericUpDown txtFuel;
    private NumericUpDown txtbTpsDis;
    private NumericUpDown txtbTpsThreshold;
    private NumericUpDown txtbDiff1;
    private NumericUpDown txtbTpsMinVss;
    private Panel panel2;
    private Label label15;
    private NumericUpDown txtbCutDelayLaunch;
    private Label label14;
    private NumericUpDown txtbTpsMinRpm;
    private bool EnableTimeLaunch = false;

    public parmFtl(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_4);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_4);
        this.InitializeComponent();
        
        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInputSelector1.method_3_CustomInput("Always On");
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(false);
        this.ctrlInputSelector1.method_5(false);
        //this.ctrlInputSelector1.method_1(0);
        this.ctrlInputSelector1.method_Input_location(this.class18_0.class13_u_0.long_137);

        this.ctrlInputSelector1.method_14(ref this.class18_0);
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(true);
        //this.ctrlInputSelector1.method_1(5);
        this.ctrlInputSelector1.method_12();
        this.ctrlInputSelector1.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_1);
        this.ctrlInputSelector1.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_0);

        this.groupBox3.Enabled = true;

        EnableTimeLaunch = false;
        if (this.class18_0.RomVersion >= 114 && this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_493) == 0) EnableTimeLaunch = true;
        if ((this.class18_0.RomVersion == 103
            || this.class18_0.RomVersion == 104
            || this.class18_0.RomVersion == 105
            || (this.class18_0.RomVersion >= 109 && this.class18_0.RomVersion < 111)
            || this.class18_0.RomVersion >= 113)
            && this.class18_0.class13_u_0.long_71 == 0xff)
        {
            EnableTimeLaunch = true;
        }

        panel2.Visible = EnableTimeLaunch;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void Launch_Mode()
    {
        if (comboBox1.SelectedIndex == 0)
        {
            label1.Text = "Minimum RPM:";
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_137) != 0) this.grpTps.Enabled = true;
            else this.grpTps.Enabled = false;
        }
        else
        {
            label1.Text = "Cut RPM:";
            this.grpTps.Enabled = false;
        }
        if (!this.bool_0) this.method_5();
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
            this.grpTps = new System.Windows.Forms.GroupBox();
            this.txtbTpsDis = new System.Windows.Forms.NumericUpDown();
            this.txtbTpsThreshold = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbCutDelayLaunch = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txtbDiff1 = new System.Windows.Forms.NumericUpDown();
            this.txtbTpsMinVss = new System.Windows.Forms.NumericUpDown();
            this.txtbTpsMinRpm = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ctrlInputSelector1 = new CtrlInputSelector();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbRetard = new System.Windows.Forms.NumericUpDown();
            this.txtFuel = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelTPS = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkSatic = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.grpTps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsThreshold)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayLaunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDiff1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsMinVss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsMinRpm)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRetard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // grpTps
            // 
            this.grpTps.Controls.Add(this.txtbTpsDis);
            this.grpTps.Controls.Add(this.txtbTpsThreshold);
            this.grpTps.Controls.Add(this.label8);
            this.grpTps.Controls.Add(this.label5);
            this.grpTps.Controls.Add(this.label7);
            this.grpTps.Controls.Add(this.label4);
            this.grpTps.Location = new System.Drawing.Point(7, 229);
            this.grpTps.Name = "grpTps";
            this.grpTps.Size = new System.Drawing.Size(261, 75);
            this.grpTps.TabIndex = 1;
            this.grpTps.TabStop = false;
            this.grpTps.Text = "TPS Settings (Only for adjustable launch)";
            // 
            // txtbTpsDis
            // 
            this.txtbTpsDis.Location = new System.Drawing.Point(122, 49);
            this.txtbTpsDis.Name = "txtbTpsDis";
            this.txtbTpsDis.Size = new System.Drawing.Size(60, 20);
            this.txtbTpsDis.TabIndex = 26;
            this.txtbTpsDis.Click += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            this.txtbTpsDis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTpsMinRpm_KeyPress);
            this.txtbTpsDis.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTpsMinRpm_Validating);
            this.txtbTpsDis.Validated += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            // 
            // txtbTpsThreshold
            // 
            this.txtbTpsThreshold.Location = new System.Drawing.Point(122, 21);
            this.txtbTpsThreshold.Name = "txtbTpsThreshold";
            this.txtbTpsThreshold.Size = new System.Drawing.Size(60, 20);
            this.txtbTpsThreshold.TabIndex = 25;
            this.txtbTpsThreshold.Click += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            this.txtbTpsThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTpsMinRpm_KeyPress);
            this.txtbTpsThreshold.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTpsMinRpm_Validating);
            this.txtbTpsThreshold.Validated += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 23;
            this.label8.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Disengage Below:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Engage Above:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.txtbDiff1);
            this.groupBox2.Controls.Add(this.txtbTpsMinVss);
            this.groupBox2.Controls.Add(this.txtbTpsMinRpm);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.ctrlInputSelector1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(7, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 206);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2-Step Settings";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtbCutDelayLaunch);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(14, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 26);
            this.panel2.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 14);
            this.label15.TabIndex = 25;
            this.label15.Text = "Ign. Cut Delay:";
            // 
            // txtbCutDelayLaunch
            // 
            this.txtbCutDelayLaunch.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtbCutDelayLaunch.Location = new System.Drawing.Point(108, 3);
            this.txtbCutDelayLaunch.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtbCutDelayLaunch.Name = "txtbCutDelayLaunch";
            this.txtbCutDelayLaunch.Size = new System.Drawing.Size(60, 20);
            this.txtbCutDelayLaunch.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(176, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 14);
            this.label14.TabIndex = 26;
            this.label14.Text = "ms";
            // 
            // txtbDiff1
            // 
            this.txtbDiff1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtbDiff1.Location = new System.Drawing.Point(122, 153);
            this.txtbDiff1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtbDiff1.Name = "txtbDiff1";
            this.txtbDiff1.Size = new System.Drawing.Size(60, 20);
            this.txtbDiff1.TabIndex = 24;
            this.txtbDiff1.Click += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            this.txtbDiff1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTpsMinRpm_KeyPress);
            this.txtbDiff1.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTpsMinRpm_Validating);
            this.txtbDiff1.Validated += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            // 
            // txtbTpsMinVss
            // 
            this.txtbTpsMinVss.Location = new System.Drawing.Point(122, 129);
            this.txtbTpsMinVss.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbTpsMinVss.Name = "txtbTpsMinVss";
            this.txtbTpsMinVss.Size = new System.Drawing.Size(60, 20);
            this.txtbTpsMinVss.TabIndex = 23;
            this.txtbTpsMinVss.Click += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            this.txtbTpsMinVss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTpsMinRpm_KeyPress);
            this.txtbTpsMinVss.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTpsMinRpm_Validating);
            this.txtbTpsMinVss.Validated += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            // 
            // txtbTpsMinRpm
            // 
            this.txtbTpsMinRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbTpsMinRpm.Location = new System.Drawing.Point(122, 105);
            this.txtbTpsMinRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbTpsMinRpm.Name = "txtbTpsMinRpm";
            this.txtbTpsMinRpm.Size = new System.Drawing.Size(60, 20);
            this.txtbTpsMinRpm.TabIndex = 22;
            this.txtbTpsMinRpm.Click += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            this.txtbTpsMinRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTpsMinRpm_KeyPress);
            this.txtbTpsMinRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTpsMinRpm_Validating);
            this.txtbTpsMinRpm.Validated += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 21;
            this.label3.Text = "rpm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "kmh";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "Cut Delay:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TPS Based (Adjustable)",
            "Memory Based (Fix)"});
            this.comboBox1.Location = new System.Drawing.Point(28, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 22);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ctrlInputSelector1
            // 
            this.ctrlInputSelector1.Location = new System.Drawing.Point(24, 17);
            this.ctrlInputSelector1.Name = "ctrlInputSelector1";
            this.ctrlInputSelector1.Size = new System.Drawing.Size(213, 48);
            this.ctrlInputSelector1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minimum RPM:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Below Speed:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.grpTps);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 483);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Launch Control Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbRetard);
            this.groupBox3.Controls.Add(this.txtFuel);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.chkEnable);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.labelTPS);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.chkSatic);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(7, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 163);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Launch Control Anti-Lag";
            // 
            // txtbRetard
            // 
            this.txtbRetard.DecimalPlaces = 2;
            this.txtbRetard.Location = new System.Drawing.Point(122, 78);
            this.txtbRetard.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbRetard.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.txtbRetard.Name = "txtbRetard";
            this.txtbRetard.Size = new System.Drawing.Size(60, 20);
            this.txtbRetard.TabIndex = 27;
            this.txtbRetard.Click += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            this.txtbRetard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFuel_KeyPress);
            this.txtbRetard.Validating += new System.ComponentModel.CancelEventHandler(this.txtFuel_Validating);
            this.txtbRetard.Validated += new System.EventHandler(this.txtFuel_Validated);
            // 
            // txtFuel
            // 
            this.txtFuel.Location = new System.Drawing.Point(122, 50);
            this.txtFuel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.Size = new System.Drawing.Size(60, 20);
            this.txtFuel.TabIndex = 27;
            this.txtFuel.Click += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            this.txtFuel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTpsMinRpm_KeyPress);
            this.txtFuel.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTpsMinRpm_Validating);
            this.txtFuel.Validated += new System.EventHandler(this.txtbTpsMinRpm_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "FV";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(14, 25);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(194, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable Launch Control Anti-Lag";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "Enable Anti-Lag Above TPS";
            // 
            // labelTPS
            // 
            this.labelTPS.AutoSize = true;
            this.labelTPS.Location = new System.Drawing.Point(217, 137);
            this.labelTPS.Name = "labelTPS";
            this.labelTPS.Size = new System.Drawing.Size(21, 14);
            this.labelTPS.TabIndex = 9;
            this.labelTPS.Text = "0%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 14);
            this.label11.TabIndex = 4;
            this.label11.Text = "Enrichment:";
            // 
            // chkSatic
            // 
            this.chkSatic.AutoSize = true;
            this.chkSatic.Location = new System.Drawing.Point(191, 79);
            this.chkSatic.Name = "chkSatic";
            this.chkSatic.Size = new System.Drawing.Size(57, 18);
            this.chkSatic.TabIndex = 5;
            this.chkSatic.Text = "Static";
            this.chkSatic.UseVisualStyleBackColor = true;
            this.chkSatic.CheckedChanged += new System.EventHandler(this.chkSatic_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(14, 135);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(194, 22);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "Ign Retard:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 492);
            this.panel1.TabIndex = 1;
            // 
            // parmFtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmFtl";
            this.Size = new System.Drawing.Size(293, 492);
            this.Load += new System.EventHandler(this.parmFtl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.grpTps.ResumeLayout(false);
            this.grpTps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsThreshold)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayLaunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDiff1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsMinVss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsMinRpm)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRetard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("2-Step - Invert Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_138, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("2-Step - Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_137, byte_0);
            this.class18_0.method_153();
        }

        if (byte_0 == 0)
        {
            comboBox1.Enabled = false;
            txtbTpsMinRpm.Enabled = false;
            txtbTpsMinVss.Enabled = false;
            txtbDiff1.Enabled = false;
            grpTps.Enabled = false;
        }
        else
        {
            comboBox1.Enabled = true;
            txtbTpsMinRpm.Enabled = true;
            txtbTpsMinVss.Enabled = true;
            txtbDiff1.Enabled = true;
            Launch_Mode();
        }
    }

    private void method_4()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmFtl_Load(null, null);
        }
    }

    private void method_5()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("2-Step - Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_144, this.class18_0.method_233(int.Parse(this.txtbTpsMinVss.Text)));
            if (comboBox1.SelectedIndex == 0)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_141, this.class18_0.method_228(int.Parse(this.txtbTpsThreshold.Text)));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_143, this.class18_0.method_219(int.Parse(this.txtbTpsMinRpm.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_139, 0xff);
                if (this.class18_0.class13_u_0.long_142 != 0L) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_142, this.class18_0.method_228(int.Parse(this.txtbTpsDis.Text)));
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_139, 0);
                this.class18_0.method_151(this.class18_0.class13_u_0.long_140, this.class18_0.method_219(int.Parse(this.txtbTpsMinRpm.Text)));
            }
            long num = this.class18_0.method_219(0xfa0);
            long num2 = this.class18_0.method_219(0xfa0 - int.Parse(this.txtbDiff1.Text));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_136, num2 - num);

            // FTL Antilag
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_158, this.class18_0.method_228(trackBar1.Value));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_160, (byte)(float.Parse(this.txtbRetard.Text) * 4f));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_159, (long)(float.Parse(this.txtFuel.Text) * 4f));

            if (this.chkEnable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_157, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_157, 0);

            if (this.chkSatic.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_162, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_162, 0);

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_163, this.class18_0.method_220(float.Parse(this.txtbRetard.Text)));

            if (EnableTimeLaunch) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_421, (byte)(int.Parse(this.txtbCutDelayLaunch.Text) / 10));

            this.class18_0.method_153();
            this.parmFtl_Load(null, null);
        }
    }

    private void parmFtl_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;

        this.label2.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();

        this.ctrlInputSelector1.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_137));
        this.ctrlInputSelector1.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_138) == 0xff);
        
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_137) == 0)
        {
            comboBox1.Enabled = false;
            txtbTpsMinRpm.Enabled = false;
            txtbTpsMinVss.Enabled = false;
            txtbDiff1.Enabled = false;
            grpTps.Enabled = false;
        }
        else
        {
            comboBox1.Enabled = true;
            txtbTpsMinRpm.Enabled = true;
            txtbTpsMinVss.Enabled = true;
            txtbDiff1.Enabled = true;
            Launch_Mode();
        }

        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_139) == 0)
        {
            comboBox1.SelectedIndex = 1;
        }
        else
        {
            comboBox1.SelectedIndex = 0;
        }

        if (comboBox1.SelectedIndex == 0)
            this.txtbTpsMinRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_143)).ToString();
        else
            this.txtbTpsMinRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_140)).ToString();
        this.txtbTpsThreshold.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_141)).ToString();
        this.txtbTpsMinVss.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_144)).ToString();
        this.txtbTpsDis.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_142)).ToString();
        int num = this.class18_0.method_218(0x1d4L);
        int num2 = this.class18_0.method_218((long) (0x1d4 + ((int) this.class18_0.method_152(this.class18_0.class13_u_0.long_136))));
        this.txtbDiff1.Text = (num - num2).ToString();

        //FTL Antilag
        this.txtbRetard.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_160) * 0.25).ToString("0.00");
        this.trackBar1.Value = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_158));
        this.labelTPS.Text = this.trackBar1.Value + "%";
        this.txtFuel.Text = this.class18_0.method_223((int)this.class18_0.method_152(this.class18_0.class13_u_0.long_159)).ToString("0.00");
        this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_157) == 0xff;
        this.chkSatic.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_162) == 0xff;
        this.chkSatic.Enabled = this.class18_0.class13_u_0.long_162 != 0L;
        this.txtbRetard.Text = this.class18_0.method_188(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_163)).ToString("0.00");

        if (this.chkEnable.Checked)
        {
            this.txtbRetard.Enabled = true;
            this.trackBar1.Enabled = true;
            this.txtFuel.Enabled = true;
            this.chkSatic.Enabled = true;
        }
        else
        {
            this.txtbRetard.Enabled = false;
            this.trackBar1.Enabled = false;
            this.txtFuel.Enabled = false;
            this.chkSatic.Enabled = false;
        }


        if (EnableTimeLaunch) this.txtbCutDelayLaunch.Text = ((int)this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_421) * 10).ToString();

        this.bool_0 = false;
    }

    private void txtbTpsMinRpm_KeyPress(object sender, KeyPressEventArgs e)
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

    private void txtbTpsMinRpm_Validated(object sender, EventArgs e)
    {
        this.method_5();
    }

    private void txtbTpsMinRpm_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtFuel_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown)sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_5();
            }
            control.Focus();
        }
    }

    private void txtFuel_Validated(object sender, EventArgs e)
    {
        this.method_5();
    }

    private void txtFuel_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        this.groupBox1.Focus();
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

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Launch_Mode();
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkEnable.Checked)
        {
            this.txtbRetard.Enabled = true;
            this.trackBar1.Enabled = true;
            this.txtFuel.Enabled = true;
        }
        else
        {
            this.txtbRetard.Enabled = false;
            this.trackBar1.Enabled = false;
            this.txtFuel.Enabled = false;
            this.chkSatic.Enabled = false;
        }
        if (!this.bool_0)
        {
            this.method_5();
        }
    }

    private void chkSatic_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_5();
        }
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        this.labelTPS.Text = this.trackBar1.Value + "%";
        this.method_5();
    }
}

