using Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmLeanProtection : UserControl
{
    private bool bool_0;
    private CheckBox checkBox_0;
    private CheckBox checkBox_1;
    private Class18 class18_0;
    private double double_0;
    private double double_1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private IContainer icontainer_0;
    private Label label1;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label15;
    private Label label17;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private ctrlMapValue lean1Map;
    private ctrlMapValue lean2Map;
    private TextBox txtbLean1AfrVal;
    private TextBox txtbLean1AfrVolt;
    private TextBox txtbLean1Tmr;
    private TextBox txtbLean2AfrVal;
    private TextBox txtbLean2AfrVolt;
    private TextBox txtbLean2Tmr;
    private TextBox txtbMinRpm;
    private IContainer components;
    private Panel panel1;
    private TextBox txtbMinTps;

    internal parmLeanProtection(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_2);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_2);
        this.InitializeComponent();
        this.lean1Map.method_0(ref this.class18_0);
        this.lean1Map.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_1);
        this.lean2Map.method_0(ref this.class18_0);
        this.lean2Map.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_0);
        
        this.groupBox1.Enabled = true;

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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtbLean2AfrVal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtbLean2AfrVolt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbLean2Tmr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox_1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbLean1AfrVal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbLean1Tmr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbLean1AfrVolt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_0 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbMinTps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbMinRpm = new System.Windows.Forms.TextBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lean2Map = new Controls.ctrlMapValue();
            this.lean1Map = new Controls.ctrlMapValue();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbMinTps);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtbMinRpm);
            this.groupBox1.Controls.Add(this.checkBox_0);
            this.groupBox1.Controls.Add(this.checkBox_1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lean Protection Settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtbLean2AfrVal);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtbLean2AfrVolt);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtbLean2Tmr);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lean2Map);
            this.groupBox4.Location = new System.Drawing.Point(7, 214);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 95);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lean Protection 2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 14);
            this.label10.TabIndex = 15;
            this.label10.Text = "afr";
            // 
            // txtbLean2AfrVal
            // 
            this.txtbLean2AfrVal.Location = new System.Drawing.Point(173, 47);
            this.txtbLean2AfrVal.Name = "txtbLean2AfrVal";
            this.txtbLean2AfrVal.Size = new System.Drawing.Size(40, 20);
            this.txtbLean2AfrVal.TabIndex = 2;
            this.txtbLean2AfrVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbLean2AfrVal_KeyPress);
            this.txtbLean2AfrVal.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLean1AfrVolt_Validating);
            this.txtbLean2AfrVal.Validated += new System.EventHandler(this.txtbLean2AfrVal_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(146, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 14);
            this.label17.TabIndex = 14;
            this.label17.Text = "V";
            // 
            // txtbLean2AfrVolt
            // 
            this.txtbLean2AfrVolt.Location = new System.Drawing.Point(102, 47);
            this.txtbLean2AfrVolt.Name = "txtbLean2AfrVolt";
            this.txtbLean2AfrVolt.Size = new System.Drawing.Size(40, 20);
            this.txtbLean2AfrVolt.TabIndex = 1;
            this.txtbLean2AfrVolt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinRpm_KeyPress);
            this.txtbLean2AfrVolt.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLean1AfrVolt_Validating);
            this.txtbLean2AfrVolt.Validated += new System.EventHandler(this.txtbMinRpm_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "mSec";
            // 
            // txtbLean2Tmr
            // 
            this.txtbLean2Tmr.Location = new System.Drawing.Point(173, 70);
            this.txtbLean2Tmr.Name = "txtbLean2Tmr";
            this.txtbLean2Tmr.Size = new System.Drawing.Size(40, 20);
            this.txtbLean2Tmr.TabIndex = 3;
            this.txtbLean2Tmr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinRpm_KeyPress);
            this.txtbLean2Tmr.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinRpm_Validating);
            this.txtbLean2Tmr.Validated += new System.EventHandler(this.txtbMinRpm_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 14);
            this.label11.TabIndex = 8;
            this.label11.Text = "Max lean duration:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 14);
            this.label12.TabIndex = 6;
            this.label12.Text = "Maximum Afr:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 14);
            this.label13.TabIndex = 5;
            this.label13.Text = "Above load:";
            // 
            // checkBox_1
            // 
            this.checkBox_1.AutoSize = true;
            this.checkBox_1.Location = new System.Drawing.Point(16, 43);
            this.checkBox_1.Name = "checkBox_1";
            this.checkBox_1.Size = new System.Drawing.Size(160, 18);
            this.checkBox_1.TabIndex = 0;
            this.checkBox_1.Text = "Enable Lean Protection 2";
            this.checkBox_1.UseVisualStyleBackColor = true;
            this.checkBox_1.CheckedChanged += new System.EventHandler(this.txtbMinRpm_Validated);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtbLean1AfrVal);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtbLean1Tmr);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtbLean1AfrVolt);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lean1Map);
            this.groupBox3.Location = new System.Drawing.Point(7, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 95);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lean Protection 1:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(216, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 12;
            this.label15.Text = "afr";
            // 
            // txtbLean1AfrVal
            // 
            this.txtbLean1AfrVal.Location = new System.Drawing.Point(173, 47);
            this.txtbLean1AfrVal.Name = "txtbLean1AfrVal";
            this.txtbLean1AfrVal.Size = new System.Drawing.Size(40, 20);
            this.txtbLean1AfrVal.TabIndex = 3;
            this.txtbLean1AfrVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbLean1AfrVal_KeyPress);
            this.txtbLean1AfrVal.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLean1AfrVolt_Validating);
            this.txtbLean1AfrVal.Validated += new System.EventHandler(this.txtbLean1AfrVal_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "mSec";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "V";
            // 
            // txtbLean1Tmr
            // 
            this.txtbLean1Tmr.Location = new System.Drawing.Point(173, 70);
            this.txtbLean1Tmr.Name = "txtbLean1Tmr";
            this.txtbLean1Tmr.Size = new System.Drawing.Size(40, 20);
            this.txtbLean1Tmr.TabIndex = 4;
            this.txtbLean1Tmr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinRpm_KeyPress);
            this.txtbLean1Tmr.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinRpm_Validating);
            this.txtbLean1Tmr.Validated += new System.EventHandler(this.txtbMinRpm_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Max lean duration:";
            // 
            // txtbLean1AfrVolt
            // 
            this.txtbLean1AfrVolt.Location = new System.Drawing.Point(102, 47);
            this.txtbLean1AfrVolt.Name = "txtbLean1AfrVolt";
            this.txtbLean1AfrVolt.Size = new System.Drawing.Size(40, 20);
            this.txtbLean1AfrVolt.TabIndex = 2;
            this.txtbLean1AfrVolt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinRpm_KeyPress);
            this.txtbLean1AfrVolt.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLean1AfrVolt_Validating);
            this.txtbLean1AfrVolt.Validated += new System.EventHandler(this.txtbMinRpm_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Maximum Afr:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Above load:";
            // 
            // checkBox_0
            // 
            this.checkBox_0.AutoSize = true;
            this.checkBox_0.Location = new System.Drawing.Point(16, 19);
            this.checkBox_0.Name = "checkBox_0";
            this.checkBox_0.Size = new System.Drawing.Size(160, 18);
            this.checkBox_0.TabIndex = 0;
            this.checkBox_0.Text = "Enable Lean Protection 1";
            this.checkBox_0.UseVisualStyleBackColor = true;
            this.checkBox_0.CheckedChanged += new System.EventHandler(this.txtbMinRpm_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
            // 
            // txtbMinTps
            // 
            this.txtbMinTps.Location = new System.Drawing.Point(73, 90);
            this.txtbMinTps.Name = "txtbMinTps";
            this.txtbMinTps.Size = new System.Drawing.Size(40, 20);
            this.txtbMinTps.TabIndex = 1;
            this.txtbMinTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinRpm_KeyPress);
            this.txtbMinTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinRpm_Validating);
            this.txtbMinTps.Validated += new System.EventHandler(this.txtbMinRpm_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min RPM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min TPS:";
            // 
            // txtbMinRpm
            // 
            this.txtbMinRpm.Location = new System.Drawing.Point(73, 64);
            this.txtbMinRpm.Name = "txtbMinRpm";
            this.txtbMinRpm.Size = new System.Drawing.Size(40, 20);
            this.txtbMinRpm.TabIndex = 0;
            this.txtbMinRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbMinRpm_KeyPress);
            this.txtbMinRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMinRpm_Validating);
            this.txtbMinRpm.Validated += new System.EventHandler(this.txtbMinRpm_Validated);
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
            this.panel1.Size = new System.Drawing.Size(302, 341);
            this.panel1.TabIndex = 1;
            // 
            // lean2Map
            // 
            this.lean2Map.Location = new System.Drawing.Point(102, 21);
            this.lean2Map.Name = "lean2Map";
            this.lean2Map.rawValue = ((byte)(0));
            this.lean2Map.Size = new System.Drawing.Size(132, 22);
            this.lean2Map.TabIndex = 0;
            // 
            // lean1Map
            // 
            this.lean1Map.Location = new System.Drawing.Point(102, 21);
            this.lean1Map.Name = "lean1Map";
            this.lean1Map.rawValue = ((byte)(0));
            this.lean1Map.Size = new System.Drawing.Size(132, 22);
            this.lean1Map.TabIndex = 1;
            // 
            // parmLeanProtection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "parmLeanProtection";
            this.Size = new System.Drawing.Size(302, 341);
            this.Load += new System.EventHandler(this.parmLeanProtection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        this.class18_0.method_155("Lean Protection");
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_385, byte_0);
        this.class18_0.method_153();
    }

    private void method_1(byte byte_0)
    {
        this.class18_0.method_155("Lean Protection");
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_381, byte_0);
        this.class18_0.method_153();
    }

    private void method_2()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmLeanProtection_Load(null, null);
        }
    }

    private void method_3(object sender, CancelEventArgs e)
    {
    }

    private void method_4()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Lean Protection");
            this.class18_0.method_151(this.class18_0.class13_u_0.long_377, this.class18_0.method_219(int.Parse(this.txtbMinRpm.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_378, this.class18_0.method_228(int.Parse(this.txtbMinTps.Text)));
            if (this.checkBox_0.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_379, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_379, 0);
            }
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_382, this.class18_0.method_227(float.Parse(this.txtbLean1AfrVolt.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_380, (byte) (int.Parse(this.txtbLean1Tmr.Text) / 10));
            if (this.checkBox_1.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_383, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_383, 0);
            }
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_386, this.class18_0.method_227(float.Parse(this.txtbLean2AfrVolt.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_384, (byte) (int.Parse(this.txtbLean2Tmr.Text) / 10));
            this.class18_0.method_153();
            this.parmLeanProtection_Load(null, null);
        }
    }

    private void parmLeanProtection_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.txtbMinRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_377)).ToString();
        this.txtbMinTps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_378)).ToString();
        this.checkBox_0.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_379) != 0;
        this.lean1Map.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_381);
        this.txtbLean1AfrVolt.Text = this.class18_0.method_196(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_382)).ToString();
        this.txtbLean1AfrVal.Text = this.class18_0.method_200(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_382)).ToString();
        this.double_0 = this.class18_0.method_200(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_382));
        this.txtbLean1Tmr.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_380) * 10).ToString();
        this.checkBox_1.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_383) != 0;
        this.lean2Map.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_385);
        this.txtbLean2AfrVolt.Text = this.class18_0.method_196(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_386)).ToString();
        this.txtbLean2AfrVal.Text = this.class18_0.method_200(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_386)).ToString();
        this.double_1 = this.class18_0.method_200(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_386));
        this.txtbLean2Tmr.Text = (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_384) * 10).ToString();

        this.groupBox3.Enabled = this.checkBox_0.Checked;
        this.groupBox4.Enabled = this.checkBox_1.Checked;
        if (!this.checkBox_0.Checked && !this.checkBox_1.Checked)
        {
            this.txtbMinRpm.Enabled = false;
            this.txtbMinTps.Enabled = false;
        }
        else
        {
            this.txtbMinRpm.Enabled = true;
            this.txtbMinTps.Enabled = true;
        }
        this.bool_0 = false;
    }

    private void txtbLean1AfrVal_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.txtbLean1AfrVal_Validated(null, null);
            }
            control.Focus();
            this.parmLeanProtection_Load(null, null);
        }
    }

    private void txtbLean1AfrVal_Validated(object sender, EventArgs e)
    {
        this.class18_0.method_155("Lean Protection");
        try
        {
            if (this.double_0 == double.Parse(this.txtbLean1AfrVal.Text))
            {
                this.class18_0.method_153();
                this.parmLeanProtection_Load(null, null);
                return;
            }
            this.double_0 = double.Parse(this.txtbLean1AfrVal.Text);
            byte num = this.class18_0.method_214(this.double_0);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_382, num);
        }
        catch (Exception)
        {
        }
        this.class18_0.method_153();
        this.parmLeanProtection_Load(null, null);
    }

    private void txtbLean1AfrVolt_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Double Postive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbLean2AfrVal_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.txtbLean2AfrVal_Validated(null, null);
            }
            control.Focus();
            this.parmLeanProtection_Load(null, null);
        }
    }

    private void txtbLean2AfrVal_Validated(object sender, EventArgs e)
    {
        this.class18_0.method_155("Lean Protection");
        try
        {
            if (this.double_1 == double.Parse(this.txtbLean2AfrVal.Text))
            {
                this.class18_0.method_153();
                this.parmLeanProtection_Load(null, null);
                return;
            }
            this.double_1 = double.Parse(this.txtbLean2AfrVal.Text);
            byte num = this.class18_0.method_214(this.double_1);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_386, num);
        }
        catch (Exception)
        {
        }
        this.class18_0.method_153();
        this.parmLeanProtection_Load(null, null);
    }

    private void txtbMinRpm_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_4();
            }
            control.Focus();
        }
    }

    private void txtbMinRpm_Validated(object sender, EventArgs e)
    {
        this.method_4();
    }

    private void txtbMinRpm_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
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

