using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Forms;

internal class CtrlInputSelector : UserControl
{
    private bool bool_0 = true;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private CheckBox chkInvert;
    private Class18 class18_0;
    private IContainer icontainer_0;
    //private int int_0;
    private Label lblInfo;
    private ComboBox lstInput;
    private string string_0 = "Always On";
    //private System.Timers.Timer timer_0 = new System.Timers.Timer(250.0);
    private long CheckLocation = 0L;
    private bool IsLoaded = false;

    public event Delegate34 delegate34_0;
    public event Delegate35 delegate35_0;

    public CtrlInputSelector()
    {
        this.InitializeComponent();
        //this.timer_0.AutoReset = true;
        //this.timer_0.Elapsed += new ElapsedEventHandler(this.timer_0_Elapsed);
    }

    private void chkInvert_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_3)
        {
            byte num = 0;
            if (this.chkInvert.Checked)
            {
                num = 0xff;
            }
            if (this.delegate35_0 != null)
            {
                this.delegate35_0(num);
            }
        }
    }

    private void CtrlInputSelector_Load(object sender, EventArgs e)
    {
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
            this.lstInput.BackColor = System.Drawing.SystemColors.Window;
            this.lstInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInput.FormattingEnabled = true;
            this.lstInput.Items.AddRange(new object[] {
            "Power Steering Switch (B8)",
            "Service Check Connector (D4)",
            "Start Signal (B9)",
            "Vtec Pressure Switch (D6)",
            "AC request (B5)",
            "Brake Switch (D2)",
            "Park/Neutral Input (B7)"});
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
            this.chkInvert.Size = new System.Drawing.Size(80, 17);
            this.chkInvert.TabIndex = 4;
            this.chkInvert.Text = "Invert Input";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(83, 30);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(97, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Input Already Used";
            this.lblInfo.Visible = false;
            // 
            // CtrlInputSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkInvert);
            this.Controls.Add(this.lstInput);
            this.Name = "CtrlInputSelector";
            this.Size = new System.Drawing.Size(185, 49);
            this.Load += new System.EventHandler(this.CtrlInputSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void lstInput_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_3)
        {
            this.class18_0.method_155("Input Selector setting");
            /*if ((this.class18_0.class13_0.long_95 != 0L) && (this.lstInput.SelectedIndex <= 6))
            {
                this.class18_0.method_149(this.class18_0.class13_0.long_95 + this.method_0(), (byte) this.lstInput.SelectedIndex);
            }
            else if ((this.class18_0.class13_0.long_95 != 0L) && (this.lstInput.SelectedIndex == (this.lstInput.Items.Count - 1)))
            {
                this.class18_0.method_149(this.class18_0.class13_0.long_95 + this.method_0(), 0xff);
            }*/
            //this.method_17(this.lstInput.SelectedIndex);
            this.class18_0.method_153();
            if (this.delegate34_0 != null)
            {
                this.delegate34_0(this.method_16());
            }
            this.method_17();
            if ((this.lstInput.SelectedIndex == 0) || (this.lstInput.SelectedIndex == 2))
            {
                this.chkInvert.Checked = true;
            }
            else
            {
                this.chkInvert.Checked = false;
            }
        }
    }

    /*public int method_0()
    {
        return this.int_0;
    }

    public void method_1(int int_1)
    {
        this.int_0 = int_1;
    }*/

    public void method_Input_location(long int_1)
    {
        this.CheckLocation = int_1;
    }

    public void method_11_Add_Disabled_In_Selection(bool bool_4)
    {
        this.bool_1 = bool_4;
    }

    public void method_12()
    {
        if (this.lstInput.Items.Count > 6)
        {
            for (int i = 7; i < this.lstInput.Items.Count; i++)
            {
                this.lstInput.Items.RemoveAt(i);
            }
        }
        if (this.bool_0)
        {
            this.lstInput.Items.Add(this.string_0);
        }
        if (this.bool_1)
        {
            this.lstInput.Items.Add("Disabled");
        }
        if (this.bool_1 && (this.lstInput.SelectedIndex == (this.lstInput.Items.Count - 1)))
        {
            this.chkInvert.Enabled = false;
        }
        if (this.lstInput.SelectedIndex == 7)
        {
            this.chkInvert.Enabled = false;
        }
        else
        {
            this.chkInvert.Enabled = true;
        }

        IsLoaded = true;
    }

    public bool GetLoadedVars()
    {
        return IsLoaded;
    }

    internal void method_14(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    public void method_15(byte byte_0)
    {
        this.bool_3 = true;
        switch (byte_0)
        {
            case 0x20:
                this.lstInput.SelectedIndex = 5;
                break;

            case 0x40:
                this.lstInput.SelectedIndex = 6;
                break;

            case 0x80:
                this.lstInput.SelectedIndex = 7;
                break;

            case 0:
                if (this.bool_1 || !this.bool_0)
                {
                    if (this.bool_1 && this.bool_0)
                    {
                        this.lstInput.SelectedIndex = 8;
                    }
                    else if (this.bool_1 && !this.bool_0)
                    {
                        this.lstInput.SelectedIndex = 7;
                    }
                }
                break;

            case 1:
                this.lstInput.SelectedIndex = 0;
                break;

            case 2:
                this.lstInput.SelectedIndex = 1;
                break;

            case 4:
                this.lstInput.SelectedIndex = 2;
                break;

            case 8:
                this.lstInput.SelectedIndex = 3;
                break;

            case 0x10:
                this.lstInput.SelectedIndex = 4;
                break;
        }
        this.bool_3 = false;
    }

    private byte method_16()
    {
        byte num = 0;
        if (this.bool_1 && (this.lstInput.SelectedIndex == (this.lstInput.Items.Count - 1)))
        {
            this.chkInvert.Enabled = false;
            return 0;
        }
        if (this.lstInput.SelectedIndex == 7)
        {
            this.chkInvert.Enabled = false;
        }
        else
        {
            this.chkInvert.Enabled = true;
        }
        return this.class18_0.method_261(num, this.lstInput.SelectedIndex, true);
    }

    //private void method_17(int int_1)
    private void method_17()
    {
        /*if (this.class18_0.class13_0.long_95 != 0L)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != this.int_0)
                {
                    if ((this.class18_0.method_150(this.class18_0.class13_0.long_95 + i) == ((byte) int_1)) && (this.class18_0.method_150(this.class18_0.class13_0.long_95 + i) != 0xff))
                    {
                        this.lblInfo.Visible = true;
                        return;
                    }
                    this.lblInfo.Visible = false;
                }
            }
        }*/

        byte CurrentPutByte = this.class18_0.GetByteAt(this.CheckLocation);
        if (this.class18_0.GetInputsListLocations() != null)
        {
            if (this.class18_0.GetInputsListLocations().Count > 0)
            {
                for (int i = 0; i < this.class18_0.GetInputsListLocations().Count; i++)
                {
                    long TestAt = this.class18_0.GetInputsListLocations()[i];
                    if (TestAt != this.CheckLocation)
                    {
                        //if ((this.class18_0.method_150(TestAt) == ((byte)int_1))
                        if ((this.class18_0.GetByteAt(TestAt) == CurrentPutByte)
                            && (this.class18_0.GetByteAt(TestAt) != 0xff)
                            && (this.class18_0.GetByteAt(TestAt) != 0x00)  //Disabled Input
                            && (this.class18_0.GetByteAt(TestAt) != 0x80)) //Always On Input
                        {
                            this.lblInfo.Visible = true;
                            MessageBox.Show(Form.ActiveForm, "Input already used for '" + this.class18_0.GetInputsListDesc()[i] + "'", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        this.lblInfo.Visible = false;
                    }
                }
            }
        }
    }

    public void method_3_CustomInput(string string_2)
    {
        this.string_0 = string_2;
    }

    public void method_5(bool bool_4)
    {
        this.bool_3 = true;
        this.bool_2 = bool_4;
        this.chkInvert.Checked = bool_4;
        this.bool_3 = false;
    }

    public void method_7_Add_CustomInput_To_Selection(bool bool_4)
    {
        this.bool_0 = bool_4;
    }

    /*private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
    {
        this.lblInfo.Visible = !this.lblInfo.Visible;
        this.Invalidate();
    }*/

    public delegate void Delegate34(byte byte_0);

    public delegate void Delegate35(byte byte_0);
}

