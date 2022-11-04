using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmOBL : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private bool bool_1;
    private IContainer icontainer_1;
    private GroupBox groupBox4;
    private ComboBox lstInput;
    private CheckBox checkBox1;
    private Label label1;
    private Label label4;
    private Label label3;
    private ComboBox conditionbox;
    private Label label2;
    private CheckBox checkBox2;
    private MaskedTextBox conditiontxt;
    private IContainer components;
    private Panel panel1;

    public parmOBL(ref Class18 Class18_1)
    {
        this.class18_0 = Class18_1;
        this.InitializeComponent();
        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_1)
        {
            try
            {
                int num = int.Parse(this.conditiontxt.Text);
                this.class18_0.method_151(0x5ed4L, (long) num);
            }
            catch
            {
            }
            if (!this.checkBox1.Checked)
            {
                this.class18_0.SetByteAt(0x5ed3L, 0xff);
            }
            else
            {
                this.method_2();
            }
            this.class18_0.method_153();
        }
    }

    private void parmOBL_Load(object sender, EventArgs e)
    {
        if (!this.bool_0 && (class18_0.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon))
        {
            this.groupBox4.Enabled = false;
            this.groupBox4.Text = "Onboard Datalogging: Require Moates Demon!";
        }
        else if (class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
        {
            try
            {
                if (!class18_0.class17_0.serialPort_0.IsOpen)
                {
                    this.groupBox4.Enabled = false;
                    this.groupBox4.Text = "Onboard Datalogging: Connect to Emulator";
                }
                else
                {
                    this.groupBox4.Enabled = true;
                    this.groupBox4.Text = "Onboard Datalogging: Demon Online";
                }
            }
            catch
            {
                this.groupBox4.Enabled = false;
                this.groupBox4.Text = "Onboard Datalogging: Connect to Emulator";
            }
        }
        this.method_0(this.class18_0.GetByteAt(0x5ed3L));
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(parmOBL));
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.conditiontxt = new System.Windows.Forms.MaskedTextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.conditionbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(424, 322);
            this.panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.conditiontxt);
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.conditionbox);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lstInput);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Location = new System.Drawing.Point(2, 8);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(294, 239);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Onboard Datalogging:";
            // 
            // conditiontxt
            // 
            this.conditiontxt.Location = new System.Drawing.Point(185, 98);
            this.conditiontxt.Margin = new System.Windows.Forms.Padding(2);
            this.conditiontxt.Name = "conditiontxt";
            this.conditiontxt.Size = new System.Drawing.Size(71, 20);
            this.conditiontxt.TabIndex = 18;
            this.conditiontxt.TextChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(207, 72);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(53, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Invert";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 78);
            this.label4.TabIndex = 16;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "<";
            // 
            // conditionbox
            // 
            this.conditionbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conditionbox.Enabled = false;
            this.conditionbox.FormattingEnabled = true;
            this.conditionbox.Items.AddRange(new object[] {
            "Disable",
            "TPS",
            "RPM",
            "SPEED"});
            this.conditionbox.Location = new System.Drawing.Point(92, 98);
            this.conditionbox.Margin = new System.Windows.Forms.Padding(2);
            this.conditionbox.Name = "conditionbox";
            this.conditionbox.Size = new System.Drawing.Size(71, 21);
            this.conditionbox.TabIndex = 13;
            this.conditionbox.SelectedIndexChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "And:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input Trigger:";
            // 
            // lstInput
            // 
            this.lstInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInput.FormattingEnabled = true;
            this.lstInput.Items.AddRange(new object[] {
            "SCS (D4)",
            "ACS (B5)",
            "VTPS (D6) ",
            "Park (B7)",
            "PSP (B8)",
            "ATShit1 (B4)",
            "ATShift2 (B3)",
            "Start Sig (B9)",
            "Brake (D3)",
            "B6 ",
            "EGR Lift (D12)",
            "ELD (D10)",
            "O2 (D14)",
            "Always On"});
            this.lstInput.Location = new System.Drawing.Point(92, 50);
            this.lstInput.Margin = new System.Windows.Forms.Padding(2);
            this.lstInput.Name = "lstInput";
            this.lstInput.Size = new System.Drawing.Size(164, 21);
            this.lstInput.TabIndex = 4;
            this.lstInput.SelectedIndexChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 23);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Enable Onboard";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // parmOBL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "parmOBL";
            this.Size = new System.Drawing.Size(424, 322);
            this.Load += new System.EventHandler(this.parmOBL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

    }

    public void method_0(byte byte_0)
    {
        this.bool_1 = true;
        switch (byte_0)
        {
            case 0:
                this.method_1(0, 0, true, true);
                goto TR_0000;

            case 1:
                this.method_1(1, 0, true, true);
                goto TR_0000;

            case 2:
                this.method_1(2, 0, true, true);
                goto TR_0000;

            case 3:
                this.method_1(3, 0, true, true);
                goto TR_0000;

            case 4:
                this.method_1(4, 0, true, true);
                goto TR_0000;

            case 5:
                this.method_1(5, 0, true, true);
                goto TR_0000;

            case 6:
                this.method_1(6, 0, true, true);
                goto TR_0000;

            case 7:
                this.method_1(7, 0, true, true);
                goto TR_0000;

            case 8:
                this.method_1(8, 0, true, true);
                goto TR_0000;

            case 9:
                this.method_1(9, 0, true, true);
                goto TR_0000;

            case 10:
                this.method_1(10, 0, true, true);
                goto TR_0000;

            case 11:
                this.method_1(11, 0, true, true);
                goto TR_0000;

            case 12:
                this.method_1(12, 0, true, true);
                goto TR_0000;

            case 13:
                this.method_1(14, 0, true, true);
                goto TR_0000;

            case 14:
            case 15:
            case 0x10:
            case 0x11:
            case 0x12:
            case 0x13:
                break;

            case 20:
                this.method_1(0, 0, true, false);
                goto TR_0000;

            case 0x15:
                this.method_1(1, 0, true, false);
                goto TR_0000;

            case 0x16:
                this.method_1(2, 0, true, false);
                goto TR_0000;

            case 0x17:
                this.method_1(3, 0, true, false);
                goto TR_0000;

            case 0x18:
                this.method_1(4, 0, true, false);
                goto TR_0000;

            case 0x19:
                this.method_1(5, 0, true, false);
                goto TR_0000;

            case 0x1a:
                this.method_1(6, 0, true, false);
                goto TR_0000;

            case 0x1b:
                this.method_1(7, 0, true, false);
                goto TR_0000;

            case 0x1c:
                this.method_1(8, 0, true, false);
                goto TR_0000;

            case 0x1d:
                this.method_1(9, 0, true, false);
                goto TR_0000;

            case 30:
                this.method_1(10, 0, true, false);
                goto TR_0000;

            case 0x1f:
                this.method_1(11, 0, true, false);
                goto TR_0000;

            case 0x20:
                this.method_1(12, 0, true, false);
                goto TR_0000;

            case 0x21:
                this.method_1(13, 0, true, false);
                goto TR_0000;

            case 0x22:
            case 0x23:
            case 0x24:
            case 0x25:
            case 0x26:
            case 0x27:
            case 0x36:
            case 0x37:
            case 0x38:
            case 0x39:
            case 0x3a:
            case 0x3b:
            case 0x4a:
            case 0x4b:
            case 0x4c:
            case 0x4d:
            case 0x4e:
            case 0x4f:
            case 0x5e:
            case 0x5f:
            case 0x60:
            case 0x61:
            case 0x62:
            case 0x63:
            case 0x72:
            case 0x73:
            case 0x74:
            case 0x75:
            case 0x76:
            case 0x77:
            case 0x86:
            case 0x87:
            case 0x88:
            case 0x89:
            case 0x8a:
            case 0x8b:
                goto TR_0000;

            case 40:
                this.method_1(0, 1, true, true);
                goto TR_0000;

            case 0x29:
                this.method_1(1, 1, true, true);
                goto TR_0000;

            case 0x2a:
                this.method_1(2, 1, true, true);
                goto TR_0000;

            case 0x2b:
                this.method_1(3, 1, true, true);
                goto TR_0000;

            case 0x2c:
                this.method_1(4, 1, true, true);
                goto TR_0000;

            case 0x2d:
                this.method_1(5, 1, true, true);
                goto TR_0000;

            case 0x2e:
                this.method_1(6, 1, true, true);
                goto TR_0000;

            case 0x2f:
                this.method_1(7, 1, true, true);
                goto TR_0000;

            case 0x30:
                this.method_1(8, 1, true, true);
                goto TR_0000;

            case 0x31:
                this.method_1(9, 1, true, true);
                goto TR_0000;

            case 50:
                this.method_1(10, 1, true, true);
                goto TR_0000;

            case 0x33:
                this.method_1(11, 1, true, true);
                goto TR_0000;

            case 0x34:
                this.method_1(12, 1, true, true);
                goto TR_0000;

            case 0x35:
                this.method_1(14, 1, true, true);
                goto TR_0000;

            case 60:
                this.method_1(0, 1, true, false);
                goto TR_0000;

            case 0x3d:
                this.method_1(1, 1, true, false);
                goto TR_0000;

            case 0x3e:
                this.method_1(2, 1, true, false);
                goto TR_0000;

            case 0x3f:
                this.method_1(3, 1, true, false);
                goto TR_0000;

            case 0x40:
                this.method_1(4, 1, true, false);
                goto TR_0000;

            case 0x41:
                this.method_1(5, 1, true, false);
                goto TR_0000;

            case 0x42:
                this.method_1(6, 1, true, false);
                goto TR_0000;

            case 0x43:
                this.method_1(7, 1, true, false);
                goto TR_0000;

            case 0x44:
                this.method_1(8, 1, true, false);
                goto TR_0000;

            case 0x45:
                this.method_1(9, 1, true, false);
                goto TR_0000;

            case 70:
                this.method_1(10, 1, true, false);
                goto TR_0000;

            case 0x47:
                this.method_1(11, 1, true, false);
                goto TR_0000;

            case 0x48:
                this.method_1(12, 1, true, false);
                goto TR_0000;

            case 0x49:
                this.method_1(13, 1, true, false);
                goto TR_0000;

            case 80:
                this.method_1(0, 2, true, true);
                goto TR_0000;

            case 0x51:
                this.method_1(1, 2, true, true);
                goto TR_0000;

            case 0x52:
                this.method_1(2, 2, true, true);
                goto TR_0000;

            case 0x53:
                this.method_1(3, 2, true, true);
                goto TR_0000;

            case 0x54:
                this.method_1(4, 2, true, true);
                goto TR_0000;

            case 0x55:
                this.method_1(5, 2, true, true);
                goto TR_0000;

            case 0x56:
                this.method_1(6, 2, true, true);
                goto TR_0000;

            case 0x57:
                this.method_1(7, 2, true, true);
                goto TR_0000;

            case 0x58:
                this.method_1(8, 2, true, true);
                goto TR_0000;

            case 0x59:
                this.method_1(9, 2, true, true);
                goto TR_0000;

            case 90:
                this.method_1(10, 2, true, true);
                goto TR_0000;

            case 0x5b:
                this.method_1(11, 2, true, true);
                goto TR_0000;

            case 0x5c:
                this.method_1(12, 2, true, true);
                goto TR_0000;

            case 0x5d:
                this.method_1(14, 2, true, true);
                goto TR_0000;

            case 100:
                this.method_1(0, 2, true, false);
                goto TR_0000;

            case 0x65:
                this.method_1(1, 2, true, false);
                goto TR_0000;

            case 0x66:
                this.method_1(2, 2, true, false);
                goto TR_0000;

            case 0x67:
                this.method_1(3, 2, true, false);
                goto TR_0000;

            case 0x68:
                this.method_1(4, 2, true, false);
                goto TR_0000;

            case 0x69:
                this.method_1(5, 2, true, false);
                goto TR_0000;

            case 0x6a:
                this.method_1(6, 2, true, false);
                goto TR_0000;

            case 0x6b:
                this.method_1(7, 2, true, false);
                goto TR_0000;

            case 0x6c:
                this.method_1(8, 2, true, false);
                goto TR_0000;

            case 0x6d:
                this.method_1(9, 2, true, false);
                goto TR_0000;

            case 110:
                this.method_1(10, 2, true, false);
                goto TR_0000;

            case 0x6f:
                this.method_1(11, 2, true, false);
                goto TR_0000;

            case 0x70:
                this.method_1(12, 2, true, false);
                goto TR_0000;

            case 0x71:
                this.method_1(13, 2, true, false);
                goto TR_0000;

            case 120:
                this.method_1(0, 3, true, true);
                goto TR_0000;

            case 0x79:
                this.method_1(1, 3, true, true);
                goto TR_0000;

            case 0x7a:
                this.method_1(2, 3, true, true);
                goto TR_0000;

            case 0x7b:
                this.method_1(3, 3, true, true);
                goto TR_0000;

            case 0x7c:
                this.method_1(4, 3, true, true);
                goto TR_0000;

            case 0x7d:
                this.method_1(5, 3, true, true);
                goto TR_0000;

            case 0x7e:
                this.method_1(6, 3, true, true);
                goto TR_0000;

            case 0x7f:
                this.method_1(7, 3, true, true);
                goto TR_0000;

            case 0x80:
                this.method_1(8, 3, true, true);
                goto TR_0000;

            case 0x81:
                this.method_1(9, 3, true, true);
                goto TR_0000;

            case 130:
                this.method_1(10, 3, true, true);
                goto TR_0000;

            case 0x83:
                this.method_1(11, 3, true, true);
                goto TR_0000;

            case 0x84:
                this.method_1(12, 3, true, true);
                goto TR_0000;

            case 0x85:
                this.method_1(14, 3, true, true);
                goto TR_0000;

            case 140:
                this.method_1(0, 3, true, false);
                goto TR_0000;

            case 0x8d:
                this.method_1(1, 3, true, false);
                goto TR_0000;

            case 0x8e:
                this.method_1(2, 3, true, false);
                goto TR_0000;

            case 0x8f:
                this.method_1(3, 3, true, false);
                goto TR_0000;

            case 0x90:
                this.method_1(4, 3, true, false);
                goto TR_0000;

            case 0x91:
                this.method_1(5, 3, true, false);
                goto TR_0000;

            case 0x92:
                this.method_1(6, 3, true, false);
                goto TR_0000;

            case 0x93:
                this.method_1(7, 3, true, false);
                goto TR_0000;

            case 0x94:
                this.method_1(8, 3, true, false);
                goto TR_0000;

            case 0x95:
                this.method_1(9, 3, true, false);
                goto TR_0000;

            case 150:
                this.method_1(10, 3, true, false);
                goto TR_0000;

            case 0x97:
                this.method_1(11, 3, true, false);
                goto TR_0000;

            case 0x98:
                this.method_1(12, 3, true, false);
                goto TR_0000;

            case 0x99:
                this.method_1(13, 3, true, false);
                goto TR_0000;

            default:
                if (byte_0 == 0xff)
                {
                    break;
                }
                goto TR_0000;
        }
        this.method_1(0, 0, false, false);
    TR_0000:
        this.bool_1 = false;
    }

    private void method_1(int int_0, int int_1, bool bool_2, bool bool_3)
    {
        this.checkBox1.Checked = bool_2;
        this.checkBox2.Checked = bool_3;
        this.lstInput.SelectedIndex = int_0;
        this.conditionbox.SelectedIndex = int_1;
    }

    private void method_2()
    {
        if (this.checkBox1.Checked && this.checkBox2.Checked)
        {
            int selectedIndex = this.lstInput.SelectedIndex;
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
}

