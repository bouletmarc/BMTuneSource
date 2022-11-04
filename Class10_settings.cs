using Dal.Settings;
using Data;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

internal class Class10_settings
{
    public AirFuelUnits airFuelUnits_0;
    public bool bool_10;
    public bool bool_11;
    public bool bool_12;
    public bool bool_15;
    public bool bool_20_ONLY_NA_VIEW;
    public bool bool_21;
    public bool bool_23;
    public bool bool_24 = true;
    public bool bool_25;
    public bool bool_26 = true;
    public bool bool_27;
    public bool bool_28;
    public bool bool_3 = true;
    public bool bool_31 = true;
    public bool bool_32 = true;
    public bool bool_33 = true;
    public bool Emu_AutoScan = true;
    public bool Emu_AlwaysRT = true;
    public bool bool_36;
    public bool bool_38;
    public bool bool_40;
    public bool bool_42 = true;
    public bool bool_43 = true;
    public bool bool_44 = true;
    public bool bool_45 = true;
    public bool[] bool_46 = new bool[] { false, true, true, true, true, true };
    public bool bool_47;
    public bool bool_48 = true;
    public bool bool_49 = false;
    //public bool bool_5 = true;    //show emu progress
    public bool bool_51 = false;
    public bool bool_6;
    public bool bool_7;
    public bool bool_8;
    public bool chkEmuVendor = true;
    public bool LogAdvancedDatas = false;

    public bool bool_CheckJ12 = false;

    //AFR, Graph, Data, Gauges, Table Grid, Live Plots, Tracing
    public int DatalogCurrentPreset = 1;
    public bool DatalogThreadEnabled = false;
    public bool[] bool_ActiveDatalog = new bool[] { true, true, true, true, true, true, true };
    public int[] int_ActiveDatalog = new int[] { 0, 0, 0, 0, 0, 0, 0 };
    //public int[] int_ActiveDatalog = new int[] { 70, 70, 70, 70, 70, 70, 70 };

    //Same as Above (better overall)
    public bool[] bool_ActiveDatalog_Preset1 = new bool[] { true, true, true, true, true, true, true };
    public int[] int_ActiveDatalog_Preset1 = new int[] { 0, 0, 0, 0, 0, 0, 0 };
    //public int[] int_ActiveDatalog_Preset1 = new int[] { 70, 70, 70, 70, 70, 70, 70 };
    //better in tables
    public bool[] bool_ActiveDatalog_Preset2 = new bool[] { true, true, true, true, true, false, true };
    public int[] int_ActiveDatalog_Preset2 = new int[] { 10, 70, 70, 70, 10, 100, 10 };
    //better for Datas and gauges
    public bool[] bool_ActiveDatalog_Preset3 = new bool[] { true, true, true, true, true, false, true };
    public int[] int_ActiveDatalog_Preset3 = new int[] { 70, 70, 20, 20, 70, 100, 70 };
    //better for graphing
    public bool[] bool_ActiveDatalog_Preset4 = new bool[] { true, true, true, true, true, true, true };
    public int[] int_ActiveDatalog_Preset4 = new int[] { 70, 15, 45, 50, 70, 15, 70 };

    //public bool IsNeptuneRTP = false;

    public ChartCollection chartCollection_0;
    private Class10_settings class10_0;
    private Class18 class18_0;
    public Color color_Trace = Color.FromArgb(128, 128, 255); //trace
    public Color color_Trail = Color.FromArgb(205, 205, 255); //trail
    public Color color_2 = Color.Blue;
    public Color color_3 = Color.FromArgb(75, 75, 75);    //3d/2d graph back
    public Color color_4 = Color.Black;
    public Color color_On = Color.FromArgb(190, 255, 190); //Led On
    public Color color_OnDark = Color.FromArgb(0, 175, 0); //Led On
    public Color color_Off = Color.FromArgb(215, 120, 120); //Led Off
    public Color color_7 = Color.FromArgb(220, 240, 255);
    public Color color_8 = Color.FromArgb(170, 230, 235);
    public Color color_9 = Color.LightCoral;
    public Color color_10 = Color.CornflowerBlue;
    public Color color_11 = Color.FromArgb(235, 235, 235);      //2D/3D Text color
    public Color color_12 = Color.FromArgb(255, 255, 200);      //Plot 2D/3D color1
    public Color color_13 = Color.FromArgb(200, 255, 200);      //Plot 2D/3D color2
    public Color color_14 = Color.FromArgb(175, 175, 175);      //2D/3D Text color #2

    public Color color_20 = Color.FromArgb(185, 255, 255);       //Fuel Color 0-15%
    public Color color_21 = Color.FromArgb(200, 255, 200);      //Fuel Color 15-60%
    public Color color_22 = Color.FromArgb(255, 255, 200);      //Fuel Color 60-100%
    public Color color_23 = Color.FromArgb(255, 80, 80);          //Fuel Color 100%

    public Color color_30 = Color.FromArgb(185, 255, 255);       //Ign Color -6 to 0
    public Color color_31 = Color.FromArgb(200, 255, 200);      //Ign Color 0 to 30
    public Color color_32 = Color.FromArgb(255, 255, 200);      //Ign Color 30 to 60
    public Color color_33 = Color.FromArgb(255, 80, 80);          //Ign Color 60
    
    public Color color_40 = Color.FromArgb(255, 200, 200);       //VE Color  -100 to 0
    public Color color_41 = Color.FromArgb(200, 255, 255);      //VE Color 0 to 100

    public int PercentColor1 = 8;
    public int PercentColor2 = 38;
    public int PercentColorIgn = 50;

    public int AccelTimerSpeedStart = 3;
    public int AccelTimerSpeedEnd = 100;

    public int GlitchedBaseromTestInterval = 15000;     //30279

    public List<string> ShortcutsKeys = new List<string>();

    public float scaleRate = 100;

    public CorrectionUnits correctionUnits_0;
    public DataloggingMode dataloggingMode_0 = DataloggingMode.datalogMultiByteX;
    public DataloggingTable dataloggingTable_0;
    public DataloggingTable dataloggingTable_1;
    public double[] double_0  = new double[] { 0.0, 1.3, 0.3, 1.0, 0.7, 1.0, 1.0, 0.71 };
    public double[] double_1 = new double[] { 1.3, 0.0, 1.0, 0.3, 1.0, 0.7, 0.71, 1.0 };
    public double double_10;
    public double double_11;
    public double double_12;
    public double double_13 = 1.5;
    public double double_14 = 10.0;
    public double double_15 = 0.75;
    public double double_2;
    public double double_3 = 14.75;
    public double[] double_4 = new double[] { 0.0, 5.0 };
    public double[] double_5 = new double[] { 0.0, 5.0 };
    public double[] double_6 = new double[] { 0.0, 5.0 };
    public double double_7;
    public double double_8;
    public double double_9 = 1.5;
    public EmulatorMode emulatorMode_0 = EmulatorMode.Demon;
    public float float_0;
    public float float_1;
    public float float_2;
    public float float_3;
    public float float_4;
    public float float_5;
    public float float_6 = 0.03f;
    public float float_7 = 14.25f;
    public float float_8 = 8.25f;
    public int int_0 = 111; // Sensors Numbers  ####    96 = Old Number
    public int int_1;
    public int int_10;
    public int Datalog_Baud = 0x9600;
    public int Emulator_Baud = 0xe1000;
    public int int_2;
    public int int_2_LivePlot = 2;
    public int int_20 = 100;
    public int int_21 = 3;
    public int int_22 = 2;  //analog1 decimals
    public int int_23 = 2;  //analog2 decimals
    public int int_24 = 2;  //analog3 decimals
    public int int_25 = 0;
    public int int_26;
    public int int_27;
    public int int_28;
    public int int_29;
    public int int_3 = 100;
    public int int_30;
    public int int_31;
    public int int_32;
    public int int_33;
    public int int_34;
    public int int_35;
    public int int_36 = 25;
    public int int_37 = 0;
    public int int_38;
    public int int_39;
    public int int_4 = 60;
    public int int_40 = 1;
    public int int_41 = 5;
    public int int_5 = 200;
    public int int_55;
    public int int_56;
    public int int_57;
    public int int_58;
    public int int_59;
    public int int_6 = 0x3f5;
    public int int_60;
    public int int_61;
    public int int_62;
    public int int_8;
    public int int_9;
    public int int_GraphSensor = 0;
    public int int_GraphColumns = 14;
    public int SplitterDistance;
    public MapGraphSelect mapGraphSelect_0 = MapGraphSelect.fill;
    public MapSensorUnits mapSensorUnits_0;
    public MapSensorUnits mapSensorUnits_1;
    public SensorsX sensors_0 = SensorsX.boostX;
    public SensorsX sensors_1 = SensorsX.injDuty;
    public SensorsX sensors_2 = SensorsX.injDur;
    private SettingsKey settingsKey_0;
    public string[] string_0 = new string[10];
    public string[] string_VW = new string[10];
    public string[] string_XDF = new string[10];
    public string string_1 = "";
    public string string_2 = "";
    public string string_4 = "";
    public string string_5 = "";
    public string string_6 = "";
    public string Password = "";
    public bool Protect = false;
    public bool PasswordHiden = false;
    public TemperatureUnits temperatureUnits_0 = TemperatureUnits.C;
    public VssUnits vssUnits_0;
    public WBinput wbinput_0;
    public Wideband_Serial wideband_Serial_0;

    public int LastPackageChecksum = 0;
    public int BurnerSoftware = 0;      //0=internal, 1=Moates Flash&Burn, 2=MiniPro
    public string BurnerLocation = "";

    public bool OverlayConditionsDisabled = true;
    public bool LogDatetime = true;

    public bool ToolbarFile = true;
    public bool ToolbarEdit = true;
    public bool ToolbarEmulator = true;
    public bool ToolbarDatalog = true;
    public bool ToolbarView = true;
    public bool ToolbarTools = true;

    public bool ShownDockedMode = false;

    public string ICutModInstall = "";

    public bool LiveGraphing = false;
    public int LiveGraph_Lenght = 800;
   
    public int burnChipIndex = 0;
    public int burnCommCache = 0;
    public string calFilePath = "";

    public Point dataloggingToolStrip = new Point(165, 49);
    public Point mainToolStrip = new Point(3, 24);
    public Point viewToolStrip = new Point(3, 74);
    public Point editToolStrip = new Point(220, 24);
    public Point windowsToolStrip = new Point(275, 74);
    public Point emulatorToolStrip = new Point(3, 49);

    public Point tunerToolStrip = new Point(3, 0);
    public Point tableEditToolStrip = new Point(175, 0);
    public Point tableViewToolStrip = new Point(3, 25);

    public Point Display_Location = new Point(375, 105);
    public Point logGraphs_Location = new Point(260, 500);
    public Point logGrid_Location = new Point(0, 105);
    public Point parameters_Location = new Point(320, 250);
    public Point tables_Location = new Point(260, 210);
    public Point Debug_Location = new Point(80, 80);
    public Point errorCodes_Location = new Point(80, 80);
    public Point LivePlot_Location = new Point(260, 500);
    public Point snapShots_Location = new Point(80, 80);
    public Point ActiveDatalog_Location = new Point(80, 80);
    public Point DynoC_Location = new Point(80, 80);

    public Size Display_Size = new Size(650, 130);
    public Size logGraphs_Size = new Size(750, 250);
    public Size logGrid_Size = new Size(255, 600);
    public Size parameters_Size = new Size(570, 570);
    public Size tables_Size = new Size(750, 435);
    public Size Debug_Size = new Size(358, 311);
    public Size errorCodes_Size = new Size(150, 150);
    public Size LivePlot_Size = new Size(750, 435);
    public Size ActiveDatalog_Size = new Size(358, 311);
    public Size DynoC_Size = new Size(150, 200);

    public int dtCommCache = 0;
    public bool dtPeakShown = true;
    public int emuCommCache = 0;
    public string logFilePath = "";
    public int overlay1_Display = 3;
    public int overlay2_Display = 3;
    public int overlay3_Display = 3;
    public string parameterNode = "";
    public string romFilePath = "";
    public int tunerSmartTrack = 1;

    public bool IsBluetooth = false;

    public bool WindowedMode = false;
    public string Tabs1_Names = "";
    public string Tabs2_Names = "";
    public string Tabs3_Names = "";
    public string Tabs4_Names = "";
    public string Tabs5_Names = "";
    public bool Tabs3_Show = true;
    public bool Tabs4_Show = true;
    public bool Tabs5_Show = false;
    public int TabsLeft_Split = 252;
    public int TabsTop_Split = 104;
    public int TabsBottom_Split = 432;
    public int TabsBottomLeft_Split = 540;
    public int TabsRight_Split = 450;
    public int Tabs1_Selected = 0;
    public int Tabs2_Selected = 0;
    public int Tabs3_Selected = 0;
    public int Tabs4_Selected = 0;
    public int Tabs5_Selected = 0;

    public int BoostFuel = 120;
    public float BoostRetard = 1;

    public int BoostIGNStep1 = 0;
    public int BoostIGNStep2 = 3;
    public int BoostIGNStep3 = 5;
    public int BoostIGNStep4 = 7;
    public int BoostIGNStep5 = 12;
    public int BoostIGNStep6 = 30;

    public double BoostIGNRetard1 = 0.08;
    public double BoostIGNRetard2 = 0.15;
    public double BoostIGNRetard3 = 0.25;
    public double BoostIGNRetard4 = 0.5;
    public double BoostIGNRetard5 = 0.75;

    public int Parameter_Splitter = 250;

    public event Delegate14 delegate14_0;
    public event Delegate12 delegate12_0;
    public event Delegate10 delegate10_0;
    public event Delegate13 delegate13_0;

    public List<string> SensorsTags;
    public List<string> SensorsNames;
    public List<string> SensorsDesc;
    public List<int> SensorsMin;
    public List<int> SensorsMax;

    public List<int> SensorsCustomMin;
    public List<int> SensorsCustomMax;
    public List<bool> SensorsCustomINT;

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\SettingsV2.xml";

    public string LastGraphSavePath = "";

    public FrmMain frmMain_0;

    public bool Shortcut_PressCTRL = false;
    public bool Shortcut_PressALT = false;
    public bool Shortcut_PressSHIFT = false;
    public Keys Shortcut_KeyPressed = (Keys)0;
    public string Shortcut_KeyName = "";

    public string Dyno_COMPORTDyno = "";
    public string Dyno_COMPort = "";
    public string Dyno_COMPortBC = "";
    public string Dyno_AUX1Type = "";
    public string Dyno_AUX2Type = "";
    public string Dyno_AUX3Type = "";
    public string Dyno_AUXMIN1V = "";
    public string Dyno_AUXMIN2V = "";
    public string Dyno_AUXMIN3V = "";
    public string Dyno_AUXMAX1V = "";
    public string Dyno_AUXMAX2V = "";
    public string Dyno_AUXMAX3V = "";
    public string Dyno_AUXMIN1O = "";
    public string Dyno_AUXMIN2O = "";
    public string Dyno_AUXMIN3O = "";
    public string Dyno_AUXMAX1O = "";
    public string Dyno_AUXMAX2O = "";
    public string Dyno_AUXMAX3O = "";

    public bool ShownHint_Gauges = false;
    public bool ShownHint_Colors = false;
    public bool ShownHint_Separator = false;
    public bool ShownHint_Dragging = false;
    public bool ShownHint_DebugLogs = false;

    public Class10_settings(ref FrmMain FrmMain_1)
    {
        this.class10_0 = this;
        this.frmMain_0 = FrmMain_1;

        string_1 = "COM1";
        string_2 = "COM1";
        string_4 = "V";
        string_5 = "V";
        string_6 = "V";

        Tabs1_Names = "Datalog,Debug Logs,";
        Tabs2_Names = "Tables,Parameters,Snapshots,";
        Tabs3_Names = "Graph,LivePlot,";
        Tabs4_Names = "CEL,Datalogs Threads,Dyno,";

        Dyno_COMPort = "COM1";
        Dyno_COMPortBC = "COM2";
        Dyno_AUX1Type = "AFR";
        Dyno_AUX2Type = "Voltage";
        Dyno_AUX3Type = "Voltage";
        Dyno_AUXMIN1V = "0";
        Dyno_AUXMIN2V = "0";
        Dyno_AUXMIN3V = "0";
        Dyno_AUXMAX1V = "5";
        Dyno_AUXMAX2V = "5";
        Dyno_AUXMAX3V = "5";
        Dyno_AUXMIN1O = "10";
        Dyno_AUXMIN2O = "0";
        Dyno_AUXMIN3O = "0";
        Dyno_AUXMAX1O = "20";
        Dyno_AUXMAX2O = "5";
        Dyno_AUXMAX3O = "5";

        //Transfert .preset files into .txt
        string path1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\display.preset";
        string path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Graph.preset";
        string path3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Target_AFR.preset";
        string path4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\templates.preset";  //not used anywhere, only remove

        string path1_2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\display.txt";
        string path2_2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Graph.txt";
        string path3_2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Target_AFR.txt";

        if (File.Exists(path1)) { File.Create(path1_2).Dispose(); File.WriteAllBytes(path1_2, File.ReadAllBytes(path1)); File.Delete(path1); }
        if (File.Exists(path2)) { File.Create(path2_2).Dispose(); File.WriteAllBytes(path2_2, File.ReadAllBytes(path2)); File.Delete(path2); }
        if (File.Exists(path3)) { File.Create(path3_2).Dispose(); File.WriteAllBytes(path3_2, File.ReadAllBytes(path3)); File.Delete(path3); }
        if (File.Exists(path4)) { File.Delete(path4); }

        LoadShortcuts();

        this.method_6();
        if (!File.Exists(path)) Reset_Default();
        try
        {
            SettingsFile.Create(path);
            this.method_list();
        }
        catch (Exception message)
        {
            MessageBox.Show(Form.ActiveForm, "Unable to load Settings correctly, Settings will be resetting to default!" + Environment.NewLine + "" + Environment.NewLine + "" + Environment.NewLine + "" + message);
            Reset_Default();
        }


        //Reset ECT and IAT Max Sensor Value was set at 0 instead of 140
        for (int i = 0; i < 2; i++)
        {
            SensorsX ThisSensor = SensorsX.ectX;
            if (i == 1) ThisSensor = SensorsX.iatX;

            int VLu = this.method_22_Max(ThisSensor);
            if (this.temperatureUnits_0 == TemperatureUnits.F) VLu = (int)this.class18_0.method_242(this.method_22_Max(ThisSensor));
            if (VLu < 140)
            {
                if (this.temperatureUnits_0 == TemperatureUnits.F) this.method_23_Max(ThisSensor, (int) this.class18_0.method_242(140));
                else this.method_23_Max(ThisSensor, 140);
            }
            //#######################
            VLu = this.method_20_Min(ThisSensor);
            if (this.temperatureUnits_0 == TemperatureUnits.F) VLu = (int)this.class18_0.method_242(this.method_20_Min(ThisSensor));
            if (VLu > -40)
            {
                if (this.temperatureUnits_0 == TemperatureUnits.F) this.method_21_Min(ThisSensor, (int)this.class18_0.method_242(-40));
                else this.method_21_Min(ThisSensor, -40);
            }
            //#######################
            VLu = this.method_22(ThisSensor);
            if (this.temperatureUnits_0 == TemperatureUnits.F) VLu = (int)this.class18_0.method_242(this.method_22(ThisSensor));
            if ((VLu < 60 && ThisSensor == SensorsX.ectX)
                || (VLu < 30 && ThisSensor == SensorsX.iatX))
            {
                if (ThisSensor == SensorsX.ectX)
                {
                    if (this.temperatureUnits_0 == TemperatureUnits.F) this.method_23(ThisSensor, (int)this.class18_0.method_242(110));
                    else this.method_23(ThisSensor, 110);
                }
                if (ThisSensor == SensorsX.iatX)
                {
                    if (this.temperatureUnits_0 == TemperatureUnits.F) this.method_23(ThisSensor, (int)this.class18_0.method_242(100));
                    else this.method_23(ThisSensor, 100);
                }
            }
            //#######################
            VLu = this.method_20(ThisSensor);
            if (this.temperatureUnits_0 == TemperatureUnits.F) VLu = (int)this.class18_0.method_242(this.method_20(ThisSensor));
            if ((VLu < 60 && ThisSensor == SensorsX.ectX)
                || (VLu < 30 && ThisSensor == SensorsX.iatX))
            {
                if (ThisSensor == SensorsX.ectX)
                {
                    if (this.temperatureUnits_0 == TemperatureUnits.F) this.method_21(ThisSensor, (int)this.class18_0.method_242(100));
                    else this.method_21(ThisSensor, 100);
                }
                if (ThisSensor == SensorsX.iatX)
                {
                    if (this.temperatureUnits_0 == TemperatureUnits.F) this.method_21(ThisSensor, (int)this.class18_0.method_242(65));
                    else this.method_21(ThisSensor, 65);
                }
            }
        }
    }

