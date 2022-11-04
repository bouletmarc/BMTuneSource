using Data;
//using PropertiesRes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Timers;
using System.Threading;
using System.Windows.Forms;

internal class Class25
{
    private BackgroundWorker backgroundWorker_0;
    private BackgroundWorker backgroundWorker_1;
    private BackgroundWorker backgroundWorker_2;
    private BackgroundWorker backgroundWorker_3;
    private BackgroundWorker backgroundWorker_4;
    private bool Emu_Connected;
    private bool bool_1;
    private bool bool_10;
    private bool bool_2;
    private bool bool_3;
    private bool bool_6;
    private bool Emu_SerialConnected;
    public bool Report_Error;
    private bool bool_9;
    private byte[] byte_0;
    private byte[] byte_1;
    private byte[] byte_2;
    private byte byte_3;
    public byte[] Serial_ID = new byte[8];
    private byte[] byte_6 = new byte[] { 15, 0xfc, 0xce, 0x2c, 0xa3, 0x9f, 0x65, 0x99 };
    private byte[] byte_7 = new byte[] { 15, 0xfc, 0xce, 0x2c, 0xa3, 0x9f, 0x65, 0x99 };
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private Class25 class25_0;
    private Class27_EmuProgress class27_EmuProgress_0;
    public EmulatorMoatesType emulatorMoatesType_0 = EmulatorMoatesType.demon;
    private EmulatorState emulatorState_0;
    private FrmMain frmMain_0;
    private int int_0;
    public int int_1;
    public int int_2;
    public int Vendor_ID;
    private Queue<Struct16> queue_0;
    private SerialPort serialPort_0;
    public string string_0 = "";
    public string EmulatorName = "";
    private System.Timers.Timer timer_0 = new System.Timers.Timer(5.0);
    private System.Timers.Timer timer_1 = new System.Timers.Timer(100.0);
    private System.Windows.Forms.Timer timer_2;

    public event Delegate65 delegate65_0;
    public event Delegate66 delegate66_0;
    public bool CaliEmuProgressReport = true;
    public bool TryingtoConnect = false;

    internal Class25(ref Class18 rm, ref Class10_settings cfg, ref Class17 dt, ref FrmMain frmM)        //Class22 in HTS 1.92
    {
        this.class10_settings_0 = cfg;
        this.class17_0 = dt;
        this.class18_0 = rm;
        this.frmMain_0 = frmM;
        this.timer_0.Elapsed += new ElapsedEventHandler(this.timer_0_Elapsed);
        this.timer_1.Elapsed += new ElapsedEventHandler(this.timer_1_Elapsed);
        SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(this.method_0);
        this.class25_0 = this;
        this.method_14(EmulatorState.Disconnected);
    }

    //Upload Rom

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
        {
            string str3 = string.Empty;
            byte[] buffer = new byte[8];
            for (int k = 0; k < 8; k++)
            {
                buffer[k] = this.Serial_ID[k];
            }
            this.method_22(buffer, 0, 8);
            this.method_22(buffer, 0, 8);
            for (int m = 0; m < 8; m++)
            {
                str3 = str3 + buffer[m].ToString("X2");
            }
        }
        byte num7 = 0;
        int num8 = 0;
        this.byte_1 = new byte[0x105];
        
        //Reset First Byte
        //this.class18_0.byte_0[0] = this.class18_0.StartByte;

        if (this.backgroundWorker_0.CancellationPending)
        {
            return;
        }
        long num6 = 0L;
        this.LogThis("Start uploading");


