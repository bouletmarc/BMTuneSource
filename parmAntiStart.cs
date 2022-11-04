using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmAntiStart : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private GroupBox groupBox1;
    private GroupBox grp_TPS;
    private IContainer icontainer_0;
    private Label label2;
    private TextBox txt_TPS_Min;
    private CheckBox chk_TPS;
    private Panel panel1;
    private Label label7;
    private Label label1;
    private GroupBox grp_Input;
    private Label label8;
    private ComboBox cmb_ACS;
    private ComboBox cmb_VTP;
    private Label label9;
    private ComboBox cmb_PSP;
    private Label label12;
    private Label label10;
    private ComboBox cmb_BKSW;
    private ComboBox cmb_SCS;
    private Label label11;
    private ErrorProvider errorProvider_0;
    private IContainer components;
    private CheckBox chk_AntiEnable;
    private Label label4;
    private NumericUpDown txt_RPM;
    private TextBox txt_TPS_Max;

    public parmAntiStart(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

        if (this.class18_0.RomVersion < 104)
        {
            groupBox1.Enabled = false;
            this.label7.Text = "THIS BASEROM VERSION\nDOESN'T INCLUDE ANTITHEFT!";
        }
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
            this.txt_RPM = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_AntiEnable = new System.Windows.Forms.CheckBox();
            this.grp_Input = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_ACS = new System.Windows.Forms.ComboBox();
            this.cmb_VTP = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_PSP = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_BKSW = new System.Windows.Forms.ComboBox();
            this.cmb_SCS = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grp_TPS = new System.Windows.Forms.GroupBox();
            this.chk_TPS = new System.Windows.Forms.CheckBox();
            this.txt_TPS_Max = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TPS_Min = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_RPM)).BeginInit();
            this.grp_Input.SuspendLayout();
            this.grp_TPS.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_RPM);
            this.groupBox1.Controls.Add(this.grp_TPS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chk_AntiEnable);
            this.groupBox1.Controls.Add(this.grp_Input);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anti-Theft Protection";
            // 
            // txt_RPM
            // 
            this.txt_RPM.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txt_RPM.Location = new System.Drawing.Point(100, 56);
            this.txt_RPM.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txt_RPM.Name = "txt_RPM";
            this.txt_RPM.Size = new System.Drawing.Size(75, 20);
            this.txt_RPM.TabIndex = 24;
            this.txt_RPM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RPM_KeyPress);
            this.txt_RPM.Validating += new System.ComponentModel.CancelEventHandler(this.txt_RPM_Validating);
            this.txt_RPM.Validated += new System.EventHandler(this.txt_RPM_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Limit RPM to:";
            // 
            // chk_AntiEnable
            // 
            this.chk_AntiEnable.AutoSize = true;
            this.chk_AntiEnable.Location = new System.Drawing.Point(17, 27);
            this.chk_AntiEnable.Name = "chk_AntiEnable";
            this.chk_AntiEnable.Size = new System.Drawing.Size(177, 18);
            this.chk_AntiEnable.TabIndex = 23;
            this.chk_AntiEnable.Text = "Enable Anti-Theft Protection";
            this.chk_AntiEnable.UseVisualStyleBackColor = true;
            this.chk_AntiEnable.CheckedChanged += new System.EventHandler(this.chk_TPS_CheckedChanged);
            // 
            // grp_Input
            // 
            this.grp_Input.Controls.Add(this.label8);
            this.grp_Input.Controls.Add(this.cmb_ACS);
            this.grp_Input.Controls.Add(this.cmb_VTP);
            this.grp_Input.Controls.Add(this.label9);
            this.grp_Input.Controls.Add(this.cmb_PSP);
            this.grp_Input.Controls.Add(this.label12);
            this.grp_Input.Controls.Add(this.label10);
            this.grp_Input.Controls.Add(this.cmb_BKSW);
            this.grp_Input.Controls.Add(this.cmb_SCS);
            this.grp_Input.Controls.Add(this.label11);
            this.grp_Input.Location = new System.Drawing.Point(6, 91);
            this.grp_Input.Name = "grp_Input";
            this.grp_Input.Size = new System.Drawing.Size(304, 156);
            this.grp_Input.TabIndex = 22;
            this.grp_Input.TabStop = false;
            this.grp_Input.Text = "Inputs Conditions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "B5-ACS (Air Conditioning Switch)";
            // 
            // cmb_ACS
            // 
            this.cmb_ACS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ACS.FormattingEnabled = true;
            this.cmb_ACS.Items.AddRange(new object[] {
            "Unused",
            "On",
            "Off"});
            this.cmb_ACS.Location = new System.Drawing.Point(216, 19);
            this.cmb_ACS.Name = "cmb_ACS";
            this.cmb_ACS.Size = new System.Drawing.Size(79, 22);
            this.cmb_ACS.TabIndex = 13;
            this.cmb_ACS.SelectedIndexChanged += new System.EventHandler(this.cmb_ACS_SelectedIndexChanged);
            // 
            // cmb_VTP
            // 
            this.cmb_VTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VTP.FormattingEnabled = true;
            this.cmb_VTP.Items.AddRange(new object[] {
            "Unused",
            "On",
            "Off"});
            this.cmb_VTP.Location = new System.Drawing.Point(216, 127);
            this.cmb_VTP.Name = "cmb_VTP";
            this.cmb_VTP.Size = new System.Drawing.Size(79, 22);
            this.cmb_VTP.TabIndex = 21;
            this.cmb_VTP.SelectedIndexChanged += new System.EventHandler(this.cmb_ACS_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 14);
            this.label9.TabIndex = 14;
            this.label9.Text = "B8-PSP (Power Sterring Pressure)";
            // 
            // cmb_PSP
            // 
            this.cmb_PSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PSP.FormattingEnabled = true;
            this.cmb_PSP.Items.AddRange(new object[] {
            "Unused",
            "On",
            "Off"});
            this.cmb_PSP.Location = new System.Drawing.Point(216, 46);
            this.cmb_PSP.Name = "cmb_PSP";
            this.cmb_PSP.Size = new System.Drawing.Size(79, 22);
            this.cmb_PSP.TabIndex = 15;
            this.cmb_PSP.SelectedIndexChanged += new System.EventHandler(this.cmb_ACS_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 14);
            this.label12.TabIndex = 20;
            this.label12.Text = "D6-VTP (Vtec Pressure)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "D4-SCS (Service Check Connector)";
            // 
            // cmb_BKSW
            // 
            this.cmb_BKSW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BKSW.FormattingEnabled = true;
            this.cmb_BKSW.Items.AddRange(new object[] {
            "Unused",
            "On",
            "Off"});
            this.cmb_BKSW.Location = new System.Drawing.Point(216, 73);
            this.cmb_BKSW.Name = "cmb_BKSW";
            this.cmb_BKSW.Size = new System.Drawing.Size(79, 22);
            this.cmb_BKSW.TabIndex = 17;
            this.cmb_BKSW.SelectedIndexChanged += new System.EventHandler(this.cmb_ACS_SelectedIndexChanged);
            // 
            // cmb_SCS
            // 
            this.cmb_SCS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SCS.FormattingEnabled = true;
            this.cmb_SCS.Items.AddRange(new object[] {
            "Unused",
            "On",
            "Off"});
            this.cmb_SCS.Location = new System.Drawing.Point(216, 100);
            this.cmb_SCS.Name = "cmb_SCS";
            this.cmb_SCS.Size = new System.Drawing.Size(79, 22);
            this.cmb_SCS.TabIndex = 19;
            this.cmb_SCS.SelectedIndexChanged += new System.EventHandler(this.cmb_ACS_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "D2-BKSW (Brake Switch)";
            // 
            // grp_TPS
            // 
            this.grp_TPS.Controls.Add(this.chk_TPS);
            this.grp_TPS.Controls.Add(this.txt_TPS_Max);
            this.grp_TPS.Controls.Add(this.label1);
            this.grp_TPS.Controls.Add(this.txt_TPS_Min);
            this.grp_TPS.Controls.Add(this.label2);
            this.grp_TPS.Location = new System.Drawing.Point(200, 19);
            this.grp_TPS.Name = "grp_TPS";
            this.grp_TPS.Size = new System.Drawing.Size(304, 73);
            this.grp_TPS.TabIndex = 2;
            this.grp_TPS.TabStop = false;
            this.grp_TPS.Text = "TPS Conditions";
            this.grp_TPS.Visible = false;
            // 
            // chk_TPS
            // 
            this.chk_TPS.AutoSize = true;
            this.chk_TPS.Location = new System.Drawing.Point(13, 20);
            this.chk_TPS.Name = "chk_TPS";
            this.chk_TPS.Size = new System.Drawing.Size(141, 18);
            this.chk_TPS.TabIndex = 8;
            this.chk_TPS.Text = "Enable TPS Condition";
            this.chk_TPS.UseVisualStyleBackColor = true;
            this.chk_TPS.CheckedChanged += new System.EventHandler(this.chk_TPS_CheckedChanged);
            // 
            // txt_TPS_Max
            // 
            this.txt_TPS_Max.Location = new System.Drawing.Point(233, 45);
            this.txt_TPS_Max.Name = "txt_TPS_Max";
            this.txt_TPS_Max.Size = new System.Drawing.Size(42, 20);
            this.txt_TPS_Max.TabIndex = 5;
            this.txt_TPS_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_RPM_KeyPress);
            this.txt_TPS_Max.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_RPM_Validating);
            this.txt_TPS_Max.Validated += new System.EventHandler(this.txt_RPM_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "%";
            // 
            // txt_TPS_Min
            // 
            this.txt_TPS_Min.Location = new System.Drawing.Point(185, 45);
            this.txt_TPS_Min.Name = "txt_TPS_Min";
            this.txt_TPS_Min.Size = new System.Drawing.Size(42, 20);
            this.txt_TPS_Min.TabIndex = 3;
            this.txt_TPS_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_RPM_KeyPress);
            this.txt_TPS_Min.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_RPM_Validating);
            this.txt_TPS_Min.Validated += new System.EventHandler(this.txt_RPM_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "TPS Between (Min/Max):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(63, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 36);
            this.label7.TabIndex = 11;
            this.label7.Text = "All the conditions are checked\r\nonly once and when the Key is\r\nfirst switched On";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 400);
            this.panel1.TabIndex = 1;
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // parmAntiStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmAntiStart";
            this.Size = new System.Drawing.Size(350, 400);
            this.Load += new System.EventHandler(this.parmAntiStart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_RPM)).EndInit();
            this.grp_Input.ResumeLayout(false);
            this.grp_Input.PerformLayout();
            this.grp_TPS.ResumeLayout(false);
            this.grp_TPS.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmAntiStart_Load(null, null);
        }
    }

    private void method_6()
    {
        if (this.class18_0.RomVersion >= 104)
        {
            if (!this.bool_0)
            {
                this.class18_0.method_155("Anti-Theft Settings");
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_430, (byte)cmb_ACS.SelectedIndex);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_431, (byte)cmb_PSP.SelectedIndex);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_432, (byte)cmb_SCS.SelectedIndex);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_433, (byte)cmb_BKSW.SelectedIndex);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_434, (byte)cmb_VTP.SelectedIndex);

                /*if (chk_TPS.Checked) this.class18_0.method_149(this.class18_0.class13_0.long_435, 0xff);
                else this.class18_0.method_149(this.class18_0.class13_0.long_435, 0);
                this.class18_0.method_149(this.class18_0.class13_0.long_436, this.class18_0.method_228(int.Parse(this.txt_TPS_Min.Text)));
                this.class18_0.method_149(this.class18_0.class13_0.long_437, this.class18_0.method_228(int.Parse(this.txt_TPS_Max.Text)));*/

                this.class18_0.method_151(this.class18_0.class13_u_0.long_438, this.class18_0.method_219(int.Parse(this.txt_RPM.Text)));
                
                if (chk_AntiEnable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_439, 0xff);
                else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_439, 0);

                this.parmAntiStart_Load(null, null);
            }
        }
    }

    private void parmAntiStart_Load(object sender, EventArgs e)
    {
        if (this.class18_0.RomVersion >= 104)
        {
            this.bool_0 = true;
            
            cmb_ACS.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_430);
            cmb_PSP.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_431);
            cmb_SCS.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_432);
            cmb_BKSW.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_433);
            cmb_VTP.SelectedIndex = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_434);

            /*chk_TPS.Checked = this.class18_0.method_150(this.class18_0.class13_0.long_435) == 0xff;
            this.txt_TPS_Min.Text = this.class18_0.method_198(this.class18_0.method_150(this.class18_0.class13_0.long_436)).ToString();
            this.txt_TPS_Max.Text = this.class18_0.method_198(this.class18_0.method_150(this.class18_0.class13_0.long_437)).ToString();
            this.txt_TPS_Min.Enabled = chk_TPS.Checked;
            this.txt_TPS_Max.Enabled = chk_TPS.Checked;*/

            chk_AntiEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_439) == 0xff;
            this.txt_RPM.Enabled = chk_AntiEnable.Checked;

            this.grp_Input.Enabled = chk_AntiEnable.Checked;
            //this.grp_TPS.Enabled = chk_AntiEnable.Checked;

            this.txt_RPM.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_438)).ToString();

            this.bool_0 = false;
        }
    }

    private void cmb_ACS_SelectedIndexChanged(object sender, EventArgs e)
    {
        method_6();
    }

    private void chk_TPS_CheckedChanged(object sender, EventArgs e)
    {
        method_6();
    }

    private void txt_RPM_Validated(object sender, EventArgs e)
    {
        method_6();
    }

    private void txt_RPM_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Int positive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txt_RPM_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown)sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_6();
            }
            control.Focus();
        }
    }

    private void txtBox_RPM_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Int positive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtBox_RPM_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox)sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_6();
            }
            control.Focus();
        }
    }
}

