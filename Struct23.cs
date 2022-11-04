using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct Struct23
{
    public Struct24 struct24_0;
    public Struct24 struct24_1;
    public Struct24 struct24_2;
    public Struct15 struct15_0;
    public bool bool_0;
    public bool bool_1;
    public byte byte_0;
    public float float_0;
    public float float_1;
    static Struct23()
    {
    }

    internal void method_0(Struct24 struct24_3, ref Class10_settings class10_settings_0)
    {
        this.struct15_0.struct24_0 = struct24_3;
        if (struct24_3.int_1 == (class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
        {
            this.struct15_0.struct24_1.int_1 = struct24_3.int_1;
            this.struct15_0.struct24_3.int_1 = struct24_3.int_1;
        }
        else
        {
            this.struct15_0.struct24_3.int_1 = struct24_3.int_1 + 1;
            this.struct15_0.struct24_1.int_1 = struct24_3.int_1 + 1;
        }
        this.struct15_0.struct24_1.int_0 = struct24_3.int_0;
        this.struct15_0.struct24_2.int_0 = struct24_3.int_0 + 1;
        this.struct15_0.struct24_2.int_1 = struct24_3.int_1;
        this.struct15_0.struct24_3.int_0 = struct24_3.int_0 + 1;
    }
}

