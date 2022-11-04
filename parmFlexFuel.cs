using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmFlexFuel : UserControl
{
    private bool bool_0;
    private bool ChangingInput;
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableEthanol;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private IContainer components;
    private Label label4;
    private Label label3;
    private Label label2;
    private GroupBox groupBox5;
    private Label label8;
    private Label label9;
    private ctrlAdvTable ctrlAdvTableFuelCrank;
    private GroupBox groupBox3;
    private Label label6;
    private Label label7;
    private ctrlAdvTable ctrlAdvTableFuelClose;
    private GroupBox groupBox6;
    private Label label10;
    private Label label11;
    private ctrlAdvTable ctrlAdvTableIgnClose;
    private ComboBox lstInput;
    private Panel panel1;

    internal parmFlexFuel(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_6);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_6);
        this.InitializeComponent();

        this.ctrlAdvTableEthanol.method_HeaderGrayed(true);
        this.ctrlAdvTableEthanol.method_HasHeader(false);
        this.ctrlAdvTableEthanol.method_RowsNumber(2);
        this.ctrlAdvTableEthanol.method_ColumnsNumber(4);
        this.ctrlAdvTableEthanol.int_2 = 42;        //width
        this.ctrlAdvTableEthanol.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_Content);
        this.ctrlAdvTableEthanol.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_Content);
        this.ctrlAdvTableEthanol.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_Content);
        this.ctrlAdvTableEthanol.method_1(ref this.class18_0);
        this.ctrlAdvTableEthanol.method_SetIncreaser(1.0);    //increaser
        this.ctrlAdvTableEthanol.method_Load();

        this.ctrlAdvTableFuelClose.method_HeaderGrayed(true);
        this.ctrlAdvTableFuelClose.method_HasHeader(false);
        this.ctrlAdvTableFuelClose.method_RowsNumber(2);
        this.ctrlAdvTableFuelClose.method_ColumnsNumber(6);
        this.ctrlAdvTableFuelClose.int_2 = 42;        //width
        this.ctrlAdvTableFuelClose.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_FuelClose);
        this.ctrlAdvTableFuelClose.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_FuelClose);
        this.ctrlAdvTableFuelClose.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_Fuel);
        this.ctrlAdvTableFuelClose.method_1(ref this.class18_0);
        this.ctrlAdvTableFuelClose.method_SetIncreaser(1.0);    //increaser
        this.ctrlAdvTableFuelClose.method_Load();

        if (this.class18_0.RomVersion >= 116)
        {
            this.ctrlAdvTableFuelCrank.method_HeaderGrayed(true);
            this.ctrlAdvTableFuelCrank.method_HasHeader(false);
            this.ctrlAdvTableFuelCrank.method_RowsNumber(2);
            this.ctrlAdvTableFuelCrank.method_ColumnsNumber(6);
            this.ctrlAdvTableFuelCrank.int_2 = 42;        //width
            this.ctrlAdvTableFuelCrank.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_FuelCrank);
            this.ctrlAdvTableFuelCrank.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_FuelCrank);
            this.ctrlAdvTableFuelCrank.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_FuelCrank);
            this.ctrlAdvTableFuelCrank.method_1(ref this.class18_0);
            this.ctrlAdvTableFuelCrank.method_SetIncreaser(1.0);    //increaser
            this.ctrlAdvTableFuelCrank.method_Load();
        }

        this.ctrlAdvTableIgnClose.method_HeaderGrayed(true);
        this.ctrlAdvTableIgnClose.method_HasHeader(false);
        this.ctrlAdvTableIgnClose.method_RowsNumber(2);
        this.ctrlAdvTableIgnClose.method_ColumnsNumber(6);
        this.ctrlAdvTableIgnClose.int_2 = 42;        //width
        this.ctrlAdvTableIgnClose.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2_IgnClose);
        this.ctrlAdvTableIgnClose.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1_IgnClose);
        this.ctrlAdvTableIgnClose.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0_Ign);
        this.ctrlAdvTableIgnClose.method_1(ref this.class18_0);
        this.ctrlAdvTableIgnClose.method_SetIncreaser(0.25);    //increaser
        this.ctrlAdvTableIgnClose.method_Load();


        //Disable under rom version
        if (this.class18_0.RomVersion < 111)
        {
            groupBox1.Enabled = false;
        }

        if (this.class18_0.RomVersion < 116)
        {
            groupBox5.Visible = false;
        }

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void lstInput_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.ChangingInput)
        {
            if (this.lstInput.SelectedIndex != 0)
            {
                if (MessageBox.Show(Form.ActiveForm, "Do you want to set defaults values to Flex Fuel Tables?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (i <= 2) this.class18_0.method_151(this.class18_0.class13_u_0.long_461 + (i * 3) + 1L, (long)(35f * 4f));
                        else this.class18_0.method_151(this.class18_0.class13_u_0.long_461 + (i * 3) + 1L, (long) 0f);
                    }
                    if (this.class18_0.class13_u_0.long_463 != 0L) for (int i = 0; i < 6; i++) this.class18_0.method_151(this.class18_0.class13_u_0.long_463 + (i * 3) + 1L, (long)0f);
                    for (int i = 0; i < 6; i++)
                    {
                        if (i <= 2) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_464 + (i * 2) + 1L, (byte)(6f * 4f));
                        else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_464 + (i * 2) + 1L, (byte) 0f);
                    }
                }
            }
            method_5();
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrlAdvTableFuelClose = new ctrlAdvTable();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlAdvTableFuelCrank = new ctrlAdvTable();
            this.lstInput = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ctrlAdvTableIgnClose = new ctrlAdvTable();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlAdvTableEthanol = new ctrlAdvTable();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.lstInput);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ctrlAdvTableEthanol);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 372);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flex Fuel";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.ctrlAdvTableFuelClose);
            this.groupBox3.Location = new System.Drawing.Point(6, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 74);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fuel Compensation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Fuel(%):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ethanol(%):";
            // 
            // ctrlAdvTableFuelClose
            // 
            this.ctrlAdvTableFuelClose.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableFuelClose.Location = new System.Drawing.Point(76, 20);
            this.ctrlAdvTableFuelClose.Name = "ctrlAdvTableFuelClose";
            this.ctrlAdvTableFuelClose.Size = new System.Drawing.Size(289, 42);
            this.ctrlAdvTableFuelClose.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.ctrlAdvTableFuelCrank);
            this.groupBox5.Location = new System.Drawing.Point(6, 295);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(371, 74);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fuel Compensation while Cranking";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 14);
            this.label8.TabIndex = 4;
            this.label8.Text = "Fuel(%):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "Ethanol(%):";
            // 
            // ctrlAdvTableFuelCrank
            // 
            this.ctrlAdvTableFuelCrank.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableFuelCrank.Location = new System.Drawing.Point(76, 20);
            this.ctrlAdvTableFuelCrank.Name = "ctrlAdvTableFuelCrank";
            this.ctrlAdvTableFuelCrank.Size = new System.Drawing.Size(289, 42);
            this.ctrlAdvTableFuelCrank.TabIndex = 0;
            // 
            // lstInput
            // 
            this.lstInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInput.FormattingEnabled = true;
            this.lstInput.Items.AddRange(new object[] {
            "Disabled",
            "Analog D10 (ELD)",
            "Analog D12 (EGR)",
            "Analog B6 (B6)"});
            this.lstInput.Location = new System.Drawing.Point(98, 44);
            this.lstInput.Name = "lstInput";
            this.lstInput.Size = new System.Drawing.Size(177, 22);
            this.lstInput.TabIndex = 4;
            this.lstInput.SelectedIndexChanged += new System.EventHandler(this.lstInput_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.ctrlAdvTableIgnClose);
            this.groupBox6.Location = new System.Drawing.Point(6, 215);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(371, 74);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ignition Advance Compensation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "Ign(°):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "Ethanol(%):";
            // 
            // ctrlAdvTableIgnClose
            // 
            this.ctrlAdvTableIgnClose.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableIgnClose.Location = new System.Drawing.Point(76, 20);
            this.ctrlAdvTableIgnClose.Name = "ctrlAdvTableIgnClose";
            this.ctrlAdvTableIgnClose.Size = new System.Drawing.Size(289, 42);
            this.ctrlAdvTableIgnClose.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Flex Fuel (Ethanol) Input:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ethanol(%):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Voltage:";
            // 
            // ctrlAdvTableEthanol
            // 
            this.ctrlAdvTableEthanol.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableEthanol.Location = new System.Drawing.Point(118, 77);
            this.ctrlAdvTableEthanol.Name = "ctrlAdvTableEthanol";
            this.ctrlAdvTableEthanol.Size = new System.Drawing.Size(232, 42);
            this.ctrlAdvTableEthanol.TabIndex = 0;
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
            this.panel1.Size = new System.Drawing.Size(413, 405);
            this.panel1.TabIndex = 1;
            // 
            // parmFlexFuel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmFlexFuel";
            this.Size = new System.Drawing.Size(413, 405);
            this.Load += new System.EventHandler(this.parmFlexFuel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0_Content(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableEthanol.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableEthanol.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_Content(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Flex Fuel Ethanol");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_460 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)), (byte)this.class18_0.method_189_VoltageByte(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_460 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L, (byte)this.class18_0.method_189_EthanolByte(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        this.class18_0.method_153();
    }

    private void method_2_Content(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189_Voltage(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_460 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2))).ToString("0.00");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189_Ethanol(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_460 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)).ToString("0");
        }
    }

    //##############################################

    private void method_0_Fuel(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }

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
            this.ctrlAdvTableFuelClose.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableFuelClose.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_FuelClose(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Flex Fuel - Fuel Closeloop");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_461 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)), this.class18_0.method_189_EthanolByte(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_461 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3) + 1L, (long)(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4f));
        }
        this.class18_0.method_153();
    }

    private void method_2_FuelClose(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189_Ethanol(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_461 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3))).ToString("0");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_223((int)this.class18_0.method_152((this.class18_0.class13_u_0.long_461 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L)).ToString("0.0");
        }
    }

    //##############################################

    private void method_0_FuelCrank(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }

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
            this.ctrlAdvTableFuelCrank.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableFuelCrank.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_FuelCrank(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Flex Fuel - Fuel Cranking");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_463 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)), this.class18_0.method_189_EthanolByte(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_463 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3) + 1L, (long)(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4f));
        }
        this.class18_0.method_153();
    }

    private void method_2_FuelCrank(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189_Ethanol(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_463 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3))).ToString("0");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_223((int)this.class18_0.method_152((this.class18_0.class13_u_0.long_463 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 3)) + 1L)).ToString("0.0");
        }
    }

    //##############################################

    private void method_0_Ign(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableIgnClose.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableIgnClose.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1_IgnClose(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Flex Fuel - Ignition Closeloop");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_464 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)), this.class18_0.method_189_EthanolByte(double.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_464 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2) + 1L, (byte)(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4f));
        }
        this.class18_0.method_153();
    }

    private void method_2_IgnClose(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_189_Ethanol(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_464 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2))).ToString("0");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_223((int)this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_464 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)) + 1L)).ToString("0.00");
        }
    }

    private void method_5()
    {
        if (!this.bool_0)
        {
            if (this.class18_0.RomVersion >= 111)
            {
                this.class18_0.method_155("Flex Fuel - Settings");

                if (this.lstInput.SelectedIndex == 0) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_466, (byte)this.lstInput.SelectedIndex);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_466, (byte)(this.lstInput.SelectedIndex + 1));

                RestoreFlexToZero();
                if (this.lstInput.SelectedIndex == 0)
                {
                    this.ctrlAdvTableEthanol.Enabled = false;
                    this.ctrlAdvTableFuelClose.Enabled = false;
                    this.ctrlAdvTableFuelCrank.Enabled = false;
                    this.ctrlAdvTableIgnClose.Enabled = false;
                }
                else
                {
                    this.ctrlAdvTableEthanol.Enabled = true;
                    this.ctrlAdvTableFuelClose.Enabled = true;
                    this.ctrlAdvTableFuelCrank.Enabled = true;
                    this.ctrlAdvTableIgnClose.Enabled = true;
                }

                this.class18_0.method_153();
                this.parmFlexFuel_Load(null, null);
            }
        }
    }

    private void RestoreFlexToZero()
    {
        if (this.lstInput.SelectedIndex == 0)
        {
            if (this.class18_0.class13_u_0.long_461 != 0L) for (int i = 0; i < 6; i++) this.class18_0.method_151(this.class18_0.class13_u_0.long_461 + (i * 3) + 1L, (long)0f);
            if (this.class18_0.class13_u_0.long_463 != 0L) for (int i = 0; i < 6; i++) this.class18_0.method_151(this.class18_0.class13_u_0.long_463 + (i * 3) + 1L, (long)0f);
            if (this.class18_0.class13_u_0.long_464 != 0L) for (int i = 0; i < 6; i++) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_464 + (i * 2) + 1L, (byte)0f);
        }
    }

    public void method_LoadInput(byte byte_0)
    {
        this.ChangingInput = true;
        switch (byte_0)
        {
            case 0xff:
                this.lstInput.SelectedIndex = 0;
                break;

            case 0:
                this.lstInput.SelectedIndex = 0;
                break;

            case 2:
                this.lstInput.SelectedIndex = 1;
                break;

            case 3:
                this.lstInput.SelectedIndex = 2;
                break;

            case 4:
                this.lstInput.SelectedIndex = 3;
                break;
        }
        this.ChangingInput = false;
    }

    private void method_6()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmFlexFuel_Load(null, null);
        }
    }

    private void parmFlexFuel_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;

        bool flag = false;
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_512) == 0x45) flag = true;


        if (this.class18_0.RomVersion >= 111)
        {
            this.ctrlAdvTableEthanol.method_DisableHeader();
            this.ctrlAdvTableFuelClose.method_DisableHeader();
            this.ctrlAdvTableFuelCrank.method_DisableHeader();
            this.ctrlAdvTableIgnClose.method_DisableHeader();

            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi) this.ctrlAdvTableFuelClose.method_SetIncreaser(0.05);
            else this.ctrlAdvTableFuelClose.method_SetIncreaser(1.0);
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi) this.ctrlAdvTableFuelCrank.method_SetIncreaser(0.05);
            else this.ctrlAdvTableFuelCrank.method_SetIncreaser(1.0);

            this.method_LoadInput(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_466));

            RestoreFlexToZero();
            if (this.lstInput.SelectedIndex == 0)
            {
                this.ctrlAdvTableEthanol.Enabled = false;
                this.ctrlAdvTableFuelClose.Enabled = false;
                this.ctrlAdvTableFuelCrank.Enabled = false;
                this.ctrlAdvTableIgnClose.Enabled = false;
            }
            else
            {
                this.ctrlAdvTableEthanol.Enabled = true;
                this.ctrlAdvTableFuelClose.Enabled = true;
                this.ctrlAdvTableFuelCrank.Enabled = true;
                this.ctrlAdvTableIgnClose.Enabled = true;
            }

            if (!flag)
            {
                this.groupBox1.Text = "Flex Fuel";
                groupBox1.Enabled = true;
            }
            else
            {
                this.groupBox1.Text = "Flex Fuel - Can't use this with knock protection";
                groupBox1.Enabled = false;
            }
        }
        else
        {
            groupBox1.Enabled = false;
        }

        this.bool_0 = false;
    }
}

