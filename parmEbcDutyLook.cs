using Data;
using Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmEbcDutyLook : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ContextMenuStrip contextMenuStrip1;
    private ctrlAdvTable ctrlAdvTableDuty;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private IContainer components;
    private Label label3;
    private Label label2;
    private ctrlAdvTable ctrlAdvTableGear;
    private Label label5;
    private Label label1;
    private Label label6;
    private byte byte_0;
    private ctrlMapValue ctrlMapValue;
    private ctrlAdvTable ctrlAdvTableRPM;
    private Label label7;
    private Label label8;
    private Label label9;
    private Panel panel1;
    private GroupBox groupBox2;
    private Label label4;

    public parmEbcDutyLook(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_5);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_5);
        this.InitializeComponent();

        this.ctrlMapValue.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_1_3);
        this.method_0_3();
        if (this.class18_0.class13_u_0.long_262 != 0L)
        {
            this.ctrlAdvTableDuty.method_HeaderGrayed(true);
            this.ctrlAdvTableDuty.method_HasHeader(false);
            this.ctrlAdvTableDuty.method_RowsNumber(2);
            this.ctrlAdvTableDuty.method_ColumnsNumber(11);
            this.ctrlAdvTableDuty.int_2 = 45;
            this.ctrlAdvTableDuty.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_3);
            this.ctrlAdvTableDuty.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
            this.ctrlAdvTableDuty.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
            this.ctrlAdvTableDuty.method_21(true);
            this.ctrlAdvTableDuty.method_23(false);
            this.ctrlAdvTableDuty.method_SetIncreaser(0.5);
            this.ctrlAdvTableDuty.delegate5_0 += new ctrlAdvTable.Delegate5(this.method_0);
            this.ctrlAdvTableDuty.method_1(ref this.class18_0);
            this.ctrlAdvTableDuty.method_Load();
        }

        this.ctrlAdvTableGear.method_HeaderGrayed(true);
        this.ctrlAdvTableGear.method_HasHeader(false);
        this.ctrlAdvTableGear.method_RowsNumber(3);
        this.ctrlAdvTableGear.method_ColumnsNumber(5);
        this.ctrlAdvTableGear.int_2 = 45;
        this.ctrlAdvTableGear.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_4_2);
        this.ctrlAdvTableGear.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_3_2);
        this.ctrlAdvTableGear.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_2_2);
        this.ctrlAdvTableGear.method_21(true);
        this.ctrlAdvTableGear.method_SetSensor(SensorsX.gearX);
        this.ctrlAdvTableGear.delegate5_0 += new ctrlAdvTable.Delegate5(this.method_1_2);
        this.ctrlAdvTableGear.method_1(ref this.class18_0);
        this.ctrlAdvTableGear.method_Load();

        if ((this.class18_0.class13_u_0.long_260 != 0L) && (this.class18_0.class13_u_0.long_261 != 0L))
        {
            this.ctrlAdvTableRPM.delegate5_0 += new ctrlAdvTable.Delegate5(this.method_1_4);
            this.ctrlAdvTableRPM.method_1(ref this.class18_0);
            this.ctrlAdvTableRPM.method_HeaderGrayed(true);
            this.ctrlAdvTableRPM.method_HasHeader(false);
            this.ctrlAdvTableRPM.method_RowsNumber(3);
            this.ctrlAdvTableRPM.method_ColumnsNumber(11);
            this.ctrlAdvTableRPM.int_2 = 45;
            this.ctrlAdvTableRPM.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_7_4);
            this.ctrlAdvTableRPM.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_6_4);
            this.ctrlAdvTableRPM.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_5_4);
            this.ctrlAdvTableRPM.method_23(false);
            this.ctrlAdvTableRPM.method_21(true);
            this.ctrlAdvTableRPM.method_SetSensor(SensorsX.rpmX);
            this.ctrlAdvTableRPM.method_Load();
        }

        this.groupBox1.Enabled = true;

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

    internal void method_0_3()
    {
        this.ctrlMapValue.method_0(ref this.class18_0);
        this.byte_0 = this.class18_0.method_226(this.class18_0.method_250(1f));
        this.ctrlMapValue.rawValue = this.byte_0;
    }

    private void method_1_3(byte byte_1)
    {
        this.byte_0 = byte_1;
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlAdvTableRPM = new ctrlAdvTable();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlMapValue = new Controls.ctrlMapValue();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlAdvTableGear = new ctrlAdvTable();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlAdvTableDuty = new ctrlAdvTable();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ctrlAdvTableRPM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ctrlAdvTableGear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ctrlAdvTableDuty);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 306);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PWM Targets";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "High Target:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Low Target:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "RPM:";
            // 
            // ctrlAdvTableRPM
            // 
            this.ctrlAdvTableRPM.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableRPM.Location = new System.Drawing.Point(85, 227);
            this.ctrlAdvTableRPM.Name = "ctrlAdvTableRPM";
            this.ctrlAdvTableRPM.Size = new System.Drawing.Size(526, 62);
            this.ctrlAdvTableRPM.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Wastegate:";
            // 
            // ctrlMapValue
            // 
            this.ctrlMapValue.Location = new System.Drawing.Point(95, 20);
            this.ctrlMapValue.Name = "ctrlMapValue";
            this.ctrlMapValue.rawValue = ((byte)(0));
            this.ctrlMapValue.Size = new System.Drawing.Size(154, 24);
            this.ctrlMapValue.TabIndex = 7;
            this.ctrlMapValue.mapValueChangedDelegate_0 += new Controls.ctrlMapValue.MapValueChangedDelegate(this.ctrlMapValue_mapValueChangedDelegate_0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "High Target:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Low Target:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gear:";
            // 
            // ctrlAdvTableGear
            // 
            this.ctrlAdvTableGear.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableGear.Location = new System.Drawing.Point(85, 140);
            this.ctrlAdvTableGear.Name = "ctrlAdvTableGear";
            this.ctrlAdvTableGear.Size = new System.Drawing.Size(288, 62);
            this.ctrlAdvTableGear.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Duty Cycle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target PSI:";
            // 
            // ctrlAdvTableDuty
            // 
            this.ctrlAdvTableDuty.ContextMenuStrip = this.contextMenuStrip1;
            this.ctrlAdvTableDuty.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableDuty.Location = new System.Drawing.Point(85, 75);
            this.ctrlAdvTableDuty.Name = "ctrlAdvTableDuty";
            this.ctrlAdvTableDuty.Size = new System.Drawing.Size(526, 42);
            this.ctrlAdvTableDuty.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 355);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ctrlMapValue);
            this.groupBox2.Location = new System.Drawing.Point(14, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 50);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Boost(psi) vs Duty Cycle Wizard (PSI Scalar)";
            // 
            // parmEbcDutyLook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmEbcDutyLook";
            this.Size = new System.Drawing.Size(638, 355);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection_0)
    {
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("PWM Duty table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_226(this.class18_0.method_250(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()))));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_262 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_211(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_245(this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_262 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2))));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_207(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_262 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L));
        }
    }

    private void method_3(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (!this.method_4())
        {
            if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
            {
                if (dataGridViewCellValidatingEventArgs_0.ColumnIndex <= 9)
                {
                    dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
                }
                else
                {
                    dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_253(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
                }
            }
            else if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
            {
                dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_254(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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
    }

    private bool method_4()
    {
        for (int i = 0; i < this.ctrlAdvTableDuty.method_3(); i++)
        {
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_262 + (i * 2)) != 0)
            {
                return false;
            }
        }
        return true;
    }

    private void method_5()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_6(null, null);
        }
    }

    private void method_6(object sender, EventArgs e)
    {
        this.ctrlAdvTableDuty.method_DisableHeader();
        this.ctrlAdvTableGear.method_DisableHeader();
        this.ctrlAdvTableRPM.method_DisableHeader();
    }

    private void method_2_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("PWM Gear Table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_258 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L, this.class18_0.method_226(this.class18_0.method_250(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()))));
        }
        if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_259 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L, this.class18_0.method_226(this.class18_0.method_250(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()))));
        }
        this.class18_0.method_153();
    }

    private void method_3_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_245(this.class18_0.method_206(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_258 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L))).ToString("0.00");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_245(this.class18_0.method_206(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_259 + dataGridViewCellValueEventArgs_0.ColumnIndex) + 1L))).ToString("0.00");
        }
    }

    private void method_4_2(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableGear.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableGear.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_2(DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection_0)
    {
    }

    private void ctrlMapValue_mapValueChangedDelegate_0(byte raw)
    {
        byte num2 = byte_0;
        byte num3 = 0xff;
        byte num = (byte)((num3 - num2) / 9);
        byte num4 = 0;
        this.class18_0.method_155("Wastegate Scalar");
        double[] numArray = new double[10];
        byte num5 = num2;
        for (int i = 0; i < 10; i++)
        {
            numArray[i] = Math.Round((double)this.class18_0.method_245(this.class18_0.method_206(num5)), 0);
            num5 = (byte)(num5 + num);
        }
        for (int j = 0; j <= 10; j++)
        {
            switch (j)
            {
                case 0:
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (j * 2), 0xff);
                    break;

                case 10:
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (j * 2), 0);
                    break;

                default:
                    num4 = this.class18_0.method_226(this.class18_0.method_250((float)numArray[9 - j]));
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (j * 2), num4);
                    break;
            }
        }
        this.class18_0.method_153();
        this.ctrlAdvTableDuty.method_DisableHeader();
    }

    private void method_1_4(DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection_0)
    {
    }

    private void method_5_4(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("PWM RPM Table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_260 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_217(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_261 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_217(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_260 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_226(this.class18_0.method_250(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()))));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_261 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, this.class18_0.method_226(this.class18_0.method_250(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()))));
        }
        this.class18_0.method_153();
    }

    private void method_6_4(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_187(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_260 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_187(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_261 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_245(this.class18_0.method_206(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_260 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_245(this.class18_0.method_206(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_261 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)));
        }
    }

    private void method_7_4(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        else if (dataGridViewCellValidatingEventArgs_0.RowIndex == 2)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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
}

