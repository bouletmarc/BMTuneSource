using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmPopcorn : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label2;
    private Label label6;
    private Label label7;
    private Label label9;
    private IContainer components;
    private TrackBar trackBar1;
    private Label label3;
    private NumericUpDown txtbRpmMin;
    private NumericUpDown txtbTps;
    private NumericUpDown txtbBoostRetard;
    private Label label11;
    private Button btnSave;
    private ToolTip toolTip1;
    private Label label5;
    private Label label8;
    private GroupBox groupBox_IgnFuel;
    private Label label10;
    private Button buttonIncrease;
    private Button buttonDecrease;
    private GroupBox groupBox3;
    private Panel panel1;
    private NumericUpDown numericAboveRPM;
    private Label label1;
    private Button buttonADD;
    private int MinimumLoad = 0;
    private CheckBox checkBoxSecondary;
    private CheckBox checkBoxPrimary;
    private bool FirstLoad = true;
    private Button buttonOpenFCutOnDecel;
    private bool HasModInstalled = false;

    public parmPopcorn(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.InitializeComponent();

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOpenFCutOnDecel = new System.Windows.Forms.Button();
            this.buttonADD = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbRpmMin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbTps = new System.Windows.Forms.NumericUpDown();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_IgnFuel = new System.Windows.Forms.GroupBox();
            this.checkBoxSecondary = new System.Windows.Forms.CheckBox();
            this.checkBoxPrimary = new System.Windows.Forms.CheckBox();
            this.numericAboveRPM = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonIncrease = new System.Windows.Forms.Button();
            this.buttonDecrease = new System.Windows.Forms.Button();
            this.txtbBoostRetard = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpmMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox_IgnFuel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAboveRPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbBoostRetard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOpenFCutOnDecel);
            this.groupBox1.Controls.Add(this.buttonADD);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox_IgnFuel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 487);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Popcorn MOD Settings:";
            // 
            // buttonOpenFCutOnDecel
            // 
            this.buttonOpenFCutOnDecel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOpenFCutOnDecel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenFCutOnDecel.Location = new System.Drawing.Point(14, 54);
            this.buttonOpenFCutOnDecel.Name = "buttonOpenFCutOnDecel";
            this.buttonOpenFCutOnDecel.Size = new System.Drawing.Size(256, 25);
            this.buttonOpenFCutOnDecel.TabIndex = 129;
            this.buttonOpenFCutOnDecel.Text = "Open FuelCut on Decel Parameters";
            this.toolTip1.SetToolTip(this.buttonOpenFCutOnDecel, "Open the FuelCut on deceleration parameters page");
            this.buttonOpenFCutOnDecel.UseVisualStyleBackColor = false;
            this.buttonOpenFCutOnDecel.Click += new System.EventHandler(this.buttonOpenFCutOnDecel_Click);
            // 
            // buttonADD
            // 
            this.buttonADD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonADD.Location = new System.Drawing.Point(69, 23);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(156, 25);
            this.buttonADD.TabIndex = 128;
            this.buttonADD.Text = "ADD MOD";
            this.toolTip1.SetToolTip(this.buttonADD, "Apply Ignition to Ignition Tables");
            this.buttonADD.UseVisualStyleBackColor = false;
            this.buttonADD.Click += new System.EventHandler(this.Button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtbRpmMin);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtbTps);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(7, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 128);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fuel Cut on Deceleration Settings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "Below TPS:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 107;
            this.label7.Text = "Cut Delay:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 106;
            this.label6.Text = "344ms";
            // 
            // txtbRpmMin
            // 
            this.txtbRpmMin.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbRpmMin.Location = new System.Drawing.Point(110, 47);
            this.txtbRpmMin.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.txtbRpmMin.Name = "txtbRpmMin";
            this.txtbRpmMin.Size = new System.Drawing.Size(69, 20);
            this.txtbRpmMin.TabIndex = 120;
            this.txtbRpmMin.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbRpmMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbRpmMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMap_Validating);
            this.txtbRpmMin.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 110;
            this.label9.Text = "Above RPM:";
            // 
            // txtbTps
            // 
            this.txtbTps.Location = new System.Drawing.Point(109, 21);
            this.txtbTps.Name = "txtbTps";
            this.txtbTps.Size = new System.Drawing.Size(69, 20);
            this.txtbTps.TabIndex = 118;
            this.txtbTps.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMap_Validating);
            this.txtbTps.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(7, 97);
            this.trackBar1.Maximum = 2310;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(162, 22);
            this.trackBar1.TabIndex = 115;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 116;
            this.label3.Text = "%";
            // 
            // groupBox_IgnFuel
            // 
            this.groupBox_IgnFuel.Controls.Add(this.checkBoxSecondary);
            this.groupBox_IgnFuel.Controls.Add(this.checkBoxPrimary);
            this.groupBox_IgnFuel.Controls.Add(this.numericAboveRPM);
            this.groupBox_IgnFuel.Controls.Add(this.label1);
            this.groupBox_IgnFuel.Controls.Add(this.label10);
            this.groupBox_IgnFuel.Controls.Add(this.buttonIncrease);
            this.groupBox_IgnFuel.Controls.Add(this.buttonDecrease);
            this.groupBox_IgnFuel.Controls.Add(this.txtbBoostRetard);
            this.groupBox_IgnFuel.Controls.Add(this.label11);
            this.groupBox_IgnFuel.Controls.Add(this.btnSave);
            this.groupBox_IgnFuel.Location = new System.Drawing.Point(7, 225);
            this.groupBox_IgnFuel.Name = "groupBox_IgnFuel";
            this.groupBox_IgnFuel.Size = new System.Drawing.Size(276, 169);
            this.groupBox_IgnFuel.TabIndex = 1;
            this.groupBox_IgnFuel.TabStop = false;
            this.groupBox_IgnFuel.Text = "Fuel/Ignition Tables";
            // 
            // checkBoxSecondary
            // 
            this.checkBoxSecondary.AutoSize = true;
            this.checkBoxSecondary.Checked = true;
            this.checkBoxSecondary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSecondary.Location = new System.Drawing.Point(29, 51);
            this.checkBoxSecondary.Name = "checkBoxSecondary";
            this.checkBoxSecondary.Size = new System.Drawing.Size(218, 18);
            this.checkBoxSecondary.TabIndex = 132;
            this.checkBoxSecondary.Text = "Popcorn MOD on Secondary Tables";
            this.checkBoxSecondary.UseVisualStyleBackColor = true;
            this.checkBoxSecondary.CheckedChanged += new System.EventHandler(this.CheckBoxSecondary_CheckedChanged);
            // 
            // checkBoxPrimary
            // 
            this.checkBoxPrimary.AutoSize = true;
            this.checkBoxPrimary.Checked = true;
            this.checkBoxPrimary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrimary.Location = new System.Drawing.Point(29, 23);
            this.checkBoxPrimary.Name = "checkBoxPrimary";
            this.checkBoxPrimary.Size = new System.Drawing.Size(198, 18);
            this.checkBoxPrimary.TabIndex = 131;
            this.checkBoxPrimary.Text = "Popcorn MOD on Primary Tables";
            this.checkBoxPrimary.UseVisualStyleBackColor = true;
            this.checkBoxPrimary.CheckedChanged += new System.EventHandler(this.CheckBoxPrimary_CheckedChanged);
            // 
            // numericAboveRPM
            // 
            this.numericAboveRPM.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericAboveRPM.Location = new System.Drawing.Point(109, 80);
            this.numericAboveRPM.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.numericAboveRPM.Name = "numericAboveRPM";
            this.numericAboveRPM.Size = new System.Drawing.Size(69, 20);
            this.numericAboveRPM.TabIndex = 130;
            this.numericAboveRPM.Click += new System.EventHandler(this.txtbMap_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 129;
            this.label1.Text = "Pop Above RPM:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 14);
            this.label10.TabIndex = 128;
            this.label10.Text = "Fuel:";
            // 
            // buttonIncrease
            // 
            this.buttonIncrease.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonIncrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncrease.Location = new System.Drawing.Point(193, 136);
            this.buttonIncrease.Name = "buttonIncrease";
            this.buttonIncrease.Size = new System.Drawing.Size(70, 25);
            this.buttonIncrease.TabIndex = 127;
            this.buttonIncrease.Text = "Increase";
            this.toolTip1.SetToolTip(this.buttonIncrease, "Apply to Fuel Tables");
            this.buttonIncrease.UseVisualStyleBackColor = false;
            this.buttonIncrease.Click += new System.EventHandler(this.Button2_Click);
            // 
            // buttonDecrease
            // 
            this.buttonDecrease.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonDecrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDecrease.Location = new System.Drawing.Point(109, 136);
            this.buttonDecrease.Name = "buttonDecrease";
            this.buttonDecrease.Size = new System.Drawing.Size(70, 25);
            this.buttonDecrease.TabIndex = 126;
            this.buttonDecrease.Text = "Decrease";
            this.toolTip1.SetToolTip(this.buttonDecrease, "Apply to Fuel Tables");
            this.buttonDecrease.UseVisualStyleBackColor = false;
            this.buttonDecrease.Click += new System.EventHandler(this.ButtonDecrease_Click);
            // 
            // txtbBoostRetard
            // 
            this.txtbBoostRetard.DecimalPlaces = 2;
            this.txtbBoostRetard.Location = new System.Drawing.Point(109, 106);
            this.txtbBoostRetard.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtbBoostRetard.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.txtbBoostRetard.Name = "txtbBoostRetard";
            this.txtbBoostRetard.Size = new System.Drawing.Size(69, 20);
            this.txtbBoostRetard.TabIndex = 122;
            this.txtbBoostRetard.Value = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.txtbBoostRetard.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbBoostRetard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbBoostRetard.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIgn_Validating);
            this.txtbBoostRetard.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 14);
            this.label11.TabIndex = 121;
            this.label11.Text = "Ignition(static):";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(193, 103);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 25);
            this.btnSave.TabIndex = 125;
            this.btnSave.Text = "Apply";
            this.toolTip1.SetToolTip(this.btnSave, "Apply Ignition to Ignition Tables");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(55, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 24);
            this.label8.TabIndex = 127;
            this.label8.Text = "PORCORN MOD ARE SHARING\r\nTHE SAME PARAMETERS FOR:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(71, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 42);
            this.label5.TabIndex = 126;
            this.label5.Text = "-Fuel Cut(on deceleration)\r\n-Ignition Tables\r\n-Fuel Tables";
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
            this.panel1.Size = new System.Drawing.Size(313, 473);
            this.panel1.TabIndex = 2;
            // 
            // parmPopcorn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmPopcorn";
            this.Size = new System.Drawing.Size(313, 473);
            this.Load += new System.EventHandler(this.parmPopcorn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpmMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox_IgnFuel.ResumeLayout(false);
            this.groupBox_IgnFuel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAboveRPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbBoostRetard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_IncreaseFuel(SelectedTable selectedTable_0)
    {
        for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
        {
            if (this.class18_0.method_160((byte)j, selectedTable_0) >= (int.Parse(numericAboveRPM.Text) - 25))
            {
                byte columnIndex = (byte)0;
                byte rowIndex = (byte)j;
                float num2 = this.class18_0.method_175(columnIndex, rowIndex, selectedTable_0);
                if (num2 >= this.class18_0.class10_settings_0.float_3) this.class18_0.method_177(columnIndex, rowIndex, num2 + ((num2 / 100f) * this.class18_0.class10_settings_0.float_1), selectedTable_0);
                else this.class18_0.method_177(columnIndex, rowIndex, num2 + this.class18_0.class10_settings_0.float_2, selectedTable_0);

                //Check if editing are done correctly
                float num2_new = this.class18_0.method_175(columnIndex, rowIndex, selectedTable_0);
                float Multiplyer = 1.5f;
                int TryCount = 0;
                while (num2 == num2_new && TryCount < 3)
                {
                    if (num2 >= this.class18_0.class10_settings_0.float_3) this.class18_0.method_177(columnIndex, rowIndex, num2 + ((num2 / 100f) * (this.class18_0.class10_settings_0.float_1 * Multiplyer)), selectedTable_0);
                    else this.class18_0.method_177(columnIndex, rowIndex, num2 + (this.class18_0.class10_settings_0.float_2 * Multiplyer), selectedTable_0);

                    num2_new = this.class18_0.method_175(columnIndex, rowIndex, selectedTable_0);
                    Multiplyer += 0.5f;
                    TryCount++;
                    if (TryCount == 3) this.class18_0.method_155("Cannot increase fuel value for Col:#" + columnIndex + " Row:#" + rowIndex);
                }
            }
        }
    }

    private void method_DecreaseFuel(SelectedTable selectedTable_0)
    {
        for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
        {
            if (this.class18_0.method_160((byte)j, selectedTable_0) >= (int.Parse(numericAboveRPM.Text) - 25))
            {
                byte columnIndex = (byte)0;
                byte rowIndex = (byte)j;
                float num2 = this.class18_0.method_175(columnIndex, rowIndex, selectedTable_0);
                if (num2 >= this.class18_0.class10_settings_0.float_3)
                {
                    if ((num2 - ((num2 / 100f) * this.class18_0.class10_settings_0.float_1)) >= 0f) this.class18_0.method_177(columnIndex, rowIndex, num2 - ((num2 / 100f) * this.class18_0.class10_settings_0.float_1), selectedTable_0);
                    else this.class18_0.method_177(columnIndex, rowIndex, 0f, selectedTable_0);
                }
                else
                {
                    if ((num2 - this.class18_0.class10_settings_0.float_2) >= 0f) this.class18_0.method_177(columnIndex, rowIndex, num2 - this.class18_0.class10_settings_0.float_2, selectedTable_0);
                    else this.class18_0.method_177(columnIndex, rowIndex, 0f, selectedTable_0);
                }

                //Check if editing are done correctly
                if (num2 > 0f)
                {
                    float num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                    float Multiplyer = 1.5f;
                    int TryCount = 0;
                    while (num2 == num2_new && TryCount < 3)
                    {
                        if (num2 >= this.class18_0.class10_settings_0.float_3)
                        {
                            if ((num2 - ((num2 / 100f) * (this.class18_0.class10_settings_0.float_1 * Multiplyer))) >= 0f) this.class18_0.method_177(columnIndex, rowIndex, num2 - ((num2 / 100f) * (this.class18_0.class10_settings_0.float_1 * Multiplyer)), selectedTable_0);
                            else this.class18_0.method_177(columnIndex, rowIndex, 0f, selectedTable_0);
                        }
                        else
                        {
                            if ((num2 - (this.class18_0.class10_settings_0.float_2 * Multiplyer)) >= 0f) this.class18_0.method_177(columnIndex, rowIndex, num2 - (this.class18_0.class10_settings_0.float_2 * Multiplyer), selectedTable_0);
                            else this.class18_0.method_177(columnIndex, rowIndex, 0f, selectedTable_0);
                        }

                        num2_new = this.class18_0.method_175(columnIndex, rowIndex, selectedTable_0);
                        Multiplyer += 0.5f;
                        TryCount++;
                        if (TryCount == 3) this.class18_0.method_155("Cannot decrease fuel value for Col:#" + columnIndex + " Row:#" + rowIndex);
                    }
                }
            }
        }
    }

    private void method_ApplyIgn(SelectedTable selectedTable_0)
    {
        //Reset before settting
        method_ResetIgn(selectedTable_0);

        //Set
        for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
        {
            if (this.class18_0.method_160((byte)j, selectedTable_0) >= (int.Parse(numericAboveRPM.Text) - 5))
            {
                this.class18_0.method_177((byte)0, (byte)j, float.Parse(txtbBoostRetard.Text), selectedTable_0);
            }
        }
    }

    private void method_ResetIgn(SelectedTable selectedTable_0)
    {
        //reset all rpm rows, only reset Col0
        for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
        {
            this.class18_0.method_177((byte)0, (byte)j, this.class18_0.method_175((byte)1, (byte)j, selectedTable_0), selectedTable_0);
        }
    }

    private bool HasPopcornMod()
    {
        bool Hasmod = false;
        SelectedTable selectedTable_0 = SelectedTable.ign1_lo;
        if (checkBoxPrimary.Checked)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++) if (this.class18_0.method_175((byte)0, (byte)j, selectedTable_0) <= 2) Hasmod = true;
            if (!Hasmod)
            {
                selectedTable_0 = SelectedTable.ign1_hi;
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++) if (this.class18_0.method_175((byte)0, (byte)j, selectedTable_0) <= 2) Hasmod = true;
            }
        }
        if (checkBoxSecondary.Checked)
        {
            if (!Hasmod)
            {
                selectedTable_0 = SelectedTable.ign2_lo;
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++) if (this.class18_0.method_175((byte)0, (byte)j, selectedTable_0) <= 2) Hasmod = true;
            }
            if (!Hasmod)
            {
                selectedTable_0 = SelectedTable.ign2_hi;
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++) if (this.class18_0.method_175((byte)0, (byte)j, selectedTable_0) <= 2) Hasmod = true;
            }
        }

        HasModInstalled = Hasmod;
        if (HasModInstalled)
        {
            buttonADD.Text = "REMOVE MOD";
            buttonADD.ForeColor = Color.Red;
        }
        else
        {
            buttonADD.Text = "ADD MOD";
            buttonADD.ForeColor = SystemColors.ControlText;
        }

        return Hasmod;
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmPopcorn_Load(null, null);
        }
    }

    private void method_5()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Popcorn Mod Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_58, (byte) (trackBar1.Value / 10));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_56, this.class18_0.method_228(int.Parse(this.txtbTps.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_54, this.class18_0.method_216(int.Parse(this.txtbRpmMin.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_55, this.class18_0.method_216(int.Parse(this.txtbRpmMin.Text) - 200));

            this.class18_0.method_153();
        }
    }

    private void parmPopcorn_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.trackBar1.Value = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_58) * 10);
        this.label6.Text = this.trackBar1.Value + "ms";
        this.txtbTps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_56)).ToString("0");
        this.txtbRpmMin.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_54)).ToString();

        MinimumLoad = this.class18_0.method_164((byte)0, SelectedTable.fuel1_lo);
        if (FirstLoad)
        {
            this.numericAboveRPM.Text = (this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_54)) + 250).ToString();
        }

        HasPopcornMod();

        this.bool_0 = false;
        this.FirstLoad = false;
    }

    private void txtbMap_KeyPress(object sender, KeyPressEventArgs e)
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

    private void txtbMap_Validated(object sender, EventArgs e)
    {
        this.method_5();
        this.parmPopcorn_Load(null, null);
    }

    private void txtbMap_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_255(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
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

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        this.method_5();
        this.parmPopcorn_Load(null, null);
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Popcorn Mod Settings");
        if (checkBoxPrimary.Checked || checkBoxPrimary.Checked)
        {
            try
            {
                if (MessageBox.Show(Form.ActiveForm, "Do you want to set the Ignition Table for popcorn mod?\n\nThis will set ignition at " + double.Parse(txtbBoostRetard.Text) + "\nAbove " + int.Parse(numericAboveRPM.Text) + "rpm\nBellow " + MinimumLoad + "mBar", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_59, 0xff); //set fuel cut enabled
                    if (checkBoxPrimary.Checked)
                    {
                        this.method_ApplyIgn(SelectedTable.ign1_hi);
                        this.method_ApplyIgn(SelectedTable.ign1_lo);
                    }
                    if (checkBoxPrimary.Checked)
                    {

                        this.method_ApplyIgn(SelectedTable.ign2_hi);
                        this.method_ApplyIgn(SelectedTable.ign2_lo);
                    }
                }
            }
            catch (Exception message)
            {
                MessageBox.Show(Form.ActiveForm, "Error when setting Ignition Table! Error:\n\n" + message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.method_5();
            this.parmPopcorn_Load(null, null);
            this.class18_0.method_53();
        }
        else
        {
            MessageBox.Show(Form.ActiveForm, "Cant set Ignition Table because you didn't selected\nwhich map to work with(primary or secondary)", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Popcorn Mod Settings");
        if (!HasModInstalled)
        {
            //add mod
            this.method_5();
            this.BtnSave_Click(null, null);
            this.parmPopcorn_Load(null, null);
        }
        else
        {
            if (checkBoxPrimary.Checked || checkBoxPrimary.Checked)
            {
                //remove mod
                try
                {
                    if (MessageBox.Show(Form.ActiveForm, "Do you want to remove popcorn mod\nfrom the Ignition Table?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (checkBoxPrimary.Checked)
                        {

                            this.method_ResetIgn(SelectedTable.ign1_hi);
                            this.method_ResetIgn(SelectedTable.ign1_lo);
                        }
                        if (checkBoxPrimary.Checked)
                        {

                            this.method_ResetIgn(SelectedTable.ign2_hi);
                            this.method_ResetIgn(SelectedTable.ign2_lo);
                        }
                    }
                }
                catch (Exception message)
                {
                    MessageBox.Show(Form.ActiveForm, "Error when setting Ignition Table! Error:\n\n" + message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.method_5();
                this.parmPopcorn_Load(null, null);
                this.class18_0.method_53();
            }
            else
            {
                MessageBox.Show(Form.ActiveForm, "Cant reset Ignition Table because you didn't selected\nwhich map to work with(primary or secondary)", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Popcorn Mod Settings");
        if (checkBoxPrimary.Checked || checkBoxPrimary.Checked)
        {
            try
            {
                if (checkBoxPrimary.Checked)
                {

                    this.method_IncreaseFuel(SelectedTable.fuel1_hi);
                    this.method_IncreaseFuel(SelectedTable.fuel1_lo);
                }
                if (checkBoxPrimary.Checked)
                {

                    this.method_IncreaseFuel(SelectedTable.fuel2_hi);
                    this.method_IncreaseFuel(SelectedTable.fuel2_lo);
                }
            }
            catch (Exception message)
            {
                MessageBox.Show(Form.ActiveForm, "Error when setting Fuel Table! Error:\n\n" + message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.method_5();
            this.parmPopcorn_Load(null, null);
            this.class18_0.method_53();
        }
        else
        {
            MessageBox.Show(Form.ActiveForm, "Cant increase Fuel Table because you didn't selected\nwhich map to work with(primary or secondary)", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonDecrease_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Popcorn Mod Settings");
        if (checkBoxPrimary.Checked || checkBoxPrimary.Checked)
        {
            try
            {
                if (checkBoxPrimary.Checked)
                {

                    this.method_DecreaseFuel(SelectedTable.fuel1_hi);
                    this.method_DecreaseFuel(SelectedTable.fuel1_lo);
                }
                if (checkBoxPrimary.Checked)
                {

                    this.method_DecreaseFuel(SelectedTable.fuel2_hi);
                    this.method_DecreaseFuel(SelectedTable.fuel2_lo);
                }
            }
            catch (Exception message)
            {
                MessageBox.Show(Form.ActiveForm, "Error when setting Fuel Table! Error:\n\n" + message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.method_5();
            this.parmPopcorn_Load(null, null);
            this.class18_0.method_53();
        }
        else
        {
            MessageBox.Show(Form.ActiveForm, "Cant decrease Fuel Table because you didn't selected\nwhich map to work with(primary or secondary)", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CheckBoxPrimary_CheckedChanged(object sender, EventArgs e)
    {
        HasPopcornMod();
    }

    private void CheckBoxSecondary_CheckedChanged(object sender, EventArgs e)
    {
        HasPopcornMod();
    }

    private void buttonOpenFCutOnDecel_Click(object sender, EventArgs e)
    {
        this.class18_0.class17_0.frmMain_0.frmParameters_0.SelectPage("nFuelCut", "Fuel Cut Decel");
    }
}

