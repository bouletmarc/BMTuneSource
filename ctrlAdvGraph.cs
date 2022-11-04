using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

internal class ctrlAdvGraph : UserControl
{
    private Brush brush_0;
    private Class10 class10_0;
    private Class16_u class16_0;
    private Class18_file class18_0;
    private Class7_u[,] class7_0;
    private Class7_u class7_1;
    private ctrlAdvTable[] ctrlAdvTable_0;
    public float float_0;
    public float float_1;
    private float float_2;
    private float float_3;
    private float float_4;
    private float float_5;
    private Graphics graphics_0;
    private IContainer icontainer_0;
    private int int_0;
    private int int_1;
    private int int_2 = 20;
    private int int_3 = 20;
    private int int_4;
    private int int_5;
    private string string_0;

    public ctrlAdvGraph()
    {
        this.InitializeComponent();
        this.class16_0 = new Class16_u();
        this.float_1 = 5f;
    }

    private void ctrlAdvGraph_Load(object sender, EventArgs e)
    {
        this.method_9();
    }

    private void ctrlAdvGraph_Resize(object sender, EventArgs e)
    {
        if (this.class7_0 == null)
        {
            this.method_9();
        }
        this.class16_0.method_1(base.CreateGraphics(), base.ClientRectangle.Width, base.ClientRectangle.Height);
        base.Invalidate();
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
        base.SuspendLayout();
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.Name = "ctrlAdvGraph";
        base.Load += new EventHandler(this.ctrlAdvGraph_Load);
        base.Resize += new EventHandler(this.ctrlAdvGraph_Resize);
        base.ResumeLayout(false);
    }

    internal void method_0(ref Class18_file class18_1, ref Class10 class10_1)
    {
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18_file.Delegate58(this.method_9);
        this.class18_0.delegate55_0 += new Class18_file.Delegate55(this.method_9);
        this.class10_0 = class10_1;
        this.ctrlAdvGraph_Load(null, null);
    }

    public ctrlAdvTable[] method_1()
    {
        return this.ctrlAdvTable_0;
    }

