using Data;
using MTSSDKLib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text;

internal class Class2_serialWB
{
    private BackgroundWorker backgroundWorker_0;
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private byte[] byte_0;
    private Class18 class18_0;
    private FrmMain frmMain_0;
    private double double_0;
    public static double[] double_1 = new double[] { 
        2.33, 2.26, 2.2, 2.13, 2.07, 2.01, 1.95, 1.9, 1.85, 1.8, 1.75, 1.7, 1.66, 1.62, 1.58, 1.54, 
        1.5, 1.47, 1.44, 1.4, 1.37, 1.34, 1.31, 1.29, 1.26, 1.24, 1.21, 1.19, 1.17, 1.15, 1.12, 1.1, 
        1.08, 1.06, 1.05, 1.03, 1.0, 1.0, 0.99, 0.98, 0.97, 0.96, 0.95, 0.94, 0.93, 0.92, 0.92, 0.91, 
        0.9, 0.89, 0.89, 0.88, 0.87, 0.86, 0.86, 0.85, 0.84, 0.84, 0.83, 0.83, 0.82, 0.81, 0.81, 0.8, 
        0.8, 0.79, 0.79, 0.78, 0.78, 0.77, 0.77, 0.76, 0.75, 0.75, 0.74, 0.74, 0.73, 0.73, 0.72, 0.72, 
        0.71, 0.71, 0.7, 0.7, 0.69
     };
    private int int_2;
    private MTS mts_0;
    private SerialPort serialPort_0;
    public string[] string_0;
    private bool Loading = true;