        Label_02AF:
        this.DiscardBuffer();
        if (num8 == this.class10_settings_0.int_21)
        {
            MessageBox.Show(Form.ActiveForm, "Uploading failed after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.LogThis("Uploading failed after " + this.class10_settings_0.int_21.ToString() + " tries");
            if (!this.IsEmulatorConnected(false))
            {
                if (this.queue_0 != null) this.queue_0.Clear();
                this.EmulatorDisconnect();
            }
        }
        else if (num6 >= 0x8000L)
        {
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ROMulator)
            {
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.method_50(this.byte_1, 0, 2);
                    this.method_52();
                    this.method_52();
                    this.method_52();
                    this.DiscardBuffer();
                }
                catch (Exception exception)
                {
                    this.DiscardBuffer();
                    if (num8 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception.Message);
                    this.IsEmulatorConnected(false);
                    num8++;
                }
            }
        }
        else
        {
            this.backgroundWorker_0.ReportProgress((int) ((((double) num6) / 32768.0) * 100.0));

            //PGMFI RTP
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP)
            {
                this.byte_1 = new byte[5];
                this.byte_1[0] = 0xa4;                                          //a4
                this.byte_1[1] = 0;                                             //0
                this.byte_1[2] = this.class18_0.GetByteAt(num6);       //Get 1byte
                this.byte_1[3] = this.class18_0.method_148(0x8000L + num6);     //MSB
                this.byte_1[4] = this.class18_0.method_147(0x8000L + num6);     //LSB
                if (this.byte_0[(int)((IntPtr)num6)] == this.class18_0.GetByteAt(num6))
                {
                    num6 += 1L;
                }
                else
                {
                    this.byte_1[1] = this.method_46(this.byte_1, 0, 5);
                    try
                    {
                        this.method_50(this.byte_1, 0, 5);
                        num7 = this.method_52();
                        this.DiscardBuffer();
                        if (num7 == 0)
                        {
                            num6 += 1L;
                            num8 = 0;
                        }
                        else
                        {
                            if (!this.IsEmulatorConnected(false) && num8 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num6) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num7) + " (Expected: " + string.Format("{0:X2}", 0) + ")");
                            num8++;
                        }
                    }
                    catch (Exception exception)
                    {
                        this.DiscardBuffer();
                        if (num8 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception.Message);
                        this.IsEmulatorConnected(false);
                        num8++;
                    }
                }
                goto Label_02AF;
            }

            //OSTRICH
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.CobraRTP
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.BMulator
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.Vitaprog
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.ECUTamer)
            {
                if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.CobraRTP
                    && this.class10_settings_0.emulatorMode_0 != EmulatorMode.BMulator  //Remove this for 4K BMulator
                    && this.class10_settings_0.emulatorMode_0 != EmulatorMode.ECUTamer
                    && ((this.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_2 && this.int_2 >= 3)
                    || (this.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_1 && this.int_2 >= 12)))
                {
                    //Ostrich 2.0
                    this.byte_1 = new byte[0x1006];
                    this.byte_1[0] = 90;                                            //Z
                    this.byte_1[1] = 0x57;                                          //W
                    this.byte_1[2] = 0x10;                                          //n = 16 (16 for 4k serial | 4096)
                    this.byte_1[3] = 0;                                             //MMSB ... Always = 0
                    this.byte_1[4] = this.class18_0.method_148(0x8000L + num6);     //MSB
                    for (int num9 = 0; num9 < 0x1000; num9++)
                    {
                        this.byte_1[5 + num9] = this.class18_0.GetByteAt(num6 + num9); //All Bytes
                    }
                    this.byte_1[0x1005] = this.method_46(this.byte_1, 0, 0x1005);       //Checksum
                    try
                    {
                        this.method_50(this.byte_1, 0, 0x1006);
                        byte Test = this.method_52();
                        this.DiscardBuffer();
                        if (Test == 0x4f)
                        {
                            num6 += 0xfffL;
                            num6 += 1L;
                            num8 = 0;
                        }
                        else
                        {
                            this.IsEmulatorConnected(false);
                            if (num8 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num6) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", Test) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                            num8++;
                        }
                    }
                    catch (Exception exception2)
                    {
                        this.DiscardBuffer();
                        if (num8 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception2.Message);
                        this.IsEmulatorConnected(false);
                        num8++;
                    }
                }
                else
                {
                    if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.ECUTamer)
                    {
                        //Ostrich 1.0 and CobrRTP
                        this.byte_1 = new byte[0x105];
                        this.byte_1[0] = 0x57;
                        this.byte_1[1] = 0;
                        this.byte_1[2] = this.class18_0.method_148(0x8000L + num6);
                        this.byte_1[3] = this.class18_0.method_147(0x8000L + num6);
                        for (int num11 = 0; num11 < 0x100; num11++)
                        {
                            this.byte_1[4 + num11] = this.class18_0.GetByteAt(num6 + num11);
                        }
                        this.byte_1[260] = this.method_46(this.byte_1, 0, 260);
                        try
                        {
                            if (num6 == 0L)
                            {
                                for (int num12 = 0; num12 < 0x105; num12++)
                                {
                                }
                            }
                            this.method_50(this.byte_1, 0, 0x105);
                            byte Test = this.method_52();
                            this.DiscardBuffer();
                            if (Test == 0x4f)
                            {
                                num6 += 0xffL;
                                num6 += 1L;
                                num8 = 0;
                            }
                            else
                            {
                                if (!this.IsEmulatorConnected(false) && num8 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num6) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", Test) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                                num8++;
                            }
                        }
                        catch (Exception exception3)
                        {
                            this.DiscardBuffer();
                            if (num8 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception3.Message);
                            this.IsEmulatorConnected(false);
                            num8++;
                        }
                    }
                    else
                    {
                        this.byte_1 = new byte[2054];
                        this.byte_1[0] = 90;
                        this.byte_1[1] = 87;
                        this.byte_1[2] = 8;
                        this.byte_1[3] = 0;
                        this.byte_1[4] = this.class18_0.method_148(32768L + num6);
                        for (int m = 0; m < 2048; m++)
                        {
                            this.byte_1[5 + m] = this.class18_0.GetByteAt(num6 + (long)m);
                        }
                        this.byte_1[2053] = this.method_46(this.byte_1, 0, 2053);
                        try
                        {
                            this.method_50(this.byte_1, 0, 2054);
                            Thread.Sleep(10);
                            byte b3 = this.method_52();
                            if (b3 == 79)
                            {
                                num6 += 2047L;
                                num6 += 1L;
                                num8 = 0;
                            }
                            else
                            {
                                this.IsEmulatorConnected(false);
                                if (num8 == 0)
                                {
                                    this.LogThis(string.Concat(new string[]
                                    {
                                    "Checksum error @",
                                    string.Format("{0:X2}", num6),
                                    "\nReply is: ",
                                    string.Format("{0:X2}", b3),
                                    " (Expected: ",
                                    string.Format("{0:X2}", 79),
                                    ")"
                                    }));
                                }
                                num8++;
                            }
                        }
                        catch (Exception ex4)
                        {
                            this.DiscardBuffer();
                            if (num8 == 0)
                            {
                                this.LogThis("Uploading error:\n" + ex4.Message);
                            }
                            this.IsEmulatorConnected(false);
                            num8++;
                        }
                    }
                }
                goto Label_02AF;
            }

            //Romulator
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ROMulator)
            {
                this.byte_1 = new byte[261];
                this.byte_1[0] = 0x77;                                  // M
                this.byte_1[1] = 0;                                     // 0
                this.byte_1[2] = this.class18_0.method_148(num6);       //MSB Byte
                this.byte_1[3] = this.class18_0.method_147(num6);       //LSB Byte
                for (int num14 = 0; num14 < 0x100; num14++)
                {
                    this.byte_1[4 + num14] = this.class18_0.GetByteAt(num6 + num14);    //Get 256bytes starting from 'num6'
                }
                this.byte_1[260] = this.method_46(this.byte_1, 0, 260);     //apply checksum
                try
                {
                    this.method_50(this.byte_1, 0, 0x105);          //send datas
                    byte Test = this.method_52();
                    this.DiscardBuffer();
                    if (Test == 0x4f)
                    {
                        num6 += 0xffL;
                        num6 += 1L;
                        num8 = 0;
                    }
                    else
                    {
                        if (!this.IsEmulatorConnected(false) && num8 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num6) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", Test) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                        num8++;
                    }
                }
                catch (Exception exception5)
                {
                    this.DiscardBuffer();
                    if (num8 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception5.Message);
                    this.IsEmulatorConnected(false);
                    num8++;
                }
                goto Label_02AF;
            }

            //Demon
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
            {
                if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                {
                    //NeptuneRTP
                    this.byte_1 = new byte[0x105];
                    this.byte_1[0] = 0x57;
                    this.byte_1[1] = 0;
                    this.byte_1[2] = this.class18_0.method_148(0x8000L + num6);
                    this.byte_1[3] = this.class18_0.method_147(0x8000L + num6);
                    for (int num11 = 0; num11 < 0x100; num11++)
                    {
                        this.byte_1[4 + num11] = this.class18_0.GetByteAt(num6 + num11);
                    }
                    this.byte_1[260] = this.method_46(this.byte_1, 0, 260);
                    if (num6 == 0L) for (int num12 = 0; num12 < 0x105; num12++) { }
                }
                else
                {
                    byte[] buffer2 = new byte[2];
                    Random random = new Random();
                    random.NextBytes(buffer2);
                    random = null;
                    this.byte_1 = new byte[0x1008];
                    this.byte_1[0] = 90;                // Z
                    this.byte_1[1] = 0x57;              // 
                    this.byte_1[2] = 0x10;              //
                    this.byte_1[3] = buffer2[0];        // random encryption1
                    this.byte_1[4] = buffer2[1];        // random encryption2
                    this.byte_1[5] = 0;                 // 0
                    this.byte_1[6] = this.class18_0.method_148(0x8000L + num6); //
                    for (int num15 = 0; num15 < 0x1000; num15++)
                    {
                        this.byte_1[7 + num15] = this.class18_0.GetByteAt(num6 + num15);    // Get 4096 bytes starting from 'num6'
                    }
                    if (num6 == 0L) for (int num16 = 0; num16 < 0x100; num16++) { }     //not neccessary?
                    this.method_22(this.byte_1, 3, 0x1007);                             //encrypt the bytes for the demon
                    if (num6 == 0L) for (int num17 = 0; num17 < 0x105; num17++) { }     //not neccessary?
                    this.byte_1[0x1007] = this.method_46(this.byte_1, 0, 0x1007);       //Apply Checksum
                }


                try
                {
                    if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP) this.method_50(this.byte_1, 0, 0x105);
                    else this.method_50(this.byte_1, 0, 0x1008);                    //Send the data to the Demon

                    byte Test = this.method_52();
                    this.DiscardBuffer();
                    if (Test == 0x4f)
                    {
                        if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                        {
                            num6 += 0xffL;
                            num6 += 1L;
                            num8 = 0;
                        }
                        else
                        {
                            num6 += 0xfffL;
                            num6 += 1L;
                            num8 = 0;
                        }
                    }
                    else
                    {
                        if (!this.IsEmulatorConnected(false) && num8 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num6) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", Test) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                        num8++;
                    }
                }
                catch (Exception exception6)
                {
                    this.DiscardBuffer();
                    if (num8 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception6.Message);
                    this.IsEmulatorConnected(false);
                    num8++;
                }
                goto Label_02AF;
            }
        }
        this.backgroundWorker_0.ReportProgress(100);
        num6 = 0L;
        this.LogThis("Done uploading");
    }

    private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.delegate66_0 != null)
        {
            this.delegate66_0(e.ProgressPercentage);
        }
    }

    private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.method_12(false);
        this.bool_2 = false;
        this.method_14(EmulatorState.Connected);
        if (this.backgroundWorker_0 != null)
        {
            this.backgroundWorker_0.Dispose();
            this.backgroundWorker_0 = null;
        }
        if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
        this.byte_1 = null;
        this.byte_2 = null;
        this.byte_0 = null;
        GC.Collect(2, GCCollectionMode.Forced);
        this.bool_9 = false;
    }

    //Download Rom

    private void backgroundWorker_1_DoWork(object sender, DoWorkEventArgs e)
    {
        int num3 = 0;
        this.byte_1 = new byte[8];
        this.byte_2 = new byte[0x101];
        if (this.method_13() != EmulatorState.Sending_data) this.method_14(EmulatorState.Downloading_data);
        if (this.backgroundWorker_1.CancellationPending) goto Label_0F11;

        long num = 0L;
        long num2 = 0L;
        this.LogThis("Start downloading");

        Label_009B:
        this.DiscardBuffer();
        if (num3 == this.class10_settings_0.int_21)
        {
            MessageBox.Show(Form.ActiveForm, "Downloading failed after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.LogThis("Downloading failed after " + this.class10_settings_0.int_21.ToString() + " tries");
            if (!this.IsEmulatorConnected(false))
            {
                if (this.queue_0 != null) this.queue_0.Clear();
                this.EmulatorDisconnect();
                this.SetConnected(false);
            }
        }
        else if (num >= 0x8000L)
        {
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ROMulator)
            {
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.method_50(this.byte_1, 0, 2);
                    this.method_52();
                    this.method_52();
                    this.method_52();
                    this.DiscardBuffer();
                }
                catch (Exception exception2)
                {
                    this.DiscardBuffer();
                    if (num3 == 0) this.LogThis("Downloading error:" + Environment.NewLine + "" + exception2.Message);
                    this.IsEmulatorConnected(false);
                    num3++;
                }
            }
        }
        else
        {
            this.backgroundWorker_1.ReportProgress((int) ((((double) num) / 32768.0) * 100.0));

            //PGMFI RTP
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP)
            {
                this.method_41();
                this.byte_1 = new byte[3];
                this.byte_1[0] = 130;                               //130 or 0x82
                this.byte_1[1] = this.class18_0.method_148(num);    //MSB
                this.byte_1[2] = this.class18_0.method_147(num);    //LSB
                try
                {
                    //this.LogThis("PGMFI RTP: Write command, address: " + this.byte_1[1].ToString("X2") + this.byte_1[2].ToString("X2"));
                    this.method_50(this.byte_1, 0, 3);              //Send CMD
                    for (int i = 0; i < 0x100; i++)                 //Read 256bytes
                    {
                        this.byte_0[(int)((IntPtr)(num + i))] = this.method_52();
                        this.method_42(this.byte_0[(int)((IntPtr)(num + i))]);
                        num2 = i;
                    }
                    byte num5 = this.method_52();
                    this.DiscardBuffer();
                    if (this.method_40() != num5)
                    {
                        if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num5) + " (Expected: " + string.Format("{0:X2}", this.method_40()) + ")");
                        this.IsEmulatorConnected(false);
                        this.method_14(EmulatorState.Error_detected);
                        num2 = 0L;
                        num3++;
                    }
                    else
                    {
                        num += num2;
                        num += 1L;
                        num2 = 0L;
                        num3 = 0;
                    }
                }
                catch (Exception exception)
                {
                    this.DiscardBuffer();
                    if (num3 == 0) this.LogThis("Downloading error:" + Environment.NewLine + "" + exception.Message);
                    this.IsEmulatorConnected(false);
                    num3++;
                    num2 = 0L;
                }
                goto Label_009B;
            }

            //Ostrich
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.CobraRTP
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.BMulator
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.Vitaprog
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.ECUTamer)
            {
                if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.CobraRTP
                    && ((this.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_2 && this.int_2 >= 3) || (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ECUTamer)))
                {
                    //Ostrich 2.0 && ECU Tamer
                    this.byte_2 = new byte[4096];
                    if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ECUTamer) this.byte_2 = new byte[2048];
                    this.method_41();
                    this.byte_1 = new byte[6];
                    this.byte_1[0] = 90;        //Z
                    this.byte_1[1] = 0x52;      //R
                    this.byte_1[2] = 0x10;      //16 = 4k
                    if (this.byte_2.Length == 2048) this.byte_1[2] = 0x08; //8 = 2k
                    this.byte_1[3] = 0;         //MMSB = 0
                    this.byte_1[4] = this.class18_0.method_148(0x8000L + num);  //MSB
                    this.byte_1[5] = this.method_46(this.byte_1, 0, 5);         //LSB
                    try
                    {
                        this.method_50(this.byte_1, 0, 6);      //SerialWrite Byte_1 (6x bytes lenght)
                        Thread.Sleep(10);
                        if (this.byte_2.Length == 2048)
                        {
                            this.method_54(this.byte_2, 2048);
                            this.method_43(this.byte_2, 2048);
                        }
                        else
                        {
                            this.method_54(this.byte_2, 0x1000);    //SerialRead 4096 bytes
                            this.method_43(this.byte_2, 0x1000);    //Calculatate the checksum of the 4096 bytes received
                        }
                        byte num7 = this.method_52();           //Read one more and also the Last byte in the serial buffer to retreive Serial Checksum
                        this.DiscardBuffer();
                        if (this.method_40() != num7)           //Compare 4096 bytes received checksum with the last serial buffer checksum byte
                        {
                            if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num7) + " (Expected: " + string.Format("{0:X2}", this.method_40()) + ")");
                            this.IsEmulatorConnected(false);
                            this.method_14(EmulatorState.Error_detected);
                            num3++;
                        }
                        else
                        {
                            if (this.byte_2.Length == 2048)
                            {
                                this.method_44(this.byte_2, (int)num2, 2048);
                                num2 += 2048L;
                            }
                            else
                            {
                                this.method_44(this.byte_2, (int)num, 0x1000); //Checksum are same, transfert the 4096bytes received to the actual baserom variable
                                num2 += 4096L;
                            }
                            num += 0x1000L;                                 //Increase the loop byte 4096bytes for the next read location (aka MSB)
                            num3 = 0;
                        }
                    }
                    catch (Exception exception2)
                    {
                        this.DiscardBuffer();
                        if (num3 == 0) this.LogThis("Downloading error:" + Environment.NewLine + "" + exception2.Message);
                        this.IsEmulatorConnected(false);
                        num3++;
                    }
                }
                else
                {
                    //Ostrich 1.0 and CobraRTP
                    this.method_41();
                    this.byte_1 = new byte[5];
                    this.byte_1[0] = 0x52;
                    this.byte_1[1] = 0;
                    this.byte_1[2] = this.class18_0.method_148(0x8000L + num);
                    this.byte_1[3] = this.class18_0.method_147(0x8000L + num);
                    this.byte_1[4] = this.method_46(this.byte_1, 0, 4);
                    try
                    {
                        this.method_50(this.byte_1, 0, 5);
                        //Thread.Sleep(100);
                        //int Tryyy = 0;
                        for (int j = 0; j < 0x100; j++)
                        {
                            this.byte_2[j] = this.method_52();
                            /*try
                            {
                                this.byte_2[j] = this.method_52();
                            }
                            catch (TimeoutException exx)
                            {
                                Tryyy++;
                                this.method_50(this.byte_1, 0, 5);
                                Console.WriteLine("Tryy" + Tryyy + " | Index:" + j);
                                if (Tryyy > 3)
                                {
                                    this.DiscardBuffer();
                                    if (num3 == 0) this.LogThis("Downloading error:" + Environment.NewLine + "" + exx.Message);
                                    this.IsEmulatorConnected(false);
                                    num3++;
                                    num2 = 0L;
                                    goto Label_009B;
                                }
                                j = -1;
                                Thread.Sleep(50);
                            }*/
                            //Console.WriteLine("byte" + j + ":0x" + this.byte_2[j].ToString("X2"));
                        }
                        //Console.WriteLine("ptuty");
                        this.method_43(this.byte_2, 0x100);
                        //Console.WriteLine("yerre");
                        byte num9 = this.method_52();
                        this.DiscardBuffer();
                        if (this.method_40() != num9)
                        {
                            if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num9) + " (Expected: " + string.Format("{0:X2}", this.method_40()) + ")");
                            this.IsEmulatorConnected(false);
                            this.method_14(EmulatorState.Error_detected);
                            num3++;
                        }
                        else
                        {
                            this.method_44(this.byte_2, (int) num, 0x100);
                            num += 0x100L;
                            num3 = 0;
                            //Thread.Sleep(50);
                        }
                    }
                    catch (Exception exception3)
                    {
                        //Console.WriteLine("erwreew");
                        this.DiscardBuffer();
                        if (num3 == 0) this.LogThis("Downloading error:" + Environment.NewLine + "" + exception3.Message);
                        this.IsEmulatorConnected(false);
                        num3++;
                        num2 = 0L;
                    }
                }
                goto Label_009B;
            }

            //Romulator
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ROMulator)
            {
                this.method_41();
                this.byte_1 = new byte[4];
                this.byte_1[0] = 0x52;
                this.byte_1[1] = 0;
                this.byte_1[2] = this.class18_0.method_148(num);
                this.byte_1[3] = this.class18_0.method_147(num);
                this.byte_1[4] = this.method_46(this.byte_1, 0, 4);
                try
                {
                    this.method_50(this.byte_1, 0, 5);
                    for (int m = 0; m < 0x100; m++)
                    {
                        this.byte_0[(int) ((IntPtr) (num + m))] = this.method_52();
                        this.method_42(this.byte_0[(int) ((IntPtr) (num + m))]);
                        num2 = m;
                    }
                    byte num13 = this.method_52();
                    this.DiscardBuffer();
                    if (this.method_40() != num13)
                    {
                        if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num13) + " (Expected: " + string.Format("{0:X2}", this.method_40()) + ")");
                        this.IsEmulatorConnected(false);
                        this.method_14(EmulatorState.Error_detected);
                        num2 = 0L;
                        num3++;
                    }
                    else
                    {
                        num += num2;
                        num += 1L;
                        num2 = 0L;
                        num3 = 0;
                    }
                }
                catch (Exception exception4)
                {
                    this.DiscardBuffer();
                    if (num3 == 0) this.LogThis("Downloading error:" + Environment.NewLine + "" + exception4.Message);
                    this.IsEmulatorConnected(false);
                    num3++;
                    num2 = 0L;
                }
                goto Label_009B;
            }

            //Demon
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
            {
                byte num14 = 0;
                byte[] buffer2 = new byte[0x1000];
                if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                {
                    buffer2 = new byte[0x100];
                    this.method_41();
                    this.byte_1 = new byte[5];
                    this.byte_1[0] = 0x52;
                    this.byte_1[1] = 0;
                    this.byte_1[2] = this.class18_0.method_148(0x8000L + num);
                    this.byte_1[3] = this.class18_0.method_147(0x8000L + num);
                    this.byte_1[4] = this.method_46(this.byte_1, 0, 4);
                }
                else
                {
                    this.method_41();
                    byte[] buffer = new byte[2];
                    new Random().NextBytes(buffer);
                    this.byte_1 = new byte[8];
                    this.byte_1[0] = 90;
                    this.byte_1[1] = 0x52;
                    this.byte_1[2] = 0x10;
                    this.byte_1[3] = buffer[0];
                    this.byte_1[4] = buffer[1];
                    this.byte_1[5] = 0;
                    this.byte_1[6] = this.class18_0.method_148(0x8000L + num);
                    num14 = this.method_22(this.byte_1, 3, 7);
                    this.byte_1[7] = this.method_46(this.byte_1, 0, 8);
                }

                try
                {
                    if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP) this.method_50(this.byte_1, 0, 5);
                    else this.method_50(this.byte_1, 0, 8);
                    //this.method_50(this.byte_1, 0, 8);

                    if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                    {
                        for (int n = 0; n < 0x100; n++) { }
                        this.method_54(buffer2, 0x100);
                        //for (int j = 0; j < 0x100; j++) this.byte_2[j] = this.method_52();
                    }
                    else
                    {
                        for (int n = 0; n < 0x1000; n++) { }
                        this.method_54(buffer2, 0x1000);
                    }

                    if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP) this.method_43(buffer2, 0x100);
                    else this.method_43(buffer2, 0x1000);
                    //this.method_43(buffer2, 0x1000);

                    byte num16 = this.method_52();
                    this.DiscardBuffer();
                    if (this.method_40() != num16)
                    {
                        if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num16) + " (Expected: " + string.Format("{0:X2}", this.method_40()) + ")");
                        this.IsEmulatorConnected(false);
                        this.method_14(EmulatorState.Error_detected);
                        num2 = 0L;
                        num3++;
                    }
                    else
                    {
                        //this.LogThis("Received:" + Environment.NewLine + "" + buffer2[0].ToString("X2") + ", " + buffer2[1].ToString("X2") + ", " + buffer2[2].ToString("X2") + ", " + buffer2[3].ToString("X2") + ", " + buffer2[4].ToString("X2") + ", " + buffer2[5].ToString("X2") + ", " + buffer2[6].ToString("X2") + ", " + buffer2[7].ToString("X2") + ", " + buffer2[8].ToString("X2"));
                        if (this.emulatorMoatesType_0 != EmulatorMoatesType.neptuneRTP) this.method_25(num14, buffer2, 0, 0x1000);
                        //this.method_25(num14, buffer2, 0, 0x1000);

                        if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                        {
                            this.method_44(buffer2, (int)num, 0x100);
                            num += num2;
                            num += 1L;
                            num2 = 0L;
                            num3 = 0;
                        }
                        else
                        {
                            this.method_44(buffer2, (int)num, 0x1000);
                            num += 0x1000L;
                            num2 = 0L;
                            num3 = 0;
                        }
                    }
                }
                catch (Exception exception4)
                {
                    this.DiscardBuffer();
                    if (num3 == 0) this.LogThis("Downloading error:" + Environment.NewLine + "" + exception4.Message);
                    this.IsEmulatorConnected(false);
                    num3++;
                    num2 = 0L;
                }
                goto Label_009B;
            }
        }
    Label_0F11:
        this.backgroundWorker_1.ReportProgress(100);
        this.byte_1 = null;
        this.byte_2 = null;
        num2 = 0L;
        num3 = 0;
        num = 0L;
        this.LogThis("Done downloading");
    }

    private void backgroundWorker_1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.delegate66_0 != null)
        {
            this.delegate66_0(e.ProgressPercentage);
        }
    }

    private void backgroundWorker_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (this.serialPort_0 != null)
        {
            this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
            this.serialPort_0.WriteTimeout = 500;
        }
        if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
        this.byte_1 = null;
        this.byte_2 = null;
        if (!this.bool_2)
        {
            this.method_12(false);
            this.class18_0.method_67(this.byte_0, false);
            this.byte_0 = null;
            if (this.backgroundWorker_1 != null)
            {
                this.backgroundWorker_1.Dispose();
                this.backgroundWorker_1 = null;
            }
        }
    }

    //Realtime Updating

    private void backgroundWorker_2_DoWork(object sender, DoWorkEventArgs e)
    {
        byte num = 0;
        byte num2 = 0;
        int num3 = 0;
        int num4 = 0;
        Struct16 struct2 = new Struct16();
        this.method_14(EmulatorState.Realtime);
        if (this.backgroundWorker_2.CancellationPending) goto Label_0D3A;

    Label_0053:
        this.DiscardBuffer();
        this.int_0 = this.queue_0.Count;

        if (this.queue_0.Count != 0)
        {
            //if (this.queue_0.Count > LastQueuCount) LastQueuCount = this.queue_0.Count;
            //this.backgroundWorker_2.ReportProgress((int)((((double)(LastQueuCount - this.queue_0.Count)) / LastQueuCount) * 100.0));

            if ((this.int_0 / 10) != num4)
            {
                num4 = this.int_0 / 10;
                if (this.delegate65_0 != null)
                {
                    this.delegate65_0(EmulatorState.Realtime, this.int_0, false);
                }
            }

            //PGMFI RTP
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP)
            {
                this.DiscardBuffer();
                struct2 = this.queue_0.Dequeue();
                while (true)
                {
                    if (num3 == this.class10_settings_0.int_21)
                    {
                        MessageBox.Show(Form.ActiveForm, "Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.LogThis("Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries");
                        if (!this.IsEmulatorConnected(false)) this.SetConnected(false);
                        goto Label_0D3A;
                    }
                    this.byte_1 = new byte[5];
                    this.byte_1[0] = 0xa4;
                    this.byte_1[1] = 0;
                    this.byte_1[2] = struct2.byte_0_X;
                    this.byte_1[3] = this.class18_0.method_148(0x8000L + struct2.long_0_X);
                    this.byte_1[4] = this.class18_0.method_147(0x8000L + struct2.long_0_X);
                    this.byte_1[1] = this.method_46(this.byte_1, 0, 5);
                    try
                    {
                        this.method_50(this.byte_1, 0, 5);
                        num2 = this.method_52();
                        this.DiscardBuffer();
                        if (num2 == 0)
                        {
                            this.DiscardBuffer();
                            num3 = 0;
                            goto Label_0053;
                        }
                        this.DiscardBuffer();
                        if (!this.IsEmulatorConnected(false)) 
                        {
                            this.LogThis("Realtime update write error @" + string.Format("{0:X2}", struct2.long_0_X) + "(ecu replied: " + string.Format("{0:x2}", num2) + ")");
                            num3++;
                        }
                        /*if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", struct2.long_0_X) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num2) + " (Expected: " + string.Format("{0:X2}", 0) + ")");
                        this.IsEmulatorConnected(false);
                        num3++;*/
                    }
                    catch (Exception exception)
                    {
                        this.DiscardBuffer();
                        if (num3 == 0) this.LogThis("Realtime update error:" + Environment.NewLine + "" + exception.Message);
                        this.IsEmulatorConnected(false);
                        num3++;
                    }
                }
            }

            //Ostrich
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.CobraRTP
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.BMulator
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.Vitaprog
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.ECUTamer)
            {
                //upload calibration take the same time as ~33 single bytes
                if (this.queue_0.Count >= 33)
                {
                    this.queue_0.Clear();
                    this.method_12(false);
                    CaliEmuProgressReport = false;
                    this.method_19();
                    CaliEmuProgressReport = true;
                }
                else
                {
                    struct2 = this.queue_0.Dequeue();
                    while (true)
                    {
                        if (num3 == this.class10_settings_0.int_21)
                        {
                            MessageBox.Show(Form.ActiveForm, "Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            this.LogThis("Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries");
                            if (!this.IsEmulatorConnected(false)) this.SetConnected(false);
                            goto Label_0D3A;
                        }

                        //######################################################
                        //Normal 1byte send
                        this.byte_1 = new byte[6];
                        this.byte_1[0] = 0x57;
                        this.byte_1[1] = 1;
                        this.byte_1[2] = this.class18_0.method_148(0x8000L + struct2.long_0_X);
                        this.byte_1[3] = this.class18_0.method_147(0x8000L + struct2.long_0_X);
                        this.byte_1[4] = struct2.byte_0_X;
                        num = this.method_46(this.byte_1, 0, 5);
                        this.byte_1[5] = num;   //index error here

                        try
                        {
                            //Normal 1byte send
                            this.method_50(this.byte_1, 0, 6);

                            num2 = this.method_52();
                            this.DiscardBuffer();
                            if (num2 == 0x4f)
                            {
                                this.DiscardBuffer();
                                num3 = 0;
                                goto Label_0053;
                            }
                            this.DiscardBuffer();
                            if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", struct2.long_0_X) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num2) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                            this.IsEmulatorConnected(false);
                            num3++;
                        }
                        catch (Exception exception2)
                        {
                            this.DiscardBuffer();
                            if (num3 == 0) this.LogThis("Realtime update error:" + Environment.NewLine + "" + exception2.Message);
                            this.IsEmulatorConnected(false);
                            num3++;
                        }
                    }
                }
            }

            //Romulator
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ROMulator)
            {
                struct2 = this.queue_0.Dequeue();
                while (true)
                {
                    if (num3 == this.class10_settings_0.int_21)
                    {
                        MessageBox.Show(Form.ActiveForm, "Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.LogThis("Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries");
                        if (!this.IsEmulatorConnected(false)) this.SetConnected(false);
                        goto Label_0D3A;
                    }
                    this.byte_1 = new byte[6];
                    this.byte_1[0] = 0x77;
                    this.byte_1[1] = 1;
                    this.byte_1[2] = this.class18_0.method_148(struct2.long_0_X);
                    this.byte_1[3] = this.class18_0.method_147(struct2.long_0_X);
                    this.byte_1[4] = struct2.byte_0_X;
                    num = this.method_46(this.byte_1, 0, 5);
                    this.byte_1[5] = num;
                    try
                    {
                        this.method_50(this.byte_1, 0, 6);
                        num2 = this.method_52();
                        this.DiscardBuffer();
                        if (num2 == 0x4f)
                        {
                            this.DiscardBuffer();
                            num3 = 0;
                            goto Label_0053;
                        }
                        this.DiscardBuffer();
                        if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", struct2.long_0_X) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num2) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                        this.IsEmulatorConnected(false);
                        num3++;
                    }
                    catch (Exception exception4)
                    {
                        this.DiscardBuffer();
                        if (num3 == 0) this.LogThis("Realtime update error:" + Environment.NewLine + "" + exception4.Message);
                        this.IsEmulatorConnected(false);
                        num3++;
                    }
                }
            }

            //Demon
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
            {
                if (this.queue_0.Count >= 512)
                {
                    this.queue_0.Clear();
                    this.method_12(false);
                    this.method_19();
                }
                else
                {
                    struct2 = this.queue_0.Dequeue();
                    while (true)
                    {
                        if (num3 == this.class10_settings_0.int_21)
                        {
                            MessageBox.Show(Form.ActiveForm, "Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            this.LogThis("Realtime update failed after " + this.class10_settings_0.int_21.ToString() + " tries");
                            if (!this.IsEmulatorConnected(false))
                            {
                                this.queue_0.Clear();
                                this.EmulatorDisconnect();
                                this.SetConnected(false);
                            }
                            goto Label_0D3A;
                        }
                        if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                        {
                            this.byte_1 = new byte[6];
                            this.byte_1[0] = 0x57;
                            this.byte_1[1] = 1;
                            this.byte_1[2] = this.class18_0.method_148(0x8000L + struct2.long_0_X);
                            this.byte_1[3] = this.class18_0.method_147(0x8000L + struct2.long_0_X);
                            this.byte_1[4] = struct2.byte_0_X;
                            num = this.method_46(this.byte_1, 0, 5);
                            this.byte_1[5] = num;
                        }
                        else
                        {
                            this.byte_1 = new byte[8];
                            byte[] buffer = new byte[2];
                            Random random = new Random();
                            random.NextBytes(buffer);
                            random = null;
                            this.byte_1[0] = 0x57;
                            this.byte_1[1] = 1;
                            this.byte_1[2] = 0;
                            this.byte_1[3] = 0;
                            this.byte_1[4] = this.class18_0.method_148(0x8000L + struct2.long_0_X);
                            this.byte_1[5] = this.class18_0.method_147(0x8000L + struct2.long_0_X);
                            this.byte_1[6] = struct2.byte_0_X;
                            if (this.emulatorMoatesType_0 != EmulatorMoatesType.neptuneRTP) this.method_22(this.byte_1, 2, 7);
                            this.byte_1[7] = this.method_46(this.byte_1, 0, 8);
                        }

                        try
                        {
                            //this.method_50(this.byte_1, 0, 8);
                            if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP) this.method_50(this.byte_1, 0, 6);
                            else this.method_50(this.byte_1, 0, 8);

                            num2 = this.method_52();
                            this.DiscardBuffer();
                            if (num2 == 0x4f)
                            {
                                this.DiscardBuffer();
                                num3 = 0;
                                goto Label_0053;
                            }
                            this.DiscardBuffer();
                            if (num3 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", struct2.long_0_X) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num2) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                            this.IsEmulatorConnected(false);
                            num3++;
                        }
                        catch (Exception exception5)
                        {
                            this.DiscardBuffer();
                            if (num3 == 0) this.LogThis("Realtime update error:" + Environment.NewLine + "" + exception5.Message);
                            this.IsEmulatorConnected(false);
                            num3++;
                        }
                    }
                }
            }
        }
    Label_0D3A:
        //LastQueuCount = 0;
        //this.backgroundWorker_2.ReportProgress(100);
        this.int_0 = 0;
        if (this.bool_3)
        {
            this.method_12(false);
            this.method_19();
        }
    }

    /*private void backgroundWorker_2_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.delegate66_0 != null)
        {
            this.delegate66_0(e.ProgressPercentage);
        }
    }*/

    private void backgroundWorker_2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.method_12(false);
        if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
        if (!this.bool_9)
        {
            this.byte_1 = null;
            this.byte_2 = null;
            GC.Collect(3, GCCollectionMode.Optimized);
        }
    }

    //Upload Rom
    private void backgroundWorker_3_DoWork(object sender, DoWorkEventArgs e)
    {
        long num2 = 0L;
        byte num3 = 0;
        int num4 = 0;
        if (this.backgroundWorker_3 == null) return;
        if (this.backgroundWorker_3.CancellationPending) goto Label_0C75;
        long num = this.class18_0.class13_u_0.long_89;
        this.LogThis("Start uploading");

        Label_002F:
        this.DiscardBuffer();
        this.method_12(true);
        this.DiscardBuffer();
        if (num4 == this.class10_settings_0.int_21)
        {
            MessageBox.Show(Form.ActiveForm, "Uploading failed after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.LogThis("Uploading failed after " + this.class10_settings_0.int_21.ToString() + " tries");
            if (!this.IsEmulatorConnected(false))
            {
                this.queue_0.Clear();
                this.EmulatorDisconnect();
            }
        }
        else if (num >= 0x8000L)
        {
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ROMulator)
            {
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.method_50(this.byte_1, 0, 2);
                    this.method_52();
                    this.method_52();
                    this.method_52();
                    this.DiscardBuffer();
                }
                catch (Exception)
                {
                    this.DiscardBuffer();
                }
            }
        }
        else
        {
            try
            {
                this.backgroundWorker_3.ReportProgress((int)((((double)(num - this.class18_0.class13_u_0.long_89)) / ((double)(0x8000L - this.class18_0.class13_u_0.long_89))) * 100.0));
            }
            catch { }

            //PGMFI RTP
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP)
            {
                this.byte_1 = new byte[5];
                //this.byte_1 = new byte[] { 0xa4, 0, this.class18_0.GetByteAt(num), this.class18_0.method_148(0x8000L + num), this.class18_0.method_147(0x8000L + num) };
                this.byte_1[0] = 0xa4;                                          //a4
                this.byte_1[1] = 0;                                             //0
                this.byte_1[2] = this.class18_0.GetByteAt(num);       //Get 1byte
                this.byte_1[3] = this.class18_0.method_148(0x8000L + num);     //MSB
                this.byte_1[4] = this.class18_0.method_147(0x8000L + num);     //LSB

                this.byte_1[1] = this.method_46(this.byte_1, 0, 5);
                try
                {
                    this.method_50(this.byte_1, 0, 5);
                    num3 = this.method_52();
                    this.DiscardBuffer();
                    if (num3 == 0)
                    {
                        num += 1L;
                        num4 = 0;
                    }
                    else
                    {
                        if (num4 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num3) + " (Expected: " + string.Format("{0:X2}", 0) + ")");
                        this.IsEmulatorConnected(false);
                        num4++;
                    }
                }
                catch (Exception exception)
                {
                    this.DiscardBuffer();
                    if (num4 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception.Message);
                    this.IsEmulatorConnected(false);
                    num4++;
                }
                goto Label_002F;
            }

            //Ostrich
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.CobraRTP
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.BMulator
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.Vitaprog
                || this.class10_settings_0.emulatorMode_0 == EmulatorMode.ECUTamer)
            {
                this.byte_1 = new byte[0x105];
                this.byte_1[0] = 0x57;
                num2 = 0x8000L - num;
                if (num2 > 0x100L)
                {
                    num2 = 0x100L;
                    this.byte_1[1] = 0;
                }
                else
                {
                    this.byte_1[1] = (byte) num2;
                }
                this.byte_1[2] = this.class18_0.method_148(0x8000L + num);
                this.byte_1[3] = this.class18_0.method_147(0x8000L + num);
                for (int i = 0; i < num2; i++)
                {
                    this.byte_1[4 + i] = this.class18_0.GetByteAt(num + i);
                }
                this.byte_1[(int) ((IntPtr) (num2 + 4L))] = this.method_46(this.byte_1, 0, ((int) num2) + 4);

                try
                {
                    this.method_50(this.byte_1, 0, (((int) num2) + 4) + 1);
                    num3 = this.method_52();
                    this.DiscardBuffer();
                    if (num3 == 0x4f)
                    {
                        num += num2;
                        num += 1L;
                    }
                    else
                    {
                        if (num4 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num3) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                        this.IsEmulatorConnected(false);
                        num4++;
                    }
                }
                catch (Exception exception3)
                {
                    this.DiscardBuffer();
                    if (num4 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception3.Message);
                    this.IsEmulatorConnected(false);
                    num4++;
                }
                goto Label_002F;
            }

            //Romulator
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.ROMulator)
            {
                this.byte_1 = new byte[0x105];
                this.byte_1[0] = 0x77;
                num2 = 0x8000L - num;
                if (num2 > 0x100L)
                {
                    num2 = 0x100L;
                    this.byte_1[1] = 0;
                }
                else
                {
                    this.byte_1[1] = (byte) (num2 - 1L);
                }
                this.byte_1[2] = this.class18_0.method_148(num);
                this.byte_1[3] = this.class18_0.method_147(num);
                for (int k = 0; k < num2; k++)
                {
                    this.byte_1[4 + k] = this.class18_0.GetByteAt(num + k);
                }
                this.byte_1[(int) ((IntPtr) (num2 + 4L))] = this.method_46(this.byte_1, 0, ((int) num2) + 4);
                try
                {
                    this.method_50(this.byte_1, 0, (((int) num2) + 4) + 1);
                    num3 = this.method_52();
                    this.DiscardBuffer();
                    if (num3 == 0x4f)
                    {
                        num += num2;
                        num += 1L;
                    }
                    else
                    {
                        if (num4 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num3) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                        this.IsEmulatorConnected(false);
                        num4++;
                    }
                }
                catch (Exception exception5)
                {
                    this.DiscardBuffer();
                    if (num4 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception5.Message);
                    this.IsEmulatorConnected(false);
                    num4++;
                }
                goto Label_002F;
            }

            //Demon
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
            {
                if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                {
                    this.byte_1 = new byte[0x105];
                    this.byte_1[0] = 0x57;
                    num2 = 0x8000L - num;
                    if (num2 > 0x100L)
                    {
                        num2 = 0x100L;
                        this.byte_1[1] = 0;
                    }
                    else
                    {
                        this.byte_1[1] = (byte)num2;
                    }
                    this.byte_1[2] = this.class18_0.method_148(0x8000L + num);
                    this.byte_1[3] = this.class18_0.method_147(0x8000L + num);
                    for (int i = 0; i < num2; i++)
                    {
                        this.byte_1[4 + i] = this.class18_0.GetByteAt(num + i);
                    }
                    this.byte_1[(int)((IntPtr)(num2 + 4L))] = this.method_46(this.byte_1, 0, ((int)num2) + 4);
                }
                else
                {
                    byte[] buffer = new byte[2];
                    Random random = new Random();
                    random.NextBytes(buffer);
                    random = null;
                    this.byte_1 = new byte[0x107];
                    this.byte_1[0] = 0x57;
                    num2 = 0x8000L - num;
                    if (num2 > 0x100L)
                    {
                        num2 = 0x100L;
                        this.byte_1[1] = 0;
                    }
                    else
                    {
                        this.byte_1[1] = (byte)num2;
                    }
                    this.byte_1[2] = buffer[0];
                    this.byte_1[3] = buffer[1];
                    this.byte_1[4] = this.class18_0.method_148(0x8000L + num);
                    this.byte_1[5] = this.class18_0.method_147(0x8000L + num);
                    for (int m = 0; m < num2; m++) this.byte_1[6 + m] = this.class18_0.GetByteAt(num + m);
                    this.method_22(this.byte_1, 2, (int)(num2 + 6L));
                    this.byte_1[(int)((IntPtr)(num2 + 6L))] = this.method_46(this.byte_1, 0, ((int)num2) + 6);
                }

                try
                {
                    if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP) this.method_50(this.byte_1, 0, (((int)num2) + 4) + 1);
                    else this.method_50(this.byte_1, 0, (((int)num2) + 6) + 1);
                    //this.method_50(this.byte_1, 0, (((int)num2) + 6) + 1);

                    num3 = this.method_52();
                    //this.DiscardBuffer();
                    if (num3 == 0x4f)
                    {
                        num += num2;
                        num += 1L;
                    }
                    else
                    {
                        if (num4 == 0) this.LogThis("Checksum error @" + string.Format("{0:X2}", num) + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num3) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                        this.IsEmulatorConnected(false);
                        num4++;
                    }
                }
                catch (Exception exception6)
                {
                    this.DiscardBuffer();
                    if (num4 == 0) this.LogThis("Uploading error:" + Environment.NewLine + "" + exception6.Message);
                    this.IsEmulatorConnected(false);
                    num4++;
                }
                goto Label_002F;
            }
        }
    Label_0C75:
        try
        {
            this.backgroundWorker_3.ReportProgress(100);
        }
        catch { }
        num = 0L;
        this.LogThis("Done uploading");
    }

    private void backgroundWorker_3_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.delegate66_0 != null)
        {
            this.delegate66_0(e.ProgressPercentage);
        }
    }

    private void backgroundWorker_3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.method_12(false);
        this.bool_2 = false;
        this.method_14(EmulatorState.Connected);
        if (this.backgroundWorker_3 != null)
        {
            this.backgroundWorker_3.Dispose();
            this.backgroundWorker_3 = null;
        }
        if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
        if (this.bool_3)
        {
            this.bool_3 = false;
        }
        this.byte_1 = null;
        this.byte_2 = null;
        this.byte_0 = null;
        GC.Collect(6);
    }

    public void backgroundWorker_4_DoWork(object sender, DoWorkEventArgs e)
    {
        if (this.class10_settings_0.bool_31)
        {
            this.Emu_SerialConnected = this.class17_0.method_27();
            return;
        }
        this.LogThis("Port scan thread");
        this.Emu_SerialConnected = false;
        int emuCommCache = 1;
        string[] portNames = SerialPort.GetPortNames();

        if (this.class10_settings_0.emuCommCache != 0)
        {
            try
            {
                emuCommCache = this.class10_settings_0.emuCommCache;
                this.Emu_SerialConnected = false;

                EmulatorDisconnect();

                bool PortAvailable = false;
                for (int i = 0; i < portNames.Length; i++)
                {
                    if (portNames[i] == ("COM" + emuCommCache.ToString())) PortAvailable = true;
                }
                if (!PortAvailable)
                {
                    emuCommCache = 1;
                }
                else
                {
                    this.serialPort_0 = new SerialPort("COM" + emuCommCache.ToString(), this.class10_settings_0.Emulator_Baud);
                    this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
                    this.serialPort_0.WriteTimeout = 500;
                    this.serialPort_0.ReadBufferSize = 0x1100;
                    this.serialPort_0.Encoding = Encoding.Default;
                    this.serialPort_0.Open();
                    LogThis("Cached port open: COM" + emuCommCache.ToString() + " (baud: " + this.class10_settings_0.Emulator_Baud.ToString() + ")");
                    if (this.IsEmulatorConnected(false))
                    {
                        this.serialPort_0.Close();
                        this.class10_settings_0.string_2 = "COM" + emuCommCache.ToString();
                        this.Emu_SerialConnected = true;
                        this.LogThis("Emulator found");
                        //this.backgroundWorker_4.ReportProgress(100);
                        return;
                    }
                    this.LogThis("Emulator not found on Cached COM" + this.class10_settings_0.emuCommCache.ToString());
                    emuCommCache = 1;
                    this.Emu_SerialConnected = false;
                }
                goto Label_0204;
            }
            catch (Exception exception)
            {
                this.LogThis("Cached port failed error:" + Environment.NewLine + "" + exception.Message);
            }
        }
        emuCommCache = 1;
        this.Emu_SerialConnected = false;
    Label_0204:
        try
        {
            if (emuCommCache == 41)
            {
                this.LogThis("Port Scan Failed");
                this.Emu_SerialConnected = false;
                if (this.Report_Error) MessageBox.Show(Form.ActiveForm, "Can't dectect '" + this.class10_settings_0.emulatorMode_0.ToString() + "' with autoscan try manual settings" + Environment.NewLine + "OR see the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //this.backgroundWorker_4.ReportProgress(100);
            }
            else
            {
                //this.backgroundWorker_4.ReportProgress((int)((((double)emuCommCache) / 30.0) * 100.0));

                //Only do available ports
                /*if (!this.class10_0.IsBluetooth)
                {
                    string str = "COM" + emuCommCache.ToString();
                    bool PortAvailable = false;
                    for (int j = 0; j < portNames.Length; j++)
                    {
                        if (portNames[j] == str) PortAvailable = true;
                    }
                    if (!PortAvailable)
                    {
                        emuCommCache++;
                        goto Label_0204;
                    }
                }*/

                //try 921600
                if (this.class10_settings_0.Emulator_Baud != 921600) this.class10_settings_0.Emulator_Baud = 921600;

                bool IsDeviceConnected = TestConnect("COM" + emuCommCache, this.class10_settings_0.Emulator_Baud);
                if (IsDeviceConnected)
                {
                    SetFound(emuCommCache, this.class10_settings_0.Emulator_Baud);
                }
                else
                {
                    //try 115200
                    if (this.class10_settings_0.Emulator_Baud == 921600)
                    {
                        IsDeviceConnected = TestConnect("COM" + emuCommCache, 115200);
                        if (IsDeviceConnected)
                        {
                            this.class10_settings_0.Emulator_Baud = 115200;
                            SetFound(emuCommCache, this.class10_settings_0.Emulator_Baud);
                            //this.backgroundWorker_4.ReportProgress(100);
                        }
                        else
                        {
                            //Change port +1
                            emuCommCache++;
                            goto Label_0204;
                        }
                    }
                    else
                    {
                        IsDeviceConnected = TestConnect("COM" + emuCommCache, 921600);
                        if (IsDeviceConnected)
                        {
                            this.class10_settings_0.Emulator_Baud = 921600;
                            SetFound(emuCommCache, this.class10_settings_0.Emulator_Baud);
                            //this.backgroundWorker_4.ReportProgress(100);
                        }
                        else
                        {
                            //Change port +1
                            emuCommCache++;
                            goto Label_0204;
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            emuCommCache++;
            goto Label_0204;
        }
    }

    private void backgroundWorker_4_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.delegate66_0 != null)
        {
            this.delegate66_0(e.ProgressPercentage);
        }
    }

    private void backgroundWorker_4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        /*if (this.backgroundWorker_4 != null)
        {
            this.backgroundWorker_4.Dispose();
            this.backgroundWorker_4 = null;
        }*/
        if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
    }

    private void SetFound(int emuCommCache, int SetBaud)
    {
        this.serialPort_0.Close();

        this.class10_settings_0.emuCommCache = emuCommCache;
        this.class10_settings_0.string_2 = "COM" + emuCommCache.ToString();

        if ((this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon) && this.class10_settings_0.bool_31)
        {
            this.class10_settings_0.dtCommCache = emuCommCache;
            this.class10_settings_0.string_1 = "COM" + emuCommCache.ToString();
        }
        this.Emu_SerialConnected = true;
    }

    private bool TestConnect(string emuCommCache, int thisBaud)
    {
        bool IsDeviceConnected = false;
        if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen) this.serialPort_0.Close();
        if (this.serialPort_0 != null)
        {
            this.serialPort_0.Dispose();
            this.serialPort_0 = null;
        }
        this.serialPort_0 = new SerialPort(emuCommCache, thisBaud);
        this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
        this.serialPort_0.WriteTimeout = 500;
        this.serialPort_0.ReadBufferSize = 0x1100;
        //this.serialPort_0.DtrEnable = true;
        //this.serialPort_0.RtsEnable = true;
        this.serialPort_0.Encoding = Encoding.Default;
        try
        {
            this.serialPort_0.Open();
            this.LogThis("------------------------------");
            this.LogThis("Port open: " + emuCommCache.ToString() + " (Baud:" + thisBaud + ")");

            //Connect and check if the device is correct
            IsDeviceConnected = this.IsEmulatorConnected(false);
            if (IsDeviceConnected) this.LogThis("Emulator found on " + emuCommCache.ToString());
            else this.LogThis("Emulator NOT found on " + emuCommCache.ToString());
        }
        catch
        {
            this.LogThis("Can't open: " + emuCommCache.ToString() + " (" + thisBaud + ")");
        }

        return IsDeviceConnected;
    }

    //#############################################################################################################################################
    //#############################################################################################################################################
    //#############################################################################################################################################
    //#############################################################################################################################################

    private void method_0(object sender, PowerModeChangedEventArgs e)
    {
        if (e.Mode == PowerModes.Suspend)
        {
            this.LogThis("Supsend detected and logging is connected: " + this.GetConnected().ToString());
            this.bool_6 = this.GetConnected();
            if (this.GetConnected())
            {
                this.method_1(true);
            }
            this.timer_1.Stop();
            this.EmulatorDisconnect();
        }
        else if (e.Mode == PowerModes.Resume)
        {
            this.bool_6 = false;
        }
    }


    public void method_1(bool bool_11)
    {
        this.Report_Error = bool_11;
        GC.Collect();
        if (!this.GetConnected())
        {
            TryingtoConnect = true;
            this.method_14(EmulatorState.Connecting);

            this.Emu_SerialConnected = false;
            if (this.class10_settings_0.Emu_AutoScan)
            {
                if (this.EmuAutoScanStart())
                {
                    this.EmuTryConnect();
                }
            }
            else
            {
                this.EmuTryConnect();
            }
        }
        else
        {
            this.EmuTryConnect();
        }

        if (!this.GetConnected()) this.method_14(EmulatorState.Disconnected);
        TryingtoConnect = false;
    }

    public bool method_10()
    {
        return (this.GetConnected() && this.class10_settings_0.bool_31);
    }

    public bool method_11()
    {
        return this.bool_1;
    }

    public void method_12(bool bool_11)
    {
        this.bool_1 = bool_11;
        if (this.GetConnected())
        {
            this.method_14(EmulatorState.Connected);
        }
        else
        {
            this.method_14(EmulatorState.Disconnected);
        }
    }

    public EmulatorState method_13()
    {
        return this.emulatorState_0;
    }

    public void method_14(EmulatorState emulatorState_1)
    {
        this.emulatorState_0 = emulatorState_1;
        if (this.delegate65_0 != null)
        {
            this.delegate65_0(this.emulatorState_0, this.int_0, true);
        }
    }

    private void method_15(int int_4)
    {
        this.timer_2 = new System.Windows.Forms.Timer();
        this.timer_2.Interval = this.serialPort_0.ReadTimeout;
        this.timer_2.Tick += new EventHandler(this.timer_2_Tick);
        this.bool_10 = false;
        this.timer_2.Start();
        while (this.serialPort_0.BytesToRead < int_4)
        {
            if (this.bool_10)
            {
                this.timer_2.Stop();
                throw new TimeoutException("Chunk timeout");
            }
            Application.DoEvents();
        }
        this.timer_2.Stop();
    }

    public void method_16()
    {
        this.class18_0.method_68();

        if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.ROMulator)
        {
            if (!this.GetConnected())
            {
                this.method_1(true);
                if (!this.GetConnected())
                {
                    this.SetConnected(false);
                    return;
                }
            }
            if (this.method_10())
            {
                this.method_12(true);
                if (this.class17_0.method_34_GetConnected())
                {
                    this.class17_0.method_22(true);
                    while (!this.class17_0.method_21())
                    {
                        Application.DoEvents();
                        this.class17_0.method_22(true);
                    }
                }
            }
            if (!this.IsEmulatorConnected(false))
            {
                this.method_12(false);
                this.SetConnected(false);
            }
            else
            {
                if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
                this.class27_EmuProgress_0 = new Class27_EmuProgress();
                this.class27_EmuProgress_0.method_0(ref this.class25_0, ref this.frmMain_0);

                this.frmMain_0.SetStatusEmulator("Dowloading data");
                this.byte_0 = new byte[0x8000];
                this.backgroundWorker_1 = new BackgroundWorker();
                this.backgroundWorker_1.WorkerSupportsCancellation = true;
                this.backgroundWorker_1.WorkerReportsProgress = true;
                this.backgroundWorker_1.DoWork += new DoWorkEventHandler(this.backgroundWorker_1_DoWork);
                this.backgroundWorker_1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_1_ProgressChanged);
                this.backgroundWorker_1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_1_RunWorkerCompleted);
                this.backgroundWorker_1.RunWorkerAsync();
            }
        }
    }

    public void method_17() //Upload Baserom + Calibration
    {
        while (this.method_11())
        {
            Application.DoEvents();
        }
        if (this.method_10())
        {
            this.method_12(true);
            if (this.class17_0.method_34_GetConnected())
            {
                this.class17_0.method_22(true);
                while (!this.class17_0.method_21())
                {
                    Application.DoEvents();
                    this.class17_0.method_22(true);
                }
            }
        }
        if (!this.IsEmulatorConnected(false))
        {
            this.method_12(false);
            this.SetConnected(false);
        }
        else
        {
            //#######################################################################
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP)
            {
                if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
                this.class27_EmuProgress_0 = new Class27_EmuProgress();
                this.class27_EmuProgress_0.method_0(ref this.class25_0, ref this.frmMain_0);

                this.frmMain_0.SetStatusEmulator("Uploading(Stage1)");
                this.method_14(EmulatorState.Sending_data);
                this.bool_2 = true;
                this.byte_0 = new byte[0x8000];
                this.backgroundWorker_1 = new BackgroundWorker();
                this.backgroundWorker_1.WorkerSupportsCancellation = true;
                this.backgroundWorker_1.WorkerReportsProgress = true;
                this.backgroundWorker_1.DoWork += new DoWorkEventHandler(this.backgroundWorker_1_DoWork);
                this.backgroundWorker_1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_1_ProgressChanged);
                this.backgroundWorker_1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_1_RunWorkerCompleted);
                this.backgroundWorker_1.RunWorkerAsync();
                while (this.backgroundWorker_1.IsBusy)
                {
                    Application.DoEvents();
                }
                this.backgroundWorker_1.Dispose();
                this.backgroundWorker_1 = null;
                if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
            }
            //#######################################################################

            if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
            this.class27_EmuProgress_0 = new Class27_EmuProgress();
            this.class27_EmuProgress_0.method_0(ref this.class25_0, ref this.frmMain_0);

            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP) this.frmMain_0.SetStatusEmulator("Uploading(Stage2)");
            else this.frmMain_0.SetStatusEmulator("Uploading data");


            if (MessageBox.Show(Form.ActiveForm, "Are the Engine Off?" + Environment.NewLine + "Uploading the 'rom' to " + this.class10_settings_0.emulatorMode_0.ToString() + " can cause LIMP MODE!", "Emulator", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.backgroundWorker_0 = new BackgroundWorker();
                this.backgroundWorker_0.WorkerReportsProgress = true;
                this.backgroundWorker_0.WorkerSupportsCancellation = true;
                this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
                this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
                this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
                this.backgroundWorker_0.RunWorkerAsync();
            }
        }
    }

    public void method_18(long long_0_i, byte byte_8)
    {
        if (this.GetConnected() && this.class10_settings_0.bool_32)
        {
            Struct16 item = new Struct16 {
                long_0_X = long_0_i,
                byte_0_X = byte_8 
            };
            if (this.queue_0 == null)
            {
                this.queue_0 = new Queue<Struct16>();
            }
            this.queue_0.Enqueue(item);
            this.timer_0.Start();
        }
    }

    public void method_19()     //Upload Calibration ONLY
    {
        while (this.method_11())
        {
            Application.DoEvents();
        }
        this.method_12(true);
        if (this.method_10() && this.class17_0.method_34_GetConnected())
        {
            this.class17_0.method_22(true);
            while (!this.class17_0.method_21())
            {
                Application.DoEvents();
                this.class17_0.method_22(true);
            }
        }
        if (!this.IsEmulatorConnected(false))
        {
            this.method_12(false);
            this.SetConnected(false);
        }
        else
        {
            if (!this.bool_3)
            {
                if (CaliEmuProgressReport)
                {
                    if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
                    this.class27_EmuProgress_0 = new Class27_EmuProgress();
                    this.class27_EmuProgress_0.method_0(ref this.class25_0, ref this.frmMain_0);
                }

                this.frmMain_0.SetStatusEmulator("Uploading Calibration");
            }
            this.method_12(true);
            this.backgroundWorker_3 = new BackgroundWorker();
            this.backgroundWorker_3.WorkerReportsProgress = CaliEmuProgressReport;
            this.backgroundWorker_3.WorkerSupportsCancellation = true;
            this.backgroundWorker_3.DoWork += new DoWorkEventHandler(this.backgroundWorker_3_DoWork);
            this.backgroundWorker_3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_3_RunWorkerCompleted);
            if (CaliEmuProgressReport) this.backgroundWorker_3.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_3_ProgressChanged);
            this.backgroundWorker_3.RunWorkerAsync();
        }
    }

    public bool EmuTryConnect()
    {
        Control.CheckForIllegalCrossThreadCalls = false;
        if (this.method_11())
        {
            if (this.backgroundWorker_1 != null)
            {
                if (this.backgroundWorker_1.IsBusy) this.backgroundWorker_1.CancelAsync();
                while (this.backgroundWorker_1.IsBusy) Application.DoEvents();
            }
            if (this.backgroundWorker_2 != null)
            {
                if (this.backgroundWorker_2.IsBusy) this.backgroundWorker_2.CancelAsync();
                while (this.backgroundWorker_2.IsBusy) Application.DoEvents();
            }
            if (this.backgroundWorker_0 != null)
            {
                if (this.backgroundWorker_0.IsBusy) this.backgroundWorker_0.CancelAsync();
                while (this.backgroundWorker_0.IsBusy) Application.DoEvents();
            }
            if (this.backgroundWorker_3 != null)
            {
                if (this.backgroundWorker_3.IsBusy) this.backgroundWorker_3.CancelAsync();
                while (this.backgroundWorker_3.IsBusy) Application.DoEvents();
            }
        }

        if (!this.GetConnected())
        {
            bool flag = this.method_5();
            if (flag)
            {
                if (((this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon) && (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogDemon)) && !this.IsEmulatorConnected(true))
                {
                    this.EmulatorDisconnect();
                    flag = false;
                }
                if (this.class10_settings_0.bool_33 && this.class18_0.method_30_HasFileLoadedInBMTune())
                {
                    this.method_17();
                }
                if (this.class10_settings_0.bool_32)
                {
                    this.timer_0.Start();
                }
            }
            if ((flag && (this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon)) && (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogDemon))
            {
                this.timer_1.Start();
            }
            return flag;
        }
        if (this.GetConnected())
        {
            if ((this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon) && (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogDemon))
            {
                this.timer_1.Stop();
            }
            this.EmulatorDisconnect();
            return false;
        }
        this.SetConnected(false);
        return false;
    }

    //#################################################
    //Verify Rom with Emulator content
    public void method_20()
    {
        while (this.method_11())
        {
        }
        if (this.method_10())
        {
            this.method_12(true);
            if (this.class17_0.method_34_GetConnected())
            {
                this.class17_0.method_22(true);
                while (!this.class17_0.method_21())
                {
                    Application.DoEvents();
                    this.class17_0.method_22(true);
                }
            }
        }
        if (!this.IsEmulatorConnected(true))
        {
            MessageBox.Show("Can't find emulator:" + this.class10_settings_0.emulatorMode_0.ToString(), "Emulator Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.method_12(false);
            this.SetConnected(false);
            return;
        }
        this.method_14(EmulatorState.Downloading_data);
        this.bool_2 = true;
        this.byte_0 = new byte[0x8000];
        this.backgroundWorker_1 = new BackgroundWorker();
        this.backgroundWorker_1.WorkerSupportsCancellation = true;
        this.backgroundWorker_1.WorkerReportsProgress = true;
        this.backgroundWorker_1.DoWork += new DoWorkEventHandler(this.backgroundWorker_1_DoWork);
        this.backgroundWorker_1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_1_ProgressChanged);
        this.backgroundWorker_1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_1_RunWorkerCompleted);
        this.backgroundWorker_1.RunWorkerAsync();
        while (this.backgroundWorker_1.IsBusy)
        {
            Application.DoEvents();
        }
        this.backgroundWorker_1.Dispose();
        this.backgroundWorker_1 = null;
        for (int i = 0; i < 0x8000; i++)
        {
            if (this.byte_0[i] != this.class18_0.GetByteAt((long)i))
            {
                MessageBox.Show("Rom did NOT verify!", "Emulator", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                goto Label_0213;
            }
        }
        MessageBox.Show("Rom verified correctly", "Emulator", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    Label_0213:
        this.byte_0 = null;
        this.bool_2 = false;
        GC.Collect(3);
        this.method_14(EmulatorState.Connected);
        this.method_12(false);
    }
    //#################################################

    public byte[] method_21()
    {
        //byte_6 = new byte[] { 15, 0xfc, 0xce, 0x2c, 0xa3, 0x9f, 0x65, 0x99 };
        //byte_7 = new byte[] { 15, 0xfc, 0xce, 0x2c, 0xa3, 0x9f, 0x65, 0x99 };
        if ((this.class18_0.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich))
        {
            return this.byte_6;
        }
        if (this.class18_0.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon)
        {
            this.class18_0.class17_0.frmMain_0.LogThis("Emulator: No vendor");
            //throw new Exception("No vendor");
        }
        return this.byte_7;
    }

    //demon encrypt array
    private byte method_22(byte[] byte_8, int int_4, int int_5)
    {
        byte num = this.method_26();
        for (int i = int_4; i < int_5; i++)
        {
            byte_8[i] = (byte) (byte_8[i] ^ num);
            for (int j = 0; j <= 7; j++)
            {
                switch (j)
                {
                    case 0:
                    case 2:
                    case 4:
                    case 6:
                        byte_8[i] = (byte) (byte_8[i] + this.method_21()[j]);
                        break;

                    default:
                        byte_8[i] = (byte) (byte_8[i] ^ this.method_21()[j]);
                        break;
                }
            }
            num = byte_8[i];
        }
        return num;
    }

    /*private byte[] method_23(byte byte_8)
    {
        return new byte[1];
    }

    private byte[] method_24(byte[] byte_8, int int_4, int int_5)
    {
        byte num = this.method_26();
        byte num2 = 0;
        for (int i = int_4; i < int_5; i++)
        {
            num2 = byte_8[i];
            for (int j = 7; j >= 0; j--)
            {
                switch (j)
                {
                    case 0:
                    case 2:
                    case 4:
                    case 6:
                        byte_8[i] = (byte) (byte_8[i] - this.method_21()[j]);
                        break;

                    default:
                        byte_8[i] = (byte) (byte_8[i] ^ this.method_21()[j]);
                        break;
                }
            }
            byte_8[i] = (byte) (byte_8[i] ^ num);
            num = num2;
        }
        return byte_8;
    }*/

    //demon download rom decrypt array
    private byte[] method_25(byte byte_8, byte[] byte_9, int int_4, int int_5)
    {
        byte num = byte_8;
        byte num2 = 0;
        for (int i = int_4; i < int_5; i++)
        {
            num2 = byte_9[i];
            for (int j = 7; j >= 0; j--)
            {
                switch (j)
                {
                    case 0:
                    case 2:
                    case 4:
                    case 6:
                        byte_9[i] = (byte) (byte_9[i] - this.method_21()[j]);
                        break;

                    default:
                        byte_9[i] = (byte) (byte_9[i] ^ this.method_21()[j]);
                        break;
                }
            }
            byte_9[i] = (byte) (byte_9[i] ^ num);
            num = num2;
        }
        return byte_9;
    }

    private byte method_26()
    {
        byte num = 90;
        for (int i = 0; i < this.method_21().Length; i++)
        {
            num = (byte) (num + this.method_21()[i]);
        }
        return num;
    }

    public void method_3()
    {
        if (this.GetConnected())
        {
            this.EmulatorDisconnect();
        }
        if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
    }

    public bool ResetVendorUnknown(byte ThisVendor)
    {
        int num = 0;
        this.GetSerial();

        if (Vendor_ID != ThisVendor)
        {
            this.byte_1 = new byte[11];
            this.byte_2 = new byte[1];
            this.byte_1[0] = 0x4e;
            this.byte_1[1] = ThisVendor;

            for (int i = 0; i < 8; i++) this.byte_1[2 + i] = this.Serial_ID[i];
            this.byte_1[10] = this.method_46(this.byte_1, 0, 10);
        Label_0071:
            if (num == this.class10_settings_0.int_21)
            {
                MessageBox.Show(Form.ActiveForm, "Error resetting VendorID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.LogThis("Error resetting VendorID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings");
                return false;
            }
            try
            {
                this.method_50(this.byte_1, 0, 11);
                this.method_47(0x1388);
                byte ReceivedByte = this.method_52();
                this.DiscardBuffer();
                if (ReceivedByte != 0x4f)
                {
                    num++;
                    goto Label_0071;
                }

                //recheck
                this.GetSerial();
                if (Vendor_ID != ThisVendor)
                {
                    MessageBox.Show(Form.ActiveForm, "Error resetting VendorID!" + Environment.NewLine + "The Vendor not match after being resetted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.LogThis("Error resetting VendorID!" + Environment.NewLine + "The Vendor not match after being resetted");
                    return false;
                }
                return true;
            }
            catch
            {
                num++;
                goto Label_0071;
            }
        }
        return false;
    }

    public bool ResetVendor(bool Ostrich)
    {
        int num = 0;
        this.GetSerial();

        //Reset only if vendor ID doesnt match
        if ((Ostrich && Vendor_ID != 0) || (!Ostrich && Vendor_ID != 1))
        {

            this.byte_1 = new byte[11];
            this.byte_2 = new byte[1];
            this.byte_1[0] = 0x4e;
            if (Ostrich) this.byte_1[1] = 0;
            else this.byte_1[1] = 1;

            for (int i = 0; i < 8; i++) this.byte_1[2 + i] = this.Serial_ID[i];
            this.byte_1[10] = this.method_46(this.byte_1, 0, 10);
        Label_0071:
            if (num == this.class10_settings_0.int_21)
            {
                MessageBox.Show(Form.ActiveForm, "Error resetting VendorID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.LogThis("Error resetting VendorID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings");
                return false;
            }
            try
            {
                this.method_50(this.byte_1, 0, 11);
                this.method_47(0x1388);
                byte ReceivedByte = this.method_52();
                this.DiscardBuffer();
                if (ReceivedByte != 0x4f)
                {
                    num++;
                    goto Label_0071;
                }

                //recheck
                this.GetSerial();
                if ((Ostrich && Vendor_ID != 0) || (!Ostrich && Vendor_ID != 1))
                {
                    MessageBox.Show(Form.ActiveForm, "Error resetting VendorID!" + Environment.NewLine + "The Vendor not match after being resetted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.LogThis("Error resetting VendorID!" + Environment.NewLine + "The Vendor not match after being resetted");
                    return false;
                }
                return true;
            }
            catch
            {
                num++;
                goto Label_0071;
            }
        }
        return false;
    }

    public bool ResetSerial(byte[] NewSerialID)
    {
        int num = 0;
        this.GetSerial();

        //Reset only if vendor ID doesnt match
        if (Serial_ID[0] != NewSerialID[0]
            && Serial_ID[1] != NewSerialID[1]
            && Serial_ID[2] != NewSerialID[2]
            && Serial_ID[3] != NewSerialID[3]
            && Serial_ID[4] != NewSerialID[4]
            && Serial_ID[5] != NewSerialID[5]
            && Serial_ID[6] != NewSerialID[6]
            && Serial_ID[7] != NewSerialID[7])
        {
            this.byte_1 = new byte[11];
            this.byte_2 = new byte[1];
            this.byte_1[0] = 0x4e;
            this.byte_1[1] = (byte) Vendor_ID;

            for (int i = 0; i < 8; i++) this.byte_1[2 + i] = NewSerialID[i];
            this.byte_1[10] = this.method_46(this.byte_1, 0, 10);
        Label_0071:
            this.DiscardBuffer();
            if (num == this.class10_settings_0.int_21)
            {
                MessageBox.Show(Form.ActiveForm, "Error resetting SerialID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.LogThis("Error resetting SerialID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings");
                return false;
            }
            try
            {
                this.method_50(this.byte_1, 0, 11);
                this.method_47(0x1388);
                byte ReceivedByte = this.method_52();
                this.DiscardBuffer();
                if (ReceivedByte != 0x4f)
                {
                    num++;
                    goto Label_0071;
                }

                //recheck
                this.GetSerial();
                if (Serial_ID[0] != NewSerialID[0]
                    && Serial_ID[1] != NewSerialID[1]
                    && Serial_ID[2] != NewSerialID[2]
                    && Serial_ID[3] != NewSerialID[3]
                    && Serial_ID[4] != NewSerialID[4]
                    && Serial_ID[5] != NewSerialID[5]
                    && Serial_ID[6] != NewSerialID[6]
                    && Serial_ID[7] != NewSerialID[7])
                {
                    MessageBox.Show(Form.ActiveForm, "Error resetting SerialID!" + Environment.NewLine + "The Serial not match after being resetted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.LogThis("Error resetting SerialID!" + Environment.NewLine + "The Serial not match after being resetted");
                    return false;
                }
                return true;
            }
            catch
            {
                num++;
                goto Label_0071;
            }
        }
        return false;
    }

    public void CheckResetSerial()
    {
        if (GetConnected())
        {
            if (this.class10_settings_0.chkEmuVendor)
            {
                GetSerial();
                if (((this.Vendor_ID != 1) && (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)) && (MessageBox.Show(Form.ActiveForm, "Demon VendorID is not set to BMTune. Do you want to set it to BMTune?" + Environment.NewLine + "This will remove all data from demon!", "BMTune", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    this.ResetVendor(false);
                    if (this.GetConnected())
                    {
                        this.method_1(false);
                    }
                    return;
                }

                if ((this.emulatorMoatesType_0 != EmulatorMoatesType.ostrich_1) || (this.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_1 && this.int_2 >= 15))
                {
                    if (((this.Vendor_ID != 0) && (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Ostrich)) && (MessageBox.Show(Form.ActiveForm, "Ostrich VendorID is not set to BMTune. Do you want to set it to BMTune?" + Environment.NewLine + "This will remove all data from ostrich!", "BMTune", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        this.ResetVendor(true);
                        if (this.GetConnected())
                        {
                            this.method_1(false);
                        }
                        return;
                    }
                }
            }
        }
    }

    public void GetSerial()
    {
        if ((this.emulatorMoatesType_0 != EmulatorMoatesType.ostrich_1) || (this.emulatorMoatesType_0 == EmulatorMoatesType.ostrich_1 && this.int_2 >= 15))
        {
            int num = 0;
            this.byte_1 = new byte[3];
            this.byte_2 = new byte[10];
            this.byte_1[0] = 0x4e;
            this.byte_1[1] = 0x53;
            this.byte_1[2] = 0xa1;
        Label_0041:
            this.DiscardBuffer();
            if (num == this.class10_settings_0.int_21)
            {
                MessageBox.Show(Form.ActiveForm, "Error getting Serial/Vendor ID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.LogThis("Error getting Serial/Vendor ID after " + this.class10_settings_0.int_21.ToString() + " tries" + Environment.NewLine + "You can disable the Serial/VendorID Check in the Settings");
            }
            try
            {
                this.method_50(this.byte_1, 0, 3);
                this.Vendor_ID = this.method_52();
                for (int i = 0; i < 8; i++) this.Serial_ID[i] = this.method_52();
                byte CheckS = this.method_52();
                this.DiscardBuffer();
            }
            catch
            {
                this.Vendor_ID = 0;
                num++;
                goto Label_0041;
            }
        }
    }

    private byte[] method_35()
    {
        byte[] buffer = new byte[8];
        new Random().NextBytes(buffer);
        return buffer;
    }

    public bool EmuAutoScanStart()
    {
        this.LogThis("Auto-scan started");

        if (this.class27_EmuProgress_0 != null) this.class27_EmuProgress_0 = null;
        this.class27_EmuProgress_0 = new Class27_EmuProgress();
        this.class27_EmuProgress_0.method_0(ref this.class25_0, ref this.frmMain_0);

        /*if (this.backgroundWorker_4 != null)
        {
            if (this.backgroundWorker_4.IsBusy)
            {
                this.backgroundWorker_4.CancelAsync();
            }
            while (this.backgroundWorker_4.IsBusy)
            {
                Application.DoEvents();
            }
            this.backgroundWorker_4.Dispose();
            this.backgroundWorker_4 = null;
        }*/

        if (this.backgroundWorker_4 != null)
        {
            this.backgroundWorker_4.Dispose();
            this.backgroundWorker_4 = null;
        }

        this.backgroundWorker_4 = new BackgroundWorker();
        this.backgroundWorker_4.DoWork += new DoWorkEventHandler(this.backgroundWorker_4_DoWork);
        this.backgroundWorker_4.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_4_RunWorkerCompleted);
        //this.backgroundWorker_4.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_4_ProgressChanged);
        //this.backgroundWorker_4.WorkerReportsProgress = true;
        this.backgroundWorker_4.WorkerReportsProgress = false;
        this.backgroundWorker_4.WorkerSupportsCancellation = true;
        this.backgroundWorker_4.RunWorkerAsync();
        while (this.backgroundWorker_4.IsBusy)
        {
            Application.DoEvents();
        }

        return this.Emu_SerialConnected;
    }

    public bool IsEmulatorConnected(bool ShowError)
    {
        if (!this.class10_settings_0.bool_31)
        {
            if (this.serialPort_0 == null) return false;
            if (this.serialPort_0 != null && !this.serialPort_0.IsOpen) return false;
        }

        int num = this.class10_settings_0.int_21;
        if (!ShowError) num = 3;

        int num2 = 0;
        this.byte_1 = new byte[5];
        this.byte_2 = new byte[3];
        //if (this.serialPort_0 != null) this.LogThis("Baud: " + this.serialPort_0.BaudRate.ToString());

    Label_008A:
        this.DiscardBuffer();
        if (num2 == num)
        {
            if (!this.class10_settings_0.bool_31)
            {
                this.LogThis("Can't dectect '" + this.class10_settings_0.emulatorMode_0.ToString() + "' on " + this.serialPort_0.PortName);
                if (ShowError) MessageBox.Show(Form.ActiveForm, "Can't dectect '" + this.class10_settings_0.emulatorMode_0.ToString() + "' on " + this.serialPort_0.PortName + "" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            goto Label_10B9;
        }
        switch (this.class10_settings_0.emulatorMode_0)
        {

            case EmulatorMode.PGMFI_RTP:
                if (this.serialPort_0.BaudRate != 38400) this.LogThis("The baudrate is not compatible for the PGMFI RTP" + Environment.NewLine + "Please set baudrate to 38400");
                try
                {
                    this.method_49(0x10);
                    byte num3 = this.method_52();
                    if (num3 == 0xcd)
                    {
                        if (!this.Emu_Connected) this.LogThis("PGMFI RTP Connected");
                        return true;
                    }
                    this.LogThis("Bad reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", num3) + " (Expected: " + string.Format("{0:X2}", 0xcd) + ")");
                    num2++;
                }
                catch (Exception exception)
                {
                    this.DiscardBuffer();
                    if (num2 == 0) this.LogThis("Serial Port error:" + Environment.NewLine + "" + exception.Message);
                    num2++;
                }
                goto Label_008A;

            case EmulatorMode.Ostrich:
                if ((this.serialPort_0.BaudRate != 921600) && (this.serialPort_0.BaudRate != 115200)) this.LogThis("The baudrate is not compatible for the Ostrich" + Environment.NewLine + "Please set baudrate to 115200 or 921600");
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.method_50(this.byte_1, 0, 2);
                    for (int i = 0; i < 3; i++) this.byte_2[i] = this.method_52();
                }
                catch (Exception exception2)
                {
                    
                    this.DiscardBuffer();
                    if (num2 == 0) this.LogThis("Serial Port error:" + Environment.NewLine + "" + exception2.Message);

                    /*if (num2 == 0) this.LogThis("Changing emulator baudrate due to serial errors");
                    this.byte_1 = new byte[3];
                    this.byte_1[0] = 0x53;      //S
                    if (this.serialPort_0.BaudRate == 115200)
                    {
                        this.byte_1[1] = 7;     //7 = set to 115220
                        this.byte_1[2] = 90;    //Checksum
                    }
                    else if (this.serialPort_0.BaudRate == 921600)
                    {
                        try
                        {
                            this.serialPort_0.Close();
                            this.serialPort_0 = new SerialPort(this.class10_settings_0.string_2, 115200);
                            this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
                            this.serialPort_0.WriteTimeout = 500;
                            this.serialPort_0.Encoding = Encoding.Default;
                            this.serialPort_0.Open();
                            this.byte_1[1] = 0;     //0 = set to 921600
                            this.byte_1[2] = 0x53;  //Checksum
                        }
                        catch (Exception exception3)
                        {
                            if (num2 == 0) this.LogThis("Serial Port error:" + Environment.NewLine + "" + exception3.Message);
                            num2++;
                            goto Label_008A;
                        }
                    }
                    try
                    {
                        this.method_50(this.byte_1, 0, 3);
                        this.byte_2[0] = this.method_52();
                        if (this.byte_2[0] == 0x4f)
                        {
                            this.serialPort_0.Close();
                            this.serialPort_0 = new SerialPort(this.class10_settings_0.string_2, this.class10_settings_0.Emulator_Baud);
                            this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
                            this.serialPort_0.WriteTimeout = 500;
                            this.serialPort_0.Encoding = Encoding.Default;
                            this.serialPort_0.Open();
                            num2 = 0;
                        }
                        else
                        {
                            if (num2 == 0) this.LogThis("Can't change emulator baudrate");
                            num2++;
                        }
                    }
                    catch
                    {
                        if (num2 == 0) this.LogThis("Can't change emulator baudrate");
                        num2++;
                    }*/
                    num2++;
                    goto Label_008A;
                }
                if (this.byte_2[2] == 0x4f)
                {
                    this.int_1 = this.byte_2[0];
                    this.string_0 = char.ConvertFromUtf32(this.byte_2[2]);
                    this.int_2 = this.byte_2[1];
                    if (this.byte_2[0] == 10)
                    {
                        if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Vitaprog)
                        {
                            if (!this.Emu_Connected) this.LogThis("Vitaprog/Hondavert (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                            this.emulatorMoatesType_0 = EmulatorMoatesType.ostrich_1;
                            this.EmulatorName = "Vitaprog/Hondavert";
                            return true;
                        }
                        else
                        {
                            if (!this.Emu_Connected) this.LogThis("Moates Ostrich1.0 (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                            this.emulatorMoatesType_0 = EmulatorMoatesType.ostrich_1;
                            this.EmulatorName = "Moates Ostrich1.0";
                        }
                    }
                    else if (this.byte_2[0] == 20 && this.byte_2[1] < 20)
                    {
                        if (!this.Emu_Connected) this.LogThis("Moates Ostrich2.0 (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                        this.emulatorMoatesType_0 = EmulatorMoatesType.ostrich_2;
                        this.EmulatorName = "Moates Ostrich2.0";
                        GetSerial();
                    }
                    else if (this.byte_2[0] == 20 && this.byte_2[1] >= 20)
                    {
                        this.class10_settings_0.emulatorMode_0 = EmulatorMode.CobraRTP;

                        if (!this.Emu_Connected) this.LogThis("CobraRTP (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                        this.EmulatorName = "CobraRTP";
                        this.emulatorMoatesType_0 = EmulatorMoatesType.ostrich_2;
                    }
                    this.byte_1 = new byte[4];
                    this.byte_2 = new byte[1];
                    this.byte_1[0] = 0x42;
                    this.byte_1[1] = 0x52;
                    this.byte_1[2] = 0x52;
                    this.byte_1[3] = 230;
                    try
                    {
                        this.method_50(this.byte_1, 0, 4);
                        this.byte_2[0] = this.method_52();
                        if (this.byte_2[0] == 0) return true;
                        if (num2 == 0) this.LogThis("Bad bank reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0) + ")");
                    }
                    catch
                    {
                        num2++;
                        goto Label_008A;
                    }
                    this.byte_1[0] = 0x42;
                    this.byte_1[1] = 0x53;
                    this.byte_1[2] = 0;
                    this.byte_1[3] = 0x95;
                    try
                    {
                        this.method_50(this.byte_1, 0, 4);
                        this.byte_2[0] = this.method_52();
                        if (this.byte_2[0] == 0x4f) return true;
                        if (num2 == 0) this.LogThis("Bad bank reset reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                        num2++;
                        goto Label_008A;
                    }
                    catch
                    {
                        num2++;
                        goto Label_008A;
                    }
                }
                if (num2 == 0) this.LogThis("Ostrich not found!" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[2]) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                num2++;
                goto Label_008A;



            //###########################################
            //###########################################
            //###########################################

            case EmulatorMode.BMulator:
                if ((this.serialPort_0.BaudRate != 921600)) this.LogThis("The baudrate is not compatible for the BMulator" + Environment.NewLine + "Please set baudrate to 921600");
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.DiscardBuffer();
                    this.method_50(this.byte_1, 0, 2);
                    for (int i = 0; i < 3; i++) this.byte_2[i] = this.method_52();
                }
                catch (Exception exception2)
                {
                    this.DiscardBuffer();
                    if (num2 == 0) this.LogThis("Serial Port error:" + Environment.NewLine + "" + exception2.Message);
                    num2++;
                    goto Label_008A;
                }
                if ((this.byte_2[0] == 10 || (this.byte_2[0] == 20 && this.byte_2[1] < 20)) && this.byte_2[2] == 0x4f)
                {
                    this.int_1 = this.byte_2[0];
                    this.string_0 = char.ConvertFromUtf32(this.byte_2[2]);
                    this.int_2 = this.byte_2[1];

                    if (!this.Emu_Connected) this.LogThis("BMulator (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                    this.emulatorMoatesType_0 = EmulatorMoatesType.ostrich_1;
                    this.EmulatorName = "BMulator";
                    return true;
                }
                if (num2 == 0) this.LogThis("BMulator not found!" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[2]) + " (Expected: 0x4F)");
                num2++;
                goto Label_008A;

            //###########################################
            //###########################################
            //###########################################

            case EmulatorMode.CobraRTP:
                if ((this.serialPort_0.BaudRate != 921600) && (this.serialPort_0.BaudRate != 115200)) this.LogThis("The baudrate is not compatible for the CobraRTP" + Environment.NewLine + "Please set baudrate to 115200 or 921600");
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.DiscardBuffer();
                    this.method_50(this.byte_1, 0, 2);
                    for (int i = 0; i < 3; i++) this.byte_2[i] = this.method_52();
                }
                catch (Exception exception2)
                {
                    this.DiscardBuffer();
                    if (num2 == 0) this.LogThis("Serial Port error:" + Environment.NewLine + "" + exception2.Message);
                    num2++;
                    goto Label_008A;
                }
                //20.9.C instead of 20.9.O   0x43 = C in ascII
                if (this.byte_2[0] == 20 && (this.byte_2[2] == 0x43 || this.byte_2[2] == 0x4f))
                {
                    this.int_1 = this.byte_2[0];
                    this.string_0 = char.ConvertFromUtf32(this.byte_2[2]);
                    this.int_2 = this.byte_2[1];

                    if (this.byte_2[1] >= 20)
                    {
                        if (!this.Emu_Connected) this.LogThis("CobraRTP (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                        this.EmulatorName = "CobraRTP";
                    }
                    else
                    {
                        if (!this.Emu_Connected) this.LogThis("Moates Ostrich2.0 (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                        this.class10_settings_0.emulatorMode_0 = EmulatorMode.Ostrich;
                        this.emulatorMoatesType_0 = EmulatorMoatesType.ostrich_2;
                        this.EmulatorName = "Moates Ostrich2.0";
                        GetSerial();
                    }

                    return true;
                }
                if (num2 == 0) this.LogThis("CobraRTP not found!" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[2]) + " (Expected: 0x43|0x4F)");
                num2++;
                goto Label_008A;

            //###########################################
            //###########################################
            //###########################################

            case EmulatorMode.ECUTamer:
                if (this.serialPort_0.BaudRate != 921600 && this.serialPort_0.BaudRate != 115200)
			    {
                    this.LogThis("The baudrate is not compatible for the ECU-Tamer" + Environment.NewLine + "Please set baudrate to 115200 or 921600");
                }
                this.byte_1 = new byte[2];
                this.byte_1[0] = 86;
                this.byte_1[1] = 86;
                try
                {
                    this.DiscardBuffer();
                    this.method_50(this.byte_1, 0, 2);
                    Thread.Sleep(10);
                    for (int n = 0; n < 3; n++) this.byte_2[n] = this.method_52();
                }
                catch (Exception ex8)
                {
                    this.DiscardBuffer();
                    if (num2 == 0)
                    {
                        this.LogThis("Serial Port error:" + Environment.NewLine + "" + ex8.Message);
                    }
                    num2++;
                    goto Label_008A;
                }
                if (this.byte_2[2] == 79)
                {
                    this.int_1 = (int)this.byte_2[0];
                    this.string_0 = char.ConvertFromUtf32((int)this.byte_2[2]);
                    this.int_2 = (int)this.byte_2[1];

                    this.LogThis("ECU-Tamer (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                    this.EmulatorName = "ECU-Tamer";
                    return true;
                }
                if (num2 == 0) this.LogThis("ECU-Tamer not found!" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[2]) + " (Expected: " + string.Format("{0:X2}", 67) + ")");
                num2++;
                goto Label_008A;

            //###########################################
            //###########################################
            //###########################################

            case EmulatorMode.Vitaprog:
                if ((this.serialPort_0.BaudRate != 115200)) this.LogThis("The baudrate is not compatible for the Vitaprog/Hondavert" + Environment.NewLine + "Please set baudrate to 115200");
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.DiscardBuffer();
                    this.method_50(this.byte_1, 0, 2);
                    for (int i = 0; i < 3; i++) this.byte_2[i] = this.method_52();
                }
                catch (Exception exception2)
                {
                    this.DiscardBuffer();
                    if (num2 == 0) this.LogThis("Serial Port error:" + Environment.NewLine + "" + exception2.Message);
                    num2++;
                    goto Label_008A;
                }
                //20.9.C instead of 20.9.O   0x43 = C in ascII
                if (this.byte_2[0] == 10 && this.byte_2[2] == 0x4f)
                {
                    this.int_1 = this.byte_2[0];
                    this.string_0 = char.ConvertFromUtf32(this.byte_2[2]);
                    this.int_2 = this.byte_2[1];



                    if (!this.Emu_Connected) this.LogThis("Vitaprog/Hondavert (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                    this.emulatorMoatesType_0 = EmulatorMoatesType.ostrich_1;
                    this.EmulatorName = "Vitaprog/Hondavert";
                    return true;
                }
                if (num2 == 0) this.LogThis("Vitaprog/Hondavert not found!" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[2]) + " (Expected: 0x4F)");
                num2++;
                goto Label_008A;

            //###########################################
            //###########################################
            //###########################################

            case EmulatorMode.ROMulator:
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.method_50(this.byte_1, 0, 2);
                    for (int j = 0; j < 3; j++)
                    {
                        this.byte_2[j] = this.method_52();
                    }
                }
                catch (Exception exception5)
                {
                    this.DiscardBuffer();
                    if (num2 == 0) this.LogThis("Serial Port error:" + Environment.NewLine + "" + exception5.Message);
                    num2++;
                    goto Label_008A;
                }
                if ((this.byte_2[2] != 0x31) && (this.byte_2[2] != 50))
                {
                    if (num2 == 0) this.LogThis("Romulator not found!" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[2]) + " (Expected: " + string.Format("{0:X2}", 0x31) + "|"  + string.Format("{0:X2}", 50) + ")");
                    num2++;
                    goto Label_008A;
                }
                if (!this.Emu_Connected) this.LogThis("Romulator Connected");
                return true;

            case EmulatorMode.Demon:
                //if ((this.serialPort_0.BaudRate != 921600) && (this.serialPort_0.BaudRate != 115200)) this.LogThis("The baudrate is not compatible for the Demon" + Environment.NewLine + "Please set baudrate to 115200 or 921600");
                this.byte_1 = new byte[2];
                this.byte_1[0] = 0x56;
                this.byte_1[1] = 0x56;
                try
                {
                    this.method_50(this.byte_1, 0, 2);
                    for (int n = 0; n < 3; n++)
                    {
                        this.byte_2[n] = this.method_52();
                    }
                }
                catch (Exception exception7)
                {
                    if (num2 == 0) this.LogThis("Demon not found. Port error:" + Environment.NewLine + "" + exception7.Message);
                    num2++;
                    goto Label_008A;
                }
                if (this.byte_2[2] != 0x44 && this.byte_2[2] != 0x43)
                {
                    if (num2 == 0) this.LogThis("Demon not found!" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[2]) + " (Expected: " + string.Format("{0:X2}", 0x44) + ")");
                    num2++;
                    goto Label_008A;
                }
                this.int_1 = this.byte_2[0];
                this.string_0 = char.ConvertFromUtf32(this.byte_2[2]);
                this.int_2 = this.byte_2[1];
                if (!this.Emu_Connected)
                {
                    if (this.byte_2[2] != 0x43)
                    {
                        this.emulatorMoatesType_0 = EmulatorMoatesType.demon;
                        //this.class10_0.dataloggingMode_0 = DataloggingMode.datalogDemon;
                        //this.class10_0.IsNeptuneRTP = false;
                        if (this.byte_2[0] == 1)
                        {
                            this.LogThis("Moates Demon1 (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                            this.EmulatorName = "Moates Demon1";
                            //GetSerial();
                        }
                        else if (this.byte_2[0] == 2)
                        {
                            this.LogThis("Moates Demon2 (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                            this.EmulatorName = "Moates Demon2";
                            GetSerial();
                        }
                    }
                    else
                    {
                        this.LogThis("NeptuneRTP (V" + this.int_1 + "." + this.int_2 + "." + this.string_0 + ")");
                        this.LogThis("NeptuneRTP found");
                        this.EmulatorName = "NeptuneRTP";
                        this.emulatorMoatesType_0 = EmulatorMoatesType.neptuneRTP;
                        //this.class10_0.dataloggingMode_0 = DataloggingMode.datalogMultiByteT;
                        //this.class10_0.IsNeptuneRTP = true;
                        this.byte_1 = new byte[4];
                        this.byte_2 = new byte[1];
                        return true;
                    }
                }
                this.byte_1 = new byte[4];
                this.byte_2 = new byte[1];
                break;

            default:
                return false;
        }
    Label_0B58:
        if (num2 == num)
        {
            this.LogThis("Can't dectect '" + this.class10_settings_0.emulatorMode_0.ToString() + "' on " + this.serialPort_0.PortName);
            if (ShowError) MessageBox.Show(Form.ActiveForm, "Can't dectect '" + this.class10_settings_0.emulatorMode_0.ToString() + "' on " + this.serialPort_0.PortName + "" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            goto Label_10B9;
        }
    Label_0BEB:
        if (this.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP) return true;
        this.byte_1 = new byte[4];
        this.byte_1[0] = 0x42;
        this.byte_1[1] = 0x52;
        this.byte_1[2] = 0x52;
        this.byte_1[3] = 230;
        try
        {
            this.method_50(this.byte_1, 0, 4);
            this.byte_2[0] = this.method_52();
            if (this.byte_2[0] == 0)  goto Label_0D25;
            this.LogThis("Bad bank reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0) + ")");
        }
        catch
        {
            num2++;
            goto Label_008A;
        }
        this.byte_1[0] = 0x42;
        this.byte_1[1] = 0x52;
        this.byte_1[2] = 0;
        this.byte_1[3] = 0x87;
        try
        {
            this.method_50(this.byte_1, 0, 4);
            this.byte_2[0] = this.method_52();
            if (this.byte_2[0] == 0x4f) goto Label_0BEB;
            this.LogThis("Bad bank reset reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
            num2++;
            goto Label_0B58;
        }
        catch
        {
            num2++;
            goto Label_008A;
        }
    Label_0D25:
        this.byte_1 = new byte[4];
        this.byte_1[0] = 0x42;
        this.byte_1[1] = 0x45;
        this.byte_1[2] = 0x52;
        this.byte_1[3] = 0xd9;
        try
        {
            this.method_50(this.byte_1, 0, 4);
            this.byte_2[0] = this.method_52();
            if (this.byte_2[0] == 0x63)
            {
                this.LogThis("Bad bank reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 1) + ")");
                num2++;
                goto Label_0B58;
            }
            if (this.byte_2[0] == 1) goto Label_0ECC;
            num2++;
            this.LogThis("Bad bank reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 1) + ")");
        }
        catch
        {
            num2++;
            goto Label_008A;
        }
        this.byte_1[0] = 0x42;
        this.byte_1[1] = 0x53;
        this.byte_1[2] = 1;
        this.byte_1[3] = 150;
        try
        {
            this.method_50(this.byte_1, 0, 4);
            this.byte_2[0] = this.method_52();
            if (this.byte_2[0] == 0x63)
            {
                this.LogThis("Bad bank reset reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                num2++;
            }
            else if(this.byte_2[0] != 0x4f)
            {
                this.LogThis("Bad bank reset reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                num2++;
            }
            goto Label_0B58;
        }
        catch
        {
            num2++;
            goto Label_008A;
        }
    Label_0ECC:
        this.byte_1 = new byte[4];
        this.byte_1[0] = 0x42;
        this.byte_1[1] = 0x45;
        this.byte_1[2] = 0x53;
        this.byte_1[3] = 0xda;
        try
        {
            this.method_50(this.byte_1, 0, 4);
            this.byte_2[0] = this.method_52();
            if (this.byte_2[0] == 0x63)
            {
                this.LogThis("Bad bank reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 1) + ")");
                num2++;
                goto Label_0B58;
            }
            if (this.byte_2[0] == 1)
            {
                this.LogThis("Demon found");
                return true;
            }
            num2++;
            this.LogThis("Bad bank reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 1) + ")");
        }
        catch
        {
            num2++;
            goto Label_008A;
        }
        this.byte_1[0] = 0x42;
        this.byte_1[1] = 0x45;
        this.byte_1[2] = 1;
        this.byte_1[3] = 0x88;
        try
        {
            this.method_50(this.byte_1, 0, 4);
            this.byte_2[0] = this.method_52();
            if (this.byte_2[0] == 0x63)
            {
                this.LogThis("Bad bank reset reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                num2++;
            }
            else if (this.byte_2[0] != 0x4f)
            {
                this.LogThis("Bad bank reset reply" + "" + Environment.NewLine + "Reply is: " + string.Format("{0:X2}", this.byte_2[0]) + " (Expected: " + string.Format("{0:X2}", 0x4f) + ")");
                num2++;
            }
            goto Label_0B58;
        }
        catch
        {
            num2++;
            goto Label_008A;
        }
    Label_10B9:
        return false;
    }

    /*public void ChangeBaudrate(int ThisBaud)
    {
        EmulatorDisconnect();

        this.LogThis("Changing emulator baudrate on " + this.class10_0.string_2);
        this.byte_1 = new byte[5];
        this.byte_2 = new byte[3];

        this.byte_1[0] = 0x53;      //S
        if (ThisBaud == 115200)
        {
            this.byte_1[1] = 7;     //7 = set to 115220
            this.byte_1[2] = 90;    //Checksum
            this.serialPort_0 = new SerialPort(this.class10_0.string_2, 921600);
        }
        else if(ThisBaud == 921600)
        {
            this.byte_1[1] = 0;     //0 = set to 921600
            this.byte_1[2] = 0x53;  //Checksum
            this.serialPort_0 = new SerialPort(this.class10_0.string_2, 115200);
        }

        this.serialPort_0.ReadTimeout = this.class10_0.int_20;
        this.serialPort_0.WriteTimeout = 500;
        this.serialPort_0.Encoding = Encoding.Default;

        try
        {
            this.serialPort_0.Open();
            this.method_50(this.byte_1, 0, 3);
            this.byte_2[0] = this.method_52();
        }
        catch { }

        if (this.byte_2[0] != 0x4f) this.LogThis("Can't change emulator baudrate on " + this.class10_0.string_2);
        else
        {
            this.LogThis("Emulator baudrate changed successfully on " + this.class10_0.string_2);
            this.class10_0.Emulator_Baud = ThisBaud;
        }
        EmulatorDisconnect();
    }*/

    public void EmulatorDisconnect()
    {
        this.SetConnected(false);
        if (!this.class10_settings_0.bool_31 && (this.serialPort_0 != null))
        {
            try
            {
                if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen)
                {
                    if (this.serialPort_0.IsOpen)
                    {
                        this.serialPort_0.Close();
                    }
                    this.serialPort_0.Dispose();
                    this.serialPort_0 = null;
                }
            }
            catch { }
            return;
        }
        if (this.class10_settings_0.bool_31)
        {
            if (!this.class17_0.method_34_GetConnected()) this.class17_0.method_20();
            return;
        }
    }

    private byte method_40()
    {
        return this.byte_3;
    }

    private void method_41()
    {
        this.byte_3 = 0;
    }

    private void method_42(byte byte_8)
    {
        this.byte_3 = (byte) (this.byte_3 + byte_8);
    }

    private void method_43(byte[] byte_8, int int_4)
    {
        this.byte_3 = 0;
        for (int i = 0; i < int_4; i++)
        {
            this.byte_3 = (byte) (this.byte_3 + byte_8[i]);
        }
    }

    private void method_44(byte[] byte_8, int int_4, int int_5)
    {
        for (int i = 0; i < int_5; i++)
        {
            this.byte_0[int_4 + i] = byte_8[i];
        }
    }

    private byte method_45()
    {
        byte num;
        try
        {
            this.method_49(6);
            num = this.method_52();
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return num;
    }

    private byte method_46(byte[] byte_8, int int_4, int int_5)
    {
        byte num = 0;
        for (int i = 0; i < int_5; i++)
        {
            num = (byte) (num + byte_8[i]);
        }
        return num;
    }

    private void method_47(int int_4)
    {
        if (this.class10_settings_0.bool_31)
        {
            if (this.method_10() && this.class17_0.method_34_GetConnected())
            {
                this.class17_0.method_22(true);
                while (!this.class17_0.method_21())
                {
                    Application.DoEvents();
                    this.class17_0.method_22(true);
                }
            }
            this.class17_0.method_10(int_4);
        }
        else
        {
            this.serialPort_0.ReadTimeout = int_4;
            this.serialPort_0.WriteTimeout = 500;
        }
    }

    private void method_49(byte byte_8)
    {
        if (this.class10_settings_0.bool_31)
        {
            if (this.method_10() && this.class17_0.method_34_GetConnected())
            {
                this.class17_0.method_22(true);
                while (!this.class17_0.method_21())
                {
                    Application.DoEvents();
                    this.class17_0.method_22(true);
                }
            }
            this.class17_0.method_14(byte_8);
        }
        else
        {
            this.serialPort_0.Write(((char) byte_8).ToString());
        }
    }

    public bool method_5()
    {
        if (this.class10_settings_0.bool_31)
        {
            if (!this.class17_0.method_17())
            {
                try
                {
                    this.LogThis("Opening datalog port");
                    if (this.class17_0.method_19(true)) this.SetConnected(true);
                }
                catch (Exception)
                {
                    this.LogThis("Can't open port: " + this.class10_settings_0.string_2);
                    if (this.Report_Error) MessageBox.Show(Form.ActiveForm, "Can't open port: " + this.class10_settings_0.string_2 + "" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.SetConnected(false);
                    return false;
                }
            }
            this.LogThis("Datalog port open: " + this.class17_0.method_17().ToString());
            this.SetConnected(this.class17_0.method_17());
            return this.class17_0.method_17();
        }
        //########################################################################
        if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen)
        {
            LogThis("port: " + this.class10_settings_0.string_2.ToString() + " is already open!");
            LogThis("Closing port: " + this.class10_settings_0.string_2.ToString());
            EmulatorDisconnect();
            //this.SetConnected(true);
            //return true;
        }

        if (!this.class10_settings_0.Emu_AutoScan)
        {
            bool DeviceConnected = TestConnect(this.class10_settings_0.string_2, this.class10_settings_0.Emulator_Baud);
            this.SetConnected(DeviceConnected);
            return DeviceConnected;
        }
        else
        {
            this.serialPort_0 = new SerialPort(this.class10_settings_0.string_2, this.class10_settings_0.Emulator_Baud);
            this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
            this.serialPort_0.WriteTimeout = 500;
            this.serialPort_0.ReadBufferSize = 0x1100;
            this.serialPort_0.Encoding = Encoding.Default;
            try
            {
                this.serialPort_0.Open();
                //this.LogThis("------------------------------");
                //this.LogThis("Port open: " + this.class10_0.string_2 + " (Baud:" + this.class10_0.Emulator_Baud + ")");
                this.SetConnected(true);
                return true;
            }
            catch
            {
                this.LogThis("Can't open port: " + this.class10_settings_0.string_2);
                if (this.Report_Error) MessageBox.Show(Form.ActiveForm, "Can't open port:" + this.class10_settings_0.string_2 + "" + Environment.NewLine + "See the debug logs for the issue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.SetConnected(false);
                return false;
            }
        }
    }

    private void method_50(byte[] byte_8, int int_4, int int_5)
    {
        if (this.class10_settings_0.bool_31)
        {
            if (this.method_10() && this.class17_0.method_34_GetConnected())
            {
                this.class17_0.method_22(true);
                while (!this.class17_0.method_21())
                {
                    Application.DoEvents();
                    this.class17_0.method_22(true);
                }
            }
            this.class17_0.method_16(byte_8, int_4, int_5);
        }
        else
        {
            this.serialPort_0.Write(byte_8, int_4, int_5);
        }
    }

    /*private void method_51(string string_1)
    {
        if (this.class10_settings_0.bool_31)
        {
            this.class18_0.class17_0.frmMain_0.LogThis("string sp.write with link emulation");
            //throw new Exception("string sp.write with link emulation");
        }
        this.serialPort_0.Write(string_1);
    }*/

    private byte method_52()
    {
        if (!this.class10_settings_0.bool_31)
        {
            return (byte) this.serialPort_0.ReadByte();
        }
        if (this.method_10() && this.class17_0.method_34_GetConnected())
        {
            this.class17_0.method_22(true);
            while (!this.class17_0.method_21())
            {
                Application.DoEvents();
                this.class17_0.method_22(true);
            }
        }
        return this.class17_0.method_7();
    }

    private void DiscardBuffer()
    {
        try
        {
            if (this.class10_settings_0.bool_31)
            {
                this.class17_0.DiscardBuffer();
            }
            else
            {
                try
                {
                    this.serialPort_0.DiscardInBuffer();
                    this.serialPort_0.DiscardOutBuffer();
                }
                catch
                {
                    this.class18_0.class17_0.frmMain_0.LogThis("Emulator SP.Discard failed");
                    //throw new Exception("Emulator SP.Discard failed");
                }
            }
        }
        catch { }
    }

    private void method_54(byte[] byte_8, int int_4)
    {
        if (this.class10_settings_0.bool_31)
        {
            if (this.method_10() && this.class17_0.method_34_GetConnected())
            {
                this.class17_0.method_22(true);
                while (!this.class17_0.method_21())
                {
                    Application.DoEvents();
                    this.class17_0.method_22(true);
                }
            }
            this.class17_0.method_11(byte_8, int_4);
        }
        else
        {
            this.method_15(int_4);
            this.serialPort_0.Read(byte_8, 0, int_4);
        }
    }

    private void LogThis(string string_1)
    {
        frmMain_0.LogThis("Emulator - " + string_1);
    }

    public bool GetConnected()
    {
        return this.Emu_Connected;
    }

    public void SetConnected(bool bool_11)
    {
        //this.Emu_SerialConnected = bool_11;
        this.Emu_Connected = bool_11;
        if (this.Emu_Connected)
        {
            this.method_14(EmulatorState.Connected);
        }
        else
        {
            this.method_14(EmulatorState.Disconnected);
        }
    }

    private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (!this.bool_9)
        {
            if (this.queue_0 == null)
            {
                this.timer_0.Stop();
            }
            else if (((this.queue_0.Count > 0) && this.class10_settings_0.bool_32) && !this.bool_9)
            {
                this.timer_0.Stop();
                if (this.backgroundWorker_2 == null)
                {
                    //if (this.class27_0 != null) this.class27_0 = null;
                    //this.class27_0 = new Class27_EmuProgress();
                    //this.class27_0.method_0(ref this.class25_0, ref this.frmMain_0);

                    this.backgroundWorker_2 = new BackgroundWorker();
                    this.backgroundWorker_2.WorkerReportsProgress = false;
                    this.backgroundWorker_2.WorkerSupportsCancellation = true;
                    this.backgroundWorker_2.DoWork += new DoWorkEventHandler(this.backgroundWorker_2_DoWork);
                    this.backgroundWorker_2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_2_RunWorkerCompleted);
                    //this.backgroundWorker_2.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_2_ProgressChanged);
                }
                if (!this.backgroundWorker_2.IsBusy && !this.method_11())
                {
                    this.method_12(true);
                    if (this.method_10() && this.class17_0.method_34_GetConnected())
                    {
                        this.class17_0.method_22(true);
                        while (!this.class17_0.method_21())
                        {
                            Application.DoEvents();
                            this.class17_0.method_22(true);
                        }
                    }
                    this.byte_1 = new byte[6];
                    this.backgroundWorker_2.RunWorkerAsync();
                }
            }
        }
    }

    private void timer_1_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (!this.class10_settings_0.bool_31)
        {
            this.timer_1.Stop();
            //if (!this.class10_settings_0.IsBluetooth)
            //{
                string[] portNames = SerialPort.GetPortNames();
                bool flag = false;
                for (int i = 0; i < portNames.Length; i++)
                {
                    if ((this.serialPort_0 != null) && (this.serialPort_0.PortName == portNames[i]))
                    {
                        this.timer_1.Start();
                        return;
                    }
                }
                if (!flag)
                {
                    try
                    {
                        if (this.serialPort_0 != null) this.serialPort_0.Close();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        this.EmulatorDisconnect();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    this.LogThis("USB might be disconnected!");
                }
            //}
        }
    }

    private void timer_2_Tick(object sender, EventArgs e)
    {
        this.bool_10 = true;
    }

    public delegate void Delegate65(EmulatorState emulatorState_0, int int_0, bool Emu_Connected);

    public delegate void Delegate66(int int_0);

    private delegate void Delegate67();
}