    public void LoadSettings(string pathnew)
    {
        try
        {
            SettingsFile.Create(pathnew);
            method_1();
            method_3();
            SettingsFile.Create(path);
            MessageBox.Show(Form.ActiveForm, "Settings succesfully loaded!");
        }
        catch
        {
            MessageBox.Show(Form.ActiveForm, "Unable to load settings!");
        }
    }

    public void Reset_Default()
    {
        FileInfo info = new FileInfo(path);
        if (info.Exists) File.Delete(path);
        SettingsFile.Create(path);
        info = null;
        info = new FileInfo(path);
        info.Directory.Create();
        info = null;
        File.Create(path).Dispose();
        this.LoadShortcuts();
        this.method_1();
        this.method_3();
        this.SaveSensors();
        this.method_Reset();

        this.dataloggingMode_0 = DataloggingMode.datalogDemon;
        this.emulatorMode_0 = EmulatorMode.Demon;
        this.bool_31 = true;
        this.string_1 = this.string_2;
        this.Emulator_Baud = 0xe1000;
        this.Datalog_Baud = this.Emulator_Baud;
        this.bool_27 = this.Emu_AlwaysRT;

        this.method_3();

        //this.method_resetWindows();
        SettingsFile.Create(path);
        
        this.method_3();

        frmCopyright frmCopyright_0 = new frmCopyright(ref frmMain_0);
        frmCopyright_0.ShowDialog();
        frmCopyright_0.Dispose();
        frmCopyright_0 = null;
    }

    internal void method_0(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;
    }

    public bool method_1()
    {
        this.settingsKey_0 = SettingsFile.Settings["tuner/scaleRate"];
        this.scaleRate = this.settingsKey_0.GetSetting("value", (float)100f);
        this.settingsKey_0 = SettingsFile.Settings["tuner/ShownDockedMode"];
        this.ShownDockedMode = this.settingsKey_0.GetSetting("value", false);

        this.settingsKey_0 = SettingsFile.Settings["editor/AdjFuelTableFv"];
        this.float_2 = this.settingsKey_0.GetSetting("value", (float) 3f);
        this.settingsKey_0 = SettingsFile.Settings["editor/AdjFuelTablePercent"];
        this.float_1 = this.settingsKey_0.GetSetting("value", (float) 1f);
        this.settingsKey_0 = SettingsFile.Settings["editor/AdjFuelTableFvSwitch"];
        this.float_3 = this.settingsKey_0.GetSetting("value", 300);
        this.settingsKey_0 = SettingsFile.Settings["editor/AdjLambdaTable"];
        this.float_4 = this.settingsKey_0.GetSetting("value", (float) 0.01f);
        this.settingsKey_0 = SettingsFile.Settings["editor/AdjIgnTable"];
        this.float_0 = this.settingsKey_0.GetSetting("value", (float) 0.25f);
        this.settingsKey_0 = SettingsFile.Settings["editor/AdjVeTable"];
        this.float_5 = this.settingsKey_0.GetSetting("value", (float) 1f);
        this.settingsKey_0 = SettingsFile.Settings["editor/Mru"];
        for (int i = 0; i < this.string_0.Length; i++)
        {
            string setting = this.settingsKey_0.GetSetting("file" + i.ToString(), "");
            if (setting != string.Empty) this.string_0[i] = setting;
            else this.string_0[i] = string.Empty;
        }
        this.settingsKey_0 = SettingsFile.Settings["editor/Mruniversal"];
        for (int i = 0; i < this.string_VW.Length; i++)
        {
            string setting = this.settingsKey_0.GetSetting("file" + i.ToString(), "");
            if (setting != string.Empty) this.string_VW[i] = setting;
            else this.string_VW[i] = string.Empty;
        }
        this.settingsKey_0 = SettingsFile.Settings["editor/MruniversalDEF"];
        for (int i = 0; i < this.string_XDF.Length; i++)
        {
            string setting = this.settingsKey_0.GetSetting("file" + i.ToString(), "");
            if (setting != string.Empty) this.string_XDF[i] = setting;
            else this.string_XDF[i] = string.Empty;
        }

        //this.settingsKey_0 = SettingsFile.Settings["editor/ShowTables"];
        //this.method_12(this.settingsKey_0.GetSetting("value", (byte) 20));
        this.settingsKey_0 = SettingsFile.Settings["editor/graphShown"];
        this.bool_6 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/playLogOnOpen"];
        this.bool_7 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/recordOnConnection"];
        this.bool_8 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/windowState"];
        this.int_1 = this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["editor/GraphHorizontal"];
        this.bool_15 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/smoothingThreshold"];
        this.float_6 = this.settingsKey_0.GetSetting("value", (float) 0.03f);

        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsPreset"];
        this.DatalogCurrentPreset = this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["editor/DatalogThreadEnabled"];
        this.DatalogThreadEnabled = this.settingsKey_0.GetSetting("value", false);

        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads"];
        for (int i = 0; i < 7; i++) this.bool_ActiveDatalog[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.bool_ActiveDatalog[i]);
        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay"];
        for (int i = 0; i < 7; i++) this.int_ActiveDatalog[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.int_ActiveDatalog[i]);

        //presets
        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset1"];
        for (int i = 0; i < 7; i++) this.bool_ActiveDatalog_Preset1[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset1[i]);
        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset1"];
        for (int i = 0; i < 7; i++) this.int_ActiveDatalog_Preset1[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset1[i]);

        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset2"];
        for (int i = 0; i < 7; i++) this.bool_ActiveDatalog_Preset2[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset2[i]);
        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset2"];
        for (int i = 0; i < 7; i++) this.int_ActiveDatalog_Preset2[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset2[i]);

        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset3"];
        for (int i = 0; i < 7; i++) this.bool_ActiveDatalog_Preset3[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset3[i]);
        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset3"];
        for (int i = 0; i < 7; i++) this.int_ActiveDatalog_Preset3[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset3[i]);

        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset4"];
        for (int i = 0; i < 7; i++) this.bool_ActiveDatalog_Preset4[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset4[i]);
        this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset4"];
        for (int i = 0; i < 7; i++) this.int_ActiveDatalog_Preset4[i] = this.settingsKey_0.GetSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset4[i]);
        //#####

        this.settingsKey_0 = SettingsFile.Settings["editor/followselected"];
        this.bool_10 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["editor/selectedHeadersTrace"];
        this.bool_11 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["editor/smoothRows"];
        this.bool_12 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/rpmBlock"];
        this.int_3 = this.settingsKey_0.GetSetting("value", 100);

        this.settingsKey_0 = SettingsFile.Settings["editor/stacksize"];
        this.int_36 = this.settingsKey_0.GetSetting("value", 25);
        this.settingsKey_0 = SettingsFile.Settings["editor/stacksizevariance"];
        this.int_41 = this.settingsKey_0.GetSetting("value", 5);

        this.settingsKey_0 = SettingsFile.Settings["editor/rpmPlotTps"];
        this.int_4 = this.settingsKey_0.GetSetting("value", 0x41);
        this.settingsKey_0 = SettingsFile.Settings["editor/timePlotLength"];
        this.int_5 = this.settingsKey_0.GetSetting("value", 200);
        this.settingsKey_0 = SettingsFile.Settings["editor/GraphTypeSelected"];
        this.int_2 = this.settingsKey_0.GetSetting("value", 0);

        this.settingsKey_0 = SettingsFile.Settings["editor/PlotTypeSelected"];
        this.int_2_LivePlot = this.settingsKey_0.GetSetting("value", 2);

        this.settingsKey_0 = SettingsFile.Settings["editor/TraceShowInterpolation"];
        this.bool_21 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/GraphSelectType"];
        this.mapGraphSelect_0 = (MapGraphSelect) this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["units/mbarSeaLevel"];
        this.int_6 = this.settingsKey_0.GetSetting("value", 0x3f5);
        this.settingsKey_0 = SettingsFile.Settings["units/vacumn"];
        this.mapSensorUnits_0 = (MapSensorUnits) this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["units/boost"];
        this.mapSensorUnits_1 = (MapSensorUnits) this.settingsKey_0.GetSetting("value", 4);
        this.settingsKey_0 = SettingsFile.Settings["units/temp"];
        this.temperatureUnits_0 = (TemperatureUnits) this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["units/vss"];
        this.vssUnits_0 = (VssUnits) this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["units/afr"];
        this.airFuelUnits_0 = (AirFuelUnits) this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["units/fuelCorr"];
        this.correctionUnits_0 = (CorrectionUnits) this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["units/usePaSen"];
        this.bool_23 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["wideband/offset"];
        this.double_2 = this.settingsKey_0.GetSetting("value", (float) 0f);
        this.settingsKey_0 = SettingsFile.Settings["wideband/index"];
        this.int_8 = this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["wideband/widebandConversion"];
        if (this.settingsKey_0.GetSettingNames().Length != 0)
        {
            this.double_0 = new double[this.settingsKey_0.GetSettingNames().Length];
            for (int j = 0; j < this.settingsKey_0.GetSettingNames().Length; j++)
            {
                this.double_0[j] = this.settingsKey_0.GetSetting("index" + j.ToString(), this.double_0[j]);
            }
        }
        else
        {
            for (int j = 0; j < this.double_0.Length; j++)
            {
                this.double_0[j] = this.settingsKey_0.GetSetting("index" + j.ToString(), this.double_0[j]);
            }
        }
        this.method_30();
        this.settingsKey_0 = SettingsFile.Settings["wideband/wbInput"];
        this.wbinput_0 = (WBinput) this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["wideband/stoichGas"];
        this.double_3 = this.settingsKey_0.GetSetting("value", (double) 14.7);
        this.settingsKey_0 = SettingsFile.Settings["wideband/stoichLstSel"];
        this.int_9 = this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["wideband/WidebandSerialInput"];
        this.bool_25 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["wideband/WidebandSerialType"];
        this.wideband_Serial_0 = (Wideband_Serial) this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["wideband/WidebandSerialPortIndex"];
        this.int_10 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana1enable"];
        this.bool_36 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana1lbl"];
        this.string_4 = this.settingsKey_0.GetSetting("value", "V");
        this.settingsKey_0 = SettingsFile.Settings["analog/ana1tbl"];

        if (this.settingsKey_0.GetSettingNames().Length > 0) this.double_4 = new double[this.settingsKey_0.GetSettingNames().Length];
        for (int k = 0; k < this.double_4.Length; k++)
        {
            this.double_4[k] = this.settingsKey_0.GetSetting("index" + k.ToString(), this.double_4[k]);
        }
        this.settingsKey_0 = SettingsFile.Settings["analog/ana1dec"];
        this.int_22 = this.settingsKey_0.GetSetting("value", 2);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana2enable"];
        this.bool_38 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana2lbl"];
        this.string_5 = this.settingsKey_0.GetSetting("value", "V");
        this.settingsKey_0 = SettingsFile.Settings["analog/ana2tbl"];

        if (this.settingsKey_0.GetSettingNames().Length > 0) this.double_5 = new double[this.settingsKey_0.GetSettingNames().Length];
        for (int m = 0; m < this.double_5.Length; m++)
        {
            this.double_5[m] = this.settingsKey_0.GetSetting("index" + m.ToString(), this.double_5[m]);
        }
        this.settingsKey_0 = SettingsFile.Settings["analog/ana2dec"];
        this.int_23 = this.settingsKey_0.GetSetting("value", 2);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana3enable"];
        this.bool_40 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana3lbl"];
        this.string_6 = this.settingsKey_0.GetSetting("value", "V");
        this.settingsKey_0 = SettingsFile.Settings["analog/ana3tbl"];

        if (this.settingsKey_0.GetSettingNames().Length > 0) this.double_6 = new double[this.settingsKey_0.GetSettingNames().Length];
        for (int n = 0; n < this.double_6.Length; n++)
        {
            this.double_6[n] = this.settingsKey_0.GetSetting("index" + n.ToString(), this.double_6[n]);
        }
        this.settingsKey_0 = SettingsFile.Settings["analog/ana3dec"];
        this.int_24 = this.settingsKey_0.GetSetting("value", 2);
        this.settingsKey_0 = SettingsFile.Settings["editor/showWarningColor"];
        this.bool_24 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["editor/dispTextPrim"];
        this.float_7 = this.settingsKey_0.GetSetting("value", (float) 14.25f);
        this.settingsKey_0 = SettingsFile.Settings["editor/dispTextSec"];
        this.float_8 = this.settingsKey_0.GetSetting("value", (float) 8.25f);
        
        this.settingsKey_0 = SettingsFile.Settings["color/TraceColor"];
        this.color_Trace = this.settingsKey_0.GetColor("value", Color.FromArgb(128, 128, 255));
        this.settingsKey_0 = SettingsFile.Settings["color/TrailColor"];
        this.color_Trail = this.settingsKey_0.GetColor("value", Color.FromArgb(205, 205, 255));
        this.settingsKey_0 = SettingsFile.Settings["color/selectedColor"];
        this.color_2 = this.settingsKey_0.GetColor("value", Color.Blue);
        this.settingsKey_0 = SettingsFile.Settings["color/dispBackColor"];
        this.color_3 = this.settingsKey_0.GetColor("value", Color.FromArgb(75, 75, 75));
        this.settingsKey_0 = SettingsFile.Settings["color/dispTextColor"];
        this.color_4 = this.settingsKey_0.GetColor("value", Color.Black);
        this.settingsKey_0 = SettingsFile.Settings["color/ledOnColor"];
        this.color_On = this.settingsKey_0.GetColor("value", Color.FromArgb(190, 255, 190));
        this.settingsKey_0 = SettingsFile.Settings["color/ledOnDarkColor"];
        this.color_OnDark = this.settingsKey_0.GetColor("value", Color.FromArgb(0, 175, 0));
        this.settingsKey_0 = SettingsFile.Settings["color/ledOffColor"];
        this.color_Off = this.settingsKey_0.GetColor("value", Color.FromArgb(215, 120, 120));
        this.settingsKey_0 = SettingsFile.Settings["color/BackColor2"];
        this.color_7 = this.settingsKey_0.GetColor("value", Color.FromArgb(200, 230, 255));
        this.settingsKey_0 = SettingsFile.Settings["color/BackColor3"];
        this.color_8 = this.settingsKey_0.GetColor("value", Color.FromArgb(100, 205, 220));
        this.settingsKey_0 = SettingsFile.Settings["color/RTPColor1"];
        this.color_9 = this.settingsKey_0.GetColor("value", Color.LightCoral);
        this.settingsKey_0 = SettingsFile.Settings["color/RTPColor2"];
        this.color_10 = this.settingsKey_0.GetColor("value", Color.CornflowerBlue);

        this.settingsKey_0 = SettingsFile.Settings["color/Text2D3D"];
        this.color_11 = this.settingsKey_0.GetColor("value", Color.FromArgb(235, 235, 235));
        this.settingsKey_0 = SettingsFile.Settings["color/PlotCol1"];
        this.color_12 = this.settingsKey_0.GetColor("value", Color.FromArgb(255, 255, 100));
        this.settingsKey_0 = SettingsFile.Settings["color/PlotCol2"];
        this.color_13 = this.settingsKey_0.GetColor("value", Color.FromArgb(150, 255, 150));
        this.settingsKey_0 = SettingsFile.Settings["color/Text2D3D_2"];
        this.color_14 = this.settingsKey_0.GetColor("value", Color.FromArgb(175, 175, 175));

