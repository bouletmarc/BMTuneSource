using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmEbcCompensation : UserControl
{
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableIat;
    private ctrlAdvTable ctrlAdvTableRpm;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private IContainer components;
    private Label label3;
    private Label label4;
    private Label label2;
    private Label label1;
    private Panel panel1;
    private IContainer icontainer_0;

    public parmEbcCompensation(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_7);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_7);
        this.InitializeComponent();
        this.ctrlAdvTableIat.method_HeaderGrayed(true);
        this.ctrlAdvTableIat.method_HasHeader(false);
        this.ctrlAdvTableIat.method_RowsNumber(2);
        this.ctrlAdvTableIat.method_ColumnsNumber(5);
        this.ctrlAdvTableIat.int_2 = 42;
        this.ctrlAdvTableIat.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2);
        this.ctrlAdvTableIat.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1);
        this.ctrlAdvTableIat.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0);
        this.ctrlAdvTableIat.method_21(true);
        this.ctrlAdvTableIat.method_SetSensor(SensorsX.iatX);
        this.ctrlAdvTableRpm.method_HeaderGrayed(true);
        this.ctrlAdvTableRpm.method_HasHeader(false);
        this.ctrlAdvTableRpm.method_RowsNumber(2);
        this.ctrlAdvTableRpm.method_ColumnsNumber(11);
        this.ctrlAdvTableRpm.int_2 = 45;
        this.ctrlAdvTableRpm.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_5);
        this.ctrlAdvTableRpm.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_4);
        this.ctrlAdvTableRpm.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_3);
        this.ctrlAdvTableRpm.method_21(true);
        this.ctrlAdvTableRpm.method_SetSensor(SensorsX.rpmX);


        //this.groupBox1.Enabled = true;
        this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_264, this.class18_0.class13_u_0.long_263 });
        if (this.groupBox1.Enabled)
        {
            this.ctrlAdvTableRpm.method_1(ref this.class18_0);
            this.ctrlAdvTableRpm.method_Load();
            this.ctrlAdvTableIat.method_1(ref this.class18_0);
            this.ctrlAdvTableIat.method_Load();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlAdvTableRpm = new ctrlAdvTable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAdvTableIat = new ctrlAdvTable();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PWM Corrections";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ctrlAdvTableRpm);
            this.groupBox3.Location = new System.Drawing.Point(7, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 79);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RPM Correction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Correction:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "RPM:";
            // 
            // ctrlAdvTableRpm
            // 
            this.ctrlAdvTableRpm.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableRpm.Location = new System.Drawing.Point(78, 23);
            this.ctrlAdvTableRpm.Name = "ctrlAdvTableRpm";
            this.ctrlAdvTableRpm.Size = new System.Drawing.Size(499, 42);
            this.ctrlAdvTableRpm.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ctrlAdvTableIat);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 79);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IAT Correction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Correction:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Temp(C):";
            // 
            // ctrlAdvTableIat
            // 
            this.ctrlAdvTableIat.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableIat.Location = new System.Drawing.Point(78, 23);
            this.ctrlAdvTableIat.Name = "ctrlAdvTableIat";
            this.ctrlAdvTableIat.Size = new System.Drawing.Size(257, 42);
            this.ctrlAdvTableIat.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 220);
            this.panel1.TabIndex = 1;
            // 
            // parmEbcCompensation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmEbcCompensation";
            this.Size = new System.Drawing.Size(622, 220);
            this.Load += new System.EventHandler(this.parmEbcCompensation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_156("PWM IAT Correction", false);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_263 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_263 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_222(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_263 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_190(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_263 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)).ToString("0.00");
        }
    }

    private void method_2(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
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
            this.ctrlAdvTableIat.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableIat.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_3(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
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
            this.ctrlAdvTableRpm.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableRpm.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_4(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_156("PWM RPM Correction", false);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_264 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_217(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_264 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_222(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_5(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_187(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_264 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_190(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_264 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)).ToString("0.00");
        }
    }

    private void method_7()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmEbcCompensation_Load(null, null);
        }
    }

    private void parmEbcCompensation_Load(object sender, EventArgs e)
    {
        this.label1.Text = "Temp(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";

        if (this.class18_0.class13_u_0.long_264 != 0L)
        {
            this.ctrlAdvTableIat.method_DisableHeader();
            this.ctrlAdvTableIat.method_SetIncreaser(0.5);
        }
        if (this.class18_0.class13_u_0.long_263 != 0L)
        {
            this.ctrlAdvTableRpm.method_DisableHeader();
            this.ctrlAdvTableRpm.method_SetIncreaser(0.5);
        }
    }
}