    private void method_10()
    {
        float num;
        string str;
         Pen pen = new Pen(this.class18_0.class10_0.color_14, 1f);
        Font font = new Font("Lucida Sans", 9f, FontStyle.Bold);
        Font font2 = new Font("Lucida Sans", 9f, FontStyle.Bold);
        SolidBrush brush = new SolidBrush(this.class18_0.class10_0.color_14);
        SolidBrush brush2 = new SolidBrush(this.class18_0.class10_0.color_11);
        float num2 = 0f;
        StringFormat format = new StringFormat {
            FormatFlags = StringFormatFlags.DirectionVertical
        };
        float num3 = 0f;
        float num4 = 0f;
        if (this.float_0 == 0f)
        {
            this.float_0 = 5f;
        }
        for (float i = 0f; i <= this.float_0; i++)
        {
            num = (this.int_0 + this.int_0) + ((i * this.int_5) / this.float_0);
            str = Math.Round((double) ((((this.float_2 - this.float_3) / this.float_0) * i) + this.float_3), 0).ToString();
            this.graphics_0.DrawString(str, font, brush2, num - (this.graphics_0.MeasureString(str, font).Width / 2f), (float) (base.ClientRectangle.Bottom - (this.int_1 - (font.Height / 8))));
            this.graphics_0.DrawLine(pen, base.ClientRectangle.Left + num, (float) (base.ClientRectangle.Bottom - this.int_1), base.ClientRectangle.Left + num, (float) (base.ClientRectangle.Top + this.int_1));
        }
        num2 = 0f;
        for (float j = 0f; j <= this.float_1; j++)
        {
            num = this.int_1 + ((j * this.int_4) / this.float_1);
            string s = Math.Round((double) ((((this.float_5 - this.float_4) / this.float_1) * j) + this.float_4), 1).ToString();
            if ((Math.Round((double) ((((this.float_5 - this.float_4) / this.float_1) * j) + this.float_4), 0) != 0.0) || ((Math.Round((double) ((((this.float_5 - this.float_4) / this.float_1) * j) + this.float_4), 0) == 0.0) && (this.float_3 != 0f)))
            {
                this.graphics_0.DrawString(s, font2, brush2, (float) (base.ClientRectangle.Left + (this.int_0 * 0.8f)), (float) ((base.ClientRectangle.Bottom - 8) - num));
            }
            this.graphics_0.DrawLine(pen, (float) ((base.ClientRectangle.Left + this.int_0) + this.int_0), base.ClientRectangle.Bottom - num, base.ClientRectangle.Right - this.int_0, base.ClientRectangle.Bottom - num);
            num2 += this.float_1;
        }
        str = this.ctrlAdvTable_0[0].string_1[0];
        this.graphics_0.DrawString(str, font, brush2, (float) ((base.ClientRectangle.Width - this.graphics_0.MeasureString(str, font).Width) / 2f), (float) ((base.ClientRectangle.Bottom - (((float) this.int_1) / 2f)) - (((float) font.Height) / 20f)));
        this.graphics_0.DrawString(this.string_0, font, brush2, base.ClientRectangle.Left + 1f, (base.ClientRectangle.Height - this.graphics_0.MeasureString(this.method_7(), font, 100, format).Height) / 2f, format);
        if (pen != null)
        {
            pen.Dispose();
        }
        pen = new Pen(this.class18_0.class10_0.color_11, 1f) {
            DashStyle = DashStyle.Custom,
            DashPattern = new float[] { 6f, 3f }
        };
        if (this.float_4 < 0f)
        {
            num4 = (this.int_4 - (this.int_4 * ((0f - this.float_4) / (this.float_5 - this.float_4)))) + this.int_1;
            this.graphics_0.DrawLine(pen, (float) ((base.ClientRectangle.Left + this.int_0) + this.int_0), num4, base.ClientRectangle.Right - this.int_0, num4);
        }
        if (this.float_3 < 0f)
        {
            num3 = (this.int_0 * 2) + (((0f - this.float_3) / (this.float_2 - this.float_3)) * this.int_5);
            this.graphics_0.DrawLine(pen, num3, (float) (base.ClientRectangle.Bottom - this.int_1), num3, (float) (base.ClientRectangle.Top + this.int_1));
        }
        if ((this.float_4 < 0f) && ((this.float_3 > 0f) || (this.float_3 < 0f)))
        {
            this.graphics_0.DrawString(0.ToString("N0"), font2, brush2, (float) (num3 - 2f), (float) (num4 - 2f));
        }
        pen.Dispose();
        font.Dispose();
        brush.Dispose();
        brush2.Dispose();
        format.Dispose();
        format = null;
        pen = null;
        font = null;
        brush = null;
        brush2 = null;
    }

    private void method_11()
    {
        SolidBrush brush = new SolidBrush(Color.Red);
        Pen pen = new Pen(Color.Red, 2f);
        Pen pen2 = new Pen(Color.Blue, 1f);
        Pen pen3 = new Pen(this.class18_0.class10_0.color_Trace, 1f);
        Pen pen4 = new Pen(this.class18_0.class10_0.color_11);
        SolidBrush brush2 = new SolidBrush(this.class18_0.class10_0.color_Trace);
        Font font = new Font("Lucida Sans", 6.5f, FontStyle.Bold);
        SolidBrush brush3 = new SolidBrush(this.class18_0.class10_0.color_11);
        Class7_u class2 = null;
        Class7_u class3 = null;
        int green = 0;
        int col = 0;
        int num3 = 0;
        float num4 = 0f;
        ctrlAdvTable table = null;
        for (int i = 0; i < this.ctrlAdvTable_0.Length; i++)
        {
            num3 += this.ctrlAdvTable_0[i].method_5() - 1;
        }
        for (int j = 0; j < this.ctrlAdvTable_0.Length; j++)
        {
            table = this.ctrlAdvTable_0[j];
            for (int k = 1; k < table.method_5(); k++)
            {
                class2 = null;
                class3 = null;
                green = (0xff - ((((0xff * k) * (j + 1)) / num3) + 1)) % 0xff;
                if (green < 0)
                {
                    green *= -1;
                }
                for (col = 0; col < table.method_3(); col++)
                {
                    pen.Color = Color.FromArgb(0xff, green, 0);
                    brush.Color = Color.FromArgb(0xff, green, 0);
                    num4 = (float) table.method_14((byte) col, (byte) k);
                    if (num4 > this.float_5)
                    {
                        num4 = this.float_5;
                    }
                    float yChart = (this.int_4 - (this.int_4 * ((num4 - this.float_4) / (this.float_5 - this.float_4)))) + this.int_1;
                    float xChart = (2 * this.int_0) + (((((float) table.method_14((byte) col, 0)) - this.float_3) / (this.float_2 - this.float_3)) * this.int_5);
                    if ((this.float_5 - this.float_4) != 0f)
                    {
                        if (this.class7_0[col, k] == null)
                        {
                            this.class7_0[col, k] = new Class7_u(xChart, yChart, (float) table.method_14((byte) col, 0), (float) table.method_14((byte) col, (byte) k), col, k);
                            this.class7_0[col, k].bool_1 = table.method_15(col, k);
                        }
                        else
                        {
                            this.class7_0[col, k].method_9(xChart);
                            this.class7_0[col, k].method_11(yChart);
                            this.class7_0[col, k].method_7((float) table.method_14((byte) col, (byte) k));
                            this.class7_0[col, k].bool_0 = table.method_15(col, k);
                        }
                        class3 = this.class7_0[col, k];
                        this.graphics_0.FillRectangle(brush, (float) (class3.method_8() - 2f), (float) (class3.method_10() - 2f), (float) 5f, (float) 5f);
                        if (class2 != null)
                        {
                            this.graphics_0.DrawLine(pen, class2.method_8(), class2.method_10(), class3.method_8(), class3.method_10());
                        }
                        if (this.class7_0[col, k].bool_0)
                        {
                            this.graphics_0.DrawRectangle(pen4, (float) (this.class7_0[col, k].method_8() - 4f), (float) (this.class7_0[col, k].method_10() - 3.5f), (float) 8f, (float) 8f);
                        }
                    }
                    class2 = class3;
                }
            }
        }
        pen.Dispose();
        pen = null;
        pen4.Dispose();
        pen4 = null;
        pen3.Dispose();
        pen3 = null;
        pen2.Dispose();
        pen2 = null;
        font.Dispose();
        font = null;
        brush3.Dispose();
        brush3 = null;
        brush.Dispose();
        brush = null;
        brush2.Dispose();
        brush2 = null;
    }