        this.settingsKey_0 = SettingsFile.Settings["color/FuelColor1"];
        this.color_20 = this.settingsKey_0.GetColor("value", Color.FromArgb(185, 255, 255));
        this.settingsKey_0 = SettingsFile.Settings["color/FuelColor2"];
        this.color_21 = this.settingsKey_0.GetColor("value", Color.FromArgb(200, 255, 200));
        this.settingsKey_0 = SettingsFile.Settings["color/FuelColor3"];
        this.color_22 = this.settingsKey_0.GetColor("value", Color.FromArgb(255, 255, 200));
        this.settingsKey_0 = SettingsFile.Settings["color/FuelColor4"];
        this.color_23 = this.settingsKey_0.GetColor("value", Color.FromArgb(255, 80, 80));
        this.settingsKey_0 = SettingsFile.Settings["color/IgnColor1"];
        this.color_30 = this.settingsKey_0.GetColor("value", Color.FromArgb(185, 255, 255));
        this.settingsKey_0 = SettingsFile.Settings["color/IgnColor2"];
        this.color_31 = this.settingsKey_0.GetColor("value", Color.FromArgb(200, 255, 200));
        this.settingsKey_0 = SettingsFile.Settings["color/IgnColor3"];
        this.color_32 = this.settingsKey_0.GetColor("value", Color.FromArgb(255, 255, 200));
        this.settingsKey_0 = SettingsFile.Settings["color/IgnColor4"];
        this.color_33 = this.settingsKey_0.GetColor("value", Color.FromArgb(255, 80, 80));
        this.settingsKey_0 = SettingsFile.Settings["color/VEColor1"];
        this.color_40 = this.settingsKey_0.GetColor("value", Color.FromArgb(255, 200, 200));
        this.settingsKey_0 = SettingsFile.Settings["color/VEColor2"];
        this.color_41 = this.settingsKey_0.GetColor("value", Color.FromArgb(200, 255, 255));

        this.settingsKey_0 = SettingsFile.Settings["color/PercentColorFuel1"];
        this.PercentColor1 = this.settingsKey_0.GetSetting("value", 8);
        this.settingsKey_0 = SettingsFile.Settings["color/PercentColorFuel2"];
        this.PercentColor2 = this.settingsKey_0.GetSetting("value", 38);
        this.settingsKey_0 = SettingsFile.Settings["color/PercentColorIgn"];
        this.PercentColorIgn = this.settingsKey_0.GetSetting("value", 50);

        this.settingsKey_0 = SettingsFile.Settings["datalog/port"];
        this.string_1 = this.settingsKey_0.GetSetting("value", "COM1");
        this.settingsKey_0 = SettingsFile.Settings["datalog/baud"];
        this.Datalog_Baud = this.settingsKey_0.GetSetting("value", 0x9600);
        this.settingsKey_0 = SettingsFile.Settings["datalog/protocol"];
        this.dataloggingMode_0 = (DataloggingMode) this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["datalog/AutoScan"];
        this.bool_27 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["datalog/datalogLoadAfterRecord"];
        this.bool_26 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["emulator/port"];
        this.string_2 = this.settingsKey_0.GetSetting("value", "COM1");
        this.settingsKey_0 = SettingsFile.Settings["emulator/baud"];
        this.Emulator_Baud = this.settingsKey_0.GetSetting("value", 0xe1000);
        this.settingsKey_0 = SettingsFile.Settings["emulator/type"];
        this.emulatorMode_0 = (EmulatorMode)this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["emulator/retries"];
        this.int_21 = this.settingsKey_0.GetSetting("value", 3);
        this.settingsKey_0 = SettingsFile.Settings["emulator/timeout"];
        this.int_20 = this.settingsKey_0.GetSetting("value", 500);
        this.settingsKey_0 = SettingsFile.Settings["emulator/useDt"];
        this.bool_31 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["emulator/RtUp"];
        this.bool_32 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["emulator/UploadOnConnect"];
        this.bool_33 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["emulator/AutoScan"];
        this.Emu_AutoScan = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["emulator/chkEmuVendor"];
        this.chkEmuVendor = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["emulator/CheckJ12"];
        this.bool_CheckJ12 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["emulator/AlwaysRt"];
        this.Emu_AlwaysRT = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["tuner/sampleRate"];
        this.int_25 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["editor/followVtecTables"];
        this.bool_42 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/followSecondaryMaps"];
        this.bool_44 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/smartTrack"];
        this.bool_45 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["tuner/STD"];
        this.double_9 = this.settingsKey_0.GetSetting("value", (double)1.5);
        this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetLow"];
        this.double_10 = this.settingsKey_0.GetSetting("value", (double) 1.0);
        this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetLowMbar"];
        this.int_38 = this.settingsKey_0.GetSetting("value", 500);
        this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetMid"];
        this.double_11 = this.settingsKey_0.GetSetting("value", (double) 0.9);
        this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetHigh"];
        this.double_12 = this.settingsKey_0.GetSetting("value", (double) 0.8);
        this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetHighBar"];
        this.int_39 = this.settingsKey_0.GetSetting("value", 900);
        this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjMin"];
        this.double_13 = this.settingsKey_0.GetSetting("value", (double) 1.5);
        this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjMax"];
        this.double_14 = this.settingsKey_0.GetSetting("value", 10);
        this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjP"];
        this.double_15 = this.settingsKey_0.GetSetting("value", (double) 0.75);
        this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjPertageNeeded"];
        this.int_40 = this.settingsKey_0.GetSetting("value", 1);
        this.settingsKey_0 = SettingsFile.Settings["tuner/MapTrail"];
        this.bool_43 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["tuner/FilterAuto"];
        this.bool_49 = this.settingsKey_0.GetSetting("value", false);

        
        this.settingsKey_0 = SettingsFile.Settings["tuner/tpsMin"];
        this.int_26 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["tuner/tpsMax"];
        this.int_27 = this.settingsKey_0.GetSetting("value", 0xff);
        this.settingsKey_0 = SettingsFile.Settings["tuner/afrMin"];
        this.double_7 = this.settingsKey_0.GetSetting("value", (double)0.7);
        this.settingsKey_0 = SettingsFile.Settings["tuner/afrMax"];
        this.double_8 = this.settingsKey_0.GetSetting("value", (double)1.5);
        this.settingsKey_0 = SettingsFile.Settings["tuner/mapMin"];
        this.int_30 = this.settingsKey_0.GetSetting("value", 110);
        this.settingsKey_0 = SettingsFile.Settings["tuner/mapMax"];
        this.int_31 = this.settingsKey_0.GetSetting("value", 0xbb8);
        this.settingsKey_0 = SettingsFile.Settings["tuner/rpmMin"];
        this.int_28 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["tuner/rpmMax"];
        this.int_29 = this.settingsKey_0.GetSetting("value", 0x2af8);
        this.settingsKey_0 = SettingsFile.Settings["tuner/ectMin"];
        this.int_32 = this.settingsKey_0.GetSetting("value", 0xff);
        this.settingsKey_0 = SettingsFile.Settings["tuner/ectMax"];
        this.int_33 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["tuner/iatMin"];
        this.int_34 = this.settingsKey_0.GetSetting("value", 0xff);
        this.settingsKey_0 = SettingsFile.Settings["tuner/iatMax"];
        this.int_35 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["tuner/gear"];
        for (int num7 = 0; num7 < 6; num7++)
        {
            this.bool_46[num7] = this.settingsKey_0.GetSetting("index" + num7.ToString(), true);
        }

        this.settingsKey_0 = SettingsFile.Settings["tuner/hitsDelay"];
        this.int_37 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["tuner/lastSampleO2diff"];
        this.bool_47 = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["tuner/checkFuelCut"];
        this.bool_48 = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["tuner/filterIsUse"];
        this.bool_51 = this.settingsKey_0.GetSetting("value", false);

        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_1"];
        this.int_55 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_2"];
        this.int_56 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_3"];
        this.int_57 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_4"];
        this.int_58 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_avg"];
        this.int_59 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_BackPress"];
        this.int_60 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_FuelPress"];
        this.int_61 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_Iat"];
        this.int_62 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_BackPress"];
        this.int_60 = this.settingsKey_0.GetSetting("value", 0);
        
        this.settingsKey_0 = SettingsFile.Settings["editor/SplitterDistance"];
        this.SplitterDistance = this.settingsKey_0.GetSetting("value", 500);
        
        this.settingsKey_0 = SettingsFile.Settings["editor/Password"];
        this.Password = this.settingsKey_0.GetSetting("value", "");
        this.settingsKey_0 = SettingsFile.Settings["editor/Protect"];
        this.Protect = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["editor/PasswordHiden"];
        this.PasswordHiden = this.settingsKey_0.GetSetting("value", false);


        this.settingsKey_0 = SettingsFile.Settings["editor/CustomGraphSensor"];
        this.int_GraphSensor = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["editor/CustomGraphColumns"];
        this.int_GraphColumns = this.settingsKey_0.GetSetting("value", 14);
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs1_Names"];
        this.Tabs1_Names = this.settingsKey_0.GetSetting("value", "Datalog,Debug Logs,");
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs2_Names"];
        this.Tabs2_Names = this.settingsKey_0.GetSetting("value", "Tables,Parameters,Snapshots,");
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs3_Names"];
        this.Tabs3_Names = this.settingsKey_0.GetSetting("value", "Graph,LivePlot,");
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs4_Names"];
        this.Tabs4_Names = this.settingsKey_0.GetSetting("value", "CEL,Datalogs Threads,Dyno,");
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs5_Names"];
        this.Tabs5_Names = this.settingsKey_0.GetSetting("value", "");

        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs3_Show"];
        this.Tabs3_Show = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs4_Show"];
        this.Tabs4_Show = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs5_Show"];
        this.Tabs5_Show = this.settingsKey_0.GetSetting("value", false);

        this.settingsKey_0 = SettingsFile.Settings["pages/TabsLeft_Split"];
        this.TabsLeft_Split = this.settingsKey_0.GetSetting("value", 252);
        this.settingsKey_0 = SettingsFile.Settings["pages/TabsTop_Split"];
        this.TabsTop_Split = this.settingsKey_0.GetSetting("value", 104);
        this.settingsKey_0 = SettingsFile.Settings["pages/TabsBottom_Split"];
        this.TabsBottom_Split = this.settingsKey_0.GetSetting("value", 432);
        this.settingsKey_0 = SettingsFile.Settings["pages/TabsBottomLeft_Split"];
        this.TabsBottomLeft_Split = this.settingsKey_0.GetSetting("value", 540);
        this.settingsKey_0 = SettingsFile.Settings["pages/TabsRight_Split"];
        this.TabsRight_Split = this.settingsKey_0.GetSetting("value", 450);

        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs1_Selected"];
        this.Tabs1_Selected = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs2_Selected"];
        this.Tabs2_Selected = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs3_Selected"];
        this.Tabs3_Selected = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs4_Selected"];
        this.Tabs4_Selected = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["pages/Tabs5_Selected"];
        this.Tabs5_Selected = this.settingsKey_0.GetSetting("value", 0);

        this.settingsKey_0 = SettingsFile.Settings["pages/Parameter_Splitter"];
        this.Parameter_Splitter = this.settingsKey_0.GetSetting("value", 250);

        this.settingsKey_0 = SettingsFile.Settings["pages/WindowedMode"];
        this.WindowedMode = this.settingsKey_0.GetSetting("value", false);

        this.settingsKey_0 = SettingsFile.Settings["Main/OverlayConditionsDisabled"];
        this.OverlayConditionsDisabled = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["Main/LogDatetime"];
        this.LogDatetime = this.settingsKey_0.GetSetting("value", true);

        this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarFile"];
        this.ToolbarFile = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarEdit"];
        this.ToolbarEdit = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarEmulator"];
        this.ToolbarEmulator = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarDatalog"];
        this.ToolbarDatalog = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarView"];
        this.ToolbarView = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarTools"];
        this.ToolbarTools = this.settingsKey_0.GetSetting("value", true);

        this.settingsKey_0 = SettingsFile.Settings["Main/LiveGraphing"];
        this.LiveGraphing = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["Main/LiveGraph_Lenght"];
        this.LiveGraph_Lenght = this.settingsKey_0.GetSetting("value", 800);

        this.settingsKey_0 = SettingsFile.Settings["Main/ICutModInstall"];
        this.ICutModInstall = this.settingsKey_0.GetSetting("value", "");

        this.settingsKey_0 = SettingsFile.Settings["Main/BoostFuel"];
        this.BoostFuel = this.settingsKey_0.GetSetting("value", 120);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostRetard"];
        this.BoostRetard = this.settingsKey_0.GetSetting("value", 1);

        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNStep1"];
        this.BoostIGNStep1 = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNStep2"];
        this.BoostIGNStep2 = this.settingsKey_0.GetSetting("value", 3);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNStep3"];
        this.BoostIGNStep3 = this.settingsKey_0.GetSetting("value", 5);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNStep4"];
        this.BoostIGNStep4 = this.settingsKey_0.GetSetting("value", 7);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNStep5"];
        this.BoostIGNStep5 = this.settingsKey_0.GetSetting("value", 12);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNStep6"];
        this.BoostIGNStep6 = this.settingsKey_0.GetSetting("value", 30);

        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNRetard1"];
        this.BoostIGNRetard1 = this.settingsKey_0.GetSetting("value", 0.08);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNRetard2"];
        this.BoostIGNRetard2 = this.settingsKey_0.GetSetting("value", 0.15);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNRetard3"];
        this.BoostIGNRetard3 = this.settingsKey_0.GetSetting("value", 0.25);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNRetard4"];
        this.BoostIGNRetard4 = this.settingsKey_0.GetSetting("value", 0.5);
        this.settingsKey_0 = SettingsFile.Settings["Main/BoostIGNRetard5"];
        this.BoostIGNRetard5 = this.settingsKey_0.GetSetting("value", 0.75);
        
        this.settingsKey_0 = SettingsFile.Settings["Main/IsBluetooth"];
        this.IsBluetooth = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["Main/LastPackageChecksum"];
        this.LastPackageChecksum = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["Main/LogAdvancedDatas"];
        this.LogAdvancedDatas = this.settingsKey_0.GetSetting("value", false);

        this.settingsKey_0 = SettingsFile.Settings["Main/BurnerLocation"];
        this.BurnerLocation = this.settingsKey_0.GetSetting("value", "");

        this.settingsKey_0 = SettingsFile.Settings["Main/BurnerSoftware"];
        this.BurnerSoftware = this.settingsKey_0.GetSetting("value", 0);

        this.settingsKey_0 = SettingsFile.Settings["Main/GlitchedBaseromTestInterval"];
        this.GlitchedBaseromTestInterval = this.settingsKey_0.GetSetting("value", 15000);    //30279

        this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Gauges"];
        this.ShownHint_Gauges = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Colors"];
        this.ShownHint_Colors = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Separator"];
        this.ShownHint_Separator = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Dragging"];
        this.ShownHint_Dragging = this.settingsKey_0.GetSetting("value", false);
        this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_DebugLogs"];
        this.ShownHint_DebugLogs = this.settingsKey_0.GetSetting("value", false);

        this.settingsKey_0 = SettingsFile.Settings["Main/AccelTimerSpeedStart"];
        this.AccelTimerSpeedStart = this.settingsKey_0.GetSetting("value", 3);
        this.settingsKey_0 = SettingsFile.Settings["Main/AccelTimerSpeedEnd"];
        this.AccelTimerSpeedEnd = this.settingsKey_0.GetSetting("value", 100);

        this.settingsKey_0 = SettingsFile.Settings["Main/burnChipIndex"];
        this.burnChipIndex = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["Main/burnCommCache"];
        this.burnCommCache = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["Main/calFilePath"];
        this.calFilePath = this.settingsKey_0.GetSetting("value", "");
        this.settingsKey_0 = SettingsFile.Settings["Main/dtCommCache"];
        this.dtCommCache = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["Main/dtPeakShown"];
        this.dtPeakShown = this.settingsKey_0.GetSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["Main/emuCommCache"];
        this.emuCommCache = this.settingsKey_0.GetSetting("value", 0);
        this.settingsKey_0 = SettingsFile.Settings["Main/logFilePath"];
        this.logFilePath = this.settingsKey_0.GetSetting("value", "");
        this.settingsKey_0 = SettingsFile.Settings["Main/overlay1_Display"];
        this.overlay1_Display = this.settingsKey_0.GetSetting("value", 3);
        this.settingsKey_0 = SettingsFile.Settings["Main/overlay2_Display"];
        this.overlay2_Display = this.settingsKey_0.GetSetting("value", 3);
        this.settingsKey_0 = SettingsFile.Settings["Main/overlay3_Display"];
        this.overlay3_Display = this.settingsKey_0.GetSetting("value", 3);
        this.settingsKey_0 = SettingsFile.Settings["Main/parameterNode"];
        this.parameterNode = this.settingsKey_0.GetSetting("value", "");
        this.settingsKey_0 = SettingsFile.Settings["Main/romFilePath"];
        this.romFilePath = this.settingsKey_0.GetSetting("value", "");
        this.settingsKey_0 = SettingsFile.Settings["Main/tunerSmartTrack"];
        this.tunerSmartTrack = this.settingsKey_0.GetSetting("value", 1);


        this.settingsKey_0 = SettingsFile.Settings["Windows/dataloggingToolStrip"];
        this.dataloggingToolStrip = this.settingsKey_0.GetPoint("value", new Point(165, 49));
        this.settingsKey_0 = SettingsFile.Settings["Windows/mainToolStrip"];
        this.mainToolStrip = this.settingsKey_0.GetPoint("value", new Point(3, 24));
        this.settingsKey_0 = SettingsFile.Settings["Windows/viewToolStrip"];
        this.viewToolStrip = this.settingsKey_0.GetPoint("value", new Point(3, 74));
        this.settingsKey_0 = SettingsFile.Settings["Windows/editToolStrip"];
        this.editToolStrip = this.settingsKey_0.GetPoint("value", new Point(220, 24));
        this.settingsKey_0 = SettingsFile.Settings["Windows/windowsToolStrip"];
        this.windowsToolStrip = this.settingsKey_0.GetPoint("value", new Point(275, 74));
        this.settingsKey_0 = SettingsFile.Settings["Windows/emulatorToolStrip"];
        this.emulatorToolStrip = this.settingsKey_0.GetPoint("value", new Point(3, 49));
        this.settingsKey_0 = SettingsFile.Settings["Windows/tunerToolStrip"];
        this.tunerToolStrip = this.settingsKey_0.GetPoint("value", new Point(3, 0));
        this.settingsKey_0 = SettingsFile.Settings["Windows/tableEditToolStrip"];
        this.tableEditToolStrip = this.settingsKey_0.GetPoint("value", new Point(175, 0));
        this.settingsKey_0 = SettingsFile.Settings["Windows/tableViewToolStrip"];
        this.tableViewToolStrip = this.settingsKey_0.GetPoint("value", new Point(3, 25));

