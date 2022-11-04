using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmCrankFuel : UserControl
{
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTable;
    private GroupBox groupBox1;
    private IContainer components;
    private Label label1;
    private Label label2;
    private Panel panel1;
    private GroupBox groupBox6;
    private Label label34;
    private Label label35;
    private ctrlAdvTable ctrlAdvTableMAP;
    private Label label32;
    private Label label33;
    private ctrlAdvTable ctrlAdvTableRPM;
    private IContainer icontainer_0;

    public parmCrankFuel(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_4);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_4);
        this.InitializeComponent();

        this.ctrlAdvTable.method_ColumnsNumber(9);
        this.ctrlAdvTable.int_2 = 0x24;
        this.ctrlAdvTable.method_RowsNumber(2);
        this.ctrlAdvTable.method_HasHeader(false); //header
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_3);
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTable.method_21(true);
        this.ctrlAdvTable.method_SetSensor(SensorsX.ectX);
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_SetIncreaser(50.0);
        //this.ctrlAdvTable.delegate3_0 += new ctrlAdvTable.Delegate3(this.method_0);
        this.ctrlAdvTable.method_Load();


        this.ctrlAdvTableRPM.method_ColumnsNumber(2);
        this.ctrlAdvTableRPM.method_RowsNumber(2);
        this.ctrlAdvTableRPM.int_2 = 50;
        this.ctrlAdvTableRPM.method_HasHeader(false);
        this.ctrlAdvTableRPM.method_HeaderGrayed(true);
        this.ctrlAdvTableRPM.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_RPM);
        this.ctrlAdvTableRPM.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_RPM);
        this.ctrlAdvTableRPM.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_RPM);
        this.ctrlAdvTableRPM.method_21(false);
        this.ctrlAdvTableRPM.method_23(false);
        this.ctrlAdvTableRPM.method_1(ref this.class18_0);
        this.ctrlAdvTableRPM.method_SetIncreaser(0.25);
        this.ctrlAdvTableRPM.method_Load();

        this.ctrlAdvTableMAP.method_ColumnsNumber(2);
        this.ctrlAdvTableMAP.method_RowsNumber(2);
        this.ctrlAdvTableMAP.int_2 = 50;
        this.ctrlAdvTableMAP.method_HasHeader(false);
        this.ctrlAdvTableMAP.method_HeaderGrayed(true);
        this.ctrlAdvTableMAP.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_MAP);
        this.ctrlAdvTableMAP.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_MAP);
        this.ctrlAdvTableMAP.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_MAP);
        this.ctrlAdvTableMAP.method_21(false);
        this.ctrlAdvTableMAP.method_23(false);
        this.ctrlAdvTableMAP.method_1(ref this.class18_0);
        this.ctrlAdvTableRPM.method_SetIncreaser(0.25);
        this.ctrlAdvTableMAP.method_Load();

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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.ctrlAdvTableMAP = new ctrlAdvTable();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.ctrlAdvTableRPM = new ctrlAdvTable();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctrlAdvTable);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cranking Fuel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "FUEL:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "ECT(C):";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(57, 20);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(325, 42);
            this.ctrlAdvTable.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 173);
            this.panel1.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.ctrlAdvTableMAP);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.ctrlAdvTableRPM);
            this.groupBox6.Location = new System.Drawing.Point(3, 87);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(391, 66);
            this.groupBox6.TabIndex = 43;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "RPM/MAP Cranking Fuel Compensation";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(175, 46);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(33, 14);
            this.label34.TabIndex = 22;
            this.label34.Text = "FV %:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(175, 20);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(36, 14);
            this.label35.TabIndex = 21;
            this.label35.Text = "mBar:";
            // 
            // ctrlAdvTableMAP
            // 
            this.ctrlAdvTableMAP.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableMAP.Location = new System.Drawing.Point(217, 18);
            this.ctrlAdvTableMAP.Name = "ctrlAdvTableMAP";
            this.ctrlAdvTableMAP.Size = new System.Drawing.Size(106, 42);
            this.ctrlAdvTableMAP.TabIndex = 20;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(7, 46);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(33, 14);
            this.label32.TabIndex = 19;
            this.label32.Text = "FV %:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(7, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 14);
            this.label33.TabIndex = 18;
            this.label33.Text = "RPM:";
            // 
            // ctrlAdvTableRPM
            // 
            this.ctrlAdvTableRPM.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableRPM.Location = new System.Drawing.Point(49, 18);
            this.ctrlAdvTableRPM.Name = "ctrlAdvTableRPM";
            this.ctrlAdvTableRPM.Size = new System.Drawing.Size(106, 42);
            this.ctrlAdvTableRPM.TabIndex = 9;
            // 
            // parmCrankFuel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmCrankFuel";
            this.Size = new System.Drawing.Size(411, 173);
            this.Load += new System.EventHandler(this.parmCrankFuel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

    }

    /*private void method_0(ctrlAdvGraph ctrlAdvGraph_0)
    {
        if (ctrlAdvGraph_0 != null)
        {
            this.grpGraph.Visible = true;
            if (this.grpGraph.Controls.Count > 0)
            {
                this.grpGraph.Controls[0].Dispose();
            }
            this.grpGraph.Controls.Clear();
            this.grpGraph.Controls.Add(ctrlAdvGraph_0);
            ctrlAdvGraph_0.Dock = DockStyle.Fill;
            ctrlAdvGraph_0.Invalidate();
        }
    }*/

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Crank Fuel Settings");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_179 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3), this.class18_0.method_230(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151((this.class18_0.class13_u_0.long_179 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L, (long) (double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4.0));
        }
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_179 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = ((int) (this.class18_0.method_152((this.class18_0.class13_u_0.long_179 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L) / 4L)).ToString("0");
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
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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

    private void method_0_RPM(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableRPM.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableRPM.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_RPM(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Cranking Fuel RPM Compensation Settings");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            //text1 = +2 index  rpm = 18
            //text2 = index     rpm = 48
            //text1 = +3 index  FV = -29.7
            //text1 = +1 index  FV 0
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_453 + 2, (byte)int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_453, (byte)int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_453 + 3, (byte)(((double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128) / 100) + 128));
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_453 + 1, (byte)(((double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128) / 100) + 128));
        }
        this.class18_0.method_153();
    }

    private void method_2_RPM(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) dataGridViewCellValueEventArgs_0.Value = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_453 + 2).ToString();
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) dataGridViewCellValueEventArgs_0.Value = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_453).ToString();
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) dataGridViewCellValueEventArgs_0.Value = (((((double) this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_453 + 3) - 128) * 100) / 128)).ToString("0.00");
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) dataGridViewCellValueEventArgs_0.Value = (((((double) this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_453 + 1) - 128) * 100) / 128)).ToString("0.00");
        }
    }

    private void method_0_MAP(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableMAP.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableMAP.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_MAP(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Cranking Fuel MAP Compensation Settings");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            //text1 = +2 index  rpm = 18
            //text2 = index     rpm = 48
            //text1 = +3 index  FV = -29.7
            //text1 = +1 index  FV 0
            //if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) this.class18_0.method_149(this.class18_0.class13_0.long_454 + 2, (byte)int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));
            //if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) this.class18_0.method_149(this.class18_0.class13_0.long_454, (byte)int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_454 + 3, (byte)(((double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128) / 100) + 128));
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_454 + 1, (byte)(((double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 128) / 100) + 128));
        }
        this.class18_0.method_153();
    }

    private void method_2_MAP(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) dataGridViewCellValueEventArgs_0.Value = (540).ToString();
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) dataGridViewCellValueEventArgs_0.Value = (961).ToString();
            //if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) dataGridViewCellValueEventArgs_0.Value = ((float)this.class18_0.method_206(this.class18_0.method_150(this.class18_0.class13_0.long_454 + 2))).ToString();
            //if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) dataGridViewCellValueEventArgs_0.Value = ((float)this.class18_0.method_206(this.class18_0.method_150(this.class18_0.class13_0.long_454))).ToString();
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 0) dataGridViewCellValueEventArgs_0.Value = (((((double) this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_454 + 3) - 128) * 100) / 128)).ToString("0.00");
            if (dataGridViewCellValueEventArgs_0.ColumnIndex == 1) dataGridViewCellValueEventArgs_0.Value = (((((double) this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_454 + 1) - 128) * 100) / 128)).ToString("0.00");
        }
    }

    private void method_4()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmCrankFuel_Load(null, null);
        }
    }

    private void parmCrankFuel_Load(object sender, EventArgs e)
    {
        this.ctrlAdvTable.method_DisableHeader();

        this.label1.Text = "ECT(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";
    }
}

