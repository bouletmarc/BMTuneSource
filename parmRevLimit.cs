using Data;
using System;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmRevLimit : UserControl
{
    private bool bool_0;
    private CheckBox chkFCut;
    private CheckBox chkICut;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label11;
    private Label label15;
    private Label lblRst1;
    private Label lblRst2;
    private Label lblSet1;
    private Label lblSet2;
    private IContainer components;
    private Label lblEct;
    private CheckBox chkGear;
    private Panel panel1;
    private Label label1;
    private Label label2;
    private ctrlAdvTable ctrlAdvTable;
    private NumericUpDown txtbLowSet;
    private NumericUpDown txtbThreshold;
    private NumericUpDown txtbHighReset;
    private NumericUpDown txtbHighSet;
    private NumericUpDown txtbLowReset;
    private NumericUpDown txtbCutDelayFTS;
    private Label label5;
    private Label label6;
    private NumericUpDown txtbCutDelayLaunch;
    private Label label3;
    private Label label4;
    private NumericUpDown txtFuel;
    private NumericUpDown txtbRetard;
    private Label label13;
    private Label label7;
    private Label label9;
    private Label label8;
    private GroupBox grp_TimeIgnCut;
    private GroupBox grp_IgnExtra;
    private CheckBox chk_IgnFuelMod;
    private CheckBox chk_IgnTimeMod;
    private NumericUpDown txtbCutDelay;
    private GroupBox groupBoxInputCutting;
    private ComboBox comboBox1;
    private CtrlInputSelector ctrlInputSelector1;
    private Label label12;
    private Label label10;
    private CheckBox checkBoxIgnCutMIL;
    private bool EnableTimeLaunch = false;

    internal parmRevLimit(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);

        this.InitializeComponent();
        
        this.chkICut.Enabled = true;
        //this.chkGear.Enabled = true;

        /*this.ctrlAdvTable.method_ColumnsNumber(5);
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.method_RowsNumber(2);
        this.ctrlAdvTable.method_HasHeader(false);
        this.ctrlAdvTable.int_2 = 40;
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_21(true);
        this.ctrlAdvTable.method_SetSensor(Sensors.gear);
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2);
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0);
        this.ctrlAdvTable.method_Load();
        this.ctrlAdvTable.Enabled = true;*/

        if (this.class18_0.RomVersion < 109)
        {
            if (this.class18_0.RomVersion < 102) grp_IgnExtra.Visible = false;
            else this.class18_0.GetIgnitionCutMODInstalled();
        }

        if (this.class18_0.RomVersion < 111) chk_IgnFuelMod.Visible = false;


        this.groupBoxInputCutting.Location = new Point(3, 151);
        if (this.class18_0.RomVersion < 118)
        {
            this.groupBoxInputCutting.Visible = false;
            this.chkICut.Visible = true;
            this.chkFCut.Visible = true;
        }
        else
        {
            this.chkICut.Visible = false;
            this.chkFCut.Visible = false;
            this.groupBoxInputCutting.Visible = true;
            this.comboBox1.Enabled = true;

            this.groupBox1.Size = new Size(265, 145);
            this.grp_IgnExtra.Location = new Point(3, 339);
            this.grp_TimeIgnCut.Location = new Point(3, 445);

            ReloadInputSelection();
        }


        /*checkBoxIgnCutMIL.Visible = false;
        if (this.class18_0.RomVersion >= 119)
        {
            checkBoxIgnCutMIL.Enabled = this.class18_0.class15_0.method_5(Enum4.const_11);
        }*/

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void ReloadInputSelection()
    {
        if (!this.ctrlInputSelector1.GetLoadedVars())
        {
            this.ctrlInputSelector1.method_14(ref this.class18_0);
            this.ctrlInputSelector1.method_3_CustomInput("Always On");
            this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(true);
            this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(true);
            this.ctrlInputSelector1.method_5(false);
            this.ctrlInputSelector1.method_Input_location(this.class18_0.class13_u_0.long_71);
            this.ctrlInputSelector1.method_12();
            this.ctrlInputSelector1.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_1_input);
            this.ctrlInputSelector1.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_0_input);
        }
    }

    public void CheckBothChecked()
    {
        label15.Visible = false;
        if (chkFCut.Checked == false && chkICut.Checked == false) label15.Visible = true;
    }

    /*private void method_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Rev Limit Settings");
        this.class18_0.method_151(this.class18_0.class13_0.long_82 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_219(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
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
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_0.long_82 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2))).ToString();
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
    }*/

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
            this.txtbThreshold = new System.Windows.Forms.NumericUpDown();
            this.txtbHighReset = new System.Windows.Forms.NumericUpDown();
            this.txtbHighSet = new System.Windows.Forms.NumericUpDown();
            this.txtbLowReset = new System.Windows.Forms.NumericUpDown();
            this.txtbLowSet = new System.Windows.Forms.NumericUpDown();
            this.lblEct = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chkICut = new System.Windows.Forms.CheckBox();
            this.chkFCut = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRst2 = new System.Windows.Forms.Label();
            this.lblRst1 = new System.Windows.Forms.Label();
            this.lblSet1 = new System.Windows.Forms.Label();
            this.lblSet2 = new System.Windows.Forms.Label();
            this.chkGear = new System.Windows.Forms.CheckBox();
            this.txtbCutDelayFTS = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbCutDelayLaunch = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFuel = new System.Windows.Forms.NumericUpDown();
            this.txtbRetard = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbCutDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxInputCutting = new System.Windows.Forms.GroupBox();
            this.checkBoxIgnCutMIL = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ctrlInputSelector1 = new CtrlInputSelector();
            this.grp_TimeIgnCut = new System.Windows.Forms.GroupBox();
            this.chk_IgnTimeMod = new System.Windows.Forms.CheckBox();
            this.grp_IgnExtra = new System.Windows.Forms.GroupBox();
            this.chk_IgnFuelMod = new System.Windows.Forms.CheckBox();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLowReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLowSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayFTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayLaunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRetard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxInputCutting.SuspendLayout();
            this.grp_TimeIgnCut.SuspendLayout();
            this.grp_IgnExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbThreshold);
            this.groupBox1.Controls.Add(this.txtbHighReset);
            this.groupBox1.Controls.Add(this.txtbHighSet);
            this.groupBox1.Controls.Add(this.txtbLowReset);
            this.groupBox1.Controls.Add(this.txtbLowSet);
            this.groupBox1.Controls.Add(this.lblEct);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.chkICut);
            this.groupBox1.Controls.Add(this.chkFCut);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblRst2);
            this.groupBox1.Controls.Add(this.lblRst1);
            this.groupBox1.Controls.Add(this.lblSet1);
            this.groupBox1.Controls.Add(this.lblSet2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rev limits Settings";
            // 
            // txtbThreshold
            // 
            this.txtbThreshold.Location = new System.Drawing.Point(140, 116);
            this.txtbThreshold.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.txtbThreshold.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.txtbThreshold.Name = "txtbThreshold";
            this.txtbThreshold.Size = new System.Drawing.Size(64, 20);
            this.txtbThreshold.TabIndex = 49;
            this.txtbThreshold.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbThreshold.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbThreshold.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // txtbHighReset
            // 
            this.txtbHighReset.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbHighReset.Location = new System.Drawing.Point(140, 92);
            this.txtbHighReset.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbHighReset.Name = "txtbHighReset";
            this.txtbHighReset.Size = new System.Drawing.Size(64, 20);
            this.txtbHighReset.TabIndex = 48;
            this.txtbHighReset.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbHighReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbHighReset.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbHighReset.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // txtbHighSet
            // 
            this.txtbHighSet.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbHighSet.Location = new System.Drawing.Point(140, 68);
            this.txtbHighSet.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbHighSet.Name = "txtbHighSet";
            this.txtbHighSet.Size = new System.Drawing.Size(64, 20);
            this.txtbHighSet.TabIndex = 47;
            this.txtbHighSet.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbHighSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbHighSet.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbHighSet.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // txtbLowReset
            // 
            this.txtbLowReset.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtbLowReset.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbLowReset.Location = new System.Drawing.Point(140, 44);
            this.txtbLowReset.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbLowReset.Name = "txtbLowReset";
            this.txtbLowReset.Size = new System.Drawing.Size(64, 20);
            this.txtbLowReset.TabIndex = 46;
            this.txtbLowReset.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbLowReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbLowReset.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbLowReset.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // txtbLowSet
            // 
            this.txtbLowSet.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbLowSet.Location = new System.Drawing.Point(140, 20);
            this.txtbLowSet.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbLowSet.Name = "txtbLowSet";
            this.txtbLowSet.Size = new System.Drawing.Size(64, 20);
            this.txtbLowSet.TabIndex = 45;
            this.txtbLowSet.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbLowSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbLowSet.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbLowSet.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(211, 119);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 23;
            this.lblEct.Text = "C";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(19, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(211, 28);
            this.label15.TabIndex = 20;
            this.label15.Text = "WARNING: Unchecking both will leave\r\n                     you with no rev limit";
            // 
            // chkICut
            // 
            this.chkICut.AutoSize = true;
            this.chkICut.Location = new System.Drawing.Point(129, 148);
            this.chkICut.Name = "chkICut";
            this.chkICut.Size = new System.Drawing.Size(89, 18);
            this.chkICut.TabIndex = 21;
            this.chkICut.Text = "Ignition Cut";
            this.chkICut.UseVisualStyleBackColor = true;
            this.chkICut.CheckedChanged += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // chkFCut
            // 
            this.chkFCut.AutoSize = true;
            this.chkFCut.Location = new System.Drawing.Point(34, 148);
            this.chkFCut.Name = "chkFCut";
            this.chkFCut.Size = new System.Drawing.Size(74, 18);
            this.chkFCut.TabIndex = 20;
            this.chkFCut.Text = " Fuel Cut";
            this.chkFCut.UseVisualStyleBackColor = true;
            this.chkFCut.CheckedChanged += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 14);
            this.label11.TabIndex = 14;
            this.label11.Text = "Warm Above ECT:";
            // 
            // lblRst2
            // 
            this.lblRst2.AutoSize = true;
            this.lblRst2.Location = new System.Drawing.Point(31, 95);
            this.lblRst2.Name = "lblRst2";
            this.lblRst2.Size = new System.Drawing.Size(72, 14);
            this.lblRst2.TabIndex = 9;
            this.lblRst2.Text = "Warm Reset:";
            // 
            // lblRst1
            // 
            this.lblRst1.AutoSize = true;
            this.lblRst1.Location = new System.Drawing.Point(31, 47);
            this.lblRst1.Name = "lblRst1";
            this.lblRst1.Size = new System.Drawing.Size(69, 14);
            this.lblRst1.TabIndex = 4;
            this.lblRst1.Text = "Cold Reset:";
            // 
            // lblSet1
            // 
            this.lblSet1.AutoSize = true;
            this.lblSet1.Location = new System.Drawing.Point(31, 22);
            this.lblSet1.Name = "lblSet1";
            this.lblSet1.Size = new System.Drawing.Size(56, 14);
            this.lblSet1.TabIndex = 2;
            this.lblSet1.Text = "Cold Set:";
            // 
            // lblSet2
            // 
            this.lblSet2.AutoSize = true;
            this.lblSet2.Location = new System.Drawing.Point(31, 71);
            this.lblSet2.Name = "lblSet2";
            this.lblSet2.Size = new System.Drawing.Size(59, 14);
            this.lblSet2.TabIndex = 7;
            this.lblSet2.Text = "Warm Set:";
            // 
            // chkGear
            // 
            this.chkGear.AutoSize = true;
            this.chkGear.Location = new System.Drawing.Point(274, 97);
            this.chkGear.Name = "chkGear";
            this.chkGear.Size = new System.Drawing.Size(157, 18);
            this.chkGear.TabIndex = 24;
            this.chkGear.Text = "Warm Gear based Limiter";
            this.chkGear.UseVisualStyleBackColor = true;
            this.chkGear.Visible = false;
            this.chkGear.CheckedChanged += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // txtbCutDelayFTS
            // 
            this.txtbCutDelayFTS.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtbCutDelayFTS.Location = new System.Drawing.Point(147, 93);
            this.txtbCutDelayFTS.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtbCutDelayFTS.Name = "txtbCutDelayFTS";
            this.txtbCutDelayFTS.Size = new System.Drawing.Size(64, 20);
            this.txtbCutDelayFTS.TabIndex = 50;
            this.txtbCutDelayFTS.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbCutDelayFTS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbCutDelayFTS.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbCutDelayFTS.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 14);
            this.label5.TabIndex = 41;
            this.label5.Text = "FTS Cut Delay:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 14);
            this.label6.TabIndex = 42;
            this.label6.Text = "ms";
            // 
            // txtbCutDelayLaunch
            // 
            this.txtbCutDelayLaunch.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtbCutDelayLaunch.Location = new System.Drawing.Point(147, 69);
            this.txtbCutDelayLaunch.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtbCutDelayLaunch.Name = "txtbCutDelayLaunch";
            this.txtbCutDelayLaunch.Size = new System.Drawing.Size(64, 20);
            this.txtbCutDelayLaunch.TabIndex = 50;
            this.txtbCutDelayLaunch.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbCutDelayLaunch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbCutDelayLaunch.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbCutDelayLaunch.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 14);
            this.label3.TabIndex = 41;
            this.label3.Text = "Launch Cut Delay:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 14);
            this.label4.TabIndex = 42;
            this.label4.Text = "ms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 14);
            this.label8.TabIndex = 51;
            this.label8.Text = "°";
            // 
            // txtFuel
            // 
            this.txtFuel.Location = new System.Drawing.Point(147, 45);
            this.txtFuel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.Size = new System.Drawing.Size(64, 20);
            this.txtFuel.TabIndex = 32;
            this.txtFuel.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtFuel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtFuel.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtFuel.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // txtbRetard
            // 
            this.txtbRetard.DecimalPlaces = 2;
            this.txtbRetard.Location = new System.Drawing.Point(147, 69);
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
            this.txtbRetard.Size = new System.Drawing.Size(64, 20);
            this.txtbRetard.TabIndex = 31;
            this.txtbRetard.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbRetard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbRetard.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIgn_Validating);
            this.txtbRetard.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 14);
            this.label13.TabIndex = 29;
            this.label13.Text = "Static Ign on Ign Cut:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "Enrichment on Ign Cut:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 14);
            this.label9.TabIndex = 30;
            this.label9.Text = "FV";
            // 
            // txtbCutDelay
            // 
            this.txtbCutDelay.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtbCutDelay.Location = new System.Drawing.Point(147, 45);
            this.txtbCutDelay.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtbCutDelay.Name = "txtbCutDelay";
            this.txtbCutDelay.Size = new System.Drawing.Size(64, 20);
            this.txtbCutDelay.TabIndex = 50;
            this.txtbCutDelay.Click += new System.EventHandler(this.txtbHighSet_Validated);
            this.txtbCutDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbHighSet_KeyPress);
            this.txtbCutDelay.Validating += new System.ComponentModel.CancelEventHandler(this.txtbHighSet_Validating);
            this.txtbCutDelay.Validated += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "Ignition Cut Delay:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "ms";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBoxInputCutting);
            this.panel1.Controls.Add(this.grp_TimeIgnCut);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grp_IgnExtra);
            this.panel1.Controls.Add(this.chkGear);
            this.panel1.Controls.Add(this.ctrlAdvTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 479);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxInputCutting
            // 
            this.groupBoxInputCutting.Controls.Add(this.checkBoxIgnCutMIL);
            this.groupBoxInputCutting.Controls.Add(this.label12);
            this.groupBoxInputCutting.Controls.Add(this.label10);
            this.groupBoxInputCutting.Controls.Add(this.comboBox1);
            this.groupBoxInputCutting.Controls.Add(this.ctrlInputSelector1);
            this.groupBoxInputCutting.Location = new System.Drawing.Point(274, 151);
            this.groupBoxInputCutting.Name = "groupBoxInputCutting";
            this.groupBoxInputCutting.Size = new System.Drawing.Size(265, 182);
            this.groupBoxInputCutting.TabIndex = 53;
            this.groupBoxInputCutting.TabStop = false;
            this.groupBoxInputCutting.Text = "Cutting Type";
            this.groupBoxInputCutting.Visible = false;
            // 
            // checkBoxIgnCutMIL
            // 
            this.checkBoxIgnCutMIL.AutoSize = true;
            this.checkBoxIgnCutMIL.Location = new System.Drawing.Point(48, 129);
            this.checkBoxIgnCutMIL.Name = "checkBoxIgnCutMIL";
            this.checkBoxIgnCutMIL.Size = new System.Drawing.Size(166, 18);
            this.checkBoxIgnCutMIL.TabIndex = 54;
            this.checkBoxIgnCutMIL.Text = "Enable MIL on Ignition Cut";
            this.checkBoxIgnCutMIL.UseVisualStyleBackColor = true;
            this.checkBoxIgnCutMIL.Visible = false;
            this.checkBoxIgnCutMIL.CheckedChanged += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(11, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(240, 28);
            this.label12.TabIndex = 5;
            this.label12.Text = "When the Input is unactive, it automatically\r\nrun in Fuel Cut ONLY";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 28);
            this.label10.TabIndex = 4;
            this.label10.Text = "When the Input is active, switch\r\nto this cutting type:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fuel Cut Only",
            "Fuel Cut+Ignition Cut",
            "Ignition Cut Only"});
            this.comboBox1.Location = new System.Drawing.Point(14, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 22);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // ctrlInputSelector1
            // 
            this.ctrlInputSelector1.Location = new System.Drawing.Point(11, 77);
            this.ctrlInputSelector1.Name = "ctrlInputSelector1";
            this.ctrlInputSelector1.Size = new System.Drawing.Size(248, 47);
            this.ctrlInputSelector1.TabIndex = 2;
            // 
            // grp_TimeIgnCut
            // 
            this.grp_TimeIgnCut.Controls.Add(this.chk_IgnTimeMod);
            this.grp_TimeIgnCut.Controls.Add(this.txtbCutDelayFTS);
            this.grp_TimeIgnCut.Controls.Add(this.txtbCutDelay);
            this.grp_TimeIgnCut.Controls.Add(this.label5);
            this.grp_TimeIgnCut.Controls.Add(this.label1);
            this.grp_TimeIgnCut.Controls.Add(this.txtbCutDelayLaunch);
            this.grp_TimeIgnCut.Controls.Add(this.label6);
            this.grp_TimeIgnCut.Controls.Add(this.label2);
            this.grp_TimeIgnCut.Controls.Add(this.label3);
            this.grp_TimeIgnCut.Controls.Add(this.label4);
            this.grp_TimeIgnCut.Location = new System.Drawing.Point(3, 329);
            this.grp_TimeIgnCut.Name = "grp_TimeIgnCut";
            this.grp_TimeIgnCut.Size = new System.Drawing.Size(265, 119);
            this.grp_TimeIgnCut.TabIndex = 52;
            this.grp_TimeIgnCut.TabStop = false;
            this.grp_TimeIgnCut.Text = "Ignition Cut Time Mod";
            // 
            // chk_IgnTimeMod
            // 
            this.chk_IgnTimeMod.AutoSize = true;
            this.chk_IgnTimeMod.Location = new System.Drawing.Point(46, 21);
            this.chk_IgnTimeMod.Name = "chk_IgnTimeMod";
            this.chk_IgnTimeMod.Size = new System.Drawing.Size(183, 18);
            this.chk_IgnTimeMod.TabIndex = 53;
            this.chk_IgnTimeMod.Text = "Enable Ignition Cut Time Mod";
            this.chk_IgnTimeMod.UseVisualStyleBackColor = true;
            this.chk_IgnTimeMod.Visible = false;
            this.chk_IgnTimeMod.CheckedChanged += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // grp_IgnExtra
            // 
            this.grp_IgnExtra.Controls.Add(this.chk_IgnFuelMod);
            this.grp_IgnExtra.Controls.Add(this.label8);
            this.grp_IgnExtra.Controls.Add(this.txtbRetard);
            this.grp_IgnExtra.Controls.Add(this.label7);
            this.grp_IgnExtra.Controls.Add(this.label13);
            this.grp_IgnExtra.Controls.Add(this.txtFuel);
            this.grp_IgnExtra.Controls.Add(this.label9);
            this.grp_IgnExtra.Location = new System.Drawing.Point(3, 223);
            this.grp_IgnExtra.Name = "grp_IgnExtra";
            this.grp_IgnExtra.Size = new System.Drawing.Size(265, 100);
            this.grp_IgnExtra.TabIndex = 2;
            this.grp_IgnExtra.TabStop = false;
            this.grp_IgnExtra.Text = "Ignition Cut Extra Mod";
            // 
            // chk_IgnFuelMod
            // 
            this.chk_IgnFuelMod.AutoSize = true;
            this.chk_IgnFuelMod.Location = new System.Drawing.Point(62, 21);
            this.chk_IgnFuelMod.Name = "chk_IgnFuelMod";
            this.chk_IgnFuelMod.Size = new System.Drawing.Size(137, 18);
            this.chk_IgnFuelMod.TabIndex = 52;
            this.chk_IgnFuelMod.Text = "Enable Fuel/Ign Mod";
            this.chk_IgnFuelMod.UseVisualStyleBackColor = true;
            this.chk_IgnFuelMod.CheckedChanged += new System.EventHandler(this.txtbHighSet_Validated);
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(274, 122);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(227, 48);
            this.ctrlAdvTable.TabIndex = 44;
            this.ctrlAdvTable.Visible = false;
            // 
            // parmRevLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmRevLimit";
            this.Size = new System.Drawing.Size(624, 479);
            this.Load += new System.EventHandler(this.parmRevLimit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLowReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLowSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayFTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelayLaunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRetard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCutDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxInputCutting.ResumeLayout(false);
            this.groupBoxInputCutting.PerformLayout();
            this.grp_TimeIgnCut.ResumeLayout(false);
            this.grp_TimeIgnCut.PerformLayout();
            this.grp_IgnExtra.ResumeLayout(false);
            this.grp_IgnExtra.PerformLayout();
            this.ResumeLayout(false);

    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmRevLimit_Load(null, null);
        }
    }

    private void method_4()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Rev Limit Settings");
            this.class18_0.method_151(this.class18_0.class13_u_0.long_52 + 6L, this.class18_0.method_219(int.Parse(this.txtbLowSet.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_52, this.class18_0.method_219(int.Parse(this.txtbLowReset.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_52 + 0x12L, this.class18_0.method_219(int.Parse(this.txtbHighSet.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_52 + 12L, this.class18_0.method_219(int.Parse(this.txtbHighReset.Text)));

            //Gear based
            //if (this.chkGear.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_84, 0xff);
            //else this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_84, 0);

            if (this.class18_0.RomVersion < 118)
            {
                if (this.chkFCut.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_72, 0);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_72, 0xff);

                if (this.chkICut.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_71, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_71, 0);
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    this.chkFCut.Checked = true;
                    this.chkICut.Checked = false;
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_520, 0x02);
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    this.chkFCut.Checked = true;
                    this.chkICut.Checked = true;
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_520, 0x00);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    this.chkFCut.Checked = false;
                    this.chkICut.Checked = true;
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_520, 0x01);
                }
                //Disable IgnitionCut Windows since input are Disabled
                if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) == 0x00) this.chkICut.Checked = false;
            }

            if (this.class18_0.RomVersion >= 119)
            {
                this.checkBoxIgnCutMIL.Visible = this.chkICut.Checked;
                if (this.checkBoxIgnCutMIL.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_525, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_525, 0);
            }

            /*if (this.class18_0.method_150(this.class18_0.class13_0.long_71) == 0xff && this.class18_0.method_150(this.class18_0.class13_0.long_74) == 0x00)
            {
                MessageBox.Show("ICM Error (CEL #15) MUST be disabled with ignition cut!");
                this.class18_0.method_149(this.class18_0.class13_0.long_74, 0xff);
            }*/

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_83, this.class18_0.method_230(double.Parse(this.txtbThreshold.Text)));

            if (this.class18_0.RomVersion >= 114)
            {
                chk_IgnTimeMod.Visible = this.chkICut.Checked;
                if (this.chk_IgnTimeMod.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_493, 0x00);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_493, 0xff);

                txtbCutDelay.Enabled = chk_IgnTimeMod.Checked && this.chkICut.Checked;
                txtbCutDelayLaunch.Enabled = chk_IgnTimeMod.Checked && this.chkICut.Checked;
                txtbCutDelayFTS.Enabled = chk_IgnTimeMod.Checked && this.chkICut.Checked;
            }

            if (this.class18_0.RomVersion < 102) grp_IgnExtra.Visible = false;
            else
            {
                if (this.class18_0.RomVersion < 109)
                {
                    if (this.class18_0.GetIgnitionCutMODInstalled()) grp_IgnExtra.Visible = this.chkICut.Checked;
                    else grp_IgnExtra.Visible = false;
                }
                else
                {
                    grp_IgnExtra.Visible = this.chkICut.Checked;
                }

                this.class18_0.method_151(this.class18_0.class13_u_0.long_423, (long)(float.Parse(this.txtFuel.Text) * 4f));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_424, (byte)((float.Parse(this.txtbRetard.Text) + 6) * 4f));
            }

            if ((this.class18_0.RomVersion == 103
                || this.class18_0.RomVersion == 104
                || this.class18_0.RomVersion == 105
                || (this.class18_0.RomVersion >= 109 && this.class18_0.RomVersion < 111)
                || this.class18_0.RomVersion >= 113))
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_420, (byte)(int.Parse(this.txtbCutDelay.Text) / 10));
                grp_TimeIgnCut.Visible = this.chkICut.Checked;

                if (this.class18_0.RomVersion >= 109)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_421, (byte)(int.Parse(this.txtbCutDelayLaunch.Text) / 10));
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_422, (byte)(int.Parse(this.txtbCutDelayFTS.Text) / 10));

                    if (this.class18_0.RomVersion < 114)
                    {
                        txtbCutDelayLaunch.Enabled = true;
                        txtbCutDelayFTS.Enabled = true;
                    }
                }
                else
                {
                    txtbCutDelayLaunch.Enabled = false;
                    txtbCutDelayFTS.Enabled = false;
                }
            }
            else
            {
                grp_TimeIgnCut.Visible = false;
            }

            if (this.class18_0.RomVersion < 111) chk_IgnFuelMod.Visible = false;
            else
            {
                if (this.chk_IgnFuelMod.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_494, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_494, 0);
            }

            this.class18_0.method_153();
            this.parmRevLimit_Load(null, null);
        }
    }

    private void SetIgnTimeModColor()
    {
        EnableTimeLaunch = false;
        if (this.class18_0.RomVersion >= 114 && this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_493) == 0)
        {
            if (this.class18_0.RomVersion < 118 && this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) == 0xff) {
                EnableTimeLaunch = true;
            }
            if (this.class18_0.RomVersion >= 118 && (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_520) == 0x00 || this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_520) == 0x01))
            {
                EnableTimeLaunch = true;
            }
        }
        
        if ((this.class18_0.RomVersion == 103
            || this.class18_0.RomVersion == 104
            || this.class18_0.RomVersion == 105
            || (this.class18_0.RomVersion >= 109 && this.class18_0.RomVersion < 111)
            || this.class18_0.RomVersion == 113)
            && this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) == 0xff)
        {
            EnableTimeLaunch = true;
        }

        if (EnableTimeLaunch)
        {
            txtbLowReset.ForeColor = Color.Red;
            txtbHighReset.ForeColor = Color.Red;
        }
        else
        {
            txtbLowReset.ForeColor = System.Drawing.SystemColors.WindowText;
            txtbHighReset.ForeColor = System.Drawing.SystemColors.WindowText;
        }
    }

    private void parmRevLimit_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.txtbLowSet.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_52 + 6L)).ToString();
        this.txtbLowReset.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_52)).ToString();
        this.txtbHighSet.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_52 + 0x12L)).ToString();
        this.txtbHighReset.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_52 + 12L)).ToString();
        if (this.class18_0.RomVersion < 118)
        {
            this.chkICut.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) != 0;
            this.chkFCut.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_72) == 0;
        }
        else
        {
            ReloadInputSelection();
            this.ctrlInputSelector1.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71));
            this.ctrlInputSelector1.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_72) == 0xff);

            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) == 0) comboBox1.Enabled = false;
            else comboBox1.Enabled = true;

            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_520) == 0) this.comboBox1.SelectedIndex = 1;
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_520) == 1) this.comboBox1.SelectedIndex = 2;
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_520) >= 2) this.comboBox1.SelectedIndex = 0;

            if (comboBox1.SelectedIndex == 0)
            {
                this.chkFCut.Checked = true;
                this.chkICut.Checked = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                this.chkFCut.Checked = true;
                this.chkICut.Checked = true;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                this.chkFCut.Checked = false;
                this.chkICut.Checked = true;
            }
            //Disable IgnitionCut Windows since input are Disabled
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) == 0x00) this.chkICut.Checked = false;
        }
        this.txtbThreshold.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_83)).ToString();
        this.txtbThreshold.Enabled = this.class18_0.class13_u_0.long_83 != 0L;

        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();

        if (this.class18_0.RomVersion >= 119)
        {
            this.checkBoxIgnCutMIL.Visible = this.chkICut.Checked;
            this.checkBoxIgnCutMIL.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_525) == 0xff;

            label12.Visible = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) != 0x00 && this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) != 0x80 && this.comboBox1.SelectedIndex != 0);
        }

        //Gear based
        //this.ctrlAdvTable.method_DisableHeader();
        //this.chkGear.Checked = this.class18_0.GetByteAt(this.class18_0.class13_0.long_84) != 0;
        //ctrlAdvTable.Enabled = (this.chkGear.Checked);
        CheckBothChecked();


        if (this.class18_0.RomVersion >= 114)
        {
            chk_IgnTimeMod.Visible = this.chkICut.Checked;
            this.chk_IgnTimeMod.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_493) == 0;

            txtbCutDelay.Enabled = chk_IgnTimeMod.Checked && this.chkICut.Checked;
            txtbCutDelayLaunch.Enabled = chk_IgnTimeMod.Checked && this.chkICut.Checked;
            txtbCutDelayFTS.Enabled = chk_IgnTimeMod.Checked && this.chkICut.Checked;
        }

        if (this.class18_0.RomVersion < 102) grp_IgnExtra.Visible = false;
        else
        {
            if (this.class18_0.RomVersion < 109)
            {
                if (this.class18_0.GetIgnitionCutMODInstalled()) grp_IgnExtra.Visible = this.chkICut.Checked;
                else grp_IgnExtra.Visible = false;
            }
            else
            {
                grp_IgnExtra.Visible = this.chkICut.Checked;
            }

            this.txtFuel.Text = this.class18_0.method_223((int)this.class18_0.method_152(this.class18_0.class13_u_0.long_423)).ToString("0.00");
            this.txtbRetard.Text = (this.class18_0.method_223(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_424)) - 6).ToString("0.00");
        }

        if ((this.class18_0.RomVersion == 103
            || this.class18_0.RomVersion == 104
            || this.class18_0.RomVersion == 105
            || (this.class18_0.RomVersion >= 109 && this.class18_0.RomVersion < 111)
            || this.class18_0.RomVersion >= 113))
        {
            this.txtbCutDelay.Text = ((int)this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_420) * 10).ToString();
            grp_TimeIgnCut.Visible = this.chkICut.Checked;

            if (this.class18_0.RomVersion >= 109)
            {
                this.txtbCutDelayLaunch.Text = ((int)this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_421) * 10).ToString();
                this.txtbCutDelayFTS.Text = ((int)this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_422) * 10).ToString();

                if (this.class18_0.RomVersion < 114)
                {
                    txtbCutDelayLaunch.Enabled = true;
                    txtbCutDelayFTS.Enabled = true;
                }
            }
            else
            {
                txtbCutDelayLaunch.Enabled = false;
                txtbCutDelayFTS.Enabled = false;
            }
        }
        else
        {
            grp_TimeIgnCut.Visible = false;
        }

        if (this.class18_0.RomVersion < 111) chk_IgnFuelMod.Visible = false;
        else
        {
            this.chk_IgnFuelMod.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_494) != 0;
        }

        SetIgnTimeModColor();

        this.bool_0 = false;
    }

    private void method_0_input(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Rev Limiter - Invert Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_72, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_1_input(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Rev Limiter - Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_71, byte_0);
            label12.Visible = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) != 0x00 && this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_71) != 0x80 && this.comboBox1.SelectedIndex != 0);
            this.class18_0.method_153();
        }

        if (byte_0 == 0)
        {
            comboBox1.Enabled = false;
            this.comboBox1.SelectedIndex = 0;
        }
        else
        {
            comboBox1.Enabled = true;
        }
    }

    private void txtbHighSet_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_4();
            }
            control.Focus();
        }
    }

    private void txtbHighSet_Validated(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_4();
        }
    }

    private void txtbHighSet_Validating(object sender, CancelEventArgs e)
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


            //Higher Reset than Set Check
            if ((int.Parse(txtbLowSet.Text) < int.Parse(txtbLowReset.Text) && control == txtbLowReset) || (int.Parse(txtbHighSet.Text) < int.Parse(txtbHighReset.Text) && control == txtbHighReset) && control != txtbThreshold)
            {
                this.errorProvider_0.SetError(control, "Reset RPM should be lower than Set RPM");
                //e.Cancel = true;
            }
        }
    }

    private void txtbIgn_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
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
}

