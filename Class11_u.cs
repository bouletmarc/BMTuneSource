using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class Class11_u
{
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private Class18 class18_0;
    private Class20_u class20_u_0;
    private int int_0;
    private Stack<Class20_u> class20_u_1;
    private Stack<Class20_u> class20_u_2;
    private string string_0;

    public event Delegate33 delegate33_0;

    public event Delegate32 delegate32_0;

    internal Class11_u(Class18 class18_1)
    {
        this.class18_0 = class18_1;
        this.class20_u_1 = new Stack<Class20_u>();
        this.class20_u_2 = new Stack<Class20_u>();
    }

    internal void method_0(long long_0, byte byte_0, byte byte_1)
    {
        if (!this.bool_1)
        {
            this.int_0++;
        }
        this.class20_u_0 = new Class20_u();
        this.class20_u_0.long_0 = long_0;
        this.class20_u_0.byte_0 = byte_0;
        this.class20_u_0.byte_1 = byte_1;
        if (!this.bool_1)
        {
            this.class20_u_0.string_0 = "Undefined operation. Contact Dev!";
        }
        else
        {
            this.class20_u_0.string_0 = this.string_0;
        }
        this.class20_u_0.int_0 = this.int_0;
        this.class20_u_1.Push(this.class20_u_0);
        this.class20_u_2.Clear();
        if (this.delegate32_0 != null)
        {
            this.delegate32_0();
        }
    }

    public bool method_1()
    {
        return (this.class20_u_1.Count > 0);
    }

    public void method_10(bool bool_3, string string_1, bool bool_4, bool bool_5)
    {
        if (bool_5)
        {
            this.bool_2 = bool_4;
            this.bool_1 = false;
            this.int_0++;
        }
        else if (!this.bool_2 || !this.bool_1)
        {
            if (!bool_3)
            {
                this.bool_2 = bool_4;
                this.bool_1 = false;
                this.int_0++;
            }
            else
            {
                this.bool_2 = bool_4;
                this.bool_1 = bool_3;
                this.string_0 = string_1;
            }
        }
    }

    public void method_11(string string_1)
    {
        this.string_0 = string_1;
    }

    public void method_12()
    {
        this.class20_u_1.Clear();
        this.class20_u_2.Clear();
        if (this.delegate32_0 != null)
        {
            this.delegate32_0();
        }
        GC.Collect(6);
    }

    public List<Class20_u> method_13()
    {
        Class20_u[] class20_u_0 = this.class20_u_1.ToArray();
        List<Class20_u> list = new List<Class20_u>();
        int num = 0;
        int num2 = 0;
        for (int i = 0; i < class20_u_0.Length; i++)
        {
            if (class20_u_0[i] != null)
            {
                if (num != class20_u_0[i].int_0)
                {
                    num = class20_u_0[i].int_0;
                }
                if (((i + 1) < class20_u_0.Length) && (num == class20_u_0[i + 1].int_0))
                {
                    class20_u_0[i] = null;
                }
            }
        }
        for (int j = 0; j < class20_u_0.Length; j++)
        {
            if (class20_u_0[j] != null)
            {
                list.Add(class20_u_0[j]);
                num2++;
                if (num2 > 3)
                {
                    break;
                }
            }
        }
        class20_u_0 = null;
        return list;
    }

    public List<Class20_u> method_14()
    {
        Class20_u[] class20_u_0 = this.class20_u_2.ToArray();
        List<Class20_u> list = new List<Class20_u>();
        int num = 0;
        int num2 = 0;
        for (int i = 0; i < class20_u_0.Length; i++)
        {
            if (class20_u_0[i] != null)
            {
                if (num != class20_u_0[i].int_0)
                {
                    num = class20_u_0[i].int_0;
                }
                if (((i + 1) < class20_u_0.Length) && (num == class20_u_0[i + 1].int_0))
                {
                    class20_u_0[i] = null;
                }
            }
        }
        for (int j = 0; j < class20_u_0.Length; j++)
        {
            if (class20_u_0[j] != null)
            {
                list.Add(class20_u_0[j]);
                num2++;
                if (num2 > 3)
                {
                    break;
                }
            }
        }
        class20_u_0 = null;
        GC.Collect();
        return list;
    }

    public bool method_2()
    {
        return (this.class20_u_2.Count > 0);
    }

    public bool method_3()
    {
        return this.bool_0;
    }

    public void UndoALL()
    {
        while (this.class20_u_1.Count > 0)
        {
            UndoOne();
            Application.DoEvents();
        }
    }

    private void UndoOne()
    {
        try
        {
            this.bool_0 = true;
            this.class20_u_0 = this.class20_u_1.Pop();
            this.class18_0.method_149_SetByte(this.class20_u_0.long_0, this.class20_u_0.byte_0);
            this.class20_u_2.Push(this.class20_u_0);
            while (this.method_6(this.class20_u_0.int_0))
            {
                this.class20_u_0 = this.class20_u_1.Pop();
                this.class18_0.method_149_SetByte(this.class20_u_0.long_0, this.class20_u_0.byte_0);
                this.class20_u_2.Push(this.class20_u_0);
            }
            this.bool_0 = false;
            if ((this.class20_u_0.string_0 == "Fuel & Ign Table Settings")
                || (this.class20_u_0.string_0 == "Import Calibration")
                || (this.class20_u_0.string_0 == "Insert Column")
                || (this.class20_u_0.string_0 == "Delete Column")
                || (this.class20_u_0.string_0.Contains("fuel1_hi"))
                || (this.class20_u_0.string_0.Contains("fuel1_lo"))
                || (this.class20_u_0.string_0.Contains("fuel2_hi"))
                || (this.class20_u_0.string_0.Contains("fuel2_lo"))
                || (this.class20_u_0.string_0.Contains("ign1_hi"))
                || (this.class20_u_0.string_0.Contains("ign1_lo"))
                || (this.class20_u_0.string_0.Contains("ign2_hi"))
                || (this.class20_u_0.string_0.Contains("ign2_lo"))
                || (this.class20_u_0.string_0 == "Map Sensor Setting")
                || (this.class20_u_0.string_0 == "Boost Table Setup")
                )
            {
                this.class18_0.method_52();
            }
            if (this.delegate33_0 != null)
            {
                this.delegate33_0();
            }
            if (this.delegate32_0 != null)
            {
                this.delegate32_0();
            }
        }
        catch { }
    }

    public void method_4()
    {
        UndoOne();
    }

    public void method_5(int int_1)
    {
    }

    public void method_7()
    {
        //Redo
        try
        {
            this.class20_u_0 = this.class20_u_2.Pop();
            this.bool_0 = true;
            this.class18_0.method_149_SetByte(this.class20_u_0.long_0, this.class20_u_0.byte_1);
            this.class20_u_1.Push(this.class20_u_0);
            while (this.method_9(this.class20_u_0.int_0))
            {
                this.class20_u_0 = this.class20_u_2.Pop();
                this.class18_0.method_149_SetByte(this.class20_u_0.long_0, this.class20_u_0.byte_1);
                this.class20_u_1.Push(this.class20_u_0);
            }
            this.bool_0 = false;
            if ((this.class20_u_0.string_0 == "Fuel & Ign Table Settings")
                    || (this.class20_u_0.string_0 == "Import Calibration")
                    || (this.class20_u_0.string_0 == "Insert Column")
                    || (this.class20_u_0.string_0 == "Delete Column")
                    || (this.class20_u_0.string_0.Contains("fuel1_hi"))
                    || (this.class20_u_0.string_0.Contains("fuel1_lo"))
                    || (this.class20_u_0.string_0.Contains("fuel2_hi"))
                    || (this.class20_u_0.string_0.Contains("fuel2_lo"))
                    || (this.class20_u_0.string_0.Contains("ign1_hi"))
                    || (this.class20_u_0.string_0.Contains("ign1_lo"))
                    || (this.class20_u_0.string_0.Contains("ign2_hi"))
                    || (this.class20_u_0.string_0.Contains("ign2_lo"))
                    || (this.class20_u_0.string_0 == "Map Sensor Setting")
                    || (this.class20_u_0.string_0 == "Boost Table Setup")
                    )
            {
                this.class18_0.method_52();
            }
            if (this.delegate33_0 != null)
            {
                this.delegate33_0();
            }
            if (this.delegate32_0 != null)
            {
                this.delegate32_0();
            }
        }
        catch { }
    }

    public void method_8(int int_1)
    {
    }

    public bool method_6(int int_1)
    {
        if (this.class20_u_1.Count <= 0)
        {
            return false;
        }
        return (this.class20_u_1.Peek().int_0 == int_1);
    }

    public bool method_9(int int_1)
    {
        if (this.class20_u_2.Count <= 0)
        {
            return false;
        }
        return (this.class20_u_2.Peek().int_0 == int_1);
    }

    public delegate void Delegate32();

    public delegate void Delegate33();
}

