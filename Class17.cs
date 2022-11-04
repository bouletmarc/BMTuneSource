using Data;
//using PropertiesRes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

internal class Class17
{
    private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();
    private BackgroundWorker backgroundWorker_1 = new BackgroundWorker();
    private BackgroundWorker backgroundWorker_2;
    private BinaryReader binaryReader_0;
    private bool bool_0;
    private bool bool_1;
    private bool IsUSBConnected = true;
    private bool bool_11;
    private bool bool_12;
    private bool bool_13;
    private bool bool_15 = true;
    private bool bool_16;
    private bool bool_17;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7 = false;
    private bool bool_71;
    private bool bool_72;
    private bool bool_8;
    private bool bool_9;
    private byte byte_0;
    private Class10_settings class10_settings_0;
    private Class18 class18_0;
    internal Class33_Sensors class33_Sensors;
    internal Class2_serialWB class2_serialWB_0;
    private Class25 class25_0;
    private DataloggingState dataloggingState_0 = DataloggingState.Disconnected;
    private DataloggingState dataloggingState_1;
    internal Enum10 enum10_0;
    internal Enum9 enum9_0;
    private FileStream fileStream_0;
    public FrmMain frmMain_0;
    private int int_0;
    private int int_1;
    private int int_2;
    private List<Struct12> list_0;
    internal List<Struct22> list_1 = new List<Struct22>();
    private long long_0;
    public long long_1;
    private long long_2;
    private long long_3;
    private long long_4;
    private Queue<Struct12> queue_0 = new Queue<Struct12>();
    public SerialPort serialPort_0;
    private Stopwatch stopwatch_0 = new Stopwatch();
    private Stopwatch stopwatch_1 = new Stopwatch();
    private Stopwatch stopwatch_2 = new Stopwatch();
    private string string_0 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\~tmp.bml";
    private string string_1 = string.Empty;
    public string string_2;
    private Struct12 struct12_0 = new Struct12();
    private Struct17 struct17_0 = new Struct17();
    private Struct20 struct20_0 = new Struct20();
    private Struct23 struct23_0 = new Struct23();
    private Thread thread_0;
    private Thread thread_1;
    private Thread thread_2;
    private System.Timers.Timer timer_0 = new System.Timers.Timer(10.0);
    private System.Timers.Timer timer_1 = new System.Timers.Timer(100.0);
    private System.Windows.Forms.Timer timer_2;
    private long FrameCounts = 0;
    private int ConnectRetry = 0;

    private DateTime LastCheck = DateTime.Now;
    private bool FakeDatalog = false;
    public bool TryingtoConnect = false;

    public event Delegate46 delegate46_0;
    public event Delegate54 delegate54_0;
    public event Delegate50 delegate50_0;
    public event Delegate48 delegate48_0;
    public event Delegate49 delegate49_0;
    public event Delegate47 delegate47_0;
    public event Delegate45 delegate45_0;
    public event Delegate53 delegate53_0;       //event only running on datalog log file loading

