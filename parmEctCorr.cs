using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmEctCorr : UserControl
{
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableFuel;
    private ctrlAdvTable ctrlAdvTableIgn;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private IContainer components;
    private Label label3;
    private Label label4;
    private Label label2;
    private Label label1;
    private GroupBox groupBox4;
    private Label label5;
    private Label label6;
    private ctrlAdvTable ctrlAdvTable;
    private Panel panel1;
    private IContainer icontainer_0;

    public parmEctCorr(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_7);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_7);
        this.InitializeComponent();

        this.ctrlAdvTableFuel.method_ColumnsNumber(9);
        this.ctrlAdvTableFuel.method_RowsNumber(2);
        this.ctrlAdvTableFuel.method_HasHeader(false);
        this.ctrlAdvTableFuel.method_HeaderGrayed(true);
        this.ctrlAdvTableFuel.int_2 = 42;
        this.ctrlAdvTableFuel.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_6);
        this.ctrlAdvTableFuel.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_5);
        this.ctrlAdvTableFuel.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_4);
        this.ctrlAdvTableFuel.method_21(true);
        this.ctrlAdvTableFuel.method_1(ref this.class18_0);
        this.ctrlAdvTableFuel.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTableFuel.method_Load();

        this.ctrlAdvTableIgn.method_HeaderGrayed(true);
        this.ctrlAdvTableIgn.method_HasHeader(false);
        this.ctrlAdvTableIgn.method_RowsNumber(2);
        this.ctrlAdvTableIgn.method_ColumnsNumber(10);
        this.ctrlAdvTableIgn.int_2 = 42;
        this.ctrlAdvTableIgn.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_3);
        this.ctrlAdvTableIgn.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_2);
        this.ctrlAdvTableIgn.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_1);
        this.ctrlAdvTableIgn.method_21(true);
        this.ctrlAdvTableIgn.method_1(ref this.class18_0);
        this.ctrlAdvTableIgn.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTableIgn.method_SetIncreaser(0.25);
        this.ctrlAdvTableIgn.method_Load();


        this.ctrlAdvTable.method_ColumnsNumber(9);
        this.ctrlAdvTable.int_2 = 0x24;
        this.ctrlAdvTable.method_RowsNumber(2);
        this.ctrlAdvTable.method_HasHeader(false);
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.int_2 = 42;
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_3_0);
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_0);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_0);
        this.ctrlAdvTable.method_21(true);
        this.ctrlAdvTable.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_SetIncreaser(1.0);
        this.ctrlAdvTable.method_Load();

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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlAdvTableIgn = new ctrlAdvTable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAdvTableFuel = new ctrlAdvTable();
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
            this.groupBox1.Size = new System.Drawing.Size(503, 272);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ECT Corrections";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.ctrlAdvTable);
            this.groupBox4.Location = new System.Drawing.Point(7, 193);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(490, 75);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Post Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "ECT:";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(62, 19);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(393, 42);
            this.ctrlAdvTable.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ctrlAdvTableIgn);
            this.groupBox3.Location = new System.Drawing.Point(7, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 74);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ignition Correction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trim:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "ECT:";
            // 
            // ctrlAdvTableIgn
            // 
            this.ctrlAdvTableIgn.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableIgn.Location = new System.Drawing.Point(59, 20);
            this.ctrlAdvTableIgn.Name = "ctrlAdvTableIgn";
            this.ctrlAdvTableIgn.Size = new System.Drawing.Size(426, 42);
            this.ctrlAdvTableIgn.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ctrlAdvTableFuel);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fuel Correction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "ECT(C):";
            // 
            // ctrlAdvTableFuel
            // 
            this.ctrlAdvTableFuel.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableFuel.Location = new System.Drawing.Point(59, 20);
            this.ctrlAdvTableFuel.Name = "ctrlAdvTableFuel";
            this.ctrlAdvTableFuel.Size = new System.Drawing.Size(337, 42);
            this.ctrlAdvTableFuel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 292);
            this.panel1.TabIndex = 1;
            // 
            // parmEctCorr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmEctCorr";
            this.Size = new System.Drawing.Size(528, 292);
            this.Load += new System.EventHandler(this.parmEctCorr_Load);
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

    private void method_1(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableIgn.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableIgn.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Ect ignition trim");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_177 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_177 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_221(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_3(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_177 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_177 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)).ToString("0.00");
        }
    }

    private void method_4(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Ect Fuel Settings");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_176 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_176 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte) this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_1));
        }
        this.class18_0.method_153();
    }

    private void method_5(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_176 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_176 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L), Enum6.const_1).ToString("0.00");
            }
            else
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_176 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L), Enum6.const_1);
            }
        }
    }

    private void method_6(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableFuel.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableFuel.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_7()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmEctCorr_Load(null, null);
        }
    }

    private void parmEctCorr_Load(object sender, EventArgs e)
    {
        this.label1.Text = "ECT(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";
        this.label4.Text = "ECT(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";
        this.label6.Text = "ECT(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";

        this.ctrlAdvTableFuel.method_DisableHeader();
        this.ctrlAdvTableIgn.method_DisableHeader();
        this.ctrlAdvTable.method_DisableHeader();
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            this.ctrlAdvTableFuel.method_SetIncreaser(0.05);
        }
        else
        {
            this.ctrlAdvTableFuel.method_SetIncreaser(5.0);
        }
    }


    private void method_1_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Postfuel Settings");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_178 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151((this.class18_0.class13_u_0.long_178 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L, (long)(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 1024.0));
        }
        this.class18_0.method_153();
    }

    private void method_2_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_178 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = (this.class18_0.method_152((this.class18_0.class13_u_0.long_178 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L) / 0x400L).ToString("0.00");
        }
    }

    private void method_3_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
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
            this.ctrlAdvTable.grid.CurrentCell.ErrorText = "Invalid Input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTable.grid.CurrentCell.ErrorText = "";
        }
    }
}

