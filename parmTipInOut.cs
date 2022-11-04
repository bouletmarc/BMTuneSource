using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmTipInOut : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private Label label5;
    private Label label6;
    private Label lblTipin;
    private Label lblTipout;
    private TextBox txtbShiftResponse;
    private TextBox txtbTipin;
    private IContainer components;
    private GroupBox groupBox4;
    private Label label13;
    private Label label14;
    private ctrlAdvTable ctrlAdvTable2;
    private GroupBox groupBox3;
    private Label label11;
    private Label label12;
    private ctrlAdvTable ctrlAdvTable1;
    private TextBox txtbTipoutDisableRpm;

    public parmTipInOut(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

        this.ctrlAdvTable1.method_HeaderGrayed(true);
        this.ctrlAdvTable1.method_HasHeader(false);
        this.ctrlAdvTable1.method_RowsNumber(2);
        this.ctrlAdvTable1.method_ColumnsNumber(6);
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
        this.ctrlAdvTable2.method_ColumnsNumber(6);
        this.ctrlAdvTable2.int_2 = 42;
        this.ctrlAdvTable2.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_Y);
        this.ctrlAdvTable2.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_Y);
        this.ctrlAdvTable2.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_Y);
        this.ctrlAdvTable2.method_21(true);
        this.ctrlAdvTable2.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTable2.method_1(ref this.class18_0);
        this.ctrlAdvTable2.method_Load();

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
            this.label5 = new System.Windows.Forms.Label();
            this.lblTipin = new System.Windows.Forms.Label();
            this.txtbTipoutDisableRpm = new System.Windows.Forms.TextBox();
            this.txtbTipin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbShiftResponse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTipout = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ctrlAdvTable2 = new ctrlAdvTable();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ctrlAdvTable1 = new ctrlAdvTable();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblTipin);
            this.groupBox1.Controls.Add(this.txtbTipoutDisableRpm);
            this.groupBox1.Controls.Add(this.txtbTipin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtbShiftResponse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTipout);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TPS Tip In && Out Fuel Corrections";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "rpm";
            // 
            // lblTipin
            // 
            this.lblTipin.AutoSize = true;
            this.lblTipin.Location = new System.Drawing.Point(240, 26);
            this.lblTipin.Name = "lblTipin";
            this.lblTipin.Size = new System.Drawing.Size(16, 14);
            this.lblTipin.TabIndex = 3;
            this.lblTipin.Text = "M";
            // 
            // txtbTipoutDisableRpm
            // 
            this.txtbTipoutDisableRpm.Location = new System.Drawing.Point(175, 71);
            this.txtbTipoutDisableRpm.Name = "txtbTipoutDisableRpm";
            this.txtbTipoutDisableRpm.Size = new System.Drawing.Size(54, 20);
            this.txtbTipoutDisableRpm.TabIndex = 6;
            this.txtbTipoutDisableRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTipin_KeyPress);
            this.txtbTipoutDisableRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTipoutDisableRpm_Validating);
            this.txtbTipoutDisableRpm.Validated += new System.EventHandler(this.txtbTipin_Validated);
            // 
            // txtbTipin
            // 
            this.txtbTipin.Location = new System.Drawing.Point(175, 23);
            this.txtbTipin.Name = "txtbTipin";
            this.txtbTipin.Size = new System.Drawing.Size(54, 20);
            this.txtbTipin.TabIndex = 2;
            this.txtbTipin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTipin_KeyPress);
            this.txtbTipin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTipin_Validating);
            this.txtbTipin.Validated += new System.EventHandler(this.txtbTipin_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tps Tip In Trim:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tps Tip Out disable below:";
            // 
            // txtbShiftResponse
            // 
            this.txtbShiftResponse.Location = new System.Drawing.Point(175, 47);
            this.txtbShiftResponse.Name = "txtbShiftResponse";
            this.txtbShiftResponse.Size = new System.Drawing.Size(54, 20);
            this.txtbShiftResponse.TabIndex = 3;
            this.txtbShiftResponse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbTipin_KeyPress);
            this.txtbShiftResponse.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTipin_Validating);
            this.txtbShiftResponse.Validated += new System.EventHandler(this.txtbTipin_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tps Tip Out Trim:";
            // 
            // lblTipout
            // 
            this.lblTipout.AutoSize = true;
            this.lblTipout.Location = new System.Drawing.Point(240, 51);
            this.lblTipout.Name = "lblTipout";
            this.lblTipout.Size = new System.Drawing.Size(16, 14);
            this.lblTipout.TabIndex = 4;
            this.lblTipout.Text = "M";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.ctrlAdvTable2);
            this.groupBox4.Location = new System.Drawing.Point(3, 185);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 70);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tps Tip In Fuel (normal)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 14);
            this.label13.TabIndex = 8;
            this.label13.Text = "Rate:";
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
            // ctrlAdvTable2
            // 
            this.ctrlAdvTable2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable2.Location = new System.Drawing.Point(47, 20);
            this.ctrlAdvTable2.Name = "ctrlAdvTable2";
            this.ctrlAdvTable2.Size = new System.Drawing.Size(264, 42);
            this.ctrlAdvTable2.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.ctrlAdvTable1);
            this.groupBox3.Location = new System.Drawing.Point(3, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 70);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tps Tip In Fuel (initial)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 14);
            this.label11.TabIndex = 8;
            this.label11.Text = "Rate:";
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
            // ctrlAdvTable1
            // 
            this.ctrlAdvTable1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable1.Location = new System.Drawing.Point(47, 20);
            this.ctrlAdvTable1.Name = "ctrlAdvTable1";
            this.ctrlAdvTable1.Size = new System.Drawing.Size(264, 42);
            this.ctrlAdvTable1.TabIndex = 6;
            // 
            // parmTipInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmTipInOut";
            this.Size = new System.Drawing.Size(346, 265);
            this.Load += new System.EventHandler(this.parmTipInOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
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
        this.class18_0.method_155("TPS Tip-In Fuel Initial");

        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_484 - (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) this.class18_0.method_151(this.class18_0.class13_u_0.long_484 + 1L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));

        this.class18_0.method_153();
    }

    private void method_2_X(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_484 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_484 + 1L + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3))).ToString();
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
        this.class18_0.method_155("TPS Tip-In Fuel Normal");

        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_485 - (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) this.class18_0.method_151(this.class18_0.class13_u_0.long_485 + 1L - (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));

        this.class18_0.method_153();
    }

    private void method_2_Y(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0) dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_485 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)));
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1) dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152(this.class18_0.class13_u_0.long_485 + 1L + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3))).ToString();
    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmTipInOut_Load(null, null);
        }
    }

    private void method_1()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Tip Tipin Tipout settings");
            if (this.class18_0.class13_u_0.long_43 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_43, (byte) this.class18_0.method_231(double.Parse(this.txtbShiftResponse.Text), Enum6.const_1));
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_38, this.class18_0.method_231(double.Parse(this.txtbTipin.Text), Enum6.const_0));
            if (this.class18_0.class13_u_0.long_44 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_44, this.class18_0.method_216(int.Parse(this.txtbTipoutDisableRpm.Text)));
            }
            this.class18_0.method_153();
            this.parmTipInOut_Load(null, null);
        }
    }

    private void parmTipInOut_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            this.lblTipin.Text = "M";
            this.lblTipout.Text = "M";
        }
        else
        {
            this.lblTipin.Text = "%";
            this.lblTipout.Text = "%";
        }
        this.txtbTipin.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_38), Enum6.const_0).ToString("");
        this.txtbShiftResponse.Enabled = this.class18_0.class13_u_0.long_43 != 0L;
        this.txtbTipoutDisableRpm.Enabled = this.class18_0.class13_u_0.long_44 != 0L;
        if (this.class18_0.class13_u_0.long_43 != 0L)
        {
            this.txtbShiftResponse.Text = this.class18_0.method_205(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_43), Enum6.const_1).ToString("");
        }
        if (this.class18_0.class13_u_0.long_44 != 0L)
        {
            this.txtbTipoutDisableRpm.Text = this.class18_0.method_186(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_44)).ToString();
        }
        this.bool_0 = false;
    }

    private void txtbTipin_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_1();
            }
            control.Focus();
        }
    }

    private void txtbTipin_Validated(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbTipin_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
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

    private void txtbTipoutDisableRpm_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Double Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

