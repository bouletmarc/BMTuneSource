using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmSCC : UserControl
{
    private bool bool_0;
    private CheckBox chkCust;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInputSelector1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private IContainer components;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private Label label3;
    private Label label4;
    private ComboBox comboBox1;
    private Label label6;
    private GroupBox groupBox5;
    private Label label9;
    private Label label8;
    private Label label5;
    private Panel panel1;
    private NumericUpDown txtbMilFlash;
    private NumericUpDown txtbSync;
    private Button buttonIgnSync;
    private NumericUpDown txtbPrime;
    private frmIgnitionSync frmIgnitionSync_0;

    internal parmSCC(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.LoadPage);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.LoadPage);
        this.InitializeComponent();

        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInputSelector1.method_3_CustomInput("Always On");
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(true);
        this.ctrlInputSelector1.method_5(false);
        //this.ctrlInputSelector1.method_1(0);
        this.ctrlInputSelector1.method_Input_location(this.class18_0.class13_u_0.long_114);

        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(true);
        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(false);
        //this.ctrlInputSelector1.method_1(0);
        this.ctrlInputSelector1.method_14(ref this.class18_0);
        this.ctrlInputSelector1.method_12();
        this.ctrlInputSelector1.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_3);
        this.ctrlInputSelector1.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_0);
        
        this.groupBox5.Enabled= true;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkCust_CheckedChanged(object sender, EventArgs e)
    {
        this.method_2();
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
            this.ctrlInputSelector1 = new CtrlInputSelector();
            this.chkCust = new System.Windows.Forms.CheckBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonIgnSync = new System.Windows.Forms.Button();
            this.txtbSync = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbPrime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtbMilFlash = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSync)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbPrime)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMilFlash)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctrlInputSelector1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Check Connector Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 2;
            // 
            // ctrlInputSelector1
            // 
            this.ctrlInputSelector1.Location = new System.Drawing.Point(7, 18);
            this.ctrlInputSelector1.Name = "ctrlInputSelector1";
            this.ctrlInputSelector1.Size = new System.Drawing.Size(215, 51);
            this.ctrlInputSelector1.TabIndex = 0;
            // 
            // chkCust
            // 
            this.chkCust.AutoSize = true;
            this.chkCust.Location = new System.Drawing.Point(15, 22);
            this.chkCust.Name = "chkCust";
            this.chkCust.Size = new System.Drawing.Size(113, 18);
            this.chkCust.TabIndex = 4;
            this.chkCust.Text = "Lock Ignition At:";
            this.chkCust.UseVisualStyleBackColor = true;
            this.chkCust.CheckedChanged += new System.EventHandler(this.chkCust_CheckedChanged);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonIgnSync);
            this.groupBox2.Controls.Add(this.txtbSync);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkCust);
            this.groupBox2.Location = new System.Drawing.Point(3, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 74);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ignition Lock";
            // 
            // buttonIgnSync
            // 
            this.buttonIgnSync.Location = new System.Drawing.Point(15, 45);
            this.buttonIgnSync.Name = "buttonIgnSync";
            this.buttonIgnSync.Size = new System.Drawing.Size(197, 23);
            this.buttonIgnSync.TabIndex = 15;
            this.buttonIgnSync.Text = "Open Ignition Sync Calibration";
            this.buttonIgnSync.UseVisualStyleBackColor = true;
            this.buttonIgnSync.Click += new System.EventHandler(this.ButtonIgnSync_Click);
            // 
            // txtbSync
            // 
            this.txtbSync.DecimalPlaces = 2;
            this.txtbSync.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.txtbSync.Location = new System.Drawing.Point(135, 19);
            this.txtbSync.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.txtbSync.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.txtbSync.Name = "txtbSync";
            this.txtbSync.Size = new System.Drawing.Size(52, 20);
            this.txtbSync.TabIndex = 14;
            this.txtbSync.Click += new System.EventHandler(this.txtbPrime_Validated);
            this.txtbSync.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbSync_KeyPress);
            this.txtbSync.Validating += new System.ComponentModel.CancelEventHandler(this.txtbSync_Validating);
            this.txtbSync.Validated += new System.EventHandler(this.chkCust_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "°";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbPrime);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Location = new System.Drawing.Point(3, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 81);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fuel Pump Control";
            // 
            // txtbPrime
            // 
            this.txtbPrime.DecimalPlaces = 1;
            this.txtbPrime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtbPrime.Location = new System.Drawing.Point(135, 51);
            this.txtbPrime.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            65536});
            this.txtbPrime.Name = "txtbPrime";
            this.txtbPrime.Size = new System.Drawing.Size(46, 20);
            this.txtbPrime.TabIndex = 13;
            this.txtbPrime.Click += new System.EventHandler(this.txtbPrime_Validated);
            this.txtbPrime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbPrime_KeyPress);
            this.txtbPrime.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPrime_Validating);
            this.txtbPrime.Validated += new System.EventHandler(this.txtbPrime_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Prime Duration:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal",
            "Always On (Drain Tank)",
            "Always Off (Fuel Off)"});
            this.comboBox1.Location = new System.Drawing.Point(9, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 22);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtbMilFlash);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(3, 240);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(229, 75);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MIL (Malfunction Indicator Light)";
            // 
            // txtbMilFlash
            // 
            this.txtbMilFlash.Location = new System.Drawing.Point(114, 19);
            this.txtbMilFlash.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtbMilFlash.Name = "txtbMilFlash";
            this.txtbMilFlash.Size = new System.Drawing.Size(51, 20);
            this.txtbMilFlash.TabIndex = 15;
            this.txtbMilFlash.ValueChanged += new System.EventHandler(this.txtbMilFlash_TextChanged);
            this.txtbMilFlash.Click += new System.EventHandler(this.txtbPrime_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "The malfunction indicator light will flash this\r\namount of time when turning the " +
    "ignition key On";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "Times";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "MIL Flashes:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 325);
            this.panel1.TabIndex = 13;
            // 
            // parmSCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmSCC";
            this.Size = new System.Drawing.Size(261, 325);
            this.Load += new System.EventHandler(this.parmSCC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSync)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbPrime)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMilFlash)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.class18_0.method_156("Fuel Pump Control", false);
        if (this.comboBox1.SelectedIndex == 0)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_78, 0);
        }
        else if (this.comboBox1.SelectedIndex == 1)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_78, 0xff);
        }
        else if (this.comboBox1.SelectedIndex == 2)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_78, 0xfe);
        }
        this.class18_0.method_153();
    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Extras");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_115, byte_0);
            this.class18_0.method_153();
        }
    }

    private void Apply_FuelPrime()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Extras");
            if (this.class18_0.class13_u_0.long_79 != 0L)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_79, (byte)(double.Parse(this.txtbPrime.Text) / 0.1));
            }
            this.class18_0.method_153();
        }
    }

    private void LoadPage()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmSCC_Load(null, null);
        }
    }

    private void method_2()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Extras");
            if (this.class18_0.class13_u_0.long_116 != 0L)
            {
                if (this.chkCust.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_116, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_116, 0);
                }
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_101, (byte) ((float.Parse(this.txtbSync.Text) + 6f) * 4f));
            }
            this.class18_0.method_153();
            this.parmSCC_Load(null, null);
        }
    }

    private void method_3(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Extras");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_114, byte_0);
            this.class18_0.method_153();
        }
    }

    private void parmSCC_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.label1.Visible = false;
        this.label2.Visible = true;
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(true);
        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(false);
        this.ctrlInputSelector1.method_12();
        this.ctrlInputSelector1.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_114));
        this.ctrlInputSelector1.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_115) == 0xff);
        if (this.class18_0.class13_u_0.long_116 != 0L)
        {
            this.chkCust.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_116) != 0;
            this.txtbSync.Text = ((this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_101) * 0.25f) - 6f).ToString();

            if (!this.chkCust.Checked) this.txtbSync.Enabled = false;
            else this.txtbSync.Enabled = true;
        }
        else
        {
            this.txtbSync.Enabled = false;
        }
        
        switch (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_78))
        {
            case 0:
                this.comboBox1.SelectedIndex = 0;
                break;

            case 0xff:
                this.comboBox1.SelectedIndex = 1;
                break;

            case 0xfe:
                this.comboBox1.SelectedIndex = 2;
                break;
        }
        if (this.class18_0.class13_u_0.long_79 == 0L) this.txtbPrime.Enabled = false;
        else this.txtbPrime.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_79) * 0.1).ToString();
        
        this.txtbMilFlash.Text = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_85).ToString();
        this.txtbMilFlash.Enabled= true;

        this.bool_0 = false;
    }

    private void txtbSync_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_2();
            }
            control.Focus();
        }
    }

    private void txtbSync_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbPrime_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown)sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.Apply_FuelPrime();
            }
            control.Focus();
        }
    }

    private void txtbPrime_Validated(object sender, EventArgs e)
    {
        this.Apply_FuelPrime();
    }

    private void txtbPrime_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbMilFlash_TextChanged(object sender, EventArgs e)
    {
        if (!this.bool_0 && this.txtbMilFlash.Text != "")
        {
            try
            {
                this.class18_0.method_155("Extras");
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_85, byte.Parse(this.txtbMilFlash.Text));
                this.class18_0.method_153();
            }
            catch { }
        }
    }

    private void ButtonIgnSync_Click(object sender, EventArgs e)
    {
        if (this.frmIgnitionSync_0 != null)
        {
            this.frmIgnitionSync_0.Focus();
        }
        else
        {
            this.frmIgnitionSync_0 = new frmIgnitionSync();
            this.frmIgnitionSync_0.method_0(ref this.class18_0);
            this.frmIgnitionSync_0.ShowDialog();
            this.class18_0.method_53();
            this.frmIgnitionSync_0.Dispose();
            this.frmIgnitionSync_0 = null;
        }
    }
}

