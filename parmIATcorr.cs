using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmIATcorr : UserControl
{
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableFuel;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer components;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private Panel panel1;
    private IContainer icontainer_0;

    internal parmIATcorr(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_7);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_7);
        this.InitializeComponent();
        this.ctrlAdvTableFuel.method_HeaderGrayed(true);
        this.ctrlAdvTableFuel.method_HasHeader(false);
        this.ctrlAdvTableFuel.method_RowsNumber(5);
        this.ctrlAdvTableFuel.method_ColumnsNumber(9);
        this.ctrlAdvTableFuel.int_2 = 38;
        this.ctrlAdvTableFuel.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_6);
        this.ctrlAdvTableFuel.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_5);
        this.ctrlAdvTableFuel.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_4);
        this.ctrlAdvTableFuel.method_21(true);
        this.ctrlAdvTableFuel.method_SetSensor(SensorsX.iatX);
        this.ctrlAdvTableFuel.method_1(ref this.class18_0);
        this.ctrlAdvTableFuel.method_Load();

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
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAdvTableFuel = new ctrlAdvTable();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctrlAdvTableFuel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IAT Corrections";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ign Retard:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "High Load:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mid Load:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Low Load:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "IAT(C):";
            // 
            // ctrlAdvTableFuel
            // 
            this.ctrlAdvTableFuel.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableFuel.Location = new System.Drawing.Point(85, 20);
            this.ctrlAdvTableFuel.Name = "ctrlAdvTableFuel";
            this.ctrlAdvTableFuel.Size = new System.Drawing.Size(347, 102);
            this.ctrlAdvTableFuel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 152);
            this.panel1.TabIndex = 1;
            // 
            // parmIATcorr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmIATcorr";
            this.Size = new System.Drawing.Size(471, 152);
            this.Load += new System.EventHandler(this.parmIATcorr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_4(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_156("Iat Fuel Settings", false);
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 0x1bL, this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_175 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 0x36L, this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151((this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L, this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_0));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            this.class18_0.method_151(((this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L) + 0x1bL, this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_0));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 3)
        {
            this.class18_0.method_151(((this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L) + 0x36L, this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_0));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 4)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_175 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_221(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_5(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_175 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_203(this.class18_0.method_152((this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L), Enum6.const_0).ToString("0.00");
            }
            else
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_203(this.class18_0.method_152((this.class18_0.class13_u_0.long_174 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L), Enum6.const_0);
            }
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_203(this.class18_0.method_152(((this.class18_0.class13_u_0.long_174 + 0x1bL) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L), Enum6.const_0).ToString("0.00");
            }
            else
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_203(this.class18_0.method_152(((this.class18_0.class13_u_0.long_174 + 0x1bL) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L), Enum6.const_0);
            }
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 3)
        {
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_203(this.class18_0.method_152(((this.class18_0.class13_u_0.long_174 + 0x36L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L), Enum6.const_0).ToString("0.00");
            }
            else
            {
                dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_203(this.class18_0.method_152(((this.class18_0.class13_u_0.long_174 + 0x36L) + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L), Enum6.const_0);
            }
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 4)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_175 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)).ToString("0.00");
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
            this.parmIATcorr_Load(null, null);
        }
    }

    private void parmIATcorr_Load(object sender, EventArgs e)
    {
        this.label1.Text = "IAT(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";
        this.ctrlAdvTableFuel.method_DisableHeader();
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            this.ctrlAdvTableFuel.method_SetIncreaser(0.05);
        }
        else
        {
            this.ctrlAdvTableFuel.method_SetIncreaser(5.0);
        }
    }
}

