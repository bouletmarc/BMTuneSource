using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmCloseLoop : UserControl
{
    private bool bool_0;
    private CheckBox chkO2heaterDisable;
    private Class18 class18_0;
    private ComboBox cmbInput;
    private ctrlAdvTable ctrlAdvTable;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private GroupBox groupBox5;
    private IContainer icontainer_0;
    private Label label1;
    private Label label12;
    private Label label2;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private TextBox textBox_0;
    private IContainer components;
    private GroupBox groupBox1;
    private Label label10;
    private Label label4;
    private Label label3;
    private GroupBox groupBox2;
    private Label label11;
    private Label label13;
    private ctrlAdvTable ctrlAdvTableVEFuel;
    private Panel panel1;
    private Label label14;
    private CheckBox chkDisable;
    private Label label17;
    private Label label16;
    private Label label15;
    private Label lblEct;
    private Label label20;
    private Label label19;
    private Label lblEct2;
    private GroupBox groupBox6;
    private Label label27;
    private Label label26;
    private Label label25;
    private Label label24;
    private Label label23;
    private Label label22;
    private Label label21;
    private Label label18;
    private Label label33;
    private Label label32;
    private Label label28;
    private Label label29;
    private ComboBox comboBox_Mode;
    private ctrlAdvTable ctrlAdvTable_Rate;
    private NumericUpDown txtbMinEct;
    private NumericUpDown txtbOpenloopMbar;
    private NumericUpDown txtbTargetVolt;
    private NumericUpDown txtbMax2;
    private NumericUpDown txtbMax;
    private NumericUpDown txtbMin2;
    private NumericUpDown txtbMin;
    private NumericUpDown textBox1;
    private CheckBox chkFuel;
    private Button buttonWBMenu;
    private NumericUpDown txtbMult;

    internal parmCloseLoop(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.InitializeComponent();

        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.method_HasHeader(false);
        this.ctrlAdvTable.method_RowsNumber(3);
        this.ctrlAdvTable.method_ColumnsNumber(6);
        this.ctrlAdvTable.int_2 = 0x26;
        //this.ctrlAdvTable.string_1 = new string[] { "RPM", "Disable TPS", "Enable TPS" };
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0);
        this.ctrlAdvTable.method_21(true);
        this.ctrlAdvTable.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTable.method_23(false);
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_Load();


        this.ctrlAdvTableVEFuel.method_HeaderGrayed(true);
        this.ctrlAdvTableVEFuel.method_HasHeader(false);
        this.ctrlAdvTableVEFuel.method_RowsNumber(2);
        this.ctrlAdvTableVEFuel.method_ColumnsNumber(6);
        this.ctrlAdvTableVEFuel.int_2 = 0x26;
        this.ctrlAdvTableVEFuel.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_3_0);
        this.ctrlAdvTableVEFuel.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_2_0);
        this.ctrlAdvTableVEFuel.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_1_0);
        this.ctrlAdvTableVEFuel.method_21(true);
        this.ctrlAdvTableVEFuel.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTableVEFuel.method_1(ref this.class18_0);
        this.ctrlAdvTableVEFuel.method_Load();


        this.ctrlAdvTable_Rate.method_HeaderGrayed(true);
        this.ctrlAdvTable_Rate.method_HasHeader(false);
        this.ctrlAdvTable_Rate.method_ColumnsNumber(4);
        this.ctrlAdvTable_Rate.method_RowsNumber(3);
        this.ctrlAdvTable_Rate.int_2 = 45;
        this.ctrlAdvTable_Rate.method_1(ref this.class18_0);
        this.ctrlAdvTable_Rate.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2_Rate);
        this.ctrlAdvTable_Rate.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1_Rate);
        this.ctrlAdvTable_Rate.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0_Rate);
        this.ctrlAdvTable_Rate.method_Load();

        //this.chkUseWb.Enabled = this.class18_0.class15_0.method_5(Enum4.const_4);
        //if (!this.class18_0.class15_0.method_5(Enum4.const_4)) this.chkUseWb.Text += " (BUY)";

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkDisableCloseloop_CheckedChanged(object sender, EventArgs e)
    {
        this.method_5();
    }

    private void chkDisable_CheckedChanged(object sender, EventArgs e)
    {
        this.method_5();
    }

    private bool IsWideband()
    {
        bool IsWBeee = false;
        if (comboBox_Mode.SelectedIndex == 2) IsWBeee = true;
        return IsWBeee;
    }

    private void ChangeWB()
    {
        double num3;
        double num4;
        double num5;
        double num = 0.0;
        byte num2 = 0;
        this.textBox_0.Enabled = !IsWideband();
        this.class18_0.method_155("Closeloop Settings");
        string str = string.Empty;
        if (IsWideband() && !this.bool_0)
        {
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.percentage)
            {
                num3 = -10.0;
                num4 = 10.0;
                num5 = -80.0;
                str = "%";
            }
            else
            {
                num3 = 0.9;
                num4 = 1.1;
                num5 = 0.2;
                str = string.Empty;
            }
            if (this.class18_0.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
            {
                num = 14.75;
            }
            else
            {
                num = this.class18_0.method_240(14.75);
            }
            try
            {
                num2 = this.class18_0.method_214(num);
            }
            catch (Exception)
            {
                //this.chkUseWb.Checked = false;
                comboBox_Mode.SelectedIndex = 1;
                return;
            }
            //if (MessageBox.Show("Import settings from Wideband ?" + Environment.NewLine + Environment.NewLine + "Correction Trim: " + num5.ToString() + str + Environment.NewLine + "Minium Adjustment " + num3.ToString() + str + Environment.NewLine + "Maxium adjustment: " + num4.ToString() + str + Environment.NewLine + "Target O2 Voltage: " + num2.ToString(), "BMTune", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            this.txtbMin.Text = num3.ToString();
            this.txtbMax.Text = num4.ToString();
            this.txtbTargetVolt.Text = this.class18_0.method_196(num2).ToString();
            this.class18_0.method_151(this.class18_0.class13_u_0.long_37, this.class18_0.method_231(num5, Enum6.const_0));
            this.txtbMult.Text = num5.ToString();
            /*}
            else
            {
                this.chkUseWb.Checked = false;
            }*/
        }
        else if (!this.bool_0)
        {
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.percentage)
            {
                num3 = -30.0;
                num4 = 47.0;
                num5 = 0.0;
                str = "%";
            }
            else
            {
                num3 = 0.7;
                num4 = 1.47;
                num5 = 0.0;
                str = string.Empty;
            }
            //if (MessageBox.Show("Set default closeloop settings?" + Environment.NewLine + "O2 correction fuel trim: " + num5.ToString() + str + Environment.NewLine + "Closeloop minium adjustment " + num3.ToString() + str + Environment.NewLine + "Closeloop maxium adjustment: " + num4.ToString() + str + Environment.NewLine + "Target o2 volt: 0.47v", "BMTune", MessageBoxButtons.OK) == DialogResult.OK)
            //{
            this.txtbMin.Text = "-30";
            this.txtbMax.Text = "47";
            this.txtbTargetVolt.Text = 0.47.ToString();
            this.class18_0.method_151(this.class18_0.class13_u_0.long_37, this.class18_0.method_231(2.0, Enum6.const_0));
            this.txtbMult.Text = "0";
            //}
        }
        this.class18_0.method_153();
        this.method_5();
    }

    private void chkUseWb_CheckedChanged(object sender, EventArgs e)
    {
        ChangeWB();
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtbMax2 = new System.Windows.Forms.NumericUpDown();
            this.txtbMax = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.txtbMin2 = new System.Windows.Forms.NumericUpDown();
            this.txtbMin = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbTargetVolt = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtbMult = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.lblEct = new System.Windows.Forms.Label();
            this.txtbMinEct = new System.Windows.Forms.NumericUpDown();
            this.textBox_0 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbOpenloopMbar = new System.Windows.Forms.NumericUpDown();
            this.cmbInput = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkO2heaterDisable = new System.Windows.Forms.CheckBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonWBMenu = new System.Windows.Forms.Button();
            this.comboBox_Mode = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ctrlAdvTable_Rate = new ctrlAdvTable();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFuel = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.NumericUpDown();
            this.ctrlAdvTableVEFuel = new ctrlAdvTable();
            this.lblEct2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkDisable = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMin)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTargetVolt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMinEct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbOpenloopMbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.ctrlAdvTable);
            this.groupBox5.Location = new System.Drawing.Point(7, 336);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(320, 101);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Disable By TPS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 14);
            this.label10.TabIndex = 18;
            this.label10.Text = "Enable TPS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Disable TPS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "RPM:";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(78, 19);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(230, 62);
            this.ctrlAdvTable.TabIndex = 15;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtbMax2);
            this.groupBox4.Controls.Add(this.txtbMax);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.txtbMin2);
            this.groupBox4.Controls.Add(this.txtbMin);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(7, 238);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(320, 92);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Short/Long Term Correction";
            // 
            // txtbMax2
            // 
            this.txtbMax2.Location = new System.Drawing.Point(216, 65);
            this.txtbMax2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbMax2.Name = "txtbMax2";
            this.txtbMax2.Size = new System.Drawing.Size(60, 20);
            this.txtbMax2.TabIndex = 24;
            this.txtbMax2.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbMax2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbMax2.Validating += new System.ComponentModel.CancelEventHandler(this.numericMult_Validating);
            this.txtbMax2.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // txtbMax
            // 
            this.txtbMax.Location = new System.Drawing.Point(140, 65);
            this.txtbMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbMax.Name = "txtbMax";
            this.txtbMax.Size = new System.Drawing.Size(60, 20);
            this.txtbMax.TabIndex = 22;
            this.txtbMax.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbMax.Validating += new System.ComponentModel.CancelEventHandler(this.numericMult_Validating);
            this.txtbMax.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(217, 22);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 14);
            this.label33.TabIndex = 38;
            this.label33.Text = "Long Term";
            // 
            // txtbMin2
            // 
            this.txtbMin2.Location = new System.Drawing.Point(216, 42);
            this.txtbMin2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbMin2.Name = "txtbMin2";
            this.txtbMin2.Size = new System.Drawing.Size(60, 20);
            this.txtbMin2.TabIndex = 23;
            this.txtbMin2.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbMin2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbMin2.Validating += new System.ComponentModel.CancelEventHandler(this.numericMult_Validating);
            this.txtbMin2.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // txtbMin
            // 
            this.txtbMin.Location = new System.Drawing.Point(140, 42);
            this.txtbMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbMin.Name = "txtbMin";
            this.txtbMin.Size = new System.Drawing.Size(60, 20);
            this.txtbMin.TabIndex = 21;
            this.txtbMin.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbMin.Validating += new System.ComponentModel.CancelEventHandler(this.numericMult_Validating);
            this.txtbMin.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(138, 22);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(66, 14);
            this.label32.TabIndex = 37;
            this.label32.Text = "Short Term";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(325, 54);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(14, 14);
            this.label28.TabIndex = 36;
            this.label28.Text = "%";
            this.label28.Visible = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(326, 41);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(14, 14);
            this.label29.TabIndex = 35;
            this.label29.Text = "%";
            this.label29.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(288, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 14);
            this.label20.TabIndex = 30;
            this.label20.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(288, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 14);
            this.label19.TabIndex = 29;
            this.label19.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Max Adjustment:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Min Adjustment:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbTargetVolt);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtbMult);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lblEct);
            this.groupBox3.Controls.Add(this.txtbMinEct);
            this.groupBox3.Controls.Add(this.textBox_0);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtbOpenloopMbar);
            this.groupBox3.Controls.Add(this.cmbInput);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(7, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 160);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings:";
            // 
            // txtbTargetVolt
            // 
            this.txtbTargetVolt.DecimalPlaces = 2;
            this.txtbTargetVolt.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbTargetVolt.Location = new System.Drawing.Point(140, 112);
            this.txtbTargetVolt.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtbTargetVolt.Name = "txtbTargetVolt";
            this.txtbTargetVolt.Size = new System.Drawing.Size(60, 20);
            this.txtbTargetVolt.TabIndex = 33;
            this.txtbTargetVolt.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbTargetVolt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbTargetVolt.Validating += new System.ComponentModel.CancelEventHandler(this.numeric_positive_Validating);
            this.txtbTargetVolt.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(210, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 14);
            this.label17.TabIndex = 29;
            this.label17.Text = "V";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(210, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 14);
            this.label16.TabIndex = 28;
            this.label16.Text = "%";
            // 
            // txtbMult
            // 
            this.txtbMult.Location = new System.Drawing.Point(140, 89);
            this.txtbMult.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtbMult.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbMult.Name = "txtbMult";
            this.txtbMult.Size = new System.Drawing.Size(60, 20);
            this.txtbMult.TabIndex = 32;
            this.txtbMult.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbMult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbMult.Validating += new System.ComponentModel.CancelEventHandler(this.numericMult_Validating);
            this.txtbMult.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(210, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 14);
            this.label15.TabIndex = 27;
            this.label15.Text = "mBar";
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(210, 69);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 26;
            this.lblEct.Text = "C";
            // 
            // txtbMinEct
            // 
            this.txtbMinEct.Location = new System.Drawing.Point(140, 66);
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
            this.txtbMinEct.Size = new System.Drawing.Size(60, 20);
            this.txtbMinEct.TabIndex = 31;
            this.txtbMinEct.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbMinEct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbMinEct.Validating += new System.ComponentModel.CancelEventHandler(this.numericOpenloopMbar_Validating);
            this.txtbMinEct.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // textBox_0
            // 
            this.textBox_0.Location = new System.Drawing.Point(140, 135);
            this.textBox_0.Name = "textBox_0";
            this.textBox_0.Size = new System.Drawing.Size(60, 20);
            this.textBox_0.TabIndex = 5;
            this.textBox_0.Visible = false;
            this.textBox_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_0_KeyPress);
            this.textBox_0.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_0_Validating);
            this.textBox_0.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "Max O2 Voltage:";
            this.label12.Visible = false;
            // 
            // txtbOpenloopMbar
            // 
            this.txtbOpenloopMbar.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtbOpenloopMbar.Location = new System.Drawing.Point(140, 44);
            this.txtbOpenloopMbar.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbOpenloopMbar.Name = "txtbOpenloopMbar";
            this.txtbOpenloopMbar.Size = new System.Drawing.Size(60, 20);
            this.txtbOpenloopMbar.TabIndex = 30;
            this.txtbOpenloopMbar.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.txtbOpenloopMbar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.txtbOpenloopMbar.Validating += new System.ComponentModel.CancelEventHandler(this.numericOpenloopMbar_Validating);
            this.txtbOpenloopMbar.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // cmbInput
            // 
            this.cmbInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInput.Enabled = false;
            this.cmbInput.FormattingEnabled = true;
            this.cmbInput.Items.AddRange(new object[] {
            "ELD(d10)",
            "EGR(d12)",
            "B6",
            "O2(d14)"});
            this.cmbInput.Location = new System.Drawing.Point(140, 17);
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Size = new System.Drawing.Size(99, 22);
            this.cmbInput.TabIndex = 25;
            this.cmbInput.SelectedIndexChanged += new System.EventHandler(this.chkDisableCloseloop_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "O2 Input:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Correction Trim:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target O2 voltage:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Disable Below ECT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disable Above Load:";
            // 
            // chkO2heaterDisable
            // 
            this.chkO2heaterDisable.AutoSize = true;
            this.chkO2heaterDisable.Location = new System.Drawing.Point(17, 49);
            this.chkO2heaterDisable.Name = "chkO2heaterDisable";
            this.chkO2heaterDisable.Size = new System.Drawing.Size(124, 18);
            this.chkO2heaterDisable.TabIndex = 3;
            this.chkO2heaterDisable.Text = "Disable O2 Heater";
            this.chkO2heaterDisable.UseVisualStyleBackColor = true;
            this.chkO2heaterDisable.CheckedChanged += new System.EventHandler(this.chkDisableCloseloop_CheckedChanged);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonWBMenu);
            this.groupBox1.Controls.Add(this.comboBox_Mode);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.chkO2heaterDisable);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 704);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Closeloop Settings";
            // 
            // buttonWBMenu
            // 
            this.buttonWBMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonWBMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWBMenu.Location = new System.Drawing.Point(159, 48);
            this.buttonWBMenu.Name = "buttonWBMenu";
            this.buttonWBMenu.Size = new System.Drawing.Size(168, 25);
            this.buttonWBMenu.TabIndex = 129;
            this.buttonWBMenu.Text = "Open Wideband Settings";
            this.buttonWBMenu.UseVisualStyleBackColor = false;
            this.buttonWBMenu.Click += new System.EventHandler(this.buttonWBMenu_Click);
            // 
            // comboBox_Mode
            // 
            this.comboBox_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mode.FormattingEnabled = true;
            this.comboBox_Mode.Items.AddRange(new object[] {
            "Openloop - O2 Disabled",
            "Closeloop - Narrowband OEM Sensor",
            "Closeloop - Wideband Sensor"});
            this.comboBox_Mode.Location = new System.Drawing.Point(17, 21);
            this.comboBox_Mode.Name = "comboBox_Mode";
            this.comboBox_Mode.Size = new System.Drawing.Size(232, 22);
            this.comboBox_Mode.TabIndex = 20;
            this.comboBox_Mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_Mode_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ctrlAdvTable_Rate);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Location = new System.Drawing.Point(7, 578);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(320, 120);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Rate of Change - %/s";
            // 
            // ctrlAdvTable_Rate
            // 
            this.ctrlAdvTable_Rate.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable_Rate.Location = new System.Drawing.Point(115, 51);
            this.ctrlAdvTable_Rate.Name = "ctrlAdvTable_Rate";
            this.ctrlAdvTable_Rate.Size = new System.Drawing.Size(182, 61);
            this.ctrlAdvTable_Rate.TabIndex = 28;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(74, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(32, 14);
            this.label27.TabIndex = 27;
            this.label27.Text = "RPM:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 94);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(102, 14);
            this.label26.TabIndex = 26;
            this.label26.Text = "Fast-Lean to Rich:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 75);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(102, 14);
            this.label25.TabIndex = 25;
            this.label25.Text = "Fast-Rich to Lean:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(70, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(36, 14);
            this.label24.TabIndex = 24;
            this.label24.Text = "Slow:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(256, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 14);
            this.label23.TabIndex = 23;
            this.label23.Text = "4000>";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(213, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 28);
            this.label22.TabIndex = 22;
            this.label22.Text = "2500\r\n4000";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(168, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 28);
            this.label21.TabIndex = 21;
            this.label21.Text = "1000\r\n2500";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(117, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 14);
            this.label18.TabIndex = 20;
            this.label18.Text = "<1000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFuel);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.ctrlAdvTableVEFuel);
            this.groupBox2.Controls.Add(this.lblEct2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.chkDisable);
            this.groupBox2.Location = new System.Drawing.Point(7, 443);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 128);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VE Overheat Fuel Correction";
            // 
            // chkFuel
            // 
            this.chkFuel.AutoSize = true;
            this.chkFuel.Enabled = false;
            this.chkFuel.Location = new System.Drawing.Point(10, 44);
            this.chkFuel.Name = "chkFuel";
            this.chkFuel.Size = new System.Drawing.Size(162, 18);
            this.chkFuel.TabIndex = 35;
            this.chkFuel.Text = "VE Overheat Fuel Disable";
            this.chkFuel.UseVisualStyleBackColor = true;
            this.chkFuel.CheckedChanged += new System.EventHandler(this.chkDisable_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 18);
            this.textBox1.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.textBox1.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 34;
            this.textBox1.Click += new System.EventHandler(this.txtbMinIat_Validated);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_KeyPress);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.numericOpenloopMbar_Validating);
            this.textBox1.Validated += new System.EventHandler(this.txtbMinIat_Validated);
            // 
            // ctrlAdvTableVEFuel
            // 
            this.ctrlAdvTableVEFuel.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableVEFuel.Location = new System.Drawing.Point(77, 68);
            this.ctrlAdvTableVEFuel.Name = "ctrlAdvTableVEFuel";
            this.ctrlAdvTableVEFuel.Size = new System.Drawing.Size(237, 52);
            this.ctrlAdvTableVEFuel.TabIndex = 0;
            // 
            // lblEct2
            // 
            this.lblEct2.AutoSize = true;
            this.lblEct2.Location = new System.Drawing.Point(299, 21);
            this.lblEct2.Name = "lblEct2";
            this.lblEct2.Size = new System.Drawing.Size(15, 14);
            this.lblEct2.TabIndex = 27;
            this.lblEct2.Text = "C";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 14);
            this.label11.TabIndex = 19;
            this.label11.Text = "Correction:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 14);
            this.label13.TabIndex = 18;
            this.label13.Text = "ECT:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(149, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 14);
            this.label14.TabIndex = 18;
            this.label14.Text = "Above ECT:";
            // 
            // chkDisable
            // 
            this.chkDisable.AutoSize = true;
            this.chkDisable.Location = new System.Drawing.Point(10, 20);
            this.chkDisable.Name = "chkDisable";
            this.chkDisable.Size = new System.Drawing.Size(100, 18);
            this.chkDisable.TabIndex = 19;
            this.chkDisable.Text = "VE Correction";
            this.chkDisable.UseVisualStyleBackColor = true;
            this.chkDisable.CheckedChanged += new System.EventHandler(this.chkDisable_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 561);
            this.panel1.TabIndex = 18;
            // 
            // parmCloseLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmCloseLoop";
            this.Size = new System.Drawing.Size(380, 561);
            this.Load += new System.EventHandler(this.parmCloseLoop_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMin)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTargetVolt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMinEct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbOpenloopMbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_255(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Closeloop tps vs rpm table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_209 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_216(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_210 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_216(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_209 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_228(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_210 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_228(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_209 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_198(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_209 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_198(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_210 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L));
        }
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmCloseLoop_Load(null, null);
            this.ctrlAdvTable.method_DisableHeader();
        }
    }

    private void method_4(object sender, CancelEventArgs e)
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

    private void method_0_Rate(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Closeloop Settings");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) this.class18_0.method_151(this.class18_0.class13_u_0.long_390 + 6L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 16);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) this.class18_0.method_151(this.class18_0.class13_u_0.long_390 + 78L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 16);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 2) this.class18_0.method_151(this.class18_0.class13_u_0.long_390 + 30L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 16);
        this.class18_0.method_153();
    }

    private void method_1_Rate(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_390 + 6L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) / 16).ToString();
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_390 + 78L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) / 16).ToString();
        if (dataGridViewCellValueEventArgs_0.RowIndex == 2) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_390 + 30L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) / 16).ToString();
    }

    private void method_2_Rate(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTable_Rate.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTable_Rate.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_5()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Closeloop Settings");

            //if (this.chkDisableCloseloop.Checked) this.class18_0.method_149(this.class18_0.class13_0.long_206, 0xff);
            //else this.class18_0.method_149(this.class18_0.class13_0.long_206, 0);
            //if (this.chkUseWb.Checked) this.class18_0.method_149(this.class18_0.class13_0.long_215, 0xff);
            //else this.class18_0.method_149(this.class18_0.class13_0.long_215, 0);
            if (comboBox_Mode.SelectedIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_206, 0xff);
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_206, 0);
                if (comboBox_Mode.SelectedIndex == 1) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_215, 0);
                if (comboBox_Mode.SelectedIndex == 2) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_215, 0xff);
            }

            if (this.chkO2heaterDisable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_49, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_49, 0xff);

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_208, this.class18_0.method_227(float.Parse(this.txtbTargetVolt.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_207, this.class18_0.method_226(int.Parse(this.txtbOpenloopMbar.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_212, this.class18_0.method_231(double.Parse(this.txtbMax.Text), Enum6.const_0));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_211, this.class18_0.method_231(double.Parse(this.txtbMin.Text), Enum6.const_0));

            this.class18_0.method_151(this.class18_0.class13_u_0.long_415, this.class18_0.method_231(double.Parse(this.txtbMax2.Text), Enum6.const_0));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_416, this.class18_0.method_231(double.Parse(this.txtbMin2.Text), Enum6.const_0));

            if (this.class18_0.class13_u_0.long_213 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_213, this.class18_0.method_230(double.Parse(this.txtbMinEct.Text)));
            }
            if (this.class18_0.class13_u_0.long_216 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_216, this.class18_0.method_227(float.Parse(this.textBox_0.Text)));
            }
            if (this.class18_0.class13_u_0.long_217 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_217, (byte) this.cmbInput.SelectedIndex);
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_37, this.class18_0.method_231(double.Parse(this.txtbMult.Text), Enum6.const_0));
            
            if (!this.chkDisable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_31, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_31, 0);
            }
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_32, this.class18_0.method_230(double.Parse(this.textBox1.Text)));

            //if (this.chkFuel.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_76, 0xff);
            //else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_76, 0);

            this.class18_0.method_153();
            this.parmCloseLoop_Load(null, null);
        }
    }

    private void method_6(object sender, EventArgs e)
    {
        this.parmCloseLoop_Load(null, null);
    }

    private void parmCloseLoop_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        /*this.chkDisableCloseloop.Checked = this.class18_0.method_150(this.class18_0.class13_0.long_206) == 0xff;
        this.chkUseWb.Enabled = (this.class18_0.class13_0.long_215 != 0L && this.class18_0.class15_0.method_5(Enum4.const_4));
        if (this.class18_0.class13_0.long_215 != 0L)
        {
            this.chkUseWb.Checked = this.class18_0.method_150(this.class18_0.class13_0.long_215) != 0;
            this.textBox_0.Enabled = !this.chkUseWb.Checked;
        }*/
        
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_206) == 0xff) comboBox_Mode.SelectedIndex = 0;
        else
        {
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_215) == 0) comboBox_Mode.SelectedIndex = 1;
            else
            {
                comboBox_Mode.SelectedIndex = 2;
            }
        }

        if (comboBox_Mode.SelectedIndex == 0)
        {
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
            this.groupBox4.Enabled = false;
            this.groupBox5.Enabled = false;
            this.groupBox6.Enabled = false;
        }
        else
        {
            this.groupBox2.Enabled = true;
            this.groupBox3.Enabled = true;
            this.groupBox4.Enabled = true;
            this.groupBox5.Enabled = true;
            this.groupBox6.Enabled = true;
        }

        this.chkO2heaterDisable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_49) == 0;
        this.txtbTargetVolt.Text = this.class18_0.method_196(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_208)).ToString("0.00");
        this.txtbOpenloopMbar.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_207)).ToString();

        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();
        this.lblEct2.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();

        this.txtbMax.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_212), Enum6.const_0).ToString();
        this.txtbMin.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_211), Enum6.const_0).ToString();
       
        this.txtbMax2.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_415), Enum6.const_0).ToString();
        this.txtbMin2.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_416), Enum6.const_0).ToString();

        this.txtbMult.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_37), Enum6.const_0).ToString("");
        this.txtbMinEct.Enabled = this.class18_0.class13_u_0.long_213 != 0L;
        if (this.class18_0.class13_u_0.long_213 != 0L)
        {
            this.txtbMinEct.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_213)).ToString();
        }
        if (this.class18_0.class13_u_0.long_216 != 0L)
        {
            this.textBox_0.Text = this.class18_0.method_196(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_216)).ToString();
        }
        if (this.class18_0.class13_u_0.long_217 != 0L)
        {
            this.cmbInput.Enabled = true;
            this.cmbInput.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_217);
        }

        this.chkDisable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_31) == 0;
        this.textBox1.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_32)).ToString();
        this.textBox1.Enabled = this.chkDisable.Checked;
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            this.ctrlAdvTableVEFuel.method_SetIncreaser(0.05);
        }
        else
        {
            this.ctrlAdvTableVEFuel.method_SetIncreaser(5.0);
        }
        this.ctrlAdvTableVEFuel.method_DisableHeader();
        if (!this.chkDisable.Checked)
        {
            if (this.class18_0.class13_u_0.long_31 != 0L)
            {
                this.chkDisable.Enabled = true;
            }
        }

        //this.chkFuel.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_76) == 0xff;

        this.ctrlAdvTable_Rate.method_DisableHeader();

        this.bool_0 = false;
    }

    private void textBox_0_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox)sender;
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_5();
            }
            control.Focus();
        }
    }

    private void numeric_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown)sender;
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_5();
            }
            control.Focus();
        }
    }

    private void textBox_0_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Double Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void numeric_positive_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Double Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void numericMult_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            if (!this.class18_0.method_254(control.Text.ToString()))
            {
                this.errorProvider_0.SetError(control, "Invalid input, Double Postive required");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider_0.SetError(control, "");
            }
        }
        else if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.percentage)
        {
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

    private void numericOpenloopMbar_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, interger Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbMinIat_Validated(object sender, EventArgs e)
    {
        this.method_5();
    }

    //#############

    private void method_1_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableVEFuel.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableVEFuel.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_2_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_156("VE Overheat Fuel", false);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_190 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_190 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)this.class18_0.method_231((double)float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_1));
        }
        this.class18_0.method_153();
    }

    private void method_3_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_190 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_190 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L), Enum6.const_1).ToString("0.00");
        }
    }

    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        this.method_5();
        this.parmCloseLoop_Load(null, null);
    }

    private void comboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            if (comboBox_Mode.SelectedIndex == 0) this.method_5();
            else ChangeWB();
        }
    }

    private void buttonWBMenu_Click(object sender, EventArgs e)
    {
        this.class18_0.class17_0.frmMain_0.OpenSettingMenu("Wideband");
    }
}

