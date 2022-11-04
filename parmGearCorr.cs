using Controls;
using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmGearCorr : UserControl
{
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableFuel;
    private Controls.ctrlMapValue ctrlMapValue;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label1;
    private Label label4;
    private IContainer components;
    private Label label6;
    private Label label5;
    private Label label3;
    private Label label2;
    private Panel panel1;
    private NumericUpDown txtbVss;

    internal parmGearCorr(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_8);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_8);
        this.InitializeComponent();
        this.ctrlAdvTableFuel.method_RowsNumber(3);
        this.ctrlAdvTableFuel.method_ColumnsNumber(5);
        this.ctrlAdvTableFuel.int_2 = 42;
        this.ctrlAdvTableFuel.method_HeaderGrayed(true);
        this.ctrlAdvTableFuel.method_HasHeader(false);
        this.ctrlAdvTableFuel.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_7);
        this.ctrlAdvTableFuel.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_6);
        this.ctrlAdvTableFuel.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_5);
        this.ctrlAdvTableFuel.method_21(true);
        this.ctrlAdvTableFuel.method_SetSensor(SensorsX.gearX);
        this.ctrlAdvTableFuel.method_1(ref this.class18_0);
        this.ctrlAdvTableFuel.method_Load();
        this.ctrlMapValue.method_0(ref this.class18_0);
        this.ctrlMapValue.mapValueChangedDelegate_0 += new Controls.ctrlMapValue.MapValueChangedDelegate(this.method_0);

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
            this.txtbVss = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlMapValue = new Controls.ctrlMapValue();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlAdvTableFuel = new ctrlAdvTable();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbVss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbVss);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ctrlMapValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ctrlAdvTableFuel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gear Corrections";
            // 
            // txtbVss
            // 
            this.txtbVss.Location = new System.Drawing.Point(102, 22);
            this.txtbVss.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbVss.Name = "txtbVss";
            this.txtbVss.Size = new System.Drawing.Size(65, 20);
            this.txtbVss.TabIndex = 9;
            this.txtbVss.Click += new System.EventHandler(this.parmGearCorr_Load);
            this.txtbVss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbVss_KeyPress);
            this.txtbVss.Validating += new System.ComponentModel.CancelEventHandler(this.txtbVss_Validating);
            this.txtbVss.Validated += new System.EventHandler(this.parmGearCorr_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "kmh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ignition:";
            // 
            // ctrlMapValue
            // 
            this.ctrlMapValue.Enabled = false;
            this.ctrlMapValue.Location = new System.Drawing.Point(102, 47);
            this.ctrlMapValue.Name = "ctrlMapValue";
            this.ctrlMapValue.rawValue = ((byte)(0));
            this.ctrlMapValue.Size = new System.Drawing.Size(135, 23);
            this.ctrlMapValue.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fuel:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Above Load:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gear:";
            // 
            // ctrlAdvTableFuel
            // 
            this.ctrlAdvTableFuel.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableFuel.Location = new System.Drawing.Point(64, 75);
            this.ctrlAdvTableFuel.Name = "ctrlAdvTableFuel";
            this.ctrlAdvTableFuel.Size = new System.Drawing.Size(217, 62);
            this.ctrlAdvTableFuel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Above Speed:";
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
            this.panel1.Size = new System.Drawing.Size(322, 183);
            this.panel1.TabIndex = 1;
            // 
            // parmGearCorr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmGearCorr";
            this.Size = new System.Drawing.Size(322, 183);
            this.Load += new System.EventHandler(this.parmGearCorr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbVss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (this.class18_0.class13_u_0.long_189 != 0L)
        {
            this.class18_0.method_155("Gear Corrections");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_189, byte_0);
            this.class18_0.method_153();
            this.parmGearCorr_Load(null, null);
        }
    }

    private void method_5(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Gear Trim");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_186 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L, (byte) this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_1));
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_187 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L, this.class18_0.method_221(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_6(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
            {
                dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
            }
            else
            {
                dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
            }
        }
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 2)
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

    private void method_7(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_186 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L), Enum6.const_1);
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_187 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L)).ToString("0.00");
        }
    }

    private void method_8()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmGearCorr_Load(null, null);
        }
    }

    private void parmGearCorr_Load(object sender, EventArgs e)
    {
        this.label2.Text = this.class18_0.class10_settings_0.vssUnits_0.ToString();
        this.txtbVss.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_188)).ToString();
        this.ctrlAdvTableFuel.method_DisableHeader();
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            this.ctrlAdvTableFuel.method_SetIncreaser(0.05);
        }
        else
        {
            this.ctrlAdvTableFuel.method_SetIncreaser(5.0);
        }
        this.ctrlMapValue.Enabled = false;
        if (this.class18_0.class13_u_0.long_189 != 0L)
        {
            this.ctrlMapValue.Enabled = true;
            this.ctrlMapValue.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_189);
        }
    }

    private void txtbVss_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_188, this.class18_0.method_233(int.Parse(this.txtbVss.Text)));
        }
    }

    private void txtbVss_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

