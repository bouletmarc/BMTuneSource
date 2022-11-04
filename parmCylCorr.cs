using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmCylCorr : UserControl
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
    private Panel panel1;
    private IContainer icontainer_0;

    public parmCylCorr(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_6);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_6);
        this.InitializeComponent();
        this.ctrlAdvTableFuel.method_RowsNumber(2);
        this.ctrlAdvTableFuel.method_ColumnsNumber(4);
        this.ctrlAdvTableFuel.int_2 = 0x26;
        this.ctrlAdvTableFuel.method_HeaderGrayed(true);
        this.ctrlAdvTableFuel.method_HasHeader(false);
        //this.ctrlAdvTableFuel.string_1 = new string[] { "Cylinder", "Fuel trim" };
        this.ctrlAdvTableFuel.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_5);
        this.ctrlAdvTableFuel.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_4);
        this.ctrlAdvTableFuel.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_3);
        this.ctrlAdvTableFuel.method_1(ref this.class18_0);
        this.ctrlAdvTableFuel.method_Load();
        this.ctrlAdvTableIgn.method_RowsNumber(2);
        this.ctrlAdvTableIgn.method_ColumnsNumber(4);
        this.ctrlAdvTableIgn.int_2 = 0x26;
        this.ctrlAdvTableIgn.method_HeaderGrayed(true);
        this.ctrlAdvTableIgn.method_HasHeader(false);
        //this.ctrlAdvTableIgn.string_1 = new string[] { "Cylinder", "Ign trim" };
        this.ctrlAdvTableIgn.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2);
        this.ctrlAdvTableIgn.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1);
        this.ctrlAdvTableIgn.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0);
        this.ctrlAdvTableIgn.method_SetIncreaser(0.25);
        this.ctrlAdvTableIgn.method_1(ref this.class18_0);
        this.ctrlAdvTableIgn.method_Load();

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
            this.ctrlAdvTableIgn = new ctrlAdvTable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAdvTableFuel = new ctrlAdvTable();
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
            this.groupBox1.Size = new System.Drawing.Size(299, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Individual Cylinder Trims";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ctrlAdvTableIgn);
            this.groupBox3.Location = new System.Drawing.Point(7, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 75);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ignition Trim (negative retard)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ignition:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cylinder:";
            // 
            // ctrlAdvTableIgn
            // 
            this.ctrlAdvTableIgn.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableIgn.Location = new System.Drawing.Point(76, 20);
            this.ctrlAdvTableIgn.Name = "ctrlAdvTableIgn";
            this.ctrlAdvTableIgn.Size = new System.Drawing.Size(181, 42);
            this.ctrlAdvTableIgn.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ctrlAdvTableFuel);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fuel Trim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fuel:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cylinder:";
            // 
            // ctrlAdvTableFuel
            // 
            this.ctrlAdvTableFuel.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableFuel.Location = new System.Drawing.Point(76, 20);
            this.ctrlAdvTableFuel.Name = "ctrlAdvTableFuel";
            this.ctrlAdvTableFuel.Size = new System.Drawing.Size(181, 42);
            this.ctrlAdvTableFuel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 207);
            this.panel1.TabIndex = 1;
            // 
            // parmCylCorr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmCylCorr";
            this.Size = new System.Drawing.Size(356, 207);
            this.Load += new System.EventHandler(this.parmCylCorr_Load);
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
        this.class18_0.method_155("Cylinder ignition trim");
        byte num = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_45);
        if (!this.class18_0.method_258(num, 0))
        {
            num = this.class18_0.method_261(num, 0, true);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_45, num);
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            int ByteLocationDifference = 1;
            //if (this.class18_0.RomVersion >= 111) ByteLocationDifference = 9;

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_184 + (dataGridViewCellValueEventArgs_0.ColumnIndex * ByteLocationDifference), this.class18_0.method_221(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            switch (dataGridViewCellValueEventArgs_0.ColumnIndex)
            {
                case 0:
                    dataGridViewCellValueEventArgs_0.Value = 1;
                    return;

                case 1:
                    dataGridViewCellValueEventArgs_0.Value = 4;
                    return;

                case 2:
                    dataGridViewCellValueEventArgs_0.Value = 2;
                    return;

                case 3:
                    dataGridViewCellValueEventArgs_0.Value = 3;
                    return;
            }
            this.class18_0.class17_0.frmMain_0.LogThis("Cyl trim error");
            //throw new Exception("Cyl trim error");
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            int ByteLocationDifference = 1;
            //if (this.class18_0.RomVersion >= 111) ByteLocationDifference = 9;

            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_184 + (dataGridViewCellValueEventArgs_0.ColumnIndex * ByteLocationDifference))).ToString("0.00");
        }
    }

    private void method_2(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
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

    private void method_3(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Cylinder fuel trim");
        byte num = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_45);
        if (!this.class18_0.method_258(num, 0))
        {
            num = this.class18_0.method_261(num, 0, true);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_45, num);
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_183 + dataGridViewCellValueEventArgs_0.ColumnIndex, (byte) this.class18_0.method_231(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), Enum6.const_1));
        }
        this.class18_0.method_153();
    }

    private void method_4(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
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

    private void method_5(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            switch (dataGridViewCellValueEventArgs_0.ColumnIndex)
            {
                case 0:
                    dataGridViewCellValueEventArgs_0.Value = 1;
                    return;

                case 1:
                    dataGridViewCellValueEventArgs_0.Value = 4;
                    return;

                case 2:
                    dataGridViewCellValueEventArgs_0.Value = 2;
                    return;

                case 3:
                    dataGridViewCellValueEventArgs_0.Value = 3;
                    return;
            }
            this.class18_0.class17_0.frmMain_0.LogThis("Cyl trim error");
            //throw new Exception("Cyl trim error");
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_205(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_183 + dataGridViewCellValueEventArgs_0.ColumnIndex), Enum6.const_1);
        }
    }

    private void method_6()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmCylCorr_Load(null, null);
        }
    }

    private void parmCylCorr_Load(object sender, EventArgs e)
    {
        this.ctrlAdvTableFuel.method_DisableHeader();
        this.ctrlAdvTableIgn.method_DisableHeader();
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

