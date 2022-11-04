using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmIdleMain : UserControl
{
    private bool bool_0;
    private CheckBox chkIacvError;
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTable;
    private double double_0;
    private double double_1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox3;
    private IContainer icontainer_0;
    private Label label_0;
    private Label label1;
    private Label label3;
    private Label label5;
    private Label lblIACVdutyAc;
    private long long_0;
    private long long_1;
    private TrackBar trackBar_0;
    private TrackBar trkIACVdutyAC;
    private IContainer components;
    private Label label6;
    private Label label4;
    private Label label2;
    private Label label7;
    private Panel panel1;
    private NumericUpDown txtbTargetIdle;
    private GroupBox groupBox5;
    private Label label8;
    private Label label11;
    private ctrlAdvTable ctrlAdvTable2;
    private GroupBox groupBox2;
    private Label label9;
    private Label label10;
    private ctrlAdvTable ctrlAdvTable1;
    private GroupBox groupBox4;

    internal parmIdleMain(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.InitializeComponent();
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.method_HasHeader(false);
        this.ctrlAdvTable.method_RowsNumber(3);
        this.ctrlAdvTable.method_ColumnsNumber(7);
        this.ctrlAdvTable.int_2 = 40;
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0);
        this.ctrlAdvTable.method_21(true);
        this.ctrlAdvTable.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_Load();


        this.ctrlAdvTable1.method_HeaderGrayed(true);
        this.ctrlAdvTable1.method_HasHeader(false);
        this.ctrlAdvTable1.method_RowsNumber(2);
        this.ctrlAdvTable1.method_ColumnsNumber(4);
        this.ctrlAdvTable1.int_2 = 48;
        this.ctrlAdvTable1.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_X);
        this.ctrlAdvTable1.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_X);
        this.ctrlAdvTable1.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_X);
        this.ctrlAdvTable1.method_21(true);
        this.ctrlAdvTable1.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTable1.method_1(ref this.class18_0);
        this.ctrlAdvTable1.method_Load();

        this.ctrlAdvTable2.method_HeaderGrayed(true);
        this.ctrlAdvTable2.method_HasHeader(false);
        this.ctrlAdvTable2.method_RowsNumber(2);
        this.ctrlAdvTable2.method_ColumnsNumber(4);
        this.ctrlAdvTable2.int_2 = 48;
        this.ctrlAdvTable2.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_Y);
        this.ctrlAdvTable2.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_Y);
        this.ctrlAdvTable2.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_Y);
        this.ctrlAdvTable2.method_21(true);
        this.ctrlAdvTable2.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTable2.method_1(ref this.class18_0);
        this.ctrlAdvTable2.method_Load();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkIacvError_CheckedChanged(object sender, EventArgs e)
    {
        this.method_4();
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ctrlAdvTable2 = new ctrlAdvTable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlAdvTable1 = new ctrlAdvTable();
            this.txtbTargetIdle = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_0 = new System.Windows.Forms.TrackBar();
            this.label_0 = new System.Windows.Forms.Label();
            this.lblIACVdutyAc = new System.Windows.Forms.Label();
            this.trkIACVdutyAC = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIacvError = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTargetIdle)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkIACVdutyAC)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtbTargetIdle);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 409);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Idle Settings";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.ctrlAdvTable2);
            this.groupBox5.Location = new System.Drawing.Point(8, 331);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(353, 70);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "High Ignition Control Idle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ign:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 14);
            this.label11.TabIndex = 7;
            this.label11.Text = "RPM:";
            // 
            // ctrlAdvTable2
            // 
            this.ctrlAdvTable2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable2.Location = new System.Drawing.Point(66, 20);
            this.ctrlAdvTable2.Name = "ctrlAdvTable2";
            this.ctrlAdvTable2.Size = new System.Drawing.Size(281, 42);
            this.ctrlAdvTable2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.ctrlAdvTable1);
            this.groupBox2.Location = new System.Drawing.Point(8, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 70);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Low Ignition Control Idle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ign:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 14);
            this.label10.TabIndex = 7;
            this.label10.Text = "RPM:";
            // 
            // ctrlAdvTable1
            // 
            this.ctrlAdvTable1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable1.Location = new System.Drawing.Point(66, 20);
            this.ctrlAdvTable1.Name = "ctrlAdvTable1";
            this.ctrlAdvTable1.Size = new System.Drawing.Size(281, 42);
            this.ctrlAdvTable1.TabIndex = 6;
            // 
            // txtbTargetIdle
            // 
            this.txtbTargetIdle.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbTargetIdle.Location = new System.Drawing.Point(97, 19);
            this.txtbTargetIdle.Maximum = new decimal(new int[] {
            3500,
            0,
            0,
            0});
            this.txtbTargetIdle.Name = "txtbTargetIdle";
            this.txtbTargetIdle.Size = new System.Drawing.Size(64, 20);
            this.txtbTargetIdle.TabIndex = 13;
            this.txtbTargetIdle.Click += new System.EventHandler(this.trackBar_0_Validated);
            this.txtbTargetIdle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTargetIdle_KeyPress);
            this.txtbTargetIdle.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTargetIdle_Validating);
            this.txtbTargetIdle.Validated += new System.EventHandler(this.txtbTargetIdle_Validated);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.trackBar_0);
            this.groupBox4.Controls.Add(this.label_0);
            this.groupBox4.Controls.Add(this.lblIACVdutyAc);
            this.groupBox4.Controls.Add(this.trkIACVdutyAC);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.chkIacvError);
            this.groupBox4.Location = new System.Drawing.Point(8, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 100);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Idle Air Control Valve";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "IACV duty:";
            // 
            // trackBar_0
            // 
            this.trackBar_0.AutoSize = false;
            this.trackBar_0.LargeChange = 1024;
            this.trackBar_0.Location = new System.Drawing.Point(108, 48);
            this.trackBar_0.Maximum = 20480;
            this.trackBar_0.Name = "trackBar_0";
            this.trackBar_0.Size = new System.Drawing.Size(197, 18);
            this.trackBar_0.SmallChange = 64;
            this.trackBar_0.TabIndex = 3;
            this.trackBar_0.TickFrequency = 2048;
            this.trackBar_0.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_0.Value = 10240;
            this.trackBar_0.ValueChanged += new System.EventHandler(this.trackBar_0_ValueChanged);
            this.trackBar_0.Validating += new System.ComponentModel.CancelEventHandler(this.trackBar_0_Validating);
            this.trackBar_0.Validated += new System.EventHandler(this.trackBar_0_Validated);
            // 
            // label_0
            // 
            this.label_0.AutoSize = true;
            this.label_0.Location = new System.Drawing.Point(311, 49);
            this.label_0.Name = "label_0";
            this.label_0.Size = new System.Drawing.Size(14, 14);
            this.label_0.TabIndex = 6;
            this.label_0.Text = "%";
            // 
            // lblIACVdutyAc
            // 
            this.lblIACVdutyAc.AutoSize = true;
            this.lblIACVdutyAc.Location = new System.Drawing.Point(311, 76);
            this.lblIACVdutyAc.Name = "lblIACVdutyAc";
            this.lblIACVdutyAc.Size = new System.Drawing.Size(14, 14);
            this.lblIACVdutyAc.TabIndex = 9;
            this.lblIACVdutyAc.Text = "%";
            // 
            // trkIACVdutyAC
            // 
            this.trkIACVdutyAC.AutoSize = false;
            this.trkIACVdutyAC.LargeChange = 1024;
            this.trkIACVdutyAC.Location = new System.Drawing.Point(108, 74);
            this.trkIACVdutyAC.Maximum = 20480;
            this.trkIACVdutyAC.Name = "trkIACVdutyAC";
            this.trkIACVdutyAC.Size = new System.Drawing.Size(197, 18);
            this.trkIACVdutyAC.SmallChange = 64;
            this.trkIACVdutyAC.TabIndex = 7;
            this.trkIACVdutyAC.TickFrequency = 2048;
            this.trkIACVdutyAC.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkIACVdutyAC.Value = 10240;
            this.trkIACVdutyAC.ValueChanged += new System.EventHandler(this.trkIACVdutyAC_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "IACV duty(AC):";
            // 
            // chkIacvError
            // 
            this.chkIacvError.AutoSize = true;
            this.chkIacvError.Location = new System.Drawing.Point(11, 21);
            this.chkIacvError.Name = "chkIacvError";
            this.chkIacvError.Size = new System.Drawing.Size(123, 18);
            this.chkIacvError.TabIndex = 4;
            this.chkIacvError.Text = "Disable IACV error";
            this.chkIacvError.UseVisualStyleBackColor = true;
            this.chkIacvError.CheckedChanged += new System.EventHandler(this.chkIacvError_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "rpm";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ctrlAdvTable);
            this.groupBox3.Location = new System.Drawing.Point(8, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 97);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Target Idle vs ECT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "Moving:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Idle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "ECT:";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(66, 20);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(281, 62);
            this.ctrlAdvTable.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target Idle:";
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
            this.panel1.Size = new System.Drawing.Size(401, 454);
            this.panel1.TabIndex = 1;
            // 
            // parmIdle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmIdle";
            this.Size = new System.Drawing.Size(401, 454);
            this.Load += new System.EventHandler(this.parmIdle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTargetIdle)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkIACVdutyAC)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
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

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Ect idle table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L, this.class18_0.method_219(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L, this.class18_0.method_219(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_245 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_218(this.class18_0.method_152((this.class18_0.class13_u_0.long_245 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_218(this.class18_0.method_152(((this.class18_0.class13_u_0.long_245 + 0x15L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L));
        }
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
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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
        this.class18_0.method_155("Low Ignition Idle Control");

        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) this.class18_0.method_151(this.class18_0.class13_u_0.long_480 + 12L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) this.class18_0.method_151(this.class18_0.class13_u_0.long_480 + 12L + 2L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4);
        
        this.class18_0.method_153();
    }

    private void method_2_X(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_480 + 12L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4))).ToString();
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_480 + 12L + 2L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4)) / 4).ToString();
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
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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
        this.class18_0.method_155("High Ignition Idle Control");

        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) this.class18_0.method_151(this.class18_0.class13_u_0.long_481 + 12L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) this.class18_0.method_151(this.class18_0.class13_u_0.long_481 + 12L + 2L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4);

        this.class18_0.method_153();
    }

    private void method_2_Y(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_481 + 12L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4))).ToString();
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_481 + 12L + 2L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 4)) / 4).ToString();
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmIdle_Load(null, null);
        }
    }

    private void method_4()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Idle Settings");
            this.class18_0.method_151(this.class18_0.class13_u_0.long_241, this.long_0);
            if (this.class18_0.class13_u_0.long_242 != 0L)
            {
                this.class18_0.method_151(this.class18_0.class13_u_0.long_242, this.long_1);
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_244, this.class18_0.method_219(int.Parse(this.txtbTargetIdle.Text)));
            if (this.chkIacvError.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_243, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_243, 0);
            }
            this.class18_0.method_153();
            this.parmIdle_Load(null, null);
        }
    }

    private void method_5()
    {
        if (this.trackBar_0.Value < 0x2800)
        {
            this.double_0 = (((double) (0x27ff - this.trackBar_0.Value)) / 10239.0) * -100.0;
        }
        else
        {
            this.double_0 = (((double) (this.trackBar_0.Value - 0x2800)) / 10240.0) * 100.0;
        }
        this.label_0.Text = this.double_0.ToString("0") + "%";
        if (this.trkIACVdutyAC.Value < 0x2800)
        {
            this.double_1 = (((double) (0x27ff - this.trkIACVdutyAC.Value)) / 10239.0) * -100.0;
        }
        else
        {
            this.double_1 = (((double) (this.trkIACVdutyAC.Value - 0x2800)) / 10240.0) * 100.0;
        }
        this.lblIACVdutyAc.Text = this.double_1.ToString("0") + "%";
    }

    private void parmIdle_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.chkIacvError.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_243) == 0xff;
        this.txtbTargetIdle.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_244)).ToString();
        int num = 0;
        this.long_0 = this.class18_0.method_152(this.class18_0.class13_u_0.long_241);
        if (this.long_0 > 0x2800L)
        {
            num = ((int) this.long_0) - 0xd800;
        }
        else
        {
            num = ((int) this.long_0) + 0x2800;
        }
        if (num < 0) num = 0;
        if (num > 20480) num = 20480;
        this.trackBar_0.Value = num;
        num = 0;
        if (this.class18_0.class13_u_0.long_242 != 0L)
        {
            this.long_1 = this.class18_0.method_152(this.class18_0.class13_u_0.long_242);
            if (this.long_1 > 0x2800L)
            {
                num = ((int) this.long_1) - 0xd800;
            }
            else
            {
                num = ((int) this.long_1) + 0x2800;
            }
            if (num < 0) num = 0;
            if (num > 20480) num = 20480;
            this.trkIACVdutyAC.Value = num;
        }
        this.method_5();
        this.ctrlAdvTable.method_DisableHeader();

        //if (!this.class18_0.class15_0.method_5(Enum4.const_4)) panel2.Visible = false;
        //if (this.class18_0.class15_0.method_5(Enum4.const_4) && !this.class18_0.class17_0.method_34()) panel2.Visible = false;

        this.bool_0 = false;
    }

    private void trackBar_0_Validated(object sender, EventArgs e)
    {
    }

    private void trackBar_0_Validating(object sender, CancelEventArgs e)
    {
    }

    private void trackBar_0_ValueChanged(object sender, EventArgs e)
    {
        int num = 0;
        if (this.trackBar_0.Value < 0x2800)
        {
            num = 0xd800 + this.trackBar_0.Value;
        }
        else
        {
            num = this.trackBar_0.Value - 0x2800;
        }
        this.long_0 = num;
        this.method_5();
        this.method_4();
    }

    private void trkIACVdutyAC_ValueChanged(object sender, EventArgs e)
    {
        int num = 0;
        if (this.trkIACVdutyAC.Value < 0x2800)
        {
            num = 0xd800 + this.trkIACVdutyAC.Value;
        }
        else
        {
            num = this.trkIACVdutyAC.Value - 0x2800;
        }
        this.long_1 = num;
        this.method_5();
        this.method_4();
    }

    private void txtbTargetIdle_KeyPress(object sender, KeyPressEventArgs e)
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

    private void txtbTargetIdle_Validated(object sender, EventArgs e)
    {
        this.method_4();
    }

    private void txtbTargetIdle_Validating(object sender, CancelEventArgs e)
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
}

