using Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmBoostCut : UserControl
{
    private bool bool_0;
    private CheckBox chkEnable;
    private Class18 class18_0;
    private ctrlMapValue ctrlBoostCutCold;
    private ctrlMapValue ctrlBoostCutHot;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private Label label3;
    private IContainer components;
    private GroupBox groupBox1;
    private Label lblEct;
    private Panel panel1;
    private CheckBox chkBoostcutOnMil;
    private GroupBox grpType;
    private RadioButton rb1200;
    private Label label7;
    private Label label6;
    private RadioButton rbCurrent;
    private NumericUpDown txtbEct;

    public parmBoostCut(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_2);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_2);
        this.InitializeComponent();
        this.ctrlBoostCutCold.method_0(ref rm);
        this.ctrlBoostCutCold.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_1);
        this.ctrlBoostCutHot.method_0(ref rm);
        this.ctrlBoostCutHot.mapValueChangedDelegate_0 += new ctrlMapValue.MapValueChangedDelegate(this.method_0);
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
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlBoostCutHot = new Controls.ctrlMapValue();
            this.ctrlBoostCutCold = new Controls.ctrlMapValue();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.rb1200 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbCurrent = new System.Windows.Forms.RadioButton();
            this.chkBoostcutOnMil = new System.Windows.Forms.CheckBox();
            this.txtbEct = new System.Windows.Forms.NumericUpDown();
            this.lblEct = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbEct)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(17, 20);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(118, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable Boost Cut";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.rbCurrent_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hot Cut:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cold Cut:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cold/Hot ECT:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // ctrlBoostCutHot
            // 
            this.ctrlBoostCutHot.Location = new System.Drawing.Point(111, 125);
            this.ctrlBoostCutHot.Name = "ctrlBoostCutHot";
            this.ctrlBoostCutHot.rawValue = ((byte)(0));
            this.ctrlBoostCutHot.Size = new System.Drawing.Size(135, 23);
            this.ctrlBoostCutHot.TabIndex = 9;
            // 
            // ctrlBoostCutCold
            // 
            this.ctrlBoostCutCold.Location = new System.Drawing.Point(111, 98);
            this.ctrlBoostCutCold.Name = "ctrlBoostCutCold";
            this.ctrlBoostCutCold.rawValue = ((byte)(0));
            this.ctrlBoostCutCold.Size = new System.Drawing.Size(135, 23);
            this.ctrlBoostCutCold.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpType);
            this.groupBox1.Controls.Add(this.chkBoostcutOnMil);
            this.groupBox1.Controls.Add(this.txtbEct);
            this.groupBox1.Controls.Add(this.lblEct);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Controls.Add(this.ctrlBoostCutHot);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ctrlBoostCutCold);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 234);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boost Cut Settings";
            // 
            // grpType
            // 
            this.grpType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpType.Controls.Add(this.rb1200);
            this.grpType.Controls.Add(this.label7);
            this.grpType.Controls.Add(this.label6);
            this.grpType.Controls.Add(this.rbCurrent);
            this.grpType.Location = new System.Drawing.Point(6, 162);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(257, 67);
            this.grpType.TabIndex = 27;
            this.grpType.TabStop = false;
            this.grpType.Text = "Boost Cut RPM Type";
            // 
            // rb1200
            // 
            this.rb1200.AutoSize = true;
            this.rb1200.Location = new System.Drawing.Point(132, 43);
            this.rb1200.Name = "rb1200";
            this.rb1200.Size = new System.Drawing.Size(14, 13);
            this.rb1200.TabIndex = 4;
            this.rb1200.TabStop = true;
            this.rb1200.UseVisualStyleBackColor = true;
            this.rb1200.CheckedChanged += new System.EventHandler(this.rbCurrent_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "Limit at 1200RPM:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "Limit at Current RPM:";
            // 
            // rbCurrent
            // 
            this.rbCurrent.AutoSize = true;
            this.rbCurrent.Location = new System.Drawing.Point(132, 21);
            this.rbCurrent.Name = "rbCurrent";
            this.rbCurrent.Size = new System.Drawing.Size(14, 13);
            this.rbCurrent.TabIndex = 3;
            this.rbCurrent.TabStop = true;
            this.rbCurrent.UseVisualStyleBackColor = true;
            this.rbCurrent.CheckedChanged += new System.EventHandler(this.rbCurrent_CheckedChanged);
            // 
            // chkBoostcutOnMil
            // 
            this.chkBoostcutOnMil.AutoSize = true;
            this.chkBoostcutOnMil.Location = new System.Drawing.Point(17, 44);
            this.chkBoostcutOnMil.Name = "chkBoostcutOnMil";
            this.chkBoostcutOnMil.Size = new System.Drawing.Size(238, 18);
            this.chkBoostcutOnMil.TabIndex = 26;
            this.chkBoostcutOnMil.Text = "Enable Boost Cut if DTC (Check Engine)";
            this.chkBoostcutOnMil.UseVisualStyleBackColor = true;
            this.chkBoostcutOnMil.CheckedChanged += new System.EventHandler(this.rbCurrent_CheckedChanged);
            // 
            // txtbEct
            // 
            this.txtbEct.Location = new System.Drawing.Point(111, 71);
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
            this.txtbEct.Size = new System.Drawing.Size(66, 20);
            this.txtbEct.TabIndex = 25;
            this.txtbEct.Click += new System.EventHandler(this.txtbEct_Validated);
            this.txtbEct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbEct_KeyPress);
            this.txtbEct.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEct_Validating);
            this.txtbEct.Validated += new System.EventHandler(this.txtbEct_Validated);
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(183, 73);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(15, 14);
            this.lblEct.TabIndex = 24;
            this.lblEct.Text = "C";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 255);
            this.panel1.TabIndex = 11;
            // 
            // parmBoostCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmBoostCut";
            this.Size = new System.Drawing.Size(303, 255);
            this.Load += new System.EventHandler(this.parmBoostCut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbEct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("Boostcut settings", false);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_128, byte_0);
            this.class18_0.method_153();
            this.parmBoostCut_Load(null, null);
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("Boostcut settings", false);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_127, byte_0);
            this.class18_0.method_153();
            this.parmBoostCut_Load(null, null);
        }
    }

    private void method_2()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmBoostCut_Load(null, null);
        }
    }

    private void method_3()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("Boostcut settings", false);
            if (this.chkEnable.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_126, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_126, 0);
            if (this.chkBoostcutOnMil.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_130, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_130, 0);
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_129, this.class18_0.method_230(double.Parse(this.txtbEct.Text)));
            if (this.rbCurrent.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_131, 0);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_131, 0xff);
            this.class18_0.method_153();
            this.parmBoostCut_Load(null, null);
        }
    }

    private void parmBoostCut_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.txtbEct.Text = this.class18_0.method_191(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_129)).ToString();
        this.chkBoostcutOnMil.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_130) == 0xff;
        this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_126) == 0xff;
        this.ctrlBoostCutCold.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_127);
        this.ctrlBoostCutHot.rawValue = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_128);
        this.txtbEct.Enabled = this.chkEnable.Checked;
        this.ctrlBoostCutCold.Enabled = this.chkEnable.Checked;
        this.ctrlBoostCutHot.Enabled = this.chkEnable.Checked;
        this.chkBoostcutOnMil.Enabled = this.chkEnable.Checked;
        this.lblEct.Text = this.class18_0.class10_settings_0.temperatureUnits_0.ToString();
        if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_131) == 0) this.rbCurrent.Checked = true;
        else this.rb1200.Checked = true;
        this.bool_0 = false;
    }

    private void rbCurrent_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_3();
            this.parmBoostCut_Load(null, null);
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
                this.method_3();
            }
            control.Focus();
        }
    }

    private void txtbEct_Validated(object sender, EventArgs e)
    {
        this.method_3();
    }

    private void txtbEct_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        this.groupBox1.Focus();
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