        this.settingsKey_0 = SettingsFile.Settings["Windows/Display_Location"];
        this.Display_Location = this.settingsKey_0.GetPoint("value", new Point(375, 105));
        this.settingsKey_0 = SettingsFile.Settings["Windows/logGraphs_Location"];
        this.logGraphs_Location = this.settingsKey_0.GetPoint("value", new Point(260, 500));
        this.settingsKey_0 = SettingsFile.Settings["Windows/logGrid_Location"];
        this.logGrid_Location = this.settingsKey_0.GetPoint("value", new Point(0, 105));
        this.settingsKey_0 = SettingsFile.Settings["Windows/parameters_Location"];
        this.parameters_Location = this.settingsKey_0.GetPoint("value", new Point(320, 250));
        this.settingsKey_0 = SettingsFile.Settings["Windows/tables_Location"];
        this.tables_Location = this.settingsKey_0.GetPoint("value", new Point(260, 210));
        this.settingsKey_0 = SettingsFile.Settings["Windows/Debug_Location"];
        this.Debug_Location = this.settingsKey_0.GetPoint("value", new Point(80, 80));
        this.settingsKey_0 = SettingsFile.Settings["Windows/errorCodes_Location"];
        this.errorCodes_Location = this.settingsKey_0.GetPoint("value", new Point(80, 80));
        this.settingsKey_0 = SettingsFile.Settings["Windows/LivePlot_Location"];
        this.LivePlot_Location = this.settingsKey_0.GetPoint("value", new Point(260, 500));
        this.settingsKey_0 = SettingsFile.Settings["Windows/snapShots_Location"];
        this.snapShots_Location = this.settingsKey_0.GetPoint("value", new Point(80, 80));
        this.settingsKey_0 = SettingsFile.Settings["Windows/ActiveDatalog_Location"];
        this.ActiveDatalog_Location = this.settingsKey_0.GetPoint("value", new Point(80, 80));
        this.settingsKey_0 = SettingsFile.Settings["Windows/DynoC_Location"];
        this.Debug_Location = this.settingsKey_0.GetPoint("value", new Point(80, 80));

        this.settingsKey_0 = SettingsFile.Settings["Windows/Display_Size"];
        this.Display_Size = this.settingsKey_0.GetSize("value", new Size(650, 130));
        this.settingsKey_0 = SettingsFile.Settings["Windows/logGraphs_Size"];
        this.logGraphs_Size = this.settingsKey_0.GetSize("value", new Size(750, 250));
        this.settingsKey_0 = SettingsFile.Settings["Windows/logGrid_Size"];
        this.logGrid_Size = this.settingsKey_0.GetSize("value", new Size(255, 600));
        this.settingsKey_0 = SettingsFile.Settings["Windows/parameters_Size"];
        this.parameters_Size = this.settingsKey_0.GetSize("value", new Size(570, 570));
        this.settingsKey_0 = SettingsFile.Settings["Windows/tables_Size"];
        this.tables_Size = this.settingsKey_0.GetSize("value", new Size(750, 435));
        this.settingsKey_0 = SettingsFile.Settings["Windows/Debug_Size"];
        this.Debug_Size = this.settingsKey_0.GetSize("value", new Size(358, 311));
        this.settingsKey_0 = SettingsFile.Settings["Windows/errorCodes_Size"];
        this.errorCodes_Size = this.settingsKey_0.GetSize("value", new Size(150, 150));
        this.settingsKey_0 = SettingsFile.Settings["Windows/LivePlot_Size"];
        this.LivePlot_Size = this.settingsKey_0.GetSize("value", new Size(750, 43));
        this.settingsKey_0 = SettingsFile.Settings["Windows/ActiveDatalog_Size"];
        this.ActiveDatalog_Size = this.settingsKey_0.GetSize("value", new Size(358, 311));
        this.settingsKey_0 = SettingsFile.Settings["Windows/DynoC_Size"];
        this.DynoC_Size = this.settingsKey_0.GetSize("value", new Size(0x117, 260));


        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_COMPort"];
        this.Dyno_COMPort = this.settingsKey_0.GetSetting("value", "COM1");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_COMPortBC"];
        this.Dyno_COMPortBC = this.settingsKey_0.GetSetting("value", "COM2");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUX1Type"];
        this.Dyno_AUX1Type = this.settingsKey_0.GetSetting("value", "AFR");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUX2Type"];
        this.Dyno_AUX2Type = this.settingsKey_0.GetSetting("value", "Voltage");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUX3Type"];
        this.Dyno_AUX3Type = this.settingsKey_0.GetSetting("value", "Voltage");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN1V"];
        this.Dyno_AUXMIN1V = this.settingsKey_0.GetSetting("value", "0");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN2V"];
        this.Dyno_AUXMIN2V = this.settingsKey_0.GetSetting("value", "0");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN3V"];
        this.Dyno_AUXMIN3V = this.settingsKey_0.GetSetting("value", "0");

        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX1V"];
        this.Dyno_AUXMAX1V = this.settingsKey_0.GetSetting("value", "5");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX2V"];
        this.Dyno_AUXMAX2V = this.settingsKey_0.GetSetting("value", "5");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX3V"];
        this.Dyno_AUXMAX3V = this.settingsKey_0.GetSetting("value", "5");

        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN1O"];
        this.Dyno_AUXMIN1O = this.settingsKey_0.GetSetting("value", "10");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN2O"];
        this.Dyno_AUXMIN2O = this.settingsKey_0.GetSetting("value", "0");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN3O"];
        this.Dyno_AUXMIN3O = this.settingsKey_0.GetSetting("value", "0");

        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX1O"];
        this.Dyno_AUXMAX1O = this.settingsKey_0.GetSetting("value", "20");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX2O"];
        this.Dyno_AUXMAX2O = this.settingsKey_0.GetSetting("value", "5");
        this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX3O"];
        this.Dyno_AUXMAX3O = this.settingsKey_0.GetSetting("value", "5");

