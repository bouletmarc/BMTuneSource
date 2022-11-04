using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;

internal class frmConvert : Form
{
    private Class18 class18_0;
    private IContainer icontainer_0;
    private Label labelProductName;
    private Label label1;
    private Label label_Baserom;
    private DataGridView dataGridView1;
    private Label label5;
    private TextBox textBox_FileName;
    private Label label6;
    private Label label2;
    private Button okButton;
    private byte[] File_Byte;
    private byte[] File_Byte_BMTune;
    private Button button1;
    private Label label3;
    private DataGridViewCheckBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    //private DASM_Bytes DASM_Bytes_0;
    string Baserom;
    string FilePath = "";


    //#####################
    byte[] Final_LFuel = new byte[504];
    byte[] Final_HFuel = new byte[504];
    byte[] Final_LIgn = new byte[480];
    byte[] Final_HIgn = new byte[480];
    byte[] Final_mBar = new byte[24];
    byte[] Final_LRPM = new byte[20];
    byte[] Final_HRPM = new byte[20];
    byte[] Final_Inj = new byte[21];

    int CurrentIndex = 0;
    int CurrentDone = 0;

    string[] All_Lines = new string[] { };

    int LFuelLocation = 0;
    int HFuelLocation = 0;
    int LIgnLocation = 0;
    int HIgnLocation = 0;
    int mBarScalarLocation = 0;
    int LRPMLocation = 0;
    int HRPMLocation = 0;
    int InjLocation = 0;

    bool LFuelFound = false;
    bool HFuelFound = false;
    bool LIgnFound = false;
    bool HIgnFound = false;
    bool mBarScalarFound = false;
    bool LRPMFound = false;
    bool HRPMFound = false;
    bool InjFound = false;

    int ModsCount = 0;
    bool Boosted = false;
    int ColumnNumber = 10;
    string baserom = "";

