using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmKnockProtection : UserControl
{
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private bool bool_1;
    private IContainer icontainer_1;
    private GroupBox groupBox4;
    private ComboBox lstInput;
    private CheckBox checkBox1;
    private Label label1;
    private IContainer components;
    private ctrlAdvTable ctrlAdvTableIgnClose;
    private Label label10;
    private Label label11;
    private Panel panel1;

    public parmKnockProtection(ref Class18 class18_1)
    {
        this.InitializeComponent();

        this.class18_0 = class18_1;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_5);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_5);

        //this.ctrlAdvTableIgnClose = new ctrlAdvTable();
        //this.ctrlAdvTableIgnClose.Font = new Font("Lucida Sans", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        //this.ctrlAdvTableIgnClose.Location = new Point(0x23, 0x99);
        //this.ctrlAdvTableIgnClose.Name = "ctrlAdvTableIgnClose";
        //this.ctrlAdvTableIgnClose.Size = new Size(520, 0x52);
        //this.ctrlAdvTableIgnClose.Enabled = false;
        //this.groupBox4.Controls.Add(this.ctrlAdvTableIgnClose);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox1.Checked)
        {
            this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_512, 0x45);
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_512 + 1L) != 0x45)
            {
                int num = 0;
                while (true)
                {
                    if (num >= 4)
                    {
                        this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_512 + 1L, 0x45);
                        break;
                    }
                    float num2 = this.class18_0.method_189(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_79 + num));
                    string s = num2.ToString("0.00");
                    this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_79 + num, this.class18_0.method_221(float.Parse(s) - 10f));
                    num++;
                }
            }
            this.lstInput.Enabled = true;
        }
        else
        {
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_512 + 1L) == 0x45)
            {
                int num3 = 0;
                while (true)
                {
                    if (num3 >= 4)
                    {
                        this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_512 + 1L, 0xff);
                        break;
                    }
                    string s = this.class18_0.method_189(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_79 + num3)).ToString("0.00");
                    this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_79 + num3, this.class18_0.method_221(float.Parse(s) + 10f));
                    num3++;
                }
            }
            this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_512, 0xff);
            this.lstInput.Enabled = false;
            this.lstInput.SelectedIndex = 0;
        }
    }

    private void parmKnockProtection_Load(object sender, EventArgs e)
    {
        bool flag = false;
        byte num = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_466);
        if ((num != 0xff) && (num != 0))
        {
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_512) == 0x45)
            {
                flag = false;
                this.lstInput.Enabled = true;
            }
            else
            {
                flag = true;
                this.lstInput.Enabled = false;
            }
        }
        if (this.class18_0.RomVersion >= 115 && !flag)
        {
            this.groupBox4.Enabled = true;
            this.checkBox1.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_512) == 0x45;
        }
        else
        {
            this.groupBox4.Text = "Knock Protection - Rom 1.15+ feature only";
            if (flag)
            {
                this.groupBox4.Text = "Knock Protection - Can't use with Flex fuel!";
            }
            this.groupBox4.Enabled = false;
        }
        this.method_3(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_466));

        this.ctrlAdvTableIgnClose.method_HeaderGrayed(true);
        this.ctrlAdvTableIgnClose.method_HasHeader(false);
        this.ctrlAdvTableIgnClose.method_RowsNumber(2);
        this.ctrlAdvTableIgnClose.method_ColumnsNumber(6);
        this.ctrlAdvTableIgnClose.int_2 = 0x2a;
        this.ctrlAdvTableIgnClose.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTableIgnClose.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTableIgnClose.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0);
        this.ctrlAdvTableIgnClose.method_1(ref this.class18_0);
        this.ctrlAdvTableIgnClose.method_SetIncreaser(0.25);
        this.ctrlAdvTableIgnClose.method_Load();
        if (this.lstInput.SelectedIndex == 0)
        {
            this.ctrlAdvTableIgnClose.Enabled = false;
            this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_466, (byte) this.lstInput.SelectedIndex);
        }
        else
        {
            this.ctrlAdvTableIgnClose.Enabled = true;
            this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_466, (byte) (this.lstInput.SelectedIndex + 1));
        }
        this.class18_0.method_153();
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ctrlAdvTableIgnClose = new ctrlAdvTable();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lstInput = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 162);
            this.panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ctrlAdvTableIgnClose);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.lstInput);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(369, 144);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Knock Protection:";
            // 
            // ctrlAdvTableIgnClose
            // 
            this.ctrlAdvTableIgnClose.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableIgnClose.Location = new System.Drawing.Point(69, 87);
            this.ctrlAdvTableIgnClose.Name = "ctrlAdvTableIgnClose";
            this.ctrlAdvTableIgnClose.Size = new System.Drawing.Size(289, 42);
            this.ctrlAdvTableIgnClose.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Ign(°):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Knock Input:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Voltage(V):";
            // 
            // lstInput
            // 
            this.lstInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInput.Enabled = false;
            this.lstInput.FormattingEnabled = true;
            this.lstInput.Items.AddRange(new object[] {
            "Disabled",
            "Analog D10 (ELD)",
            "Analog D12 (EGR)",
            "Analog B6 (B6)"});
            this.lstInput.Location = new System.Drawing.Point(92, 50);
            this.lstInput.Margin = new System.Windows.Forms.Padding(2);
            this.lstInput.Name = "lstInput";
            this.lstInput.Size = new System.Drawing.Size(153, 21);
            this.lstInput.TabIndex = 4;
            this.lstInput.SelectedIndexChanged += new System.EventHandler(this.lstInput_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 23);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Knock Protection";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // parmKnockProtection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "parmKnockProtection";
            this.Size = new System.Drawing.Size(384, 162);
            this.Load += new System.EventHandler(this.parmKnockProtection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

    }

    private void lstInput_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_1)
        {
            if (this.lstInput.SelectedIndex == 0)
            {
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_466, (byte) this.lstInput.SelectedIndex);
            }
            else
            {
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_466, (byte) (this.lstInput.SelectedIndex + 1));
            }
            if ((this.lstInput.SelectedIndex != 0) && (MessageBox.Show(Form.ActiveForm, "Do you want to set defaults values to knock Tables?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510, 0xff);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510 + 2L, 180);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510 + 4L, 0x54);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510 + 6L, 0);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510 + 1L, 0xff);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510 + 3L, 180);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510 + 5L, 0x54);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_510 + 7L, 0);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_511, 0xff);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_511 + 3L, 0xcc);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_511 + 6L, 0x99);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_511 + 9L, 0x66);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_511 + 12L, 0x33);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_511 + 15L, 0);
                this.class18_0.method_151(this.class18_0.class13_u_0.long_511 + 1L, 0L);
                this.class18_0.method_151((this.class18_0.class13_u_0.long_511 + 3L) + 1L, 0L);
                this.class18_0.method_151((this.class18_0.class13_u_0.long_511 + 6L) + 1L, 0L);
                this.class18_0.method_151((this.class18_0.class13_u_0.long_511 + 9L) + 1L, 0L);
                this.class18_0.method_151((this.class18_0.class13_u_0.long_511 + 12L) + 1L, 0L);
                this.class18_0.method_151((this.class18_0.class13_u_0.long_511 + 15L) + 1L, 0L);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514, 0xff);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514 + 2L, 0xcc);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514 + 4L, 0x99);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514 + 6L, 0x66);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514 + 8L, 0x33);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514 + 10L, 0);
                this.class18_0.SetByteAt((this.class18_0.class13_u_0.long_514 + 10L) + 1L, 40);
                this.class18_0.SetByteAt((this.class18_0.class13_u_0.long_514 + 8L) + 1L, 0x23);
                this.class18_0.SetByteAt((this.class18_0.class13_u_0.long_514 + 6L) + 1L, 30);
                this.class18_0.SetByteAt((this.class18_0.class13_u_0.long_514 + 4L) + 1L, 0x19);
                this.class18_0.SetByteAt((this.class18_0.class13_u_0.long_514 + 2L) + 1L, 15);
                this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514 + 1L, 0);
            }
            this.class18_0.method_153();
            this.method_4();
        }
    }

    private void method_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        if (!dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableIgnClose.grid.CurrentCell.ErrorText = "";
        }
        else
        {
            this.ctrlAdvTableIgnClose.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Knock Table");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            string s = smethod_0(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), 0f, 5f, 0f, 100f).ToString();
            this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_514 + ((5 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2), this.class18_0.method_189_EthanolByte(double.Parse(s)));
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            string s = smethod_0(float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()), 0f, -10f, 10f, 0f).ToString();
            this.class18_0.SetByteAt((this.class18_0.class13_u_0.long_514 + ((5 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2)) + 1L, (byte) (float.Parse(s) * 4f));
        }
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            float num = float.Parse(this.class18_0.method_189_Ethanol(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_514 + ((5 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2))).ToString("0"));
            dataGridViewCellValueEventArgs_0.Value = smethod_0(num, 100f, 0f, 5f, 0f).ToString("0.00");
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            float num4 = float.Parse(this.class18_0.method_223(this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_514 + ((5 - dataGridViewCellValueEventArgs_0.ColumnIndex) * 2)) + 1L)).ToString("0.00"));
            dataGridViewCellValueEventArgs_0.Value = smethod_0(num4, 0f, 10f, -10f, 0f).ToString("0.00");
        }
    }

    public void method_3(byte byte_0)
    {
        this.bool_1 = true;
        switch (byte_0)
        {
            case 0:
                this.lstInput.SelectedIndex = 0;
                break;

            case 1:
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

            default:
                if (byte_0 == 0xff)
                {
                    this.lstInput.SelectedIndex = 0;
                }
                break;
        }
        this.bool_1 = false;
    }

    private void method_4()
    {
        this.parmKnockProtection_Load(null, null);
    }

    private void method_5()
    {
    }

    public static float smethod_0(float float_0, float float_1, float float_2, float float_3, float float_4) => 
        ((((float_0 - float_1) / (float_2 - float_1)) * (float_4 - float_3)) + float_3);

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }
}

