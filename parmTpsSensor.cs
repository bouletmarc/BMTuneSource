using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

internal class parmTpsSensor : UserControl
{
    private bool bool_0;
    private CheckBox chkEnable;
    private Class18 class18_0;
    private Class17 class17_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label1;
    private Label label3;
    private TextBox txtbMax;
    private IContainer components;
    private GroupBox groupBox2;
    private Label lblStatus;
    private Label lblVolt;
    private Button btnNext;
    private TextBox txtbMin;

    private byte byte_0;
    private byte byte_1;
    private byte byte_2;
    private int int_0;
    private Label label4;
    private Label label2;
    private Panel panel1;
    private bool EngRunning = false;

    internal parmTpsSensor(ref Class18 rm, ref Class17 class17_1)
    {
        this.class17_0 = class17_1;
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();
        this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_1_2);
        
        this.groupBox2.Enabled= true;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkEnable.Checked)
        {
            this.txtbMin.Enabled = true;
            this.txtbMax.Enabled = true;
        }
        else
        {
            this.txtbMin.Enabled = false;
            this.txtbMax.Enabled = false;
        }
        if (!this.bool_0)
        {
            this.method_1();
            this.parmTpsSensor_Load(null, null);
        }
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }
        catch { }
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbMax = new System.Windows.Forms.TextBox();
            this.txtbMin = new System.Windows.Forms.TextBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblVolt = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbMax);
            this.groupBox1.Controls.Add(this.txtbMin);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TPS Sensor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "V";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(7, 20);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(129, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable Custom TPS";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "TPS at 0%:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "TPS at 100%:";
            // 
            // txtbMax
            // 
            this.txtbMax.Location = new System.Drawing.Point(92, 76);
            this.txtbMax.Name = "txtbMax";
            this.txtbMax.Size = new System.Drawing.Size(49, 20);
            this.txtbMax.TabIndex = 5;
            this.txtbMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMin_KeyPress);
            this.txtbMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMin_Validating);
            this.txtbMax.Validated += new System.EventHandler(this.txtbMin_Validated);
            // 
            // txtbMin
            // 
            this.txtbMin.Location = new System.Drawing.Point(92, 48);
            this.txtbMin.Name = "txtbMin";
            this.txtbMin.Size = new System.Drawing.Size(49, 20);
            this.txtbMin.TabIndex = 4;
            this.txtbMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMin_KeyPress);
            this.txtbMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMin_Validating);
            this.txtbMin.Validated += new System.EventHandler(this.txtbMin_Validated);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.lblVolt);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Location = new System.Drawing.Point(3, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 106);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calibrate TPS";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(5, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 14);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Set TPS at 0%";
            // 
            // lblVolt
            // 
            this.lblVolt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolt.ForeColor = System.Drawing.Color.IndianRed;
            this.lblVolt.Location = new System.Drawing.Point(3, 74);
            this.lblVolt.Name = "lblVolt";
            this.lblVolt.Size = new System.Drawing.Size(169, 29);
            this.lblVolt.TabIndex = 10;
            this.lblVolt.Text = "0.45v";
            this.lblVolt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(40, 45);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(97, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 245);
            this.panel1.TabIndex = 2;
            // 
            // parmTpsSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmTpsSensor";
            this.Size = new System.Drawing.Size(210, 245);
            this.Load += new System.EventHandler(this.parmTpsSensor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmTpsSensor_Load(null, null);
        }
    }

    private void method_1()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Tps Sensor Scaling");
            if (this.chkEnable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_112, 0xff);
                if (this.chkEnable.Checked)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113 + 2L, this.class18_0.method_227(float.Parse(this.txtbMin.Text)));
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113, this.class18_0.method_227(float.Parse(this.txtbMax.Text)));
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113 + 2L, 0x18);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113, 0xe8);
                }
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_112, 0);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113 + 2L, 0x18);
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113, 0xe8);
            }
            this.class18_0.method_153();
        }
    }

    private void parmTpsSensor_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.txtbMin.Text = this.class18_0.method_196(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_113 + 2L)).ToString("0.00");
        this.txtbMax.Text = this.class18_0.method_196(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_113)).ToString("0.00");
        this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_112) == 0xff;
        if (this.chkEnable.Checked)
        {
            this.txtbMin.Enabled = true;
            this.txtbMax.Enabled = true;
        }
        else
        {
            this.txtbMax.Enabled = false;
            this.txtbMin.Enabled = false;
        }
        if (!this.class17_0.method_34_GetConnected())
        {
            this.lblStatus.Text = "Ecu not connected";
            this.btnNext.Enabled = false;
            this.lblVolt.Visible = false;
        }
        this.bool_0 = false;
    }

    private void txtbMin_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_1();
            }
            control.Focus();
        }
    }

    private void txtbMin_Validated(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbMin_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
        if (!e.Cancel && ((control.Name == "txtbMin") || (control.Name == "txtbMax")))
        {
            if (double.Parse(this.txtbMin.Text) >= double.Parse(this.txtbMax.Text))
            {
                this.errorProvider_0.SetError(control, "Error with TPS Voltage!");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider_0.SetError(control, "");
            }
        }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Tps calibration");
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_112, 0xff);
        this.class18_0.method_153();
        if (this.int_0 == 0)
        {
            this.btnNext.Text = "Next";
            this.lblStatus.Text = "Set TPS at 100%";
            this.class18_0.method_155("Tps calibration 0%");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113 + 2L, this.byte_0);
            this.class18_0.method_153();
            this.byte_1 = this.byte_0;
            this.int_0++;
            this.lblStatus.Text = "Set TPS at 100%";
        }
        else if (this.int_0 == 1)
        {
            this.byte_2 = this.byte_0;
            this.class18_0.method_155("Tps calibration 100%");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113, this.byte_0);
            this.class18_0.method_153();
            this.lblStatus.Text = "Done, 0%: " + this.class18_0.method_196(this.byte_1).ToString() + "v ; 100%: " + this.class18_0.method_196(this.byte_2).ToString() + "v";
            this.lblStatus.Visible = true;
            this.btnNext.Text = "Redo";
            this.int_0 = 0;
        }
        this.parmTpsSensor_Load(sender, e);
        this.class18_0.method_153();
    }

    private void method_1_2(Struct12 struct12_0)
    {
        if ((int)this.class18_0.method_218((long)struct12_0.ushort_0_E6_7) > 50)
        {
            this.lblStatus.Text = "Engine Running!";
            this.EngRunning = true;
        }
        else
        {
            this.EngRunning = false;
        }

        if (!this.EngRunning)
        {
            if (!this.btnNext.Enabled)
            {
                this.btnNext.Enabled = true;
                this.lblVolt.Visible = true;
                this.lblStatus.Text = "Set TPS at 0%";
            }
            this.byte_0 = struct12_0.byte_5;
            this.lblVolt.Text = this.class18_0.method_196(struct12_0.byte_5).ToString("0.00") + "v";
        }
    }
}

