using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmInjector : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private Class17 class17_0;
    private ctrlAdvTable ctrlAdvTable;
    private ctrlBatteryOffset ctrlBatteryOffset = new ctrlBatteryOffset();
    private frmInjectorOverallCalc frmInjectorOverallCalc_0;
    private ErrorProvider errorProvider_0;
    private float float_0;
    private GroupBox groupBox1;
    private GroupBox groupBox4;
    private IContainer icontainer_0;
    private Label label1;
    private Label label11;
    private Label label4;
    private Label label8;
    private Label label9;
    private IContainer components;
    private Label label3;
    private Label label2;
    private Label label5;
    private Label label6;
    private Label label7;
    private GroupBox groupBox2;
    private Label label10;
    private Label label12;
    private Label lblO2;

    private byte byte_0;
    private byte[] byte_1;
    private TextBox txtbMultiplier;
    private Label label13;
    private Label label14;
    private Button btnMin2;
    private Button btnPlus2;
    private double double_0_0;
    private double double_1_0;
    private Label label21;
    private Label label20;
    private Label label19;
    private Label label18;
    private Label label17;
    private Label label16;
    private Label label15;
    private double double_2_0;
    private Button btnOverAllCalc;
    private string LastMultiplier = "";

    public int FuelPressureStart = 45;
    public int FuelPressureEnd = 45;
    public int DisplacementStart = 1595;
    private Panel panel1;
    private GroupBox groupBox3;
    private Label label25;
    private Label label24;
    private Label label22;
    private Label label23;
    private Label label28;
    private Label label29;
    private Label label26;
    private Label label27;
    public int DisplacementEnd = 1595;
    private GroupBox groupBox5;
    private Label label30;
    private Label label31;
    private ctrlAdvTable ctrlAdvTableDecay;
    private NumericUpDown txtbTipin;
    private NumericUpDown txtbPostfuel;
    private NumericUpDown txtbCrank;
    private NumericUpDown txtbDeadtime;
    private NumericUpDown txtbOverall;
    private NumericUpDown txtbInjNew;
    private NumericUpDown txtbInjOld;
    private NumericUpDown txtInjHotHigh;
    private NumericUpDown txtInjHotLow;
    private NumericUpDown txtInjColdHigh;
    private NumericUpDown txtInjColdLow;
    public bool CalculateOver = true;

    internal parmInjector(ref Class18 rm)
    {
        this.ctrlBatteryOffset = new ctrlBatteryOffset();
        this.class18_0 = rm;
        this.class17_0 = this.class18_0.class17_0;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.InitializeComponent();



        this.ctrlAdvTable.method_ColumnsNumber(7);
        this.ctrlAdvTable.method_RowsNumber(2);
        this.ctrlAdvTable.int_2 = 41;
        this.ctrlAdvTable.method_HasHeader(false);
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0);
        this.ctrlAdvTable.method_SetSensor(SensorsX.batV);
        this.ctrlAdvTable.method_21(true);
        this.ctrlAdvTable.method_23(false);
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_Load();

        this.ctrlAdvTableDecay.method_ColumnsNumber(4);
        this.ctrlAdvTableDecay.method_RowsNumber(2);
        this.ctrlAdvTableDecay.int_2 = 50;
        this.ctrlAdvTableDecay.method_HasHeader(false);
        this.ctrlAdvTableDecay.method_HeaderGrayed(true);
        this.ctrlAdvTableDecay.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_Decay);
        this.ctrlAdvTableDecay.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_Decay);
        this.ctrlAdvTableDecay.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_Decay);
        this.ctrlAdvTableDecay.method_21(false);
        this.ctrlAdvTableDecay.method_23(false);
        this.ctrlAdvTableDecay.method_1(ref this.class18_0);
        this.ctrlAdvTableDecay.method_Load();

        this.ctrlBatteryOffset.method_0(ref this.class18_0);

        this.class18_0.method_156("Injector Calibration", true);
        this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_1_2);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1_2(Struct12 struct12_0)
    {
        /*this.groupBox2.Visible = true;
        this.panel2.Visible = true;
        this.panel3.Visible = true;

        this.btnMin2.Visible = true;
        this.btnPlus2.Visible = true;*/
            
        this.lblO2.Visible = true;
        this.label12.Visible = true;
        this.label10.Text = "Set offset at idle";
        this.lblO2.Text = this.class18_0.method_200(struct12_0.byte_43).ToString("0.0");
        this.lblO2.ForeColor = this.class18_0.method_239(double.Parse(this.lblO2.Text));
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }
        catch { }
    }

    private void InitializeComponent()
    {
        this.ctrlBatteryOffset = new ctrlBatteryOffset();
        this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbTipin = new System.Windows.Forms.NumericUpDown();
            this.txtbPostfuel = new System.Windows.Forms.NumericUpDown();
            this.txtbCrank = new System.Windows.Forms.NumericUpDown();
            this.txtbDeadtime = new System.Windows.Forms.NumericUpDown();
            this.txtbOverall = new System.Windows.Forms.NumericUpDown();
            this.txtbInjNew = new System.Windows.Forms.NumericUpDown();
            this.txtbInjOld = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.ctrlAdvTableDecay = new ctrlAdvTable();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInjHotHigh = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.txtInjHotLow = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.txtInjColdHigh = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.txtInjColdLow = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.btnOverAllCalc = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbMultiplier = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.btnMin2 = new System.Windows.Forms.Button();
            this.btnPlus2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblO2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTipin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbPostfuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCrank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDeadtime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbOverall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbInjNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbInjOld)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjHotHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjHotLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjColdHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjColdLow)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlBatteryOffset
            // 
            this.ctrlBatteryOffset.Location = new System.Drawing.Point(82, 19);
            this.ctrlBatteryOffset.Name = "ctrlBatteryOffset";
            this.ctrlBatteryOffset.Size = new System.Drawing.Size(349, 22);
            this.ctrlBatteryOffset.TabIndex = 25;
            this.ctrlBatteryOffset.delegate64_0 += new ctrlBatteryOffset.Delegate64(this.method_7);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbTipin);
            this.groupBox1.Controls.Add(this.txtbPostfuel);
            this.groupBox1.Controls.Add(this.txtbCrank);
            this.groupBox1.Controls.Add(this.txtbDeadtime);
            this.groupBox1.Controls.Add(this.txtbOverall);
            this.groupBox1.Controls.Add(this.txtbInjNew);
            this.groupBox1.Controls.Add(this.txtbInjOld);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnOverAllCalc);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtbMultiplier);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 391);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Injector Calibration";
            // 
            // txtbTipin
            // 
            this.txtbTipin.Location = new System.Drawing.Point(328, 73);
            this.txtbTipin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtbTipin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbTipin.Name = "txtbTipin";
            this.txtbTipin.Size = new System.Drawing.Size(56, 20);
            this.txtbTipin.TabIndex = 48;
            this.txtbTipin.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtbTipin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtbTipin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtbTipin.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // txtbPostfuel
            // 
            this.txtbPostfuel.Location = new System.Drawing.Point(328, 49);
            this.txtbPostfuel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtbPostfuel.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbPostfuel.Name = "txtbPostfuel";
            this.txtbPostfuel.Size = new System.Drawing.Size(56, 20);
            this.txtbPostfuel.TabIndex = 47;
            this.txtbPostfuel.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtbPostfuel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtbPostfuel.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtbPostfuel.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // txtbCrank
            // 
            this.txtbCrank.Location = new System.Drawing.Point(328, 25);
            this.txtbCrank.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtbCrank.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbCrank.Name = "txtbCrank";
            this.txtbCrank.Size = new System.Drawing.Size(56, 20);
            this.txtbCrank.TabIndex = 46;
            this.txtbCrank.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtbCrank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtbCrank.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtbCrank.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // txtbDeadtime
            // 
            this.txtbDeadtime.DecimalPlaces = 2;
            this.txtbDeadtime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.txtbDeadtime.Location = new System.Drawing.Point(101, 97);
            this.txtbDeadtime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbDeadtime.Name = "txtbDeadtime";
            this.txtbDeadtime.Size = new System.Drawing.Size(56, 20);
            this.txtbDeadtime.TabIndex = 45;
            this.txtbDeadtime.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtbDeadtime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtbDeadtime.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDeadtime_Validating);
            this.txtbDeadtime.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // txtbOverall
            // 
            this.txtbOverall.Location = new System.Drawing.Point(101, 73);
            this.txtbOverall.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtbOverall.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtbOverall.Name = "txtbOverall";
            this.txtbOverall.Size = new System.Drawing.Size(56, 20);
            this.txtbOverall.TabIndex = 44;
            this.txtbOverall.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtbOverall.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtbOverall.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtbOverall.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // txtbInjNew
            // 
            this.txtbInjNew.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtbInjNew.Location = new System.Drawing.Point(101, 49);
            this.txtbInjNew.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbInjNew.Name = "txtbInjNew";
            this.txtbInjNew.Size = new System.Drawing.Size(56, 20);
            this.txtbInjNew.TabIndex = 43;
            this.txtbInjNew.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtbInjNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtbInjNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtbInjOld_Validating);
            this.txtbInjNew.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // txtbInjOld
            // 
            this.txtbInjOld.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtbInjOld.Location = new System.Drawing.Point(101, 25);
            this.txtbInjOld.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbInjOld.Name = "txtbInjOld";
            this.txtbInjOld.Size = new System.Drawing.Size(56, 20);
            this.txtbInjOld.TabIndex = 42;
            this.txtbInjOld.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtbInjOld.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtbInjOld.Validating += new System.ComponentModel.CancelEventHandler(this.txtbInjOld_Validating);
            this.txtbInjOld.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.ctrlAdvTableDecay);
            this.groupBox5.Location = new System.Drawing.Point(4, 320);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(437, 66);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Post Start Fuel Rate of Decay";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(7, 45);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(34, 14);
            this.label30.TabIndex = 17;
            this.label30.Text = "Rate:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 19);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 14);
            this.label31.TabIndex = 16;
            this.label31.Text = "Step:";
            // 
            // ctrlAdvTableDecay
            // 
            this.ctrlAdvTableDecay.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableDecay.Location = new System.Drawing.Point(82, 19);
            this.ctrlAdvTableDecay.Name = "ctrlAdvTableDecay";
            this.ctrlAdvTableDecay.Size = new System.Drawing.Size(210, 42);
            this.ctrlAdvTableDecay.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtInjHotHigh);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.txtInjHotLow);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.txtInjColdHigh);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.txtInjColdLow);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Location = new System.Drawing.Point(4, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 63);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Injector Phase";
            // 
            // txtInjHotHigh
            // 
            this.txtInjHotHigh.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtInjHotHigh.Location = new System.Drawing.Point(334, 38);
            this.txtInjHotHigh.Maximum = new decimal(new int[] {
            570,
            0,
            0,
            0});
            this.txtInjHotHigh.Name = "txtInjHotHigh";
            this.txtInjHotHigh.Size = new System.Drawing.Size(56, 20);
            this.txtInjHotHigh.TabIndex = 52;
            this.txtInjHotHigh.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtInjHotHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtInjHotHigh.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtInjHotHigh.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(332, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(61, 14);
            this.label26.TabIndex = 48;
            this.label26.Text = "High Load";
            // 
            // txtInjHotLow
            // 
            this.txtInjHotLow.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtInjHotLow.Location = new System.Drawing.Point(272, 38);
            this.txtInjHotLow.Maximum = new decimal(new int[] {
            570,
            0,
            0,
            0});
            this.txtInjHotLow.Name = "txtInjHotLow";
            this.txtInjHotLow.Size = new System.Drawing.Size(56, 20);
            this.txtInjHotLow.TabIndex = 51;
            this.txtInjHotLow.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtInjHotLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtInjHotLow.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtInjHotLow.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(269, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 14);
            this.label27.TabIndex = 47;
            this.label27.Text = "Low Load";
            // 
            // txtInjColdHigh
            // 
            this.txtInjColdHigh.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtInjColdHigh.Location = new System.Drawing.Point(108, 38);
            this.txtInjColdHigh.Maximum = new decimal(new int[] {
            570,
            0,
            0,
            0});
            this.txtInjColdHigh.Name = "txtInjColdHigh";
            this.txtInjColdHigh.Size = new System.Drawing.Size(56, 20);
            this.txtInjColdHigh.TabIndex = 50;
            this.txtInjColdHigh.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtInjColdHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtInjColdHigh.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtInjColdHigh.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(107, 18);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 14);
            this.label25.TabIndex = 46;
            this.label25.Text = "High Load";
            // 
            // txtInjColdLow
            // 
            this.txtInjColdLow.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtInjColdLow.Location = new System.Drawing.Point(48, 38);
            this.txtInjColdLow.Maximum = new decimal(new int[] {
            570,
            0,
            0,
            0});
            this.txtInjColdLow.Name = "txtInjColdLow";
            this.txtInjColdLow.Size = new System.Drawing.Size(56, 20);
            this.txtInjColdLow.TabIndex = 49;
            this.txtInjColdLow.Click += new System.EventHandler(this.txtbInjOld_Validated);
            this.txtInjColdLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInjOld_KeyPress);
            this.txtInjColdLow.Validating += new System.ComponentModel.CancelEventHandler(this.txtbOverall_Validating);
            this.txtInjColdLow.Validated += new System.EventHandler(this.txtbInjOld_Validated);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(44, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 14);
            this.label24.TabIndex = 45;
            this.label24.Text = "Low Load";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(396, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 14);
            this.label22.TabIndex = 44;
            this.label22.Text = "°";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(170, 40);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 14);
            this.label23.TabIndex = 43;
            this.label23.Text = "°";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(242, 40);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 14);
            this.label28.TabIndex = 36;
            this.label28.Text = "Hot:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 40);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 14);
            this.label29.TabIndex = 35;
            this.label29.Text = "Cold:";
            // 
            // btnOverAllCalc
            // 
            this.btnOverAllCalc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOverAllCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverAllCalc.Location = new System.Drawing.Point(129, 129);
            this.btnOverAllCalc.Name = "btnOverAllCalc";
            this.btnOverAllCalc.Size = new System.Drawing.Size(196, 23);
            this.btnOverAllCalc.TabIndex = 34;
            this.btnOverAllCalc.Text = "Calculate Overall Fuel Trim";
            this.btnOverAllCalc.UseVisualStyleBackColor = false;
            this.btnOverAllCalc.Click += new System.EventHandler(this.btnOverAllCalc_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(393, 76);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 14);
            this.label21.TabIndex = 33;
            this.label21.Text = "%";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(393, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 14);
            this.label20.TabIndex = 32;
            this.label20.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(393, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 14);
            this.label19.TabIndex = 31;
            this.label19.Text = "%";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(166, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 14);
            this.label18.TabIndex = 30;
            this.label18.Text = "FV";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(166, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 14);
            this.label17.TabIndex = 29;
            this.label17.Text = "%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(166, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 14);
            this.label16.TabIndex = 28;
            this.label16.Text = "cc";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(166, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 27;
            this.label15.Text = "cc";
            // 
            // txtbMultiplier
            // 
            this.txtbMultiplier.Enabled = false;
            this.txtbMultiplier.Location = new System.Drawing.Point(328, 97);
            this.txtbMultiplier.Name = "txtbMultiplier";
            this.txtbMultiplier.Size = new System.Drawing.Size(56, 20);
            this.txtbMultiplier.TabIndex = 25;
            this.txtbMultiplier.Text = "0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 14);
            this.label13.TabIndex = 26;
            this.label13.Text = "Final Multiplier:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 14);
            this.label14.TabIndex = 24;
            this.label14.Text = "Injector Offset:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 22;
            this.label7.Text = "Tps Tip-in:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "Post Start Trim:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cranking Trim:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ctrlBatteryOffset);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.ctrlAdvTable);
            this.groupBox4.Controls.Add(this.btnMin2);
            this.groupBox4.Controls.Add(this.btnPlus2);
            this.groupBox4.Location = new System.Drawing.Point(4, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(437, 99);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Battery Voltage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Offset (ms):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Voltage:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Presets:";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(82, 50);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(318, 42);
            this.ctrlAdvTable.TabIndex = 7;
            // 
            // btnMin2
            // 
            this.btnMin2.AutoSize = true;
            this.btnMin2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMin2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin2.Font = new System.Drawing.Font("Lucida Sans", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin2.ForeColor = System.Drawing.Color.IndianRed;
            this.btnMin2.Location = new System.Drawing.Point(409, 50);
            this.btnMin2.Name = "btnMin2";
            this.btnMin2.Size = new System.Drawing.Size(22, 19);
            this.btnMin2.TabIndex = 24;
            this.btnMin2.Text = "-";
            this.btnMin2.UseVisualStyleBackColor = false;
            this.btnMin2.Click += new System.EventHandler(this.btnMin2_Click);
            // 
            // btnPlus2
            // 
            this.btnPlus2.AutoSize = true;
            this.btnPlus2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPlus2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus2.Font = new System.Drawing.Font("Lucida Sans", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus2.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnPlus2.Location = new System.Drawing.Point(409, 75);
            this.btnPlus2.Name = "btnPlus2";
            this.btnPlus2.Size = new System.Drawing.Size(22, 19);
            this.btnPlus2.TabIndex = 23;
            this.btnPlus2.Text = "+";
            this.btnPlus2.UseVisualStyleBackColor = false;
            this.btnPlus2.Click += new System.EventHandler(this.btnPlus2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "Overall Fuel:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 491);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 14);
            this.label8.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "New Injector:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stock Injector:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblO2);
            this.groupBox2.Location = new System.Drawing.Point(7, 395);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 45);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calibrate Injector";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(62, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Set offset at idle";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(258, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "O2:";
            // 
            // lblO2
            // 
            this.lblO2.AutoSize = true;
            this.lblO2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblO2.Location = new System.Drawing.Point(285, 23);
            this.lblO2.Name = "lblO2";
            this.lblO2.Size = new System.Drawing.Size(37, 12);
            this.lblO2.TabIndex = 2;
            this.lblO2.Text = "14.75";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 461);
            this.panel1.TabIndex = 2;
            // 
            // parmInjector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmInjector";
            this.Size = new System.Drawing.Size(480, 461);
            this.Load += new System.EventHandler(this.parmInjector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTipin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbPostfuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCrank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDeadtime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbOverall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbInjNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbInjOld)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjHotHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjHotLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjColdHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInjColdLow)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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
        this.class18_0.method_155("Injector Voltage");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_185 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), this.class18_0.method_209(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151((this.class18_0.class13_u_0.long_185 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L, (long) ((double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 1000.0) / 3.2));
        }
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_208(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_185 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3))).ToString("0.00");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_224((int) this.class18_0.method_152((this.class18_0.class13_u_0.long_185 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L)).ToString("0.00");
        }
    }


    private void method_0_Decay(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableDecay.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableDecay.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_Decay(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Post-Start Rate of Decay");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_450 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4);
            this.class18_0.method_151(this.class18_0.class13_u_0.long_451 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4);
            this.class18_0.method_151(this.class18_0.class13_u_0.long_452 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4);
        }
        this.class18_0.method_153();
    }

    private void method_2_Decay(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_450 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) / 4).ToString();
        }
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmInjector_Load(null, null);
        }
    }

    private void method_6()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Injector Calibration");
            this.txtbMultiplier.Text = (float.Parse(this.txtbInjOld.Text) / float.Parse(this.txtbInjNew.Text)).ToString("0.000");
            //SetMultiplier(double.Parse((float.Parse(this.txtbInjOld.Text) / float.Parse(this.txtbInjNew.Text)).ToString("0.000")));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_33, this.class18_0.method_229(double.Parse(this.txtbMultiplier.Text)));
            if (this.class18_0.class13_u_0.long_34 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_34, (long)(double.Parse(this.txtbDeadtime.Text) * 8.0));
            if (this.class18_0.class13_u_0.long_39 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_39, this.class18_0.method_231(double.Parse(this.txtbOverall.Text), Enum6.const_0));
            this.class18_0.method_51_SetOLDInjectorSize(int.Parse(this.txtbInjOld.Text));
            this.class18_0.method_153();
            this.class18_0.method_155("Fuel Trim");
            this.class18_0.method_151(this.class18_0.class13_u_0.long_35, this.class18_0.method_231(double.Parse(this.txtbCrank.Text), Enum6.const_0));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_36, this.class18_0.method_231(double.Parse(this.txtbPostfuel.Text), Enum6.const_0));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_38, this.class18_0.method_231(double.Parse(this.txtbTipin.Text), Enum6.const_0));
            this.class18_0.method_153();
            
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_391 + 3L, (byte) ((570 - int.Parse(this.txtInjColdLow.Text)) / 15));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_391 + 4L, (byte)((570 - int.Parse(this.txtInjColdHigh.Text)) / 15));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_391 + 0L, (byte)((570 - int.Parse(this.txtInjHotLow.Text)) / 15));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_391 + 1L, (byte)((570 - int.Parse(this.txtInjHotHigh.Text)) / 15));

            //Reset Trims
            if (CalculateOver)
            {
                if (this.txtbMultiplier.Text != LastMultiplier)
                {
                    if (MessageBox.Show(Form.ActiveForm, "Would you like BMTune to calculate base trim values for the TPS Tip-In and Cranking?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    {
                        int Trims = (int)((1 - (float.Parse(this.txtbInjOld.Text) / float.Parse(this.txtbInjNew.Text))) * 100);
                        this.class18_0.method_151(this.class18_0.class13_u_0.long_35, this.class18_0.method_231((double)-Trims, Enum6.const_0));
                        this.class18_0.method_151(this.class18_0.class13_u_0.long_38, this.class18_0.method_231((double)-Trims, Enum6.const_0));
                    }
                }
            }
            CalculateOver = true;

            LastMultiplier = this.txtbMultiplier.Text;

            this.parmInjector_Load(null, null);
        }
        //this.parmInjector_Load(null, null);
    }

    private void btnOverAllCalc_Click(object sender, EventArgs e)
    {
        this.frmInjectorOverallCalc_0 = new frmInjectorOverallCalc();
        //this.frmInjectorOverallCalc_0.method_0(ref this.class18_0, FuelPressureStart, FuelPressureEnd, DisplacementStart, DisplacementEnd);
        this.frmInjectorOverallCalc_0.method_0(ref this.class18_0);
        if (this.frmInjectorOverallCalc_0.ShowDialog() == DialogResult.OK)
        {
            //FuelPressureStart = this.frmInjectorOverallCalc_0.FuelPressureStart;
            //FuelPressureEnd = this.frmInjectorOverallCalc_0.FuelPressureEnd;
            //DisplacementStart = this.frmInjectorOverallCalc_0.DisplacementStart;
            //DisplacementEnd = this.frmInjectorOverallCalc_0.DisplacementEnd;
            //SetMultiplier(double.Parse((float.Parse(this.txtbInjOld.Text) / float.Parse(this.txtbInjNew.Text)).ToString("0.000")));

            this.txtbOverall.Text = double.Parse(this.frmInjectorOverallCalc_0.Tag.ToString()).ToString();
        }
        this.frmInjectorOverallCalc_0.Close();
        this.frmInjectorOverallCalc_0.Dispose();
        this.frmInjectorOverallCalc_0 = null;
        this.method_6();
        this.parmInjector_Load(null, null);
    }

    private void method_7(byte[] byte_0, double[] double_0, double[] double_1, int int_0, string string_0)
    {
        this.class18_0.method_155("Injector Voltage: " + string_0);
        for (int i = 0; i < 7; i++)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_185 + (i * 3), this.class18_0.method_209((float) double_0[i]));
            this.class18_0.method_151((this.class18_0.class13_u_0.long_185 + (i * 3)) + 1L, (long) ((double_1[i] * 1000.0) / 3.2));
        }
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_81, (byte) int_0);
        this.class18_0.method_153();
        this.ctrlAdvTable.method_DisableHeader();
    }

    /*public void SetMultiplier(double InitialValue)
    {
        double Mult = InitialValue;
        double MultFuel = Math.Sqrt(double.Parse(FuelPressureEnd.ToString()) / double.Parse(FuelPressureStart.ToString()));
        double MultDisp = Math.Sqrt(double.Parse(DisplacementEnd.ToString()) / double.Parse(DisplacementStart.ToString()));
        this.txtbMultiplier.Text = (Mult + MultFuel + MultDisp).ToString("0.000");
    }*/

    private void parmInjector_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.txtbInjOld.Text = this.class18_0.method_50_GetOLDInjectorSize().ToString();
        if (this.class18_0.class13_u_0.long_81 != 0L)
        {
            this.ctrlBatteryOffset.method_1(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_81));
        }
        this.ctrlAdvTable.method_DisableHeader();
        this.txtbInjNew.Text = (((double) this.class18_0.method_50_GetOLDInjectorSize()) / this.class18_0.method_49()).ToString("0");
        this.float_0 = float.Parse(this.txtbInjNew.Text);
        this.txtbMultiplier.Text = this.class18_0.method_49().ToString("0.000");
        //SetMultiplier(this.class18_0.method_49());
        //LastMultiplier = this.class18_0.method_49().ToString("0.000");
        LastMultiplier = this.txtbMultiplier.Text;
        if (this.class18_0.class13_u_0.long_34 != 0L)
        {

            this.double_0_0 = ((double)this.class18_0.method_152(this.class18_0.class13_u_0.long_34)) / 8.0;
            this.txtbDeadtime.Text = (((double)this.class18_0.method_152(this.class18_0.class13_u_0.long_34)) / 8.0).ToString("0.00");
        }
        this.txtbDeadtime.Enabled = this.class18_0.class13_u_0.long_34 != 0L;
        if (this.class18_0.class13_u_0.long_39 != 0L)
        {
            this.txtbOverall.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_39), Enum6.const_0).ToString("");
        }
        this.txtbCrank.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_35), Enum6.const_0).ToString("");
        this.txtbPostfuel.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_36), Enum6.const_0).ToString("");
        this.txtbTipin.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_38), Enum6.const_0).ToString("");
        this.txtbOverall.Enabled = this.class18_0.class13_u_0.long_39 != 0L;

        this.txtInjColdLow.Text = (570 - (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_391 + 3L) * 15)).ToString();
        this.txtInjColdHigh.Text = (570 - (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_391 + 4L) * 15)).ToString();
        this.txtInjHotLow.Text = (570 - (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_391 + 0L) * 15)).ToString();
        this.txtInjHotHigh.Text = (570 - (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_391 + 1L) * 15)).ToString();


        if (!this.class18_0.class17_0.method_34_GetConnected())
        {
            this.label10.Text = "Ecu Disconnected";
            this.lblO2.Visible = false;
            this.label12.Visible = false;

            /*this.groupBox2.Visible = false;
            this.panel2.Visible = false;
            this.panel3.Visible = false;

            this.btnMin2.Visible = false;
            this.btnPlus2.Visible = false;*/
        }
        this.bool_0 = false;
    }

    private void txtbDeadtime_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbInjOld_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((this.txtbInjNew.Text != "0") && (e.KeyChar == '\r'))
        {
            this.bool_0 = true;
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            this.bool_0 = false;
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_6();
            }
            control.Focus();
        }
    }

    private void txtbInjOld_Validated(object sender, EventArgs e)
    {
        this.method_6();
    }

    private void txtbInjOld_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_257(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbOverall_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
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

    private void btnMin2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.ctrlAdvTable.grid.ColumnCount; i++)
        {
            float Values = float.Parse(this.ctrlAdvTable.grid.Rows[1].Cells[i].Value.ToString());
            this.ctrlAdvTable.grid.Rows[1].Cells[i].Value = Values - 0.01;
        }
        this.parmInjector_Load(null, null);
    }

    private void btnPlus2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.ctrlAdvTable.grid.ColumnCount; i++)
        {
            float Values = float.Parse(this.ctrlAdvTable.grid.Rows[1].Cells[i].Value.ToString());
            this.ctrlAdvTable.grid.Rows[1].Cells[i].Value = Values + 0.01;
        }
        this.parmInjector_Load(null, null);
    }
}

