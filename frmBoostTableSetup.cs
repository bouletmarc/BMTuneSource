using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmBoostTableSetup : Form
{
    private Button btnApply;
    private Button btnCancel;
    private Class18 class18_0;
    private GroupBox groupBox3;
    private GroupBox groupBox5;
    private IContainer icontainer_0;
    private Label label2;
    private RadioButton rbFuelAdd;
    private RadioButton rbFuelDont;
    private RadioButton rbIgnDont;
    private RadioButton rbIgnRet;
    private Label label1;
    private Label label5;
    private Label label3;
    private Label label4;
    private int[] int_1 = new int[0x18];
    private int[] int_2 = new int[0x18];
    private bool Changed = false;
    private bool Loading = true;
    private bool IsBoosted = false;
    private Label label6;
    private Panel panel1;
    private Label label15;
    private Label label7;
    private Label label16;
    private Label label11;
    private Label label8;
    private Label label17;
    private Label label10;
    private Label label18;
    private Label label12;
    private Label label9;
    private Label label19;
    private Label label21;
    private Label label13;
    private Label label14;
    private Label label20;
    private RadioButton rbIgnStep;
    private GroupBox groupBox1;
    private CheckBox chkSec;
    private CheckBox chkPrim;
    private RadioButton rbSelected;
    private RadioButton rbCurrent;
    private NumericUpDown txtbBoostRetard;
    private NumericUpDown txtbBoostEff;
    private NumericUpDown txtbStep10;
    private NumericUpDown txtbStepIgn5;
    private NumericUpDown txtbStep8;
    private NumericUpDown txtbStep6;
    private NumericUpDown txtbStepIgn4;
    private NumericUpDown txtbStep4;
    private NumericUpDown txtbStepIgn3;
    private NumericUpDown txtbStep2;
    private NumericUpDown txtbStep9;
    private NumericUpDown txtbStepIgn2;
    private NumericUpDown txtbStep7;
    private NumericUpDown txtbStepIgn1;
    private NumericUpDown txtbStep5;
    private NumericUpDown txtbStep3;
    private NumericUpDown txtbStep1;
    private NumericUpDown txtbCols;
    private int StartColumns = 0;

    internal frmBoostTableSetup()
    {
        this.InitializeComponent();
        //this.txtbBoostRetard.Text = 0.75f.ToString();

        this.txtbStepIgn1.Text = 0.08f.ToString();
        this.txtbStepIgn2.Text = 0.15f.ToString();
        this.txtbStepIgn3.Text = 0.25f.ToString();
        this.txtbStepIgn4.Text = 0.5f.ToString();
        this.txtbStepIgn5.Text = 0.75f.ToString();

    }

    private void Apply_Columns()
    {
        if (int.Parse(this.txtbCols.Text) == 0 && IsBoosted) MessageBox.Show(Form.ActiveForm, "Columns number are set to 0\nThe basemap will reset for NA", "BMTune");
        if (int.Parse(this.txtbCols.Text) != 0 && !IsBoosted) MessageBox.Show(Form.ActiveForm, "Columns number are higher than 0\nThe basemap will reset for Boost", "BMTune");

        //Get Boost Columns
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, (byte)(10 + byte.Parse(this.txtbCols.Text)));
        int startcolumns = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_75) - 10;
        if (startcolumns < 0) startcolumns = 0;
        if (startcolumns > 14) startcolumns = 14;
        this.txtbCols.Text = startcolumns.ToString();
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, (byte)(10 + byte.Parse(this.txtbCols.Text)));

        StartColumns = startcolumns;
        
        float num12 = -1f;
        float num13 = -1f;
        float num14 = -1f;
        float num15 = -1f;
        int num16 = (this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1) - 10;
        num12 = 2f;
        num15 = this.class18_0.method_245(this.class18_0.method_206(0xff));
        num13 = (num15 - num12) / ((float)num16);
        for (int num17 = 10; num17 < this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber(); num17++)
        {
            if (num14 < 0f)
            {
                num14 = num12;
            }
            this.class18_0.method_171((byte)num17, this.class18_0.method_226(this.class18_0.method_250(num14)), SelectedTable.fuel1_hi);
            this.class18_0.method_171((byte)num17, this.class18_0.method_226(this.class18_0.method_250(num14)), SelectedTable.fuel2_hi);
            num14 += num13;
        }
        for (int num18 = this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber(); num18 < this.class18_0.method_33(); num18++)
        {
            this.class18_0.method_171((byte)num18, 0xff, SelectedTable.fuel1_hi);
            this.class18_0.method_171((byte)num18, 0xff, SelectedTable.fuel2_hi);
        }
        this.method_1_SetFuel(SelectedTable.fuel1_hi);
        this.method_1_SetFuel(SelectedTable.fuel1_lo);
        this.method_1_SetFuel(SelectedTable.fuel2_hi);
        this.method_1_SetFuel(SelectedTable.fuel2_lo);
        this.method_2_SetIgnition(SelectedTable.ign1_hi);
        this.method_2_SetIgnition(SelectedTable.ign1_lo);
        this.method_2_SetIgnition(SelectedTable.ign2_hi);
        this.method_2_SetIgnition(SelectedTable.ign2_lo);



        this.class18_0.method_153();
        this.class18_0.method_52();
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        if (this.rbIgnDont.Checked && this.rbFuelDont.Checked && !Changed)
        {
            MessageBox.Show(Form.ActiveForm, "No adjustment selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else if (this.rbSelected.Checked && !this.chkPrim.Checked && !this.chkSec.Checked)
        {
            MessageBox.Show(Form.ActiveForm, "No tables selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
            this.class18_0.method_156("Boost Table Setup", true);

            //Apply new boost Columns
            if (Changed) Apply_Columns();

            if (!this.rbFuelDont.Checked)
            {

                if (this.rbSelected.Checked && !this.rbFuelDont.Checked)
                {
                    if (this.chkPrim.Checked)
                    {
                        this.method_1_SetFuel(SelectedTable.fuel1_hi);
                        this.method_1_SetFuel(SelectedTable.fuel1_lo);
                    }
                    if (this.chkSec.Checked)
                    {
                        this.method_1_SetFuel(SelectedTable.fuel2_hi);
                        this.method_1_SetFuel(SelectedTable.fuel2_lo);
                    }
                }
                else
                {
                    if (this.class18_0.method_39())
                    {
                        this.method_1_SetFuel(SelectedTable.fuel2_hi);
                        this.method_1_SetFuel(SelectedTable.fuel2_lo);
                    }
                    else
                    {
                        this.method_1_SetFuel(SelectedTable.fuel1_hi);
                        this.method_1_SetFuel(SelectedTable.fuel1_lo);
                    }
                }
            }
            if (!this.rbIgnDont.Checked)
            {
                if (this.rbSelected.Checked && !this.rbFuelDont.Checked)
                {
                    if (this.chkPrim.Checked)
                    {
                        this.method_2_SetIgnition(SelectedTable.ign1_hi);
                        this.method_2_SetIgnition(SelectedTable.ign1_lo);
                    }
                    if (this.chkSec.Checked)
                    {
                        this.method_2_SetIgnition(SelectedTable.ign2_hi);
                        this.method_2_SetIgnition(SelectedTable.ign2_lo);
                    }
                }
                else
                {
                    if (this.class18_0.method_39())
                    {
                        this.method_2_SetIgnition(SelectedTable.ign2_hi);
                        this.method_2_SetIgnition(SelectedTable.ign2_lo);
                    }
                    else
                    {
                        this.method_2_SetIgnition(SelectedTable.ign1_hi);
                        this.method_2_SetIgnition(SelectedTable.ign1_lo);
                    }
                }
            }
            this.class18_0.method_154();
            this.class18_0.method_53();


            try
            {
                this.class18_0.class10_settings_0.BoostFuel = int.Parse(txtbBoostEff.Text);
                this.class18_0.class10_settings_0.BoostRetard = float.Parse(txtbBoostRetard.Text);

                this.class18_0.class10_settings_0.BoostIGNStep1 = int.Parse(this.txtbStep1.Text);
                this.class18_0.class10_settings_0.BoostIGNStep2 = int.Parse(this.txtbStep2.Text);
                this.class18_0.class10_settings_0.BoostIGNStep3 = int.Parse(this.txtbStep4.Text);
                this.class18_0.class10_settings_0.BoostIGNStep4 = int.Parse(this.txtbStep6.Text);
                this.class18_0.class10_settings_0.BoostIGNStep5 = int.Parse(this.txtbStep8.Text);
                this.class18_0.class10_settings_0.BoostIGNStep6 = int.Parse(this.txtbStep10.Text);

                this.class18_0.class10_settings_0.BoostIGNRetard1 = double.Parse(this.txtbStepIgn1.Text);
                this.class18_0.class10_settings_0.BoostIGNRetard2 = double.Parse(this.txtbStepIgn2.Text);
                this.class18_0.class10_settings_0.BoostIGNRetard3 = double.Parse(this.txtbStepIgn3.Text);
                this.class18_0.class10_settings_0.BoostIGNRetard4 = double.Parse(this.txtbStepIgn4.Text);
                this.class18_0.class10_settings_0.BoostIGNRetard5 = double.Parse(this.txtbStepIgn5.Text);
            }
            catch
            {
                this.class18_0.class10_settings_0.BoostFuel = 120;
                this.class18_0.class10_settings_0.BoostRetard = 1;

                this.class18_0.class10_settings_0.BoostIGNStep1 = 0;
                this.class18_0.class10_settings_0.BoostIGNStep2 = 3;
                this.class18_0.class10_settings_0.BoostIGNStep3 = 5;
                this.class18_0.class10_settings_0.BoostIGNStep4 = 7;
                this.class18_0.class10_settings_0.BoostIGNStep5 = 12;
                this.class18_0.class10_settings_0.BoostIGNStep6 = 30;

                this.class18_0.class10_settings_0.BoostIGNRetard1 = 0.08;
                this.class18_0.class10_settings_0.BoostIGNRetard2 = 0.15;
                this.class18_0.class10_settings_0.BoostIGNRetard3 = 0.25;
                this.class18_0.class10_settings_0.BoostIGNRetard4 = 0.5;
                this.class18_0.class10_settings_0.BoostIGNRetard5 = 0.75;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoostTableSetup));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbIgnRet = new System.Windows.Forms.RadioButton();
            this.rbIgnDont = new System.Windows.Forms.RadioButton();
            this.rbIgnStep = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbFuelDont = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbFuelAdd = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSec = new System.Windows.Forms.CheckBox();
            this.chkPrim = new System.Windows.Forms.CheckBox();
            this.rbSelected = new System.Windows.Forms.RadioButton();
            this.rbCurrent = new System.Windows.Forms.RadioButton();
            this.txtbBoostEff = new System.Windows.Forms.NumericUpDown();
            this.txtbBoostRetard = new System.Windows.Forms.NumericUpDown();
            this.txtbStepIgn1 = new System.Windows.Forms.NumericUpDown();
            this.txtbStepIgn2 = new System.Windows.Forms.NumericUpDown();
            this.txtbStepIgn3 = new System.Windows.Forms.NumericUpDown();
            this.txtbStepIgn4 = new System.Windows.Forms.NumericUpDown();
            this.txtbStepIgn5 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep1 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep3 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep5 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep7 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep9 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep2 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep4 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep6 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep8 = new System.Windows.Forms.NumericUpDown();
            this.txtbStep10 = new System.Windows.Forms.NumericUpDown();
            this.txtbCols = new System.Windows.Forms.NumericUpDown();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbBoostEff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbBoostRetard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCols)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(23, 432);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(162, 432);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(147, 25);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbBoostRetard);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.rbIgnRet);
            this.groupBox3.Controls.Add(this.rbIgnDont);
            this.groupBox3.Controls.Add(this.rbIgnStep);
            this.groupBox3.Location = new System.Drawing.Point(14, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 200);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ignition Tables";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtbStep10);
            this.panel1.Controls.Add(this.txtbStepIgn5);
            this.panel1.Controls.Add(this.txtbStep8);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtbStep6);
            this.panel1.Controls.Add(this.txtbStepIgn4);
            this.panel1.Controls.Add(this.txtbStep4);
            this.panel1.Controls.Add(this.txtbStepIgn3);
            this.panel1.Controls.Add(this.txtbStep2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtbStep9);
            this.panel1.Controls.Add(this.txtbStepIgn2);
            this.panel1.Controls.Add(this.txtbStep7);
            this.panel1.Controls.Add(this.txtbStepIgn1);
            this.panel1.Controls.Add(this.txtbStep5);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtbStep3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtbStep1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(18, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 115);
            this.panel1.TabIndex = 71;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(226, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 14);
            this.label15.TabIndex = 70;
            this.label15.Text = "°/psi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 14);
            this.label7.TabIndex = 52;
            this.label7.Text = "°/psi";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(123, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 14);
            this.label16.TabIndex = 68;
            this.label16.Text = "Psi";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 54;
            this.label11.Text = "><";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 14);
            this.label8.TabIndex = 50;
            this.label8.Text = "Psi";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(52, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 14);
            this.label17.TabIndex = 66;
            this.label17.Text = "><";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 14);
            this.label10.TabIndex = 56;
            this.label10.Text = "Psi";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(52, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 14);
            this.label18.TabIndex = 48;
            this.label18.Text = "><";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(226, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 14);
            this.label12.TabIndex = 64;
            this.label12.Text = "°/psi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 14);
            this.label9.TabIndex = 58;
            this.label9.Text = "°/psi";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(226, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 14);
            this.label19.TabIndex = 46;
            this.label19.Text = "°/psi";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(52, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 14);
            this.label21.TabIndex = 42;
            this.label21.Text = "><";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(123, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 14);
            this.label13.TabIndex = 62;
            this.label13.Text = "Psi";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 14);
            this.label14.TabIndex = 60;
            this.label14.Text = "><";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(123, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 14);
            this.label20.TabIndex = 44;
            this.label20.Text = "Psi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Retard per PSI:";
            // 
            // rbIgnRet
            // 
            this.rbIgnRet.AutoSize = true;
            this.rbIgnRet.Location = new System.Drawing.Point(6, 38);
            this.rbIgnRet.Name = "rbIgnRet";
            this.rbIgnRet.Size = new System.Drawing.Size(104, 18);
            this.rbIgnRet.TabIndex = 6;
            this.rbIgnRet.Text = "Retard Ignition";
            this.rbIgnRet.UseVisualStyleBackColor = true;
            this.rbIgnRet.CheckedChanged += new System.EventHandler(this.rbIgnRet_CheckedChanged);
            // 
            // rbIgnDont
            // 
            this.rbIgnDont.AutoSize = true;
            this.rbIgnDont.Checked = true;
            this.rbIgnDont.Location = new System.Drawing.Point(6, 19);
            this.rbIgnDont.Name = "rbIgnDont";
            this.rbIgnDont.Size = new System.Drawing.Size(98, 18);
            this.rbIgnDont.TabIndex = 1;
            this.rbIgnDont.TabStop = true;
            this.rbIgnDont.Text = "Don\'t Change";
            this.rbIgnDont.UseVisualStyleBackColor = true;
            // 
            // rbIgnStep
            // 
            this.rbIgnStep.AutoSize = true;
            this.rbIgnStep.Location = new System.Drawing.Point(6, 57);
            this.rbIgnStep.Name = "rbIgnStep";
            this.rbIgnStep.Size = new System.Drawing.Size(91, 18);
            this.rbIgnStep.TabIndex = 40;
            this.rbIgnStep.Text = "Step Retard:";
            this.rbIgnStep.UseVisualStyleBackColor = true;
            this.rbIgnStep.CheckedChanged += new System.EventHandler(this.rbIgnStep_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtbBoostEff);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.rbFuelDont);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.rbFuelAdd);
            this.groupBox5.Location = new System.Drawing.Point(14, 92);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(310, 61);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fuel Tables";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "%";
            // 
            // rbFuelDont
            // 
            this.rbFuelDont.AutoSize = true;
            this.rbFuelDont.Checked = true;
            this.rbFuelDont.Location = new System.Drawing.Point(7, 16);
            this.rbFuelDont.Name = "rbFuelDont";
            this.rbFuelDont.Size = new System.Drawing.Size(98, 18);
            this.rbFuelDont.TabIndex = 5;
            this.rbFuelDont.TabStop = true;
            this.rbFuelDont.Text = "Don\'t Change";
            this.rbFuelDont.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fuel per PSI:";
            // 
            // rbFuelAdd
            // 
            this.rbFuelAdd.AutoSize = true;
            this.rbFuelAdd.Location = new System.Drawing.Point(6, 36);
            this.rbFuelAdd.Name = "rbFuelAdd";
            this.rbFuelAdd.Size = new System.Drawing.Size(98, 18);
            this.rbFuelAdd.TabIndex = 2;
            this.rbFuelAdd.Text = "Increase Fuel";
            this.rbFuelAdd.UseVisualStyleBackColor = true;
            this.rbFuelAdd.CheckedChanged += new System.EventHandler(this.rbFuelAdd_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Boost Columns:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(65, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "If you change Columns number\r\nReset also Fuel and Ignition Tables";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSec);
            this.groupBox1.Controls.Add(this.chkPrim);
            this.groupBox1.Controls.Add(this.rbSelected);
            this.groupBox1.Controls.Add(this.rbCurrent);
            this.groupBox1.Location = new System.Drawing.Point(14, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 86);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table Selection";
            // 
            // chkSec
            // 
            this.chkSec.AutoSize = true;
            this.chkSec.Enabled = false;
            this.chkSec.Location = new System.Drawing.Point(151, 61);
            this.chkSec.Name = "chkSec";
            this.chkSec.Size = new System.Drawing.Size(116, 18);
            this.chkSec.TabIndex = 8;
            this.chkSec.Text = "Secondary Maps";
            this.chkSec.UseVisualStyleBackColor = true;
            // 
            // chkPrim
            // 
            this.chkPrim.AutoSize = true;
            this.chkPrim.Enabled = false;
            this.chkPrim.Location = new System.Drawing.Point(35, 61);
            this.chkPrim.Name = "chkPrim";
            this.chkPrim.Size = new System.Drawing.Size(96, 18);
            this.chkPrim.TabIndex = 7;
            this.chkPrim.Text = "Primary Maps";
            this.chkPrim.UseVisualStyleBackColor = true;
            // 
            // rbSelected
            // 
            this.rbSelected.AutoSize = true;
            this.rbSelected.Location = new System.Drawing.Point(6, 39);
            this.rbSelected.Name = "rbSelected";
            this.rbSelected.Size = new System.Drawing.Size(105, 18);
            this.rbSelected.TabIndex = 1;
            this.rbSelected.Text = "Selected Maps";
            this.rbSelected.UseVisualStyleBackColor = true;
            this.rbSelected.CheckedChanged += new System.EventHandler(this.rbSelected_CheckedChanged);
            // 
            // rbCurrent
            // 
            this.rbCurrent.AutoSize = true;
            this.rbCurrent.Checked = true;
            this.rbCurrent.Location = new System.Drawing.Point(6, 18);
            this.rbCurrent.Name = "rbCurrent";
            this.rbCurrent.Size = new System.Drawing.Size(118, 18);
            this.rbCurrent.TabIndex = 0;
            this.rbCurrent.TabStop = true;
            this.rbCurrent.Text = "Current Set Maps";
            this.rbCurrent.UseVisualStyleBackColor = true;
            // 
            // txtbBoostEff
            // 
            this.txtbBoostEff.Location = new System.Drawing.Point(227, 34);
            this.txtbBoostEff.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.txtbBoostEff.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.txtbBoostEff.Name = "txtbBoostEff";
            this.txtbBoostEff.Size = new System.Drawing.Size(55, 20);
            this.txtbBoostEff.TabIndex = 11;
            this.txtbBoostEff.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // txtbBoostRetard
            // 
            this.txtbBoostRetard.DecimalPlaces = 2;
            this.txtbBoostRetard.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtbBoostRetard.Location = new System.Drawing.Point(227, 34);
            this.txtbBoostRetard.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtbBoostRetard.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.txtbBoostRetard.Name = "txtbBoostRetard";
            this.txtbBoostRetard.Size = new System.Drawing.Size(55, 20);
            this.txtbBoostRetard.TabIndex = 12;
            this.txtbBoostRetard.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // txtbStepIgn1
            // 
            this.txtbStepIgn1.DecimalPlaces = 2;
            this.txtbStepIgn1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn1.Location = new System.Drawing.Point(166, 5);
            this.txtbStepIgn1.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtbStepIgn1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn1.Name = "txtbStepIgn1";
            this.txtbStepIgn1.Size = new System.Drawing.Size(55, 20);
            this.txtbStepIgn1.TabIndex = 72;
            this.txtbStepIgn1.Value = new decimal(new int[] {
            8,
            0,
            0,
            131072});
            // 
            // txtbStepIgn2
            // 
            this.txtbStepIgn2.DecimalPlaces = 2;
            this.txtbStepIgn2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn2.Location = new System.Drawing.Point(166, 26);
            this.txtbStepIgn2.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtbStepIgn2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn2.Name = "txtbStepIgn2";
            this.txtbStepIgn2.Size = new System.Drawing.Size(55, 20);
            this.txtbStepIgn2.TabIndex = 73;
            this.txtbStepIgn2.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            // 
            // txtbStepIgn3
            // 
            this.txtbStepIgn3.DecimalPlaces = 2;
            this.txtbStepIgn3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn3.Location = new System.Drawing.Point(166, 47);
            this.txtbStepIgn3.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtbStepIgn3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn3.Name = "txtbStepIgn3";
            this.txtbStepIgn3.Size = new System.Drawing.Size(55, 20);
            this.txtbStepIgn3.TabIndex = 74;
            this.txtbStepIgn3.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // txtbStepIgn4
            // 
            this.txtbStepIgn4.DecimalPlaces = 2;
            this.txtbStepIgn4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn4.Location = new System.Drawing.Point(166, 68);
            this.txtbStepIgn4.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtbStepIgn4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn4.Name = "txtbStepIgn4";
            this.txtbStepIgn4.Size = new System.Drawing.Size(55, 20);
            this.txtbStepIgn4.TabIndex = 75;
            this.txtbStepIgn4.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // txtbStepIgn5
            // 
            this.txtbStepIgn5.DecimalPlaces = 2;
            this.txtbStepIgn5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn5.Location = new System.Drawing.Point(166, 89);
            this.txtbStepIgn5.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtbStepIgn5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtbStepIgn5.Name = "txtbStepIgn5";
            this.txtbStepIgn5.Size = new System.Drawing.Size(55, 20);
            this.txtbStepIgn5.TabIndex = 76;
            this.txtbStepIgn5.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            // 
            // txtbStep1
            // 
            this.txtbStep1.Location = new System.Drawing.Point(10, 5);
            this.txtbStep1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep1.Name = "txtbStep1";
            this.txtbStep1.Size = new System.Drawing.Size(38, 20);
            this.txtbStep1.TabIndex = 12;
            // 
            // txtbStep3
            // 
            this.txtbStep3.Location = new System.Drawing.Point(10, 26);
            this.txtbStep3.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep3.Name = "txtbStep3";
            this.txtbStep3.Size = new System.Drawing.Size(38, 20);
            this.txtbStep3.TabIndex = 13;
            this.txtbStep3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtbStep5
            // 
            this.txtbStep5.Location = new System.Drawing.Point(10, 48);
            this.txtbStep5.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep5.Name = "txtbStep5";
            this.txtbStep5.Size = new System.Drawing.Size(38, 20);
            this.txtbStep5.TabIndex = 14;
            this.txtbStep5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtbStep7
            // 
            this.txtbStep7.Location = new System.Drawing.Point(10, 68);
            this.txtbStep7.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep7.Name = "txtbStep7";
            this.txtbStep7.Size = new System.Drawing.Size(38, 20);
            this.txtbStep7.TabIndex = 15;
            this.txtbStep7.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // txtbStep9
            // 
            this.txtbStep9.Location = new System.Drawing.Point(10, 89);
            this.txtbStep9.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep9.Name = "txtbStep9";
            this.txtbStep9.Size = new System.Drawing.Size(38, 20);
            this.txtbStep9.TabIndex = 16;
            this.txtbStep9.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // txtbStep2
            // 
            this.txtbStep2.Location = new System.Drawing.Point(79, 6);
            this.txtbStep2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep2.Name = "txtbStep2";
            this.txtbStep2.Size = new System.Drawing.Size(38, 20);
            this.txtbStep2.TabIndex = 17;
            this.txtbStep2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtbStep4
            // 
            this.txtbStep4.Location = new System.Drawing.Point(79, 27);
            this.txtbStep4.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep4.Name = "txtbStep4";
            this.txtbStep4.Size = new System.Drawing.Size(38, 20);
            this.txtbStep4.TabIndex = 18;
            this.txtbStep4.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtbStep6
            // 
            this.txtbStep6.Location = new System.Drawing.Point(79, 48);
            this.txtbStep6.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep6.Name = "txtbStep6";
            this.txtbStep6.Size = new System.Drawing.Size(38, 20);
            this.txtbStep6.TabIndex = 19;
            this.txtbStep6.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // txtbStep8
            // 
            this.txtbStep8.Location = new System.Drawing.Point(79, 69);
            this.txtbStep8.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep8.Name = "txtbStep8";
            this.txtbStep8.Size = new System.Drawing.Size(38, 20);
            this.txtbStep8.TabIndex = 20;
            this.txtbStep8.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // txtbStep10
            // 
            this.txtbStep10.Location = new System.Drawing.Point(79, 89);
            this.txtbStep10.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbStep10.Name = "txtbStep10";
            this.txtbStep10.Size = new System.Drawing.Size(38, 20);
            this.txtbStep10.TabIndex = 21;
            this.txtbStep10.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtbCols
            // 
            this.txtbCols.Location = new System.Drawing.Point(193, 364);
            this.txtbCols.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.txtbCols.Name = "txtbCols";
            this.txtbCols.Size = new System.Drawing.Size(47, 20);
            this.txtbCols.TabIndex = 13;
            this.txtbCols.ValueChanged += new System.EventHandler(this.txtbCols_TextChanged);
            // 
            // frmBoostTableSetup
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(338, 471);
            this.Controls.Add(this.txtbCols);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBoostTableSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Boost Tables";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbBoostEff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbBoostRetard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStepIgn5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbStep10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_0(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;


        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        //Get Boost Columns
        int startcolumns = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_75) - 10;
        if (startcolumns < 0) startcolumns = 0;
        if (startcolumns > 14) startcolumns = 14;
        this.txtbCols.Text = startcolumns.ToString();

        if (startcolumns == 0) IsBoosted = false;
        else IsBoosted = true;

        StartColumns = startcolumns;


        this.txtbBoostEff.Text = this.class18_0.class10_settings_0.BoostFuel.ToString();
        this.txtbBoostRetard.Text = this.class18_0.class10_settings_0.BoostRetard.ToString();

        this.txtbStep1.Text = this.class18_0.class10_settings_0.BoostIGNStep1.ToString();
        this.txtbStep2.Text = this.class18_0.class10_settings_0.BoostIGNStep2.ToString();
        this.txtbStep3.Text = this.class18_0.class10_settings_0.BoostIGNStep2.ToString();
        this.txtbStep4.Text = this.class18_0.class10_settings_0.BoostIGNStep3.ToString();
        this.txtbStep5.Text = this.class18_0.class10_settings_0.BoostIGNStep3.ToString();
        this.txtbStep6.Text = this.class18_0.class10_settings_0.BoostIGNStep4.ToString();
        this.txtbStep7.Text = this.class18_0.class10_settings_0.BoostIGNStep4.ToString();
        this.txtbStep8.Text = this.class18_0.class10_settings_0.BoostIGNStep5.ToString();
        this.txtbStep9.Text = this.class18_0.class10_settings_0.BoostIGNStep5.ToString();
        this.txtbStep10.Text = this.class18_0.class10_settings_0.BoostIGNStep6.ToString();

        this.txtbStepIgn1.Text = this.class18_0.class10_settings_0.BoostIGNRetard1.ToString();
        this.txtbStepIgn2.Text = this.class18_0.class10_settings_0.BoostIGNRetard2.ToString();
        this.txtbStepIgn3.Text = this.class18_0.class10_settings_0.BoostIGNRetard3.ToString();
        this.txtbStepIgn4.Text = this.class18_0.class10_settings_0.BoostIGNRetard4.ToString();
        this.txtbStepIgn5.Text = this.class18_0.class10_settings_0.BoostIGNRetard5.ToString();

        Loading = false;
    }

    private void method_1_SetFuel(SelectedTable selectedTable_0)
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        float num4 = 0f;
        float num5 = float.Parse(this.txtbBoostEff.Text) / 100f;
        double num6 = 0.0;
        while (this.class18_0.method_164((byte) num, selectedTable_0) <= (this.class18_0.class10_settings_0.int_6 + 40))
        {
            num++;
        }
        num2 = num - 1;
        num3 = num;
        for (int i = num3; i < this.class18_0.method_33(); i++)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                num4 = this.class18_0.method_175((byte) num2, (byte) j, selectedTable_0);
                num6 = this.class18_0.method_163((byte) i) - this.class18_0.method_163((byte) num2);
                num4 += (num4 * (((float) num6) / 1000f)) * num5;
                this.class18_0.method_177((byte) i, (byte) j, num4, selectedTable_0);
            }
        }
    }

    private void method_2_SetIgnition(SelectedTable selectedTable_0)
    {
        if (this.rbIgnStep.Checked)
        {
            this.method_3(selectedTable_0, float.Parse(this.txtbStep1.Text), float.Parse(this.txtbStep2.Text), float.Parse(this.txtbStepIgn1.Text));
            this.method_3(selectedTable_0, float.Parse(this.txtbStep3.Text), float.Parse(this.txtbStep4.Text), float.Parse(this.txtbStepIgn2.Text));
            this.method_3(selectedTable_0, float.Parse(this.txtbStep5.Text), float.Parse(this.txtbStep6.Text), float.Parse(this.txtbStepIgn3.Text));
            this.method_3(selectedTable_0, float.Parse(this.txtbStep7.Text), float.Parse(this.txtbStep8.Text), float.Parse(this.txtbStepIgn4.Text));
            this.method_3(selectedTable_0, float.Parse(this.txtbStep9.Text), float.Parse(this.txtbStep10.Text), float.Parse(this.txtbStepIgn5.Text));
        }
        else
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            float num4 = 0f;
            float num5 = 0f;
            try
            {
                num5 = float.Parse(this.txtbBoostRetard.Text);
            }
            catch
            {
                try
                {
                    num5 = (float) double.Parse(this.txtbBoostRetard.Text);
                }
                catch { }
            }

            float num6 = 0f;
            while (this.class18_0.method_164((byte)num, selectedTable_0) <= (this.class18_0.class10_settings_0.int_6 + 40))
            {
                num++;
            }
            num2 = num - 1;
            num3 = num;
            for (int i = num3; i < this.class18_0.method_33(); i++)
            {
                num6 = this.class18_0.method_245(this.class18_0.method_164((byte)i, selectedTable_0));
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    num4 = this.class18_0.method_175((byte)num2, (byte)j, selectedTable_0);
                    num4 -= num6 * num5;
                    if (num4 < 0f) num4 = 0f;
                    this.class18_0.method_177((byte)i, (byte)j, num4, selectedTable_0);
                }
            }
        }
    }

    private void method_3(SelectedTable selectedTable_0, float float_0, float float_1, float float_2)
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        float num4 = 0f;
        float num5 = float_2;
        float num6 = 0f;
        while (this.class18_0.method_164((byte)num, selectedTable_0) <= (this.class18_0.class10_settings_0.int_6 + 20))
        {
            num++;
        }
        num2 = num - 1;
        num3 = num;
        for (int i = num3; i < this.class18_0.method_33(); i++)
        {
            num6 = this.class18_0.method_245(this.class18_0.method_164((byte)i, selectedTable_0));
            if ((num6 >= float_0) && (num6 <= float_1))
            {
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    num4 = this.class18_0.method_175((byte)num2, (byte)j, selectedTable_0);
                    if (num4 > -6f)
                    {
                        num4 -= num6 * num5;
                        this.class18_0.method_177((byte)i, (byte)j, num4, selectedTable_0);
                    }
                }
            }
        }
    }

    private void rbFuelAdd_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbFuelAdd.Checked)
        {
            this.txtbBoostEff.Enabled = true;
        }
        else
        {
            this.txtbBoostEff.Enabled = false;
        }
    }

    private void rbIgnRet_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbIgnRet.Checked)
        {
            this.txtbBoostRetard.Enabled = true;
        }
        else
        {
            this.txtbBoostRetard.Enabled = false;
        }
    }

    private void txtbCols_TextChanged(object sender, EventArgs e)
    {
        if (int.Parse(this.txtbCols.Text) < 0) this.txtbCols.Text = "0";
        if (int.Parse(this.txtbCols.Text) > 15) this.txtbCols.Text = "15";
        if (!Loading)
        {
            if (int.Parse(this.txtbCols.Text) == StartColumns) Changed = false;
            else Changed = true;

            if (Changed && int.Parse(this.txtbCols.Text) != 0)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                this.rbFuelAdd.Checked = true;
                this.rbIgnRet.Checked = true;
            }
            else if (Changed && int.Parse(this.txtbCols.Text) == 0)
            {
                this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
                this.rbFuelAdd.Checked = false;
                this.rbIgnRet.Checked = false;
            }
            else label6.ForeColor = System.Drawing.SystemColors.ControlText;
        }
    }

    private void rbIgnStep_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbIgnStep.Checked)
        {
            this.panel1.Enabled = true;
        }
        else
        {
            this.panel1.Enabled = false;
        }
    }

    private void rbSelected_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbSelected.Checked)
        {
            this.chkPrim.Enabled = true;
            this.chkSec.Enabled = true;
            this.chkSec.Checked = false;
            this.chkPrim.Checked = false;
        }
        else
        {
            this.chkPrim.Enabled = false;
            this.chkSec.Enabled = false;
            this.chkSec.Checked = false;
            this.chkPrim.Checked = false;
        }
    }
}