    public void method_2(ctrlAdvTable[] ctrlAdvTable_1)
    {
        this.ctrlAdvTable_0 = ctrlAdvTable_1;
        if (this.ctrlAdvTable_0 != null)
        {
            this.float_0 = this.ctrlAdvTable_0[0].method_3() - 1;
        }
    }

    public float method_3()
    {
        return this.float_4;
    }

    public void method_4(float float_6)
    {
        this.float_4 = float_6;
    }

    public float method_5()
    {
        return this.float_5;
    }

    public void method_6(float float_6)
    {
        this.float_5 = float_6;
    }

    public string method_7()
    {
        return this.string_0;
    }

    public void method_8(string string_1)
    {
        this.string_0 = string_1;
    }

    private void method_9()
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.method_30_HasFileLoadedInBMTune())
            {
                int num = 0;
                for (int i = 0; i < this.ctrlAdvTable_0.Length; i++)
                {
                    num = this.ctrlAdvTable_0[i].method_5();
                }
                this.class7_0 = new Class7_u[this.ctrlAdvTable_0[0].method_3(), num];
            }
            this.Refresh();
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        this.int_0 = 30;
        this.int_1 = 0x19;
        this.int_5 = base.ClientRectangle.Width - (3 * this.int_0);
        this.int_4 = base.ClientRectangle.Height - (2 * this.int_1);
        this.brush_0 = new SolidBrush(this.class10_0.color_3);
        if (this.class18_0 == null)
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.FillRectangle(this.brush_0, pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            //this.graphics_0.FillRectangle(new SolidBrush(SystemColors.Control), pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
        }
        else if (!this.class18_0.method_30_HasFileLoadedInBMTune() || !this.class16_0.method_0())
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.SmoothingMode = SmoothingMode.None;
            this.graphics_0.FillRectangle(this.brush_0, pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
        }
        else if (this.class16_0.method_0())
        {
            this.graphics_0 = this.class16_0.method_3();
            this.graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics_0.FillRectangle(this.brush_0, pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            this.int_2 = 20;
            this.int_3 = 20;
            this.float_2 = (float) this.ctrlAdvTable_0[0].method_7();
            this.float_3 = (float) this.ctrlAdvTable_0[0].method_8();
            this.method_10();
            this.method_11();
            this.class16_0.method_2(pe.Graphics);
        }
    }

    protected override void OnPaintBackground(PaintEventArgs pe)
    {
    }
}

