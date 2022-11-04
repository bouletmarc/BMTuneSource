using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmBurnOut : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private CtrlInputSelector ctrlInputSelector1;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private HelpProvider helpProvider_0;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private IContainer components;
    private NumericUpDown txtbRpm;
    private Panel panel1;

    public parmBurnOut(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.InitializeComponent();

        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(true);
        this.ctrlInputSelector1.method_3_CustomInput("Always On");
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(false);
        this.ctrlInputSelector1.method_5(false);
        //this.ctrlInputSelector1.method_1(0);
        this.ctrlInputSelector1.method_Input_location(this.class18_0.class13_u_0.long_172);

        this.ctrlInputSelector1.method_14(ref this.class18_0);
        this.ctrlInputSelector1.method_3_CustomInput("Always on");
        this.ctrlInputSelector1.method_7_Add_CustomInput_To_Selection(false);
        this.ctrlInputSelector1.method_11_Add_Disabled_In_Selection(true);
        //this.ctrlInputSelector1.method_1(5);
        this.ctrlInputSelector1.method_12();
        this.ctrlInputSelector1.delegate34_0 += new CtrlInputSelector.Delegate34(this.method_1);
        this.ctrlInputSelector1.delegate35_0 += new CtrlInputSelector.Delegate35(this.method_0);
        
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
            this.txtbRpm = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlInputSelector1 = new CtrlInputSelector();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider_0 = new System.Windows.Forms.HelpProvider();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbRpm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctrlInputSelector1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Burnout Control";
            // 
            // txtbRpm
            // 
            this.txtbRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbRpm.Location = new System.Drawing.Point(98, 75);
            this.txtbRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbRpm.Name = "txtbRpm";
            this.txtbRpm.Size = new System.Drawing.Size(74, 20);
            this.txtbRpm.TabIndex = 4;
            this.txtbRpm.Click += new System.EventHandler(this.txtbRpm_Validated);
            this.txtbRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpm_KeyPress);
            this.txtbRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbRpm_Validating);
            this.txtbRpm.Validated += new System.EventHandler(this.parmBurnOut_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "rpm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Burnout rpm:";
            // 
            // ctrlInputSelector1
            // 
            this.ctrlInputSelector1.Location = new System.Drawing.Point(6, 19);
            this.ctrlInputSelector1.Name = "ctrlInputSelector1";
            this.ctrlInputSelector1.Size = new System.Drawing.Size(220, 49);
            this.ctrlInputSelector1.TabIndex = 0;
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
            this.panel1.Size = new System.Drawing.Size(269, 189);
            this.panel1.TabIndex = 1;
            // 
            // parmBurnOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "parmBurnOut";
            this.Size = new System.Drawing.Size(269, 189);
            this.Load += new System.EventHandler(this.parmBurnOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("3Step-Burnout input invert");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_171, byte_0);
            this.class18_0.method_153();
            this.parmBurnOut_Load(null, null);
        }
    }

    private void method_1(byte byte_0)
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("3Step-Burnout input");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_172, byte_0);
            this.class18_0.method_153();
            this.parmBurnOut_Load(null, null);
        }
    }

    private void method_2()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("3Step-Burnout settings");
            this.class18_0.method_151(this.class18_0.class13_u_0.long_173, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)));
            this.class18_0.method_153();
            this.parmBurnOut_Load(null, null);
        }
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmBurnOut_Load(null, null);
        }
    }

    private void parmBurnOut_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        if (this.class18_0.class13_u_0.long_172 != 0L)
        {
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_172) != 0)
            {
                this.txtbRpm.Enabled = true;
            }
            else
            {
                this.txtbRpm.Enabled = false;
            }
            this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_173)).ToString();
            this.ctrlInputSelector1.method_15(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_172));
            this.ctrlInputSelector1.method_5(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_171) == 0xff);
        }
        else
        {
            this.ctrlInputSelector1.Enabled = false;
            this.txtbRpm.Enabled = false;
        }
        this.bool_0 = false;
    }

    private void txtbRpm_KeyPress(object sender, KeyPressEventArgs e)
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

    private void txtbRpm_Validated(object sender, EventArgs e)
    {
        this.method_2();
    }

    private void txtbRpm_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
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

