using Data;
using System;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmOstrichInfo : Form
{
    private Button btnClose;
    private Button btnReset;
    private Class18 class18_0;
    private Class25 class25_0;
    private GroupBox grpInfo;
    private IContainer icontainer_0;
    private Label label1;
    private Label labelEmulatorName;
    private Label label3;
    private Label label4;
    private Label label6;
    private Label lblFirmVersion;
    private Label lblNotConnected;
    private TextBox lblSerial;
    private Button ReloadInfos;
    private GroupBox groupBoxAdvanced;
    private TextBox textBoxSerialID;
    private Label label5;
    private Label label7;
    private Button buttonResetSerial;
    private NumericUpDown numericVendorID;
    private ErrorProvider errorProvider_0;
    private IContainer components;
    private Label label2;
    private Label lblVendorId;

    internal frmOstrichInfo()
    {
        this.InitializeComponent();
    }

    private void ButtonReloadInfo_Click(object sender, EventArgs e)
    {
        this.class18_0.class17_0.SetDemonDatalogCheck(false);
        this.class25_0.method_1(true);
        this.method_2();
    }

    private void ButtonResetSerial_Click(object sender, EventArgs e)
    {
        try
        {
            //this.textBoxSerialID.Text = "FFFFF FFFFF FFFFF F";
            if (this.textBoxSerialID.Text.Length == 16)
            {
                byte[] NewID = StringToByteArray(textBoxSerialID.Text);
                if (NewID.Length == 8)
                {
                    if (MessageBox.Show(Form.ActiveForm, "This will reset your Serial ID, vendorID will remain the same\nThis will remove all data on emulator!\nDo you want to continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!this.class25_0.GetConnected())
                        {
                            this.class25_0.method_1(true);
                        }
                        this.class25_0.ResetSerial(NewID);
                        this.method_2();
                    }
                }
                else
                {
                    MessageBox.Show(Form.ActiveForm, "The Serial ID aren't correct!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show(Form.ActiveForm, "The Serial ID aren't correct in lenght!\nThe serial ID need 16x characters", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message);
        }
    }

    private byte[] StringToByteArray(string hex)
    {
        try
        {
            return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
        }
        catch
        {
            return new byte[] { };
        }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            if (MessageBox.Show(Form.ActiveForm, "This will reset your vendorID, serialID will remain the same\nThis will remove all data on emulator!\nDo you want to continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich && numericVendorID.Value != 0)
                    || (this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon && numericVendorID.Value != 1))
                {
                    MessageBox.Show(Form.ActiveForm, "Take note that when using a not compatible emulator vendor ID for\nBMTune, BMTune will give you warning and offer you to reset the\nvendor ID to a compatible one", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

                if (!this.class25_0.GetConnected())
                {
                    this.class25_0.method_1(true);
                }
                this.class25_0.ResetVendorUnknown((byte) numericVendorID.Value);
                this.method_2();
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message);
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

    private void frmOstrichInfo_Load(object sender, EventArgs e)
    {
        this.method_2();
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOstrichInfo));
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.ReloadInfos = new System.Windows.Forms.Button();
            this.lblSerial = new System.Windows.Forms.TextBox();
            this.labelEmulatorName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVendorId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFirmVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNotConnected = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxAdvanced = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericVendorID = new System.Windows.Forms.NumericUpDown();
            this.buttonResetSerial = new System.Windows.Forms.Button();
            this.textBoxSerialID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpInfo.SuspendLayout();
            this.groupBoxAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVendorID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.ReloadInfos);
            this.grpInfo.Controls.Add(this.lblSerial);
            this.grpInfo.Controls.Add(this.labelEmulatorName);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.label6);
            this.grpInfo.Controls.Add(this.lblVendorId);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.lblFirmVersion);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Location = new System.Drawing.Point(12, 12);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(259, 152);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Emulator Infos";
            // 
            // ReloadInfos
            // 
            this.ReloadInfos.Location = new System.Drawing.Point(39, 117);
            this.ReloadInfos.Name = "ReloadInfos";
            this.ReloadInfos.Size = new System.Drawing.Size(173, 25);
            this.ReloadInfos.TabIndex = 19;
            this.ReloadInfos.Text = "Reload Info (try connect)";
            this.ReloadInfos.UseVisualStyleBackColor = true;
            this.ReloadInfos.Click += new System.EventHandler(this.ButtonReloadInfo_Click);
            // 
            // lblSerial
            // 
            this.lblSerial.Location = new System.Drawing.Point(90, 90);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.ReadOnly = true;
            this.lblSerial.Size = new System.Drawing.Size(160, 20);
            this.lblSerial.TabIndex = 20;
            // 
            // labelEmulatorName
            // 
            this.labelEmulatorName.AutoSize = true;
            this.labelEmulatorName.Location = new System.Drawing.Point(87, 22);
            this.labelEmulatorName.Name = "labelEmulatorName";
            this.labelEmulatorName.Size = new System.Drawing.Size(15, 14);
            this.labelEmulatorName.TabIndex = 19;
            this.labelEmulatorName.Text = "#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Vendor ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Serial ID:";
            // 
            // lblVendorId
            // 
            this.lblVendorId.AutoSize = true;
            this.lblVendorId.Location = new System.Drawing.Point(87, 69);
            this.lblVendorId.Name = "lblVendorId";
            this.lblVendorId.Size = new System.Drawing.Size(15, 14);
            this.lblVendorId.TabIndex = 3;
            this.lblVendorId.Text = "#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Emulator:";
            // 
            // lblFirmVersion
            // 
            this.lblFirmVersion.AutoSize = true;
            this.lblFirmVersion.Location = new System.Drawing.Point(87, 45);
            this.lblFirmVersion.Name = "lblFirmVersion";
            this.lblFirmVersion.Size = new System.Drawing.Size(15, 14);
            this.lblFirmVersion.TabIndex = 1;
            this.lblFirmVersion.Text = "#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firmware:";
            // 
            // lblNotConnected
            // 
            this.lblNotConnected.AutoSize = true;
            this.lblNotConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotConnected.ForeColor = System.Drawing.Color.Red;
            this.lblNotConnected.Location = new System.Drawing.Point(37, 212);
            this.lblNotConnected.Name = "lblNotConnected";
            this.lblNotConnected.Size = new System.Drawing.Size(201, 20);
            this.lblNotConnected.TabIndex = 0;
            this.lblNotConnected.Text = "Emulator not connected";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(6, 81);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(119, 25);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset Vendor ID";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnClose.Location = new System.Drawing.Point(186, 289);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // groupBoxAdvanced
            // 
            this.groupBoxAdvanced.Controls.Add(this.label2);
            this.groupBoxAdvanced.Controls.Add(this.numericVendorID);
            this.groupBoxAdvanced.Controls.Add(this.buttonResetSerial);
            this.groupBoxAdvanced.Controls.Add(this.textBoxSerialID);
            this.groupBoxAdvanced.Controls.Add(this.label5);
            this.groupBoxAdvanced.Controls.Add(this.label7);
            this.groupBoxAdvanced.Controls.Add(this.btnReset);
            this.groupBoxAdvanced.Location = new System.Drawing.Point(12, 170);
            this.groupBoxAdvanced.Name = "groupBoxAdvanced";
            this.groupBoxAdvanced.Size = new System.Drawing.Size(259, 112);
            this.groupBoxAdvanced.TabIndex = 18;
            this.groupBoxAdvanced.TabStop = false;
            this.groupBoxAdvanced.Text = "Advanced Tools";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 30);
            this.label2.TabIndex = 27;
            this.label2.Text = "BMTune Vendor:\r\nMoates Ostrich=0\r\nMoates Demon=1";
            // 
            // numericVendorID
            // 
            this.numericVendorID.Location = new System.Drawing.Point(90, 27);
            this.numericVendorID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericVendorID.Name = "numericVendorID";
            this.numericVendorID.Size = new System.Drawing.Size(55, 20);
            this.numericVendorID.TabIndex = 26;
            // 
            // buttonResetSerial
            // 
            this.buttonResetSerial.Enabled = false;
            this.buttonResetSerial.ForeColor = System.Drawing.Color.Red;
            this.buttonResetSerial.Location = new System.Drawing.Point(129, 81);
            this.buttonResetSerial.Name = "buttonResetSerial";
            this.buttonResetSerial.Size = new System.Drawing.Size(119, 25);
            this.buttonResetSerial.TabIndex = 25;
            this.buttonResetSerial.Text = "Reset Serial ID";
            this.buttonResetSerial.UseVisualStyleBackColor = true;
            this.buttonResetSerial.Click += new System.EventHandler(this.ButtonResetSerial_Click);
            // 
            // textBoxSerialID
            // 
            this.textBoxSerialID.Location = new System.Drawing.Point(90, 51);
            this.textBoxSerialID.Name = "textBoxSerialID";
            this.textBoxSerialID.Size = new System.Drawing.Size(160, 20);
            this.textBoxSerialID.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Vendor ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = "Serial ID:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // frmOstrichInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 320);
            this.Controls.Add(this.groupBoxAdvanced);
            this.Controls.Add(this.lblNotConnected);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOstrichInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Emulator Infos";
            this.Load += new System.EventHandler(this.frmOstrichInfo_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.groupBoxAdvanced.ResumeLayout(false);
            this.groupBoxAdvanced.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVendorID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_0(ref Class18 class18_1, ref Class25 class25_1)
    {
        this.class18_0 = class18_1;
        this.class25_0 = class25_1;
        class25_1.delegate65_0 += new Class25.Delegate65(this.method_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1(EmulatorState emulatorState_0, int int_0, bool bool_0)
    {
        if (emulatorState_0 == EmulatorState.Connected)
        {
            SetConnectedMenu(true);
        }
        else
        {
            SetConnectedMenu(false);
        }
    }

    private void SetConnectedMenu(bool IsConnected)
    {
        if (IsConnected)
        {
            this.btnReset.Enabled = true;
            this.buttonResetSerial.Enabled = true;
            this.lblNotConnected.Visible = false;
            this.groupBoxAdvanced.Visible = true;
        }
        else
        {
            this.btnReset.Enabled = false;
            this.buttonResetSerial.Enabled = false;
            this.lblNotConnected.Visible = true;
            this.groupBoxAdvanced.Visible = false;
        }
    }

    private void method_2()
    {
    Label_0005:
        this.lblNotConnected.Visible = false;
        this.btnReset.Enabled = this.class25_0.GetConnected();
        if (this.class25_0.method_13() != EmulatorState.Connected)
        {
            SetConnectedMenu(false);
            lblNotConnected.Text = "Emulator not connected";
        }
        else
        {
            SetConnectedMenu(true);
            if (((this.class25_0.Vendor_ID != 1) && (this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)) && (MessageBox.Show(Form.ActiveForm, "Demon VendorID is not set to BMTune. Do you want to set it to BMTune?\nThis will remove all data from demon!", "BMTune", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                this.class25_0.ResetVendor(false);
                goto Label_0005;
            }

            if ((this.class25_0.emulatorMoatesType_0 != EmulatorMoatesType.ostrich_1) || (this.class25_0.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_1 && this.class25_0.int_2 >= 15))
            {
                if (((this.class25_0.Vendor_ID != 0) && (this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich)) && (MessageBox.Show(Form.ActiveForm, "Ostrich VendorID is not set to BMTune. Do you want to set it to BMTune?\nThis will remove all data from ostrich!", "BMTune", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    this.class25_0.ResetVendor(true);
                    goto Label_0005;
                }
            }
            if ((((this.class18_0.class10_settings_0.emulatorMode_0 != EmulatorMode.Ostrich) && (this.class18_0.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon))
                && (((this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich) && (this.class25_0.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_1)) && (this.class25_0.int_2 < 15)))
                && (((this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich) && (this.class25_0.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_2)) && (this.class25_0.int_2 < 4)))
            {
                SetConnectedMenu(false);
                lblNotConnected.Text = "Emulator not compatible";
            }
            else
            {
                if (this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon) this.lblVendorId.Text = ((EmulatorVendorDemon)this.class25_0.Vendor_ID).ToString();
                else if (this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich) this.lblVendorId.Text = ((EmulatorVendorOstrich)this.class25_0.Vendor_ID).ToString();

                this.numericVendorID.Value = this.class25_0.Vendor_ID;
                this.lblVendorId.Text += " " + (int) this.class25_0.Vendor_ID + "(" + this.class25_0.Vendor_ID.ToString("X2") + ")";

                string str = string.Empty;
                bool flag = true;
                for (int i = 0; i < 8; i++)
                {
                    if (this.class25_0.Serial_ID[i] != 0xff)
                    {
                        flag = false;
                        break;
                    }
                }
                for (int j = 0; j < 8; j++)
                {
                    if ((this.class25_0.Serial_ID[0] == 0xff) && (this.class25_0.Serial_ID[1] == 0xff))
                    {
                        str = str + "FF";
                    }
                    else
                    {
                        str = str + this.class25_0.Serial_ID[j].ToString("X2");
                    }
                }
                if (flag)
                {
                    this.lblSerial.Text = "FFFFFFFFFFFFFFFF";
                    this.textBoxSerialID.Text = "FFFFFFFFFFFFFFFF";
                }
                else
                {
                    this.lblSerial.Text = str;
                    this.textBoxSerialID.Text = str;
                }
            }
            this.lblFirmVersion.Text = "V" + this.class25_0.int_1 + "." + this.class25_0.int_2 + "." + this.class25_0.string_0;
            this.labelEmulatorName.Text = this.class25_0.EmulatorName;
        }
    }

    private void txtbTpsMinRpm_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown)sender;
            this.groupBoxAdvanced.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_2();
            }
            control.Focus();
        }
    }

    private void txtbTpsMinRpm_Validated(object sender, EventArgs e)
    {
        this.method_2();
    }

    private void txtbTpsMinRpm_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