    internal Class2_serialWB(ref Class18 rm, ref FrmMain rm2)
    {
        this.class18_0 = rm;
        this.frmMain_0 = rm2;
        this.backgroundWorker_0 = new BackgroundWorker();
        this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
        this.backgroundWorker_0.WorkerSupportsCancellation = true;
        //this.LogThis("Background worker created");
        this.method_16();
        //this.LogThis("innovate Init + GetPorts");
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.TechEdge)
        {
            //this.LogThis("TE 2.0 frame set to port");
            this.serialPort_0.NewLine = "" + Environment.NewLine + "";
            this.serialPort_0.WriteLine("s03e1");
            this.serialPort_0.DiscardInBuffer();
        }
        StringBuilder builder = new StringBuilder();
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        bool flag = false;
        byte[] buffer = new byte[] { 0 };
    Label_006A:
        if (!this.backgroundWorker_0.CancellationPending)
        {
            try
            {
                string str = string.Empty;
                if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.FJO)
                {
                    double num4 = 0.0;
                    while (num2 <= 10)
                    {
                        //this.LogThis("byte to read: " + this.serialPort_0.BytesToRead.ToString());
                        num = this.serialPort_0.ReadByte();
                        str = str + Convert.ToChar(num);
                        if (num == 10)
                        {
                            //this.LogThis("detected 0x0a");
                            break;
                        }
                        num2++;
                    }
                    //this.LogThis("Received FJO line: " + str.ToString());
                    if (builder.ToString().Contains("H-1"))
                    {
                        this.double_0 = 0.0;
                    }
                    else if (builder.ToString().Contains("."))
                    {
                        num4 = double.Parse(builder.ToString()) / 14.7;
                        this.double_0 = num4;
                    }
                    else if (builder.ToString().Contains("Err"))
                    {
                        this.bool_0 = false;
                        this.serialPort_0.Close();
                        this.serialPort_0.Dispose();
                        this.serialPort_0 = null;
                        this.LogThis("error detected: " + builder.ToString());
                        goto Label_09D1;
                        //throw new Exception("error detected: " + builder.ToString());
                    }
                    goto Label_006A;
                }
                if (this.class18_0.class10_settings_0.wideband_Serial_0 != Wideband_Serial.TechEdge)
                {
                    goto Label_03B7;
                }
                bool flag2 = false;
                goto Label_02D4;
            Label_01E9:
                //this.LogThis("byte to read: " + this.serialPort_0.BytesToRead.ToString());
                while (this.serialPort_0.BytesToRead < 0x1c)
                {
                }
                byte num6 = (byte) this.serialPort_0.ReadByte();
                byte num7 = 0;
                //this.LogThis("b1: " + num6.ToString("X2"));
                if (num6 != 90)
                {
                    goto Label_01E9;
                }
                num7 = (byte) this.serialPort_0.ReadByte();
                if (num6 != 90)
                {
                    goto Label_01E9;
                }
                //this.LogThis("b2: " + num7.ToString("X2"));
                //this.LogThis("Te_frame_detected");
                flag2 = true;
                this.byte_0[0] = num6;
                this.byte_0[1] = num7;
                for (int i = 0; i < 0x1a; i++)
                {
                    this.byte_0[2 + i] = (byte) this.serialPort_0.ReadByte();
                }
                //this.LogThis("read remaining 26 bytes");
            Label_02D4:
                if (!flag2)
                {
                    goto Label_01E9;
                }
                //this.LogThis("Reading/calc frame");
                int num9 = this.class18_0.method_146(this.byte_0[6], this.byte_0[5]);
                //this.LogThis("b8/9: " + num9.ToString());
                byte num10 = 0;
                byte num11 = 0;
                num10 = this.byte_0[0x19];
                num11 = this.byte_0[0x1a];
                //this.LogThis("Status 1: " + num10.ToString() + " Status 2: " + num11.ToString());
                if ((num11 == 0) && (num10 == 3))
                {
                    this.serialPort_0.DiscardInBuffer();
                    double num12 = (((double) num9) / 8192.0) + 0.5;
                    //this.LogThis("Lambda temp: " + num12.ToString());
                    this.double_0 = num12;
                }
                else
                {
                    this.LogThis("Status byte 27 not 0");
                }
                goto Label_006A;
            Label_03B7:
                if (this.class18_0.class10_settings_0.wideband_Serial_0 != Wideband_Serial.Zeitronix)
                {
                    goto Label_0560;
                }
                bool flag3 = false;
                goto Label_04F0;
            Label_03D5:
                //this.LogThis("byte to read: " + this.serialPort_0.BytesToRead.ToString());
                byte num13 = (byte) this.serialPort_0.ReadByte();
                byte num14 = 0;
                byte num15 = 0;
                //this.LogThis("b1: " + num13.ToString("X2"));
                if (num13 != 0)
                {
                    goto Label_03D5;
                }
                num14 = (byte) this.serialPort_0.ReadByte();
                //this.LogThis("b2: " + num14.ToString("X2"));
                if (num14 != 1)
                {
                    goto Label_03D5;
                }
                num15 = (byte) this.serialPort_0.ReadByte();
                //this.LogThis("b3: " + num15.ToString("X2"));
                if (num15 != 2)
                {
                    goto Label_03D5;
                }
                //this.LogThis("ZE_frame_detected");
                flag3 = true;
                this.byte_0[0] = num13;
                this.byte_0[1] = num14;
                this.byte_0[2] = num15;
                for (int j = 0; j < 11; j++)
                {
                    this.byte_0[3 + j] = (byte) this.serialPort_0.ReadByte();
                }
                //this.LogThis("read remaning 11 bytes");
            Label_04F0:
                if (!flag3)
                {
                    goto Label_03D5;
                }
                //this.LogThis("Reading/calc frame");
                double num17 = ((double) this.byte_0[3]) / 10.0;
                //this.LogThis("Afr temp: " + num17.ToString());
                double num18 = num17 / 14.7;
                //this.LogThis("Lambda temp: " + num18.ToString());
                this.double_0 = num18;
                goto Label_006A;
            Label_0560:
                if (this.class18_0.class10_settings_0.wideband_Serial_0 != Wideband_Serial.Plx)
                {
                    goto Label_07F4;
                }
                bool flag4 = false;
                goto Label_05E0;
            Label_057B:
                //this.LogThis("byte to read: " + this.serialPort_0.BytesToRead.ToString());
                byte num19 = (byte) this.serialPort_0.ReadByte();
                //this.LogThis("b1: " + num19.ToString("X2"));
                if (num19 != 0xff)
                {
                    goto Label_057B;
                }
                //this.LogThis("Plx_frame_detected last 0xff, read frame");
                flag4 = true;
            Label_05E0:
                if (!flag4)
                {
                    goto Label_057B;
                }
            Label_05E4:
                if (this.backgroundWorker_0.CancellationPending)
                {
                    goto Label_09D1;
                }
                while (this.serialPort_0.BytesToRead < 9)
                {
                }
                //this.LogThis("read remaning 9 bytes");
                for (int k = 0; k < 9; k++)
                {
                    this.byte_0[k] = (byte) this.serialPort_0.ReadByte();
                }
                if (this.byte_0[8] == 0xff)
                {
                    //this.LogThis("frame: " + this.byte_0[0].ToString("X2") + " " + this.byte_0[1].ToString("X2") + " " + this.byte_0[2].ToString("X2") + " " + this.byte_0[3].ToString("X2") + " " + this.byte_0[4].ToString("X2") + " " + this.byte_0[5].ToString("X2") + " " + this.byte_0[6].ToString("X2") + " " + this.byte_0[7].ToString("X2") + " " + this.byte_0[8].ToString("X2") + " ");
                    double num21 = (this.byte_0[7] * 0.0026667) + 0.68;
                    //this.LogThis("Lambda temp: " + num21.ToString());
                    this.double_0 = num21;
                    goto Label_05E4;
                }
                goto Label_006A;
            Label_07F4:
                if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.Aem)
                {
                    double num22 = 0.0;
                    str = this.serialPort_0.ReadLine();
                    //this.LogThis("Received AE< line: " + str.ToString());
                    if (str.ToString().Contains("."))
                    {
                        double num23 = double.Parse(str.ToString());
                        if (num23 > 2.0)
                        {
                            num22 = num23 / 14.7;
                        }
                        this.double_0 = num22;
                    }
                    goto Label_006A;
                }
                if (this.class18_0.class10_settings_0.wideband_Serial_0 != Wideband_Serial.JAW)
                {
                    goto Label_09D1;
                }
            Label_089A:
                if (!flag)
                {
                    //this.LogThis("Sending request 0x00");
                    this.serialPort_0.Write(buffer, 0, 1);
                }
                //this.LogThis("byte to read: " + this.serialPort_0.BytesToRead.ToString());
                if (this.serialPort_0.BytesToRead < 6)
                {
                    flag = true;
                    goto Label_089A;
                }
                flag = false;
                for (int m = 0; m < 6; m++)
                {
                    this.byte_0[m] = (byte) this.serialPort_0.ReadByte();
                }
                //this.LogThis("read remaning 6 bytes");
                //this.LogThis("Reading/calc frame");
                double num25 = this.byte_0[1];
                //this.LogThis("Jaw wb temp: " + num25.ToString());
                if (num25 < 15.0)
                {
                    this.LogThis("Jaw temp smaller then 16");
                }
                else
                {
                    double num26 = double_1[this.byte_0[0]];
                    //this.LogThis("Lambda temp: " + num26.ToString());
                    this.double_0 = num26;
                }
                goto Label_006A;
            }
            catch (Exception exception)
            {
                if (this.serialPort_0.IsOpen)
                {
                    num3++;
                    this.LogThis("" + exception.Message);
                    if (num3 >= 9)
                    {
                        goto Label_09D1;
                        //throw exception;
                    }
                    goto Label_006A;
                }
            }
        }
    Label_09D1:
        builder = null;
        num2 = 0;
        num = 0;
    }

    public void method_0()
    {
        //if (!Loading) this.LogThis("Selected: " + this.class18_0.class10_settings_0.wideband_Serial_0.ToString());

        /*if (this.class18_0.class10_0.wideband_Serial_0 == Wideband_Serial.const_0)
        {
            this.method_15();
            if (!Loading) this.LogThis("Innovate ports created");
        }
        else
        {*/
            this.string_0 = new string[20];
            for (int i = 0; i <= 0x13; i++) this.string_0[i] = "COM" + ((i + 1)).ToString();
            //if (!Loading) this.LogThis("comm ports 20 created");
        //}
        if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.TechEdge)
        {
            this.byte_0 = new byte[this.method_14()];
            //if (!Loading) this.LogThis("Serial frame (" + this.class18_0.class10_settings_0.wideband_Serial_0.ToString() + ") with size:" + this.method_14().ToString() + " created");
        }
        else if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.Zeitronix)
        {
            this.byte_0 = new byte[this.method_14()];
            //if (!Loading) this.LogThis("Serial frame (" + this.class18_0.class10_settings_0.wideband_Serial_0.ToString() + ") with size:" + this.method_14().ToString() + " created");
        }
        if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.Plx)
        {
            this.byte_0 = new byte[this.method_14()];
            //if (!Loading) this.LogThis("Serial frame (" + this.class18_0.class10_settings_0.wideband_Serial_0.ToString() + ") with size:" + this.method_14().ToString() + " created");
        }

        Loading = false;
    }

    public double method_1()
    {
        if (!this.method_4())
        {
            return 0.0;
        }
        if ((this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.const_0) && this.bool_2)
        {
            this.LogThis("Innovate Connection Error detected");
            return 0.0;
            //throw new Exception("Innovate Connection Error detected");
        }
        return this.double_0;
    }

    private Parity method_10()
    {
        switch (this.class18_0.class10_settings_0.wideband_Serial_0)
        {
            case Wideband_Serial.const_0:
                break;
                //throw new Exception("parity selection failed");

            case Wideband_Serial.FJO:
                return Parity.None;

            case Wideband_Serial.TechEdge:
                return Parity.None;

            case Wideband_Serial.Zeitronix:
                return Parity.None;

            case Wideband_Serial.Aem:
                return Parity.None;

            case Wideband_Serial.Plx:
                return Parity.Even;
        }

        this.LogThis("parity selection failed");
        return Parity.None;
        //throw new Exception("parity selection failed");
    }

    private StopBits method_11()
    {
        switch (this.class18_0.class10_settings_0.wideband_Serial_0)
        {
            case Wideband_Serial.const_0:
                break;
                //throw new Exception("stop bit selection failed");

            case Wideband_Serial.FJO:
                return StopBits.One;

            case Wideband_Serial.TechEdge:
                return StopBits.One;

            case Wideband_Serial.Zeitronix:
                return StopBits.One;

            case Wideband_Serial.Aem:
                return StopBits.One;

            case Wideband_Serial.Plx:
                return StopBits.One;

            case Wideband_Serial.JAW:
                return StopBits.One;
        }

        this.LogThis("stop bit selection failed");
        return StopBits.One;
        //throw new Exception("stop bit selection failed");
    }

    private int method_12()
    {
        switch (this.class18_0.class10_settings_0.wideband_Serial_0)
        {
            case Wideband_Serial.const_0:
                break;
                //throw new Exception("data bit selection failed");

            case Wideband_Serial.FJO:
                return 8;

            case Wideband_Serial.TechEdge:
                return 8;

            case Wideband_Serial.Zeitronix:
                return 8;

            case Wideband_Serial.Aem:
                return 8;

            case Wideband_Serial.Plx:
                return 8;

            case Wideband_Serial.JAW:
                return 8;
        }

        this.LogThis("data bit selection failed");
        return 8;
        //throw new Exception("data bit selection failed");
    }

    private string method_13()
    {
        return this.string_0[this.method_7()].ToString();
    }

    private int method_14()
    {
        switch (this.class18_0.class10_settings_0.wideband_Serial_0)
        {
            case Wideband_Serial.const_0:
                break;
                //throw new Exception("frame seize selection failed");

            case Wideband_Serial.FJO:
                break;
                //throw new Exception("frame seize selection failed");

            case Wideband_Serial.TechEdge:
                return 0x1c;

            case Wideband_Serial.Zeitronix:
                return 14;

            case Wideband_Serial.Plx:
                return 9;

            case Wideband_Serial.JAW:
                return 6;
        }

        this.LogThis("frame size selection failed");
        return 9;
        //throw new Exception("frame seize selection failed");
    }

    //#################################################################################
    public void method_15()
    {
        int portCount = this.mts_0.PortCount;
        this.string_0 = new string[portCount];
        if (portCount != 0)
        {
            for (int i = 0; i < portCount; i++)
            {
                this.mts_0.CurrentPort = i;
                this.string_0[i] = this.mts_0.PortName;
            }
        }
    }

    private void method_16()
    {
        try
        {
            this.mts_0 = new MTS();
            this.mts_0.ConnectionError += new _IMTSEvents_ConnectionErrorEventHandler(this.method_19);
            this.mts_0.ConnectionEvent += new _IMTSEvents_ConnectionEventEventHandler(this.method_18);
            this.mts_0.NewData += new _IMTSEvents_NewDataEventHandler(this.method_17);
        }
        catch
        {
        }
    }

    private void method_17()
    {
        Enum0 inputFunction;
        //this.LogThis("innovate new data()");
        double inputSample = 0.0;
        this.bool_2 = false;
        if (this.mts_0.InputCount > 0)
        {
            this.int_2++;
            inputSample = this.mts_0.InputSample;
            inputFunction = (Enum0)this.mts_0.InputFunction;
            if (this.mts_0.InputType == 1)
            {
                if (inputFunction == Enum0.const_0)
                {
                    inputSample = (inputSample * 0.001) + 0.5;
                }
                else
                {
                    if (inputFunction != Enum0.const_1)
                    {
                        goto Label_00DB;
                    }
                    inputSample *= 0.1;
                }
            }
            else
            {
                if (this.mts_0.InputType != 0)
                {
                    goto Label_00DB;
                }
                if (inputFunction == Enum0.const_0)
                {
                    inputSample = (inputSample * 0.001) + 0.5;
                }
                else
                {
                    if (inputFunction != Enum0.const_1)
                    {
                        goto Label_00DB;
                    }
                    inputSample *= 0.1;
                }
            }
            this.double_0 = inputSample;
            this.int_2 = 0;
        }
        return;
        Label_00DB:
        this.int_2 = 0;
        switch (inputFunction)
        {
            case Enum0.const_2:
            case Enum0.const_3:
                break;

            case Enum0.const_4:
                this.double_0 = 0.0;
                return;

            case Enum0.const_5:
                this.double_0 = 0.0;
                return;

            case Enum0.const_6:
                this.double_0 = 0.0;
                return;

            case Enum0.const_7:
                this.double_0 = 0.0;
                return;

            case Enum0.const_8:
                this.double_0 = 0.0;
                return;

            case Enum0.const_9:
                this.double_0 = 0.0;
                return;

            case Enum0.const_10:
                this.double_0 = 0.0;
                break;

            default:
                return;
        }
    }

    private void method_18(int int_3)
    {
        if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.const_0)
        {
            //this.LogThis("innovate event : " + int_3.ToString());
            switch (int_3)
            {
                case -1:
                    this.bool_1 = false;
                    this.bool_0 = this.bool_1;
                    this.bool_2 = true;
                    this.LogThis("Innovate wideband not detected");
                    return;
                    //throw new Exception("Innovate wideband not detected");

                case 0:
                    this.bool_1 = true;
                    this.bool_0 = this.bool_1;
                    this.bool_2 = false;
                    return;
            }
            this.bool_1 = false;
            this.bool_0 = this.bool_1;
            this.bool_2 = true;
            this.LogThis("Innovate error: " + int_3.ToString());
            //throw new Exception("Innovate error: " + int_3.ToString());
        }
    }

    private void method_19()
    {
        if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.const_0)
        {
            this.LogThis("innovate connection error");
            this.bool_2 = true;
            this.mts_0.Disconnect();
        }
    }
    //############################################################################

    public bool method_2()
    {
        this.LogThis("Connecting: " + this.class18_0.class10_settings_0.wideband_Serial_0.ToString());

        //###########################################
        if (this.class18_0.class10_settings_0.wideband_Serial_0 == Wideband_Serial.const_0)
        {
            this.mts_0.CurrentPort = this.method_7();
            this.mts_0.Connect();
            if (!this.bool_1)
            {
                this.LogThis("Innovate wideband not detected");
                return this.bool_1;
                //throw new Exception("Innovate wideband not detected");
            }
            //this.LogThis("Innovate SDK startdata");
            this.mts_0.StartData();
            this.LogThis("Innovate SDK connected");
            return this.bool_1;
        }
        //###########################################
        try
        {
            this.serialPort_0 = new SerialPort(this.method_13(), this.method_9(), this.method_10(), this.method_12(), this.method_11());
            this.serialPort_0.Open();
            this.serialPort_0.ReadTimeout = 200;
            //this.LogThis("Serial port created " + this.method_13().ToString() + " " + this.method_9().ToString() + " " + this.method_10().ToString() + " " + this.method_12().ToString() + " " + this.method_11().ToString());
        }
        catch (Exception exception)
        {
            this.serialPort_0.Close();
            this.LogThis(exception.Message);
            this.bool_1 = false;
            return this.bool_1;
            //throw exception;
        }
        this.bool_0 = this.serialPort_0.IsOpen;
        if (!this.bool_0)
        {
            this.LogThis("Unable to open comm port");
            return this.bool_0;
            //throw new Exception("Unable to open comm port");
        }
        this.backgroundWorker_0.RunWorkerAsync();
        //this.LogThis("Running background worker for Wideband");
        return this.bool_0;
    }

    public void method_3()
    {
        this.mts_0.Disconnect();
    }

    public bool method_4()
    {
        return this.bool_0;
    }

    private void LogThis(string string_1)
    {
        this.frmMain_0.LogThis("Wideband - " + string_1);
    }

    private int method_7()
    {
        return this.class18_0.class10_settings_0.int_10;
    }

    private int method_9()
    {
        switch (this.class18_0.class10_settings_0.wideband_Serial_0)
        {
            case Wideband_Serial.const_0:
                break;
                //throw new Exception("Baud selection failed");

            case Wideband_Serial.FJO:
                return 0x4b00;

            case Wideband_Serial.TechEdge:
                return 0x4b00;

            case Wideband_Serial.Zeitronix:
                return 0x2580;

            case Wideband_Serial.Aem:
                return 0x2580;

            case Wideband_Serial.Plx:
                return 0x960;

            case Wideband_Serial.JAW:
                return 0x3840;
        }

        this.LogThis("Baud selection failed");
        return 0x960;
        //throw new Exception("Baud selection failed");
    }

    public enum Enum0
    {
        const_0,
        const_1,
        const_2,
        const_3,
        const_4,
        const_5,
        const_6,
        const_7,
        const_8,
        const_9,
        const_10
    }
}

