using Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmGPO1_a : UserControl
{
    private bool bool_0;
    private CheckBox checkBox_0;
    private CheckBox chkEnable;
    private CheckBox chkMaps;
    private CheckBox chkMil;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInputSelector1;
    private ctrlMapValue ctrlMapValueMax;
    private ctrlMapValue ctrlMapValueMin;
    private CtrlOutputSelector ctrlOutputSelector1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox3;
    private GroupBox groupBox5;
    private IContainer icontainer_0;
    private Label label1;
    private Label label12;
    private Label label15;
    private Label label17;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Panel panel1;
    private TextBox txtbEctMax;
    private TextBox txtbEctMin;
    private TextBox txtbIatMax;
    private TextBox txtbIatMin;
    private TextBox txtbRpmMax;
    private TextBox txtbRpmMin;
    private TextBox txtbTps;
    private TextBox txtbVssMax;
    private IContainer components;
    private GroupBox groupBox2;
    private Label label9;
    private Label label8;
    private Label label6;
    private TextBox txtbVssMin;

    internal parmGPO1_a(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_6);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_6);
        this.InitializeComponent();

        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInputSelector1.method_3_CustomInput("None");
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(false);
        this.ctrlInputSelector1.method_5(false);
        //this.ctrlInputSelector1.method_1(0);
        this.ctrlInputSelector1.method_Input_location(this.class18_0.class13_u_0.long_292);

        this.ctrlOutputSelector1.method_1(false);
        this.ctrlOutputSelector1.method_3(true);
        this.ctrlOutputSelector1.method_7(false);
        this.ctrlOutputSelector1.method_Output_location(this.class18_0.class13_u_0.long_294);

        this.ctrlInputSelector1.method_14(ref this.class18_0);
        this.ctrlInputSelector1.method_12();
        this.ctrlInputSelector1.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_5);
        this.ctrlInputSelector1.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_4);
        //this.ctrlInputSelector1.method_1(2);
        this.ctrlOutputSelector1.method_9(ref this.class18_0);
        this.ctrlOutputSelector1.method_8();
        this.ctrlOutputSelector1.delegate37_0 += new CtrlOutputSelector.Delegate37(this.method_2);
        this.ctrlOutputSelector1.delegate36_0 += new CtrlOutputSelector.Delegate36(this.method_3);
        this.ctrlMapValueMin.method_0(ref this.class18_0);
        this.ctrlMapValueMin.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_1);
        this.ctrlMapValueMax.method_0(ref this.class18_0);
        this.ctrlMapValueMax.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_0);
        
        this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_291 });

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        this.method_7();
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
            this.ctrlMapValueMax = new Controls.ctrlMapValue();
            this.ctrlMapValueMin = new Controls.ctrlMapValue();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlOutputSelector1 = new CtrlOutputSelector();
            this.label8 = new System.Windows.Forms.Label();
            this.ctrlInputSelector1 = new CtrlInputSelector();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbTps = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtbVssMax = new System.Windows.Forms.TextBox();
            this.txtbVssMin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbIatMax = new System.Windows.Forms.TextBox();
            this.txtbIatMin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbEctMax = new System.Windows.Forms.TextBox();
            this.txtbEctMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbRpmMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbRpmMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_0 = new System.Windows.Forms.CheckBox();
            this.chkMil = new System.Windows.Forms.CheckBox();
            this.chkMaps = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlMapValueMax
            // 
            this.ctrlMapValueMax.Location = new System.Drawing.Point(93, 206);
            this.ctrlMapValueMax.Name = "ctrlMapValueMax";
            this.ctrlMapValueMax.rawValue = ((byte)(0));
            this.ctrlMapValueMax.Size = new System.Drawing.Size(137, 23);
            this.ctrlMapValueMax.TabIndex = 30;
            // 
            // ctrlMapValueMin
            // 
            this.ctrlMapValueMin.Location = new System.Drawing.Point(93, 178);
            this.ctrlMapValueMin.Name = "ctrlMapValueMin";
            this.ctrlMapValueMin.rawValue = ((byte)(0));
            this.ctrlMapValueMin.Size = new System.Drawing.Size(137, 23);
            this.ctrlMapValueMin.TabIndex = 31;
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
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 475);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 546);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Purpose Output 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ctrlOutputSelector1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ctrlInputSelector1);
            this.groupBox2.Location = new System.Drawing.Point(7, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 163);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input/Output Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = "Output:";
            // 
            // ctrlOutputSelector1
            // 
            this.ctrlOutputSelector1.Location = new System.Drawing.Point(14, 34);
            this.ctrlOutputSelector1.Name = "ctrlOutputSelector1";
            this.ctrlOutputSelector1.Size = new System.Drawing.Size(220, 52);
            this.ctrlOutputSelector1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "Input:";
            // 
            // ctrlInputSelector1
            // 
            this.ctrlInputSelector1.Location = new System.Drawing.Point(14, 107);
            this.ctrlInputSelector1.Name = "ctrlInputSelector1";
            this.ctrlInputSelector1.Size = new System.Drawing.Size(220, 50);
            this.ctrlInputSelector1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.ctrlMapValueMax);
            this.groupBox5.Controls.Add(this.ctrlMapValueMin);
            this.groupBox5.Controls.Add(this.txtbTps);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.txtbVssMax);
            this.groupBox5.Controls.Add(this.txtbVssMin);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtbIatMax);
            this.groupBox5.Controls.Add(this.txtbIatMin);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtbEctMax);
            this.groupBox5.Controls.Add(this.txtbEctMin);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtbRpmMax);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtbRpmMin);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(7, 301);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(246, 239);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Conditions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "Max Load:";
            // 
            // txtbTps
            // 
            this.txtbTps.Location = new System.Drawing.Point(94, 151);
            this.txtbTps.Name = "txtbTps";
            this.txtbTps.Size = new System.Drawing.Size(63, 20);
            this.txtbTps.TabIndex = 10;
            this.txtbTps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbTps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbTps.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 14);
            this.label17.TabIndex = 25;
            this.label17.Text = "TPS:";
            // 
            // txtbVssMax
            // 
            this.txtbVssMax.Location = new System.Drawing.Point(167, 67);
            this.txtbVssMax.Name = "txtbVssMax";
            this.txtbVssMax.Size = new System.Drawing.Size(63, 20);
            this.txtbVssMax.TabIndex = 9;
            this.txtbVssMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbVssMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbRpmMin_Validating);
            this.txtbVssMax.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // txtbVssMin
            // 
            this.txtbVssMin.Location = new System.Drawing.Point(94, 67);
            this.txtbVssMin.Name = "txtbVssMin";
            this.txtbVssMin.Size = new System.Drawing.Size(63, 20);
            this.txtbVssMin.TabIndex = 8;
            this.txtbVssMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbVssMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbRpmMin_Validating);
            this.txtbVssMin.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 14);
            this.label15.TabIndex = 20;
            this.label15.Text = "Speed(kmh):";
            // 
            // txtbIatMax
            // 
            this.txtbIatMax.Location = new System.Drawing.Point(167, 123);
            this.txtbIatMax.Name = "txtbIatMax";
            this.txtbIatMax.Size = new System.Drawing.Size(63, 20);
            this.txtbIatMax.TabIndex = 7;
            this.txtbIatMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbIatMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbIatMax.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // txtbIatMin
            // 
            this.txtbIatMin.Location = new System.Drawing.Point(94, 123);
            this.txtbIatMin.Name = "txtbIatMin";
            this.txtbIatMin.Size = new System.Drawing.Size(63, 20);
            this.txtbIatMin.TabIndex = 6;
            this.txtbIatMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbIatMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbIatMin.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 14);
            this.label12.TabIndex = 15;
            this.label12.Text = "IAT(C):";
            // 
            // txtbEctMax
            // 
            this.txtbEctMax.Location = new System.Drawing.Point(167, 95);
            this.txtbEctMax.Name = "txtbEctMax";
            this.txtbEctMax.Size = new System.Drawing.Size(63, 20);
            this.txtbEctMax.TabIndex = 5;
            this.txtbEctMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbEctMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbEctMax.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // txtbEctMin
            // 
            this.txtbEctMin.Location = new System.Drawing.Point(94, 95);
            this.txtbEctMin.Name = "txtbEctMin";
            this.txtbEctMin.Size = new System.Drawing.Size(63, 20);
            this.txtbEctMin.TabIndex = 4;
            this.txtbEctMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbEctMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEctMin_Validating);
            this.txtbEctMin.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "ECT(C):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Min Load:";
            // 
            // txtbRpmMax
            // 
            this.txtbRpmMax.Location = new System.Drawing.Point(167, 39);
            this.txtbRpmMax.Name = "txtbRpmMax";
            this.txtbRpmMax.Size = new System.Drawing.Size(63, 20);
            this.txtbRpmMax.TabIndex = 1;
            this.txtbRpmMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbRpmMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbRpmMin_Validating);
            this.txtbRpmMax.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maximum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimum";
            // 
            // txtbRpmMin
            // 
            this.txtbRpmMin.Location = new System.Drawing.Point(94, 39);
            this.txtbRpmMin.Name = "txtbRpmMin";
            this.txtbRpmMin.Size = new System.Drawing.Size(63, 20);
            this.txtbRpmMin.TabIndex = 0;
            this.txtbRpmMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpmMin_KeyPress);
            this.txtbRpmMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbRpmMin_Validating);
            this.txtbRpmMin.Validated += new System.EventHandler(this.txtbRpmMin_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "RPM:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_0);
            this.groupBox3.Controls.Add(this.chkMil);
            this.groupBox3.Controls.Add(this.chkMaps);
            this.groupBox3.Location = new System.Drawing.Point(7, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 92);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // checkBox_0
            // 
            this.checkBox_0.AutoSize = true;
            this.checkBox_0.Location = new System.Drawing.Point(7, 69);
            this.checkBox_0.Name = "checkBox_0";
            this.checkBox_0.Size = new System.Drawing.Size(183, 18);
            this.checkBox_0.TabIndex = 3;
            this.checkBox_0.Text = "Disable If FTL/FTS/Boost Cut";
            this.checkBox_0.UseVisualStyleBackColor = true;
            this.checkBox_0.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            this.checkBox_0.Validated += new System.EventHandler(this.parmGPO1_Load);
            // 
            // chkMil
            // 
            this.chkMil.AutoSize = true;
            this.chkMil.Location = new System.Drawing.Point(7, 44);
            this.chkMil.Name = "chkMil";
            this.chkMil.Size = new System.Drawing.Size(129, 18);
            this.chkMil.TabIndex = 2;
            this.chkMil.Text = "Disable If MIL Code";
            this.chkMil.UseVisualStyleBackColor = true;
            this.chkMil.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            this.chkMil.Validated += new System.EventHandler(this.parmGPO1_Load);
            // 
            // chkMaps
            // 
            this.chkMaps.AutoSize = true;
            this.chkMaps.Location = new System.Drawing.Point(7, 20);
            this.chkMaps.Name = "chkMaps";
            this.chkMaps.Size = new System.Drawing.Size(228, 18);
            this.chkMaps.TabIndex = 0;
            this.chkMaps.Text = "Switch to Secondary Maps on Output";
            this.chkMaps.UseVisualStyleBackColor = true;
            this.chkMaps.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            this.chkMaps.Validated += new System.EventHandler(this.parmGPO1_Load);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(13, 20);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(195, 18);
            this.chkEnable.TabIndex = 0;
            this.chkEnable.Text = "Enable General Purpose Output";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            this.chkEnable.Validated += new System.EventHandler(this.parmGPO1_Load);
            // 
            // parmGPO1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmGPO1";
            this.Size = new System.Drawing.Size(296, 475);
            this.Load += new System.EventHandler(this.parmGPO1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("GPO 1 Settings", false);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_302, byte_0);
            this.class18_0.method_153();
            this.parmGPO1_Load(null, null);
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("GPO 1 Settings", false);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_301, byte_0);
            this.class18_0.method_153();
            this.parmGPO1_Load(null, null);
        }
    }

    private void method_2(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("GPO 1 Output");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_294, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_3(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("GPO 1 Invert Output");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_295, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_4(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("GPO 1 Invert Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_293, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_5(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("GPO 1 Input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_292, byte_0);
            this.class18_0.method_153();
        }
    }

    private void method_6()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmGPO1_Load(null, null);
        }
    }

    private void method_7()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("GPO 1 Settings");
            if (this.chkEnable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_291, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_291, 0);
            }
            if (this.checkBox_0.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_297, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_297, 0);
            }
            if (this.chkMaps.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_298, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_298, 0);
            }
            if (this.chkMil.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_296, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_296, 0);
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_299, this.class18_0.method_219(int.Parse(this.txtbRpmMin.Text)));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_300, this.class18_0.method_219(int.Parse(this.txtbRpmMax.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_303, this.class18_0.method_230(double.Parse(this.txtbEctMin.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_304, this.class18_0.method_230(double.Parse(this.txtbEctMax.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_305, this.class18_0.method_230(double.Parse(this.txtbIatMin.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_306, this.class18_0.method_230(double.Parse(this.txtbIatMax.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_307, this.class18_0.method_233(int.Parse(this.txtbVssMin.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_308, this.class18_0.method_233(int.Parse(this.txtbVssMax.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_309, this.class18_0.method_228(int.Parse(this.txtbTps.Text)));
            this.class18_0.method_153();
            this.parmGPO1_Load(null, null);
        }
    }

    private void parmGPO1_Load(object sender, EventArgs e)
    {
        if (this.groupBox1.Enabled)
        {
            this.bool_0 = true;

            this.label15.Text = "Speed(" + this.class18_0.class10_settings_0.vssUnits_0.ToString() + "):";
            this.label5.Text = "ECT(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";
            this.label12.Text = "IAT(" + this.class18_0.class10_settings_0.temperatureUnits_0.ToString() + "):";

            this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_291) == 0xff;
            this.ctrlOutputSelector1.method_10(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_294));
            this.ctrlOutputSelector1.method_1(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_295) == 0xff);
            this.ctrlInputSelector1.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_292));
            this.ctrlInputSelector1.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_293) == 0xff);
            this.checkBox_0.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_297) == 0xff;
            this.chkMaps.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_298) == 0xff;
            this.chkMil.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_296) == 0xff;
            this.txtbRpmMin.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_299)).ToString();
            this.txtbRpmMax.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_300)).ToString();
            this.ctrlMapValueMin.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_301);
            this.ctrlMapValueMax.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_302);
            this.txtbEctMin.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_303)).ToString();
            this.txtbEctMax.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_304)).ToString();
            this.txtbIatMin.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_305)).ToString();
            this.txtbIatMax.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_306)).ToString();
            this.txtbVssMin.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_307)).ToString();
            this.txtbVssMax.Text = this.class18_0.method_197(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_308)).ToString();
            this.txtbTps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_309)).ToString();

            if (!this.chkEnable.Checked)
            {
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = false;
                this.groupBox5.Enabled = false;
            }
            else
            {
                this.groupBox2.Enabled = true;
                this.groupBox3.Enabled = true;
                this.groupBox5.Enabled = true;
            }
            this.bool_0 = false;
        }
    }

    private void txtbEctMin_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_255(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Int required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbRpmMin_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            TextBox control = (TextBox) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_7();
            }
            control.Focus();
        }
    }

    private void txtbRpmMin_Validated(object sender, EventArgs e)
    {
        this.method_7();
    }

    private void txtbRpmMin_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
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
}

