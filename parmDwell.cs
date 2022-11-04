using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmDwell : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableBat;
    private ctrlAdvTable ctrlAdvTableRpm1;
    private ctrlAdvTable ctrlAdvTableRpm2;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private IContainer icontainer_0;
    private IContainer components;
    private Label label4;
    private Label label5;
    private Label label3;
    private Label label6;
    private Label label7;
    private Panel panel1;
    private Label label2;

    public parmDwell(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_10);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_10);
        this.InitializeComponent();
        this.ctrlAdvTableRpm1.method_HeaderGrayed(true);
        this.ctrlAdvTableRpm1.method_HasHeader(false);
        this.ctrlAdvTableRpm1.method_RowsNumber(2);
        this.ctrlAdvTableRpm1.method_ColumnsNumber(7);
        this.ctrlAdvTableRpm1.int_2 = 45;
        this.ctrlAdvTableRpm1.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_9);
        this.ctrlAdvTableRpm1.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_8);
        this.ctrlAdvTableRpm1.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_7);
        this.ctrlAdvTableRpm1.method_21(true);
        this.ctrlAdvTableRpm1.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTableRpm1.method_23(false);
        this.ctrlAdvTableRpm1.method_1(ref this.class18_0);
        this.ctrlAdvTableRpm1.method_SetIncreaser(0.25);
        this.ctrlAdvTableRpm1.method_Load();
        this.ctrlAdvTableRpm2.method_HeaderGrayed(true);
        this.ctrlAdvTableRpm2.method_HasHeader(false);
        this.ctrlAdvTableRpm2.method_RowsNumber(2);
        this.ctrlAdvTableRpm2.method_ColumnsNumber(8);
        this.ctrlAdvTableRpm2.int_2 = 42;
        this.ctrlAdvTableRpm2.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_5);
        this.ctrlAdvTableRpm2.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_4);
        this.ctrlAdvTableRpm2.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_3);
        this.ctrlAdvTableRpm2.method_21(true);
        this.ctrlAdvTableRpm2.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTableRpm2.method_23(false);
        this.ctrlAdvTableRpm2.method_1(ref this.class18_0);
        this.ctrlAdvTableRpm2.method_SetIncreaser(1.0);
        if (this.class18_0.class13_u_0.long_375 != 0L)
        {
            this.ctrlAdvTableRpm2.method_Load();
        }
        this.ctrlAdvTableBat.method_HeaderGrayed(true);
        this.ctrlAdvTableBat.method_HasHeader(false);
        this.ctrlAdvTableBat.method_RowsNumber(2);
        this.ctrlAdvTableBat.method_ColumnsNumber(10);
        this.ctrlAdvTableBat.int_2 = 42;
        this.ctrlAdvTableBat.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTableBat.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTableBat.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0);
        this.ctrlAdvTableBat.method_21(true);
        this.ctrlAdvTableBat.method_SetSensor(SensorsX.batV);
        this.ctrlAdvTableBat.method_23(false);
        this.ctrlAdvTableBat.method_1(ref this.class18_0);
        this.ctrlAdvTableBat.method_SetIncreaser(1.0);
        if (this.class18_0.class13_u_0.long_376 != 0L)
        {
            this.ctrlAdvTableBat.method_Load();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrlAdvTableBat = new ctrlAdvTable();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlAdvTableRpm2 = new ctrlAdvTable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlAdvTableRpm1 = new ctrlAdvTable();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dwell Control";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.ctrlAdvTableBat);
            this.groupBox4.Location = new System.Drawing.Point(7, 178);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(498, 72);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Battery";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Multiplier:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "Voltage:";
            // 
            // ctrlAdvTableBat
            // 
            this.ctrlAdvTableBat.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableBat.Location = new System.Drawing.Point(68, 20);
            this.ctrlAdvTableBat.Name = "ctrlAdvTableBat";
            this.ctrlAdvTableBat.Size = new System.Drawing.Size(425, 42);
            this.ctrlAdvTableBat.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ctrlAdvTableRpm2);
            this.groupBox3.Location = new System.Drawing.Point(7, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 72);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phasing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Advance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "RPM:";
            // 
            // ctrlAdvTableRpm2
            // 
            this.ctrlAdvTableRpm2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableRpm2.Location = new System.Drawing.Point(68, 20);
            this.ctrlAdvTableRpm2.Name = "ctrlAdvTableRpm2";
            this.ctrlAdvTableRpm2.Size = new System.Drawing.Size(365, 42);
            this.ctrlAdvTableRpm2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ctrlAdvTableRpm1);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 72);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ignition Advance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Advance:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "RPM:";
            // 
            // ctrlAdvTableRpm1
            // 
            this.ctrlAdvTableRpm1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableRpm1.Location = new System.Drawing.Point(68, 20);
            this.ctrlAdvTableRpm1.Name = "ctrlAdvTableRpm1";
            this.ctrlAdvTableRpm1.Size = new System.Drawing.Size(365, 42);
            this.ctrlAdvTableRpm1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 291);
            this.panel1.TabIndex = 1;
            // 
            // parmDwell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmDwell";
            this.Size = new System.Drawing.Size(538, 291);
            this.Load += new System.EventHandler(this.parmDwell_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableBat.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableBat.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Dwell battery table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_376 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), (byte) ((float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) - 6.26) / 0.052));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_376 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte) this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_2));
        }
        this.class18_0.method_153();
    }

    private void method_10()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmDwell_Load(null, null);
        }
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = ((this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_376 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) * 0.052) + 6.26).ToString("0.00");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_376 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L), Enum6.const_2);
        }
    }

    private void method_3(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableRpm2.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableRpm2.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_4(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_156("Dwell Rpm table", false);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_375 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_217(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_375 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte) ((float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 16f) + 16f));
        }
        this.class18_0.method_153();
    }

    private void method_5(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_187(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_375 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = ((this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_375 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L) / 0x10) - 1f).ToString("0");
        }
    }

    private void method_7(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableRpm1.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableRpm1.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_8(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_156("Dwell Base Rpm table", false);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_374 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_217(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_374 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte) (float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4f));
        }
        this.class18_0.method_153();
    }

    private void method_9(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_187(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_374 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = (((float) this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_374 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)) / 4f).ToString("0.00");
        }
    }

    private void parmDwell_Load(object sender, EventArgs e)
    {
        this.ctrlAdvTableRpm1.method_DisableHeader();
        if (this.class18_0.class13_u_0.long_375 != 0L)
        {
            this.ctrlAdvTableRpm2.method_DisableHeader();
        }
        if (this.class18_0.class13_u_0.long_376 != 0L)
        {
            this.ctrlAdvTableBat.method_DisableHeader();
        }
    }
}

