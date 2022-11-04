using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmTransmission : UserControl
{
    private bool bool_0;
    private CheckBox chkCustomRatio;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox grpCustomRatio;
    private IContainer icontainer_0;
    private ComboBox lstGear;
    private IContainer components;
    private Panel panel1;
    private Button button1;
    private ctrlAdvTable ctrlAdvTable;

    internal parmTransmission(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

        this.ctrlAdvTable.method_ColumnsNumber(4);
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.method_RowsNumber(2);
        this.ctrlAdvTable.method_HasHeader(false);
        this.ctrlAdvTable.int_2 = 49;
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.method_21(true);
        this.ctrlAdvTable.method_SetSensor(SensorsX.gearX);
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2_Gear);
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1_Gear);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0_Gear);
        this.ctrlAdvTable.method_Load();

        //string[] Rows = {"0", "0", "0", "0" };
        //dataGridView1.Rows.Add(Rows);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkCustomRatio_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.grpCustomRatio.Enabled = this.chkCustomRatio.Checked;
            this.lstGear.Enabled = !this.chkCustomRatio.Checked;

            this.method_2();
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
            this.button1 = new System.Windows.Forms.Button();
            this.chkCustomRatio = new System.Windows.Forms.CheckBox();
            this.grpCustomRatio = new System.Windows.Forms.GroupBox();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.lstGear = new System.Windows.Forms.ComboBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.grpCustomRatio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chkCustomRatio);
            this.groupBox1.Controls.Add(this.grpCustomRatio);
            this.groupBox1.Controls.Add(this.lstGear);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transmission";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(51, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Gear Learning Tool";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkCustomRatio
            // 
            this.chkCustomRatio.AutoSize = true;
            this.chkCustomRatio.Location = new System.Drawing.Point(17, 56);
            this.chkCustomRatio.Name = "chkCustomRatio";
            this.chkCustomRatio.Size = new System.Drawing.Size(136, 18);
            this.chkCustomRatio.TabIndex = 3;
            this.chkCustomRatio.Text = "Enable Custom Ratio";
            this.chkCustomRatio.UseVisualStyleBackColor = true;
            this.chkCustomRatio.CheckedChanged += new System.EventHandler(this.chkCustomRatio_CheckedChanged);
            // 
            // grpCustomRatio
            // 
            this.grpCustomRatio.Controls.Add(this.ctrlAdvTable);
            this.grpCustomRatio.Location = new System.Drawing.Point(10, 81);
            this.grpCustomRatio.Name = "grpCustomRatio";
            this.grpCustomRatio.Size = new System.Drawing.Size(217, 70);
            this.grpCustomRatio.TabIndex = 9;
            this.grpCustomRatio.TabStop = false;
            this.grpCustomRatio.Text = "Based Gear Speed (Raw)";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(9, 19);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(200, 42);
            this.ctrlAdvTable.TabIndex = 11;
            // 
            // lstGear
            // 
            this.lstGear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstGear.FormattingEnabled = true;
            this.lstGear.Items.AddRange(new object[] {
            "Civic/Delsol y21/y80/s80 JDM",
            "Civic/Delsol y21/y80/s80 EDM",
            "ITR s80 JDM 96-97",
            "ITR s80 JDM 98-01",
            "ITR s80 USDM 97-01",
            "Civic/Delsol d16z6(92-95)/d16y8(96-00)",
            "Integra GSR USDM 94+",
            "Integra GSR JDM 93+ SiR-G",
            "Integra LS/RS/GS/SE 94+",
            "Prelude H22 USDM 92-96",
            "Prelude H22 JDM 92-96",
            "Prelude H23 USDM 92-96",
            "Prelude H23 JDM 92-96",
            "Civic D16Y7 96-00"});
            this.lstGear.Location = new System.Drawing.Point(17, 20);
            this.lstGear.Name = "lstGear";
            this.lstGear.Size = new System.Drawing.Size(199, 22);
            this.lstGear.TabIndex = 2;
            this.lstGear.SelectedIndexChanged += new System.EventHandler(this.lstGear_SelectedIndexChanged);
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
            this.panel1.Size = new System.Drawing.Size(252, 208);
            this.panel1.TabIndex = 1;
            // 
            // parmTransmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmTransmission";
            this.Size = new System.Drawing.Size(252, 208);
            this.Load += new System.EventHandler(this.parmTransmission_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpCustomRatio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void lstGear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_2();
        }
    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmTransmission_Load(null, null);
        }
    }

    private void method_1()
    {
        long num = 70L;
        long num2 = 0x67L;
        long num3 = 0x8eL;
        long num4 = 0xb8L;
        if (!this.chkCustomRatio.Checked)
        {
            switch (this.lstGear.SelectedIndex)
            {

                case 0:
                    num = 70L;
                    num2 = 0x67L;
                    num3 = 0x8eL;
                    num4 = 0xb8L;
                    goto Label_022A;

                case 1:
                    num = 70L;
                    num2 = 0x67L;
                    num3 = 0x8eL;
                    num4 = 0xb8L;
                    goto Label_022A;

                case 2:
                    num = 70L;
                    num2 = 0x67L;
                    num3 = 0x8eL;
                    num4 = 0xb8L;
                    goto Label_022A;

                case 3:
                    num = 0x42L;
                    num2 = 0x5dL;
                    num3 = 0x87L;
                    num4 = 0xb6L;
                    goto Label_022A;

                case 4:
                    num = 70L;
                    num2 = 100L;
                    num3 = 0x91L;
                    num4 = 0xb8L;
                    goto Label_022A;

                case 5:
                    num = 0x48L;
                    num2 = 0x71L;
                    num3 = 170L;
                    num4 = 0xe3L;
                    goto Label_022A;

                case 6:
                    num = 70L;
                    num2 = 110L;
                    num3 = 0x9aL;
                    num4 = 0xc4L;
                    goto Label_022A;

                case 7:
                    num = 70L;
                    num2 = 110L;
                    num3 = 0x9aL;
                    num4 = 0xc4L;
                    goto Label_022A;

                case 8:
                    num = 0x48L;
                    num2 = 0x71L;
                    num3 = 0xb2L;
                    num4 = 0xd6L;
                    goto Label_022A;

                case 9:
                    num = 0x47L;
                    num2 = 110L;
                    num3 = 0x9eL;
                    num4 = 0xc3L;
                    goto Label_022A;

                case 10:
                    num = 0x47L;
                    num2 = 110L;
                    num3 = 0x9eL;
                    num4 = 0xc9L;
                    goto Label_022A;

                case 11:
                    num = 0x47L;
                    num2 = 110L;
                    num3 = 0x9eL;
                    num4 = 0xc9L;
                    goto Label_022A;

                case 12:
                    num = 0x4aL;
                    num2 = 0x7bL;
                    num3 = 0xafL;
                    num4 = 0xe0L;
                    goto Label_022A;

                case 13:
                    num = 0x4bL;
                    num2 = 0x7dL;
                    num3 = 0xbcL;
                    num4 = 0xedL;
                    goto Label_022A;

                default:
                    goto Label_022A;
            }

            Label_022A:
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63, num);
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 2L, num2);
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 4L, num3);
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 6L, num4);
        }

        if (this.chkCustomRatio.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_64, 0xff);
        else
        {
            if (this.lstGear.Text == "") this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_64, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_64, (byte)this.lstGear.SelectedIndex);
        }
    }

    private void method_2()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Transmission Settings");
            this.method_1();
            this.class18_0.method_153();
            this.parmTransmission_Load(null, null);
        }
    }

    private void parmTransmission_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_64) == 0xff) this.chkCustomRatio.Checked = true;
        else
        {
            this.chkCustomRatio.Checked = false;
            this.lstGear.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_64);
        }

        this.grpCustomRatio.Enabled = this.chkCustomRatio.Checked;
        this.lstGear.Enabled = !this.chkCustomRatio.Checked;

        this.ctrlAdvTable.method_DisableHeader();
        this.bool_0 = false;
    }

    private void method_0_Gear(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Transmission Settings");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()));
        }
        this.class18_0.method_153();
    }

    private void method_1_Gear(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_152(this.class18_0.class13_u_0.long_63 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2)).ToString();
        }
    }

    private void method_2_Gear(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
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

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_255(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        this.method_2();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.class18_0.class17_0.frmMain_0.GearLearn();
    }
}

