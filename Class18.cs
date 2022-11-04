using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

internal class Class18
{
    private BackgroundWorker backgroundWorker1 = new BackgroundWorker();
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool CalcTime = false;
    private double LastAccelTime = 99.9;
    Stopwatch watch;

    //private bool KBinLoaded = false;
    private bool VWBinLoaded = false;
    public bool BinLoadedForSaving = false;

    private byte[] byte_0_X1;
    private byte[] byte_0_X2;

    private long long_3 = 0xaa00L;
    private long long_4 = 0x1418L;
    private long long_28 = 0x80L;

    private byte byte_2;
    public Class10_settings class10_settings_0;
    internal Class11_u class11_u_0;
    internal Class12_afrT class12_afrT_0;
    public Class13_u class13_u_0 = new Class13_u();
    internal Class15 class15_0;
    internal Class17 class17_0;
    private Class21_snap class21_snap_0;
    internal Class25 class25_0;
    private Class32_Locations class32_Locations_0;

    public Collection<Class24_u> class24_u_0 = new Collection<Class24_u>();
    private List<long> InputsListLocations = new List<long>();
    private List<string> InputsListDesc = new List<string>();

    private List<long> OutputsListLocations = new List<long>();
    private List<string> OutputsListDesc = new List<string>();

    internal Binary_Files Binary_Files_0;
    private int Stable_Version_LAST = 0; //Ex: 1.03 last stable in list // THIS IS THE LAST VERSION AVAILABLE IN THE STABLE LIST                         0 = 1.0.0 ### 1 = 1.0.1 ### 2 = 1.0.2 ### ETC
    private int CurrentVersion = 100;
    public int RomVersion = 100;
    internal bool ConvertedToStable = false;

    public int LastLocationLoaded = 0;

    private frmPassword frmPassword_0;
    private Class18 Class18_0;
    private double[] double_0 = new double[] { 
        140.961, 138.694, 136.479, 134.314, 132.198, 130.129, 128.108, 126.132, 124.2, 122.312, 120.467, 118.663, 116.9, 115.176, 113.491, 111.843, 
        110.232, 108.657, 107.117, 105.611, 104.139, 102.699, 101.29, 99.9123, 98.5646, 97.2463, 95.9564, 94.6944, 93.4595, 92.251, 91.0682, 89.9104, 
        88.7771, 87.6674, 86.5809, 85.5169, 84.4749, 83.4541, 82.454, 81.4742, 80.5139, 79.5728, 78.6502, 77.7457, 76.8587, 75.9887, 75.1354, 74.2982, 
        73.4766, 72.6702, 71.8787, 71.1014, 70.3382, 69.5884, 68.8518, 68.1279, 67.4164, 66.717, 66.0292, 65.3527, 64.6871, 64.0322, 63.3876, 62.753, 
        62.1281, 61.5126, 60.9062, 60.3086, 59.7195, 59.1388, 58.566, 58.001, 57.4435, 56.8932, 56.35, 55.8136, 55.2838, 54.7603, 54.243, 53.7316, 
        53.226, 52.7259, 52.2312, 51.7417, 51.2571, 50.7774, 50.3024, 49.8318, 49.3656, 48.9035, 48.4455, 47.9913, 47.5409, 47.094, 46.6507, 46.2106, 
        45.7738, 45.34, 44.9092, 44.4812, 44.0559, 43.6333, 43.2131, 42.7953, 42.3799, 41.9666, 41.5554, 41.1461, 40.7388, 40.3333, 39.9295, 39.5274, 
        39.1268, 38.7276, 38.3299, 37.9335, 37.5382, 37.1442, 36.7512, 36.3592, 35.9682, 35.578, 35.1886, 34.8, 34.412, 34.0247, 33.6378, 33.2515, 
        32.8655, 32.4799, 32.0946, 31.7096, 31.3247, 30.9399, 30.5552, 30.1706, 29.7858, 29.401, 29.016, 28.6308, 28.2454, 27.8596, 27.4735, 27.087, 
        26.7, 26.3124, 25.9244, 25.5357, 25.1463, 24.7562, 24.3654, 23.9737, 23.5812, 23.1878, 22.7934, 22.398, 22.0016, 21.6041, 21.2054, 20.8056, 
        20.4045, 20.0022, 19.5985, 19.1934, 18.787, 18.3791, 17.9697, 17.5587, 17.1462, 16.732, 16.3162, 15.8986, 15.4793, 15.0582, 14.6353, 14.2105, 
        13.7838, 13.3552, 12.9246, 12.4919, 12.0572, 11.6205, 11.1816, 10.7405, 10.2973, 9.85183, 9.40413, 8.95416, 8.5019, 8.04731, 7.59037, 7.13106, 
        6.66936, 6.20526, 5.73872, 5.26973, 4.79829, 4.32437, 3.84797, 3.36908, 2.88769, 2.40381, 1.91741, 1.42851, 0.93711, 0.443211, -0.0531673, -0.552034, 
        -1.05337, -1.55713, -2.06334, -2.57195, -3.08295, -3.5963, -4.11196, -4.62992, -5.15012, -5.67251, -6.19708, -6.72373, -7.25245, -7.78316, -8.31578, -8.85028, 
        -9.38656, -9.92454, -10.4642, -11.0053, -11.5479, -12.0919, -12.6371, -13.1835, -13.7308, -14.2791, -14.8282, -15.3779, -15.9282, -16.4788, -17.0296, -17.5805, 
        -18.1313, -18.6818, -19.2319, -19.7814, -20.33, -20.8776, -21.4239, -21.9688, -22.5121, -23.0534, -23.5926, -24.1294, -24.6635, -25.1947, -25.7227, -26.2472
     };
    private FuelDisplayMode fuelDisplayMode_0;
    private SelectedTable selectedTable_0;
    public string string_1;
    public int int_0 = 333;
    private string string_4;
    private string string_5;
    private string string_7;
    private TableOverlay tableOverlay_0;
    //private DASM_Bytes DASM_Bytes_0;

    public event Delegate57 delegate57_0;
    public event Delegate61 delegate61_0;
    public event Delegate58 delegate58_0;   //delegate occuring once when loading file
    public event Delegate60 delegate60_0;
    public event Delegate55 delegate55_0;
    public event Delegate55 delegate55_1;

    public bool OpenSilentBRom = false;
    private byte[] LastGlitchedByte = new byte[] { };
    public bool Converting = false;
    public bool Glitched = false;
    private bool GlitchTesting = false;
    private int GlitchTestingTimer = 0;

    internal Class18(ref Class10_settings cfg, ref Class15 RmChk)       //This is class13 in HTS 1.92
    {
        this.class10_settings_0 = cfg;
        this.class15_0 = RmChk;
        this.Class18_0 = this;

        //DASM_Bytes_0 = new DASM_Bytes();

        string_1 = "3.3.3";

        LoadBinaryFiles();
        Stable_Version_LAST = Binary_Files_0.GetLastStable();
        //CloseBinaryFiles();

        //Get Version
        CurrentVersion = Stable_Version_LAST + 100;
        RomVersion = Stable_Version_LAST + 100;

        if (this.class10_settings_0.GlitchedBaseromTestInterval < 5000) this.class10_settings_0.GlitchedBaseromTestInterval = 15000;
        GlitchTestingTimer = this.class10_settings_0.GlitchedBaseromTestInterval;

        class32_Locations_0 = new Class32_Locations();
        class32_Locations_0.LoadReference(ref Class18_0);

        InjectorsLoading InjectorsLoading_0 = new InjectorsLoading(ref this.Class18_0);
        InjectorsLoading_0 = null;

        this.backgroundWorker1.WorkerSupportsCancellation = true;
        this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
        this.backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        while (!worker.CancellationPending)
        {
            if (GlitchTestingTimer <= 0)
            {
                GlitchTestingTimer = this.class10_settings_0.GlitchedBaseromTestInterval;

                if (method_30_HasFileLoadedInBMTune())
                {
                    IsBaseromGlitched();
                }
            }

            Thread.Sleep(1);
            GlitchTestingTimer--;
        }
    }

    public void Dissspose()
    {
        if (this.backgroundWorker1 != null)
        {
            if (this.backgroundWorker1.IsBusy) this.backgroundWorker1.CancelAsync();
            this.backgroundWorker1.Dispose();
            this.backgroundWorker1 = null;
        }
    }

