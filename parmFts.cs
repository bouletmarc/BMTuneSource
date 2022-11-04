using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmFts : UserControl
{
    private bool bool_0;
    private CheckBox chkAntiLag;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInputSelector;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox grpAntilag;
    private IContainer icontainer_0;
    private Label label1;
    private Label label4;
    private Label label6;
    private Label label9;
    private IContainer components;
    private Label label2;
    private Label label3;
    private Label label5;
    private ComboBox comboBox1;
    private Label label8;
    private Label label10;
    private Panel panel1;
    private Label label11;
    private ToolTip toolTip1;
    private Panel panel4;
    private CheckBox chkStrain;
    private Label label12;
    private Label label13;
    private NumericUpDown txtbFuel;
    private NumericUpDown textBox_0;
    private NumericUpDown textBox1;
    private NumericUpDown txtbCutDelay;
    private NumericUpDown txtbIgn;
    private GroupBox grpSettings;
    private Label label14;
    private Label label15;
    private ctrlAdvTable ctrlAdvTable;
    private CheckBox chkGear;
    private CheckBox chkSatic;
    private Panel panel2;
    private Label label7;
    private NumericUpDown txtbCutDelayLaunch;
    private Label label16;
    private NumericUpDown txtbRpm;
    private bool EnableTimeLaunch = false;

    internal parmFts(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_5);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_5);
        this.InitializeComponent();

        this.ctrlInputSelector.method_7_Add_CustomInput_To_Selection(false);
        this.ctrlInputSelector.method_3_CustomInput("Always On");
        this.ctrlInputSelector.method_11_Add_Disabled_In_Selection(true);
        this.ctrlInputSelector.method_5(false);
        //this.ctrlInputSelector.method_1(0);
        this.ctrlInputSelector.method_Input_location(this.class18_0.class13_u_0.long_147);

        this.ctrlInputSelector.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_4);
        this.ctrlInputSelector.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_3);
        this.ctrlInputSelector.method_14(ref this.class18_0);
        //this.ctrlInputSelector.method_1(7);
        this.ctrlInputSelector.method_12();

        this.ctrlAdvTable.method_ColumnsNumber(5);
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.method_RowsNumber(2);
        this.ctrlAdvTable.int_2 = 40;
        this.ctrlAdvTable.method_HasHeader(false);
        //this.ctrlAdvTable.string_1 = new string[] { "Gear", "Rpm" };
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2);
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0);
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_Load();

        this.groupBox1.Enabled = true;

        //Disable under rom version
        if (this.class18_0.RomVersion <= 100)
        {
            label8.Visible = false;
            label10.Visible = false;
            textBox1.Visible = false;
        }

        if (this.class18_0.RomVersion != 108) panel4.Visible = false;
        if (this.class18_0.RomVersion < 110) this.chkSatic.Visible = false;

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

    private void chkAntiLag_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_6();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(parmFts));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbCutDelayLaunch = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.chkGear = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.NumericUpDown();
            this.txtbRpm = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAntilag = new System.Windows.Forms.GroupBox();
            this.chkSatic = new System.Windows.Forms.CheckBox();
            this.txtbIgn = new System.Windows.Forms.NumericUpDown();
            this.txtbFuel = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAntiLag = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_0 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlInputSelector = new CtrlInputSelector();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtbCutDelay = new System.Windows.Forms.NumericUpDown();
            this.chkStrain = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayLaunch)).BeginInit();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).BeginInit();
            this.grpAntilag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIgn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_0)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.grpSettings);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtbRpm);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.grpAntilag);
            this.groupBox1.Controls.Add(this.textBox_0);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ctrlInputSelector);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 469);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Full Throttle Shift Settings";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtbCutDelayLaunch);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(11, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 26);
            this.panel2.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "Ign. Cut Delay:";
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(176, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 14);
            this.label16.TabIndex = 26;
            this.label16.Text = "ms";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.label14);
            this.grpSettings.Controls.Add(this.label15);
            this.grpSettings.Controls.Add(this.ctrlAdvTable);
            this.grpSettings.Controls.Add(this.chkGear);
            this.grpSettings.Location = new System.Drawing.Point(7, 263);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(252, 95);
            this.grpSettings.TabIndex = 47;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Gear Based Shift Light";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 14);
            this.label14.TabIndex = 4;
            this.label14.Text = "RPM:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "Gear:";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(45, 44);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(201, 42);
            this.ctrlAdvTable.TabIndex = 2;
            // 
            // chkGear
            // 
            this.chkGear.AutoSize = true;
            this.chkGear.Location = new System.Drawing.Point(10, 19);
            this.chkGear.Name = "chkGear";
            this.chkGear.Size = new System.Drawing.Size(178, 18);
            this.chkGear.TabIndex = 1;
            this.chkGear.Text = "Enable Gear Based Shiftlight";
            this.chkGear.UseVisualStyleBackColor = true;
            this.chkGear.CheckedChanged += new System.EventHandler(this.chkAntiLag_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 182);
            this.textBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 45;
            this.textBox1.Click += new System.EventHandler(this.textBox_0_Validated);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_0_KeyPress);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_0_Validating);
            this.textBox1.Validated += new System.EventHandler(this.textBox_0_Validated);
            // 
            // txtbRpm
            // 
            this.txtbRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbRpm.Location = new System.Drawing.Point(118, 207);
            this.txtbRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbRpm.Name = "txtbRpm";
            this.txtbRpm.Size = new System.Drawing.Size(60, 20);
            this.txtbRpm.TabIndex = 46;
            this.txtbRpm.Click += new System.EventHandler(this.textBox_0_Validated);
            this.txtbRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_0_KeyPress);
            this.txtbRpm.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_0_Validating);
            this.txtbRpm.Validated += new System.EventHandler(this.textBox_0_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Sans", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(69, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 42;
            this.label11.Text = "FTS Informations?";
            this.toolTip1.SetToolTip(this.label11, resources.GetString("label11.ToolTip"));
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 38;
            this.label8.Text = "km/h";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 14);
            this.label10.TabIndex = 37;
            this.label10.Text = "Above VSS:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ajustable RPM",
            "Fixed RPM"});
            this.comboBox1.Location = new System.Drawing.Point(22, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 22);
            this.comboBox1.TabIndex = 35;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "Full Throttle Shift Input :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cut RPM:";
            // 
            // grpAntilag
            // 
            this.grpAntilag.Controls.Add(this.chkSatic);
            this.grpAntilag.Controls.Add(this.txtbIgn);
            this.grpAntilag.Controls.Add(this.txtbFuel);
            this.grpAntilag.Controls.Add(this.label5);
            this.grpAntilag.Controls.Add(this.chkAntiLag);
            this.grpAntilag.Controls.Add(this.label6);
            this.grpAntilag.Controls.Add(this.label9);
            this.grpAntilag.Location = new System.Drawing.Point(6, 364);
            this.grpAntilag.Name = "grpAntilag";
            this.grpAntilag.Size = new System.Drawing.Size(253, 97);
            this.grpAntilag.TabIndex = 32;
            this.grpAntilag.TabStop = false;
            this.grpAntilag.Text = "Full Throttle Shift Anti-Lag";
            // 
            // chkSatic
            // 
            this.chkSatic.AutoSize = true;
            this.chkSatic.Location = new System.Drawing.Point(177, 70);
            this.chkSatic.Name = "chkSatic";
            this.chkSatic.Size = new System.Drawing.Size(57, 18);
            this.chkSatic.TabIndex = 47;
            this.chkSatic.Text = "Static";
            this.chkSatic.UseVisualStyleBackColor = true;
            this.chkSatic.CheckedChanged += new System.EventHandler(this.ChkSatic_CheckedChanged);
            // 
            // txtbIgn
            // 
            this.txtbIgn.DecimalPlaces = 2;
            this.txtbIgn.Location = new System.Drawing.Point(100, 69);
            this.txtbIgn.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbIgn.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.txtbIgn.Name = "txtbIgn";
            this.txtbIgn.Size = new System.Drawing.Size(60, 20);
            this.txtbIgn.TabIndex = 46;
            this.txtbIgn.Click += new System.EventHandler(this.textBox_0_Validated);
            this.txtbIgn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_0_KeyPress);
            this.txtbIgn.Validating += new System.ComponentModel.CancelEventHandler(this.txtFuel_Validating);
            this.txtbIgn.Validated += new System.EventHandler(this.textBox_0_Validated);
            // 
            // txtbFuel
            // 
            this.txtbFuel.Location = new System.Drawing.Point(100, 42);
            this.txtbFuel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbFuel.Name = "txtbFuel";
            this.txtbFuel.Size = new System.Drawing.Size(60, 20);
            this.txtbFuel.TabIndex = 38;
            this.txtbFuel.Click += new System.EventHandler(this.textBox_0_Validated);
            this.txtbFuel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_0_KeyPress);
            this.txtbFuel.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_0_Validating);
            this.txtbFuel.Validated += new System.EventHandler(this.textBox_0_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 14);
            this.label5.TabIndex = 35;
            this.label5.Text = "FV";
            // 
            // chkAntiLag
            // 
            this.chkAntiLag.AutoSize = true;
            this.chkAntiLag.Location = new System.Drawing.Point(5, 17);
            this.chkAntiLag.Name = "chkAntiLag";
            this.chkAntiLag.Size = new System.Drawing.Size(134, 18);
            this.chkAntiLag.TabIndex = 25;
            this.chkAntiLag.Text = " Enable FTS Anti-Lag";
            this.chkAntiLag.UseVisualStyleBackColor = true;
            this.chkAntiLag.CheckedChanged += new System.EventHandler(this.chkAntiLag_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "Enrichment:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 14);
            this.label9.TabIndex = 29;
            this.label9.Text = "Ign Retard:";
            // 
            // textBox_0
            // 
            this.textBox_0.Location = new System.Drawing.Point(118, 156);
            this.textBox_0.Name = "textBox_0";
            this.textBox_0.Size = new System.Drawing.Size(60, 20);
            this.textBox_0.TabIndex = 45;
            this.textBox_0.Click += new System.EventHandler(this.textBox_0_Validated);
            this.textBox_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_0_KeyPress);
            this.textBox_0.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_0_Validating);
            this.textBox_0.Validated += new System.EventHandler(this.textBox_0_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Above TPS:";
            // 
            // ctrlInputSelector
            // 
            this.ctrlInputSelector.Location = new System.Drawing.Point(20, 72);
            this.ctrlInputSelector.Name = "ctrlInputSelector";
            this.ctrlInputSelector.Size = new System.Drawing.Size(216, 48);
            this.ctrlInputSelector.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtbCutDelay);
            this.panel4.Controls.Add(this.chkStrain);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(13, 478);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 54);
            this.panel4.TabIndex = 44;
            // 
            // txtbCutDelay
            // 
            this.txtbCutDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtbCutDelay.Location = new System.Drawing.Point(124, 28);
            this.txtbCutDelay.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtbCutDelay.Name = "txtbCutDelay";
            this.txtbCutDelay.Size = new System.Drawing.Size(50, 20);
            this.txtbCutDelay.TabIndex = 47;
            this.txtbCutDelay.Click += new System.EventHandler(this.textBox_0_Validated);
            this.txtbCutDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_0_KeyPress);
            this.txtbCutDelay.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_0_Validating);
            this.txtbCutDelay.Validated += new System.EventHandler(this.textBox_0_Validated);
            // 
            // chkStrain
            // 
            this.chkStrain.AutoSize = true;
            this.chkStrain.Location = new System.Drawing.Point(8, 5);
            this.chkStrain.Name = "chkStrain";
            this.chkStrain.Size = new System.Drawing.Size(155, 18);
            this.chkStrain.TabIndex = 43;
            this.chkStrain.Text = " Enable Strain Cut Delay";
            this.chkStrain.UseVisualStyleBackColor = true;
            this.chkStrain.CheckedChanged += new System.EventHandler(this.chkStrain_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 14);
            this.label12.TabIndex = 41;
            this.label12.Text = "Ignition Cut Delay:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(187, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 14);
            this.label13.TabIndex = 42;
            this.label13.Text = "ms";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 457);
            this.panel1.TabIndex = 1;
            // 
            // parmFts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmFts";
            this.Size = new System.Drawing.Size(297, 457);
            this.Load += new System.EventHandler(this.parmFts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayLaunch)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).EndInit();
            this.grpAntilag.ResumeLayout(false);
            this.grpAntilag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIgn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_0)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("FTS settings");
        this.class18_0.method_151(this.class18_0.class13_u_0.long_150 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_219(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        this.class18_0.method_153();
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_150 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2))).ToString();
        }
    }

    private void method_2(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTable.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTable.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_3(byte byte_0)
    {
        if (byte_0 == 0)
        {
            this.txtbRpm.Enabled = false;
            this.textBox_0.Enabled = false;
            this.chkGear.Enabled = false;
            this.grpAntilag.Enabled = false;
            this.comboBox1.Enabled = false;
            this.textBox1.Enabled = false;
        }
        else
        {
            this.grpAntilag.Enabled = true;
            this.txtbRpm.Enabled = true;
            this.comboBox1.Enabled = true;
            this.textBox_0.Enabled = true;
            this.chkGear.Enabled = true;
            this.textBox1.Enabled = true;
            this.ctrlAdvTable.Enabled = this.chkGear.Checked;
        }
        if (!this.bool_0)
        {
            this.class18_0.method_155("2-Step - FTS Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_147, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_4(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("2-Step - FTS Input Invert");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_148, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_5()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmFts_Load(null, null);
        }
    }

    private void method_6()
    {
        if (!this.bool_0)
        {
            if (this.class18_0.class13_u_0.long_150 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_150, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)));
            else this.class18_0.method_151(this.class18_0.class13_u_0.long_149, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_151, this.class18_0.method_228(int.Parse(this.textBox_0.Text)));

            if (this.chkGear.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_152, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_152, 0);

            if (this.class18_0.class13_u_0.long_153 != 0L)
            {
                if (comboBox1.SelectedIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_153, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_153, 0);
            }

            if (this.class18_0.class13_u_0.long_154 != 0L)
            {
                if (this.chkAntiLag.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_154, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_154, 0);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_156, (byte)(float.Parse(this.txtbIgn.Text) * 4f));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_155, (long)(float.Parse(this.txtbFuel.Text) * 4f));
            }

            if (this.class18_0.RomVersion > 100) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_402, this.class18_0.method_233(int.Parse(this.textBox1.Text)));

            if (this.class18_0.RomVersion == 108)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_420, (byte)(int.Parse(this.txtbCutDelay.Text) / 10));
                panel4.Visible = IsIgnitionCutActive();
                if (chkStrain.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_440, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_440, 0);
                txtbCutDelay.Enabled = chkStrain.Checked;
            }

            if (this.class18_0.RomVersion >= 110)
            {
                if (this.chkSatic.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_472, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_472, 0);

                if (this.chkSatic.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_473, this.class18_0.method_220(float.Parse(this.txtbIgn.Text)));

                this.chkSatic.Enabled = this.chkAntiLag.Checked;
            }

            if (EnableTimeLaunch) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_422, (byte)(int.Parse(this.txtbCutDelayLaunch.Text) / 10));

            this.parmFts_Load(null, null);
        }
    }

    private bool IsIgnitionCutActive()
    {
        return this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) != 0;
    }

    private void parmFts_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        if (this.class18_0.class13_u_0.long_150 != 0L)
        {
            this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_150)).ToString();
        }
        else
        {
            this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_149)).ToString();
        }
        this.ctrlInputSelector.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_147));
        this.ctrlInputSelector.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_148) == 0xff);
        if (this.class18_0.class13_u_0.long_151 != 0L)
        {
            this.textBox_0.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_151)).ToString();
        }


        this.chkGear.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_152) == 0xff;
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_147) == 0)
        {
            this.txtbRpm.Enabled = false;
            this.textBox_0.Enabled = false;
            this.grpAntilag.Enabled = false;
            this.chkGear.Enabled = false;
            this.comboBox1.Enabled = false;
            this.textBox1.Enabled = false;
            this.ctrlAdvTable.Enabled = false;
        }
        else
        {
            this.grpAntilag.Enabled = true;
            this.txtbRpm.Enabled = !this.chkGear.Checked;
            this.comboBox1.Enabled = true;
            this.textBox_0.Enabled = this.class18_0.class13_u_0.long_151 != 0L;
            this.textBox1.Enabled = true;
            this.ctrlAdvTable.Enabled = this.chkGear.Checked;
        }
        this.chkAntiLag.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_154) == 0xff;
        this.txtbFuel.Text = this.class18_0.method_223((int) this.class18_0.method_152(this.class18_0.class13_u_0.long_155)).ToString("0.00");
        this.txtbIgn.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_156) * 0.25).ToString("0.00");
        this.textBox1.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_402)).ToString();

        if (this.class18_0.RomVersion > 100) this.textBox1.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_402)).ToString();

        this.txtbFuel.Enabled = this.chkAntiLag.Checked;
        this.txtbIgn.Enabled = this.chkAntiLag.Checked;


        this.label8.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();

        bool IsAdjustable = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_153) == 0xff;
        if (IsAdjustable) comboBox1.SelectedIndex = 0;
        else comboBox1.SelectedIndex = 1;
        FTS_Mode();

        if (this.class18_0.RomVersion == 108)
        {
            this.txtbCutDelay.Text = ((int)this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_420) * 10).ToString();
            panel4.Visible = IsIgnitionCutActive();
            chkStrain.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_440) == 0xff;
            txtbCutDelay.Enabled = chkStrain.Checked;
        }

        if (this.class18_0.RomVersion >= 110)
        {
            this.chkSatic.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_472) == 0xff;
            if (this.chkSatic.Checked) this.txtbIgn.Text = this.class18_0.method_188(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_473)).ToString("0.00");

            this.chkSatic.Enabled = this.chkAntiLag.Checked;
        }

        if (EnableTimeLaunch) this.txtbCutDelayLaunch.Text = ((int)this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_422) * 10).ToString();

        this.bool_0 = false;
    }

    private void textBox_0_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_6();
            }
            control.Focus();
        }
    }

    private void textBox_0_Validated(object sender, EventArgs e)
    {
        this.method_6();
    }

    private void textBox_0_Validating(object sender, CancelEventArgs e)
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

    private void FTS_Mode()
    {
        if (comboBox1.SelectedIndex == 0) label1.Text = "Minimum RPM:";
        else label1.Text = "Cut RPM:";
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0) this.FTS_Mode();
    }

    private void btnMin3_Click(object sender, EventArgs e)
    {
        if (this.class18_0.class13_u_0.long_150 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_150, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)) + 1);
        else this.class18_0.method_151(this.class18_0.class13_u_0.long_149, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)) + 1);
        if (this.class18_0.class13_u_0.long_150 != 0L) this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_150)).ToString();
        else this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_149)).ToString();
        method_6();
    }

    private void btnPlus3_Click(object sender, EventArgs e)
    {
        if (this.class18_0.class13_u_0.long_150 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_150, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)) - 1);
        else this.class18_0.method_151(this.class18_0.class13_u_0.long_149, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)) - 1);
        if (this.class18_0.class13_u_0.long_150 != 0L) this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_150)).ToString();
        else this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_149)).ToString();
        method_6();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (this.class18_0.class13_u_0.long_151 != 0L) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_151, this.class18_0.method_228(int.Parse(this.textBox_0.Text) - 2));
        if (this.class18_0.class13_u_0.long_151 != 0L) this.textBox_0.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_151)).ToString();
        method_6();
    }

    private void button2_Click(object sender, EventArgs e)
    {

        if (this.class18_0.class13_u_0.long_151 != 0L) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_151, this.class18_0.method_228(int.Parse(this.textBox_0.Text) + 2));
        if (this.class18_0.class13_u_0.long_151 != 0L) this.textBox_0.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_151)).ToString();
        method_6();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        if (this.class18_0.RomVersion > 100) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_402, this.class18_0.method_233(int.Parse(this.textBox1.Text) - 2));
        if (this.class18_0.RomVersion > 100) this.textBox1.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_402)).ToString();
        method_6();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        if (this.class18_0.RomVersion > 100) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_402, this.class18_0.method_233(int.Parse(this.textBox1.Text) + 2));
        if (this.class18_0.RomVersion > 100) this.textBox1.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_402)).ToString();
        method_6();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        this.class18_0.method_151(this.class18_0.class13_u_0.long_155, (long)((float.Parse(this.txtbFuel.Text) - 2) * 4f));
        this.txtbFuel.Text = this.class18_0.method_223((int)this.class18_0.method_152(this.class18_0.class13_u_0.long_155)).ToString("0.00");
        method_6();
    }

    private void button6_Click(object sender, EventArgs e)
    {
        this.class18_0.method_151(this.class18_0.class13_u_0.long_155, (long)((float.Parse(this.txtbFuel.Text) + 2) * 4f));
        this.txtbFuel.Text = this.class18_0.method_223((int)this.class18_0.method_152(this.class18_0.class13_u_0.long_155)).ToString("0.00");
        method_6();
    }

    private void button8_Click(object sender, EventArgs e)
    {
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_156, (byte)((float.Parse(this.txtbIgn.Text) - 2) * 4f));
        this.txtbIgn.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_156) * 0.25).ToString("0.00");
        method_6();
    }

    private void button7_Click(object sender, EventArgs e)
    {
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_156, (byte)((float.Parse(this.txtbIgn.Text) + 2) * 4f));
        this.txtbIgn.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_156) * 0.25).ToString("0.00");
        method_6();
    }

    private void chkStrain_CheckedChanged(object sender, EventArgs e)
    {
        this.method_6();
    }

    private void txtbCutDelay_Validated(object sender, EventArgs e)
    {
        this.method_6();
    }

    private void ChkSatic_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_6();
        }
    }
}

