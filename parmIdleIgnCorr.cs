using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmIdleIgnCorr : UserControl
{
    private bool bool_0;
    private CheckBox chkEnable;
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTableIdleIgn;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label1;
    private IContainer components;
    private Label label4;
    private Label label3;
    private Label lblEct;
    private NumericUpDown txtbEct;
    private Panel panel1;

    internal parmIdleIgnCorr(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_6);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_6);
        this.InitializeComponent();
        this.ctrlAdvTableIdleIgn.method_HeaderGrayed(true);
        this.ctrlAdvTableIdleIgn.method_HasHeader(false);
        this.ctrlAdvTableIdleIgn.method_RowsNumber(2);
        this.ctrlAdvTableIdleIgn.method_ColumnsNumber(8);
        this.ctrlAdvTableIdleIgn.int_2 = 34;
        this.ctrlAdvTableIdleIgn.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_2);
        this.ctrlAdvTableIdleIgn.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_1);
        this.ctrlAdvTableIdleIgn.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_0);
        this.ctrlAdvTableIdleIgn.method_21(false);
        this.ctrlAdvTableIdleIgn.method_SetSensor(SensorsX.tpsX);
        this.ctrlAdvTableIdleIgn.method_23(false);
        this.ctrlAdvTableIdleIgn.method_1(ref this.class18_0);
        this.ctrlAdvTableIdleIgn.method_SetIncreaser(0.25);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        this.method_5();
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
            this.txtbEct = new System.Windows.Forms.NumericUpDown();
            this.lblEct = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlAdvTableIdleIgn = new ctrlAdvTable();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbEct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbEct);
            this.groupBox1.Controls.Add(this.lblEct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ctrlAdvTableIdleIgn);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Idle Ignition Correction";
            // 
            // txtbEct
            // 
            this.txtbEct.Location = new System.Drawing.Point(301, 21);
            this.txtbEct.Maximum = new decimal(new int[] {
            284,
            0,
            0,
            0});
            this.txtbEct.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.txtbEct.Name = "txtbEct";
            this.txtbEct.Size = new System.Drawing.Size(51, 20);
            this.txtbEct.TabIndex = 1;
            this.txtbEct.Click += new System.EventHandler(this.txtbEct_Validated);
            this.txtbEct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEct_KeyPress);
            this.txtbEct.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEct_Validating);
            this.txtbEct.Validated += new System.EventHandler(this.txtbEct_Validated);
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(360, 25);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 24;
            this.lblEct.Text = "C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ignition Adjust:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Idle Difference:";
            // 
            // ctrlAdvTableIdleIgn
            // 
            this.ctrlAdvTableIdleIgn.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTableIdleIgn.Location = new System.Drawing.Point(99, 51);
            this.ctrlAdvTableIdleIgn.Name = "ctrlAdvTableIdleIgn";
            this.ctrlAdvTableIdleIgn.Size = new System.Drawing.Size(278, 42);
            this.ctrlAdvTableIdleIgn.TabIndex = 0;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(12, 24);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(167, 18);
            this.chkEnable.TabIndex = 2;
            this.chkEnable.Text = "Idle Ignition Adjustements";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Above ECT:";
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
            this.panel1.Size = new System.Drawing.Size(415, 141);
            this.panel1.TabIndex = 1;
            // 
            // parmIdleIgnCorr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmIdleIgnCorr";
            this.Size = new System.Drawing.Size(415, 141);
            this.Load += new System.EventHandler(this.parmIdleIgnCorr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbEct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_252(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTableIdleIgn.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTableIdleIgn.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Idle Ign Correction");
        if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex < 4)
            {
                byte num = (byte) (float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4f);
                if (num > 14)
                {
                    num = 14;
                }
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_191 + ((dataGridViewCellValueEventArgs_0.ColumnIndex * 4) + 2), num);
            }
            else
            {
                int num2 = dataGridViewCellValueEventArgs_0.ColumnIndex - 4;
                byte num3 = (byte) ((float.Parse(dataGridViewCellValueEventArgs_0.Value.ToString()) * 4f) * -1f);
                if (num3 > 14)
                {
                    num3 = 14;
                }
                this.class18_0.method_149_SetByte((this.class18_0.class13_u_0.long_191 + 30L) - (num2 * 4), num3);
            }
        }
        this.class18_0.method_153();
    }

    private void method_2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            long num = 0L;
            if (dataGridViewCellValueEventArgs_0.ColumnIndex < 4)
            {
                num = this.class18_0.method_152(this.class18_0.class13_u_0.long_191 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 4));
                if (num > 0x300L)
                {
                    num = 0x300L;
                }
                dataGridViewCellValueEventArgs_0.Value = this.method_4(num) * -1;
            }
            else
            {
                int num2 = dataGridViewCellValueEventArgs_0.ColumnIndex - 4;
                num = this.class18_0.method_152((this.class18_0.class13_u_0.long_191 + 0x1cL) - (num2 * 4));
                if (num > 0x300L)
                {
                    num = 0x300L;
                }
                dataGridViewCellValueEventArgs_0.Value = this.method_4(num);
            }
        }
        else if (dataGridViewCellValueEventArgs_0.RowIndex == 1)
        {
            if (dataGridViewCellValueEventArgs_0.ColumnIndex < 4)
            {
                byte num3 = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_191 + ((dataGridViewCellValueEventArgs_0.ColumnIndex * 4) + 2));
                if (num3 > 14)
                {
                    num3 = 14;
                }
                dataGridViewCellValueEventArgs_0.Value = Math.Round((double) (((float) num3) / 4f), 2);
            }
            else
            {
                int num4 = dataGridViewCellValueEventArgs_0.ColumnIndex - 4;
                byte num5 = this.class18_0.GetByteAt((this.class18_0.class13_u_0.long_191 + 30L) - (num4 * 4));
                if (num5 > 14)
                {
                    num5 = 14;
                }
                dataGridViewCellValueEventArgs_0.Value = -1.0 * Math.Round((double) (((float) num5) / 4f), 2);
            }
        }
    }

    private int method_4(long long_0)
    {
        long num = this.class18_0.method_219(0x3e8);
        int num2 = this.class18_0.method_218(num + long_0);
        return (0x3e8 - num2);
    }

    private void method_5()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Idle Ignition Correction");
            if (this.chkEnable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_192, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_192, 0);
            }
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_193, this.class18_0.method_230((double) int.Parse(this.txtbEct.Text)));
            this.class18_0.method_153();
            this.parmIdleIgnCorr_Load(null, null);
        }
    }

    private void method_6()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmIdleIgnCorr_Load(null, null);
        }
    }

    private void parmIdleIgnCorr_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;

        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();

        this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_191, this.class18_0.class13_u_0.long_193, this.class18_0.class13_u_0.long_192 });
        if (this.groupBox1.Enabled)
        {
            if (this.class18_0.class13_u_0.long_191 != 0L)
            {
                this.ctrlAdvTableIdleIgn.method_Load();
            }
            if (this.class18_0.class13_u_0.long_193 != 0L)
            {
                this.txtbEct.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_193)).ToString();
            }
            if (this.class18_0.class13_u_0.long_192 != 0L)
            {
                this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_192) == 0xff;
            }

            if (!this.chkEnable.Checked)
            {
                this.txtbEct.Enabled = false;
                this.ctrlAdvTableIdleIgn.Enabled = false;
            }
            else
            {
                this.txtbEct.Enabled = true;
                this.ctrlAdvTableIdleIgn.Enabled = true;
            }
            this.bool_0 = false;
        }
    }

    private void txtbEct_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_5();
            }
            control.Focus();
        }
    }

    private void txtbEct_Validated(object sender, EventArgs e)
    {
        this.method_5();
    }

    private void txtbEct_Validating(object sender, CancelEventArgs e)
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

