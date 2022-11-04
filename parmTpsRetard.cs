using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmTpsRetard : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableGearDecay;
    private ctrlAdvTable ctrlAdvTableGearMultiplier;
    private ctrlAdvTable ctrlAdvTablePrevTps;
    private ctrlAdvTable ctrlAdvTableTpsMultiplier;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private GroupBox groupBox5;
    private GroupBox groupBox7;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label5;
    private Label label8;
    private Label label9;
    private Panel panel1;
    private TextBox txtbDeltaTps;
    private TextBox txtbEctMin;
    private TextBox txtbRpmMax;
    private TextBox txtbRpmMin;
    private TextBox txtbVssMax;
    private IContainer components;
    private Label label13;
    private Label label14;
    private GroupBox groupBox6;
    private Label label6;
    private Label label4;
    private ctrlAdvTable ctrlAdvTableRpmBase;
    private Label label15;
    private Label label16;
    private Label label7;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label19;
    private Label label18;
    private Label label17;
    private Label lblEct;
    private TextBox txtbVssMin;

    internal parmTpsRetard(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_15);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_15);
        this.InitializeComponent();
        this.ctrlAdvTableTpsMultiplier.method_HeaderGrayed(true);
        this.ctrlAdvTableTpsMultiplier.method_HasHeader(false);
        this.ctrlAdvTableTpsMultiplier.method_RowsNumber(2);
        this.ctrlAdvTableTpsMultiplier.method_ColumnsNumber(6);
        this.ctrlAdvTableTpsMultiplier.int_2 = 42;
        this.ctrlAdvTableTpsMultiplier.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_3);
        this.ctrlAdvTableTpsMultiplier.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_5);
        this.ctrlAdvTableTpsMultiplier.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_4);
        this.ctrlAdvTableTpsMultiplier.method_21(true);
        this.ctrlAdvTableTpsMultiplier.method_SetSensor(SensorsX.tpsX);
        this.ctrlAdvTableTpsMultiplier.method_23(false);
        this.ctrlAdvTableTpsMultiplier.method_1(ref this.class18_0);
        this.ctrlAdvTableTpsMultiplier.method_SetIncreaser(0.25);
        if (this.class18_0.class13_u_0.long_201 != 0L)
        {
            this.ctrlAdvTableTpsMultiplier.method_Load();
        }
        this.ctrlAdvTablePrevTps.method_HeaderGrayed(true);
        this.ctrlAdvTablePrevTps.method_HasHeader(false);
        this.ctrlAdvTablePrevTps.method_RowsNumber(2);
        this.ctrlAdvTablePrevTps.method_ColumnsNumber(7);
        this.ctrlAdvTablePrevTps.int_2 = 42;
        this.ctrlAdvTablePrevTps.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_0);
        this.ctrlAdvTablePrevTps.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_2);
        this.ctrlAdvTablePrevTps.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_1);
        this.ctrlAdvTablePrevTps.method_21(true);
        this.ctrlAdvTablePrevTps.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTablePrevTps.method_23(false);
        this.ctrlAdvTablePrevTps.method_1(ref this.class18_0);
        this.ctrlAdvTablePrevTps.method_SetIncreaser(0.25);
        if (this.class18_0.class13_u_0.long_205 != 0L)
        {
            this.ctrlAdvTablePrevTps.method_Load();
        }
        this.ctrlAdvTableRpmBase.method_HeaderGrayed(true);
        this.ctrlAdvTableRpmBase.method_HasHeader(false);
        this.ctrlAdvTableRpmBase.method_RowsNumber(2);
        this.ctrlAdvTableRpmBase.method_ColumnsNumber(7);
        this.ctrlAdvTableRpmBase.int_2 = 42;
        this.ctrlAdvTableRpmBase.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_12);
        this.ctrlAdvTableRpmBase.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_14);
        this.ctrlAdvTableRpmBase.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_13);
        this.ctrlAdvTableRpmBase.method_21(true);
        this.ctrlAdvTableRpmBase.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTableRpmBase.method_23(false);
        this.ctrlAdvTableRpmBase.method_1(ref this.class18_0);
        this.ctrlAdvTableRpmBase.method_SetIncreaser(0.25);
        if (this.class18_0.class13_u_0.long_204 != 0L)
        {
            this.ctrlAdvTableRpmBase.method_Load();
        }
        this.ctrlAdvTableGearDecay.method_HeaderGrayed(true);
        this.ctrlAdvTableGearDecay.method_HasHeader(false);
        this.ctrlAdvTableGearDecay.method_RowsNumber(2);
        this.ctrlAdvTableGearDecay.method_ColumnsNumber(5);
        this.ctrlAdvTableGearDecay.int_2 = 42;
        this.ctrlAdvTableGearDecay.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_6);
        this.ctrlAdvTableGearDecay.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_8);
        this.ctrlAdvTableGearDecay.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_7);
        this.ctrlAdvTableGearDecay.method_21(true);
        this.ctrlAdvTableGearDecay.method_SetSensor(SensorsX.gearX);
        this.ctrlAdvTableGearDecay.method_23(true);
        this.ctrlAdvTableGearDecay.method_1(ref this.class18_0);
        this.ctrlAdvTableGearDecay.method_SetIncreaser(1.0);
        if (this.class18_0.class13_u_0.long_202 != 0L)
        {
            this.ctrlAdvTableGearDecay.method_Load();
        }
        this.ctrlAdvTableGearMultiplier.method_HeaderGrayed(true);
        this.ctrlAdvTableGearMultiplier.method_HasHeader(false);
        this.ctrlAdvTableGearMultiplier.method_RowsNumber(2);
        this.ctrlAdvTableGearMultiplier.method_ColumnsNumber(5);
        this.ctrlAdvTableGearMultiplier.int_2 = 42;
        this.ctrlAdvTableGearMultiplier.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_10);
        this.ctrlAdvTableGearMultiplier.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_11);
        this.ctrlAdvTableGearMultiplier.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_9);
        this.ctrlAdvTableGearMultiplier.method_21(true);
        this.ctrlAdvTableGearMultiplier.method_SetSensor(SensorsX.gearX);
        this.ctrlAdvTableGearMultiplier.method_23(true);
        this.ctrlAdvTableGearMultiplier.method_1(ref this.class18_0);
        this.ctrlAdvTableGearMultiplier.method_SetIncreaser(0.25);
        if (this.class18_0.class13_u_0.long_203 != 0L)
        {
            this.ctrlAdvTableGearMultiplier.method_Load();
        }

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
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
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ctrlAdvTableGearDecay = new ctrlAdvTable();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlAdvTableRpmBase = new ctrlAdvTable();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ctrlAdvTablePrevTps = new ctrlAdvTable();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlAdvTableTpsMultiplier = new ctrlAdvTable();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ctrlAdvTableGearMultiplier = new ctrlAdvTable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbDeltaTps = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbRpmMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbRpmMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbVssMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbVssMin = new System.Windows.Forms.TextBox();
            this.txtbEctMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEct = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(471, 498);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 517);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tip-in Ignition Correction";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.ctrlAdvTableGearDecay);
            this.groupBox3.Location = new System.Drawing.Point(7, 435);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 72);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gear Duration (ms)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "Duration:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 6;
            this.label14.Text = "Gear:";
            // 
            // ctrlAdvTableGearDecay
            // 
            this.ctrlAdvTableGearDecay.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableGearDecay.Location = new System.Drawing.Point(83, 19);
            this.ctrlAdvTableGearDecay.Name = "ctrlAdvTableGearDecay";
            this.ctrlAdvTableGearDecay.Size = new System.Drawing.Size(241, 42);
            this.ctrlAdvTableGearDecay.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.ctrlAdvTableRpmBase);
            this.groupBox6.Location = new System.Drawing.Point(7, 206);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(416, 72);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Base Retard Per RPM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Retard:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "RPM:";
            // 
            // ctrlAdvTableRpmBase
            // 
            this.ctrlAdvTableRpmBase.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableRpmBase.Location = new System.Drawing.Point(83, 19);
            this.ctrlAdvTableRpmBase.Name = "ctrlAdvTableRpmBase";
            this.ctrlAdvTableRpmBase.Size = new System.Drawing.Size(319, 42);
            this.ctrlAdvTableRpmBase.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.ctrlAdvTablePrevTps);
            this.groupBox7.Location = new System.Drawing.Point(7, 127);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(416, 72);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Minimum TPS Required Per RPM";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 14);
            this.label15.TabIndex = 7;
            this.label15.Text = "TPS:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 14);
            this.label16.TabIndex = 6;
            this.label16.Text = "RPM:";
            // 
            // ctrlAdvTablePrevTps
            // 
            this.ctrlAdvTablePrevTps.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTablePrevTps.Location = new System.Drawing.Point(83, 18);
            this.ctrlAdvTablePrevTps.Name = "ctrlAdvTablePrevTps";
            this.ctrlAdvTablePrevTps.Size = new System.Drawing.Size(319, 42);
            this.ctrlAdvTablePrevTps.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.ctrlAdvTableTpsMultiplier);
            this.groupBox5.Location = new System.Drawing.Point(7, 284);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(416, 72);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TPS Correction Multiplier";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "Correction:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "TPS:";
            // 
            // ctrlAdvTableTpsMultiplier
            // 
            this.ctrlAdvTableTpsMultiplier.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableTpsMultiplier.Location = new System.Drawing.Point(83, 18);
            this.ctrlAdvTableTpsMultiplier.Name = "ctrlAdvTableTpsMultiplier";
            this.ctrlAdvTableTpsMultiplier.Size = new System.Drawing.Size(279, 42);
            this.ctrlAdvTableTpsMultiplier.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.ctrlAdvTableGearMultiplier);
            this.groupBox4.Location = new System.Drawing.Point(7, 363);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 72);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gear Correction Multiplier";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 14);
            this.label11.TabIndex = 7;
            this.label11.Text = "Correction:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 6;
            this.label12.Text = "Gear:";
            // 
            // ctrlAdvTableGearMultiplier
            // 
            this.ctrlAdvTableGearMultiplier.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableGearMultiplier.Location = new System.Drawing.Point(83, 18);
            this.ctrlAdvTableGearMultiplier.Name = "ctrlAdvTableGearMultiplier";
            this.ctrlAdvTableGearMultiplier.Size = new System.Drawing.Size(241, 42);
            this.ctrlAdvTableGearMultiplier.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblEct);
            this.groupBox2.Controls.Add(this.txtbDeltaTps);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtbRpmMax);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtbRpmMin);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtbVssMax);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtbVssMin);
            this.groupBox2.Controls.Add(this.txtbEctMin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conditions";
            // 
            // txtbDeltaTps
            // 
            this.txtbDeltaTps.Location = new System.Drawing.Point(322, 15);
            this.txtbDeltaTps.Name = "txtbDeltaTps";
            this.txtbDeltaTps.Size = new System.Drawing.Size(48, 20);
            this.txtbDeltaTps.TabIndex = 2;
            this.txtbDeltaTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEctMin_KeyPress);
            this.txtbDeltaTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbDeltaTps.Validated += new System.EventHandler(this.txtbEctMin_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "TPS Delta:";
            // 
            // txtbRpmMax
            // 
            this.txtbRpmMax.Location = new System.Drawing.Point(322, 42);
            this.txtbRpmMax.Name = "txtbRpmMax";
            this.txtbRpmMax.Size = new System.Drawing.Size(48, 20);
            this.txtbRpmMax.TabIndex = 6;
            this.txtbRpmMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEctMin_KeyPress);
            this.txtbRpmMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbRpmMax.Validated += new System.EventHandler(this.txtbEctMin_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "Maximum RPM:";
            // 
            // txtbRpmMin
            // 
            this.txtbRpmMin.Location = new System.Drawing.Point(104, 42);
            this.txtbRpmMin.Name = "txtbRpmMin";
            this.txtbRpmMin.Size = new System.Drawing.Size(48, 20);
            this.txtbRpmMin.TabIndex = 4;
            this.txtbRpmMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEctMin_KeyPress);
            this.txtbRpmMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbRpmMin.Validated += new System.EventHandler(this.txtbEctMin_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "Minimum RPM:";
            // 
            // txtbVssMax
            // 
            this.txtbVssMax.Location = new System.Drawing.Point(322, 71);
            this.txtbVssMax.Name = "txtbVssMax";
            this.txtbVssMax.Size = new System.Drawing.Size(48, 20);
            this.txtbVssMax.TabIndex = 5;
            this.txtbVssMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEctMin_KeyPress);
            this.txtbVssMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbVssMax.Validated += new System.EventHandler(this.txtbEctMin_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Maximum Speed:";
            // 
            // txtbVssMin
            // 
            this.txtbVssMin.Location = new System.Drawing.Point(104, 71);
            this.txtbVssMin.Name = "txtbVssMin";
            this.txtbVssMin.Size = new System.Drawing.Size(48, 20);
            this.txtbVssMin.TabIndex = 3;
            this.txtbVssMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEctMin_KeyPress);
            this.txtbVssMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbVssMin.Validated += new System.EventHandler(this.txtbEctMin_Validated);
            // 
            // txtbEctMin
            // 
            this.txtbEctMin.Location = new System.Drawing.Point(104, 15);
            this.txtbEctMin.Name = "txtbEctMin";
            this.txtbEctMin.Size = new System.Drawing.Size(48, 20);
            this.txtbEctMin.TabIndex = 0;
            this.txtbEctMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEctMin_KeyPress);
            this.txtbEctMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbEctMin.Validated += new System.EventHandler(this.txtbEctMin_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Minimum Speed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum ECT:";
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(158, 18);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 24;
            this.lblEct.Text = "C";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(376, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 14);
            this.label17.TabIndex = 25;
            this.label17.Text = "%";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 14);
            this.label18.TabIndex = 26;
            this.label18.Text = "kmh";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(373, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 14);
            this.label19.TabIndex = 27;
            this.label19.Text = "kmh";
            // 
            // parmTpsRetard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmTpsRetard";
            this.Size = new System.Drawing.Size(471, 498);
            this.Load += new System.EventHandler(this.parmTpsRetard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_205 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_198(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_205 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L));
        }
    }

    private void method_1(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_255(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_255(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTablePrevTps.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTablePrevTps.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_10(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_203 + dataGridViewCellValueEventArgs_0.ColumnIndex), Enum6.const_1).ToString("0.00");
        }
    }

    private void method_11(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("TPS Tip-in Retard");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_203 + dataGridViewCellValueEventArgs_0.ColumnIndex, (byte) this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_1));
        }
        this.class18_0.method_153();
    }

    private void method_12(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_204 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = Math.Round((double) ((-1f * this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_204 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)) / 4f), 2);
        }
    }

    private void method_13(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_255(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_253(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableRpmBase.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableRpmBase.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_14(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("TSP Tip-in Retard");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_204 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_216(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_204 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte) (float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * -4f));
        }
        this.class18_0.method_153();
    }

    private void method_15()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmTpsRetard_Load(null, null);
        }
    }

    private void method_16()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("TPS Tip-in Retard");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_198, this.class18_0.method_233(int.Parse(this.txtbVssMin.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_199, this.class18_0.method_233(int.Parse(this.txtbVssMax.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_196, this.class18_0.method_216(int.Parse(this.txtbRpmMin.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_197, this.class18_0.method_216(int.Parse(this.txtbRpmMax.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_195, this.class18_0.method_230((double) int.Parse(this.txtbEctMin.Text)));
            byte num = this.class18_0.method_228(50);
            byte num2 = this.class18_0.method_228(50 + int.Parse(this.txtbDeltaTps.Text));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_200, (byte) (num2 - num));
            this.class18_0.method_153();
            this.parmTpsRetard_Load(null, null);
        }
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("TPS Tip-in Retard");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_205 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_216(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_205 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_228(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_3(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_201 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_201 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L), Enum6.const_1).ToString("0.00");
        }
    }

    private void method_4(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_255(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableTpsMultiplier.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableTpsMultiplier.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_5(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("TPS Tip-in Retard");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_201 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_228(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_201 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte) this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_1));
        }
        this.class18_0.method_153();
    }

    private void method_6(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_202 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L) * 10;
        }
    }

    private void method_7(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableGearDecay.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableGearDecay.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_8(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("TPS Tip-in Retard");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_202 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L, (byte) (float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) / 10f));
        }
        this.class18_0.method_153();
    }

    private void method_9(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableGearMultiplier.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableGearMultiplier.grid.CurrentCell.ErrorText = "";
        }
    }

    private void parmTpsRetard_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;

        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();
        this.label18.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();
        this.label19.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();

        this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_200, this.class18_0.class13_u_0.long_202, this.class18_0.class13_u_0.long_203, this.class18_0.class13_u_0.long_205, this.class18_0.class13_u_0.long_204, this.class18_0.class13_u_0.long_201 });
        if (this.groupBox1.Enabled)
        {
            this.txtbEctMin.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_195)).ToString();
            this.txtbRpmMax.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_197)).ToString();
            this.txtbRpmMin.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_196)).ToString();
            this.txtbVssMax.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_199)).ToString();
            this.txtbVssMin.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_198)).ToString();
            int num = this.class18_0.method_198(0x80);
            int num2 = this.class18_0.method_198((byte) (0x80 + this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_200)));
            this.txtbDeltaTps.Text = (num2 - num).ToString();
            this.ctrlAdvTableTpsMultiplier.method_DisableHeader();
            this.ctrlAdvTableRpmBase.method_DisableHeader();
            this.ctrlAdvTableGearMultiplier.method_DisableHeader();
            this.ctrlAdvTableGearDecay.method_DisableHeader();
            this.ctrlAdvTablePrevTps.method_DisableHeader();
            this.bool_0 = false;
        }
    }

    private void txtbEctMin_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_16();
            }
            control.Focus();
        }
    }

    private void txtbEctMin_Validated(object sender, EventArgs e)
    {
        this.method_16();
    }

    private void txtbEctMin_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, interger Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
        if (!e.Cancel)
        {
            if ((control.Name == "txtbVssMin") || (control.Name == "txtbVssMax"))
            {
                if (int.Parse(this.txtbVssMin.Text) >= int.Parse(this.txtbVssMax.Text))
                {
                    this.errorProvider_0.SetError(control, "Vss max should be larger then vss min!");
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider_0.SetError(control, "");
                }
            }
            if ((control.Name == "txtbRpmMin") || (control.Name == "txtbRpmMax"))
            {
                if (int.Parse(this.txtbRpmMin.Text) >= int.Parse(this.txtbRpmMax.Text))
                {
                    this.errorProvider_0.SetError(control, "Rpm max should be larger then rpm min!");
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider_0.SetError(control, "");
                }
            }
        }
    }
}