        return true;
    }

    public void method_10()
    {
        this.dataloggingTable_0 = this.dataloggingTable_1;
        this.bool_28 = false;
    }

    public int method_11_GetMAP_ColumnsNumber()
    {
        try
        {
            if (this.class18_0.method_30_HasFileLoadedInBMTune())
            {
                return this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_75);
            }
            return 10;
        }
        catch { return 20; }
    }

    public string method_13(SensorsX sensors_3)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        string setting = this.settingsKey_0.GetSetting("name", sensors_3.ToString());
        SettingsFile.smethod_1();
        this.settingsKey_0 = null;
        return setting;
    }

    public void method_15()
    {
        if (this.delegate14_0 != null)
        {
            this.delegate14_0();
        }
    }

    public string method_16(SensorsX sensors_3)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        string setting = this.settingsKey_0.GetSetting("desc", "");
        this.settingsKey_0 = null;
        return setting;
    }

    public void method_2()
    {
        if (this.delegate12_0 != null)
        {
            this.delegate12_0();
        }
        this.class18_0.method_52();
    }

    //Get
    public int method_20(SensorsX sensors_3)
    {
        int setting = 0;
        try
        {
            this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
            setting = this.settingsKey_0.GetSetting("warnMin", 0);
            this.settingsKey_0 = null;
        }
        catch (Exception mess)
        {
            LogThisGraph("Error getting sensor '" + sensors_3 + "' warning minimum settings:" + Environment.NewLine + "" + mess);
        }
        return setting;
    }

    //Set
    public void method_21(SensorsX sensors_3, double double_18)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        this.settingsKey_0.StoreSetting("warnMin", double_18);
        SettingsFile.smethod_1();
        this.settingsKey_0 = null;
    }

    //Get
    public int method_22(SensorsX sensors_3)
    {
        int setting = 0;
        try
        {
            this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
            setting = this.settingsKey_0.GetSetting("warnMax", 0);
            this.settingsKey_0 = null;
        }
        catch (Exception mess)
        {
            LogThisGraph("Error getting sensor '" + sensors_3 + "' warning maximum settings:" + Environment.NewLine + "" + mess);
        }
        return setting;
    }

    //Set
    public void method_23(SensorsX sensors_3, double double_18)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        this.settingsKey_0.StoreSetting("warnMax", double_18);
        SettingsFile.smethod_1();
        this.settingsKey_0 = null;
    }

    //Get
    public int method_20_Min(SensorsX sensors_3)
    {
        int setting = 0;
        try
        {
            this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
            setting = this.settingsKey_0.GetSetting("customMin", 0);
            this.settingsKey_0 = null;
        }
        catch (Exception mess)
        {
            LogThisGraph("Error getting sensor '" + sensors_3 + "' minimum settings:" + Environment.NewLine + "" + mess);
        }
        return setting;
    }

    //Set
    public void method_21_Min(SensorsX sensors_3, double double_18)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        this.settingsKey_0.StoreSetting("customMin", double_18);
        SettingsFile.smethod_1();
        this.settingsKey_0 = null;
    }

    //Get
    public int method_22_Max(SensorsX sensors_3)
    {
        int setting = 0;
        try
        {
            this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
            setting = this.settingsKey_0.GetSetting("customMax", 0);
            this.settingsKey_0 = null;
        }
        catch (Exception mess)
        {
            LogThisGraph("Error getting sensor '" + sensors_3 + "' maximum settings:" + Environment.NewLine + "" + mess);
        }
        return setting;
    }

    //Set
    public void method_23_Max(SensorsX sensors_3, double double_18)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        this.settingsKey_0.StoreSetting("customMax", double_18);
        SettingsFile.smethod_1();
        this.settingsKey_0 = null;
    }

    public bool method_22_IsInt(SensorsX sensors_3)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        return this.settingsKey_0.GetSetting("customINT", true);
    }

    public string method_24(SensorsX sensors_3, string Types)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        return this.settingsKey_0.GetSetting(Types, "");
    }

    public void method_25(SensorsX sensors_3, string double_18, string Types)
    {
        this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(sensors_3.ToString())];
        this.settingsKey_0.StoreSetting(Types, double_18);
        SettingsFile.smethod_1();
        this.settingsKey_0 = null;
    }

    public string ResetSenssStr(string ThisSenssdStr)
    {
        //rpmX
        //vssX
        //gearX
        //mapX
        //boostX
        //paX
        //tpsX
        //ectX
        //iatX
        //outVtsX
        //ebcDutyX
        string ThisSensorTag = ThisSenssdStr;
        if (ThisSenssdStr == "rpmX"
            || ThisSenssdStr == "vssX"
            || ThisSenssdStr == "gearX"
            || ThisSenssdStr == "mapX"
            || ThisSenssdStr == "boostX"
            || ThisSenssdStr == "paX"
            || ThisSenssdStr == "tpsX"
            || ThisSenssdStr == "ectX"
            || ThisSenssdStr == "iatX"
            || ThisSenssdStr == "outVtsX"
            || ThisSenssdStr == "ebcDutyX")
        {
            ThisSensorTag = ThisSenssdStr.Substring(0, ThisSenssdStr.Length - 1);
        }

        return ThisSensorTag;
    }

    public void method_28(string string_7)
    {
        int index_0 = 4;
        for (int i = 0; i < 5; i++)
        {
            if (string_7 == this.string_0[i])
            {
                index_0 = i;
                break;
            }
        }
        while (index_0 > 0)
        {
            this.string_0[index_0] = this.string_0[--index_0];
        }
        this.string_0[0] = string_7;
        if (this.delegate10_0 != null)
        {
            this.delegate10_0(this.string_0);
        }
    }

    public void method_29(string string_7)
    {
        for (int i = 0; i < this.string_0.Length; i++)
        {
            if (this.string_0[i] == string_7)
            {
                this.string_0[i] = string.Empty;
            }
        }
        if (this.delegate10_0 != null)
        {
            this.delegate10_0(this.string_0);
        }
    }

    public void method_3()
    {
        this.method_7();
        FileInfo info = new FileInfo(path);
        if (info.Exists)
        {
            info = null;
            this.settingsKey_0 = SettingsFile.Settings["tuner/scaleRate"];
            this.settingsKey_0.StoreSetting("value", this.scaleRate);
            this.settingsKey_0 = SettingsFile.Settings["tuner/ShownDockedMode"];
            this.settingsKey_0.StoreSetting("value", this.ShownDockedMode);

            this.settingsKey_0 = SettingsFile.Settings["editor/binSaveDefault"];
            this.settingsKey_0.StoreSetting("value", this.bool_3);
            this.settingsKey_0 = SettingsFile.Settings["editor/AdjFuelTableFv"];
            this.settingsKey_0.StoreSetting("value", this.float_2);
            this.settingsKey_0 = SettingsFile.Settings["editor/AdjFuelTablePercent"];
            this.settingsKey_0.StoreSetting("value", this.float_1);
            this.settingsKey_0 = SettingsFile.Settings["editor/AdjFuelTableFvSwitch"];
            this.settingsKey_0.StoreSetting("value", this.float_3);
            this.settingsKey_0 = SettingsFile.Settings["editor/AdjLambdaTable"];
            this.settingsKey_0.StoreSetting("value", this.float_4);
            this.settingsKey_0 = SettingsFile.Settings["editor/AdjIgnTable"];
            this.settingsKey_0.StoreSetting("value", this.float_0);
            this.settingsKey_0 = SettingsFile.Settings["editor/AdjVeTable"];
            this.settingsKey_0.StoreSetting("value", this.float_5);
            this.settingsKey_0 = SettingsFile.Settings["editor/Mru"];
            int num = 0;
            for (int i = 0; i < this.string_0.Length; i++)
            {
                if (this.string_0[i] != string.Empty)
                {
                    this.settingsKey_0.StoreSetting("file" + num.ToString(), this.string_0[i]);
                    num++;
                }
            }
            this.settingsKey_0 = SettingsFile.Settings["editor/Mruniversal"];
            num = 0;
            for (int i = 0; i < this.string_VW.Length; i++)
            {
                if (this.string_VW[i] != string.Empty)
                {
                    this.settingsKey_0.StoreSetting("file" + num.ToString(), this.string_VW[i]);
                    num++;
                }
            }
            this.settingsKey_0 = SettingsFile.Settings["editor/MruniversalDEF"];
            num = 0;
            for (int i = 0; i < this.string_XDF.Length; i++)
            {
                if (this.string_XDF[i] != string.Empty)
                {
                    this.settingsKey_0.StoreSetting("file" + num.ToString(), this.string_XDF[i]);
                    num++;
                }
            }
            //this.settingsKey_0 = SettingsFile.Settings["editor/ShowTables"];
            //this.settingsKey_0.StoreSetting("value", this.method_11());
            this.settingsKey_0 = SettingsFile.Settings["editor/graphShown"];
            this.settingsKey_0.StoreSetting("value", this.bool_6);
            this.settingsKey_0 = SettingsFile.Settings["editor/playLogOnOpen"];
            this.settingsKey_0.StoreSetting("value", this.bool_7);
            this.settingsKey_0 = SettingsFile.Settings["editor/recordOnConnection"];
            this.settingsKey_0.StoreSetting("value", this.bool_8);
            this.settingsKey_0 = SettingsFile.Settings["editor/followVtecTables"];
            this.settingsKey_0.StoreSetting("value", this.bool_42);
            this.settingsKey_0 = SettingsFile.Settings["editor/followSecondaryMaps"];
            this.settingsKey_0.StoreSetting("value", this.bool_44);
            this.settingsKey_0 = SettingsFile.Settings["editor/windowState"];
            this.settingsKey_0.StoreSetting("value", this.int_1);
            this.settingsKey_0 = SettingsFile.Settings["editor/GraphHorizontal"];
            this.settingsKey_0.StoreSetting("value", this.bool_15);
            this.settingsKey_0 = SettingsFile.Settings["editor/smoothingThreshold"];
            this.settingsKey_0.StoreSetting("value", this.float_6);

            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsPreset"];
            this.settingsKey_0.StoreSetting("value", this.DatalogCurrentPreset);
            this.settingsKey_0 = SettingsFile.Settings["editor/DatalogThreadEnabled"];
            this.settingsKey_0.StoreSetting("value", this.DatalogThreadEnabled);

            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads"];
            this.settingsKey_0.StoreSetting("index0", false);
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.bool_ActiveDatalog[i]);
            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay"];
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.int_ActiveDatalog[i]);

            //presets
            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset1"];
            this.settingsKey_0.StoreSetting("index0", false);
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset1[i]);
            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset1"];
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset1[i]);

            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset2"];
            this.settingsKey_0.StoreSetting("index0", false);
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset2[i]);
            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset2"];
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset2[i]);

            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset3"];
            this.settingsKey_0.StoreSetting("index0", false);
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset3[i]);
            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset3"];
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset3[i]);

            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreads_Preset4"];
            this.settingsKey_0.StoreSetting("index0", false);
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.bool_ActiveDatalog_Preset4[i]);
            this.settingsKey_0 = SettingsFile.Settings["editor/activeDatalogThreadsDelay_Preset4"];
            for (int i = 0; i < 7; i++) this.settingsKey_0.StoreSetting("index" + i.ToString(), this.int_ActiveDatalog_Preset4[i]);
            //######################

            this.settingsKey_0 = SettingsFile.Settings["editor/followselected"];
            this.settingsKey_0.StoreSetting("value", this.bool_10);
            this.settingsKey_0 = SettingsFile.Settings["editor/selectedHeadersTrace"];
            this.settingsKey_0.StoreSetting("value", this.bool_11);
            this.settingsKey_0 = SettingsFile.Settings["editor/smoothRows"];
            this.settingsKey_0.StoreSetting("value", this.bool_12);
            this.settingsKey_0 = SettingsFile.Settings["editor/rpmBlock"];
            this.settingsKey_0.StoreSetting("value", this.int_3);
            this.settingsKey_0 = SettingsFile.Settings["editor/rpmPlotTps"];
            this.settingsKey_0.StoreSetting("value", this.int_4);
            this.settingsKey_0 = SettingsFile.Settings["editor/timePlotLength"];
            this.settingsKey_0.StoreSetting("value", this.int_5);
            this.settingsKey_0 = SettingsFile.Settings["editor/GraphTypeSelected"];
            this.settingsKey_0.StoreSetting("value", this.int_2);

            this.settingsKey_0 = SettingsFile.Settings["editor/PlotTypeSelected"];
            this.settingsKey_0.StoreSetting("value", this.int_2_LivePlot);


            this.settingsKey_0 = SettingsFile.Settings["editor/stacksize"];
            this.settingsKey_0.StoreSetting("value", this.int_36);
            this.settingsKey_0 = SettingsFile.Settings["editor/stacksizevariance"];
            this.settingsKey_0.StoreSetting("value", this.int_41);

            this.settingsKey_0 = SettingsFile.Settings["editor/TraceShowInterpolation"];
            this.settingsKey_0.StoreSetting("value", this.bool_21);
            this.settingsKey_0 = SettingsFile.Settings["editor/GraphSelectType"];
            this.settingsKey_0.StoreSetting("value", (int) this.mapGraphSelect_0);
            this.settingsKey_0 = SettingsFile.Settings["units/mbarSeaLevel"];
            this.settingsKey_0.StoreSetting("value", this.int_6);
            this.settingsKey_0 = SettingsFile.Settings["units/vacumn"];
            this.settingsKey_0.StoreSetting("value", (int) this.mapSensorUnits_0);
            this.settingsKey_0 = SettingsFile.Settings["units/boost"];
            this.settingsKey_0.StoreSetting("value", (int) this.mapSensorUnits_1);
            this.settingsKey_0 = SettingsFile.Settings["units/temp"];
            this.settingsKey_0.StoreSetting("value", (int) this.temperatureUnits_0);
            this.settingsKey_0 = SettingsFile.Settings["units/vss"];
            this.settingsKey_0.StoreSetting("value", (int) this.vssUnits_0);
            this.settingsKey_0 = SettingsFile.Settings["units/afr"];
            this.settingsKey_0.StoreSetting("value", (int) this.airFuelUnits_0);
            this.settingsKey_0 = SettingsFile.Settings["units/fuelCorr"];
            this.settingsKey_0.StoreSetting("value", (int) this.correctionUnits_0);
            this.settingsKey_0 = SettingsFile.Settings["units/usePaSen"];
            this.settingsKey_0.StoreSetting("value", this.bool_23);
            this.settingsKey_0 = SettingsFile.Settings["wideband/offset"];
            this.settingsKey_0.StoreSetting("value", this.double_2);
            this.settingsKey_0 = SettingsFile.Settings["wideband/index"];
            this.settingsKey_0.StoreSetting("value", this.int_8);
            this.settingsKey_0 = SettingsFile.Settings["wideband/widebandConversion"];
            string[] settingNames = this.settingsKey_0.GetSettingNames();
            for (int j = 0; j < settingNames.Length; j++)
            {
                this.settingsKey_0.DeleteSetting(settingNames[j]);
            }
            for (int k = 0; k < this.double_0.Length; k++)
            {
                this.settingsKey_0.StoreSetting("index" + k.ToString(), this.double_0[k]);
            }
            this.settingsKey_0 = SettingsFile.Settings["wideband/wbInput"];
            this.settingsKey_0.StoreSetting("value", (int) this.wbinput_0);
            this.settingsKey_0 = SettingsFile.Settings["wideband/stoichGas"];
            this.settingsKey_0.StoreSetting("value", this.double_3);
            this.settingsKey_0 = SettingsFile.Settings["wideband/stoichLstSel"];
            this.settingsKey_0.StoreSetting("value", this.int_9);
            this.settingsKey_0 = SettingsFile.Settings["wideband/WidebandSerialInput"];
            this.settingsKey_0.StoreSetting("value", this.bool_25);
            this.settingsKey_0 = SettingsFile.Settings["wideband/WidebandSerialPortIndex"];
            this.settingsKey_0.StoreSetting("value", this.int_10);
            this.settingsKey_0 = SettingsFile.Settings["wideband/WidebandSerialType"];
            this.settingsKey_0.StoreSetting("value", (int) this.wideband_Serial_0);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana1enable"];
            this.settingsKey_0.StoreSetting("value", this.bool_36);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana1lbl"];
            this.settingsKey_0.StoreSetting("value", this.string_4);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana1tbl"];
            settingNames = this.settingsKey_0.GetSettingNames();
            for (int m = 0; m < settingNames.Length; m++)
            {
                this.settingsKey_0.DeleteSetting(settingNames[m]);
            }
            for (int n = 0; n < this.double_4.Length; n++)
            {
                this.settingsKey_0.StoreSetting("index" + n.ToString(), this.double_4[n]);
            }
            this.settingsKey_0 = SettingsFile.Settings["analog/ana1dec"];
            this.settingsKey_0.StoreSetting("value", this.int_22);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana2enable"];
            this.settingsKey_0.StoreSetting("value", this.bool_38);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana2lbl"];
            this.settingsKey_0.StoreSetting("value", this.string_5);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana2tbl"];
            settingNames = this.settingsKey_0.GetSettingNames();
            for (int num7 = 0; num7 < settingNames.Length; num7++)
            {
                this.settingsKey_0.DeleteSetting(settingNames[num7]);
            }
            for (int num8 = 0; num8 < this.double_5.Length; num8++)
            {
                this.settingsKey_0.StoreSetting("index" + num8.ToString(), this.double_5[num8]);
            }
            this.settingsKey_0 = SettingsFile.Settings["analog/ana2dec"];
            this.settingsKey_0.StoreSetting("value", this.int_23);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana3enable"];
            this.settingsKey_0.StoreSetting("value", this.bool_40);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana3lbl"];
            this.settingsKey_0.StoreSetting("value", this.string_6);
            this.settingsKey_0 = SettingsFile.Settings["analog/ana3tbl"];
            settingNames = this.settingsKey_0.GetSettingNames();
            for (int num9 = 0; num9 < settingNames.Length; num9++)
            {
                this.settingsKey_0.DeleteSetting(settingNames[num9]);
            }
            for (int num10 = 0; num10 < this.double_6.Length; num10++)
            {
                this.settingsKey_0.StoreSetting("index" + num10.ToString(), this.double_6[num10]);
            }
            this.settingsKey_0 = SettingsFile.Settings["analog/ana3dec"];
            this.settingsKey_0.StoreSetting("value", this.int_24);
            this.settingsKey_0 = SettingsFile.Settings["display/showWarningColor"];
            this.settingsKey_0.StoreSetting("value", this.bool_24);
            this.settingsKey_0 = SettingsFile.Settings["display/dispTextPrim"];
            this.settingsKey_0.StoreSetting("value", this.float_7);
            this.settingsKey_0 = SettingsFile.Settings["display/dispTextSec"];
            this.settingsKey_0.StoreSetting("value", this.float_8);

            this.settingsKey_0 = SettingsFile.Settings["color/TraceColor"];
            this.settingsKey_0.StoreColor("value", this.color_Trace);
            this.settingsKey_0 = SettingsFile.Settings["color/TrailColor"];
            this.settingsKey_0.StoreColor("value", this.color_Trail);
            this.settingsKey_0 = SettingsFile.Settings["color/selectedColor"];
            this.settingsKey_0.StoreColor("value", this.color_2);
            this.settingsKey_0 = SettingsFile.Settings["color/dispBackColor"];
            this.settingsKey_0.StoreColor("value", this.color_3);
            this.settingsKey_0 = SettingsFile.Settings["color/dispTextColor"];
            this.settingsKey_0.StoreColor("value", this.color_4);
            this.settingsKey_0 = SettingsFile.Settings["color/ledOnColor"];
            this.settingsKey_0.StoreColor("value", this.color_On);
            this.settingsKey_0 = SettingsFile.Settings["color/ledOnDarkColor"];
            this.settingsKey_0.StoreColor("value", this.color_OnDark);
            this.settingsKey_0 = SettingsFile.Settings["color/ledOffColor"];
            this.settingsKey_0.StoreColor("value", this.color_Off);
            this.settingsKey_0 = SettingsFile.Settings["color/BackColor2"];
            this.settingsKey_0.StoreColor("value", this.color_7);
            this.settingsKey_0 = SettingsFile.Settings["color/BackColor3"];
            this.settingsKey_0.StoreColor("value", this.color_8);
            this.settingsKey_0 = SettingsFile.Settings["color/RTPColor1"];
            this.settingsKey_0.StoreColor("value", this.color_9);
            this.settingsKey_0 = SettingsFile.Settings["color/RTPColor2"];
            this.settingsKey_0.StoreColor("value", this.color_10);

            this.settingsKey_0 = SettingsFile.Settings["color/Text2D3D"];
            this.settingsKey_0.StoreColor("value", this.color_11);
            this.settingsKey_0 = SettingsFile.Settings["color/PlotCol1"];
            this.settingsKey_0.StoreColor("value", this.color_12);
            this.settingsKey_0 = SettingsFile.Settings["color/PlotCol2"];
            this.settingsKey_0.StoreColor("value", this.color_13);
            this.settingsKey_0 = SettingsFile.Settings["color/Text2D3D_2"];
            this.settingsKey_0.StoreColor("value", this.color_14);

            this.settingsKey_0 = SettingsFile.Settings["color/FuelColor1"];
            this.settingsKey_0.StoreColor("value", this.color_20);
            this.settingsKey_0 = SettingsFile.Settings["color/FuelColor2"];
            this.settingsKey_0.StoreColor("value", this.color_21);
            this.settingsKey_0 = SettingsFile.Settings["color/FuelColor3"];
            this.settingsKey_0.StoreColor("value", this.color_22);
            this.settingsKey_0 = SettingsFile.Settings["color/FuelColor4"];
            this.settingsKey_0.StoreColor("value", this.color_23);
            this.settingsKey_0 = SettingsFile.Settings["color/IgnColor1"];
            this.settingsKey_0.StoreColor("value", this.color_30);
            this.settingsKey_0 = SettingsFile.Settings["color/IgnColor2"];
            this.settingsKey_0.StoreColor("value", this.color_31);
            this.settingsKey_0 = SettingsFile.Settings["color/IgnColor3"];
            this.settingsKey_0.StoreColor("value", this.color_32);
            this.settingsKey_0 = SettingsFile.Settings["color/IgnColor4"];
            this.settingsKey_0.StoreColor("value", this.color_33);
            this.settingsKey_0 = SettingsFile.Settings["color/VEColor1"];
            this.settingsKey_0.StoreColor("value", this.color_40);
            this.settingsKey_0 = SettingsFile.Settings["color/VEColor2"];
            this.settingsKey_0.StoreColor("value", this.color_41);

            this.settingsKey_0 = SettingsFile.Settings["color/PercentColorFuel1"];
            this.settingsKey_0.StoreSetting("value", this.PercentColor1);
            this.settingsKey_0 = SettingsFile.Settings["color/PercentColorFuel2"];
            this.settingsKey_0.StoreSetting("value", this.PercentColor2);
            this.settingsKey_0 = SettingsFile.Settings["color/PercentColorIgn"];
            this.settingsKey_0.StoreSetting("value", this.PercentColorIgn);

            this.settingsKey_0 = SettingsFile.Settings["datalog/port"];
            this.settingsKey_0.StoreSetting("value", this.string_1);
            this.settingsKey_0 = SettingsFile.Settings["datalog/baud"];
            this.settingsKey_0.StoreSetting("value", this.Datalog_Baud);
            this.settingsKey_0 = SettingsFile.Settings["datalog/protocol"];
            this.settingsKey_0.StoreSetting("value", (int) this.dataloggingMode_0);
            this.settingsKey_0 = SettingsFile.Settings["datalog/AutoScan"];
            this.settingsKey_0.StoreSetting("value", this.bool_27);
            this.settingsKey_0 = SettingsFile.Settings["datalog/datalogLoadAfterRecord"];
            this.settingsKey_0.StoreSetting("value", this.bool_26);
            this.settingsKey_0 = SettingsFile.Settings["emulator/port"];
            this.settingsKey_0.StoreSetting("value", this.string_2);
            this.settingsKey_0 = SettingsFile.Settings["emulator/baud"];
            this.settingsKey_0.StoreSetting("value", this.Emulator_Baud);
            this.settingsKey_0 = SettingsFile.Settings["emulator/type"];
            this.settingsKey_0.StoreSetting("value", (int) this.emulatorMode_0);
            this.settingsKey_0 = SettingsFile.Settings["emulator/retries"];
            this.settingsKey_0.StoreSetting("value", this.int_21);
            this.settingsKey_0 = SettingsFile.Settings["emulator/timeout"];
            this.settingsKey_0.StoreSetting("value", this.int_20);
            this.settingsKey_0 = SettingsFile.Settings["emulator/useDt"];
            this.settingsKey_0.StoreSetting("value", this.bool_31);
            this.settingsKey_0 = SettingsFile.Settings["emulator/RtUp"];
            this.settingsKey_0.StoreSetting("value", this.bool_32);
            this.settingsKey_0 = SettingsFile.Settings["emulator/UploadOnConnect"];
            this.settingsKey_0.StoreSetting("value", this.bool_33);
            this.settingsKey_0 = SettingsFile.Settings["emulator/AutoScan"];
            this.settingsKey_0.StoreSetting("value", this.Emu_AutoScan);
            this.settingsKey_0 = SettingsFile.Settings["emulator/chkEmuVendor"];
            this.settingsKey_0.StoreSetting("value", this.chkEmuVendor);
            this.settingsKey_0 = SettingsFile.Settings["emulator/CheckJ12"];
            this.settingsKey_0.StoreSetting("value", this.bool_CheckJ12);
            this.settingsKey_0 = SettingsFile.Settings["emulator/AlwaysRt"];
            this.settingsKey_0.GetSetting("value", this.Emu_AlwaysRT);
            this.settingsKey_0 = SettingsFile.Settings["editor/smartTrack"];
            this.settingsKey_0.StoreSetting("value", this.bool_45);
            this.settingsKey_0 = SettingsFile.Settings["tuner/sampleRate"];
            this.settingsKey_0.StoreSetting("value", this.int_25);
            this.settingsKey_0 = SettingsFile.Settings["tuner/STD"];
            this.settingsKey_0.StoreSetting("value", this.double_9);
            this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetLow"];
            this.settingsKey_0.StoreSetting("value", this.double_10);
            this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetLowMbar"];
            this.settingsKey_0.StoreSetting("value", this.int_38);
            this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetMid"];
            this.settingsKey_0.StoreSetting("value", this.double_11);
            this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetHigh"];
            this.settingsKey_0.StoreSetting("value", this.double_12);
            this.settingsKey_0 = SettingsFile.Settings["tuner/afrTargetHighBar"];
            this.settingsKey_0.StoreSetting("value", this.int_39);
            this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjMin"];
            this.settingsKey_0.StoreSetting("value", this.double_13);
            this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjMax"];
            this.settingsKey_0.StoreSetting("value", this.double_14);
            this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjP"];
            this.settingsKey_0.StoreSetting("value", this.double_15);
            this.settingsKey_0 = SettingsFile.Settings["tuner/fuelAdjPertageNeeded"];
            this.settingsKey_0.StoreSetting("value", this.int_40);
            this.settingsKey_0 = SettingsFile.Settings["tuner/MapTrail"];
            this.settingsKey_0.StoreSetting("value", this.bool_43);

            this.settingsKey_0 = SettingsFile.Settings["tuner/tpsMin"];
            this.settingsKey_0.StoreSetting("value", this.int_26);
            this.settingsKey_0 = SettingsFile.Settings["tuner/tpsMax"];
            this.settingsKey_0.StoreSetting("value", this.int_27);
            this.settingsKey_0 = SettingsFile.Settings["tuner/afrMin"];
            this.settingsKey_0.StoreSetting("value", this.double_7);
            this.settingsKey_0 = SettingsFile.Settings["tuner/afrMax"];
            this.settingsKey_0.StoreSetting("value", this.double_8);
            this.settingsKey_0 = SettingsFile.Settings["tuner/mapMin"];
            this.settingsKey_0.StoreSetting("value", this.int_30);
            this.settingsKey_0 = SettingsFile.Settings["tuner/mapMax"];
            this.settingsKey_0.StoreSetting("value", this.int_31);
            this.settingsKey_0 = SettingsFile.Settings["tuner/rpmMin"];
            this.settingsKey_0.StoreSetting("value", this.int_28);
            this.settingsKey_0 = SettingsFile.Settings["tuner/rpmMax"];
            this.settingsKey_0.StoreSetting("value", this.int_29);
            this.settingsKey_0 = SettingsFile.Settings["tuner/ectMin"];
            this.settingsKey_0.StoreSetting("value", this.int_32);
            this.settingsKey_0 = SettingsFile.Settings["tuner/ectMax"];
            this.settingsKey_0.StoreSetting("value", this.int_33);
            this.settingsKey_0 = SettingsFile.Settings["tuner/iatMin"];
            this.settingsKey_0.StoreSetting("value", this.int_34);
            this.settingsKey_0 = SettingsFile.Settings["tuner/iatMax"];
            this.settingsKey_0.StoreSetting("value", this.int_35);
            this.settingsKey_0 = SettingsFile.Settings["tuner/gear"];
            this.settingsKey_0.StoreSetting("index0", false);
            for (int num13 = 0; num13 < 6; num13++)
            {
                this.settingsKey_0.StoreSetting("index" + num13.ToString(), this.bool_46[num13]);
            }
            this.settingsKey_0 = SettingsFile.Settings["tuner/hitsDelay"];
            this.settingsKey_0.StoreSetting("value", this.int_37);
            this.settingsKey_0 = SettingsFile.Settings["tuner/lastSampleO2diff"];
            this.settingsKey_0.StoreSetting("value", this.bool_47);
            this.settingsKey_0 = SettingsFile.Settings["tuner/checkFuelCut"];
            this.settingsKey_0.StoreSetting("value", this.bool_48);
            

            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_1"];
            this.settingsKey_0.StoreSetting("value", this.int_55);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_2"];
            this.settingsKey_0.StoreSetting("value", this.int_56);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_3"];
            this.settingsKey_0.StoreSetting("value", this.int_57);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_4"];
            this.settingsKey_0.StoreSetting("value", this.int_58);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_egt_avg"];
            this.settingsKey_0.StoreSetting("value", this.int_59);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_BackPress"];
            this.settingsKey_0.StoreSetting("value", this.int_60);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_FuelPress"];
            this.settingsKey_0.StoreSetting("value", this.int_61);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_Iat"];
            this.settingsKey_0.StoreSetting("value", this.int_62);
            this.settingsKey_0 = SettingsFile.Settings["overlay/specialSensor_BackPress"];
            this.settingsKey_0.StoreSetting("value", this.int_60);
            
            this.settingsKey_0 = SettingsFile.Settings["editor/SplitterDistance"];
            this.settingsKey_0.StoreSetting("value", this.SplitterDistance);

            //Empty password error fix
            try
            {
                this.settingsKey_0 = SettingsFile.Settings["editor/Password"];
                this.settingsKey_0.StoreSetting("value", this.Password);
            }
            catch { }
            this.settingsKey_0 = SettingsFile.Settings["editor/Protect"];
            this.settingsKey_0.StoreSetting("value", this.Protect);
            this.settingsKey_0 = SettingsFile.Settings["editor/PasswordHiden"];
            this.settingsKey_0.StoreSetting("value", this.PasswordHiden);
            
            this.settingsKey_0 = SettingsFile.Settings["editor/CustomGraphSensor"];
            this.settingsKey_0.StoreSetting("value", this.int_GraphSensor);
            this.settingsKey_0 = SettingsFile.Settings["editor/CustomGraphColumns"];
            this.settingsKey_0.StoreSetting("value", this.int_GraphColumns);

            if (this.Tabs1_Names == "") this.Tabs1_Names = "null";
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs1_Names"];
            this.settingsKey_0.StoreSetting("value", this.Tabs1_Names);
            if (this.Tabs2_Names == "") this.Tabs2_Names = "null";
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs2_Names"];
            this.settingsKey_0.StoreSetting("value", this.Tabs2_Names);
            if (this.Tabs3_Names == "") this.Tabs3_Names = "null";
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs3_Names"];
            this.settingsKey_0.StoreSetting("value", this.Tabs3_Names);
            if (this.Tabs4_Names == "") this.Tabs4_Names = "null";
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs4_Names"];
            this.settingsKey_0.StoreSetting("value", this.Tabs4_Names);
            if (this.Tabs5_Names == "") this.Tabs5_Names = "null";
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs5_Names"];
            this.settingsKey_0.StoreSetting("value", this.Tabs5_Names);

            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs3_Show"];
            this.settingsKey_0.StoreSetting("value", this.Tabs3_Show);
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs4_Show"];
            this.settingsKey_0.StoreSetting("value", this.Tabs4_Show);
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs5_Show"];
            this.settingsKey_0.StoreSetting("value", this.Tabs5_Show);

            this.settingsKey_0 = SettingsFile.Settings["pages/TabsLeft_Split"];
            this.settingsKey_0.StoreSetting("value", this.TabsLeft_Split);
            this.settingsKey_0 = SettingsFile.Settings["pages/TabsTop_Split"];
            this.settingsKey_0.StoreSetting("value", this.TabsTop_Split);
            this.settingsKey_0 = SettingsFile.Settings["pages/TabsBottom_Split"];
            this.settingsKey_0.StoreSetting("value", this.TabsBottom_Split);
            this.settingsKey_0 = SettingsFile.Settings["pages/TabsBottomLeft_Split"];
            this.settingsKey_0.StoreSetting("value", this.TabsBottomLeft_Split);
            this.settingsKey_0 = SettingsFile.Settings["pages/TabsRight_Split"];
            this.settingsKey_0.StoreSetting("value", this.TabsRight_Split);

            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs1_Selected"];
            this.settingsKey_0.StoreSetting("value", this.Tabs1_Selected);
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs2_Selected"];
            this.settingsKey_0.StoreSetting("value", this.Tabs2_Selected);
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs3_Selected"];
            this.settingsKey_0.StoreSetting("value", this.Tabs3_Selected);
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs4_Selected"];
            this.settingsKey_0.StoreSetting("value", this.Tabs4_Selected);
            this.settingsKey_0 = SettingsFile.Settings["pages/Tabs5_Selected"];
            this.settingsKey_0.StoreSetting("value", this.Tabs5_Selected);

            this.settingsKey_0 = SettingsFile.Settings["pages/Parameter_Splitter"];
            this.settingsKey_0.StoreSetting("value", this.Parameter_Splitter);

            this.settingsKey_0 = SettingsFile.Settings["pages/WindowedMode"];
            this.settingsKey_0.StoreSetting("value", this.WindowedMode);

            this.settingsKey_0 = SettingsFile.Settings["Main/OverlayConditionsDisabled"];
            this.settingsKey_0.StoreSetting("value", this.OverlayConditionsDisabled);
            this.settingsKey_0 = SettingsFile.Settings["Main/LogDatetime"];
            this.settingsKey_0.StoreSetting("value", this.LogDatetime);

            this.settingsKey_0 = SettingsFile.Settings["tuner/filterIsUse"];
            this.settingsKey_0.StoreSetting("value", this.bool_51);

            this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarFile"];
            this.settingsKey_0.StoreSetting("value", this.ToolbarFile);
            this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarEdit"];
            this.settingsKey_0.StoreSetting("value", this.ToolbarEdit);
            this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarEmulator"];
            this.settingsKey_0.StoreSetting("value", this.ToolbarEmulator);
            this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarDatalog"];
            this.settingsKey_0.StoreSetting("value", this.ToolbarDatalog);
            this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarView"];
            this.settingsKey_0.StoreSetting("value", this.ToolbarView);
            this.settingsKey_0 = SettingsFile.Settings["Main/ToolbarTools"];
            this.settingsKey_0.StoreSetting("value", this.ToolbarTools);

            this.settingsKey_0 = SettingsFile.Settings["Main/LiveGraphing"];
            this.settingsKey_0.StoreSetting("value", this.LiveGraphing);
            this.settingsKey_0 = SettingsFile.Settings["Main/LiveGraph_Lenght"];
            this.settingsKey_0.StoreSetting("value", this.LiveGraph_Lenght);


            try
            {
                this.settingsKey_0 = SettingsFile.Settings["Main/ICutModInstall"];
                this.settingsKey_0.StoreSetting("value", this.ICutModInstall);
            }
            catch { }

            this.settingsKey_0 = SettingsFile.Settings["Main/BoostFuel"];
            this.settingsKey_0.StoreSetting("value", this.BoostFuel);
            this.settingsKey_0 = SettingsFile.Settings["Main/BoostRetard"];
            this.settingsKey_0.StoreSetting("value", this.BoostRetard);

            this.settingsKey_0 = SettingsFile.Settings["Main/IsBluetooth"];
            this.settingsKey_0.StoreSetting("value", this.IsBluetooth);
            this.settingsKey_0 = SettingsFile.Settings["Main/LastPackageChecksum"];
            this.settingsKey_0.StoreSetting("value", this.LastPackageChecksum);
            this.settingsKey_0 = SettingsFile.Settings["Main/LogAdvancedDatas"];
            this.settingsKey_0.StoreSetting("value", this.LogAdvancedDatas);

            try
            {
                this.settingsKey_0 = SettingsFile.Settings["Main/BurnerLocation"];
                this.settingsKey_0.StoreSetting("value", this.BurnerLocation);
            }
            catch { }
            this.settingsKey_0 = SettingsFile.Settings["Main/BurnerSoftware"];
            this.settingsKey_0.StoreSetting("value", this.BurnerSoftware);
            this.settingsKey_0 = SettingsFile.Settings["Main/GlitchedBaseromTestInterval"];
            this.settingsKey_0.StoreSetting("value", this.GlitchedBaseromTestInterval);

            this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Gauges"];
            this.settingsKey_0.StoreSetting("value", this.ShownHint_Gauges);
            this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Colors"];
            this.settingsKey_0.StoreSetting("value", this.ShownHint_Colors);
            this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Separator"];
            this.settingsKey_0.StoreSetting("value", this.ShownHint_Separator);
            this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_Dragging"];
            this.settingsKey_0.StoreSetting("value", this.ShownHint_Dragging);
            this.settingsKey_0 = SettingsFile.Settings["Main/ShownHint_DebugLogs"];
            this.settingsKey_0.StoreSetting("value", this.ShownHint_DebugLogs);

            this.settingsKey_0 = SettingsFile.Settings["Main/AccelTimerSpeedStart"];
            this.settingsKey_0.StoreSetting("value", this.AccelTimerSpeedStart);
            this.settingsKey_0 = SettingsFile.Settings["Main/AccelTimerSpeedEnd"];
            this.settingsKey_0.StoreSetting("value", this.AccelTimerSpeedEnd);

            this.settingsKey_0 = SettingsFile.Settings["Main/burnChipIndex"];
            this.settingsKey_0.StoreSetting("value", this.burnChipIndex);
            this.settingsKey_0 = SettingsFile.Settings["Main/burnCommCache"];
            this.settingsKey_0.StoreSetting("value", this.burnCommCache);
            if (this.calFilePath != null && this.calFilePath != string.Empty)
            {
                this.settingsKey_0 = SettingsFile.Settings["Main/calFilePath"];
                this.settingsKey_0.StoreSetting("value", this.calFilePath);
            }
            this.settingsKey_0 = SettingsFile.Settings["Main/dtCommCache"];
            this.settingsKey_0.StoreSetting("value", this.dtCommCache);
            this.settingsKey_0 = SettingsFile.Settings["Main/dtPeakShown"];
            this.settingsKey_0.StoreSetting("value", this.dtPeakShown);
            this.settingsKey_0 = SettingsFile.Settings["Main/emuCommCache"];
            this.settingsKey_0.StoreSetting("value", this.emuCommCache);
            if (this.logFilePath != null && this.logFilePath != string.Empty)
            {
                this.settingsKey_0 = SettingsFile.Settings["Main/logFilePath"];
                this.settingsKey_0.StoreSetting("value", this.logFilePath);
            }
            this.settingsKey_0 = SettingsFile.Settings["Main/overlay1_Display"];
            this.settingsKey_0.StoreSetting("value", this.overlay1_Display);
            this.settingsKey_0 = SettingsFile.Settings["Main/overlay2_Display"];
            this.settingsKey_0.StoreSetting("value", this.overlay2_Display);
            this.settingsKey_0 = SettingsFile.Settings["Main/overlay3_Display"];
            this.settingsKey_0.StoreSetting("value", this.overlay3_Display);
            if (this.parameterNode != null && this.parameterNode != string.Empty)
            {
                this.settingsKey_0 = SettingsFile.Settings["Main/parameterNode"];
                this.settingsKey_0.StoreSetting("value", this.parameterNode);
            }
            if (this.romFilePath != null && this.romFilePath != string.Empty)
            {
                this.settingsKey_0 = SettingsFile.Settings["Main/romFilePath"];
                this.settingsKey_0.StoreSetting("value", this.romFilePath);
            }
            this.settingsKey_0 = SettingsFile.Settings["Main/tunerSmartTrack"];
            this.settingsKey_0.StoreSetting("value", this.tunerSmartTrack);

            this.settingsKey_0 = SettingsFile.Settings["Windows/dataloggingToolStrip"];
            this.settingsKey_0.StorePoint("value", this.dataloggingToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/mainToolStrip"];
            this.settingsKey_0.StorePoint("value", this.mainToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/viewToolStrip"];
            this.settingsKey_0.StorePoint("value", this.viewToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/editToolStrip"];
            this.settingsKey_0.StorePoint("value", this.editToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/windowsToolStrip"];
            this.settingsKey_0.StorePoint("value", this.windowsToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/emulatorToolStrip"];
            this.settingsKey_0.StorePoint("value", this.emulatorToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/tunerToolStrip"];
            this.settingsKey_0.StorePoint("value", this.tunerToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/tableEditToolStrip"];
            this.settingsKey_0.StorePoint("value", this.tableEditToolStrip);
            this.settingsKey_0 = SettingsFile.Settings["Windows/tableViewToolStrip"];
            this.settingsKey_0.StorePoint("value", this.tableViewToolStrip);

            this.settingsKey_0 = SettingsFile.Settings["Windows/Display_Location"];
            this.settingsKey_0.StorePoint("value", this.Display_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/logGraphs_Location"];
            this.settingsKey_0.StorePoint("value", this.logGraphs_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/logGrid_Location"];
            this.settingsKey_0.StorePoint("value", this.logGrid_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/parameters_Location"];
            this.settingsKey_0.StorePoint("value", this.parameters_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/tables_Location"];
            this.settingsKey_0.StorePoint("value", this.tables_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/Debug_Location"];
            this.settingsKey_0.StorePoint("value", this.Debug_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/errorCodes_Location"];
            this.settingsKey_0.StorePoint("value", this.errorCodes_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/LivePlot_Location"];
            this.settingsKey_0.StorePoint("value", this.LivePlot_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/snapShots_Location"];
            this.settingsKey_0.StorePoint("value", this.snapShots_Location);
            this.settingsKey_0 = SettingsFile.Settings["Windows/DynoC_Location"];
            this.settingsKey_0.StorePoint("value", this.DynoC_Location);

            this.settingsKey_0 = SettingsFile.Settings["Windows/Display_Size"];
            this.settingsKey_0.StoreSize("value", this.Display_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/logGraphs_Size"];
            this.settingsKey_0.StoreSize("value", this.logGraphs_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/logGrid_Size"];
            this.settingsKey_0.StoreSize("value", this.logGrid_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/parameters_Size"];
            this.settingsKey_0.StoreSize("value", this.parameters_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/tables_Size"];
            this.settingsKey_0.StoreSize("value", this.tables_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/Debug_Size"];
            this.settingsKey_0.StoreSize("value", this.Debug_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/errorCodes_Size"];
            this.settingsKey_0.StoreSize("value", this.errorCodes_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/LivePlot_Size"];
            this.settingsKey_0.StoreSize("value", this.LivePlot_Size);
            this.settingsKey_0 = SettingsFile.Settings["Windows/DynoC_Size"];
            this.settingsKey_0.StoreSize("value", this.DynoC_Size);

            for (int i = 0; i < this.ShortcutsKeys.Count; i++)
            {
                this.settingsKey_0 = SettingsFile.Settings["shortcuts/shortcut" + i];
                this.settingsKey_0.StoreSetting("shortcut", this.ShortcutsKeys[i]);
            }



            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_COMPort"];
            if (this.Dyno_COMPort != null && this.Dyno_COMPort != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_COMPort);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_COMPortBC"];
            if (this.Dyno_COMPortBC != null && this.Dyno_COMPortBC != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_COMPortBC);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUX1Type"];
            if (this.Dyno_AUX1Type != null && this.Dyno_AUX1Type != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUX1Type);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUX2Type"];
            if (this.Dyno_AUX2Type != null && this.Dyno_AUX2Type != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUX2Type);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUX3Type"];
            if (this.Dyno_AUX3Type != null && this.Dyno_AUX3Type != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUX3Type);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN1V"];
            if (this.Dyno_AUXMIN1V != null && this.Dyno_AUXMIN1V != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMIN1V);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN2V"];
            if (this.Dyno_AUXMIN2V != null && this.Dyno_AUXMIN2V != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMIN2V);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN3V"];
            if (this.Dyno_AUXMIN3V != null && this.Dyno_AUXMIN3V != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMIN3V);

            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX1V"];
            if (this.Dyno_AUXMAX1V != null && this.Dyno_AUXMAX1V != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMAX1V);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX2V"];
            if (this.Dyno_AUXMAX2V != null && this.Dyno_AUXMAX2V != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMAX2V);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX3V"];
            if (this.Dyno_AUXMAX3V != null && this.Dyno_AUXMAX3V != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMAX3V);

            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN1O"];
            if (this.Dyno_AUXMIN1O != null && this.Dyno_AUXMIN1O != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMIN1O);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN2O"];
            if (this.Dyno_AUXMIN2O != null && this.Dyno_AUXMIN2O != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMIN2O);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMIN3O"];
            if (this.Dyno_AUXMIN3O != null && this.Dyno_AUXMIN3O != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMIN3O);

            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX1O"];
            if (this.Dyno_AUXMAX1O != null && this.Dyno_AUXMAX1O != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMAX1O);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX2O"];
            if (this.Dyno_AUXMAX2O != null && this.Dyno_AUXMAX2O != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMAX2O);
            this.settingsKey_0 = SettingsFile.Settings["dyno/Dyno_AUXMAX3O"];
            if (this.Dyno_AUXMAX3O != null && this.Dyno_AUXMAX3O != string.Empty) this.settingsKey_0.StoreSetting("value", this.Dyno_AUXMAX3O);

            SettingsFile.Update();
        }
    }

    public void method_30()
    {
        this.double_1 = new double[this.double_0.Length];
        for (int i = 0; i < (this.double_0.Length - 1); i++)
        {
            double num = this.double_0[i];
            this.double_1[i] = this.double_0[i + 1];
            this.double_1[i + 1] = num;
            i++;
        }
    }

    public void method_4(bool bool_65)
    {
        if (this.delegate13_0 != null)
        {
            this.delegate13_0(bool_65);
        }
    }

    private void method_6()
    {
        string path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Graph.txt";
        FileInfo info = new FileInfo(path2);
        if (!info.Exists)
        {
            this.chartCollection_0 = new ChartCollection();
        }
        else
        {
            //#####
            try
            {
                this.chartCollection_0 = new ChartCollection();
                for (int i = this.chartCollection_0.ChartTemplate_0.Count -1; i >= 0; i--) this.chartCollection_0.removeTemplateAt(i);

                string[] AllLines = File.ReadAllLines(path2);
                if (AllLines.Length > 0)
                {
                    for (int i = 0; i < AllLines.Length; i++)
                    {
                        if (AllLines[i].Contains("Template") && !AllLines[i].Contains("TemplateEnd"))
                        {
                            ChartTemplate CurrentTemplate = new ChartTemplate();

                            string[] SplitT = AllLines[i].Split('=');
                            CurrentTemplate.templateName = SplitT[1];

                            int CurrentNextLine = i + 1;
                            int CurrentChart = 0;
                            while (!AllLines[CurrentNextLine].Contains("TemplateEnd"))
                            {
                                if (AllLines[CurrentNextLine].Contains("Chart") && !AllLines[i].Contains("ChartEnd"))
                                {
                                    string[] SplitC = AllLines[CurrentNextLine].Split('=');
                                    CurrentTemplate.ChartsEnable[CurrentChart] = bool.Parse(SplitC[1]);
                                    CurrentNextLine++;

                                    ChartSetup[] ChartSetup = new Data.ChartSetup[4];

                                    ChartSetup[0] = new Data.ChartSetup();
                                    ChartSetup[1] = new Data.ChartSetup();
                                    ChartSetup[2] = new Data.ChartSetup();
                                    ChartSetup[3] = new Data.ChartSetup();

                                    int CurrentChartSetup = 0;
                                    while (!AllLines[CurrentNextLine].Contains("ChartEnd"))
                                    {
                                        if (AllLines[CurrentNextLine].Contains("Color"))
                                        {
                                            string[] SplitC2 = AllLines[CurrentNextLine].Split('=');
                                            string[] SplitC2_Dual = SplitC2[1].Split(',');
                                            ChartSetup[CurrentChart].colors[CurrentChartSetup] = Color.FromArgb(255, int.Parse(SplitC2_Dual[0]), int.Parse(SplitC2_Dual[1]), int.Parse(SplitC2_Dual[2]));
                                            CurrentNextLine++;
                                        }
                                        if (AllLines[CurrentNextLine].Contains("PlotEnabled"))
                                        {
                                            string[] SplitC2 = AllLines[CurrentNextLine].Split('=');
                                            ChartSetup[CurrentChart].plotLinesEnable[CurrentChartSetup] = bool.Parse(SplitC2[1]);
                                            CurrentNextLine++;
                                        }
                                        if (AllLines[CurrentNextLine].Contains("sensor"))
                                        {
                                            string[] SplitC2 = AllLines[CurrentNextLine].Split('=');
                                            ChartSetup[CurrentChart].Sensors_0[CurrentChartSetup] = (SensorsX)int.Parse(SplitC2[1]);
                                            CurrentNextLine++;
                                        }
                                        CurrentChartSetup++;
                                    }
                                    CurrentTemplate.ChartSetup[CurrentChart] = ChartSetup[CurrentChart];
                                    CurrentChart++;
                                }

                                CurrentNextLine++;
                            }

                            this.chartCollection_0.addThisTemplate(CurrentTemplate);
                        }
                    }
            }
            }
            catch (Exception mess)
            {
                LogThisGraph("Error while loading Graph Layout:" + Environment.NewLine + "" + mess);

                this.chartCollection_0 = new ChartCollection();
                method_7();
            }
            GC.Collect(3, GCCollectionMode.Forced);
        }
    }


    private void LogThisGraph(string string_8)
    {
        this.frmMain_0.LogThis("Graph - " + string_8);
    }

    private void LogThis(string string_8)
    {
        this.frmMain_0.LogThis("Settings - " + string_8);
    }

    private void method_7()
    {
        string path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Graph.txt";
        FileInfo info = new FileInfo(path2);
        if (info.Exists) info.Delete();

        string SaveStr = "";
        for (int i = 0; i < this.chartCollection_0.ChartTemplate_0.Count; i++)
        {
            SaveStr += "Template" + i + "=" + this.chartCollection_0.ChartTemplate_0[i].templateName + Environment.NewLine;
            for (int i2 = 0; i2 < this.chartCollection_0.ChartTemplate_0[i].ChartSetup.Length; i2++)
            {
                SaveStr += "\tChart" + i2 + "=" + this.chartCollection_0.ChartTemplate_0[i].ChartsEnable[i2].ToString() + Environment.NewLine;
                for (int i3 = 0; i3 < this.chartCollection_0.ChartTemplate_0[i].ChartSetup[i2].plotLinesEnable.Length; i3++)
                {
                    SaveStr += "\t\tColor" + i3 + "=" + this.chartCollection_0.ChartTemplate_0[i].ChartSetup[i2].colors[i3].R + "," + this.chartCollection_0.ChartTemplate_0[i].ChartSetup[i2].colors[i3].G + "," + this.chartCollection_0.ChartTemplate_0[i].ChartSetup[i2].colors[i3].B + Environment.NewLine;
                    SaveStr += "\t\tPlotEnabled" + i3 + "=" + this.chartCollection_0.ChartTemplate_0[i].ChartSetup[i2].plotLinesEnable[i3].ToString() + Environment.NewLine;
                    SaveStr += "\t\tsensor" + i3 + "=" + (int)this.chartCollection_0.ChartTemplate_0[i].ChartSetup[i2].Sensors_0[i3] + Environment.NewLine;

                }
                SaveStr += "\tChartEnd" + Environment.NewLine;
            }
            SaveStr += "TemplateEnd" + Environment.NewLine;
        }
        File.Create(path2).Dispose();
        File.WriteAllText(path2, SaveStr);
    }

    public DataloggingTable method_8()
    {
        return this.dataloggingTable_0;
    }

    public void method_9(DataloggingTable dataloggingTable_2)
    {
        this.bool_28 = true;
        this.dataloggingTable_1 = dataloggingTable_2;
    }

    public bool GetKeyPressed(KeyEventArgs e, string ThisKey)
    {
        bool Pressed = false;
        try
        {
            for (int i = 0; i < this.ShortcutsKeys.Count; i++)
            {
                if (this.ShortcutsKeys[i].Contains("~"))
                {
                    string[] SplittedCMD2 = this.ShortcutsKeys[i].Split('~');
                    if (ThisKey == SplittedCMD2[4])
                    {
                        bool PressCTRL = bool.Parse(SplittedCMD2[0]);
                        bool PressALT = bool.Parse(SplittedCMD2[1]);
                        bool PressSHIFT = bool.Parse(SplittedCMD2[2]);
                        Keys KeyPressed = this.frmMain_0.class28_Shortcuts_0.GetKeyCode(SplittedCMD2[3]);

                        if (e.KeyCode == KeyPressed && e.Control == PressCTRL && e.Shift == PressALT && e.Alt == PressSHIFT) Pressed = true;

                        i = this.ShortcutsKeys.Count;
                    }
                }
            }
        }
        catch (Exception mess)
        {
            LogThisGraph("Error getting KeyPressed for Key: '" + ThisKey + "' with error:" + Environment.NewLine + "" + mess);
        }

        return Pressed;
    }

    public bool GetKeySettings(string ThisKeyDesc)
    {
        bool Found = false;

        try
        {
            for (int i = 0; i < this.ShortcutsKeys.Count; i++)
            {
                if (this.ShortcutsKeys[i].Contains("~"))
                {
                    string[] SplittedCMD2 = this.ShortcutsKeys[i].Split('~');
                    if (ThisKeyDesc == SplittedCMD2[4])
                    {
                        Shortcut_PressCTRL = bool.Parse(SplittedCMD2[0]);
                        Shortcut_PressALT = bool.Parse(SplittedCMD2[1]);
                        Shortcut_PressSHIFT = bool.Parse(SplittedCMD2[2]);
                        Shortcut_KeyPressed = this.frmMain_0.class28_Shortcuts_0.GetKeyCode(SplittedCMD2[3]);
                        Shortcut_KeyName = SplittedCMD2[3];

                        Found = true;

                        i = this.ShortcutsKeys.Count;
                    }
                }
            }
        }
        catch (Exception mess)
        {
            LogThisGraph("Error getting KeySetting for Key: '" + ThisKeyDesc + "' with error:" + Environment.NewLine + "" + mess);
        }

        return Found;
    }

    public void LoadShortcuts()
    {
        this.ShortcutsKeys = new List<string>();

        //Control, Alt, Shift, KeyPressed, Description
        this.ShortcutsKeys.Add("true~false~false~C~Copy");
        this.ShortcutsKeys.Add("true~false~false~V~Paste");
        this.ShortcutsKeys.Add("true~false~false~N~New Basemap");
        this.ShortcutsKeys.Add("true~false~false~O~Open File");
        this.ShortcutsKeys.Add("true~false~false~S~Save File As");
        this.ShortcutsKeys.Add("false~true~false~S~Save File");
        this.ShortcutsKeys.Add("true~false~false~Q~Quit");
        this.ShortcutsKeys.Add("true~false~false~Z~Undo");
        this.ShortcutsKeys.Add("true~false~false~Y~Redo");
        this.ShortcutsKeys.Add("true~false~false~T~Open Tables");
        this.ShortcutsKeys.Add("true~false~false~P~Open Parameters");
        this.ShortcutsKeys.Add("true~false~false~E~Open Error Code");
        this.ShortcutsKeys.Add("true~false~false~I~Open Timing Sync");
        this.ShortcutsKeys.Add("true~false~false~B~Open Boost Table");
        this.ShortcutsKeys.Add("true~false~false~D~Open Dyno Control");
        this.ShortcutsKeys.Add("true~false~false~Q~Open Snapshots List");
        this.ShortcutsKeys.Add("true~true~false~T~Open TPS Calibration");
        this.ShortcutsKeys.Add("true~false~false~K~Kill Injectors");
        this.ShortcutsKeys.Add("true~false~false~F~Kill Fuel Pump (Off)");

        this.ShortcutsKeys.Add("false~false~false~F1~Primary Low Ignition");
        this.ShortcutsKeys.Add("false~false~false~F2~Primary High Ignition");
        this.ShortcutsKeys.Add("false~false~false~F3~Primary Low Fuel");
        this.ShortcutsKeys.Add("false~false~false~F4~Primary High Fuel");
        this.ShortcutsKeys.Add("false~false~true~F1~Secondary Low Ignition");
        this.ShortcutsKeys.Add("false~false~true~F2~Secondary High Ignition");
        this.ShortcutsKeys.Add("false~false~true~F3~Secondary Low Fuel");
        this.ShortcutsKeys.Add("false~false~true~F4~Secondary High Fuel");
        this.ShortcutsKeys.Add("false~false~false~F5~Show Map Values");
        this.ShortcutsKeys.Add("false~false~false~F6~Show A/F Target");
        this.ShortcutsKeys.Add("false~false~false~F7~Show A/F Reading");
        this.ShortcutsKeys.Add("false~false~false~F8~Show Fuel Difference");
        this.ShortcutsKeys.Add("false~false~false~F9~Show VE Table");
        this.ShortcutsKeys.Add("false~false~false~F10~Show Raw Fuel Value");
        this.ShortcutsKeys.Add("false~false~false~F11~Show Fuel Duty Cycle");
        this.ShortcutsKeys.Add("false~false~false~F12~Show Injector Duration");
        this.ShortcutsKeys.Add("false~false~true~F5~Graph 2D View");
        this.ShortcutsKeys.Add("false~false~true~F6~Graph 3D View");
        this.ShortcutsKeys.Add("false~false~true~F7~Graph 2D/3D View - Bellow Table");
        this.ShortcutsKeys.Add("false~false~true~F8~Graph 2D/3D View - Only N/A");

        this.ShortcutsKeys.Add("true~false~false~UP~Increase Selected Cells");
        this.ShortcutsKeys.Add("true~false~false~DOWN~Decrease Selected Cells");
        this.ShortcutsKeys.Add("true~false~false~J~Adjust Selection");
        this.ShortcutsKeys.Add("false~false~false~PAGE UP~Increase Selected Cells #2");
        this.ShortcutsKeys.Add("false~false~false~PAGE DOWN~Decrease Selected Cells #2");
        this.ShortcutsKeys.Add("true~false~true~G~Clear Current Selection");
        this.ShortcutsKeys.Add("true~false~true~M~Smooth current selection/map");
        this.ShortcutsKeys.Add("true~false~true~R~Interpolate rows");
        this.ShortcutsKeys.Add("true~false~true~C~Interpolate columns");
        this.ShortcutsKeys.Add("true~false~true~I~Interpolate All X & Y");
        this.ShortcutsKeys.Add("false~true~true~RIGHT~Increase map size width");
        this.ShortcutsKeys.Add("false~true~true~LEFT~Decrease map size width");
        this.ShortcutsKeys.Add("false~true~false~M~Map trail toggle");
        this.ShortcutsKeys.Add("true~true~false~C~Clear all recording");
        this.ShortcutsKeys.Add("false~false~true~F10~Clear live plot");
        this.ShortcutsKeys.Add("false~false~false~ESC~Press escape to cancel the current dragging");
        this.ShortcutsKeys.Add("true~false~true~E~Connect to emulator");
        this.ShortcutsKeys.Add("true~false~true~P~Upload Rom");
        this.ShortcutsKeys.Add("true~false~true~G~Get Rom");
        this.ShortcutsKeys.Add("true~false~true~V~Verify Rom");
        this.ShortcutsKeys.Add("true~false~true~C~Upload calibration");
        this.ShortcutsKeys.Add("true~false~true~T~Realtime update toggle");
        this.ShortcutsKeys.Add("true~true~false~D~Connect to ecu/datalogging");
        this.ShortcutsKeys.Add("true~true~false~L~Open datalog file");
        this.ShortcutsKeys.Add("true~true~false~S~Save datalog file");
        this.ShortcutsKeys.Add("true~true~false~UP~Play datalog file");
        this.ShortcutsKeys.Add("true~true~false~DOWN~Pause datalog file");
        this.ShortcutsKeys.Add("true~false~false~L~Scroll tru datalog file");
        this.ShortcutsKeys.Add("false~true~false~T~Smart track toggle");
        this.ShortcutsKeys.Add("false~true~false~M~Map trail toggle");

        this.ShortcutsKeys.Add("false~true~false~V~Follow Vtec");
        this.ShortcutsKeys.Add("false~true~false~D~Follow Secondary Map");
        this.ShortcutsKeys.Add("true~true~false~A~Auto Adjust Selection");
        this.ShortcutsKeys.Add("false~false~true~F10~Clear data live plot");

        this.ShortcutsKeys.Add("true~false~false~D~Datalog Display");
        this.ShortcutsKeys.Add("true~false~false~S~Datalog Data");
        this.ShortcutsKeys.Add("true~false~false~G~Datalog Graphs");
        this.ShortcutsKeys.Add("true~false~false~LEFT~Move datalog cursor left");
        this.ShortcutsKeys.Add("true~false~false~RIGHT~Move datalog cursor right");
        this.ShortcutsKeys.Add("true~false~true~LEFT~Move datalog cursor large step left");
        this.ShortcutsKeys.Add("true~false~true~RIGHT~Move datalog cursor large step right");
        this.ShortcutsKeys.Add("true~false~true~UP~Zoom in");
        this.ShortcutsKeys.Add("true~false~true~DOWN~Zoom out");
        //this.ShortcutsKeys.Add("false~false~false~~");

        for (int i = 0; i < this.ShortcutsKeys.Count; i++)
        {
            this.settingsKey_0 = SettingsFile.Settings["shortcuts/shortcut" + i];
            this.ShortcutsKeys[i] = this.settingsKey_0.GetSetting("shortcut", this.ShortcutsKeys[i]);
        }
    }

    public void SaveThisShortcuts(string ThisShorcut)
    {
        try {
            string[] SplittedCMD = ThisShorcut.Split('~');


            for (int i = 0; i < this.ShortcutsKeys.Count; i++)
            {
                if (this.ShortcutsKeys[i].Contains("~"))
                {
                    string[] SplittedCMD2 = this.ShortcutsKeys[i].Split('~');
                    if (SplittedCMD[4] == SplittedCMD2[4]) {
                        this.ShortcutsKeys[i] = ThisShorcut;

                        this.settingsKey_0 = SettingsFile.Settings["shortcuts/shortcut" + i];
                        this.settingsKey_0.StoreSetting("shortcut", this.ShortcutsKeys[i]);
                        SettingsFile.smethod_1();

                        this.frmMain_0.ReloadShortcuts();
                        if (this.frmMain_0.frmGridChart_0 != null) this.frmMain_0.frmGridChart_0.ReloadShortcuts();
                        i = this.ShortcutsKeys.Count;
                    }
                }
            }
        }
        catch (Exception mess)
        {
            LogThisGraph("Error saving data for Key: '" + ThisShorcut + "' with error:" + Environment.NewLine + "" + mess);
        }
    }

    public void method_list()
    {
        this.SensorsTags = new List<string>();
        this.SensorsNames = new List<string>();
        this.SensorsDesc = new List<string>();
        this.SensorsMin = new List<int>();
        this.SensorsMax = new List<int>();

        this.SensorsCustomMin = new List<int>();
        this.SensorsCustomMax = new List<int>();
        this.SensorsCustomINT = new List<bool>();

        //rpmX
        //vssX
        //gearX
        //mapX
        //boostX
        //paX
        //tpsX
        //ectX
        //iatX
        //outVtsX
        //ebcDutyX

        this.SensorsTags.Add("rpmX"); this.SensorsNames.Add("RPM"); this.SensorsDesc.Add("Engine speed"); this.SensorsMin.Add(9000); this.SensorsMax.Add(9500); this.SensorsCustomMin.Add(28); this.SensorsCustomMax.Add(11000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("vssX"); this.SensorsNames.Add("VSS"); this.SensorsDesc.Add("Vehicle speed"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gearX"); this.SensorsNames.Add("Gear"); this.SensorsDesc.Add("Vehicle gear"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(6); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("mapX"); this.SensorsNames.Add("MAP"); this.SensorsDesc.Add("Manifold abosolute pressure"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(3000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("boostX"); this.SensorsNames.Add("Boost"); this.SensorsDesc.Add("Manifold boost"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(40); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("paX"); this.SensorsNames.Add("PA"); this.SensorsDesc.Add("Athmopheric pressure"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(1100); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("tpsX"); this.SensorsNames.Add("TPS"); this.SensorsDesc.Add("Throttle position sensor"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-5); this.SensorsCustomMax.Add(115); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("tpsV"); this.SensorsNames.Add("TPS Voltage"); this.SensorsDesc.Add("Throttle position sensor Voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(5); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("injDur"); this.SensorsNames.Add("INJ Duration"); this.SensorsDesc.Add("Opening time of the injectors"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(20); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("injDuty"); this.SensorsNames.Add("INJ Duty"); this.SensorsDesc.Add("Injector duty cycle"); this.SensorsMin.Add(80); this.SensorsMax.Add(100); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(130); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("injFV"); this.SensorsNames.Add("Fuel Value"); this.SensorsDesc.Add("The final fuel value"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(2000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ignFnl"); this.SensorsNames.Add("IGN Final"); this.SensorsDesc.Add("Ignition advance final"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-6); this.SensorsCustomMax.Add(60); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ignTbl"); this.SensorsNames.Add("IGN Table"); this.SensorsDesc.Add("Ignition advance from ignition table"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-6); this.SensorsCustomMax.Add(60); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ectX"); this.SensorsNames.Add("ECT"); this.SensorsDesc.Add("Engine coolant temperature sensor"); this.SensorsMin.Add(100); this.SensorsMax.Add(110); this.SensorsCustomMin.Add(-40); this.SensorsCustomMax.Add(140); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("iatX"); this.SensorsNames.Add("IAT"); this.SensorsDesc.Add("Intake air temperature sensor"); this.SensorsMin.Add(65); this.SensorsMax.Add(100); this.SensorsCustomMin.Add(-40); this.SensorsCustomMax.Add(140); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("afr"); this.SensorsNames.Add("A/F Ratio"); this.SensorsDesc.Add("Air fuel ratio"); this.SensorsMin.Add(17); this.SensorsMax.Add(20); this.SensorsCustomMin.Add(10); this.SensorsCustomMax.Add(20); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("o2V"); this.SensorsNames.Add("O2 Voltage"); this.SensorsDesc.Add("The O2 sensor voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(16); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("batV"); this.SensorsNames.Add("BAT Voltage"); this.SensorsDesc.Add("Battery voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(16); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("eldV"); this.SensorsNames.Add("ELD Voltage"); this.SensorsDesc.Add("Electronic load dector voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(16); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("knockV"); this.SensorsNames.Add("Knock Level"); this.SensorsDesc.Add("Knock sensor voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(5); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("mapV"); this.SensorsNames.Add("MAP Voltage"); this.SensorsDesc.Add("Manifold air presure sensor voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(5); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("mil"); this.SensorsNames.Add("MIL"); this.SensorsDesc.Add("Malfunciton indicator light"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ectFc"); this.SensorsNames.Add("ECT Fuel.c"); this.SensorsDesc.Add("Fuel correction based on ECT"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("iatFc"); this.SensorsNames.Add("IAT Fuel.c"); this.SensorsDesc.Add("Fuel correction based on IAT"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("o2Short"); this.SensorsNames.Add("O2 Short"); this.SensorsDesc.Add("Closeloop fuel correction short term"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("o2Long"); this.SensorsNames.Add("O2 Long"); this.SensorsDesc.Add("Closeloop fuel correction long term"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("veFc"); this.SensorsNames.Add("VE Fuel.c"); this.SensorsDesc.Add("VE table fuel correction"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ectIc"); this.SensorsNames.Add("ECT Ign.c"); this.SensorsDesc.Add("Ignition correction based on ECT"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-6); this.SensorsCustomMax.Add(60); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("iatIc"); this.SensorsNames.Add("IAT Ign.c"); this.SensorsDesc.Add("Ignition correction based on IAT"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-6); this.SensorsCustomMax.Add(60); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("frame"); this.SensorsNames.Add("Frame"); this.SensorsDesc.Add("Datalog frame count. Click on frame cell to change the frame index."); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(9999); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("interval"); this.SensorsNames.Add("Interval"); this.SensorsDesc.Add("Interval for each frame in milliSeconds"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("duration"); this.SensorsNames.Add("Duration"); this.SensorsDesc.Add("Duration of recording"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(60); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outVtsX"); this.SensorsNames.Add("VTS"); this.SensorsDesc.Add("Output Vtec" + Environment.NewLine + "Pin A4"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outVtsM"); this.SensorsNames.Add("VTS Maps"); this.SensorsDesc.Add("Output vtec map switch"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outAc"); this.SensorsNames.Add("ACC"); this.SensorsDesc.Add("Output Airconditioning" + Environment.NewLine + "Pin A15"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outO2h"); this.SensorsNames.Add("O2 Heater"); this.SensorsDesc.Add("Output to O2 sensor heater" + Environment.NewLine + "Pin A6"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outMil"); this.SensorsNames.Add("MIL"); this.SensorsDesc.Add("Output to check engine indicator" + Environment.NewLine + "Pin A13"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outPurge"); this.SensorsNames.Add("PCS"); this.SensorsDesc.Add("Output to purge canister" + Environment.NewLine + "Pin A20"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outFanc"); this.SensorsNames.Add("RadFC"); this.SensorsDesc.Add("Output to radiator fan" + Environment.NewLine + "Pin A12"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outFpump"); this.SensorsNames.Add("FP"); this.SensorsDesc.Add("Output to fuelpump" + Environment.NewLine + "Pin A7"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outIab"); this.SensorsNames.Add("IAB"); this.SensorsDesc.Add("IAB output" + Environment.NewLine + "Pin A17"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inPsp"); this.SensorsNames.Add("PSP"); this.SensorsDesc.Add("Powersteering switch input" + Environment.NewLine + "Pin B8"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inStartS"); this.SensorsNames.Add("Start Signal"); this.SensorsDesc.Add("Start signal input" + Environment.NewLine + "Pin B9"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inParkN"); this.SensorsNames.Add("Park Indicator"); this.SensorsDesc.Add("Park/neutural indicator input" + Environment.NewLine + "On every ecu" + Environment.NewLine + "Pin B7"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inSCC"); this.SensorsNames.Add("SCC"); this.SensorsDesc.Add("Service Check connector input" + Environment.NewLine + "Pin D4"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inAccs"); this.SensorsNames.Add("ACSW"); this.SensorsDesc.Add("Ac request input" + Environment.NewLine + "Pin B5"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inBksw"); this.SensorsNames.Add("BKSW"); this.SensorsDesc.Add("Brake switch input" + Environment.NewLine + "Pin D2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inVtp"); this.SensorsNames.Add("VTP"); this.SensorsDesc.Add("Vtec pressure input" + Environment.NewLine + "Pin D6"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outFuelCut"); this.SensorsNames.Add("Fuel Cut"); this.SensorsDesc.Add("Fuel cut active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inAtShift1"); this.SensorsNames.Add("AT Shift1"); this.SensorsDesc.Add("Automatic shift indicator 1 input" + Environment.NewLine + "Only on AT ecu's" + Environment.NewLine + "Pin B4"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inAtShift2"); this.SensorsNames.Add("AT Shift2"); this.SensorsDesc.Add("Automatic shift indicator 2 input" + Environment.NewLine + "Only on AT ecu's" + Environment.NewLine + "Pin B3"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gearFc"); this.SensorsNames.Add("Gear Fuel.c"); this.SensorsDesc.Add("Fuel correction based on Gear"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gearIc"); this.SensorsNames.Add("Gear Ign.c"); this.SensorsDesc.Add("Ignition correction based on Gear"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-6); this.SensorsCustomMax.Add(60); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("ignitionCut"); this.SensorsNames.Add("Ignition Cut"); this.SensorsDesc.Add("Ignition Cut active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("boostcutActive"); this.SensorsNames.Add("Boost Cut"); this.SensorsDesc.Add("Boost cut  active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ftlInput"); this.SensorsNames.Add("FTL Input"); this.SensorsDesc.Add("3-Step launch control input active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ftsActive"); this.SensorsNames.Add("FTS Active"); this.SensorsDesc.Add("Full Throttle shift active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("antilagActive"); this.SensorsNames.Add("FTS Anti-Lag"); this.SensorsDesc.Add("3-Step AntiLag active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ftsClutchInput"); this.SensorsNames.Add("FTS Clutch Input"); this.SensorsDesc.Add("3-Step full-throttle shift clutch input active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ftlActive"); this.SensorsNames.Add("FTL Active"); this.SensorsDesc.Add("3-Step launch control active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("sccChecker"); this.SensorsNames.Add("SCC Routine"); this.SensorsDesc.Add("Service Check Connector rountine active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("outAltCtrl"); this.SensorsNames.Add("ALT Control"); this.SensorsDesc.Add("Alternator control output"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("inVtsFeedBack"); this.SensorsNames.Add("VTS Feedback"); this.SensorsDesc.Add("Vtec solenoid feedback"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ebcBaseDuty"); this.SensorsNames.Add("PWM Base Duty"); this.SensorsDesc.Add("Displays the base duty cycle for the current gear"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ebcDutyX"); this.SensorsNames.Add("PWM Duty"); this.SensorsDesc.Add("Displays the adjusted duty cycle"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ebcTarget"); this.SensorsNames.Add("PWM Target"); this.SensorsDesc.Add("Displays the pwm boost target"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ebcCurrent"); this.SensorsNames.Add("PWM Current"); this.SensorsDesc.Add("Displays the current boost"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ebcInput"); this.SensorsNames.Add("PWM Input Switch"); this.SensorsDesc.Add("PWM input switch active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ebcActive"); this.SensorsNames.Add("PWM Active"); this.SensorsDesc.Add("PWM active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("postFuel"); this.SensorsNames.Add("PostFuel Active"); this.SensorsDesc.Add("Display the status of postfuel routine"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ebcHiInput"); this.SensorsNames.Add("PWM Hi Switch"); this.SensorsDesc.Add("PWM high boost settings input active/inactive"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("secMaps"); this.SensorsNames.Add("Secondary Maps"); this.SensorsDesc.Add("Secondary maps indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("loadType"); this.SensorsNames.Add("Load Type"); this.SensorsDesc.Add("Current load type indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("test0"); this.SensorsNames.Add("test0"); this.SensorsDesc.Add("test0"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("fanCtrl"); this.SensorsNames.Add("Fan Control Output"); this.SensorsDesc.Add("Output to Fan Control"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gpo1_in"); this.SensorsNames.Add("GPO 1 Input"); this.SensorsDesc.Add("General Purpose Input 1"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gpo1_out"); this.SensorsNames.Add("GPO 1 Output"); this.SensorsDesc.Add("General Purpose Output 1"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gpo2_in"); this.SensorsNames.Add("GPO 2 Input"); this.SensorsDesc.Add("General Purpose Input 2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gpo2_out"); this.SensorsNames.Add("GPO 2 Output"); this.SensorsDesc.Add("General Purpose Output 2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gpo3_in"); this.SensorsNames.Add("GPO 3 Input"); this.SensorsDesc.Add("General Purpose Input 3"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("gpo3_out"); this.SensorsNames.Add("GPO 3 Output"); this.SensorsDesc.Add("General Purpose Output 3"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("bstStage2"); this.SensorsNames.Add("Boost Control Stage 2"); this.SensorsDesc.Add("Boost Control Stage 2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("bstStage3"); this.SensorsNames.Add("Boost Control Stage 3"); this.SensorsDesc.Add("Boost Control Stage 3"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("bstStage4"); this.SensorsNames.Add("Boost Control Stage 4"); this.SensorsDesc.Add("Boost Control Stage 4"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("bstInput"); this.SensorsNames.Add("Boost Control Input"); this.SensorsDesc.Add("Boost Control Input"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("bstActive"); this.SensorsNames.Add("Boost Control Active"); this.SensorsDesc.Add("Boost Active"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("analog1"); this.SensorsNames.Add("Analog Input 1"); this.SensorsDesc.Add("Input on Analog 1"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("analog2"); this.SensorsNames.Add("Analog Input 2"); this.SensorsDesc.Add("Input on Analog 2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("analog3"); this.SensorsNames.Add("Analog Input 3"); this.SensorsDesc.Add("Input on Analog 3"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(0); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("ecuO2V"); this.SensorsNames.Add("O2V Ecu"); this.SensorsDesc.Add("O2 input on d14"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(16); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("wbO2V"); this.SensorsNames.Add("O2V Wideband"); this.SensorsDesc.Add("Wideband O2 voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(16); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("overheatActive"); this.SensorsNames.Add("Overheat Protection"); this.SensorsDesc.Add("Overheat Protection active/inactive indicator"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("iacvDuty"); this.SensorsNames.Add("IACV Duty"); this.SensorsDesc.Add("Idle Air Control Valve Duty"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-100); this.SensorsCustomMax.Add(100); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("leanProtection"); this.SensorsNames.Add("Lean Protection"); this.SensorsDesc.Add("Bit active if lean codition from lean 1 or lean 2 is detected"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(-1); this.SensorsCustomMax.Add(2); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("deltaRpm1"); this.SensorsNames.Add("Delta RPM1"); this.SensorsDesc.Add("Delta RPM1"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(50); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("deltaRpm2"); this.SensorsNames.Add("Delta RPM2"); this.SensorsDesc.Add("Delta RPM2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(50); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("afrTrg"); this.SensorsNames.Add("AFR Target"); this.SensorsDesc.Add("Air Fuel Ratio Target"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(10); this.SensorsCustomMax.Add(20); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("deltaVss"); this.SensorsNames.Add("Delta VSS"); this.SensorsDesc.Add("Delta VSS"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(40); this.SensorsCustomINT.Add(true);

        this.SensorsTags.Add("accelTime"); this.SensorsNames.Add("Acceleration Time"); this.SensorsDesc.Add("Acceleration Time"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(100); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("fuelUsage"); this.SensorsNames.Add("Fuel Usage"); this.SensorsDesc.Add("Engine Fuel Usage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(100); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("egrV"); this.SensorsNames.Add("EGR Voltage"); this.SensorsDesc.Add("EGR Voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(5); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("b6V"); this.SensorsNames.Add("B6 Voltage"); this.SensorsDesc.Add("B6 Voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(5); this.SensorsCustomINT.Add(false);
        
        this.SensorsTags.Add("egt_cht1"); this.SensorsNames.Add("EGT CHT1"); this.SensorsDesc.Add("EGT CHT1"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(500); this.SensorsCustomMax.Add(2000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("egt_cht2"); this.SensorsNames.Add("EGT CHT2"); this.SensorsDesc.Add("EGT CHT2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(500); this.SensorsCustomMax.Add(2000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("egt_cht3"); this.SensorsNames.Add("EGT CHT3"); this.SensorsDesc.Add("EGT CHT3"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(500); this.SensorsCustomMax.Add(2000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("egt_cht4"); this.SensorsNames.Add("EGT CHT4"); this.SensorsDesc.Add("EGT CHT4"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(500); this.SensorsCustomMax.Add(2000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("egt_chtAvg"); this.SensorsNames.Add("EGT CHT4"); this.SensorsDesc.Add("EGT CHT4"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(500); this.SensorsCustomMax.Add(2000); this.SensorsCustomINT.Add(true);
        this.SensorsTags.Add("backPres"); this.SensorsNames.Add("Back Pressure"); this.SensorsDesc.Add("Back Pressure"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(45); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("fuelPres"); this.SensorsNames.Add("Fuel Pressure"); this.SensorsDesc.Add("Fuel Pressure"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(150); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("iat2"); this.SensorsNames.Add("IAT #2"); this.SensorsDesc.Add("Intake Air Temperature#2"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(255); this.SensorsCustomINT.Add(false);

        this.SensorsTags.Add("flexFuel"); this.SensorsNames.Add("Flex Fuel"); this.SensorsDesc.Add("Flex Fuel/Ethanol Percentage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(100); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("ectV"); this.SensorsNames.Add("ECT Voltage"); this.SensorsDesc.Add("ECT Voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(5); this.SensorsCustomINT.Add(false);
        this.SensorsTags.Add("iatV"); this.SensorsNames.Add("IAT Voltage"); this.SensorsDesc.Add("IAT Voltage"); this.SensorsMin.Add(0); this.SensorsMax.Add(0); this.SensorsCustomMin.Add(0); this.SensorsCustomMax.Add(5); this.SensorsCustomINT.Add(false);

        LoadSensors();
    }

    private void LoadSensors()
    {
        if (this.SensorsTags != null)
        {
            for (int i = 0; i < this.SensorsTags.Count; i++)
            {
                this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(this.SensorsTags[i])];
                //this.settingsKey_0 = SettingsFile.Settings["sensors/" + this.SensorsTags[i]];

                this.settingsKey_0.GetSetting("name", this.SensorsNames[i]);
                this.settingsKey_0.GetSetting("desc", this.SensorsDesc[i]);
                this.settingsKey_0.GetSetting("warnMin", this.SensorsMin[i]);
                this.settingsKey_0.GetSetting("warnMax", this.SensorsMax[i]);

                this.settingsKey_0.GetSetting("customMin", this.SensorsCustomMin[i]);
                this.settingsKey_0.GetSetting("customMax", this.SensorsCustomMax[i]);
                this.settingsKey_0.GetSetting("customINT", this.SensorsCustomINT[i]);
            }
        }
    }

    private void SaveSensors()
    {
        if (this.SensorsTags == null) method_list();
        else LoadSensors();

        for (int i = 0; i < this.SensorsTags.Count; i++)
        {
            this.settingsKey_0 = SettingsFile.Settings["sensors/" + ResetSenssStr(this.SensorsTags[i])];
            //this.settingsKey_0 = SettingsFile.Settings["sensors/" + this.SensorsTags[i]];

            this.settingsKey_0.StoreSetting("name", this.SensorsNames[i]);
            if (this.SensorsDesc[i] != "") this.settingsKey_0.StoreSetting("desc", this.SensorsDesc[i]);
            this.settingsKey_0.StoreSetting("warnMin", this.SensorsMin[i]);
            this.settingsKey_0.StoreSetting("warnMax", this.SensorsMax[i]);

            this.settingsKey_0.StoreSetting("customMin", this.SensorsCustomMin[i]);
            this.settingsKey_0.StoreSetting("customMax", this.SensorsCustomMax[i]);
            this.settingsKey_0.StoreSetting("customINT", this.SensorsCustomINT[i]);
        }

        SettingsFile.Update();  //Save
    }

    private void method_Reset()
    {
        this.settingsKey_0 = SettingsFile.Settings["editor/showWarningColor"];
        this.settingsKey_0.StoreSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["editor/dispTextPrim"];
        this.settingsKey_0.StoreSetting("value", (float)14.25f);
        this.settingsKey_0 = SettingsFile.Settings["editor/dispTextSec"];
        this.settingsKey_0.StoreSetting("value", (float)8.25f);
        this.settingsKey_0 = SettingsFile.Settings["wideband/widebandConversion"];
        this.settingsKey_0.StoreSetting("index0", 0);
        this.settingsKey_0.StoreSetting("index1", 1.3);
        this.settingsKey_0.StoreSetting("index2", 0.3);
        this.settingsKey_0.StoreSetting("index3", 1);
        this.settingsKey_0.StoreSetting("index4", 0.7);
        this.settingsKey_0.StoreSetting("index5", 1);
        this.settingsKey_0.StoreSetting("index6", 1);
        this.settingsKey_0.StoreSetting("index7", 0.710204081632653);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana1tbl"];
        this.settingsKey_0.StoreSetting("index0", 0);
        this.settingsKey_0.StoreSetting("index1", 0);
        this.settingsKey_0.StoreSetting("index2", 5);
        this.settingsKey_0.StoreSetting("index3", 5);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana2tbl"];
        this.settingsKey_0.StoreSetting("index0", 0);
        this.settingsKey_0.StoreSetting("index1", 0);
        this.settingsKey_0.StoreSetting("index2", 5);
        this.settingsKey_0.StoreSetting("index3", 5);
        this.settingsKey_0 = SettingsFile.Settings["analog/ana3tbl"];
        this.settingsKey_0.StoreSetting("index0", 0);
        this.settingsKey_0.StoreSetting("index1", 0);
        this.settingsKey_0.StoreSetting("index2", 5);
        this.settingsKey_0.StoreSetting("index3", 5);
        this.settingsKey_0 = SettingsFile.Settings["emulator/AlwaysRt"];
        this.settingsKey_0.StoreSetting("value", true);
        this.settingsKey_0 = SettingsFile.Settings["tuner/FilterAuto"];
        this.settingsKey_0.StoreSetting("value", true);
        this.method_1();
        SettingsFile.Update();
    }

    public void ResetOtherSettings()
    {
        string path1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\display.txt";
        string path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Graph.txt";
        string path3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Target_AFR.txt";
        if (File.Exists(path1)) File.Delete(path1);
        if (File.Exists(path2)) File.Delete(path2);
        if (File.Exists(path3)) File.Delete(path3);
    }

    public delegate void Delegate10(string[] string_0);

    public delegate void Delegate11();

    public delegate void Delegate12();

    public delegate void Delegate13(bool bool_0);

    public delegate void Delegate14();
}

