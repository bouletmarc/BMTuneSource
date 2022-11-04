using Data;
using Help;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;


internal class FrmMain : Form
{
    private bool bool_0;
    private bool bool_1;
    public bool CustomMenuLoaded = false;
    public bool KTableLoaded = false;
    public bool OBD0Loaded = false;

    private ToolStripMenuItem chipBurnerToolStripMenuItem;
    public Class10_settings class10_settings_0;
    private Class11_u class11_u_0;
    private Class12_afrT class12_afrT_0;
    internal Class15 class15_0;
    private Class17 class17_0;
    internal Class18 class18_0;
    private Class25 class25_0;
    public Class28_Shortcuts class28_Shortcuts_0;
    public Class29_Dyno class29_Dyno_0;
    private Class5_burn class5_burn_0;
    private Class21_snap class21_snap_0;
    public Class34_Zip Class34_Zip_0;
    //public string string_ktable = "";
    //public Class39 Class39_0;
    //public Ktable ktable_0;
    //public OBD0Table obd0Table_0;
    //private FlashGUI flashGUI_0;
    //public Class38 Class38_0;
    //public frmOBD2Scan frmOBD2Scan_0;
    private frmWaiting frmWaiting_0;
    private frmHelp frmHelp_0;
    private ToolStripMenuItem closeRomToolStripMenuItem;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripMenuItem datalogToolStripMenuItem;
    private ToolStripMenuItem dlCloseToolStripMenuItem;
    private ToolStripMenuItem dlConnectToolStripMenuItem;
    private ToolStripMenuItem dlExporttoolStripMenuItem;
    private ToolStripMenuItem dlOpenToolStripMenuItem;
    private ToolStripMenuItem dlRecordToolStripMenuItem;
    private ToolStripMenuItem dlSaveToolStripMenuItem;
    private ToolStripMenuItem editToolStripMenuItem1;
    private ToolStripMenuItem emuConnectToolStripMenuItem;
    private ToolStripMenuItem emuGetRomToolStripMenuItem;
    private ToolStripMenuItem emulatorToolStripMenuItem;
    private ToolStripMenuItem emuPutRomToolStripMenuItem;
    private ToolStripMenuItem emuRealTimeUpdateToolStripMenuItem;
    private ToolStripMenuItem emuUploadCalToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem1;
    private ToolStripMenuItem fileToolStripMenuItem1;
    private frmBaseMap frmBaseMap_0;
    private frmBoostTableSetup frmBoostTableSetup_0;
    private frmBurner frmBurner_0;
    private frmChartTemplates frmChartTemplates_0;
    private frmCopyMaps frmCopyMaps_0;
    public FrmDataDisplay frmDataDisplay_0;
    public frmDataGrid frmDataGrid_0;
    public frmDatalogGraphs frmDatalogGraphs_0;
    public frmErrorCodes frmErrorCodes_0;
    public frmDebug frmDebug_0;
    public frmActiveDatalog frmActiveDatalog_0;
    //public frmDatalogAutoSave frmDatalogAutoSave_0;
    public frmUploadBaserom frmUploadBaserom_0;
    public frmBaseromConvert frmBaseromConvert_0;
    public FrmGridChart frmGridChart_0;
    private frmQuickSaveMain frmQuickSaveMain_0;
    private frmIgnitionSync frmIgnitionSync_0;
    private FrmMain frmMain_0;
    public frmParameters frmParameters_0;
    private frmSensorSetup frmSensorSetup_0;
    public frmConsole frmConsole_0;
    //private frmReg frmRegister_0;
    public frmLivePlot frmLivePlot_0;
    private frmOstrichInfo frmOstrichInfo_0;
    public frmSettings frmSettings_0;
    private frmShortKeys frmShortKeys_0;
    private frmGearLearn frmGearLearn_0;
    private frmCPUBench frmCPUBench_0;
    public frmMapScalar frmMapScalar_0;
    private frmAboutBox frmAboutBox_0;
    public frmBluetooth frmHC05_0;
    public frmBinTool frmBinTool_0;
    public frmDynoControl frmDynoControl_0;
    private frmDynoSetup frmDynoSetup_0;
    private frmOnboard frmOnboard_0;
    private frmSelectMode frmSelectMode_0;
    private IContainer icontainer_0;
    private ToolStripMenuItem importCalibrationToolStripMenuItem;
    private ToolStripMenuItem importExportToolStripMenuItem;
    private ToolStripMenuItem importTablesToolStripMenuItem;
    public int int_0 = 0x13;
    private MenuStrip mdiMenuStrip;
    private ToolStripMenuItem mruToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem pasteToolStripMenuItem;
    private ToolStripMenuItem readChipToolStripMenuItem;
    private ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    //public string string_0 = (Application.StartupPath + @"\BMTune.chm");
    private ToolStripMenuItem windowsToolStripMenuItem;
    private ToolStripPanel toolStripPanelTop;
    private ToolStripSeparator toolStripSeparator10;
    private ToolStripSeparator toolStripSeparator12;
    private ToolStripSeparator toolStripSeparator4;
    private ToolTip toolTip_0;
    private ToolStripMenuItem undoToolStripMenuItem;
    private ToolStripMenuItem verifyChipToolStripMenuItem1;
    private IContainer components;
    private ToolStripMenuItem ExportToolStripMenuItem;
    private ToolStripMenuItem exportCalibrationToolStripMenuItem;
    private ToolStripMenuItem exportTableToolStripMenuItem;
    private ToolStripMenuItem SerialMenuToolStripMenuItem;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripMenuItem parametersToolStripMenuItem;
    private ToolStripMenuItem tablesToolStripMenuItem;
    private ToolStripMenuItem errorToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutBMTuneToolStripMenuItem;
    private ToolStripMenuItem shortcutKeysToolStripMenuItem;
    private ToolStripMenuItem registerToolStripMenuItem1;
    private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
    private ToolStripMenuItem debugLogsToolStripMenuItem;
    private ToolStripMenuItem writeChipToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripMenuItem dlTableToolStripMenuItem;
    private ToolStripMenuItem openLogAfterRecordToolStripMenuItem;
    public List<string> DebugLogs = new List<string>();
    private TrackBar trackBar_0;

    private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    private ToolStripMenuItem livePlotsToolStripMenuItem;
    private ToolStripMenuItem dlAutoSave;
    private ToolStripMenuItem uploadBaseromOnlineToolStripMenuItem;
    private ToolStripMenuItem saveQuickToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator13;
    private List<string> PagesDoneList = new List<string>();
    private FormWindowState LastWindowsState;

    private SplitContainer splitContainer1_Left;
    public TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private SplitContainer splitContainer2_Top;
    private SplitContainer splitContainer3_Bottom;
    public TabControl tabControl2;
    private TabPage tabPage3;
    private TabPage tabPage4;
    public TabControl tabControl3;
    private TabPage tabPage7;
    private SplitContainer splitContainer5_BottomLeft;
    public TabControl tabControl4;
    private TabPage tabPage5;
    private TabPage tabPage6;
    private TabPage tabPage8;
    private SplitContainer splitContainer6_Right;
    public TabControl tabControl5;
    private TabPage tabPage9;
    private TabPage tabPage10;

    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem ignitionSyncToolStripMenuItem;
    private ToolStripMenuItem baseromConverterToolStripMenuItem;
    private ToolStripMenuItem consoleToolStripMenuItem;
    private ToolStripMenuItem undoHistoryToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripSeparator toolStripSeparator14;
    private ToolStripMenuItem increaseSelectionToolStripMenuItem;
    private ToolStripMenuItem decreaseSelectionToolStripMenuItem;
    private ToolStripMenuItem adjustSelectionToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator15;
    public ToolStripMenuItem interpolateToolStripMenuItem;
    public ToolStripMenuItem interpolateHorizontallyToolStripMenuItem;
    public ToolStripMenuItem interpolateVerticallyToolStripMenuItem;
    public ToolStripMenuItem smoothMapsToolStripMenuItem;
    private ToolStripMenuItem copyPrimaryTablesToSecondaryToolStripMenuItem;
    private ToolStripMenuItem copySecondaryTablesToPrimaryToolStripMenuItem;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator17;
    private ToolStripMenuItem clearToolStripMenuItem;
    private ToolStripMenuItem clearLivePlotsToolStripMenuItem;
    private ToolStripMenuItem clearDataToolStripMenuItem;
    private ToolStripMenuItem clearRecordingToolStripMenuItem;
    private ToolStripMenuItem clearMapTraceTrailToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator18;
    private ToolStripMenuItem ClearCELErrorsToolStripMenuItem;
    private ToolStripMenuItem debugLogsToolStripMenuItem1;
    private ToolStripSeparator toolStripSeparator19;
    private ToolStripSeparator toolStripSeparator20;
    private ToolStripMenuItem scalarSetupToolStripMenuItem;
    private ToolStripMenuItem mapValuesToolStripMenuItem;
    private ToolStripMenuItem aFTargetToolStripMenuItem1;
    private ToolStripMenuItem aFToolStripMenuItem;
    private ToolStripMenuItem fuelDifferenceToolStripMenuItem;
    private ToolStripMenuItem vETablesToolStripMenuItem1;
    private ToolStripSeparator toolStripSeparator21;
    private ToolStripMenuItem analog1Reading_Button;
    private ToolStripMenuItem analog2Reading_Button;
    private ToolStripMenuItem analog3Reading_Button;
    private ToolStripSeparator toolStripSeparator22;
    private ToolStripMenuItem FuelRawToolStripMenuItem;
    private ToolStripMenuItem FuelDutyToolStripMenuItem;
    private ToolStripMenuItem fuelInjDurToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator23;
    private ToolStripMenuItem primaryLowIgnitionToolStripMenuItem;
    private ToolStripMenuItem primaryHighIgnitionToolStripMenuItem;
    private ToolStripMenuItem primaryLowFuelToolStripMenuItem;
    private ToolStripMenuItem primaryHighFuelToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator24;
    private ToolStripMenuItem primaryTablesToolStripMenuItem;
    private ToolStripMenuItem secondaryTablesToolStripMenuItem;
    private ToolStripMenuItem sensorsToolStripMenuItem;
    private ToolStripMenuItem displayToolStripMenuItem;
    private ToolStripMenuItem graphsToolStripMenuItem;
    private ToolStripMenuItem copyScalarsToolStripMenuItem;
    private ToolStripMenuItem rpmScalarsToolStripMenuItem;
    private ToolStripMenuItem loadScalarsToolStripMenuItem;
    private ToolStripMenuItem playBackwardToolStripMenuItem;
    private ToolStripMenuItem playToolStripMenuItem;
    private ToolStripMenuItem playDoubleSpeedToolStripMenuItem;
    private ToolStripMenuItem pauseToolStripMenuItem;
    private ToolStripMenuItem stopToolStripMenuItem;
    private ToolStripMenuItem snapshotToolStripMenuItem;
    private ToolStripMenuItem informationsToolStripMenuItem;
    private ToolStripMenuItem injectorCalibrationToolStripMenuItem;
    private ToolStripMenuItem gearLearningToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripMenuItem killInjectorsToolStripMenuItem;
    private ToolStripMenuItem fuelPumpToolStripMenuItem;
    private ToolStripMenuItem offToolStripMenuItem;
    private ToolStripMenuItem onDrainTankToolStripMenuItem;
    private ToolStripMenuItem useSecondaryMapsOnlyToolStripMenuItem;
    private ToolStripMenuItem useHighCamsMapsOnlyToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator25;
    private ToolStripMenuItem toolTunerFollowVtec;
    private ToolStripMenuItem toolTunerFollowDualTables;
    private ToolStripMenuItem toolTunerMapTrail;
    private ToolStripMenuItem toolTunerSmartTrack;
    private ToolStripMenuItem bstTablesToolStripMenuItem;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel statusName;
    private ToolStripSeparator toolStripSeparator30;
    private ToolStripStatusLabel statusBaserom;
    private ToolStripSeparator toolStripSeparator29;
    public ToolStripStatusLabel statusEmulator;
    private ToolStripSeparator toolStripSeparator16;
    private ToolStripStatusLabel statusDatalogging;
    private ToolStripSeparator toolStripSeparator27;
    private ToolStripStatusLabel statusWB;
    private ToolStripSeparator toolStripSeparator28;
    public ToolStripProgressBar stutasEmulatorProgress;
    private ToolStrip mainToolStrip;
    private ToolStripButton toolStripButtonNewFile;
    private ToolStripButton toolStripButtonOpenFile;
    private ToolStripButton toolStripButtonSave;
    private ToolStripButton toolStripButtonSaveAs;
    private ToolStripButton toolStripButtonSaveSnapshot;
    private ToolStripButton toolStripButtonUploadFile;
    private ToolStripButton toolStripButtonCloseFile;
    private ToolStrip emulatorToolStrip;
    private ToolStripButton toolStripButtonEmuConnect;
    private ToolStripButton toolStripButtonEmuDownload;
    private ToolStripButton toolStripButtonEmuUploadAll;
    private ToolStripButton toolStripButtonEmuUploadCal;
    private ToolStripButton toolStripButtonEmuInfos;
    private ToolStripButton toolStripButtonEmuRealtime;
    private ToolStrip dataloggingToolStrip;
    private ToolStripButton toolDtConnect;
    private ToolStripButton toolDtRecord;
    private ToolStripButton toolDtSave;
    private ToolStripButton toolDtAutoSave;
    private ToolStripSeparator toolStripSeparator50;
    private ToolStripButton toolDtPeakMax;
    private ToolStripButton toolDtPeakClear;
    private ToolStripSeparator toolStripSeparator51;
    private ToolStripButton toolDtOpen;
    private ToolStripButton toolDtClose;
    private ToolStripButton toolDtPlayBack;
    private ToolStripButton toolDtPlay;
    private ToolStripButton toolDtForward;
    private ToolStripButton toolDtPause;
    private ToolStripButton toolDtStop;
    private ToolStripSeparator dtToolStripSeparator2;
    private ToolStripDropDownButton toolStripDropDownLastFile;
    private ToolStripPanel toolStripPanel1;
    private ToolStrip editToolStrip;
    private ToolStripButton copyToolStripButton;
    private ToolStripButton pasteToolStripButton;
    private ToolStripSeparator toolStripSeparator49;
    private ToolStripSplitButton undoToolStripDropDown;
    private ToolStripSplitButton redoToolStripDropDown;
    private ToolStripButton toolStripButtonUndoHistory;
    private ToolStripSeparator toolStripSeparator31;
    private ToolStripButton toolStripButtonIncSelection;
    private ToolStripButton toolStripButtonDecSelection;
    private ToolStripButton toolStripButtonAdjustSelection;
    private ToolStripSeparator toolStripSeparator32;
    public ToolStripButton toolStripButtonInterpolate;
    public ToolStripButton toolStripButtonInterpolateRow;
    public ToolStripButton toolStripButtonInterpolateColomn;
    public ToolStripButton toolStripButtonSmoothMap;
    private ToolStrip viewToolStrip;
    private ToolStripButton toolStripButtonLowIgn;
    private ToolStripButton toolStripButtonHighIgn;
    private ToolStripButton toolStripButtonLowFuel;
    private ToolStripButton toolStripButtonHighFuel;
    private ToolStripSeparator toolStripSeparator33;
    private ToolStripButton toolStripButtonPrimary;
    private ToolStripButton toolStripButtonSecondary;
    private ToolStripSeparator toolStripSeparator34;
    private ToolStripButton toolStripButtonAFTarget;
    private ToolStripButton toolStripButtonAFReading;
    private ToolStripButton toolStripButtonAFDiff;
    private ToolStrip windowsToolStrip;
    private ToolStripButton toolStripButtonParameters;
    private ToolStripButton toolStripButtonTables;
    private ToolStripButton toolStripButtonCELCodes;
    private ToolStripButton toolStripButtonDebugLogs;
    private ToolStripButton toolStripButtonMapValues;
    private ToolStripMenuItem editLimitsWarningsToolStripMenuItem;
    private ToolStripMenuItem windowedModeToolStripMenuItem;
    private bool Disposed = false;
    private bool Loading = true;
    private int TitleCount = 0;
    public frmLoading frmLoading_0;
    private ToolStripMenuItem donateToolStripMenuItem;
    private ToolStripMenuItem activeDatalogsThreadsToolStripMenuItem;
    public ToolStripMenuItem reinstallLastStableReleaseToolStripMenuItem;
    public ToolStripMenuItem dynoToolStripMenuItem;
    public ToolStripMenuItem connectToolStripMenuItem;
    public ToolStripMenuItem controlToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    public ToolStripMenuItem setupToolStripMenuItem;
    private ToolStripMenuItem bluetoothProgrammerToolStripMenuItem;
    private ToolStripMenuItem create2TimerBin512kbToolStripMenuItem;
    private ToolStripMenuItem playQuarterSpeedToolStripMenuItem;
    private ToolStripMenuItem playHalfSpeedToolStripMenuItem;
    private ToolStripButton toolDtQuart;
    private ToolStripButton toolDtHalf;
    private ToolStripSeparator toolStripSeparator3;
    public ToolStripStatusLabel statusDyno;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripMenuItem dynoTractionToolStripMenuItem;
    private ToolStripMenuItem dynoHPToolStripMenuItem;
    private ToolStripMenuItem dynoNMToolStripMenuItem;
    private ToolStripMenuItem dynoAUX1ToolStripMenuItem;
    private ToolStripMenuItem dynoAUX2ToolStripMenuItem;
    private ToolStripMenuItem dynoAUX3ToolStripMenuItem;
    private ToolStripMenuItem dynoTHCToolStripMenuItem;
    private ToolStripMenuItem OBD2ScanStripMenuItem;
    private ToolStripMenuItem bMDataloggerLCDDisplayToolStripMenuItem;
    private ToolStripMenuItem bMBurnerChipBurningToolToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripMenuItem converterToolStripMenuItem;
    private ToolStripMenuItem serialMonitorToolStripMenuItem;
    private ToolStripMenuItem moatesFlashBurnToolStripMenuItem;
    private ToolStripMenuItem moatesDemonOstrichResetToolStripMenuItem;
    private ToolStripMenuItem bMDevsFirmwareUpdaterToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator11;
    private ToolStripMenuItem fileToolbarVisibleToolStripMenuItem;
    private ToolStripMenuItem editToolbarToolStripMenuItem;
    private ToolStripMenuItem emulatorToolbarToolStripMenuItem;
    private ToolStripMenuItem viewToolbarToolStripMenuItem;
    private ToolStripMenuItem toolsToolbarToolStripMenuItem;
    private ToolStripMenuItem datalogToolbartoolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem1;
    private ToolStripMenuItem benchmarkToolToolStripMenuItem;
    private ToolStripMenuItem onBoardLoggingToolStripMenuItem;
    private ToolStripMenuItem flashToolStripMenuItem;
    private ToolStripMenuItem tPSCalibrationToolStripMenuItem;
    private ToolStripMenuItem emuVerifyRomToolStripMenuItem;
    private ToolStripMenuItem cOMPortHelperToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator40;
    private ToolStripMenuItem iSRV3ProtocolInfosToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator41;
    private ToolStripMenuItem testECUOutputsToolStripMenuItem;
    private ToolStripMenuItem vTSToolStripMenuItem;
    private ToolStripMenuItem fuelPumpToolStripMenuItem1;
    private ToolStripMenuItem a10ToolStripMenuItem;
    private ToolStripMenuItem aCToolStripMenuItem;
    private ToolStripMenuItem pCSToolStripMenuItem;
    private ToolStripMenuItem iABToolStripMenuItem;
    private ToolStripMenuItem fANCToolStripMenuItem;
    private ToolStripMenuItem aLTCToolStripMenuItem;
    private ToolStripMenuItem dlCloudtoolStripMenuItem;
    private ToolStripMenuItem importTunerViewRAWToolStripMenuItem;
    private ToolStripMenuItem invertToolStripMenuItem;

    public FrmMain()
    {
        this.InitializeComponent();
        this.frmMain_0 = this;
        this.frmLoading_0 = new frmLoading();
        this.frmLoading_0.Show();
        this.frmLoading_0.Location = new Point(this.frmLoading_0.Location.X, this.frmLoading_0.Location.Y / 2);
        Control.CheckForIllegalCrossThreadCalls = false;
        base.HandleCreated += new EventHandler(this.FrmMain_HandleCreated);
        base.HandleDestroyed += new EventHandler(this.FrmMain_HandleDestroyed);

        LoopTimer.Interval = 1000;
        LoopTimer.Tick += DoThisAllTheTime;
        LoopTimer.Start();
    }

    /*public void UpdateColorControls(Control myControl)
    {
        if (myControl is Panel)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is TextBox)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is RichTextBox)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is ToolStripPanel)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is ToolStrip)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is MenuStrip)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is GroupBox)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is ToolStripDropDownMenu)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is SplitContainer)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is TabControl)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is TabPage)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is TreeView)
        {
            myControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            myControl.ForeColor = System.Drawing.SystemColors.Control;
        }
        if (myControl is DataGridView)
        {
            DataGridView MyDgv = (DataGridView)myControl;
            MyDgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            MyDgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.Control;
        }

        // Any other non-standard controls should be implemented here aswell...
        foreach (Control subC in myControl.Controls)
        {
            UpdateColorControls(subC);
        }
    }*/

    void DoThisAllTheTime(object sender, EventArgs e)
    {
        //if (!LoadingTitle)
        //{
        //LoadingTitle = true;

        if (this.class15_0 != null && this.class18_0 != null && this.class17_0 != null && this.class25_0 != null)
        {
            this.Text = "BMTune - " + this.class15_0.CurrentBMTuneVersion;

            this.Text += " (Fully Unlocked)";
            if (this.class18_0.method_30_HasFileLoadedInBMTune())
            {
                this.Text += " - " + Path.GetFileName(this.class18_0.method_25_GetFilename());
                this.statusName.Text = Path.GetFileName(this.class18_0.method_25_GetFilename());

                if (this.class18_0.method_45())
                {
                    this.Text += "*";
                    this.statusName.Text += "*";
                }

                if (!CustomMenuLoaded)
                {
                    if (this.class18_0.Glitched)
                    {
                        /*if (ktable_0 != null)
                        {
                            if (!ktable_0.Class39_0.bool_1)
                            {
                                this.Text += " **GLITCHED**";
                                this.statusName.Text += " **GLITCHED**";
                            }
                        }
                        else
                        {*/
                            this.Text += " **GLITCHED**";
                            this.statusName.Text += " **GLITCHED**";
                        //}
                    }
                }

                //#######
                if (!CustomMenuLoaded)
                {
                    if (this.class18_0.RomVersion >= 100)
                    {
                        string FVersion = this.class18_0.RomVersion.ToString().Substring(0, 1) + "." + this.class18_0.RomVersion.ToString().Substring(1, 2);
                        /*if (ktable_0 != null)
                        {
                            if (ktable_0.Class39_0 != null)
                            {
                                this.Text = !ktable_0.Class39_0.bool_1 ? (this.Text + " (v" + FVersion + ")") : (this.Text + " (KSeries) Table: " + string_ktable);
                            }
                        }*/
                        this.Text += " (v" + FVersion + ")";
                        this.statusBaserom.Text = "Baserom=V" + FVersion;
                    }
                }
                else
                {
                    this.statusBaserom.Text = "Baserom=V?.??";
                }
            }
            else
            {
                this.statusName.Text = "No File Opened";
                this.statusBaserom.Text = "Baserom=V?.??";
            }
            if (this.class17_0.method_63_HasLogsFileOpen()) this.Text += " - " + this.class17_0.method_62();

            //#####################################################################
            //Emulator Title infos
            if (this.class25_0.GetConnected() || this.class25_0.TryingtoConnect)
            {
                this.Text += " - ";
                if (!this.class25_0.GetConnected())
                {
                    if (this.class25_0.TryingtoConnect)
                    {
                        this.Text += "Connecting to Emulator";
                        if (TitleCount > 0)
                        {
                            for (int i = 0; i < TitleCount; i++) this.Text += ".";
                        }
                    }
                }
                else
                {
                    this.Text += this.class10_settings_0.emulatorMode_0.ToString() + " Connected";
                }
            }
            else
            {
                this.Text += " - " + this.class10_settings_0.emulatorMode_0.ToString() + " Disconnected";
            }


            //#####################################################################
            //Datalogger Title infos
            if (this.class17_0.method_34_GetConnected() || this.class17_0.TryingtoConnect)
            {
                this.Text += " - ";
                if (!this.class17_0.method_34_GetConnected())
                {
                    if (this.class17_0.TryingtoConnect)
                    {
                        this.Text += "Connecting to Datalogger";
                        if (TitleCount > 0)
                        {
                            for (int i = 0; i < TitleCount; i++) this.Text += ".";
                        }
                    }
                }
                else
                {
                    this.Text += "Datalogger Connected";
                }
            }
            else
            {
                this.Text += " - Datalogger Disconnected";
            }

            TitleCount++;
            if (TitleCount > 3) TitleCount = 0;


            //Laptop battery
            if (SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery)
            {
                if (SystemInformation.PowerStatus.PowerLineStatus != PowerLineStatus.Online)
                {
                    string RemainingHours = (SystemInformation.PowerStatus.BatteryLifeRemaining / 3600).ToString("0");
                    string RemainingMinutes = ((SystemInformation.PowerStatus.BatteryLifeRemaining % 3600) / 60).ToString("00");

                    //2:51h
                    //52min
                    string ReturnstrTime = "";
                    if (RemainingHours != "0") ReturnstrTime = RemainingHours + ":" + RemainingMinutes + "h";
                    else ReturnstrTime = RemainingMinutes + "min";
                    this.Text += " | Battery: " + (SystemInformation.PowerStatus.BatteryLifePercent * 100).ToString("0") + "% (" + ReturnstrTime + ")";
                }
            }

        }

        //LoadingTitle = false;
        //}
    }

    public void LogThis(string ThisText)
    {
        DebugLogs.Add(ThisText);
        debugLogsToolStripMenuItem1.Enabled = true;
    }

    private void LogThisMain(string string_1)
    {
        this.LogThis("BMTune - " + string_1);
    }

    public void ClearLogs()
    {
        DebugLogs.Clear();
        debugLogsToolStripMenuItem1.Enabled = false;
    }

    public void LoadKTable(bool KTable, bool OBD0)
    {
        this.SpawnWaitingwindows();
        //KTableLoaded = KTable;
        //OBD0Loaded = OBD0;

        foreach (TabPage page in this.tabControl1.TabPages)
        {
            this.tabControl1.TabPages.Remove(page);
        }
        foreach (TabPage page2 in this.tabControl2.TabPages)
        {
            this.tabControl2.TabPages.Remove(page2);
        }
        foreach (TabPage page3 in this.tabControl3.TabPages)
        {
            this.tabControl3.TabPages.Remove(page3);
        }
        foreach (TabPage page4 in this.tabControl4.TabPages)
        {
            this.tabControl4.TabPages.Remove(page4);
        }
        foreach (TabPage page5 in this.tabControl5.TabPages)
        {
            this.tabControl5.TabPages.Remove(page5);
        }
        this.splitContainer2_Top.Panel1Collapsed = (KTable || OBD0);
        this.splitContainer2_Top.Panel2Collapsed = (KTable || OBD0);
        this.splitContainer3_Bottom.Panel2Collapsed = (KTable || OBD0);
        this.splitContainer3_Bottom.Panel1Collapsed = (KTable || OBD0);
        this.splitContainer6_Right.Panel2Collapsed = (KTable || OBD0);
        this.splitContainer6_Right.Panel1Collapsed = (KTable || OBD0);
        this.splitContainer1_Left.Panel2Collapsed = (KTable || OBD0);

        this.saveToolStripMenuItem.Visible = !(KTable || OBD0);
        this.editToolStripMenuItem1.Visible = !(KTable || OBD0);
        this.clearToolStripMenuItem.Visible = !(KTable || OBD0);
        this.emulatorToolStripMenuItem.Visible = !(KTable || OBD0);
        this.datalogToolStripMenuItem.Visible = !(KTable || OBD0);
        this.viewToolStripMenuItem.Visible = !(KTable || OBD0);
        this.windowsToolStripMenuItem.Visible = !(KTable || OBD0);
        this.toolsToolStripMenuItem.Visible = !(KTable || OBD0);
        this.optionsToolStripMenuItem.Visible = !(KTable || OBD0);

        if (!(KTable || OBD0))
        {
            CheckToolbarVisible();
        }
        else 
        {
            this.mainToolStrip.Visible = !(KTable || OBD0);
            this.editToolStrip.Visible = !(KTable || OBD0);
            this.emulatorToolStrip.Visible = !(KTable || OBD0);
            this.dataloggingToolStrip.Visible = !(KTable || OBD0);
            this.viewToolStrip.Visible = !(KTable || OBD0);
            this.windowsToolStrip.Visible = !(KTable || OBD0);
        }

        this.closeRomToolStripMenuItem.Visible = !(KTable || OBD0);
        this.snapshotToolStripMenuItem.Visible = !(KTable || OBD0);
        this.toolStripButtonCloseFile.Visible = !(KTable || OBD0);
        this.toolStripButtonSaveSnapshot.Visible = !(KTable || OBD0);
        this.exportTableToolStripMenuItem.Visible = !(KTable || OBD0);
        this.importTablesToolStripMenuItem.Visible = !(KTable || OBD0);
        this.writeChipToolStripMenuItem.Visible = !(KTable || OBD0);
        this.chipBurnerToolStripMenuItem.Visible = !(KTable || OBD0);
        this.copyToolStripMenuItem.Visible = !(KTable || OBD0);
        this.saveQuickToolStripMenuItem.Visible = !(KTable || OBD0);
        this.mruToolStripMenuItem.Visible = !(KTable || OBD0);
        this.toolStripButtonSave.Visible = !(KTable || OBD0);
        this.toolStripDropDownLastFile.Visible = !(KTable || OBD0);
        this.toolStripSeparator13.Visible = !(KTable || OBD0);

        //this.dynoToolStripMenuItem.Visible = !(KTable || OBD0);
        this.flashToolStripMenuItem.Visible = !(OBD0);

        this.saveAsToolStripMenuItem.Enabled = true;
        this.toolStripButtonSaveAs.Enabled = true;

        this.fileToolStripMenuItem1.Visible = false;

        if (KTable)
        {
            /*this.flashToolStripMenuItem.Enabled = true;
            this.flashToolStripMenuItem.Visible = true;

            if (ktable_0 == null)
            {
                this.ktable_0 = new Ktable(ref class10_settings_0);
                this.ktable_0.method_33(ref this.class18_0, ref this.frmMain_0, ref this.class10_settings_0);
                this.ktable_0.TopLevel = false;
                this.ktable_0.Show();
            }

            this.tabControl1.TabPages.Add("K-Table");
            this.tabControl1.TabPages[0].Controls.Add(this.ktable_0);

            this.ktable_0.method_1();

            CustomMenuLoaded = true;*/
        }
        else
        {
            if (OBD0)
            {
                /*if (this.obd0Table_0 == null)
                {
                    this.obd0Table_0 = new OBD0Table(ref this.frmMain_0);
                    this.obd0Table_0.method_0(ref this.class18_0, ref this.frmMain_0, ref this.class10_settings_0);
                    this.obd0Table_0.TopLevel = false;
                    this.obd0Table_0.Show();
                }

                this.tabControl1.TabPages.Add("OBD0");
                this.tabControl1.TabPages[0].Controls.Add(this.obd0Table_0);

                CustomMenuLoaded = true;*/
            }
            else
            {
                CustomMenuLoaded = false;
                this.LoadPages();
            }
        }

        //####################################
        //Load ScanTool
        /*if (KTable || OBD0)
        {
            if (this.frmOBD2Scan_0 == null)
            {
                this.frmOBD2Scan_0 = new frmOBD2Scan(ref this.class10_settings_0, ref this.Class34_Zip_0);
                this.frmOBD2Scan_0.TopLevel = false;
                this.frmOBD2Scan_0.Show();
            }

            frmOBD2Scan.bool_3 = true;

            this.tabControl4.TabPages.Add("ScanTool");
            this.tabControl4.TabPages[0].Controls.Add(this.frmOBD2Scan_0);
        }
        else
        {
            if (this.frmOBD2Scan_0 != null)
            {
                this.frmOBD2Scan_0.Dispose();
                this.frmOBD2Scan_0 = null;
            }
        }*/

        this.CloseWaitingwindows();
    }

    public bool ConvertASMtoBIN(string string_10)
    {
        bool flag;
        try
        {
            string Filename = "asmtool.exe";
            string ZipFolder = "ASM";
            string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
            string ShowMessageStr = "";
            if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
            //if (File.Exists(WholePath)) this.string_0 = File.ReadAllText(WholePath);
            goto TR_0022;
        TR_0005:
            MessageBox.Show(ShowMessageStr);
            try
            {
                File.Delete(Application.StartupPath + @"\" + ZipFolder + @"\asmtool.exe");
            }
            catch
            {
            }
            return File.Exists(string_10 + ".bin");
        TR_0022:
            ShowMessageStr = "BMTune 66K ASM Compiler." + Environment.NewLine;
            string path = Application.StartupPath + @"\" + ZipFolder + @"\Compile.asm";
            if (File.Exists(path)) File.Delete(path);
            string contents = File.ReadAllText(string_10);
            if (contents.Contains("     TBR     "))
            {
                contents = contents.Replace("     TBR     ", "     TRB     ");
            }
            else if (contents.Contains("     TRB     "))
            {
                ShowMessageStr += "Warning: Fixing TRB Bug." + Environment.NewLine;
            }
            File.WriteAllText(path, contents);
            string[] textArray1 = new string[] { "/C ", Application.StartupPath, @"\", ZipFolder, @"\asmtool.exe ", path, " ", string_10, ".bin" };
            string str3 = string.Concat(textArray1);
            using (Process process = new Process())
            {
                ProcessStartInfo info1 = new ProcessStartInfo("cmd.exe");
                info1.CreateNoWindow = true;
                info1.RedirectStandardInput = true;
                info1.RedirectStandardOutput = true;
                info1.RedirectStandardError = true;
                info1.UseShellExecute = false;
                info1.Arguments = str3;
                process.StartInfo = info1;
                process.Start();
                List<string> list = new List<string>();
                while (true)
                {
                    if (process.StandardOutput.Peek() <= -1)
                    {
                        while (true)
                        {
                            if (process.StandardError.Peek() <= -1)
                            {
                                process.WaitForExit();
                                if (list.Count == 0)
                                {
                                    ShowMessageStr += "Compiled with no Errors/Warnings.";
                                }
                                else
                                {
                                    foreach (string str4 in list)
                                    {
                                        try
                                        {
                                            string[] textArray2 = new string[] { path };
                                            ShowMessageStr += str4.Split(textArray2, (StringSplitOptions)StringSplitOptions.None)[1] + Environment.NewLine;
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                                break;
                            }
                            list.Add(process.StandardError.ReadLine());
                        }
                        break;
                    }
                    list.Add(process.StandardOutput.ReadLine());
                }
            }
            goto TR_0005;
        }
        catch
        {
            flag = false;
        }
        return flag;
    }

    public void SensorWarning_Click(object sender, EventArgs e)
    {
        if (this.frmSensorSetup_0 != null)
        {
            this.frmSensorSetup_0.Dispose();
            this.frmSensorSetup_0 = null;
        }
        this.frmSensorSetup_0 = new frmSensorSetup();
        this.frmSensorSetup_0.method_0(ref this.class18_0, ref this.class10_settings_0);
        this.frmSensorSetup_0.ShowDialog();
        this.frmSensorSetup_0.Dispose();
        this.frmSensorSetup_0 = null;
    }

    public void OpenBoostTable()
    {
        if (this.frmBoostTableSetup_0 != null)
        {
            this.frmBoostTableSetup_0.Focus();
        }
        else
        {
            this.frmBoostTableSetup_0 = new frmBoostTableSetup();
            this.frmBoostTableSetup_0.method_0(ref this.class18_0);
            this.frmBoostTableSetup_0.ShowDialog();
            this.frmBoostTableSetup_0.Dispose();
            this.frmBoostTableSetup_0 = null;
        }
    }

    public void bstTablesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenBoostTable();
    }

    private void calExportToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.class18_0.method_72();
        }
    }

    private void calImportToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.class18_0.method_74();
        }
    }

    private void closeRomToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_68();
    }

    public void copyPrimarySecondaryMaps_Click(object sender, EventArgs e)
    {
        if (this.frmCopyMaps_0 != null)
        {
            this.frmCopyMaps_0.Focus();
        }
        else
        {
            this.frmCopyMaps_0 = new frmCopyMaps();
            this.frmCopyMaps_0.method_0(ref this.class18_0);
            this.frmCopyMaps_0.ShowDialog();
            this.frmCopyMaps_0.Dispose();
            this.frmCopyMaps_0 = null;
        }
    }

    private void dlTableToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void datalogToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
        this.dlConnectToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.dlOpenToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.importTunerViewRAWToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.dlCloudtoolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.dlSaveToolStripMenuItem.Enabled = this.class17_0.method_54();
        if (this.class10_settings_0.bool_28) this.class10_settings_0.method_10();
        if (this.class10_settings_0.method_8() == DataloggingTable.tableMinimal) this.dlTableToolStripMenuItem.Checked = true;
        else this.dlTableToolStripMenuItem.Checked = false;
        this.openLogAfterRecordToolStripMenuItem.Checked = this.class10_settings_0.bool_26;

        this.toolDtConnect.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolDtOpen.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolDtSave.Enabled = this.class17_0.method_54();
    }

    public void displayToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.frmDataDisplay_0 != null)
        {
            this.frmDataDisplay_0.Focus();
        }
        else
        {
            this.frmDataDisplay_0 = new FrmDataDisplay();
            this.frmDataDisplay_0.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);
            this.frmDataDisplay_0.MdiParent = this;
            this.frmDataDisplay_0.Show();
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

    private void dlExporttoolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class17_0.method_56();
    }

    public void emuConnectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class17_0.SetDemonDatalogCheck(false);
        this.class25_0.method_1(true);
        if (this.class25_0.GetConnected())
        {
            if (this.class25_0.emulatorMoatesType_0 != EmulatorMoatesType.neptuneRTP)
            {
                this.class25_0.CheckResetSerial();
            }
        }
    }

    public void emuGetRomToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class25_0.method_16();
    }

    private void emulatorToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
        this.emuRealTimeUpdateToolStripMenuItem.Checked = this.class10_settings_0.bool_32;
    }

    public void emuPutRomToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class25_0.method_17();
    }

    private void emuRealTimeUpdateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_32 = this.emuRealTimeUpdateToolStripMenuItem.Checked;
    }

    public void emuUploadCalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class25_0.method_19();
    }

    public void errorToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.frmErrorCodes_0 != null)
        {
            this.frmErrorCodes_0.Focus();
        }
        else
        {
            this.frmErrorCodes_0 = new frmErrorCodes();
            this.frmErrorCodes_0.method_0(ref this.class18_0, ref this.class17_0, ref this.frmMain_0);
            this.frmErrorCodes_0.MdiParent = this;
            this.frmErrorCodes_0.Show();
        }
        OpenThisTab("CEL");
    }

    private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        base.Close();
    }

    private void exportTableToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.class18_0.method_82();
        }
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        /*frmOBD2Scan.bool_11 = false;
        frmOBD2Scan.bool_1 = false;*/

        if (this.class18_0 != null) this.class18_0.Dissspose();
        if (this.Class34_Zip_0 != null) this.Class34_Zip_0.RemoveZip();
        if (this.class10_settings_0 != null)
        {
            if (this.dataloggingToolStrip != null) this.class10_settings_0.dataloggingToolStrip = this.dataloggingToolStrip.Location;
            if (this.editToolStrip != null) this.class10_settings_0.editToolStrip = this.editToolStrip.Location;
            if (this.viewToolStrip != null) this.class10_settings_0.viewToolStrip = this.viewToolStrip.Location;
            if (this.windowsToolStrip != null) this.class10_settings_0.windowsToolStrip = this.windowsToolStrip.Location;
            if (this.mainToolStrip != null) this.class10_settings_0.mainToolStrip = this.mainToolStrip.Location;
            if (this.emulatorToolStrip != null) this.class10_settings_0.emulatorToolStrip = this.emulatorToolStrip.Location;
        }

        /*if (ktable_0 != null)
        {
            if (!ktable_0.Class39_0.bool_1)
            {
                SavePages();
            }
            ktable_0.Close();
        }
        else
        {*/
            SavePages();
        //}

        if (this.class18_0 != null)
        {
            e.Cancel = !this.class18_0.method_68();
            if (e.Cancel)
            {
                return;
            }
            this.class18_0.delegate58_0 -= new Class18.Delegate58(this.method_19);
        }
        if (this.class25_0 != null)
        {
            this.class25_0.method_3();
        }
        if ((this.class17_0 != null) && this.class17_0.method_63_HasLogsFileOpen())
        {
            this.class17_0.method_75();
        }
        if (this.class17_0 != null)
        {
            this.class17_0.method_2();
            this.class17_0.delegate54_0 -= new Class17.Delegate54(this.method_16);
            this.class17_0.delegate46_0 -= new Class17.Delegate46(this.method_15);
            this.class17_0.delegate53_0 -= new Class17.Delegate53(this.method_18);
            this.class17_0 = null;
        }

        DisposeAll();

        if (this.frmDataGrid_0 != null)
        {
            this.frmDataGrid_0.Close();
        }
        if (this.frmDataDisplay_0 != null)
        {
            this.frmDataDisplay_0.Close();
        }
        if (this.class10_settings_0 != null)
        {
            this.class10_settings_0.int_1 = (int)base.WindowState;
            this.class10_settings_0.method_3();
        }
        if (this.frmLoading_0 != null)
        {
            this.frmLoading_0.Close();
            if (this.frmLoading_0 != null) this.frmLoading_0.Dispose();
            if (this.frmLoading_0 != null) this.frmLoading_0 = null;
        }

        //Clear BMTune repository
        if (Directory.Exists(Application.StartupPath + "\\Baseroms")) Directory.Delete(Application.StartupPath + "\\Baseroms", true);
        if (Directory.Exists(Application.StartupPath + "\\Calibrations")) Directory.Delete(Application.StartupPath + "\\Calibrations", true);
        if (Directory.Exists(Application.StartupPath + "\\ECUS")) Directory.Delete(Application.StartupPath + "\\ECUS", true);
        if (Directory.Exists(Application.StartupPath + "\\DLL")) Directory.Delete(Application.StartupPath + "\\DLL", true);
    }

    private void FrmMain_HandleCreated(object sender, EventArgs e)
    {
        this.bool_0 = true;
    }

    private void FrmMain_HandleDestroyed(object sender, EventArgs e)
    {
        this.bool_0 = false;
    }


    private void FrmMain_KeyUp(object sender, KeyEventArgs e)
    {
        if (this.class10_settings_0.GetKeyPressed(e, "Scroll tru datalog file"))
        {
            this.trackBar_0.Focus();
            e.Handled = true;
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Open Parameters"))
        {
            if (!this.class10_settings_0.WindowedMode) SelectPage("Parameters");
            else parametersToolStripButton_Click(null, null);
            e.Handled = true;
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Open Tables"))
        {
            if (!this.class10_settings_0.WindowedMode) SelectPage("Tables");
            else tablesToolStripButton_Click(null, null);
            e.Handled = true;
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Open Error Code"))
        {
            if (!this.class10_settings_0.WindowedMode) SelectPage("CEL");
            else errorToolStripButton_Click(null, null);
            e.Handled = true;
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Open Dyno Control"))
        {
            if (!this.class10_settings_0.WindowedMode) SelectPage("Dyno");
            else errorToolStripButton_Click(null, null);
            e.Handled = true;
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Copy"))
        //else if ((e.KeyCode == (Keys) Enum.Parse(typeof(Keys), "C")) && e.Control && (!e.Shift && !e.Alt))
        {
            copyToolStripButton_Click(null, null);
            e.Handled = true;
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Paste"))
        {
            pasteToolStripButton_Click(null, null);
            e.Handled = true;
        }
        else
        {
            e.Handled = false;
        }

        if (this.frmGridChart_0 != null && !this.frmGridChart_0.Focused) this.frmGridChart_0.FrmGridChart_KeyDown(sender, e);
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune";
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        if (File.Exists(Application.StartupPath + @"\Setup.zip")) File.Delete(Application.StartupPath + @"\Setup.zip");

        this.class10_settings_0 = new Class10_settings(ref this.frmMain_0);
        this.class10_settings_0.delegate10_0 += new Class10_settings.Delegate10(this.method_9);
        this.class10_settings_0.delegate12_0 += new Class10_settings.Delegate12(this.method_10);
        this.class10_settings_0.method_1();

        this.Class34_Zip_0 = new Class34_Zip();
        this.Class34_Zip_0.AddClass10(ref this.class10_settings_0);
        this.Class34_Zip_0.ExtractZip();


        string familyName = "Lucida Sans";
        using (Font font = new Font(familyName, 12f, FontStyle.Regular, GraphicsUnit.Pixel))
        {
            if (font.Name != familyName)
            {
                string[] textArray1 = new string[] { "Your computer is missing Lucida Sans font pack.", Environment.NewLine, "It will run faster with the correct font installed", Environment.NewLine, "Do you want to install it?" };
                if (MessageBox.Show(string.Concat(textArray1), "Missing Font:", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string Filename = "Lucida Sans.ttf";
                    string ZipFolder = "DLL";
                    string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
                    if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
                    if (File.Exists(WholePath)) ExecuteNotAsAdmin(WholePath);
                    else Process.Start("https://www.wfonts.com/font/lucida-sans");
                }
            }
        }
        this.frmLoading_0.SetPercent(5);

        this.class15_0 = new Class15(ref this.frmMain_0);
        //this.class15_0.LoadingL();
        this.frmLoading_0.SetPercent(10);
        base.WindowState = FormWindowState.Maximized;
        this.Enabled = true;
        this.method_1(); //New Loading

        this.Text = "BMTune - " + this.class15_0.CurrentBMTuneVersion;
        this.Text += " (Fully Unlocked)";

        this.method_0();

        if (this.frmLoading_0 != null)
        {
            this.frmLoading_0.Close();
            if (this.frmLoading_0 != null) this.frmLoading_0.Dispose();
            if (this.frmLoading_0 != null) this.frmLoading_0 = null;
        }


        bool BMTuneOverUpdated = false;  //if higher than last stable relase
        if (File.Exists(Application.StartupPath + @"\BMTune_Backup.exe"))
        {
            BMTuneOverUpdated = true;
            this.reinstallLastStableReleaseToolStripMenuItem.Visible = true;
        }

        if (BMTuneOverUpdated)
        {
            DialogResult result = MessageBox.Show(Form.ActiveForm, "This is a BETA update!" + Environment.NewLine + "" +
            "" + Environment.NewLine + "This update can be UNSTABLE but it's suggested that you report any bugs to support@bmtune.com" +
            "" + Environment.NewLine + "" +
            "" + Environment.NewLine + "" + Environment.NewLine + "Do you want to continue with the BETA update?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result != DialogResult.Yes)
            {
                Process.Start(Application.StartupPath + @"\BMTune_Backup.exe");
                Environment.Exit(0);
            }
        }

        GC.Collect(3, GCCollectionMode.Forced);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        /*foreach (Control c in this.Controls)
        {
            UpdateColorControls(c);
        }*/
    }

    //#####################################################################################################
    //#####################################################################################################
    //#####################################################################################################

    public bool AddthisPage(int Current_Control, string Page_Name)
    {
        //get already done
        bool AlreadyDoneThis = false;
        for (int i2 = 0; i2 < PagesDoneList.Count; i2++)
        {
            if (PagesDoneList[i2] == Page_Name) AlreadyDoneThis = true;
        }

        bool Found = false;
        if (!AlreadyDoneThis)
        {
            Control TControl = new Control();
            TabControl TControl2 = new TabControl();
            if (Page_Name == "Datalog") { TControl = this.frmDataGrid_0; Found = true; }
            if (Page_Name == "Tables") { TControl = this.frmGridChart_0; Found = true; }
            if (Page_Name == "Parameters") { TControl = this.frmParameters_0; Found = true; }
            if (Page_Name == "Graph") { TControl = this.frmDatalogGraphs_0; Found = true; }
            if (Page_Name == "CEL") { TControl = this.frmErrorCodes_0; Found = true; }
            if (Page_Name == "Debug Logs") { TControl = this.frmDebug_0; Found = true; }
            if (Page_Name == "LivePlot") { TControl = this.frmLivePlot_0; Found = true; }
            if (Page_Name == "Snapshots") { TControl = this.frmQuickSaveMain_0; Found = true; }
            if (Page_Name == "Datalogs Threads") { TControl = this.frmActiveDatalog_0; Found = true; }
            if (Page_Name == "Dyno") { TControl = this.frmDynoControl_0; Found = true; }

            if (Found)
            {
                if (Current_Control == 0) TControl2 = this.tabControl1;
                if (Current_Control == 1) TControl2 = this.tabControl2;
                if (Current_Control == 2) TControl2 = this.tabControl3;
                if (Current_Control == 3) TControl2 = this.tabControl4;
                if (Current_Control == 4) TControl2 = this.tabControl5;

                TControl2.TabPages.Add(Page_Name);
                TControl2.TabPages[TControl2.TabPages.Count - 1].Name = Page_Name;
                TControl2.TabPages[TControl2.TabPages.Count - 1].Controls.Add(TControl);
            }
        }
        return Found;
    }

    public void DisposeAll()
    {
        if (!Disposed)
        {
            if (this.frmDebug_0 != null) this.frmDebug_0.Close();
            if (this.frmDebug_0 != null) this.frmDebug_0.Dispose();
            if (this.frmDebug_0 != null) this.frmDebug_0 = null;

            if (this.frmErrorCodes_0 != null) this.frmErrorCodes_0.Close();
            if (this.frmErrorCodes_0 != null) this.frmErrorCodes_0.Dispose();
            if (this.frmErrorCodes_0 != null) this.frmErrorCodes_0 = null;

            if (this.frmParameters_0 != null) this.frmParameters_0.Close();
            if (this.frmParameters_0 != null) this.frmParameters_0.Dispose();
            if (this.frmParameters_0 != null) this.frmParameters_0 = null;

            if (this.frmDatalogGraphs_0 != null) this.frmDatalogGraphs_0.Close();
            if (this.frmDatalogGraphs_0 != null) this.frmDatalogGraphs_0.Dispose();
            if (this.frmDatalogGraphs_0 != null) this.frmDatalogGraphs_0 = null;

            if (this.frmDataGrid_0 != null) this.frmDataGrid_0.Close();
            if (this.frmDataGrid_0 != null) this.frmDataGrid_0.Dispose();
            if (this.frmDataGrid_0 != null) this.frmDataGrid_0 = null;

            if (this.frmGridChart_0 != null) this.frmGridChart_0.Close();
            if (this.frmGridChart_0 != null) this.frmGridChart_0.Dispose();
            if (this.frmGridChart_0 != null) this.frmGridChart_0 = null;

            if (this.frmDataDisplay_0 != null) this.frmDataDisplay_0.Close();
            if (this.frmDataDisplay_0 != null) this.frmDataDisplay_0.Dispose();
            if (this.frmDataDisplay_0 != null) this.frmDataDisplay_0 = null;

            if (this.frmLivePlot_0 != null) this.frmLivePlot_0.Close();
            if (this.frmLivePlot_0 != null) this.frmLivePlot_0.Dispose();
            if (this.frmLivePlot_0 != null) this.frmLivePlot_0 = null;

            if (this.frmQuickSaveMain_0 != null) this.frmQuickSaveMain_0.Close();
            if (this.frmQuickSaveMain_0 != null) this.frmQuickSaveMain_0.Dispose();
            if (this.frmQuickSaveMain_0 != null) this.frmQuickSaveMain_0 = null;

            if (this.frmActiveDatalog_0 != null) this.frmActiveDatalog_0.Close();
            if (this.frmActiveDatalog_0 != null) this.frmActiveDatalog_0.Dispose();
            if (this.frmActiveDatalog_0 != null) this.frmActiveDatalog_0 = null;

            if (this.frmDynoControl_0 != null) this.frmDynoControl_0.Close();
            if (this.frmDynoControl_0 != null) this.frmDynoControl_0.Dispose();
            if (this.frmDynoControl_0 != null) this.frmDynoControl_0 = null;

            /*if (this.ktable_0 != null) this.ktable_0.Close();
            if (this.ktable_0 != null) this.ktable_0.Dispose();
            if (this.ktable_0 != null) this.ktable_0 = null;*/

            /*if (this.obd0Table_0 != null) this.obd0Table_0.Close();
            if (this.obd0Table_0 != null) this.obd0Table_0.Dispose();
            if (this.obd0Table_0 != null) this.obd0Table_0 = null;*/


            Disposed = true;
        }
    }

    public void LoadPages()
    {
        this.SpawnWaitingwindows();
        //Reset (Docked Mode Extra)
        try
        {
            this.tabControl1.Controls.Clear();
            this.tabControl2.Controls.Clear();
            this.tabControl3.Controls.Clear();
            this.tabControl4.Controls.Clear();
            this.tabControl5.Controls.Clear();

            this.tabControl1.TabPages.Clear();
            this.tabControl2.TabPages.Clear();
            this.tabControl3.TabPages.Clear();
            this.tabControl4.TabPages.Clear();
            this.tabControl5.TabPages.Clear();
        }
        catch { }


        if (this.class10_settings_0 == null)
        {
            this.class10_settings_0 = new Class10_settings(ref this.frmMain_0);
            this.class10_settings_0.delegate10_0 += new Class10_settings.Delegate10(this.method_9);
            this.class10_settings_0.delegate12_0 += new Class10_settings.Delegate12(this.method_10);
            this.class10_settings_0.method_1();
        }

        this.splitContainer2_Top.Panel1.Controls.Clear();                   //Clear datalog Display (Led, bar graph, gauge, etc)
        this.splitContainer1_Left.Visible = !this.class10_settings_0.WindowedMode;   //show docked mode or not

        toolStripSeparator2.Visible = this.class10_settings_0.WindowedMode;
        //windowsToolStripMenuItem.Visible = this.class10_0.WindowedMode;
        //windowsToolStrip.Visible = this.class10_0.WindowedMode;


        DisposeAll();

        this.frmDataDisplay_0 = new FrmDataDisplay();
        this.frmDataDisplay_0.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);
        this.frmDataDisplay_0.MdiParent = this;

        this.frmGridChart_0 = new FrmGridChart();
        this.frmGridChart_0.method_2(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.class12_afrT_0, ref this.class11_u_0, ref this.frmMain_0);
        this.frmGridChart_0.MdiParent = this;

        this.frmDataGrid_0 = new frmDataGrid();
        this.frmDataGrid_0.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);
        this.frmDataGrid_0.MdiParent = this;

        this.frmParameters_0 = new frmParameters();
        this.frmParameters_0.method_0(ref this.class18_0, ref this.frmMain_0);
        this.frmParameters_0.MdiParent = this;

        /*this.ktable_0 = new Ktable(ref this.class10_settings_0);
        this.ktable_0.method_33(ref this.class18_0, ref this.frmMain_0, ref this.class10_settings_0);
        this.ktable_0.MdiParent = this;*/

        //this.Class38_0 = null;
        //Class38_0 = new Class38(ref ktable_0.Class39_0, ref frmMain_0);

        if (!this.class10_settings_0.WindowedMode)
        {
            this.frmLivePlot_0 = new frmLivePlot();
            this.frmLivePlot_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmLivePlot_0.MdiParent = this;

            this.frmDatalogGraphs_0 = new frmDatalogGraphs();
            this.frmDatalogGraphs_0.method_1(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);
            this.frmDatalogGraphs_0.MdiParent = this;

            this.frmErrorCodes_0 = new frmErrorCodes();
            this.frmErrorCodes_0.method_0(ref this.class18_0, ref this.class17_0, ref this.frmMain_0);
            this.frmErrorCodes_0.MdiParent = this;

            this.frmDebug_0 = new frmDebug();
            this.frmDebug_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmDebug_0.MdiParent = this;

            this.frmQuickSaveMain_0 = new frmQuickSaveMain();
            this.frmQuickSaveMain_0.method_0(ref this.class21_snap_0, ref this.class18_0);
            this.frmQuickSaveMain_0.MdiParent = this;


            this.frmActiveDatalog_0 = new frmActiveDatalog();
            this.frmActiveDatalog_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmActiveDatalog_0.MdiParent = this;

            this.frmDynoControl_0 = new frmDynoControl();
            this.frmDynoControl_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmDynoControl_0.MdiParent = this;

            //Docked Mode Extra
            this.splitContainer2_Top.Panel1.Controls.Add(this.frmDataDisplay_0);
            PagesDoneList = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                string ThisTabs = "";
                if (i == 0) ThisTabs = this.class10_settings_0.Tabs1_Names;
                if (i == 1) ThisTabs = this.class10_settings_0.Tabs2_Names;
                if (i == 2) ThisTabs = this.class10_settings_0.Tabs3_Names;
                if (i == 3) ThisTabs = this.class10_settings_0.Tabs4_Names;
                if (i == 4) ThisTabs = this.class10_settings_0.Tabs5_Names;

                bool CanFollow = true;
                if (!this.class10_settings_0.Tabs3_Show && i == 2) CanFollow = false;
                if (!this.class10_settings_0.Tabs4_Show && i == 3) CanFollow = false;
                if (!this.class10_settings_0.Tabs5_Show && i == 4) CanFollow = false;

                if (ThisTabs.Contains(",") && CanFollow)
                {
                    string[] SplittedNames = ThisTabs.Split(',');
                    for (int i2 = 0; i2 < SplittedNames.Length; i2++)
                        if (AddthisPage(i, SplittedNames[i2])) PagesDoneList.Add(SplittedNames[i2]);
                }
            }

            //#### MAKE SURE TO CHANGE THIS NUMBER WITH THE PAGES AVAILABLE ####
            //Check for undone page
            if (PagesDoneList.Count != 9)
            {
                bool DatalogDone = false;
                bool TablesDone = false;
                bool ParametersDone = false;
                bool GraphDone = false;
                bool CELDone = false;
                bool DebugDone = false;
                bool LivePlotDone = false;
                bool SnapDone = false;
                bool ActiveDatalogDone = false;
                bool DynoDone = false;

                for (int i2 = 0; i2 < PagesDoneList.Count; i2++)
                {
                    if (PagesDoneList[i2] == "Datalog") DatalogDone = true;
                    if (PagesDoneList[i2] == "Tables") TablesDone = true;
                    if (PagesDoneList[i2] == "Parameters") ParametersDone = true;
                    if (PagesDoneList[i2] == "Graph") GraphDone = true;
                    if (PagesDoneList[i2] == "CEL") CELDone = true;
                    if (PagesDoneList[i2] == "Debug Logs") DebugDone = true;
                    if (PagesDoneList[i2] == "LivePlot") LivePlotDone = true;
                    if (PagesDoneList[i2] == "Snapshots") SnapDone = true;
                    if (PagesDoneList[i2] == "Datalogs Threads") ActiveDatalogDone = true;
                    if (PagesDoneList[i2] == "Dyno") DynoDone = true;
                }

                if (!DatalogDone) AddthisPage(0, "Datalog");
                if (!TablesDone) AddthisPage(1, "Tables");
                if (!ParametersDone) AddthisPage(1, "Parameters");
                if (!GraphDone) AddthisPage(2, "Graph");
                if (!CELDone) AddthisPage(3, "CEL");
                if (!DebugDone) AddthisPage(3, "Debug Logs");
                if (!LivePlotDone) AddthisPage(2, "LivePlot");
                if (!SnapDone) AddthisPage(1, "Snapshots");
                if (!ActiveDatalogDone) AddthisPage(3, "Datalogs Threads");
                if (!DynoDone) AddthisPage(3, "Dyno");
            }

            //Select Tab
            try { if (this.tabControl1.TabPages[this.class10_settings_0.Tabs1_Selected] != null) if (this.class10_settings_0.Tabs1_Selected > 0) this.tabControl1.SelectTab(this.class10_settings_0.Tabs1_Selected); } catch { this.class10_settings_0.Tabs1_Selected = 0; };
            try { if (this.tabControl2.TabPages[this.class10_settings_0.Tabs2_Selected] != null) if (this.class10_settings_0.Tabs2_Selected > 0) this.tabControl2.SelectTab(this.class10_settings_0.Tabs2_Selected); } catch { this.class10_settings_0.Tabs2_Selected = 0; };
            try { if (this.tabControl3.TabPages[this.class10_settings_0.Tabs3_Selected] != null) if (this.class10_settings_0.Tabs3_Selected > 0 && this.class10_settings_0.Tabs3_Show) this.tabControl3.SelectTab(this.class10_settings_0.Tabs3_Selected); } catch { this.class10_settings_0.Tabs3_Selected = 0; };
            try { if (this.tabControl4.TabPages[this.class10_settings_0.Tabs4_Selected] != null) if (this.class10_settings_0.Tabs4_Selected > 0 && this.class10_settings_0.Tabs4_Show) this.tabControl4.SelectTab(this.class10_settings_0.Tabs4_Selected); } catch { this.class10_settings_0.Tabs4_Selected = 0; };
            try { if (this.tabControl5.TabPages[this.class10_settings_0.Tabs5_Selected] != null) if (this.class10_settings_0.Tabs5_Selected > 0 && this.class10_settings_0.Tabs5_Show) this.tabControl5.SelectTab(this.class10_settings_0.Tabs5_Selected); } catch { this.class10_settings_0.Tabs5_Selected = 0; };

            ReloadDockedModePageSize();

            this.splitContainer2_Top.Panel1Collapsed = false;
            this.splitContainer2_Top.Panel2Collapsed = false;
            this.splitContainer3_Bottom.Panel1Collapsed = false;
            this.splitContainer6_Right.Panel2Collapsed = false;
            this.splitContainer5_BottomLeft.Panel1Collapsed = false;
            this.splitContainer5_BottomLeft.Panel2Collapsed = false;
            this.splitContainer3_Bottom.Panel2Collapsed = false;
            this.splitContainer5_BottomLeft.Panel2Collapsed = false;
            this.splitContainer6_Right.Panel2Collapsed = false;

            this.class10_settings_0.Tabs3_Show = true;
            this.class10_settings_0.Tabs4_Show = true;
            this.class10_settings_0.Tabs5_Show = true;
            //this.splitContainer3_Bottom.Panel2Collapsed = !this.class10_settings_0.Tabs3_Show;
            //this.splitContainer5_BottomLeft.Panel2Collapsed = !this.class10_settings_0.Tabs4_Show;
            //this.splitContainer6_Right.Panel2Collapsed = !this.class10_settings_0.Tabs5_Show;

            this.splitContainer1_Left.SplitterDistance = this.class10_settings_0.TabsLeft_Split;
            this.splitContainer2_Top.SplitterDistance = this.class10_settings_0.TabsTop_Split;
            if (this.class10_settings_0.Tabs3_Show) this.splitContainer3_Bottom.SplitterDistance = this.class10_settings_0.TabsBottom_Split;
            if (this.class10_settings_0.Tabs4_Show) this.splitContainer5_BottomLeft.SplitterDistance = this.class10_settings_0.TabsBottomLeft_Split;
            if (this.class10_settings_0.Tabs5_Show) this.splitContainer6_Right.SplitterDistance = this.class10_settings_0.TabsRight_Split;

            this.frmParameters_0.splitContainer1.SplitterDistance = this.class10_settings_0.Parameter_Splitter;
            CheckEmptyPages();
        }

        LastWindowsState = base.WindowState;

        this.CloseWaitingwindows();
        this.frmDataDisplay_0.Show();
        this.frmGridChart_0.Show();
        this.frmDataGrid_0.Show();
        this.frmParameters_0.Show();
        if (!this.class10_settings_0.WindowedMode)
        {
            this.frmDatalogGraphs_0.Show();
            this.frmLivePlot_0.Show();
            this.frmErrorCodes_0.Show();
            this.frmDebug_0.Show();
            this.frmQuickSaveMain_0.Show();
            this.frmActiveDatalog_0.Show();
            this.frmDynoControl_0.Show();

            //hints
            if (!this.class10_settings_0.ShownHint_Dragging)
            {
                string ThisHint = "You can Drag the Tab pages" + Environment.NewLine + "to another Tab control!";
                int LocX = this.tabControl2.Location.X + 50;
                int LocY = this.tabControl2.Location.Y + 30 + this.toolStripPanelTop.Size.Height;

                frmHints frmHints_0 = new frmHints(ThisHint, true, 10, new Point(LocX, LocY));
                DialogResult result = frmHints_0.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.class10_settings_0.ShownHint_Dragging = true;
                }
            }

            if (!this.class10_settings_0.ShownHint_Separator)
            {
                string ThisHint = "You can move the separators" + Environment.NewLine + "to customize the layout!";
                int LocX = this.splitContainer1_Left.Location.X + this.splitContainer1_Left.SplitterDistance + 5;
                int LocY = this.splitContainer1_Left.Location.Y + 80 + this.toolStripPanelTop.Size.Height;

                frmHints frmHints_0 = new frmHints(ThisHint, true, 10, new Point(LocX, LocY));
                DialogResult result = frmHints_0.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.class10_settings_0.ShownHint_Separator = true;
                }
            }

            if (!this.class10_settings_0.ShownHint_DebugLogs)
            {
                for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    if (this.tabControl1.TabPages[i].Text.ToString() == "Debug Logs")
                    {
                        string ThisHint = "You can use the debug logs to" + Environment.NewLine + "debug possible issue by yourself!";
                        int LocX = this.tabControl2.Location.X + 90;
                        int LocY = this.tabControl2.Location.Y + 30 + this.toolStripPanelTop.Size.Height;

                        frmHints frmHints_0 = new frmHints(ThisHint, true, 10, new Point(LocX, LocY));
                        DialogResult result = frmHints_0.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            this.class10_settings_0.ShownHint_DebugLogs = true;
                        }

                        i = this.tabControl1.TabPages.Count + 1;
                    }
                }
            }

            this.frmDataDisplay_0.LoadHints();
        }

        //Reload custom menu
        this.fileToolStripMenuItem1.Visible = true;
        if (CustomMenuLoaded) LoadKTable(KTableLoaded, OBD0Loaded);

        Disposed = false;
    }



    private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TabControl tCtrl = (TabControl)sender;
        if (tCtrl.SelectedTab != null)
        {
            if (this.class10_settings_0 != null)
            {
                if (!this.class10_settings_0.WindowedMode)
                {
                    if (tCtrl.SelectedTab.Name == "Datalog") this.frmDataGrid_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "Tables") this.frmGridChart_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "Parameters") this.frmParameters_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "Graph") this.frmDatalogGraphs_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "CEL") this.frmErrorCodes_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "Debug Logs") this.frmDebug_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "LivePlot") this.frmLivePlot_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "Snapshots") this.frmQuickSaveMain_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "Datalogs Threads") this.frmActiveDatalog_0.Invalidate();
                    if (tCtrl.SelectedTab.Name == "Dyno") this.frmDynoControl_0.Invalidate();
                    /*if (tCtrl.SelectedTab.Name == "K-Table")
                    {
                        if (this.ktable_0 != null)
                        {
                            this.ktable_0.Invalidate();
                            this.ktable_0.method_1();
                        }
                    }*/
                }
            }
        }
    }

    public void ReloadDockedModePageSize()
    {
        try
        {
            if (this.class10_settings_0 != null)
            {
                if (!this.class10_settings_0.WindowedMode)
                {
                    int BorderWidth = (this.Width - this.ClientSize.Width) / 2;
                    int TitlebarHeight = this.Height - this.ClientSize.Height - (2 * BorderWidth);

                    this.splitContainer1_Left.Location = new Point(0, this.toolStripPanelTop.Height);
                    this.splitContainer1_Left.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - this.toolStripPanelTop.Height - this.statusStrip1.Height);
                }
            }
        }
        catch (Exception message)
        {
            LogThisMain("Can't set docked mode windows location and size! See the error:" + Environment.NewLine + "" + message);
        }
    }

    public void SavePages()
    {
        if (this.class10_settings_0 != null)
        {
            if (!this.class10_settings_0.WindowedMode)
            {
                this.class10_settings_0.Tabs1_Names = "";
                this.class10_settings_0.Tabs2_Names = "";
                this.class10_settings_0.Tabs3_Names = "";
                this.class10_settings_0.Tabs4_Names = "";
                this.class10_settings_0.Tabs5_Names = "";

                for (int i = 0; i < 5; i++)
                {
                    if (i == 0) if (this.tabControl1.TabPages.Count > 0) for (int i2 = 0; i2 < this.tabControl1.TabPages.Count; i2++) this.class10_settings_0.Tabs1_Names += this.tabControl1.TabPages[i2].Text.ToString() + ",";
                    if (i == 1) if (this.tabControl2.TabPages.Count > 0) for (int i2 = 0; i2 < this.tabControl2.TabPages.Count; i2++) this.class10_settings_0.Tabs2_Names += this.tabControl2.TabPages[i2].Text.ToString() + ",";
                    if (i == 2) if (this.tabControl3.TabPages.Count > 0) for (int i2 = 0; i2 < this.tabControl3.TabPages.Count; i2++) this.class10_settings_0.Tabs3_Names += this.tabControl3.TabPages[i2].Text.ToString() + ",";
                    if (i == 3) if (this.tabControl4.TabPages.Count > 0) for (int i2 = 0; i2 < this.tabControl4.TabPages.Count; i2++) this.class10_settings_0.Tabs4_Names += this.tabControl4.TabPages[i2].Text.ToString() + ",";
                    if (i == 4) if (this.tabControl5.TabPages.Count > 0) for (int i2 = 0; i2 < this.tabControl5.TabPages.Count; i2++) this.class10_settings_0.Tabs5_Names += this.tabControl5.TabPages[i2].Text.ToString() + ",";
                }
                this.class10_settings_0.Tabs1_Selected = this.tabControl1.SelectedIndex;
                this.class10_settings_0.Tabs2_Selected = this.tabControl2.SelectedIndex;
                this.class10_settings_0.Tabs3_Selected = this.tabControl3.SelectedIndex;
                this.class10_settings_0.Tabs4_Selected = this.tabControl4.SelectedIndex;
                this.class10_settings_0.Tabs5_Selected = this.tabControl4.SelectedIndex;

                this.class10_settings_0.Tabs3_Show = !this.splitContainer3_Bottom.Panel2Collapsed;
                this.class10_settings_0.Tabs4_Show = !this.splitContainer5_BottomLeft.Panel2Collapsed;
                this.class10_settings_0.Tabs5_Show = !this.splitContainer6_Right.Panel2Collapsed;

                this.class10_settings_0.TabsLeft_Split = this.splitContainer1_Left.SplitterDistance;
                this.class10_settings_0.TabsTop_Split = this.splitContainer2_Top.SplitterDistance;
                if (this.class10_settings_0.Tabs3_Show) this.class10_settings_0.TabsBottom_Split = this.splitContainer3_Bottom.SplitterDistance;
                if (this.class10_settings_0.Tabs4_Show) this.class10_settings_0.TabsBottomLeft_Split = this.splitContainer5_BottomLeft.SplitterDistance;
                if (this.class10_settings_0.Tabs5_Show) this.class10_settings_0.TabsRight_Split = this.splitContainer6_Right.SplitterDistance;
            }
        }
    }

    public void CheckEmptyPages()
    {
        CheckForDraggedPageName();
        if (this.tabControl3.TabPages.Count == 0) this.splitContainer3_Bottom.Panel2Collapsed = true;
        else this.splitContainer3_Bottom.Panel2Collapsed = false;
        if (this.tabControl4.TabPages.Count == 0) this.splitContainer5_BottomLeft.Panel2Collapsed = true;
        else this.splitContainer5_BottomLeft.Panel2Collapsed = false;
        if (this.tabControl5.TabPages.Count == 0) this.splitContainer6_Right.Panel2Collapsed = true;
        else this.splitContainer6_Right.Panel2Collapsed = false;

        this.class10_settings_0.Tabs3_Show = !this.splitContainer3_Bottom.Panel2Collapsed;
        this.class10_settings_0.Tabs4_Show = !this.splitContainer5_BottomLeft.Panel2Collapsed;
        this.class10_settings_0.Tabs5_Show = !this.splitContainer6_Right.Panel2Collapsed;
    }

    public void CheckEmptyPagesDragging()
    {
        if (this.tabControl1.TabPages.Count == 0)
        {
            this.tabControl1.TabPages.Add("DRAG HERE");
        }
        if (this.tabControl2.TabPages.Count == 0)
        {
            this.tabControl2.TabPages.Add("DRAG HERE");
        }

        if (this.tabControl3.TabPages.Count == 0)
        {
            this.splitContainer3_Bottom.Panel2Collapsed = false;
            this.tabControl3.TabPages.Add("DRAG HERE");
        }
        if (this.tabControl4.TabPages.Count == 0)
        {
            this.splitContainer5_BottomLeft.Panel2Collapsed = false;
            this.tabControl4.TabPages.Add("DRAG HERE");
        }
        if (this.tabControl5.TabPages.Count == 0)
        {
            this.splitContainer6_Right.Panel2Collapsed = false;
            this.tabControl5.TabPages.Add("DRAG HERE");
        }
    }

    public bool IsPageFocused(string Page_Name)
    {
        if (!this.class10_settings_0.WindowedMode)
        {
            if (this.tabControl1.TabPages.Count > 0)
                for (int i2 = 0; i2 < this.tabControl1.TabPages.Count; i2++)
                    if (this.tabControl1.TabPages[i2].Text.ToString() == Page_Name && this.tabControl1.SelectedIndex == i2) return true;

            if (this.tabControl2.TabPages.Count > 0)
                for (int i2 = 0; i2 < this.tabControl2.TabPages.Count; i2++)
                    if (this.tabControl2.TabPages[i2].Text.ToString() == Page_Name && this.tabControl2.SelectedIndex == i2) return true;

            if (this.tabControl3.TabPages.Count > 0)
                for (int i2 = 0; i2 < this.tabControl3.TabPages.Count; i2++)
                    if (this.tabControl3.TabPages[i2].Text.ToString() == Page_Name && this.tabControl3.SelectedIndex == i2) return true;

            if (this.tabControl4.TabPages.Count > 0)
                for (int i2 = 0; i2 < this.tabControl4.TabPages.Count; i2++)
                    if (this.tabControl4.TabPages[i2].Text.ToString() == Page_Name && this.tabControl4.SelectedIndex == i2) return true;

            if (this.tabControl5.TabPages.Count > 0)
                for (int i2 = 0; i2 < this.tabControl5.TabPages.Count; i2++)
                    if (this.tabControl5.TabPages[i2].Text.ToString() == Page_Name && this.tabControl5.SelectedIndex == i2) return true;
        }
        else
        {
            return true;
        }
        return false;
    }

    public void CheckForDraggedPageName()
    {
        if (this.tabControl1.TabPages.Count > 0)
            for (int i2 = 0; i2 < this.tabControl1.TabPages.Count; i2++)
                if (this.tabControl1.TabPages[i2].Text.ToString() == "DRAG HERE")
                    this.tabControl1.TabPages.RemoveAt(i2);

        if (this.tabControl2.TabPages.Count > 0)
            for (int i2 = 0; i2 < this.tabControl2.TabPages.Count; i2++)
                if (this.tabControl2.TabPages[i2].Text.ToString() == "DRAG HERE")
                    this.tabControl2.TabPages.RemoveAt(i2);

        if (this.tabControl3.TabPages.Count > 0)
            for (int i2 = 0; i2 < this.tabControl3.TabPages.Count; i2++)
                if (this.tabControl3.TabPages[i2].Text.ToString() == "DRAG HERE")
                    this.tabControl3.TabPages.RemoveAt(i2);

        if (this.tabControl4.TabPages.Count > 0)
            for (int i2 = 0; i2 < this.tabControl4.TabPages.Count; i2++)
                if (this.tabControl4.TabPages[i2].Text.ToString() == "DRAG HERE")
                    this.tabControl4.TabPages.RemoveAt(i2);

        if (this.tabControl5.TabPages.Count > 0)
            for (int i2 = 0; i2 < this.tabControl5.TabPages.Count; i2++)
                if (this.tabControl5.TabPages[i2].Text.ToString() == "DRAG HERE")
                    this.tabControl5.TabPages.RemoveAt(i2);
    }

    public void SelectPage(string PageN)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == 0)
                if (this.tabControl1.TabPages.Count > 0)
                    for (int i2 = 0; i2 < this.tabControl1.TabPages.Count; i2++)
                        if (this.tabControl1.TabPages[i2].Text.ToString() == PageN)
                            if (this.tabControl1.TabPages[i2] != null) this.tabControl1.SelectTab(i2);
            if (i == 1)
                if (this.tabControl2.TabPages.Count > 0)
                    for (int i2 = 0; i2 < this.tabControl2.TabPages.Count; i2++)
                        if (this.tabControl2.TabPages[i2].Text.ToString() == PageN)
                            if (this.tabControl2.TabPages[i2] != null) this.tabControl2.SelectTab(i2);
            if (i == 2)
                if (this.tabControl3.TabPages.Count > 0)
                    for (int i2 = 0; i2 < this.tabControl3.TabPages.Count; i2++)
                        if (this.tabControl3.TabPages[i2].Text.ToString() == PageN)
                            if (this.tabControl3.TabPages[i2] != null) this.tabControl3.SelectTab(i2);
            if (i == 3)
                if (this.tabControl4.TabPages.Count > 0)
                    for (int i2 = 0; i2 < this.tabControl4.TabPages.Count; i2++)
                        if (this.tabControl4.TabPages[i2].Text.ToString() == PageN)
                            if (this.tabControl4.TabPages[i2] != null) this.tabControl4.SelectTab(i2);
            if (i == 4)
                if (this.tabControl5.TabPages.Count > 0)
                    for (int i2 = 0; i2 < this.tabControl5.TabPages.Count; i2++)
                        if (this.tabControl5.TabPages[i2].Text.ToString() == PageN)
                            if (this.tabControl5.TabPages[i2] != null) this.tabControl5.SelectTab(i2);
        }
    }


    public void graphsSetupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmChartTemplates_0 != null)
        {
            this.frmChartTemplates_0.Dispose();
            this.frmChartTemplates_0 = null;
        }

        this.frmChartTemplates_0 = new frmChartTemplates();
        this.frmChartTemplates_0.method_0(ref this.class18_0, ref this.class10_settings_0);
        this.frmChartTemplates_0.Show();
    }

    public void graphsToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.frmDatalogGraphs_0 != null)
        {
            this.frmDatalogGraphs_0.Focus();
        }
        else
        {
            this.frmDatalogGraphs_0 = new frmDatalogGraphs();
            this.frmDatalogGraphs_0.method_1(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);
            this.frmDatalogGraphs_0.MdiParent = this;
            this.frmDatalogGraphs_0.Show();
        }
        OpenThisTab("Graph");
    }

    private void ignitionSyncToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmIgnitionSync_0 != null)
        {
            this.frmIgnitionSync_0.Focus();
        }
        else
        {
            this.frmIgnitionSync_0 = new frmIgnitionSync();
            this.frmIgnitionSync_0.method_0(ref this.class18_0);
            this.frmIgnitionSync_0.ShowDialog();
            this.class18_0.method_53();
            this.frmIgnitionSync_0.Dispose();
            this.frmIgnitionSync_0 = null;
        }
    }

    private void importTablesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.class18_0.method_83();
        }
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mdiMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.create2TimerBin512kbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveQuickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadBaseromOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chipBurnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readChipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeChipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyChipToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.copyPrimaryTablesToSecondaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySecondaryTablesToPrimaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyScalarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rpmScalarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScalarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.interpolateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interpolateHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interpolateVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLivePlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapTraceTrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearCELErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugLogsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.emulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emuConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emuRealTimeUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.emuGetRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emuPutRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emuUploadCalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emuVerifyRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogAfterRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.dlTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onBoardLoggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.dlOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlExporttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTunerViewRAWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlCloudtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.playBackwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playQuarterSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playHalfSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playDoubleSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator40 = new System.Windows.Forms.ToolStripSeparator();
            this.iSRV3ProtocolInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primaryLowIgnitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primaryHighIgnitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primaryLowFuelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primaryHighFuelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.primaryTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondaryTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.mapValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aFTargetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuelDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vETablesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.FuelRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuelDutyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuelInjDurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.analog1Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.analog2Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.analog3Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.dynoTractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynoHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynoNMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynoAUX1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynoAUX2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynoAUX3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynoTHCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.livePlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeDatalogsThreadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sensorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.fileToolbarVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulatorToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datalogToolbartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tPSCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.injectorCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignitionSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gearLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.bstTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalarSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.windowedModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseromConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.converterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bluetoothProgrammerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMBurnerChipBurningToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMDevsFirmwareUpdaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMDataloggerLCDDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moatesDemonOstrichResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moatesFlashBurnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OBD2ScanStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPortHelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killInjectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuelPumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onDrainTankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useHighCamsMapsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSecondaryMapsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTunerFollowVtec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerFollowDualTables = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerMapTrail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerSmartTrack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator41 = new System.Windows.Forms.ToolStripSeparator();
            this.testECUOutputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuelPumpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.a10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fANCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aLTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortcutKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBMTuneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLimitsWarningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinstallLastStableReleaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.benchmarkToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPanelTop = new System.Windows.Forms.ToolStripPanel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownLastFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveSnapshot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUploadFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCloseFile = new System.Windows.Forms.ToolStripButton();
            this.editToolStrip = new System.Windows.Forms.ToolStrip();
            this.undoToolStripDropDown = new System.Windows.Forms.ToolStripSplitButton();
            this.redoToolStripDropDown = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButtonUndoHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator49 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonIncSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdjustSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonInterpolate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInterpolateRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInterpolateColomn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSmoothMap = new System.Windows.Forms.ToolStripButton();
            this.emulatorToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonEmuConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmuDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmuUploadAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmuUploadCal = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmuRealtime = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmuInfos = new System.Windows.Forms.ToolStripButton();
            this.dataloggingToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolDtConnect = new System.Windows.Forms.ToolStripButton();
            this.toolDtRecord = new System.Windows.Forms.ToolStripButton();
            this.toolDtSave = new System.Windows.Forms.ToolStripButton();
            this.toolDtOpen = new System.Windows.Forms.ToolStripButton();
            this.toolDtClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator50 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDtAutoSave = new System.Windows.Forms.ToolStripButton();
            this.toolDtPeakMax = new System.Windows.Forms.ToolStripButton();
            this.toolDtPeakClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator51 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDtPlayBack = new System.Windows.Forms.ToolStripButton();
            this.toolDtPlay = new System.Windows.Forms.ToolStripButton();
            this.toolDtQuart = new System.Windows.Forms.ToolStripButton();
            this.toolDtHalf = new System.Windows.Forms.ToolStripButton();
            this.toolDtForward = new System.Windows.Forms.ToolStripButton();
            this.toolDtPause = new System.Windows.Forms.ToolStripButton();
            this.toolDtStop = new System.Windows.Forms.ToolStripButton();
            this.dtToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLowIgn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHighIgn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLowFuel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHighFuel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPrimary = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSecondary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMapValues = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAFTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAFReading = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAFDiff = new System.Windows.Forms.ToolStripButton();
            this.windowsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonParameters = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTables = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCELCodes = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDebugLogs = new System.Windows.Forms.ToolStripButton();
            this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.statusBaserom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.statusEmulator = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.statusDatalogging = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.statusWB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusDyno = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.stutasEmulatorProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.splitContainer1_Left = new System.Windows.Forms.SplitContainer();
            this.splitContainer5_BottomLeft = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.splitContainer2_Top = new System.Windows.Forms.SplitContainer();
            this.splitContainer6_Right = new System.Windows.Forms.SplitContainer();
            this.splitContainer3_Bottom = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.mdiMenuStrip.SuspendLayout();
            this.toolStripPanelTop.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.editToolStrip.SuspendLayout();
            this.emulatorToolStrip.SuspendLayout();
            this.dataloggingToolStrip.SuspendLayout();
            this.viewToolStrip.SuspendLayout();
            this.windowsToolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1_Left)).BeginInit();
            this.splitContainer1_Left.Panel1.SuspendLayout();
            this.splitContainer1_Left.Panel2.SuspendLayout();
            this.splitContainer1_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5_BottomLeft)).BeginInit();
            this.splitContainer5_BottomLeft.Panel1.SuspendLayout();
            this.splitContainer5_BottomLeft.Panel2.SuspendLayout();
            this.splitContainer5_BottomLeft.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2_Top)).BeginInit();
            this.splitContainer2_Top.Panel2.SuspendLayout();
            this.splitContainer2_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6_Right)).BeginInit();
            this.splitContainer6_Right.Panel1.SuspendLayout();
            this.splitContainer6_Right.Panel2.SuspendLayout();
            this.splitContainer6_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3_Bottom)).BeginInit();
            this.splitContainer3_Bottom.Panel1.SuspendLayout();
            this.splitContainer3_Bottom.Panel2.SuspendLayout();
            this.splitContainer3_Bottom.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.SuspendLayout();
            // 
            // mdiMenuStrip
            // 
            this.mdiMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mdiMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.emulatorToolStripMenuItem,
            this.datalogToolStripMenuItem,
            this.dynoToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.flashToolStripMenuItem});
            this.mdiMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mdiMenuStrip.Name = "mdiMenuStrip";
            this.mdiMenuStrip.Size = new System.Drawing.Size(868, 24);
            this.mdiMenuStrip.TabIndex = 0;
            this.mdiMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.mruToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.create2TimerBin512kbToolStripMenuItem,
            this.saveQuickToolStripMenuItem,
            this.uploadBaseromOnlineToolStripMenuItem,
            this.closeRomToolStripMenuItem,
            this.chipBurnerToolStripMenuItem,
            this.toolStripSeparator13,
            this.importExportToolStripMenuItem,
            this.ExportToolStripMenuItem,
            this.toolStripSeparator4,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator7,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::Properties.Resources.New_document;
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::Properties.Resources.Folder;
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripButton_ButtonClick);
            // 
            // mruToolStripMenuItem
            // 
            this.mruToolStripMenuItem.Image = global::Properties.Resources.folder_open_document;
            this.mruToolStripMenuItem.Name = "mruToolStripMenuItem";
            this.mruToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.mruToolStripMenuItem.Text = "Open Recent";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = global::Properties.Resources.Save;
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Image = global::Properties.Resources.SaveAs;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // create2TimerBin512kbToolStripMenuItem
            // 
            this.create2TimerBin512kbToolStripMenuItem.Enabled = false;
            this.create2TimerBin512kbToolStripMenuItem.Image = global::Properties.Resources.SaveAs;
            this.create2TimerBin512kbToolStripMenuItem.Name = "create2TimerBin512kbToolStripMenuItem";
            this.create2TimerBin512kbToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.create2TimerBin512kbToolStripMenuItem.Text = "Save As 2Timer Bin (512kb)";
            this.create2TimerBin512kbToolStripMenuItem.Click += new System.EventHandler(this.Create2TimerBin512kbToolStripMenuItem_Click);
            // 
            // saveQuickToolStripMenuItem
            // 
            this.saveQuickToolStripMenuItem.Enabled = false;
            this.saveQuickToolStripMenuItem.Image = global::Properties.Resources.Movie;
            this.saveQuickToolStripMenuItem.Name = "saveQuickToolStripMenuItem";
            this.saveQuickToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.saveQuickToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.saveQuickToolStripMenuItem.Text = "Save Snapshot";
            this.saveQuickToolStripMenuItem.Click += new System.EventHandler(this.saveQuickToolStripMenuItem_Click);
            // 
            // uploadBaseromOnlineToolStripMenuItem
            // 
            this.uploadBaseromOnlineToolStripMenuItem.Enabled = false;
            this.uploadBaseromOnlineToolStripMenuItem.Image = global::Properties.Resources.Update;
            this.uploadBaseromOnlineToolStripMenuItem.Name = "uploadBaseromOnlineToolStripMenuItem";
            this.uploadBaseromOnlineToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.uploadBaseromOnlineToolStripMenuItem.Text = "Upload Baserom Online";
            this.uploadBaseromOnlineToolStripMenuItem.Click += new System.EventHandler(this.uploadBaseromOnlineToolStripMenuItem_Click);
            // 
            // closeRomToolStripMenuItem
            // 
            this.closeRomToolStripMenuItem.Enabled = false;
            this.closeRomToolStripMenuItem.Image = global::Properties.Resources.Erase;
            this.closeRomToolStripMenuItem.Name = "closeRomToolStripMenuItem";
            this.closeRomToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.closeRomToolStripMenuItem.Text = "Close";
            this.closeRomToolStripMenuItem.Click += new System.EventHandler(this.closeRomToolStripMenuItem_Click);
            // 
            // chipBurnerToolStripMenuItem
            // 
            this.chipBurnerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readChipToolStripMenuItem,
            this.writeChipToolStripMenuItem,
            this.verifyChipToolStripMenuItem1});
            this.chipBurnerToolStripMenuItem.Enabled = false;
            this.chipBurnerToolStripMenuItem.Name = "chipBurnerToolStripMenuItem";
            this.chipBurnerToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.chipBurnerToolStripMenuItem.Text = "Chip";
            // 
            // readChipToolStripMenuItem
            // 
            this.readChipToolStripMenuItem.Enabled = false;
            this.readChipToolStripMenuItem.Name = "readChipToolStripMenuItem";
            this.readChipToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.readChipToolStripMenuItem.Tag = "2";
            this.readChipToolStripMenuItem.Text = "Read Chip";
            this.readChipToolStripMenuItem.Click += new System.EventHandler(this.verifyChipToolStripMenuItem1_Click);
            // 
            // writeChipToolStripMenuItem
            // 
            this.writeChipToolStripMenuItem.Enabled = false;
            this.writeChipToolStripMenuItem.Name = "writeChipToolStripMenuItem";
            this.writeChipToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.writeChipToolStripMenuItem.Tag = "1";
            this.writeChipToolStripMenuItem.Text = "Write Chip";
            this.writeChipToolStripMenuItem.Click += new System.EventHandler(this.verifyChipToolStripMenuItem1_Click);
            // 
            // verifyChipToolStripMenuItem1
            // 
            this.verifyChipToolStripMenuItem1.Enabled = false;
            this.verifyChipToolStripMenuItem1.Name = "verifyChipToolStripMenuItem1";
            this.verifyChipToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.verifyChipToolStripMenuItem1.Tag = "3";
            this.verifyChipToolStripMenuItem1.Text = "Verify Chip";
            this.verifyChipToolStripMenuItem1.Click += new System.EventHandler(this.verifyChipToolStripMenuItem1_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(212, 6);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTablesToolStripMenuItem,
            this.importCalibrationToolStripMenuItem});
            this.importExportToolStripMenuItem.Enabled = false;
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.importExportToolStripMenuItem.Text = "Import";
            // 
            // importTablesToolStripMenuItem
            // 
            this.importTablesToolStripMenuItem.Enabled = false;
            this.importTablesToolStripMenuItem.Name = "importTablesToolStripMenuItem";
            this.importTablesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.importTablesToolStripMenuItem.Text = "Import Tables";
            this.importTablesToolStripMenuItem.Click += new System.EventHandler(this.importTablesToolStripMenuItem_Click);
            // 
            // importCalibrationToolStripMenuItem
            // 
            this.importCalibrationToolStripMenuItem.Enabled = false;
            this.importCalibrationToolStripMenuItem.Name = "importCalibrationToolStripMenuItem";
            this.importCalibrationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.importCalibrationToolStripMenuItem.Text = "Import Calibration";
            this.importCalibrationToolStripMenuItem.Click += new System.EventHandler(this.calImportToolStripButton_Click);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCalibrationToolStripMenuItem,
            this.exportTableToolStripMenuItem});
            this.ExportToolStripMenuItem.Enabled = false;
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.ExportToolStripMenuItem.Text = "Export";
            // 
            // exportCalibrationToolStripMenuItem
            // 
            this.exportCalibrationToolStripMenuItem.Enabled = false;
            this.exportCalibrationToolStripMenuItem.Name = "exportCalibrationToolStripMenuItem";
            this.exportCalibrationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exportCalibrationToolStripMenuItem.Text = "Export Calibration";
            this.exportCalibrationToolStripMenuItem.Click += new System.EventHandler(this.calExportToolStripButton_Click);
            // 
            // exportTableToolStripMenuItem
            // 
            this.exportTableToolStripMenuItem.Enabled = false;
            this.exportTableToolStripMenuItem.Name = "exportTableToolStripMenuItem";
            this.exportTableToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exportTableToolStripMenuItem.Text = "Export Tables";
            this.exportTableToolStripMenuItem.Click += new System.EventHandler(this.exportTableToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(212, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::Properties.Resources.Equipment;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(212, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.undoHistoryToolStripMenuItem,
            this.toolStripSeparator9,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator14,
            this.copyPrimaryTablesToSecondaryToolStripMenuItem,
            this.copySecondaryTablesToPrimaryToolStripMenuItem,
            this.copyScalarsToolStripMenuItem,
            this.toolStripSeparator17,
            this.increaseSelectionToolStripMenuItem,
            this.decreaseSelectionToolStripMenuItem,
            this.adjustSelectionToolStripMenuItem,
            this.toolStripSeparator15,
            this.interpolateToolStripMenuItem,
            this.interpolateHorizontallyToolStripMenuItem,
            this.interpolateVerticallyToolStripMenuItem,
            this.smoothMapsToolStripMenuItem});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem1.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Image = global::Properties.Resources.Undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripDorpDown_ButtonClick);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Image = global::Properties.Resources.Redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripDorpDown_ButtonClick);
            // 
            // undoHistoryToolStripMenuItem
            // 
            this.undoHistoryToolStripMenuItem.Enabled = false;
            this.undoHistoryToolStripMenuItem.Image = global::Properties.Resources.History;
            this.undoHistoryToolStripMenuItem.Name = "undoHistoryToolStripMenuItem";
            this.undoHistoryToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.undoHistoryToolStripMenuItem.Text = "Undo History";
            this.undoHistoryToolStripMenuItem.Click += new System.EventHandler(this.ToolStripButtonUndoHistory_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(250, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Image = global::Properties.Resources.Copy;
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Image = global::Properties.Resources.Paste;
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(250, 6);
            // 
            // copyPrimaryTablesToSecondaryToolStripMenuItem
            // 
            this.copyPrimaryTablesToSecondaryToolStripMenuItem.Enabled = false;
            this.copyPrimaryTablesToSecondaryToolStripMenuItem.Name = "copyPrimaryTablesToSecondaryToolStripMenuItem";
            this.copyPrimaryTablesToSecondaryToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.copyPrimaryTablesToSecondaryToolStripMenuItem.Text = "Copy Primary Tables to Secondary";
            this.copyPrimaryTablesToSecondaryToolStripMenuItem.Click += new System.EventHandler(this.copyPrimaryMapsToSecondaryMapsToolStripMenuItem_Click);
            // 
            // copySecondaryTablesToPrimaryToolStripMenuItem
            // 
            this.copySecondaryTablesToPrimaryToolStripMenuItem.Enabled = false;
            this.copySecondaryTablesToPrimaryToolStripMenuItem.Name = "copySecondaryTablesToPrimaryToolStripMenuItem";
            this.copySecondaryTablesToPrimaryToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.copySecondaryTablesToPrimaryToolStripMenuItem.Text = "Copy Secondary Tables to Primary";
            this.copySecondaryTablesToPrimaryToolStripMenuItem.Click += new System.EventHandler(this.copySecondaryMapsToPrimaryMapsToolStripMenuItem_Click);
            // 
            // copyScalarsToolStripMenuItem
            // 
            this.copyScalarsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rpmScalarsToolStripMenuItem,
            this.loadScalarsToolStripMenuItem});
            this.copyScalarsToolStripMenuItem.Enabled = false;
            this.copyScalarsToolStripMenuItem.Name = "copyScalarsToolStripMenuItem";
            this.copyScalarsToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.copyScalarsToolStripMenuItem.Text = "Copy Scalars";
            // 
            // rpmScalarsToolStripMenuItem
            // 
            this.rpmScalarsToolStripMenuItem.Name = "rpmScalarsToolStripMenuItem";
            this.rpmScalarsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.rpmScalarsToolStripMenuItem.Text = "Rpm Scalars";
            this.rpmScalarsToolStripMenuItem.Click += new System.EventHandler(this.rpmScalarsToolStripMenuItem_Click);
            // 
            // loadScalarsToolStripMenuItem
            // 
            this.loadScalarsToolStripMenuItem.Name = "loadScalarsToolStripMenuItem";
            this.loadScalarsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.loadScalarsToolStripMenuItem.Text = "Load Scalars";
            this.loadScalarsToolStripMenuItem.Click += new System.EventHandler(this.mapScalarsToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(250, 6);
            // 
            // increaseSelectionToolStripMenuItem
            // 
            this.increaseSelectionToolStripMenuItem.Image = global::Properties.Resources.zone__plus;
            this.increaseSelectionToolStripMenuItem.Name = "increaseSelectionToolStripMenuItem";
            this.increaseSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.increaseSelectionToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.increaseSelectionToolStripMenuItem.Text = "Increase Selection";
            this.increaseSelectionToolStripMenuItem.Click += new System.EventHandler(this.IncreaseSelectionToolStripMenuItem_Click);
            // 
            // decreaseSelectionToolStripMenuItem
            // 
            this.decreaseSelectionToolStripMenuItem.Image = global::Properties.Resources.zone__minus;
            this.decreaseSelectionToolStripMenuItem.Name = "decreaseSelectionToolStripMenuItem";
            this.decreaseSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.decreaseSelectionToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.decreaseSelectionToolStripMenuItem.Text = "Decrease Selection";
            this.decreaseSelectionToolStripMenuItem.Click += new System.EventHandler(this.DecreaseSelectionToolStripMenuItem_Click);
            // 
            // adjustSelectionToolStripMenuItem
            // 
            this.adjustSelectionToolStripMenuItem.Image = global::Properties.Resources.zone__arrow;
            this.adjustSelectionToolStripMenuItem.Name = "adjustSelectionToolStripMenuItem";
            this.adjustSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.adjustSelectionToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.adjustSelectionToolStripMenuItem.Text = "Adjust Selection";
            this.adjustSelectionToolStripMenuItem.Click += new System.EventHandler(this.AdjustSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(250, 6);
            // 
            // interpolateToolStripMenuItem
            // 
            this.interpolateToolStripMenuItem.Enabled = false;
            this.interpolateToolStripMenuItem.Image = global::Properties.Resources.table_rotate;
            this.interpolateToolStripMenuItem.Name = "interpolateToolStripMenuItem";
            this.interpolateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.interpolateToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.interpolateToolStripMenuItem.Text = "Interpolate";
            this.interpolateToolStripMenuItem.Click += new System.EventHandler(this.InterpolateToolStripMenuItem_Click);
            // 
            // interpolateHorizontallyToolStripMenuItem
            // 
            this.interpolateHorizontallyToolStripMenuItem.Enabled = false;
            this.interpolateHorizontallyToolStripMenuItem.Image = global::Properties.Resources.table_split_row;
            this.interpolateHorizontallyToolStripMenuItem.Name = "interpolateHorizontallyToolStripMenuItem";
            this.interpolateHorizontallyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.interpolateHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.interpolateHorizontallyToolStripMenuItem.Text = "Interpolate Rows";
            this.interpolateHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.InterpolateHorizontallyToolStripMenuItem_Click);
            // 
            // interpolateVerticallyToolStripMenuItem
            // 
            this.interpolateVerticallyToolStripMenuItem.Enabled = false;
            this.interpolateVerticallyToolStripMenuItem.Image = global::Properties.Resources.table_split_column;
            this.interpolateVerticallyToolStripMenuItem.Name = "interpolateVerticallyToolStripMenuItem";
            this.interpolateVerticallyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.interpolateVerticallyToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.interpolateVerticallyToolStripMenuItem.Text = "Interpolate Colomns";
            this.interpolateVerticallyToolStripMenuItem.Click += new System.EventHandler(this.InterpolateVerticallyToolStripMenuItem_Click);
            // 
            // smoothMapsToolStripMenuItem
            // 
            this.smoothMapsToolStripMenuItem.Enabled = false;
            this.smoothMapsToolStripMenuItem.Image = global::Properties.Resources.table_heatmap;
            this.smoothMapsToolStripMenuItem.Name = "smoothMapsToolStripMenuItem";
            this.smoothMapsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.smoothMapsToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.smoothMapsToolStripMenuItem.Text = "Smooth Maps";
            this.smoothMapsToolStripMenuItem.Click += new System.EventHandler(this.SmoothMapsToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLivePlotsToolStripMenuItem,
            this.clearDataToolStripMenuItem,
            this.clearRecordingToolStripMenuItem,
            this.clearMapTraceTrailToolStripMenuItem,
            this.toolStripSeparator18,
            this.ClearCELErrorsToolStripMenuItem,
            this.debugLogsToolStripMenuItem1});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // clearLivePlotsToolStripMenuItem
            // 
            this.clearLivePlotsToolStripMenuItem.Enabled = false;
            this.clearLivePlotsToolStripMenuItem.Name = "clearLivePlotsToolStripMenuItem";
            this.clearLivePlotsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearLivePlotsToolStripMenuItem.Text = "Live Plots";
            this.clearLivePlotsToolStripMenuItem.Click += new System.EventHandler(this.ClearLivePlotsToolStripMenuItem_Click);
            // 
            // clearDataToolStripMenuItem
            // 
            this.clearDataToolStripMenuItem.Enabled = false;
            this.clearDataToolStripMenuItem.Name = "clearDataToolStripMenuItem";
            this.clearDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearDataToolStripMenuItem.Text = "Datalog";
            this.clearDataToolStripMenuItem.Click += new System.EventHandler(this.ClearDataToolStripMenuItem_Click);
            // 
            // clearRecordingToolStripMenuItem
            // 
            this.clearRecordingToolStripMenuItem.Enabled = false;
            this.clearRecordingToolStripMenuItem.Name = "clearRecordingToolStripMenuItem";
            this.clearRecordingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearRecordingToolStripMenuItem.Text = "Recording";
            this.clearRecordingToolStripMenuItem.Click += new System.EventHandler(this.ClearRecordingToolStripMenuItem_Click);
            // 
            // clearMapTraceTrailToolStripMenuItem
            // 
            this.clearMapTraceTrailToolStripMenuItem.Enabled = false;
            this.clearMapTraceTrailToolStripMenuItem.Name = "clearMapTraceTrailToolStripMenuItem";
            this.clearMapTraceTrailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearMapTraceTrailToolStripMenuItem.Text = "Map Trace Trail";
            this.clearMapTraceTrailToolStripMenuItem.Click += new System.EventHandler(this.ClearMapTraceTrailToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(149, 6);
            // 
            // ClearCELErrorsToolStripMenuItem
            // 
            this.ClearCELErrorsToolStripMenuItem.Enabled = false;
            this.ClearCELErrorsToolStripMenuItem.Name = "ClearCELErrorsToolStripMenuItem";
            this.ClearCELErrorsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ClearCELErrorsToolStripMenuItem.Text = "CEL Errors";
            this.ClearCELErrorsToolStripMenuItem.Click += new System.EventHandler(this.ClearCELErrorsToolStripMenuItem_Click);
            // 
            // debugLogsToolStripMenuItem1
            // 
            this.debugLogsToolStripMenuItem1.Enabled = false;
            this.debugLogsToolStripMenuItem1.Name = "debugLogsToolStripMenuItem1";
            this.debugLogsToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.debugLogsToolStripMenuItem1.Text = "Debug Logs";
            this.debugLogsToolStripMenuItem1.Click += new System.EventHandler(this.DebugLogsToolStripMenuItem1_Click);
            // 
            // emulatorToolStripMenuItem
            // 
            this.emulatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emuConnectToolStripMenuItem,
            this.emuRealTimeUpdateToolStripMenuItem,
            this.informationsToolStripMenuItem,
            this.SerialMenuToolStripMenuItem,
            this.toolStripSeparator12,
            this.emuGetRomToolStripMenuItem,
            this.emuPutRomToolStripMenuItem,
            this.emuUploadCalToolStripMenuItem,
            this.emuVerifyRomToolStripMenuItem});
            this.emulatorToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.emulatorToolStripMenuItem.Name = "emulatorToolStripMenuItem";
            this.emulatorToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.emulatorToolStripMenuItem.Text = "Emulator";
            this.emulatorToolStripMenuItem.DropDownOpening += new System.EventHandler(this.emulatorToolStripMenuItem_DropDownOpening);
            // 
            // emuConnectToolStripMenuItem
            // 
            this.emuConnectToolStripMenuItem.Image = global::Properties.Resources.drive__plus;
            this.emuConnectToolStripMenuItem.Name = "emuConnectToolStripMenuItem";
            this.emuConnectToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.emuConnectToolStripMenuItem.Tag = "0";
            this.emuConnectToolStripMenuItem.Text = "Connect";
            this.emuConnectToolStripMenuItem.Click += new System.EventHandler(this.emuConnectToolStripMenuItem_Click);
            // 
            // emuRealTimeUpdateToolStripMenuItem
            // 
            this.emuRealTimeUpdateToolStripMenuItem.CheckOnClick = true;
            this.emuRealTimeUpdateToolStripMenuItem.Enabled = false;
            this.emuRealTimeUpdateToolStripMenuItem.Image = global::Properties.Resources.Apply;
            this.emuRealTimeUpdateToolStripMenuItem.Name = "emuRealTimeUpdateToolStripMenuItem";
            this.emuRealTimeUpdateToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.emuRealTimeUpdateToolStripMenuItem.Text = "Realtime Update";
            this.emuRealTimeUpdateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.emuRealTimeUpdateToolStripMenuItem_CheckedChanged);
            // 
            // informationsToolStripMenuItem
            // 
            this.informationsToolStripMenuItem.Image = global::Properties.Resources.Computer_16x16;
            this.informationsToolStripMenuItem.Name = "informationsToolStripMenuItem";
            this.informationsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.informationsToolStripMenuItem.Text = "Emulator Infos";
            this.informationsToolStripMenuItem.Click += new System.EventHandler(this.InformationsToolStripMenuItem_Click);
            // 
            // SerialMenuToolStripMenuItem
            // 
            this.SerialMenuToolStripMenuItem.Enabled = false;
            this.SerialMenuToolStripMenuItem.Name = "SerialMenuToolStripMenuItem";
            this.SerialMenuToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.SerialMenuToolStripMenuItem.Text = "Emulator Menu";
            this.SerialMenuToolStripMenuItem.Visible = false;
            this.SerialMenuToolStripMenuItem.Click += new System.EventHandler(this.SerialMenuToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(238, 6);
            // 
            // emuGetRomToolStripMenuItem
            // 
            this.emuGetRomToolStripMenuItem.Enabled = false;
            this.emuGetRomToolStripMenuItem.Image = global::Properties.Resources.drive_download;
            this.emuGetRomToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.emuGetRomToolStripMenuItem.Name = "emuGetRomToolStripMenuItem";
            this.emuGetRomToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.emuGetRomToolStripMenuItem.Tag = "3";
            this.emuGetRomToolStripMenuItem.Text = "Download Rom";
            this.emuGetRomToolStripMenuItem.Click += new System.EventHandler(this.emuGetRomToolStripMenuItem_Click);
            // 
            // emuPutRomToolStripMenuItem
            // 
            this.emuPutRomToolStripMenuItem.Enabled = false;
            this.emuPutRomToolStripMenuItem.Image = global::Properties.Resources.drive_upload;
            this.emuPutRomToolStripMenuItem.Name = "emuPutRomToolStripMenuItem";
            this.emuPutRomToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.emuPutRomToolStripMenuItem.Tag = "1";
            this.emuPutRomToolStripMenuItem.Text = "Upload Base Rom && Calibration";
            this.emuPutRomToolStripMenuItem.Click += new System.EventHandler(this.emuPutRomToolStripMenuItem_Click);
            // 
            // emuUploadCalToolStripMenuItem
            // 
            this.emuUploadCalToolStripMenuItem.Enabled = false;
            this.emuUploadCalToolStripMenuItem.Image = global::Properties.Resources.drive__arrow;
            this.emuUploadCalToolStripMenuItem.Name = "emuUploadCalToolStripMenuItem";
            this.emuUploadCalToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.emuUploadCalToolStripMenuItem.Tag = "2";
            this.emuUploadCalToolStripMenuItem.Text = "Upload Calibration";
            this.emuUploadCalToolStripMenuItem.Click += new System.EventHandler(this.emuUploadCalToolStripMenuItem_Click);
            // 
            // emuVerifyRomToolStripMenuItem
            // 
            this.emuVerifyRomToolStripMenuItem.Enabled = false;
            this.emuVerifyRomToolStripMenuItem.Image = global::Properties.Resources.drive_disc_blue;
            this.emuVerifyRomToolStripMenuItem.Name = "emuVerifyRomToolStripMenuItem";
            this.emuVerifyRomToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.emuVerifyRomToolStripMenuItem.Text = "Verify Rom with Emulator";
            this.emuVerifyRomToolStripMenuItem.Click += new System.EventHandler(this.verifyRomWithEmulatorToolStripMenuItem_Click);
            // 
            // datalogToolStripMenuItem
            // 
            this.datalogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dlConnectToolStripMenuItem,
            this.dlRecordToolStripMenuItem,
            this.dlSaveToolStripMenuItem,
            this.openLogAfterRecordToolStripMenuItem,
            this.dlAutoSave,
            this.dlTableToolStripMenuItem,
            this.onBoardLoggingToolStripMenuItem,
            this.toolStripSeparator10,
            this.dlOpenToolStripMenuItem,
            this.dlCloseToolStripMenuItem,
            this.dlExporttoolStripMenuItem,
            this.importTunerViewRAWToolStripMenuItem,
            this.dlCloudtoolStripMenuItem,
            this.toolStripSeparator8,
            this.playBackwardToolStripMenuItem,
            this.playToolStripMenuItem,
            this.playQuarterSpeedToolStripMenuItem,
            this.playHalfSpeedToolStripMenuItem,
            this.playDoubleSpeedToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator40,
            this.iSRV3ProtocolInfosToolStripMenuItem});
            this.datalogToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.datalogToolStripMenuItem.Name = "datalogToolStripMenuItem";
            this.datalogToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.datalogToolStripMenuItem.Text = "Datalog";
            this.datalogToolStripMenuItem.DropDownOpening += new System.EventHandler(this.datalogToolStripMenuItem_DropDownOpening);
            // 
            // dlConnectToolStripMenuItem
            // 
            this.dlConnectToolStripMenuItem.Enabled = false;
            this.dlConnectToolStripMenuItem.Image = global::Properties.Resources.dashboard__plus;
            this.dlConnectToolStripMenuItem.Name = "dlConnectToolStripMenuItem";
            this.dlConnectToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlConnectToolStripMenuItem.Text = "Start";
            this.dlConnectToolStripMenuItem.Click += new System.EventHandler(this.toolDtConnect_Click);
            // 
            // dlRecordToolStripMenuItem
            // 
            this.dlRecordToolStripMenuItem.Enabled = false;
            this.dlRecordToolStripMenuItem.Image = global::Properties.Resources.control_record;
            this.dlRecordToolStripMenuItem.Name = "dlRecordToolStripMenuItem";
            this.dlRecordToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlRecordToolStripMenuItem.Text = "Record";
            this.dlRecordToolStripMenuItem.Click += new System.EventHandler(this.toolDtRecord_Click);
            // 
            // dlSaveToolStripMenuItem
            // 
            this.dlSaveToolStripMenuItem.Enabled = false;
            this.dlSaveToolStripMenuItem.Image = global::Properties.Resources.disk__exclamation;
            this.dlSaveToolStripMenuItem.Name = "dlSaveToolStripMenuItem";
            this.dlSaveToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlSaveToolStripMenuItem.Text = "Save";
            this.dlSaveToolStripMenuItem.Click += new System.EventHandler(this.toolDtSave_Click);
            // 
            // openLogAfterRecordToolStripMenuItem
            // 
            this.openLogAfterRecordToolStripMenuItem.CheckOnClick = true;
            this.openLogAfterRecordToolStripMenuItem.Enabled = false;
            this.openLogAfterRecordToolStripMenuItem.Image = global::Properties.Resources.Notes;
            this.openLogAfterRecordToolStripMenuItem.Name = "openLogAfterRecordToolStripMenuItem";
            this.openLogAfterRecordToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.openLogAfterRecordToolStripMenuItem.Text = "Open Log after Record";
            this.openLogAfterRecordToolStripMenuItem.CheckedChanged += new System.EventHandler(this.openLogAfterRecordToolStripMenuItem_CheckedChanged);
            this.openLogAfterRecordToolStripMenuItem.Click += new System.EventHandler(this.openLogAfterRecordToolStripMenuItem_Click);
            // 
            // dlAutoSave
            // 
            this.dlAutoSave.CheckOnClick = true;
            this.dlAutoSave.Enabled = false;
            this.dlAutoSave.Image = global::Properties.Resources.How_to;
            this.dlAutoSave.Name = "dlAutoSave";
            this.dlAutoSave.Size = new System.Drawing.Size(231, 22);
            this.dlAutoSave.Text = "Auto Record";
            this.dlAutoSave.Visible = false;
            this.dlAutoSave.Click += new System.EventHandler(this.dlAutoSave_Click);
            // 
            // dlTableToolStripMenuItem
            // 
            this.dlTableToolStripMenuItem.CheckOnClick = true;
            this.dlTableToolStripMenuItem.Enabled = false;
            this.dlTableToolStripMenuItem.Image = global::Properties.Resources.Blue_pin;
            this.dlTableToolStripMenuItem.Name = "dlTableToolStripMenuItem";
            this.dlTableToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlTableToolStripMenuItem.Text = "Log Minimal Data";
            this.dlTableToolStripMenuItem.Visible = false;
            this.dlTableToolStripMenuItem.CheckedChanged += new System.EventHandler(this.dlTableToolStripMenuItem_CheckedChanged);
            this.dlTableToolStripMenuItem.Click += new System.EventHandler(this.dlTableToolStripMenuItem_Click);
            // 
            // onBoardLoggingToolStripMenuItem
            // 
            this.onBoardLoggingToolStripMenuItem.Image = global::Properties.Resources.Database;
            this.onBoardLoggingToolStripMenuItem.Name = "onBoardLoggingToolStripMenuItem";
            this.onBoardLoggingToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.onBoardLoggingToolStripMenuItem.Text = "On Board Logging";
            this.onBoardLoggingToolStripMenuItem.Click += new System.EventHandler(this.onBoardLoggingToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(228, 6);
            // 
            // dlOpenToolStripMenuItem
            // 
            this.dlOpenToolStripMenuItem.Enabled = false;
            this.dlOpenToolStripMenuItem.Image = global::Properties.Resources.folder_open_document;
            this.dlOpenToolStripMenuItem.Name = "dlOpenToolStripMenuItem";
            this.dlOpenToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlOpenToolStripMenuItem.Text = "Open Log";
            this.dlOpenToolStripMenuItem.Click += new System.EventHandler(this.toolDtOpen_Click);
            // 
            // dlCloseToolStripMenuItem
            // 
            this.dlCloseToolStripMenuItem.Enabled = false;
            this.dlCloseToolStripMenuItem.Image = global::Properties.Resources.cross_button;
            this.dlCloseToolStripMenuItem.Name = "dlCloseToolStripMenuItem";
            this.dlCloseToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlCloseToolStripMenuItem.Text = "Close Log";
            this.dlCloseToolStripMenuItem.Click += new System.EventHandler(this.toolDtClose_Click);
            // 
            // dlExporttoolStripMenuItem
            // 
            this.dlExporttoolStripMenuItem.Enabled = false;
            this.dlExporttoolStripMenuItem.Image = global::Properties.Resources.List;
            this.dlExporttoolStripMenuItem.Name = "dlExporttoolStripMenuItem";
            this.dlExporttoolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlExporttoolStripMenuItem.Text = "Export Log";
            this.dlExporttoolStripMenuItem.Click += new System.EventHandler(this.dlExporttoolStripMenuItem_Click);
            // 
            // importTunerViewRAWToolStripMenuItem
            // 
            this.importTunerViewRAWToolStripMenuItem.Image = global::Properties.Resources.Folder;
            this.importTunerViewRAWToolStripMenuItem.Name = "importTunerViewRAWToolStripMenuItem";
            this.importTunerViewRAWToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.importTunerViewRAWToolStripMenuItem.Text = "Import TunerView/RAW";
            this.importTunerViewRAWToolStripMenuItem.Visible = false;
            // 
            // dlCloudtoolStripMenuItem
            // 
            this.dlCloudtoolStripMenuItem.Image = global::Properties.Resources.Folder;
            this.dlCloudtoolStripMenuItem.Name = "dlCloudtoolStripMenuItem";
            this.dlCloudtoolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.dlCloudtoolStripMenuItem.Text = "Convert Demon Onboard Log";
            this.dlCloudtoolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(228, 6);
            // 
            // playBackwardToolStripMenuItem
            // 
            this.playBackwardToolStripMenuItem.Enabled = false;
            this.playBackwardToolStripMenuItem.Image = global::Properties.Resources.control_180;
            this.playBackwardToolStripMenuItem.Name = "playBackwardToolStripMenuItem";
            this.playBackwardToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.playBackwardToolStripMenuItem.Text = "Rewind";
            this.playBackwardToolStripMenuItem.Click += new System.EventHandler(this.toolDtPlayBack_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Enabled = false;
            this.playToolStripMenuItem.Image = global::Properties.Resources.control;
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.toolDtPlay_Click);
            // 
            // playQuarterSpeedToolStripMenuItem
            // 
            this.playQuarterSpeedToolStripMenuItem.Enabled = false;
            this.playQuarterSpeedToolStripMenuItem.Image = global::Properties.Resources.PlayQuart;
            this.playQuarterSpeedToolStripMenuItem.Name = "playQuarterSpeedToolStripMenuItem";
            this.playQuarterSpeedToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.playQuarterSpeedToolStripMenuItem.Text = "Quarter Speed";
            this.playQuarterSpeedToolStripMenuItem.Click += new System.EventHandler(this.PlayQuarterSpeedToolStripMenuItem_Click);
            // 
            // playHalfSpeedToolStripMenuItem
            // 
            this.playHalfSpeedToolStripMenuItem.Enabled = false;
            this.playHalfSpeedToolStripMenuItem.Image = global::Properties.Resources.PlayHalft;
            this.playHalfSpeedToolStripMenuItem.Name = "playHalfSpeedToolStripMenuItem";
            this.playHalfSpeedToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.playHalfSpeedToolStripMenuItem.Text = "Half Speed";
            this.playHalfSpeedToolStripMenuItem.Click += new System.EventHandler(this.PlayHalfSpeedToolStripMenuItem_Click);
            // 
            // playDoubleSpeedToolStripMenuItem
            // 
            this.playDoubleSpeedToolStripMenuItem.Enabled = false;
            this.playDoubleSpeedToolStripMenuItem.Image = global::Properties.Resources.control_double;
            this.playDoubleSpeedToolStripMenuItem.Name = "playDoubleSpeedToolStripMenuItem";
            this.playDoubleSpeedToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.playDoubleSpeedToolStripMenuItem.Text = "Double Speed";
            this.playDoubleSpeedToolStripMenuItem.Click += new System.EventHandler(this.toolDtPlayDouble_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Enabled = false;
            this.pauseToolStripMenuItem.Image = global::Properties.Resources.control_pause;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.toolDtPause_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Image = global::Properties.Resources.control_stop_square;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.toolDtStop_Click);
            // 
            // toolStripSeparator40
            // 
            this.toolStripSeparator40.Name = "toolStripSeparator40";
            this.toolStripSeparator40.Size = new System.Drawing.Size(228, 6);
            // 
            // iSRV3ProtocolInfosToolStripMenuItem
            // 
            this.iSRV3ProtocolInfosToolStripMenuItem.Name = "iSRV3ProtocolInfosToolStripMenuItem";
            this.iSRV3ProtocolInfosToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.iSRV3ProtocolInfosToolStripMenuItem.Text = "ISR V3 Protocol Infos";
            this.iSRV3ProtocolInfosToolStripMenuItem.Click += new System.EventHandler(this.iSRV3ProtocolInfosToolStripMenuItem_Click);
            // 
            // dynoToolStripMenuItem
            // 
            this.dynoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.toolStripSeparator1,
            this.setupToolStripMenuItem});
            this.dynoToolStripMenuItem.Name = "dynoToolStripMenuItem";
            this.dynoToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.dynoToolStripMenuItem.Text = "Dyno";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = global::Properties.Resources.Delivery;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.Enabled = false;
            this.controlToolStripMenuItem.Image = global::Properties.Resources.drive_disc_blue;
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.controlToolStripMenuItem.Text = "Control";
            this.controlToolStripMenuItem.Click += new System.EventHandler(this.ControlToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Image = global::Properties.Resources.Tune;
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.SetupToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primaryLowIgnitionToolStripMenuItem,
            this.primaryHighIgnitionToolStripMenuItem,
            this.primaryLowFuelToolStripMenuItem,
            this.primaryHighFuelToolStripMenuItem,
            this.toolStripSeparator24,
            this.primaryTablesToolStripMenuItem,
            this.secondaryTablesToolStripMenuItem,
            this.toolStripSeparator23,
            this.mapValuesToolStripMenuItem,
            this.aFTargetToolStripMenuItem1,
            this.aFToolStripMenuItem,
            this.fuelDifferenceToolStripMenuItem,
            this.vETablesToolStripMenuItem1,
            this.toolStripSeparator22,
            this.FuelRawToolStripMenuItem,
            this.FuelDutyToolStripMenuItem,
            this.fuelInjDurToolStripMenuItem,
            this.toolStripSeparator21,
            this.analog1Reading_Button,
            this.analog2Reading_Button,
            this.analog3Reading_Button,
            this.toolStripSeparator5,
            this.dynoTractionToolStripMenuItem,
            this.dynoHPToolStripMenuItem,
            this.dynoNMToolStripMenuItem,
            this.dynoAUX1ToolStripMenuItem,
            this.dynoAUX2ToolStripMenuItem,
            this.dynoAUX3ToolStripMenuItem,
            this.dynoTHCToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // primaryLowIgnitionToolStripMenuItem
            // 
            this.primaryLowIgnitionToolStripMenuItem.CheckOnClick = true;
            this.primaryLowIgnitionToolStripMenuItem.Image = global::Properties.Resources.Lightning1;
            this.primaryLowIgnitionToolStripMenuItem.Name = "primaryLowIgnitionToolStripMenuItem";
            this.primaryLowIgnitionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.primaryLowIgnitionToolStripMenuItem.Text = "Low Ignition";
            this.primaryLowIgnitionToolStripMenuItem.Click += new System.EventHandler(this.PrimaryLowIgnitionToolStripMenuItem_Click);
            // 
            // primaryHighIgnitionToolStripMenuItem
            // 
            this.primaryHighIgnitionToolStripMenuItem.CheckOnClick = true;
            this.primaryHighIgnitionToolStripMenuItem.Image = global::Properties.Resources.Lightning2;
            this.primaryHighIgnitionToolStripMenuItem.Name = "primaryHighIgnitionToolStripMenuItem";
            this.primaryHighIgnitionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.primaryHighIgnitionToolStripMenuItem.Text = "High Ignition";
            this.primaryHighIgnitionToolStripMenuItem.Click += new System.EventHandler(this.PrimaryHighIgnitionToolStripMenuItem_Click);
            // 
            // primaryLowFuelToolStripMenuItem
            // 
            this.primaryLowFuelToolStripMenuItem.CheckOnClick = true;
            this.primaryLowFuelToolStripMenuItem.Image = global::Properties.Resources.injector1;
            this.primaryLowFuelToolStripMenuItem.Name = "primaryLowFuelToolStripMenuItem";
            this.primaryLowFuelToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.primaryLowFuelToolStripMenuItem.Text = "Low Fuel";
            this.primaryLowFuelToolStripMenuItem.Click += new System.EventHandler(this.PrimaryLowFuelToolStripMenuItem_Click);
            // 
            // primaryHighFuelToolStripMenuItem
            // 
            this.primaryHighFuelToolStripMenuItem.CheckOnClick = true;
            this.primaryHighFuelToolStripMenuItem.Image = global::Properties.Resources.injector2;
            this.primaryHighFuelToolStripMenuItem.Name = "primaryHighFuelToolStripMenuItem";
            this.primaryHighFuelToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.primaryHighFuelToolStripMenuItem.Text = "High Fuel";
            this.primaryHighFuelToolStripMenuItem.Click += new System.EventHandler(this.PrimaryHighFuelToolStripMenuItem_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(185, 6);
            // 
            // primaryTablesToolStripMenuItem
            // 
            this.primaryTablesToolStripMenuItem.CheckOnClick = true;
            this.primaryTablesToolStripMenuItem.Image = global::Properties.Resources.Map1;
            this.primaryTablesToolStripMenuItem.Name = "primaryTablesToolStripMenuItem";
            this.primaryTablesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.primaryTablesToolStripMenuItem.Text = "Primary Tables";
            this.primaryTablesToolStripMenuItem.Click += new System.EventHandler(this.PrimaryTablesToolStripMenuItem_Click);
            // 
            // secondaryTablesToolStripMenuItem
            // 
            this.secondaryTablesToolStripMenuItem.CheckOnClick = true;
            this.secondaryTablesToolStripMenuItem.Image = global::Properties.Resources.Map2;
            this.secondaryTablesToolStripMenuItem.Name = "secondaryTablesToolStripMenuItem";
            this.secondaryTablesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.secondaryTablesToolStripMenuItem.Text = "Secondary Tables";
            this.secondaryTablesToolStripMenuItem.Click += new System.EventHandler(this.SecondaryTablesToolStripMenuItem_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(185, 6);
            // 
            // mapValuesToolStripMenuItem
            // 
            this.mapValuesToolStripMenuItem.Checked = true;
            this.mapValuesToolStripMenuItem.CheckOnClick = true;
            this.mapValuesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapValuesToolStripMenuItem.Image = global::Properties.Resources._3d_bar_chart;
            this.mapValuesToolStripMenuItem.Name = "mapValuesToolStripMenuItem";
            this.mapValuesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mapValuesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.mapValuesToolStripMenuItem.Text = "Map Values";
            this.mapValuesToolStripMenuItem.Click += new System.EventHandler(this.mapValuesToolStripMenuItem_Click);
            // 
            // aFTargetToolStripMenuItem1
            // 
            this.aFTargetToolStripMenuItem1.CheckOnClick = true;
            this.aFTargetToolStripMenuItem1.Image = global::Properties.Resources.AFTarget;
            this.aFTargetToolStripMenuItem1.Name = "aFTargetToolStripMenuItem1";
            this.aFTargetToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.aFTargetToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.aFTargetToolStripMenuItem1.Text = "A/F Target";
            this.aFTargetToolStripMenuItem1.Click += new System.EventHandler(this.aFTargetToolStripMenuItem1_Click);
            // 
            // aFToolStripMenuItem
            // 
            this.aFToolStripMenuItem.CheckOnClick = true;
            this.aFToolStripMenuItem.Image = global::Properties.Resources.AFReading;
            this.aFToolStripMenuItem.Name = "aFToolStripMenuItem";
            this.aFToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.aFToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aFToolStripMenuItem.Text = "A/F Reading";
            this.aFToolStripMenuItem.Click += new System.EventHandler(this.aFToolStripMenuItem_Click);
            // 
            // fuelDifferenceToolStripMenuItem
            // 
            this.fuelDifferenceToolStripMenuItem.CheckOnClick = true;
            this.fuelDifferenceToolStripMenuItem.Image = global::Properties.Resources.AFDiff;
            this.fuelDifferenceToolStripMenuItem.Name = "fuelDifferenceToolStripMenuItem";
            this.fuelDifferenceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.fuelDifferenceToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.fuelDifferenceToolStripMenuItem.Text = "Fuel Difference";
            this.fuelDifferenceToolStripMenuItem.Click += new System.EventHandler(this.fuelDifferenceToolStripMenuItem_Click);
            // 
            // vETablesToolStripMenuItem1
            // 
            this.vETablesToolStripMenuItem1.CheckOnClick = true;
            this.vETablesToolStripMenuItem1.Image = global::Properties.Resources.table_VE;
            this.vETablesToolStripMenuItem1.Name = "vETablesToolStripMenuItem1";
            this.vETablesToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.vETablesToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.vETablesToolStripMenuItem1.Text = "VE Tables";
            this.vETablesToolStripMenuItem1.Click += new System.EventHandler(this.vETablesToolStripMenuItem1_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(185, 6);
            // 
            // FuelRawToolStripMenuItem
            // 
            this.FuelRawToolStripMenuItem.Checked = true;
            this.FuelRawToolStripMenuItem.CheckOnClick = true;
            this.FuelRawToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FuelRawToolStripMenuItem.Name = "FuelRawToolStripMenuItem";
            this.FuelRawToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.FuelRawToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.FuelRawToolStripMenuItem.Tag = "0";
            this.FuelRawToolStripMenuItem.Text = "Fuel Raw Value";
            this.FuelRawToolStripMenuItem.ToolTipText = "Show raw fuel values in fuel tables";
            this.FuelRawToolStripMenuItem.Click += new System.EventHandler(this.FuelDuty_Click);
            // 
            // FuelDutyToolStripMenuItem
            // 
            this.FuelDutyToolStripMenuItem.CheckOnClick = true;
            this.FuelDutyToolStripMenuItem.Name = "FuelDutyToolStripMenuItem";
            this.FuelDutyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.FuelDutyToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.FuelDutyToolStripMenuItem.Tag = "2";
            this.FuelDutyToolStripMenuItem.Text = "Fuel Duty Cycle";
            this.FuelDutyToolStripMenuItem.ToolTipText = "Show estimade duty cycle in fuel table";
            this.FuelDutyToolStripMenuItem.Click += new System.EventHandler(this.InjDuty_Click);
            // 
            // fuelInjDurToolStripMenuItem
            // 
            this.fuelInjDurToolStripMenuItem.CheckOnClick = true;
            this.fuelInjDurToolStripMenuItem.Name = "fuelInjDurToolStripMenuItem";
            this.fuelInjDurToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.fuelInjDurToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.fuelInjDurToolStripMenuItem.Tag = "1";
            this.fuelInjDurToolStripMenuItem.Text = "Injector Duration";
            this.fuelInjDurToolStripMenuItem.ToolTipText = "Show injector duration in fuel tables";
            this.fuelInjDurToolStripMenuItem.Click += new System.EventHandler(this.InjDurr_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(185, 6);
            // 
            // analog1Reading_Button
            // 
            this.analog1Reading_Button.CheckOnClick = true;
            this.analog1Reading_Button.Name = "analog1Reading_Button";
            this.analog1Reading_Button.Size = new System.Drawing.Size(188, 22);
            this.analog1Reading_Button.Text = "Analog1 Reading";
            this.analog1Reading_Button.Click += new System.EventHandler(this.analog1Reading_Click);
            // 
            // analog2Reading_Button
            // 
            this.analog2Reading_Button.CheckOnClick = true;
            this.analog2Reading_Button.Name = "analog2Reading_Button";
            this.analog2Reading_Button.Size = new System.Drawing.Size(188, 22);
            this.analog2Reading_Button.Text = "Analog2 Reading";
            this.analog2Reading_Button.Click += new System.EventHandler(this.analog2Reading_Click);
            // 
            // analog3Reading_Button
            // 
            this.analog3Reading_Button.CheckOnClick = true;
            this.analog3Reading_Button.Name = "analog3Reading_Button";
            this.analog3Reading_Button.Size = new System.Drawing.Size(188, 22);
            this.analog3Reading_Button.Text = "Analog3 Reading";
            this.analog3Reading_Button.Click += new System.EventHandler(this.analog3Reading_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(185, 6);
            // 
            // dynoTractionToolStripMenuItem
            // 
            this.dynoTractionToolStripMenuItem.Name = "dynoTractionToolStripMenuItem";
            this.dynoTractionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.dynoTractionToolStripMenuItem.Text = "Dyno Traction";
            this.dynoTractionToolStripMenuItem.Click += new System.EventHandler(this.DynoTractionToolStripMenuItem_Click);
            // 
            // dynoHPToolStripMenuItem
            // 
            this.dynoHPToolStripMenuItem.Name = "dynoHPToolStripMenuItem";
            this.dynoHPToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.dynoHPToolStripMenuItem.Text = "Dyno HP";
            this.dynoHPToolStripMenuItem.Click += new System.EventHandler(this.DynoHPToolStripMenuItem_Click);
            // 
            // dynoNMToolStripMenuItem
            // 
            this.dynoNMToolStripMenuItem.Name = "dynoNMToolStripMenuItem";
            this.dynoNMToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.dynoNMToolStripMenuItem.Text = "Dyno NM";
            this.dynoNMToolStripMenuItem.Click += new System.EventHandler(this.DynoNMToolStripMenuItem_Click);
            // 
            // dynoAUX1ToolStripMenuItem
            // 
            this.dynoAUX1ToolStripMenuItem.Name = "dynoAUX1ToolStripMenuItem";
            this.dynoAUX1ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.dynoAUX1ToolStripMenuItem.Text = "Dyno AUX1";
            this.dynoAUX1ToolStripMenuItem.Click += new System.EventHandler(this.DynoAUX1ToolStripMenuItem_Click);
            // 
            // dynoAUX2ToolStripMenuItem
            // 
            this.dynoAUX2ToolStripMenuItem.Name = "dynoAUX2ToolStripMenuItem";
            this.dynoAUX2ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.dynoAUX2ToolStripMenuItem.Text = "Dyno AUX2";
            this.dynoAUX2ToolStripMenuItem.Click += new System.EventHandler(this.DynoAUX2ToolStripMenuItem_Click);
            // 
            // dynoAUX3ToolStripMenuItem
            // 
            this.dynoAUX3ToolStripMenuItem.Name = "dynoAUX3ToolStripMenuItem";
            this.dynoAUX3ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.dynoAUX3ToolStripMenuItem.Text = "Dyno AUX3";
            this.dynoAUX3ToolStripMenuItem.Click += new System.EventHandler(this.DynoAUX3ToolStripMenuItem_Click);
            // 
            // dynoTHCToolStripMenuItem
            // 
            this.dynoTHCToolStripMenuItem.Name = "dynoTHCToolStripMenuItem";
            this.dynoTHCToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.dynoTHCToolStripMenuItem.Text = "Dyno THC";
            this.dynoTHCToolStripMenuItem.Click += new System.EventHandler(this.DynoTHCToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametersToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.errorToolStripMenuItem,
            this.debugLogsToolStripMenuItem,
            this.snapshotToolStripMenuItem,
            this.livePlotsToolStripMenuItem,
            this.activeDatalogsThreadsToolStripMenuItem,
            this.toolStripSeparator2,
            this.sensorsToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.graphsToolStripMenuItem,
            this.toolStripSeparator11,
            this.fileToolbarVisibleToolStripMenuItem,
            this.editToolbarToolStripMenuItem,
            this.emulatorToolbarToolStripMenuItem,
            this.datalogToolbartoolStripMenuItem,
            this.viewToolbarToolStripMenuItem,
            this.toolsToolbarToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            this.windowsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolsToolStripMenuItem_DropDownOpening);
            // 
            // parametersToolStripMenuItem
            // 
            this.parametersToolStripMenuItem.Image = global::Properties.Resources.Application;
            this.parametersToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.parametersToolStripMenuItem.Name = "parametersToolStripMenuItem";
            this.parametersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.parametersToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.parametersToolStripMenuItem.Text = "Parameters";
            this.parametersToolStripMenuItem.Click += new System.EventHandler(this.parametersToolStripButton_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.Image = global::Properties.Resources.Table;
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.tablesToolStripMenuItem.Text = "Tables";
            this.tablesToolStripMenuItem.Click += new System.EventHandler(this.tablesToolStripButton_Click);
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.Image = global::Properties.Resources.Error;
            this.errorToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.errorToolStripMenuItem.Text = "Error codes";
            this.errorToolStripMenuItem.Click += new System.EventHandler(this.errorToolStripButton_Click);
            // 
            // debugLogsToolStripMenuItem
            // 
            this.debugLogsToolStripMenuItem.Image = global::Properties.Resources.Warning;
            this.debugLogsToolStripMenuItem.Name = "debugLogsToolStripMenuItem";
            this.debugLogsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.debugLogsToolStripMenuItem.Text = "Debug Logs";
            this.debugLogsToolStripMenuItem.Click += new System.EventHandler(this.debugLogsToolStripMenuItem_Click);
            // 
            // snapshotToolStripMenuItem
            // 
            this.snapshotToolStripMenuItem.Enabled = false;
            this.snapshotToolStripMenuItem.Image = global::Properties.Resources.Notes;
            this.snapshotToolStripMenuItem.Name = "snapshotToolStripMenuItem";
            this.snapshotToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.snapshotToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.snapshotToolStripMenuItem.Text = "Snapshot List";
            this.snapshotToolStripMenuItem.Click += new System.EventHandler(this.snapshotToolStripMenuItem_Click);
            // 
            // livePlotsToolStripMenuItem
            // 
            this.livePlotsToolStripMenuItem.Image = global::Properties.Resources.Brush;
            this.livePlotsToolStripMenuItem.Name = "livePlotsToolStripMenuItem";
            this.livePlotsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.livePlotsToolStripMenuItem.Text = "Live Plots";
            this.livePlotsToolStripMenuItem.Click += new System.EventHandler(this.livePlotsToolStripMenuItem_Click);
            // 
            // activeDatalogsThreadsToolStripMenuItem
            // 
            this.activeDatalogsThreadsToolStripMenuItem.Image = global::Properties.Resources.Script1;
            this.activeDatalogsThreadsToolStripMenuItem.Name = "activeDatalogsThreadsToolStripMenuItem";
            this.activeDatalogsThreadsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.activeDatalogsThreadsToolStripMenuItem.Text = "Active Datalogs Threads";
            this.activeDatalogsThreadsToolStripMenuItem.Click += new System.EventHandler(this.ActiveDatalogsThreadsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // sensorsToolStripMenuItem
            // 
            this.sensorsToolStripMenuItem.Image = global::Properties.Resources.Hard_disk;
            this.sensorsToolStripMenuItem.Name = "sensorsToolStripMenuItem";
            this.sensorsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.sensorsToolStripMenuItem.Text = "Sensors";
            this.sensorsToolStripMenuItem.Click += new System.EventHandler(this.sensorToolStripButton_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Image = global::Properties.Resources.Display_16x16;
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.displayToolStripMenuItem.Text = "Display";
            this.displayToolStripMenuItem.Click += new System.EventHandler(this.displayToolStripButton_Click);
            // 
            // graphsToolStripMenuItem
            // 
            this.graphsToolStripMenuItem.Image = global::Properties.Resources.graph_16;
            this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            this.graphsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.graphsToolStripMenuItem.Text = "Graph";
            this.graphsToolStripMenuItem.Click += new System.EventHandler(this.graphsToolStripButton_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(197, 6);
            // 
            // fileToolbarVisibleToolStripMenuItem
            // 
            this.fileToolbarVisibleToolStripMenuItem.CheckOnClick = true;
            this.fileToolbarVisibleToolStripMenuItem.Name = "fileToolbarVisibleToolStripMenuItem";
            this.fileToolbarVisibleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.fileToolbarVisibleToolStripMenuItem.Text = "File Toolbar";
            this.fileToolbarVisibleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.fileToolbarVisibleToolStripMenuItem_CheckedChanged);
            // 
            // editToolbarToolStripMenuItem
            // 
            this.editToolbarToolStripMenuItem.CheckOnClick = true;
            this.editToolbarToolStripMenuItem.Name = "editToolbarToolStripMenuItem";
            this.editToolbarToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.editToolbarToolStripMenuItem.Text = "Edit Toolbar";
            this.editToolbarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.editToolbarToolStripMenuItem_CheckedChanged);
            // 
            // emulatorToolbarToolStripMenuItem
            // 
            this.emulatorToolbarToolStripMenuItem.CheckOnClick = true;
            this.emulatorToolbarToolStripMenuItem.Name = "emulatorToolbarToolStripMenuItem";
            this.emulatorToolbarToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.emulatorToolbarToolStripMenuItem.Text = "Emulator Toolbar";
            this.emulatorToolbarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.emulatorToolbarToolStripMenuItem_CheckedChanged);
            // 
            // datalogToolbartoolStripMenuItem
            // 
            this.datalogToolbartoolStripMenuItem.CheckOnClick = true;
            this.datalogToolbartoolStripMenuItem.Name = "datalogToolbartoolStripMenuItem";
            this.datalogToolbartoolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.datalogToolbartoolStripMenuItem.Text = "Datalog Toolbar";
            this.datalogToolbartoolStripMenuItem.CheckedChanged += new System.EventHandler(this.datalogToolbartoolStripMenuItem_CheckedChanged);
            // 
            // viewToolbarToolStripMenuItem
            // 
            this.viewToolbarToolStripMenuItem.CheckOnClick = true;
            this.viewToolbarToolStripMenuItem.Name = "viewToolbarToolStripMenuItem";
            this.viewToolbarToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.viewToolbarToolStripMenuItem.Text = "View Toolbar";
            this.viewToolbarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.viewToolbarToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolbarToolStripMenuItem
            // 
            this.toolsToolbarToolStripMenuItem.CheckOnClick = true;
            this.toolsToolbarToolStripMenuItem.Name = "toolsToolbarToolStripMenuItem";
            this.toolsToolbarToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.toolsToolbarToolStripMenuItem.Text = "Tools Toolbar";
            this.toolsToolbarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.toolsToolbarToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tPSCalibrationToolStripMenuItem,
            this.injectorCalibrationToolStripMenuItem,
            this.ignitionSyncToolStripMenuItem,
            this.gearLearningToolStripMenuItem,
            this.toolStripSeparator20,
            this.bstTablesToolStripMenuItem,
            this.scalarSetupToolStripMenuItem,
            this.toolStripSeparator19,
            this.windowedModeToolStripMenuItem,
            this.baseromConverterToolStripMenuItem,
            this.consoleToolStripMenuItem,
            this.toolStripSeparator6,
            this.converterToolStripMenuItem,
            this.bluetoothProgrammerToolStripMenuItem,
            this.bMBurnerChipBurningToolToolStripMenuItem,
            this.bMDevsFirmwareUpdaterToolStripMenuItem,
            this.bMDataloggerLCDDisplayToolStripMenuItem,
            this.moatesDemonOstrichResetToolStripMenuItem,
            this.moatesFlashBurnToolStripMenuItem,
            this.OBD2ScanStripMenuItem,
            this.serialMonitorToolStripMenuItem,
            this.cOMPortHelperToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.ToolsToolStripMenuItem_DropDownOpening_1);
            // 
            // tPSCalibrationToolStripMenuItem
            // 
            this.tPSCalibrationToolStripMenuItem.Enabled = false;
            this.tPSCalibrationToolStripMenuItem.Name = "tPSCalibrationToolStripMenuItem";
            this.tPSCalibrationToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.tPSCalibrationToolStripMenuItem.Text = "TPS Calibration";
            this.tPSCalibrationToolStripMenuItem.Click += new System.EventHandler(this.TPSCalibrationToolStripMenuItem_Click);
            // 
            // injectorCalibrationToolStripMenuItem
            // 
            this.injectorCalibrationToolStripMenuItem.Enabled = false;
            this.injectorCalibrationToolStripMenuItem.Name = "injectorCalibrationToolStripMenuItem";
            this.injectorCalibrationToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.injectorCalibrationToolStripMenuItem.Text = "Injector Calibration";
            this.injectorCalibrationToolStripMenuItem.Click += new System.EventHandler(this.InjectorCalibrationToolStripMenuItem_Click);
            // 
            // ignitionSyncToolStripMenuItem
            // 
            this.ignitionSyncToolStripMenuItem.Enabled = false;
            this.ignitionSyncToolStripMenuItem.Name = "ignitionSyncToolStripMenuItem";
            this.ignitionSyncToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.ignitionSyncToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.ignitionSyncToolStripMenuItem.Text = "Ignition Calibration";
            this.ignitionSyncToolStripMenuItem.Click += new System.EventHandler(this.ignitionSyncToolStripMenuItem_Click);
            // 
            // gearLearningToolStripMenuItem
            // 
            this.gearLearningToolStripMenuItem.Enabled = false;
            this.gearLearningToolStripMenuItem.Name = "gearLearningToolStripMenuItem";
            this.gearLearningToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.gearLearningToolStripMenuItem.Text = "Gear Calibration";
            this.gearLearningToolStripMenuItem.Click += new System.EventHandler(this.GearLearningToolStripMenuItem_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(230, 6);
            // 
            // bstTablesToolStripMenuItem
            // 
            this.bstTablesToolStripMenuItem.Enabled = false;
            this.bstTablesToolStripMenuItem.Name = "bstTablesToolStripMenuItem";
            this.bstTablesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.bstTablesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bstTablesToolStripMenuItem.Text = "Boost Table";
            this.bstTablesToolStripMenuItem.Click += new System.EventHandler(this.bstTablesToolStripMenuItem_Click);
            // 
            // scalarSetupToolStripMenuItem
            // 
            this.scalarSetupToolStripMenuItem.Enabled = false;
            this.scalarSetupToolStripMenuItem.Name = "scalarSetupToolStripMenuItem";
            this.scalarSetupToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.scalarSetupToolStripMenuItem.Text = "Scalar Setup";
            this.scalarSetupToolStripMenuItem.Click += new System.EventHandler(this.scalarSetupToolStripMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(230, 6);
            // 
            // windowedModeToolStripMenuItem
            // 
            this.windowedModeToolStripMenuItem.CheckOnClick = true;
            this.windowedModeToolStripMenuItem.Name = "windowedModeToolStripMenuItem";
            this.windowedModeToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.windowedModeToolStripMenuItem.Text = "Windowed Mode";
            this.windowedModeToolStripMenuItem.ToolTipText = "Switch between Docked or Windows Mode Style";
            this.windowedModeToolStripMenuItem.Click += new System.EventHandler(this.WindowedModeToolStripMenuItem_Click);
            // 
            // baseromConverterToolStripMenuItem
            // 
            this.baseromConverterToolStripMenuItem.Enabled = false;
            this.baseromConverterToolStripMenuItem.Name = "baseromConverterToolStripMenuItem";
            this.baseromConverterToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.baseromConverterToolStripMenuItem.Text = "Baserom Converter";
            this.baseromConverterToolStripMenuItem.Click += new System.EventHandler(this.baseromConverterToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(230, 6);
            // 
            // converterToolStripMenuItem
            // 
            this.converterToolStripMenuItem.Name = "converterToolStripMenuItem";
            this.converterToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.converterToolStripMenuItem.Text = "Converter (Extra Tool)";
            this.converterToolStripMenuItem.Visible = false;
            this.converterToolStripMenuItem.Click += new System.EventHandler(this.converterToolStripMenuItem_Click);
            // 
            // bluetoothProgrammerToolStripMenuItem
            // 
            this.bluetoothProgrammerToolStripMenuItem.Name = "bluetoothProgrammerToolStripMenuItem";
            this.bluetoothProgrammerToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bluetoothProgrammerToolStripMenuItem.Text = "Bluetooth Programmer";
            this.bluetoothProgrammerToolStripMenuItem.Click += new System.EventHandler(this.BluetoothProgrammerToolStripMenuItem_Click);
            // 
            // bMBurnerChipBurningToolToolStripMenuItem
            // 
            this.bMBurnerChipBurningToolToolStripMenuItem.Name = "bMBurnerChipBurningToolToolStripMenuItem";
            this.bMBurnerChipBurningToolToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bMBurnerChipBurningToolToolStripMenuItem.Text = "BMBurner (Chip Burning Tool)";
            this.bMBurnerChipBurningToolToolStripMenuItem.Visible = false;
            this.bMBurnerChipBurningToolToolStripMenuItem.Click += new System.EventHandler(this.bMBurnerChipBurningToolToolStripMenuItem_Click);
            // 
            // bMDevsFirmwareUpdaterToolStripMenuItem
            // 
            this.bMDevsFirmwareUpdaterToolStripMenuItem.Name = "bMDevsFirmwareUpdaterToolStripMenuItem";
            this.bMDevsFirmwareUpdaterToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bMDevsFirmwareUpdaterToolStripMenuItem.Text = "BMDevsFirmwareUpdater";
            this.bMDevsFirmwareUpdaterToolStripMenuItem.Visible = false;
            this.bMDevsFirmwareUpdaterToolStripMenuItem.Click += new System.EventHandler(this.bMDevsFirmwareUpdaterToolStripMenuItem_Click);
            // 
            // bMDataloggerLCDDisplayToolStripMenuItem
            // 
            this.bMDataloggerLCDDisplayToolStripMenuItem.Name = "bMDataloggerLCDDisplayToolStripMenuItem";
            this.bMDataloggerLCDDisplayToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bMDataloggerLCDDisplayToolStripMenuItem.Text = "BMDatalogger (LCD Display)";
            this.bMDataloggerLCDDisplayToolStripMenuItem.Visible = false;
            this.bMDataloggerLCDDisplayToolStripMenuItem.Click += new System.EventHandler(this.bMDataloggerLCDDisplayToolStripMenuItem_Click);
            // 
            // moatesDemonOstrichResetToolStripMenuItem
            // 
            this.moatesDemonOstrichResetToolStripMenuItem.Name = "moatesDemonOstrichResetToolStripMenuItem";
            this.moatesDemonOstrichResetToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.moatesDemonOstrichResetToolStripMenuItem.Text = "Moates DemonOstrich Reset";
            this.moatesDemonOstrichResetToolStripMenuItem.Visible = false;
            this.moatesDemonOstrichResetToolStripMenuItem.Click += new System.EventHandler(this.moatesDemonOstrichResetToolStripMenuItem_Click);
            // 
            // moatesFlashBurnToolStripMenuItem
            // 
            this.moatesFlashBurnToolStripMenuItem.Name = "moatesFlashBurnToolStripMenuItem";
            this.moatesFlashBurnToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.moatesFlashBurnToolStripMenuItem.Text = "Moates Flash&&Burn";
            this.moatesFlashBurnToolStripMenuItem.Visible = false;
            this.moatesFlashBurnToolStripMenuItem.Click += new System.EventHandler(this.moatesFlashBurnToolStripMenuItem_Click);
            // 
            // OBD2ScanStripMenuItem
            // 
            this.OBD2ScanStripMenuItem.Name = "OBD2ScanStripMenuItem";
            this.OBD2ScanStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.OBD2ScanStripMenuItem.Text = "OBD2 ScanTool";
            this.OBD2ScanStripMenuItem.Visible = false;
            this.OBD2ScanStripMenuItem.Click += new System.EventHandler(this.OBD2ScanStripMenuItem_Click);
            // 
            // serialMonitorToolStripMenuItem
            // 
            this.serialMonitorToolStripMenuItem.Name = "serialMonitorToolStripMenuItem";
            this.serialMonitorToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.serialMonitorToolStripMenuItem.Text = "Serial Monitor";
            this.serialMonitorToolStripMenuItem.Visible = false;
            this.serialMonitorToolStripMenuItem.Click += new System.EventHandler(this.serialMonitorToolStripMenuItem_Click);
            // 
            // cOMPortHelperToolStripMenuItem
            // 
            this.cOMPortHelperToolStripMenuItem.Name = "cOMPortHelperToolStripMenuItem";
            this.cOMPortHelperToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.cOMPortHelperToolStripMenuItem.Text = "COM Port Helper";
            this.cOMPortHelperToolStripMenuItem.Click += new System.EventHandler(this.cOMPortHelperToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killInjectorsToolStripMenuItem,
            this.fuelPumpToolStripMenuItem,
            this.useHighCamsMapsOnlyToolStripMenuItem,
            this.useSecondaryMapsOnlyToolStripMenuItem,
            this.toolStripSeparator25,
            this.toolTunerFollowVtec,
            this.toolTunerFollowDualTables,
            this.toolTunerMapTrail,
            this.toolTunerSmartTrack,
            this.toolStripSeparator41,
            this.testECUOutputsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.OptionsToolStripMenuItem_DropDownOpening);
            // 
            // killInjectorsToolStripMenuItem
            // 
            this.killInjectorsToolStripMenuItem.CheckOnClick = true;
            this.killInjectorsToolStripMenuItem.Enabled = false;
            this.killInjectorsToolStripMenuItem.Name = "killInjectorsToolStripMenuItem";
            this.killInjectorsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.killInjectorsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.killInjectorsToolStripMenuItem.Text = "Kill Injector";
            this.killInjectorsToolStripMenuItem.Click += new System.EventHandler(this.killInjectorsToolStripMenuItem_Click);
            // 
            // fuelPumpToolStripMenuItem
            // 
            this.fuelPumpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offToolStripMenuItem,
            this.onDrainTankToolStripMenuItem});
            this.fuelPumpToolStripMenuItem.Enabled = false;
            this.fuelPumpToolStripMenuItem.Name = "fuelPumpToolStripMenuItem";
            this.fuelPumpToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.fuelPumpToolStripMenuItem.Text = "Fuel Pump";
            // 
            // offToolStripMenuItem
            // 
            this.offToolStripMenuItem.CheckOnClick = true;
            this.offToolStripMenuItem.Name = "offToolStripMenuItem";
            this.offToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.offToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.offToolStripMenuItem.Text = "Off";
            this.offToolStripMenuItem.Click += new System.EventHandler(this.OffToolStripMenuItem_Click);
            // 
            // onDrainTankToolStripMenuItem
            // 
            this.onDrainTankToolStripMenuItem.CheckOnClick = true;
            this.onDrainTankToolStripMenuItem.Name = "onDrainTankToolStripMenuItem";
            this.onDrainTankToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.onDrainTankToolStripMenuItem.Text = "On (Drain tank)";
            this.onDrainTankToolStripMenuItem.Click += new System.EventHandler(this.drainFPtoolStripMenuItem_Click);
            // 
            // useHighCamsMapsOnlyToolStripMenuItem
            // 
            this.useHighCamsMapsOnlyToolStripMenuItem.CheckOnClick = true;
            this.useHighCamsMapsOnlyToolStripMenuItem.Name = "useHighCamsMapsOnlyToolStripMenuItem";
            this.useHighCamsMapsOnlyToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.useHighCamsMapsOnlyToolStripMenuItem.Text = "High Cams Maps Only";
            this.useHighCamsMapsOnlyToolStripMenuItem.ToolTipText = "Use the High Cams maps only";
            this.useHighCamsMapsOnlyToolStripMenuItem.Click += new System.EventHandler(this.useHighCamToolStripMenuItem_Click);
            // 
            // useSecondaryMapsOnlyToolStripMenuItem
            // 
            this.useSecondaryMapsOnlyToolStripMenuItem.CheckOnClick = true;
            this.useSecondaryMapsOnlyToolStripMenuItem.Name = "useSecondaryMapsOnlyToolStripMenuItem";
            this.useSecondaryMapsOnlyToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.useSecondaryMapsOnlyToolStripMenuItem.Text = "Secondary Tables Only";
            this.useSecondaryMapsOnlyToolStripMenuItem.ToolTipText = "Use the Secondary tables only";
            this.useSecondaryMapsOnlyToolStripMenuItem.Click += new System.EventHandler(this.useSecMapsToolStripMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(234, 6);
            // 
            // toolTunerFollowVtec
            // 
            this.toolTunerFollowVtec.CheckOnClick = true;
            this.toolTunerFollowVtec.Name = "toolTunerFollowVtec";
            this.toolTunerFollowVtec.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.toolTunerFollowVtec.Size = new System.Drawing.Size(237, 22);
            this.toolTunerFollowVtec.Text = "Follow Vtec";
            this.toolTunerFollowVtec.ToolTipText = "Follow Vtec when map tracing";
            this.toolTunerFollowVtec.Click += new System.EventHandler(this.followVtecToolStripMenuItem_Click);
            // 
            // toolTunerFollowDualTables
            // 
            this.toolTunerFollowDualTables.CheckOnClick = true;
            this.toolTunerFollowDualTables.Name = "toolTunerFollowDualTables";
            this.toolTunerFollowDualTables.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.toolTunerFollowDualTables.Size = new System.Drawing.Size(237, 22);
            this.toolTunerFollowDualTables.Text = "Follow Secondary Maps";
            this.toolTunerFollowDualTables.ToolTipText = "Follow Secondary maps switching when map tracing";
            this.toolTunerFollowDualTables.Click += new System.EventHandler(this.followSecondaryMenuItem_Click);
            // 
            // toolTunerMapTrail
            // 
            this.toolTunerMapTrail.CheckOnClick = true;
            this.toolTunerMapTrail.Name = "toolTunerMapTrail";
            this.toolTunerMapTrail.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.toolTunerMapTrail.Size = new System.Drawing.Size(237, 22);
            this.toolTunerMapTrail.Text = "Map Trace Trail";
            this.toolTunerMapTrail.ToolTipText = "Map Trace Trail";
            this.toolTunerMapTrail.Click += new System.EventHandler(this.MapTraceToolStripMenuItem_Click);
            // 
            // toolTunerSmartTrack
            // 
            this.toolTunerSmartTrack.CheckOnClick = true;
            this.toolTunerSmartTrack.Name = "toolTunerSmartTrack";
            this.toolTunerSmartTrack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.toolTunerSmartTrack.Size = new System.Drawing.Size(237, 22);
            this.toolTunerSmartTrack.Text = "Smart Tracking";
            this.toolTunerSmartTrack.ToolTipText = "Smart track map trace cells";
            this.toolTunerSmartTrack.Click += new System.EventHandler(this.ToolTunerSmartTrack_Click);
            // 
            // toolStripSeparator41
            // 
            this.toolStripSeparator41.Name = "toolStripSeparator41";
            this.toolStripSeparator41.Size = new System.Drawing.Size(234, 6);
            this.toolStripSeparator41.Visible = false;
            // 
            // testECUOutputsToolStripMenuItem
            // 
            this.testECUOutputsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vTSToolStripMenuItem,
            this.fuelPumpToolStripMenuItem1,
            this.a10ToolStripMenuItem,
            this.aCToolStripMenuItem,
            this.pCSToolStripMenuItem,
            this.iABToolStripMenuItem,
            this.fANCToolStripMenuItem,
            this.aLTCToolStripMenuItem});
            this.testECUOutputsToolStripMenuItem.Name = "testECUOutputsToolStripMenuItem";
            this.testECUOutputsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.testECUOutputsToolStripMenuItem.Text = "Test ECU Outputs";
            this.testECUOutputsToolStripMenuItem.Visible = false;
            // 
            // vTSToolStripMenuItem
            // 
            this.vTSToolStripMenuItem.CheckOnClick = true;
            this.vTSToolStripMenuItem.Name = "vTSToolStripMenuItem";
            this.vTSToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.vTSToolStripMenuItem.Text = "VTS";
            this.vTSToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // fuelPumpToolStripMenuItem1
            // 
            this.fuelPumpToolStripMenuItem1.CheckOnClick = true;
            this.fuelPumpToolStripMenuItem1.Name = "fuelPumpToolStripMenuItem1";
            this.fuelPumpToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.fuelPumpToolStripMenuItem1.Text = "Fuel Pump";
            this.fuelPumpToolStripMenuItem1.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // a10ToolStripMenuItem
            // 
            this.a10ToolStripMenuItem.CheckOnClick = true;
            this.a10ToolStripMenuItem.Name = "a10ToolStripMenuItem";
            this.a10ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.a10ToolStripMenuItem.Text = "A10";
            this.a10ToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // aCToolStripMenuItem
            // 
            this.aCToolStripMenuItem.CheckOnClick = true;
            this.aCToolStripMenuItem.Name = "aCToolStripMenuItem";
            this.aCToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aCToolStripMenuItem.Text = "AC";
            this.aCToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // pCSToolStripMenuItem
            // 
            this.pCSToolStripMenuItem.CheckOnClick = true;
            this.pCSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertToolStripMenuItem});
            this.pCSToolStripMenuItem.Name = "pCSToolStripMenuItem";
            this.pCSToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.pCSToolStripMenuItem.Text = "PCS";
            this.pCSToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.CheckOnClick = true;
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // iABToolStripMenuItem
            // 
            this.iABToolStripMenuItem.CheckOnClick = true;
            this.iABToolStripMenuItem.Name = "iABToolStripMenuItem";
            this.iABToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.iABToolStripMenuItem.Text = "IAB";
            this.iABToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // fANCToolStripMenuItem
            // 
            this.fANCToolStripMenuItem.CheckOnClick = true;
            this.fANCToolStripMenuItem.Name = "fANCToolStripMenuItem";
            this.fANCToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.fANCToolStripMenuItem.Text = "FANC";
            this.fANCToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // aLTCToolStripMenuItem
            // 
            this.aLTCToolStripMenuItem.CheckOnClick = true;
            this.aLTCToolStripMenuItem.Name = "aLTCToolStripMenuItem";
            this.aLTCToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aLTCToolStripMenuItem.Text = "ALTC";
            this.aLTCToolStripMenuItem.Click += new System.EventHandler(this.vTSToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shortcutKeysToolStripMenuItem,
            this.registerToolStripMenuItem1,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutBMTuneToolStripMenuItem,
            this.editLimitsWarningsToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.reinstallLastStableReleaseToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.benchmarkToolToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "More";
            // 
            // shortcutKeysToolStripMenuItem
            // 
            this.shortcutKeysToolStripMenuItem.Image = global::Properties.Resources.Calendar;
            this.shortcutKeysToolStripMenuItem.Name = "shortcutKeysToolStripMenuItem";
            this.shortcutKeysToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.shortcutKeysToolStripMenuItem.Text = "Shortcut Keys";
            this.shortcutKeysToolStripMenuItem.Click += new System.EventHandler(this.shortcutKeysToolStripMenuItem_Click_1);
            // 
            // registerToolStripMenuItem1
            // 
            this.registerToolStripMenuItem1.Image = global::Properties.Resources.Key;
            this.registerToolStripMenuItem1.Name = "registerToolStripMenuItem1";
            this.registerToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.registerToolStripMenuItem1.Text = "Register";
            this.registerToolStripMenuItem1.Visible = false;
            this.registerToolStripMenuItem1.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Image = global::Properties.Resources.Earth;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Visible = false;
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // aboutBMTuneToolStripMenuItem
            // 
            this.aboutBMTuneToolStripMenuItem.Image = global::Properties.Resources.About;
            this.aboutBMTuneToolStripMenuItem.Name = "aboutBMTuneToolStripMenuItem";
            this.aboutBMTuneToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.aboutBMTuneToolStripMenuItem.Text = "About BMTune";
            this.aboutBMTuneToolStripMenuItem.Click += new System.EventHandler(this.aboutBMTuneToolStripMenuItem_Click);
            // 
            // editLimitsWarningsToolStripMenuItem
            // 
            this.editLimitsWarningsToolStripMenuItem.Image = global::Properties.Resources.Abort;
            this.editLimitsWarningsToolStripMenuItem.Name = "editLimitsWarningsToolStripMenuItem";
            this.editLimitsWarningsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.editLimitsWarningsToolStripMenuItem.Text = "Edit Limits/Warnings";
            this.editLimitsWarningsToolStripMenuItem.ToolTipText = "Edit Sensors Min/Max Limit and Warnings";
            this.editLimitsWarningsToolStripMenuItem.Click += new System.EventHandler(this.SensorWarning_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Image = global::Properties.Resources.Dollar;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.DonateToolStripMenuItem_Click);
            // 
            // reinstallLastStableReleaseToolStripMenuItem
            // 
            this.reinstallLastStableReleaseToolStripMenuItem.Image = global::Properties.Resources.Repair;
            this.reinstallLastStableReleaseToolStripMenuItem.Name = "reinstallLastStableReleaseToolStripMenuItem";
            this.reinstallLastStableReleaseToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.reinstallLastStableReleaseToolStripMenuItem.Text = "Reinstall Last Stable Release";
            this.reinstallLastStableReleaseToolStripMenuItem.Visible = false;
            this.reinstallLastStableReleaseToolStripMenuItem.Click += new System.EventHandler(this.ReinstallLastStableReleaseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = global::Properties.Resources.Help_symbol;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // benchmarkToolToolStripMenuItem
            // 
            this.benchmarkToolToolStripMenuItem.Image = global::Properties.Resources.Apply;
            this.benchmarkToolToolStripMenuItem.Name = "benchmarkToolToolStripMenuItem";
            this.benchmarkToolToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.benchmarkToolToolStripMenuItem.Text = "Benchmark Tool";
            this.benchmarkToolToolStripMenuItem.Click += new System.EventHandler(this.benchmarkToolToolStripMenuItem_Click);
            // 
            // flashToolStripMenuItem
            // 
            this.flashToolStripMenuItem.Name = "flashToolStripMenuItem";
            this.flashToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.flashToolStripMenuItem.Text = "K-Flash";
            this.flashToolStripMenuItem.Visible = false;
            this.flashToolStripMenuItem.Click += new System.EventHandler(this.flashToolStripMenuItem_Click);
            // 
            // toolStripPanelTop
            // 
            this.toolStripPanelTop.Controls.Add(this.mdiMenuStrip);
            this.toolStripPanelTop.Controls.Add(this.mainToolStrip);
            this.toolStripPanelTop.Controls.Add(this.editToolStrip);
            this.toolStripPanelTop.Controls.Add(this.emulatorToolStrip);
            this.toolStripPanelTop.Controls.Add(this.dataloggingToolStrip);
            this.toolStripPanelTop.Controls.Add(this.viewToolStrip);
            this.toolStripPanelTop.Controls.Add(this.windowsToolStrip);
            this.toolStripPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanelTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanelTop.Name = "toolStripPanelTop";
            this.toolStripPanelTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanelTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripPanelTop.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanelTop.Size = new System.Drawing.Size(868, 99);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.AllowDrop = true;
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewFile,
            this.toolStripButtonOpenFile,
            this.toolStripDropDownLastFile,
            this.toolStripButtonSave,
            this.toolStripButtonSaveAs,
            this.toolStripButtonSaveSnapshot,
            this.toolStripButtonUploadFile,
            this.toolStripButtonCloseFile});
            this.mainToolStrip.Location = new System.Drawing.Point(4, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainToolStrip.Size = new System.Drawing.Size(202, 25);
            this.mainToolStrip.TabIndex = 4;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonNewFile
            // 
            this.toolStripButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewFile.Image = global::Properties.Resources.New_document;
            this.toolStripButtonNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewFile.Name = "toolStripButtonNewFile";
            this.toolStripButtonNewFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewFile.Text = "toolStripButton1";
            this.toolStripButtonNewFile.ToolTipText = "Create new baserom";
            this.toolStripButtonNewFile.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // toolStripButtonOpenFile
            // 
            this.toolStripButtonOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenFile.Image = global::Properties.Resources.Folder;
            this.toolStripButtonOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenFile.Name = "toolStripButtonOpenFile";
            this.toolStripButtonOpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenFile.Text = "toolStripButton2";
            this.toolStripButtonOpenFile.ToolTipText = "Open File";
            this.toolStripButtonOpenFile.Click += new System.EventHandler(this.openToolStripButton_ButtonClick);
            // 
            // toolStripDropDownLastFile
            // 
            this.toolStripDropDownLastFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownLastFile.Enabled = false;
            this.toolStripDropDownLastFile.Image = global::Properties.Resources.folder_open_document;
            this.toolStripDropDownLastFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownLastFile.Name = "toolStripDropDownLastFile";
            this.toolStripDropDownLastFile.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownLastFile.Text = "toolStripDropDownButton1";
            this.toolStripDropDownLastFile.ToolTipText = "Open recently";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = global::Properties.Resources.Save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "toolStripButton4";
            this.toolStripButtonSave.ToolTipText = "Save File";
            this.toolStripButtonSave.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveAs.Enabled = false;
            this.toolStripButtonSaveAs.Image = global::Properties.Resources.SaveAs;
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveAs.Text = "toolStripButton5";
            this.toolStripButtonSaveAs.ToolTipText = "Save File As";
            this.toolStripButtonSaveAs.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripButtonSaveSnapshot
            // 
            this.toolStripButtonSaveSnapshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveSnapshot.Enabled = false;
            this.toolStripButtonSaveSnapshot.Image = global::Properties.Resources.Movie;
            this.toolStripButtonSaveSnapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveSnapshot.Name = "toolStripButtonSaveSnapshot";
            this.toolStripButtonSaveSnapshot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveSnapshot.Text = "toolStripButton6";
            this.toolStripButtonSaveSnapshot.ToolTipText = "Save Snapshot";
            this.toolStripButtonSaveSnapshot.Click += new System.EventHandler(this.saveQuickToolStripMenuItem_Click);
            // 
            // toolStripButtonUploadFile
            // 
            this.toolStripButtonUploadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUploadFile.Enabled = false;
            this.toolStripButtonUploadFile.Image = global::Properties.Resources.Update;
            this.toolStripButtonUploadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUploadFile.Name = "toolStripButtonUploadFile";
            this.toolStripButtonUploadFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUploadFile.Text = "toolStripButton7";
            this.toolStripButtonUploadFile.ToolTipText = "Upload File to BMTune server";
            this.toolStripButtonUploadFile.Click += new System.EventHandler(this.uploadBaseromOnlineToolStripMenuItem_Click);
            // 
            // toolStripButtonCloseFile
            // 
            this.toolStripButtonCloseFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCloseFile.Enabled = false;
            this.toolStripButtonCloseFile.Image = global::Properties.Resources.Erase;
            this.toolStripButtonCloseFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCloseFile.Name = "toolStripButtonCloseFile";
            this.toolStripButtonCloseFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCloseFile.Text = "toolStripButton8";
            this.toolStripButtonCloseFile.ToolTipText = "Close File";
            this.toolStripButtonCloseFile.Click += new System.EventHandler(this.closeRomToolStripMenuItem_Click);
            // 
            // editToolStrip
            // 
            this.editToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.editToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripDropDown,
            this.redoToolStripDropDown,
            this.toolStripButtonUndoHistory,
            this.toolStripSeparator49,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator31,
            this.toolStripButtonIncSelection,
            this.toolStripButtonDecSelection,
            this.toolStripButtonAdjustSelection,
            this.toolStripSeparator32,
            this.toolStripButtonInterpolate,
            this.toolStripButtonInterpolateRow,
            this.toolStripButtonInterpolateColomn,
            this.toolStripButtonSmoothMap});
            this.editToolStrip.Location = new System.Drawing.Point(220, 24);
            this.editToolStrip.Name = "editToolStrip";
            this.editToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.editToolStrip.Size = new System.Drawing.Size(324, 25);
            this.editToolStrip.TabIndex = 5;
            this.editToolStrip.Text = "Main Tool Strip";
            // 
            // undoToolStripDropDown
            // 
            this.undoToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripDropDown.Enabled = false;
            this.undoToolStripDropDown.Image = global::Properties.Resources.Undo;
            this.undoToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripDropDown.Name = "undoToolStripDropDown";
            this.undoToolStripDropDown.Size = new System.Drawing.Size(32, 22);
            this.undoToolStripDropDown.ToolTipText = "Undo an operation or view undo history";
            this.undoToolStripDropDown.ButtonClick += new System.EventHandler(this.undoToolStripDorpDown_ButtonClick);
            this.undoToolStripDropDown.DropDownOpening += new System.EventHandler(this.undoToolStripDorpDown_DropDownOpening);
            // 
            // redoToolStripDropDown
            // 
            this.redoToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoToolStripDropDown.Enabled = false;
            this.redoToolStripDropDown.Image = global::Properties.Resources.Redo;
            this.redoToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoToolStripDropDown.Name = "redoToolStripDropDown";
            this.redoToolStripDropDown.Size = new System.Drawing.Size(32, 22);
            this.redoToolStripDropDown.ToolTipText = "Redo an operation or view redo history";
            this.redoToolStripDropDown.ButtonClick += new System.EventHandler(this.redoToolStripDorpDown_ButtonClick);
            this.redoToolStripDropDown.DropDownOpening += new System.EventHandler(this.redoToolStripDorpDown_DropDownOpening);
            // 
            // toolStripButtonUndoHistory
            // 
            this.toolStripButtonUndoHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndoHistory.Enabled = false;
            this.toolStripButtonUndoHistory.Image = global::Properties.Resources.History;
            this.toolStripButtonUndoHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndoHistory.Name = "toolStripButtonUndoHistory";
            this.toolStripButtonUndoHistory.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUndoHistory.Text = "toolStripButton3";
            this.toolStripButtonUndoHistory.ToolTipText = "Undo all operations";
            this.toolStripButtonUndoHistory.Click += new System.EventHandler(this.ToolStripButtonUndoHistory_Click);
            // 
            // toolStripSeparator49
            // 
            this.toolStripSeparator49.Name = "toolStripSeparator49";
            this.toolStripSeparator49.Size = new System.Drawing.Size(6, 25);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Enabled = false;
            this.copyToolStripButton.Image = global::Properties.Resources.Copy;
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Enabled = false;
            this.pasteToolStripButton.Image = global::Properties.Resources.Paste;
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonIncSelection
            // 
            this.toolStripButtonIncSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncSelection.Image = global::Properties.Resources.zone__plus;
            this.toolStripButtonIncSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncSelection.Name = "toolStripButtonIncSelection";
            this.toolStripButtonIncSelection.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonIncSelection.Text = "toolStripButton16";
            this.toolStripButtonIncSelection.ToolTipText = "Increase Selection";
            this.toolStripButtonIncSelection.Click += new System.EventHandler(this.IncreaseSelectionToolStripMenuItem_Click);
            // 
            // toolStripButtonDecSelection
            // 
            this.toolStripButtonDecSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecSelection.Image = global::Properties.Resources.zone__minus;
            this.toolStripButtonDecSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecSelection.Name = "toolStripButtonDecSelection";
            this.toolStripButtonDecSelection.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDecSelection.Text = "toolStripButton17";
            this.toolStripButtonDecSelection.ToolTipText = "Decrease Selection";
            this.toolStripButtonDecSelection.Click += new System.EventHandler(this.DecreaseSelectionToolStripMenuItem_Click);
            // 
            // toolStripButtonAdjustSelection
            // 
            this.toolStripButtonAdjustSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdjustSelection.Image = global::Properties.Resources.zone__arrow;
            this.toolStripButtonAdjustSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdjustSelection.Name = "toolStripButtonAdjustSelection";
            this.toolStripButtonAdjustSelection.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdjustSelection.Text = "toolStripButton18";
            this.toolStripButtonAdjustSelection.ToolTipText = "Adjust Selection";
            this.toolStripButtonAdjustSelection.Click += new System.EventHandler(this.AdjustSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonInterpolate
            // 
            this.toolStripButtonInterpolate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInterpolate.Enabled = false;
            this.toolStripButtonInterpolate.Image = global::Properties.Resources.table_rotate;
            this.toolStripButtonInterpolate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInterpolate.Name = "toolStripButtonInterpolate";
            this.toolStripButtonInterpolate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonInterpolate.Text = "toolStripButton19";
            this.toolStripButtonInterpolate.ToolTipText = "Interpolate";
            this.toolStripButtonInterpolate.Click += new System.EventHandler(this.InterpolateToolStripMenuItem_Click);
            // 
            // toolStripButtonInterpolateRow
            // 
            this.toolStripButtonInterpolateRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInterpolateRow.Enabled = false;
            this.toolStripButtonInterpolateRow.Image = global::Properties.Resources.table_split_row;
            this.toolStripButtonInterpolateRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInterpolateRow.Name = "toolStripButtonInterpolateRow";
            this.toolStripButtonInterpolateRow.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonInterpolateRow.Text = "toolStripButton20";
            this.toolStripButtonInterpolateRow.ToolTipText = "Interpolate rows";
            this.toolStripButtonInterpolateRow.Click += new System.EventHandler(this.InterpolateHorizontallyToolStripMenuItem_Click);
            // 
            // toolStripButtonInterpolateColomn
            // 
            this.toolStripButtonInterpolateColomn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInterpolateColomn.Enabled = false;
            this.toolStripButtonInterpolateColomn.Image = global::Properties.Resources.table_split_column;
            this.toolStripButtonInterpolateColomn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInterpolateColomn.Name = "toolStripButtonInterpolateColomn";
            this.toolStripButtonInterpolateColomn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonInterpolateColomn.Text = "toolStripButton21";
            this.toolStripButtonInterpolateColomn.ToolTipText = "Interpolate Columns";
            this.toolStripButtonInterpolateColomn.Click += new System.EventHandler(this.InterpolateVerticallyToolStripMenuItem_Click);
            // 
            // toolStripButtonSmoothMap
            // 
            this.toolStripButtonSmoothMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSmoothMap.Enabled = false;
            this.toolStripButtonSmoothMap.Image = global::Properties.Resources.table_heatmap;
            this.toolStripButtonSmoothMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSmoothMap.Name = "toolStripButtonSmoothMap";
            this.toolStripButtonSmoothMap.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSmoothMap.Text = "toolStripButton22";
            this.toolStripButtonSmoothMap.ToolTipText = "Smooth Map";
            this.toolStripButtonSmoothMap.Click += new System.EventHandler(this.SmoothMapsToolStripMenuItem_Click);
            // 
            // emulatorToolStrip
            // 
            this.emulatorToolStrip.AllowDrop = true;
            this.emulatorToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.emulatorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonEmuConnect,
            this.toolStripButtonEmuDownload,
            this.toolStripButtonEmuUploadAll,
            this.toolStripButtonEmuUploadCal,
            this.toolStripButtonEmuRealtime,
            this.toolStripButtonEmuInfos});
            this.emulatorToolStrip.Location = new System.Drawing.Point(4, 49);
            this.emulatorToolStrip.Name = "emulatorToolStrip";
            this.emulatorToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.emulatorToolStrip.Size = new System.Drawing.Size(150, 25);
            this.emulatorToolStrip.TabIndex = 5;
            this.emulatorToolStrip.Text = "toolStrip2";
            // 
            // toolStripButtonEmuConnect
            // 
            this.toolStripButtonEmuConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmuConnect.Image = global::Properties.Resources.drive__plus;
            this.toolStripButtonEmuConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmuConnect.Name = "toolStripButtonEmuConnect";
            this.toolStripButtonEmuConnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEmuConnect.Tag = "0";
            this.toolStripButtonEmuConnect.Text = "toolStripButton9";
            this.toolStripButtonEmuConnect.ToolTipText = "Connect/Disconnect Emulator";
            this.toolStripButtonEmuConnect.Click += new System.EventHandler(this.emuConnectToolStripMenuItem_Click);
            // 
            // toolStripButtonEmuDownload
            // 
            this.toolStripButtonEmuDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmuDownload.Enabled = false;
            this.toolStripButtonEmuDownload.Image = global::Properties.Resources.drive_download;
            this.toolStripButtonEmuDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmuDownload.Name = "toolStripButtonEmuDownload";
            this.toolStripButtonEmuDownload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEmuDownload.Text = "toolStripButton11";
            this.toolStripButtonEmuDownload.ToolTipText = "Download content from emulator";
            this.toolStripButtonEmuDownload.Click += new System.EventHandler(this.emuGetRomToolStripMenuItem_Click);
            // 
            // toolStripButtonEmuUploadAll
            // 
            this.toolStripButtonEmuUploadAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmuUploadAll.Enabled = false;
            this.toolStripButtonEmuUploadAll.Image = global::Properties.Resources.drive_upload;
            this.toolStripButtonEmuUploadAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmuUploadAll.Name = "toolStripButtonEmuUploadAll";
            this.toolStripButtonEmuUploadAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEmuUploadAll.Text = "toolStripButton12";
            this.toolStripButtonEmuUploadAll.ToolTipText = "Upload Baserom+Calibration to the emulator";
            this.toolStripButtonEmuUploadAll.Click += new System.EventHandler(this.emuPutRomToolStripMenuItem_Click);
            // 
            // toolStripButtonEmuUploadCal
            // 
            this.toolStripButtonEmuUploadCal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmuUploadCal.Enabled = false;
            this.toolStripButtonEmuUploadCal.Image = global::Properties.Resources.drive__arrow;
            this.toolStripButtonEmuUploadCal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmuUploadCal.Name = "toolStripButtonEmuUploadCal";
            this.toolStripButtonEmuUploadCal.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEmuUploadCal.Text = "toolStripButton13";
            this.toolStripButtonEmuUploadCal.ToolTipText = "Upload Calibration Only to the emulator";
            this.toolStripButtonEmuUploadCal.Click += new System.EventHandler(this.emuUploadCalToolStripMenuItem_Click);
            // 
            // toolStripButtonEmuRealtime
            // 
            this.toolStripButtonEmuRealtime.CheckOnClick = true;
            this.toolStripButtonEmuRealtime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmuRealtime.Enabled = false;
            this.toolStripButtonEmuRealtime.Image = global::Properties.Resources.Apply;
            this.toolStripButtonEmuRealtime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmuRealtime.Name = "toolStripButtonEmuRealtime";
            this.toolStripButtonEmuRealtime.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEmuRealtime.Text = "toolStripButton15";
            this.toolStripButtonEmuRealtime.ToolTipText = "Enable/Disable Realtime update on the emulator";
            this.toolStripButtonEmuRealtime.Click += new System.EventHandler(this.emuRealTimeUpdateToolStripMenuItem_CheckedChanged);
            // 
            // toolStripButtonEmuInfos
            // 
            this.toolStripButtonEmuInfos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmuInfos.Image = global::Properties.Resources.Computer_16x16;
            this.toolStripButtonEmuInfos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmuInfos.Name = "toolStripButtonEmuInfos";
            this.toolStripButtonEmuInfos.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEmuInfos.Text = "toolStripButton14";
            this.toolStripButtonEmuInfos.ToolTipText = "Emulator Infos";
            this.toolStripButtonEmuInfos.Click += new System.EventHandler(this.InformationsToolStripMenuItem_Click);
            // 
            // dataloggingToolStrip
            // 
            this.dataloggingToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.dataloggingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDtConnect,
            this.toolDtRecord,
            this.toolDtSave,
            this.toolDtOpen,
            this.toolDtClose,
            this.toolStripSeparator50,
            this.toolDtAutoSave,
            this.toolDtPeakMax,
            this.toolDtPeakClear,
            this.toolStripSeparator51,
            this.toolDtPlayBack,
            this.toolDtPlay,
            this.toolDtQuart,
            this.toolDtHalf,
            this.toolDtForward,
            this.toolDtPause,
            this.toolDtStop,
            this.dtToolStripSeparator2});
            this.dataloggingToolStrip.Location = new System.Drawing.Point(227, 49);
            this.dataloggingToolStrip.Name = "dataloggingToolStrip";
            this.dataloggingToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.dataloggingToolStrip.Size = new System.Drawing.Size(306, 25);
            this.dataloggingToolStrip.TabIndex = 6;
            // 
            // toolDtConnect
            // 
            this.toolDtConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtConnect.Enabled = false;
            this.toolDtConnect.Image = global::Properties.Resources.dashboard__plus;
            this.toolDtConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtConnect.Name = "toolDtConnect";
            this.toolDtConnect.Size = new System.Drawing.Size(23, 22);
            this.toolDtConnect.Text = "Connect to ECU";
            this.toolDtConnect.ToolTipText = "Connect to ECU/Datalog";
            this.toolDtConnect.Click += new System.EventHandler(this.toolDtConnect_Click);
            // 
            // toolDtRecord
            // 
            this.toolDtRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtRecord.Enabled = false;
            this.toolDtRecord.Image = global::Properties.Resources.control_record;
            this.toolDtRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtRecord.Name = "toolDtRecord";
            this.toolDtRecord.Size = new System.Drawing.Size(23, 22);
            this.toolDtRecord.Text = "Record datalog";
            this.toolDtRecord.Click += new System.EventHandler(this.toolDtRec_Click);
            // 
            // toolDtSave
            // 
            this.toolDtSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtSave.Enabled = false;
            this.toolDtSave.Image = global::Properties.Resources.disk__exclamation;
            this.toolDtSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtSave.Name = "toolDtSave";
            this.toolDtSave.Size = new System.Drawing.Size(23, 22);
            this.toolDtSave.Text = "Save recording";
            this.toolDtSave.ToolTipText = "Save recorded datalog";
            this.toolDtSave.Click += new System.EventHandler(this.toolDtSave_Click);
            // 
            // toolDtOpen
            // 
            this.toolDtOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtOpen.Enabled = false;
            this.toolDtOpen.Image = global::Properties.Resources.folder_open_document;
            this.toolDtOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtOpen.Name = "toolDtOpen";
            this.toolDtOpen.Size = new System.Drawing.Size(23, 22);
            this.toolDtOpen.Text = "Open log file";
            this.toolDtOpen.ToolTipText = "Open datalog file";
            this.toolDtOpen.Click += new System.EventHandler(this.toolDtOpen_Click);
            // 
            // toolDtClose
            // 
            this.toolDtClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtClose.Enabled = false;
            this.toolDtClose.Image = global::Properties.Resources.cross_button;
            this.toolDtClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtClose.Name = "toolDtClose";
            this.toolDtClose.Size = new System.Drawing.Size(23, 22);
            this.toolDtClose.Text = "Close log file";
            this.toolDtClose.ToolTipText = "Close datalog file";
            this.toolDtClose.Click += new System.EventHandler(this.toolDtClose_Click);
            // 
            // toolStripSeparator50
            // 
            this.toolStripSeparator50.Name = "toolStripSeparator50";
            this.toolStripSeparator50.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDtAutoSave
            // 
            this.toolDtAutoSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtAutoSave.Enabled = false;
            this.toolDtAutoSave.Image = global::Properties.Resources.How_to;
            this.toolDtAutoSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtAutoSave.Name = "toolDtAutoSave";
            this.toolDtAutoSave.Size = new System.Drawing.Size(23, 22);
            this.toolDtAutoSave.Text = "Datalog Auto Save ";
            this.toolDtAutoSave.ToolTipText = "Autosave datalog with conditions";
            this.toolDtAutoSave.Visible = false;
            // 
            // toolDtPeakMax
            // 
            this.toolDtPeakMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtPeakMax.Enabled = false;
            this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090;
            this.toolDtPeakMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtPeakMax.Name = "toolDtPeakMax";
            this.toolDtPeakMax.Size = new System.Drawing.Size(23, 22);
            this.toolDtPeakMax.Text = "Datalogging Peak";
            this.toolDtPeakMax.Click += new System.EventHandler(this.toolDtPeakMax_Click);
            // 
            // toolDtPeakClear
            // 
            this.toolDtPeakClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtPeakClear.Enabled = false;
            this.toolDtPeakClear.Image = global::Properties.Resources.Fall;
            this.toolDtPeakClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtPeakClear.Name = "toolDtPeakClear";
            this.toolDtPeakClear.Size = new System.Drawing.Size(23, 22);
            this.toolDtPeakClear.Text = "Datalogging Peak Clear";
            this.toolDtPeakClear.Click += new System.EventHandler(this.toolDtPeakClear_Click);
            // 
            // toolStripSeparator51
            // 
            this.toolStripSeparator51.Name = "toolStripSeparator51";
            this.toolStripSeparator51.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDtPlayBack
            // 
            this.toolDtPlayBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtPlayBack.Enabled = false;
            this.toolDtPlayBack.Image = global::Properties.Resources.control_180;
            this.toolDtPlayBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtPlayBack.Name = "toolDtPlayBack";
            this.toolDtPlayBack.Size = new System.Drawing.Size(23, 22);
            this.toolDtPlayBack.Text = "Play log file backwards";
            this.toolDtPlayBack.ToolTipText = "Play datalog file backward";
            this.toolDtPlayBack.Click += new System.EventHandler(this.toolDtPlayBack_Click);
            // 
            // toolDtPlay
            // 
            this.toolDtPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtPlay.Enabled = false;
            this.toolDtPlay.Image = global::Properties.Resources.control;
            this.toolDtPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtPlay.Name = "toolDtPlay";
            this.toolDtPlay.Size = new System.Drawing.Size(23, 22);
            this.toolDtPlay.Text = "Play log file";
            this.toolDtPlay.ToolTipText = "Play datalog file";
            this.toolDtPlay.Click += new System.EventHandler(this.toolDtPlay_Click);
            // 
            // toolDtQuart
            // 
            this.toolDtQuart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtQuart.Enabled = false;
            this.toolDtQuart.Image = global::Properties.Resources.PlayQuart;
            this.toolDtQuart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtQuart.Name = "toolDtQuart";
            this.toolDtQuart.Size = new System.Drawing.Size(23, 22);
            this.toolDtQuart.Text = "toolStripButton1";
            this.toolDtQuart.Visible = false;
            this.toolDtQuart.Click += new System.EventHandler(this.PlayQuarterSpeedToolStripMenuItem_Click);
            // 
            // toolDtHalf
            // 
            this.toolDtHalf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtHalf.Enabled = false;
            this.toolDtHalf.Image = global::Properties.Resources.PlayHalft;
            this.toolDtHalf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtHalf.Name = "toolDtHalf";
            this.toolDtHalf.Size = new System.Drawing.Size(23, 22);
            this.toolDtHalf.Text = "toolStripButton1";
            this.toolDtHalf.Visible = false;
            this.toolDtHalf.Click += new System.EventHandler(this.PlayHalfSpeedToolStripMenuItem_Click);
            // 
            // toolDtForward
            // 
            this.toolDtForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtForward.Enabled = false;
            this.toolDtForward.Image = global::Properties.Resources.control_double;
            this.toolDtForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtForward.Name = "toolDtForward";
            this.toolDtForward.Size = new System.Drawing.Size(23, 22);
            this.toolDtForward.Text = "Play speed double";
            this.toolDtForward.ToolTipText = "Play datalog file at speed double";
            this.toolDtForward.Click += new System.EventHandler(this.toolDtPlayDouble_Click);
            // 
            // toolDtPause
            // 
            this.toolDtPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtPause.Enabled = false;
            this.toolDtPause.Image = global::Properties.Resources.control_pause;
            this.toolDtPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtPause.Name = "toolDtPause";
            this.toolDtPause.Size = new System.Drawing.Size(23, 22);
            this.toolDtPause.Text = "Pause log file";
            this.toolDtPause.ToolTipText = "Pause the datalog file";
            this.toolDtPause.Click += new System.EventHandler(this.toolDtPause_Click);
            // 
            // toolDtStop
            // 
            this.toolDtStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDtStop.Enabled = false;
            this.toolDtStop.Image = global::Properties.Resources.control_stop_square;
            this.toolDtStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDtStop.Name = "toolDtStop";
            this.toolDtStop.Size = new System.Drawing.Size(23, 22);
            this.toolDtStop.Text = "Stop playing log file";
            this.toolDtStop.ToolTipText = "Stop playing the datalog file";
            this.toolDtStop.Click += new System.EventHandler(this.toolDtStop_Click);
            // 
            // dtToolStripSeparator2
            // 
            this.dtToolStripSeparator2.Name = "dtToolStripSeparator2";
            this.dtToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLowIgn,
            this.toolStripButtonHighIgn,
            this.toolStripButtonLowFuel,
            this.toolStripButtonHighFuel,
            this.toolStripSeparator33,
            this.toolStripButtonPrimary,
            this.toolStripButtonSecondary,
            this.toolStripSeparator34,
            this.toolStripButtonMapValues,
            this.toolStripButtonAFTarget,
            this.toolStripButtonAFReading,
            this.toolStripButtonAFDiff});
            this.viewToolStrip.Location = new System.Drawing.Point(4, 74);
            this.viewToolStrip.Name = "viewToolStrip";
            this.viewToolStrip.Size = new System.Drawing.Size(254, 25);
            this.viewToolStrip.TabIndex = 13;
            this.viewToolStrip.Text = "toolStrip3";
            // 
            // toolStripButtonLowIgn
            // 
            this.toolStripButtonLowIgn.CheckOnClick = true;
            this.toolStripButtonLowIgn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLowIgn.Image = global::Properties.Resources.Lightning1;
            this.toolStripButtonLowIgn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLowIgn.Name = "toolStripButtonLowIgn";
            this.toolStripButtonLowIgn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLowIgn.Text = "toolStripButton25";
            this.toolStripButtonLowIgn.ToolTipText = "Low Cams Ignition";
            this.toolStripButtonLowIgn.Click += new System.EventHandler(this.PrimaryLowIgnitionToolStripMenuItem_Click);
            // 
            // toolStripButtonHighIgn
            // 
            this.toolStripButtonHighIgn.CheckOnClick = true;
            this.toolStripButtonHighIgn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHighIgn.Image = global::Properties.Resources.Lightning2;
            this.toolStripButtonHighIgn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHighIgn.Name = "toolStripButtonHighIgn";
            this.toolStripButtonHighIgn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHighIgn.Text = "toolStripButton26";
            this.toolStripButtonHighIgn.ToolTipText = "High Cams Ignition";
            this.toolStripButtonHighIgn.Click += new System.EventHandler(this.PrimaryHighIgnitionToolStripMenuItem_Click);
            // 
            // toolStripButtonLowFuel
            // 
            this.toolStripButtonLowFuel.CheckOnClick = true;
            this.toolStripButtonLowFuel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLowFuel.Image = global::Properties.Resources.injector1;
            this.toolStripButtonLowFuel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLowFuel.Name = "toolStripButtonLowFuel";
            this.toolStripButtonLowFuel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLowFuel.Text = "toolStripButton23";
            this.toolStripButtonLowFuel.ToolTipText = "Low Cams Fuel";
            this.toolStripButtonLowFuel.Click += new System.EventHandler(this.PrimaryLowFuelToolStripMenuItem_Click);
            // 
            // toolStripButtonHighFuel
            // 
            this.toolStripButtonHighFuel.CheckOnClick = true;
            this.toolStripButtonHighFuel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHighFuel.Image = global::Properties.Resources.injector2;
            this.toolStripButtonHighFuel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHighFuel.Name = "toolStripButtonHighFuel";
            this.toolStripButtonHighFuel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHighFuel.Text = "toolStripButton24";
            this.toolStripButtonHighFuel.ToolTipText = "High Cams Fuel";
            this.toolStripButtonHighFuel.Click += new System.EventHandler(this.PrimaryHighFuelToolStripMenuItem_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonPrimary
            // 
            this.toolStripButtonPrimary.CheckOnClick = true;
            this.toolStripButtonPrimary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrimary.Image = global::Properties.Resources.Map1;
            this.toolStripButtonPrimary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrimary.Name = "toolStripButtonPrimary";
            this.toolStripButtonPrimary.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrimary.Text = "toolStripButton27";
            this.toolStripButtonPrimary.ToolTipText = "Primary Tables";
            this.toolStripButtonPrimary.Click += new System.EventHandler(this.PrimaryTablesToolStripMenuItem_Click);
            // 
            // toolStripButtonSecondary
            // 
            this.toolStripButtonSecondary.CheckOnClick = true;
            this.toolStripButtonSecondary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSecondary.Image = global::Properties.Resources.Map2;
            this.toolStripButtonSecondary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSecondary.Name = "toolStripButtonSecondary";
            this.toolStripButtonSecondary.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSecondary.Text = "toolStripButton28";
            this.toolStripButtonSecondary.ToolTipText = "Secondary Tables";
            this.toolStripButtonSecondary.Click += new System.EventHandler(this.SecondaryTablesToolStripMenuItem_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMapValues
            // 
            this.toolStripButtonMapValues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMapValues.Image = global::Properties.Resources._3d_bar_chart;
            this.toolStripButtonMapValues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMapValues.Name = "toolStripButtonMapValues";
            this.toolStripButtonMapValues.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMapValues.Text = "toolStripButton1";
            this.toolStripButtonMapValues.ToolTipText = "Maps Values";
            this.toolStripButtonMapValues.Click += new System.EventHandler(this.mapValuesToolStripMenuItem_Click);
            // 
            // toolStripButtonAFTarget
            // 
            this.toolStripButtonAFTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAFTarget.Image = global::Properties.Resources.AFTarget;
            this.toolStripButtonAFTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAFTarget.Name = "toolStripButtonAFTarget";
            this.toolStripButtonAFTarget.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAFTarget.Text = "toolStripButton29";
            this.toolStripButtonAFTarget.ToolTipText = "AF Target";
            this.toolStripButtonAFTarget.Click += new System.EventHandler(this.aFTargetToolStripMenuItem1_Click);
            // 
            // toolStripButtonAFReading
            // 
            this.toolStripButtonAFReading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAFReading.Image = global::Properties.Resources.AFReading;
            this.toolStripButtonAFReading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAFReading.Name = "toolStripButtonAFReading";
            this.toolStripButtonAFReading.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAFReading.Text = "toolStripButton30";
            this.toolStripButtonAFReading.ToolTipText = "AF Reading";
            this.toolStripButtonAFReading.Click += new System.EventHandler(this.aFToolStripMenuItem_Click);
            // 
            // toolStripButtonAFDiff
            // 
            this.toolStripButtonAFDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAFDiff.Image = global::Properties.Resources.AFDiff;
            this.toolStripButtonAFDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAFDiff.Name = "toolStripButtonAFDiff";
            this.toolStripButtonAFDiff.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAFDiff.Text = "toolStripButton31";
            this.toolStripButtonAFDiff.ToolTipText = "AF Diff";
            this.toolStripButtonAFDiff.Click += new System.EventHandler(this.fuelDifferenceToolStripMenuItem_Click);
            // 
            // windowsToolStrip
            // 
            this.windowsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.windowsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonParameters,
            this.toolStripButtonTables,
            this.toolStripButtonCELCodes,
            this.toolStripButtonDebugLogs});
            this.windowsToolStrip.Location = new System.Drawing.Point(275, 74);
            this.windowsToolStrip.Name = "windowsToolStrip";
            this.windowsToolStrip.Size = new System.Drawing.Size(104, 25);
            this.windowsToolStrip.TabIndex = 13;
            this.windowsToolStrip.Text = "toolStrip4";
            // 
            // toolStripButtonParameters
            // 
            this.toolStripButtonParameters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonParameters.Image = global::Properties.Resources.Application;
            this.toolStripButtonParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonParameters.Name = "toolStripButtonParameters";
            this.toolStripButtonParameters.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonParameters.Text = "toolStripButton1";
            this.toolStripButtonParameters.ToolTipText = "Parameters";
            this.toolStripButtonParameters.Click += new System.EventHandler(this.parametersToolStripButton_Click);
            // 
            // toolStripButtonTables
            // 
            this.toolStripButtonTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTables.Image = global::Properties.Resources.Table;
            this.toolStripButtonTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTables.Name = "toolStripButtonTables";
            this.toolStripButtonTables.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTables.Text = "toolStripButton2";
            this.toolStripButtonTables.ToolTipText = "Tables";
            this.toolStripButtonTables.Click += new System.EventHandler(this.tablesToolStripButton_Click);
            // 
            // toolStripButtonCELCodes
            // 
            this.toolStripButtonCELCodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCELCodes.Image = global::Properties.Resources.Error;
            this.toolStripButtonCELCodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCELCodes.Name = "toolStripButtonCELCodes";
            this.toolStripButtonCELCodes.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCELCodes.Text = "toolStripButton3";
            this.toolStripButtonCELCodes.ToolTipText = "CEL Error Codes";
            this.toolStripButtonCELCodes.Click += new System.EventHandler(this.errorToolStripButton_Click);
            // 
            // toolStripButtonDebugLogs
            // 
            this.toolStripButtonDebugLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDebugLogs.Image = global::Properties.Resources.Warning;
            this.toolStripButtonDebugLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDebugLogs.Name = "toolStripButtonDebugLogs";
            this.toolStripButtonDebugLogs.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDebugLogs.Text = "toolStripButton4";
            this.toolStripButtonDebugLogs.ToolTipText = "Debug Logs";
            this.toolStripButtonDebugLogs.Click += new System.EventHandler(this.debugLogsToolStripMenuItem_Click);
            // 
            // toolTip_0
            // 
            this.toolTip_0.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusName,
            this.toolStripSeparator30,
            this.statusBaserom,
            this.toolStripSeparator29,
            this.statusEmulator,
            this.toolStripSeparator16,
            this.statusDatalogging,
            this.toolStripSeparator27,
            this.statusWB,
            this.toolStripSeparator3,
            this.statusDyno,
            this.toolStripSeparator28,
            this.stutasEmulatorProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 570);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(868, 23);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusName
            // 
            this.statusName.Name = "statusName";
            this.statusName.Size = new System.Drawing.Size(97, 18);
            this.statusName.Text = "NO FILE OPENED";
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(6, 23);
            // 
            // statusBaserom
            // 
            this.statusBaserom.Name = "statusBaserom";
            this.statusBaserom.Size = new System.Drawing.Size(84, 18);
            this.statusBaserom.Text = "Baserom:V1.00";
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(6, 23);
            // 
            // statusEmulator
            // 
            this.statusEmulator.Name = "statusEmulator";
            this.statusEmulator.Size = new System.Drawing.Size(130, 18);
            this.statusEmulator.Text = "Emulator:Disconnected";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 23);
            // 
            // statusDatalogging
            // 
            this.statusDatalogging.Name = "statusDatalogging";
            this.statusDatalogging.Size = new System.Drawing.Size(123, 18);
            this.statusDatalogging.Text = "Datalog:Disconnected";
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(6, 23);
            // 
            // statusWB
            // 
            this.statusWB.Name = "statusWB";
            this.statusWB.Size = new System.Drawing.Size(118, 18);
            this.statusWB.Text = "Wideband:OEM(D14)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // statusDyno
            // 
            this.statusDyno.Name = "statusDyno";
            this.statusDyno.Size = new System.Drawing.Size(110, 18);
            this.statusDyno.Text = "Dyno:Disconnected";
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(6, 23);
            // 
            // stutasEmulatorProgress
            // 
            this.stutasEmulatorProgress.Name = "stutasEmulatorProgress";
            this.stutasEmulatorProgress.Size = new System.Drawing.Size(100, 17);
            this.stutasEmulatorProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 99);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(868, 0);
            // 
            // splitContainer1_Left
            // 
            this.splitContainer1_Left.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1_Left.Location = new System.Drawing.Point(0, 97);
            this.splitContainer1_Left.Name = "splitContainer1_Left";
            // 
            // splitContainer1_Left.Panel1
            // 
            this.splitContainer1_Left.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1_Left.Panel1.Controls.Add(this.splitContainer5_BottomLeft);
            // 
            // splitContainer1_Left.Panel2
            // 
            this.splitContainer1_Left.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1_Left.Panel2.Controls.Add(this.splitContainer2_Top);
            this.splitContainer1_Left.Size = new System.Drawing.Size(868, 449);
            this.splitContainer1_Left.SplitterDistance = 173;
            this.splitContainer1_Left.TabIndex = 3;
            // 
            // splitContainer5_BottomLeft
            // 
            this.splitContainer5_BottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5_BottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5_BottomLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5_BottomLeft.Name = "splitContainer5_BottomLeft";
            this.splitContainer5_BottomLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5_BottomLeft.Panel1
            // 
            this.splitContainer5_BottomLeft.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer5_BottomLeft.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer5_BottomLeft.Panel2
            // 
            this.splitContainer5_BottomLeft.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer5_BottomLeft.Panel2.Controls.Add(this.tabControl4);
            this.splitContainer5_BottomLeft.Size = new System.Drawing.Size(173, 449);
            this.splitContainer5_BottomLeft.SplitterDistance = 353;
            this.splitContainer5_BottomLeft.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(169, 349);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl2_SelectedIndexChanged);
            this.tabControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl_DragDrop);
            this.tabControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControl_DragEnter);
            this.tabControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseMove);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(161, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datalog";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(161, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.AllowDrop = true;
            this.tabControl4.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl4.Controls.Add(this.tabPage5);
            this.tabControl4.Controls.Add(this.tabPage6);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(169, 88);
            this.tabControl4.TabIndex = 0;
            this.tabControl4.SelectedIndexChanged += new System.EventHandler(this.TabControl2_SelectedIndexChanged);
            this.tabControl4.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl_DragDrop);
            this.tabControl4.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControl_DragEnter);
            this.tabControl4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseMove);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(161, 59);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "CEL Code";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(161, 59);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // splitContainer2_Top
            // 
            this.splitContainer2_Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2_Top.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2_Top.Name = "splitContainer2_Top";
            this.splitContainer2_Top.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2_Top.Panel1
            // 
            this.splitContainer2_Top.Panel1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // splitContainer2_Top.Panel2
            // 
            this.splitContainer2_Top.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2_Top.Panel2.Controls.Add(this.splitContainer6_Right);
            this.splitContainer2_Top.Size = new System.Drawing.Size(691, 449);
            this.splitContainer2_Top.SplitterDistance = 60;
            this.splitContainer2_Top.TabIndex = 0;
            // 
            // splitContainer6_Right
            // 
            this.splitContainer6_Right.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer6_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6_Right.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6_Right.Name = "splitContainer6_Right";
            // 
            // splitContainer6_Right.Panel1
            // 
            this.splitContainer6_Right.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer6_Right.Panel1.Controls.Add(this.splitContainer3_Bottom);
            // 
            // splitContainer6_Right.Panel2
            // 
            this.splitContainer6_Right.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer6_Right.Panel2.Controls.Add(this.tabControl5);
            this.splitContainer6_Right.Size = new System.Drawing.Size(691, 385);
            this.splitContainer6_Right.SplitterDistance = 456;
            this.splitContainer6_Right.TabIndex = 1;
            // 
            // splitContainer3_Bottom
            // 
            this.splitContainer3_Bottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3_Bottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3_Bottom.Name = "splitContainer3_Bottom";
            this.splitContainer3_Bottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3_Bottom.Panel1
            // 
            this.splitContainer3_Bottom.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer3_Bottom.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer3_Bottom.Panel2
            // 
            this.splitContainer3_Bottom.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer3_Bottom.Panel2.Controls.Add(this.tabControl3);
            this.splitContainer3_Bottom.Size = new System.Drawing.Size(456, 385);
            this.splitContainer3_Bottom.SplitterDistance = 180;
            this.splitContainer3_Bottom.TabIndex = 0;
            this.splitContainer3_Bottom.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer3_SplitterMoved);
            // 
            // tabControl2
            // 
            this.tabControl2.AllowDrop = true;
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(452, 176);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.TabControl2_SelectedIndexChanged);
            this.tabControl2.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl_DragDrop);
            this.tabControl2.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControl_DragEnter);
            this.tabControl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseMove);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(444, 146);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Tables";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(444, 146);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Parameters";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.AllowDrop = true;
            this.tabControl3.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(452, 197);
            this.tabControl3.TabIndex = 0;
            this.tabControl3.SelectedIndexChanged += new System.EventHandler(this.TabControl2_SelectedIndexChanged);
            this.tabControl3.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl_DragDrop);
            this.tabControl3.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControl_DragEnter);
            this.tabControl3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseMove);
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 26);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(444, 167);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Graph";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 26);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(444, 167);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.AllowDrop = true;
            this.tabControl5.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl5.Controls.Add(this.tabPage9);
            this.tabControl5.Controls.Add(this.tabPage10);
            this.tabControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl5.Location = new System.Drawing.Point(0, 0);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(227, 381);
            this.tabControl5.TabIndex = 0;
            this.tabControl5.SelectedIndexChanged += new System.EventHandler(this.TabControl2_SelectedIndexChanged);
            this.tabControl5.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl_DragDrop);
            this.tabControl5.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControl_DragEnter);
            this.tabControl5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseMove);
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 25);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(219, 352);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(219, 352);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "tabPage10";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(868, 593);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripPanelTop);
            this.Controls.Add(this.splitContainer1_Left);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mdiMenuStrip;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BMTune";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResizeBegin += new System.EventHandler(this.FrmMain_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.FrmMain_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.mdiMenuStrip.ResumeLayout(false);
            this.mdiMenuStrip.PerformLayout();
            this.toolStripPanelTop.ResumeLayout(false);
            this.toolStripPanelTop.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.editToolStrip.ResumeLayout(false);
            this.editToolStrip.PerformLayout();
            this.emulatorToolStrip.ResumeLayout(false);
            this.emulatorToolStrip.PerformLayout();
            this.dataloggingToolStrip.ResumeLayout(false);
            this.dataloggingToolStrip.PerformLayout();
            this.viewToolStrip.ResumeLayout(false);
            this.viewToolStrip.PerformLayout();
            this.windowsToolStrip.ResumeLayout(false);
            this.windowsToolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1_Left.Panel1.ResumeLayout(false);
            this.splitContainer1_Left.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1_Left)).EndInit();
            this.splitContainer1_Left.ResumeLayout(false);
            this.splitContainer5_BottomLeft.Panel1.ResumeLayout(false);
            this.splitContainer5_BottomLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5_BottomLeft)).EndInit();
            this.splitContainer5_BottomLeft.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.splitContainer2_Top.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2_Top)).EndInit();
            this.splitContainer2_Top.ResumeLayout(false);
            this.splitContainer6_Right.Panel1.ResumeLayout(false);
            this.splitContainer6_Right.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6_Right)).EndInit();
            this.splitContainer6_Right.ResumeLayout(false);
            this.splitContainer3_Bottom.Panel1.ResumeLayout(false);
            this.splitContainer3_Bottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3_Bottom)).EndInit();
            this.splitContainer3_Bottom.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    public void ReloadShortcuts()
    {
        if (this.class10_settings_0.GetKeySettings("Open Parameters"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.parametersToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Open Tables"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.tablesToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Open Error Code"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.errorToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Open Snapshots List"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.snapshotToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Open TPS Calibration"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.tPSCalibrationToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Open Timing Sync"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.ignitionSyncToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Open Boost Table"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.bstTablesToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Kill Injectors"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.killInjectorsToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Kill Fuel Pump (Off)"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.offToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        //############
        if (this.class10_settings_0.GetKeySettings("New Basemap"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.newToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Open File"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.openToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Save File As"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.saveToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Save File"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.saveQuickToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Quit"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.exitToolStripMenuItem1.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Copy"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.copyToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Paste"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.pasteToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        //############
        if (this.class10_settings_0.GetKeySettings("Undo"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.undoToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Redo"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.redoToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Increase Selected Cells"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.increaseSelectionToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Decrease Selected Cells"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.decreaseSelectionToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Adjust Selection"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.adjustSelectionToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Interpolate All X & Y"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.interpolateToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Interpolate rows"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.interpolateHorizontallyToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Interpolate columns"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.interpolateVerticallyToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Smooth current selection/map"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.smoothMapsToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        //############
        if (this.class10_settings_0.GetKeySettings("Show Map Values"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.mapValuesToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Show A/F Target"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.aFTargetToolStripMenuItem1.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Show A/F Reading"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.aFToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Show Fuel Difference"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.fuelDifferenceToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Show VE Table"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.vETablesToolStripMenuItem1.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        //############
        if (this.class10_settings_0.GetKeySettings("Show Raw Fuel Value"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.FuelRawToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Show Fuel Duty Cycle"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.FuelDutyToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Show Injector Duration"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.fuelInjDurToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        //############
        if (this.class10_settings_0.GetKeySettings("Smart track toggle"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.toolTunerSmartTrack.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Map trail toggle"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.toolTunerMapTrail.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Follow Vtec"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.toolTunerFollowVtec.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Follow Secondary Map"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.toolTunerFollowDualTables.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        //############
        if (this.class10_settings_0.GetKeySettings("Clear all recording"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.clearRecordingToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
    }

    private void killInjectorsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.class18_0.class13_u_0.long_88 != 0L)
        {
            this.class18_0.method_155("Kill injector setting");
            if (this.killInjectorsToolStripMenuItem.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_88, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_88, 0);
            }
            this.class18_0.method_153();
        }
    }

    public void method_0()
    {
        //Loading files by double clicking on them
        FileInfo info;
        this.method_7();

        string fullName = null;
        string[] commandLineArgs = Environment.GetCommandLineArgs();
        for (int i = 0; i < commandLineArgs.Length; i++)
        {
            info = new FileInfo(commandLineArgs[i]);
            if (((info.Extension == ".bin")) && info.Exists)
            {
                fullName = info.FullName;
                this.class10_settings_0.romFilePath = info.Directory.ToString();
                this.class18_0.method_62(fullName);
            }
            if ((info.Extension == ".bmc") && info.Exists)
            {
                this.class10_settings_0.romFilePath = info.Directory.ToString();
                this.class18_0.method_66(info.FullName);
                return;
            }
            if ((info.Extension == ".bmg") && info.Exists)
            {
                //Load Last opened file
                if ((this.class10_settings_0.string_0[0] != string.Empty)) this.class18_0.method_62(this.class10_settings_0.string_0[0]);

                if (this.frmChartTemplates_0 != null)
                {
                    this.frmChartTemplates_0.Dispose();
                    this.frmChartTemplates_0 = null;
                }

                this.frmChartTemplates_0 = new frmChartTemplates();
                this.frmChartTemplates_0.method_0(ref this.class18_0, ref this.class10_settings_0);
                this.frmChartTemplates_0.Show();
                this.frmChartTemplates_0.LoadSet(info.FullName);
                this.frmChartTemplates_0.Dispose();
                this.frmChartTemplates_0 = null;

                return;
            }
            if ((info.Extension == ".bml") && info.Exists)
            {
                //Load Last opened file
                if ((this.class10_settings_0.string_0[0] != string.Empty))
                {
                    this.class18_0.method_62(this.class10_settings_0.string_0[0]);

                    //Load license file
                    if (info.Name.Contains("License"))
                    {
                       /*string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\License.bml";
                        byte[] Byte_99_9_2 = File.ReadAllBytes(info.FullName);
                        File.Create(path).Dispose();
                        File.WriteAllBytes(path, Byte_99_9_2);
                        File.Delete(info.FullName);
                        this.class15_0.IsNewClient = true;

                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\data5123.txt"))
                            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\data5123.txt");
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\data3245.txt"))
                            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\data3245.txt");

                        this.class15_0.method_12();
                        //GC.Collect();*/
                        return;
                    }
                    //Load datalog file
                    else
                    {
                        if (this.class17_0.method_3() == DataloggingState.PlayingF)
                        {
                            this.class17_0.method_71();
                            this.class17_0.method_75();
                            GC.Collect(3, GCCollectionMode.Forced);
                        }
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\" + info.Name;
                        byte[] byte_99_0 = this.class18_0.method_93(File.ReadAllBytes(info.FullName));
                        File.WriteAllBytes(path, byte_99_0);

                        this.class10_settings_0.logFilePath = Path.GetDirectoryName(path);
                        this.class17_0.string_2 = path;
                        this.class17_0.method_67(path);
                        if (this.class10_settings_0.bool_7) this.class17_0.method_70();
                        return;
                    }
                }
            }
        }
        info = null;
        this.frmLoading_0.SetPercent(100);
        Loading = false;

        if (!this.class10_settings_0.ShownDockedMode)
        {
            this.frmSelectMode_0 = new frmSelectMode(ref this.class10_settings_0);
            this.frmSelectMode_0.StartPosition = FormStartPosition.CenterParent;
            this.frmSelectMode_0.ShowDialog();
            this.frmSelectMode_0.Dispose();
            this.frmSelectMode_0 = null;
        }

        if ((this.class10_settings_0.string_0[0] != string.Empty)) this.class18_0.method_62(this.class10_settings_0.string_0[0]);
    }

    private void method_1()
    {
        //try
        //{
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune";
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        this.class28_Shortcuts_0 = new Class28_Shortcuts();

        ReloadShortcuts();
        this.frmLoading_0.SetPercent(20);

        this.class18_0 = new Class18(ref this.class10_settings_0, ref this.class15_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_19);

        this.class21_snap_0 = new Class21_snap();
        this.class21_snap_0.method_0(ref this.class18_0);
        this.frmLoading_0.SetPercent(25);

        this.class10_settings_0.method_0(ref this.class18_0);
        this.frmLoading_0.SetPercent(30);

        this.class11_u_0 = new Class11_u(this.class18_0);
        this.class11_u_0.delegate32_0 += new Class11_u.Delegate32(this.SetModified);
        this.frmLoading_0.SetPercent(35);

        this.class17_0 = new Class17();
        this.class25_0 = new Class25(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);

        this.frmLoading_0.SetPercent(40);
        
        this.class5_burn_0 = new Class5_burn(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);
        this.frmLoading_0.SetPercent(45);

        this.class18_0.method_0(ref this.class11_u_0, ref this.class17_0, ref this.class21_snap_0);
        this.frmLoading_0.SetPercent(50);

        this.class17_0.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class25_0, ref this.frmMain_0);
        this.frmLoading_0.SetPercent(55);

        this.class17_0.delegate46_0 += new Class17.Delegate46(this.method_15);
        this.class17_0.delegate53_0 += new Class17.Delegate53(this.method_18);
        this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_16);
        this.class25_0.delegate65_0 += new Class25.Delegate65(this.method_13);
        this.class25_0.delegate66_0 += new Class25.Delegate66(this.method_11);
        this.frmLoading_0.SetPercent(60);

        this.class18_0.method_2(ref this.class25_0);
        this.frmLoading_0.SetPercent(65);

        this.class12_afrT_0 = new Class12_afrT();
        this.class12_afrT_0.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0);
        this.frmLoading_0.SetPercent(75);

        this.mdiMenuStrip.Location = new Point(0, 0);

        this.trackBar_0 = new TrackBar();
        this.trackBar_0.AutoSize = false;
        this.trackBar_0.TickStyle = TickStyle.None;
        this.trackBar_0.Width = 150;
        this.trackBar_0.Height = 15;
        this.trackBar_0.SmallChange = 2;
        this.trackBar_0.LargeChange = 100;
        this.trackBar_0.BackColor = SystemColors.ControlLightLight;
        this.trackBar_0.Scroll += new EventHandler(this.trackBar_0_Scroll);
        ToolStripControlHost host = new ToolStripControlHost(this.trackBar_0)
        {
            AutoSize = false,
            Height = 20
        };
        this.dataloggingToolStrip.Items.Add(host);

        this.method_4();
        this.frmLoading_0.SetPercent(80);

        if (this.class10_settings_0.Emu_AlwaysRT) this.class10_settings_0.bool_32 = true;
        SetImageBackgrounds();

        this.datalogToolStripMenuItem.Enabled = true;
        this.dlConnectToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.consoleToolStripMenuItem.Visible = true;
        this.uploadBaseromOnlineToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolStripButtonUploadFile.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();


        this.dataloggingToolStrip.Location = this.class10_settings_0.dataloggingToolStrip;
        this.editToolStrip.Location = this.class10_settings_0.editToolStrip;
        this.viewToolStrip.Location = this.class10_settings_0.viewToolStrip;
        this.windowsToolStrip.Location = this.class10_settings_0.windowsToolStrip;
        this.mainToolStrip.Location = this.class10_settings_0.mainToolStrip;
        this.emulatorToolStrip.Location = this.class10_settings_0.emulatorToolStrip;


        //#################################################
        //Load Pages
        this.frmLoading_0.SetPercent(82);
        windowedModeToolStripMenuItem.Checked = this.class10_settings_0.WindowedMode;
        LoadPages();
        this.frmLoading_0.SetPercent(90);
        //#####################

        //#################################################
        //Load Toolbars

        this.fileToolbarVisibleToolStripMenuItem.Checked = this.class10_settings_0.ToolbarFile;
        this.editToolbarToolStripMenuItem.Checked = this.class10_settings_0.ToolbarEdit;
        this.emulatorToolbarToolStripMenuItem.Checked = this.class10_settings_0.ToolbarEmulator;
        this.datalogToolbartoolStripMenuItem.Checked = this.class10_settings_0.ToolbarDatalog;
        this.viewToolbarToolStripMenuItem.Checked = this.class10_settings_0.ToolbarView;
        this.toolsToolbarToolStripMenuItem.Checked = this.class10_settings_0.ToolbarTools;

        this.mainToolStrip.Visible = this.class10_settings_0.ToolbarFile;
        this.editToolStrip.Visible = this.class10_settings_0.ToolbarEdit;
        this.emulatorToolStrip.Visible = this.class10_settings_0.ToolbarEmulator;
        this.dataloggingToolStrip.Visible = this.class10_settings_0.ToolbarDatalog;
        this.viewToolStrip.Visible = this.class10_settings_0.ToolbarView;
        this.windowsToolStrip.Visible = this.class10_settings_0.ToolbarTools;

        CheckToolbarVisible();
        //#################################################

        // RESET log minimal data
        this.class10_settings_0.method_9(DataloggingTable.tableMain);
        /*}
        catch (Exception exception)
        {
            //MessageBox.Show(Form.ActiveForm, string.Concat(new object[] { exception.Message, " ", exception.TargetSite, " ", exception.StackTrace }));
            MessageBox.Show(string.Concat(new object[] { exception.Message, " ", exception.TargetSite, " ", exception.StackTrace }));
            Environment.Exit(0);
        }*/
    }

    private void method_10()
    {
        string str = "Wideband:";
        if (this.class10_settings_0.bool_25)
        {
            str = this.class10_settings_0.wideband_Serial_0.ToString();
        }
        else
        {
            switch (this.class10_settings_0.int_8)
            {
                case 0:
                    str = str + "Custom";
                    break;

                case 1:
                    str = "";
                    break;
                //goto Label_015A;

                case 2:
                    str = str + "AEM";
                    break;

                case 3:
                    str = str + "PLX M";
                    break;

                case 4:
                    str = str + "FJO CW0002";
                    break;

                case 5:
                    str = str + "LC-1/LM-1";
                    break;

                case 6:
                    str = str + "TE";
                    break;

                case 7:
                    str = str + "Zeitronix";
                    break;

                case 8:
                    str = str + "Motec PLM";
                    break;

                case 9:
                    str = str + "JAW";
                    break;
            }
            switch (this.class10_settings_0.wbinput_0)
            {
                case WBinput.o2Input:
                    str = str + "(D14-O2)";
                    break;

                case WBinput.eldInput:
                    str = str + "(D10-ELD)";
                    break;

                case WBinput.egrInput:
                    str = str + "(D12-EGR)";
                    break;

                case WBinput.b6Input:
                    str = str + "(B6)";
                    break;
            }
        }
        this.statusWB.Text = str;
    }

    private void method_11(int int_1)
    {
        if (this.bool_0)
        {
            try
            {
                base.Invoke(new Delegate40(this.method_12), new object[] { int_1 });
            }
            catch { }
        }
    }

    private void method_12(int int_1)
    {
        if (int_1 == 100)
        {
            this.stutasEmulatorProgress.Visible = false;
            base.Enabled = true;
            this.frmDataDisplay_0.Enabled = true;
        }
        else
        {
            this.stutasEmulatorProgress.Visible = true;
            this.stutasEmulatorProgress.Value = int_1;
            if (this.class25_0.method_13() != EmulatorState.Sending_data)
            {
                base.Enabled = false;
                if (this.frmDataDisplay_0 != null)
                {
                    this.frmDataDisplay_0.Enabled = false;
                }
            }
        }
    }

    private void method_13(EmulatorState emulatorState_0, int int_1, bool bool_2)
    {
        if (this.bool_0)
        {
            try
            {
                base.Invoke(new Delegate41(this.method_14), new object[] { emulatorState_0, int_1, bool_2 });
            }
            catch (Exception)
            {

            }
        }
    }

    public void SetStatusEmulator(string ThisS)
    {
        this.statusEmulator.Text = "Emulator:" + ThisS;
    }

    private void method_14(EmulatorState emulatorState_0, int int_1, bool bool_2)
    {
        if (int_1 < 0)
        {
            return;
        }
        switch (emulatorState_0)
        {
            case EmulatorState.Connected:
                this.statusEmulator.Text = "Emulator:Connected";
                this.statusEmulator.ForeColor = this.class10_settings_0.color_OnDark;
                this.emulatorToolStripMenuItem.ForeColor = this.class10_settings_0.color_OnDark;
                break;

            case EmulatorState.Disconnected:
                this.statusEmulator.Text = "Emulator:Disconnected";
                this.statusEmulator.ForeColor = this.class10_settings_0.color_Off;
                this.emuConnectToolStripMenuItem.Text = "Connect";
                this.emulatorToolStripMenuItem.ForeColor = this.class10_settings_0.color_Off;
                goto Label_0146;

            case EmulatorState.Connecting:
                this.statusEmulator.Text = "Emulator:Connecting...";
                this.statusEmulator.ForeColor = this.class10_settings_0.color_Trace;
                this.emulatorToolStripMenuItem.ForeColor = this.class10_settings_0.color_Trace;
                goto Label_0146;

            case EmulatorState.Error_detected:
                this.statusEmulator.Text = "Emulator:Error dectected";
                this.statusEmulator.ForeColor = this.class10_settings_0.color_Off;
                this.emulatorToolStripMenuItem.ForeColor = this.class10_settings_0.color_Off;
                goto Label_0146;

            case EmulatorState.Downloading_data:
                this.statusEmulator.Text = "Emulator:Downloading data";
                this.statusEmulator.ForeColor = this.class10_settings_0.color_9;
                this.emulatorToolStripMenuItem.ForeColor = this.class10_settings_0.color_9;
                goto Label_0146;

            case EmulatorState.Sending_data:
                this.statusEmulator.Text = "Emulator:Uploading data";
                this.statusEmulator.ForeColor = this.class10_settings_0.color_9;
                this.emulatorToolStripMenuItem.ForeColor = this.class10_settings_0.color_9;
                goto Label_0146;

            case EmulatorState.Realtime:
                this.statusEmulator.Text = "Emulator:Updating(left: " + int_1.ToString() + ")";
                this.statusEmulator.ForeColor = this.class10_settings_0.color_9;
                this.emulatorToolStripMenuItem.ForeColor = this.class10_settings_0.color_9;
                goto Label_0146;

            default:
                goto Label_0146;
        }
        this.emuConnectToolStripMenuItem.Text = "Disconnect";
    //set disconnect image
    Label_0146:
        this.method_5();
    }

    private void DataloggingImages(DataloggingState dataloggingState_0)
    {
        if (base.WindowState == FormWindowState.Normal || base.WindowState == FormWindowState.Maximized)
        {
            if (dataloggingState_0 != DataloggingState.PlayingF && dataloggingState_0 != DataloggingState.PlayingR && dataloggingState_0 != DataloggingState.Pause && dataloggingState_0 != DataloggingState.Stop && dataloggingState_0 != DataloggingState.Recording)
            {
                this.toolDtPlay.Image = global::Properties.Resources.control;
                this.toolDtStop.Image = global::Properties.Resources.control_stop_square;
                this.toolDtPause.Image = global::Properties.Resources.control_pause;
                this.toolDtPlayBack.Image = global::Properties.Resources.control_180;
                this.toolDtRecord.Image = global::Properties.Resources.control_record;

                this.playToolStripMenuItem.Image = global::Properties.Resources.control;
                this.stopToolStripMenuItem.Image = global::Properties.Resources.control_stop_square;
                this.pauseToolStripMenuItem.Image = global::Properties.Resources.control_pause;
                this.playBackwardToolStripMenuItem.Image = global::Properties.Resources.control_180;
                this.dlRecordToolStripMenuItem.Image = global::Properties.Resources.control_record;
            }

            switch (dataloggingState_0)
            {
                case DataloggingState.Recording:
                    this.toolDtPlay.Image = global::Properties.Resources.control;
                    this.toolDtStop.Image = global::Properties.Resources.control_stop_square;
                    this.toolDtPause.Image = global::Properties.Resources.control_pause;
                    this.toolDtPlayBack.Image = global::Properties.Resources.control_180;
                    this.toolDtRecord.Image = global::Properties.Resources.control_pause_record;

                    this.playToolStripMenuItem.Image = global::Properties.Resources.control;
                    this.stopToolStripMenuItem.Image = global::Properties.Resources.control_stop_square;
                    this.pauseToolStripMenuItem.Image = global::Properties.Resources.control_pause;
                    this.playBackwardToolStripMenuItem.Image = global::Properties.Resources.control_180;
                    this.dlRecordToolStripMenuItem.Image = global::Properties.Resources.control_pause_record;
                    break;

                case DataloggingState.PlayingF:
                    this.toolDtPlay.Image = global::Properties.Resources.control_green;
                    this.toolDtStop.Image = global::Properties.Resources.control_stop_square;
                    this.toolDtPause.Image = global::Properties.Resources.control_pause;
                    this.toolDtPlayBack.Image = global::Properties.Resources.control_180;
                    this.toolDtRecord.Image = global::Properties.Resources.control_record;

                    this.playToolStripMenuItem.Image = global::Properties.Resources.control_green;
                    this.stopToolStripMenuItem.Image = global::Properties.Resources.control_stop_square;
                    this.pauseToolStripMenuItem.Image = global::Properties.Resources.control_pause;
                    this.playBackwardToolStripMenuItem.Image = global::Properties.Resources.control_180;
                    this.dlRecordToolStripMenuItem.Image = global::Properties.Resources.control_record;
                    break;

                case DataloggingState.PlayingR:
                    this.toolDtPlay.Image = global::Properties.Resources.control;
                    this.toolDtStop.Image = global::Properties.Resources.control_stop_square;
                    this.toolDtPause.Image = global::Properties.Resources.control_pause;
                    this.toolDtPlayBack.Image = global::Properties.Resources.control_180_green;
                    this.toolDtRecord.Image = global::Properties.Resources.control_record;

                    this.playToolStripMenuItem.Image = global::Properties.Resources.control;
                    this.stopToolStripMenuItem.Image = global::Properties.Resources.control_stop_square;
                    this.pauseToolStripMenuItem.Image = global::Properties.Resources.control_pause;
                    this.playBackwardToolStripMenuItem.Image = global::Properties.Resources.control_180_green;
                    this.dlRecordToolStripMenuItem.Image = global::Properties.Resources.control_record;
                    break;

                case DataloggingState.Pause:
                    this.toolDtPlay.Image = global::Properties.Resources.control;
                    this.toolDtStop.Image = global::Properties.Resources.control_stop_square;
                    this.toolDtPause.Image = global::Properties.Resources.control_pause_green;
                    this.toolDtPlayBack.Image = global::Properties.Resources.control_180;
                    this.toolDtRecord.Image = global::Properties.Resources.control_record;

                    this.playToolStripMenuItem.Image = global::Properties.Resources.control;
                    this.stopToolStripMenuItem.Image = global::Properties.Resources.control_stop_square;
                    this.pauseToolStripMenuItem.Image = global::Properties.Resources.control_pause_green;
                    this.playBackwardToolStripMenuItem.Image = global::Properties.Resources.control_180;
                    this.dlRecordToolStripMenuItem.Image = global::Properties.Resources.control_record;
                    break;

                case DataloggingState.Stop:
                    this.toolDtPlay.Image = global::Properties.Resources.control;
                    this.toolDtStop.Image = global::Properties.Resources.control_stop_square_green;
                    this.toolDtPause.Image = global::Properties.Resources.control_pause;
                    this.toolDtPlayBack.Image = global::Properties.Resources.control_180;
                    this.toolDtRecord.Image = global::Properties.Resources.control_record;

                    this.playToolStripMenuItem.Image = global::Properties.Resources.control;
                    this.stopToolStripMenuItem.Image = global::Properties.Resources.control_stop_square_green;
                    this.pauseToolStripMenuItem.Image = global::Properties.Resources.control_pause;
                    this.playBackwardToolStripMenuItem.Image = global::Properties.Resources.control_180;
                    this.dlRecordToolStripMenuItem.Image = global::Properties.Resources.control_record;
                    break;
            }
        }
    }

    public void SetStatuDatalog(string ThisS)
    {
        this.statusDatalogging.Text = "Datalog:" + ThisS;
    }

    private void method_15(DataloggingState dataloggingState_0, bool bool_2)
    {
        DataloggingImages(dataloggingState_0);

        switch (dataloggingState_0)
        {
            case DataloggingState.Connected:
                this.statusDatalogging.Text = "Datalog:Connected";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_OnDark;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_OnDark;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;

            case DataloggingState.Link:
                this.statusDatalogging.Text = "Datalog:Link";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_OnDark;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_OnDark;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;

            case DataloggingState.Disconnected:
                this.statusDatalogging.Text = "Datalog:Disconnected";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_Off;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_Off;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                this.Cursor = Cursors.Arrow;
                break;

            case DataloggingState.Recording:
                this.statusDatalogging.Text = "Datalog:Recording";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_9;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_9;
                this.dlRecordToolStripMenuItem.Checked = true;
                this.dlRecordToolStripMenuItem.Text = "Stop Record";
                break;

            case DataloggingState.PlayingF:
                this.statusDatalogging.Text = "Datalog:Playing";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_10;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_10;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;

            case DataloggingState.PlayingR:
                this.statusDatalogging.Text = "Datalog:Rewinding";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_10;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_10;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;

            case DataloggingState.Pause:
                this.statusDatalogging.Text = "Datalog:Paused";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_10;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_10;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;

            case DataloggingState.Stop:
                this.statusDatalogging.Text = "Datalog:Stopped";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_9;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_9;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;

            case DataloggingState.Timeout:
                this.statusDatalogging.Text = "Datalog:Timeout";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_Off;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_Off;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;

            case DataloggingState.Loading:
                this.statusDatalogging.Text = "Datalog:Loading";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_9;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_9;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                this.Cursor = Cursors.WaitCursor;
                break;

            case DataloggingState.Connecting:
                this.statusDatalogging.Text = "Datalog:Connecting...";
                this.statusDatalogging.ForeColor = this.class10_settings_0.color_Trace;
                this.datalogToolStripMenuItem.ForeColor = this.class10_settings_0.color_Trace;
                this.dlRecordToolStripMenuItem.Checked = false;
                this.dlRecordToolStripMenuItem.Text = "Start Record";
                break;
        }
        if ((dataloggingState_0 == DataloggingState.Connected) || (dataloggingState_0 == DataloggingState.Recording))
        {
            this.dlConnectToolStripMenuItem.Text = "Disconnect";
            this.toolDtConnect.Image = global::Properties.Resources.dashboard__minus;
            this.dlConnectToolStripMenuItem.Image = global::Properties.Resources.dashboard__minus;
        }
        else
        {
            this.dlConnectToolStripMenuItem.Text = "Connect";
            this.toolDtConnect.Image = global::Properties.Resources.dashboard__plus;
            this.dlConnectToolStripMenuItem.Image = global::Properties.Resources.dashboard__plus;
        }
        //this.dlTableToolStripMenuItem.Enabled = bool_2;
        this.dlRecordToolStripMenuItem.Enabled = bool_2;
        this.toolDtRecord.Enabled = bool_2;
        if (this.class17_0 != null)
        {
            if (!this.class17_0.method_63_HasLogsFileOpen())
            {
                this.toolDtPeakMax.Enabled = bool_2;
                this.toolDtPeakClear.Enabled = bool_2;
                if (this.class10_settings_0.dtPeakShown) this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090_green;
                else this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090;
            }
            this.dlSaveToolStripMenuItem.Enabled = this.class17_0.method_54();
            this.toolDtSave.Enabled = this.class17_0.method_54();
        }
    }

    private void method_16(Struct12 struct12_0)
    {
        if ((this.class17_0 != null) && this.bool_0)
        {
            try
            {
                base.Invoke(new Delegate42(this.method_17), new object[] { struct12_0 });
                if (this.frmErrorCodes_0 != null) this.frmErrorCodes_0.button1.Enabled = this.class17_0.method_34_GetConnected();
                this.ClearCELErrorsToolStripMenuItem.Enabled = this.class17_0.method_34_GetConnected();
            }
            catch
            {
            }
        }
    }

    private void method_17(Struct12 struct12_0)
    {
        if (this.class17_0.method_63_HasLogsFileOpen() && this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            if (this.class10_settings_0.dtPeakShown) this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090_green;
            else this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090;

            if (struct12_0.long_5 != 0L)
            {
                string str = TimeSpan.FromMilliseconds((double)struct12_0.long_3).ToString();
                if (str.Length > 8)
                {
                    str = str.Remove(str.Length - 4, 4);
                }
                else
                {
                    str = str + ".000";
                }
                //this.toolDtDuration.Text = str + " of " + this.class17_0.method_64();
                this.trackBar_0.Value = (int)struct12_0.long_5;
            }
            else
            {
                this.trackBar_0.Value = 0;
                //this.toolDtDuration.Text = "00:00:00.000 of " + this.class17_0.method_64();
            }
            //this.toolDtDuration.Invalidate();
        }
    }

    private void method_18(long long_0, string string_1)
    {
        if (this.class17_0.method_63_HasLogsFileOpen())
        {
            this.trackBar_0.Maximum = (int)long_0;
            //this.toolDtDuration.Text = "00.00:00:000 of " + string_1;
        }
        else
        {
            //this.toolDtDuration.Text = string.Empty;
            this.trackBar_0.Value = 0;
            this.trackBar_0.Maximum = 1;
            this.toolDtPlay.Checked = false;
            this.toolDtStop.Checked = false;
            this.toolDtPause.Checked = false;
            this.toolDtPlayBack.Checked = false;
            this.toolDtForward.Checked = false;
            this.toolDtHalf.Checked = false;
            this.toolDtQuart.Checked = false;

            this.playToolStripMenuItem.Checked = false;
            this.stopToolStripMenuItem.Checked = false;
            this.pauseToolStripMenuItem.Checked = false;
            this.playBackwardToolStripMenuItem.Checked = false;
            this.playDoubleSpeedToolStripMenuItem.Checked = false;
            this.playQuarterSpeedToolStripMenuItem.Checked = false;
            this.playHalfSpeedToolStripMenuItem.Checked = false;
        }
        //this.toolDtDuration.Visible = this.class17_0.method_63();
        this.toolDtClose.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtPlay.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtStop.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtPause.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtForward.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtPlayBack.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.trackBar_0.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtPeakMax.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtPeakClear.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtHalf.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.toolDtQuart.Enabled = this.class17_0.method_63_HasLogsFileOpen();

        if (this.class10_settings_0.dtPeakShown) this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090_green;
        else this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090;

        this.dlCloseToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.playToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.stopToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.pauseToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.playDoubleSpeedToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.playBackwardToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.playQuarterSpeedToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.playHalfSpeedToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();

        this.dlExporttoolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        this.dlTableToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
    }

    private void method_19()
    {
        //Unlock menus when file is opened in bmtune
        this.method_7();
        Control.CheckForIllegalCrossThreadCalls = false;
        this.copyPrimaryTablesToSecondaryToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.copySecondaryTablesToPrimaryToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.copyToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();

        this.dlTableToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.copyToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.pasteToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.closeRomToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.saveAsToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune() || this.class18_0.BinLoadedForSaving;
        this.create2TimerBin512kbToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune() || this.class18_0.BinLoadedForSaving;
        this.saveToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.saveQuickToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.snapshotToolStripMenuItem.Enabled = true;
        this.toolStripButtonUploadFile.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.uploadBaseromOnlineToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.dlConnectToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.dlOpenToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.importTunerViewRAWToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.dlCloudtoolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.dlSaveToolStripMenuItem.Enabled = this.class17_0.method_54();

        this.copyToolStripButton.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.pasteToolStripButton.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolStripButtonCloseFile.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolStripButtonSaveAs.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune() || this.class18_0.BinLoadedForSaving;
        this.toolStripButtonSave.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolStripButtonSaveSnapshot.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolDtConnect.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolDtOpen.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.toolDtSave.Enabled = this.class17_0.method_54();

        this.exportTableToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.importTablesToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();

        this.writeChipToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();   //this.writeChipToolStripMenuItem.Enabled = this.class18_0.method_30() && this.class15_0.method_5(Enum4.const_4);
        this.verifyChipToolStripMenuItem1.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune(); //this.verifyChipToolStripMenuItem1.Enabled = this.class18_0.method_30() && this.class15_0.method_5(Enum4.const_4);

        this.ignitionSyncToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.killInjectorsToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune() && (this.class18_0.class13_u_0.long_88 != 0L);
        this.bstTablesToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.scalarSetupToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.fuelPumpToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.baseromConverterToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();

        this.tPSCalibrationToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.injectorCalibrationToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.gearLearningToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();

        if (this.class18_0.method_48())
        {
            this.importCalibrationToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
            this.exportCalibrationToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
            this.importCalibrationToolStripMenuItem.Visible = this.class18_0.method_30_HasFileLoadedInBMTune();
            this.exportCalibrationToolStripMenuItem.Visible = this.class18_0.method_30_HasFileLoadedInBMTune();
        }
        else
        {
            this.importCalibrationToolStripMenuItem.Enabled = (this.class18_0.method_30_HasFileLoadedInBMTune() && !this.class18_0.method_46());
            this.exportCalibrationToolStripMenuItem.Enabled = (this.class18_0.method_30_HasFileLoadedInBMTune() && !this.class18_0.method_46());
            this.importCalibrationToolStripMenuItem.Visible = (this.class18_0.method_30_HasFileLoadedInBMTune() && !this.class18_0.method_46());
            this.exportCalibrationToolStripMenuItem.Visible = (this.class18_0.method_30_HasFileLoadedInBMTune() && !this.class18_0.method_46());
        }

        this.method_5();
        this.method_10();
    }

    public void method_2(ref Struct12 struct12_0)
    {
        try
        {
            base.BeginInvoke(new Delegate39(this.method_3), new object[] { (Struct12)struct12_0 });
        }
        catch
        {
        }
    }

    private void method_23(object sender, EventArgs e)
    {
        this.class18_0.method_62(((ToolStripMenuItem)sender).Text);
    }

    private void method_3(ref Struct12 struct12_0)
    {
        if (!this.bool_1 && (struct12_0.byte_9_E11 > (this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1)))
        {
            if (!this.class18_0.method_42())
            {
                if (((struct12_0.byte_9_E11 > 0x17) && !this.bool_1) && (this.class18_0.class15_0.method_22() != BMTuneVersions.datalogger))
                {
                    if (struct12_0.byte_4 < this.class18_0.method_165(0))
                    {
                        this.bool_1 = true;
                        if (MessageBox.Show(Form.ActiveForm, string.Concat(new object[] { "Error!" + Environment.NewLine + "Current mbar is lower then column1.", Environment.NewLine, "Current mbar is ", this.class18_0.method_206(struct12_0.byte_4), " and colomn 1 mbar is ", this.class18_0.method_163(0), Environment.NewLine, "Would like to lower column 1 mbar to ", this.class18_0.method_206(struct12_0.byte_4 - 3), "?" }), "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                        {
                            int num = this.class18_0.method_206(struct12_0.byte_4 - 3);
                            this.class18_0.method_173(0, num);
                            this.class18_0.method_53();
                        }
                    }
                    else
                    {
                        this.bool_1 = true;
                        MessageBox.Show(Form.ActiveForm, "Error!" + Environment.NewLine + "Current load is higher then load of last column!");
                    }
                }
            }
            else
            {
                this.bool_1 = true;
                MessageBox.Show(Form.ActiveForm, "Error!" + Environment.NewLine + "Set the TPS range indexing properly!");
            }
            struct12_0.byte_9_E11 = (byte)(this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1);
        }
    }

    private void method_5()
    {
        this.emuGetRomToolStripMenuItem.Enabled = (this.class25_0.GetConnected());
        this.emuPutRomToolStripMenuItem.Enabled = (this.class25_0.GetConnected() & this.class18_0.method_30_HasFileLoadedInBMTune());
        this.emuRealTimeUpdateToolStripMenuItem.Enabled = (this.class25_0.GetConnected() & this.class18_0.method_30_HasFileLoadedInBMTune());
        this.emuUploadCalToolStripMenuItem.Enabled = ((this.class25_0.GetConnected() & this.class18_0.method_30_HasFileLoadedInBMTune()) && (this.class25_0.method_13() != EmulatorState.Realtime));
        this.emuVerifyRomToolStripMenuItem.Enabled = (this.class25_0.GetConnected() & this.class18_0.method_30_HasFileLoadedInBMTune());

        this.toolStripButtonEmuDownload.Enabled = (this.class25_0.GetConnected());
        this.toolStripButtonEmuRealtime.Enabled = (this.class25_0.GetConnected() & this.class18_0.method_30_HasFileLoadedInBMTune());
        this.toolStripButtonEmuUploadAll.Enabled = (this.class25_0.GetConnected() & this.class18_0.method_30_HasFileLoadedInBMTune());
        this.toolStripButtonEmuUploadCal.Enabled = ((this.class25_0.GetConnected() & this.class18_0.method_30_HasFileLoadedInBMTune()) && (this.class25_0.method_13() != EmulatorState.Realtime));
    }

    public void SetDemon()
    {
        this.class10_settings_0.Datalog_Baud = 0xe1000;
        this.class10_settings_0.Emulator_Baud = 0xe1000;
        this.class10_settings_0.bool_32 = false;
        this.emuRealTimeUpdateToolStripMenuItem.Checked = false;
        this.class10_settings_0.bool_31 = true;
        this.class10_settings_0.emulatorMode_0 = EmulatorMode.Demon;
        this.class10_settings_0.dataloggingMode_0 = DataloggingMode.datalogDemon;
        this.class10_settings_0.string_2 = "COM1";
        this.class10_settings_0.string_1 = this.class10_settings_0.string_2;
        this.class10_settings_0.Emu_AlwaysRT = false;
        this.class10_settings_0.bool_27 = this.class10_settings_0.Emu_AlwaysRT;
        this.emulatorToolStripMenuItem.Enabled = false;
    }

    private void method_7()
    {
        this.openToolStripMenuItem.Enabled = true;
        this.mruToolStripMenuItem.Enabled = true;
        this.editToolStripMenuItem1.Enabled = true;
        this.chipBurnerToolStripMenuItem.Enabled = true;
        this.readChipToolStripMenuItem.Enabled = true;

        this.toolStripButtonOpenFile.Enabled = true;
        this.toolStripDropDownLastFile.Enabled = true;

        this.importExportToolStripMenuItem.Enabled = true;
        this.ExportToolStripMenuItem.Enabled = true;
    }

    private void SetModified()
    {
        this.undoToolStripMenuItem.Enabled = this.class11_u_0.method_1();
        this.undoToolStripDropDown.Enabled = this.class11_u_0.method_1();

        this.undoHistoryToolStripMenuItem.Enabled = this.class11_u_0.method_1();
        this.toolStripButtonUndoHistory.Enabled = this.class11_u_0.method_1();

        this.redoToolStripMenuItem.Enabled = this.class11_u_0.method_2();
        this.redoToolStripDropDown.Enabled = this.class11_u_0.method_2();
        /*if (this.class18_0.method_45())
        {
            this.statusModified.Text = "Modified";
            this.statusModified.ForeColor = Color.Red;
        }
        else
        {
            this.statusModified.Text = "";
            this.statusModified.ForeColor = Color.Black;
        }*/
    }

    public void method_4()
    {
        method_9(this.class10_settings_0.string_0);
    }

    private void method_9(string[] string_1)
    {
        this.mruToolStripMenuItem.DropDownItems.Clear();
        this.toolStripDropDownLastFile.DropDownItems.Clear();
        for (int i = 0; i < string_1.Length; i++)
        {
            if (string_1[i] != string.Empty)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(string_1[i], null, new EventHandler(this.method_23));
                ToolStripMenuItem item2 = new ToolStripMenuItem(string_1[i], null, new EventHandler(this.method_23));
                this.mruToolStripMenuItem.DropDownItems.Add(item);
                this.toolStripDropDownLastFile.DropDownItems.Add(item2);
            }
        }
    }

    private void newToolStripButton_Click(object sender, EventArgs e)
    {
        this.frmBaseMap_0 = new frmBaseMap(ref this.class18_0, ref this.frmMain_0);
        this.frmBaseMap_0.StartPosition = FormStartPosition.CenterParent;
        this.frmBaseMap_0.ShowDialog();
        this.frmBaseMap_0.Dispose();
        this.frmBaseMap_0 = null;
    }

    private void openToolStripButton_ButtonClick(object sender, EventArgs e)
    {
        this.class18_0.method_61();
    }

    public void parametersToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.frmParameters_0 != null)
        {
            if (!this.class10_settings_0.WindowedMode)
            {
                this.frmQuickSaveMain_0.Focus();
            }
            else
            {
                this.frmParameters_0.Close();
            }
        }
        else
        {
            this.frmParameters_0 = new frmParameters();
            this.frmParameters_0.MdiParent = this;
            this.frmParameters_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmParameters_0.Show();
        }
        OpenThisTab("Parameters");
    }

    private void undoToolStripDorpDown_DropDownOpening(object sender, EventArgs e)
    {
        List<Class20_u> class20_u_0 = this.class11_u_0.method_13();
        this.undoToolStripMenuItem.DropDownItems.Clear();
        for (int i = 0; i < class20_u_0.Count; i++)
        {
            ToolStripMenuItem item = new ToolStripMenuItem
            {
                Text = class20_u_0[i].string_0,
                Tag = class20_u_0[i].int_0
            };
            this.undoToolStripMenuItem.DropDownItems.Add(item);
        }
        if (class20_u_0.Count > 0) this.undoToolStripMenuItem.DropDown.Visible = true;
    }
    private void redoToolStripDorpDown_DropDownOpening(object sender, EventArgs e)
    {
        List<Class20_u> class20_u_0 = this.class11_u_0.method_14();
        this.redoToolStripMenuItem.DropDownItems.Clear();
        for (int i = 0; i < class20_u_0.Count; i++)
        {
            ToolStripMenuItem item = new ToolStripMenuItem
            {
                Text = class20_u_0[i].string_0,
                Tag = class20_u_0[i].int_0
            };
            this.redoToolStripMenuItem.DropDownItems.Add(item);
        }
        if (class20_u_0.Count > 0) this.redoToolStripMenuItem.DropDown.Visible = true;
    }

    private void copyToolStripButton_Click(object sender, EventArgs e)
    {
        if ((this.frmGridChart_0 != null) && this.frmGridChart_0.ContainsFocus)
        {
            this.frmGridChart_0.method_9();
        }
        else if ((this.frmDebug_0 != null) && this.frmDebug_0.ContainsFocus)
        {
            this.frmDebug_0.CopyLogToClip();
        }
        else
        {
            //Form activeMdiChild = base.ActiveMdiChild;
            Form activeMdiChild = null;

            if (this.frmDataGrid_0 != null && this.frmDataGrid_0.ContainsFocus) activeMdiChild = this.frmDataGrid_0;
            if (this.frmGridChart_0 != null && this.frmGridChart_0.ContainsFocus) activeMdiChild = this.frmGridChart_0;
            if (this.frmParameters_0 != null && this.frmParameters_0.ContainsFocus) activeMdiChild = this.frmParameters_0;
            if (this.frmDatalogGraphs_0 != null && this.frmDatalogGraphs_0.ContainsFocus) activeMdiChild = this.frmDatalogGraphs_0;
            if (this.frmDebug_0 != null && this.frmDebug_0.ContainsFocus) activeMdiChild = this.frmDebug_0;
            if (this.frmLivePlot_0 != null && this.frmLivePlot_0.ContainsFocus) activeMdiChild = this.frmLivePlot_0;
            if (this.frmQuickSaveMain_0 != null && this.frmQuickSaveMain_0.ContainsFocus) activeMdiChild = this.frmQuickSaveMain_0;
            if (this.frmActiveDatalog_0 != null && this.frmActiveDatalog_0.ContainsFocus) activeMdiChild = this.frmActiveDatalog_0;

            //if (this.ktable_0 != null && ktable_0.ContainsFocus) activeMdiChild = this.ktable_0;
            //if (this.obd0Table_0 != null && obd0Table_0.ContainsFocus) activeMdiChild = this.obd0Table_0;
            //if (this.frmOBD2Scan_0 != null && frmOBD2Scan_0.ContainsFocus) activeMdiChild = this.frmOBD2Scan_0;

            if (this.frmSettings_0 != null && frmSettings_0.ContainsFocus) activeMdiChild = this.frmSettings_0;
            if (this.frmSensorSetup_0 != null && frmSensorSetup_0.ContainsFocus) activeMdiChild = this.frmSensorSetup_0;
            if (this.frmShortKeys_0 != null && frmShortKeys_0.ContainsFocus) activeMdiChild = this.frmShortKeys_0;
            if (this.frmOstrichInfo_0 != null && frmOstrichInfo_0.ContainsFocus) activeMdiChild = this.frmOstrichInfo_0;
            if (this.frmOnboard_0 != null && frmOnboard_0.ContainsFocus) activeMdiChild = this.frmOnboard_0;
            if (this.frmHelp_0 != null && frmHelp_0.ContainsFocus) activeMdiChild = this.frmHelp_0;
            if (this.frmIgnitionSync_0 != null && frmIgnitionSync_0.ContainsFocus) activeMdiChild = this.frmIgnitionSync_0;
            if (this.frmHC05_0 != null && frmHC05_0.ContainsFocus) activeMdiChild = this.frmHC05_0;
            if (this.frmCPUBench_0 != null && frmCPUBench_0.ContainsFocus) activeMdiChild = this.frmCPUBench_0;
            if (this.frmBoostTableSetup_0 != null && frmBoostTableSetup_0.ContainsFocus) activeMdiChild = this.frmBoostTableSetup_0;
            if (this.frmBurner_0 != null && frmBurner_0.ContainsFocus) activeMdiChild = this.frmBurner_0;

            if (activeMdiChild != null)
            {
                bool DataCopied = false;
                try
                {
                    if (!DataCopied) DataCopied = CopyThisControl(((UserControl)((UserControl)((SplitContainer)activeMdiChild.ActiveControl).ActiveControl).ActiveControl).ActiveControl);
                }
                catch { }
                try
                {
                    if (!DataCopied) DataCopied = CopyThisControl(((UserControl)((SplitContainer)activeMdiChild.ActiveControl).ActiveControl).ActiveControl);
                }
                catch { }
                try
                {
                    if (!DataCopied) DataCopied = CopyThisControl(((UserControl)activeMdiChild.ActiveControl).ActiveControl);
                }
                catch { }

                if (!DataCopied) this.class17_0.frmMain_0.LogThis("Unable to find content to copy to clipboard");
            }
        }
    }

    private bool CopyThisControl(Control ThisControl)
    {
        bool DataCopied = false;
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.TextBox")
        {
            if (TryCopyThisItem((TextBox)ThisControl)) DataCopied = true;
        }
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.NumericUpDown")
        {
            if (TryCopyThisItem((NumericUpDown) ThisControl)) DataCopied = true;
        }
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.Label")
        {
            if (TryCopyThisItem((Label) ThisControl)) DataCopied = true;
        }
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.DataGridView")
        {
            if (TryCopyThisItem((DataGridView)ThisControl)) DataCopied = true;
        }
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.ComboBox")
        {
            if (TryCopyThisItem((ComboBox)ThisControl)) DataCopied = true;
        }
        if (!DataCopied)
        {
            if (TryCopyThisItem(ThisControl)) DataCopied = true;
        }

        return DataCopied;
    }

    //##############################################################

    private bool TryCopyThisItem(Label activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                Clipboard.SetDataObject(activeControl.Text);
                this.class17_0.frmMain_0.LogThis("Value:" + activeControl.Text + " copied to clipboard");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    private bool TryCopyThisItem(NumericUpDown activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                Clipboard.SetDataObject(activeControl.Value.ToString());
                this.class17_0.frmMain_0.LogThis("Value:" + activeControl.Value.ToString() + " copied to clipboard");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    private bool TryCopyThisItem(TextBox activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                Clipboard.SetDataObject(activeControl.SelectedText);
                this.class17_0.frmMain_0.LogThis("Value:" + activeControl.SelectedText + " copied to clipboard");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    private bool TryCopyThisItem(DataGridView activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                string newline = "\n";
                string tab = "\t";
                StringBuilder clipboard_string = new StringBuilder();

                for (int i = 0; i < activeControl.Rows.Count; i++)
                {
                    int TabCount = 0;
                    for (int i2 = 0; i2 < activeControl.Rows[i].Cells.Count; i2++)
                    {
                        if (activeControl.Rows[i].Cells[i2].Selected)
                        {
                            if (TabCount > 0) clipboard_string.Append(tab);
                            clipboard_string.Append(activeControl.Rows[i].Cells[i2].Value);
                            TabCount++;
                        }

                        if (i2 == (activeControl.Rows[i].Cells.Count - 1)) clipboard_string.Append(newline);
                    }
                }

                Clipboard.SetDataObject(clipboard_string.ToString());
                this.class17_0.frmMain_0.LogThis("Grid values copied to clipboard");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    private bool TryCopyThisItem(ComboBox activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                Clipboard.SetDataObject(activeControl.Text);
                this.class17_0.frmMain_0.LogThis("Value:" + activeControl.Text + " copied to clipboard");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    //Universal
    private bool TryCopyThisItem(Control activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                Clipboard.SetDataObject(activeControl.Text);
                this.class17_0.frmMain_0.LogThis("Value:" + activeControl.Text + " copied to clipboard");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    //##############################################################
    //##############################################################
    //##############################################################

    private void pasteToolStripButton_Click(object sender, EventArgs e)
    {
        if ((this.frmGridChart_0 != null) && this.frmGridChart_0.ContainsFocus)
        {
            this.frmGridChart_0.method_10();
        }
        else
        {
            //Form activeMdiChild = base.ActiveMdiChild;
            Form activeMdiChild = null;

            if (this.frmDataGrid_0 != null && this.frmDataGrid_0.ContainsFocus) activeMdiChild = this.frmDataGrid_0;
            if (this.frmGridChart_0 != null && this.frmGridChart_0.ContainsFocus) activeMdiChild = this.frmGridChart_0;
            if (this.frmParameters_0 != null && this.frmParameters_0.ContainsFocus) activeMdiChild = this.frmParameters_0;
            if (this.frmDatalogGraphs_0 != null && this.frmDatalogGraphs_0.ContainsFocus) activeMdiChild = this.frmDatalogGraphs_0;
            if (this.frmDebug_0 != null && this.frmDebug_0.ContainsFocus) activeMdiChild = this.frmDebug_0;
            if (this.frmLivePlot_0 != null && this.frmLivePlot_0.ContainsFocus) activeMdiChild = this.frmLivePlot_0;
            if (this.frmQuickSaveMain_0 != null && this.frmQuickSaveMain_0.ContainsFocus) activeMdiChild = this.frmQuickSaveMain_0;
            if (this.frmActiveDatalog_0 != null && this.frmActiveDatalog_0.ContainsFocus) activeMdiChild = this.frmActiveDatalog_0;

            //if (this.ktable_0 != null && ktable_0.ContainsFocus) activeMdiChild = this.ktable_0;
            //if (this.obd0Table_0 != null && obd0Table_0.ContainsFocus) activeMdiChild = this.obd0Table_0;
            //if (this.frmOBD2Scan_0 != null && frmOBD2Scan_0.ContainsFocus) activeMdiChild = this.frmOBD2Scan_0;

            if (this.frmSettings_0 != null && frmSettings_0.ContainsFocus) activeMdiChild = this.frmSettings_0;
            if (this.frmSensorSetup_0 != null && frmSensorSetup_0.ContainsFocus) activeMdiChild = this.frmSensorSetup_0;
            if (this.frmShortKeys_0 != null && frmShortKeys_0.ContainsFocus) activeMdiChild = this.frmShortKeys_0;
            if (this.frmOstrichInfo_0 != null && frmOstrichInfo_0.ContainsFocus) activeMdiChild = this.frmOstrichInfo_0;
            if (this.frmOnboard_0 != null && frmOnboard_0.ContainsFocus) activeMdiChild = this.frmOnboard_0;
            if (this.frmHelp_0 != null && frmHelp_0.ContainsFocus) activeMdiChild = this.frmHelp_0;
            if (this.frmIgnitionSync_0 != null && frmIgnitionSync_0.ContainsFocus) activeMdiChild = this.frmIgnitionSync_0;
            if (this.frmHC05_0 != null && frmHC05_0.ContainsFocus) activeMdiChild = this.frmHC05_0;
            if (this.frmCPUBench_0 != null && frmCPUBench_0.ContainsFocus) activeMdiChild = this.frmCPUBench_0;
            if (this.frmBoostTableSetup_0 != null && frmBoostTableSetup_0.ContainsFocus) activeMdiChild = this.frmBoostTableSetup_0;
            if (this.frmBurner_0 != null && frmBurner_0.ContainsFocus) activeMdiChild = this.frmBurner_0;

            if (activeMdiChild != null)
            {
                bool DataPasted = false;
                try
                {
                    if (!DataPasted) DataPasted = PasteThisControl(((UserControl)((UserControl)((SplitContainer)activeMdiChild.ActiveControl).ActiveControl).ActiveControl).ActiveControl);
            }
                catch { }
                try
                {
                    if (!DataPasted) DataPasted = PasteThisControl(((UserControl)((SplitContainer)activeMdiChild.ActiveControl).ActiveControl).ActiveControl);
                }
                catch { }
                try
                {
                    if (!DataPasted) DataPasted = PasteThisControl(((UserControl)activeMdiChild.ActiveControl).ActiveControl);
                }
                catch { }

                if (!DataPasted) this.class17_0.frmMain_0.LogThis("Unable to find the control to paste clipboard content");
            }
        }
    }

    private bool PasteThisControl(Control ThisControl)
    {
        bool DataPasted = false;
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.TextBox")
        {
            if (TryPasteThisItem((TextBox)ThisControl)) DataPasted = true;
        }
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.NumericUpDown")
        {
            if (TryPasteThisItem((NumericUpDown)ThisControl)) DataPasted = true;
        }
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.DataGridView")
        {
            if (TryPasteThisItem((DataGridView)ThisControl)) DataPasted = true;
        }
        if (ThisControl.GetType().ToString() == "System.Windows.Forms.ComboBox")
        {
            if (TryPasteThisItem((ComboBox)ThisControl)) DataPasted = true;
        }
        if (!DataPasted)
        {
            if (TryPasteThisItem(ThisControl)) DataPasted = true;
        }

        return DataPasted;
    }

    //##############################################################

    private bool TryPasteThisItem(NumericUpDown activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                activeControl.Value = decimal.Parse(Clipboard.GetText());
                this.class17_0.frmMain_0.LogThis("Clipboard value:" + activeControl.Value + " paste in NumericUpDown");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    private bool TryPasteThisItem(TextBox activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                activeControl.SelectedText = Clipboard.GetText();
                this.class17_0.frmMain_0.LogThis("Clipboard value:" + activeControl.SelectedText + " paste in Textbox");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }
    private bool TryPasteThisItem(DataGridView activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                IDataObject dataObject;
                char[] separator = new char[] { '\r', '\n' };
                char[] chArray2 = new char[] { '\t' };
                try
                {
                    dataObject = Clipboard.GetDataObject();
                }
                catch (Exception)
                {
                    return ItemCopied;
                }

                string data = (string)dataObject.GetData(DataFormats.Text);
                if (!(data == string.Empty) && (data != null))
                {
                    DataGridViewSelectedCellCollection selectedCells = activeControl.SelectedCells;

                    int[] numArray = this.GetGridSelectionSize(activeControl);
                    string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    string[] strArray2 = strArray[0].Split(chArray2, StringSplitOptions.RemoveEmptyEntries);
                    int num = strArray.Length * strArray2.Length;
                    if (selectedCells.Count != num)
                    {
                        MessageBox.Show(Form.ActiveForm, "Clipboard doesn't fit selection");
                    }
                    else
                    {
                        strArray2 = null;
                        int index = 0;
                        int num3 = 0;
                        this.class18_0.method_156("Clipboard paste in table: " + this.class18_0.method_4().ToString(), true);
                        for (int i = numArray[1]; i <= numArray[3]; i++)
                        {
                            strArray2 = strArray[num3].Split(chArray2, StringSplitOptions.RemoveEmptyEntries);
                            index = 0;
                            for (int j = numArray[0]; j <= numArray[2]; j++)
                            {
                                activeControl[j, i].Value = strArray2[index];
                                index++;
                            }
                            num3++;
                        }
                        this.class18_0.method_154();
                        activeControl.Invalidate();
                        ItemCopied = true;
                    }
                }
            }
        }
        catch { }
        return ItemCopied;
    }

    private bool TryPasteThisItem(ComboBox activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                activeControl.Text = Clipboard.GetText();
                this.class17_0.frmMain_0.LogThis("Clipboard value:" + activeControl.Text + " paste in ComboBox");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }
    private bool TryPasteThisItem(Control activeControl)
    {
        bool ItemCopied = false;
        try
        {
            if (activeControl != null)
            {
                activeControl.Text = Clipboard.GetText();
                this.class17_0.frmMain_0.LogThis("Clipboard value:" + activeControl.Text + " paste in Control");
                ItemCopied = true;
            }
        }
        catch { }
        return ItemCopied;
    }

    public int[] GetGridSelectionSize(DataGridView activeControl)
    {
        DataGridViewSelectedCellCollection selectedCells = activeControl.SelectedCells;
        int columnIndex = 0xff;
        int num2 = 0;
        int rowIndex = 0xff;
        int num4 = 0;
        foreach (DataGridViewCell cell in selectedCells)
        {
            if (cell.ColumnIndex < columnIndex) columnIndex = cell.ColumnIndex;
            if (cell.RowIndex < rowIndex) rowIndex = cell.RowIndex;
        }
        foreach (DataGridViewCell cell2 in selectedCells)
        {
            if (cell2.ColumnIndex > num2) num2 = cell2.ColumnIndex;
            if (cell2.RowIndex > num4) num4 = cell2.RowIndex;
        }
        if (num2 > (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
        {
            num2 = this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1;
        }
        return new int[] { columnIndex, rowIndex, num2, num4 };
    }

    //#############################################################
    //#############################################################
    //#############################################################

    private void redoToolStripDorpDown_ButtonClick(object sender, EventArgs e)
    {
        this.class11_u_0.method_7();
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_70();
    }

    private void saveToolStripButton_Click(object sender, EventArgs e)
    {
        this.class18_0.method_69();
    }

    public void sensorToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.frmDataGrid_0 != null)
        {
            this.frmDataGrid_0.Focus();
            GC.Collect(3, GCCollectionMode.Forced);
        }
        else
        {
            this.frmDataGrid_0 = new frmDataGrid();
            this.frmDataGrid_0.MdiParent = this;
            this.frmDataGrid_0.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.frmMain_0);
            this.frmDataGrid_0.Show();
        }
        OpenThisTab("Datalog");
    }

    private void OpenThisTab(string ThisTab)
    {
        if (!this.class10_settings_0.WindowedMode)
        {
            bool TabIsSelected = false;
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                if (this.tabControl1.TabPages[i].Text.ToString() == ThisTab)
                {
                    this.tabControl1.SelectTab(i);
                    TabIsSelected = true;
                    i = this.tabControl1.TabPages.Count + 1;
                }
            }
            //############
            if (!TabIsSelected)
            {
                for (int i = 0; i < this.tabControl2.TabPages.Count; i++)
                {
                    if (this.tabControl2.TabPages[i].Text.ToString() == ThisTab)
                    {
                        this.tabControl2.SelectTab(i);
                        TabIsSelected = true;
                        i = this.tabControl2.TabPages.Count + 1;
                    }
                }
            }
            //############
            if (!TabIsSelected)
            {
                for (int i = 0; i < this.tabControl3.TabPages.Count; i++)
                {
                    if (this.tabControl3.TabPages[i].Text.ToString() == ThisTab)
                    {
                        this.tabControl3.SelectTab(i);
                        TabIsSelected = true;
                        i = this.tabControl3.TabPages.Count + 1;
                    }
                }
            }
            //############
            if (!TabIsSelected)
            {
                for (int i = 0; i < this.tabControl4.TabPages.Count; i++)
                {
                    if (this.tabControl4.TabPages[i].Text.ToString() == ThisTab)
                    {
                        this.tabControl4.SelectTab(i);
                        TabIsSelected = true;
                        i = this.tabControl4.TabPages.Count + 1;
                    }
                }
            }
            //############
            if (!TabIsSelected)
            {
                for (int i = 0; i < this.tabControl5.TabPages.Count; i++)
                {
                    if (this.tabControl5.TabPages[i].Text.ToString() == ThisTab)
                    {
                        this.tabControl5.SelectTab(i);
                        TabIsSelected = true;
                        i = this.tabControl5.TabPages.Count + 1;
                    }
                }
            }
        }
    }

    public void tablesToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.Focus();
        }
        else
        {
            this.frmGridChart_0 = new FrmGridChart();
            this.frmGridChart_0.method_2(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.class12_afrT_0, ref this.class11_u_0, ref this.frmMain_0);
            this.frmGridChart_0.MdiParent = this;
            this.frmGridChart_0.Show();
            this.frmGridChart_0.Focus();
        }
        OpenThisTab("Tables");
    }

    public void toolDtClose_Click(object sender, EventArgs e)
    {
        this.class17_0.method_75();
    }

    public void toolDtConnect_Click(object sender, EventArgs e)
    {
        this.class17_0.SetDemonDatalogCheck(true);
        /*if (this.class10_0.emulatorMode_0 == EmulatorMode.Demon) this.class25_0.method_1(true);
        else this.class17_0.method_36();*/
        this.class17_0.method_36();
    }

    public void toolDtOpen_Click(object sender, EventArgs e)
    {
        this.class17_0.method_OpenLog();
    }

    public void toolDtRecord_Click(object sender, EventArgs e)
    {
        this.class17_0.method_StartRecord();
    }

    public void toolDtSave_Click(object sender, EventArgs e)
    {
        this.class17_0.method_SaveDatalog();
    }

    private void toolDtPause_Click(object sender, EventArgs e)
    {
        this.class17_0.method_72();
    }

    private void toolDtPeakClear_Click(object sender, EventArgs e)
    {
        if (this.frmDataDisplay_0 != null)
        {
            this.frmDataDisplay_0.method_2();
        }
    }

    private void toolDtPeakMax_Click(object sender, EventArgs e)
    {
        if (this.frmDataDisplay_0 != null)
        {
            this.frmDataDisplay_0.method_1();
            if (this.class10_settings_0.dtPeakShown) this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090_green;
            else this.toolDtPeakMax.Image = global::Properties.Resources.arrow_090;
        }
    }

    private void toolDtPlay_Click(object sender, EventArgs e)
    {
        this.class17_0.method_70();
    }

    private void toolDtPlayBack_Click(object sender, EventArgs e)
    {
        this.class17_0.method_74();
    }

    private void toolDtRec_Click(object sender, EventArgs e)
    {
        this.class17_0.method_StartRecord();
    }

    private void toolDtPlayDouble_Click(object sender, EventArgs e)
    {
        this.class17_0.method_73();
    }

    private void toolDtSave_MouseEnter(object sender, EventArgs e)
    {
        this.toolDtSave.Enabled = this.class17_0.method_54();
    }

    private void toolDtStop_Click(object sender, EventArgs e)
    {
        this.class17_0.method_71();
    }

    private void toolsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.killInjectorsToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_88) == 0xff;
        }
    }

    public void OpenSettingMenu(string ThisTab)
    {
        if (this.frmSettings_0 != null)
        {
            this.frmSettings_0.Dispose();
            this.frmSettings_0 = null;
        }
        this.frmSettings_0 = new frmSettings();
        this.frmSettings_0.StartPosition = FormStartPosition.CenterParent;
        this.frmSettings_0.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.class25_0, ref this.frmMain_0);
        if (ThisTab != "") this.frmSettings_0.OpenThisTab(ThisTab);
        this.frmSettings_0.ShowDialog();
        try
        {
            this.frmSettings_0.Dispose();
        }
        catch { }
        this.frmSettings_0 = null;
        GC.Collect(3, GCCollectionMode.Forced);
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        OpenSettingMenu("");
    }

    private void undoToolStripDorpDown_ButtonClick(object sender, EventArgs e)
    {
        this.class11_u_0.method_4();
        this.undoToolStripMenuItem.Enabled = this.class11_u_0.method_1();
        this.undoToolStripDropDown.Enabled = this.class11_u_0.method_1();

        this.undoHistoryToolStripMenuItem.Enabled = this.class11_u_0.method_1();
        this.toolStripButtonUndoHistory.Enabled = this.class11_u_0.method_1();
    }

    private void verifyChipToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        if (this.class10_settings_0.BurnerSoftware == 0)
        {
            this.frmBurner_0 = new frmBurner();
            this.frmBurner_0.StartPosition = FormStartPosition.CenterParent;
            this.frmBurner_0.method_0(ref this.class5_burn_0, ref this.class18_0);
            this.frmBurner_0.Tag = int.Parse(((ToolStripMenuItem)sender).Tag.ToString());
            this.frmBurner_0.ShowDialog();
            this.frmBurner_0.Close();
            this.frmBurner_0.Dispose();
            this.frmBurner_0 = null;
        }
        else
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = this.class10_settings_0.BurnerLocation;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
            }
            catch
            {
                LogThisMain("Can't start '" + this.class10_settings_0.BurnerLocation + "'");
            }
        }
    }

    private delegate void Delegate39(ref Struct12 struct12_0);

    private delegate void Delegate40(int int_0);

    private delegate void Delegate41(EmulatorState emulatorState_0, int int_0, bool bool_0);

    private delegate void Delegate42(Struct12 struct12_0);

    private void trackBar_0_Scroll(object sender, EventArgs e)
    {
        if (this.class17_0.method_63_HasLogsFileOpen())
        {
            this.class17_0.method_69((long)this.trackBar_0.Value);
            this.class17_0.long_1 = this.trackBar_0.Value;
        }
    }

    public void SerialMenuToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*if (this.frmDatalogMenu_0 != null)
        {
            this.frmDatalogMenu_0.Show();
            this.frmDatalogMenu_0.Focus();
        }
        else
        {
            this.frmDatalogMenu_0 = new frmDatalogMenu(ref class17_0, ref class18_0, ref this.frmMain_0, ref this.class25_0);
            this.frmDatalogMenu_0.MdiParent = this;
            this.frmDatalogMenu_0.Show();
            this.frmDatalogMenu_0.Focus();
        }*/
    }

    private void registerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*this.frmRegister_0 = new frmReg(ref this.frmMain_0);
        this.frmRegister_0.StartPosition = FormStartPosition.CenterParent;
        this.frmRegister_0.ShowDialog();
        this.frmRegister_0.Dispose();
        this.frmRegister_0 = null;*/
    }

    private void aboutBMTuneToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmAboutBox_0 = new frmAboutBox(ref this.frmMain_0);
        this.frmAboutBox_0.StartPosition = FormStartPosition.CenterParent;
        this.frmAboutBox_0.ShowDialog();
        this.frmAboutBox_0.Dispose();
        this.frmAboutBox_0 = null;
    }

    private void shortcutKeysToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        this.frmShortKeys_0 = new frmShortKeys(ref this.frmMain_0);
        this.frmShortKeys_0.StartPosition = FormStartPosition.CenterParent;
        this.frmShortKeys_0.ShowDialog();
        this.frmShortKeys_0.Dispose();
        this.frmShortKeys_0 = null;
    }

    private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class15_0.CheckForUpdate(true);
    }

    private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        this.frmHelp_0 = new frmHelp();
        this.frmHelp_0.ShowDialog();
        this.frmHelp_0.Dispose();
        this.frmHelp_0 = null;
    }

    private void debugLogsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmDebug_0 != null)
        {
            this.frmDebug_0.Focus();
        }
        else
        {
            this.frmDebug_0 = new frmDebug();
            this.frmDebug_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmDebug_0.MdiParent = this;
            this.frmDebug_0.Show();
        }
        OpenThisTab("Debug Logs");
    }

    private void baseromConverterToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmBaseromConvert_0 = new frmBaseromConvert(ref this.class18_0);
        this.frmBaseromConvert_0.StartPosition = FormStartPosition.CenterParent;
        this.frmBaseromConvert_0.ShowDialog();
        this.frmBaseromConvert_0.Dispose();
        this.frmBaseromConvert_0 = null;
    }

    private void openLogAfterRecordToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_26 = this.openLogAfterRecordToolStripMenuItem.Checked;
    }

    public void OpenScalarMenu()
    {
        if (this.frmMapScalar_0 != null)
        {
            this.frmMapScalar_0.Focus();
        }
        else
        {
            this.frmMapScalar_0 = new frmMapScalar();
            this.frmMapScalar_0.method_0(ref this.class18_0);
            this.frmMapScalar_0.ShowDialog();
            this.frmMapScalar_0.Dispose();
            this.frmMapScalar_0 = null;
        }
    }

    private void scalarSetupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenScalarMenu();
    }

    private void openLogAfterRecordToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void dlTableToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        if (this.dlTableToolStripMenuItem.Checked)
        {
            this.class10_settings_0.method_9(DataloggingTable.tableMinimal);
        }
        else
        {
            this.class10_settings_0.method_9(DataloggingTable.tableMain);
        }
    }

    public void SetImageBackgrounds()
    {
        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back1.bmp"))
        {
            Bitmap ThisB = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back1.bmp");
            this.BackgroundImage = new Bitmap(ThisB);
            ThisB.Dispose();
            ThisB = null;
        }
        else this.BackgroundImage = null;

        if (this.frmGridChart_0 != null) this.frmGridChart_0.SetImageBackgrounds();
    }

    private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.RefreshPage();
    }

    private void livePlotsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmLivePlot_0 != null)
        {
            this.frmLivePlot_0.Focus();
        }
        else
        {
            this.frmLivePlot_0 = new frmLivePlot();
            this.frmLivePlot_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmLivePlot_0.MdiParent = this;
            this.frmLivePlot_0.Show();
        }
        OpenThisTab("LivePlot");
    }

    private void dlAutoSave_Click(object sender, EventArgs e)
    {
        /*if (!this.dlAutoSave.Checked)
        {
            this.class17_0.method_24(false);
        }
        else
        {
            this.frmDatalogAutoSave_0 = new frmDatalogAutoSave();
            this.frmDatalogAutoSave_0.method_0(ref this.class18_0, ref this.class17_0);
            this.frmDatalogAutoSave_0.ShowDialog();
            this.frmDatalogAutoSave_0.Close();
            this.frmDatalogAutoSave_0.Dispose();
            this.frmDatalogAutoSave_0 = null;
            //this.dlAutoSave.Checked = this.class17_0.method_23() || this.class17_0.method_25();
        }*/
    }

    private void uploadBaseromOnlineToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmUploadBaserom_0 != null)
        {
            this.frmUploadBaserom_0.Focus();
        }
        else
        {
            this.frmUploadBaserom_0 = new frmUploadBaserom(ref this.class18_0);
            this.frmUploadBaserom_0.ShowDialog();
            this.frmUploadBaserom_0 = null;
        }
    }

    private void saveQuickToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class21_snap_0.method_2();
        this.snapshotToolStripMenuItem_Click(null, null);
    }

    private void snapshotToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmQuickSaveMain_0 != null)
        {
            if (!this.class10_settings_0.WindowedMode)
            {
                this.frmQuickSaveMain_0.Focus();
            }
            else
            {
                this.frmQuickSaveMain_0.Dispose();
                this.frmQuickSaveMain_0 = null;
            }
        }
        this.frmQuickSaveMain_0 = new frmQuickSaveMain();
        this.frmQuickSaveMain_0.MdiParent = this;
        this.frmQuickSaveMain_0.method_0(ref this.class21_snap_0, ref this.class18_0);
        this.frmQuickSaveMain_0.Show();
        OpenThisTab("Snapshots");
    }

    private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmConsole_0 != null)
        {
            this.frmConsole_0.Dispose();
            this.frmConsole_0 = null;
        }
        this.frmConsole_0 = new frmConsole(ref this.frmMain_0, ref this.class18_0);
        this.frmConsole_0.Show();
    }

    private void InformationsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmOstrichInfo_0 != null)
        {
            this.frmOstrichInfo_0.Dispose();
            this.frmOstrichInfo_0 = null;
        }
        this.frmOstrichInfo_0 = new frmOstrichInfo();
        this.frmOstrichInfo_0.StartPosition = FormStartPosition.CenterParent;
        this.frmOstrichInfo_0.method_0(ref this.class18_0, ref this.class25_0);
        this.frmOstrichInfo_0.ShowDialog();
        this.frmOstrichInfo_0.Dispose();
        this.frmOstrichInfo_0 = null;
    }

    private void ToolStripButtonUndoHistory_Click(object sender, EventArgs e)
    {
        this.class11_u_0.UndoALL();
        this.undoToolStripMenuItem.Enabled = this.class11_u_0.method_1();
        this.undoToolStripDropDown.Enabled = this.class11_u_0.method_1();

        this.undoHistoryToolStripMenuItem.Enabled = this.class11_u_0.method_1();
        this.toolStripButtonUndoHistory.Enabled = this.class11_u_0.method_1();
    }

    private void AdjustSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.toolBtnAdjSel_Click(sender, e);
    }

    private void IncreaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.toolIncrease_Click(sender, e);
    }

    private void DecreaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.toolDecrease_Click(sender, e);
    }

    private void InterpolateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.interpolateXYtoolStripButton_Click(sender, e);
    }

    private void InterpolateHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.interplotaeRToolStripButton_Click(sender, e);
    }

    private void InterpolateVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.interplolateCToolStripButton_Click(sender, e);
    }

    private void SmoothMapsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.toolSmooth_Click(sender, e);
    }

    private void OffToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("FP setting");
        if (this.offToolStripMenuItem.Checked)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_78, 0xfe);
        }
        else
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_78, 0);
        }
        this.class18_0.method_153();
    }

    private void drainFPtoolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("FP setting");
        if (this.onDrainTankToolStripMenuItem.Checked)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_78, 0xff);
        }
        else
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_78, 0);
        }
        this.class18_0.method_153();
    }

    private void ToolsToolStripMenuItem_DropDownOpening_1(object sender, EventArgs e)
    {

    }

    private void OptionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.killInjectorsToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_88) == 0xff;
            this.onDrainTankToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_78) == 0xff;
            this.offToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_78) == 0xfe;
            this.useSecondaryMapsOnlyToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_25) == 0xff;
            this.useHighCamsMapsOnlyToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_24) == 0xff;

            this.toolTunerFollowVtec.Checked = this.class10_settings_0.bool_42;
            this.toolTunerFollowDualTables.Checked = this.class10_settings_0.bool_44;
            this.toolTunerSmartTrack.Checked = this.class10_settings_0.bool_45;
            this.toolTunerMapTrail.Checked = this.class10_settings_0.bool_43;
        }

        SetTestOutputsInfos();
    }

    private void followSecondaryMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_44 = this.toolTunerFollowDualTables.Checked;
    }

    private void followVtecToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_42 = this.toolTunerFollowVtec.Checked;
    }

    private void useHighCamToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Use High Cam Only setting");
        if (this.useHighCamsMapsOnlyToolStripMenuItem.Checked)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_24, 0xff);
        }
        else
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_24, 0);
        }
        this.class18_0.method_153();
    }

    private void useSecMapsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Secondary Maps Only setting");
        if (this.useSecondaryMapsOnlyToolStripMenuItem.Checked)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_25, 0xff);
        }
        else
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_25, 0);
        }
        this.class18_0.method_153();
    }

    private void MapTraceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_43 = this.toolTunerMapTrail.Checked;
        this.class18_0.method_53();
    }

    private void ToolTunerSmartTrack_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_45 = this.toolTunerSmartTrack.Checked;
        this.class10_settings_0.bool_42 = this.toolTunerSmartTrack.Checked;
    }

    public void GearLearn()
    {
        if (this.frmGearLearn_0 != null)
        {
            this.frmGearLearn_0.Focus();
        }
        else
        {
            this.frmGearLearn_0 = new frmGearLearn();
            this.frmGearLearn_0.method_0(ref this.class18_0, ref this.class18_0.class17_0);
            this.frmGearLearn_0.ShowDialog();
            this.frmGearLearn_0.Dispose();
            this.frmGearLearn_0 = null;
        }
    }

    private void GearLearningToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GearLearn();
    }

    private void InjectorCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmParameters_0 != null)
        {
            this.frmParameters_0.Focus();
        }
        else
        {
            this.frmParameters_0 = new frmParameters();
            this.frmParameters_0.MdiParent = this;
            this.frmParameters_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmParameters_0.Show();
        }
        this.frmParameters_0.SelectPage("nInjector", "Injector Calibration");
    }

    private void TPSCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmParameters_0 != null)
        {
            this.frmParameters_0.Focus();
        }
        else
        {
            this.frmParameters_0 = new frmParameters();
            this.frmParameters_0.MdiParent = this;
            this.frmParameters_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmParameters_0.Show();
        }
        this.frmParameters_0.SelectPage("nTpsSensor", "TPS Sensor");
    }

    private void ClearLivePlotsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.ClearLivePlots();
    }

    private void ClearDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.ClearDatalog();
    }

    private void ClearRecordingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.ClearRecording();
    }

    private void ClearMapTraceTrailToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.ClearMapTrace();
    }

    private void ClearCELErrorsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.class17_0 != null) this.class17_0.method_30();
    }

    private void DebugLogsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        ClearLogs();
    }

    private void copyPrimaryMapsToSecondaryMapsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmCopyMaps_0 != null)
        {
            this.frmCopyMaps_0.Focus();
        }
        else
        {
            this.frmCopyMaps_0 = new frmCopyMaps();
            this.frmCopyMaps_0.method_0(ref this.class18_0);
            this.frmCopyMaps_0.Tag = 1;
            this.frmCopyMaps_0.ShowDialog();
            this.frmCopyMaps_0.Dispose();
            this.frmCopyMaps_0 = null;
        }
    }

    private void copySecondaryMapsToPrimaryMapsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmCopyMaps_0 != null)
        {
            this.frmCopyMaps_0.Focus();
        }
        else
        {
            this.frmCopyMaps_0 = new frmCopyMaps();
            this.frmCopyMaps_0.method_0(ref this.class18_0);
            this.frmCopyMaps_0.Tag = 2;
            this.frmCopyMaps_0.ShowDialog();
            this.frmCopyMaps_0.Dispose();
            this.frmCopyMaps_0 = null;
        }
    }

    private void rpmScalarsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Copy Rpm Scalar");
        for (byte j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j = (byte)(j + 1))
        {
            int num4 = this.class18_0.method_159(j);
            switch (this.class18_0.method_4())
            {
                case SelectedTable.undefined:
                    this.LogThis("rpm scalar copy error");
                    break;
                    //throw new Exception("rpm scalar copy");

                case SelectedTable.ign1_lo:
                    this.class18_0.method_169(j, num4, SelectedTable.ign2_lo);
                    break;

                case SelectedTable.ign1_hi:
                    this.class18_0.method_169(j, num4, SelectedTable.ign2_hi);
                    break;

                case SelectedTable.fuel1_lo:
                    this.class18_0.method_169(j, num4, SelectedTable.fuel2_lo);
                    break;

                case SelectedTable.fuel1_hi:
                    this.class18_0.method_169(j, num4, SelectedTable.fuel2_hi);
                    break;

                case SelectedTable.ign2_lo:
                    this.class18_0.method_169(j, num4, SelectedTable.ign1_hi);
                    break;

                case SelectedTable.ign2_hi:
                    this.class18_0.method_169(j, num4, SelectedTable.ign1_lo);
                    break;

                case SelectedTable.fuel2_lo:
                    this.class18_0.method_169(j, num4, SelectedTable.fuel1_hi);
                    break;

                case SelectedTable.fuel2_hi:
                    this.class18_0.method_169(j, num4, SelectedTable.fuel1_lo);
                    break;

                case SelectedTable.ve_lo:
                case SelectedTable.ve_hi:
                    break;

                default:
                    this.LogThis("rpm scalar copy error");
                    break;
                    //throw new Exception("rpm scalar copy");
            }
        }
        this.class18_0.method_153();
    }

    private void mapScalarsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Copy Map Scalar");
        for (byte i = 0; i < this.class18_0.method_33(); i = (byte)(i + 1))
        {
            byte num2 = (byte)this.class18_0.method_165(i);
            if (!this.class18_0.method_39())
            {
                this.class18_0.method_171(i, num2, SelectedTable.fuel2_hi);
            }
            else
            {
                this.class18_0.method_171(i, num2, SelectedTable.fuel1_hi);
            }
        }
        this.class18_0.method_153();
    }

    private void PrimaryLowIgnitionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            int MapIndex = 0;
            if (this.class18_0.method_39()) MapIndex += 4;
            this.frmGridChart_0.SelectMap(MapIndex);
        }
    }

    private void PrimaryHighIgnitionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            int MapIndex = 1;
            if (this.class18_0.method_39()) MapIndex += 4;
            this.frmGridChart_0.SelectMap(MapIndex);
        }
    }

    private void PrimaryLowFuelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            int MapIndex = 2;
            if (this.class18_0.method_39()) MapIndex += 4;
            this.frmGridChart_0.SelectMap(MapIndex);
        }
    }

    private void PrimaryHighFuelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            int MapIndex = 3;
            if (this.class18_0.method_39()) MapIndex += 4;
            this.frmGridChart_0.SelectMap(MapIndex);
        }
    }

    private void PrimaryTablesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            int num = (int)this.class18_0.method_4();
            if (num >= 5)
            {
                num -= 4;
                this.frmGridChart_0.SelectMap(num - 1);
            }
        }
    }

    private void SecondaryTablesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            int num = (int)this.class18_0.method_4();
            if (num < 5)
            {
                num += 4;
                this.frmGridChart_0.SelectMap(num - 1);
            }
        }
    }

    public void SetMapsButtons()
    {
        int num = (int)this.class18_0.method_4();

        if (num < 5)
        {
            primaryTablesToolStripMenuItem.Checked = true;
            secondaryTablesToolStripMenuItem.Checked = false;

            toolStripButtonPrimary.Checked = true;
            toolStripButtonSecondary.Checked = false;
        }
        else
        {
            primaryTablesToolStripMenuItem.Checked = false;
            secondaryTablesToolStripMenuItem.Checked = true;

            toolStripButtonPrimary.Checked = false;
            toolStripButtonSecondary.Checked = true;
        }

        if (num >= 5) num -= 4;
        if (num == 0) num = 1;

        if (num == 1)
        {
            primaryLowIgnitionToolStripMenuItem.Checked = true;
            primaryHighIgnitionToolStripMenuItem.Checked = false;
            primaryLowFuelToolStripMenuItem.Checked = false;
            primaryHighFuelToolStripMenuItem.Checked = false;

            toolStripButtonLowIgn.Checked = true;
            toolStripButtonHighIgn.Checked = false;
            toolStripButtonLowFuel.Checked = false;
            toolStripButtonHighFuel.Checked = false;
        }
        else if (num == 2)
        {
            primaryLowIgnitionToolStripMenuItem.Checked = false;
            primaryHighIgnitionToolStripMenuItem.Checked = true;
            primaryLowFuelToolStripMenuItem.Checked = false;
            primaryHighFuelToolStripMenuItem.Checked = false;

            toolStripButtonLowIgn.Checked = false;
            toolStripButtonHighIgn.Checked = true;
            toolStripButtonLowFuel.Checked = false;
            toolStripButtonHighFuel.Checked = false;
        }
        else if (num == 3)
        {
            primaryLowIgnitionToolStripMenuItem.Checked = false;
            primaryHighIgnitionToolStripMenuItem.Checked = false;
            primaryLowFuelToolStripMenuItem.Checked = true;
            primaryHighFuelToolStripMenuItem.Checked = false;

            toolStripButtonLowIgn.Checked = false;
            toolStripButtonHighIgn.Checked = false;
            toolStripButtonLowFuel.Checked = true;
            toolStripButtonHighFuel.Checked = false;
        }
        else if (num == 4)
        {
            primaryLowIgnitionToolStripMenuItem.Checked = false;
            primaryHighIgnitionToolStripMenuItem.Checked = false;
            primaryLowFuelToolStripMenuItem.Checked = false;
            primaryHighFuelToolStripMenuItem.Checked = true;

            toolStripButtonLowIgn.Checked = false;
            toolStripButtonHighIgn.Checked = false;
            toolStripButtonLowFuel.Checked = false;
            toolStripButtonHighFuel.Checked = true;
        }
    }

    private void mapValuesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectFuel();
    }
    private void aFToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectAFReading();
    }

    private void vETablesToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectVE();
    }

    private void aFTargetToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectAFTarget();
    }

    private void fuelDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectAFDiff();
    }

    public void SetMapsPresetButtons()
    {
        if (this.frmGridChart_0 != null)
        {
            this.mapValuesToolStripMenuItem.Checked = this.frmGridChart_0.toolStripButtonMapValue.Checked;
            this.aFTargetToolStripMenuItem1.Checked = this.frmGridChart_0.toolStripButtonAFTarget.Checked;
            this.aFToolStripMenuItem.Checked = this.frmGridChart_0.toolStripButtonAFReading.Checked;
            this.fuelDifferenceToolStripMenuItem.Checked = this.frmGridChart_0.toolStripButtonAFDiff.Checked;
            this.vETablesToolStripMenuItem1.Checked = this.frmGridChart_0.toolStripButtonVE.Checked;
            this.analog1Reading_Button.Checked = this.frmGridChart_0.analog1Reading_Button.Checked;
            this.analog2Reading_Button.Checked = this.frmGridChart_0.analog2Reading_Button.Checked;
            this.analog3Reading_Button.Checked = this.frmGridChart_0.analog3Reading_Button.Checked;

            this.toolStripButtonMapValues.Checked = this.frmGridChart_0.toolStripButtonMapValue.Checked;
            this.toolStripButtonAFTarget.Checked = this.frmGridChart_0.toolStripButtonAFTarget.Checked;
            this.toolStripButtonAFReading.Checked = this.frmGridChart_0.toolStripButtonAFReading.Checked;
            this.toolStripButtonAFDiff.Checked = this.frmGridChart_0.toolStripButtonVE.Checked;
            //this.vETablesToolStripMenuItem1.Checked = this.frmGridChart_0.vETablesToolStripMenuItem1.Checked;
            //this.analog1Reading_Button.Checked = this.frmGridChart_0.analog1Reading_Button.Checked;
            //this.analog2Reading_Button.Checked = this.frmGridChart_0.analog2Reading_Button.Checked;
            //this.analog3Reading_Button.Checked = this.frmGridChart_0.analog3Reading_Button.Checked;
        }
    }

    private void analog1Reading_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectAnalog1Reading();
    }

    private void analog2Reading_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectAnalog2Reading();
    }

    private void analog3Reading_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectAnalog3Reading();
    }

    private void FuelDuty_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectFuelDuty(0);
    }

    private void InjDurr_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectFuelDuty(1);
    }
    private void InjDuty_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null) this.frmGridChart_0.SelectFuelDuty(2);
    }

    public void SetFuelButtons()
    {
        if (this.frmGridChart_0 != null)
        {
            this.FuelRawToolStripMenuItem.Checked = this.frmGridChart_0.FuelRawToolStripMenuItem.Checked;
            this.FuelDutyToolStripMenuItem.Checked = this.frmGridChart_0.FuelDutyToolStripMenuItem.Checked;
            this.fuelInjDurToolStripMenuItem.Checked = this.frmGridChart_0.fuelInjDurToolStripMenuItem.Checked;
        }
    }

    private void WindowedModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DisposeAll();
        this.class10_settings_0.WindowedMode = windowedModeToolStripMenuItem.Checked;
        LoadPages();
    }

    private void FrmMain_ResizeEnd(object sender, EventArgs e)
    {
        //method_1();
        if (this.class10_settings_0 != null && this.class17_0 != null && this.class18_0 != null)
        {
            LoadPages();
        }
    }

    private void FrmMain_ResizeBegin(object sender, EventArgs e)
    {
        DisposeAll();
    }

    private void tabControl_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(TabPage))) e.Effect = DragDropEffects.Move;
        else e.Effect = DragDropEffects.None;
    }

    private void tabControl_DragDrop(object sender, DragEventArgs e)
    {
        TabControl control = (TabControl)sender;
        TabPage DropTab = (TabPage)(e.Data.GetData(typeof(TabPage)));
        bool Passed = true;

        for (int i = 0; i < control.TabPages.Count; i++)
        {
            if (control.TabPages[i].Name == DropTab.Name) Passed = false;
        }
        if (Passed)
        {
            control.TabPages.Add(DropTab);
            CheckEmptyPages();
        }
    }

    private void tabControl_MouseMove(object sender, MouseEventArgs e)
    {
        TabControl control = (TabControl)sender;

        if (e.Button == MouseButtons.Left)
        {
            CheckEmptyPagesDragging();
            control.DoDragDrop(control.SelectedTab, DragDropEffects.All);
        }
        else
        {
            CheckEmptyPages();
        }
    }

    private void FrmMain_Resize(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null && (base.WindowState == FormWindowState.Normal || base.WindowState == FormWindowState.Maximized))
        {
            if (base.WindowState != LastWindowsState && this.class17_0 != null && this.class18_0 != null) LoadPages();

            if (!this.class10_settings_0.WindowedMode)
            {
                this.splitContainer1_Left.SplitterDistance = this.class10_settings_0.TabsLeft_Split;
                this.splitContainer2_Top.SplitterDistance = this.class10_settings_0.TabsTop_Split;
                if (this.class10_settings_0.Tabs3_Show) this.splitContainer3_Bottom.SplitterDistance = this.class10_settings_0.TabsBottom_Split;
                if (this.class10_settings_0.Tabs4_Show) this.splitContainer5_BottomLeft.SplitterDistance = this.class10_settings_0.TabsBottomLeft_Split;
                if (this.class10_settings_0.Tabs5_Show) this.splitContainer6_Right.SplitterDistance = this.class10_settings_0.TabsRight_Split;
            }
        }
    }

    private void DonateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Process.Start("https://www.paypal.me/bouletmarc");
    }

    private void ActiveDatalogsThreadsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmActiveDatalog_0 != null)
        {
            this.frmActiveDatalog_0.Focus();
        }
        else
        {
            this.frmActiveDatalog_0 = new frmActiveDatalog();
            this.frmActiveDatalog_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmActiveDatalog_0.MdiParent = this;
            this.frmActiveDatalog_0.Show();
        }
        OpenThisTab("Datalogs Threads");
    }

    private void BluetoothProgrammerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmHC05_0 = new frmBluetooth();
        this.frmHC05_0.StartPosition = FormStartPosition.CenterParent;
        this.frmHC05_0.ShowDialog();
        this.frmHC05_0.Dispose();
        this.frmHC05_0 = null;
    }

    private void Create2TimerBin512kbToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmBinTool_0 = new frmBinTool(ref this.class10_settings_0, ref this.class18_0);
        this.frmBinTool_0.StartPosition = FormStartPosition.CenterParent;
        this.frmBinTool_0.ShowDialog();
        this.frmBinTool_0.Dispose();
        this.frmBinTool_0 = null;
    }

    private void PlayQuarterSpeedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.playDoubleSpeedToolStripMenuItem.Checked = false;
        this.playHalfSpeedToolStripMenuItem.Checked = false;
        this.toolDtForward.Checked = false;
        this.toolDtHalf.Checked = false;
        this.toolDtQuart.Checked = !this.toolDtQuart.Checked;
        this.playQuarterSpeedToolStripMenuItem.Checked = !this.playQuarterSpeedToolStripMenuItem.Checked;
        this.class17_0.method_73_2();
    }

    private void PlayHalfSpeedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.playDoubleSpeedToolStripMenuItem.Checked = false;
        this.playQuarterSpeedToolStripMenuItem.Checked = false;
        this.toolDtForward.Checked = false;
        this.toolDtQuart.Checked = false;
        this.playHalfSpeedToolStripMenuItem.Checked = !this.playHalfSpeedToolStripMenuItem.Checked;
        this.toolDtHalf.Checked = !this.toolDtHalf.Checked;
        this.class17_0.method_73_1();
    }

    private void ControlToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmDynoControl_0 != null)
        {
            this.frmDynoControl_0.Focus();
        }
        else
        {
            this.frmDynoControl_0 = new frmDynoControl();
            this.frmDynoControl_0.method_0(ref this.class18_0, ref this.frmMain_0);
            this.frmDynoControl_0.MdiParent = this;
            this.frmDynoControl_0.Show();
        }
    }

    private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!frmDynoSetup.Dyno_Connected)
        {
            if (this.class29_Dyno_0 == null)
            {
                this.class29_Dyno_0 = new Class29_Dyno(ref this.class18_0);
            }
            this.class29_Dyno_0.Connect();
            connectToolStripMenuItem.ForeColor = this.class10_settings_0.color_OnDark;
            dynoToolStripMenuItem.ForeColor = this.class10_settings_0.color_OnDark;
            connectToolStripMenuItem.Text = "Disconnect";
            frmDynoSetup.Dyno_Connected = true;
            statusDyno.Text = "Dyno:Connected";
            controlToolStripMenuItem.Enabled = true;
            statusDyno.ForeColor = this.class10_settings_0.color_OnDark;
        }
        else
        {
            if (this.class29_Dyno_0 == null)
            {
                this.class29_Dyno_0 = new Class29_Dyno(ref this.class18_0);
            }
            this.class29_Dyno_0.Disconnect();
            frmDynoSetup.Dyno_Connected = false;
            connectToolStripMenuItem.ForeColor = this.class10_settings_0.color_4;
            dynoToolStripMenuItem.ForeColor = this.class10_settings_0.color_4;
            connectToolStripMenuItem.Text = "Connect";
            statusDyno.Text = "Dyno:Disconnected";
            controlToolStripMenuItem.Enabled = false;
            statusDyno.ForeColor = this.class10_settings_0.color_4;
        }
    }

    private void SetupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmDynoSetup_0 = new frmDynoSetup(ref this.class10_settings_0);
        this.frmDynoSetup_0.StartPosition = FormStartPosition.CenterParent;
        this.frmDynoSetup_0.ShowDialog();
        this.frmDynoSetup_0.Dispose();
        this.frmDynoSetup_0 = null;
    }

    private void DynoTractionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.SelectDynoWSReading();
        }
    }

    private void DynoHPToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.SelectDynoHPReading();
        }
    }

    private void DynoNMToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.SelectDynoNMReading();
        }
    }

    private void DynoAUX1ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.SelectAUX1Reading();
        }
    }

    private void DynoAUX2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.SelectAUX2Reading();
        }
    }

    private void DynoAUX3ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.SelectAUX3Reading();
        }
    }

    private void DynoTHCToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.frmGridChart_0 != null)
        {
            this.frmGridChart_0.SelectTHCReading();
        }
    }

    private void OBD2ScanStripMenuItem_Click(object sender, EventArgs e)
    {
        /*this.frmOBD2Scan_0 = new frmOBD2Scan(ref this.class10_settings_0, ref this.Class34_Zip_0);
        this.frmOBD2Scan_0.StartPosition = FormStartPosition.CenterParent;
        this.frmOBD2Scan_0.ShowDialog();
        this.frmOBD2Scan_0.Dispose();
        this.frmOBD2Scan_0 = null;*/
    }

    private void ReinstallLastStableReleaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Process.Start(Application.StartupPath + @"\BMTune_Backup.exe");
        Environment.Exit(0);
    }

    private void bMDataloggerLCDDisplayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string Filename = "BMDatalogger.exe";
        string ZipFolder = "BMDatalogger";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ExecuteAsAdmin(Filename, Application.StartupPath + @"\" + ZipFolder);
    }

    private void bMBurnerChipBurningToolToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string Filename = "BMBurner.exe";
        string ZipFolder = "BMBurner";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ExecuteAsAdmin(Filename, Application.StartupPath + @"\" + ZipFolder);
    }

    public void ExecuteAsAdmin(string fileName)
    {
        try
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }
        catch
        {
            LogThisMain("Can't start '" + fileName + "'");
        }
    }

    public void ExecuteAsAdmin(string fileName, string folderName)
    {
        try
        {
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = folderName;
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }
        catch
        {
            LogThisMain("Can't start '" + fileName + "'");
        }
    }

    public void ExecuteNotAsAdmin(string fileName)
    {
        try
        {
            Process.Start(fileName);
        }
        catch
        {
            LogThisMain("Can't start '" + fileName + "'");
        }
    }

    private void converterToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string Filename = "Converter.exe";
        string ZipFolder = "Converter";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ExecuteAsAdmin(Filename, Application.StartupPath + @"\" + ZipFolder);
    }

    private void serialMonitorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string Filename = "SerialMonitor.exe";
        string ZipFolder = "SerialMonitor";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ExecuteAsAdmin(Filename, Application.StartupPath + @"\" + ZipFolder);
    }

    private void moatesFlashBurnToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string Filename = "FlashBurn.exe";
        string ZipFolder = "Moates";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ExecuteAsAdmin(Filename, Application.StartupPath + @"\" + ZipFolder);
    }

    private void moatesDemonOstrichResetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string Filename = "DemonOstrichReset.exe";
        string ZipFolder = "Moates";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ExecuteAsAdmin(Filename, Application.StartupPath + @"\" + ZipFolder);
    }

    private void bMDevsFirmwareUpdaterToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string Filename = "BMDevsFirmwareUpdater.exe";
        string ZipFolder = "BMDevsFirmwareUpdater";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ExecuteAsAdmin(Filename, Application.StartupPath + @"\" + ZipFolder);
    }

    private void fileToolbarVisibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        CheckToolbarVisible();
    }

    private void CheckToolbarVisible()
    {
        if (!Loading)
        {
            this.class10_settings_0.ToolbarFile = this.fileToolbarVisibleToolStripMenuItem.Checked;
            this.class10_settings_0.ToolbarEdit = this.editToolbarToolStripMenuItem.Checked;
            this.class10_settings_0.ToolbarEmulator = this.emulatorToolbarToolStripMenuItem.Checked;
            this.class10_settings_0.ToolbarDatalog = this.datalogToolbartoolStripMenuItem.Checked;
            this.class10_settings_0.ToolbarView = this.viewToolbarToolStripMenuItem.Checked;
            this.class10_settings_0.ToolbarTools = this.toolsToolbarToolStripMenuItem.Checked;
        }

        this.mainToolStrip.Visible = this.class10_settings_0.ToolbarFile;
        this.editToolStrip.Visible = this.class10_settings_0.ToolbarEdit;
        this.emulatorToolStrip.Visible = this.class10_settings_0.ToolbarEmulator;
        this.dataloggingToolStrip.Visible = this.class10_settings_0.ToolbarDatalog;
        this.viewToolStrip.Visible = this.class10_settings_0.ToolbarView;
        this.windowsToolStrip.Visible = this.class10_settings_0.ToolbarTools;

        //Get Max Toolbar height
        int MaxHeight = 0;
        if (this.mainToolStrip.Visible && this.mainToolStrip.Location.Y > MaxHeight) MaxHeight = this.mainToolStrip.Location.Y;
        if (this.editToolStrip.Visible && this.editToolStrip.Location.Y > MaxHeight) MaxHeight = this.editToolStrip.Location.Y;
        if (this.emulatorToolStrip.Visible && this.emulatorToolStrip.Location.Y > MaxHeight) MaxHeight = this.emulatorToolStrip.Location.Y;
        if (this.dataloggingToolStrip.Visible && this.dataloggingToolStrip.Location.Y > MaxHeight) MaxHeight = this.dataloggingToolStrip.Location.Y;
        if (this.viewToolStrip.Visible && this.viewToolStrip.Location.Y > MaxHeight) MaxHeight = this.viewToolStrip.Location.Y;
        if (this.windowsToolStrip.Visible && this.windowsToolStrip.Location.Y > MaxHeight) MaxHeight = this.windowsToolStrip.Location.Y;

        this.toolStripPanelTop.Size = new Size(this.toolStripPanelTop.Size.Width, MaxHeight + 24);
        this.splitContainer1_Left.Location = new Point(this.splitContainer1_Left.Location.X, MaxHeight + 24);

        this.splitContainer1_Left.Size = new Size(this.splitContainer1_Left.Size.Width, this.Height - 58 - (MaxHeight + 24));
    }

    private void editToolbarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        CheckToolbarVisible();
    }

    private void emulatorToolbarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        CheckToolbarVisible();
    }

    private void datalogToolbartoolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        CheckToolbarVisible();
    }

    private void viewToolbarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        CheckToolbarVisible();
    }

    private void toolsToolbarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        CheckToolbarVisible();
    }

    private void benchmarkToolToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmCPUBench_0 = new frmCPUBench(ref this.class17_0);
        this.frmCPUBench_0.StartPosition = FormStartPosition.CenterParent;
        this.frmCPUBench_0.ShowDialog();
        this.frmCPUBench_0.Dispose();
        this.frmCPUBench_0 = null;
    }

    private void onBoardLoggingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmOnboard_0 = new frmOnboard(ref this.class17_0, ref this.class10_settings_0);
        this.frmOnboard_0.StartPosition = FormStartPosition.CenterParent;
        this.frmOnboard_0.ShowDialog();
        this.frmOnboard_0.Dispose();
        this.frmOnboard_0 = null;
    }

    private void flashToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*if (this.flashGUI_0 != null)
        {
            this.flashGUI_0.Focus();
        }
        else
        {
            this.flashGUI_0 = new FlashGUI(ref this.class10_settings_0, ref this.Class34_Zip_0, ref this.ktable_0.Class39_0);
            this.flashGUI_0.method_8(ref this.class18_0);
            this.flashGUI_0.StartPosition = FormStartPosition.CenterParent;
            this.flashGUI_0.ShowDialog();
            this.flashGUI_0.Dispose();
            this.flashGUI_0 = null;
        }*/
    }

    /*public void OpenOBD2Menu()
    {
        frmVWBINLoader frmVWBINLoader_0 = new frmVWBINLoader(ref this.frmMain_0);
        frmVWBINLoader_0.StartPosition = FormStartPosition.CenterParent;
        frmVWBINLoader_0.ShowDialog();
        frmVWBINLoader_0.Dispose();
        frmVWBINLoader_0 = null;
    }*/

    /*public void OpenOBD0Menu()
    {
        Form35 Form35_0 = new Form35(ref this.frmMain_0);
        Form35_0.StartPosition = FormStartPosition.CenterParent;
        Form35_0.ShowDialog();
        Form35_0.Dispose();
        Form35_0 = null;
    }*/

    public void SpawnWaitingwindows()
    {
        if (frmWaiting_0 == null)
        {
            frmWaiting_0 = new frmWaiting();
            //frmWaiting_0.TopLevel = true;
            frmWaiting_0.TopMost = true;
            frmWaiting_0.Show();
            Thread.Sleep(10);
            frmWaiting_0.Refresh();
            Thread.Sleep(10);
        }
    }

    public void CloseWaitingwindows()
    {
        if (frmWaiting_0 != null)
        {
            frmWaiting_0.Dispose();
            frmWaiting_0 = null;
        }
    }

    private void verifyRomWithEmulatorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class25_0.method_20();
    }

    private void cOMPortHelperToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("This will help you to find the COM Port of a device!" + Environment.NewLine + Environment.NewLine + "Make sure the device is unplugged then Clic Ok", "BMTune", MessageBoxButtons.OKCancel) == DialogResult.OK)
        {
            string[] strArray2 = SerialPort.GetPortNames();

            if (MessageBox.Show("Now plug the device in then press Ok", "BMTune", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Thread.Sleep(5000);

                string[] strArray3 = SerialPort.GetPortNames();

                bool FoundAny = false;
                if (strArray3.Length > strArray2.Length)
                {
                    string NewCOM = "";
                    for (int i = strArray2.Length; i < strArray3.Length; i++)
                    {
                        NewCOM = strArray3[i] + Environment.NewLine;
                    }
                    NewCOM += "Found(s)!";

                    FoundAny = true;
                    MessageBox.Show(NewCOM, "BMTune", MessageBoxButtons.OK);
                }
                //Invert Method
                if (strArray3.Length < strArray2.Length)
                {
                    string NewCOM = "";
                    for (int i = strArray3.Length; i < strArray2.Length; i++)
                    {
                        NewCOM = strArray2[i] + Environment.NewLine;
                    }
                    NewCOM += "Found(s)!";

                    FoundAny = true;
                    MessageBox.Show(NewCOM, "BMTune", MessageBoxButtons.OK);
                }

                if (!FoundAny)
                {
                    string NewCOM = "No COM Ports Found(s)!";
                    MessageBox.Show(NewCOM, "BMTune", MessageBoxButtons.OK);
                }
            }
        }
    }

    private void iSRV3ProtocolInfosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmProtocolInfos frmProtocolInfos_0 = new frmProtocolInfos();
        frmProtocolInfos_0.ShowDialog();

        if (frmProtocolInfos_0 != null)
        {
            frmProtocolInfos_0.Dispose();
            frmProtocolInfos_0 = null;
        }
    }

    public void SetTestOutputsInfos()
    {
        /*
         this.class13_u_0.long_530_vts
         this.class13_u_0.long_531_fpump
         this.class13_u_0.long_532_a10
         this.class13_u_0.long_533_ac
         this.class13_u_0.long_534_pcs
         this.class13_u_0.long_535_iab
         this.class13_u_0.long_536_fanc
         this.class13_u_0.long_537_altc
         */

        if (this.class18_0.RomVersion >= 120 && this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.toolStripSeparator41.Visible = true;
            this.testECUOutputsToolStripMenuItem.Visible = true;

            this.vTSToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_530_vts) == 0xff;
            this.fuelPumpToolStripMenuItem1.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_531_fpump) == 0xff;
            this.a10ToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_532_a10) == 0xff;
            this.aCToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_533_ac) == 0xff;
            this.pCSToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_534_pcs) == 0xff;
            this.iABToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_535_iab) == 0xff;
            this.fANCToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_536_fanc) == 0xff;
            this.aLTCToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_537_altc) == 0xff;

            this.invertToolStripMenuItem.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_104) == 0xff;
        }
        else
        {
            this.toolStripSeparator41.Visible = false;
            this.testECUOutputsToolStripMenuItem.Visible = false;
        }
    }

    private void vTSToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.class18_0.RomVersion >= 120)
        {
            if (this.vTSToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_530_vts, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_530_vts, 0x00);
            if (this.fuelPumpToolStripMenuItem1.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_531_fpump, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_531_fpump, 0x00);
            if (this.a10ToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_532_a10, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_532_a10, 0x00);
            if (this.aCToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_533_ac, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_533_ac, 0x00);
            if (this.pCSToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_534_pcs, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_534_pcs, 0x00);
            if (this.iABToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_535_iab, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_535_iab, 0x00);
            if (this.fANCToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_536_fanc, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_536_fanc, 0x00);
            if (this.aLTCToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_537_altc, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_537_altc, 0x00);

            if (this.invertToolStripMenuItem.Checked) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_104, 0xff);
            else this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_104, 0x00);
        }
    }

    /*public static bool oYoY = false;

    private sealed class P2P2
    {
        // Token: 0x06000882 RID: 2178 RVA: 0x00008EE9 File Offset: 0x000072E9
        internal void q2q2()
        {
            this.ZjZj.KxKx(this.Q2Q2, this.r2r2);
        }

        // Token: 0x04000BD8 RID: 3032
        public FrmMain ZjZj;

        // Token: 0x04000BD9 RID: 3033
        public string[] Q2Q2;

        // Token: 0x04000BDA RID: 3034
        public int r2r2;
    }*/

    private void importTunerViewRAWToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*FrmMain.P2P2 P2P2 = new FrmMain.P2P2();
        P2P2.ZjZj = this;
        FrmMain.oYoY = false;   //check for this reference
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Select TunerView or Raw log File.";
        openFileDialog.Filter = "(TunerView CSV, Raw Log)|*.csv;*.RAW";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            if (Path.GetExtension(openFileDialog.FileName) == ".RAW")
            {
                byte[] array = File.ReadAllBytes(openFileDialog.FileName);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Datalog|*.log";
                saveFileDialog.Title = "Save Datalog";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }
                    this.kxkx(array, saveFileDialog);
                    return;
                }
            }
            else
            {
                try
                {
                    P2P2.Q2Q2 = File.ReadAllLines(openFileDialog.FileName.ToString());
                    try
                    {
                        string text = P2P2.Q2Q2[0];
                        if (!text.Contains("TunerView"))
                        {
                            MessageBox.Show("Not a TunerView file.");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Not a TunerView file.");
                        return;
                    }
                    string s = "10";
                    P2P2.r2r2 = 2;
                    if (FrmMain.IxIx("TPS Filter", "Filter out data below TPS value of:", ref s) == DialogResult.OK)
                    {
                        try
                        {
                            P2P2.r2r2 = int.Parse(s);
                            goto IL_144;
                        }
                        catch
                        {
                            goto IL_144;
                        }
                    }
                    P2P2.r2r2 = 0;
                IL_144:
                    try
                    {
                        Array.Clear(ZeZe.byte_0_Analog1, 0, ZeZe.byte_0_Analog1.Length);
                        Array.Clear(ZeZe.byte_0_Analog2, 0, ZeZe.byte_0_Analog2.Length);
                        Array.Clear(ZeZe.byte_0_Analog3, 0, ZeZe.byte_0_Analog3.Length);
                        Array.Clear(ZeZe.byte_0_DemonA1, 0, ZeZe.byte_0_DemonA1.Length);
                        Array.Clear(ZeZe.byte_0_DemonA2, 0, ZeZe.byte_0_DemonA2.Length);
                        Array.Clear(ZeZe.byte_0_DemonA3, 0, ZeZe.byte_0_DemonA3.Length);
                        Array.Clear(ZeZe.byte_0_DemonA4, 0, ZeZe.byte_0_DemonA4.Length);
                        Array.Clear(ZeZe.byte_0_DemonA5, 0, ZeZe.byte_0_DemonA5.Length);
                        Array.Clear(ZeZe.byte_0_IAT, 0, ZeZe.byte_0_IAT.Length);
                        Array.Clear(ZeZe.byte_0_ECT, 0, ZeZe.byte_0_ECT.Length);
                        Array.Clear(ZeZe.byte_0_Fign, 0, ZeZe.byte_0_Fign.Length);
                        Array.Clear(ZeZe.byte_0_Fuelusage, 0, ZeZe.byte_0_Fuelusage.Length);
                        Array.Clear(ZeZe.byte_0_inj, 0, ZeZe.byte_0_inj.Length);
                        Array.Clear(ZeZe.byte_0_bat, 0, ZeZe.byte_0_bat.Length);
                        Array.Clear(ZeZe.byte_0_D14, 0, ZeZe.byte_0_D14.Length);
                        Array.Clear(ZeZe.byte_0_VTS, 0, ZeZe.byte_0_VTS.Length);
                        Array.Clear(ZeZe.byte_0_BSTDC, 0, ZeZe.byte_0_BSTDC.Length);
                        Array.Clear(ZeZe.byte_0_TPS, 0, ZeZe.byte_0_TPS.Length);
                    }
                    catch
                    {
                    }
                    Task task = Task.Factory.StartNew(new Action(P2P2.q2q2));
                }
                catch
                {
                    MessageBox.Show("Failed to open file.");
                }
                if (this.TzTz != null)
                {
                    this.TzTz.9P9P();
                }
            }
        }*/
    }

    // Token: 0x06000792 RID: 1938 RVA: 0x000A2914 File Offset: 0x000A0D14
    public void kxkx(byte[] A_1, SaveFileDialog A_2)
    {
        /*int count = Regex.Matches(Encoding.Default.GetString(A_1), "<D>").Count;
        byte[] array = new byte[60];
        int num = 0;
        for (int i = 0; i < A_1.Length; i++)
        {
            if (A_1[i] == 60 && A_1[i + 1] == 68 && A_1[i + 2] == 62)
            {
                for (int j = 0; j < 60; j++)
                {
                    array[j] = A_1[i - 57 + j];
                }
                num++;
                this.jxjx(array);
                this.olol.TiTi(this.BjBj, 40);
            }
        }
        using (Stream stream = File.OpenWrite(A_2.FileName))
        {
            byte[] array2 = this.AzAz.glgl(ZHZH.pIpI.ToArray());
            stream.Write(array2, 0, array2.Length);
            ZHZH.pIpI.Clear();
            MessageBox.Show(string.Concat(new string[]
            {
                "Converted ",
                num.ToString(),
                " out of ",
                count.ToString(),
                "\nReported size was ",
                (A_1.Length / 60).ToString(),
                "\nYou can open it like a normal log now."
            }), "Onboard:");
        }*/
    }

    /*public void KxKx(string[] A_1, int A_2)
    {
        FrmMain.oYoY = true;
        string text = A_1[1];
        string[] array = A_1[2].Split(new char[]
        {
            ','
        });
        string[] array2 = A_1[3].Split(new char[]
        {
            ','
        });
        FrmMain.OYOY = false;
        if (array2[7] == "AFR")
        {
            FrmMain.OYOY = true;
        }
        else if (array2[7] != "V")
        {
            MessageBox.Show("Only logs with O2 as V or AFR work.");
            return;
        }
        this.M2M2.Clear();
        this.n2n2.Clear();
        for (int i = 0; i <= 25; i++)
        {
            this.M2M2.Add(float.Parse(this.AzAz.NJNJ((byte)i, SelectedTable.fuel1_lo).ToString()));
        }
        for (int j = 0; j <= 19; j++)
        {
            this.n2n2.Add(int.Parse(this.AzAz.LJLJ((byte)j).ToString()));
        }
        for (int k = 4; k <= A_1.Length - 3; k++)
        {
            this.pYpY = (int)(0.5f + (100f * (float)k / (float)A_1.Length - 3f));
            string[] array3 = A_1[k].Split(new char[]
            {
                ','
            });
            string a = array2[4];
            if (!(a == "mBar"))
            {
                if (!(a == "PSI"))
                {
                    if (!(a == "PSI abs"))
                    {
                        if (!(a == "BAR"))
                        {
                            if (!(a == "BAR abs"))
                            {
                                if (a == "KPA")
                                {
                                    array3[4] = (float.Parse(array3[4]) * 10f).ToString("0");
                                }
                            }
                            else
                            {
                                array3[4] = (float.Parse(array3[4]) * 1000f).ToString("0");
                            }
                        }
                        else
                        {
                            float num = float.Parse(array3[4]) + 14.7f;
                            array3[4] = (num * 1000f).ToString("0");
                        }
                    }
                    else
                    {
                        array3[4] = (float.Parse(array3[4]) * 68.94757f).ToString("0");
                    }
                }
                else
                {
                    float num2 = float.Parse(array3[4]) + 14.7f;
                    array3[4] = (num2 * 68.94757f).ToString("0");
                }
            }
            if (this.lxlx(int.Parse(array3[3]), A_2))
            {
                byte[] array4 = this.LxLx(int.Parse(array3[1]), float.Parse(array3[4]));
                ZeZe.byte_0_Analog1[(int)array4[1], (int)array4[0]] = (byte)FrmMain.GiGi(0f, 5f, 0f, 255f, float.Parse(array3[13]));
                ZeZe.byte_0_Analog2[(int)array4[1], (int)array4[0]] = (byte)FrmMain.GiGi(0f, 5f, 0f, 255f, float.Parse(array3[11]));
                ZeZe.byte_0_Analog3[(int)array4[1], (int)array4[0]] = (byte)FrmMain.GiGi(0f, 5f, 0f, 255f, float.Parse(array3[12]));
                if (AxAx.OYOY)
                {
                    ZeZe.byte_0_D14[(int)array4[1], (int)array4[0]] = float.Parse(array3[7]);
                }
                else
                {
                    ZeZe.byte_0_D14[(int)array4[1], (int)array4[0]] = (float)this.AzAz.bkbk((byte)FrmMain.GiGi(0f, 5f, 0f, 255f, float.Parse(array3[7])));
                }
                ZeZe.byte_0_IAT[(int)array4[1], (int)array4[0]] = float.Parse(array3[5]);
                ZeZe.byte_0_ECT[(int)array4[1], (int)array4[0]] = float.Parse(array3[6]);
                ZeZe.byte_0_Fign[(int)array4[1], (int)array4[0]] = float.Parse(array3[8]);
                ZeZe.byte_0_inj[(int)array4[1], (int)array4[0]] = float.Parse(array3[9]);
                ZeZe.byte_0_bat[(int)array4[1], (int)array4[0]] = float.Parse(array3[10]);
                ZeZe.byte_0_VTS[(int)array4[1], (int)array4[0]] = (byte)int.Parse(array3[18]);
                ZeZe.byte_0_BSTDC[(int)array4[1], (int)array4[0]] = 0f;
                ZeZe.byte_0_TPS[(int)array4[1], (int)array4[0]] = (float)int.Parse(array3[3]);
            }
        }
        this.pYpY = 0;
    }

    public static DialogResult IxIx(string A_0, string A_1, ref string A_2)
    {
        Form form = new Form();
        Label label = new Label();
        MaskedTextBox maskedTextBox = new MaskedTextBox();
        Button button = new Button();
        Button button2 = new Button();
        form.Text = A_0;
        label.Text = A_1;
        maskedTextBox.Text = A_2;
        maskedTextBox.Mask = "000";
        button.Text = "OK";
        button2.Text = "Cancel";
        button.DialogResult = DialogResult.OK;
        button2.DialogResult = DialogResult.Cancel;
        label.SetBounds(9, 20, 372, 13);
        maskedTextBox.SetBounds(12, 39, 372, 20);
        button.SetBounds(228, 72, 75, 23);
        button2.SetBounds(309, 72, 75, 23);
        label.AutoSize = true;
        maskedTextBox.Anchor |= AnchorStyles.Right;
        button.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
        button2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
        form.ClientSize = new Size(396, 107);
        form.Controls.AddRange(new Control[]
        {
            label,
            maskedTextBox,
            button,
            button2
        });
        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = button;
        form.CancelButton = button2;
        DialogResult result = form.ShowDialog();
        A_2 = maskedTextBox.Text;
        return result;
    }*/
    //####################################################################

    /*private void MenuButtons_EnabledChanged(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(ToolStripMenuItem))
        {
            try
            {
                var Test1 = (ToolStripMenuItem)sender;
                if (this.frmDataDisplay_0 != null && Test1.Tag != null) this.frmDataDisplay_0.SetButtonsEnabled(int.Parse(Test1.Tag.ToString()), Test1.Enabled);
            }
            catch { }
        }
        if (sender.GetType() == typeof(ToolStripButton))
        {
            try
            {
                var Test1 = (ToolStripButton)sender;
                if (this.frmDataDisplay_0 != null && Test1.Tag != null) this.frmDataDisplay_0.SetButtonsEnabled(int.Parse(Test1.Tag.ToString()), Test1.Enabled);
            }
            catch { }
        }
    }*/
}

