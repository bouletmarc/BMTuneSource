using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmFuelCut : UserControl
{
    private bool bool_0;
    private CheckBox chkFCutDisable;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private Label label6;
    private Label label7;
    private Label label9;
    private IContainer components;
    private TrackBar trackBar1;
    private Label label4;
    private Label label3;
    private GroupBox groupBox2;
    private Label label10;
    private Label label5;
    private Label label8;
    private CheckBox chkFCutVacEnable;
    private NumericUpDown txtbRpmMin;
    private NumericUpDown txtbMap;
    private NumericUpDown txtbTps;
    private NumericUpDown txtbFcutVacRpm;
    private NumericUpDown txtbFCutVacTps;
    private GroupBox groupBox3;
    private Label label11;
    private Label label12;
    private ctrlAdvTable ctrlAdvTable1;
    private GroupBox groupBox4;
    private Label label13;
    private Label label14;
    private ctrlAdvTable ctrlAdvTable2;
    private CheckBox chkIgnCut;
    private Panel panel1;

    public parmFuelCut(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.InitializeComponent();

        this.ctrlAdvTable1.method_HeaderGrayed(true);
        this.ctrlAdvTable1.method_HasHeader(false);
        this.ctrlAdvTable1.method_RowsNumber(2);
        this.ctrlAdvTable1.method_ColumnsNumber(7);
        this.ctrlAdvTable1.int_2 = 42;
        this.ctrlAdvTable1.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_X);
        this.ctrlAdvTable1.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_X);
        this.ctrlAdvTable1.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_X);
        this.ctrlAdvTable1.method_21(true);
        this.ctrlAdvTable1.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTable1.method_1(ref this.class18_0);
        this.ctrlAdvTable1.method_Load();

        this.ctrlAdvTable2.method_HeaderGrayed(true);
        this.ctrlAdvTable2.method_HasHeader(false);
        this.ctrlAdvTable2.method_RowsNumber(2);
        this.ctrlAdvTable2.method_ColumnsNumber(7);
        this.ctrlAdvTable2.int_2 = 42;
        this.ctrlAdvTable2.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_Y);
        this.ctrlAdvTable2.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_Y);
        this.ctrlAdvTable2.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_Y);
        this.ctrlAdvTable2.method_21(true);
        this.ctrlAdvTable2.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTable2.method_1(ref this.class18_0);
        this.ctrlAdvTable2.method_Load();

        if (this.class18_0.RomVersion < 116) chkIgnCut.Visible = false;

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
            this.chkIgnCut = new System.Windows.Forms.CheckBox();
            this.txtbRpmMin = new System.Windows.Forms.NumericUpDown();
            this.txtbMap = new System.Windows.Forms.NumericUpDown();
            this.txtbTps = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.chkFCutDisable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbFcutVacRpm = new System.Windows.Forms.NumericUpDown();
            this.txtbFCutVacTps = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkFCutVacEnable = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ctrlAdvTable2 = new ctrlAdvTable();
            this.ctrlAdvTable1 = new ctrlAdvTable();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpmMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFcutVacRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCutVacTps)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIgnCut);
            this.groupBox1.Controls.Add(this.txtbRpmMin);
            this.groupBox1.Controls.Add(this.txtbMap);
            this.groupBox1.Controls.Add(this.txtbTps);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.chkFCutDisable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fuel Cut on Deceleration Settings:";
            // 
            // chkIgnCut
            // 
            this.chkIgnCut.AutoSize = true;
            this.chkIgnCut.Location = new System.Drawing.Point(135, 20);
            this.chkIgnCut.Name = "chkIgnCut";
            this.chkIgnCut.Size = new System.Drawing.Size(104, 18);
            this.chkIgnCut.TabIndex = 121;
            this.chkIgnCut.Text = "Enable Ign Cut";
            this.chkIgnCut.UseVisualStyleBackColor = true;
            this.chkIgnCut.Visible = false;
            this.chkIgnCut.CheckedChanged += new System.EventHandler(this.txtbMap_Validated);
            // 
            // txtbRpmMin
            // 
            this.txtbRpmMin.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbRpmMin.Location = new System.Drawing.Point(90, 98);
            this.txtbRpmMin.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.txtbRpmMin.Name = "txtbRpmMin";
            this.txtbRpmMin.Size = new System.Drawing.Size(60, 20);
            this.txtbRpmMin.TabIndex = 120;
            this.txtbRpmMin.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbRpmMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbRpmMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMap_Validating);
            this.txtbRpmMin.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // txtbMap
            // 
            this.txtbMap.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtbMap.Location = new System.Drawing.Point(90, 72);
            this.txtbMap.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbMap.Name = "txtbMap";
            this.txtbMap.Size = new System.Drawing.Size(60, 20);
            this.txtbMap.TabIndex = 119;
            this.txtbMap.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbMap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbMap.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMap_Validating);
            this.txtbMap.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // txtbTps
            // 
            this.txtbTps.Location = new System.Drawing.Point(90, 46);
            this.txtbTps.Name = "txtbTps";
            this.txtbTps.Size = new System.Drawing.Size(60, 20);
            this.txtbTps.TabIndex = 118;
            this.txtbTps.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMap_Validating);
            this.txtbTps.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 117;
            this.label4.Text = "mBar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 116;
            this.label3.Text = "%";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(8, 153);
            this.trackBar1.Maximum = 2310;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(162, 22);
            this.trackBar1.TabIndex = 115;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // chkFCutDisable
            // 
            this.chkFCutDisable.AutoSize = true;
            this.chkFCutDisable.Location = new System.Drawing.Point(8, 20);
            this.chkFCutDisable.Name = "chkFCutDisable";
            this.chkFCutDisable.Size = new System.Drawing.Size(110, 18);
            this.chkFCutDisable.TabIndex = 114;
            this.chkFCutDisable.Text = "Enable Fuel Cut";
            this.chkFCutDisable.UseVisualStyleBackColor = true;
            this.chkFCutDisable.CheckedChanged += new System.EventHandler(this.txtbMap_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 100;
            this.label1.Text = "Below Load:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 110;
            this.label9.Text = "Above RPM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "Below TPS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 106;
            this.label6.Text = "344ms";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 107;
            this.label7.Text = "Cut Delay:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbFcutVacRpm);
            this.groupBox2.Controls.Add(this.txtbFCutVacTps);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkFCutVacEnable);
            this.groupBox2.Location = new System.Drawing.Point(3, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 99);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vacumn Leak Fuel Cut";
            // 
            // txtbFcutVacRpm
            // 
            this.txtbFcutVacRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbFcutVacRpm.Location = new System.Drawing.Point(90, 69);
            this.txtbFcutVacRpm.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.txtbFcutVacRpm.Name = "txtbFcutVacRpm";
            this.txtbFcutVacRpm.Size = new System.Drawing.Size(60, 20);
            this.txtbFcutVacRpm.TabIndex = 121;
            this.txtbFcutVacRpm.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbFcutVacRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbFcutVacRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMap_Validating);
            this.txtbFcutVacRpm.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // txtbFCutVacTps
            // 
            this.txtbFCutVacTps.Location = new System.Drawing.Point(90, 43);
            this.txtbFCutVacTps.Name = "txtbFCutVacTps";
            this.txtbFCutVacTps.Size = new System.Drawing.Size(60, 20);
            this.txtbFCutVacTps.TabIndex = 121;
            this.txtbFCutVacTps.Click += new System.EventHandler(this.txtbMap_Validated);
            this.txtbFCutVacTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMap_KeyPress);
            this.txtbFCutVacTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMap_Validating);
            this.txtbFCutVacTps.Validated += new System.EventHandler(this.txtbMap_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 121;
            this.label10.Text = "Above RPM:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 119;
            this.label5.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 14);
            this.label8.TabIndex = 118;
            this.label8.Text = "Below TPS:";
            // 
            // chkFCutVacEnable
            // 
            this.chkFCutVacEnable.AutoSize = true;
            this.chkFCutVacEnable.Location = new System.Drawing.Point(8, 20);
            this.chkFCutVacEnable.Name = "chkFCutVacEnable";
            this.chkFCutVacEnable.Size = new System.Drawing.Size(158, 18);
            this.chkFCutVacEnable.TabIndex = 0;
            this.chkFCutVacEnable.Text = "Disable for Vacumn Leak";
            this.chkFCutVacEnable.UseVisualStyleBackColor = true;
            this.chkFCutVacEnable.CheckedChanged += new System.EventHandler(this.txtbMap_Validated);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 484);
            this.panel1.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.ctrlAdvTable2);
            this.groupBox4.Location = new System.Drawing.Point(3, 372);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 70);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Overrun Fuelcut Resume (normal)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 14);
            this.label13.TabIndex = 8;
            this.label13.Text = "RPM:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 14);
            this.label14.TabIndex = 7;
            this.label14.Text = "ECT:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.ctrlAdvTable1);
            this.groupBox3.Location = new System.Drawing.Point(3, 296);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 70);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Overrun Fuelcut Resume (initial)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 14);
            this.label11.TabIndex = 8;
            this.label11.Text = "RPM:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 14);
            this.label12.TabIndex = 7;
            this.label12.Text = "ECT:";
            // 
            // ctrlAdvTable2
            // 
            this.ctrlAdvTable2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable2.Location = new System.Drawing.Point(47, 20);
            this.ctrlAdvTable2.Name = "ctrlAdvTable2";
            this.ctrlAdvTable2.Size = new System.Drawing.Size(300, 42);
            this.ctrlAdvTable2.TabIndex = 6;
            // 
            // ctrlAdvTable1
            // 
            this.ctrlAdvTable1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable1.Location = new System.Drawing.Point(47, 20);
            this.ctrlAdvTable1.Name = "ctrlAdvTable1";
            this.ctrlAdvTable1.Size = new System.Drawing.Size(300, 42);
            this.ctrlAdvTable1.TabIndex = 6;
            // 
            // parmFuelCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmFuelCut";
            this.Size = new System.Drawing.Size(481, 484);
            this.Load += new System.EventHandler(this.parmFuelCut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpmMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFcutVacRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCutVacTps)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

    }

    //#################################################################################

    private void method_0_X(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTable1.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTable1.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_X(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Overrun Fuel resume Initial");

        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_482 - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_482 + 1L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), (byte) (int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) / 16));

        this.class18_0.method_153();
    }

    private void method_2_X(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_482 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_482 + 1L + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) * 16).ToString();
    }

    //#################################################################################

    private void method_0_Y(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTable2.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTable2.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_Y(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Overrun Fuel resume Normal");

        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_483 - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_483 + 1L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), (byte)(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) / 16));

        this.class18_0.method_153();
    }

    private void method_2_Y(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_483 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_483 + 1L + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) * 16).ToString();
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmFuelCut_Load(null, null);
        }
    }

    private void method_5()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Fuel Cut Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_58, (byte) (trackBar1.Value / 10));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_53, this.class18_0.method_226(int.Parse(this.txtbMap.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_56, this.class18_0.method_228(int.Parse(this.txtbTps.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_54, this.class18_0.method_216(int.Parse(this.txtbRpmMin.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_55, this.class18_0.method_216(int.Parse(this.txtbRpmMin.Text) - 200));

            if (this.chkFCutDisable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_59, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_59, 0xff);
            
            if (this.chkFCutVacEnable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_61, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_61, 0);

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_62, this.class18_0.method_216(int.Parse(this.txtbFcutVacRpm.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_60, this.class18_0.method_228(int.Parse(this.txtbFCutVacTps.Text)));

            /*if (this.class18_0.RomVersion >= 116)
            {
                if (this.chkIgnCut.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_520, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_520, 0);
            }*/

            this.class18_0.method_153();
        }
    }

    private void parmFuelCut_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.trackBar1.Value = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_58) * 10);
        this.label6.Text = this.trackBar1.Value + "ms";
        this.txtbMap.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_53)).ToString();
        this.txtbTps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_56)).ToString("0");
        this.txtbRpmMin.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_54)).ToString();
        this.chkFCutDisable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_59) != 0xff;
        this.chkFCutVacEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_61) != 0;
        this.txtbFcutVacRpm.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_62)).ToString();
        this.txtbFCutVacTps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_60)).ToString("0");

        /*if (!this.chkFCutDisable.Checked)
        {
            this.txtbMap.Enabled = false;
            this.txtbTps.Enabled = false;
            this.txtbRpmMin.Enabled = false;
            this.trackBar1.Enabled = false;
        }
        else
        {*/
            this.txtbMap.Enabled = true;
            this.txtbTps.Enabled = true;
            this.txtbRpmMin.Enabled = true;
            this.trackBar1.Enabled = true;
        //}


        /*if (this.class18_0.RomVersion >= 116)
        {
            this.chkIgnCut.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_520) == 0xff;
        }*/

        this.bool_0 = false;
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
        this.parmFuelCut_Load(null, null);
    }

    private void txtbMap_Validating(object sender, CancelEventArgs e)
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

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        this.method_5();
        this.parmFuelCut_Load(null, null);
    }
}

