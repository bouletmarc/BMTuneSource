using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmGearLearn : Form
{
    private bool bool_0;
    private Button btnAdvance;
    private Button btnCancel;
    private Button btnG1;
    private Button btnG2;
    private Button btnG3;
    private Button btnG4;
    private Button btnNext;
    private Button btnOK;
    private Button btnPrev;
    private Button btnReset;
    private Class17 class17_0;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox grpCustomRatio;
    private IContainer icontainer_0;
    private int int_0;
    private int int_1;
    private Label label1;
    private Label label10;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label8;
    private Label lblGear;
    private Label lblMSG;
    private Label lblRaw;
    private Label lblRawMax;
    private Label lblRpm;
    private Label lblVss;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private IContainer components;
    private TextBox textBox4;

    private DateTime LastCheck = DateTime.Now;
    internal frmGearLearn()
    {
        this.InitializeComponent();

    }

    private void btnAdvance_Click(object sender, EventArgs e)
    {
        this.bool_0 = !this.bool_0;
        this.btnPrev.Enabled = !this.bool_0;
        this.btnNext.Enabled = !this.bool_0;
        this.grpCustomRatio.Enabled = this.bool_0;
        this.method_3(0, this.bool_0);
        this.btnNext.Text = "Start";
    }

    private void btnG1_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Gear Learn (Gear1) Settings");
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63, (long) this.int_1);
        this.int_1 = 0;
        this.lblRawMax.Text = "0";
        this.frmGearLearn_Load(null, null);
    }

    private void btnG2_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Gear Learn (Gear2) Settings");
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 2L, (long) this.int_1);
        this.int_1 = 0;
        this.lblRawMax.Text = "0";
        this.frmGearLearn_Load(null, null);
    }

    private void btnG3_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Gear Learn (Gear3) Settings");
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 4L, (long) (this.int_1 + 6));
        this.int_1 = 0;
        this.lblRawMax.Text = "0";
        this.frmGearLearn_Load(null, null);
    }

    private void btnG4_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Gear Learn (Gear4) Settings");
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 6L, (long) (this.int_1 + 6));
        this.int_1 = 0;
        this.lblRawMax.Text = "0";
        this.frmGearLearn_Load(null, null);
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Gear Learn Settings");
        if ((this.int_0 == 1) && (this.int_1 != 0))
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63, (long) this.int_1);
        }
        else if ((this.int_0 == 2) && (this.int_1 != 0))
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 2L, (long) this.int_1);
        }
        else if ((this.int_0 == 3) && (this.int_1 != 0))
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 4L, (long) this.int_1);
        }
        else if ((this.int_0 == 4) && (this.int_1 != 0))
        {
            this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 6L, (long) this.int_1);
        }
        this.frmGearLearn_Load(null, null);
        if (this.int_0 < 5)
        {
            this.int_0++;
        }
        this.method_3(this.int_0, false);
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
        if (this.int_0 == 5)
        {
            this.int_0 = 0;
            this.method_3(this.int_0, false);
        }
        else
        {
            if (this.int_0 > 0)
            {
                this.int_0--;
            }
            this.method_3(this.int_0, false);
        }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        this.int_1 = 0;
        this.lblRawMax.Text = "0";
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmGearLearn_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.class18_0.method_153();
    }

    private void frmGearLearn_Load(object sender, EventArgs e)
    {
        bool flag = this.class17_0.method_34_GetConnected();
        if (!this.bool_0)
        {
            this.grpCustomRatio.Enabled = flag;
            this.btnAdvance.Enabled = flag;
            this.btnNext.Enabled = flag;
            this.btnPrev.Enabled = flag;
            this.btnOK.Enabled = flag;
            this.btnReset.Enabled = flag;
        }
        this.grpCustomRatio.Enabled = this.bool_0;
        if (!flag)
        {
            this.lblMSG.Text = "Datalogging not connected";
            this.lblGear.Text = "";
            this.lblMSG.ForeColor = Color.Red;
        }
        else
        {
            this.textBox1.Text = this.class18_0.method_152(this.class18_0.class13_u_0.long_63).ToString();
            this.textBox2.Text = this.class18_0.method_152(this.class18_0.class13_u_0.long_63 + 2L).ToString();
            this.textBox3.Text = this.class18_0.method_152(this.class18_0.class13_u_0.long_63 + 4L).ToString();
            this.textBox4.Text = this.class18_0.method_152(this.class18_0.class13_u_0.long_63 + 6L).ToString();
            if (!this.bool_0)
            {
                this.method_3(0, false);
                this.btnNext.Text = "Start";
            }
            else
            {
                this.method_3(0, true);
            }
        }
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGearLearn));
            this.lblMSG = new System.Windows.Forms.Label();
            this.lblGear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRaw = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.grpCustomRatio = new System.Windows.Forms.GroupBox();
            this.btnG4 = new System.Windows.Forms.Button();
            this.btnG3 = new System.Windows.Forms.Button();
            this.btnG2 = new System.Windows.Forms.Button();
            this.btnG1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRpm = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblVss = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRawMax = new System.Windows.Forms.Label();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.grpCustomRatio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMSG
            // 
            this.lblMSG.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSG.Location = new System.Drawing.Point(14, 42);
            this.lblMSG.Name = "lblMSG";
            this.lblMSG.Size = new System.Drawing.Size(285, 29);
            this.lblMSG.TabIndex = 0;
            this.lblMSG.Text = "Drive in gear 1 and press \"Next Gear\"";
            this.lblMSG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGear
            // 
            this.lblGear.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGear.Location = new System.Drawing.Point(14, 7);
            this.lblGear.Name = "lblGear";
            this.lblGear.Size = new System.Drawing.Size(198, 32);
            this.lblGear.TabIndex = 1;
            this.lblGear.Text = "Learning Gear: 1";
            this.lblGear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Raw ratio:";
            // 
            // lblRaw
            // 
            this.lblRaw.AutoSize = true;
            this.lblRaw.Location = new System.Drawing.Point(95, 20);
            this.lblRaw.Name = "lblRaw";
            this.lblRaw.Size = new System.Drawing.Size(14, 14);
            this.lblRaw.TabIndex = 3;
            this.lblRaw.Text = "0";
            // 
            // btnPrev
            // 
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(194, 147);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(105, 25);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "Prev Gear";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // grpCustomRatio
            // 
            this.grpCustomRatio.Controls.Add(this.btnG4);
            this.grpCustomRatio.Controls.Add(this.btnG3);
            this.grpCustomRatio.Controls.Add(this.btnG2);
            this.grpCustomRatio.Controls.Add(this.btnG1);
            this.grpCustomRatio.Controls.Add(this.textBox4);
            this.grpCustomRatio.Controls.Add(this.label5);
            this.grpCustomRatio.Controls.Add(this.textBox3);
            this.grpCustomRatio.Controls.Add(this.label4);
            this.grpCustomRatio.Controls.Add(this.textBox2);
            this.grpCustomRatio.Controls.Add(this.label3);
            this.grpCustomRatio.Controls.Add(this.textBox1);
            this.grpCustomRatio.Controls.Add(this.label6);
            this.grpCustomRatio.Enabled = false;
            this.grpCustomRatio.Location = new System.Drawing.Point(14, 141);
            this.grpCustomRatio.Name = "grpCustomRatio";
            this.grpCustomRatio.Size = new System.Drawing.Size(174, 119);
            this.grpCustomRatio.TabIndex = 10;
            this.grpCustomRatio.TabStop = false;
            this.grpCustomRatio.Text = "Ratio\'s Raw";
            // 
            // btnG4
            // 
            this.btnG4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnG4.Location = new System.Drawing.Point(117, 88);
            this.btnG4.Name = "btnG4";
            this.btnG4.Size = new System.Drawing.Size(47, 22);
            this.btnG4.TabIndex = 23;
            this.btnG4.Text = "Set";
            this.btnG4.UseVisualStyleBackColor = true;
            this.btnG4.Click += new System.EventHandler(this.btnG4_Click);
            // 
            // btnG3
            // 
            this.btnG3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnG3.Location = new System.Drawing.Point(117, 64);
            this.btnG3.Name = "btnG3";
            this.btnG3.Size = new System.Drawing.Size(47, 22);
            this.btnG3.TabIndex = 22;
            this.btnG3.Text = "Set";
            this.btnG3.UseVisualStyleBackColor = true;
            this.btnG3.Click += new System.EventHandler(this.btnG3_Click);
            // 
            // btnG2
            // 
            this.btnG2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnG2.Location = new System.Drawing.Point(117, 40);
            this.btnG2.Name = "btnG2";
            this.btnG2.Size = new System.Drawing.Size(47, 22);
            this.btnG2.TabIndex = 21;
            this.btnG2.Text = "Set";
            this.btnG2.UseVisualStyleBackColor = true;
            this.btnG2.Click += new System.EventHandler(this.btnG2_Click);
            // 
            // btnG1
            // 
            this.btnG1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnG1.Location = new System.Drawing.Point(117, 16);
            this.btnG1.Name = "btnG1";
            this.btnG1.Size = new System.Drawing.Size(47, 22);
            this.btnG1.TabIndex = 20;
            this.btnG1.Text = "Set";
            this.btnG1.UseVisualStyleBackColor = true;
            this.btnG1.Click += new System.EventHandler(this.btnG1_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(60, 90);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(48, 20);
            this.textBox4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "gear 4:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(60, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(48, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "gear 3:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(60, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "gear 2:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "gear 1:";
            // 
            // lblRpm
            // 
            this.lblRpm.AutoSize = true;
            this.lblRpm.Location = new System.Drawing.Point(252, 41);
            this.lblRpm.Name = "lblRpm";
            this.lblRpm.Size = new System.Drawing.Size(14, 14);
            this.lblRpm.TabIndex = 12;
            this.lblRpm.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "Rpm:";
            // 
            // lblVss
            // 
            this.lblVss.AutoSize = true;
            this.lblVss.Location = new System.Drawing.Point(252, 21);
            this.lblVss.Name = "lblVss";
            this.lblVss.Size = new System.Drawing.Size(14, 14);
            this.lblVss.TabIndex = 14;
            this.lblVss.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(165, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "VSS raw:";
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(194, 175);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(105, 25);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next Gear";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(160, 268);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 25);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "Finished";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(48, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 25);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRawMax);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblRaw);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblRpm);
            this.groupBox1.Controls.Add(this.lblVss);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(14, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 62);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Raw avg ratio:";
            // 
            // lblRawMax
            // 
            this.lblRawMax.AutoSize = true;
            this.lblRawMax.Location = new System.Drawing.Point(95, 39);
            this.lblRawMax.Name = "lblRawMax";
            this.lblRawMax.Size = new System.Drawing.Size(14, 14);
            this.lblRawMax.TabIndex = 16;
            this.lblRawMax.Text = "0";
            // 
            // btnAdvance
            // 
            this.btnAdvance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvance.Location = new System.Drawing.Point(194, 232);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(105, 25);
            this.btnAdvance.TabIndex = 20;
            this.btnAdvance.Text = "Advance";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(194, 203);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 25);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset Current";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmGearLearn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 303);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAdvance);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grpCustomRatio);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblGear);
            this.Controls.Add(this.lblMSG);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGearLearn";
            this.Text = "Gear Learn Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGearLearn_FormClosing);
            this.Load += new System.EventHandler(this.frmGearLearn_Load);
            this.grpCustomRatio.ResumeLayout(false);
            this.grpCustomRatio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);

    }

    internal void method_0(ref Class18 class18_1, ref Class17 class17_1)
    {
        this.class18_0 = class18_1;
        this.class18_0.method_156("Gear learn tool", true);
        this.class17_0 = class17_1;
        this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1(Struct12 struct12_0)
    {
        if ((DateTime.Now - LastCheck).TotalMilliseconds >= this.class18_0.class10_settings_0.int_ActiveDatalog[4])
        {
            LastCheck = DateTime.Now;
            if (this.class17_0.method_34_GetConnected() && ((this.int_0 != 0) || this.bool_0))
            {
                int num = struct12_0.byte_14_E16;
                int num2 = this.class18_0.method_218((long)struct12_0.ushort_0_E6_7);
                this.lblRpm.Text = num2.ToString();
                this.lblVss.Text = num.ToString();
                this.lblRaw.Text = this.method_4((double)num, (double)num2).ToString();
                if (this.int_1 == 0)
                {
                    this.int_1 = this.method_4((double)num, (double)num2);
                }
                else
                {
                    this.int_1 = (this.int_1 + this.method_4((double)num, (double)num2)) / 2;
                }
                this.lblRawMax.Text = this.int_1.ToString();
                if (this.bool_0)
                {
                    this.lblRaw.Text = this.lblRaw.Text + "/" + ((this.method_4((double)num, (double)num2) + 6)).ToString();
                    this.lblRawMax.Text = this.lblRawMax.Text + "/" + ((this.int_1 + 6)).ToString();
                }
            }
        }
    }

    private void method_2(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.percentage)
        {
            if (!this.class18_0.method_255(control.Text.ToString()))
            {
                this.errorProvider_0.SetError(control, "Invalid input, Interger required");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider_0.SetError(control, "");
            }
        }
        else if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double positive required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void method_3(int int_2, bool bool_1)
    {
        this.int_1 = 0;
        if (!bool_1)
        {
            this.btnPrev.Text = "Prev Gear";
            if (int_2 == 0)
            {
                this.lblGear.Text = "";
                this.lblMSG.Text = "Press start to start gear learning";
                this.btnPrev.Enabled = false;
            }
            else if (int_2 <= 4)
            {
                this.btnPrev.Enabled = true;
                this.btnNext.Text = "Next Gear";
                this.lblGear.Text = "Learning gear: " + int_2.ToString();
                this.lblMSG.Text = "Drive in gear " + int_2.ToString() + " and press \"Next Gear\"";
                this.lblMSG.ForeColor = Color.Black;
            }
            else
            {
                this.btnPrev.Enabled = true;
                this.lblGear.Text = "";
                this.lblMSG.Text = "Gear learning finished";
                this.btnPrev.Text = "Restart";
            }
            this.btnNext.Enabled = int_2 != 5;
        }
        else
        {
            this.lblMSG.Text = "";
            this.lblGear.Text = "Advance mode";
        }
    }

    private int method_4(double double_0, double double_1)
    {
        double num = 0.0;
        if (this.bool_0)
        {
            num = Math.Floor((double) ((((double_0 * 256.0) * (1875000.0 / double_1)) / 65535.0) + 14.0));
        }
        else if ((this.int_0 == 1) || (this.int_0 == 2))
        {
            num = Math.Floor((double) ((((double_0 * 256.0) * (1875000.0 / double_1)) / 65535.0) + 14.0));
        }
        else
        {
            if ((this.int_0 != 3) && (this.int_0 != 4))
            {
                return 0;
            }
            num = Math.Floor((double) ((((double_0 * 256.0) * (1875000.0 / double_1)) / 65535.0) + 20.0));
        }
        return (int) num;
    }
}

