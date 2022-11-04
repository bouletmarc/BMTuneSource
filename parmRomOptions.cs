using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmRomOptions : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private GroupBox groupBox1;
    private Label label8;
    private Label label6;
    private Label label5;
    private Label label2;
    private Label label3;
    private Label lblECT;
    private Label label4;
    private CheckBox chkECT;
    private Label lblIAT;
    private Label label1;
    private CheckBox chkDisableCloseloop;
    private CheckBox chkO2heaterDisable;
    private CheckBox chkVtp;
    private CheckBox chkErrorChk;
    private CheckBox chkAutoTranny;
    private CheckBox chkIAT;
    private CheckBox chkIacvError;
    private CheckBox chkVSS;
    private Label label7;
    private CheckBox chkPCS;
    private CheckBox chkInv;
    private CheckBox chkIgnCorr;
    private CheckBox checkBox_0;
    private CheckBox chkVeDisable;
    private CheckBox chkInjecTest;
    private CheckBox chkBaro;
    private CheckBox chkEld;
    private CheckBox chkKnock;
    private Panel panel1;
    private CheckBox chkAtlCtrl;
    private NumericUpDown txtbIgnMbar;
    private NumericUpDown textBox1;
    private NumericUpDown txtIAT;
    private NumericUpDown txtECT;
    private CheckBox chkOpenloopStock;
    private CheckBox chkDebug;
    private GroupBox groupBox2;
    private CheckBox chk_DisableTPS;
    private CheckBox chk_CYP;
    private CheckBox chk_TDC;
    private CheckBox chk_Crank;
    private CheckBox chk_Traction;
    private CheckBox chk_AutoSignalB;
    private Label label10;
    private Label label9;
    private Label label11;
    private IContainer components;

    internal parmRomOptions(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();
        
        this.chkECT.Enabled= true;
        this.chkIAT.Enabled= true;
        this.chkVSS.Enabled= true;
        this.chkDebug.Enabled= true;
        groupBox2.Enabled= true;

        if (this.class18_0.RomVersion < 111) chk_DisableTPS.Enabled = false;

        DisableExtra();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    public void DisableExtra()
    {
        //Disable under rom version
        label4.Visible = true;
        label1.Visible = true;
        lblECT.Visible = true;
        lblIAT.Visible = true;
        txtECT.Visible = true;
        txtIAT.Visible = true;

        //label2.Visible = true;
        //label3.Visible = true;
        //textBox1.Visible = true;
        label2.Visible = false;
        label3.Visible = false;
        textBox1.Visible = false;

        label5.Visible = false;
        label6.Visible = false;
        label8.Visible = false;

        //COP
        //if (this.class18_0.RomVersion <= 103) groupBox2.Visible = false;
        //else groupBox2.Visible = true;
    }

    private void chkKnock_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void chkVeDisable_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            if (this.chkVeDisable.Checked)
            {
                if (MessageBox.Show(Form.ActiveForm, "After you disable VE you will have to to retune your car. You won't be able to turn it back on." + Environment.NewLine + "Are you sure you want to disable VE?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.method_1();
                }
                else
                {
                    this.chkVeDisable.Checked = true;
                }
            }
            else
            {
                this.method_1();
            }
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
            this.chkKnock = new System.Windows.Forms.CheckBox();
            this.chkEld = new System.Windows.Forms.CheckBox();
            this.chkBaro = new System.Windows.Forms.CheckBox();
            this.chkInjecTest = new System.Windows.Forms.CheckBox();
            this.chkVeDisable = new System.Windows.Forms.CheckBox();
            this.checkBox_0 = new System.Windows.Forms.CheckBox();
            this.chkIgnCorr = new System.Windows.Forms.CheckBox();
            this.chkInv = new System.Windows.Forms.CheckBox();
            this.chkPCS = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkVSS = new System.Windows.Forms.CheckBox();
            this.chkIacvError = new System.Windows.Forms.CheckBox();
            this.chkIAT = new System.Windows.Forms.CheckBox();
            this.chkAutoTranny = new System.Windows.Forms.CheckBox();
            this.chkErrorChk = new System.Windows.Forms.CheckBox();
            this.chkVtp = new System.Windows.Forms.CheckBox();
            this.chkO2heaterDisable = new System.Windows.Forms.CheckBox();
            this.chkDisableCloseloop = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIAT = new System.Windows.Forms.Label();
            this.chkECT = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblECT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_TDC = new System.Windows.Forms.CheckBox();
            this.chk_AutoSignalB = new System.Windows.Forms.CheckBox();
            this.chk_Traction = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chk_CYP = new System.Windows.Forms.CheckBox();
            this.chk_Crank = new System.Windows.Forms.CheckBox();
            this.chk_DisableTPS = new System.Windows.Forms.CheckBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.NumericUpDown();
            this.txtIAT = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtECT = new System.Windows.Forms.NumericUpDown();
            this.chkOpenloopStock = new System.Windows.Forms.CheckBox();
            this.txtbIgnMbar = new System.Windows.Forms.NumericUpDown();
            this.chkAtlCtrl = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtECT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIgnMbar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // chkKnock
            // 
            this.chkKnock.AutoSize = true;
            this.chkKnock.Location = new System.Drawing.Point(6, 163);
            this.chkKnock.Name = "chkKnock";
            this.chkKnock.Size = new System.Drawing.Size(207, 18);
            this.chkKnock.TabIndex = 0;
            this.chkKnock.Text = "Disable Code #23 (Knock Sensor)";
            this.chkKnock.UseVisualStyleBackColor = true;
            this.chkKnock.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkEld
            // 
            this.chkEld.AutoSize = true;
            this.chkEld.Location = new System.Drawing.Point(6, 91);
            this.chkEld.Name = "chkEld";
            this.chkEld.Size = new System.Drawing.Size(152, 18);
            this.chkEld.TabIndex = 1;
            this.chkEld.Text = "Disable Code #20 (ELD)";
            this.chkEld.UseVisualStyleBackColor = true;
            this.chkEld.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkBaro
            // 
            this.chkBaro.AutoSize = true;
            this.chkBaro.Location = new System.Drawing.Point(6, 19);
            this.chkBaro.Name = "chkBaro";
            this.chkBaro.Size = new System.Drawing.Size(175, 18);
            this.chkBaro.TabIndex = 2;
            this.chkBaro.Text = "Disable Code #13 (PA/Baro)";
            this.chkBaro.UseVisualStyleBackColor = true;
            this.chkBaro.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkInjecTest
            // 
            this.chkInjecTest.AutoSize = true;
            this.chkInjecTest.Location = new System.Drawing.Point(6, 67);
            this.chkInjecTest.Name = "chkInjecTest";
            this.chkInjecTest.Size = new System.Drawing.Size(201, 18);
            this.chkInjecTest.TabIndex = 3;
            this.chkInjecTest.Text = "Disable Code #16 (Injector Test)";
            this.chkInjecTest.UseVisualStyleBackColor = true;
            this.chkInjecTest.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkVeDisable
            // 
            this.chkVeDisable.AutoSize = true;
            this.chkVeDisable.Location = new System.Drawing.Point(6, 331);
            this.chkVeDisable.Name = "chkVeDisable";
            this.chkVeDisable.Size = new System.Drawing.Size(143, 18);
            this.chkVeDisable.TabIndex = 10;
            this.chkVeDisable.Text = "Disable VE Correction";
            this.chkVeDisable.UseVisualStyleBackColor = true;
            this.chkVeDisable.CheckedChanged += new System.EventHandler(this.chkVeDisable_CheckedChanged);
            // 
            // checkBox_0
            // 
            this.checkBox_0.AutoSize = true;
            this.checkBox_0.Location = new System.Drawing.Point(6, 379);
            this.checkBox_0.Name = "checkBox_0";
            this.checkBox_0.Size = new System.Drawing.Size(136, 18);
            this.checkBox_0.TabIndex = 13;
            this.checkBox_0.Text = "Disable Starter Input";
            this.checkBox_0.UseVisualStyleBackColor = true;
            this.checkBox_0.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkIgnCorr
            // 
            this.chkIgnCorr.AutoSize = true;
            this.chkIgnCorr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIgnCorr.Location = new System.Drawing.Point(6, 355);
            this.chkIgnCorr.Name = "chkIgnCorr";
            this.chkIgnCorr.Size = new System.Drawing.Size(185, 18);
            this.chkIgnCorr.TabIndex = 15;
            this.chkIgnCorr.Text = "Disable Ign Correction Above";
            this.chkIgnCorr.UseVisualStyleBackColor = true;
            this.chkIgnCorr.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkInv
            // 
            this.chkInv.AutoSize = true;
            this.chkInv.Location = new System.Drawing.Point(6, 451);
            this.chkInv.Name = "chkInv";
            this.chkInv.Size = new System.Drawing.Size(169, 18);
            this.chkInv.TabIndex = 22;
            this.chkInv.Text = "Invert Purge Valve (obd2b)";
            this.chkInv.UseVisualStyleBackColor = true;
            this.chkInv.CheckedChanged += new System.EventHandler(this.chkPCS_CheckedChanged);
            // 
            // chkPCS
            // 
            this.chkPCS.AutoSize = true;
            this.chkPCS.Location = new System.Drawing.Point(6, 427);
            this.chkPCS.Name = "chkPCS";
            this.chkPCS.Size = new System.Drawing.Size(133, 18);
            this.chkPCS.TabIndex = 21;
            this.chkPCS.Text = "Disable Purge Valve";
            this.chkPCS.UseVisualStyleBackColor = true;
            this.chkPCS.CheckedChanged += new System.EventHandler(this.chkPCS_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "mBar";
            // 
            // chkVSS
            // 
            this.chkVSS.AutoSize = true;
            this.chkVSS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkVSS.Location = new System.Drawing.Point(4, 163);
            this.chkVSS.Name = "chkVSS";
            this.chkVSS.Size = new System.Drawing.Size(252, 18);
            this.chkVSS.TabIndex = 26;
            this.chkVSS.Text = "Disable Code #17 (Vehicle Speed Sensor)";
            this.chkVSS.UseVisualStyleBackColor = true;
            this.chkVSS.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkIacvError
            // 
            this.chkIacvError.AutoSize = true;
            this.chkIacvError.Location = new System.Drawing.Point(6, 43);
            this.chkIacvError.Name = "chkIacvError";
            this.chkIacvError.Size = new System.Drawing.Size(245, 18);
            this.chkIacvError.TabIndex = 27;
            this.chkIacvError.Text = "Disable Code #14 (Idle Air Control Valve)";
            this.chkIacvError.UseVisualStyleBackColor = true;
            this.chkIacvError.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkIAT
            // 
            this.chkIAT.AutoSize = true;
            this.chkIAT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIAT.Location = new System.Drawing.Point(4, 139);
            this.chkIAT.Name = "chkIAT";
            this.chkIAT.Size = new System.Drawing.Size(215, 18);
            this.chkIAT.TabIndex = 25;
            this.chkIAT.Text = "Disable Code #10 (Intake Air Temp)";
            this.chkIAT.UseVisualStyleBackColor = true;
            this.chkIAT.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkAutoTranny
            // 
            this.chkAutoTranny.AutoSize = true;
            this.chkAutoTranny.Location = new System.Drawing.Point(6, 307);
            this.chkAutoTranny.Name = "chkAutoTranny";
            this.chkAutoTranny.Size = new System.Drawing.Size(132, 18);
            this.chkAutoTranny.TabIndex = 28;
            this.chkAutoTranny.Text = "Disable Auto tranny";
            this.chkAutoTranny.UseVisualStyleBackColor = true;
            this.chkAutoTranny.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkErrorChk
            // 
            this.chkErrorChk.AutoSize = true;
            this.chkErrorChk.Location = new System.Drawing.Point(6, 115);
            this.chkErrorChk.Name = "chkErrorChk";
            this.chkErrorChk.Size = new System.Drawing.Size(264, 18);
            this.chkErrorChk.TabIndex = 29;
            this.chkErrorChk.Text = "Disable Code #21 (Vtec Solenoid Feedback)";
            this.chkErrorChk.UseVisualStyleBackColor = true;
            this.chkErrorChk.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkVtp
            // 
            this.chkVtp.AutoSize = true;
            this.chkVtp.Location = new System.Drawing.Point(6, 139);
            this.chkVtp.Name = "chkVtp";
            this.chkVtp.Size = new System.Drawing.Size(247, 18);
            this.chkVtp.TabIndex = 30;
            this.chkVtp.Text = "Disable Code #22 (Vtec Pressure Switch)";
            this.chkVtp.UseVisualStyleBackColor = true;
            this.chkVtp.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkO2heaterDisable
            // 
            this.chkO2heaterDisable.AutoSize = true;
            this.chkO2heaterDisable.Location = new System.Drawing.Point(6, 235);
            this.chkO2heaterDisable.Name = "chkO2heaterDisable";
            this.chkO2heaterDisable.Size = new System.Drawing.Size(187, 18);
            this.chkO2heaterDisable.TabIndex = 31;
            this.chkO2heaterDisable.Text = "Disable Code #41 (O2 Heater)";
            this.chkO2heaterDisable.UseVisualStyleBackColor = true;
            this.chkO2heaterDisable.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkDisableCloseloop
            // 
            this.chkDisableCloseloop.AutoSize = true;
            this.chkDisableCloseloop.Location = new System.Drawing.Point(6, 259);
            this.chkDisableCloseloop.Name = "chkDisableCloseloop";
            this.chkDisableCloseloop.Size = new System.Drawing.Size(124, 18);
            this.chkDisableCloseloop.TabIndex = 32;
            this.chkDisableCloseloop.Text = "Disable Closeloop";
            this.chkDisableCloseloop.UseVisualStyleBackColor = true;
            this.chkDisableCloseloop.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 33;
            this.label1.Text = "Value:";
            // 
            // lblIAT
            // 
            this.lblIAT.AutoSize = true;
            this.lblIAT.Location = new System.Drawing.Point(360, 119);
            this.lblIAT.Name = "lblIAT";
            this.lblIAT.Size = new System.Drawing.Size(15, 14);
            this.lblIAT.TabIndex = 34;
            this.lblIAT.Text = "C";
            // 
            // chkECT
            // 
            this.chkECT.AutoSize = true;
            this.chkECT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkECT.Location = new System.Drawing.Point(4, 45);
            this.chkECT.Name = "chkECT";
            this.chkECT.Size = new System.Drawing.Size(240, 18);
            this.chkECT.TabIndex = 36;
            this.chkECT.Text = "Disable Code #6 (Engine Coolant Temp)";
            this.chkECT.UseVisualStyleBackColor = true;
            this.chkECT.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "Value:";
            // 
            // lblECT
            // 
            this.lblECT.AutoSize = true;
            this.lblECT.Location = new System.Drawing.Point(360, 46);
            this.lblECT.Name = "lblECT";
            this.lblECT.Size = new System.Drawing.Size(15, 14);
            this.lblECT.TabIndex = 38;
            this.lblECT.Text = "C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 40;
            this.label3.Text = "Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "km/h";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(278, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 14);
            this.label5.TabIndex = 43;
            this.label5.Text = "NOT STABLE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(278, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 44;
            this.label6.Text = "NOT STABLE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_AutoSignalB);
            this.groupBox1.Controls.Add(this.chk_Traction);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkOpenloopStock);
            this.groupBox1.Controls.Add(this.txtbIgnMbar);
            this.groupBox1.Controls.Add(this.chkAtlCtrl);
            this.groupBox1.Controls.Add(this.chkDisableCloseloop);
            this.groupBox1.Controls.Add(this.chkO2heaterDisable);
            this.groupBox1.Controls.Add(this.chkVtp);
            this.groupBox1.Controls.Add(this.chkErrorChk);
            this.groupBox1.Controls.Add(this.chkAutoTranny);
            this.groupBox1.Controls.Add(this.chkIacvError);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkPCS);
            this.groupBox1.Controls.Add(this.chkInv);
            this.groupBox1.Controls.Add(this.chkIgnCorr);
            this.groupBox1.Controls.Add(this.checkBox_0);
            this.groupBox1.Controls.Add(this.chkVeDisable);
            this.groupBox1.Controls.Add(this.chkInjecTest);
            this.groupBox1.Controls.Add(this.chkBaro);
            this.groupBox1.Controls.Add(this.chkEld);
            this.groupBox1.Controls.Add(this.chkKnock);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 691);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor/Hardware Options:";
            // 
            // chk_TDC
            // 
            this.chk_TDC.AutoSize = true;
            this.chk_TDC.Location = new System.Drawing.Point(4, 91);
            this.chk_TDC.Name = "chk_TDC";
            this.chk_TDC.Size = new System.Drawing.Size(249, 18);
            this.chk_TDC.TabIndex = 55;
            this.chk_TDC.Text = "Disable Code #8 (TDC - Top Dead Center)";
            this.chk_TDC.UseVisualStyleBackColor = true;
            this.chk_TDC.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chk_AutoSignalB
            // 
            this.chk_AutoSignalB.AutoSize = true;
            this.chk_AutoSignalB.Location = new System.Drawing.Point(6, 187);
            this.chk_AutoSignalB.Name = "chk_AutoSignalB";
            this.chk_AutoSignalB.Size = new System.Drawing.Size(306, 18);
            this.chk_AutoSignalB.TabIndex = 58;
            this.chk_AutoSignalB.Text = "Disable Code #31 (Automatic Transmission B Signal)";
            this.chk_AutoSignalB.UseVisualStyleBackColor = true;
            this.chk_AutoSignalB.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chk_Traction
            // 
            this.chk_Traction.AutoSize = true;
            this.chk_Traction.Location = new System.Drawing.Point(6, 211);
            this.chk_Traction.Name = "chk_Traction";
            this.chk_Traction.Size = new System.Drawing.Size(220, 18);
            this.chk_Traction.TabIndex = 57;
            this.chk_Traction.Text = "Disable Code #36 (Traction Control)";
            this.chk_Traction.UseVisualStyleBackColor = true;
            this.chk_Traction.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.chk_TDC);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.chk_CYP);
            this.groupBox2.Controls.Add(this.chk_Crank);
            this.groupBox2.Controls.Add(this.chk_DisableTPS);
            this.groupBox2.Controls.Add(this.chkECT);
            this.groupBox2.Controls.Add(this.chkDebug);
            this.groupBox2.Controls.Add(this.chkIAT);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblIAT);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtIAT);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblECT);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtECT);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkVSS);
            this.groupBox2.Location = new System.Drawing.Point(2, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 212);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Important/Critical Sensors";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(275, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 14);
            this.label10.TabIndex = 58;
            this.label10.Text = "*EngineSim Use only*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(275, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 14);
            this.label9.TabIndex = 57;
            this.label9.Text = "*EngineSim Use only*";
            // 
            // chk_CYP
            // 
            this.chk_CYP.AutoSize = true;
            this.chk_CYP.Location = new System.Drawing.Point(4, 115);
            this.chk_CYP.Name = "chk_CYP";
            this.chk_CYP.Size = new System.Drawing.Size(271, 18);
            this.chk_CYP.TabIndex = 54;
            this.chk_CYP.Text = "Disable Code #9 (CYP - Cylinder/Cam Sensor)";
            this.chk_CYP.UseVisualStyleBackColor = true;
            this.chk_CYP.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chk_Crank
            // 
            this.chk_Crank.AutoSize = true;
            this.chk_Crank.Location = new System.Drawing.Point(4, 21);
            this.chk_Crank.Name = "chk_Crank";
            this.chk_Crank.Size = new System.Drawing.Size(273, 18);
            this.chk_Crank.TabIndex = 56;
            this.chk_Crank.Text = "Disable Code #4 (CKP - Crank Position Sensor)";
            this.chk_Crank.UseVisualStyleBackColor = true;
            this.chk_Crank.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chk_DisableTPS
            // 
            this.chk_DisableTPS.AutoSize = true;
            this.chk_DisableTPS.Location = new System.Drawing.Point(4, 69);
            this.chk_DisableTPS.Name = "chk_DisableTPS";
            this.chk_DisableTPS.Size = new System.Drawing.Size(255, 18);
            this.chk_DisableTPS.TabIndex = 53;
            this.chk_DisableTPS.Text = "Disable Code #7 (Throttle Position Sensor)";
            this.chk_DisableTPS.UseVisualStyleBackColor = true;
            this.chk_DisableTPS.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(4, 187);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(183, 18);
            this.chkDebug.TabIndex = 52;
            this.chkDebug.Text = "Enable Baserom Debug Mode";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(303, 163);
            this.textBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 49;
            this.textBox1.Click += new System.EventHandler(this.txtbIgnMbar_Validated);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIgnMbar_KeyPress);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIgnMbar_Validating);
            this.textBox1.Validated += new System.EventHandler(this.txtbIgnMbar_Validated);
            // 
            // txtIAT
            // 
            this.txtIAT.Location = new System.Drawing.Point(303, 138);
            this.txtIAT.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.txtIAT.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.txtIAT.Name = "txtIAT";
            this.txtIAT.Size = new System.Drawing.Size(50, 20);
            this.txtIAT.TabIndex = 48;
            this.txtIAT.Click += new System.EventHandler(this.txtbIgnMbar_Validated);
            this.txtIAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIgnMbar_KeyPress);
            this.txtIAT.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIgnMbar_Validating);
            this.txtIAT.Validated += new System.EventHandler(this.txtbIgnMbar_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(278, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 14);
            this.label8.TabIndex = 45;
            this.label8.Text = "NOT STABLE";
            // 
            // txtECT
            // 
            this.txtECT.Location = new System.Drawing.Point(303, 43);
            this.txtECT.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.txtECT.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.txtECT.Name = "txtECT";
            this.txtECT.Size = new System.Drawing.Size(50, 20);
            this.txtECT.TabIndex = 47;
            this.txtECT.Click += new System.EventHandler(this.txtbIgnMbar_Validated);
            this.txtECT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIgnMbar_KeyPress);
            this.txtECT.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIgnMbar_Validating);
            this.txtECT.Validated += new System.EventHandler(this.txtbIgnMbar_Validated);
            // 
            // chkOpenloopStock
            // 
            this.chkOpenloopStock.AutoSize = true;
            this.chkOpenloopStock.Location = new System.Drawing.Point(6, 283);
            this.chkOpenloopStock.Name = "chkOpenloopStock";
            this.chkOpenloopStock.Size = new System.Drawing.Size(250, 18);
            this.chkOpenloopStock.TabIndex = 51;
            this.chkOpenloopStock.Text = "Disable Closeloop + VE correction (Stock)";
            this.chkOpenloopStock.UseVisualStyleBackColor = true;
            this.chkOpenloopStock.CheckedChanged += new System.EventHandler(this.chkKnock_CheckedChanged);
            // 
            // txtbIgnMbar
            // 
            this.txtbIgnMbar.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtbIgnMbar.Location = new System.Drawing.Point(192, 353);
            this.txtbIgnMbar.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbIgnMbar.Name = "txtbIgnMbar";
            this.txtbIgnMbar.Size = new System.Drawing.Size(50, 20);
            this.txtbIgnMbar.TabIndex = 50;
            this.txtbIgnMbar.Click += new System.EventHandler(this.txtbIgnMbar_Validated);
            this.txtbIgnMbar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbIgnMbar_KeyPress);
            this.txtbIgnMbar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIgnMbar_Validating);
            this.txtbIgnMbar.Validated += new System.EventHandler(this.txtbIgnMbar_Validated);
            // 
            // chkAtlCtrl
            // 
            this.chkAtlCtrl.AutoSize = true;
            this.chkAtlCtrl.Location = new System.Drawing.Point(6, 403);
            this.chkAtlCtrl.Name = "chkAtlCtrl";
            this.chkAtlCtrl.Size = new System.Drawing.Size(161, 18);
            this.chkAtlCtrl.TabIndex = 46;
            this.chkAtlCtrl.Text = "Disable Altenator Control";
            this.chkAtlCtrl.UseVisualStyleBackColor = true;
            this.chkAtlCtrl.CheckedChanged += new System.EventHandler(this.chkAtlCtrl_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 526);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(275, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 14);
            this.label11.TabIndex = 59;
            this.label11.Text = "*EngineSim Use only*";
            // 
            // parmRomOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmRomOptions";
            this.Size = new System.Drawing.Size(460, 526);
            this.Load += new System.EventHandler(this.parmRomOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtECT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIgnMbar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmRomOptions_Load(null, null);
        }
    }

    private void method_1()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Options");
            if (this.chkKnock.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_47, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_47, 0xff);

            if (this.chkEld.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_48, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_48, 0xff);

            if (this.chkBaro.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_50, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_50, 0xff);

            if (this.chkInjecTest.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_51, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_51, 0);

            if (this.chkVeDisable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_31, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_31, 0);

            if (this.chkIgnCorr.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_180, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_180, 0);

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_181, this.class18_0.method_226(int.Parse(this.txtbIgnMbar.Text)));

            if (this.checkBox_0.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_46, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_46, 0);

            chkInv.Enabled = !this.chkPCS.Checked;
            if (this.chkPCS.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_103, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_103, 0);
            if (this.chkInv.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_104, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_104, 0);

            if (this.chkIacvError.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_243, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_243, 0);

            if (this.chkVtp.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_224, 0xff); 
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_224, 0);

            if (this.chkErrorChk.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_225, 0xff); 
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_225, 0);

            if (this.chkErrorChk.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_223, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_223, 0);

            if (this.chkDisableCloseloop.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_206, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_206, 0);

            if (this.chkO2heaterDisable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_49, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_49, 0xff);

            if (this.chkAutoTranny.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_66, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_66, 0xff);
            
            if (this.chkAtlCtrl.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_80, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_80, 0);

            if (this.chkOpenloopStock.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_65, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_65, 0xff);

            if (this.chkDebug.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_67, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_67, 0);


            //TPS Error
            if (this.class18_0.RomVersion >= 111)
            {
                if (this.chk_DisableTPS.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_407, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_407, 0);
            }

            //CYP Error
            if (this.chk_CYP.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_408, 0xd8);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_408, 0xe8);
            //if (this.chk_CYP.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_408, 0x00);   //Old BMTune CYP Code
            //else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_408, 0xff);

            //CKP Error
            //if (this.chk_Crank.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_409, 0x00);
            //else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_409, 0xff);

            if (this.chk_Traction.Checked)
            {
                //DD161C      95CB1E
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413, 0x95);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413 + 1, 0xcb);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413 + 2, 0x1d);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413, 0xdd);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413 + 1, 0x16);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413 + 2, 0x1c);
            }

            if (this.chk_AutoSignalB.Checked)
            {
                //DD1614	95CB17
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414, 0x95);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414 + 1, 0xcb);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414 + 2, 0x28);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414, 0xdd);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414 + 1, 0x16);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414 + 2, 0x14);
            }

            //ECT, IAT AND VSS
            if (this.class18_0.RomVersion < 111)
            {
                /*if (!this.chkECT.Checked) this.class18_0.method_149_Bytes_String(this.class18_0.class13_0.long_403, "A30C");
                else this.class18_0.method_149_Bytes_String(this.class18_0.class13_0.long_403, "CB12");
                if (!this.chkIAT.Checked) this.class18_0.method_149_Bytes_String(this.class18_0.class13_0.long_405, "D91306");
                else this.class18_0.method_149_Bytes_String(this.class18_0.class13_0.long_405, "959595");
                if (!this.chkVSS.Checked) this.class18_0.method_149_Bytes_String(this.class18_0.class13_0.long_401, "DB191A");
                else this.class18_0.method_149_Bytes_String(this.class18_0.class13_0.long_401, "CB1B95");*/

                /*if (!this.chkECT.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_403, 0x3b);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_403, 0x0b);
                if (!this.chkIAT.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_405, 0x3d);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_405, 0x0d);
                if (!this.chkVSS.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_401, 0x3c);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_0.long_401, 0x0c);*/

                this.chkECT.Enabled = false;
                this.chkIAT.Enabled = false;
                this.chkVSS.Enabled = false;

                this.txtECT.Enabled = false;
                this.txtIAT.Enabled = false;
                this.textBox1.Enabled = false;
            }
            else
            {
                if (!this.chkECT.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_403, 0x00);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_403, 0xff);
                if (!this.chkIAT.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_405, 0x00);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_405, 0xff);
                if (!this.chkVSS.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_401, 0x00);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_401, 0xff);


                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_404, this.class18_0.method_230(double.Parse(this.txtECT.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_406, this.class18_0.method_230(double.Parse(this.txtIAT.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_400, this.class18_0.method_233(int.Parse(this.textBox1.Text)));

                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_490, this.class18_0.method_230(double.Parse(this.txtECT.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_491, this.class18_0.method_230(double.Parse(this.txtIAT.Text)));
            }


            //COP
            /*if (this.class18_0.RomVersion >= 104)
            {
                if (this.chkCOPSync.Checked) this.class18_0.method_149(this.class18_0.class13_0.long_407, 0xff);
                else this.class18_0.method_149(this.class18_0.class13_0.long_407, 0x00);
                if (this.chkCOPFully.Checked) this.class18_0.method_149(this.class18_0.class13_0.long_408, 0xff);
                else this.class18_0.method_149(this.class18_0.class13_0.long_408, 0x00);
                if (this.chkCOPFire.Checked) this.class18_0.method_149(this.class18_0.class13_0.long_409, 0xff);
                else this.class18_0.method_149(this.class18_0.class13_0.long_409, 0x00);
            }*/

            /*if (this.chkICM.Checked) this.class18_0.method_149(this.class18_0.class13_0.long_74, 0xff);
            else this.class18_0.method_149(this.class18_0.class13_0.long_74, 0);
            if (this.class18_0.method_150(this.class18_0.class13_0.long_71) != 0 && !this.chkICM.Checked)
            {
                MessageBox.Show("ICM Error (CEL #15) MUST be disabled with ignition cut!");
                this.chkICM.Checked = true;
                this.class18_0.method_149(this.class18_0.class13_0.long_74, 0xff);
            }*/

            RemoveSIMCodes();

            this.class18_0.method_153();
            this.parmRomOptions_Load(null, null);
            }
    }

    private void parmRomOptions_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.chkKnock.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_47) == 0;
        this.chkEld.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_48) == 0;
        this.chkBaro.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_50) == 0;
        this.chkInjecTest.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_51) == 0xff;
        this.chkVeDisable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_31) == 0xff;
        this.chkIgnCorr.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_180) == 0xff;
        if (this.chkIgnCorr.Checked)
            txtbIgnMbar.Enabled = true;
        else
            txtbIgnMbar.Enabled = false;
        this.txtbIgnMbar.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_181)).ToString();
        this.checkBox_0.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_46) == 0xff;
        
        this.chkPCS.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_103) == 0xff;
        this.chkInv.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_104) == 0xff;
        chkInv.Enabled = !this.chkPCS.Checked;

        this.chkIacvError.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_243) == 0xff;

        this.chkVtp.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_224) == 0xff;
        this.chkErrorChk.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_223) == 0xff;

        this.chkDisableCloseloop.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_206) == 0xff;
        this.chkOpenloopStock.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_65) == 0;
        this.chkO2heaterDisable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_49) == 0;

        this.chkAutoTranny.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_66) == 0;
        this.chkAtlCtrl.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_80) == 0xff;
        this.chkDebug.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_67) == 0xff;

        //TPS Error
        if (this.class18_0.RomVersion >= 111)
        {
            this.chk_DisableTPS.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_407) == 0xff;
        }

        //CYP/TDC Error
        this.chk_CYP.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_408) == 0xd8;
        //this.chk_CYP.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_408) == 0x00; //Old BMTune CYP Code
        //this.chk_Crank.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_409) == 0x00;
        this.chk_Traction.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_413) == 0x95;
        this.chk_AutoSignalB.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_414) == 0x95;

        //ECT, IAT AND VSS
        if (this.class18_0.RomVersion < 111)
        {
            /*this.chkECT.Checked = this.class18_0.GetByteAt(this.class18_0.class13_0.long_403) != 0xA3;
            this.chkIAT.Checked = this.class18_0.GetByteAt(this.class18_0.class13_0.long_405) != 0xd9;
            this.chkVSS.Checked = this.class18_0.GetByteAt(this.class18_0.class13_0.long_401) != 0xdb;*/

            /*this.chkECT.Checked = this.class18_0.GetByteAt(this.class18_0.class13_0.long_403) == 0x0b;
            this.chkIAT.Checked = this.class18_0.GetByteAt(this.class18_0.class13_0.long_405) == 0x0d;
            this.chkVSS.Checked = this.class18_0.GetByteAt(this.class18_0.class13_0.long_401) == 0x0c;*/

            this.chkECT.Enabled = false;
            this.chkIAT.Enabled = false;
            this.chkVSS.Enabled = false;

            this.txtECT.Enabled = false;
            this.txtIAT.Enabled = false;
            this.textBox1.Enabled = false;
        }
        else
        {
            this.chkECT.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_403) != 0x00;
            this.chkIAT.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_405) != 0x00;
            this.chkVSS.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_401) != 0x00;

            this.txtECT.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_404)).ToString();
            this.txtIAT.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_406)).ToString();
            this.textBox1.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_400)).ToString();

            this.txtECT.Enabled = this.chkECT.Checked;
            this.txtIAT.Enabled = this.chkIAT.Checked;
            this.textBox1.Enabled = this.chkVSS.Checked;
        }

        this.lblECT.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();
        this.lblIAT.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();
        this.label2.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();


        DisableExtra();
        GetSIMCodesCheckState();

        /*this.chkICM.Checked = this.class18_0.method_150(this.class18_0.class13_0.long_74) == 0xff;
        if (this.class18_0.method_150(this.class18_0.class13_0.long_71) != 0 && !this.chkICM.Checked)
        {
            MessageBox.Show("ICM Error (CEL #15) MUST be disabled with ignition cut!");
            this.chkICM.Checked = true;
            this.class18_0.method_149(this.class18_0.class13_0.long_74, 0xff);
        }*/

        //COP
        /*if (this.class18_0.RomVersion >= 104)
        {
            this.chkCOPSync.Checked = this.class18_0.method_150(this.class18_0.class13_0.long_407) == 0xff;
            this.chkCOPFully.Checked = this.class18_0.method_150(this.class18_0.class13_0.long_408) == 0xff;
            this.chkCOPFire.Checked = this.class18_0.method_150(this.class18_0.class13_0.long_409) == 0xff;
        }*/

        this.bool_0 = false;
    }

    private void txtbIgnMbar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_1();
            }
            control.Focus();
        }
    }

    private void txtbIgnMbar_Validated(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbIgnMbar_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_255(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void chkPCS_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void chkICM_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void chkAtlCtrl_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void GetSIMCodesCheckState()
    {
        for (int i = 0x4f00; i < this.class18_0.GetByteLenght(); i++)
        {
            if (this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x2d && this.class18_0.GetByteAt(i + 3) == 0x38) this.chk_Crank.Checked = false;
            if (this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x12 && this.class18_0.GetByteAt(i + 3) == 0x3b) this.chk_Crank.Checked = true;

            if (this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x27 && this.class18_0.GetByteAt(i + 3) == 0x39) this.chk_TDC.Checked = false;
            if (this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x12 && this.class18_0.GetByteAt(i + 3) == 0x3f) this.chk_TDC.Checked = true;
        }
    }

    private void RemoveSIMCodes()
    {
        //Code4-8-9 are atleast above 4F00  (**not for Code14**)
        for (int i = 0x4f00; i < this.class18_0.GetByteLenght(); i++)
        {
            //53 + C42D38    off(0022dh).0      (Method #2 due to some roms not having 'off(00216h).1')
            if ((this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x2d && this.class18_0.GetByteAt(i + 3) == 0x38) && this.chk_Crank.Checked)
            {
                //CKP - Code4
                this.class18_0.SetByteAt(i + 1, 0xc4);
                this.class18_0.SetByteAt(i + 2, 0x12);
                this.class18_0.SetByteAt(i + 3, 0x3b);

                //Disable Code Location
                string CodeLoc = this.class18_0.GetByteAt(i-1).ToString("x2") + this.class18_0.GetByteAt(i - 2).ToString("x2");
                int CodeLocation = Int32.Parse(CodeLoc, System.Globalization.NumberStyles.HexNumber);
                this.class18_0.SetByteAt(CodeLocation, 0x00);

            }
            if ((this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x12 && this.class18_0.GetByteAt(i + 3) == 0x3b) && !this.chk_Crank.Checked)
            {
                //CKP - Code4
                this.class18_0.SetByteAt(i + 1, 0xc4);
                this.class18_0.SetByteAt(i + 2, 0x2d);
                this.class18_0.SetByteAt(i + 3, 0x38);

                //Enable Code Location
                string CodeLoc = this.class18_0.GetByteAt(i - 1).ToString("x2") + this.class18_0.GetByteAt(i - 2).ToString("x2");
                int CodeLocation = Int32.Parse(CodeLoc, System.Globalization.NumberStyles.HexNumber);
                this.class18_0.SetByteAt(CodeLocation, 0xff);
            }
            //########################################################################################################################
            //########################################################################################################################
            //########################################################################################################################
            //53 + C42739   off(00227h).1
            if ((this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x27 && this.class18_0.GetByteAt(i + 3) == 0x39) && this.chk_TDC.Checked)
            {
                //TDC - Code8
                this.class18_0.SetByteAt(i + 1, 0xc4);
                this.class18_0.SetByteAt(i + 2, 0x12);
                this.class18_0.SetByteAt(i + 3, 0x3f);

                //Disable Code Location
                string CodeLoc = this.class18_0.GetByteAt(i - 1).ToString("x2") + this.class18_0.GetByteAt(i - 2).ToString("x2");
                int CodeLocation = Int32.Parse(CodeLoc, System.Globalization.NumberStyles.HexNumber);
                this.class18_0.SetByteAt(CodeLocation, 0x00);
            }
            if ((this.class18_0.GetByteAt(i) == 0x53 && this.class18_0.GetByteAt(i + 1) == 0xC4 && this.class18_0.GetByteAt(i + 2) == 0x12 && this.class18_0.GetByteAt(i + 3) == 0x3f) && !this.chk_TDC.Checked)
            {
                //TDC - Code8
                this.class18_0.SetByteAt(i + 1, 0xc4);
                this.class18_0.SetByteAt(i + 2, 0x27);
                this.class18_0.SetByteAt(i + 3, 0x39);

                //Disable Code Location
                string CodeLoc = this.class18_0.GetByteAt(i - 1).ToString("x2") + this.class18_0.GetByteAt(i - 2).ToString("x2");
                int CodeLocation = Int32.Parse(CodeLoc, System.Globalization.NumberStyles.HexNumber);
                this.class18_0.SetByteAt(CodeLocation, 0x00);
            }
        }
    }
}

