using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmGPO1_if : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableFuel;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private IContainer components;
    private Label label3;
    private Label label2;
    private Panel panel1;
    private Label label1;

    internal parmGPO1_if(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_6);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_6);
        this.InitializeComponent();
        this.ctrlAdvTableFuel.method_21(true);
        this.ctrlAdvTableFuel.method_SetSensor(SensorsX.rpmX);
        this.ctrlAdvTableFuel.method_23(false);
        this.ctrlAdvTableFuel.method_HeaderGrayed(true);
        this.ctrlAdvTableFuel.method_HasHeader(false);
        this.ctrlAdvTableFuel.method_RowsNumber(3);
        this.ctrlAdvTableFuel.method_ColumnsNumber(11);
        this.ctrlAdvTableFuel.int_2 = 45;
        this.ctrlAdvTableFuel.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2);
        this.ctrlAdvTableFuel.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1);
        this.ctrlAdvTableFuel.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0);

        this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_311, this.class18_0.class13_u_0.long_310 });
        if (this.groupBox1.Enabled)
        {
            this.ctrlAdvTableFuel.method_Load();
            this.ctrlAdvTableFuel.method_1(ref this.class18_0);
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAdvTableFuel = new ctrlAdvTable();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctrlAdvTableFuel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPO 1 Fuel && Ignition Corrections:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ign Retard:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fuel (neg):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "RPM:";
            // 
            // ctrlAdvTableFuel
            // 
            this.ctrlAdvTableFuel.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableFuel.Location = new System.Drawing.Point(81, 20);
            this.ctrlAdvTableFuel.Name = "ctrlAdvTableFuel";
            this.ctrlAdvTableFuel.Size = new System.Drawing.Size(540, 64);
            this.ctrlAdvTableFuel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 138);
            this.panel1.TabIndex = 1;
            // 
            // parmGPO1_if
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmGPO1_if";
            this.Size = new System.Drawing.Size(650, 138);
            this.Load += new System.EventHandler(this.parmGPO1_if_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_156("GPO 1 Fuel Trim", false);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_311 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), this.class18_0.method_217(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_310 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_217(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            long num = (long) (float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4f);
            if (num >= 0L)
            {
                num += 0x8000L;
            }
            else
            {
                num = 0x8000L - (num * -1L);
            }
            this.class18_0.method_151((this.class18_0.class13_u_0.long_311 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L, num);
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_310 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_221(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_187(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_311 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            int num = (int) this.class18_0.method_152((this.class18_0.class13_u_0.long_311 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L);
            if (num >= 0x8000)
            {
                num -= 0x8000;
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_223(num);
            }
            else
            {
                num = 0x8000 - num;
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_223(num) * -1.0;
            }
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_310 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)).ToString("0.00");
        }
    }

    private void method_2(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
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
            this.ctrlAdvTableFuel.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableFuel.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_6()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmGPO1_if_Load(null, null);
        }
    }

    private void parmGPO1_if_Load(object sender, EventArgs e)
    {
        this.ctrlAdvTableFuel.method_DisableHeader();
    }
}