    private void IsBaseromGlitched()
    {
        //if (!Converting && !Glitched && !GlitchTesting && !KBinLoaded && !VWBinLoaded && !this.class17_0.frmMain_0.CustomMenuLoaded)
        if (!Converting && !Glitched && !GlitchTesting && !VWBinLoaded && !this.class17_0.frmMain_0.CustomMenuLoaded)
        {
            bool CanCheckB = true;
            /*if (this.class17_0.frmMain_0.ktable_0 != null)
            {
                if (this.class17_0.frmMain_0.ktable_0.Class39_0 != null)
                {
                    if (this.class17_0.frmMain_0.ktable_0.Class39_0.bool_1) CanCheckB = false;
                }
            }*/
            if (CanCheckB) 
            {
                GlitchTesting = true;

                byte[] AllByte = GetAllByte();
                if (AllByte != LastGlitchedByte)
                {
                    LastGlitchedByte = AllByte;

                    if (AllByte.Length == 32768)
                    {
                        //#######
                        //Zipping
                        string Filename = "dasm662.exe";
                        string ZipFolder = "ASM";
                        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
                        if (!File.Exists(WholePath)) this.class17_0.frmMain_0.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
                        //#######

                        for (int i = 0; i < AllByte.Length; i++)
                        {
                            if (AllByte[i] == 0x92 && AllByte[i + 1] == 0x22 && AllByte[i + 2] == 0x03)
                            {
                                AllByte[i - 3] = 0x03;
                                AllByte[i] = 0xff;
                                AllByte[i + 1] = 0xff;
                            }
                        }

                        File.Create(Application.StartupPath + @"\" + ZipFolder + @"\GlitchTest.bin").Dispose();
                        File.WriteAllBytes(Application.StartupPath + @"\" + ZipFolder + @"\GlitchTest.bin", AllByte);

                        //Create DASM.bat
                        /*if (!File.Exists(Application.StartupPath + @"\" + ZipFolder + @"\DASM.bat"))
                        {
                            string BatTxt = "dasm662.exe GlitchTest.bin GlitchTest.asm";
                            StreamWriter writer = new StreamWriter(Application.StartupPath + @"\" + ZipFolder + @"\DASM.bat", false);
                            writer.Write(BatTxt);
                            writer.Close();
                            writer.Dispose();
                            writer = null;
                        }*/

                        //Load DASM.bat
                        Process p = new Process();
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                        p.StartInfo.WorkingDirectory = Application.StartupPath + @"\" + ZipFolder;
                        //p.StartInfo.FileName = "DASM.bat";
                        //p.StartInfo.FileName = Application.StartupPath + @"\" + ZipFolder + @"\dasm662.exe";
                        p.StartInfo.FileName = "dasm662.exe";
                        p.StartInfo.Arguments = "GlitchTest.bin GlitchTest.asm";
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.Verb = "runas";
                        p.Start();

                        //#################
                        int SleepingCount = 0;
                        while (SleepingCount < 200)
                        {
                            Thread.Sleep(1);
                            SleepingCount++;
                        }
                        SleepingCount = 0;
                        //#################

                        Process[] pname = Process.GetProcessesByName("dasm662.exe");
                        //Process[] pname = Process.GetProcessesByName("DASM.bat");
                        while (pname.Length > 1)
                        {
                            Thread.Sleep(1);
                            pname = Process.GetProcessesByName("dasm662.exe");
                            //pname = Process.GetProcessesByName("DASM.bat");
                        }

                        //#################
                        while (SleepingCount < 200)
                        {
                            Thread.Sleep(1);
                            SleepingCount++;
                        }
                        SleepingCount = 0;
                        //#################

                        FileInfo info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\GlitchTest.asm");
                        if (info.Exists)
                        {
                            if (info.Length < 1024000 && info.Length > 2)
                            {
                                Glitched = true;
                                this.class17_0.frmMain_0.LogThis("We detected that the baserom is glitched!" + Environment.NewLine + "This can cause a permanent CEL and run in Limp Mode. We recommand to restore the baserom using the Baserom Converter!");
                                MessageBox.Show(Form.ActiveForm, "We detected that the baserom is glitched!" + Environment.NewLine + Environment.NewLine + "This can cause a permanent CEL and run in Limp Mode. We recommand to" + Environment.NewLine + "restore the baserom using the Baserom Converter!", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                        else
                        {
                            this.class17_0.frmMain_0.LogThis("Can't disassemble binary to check if the baserom is glitched!");
                        }

                        RemoveFile();
                        info = null;
                        GlitchTesting = false;
                    }
                }
            }
        }
    }

    public void RemoveFile()
    {
        try
        {
            //Remove DASM
            string ZipFolder = "ASM";

            FileInfo info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\GlitchTest.bin");
            if (info.Exists) info.Delete();
            info = null;

            info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\GlitchTest.asm");
            if (info.Exists) info.Delete();
            info = null;

            info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\FileName.bin");
            if (info.Exists) info.Delete();
            info = null;

            info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\FileName.asm");
            if (info.Exists) info.Delete();
            info = null;

            //info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\dasm662.exe");
            //if (info.Exists) info.Delete();
            //info = null;

            //info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\DASM.bat");
            //if (info.Exists) info.Delete();
            //info = null;
        }
        catch { }
    }

    internal void method_0(ref Class11_u class11_u_1, ref Class17 class17_1, ref Class21_snap class21_1)
    {
        this.class11_u_0 = class11_u_1;
        this.class11_u_0.delegate33_0 += new Class11_u.Delegate33(this.method_3);
        this.class17_0 = class17_1;
        this.class21_snap_0 = class21_1;
    }

    internal void method_1(ref Class12_afrT class12_1)
    {
        this.class12_afrT_0 = class12_1;
    }

    public void SetByteNull()
    {
        byte_0_X1 = null;
        byte_0_X2 = null;
        //Console.WriteLine("Set null");
    }

    public void SetByteSize(int Size)
    {
        int MidSize = Size / 2;
        byte_0_X1 = new byte[MidSize];
        byte_0_X2 = new byte[Size - MidSize];
        //Console.WriteLine("Set size");
    }

    public void SetAllByte(byte[] TByte)
    {
        int MidSize = TByte.Length / 2;
        byte_0_X1 = new byte[MidSize];
        byte_0_X2 = new byte[TByte.Length - MidSize];

        for (int i = 0; i < MidSize; i++) byte_0_X1[i] = TByte[i];
        for (int i = 0; i < (TByte.Length - MidSize); i++) byte_0_X2[i] = TByte[i + MidSize];

        //Console.WriteLine("Set bytes");
    }

    public byte[] GetAllByte()
    {
        byte[] Returning = new byte[GetByteLenght()];
        for (int i = 0; i < byte_0_X1.Length; i++) Returning[i] = byte_0_X1[i];
        for (int i = 0; i < byte_0_X2.Length; i++) Returning[i + byte_0_X1.Length] = byte_0_X2[i];
        return Returning;
    }

    public int GetByteLenght()
    {
        if (byte_0_X1 != null && byte_0_X2 != null)
        {
            return byte_0_X1.Length + byte_0_X2.Length;
        }
        else
        {
            this.class17_0.frmMain_0.LogThis("CAN'T get rom lenght due to Byte Array not declared (null)!");
        }
        return 0;
    }

    public void SetByteAt(long Location, byte TByte)
    {
        if (byte_0_X1 != null && byte_0_X2 != null)
        {
            //Upload Byte to RTP only if it has changed!
            if (GetByteAt(Location) != TByte)
            {
                this.class25_0.method_18(Location, TByte); //RTP Upload this Byte
            }

            if (this.class10_settings_0.LogAdvancedDatas) this.class17_0.frmMain_0.LogThis("ByteSet: 0x" + TByte.ToString("X2") + " At: 0x" + Location.ToString("X"));
            if (Location < byte_0_X1.Length) byte_0_X1[Location] = TByte;
            else byte_0_X2[Location - byte_0_X1.Length] = TByte;
        }
        else
        {
            this.class17_0.frmMain_0.LogThis("CAN'T set rom byte due to Byte Array not declared (null)!");
        }
    }

    public byte GetByteAt(long Location)
    {
        if (Location <= 0x7fff)
        {
            if (byte_0_X1 != null && byte_0_X2 != null)
            {
                if (this.class10_settings_0.LogAdvancedDatas) this.class17_0.frmMain_0.LogThis("ByteGet At: 0x" + Location.ToString("X"));
                if (Location < byte_0_X1.Length) return byte_0_X1[Location];
                else return byte_0_X2[Location - byte_0_X1.Length];
            }
        }
        else
        {
            this.class17_0.frmMain_0.LogThis("CAN'T get rom byte due to invalid location!" + Environment.NewLine + "Location: 0x" + Location.ToString("x4"));
        }

        return 0;
    }

    //#########################################################################################################################
    //#########################################################################################################################

    public ushort method_146(byte byte_3, byte byte_4)
    {
        return (ushort)((byte_4 * 0x100) + byte_3);
    }

    public byte method_147(long long_0_X)
    {
        return (byte)(long_0_X & 0xffL);
    }

    public byte method_148(long long_0_X)
    {
        return (byte)((long_0_X & 0xff00L) / 0x100L);
    }

    public void method_149_SetByte(long long_0_X, byte byte_3)
    {
        //if (long_0_X != 0 && long_0_X <= 0x7fff)
        if (long_0_X > 80 && long_0_X <= 0x7fff)
        {
            if (GetByteAt((int)((IntPtr)long_0_X)) != byte_3)
            {
                if (!this.class11_u_0.method_3() && this.method_30_HasFileLoadedInBMTune())
                {
                    this.class11_u_0.method_0(long_0_X, GetByteAt((int)((IntPtr)long_0_X)), byte_3);
                }
                SetByteAt((int)((IntPtr)long_0_X), byte_3);
                //this.class25_0.method_18(long_0_X, byte_3); //RTP Upload this Byte
            }
        }
    }

    public void method_151(long long_0_X, long long_1_X)
    {
        this.method_149_SetByte(long_0_X, this.method_147(long_1_X));
        this.method_149_SetByte(long_0_X + 1L, this.method_148(long_1_X));
    }

    public long method_152(long long_0_X)
    {
        return (long)((this.GetByteAt(long_0_X + 1L) * 0x100) + this.GetByteAt(long_0_X));
    }

    //#########################################################################################################################
    //#########################################################################################################################
    //#########################################################################################################################
    //#########################################################################################################################
    //#########################################################################################################################
    //#########################################################################################################################
    //#########################################################################################################################

    public void method_145()
    {
        Class13_u class13_u_1 = new Class13_u
        {
            long_0 = 0x60fdL,       //manual edit 1.11
            long_1 = 0x60ffL,       //manual edit 1.11
            long_2 = 0x60fcL,       //manual edit 1.11
            long_6 = 0x6e59L,
            long_8 = 0x6e71L,
            long_9 = 0x6e85L,

            long_10 = 0x6eadL,
            long_11 = 0x70a5L,
            long_12 = 0x729dL,
            long_13 = 0x747dL,
            long_18 = 0x6e17L,      //can also relate to export table start location (same location)
            long_16 = 0x6e2fL,
            long_17 = 0x6e43L,

            long_20 = 0x765fL,
            long_21 = 0x7857L,
            long_22 = 0x7a4fL,
            long_23 = 0x7c2fL,
            long_24 = 0x61a6L,
            long_25 = 0x61a8L,      //this lcoation +1 refer to injectors index
            long_27 = 0x7e0fL,
            long_29 = 0x6e99L,

            long_31 = 0x610fL,
            long_32 = 0x6110L,
            long_33 = 0x6101L,
            long_34 = 0x610dL,
            long_35 = 0x6103L,
            long_36 = 0x6105L,
            long_37 = 0x6107L,
            long_38 = 0x6109L,
            long_39 = 0x610bL,      //injector overall fuel trim

            long_41 = 0x628eL,
            long_43 = 0x5f4eL,
            long_44 = 0x5f4aL,
            long_45 = 0x61fcL,
            long_46 = 0x5ffdL,
            long_47 = 0x61f3L,
            long_48 = 0x620eL,
            long_49 = 0x61f4L,

            long_50 = 0x61f5L,
            long_51 = 0x61f9L,
            long_52 = 0x6591L,
            long_53 = 0x61f6L,
            long_54 = 0x5f4dL,
            long_55 = 0x5f49L,
            long_56 = 0x61f7L,
            long_58 = 0x5ffeL,      //Fcut delay (overrun fcut)
            long_59 = 0x5f46L,

            long_61 = 0x5f41L,      //Fcut Leak
            long_60 = 0x5f42L,      //FCut Leak
            long_62 = 0x5f43L,      //FCut Leak
            long_63 = 0x664fL,
            long_64 = 0x6213L,
            long_66 = 0x620bL,
            long_65 = 0x61f8L,
            long_67 = 0x620aL,
            long_68 = 0x7ff7L,      //datalog file ending bytes (3bytes, exemple: BMT)

            long_71 = 0x6125L,
            long_72 = 0x6126L,
            long_75 = 0x61fbL,      //column number
            long_76 = 0x616fL,
            long_77 = 0x619aL,
            long_78 = 0x61a7L,
            long_79 = 0x5ffcL,

            long_80 = 0x61ceL,
            long_81 = 0x6210L,
            long_82 = 0x5f90L,      //gear based rev limiter
            long_83 = 0x5f8fL,      //rev limiter ect threshold (cold/hot)
            long_84 = 0x5f8eL,
            long_85 = 0x5f9cL,
            long_88 = 0x5f4fL,      //kill injector
            long_89 = 0x5f03L,      //Calibration Area (previous: 0x5f28L, ectune: 0x5f44L)

            long_90 = 0x7ff5L,
            long_94 = 0x7fefL,      //export table (table end location)
            long_95 = 0x61d8L,

            long_100 = 0x61fdL,
            long_101 = 0x6202L,     //ignition sync value
            long_102 = 0x6208L,
            long_103 = 0x616bL,
            long_104 = 0x616cL,
            long_105 = 0x616dL,
            long_106 = 0x616eL,     //Fan control enabled

            long_110 = 0x616fL,
            long_111 = 0x61bfL,
            long_112 = 0x6200L,
            long_113 = 0x6203L,
            long_114 = 0x6138L,
            long_115 = 0x6139L,
            long_116 = 0x5f50L,     //ign sync on/off
            long_117 = 0x6142L,     //mil shiftlight enable
            long_118 = 0x6143L,
            long_119 = 0x6144L,

            long_120 = 0x6146L,
            long_121 = 0x613eL,
            long_122 = 0x6140L,
            long_123 = 0x613aL,
            long_124 = 0x613bL,
            long_125 = 0x613dL,
            long_126 = 0x6150L,     //Boost cut enabled
            long_127 = 0x6151L,     //Boost cut Cold Load value
            long_128 = 0x615eL,     //Boost cut Hot Load value
            long_129 = 0x615fL,     //Boost cut ect threshold

            long_130 = 0x615dL,     //Boost cut activate boost cut if DTC
            long_131 = 0x619bL,     //Boost cut limit rpm type (1200rpm or set at current rpm)
            long_132 = 0x5ffbL,     //ect protect, above ect
            long_133 = 0x5ffaL,     //ect protect enabled
            long_135 = 0x5f77L,     //ect protect limit to rpm
            long_136 = 0x5fa5L,
            long_137 = 0x6152L,
            long_138 = 0x6153L,
            long_139 = 0x6155L,

            long_140 = 0x6156L,     //launch-FTL minimum RPM
            long_141 = 0x6158L,
            long_142 = 0x61cfL,
            long_143 = 0x6165L,
            long_144 = 0x6154L,
            long_147 = 0x6159L,
            long_148 = 0x615aL,
            long_149 = 0x615bL,

            long_150 = 0x5f80L,     //fts rpm
            long_151 = 0x5f7eL,     //fts above tps
            long_152 = 0x5f7fL,     //fts gear based rpm enable
            long_153 = 0x5f59L,     //fts type (fixed or adjustable rpm)
            long_154 = 0x5f58L,     //fts antilag enabled
            long_155 = 0x5f56L,     //fts fuel
            long_156 = 0x5f55L,     //fts ign retard
            long_157 = 0x6164L,     //fts enabled
            long_158 = 0x6160L,     //FTL antilag above tps
            long_159 = 0x6161L,     //FTL fuel

            long_160 = 0x6163L,     //FTL Retard
            long_162 = 0x5f8dL,     //FTL Antilag ign mode (static, by retard)
            long_163 = 0x5f8cL,     //FTL retard static

            long_171 = 0x5f54L,     //Burnout Control Rpm
            long_172 = 0x5f53L,     //Burnout Control Input
            long_173 = 0x5f51L,     //Burnout Control
            long_174 = 0x62a2L,     //IAT Corr Table #1
            long_175 = 0x6ab6L,     //IAT Corr Table #3
            long_176 = 0x622eL,     //IAT Corr Table #2
            long_177 = 0x6a96L,     //ECT Corr Table #2
            long_178 = 0x630bL,     //ECT Corr Table #1
            long_179 = 0x6518L,     //Crank Corr Table

            long_180 = 0x611bL,     //Enabled Ign Corr
            long_181 = 0x611cL,     //disable ign corr above Load
            long_183 = 0x6426L,     //Individual Cyl Corr Table #1
            long_184 = 0x6134L,     //Individual Cyl Corr Table #2
            long_185 = 0x6442L,     //Injector Table
            long_186 = 0x6128L,     //Gear Corr Table #1
            long_188 = 0x6127L,     //Gear Corr Above VSS
            long_187 = 0x612eL,     //Gear Corr Table #2
            long_189 = 0x5f44L,     //Gear Corr Above Load

            long_190 = 0x63b2L,     //Closeloop Table
            long_191 = 0x6aecL,     //Idle Ign Corr Table
            long_192 = 0x5f9dL,     //Idle Ign Corr Enabled
            long_193 = 0x5f9eL,     //Idle Ign Corr Above ect
            //long_194 = 0x649cL,   //#### NOT USED ### missing baro fuel BUT IT IS NEVER USED
            long_195 = 0x5fa3L,
            long_196 = 0x5fa1L,
            long_197 = 0x5fa2L,
            long_198 = 0x5f9fL, 
            long_199 = 0x5fa0L,

            long_200 = 0x5fa4L,
            long_201 = 0x6b7dL,
            long_202 = 0x6b77L,
            long_203 = 0x6ba7L,
            long_204 = 0x6b6aL,
            long_205 = 0x6b5cL,
            long_206 = 0x6111L,
            long_207 = 0x6112L,
            long_208 = 0x6113L,
            long_209 = 0x63caL,

            long_210 = 0x63beL,
            long_211 = 0x6167L,
            long_212 = 0x6169L,
            long_213 = 0x61d5L,
            long_215 = 0x61d7L,
            long_216 = 0x61d4L,
            long_217 = 0x5f5aL,
            long_218 = 0x61f2L,
            long_219 = 0x6209L,

            long_220 = 0x611fL,
            long_221 = 0x6657L,
            long_223 = 0x611eL,
            long_224 = 0x6123L,
            long_225 = 0x6124L,
            long_227 = 0x6121L,
            long_228 = 0x6120L,
            long_229 = 0x6122L,

            long_230 = 0x611dL,
            long_231 = 0x5f7bL,
            long_232 = 0x5f7cL,
            long_233 = 0x5f7dL,
            long_234 = 0x6215L,
            long_235 = 0x6119L,
            long_236 = 0x6201L,
            long_237 = 0x5fc9L,
            long_239 = 0x5f73L,

            long_240 = 0x5f74L,
            long_241 = 0x6114L,
            long_242 = 0x5f4bL,
            long_243 = 0x6116L,
            long_244 = 0x6117L,
            long_245 = 0x6738L,
            long_246 = 0x6170L,
            long_247 = 0x6171L,
            long_248 = 0x6172L,
            long_249 = 0x6173L,

            long_251 = 0x6178L,
            long_253 = 0x6175L,
            long_254 = 0x6177L,
            long_255 = 0x6176L,
            long_256 = 0x5fffL,
            long_257 = 0x618bL,
            long_258 = 0x617fL,
            long_259 = 0x6185L,

            long_260 = 0x6037L,
            long_261 = 0x6021L,
            long_262 = 0x600bL,
            long_263 = 0x604dL,
            long_264 = 0x5fb3L,
            long_265 = 0x5f6bL,
            long_266 = 0x5fa7L,
            long_267 = 0x6199L,
            long_268 = 0x5f75L,
            long_269 = 0x5fafL,

            long_270 = 0x5f63L,
            long_271 = 0x619bL,
            long_272 = 0x617cL,
            long_273 = 0x617bL,
            long_274 = 0x617aL,
            long_275 = 0x617dL,
            long_276 = 0x617eL,
            long_277 = 0x6198L,
            long_279 = 0x6197L,

            long_280 = 0x615bL,
            long_281 = 0x615cL,
            long_282 = 0x619cL,
            long_283 = 0x619dL,
            long_284 = 0x619eL,
            long_285 = 0x61a0L,
            long_286 = 0x619fL,
            long_287 = 0x61a5L,
            long_288 = 0x61a4L,
            long_289 = 0x61a3L,

            long_290 = 0x61a2L,
            long_291 = 0x61aaL,
            long_292 = 0x61adL,
            long_293 = 0x61aeL,
            long_294 = 0x61abL,
            long_295 = 0x61acL,
            long_296 = 0x61b0L,
            long_297 = 0x61afL,
            long_298 = 0x61b1L,
            long_299 = 0x61b2L,

            long_300 = 0x61b4L,
            long_301 = 0x61b6L,
            long_302 = 0x61b7L,
            long_303 = 0x61b8L,
            long_304 = 0x61b9L,
            long_305 = 0x61baL,
            long_306 = 0x61bbL,
            long_307 = 0x61bcL,
            long_308 = 0x61beL,
            long_309 = 0x61bdL,

            long_310 = 0x6057L,
            long_311 = 0x606dL,
            long_313 = 0x5fcdL,
            long_314 = 0x5fd0L,
            long_315 = 0x5fd1L,
            long_316 = 0x5fceL,
            long_317 = 0x5fcfL,
            long_318 = 0x5fd3L,
            long_319 = 0x5fd2L,

            long_320 = 0x5fd4L,
            long_321 = 0x5fd5L,
            long_322 = 0x5fd7L,
            long_323 = 0x5fd9L,
            long_324 = 0x5fdaL,
            long_325 = 0x5fdbL,
            long_326 = 0x5fdcL,
            long_327 = 0x5fddL,
            long_328 = 0x5fdeL,
            long_329 = 0x5fdfL,

            long_330 = 0x5fe1L,
            long_331 = 0x5fe0L,
            long_332 = 0x608eL,
            long_333 = 0x60a4L,
            long_335 = 0x5fe2L,
            long_336 = 0x5fe5L,
            long_337 = 0x5fe6L,
            long_338 = 0x5fe3L,
            long_339 = 0x5fe4L,

            long_340 = 0x5fe8L,
            long_341 = 0x5fe7L,
            long_342 = 0x5fe9L,
            long_343 = 0x5feaL,
            long_344 = 0x5fecL,
            long_345 = 0x5feeL,
            long_346 = 0x5fefL,
            long_347 = 0x5ff0L,
            long_348 = 0x5ff1L,
            long_349 = 0x5ff2L,

            long_350 = 0x5ff3L,
            long_351 = 0x5ff4L,
            long_352 = 0x5ff6L,
            long_353 = 0x5ff5L,
            long_354 = 0x60c5L,
            long_355 = 0x60dbL,
            long_357 = 0x61c0L,
            long_358 = 0x61c1L,
            long_359 = 0x61c2L,

            long_360 = 0x61c3L,
            long_361 = 0x61c4L,
            long_362 = 0x61c6L,
            long_363 = 0x61c7L,
            long_364 = 0x61c8L,
            long_365 = 0x61cbL,
            long_366 = 0x61c9L,
            long_367 = 0x61ccL,
            long_368 = 0x61caL,
            long_369 = 0x61cdL,

            long_370 = 0x5facL,
            long_371 = 0x5fadL,
            long_372 = 0x5faeL,
            long_373 = 0x5fa8L,
            long_374 = 0x6a7aL,
            long_375 = 0x6a56L,
            long_376 = 0x6a66L,
            long_377 = 0x5f5bL, //lean protect min rpm
            long_378 = 0x5f5dL, //lean protect min tps
            long_379 = 0x5f5fL, //lean protect

            long_380 = 0x5f5eL, //lean protect
            long_381 = 0x5f60L, //lean protect
            long_382 = 0x5f61L, //lean protect
            long_383 = 0x5fb0L, //lean protect
            long_384 = 0x5f62L, //lean protect
            long_385 = 0x5fb1L, //lean protect
            long_386 = 0x5fb2L, //lean protect

            long_390 = 0x633eL,      //closeloop rate of change
            long_391 = 0x6216L,      //injector phase

            //THOSE ADDRESE CAN VARY WHEN CHANGING BASEROM
            long_402 = 0x5f2fL,     //FTS Speed

            long_420 = 0x61d8L,     //ignition cut delay
            long_421 = 0x61e4L,     //Ignition Cut Delay (FTL - Launch)
            long_422 = 0x61e5L,     //Ignition Cut Delay (FTS)
            long_423 = 0x61e6L,     //Ignition Cut Fuel Adding
            long_424 = 0x61e8L,     //Ignition Cut Ign retarding

            //Antitheft
            long_430 = 0x61d9L,     //acs input
            long_431 = 0x61daL,     //psp input
            long_432 = 0x61dbL,     //scs input
            long_433 = 0x61dcL,     //bkws input
            long_434 = 0x61ddL,     //vtp input
            //long_435 = 0x61deL,     //tps require
            //long_436 = 0x61dfL,     //tps min
            //long_437 = 0x61e0L,     //tps min
            long_438 = 0x61e1L,     //locking rpm
            long_439 = 0x61e3L,     //antitheft enabled

            long_440 = 0x61e4L,     //FTS strain cut active

            long_450 = 0x62f3L,     //injector rate of decay1
            long_451 = 0x62fbL,     //injector rate of decay2
            long_452 = 0x6303L,     //injector rate of decay3
            long_453 = 0x6533L,     //crank fuel RPM Compensation
            long_454 = 0x6537L,     //crank fuel MAP Compensation

            long_460 = 0x5f18L,     //FlexFuel Ethanol Content
            long_461 = 0x5f06L,     //FlexFuel Fuel - Closeloop
            long_463 = 0xf0ffL,     //FlexFuel Fuel - Cranking
            long_464 = 0x5f20L,     //FlexFuel Ignition - Closeloop
            /*long_460 = 0x5f18L,     //FlexFuel Ethanol Content
            long_461 = 0x5ef4L,     //FlexFuel Fuel - Closeloop
            long_463 = 0x5f06L,     //FlexFuel Fuel - Cranking
            long_464 = 0x5f20L,     //FlexFuel Ignition - Closeloop*/

            long_466 = 0x61deL,     //FlexFuel Input

            //long_471 = 0x61e8L,     //FTS Ign (Not used)
            long_472 = 0x61eaL,     //FTS Ign Mode (Static or vise versa)
            long_473 = 0x61e9L,     //FTS Static Ignition Value
            long_474 = 0x61ebL,     //Fan Cutout Speed
            long_475 = 0x61ecL,     //AC Cutout Speed

            long_480 = 0x6afcL,     //Ignition Controlled Idle Low Table    hondata 53a8
            long_481 = 0x6aecL,     //Ignition Controlled Idle High Table   hondata 5398
            long_482 = 0x653bL,     //Overrun Fuel resume (initial)   hondata 4f4b
            long_483 = 0x6549L,     //Overrun Fuel resume (normal)   hondata 4f59
            long_484 = 0x646cL,     //Tip-In Fuel (initial)   hondata 4ea6
            long_485 = 0x645aL,     //Tip-In Fuel (normal)   hondata 4e94

            long_492 = 0xf000L,     //TPS Error
            long_405 = 0xf001L,     //IAT Error
            long_406 = 0xf002L,     //IAT Temp
            long_493 = 0xf003L,     //Ign Cut Mod (Soft/Hard)
            //long_494 = 0xf004L,     //Ign Cut Mod (With fuel/ign mod or not)
            //long_494 = 0x5ef3L,     //Ign Cut Mod (With fuel/ign mod or not)
            long_494 = 0x5f05L,     //Ign Cut Mod (With fuel/ign mod or not)

            long_403 = 0xf005L,     //ECT Error
            long_401 = 0xf006L,     //VSS Error
            long_400 = 0xf007L,     //VSS Corr
            long_407 = 0xf008L,     //TPS Error
            long_408 = 0xf009L,     //CYP Error
            //long_408 = 0x61dfL,     //CYP Error Code9
            //long_409 = 0x61fcL,     //CKP Error Code8
            //long_408 = 0x61faL,     //CYP Error Code9
            //long_409 = 0x61ffL,     //CKP Error Code8
            //long_410 = 0xf00bL,     //TDC Error

            long_413 = 0xf00eL,     //Traction Control Error
            long_414 = 0xf00fL,     //Automatic Transmission B Signal Error

            long_4Inj = 0x61a9L,
            //long_4PASS = 0x5ea6L

            long_510 = 0x5f9cL, //long_324 in HTS used in knock
            long_511 = 0x5f8aL, //long_325 in HTS used in knock
            long_512 = 0x61dfL, //long_326 in HTS used in knock
            long_513 = 0x5f8aL, //long_327 in HTS used in knock
            long_514 = 0x5fa4L, //long_328 in HTS  ** Used in flex Fuel !!!!! **

            //long_515 = 0x61e0L, //used to know the wideband sensor

            long_520 = 0xf009L,   ///rev limiter cutting type
            long_521 = 0xf00aL,   //enable CPR on ALTC
            long_522 = 0xf00bL,   //CPR fully sync when cranking
            long_523 = 0xf00cL,   //CPR dont fire before sync

            long_525 = 0xf00dL,   //enable MIL on Ignition Cut

            long_530_vts = 0xf00dL,       //test output
            long_531_fpump = 0xf00dL,     //test output
            long_532_a10 = 0xf00dL,       //test output
            long_533_ac = 0xf00dL,        //test output
            long_534_pcs = 0xf00dL,       //test output
            long_535_iab = 0xf00dL,       //test output
            long_536_fanc = 0xf00dL,      //test output
            long_537_altc = 0xf00dL,      //test output
        };
        this.class13_u_0 = class13_u_1;
        class13_u_1 = null;
        //GetInputsOutputsLocations();
        //Get_Area();
        //GetECT_IAT_Temp_Area();
    }

    public void GetInputsOutputsLocations()
    {
        if (InputsListLocations != null) InputsListLocations = null;
        InputsListLocations = new List<long>();
        InputsListDesc = new List<string>();
        InputsListLocations.Add(this.class13_u_0.long_357); InputsListDesc.Add("Manual Boost Controller");
        InputsListLocations.Add(this.class13_u_0.long_172); InputsListDesc.Add("Burnout Control");
        InputsListLocations.Add(this.class13_u_0.long_283); InputsListDesc.Add("Dual Map Switching (Primary/Sec)");
        InputsListLocations.Add(this.class13_u_0.long_246); InputsListDesc.Add("Electronic Boost Controller (EBC) PWM");
        InputsListLocations.Add(this.class13_u_0.long_248); InputsListDesc.Add("Electronic Boost Controller (EBC) PWM Hi/Lo");
        InputsListLocations.Add(this.class13_u_0.long_137); InputsListDesc.Add("Launch Control");
        InputsListLocations.Add(this.class13_u_0.long_147); InputsListDesc.Add("Full Throttle Shift");
        InputsListLocations.Add(this.class13_u_0.long_292); InputsListDesc.Add("General Outputs (GPO) #1");
        InputsListLocations.Add(this.class13_u_0.long_314); InputsListDesc.Add("General Outputs (GPO) #2");
        InputsListLocations.Add(this.class13_u_0.long_336); InputsListDesc.Add("General Outputs (GPO) #3");
        InputsListLocations.Add(this.class13_u_0.long_114); InputsListDesc.Add("Extras (SCC Input)");

        if (OutputsListLocations != null) OutputsListLocations = null;
        OutputsListLocations = new List<long>();
        OutputsListDesc = new List<string>();
        OutputsListLocations.Add(this.class13_u_0.long_364); OutputsListDesc.Add("Manual Boost Controller Stage2");
        OutputsListLocations.Add(this.class13_u_0.long_366); OutputsListDesc.Add("Manual Boost Controller Stage3");
        OutputsListLocations.Add(this.class13_u_0.long_368); OutputsListDesc.Add("Manual Boost Controller Stage4");
        OutputsListLocations.Add(this.class13_u_0.long_110); OutputsListDesc.Add("Fan Control");
        OutputsListLocations.Add(this.class13_u_0.long_294); OutputsListDesc.Add("General Outputs (GPO) #1");
        OutputsListLocations.Add(this.class13_u_0.long_316); OutputsListDesc.Add("General Outputs (GPO) #2");
        OutputsListLocations.Add(this.class13_u_0.long_338); OutputsListDesc.Add("General Outputs (GPO) #3");
        OutputsListLocations.Add(this.class13_u_0.long_239); OutputsListDesc.Add("IAB");
        OutputsListLocations.Add(this.class13_u_0.long_232); OutputsListDesc.Add("Vtec");
    }

    public void GetECT_IAT_Temp_Area()
    {
        //GetRomVersion();

        for (int i = 0; i < GetByteLenght(); i++)
        {
            //ECT Temp      D5 D9 A3 1C CB
            if (GetByteAt(i) == 0xD5 && GetByteAt(i + 1) == 0xD9 && GetByteAt(i + 2) == 0xA3 && GetByteAt(i + 3) == 0x1C && GetByteAt(i + 4) == 0xCB)
            {
                this.class13_u_0.long_404 = i + 9;
            }
            //Closeloop Long Term       DA 16 05 C5 B8
            if (GetByteAt(i) == 0xDA && GetByteAt(i + 1) == 0x16 && GetByteAt(i + 2) == 0x05 && GetByteAt(i + 3) == 0xC5 && GetByteAt(i + 4) == 0xB8)
            {
                this.class13_u_0.long_415 = i + 10;
                this.class13_u_0.long_416 = i + 16;
            }
            //###############################################################################
            //THIS IS ANOTHER ROM LOCATION THAT SHARE SENSORS DEFAULT VALUE IF SENSORS FAIL
            //ECT/IAT Temp #2       D5 DA 62 D1 03
            if (GetByteAt(i) == 0xD5 && GetByteAt(i + 1) == 0xDA && GetByteAt(i + 2) == 0x62 && GetByteAt(i + 3) == 0xD1 && GetByteAt(i + 4) == 0x03)
            {
                this.class13_u_0.long_490 = i + 15;
                this.class13_u_0.long_491 = i + 11;
            }
            //###############################################################################
            //ECT Disable       C4 30 1D C5 B0
            if (GetByteAt(i) == 0xC4 && GetByteAt(i + 1) == 0x30 && GetByteAt(i + 2) == 0x1D && GetByteAt(i + 3) == 0xC5 && GetByteAt(i + 4) == 0xB0)
            {
                this.class13_u_0.long_403 = i + 7; //ECT Disable
            }
            //IAT ERROR         C4 19 2E C5 B0
            if (GetByteAt(i) == 0xC4 && GetByteAt(i + 1) == 0x19 && GetByteAt(i + 2) == 0x2E && GetByteAt(i + 3) == 0xC5 && GetByteAt(i + 4) == 0xB0)
            {
                this.class13_u_0.long_405 = i + 7; //IAT Disable
                this.class13_u_0.long_406 = i + 16; //IAT Temp
            }
            //VSS ERROR         C4 1C 2C C5 B1
            if (GetByteAt(i) == 0xC4 && GetByteAt(i + 1) == 0x1C && GetByteAt(i + 2) == 0x2C && GetByteAt(i + 3) == 0xC5 && GetByteAt(i + 4) == 0xB1)
            {
                this.class13_u_0.long_401 = i + 8; //VSS Disable
                this.class13_u_0.long_400 = i + 12; //VSS Correction
            }
            //TPS ERROR         11 44 15 89 77
            if (GetByteAt(i) == 0x11 && GetByteAt(i + 1) == 0x44 && GetByteAt(i + 2) == 0x15 && GetByteAt(i + 3) == 0x89 && GetByteAt(i + 4) == 0x77)
            {
                this.class13_u_0.long_407 = i + 5; //TPS Disable
            }
            //CYP ERROR         C5 B5 19 B4 34
            if (GetByteAt(i) == 0xc5 && GetByteAt(i + 1) == 0xb5 && GetByteAt(i + 2) == 0x19 && GetByteAt(i + 3) == 180 && GetByteAt(i + 4) == 0x34)
            {
                this.class13_u_0.long_408 = i + 12;
            }
            //TDC ERROR     C5 B5 19 B4 34
            /*if (GetByteAt(i) == 0xC5 && GetByteAt(i + 1) == 0xB5 && GetByteAt(i + 2) == 0x19 && GetByteAt(i + 3) == 0xB5 && GetByteAt(i + 4) == 0xA2)
            {
                //this.class13_0.long_410 = i + 6;  //TDC Disable
            }*/
            //Traction Control ERROR EF 33 03 C4 32
            if (GetByteAt(i) == 0xEF && GetByteAt(i + 1) == 0x33 && GetByteAt(i + 2) == 0x03 && GetByteAt(i + 3) == 0xC4 && GetByteAt(i + 4) == 0x32)
            {
                this.class13_u_0.long_413 = i + 9; //Traction Control Disable
            }
            //Automatic Transmission B Signal ERROR CB 01 95 C5 B3
            if (GetByteAt(i) == 0xCB && GetByteAt(i + 1) == 0x01 && GetByteAt(i + 2) == 0x95 && GetByteAt(i + 3) == 0xC5 && GetByteAt(i + 4) == 0xB3)
            {
                this.class13_u_0.long_414 = i + 6; //Automatic Transmission B Signal Disable
            }
        }
    }

    public void Get_TestOutputs_Area()
    {
        if (RomVersion >= 116)
        {
            for (int i = 0; i < GetByteLenght(); i++)
            {
                //5714009299 = CPR fully sync when cranking
                if (GetByteAt(i) == 0x57 && GetByteAt(i + 1) == 0x14 && GetByteAt(i + 2) == 0x00 && GetByteAt(i + 3) == 0x92 && GetByteAt(i + 4) == 0x99)
                {
                    this.class13_u_0.long_522 = i + 21;
                }
                //62B803D2 = CPR dont fire before sync
                if (GetByteAt(i) == 0x62 && GetByteAt(i + 1) == 0xb8 && GetByteAt(i + 2) == 0x03 && GetByteAt(i + 3) == 0xd2)
                {
                    this.class13_u_0.long_523 = i + 17;
                }
            }
        }

        if (RomVersion >= 120)
        {
            for (int i = 0; i < GetByteLenght(); i++)
            {
                //79D4A477 = vts
                if (GetByteAt(i) == 0x79 && GetByteAt(i + 1) == 0xd4 && GetByteAt(i + 2) == 0xa4 && GetByteAt(i + 3) == 0x77)
                {
                    this.class13_u_0.long_530_vts = i + 4;
                }
                //EE190777 = fpump
                if (GetByteAt(i) == 0xee && GetByteAt(i + 1) == 0x19 && GetByteAt(i + 2) == 0x07 && GetByteAt(i + 3) == 0x77)
                {
                    this.class13_u_0.long_531_fpump = i + 4;
                }
                //85C5203877 = ac
                if (GetByteAt(i) == 0x85 && GetByteAt(i + 1) == 0xc5 && GetByteAt(i + 2) == 0x20 && GetByteAt(i + 3) == 0x38 && GetByteAt(i + 4) == 0x77)
                {
                    this.class13_u_0.long_533_ac = i + 5;
                    this.class13_u_0.long_532_a10 = i + 13;
                }
                //C4ED3D77 = pcs
                if (GetByteAt(i) == 0xc4 && GetByteAt(i + 1) == 0xed && GetByteAt(i + 2) == 0x3d && GetByteAt(i + 3) == 0x77)
                {
                    this.class13_u_0.long_534_pcs = i + 4;
                }
                //C5203977 = iab
                if (GetByteAt(i) == 0xc5 && GetByteAt(i + 1) == 0x20 && GetByteAt(i + 2) == 0x39 && GetByteAt(i + 3) == 0x77)
                {
                    this.class13_u_0.long_535_iab = i + 4;
                }
                //C499C01E = fanc
                if (GetByteAt(i) == 0xc4 && GetByteAt(i + 1) == 0x99 && GetByteAt(i + 2) == 0xc0 && GetByteAt(i + 3) == 0x1e)
                {
                    this.class13_u_0.long_536_fanc = i + 9;
                }
                //72C22FA2 = altc
                if (GetByteAt(i) == 0x72 && GetByteAt(i + 1) == 0xC2 && GetByteAt(i + 2) == 0x2F && GetByteAt(i + 3) == 0xA2)
                {
                    this.class13_u_0.long_537_altc = i + 12;
                }
            }
        }

        this.class17_0.frmMain_0.SetTestOutputsInfos();
    }

    public bool GetIgnitionCutMODInstalled()
    {
        //GetRomVersion();
        bool Installed = false;

        if (RomVersion >= 102 && RomVersion < 109)
        {
            for (int i = 0; i < GetByteLenght(); i++)
            {
                //62 09 04 C2 29
                if (GetByteAt(i) == 0x62 && GetByteAt(i + 1) == 0x09 && GetByteAt(i + 2) == 0x04 && GetByteAt(i + 3) == 0xC2 && GetByteAt(i + 4) == 0x29)
                {
                    if (GetByteAt(i - 5) == 0xe6 && GetByteAt(i - 4) == 0x00)
                    {
                        Installed = true;
                        i = GetByteLenght();
                    }
                }
            }
        }

        return Installed;
    }

    public void InstallCYPMod()
    {
        for (int i = 0; i < GetByteLenght(); i++)
        {
            //53 + C4273F
            //off(00212h).3     //Code4 CKP
            //off(00212h).7     //Code8 TDC
            //off(00213h).0     //Code9 CYL
            //off(00213h).5     //Code14 IACV

            //90 9D FA 61 53
            /*if (GetByteAt(i) == 0x90 && GetByteAt(i + 1) == 0x9D && GetByteAt(i + 2) == 0xFA && GetByteAt(i + 3) == 0x61 && GetByteAt(i + 4) == 0x53)
            {
                //CYP - Code9
                SetByteAt(i + 5, 0xc4);
                SetByteAt(i + 6, 0x13);
                SetByteAt(i + 7, 0x38);

                SetByteAt(0x61fa, 0x00);

                //CKP - Code8
                //SetByteAt(i + 21, 0xc4);
                //SetByteAt(i + 22, 0x12);
                //SetByteAt(i + 23, 0x3b);

                i = GetByteLenght();
            }*/

            //90 9D 0E 62 53
            /*if (GetByteAt(i) == 0x90 && GetByteAt(i + 1) == 0x9D && GetByteAt(i + 2) == 0x0E && GetByteAt(i + 3) == 0x62 && GetByteAt(i + 4) == 0x53)
            {
                i += 8;
                int StartIndex = i;
                while (GetByteAt(StartIndex) != 0xff && GetByteAt(StartIndex + 1) != 0xff && GetByteAt(StartIndex + 2) != 0xff && GetByteAt(StartIndex + 3) != 0xff) 
                {
                    StartIndex++;
                }

                for (int i2 = StartIndex + 16; i2 > i; i2--) SetByteAt(i2, GetByteAt(i2 - 16));

                //90 9D FB 61 53 C4 13 38
                //90 9D FC 61 53 C4 12 3B
                //CYP - Code9
                SetByteAt(i, 0x90);
                SetByteAt(i + 1, 0x9d);
                SetByteAt(i + 2, 0xfb);
                SetByteAt(i + 3, 0x61);
                SetByteAt(i + 4, 0x53);
                SetByteAt(i + 5, 0xc4);
                SetByteAt(i + 6, 0x13);
                SetByteAt(i + 7, 0x38);

                //CKP - Code8
                SetByteAt(i + 8, 0x90);
                SetByteAt(i + 9, 0x9d);
                SetByteAt(i + 10, 0xfc);
                SetByteAt(i + 11, 0x61);
                SetByteAt(i + 12, 0x53);
                SetByteAt(i + 13, 0xc4);
                SetByteAt(i + 14, 0x12);
                SetByteAt(i + 15, 0x3b);

                i = GetByteLenght();
            }*/
        }
    }

    public List<long> GetInputsListLocations()
    {
        return InputsListLocations;
    }

    public List<string> GetInputsListDesc()
    {
        return InputsListDesc;
    }

    public List<long> GetOutputsListLocations()
    {
        return OutputsListLocations;
    }

    public List<string> GetOutputsListDesc()
    {
        return OutputsListDesc;
    }

    public int GetStable_Version_LAST()
    {
        return Stable_Version_LAST;
    }

    public void method_149_Bytes_String(long long_0_X, string TheseBytes)
    {
        //if (long_0_X != 0)
        if (long_0_X > 80)
        {
            int NumberChars = TheseBytes.Length;
            byte[] byte_3 = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2) byte_3[i / 2] = Convert.ToByte(TheseBytes.Substring(i, 2), 16);

            bool Same = true;
            for (int i = 0; i < byte_3.Length; i++) if (GetByteAt((int)((IntPtr)long_0_X) + i) != byte_3[i]) Same = false;

            if (!Same)
            {
                if (!this.class11_u_0.method_3() && this.method_30_HasFileLoadedInBMTune())
                {
                    for (int i = 0; i < byte_3.Length; i++)
                    {
                        this.class11_u_0.method_0(long_0_X + i, GetByteAt((int)((IntPtr)long_0_X)), byte_3[i]);
                    }
                }

                for (int i = 0; i < byte_3.Length; i++)
                {
                    SetByteAt((int)((IntPtr)long_0_X + i), byte_3[i]);
                    //this.class25_0.method_18(long_0_X + i, byte_3[i]);   //RTP Upload this Byte
                }
            }
        }
    }

    public void method_153()
    {
        this.class11_u_0.method_10(false, null, false, false);
    }

    public void method_154()
    {
        this.class11_u_0.method_10(false, null, false, true);
    }

    public void method_155(string string_8)
    {
        this.class17_0.frmMain_0.LogThis("Settings - " + string_8);
        this.class11_u_0.method_10(true, string_8, false, false);
    }

    public void method_156(string string_8, bool bool_3)
    {
        this.class17_0.frmMain_0.LogThis("Settings - " + string_8);
        this.class11_u_0.method_10(true, string_8, bool_3, false);
    }

    public bool method_157()
    {
        return this.class11_u_0.method_1();
    }

    public bool method_158()
    {
        return this.class11_u_0.method_2();
    }

    public int method_159(byte byte_3)
    {
        int num = 0;
        long num2 = 0L;
        switch (this.method_4())
        {
            case SelectedTable.undefined:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");

            case SelectedTable.ign1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.ign1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.fuel1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.fuel1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.ign2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.ign2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.fuel2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.fuel2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.ve_lo:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");

            case SelectedTable.ve_hi:
                num2 = this.class13_u_0.long_29;
                break;

            default:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");
        }
        num = this.GetByteAt(num2 + byte_3);
        if ((num <= 0) && (byte_3 > 0))
        {
            num += 0x100;
        }
        if (this.method_35())
        {
            return this.method_186(num);
        }
        if (!this.method_36())
        {
            this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
            return 0;
            //throw new Exception("Get RpmScalar Error");
        }
        return this.method_187(num);
    }

    public int method_160(byte byte_3, SelectedTable selectedTable_1)
    {
        int num = 0;
        long num2 = 0L;
        switch (selectedTable_1)
        {
            case SelectedTable.undefined:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");

            case SelectedTable.ign1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.ign1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.fuel1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.fuel1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.ign2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.ign2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.fuel2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.fuel2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.ve_lo:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");

            case SelectedTable.ve_hi:
                num2 = this.class13_u_0.long_29;
                break;

            default:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");
        }
        num = this.GetByteAt(num2 + byte_3);
        if ((num <= 0) && (byte_3 > 0))
        {
            num += 0x100;
        }
        if (this.method_35_Selectable(selectedTable_1))
        {
            return this.method_186(num);
        }
        if (!this.method_36_Selectable(selectedTable_1))
        {
            this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
            return 0;
            //throw new Exception("Get RpmScalar Error");
        }
        return this.method_187(num);
    }


    public int method_162(byte byte_3, SelectedTable selectedTable_1)
    {
        long num = 0L;
        switch (selectedTable_1)
        {
            case SelectedTable.undefined:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");

            case SelectedTable.ign1_lo:
                num = this.class13_u_0.long_8;
                break;

            case SelectedTable.ign1_hi:
                num = this.class13_u_0.long_9;
                break;

            case SelectedTable.fuel1_lo:
                num = this.class13_u_0.long_8;
                break;

            case SelectedTable.fuel1_hi:
                num = this.class13_u_0.long_9;
                break;

            case SelectedTable.ign2_lo:
                num = this.class13_u_0.long_16;
                break;

            case SelectedTable.ign2_hi:
                num = this.class13_u_0.long_17;
                break;

            case SelectedTable.fuel2_lo:
                num = this.class13_u_0.long_16;
                break;

            case SelectedTable.fuel2_hi:
                num = this.class13_u_0.long_17;
                break;

            case SelectedTable.ve_lo:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");

            case SelectedTable.ve_hi:
                num = this.class13_u_0.long_29;
                break;

            default:
                this.class17_0.frmMain_0.LogThis("Get RpmScalar Error");
                return 0;
                //throw new Exception("Get RpmScalar Error");
        }
        return this.GetByteAt(num + byte_3);
    }

    public int method_163(byte byte_3)
    {
        int num = 0;
        switch (this.method_4())
        {
            case SelectedTable.undefined:
                break;

            case SelectedTable.ign1_lo:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.ign1_hi:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.fuel1_lo:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.fuel1_hi:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.ign2_lo:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.ign2_hi:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.fuel2_lo:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.fuel2_hi:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.ve_lo:
                num = this.GetByteAt(this.class13_u_0.long_30 + byte_3);
                break;

            case SelectedTable.ve_hi:
                num = this.GetByteAt(this.class13_u_0.long_30 + byte_3);
                break;

            default:
                this.class17_0.frmMain_0.LogThis("GetMapScalarMbar error");
                return 0;
                //throw new Exception("GetMapScalarMbar error");
        }
        if ((num <= 0) && (byte_3 > 0))
        {
            num += 0x100;
        }
        return this.method_206(num);
    }

    public int method_164(byte byte_3, SelectedTable selectedTable_1)
    {
        int num = 0;
        switch (selectedTable_1)
        {
            case SelectedTable.undefined:
                break;

            case SelectedTable.ign1_lo:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.ign1_hi:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.fuel1_lo:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.fuel1_hi:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.ign2_lo:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.ign2_hi:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.fuel2_lo:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.fuel2_hi:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.ve_lo:
                num = this.GetByteAt(this.class13_u_0.long_30 + byte_3);
                break;

            case SelectedTable.ve_hi:
                num = this.GetByteAt(this.class13_u_0.long_30 + byte_3);
                break;

            default:
                this.class17_0.frmMain_0.LogThis("GetMapScalarMbar error");
                return 0;
                //throw new Exception("GetMapScalarMbar error");
        }
        if ((num <= 0) && (byte_3 > 0))
        {
            num += 0x100;
        }
        return this.method_206(num);
    }

    public int method_165(byte byte_3)
    {
        int num = 0;
        switch (this.method_4())
        {
            case SelectedTable.undefined:
                return num;

            case SelectedTable.ign1_lo:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.ign1_hi:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.fuel1_lo:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.fuel1_hi:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.ign2_lo:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.ign2_hi:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.fuel2_lo:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.fuel2_hi:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.ve_lo:
                return this.GetByteAt(this.class13_u_0.long_30 + byte_3);

            case SelectedTable.ve_hi:
                return this.GetByteAt(this.class13_u_0.long_30 + byte_3);
        }
        this.class17_0.frmMain_0.LogThis("GetMapScalarRaw error");
        return 0;
        //throw new Exception("GetMapScalarRaw error");
    }

    public int method_166(byte byte_3, SelectedTable selectedTable_1)
    {
        int num = 0;
        switch (selectedTable_1)
        {
            case SelectedTable.undefined:
                return num;

            case SelectedTable.ign1_lo:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.ign1_hi:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.fuel1_lo:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.fuel1_hi:
                return this.GetByteAt(this.class13_u_0.long_6 + byte_3);

            case SelectedTable.ign2_lo:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.ign2_hi:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.fuel2_lo:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.fuel2_hi:
                return this.GetByteAt(this.class13_u_0.long_18 + byte_3);

            case SelectedTable.ve_lo:
                return this.GetByteAt(this.class13_u_0.long_30 + byte_3);

            case SelectedTable.ve_hi:
                return this.GetByteAt(this.class13_u_0.long_30 + byte_3);
        }
        this.class17_0.frmMain_0.LogThis("GetMapScalarRaw error");
        return 0;
        //throw new Exception("GetMapScalarRaw error");
    }

    public string method_167(byte byte_3)
    {
        int num = 0;
        switch (this.method_4())
        {
            case SelectedTable.undefined:
                break;

            case SelectedTable.ign1_lo:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.ign1_hi:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.fuel1_lo:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.fuel1_hi:
                num = this.GetByteAt(this.class13_u_0.long_6 + byte_3);
                break;

            case SelectedTable.ign2_lo:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.ign2_hi:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.fuel2_lo:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.fuel2_hi:
                num = this.GetByteAt(this.class13_u_0.long_18 + byte_3);
                break;

            case SelectedTable.ve_lo:
                num = this.GetByteAt(this.class13_u_0.long_30 + byte_3);
                break;

            case SelectedTable.ve_hi:
                num = this.GetByteAt(this.class13_u_0.long_30 + byte_3);
                break;

            default:
                this.class17_0.frmMain_0.LogThis("GetMapScalarDisplay error");
                return "";
                //throw new Exception("GetMapScalarDisplay error");
        }
        if ((num <= 0) && (byte_3 > 0))
        {
            num += 0x100;
        }
        return this.method_195(num);
    }

    public void method_168(byte byte_3, int int_3)
    {
        byte num = 0;
        long num2 = 0L;
        switch (this.method_4())
        {
            case SelectedTable.undefined:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");

            case SelectedTable.ign1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.ign1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.fuel1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.fuel1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.ign2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.ign2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.fuel2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.fuel2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.ve_lo:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");

            case SelectedTable.ve_hi:
                num2 = this.class13_u_0.long_29;
                break;

            default:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");
        }
        if (this.method_35())
        {
            num = this.method_216(int_3);
            if ((num == 0xff) && (byte_3 > 0))
            {
                num = 0;
            }
            this.method_149_SetByte(num2 + byte_3, num);
            if (this.delegate55_0 != null)
            {
                this.delegate55_0();
            }
        }
        else
        {
            if (!this.method_36())
            {
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");
            }
            num = this.method_217(int_3);
            if ((num == 0xff) && (byte_3 > 0))
            {
                num = 0;
            }
            this.method_149_SetByte(num2 + byte_3, num);
            if (this.delegate55_0 != null)
            {
                this.delegate55_0();
            }
        }
    }

    public void method_169(byte byte_3, int int_3, SelectedTable selectedTable_1)
    {
        byte num = 0;
        long num2 = 0L;
        switch (selectedTable_1)
        {
            case SelectedTable.undefined:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");

            case SelectedTable.ign1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.ign1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.fuel1_lo:
                num2 = this.class13_u_0.long_8;
                break;

            case SelectedTable.fuel1_hi:
                num2 = this.class13_u_0.long_9;
                break;

            case SelectedTable.ign2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.ign2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.fuel2_lo:
                num2 = this.class13_u_0.long_16;
                break;

            case SelectedTable.fuel2_hi:
                num2 = this.class13_u_0.long_17;
                break;

            case SelectedTable.ve_lo:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");

            case SelectedTable.ve_hi:
                num2 = this.class13_u_0.long_29;
                break;

            default:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");
        }
        if (((selectedTable_1 == SelectedTable.fuel1_lo) || (selectedTable_1 == SelectedTable.fuel2_lo)) || ((selectedTable_1 == SelectedTable.ign1_lo) || (selectedTable_1 == SelectedTable.ign2_lo)))
        {
            num = this.method_216(int_3);
            if ((num == 0xff) && (byte_3 > 0))
            {
                num = 0;
            }
            this.method_149_SetByte(num2 + byte_3, num);
            if (this.delegate55_0 != null)
            {
                this.delegate55_0();
            }
        }
        else
        {
            if (((selectedTable_1 != SelectedTable.fuel1_hi) && (selectedTable_1 != SelectedTable.fuel2_hi)) && ((selectedTable_1 != SelectedTable.ign1_hi) && (selectedTable_1 != SelectedTable.ign2_hi)))
            {
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");
            }
            num = this.method_217(int_3);
            if ((num == 0xff) && (byte_3 > 0))
            {
                num = 0;
            }
            this.method_149_SetByte(num2 + byte_3, num);
            if (this.delegate55_0 != null)
            {
                this.delegate55_0();
            }
        }
    }

    public void method_170(byte byte_3, byte byte_4, SelectedTable selectedTable_1)
    {
        long num = 0L;
        switch (selectedTable_1)
        {
            case SelectedTable.undefined:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");

            case SelectedTable.ign1_lo:
                num = this.class13_u_0.long_8;
                break;

            case SelectedTable.ign1_hi:
                num = this.class13_u_0.long_9;
                break;

            case SelectedTable.fuel1_lo:
                num = this.class13_u_0.long_8;
                break;

            case SelectedTable.fuel1_hi:
                num = this.class13_u_0.long_9;
                break;

            case SelectedTable.ign2_lo:
                num = this.class13_u_0.long_16;
                break;

            case SelectedTable.ign2_hi:
                num = this.class13_u_0.long_17;
                break;

            case SelectedTable.fuel2_lo:
                num = this.class13_u_0.long_16;
                break;

            case SelectedTable.fuel2_hi:
                num = this.class13_u_0.long_17;
                break;

            case SelectedTable.ve_lo:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");

            case SelectedTable.ve_hi:
                num = this.class13_u_0.long_29;
                break;

            default:
                this.class17_0.frmMain_0.LogThis("Set RpmScalar Error");
                return;
                //throw new Exception("Set RpmScalar Error");
        }
        this.method_149_SetByte(num + byte_3, byte_4);
    }

    public void method_171(byte byte_3, byte byte_4, SelectedTable selectedTable_1)
    {
        long num = 0L;
        switch (selectedTable_1)
        {
            case SelectedTable.ign1_lo:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.ign1_hi:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.fuel1_lo:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.fuel1_hi:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.ign2_lo:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.ign2_hi:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.fuel2_lo:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.fuel2_hi:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.ve_lo:
                num = this.class13_u_0.long_30 + byte_3;
                break;

            case SelectedTable.ve_hi:
                num = this.class13_u_0.long_30 + byte_3;
                break;
        }
        this.method_149_SetByte(num, byte_4);
    }

    public void method_172(byte byte_3, float float_0, int int_3)
    {
        int num = 0;
        if (int_3 < this.method_226(this.class10_settings_0.int_6))
        {
            if (this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.mBar)
            {
                num = (int) float_0;
            }
            else if (this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.Bar)
            {
                num = (int) (float_0 * 1000f);
            }
            else if (this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.inHg)
            {
                num = this.method_247(float_0);
            }
            else if (this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.inHgG)
            {
                num = this.method_247(this.method_246(this.class10_settings_0.int_6) - (float_0 * -1f));
            }
            else if (this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.psi)
            {
                num = this.method_250(float_0);
            }
            else if (this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.kPa)
            {
                num = this.method_249(float_0);
            }
        }
        else if (this.class10_settings_0.mapSensorUnits_1 == MapSensorUnits.mBar)
        {
            num = (int) float_0;
        }
        else if (this.class10_settings_0.mapSensorUnits_1 == MapSensorUnits.Bar)
        {
            num = (int) (float_0 * 1000f);
        }
        else if (this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.inHg)
        {
            num = this.method_247(float_0);
        }
        else if (this.class10_settings_0.mapSensorUnits_1 == MapSensorUnits.psi)
        {
            num = this.method_250(float_0);
        }
        else if (this.class10_settings_0.mapSensorUnits_1 == MapSensorUnits.kPa)
        {
            num = this.method_249(float_0);
        }
        int num2 = 0;
        int num3 = 0;
        if (byte_3 != 0)
        {
            num2 = this.method_163((byte) (byte_3 - 1));
            if (num < num2)
            {
                if (MessageBox.Show(Form.ActiveForm, "Value is lower then the column to the left" + Environment.NewLine + "Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.method_173(byte_3, num);
                }
                else
                {
                    return;
                }
            }
        }
        if (byte_3 != this.method_33())
        {
            num3 = this.method_163((byte) (byte_3 + 1));
            if (num > num3)
            {
                if (MessageBox.Show(Form.ActiveForm, "Value is higher then the column to the right" + Environment.NewLine + "Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.method_173(byte_3, num);
                }
                else
                {
                    return;
                }
            }
        }
        if (byte_3 == this.method_33())
        {
            num2 = this.method_163((byte) (byte_3 - 1));
            if (num < num2)
            {
                if (MessageBox.Show(Form.ActiveForm, "Value is lower then the column to the left" + Environment.NewLine + "Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.method_173(byte_3, num);
                }
                else
                {
                    return;
                }
            }
        }
        if (byte_3 == 0)
        {
            num3 = this.method_163((byte) (byte_3 + 1));
            if (num > num3)
            {
                if (MessageBox.Show(Form.ActiveForm, "Value is higher then the column to the right" + Environment.NewLine + "Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.method_173(byte_3, num);
                }
                else
                {
                    return;
                }
            }
        }
        this.method_173(byte_3, num);
    }

    public void method_173(byte byte_3, int int_3)
    {
        long num = 0L;
        switch (this.method_4())
        {
            case SelectedTable.ign1_lo:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.ign1_hi:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.fuel1_lo:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.fuel1_hi:
                num = this.class13_u_0.long_6 + byte_3;
                break;

            case SelectedTable.ign2_lo:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.ign2_hi:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.fuel2_lo:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.fuel2_hi:
                num = this.class13_u_0.long_18 + byte_3;
                break;

            case SelectedTable.ve_lo:
                num = this.class13_u_0.long_30 + byte_3;
                break;

            case SelectedTable.ve_hi:
                num = this.class13_u_0.long_30 + byte_3;
                break;
        }
        this.method_149_SetByte(num, this.method_226(int_3));
    }

    public float method_174(byte byte_3, byte byte_4)
    {
        switch (this.selectedTable_0)
        {
            case SelectedTable.ign1_lo:
                return this.method_188(this.method_178(byte_3, byte_4));

            case SelectedTable.ign1_hi:
                return this.method_188(this.method_178(byte_3, byte_4));

            case SelectedTable.fuel1_lo:
                return ((this.method_178(byte_3, byte_4) * this.method_182(byte_3)) / 4f);

            case SelectedTable.fuel1_hi:
                return ((this.method_178(byte_3, byte_4) * this.method_182(byte_3)) / 4f);

            case SelectedTable.ign2_lo:
                return this.method_188(this.method_178(byte_3, byte_4));

            case SelectedTable.ign2_hi:
                return this.method_188(this.method_178(byte_3, byte_4));

            case SelectedTable.fuel2_lo:
                return ((this.method_178(byte_3, byte_4) * this.method_182(byte_3)) / 4f);

            case SelectedTable.fuel2_hi:
                return ((this.method_178(byte_3, byte_4) * this.method_182(byte_3)) / 4f);

            case SelectedTable.ve_lo:
                return (float) Math.Round((double) (((((double) this.method_178(byte_3, byte_4)) / ((double) this.long_28)) * 100.0) - 100.0), 0);

            case SelectedTable.ve_hi:
                return (float) Math.Round((double) (((((double) this.method_178(byte_3, byte_4)) / ((double) this.long_28)) * 100.0) - 100.0), 0);
        }
        return 0f;
    }

    public float method_175(byte byte_3, byte byte_4, SelectedTable selectedTable_1)
    {
        switch (selectedTable_1)
        {
            case SelectedTable.ign1_lo:
                return this.method_188(this.method_179(byte_3, byte_4, selectedTable_1));

            case SelectedTable.ign1_hi:
                return this.method_188(this.method_179(byte_3, byte_4, selectedTable_1));

            case SelectedTable.fuel1_lo:
                return ((this.method_179(byte_3, byte_4, selectedTable_1) * this.method_183(byte_3, selectedTable_1)) / 4f);

            case SelectedTable.fuel1_hi:
                return ((this.method_179(byte_3, byte_4, selectedTable_1) * this.method_183(byte_3, selectedTable_1)) / 4f);

            case SelectedTable.ign2_lo:
                return this.method_188(this.method_179(byte_3, byte_4, selectedTable_1));

            case SelectedTable.ign2_hi:
                return this.method_188(this.method_179(byte_3, byte_4, selectedTable_1));

            case SelectedTable.fuel2_lo:
                return ((this.method_179(byte_3, byte_4, selectedTable_1) * this.method_183(byte_3, selectedTable_1)) / 4f);

            case SelectedTable.fuel2_hi:
                return ((this.method_179(byte_3, byte_4, selectedTable_1) * this.method_183(byte_3, selectedTable_1)) / 4f);

            case SelectedTable.ve_lo:
                return (float) Math.Round((double) (((((double) this.method_179(byte_3, byte_4, selectedTable_1)) / ((double) this.long_28)) * 100.0) - 100.0), 0);

            case SelectedTable.ve_hi:
                return (float) Math.Round((double) (((((double) this.method_179(byte_3, byte_4, selectedTable_1)) / ((double) this.long_28)) * 100.0) - 100.0), 0);
        }
        return 0f;
    }

    public void method_176(byte byte_3, byte byte_4, float float_0)
    {
        byte num;
        byte num2;
        float num3;
        float num4;
        float num5;
        switch (this.selectedTable_0)
        {
            case SelectedTable.ign1_lo:
                this.method_180(byte_3, byte_4, this.method_220(float_0));
                return;

            case SelectedTable.ign1_hi:
                this.method_180(byte_3, byte_4, this.method_220(float_0));
                return;

            case SelectedTable.fuel1_lo:
                num = this.method_182(byte_3);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = (float) Math.Round((double) ((float_0 * 4f) / ((float) num)), 0);
                while ((num3 > 255f) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = (float) Math.Round((double) ((float_0 * 4f) / ((float) num)), 0);
                }
                this.method_180(byte_3, byte_4, (byte) num3);
                this.method_178(byte_3, byte_4);
                if (num != num2)
                {
                    this.method_184(byte_3, num);
                    for (int i = 0; i < this.method_32_GetRPM_RowsNumber(); i++)
                    {
                        if (i != byte_4)
                        {
                            num3 = (int) (this.method_178(byte_3, (byte) i) * (((float) num2) / ((float) num)));
                            num4 = (this.method_178(byte_3, (byte) i) * num2) / 4;
                            for (num5 = (num3 * num) / 4f; num4 > num5; num5 = (num3 * num) / 4f)
                            {
                                num3++;
                            }
                            this.method_180(byte_3, (byte) i, (byte) num3);
                        }
                    }
                    if (this.delegate60_0 == null)
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.fuel1_hi:
                num = this.method_182(byte_3);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = (float) Math.Round((double) ((float_0 * 4f) / ((float) num)), 0);
                while ((num3 > 255f) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = (float_0 * 4f) / ((float) num);
                }
                num5 = (num3 * num) / 4f;
                this.method_180(byte_3, byte_4, (byte) num3);
                if (num != num2)
                {
                    this.method_184(byte_3, num);
                    for (int j = 0; j < this.method_32_GetRPM_RowsNumber(); j++)
                    {
                        if (j != byte_4)
                        {
                            num3 = (int) (this.method_178(byte_3, (byte) j) * (((float) num2) / ((float) num)));
                            num4 = (this.method_178(byte_3, (byte) j) * num2) / 4;
                            num5 = (num3 * num) / 4f;
                            while (num4 > num5)
                            {
                                num3++;
                                num5 = (num3 * num) / 4f;
                            }
                            this.method_180(byte_3, (byte) j, (byte) num3);
                        }
                    }
                    if (this.delegate60_0 == null)
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.ign2_lo:
                this.method_180(byte_3, byte_4, this.method_220(float_0));
                return;

            case SelectedTable.ign2_hi:
                this.method_180(byte_3, byte_4, this.method_220(float_0));
                return;

            case SelectedTable.fuel2_lo:
                num = this.method_182(byte_3);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = (float) Math.Round((double) ((float_0 * 4f) / ((float) num)), 0);
                while ((num3 > 255f) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = (float) Math.Round((double) ((float_0 * 4f) / ((float) num)), 0);
                }
                this.method_180(byte_3, byte_4, (byte) num3);
                if (num != num2)
                {
                    this.method_184(byte_3, num);
                    for (int k = 0; k < this.method_32_GetRPM_RowsNumber(); k++)
                    {
                        if (k != byte_4)
                        {
                            num3 = this.method_178(byte_3, (byte) k) * (((float) num2) / ((float) num));
                            num4 = (this.method_178(byte_3, (byte) k) * num2) / 4;
                            for (num5 = (num3 * num) / 4f; num4 > num5; num5 = (num3 * num) / 4f)
                            {
                                num3++;
                            }
                            this.method_180(byte_3, (byte) k, (byte) num3);
                        }
                    }
                    if (this.delegate60_0 == null)
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.fuel2_hi:
                num = this.method_182(byte_3);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = (float) Math.Round((double) ((float_0 * 4f) / ((float) num)), 0);
                while ((num3 > 255f) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = (float) Math.Round((double) ((float_0 * 4f) / ((float) num)), 0);
                }
                num5 = (num3 * num) / 4f;
                this.method_180(byte_3, byte_4, (byte) num3);
                if (num != num2)
                {
                    this.method_184(byte_3, num);
                    for (int m = 0; m < this.method_32_GetRPM_RowsNumber(); m++)
                    {
                        if (m != byte_4)
                        {
                            num3 = this.method_178(byte_3, (byte) m) * (((float) num2) / ((float) num));
                            num4 = (this.method_178(byte_3, (byte) m) * num2) / 4;
                            for (num5 = (num3 * num) / 4f; num4 > num5; num5 = (num3 * num) / 4f)
                            {
                                num3++;
                            }
                            this.method_180(byte_3, (byte) m, (byte) num3);
                        }
                    }
                    if (this.delegate60_0 == null)
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.ve_lo:
                float_0 = ((float_0 + 100f) * this.long_28) / 100f;
                if (float_0 > 255f)
                {
                    float_0 = 255f;
                }
                if (float_0 < 0f)
                {
                    float_0 = 0f;
                }
                this.method_180(byte_3, byte_4, (byte) float_0);
                return;

            case SelectedTable.ve_hi:
                float_0 = ((float_0 + 100f) * this.long_28) / 100f;
                if (float_0 > 255f)
                {
                    float_0 = 255f;
                }
                if (float_0 < 0f)
                {
                    float_0 = 0f;
                }
                this.method_180(byte_3, byte_4, (byte) float_0);
                return;
        }
    }

    public void method_177(byte byte_3, byte byte_4, float float_0, SelectedTable selectedTable_1)
    {
        byte num;
        byte num2;
        int num3;
        float num4;
        float num5;
        switch (selectedTable_1)
        {
            case SelectedTable.ign1_lo:
                this.method_181(byte_3, byte_4, this.method_220(float_0), selectedTable_1);
                return;

            case SelectedTable.ign1_hi:
                this.method_181(byte_3, byte_4, this.method_220(float_0), selectedTable_1);
                return;

            case SelectedTable.fuel1_lo:
                num = this.method_183(byte_3, selectedTable_1);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = ((int) (float_0 * 4f)) / num;
                while ((num3 > 0xff) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = ((int) (float_0 * 4f)) / num;
                }
                this.method_181(byte_3, byte_4, (byte) num3, selectedTable_1);
                if (num != num2)
                {
                    this.method_185(byte_3, num, selectedTable_1);
                    for (int i = 0; i < this.method_32_GetRPM_RowsNumber(); i++)
                    {
                        if (i != byte_4)
                        {
                            num3 = (int) (this.method_179(byte_3, (byte) i, selectedTable_1) * (((float) num2) / ((float) num)));
                            num4 = (this.method_179(byte_3, (byte) i, selectedTable_1) * num2) / 4;
                            for (num5 = (num3 * num) / 4; num4 > num5; num5 = (num3 * num) / 4)
                            {
                                num3++;
                            }
                            this.method_181(byte_3, (byte) i, (byte) num3, selectedTable_1);
                        }
                    }
                    if ((this.delegate60_0 == null) || (byte_3 >= (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1)))
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.fuel1_hi:
                num = this.method_183(byte_3, selectedTable_1);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = ((int) (float_0 * 4f)) / num;
                while ((num3 > 0xff) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = ((int) (float_0 * 4f)) / num;
                }
                num5 = (num3 * num) / 4;
                this.method_181(byte_3, byte_4, (byte) num3, selectedTable_1);
                if (num != num2)
                {
                    this.method_185(byte_3, num, selectedTable_1);
                    for (int j = 0; j < this.method_32_GetRPM_RowsNumber(); j++)
                    {
                        if (j != byte_4)
                        {
                            num3 = (int) (this.method_179(byte_3, (byte) j, selectedTable_1) * (((float) num2) / ((float) num)));
                            num4 = (this.method_179(byte_3, (byte) j, selectedTable_1) * num2) / 4;
                            num5 = (num3 * num) / 4;
                            while (num4 > num5)
                            {
                                num3++;
                                num5 = (num3 * num) / 4;
                            }
                            this.method_181(byte_3, (byte) j, (byte) num3, selectedTable_1);
                        }
                    }
                    if ((this.delegate60_0 == null) || (byte_3 >= (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1)))
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.ign2_lo:
                this.method_181(byte_3, byte_4, this.method_220(float_0), selectedTable_1);
                return;

            case SelectedTable.ign2_hi:
                this.method_181(byte_3, byte_4, this.method_220(float_0), selectedTable_1);
                return;

            case SelectedTable.fuel2_lo:
                num = this.method_183(byte_3, selectedTable_1);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = ((int) (float_0 * 4f)) / num;
                while ((num3 > 0xff) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = ((int) (float_0 * 4f)) / num;
                }
                this.method_181(byte_3, byte_4, (byte) num3, selectedTable_1);
                if (num != num2)
                {
                    this.method_185(byte_3, num, selectedTable_1);
                    for (int k = 0; k < this.method_32_GetRPM_RowsNumber(); k++)
                    {
                        if (k != byte_4)
                        {
                            num3 = (int) (this.method_179(byte_3, (byte) k, selectedTable_1) * (((float) num2) / ((float) num)));
                            num4 = (this.method_179(byte_3, (byte) k, selectedTable_1) * num2) / 4;
                            for (num5 = (num3 * num) / 4; num4 > num5; num5 = (num3 * num) / 4)
                            {
                                num3++;
                            }
                            this.method_181(byte_3, (byte) k, (byte) num3, selectedTable_1);
                        }
                    }
                    if ((this.delegate60_0 == null) || (byte_3 >= (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1)))
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.fuel2_hi:
                num = this.method_183(byte_3, selectedTable_1);
                if (num < 0)
                {
                    num = (byte) (num + 0xff);
                }
                num2 = num;
                num3 = ((int) (float_0 * 4f)) / num;
                while ((num3 > 0xff) && (num <= 0xff))
                {
                    num = (byte) (num + 1);
                    num3 = ((int) (float_0 * 4f)) / num;
                }
                num5 = (num3 * num) / 4;
                this.method_181(byte_3, byte_4, (byte) num3, selectedTable_1);
                if (num != num2)
                {
                    this.method_185(byte_3, num, selectedTable_1);
                    for (int m = 0; m < this.method_32_GetRPM_RowsNumber(); m++)
                    {
                        if (m != byte_4)
                        {
                            num3 = (int) (this.method_179(byte_3, (byte) m, selectedTable_1) * (((float) num2) / ((float) num)));
                            num4 = (this.method_179(byte_3, (byte) m, selectedTable_1) * num2) / 4;
                            for (num5 = (num3 * num) / 4; num4 > num5; num5 = (num3 * num) / 4)
                            {
                                num3++;
                            }
                            this.method_181(byte_3, (byte) m, (byte) num3, selectedTable_1);
                        }
                    }
                    if ((this.delegate60_0 == null) || (byte_3 >= (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1)))
                    {
                        return;
                    }
                    this.delegate60_0(byte_3);
                }
                return;

            case SelectedTable.ve_lo:
                float_0 = ((float_0 + 100f) * this.long_28) / 100f;
                if (float_0 > 255f)
                {
                    float_0 = 255f;
                }
                if (float_0 < 0f)
                {
                    float_0 = 0f;
                }
                this.method_181(byte_3, byte_4, (byte) float_0, selectedTable_1);
                return;

            case SelectedTable.ve_hi:
                float_0 = ((float_0 + 100f) * this.long_28) / 100f;
                if (float_0 > 255f)
                {
                    float_0 = 255f;
                }
                if (float_0 < 0f)
                {
                    float_0 = 0f;
                }
                this.method_181(byte_3, byte_4, (byte) float_0, selectedTable_1);
                return;
        }
    }

    public byte method_178(byte byte_3, byte byte_4)
    {
        switch (this.selectedTable_0)
        {
            case SelectedTable.ign1_lo:
                return this.GetByteAt((this.class13_u_0.long_12 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ign1_hi:
                return this.GetByteAt((this.class13_u_0.long_13 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel1_lo:
                return this.GetByteAt((this.class13_u_0.long_10 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel1_hi:
                return this.GetByteAt((this.class13_u_0.long_11 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ign2_lo:
                return this.GetByteAt((this.class13_u_0.long_22 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ign2_hi:
                return this.GetByteAt((this.class13_u_0.long_23 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel2_lo:
                return this.GetByteAt((this.class13_u_0.long_20 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel2_hi:
                return this.GetByteAt((this.class13_u_0.long_21 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ve_lo:
                return this.GetByteAt((this.class13_u_0.long_26 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ve_hi:
                return this.GetByteAt((this.class13_u_0.long_27 + (byte_4 * this.method_33())) + byte_3);
        }
        return 0;
    }

    public byte method_179(byte byte_3, byte byte_4, SelectedTable selectedTable_1)
    {
        switch (selectedTable_1)
        {
            case SelectedTable.ign1_lo:
                return this.GetByteAt((this.class13_u_0.long_12 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ign1_hi:
                return this.GetByteAt((this.class13_u_0.long_13 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel1_lo:
                return this.GetByteAt((this.class13_u_0.long_10 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel1_hi:
                return this.GetByteAt((this.class13_u_0.long_11 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ign2_lo:
                return this.GetByteAt((this.class13_u_0.long_22 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ign2_hi:
                return this.GetByteAt((this.class13_u_0.long_23 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel2_lo:
                return this.GetByteAt((this.class13_u_0.long_20 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.fuel2_hi:
                return this.GetByteAt((this.class13_u_0.long_21 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ve_lo:
                return this.GetByteAt((this.class13_u_0.long_26 + (byte_4 * this.method_33())) + byte_3);

            case SelectedTable.ve_hi:
                return this.GetByteAt((this.class13_u_0.long_27 + (byte_4 * this.method_33())) + byte_3);
        }
        return 0;
    }

    public void method_180(byte byte_3, byte byte_4, byte byte_5)
    {
        switch (this.selectedTable_0)
        {
            case SelectedTable.ign1_lo:
                this.method_149_SetByte((this.class13_u_0.long_12 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ign1_hi:
                this.method_149_SetByte((this.class13_u_0.long_13 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel1_lo:
                this.method_149_SetByte((this.class13_u_0.long_10 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel1_hi:
                this.method_149_SetByte((this.class13_u_0.long_11 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ign2_lo:
                this.method_149_SetByte((this.class13_u_0.long_22 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ign2_hi:
                this.method_149_SetByte((this.class13_u_0.long_23 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel2_lo:
                this.method_149_SetByte((this.class13_u_0.long_20 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel2_hi:
                this.method_149_SetByte((this.class13_u_0.long_21 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ve_lo:
                this.method_149_SetByte((this.class13_u_0.long_26 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ve_hi:
                this.method_149_SetByte((this.class13_u_0.long_27 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;
        }
    }

    public void method_181(byte byte_3, byte byte_4, byte byte_5, SelectedTable selectedTable_1)
    {
        switch (selectedTable_1)
        {
            case SelectedTable.ign1_lo:
                this.method_149_SetByte((this.class13_u_0.long_12 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ign1_hi:
                this.method_149_SetByte((this.class13_u_0.long_13 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel1_lo:
                this.method_149_SetByte((this.class13_u_0.long_10 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel1_hi:
                this.method_149_SetByte((this.class13_u_0.long_11 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ign2_lo:
                this.method_149_SetByte((this.class13_u_0.long_22 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ign2_hi:
                this.method_149_SetByte((this.class13_u_0.long_23 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel2_lo:
                this.method_149_SetByte((this.class13_u_0.long_20 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.fuel2_hi:
                this.method_149_SetByte((this.class13_u_0.long_21 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ve_lo:
                this.method_149_SetByte((this.class13_u_0.long_26 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;

            case SelectedTable.ve_hi:
                this.method_149_SetByte((this.class13_u_0.long_27 + (byte_4 * this.method_33())) + byte_3, byte_5);
                return;
        }
    }

    public byte method_182(byte byte_3)
    {
        switch (this.selectedTable_0)
        {
            case SelectedTable.fuel1_lo:
                return this.GetByteAt((this.class13_u_0.long_10 + this.method_34()) + byte_3);

            case SelectedTable.fuel1_hi:
                return this.GetByteAt((this.class13_u_0.long_11 + this.method_34()) + byte_3);

            case SelectedTable.fuel2_lo:
                return this.GetByteAt((this.class13_u_0.long_20 + this.method_34()) + byte_3);

            case SelectedTable.fuel2_hi:
                return this.GetByteAt((this.class13_u_0.long_21 + this.method_34()) + byte_3);
        }
        return 0;
    }

    public byte method_183(byte byte_3, SelectedTable selectedTable_1)
    {
        switch (selectedTable_1)
        {
            case SelectedTable.fuel1_lo:
                return this.GetByteAt((this.class13_u_0.long_10 + this.method_34()) + byte_3);

            case SelectedTable.fuel1_hi:
                return this.GetByteAt((this.class13_u_0.long_11 + this.method_34()) + byte_3);

            case SelectedTable.fuel2_lo:
                return this.GetByteAt((this.class13_u_0.long_20 + this.method_34()) + byte_3);

            case SelectedTable.fuel2_hi:
                return this.GetByteAt((this.class13_u_0.long_21 + this.method_34()) + byte_3);
        }
        return 0;
    }

    public void method_184(byte byte_3, byte byte_4)
    {
        switch (this.selectedTable_0)
        {
            case SelectedTable.fuel1_lo:
                this.method_149_SetByte((this.class13_u_0.long_10 + this.method_34()) + byte_3, byte_4);
                return;

            case SelectedTable.fuel1_hi:
                this.method_149_SetByte((this.class13_u_0.long_11 + this.method_34()) + byte_3, byte_4);
                return;

            case SelectedTable.ign2_lo:
            case SelectedTable.ign2_hi:
                break;

            case SelectedTable.fuel2_lo:
                this.method_149_SetByte((this.class13_u_0.long_20 + this.method_34()) + byte_3, byte_4);
                return;

            case SelectedTable.fuel2_hi:
                this.method_149_SetByte((this.class13_u_0.long_21 + this.method_34()) + byte_3, byte_4);
                break;

            default:
                return;
        }
    }

    public void method_185(byte byte_3, byte byte_4, SelectedTable selectedTable_1)
    {
        switch (selectedTable_1)
        {
            case SelectedTable.fuel1_lo:
                this.method_149_SetByte((this.class13_u_0.long_10 + this.method_34()) + byte_3, byte_4);
                return;

            case SelectedTable.fuel1_hi:
                this.method_149_SetByte((this.class13_u_0.long_11 + this.method_34()) + byte_3, byte_4);
                return;

            case SelectedTable.ign2_lo:
            case SelectedTable.ign2_hi:
                break;

            case SelectedTable.fuel2_lo:
                this.method_149_SetByte((this.class13_u_0.long_20 + this.method_34()) + byte_3, byte_4);
                return;

            case SelectedTable.fuel2_hi:
                this.method_149_SetByte((this.class13_u_0.long_21 + this.method_34()) + byte_3, byte_4);
                break;

            default:
                return;
        }
    }

    public int method_186(int int_3)
    {
        int num = int_3;
        if (num == 0xff)
        {
            num = 0x100;
        }
        float num2 = 7.8125f;
        if (num < 0)
        {
            num += 0x100;
        }
        int num3 = num / 0x40;
        int num4 = num % 0x40;
        num2 *= num4;
        num2 += 500f;
        num2 = ((float) Math.Round((double) ((Math.Pow(2.0, (double) num3) * num2) / 25.0), 0)) * 25f;
        return (int) num2;
    }

    public int method_187(int int_3)
    {
        int num = int_3;
        double num2 = (1875000f * num) / ((float) this.long_3);
        num2 = Math.Round((double) (num2 / 50.0), 0) * 50.0;
        return (int) num2;
    }

    public float method_188(byte byte_3)
    {
        byte num = this.GetByteAt(this.class13_u_0.long_102);
        float num2 = (float) ((byte_3 * 0.25) - 6.0);
        if (((num != 0) && (num != 0xff)) && (this.class13_u_0.long_102 != 0L))
        {
            return (float) Math.Round((num2 - (16f - ((num * 0.25f) - 6f))), 2);
        }
        return (float)Math.Round(num2, 2);
    }

    public float method_189(byte byte_3)
    {
        if (byte_3 == 0x80)
        {
            return 0f;
        }
        if (byte_3 < 0x80)
        {
            return (float)Math.Round((0x80 - byte_3) * -0.25f, 2);
        }
        if (byte_3 <= 0x80)
        {
            this.class17_0.frmMain_0.LogThis("byteToIgnCorrection Error");
            return 0f;
            //throw new Exception("byteToIgnCorrection Error");
        }
        return (float)Math.Round((byte_3 - 0x80) * 0.25f, 2);
    }

    public float method_189_Voltage(byte byte_3)
    {
        return (float)Math.Round((double) (((double) byte_3 * 5.0) / 255.0), 2);
    }
    public byte method_189_VoltageByte(double Percent)
    {
        return (byte)((Percent * 255) / 5);
    }

    public int method_189_Ethanol(byte byte_3)
    {
        return (int) Math.Round((double)(((double)byte_3 * 100) / 255.0), 0);
    }

    public byte method_189_EthanolByte(double Percent)
    {
        return (byte) ((Percent * 255) / 100);
    }

    public double method_190(byte byte_3)
    {
        double num = 0.0;
        num = 0.5;
        if (byte_3 == 0x80)
        {
            return 0.0;
        }
        if (byte_3 < 0x80)
        {
            return Math.Round((double) (((128.0 - byte_3) * -1.0) * num), 1);
        }
        if (byte_3 <= 0x80)
        {
            this.class17_0.frmMain_0.LogThis("byteToIgnCorrection Error");
            return 0.0;
            //throw new Exception("byteToIgnCorrection Error");
        }
        return Math.Round((double) ((byte_3 - 128.0) * num), 1);
    }

    public double method_191(byte byte_3)
    {
        if (this.class10_settings_0.temperatureUnits_0 == TemperatureUnits.C)
        {
            return Math.Round(this.double_0[byte_3], 0);
        }
        return Math.Round(this.method_242(this.double_0[byte_3]), 0);
    }

    public double method_191_GetTempInC(byte byte_3)
    {
        return Math.Round(this.double_0[byte_3], 0);
    }

    private float method_192(float float_0, float float_1, float float_2, float float_3, float float_4)
    {
        return (float_3 + (((float_0 - float_1) * (float_4 - float_3)) / (float_2 - float_1)));
    }

    public float method_193(int int_3)
    {
        int num = this.method_206(int_3);
        if (num <= this.class10_settings_0.int_6)
        {
            switch (this.class10_settings_0.mapSensorUnits_0)
            {
                case MapSensorUnits.mBar:
                    return (float) num;

                case MapSensorUnits.Bar:
                    return (float)(num / 0x3e8);

                case MapSensorUnits.inHgG:
                    return (float) Math.Round((double) (-this.method_246(this.class10_settings_0.int_6) + this.method_246(num)), 1);

                case MapSensorUnits.inHg:
                    return this.method_246(num);

                case MapSensorUnits.psi:
                    return this.method_245(num);

                case MapSensorUnits.kPa:
                    return this.method_248(num);
            }
        }
        else
        {
            switch (this.class10_settings_0.mapSensorUnits_1)
            {
                case MapSensorUnits.mBar:
                    return (float) num;

                case MapSensorUnits.Bar:
                    return (float) (num / 0x3e8);

                case MapSensorUnits.inHg:
                    return this.method_246(num);

                case MapSensorUnits.psi:
                    return this.method_245(num);

                case MapSensorUnits.kPa:
                    return this.method_248(num);
            }
        }
        this.class17_0.frmMain_0.LogThis("byteToMapDisplay error");
        return 0;
        //throw new Exception("byteToMapDisplay error");
    }

    public string method_195(int int_3)
    {
        int num = this.method_206(int_3);
        if (this.method_37() || this.method_40())
        {
            if (this.method_41())
            {
                int num2 = this.method_206(this.GetByteAt(this.class13_u_0.long_371));
                if (num >= num2)
                {
                    float num3 = int_3;
                    float num4 = this.GetByteAt(this.class13_u_0.long_373 + 3L);
                    float num5 = this.GetByteAt(this.class13_u_0.long_373 + 1L);
                    float num6 = this.GetByteAt(this.class13_u_0.long_373 + 2L);
                    float num7 = this.GetByteAt(this.class13_u_0.long_373);
                    byte num8 = (byte) this.method_192(num3, num4, num5, num6, num7);
                    return (this.method_198(num8).ToString() + "%");
                }
            }
            else if (this.method_42())
            {
                return (this.method_198((byte) int_3).ToString() + "%");
            }
        }
        if (num <= this.class10_settings_0.int_6)
        {
            switch (this.class10_settings_0.mapSensorUnits_0)
            {
                case MapSensorUnits.mBar:
                    return num.ToString();

                case MapSensorUnits.Bar:
                    {
                        int num15 = num / 0x3e8;
                        return num15.ToString();
                    }

                case MapSensorUnits.inHgG:
                    return Math.Round((double) (-this.method_246(this.class10_settings_0.int_6) + this.method_246(num)), 1).ToString();

                case MapSensorUnits.inHg:
                    return this.method_246(num).ToString();

                case MapSensorUnits.psi:
                    return this.method_245(num).ToString();

                case MapSensorUnits.kPa:
                    return this.method_248(num).ToString();
            }
        }
        else
        {
            switch (this.class10_settings_0.mapSensorUnits_1)
            {
                case MapSensorUnits.mBar:
                    return num.ToString();

                case MapSensorUnits.Bar:
                {
                    int num15 = num / 0x3e8;
                    return num15.ToString();
                }
                case MapSensorUnits.inHg:
                    return this.method_246(num).ToString();

                case MapSensorUnits.psi:
                    return this.method_245(num).ToString();

                case MapSensorUnits.kPa:
                    return this.method_248(num).ToString();
            }
        }
        this.class17_0.frmMain_0.LogThis("byteToMapDisplay error");
        return "0";
        //throw new Exception("byteToMapDisplay error");
    }

    public double method_196(byte byte_3)
    {
        return Math.Round((double) (byte_3 * 0.01960784f), 2);
    }

    public int method_197(byte byte_3)
    {
        if (this.class10_settings_0.vssUnits_0 == VssUnits.kmh)
        {
            return byte_3;
        }
        return (int) Math.Round((double) (((double) byte_3) / 1.6), 0);
    }

    public int method_198(byte byte_3)
    {
        return (int) Math.Round((double) ((byte_3 - 25.0) / 2.04), 0);
    }

    internal void method_2(ref Class25 class25_1)
    {
        this.class25_0 = class25_1;
    }

    public int method_20()
    {
        if (this.string_7 == null)
        {
            return 0;
        }
        return int.Parse(this.string_7.Substring(1).Replace(".", ""));
    }

    public double method_200(byte byte_3)
    {
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
        {
            return Math.Round((double) (this.method_264(this.class10_settings_0.double_0, this.method_196(byte_3)) + this.class10_settings_0.double_2), 2);
        }
        return Math.Round(this.method_241(this.method_264(this.class10_settings_0.double_0, this.method_196(byte_3)) + this.class10_settings_0.double_2), 2);
    }

    public float method_201(AnalogInputs analogInputs_0, byte byte_3)
    {
        if (analogInputs_0 == AnalogInputs.analog1)
        {
            return (float) Math.Round(this.method_264(this.class10_settings_0.double_4, this.method_196(byte_3)), this.class10_settings_0.int_22);
        }
        if (analogInputs_0 == AnalogInputs.analog2)
        {
            return (float) Math.Round(this.method_264(this.class10_settings_0.double_5, this.method_196(byte_3)), this.class10_settings_0.int_23);
        }
        if (analogInputs_0 == AnalogInputs.analog3)
        {
            return (float) Math.Round(this.method_264(this.class10_settings_0.double_6, this.method_196(byte_3)), this.class10_settings_0.int_24);
        }
        return 0f;
    }

    public double method_202(long long_0_X)
    {
        return (((double) long_0_X) / 32768.0);
    }

    public double method_203(long long_0_X, Enum6 enum6_0)
    {
        double num = 0.0;
        num = ((double) long_0_X) / ((double) enum6_0);
        if (this.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            return Math.Round(num, 2);
        }
        return Math.Round((double) ((num * 100.0) - 100.0), 0);
    }

    public double method_204(long long_0_X, Enum6 enum6_0, bool bool_3)
    {
        double num = 0.0;
        num = ((double) long_0_X) / ((double) enum6_0);
        return Math.Round((double) ((num * 100.0) - 100.0), 0);
    }

    public double method_205(byte byte_3, Enum6 enum6_0)
    {
        double num = 0.0;
        num = ((double) byte_3) / ((double) enum6_0);
        if (this.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            return Math.Round(num, 2);
        }
        return Math.Round((double) ((num * 100.0) - 100.0), 0);
    }

    public int method_206(int int_3)
    {
        byte num = this.GetByteAt(this.class13_u_0.long_2);
        if (num == 0)
        {
            return (int) Math.Round((double) ((((int_3 / 2) + this.GetByteAt(this.class13_u_0.long_53)) * 7.221) - 59.0), 0);
        }
        if (num == 1)
        {
            return (int) Math.Round((double) ((int_3 * 7.221) - 59.0), 0);
        }
        return (int) Math.Round((double) ((((int_3 * (this.method_152(this.class13_u_0.long_1) - this.method_152(this.class13_u_0.long_0))) / 255.0) + this.method_152(this.class13_u_0.long_0)) - 32768.0), 0);
    }

    public double method_207(byte byte_3)
    {
        double num = 0.0;
        num = ((double) byte_3) / 2.0;
        if (num > 100.0)
        {
            num = 100.0;
        }
        return Math.Round(num, 1);
    }

    public double method_208(byte byte_3)
    {
        return Math.Round((double) ((26.0 * byte_3) / 270.0), 2);
    }

    public byte method_209(float float_0)
    {
        return (byte) ((270f * float_0) / 26f);
    }

    public byte method_210(float float_0)
    {
        float num2 = this.method_245(this.class10_settings_0.int_6) + float_0;
        return (byte)(this.method_226(this.method_250(num2)) - this.method_226(this.class10_settings_0.int_6));
    }

    public byte method_211(double double_1)
    {
        if (double_1 > 100.0)
        {
            double_1 = 100.0;
        }
        return (byte) (double_1 * 2.0);
    }

    public byte method_213(double double_1)
    {
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
        {
            return this.method_227((float) this.method_264(this.class10_settings_0.double_1, this.method_240(double_1)));
        }
        return this.method_227((float) this.method_264(this.class10_settings_0.double_1, double_1));
    }

    public byte method_214(double double_1)
    {
        bool flag = false;
        string str = string.Empty;
        switch (this.class10_settings_0.int_8)
        {
            case 0:
                str = "Custom";
                break;

            case 1:
                str = "Stock";
                flag = true;
                break;

            case 2:
                str = "Aem";
                break;

            case 3:
                str = "Plx";
                break;

            case 4:
                str = "FJO";
                break;

            case 5:
                str = "Innovate lc-1/lm-1";
                break;

            case 6:
                str = "Techedge";
                break;

            case 7:
                str = "Zeitrox";
                break;

            case 8:
                str = "Motec";
                break;

            case 9:
                str = "JAW";
                break;
        }
        if (flag)
        {
            MessageBox.Show(Form.ActiveForm, "You can't lookup with narrowband." + Environment.NewLine + "Select your wideband in Settings", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            throw new Exception();
        }
        if (this.class10_settings_0.bool_25)
        {
            MessageBox.Show(Form.ActiveForm, "You can't lookup with serial wideband.", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            throw new Exception();
        }
        if (MessageBox.Show(Form.ActiveForm, "Do you want to use the " + str + " wideband?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            throw new Exception();
        }
        return this.method_213(double_1);
    }

    public byte method_215(byte byte_3, long long_0_X)
    {
        if (byte_3 == 0)
        {
            return 0;
        }
        long num = ((byte_3 * 0x100) * long_0_X) / 0xffffL;
        byte num3 = 0;
        for (int i = 0; i < 4; i++)
        {
            int num2 = i * 2;
            if (num < this.method_152(this.class13_u_0.long_63 + num2))
            {
                return (byte) (i + 1);
            }
            num3 = 5;
        }
        return num3;
    }

    public byte method_216(int int_3)
    {
        for (byte i = 0; i < 0x80; i = (byte) (i + 1))
        {
            if (this.method_186(i) >= int_3)
            {
                return i;
            }
            if (this.method_186((byte) (0xff - i)) <= int_3)
            {
                return (byte) (0xff - i);
            }
        }
        return 0;
    }

    public byte method_217(int int_3)
    {
        long num = (long) ((((float) (int_3 + 0x19)) / 1875000f) * this.long_3);
        if (num >= 0xffL)
        {
            num = 0xffL;
        }
        return (byte) num;
    }

    public int method_218(long long_0_X)
    {
        if (long_0_X == 0L)
        {
            return 0;
        }
        return (0x1c9c38 / ((int) long_0_X));
    }

    public double AccelTime(int Speed)   //###################################
    {
        if (this.watch == null) this.watch = new Stopwatch();

        if (this.class10_settings_0.vssUnits_0 == VssUnits.mph) Speed = (int) ((float) Speed * 1.6);
        if (Speed <= this.class10_settings_0.AccelTimerSpeedStart)
        {
            if (this.watch.IsRunning) watch.Stop();
            LastAccelTime = 99.9;
            CalcTime = false;
        }
        else if (Speed > this.class10_settings_0.AccelTimerSpeedStart && Speed < this.class10_settings_0.AccelTimerSpeedEnd && !CalcTime)
        {
            if (!this.watch.IsRunning) this.watch = Stopwatch.StartNew();
            LastAccelTime = ((double)watch.ElapsedMilliseconds / 1000.0);
            //LastAccelTime = Math.Round((double)(watch.ElapsedMilliseconds / 1000), 2);

            //Generally calc only for 20sec
            if (LastAccelTime > 99.9)
            {
                if (this.watch.IsRunning) watch.Stop();
                LastAccelTime = 99.9;
                CalcTime = true;
            }
        }
        else if (Speed >= this.class10_settings_0.AccelTimerSpeedEnd && !CalcTime)
        {
            watch.Stop();
            LastAccelTime = ((double)watch.ElapsedMilliseconds / 1000.0);
            //LastAccelTime = Math.Round((double)(watch.ElapsedMilliseconds / 1000), 2);
            CalcTime = true;
        }

        return LastAccelTime;
    }

    public double GetInstantConsumption(int Speed, int RPM, int int_3)   //#######################################
    {
        double Dreturn = 0;
        if (Speed != 0)
        {
            double InjSize = (((double)this.method_50_GetOLDInjectorSize()) / this.method_49());
            //double hundredkm = ((60 / Speed) * 100) / 60;
            double hundredkm = 6000 / Speed;
            double fuelc = (hundredkm * ((InjSize / 100) * GetDuty(RPM, int_3))) / 1000;
            Dreturn = Math.Round(fuelc * 4, 2);
        }
        return Dreturn;
    }
    double GetDuty(int RPM, int int_3)
    {
        return ((RPM * this.method_224(int_3)) / 1200f);
    }

    public long method_219(int int_3)
    {
        if (int_3 > 0x2ee0)
        {
            int_3 = 0x2ee0;
        }
        else if (int_3 <= 0)
        {
            int_3 = 300;
        }
        return (long) (0x1c9c38 / int_3);
    }

    public byte method_220(float float_0)
    {
        byte num = this.GetByteAt(this.class13_u_0.long_102);
        if (((num != 0) && (num != 0xff)) && (this.class13_u_0.long_102 != 0L))
        {
            float_0 += 16f - ((num * 0.25f) - 6f);
            if (float_0 < -6f)
            {
                return 0;
            }
            return (byte) ((float_0 + 6f) * 4f);
        }
        if (float_0 < -6f)
        {
            return 0;
        }
        return (byte) ((float_0 + 6f) * 4f);
    }

    public byte method_221(float float_0)
    {
        if (float_0 != 0f)
        {
            if (float_0 < 0f)
            {
                return (byte) (128f - (float_0 * -4f));
            }
            if (float_0 > 0f)
            {
                return (byte) (128f + (float_0 * 4f));
            }
        }
        return 0x80;
    }

    public byte method_222(float float_0)
    {
        float num = 0f;
        num = 2f;
        if (float_0 != 0f)
        {
            if (float_0 < 0f)
            {
                return (byte) (128f - ((float_0 * -1f) * num));
            }
            if (float_0 > 0f)
            {
                return (byte) (128f + (float_0 * num));
            }
        }
        return 0x80;
    }

    public double method_223(int int_3)
    {
        return Math.Round((double) (((double) int_3) / 4.0), 2);
    }

    public float method_224(int int_3)  //inj duration
    {
        return (float)Math.Round(((int_3 * 3.2f) / 1000f), 2);
    }

    public float method_225(int int_3, int int_4, byte byte_3)  //inj duty
    {
        if (int_4 == 0)
        {
            int_4 = this.method_159(byte_3);
        }
        return (float) Math.Round(((int_4 * this.method_224(int_3)) / 1200f), 0);
    }

    public byte method_226(int int_3)
    {
        double num = 0.0;
        if (int_3 < (this.method_152(this.class13_u_0.long_0) - 0x8000L))
        {
            return 0;
        }
        num = Math.Round((double) ((255.0 / (this.method_152(this.class13_u_0.long_1) - this.method_152(this.class13_u_0.long_0))) * (int_3 - (this.method_152(this.class13_u_0.long_0) - 32768.0))), 0);
        if (num > 255.0)
        {
            return 0xff;
        }
        return (byte) num;
    }

    public byte method_227(float float_0)
    {
        return (byte) Math.Round((double) ((float_0 / 5f) * 255f), 0);
    }

    public byte method_228(int int_3)
    {
        return (byte) ((int_3 * 2.04) + 25.0);
    }

    public long method_229(double double_1)
    {
        return (long) (32768.0 * double_1);
    }

    public string method_23()
    {
        return this.string_5;
    }

    public byte method_230(double double_1)
    {
        if (this.class10_settings_0.temperatureUnits_0 == TemperatureUnits.F)
        {
            double_1 = this.method_243(double_1);
        }
        for (byte i = 0; i < 0x80; i = (byte) (i + 1))
        {
            if (Math.Round(double_1, 0) >= Math.Round(this.double_0[i], 0))
            {
                return i;
            }
            if (Math.Round(double_1, 0) <= Math.Round(this.double_0[0xff - i], 0))
            {
                return (byte) (0xff - i);
            }
        }
        this.class17_0.frmMain_0.LogThis("temperature value not found");
        return 0x00;
        //throw new Exception("temperature value not found");
    }

    public long method_231(double double_1, Enum6 enum6_0)
    {
        if (this.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
        {
            return (long) (double_1 * ((double) enum6_0));
        }
        return (long) (((double_1 + 100.0) / 100.0) * ((double) enum6_0));
    }

    public long method_232(double double_1, Enum6 enum6_0, bool bool_3)
    {
        return (long) (((double_1 + 100.0) / 100.0) * ((double) enum6_0));
    }

    public byte method_233(int int_3)
    {
        if (this.class10_settings_0.vssUnits_0 == VssUnits.mph)
        {
            int_3 = (int) (int_3 * 1.6);
        }
        return (byte) int_3;
    }

    public Color method_234(double double_1, double double_2, double double_3)
    {
        int num;
        if ((double_2 == 0.0) && (double_3 == 0.0))
        {
            return Color.White;
        }
        if (((int) double_1) < double_2)
        {
            return Color.White;
        }
        if (((int) double_1) >= double_3)
        {
            double_1 = double_3;
            num = 0x7f;
            return Color.FromArgb(0xff, 0x7f - num, 0x7f - num);
        }
        double num2 = (double_3 - double_2) / 127.0;
        num = (int) Math.Floor((double) (double_1 - (double_2 / num2)));
        if ((num > 0x7f) || (num < 0))
        {
            num = 0;
        }
        return Color.FromArgb(0xff, 0x7f - num, 0x7f - num);
    }

    public Color method_235(double double_1, double double_2, double double_3)
    {
        if ((double_2 == 0.0) && (double_3 == 0.0))
        {
            return this.class10_settings_0.color_4;
        }
        if (((int) double_1) < double_2)
        {
            return this.class10_settings_0.color_4;
        }
        return this.class10_settings_0.color_Off;
    }

    public Color Mix(Color from, Color to, float percent)
    {
        float amountFrom = 1.0f - percent;
        int RCol = (int)(from.R * amountFrom + to.R * percent);
        int GCol = (int)(from.G * amountFrom + to.G * percent);
        int BCol = (int)(from.B * amountFrom + to.B * percent);
        if (RCol < 0) RCol = 0;
        if (GCol < 0) GCol = 0;
        if (BCol < 0) BCol = 0;
        if (RCol > 255) RCol = 255;
        if (GCol > 255) GCol = 255;
        if (BCol > 255) BCol = 255;

        return Color.FromArgb(255, RCol, GCol, BCol);
    }

    public Color method_236(double double_1)
    {
        //Coloring Fuel Value
        if (this.method_37())
        {
            double_1 *= this.method_49();
            
            int Percent = (int) ((double_1 * 100) / 1200.0);
            
            if (Percent < this.class10_settings_0.PercentColor1)
            {
                int InternalPercent = (Percent * 100) / this.class10_settings_0.PercentColor1;
                return Mix(this.class10_settings_0.color_20, this.class10_settings_0.color_21, ((float) InternalPercent / 100));
            }
            if (Percent < this.class10_settings_0.PercentColor2)
            {
                int InternalPercent = ((Percent - this.class10_settings_0.PercentColor1) * 100) / (this.class10_settings_0.PercentColor2 - this.class10_settings_0.PercentColor1);
                return Mix(this.class10_settings_0.color_21, this.class10_settings_0.color_22, ((float)InternalPercent / 100));
            }
            if (Percent < 100)
            {
                int InternalPercent = ((Percent - this.class10_settings_0.PercentColor2) * 100) / (100 - this.class10_settings_0.PercentColor2);
                return Mix(this.class10_settings_0.color_22, this.class10_settings_0.color_23, ((float)InternalPercent / 100));
            }
            return this.class10_settings_0.color_23;
        }

        //Coloring Ignition Value
        if (this.method_40())
        {
            int Percent = (int)(((double_1 + 6) * 100) / 66);

            if (Percent <= 9)
            {
                int InternalPercent = (Percent * 100) / 9;
                return Mix(this.class10_settings_0.color_30, this.class10_settings_0.color_31, ((float)InternalPercent / 100));
            }
            if (Percent < this.class10_settings_0.PercentColorIgn)
            {
                int InternalPercent = ((Percent - 9) * 100) / (this.class10_settings_0.PercentColorIgn - 9);
                return Mix(this.class10_settings_0.color_31, this.class10_settings_0.color_32, ((float)InternalPercent / 100));
            }
            if (Percent < 100)
            {
                int InternalPercent = ((Percent - this.class10_settings_0.PercentColorIgn) * 100) / (100 - this.class10_settings_0.PercentColorIgn);
                return Mix(this.class10_settings_0.color_32, this.class10_settings_0.color_33, ((float)InternalPercent / 100));
            }
            return this.class10_settings_0.color_33;
        }

        //Coloring VE Tables
        if (this.method_38())
        {
            int Percent = (int)((double_1 * 100) / 300.0);
            Percent *= 9;

            if (Percent < 0)
            {
                int InternalPercent = -Percent;
                return Mix(this.class10_settings_0.color_40, this.class10_settings_0.color_41, ((float)InternalPercent / 100));
            }
            if (Percent < 100)
            {
                int InternalPercent = Percent;
                return Mix(this.class10_settings_0.color_41, this.class10_settings_0.color_40, ((float)InternalPercent / 100));
            }
            return this.class10_settings_0.color_40;
        }
        return Color.White;
    }

    public Color method_237_Analog(TableOverlay TableOverlay_0, double double_1)
    {
        double double_Min = 0;
        double double_Max = 0;
        if (TableOverlay_0 == TableOverlay.analog1Reading)
        {
            double_Min = this.class10_settings_0.double_4[1];
            double_Max = this.class10_settings_0.double_4[this.class10_settings_0.double_4.Length - 1];
        }
        else if (TableOverlay_0 == TableOverlay.analog2Reading)
        {
            double_Min = this.class10_settings_0.double_5[1];
            double_Max = this.class10_settings_0.double_5[this.class10_settings_0.double_5.Length - 1];
        }
        else if (TableOverlay_0 == TableOverlay.analog3Reading)
        {
            double_Min = this.class10_settings_0.double_6[1];
            double_Max = this.class10_settings_0.double_6[this.class10_settings_0.double_6.Length - 1];
        }

        int Percent = (int) (((double_1 - double_Min) * 100) / (double_Max - double_Min));

        Color ReturnColor = Color.White;
        if (double_1 != 0) ReturnColor = Mix(this.class10_settings_0.color_21, this.class10_settings_0.color_22, ((float) Percent / 100));
        return ReturnColor;
    }

    public Color method_237(double double_1)
    {
        int num;
        int num2;
        int num3;
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
        {
            double_1 = this.method_241(double_1);
        }
        if (this.method_8() == TableOverlay.afDiff)
        {
            if (double_1 < 0.0)
            {
                if (double_1 <= -15.0)
                {
                    double_1 = -15.0;
                }
                num = (int) Math.Floor((double) (double_1 / -0.0588));
                num3 = (int) Math.Floor((double) (double_1 / -0.166));
                return Color.FromArgb(num, 0xff - num3, 0);
            }
            if (double_1 >= 0.0)
            {
                if (double_1 >= 15.0)
                {
                    double_1 = 15.0;
                }
                num3 = (int) Math.Floor((double) (double_1 / 0.4545));
                num2 = (int) Math.Floor((double) (double_1 / 0.0717));
                return Color.FromArgb(0, 0xff - num3, num2);
            }
        }
        else if ((this.method_8() == TableOverlay.afReading) || (this.method_8() == TableOverlay.afTarget))
        {
            if (double_1 < 14.0)
            {
                if (double_1 < 10.0)
                {
                    double_1 = 10.0;
                }
                num = (int) Math.Floor((double) ((14.0 - double_1) / 0.0166));
                num3 = (int) Math.Floor((double) ((14.0 - double_1) / 0.16));
                num2 = (int) Math.Floor((double) ((14.0 - double_1) / 0.0314));
                return Color.FromArgb(240 - num, 230 + num3, num2);
            }
            if ((double_1 >= 14.0) && (double_1 < 15.0))
            {
                return Color.FromArgb(0xff, 0xd7, 0);
            }
            if (double_1 >= 15.0)
            {
                if (double_1 > 17.5)
                {
                    double_1 = 17.5;
                }
                num3 = (int) Math.Floor((double) ((double_1 - 15.0) / 0.01162));
                return Color.FromArgb(0xff, 0xd7 - num3, 0);
            }
        }
        return Color.White;
    }

    public Color method_238(double double_1, TableOverlay tableOverlay_1)
    {
        int num;
        int num2;
        int num3;
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
        {
            double_1 = this.method_241(double_1);
        }
        if (this.method_8() == TableOverlay.afDiff)
        {
            if (double_1 < 0.0)
            {
                if (double_1 <= -15.0)
                {
                    double_1 = -15.0;
                }
                num = (int) Math.Floor((double) (double_1 / -0.0588));
                num3 = (int) Math.Floor((double) (double_1 / -0.166));
                return Color.FromArgb(num, 0xff - num3, 0);
            }
            if (double_1 >= 0.0)
            {
                if (double_1 >= 15.0)
                {
                    double_1 = 15.0;
                }
                num3 = (int) Math.Floor((double) (double_1 / 0.4545));
                num2 = (int) Math.Floor((double) (double_1 / 0.0717));
                return Color.FromArgb(0, 0xff - num3, num2);
            }
        }
        else if ((this.method_8() == TableOverlay.afReading) || (this.method_8() == TableOverlay.afTarget))
        {
            if (double_1 < 14.0)
            {
                if (double_1 < 10.0)
                {
                    double_1 = 10.0;
                }
                num = (int) Math.Floor((double) ((14.0 - double_1) / 0.0166));
                num3 = (int) Math.Floor((double) ((14.0 - double_1) / 0.16));
                num2 = (int) Math.Floor((double) ((14.0 - double_1) / 0.0314));
                return Color.FromArgb(240 - num, 230 + num3, num2);
            }
            if ((double_1 >= 14.0) && (double_1 < 15.0))
            {
                return Color.FromArgb(0xff, 0xd7, 0);
            }
            if (double_1 >= 15.0)
            {
                if (double_1 > 17.5)
                {
                    double_1 = 17.5;
                }
                num3 = (int) Math.Floor((double) ((double_1 - 15.0) / 0.01162));
                return Color.FromArgb(0xff, 0xd7 - num3, 0);
            }
        }
        return Color.White;
    }

    public Color method_239(double double_1)
    {
        int num3;
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
        {
            double_1 = this.method_241(double_1);
        }
        if (double_1 < 14.0)
        {
            if (double_1 < 10.0)
            {
                double_1 = 10.0;
            }
            int num = (int) Math.Floor((double) ((14.0 - double_1) / 0.0166));
            num3 = (int) Math.Floor((double) ((14.0 - double_1) / 0.16));
            int blue = (int) Math.Floor((double) ((14.0 - double_1) / 0.0314));
            return Color.FromArgb(240 - num, 230 + num3, blue);
        }
        if ((double_1 >= 14.0) && (double_1 < 15.0))
        {
            return Color.FromArgb(0xff, 0xd7, 0);
        }
        if (double_1 < 15.0)
        {
            return Color.Black;
        }
        if (double_1 > 17.5)
        {
            double_1 = 17.5;
        }
        num3 = (int) Math.Floor((double) ((double_1 - 15.0) / 0.01162));
        return Color.FromArgb(0xff, 0xd7 - num3, 0);
    }

    public void method_24(string string_8)
    {
        this.string_5 = string_8;
    }

    public double method_240(double double_1)
    {
        return (double_1 / this.class10_settings_0.double_3);
    }

    public double method_241(double double_1)
    {
        return Math.Round((double) (double_1 * this.class10_settings_0.double_3), 2);
    }

    public double method_242(double double_1)
    {
        return ((double_1 * 1.8) + 32.0);
    }

    public double method_243(double double_1)
    {
        return ((double_1 - 32.0) / 1.8);
    }

    public float method_244(byte byte_3)
    {
        byte num = this.method_226(this.class10_settings_0.int_6);
        float num2 = this.method_245(this.class10_settings_0.int_6);
        byte num3 = (byte) (num + byte_3);
        int num4 = this.method_206(num3);
        return (float) Math.Round((double) (this.method_245(num4) - num2), 1);
    }

    public float method_245(int int_3)
    {
        return (float) Math.Round((double) ((int_3 - this.class10_settings_0.int_6) * 0.01450377f), 2);
    }

    public float method_246(int int_3)
    {
        return (float) Math.Round((double) (int_3 * 0.02952999), 1);
    }

    public byte[] method_246_HTSCrypter(byte[] byte_3)
    {
        byte[] buffer1 = this.method_248_HTSCrypter(byte_3);
        byte_3 = buffer1;
        byte num = byte_3[byte_3.Length - 1];
        byte[] buffer = new byte[byte_3.Length - 1];
        for (int i = 0; i < buffer.Length; i++)
        {
            if ((i % 2) == 0)
            {
                int num3 = byte_3[i] - num;
                if (num3 < 0)
                {
                    num3 += 0x100;
                }
                buffer[i] = (byte)num3;
            }
            else
            {
                int num4 = byte_3[i] + num;
                if (num4 > 0xff)
                {
                    num4 -= 0x100;
                }
                buffer[i] = (byte)num4;
            }
        }
        byte_3 = null;
        return buffer;
    }

    public byte[] method_248_HTSCrypter(byte[] byte_3)
    {
        byte num = byte_3[0x10];
        byte num2 = byte_3[0x21];
        byte num3 = byte_3[50];
        byte num4 = byte_3[0x43];
        byte num5 = byte_3[0x54];
        byte num6 = byte_3[0x65];
        byte num7 = byte_3[0x76];
        byte num8 = byte_3[0x87];
        byte num9 = byte_3[byte_3.Length - 1];
        byte num10 = 0;
        byte[] buffer = new byte[byte_3.Length - 9];
        int index = 0;
        for (int i = 0; i < buffer.Length; i++)
        {
            if (i < 0x80)
            {
                num10 = num8;
            }
            if (i < 0x70)
            {
                num10 = num7;
            }
            if (i < 0x60)
            {
                num10 = num6;
            }
            if (i < 80)
            {
                num10 = num5;
            }
            if (i < 0x40)
            {
                num10 = num4;
            }
            if (i < 0x30)
            {
                num10 = num3;
            }
            if (i < 0x20)
            {
                num10 = num2;
            }
            if (i < 0x10)
            {
                num10 = num;
            }
            if (i >= 0x80)
            {
                num10 = num9;
            }
            if (((i == 0x10) || ((i == 0x20) || ((i == 0x30) || ((i == 0x40) || ((i == 80) || ((i == 0x60) || (i == 0x70))))))) || (i == 0x80))
            {
                index++;
            }
            int num13 = byte_3[index] + num10;
            if (num13 > 0xff)
            {
                num13 -= 0x100;
            }
            buffer[i] = (byte)num13;
            index++;
        }
        byte_3 = null;
        return buffer;
    }

    public int method_247(float float_0)
    {
        return (int) Math.Round((double) (float_0 * 33.86388), 0);
    }

    public float method_248(int int_3)
    {
        return (float) Math.Round((double) (int_3 * 0.1), 0);
    }

    public int method_249(float float_0)
    {
        return (int) Math.Round((double) (float_0 * 10f), 0);
    }

    public string method_25_GetFilename()
    {
        return this.string_4;
    }

    public int method_250(float float_0)
    {
        return (int) Math.Round((double) ((float_0 * 68.94757) + this.class10_settings_0.int_6));
    }

    public string method_251(MapSensorUnits mapSensorUnits_0)
    {
        switch (mapSensorUnits_0)
        {
            case MapSensorUnits.mBar:
                return "mbar";

            case MapSensorUnits.inHgG:
                return "inHg";

            case MapSensorUnits.inHg:
                return "inHg";

            case MapSensorUnits.psi:
                return "psi";

            case MapSensorUnits.kPa:
                return "kpa";
        }
        return "";
    }

    public bool method_252(string string_8)
    {
        double num;
        return double.TryParse(Convert.ToString(string_8), NumberStyles.Any, (IFormatProvider) NumberFormatInfo.CurrentInfo, out num);
    }

    public bool method_253(string string_8)
    {
        double num;
        bool flag = double.TryParse(Convert.ToString(string_8), NumberStyles.Any, (IFormatProvider) NumberFormatInfo.CurrentInfo, out num);
        if (num > 0.0)
        {
            return false;
        }
        return flag;
    }

    public bool method_254(string string_8)
    {
        double num;
        bool flag = double.TryParse(Convert.ToString(string_8), NumberStyles.Any, (IFormatProvider) NumberFormatInfo.CurrentInfo, out num);
        if (num < 0.0)
        {
            return false;
        }
        return flag;
    }

    public bool method_255(string string_8)
    {
        int num;
        return int.TryParse(Convert.ToString(string_8), NumberStyles.Any, NumberFormatInfo.CurrentInfo, out num);
    }

    public bool method_256(string string_8)
    {
        int num;
        bool flag = int.TryParse(Convert.ToString(string_8), NumberStyles.Any, NumberFormatInfo.CurrentInfo, out num);
        if (num < 0)
        {
            return false;
        }
        return flag;
    }

    public bool method_257(string string_8)
    {
        int num;
        bool flag = int.TryParse(Convert.ToString(string_8), NumberStyles.Any, NumberFormatInfo.CurrentInfo, out num);
        if (num <= 0)
        {
            return false;
        }
        return flag;
    }

    public bool method_258(byte byte_3, int int_3)
    {
        byte[] bytes_4 = new byte[] { byte_3 };
        BitArray array_0 = new BitArray(bytes_4);
        return array_0.Get(int_3);
    }

    public bool method_259(byte byte_3, int int_3, bool bool_3)
    {
        byte[] bytes_4 = new byte[] { byte_3 };
        BitArray array_0 = new BitArray(bytes_4);
        if (bool_3)
        {
            return !array_0.Get(int_3);
        }
        return array_0.Get(int_3);
    }

    public void method_26_SetFilename(string string_8)
    {
        this.string_4 = string_8;
    }

    public byte method_260(byte byte_3, int int_3, bool bool_3)
    {
        byte[] bytes_4 = new byte[] { byte_3 };
        BitArray array_0 = new BitArray(bytes_4);
        if (bool_3)
        {
            if (array_0.Get(int_3))
            {
                return 0;
            }
            return 1;
        }
        if (array_0.Get(int_3))
        {
            return 1;
        }
        return 0;
    }

    public byte method_261(byte byte_3, int int_3, bool bool_3)
    {
        bool[] flagArray = this.method_262(byte_3);
        flagArray[int_3] = bool_3;
        return this.method_263(flagArray);
    }

    private bool[] method_262(int int_3)
    {
        bool[] flagArray = new bool[8];
        if ((int_3 - 0x80) >= 0)
        {
            flagArray[7] = true;
            int_3 -= 0x80;
        }
        if ((int_3 - 0x40) >= 0)
        {
            flagArray[6] = true;
            int_3 -= 0x40;
        }
        if ((int_3 - 0x20) >= 0)
        {
            flagArray[5] = true;
            int_3 -= 0x20;
        }
        if ((int_3 - 0x10) >= 0)
        {
            flagArray[4] = true;
            int_3 -= 0x10;
        }
        if ((int_3 - 8) >= 0)
        {
            flagArray[3] = true;
            int_3 -= 8;
        }
        if ((int_3 - 4) >= 0)
        {
            flagArray[2] = true;
            int_3 -= 4;
        }
        if ((int_3 - 2) >= 0)
        {
            flagArray[1] = true;
            int_3 -= 2;
        }
        if ((int_3 - 1) >= 0)
        {
            flagArray[0] = true;
            int_3--;
        }
        return flagArray;
    }

    private byte method_263(bool[] bool_3)
    {
        byte num = 0;
        if (bool_3[7])
        {
            num = (byte) (num + 0x80);
        }
        if (bool_3[6])
        {
            num = (byte) (num + 0x40);
        }
        if (bool_3[5])
        {
            num = (byte) (num + 0x20);
        }
        if (bool_3[4])
        {
            num = (byte) (num + 0x10);
        }
        if (bool_3[3])
        {
            num = (byte) (num + 8);
        }
        if (bool_3[2])
        {
            num = (byte) (num + 4);
        }
        if (bool_3[1])
        {
            num = (byte) (num + 2);
        }
        if (bool_3[0])
        {
            num = (byte) (num + 1);
        }
        return num;
    }

    private double method_264(double[] double_1, double double_2)
    {
        int index = double_1.Length - 1;
        if (double_2 < double_1[0])
        {
            return double_1[1];
        }
        if (double_2 > double_1[index - 1])
        {
            return double_1[index];
        }
        for (int i = 0; i < (double_1.Length / 2); i++)
        {
            index = 2 * i;
            if ((double_2 >= double_1[index]) && (double_2 <= double_1[index + 2]))
            {
                return (double_1[index + 1] + (((double_2 - double_1[index]) * (double_1[index + 3] - double_1[index + 1])) / (double_1[index + 2] - double_1[index])));
            }
        }

        this.class17_0.frmMain_0.LogThis("Error with interpolation");
        return 0.0;
        //throw new Exception("Error with interpolation");
    }

    public bool method_265(long[] long_0_X)
    {
        for (int i = 0; i < long_0_X.Length; i++)
        {
            if (long_0_X[i] == 0L)
            {
                return false;
            }
        }
        return true;
    }

    public void method_266(bool bool_3, bool bool_4)
    {
        this.method_155("Copy Primary Maps To Secondary Maps");
        int num = (this.method_32_GetRPM_RowsNumber() * this.method_33()) + this.method_33();
        for (int i = 0; i < num; i++)
        {
            this.method_149_SetByte(this.class13_u_0.long_20 + i, this.GetByteAt(this.class13_u_0.long_10 + i));
            this.method_149_SetByte(this.class13_u_0.long_21 + i, this.GetByteAt(this.class13_u_0.long_11 + i));
        }
        for (int j = 0; j < (num - this.method_33()); j++)
        {
            this.method_149_SetByte(this.class13_u_0.long_22 + j, this.GetByteAt(this.class13_u_0.long_12 + j));
            this.method_149_SetByte(this.class13_u_0.long_23 + j, this.GetByteAt(this.class13_u_0.long_13 + j));
        }
        if (bool_3)
        {
            for (byte k = 0; k < this.method_33(); k = (byte) (k + 1))
            {
                byte num5 = (byte) this.method_166(k, SelectedTable.fuel1_hi);
                this.method_171(k, num5, SelectedTable.fuel2_hi);
            }
        }
        if (bool_4)
        {
            for (byte m = 0; m < this.method_32_GetRPM_RowsNumber(); m = (byte) (m + 1))
            {
                byte num7 = (byte) this.method_162(m, SelectedTable.fuel1_lo);
                this.method_170(m, num7, SelectedTable.fuel2_lo);
                byte num8 = (byte) this.method_162(m, SelectedTable.fuel1_hi);
                this.method_170(m, num8, SelectedTable.fuel2_hi);
            }
        }
        this.method_153();
        this.method_53();
        this.method_153();
    }

    public void method_267(bool bool_3, bool bool_4)
    {
        this.method_155("Copy Secondary Maps To Primary Maps");
        int num = (this.method_32_GetRPM_RowsNumber() * this.method_33()) + this.method_33();
        for (int i = 0; i < num; i++)
        {
            this.method_149_SetByte(this.class13_u_0.long_10 + i, this.GetByteAt(this.class13_u_0.long_20 + i));
            this.method_149_SetByte(this.class13_u_0.long_11 + i, this.GetByteAt(this.class13_u_0.long_21 + i));
        }
        for (int j = 0; j < (num - this.method_33()); j++)
        {
            this.method_149_SetByte(this.class13_u_0.long_12 + j, this.GetByteAt(this.class13_u_0.long_22 + j));
            this.method_149_SetByte(this.class13_u_0.long_13 + j, this.GetByteAt(this.class13_u_0.long_23 + j));
        }
        if (bool_3)
        {
            for (byte k = 0; k < this.method_33(); k = (byte) (k + 1))
            {
                byte num5 = (byte) this.method_166(k, SelectedTable.fuel2_hi);
                this.method_171(k, num5, SelectedTable.fuel1_hi);
            }
        }
        if (bool_4)
        {
            for (byte m = 0; m < this.method_32_GetRPM_RowsNumber(); m = (byte) (m + 1))
            {
                byte num7 = (byte) this.method_162(m, SelectedTable.fuel2_lo);
                this.method_170(m, num7, SelectedTable.fuel1_lo);
                byte num8 = (byte) this.method_162(m, SelectedTable.fuel2_hi);
                this.method_170(m, num8, SelectedTable.fuel1_hi);
            }
        }
        this.method_153();
        this.method_53();
        this.method_153();
    }

    public string method_27()
    {
        if (string.IsNullOrEmpty(this.method_25_GetFilename()))
        {
            return string.Empty;
        }
        FileInfo info = new FileInfo(this.method_25_GetFilename());
        string directoryName = info.DirectoryName;
        info = null;
        return directoryName;
    }

    public bool method_28()
    {
        return this.bool_2;
    }

    public void method_29(bool bool_3)
    {
        this.bool_2 = bool_3;
    }

    public void method_3()
    {
        if (this.delegate55_1 != null)
        {
            this.delegate55_1();
        }
    }

    public bool method_30_HasFileLoadedInBMTune()
    {
        return this.bool_1;
    }

    public void SetFileLoaded(bool bool_3)
    {
        this.bool_1 = bool_3;
        if (!this.method_28())
        {
            if (this.delegate58_0 != null)
            {
                this.delegate58_0();
            }
            if (this.delegate55_1 != null)
            {
                this.delegate55_1();
            }
        }
    }

    public byte method_32_GetRPM_RowsNumber()
    {
        return this.method_148(this.long_4);
    }

    public byte method_33()
    {
        return this.method_147(this.long_4);
    }

    public long method_34()
    {
        return (long) (this.method_32_GetRPM_RowsNumber() * this.method_33());
    }

    public bool method_35()
    {
        switch (this.method_4())
        {
            case SelectedTable.ign1_lo:
                return true;

            case SelectedTable.fuel1_lo:
                return true;

            case SelectedTable.ign2_lo:
                return true;

            case SelectedTable.fuel2_lo:
                return true;

            case SelectedTable.ve_lo:
                return true;
        }
        return false;
    }

    public bool method_35_Selectable(SelectedTable SelectedTable_0)
    {
        switch (SelectedTable_0)
        {
            case SelectedTable.ign1_lo:
                return true;

            case SelectedTable.fuel1_lo:
                return true;

            case SelectedTable.ign2_lo:
                return true;

            case SelectedTable.fuel2_lo:
                return true;

            case SelectedTable.ve_lo:
                return true;
        }
        return false;
    }

    public bool method_36()
    {
        switch (this.method_4())
        {
            case SelectedTable.ign1_hi:
                return true;

            case SelectedTable.fuel1_hi:
                return true;

            case SelectedTable.ign2_hi:
                return true;

            case SelectedTable.fuel2_hi:
                return true;

            case SelectedTable.ve_hi:
                return true;
        }
        return false;
    }

    public bool method_36_Selectable(SelectedTable SelectedTable_0)
    {
        switch (SelectedTable_0)
        {
            case SelectedTable.ign1_hi:
                return true;

            case SelectedTable.fuel1_hi:
                return true;

            case SelectedTable.ign2_hi:
                return true;

            case SelectedTable.fuel2_hi:
                return true;

            case SelectedTable.ve_hi:
                return true;
        }
        return false;
    }

    public bool method_37()
    {
        switch (this.method_4())
        {
            case SelectedTable.fuel1_lo:
                return true;

            case SelectedTable.fuel1_hi:
                return true;

            case SelectedTable.fuel2_lo:
                return true;

            case SelectedTable.fuel2_hi:
                return true;
        }
        return false;
    }

    public bool method_38()
    {
        if (this.method_4() != SelectedTable.ve_lo)
        {
            return (this.method_4() == SelectedTable.ve_hi);
        }
        return true;
    }

    public bool method_39()
    {
        int num = (int) this.method_4();
        return ((num >= 5) && (num <= 8));
    }

    public SelectedTable method_4()
    {
        return this.selectedTable_0;
    }

    public bool method_40()
    {
        switch (this.method_4())
        {
            case SelectedTable.ign1_lo:
                return true;

            case SelectedTable.ign1_hi:
                return true;

            case SelectedTable.ign2_lo:
                return true;

            case SelectedTable.ign2_hi:
                return true;
        }
        return false;
    }

    public bool method_41()
    {
        if ((this.class13_u_0.long_372 == 0L) || !this.method_30_HasFileLoadedInBMTune())
        {
            return false;
        }
        if (!this.method_39())
        {
            return this.method_258(this.GetByteAt(this.class13_u_0.long_372), 0);
        }
        return this.method_258(this.GetByteAt(this.class13_u_0.long_372), 2);
    }

    public bool method_42()
    {
        if ((this.class13_u_0.long_372 == 0L) || !this.method_30_HasFileLoadedInBMTune())
        {
            return false;
        }
        if (!this.method_39())
        {
            return this.method_258(this.GetByteAt(this.class13_u_0.long_372), 1);
        }
        return this.method_258(this.GetByteAt(this.class13_u_0.long_372), 3);
    }

    public bool method_43(int int_3)
    {
        if ((this.class13_u_0.long_371 != 0L) && (this.method_37() || this.method_40()))
        {
            if (this.method_41())
            {
                int num = this.method_206(this.GetByteAt(this.class13_u_0.long_371));
                if (int_3 >= num)
                {
                    return true;
                }
            }
            else if (this.method_42())
            {
                return true;
            }
        }
        return false;
    }

    public bool method_44()
    {
        return (this.method_8() != TableOverlay.none);
    }

    public bool method_45()
    {
        if (this.class11_u_0 == null)
        {
            return false;
        }
        return this.class11_u_0.method_1();
    }

    public bool method_46()
    {
        if (this.method_48() || (this.method_25_GetFilename() == null))
        {
            return true;
        }
        FileInfo info = new FileInfo(this.method_25_GetFilename());
        bool flag = false;
        if (info.Extension == ".bmc")
        {
            flag = true;
        }
        info = null;
        return flag;
    }

    public bool method_47()
    {
        return (this.method_25_GetFilename() == "Emulator Rom");
    }

    public bool method_48()
    {
        if (!(this.method_25_GetFilename() == "Emulator Rom"))
        {
            return (this.method_25_GetFilename() == "New Calibration");
        }
        return true;
    }

    public double method_49()
    {
        return (((double) this.method_152(this.class13_u_0.long_33)) / 32768.0);
    }

    public void method_5_SetSelectedTable(SelectedTable selectedTable_1)
    {
        this.class17_0.frmMain_0.SpawnWaitingwindows();
        this.selectedTable_0 = selectedTable_1;
        if (this.delegate57_0 != null) this.delegate57_0(selectedTable_1);
        this.class17_0.frmMain_0.CloseWaitingwindows();
    }

    public int method_50_GetOLDInjectorSize()
    {
        if (this.method_152(this.class13_u_0.long_41) != 0L)
        {
            return (int) this.method_152(this.class13_u_0.long_41);
        }
        return 240;
    }

    public void method_51_SetOLDInjectorSize(int int_3)
    {
        this.method_151(this.class13_u_0.long_41, (long) int_3);
    }

    public void method_52()
    {
        if (this.delegate58_0 != null) this.delegate58_0();
    }

    public void method_53()
    {
        if (this.delegate55_0 != null) this.delegate55_0();
    }

    public void method_54()
    {
        if (!this.method_48() && !this.method_47())
        {
            this.method_69();
        }
    }

    public FuelDisplayMode method_6()
    {
        return this.fuelDisplayMode_0;
    }

    public void method_60()
    {
        if (this.class17_0 != null)
        {
            if (this.class17_0.method_34_GetConnected())
            {
                this.class17_0.method_36();
                this.class17_0.method_20();
            }
            if (this.class17_0.method_63_HasLogsFileOpen())
            {
                this.class17_0.method_75();
            }
        }
    }

    //Open file (when clicking the button 'open file' in the main menu
    public void method_61()
    {
        this.class21_snap_0.method_8();
        this.method_60();
        OpenFileDialog dialog = new OpenFileDialog();
        if (this.class10_settings_0.romFilePath != string.Empty)
        {
            if (this.class10_settings_0.romFilePath == Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\")
                this.class10_settings_0.romFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        else
        {
            this.class10_settings_0.romFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        dialog.InitialDirectory = this.class10_settings_0.romFilePath;


        //########################################
        //1. BMTune and HTS DEV ROM |*.asm
        //2. ECU Binary|*.bin
        //3. Kseries Calibration|*.khts
        //4. Honda Tune File|*.bin;*.khts
        //5. Universal ECU Bin File|*.bin
        //dialog.Filter = "BMTune and HTS DEV ROM |*.asm|ECU Binary|*.bin|Kseries Calibration|*.khts|Honda Tune File|*.bin;*.khts|Universal ECU Bin File|*.bin";
        //########################################

        //########################################
        //1. BMTune Devlopment Baserom |*.asm
        //2. Honda Tune File|*.bin
        //3. Universal ECU Bin File|*.bin
        dialog.Filter = "BMTune Devlopment Baserom|*.asm|ECU Binary|*.bin|Honda Tune File|*.bin";
        //dialog.Filter = "BMTune Devlopment Baserom|*.asm|ECU Binary|*.bin|Honda Tune File|*.bin|Universal ECU Bin File|*.bin";
        //########################################

        dialog.CheckFileExists = true;
        dialog.CheckPathExists = true;
        //dialog.FilterIndex = !false ? 4 : 3;
        dialog.FilterIndex = 2;

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            //KBinLoaded = false;

            FileInfo info = new FileInfo(dialog.FileName);
            this.class10_settings_0.romFilePath = info.DirectoryName;
            this.method_26_SetFilename(dialog.FileName);
            this.method_24(info.Name);
            string str = Path.GetExtension(dialog.FileName).ToLower();

            //if (dialog.FilterIndex == 5)
            /*if (dialog.FilterIndex == 3)
            {
                this.method_LoadVWTune(dialog.FileName);
            }
            else
            {*/
                //if (str == ".khts") dialog.FilterIndex = 3;
                //else if (str == ".bin") dialog.FilterIndex = 2;

                /*if (dialog.FilterIndex == 3)
                {
                    this.method_LoadKTune(dialog.FileName);
                }
                else
                {*/

                //Reload Normal Menu
                if (this.class17_0.frmMain_0.CustomMenuLoaded)
                {
                    this.class17_0.frmMain_0.LoadKTable(false, false);
                    this.class17_0.frmMain_0.LoadPages();
                }

                this.method_5_SetSelectedTable(SelectedTable.fuel1_lo);
                this.method_9(TableOverlay.none);
                if (dialog.FilterIndex == 2)
                {
                    try
                    {
                        int length;
                        FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        if (stream.CanRead)
                        {
                            length = (int)stream.Length;
                            byte[] byte_XX = new byte[length];
                            stream.Read(byte_XX, 0, length);
                            SetAllByte(byte_XX);
                        }
                        stream.Dispose();
                        stream = null;
                        length = 0;

                        this.method_90();
                        GlitchTestingTimer = 0;
                        //if (this.method_30_HasFileLoadedInBMTune()) this.method_54();
                    }
                    catch (Exception mess)
                    {
                        MessageBox.Show(Form.ActiveForm, mess.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else if (dialog.FilterIndex == 1)
                {
                    if (this.class10_settings_0.frmMain_0.ConvertASMtoBIN(dialog.FileName))
                    {
                        SetAllByte(File.ReadAllBytes(dialog.FileName + ".bin"));
                        this.method_90();
                    }
                    else
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to compile ASM into BIN!", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //this.method_66(dialog.FileName); //loading calibrations
                }
            //}
            this.class10_settings_0.method_28(dialog.FileName);
        }
        dialog.Dispose();
        dialog = null;
        GC.Collect(3, GCCollectionMode.Forced);
    }

    /*public void method_LoadKTune(string string_7)
    {
        this.class10_settings_0.frmMain_0.ktable_0.string_8 = string_7;
        this.class10_settings_0.frmMain_0.LoadKTable(true, false);
        KBinLoaded = true;
    }*/

    /*public void method_LoadOBD0(string string_7)
    {
        this.class10_settings_0.frmMain_0.ktable_0.string_8 = string_7;
        this.class10_settings_0.frmMain_0.LoadKTable(false, true);
        KBinLoaded = true;
    }*/

    //Load Last File
    public void method_62(string string_8)
    {
        //load asm into .bin
        if (string_8.Substring(string_8.Length - 4).Contains(".asm"))
        {
            if (!this.class17_0.frmMain_0.ConvertASMtoBIN(string_8))
            {
                MessageBox.Show("Failed to compile ASM into BIN.");
                return;
            }
            string text1 = string_8 + ".bin";
            string_8 = text1;
        }

        this.class21_snap_0.method_8();
        this.method_60();
        FileInfo info = new FileInfo(string_8);
        if (!info.Exists)
        {
            this.class10_settings_0.method_29(string_8);
        }
        else
        {
            string str = Path.GetExtension(string_8).ToLower();
            /*if ((str == ".KHTS") || (str == "khts"))
            {
                if (MessageBox.Show("Last opened file was K series calibration." + Environment.NewLine + "Do you want to open this again?", "K-Series", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.method_LoadKTune(string_8);
                }
            }
            else
            {*/
            this.method_5_SetSelectedTable(SelectedTable.fuel1_lo);
            this.method_9(TableOverlay.none);
            if (!this.method_30_HasFileLoadedInBMTune() || this.method_68())
            {
                this.method_26_SetFilename(string_8);
                this.method_24(info.Name);
                FileInfo info2 = new FileInfo(this.method_25_GetFilename());
                if (info2.Extension == ".bin")
                {
                    try
                    {
                        int length;
                        FileStream stream = new FileStream(string_8, FileMode.Open, FileAccess.Read);
                        if (stream.CanRead)
                        {
                            length = (int)stream.Length;
                            //byte[] byte_XX = null;
                            byte[] byte_XX = new byte[length];
                            stream.Read(byte_XX, 0, length);

                            SetByteNull();
                            SetAllByte(byte_XX);
                        }
                        stream.Dispose();
                        stream = null;
                        length = 0;
                        this.method_90();
                        GlitchTestingTimer = 0;
                        //if (!this.method_30_HasFileLoadedInBMTune()) this.method_54();  //save file
                    }
                    catch (Exception mess)
                    {
                        MessageBox.Show(Form.ActiveForm, mess.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    this.method_66(string_8);
                }
                if (this.method_30_HasFileLoadedInBMTune())
                {
                    this.class10_settings_0.method_28(string_8);
                }
                else
                {
                    this.method_68();
                }
                GC.Collect(3, GCCollectionMode.Forced);
            }
            //}
        }
    }

    public void method_63(bool bool_3, int Version, string Filename)
    {
        byte[] buffer = new byte[] { };

        //Select New and Last Version
        RomVersion = Version;
        //LoadBinaryFiles();
        buffer = Binary_Files_0.ThisBytesL[Version - 100];
        RomVersion = Version;
        //CloseBinaryFiles();

        if (bool_3)
        {
            this.method_67(buffer, true);
            buffer = null;
            GC.Collect(1, GCCollectionMode.Forced);
        }
        else
        {
            //here for loading premade, new baserom, etc
            if (Filename == "") Filename = "New Baserom";
            if (Path.GetDirectoryName(Filename) == "" && this.class10_settings_0.romFilePath != "") Filename = this.class10_settings_0.romFilePath + @"\" + Filename;

            this.class21_snap_0.method_8();
            this.method_68();
            this.method_60();
            this.method_26_SetFilename(Filename);
            this.method_24(Filename);
            this.method_67(buffer, true);
            buffer = null;
            GC.Collect(1, GCCollectionMode.Forced);
            //this.method_54();       //save file
        }
    }

    public void method_65()
    {
        this.class11_u_0.method_12();
    }

    public void method_66(string string_8)
    {
        this.method_29(true);
        this.class21_snap_0.method_8();
        this.method_63(true, Stable_Version_LAST + 100, "");
        this.method_26_SetFilename(string_8);
        FileInfo info = new FileInfo(string_8);
        if (info.Exists)
        {
            this.method_24(info.Name);
            info = null;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\" + Path.GetFileName(string_8);
            byte[] byte_99_0 = method_93(File.ReadAllBytes(string_8));
            File.WriteAllBytes(path, byte_99_0);

            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            //FileStream stream = new FileStream(string_8, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int) stream.Length);
            stream.Dispose();
            stream = null;
            this.method_29(false);
            this.method_76(buffer, true);
            buffer = null;
            if (File.Exists(path)) File.Delete(path);
            this.method_54();
            GC.Collect(1, GCCollectionMode.Forced);
        }
    }

    //Loading Full File (32kb .bin)
    public void method_67(byte[] byte_3, bool bool_3)
    {
        SetAllByte(byte_3);
        //this.byte_0 = byte_3;
        if (!bool_3)
        {
            this.method_26_SetFilename("Emulator Rom");
            this.method_24("Emulator Rom");
        }
        this.method_90();
        this.class11_u_0.method_12();
        GC.Collect(3, GCCollectionMode.Forced);
    }

    public bool method_68()
    {
        this.class21_snap_0.method_8();
        this.method_60();
        if (this.method_30_HasFileLoadedInBMTune())
        {
            if (this.method_45())
            {
                switch (MessageBox.Show(Form.ActiveForm, "Unsaved modifications!" + Environment.NewLine + "Do you want to save modifications?", "BMTune", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        this.method_69();
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }
            else if (this.method_48() || this.method_47())
            {
                switch (MessageBox.Show(Form.ActiveForm, "Unsaved modifications!" + Environment.NewLine + "Do you want to save modifications?", "BMTune", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        this.method_70();
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }
        }
        this.method_26_SetFilename(null);
        this.method_24(null);
        this.class11_u_0.method_12();
        this.SetFileLoaded(false);
        GC.Collect(3, GCCollectionMode.Forced);
        return true;
    }

    //This method refer to 'File/Save'
    public void method_69()
    {
        if (this.method_48() || this.method_47())
        {
            this.method_70();
        }
        else
        {
            try
            {
                FileInfo info = new FileInfo(this.method_25_GetFilename());
                if (info.Exists) info.Delete();
                if (info.Extension == ".bin")
                {
                    FileStream stream = new FileStream(this.method_25_GetFilename(), FileMode.OpenOrCreate, FileAccess.Write);
                    stream.Write(GetAllByte(), 0, GetByteLenght());
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                    info = null;
                }
                else
                {
                    this.method_73(this.method_25_GetFilename());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Form.ActiveForm, exception.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.class11_u_0.method_12();
        }
    }

    public void method_7(FuelDisplayMode fuelDisplayMode_1)
    {
        this.fuelDisplayMode_0 = fuelDisplayMode_1;
        if (this.delegate61_0 != null)
        {
            this.delegate61_0(fuelDisplayMode_1);
        }
    }

    //This method refer to 'Save As'
    public void method_70()
    {
        SaveFileDialog dialog = new SaveFileDialog();

        if (this.class10_settings_0.romFilePath == string.Empty
            || this.class10_settings_0.romFilePath == Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\")
        {
            this.class10_settings_0.romFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        dialog.InitialDirectory = this.class10_settings_0.romFilePath;
        dialog.OverwritePrompt = true;
        /*dialog.Filter = "BMTune Binary|*.bin";
        dialog.FilterIndex = 1;
        if (this.class15_0.method_5(Enum4.const_12))
        {*/
            dialog.Filter = "BMTune Calibration|*.bmc|BMTune Binary|*.bin";
            dialog.FilterIndex = 2;
        //}

        dialog.FileName = this.string_5;
        if (dialog.FileName.LastIndexOf('.') != -1) dialog.FileName = dialog.FileName.Substring(0, dialog.FileName.Length - 4);
        if (dialog.FilterIndex == 1) dialog.DefaultExt = ".bmc";
        else if (dialog.FilterIndex == 2) dialog.DefaultExt = ".bin";
        /*if (dialog.FilterIndex == 1 && this.class15_0.method_5(Enum4.const_12)) dialog.DefaultExt = ".bmc";
        else if (dialog.FilterIndex == 1 && !this.class15_0.method_5(Enum4.const_12)) dialog.DefaultExt = ".bin";
        else if (dialog.FilterIndex == 2 && this.class15_0.method_5(Enum4.const_12)) dialog.DefaultExt = ".bin";*/
        dialog.AddExtension = true;

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                if (File.Exists(dialog.FileName)) File.Delete(dialog.FileName);

                //Open .bin File
                //if ((dialog.FilterIndex == 1 && !this.class15_0.method_5(Enum4.const_12)) || (dialog.FilterIndex == 2 && this.class15_0.method_5(Enum4.const_12)))
                if (dialog.FilterIndex == 2)
                {
                    FileStream stream = new FileStream(dialog.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    stream.Write(GetAllByte(), 0, GetByteLenght());
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }
                //Open .bmc File
                //else if (dialog.FilterIndex == 1 && this.class15_0.method_5(Enum4.const_12))
                else if (dialog.FilterIndex == 1)
                {
                    this.method_73(dialog.FileName);    //load cal (.bmc) only for developper
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Form.ActiveForm, exception.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FileInfo info2 = new FileInfo(dialog.FileName);
            this.class10_settings_0.romFilePath = info2.DirectoryName;
            this.method_26_SetFilename(dialog.FileName);
            this.method_24(info2.Name);
            info2 = null;
            this.class11_u_0.method_12();
            this.method_52();
            this.class10_settings_0.method_28(this.method_25_GetFilename());
        }
    }

    //export calibration clic from Frm_Main
    public void method_72()
    {
        SaveFileDialog dialog = new SaveFileDialog();
        if (this.class10_settings_0.calFilePath != string.Empty) dialog.InitialDirectory = this.class10_settings_0.calFilePath;
        dialog.DefaultExt = "*.bmc";
        dialog.Filter = "BMTune Calibration|*.bmc";
        dialog.DefaultExt = ".bmc";
        dialog.AddExtension = true;
        dialog.OverwritePrompt = true;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            FileInfo info = new FileInfo(dialog.FileName);
            if (info.Exists) info.Delete();
            this.class10_settings_0.calFilePath = info.Directory.ToString();
            info = null;

            method_73(dialog.FileName);
        }
        dialog.Dispose();
        dialog = null;
    }

    public void method_73(string string_8)
    {
        FileInfo info = new FileInfo(string_8);
        if (info.Exists)
        {
            info.Delete();
        }
        if (!info.Directory.Exists)
        {
            info.Directory.Create();
        }
        info = null;

        FileStream stream = new FileStream(string_8, FileMode.CreateNew, FileAccess.Write);
        this.byte_2 = 0;
        stream.WriteByte(this.method_147(this.class13_u_0.long_89));
        stream.WriteByte(this.method_148(this.class13_u_0.long_89));
        stream.WriteByte(this.method_147(this.class13_u_0.long_90));
        stream.WriteByte(this.method_148(this.class13_u_0.long_90));
        for (int k = 0; k < 4; k++)
        {
            stream.WriteByte(this.GetByteAt((long) (0x7ffa + k)));
        }
        for (long i = this.class13_u_0.long_89; i <= this.class13_u_0.long_90; i += 1L)
        {
            stream.WriteByte(this.GetByteAt(i));
            this.method_86(this.GetByteAt(i));
        }
        for (long j = 0L; j < 3L; j += 1L)
        {
            stream.WriteByte(this.GetByteAt(this.class13_u_0.long_68 + j));
            this.method_86(this.GetByteAt(this.class13_u_0.long_68 + j));
        }
        stream.WriteByte(this.method_85());
        //Set Calibration comment
        //byte[] bytes = Encoding.UTF8.GetBytes(this.method_88_GetComments());
        //stream.Write(bytes, 0, bytes.Length);
        stream.Dispose();
        stream = null;

        byte[] byte_99_0 = method_92(File.ReadAllBytes(string_8));
        File.WriteAllBytes(string_8, byte_99_0);
    }

    //calibration import button clic from Frm_Main
    public void method_74()
    {
        FileStream stream = null;
        OpenFileDialog dialog = new OpenFileDialog();
        if (this.class10_settings_0.calFilePath != string.Empty) dialog.InitialDirectory = this.class10_settings_0.calFilePath;
        dialog.DefaultExt = "*.bmc";
        dialog.Filter = "BMTune Calibration|*.bmc|eCtune Calibration|*.cal|HTS Calibration|*.bmc";
        dialog.CheckFileExists = true;
        dialog.CheckPathExists = true;
        string path = "";
        try
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\" + Path.GetFileName(dialog.FileName);
                FileInfo info = new FileInfo(path);
                this.class10_settings_0.calFilePath = info.Directory.ToString();
                info = null;

                method_75(dialog.FileName, false, dialog.FilterIndex);
            }
            dialog.Dispose();
            dialog = null;
        }
        catch
        {
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
            if (dialog != null)
            {
                dialog.Dispose();
                dialog = null;
            }
            if (File.Exists(path)) File.Delete(path);
        }
    }

    public void method_75(string string_8, bool bool_3, int FilterIndex)
    {
        FileStream stream = null;
        long num = this.class13_u_0.long_89;
        long num2 = this.class13_u_0.long_90;
        long num3 = 0L;
        long num4 = 0L;
        byte num5 = 0;
        byte[] buffer = null;
        byte[] buffer2 = new byte[3];
        string path = "";
        try
        {
            this.byte_2 = 0;
            if (FilterIndex == 1)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\" + Path.GetFileName(string_8);
                byte[] byte_99_0 = method_93(File.ReadAllBytes(string_8));
                File.WriteAllBytes(path, byte_99_0);
            }
            if (FilterIndex == 2)
            {
                path = string_8;
            }
            if (FilterIndex == 3)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\" + Path.GetFileName(string_8);
                byte[] byte_99_0 = method_246_HTSCrypter(File.ReadAllBytes(string_8));
                File.WriteAllBytes(path, byte_99_0);
            }
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            num = this.method_146((byte) stream.ReadByte(), (byte) stream.ReadByte());
            num2 = this.method_146((byte) stream.ReadByte(), (byte) stream.ReadByte());
            num3 = this.method_146((byte) stream.ReadByte(), (byte) stream.ReadByte());
            num4 = this.method_146((byte) stream.ReadByte(), (byte) stream.ReadByte());
            buffer = new byte[(num2 - num) + 1L];
            for (long i = 0L; i < buffer.Length; i += 1L)
            {
                buffer[(int) ((IntPtr) i)] = (byte) stream.ReadByte();
                this.method_86(buffer[(int) ((IntPtr) i)]);
            }
            for (long j = 0L; j < 3L; j += 1L)
            {
                buffer2[(int) ((IntPtr) j)] = (byte) stream.ReadByte();
                this.method_86(buffer2[(int) ((IntPtr) j)]);
            }
            num5 = (byte) stream.ReadByte();
            string s = buffer2[0].ToString() + buffer2[1].ToString() + buffer2[2].ToString();
            this.string_7 = s;
            int num8 = int.Parse(s);
            //Get Calibration comment
            /*if (stream.Length > ((buffer.Length + buffer2.Length) + 9))
            {
                bytes = new byte[stream.Length - ((buffer.Length + buffer2.Length) + 5)];
                for (int k = 0; k < (stream.Length - ((buffer.Length + buffer2.Length) + 5)); k++)
                {
                    bytes[k] = (byte) stream.ReadByte();
                }
            }*/
            if (num5 == this.method_85())
            {
                bool flag = this.class10_settings_0.bool_32;
                this.class10_settings_0.bool_32 = false;

                this.method_155("Import Calibration");
                int index = 0;
                for (long m = num; m <= num2; m += 1L)
                {
                    if (((num3 != 0L) && (num3 != 0xffffL)) && ((num4 != 0L) && (num4 != 0xffffL)))
                    {
                        if ((m >= num3) && (m <= num4))
                        {
                            this.method_149_SetByte(m, buffer[index]);
                        }
                        if (m >= 0x61f1L)
                        {
                            this.method_149_SetByte(m, buffer[index]);
                        }
                    }
                    else
                    {
                        this.method_149_SetByte(m, buffer[index]);
                    }
                    index++;
                }
                //Set Calibration comment
                /*if (bytes != null)
                {
                    string str2 = Encoding.UTF8.GetString(bytes);
                    this.method_87_SetComments(str2);
                }*/
                this.method_153();
                this.method_52();
                this.method_77();
                if (this.class25_0.GetConnected())
                {
                    if (bool_3) this.class25_0.method_17();
                    else this.class25_0.method_19();
                }
                this.class10_settings_0.bool_32 = flag;
            }
            stream.Dispose();
            stream = null;
            if (File.Exists(path)) File.Delete(path);
        }
        catch
        {
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
            if (File.Exists(path)) File.Delete(path);
        }
    }

    public void method_76(byte[] byte_3, bool bool_3)
    {
        long num = this.class13_u_0.long_89;
        long num2 = this.class13_u_0.long_90;
        long num3 = 0L;
        long num4 = 0L;
        byte num5 = 0;
        byte[] buffer = null;
        byte[] buffer2 = new byte[3];
        int num6 = 0;
        try
        {
            this.byte_2 = 0;
            num = this.method_146(byte_3[0], byte_3[1]);
            num2 = this.method_146(byte_3[2], byte_3[3]);
            num3 = this.method_146(byte_3[4], byte_3[5]);
            num4 = this.method_146(byte_3[6], byte_3[7]);
            buffer = new byte[(num2 - num) + 1L];
            for (long i = 0L; i < buffer.Length; i += 1L)
            {
                buffer[(int) ((IntPtr) i)] = byte_3[(int) ((IntPtr) (8L + i))];
                this.method_86(buffer[(int) ((IntPtr) i)]);
                num6++;
            }
            for (long j = 0L; j < 3L; j += 1L)
            {
                buffer2[(int) ((IntPtr) j)] = byte_3[(int) ((IntPtr) ((8 + buffer.Length) + j))];
                this.method_86(buffer2[(int) ((IntPtr) j)]);
            }
            string s = buffer2[0].ToString() + buffer2[1].ToString() + buffer2[2].ToString();
            this.string_7 = s;
            int num9 = int.Parse(s);
            num5 = byte_3[11 + buffer.Length];
            //Get Calibration comment
            /*if (byte_3.Length > ((buffer.Length + buffer2.Length) + 9))
            {
                bytes = new byte[byte_3.Length - ((buffer.Length + buffer2.Length) + 9)];
                for (int k = 0; k < (byte_3.Length - ((buffer.Length + buffer2.Length) + 9)); k++)
                {
                    bytes[k] = byte_3[((buffer.Length + buffer2.Length) + 9) + k];
                }
            }*/
            if (num5 == this.method_85())
            {
                int index = 0;
                bool flag = this.class10_settings_0.bool_32;
                this.class10_settings_0.bool_32 = false;

                for (long m = num; m <= num2; m += 1L)
                {
                    if (((num3 != 0L) && (num3 != 0xffffL)) && ((num4 != 0L) && (num4 != 0xffffL)))
                    {
                        if ((m >= num3) && (m <= num4)) SetByteAt(m, buffer[index]);
                        if (m >= 0x61f1L) SetByteAt(m, buffer[index]);
                    }
                    else
                    {
                        SetByteAt(m, buffer[index]);
                    }
                    index++;
                }
                //Set Calibration comment
                /*if (bytes != null)
                {
                    string str2 = Encoding.UTF8.GetString(bytes);
                    this.method_87_SetComments(str2);
                }*/
                this.method_52();
                if (this.class25_0.GetConnected())
                {
                    if (bool_3) this.class25_0.method_17();
                    else this.class25_0.method_19();
                }
                this.class10_settings_0.bool_32 = flag;

                this.method_77();
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.ToString());
        }
    }

    private void method_77()
    {
        this.method_155("init new values");
        
        if (this.GetByteAt(this.class13_u_0.long_114) == 0x80) this.method_149_SetByte(this.class13_u_0.long_114, 0);
        if (this.GetByteAt(this.class13_u_0.long_373 + 1L) == 0xff) this.method_149_SetByte(this.class13_u_0.long_373 + 1L, 0xfd);

        this.method_153();
    }

    public TableOverlay method_8()
    {
        return this.tableOverlay_0;
    }

    public void method_80()
    {
        if (this.class25_0.GetConnected())
        {
            this.class25_0.method_17();
        }
    }

    public void method_82()
    {
        SaveFileDialog dialog = new SaveFileDialog {
            Filter = "BMTune Table Export|*.bmt",
            DefaultExt = ".bmt",
            AddExtension = true,
            OverwritePrompt = true
        };
        int[] numArray = new int[0x18];
        int[] numArray2 = new int[0x18];
        int[] numArray3 = new int[0x18];
        long num1 = this.class13_u_0.long_94;
        long num7 = this.class13_u_0.long_18;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            FileStream stream;
            this.byte_2 = 0;
            FileInfo info = new FileInfo(dialog.FileName);
            if (info.Exists)
            {
                stream = new FileStream(dialog.FileName, FileMode.Truncate, FileAccess.Write);
            }
            else
            {
                stream = new FileStream(dialog.FileName, FileMode.CreateNew, FileAccess.Write);
            }
            BinaryWriter writer = new BinaryWriter(stream);
            for (int i = 0; i < this.method_33(); i++)
            {
                numArray[i] = this.method_164((byte) i, SelectedTable.fuel1_lo);
                numArray2[i] = this.method_164((byte) i, SelectedTable.fuel2_lo);
                numArray3[i] = this.method_164((byte) i, SelectedTable.fuel1_lo);
            }
            for (int j = 0; j < this.method_33(); j++)
            {
                writer.Write((short) numArray[j]);
            }
            for (int k = 0; k < this.method_33(); k++)
            {
                writer.Write((short) numArray2[k]);
            }
            for (int m = 0; m < this.method_33(); m++)
            {
                writer.Write((short) numArray3[m]);
            }
            writer.Close();
            writer = null;
            stream.Close();
            stream.Dispose();
            stream = null;
            stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read) {
                Position = 0L
            };
            for (int n = 0; n < this.method_33(); n++)
            {
                this.method_86((byte) stream.ReadByte());
            }
            stream.Close();
            stream.Dispose();
            stream = null;
            stream = new FileStream(dialog.FileName, FileMode.Append, FileAccess.Write);
            writer = new BinaryWriter(stream);
            for (long num6 = this.class13_u_0.long_18; num6 <= this.class13_u_0.long_94; num6 += 1L)
            {
                writer.Write(this.GetByteAt(num6));
                this.method_86(this.GetByteAt(num6));
            }
            writer.Write(this.method_85());
            writer.Close();
            writer = null;
            stream.Close();
            stream.Dispose();
            stream = null;

            //Remove this to add more binary in bmtune
            byte[] byte_99_0 = method_92(File.ReadAllBytes(dialog.FileName));
            File.WriteAllBytes(dialog.FileName, byte_99_0);
        }
    }

    //Import Tables button clic
    public void method_83()
    {
        OpenFileDialog dialog = new OpenFileDialog {
            DefaultExt = "*.bmt",
            //Filter = "BMTune Table Import|*.bmt",
            Filter = "BMTune Table|*.bmt|eCtune Table|*.eex|HTS Table|*.table",
            CheckFileExists = true,
            CheckPathExists = true
        };
        byte[] buffer = null;
        try
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.method_155("Import Tables");
                this.byte_2 = 0;

                if (dialog.FilterIndex == 1)
                {
                    buffer = method_93(File.ReadAllBytes(dialog.FileName));
                }
                if (dialog.FilterIndex == 2)
                {
                    buffer = File.ReadAllBytes(dialog.FileName);
                }
                if (dialog.FilterIndex == 3)
                {
                    buffer = method_246_HTSCrypter(File.ReadAllBytes(dialog.FileName));
                }
                this.ImportTableBytes(buffer);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, "Error when importing tables!" + Environment.NewLine + "Error: " + exception.Message);
        }
        finally
        {
            dialog.Dispose();
            dialog = null;
        }
    }

    public void ImportTableBytes(byte[] byte_3)
    {
        int[] numArray = new int[0x18];
        int[] numArray2 = new int[0x18];
        int[] numArray3 = new int[0x18];
        try
        {
            this.method_155("Import Tables");
            this.byte_2 = 0;
            byte num = 0;
            int length = byte_3.Length;
            for (int i = 0; i < (byte_3.Length - 1); i++)
            {
                this.method_86(byte_3[i]);
            }
            num = byte_3[length - 1];
            //if (num == this.method_85())
            //{
                int num4 = 0;
                for (long j = this.class13_u_0.long_18; j <= this.class13_u_0.long_94; j += 1L)
                {
                    this.method_149_SetByte(j, byte_3[0x90 + num4]);
                    num4++;
                }
                int num6 = 0;
                for (int k = 0; k < 0x18; k++)
                {
                    numArray[k] = BitConverter.ToInt16(byte_3, num6 + (k * 2));
                }
                num6 = 0x30;
                for (int m = 0; m < 0x18; m++)
                {
                    numArray2[m] = BitConverter.ToInt16(byte_3, num6 + (m * 2));
                }
                num6 = 0x60;
                for (int n = 0; n < 0x18; n++)
                {
                    numArray3[n] = BitConverter.ToInt16(byte_3, num6 + (n * 2));
                }
                for (int num10 = 0; num10 < 0x18; num10++)
                {
                    this.method_171((byte) num10, this.method_226(numArray[num10]), SelectedTable.fuel1_lo);
                    this.method_171((byte) num10, this.method_226(numArray2[num10]), SelectedTable.fuel2_lo);
                }
                this.method_53();
                this.method_153();
            //}
            //else
            //{
            //    MessageBox.Show(new Form {TopMost = true}, "Error when importing tables!");
            //}
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, "Error when importing tables!" + Environment.NewLine + "Error: " + exception.Message);
        }
    }

    public byte method_85()
    {
        return this.byte_2;
    }

    public void method_86(byte byte_3)
    {
        this.byte_2 = (byte) (this.byte_2 + byte_3);
    }

    public void method_87_SetComments(string string_8)
    {
        string Newpath = Path.GetDirectoryName(this.method_25_GetFilename()) + @"\" + Path.GetFileName(this.method_25_GetFilename()).Substring(0, Path.GetFileName(this.method_25_GetFilename()).Length - 4) + ".comment";
        File.Create(Newpath).Dispose();
        File.WriteAllText(Newpath, string_8);

        /*byte[] bytes = Encoding.UTF8.GetBytes(string_8);
        long num = 0x8000L;
        byte[] buffer2 = new byte[num + bytes.Length];
        for (int i = 0; i < num; i++)
        {
            buffer2[i] = GetByteAt(i);
        }
        if (bytes.Length == 0)
        {
            //this.byte_0 = new byte[0x8000];
            SetByteSize(0x8000);
            for (int j = 0; j < buffer2.Length; j++) SetByteAt(j, buffer2[j]);
            buffer2 = null;
        }
        else
        {
            for (int k = 0; k < bytes.Length; k++)
            {
                buffer2[(int) ((IntPtr) (num + k))] = bytes[k];
            }
            //this.byte_0 = new byte[buffer2.Length];
            SetByteSize(buffer2.Length);
            for (int m = 0; m < buffer2.Length; m++) SetByteAt(m, buffer2[m]);
            buffer2 = null;
        }*/
    }

    public string method_88_GetComments()
    {
        UTF8Encoding encoding = new UTF8Encoding();
        if ((GetByteLenght() - 0x8000) <= 0)
        {
            string Newpath = Path.GetDirectoryName(this.method_25_GetFilename()) + @"\" + Path.GetFileName(this.method_25_GetFilename()).Substring(0, Path.GetFileName(this.method_25_GetFilename()).Length - 4) + ".comment";
            if (File.Exists(Newpath))
            {
                return File.ReadAllText(Newpath);
            }
            else
            {
                return "";
            }
        }
        byte[] bytes = new byte[GetByteLenght() - 0x8000];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = GetByteAt(0x8000 + i);
        }
        return encoding.GetString(bytes);
    }

    public void method_9(TableOverlay tableOverlay_1)
    {
        this.tableOverlay_0 = tableOverlay_1;
    }

    private void ShowConvert(string Type)
    {
        if (MessageBox.Show(Form.ActiveForm, "This is a " + Type + " file" + Environment.NewLine + "Do you want to convert it into BMtune?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
        {
            frmConvert ConvertX = new frmConvert(ref this.Class18_0, Type);
            DialogResult Result = ConvertX.ShowDialog();
            ConvertX.Dispose();
            ConvertX = null;
            if (Result == DialogResult.OK)
            {
                //if (Type == "eCtune") ConvertBaserom("3.3.3");
                if (Type == "eCtune") ConvertBaserom("eCtune");
                LoadBMtune();
            }
        }
        else
        {
            this.SetFileLoaded(false);
            //this.byte_0 = null;
            SetByteNull();
            this.method_24(null);
        }
    }

    private bool TryPass()
    {
        bool Protected = true;
        bool Locked = true;
        if (Protected) MessageBox.Show(Form.ActiveForm, "File are protected" + Environment.NewLine + "Requesting Password", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        while (Protected && Locked)
        {
            //Try with setting password first
            if (class10_settings_0.Password != "" && PasswordMatch())
            {
                MessageBox.Show(Form.ActiveForm, "Password found in Settings are Matching the file Password!", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Protected = false;
            }

            //If still protected, then perform manually password (password settings doesnt match)
            if (Protected)
            {

                this.frmPassword_0 = new frmPassword();
                this.frmPassword_0.method_0(ref this.Class18_0);
                this.frmPassword_0.ShowDialog();
                if (this.frmPassword_0 != null)
                {
                    this.frmPassword_0.Dispose();
                    this.frmPassword_0 = null;
                }

                if (PasswordMatch())
                {
                    this.class10_settings_0.Protect = true;
                    Protected = false;
                }
                else
                {
                    this.class10_settings_0.Password = "";
                    if (MessageBox.Show(Form.ActiveForm, "Bad Password!" + Environment.NewLine + "Do you want to retry?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
                        Locked = false;
                }
            }
        }

        return Protected;
    }

    public void method_90()
    {
        ConvertedToStable = false;

        this.method_65();

        //Convert 64kb file to 32kb
        if (GetByteLenght() < 1048576)
        {
            if (GetByteLenght() == 65535 || GetByteLenght() == 65536)
            {
                if (MessageBox.Show(Form.ActiveForm, "This is a 64kb file!" + Environment.NewLine + "Do you want to open the 32kb zone in the .bin?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    bool DataFound = false;
                    if (this.GetByteAt(0x0L) != 0xff)
                    {
                        DataFound = true;

                        byte[] BufferBinn = new byte[32768];
                        for (int i = 0; i < BufferBinn.Length; i++) BufferBinn[i] = this.GetByteAt(i);
                        this.SetByteNull();
                        this.SetAllByte(BufferBinn);
                    }
                    else if (this.GetByteAt(0x8000L) != 0xff)
                    {
                        DataFound = true;

                        byte[] BufferBinn = new byte[32768];
                        for (int i = 0; i < BufferBinn.Length; i++) BufferBinn[i] = this.GetByteAt(i + 0x8000L);
                        this.SetByteNull();
                        this.SetAllByte(BufferBinn);
                    }

                    if (!DataFound)
                    {
                        MessageBox.Show(Form.ActiveForm, "Cannot convert to 32kb .bin!" + Environment.NewLine + "No Data found at 0x0000 or 0x8000", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            // Load eCt Files
            if ((this.method_152(0x7fefL) == 0x4365L) && (this.method_152(0x7ff1L) == 0xa974L) && (this.GetByteAt(0x7ff7L) == 0) && (this.GetByteAt(0x7ff8L) == 0))
            {
                ShowConvert("eCtune");
            }
            // Load Crome Gold Files
            else if (this.GetByteAt(528) == 137 && this.GetByteAt(529) == 0xc6 && this.GetByteAt(530) == 0xab)
            {
                ShowConvert("Crome Gold");
            }
            // Load Crome P28 Files
            else if (this.GetByteAt(528) == 212 && this.GetByteAt(529) == 0x1a && this.GetByteAt(530) == 0x02)
            {
                ShowConvert("Crome P28");
            }
            // Load Crome P30 Files
            else if (this.GetByteAt(528) == 0x2e && this.GetByteAt(529) == 0xf9 && this.GetByteAt(530) == 0x7d)
            {
                ShowConvert("Crome P30");
            }
            // Load Crome P72 Files
            else if (this.GetByteAt(528) == 228 && this.GetByteAt(529) == 0xf8 && this.GetByteAt(530) == 0xa2)
            {
                ShowConvert("Crome P72");
            }
            // Load Crome P13 Files
            else if ((this.GetByteAt(528) == 0x29 && this.GetByteAt(529) == 0x0f && this.GetByteAt(530) == 0xc9) ||
                     (this.GetByteAt(528) == 0xc4 && this.GetByteAt(529) == 0xaa && this.GetByteAt(530) == 0x98))
            {
                ShowConvert("Crome P13");
            }
            //Load Neptune Files
            else if (this.GetByteAt(528) == 16 && this.GetByteAt(529) == 0x8a && this.GetByteAt(530) == 0xc4)
            {
                ShowConvert("Neptune");
            }

            //####################################################
            //Load HTS Files  (tie, tiE, ple)
            /*if (((this.GetByteAt(0x7fffL) != 0x65) && (((this.GetByteAt(0x7ffdL) != 0x49) || (this.GetByteAt(0x7ffeL) != 0x54)) || (this.GetByteAt(0x7fffL) != 0x45)))
                && (((this.GetByteAt(0x7ffdL) != 0x70) || (this.GetByteAt(0x7ffeL) != 0x6c)) || (this.GetByteAt(0x7fffL) != 0x65)))
            {
            }
            else
            {
                this.method_238();
                this.method_226();
                this.method_239();
                this.method_239();
            }*/

            //####################################################
            //Load BMTune Files
            //48 4F 4E 44 41 54 55 4E 45 53 55 49 54 45 --> HONDATUNESUITE
            //28 43 29 32 30 32 30 20 42 4D 54 75 6E 65 --> (C)2020 BMTune

            if ((this.GetByteAt(0x7ffaL) == 0x42 && this.GetByteAt(0x7ffbL) == 0x4d && this.GetByteAt(0x7ffcL) == 0x54 && this.GetByteAt(0x7ffdL) == 0x75 && this.GetByteAt(0x7ffeL) == 0x6e && this.GetByteAt(0x7fffL) == 0x65) ||
                (this.GetByteAt(0x7ffaL) == 0x45 && this.GetByteAt(0x7ffbL) == 0x53 && this.GetByteAt(0x7ffcL) == 0x55 && this.GetByteAt(0x7ffdL) == 0x49 && this.GetByteAt(0x7ffeL) == 0x54 && this.GetByteAt(0x7fffL) == 0x45))
            {
                Converting = true;

                if (this.GetByteAt(0x7ff1L) != 0xff)
                {
                    GetRomVersion();

                    if (this.GetByteAt(0x7ffaL) == 0x45 && this.GetByteAt(0x7ffbL) == 0x53 && this.GetByteAt(0x7ffcL) == 0x55 && this.GetByteAt(0x7ffdL) == 0x49 && this.GetByteAt(0x7ffeL) == 0x54 && this.GetByteAt(0x7fffL) == 0x45)
                    {
                        if (MessageBox.Show(Form.ActiveForm, "This is an HTS File!" + Environment.NewLine + "HTS are made from the stolen source code of BMTune 1.72" + Environment.NewLine + "Thank you for converting this file back to BMTune!", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            this.SetByteAt(0x61dfL, this.GetByteAt(0x5f74L));

                            this.SetByteAt(this.class13_u_0.long_4PASS, 0xff);
                            this.SetByteAt(this.class13_u_0.long_4PASS + 1, 0xff);

                            SetBMTuneCopyrightEnding();
                        }
                    }

                    //Update Rom
                    if (!OpenSilentBRom)
                    {
                        if (RomVersion < CurrentVersion)
                        {
                            string FVersion = RomVersion.ToString().Substring(0, 1) + "." + RomVersion.ToString().Substring(1, 1) + RomVersion.ToString().Substring(2, 1);
                            string BMVersion = CurrentVersion.ToString().Substring(0, 1) + "." + CurrentVersion.ToString().Substring(1, 1) + CurrentVersion.ToString().Substring(2, 1);

                            if (MessageBox.Show(Form.ActiveForm, "Old baserom version detected!" + Environment.NewLine + "Baserom opened is version " + FVersion + Environment.NewLine + "Current baserom version " + BMVersion + Environment.NewLine + "Do you want to upgrade to v1." + Stable_Version_LAST.ToString("00") + "?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                ConvertBaseromToLastStable();
                        }

                        //unstable baserom
                        //LoadBinaryFiles();
                        if (!Binary_Files_0.IsStable(RomVersion - 100))
                        {
                            if (MessageBox.Show(Form.ActiveForm, "This baserom version can be UNSTABLE!" + Environment.NewLine + Environment.NewLine + "Do you want to convert to the last stable baserom(" + "v1." + Stable_Version_LAST.ToString("00") + ")?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                ConvertBaseromToLastStable();
                        }
                        //CloseBinaryFiles();
                    }

                    //Get Protection
                    bool Protected = false;
                    GetPWLocation(RomVersion);
                    int PWLen = GetPWLenght(RomVersion);
                    if (PWLen > 0)
                    {
                        //###############
                        //Reset Bad PW for ROM 1.15
                        ResetBadPW();
                        //###############

                        for (int i = 0; i < PWLen; i++)
                        {
                            if (this.GetByteAt(this.class13_u_0.long_4PASS + i) != 0xff && this.GetByteAt(this.class13_u_0.long_4PASS + i) != 0x00) Protected = true;
                        }
                    }
                    if (Protected) Protected = TryPass();
                    if (!Protected) LoadBMtune();
                }
                else if (this.GetByteAt(0x7ff1L) == 0xff)
                {
                    //convert free binary to registered
                    if (MessageBox.Show(Form.ActiveForm, "Free baserom version detected!" + Environment.NewLine + "Do you want to upgrade to v1." + Stable_Version_LAST.ToString("00") + "?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        ConvertBaseromToLastStable();

                    LoadBMtune();
                }

                Converting = false;
            }
            else
            {
                this.method_68();
            }

            //Is Loaded ?
            if (!this.method_30_HasFileLoadedInBMTune())
            {
                /*DialogResult result = MessageBox.Show(Form.ActiveForm, "Do you want to open with the OBD0 File Editor?", "BMTune", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                 if (result == DialogResult.Yes)
                 {
                     this.method_LoadOBD0(this.method_25_GetFilename());
                 }
                 else
                 {*/
                BinLoadedForSaving = false;
                DialogResult result = MessageBox.Show(Form.ActiveForm, "Unale to open file" + Environment.NewLine + "Do you want to open the file only for saving accessibility?", "BMTune", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BinLoadedForSaving = true;
                }
                else
                {
                    string ThisError = GetFileType();
                    MessageBox.Show(Form.ActiveForm, ThisError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.method_24(null);
                }

                this.SetFileLoaded(false);
                //}
            }
            else
            {
                if (this.bool_0)
                {
                    string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\tmp.bmc";
                    FileInfo info = new FileInfo(fileName);
                    if (info.Exists)
                    {
                        this.method_75(fileName, true, 1);
                    }
                    info = new FileInfo("");
                    this.method_24(info.Name);
                    this.method_26_SetFilename("");
                    this.method_52();
                    this.bool_0 = false;
                }
            }
        }
        else
        {
            MessageBox.Show(Form.ActiveForm, "This file is too big to open with BMTune", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            /*if (!VWBinLoaded)
            {
                //DialogResult result = MessageBox.Show(Form.ActiveForm, "Do you want to open with the Universal bin file Editor?" + Environment.NewLine + "Clic on No to open as Kserie File", "BMTune", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                DialogResult result = MessageBox.Show(Form.ActiveForm, "Do you want to open the file with the Universal bin file Editor?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.method_LoadVWTune(this.method_25_GetFilename());
                }
                //if (result == DialogResult.No)
                //{
                //    //Open K-Serie file
                //    KBinLoaded = true;
                //    Bin2KHTS Bin2KHTS_0 = new Bin2KHTS();
                //    Bin2KHTS_0.string_0 = this.method_25_GetFilename();
                //    Bin2KHTS_0.ShowDialog();
                //}
            }*/
        }
    }

    private void ResetBadPW()
    {
        GetPWLocation(RomVersion);
        int PWLen = GetPWLenght(RomVersion);
        if (PWLen > 0)
        {
            //###############
            //Reset Bad PW for ROM 1.15
            if (RomVersion == 115)
            {
                bool SameData = true;
                for (int i = 0; i < PWLen; i++)
                {
                    if (this.GetByteAt(this.class13_u_0.long_4PASS + i) != this.GetByteAt(0x5F88 + i)) SameData = false;
                }
                //Reset Password Data is Same
                if (SameData)
                {
                    for (int i = 0; i < PWLen; i++) this.SetByteAt(this.class13_u_0.long_4PASS + i, 0xff);
                }
            }
            //###############
        }
    }

    public void LoadBinaryFiles()
    {
        /*if (Binary_Files_0 == null)
        {
            Binary_Files_0 = new Binary_Files();
            Binary_Files_0.Load(ref this.Class18_0);
        }
        else
        {
            Binary_Files_0.ReloadRoms();
        }*/
        
        if (Binary_Files_0 != null) Binary_Files_0 = null;
        Binary_Files_0 = new Binary_Files();
        Binary_Files_0.Load(ref this.Class18_0);
    }

    /*public void method_238()
    {
        try
        {
            string s = ((int)this.GetByteAt(0x7fefL)).ToString() + ((int)this.GetByteAt(0x7ff0L)).ToString() + ((int)this.GetByteAt(0x7ff1L)).ToString();
            this.RomVersion = int.Parse(s);
        }
        catch (Exception exception)
        {
            string text1;
            if (exception != null)
            {
                text1 = exception.ToString();
            }
            else
            {
                Exception local1 = exception;
                text1 = null;
            }
            this.class17_0.frmMain_0.LogThis("Baserom Error Getting Version :\n" + text1);
        }
        //this.method_226();
        if (this.RomVersion < 100)
        {
            this.RomVersion = 100;
        }
        //this.method_227();
    }

    public void method_239()
    {
        this.method_238();
        Class14 class2 = new Class14();
        class2.method_0(ref this.class13_0);
        class2.method_1(this.RomVersion);
        class2 = null;
        if (this.RomVersion >= 0x6f)
        {
            this.method_236_HTSRomLoading();
        }
        this.SetFileLoaded(true);
    }*/

    public void method_236_HTSRomLoading()
    {
        /*this.method_235();
        Class14 class2 = new Class14();
        class2.method_0(ref this.class13_0);
        class2.method_1(this.RomVersion);
        class2 = null;
        this.method_241();
        this.SetByteAt(0x7ff2L, 0x48);
        this.SetByteAt(0x7ff3L, 0x4f);
        this.SetByteAt(0x7ff4L, 0x4e);
        this.SetByteAt(0x7ff5L, 0x44);
        this.SetByteAt(0x7ff6L, 0x41);
        this.SetByteAt(0x7ff7L, 0x54);
        this.SetByteAt(0x7ff8L, 0x55);
        this.SetByteAt(0x7ff9L, 0x4e);
        this.SetByteAt(0x7ffaL, 0x45);
        this.SetByteAt(0x7ffbL, 0x53);
        this.SetByteAt(0x7ffcL, 0x55);
        this.SetByteAt(0x7ffdL, 0x49);
        this.SetByteAt(0x7ffeL, 0x54);
        this.SetByteAt(0x7fffL, 0x45);
        if (this.RomVersion == 0x73)
        {
            this.method_237();
        }*/
        /*else if (this.RomVersion != 110)
        {
            if ((this.RomVersion == 0x71) || (this.RomVersion == 0x72))
            {
                MessageBox.Show("There are issues with this rom please export your settings/tables and import them into either 1.00/1.01/1.10/1.15 Rom");
            }
            else if ((this.RomVersion == 100) || (this.RomVersion == 0x65))
            {
                this.method_9();
            }
            else
            {
                MessageBox.Show("There are issues with this rom please export your settings/tables and import them into either 1.00/1.01/1.10/1.15 Rom");
            }
        }
        else
        {
            if (this.method_26(this.class13_u_0.long_306) >= 100) this.method_23(this.class13_u_0.long_306, 5);
            if (this.method_26(this.class13_u_0.long_307) >= 100) this.method_23(this.class13_u_0.long_307, 20);
            if (this.method_26(this.class13_u_0.long_308) >= 100) this.method_23(this.class13_u_0.long_308, 0x20);
            if (this.method_105(this.method_26(this.class13_u_0.long_309)) >= 241.0) this.method_27(this.class13_u_0.long_309, 0L);
            if (this.method_26(this.class13_u_0.long_310) >= 0xf1) this.method_23(this.class13_u_0.long_310, 0);
        }*/
    }

    public void CloseBinaryFiles()
    {
        if (Binary_Files_0 != null) Binary_Files_0 = null;
    }

    public void ConvertBaseromToLastStable()
    {
        ConvertedToStable = true;
        ConvertBaseromVersionToVersion(Stable_Version_LAST + 100);
    }

    public void ConvertBaserom(string Type)
    {
        //LoadBinaryFiles();
        Converting = true;
        if (Type == "3.3.3")
        {
            int CurrentI = 0;
            for (int i = 0; i < GetByteLenght(); i++)
            {
                if (i == 0) i = 0x5D10;
                if (i >= 0x5D10 && i < (0x5D10 + 128))
                {
                    SetByteAt(0x5ea6L + CurrentI, this.GetByteAt(0x5D10L + CurrentI));
                    SetByteAt(0x5D10L + CurrentI, Binary_Files_0.ThisBytesL[Stable_Version_LAST][0x5D10L + CurrentI]);
                    CurrentI++;
                    if (CurrentI >= 127) i += 350;
                }
            }
        }

        if (Type == "eCtune")
        {
            GetRomVersion();
            int PWLen = GetPWLenght(RomVersion);
            GetPWLocation(RomVersion);
            if (PWLen > 0)
            {
                for (int i = 0; i < PWLen; i++)
                {
                    if (this.GetByteAt(this.class13_u_0.long_4PASS + i) != 0xff) SetByteAt(this.class13_u_0.long_4PASS + i, 0xff);
                }
            }
        }

        ConvertBaseromToLastStable();
        //CloseBinaryFiles();
    }

    public void GetPWLocation(int TVersion)
    {
        long ReturningLocation = 0x5ea6L;
        if (TVersion <= 109) ReturningLocation = 0x5ea6L;
        if (TVersion == 110) ReturningLocation = 0x5f01L;
        if (TVersion >= 111 && TVersion < 113) ReturningLocation = 0x5ed1L;
        if (TVersion == 113) ReturningLocation = 0x5f04L;
        if (TVersion >= 114) ReturningLocation = 0x5f74L;
        if (TVersion >= 116) ReturningLocation = 0x6066L;

        this.class13_u_0.long_4PASS = ReturningLocation;
        //if (LoadToC10) this.class13_u_0.long_4PASS = ReturningLocation;
        //return ReturningLocation;
    }

    public int GetPWLenght(int TVersion)
    {
        if (TVersion <= 109) return 64;
        if (TVersion == 110) return 16;
        if (TVersion >= 111 && TVersion < 113) return 16;
        if (TVersion == 113) return 0;
        if (TVersion >= 114) return 16;

        return 0;
    }

    private byte[] GetPWBuffer(int fromlong)
    {
        GetPWLocation(fromlong);
        int PLenght = 16;
        byte[] bufferPass = new byte[PLenght];
        for (int i = 0; i < bufferPass.Length; i++) bufferPass[i] = GetByteAt(this.class13_u_0.long_4PASS + i);

        return bufferPass;
    }

    public void ConvertBaseromVersionToVersion(int TVersion)
    {
        LoadBinaryFiles();
        int OldVersion = RomVersion;

        //#################################################
        if (OldVersion >= 116 && TVersion <= 115)
        {
            string FromV = "V1." + (OldVersion - 100);
            string ToV = "V1." + (TVersion - 100);
            if (MessageBox.Show(Form.ActiveForm, "We can't convert baserom " + FromV + " to " + ToV + "!" + Environment.NewLine + "You should create a new baserom " + ToV + " and manually copy parameters", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
            {
                return;
            }
        }
        if (Path.GetFileName(this.method_25_GetFilename()) != "New Baserom")
        {
            if (OldVersion <= 115 && TVersion >= 116)
            {
                //string FromV = "V1." + (OldVersion - 100);
                string ToV = "V1." + (TVersion - 100);
                if (MessageBox.Show(Form.ActiveForm, "If you convert to baserom " + ToV + ", you won't be able to convert" + Environment.NewLine + "back to baserom 1.15 or an older version." + Environment.NewLine + "Are you sure you want to continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
                {
                    return;
                }
            }
        }
        //#################################################

        //Converting 1.13 and less to 1.15 before 1.16
        if (OldVersion < 114 && TVersion >= 116) ConvertBrmVToV(115);    //Convert to 1.15 before any greater version
        if (OldVersion < 115 && TVersion >= 117) ConvertBrmVToV(116);    //Convert to 1.16 before any greater version
        if (OldVersion < 116 && TVersion >= 118) ConvertBrmVToV(117);    //Convert to 1.17 before any greater version
        if (OldVersion < 117 && TVersion >= 119) ConvertBrmVToV(118);    //Convert to 1.18 before any greater version
        if (OldVersion < 118 && TVersion >= 120) ConvertBrmVToV(119);    //Convert to 1.19 before any greater version
        if (OldVersion < 119 && TVersion >= 120) ConvertBrmVToV(120);    //Convert to 1.20 before any greater version

        //Converting 1.16 and more to 1.15 before 1.13 or less
        if (OldVersion >= 116 && TVersion < 114) ConvertBrmVToV(115);

        //Convert to Actual Version
        ConvertBrmVToV(TVersion);


        //###############
        //Reset Bad PW for ROM 1.13 to 1.15
        if (OldVersion == 113 && TVersion >= 116)
        {
            GetPWLocation(TVersion);
            for (int i = 0; i < 16; i++)
            {
                SetByteAt(this.class13_u_0.long_4PASS + i, 0xff);
            }
        }
        //###############
        //Reset Bad PW for ROM 1.15
        ResetBadPW();
        //###############
        //Reset Possible Corrupted Bytes when converting to rom 1.16
        if (TVersion == 116)
        {
            byte[] CorrectedBytesArray1 = new byte[] {0xF5, 0x7A, 0xD6, 0x7B, 0xC6, 0x7A, 0xF5, 0x59, 0xD6, 0x5F };
            int CurrentByteDoing1 = 0;
            for (int i = 0x3647; i < 0x3647 + 10; i++)
            {
                SetByteAt(i, CorrectedBytesArray1[CurrentByteDoing1]);
                CurrentByteDoing1++;
            }

            SetByteAt(0x3918, 0xDD);
            SetByteAt(0x3919, 0x16);
            SetByteAt(0x391A, 0x1C);

            SetByteAt(0x393B, 0xDD);
            SetByteAt(0x393C, 0x16);
            SetByteAt(0x393D, 0x14);

            byte[] CorrectedBytesArray2 = new byte[] {0xF0, 0x39, 0x04, 0x60, 0xC1, 0x60, 0x32, 0x81, 0x49, 0x90, 0x15, 0xD0, 0x3C, 0x04, 0x01, 0x62,
                                                    0xE6, 0x00, 0xE2, 0xCE, 0x04, 0x32, 0xC7, 0x5B, 0x01, 0x32, 0xC7, 0x5B, 0x42, 0x01, 0xFF, 0xFF,
                                                    0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};

            int CurrentByteDoing2 = 0;
            for (int i = 0x5f87; i < 0x5f87 + 41; i++)
            {
                SetByteAt(i, CorrectedBytesArray2[CurrentByteDoing2]);
                CurrentByteDoing2++;
            }
        }
        //###############

        GlitchTestingTimer = 0;
    }


    private void ConvertBrmVToV(int TVersion)
    {
        Converting = true;

        int OldVersion = RomVersion;
        int MaxVersion = 100 + (Binary_Files_0.ThisBytesL.Count - 1);

        int PLenght = 16;
        byte[] bufferPass = new byte[PLenght];
        for (int i = 0; i < bufferPass.Length; i++) bufferPass[i] = 0xff;
        bufferPass = GetPWBuffer(OldVersion);

        string VersionStr = TVersion.ToString();
        this.class17_0.frmMain_0.LogThis("Converting Baserom to version:" + VersionStr.Substring(0, 1) + "." + VersionStr.Substring(1));

        //Only convert if new and old version are greater than 100 and lower than max version number
        if ((TVersion >= 100 && TVersion <= MaxVersion)
            && (OldVersion >= 100 && OldVersion <= MaxVersion))
        {
            byte[] buffer = new byte[] { };
            if (TVersion >= 102 && TVersion < 108)
            {
                //Load Ignition Cut Mod for Rom 1.02 to 1.08
                if (this.class10_settings_0.ICutModInstall == "")
                {
                    frmIgnCutModWarning frmIgnCutModWarning_0 = new frmIgnCutModWarning(ref this.Class18_0);
                    DialogResult result = frmIgnCutModWarning_0.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (frmIgnCutModWarning_0.InstallMod) buffer = Binary_Files_0.ThisBytesL[TVersion - 100];
                        else buffer = Binary_Files_0.ThisBytesL_NOMOD[TVersion - 100];
                    }
                }
                else if (this.class10_settings_0.ICutModInstall == "false") buffer = Binary_Files_0.ThisBytesL_NOMOD[TVersion - 100];
                else if (this.class10_settings_0.ICutModInstall == "true") buffer = Binary_Files_0.ThisBytesL[TVersion - 100];
            }
            else
            {
                //Load Current ROM Binaries
                buffer = Binary_Files_0.ThisBytesL[TVersion - 100];
            }

            if (OldVersion < 114 && (TVersion == 114 || TVersion == 115))
            {
                //for (int i = 0x5f05; i < 0x5f87; i++) buffer[i] = Binary_Files_0.ThisBytesL[TVersion - 100][i];

                for (int i = 0x5f05; i < GetByteLenght(); i++)
                {
                    if (i < 0x5fb3) buffer[i + 132] = GetByteAt(i);                 //from old 0x5f05++ calibration to 0x5f89++
                    if (i >= 0x5fc9 && i < 0x6057) buffer[i + 110] = GetByteAt(i);  //from old 0x5fc9++ calibration to 0x6037++
                    if (i >= 0x60c5) i = GetByteLenght() + 1;                       //return break
                }
            }

            if ((OldVersion == 114 || OldVersion == 115) && TVersion < 114)
            {
                for (int i = 0x5f05; i < GetByteLenght(); i++)
                {
                    if (i < 0x5fb3) buffer[i] = GetByteAt(i + 132);
                    if (i >= 0x5fc9 && i < 0x6057) buffer[i] = GetByteAt(i + 110);
                    if (i >= 0x60c5) i = GetByteLenght() + 1;
                }
            }
            //########################################################
            if ((OldVersion == 114 || OldVersion == 115) && TVersion >= 116)
            {
                //606e = new calibration area
                //for (int i = 0x5f05; i < 0x606e - 1; i++) buffer[i] = Binary_Files_0.ThisBytesL[TVersion - 100][i]; //edit this location

                for (int i = 0x5f88; i < GetByteLenght(); i++)
                {
                    if (i < 0x636e) buffer[i + 48 + 12 + 28 + 108 + 11 + 78] = GetByteAt(i);
                    if (i >= 0x639e && i < 0x647d) buffer[i + 12 + 28 + 108 + 11 + 78] = GetByteAt(i);
                    if (i >= 0x648a && i < 0x6557) buffer[i + 28 + 108 + 11 + 78] = GetByteAt(i);
                    if (i >= 0x6573 && i < 0x6607) buffer[i + 108 + 11 + 78] = GetByteAt(i);
                    if (i >= 0x664f && i < 0x67cf) buffer[i + 11 + 78] = GetByteAt(i);
                    if (i >= 0x67da && i < 0x687d) buffer[i + 78] = GetByteAt(i);
                    //if (i >= 0x6895 && i < 0x68cb) buffer[i + 36] = GetByteAt(i);
                    if (i >= 0x68cb) i = GetByteLenght() + 1;                       //return break
                }
            }
            if (OldVersion >= 116 && (TVersion == 114 || TVersion == 115))
            {
                for (int i = 0x5f88; i < GetByteLenght(); i++)
                {
                    if (i < 0x636e) buffer[i] = GetByteAt(i + 48 + 12 + 28 + 108 + 11 + 78);
                    if (i >= 0x639e && i < 0x647d) buffer[i] = GetByteAt(i + 12 + 28 + 108 + 11 + 78);
                    if (i >= 0x648a && i < 0x6557) buffer[i] = GetByteAt(i + 28 + 108 + 11 + 78);
                    if (i >= 0x6573 && i < 0x6607) buffer[i] = GetByteAt(i + 108 + 11 + 78);
                    if (i >= 0x664f && i < 0x67cf) buffer[i] = GetByteAt(i + 11 + 78);
                    if (i >= 0x67da && i < 0x687d) buffer[i] = GetByteAt(i + 78);
                    //if (i >= 0x6895 && i < 0x68cb) buffer[i] = GetByteAt(i + 36);
                    if (i >= 0x68cb) i = GetByteLenght() + 1;                       //return break
                }
            }

            //#############################
            //set all bytes from new baserom
            long MostLastestTableLocation = 0x5f05L;
            if ((OldVersion < 114 && TVersion >= 114) || (OldVersion >= 114 && TVersion < 114)) MostLastestTableLocation = 0x60c5L;
            if (OldVersion >= 114 && TVersion >= 114) MostLastestTableLocation = 0x5f80L;
            if ((OldVersion == 114 || OldVersion == 115) && TVersion >= 116) MostLastestTableLocation = 0x68cbL;
            if (OldVersion >= 116 && (TVersion == 114 || TVersion == 115)) MostLastestTableLocation = 0x5f80L;
            if (OldVersion >= 116 && TVersion >= 116) MostLastestTableLocation = 0x606eL;
            for (int i = 0; i < GetByteLenght(); i++)
            {
                if (i < MostLastestTableLocation) SetByteAt(i, buffer[i]);
                else i = GetByteLenght() + 1;
            }
            //#############################
            RomVersion = TVersion;

            ResetBaseromParameters();

            //Rev Limiter Extra Mod and Time Mod
            /*if (OldVersion <= 114 && RomVersion >= 114)
            {
                //this.method_151(this.class13_u_0.long_423, (long)(60f * 4f));   //60FV
                if (this.GetByteAt(this.class13_u_0.long_424) == 0xff) this.SetByteAt(this.class13_u_0.long_424, (byte)((-6 + 6) * 4f));   //-6 ign retard

                if (this.GetByteAt(this.class13_u_0.long_420) == 0xff) this.SetByteAt(this.class13_u_0.long_420, (byte)(70 / 10)); //70ms
                if (this.GetByteAt(this.class13_u_0.long_421) == 0xff) this.SetByteAt(this.class13_u_0.long_421, (byte)(70 / 10)); //70ms
                if (this.GetByteAt(this.class13_u_0.long_422) == 0xff) this.SetByteAt(this.class13_u_0.long_422, (byte)(70 / 10)); //70ms
            }*/


            //flex fuel cranking compasation
            if (OldVersion <= 115 && RomVersion >= 116)
            {
                for (int i = 0; i < Binary_Files_0.ThisBytes116_Reload.Length; i++) SetByteAt(this.class13_u_0.long_463 + i, Binary_Files_0.ThisBytes116_Reload[i]);

                //CPR Enable SYNC on ALT-Control
                this.method_149_SetByte(this.class13_u_0.long_521, 0);
            }

            //rev limiter cutting type input (rom 1.18)
            if (OldVersion < 118 && RomVersion >= 118)
            {
                SetByteAt(this.class13_u_0.long_520, 0x03);
                SetByteAt(this.class13_u_0.long_71, 0x00);  //Rev Limiter input... set to 0x80 for 'Always On'
                SetByteAt(this.class13_u_0.long_72, 0x00);  //Invert Input ... set to 0xff for inverted
            }
            //rev limiter cutting type (rom 1.18)
            if (OldVersion >= 118 && RomVersion < 118)
            {
                SetByteAt(this.class13_u_0.long_71, 0x00);  //fuelcut enabled
                SetByteAt(this.class13_u_0.long_72, 0x00);  //igncut disabled
            }

            //CEL Fix rom 1.20, 1.21++
            if (OldVersion < 119 && (RomVersion == 120 || RomVersion == 121))
            {
                SetByteAt(0x5E97L, 0xCA);
            }

            //corrupted reference fix
            if (OldVersion < 120 && RomVersion >= 121)
            {
                SetByteAt(0x608fL, 0x00);
                SetByteAt(0x608fL+1, 0x5a);
            }

            //recheck pass if its same as before
            byte[] bufferPass2 = new byte[PLenght];
            bufferPass2 = GetPWBuffer(TVersion);

            bool SamePassAsBefore = true;
            for (int i = 0; i < bufferPass.Length; i++)
            {
                if (bufferPass[i] != bufferPass2[i]) SamePassAsBefore = false;
            }

            if (!SamePassAsBefore)
            {
                for (int i = 0; i < bufferPass.Length; i++) SetByteAt(this.class13_u_0.long_4PASS + i, bufferPass[i]);
            }
        }

        Converting = false;
        //CloseBinaryFiles();
    }

    public void ReloadAntitheft()
    {
        this.method_149_SetByte(this.class13_u_0.long_430, 0);
        this.method_149_SetByte(this.class13_u_0.long_431, 0);
        this.method_149_SetByte(this.class13_u_0.long_432, 0);
        this.method_149_SetByte(this.class13_u_0.long_433, 0);
        this.method_149_SetByte(this.class13_u_0.long_434, 0);

        //this.method_149(this.class13_0.long_435, 0);
        //this.method_149(this.class13_0.long_436, 0x4a);
        //this.method_149(this.class13_0.long_437, 0x7d);

        this.method_151(this.class13_u_0.long_438, this.method_219(2500));
        this.method_149_SetByte(this.class13_u_0.long_439, 0);
    }

    private void SetBMTuneCopyrightEnding()
    {
        //Set '(C)2021 BMTune'
        SetByteAt(0x7ff2L, 0x28); SetByteAt(0x7ff3L, 0x43); SetByteAt(0x7ff4L, 0x29);   //(C)
        SetByteAt(0x7ff5L, 0x32); SetByteAt(0x7ff6L, 0x30); SetByteAt(0x7ff7L, 0x32); SetByteAt(0x7ff8L, 0x31); //2021
        SetByteAt(0x7ff9L, 0x20);       // 
        SetByteAt(0x7ffaL, 0x42);       //B
        SetByteAt(0x7ffbL, 0x4D);       //M
        SetByteAt(0x7ffcL, 0x54);       //T
        SetByteAt(0x7ffdL, 0x75);       //u
        SetByteAt(0x7ffeL, 0x6E);       //n
        SetByteAt(0x7fffL, 0x65);       //e
    }

    public void ResetBaseromParameters()
    {
        //Set Version
        SetByteAt(0x7fefL, (byte)int.Parse(RomVersion.ToString().Substring(0, 1)));
        SetByteAt(0x7ff0L, (byte)int.Parse(RomVersion.ToString().Substring(1, 1)));
        SetByteAt(0x7ff1L, (byte)int.Parse(RomVersion.ToString().Substring(2, 1)));
        SetBMTuneCopyrightEnding();

        //Load parameters Long (area) locations
        //method_145();
        this.LastLocationLoaded = -1;
        class32_Locations_0.ResetAddresseForVersion(RomVersion);

        ResetInjector();
        //InstallCYPMod();

        //Reload Ign Cut Delay
        if (RomVersion >= 103 && GetByteAt(this.class13_u_0.long_420) >= 100) SetByteAt(this.class13_u_0.long_420, 0x07);

        //Reload Antitheft
        if (RomVersion >= 104)
        {
            if (this.GetByteAt(this.class13_u_0.long_430) == 0xff) this.ReloadAntitheft();
            if (this.GetByteAt(this.class13_u_0.long_431) == 0xff) this.ReloadAntitheft();
            if (this.GetByteAt(this.class13_u_0.long_432) == 0xff) this.ReloadAntitheft();
            if (this.GetByteAt(this.class13_u_0.long_433) == 0xff) this.ReloadAntitheft();
            if (this.GetByteAt(this.class13_u_0.long_434) == 0xff) this.ReloadAntitheft();
            //if (this.method_150(this.class13_0.long_436) == 0xff && this.method_150(this.class13_0.long_437) == 0xff) this.ReloadAntitheft();
        }

        if (RomVersion >= 109)
        {
            //if (GetByteAt(this.class13_u_0.long_420) >= 100) this.method_149_SetByte(this.class13_u_0.long_420, 0x07); //ign cut delay
            if (GetByteAt(this.class13_u_0.long_421) >= 100) this.method_149_SetByte(this.class13_u_0.long_421, 0x07); //ign cut ftl delay
            if (GetByteAt(this.class13_u_0.long_422) >= 100) this.method_149_SetByte(this.class13_u_0.long_422, 0x07); //ign cut fts delay
            if (this.method_223((int)this.method_152(this.class13_u_0.long_423)) >= 241) this.method_151(this.class13_u_0.long_423, (long)(60f * 4f)); //ign cut Enrichment 100FV
            if (GetByteAt(this.class13_u_0.long_424) >= 241) this.method_149_SetByte(this.class13_u_0.long_424, 0x00); //ign cut Retard
        }
        if (RomVersion >= 111)
        {
            if (GetByteAt(this.class13_u_0.long_461) == 0xff && GetByteAt(this.class13_u_0.long_461 + 1) == 0xff && GetByteAt(this.class13_u_0.long_461 + 2) == 0xff)
            {
                //reload flex fuel tables
                //LoadBinaryFiles();
                for (int i = 0; i < Binary_Files_0.ThisBytes109_Reload.Length; i++) SetByteAt(this.class13_u_0.long_461 + i, Binary_Files_0.ThisBytes109_Reload[i]);
                //CloseBinaryFiles();

                //flex fuel input
                this.method_149_SetByte(this.class13_u_0.long_466, 0);

                //flex fuel table
                if (this.class13_u_0.long_461 != 0L) for (int i = 0; i < 6; i++) this.method_151(this.class13_u_0.long_461 + (i * 3) + 1L, (long)0f);
                //if (this.class13_u_0.long_463 != 0L) for (int i = 0; i < 6; i++) this.method_151(this.class13_u_0.long_463 + (i * 3) + 1L, (long)0f);
                if (this.class13_u_0.long_464 != 0L) for (int i = 0; i < 6; i++) this.method_149_SetByte(this.class13_u_0.long_464 + (i * 2) + 1L, (byte)0f);
            }
        }
        if (RomVersion >= 116)
        {
            //COP / CPR Coil on Plugs Retrofit options disabled
            if (GetByteAt(this.class13_u_0.long_521) != 0xff && GetByteAt(this.class13_u_0.long_521) != 0x00) this.method_149_SetByte(this.class13_u_0.long_521, 0);
            if (GetByteAt(this.class13_u_0.long_522) != 0xff && GetByteAt(this.class13_u_0.long_522) != 0x00) this.method_149_SetByte(this.class13_u_0.long_522, 0);
            if (GetByteAt(this.class13_u_0.long_523) != 0xff && GetByteAt(this.class13_u_0.long_523) != 0x00) this.method_149_SetByte(this.class13_u_0.long_523, 0);

            //Ign Cut on decel Disabled
            //if (GetByteAt(this.class13_u_0.long_520) != 0xff && GetByteAt(this.class13_u_0.long_520) != 0x00) this.method_149_SetByte(this.class13_u_0.long_520, 0);
        }
        if (RomVersion == 120 || RomVersion == 121)
        {
            if (GetByteAt(0x1508L) == 0x00) this.method_149_SetByte(0x1508L, 0x0f); //CPR fix for rom 1.20
            this.method_149_SetByte(0x5E97L, 0xCA); //CEL Light Fix
        }

        //this.method_149_SetByte(this.class13_u_0.long_404, this.method_230(65));  //65 degree ECT
        //this.method_149_SetByte(this.class13_u_0.long_406, this.method_230(25));  //25 degree IAT
        //this.method_149_SetByte(this.class13_u_0.long_400, this.method_233(15));  //15 km/h VSS

        TryFixECTBug();
    }

    private void TryFixECTBug()
    {
        //0x77 or 0xa3 (0xa3 has NOT ECT Disable function) equal 0x0c
        //0x77 or 0xd9 (0xa3 has NOT IAT Disable function) equal 0x13
        //0xce or 0xdb (0xdb has NOT VSS Disable function) equal 0x1f **VSS check at +1**

        if (this.class13_u_0.long_403 != 0xf005L)
        {
            if (this.GetByteAt(this.class13_u_0.long_403 - 1) == 0x77 && this.GetByteAt(this.class13_u_0.long_403) != 0x00 && this.GetByteAt(this.class13_u_0.long_403) != 0xff) this.method_149_SetByte(this.class13_u_0.long_403, 0x00);
            if (this.GetByteAt(this.class13_u_0.long_403 - 1) == 0xa3 && this.GetByteAt(this.class13_u_0.long_403) != 0x0c) this.method_149_SetByte(this.class13_u_0.long_403, 0x0c);
        }

        if (this.class13_u_0.long_405 != 0xf001L)
        {
            if (this.GetByteAt(this.class13_u_0.long_405 - 1) == 0x77 && this.GetByteAt(this.class13_u_0.long_405) != 0x00 && this.GetByteAt(this.class13_u_0.long_405) != 0xff) this.method_149_SetByte(this.class13_u_0.long_405, 0x00);
            if (this.GetByteAt(this.class13_u_0.long_405 - 1) == 0xd9 && this.GetByteAt(this.class13_u_0.long_405) != 0x13) this.method_149_SetByte(this.class13_u_0.long_405, 0x13);

        }

        if (this.class13_u_0.long_401 != 0xf006L)
        {
            if (this.GetByteAt(this.class13_u_0.long_401 + 1) == 0xce && this.GetByteAt(this.class13_u_0.long_401) != 0x00 && this.GetByteAt(this.class13_u_0.long_401) != 0xff) this.method_149_SetByte(this.class13_u_0.long_401, 0x00);
            if (this.GetByteAt(this.class13_u_0.long_401 + 1) == 0xdb && this.GetByteAt(this.class13_u_0.long_401) != 0x1f) this.method_149_SetByte(this.class13_u_0.long_401, 0x1f);
        }
    }

    public void GetRomVersion()
    {
        if (this.GetByteAt(0x7ff1L) != 0xff)
        {
            try
            {
                string VStr = ((int)(this.GetByteAt(0x7fefL))).ToString() + ((int)(this.GetByteAt(0x7ff0L))).ToString() + ((int)(this.GetByteAt(0x7ff1L))).ToString();
                RomVersion = int.Parse(VStr);
            }
            catch (Exception message) {
                this.class17_0.frmMain_0.LogThis("Baserom Error Getting Version :" + Environment.NewLine + "" + message);
            }
        }
        else
        {
            RomVersion = 100;
        }

        //LoadBinaryFiles();
        if (RomVersion < 100) RomVersion = 100;
        if (RomVersion > Binary_Files_0.ThisBytesL.Count + 100 - 1) RomVersion = Binary_Files_0.ThisBytesL.Count + 100 - 1;
        //CloseBinaryFiles();
    }

    public void LoadBMtune()
    {
        Glitched = false;

        GetRomVersion();
        class32_Locations_0.ResetAddresseForVersion(RomVersion);

        //SetBMTune_Baserom();
        if (RomVersion < 111) ConvertBaseromVersionToVersion(RomVersion);
        else ResetBaseromParameters();

        GlitchTestingTimer = 0;

        //this.method_26(this.string_5);
        this.SetFileLoaded(true);
    }

    private string GetFileType()
    {
        //0x0210 = 528	...	eCtune=196, P30=71, Gold=137, P72=228, Neptune=16, P28=212
        //Get Other Softwares
        string Error_Str = "";
        if (this.GetByteAt(528) == 0x2e && this.GetByteAt(529) == 0xf9 && this.GetByteAt(530) == 0x7d) Error_Str = "This is a Crome P30 file" + Environment.NewLine + "Open this file with Crome";
        else if (this.GetByteAt(528) == 228 && this.GetByteAt(529) == 0xf8 && this.GetByteAt(530) == 0xa2) Error_Str = "This is a Crome P72 file" + Environment.NewLine + "Open this file with Crome";
        else if (this.GetByteAt(528) == 212 && this.GetByteAt(529) == 0x1a && this.GetByteAt(530) == 0x02) Error_Str = "This is a Crome P28 file" + Environment.NewLine + "Open this file with Crome";
        else if ((this.GetByteAt(528) == 0x29 && this.GetByteAt(529) == 0x0f && this.GetByteAt(530) == 0xc9) ||
                 (this.GetByteAt(528) == 0xc4 && this.GetByteAt(529) == 0xaa && this.GetByteAt(530) == 0x98)) Error_Str = "This is a Crome P13 file" + Environment.NewLine + "Open this file with Crome";
        else if (this.GetByteAt(528) == 137 && this.GetByteAt(529) == 0xc6 && this.GetByteAt(530) == 0xab) Error_Str = "This is a Crome Gold file" + Environment.NewLine + "Open this file with Crome" + Environment.NewLine + "OR BUY BMTUNE TO IMPORT IT";
        else if (this.GetByteAt(528) == 19) Error_Str = "This is possibly a Hondata S200 file" + Environment.NewLine + "Open this file with Hondata";
        else if (this.GetByteAt(528) == 16 && this.GetByteAt(529) == 0x8a && this.GetByteAt(530) == 0xc4) Error_Str = "This is a Neptune file" + Environment.NewLine + "Open this file with Neptune" + Environment.NewLine + "OR BUY BMTUNE TO IMPORT IT";
        if ((this.method_152(0x7fefL) == 0x4365L) && (this.method_152(0x7ff1L) == 0xa974L)) Error_Str = "This is a eCtune file" + Environment.NewLine + "Open this file with eCtune" + Environment.NewLine + "OR BUY BMTUNE TO IMPORT IT";
        if (Error_Str == "") Error_Str = "Can't load the file!";
        return Error_Str;
    }

    private void ResetInjector()
    {
        int ThisI = GetInjIndex();
        if (this.GetByteAt(this.class13_u_0.long_81) != ThisI) SetByteAt(this.class13_u_0.long_81, (byte)ThisI);
    }

    private int GetInjIndex()
    {
        int ThatI = this.class24_u_0.Count - 1;   //set to custom injector automatically if not found
        
        byte[] Vdouble_byte = new byte[7];
        byte[] Vdouble_byte2 = new byte[7];
        long[] Tdouble_byte = new long[7];
        long[] Tdouble_byte2 = new long[7];
        for (int i = 0; i < 7; i++) Vdouble_byte[i] = this.GetByteAt(this.class13_u_0.long_185 + (i * 3));
        for (int i = 0; i < 7; i++) Tdouble_byte[i] = this.method_152(this.class13_u_0.long_185 + (i * 3) + 1L);

        List<int> InjectorPossibleMatch = new List<int>();
        List<int> InjectorPossibleMatchDiffSize = new List<int>();

        for (int i = 0; i < this.class24_u_0.Count; i++)
        {
            bool Same = true;
            int Differences = 0;
            for (int i2 = 0; i2 < 7; i2++)
            {
                Vdouble_byte2[i2] = method_209((float)this.class24_u_0[i].double_0[i2]);
                Tdouble_byte2[i2] = (long)((this.class24_u_0[i].double_1[i2] * 1000.0) / 3.2);

                if (Vdouble_byte[i2] != Vdouble_byte2[i2] && Vdouble_byte[i2] != Vdouble_byte2[i2] - 1 && Vdouble_byte[i2] != Vdouble_byte2[i2] + 1) Same = false;
                if (Tdouble_byte[i2] != Tdouble_byte2[i2] && Tdouble_byte[i2] != Tdouble_byte2[i2] - 1 && Tdouble_byte[i2] != Tdouble_byte2[i2] + 1) Same = false;

                //Get diff size
                if (Same)
                {
                    if (Vdouble_byte[i2] != Vdouble_byte2[i2]) Differences++;
                    if (Tdouble_byte[i2] != Tdouble_byte2[i2]) Differences++;
                }
            }

            if (Same)
            {
                InjectorPossibleMatch.Add(i);
                InjectorPossibleMatchDiffSize.Add(Differences);
            }
        }

        if (InjectorPossibleMatchDiffSize.Count > 0)
        {
            int IndexWithLeastDifference = 0;
            int LeastDifference = 9999;

            //Get the injector that has least differences
            for (int i = 0; i < InjectorPossibleMatchDiffSize.Count; i++)
            {
                if (InjectorPossibleMatchDiffSize[i] < LeastDifference)
                {
                    LeastDifference = InjectorPossibleMatchDiffSize[i];
                    IndexWithLeastDifference = InjectorPossibleMatch[i];
                }
            }

            //Set Injector that has least differences
            ThatI = IndexWithLeastDifference;
        }

        Vdouble_byte = null;
        Vdouble_byte2 = null;
        Tdouble_byte = null;
        Tdouble_byte2 = null;
        InjectorPossibleMatch = null;
        InjectorPossibleMatchDiffSize = null;

        return ThatI;
    }

    private bool PasswordMatch()
    {
        GetPWLocation(RomVersion);

        byte[] PasswordByte = new byte[class10_settings_0.Password.Length];
        for (int i = 0; i < class10_settings_0.Password.Length; i++) PasswordByte[i] = Convert.ToByte(class10_settings_0.Password[i]);
        byte[] PasswordByte2 = method_92(PasswordByte);

        bool Match = true;
        for (int i = 0; i < PasswordByte2.Length; i++)
        {
            if (this.GetByteAt(this.class13_u_0.long_4PASS + i) != PasswordByte2[i]) Match = false;
        }

        PasswordByte = null;
        PasswordByte2 = null;
        return Match;
    }

    private byte method_92_c(byte[] byte_01)
    {
        int int_92_0 = 0;
        for (int i = 0; i < byte_01.Length; i++)
        {
            int_92_0 = int_92_0 + (int)byte_01[i];
            if (int_92_0 > 255) int_92_0 = int_92_0 - 256;
        }
        byte_01 = null;
        return (byte)int_92_0;
    }

    public byte[] method_92(byte[] byte_01)
    {
        byte byte92 = method_92_c(byte_01);
        byte[] byte_02 = new byte[byte_01.Length + 1];
        for (int i = 0; i < byte_01.Length; i++)
        {
            if ((i % 2) == 0)
            {
                int int_01 = (int) byte_01[i] + byte92;
                if (int_01 > 255) int_01 -= 256;
                byte_02[i] = (byte)int_01;
            }
            else {
                int int_01 = (int) byte_01[i] - byte92;
                if (int_01 < 0) int_01 += 256;
                byte_02[i] = (byte) int_01;
            }
        }
        byte_02[byte_01.Length] = byte92;

        byte_02 = method_94(byte_02);
        byte_01 = null;
        return byte_02;
    }

    public byte[] method_93(byte[] byte_01)
    {
        byte_01 = method_95(byte_01);

        byte byte92 = byte_01[byte_01.Length - 1];
        byte[] byte_02 = new byte[byte_01.Length - 1];
        for (int i = 0; i < byte_02.Length; i++)
        {
            if ((i % 2) == 0)
            {
                int int_01 = (int)byte_01[i] - byte92;
                if (int_01 < 0) int_01 += 256;
                byte_02[i] = (byte)int_01;
            }
            else
            {
                int int_01 = (int)byte_01[i] + byte92;
                if (int_01 > 255) int_01 -= 256;
                byte_02[i] = (byte)int_01;
            }
        }
        byte_01 = null;
        return byte_02;
    }

    public byte[] method_94(byte[] byte_01)
    {
        byte byte92 = method_92_c(byte_01);
        byte[] byte_02 = new byte[byte_01.Length + 9];
        int int_99 = 0;
        for (int i = 0; i < byte_01.Length; i++)
        {
            int int_01 = (int)byte_01[i] - byte92;
            if (int_01 < 0) int_01 += 256;
            byte_02[int_99] = (byte)int_01;

            int int_02 = i + 1;
            if (int_02 == 16 || int_02 == 32 || int_02 == 48 || int_02 == 64 || int_02 == 80 || int_02 == 96 || int_02 == 112 || int_02 == 128)
            {
                int_99++;
                byte_02[int_99] = byte92;
                byte Old = byte92;
                byte92 = method_92_c(byte_02);
            }
            int_99++;
        }
        byte_02[byte_02.Length - 1] = byte92;
        byte_01 = null;
        return byte_02;
    }

    public byte[] method_95(byte[] byte_01)
    {
        byte byte92_1 = byte_01[16];
        byte byte92_2 = byte_01[32+1];
        byte byte92_3 = byte_01[48+2];
        byte byte92_4 = byte_01[64+3];
        byte byte92_5 = byte_01[80+4];
        byte byte92_6 = byte_01[96+5];
        byte byte92_7 = byte_01[112+6];
        byte byte92_8 = byte_01[128+7];
        byte byte92_9 = byte_01[byte_01.Length - 1];
        byte byte92 = 0;
        byte[] byte_02 = new byte[byte_01.Length - 9];
        int int_99 = 0;
        for (int i = 0; i < byte_02.Length; i++)
        {
            if (i < 128) byte92 = byte92_8;
            if (i < 112) byte92 = byte92_7;
            if (i < 96) byte92 = byte92_6;
            if (i < 80) byte92 = byte92_5;
            if (i < 64) byte92 = byte92_4;
            if (i < 48) byte92 = byte92_3;
            if (i < 32) byte92 = byte92_2;
            if (i < 16) byte92 = byte92_1;
            if (i >= 128) byte92 = byte92_9;
            if (i == 16 || i == 32 || i == 48 || i == 64 || i == 80 || i == 96 || i == 112 || i == 128) int_99++;

            int int_01 = (int)byte_01[int_99] + byte92;
            if (int_01 > 255) int_01 -= 256;
            byte_02[i] = (byte)int_01;

            int_99++;
        }
        byte_01 = null;
        return byte_02;
    }

    public delegate void Delegate55();

    public delegate void Delegate56(string string_0, string string_1, string string_2);

    public delegate void Delegate57(SelectedTable selectedTable_0);

    public delegate void Delegate58();

    public delegate void Delegate59();

    public delegate void Delegate60(int int_0);

    public delegate void Delegate61(FuelDisplayMode fuelDisplayMode_0);

    public delegate void Delegate62(string string_0, string string_1);
}

