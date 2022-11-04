using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class CtrlOutputSelector : UserControl
{
    private bool bool_0 = true;
    private bool bool_1;
    private bool bool_2 = true;
    private bool bool_3;
    private CheckBox chkInvert;
    private Class18 class18_0;
    private IContainer icontainer_0;
    private ComboBox lstInput;
    private Label lblInfo;
    private long CheckLocation = 0L;

    public event Delegate37 delegate37_0;
    public event Delegate36 delegate36_0;

    public CtrlOutputSelector()
    {
        this.InitializeComponent();
    }

    private void chkInvert_CheckedChanged(object sender, EventArgs e)
    {
        byte num = 0;
        if (this.chkInvert.Checked)
        {
            num = 0xff;
        }
        if (this.delegate36_0 != null)
        {
            this.delegate36_0(num);
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
            this.lstInput = new System.Windows.Forms.ComboBox();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstInput
            // 
            this.lstInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInput.FormattingEnabled = true;
            this.lstInput.Items.AddRange(new object[] {
            "ACC (AC Clutch A15)",
            "PCS (Purge Valve A20)",
            "PO2H (O2 Heater A6)",
            "FANC (Radiator Fan Relay A12)",
            "MIL (Check Engine Light A13)",
            "FPR (Fuel Pump Relay A7)",
            "IAB (Intake Butterflys A17)",
            "ATLC (Alternator Control A16)",
            "None"});
            this.lstInput.Location = new System.Drawing.Point(3, 3);
            this.lstInput.Name = "lstInput";
            this.lstInput.Size = new System.Drawing.Size(177, 21);
            this.lstInput.TabIndex = 3;
            this.lstInput.SelectedIndexChanged += new System.EventHandler(this.lstInput_SelectedIndexChanged);
            // 
            // chkInvert
            // 
            this.chkInvert.AutoSize = true;
            this.chkInvert.Location = new System.Drawing.Point(3, 29);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(88, 17);
            this.chkInvert.TabIndex = 4;
            this.chkInvert.Text = "Invert Output";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(101, 30);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(70, 13);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Already Used";
            this.lblInfo.Visible = false;
            // 
            // CtrlOutputSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkInvert);
            this.Controls.Add(this.lstInput);
            this.Name = "CtrlOutputSelector";
            this.Size = new System.Drawing.Size(185, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void lstInput_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.class18_0.method_155("Output Selector setting");
        this.class18_0.method_153();

        if (this.delegate37_0 != null)
        {
            this.delegate37_0(this.method_11());
        }
        this.method_17();
    }
    public void method_Output_location(long int_1)
    {
        this.CheckLocation = int_1;
    }

    private void method_17()
    {
        byte CurrentPutByte = this.class18_0.GetByteAt(this.CheckLocation);
        if (this.class18_0.GetOutputsListLocations() != null)
        {
            if (this.class18_0.GetOutputsListLocations().Count > 0)
            {
                for (int i = 0; i < this.class18_0.GetOutputsListLocations().Count; i++)
                {
                    long TestAt = this.class18_0.GetOutputsListLocations()[i];
                    if (TestAt != this.CheckLocation)
                    {
                        //if ((this.class18_0.method_150(TestAt) == ((byte)int_1))
                        if ((this.class18_0.GetByteAt(TestAt) == CurrentPutByte)
                            && (this.class18_0.GetByteAt(TestAt) != 0xff)
                            && (this.class18_0.GetByteAt(TestAt) != 0x08)) //None (disable output)
                        {
                            this.lblInfo.Visible = true;
                            MessageBox.Show(Form.ActiveForm, "Output already used for '" + this.class18_0.GetOutputsListDesc()[i] + "'", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        this.lblInfo.Visible = false;
                    }
                }
            }
        }
    }

    public void method_1(bool bool_4)
    {
        this.bool_1 = bool_4;
        this.chkInvert.Checked = bool_4;
    }

    public void method_10(byte byte_0)
    {
        this.bool_3 = true;
        this.lstInput.SelectedIndex = byte_0;
        this.bool_3 = false;
    }

    public byte method_11()
    {
        if (this.lstInput.SelectedIndex == (this.lstInput.Items.Count - 1))
        {
            this.chkInvert.Enabled = false;
            return (byte) this.lstInput.SelectedIndex;
        }
        this.chkInvert.Enabled = true;
        return (byte) this.lstInput.SelectedIndex;
    }

    public void method_3(bool bool_4)
    {
        this.bool_2 = bool_4;
        this.chkInvert.Enabled = bool_4;
    }

    public void method_7(bool bool_4)
    {
        this.bool_0 = bool_4;
    }

    public void method_8()
    {
        this.chkInvert.Enabled = this.bool_2;
    }

    public void method_9(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    public delegate void Delegate36(byte byte_0);

    public delegate void Delegate37(byte byte_0);
}

