using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct Struct17
{
    public Struct24 struct24_0;
    public Struct24 struct24_1;
    public Struct15 struct15_0;
    public float float_0;
    public float float_1;
    public long long_0;
    public bool bool_0;
    public bool bool_1;
    public bool bool_2;
    public bool bool_3;
    public byte byte_0;
    public long long_1;
    public byte byte_1;
    public byte byte_2;
    public byte byte_3;
    public byte byte_4;
    public byte byte_5;
    static Struct17()
    {
    }

    public bool method_0(Struct24 struct24_1)
    {
        return ((struct24_1.int_1 == this.struct24_1.int_1) && (struct24_1.int_0 == this.struct24_1.int_0));
    }

    internal void method_1(Struct24 struct24_1, ref Class18 class18_0)
    {
        this.struct15_0.struct24_0 = struct24_1;
        if (struct24_1.int_1 >= (class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
        {
            this.struct15_0.struct24_1.int_1 = struct24_1.int_1;
            this.struct15_0.struct24_3.int_1 = struct24_1.int_1;
        }
        else
        {
            this.struct15_0.struct24_3.int_1 = struct24_1.int_1 + 1;
            this.struct15_0.struct24_1.int_1 = struct24_1.int_1 + 1;
        }
        if (struct24_1.int_0 >= (class18_0.method_32_GetRPM_RowsNumber() - 1))
        {
            this.struct15_0.struct24_1.int_0 = struct24_1.int_0;
            this.struct15_0.struct24_2.int_0 = struct24_1.int_0;
            this.struct15_0.struct24_2.int_1 = struct24_1.int_1;
            this.struct15_0.struct24_3.int_0 = struct24_1.int_0;
        }
        else
        {
            this.struct15_0.struct24_1.int_0 = struct24_1.int_0;
            this.struct15_0.struct24_2.int_0 = struct24_1.int_0 + 1;
            this.struct15_0.struct24_2.int_1 = struct24_1.int_1;
            this.struct15_0.struct24_3.int_0 = struct24_1.int_0 + 1;
        }
    }

    public override bool Equals(object obj)
    {
        return ((obj is Struct17) && (this == ((Struct17) obj)));
    }

    public override int GetHashCode()
    {
        return (int) Math.Sqrt((double) ((((((((this.struct24_0.int_1 * this.struct24_0.int_1) + (this.struct24_0.int_0 * this.struct24_0.int_0)) + (this.byte_0 * this.byte_0)) + (this.long_1 * this.long_1)) + (this.byte_3 * this.byte_3)) + (this.byte_4 * this.byte_4)) + (this.byte_5 * this.byte_5)) + (this.byte_2 * this.byte_2)));
    }

    public static bool operator ==(Struct17 struct17_0, Struct17 struct17_1)
    {
        return ((((struct17_0.struct24_0.int_1 == struct17_1.struct24_0.int_1) && (struct17_0.struct24_0.int_0 == struct17_1.struct24_0.int_0)) && (struct17_0.bool_1 == struct17_1.bool_1)) && (struct17_0.bool_0 == struct17_1.bool_0));
    }

    public static bool operator !=(Struct17 struct17_0, Struct17 struct17_1)
    {
        if (((struct17_0.struct24_0.int_1 == struct17_1.struct24_0.int_1) && (struct17_0.struct24_0.int_0 == struct17_1.struct24_0.int_0)) && (struct17_0.bool_1 == struct17_1.bool_1))
        {
            return (struct17_0.bool_0 != struct17_1.bool_0);
        }
        return true;
    }
}

