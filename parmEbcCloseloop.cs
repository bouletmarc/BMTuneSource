using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmEbcCloseloop : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private IContainer components;
    private GroupBox groupBox5;
    private TrackBar trckUndershootSen;
    private TrackBar trckOvershootSens;
    private Label label15;
    private TextBox txtbCloseloopMax;
    private Label label16;
    private Label label3;
    private TextBox txtbCloseloopMin;
    private Label label14;
    private Label label2;
    private CheckBox chkCloseloop;
    private Label label21;
    private TextBox txtbUpdTmrNeg;
    private Label label13;
    private TextBox txtbUpdTmrPos;
    private Label label12;
    private TextBox txtbDeadBand;
    private Label label11;
    private ErrorProvider errorProvider_0;
    private Panel panel1;
    private GroupBox groupBox4;
    private Button btnResetPsi;
    private Button btnResetDuty;
    private TextBox txtbDuty;
    private Label label1;
    private GroupBox groupBox2;
    private ctrlAdvTable ctrlAdvTableDuty;
    private IContainer icontainer_0;

    public parmEbcCloseloop(ref Class18 rm)
    {
        this.InitializeComponent();
        class18_0 = rm;

        this.groupBox5.Enabled = true;

        this.ctrlAdvTableDuty.method_HeaderGrayed(true);
        this.ctrlAdvTableDuty.method_HasHeader(true);
        this.ctrlAdvTableDuty.method_RowsNumber(2);
        this.ctrlAdvTableDuty.method_ColumnsNumber(11);
        this.ctrlAdvTableDuty.int_2 = 0x24;
        this.ctrlAdvTableDuty.string_1 = new string[] { "Target Error(psi)", "Duty Adjustment(%)" };
        this.ctrlAdvTableDuty.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_3);
        this.ctrlAdvTableDuty.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTableDuty.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTableDuty.method_21(true);
        this.ctrlAdvTableDuty.method_SetIncreaser(1.0);
        this.ctrlAdvTableDuty.method_21(false);
        this.ctrlAdvTableDuty.method_SetIncreaser(0.5);
        this.ctrlAdvTableDuty.method_1(ref this.class18_0);
        this.ctrlAdvTableDuty.method_Load();
        this.ctrlAdvTableDuty.Enabled = false;

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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnResetPsi = new System.Windows.Forms.Button();
            this.btnResetDuty = new System.Windows.Forms.Button();
            this.txtbDuty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlAdvTableDuty = new ctrlAdvTable();
            this.trckUndershootSen = new System.Windows.Forms.TrackBar();
            this.trckOvershootSens = new System.Windows.Forms.TrackBar();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbCloseloopMax = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbCloseloopMin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCloseloop = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtbUpdTmrNeg = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbUpdTmrPos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbDeadBand = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckUndershootSen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckOvershootSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.trckUndershootSen);
            this.groupBox5.Controls.Add(this.trckOvershootSens);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtbCloseloopMax);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtbCloseloopMin);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.chkCloseloop);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.txtbUpdTmrNeg);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtbUpdTmrPos);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtbDeadBand);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(638, 305);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Closeloop Feedback Settings:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnResetPsi);
            this.groupBox4.Controls.Add(this.btnResetDuty);
            this.groupBox4.Controls.Add(this.txtbDuty);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 249);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(624, 49);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Target Error vs Duty Adjustment Wizard:";
            // 
            // btnResetPsi
            // 
            this.btnResetPsi.Enabled = false;
            this.btnResetPsi.Location = new System.Drawing.Point(274, 18);
            this.btnResetPsi.Name = "btnResetPsi";
            this.btnResetPsi.Size = new System.Drawing.Size(98, 23);
            this.btnResetPsi.TabIndex = 3;
            this.btnResetPsi.Text = "Reset Psi Error";
            this.btnResetPsi.UseVisualStyleBackColor = true;
            this.btnResetPsi.Click += new System.EventHandler(this.btnResetPsi_Click);
            // 
            // btnResetDuty
            // 
            this.btnResetDuty.Enabled = false;
            this.btnResetDuty.Location = new System.Drawing.Point(184, 18);
            this.btnResetDuty.Name = "btnResetDuty";
            this.btnResetDuty.Size = new System.Drawing.Size(84, 23);
            this.btnResetDuty.TabIndex = 2;
            this.btnResetDuty.Text = "Reset Duty";
            this.btnResetDuty.UseVisualStyleBackColor = true;
            this.btnResetDuty.Click += new System.EventHandler(this.btnResetDuty_Click);
            // 
            // txtbDuty
            // 
            this.txtbDuty.Enabled = false;
            this.txtbDuty.Location = new System.Drawing.Point(126, 19);
            this.txtbDuty.Name = "txtbDuty";
            this.txtbDuty.Size = new System.Drawing.Size(42, 20);
            this.txtbDuty.TabIndex = 1;
            this.txtbDuty.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDuty_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correction P:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ctrlAdvTableDuty);
            this.groupBox2.Location = new System.Drawing.Point(8, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 70);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Error vs Duty Adjustment:";
            // 
            // ctrlAdvTableDuty
            // 
            this.ctrlAdvTableDuty.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableDuty.Location = new System.Drawing.Point(5, 18);
            this.ctrlAdvTableDuty.Name = "ctrlAdvTableDuty";
            this.ctrlAdvTableDuty.Size = new System.Drawing.Size(608, 43);
            this.ctrlAdvTableDuty.TabIndex = 0;
            // 
            // trckUndershootSen
            // 
            this.trckUndershootSen.AutoSize = false;
            this.trckUndershootSen.LargeChange = 100;
            this.trckUndershootSen.Location = new System.Drawing.Point(134, 69);
            this.trckUndershootSen.Maximum = 500;
            this.trckUndershootSen.Name = "trckUndershootSen";
            this.trckUndershootSen.Size = new System.Drawing.Size(104, 16);
            this.trckUndershootSen.SmallChange = 50;
            this.trckUndershootSen.TabIndex = 43;
            this.trckUndershootSen.TickFrequency = 50;
            this.trckUndershootSen.Value = 450;
            this.trckUndershootSen.Scroll += new System.EventHandler(this.trckOvershootSens_Scroll);
            this.trckUndershootSen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trckOvershootSens_KeyPress);
            this.trckUndershootSen.Leave += new System.EventHandler(this.chkCloseloop_CheckedChanged);
            this.trckUndershootSen.MouseLeave += new System.EventHandler(this.chkCloseloop_CheckedChanged);
            // 
            // trckOvershootSens
            // 
            this.trckOvershootSens.AutoSize = false;
            this.trckOvershootSens.LargeChange = 100;
            this.trckOvershootSens.Location = new System.Drawing.Point(134, 40);
            this.trckOvershootSens.Maximum = 500;
            this.trckOvershootSens.Name = "trckOvershootSens";
            this.trckOvershootSens.Size = new System.Drawing.Size(104, 16);
            this.trckOvershootSens.SmallChange = 50;
            this.trckOvershootSens.TabIndex = 40;
            this.trckOvershootSens.TickFrequency = 50;
            this.trckOvershootSens.Value = 450;
            this.trckOvershootSens.Scroll += new System.EventHandler(this.trckOvershootSens_Scroll);
            this.trckOvershootSens.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trckOvershootSens_KeyPress);
            this.trckOvershootSens.Leave += new System.EventHandler(this.chkCloseloop_CheckedChanged);
            this.trckOvershootSens.MouseLeave += new System.EventHandler(this.chkCloseloop_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(183, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 14);
            this.label15.TabIndex = 39;
            this.label15.Text = "DC %";
            // 
            // txtbCloseloopMax
            // 
            this.txtbCloseloopMax.Enabled = false;
            this.txtbCloseloopMax.Location = new System.Drawing.Point(134, 121);
            this.txtbCloseloopMax.Name = "txtbCloseloopMax";
            this.txtbCloseloopMax.Size = new System.Drawing.Size(42, 20);
            this.txtbCloseloopMax.TabIndex = 5;
            this.txtbCloseloopMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDeadBand_KeyPress);
            this.txtbCloseloopMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbCloseloopMax_Validating);
            this.txtbCloseloopMax.Validated += new System.EventHandler(this.txtbDeadBand_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 14);
            this.label16.TabIndex = 38;
            this.label16.Text = "Closeloop adj max:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "DC %";
            // 
            // txtbCloseloopMin
            // 
            this.txtbCloseloopMin.Enabled = false;
            this.txtbCloseloopMin.Location = new System.Drawing.Point(134, 95);
            this.txtbCloseloopMin.Name = "txtbCloseloopMin";
            this.txtbCloseloopMin.Size = new System.Drawing.Size(42, 20);
            this.txtbCloseloopMin.TabIndex = 4;
            this.txtbCloseloopMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDeadBand_KeyPress);
            this.txtbCloseloopMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbCloseloopMin_Validating);
            this.txtbCloseloopMin.Validated += new System.EventHandler(this.txtbDeadBand_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 14);
            this.label14.TabIndex = 35;
            this.label14.Text = "Closeloop adj min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "Closeloop Feedback:";
            // 
            // chkCloseloop
            // 
            this.chkCloseloop.AutoSize = true;
            this.chkCloseloop.Location = new System.Drawing.Point(134, 19);
            this.chkCloseloop.Name = "chkCloseloop";
            this.chkCloseloop.Size = new System.Drawing.Size(15, 14);
            this.chkCloseloop.TabIndex = 0;
            this.chkCloseloop.UseVisualStyleBackColor = true;
            this.chkCloseloop.CheckedChanged += new System.EventHandler(this.chkCloseloop_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(182, 149);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 14);
            this.label21.TabIndex = 31;
            this.label21.Text = "psi";
            // 
            // txtbUpdTmrNeg
            // 
            this.txtbUpdTmrNeg.Location = new System.Drawing.Point(253, 39);
            this.txtbUpdTmrNeg.Name = "txtbUpdTmrNeg";
            this.txtbUpdTmrNeg.Size = new System.Drawing.Size(42, 20);
            this.txtbUpdTmrNeg.TabIndex = 1;
            this.txtbUpdTmrNeg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDeadBand_KeyPress);
            this.txtbUpdTmrNeg.Validating += new System.ComponentModel.CancelEventHandler(this.txtbUpdTmrNeg_Validating);
            this.txtbUpdTmrNeg.Validated += new System.EventHandler(this.txtbDeadBand_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 14);
            this.label13.TabIndex = 21;
            this.label13.Text = "Overshoot Senitivity:";
            // 
            // txtbUpdTmrPos
            // 
            this.txtbUpdTmrPos.Location = new System.Drawing.Point(253, 68);
            this.txtbUpdTmrPos.Name = "txtbUpdTmrPos";
            this.txtbUpdTmrPos.Size = new System.Drawing.Size(42, 20);
            this.txtbUpdTmrPos.TabIndex = 2;
            this.txtbUpdTmrPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDeadBand_KeyPress);
            this.txtbUpdTmrPos.Validating += new System.ComponentModel.CancelEventHandler(this.txtbUpdTmrNeg_Validating);
            this.txtbUpdTmrPos.Validated += new System.EventHandler(this.txtbDeadBand_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "Undershoot Senitivity:";
            // 
            // txtbDeadBand
            // 
            this.txtbDeadBand.Location = new System.Drawing.Point(134, 146);
            this.txtbDeadBand.Name = "txtbDeadBand";
            this.txtbDeadBand.Size = new System.Drawing.Size(42, 20);
            this.txtbDeadBand.TabIndex = 3;
            this.txtbDeadBand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDeadBand_KeyPress);
            this.txtbDeadBand.Leave += new System.EventHandler(this.txtbDeadBand_Leave);
            this.txtbDeadBand.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDeadBand_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 14);
            this.label11.TabIndex = 17;
            this.label11.Text = "Deadband error:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 323);
            this.panel1.TabIndex = 7;
            // 
            // parmEbcCloseloop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmEbcCloseloop";
            this.Size = new System.Drawing.Size(665, 323);
            this.Load += new System.EventHandler(this.parmEbcCompensation_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trckUndershootSen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckOvershootSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Ebc Closeloop table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex < 5)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_257 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_210(-1f * float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            }
            else if (dataGridViewCellValueEventArgs_0.ColumnIndex == 5)
            {
                dataGridViewCellValueEventArgs_0.Value = 0;
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_256 + ((10 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2), this.class18_0.method_210(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            }
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex < 5)
            {
                this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_257 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_211((double)float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            }
            else if (dataGridViewCellValueEventArgs_0.ColumnIndex == 5)
            {
                dataGridViewCellValueEventArgs_0.Value = 0;
            }
            else
            {
                this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_256 + ((10 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2)) + 1L, this.class18_0.method_211((double)(-1f * float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()))));
            }
        }
        this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_257 + 10L) + 1L, 0);
        this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_256 + 10L) + 1L, 0);
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_257 + 10L, 0);
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_256 + 10L, 0);
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex < 5)
            {
                dataGridViewCellValueEventArgs_0.Value = -1f * this.class18_0.method_244(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_257 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
            }
            else if (dataGridViewCellValueEventArgs_0.ColumnIndex == 5)
            {
                dataGridViewCellValueEventArgs_0.Value = 0;
            }
            else
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_244(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_256 + ((10 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2)));
            }
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex < 5)
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_207(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_257 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L));
            }
            else if (dataGridViewCellValueEventArgs_0.ColumnIndex == 5)
            {
                dataGridViewCellValueEventArgs_0.Value = 0;
            }
            else
            {
                dataGridViewCellValueEventArgs_0.Value = -1.0 * this.class18_0.method_207(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_256 + ((10 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2)) + 1L));
            }
        }
    }

    private void method_3(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            if (dataGridViewCellValidatingEventArgs_0.ColumnIndex < 5)
            {
                dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_253(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
            }
            else if (dataGridViewCellValidatingEventArgs_0.ColumnIndex > 5)
            {
                dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
            }
        }
        else if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValidatingEventArgs_0.ColumnIndex < 5)
            {
                dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
            }
            else if (dataGridViewCellValidatingEventArgs_0.ColumnIndex > 5)
            {
                dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_253(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
            }
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableDuty.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableDuty.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_15()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Ebc Settings");

            if (this.class18_0.class13_u_0.long_280 != 0L)
            {
                if (this.chkCloseloop.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_276, 0);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_276, 0xff);
                }
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_273, (byte)(double.Parse(this.txtbUpdTmrNeg.Text) / 10.0));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_272, (byte)(double.Parse(this.txtbUpdTmrPos.Text) / 10.0));
               
                if (this.class18_0.class13_u_0.long_280 != 0L)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_280, this.class18_0.method_222(float.Parse(this.txtbCloseloopMin.Text)));
                }
                if (this.class18_0.class13_u_0.long_281 != 0L)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_281, this.class18_0.method_222(float.Parse(this.txtbCloseloopMax.Text)));
                }
            }
            this.class18_0.method_153();
            this.parmEbcCompensation_Load(null, null);
        }
    }

    private void parmEbcCompensation_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        //this.groupBox5.Enabled = this.class18_0.class13_0.long_280 != 0L;
        //if (this.class18_0.class13_0.long_280 != 0L)
        //{
            this.chkCloseloop.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_276) == 0;
            this.txtbCloseloopMin.Enabled = this.class18_0.class13_u_0.long_280 != 0L;
            if (this.class18_0.class13_u_0.long_280 != 0L)
            {
                this.txtbCloseloopMin.Text = this.class18_0.method_190(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_280)).ToString();
            }
            this.txtbCloseloopMax.Enabled = this.class18_0.class13_u_0.long_281 != 0L;
            if (this.class18_0.class13_u_0.long_281 != 0L)
            {
                this.txtbCloseloopMax.Text = this.class18_0.method_190(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_281)).ToString();
            }
            this.txtbUpdTmrNeg.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_273) * 10).ToString();
            this.txtbUpdTmrPos.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_272) * 10).ToString();
            this.trckOvershootSens.Value = 500 - (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_273) * 10);
            this.trckUndershootSen.Value = 500 - (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_272) * 10);
            this.txtbDeadBand.Text = this.class18_0.method_244(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_274)).ToString();
        //}

        double num = 0.25;
        if (((this.class18_0.class13_u_0.long_256 != 0L) && (this.class18_0.class13_u_0.long_257 != 0L)))
        {
            this.ctrlAdvTableDuty.method_DisableHeader();
            this.txtbDuty.Text = num.ToString();
            this.ctrlAdvTableDuty.Enabled = true;
            this.btnResetDuty.Enabled = true;
            this.btnResetPsi.Enabled = true;
            this.txtbDuty.Enabled = true;
        }
        this.bool_0 = false;
    }

    private void trckOvershootSens_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            this.method_15();
        }
    }

    private void txtbDeadBand_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox)sender;
            this.groupBox5.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_15();
            }
            control.Focus();
        }
    }

    private void txtbDeadBand_Leave(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_15();
        }
    }

    private void txtbDeadBand_Validating(object sender, CancelEventArgs e)
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

    private void chkCloseloop_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0 && this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_15();
        }
    }

    private void trckOvershootSens_Scroll(object sender, EventArgs e)
    {

        this.txtbUpdTmrNeg.Text = (500 - this.trckOvershootSens.Value).ToString();
        this.txtbUpdTmrPos.Text = (500 - this.trckUndershootSen.Value).ToString();
    }

    private void txtbUpdTmrNeg_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
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

    private void txtbCloseloopMin_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_253(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Double Negative required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbCloseloopMax_Validating(object sender, CancelEventArgs e)
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

    private void txtbDuty_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Double input, interger Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void btnResetDuty_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.errorProvider_0.GetError(this.txtbDuty)) && (this.ctrlAdvTableDuty.method_14(0, 0) != 0.0))
        {
            this.class18_0.method_155("Ebc Closeloop table");
            double[] numArray = new double[11];
            for (int i = 0; i < 11; i++)
            {
                numArray[i] = this.ctrlAdvTableDuty.method_14(i, 0);
                numArray[i] *= double.Parse(this.txtbDuty.Text) * -1.0;
                if (i < 5)
                {
                    this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_257 + (i * 2)) + 1L, this.class18_0.method_211((double)((float)numArray[i])));
                }
                else if (i == 5)
                {
                    numArray[i] = 0.0;
                    this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_257 + (i * 2)) + 1L, 0);
                    this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_256 + ((10 - i) * 2)) + 1L, 0);
                }
                else
                {
                    this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_256 + ((10 - i) * 2)) + 1L, this.class18_0.method_211((double)(-1f * ((float)numArray[i]))));
                }
            }
            this.class18_0.method_153();
            this.ctrlAdvTableDuty.method_DisableHeader();
        }
    }

    private void btnResetPsi_Click(object sender, EventArgs e)
    {
        frmEbcDutyErrorInput input = new frmEbcDutyErrorInput();
        input.method_0(ref this.class18_0);
        if (input.ShowDialog() == DialogResult.OK)
        {
            float num = float.Parse(input.Tag.ToString());
            input.Close();
            input.Dispose();
            input = null;
            this.class18_0.method_155("Ebc Closeloop table");
            float num2 = 0f;
            float num3 = 0f;
            float num4 = (num - num2) / 5f;
            float[] numArray = new float[11];
            num3 = -1f * num;
            for (int i = 0; i < 11; i++)
            {
                if (i < 5)
                {
                    numArray[i] = num3;
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_257 + (i * 2), this.class18_0.method_210(-1f * num3));
                }
                else if (i == 5)
                {
                    num3 = 0f;
                    numArray[i] = num3;
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_257 + (i * 2), 0);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_256 + ((10 - i) * 2), 0);
                }
                else
                {
                    numArray[i] = num3;
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_256 + ((10 - i) * 2), this.class18_0.method_210(num3));
                }
                num3 += num4;
            }
            this.class18_0.method_153();
            this.ctrlAdvTableDuty.method_DisableHeader();
        }
    }
}

