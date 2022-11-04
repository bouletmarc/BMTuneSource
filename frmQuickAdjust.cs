using eCtune.Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmQuickAdjust : Form
{
    private Class18 class18_0;
    private Enum12 enum12_0;
    private IContainer icontainer_0;
    private TextBox textBox1;

    internal frmQuickAdjust()
    {
        this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmQuickAdjust_KeyDown(object sender, KeyEventArgs e)
    {
        if (((e.KeyData == Keys.Up) || (e.KeyData == Keys.Right)) || (e.KeyData == Keys.PageUp))
        {
            if (this.method_0() != Enum12.const_0)
            {
                if (this.method_0() == Enum12.const_1)
                {
                    double num3 = double.Parse(this.textBox1.Text) + 0.5;
                    this.textBox1.Text = num3.ToString();
                    if (this.class18_0.class13_0.long_34 != 0L)
                    {
                        this.class18_0.method_151(this.class18_0.class13_0.long_34, (long) (num3 * 8.0));
                    }
                }
            }
            else
            {
                double num = double.Parse(this.textBox1.Text);
                double num2 = 1.99;
                if (this.class18_0.class10_0.correctionUnits_0 == CorrectionUnits.percentage)
                {
                    num2 = 100.0;
                }
                if (num < num2)
                {
                    if (this.class18_0.class10_0.correctionUnits_0 == CorrectionUnits.percentage)
                    {
                        num++;
                    }
                    else
                    {
                        num += 0.01;
                    }
                    this.textBox1.Text = num.ToString();
                    if (this.class18_0.class13_0.long_39 != 0L)
                    {
                        this.class18_0.method_151(this.class18_0.class13_0.long_39, this.class18_0.method_231(num, Enum6.const_0));
                    }
                }
            }
        }
        else if (((e.KeyData == Keys.Down) || (e.KeyData == Keys.Left)) || (e.KeyData == Keys.Next))
        {
            if (this.method_0() != Enum12.const_0)
            {
                if (this.method_0() == Enum12.const_1)
                {
                    double num6 = double.Parse(this.textBox1.Text);
                    if (num6 > 0.0)
                    {
                        num6 -= 0.5;
                        this.textBox1.Text = num6.ToString();
                        if (this.class18_0.class13_0.long_34 != 0L)
                        {
                            this.class18_0.method_151(this.class18_0.class13_0.long_34, (long) (num6 * 8.0));
                        }
                    }
                }
            }
            else
            {
                double num4 = double.Parse(this.textBox1.Text);
                double num5 = 0.0;
                if (this.class18_0.class10_0.correctionUnits_0 == CorrectionUnits.percentage)
                {
                    num5 = -100.0;
                }
                if (num4 > num5)
                {
                    if (this.class18_0.class10_0.correctionUnits_0 == CorrectionUnits.percentage)
                    {
                        num4--;
                    }
                    else
                    {
                        num4 -= 0.01;
                    }
                    this.textBox1.Text = num4.ToString();
                    if (this.class18_0.class13_0.long_39 != 0L)
                    {
                        this.class18_0.method_151(this.class18_0.class13_0.long_39, this.class18_0.method_231(num4, Enum6.const_0));
                    }
                }
            }
        }
        else if ((e.KeyData == Keys.Enter) || (e.KeyData == Keys.Escape))
        {
            base.Close();
            this.class18_0.method_153();
            this.class18_0.method_3();
        }
    }

    private void InitializeComponent()
    {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            // 
            // frmQuickAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(74, 19);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmQuickAdjust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuickAdjust";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQuickAdjust_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal Enum12 method_0()
    {
        return this.enum12_0;
    }

    internal void method_1(Enum12 enum12_1)
    {
        this.enum12_0 = enum12_1;
        this.class18_0.method_155(this.method_0().ToString() + " quick adjustment");
        if (enum12_1 == Enum12.const_1)
        {
            this.Text = "Offset";
            if (this.class18_0.class13_0.long_34 != 0L)
            {
                this.textBox1.Text = (((double) this.class18_0.method_152(this.class18_0.class13_0.long_34)) / 8.0).ToString("0.00");
            }
        }
        else
        {
            this.Text = "Overall";
            this.textBox1.Text = this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_0.long_39), Enum6.const_0).ToString("");
        }
    }

    internal void method_2(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;
    }
}