    internal Class17()      //refer to Class11 in HTS
    {
        this.backgroundWorker_0.WorkerSupportsCancellation = true;
        this.backgroundWorker_0.WorkerReportsProgress = false;
        this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
        this.backgroundWorker_1.WorkerReportsProgress = false;
        this.backgroundWorker_1.WorkerSupportsCancellation = true;
        this.backgroundWorker_1.DoWork += new DoWorkEventHandler(this.backgroundWorker_1_DoWork);
        this.backgroundWorker_1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_1_RunWorkerCompleted);
        this.timer_0.Elapsed += new ElapsedEventHandler(this.timer_0_Elapsed);
        this.timer_1.Elapsed += new ElapsedEventHandler(this.timer_1_Elapsed);
        Control.CheckForIllegalCrossThreadCalls = false;
        SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(this.method_6);
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        if (!FakeDatalog)
        {
            try
            {
                this.method_18();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(Form.ActiveForm, "Can't open port:" + this.class10_settings_0.string_1, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto Label_0C1E;
            }
        }
        int num = 0x33;     //<- 51 to 56
        int num2 = 0x10;
        int num3 = 0x19;
        byte[] buffer_0 = new byte[num + 1];
        int num4 = 0;
        this.long_1 = 0L;
        /*if (!this.method_28())
        {
            goto Label_0C1E;
        }*/
        if (this.class10_settings_0.bool_25) //WidebandSerialInput
        {
            try
            {
                if (!this.class2_serialWB_0.method_2())
                {
                    goto Label_0C1E;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Form.ActiveForm, exception.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto Label_0C1E;
            }
        }
        this.method_35(true);   //set connected
        if (this.class10_settings_0.bool_8 || this.method_23())
        {
            this.method_4(DataloggingState.Recording);
        }

    //############
    Label_00F3:
        if (this.serialPort_0 != null) this.serialPort_0.WriteTimeout = 300;
        while (this.bool_4)
        {
            //this.LogThis("in wait for emulator");
            this.DiscardBuffer();
            this.bool_3 = true;
            DataloggingState state = this.method_3();
            this.method_4(DataloggingState.Waiting);
            while (this.class25_0.method_11())
            {
                Thread.Sleep(20);
            }
            this.method_4(state);
            this.bool_4 = false;
            this.bool_3 = false;
        }
        this.int_0 = 0;
        ConnectRetry = 0;

    //############
    Label_0105:
        if (this.bool_9)
        {
            this.LogThis("Mil reset request");
            try
            {
                byte num5 = 80;
                if (this.int_0 == this.class10_settings_0.int_21)
                {
                    this.LogThis("Reset MIL Failed");
                    MessageBox.Show(Form.ActiveForm, "Reset MIL Failed", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                if (this.class10_settings_0.dataloggingMode_0 == DataloggingMode.datalogDemon)
                {
                    this.method_47();
                    this.method_48();
                    buffer_0 = new byte[4];
                    this.method_11(buffer_0, 4);
                    num5 = buffer_0[1];
                }
                else
                {
                    if (this.serialPort_0 != null)
                    {
                        this.serialPort_0.Write('P'.ToString());
                        num5 = (byte)this.serialPort_0.ReadByte();
                    }
                }
                if (num5 != 80)
                {
                    this.LogThis("Mil reset failed");
                    if (this.serialPort_0 != null) this.serialPort_0.DiscardInBuffer();
                    this.int_0++;
                    goto Label_0105;
                }
                this.LogThis("Mil reset finished");
            }
            catch (Exception)
            {
                if (this.serialPort_0 != null) this.serialPort_0.DiscardInBuffer();
                this.int_0++;
                goto Label_0105;
            }
            this.bool_9 = false;
            goto Label_00F3;
        }
        if (!this.method_28())
        {
            goto Label_0C1E;
        }
        if (this.class10_settings_0.dataloggingMode_0 == DataloggingMode.datalogDemon)
        {
            this.method_46();
        }
        this.stopwatch_1.Start();
        if ((this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogMultiByteX) && (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogMultiByteT))
        {
            goto Label_070C;
        }

    //############
    Label_027C:
        if (this.backgroundWorker_0.CancellationPending)
        {
            goto Label_0C1E;
        }
        if (this.bool_4 || this.bool_9)
        {
            goto Label_00F3;
        }
        if (this.class10_settings_0.bool_28)
        {
            this.class10_settings_0.method_10();
        }
        this.stopwatch_0.Start();
        this.stopwatch_1.Start();
        num4++;
        try
        {
            if (!FakeDatalog) this.serialPort_0.Write(this.GetDatalogCommand());
            //this.LogThis("Send datalogging command: '" + this.method_31() + "'");
            //if (this.serialPort_0 != null) this.serialPort_0.Write(this.GetDatalogCommand());
            if (this.int_0 == this.class10_settings_0.int_21)
            {
                this.LogThis("Timeout");
                this.method_4(DataloggingState.Timeout);
                this.stopwatch_0.Stop();
                this.stopwatch_1.Stop();
                while (!this.backgroundWorker_0.CancellationPending)
                {
                    try
                    {
                        if (!this.method_18() || !this.method_29(false))
                        {
                            continue;
                        }
                        this.LogThis("Timeout but found ISR");
                        bool flag = false;
                        if (this.method_50())
                        {
                            flag = true;
                            this.timer_0.Stop();
                        }
                        this.method_4(DataloggingState.Connected);
                        if (flag)
                        {
                            this.timer_0.Start();
                            this.method_4(DataloggingState.Recording);
                        }
                        num4 = 0;
                        goto Label_00F3;
                    }
                    catch (Exception exception2)
                    {
                        this.LogThis("Timeout Error " + exception2.Message);
                        continue;
                    }
                }
            }
            else
            {
                this.method_42();   //clear checksum
                int NLenght = 0;
                if (this.class10_settings_0.method_8() == DataloggingTable.tableMain) NLenght = num;
                else if (this.class10_settings_0.method_8() == DataloggingTable.tableMinimal) NLenght = num2;
                else if (this.class10_settings_0.method_8() == DataloggingTable.table3) NLenght = num3;

                //###############
                //read datalog bytes array
                if (FakeDatalog)
                {
                    buffer_0 = FakeThisDatalog(NLenght);
                }
                else
                {
                    for (int i = 0; i < NLenght; i++)
                    {
                        buffer_0[i] = this.method_7();
                        this.method_43(buffer_0[i]);  //add to cheksum
                    }
                }
                //###############

                if (!FakeDatalog)
                {
                    //compare array with checksum
                    if (this.method_7() != this.method_41())
                    {
                        this.LogThis("Bad checksum on packet");
                        if (this.serialPort_0 != null) this.serialPort_0.DiscardInBuffer();
                        goto Label_027C;
                    }
                }
                if ((buffer_0[6] == 0) && (buffer_0[7] == 0))
                {
                    this.LogThis("Received buffer is empty");
                    goto Label_027C;
                }
                this.struct12_0 = this.method_38(buffer_0);
                this.method_49(this.struct12_0);
                if (this.method_50())
                {
                    this.queue_0.Enqueue(this.struct12_0);
                }
                if ((!FakeDatalog && num4 == (this.class10_settings_0.int_25 + 1)) || (FakeDatalog && num4 == 20))
                {
                    num4 = 0;
                    this.method_40_SendBytes_Delegate();
                }
                if (!this.backgroundWorker_0.CancellationPending)
                {
                    this.long_1 += 1L;
                    goto Label_027C;
                }
            }
            goto Label_0C1E;
        }
        catch (TimeoutException)
        {
            this.LogThis("Read Timeout! (set the timeout higher in the setting to possibly avoid this issue)");
            this.int_0++;
            num4 = 0;
            if (this.serialPort_0 != null)
            {
                this.serialPort_0.DiscardOutBuffer();
                this.serialPort_0.DiscardInBuffer();
            }
            goto Label_027C;
        }
        catch (Exception exception3)
        {
            if (exception3.Message == "Innovate Connection Error detected")
            {
                MessageBox.Show(Form.ActiveForm, exception3.Message);
                goto Label_0C1E;
            }
            this.LogThis("Read Error " + exception3.Message);
            if (this.class10_settings_0.IsBluetooth)
            {
                this.int_0++;
                num4 = 0;
                if (this.serialPort_0 != null)
                {
                    if (this.serialPort_0.IsOpen)
                    {
                        this.serialPort_0.DiscardOutBuffer();
                        this.serialPort_0.DiscardInBuffer();
                    }
                }
                if (this.int_0 != this.class10_settings_0.int_21) goto Label_027C;

                //bluetooth disconnect
                this.method_4(DataloggingState.Timeout);
                /*if (!this.class10_settings_0.bool_31)
                {
                    try
                    {
                        if (this.serialPort_0 != null) this.serialPort_0.Close();
                        if (this.serialPort_0 != null) this.serialPort_0.Dispose();
                    }
                    catch { }
                    this.serialPort_0 = null;
                }
                else if (this.class10_settings_0.bool_31)
                {
                    this.class25_0.EmulatorDisconnect();
                }*/
                this.method_35(false);
                this.LogThis("Bluetooth might be unpowered!");
                //this.method_2()
                this.method_20();
                //goto Label_0C1E;
            }
            else if (!this.IsUSBConnected)
            {
                if (!this.class10_settings_0.bool_31)
                {
                    try
                    {
                        if (this.serialPort_0 != null)
                        {
                            if (this.serialPort_0.IsOpen) this.serialPort_0.Close();
                            this.serialPort_0.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                    }
                    this.serialPort_0 = null;
                }
                else if (this.class10_settings_0.bool_31)
                {
                    this.class25_0.EmulatorDisconnect();
                }
                this.timer_1.Stop();
                this.LogThis("Read Error Port unavailable");
                MessageBox.Show(Form.ActiveForm, "USB error port not available", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                //this.method_2();
                this.method_20();
            }

            //##################
            //new disconnect code
            if (this.int_0 == this.class10_settings_0.int_21)
            {
                //this.method_2();
                //this.method_20();
                goto Label_0C1E;
            }
            //######################

            this.int_0++;
            num4 = 0;
            goto Label_027C;
        }
    Label_070C:
        if (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogDemon)
        {
            goto Label_0BAF;
        }
    //Datlogging for demon 
    Label_071D: 
        if (this.backgroundWorker_0.CancellationPending)
        {
            goto Label_0C1E;
        }
        if (this.bool_4 || this.bool_9)
        {
            goto Label_00F3;
        }
        if (this.class10_settings_0.bool_28)
        {
            this.class10_settings_0.method_10();
        }
        this.stopwatch_0.Start();
        this.stopwatch_1.Start();
        num4++;
        try
        {
            buffer_0 = new byte[0x37];
            byte[] buffer2 = new byte[0x33];
            this.method_48();
            if (this.int_0 == this.class10_settings_0.int_21)
            {
                this.LogThis("Timeout");
                this.method_4(DataloggingState.Timeout);
                this.stopwatch_0.Stop();
                this.stopwatch_1.Stop();
                while (!this.backgroundWorker_0.CancellationPending)
                {
                    try
                    {
                        //this.LogThis("Timeout - Cancellation Pending");
                        if (!this.method_18())
                        {
                            continue;
                        }
                        //this.LogThis("comm open");
                        if (!this.method_29(false))
                        {
                            continue;
                        }
                        bool flag2 = false;
                        if (this.method_50())
                        {
                            flag2 = true;
                            this.timer_0.Stop();
                        }
                        this.method_4(DataloggingState.Connected);
                        if (flag2)
                        {
                            this.timer_0.Start();
                            this.method_4(DataloggingState.Recording);
                        }
                        num4 = 0;
                        goto Label_00F3;
                    }
                    catch (Exception exception4)
                    {
                        this.LogThis("Error " + exception4.Message);
                        continue;
                    }
                }
            }
            else
            {
                this.method_42();
                if (this.class10_settings_0.method_8() != DataloggingTable.tableMain)
                {
                    this.class18_0.class17_0.frmMain_0.LogThis(this.class25_0.emulatorMoatesType_0 + " does not support multi tables yet");
                    goto Label_0C1E;
                    //return;
                    //throw new Exception(this.class25_0.emulatorMoatesType_0 + " does not support multi tables yet");
                }
                this.method_11(buffer_0, 0x36);
                this.method_44(buffer_0, 0x36);
                if (this.method_7() != this.method_41())
                {
                    this.LogThis("Bad checksum on packet from " + this.class25_0.emulatorMoatesType_0); //demon
                    goto Label_071D;
                }
                if (buffer_0[1] == 0x54)
                {
                    this.LogThis("ecu to demon Read timeout!");
                    this.int_0++;
                    num4 = 0;
                    this.DiscardBuffer();
                    goto Label_071D;
                }
                for (int m = 0; m < 0x33; m++)
                {
                    buffer2[m] = buffer_0[m + 1];
                }
                this.method_42();
                this.method_44(buffer2, 0x33);
                byte num12 = buffer_0[0x34];
                if (num12 == this.method_41())
                {
                    this.struct12_0 = this.method_38(buffer2);
                }
                this.method_49(this.struct12_0);
                if (this.method_50())
                {
                    this.queue_0.Enqueue(this.struct12_0);
                }
                if (num4 == (this.class10_settings_0.int_25 + 1))
                {
                    num4 = 0;
                    this.method_40_SendBytes_Delegate();
                }
                if (!this.backgroundWorker_0.CancellationPending)
                {
                    this.long_1 += 1L;
                    goto Label_071D;
                }
            }
            goto Label_0C1E;
        }
        catch (TimeoutException)
        {
            this.LogThis(this.class25_0.emulatorMoatesType_0 + " Read Timeout (set the timeout higher in the setting to possibly avoid this issue)");
            this.int_0++;
            num4 = 0;
            this.DiscardBuffer();
            goto Label_071D;
        }
        catch (Exception exception5)
        {
            if (exception5.Message == "Innovate Connection Error detected")
            {
                MessageBox.Show(Form.ActiveForm, exception5.Message);
                goto Label_0C1E;
            }
            this.LogThis("Error " + exception5.Message);
            /*if (((exception5.Message == "Access to the port is denied.") || (exception5.Message == "The port is closed.")) || (exception5.Message == "A device attached to the system is not functioning.\r" + Environment.NewLine + ""))
            {
                this.serialPort_0 = null;
                goto Label_0C1E;
            }*/
            if (!this.IsUSBConnected)
            {
                this.serialPort_0 = null;
                //this.method_2();
                //this.method_20();
                this.LogThis("Port unavailable");
                MessageBox.Show(Form.ActiveForm, "USB port not available", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto Label_0C1E;
            }
            this.int_0++;
            num4 = 0;
            goto Label_071D;
        }
    Label_0BAF:
        this.class18_0.class17_0.frmMain_0.LogThis(this.class25_0.emulatorMoatesType_0 + " datalog protocol not selected");
        return;
    //throw new Exception(this.class25_0.emulatorMoatesType_0 + " datalog protocol not selected");
    Label_0C1E:
        if (this.class10_settings_0.bool_25 && (this.class2_serialWB_0 != null))
        {
            this.class2_serialWB_0.method_3();
        }
        if (this.timer_1.Enabled)
        {
            this.timer_1.Stop();
        }
        this.bool_3 = false;
        this.bool_4 = false;
        this.long_1 = 0L;
        this.stopwatch_1.Reset();
        this.method_20();
        this.method_51(false);
        LogThis(string_1);
    }

    private byte[] FakeThisDatalog(int num)
    {
        byte[] buffer_0 = { 0X7E, 0X8F, 0XA7, 0XF9, 0X2E, 0X2E, 0X1B, 0X03, 0X01, 0X08, 0X03, 0X00, 0X00, 0X20, 0X00, 0X04, 0X00, 0X55, 0X04, 0XAE, 0X97, 0X08, 0X6D, 0X20, 0X00, 0X82, 0X95, 0X8F, 0X82, 0X00, 0X80, 0XA6, 0X81, 0X80, 0X80, 0X97, 0X80, 0X80, 0X01, 0X00, 0X00, 0X00, 0X00, 0X00, 0X00, 0X7F, 0X3B, 0XAA, 0X00, 0XCC, 0X02, 0X23 };

        Random rnd = new Random();
        buffer_0[0] = (byte) rnd.Next(0,255);
        buffer_0[1] = (byte)rnd.Next(0, 255);
        buffer_0[5] = (byte)rnd.Next(0, 255);
        /*byte[] buffer_0 = new byte[num + 1];
        for (int i = 0; i < num; i++)
        {
            if (i == 0) buffer_0[i] = 180;
            else if (i == 1) buffer_0[i] = 90;
            else if (i == 2) buffer_0[i] = 127;
            else if (i == 4) buffer_0[i] = 20;
            else if (i == 5) buffer_0[i] = 0; //tps
            else if (i == 6) buffer_0[i] = 0xb0;    //rpm1
            else if (i == 7) buffer_0[i] = 0x04;    //rpm2
            else if (i == 8) buffer_0[i] = 65;

            else buffer_0[i] = this.method_7();
            this.method_43(buffer_0[i]);
        }*/
        return buffer_0;
    }

    private void backgroundWorker_1_DoWork(object sender, DoWorkEventArgs e)
    {
        while ((this.queue_0.Count != 0) && !this.backgroundWorker_1.CancellationPending)
        {
            this.method_52(this.queue_0.Dequeue());
        }
    }

    private void backgroundWorker_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.timer_0.Start();
    }

    public void SetDemonDatalogCheck(bool bool_16_0)
    {
        this.bool_16 = bool_16_0;
    }

    private void backgroundWorker_2_DoWork(object sender, DoWorkEventArgs e)
    {
        if ((this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogDemon) || !this.class10_settings_0.bool_31)
        {
            goto Label_0500;
        }

        //###################################################################################
        //###################################################################################
        //###################################################################################
        //Section for Demon Datalogging!! trying on cached port!
        if (this.method_34_GetConnected())
        {
            this.bool_11 = true;
            return;
        }
        LogThis(this.class25_0.emulatorMoatesType_0 + " detection started");
        if ((this.class10_settings_0.Datalog_Baud != 921600) && (this.class10_settings_0.Datalog_Baud != 115200)) this.LogThis("The baudrate is not compatible for the Demon" + Environment.NewLine + "Please set baudrate to 921600 (or 115200)");
        int dtCommCache = 1;
        string[] portNames = SerialPort.GetPortNames();
        try
        {
            if (this.class10_settings_0.dtCommCache != 0)
            {
                dtCommCache = this.class10_settings_0.dtCommCache;
                this.bool_11 = false;
                LogThis("Cached port: COM" + dtCommCache.ToString() + " (baud: " + this.class10_settings_0.Datalog_Baud.ToString() + ")");
                try   //not used
                {
                    if (this.serialPort_0 != null)
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
                bool flag = false;
                if (!this.class10_settings_0.IsBluetooth)
                {
                    for (int i = 0; i < portNames.Length; i++)
                    {
                        if (portNames[i] == ("COM" + dtCommCache.ToString()))
                        {
                            flag = true;
                        }
                    }
                }
                else flag = true;


                if (flag)
                {
                    this.serialPort_0 = new SerialPort("COM" + dtCommCache.ToString(), this.class10_settings_0.Datalog_Baud);
                    this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
                    this.serialPort_0.WriteTimeout = 300;
                    //if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon && this.class10_settings_0.IsBluetooth) this.serialPort_0.WriteTimeout = 300;
                    this.serialPort_0.ReadBufferSize = 0x1100;
                    this.serialPort_0.Encoding = Encoding.Default;
                    this.serialPort_0.Open();
                    LogThis("Cached port: COM" + dtCommCache.ToString() + " open" + " (baud: " + this.class10_settings_0.Datalog_Baud.ToString() + ")");
                    bool flagT = this.class25_0.IsEmulatorConnected(false);
                    if (flagT)
                    {
                        LogThis(this.class25_0.emulatorMoatesType_0 + " found");
                        if (this.bool_16)
                        {
                            if (this.method_29(false))
                            {
                                LogThis(this.class25_0.emulatorMoatesType_0 + " and ecu found");
                                this.class10_settings_0.string_1 = "COM" + dtCommCache.ToString();
                                this.bool_11 = true;
                            }
                            else
                            {
                                LogThis(this.class25_0.emulatorMoatesType_0 + " found but ecu not detected. Check connection between ecu and demon");
                                this.bool_11 = false;
                            }
                        }
                        else
                        {
                            this.class10_settings_0.string_1 = "COM" + dtCommCache.ToString();
                            this.bool_11 = true;
                        }

                        this.serialPort_0.Close();
                        this.serialPort_0.Dispose();
                        return;
                    }
                    LogThis(this.class25_0.emulatorMoatesType_0 + " not found on cached port: COM" + dtCommCache.ToString());
                }
                else
                {
                    LogThis("Cached port failed to open");
                }
                dtCommCache = 1;
                this.bool_11 = false;
                goto Label_02B4;
            }
            else
            {
                LogThis("Cached port is COM0 or not saved");
                dtCommCache = 1;
                this.bool_11 = false;
                goto Label_02B4;
            }
        }
        catch (Exception exception)
        {
            LogThis("Cached port failed with error:" + Environment.NewLine + "" + exception.Message);
        }
        dtCommCache = 1;
        this.bool_11 = false;

    //###################################################################################
    //###################################################################################
    //###################################################################################
    //Section for Demon datalogging trying to auto-scan port!
    Label_02B4:
        try
        {
            if (dtCommCache == 41)
            {
                LogThis("Port Scan Failed");
                this.bool_11 = false;
                if (this.class25_0.Report_Error)
                {
                    LogThis("If you try to datalog on a chip you must change the emulator to:" + Environment.NewLine + "Moates Ostrich in the settings!");
                    MessageBox.Show(Form.ActiveForm, "Can't connect with demon" + Environment.NewLine + "See the debug logs for the issue", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return;
            }
            if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen)
            {
                this.serialPort_0.Close();
            }
            if (this.serialPort_0 != null)
            {
                this.serialPort_0.Dispose();
                this.serialPort_0 = null;
            }
            string str = "COM" + dtCommCache.ToString();
            bool flag2 = false;
            if (!this.class10_settings_0.IsBluetooth)
            {
                for (int j = 0; j < portNames.Length; j++)
                    if (portNames[j] == str) flag2 = true;
            }
            else flag2 = true;
            //flag2 = true;


            if (flag2)
            {
                this.serialPort_0 = new SerialPort("COM" + dtCommCache.ToString(), this.class10_settings_0.Datalog_Baud);
                this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
                this.serialPort_0.WriteTimeout = 300;
                //if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon && this.class10_settings_0.IsBluetooth) this.serialPort_0.WriteTimeout = 300;
                this.serialPort_0.ReadBufferSize = 0x1100;
                this.serialPort_0.Encoding = Encoding.Default;
                this.serialPort_0.Open();
                LogThis("Port open: COM" + dtCommCache.ToString() + " (baud: " + this.class10_settings_0.Datalog_Baud.ToString() + ")");
                bool flag3 = this.class25_0.IsEmulatorConnected(false);
                LogThis(this.class25_0.emulatorMoatesType_0 + " replied=" + flag3.ToString());
                if (flag3)
                {
                    LogThis(this.class25_0.emulatorMoatesType_0 + " found");
                    if (this.bool_16)
                    {
                        if (this.method_29(false))
                        {
                            this.class10_settings_0.string_1 = "COM" + dtCommCache.ToString();
                            this.class10_settings_0.dtCommCache = dtCommCache;
                            LogThis(this.class25_0.emulatorMoatesType_0 + " found on port: COM" + dtCommCache.ToString());
                            this.bool_11 = true;
                        }
                        else
                        {
                            LogThis(this.class25_0.emulatorMoatesType_0 + " found but ecu not detected. Check connection between ecu and demon");
                            this.bool_11 = false;
                        }
                    }
                    else
                    {
                        this.class10_settings_0.string_1 = "COM" + dtCommCache.ToString();
                        this.class10_settings_0.dtCommCache = dtCommCache;
                        LogThis(this.class25_0.emulatorMoatesType_0 + " found on port: COM" + dtCommCache.ToString());
                        this.bool_11 = true;
                    }
                    return;
                }
            }
            dtCommCache++;
            goto Label_02B4;
        }
        catch
        {
            dtCommCache++;
            goto Label_02B4;
        }

    //###################################################################################
    //###################################################################################
    //###################################################################################
    // Section for Ostrich/Chips datalogging!! trying on cached port
    Label_0500:
        LogThis("Ecu detection started");
        int num4 = 1;
        string[] strArray2 = SerialPort.GetPortNames();
        try
        {
            if (this.class10_settings_0.dtCommCache != 0)
            {
                num4 = this.class10_settings_0.dtCommCache;
                this.bool_11 = false;
                LogThis("Cached port: COM" + num4.ToString() + " (baud: " + this.class10_settings_0.Datalog_Baud.ToString() + ")");
                try   //not used!!
                {
                    if (this.serialPort_0 != null)
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
                bool flag4 = false;
                if (!this.class10_settings_0.IsBluetooth)
                {
                    for (int k = 0; k < strArray2.Length; k++)
                    {
                        if (strArray2[k] == ("COM" + num4.ToString()))
                        {
                            flag4 = true;
                        }
                    }
                }
                else flag4 = true;

                if (flag4)
                {
                    this.serialPort_0 = new SerialPort("COM" + num4.ToString(), this.class10_settings_0.Datalog_Baud);
                    this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
                    this.serialPort_0.WriteTimeout = 300;
                    //if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon && this.class10_settings_0.IsBluetooth) this.serialPort_0.WriteTimeout = 300;
                    this.serialPort_0.Encoding = Encoding.Default;
                    this.serialPort_0.Open();
                    LogThis("Cached port: COM" + num4.ToString() + " open" + " (baud: " + this.class10_settings_0.Datalog_Baud.ToString() + ")");
                    if (this.method_29(false))
                    {
                        this.class10_settings_0.string_1 = "COM" + num4.ToString();
                        this.class10_settings_0.dtCommCache = num4;
                        if (!this.class10_settings_0.IsBluetooth)
                        {
                            this.serialPort_0.Close();
                            this.serialPort_0.Dispose();
                        }
                        this.bool_11 = true;
                        LogThis("Ecu found");
                        return;
                    }
                    LogThis("Ecu not found on cached port!");
                }
                else
                {
                    LogThis("Cached port failed to open");
                }
                num4 = 1;
                this.bool_11 = false;
                goto Label_06FE;
            }
            else
            {
                LogThis("Cached port is COM0 or not saved");
            }
            num4 = 1;
            this.bool_11 = false;
            goto Label_06FE;
        }
        catch (Exception exception2)
        {
            LogThis("Cached port failed with error:" + Environment.NewLine + "" + exception2.Message);
        }
        num4 = 1;
        this.bool_11 = false;

    //###################################################################################
    //###################################################################################
    //###################################################################################
    //Section for Ostrich/Chips datalogging!! trying to auto-scan port!
    Label_06FE:
        try
        {
            if (num4 == 41)
            {
                LogThis("Port Scan Failed");
                this.bool_11 = false;
                MessageBox.Show(Form.ActiveForm, "Can't connect with ECU" + Environment.NewLine + "See the debug logs for the issue", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen)
                {
                    this.serialPort_0.Close();
                }
                if (this.serialPort_0 != null)
                {
                    this.serialPort_0.Dispose();
                    this.serialPort_0 = null;
                }
                string str2 = "COM" + num4.ToString();
                bool flag5 = false;
                if (!this.class10_settings_0.IsBluetooth)
                {
                    for (int m = 0; m < strArray2.Length; m++)
                    {
                        if (strArray2[m] == str2)
                        {
                            flag5 = true;
                        }
                    }
                }
                else flag5 = true;

                if (!flag5)
                {
                    num4++;
                    goto Label_06FE;
                }
                this.serialPort_0 = new SerialPort("COM" + num4.ToString(), this.class10_settings_0.Datalog_Baud);
                this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
                this.serialPort_0.WriteTimeout = 300;
                //if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon && this.class10_settings_0.IsBluetooth) this.serialPort_0.WriteTimeout = 300;
                this.serialPort_0.Encoding = Encoding.Default;
                this.serialPort_0.Open();
                LogThis("Port open: COM" + num4.ToString() + " (baud: " + this.class10_settings_0.Datalog_Baud.ToString() + ")");
                bool flag6 = this.method_29(false);
                LogThis("ECU replied=" + flag6.ToString());
                if (flag6)
                {
                    this.class10_settings_0.string_1 = "COM" + num4.ToString();
                    this.class10_settings_0.dtCommCache = num4;
                    LogThis("Ecu found on port: COM" + num4.ToString());
                    this.bool_11 = true;
                }
                else
                {
                    num4++;
                    goto Label_06FE;
                }
            }
        }
        catch
        {
            num4++;
            goto Label_06FE;
        }
    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1, ref Class25 class25_1, ref FrmMain frmMain_1)
    {
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_1);
        this.class10_settings_0 = class10_1;
        this.class25_0 = class25_1;
        this.frmMain_0 = frmMain_1;

        this.class2_serialWB_0 = new Class2_serialWB(ref this.class18_0, ref this.frmMain_0);
        //this.class2_serialWB_0.method_0();
        //##########
        try
        {
            this.class2_serialWB_0.method_0();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            try
            {
                Process process = new Process();
                string environmentVariable = Environment.GetEnvironmentVariable("systemroot");
                process.StartInfo.FileName = environmentVariable + "\\system32\\regsvr32.exe";
                process.StartInfo.Arguments = "\"" + Application.StartupPath + "\\mtssdk.ocx\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                int exitCode = process.ExitCode;
                if (exitCode != 0)
                {
                    MessageBox.Show("failed to register innovate ocx, Innovate widebands wont work.");
                    Application.Exit();
                }
            }
            catch
            {
            }
        }
        this.class2_serialWB_0.method_0();
        //###############

        //this.Class14_Display_0 = new Class14_Display(ref this.class18_0);
        this.class33_Sensors = new Class33_Sensors(ref this.class18_0);
    }

    private void method_1()
    {
        if ((!this.class18_0.method_30_HasFileLoadedInBMTune() && (this.backgroundWorker_0 != null)) && this.backgroundWorker_0.IsBusy)
        {
            this.backgroundWorker_0.CancelAsync();
        }
    }

    public void method_10(int int_3)
    {
        this.serialPort_0.ReadTimeout = int_3;
    }

    public void method_11(byte[] byte_1, int int_3)
    {
        //if (this.method_12(int_3)) this.serialPort_0.Read(byte_1, 0, int_3);

        //Old system is just this
        this.method_12(int_3);
        this.serialPort_0.Read(byte_1, 0, int_3);
    }

    private void method_12(int int_3)
    {
        this.timer_2 = new System.Windows.Forms.Timer();
        this.timer_2.Interval = this.serialPort_0.ReadTimeout;
        this.timer_2.Tick += new EventHandler(this.timer_2_Tick);
        this.bool_13 = false;
        this.timer_2.Start();

        while (this.serialPort_0.BytesToRead < int_3)
        {
            if (this.bool_13)
            {
                this.timer_2.Stop();
                throw new TimeoutException("Chunk timeout");
            }
            Application.DoEvents();
        }
        this.timer_2.Stop();
    }

    /*private bool method_12(int int_3)
    {
        int ThisTries = 0;
        while (this.serialPort_0.BytesToRead < int_3 && ThisTries < 30)
        {
            Application.DoEvents();
            Thread.Sleep((this.serialPort_0.ReadTimeout / 2) / 30);
            ThisTries++;
        }
        if (this.serialPort_0.BytesToRead >= int_3) return true;
        else return false;
    }*/

    public void DiscardBuffer()
    {
        if (!FakeDatalog)
        {
            if (this.serialPort_0.IsOpen)
            {
                try
                {
                    this.serialPort_0.DiscardInBuffer();
                    this.serialPort_0.DiscardOutBuffer();
                }
                catch (Exception)
                {
                }
            }
        }
    }

    public void method_14(byte byte_1)
    {
        try
        {
            this.serialPort_0.Write(((char) byte_1).ToString());
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public void method_15(string string_3)
    {
        try
        {
            this.serialPort_0.Write(string_3);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public void method_16(byte[] byte_1, int int_3, int int_4)
    {
        try
        {
            this.serialPort_0.Write(byte_1, int_3, int_4);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public bool method_17()
    {
        return ((this.serialPort_0 != null) && this.serialPort_0.IsOpen);
    }

    public bool method_18()
    {
        return this.method_19(false);
    }

    public bool method_19(bool bool_18)
    {
        bool flag;

        if (FakeDatalog)
        {
            return true;
        }
        else
        {
            if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen)
            {
                if (bool_18) LogThis("port: " + this.class10_settings_0.string_1.ToString() + " is already open!");

                //###
                //Close and Reopen Port to try
                if (ConnectRetry >= this.class10_settings_0.int_21)
                {
                    DisposeSerial();
                    return false;
                }
                else
                {
                    return true;
                }
                //return true;
            }
            this.serialPort_0 = new SerialPort(this.class10_settings_0.string_1, this.class10_settings_0.Datalog_Baud);
            this.serialPort_0.ReadTimeout = this.class10_settings_0.int_20;
            //this.serialPort_0.WriteTimeout = 300;
            if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon && this.class10_settings_0.IsBluetooth) this.serialPort_0.WriteTimeout = 300;
            this.serialPort_0.ReadBufferSize = 0x1100;
            this.serialPort_0.Encoding = Encoding.Default;
            try
            {
                LogThis("try to open port: " + this.class10_settings_0.string_1.ToString() + " (baud: " + this.serialPort_0.BaudRate.ToString() + ")");
                this.serialPort_0.Open();
                LogThis("port: " + this.class10_settings_0.string_1.ToString() + " open: " + this.method_17().ToString());
                if (bool_18 && this.method_17())
                {
                    if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon)
                    {
                        this.method_4(DataloggingState.Link);
                        flag = this.method_17();
                    }
                    else
                    {
                        bool flagT = this.class25_0.IsEmulatorConnected(false);
                        if (flagT)
                        {
                            if (this.bool_16)
                            {
                                if (this.method_29(false))
                                {
                                    LogThis(this.class25_0.emulatorMoatesType_0 + " and ecu found");
                                    this.method_4(DataloggingState.Link);
                                    flag = true;
                                }
                                else
                                {
                                    LogThis(this.class25_0.emulatorMoatesType_0 + " found but ecu not detected. Check connection between ecu and " + this.class25_0.emulatorMoatesType_0);
                                    flag = false;
                                }
                            }
                            else
                            {
                                LogThis(this.class25_0.emulatorMoatesType_0 + " found");
                                this.method_4(DataloggingState.Link);
                                flag = true;
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                else
                {
                    flag = this.method_17();
                }
            }
            catch (Exception exception2)
            {
                LogThis("Failed to open port:" + this.class10_settings_0.string_1 + " with error:" + Environment.NewLine + "" + exception2.Message);
                throw new ArgumentOutOfRangeException("Failed to open port:" + this.class10_settings_0.string_1, "BMTune");
            }
            if (!flag)
            {
                //method_20();
                DisposeSerial();
            }
        }
        return flag;
    }

    private void DisposeSerial()
    {
        try
        {
            if (this.serialPort_0 != null)
            {
                if (this.serialPort_0.IsOpen) this.serialPort_0.Close();
                this.serialPort_0.Dispose();
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message);
        }
        this.serialPort_0 = null;
    }

    public void method_2()
    {
        if (this.method_63_HasLogsFileOpen())
        {
            this.method_75();
        }
        if (this.method_54())
        {
            if (MessageBox.Show("Temporary datalog file found. " + Environment.NewLine + "" + Environment.NewLine + " Save the temporary file?", "Datalog", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false) == DialogResult.Yes)
            {
                this.method_SaveDatalog();
            }
            else
            {
                File.Delete(this.string_0);
            }
        }
        if (this.method_34_GetConnected())
        {
            this.method_36();
        }
        if (this.backgroundWorker_1 != null)
        {
            while (this.backgroundWorker_1.IsBusy)
            {
                Application.DoEvents();
            }
            this.backgroundWorker_1.Dispose();
            this.backgroundWorker_1 = null;
        }
        if (this.backgroundWorker_0 != null)
        {
            if (this.backgroundWorker_0.IsBusy) this.backgroundWorker_0.CancelAsync();
            while (this.backgroundWorker_0.IsBusy)
            {
                Application.DoEvents();
            }
            this.backgroundWorker_0.Dispose();
            this.backgroundWorker_0 = null;
        }
        this.method_20();
    }

    public void method_20()
    {
        this.method_35(false);
        if (this.serialPort_0 != null)
        {
            if (this.class25_0.method_10())
            {
                if (this.class25_0.GetConnected()) this.method_4(DataloggingState.Link);
            }
            else
            {
                DisposeSerial();
            }
        }
        else
        {
            this.method_4(DataloggingState.Disconnected);
            if (this.class25_0.GetConnected()) this.class25_0.EmulatorDisconnect();
        }
    }

    public bool method_21()
    {
        return this.bool_3;
    }

    public void method_22(bool bool_18)
    {
        this.bool_4 = bool_18;
    }

    public bool method_23()
    {
        return this.bool_5;
    }

    public void method_24(bool bool_18)
    {
        this.bool_5 = bool_18;
    }

    public bool method_25()
    {
        return (!string.IsNullOrEmpty(this.string_1));
    }

    public bool method_27()
    {
        if (!FakeDatalog)
        {
            //Do not run 2x Threads!
            if (this.backgroundWorker_2 != null)
            {
                this.backgroundWorker_2.Dispose();
                this.backgroundWorker_2 = null;
            }

            this.LogThis("Auto-scan started");
            TryingtoConnect = true;             //TryingtoConnect are Only used for FrmMain Title bar
            this.method_4(DataloggingState.Connecting);
            this.backgroundWorker_2 = new BackgroundWorker();
            this.backgroundWorker_2.DoWork += new DoWorkEventHandler(this.backgroundWorker_2_DoWork);
            this.backgroundWorker_2.WorkerReportsProgress = false;
            this.backgroundWorker_2.WorkerSupportsCancellation = false;
            this.backgroundWorker_2.RunWorkerAsync();
            while (this.backgroundWorker_2.IsBusy)
            {
                Application.DoEvents();
            }
            if (!this.method_34_GetConnected()) this.method_4(DataloggingState.Disconnected);       //method_34_GetConnected return value of bool_1
            TryingtoConnect = false;
        }
        else
        {
            this.bool_11 = true;
        }
        return this.bool_11;
    }

    public bool method_28()
    {
        if (!FakeDatalog)
        {
            return this.method_29(true);
        }
        else
        {
            this.long_0 = 0x20L;
            return true;
        }
    }

    public bool method_29(bool bool_18)
    {
        int num6;
        bool flag2;

        if ((this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogDemon) || !this.class10_settings_0.bool_31)
        {
            goto Label_02D0;
        }
        if (this.class25_0.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
        {
            return true;
        }
        //######################################################################################################
        //######################################################################################################
        //######################################################################################################
        // Section for Demon datalogging
        int num = this.class10_settings_0.int_21;
        int num2 = 0;
        try
        {
            if (!this.method_17())
            {
                this.method_18();
            }
        }
        catch (Exception)
        {
        }
        this.DiscardBuffer();
    Label_004E:
        if ((num2 == num) && bool_18)
        {
            LogThis("If you try to datalog on a chip you must change the emulator to:" + Environment.NewLine + "Moates Ostrich in the settings!");
            MessageBox.Show(Form.ActiveForm, "Can't connect with demon on " + this.class10_settings_0.string_1 + "" + Environment.NewLine + "See the debug logs for the issue", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
        this.method_42();
        byte[] buffer_0 = new byte[0x11];
        byte num3 = 0;
        buffer_0[0] = 0x44;       //D
        buffer_0[1] = 0x52;       //R
        buffer_0[2] = 0;          //0
        buffer_0[3] = 0x17;       //
        buffer_0[4] = 0;
        buffer_0[5] = 0;
        buffer_0[6] = 3;
        buffer_0[7] = 1;
        buffer_0[8] = 1;
        buffer_0[9] = 0x10;
        buffer_0[10] = 1;
        buffer_0[11] = 1;
        buffer_0[12] = 0x10;
        buffer_0[13] = 1;
        buffer_0[14] = 1;
        buffer_0[15] = 0x10;
        this.method_44(buffer_0, 0x10);
        num3 = this.method_41();
        buffer_0[0x10] = num3;
        try
        {
            this.method_16(buffer_0, 0, 0x11);
            byte num4 = this.method_7();
            if (num4 == 0x4f)
            {
                num2 = 0;
                LogThis(this.class25_0.emulatorMoatesType_0 + " detected and replied success");
            }
            else
            {
                LogThis(this.class25_0.emulatorMoatesType_0 + " detected and replied: " + num4.ToString("X2") + " " + ((char)num4).ToString());
                num2++;
                goto Label_004E;
            }
        }
        catch (Exception exception)
        {
            LogThis("Error message " + exception.Message + " retry #:" + num2.ToString());
            num2++;
            goto Label_004E;
        }
    Label_0196:
        this.DiscardBuffer();
        if (num2 == num)
        {
            if (bool_18)
            {
                LogThis("If you try to datalog on a chip you must change the emulator to:" + Environment.NewLine + "Moates Ostrich in the settings!");
                MessageBox.Show(Form.ActiveForm, "Can't connect with demon on " + this.class10_settings_0.string_1 + "" + Environment.NewLine + "See the debug logs for the issue", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return false;
        }
        buffer_0 = new byte[1];
        buffer_0[0] = 100;
        byte[] buffer2 = new byte[6];
        try
        {
            this.method_16(buffer_0, 0, 1);
            this.method_11(buffer2, 6);
            this.method_42();
            this.method_44(buffer2, 5);
            num3 = this.method_41();
            byte num5 = buffer2[5];
            if (num5 == num3)
            {
                if (buffer2[1] == 0xcd)
                {
                    LogThis(this.class25_0.emulatorMoatesType_0 + " detected and we have ecu reply");
                    buffer2 = null;
                    buffer_0 = null;
                    num5 = 0;
                    num3 = 0;
                    return true;
                }
                if (buffer2[1] == 84 || buffer2[1] == 0x84)
                {
                    LogThis(this.class25_0.emulatorMoatesType_0 + " detected but the ecu doesn't have power, please put the ignition key On.");
                    this.frmMain_0.SetStatuDatalog("No power to ecu");
                    num2++;
                    //return false;
                }
                if (buffer2[1] != 0xcd && buffer2[1] != 84 && buffer2[1] != 0x84) LogThis(this.class25_0.emulatorMoatesType_0 + " detected but we have timeout between demon and ecu" + Environment.NewLine + "Check Wiring and components and retry");
                this.DiscardBuffer();
                num2++;
            }
            else
            {
                LogThis(this.class25_0.emulatorMoatesType_0 + " detected but we have a checksum error");
                num2++;
            }
            goto Label_0196;
        }
        catch (Exception exception2)
        {
            LogThis(exception2.Message);
            num2++;
            goto Label_0196;
        }

    //######################################################################################################
    //######################################################################################################
    //######################################################################################################
    // Section for Ostrich/Chips Datalogging
    Label_02D0:
        num6 = this.class10_settings_0.int_21;
        int num7 = 0;
        byte num8 = 0;
        byte num9 = 0;
        ConnectRetry = 0;
        switch (this.class10_settings_0.dataloggingMode_0)
        {
            case DataloggingMode.datalogMultiByteT: //this one for ostrich, chips, etc
                num8 = 0x10;
                this.long_0 = 0x20L;
                break;

            case DataloggingMode.datalogDemon:
                if (this.class25_0.emulatorMoatesType_0 == EmulatorMoatesType.neptuneRTP)
                {
                    num8 = 0x10;
                    this.long_0 = 0x20L;
                    break;
                    //return true;
                }
                else
                {
                    this.class18_0.class17_0.frmMain_0.LogThis("datalogging error: demon");
                    num8 = 0x10;
                    this.long_0 = 0x20L;
                    break;
                    //throw new Exception("datalogging error: demon");
                }

            case DataloggingMode.datalogMultiByteX:
                num8 = 0xab;
                this.long_0 = 0x90L;
                break;

            case DataloggingMode.datalogSingleByte:
                num8 = 0xab;
                this.long_0 = 0x90L;
                break;

            default:
                this.class18_0.class17_0.frmMain_0.LogThis("datalogging error: unknow datalog type");
                num8 = 0x10;
                this.long_0 = 0x20L;
                break;
                //throw new Exception("datalogging error: demon");
        }
    Label_035F:
        if (!this.method_17())
        {
            this.method_18();
        }
        this.DiscardBuffer();
        try
        {
            if (num7 == num6)
            {
                if (bool_18)
                {
                    MessageBox.Show(Form.ActiveForm, "Can't connect with ecu on " + this.class10_settings_0.string_1 + "" + Environment.NewLine + "See the debug logs for the issue", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            this.serialPort_0.Write(((char)num8).ToString());       //here too
            byte num10 = (byte)this.serialPort_0.ReadByte();
            //ConnectRetry = 0;

            if ((num10 == num9) && (num10 != 0xcd))
            {
                //flag2 = false;
                if (this.class10_settings_0.bool_CheckJ12)
                {
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
                MessageBox.Show(Form.ActiveForm, "J12/J4 not removed in the ecu?", "BMTune");
                LogThis("Received byte is same as send byte");
                LogThis("J12/J4 inplace detect");
                LogThis("remove J12(USDM ecu) or J4(JDM ecu) to be able to datalog");
            }
            num9 = num10;
            if (num10 == 0xcd)
            {
                LogThis("Ecu replied correct handshake byte");
                this.bool_11 = true;
                flag2 = true;
            }
            else
            {
                LogThis("Ecu DIDN'T Replied correct handshake byte!" + Environment.NewLine + "Replied: " + num10.ToString("X2") + "(expected is: 0xCD)");
                if (this.class10_settings_0.bool_CheckJ12)
                {
                    this.bool_11 = true;
                    flag2 = true;
                }
                else
                {
                    ConnectRetry++;
                    num7++;
                    goto Label_035F;
                }
            }
        }
        catch (Exception exception3)
        {
            ConnectRetry++;
            LogThis(exception3.Message);
            num7++;
            goto Label_035F;
        }
        return flag2;
    }

    public DataloggingState method_3()
    {
        return this.dataloggingState_0;
    }

    public void method_30()
    {
        this.bool_9 = true;
    }

    private string GetDatalogCommand()
    {
        switch (this.class10_settings_0.method_8())
        {
            case DataloggingTable.tableMain:
            {
                if (this.class10_settings_0.dataloggingMode_0 == DataloggingMode.datalogMultiByteT)
                {
                    char ch2 = ' ';
                    return ch2.ToString();
                }
                char ch = '\x0090';
                return ch.ToString();
            }
            case DataloggingTable.tableMinimal:
            {
                if (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogMultiByteT)
                {
                    this.class18_0.class17_0.frmMain_0.LogThis("Error: DatalogginCommand");
                    //throw new Exception("DatalogginCommand");
                }
                char ch4 = '0';
                return ch4.ToString();
                //char ch3 = '\x0090';
                //return ch3.ToString();
            }
            case DataloggingTable.table3:
            {
                if (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogMultiByteT)
                {
                    this.class18_0.class17_0.frmMain_0.LogThis("Error: DatalogginCommand");
                    //throw new Exception("DatalogginCommand");
                }
                char ch6 = '0';
                return ch6.ToString();
                //char ch5 = '\x0090';
                //return ch5.ToString();
            }
        }
        this.class18_0.class17_0.frmMain_0.LogThis("Error: DatalogginCommand");
        char chx = ' ';
        return chx.ToString();
        //throw new Exception("DatalogginCommand");
    }

    private void LogThis(string string_1)
    {
        frmMain_0.LogThis("Datalog - " + string_1);
    }

    public bool method_34_GetConnected()
    {
        return this.bool_1;
    }

    public void method_35(bool bool_18)
    {
        this.bool_1 = bool_18;
        if (bool_18)
        {
            this.method_4(DataloggingState.Connected);
        }
        else
        {
            this.method_4(DataloggingState.Disconnected);
        }
    }

    //Datalog connect button clic from main menu
    public void method_36()
    {
        //bool_27 = autoscan
        //method_34_GetConnected = bool_1
        if (!this.class10_settings_0.bool_27 || this.method_34_GetConnected())
        {
            this.method_37();
        }
        else if (this.class10_settings_0.bool_27 && !this.method_34_GetConnected())
        {
            //method_27 = autoscan thread backgroundWorker_2
            //method_37 = connect to device!
            LogThis("Auto scan enabled");
            if (this.method_27())
            {
                this.method_37();
            }
        }
    }

    public void method_37()
    {
        /*Console.WriteLine("1." + this.backgroundWorker_0.IsBusy);
        Console.WriteLine("2." + this.method_34_GetConnected());
        Console.WriteLine("3." + this.bool_11);
        Console.WriteLine("4." + serialPort_0.IsOpen);*/

        this.int_0 = 0;

        if (!this.backgroundWorker_0.IsBusy)
        {
            //Console.WriteLine("restart");
            if (this.method_63_HasLogsFileOpen())
            {
                this.method_75();
            }
            //TryingtoConnect = true;                         //
            //this.method_4(DataloggingState.Connecting);     //this is not called
            this.stopwatch_1.Reset();
            this.FrameCounts = 0L;
            if (this.list_0 != null) this.list_0 = null;
            this.backgroundWorker_0.RunWorkerAsync();
            if (this.class10_settings_0.bool_8 || this.method_23())
            {
                this.method_StartRecord();
            }
            //if (!this.method_34_GetConnected()) this.method_4(DataloggingState.Disconnected);   //this is not called
            //TryingtoConnect = false;                        //
        }
        else if (this.method_34_GetConnected())
        {
            if (this.method_50())
            {
                this.method_StartRecord();
            }
            if (this.method_23() && this.method_54())
            {
                string destFileName = (this.string_1 + @"\log_") + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".bml";
                FileInfo info = new FileInfo(this.string_0);
                try
                {
                    info.CopyTo(destFileName);
                    byte[] byte_99_0 = this.class18_0.method_92(File.ReadAllBytes(destFileName));
                    File.WriteAllBytes(destFileName, byte_99_0);
                }
                catch (Exception)
                {
                }
                finally
                {
                    info.Delete();
                    info = null;
                }
            }
            this.backgroundWorker_0.CancelAsync();
            method_35(false);
        }
    }

    private Struct12 method_38(byte[] byte_1)
    {
        this.stopwatch_0.Stop();
        if (this.class10_settings_0.method_8() == DataloggingTable.tableMain)
        {
            this.struct12_0 = new Struct12();
            this.struct12_0.byte_0 = byte_1[0];
            this.struct12_0.byte_1 = byte_1[1];
            this.struct12_0.byte_2 = byte_1[2];
            this.struct12_0.byte_3 = byte_1[3];
            this.struct12_0.byte_4 = byte_1[4];
            this.struct12_0.byte_5 = byte_1[5];
            this.struct12_0.ushort_0_E6_7 = this.class18_0.method_146(byte_1[6], byte_1[7]);
            this.struct12_0.byte_6_E8 = byte_1[8];
            this.struct12_0.byte_7_E9 = byte_1[9];
            this.struct12_0.byte_8_E10 = byte_1[10];
            this.struct12_0.byte_9_E11 = byte_1[11];
            this.struct12_0.byte_10_E12 = byte_1[12];
            this.struct12_0.byte_11_E13 = byte_1[13];
            this.struct12_0.byte_12_E14 = byte_1[14];
            this.struct12_0.byte_13_E15 = byte_1[15];
            this.struct12_0.byte_14_E16 = byte_1[0x10];
            this.struct12_0.ushort_1_E17_18 = this.class18_0.method_146(byte_1[0x11], byte_1[0x12]);
            this.struct12_0.byte_15_E19 = byte_1[0x13];
            this.struct12_0.byte_16_E20 = byte_1[20];
            this.struct12_0.byte_20 = this.class18_0.method_215(this.struct12_0.byte_14_E16, (long) this.struct12_0.ushort_0_E6_7);
            this.struct12_0.byte_21_E21 = byte_1[0x15];
            this.struct12_0.byte_22_E22 = byte_1[0x16];
            this.struct12_0.byte_23_E23 = byte_1[0x17];
            this.struct12_0.byte_24_E24 = byte_1[0x18];
            this.struct12_0.byte_27_E25 = byte_1[0x19];
            this.struct12_0.byte_28_E26 = byte_1[0x1a];
            this.struct12_0.long_0_E27_28 = this.class18_0.method_146(byte_1[0x1b], byte_1[0x1c]);
            this.struct12_0.long_1_E29_30 = this.class18_0.method_146(byte_1[0x1d], byte_1[30]);
            this.struct12_0.long_2_E31_32 = this.class18_0.method_146(byte_1[0x1f], byte_1[0x20]);
            this.struct12_0.byte_29_E33 = byte_1[0x21];
            this.struct12_0.byte_30_E34 = byte_1[0x22];
            this.struct12_0.byte_31_E35 = byte_1[0x23];
            this.struct12_0.byte_32_E36 = byte_1[0x24];
            this.struct12_0.byte_33_E37 = byte_1[0x25];
            this.struct12_0.byte_34_E38 = byte_1[0x26];
            this.struct12_0.byte_35_E39 = byte_1[0x27];
            this.struct12_0.byte_37_E40 = byte_1[40];
            this.struct12_0.byte_38_E41 = byte_1[0x29];
            this.struct12_0.byte_39_E42 = byte_1[0x2a];
            this.struct12_0.byte_36_E43 = byte_1[0x2b];
            this.struct12_0.byte_25_E44 = byte_1[0x2c];
            this.struct12_0.byte_26_E45 = byte_1[0x2d];
            this.struct12_0.byte_44_E46 = byte_1[0x2e];
            this.struct12_0.byte_45_E47 = byte_1[0x2f];
            this.struct12_0.byte_46_E48 = byte_1[0x30];
            this.struct12_0.ushort_2_E49_50 = this.class18_0.method_146(byte_1[0x31], byte_1[50]);
        }
        else if (this.class10_settings_0.method_8() == DataloggingTable.tableMinimal)
        {
            this.struct12_0 = new Struct12();
            this.struct12_0.byte_0 = byte_1[0];
            this.struct12_0.byte_1 = byte_1[1];
            this.struct12_0.byte_2 = byte_1[2];
            this.struct12_0.byte_4 = byte_1[3];
            this.struct12_0.byte_5 = byte_1[4];
            this.struct12_0.byte_14_E16 = byte_1[5];
            this.struct12_0.byte_7_E9 = byte_1[6];
            this.struct12_0.byte_8_E10 = byte_1[7];
            this.struct12_0.byte_9_E11 = byte_1[8];
            this.struct12_0.ushort_0_E6_7 = this.class18_0.method_146(byte_1[9], byte_1[10]);
            this.struct12_0.ushort_1_E17_18 = this.class18_0.method_146(byte_1[11], byte_1[12]);
            this.struct12_0.byte_15_E19 = byte_1[13];
            this.struct12_0.byte_6_E8 = byte_1[14];
            this.struct12_0.byte_35_E39 = byte_1[15];
            this.struct12_0.byte_20 = this.class18_0.method_215(this.struct12_0.byte_14_E16, (long) this.struct12_0.ushort_0_E6_7);
        }
        else if (this.class10_settings_0.method_8() == DataloggingTable.table3)
        {
            this.struct12_0 = new Struct12();
            this.struct12_0.byte_0 = byte_1[0];
            this.struct12_0.byte_1 = byte_1[1];
            this.struct12_0.byte_2 = byte_1[2];
            this.struct12_0.byte_4 = byte_1[3];
            this.struct12_0.byte_5 = byte_1[4];
            this.struct12_0.byte_14_E16 = byte_1[5];
            this.struct12_0.ushort_0_E6_7 = this.class18_0.method_146(byte_1[6], byte_1[7]);
            this.struct12_0.long_6 = this.class18_0.method_146(byte_1[8], byte_1[9]);
            this.struct12_0.long_7 = this.class18_0.method_146(byte_1[10], byte_1[11]);
            this.struct12_0.byte_47 = byte_1[12];
            this.struct12_0.byte_20 = this.class18_0.method_215(this.struct12_0.byte_14_E16, (long) this.struct12_0.ushort_0_E6_7);
            this.struct12_0.byte_7_E9 = byte_1[13];
            this.struct12_0.byte_8_E10 = byte_1[14];
            this.struct12_0.byte_9_E11 = byte_1[15];
            this.struct12_0.ushort_1_E17_18 = this.class18_0.method_146(byte_1[0x10], byte_1[0x11]);
            this.struct12_0.byte_15_E19 = byte_1[0x12];
            this.struct12_0.byte_24_E24 = byte_1[0x13];
            this.struct12_0.byte_38_E41 = byte_1[20];
            this.struct12_0.byte_25_E44 = byte_1[0x15];
            this.struct12_0.byte_26_E45 = byte_1[0x16];
            this.struct12_0.byte_6_E8 = byte_1[0x17];
            this.struct12_0.byte_35_E39 = byte_1[0x18];
        }
        FrameCounts++;
        if (this.method_34_GetConnected() && !this.method_63_HasLogsFileOpen())
        {
            this.struct12_0.long_3 = FrameCounts;
            this.struct12_0.long_4 = 10;
        }
        else
        {
            this.struct12_0.long_3 = this.stopwatch_1.ElapsedMilliseconds;
            this.struct12_0.long_4 = this.stopwatch_0.ElapsedMilliseconds;
        }
        this.stopwatch_0.Reset();
        this.struct12_0.long_5 = this.long_1;
        this.struct12_0.byte_40 = this.struct12_0.byte_24_E24;
        this.struct12_0.byte_41 = this.struct12_0.byte_25_E44;
        this.struct12_0.byte_42 = this.struct12_0.byte_26_E45;
        if (this.class10_settings_0.bool_25)
        {
            try
            {
                this.struct12_0.byte_43 = this.class18_0.method_213(this.class18_0.method_241(this.class2_serialWB_0.method_1()));
                goto Label_07C3;
            }
            catch
            {
                throw;
            }
        }
        switch (this.class10_settings_0.wbinput_0)
        {
            case WBinput.o2Input:
                this.struct12_0.byte_43 = this.struct12_0.byte_2;
                break;

            case WBinput.eldInput:
                this.struct12_0.byte_43 = this.struct12_0.byte_24_E24;
                break;

            case WBinput.egrInput:
                this.struct12_0.byte_43 = this.struct12_0.byte_25_E44;
                break;

            case WBinput.b6Input:
                this.struct12_0.byte_43 = this.struct12_0.byte_26_E45;
                break;

            default:
                this.struct12_0.byte_43 = this.struct12_0.byte_2;
                this.class18_0.class17_0.frmMain_0.LogThis("wideband input error in selection");
                break;
                //throw new Exception("wideband input error in selection");
        }
    Label_07C3:
        if (this.class10_settings_0.bool_23 && (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_50) == 0))
        {
            if (this.struct12_0.byte_3 != 0)
            {
                int num = (int) Math.Round((double) ((((this.struct12_0.byte_3 / 2) + 0x18) * 7.221) - 59.0), 0);
                if (this.class10_settings_0.int_6 != num)
                {
                    this.class10_settings_0.int_6 = num;
                }
            }
            else
            {
                this.class10_settings_0.int_6 = 0x3f2;
            }
        }
        this.struct23_0.bool_0 = this.class18_0.method_258(this.struct12_0.byte_6_E8, 3);
        this.struct23_0.bool_1 = this.class18_0.method_258(this.struct12_0.byte_35_E39, 5);
        this.frmMain_0.method_2(ref this.struct12_0);
        if (this.struct12_0.byte_7_E9 > (this.class18_0.method_32_GetRPM_RowsNumber() - 1))
        {
            this.struct12_0.byte_7_E9 = (byte) (this.class18_0.method_32_GetRPM_RowsNumber() - 1);
        }
        if (this.struct12_0.byte_8_E10 > (this.class18_0.method_32_GetRPM_RowsNumber() - 1))
        {
            this.struct12_0.byte_8_E10 = (byte) (this.class18_0.method_32_GetRPM_RowsNumber() - 1);
        }
        if (this.struct12_0.byte_9_E11 > (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
        {
            if (!this.class18_0.method_42())
            {
                if (((this.struct12_0.byte_9_E11 > 0x17) && !this.bool_12) && (this.class18_0.class15_0.method_22() != BMTuneVersions.datalogger))
                {
                    if (this.struct12_0.byte_4 < this.class18_0.method_165(0))
                    {
                        this.bool_12 = true;
                        if (MessageBox.Show(Form.ActiveForm, string.Concat(new object[] { "Error!" + Environment.NewLine + "Current mbar is lower then column1.", Environment.NewLine, "Current mbar is ", this.class18_0.method_206(this.struct12_0.byte_4), " and colomn 1 mbar is ", this.class18_0.method_163(0), Environment.NewLine, "Would like to lower column 1 mbar to ", this.class18_0.method_206(this.struct12_0.byte_4 - 3), "?" }), "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                        {
                            int num2 = this.class18_0.method_206(this.struct12_0.byte_4 - 3);
                            this.class18_0.method_173(0, num2);
                            this.class18_0.method_53();
                        }
                    }
                    else
                    {
                        this.bool_12 = true;
                        MessageBox.Show(Form.ActiveForm, "Error!" + Environment.NewLine + "Current load is higher then load of last column!");
                    }
                }
            }
            else
            {
                this.bool_12 = true;
                MessageBox.Show(Form.ActiveForm, "Error!" + Environment.NewLine + "Set the TPS range indexing properly!");
            }
            this.struct12_0.byte_9_E11 = (byte) (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1);
        }
        if (this.struct23_0.bool_0)
        {
            this.struct23_0.struct24_0.int_0 = this.struct12_0.byte_8_E10;
            this.struct23_0.float_0 = 0f;
            if (this.struct23_0.struct24_0.int_0 < this.class18_0.method_32_GetRPM_RowsNumber())
            {
                int num3 = this.class18_0.method_159(this.struct12_0.byte_8_E10);
                int num4 = this.class18_0.method_159((byte) (this.struct12_0.byte_8_E10 + 1));
                this.struct23_0.float_0 = ((float) this.class18_0.method_218((long) this.struct12_0.ushort_0_E6_7)) / ((float) (num3 + num4));
            }
        }
        else
        {
            this.struct23_0.struct24_0.int_0 = this.struct12_0.byte_7_E9;
            this.struct23_0.float_0 = 0f;
            if (this.struct23_0.struct24_0.int_0 < this.class18_0.method_32_GetRPM_RowsNumber())
            {
                int num5 = this.class18_0.method_159(this.struct12_0.byte_7_E9);
                int num6 = this.class18_0.method_159((byte) (this.struct12_0.byte_7_E9 + 1));
                this.struct23_0.float_0 = ((float) this.class18_0.method_218((long) this.struct12_0.ushort_0_E6_7)) / ((float) (num5 + num6));
            }
        }
        this.struct23_0.float_1 = 0f;
        if (this.struct12_0.byte_9_E11 < ((byte) (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1)))
        {
            int num7 = this.class18_0.method_165(this.struct12_0.byte_9_E11);
            int num8 = this.class18_0.method_165((byte) (this.struct12_0.byte_9_E11 + 1));
            this.struct23_0.float_1 = ((float) this.struct12_0.byte_4) / ((float) (num7 + num8));
        }
        this.struct23_0.struct24_0.int_1 = this.struct12_0.byte_9_E11;
        this.struct23_0.struct24_1 = this.struct23_0.struct24_0;
        if (this.struct23_0.float_0 >= 0.5) this.struct23_0.struct24_1.int_0++;
        if (this.struct23_0.float_1 >= 0.5) this.struct23_0.struct24_1.int_1++;
        this.struct12_0.struct24_0 = this.struct23_0.struct24_1;
        this.struct23_0.struct24_2 = this.struct23_0.struct24_0;
        this.struct23_0.method_0(this.struct23_0.struct24_0, ref this.class10_settings_0);
        this.struct23_0.byte_0 = this.struct12_0.byte_43;
        bool flag = this.class18_0.method_258(this.struct12_0.byte_6_E8, 4) || this.class18_0.method_258(this.struct12_0.byte_6_E8, 5);
        this.struct17_0.bool_0 = this.struct23_0.bool_0;
        this.struct12_0.bool_11 = this.struct23_0.bool_0;
        this.struct17_0.bool_1 = this.struct23_0.bool_1;
        this.struct12_0.bool_12 = this.struct23_0.bool_1;
        if (this.class10_settings_0.bool_48) this.struct17_0.bool_2 = flag;
        else this.struct17_0.bool_2 = false;
        this.struct17_0.struct24_0.int_0 = this.struct23_0.struct24_0.int_0;
        this.struct17_0.struct24_0.int_1 = this.struct23_0.struct24_0.int_1;
        this.struct17_0.float_0 = this.struct23_0.float_0;
        this.struct17_0.float_1 = this.struct23_0.float_1;
        this.struct17_0.method_1(this.struct17_0.struct24_0, ref this.class18_0);
        this.struct17_0.struct24_1 = this.struct23_0.struct24_1;
        this.struct17_0.byte_0 = this.struct12_0.byte_43;
        this.struct17_0.long_1 = this.struct12_0.ushort_0_E6_7;
        this.struct17_0.byte_2 = this.struct12_0.byte_4;
        this.struct17_0.byte_1 = this.struct12_0.byte_5;
        this.struct17_0.byte_3 = this.struct12_0.byte_0;
        this.struct17_0.byte_4 = this.struct12_0.byte_1;
        this.struct17_0.byte_5 = this.struct12_0.byte_20;
        this.struct17_0.long_0 = this.struct12_0.long_3;
        float num9 = 0f;
        this.struct12_0.bool_0 = this.class10_settings_0.bool_36 && !this.method_88(AnalogInputs.analog1);
        this.struct12_0.bool_1 = this.class10_settings_0.bool_38 && !this.method_88(AnalogInputs.analog2);
        this.struct12_0.bool_2 = this.class10_settings_0.bool_40 && !this.method_88(AnalogInputs.analog3);
        this.struct12_0.bool_3 = this.method_86(SensorsX.egt_cht1);
        if (this.method_87(SensorsX.egt_cht1))
        {
            if (this.class10_settings_0.int_55 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_55 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_55 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_0 = num9;
        this.struct12_0.bool_4 = this.method_86(SensorsX.egt_cht2);
        if (this.method_87(SensorsX.egt_cht2))
        {
            if (this.class10_settings_0.int_56 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_56 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_56 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_1 = num9;
        this.struct12_0.bool_5 = this.method_86(SensorsX.egt_cht3);
        if (this.method_87(SensorsX.egt_cht3))
        {
            if (this.class10_settings_0.int_57 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_57 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_57 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_2 = num9;
        this.struct12_0.bool_6 = this.method_86(SensorsX.egt_cht4);
        if (this.method_87(SensorsX.egt_cht4))
        {
            if (this.class10_settings_0.int_58 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_58 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_58 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_3 = num9;
        this.struct12_0.bool_7 = this.method_86(SensorsX.egt_chtAvg);
        if (this.method_87(SensorsX.egt_chtAvg))
        {
            if (this.class10_settings_0.int_59 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_59 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_59 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_4 = num9;
        this.struct12_0.bool_8 = this.method_86(SensorsX.backPres);
        if (this.method_87(SensorsX.backPres))
        {
            if (this.class10_settings_0.int_60 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_60 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_60 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_5 = num9;
        this.struct12_0.bool_9 = this.method_86(SensorsX.fuelPres);
        if (this.method_87(SensorsX.fuelPres))
        {
            if (this.class10_settings_0.int_61 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_61 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_61 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_6 = num9;
        this.struct12_0.bool_10 = this.method_86(SensorsX.iat2);
        if (this.method_87(SensorsX.iat2))
        {
            if (this.class10_settings_0.int_62 == 1)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog1, this.struct12_0.byte_40);
            }
            else if (this.class10_settings_0.int_62 == 2)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog2, this.struct12_0.byte_41);
            }
            else if (this.class10_settings_0.int_62 == 3)
            {
                num9 = this.class18_0.method_201(AnalogInputs.analog3, this.struct12_0.byte_42);
            }
        }
        this.struct12_0.float_7 = num9;
        if (this.delegate47_0 != null)
        {
            this.delegate47_0(this.struct17_0);
        }
        if (this.delegate50_0 != null)
        {
            this.delegate50_0(this.struct12_0);
        }
        this.struct20_0.byte_0 = this.struct12_0.byte_10_E12;
        this.struct20_0.byte_1 = this.struct12_0.byte_11_E13;
        this.struct20_0.byte_2 = this.struct12_0.byte_12_E14;
        this.struct20_0.byte_3 = this.struct12_0.byte_13_E15;
        if (((this.struct20_0.byte_0 != 0) || (this.struct20_0.byte_1 != 0)) || ((this.struct20_0.byte_2 != 0) || (this.struct20_0.byte_3 != 0)))
        {
            this.struct12_0.byte_19 = 1;
        }
        else
        {
            this.struct12_0.byte_19 = 0;
        }
        return this.struct12_0;
    }

    private void method_39()
    {
        this.thread_1 = new Thread(new ThreadStart(this.method_40_SendBytes_Delegate));
        this.thread_1.Priority = ThreadPriority.Normal;
        this.thread_1.Start();
    }

    public void method_4(DataloggingState dataloggingState_2)
    {
        this.dataloggingState_0 = dataloggingState_2;
        if (this.delegate46_0 != null)
        {
            this.delegate46_0(this.dataloggingState_0, this.method_34_GetConnected());
        }
    }

    private void method_40_SendBytes_Delegate()
    {
        if ((Application.OpenForms[0].WindowState != FormWindowState.Minimized) && this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            if (this.delegate49_0 != null)
            {
                this.delegate49_0(this.struct23_0);
            }
            if (this.delegate45_0 != null)
            {
                this.delegate45_0(this.struct20_0);
            }
            if (this.delegate54_0 != null)
            {
                //this.class18_Sensors.LoadSensorsData(this.struct12_0);
                this.delegate54_0(this.struct12_0);
            }
        }
    }

    private byte method_41()
    {
        return this.byte_0;
    }

    private void method_42()
    {
        this.byte_0 = 0;
    }

    private void method_43(byte byte_1)
    {
        this.byte_0 = (byte) (this.byte_0 + byte_1);
    }

    private void method_44(byte[] byte_1, int int_3)
    {
        this.byte_0 = 0;
        for (int i = 0; i < int_3; i++)
        {
            this.byte_0 = (byte) (this.byte_0 + byte_1[i]);
        }
    }

    /*private bool method_45()
    {
        bool flag;
        int num = this.class10_0.int_21;
        int num2 = 0;
    Label_0013:
        if (num2 == num)
        {
            return false;
        }
        this.method_42();
        byte[] buffer_0 = new byte[0x11];
        buffer_0[0] = 0x44;
        buffer_0[1] = 0x52;
        buffer_0[2] = 0;
        buffer_0[3] = 0x17;
        buffer_0[4] = 0;
        buffer_0[5] = 0;
        buffer_0[6] = 3;
        buffer_0[7] = 1;
        buffer_0[8] = 1;
        buffer_0[9] = 0x10;
        buffer_0[10] = 1;
        buffer_0[11] = 1;
        buffer_0[12] = 0x10;
        buffer_0[13] = 1;
        buffer_0[14] = 1;
        buffer_0[15] = 0x10;
        this.method_44(buffer_0, 0x10);
        byte num3 = this.method_41();
        buffer_0[0x10] = num3;
        try
        {
            this.method_16(buffer_0, 0, 0x11);
            byte num4 = this.method_7();
            if (num4 == 0x4f)
            {
                num2 = 0;
                LogThis(this.class25_0.emulatorMoatesType_0 + " detected and replied succes");
                flag = true;
            }
            else
            {
                LogThis(this.class25_0.emulatorMoatesType_0 + " detected and replied: " + num4.ToString("X2") + " " + ((char) num4).ToString());
                num2++;
                goto Label_0013;
            }
        }
        catch (Exception exception)
        {
            LogThis("Error message " + exception.Message + " retry #:" + num2.ToString());
            MessageBox.Show(new Form {TopMost = true}, exception.Message);
            num2++;
            goto Label_0013;
        }
        return flag;
    }*/

    private bool method_46()
    {
        bool flag;
        int num = this.class10_settings_0.int_21;
        int num2 = 0;
    Label_0013:
        if (!this.method_17())
        {
            this.method_18();
        }
        this.DiscardBuffer();
        if (num2 == num)
        {
            MessageBox.Show(Form.ActiveForm, "Failed to set datalog command", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
        this.method_42();
        byte[] buffer_0 = new byte[11];
        buffer_0[0] = 0x44;
        buffer_0[1] = 0x52;
        buffer_0[2] = 0;
        buffer_0[3] = 0x17;
        buffer_0[4] = 0;
        buffer_0[5] = 0;
        buffer_0[6] = 1;
        buffer_0[7] = 1;
        buffer_0[8] = 0x34;
        buffer_0[9] = 0x20;
        this.method_44(buffer_0, 10);
        byte num3 = this.method_41();
        buffer_0[10] = num3;
        try
        {
            this.method_16(buffer_0, 0, 11);
            if (this.method_7() == 0x4f)
            {
                num2 = 0;
                flag = true;
            }
            else
            {
                num2++;
                goto Label_0013;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message);
            num2++;
            goto Label_0013;
        }
        return flag;
    }

    private bool method_47()
    {
        bool flag;
        int num = this.class10_settings_0.int_21;
        int num2 = 0;
    Label_0013:
        if (!this.method_17())
        {
            this.method_18();
        }
        this.DiscardBuffer();
        if (num2 == num)
        {
            MessageBox.Show(Form.ActiveForm, "Failed to set datalog command:" + Environment.NewLine + "MIL CLEAR", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
        this.method_42();
        byte[] buffer_0 = new byte[11];
        buffer_0[0] = 0x44;
        buffer_0[1] = 0x52;
        buffer_0[2] = 0;
        buffer_0[3] = 0x17;
        buffer_0[4] = 0;
        buffer_0[5] = 0;
        buffer_0[6] = 1;
        buffer_0[7] = 1;
        buffer_0[8] = 1;
        buffer_0[9] = 80;
        this.method_44(buffer_0, 10);
        byte num3 = this.method_41();
        buffer_0[10] = num3;
        try
        {
            this.method_16(buffer_0, 0, 11);
            if (this.method_7() == 0x4f)
            {
                num2 = 0;
                flag = true;
            }
            else
            {
                num2++;
                goto Label_0013;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message);
            num2++;
            goto Label_0013;
        }
        return flag;
    }

    private void method_48()
    {
        try
        {
            byte[] buffer_0 = new byte[] { 100 };
            this.serialPort_0.Write(buffer_0, 0, 1);
            buffer_0 = null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void method_49(Struct12 struct12_1)
    {
        if (this.method_34_GetConnected() && !this.method_63_HasLogsFileOpen())
        {
            if (this.list_0 == null) this.list_0 = new List<Struct12>();
            struct12_1.long_3 = FrameCounts;
            this.list_0.Add(struct12_1);
        }
        if (!this.method_25())
        {
            return;
        }
        this.enum9_0 = (Enum9)0;
        this.enum10_0 = (Enum10)0;
        bool flag = false;
        bool flag2 = false;
        bool flag3 = false;
        flag = ((this.class18_0.method_198(struct12_1.byte_5) >= 0) && (struct12_1.byte_14_E16 >= 0)) && (this.class18_0.method_218((long)struct12_1.ushort_0_E6_7) >= 0);
        flag3 = flag;
        switch (this.enum9_0)
        {
            case Enum9.const_0:
                goto Label_01C5;
        }
        if (this.enum10_0 == Enum10.const_0)
        {
            flag3 = flag && flag2;
        }
        else if (flag2 || flag)
        {
            flag3 = true;
        }
        else
        {
            flag3 = false;
        }
        Label_01C5:
        this.bool_15 = flag3;
        if (!flag3)
        {
            this.dataloggingState_1 = this.method_3();
        }
        if (flag3)
        {
            if (this.method_25() && (this.method_3() != DataloggingState.Recording))
            {
                this.method_4(DataloggingState.Recording);
                this.method_StartRecord();
            }
        }
        else if (this.method_50())
        {
            this.method_StartRecord();
            if (this.method_25() && this.method_54())
            {
                string destFileName = (this.string_1 + @"\log_") + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".bml";
                FileInfo info = new FileInfo(this.string_0);
                try
                {
                    info.CopyTo(destFileName);
                    byte[] byte_99_0 = this.class18_0.method_92(File.ReadAllBytes(destFileName));
                    File.WriteAllBytes(destFileName, byte_99_0);
                }
                catch (Exception)
                {
                }
                finally
                {
                    info.Delete();
                    info = null;
                }
                this.method_4(this.method_3());
            }
        }
    }

    public bool method_50()
    {
        return this.bool_2;
    }

    public void method_51(bool bool_18)
    {
        this.bool_2 = bool_18;
        if (bool_18)
        {
            this.method_4(DataloggingState.Recording);
        }
    }

    private void method_52(Struct12 struct12_1)
    {
        BinaryWriter writer;
        FileStream output = new FileStream(this.string_0, FileMode.OpenOrCreate, FileAccess.Write);
        writer = new BinaryWriter(output);
        writer.BaseStream.Position = writer.BaseStream.Length;

        this.long_2 = ((int)((writer.BaseStream.Length - 0x7b) - 0x10L)) / (0x7b + 1);
        this.long_3 = struct12_1.long_3;

        int num = 0;
        int num2 = 6;
        int num3 = 0x7b;
        if (writer.BaseStream.Position == 0L)
        {
            writer.Write((byte) 0x42);
            writer.Write((byte) 0x4d);
            writer.Write((byte) 0x54);
            writer.Write((byte) 0x75);
            writer.Write((byte) 0x6e);
            writer.Write((byte) 0x65);
            writer.Write((byte) 0x2e);
            writer.Write((byte) 0x62);
            writer.Write((byte) 0x6d);
            writer.Write((byte) 0x6c);
            writer.Write((ushort) num2);
            writer.Write((byte) num3);
            writer.Write(num);
        }
        writer.Write(struct12_1.byte_0);
        writer.Write(struct12_1.byte_1);
        writer.Write(struct12_1.byte_2);
        writer.Write(struct12_1.byte_3);
        writer.Write(struct12_1.byte_4);
        writer.Write(struct12_1.byte_5);
        writer.Write(struct12_1.ushort_0_E6_7);
        writer.Write(struct12_1.byte_6_E8);
        writer.Write(struct12_1.byte_7_E9);
        writer.Write(struct12_1.byte_8_E10);
        writer.Write(struct12_1.byte_9_E11);
        writer.Write(struct12_1.byte_10_E12);
        writer.Write(struct12_1.byte_11_E13);
        writer.Write(struct12_1.byte_12_E14);
        writer.Write(struct12_1.byte_13_E15);
        writer.Write(struct12_1.byte_14_E16);
        writer.Write(struct12_1.ushort_1_E17_18);
        writer.Write(struct12_1.byte_15_E19);
        writer.Write(struct12_1.byte_16_E20);
        writer.Write(struct12_1.byte_21_E21);
        writer.Write(struct12_1.byte_22_E22);
        writer.Write(struct12_1.byte_23_E23);
        writer.Write(struct12_1.byte_24_E24);
        writer.Write(struct12_1.byte_27_E25);
        writer.Write(struct12_1.long_3);
        writer.Write(struct12_1.long_4);
        writer.Write(struct12_1.byte_28_E26);
        writer.Write((ushort)struct12_1.long_0_E27_28);
        writer.Write((ushort)struct12_1.long_1_E29_30);
        writer.Write((ushort)struct12_1.long_2_E31_32);
        writer.Write(struct12_1.byte_29_E33);
        writer.Write(struct12_1.byte_30_E34);
        writer.Write(struct12_1.byte_31_E35);
        writer.Write(struct12_1.byte_32_E36);
        writer.Write(struct12_1.byte_33_E37);
        writer.Write(struct12_1.byte_34_E38);
        writer.Write(struct12_1.byte_35_E39);
        writer.Write(struct12_1.byte_37_E40);
        writer.Write(struct12_1.byte_38_E41);
        writer.Write(struct12_1.byte_39_E42);
        writer.Write(struct12_1.byte_36_E43);
        writer.Write(struct12_1.byte_25_E44);
        writer.Write(struct12_1.byte_26_E45);
        writer.Write(struct12_1.byte_44_E46);
        writer.Write(struct12_1.byte_45_E47);
        writer.Write(struct12_1.byte_46_E48);
        writer.Write(struct12_1.ushort_2_E49_50);
        writer.Write(struct12_1.byte_43);
        writer.Write((ushort)struct12_1.long_6);
        writer.Write((ushort)struct12_1.long_7);
        writer.Write(struct12_1.bool_0);
        writer.Write(struct12_1.bool_1);
        writer.Write(struct12_1.bool_2);
        writer.Write(struct12_1.bool_3);
        writer.Write(struct12_1.float_0);
        writer.Write(struct12_1.bool_4);
        writer.Write(struct12_1.float_1);
        writer.Write(struct12_1.bool_5);
        writer.Write(struct12_1.float_2);
        writer.Write(struct12_1.bool_6);
        writer.Write(struct12_1.float_3);
        writer.Write(struct12_1.bool_7);
        writer.Write(struct12_1.float_4);
        writer.Write(struct12_1.bool_8);
        writer.Write(struct12_1.float_5);
        writer.Write(struct12_1.bool_9);
        writer.Write(struct12_1.float_6);
        writer.Write(struct12_1.bool_10);
        writer.Write(struct12_1.float_7);
        writer.Write(struct12_1.float_8);
        writer.Write(struct12_1.float_9);
        writer.Write(struct12_1.byte_47);
        writer.Close();
        writer = null;
        output.Close();
        output.Dispose();
        output = null;
        
        /*if (this.delegate53_0 != null)
        {
            this.delegate53_0(this.long_2, this.method_64());
        }*/
    }

    public void method_StartRecord()
    {
        if (this.method_50())
        {
            this.timer_0.Stop();
            if (this.backgroundWorker_1.IsBusy)
            {
                this.backgroundWorker_1.CancelAsync();
            }
            while (this.backgroundWorker_1.IsBusy)
            {
            }
            this.method_51(false);
            this.queue_0.Clear();
            this.method_4(DataloggingState.Connected);
            if ((this.class10_settings_0.bool_26 && !this.method_23()) && !this.method_25())
            {
                this.method_67(this.string_0);
            }
        }
        else
        {
            if (this.method_54())
            {
                string text = "Temporary datalog file found." + Environment.NewLine + "" + Environment.NewLine + "Do you want to save the file?";
                if (MessageBox.Show(text, "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false) == DialogResult.Yes)
                {
                    this.method_SaveDatalog();
                }
                else
                {
                    File.Delete(this.string_0);
                }
            }
            while ((this.queue_0.Count > 0) && this.backgroundWorker_1.IsBusy)
            {
            }
            this.queue_0.Clear();
            this.stopwatch_0.Reset();
            this.stopwatch_1.Reset();
            this.long_1 = 0L;
            this.timer_0.Start();
            this.method_51(true);
            this.method_4(DataloggingState.Recording);
        }
    }

    public bool method_54()
    {
        FileInfo info = new FileInfo(this.string_0);
        bool flag = false;
        if (info.Exists)
        {
            flag = true;
        }
        info = null;
        return flag;
    }

    public void method_SaveDatalog()
    {
        if (this.method_63_HasLogsFileOpen())
        {
            this.method_75();
        }
        FileInfo info = new FileInfo(this.string_0);
        if (info.Exists)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            /*if (Settings.Default.logFilePath != string.Empty)
            {
                if (Settings.Default.logFilePath == Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\")
                    Settings.Default.logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                Settings.Default.logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            dialog.InitialDirectory = Settings.Default.logFilePath;*/

            if (this.class10_settings_0.logFilePath != string.Empty)
            {
                if (this.class10_settings_0.logFilePath == Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\")
                    this.class10_settings_0.logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                this.class10_settings_0.logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            dialog.InitialDirectory = this.class10_settings_0.logFilePath;

            dialog.Filter = "BMTune datalog|*.bml";
            dialog.OverwritePrompt = true;
            dialog.AddExtension = true;
            dialog.DefaultExt = ".bml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info2 = new FileInfo(dialog.FileName);
                //Settings.Default.logFilePath = info2.DirectoryName;
                this.class10_settings_0.logFilePath = info2.DirectoryName;
                string fileName = dialog.FileName;
                if (File.Exists(fileName)) File.Delete(fileName);
                info.CopyTo(fileName);
                byte[] byte_99_0 = this.class18_0.method_92(File.ReadAllBytes(fileName));
                File.WriteAllBytes(fileName, byte_99_0);
                info.Delete();
            }
            dialog.Dispose();
            dialog = null;
        }
        info = null;
    }

    public void method_56()
    {
        if (this.method_63_HasLogsFileOpen())
        {
            SaveFileDialog dialog = new SaveFileDialog();
            /*if (Settings.Default.logFilePath != string.Empty)
            {
                if (Settings.Default.logFilePath == Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\")
                {
                    Settings.Default.logFilePath = Application.StartupPath;
                }
                dialog.InitialDirectory = Settings.Default.logFilePath;
            }*/
            if (this.class10_settings_0.logFilePath != string.Empty)
            {
                if (this.class10_settings_0.logFilePath == Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\")
                {
                    this.class10_settings_0.logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                dialog.InitialDirectory = this.class10_settings_0.logFilePath;
            }

            dialog.CheckFileExists = false;
            dialog.AddExtension = true;
            dialog.Filter = "CVS export|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer;
                FileInfo info = new FileInfo(dialog.FileName);
                //Settings.Default.logFilePath = info.DirectoryName;
                this.class10_settings_0.logFilePath = info.DirectoryName;
                string fileName = dialog.FileName;
                dialog.Dispose();
                dialog = null;
                try
                {
                    writer = new StreamWriter(fileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(Form.ActiveForm, exception.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    writer = null;
                    return;
                }
                writer.WriteLine("BMTune Datalog export of " + this.method_62());
                writer.WriteLine("BMTune file: " + this.class18_0.method_23());
                writer.WriteLine("Total Frames: " + this.method_65().ToString());
                writer.WriteLine("Duration :" + this.method_64());
                writer.WriteLine(this.method_59());
                foreach (Struct12 struct2 in this.list_0)
                {
                    writer.WriteLine(this.method_60(struct2));
                }
                writer.Close();
                writer.Dispose();
                writer = null;
            }
        }
    }

    private string method_57(SensorsX sensors_0)
    {
        return this.class10_settings_0.method_13(sensors_0).ToString();
    }

    private string method_58()
    {
        return CultureInfo.CurrentCulture.TextInfo.ListSeparator.ToString();
    }

    private string method_59()
    {
        return (this.method_57(SensorsX.frame) + this.method_58() + this.method_57(SensorsX.duration) + this.method_58() + this.method_57(SensorsX.rpmX) + this.method_58() + this.method_57(SensorsX.vssX) + "(" + this.class10_settings_0.vssUnits_0.ToString() + ")" + this.method_58() + this.method_57(SensorsX.gearX) + this.method_58() + this.method_57(SensorsX.mapX) + "(mBar)" + this.method_58() + this.method_57(SensorsX.boostX) + "(psi)" + this.method_58() + this.method_57(SensorsX.paX) + "(mBar)" + this.method_58() + this.method_57(SensorsX.tpsX) + "(%)" + this.method_58() + this.method_57(SensorsX.tpsV) + "(v)" + this.method_58() + this.method_57(SensorsX.injDur) + "(ms)" + this.method_58() + this.method_57(SensorsX.injDuty) + "(%)" + this.method_58() + this.method_57(SensorsX.injFV) + this.method_58() + this.method_57(SensorsX.ignTbl) + "(degrees)" + this.method_58() + this.method_57(SensorsX.ignFnl) + "(degrees)" + this.method_58() + this.method_57(SensorsX.ectX) + "(" + this.class10_settings_0.temperatureUnits_0.ToString() + ")" + this.method_58() + this.method_57(SensorsX.iatX) + "(" + this.class10_settings_0.temperatureUnits_0.ToString() + ")" + this.method_58() + this.method_57(SensorsX.afr) + this.method_58() + this.method_57(SensorsX.ecuO2V) + "(v)" + this.method_58() + this.method_57(SensorsX.batV) + "(v)" + this.method_58() + this.method_57(SensorsX.eldV) + "(v)" + this.method_58() + this.method_57(SensorsX.mapV) + "(v)" + this.method_58() + this.method_57(SensorsX.mil));
    }

    private void method_6(object sender, PowerModeChangedEventArgs e)
    {
        if (e.Mode == PowerModes.Suspend)
        {
            this.LogThis("Supsend detected and logging is connected: " + this.method_34_GetConnected().ToString());
            this.bool_0 = this.method_34_GetConnected();
            if (this.method_34_GetConnected())
            {
                this.method_36();
            }
            this.timer_1.Stop();
            this.method_20();
        }
        else if (e.Mode == PowerModes.Resume)
        {
            this.bool_0 = false;
        }
    }

    private string method_60(Struct12 struct12_1)
    {
        string str2;
        string str = (((float) struct12_1.long_3) / 1000f).ToString();
        if (this.class18_0.method_206(struct12_1.byte_4) >= this.class10_settings_0.int_6)
        {
            str2 = this.class18_0.method_245(this.class18_0.method_206(struct12_1.byte_4)).ToString();
        }
        else
        {
            str2 = "0";
        }
        int num = this.class18_0.method_218((long) struct12_1.ushort_0_E6_7);
        return string.Concat(new object[] { 
            struct12_1.long_5, this.method_58(), str, this.method_58(), num.ToString(), this.method_58(), this.class18_0.method_197(struct12_1.byte_14_E16).ToString(), this.method_58(), struct12_1.byte_20.ToString(), this.method_58(), this.class18_0.method_206(struct12_1.byte_4).ToString(), this.method_58(), str2, this.method_58(), this.class18_0.method_206(struct12_1.byte_3).ToString(), this.method_58(), 
            this.class18_0.method_198(struct12_1.byte_5).ToString(), this.method_58(), this.class18_0.method_196(struct12_1.byte_5).ToString("0.00"), this.method_58(), this.class18_0.method_224((int) this.class18_0.method_223(struct12_1.ushort_1_E17_18)).ToString("0.00"), this.method_58(), this.class18_0.method_225((int) this.class18_0.method_223(struct12_1.ushort_1_E17_18), num, 0).ToString("0.00"), this.method_58(), this.class18_0.method_223(struct12_1.ushort_1_E17_18).ToString("0.00"), this.method_58(), this.class18_0.method_188(struct12_1.byte_16_E20).ToString("0.00"), this.method_58(), this.class18_0.method_188(struct12_1.byte_15_E19).ToString("0.00"), this.method_58(), this.class18_0.method_191(struct12_1.byte_0).ToString("0"), this.method_58(), 
            this.class18_0.method_191(struct12_1.byte_1).ToString("0"), this.method_58(), this.class18_0.method_200(struct12_1.byte_43).ToString("0.00"), this.method_58(), this.class18_0.method_196(struct12_1.byte_2).ToString("0.00"), this.method_58(), this.class18_0.method_208(struct12_1.byte_27_E25).ToString("0.00"), this.method_58(), this.class18_0.method_196(struct12_1.byte_24_E24).ToString("0.00"), this.method_58(), this.class18_0.method_196(struct12_1.byte_4).ToString("0.00"), this.method_58(), this.method_61(struct12_1.byte_19)
         });
    }

    private string method_61(byte byte_1)
    {
        if (byte_1 == 0)
        {
            return "OFF";
        }
        return "ON";
    }

    public string method_62()
    {
        FileInfo info = new FileInfo(this.string_2);
        string name = info.Name;
        info = null;
        return name;
    }

    public bool method_63_HasLogsFileOpen()
    {
        return this.bool_6;
    }

    public string method_64()
    {
        if (this.method_63_HasLogsFileOpen() || this.method_50())
        {
            string str = TimeSpan.FromMilliseconds((double)this.long_3).ToString();
            //string str = TimeSpan.FromMilliseconds((double) 0).ToString();
            return str.Remove(str.Length - 4, 4);
        }
        return "";
    }

    public long method_65()
    {
        if (this.method_34_GetConnected() && !this.method_63_HasLogsFileOpen())
        {
            this.long_2 = this.FrameCounts;
            //this.long_2 = ((((this.FrameCounts * 51) + 0x7b) + 0x10L)) * (0x7b + 1);
            //this.long_2 = ((int)((writer.BaseStream.Length - 0x7b) - 0x10L)) / (0x7b + 1);
            return this.long_2;
        }
        
        //if (!this.method_63() && !this.method_34())
        if (!this.method_63_HasLogsFileOpen())
        {
            this.class18_0.class17_0.frmMain_0.LogThis("log not open or not logging");
            //throw new Exception("log not open or not logging");
        }
        if (this.long_2 == 0L)
        {
            this.class18_0.class17_0.frmMain_0.LogThis("log file open and frame max is 0");
            //throw new Exception("log file open and frame max is 0");
        }

        return this.long_2;
    }

    public void method_OpenLog()
    {
        if (this.backgroundWorker_0.IsBusy)
        {
            this.backgroundWorker_0.CancelAsync();
        }
        while (this.backgroundWorker_0.IsBusy)
        {
            Application.DoEvents();
        }
        OpenFileDialog dialog = new OpenFileDialog();
        if (this.class10_settings_0.logFilePath == string.Empty) this.class10_settings_0.logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        if (this.class10_settings_0.logFilePath.Contains(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))) this.class10_settings_0.logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        dialog.InitialDirectory = this.class10_settings_0.logFilePath;

        dialog.Filter = "BMTune datalog|*.bml|eCtune datalog|*.elf|HTS datalog|*.log;*.rlog|All files (*.*)|*.*";
        dialog.DefaultExt = ".bml";
        dialog.CheckFileExists = true;
        dialog.CheckPathExists = true;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (this.method_3() == DataloggingState.PlayingF)
            {
                this.method_71();
                this.method_75();
                GC.Collect(3, GCCollectionMode.Forced);
            }

            //Open bmtune datalog files
            string path = "";
            if (dialog.FilterIndex == 1)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\" + Path.GetFileName(dialog.FileName);
                byte[] byte_99_0 = this.class18_0.method_93(File.ReadAllBytes(dialog.FileName));
                File.WriteAllBytes(path, byte_99_0);
            }
            //Open eCtune datalog files
            if (dialog.FilterIndex == 2)
            {
                path = dialog.FileName;
            }
            if (dialog.FilterIndex == 3 || dialog.FilterIndex == 4)
            {
                string extension = Path.GetExtension(dialog.FileName);
                if (extension == ".bml")
                {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\" + Path.GetFileName(dialog.FileName);
                    byte[] byte_99_0 = this.class18_0.method_93(File.ReadAllBytes(dialog.FileName));
                    File.WriteAllBytes(path, byte_99_0);
                }
                if (extension == ".elf")
                {
                    path = dialog.FileName;
                }
                if (extension == ".rlog")
                {
                    string str = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BMTune\\";
                    if (File.Exists(str + "PROG")) File.Delete(str + "PROG");
                    if (File.Exists(str + "DL")) File.Delete(str + "DL");
                    if (File.Exists(str + "SET")) File.Delete(str + "SET");
                    if (File.Exists(str + "OLDSET")) File.Delete(str + "OLDSET");

                    //File.Create(str + "OLDSET").Dispose();
                    //this.class10_settings_0.method_3();
                    //File.WriteAllBytes(str + "OLDSET", File.ReadAllBytes(this.class10_settings_0.path));
                    if (File.Exists(dialog.FileName))
                    {
                        using (FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open))
                        {
                            using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read))
                            {
                                foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                                {
                                    using (Stream stream = zipArchiveEntry.Open())
                                    {
                                        using (BinaryReader binaryReader = new BinaryReader(stream))
                                        {
                                            using (FileStream fileStream2 = new FileStream(str + zipArchiveEntry.Name.ToString(), FileMode.CreateNew))
                                            {
                                                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream2))
                                                {
                                                    binaryWriter.Write(binaryReader.ReadBytes((int)zipArchiveEntry.Length));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //this.class10_settings_0.LoadSettings(str + "SET");
                    //this.class10_settings_0.method_2();
                    //this.class18_0.method_195(str + "PROG");
                    //dialog.FileName = str + "DL";
                }

                //final HTS datalog loading
                if (extension == ".rlog" || extension == ".log")
                {
                    string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BMTune\\" + Path.GetFileName(dialog.FileName);
                    byte[] bytes = this.class18_0.method_246_HTSCrypter(File.ReadAllBytes(dialog.FileName));
                    File.WriteAllBytes(text, bytes);
                    path = text;
                }
            }

            this.class10_settings_0.logFilePath = Path.GetDirectoryName(dialog.FileName);
            this.string_2 = path;
            this.method_67(path);
            if (this.class10_settings_0.bool_7) this.method_70();
            if (File.Exists(path)) File.Delete(path);
        }
        dialog.Dispose();
        dialog = null;
    }

    public void method_67(string string_3)
    {
        if (!this.bool_17)
        {
            if (this.method_63_HasLogsFileOpen())
            {
                this.method_75();
            }
            this.string_2 = string_3;
            this.bool_17 = true;    //set loading
            this.method_4(DataloggingState.Loading);
            this.thread_2 = new Thread(new ThreadStart(this.method_68));
            this.thread_2.Priority = ThreadPriority.Highest;
            this.thread_2.Start();
            while (this.thread_2.IsAlive)
            {
                Application.DoEvents();
            }
            this.bool_6 = true;
            this.long_1 = 0L;
            if (this.delegate53_0 != null)
            {
                this.delegate53_0(this.long_2, this.method_64());
            }
            this.struct12_0 = this.method_76(0L);
            this.method_39();
            this.bool_17 = false;  //set loading
            if (this.class10_settings_0.bool_7)
            {
                this.method_70();   //play log on open
            }
        }
    }

    public void method_68()
    {
        this.list_1.Clear();
        int num = 0x3a;
        string str = null;
        this.int_1 = 0;
        bool flag = false;
        if (this.backgroundWorker_0.IsBusy)
        {
            this.backgroundWorker_0.CancelAsync();
        }
        while (this.backgroundWorker_0.IsBusy)
        {
            Application.DoEvents();
        }
        this.fileStream_0 = new FileStream(this.string_2, FileMode.Open, FileAccess.Read);
        try
        {
            if (this.fileStream_0 != null)
            {
                this.fileStream_0.Dispose();
                this.fileStream_0 = null;
            }
            this.fileStream_0 = new FileStream(this.string_2, FileMode.Open, FileAccess.Read);
            if (this.binaryReader_0 != null)
            {
                this.binaryReader_0.Close();
                this.binaryReader_0 = null;
            }
            this.binaryReader_0 = new BinaryReader(this.fileStream_0);
            try
            {
                for (int j = 0; j < 10; j++)
                {
                    str = str + this.binaryReader_0.ReadChar().ToString();
                }
            }
            catch (Exception)
            {
            }
            if (str == "BMTune.bml" || str == "eCtune.dlf" || str == "DATALOGGER")
            {
                flag = true;
                this.binaryReader_0.BaseStream.Position = 10L;
                this.int_1 = this.binaryReader_0.ReadUInt16();
                num = this.binaryReader_0.ReadByte();
                this.binaryReader_0.ReadInt32();

                /*
                int num2 = 6;
                int num3 = 0x7b;
                int num = 0;
                */
            }


            if (flag) this.long_2 = ((int) ((this.binaryReader_0.BaseStream.Length - num) - 0x10L)) / (num + 1);
            else this.long_2 = (((int) this.binaryReader_0.BaseStream.Length) - num) / (num + 1);

            if (this.list_0 != null) this.list_0 = null;
            int num3 = 0;
            this.list_0 = new List<Struct12>();
            Struct12 item = new Struct12();
            bool FileLoadingError = false;
            for (int i = 0; i <= this.long_2; i++)
            {
                try
                {
                    if (flag)
                    {
                        this.binaryReader_0.BaseStream.Position = 0x11 + (i * (num + 1));
                    }
                    else
                    {
                        this.binaryReader_0.BaseStream.Position = i * (num + 1);
                    }
                    item.long_5 = i;
                    item.byte_0 = this.binaryReader_0.ReadByte();
                    item.byte_1 = this.binaryReader_0.ReadByte();
                    item.byte_2 = this.binaryReader_0.ReadByte();
                    item.byte_3 = this.binaryReader_0.ReadByte();
                    item.byte_4 = this.binaryReader_0.ReadByte();
                    item.byte_5 = this.binaryReader_0.ReadByte();
                    item.ushort_0_E6_7 = this.binaryReader_0.ReadUInt16();
                    item.byte_6_E8 = this.binaryReader_0.ReadByte();
                    item.byte_7_E9 = this.binaryReader_0.ReadByte();
                    item.byte_8_E10 = this.binaryReader_0.ReadByte();
                    item.byte_9_E11 = this.binaryReader_0.ReadByte();
                    item.byte_10_E12 = this.binaryReader_0.ReadByte();
                    item.byte_11_E13 = this.binaryReader_0.ReadByte();
                    item.byte_12_E14 = this.binaryReader_0.ReadByte();
                    item.byte_13_E15 = this.binaryReader_0.ReadByte();
                    item.byte_14_E16 = this.binaryReader_0.ReadByte();
                    item.ushort_1_E17_18 = this.binaryReader_0.ReadUInt16();
                    item.byte_15_E19 = this.binaryReader_0.ReadByte();
                    item.byte_16_E20 = this.binaryReader_0.ReadByte();
                    item.byte_20 = this.class18_0.method_215(item.byte_14_E16, (long) item.ushort_0_E6_7);
                    item.byte_21_E21 = this.binaryReader_0.ReadByte();
                    item.byte_22_E22 = this.binaryReader_0.ReadByte();
                    item.byte_23_E23 = this.binaryReader_0.ReadByte();
                    item.byte_24_E24 = this.binaryReader_0.ReadByte();
                    item.byte_27_E25 = this.binaryReader_0.ReadByte();
                    item.long_3 = this.binaryReader_0.ReadInt64() - this.long_4;
                    item.long_4 = this.binaryReader_0.ReadInt64();
                    item.byte_28_E26 = this.binaryReader_0.ReadByte();
                    item.long_0_E27_28 = this.binaryReader_0.ReadUInt16();
                    item.long_1_E29_30 = this.binaryReader_0.ReadUInt16();
                    item.long_2_E31_32 = this.binaryReader_0.ReadUInt16();
                    item.byte_29_E33 = this.binaryReader_0.ReadByte();
                    item.byte_30_E34 = this.binaryReader_0.ReadByte();
                    item.byte_31_E35 = this.binaryReader_0.ReadByte();
                    item.byte_32_E36 = this.binaryReader_0.ReadByte();
                    item.byte_33_E37 = this.binaryReader_0.ReadByte();
                    item.byte_34_E38 = this.binaryReader_0.ReadByte();
                    item.byte_35_E39 = this.binaryReader_0.ReadByte();
                    item.byte_37_E40 = this.binaryReader_0.ReadByte();
                    item.byte_38_E41 = this.binaryReader_0.ReadByte();
                    item.byte_39_E42 = this.binaryReader_0.ReadByte();
                    item.byte_40 = item.byte_24_E24;
                    if (this.int_1 > 1)
                    {
                        item.byte_36_E43 = this.binaryReader_0.ReadByte();
                        item.byte_25_E44 = this.binaryReader_0.ReadByte();
                        item.byte_26_E45 = this.binaryReader_0.ReadByte();
                        item.byte_44_E46 = this.binaryReader_0.ReadByte();
                        item.byte_45_E47 = this.binaryReader_0.ReadByte();
                        item.byte_46_E48 = this.binaryReader_0.ReadByte();
                        item.ushort_2_E49_50 = this.binaryReader_0.ReadUInt16();
                    }
                    item.byte_41 = item.byte_25_E44;
                    item.byte_42 = item.byte_26_E45;
                    if (this.int_1 > 2)
                    {
                        item.byte_43 = this.binaryReader_0.ReadByte();
                    }
                    else
                    {
                        switch (this.class10_settings_0.wbinput_0)
                        {
                            case WBinput.o2Input:
                                item.byte_43 = item.byte_2;
                                goto Label_061C;

                            case WBinput.eldInput:
                                item.byte_43 = item.byte_24_E24;
                                goto Label_061C;

                            case WBinput.egrInput:
                                item.byte_43 = item.byte_25_E44;
                                goto Label_061C;

                            case WBinput.b6Input:
                                item.byte_43 = item.byte_26_E45;
                                goto Label_061C;
                        }

                        this.class18_0.class17_0.frmMain_0.LogThis("wideband input error in selection");
                        item.byte_43 = item.byte_2;
                        goto Label_061C;
                        //throw new Exception("wideband input error in selection");
                    }
                Label_061C:
                    if (this.int_1 > 3)
                    {
                        item.long_6 = this.binaryReader_0.ReadUInt16();
                        item.long_7 = this.binaryReader_0.ReadUInt16();
                    }
                    if (this.int_1 <= 4)
                    {
                        float num5 = 0f;
                        item.bool_0 = this.class10_settings_0.bool_36 && !this.method_88(AnalogInputs.analog1);
                        item.bool_1 = this.class10_settings_0.bool_38 && !this.method_88(AnalogInputs.analog2);
                        item.bool_2 = this.class10_settings_0.bool_40 && !this.method_88(AnalogInputs.analog3);
                        item.bool_3 = this.method_86(SensorsX.egt_cht1);
                        if (this.method_87(SensorsX.egt_cht1))
                        {
                            if (this.class10_settings_0.int_55 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_55 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_55 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        item.float_0 = num5;
                        item.bool_4 = this.method_86(SensorsX.egt_cht2);
                        if (this.method_87(SensorsX.egt_cht2))
                        {
                            if (this.class10_settings_0.int_56 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_56 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_56 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        this.struct12_0.float_1 = num5;
                        item.bool_5 = this.method_86(SensorsX.egt_cht3);
                        if (this.method_87(SensorsX.egt_cht3))
                        {
                            if (this.class10_settings_0.int_57 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_57 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_57 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        item.float_2 = num5;
                        item.bool_6 = this.method_86(SensorsX.egt_cht4);
                        if (this.method_87(SensorsX.egt_cht4))
                        {
                            if (this.class10_settings_0.int_58 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_58 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_58 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        item.float_3 = num5;
                        item.bool_7 = this.method_86(SensorsX.egt_chtAvg);
                        if (this.method_87(SensorsX.egt_chtAvg))
                        {
                            if (this.class10_settings_0.int_59 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_59 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_59 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        item.float_4 = num5;
                        item.bool_8 = this.method_86(SensorsX.backPres);
                        if (this.method_87(SensorsX.backPres))
                        {
                            if (this.class10_settings_0.int_60 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_60 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_60 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        item.float_5 = num5;
                        item.bool_9 = this.method_86(SensorsX.fuelPres);
                        if (this.method_87(SensorsX.fuelPres))
                        {
                            if (this.class10_settings_0.int_61 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_61 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_61 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        item.float_6 = num5;
                        item.bool_10 = this.method_86(SensorsX.iat2);
                        if (this.method_87(SensorsX.iat2))
                        {
                            if (this.class10_settings_0.int_62 == 1)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog1, item.byte_40);
                            }
                            else if (this.class10_settings_0.int_62 == 2)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog2, item.byte_41);
                            }
                            else if (this.class10_settings_0.int_62 == 3)
                            {
                                num5 = this.class18_0.method_201(AnalogInputs.analog3, item.byte_42);
                            }
                        }
                        item.float_7 = num5;
                    }
                    if (this.int_1 >= 6)
                    {
                        item.byte_47 = this.binaryReader_0.ReadByte();
                    }
                    num3++;
                    this.list_0.Add(item);
                    this.struct23_0.bool_0 = this.class18_0.method_258(item.byte_6_E8, 3);
                    this.struct23_0.bool_1 = this.class18_0.method_258(item.byte_35_E39, 5);
                    if (item.byte_9_E11 > (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
                    {
                        item.byte_9_E11 = (byte) (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1);
                    }
                    if (this.struct23_0.bool_0)
                    {
                        this.struct23_0.struct24_0.int_0 = item.byte_8_E10;
                        this.struct23_0.float_0 = ((float) item.byte_45_E47) / 255f;
                    }
                    else
                    {
                        this.struct23_0.struct24_0.int_0 = item.byte_7_E9;
                        this.struct23_0.float_0 = ((float) item.byte_44_E46) / 255f;
                    }
                    this.struct23_0.float_1 = ((float) item.byte_46_E48) / 255f;
                    this.struct23_0.struct24_0.int_1 = item.byte_9_E11;
                    this.struct23_0.struct24_1 = this.struct23_0.struct24_0;
                    if (this.struct23_0.float_0 >= 0.5) this.struct23_0.struct24_1.int_0++;
                    if (this.struct23_0.float_1 >= 0.5) this.struct23_0.struct24_1.int_1++;
                    item.struct24_0 = this.struct23_0.struct24_1;
                    this.struct23_0.struct24_2 = this.struct23_0.struct24_0;
                    this.struct23_0.method_0(this.struct23_0.struct24_0, ref this.class10_settings_0);
                    this.struct23_0.byte_0 = this.struct12_0.byte_43;
                    bool flag2 = this.class18_0.method_258(item.byte_6_E8, 4) || this.class18_0.method_258(item.byte_6_E8, 5);
                    this.struct17_0.bool_0 = this.struct23_0.bool_0;
                    this.struct17_0.bool_1 = this.struct23_0.bool_1;
                    if (this.class10_settings_0.bool_48)
                    {
                        this.struct17_0.bool_2 = flag2;
                    }
                    else
                    {
                        this.struct17_0.bool_2 = false;
                    }
                    this.struct17_0.struct24_0.int_0 = this.struct23_0.struct24_0.int_0;
                    this.struct17_0.struct24_0.int_1 = this.struct23_0.struct24_0.int_1;
                    this.struct17_0.float_0 = this.struct23_0.float_0;
                    this.struct17_0.float_1 = this.struct23_0.float_1;
                    this.struct17_0.struct24_1 = this.struct23_0.struct24_1;
                    this.struct17_0.method_1(this.struct17_0.struct24_0, ref this.class18_0);
                    this.struct17_0.byte_0 = item.byte_43;
                    this.struct17_0.long_1 = item.ushort_0_E6_7;
                    this.struct17_0.byte_2 = item.byte_4;
                    this.struct17_0.byte_1 = item.byte_5;
                    this.struct17_0.byte_3 = item.byte_0;
                    this.struct17_0.byte_4 = item.byte_1;
                    this.struct17_0.byte_5 = item.byte_20;
                    this.struct17_0.long_0 = item.long_3;
                    if (num3 == (this.class10_settings_0.int_25 + 1))
                    {
                        num3 = 0;
                        if (this.delegate48_0 != null)
                        {
                            this.delegate48_0(item);
                        }
                        if (this.delegate47_0 != null)
                        {
                            this.delegate47_0(this.struct17_0);
                        }
                        if (this.delegate50_0 != null)
                        {
                            this.delegate50_0(item);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(Form.ActiveForm, exception.Message);
                    i = (int) this.long_2;
                    FileLoadingError = true;
                }
            }
            if (!FileLoadingError)
            {
                this.long_3 = this.method_76(this.long_2).long_3;
                this.struct12_0 = this.method_76(0L);
                this.method_39();
            }
        }
        catch (Exception exception2)
        {
            MessageBox.Show(Form.ActiveForm, "Error getting maxframe from log :" + exception2.ToString());
        }
        if (this.binaryReader_0 != null)
        {
            this.binaryReader_0.Close();
            this.binaryReader_0 = null;
        }
        if (this.fileStream_0 != null)
        {
            this.fileStream_0.Close();
            this.fileStream_0.Dispose();
            this.fileStream_0 = null;
        }
        /*if (this.int_1 > 1)   //load markers
        {
            this.method_83(this.string_2);
        }*/
        //REMOVE LOADING FILESTREAM HERE
        if (File.Exists(this.string_2)) File.Delete(this.string_2);
        this.method_4(DataloggingState.Disconnected);
    }

    public void method_69(long long_5)
    {
        this.struct12_0 = this.method_76(long_5);
        this.long_1 = long_5;
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_40_SendBytes_Delegate();
        }
    }

    public byte method_7()
    {
        byte num = 0;
        if (!FakeDatalog)
        {
            //if (this.method_12(1)) num = (byte)this.serialPort_0.ReadByte();
            //num = (byte)this.serialPort_0.ReadByte();
            try
            {
                num = (byte)this.serialPort_0.ReadByte();    //here for datalog disconnected issue with bluetooth
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        return num;
    }

    //Datalog Play Button Clic
    public void method_70()
    {
        if ((this.thread_0 == null) || (this.thread_0.ThreadState == System.Threading.ThreadState.Stopped))
        {
            this.thread_0 = new Thread(new ThreadStart(this.method_81));
            this.thread_0.Name = "Log Player";
            this.thread_0.Priority = ThreadPriority.AboveNormal;
            this.thread_0.Start();
        }
        if (this.thread_0.ThreadState == System.Threading.ThreadState.Suspended)
        {
            this.thread_0.Resume();
        }
        this.bool_8 = false;
        this.method_4(DataloggingState.PlayingF);
        GC.Collect(3, GCCollectionMode.Optimized);
    }

    public void method_71()
    {
        this.long_1 = 0L;
        this.int_2 = 0;
        this.struct12_0 = this.method_76(0L);
        this.method_4(DataloggingState.Stop);
        this.bool_8 = false;
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_39();
        }
        if (this.thread_0 != null)
        {
            if (this.thread_0.IsAlive)
            {
                if (this.thread_0.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    this.thread_0.Resume();
                }
                this.thread_0.Abort();
                this.thread_0 = null;
            }
            this.thread_0 = null;
        }
        GC.Collect(3, GCCollectionMode.Forced);
    }

    public void method_72()
    {
        if ((this.thread_0 != null) && this.thread_0.IsAlive)
        {
            this.thread_0.Suspend();
            this.method_4(DataloggingState.Pause);
        }
        GC.Collect(3, GCCollectionMode.Forced);
    }

    public void method_73()
    {
        this.bool_7 = !this.bool_7;
    }

    public bool method_73_0()
    {
        return this.bool_7;
    }

    public void method_73_1()
    {
        this.bool_71 = !this.bool_71;
        this.bool_7 = false;
        this.bool_72 = false;
    }

    public void method_73_2()
    {
        this.bool_7 = false;
        this.bool_71 = false;
        this.bool_72 = !this.bool_72;
    }

    public void method_74()
    {
        if (this.long_1 != 0L)
        {
            this.bool_8 = !this.bool_8;
            if (this.thread_0 == null)
            {
                this.thread_0 = new Thread(new ThreadStart(this.method_81));
                this.thread_0.Name = "Log Player";
                this.thread_0.Priority = ThreadPriority.AboveNormal;
                this.thread_0.Start();
            }
            if (this.thread_0.ThreadState == System.Threading.ThreadState.Suspended)
            {
                this.thread_0.Resume();
            }
            this.method_4(DataloggingState.PlayingR);
        }
    }

    public void method_75()
    {
        string str = this.string_2;
        if ((this.thread_0 != null) && this.thread_0.IsAlive)
        {
            this.method_71();
        }
        this.string_2 = null;
        if (this.binaryReader_0 != null)
        {
            this.binaryReader_0.Close();
            this.binaryReader_0 = null;
        }
        if (this.fileStream_0 != null)
        {
            this.fileStream_0.Close();
            this.fileStream_0.Dispose();
            this.fileStream_0 = null;
        }
        /*if (!string.IsNullOrEmpty(str))   //save markers
        {
            this.method_82(str);
        }*/
        //REMOVE LOADING FILESTREAM HERE
        if (File.Exists(this.string_2)) File.Delete(this.string_2);
        this.list_1.Clear();
        if (this.list_0 != null) this.list_0 = null;
        this.bool_6 = false;
        if (this.delegate53_0 != null)
        {
            this.delegate53_0(0L, string.Empty);
        }
        this.method_4(DataloggingState.Disconnected);
        this.long_4 = 0L;
        this.long_3 = 0L;
        this.long_2 = 0L;
        this.int_1 = 0;
        this.FrameCounts = 0L;
        GC.Collect(1, GCCollectionMode.Forced);
    }

    private Struct12 method_76(long long_5)
    {
        if ((this.list_0 == null) || (long_5 > this.long_2))
        {
            return new Struct12();
        }
        if (long_5 > this.long_2)
        {
            long_5 = this.long_2;
        }
        this.struct12_0 = this.list_0[(int) long_5];
        if (this.class10_settings_0.bool_23 && (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_50) == 0))
        {
            if (this.struct12_0.byte_3 != 0)
            {
                int num = (int) Math.Round((double) ((((this.struct12_0.byte_3 / 2) + 0x18) * 7.221) - 59.0), 0);
                if (this.class10_settings_0.int_6 != num)
                {
                    this.class10_settings_0.int_6 = num;
                }
            }
            else
            {
                this.class10_settings_0.int_6 = 0x3f2;
            }
        }
        this.struct23_0.bool_0 = this.class18_0.method_258(this.struct12_0.byte_6_E8, 3);
        this.struct23_0.bool_1 = this.class18_0.method_258(this.struct12_0.byte_35_E39, 5);
        if (this.struct12_0.byte_9_E11 > (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
        {
            this.struct12_0.byte_9_E11 = (byte) (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1);
        }
        if (this.struct23_0.bool_0)
        {
            this.struct23_0.struct24_0.int_0 = this.struct12_0.byte_8_E10;
            this.struct23_0.float_0 = ((float) this.struct12_0.byte_45_E47) / 255f;
        }
        else
        {
            this.struct23_0.struct24_0.int_0 = this.struct12_0.byte_7_E9;
            this.struct23_0.float_0 = ((float) this.struct12_0.byte_44_E46) / 255f;
        }
        this.struct23_0.float_1 = ((float) this.struct12_0.byte_46_E48) / 255f;
        this.struct23_0.struct24_0.int_1 = this.struct12_0.byte_9_E11;
        this.struct23_0.struct24_1 = this.struct23_0.struct24_0;
        if (this.struct23_0.float_0 >= 0.5)
        {
            this.struct23_0.struct24_1.int_0++;
        }
        if (this.struct23_0.float_1 >= 0.5)
        {
            this.struct23_0.struct24_1.int_1++;
        }
        this.struct12_0.struct24_0 = this.struct23_0.struct24_1;
        this.struct23_0.struct24_2 = this.struct23_0.struct24_0;
        this.struct23_0.method_0(this.struct23_0.struct24_0, ref this.class10_settings_0);
        this.struct23_0.byte_0 = this.struct12_0.byte_43;
        bool flag = this.class18_0.method_258(this.struct12_0.byte_6_E8, 4) || this.class18_0.method_258(this.struct12_0.byte_6_E8, 5);
        this.struct17_0.bool_0 = this.struct23_0.bool_0;
        this.struct12_0.bool_11 = this.struct23_0.bool_0;
        this.struct17_0.bool_1 = this.struct23_0.bool_1;
        if (this.class10_settings_0.bool_48)
        {
            this.struct17_0.bool_2 = flag;
        }
        else
        {
            this.struct17_0.bool_2 = false;
        }
        this.struct12_0.bool_12 = this.struct23_0.bool_1;
        this.struct17_0.struct24_0.int_0 = this.struct23_0.struct24_0.int_0;
        this.struct17_0.struct24_0.int_1 = this.struct23_0.struct24_0.int_1;
        this.struct17_0.float_0 = this.struct23_0.float_0;
        this.struct17_0.float_1 = this.struct23_0.float_1;
        this.struct17_0.method_1(this.struct17_0.struct24_0, ref this.class18_0);
        this.struct17_0.struct24_1 = this.struct23_0.struct24_1;
        this.struct17_0.byte_0 = this.struct12_0.byte_43;
        this.struct17_0.long_1 = this.struct12_0.ushort_0_E6_7;
        this.struct17_0.byte_2 = this.struct12_0.byte_4;
        this.struct17_0.byte_1 = this.struct12_0.byte_5;
        this.struct17_0.byte_3 = this.struct12_0.byte_0;
        this.struct17_0.byte_4 = this.struct12_0.byte_1;
        this.struct17_0.byte_5 = this.struct12_0.byte_20;
        this.struct17_0.long_0 = this.struct12_0.long_3;
        if (this.delegate47_0 != null)
        {
            this.delegate47_0(this.struct17_0);
        }
        if (this.delegate50_0 != null)
        {
            this.delegate50_0(this.struct12_0);
        }
        this.struct20_0.byte_0 = this.struct12_0.byte_10_E12;
        this.struct20_0.byte_1 = this.struct12_0.byte_11_E13;
        this.struct20_0.byte_2 = this.struct12_0.byte_12_E14;
        this.struct20_0.byte_3 = this.struct12_0.byte_13_E15;
        if (((this.struct20_0.byte_0 != 0) || (this.struct20_0.byte_1 != 0)) || ((this.struct20_0.byte_2 != 0) || (this.struct20_0.byte_3 != 0)))
        {
            this.struct12_0.byte_19 = 1;
        }
        else
        {
            this.struct12_0.byte_19 = 0;
        }
        return this.struct12_0;
    }

    public float method_77(SensorsX sensors_0, int int_3)
    {
        float num = 0f;
        if (int_3 < 0 || int_3 > this.list_0.Count - 1)
        {
            return num;
        }

        switch (sensors_0)
        {
            case SensorsX.rpmX:
                return (float) this.class18_0.method_218((long) this.list_0[int_3].ushort_0_E6_7);

            case SensorsX.vssX:
                return (float) this.class18_0.method_197(this.list_0[int_3].byte_14_E16);

            case SensorsX.gearX:
                return (float) this.list_0[int_3].byte_20;

            case SensorsX.mapX:
                return (float) this.class18_0.method_206(this.list_0[int_3].byte_4);

            case SensorsX.boostX:
                if (this.class18_0.method_206(this.list_0[int_3].byte_4) <= this.class10_settings_0.int_6)
                {
                    return 0f;
                }
                return this.class18_0.method_193(this.list_0[int_3].byte_4);

            case SensorsX.paX:
                return (float) ((int) Math.Round((double) ((((this.list_0[int_3].byte_3 / 2) + 0x18) * 7.221) - 59.0), 0));

            case SensorsX.tpsX:
                return (float) this.class18_0.method_198(this.list_0[int_3].byte_5);

            case SensorsX.tpsV:
                return (float) this.class18_0.method_196(this.list_0[int_3].byte_5);

            case SensorsX.injDur:
                return (float) Math.Round((double) this.class18_0.method_224(this.list_0[int_3].ushort_1_E17_18), 2);

            case SensorsX.injDuty:
                return (float) Math.Round((double) this.class18_0.method_225(this.list_0[int_3].ushort_1_E17_18, this.class18_0.method_218((long) this.list_0[int_3].ushort_0_E6_7), 0), 0);

            case SensorsX.injFV:
                return (float) this.class18_0.method_223(this.list_0[int_3].ushort_1_E17_18);

            case SensorsX.ignFnl:
                return this.class18_0.method_188(this.list_0[int_3].byte_15_E19);

            case SensorsX.ignTbl:
                return this.class18_0.method_188(this.list_0[int_3].byte_16_E20);

            case SensorsX.ectX:
                return (float) this.class18_0.method_191(this.list_0[int_3].byte_0);

            case SensorsX.iatX:
                return (float) this.class18_0.method_191(this.list_0[int_3].byte_1);

            case SensorsX.afr:
                return (float) this.class18_0.method_200(this.list_0[int_3].byte_43);

            case SensorsX.ecuO2V:
                return (float) this.class18_0.method_196(this.list_0[int_3].byte_2);

            case SensorsX.wbO2V:
                return (float) this.class18_0.method_200(this.list_0[int_3].byte_43);

            case SensorsX.batV:
                return (float) this.class18_0.method_208(this.list_0[int_3].byte_27_E25);

            case SensorsX.eldV:
                return (float) this.class18_0.method_196(this.list_0[int_3].byte_24_E24);

            case SensorsX.knockV:
            case SensorsX.mil:
            case SensorsX.frame:
            case SensorsX.interval:
            case SensorsX.loadType:
            case SensorsX.overheatActive:
            case SensorsX.test0:
                return num;

            case SensorsX.mapV:
                return (float) this.class18_0.method_196(this.list_0[int_3].byte_4);

            case SensorsX.duration:
                //if (this.method_34() && !this.method_63()) this.long_2 = this.FrameCounts;
                return (float) this.list_0[int_3].long_3;

            case SensorsX.ectFc:
                return (float) this.class18_0.method_205(this.list_0[int_3].byte_28_E26, Enum6.const_1);

            case SensorsX.iatFc:
                return (float) this.class18_0.method_203(this.list_0[int_3].long_2_E31_32, Enum6.const_0);

            case SensorsX.o2Short:
                return (float) this.class18_0.method_203(this.list_0[int_3].long_0_E27_28, Enum6.const_0);

            case SensorsX.o2Long:
                return (float) this.class18_0.method_203(this.list_0[int_3].long_1_E29_30, Enum6.const_0);

            case SensorsX.veFc:
                return (float) this.class18_0.method_205(this.list_0[int_3].byte_29_E33, Enum6.const_1);

            case SensorsX.ectIc:
                return this.class18_0.method_189(this.list_0[int_3].byte_31_E35);

            case SensorsX.iatIc:
                return this.class18_0.method_189(this.list_0[int_3].byte_30_E34);

            case SensorsX.gearIc:
                return this.class18_0.method_189(this.list_0[int_3].byte_32_E36);

            case SensorsX.gearFc:
                return (float) this.list_0[int_3].byte_29_E33;

            case SensorsX.postFuel:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_6_E8, 0, false);

            case SensorsX.outIab:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_22_E22, 2, false);

            case SensorsX.outVtsX:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_23_E23, 7, false);

            case SensorsX.outVtsM:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_6_E8, 3, false);

            case SensorsX.outAc:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_22_E22, 7, false);

            case SensorsX.outO2h:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_23_E23, 6, false);

            case SensorsX.outMil:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_23_E23, 5, false);

            case SensorsX.outPurge:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_22_E22, 6, false);

            case SensorsX.outFanc:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_22_E22, 4, false);

            case SensorsX.outFpump:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_22_E22, 0, false);

            case SensorsX.outFuelCut:
                if (!this.class18_0.method_258(this.list_0[int_3].byte_6_E8, 4) && !this.class18_0.method_258(this.list_0[int_3].byte_6_E8, 5))
                {
                    return 0f;
                }
                return 1f;

            case SensorsX.outAltCtrl:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_22_E22, 5, false);

            case SensorsX.inPsp:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 7, false);

            case SensorsX.inSCC:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 5, false);

            case SensorsX.inAccs:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 2, false);

            case SensorsX.inBksw:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 1, false);

            case SensorsX.inVtp:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 3, false);

            case SensorsX.inVtsFeedBack:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 6, false);

            case SensorsX.inParkN:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 0, false);

            case SensorsX.inStartS:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_21_E21, 4, false);

            case SensorsX.inAtShift1:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_6_E8, 6, false);

            case SensorsX.inAtShift2:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_6_E8, 7, false);

            case SensorsX.secMaps:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 5, false);

            case SensorsX.ftlInput:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 0, false);

            case SensorsX.ftlActive:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 0, false);

            case SensorsX.ftsClutchInput:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 1, false);

            case SensorsX.ftsActive:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 2, false);

            case SensorsX.boostcutActive:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 3, false);

            case SensorsX.antilagActive:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 1, false);

            case SensorsX.ignitionCut:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_6_E8, 2, false);

            case SensorsX.sccChecker:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_6_E8, 1, false);

            case SensorsX.ebcInput:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 2, false);

            case SensorsX.ebcHiInput:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 3, false);

            case SensorsX.ebcActive:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 4, false);

            case SensorsX.ebcBaseDuty:
                return (float) this.class18_0.method_207(this.list_0[int_3].byte_37_E40);

            case SensorsX.ebcDutyX:
                return (float) this.class18_0.method_207(this.list_0[int_3].byte_38_E41);

            case SensorsX.ebcTarget:
                return (float) this.class18_0.method_206(this.list_0[int_3].byte_39_E42);

            case SensorsX.ebcCurrent:
                return (float) this.class18_0.method_206(this.list_0[int_3].byte_4);

            case SensorsX.gpo1_in:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 4, false);

            case SensorsX.gpo1_out:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_36_E43, 0, false);

            case SensorsX.gpo2_in:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 5, false);

            case SensorsX.gpo2_out:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_36_E43, 1, false);

            case SensorsX.gpo3_in:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 6, false);

            case SensorsX.gpo3_out:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_36_E43, 2, false);

            case SensorsX.fanCtrl:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 6, false);

            case SensorsX.bstStage2:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_36_E43, 3, false);

            case SensorsX.bstStage3:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_36_E43, 4, false);

            case SensorsX.bstStage4:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_36_E43, 5, false);

            case SensorsX.bstActive:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_35_E39, 7, false);

            case SensorsX.bstInput:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_34_E38, 7, false);

            case SensorsX.analog1:
                return this.class18_0.method_201(AnalogInputs.analog1, this.list_0[int_3].byte_40);

            case SensorsX.analog2:
                return this.class18_0.method_201(AnalogInputs.analog2, this.list_0[int_3].byte_41);

            case SensorsX.analog3:
                return this.class18_0.method_201(AnalogInputs.analog3, this.list_0[int_3].byte_42);

            case SensorsX.iacvDuty:
            {
                float num3 = ((float) this.list_0[int_3].ushort_2_E49_50) / 32768f;
                return ((num3 * 100f) - 100f);
            }
            case SensorsX.leanProtection:
                return (float) this.class18_0.method_260(this.list_0[int_3].byte_36_E43, 7, false);

            case SensorsX.deltaRpm1:
                return (float) this.list_0[int_3].long_6;

            case SensorsX.deltaVss:
                return (float) this.list_0[int_3].byte_47;

            case SensorsX.deltaRpm2:
                return (float) this.list_0[int_3].long_7;
        }
        return num;
    }

    public string method_79(SensorsX sensors_0, int int_3)
    {
        float num = 0f;
        if (sensors_0 == SensorsX.mapX)
        {
            num = this.class18_0.method_193(this.list_0[int_3].byte_4);
        }
        else
        {
            num = this.method_77(sensors_0, int_3);
        }
        return num.ToString();
    }

    public float[] method_80(SensorsX sensors_0)
    {
        float[] numArray = new float[] { -1f, 2f };
        switch (sensors_0)
        {
            case SensorsX.rpmX:
                numArray[0] = 0f;
                numArray[1] = 10000f;
                return numArray;

            case SensorsX.vssX:
                numArray[0] = 0f;
                numArray[1] = 255f;
                return numArray;

            case SensorsX.gearX:
                numArray[0] = -1f;
                numArray[1] = 6f;
                return numArray;

            case SensorsX.mapX:
                numArray[0] = this.class18_0.method_206(0);
                numArray[1] = this.class18_0.method_206(0xff);
                return numArray;

            case SensorsX.boostX:
                numArray[0] = this.class18_0.method_245(950);
                numArray[1] = this.class18_0.method_245(this.class18_0.method_206(0xff));
                return numArray;

            case SensorsX.paX:
                numArray[0] = 0f;
                numArray[1] = 1100f;
                return numArray;

            case SensorsX.tpsX:
                numArray[0] = -5f;
                numArray[1] = 115f;
                return numArray;

            case SensorsX.tpsV:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.injDur:
                numArray[0] = 0f;
                numArray[1] = 20f;
                return numArray;

            case SensorsX.injDuty:
                numArray[0] = 0f;
                numArray[1] = 130f;
                return numArray;

            case SensorsX.injFV:
                numArray[0] = 0f;
                numArray[1] = 2000f;
                return numArray;

            case SensorsX.ignFnl:
                numArray[0] = -6f;
                numArray[1] = 60f;
                return numArray;

            case SensorsX.ignTbl:
                numArray[0] = -6f;
                numArray[1] = 60f;
                return numArray;

            case SensorsX.ectX:
                numArray[0] = (float) this.class18_0.method_191(0xff);
                numArray[1] = (float) this.class18_0.method_191(0);
                return numArray;

            case SensorsX.iatX:
                numArray[0] = (float) this.class18_0.method_191(0xff);
                numArray[1] = (float) this.class18_0.method_191(0);
                return numArray;

            case SensorsX.afr:
                numArray[0] = (float) this.class18_0.method_200(0);
                numArray[1] = (float) this.class18_0.method_200(0xff);
                return numArray;

            case SensorsX.ecuO2V:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.wbO2V:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.batV:
                numArray[0] = 0f;
                numArray[1] = 15f;
                return numArray;

            case SensorsX.eldV:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.knockV:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.mapV:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.mil:
            case SensorsX.frame:
            case SensorsX.duration:
            case SensorsX.interval:
            case SensorsX.loadType:
            case SensorsX.overheatActive:
            case SensorsX.test0:
                return numArray;

            case SensorsX.ectFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    numArray[0] = -100f;
                    numArray[1] = 100f;
                    return numArray;
                }
                numArray[0] = 0f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.iatFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    numArray[0] = -100f;
                    numArray[1] = 100f;
                    return numArray;
                }
                numArray[0] = 0f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.o2Short:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    numArray[0] = -100f;
                    numArray[1] = 100f;
                    return numArray;
                }
                numArray[0] = 0f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.o2Long:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    numArray[0] = -100f;
                    numArray[1] = 100f;
                    return numArray;
                }
                numArray[0] = 0f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.veFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    numArray[0] = -100f;
                    numArray[1] = 100f;
                    return numArray;
                }
                numArray[0] = 0f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ectIc:
                numArray[0] = -30f;
                numArray[1] = 30f;
                return numArray;

            case SensorsX.iatIc:
                numArray[0] = -30f;
                numArray[1] = 30f;
                return numArray;

            case SensorsX.gearIc:
                numArray[0] = -30f;
                numArray[1] = 30f;
                return numArray;

            case SensorsX.gearFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    numArray[0] = -100f;
                    numArray[1] = 100f;
                    return numArray;
                }
                numArray[0] = 0f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.postFuel:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outIab:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outVtsX:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outVtsM:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outAc:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outO2h:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outMil:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outPurge:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outFanc:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outFpump:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outFuelCut:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.outAltCtrl:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inPsp:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inSCC:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inAccs:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inBksw:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inVtp:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inVtsFeedBack:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inParkN:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inStartS:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inAtShift1:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.inAtShift2:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.secMaps:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ftlInput:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ftlActive:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ftsClutchInput:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ftsActive:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.boostcutActive:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.antilagActive:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ignitionCut:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.sccChecker:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ebcInput:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ebcHiInput:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ebcActive:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.ebcBaseDuty:
                numArray[0] = 0f;
                numArray[1] = 100f;
                return numArray;

            case SensorsX.ebcDutyX:
                numArray[0] = 0f;
                numArray[1] = 100f;
                return numArray;

            case SensorsX.ebcTarget:
                numArray[0] = this.class18_0.method_206(0);
                numArray[1] = this.class18_0.method_206(0xff);
                return numArray;

            case SensorsX.ebcCurrent:
                numArray[0] = this.class18_0.method_206(0);
                numArray[1] = this.class18_0.method_206(0xff);
                return numArray;

            case SensorsX.gpo1_in:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.gpo1_out:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.gpo2_in:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.gpo2_out:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.gpo3_in:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.gpo3_out:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.fanCtrl:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.bstStage2:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.bstStage3:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.bstStage4:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.bstActive:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.bstInput:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.analog1:
                numArray[0] = this.class18_0.method_201(AnalogInputs.analog1, 0);
                numArray[1] = this.class18_0.method_201(AnalogInputs.analog1, 0xff);
                return numArray;

            case SensorsX.analog2:
                numArray[0] = this.class18_0.method_201(AnalogInputs.analog2, 0);
                numArray[1] = this.class18_0.method_201(AnalogInputs.analog2, 0xff);
                return numArray;

            case SensorsX.analog3:
                numArray[0] = this.class18_0.method_201(AnalogInputs.analog3, 0);
                numArray[1] = this.class18_0.method_201(AnalogInputs.analog3, 0xff);
                return numArray;

            case SensorsX.iacvDuty:
                numArray[0] = -100f;
                numArray[1] = 100f;
                return numArray;

            case SensorsX.leanProtection:
                numArray[0] = -1f;
                numArray[1] = 2f;
                return numArray;

            case SensorsX.deltaRpm1:
                numArray[0] = 0f;
                numArray[1] = 50f;
                return numArray;

            case SensorsX.deltaVss:
                numArray[0] = 0f;
                numArray[1] = 40f;
                return numArray;

            case SensorsX.deltaRpm2:
                numArray[0] = 0f;
                numArray[1] = 50f;
                return numArray;

            case SensorsX.egt_cht1:
                numArray[0] = 500f;
                numArray[1] = 2000f;
                return numArray;

            case SensorsX.egt_cht2:
                numArray[0] = 500f;
                numArray[1] = 2000f;
                return numArray;

            case SensorsX.egt_cht3:
                numArray[0] = 500f;
                numArray[1] = 2000f;
                return numArray;

            case SensorsX.egt_cht4:
                numArray[0] = 500f;
                numArray[1] = 2000f;
                return numArray;

            case SensorsX.egt_chtAvg:
                numArray[0] = 500f;
                numArray[1] = 2000f;
                return numArray;

            case SensorsX.backPres:
                numArray[0] = 0f;
                numArray[1] = 45f;
                return numArray;

            case SensorsX.fuelPres:
                numArray[0] = 0f;
                numArray[1] = 150f;
                return numArray;

            case SensorsX.iat2:
                numArray[0] = 0f;
                numArray[1] = 255f;
                return numArray;

            case SensorsX.accelTime:
                numArray[0] = 0f;
                numArray[1] = 100f;
                return numArray;

            case SensorsX.fuelUsage:
                numArray[0] = 0f;
                numArray[1] = 100f;
                return numArray;

            case SensorsX.egrV:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.b6V:
                numArray[0] = 0f;
                numArray[1] = 5f;
                return numArray;

            case SensorsX.flexFuel:
                numArray[0] = 0f;
                numArray[1] = 100f;
                return numArray;
        }
        return numArray;
    }

    public void method_81()
    {
    Label_0005:
        if (this.bool_8)
        {
            this.long_1 -= 1L;
        }
        else
        {
            this.long_1 += 1L;
        }
        if ((this.long_1 != this.method_65()) && (this.long_1 != 0L))
        {
            this.struct12_0 = this.method_76(this.long_1);
            this.int_2++;
            if (this.int_2 >= (this.class10_settings_0.int_25 + 1))
            {
                this.int_2 = 0;
                this.method_40_SendBytes_Delegate();
            }
            if (this.bool_7)
            {
                this.stopwatch_2.Reset();
                this.stopwatch_2.Start();
                while (this.stopwatch_2.ElapsedMilliseconds < (this.struct12_0.long_4 / 2L))
                {
                    Application.DoEvents();
                }
                this.stopwatch_2.Reset();
            }
            else if (this.bool_71)
            {
                this.stopwatch_2.Reset();
                this.stopwatch_2.Start();
                while (true)
                {
                    if (this.stopwatch_2.ElapsedMilliseconds >= (this.struct12_0.long_4 * 2L))
                    {
                        this.stopwatch_2.Reset();
                        break;
                    }
                    Application.DoEvents();
                }
            }
            else if (this.bool_72)
            {
                this.stopwatch_2.Reset();
                this.stopwatch_2.Start();
                while (true)
                {
                    if (this.stopwatch_2.ElapsedMilliseconds >= (this.struct12_0.long_4 * 6L))
                    {
                        this.stopwatch_2.Reset();
                        break;
                    }
                    Application.DoEvents();
                }
            }
            else
            {
                this.stopwatch_2.Reset();
                this.stopwatch_2.Start();
                while (this.stopwatch_2.ElapsedMilliseconds < this.struct12_0.long_4)
                {
                    Application.DoEvents();
                }
                this.stopwatch_2.Reset();
            }
            goto Label_0005;
        }
        this.method_71();
    }

    /*private void method_82(string string_3)
    {
        if (this.int_1 >= 1)
        {
            try
            {
                FileStream input = new FileStream(string_3, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryReader reader = new BinaryReader(input) {
                    BaseStream = { Position = 13L }
                };
                int count = reader.ReadInt32();
                reader.Close();
                reader = null;
                input.Close();
                input = null;
                input = new FileStream(string_3, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(input) {
                    BaseStream = { Position = 13L }
                };
                long length = 0L;
                if (count == 0)
                {
                    length = writer.BaseStream.Length;
                }
                else
                {
                    length = count;
                }
                writer.Write((int) length);
                writer.Close();
                writer = null;
                input.Close();
                input.Dispose();
                input = null;
                if (count != 0)
                {
                    input = new FileStream(string_3, FileMode.OpenOrCreate, FileAccess.Read);
                    reader = new BinaryReader(input) {
                        BaseStream = { Position = 0L }
                    };
                    byte[] buffer_0 = new byte[count];
                    reader.Read(buffer_0, 0, count);
                    reader.Close();
                    reader = null;
                    input.Close();
                    input.Dispose();
                    input = null;
                    input = new FileStream(string_3, FileMode.Truncate, FileAccess.ReadWrite);
                    writer = new BinaryWriter(input);
                    writer.Write(buffer_0, 0, buffer_0.Length);
                    writer.Close();
                    writer = null;
                }
                input = new FileStream(string_3, FileMode.Open, FileAccess.Write);
                StreamWriter writer2 = new StreamWriter(input) {
                    BaseStream = { Position = (long) ((int) length) }
                };
                foreach (Struct22 struct2 in this.list_1)
                {
                    writer2.WriteLine(struct2.int_0.ToString() + ";" + struct2.string_0);
                }
                writer2.Close();
                writer2.Dispose();
                writer2 = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(new Form {TopMost = true}, string.Concat(new object[] { "save marker errored with: ", exception.Message, Environment.NewLine, exception.StackTrace, Environment.NewLine, exception.Source, Environment.NewLine, exception.TargetSite }));
            }
        }
    }

    private void method_83(string string_3)
    {
        this.list_1.Clear();
        try
        {
            FileStream input = new FileStream(string_3, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(input) {
                BaseStream = { Position = 13L }
            };
            int num = reader.ReadInt32();
            reader.Close();
            reader = null;
            input.Close();
            input = null;
            if (num != 0)
            {
                input = new FileStream(string_3, FileMode.Open, FileAccess.ReadWrite);
                StreamReader reader2 = new StreamReader(input) {
                    BaseStream = { Position = (long) num }
                };
                string str = null;
                for (str = reader2.ReadLine(); (str != "") && (str != null); str = reader2.ReadLine())
                {
                    Struct22 item = new Struct22();
                    string[] strArray = str.Split(new char[] { ';' });
                    item.int_0 = int.Parse(strArray[0]);
                    item.string_0 = strArray[1];
                    this.list_1.Add(item);
                }
                reader2.Close();
                reader2 = null;
                input.Close();
                input = null;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(new Form {TopMost = true}, "Load saved marker errored with: " + exception.Message + Environment.NewLine + exception.StackTrace);
        }
    }*/

    public bool method_86(SensorsX sensors_0)
    {
        switch (sensors_0)
        {
            case SensorsX.egt_cht1:
                return (this.class10_settings_0.int_55 != 0);

            case SensorsX.egt_cht2:
                return (this.class10_settings_0.int_56 != 0);

            case SensorsX.egt_cht3:
                return (this.class10_settings_0.int_57 != 0);

            case SensorsX.egt_cht4:
                return (this.class10_settings_0.int_58 != 0);

            case SensorsX.egt_chtAvg:
                return (this.class10_settings_0.int_59 != 0);

            case SensorsX.backPres:
                return (this.class10_settings_0.int_60 != 0);

            case SensorsX.fuelPres:
                return (this.class10_settings_0.int_61 != 0);

            case SensorsX.iat2:
                return (this.class10_settings_0.int_62 != 0);
        }
        return false;
    }

    public bool method_87(SensorsX sensors_0)
    {
        switch (sensors_0)
        {
            case SensorsX.egt_cht1:
                return (this.class10_settings_0.int_55 <= 3);

            case SensorsX.egt_cht2:
                return (this.class10_settings_0.int_56 <= 3);

            case SensorsX.egt_cht3:
                return (this.class10_settings_0.int_57 <= 3);

            case SensorsX.egt_cht4:
                return (this.class10_settings_0.int_58 <= 3);

            case SensorsX.egt_chtAvg:
                return (this.class10_settings_0.int_59 <= 3);

            case SensorsX.backPres:
                return (this.class10_settings_0.int_60 <= 3);

            case SensorsX.fuelPres:
                return (this.class10_settings_0.int_61 <= 3);

            case SensorsX.iat2:
                return (this.class10_settings_0.int_62 <= 3);
        }
        return false;
    }

    public bool method_88(AnalogInputs analogInputs_0)
    {
        switch (analogInputs_0)
        {
            case AnalogInputs.analog1:
                return (((((this.class10_settings_0.int_60 == 1) || (this.class10_settings_0.int_55 == 1)) || ((this.class10_settings_0.int_56 == 1) || (this.class10_settings_0.int_57 == 1))) || ((this.class10_settings_0.int_58 == 1) || (this.class10_settings_0.int_59 == 1))) || ((this.class10_settings_0.int_61 == 1) | (this.class10_settings_0.int_62 == 1)));

            case AnalogInputs.analog2:
                return (((((this.class10_settings_0.int_60 == 2) || (this.class10_settings_0.int_55 == 2)) || ((this.class10_settings_0.int_56 == 2) || (this.class10_settings_0.int_57 == 1))) || ((this.class10_settings_0.int_58 == 1) || (this.class10_settings_0.int_59 == 2))) || ((this.class10_settings_0.int_61 == 2) | (this.class10_settings_0.int_62 == 2)));

            case AnalogInputs.analog3:
                return (((((this.class10_settings_0.int_60 == 3) || (this.class10_settings_0.int_55 == 3)) || ((this.class10_settings_0.int_56 == 3) || (this.class10_settings_0.int_57 == 1))) || ((this.class10_settings_0.int_58 == 1) || (this.class10_settings_0.int_59 == 3))) || ((this.class10_settings_0.int_61 == 3) | (this.class10_settings_0.int_62 == 3)));
        }
        return false;
    }

    private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
    {
        this.timer_0.Stop();
        if ((this.queue_0.Count > 0) && !this.backgroundWorker_1.IsBusy)
        {
            this.backgroundWorker_1.RunWorkerAsync();
        }
        else
        {
            this.timer_0.Start();
        }
    }

    private void timer_1_Elapsed(object sender, ElapsedEventArgs e)
    {
        this.timer_1.Stop();
        if (!this.class10_settings_0.IsBluetooth)
        {
            string[] portNames = SerialPort.GetPortNames();
            bool flag = false;
            for (int i = 0; i < portNames.Length; i++)
            {
                if ((this.serialPort_0 != null) && portNames[i].Contains(this.serialPort_0.PortName))
                {
                    this.timer_1.Start();
                    this.IsUSBConnected = true;
                    flag = true;
                    return;
                }
            }
            this.IsUSBConnected = false;
            if (!flag)
            {
                try
                {
                    this.serialPort_0.Close();
                    this.method_4(DataloggingState.Disconnected);
                }
                catch (Exception)
                {
                }
                try
                {
                    this.serialPort_0.Dispose();
                }
                catch (Exception)
                {
                }
                this.serialPort_0 = null;
                this.method_35(false);
                this.LogThis("USB might be disconnected!");
                this.method_20();
            }
        }
    }

    private void timer_2_Tick(object sender, EventArgs e)
    {
        this.bool_13 = true;
    }

    public delegate void Delegate45(Struct20 struct20_0);

    public delegate void Delegate46(DataloggingState dataloggingState_0, bool bool_0);

    public delegate void Delegate47(Struct17 struct17_0);

    public delegate void Delegate48(Struct12 struct12_0);

    public delegate void Delegate49(Struct23 struct23_0);

    public delegate void Delegate50(Struct12 struct12_0);

    private delegate void Delegate51();

    private delegate void Delegate52(Struct12 struct12_0);

    public delegate void Delegate53(long long_0, string string_0);

    public delegate void Delegate54(Struct12 struct12_0);

    internal enum Enum10
    {
        const_0,
        const_1
    }

    internal enum Enum9
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
        const_9
    }
}