    public frmConvert(ref Class18 class18_1, string BaseromT)
    {
        this.InitializeComponent();
        this.class18_0 = class18_1;

        //DASM_Bytes_0 = new DASM_Bytes();

        LoadThis(BaseromT);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    public void LoadThis(string BaseromT)
    {
        File_Byte = this.class18_0.GetAllByte();

        FilePath = Path.GetDirectoryName(this.class18_0.method_25_GetFilename());
        string FileName = this.class18_0.method_23();
        string ext = FileName.Substring(FileName.Length - 4);
        textBox_FileName.Text = FileName.Substring(0, FileName.Length - 4) + "_Converted" + ext;

        Baserom = BaseromT;
        label_Baserom.Text = Baserom;

        dataGridView1.Rows.Clear();
        if (Baserom == "eCtune")
        {
            dataGridView1.Rows.Add(true, "All", "Any", "Any");
        }
        else if (Baserom == "Crome Gold" || Baserom == "Neptune")
        {
            dataGridView1.Rows.Add(true, "Fuel tables (low-high cams)");
            dataGridView1.Rows.Add(true, "Igntion tables (low-high cams)");
            dataGridView1.Rows.Add(true, "Tables scaling (mBar vs rpm)");
            dataGridView1.Rows.Add(true, "Injectors settings");
            dataGridView1.Rows.Add(true, "Idle settings");
            dataGridView1.Rows.Add(true, "Rev limit settings (cold-warm became low-high cams)");
            dataGridView1.Rows.Add(true, "Launch settings");
            dataGridView1.Rows.Add(true, "Vtec settings (except rpm)");
            dataGridView1.Rows.Add(true, "Sensors settings (except map sensor)");
            dataGridView1.Rows.Add(true, "Closeloop settings (except wideband)");
            //dataGridView1.Rows.Add(true, "Fuel and Ignition correction");
            //dataGridView1.Rows.Add(true, "Tip-in settings");
            //dataGridView1.Rows.Add(true, "Transmission settings");
        }
        else if (Baserom == "Crome P28" || Baserom == "Crome P30" || Baserom == "Crome P72")
        {
            dataGridView1.Rows.Add(true, "Fuel tables (low-high cams)");
            dataGridView1.Rows.Add(true, "Igntion tables (low-high cams)");
            dataGridView1.Rows.Add(true, "Tables scaling (mBar vs rpm)");
            dataGridView1.Rows.Add(true, "Injectors settings");
        }
        else if (Baserom == "Crome P13")
        {
            dataGridView1.Rows.Add(true, "Fuel tables (low-high cams) **APROXIMATIVE**");
            dataGridView1.Rows.Add(true, "Igntion tables (low-high cams)");
            dataGridView1.Rows.Add(true, "Tables scaling (mBar vs rpm)");
        }
    }

    /*public void ConvertInjector()
    {
        //0x6210L
        byte InjectorByte = File_Byte_BMTune[this.class18_0.class13_0.long_81];
        //Prelude H22 330cc and 290cc
        if (InjectorByte == 2) InjectorByte = 8;
        if (InjectorByte == 3) InjectorByte = 9;
        //Mitshubishi DSM 450cc
        if (InjectorByte == 4) InjectorByte = 16;
        if (InjectorByte == 5) InjectorByte = 17;
        //MSD
        if (InjectorByte == 6) InjectorByte = 26;
        if (InjectorByte == 7) InjectorByte = 27;
        //Precision Turbo
        if (InjectorByte == 8) InjectorByte = 35;
        if (InjectorByte == 9) InjectorByte = 36;
        if (InjectorByte == 10) InjectorByte = 37;
        //RC Enginering
        if (InjectorByte == 11) InjectorByte = 38;
        if (InjectorByte == 12) InjectorByte = 39;
        if (InjectorByte == 13) InjectorByte = 40;
        if (InjectorByte == 14) InjectorByte = 41;
        if (InjectorByte == 15) InjectorByte = 42;
        if (InjectorByte == 16) InjectorByte = 43;
        if (InjectorByte == 17) InjectorByte = 44;
        if (InjectorByte == 18) InjectorByte = 45;
        if (InjectorByte == 19) InjectorByte = 46;
        if (InjectorByte == 20) InjectorByte = 47;
        if (InjectorByte == 21) InjectorByte = 48;
        if (InjectorByte == 22) InjectorByte = 49;
        if (InjectorByte == 23) InjectorByte = 50;
        if (InjectorByte == 24) InjectorByte = 51;
        if (InjectorByte == 25) InjectorByte = 52;
        //P&H
        if (InjectorByte == 26) InjectorByte = 28;
        if (InjectorByte == 27) InjectorByte = 29;
        //Ultimate racing
        if (InjectorByte == 28) InjectorByte = 30;
        //Honda s2000
        if (InjectorByte == 29) InjectorByte = 10;
        //Denso
        if (InjectorByte == 30) InjectorByte = 32;
        if (InjectorByte == 31) InjectorByte = 33;
        if (InjectorByte == 32) InjectorByte = 34;
        //HKS
        if (InjectorByte == 33) InjectorByte = 31;
        //Injector Dynamics
        int Difference = InjectorByte - 34;
        if (InjectorByte >= 34) InjectorByte = (byte) (53 + Difference);

        //Apply new reseted byte
        File_Byte_BMTune[this.class18_0.class13_0.long_81] = InjectorByte;
    }*/

    public void Convert()
    {
        //Load New Baserom Binary (Class18 byte_0)
        this.class18_0.method_63(true, this.class18_0.GetStable_Version_LAST() + 100, "");
        File_Byte_BMTune = this.class18_0.GetAllByte();

        //Convert Bytes
        if (Baserom == "eCtune")
        {
            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "True")
            {
                File_Byte_BMTune = File_Byte;
                //ConvertInjector();
            }
        }
        if (Baserom == "Crome Gold")
        {
            //Fuel Low-High
            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 504; i++) File_Byte_BMTune[0x6ead + i] = File_Byte[0x6e9a + i];
                for (int i = 0; i < 504; i++) File_Byte_BMTune[0x70a5 + i] = File_Byte[0x7092 + i];
                //File_Byte_BMTune[0x61fb] = File_Byte[0x0a1d];
                //File_Byte_BMTune[0x61fb] += 2;
                int ColumnCount = 0;
                for (int i = 0; i < 24; i++)
                {
                    if (i > 0)
                    {
                        if (File_Byte[0x6e5a + i] > File_Byte[0x6e5a + i - 1]) ColumnCount++;
                        else i = 25;
                    }
                }
                File_Byte_BMTune[0x61fb] = (byte)(ColumnCount + 1);
            }
            //Ign Low-High
            if (dataGridView1.Rows[1].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 480; i++) File_Byte_BMTune[0x729d + i] = File_Byte[0x728a + i];
                for (int i = 0; i < 480; i++) File_Byte_BMTune[0x747d + i] = File_Byte[0x746a + i];
                //File_Byte_BMTune[0x61fb] = File_Byte[0x0a1d];
                //File_Byte_BMTune[0x61fb] += 2;
                int ColumnCount = 0;
                for (int i = 0; i < 24; i++)
                {
                    if (i > 0)
                    {
                        if (File_Byte[0x6e5a + i] > File_Byte[0x6e5a + i - 1]) ColumnCount++;
                        else i = 25;
                    }
                }
                File_Byte_BMTune[0x61fb] = (byte)(ColumnCount + 1);
            }
            //Mbar Scaling, Rpm Low, Rpm High Scaling
            if (dataGridView1.Rows[2].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 24; i++) File_Byte_BMTune[0x6e59 + i] = File_Byte[0x6e5a + i];
                for (int i = 0; i < 20; i++) File_Byte_BMTune[0x6e71 + i] = File_Byte[0x6e72 + i];
                for (int i = 0; i < 20; i++) File_Byte_BMTune[0x6e85 + i] = File_Byte[0x6e86 + i];
            }
            // Injector Offset (Table, Offset ms, Value cc)
            if (dataGridView1.Rows[3].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 21; i++) File_Byte_BMTune[0x6442 + i] = File_Byte[0x61d6 + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x610d + i] = File_Byte[0x6B6D + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6101 + i] = File_Byte[0x6B68 + i];
                File_Byte_BMTune[0x6210] = 89;  //set to custom injector

                //Fuel Trims
                /*long Trim1 = (long)(this.class18_0.method_203(((File_Byte[0x6BC7 + 1] * 256) + File_Byte[0x6BC7]), Enum6.const_0) + 76);
                long Trim2 = (long)(this.class18_0.method_203(((File_Byte[0x6BE3 + 1] * 256) + File_Byte[0x6BE3]), Enum6.const_0) + 76);
                long Trim3 = (long)(this.class18_0.method_203(((File_Byte[0x6BD8 + 1] * 256) + File_Byte[0x6BD8]), Enum6.const_0) + 76);
                Trim1 = this.class18_0.method_231(double.Parse(Trim1.ToString()), Enum6.const_0);
                Trim2 = this.class18_0.method_231(double.Parse(Trim2.ToString()), Enum6.const_0);
                Trim3 = this.class18_0.method_231(double.Parse(Trim3.ToString()), Enum6.const_0);
                File_Byte_BMTune[0x6103 + 1] = (byte)(Trim1 / 256);
                File_Byte_BMTune[0x6103] = (byte)(Trim1 - (Trim1 / 256));
                File_Byte_BMTune[0x6105 + 1] = (byte)(Trim1 / 256);
                File_Byte_BMTune[0x6105] = (byte)(Trim1 - (Trim1 / 256));
                File_Byte_BMTune[0x6109 + 1] = (byte)(Trim1 / 256);
                File_Byte_BMTune[0x6109] = (byte)(Trim1 - (Trim1 / 256));*/
            }
            //Idle
            if (dataGridView1.Rows[4].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6117 + i] = File_Byte[0x2B5D + i];
                for (int i = 0; i < 42; i++) File_Byte_BMTune[0x6738 + i] = File_Byte[0x66e5 + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6114 + i] = File_Byte[0x698A + i];
            }
            //Rev Limit
            if (dataGridView1.Rows[5].Cells[0].Value.ToString() == "True")
            {
                //Cold-Hot Set
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 6] = File_Byte[0x3F4C + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 18] = File_Byte[0x3F43 + i];
                //Cold-Hot Reset
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0) File_Byte_BMTune[0x6591 + i] = (byte)(File_Byte[0x3F4C + i] + 1);
                    else File_Byte_BMTune[0x6591 + i] = File_Byte[0x3F4C + i];
                }
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0) File_Byte_BMTune[0x6591 + i + 12] = (byte)(File_Byte[0x3F43 + i] + 1);
                    else File_Byte_BMTune[0x6591 + i + 12] = File_Byte[0x3F43 + i];
                }
                //RESET NOVTEC
                if (File_Byte[0x6001] == 0)
                {
                    for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 18] = File_Byte[0x3F4C + i];
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0) File_Byte_BMTune[0x6591 + i + 12] = (byte)(File_Byte[0x3F4C + i] + 1);
                        else File_Byte_BMTune[0x6591 + i + 12] = File_Byte[0x3F4C + i];
                    }
                }

                //Activate Shiftlight, enable gear based shiftlight
                File_Byte_BMTune[0x6142] = 0xff;
                File_Byte_BMTune[0x6143] = 0xff;
                for (int i = 0; i < 10; i++) File_Byte_BMTune[0x6144 + i + 2] = File_Byte[0x6bfe + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6144 + i] = File_Byte[0x6bfe + i];
            }
            //Launch
            if (dataGridView1.Rows[6].Cells[0].Value.ToString() == "True")
            {
                //Activate
                File_Byte_BMTune[0x6152] = 0x80;
                File_Byte_BMTune[0x6154] = File_Byte[0x3f7d];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6156 + i] = File_Byte[0x3F40 + i];

                //Set Antilag
                long AntilagVal = ((File_Byte[0x6b7a + 1] * 256) + File_Byte[0x6b7a]) / 4;
                File_Byte_BMTune[0x6162] = (byte)(AntilagVal / 256);
                File_Byte_BMTune[0x6161] = (byte)(AntilagVal - (AntilagVal / 256));
                File_Byte_BMTune[0x6163] = (byte)(File_Byte[0x78d8] + 24);
                File_Byte_BMTune[0x5f8c] = (byte)(File_Byte[0x78d8] + 24);
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6161 + i] = File_Byte[0x6b7a + i];
                //Activate Antilag only if values arent ZERO's
                if (File_Byte[0x78d8] != 0 || File_Byte[0x6b7a] != 0 || File_Byte[0x6b7a + 1] != 0) File_Byte_BMTune[0x6164] = 0xff;
            }
            //Vtec
            if (dataGridView1.Rows[7].Cells[0].Value.ToString() == "True")
            {
                File_Byte_BMTune[0x61f2] = File_Byte[0x6001];
                if (File_Byte[0x3d27] != 0) File_Byte_BMTune[0x6123] = 0x00;
                else File_Byte_BMTune[0x6123] = 0xff;
                if (File_Byte[0x3d06] != 0) File_Byte_BMTune[0x6124] = 0x00;
                else File_Byte_BMTune[0x6124] = 0xff;

                //Vtec ECT
                if (File_Byte[0x11aa] == 0xff)
                {
                    File_Byte_BMTune[0x611f] = 0xff;
                }
                else
                {
                    File_Byte_BMTune[0x611f] = 0x00;
                    File_Byte_BMTune[0x6120] = File_Byte[0x11aa];
                }

                //Vtec Speed
                if (File_Byte[0x11b0] == 0x00)
                {
                    File_Byte_BMTune[0x6209] = 0xff;
                }
                else
                {
                    File_Byte_BMTune[0x6209] = 0x00;
                    File_Byte_BMTune[0x6122] = File_Byte[0x11b0];
                }

                //IAB
                if (File_Byte[0x11ed] != 0) File_Byte_BMTune[0x6215] = 0xff;
                else File_Byte_BMTune[0x6215] = 0x00;
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x611a + i] = File_Byte[0x11e4 + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6119 + i] = File_Byte[0x11de + i];
                if (File_Byte[0x11ec] == 0) File_Byte_BMTune[0x5fc9] = 0xff;
                else File_Byte_BMTune[0x5fc9] = 0x00;
            }
            //Sensors
            if (dataGridView1.Rows[8].Cells[0].Value.ToString() == "True")
            {
                File_Byte_BMTune[0x61f5] = File_Byte[0x6004];
                if (File_Byte[0x3c6f] == 0) File_Byte_BMTune[0x6116] = 0xff;
                else File_Byte_BMTune[0x6116] = 0x00;
                File_Byte_BMTune[0x61f3] = File_Byte[0x6002];
                File_Byte_BMTune[0x61f9] = File_Byte[0x6006];
                File_Byte_BMTune[0x620e] = File_Byte[0x6015];

                //TPS
                File_Byte_BMTune[0x6200] = 0xff;
                File_Byte_BMTune[0x6205] = File_Byte[0x6c21];
                File_Byte_BMTune[0x6203] = File_Byte[0x6c1f];

                //MAP
                //File_Byte_BMTune[0x60fc] = 11;
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x60fd + i] = File_Byte[0x6376 + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x60ff + i] = File_Byte[0x6374 + i];
            }
            //Closeloop
            if (dataGridView1.Rows[9].Cells[0].Value.ToString() == "True")
            {
                File_Byte_BMTune[0x61f4] = File_Byte[0x6003];
                if (File_Byte[0x6005] == 0) File_Byte_BMTune[0x6111] = 0xff;
                else File_Byte_BMTune[0x6111] = 0x00;
                File_Byte_BMTune[0x6112] = File_Byte[0x15b4];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6167 + i] = File_Byte[0x5f53 + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6169 + i] = File_Byte[0x1c08 + i];
            }
            //Ect iat corr
            //IAT Fuel Corr
            /*if (dataGridView1.Rows[10].Cells[0].Value.ToString() == "True")
            {
                int FinalIndex = 0;
                for (int i = 0; i < 21; i++)
                {
                    //Apply for Low, Mid, High Load
                    for (int i2 = 0; i2 < 3; i2++)
                    {
                        byte Byte_IAT_Temp = File_Byte[0x607a + i];
                        long IAT_Corr = ((long)((File_Byte[0x607a + i + 2] * 0x100) + File_Byte[0x607a + i + 1]) / 32768);

                        //IAT Temp
                        File_Byte_BMTune[0x62a2 + FinalIndex] = Byte_IAT_Temp;
                        //IAT Low Load (-5 diff)
                        long IAT_CurrentCorr = (IAT_Corr - 5) * 32768;
                        byte firstB = (byte)(IAT_CurrentCorr / 256);
                        byte SecondB = (byte)(IAT_CurrentCorr - (firstB * 256));
                        File_Byte_BMTune[0x62a2 + FinalIndex + 2] = (byte)(IAT_CurrentCorr / 255);
                        File_Byte_BMTune[0x62a2 + FinalIndex + 1] = (byte)(IAT_CurrentCorr - firstB);
                        //IAT Mid Load (-2 diff)
                        IAT_CurrentCorr = (IAT_Corr - 2) * 32768;
                        firstB = (byte)(IAT_CurrentCorr / 256);
                        SecondB = (byte)(IAT_CurrentCorr - (firstB * 256));
                        File_Byte_BMTune[0x62bd + FinalIndex + 2] = firstB;
                        File_Byte_BMTune[0x62bd + FinalIndex + 1] = SecondB;
                        //IAT High Load (No diff)
                        IAT_CurrentCorr = (IAT_Corr) * 32768;
                        firstB = (byte)(IAT_CurrentCorr / 256);
                        SecondB = (byte)(IAT_CurrentCorr - (firstB * 256));
                        File_Byte_BMTune[0x62d8 + FinalIndex + 2] = firstB;
                        File_Byte_BMTune[0x62d8 + FinalIndex + 1] = SecondB;
                    }

                    //Apply for 2x missing columns
                    if (i == 3 || i == 6)
                    {
                        //Current
                        byte Byte_IAT_Temp = File_Byte[0x607a + i];
                        long IAT_Corr = ((long)((File_Byte[0x607a + i + 2] * 0x100) + File_Byte[0x607a + i + 1]) / 32768);
                        //After
                        byte Byte_IAT_Temp_After = File_Byte[0x607a + i + 3];
                        long IAT_Corr_After = ((long)((File_Byte[0x607a + i + 2 + 3] * 0x100) + File_Byte[0x607a + i + 1 + 3]) / 32768);
                        //Middle value
                        byte Byte_IAT_Temp_Mid = (byte)(Byte_IAT_Temp_After - ((Byte_IAT_Temp_After - Byte_IAT_Temp) / 2));
                        byte IAT_Corr_Mid = (byte)(IAT_Corr_After - ((IAT_Corr_After - IAT_Corr) / 2));
                        //Increase BMTune Table
                        FinalIndex++;
                        FinalIndex++;
                        FinalIndex++;

                        //IAT Temp
                        File_Byte_BMTune[0x62a2 + FinalIndex] = Byte_IAT_Temp_Mid;
                        //IAT Low Load (-5 diff)
                        long IAT_CurrentCorr = (IAT_Corr_Mid - 5) * 32768;
                        byte firstB = (byte)(IAT_CurrentCorr / 256);
                        byte SecondB = (byte)(IAT_CurrentCorr - (firstB * 256));
                        File_Byte_BMTune[0x62a2 + FinalIndex + 2] = (byte)(IAT_CurrentCorr / 255);
                        File_Byte_BMTune[0x62a2 + FinalIndex + 1] = (byte)(IAT_CurrentCorr - firstB);
                        //IAT Mid Load (-2 diff)
                        IAT_CurrentCorr = (IAT_Corr_Mid - 2) * 32768;
                        firstB = (byte)(IAT_CurrentCorr / 256);
                        SecondB = (byte)(IAT_CurrentCorr - (firstB * 256));
                        File_Byte_BMTune[0x62bd + FinalIndex + 2] = firstB;
                        File_Byte_BMTune[0x62bd + FinalIndex + 1] = SecondB;
                        //IAT High Load (No diff)
                        IAT_CurrentCorr = (IAT_Corr_Mid) * 32768;
                        firstB = (byte)(IAT_CurrentCorr / 256);
                        SecondB = (byte)(IAT_CurrentCorr - (firstB * 256));
                        File_Byte_BMTune[0x62d8 + FinalIndex + 2] = firstB;
                        File_Byte_BMTune[0x62d8 + FinalIndex + 1] = SecondB;
                    }

                    //Increase Crome Table
                    i++;
                    i++;

                    //Increase BMTune Table
                    FinalIndex++;
                    FinalIndex++;
                    FinalIndex++;
                }
            }*/

            //Tip-in

            //Transmission
        }
        if (Baserom == "Neptune")
        {
            //Fuel Low-High
            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 480; i++) File_Byte_BMTune[0x6ead + i] = File_Byte[0x6a90 + i];
                for (int i = 0; i < 480; i++) File_Byte_BMTune[0x70a5 + i] = File_Byte[0x6f40 + i];
                for (int i = 0; i < 24; i++) File_Byte_BMTune[0x6ead + i + 480] = File_Byte[0x6a90 + i + 576];
                for (int i = 0; i < 24; i++) File_Byte_BMTune[0x70a5 + i + 480] = File_Byte[0x6f40 + i + 576];
                int ColumnCount = 0;
                for (int i = 0; i < 24; i++)
                {
                    if (File_Byte[0x6a00 + i] != 0xff) ColumnCount++;
                    else i = 25;
                }
                File_Byte_BMTune[0x61fb] = (byte)(ColumnCount);
            }
            //Ign Low-High
            if (dataGridView1.Rows[1].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 480; i++) File_Byte_BMTune[0x729d + i] = File_Byte[0x73f0 + i];
                for (int i = 0; i < 480; i++) File_Byte_BMTune[0x747d + i] = File_Byte[0x7870 + i];
                int ColumnCount = 0;
                for (int i = 0; i < 24; i++)
                {
                    if (File_Byte[0x6a00 + i] != 0xff) ColumnCount++;
                    else i = 25;
                }
                File_Byte_BMTune[0x61fb] = (byte)(ColumnCount);
            }
            //Mbar Scaling, Rpm Low, Rpm High Scaling
            if (dataGridView1.Rows[2].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 24; i++) File_Byte_BMTune[0x6e59 + i] = File_Byte[0x6a00 + i];
                //for (int i = 0; i < 20; i++) File_Byte_BMTune[0x6e71 + i] = File_Byte[0x6a30 + i];    //rpm scale low
                //for (int i = 0; i < 20; i++) File_Byte_BMTune[0x6e85 + i] = File_Byte[0x6a48 + i];    //rpm scale high
            }
            // Injector Offset (Table, Offset ms, Value cc)
            if (dataGridView1.Rows[3].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 21; i++) File_Byte_BMTune[0x6442 + i] = File_Byte[0x56d6 + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6101 + i] = File_Byte[0x5403 + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x610d + i] = File_Byte[0x5403 + i];     //Injector Offset
                File_Byte_BMTune[0x6210] = 89;  //set to custom injector

                //Fuel Trims
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6103 + i] = File_Byte[0x5406 + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6105 + i] = File_Byte[0x540a + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6109 + i] = File_Byte[0x5408 + i];
            }
            //Idle
            if (dataGridView1.Rows[4].Cells[0].Value.ToString() == "True")
            {
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6117 + i] = File_Byte[0x53f2 + i];
                for (int i = 0; i < 42; i++) File_Byte_BMTune[0x6738 + i] = File_Byte[0x5a56 + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6114 + i] = File_Byte[0x698A + i]; //Iacv Duty
            }
            //Rev Limit
            if (dataGridView1.Rows[5].Cells[0].Value.ToString() == "True")
            {
                //Cold-Hot Set
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 6] = File_Byte[0x5813 + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 18] = File_Byte[0x581f + i];
                //Cold-Hot Reset
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i] = File_Byte[0x580d + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 12] = File_Byte[0x5819 + i];
                //RESET NOVTEC
                if (File_Byte[0x5466] == 0)
                {
                    for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 18] = File_Byte[0x5813 + i];
                    for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6591 + i + 12] = File_Byte[0x580d + i];
                }

                //Activate Shiftlight, enable gear based shiftlight
                File_Byte_BMTune[0x6142] = File_Byte[0x5458];
                File_Byte_BMTune[0x6143] = File_Byte[0x5395];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6144 + i] = File_Byte[0x5442 + i];
                for (int i = 0; i < 10; i++) File_Byte_BMTune[0x6144 + i + 2] = File_Byte[0x5e6a + i];
            }
            //Launch
            if (dataGridView1.Rows[6].Cells[0].Value.ToString() == "True")
            {
                //Activate
                if (File_Byte[0x545e] == 0xff) File_Byte_BMTune[0x6152] = 0x80;
                else File_Byte_BMTune[0x6152] = 0xff;
                File_Byte_BMTune[0x6154] = File_Byte[0x5418];   //vss
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6156 + i] = File_Byte[0x5419 + i];   //rpm

                //Set Antilag
                long AntilagVal = ((File_Byte[0x5416 + 1] * 256) + File_Byte[0x5416]) / 4;
                File_Byte_BMTune[0x6162] = (byte)(AntilagVal / 256);
                File_Byte_BMTune[0x6161] = (byte)(AntilagVal - (AntilagVal / 256));
                File_Byte_BMTune[0x6163] = (byte)(File_Byte[0x541D]);
                File_Byte_BMTune[0x5f8c] = (byte)(File_Byte[0x541D]);
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6161 + i] = File_Byte[0x6b7a + i];
                //Activate Antilag only if values arent ZERO's
                if (File_Byte[0x541D] != 0 || File_Byte[0x5416] != 0 || File_Byte[0x5416 + 1] != 0) File_Byte_BMTune[0x6164] = 0xff;
            }
            //Vtec
            if (dataGridView1.Rows[7].Cells[0].Value.ToString() == "True")
            {
                //Vtec, vtc pressure, vtc solenoid
                File_Byte_BMTune[0x61f2] = File_Byte[0x5466];
                File_Byte_BMTune[0x6123] = File_Byte[0x545b];
                File_Byte_BMTune[0x6124] = File_Byte[0x545c];
                //Vtec ECT
                File_Byte_BMTune[0x611f] = File_Byte[0x53c8];
                //File_Byte_BMTune[0x6120] = File_Byte[0x545d];
                //Vtec Speed
                File_Byte_BMTune[0x6209] = File_Byte[0x53c7];
                //File_Byte_BMTune[0x6122] = File_Byte[0x547d];
                //Vtec rpm
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6657 + i] = File_Byte[0x58d5 + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6659 + i] = File_Byte[0x58d3 + i];

                //IAB
                File_Byte_BMTune[0x6215] = File_Byte[0x5489];
                File_Byte_BMTune[0x611a] = File_Byte[0x5433];
                File_Byte_BMTune[0x6119] = File_Byte[0x5434];
            }
            //Sensors
            if (dataGridView1.Rows[8].Cells[0].Value.ToString() == "True")
            {
                File_Byte_BMTune[0x61f5] = File_Byte[0x5469];
                File_Byte_BMTune[0x6116] = File_Byte[0x5452];
                File_Byte_BMTune[0x61f3] = File_Byte[0x5467];
                File_Byte_BMTune[0x61f9] = File_Byte[0x546d];
                File_Byte_BMTune[0x620e] = File_Byte[0x5482];

                //TPS
                //File_Byte_BMTune[0x6200] = 0xff;
                //File_Byte_BMTune[0x6205] = File_Byte[0x6c21];
                //File_Byte_BMTune[0x6203] = File_Byte[0x6c1f];

                //MAP
                //File_Byte_BMTune[0x60fc] = 11;
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x60fd + i] = File_Byte[0x6376 + i];
                //for (int i = 0; i < 2; i++) File_Byte_BMTune[0x60ff + i] = File_Byte[0x6374 + i];
            }
            //Closeloop
            if (dataGridView1.Rows[9].Cells[0].Value.ToString() == "True")
            {
                File_Byte_BMTune[0x61f4] = File_Byte[0x5468];
                File_Byte_BMTune[0x6111] = File_Byte[0x5464];
                File_Byte_BMTune[0x6112] = File_Byte[0x5446];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6167 + i] = File_Byte[0x53b9 + i];
                for (int i = 0; i < 2; i++) File_Byte_BMTune[0x6169 + i] = File_Byte[0x53bb + i];
            }
        }

        if (Baserom == "Crome P28" || Baserom == "Crome P30" || Baserom == "Crome P72" || Baserom == "Crome P13")
        {
            if (!Directory.Exists(FilePath)) Directory.CreateDirectory(FilePath);

            string FileName = this.class18_0.method_23();

            this.class18_0.Converting = true;

            //#######
            //Zipping
            string Filename = "dasm662.exe";
            string ZipFolder = "ASM";
            string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
            if (!File.Exists(WholePath)) this.class18_0.class17_0.frmMain_0.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
            //#######

            File.Create(Application.StartupPath + @"\" + ZipFolder + @"\FileName.bin").Dispose();
            File.WriteAllBytes(Application.StartupPath + @"\" + ZipFolder + @"\FileName.bin", File_Byte);

            //Create DASM.bat
            /*string BatTxt = "dasm662.exe FileName.bin FileName.asm";
            StreamWriter writer = new StreamWriter(Application.StartupPath + @"\" + ZipFolder + @"\DASM.bat", false);
            writer.Write(BatTxt);
            writer.Close();
            writer.Dispose();
            writer = null;*/

            //Load DASM.bat
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //p.StartInfo.FileName = Application.StartupPath + @"\" + ZipFolder + @"\DASM.bat";
            p.StartInfo.FileName = "dasm662.exe";
            p.StartInfo.Arguments = "FileName.bin FileName.asm";
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

            FileInfo info = new FileInfo(Application.StartupPath + @"\" + ZipFolder + @"\FileName.asm");
            if (info.Exists)
            {
                GetASMLocation();
                Load_Bytes();
                Apply_Bytes();
            }
            else
            {
                MessageBox.Show(Form.ActiveForm, "Can't disassemble binary", "BMTune");
            }
            this.class18_0.RemoveFile();
            this.class18_0.Converting = false;
            info = null;
        }

        //Apply Bytes and File Name
        //this.class18_0.byte_0 = File_Byte_BMTune;
        this.class18_0.SetAllByte(File_Byte_BMTune);
        this.class18_0.method_26_SetFilename(FilePath + @"\" + textBox_FileName.Text);
        this.class18_0.method_24(textBox_FileName.Text);
    }

    private void GetASMLocation()
    {
        string ZipFolder = "ASM";

        All_Lines = File.ReadAllLines(Application.StartupPath + @"\" + ZipFolder + @"\FileName.asm");

        LFuelFound = false;
        HFuelFound = false;
        LIgnFound = false;
        HIgnFound = false;
        mBarScalarFound = false;
        LRPMFound = false;
        HRPMFound = false;
        InjFound = false;

        ModsCount = 0;

        //Get Rom Type
        baserom = "";
        if (File_Byte[528] == 212 && File_Byte[529] == 0x1a && File_Byte[530] == 0x02) baserom = "P28";
        if (File_Byte[528] == 0x2e && File_Byte[529] == 0xf9 && File_Byte[530] == 0x7d) baserom = "P30";
        if (File_Byte[528] == 228 && File_Byte[529] == 0xf8 && File_Byte[530] == 0xa2) baserom = "P72";
        //if (File_Byte[528] == 0x29 && File_Byte[529] == 0x0f && File_Byte[530] == 0xc9) baserom = "P13";
        if ((File_Byte[528] == 0x29 && File_Byte[529] == 0x0f && File_Byte[530] == 0xc9) ||
                 (File_Byte[528] == 0xc4 && File_Byte[529] == 0xaa && File_Byte[530] == 0x98)) baserom = "P13";

        //Get Columns Number
        ColumnNumber = 10;
        if (baserom == "P30") ColumnNumber = File_Byte[0x1235];
        if (baserom == "P28") ColumnNumber = File_Byte[0x12FD];
        if (baserom == "P72") ColumnNumber = File_Byte[0x1267];
        //if (baserom == "P13") ColumnNumber = File_Byte[0x1267];

        //Set boosted
        Boosted = false;
        if (ColumnNumber > 10) Boosted = true;

        if (baserom != "")
        {
            if (All_Lines.Length > 0 && File_Byte.Length > 0)
            {
                //Getting Locations
                for (int i = 0; i < All_Lines.Length; i++)
                {
                    if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "True")
                    {
                        if (!LFuelFound)
                        {
                            if (baserom == "P30")
                            {
                                if (All_Lines[i].Contains("er3, off(001dah)"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        LFuelLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        LFuelFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P28")
                            {
                                if (All_Lines[i].Contains("er3, off(001c2h)"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        LFuelLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        LFuelFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P72")
                            {
                                if (All_Lines[i].Contains("er3, off(001eah)"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        LFuelLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        LFuelFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P13")
                            {
                                LFuelLocation = int.Parse("60aa", System.Globalization.NumberStyles.HexNumber);
                                LFuelFound = true;
                                ModsCount++;
                            }
                        }

                        if (!HFuelFound)
                        {
                            if (baserom == "P30")
                            {
                                if (All_Lines[i].Contains("er3, off(001dch)"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HFuelLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HFuelFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P28")
                            {
                                if (All_Lines[i].Contains("er3, off(001c4h)"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HFuelLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HFuelFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P72")
                            {
                                if (All_Lines[i].Contains("er3, off(001ech)"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HFuelLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HFuelFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P13")
                            {
                                HFuelLocation = int.Parse("6172", System.Globalization.NumberStyles.HexNumber);
                                HFuelFound = true;
                                ModsCount++;
                            }
                        }
                    }

                    //####################################

                    if (dataGridView1.Rows[1].Cells[0].Value.ToString() == "True")
                    {
                        if (!LIgnFound)
                        {
                            if (baserom == "P30")
                            {
                                if (All_Lines[i].Contains("er3, (001dah-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        LIgnLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        LIgnFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P28")
                            {
                                if (All_Lines[i].Contains("er3, (001c4h-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        LIgnLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        LIgnFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P72")
                            {
                                if (All_Lines[i].Contains("label_0b98"))
                                {
                                    string CurrentCmd = All_Lines[i - 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        LIgnLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        LIgnFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P13")
                            {
                                LIgnLocation = int.Parse("63f8", System.Globalization.NumberStyles.HexNumber);
                                LIgnFound = true;
                                ModsCount++;
                            }
                        }

                        if (!HIgnFound)
                        {
                            if (baserom == "P30")
                            {
                                if (All_Lines[i].Contains("er3, (001dch-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HIgnLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HIgnFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P28")
                            {
                                if (All_Lines[i].Contains("er3, (001c2h-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HIgnLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HIgnFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P72")
                            {
                                if (All_Lines[i].Contains("label_0bac"))
                                {
                                    string CurrentCmd = All_Lines[i - 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HIgnLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HIgnFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P13")
                            {
                                HIgnLocation = int.Parse("659c", System.Globalization.NumberStyles.HexNumber);
                                HIgnFound = true;
                                ModsCount++;
                            }
                        }
                    }

                    //####################################

                    if (dataGridView1.Rows[2].Cells[0].Value.ToString() == "True")
                    {
                        if (!mBarScalarFound)
                        {
                            if (baserom == "P30")
                            {
                                if (All_Lines[i].Contains("r3, (001d2h-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i - 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        mBarScalarLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        mBarScalarFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P28")
                            {
                                if (All_Lines[i].Contains("r3, (001bbh-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i - 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        mBarScalarLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        mBarScalarFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P72")
                            {
                                if (All_Lines[i].Contains("r3, (001deh-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i - 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        mBarScalarLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        mBarScalarFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P13")
                            {
                                mBarScalarLocation = int.Parse("6050", System.Globalization.NumberStyles.HexNumber);
                                mBarScalarFound = true;
                                ModsCount++;
                            }
                        }

                        if (!LRPMFound)
                        {
                            if (baserom == "P13")
                            {
                                LRPMLocation = int.Parse("6000", System.Globalization.NumberStyles.HexNumber);
                                LRPMFound = true;
                                ModsCount++;
                            }
                            else
                            {
                                if (All_Lines[i].Contains("off(00217h).0, C"))
                                {
                                    string CurrentCmd = All_Lines[i + 1];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        LRPMLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        LRPMFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                        }

                        if (!HRPMFound)
                        {
                            if (baserom == "P30")
                            {
                                if (All_Lines[i].Contains("A, (001dah-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i + 3];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HRPMLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HRPMFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P28")
                            {
                                if (All_Lines[i].Contains("A, (001c2h-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i + 3];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HRPMLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HRPMFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P72")
                            {
                                if (All_Lines[i].Contains("A, (001eah-00180h)[USP]"))
                                {
                                    string CurrentCmd = All_Lines[i + 3];
                                    if (CurrentCmd.Contains("#"))
                                    {
                                        CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                        HRPMLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                        HRPMFound = true;
                                        ModsCount++;
                                    }
                                }
                            }
                            if (baserom == "P13")
                            {
                                HRPMLocation = int.Parse("6028", System.Globalization.NumberStyles.HexNumber);
                                HRPMFound = true;
                                ModsCount++;
                            }
                        }
                    }

                    //####################################

                    if (baserom != "P13") {
                        if (dataGridView1.Rows[3].Cells[0].Value.ToString() == "True")
                        {
                            if (!InjFound)
                            {
                                if (baserom == "P30")
                                {
                                    if (All_Lines[i].Contains("A, (00168h-00180h)[USP]"))
                                    {
                                        string CurrentCmd = All_Lines[i + 5];
                                        if (CurrentCmd.Contains("#"))
                                        {
                                            CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                            InjLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                            InjFound = true;
                                            ModsCount++;
                                        }
                                    }
                                }
                                if (baserom == "P28")
                                {
                                    if (All_Lines[i].Contains("A, (00144h-00180h)[USP]"))
                                    {
                                        string CurrentCmd = All_Lines[i - 2];
                                        if (CurrentCmd.Contains("#"))
                                        {
                                            CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                            InjLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                            InjFound = true;
                                            ModsCount++;
                                        }
                                    }
                                }
                                if (baserom == "P72")
                                {
                                    if (All_Lines[i].Contains("A, off(00152h)"))
                                    {
                                        string CurrentCmd = All_Lines[i + 6];
                                        if (CurrentCmd.Contains("#"))
                                        {
                                            CurrentCmd = CurrentCmd.Substring(CurrentCmd.IndexOf("#") + 5, 4);
                                            InjLocation = int.Parse(CurrentCmd, System.Globalization.NumberStyles.HexNumber);
                                            InjFound = true;
                                            ModsCount++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                if (ModsCount == 0)
                {
                    MessageBox.Show(Form.ActiveForm, "Can't find location for anything", "BMTune");
                }
                else
                {
                    if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "True")
                    {
                        if (!LFuelFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nLOW - Fuel", "BMTune");
                        if (!HFuelFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nHIGH - Fuel", "BMTune");
                    }
                    if (dataGridView1.Rows[1].Cells[0].Value.ToString() == "True")
                    {
                        if (!LIgnFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nLOW - Ignition", "BMTune");
                        if (!HIgnFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nHIGH - Ignition", "BMTune");
                    }
                    if (dataGridView1.Rows[2].Cells[0].Value.ToString() == "True")
                    {
                        if (!mBarScalarFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nmBar Scalar", "BMTune");
                        if (!LRPMFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nLOW RPM", "BMTune");
                        if (!HRPMFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nHIGH RPM", "BMTune");
                    }
                    if (baserom != "P13")
                    {
                        if (dataGridView1.Rows[3].Cells[0].Value.ToString() == "True")
                        {
                            if (!InjFound) MessageBox.Show(Form.ActiveForm, "Can't find location for\nInjector Deadtime", "BMTune");
                        }
                    }
                }
            }
        }
        else
        {
            MessageBox.Show(Form.ActiveForm, "Can't reconize the baserom type", "BMTune");
        }
    }

    public void Load_Bytes()
    {
        //Getting Bytes
        Final_LFuel = new byte[504];
        Final_HFuel = new byte[504];
        Final_LIgn = new byte[480];
        Final_HIgn = new byte[480];

        Final_mBar = new byte[24];

        Final_LRPM = new byte[20];
        Final_HRPM = new byte[20];

        Final_Inj = new byte[21];

        if (ModsCount > 0)
        {
            //####################################
            //Low - Fuel
            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "True")
            {
                CurrentIndex = 0;
                CurrentDone = 0;
                if (LFuelFound)
                {
                    if (!Boosted)
                    {
                        int TableLenght = 21;
                        if (baserom == "P13") TableLenght = 20;

                        for (int i = 0; i < TableLenght; i++)
                        {
                            byte LastByte = 0;

                            //Add 10x of the current correct value
                            for (int i2 = 0; i2 < 10; i2++)
                            {
                                Final_LFuel[CurrentIndex] = File_Byte[LFuelLocation + CurrentDone];
                                if (i2 == 9) LastByte = File_Byte[LFuelLocation + CurrentDone];

                                CurrentIndex++;
                                CurrentDone++;
                            }

                            //Add 14x of the Last rows bytes
                            for (int i2 = 0; i2 < 14; i2++)
                            {
                                Final_LFuel[CurrentIndex] = LastByte;
                                CurrentIndex++;
                            }
                        }

                        //P13 doesn't have the low rows for fueling, lets add it manually
                        if (baserom == "P13")
                        {
                            Final_LFuel[CurrentIndex] = 0x01; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x03; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x04; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x06; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x0a; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x0e; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x11; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x12; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x13; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x14; CurrentIndex++;

                            /*Final_LFuel[CurrentIndex] = 0x01; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x03; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x04; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x05; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x06; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x07; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x08; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x09; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x09; CurrentIndex++;
                            Final_LFuel[CurrentIndex] = 0x0a; CurrentIndex++;

                            001h,003h,004h,006h,009h,00Ch,00Dh,00Fh ; 708D
                            010h,011h,00Bh,00Bh,00Bh,00Bh,00Bh,00Bh ; 7095
                            00Bh,00Bh,00Bh,00Bh,00Bh,00Bh ; 709D
                             
                             */

                            for (int i2 = 0; i2 < 14; i2++)
                            {
                                Final_LFuel[CurrentIndex] = 0x14;
                                //Final_LFuel[CurrentIndex] = 0x0a;
                                CurrentIndex++;
                            }
                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < Final_LFuel.Length; i2++) Final_LFuel[i2] = File_Byte[LFuelLocation + i2];
                    }
                }

                //####################################
                //High - Fuel
                CurrentIndex = 0;
                CurrentDone = 0;
                if (HFuelFound)
                {
                    if (!Boosted)
                    {
                        int TableLenght = 21;
                        if (baserom == "P13") TableLenght = 20;

                        for (int i = 0; i < TableLenght; i++)
                        {
                            byte LastByte = 0;

                            //Add 10x of the current correct value
                            for (int i2 = 0; i2 < 10; i2++)
                            {
                                Final_HFuel[CurrentIndex] = File_Byte[HFuelLocation + CurrentDone];
                                if (i2 == 9) LastByte = File_Byte[HFuelLocation + CurrentDone];

                                //P72 has 15x rows for High CAM instead of 20x
                                if (i >= 14 && baserom == "P72")
                                {
                                    Final_HFuel[CurrentIndex] = File_Byte[HFuelLocation + 140 + i2];
                                    if (i2 == 9) LastByte = File_Byte[HFuelLocation + 140 + i2];

                                    if (i >= 20 && baserom == "P72")
                                    {
                                        Final_HFuel[CurrentIndex] = File_Byte[HFuelLocation + 150 + i2];
                                        if (i2 == 9) LastByte = File_Byte[HFuelLocation + 150 + i2];
                                    }
                                }

                                CurrentIndex++;
                                CurrentDone++;
                            }

                            //Add 14x of the Last rows bytes
                            for (int i2 = 0; i2 < 14; i2++)
                            {
                                Final_HFuel[CurrentIndex] = LastByte;
                                CurrentIndex++;
                            }
                        }

                        //P13 doesn't have the low rows for fueling, lets add it manually
                        if (baserom == "P13")
                        {
                            Final_HFuel[CurrentIndex] = 0x01; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x03; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x04; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x07; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x0d; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x11; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x14; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x15; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x16; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x17; CurrentIndex++;

                            /*Final_HFuel[CurrentIndex] = 0x01; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x03; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x04; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x05; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x06; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x07; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x08; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x09; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x09; CurrentIndex++;
                            Final_HFuel[CurrentIndex] = 0x0a; CurrentIndex++;*/

                            for (int i2 = 0; i2 < 14; i2++)
                            {
                                Final_HFuel[CurrentIndex] = 0x14;
                                //Final_HFuel[CurrentIndex] = 0x0a;
                                CurrentIndex++;
                            }
                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < Final_HFuel.Length; i2++) Final_HFuel[i2] = File_Byte[HFuelLocation + i2];
                    }
                }
            }

            //####################################
            //Low - Ignition
            if (dataGridView1.Rows[1].Cells[0].Value.ToString() == "True")
            {
                CurrentIndex = 0;
                CurrentDone = 0;
                if (LIgnFound)
                {
                    if (!Boosted)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            byte LastByte = 0;

                            //Add 10x of the current correct value
                            for (int i2 = 0; i2 < 10; i2++)
                            {
                                Final_LIgn[CurrentIndex] = File_Byte[LIgnLocation + CurrentDone];
                                if (i2 == 9) LastByte = File_Byte[LIgnLocation + CurrentDone];

                                CurrentIndex++;
                                CurrentDone++;
                            }

                            //Add 14x of the Last rows bytes
                            for (int i2 = 0; i2 < 14; i2++)
                            {
                                Final_LIgn[CurrentIndex] = LastByte;
                                CurrentIndex++;
                            }
                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < Final_LIgn.Length; i2++) Final_LIgn[i2] = File_Byte[LIgnLocation + i2];
                    }
                }

                //####################################
                //High - Ignition
                CurrentIndex = 0;
                CurrentDone = 0;
                if (HIgnFound)
                {
                    if (!Boosted)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            byte LastByte = 0;

                            //Add 10x of the current correct value
                            for (int i2 = 0; i2 < 10; i2++)
                            {
                                Final_HIgn[CurrentIndex] = File_Byte[HIgnLocation + CurrentDone];
                                if (i2 == 9) LastByte = File_Byte[HIgnLocation + CurrentDone];

                                //P72 has 15x rows for High CAM instead of 20x
                                if (i >= 14 && baserom == "P72")
                                {
                                    Final_HIgn[CurrentIndex] = File_Byte[HIgnLocation + 140 + i2];
                                    if (i2 == 9) LastByte = File_Byte[HIgnLocation + 140 + i2];
                                }

                                CurrentIndex++;
                                CurrentDone++;
                            }

                            //Add 14x of the Last rows bytes
                            for (int i2 = 0; i2 < 14; i2++)
                            {
                                Final_HIgn[CurrentIndex] = LastByte;
                                CurrentIndex++;
                            }
                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < Final_HIgn.Length; i2++) Final_HIgn[i2] = File_Byte[HIgnLocation + i2];
                    }
                }
            }

            //####################################
            //mBar Scalar
            if (dataGridView1.Rows[2].Cells[0].Value.ToString() == "True")
            {
                CurrentIndex = 0;
                CurrentDone = 0;
                if (mBarScalarFound)
                {
                    if (!Boosted)
                    {
                        byte LastByte = 0;

                        //Add 10x of the current correct value
                        for (int i2 = 0; i2 < 10; i2++)
                        {
                            //in BMTune mBar = Byte * 8
                            //in Crome mBar = Byte * 4 + 96

                            int ThisValue = File_Byte[mBarScalarLocation + CurrentDone];
                            if (i2 == 9 && ThisValue == 0) ThisValue = 255;

                            ThisValue = (ThisValue * 4) + 114 + 88;
                            byte ThisB = (byte)(ThisValue / 8);

                            //float Divider = ((float) this.class18_0.class10_0.int_6 + 70f) / 1790f;
                            //int ThisValue = File_Byte[mBarScalarLocation + CurrentDone];
                            //if (i2 == 9 && ThisValue == 0) ThisValue = 255;
                            //byte ThisB = (byte)(ThisValue * Divider);
                            // byte ThisB = (byte)(ThisValue * 3 + 114);

                            //set 1st rows to 127 mBar
                            //if (i2 == 0 && ThisValue == 0) ThisB = 0x1b;

                            Final_mBar[CurrentIndex] = ThisB;
                            if (i2 == 9) LastByte = ThisB;

                            CurrentIndex++;
                            CurrentDone++;
                        }

                        //Add 14x of the Last rows bytes
                        for (int i2 = 0; i2 < 14; i2++)
                        {
                            Final_mBar[CurrentIndex] = LastByte;
                            if (i2 == 13) Final_mBar[CurrentIndex] = 0;

                            CurrentIndex++;
                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < Final_mBar.Length; i2++) Final_mBar[i2] = File_Byte[mBarScalarLocation + i2];
                    }
                }

                //####################################
                //LOW RPM
                if (LRPMFound)
                {
                    CurrentIndex = 0;

                    for (int i2 = 0; i2 < 20; i2++)
                    {
                        if (baserom == "P13")
                        {
                            int ThisValue = File_Byte[LRPMLocation + CurrentIndex];
                            CurrentIndex++;
                            ThisValue = ThisValue + (File_Byte[LRPMLocation + CurrentIndex] * 0xff);
                            CurrentIndex++;
                            
                            int ThisRPM = 1875000 / ThisValue;

                            int num = this.class18_0.method_216(ThisRPM);
                            if ((num == 0xff) && (i2 > 0)) num = 0;

                            Final_LRPM[i2] = (byte) num;
                        }
                        else
                        {
                            //float Divider = (9000f / 11050f);
                            float Divider = 1f;
                            int ThisValue = File_Byte[LRPMLocation + i2];
                            byte ThisB = (byte)(ThisValue * Divider);

                            Final_LRPM[i2] = ThisB;
                        }
                    }
                }

                //####################################
                //HIGH RPM
                if (HRPMFound)
                {
                    for (int i2 = 0; i2 < 20; i2++)
                    {
                        if (baserom == "P13")
                        {
                            int ThisValue = File_Byte[LRPMLocation + CurrentIndex];
                            CurrentIndex++;
                            ThisValue = ThisValue + (File_Byte[LRPMLocation + CurrentIndex] * 0xff);
                            CurrentIndex++;

                            int ThisRPM = 1875000 / ThisValue;

                            int num = this.class18_0.method_216(ThisRPM);
                            if ((num == 0xff) && (i2 > 0)) num = 0;

                            Final_HRPM[i2] = (byte)num;
                        }
                        else
                        {
                            //float Divider = (9000f / 11050f);
                            float Divider = 0.82f;
                            int ThisValue = File_Byte[HRPMLocation + i2];
                            if (i2 == 19 && ThisValue == 0) ThisValue = 0xff;

                            //P72 has 15x rows for High CAM instead of 20x
                            if (i2 >= 14 && baserom == "P72")
                            {
                                ThisValue = File_Byte[HRPMLocation + 14];
                                if (i2 >= 14 && ThisValue == 0) ThisValue = 0xff;
                            }

                            Final_HRPM[i2] = (byte)(ThisValue * Divider);
                        }
                    }
                }
            }

            //####################################
            //Injector Deatime
            if (baserom != "P13")
            {
                if (dataGridView1.Rows[3].Cells[0].Value.ToString() == "True")
                {
                    if (InjFound)
                    {
                        for (int i2 = 0; i2 < 21; i2++) Final_Inj[i2] = File_Byte[InjLocation + i2];
                    }
                }
            }
        }
    }


    public void Apply_Bytes()
    {
        if (ModsCount > 0)
        {
            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "True")
            {
                if (LFuelFound) for (int i = 0; i < Final_LFuel.Length; i++) File_Byte_BMTune[0x6ead + i] = Final_LFuel[i];
                if (HFuelFound) for (int i = 0; i < Final_HFuel.Length; i++) File_Byte_BMTune[0x70a5 + i] = Final_HFuel[i];
            }
            if (dataGridView1.Rows[1].Cells[0].Value.ToString() == "True")
            {
                if (LIgnFound) for (int i = 0; i < Final_LIgn.Length; i++) File_Byte_BMTune[0x729d + i] = Final_LIgn[i];
                if (HIgnFound) for (int i = 0; i < Final_HIgn.Length; i++) File_Byte_BMTune[0x747d + i] = Final_HIgn[i];
            }
            if (dataGridView1.Rows[2].Cells[0].Value.ToString() == "True")
            {
                if (mBarScalarFound) for (int i = 0; i < Final_mBar.Length; i++) File_Byte_BMTune[0x6e59 + i] = Final_mBar[i];
                if (LRPMFound) for (int i = 0; i < Final_LRPM.Length; i++) File_Byte_BMTune[0x6e71 + i] = Final_LRPM[i];
                if (HRPMFound) for (int i = 0; i < Final_HRPM.Length; i++) File_Byte_BMTune[0x6e85 + i] = Final_HRPM[i];
            }
            if (baserom != "P13")
            {
                if (dataGridView1.Rows[3].Cells[0].Value.ToString() == "True")
                {
                    if (InjFound) for (int i = 0; i < Final_Inj.Length; i++) File_Byte_BMTune[0x6442 + i] = Final_Inj[i];
                }
            }

            File_Byte_BMTune[0x61FB] = (byte)ColumnNumber;
        }
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvert));
            this.labelProductName = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Baserom = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.Location = new System.Drawing.Point(119, 10);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 18);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(165, 18);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Baserom Converter";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.AutoSize = true;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(306, 445);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 25);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Baserom Type :";
            // 
            // label_Baserom
            // 
            this.label_Baserom.AutoSize = true;
            this.label_Baserom.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Baserom.Location = new System.Drawing.Point(125, 62);
            this.label_Baserom.Name = "label_Baserom";
            this.label_Baserom.Size = new System.Drawing.Size(77, 15);
            this.label_Baserom.TabIndex = 27;
            this.label_Baserom.Text = "Crome Gold";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(13, 145);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(380, 244);
            this.dataGridView1.TabIndex = 29;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "True";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 25;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Parameters";
            this.Column2.Name = "Column2";
            this.Column2.Width = 352;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "New File Name :";
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(122, 86);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(265, 20);
            this.textBox_FileName.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(74, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "Convert others types of Baserom to BMTune";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(47, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "** Select which Parameters you want to convert **";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(13, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "Cancel";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(59, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 45);
            this.label3.TabIndex = 35;
            this.label3.Text = "** NOT ALL PARAMETERS WILL BE CONVERTED **\r\n\r\nUSE AT YOUR OWN RISK";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 483);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_FileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_Baserom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConvert";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Baserom Converter";
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

    private void okButton_Click(object sender, EventArgs e)
    {
        if (Baserom != "eCtune") MessageBox.Show(Form.ActiveForm, "NOT all parameters going to be converted\nCheck again all parameters after the convertion!", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Convert();
        this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}

