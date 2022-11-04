using Controls;
using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmEbcSettings : UserControl
{
    private bool bool_0 = true;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInputSelectorActivation;
    private CtrlInputSelector ctrlInputSelectorHiLo;
    private ctrlMapValue ctrlMapEbcAct;
    private ctrlMapValue ctrlMapWGact;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox9;
    private IContainer icontainer_0;
    private Label label1;
    private Label label25;
    private Label label6;
    private Label label7;
    private Label label9;
    private TextBox txtbFixedDutyLo;
    private TextBox txtbFspoolDuty;
    private ComboBox comboBox1;
    private Label label2;
    private Label label27;
    private Label label19;
    private IContainer components;
    private ComboBox comboBox2;
    private Label label3;
    private TextBox txtbMinDuty;
    private TextBox txtbMaxDuty;
    private ComboBox cmbHz;
    private Label label5;
    private Label label23;
    private Label label22;
    private GroupBox groupBox3;
    private GroupBox groupBox2;
    private Panel panel1;
    private Label label10;
    private Label label8;
    private CheckBox chkDisbleMilLean;
    private GroupBox groupBox6;
    private Label label12;
    private Label label11;
    private RadioButton rbNC;
    private RadioButton rbNO;
    private GroupBox groupBox5;
    private GroupBox groupBox4;
    private Label label18;
    private GroupBox groupBox_0;
    private Label label13;
    private Label label14;
    private ComboBox cmbDialInput;
    private ctrlAdvTable ctrlAdvTableDial;
    private GroupBox groupBox7;
    private ctrlAdvTable ctrlAdvTableTps;
    private bool DutyMode = true;

    internal parmEbcSettings(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_12);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_12);
        this.InitializeComponent();

        this.ctrlInputSelectorActivation.method_7_Add_CustomInput_To_Selection(false);
        this.ctrlInputSelectorActivation.method_3_CustomInput("Always On");
        this.ctrlInputSelectorActivation.method_11_Add_Disabled_In_Selection(false);
        this.ctrlInputSelectorActivation.method_5(false);
        //this.ctrlInputSelectorActivation.method_1(0);
        this.ctrlInputSelectorActivation.method_Input_location(this.class18_0.class13_u_0.long_246);

        this.ctrlInputSelectorHiLo.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInputSelectorHiLo.method_3_CustomInput("Always On");
        this.ctrlInputSelectorHiLo.method_11_Add_Disabled_In_Selection(true);
        this.ctrlInputSelectorHiLo.method_5(false);
        //this.ctrlInputSelectorHiLo.method_1(0);
        this.ctrlInputSelectorHiLo.method_Input_location(this.class18_0.class13_u_0.long_248);

        this.ctrlAdvTableTps.method_HeaderGrayed(false);
        this.ctrlAdvTableTps.method_HasHeader(true);
        this.ctrlAdvTableTps.method_RowsNumber(2);
        this.ctrlAdvTableTps.method_ColumnsNumber(2);
        this.ctrlAdvTableTps.method_1(ref this.class18_0);
        this.ctrlAdvTableTps.string_1 = new string[] { "tps(%)", "multiplier" };
        this.ctrlAdvTableTps.method_Load();
        this.ctrlAdvTableTps.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_7);
        this.ctrlAdvTableTps.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_6);
        this.ctrlAdvTableTps.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_5);

        this.ctrlAdvTableDial.method_HeaderGrayed(false);
        this.ctrlAdvTableDial.method_HasHeader(true);
        this.ctrlAdvTableDial.method_RowsNumber(2);
        this.ctrlAdvTableDial.method_ColumnsNumber(2);
        this.ctrlAdvTableDial.method_1(ref this.class18_0);
        this.ctrlAdvTableDial.string_1 = new string[] { "Analog Input(%)", "multiplier" };
        this.ctrlAdvTableDial.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTableDial.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTableDial.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0);

        this.comboBox1.SelectedIndex = 0;
        this.ctrlMapEbcAct.method_0(ref rm);
        this.ctrlMapEbcAct.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_4);
        this.ctrlMapWGact.method_0(ref rm);
        this.ctrlMapWGact.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_3);
        this.groupBox1.Location = new Point(0, 0);
        this.ctrlInputSelectorActivation.method_14(ref this.class18_0);
        this.ctrlInputSelectorActivation.method_3_CustomInput("Always on");
        this.ctrlInputSelectorActivation.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInputSelectorActivation.method_11_Add_Disabled_In_Selection(true);
        //this.ctrlInputSelectorActivation.method_1(7);
        this.ctrlInputSelectorActivation.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_11);
        this.ctrlInputSelectorActivation.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_10);
        this.ctrlInputSelectorActivation.method_12();
        this.ctrlInputSelectorHiLo.method_14(ref this.class18_0);
        //this.ctrlInputSelectorHiLo.method_1(8);
        this.ctrlInputSelectorHiLo.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_9);
        this.ctrlInputSelectorHiLo.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_8);
        this.ctrlInputSelectorHiLo.method_12();

        this.groupBox1.Enabled = true;

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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox_0 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDialInput = new System.Windows.Forms.ComboBox();
            this.ctrlAdvTableDial = new ctrlAdvTable();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbNC = new System.Windows.Forms.RadioButton();
            this.rbNO = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbHz = new System.Windows.Forms.ComboBox();
            this.txtbMinDuty = new System.Windows.Forms.TextBox();
            this.txtbMaxDuty = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ctrlAdvTableTps = new ctrlAdvTable();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtbFixedDutyLo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlMapWGact = new Controls.ctrlMapValue();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbFspoolDuty = new System.Windows.Forms.TextBox();
            this.ctrlMapEbcAct = new Controls.ctrlMapValue();
            this.label7 = new System.Windows.Forms.Label();
            this.chkDisbleMilLean = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ctrlInputSelectorActivation = new CtrlInputSelector();
            this.label27 = new System.Windows.Forms.Label();
            this.ctrlInputSelectorHiLo = new CtrlInputSelector();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox_0.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox_0);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.chkDisbleMilLean);
            this.groupBox3.Location = new System.Drawing.Point(7, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 619);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters";
            // 
            // groupBox_0
            // 
            this.groupBox_0.Controls.Add(this.label13);
            this.groupBox_0.Controls.Add(this.label14);
            this.groupBox_0.Controls.Add(this.cmbDialInput);
            this.groupBox_0.Controls.Add(this.ctrlAdvTableDial);
            this.groupBox_0.Location = new System.Drawing.Point(6, 441);
            this.groupBox_0.Name = "groupBox_0";
            this.groupBox_0.Size = new System.Drawing.Size(335, 173);
            this.groupBox_0.TabIndex = 10;
            this.groupBox_0.TabStop = false;
            this.groupBox_0.Text = "Target Boost Dial Adjustment";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(287, 56);
            this.label13.TabIndex = 4;
            this.label13.Text = "Note: -Use a pot meter 10k ohm connect to 5V/Gnd.\r\n          Output to one of the" +
    " input pins\r\n          -Use Dial for quick adjustment to your \r\n          target" +
    " boost(-/+)\r\n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 14);
            this.label14.TabIndex = 2;
            this.label14.Text = "Dial Input:";
            // 
            // cmbDialInput
            // 
            this.cmbDialInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDialInput.Enabled = false;
            this.cmbDialInput.FormattingEnabled = true;
            this.cmbDialInput.Items.AddRange(new object[] {
            "ELD",
            "EGR",
            "B6"});
            this.cmbDialInput.Location = new System.Drawing.Point(116, 74);
            this.cmbDialInput.Name = "cmbDialInput";
            this.cmbDialInput.Size = new System.Drawing.Size(121, 22);
            this.cmbDialInput.TabIndex = 1;
            // 
            // ctrlAdvTableDial
            // 
            this.ctrlAdvTableDial.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableDial.Location = new System.Drawing.Point(59, 18);
            this.ctrlAdvTableDial.Name = "ctrlAdvTableDial";
            this.ctrlAdvTableDial.Size = new System.Drawing.Size(232, 50);
            this.ctrlAdvTableDial.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.rbNC);
            this.groupBox6.Controls.Add(this.rbNO);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.cmbHz);
            this.groupBox6.Controls.Add(this.txtbMinDuty);
            this.groupBox6.Controls.Add(this.txtbMaxDuty);
            this.groupBox6.Location = new System.Drawing.Point(6, 230);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(335, 127);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Solenoid Settings";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(136, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 14);
            this.label12.TabIndex = 59;
            this.label12.Text = "100% DC Max; 0% DC Min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 14);
            this.label11.TabIndex = 36;
            this.label11.Text = "0% DC Max; 100% DC Min (GM)";
            // 
            // rbNC
            // 
            this.rbNC.AutoSize = true;
            this.rbNC.Location = new System.Drawing.Point(14, 75);
            this.rbNC.Name = "rbNC";
            this.rbNC.Size = new System.Drawing.Size(113, 18);
            this.rbNC.TabIndex = 10;
            this.rbNC.TabStop = true;
            this.rbNC.Text = "Normally Closed";
            this.rbNC.UseVisualStyleBackColor = true;
            this.rbNC.CheckedChanged += new System.EventHandler(this.rbNC_CheckedChanged);
            // 
            // rbNO
            // 
            this.rbNO.AutoSize = true;
            this.rbNO.Location = new System.Drawing.Point(14, 98);
            this.rbNO.Name = "rbNO";
            this.rbNO.Size = new System.Drawing.Size(105, 18);
            this.rbNO.TabIndex = 9;
            this.rbNO.TabStop = true;
            this.rbNO.Text = "Normally Open";
            this.rbNO.UseVisualStyleBackColor = true;
            this.rbNO.CheckedChanged += new System.EventHandler(this.rbNC_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 14);
            this.label5.TabIndex = 56;
            this.label5.Text = "Frequency:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 14);
            this.label22.TabIndex = 52;
            this.label22.Text = "Min/Max Duty:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 14);
            this.label10.TabIndex = 58;
            this.label10.Text = "Hz";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(257, 49);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(14, 14);
            this.label23.TabIndex = 53;
            this.label23.Text = "%";
            // 
            // cmbHz
            // 
            this.cmbHz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHz.Enabled = false;
            this.cmbHz.FormattingEnabled = true;
            this.cmbHz.Items.AddRange(new object[] {
            "8",
            "15",
            "20",
            "25",
            "31",
            "40"});
            this.cmbHz.Location = new System.Drawing.Point(116, 16);
            this.cmbHz.Name = "cmbHz";
            this.cmbHz.Size = new System.Drawing.Size(63, 22);
            this.cmbHz.TabIndex = 49;
            this.cmbHz.SelectedIndexChanged += new System.EventHandler(this.cmbHz_SelectedIndexChanged);
            // 
            // txtbMinDuty
            // 
            this.txtbMinDuty.Location = new System.Drawing.Point(116, 45);
            this.txtbMinDuty.Name = "txtbMinDuty";
            this.txtbMinDuty.Size = new System.Drawing.Size(63, 20);
            this.txtbMinDuty.TabIndex = 50;
            this.txtbMinDuty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMaxDuty_KeyPress);
            this.txtbMinDuty.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMaxDuty_Validating);
            this.txtbMinDuty.Validated += new System.EventHandler(this.txtbMaxDuty_Validated);
            // 
            // txtbMaxDuty
            // 
            this.txtbMaxDuty.Location = new System.Drawing.Point(185, 45);
            this.txtbMaxDuty.Name = "txtbMaxDuty";
            this.txtbMaxDuty.Size = new System.Drawing.Size(63, 20);
            this.txtbMaxDuty.TabIndex = 51;
            this.txtbMaxDuty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMaxDuty_KeyPress);
            this.txtbMaxDuty.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMaxDuty_Validating);
            this.txtbMaxDuty.Validated += new System.EventHandler(this.txtbMaxDuty_Validated);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ctrlAdvTableTps);
            this.groupBox7.Location = new System.Drawing.Point(6, 363);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(335, 72);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Target Boost TPS mutliplier";
            // 
            // ctrlAdvTableTps
            // 
            this.ctrlAdvTableTps.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlAdvTableTps.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableTps.Location = new System.Drawing.Point(77, 19);
            this.ctrlAdvTableTps.Name = "ctrlAdvTableTps";
            this.ctrlAdvTableTps.Size = new System.Drawing.Size(183, 46);
            this.ctrlAdvTableTps.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Location = new System.Drawing.Point(6, 43);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(335, 86);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Target Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Target Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fixed Duty",
            "Gear Based",
            "RPM Based"});
            this.comboBox1.Location = new System.Drawing.Point(116, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 22);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label25);
            this.groupBox9.Controls.Add(this.txtbFixedDutyLo);
            this.groupBox9.Location = new System.Drawing.Point(5, 45);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(324, 39);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Fixed Duty Cycle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 14);
            this.label8.TabIndex = 27;
            this.label8.Text = "DC %";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 14);
            this.label25.TabIndex = 26;
            this.label25.Text = "Duty Cycle:";
            // 
            // txtbFixedDutyLo
            // 
            this.txtbFixedDutyLo.Location = new System.Drawing.Point(111, 13);
            this.txtbFixedDutyLo.Name = "txtbFixedDutyLo";
            this.txtbFixedDutyLo.Size = new System.Drawing.Size(65, 20);
            this.txtbFixedDutyLo.TabIndex = 1;
            this.txtbFixedDutyLo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDeadBand_KeyPress);
            this.txtbFixedDutyLo.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDeadBand_Validating);
            this.txtbFixedDutyLo.Validated += new System.EventHandler(this.txtbDeadBand_Leave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.ctrlMapWGact);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtbFspoolDuty);
            this.groupBox4.Controls.Add(this.ctrlMapEbcAct);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(6, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(335, 97);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Activations Points";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(187, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 14);
            this.label18.TabIndex = 60;
            this.label18.Text = "DC %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enable Above:";
            // 
            // ctrlMapWGact
            // 
            this.ctrlMapWGact.Location = new System.Drawing.Point(116, 68);
            this.ctrlMapWGact.Name = "ctrlMapWGact";
            this.ctrlMapWGact.rawValue = ((byte)(0));
            this.ctrlMapWGact.Size = new System.Drawing.Size(154, 23);
            this.ctrlMapWGact.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Wastegate:";
            // 
            // txtbFspoolDuty
            // 
            this.txtbFspoolDuty.Location = new System.Drawing.Point(116, 42);
            this.txtbFspoolDuty.Name = "txtbFspoolDuty";
            this.txtbFspoolDuty.Size = new System.Drawing.Size(65, 20);
            this.txtbFspoolDuty.TabIndex = 1;
            this.txtbFspoolDuty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDeadBand_KeyPress);
            this.txtbFspoolDuty.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDeadBand_Validating);
            this.txtbFspoolDuty.Validated += new System.EventHandler(this.txtbDeadBand_Leave);
            // 
            // ctrlMapEbcAct
            // 
            this.ctrlMapEbcAct.Location = new System.Drawing.Point(116, 15);
            this.ctrlMapEbcAct.Name = "ctrlMapEbcAct";
            this.ctrlMapEbcAct.rawValue = ((byte)(0));
            this.ctrlMapEbcAct.Size = new System.Drawing.Size(154, 23);
            this.ctrlMapEbcAct.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fastspool Duty:";
            // 
            // chkDisbleMilLean
            // 
            this.chkDisbleMilLean.AutoSize = true;
            this.chkDisbleMilLean.Enabled = false;
            this.chkDisbleMilLean.Location = new System.Drawing.Point(20, 19);
            this.chkDisbleMilLean.Name = "chkDisbleMilLean";
            this.chkDisbleMilLean.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDisbleMilLean.Size = new System.Drawing.Size(224, 18);
            this.chkDisbleMilLean.TabIndex = 59;
            this.chkDisbleMilLean.Text = "Disable PWM if DTC or lean condition";
            this.chkDisbleMilLean.UseVisualStyleBackColor = true;
            this.chkDisbleMilLean.CheckedChanged += new System.EventHandler(this.chkDisbleMilLean_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.ctrlInputSelectorActivation);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.ctrlInputSelectorHiLo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input/Output";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 14);
            this.label19.TabIndex = 9;
            this.label19.Text = "PWM Input :";
            // 
            // ctrlInputSelectorActivation
            // 
            this.ctrlInputSelectorActivation.Location = new System.Drawing.Point(106, 15);
            this.ctrlInputSelectorActivation.Name = "ctrlInputSelectorActivation";
            this.ctrlInputSelectorActivation.Size = new System.Drawing.Size(218, 50);
            this.ctrlInputSelectorActivation.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 70);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 14);
            this.label27.TabIndex = 10;
            this.label27.Text = "Low/Hi Input:";
            // 
            // ctrlInputSelectorHiLo
            // 
            this.ctrlInputSelectorHiLo.Location = new System.Drawing.Point(106, 66);
            this.ctrlInputSelectorHiLo.Name = "ctrlInputSelectorHiLo";
            this.ctrlInputSelectorHiLo.Size = new System.Drawing.Size(218, 50);
            this.ctrlInputSelectorHiLo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "PWM Output:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.DropDownWidth = 300;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "A11-EGR",
            "A17-AT Lockup/IAB - P72 only ecu with SK5151"});
            this.comboBox2.Location = new System.Drawing.Point(108, 116);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(206, 22);
            this.comboBox2.TabIndex = 19;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 791);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PWM Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 14);
            this.label9.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 427);
            this.panel1.TabIndex = 1;
            // 
            // parmEbcSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmEbcSettings";
            this.Size = new System.Drawing.Size(402, 427);
            this.Load += new System.EventHandler(this.parmEbcSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_0.ResumeLayout(false);
            this.groupBox_0.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_255(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableDial.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableDial.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("EBC dial multiplier");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_270 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 2.55));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0)
            {
                this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_270 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
                this.class18_0.method_149_SetByte(((this.class18_0.class13_u_0.long_270 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
            }
            else
            {
                this.class18_0.method_149_SetByte(((this.class18_0.class13_u_0.long_270 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
                this.class18_0.method_149_SetByte(((this.class18_0.class13_u_0.long_270 + 4L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
            }
        }
        this.class18_0.method_153();
    }

    private void method_10(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("PWM Invert Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_247, byte_0);
            this.class18_0.method_153();
            this.parmEbcSettings_Load(null, null);
        }
    }

    private void method_11(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("PWM Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_246, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_12()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmEbcSettings_Load(null, null);
            this.ctrlAdvTableDial.Invalidate();
            this.ctrlAdvTableTps.Invalidate();
        }
    }

    private void method_15()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("PWM Settings");
            if (comboBox1.SelectedIndex == 0)
            {
                double num = 0.0;
                if (this.txtbFixedDutyLo.Text == num.ToString("0.00"))
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_251, this.class18_0.method_211(1.0));
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_251, this.class18_0.method_211(double.Parse(this.txtbFixedDutyLo.Text)));
                }
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_251, this.class18_0.method_211(0.0));
            }
            if (comboBox1.SelectedIndex != 2)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_275, 0);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_275, 0xff);
            }
            groupBox9.Enabled = false;
            if (comboBox1.SelectedIndex == 0) groupBox9.Enabled = true;
            if (this.class18_0.class13_u_0.long_280 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_276, 0xff);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_254, this.class18_0.method_211(double.Parse(this.txtbFspoolDuty.Text)));
            }
            if (this.class18_0.class13_u_0.long_269 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_269, (byte)this.cmbDialInput.SelectedIndex);
            }
            if (this.class18_0.class13_u_0.long_271 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_271, 0xff);
            }

            //#########

            if (comboBox2.SelectedIndex == 0)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_277, 0);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_277, 0xff);
            }
            if (this.rbNC.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_279, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_279, 0);
            }
            if (this.class18_0.class13_u_0.long_267 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_267, this.class18_0.method_211(double.Parse(this.txtbMaxDuty.Text)));
            }
            if (this.class18_0.class13_u_0.long_267 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_266, this.class18_0.method_211(double.Parse(this.txtbMinDuty.Text)));
            }
            if (this.class18_0.class13_u_0.long_268 != 0L)
            {
                this.class18_0.method_151(this.class18_0.class13_u_0.long_268, this.method_2_2());
            }
            if (this.class18_0.class13_u_0.long_271 != 0L)
            {
                if (this.chkDisbleMilLean.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_271, 0);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_271, 0xff);
            }
            this.class18_0.method_153();
            this.parmEbcSettings_Load(null, null);
        }
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = Math.Round((double)(((double)this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_270 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2))) / 2.55), 0);
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = Math.Round((double)(((double)this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_270 + 2L) + ((dataGridViewCellValueEventArgs_0.ColumnIndex * 2) + 1))) / 128.0), 2).ToString("0.00");
        }
    }

    private void method_3(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("PWM Settings", false);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_255, byte_0);
            this.class18_0.method_153();
            this.parmEbcSettings_Load(null, null);
        }
    }

    private void method_4(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("PWM Settings", false);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_253, byte_0);
            this.class18_0.method_153();
            this.parmEbcSettings_Load(null, null);
        }
    }

    private void method_5(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_255(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableTps.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableTps.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_6(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("EBC tps multiplier");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_265 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_228(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0)
            {
                this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_265 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
                this.class18_0.method_149_SetByte(((this.class18_0.class13_u_0.long_265 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
            }
            else
            {
                this.class18_0.method_149_SetByte(((this.class18_0.class13_u_0.long_265 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
                this.class18_0.method_149_SetByte(((this.class18_0.class13_u_0.long_265 + 4L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128.0));
            }
        }
        this.class18_0.method_153();
    }

    private void method_7(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_198(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_265 + 2L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = Math.Round((double)(((double)this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_265 + 2L) + ((dataGridViewCellValueEventArgs_0.ColumnIndex * 2) + 1))) / 128.0), 2).ToString("0.00");
        }
    }

    private void method_8(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("PWM Hi/Lo Invert Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_249, byte_0);
            this.class18_0.method_153();
            this.parmEbcSettings_Load(null, null);
        }
    }

    private void method_9(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("PWM Hi/Lo Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_248, byte_0);
            this.class18_0.method_153();
        }
    }

    private void parmEbcSettings_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.DutyMode = false;
        if (this.class18_0.method_207(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_251)) != 0.0)
        {
            comboBox1.SelectedIndex = 0;
            DutyMode = true;
        }
        if (!DutyMode)
        {
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_275) == 0)
                comboBox1.SelectedIndex = 1;
            else
                comboBox1.SelectedIndex = 2;
        }
        groupBox9.Enabled = false;
        if (comboBox1.SelectedIndex == 0) groupBox9.Enabled = true;

        this.cmbDialInput.Enabled = this.class18_0.class13_u_0.long_269 != 0L;
        this.groupBox_0.Enabled = this.class18_0.class13_u_0.long_269 != 0L;
        if (this.class18_0.class13_u_0.long_269 != 0L)
        {
            this.ctrlAdvTableDial.method_Load();
            try
            {
                this.cmbDialInput.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_269);
            }
            catch (Exception)
            {
                this.cmbDialInput.SelectedIndex = 0;
            }
        }

        this.txtbFspoolDuty.Text = this.class18_0.method_207(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_254)).ToString("0.00");
        this.txtbFixedDutyLo.Text = this.class18_0.method_207(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_251)).ToString("0.00");
        this.ctrlMapEbcAct.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_253);
        this.ctrlMapWGact.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_255);
        this.ctrlInputSelectorActivation.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_247) == 0xff);
        this.ctrlInputSelectorActivation.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_246));
        this.ctrlInputSelectorHiLo.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_249) == 0xff);
        this.ctrlInputSelectorHiLo.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_248));

        //##################

        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_277) == 0)
        {
            comboBox2.SelectedIndex = 0;
        }
        else
        {
            comboBox2.SelectedIndex = 1;
        }
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_279) == 0)
        {
            this.rbNC.Checked = false;
            this.rbNO.Checked = true;
        }
        else
        {
            this.rbNC.Checked = true;
            this.rbNO.Checked = false;
        }
        this.txtbMaxDuty.Enabled = this.class18_0.class13_u_0.long_267 != 0L;
        if (this.class18_0.class13_u_0.long_267 != 0L)
        {
            this.txtbMaxDuty.Text = this.class18_0.method_207(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_267)).ToString();
        }
        this.txtbMinDuty.Enabled = this.class18_0.class13_u_0.long_266 != 0L;
        if (this.class18_0.class13_u_0.long_266 != 0L)
        {
            this.txtbMinDuty.Text = this.class18_0.method_207(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_266)).ToString();
        }
        this.cmbHz.Enabled = this.class18_0.class13_u_0.long_268 != 0L;
        if (this.class18_0.class13_u_0.long_268 != 0L)
        {
            this.cmbHz.SelectedIndex = this.method_3_2(this.class18_0.method_152(this.class18_0.class13_u_0.long_268));
        }
        if (this.class18_0.class13_u_0.long_271 != 0L)
        {
            this.chkDisbleMilLean.Enabled = true;
            this.chkDisbleMilLean.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_271) == 0;
        }
        this.bool_0 = false;
    }

    private void txtbDeadBand_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                if (!this.bool_0)
                {
                    this.method_15();
                }
            }
            control.Focus();
        }
    }

    private void txtbDeadBand_Leave(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            if (!this.bool_0)
            {
                this.method_15();
            }
        }
    }

    private void txtbDeadBand_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid Input, Double Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0 && this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_15();
        }
    }
    
    private void cmbHz_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_15();
        }
    }

    private long method_2_2()
    {
        switch (this.cmbHz.SelectedIndex)
        {
            case 0:
                return 610L;

            case 1:
                return 0x145L;

            case 2:
                return 0xf4L;

            case 3:
                return 0xc3L;

            case 4:
                return 0x9eL;

            case 5:
                return 0x7aL;
        }
        return 3L;
    }

    private int method_3_2(long long_0)
    {
        switch (long_0)
        {
            case 0x7aL:
                return 5;

            case 0x9eL:
                return 4;

            case 0xc3L:
                return 3;

            case 0xf4L:
                return 2;

            case 0x145L:
                return 1;

            case 610L:
                return 0;
        }
        return 2;
    }

    private void txtbMaxDuty_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (e.KeyChar == '\r')
        {
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                if (!this.bool_0)
                {
                    this.method_15();
                }
            }
            control.Focus();
        }
    }

    private void txtbMaxDuty_Validated(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_15();
        }
    }

    private void txtbMaxDuty_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
        if (!e.Cancel && ((control.Name == "txtbMinDuty") || (control.Name == "txtbMaxDuty")))
        {
            if (double.Parse(this.txtbMinDuty.Text) >= double.Parse(this.txtbMaxDuty.Text))
            {
                this.errorProvider_0.SetError(control, "Please check min/max duty setting!");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider_0.SetError(control, "");
            }
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_15();
        }
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_15();
        }
    }

    private void chkDisbleMilLean_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0 && this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_15();
        }
    }

    private void rbNC_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_15();
        }
    }
}

