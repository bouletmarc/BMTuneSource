using System;
using System.Drawing;

internal class Class16_u
{
    private Bitmap bitmap_0;
    private Graphics graphics_0;
    private int int_0 = 0;
    private int int_1 = 0;

    public bool method_0()
    {
        return (this.graphics_0 != null);
    }

    public bool method_1(Graphics graphics_1, int int_2, int int_3)
    {
        if (this.bitmap_0 != null)
        {
            this.bitmap_0.Dispose();
            this.bitmap_0 = null;
        }
        if (this.graphics_0 != null)
        {
            this.graphics_0.Dispose();
            this.graphics_0 = null;
        }
        if ((int_2 == 0) || (int_3 == 0))
        {
            return false;
        }
        this.int_1 = int_2;
        this.int_0 = int_3;
        this.bitmap_0 = new Bitmap(int_2, int_3);
        this.graphics_0 = Graphics.FromImage(this.bitmap_0);
        return true;
    }

    public void method_2(Graphics graphics_1)
    {
        if (this.bitmap_0 != null)
        {
            graphics_1.DrawImage(this.bitmap_0, new Rectangle(0, 0, this.int_1, this.int_0), 0, 0, this.int_1, this.int_0, GraphicsUnit.Pixel);
        }
    }

    public Graphics method_3()
    {
        return this.graphics_0;
    }
}

