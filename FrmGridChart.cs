using Data;
//using PropertiesRes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class FrmGridChart : Form
{
    private ToolStripMenuItem adjustSelectionToolStripMenuItem;
    public MapGraphType mapGraphType_0;
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    public frmLivePSetting LivePlots_0;
    private Class10_settings class10_settings_0;
    private Class11_u class11_u_0;
    private Class12_afrT class12_afrT_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private ToolStripMenuItem contextDeleteColumn;
    private ToolStripMenuItem contextDeleteRow;
    private ToolStripMenuItem contextInsertColumn;
    private ToolStripMenuItem contextInsertRow;
    private ToolStripMenuItem contextInterpolateColumnsTool;
    private ToolStripMenuItem contextInterpolateRowsTool;
    private ToolStripMenuItem contextInterpolateXYTool;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem contextRedo;
    private ToolStripMenuItem contextSmoothMap;
    private ToolStripMenuItem contextSmoothSelection;
    private ToolStripMenuItem contextUndo;
    public SplitContainer splitContainer1;
    private CtrlGrid ctrlGrid;
    private ctrlMapGraph ctrlMapGraph1;
    private ToolStripMenuItem decreaseToolStripMenuItem;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private double double_4;
    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    private ToolStripMenuItem increaseToolStripMenuItem;
    private int[] int_0;
    private object object_0;
    private object object_1;
    private Struct17 struct17_0;
    private ToolStripContainer toolStripContainer1;
    private ToolStripContainer toolStripContainer2;
    private ToolStripSeparator toolStripSeparator16;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripMenuItem toolTunerClear;
    private ToolStripMenuItem toolTunerClearAll;
    private ToolStripMenuItem toolTunerClearTrail;
    private ToolStripMenuItem toolTunerMapTrail;
    private ToolStripDropDownButton toolTunerMenu;
    private ToolStripMenuItem toolTunerSmartTrack;
    private ToolStrip tunerToolStrip;
    private IContainer components;
    private ToolStripDropDownButton toolStripDropDownButton2;
    private ToolStripMenuItem graphClearShort;
    private ToolStripSeparator toolStripSeparator4;
    public ToolStripMenuItem FuelRawToolStripMenuItem;
    public ToolStripMenuItem FuelDutyToolStripMenuItem;
    public ToolStripMenuItem fuelInjDurToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripMenuItem toolStripMenuItem3;
    private ToolStripMenuItem toolStripMenuItem4;
    private ToolStripMenuItem toolStripMenuItem5;
    private ToolStripSeparator toolStripSeparator10;
    public ToolStripMenuItem copyPrimarySecondaryToolStripMenuItem;
    private bool ShowingVE = false;
    private ToolStripMenuItem toolTunerFollowVtec;
    private ToolStripMenuItem toolTunerFollowDualTables;
    private ToolStripMenuItem scalarsToolStripMenuItem;
    private bool IsLoading = true;
    //public float CustomMin;
    //public float CustomMax;
    //public int CustomColumns = 14;
    //public int CustomSensor = 0;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem dGraphToolStripMenuItem;
    private ToolStripMenuItem dGraphToolStripMenuItem1;
    private ToolStripMenuItem graphSetupToolStripMenuItem;
    private ToolStripMenuItem belowTableToolStripMenuItem;
    private ToolStripMenuItem onlyNAViewToolStripMenuItem;
    private FrmGridChart FrmGridChart_0;
    private ToolStripMenuItem autoAdjustSelectionToolStripMenuItem;
    public ToolStripMenuItem analog3Reading_Button;
    public ToolStripMenuItem analog1Reading_Button;
    public ToolStripMenuItem analog2Reading_Button;
    private ToolStrip tableEditToolStrip;
    private ToolStripButton toolBtnAdjSel;
    private ToolStripButton toolIncrease;
    private ToolStripButton toolDecrease;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton interplotaeRToolStripButton;
    private ToolStripButton interplolateCToolStripButton;
    private ToolStripButton interpolateXYtoolStripButton;
    private ToolStripButton toolSmooth;
    private ToolStrip tableViewToolStrip;
    public ToolStripButton toolStripButtonHighFuel;
    public ToolStripButton toolStripButtonLowIgn;
    public ToolStripButton toolStripButtonLowFuel;
    public ToolStripButton toolStripButtonHighIgn;
    private ToolStripSeparator toolStripSeparator14;
    public ToolStripButton toolStripButtonPrimary;
    public ToolStripButton toolStripButtonSecondary;
    private ToolStripSeparator toolStripSeparator1;
    public ToolStripButton toolStripButtonMapValue;
    public ToolStripButton toolStripButtonAFTarget;
    public ToolStripButton toolStripButtonAFReading;
    public ToolStripButton toolStripButtonAFDiff;
    public ToolStripButton toolStripButtonVE;
    private ToolStripMenuItem contextTunerFilterData;
    private ToolStripMenuItem contextTunerFilterAllData;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripSeparator toolStripSeparator11;
    private ToolStripMenuItem toolTunerTrace;
    private ToolStripMenuItem singleCellToolStripMenuItem;
    private ToolStripMenuItem quadCellToolStripMenuItem;
    private ToolStripMenuItem singleCellRowToolStripMenuItem;
    private ToolStripMenuItem singleCellEndcolumnToolStripMenuItem;
    private ToolStripMenuItem singleCellEndcolumnRowToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator12;
    private ToolStripMenuItem toolStripMenuItem6;
    private ToolStripMenuItem toolStripMenuItem7;
    private ToolStripMenuItem toolStripMenuItem8;
    private ToolStripMenuItem toolStripMenuItem9;
    private ToolStripMenuItem toolStripMenuItem10;
    private ToolStripMenuItem toolStripMenuItem11;
    private ToolStripMenuItem traceOptionsToolStripMenuItem;
    private ToolStripMenuItem followSelectedCellsOnRowcolumnHeaderToolStripMenuItem;
    private ToolStripMenuItem followTraceOnRowcolumnHeaderToolStripMenuItem;
    private ToolStripMenuItem drawOnCellTraceTheInterpolationToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItem12;
    private ToolStripMenuItem toolStripMenuItem13;
    private ToolStripMenuItem toolStripMenuItem14;
    private ToolStripMenuItem toolStripMenuItem15;
    public bool loading = true;
    private ToolStripSeparator toolStripSeparator13;
    private ToolStripMenuItem DynoWSReading_Button;
    private ToolStripMenuItem DynoHPReading_Button;
    private ToolStripMenuItem DynoNMReading_Button;
    private ToolStripMenuItem AUX1Reading_Button;
    private ToolStripMenuItem AUX2Reading_Button;
    private ToolStripMenuItem AUX3Reading_Button;
    private ToolStripMenuItem THCReading_Button;
    private DateTime LastCheck = DateTime.Now;

    public FrmGridChart()
    {
        this.InitializeComponent();
        base.HandleCreated += new EventHandler(this.FrmGridChart_HandleCreated);
        base.HandleDestroyed += new EventHandler(this.FrmGridChart_HandleDestroyed);

        FrmGridChart_0 = this;

    }

    private void contextDeleteColumn_Click(object sender, EventArgs e)
    {
        this.method_15();
    }

    private void contextDeleteRow_Click(object sender, EventArgs e)
    {
        this.method_17();
    }

    private void contextInsertColumn_Click(object sender, EventArgs e)
    {
        this.method_14();
    }

    private void contextInsertRow_Click(object sender, EventArgs e)
    {
        this.method_16();
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        this.contextRedo.Enabled = this.class18_0.method_158();
        this.contextUndo.Enabled = this.class18_0.method_157();
        GC.Collect(3);
    }

    private void contextRedo_Click(object sender, EventArgs e)
    {
        this.class11_u_0.method_7();
    }

    private void contextSmoothMap_Click(object sender, EventArgs e)
    {
        this.method_30();
    }

    private void contextSmoothSelection_Click(object sender, EventArgs e)
    {
        this.method_31();
    }

    private void contextUndo_Click(object sender, EventArgs e)
    {
        this.class11_u_0.method_4();
    }

    private void ctrlGrid_Load(object sender, EventArgs e)
    {
        SelectMap(2);
        SelectFuel();
        //this.toolStripComboBox1.SelectedIndex = 2;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void FrmGridChart_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.class18_0.delegate57_0 -= new Class18.Delegate57(this.method_18);
        this.class18_0.delegate61_0 -= new Class18.Delegate61(this.method_19);
        this.class18_0.delegate58_0 -= new Class18.Delegate58(this.method_8);
        this.ctrlGrid.Resize -= new EventHandler(this.ctrlGrid_Resize);
        //Settings.Default.Save();
        this.class10_settings_0 = null;
        this.class17_0 = null;
        this.class18_0 = null;
        this.ctrlGrid.method_18();
        this.ctrlGrid.Dispose();
        this.ctrlGrid = null;
        this.ctrlMapGraph1.Dispose();
        this.ctrlMapGraph1 = null;
        this.frmMain_0.frmGridChart_0.Dispose();
        this.frmMain_0.frmGridChart_0 = null;
        base.Dispose();
    }

    private void FrmGridChart_ResizeEnd(object sender, EventArgs e)
    {
        RefreshPage();
    }


    private void ctrlGrid_Resize(object sender, EventArgs e)
    {
        //RefreshPage();
    }

    private void FrmGridChart_HandleCreated(object sender, EventArgs e)
    {
        this.bool_1 = true;
    }

    private void FrmGridChart_HandleDestroyed(object sender, EventArgs e)
    {
        this.bool_1 = false;
    }

    public void FrmGridChart_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.class10_settings_0.GetKeyPressed(e, "Increase map size width"))
        {
            e.Handled = true;
            byte num = (byte)(this.class10_settings_0.method_11_GetMAP_ColumnsNumber() + 1);
            if ((num >= 10) && (num <= 0x18))
            {
                this.class18_0.method_155("Fuel & Ign Table Settings");
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, num);
                this.class18_0.method_153();
                this.class18_0.method_52();
            }
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Decrease map size width"))
        {
            e.Handled = true;
            byte num2 = (byte)(this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1);
            if ((num2 >= 10) && (num2 <= 0x18))
            {
                this.class18_0.method_155("Fuel & Ign Table Settings");
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, num2);
                this.class18_0.method_153();
                this.class18_0.method_52();
            }
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Clear Current Selection"))
        {
            this.ctrlGrid.method_17_ClearSelection();
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Primary Low Ignition"))
        {
            SelectMap(0);
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Primary High Ignition"))
        {
            SelectMap(1);
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Primary Low Fuel"))
        {
            SelectMap(2);
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Primary High Fuel"))
        {
            SelectMap(3);
        }

        else if (this.class10_settings_0.GetKeyPressed(e, "Secondary Low Ignition"))
        {
            SelectMap(4);
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Secondary High Ignition"))
        {
            SelectMap(5);
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Secondary Low Fuel"))
        {
            SelectMap(6);
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Secondary High Fuel"))
        {
            SelectMap(7);
        }
    }

    private void FrmGridChart_Load(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Dock = DockStyle.None;
                base.Location = this.class18_0.class10_settings_0.tables_Location;
                base.Size = this.class18_0.class10_settings_0.tables_Size;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
            }
            this.tunerToolStrip.Location = this.class10_settings_0.tunerToolStrip;
            this.tableEditToolStrip.Location = this.class10_settings_0.tableEditToolStrip;
            this.tableViewToolStrip.Location = this.class10_settings_0.tableViewToolStrip;
        }
        loading = false;

        this.class18_0.method_5_SetSelectedTable(SelectedTable.fuel1_lo);
        this.method_8();
        this.onlyNAViewToolStripMenuItem.Checked = this.class10_settings_0.bool_20_ONLY_NA_VIEW;
        this.belowTableToolStripMenuItem.Checked = this.class10_settings_0.bool_15;

        /*foreach (string str in Enum.GetNames(typeof(Sensors)))
        {
            Sensors sensors = (Sensors) Enum.Parse(typeof(Sensors), str);
            if (this.class10_0.method_5(sensors))
            {
                item = new ToolStripMenuItem {
                    Text = this.class10_0.method_13(sensors),
                    Tag = (int) sensors
                };
                item.Click += new EventHandler(this.method_39);
            }
        }*/
    }

    public void RefreshPage()
    {
        if (base.WindowState == FormWindowState.Normal)
        {
            this.Invalidate();
            this.ctrlMapGraph1.Invalidate();
            this.ctrlGrid.method_31();
        }
    }

    private void FrmGridChart_Resize(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode && !loading)
            {
                if (base.WindowState == FormWindowState.Normal)
                {
                    this.class18_0.class10_settings_0.tables_Size = base.Size;
                }
                this.class18_0.class10_settings_0.tables_Location = base.Location;
            }
        }
    }

    public void SelectFuelDuty(int Mode)
    {
        ToolStripMenuItem item = new ToolStripMenuItem();
        if (Mode == 0) item = this.FuelRawToolStripMenuItem;
        if (Mode == 1) item = this.fuelInjDurToolStripMenuItem;
        if (Mode == 2) item = this.FuelDutyToolStripMenuItem;

        if (!item.Checked)
        {
            this.FuelRawToolStripMenuItem.Checked = false;
            this.fuelInjDurToolStripMenuItem.Checked = false;
            this.FuelDutyToolStripMenuItem.Checked = false;
            item.Checked = true;
            this.class18_0.method_7((FuelDisplayMode)Mode);
            this.frmMain_0.SetFuelButtons();
        }
    }

    private void FuelDutyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem item = (ToolStripMenuItem)sender;
        SelectFuelDuty(int.Parse(item.Tag.ToString()));
    }

    public void ClearLivePlots()
    {
        this.ctrlMapGraph1.method_17();
    }

    private void grphBtnClear_Click(object sender, EventArgs e)
    {
        ClearLivePlots();
    }

    public void interplolateCToolStripButton_Click(object sender, EventArgs e)
    {
        this.method_34();
    }

    public void interplotaeRToolStripButton_Click(object sender, EventArgs e)
    {
        this.method_33();
    }

    public void interpolateXYtoolStripButton_Click(object sender, EventArgs e)
    {
        this.method_32_InterpolateX();
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGridChart));
            this.ctrlGrid = new CtrlGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextInterpolateXYTool = new System.Windows.Forms.ToolStripMenuItem();
            this.contextInterpolateRowsTool = new System.Windows.Forms.ToolStripMenuItem();
            this.contextInterpolateColumnsTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextSmoothMap = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSmoothSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.contextTunerFilterData = new System.Windows.Forms.ToolStripMenuItem();
            this.contextTunerFilterAllData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.contextInsertColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTunerTrace = new System.Windows.Forms.ToolStripMenuItem();
            this.singleCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleCellRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleCellEndcolumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleCellEndcolumnRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followTraceOnRowcolumnHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawOnCellTraceTheInterpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableEditToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnAdjSel = new System.Windows.Forms.ToolStripButton();
            this.toolIncrease = new System.Windows.Forms.ToolStripButton();
            this.toolDecrease = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.interplotaeRToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.interplolateCToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.interpolateXYtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolSmooth = new System.Windows.Forms.ToolStripButton();
            this.tableViewToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLowIgn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHighIgn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLowFuel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHighFuel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPrimary = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSecondary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMapValue = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAFTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAFReading = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAFDiff = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVE = new System.Windows.Forms.ToolStripButton();
            this.tunerToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.fuelInjDurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuelDutyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuelRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.analog1Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.analog2Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.analog3Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.DynoWSReading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.DynoHPReading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.DynoNMReading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.AUX1Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.AUX2Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.AUX3Reading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.THCReading_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.copyPrimarySecondaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTunerSmartTrack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerMapTrail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerFollowVtec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerFollowDualTables = new System.Windows.Forms.ToolStripMenuItem();
            this.autoAdjustSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.graphClearShort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTunerClearTrail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.dGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dGraphToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.belowTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyNAViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.ctrlMapGraph1 = new ctrlMapGraph();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableEditToolStrip.SuspendLayout();
            this.tableViewToolStrip.SuspendLayout();
            this.tunerToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlGrid
            // 
            this.ctrlGrid.AutoScroll = true;
            this.ctrlGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.ctrlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGrid.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlGrid.Location = new System.Drawing.Point(0, 0);
            this.ctrlGrid.Name = "ctrlGrid";
            this.ctrlGrid.Size = new System.Drawing.Size(480, 355);
            this.ctrlGrid.TabIndex = 0;
            this.ctrlGrid.Load += new System.EventHandler(this.ctrlGrid_Load);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextUndo,
            this.contextRedo,
            this.toolStripSeparator5,
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem,
            this.adjustSelectionToolStripMenuItem,
            this.toolStripSeparator7,
            this.contextInterpolateXYTool,
            this.contextInterpolateRowsTool,
            this.contextInterpolateColumnsTool,
            this.toolStripSeparator2,
            this.contextSmoothMap,
            this.contextSmoothSelection,
            this.toolStripSeparator16,
            this.contextTunerFilterData,
            this.contextTunerFilterAllData,
            this.toolStripSeparator3,
            this.contextInsertRow,
            this.contextDeleteRow,
            this.contextInsertColumn,
            this.contextDeleteColumn,
            this.toolStripSeparator11,
            this.toolTunerTrace,
            this.traceOptionsToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 436);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // contextUndo
            // 
            this.contextUndo.Name = "contextUndo";
            this.contextUndo.Size = new System.Drawing.Size(193, 22);
            this.contextUndo.Text = "Undo";
            this.contextUndo.Click += new System.EventHandler(this.contextUndo_Click);
            // 
            // contextRedo
            // 
            this.contextRedo.Name = "contextRedo";
            this.contextRedo.Size = new System.Drawing.Size(193, 22);
            this.contextRedo.Text = "Redo";
            this.contextRedo.Click += new System.EventHandler(this.contextRedo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(190, 6);
            // 
            // increaseToolStripMenuItem
            // 
            this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
            this.increaseToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.increaseToolStripMenuItem.Text = "Increase selection";
            this.increaseToolStripMenuItem.ToolTipText = "Increase selection";
            this.increaseToolStripMenuItem.Click += new System.EventHandler(this.toolIncrease_Click);
            // 
            // decreaseToolStripMenuItem
            // 
            this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
            this.decreaseToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.decreaseToolStripMenuItem.Text = "Decrease selection";
            this.decreaseToolStripMenuItem.ToolTipText = "Decrease selection";
            this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.toolDecrease_Click);
            // 
            // adjustSelectionToolStripMenuItem
            // 
            this.adjustSelectionToolStripMenuItem.Name = "adjustSelectionToolStripMenuItem";
            this.adjustSelectionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.adjustSelectionToolStripMenuItem.Text = "Adjust selection";
            this.adjustSelectionToolStripMenuItem.ToolTipText = "Adjust selection";
            this.adjustSelectionToolStripMenuItem.Click += new System.EventHandler(this.toolBtnAdjSel_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(190, 6);
            // 
            // contextInterpolateXYTool
            // 
            this.contextInterpolateXYTool.Name = "contextInterpolateXYTool";
            this.contextInterpolateXYTool.Size = new System.Drawing.Size(193, 22);
            this.contextInterpolateXYTool.Text = "Interpolate";
            this.contextInterpolateXYTool.Click += new System.EventHandler(this.interpolateXYtoolStripButton_Click);
            // 
            // contextInterpolateRowsTool
            // 
            this.contextInterpolateRowsTool.Name = "contextInterpolateRowsTool";
            this.contextInterpolateRowsTool.Size = new System.Drawing.Size(193, 22);
            this.contextInterpolateRowsTool.Text = "Interpolate by Row";
            this.contextInterpolateRowsTool.Click += new System.EventHandler(this.interplotaeRToolStripButton_Click);
            // 
            // contextInterpolateColumnsTool
            // 
            this.contextInterpolateColumnsTool.Name = "contextInterpolateColumnsTool";
            this.contextInterpolateColumnsTool.Size = new System.Drawing.Size(193, 22);
            this.contextInterpolateColumnsTool.Text = "Interpolate by Column";
            this.contextInterpolateColumnsTool.Click += new System.EventHandler(this.interplolateCToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // contextSmoothMap
            // 
            this.contextSmoothMap.Name = "contextSmoothMap";
            this.contextSmoothMap.Size = new System.Drawing.Size(193, 22);
            this.contextSmoothMap.Text = "Smooth Map";
            this.contextSmoothMap.Click += new System.EventHandler(this.contextSmoothMap_Click);
            // 
            // contextSmoothSelection
            // 
            this.contextSmoothSelection.Name = "contextSmoothSelection";
            this.contextSmoothSelection.Size = new System.Drawing.Size(193, 22);
            this.contextSmoothSelection.Text = "Smooth Selection";
            this.contextSmoothSelection.Click += new System.EventHandler(this.contextSmoothSelection_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(190, 6);
            // 
            // contextTunerFilterData
            // 
            this.contextTunerFilterData.Name = "contextTunerFilterData";
            this.contextTunerFilterData.Size = new System.Drawing.Size(193, 22);
            this.contextTunerFilterData.Text = "Filter Selected Cells";
            this.contextTunerFilterData.ToolTipText = "Filter out static unacceptable values";
            this.contextTunerFilterData.Click += new System.EventHandler(this.toolTunerFilterSelectedCells_Click);
            // 
            // contextTunerFilterAllData
            // 
            this.contextTunerFilterAllData.Name = "contextTunerFilterAllData";
            this.contextTunerFilterAllData.Size = new System.Drawing.Size(193, 22);
            this.contextTunerFilterAllData.Text = "Filter Selected Map";
            this.contextTunerFilterAllData.ToolTipText = "Filter out static unacceptable values";
            this.contextTunerFilterAllData.Click += new System.EventHandler(this.tunerFilter_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // contextInsertRow
            // 
            this.contextInsertRow.Name = "contextInsertRow";
            this.contextInsertRow.Size = new System.Drawing.Size(193, 22);
            this.contextInsertRow.Text = "Insert Row";
            this.contextInsertRow.Click += new System.EventHandler(this.contextInsertRow_Click);
            // 
            // contextDeleteRow
            // 
            this.contextDeleteRow.Name = "contextDeleteRow";
            this.contextDeleteRow.Size = new System.Drawing.Size(193, 22);
            this.contextDeleteRow.Text = "Delete Row";
            this.contextDeleteRow.Click += new System.EventHandler(this.contextDeleteRow_Click);
            // 
            // contextInsertColumn
            // 
            this.contextInsertColumn.Name = "contextInsertColumn";
            this.contextInsertColumn.Size = new System.Drawing.Size(193, 22);
            this.contextInsertColumn.Text = "Insert Column";
            this.contextInsertColumn.Click += new System.EventHandler(this.contextInsertColumn_Click);
            // 
            // contextDeleteColumn
            // 
            this.contextDeleteColumn.Name = "contextDeleteColumn";
            this.contextDeleteColumn.Size = new System.Drawing.Size(193, 22);
            this.contextDeleteColumn.Text = "Delete Column";
            this.contextDeleteColumn.Click += new System.EventHandler(this.contextDeleteColumn_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(190, 6);
            // 
            // toolTunerTrace
            // 
            this.toolTunerTrace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleCellToolStripMenuItem,
            this.quadCellToolStripMenuItem,
            this.singleCellRowToolStripMenuItem,
            this.singleCellEndcolumnToolStripMenuItem,
            this.singleCellEndcolumnRowToolStripMenuItem});
            this.toolTunerTrace.Name = "toolTunerTrace";
            this.toolTunerTrace.Size = new System.Drawing.Size(193, 22);
            this.toolTunerTrace.Text = "Trace Method";
            this.toolTunerTrace.DropDownOpening += new System.EventHandler(this.ToolTunerTrace_DropDownOpening);
            // 
            // singleCellToolStripMenuItem
            // 
            this.singleCellToolStripMenuItem.CheckOnClick = true;
            this.singleCellToolStripMenuItem.Name = "singleCellToolStripMenuItem";
            this.singleCellToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.singleCellToolStripMenuItem.Tag = "0";
            this.singleCellToolStripMenuItem.Text = "Single Cell";
            this.singleCellToolStripMenuItem.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // quadCellToolStripMenuItem
            // 
            this.quadCellToolStripMenuItem.CheckOnClick = true;
            this.quadCellToolStripMenuItem.Name = "quadCellToolStripMenuItem";
            this.quadCellToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.quadCellToolStripMenuItem.Tag = "1";
            this.quadCellToolStripMenuItem.Text = "Quad Cell";
            this.quadCellToolStripMenuItem.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // singleCellRowToolStripMenuItem
            // 
            this.singleCellRowToolStripMenuItem.CheckOnClick = true;
            this.singleCellRowToolStripMenuItem.Name = "singleCellRowToolStripMenuItem";
            this.singleCellRowToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.singleCellRowToolStripMenuItem.Tag = "2";
            this.singleCellRowToolStripMenuItem.Text = "Single Cell->End Row";
            this.singleCellRowToolStripMenuItem.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // singleCellEndcolumnToolStripMenuItem
            // 
            this.singleCellEndcolumnToolStripMenuItem.CheckOnClick = true;
            this.singleCellEndcolumnToolStripMenuItem.Name = "singleCellEndcolumnToolStripMenuItem";
            this.singleCellEndcolumnToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.singleCellEndcolumnToolStripMenuItem.Tag = "3";
            this.singleCellEndcolumnToolStripMenuItem.Text = "Single Cell->End Column";
            this.singleCellEndcolumnToolStripMenuItem.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // singleCellEndcolumnRowToolStripMenuItem
            // 
            this.singleCellEndcolumnRowToolStripMenuItem.CheckOnClick = true;
            this.singleCellEndcolumnRowToolStripMenuItem.Name = "singleCellEndcolumnRowToolStripMenuItem";
            this.singleCellEndcolumnRowToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.singleCellEndcolumnRowToolStripMenuItem.Tag = "4";
            this.singleCellEndcolumnRowToolStripMenuItem.Text = "Single Cell->End Row&&Column";
            this.singleCellEndcolumnRowToolStripMenuItem.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // traceOptionsToolStripMenuItem
            // 
            this.traceOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem,
            this.followTraceOnRowcolumnHeaderToolStripMenuItem,
            this.drawOnCellTraceTheInterpolationToolStripMenuItem});
            this.traceOptionsToolStripMenuItem.Name = "traceOptionsToolStripMenuItem";
            this.traceOptionsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.traceOptionsToolStripMenuItem.Text = "Trace Options";
            this.traceOptionsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.ToolTunerTraceOptions_DropDownOpening);
            // 
            // followSelectedCellsOnRowcolumnHeaderToolStripMenuItem
            // 
            this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem.CheckOnClick = true;
            this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem.Name = "followSelectedCellsOnRowcolumnHeaderToolStripMenuItem";
            this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem.Text = "Follow selected cells on row/column header";
            this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem.Click += new System.EventHandler(this.FollowSelectedCellsOnRowcolumnHeaderToolStripMenuItem_Click);
            // 
            // followTraceOnRowcolumnHeaderToolStripMenuItem
            // 
            this.followTraceOnRowcolumnHeaderToolStripMenuItem.CheckOnClick = true;
            this.followTraceOnRowcolumnHeaderToolStripMenuItem.Name = "followTraceOnRowcolumnHeaderToolStripMenuItem";
            this.followTraceOnRowcolumnHeaderToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.followTraceOnRowcolumnHeaderToolStripMenuItem.Text = "Follow trace on row/column header";
            this.followTraceOnRowcolumnHeaderToolStripMenuItem.Click += new System.EventHandler(this.FollowTraceOnRowcolumnHeaderToolStripMenuItem_Click);
            // 
            // drawOnCellTraceTheInterpolationToolStripMenuItem
            // 
            this.drawOnCellTraceTheInterpolationToolStripMenuItem.CheckOnClick = true;
            this.drawOnCellTraceTheInterpolationToolStripMenuItem.Name = "drawOnCellTraceTheInterpolationToolStripMenuItem";
            this.drawOnCellTraceTheInterpolationToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.drawOnCellTraceTheInterpolationToolStripMenuItem.Text = "Draw on cell trace the interpolation";
            this.drawOnCellTraceTheInterpolationToolStripMenuItem.Click += new System.EventHandler(this.DrawOnCellTraceTheInterpolationToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ctrlGrid);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(480, 355);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(480, 430);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tableEditToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tableViewToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tunerToolStrip);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // tableEditToolStrip
            // 
            this.tableEditToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.tableEditToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnAdjSel,
            this.toolIncrease,
            this.toolDecrease,
            this.toolStripSeparator6,
            this.interplotaeRToolStripButton,
            this.interplolateCToolStripButton,
            this.interpolateXYtoolStripButton,
            this.toolSmooth});
            this.tableEditToolStrip.Location = new System.Drawing.Point(3, 0);
            this.tableEditToolStrip.Name = "tableEditToolStrip";
            this.tableEditToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tableEditToolStrip.Size = new System.Drawing.Size(179, 25);
            this.tableEditToolStrip.TabIndex = 6;
            // 
            // toolBtnAdjSel
            // 
            this.toolBtnAdjSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnAdjSel.Image = global::Properties.Resources.zone__arrow;
            this.toolBtnAdjSel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAdjSel.Name = "toolBtnAdjSel";
            this.toolBtnAdjSel.Size = new System.Drawing.Size(23, 22);
            this.toolBtnAdjSel.Text = "Adjust Selection (Ctrl+J)";
            this.toolBtnAdjSel.Click += new System.EventHandler(this.toolBtnAdjSel_Click);
            // 
            // toolIncrease
            // 
            this.toolIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolIncrease.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolIncrease.Image = global::Properties.Resources.zone__plus;
            this.toolIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolIncrease.Name = "toolIncrease";
            this.toolIncrease.Size = new System.Drawing.Size(23, 22);
            this.toolIncrease.Text = "Increase Selection";
            this.toolIncrease.Click += new System.EventHandler(this.toolIncrease_Click);
            // 
            // toolDecrease
            // 
            this.toolDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDecrease.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolDecrease.Image = global::Properties.Resources.zone__minus;
            this.toolDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDecrease.Name = "toolDecrease";
            this.toolDecrease.Size = new System.Drawing.Size(23, 22);
            this.toolDecrease.Text = "Decrease Selection";
            this.toolDecrease.Click += new System.EventHandler(this.toolDecrease_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // interplotaeRToolStripButton
            // 
            this.interplotaeRToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.interplotaeRToolStripButton.Enabled = false;
            this.interplotaeRToolStripButton.Image = global::Properties.Resources.table_split_row;
            this.interplotaeRToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.interplotaeRToolStripButton.Name = "interplotaeRToolStripButton";
            this.interplotaeRToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.interplotaeRToolStripButton.Text = "Interpolate Row(Y) Values (Ctrl + Shift + R)";
            this.interplotaeRToolStripButton.Click += new System.EventHandler(this.interplotaeRToolStripButton_Click);
            // 
            // interplolateCToolStripButton
            // 
            this.interplolateCToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.interplolateCToolStripButton.Enabled = false;
            this.interplolateCToolStripButton.Image = global::Properties.Resources.table_split_column;
            this.interplolateCToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.interplolateCToolStripButton.Name = "interplolateCToolStripButton";
            this.interplolateCToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.interplolateCToolStripButton.Text = "Interpolate Column(X) Values (Ctrl + Shift + C)";
            this.interplolateCToolStripButton.Click += new System.EventHandler(this.interplolateCToolStripButton_Click);
            // 
            // interpolateXYtoolStripButton
            // 
            this.interpolateXYtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.interpolateXYtoolStripButton.Enabled = false;
            this.interpolateXYtoolStripButton.Image = global::Properties.Resources.table_rotate;
            this.interpolateXYtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.interpolateXYtoolStripButton.Name = "interpolateXYtoolStripButton";
            this.interpolateXYtoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.interpolateXYtoolStripButton.Text = "Interpolate XY (Ctrl + Shift + I)";
            this.interpolateXYtoolStripButton.Click += new System.EventHandler(this.interpolateXYtoolStripButton_Click);
            // 
            // toolSmooth
            // 
            this.toolSmooth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSmooth.Image = global::Properties.Resources.table_heatmap;
            this.toolSmooth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSmooth.Name = "toolSmooth";
            this.toolSmooth.Size = new System.Drawing.Size(23, 22);
            this.toolSmooth.Text = "Smooth (Ctrl + Shift + M)";
            this.toolSmooth.Click += new System.EventHandler(this.toolSmooth_Click);
            // 
            // tableViewToolStrip
            // 
            this.tableViewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.tableViewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLowIgn,
            this.toolStripButtonHighIgn,
            this.toolStripButtonLowFuel,
            this.toolStripButtonHighFuel,
            this.toolStripSeparator14,
            this.toolStripButtonPrimary,
            this.toolStripButtonSecondary,
            this.toolStripSeparator1,
            this.toolStripButtonMapValue,
            this.toolStripButtonAFTarget,
            this.toolStripButtonAFReading,
            this.toolStripButtonAFDiff,
            this.toolStripButtonVE});
            this.tableViewToolStrip.Location = new System.Drawing.Point(3, 25);
            this.tableViewToolStrip.Name = "tableViewToolStrip";
            this.tableViewToolStrip.Size = new System.Drawing.Size(308, 25);
            this.tableViewToolStrip.TabIndex = 7;
            // 
            // toolStripButtonLowIgn
            // 
            this.toolStripButtonLowIgn.CheckOnClick = true;
            this.toolStripButtonLowIgn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLowIgn.Image = global::Properties.Resources.Lightning1;
            this.toolStripButtonLowIgn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLowIgn.Name = "toolStripButtonLowIgn";
            this.toolStripButtonLowIgn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLowIgn.Text = "toolStripButton1";
            this.toolStripButtonLowIgn.ToolTipText = "Low Cams Ignition";
            this.toolStripButtonLowIgn.Click += new System.EventHandler(this.ToolStripButtonLowIgn_Click);
            // 
            // toolStripButtonHighIgn
            // 
            this.toolStripButtonHighIgn.CheckOnClick = true;
            this.toolStripButtonHighIgn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHighIgn.Image = global::Properties.Resources.Lightning2;
            this.toolStripButtonHighIgn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHighIgn.Name = "toolStripButtonHighIgn";
            this.toolStripButtonHighIgn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHighIgn.Text = "toolStripButton2";
            this.toolStripButtonHighIgn.ToolTipText = "High Cams Ignition";
            this.toolStripButtonHighIgn.Click += new System.EventHandler(this.ToolStripButtonHighIgn_Click);
            // 
            // toolStripButtonLowFuel
            // 
            this.toolStripButtonLowFuel.CheckOnClick = true;
            this.toolStripButtonLowFuel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLowFuel.Image = global::Properties.Resources.injector1;
            this.toolStripButtonLowFuel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLowFuel.Name = "toolStripButtonLowFuel";
            this.toolStripButtonLowFuel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLowFuel.Text = "toolStripButton3";
            this.toolStripButtonLowFuel.ToolTipText = "Low Cams Fuel";
            this.toolStripButtonLowFuel.Click += new System.EventHandler(this.ToolStripButtonLowFuel_Click);
            // 
            // toolStripButtonHighFuel
            // 
            this.toolStripButtonHighFuel.CheckOnClick = true;
            this.toolStripButtonHighFuel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHighFuel.Image = global::Properties.Resources.injector2;
            this.toolStripButtonHighFuel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHighFuel.Name = "toolStripButtonHighFuel";
            this.toolStripButtonHighFuel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHighFuel.Text = "toolStripButton4";
            this.toolStripButtonHighFuel.ToolTipText = "High Cams Fuel";
            this.toolStripButtonHighFuel.Click += new System.EventHandler(this.ToolStripButtonHighFuel_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonPrimary
            // 
            this.toolStripButtonPrimary.CheckOnClick = true;
            this.toolStripButtonPrimary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrimary.Image = global::Properties.Resources.Map1;
            this.toolStripButtonPrimary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrimary.Name = "toolStripButtonPrimary";
            this.toolStripButtonPrimary.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrimary.Text = "toolStripButton5";
            this.toolStripButtonPrimary.ToolTipText = "Primary Maps";
            this.toolStripButtonPrimary.Click += new System.EventHandler(this.ToolStripButtonPrimary_Click);
            // 
            // toolStripButtonSecondary
            // 
            this.toolStripButtonSecondary.CheckOnClick = true;
            this.toolStripButtonSecondary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSecondary.Image = global::Properties.Resources.Map2;
            this.toolStripButtonSecondary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSecondary.Name = "toolStripButtonSecondary";
            this.toolStripButtonSecondary.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSecondary.Text = "toolStripButton6";
            this.toolStripButtonSecondary.ToolTipText = "Secondary Maps";
            this.toolStripButtonSecondary.Click += new System.EventHandler(this.ToolStripButtonSecondary_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMapValue
            // 
            this.toolStripButtonMapValue.CheckOnClick = true;
            this.toolStripButtonMapValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMapValue.Image = global::Properties.Resources._3d_bar_chart;
            this.toolStripButtonMapValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMapValue.Name = "toolStripButtonMapValue";
            this.toolStripButtonMapValue.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMapValue.Text = "toolStripButton7";
            this.toolStripButtonMapValue.ToolTipText = "Raw Maps Values";
            this.toolStripButtonMapValue.Click += new System.EventHandler(this.ToolStripButtonMapValue_Click);
            // 
            // toolStripButtonAFTarget
            // 
            this.toolStripButtonAFTarget.CheckOnClick = true;
            this.toolStripButtonAFTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAFTarget.Image = global::Properties.Resources.AFTarget;
            this.toolStripButtonAFTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAFTarget.Name = "toolStripButtonAFTarget";
            this.toolStripButtonAFTarget.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAFTarget.Text = "toolStripButton8";
            this.toolStripButtonAFTarget.ToolTipText = "AF Target";
            this.toolStripButtonAFTarget.Click += new System.EventHandler(this.ToolStripButtonAFTarget_Click);
            // 
            // toolStripButtonAFReading
            // 
            this.toolStripButtonAFReading.CheckOnClick = true;
            this.toolStripButtonAFReading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAFReading.Image = global::Properties.Resources.AFReading;
            this.toolStripButtonAFReading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAFReading.Name = "toolStripButtonAFReading";
            this.toolStripButtonAFReading.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAFReading.Text = "toolStripButton9";
            this.toolStripButtonAFReading.ToolTipText = "AF Reading";
            this.toolStripButtonAFReading.Click += new System.EventHandler(this.ToolStripButtonAFReading_Click);
            // 
            // toolStripButtonAFDiff
            // 
            this.toolStripButtonAFDiff.CheckOnClick = true;
            this.toolStripButtonAFDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAFDiff.Image = global::Properties.Resources.AFDiff;
            this.toolStripButtonAFDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAFDiff.Name = "toolStripButtonAFDiff";
            this.toolStripButtonAFDiff.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAFDiff.Text = "toolStripButton10";
            this.toolStripButtonAFDiff.ToolTipText = "AF Fuel Difference";
            this.toolStripButtonAFDiff.Click += new System.EventHandler(this.ToolStripButtonAFDiff_Click);
            // 
            // toolStripButtonVE
            // 
            this.toolStripButtonVE.CheckOnClick = true;
            this.toolStripButtonVE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVE.Image = global::Properties.Resources.table_VE;
            this.toolStripButtonVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVE.Name = "toolStripButtonVE";
            this.toolStripButtonVE.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonVE.Text = "toolStripButton11";
            this.toolStripButtonVE.ToolTipText = "VE Table";
            this.toolStripButtonVE.Click += new System.EventHandler(this.ToolStripButtonVE_Click);
            // 
            // tunerToolStrip
            // 
            this.tunerToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.tunerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolTunerMenu,
            this.toolStripDropDownButton1});
            this.tunerToolStrip.Location = new System.Drawing.Point(3, 50);
            this.tunerToolStrip.Name = "tunerToolStrip";
            this.tunerToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tunerToolStrip.Size = new System.Drawing.Size(161, 25);
            this.tunerToolStrip.TabIndex = 5;
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fuelInjDurToolStripMenuItem,
            this.FuelDutyToolStripMenuItem,
            this.FuelRawToolStripMenuItem,
            this.toolStripSeparator4,
            this.analog1Reading_Button,
            this.analog2Reading_Button,
            this.analog3Reading_Button,
            this.toolStripSeparator13,
            this.DynoWSReading_Button,
            this.DynoHPReading_Button,
            this.DynoNMReading_Button,
            this.AUX1Reading_Button,
            this.AUX2Reading_Button,
            this.AUX3Reading_Button,
            this.THCReading_Button});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(50, 22);
            this.toolStripDropDownButton2.Text = "Views";
            // 
            // fuelInjDurToolStripMenuItem
            // 
            this.fuelInjDurToolStripMenuItem.Name = "fuelInjDurToolStripMenuItem";
            this.fuelInjDurToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.fuelInjDurToolStripMenuItem.Tag = "1";
            this.fuelInjDurToolStripMenuItem.Text = "Injector Duration";
            this.fuelInjDurToolStripMenuItem.ToolTipText = "Show injector duration in fuel tables";
            this.fuelInjDurToolStripMenuItem.Click += new System.EventHandler(this.FuelDutyToolStripMenuItem_Click);
            // 
            // FuelDutyToolStripMenuItem
            // 
            this.FuelDutyToolStripMenuItem.Name = "FuelDutyToolStripMenuItem";
            this.FuelDutyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.FuelDutyToolStripMenuItem.Tag = "2";
            this.FuelDutyToolStripMenuItem.Text = "Fuel Duty Cycle";
            this.FuelDutyToolStripMenuItem.ToolTipText = "Show estimade duty cycle in fuel table";
            this.FuelDutyToolStripMenuItem.Click += new System.EventHandler(this.FuelDutyToolStripMenuItem_Click);
            // 
            // FuelRawToolStripMenuItem
            // 
            this.FuelRawToolStripMenuItem.Checked = true;
            this.FuelRawToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FuelRawToolStripMenuItem.Name = "FuelRawToolStripMenuItem";
            this.FuelRawToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.FuelRawToolStripMenuItem.Tag = "0";
            this.FuelRawToolStripMenuItem.Text = "Fuel Raw Value";
            this.FuelRawToolStripMenuItem.ToolTipText = "Show raw fuel values in fuel tables";
            this.FuelRawToolStripMenuItem.Click += new System.EventHandler(this.FuelDutyToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // analog1Reading_Button
            // 
            this.analog1Reading_Button.Name = "analog1Reading_Button";
            this.analog1Reading_Button.Size = new System.Drawing.Size(164, 22);
            this.analog1Reading_Button.Text = "Analog1 Reading";
            this.analog1Reading_Button.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // analog2Reading_Button
            // 
            this.analog2Reading_Button.Name = "analog2Reading_Button";
            this.analog2Reading_Button.Size = new System.Drawing.Size(164, 22);
            this.analog2Reading_Button.Text = "Analog2 Reading";
            this.analog2Reading_Button.Click += new System.EventHandler(this.analog2Reading_Button_Click);
            // 
            // analog3Reading_Button
            // 
            this.analog3Reading_Button.Name = "analog3Reading_Button";
            this.analog3Reading_Button.Size = new System.Drawing.Size(164, 22);
            this.analog3Reading_Button.Text = "Analog3 Reading";
            this.analog3Reading_Button.Click += new System.EventHandler(this.analog1ReadingToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(161, 6);
            // 
            // DynoWSReading_Button
            // 
            this.DynoWSReading_Button.Name = "DynoWSReading_Button";
            this.DynoWSReading_Button.Size = new System.Drawing.Size(164, 22);
            this.DynoWSReading_Button.Text = "Dyno Traction";
            this.DynoWSReading_Button.Click += new System.EventHandler(this.DynoWSReading_Button_Click);
            // 
            // DynoHPReading_Button
            // 
            this.DynoHPReading_Button.Name = "DynoHPReading_Button";
            this.DynoHPReading_Button.Size = new System.Drawing.Size(164, 22);
            this.DynoHPReading_Button.Text = "Dyno HP";
            this.DynoHPReading_Button.Click += new System.EventHandler(this.DynoHPReading_Button_Click);
            // 
            // DynoNMReading_Button
            // 
            this.DynoNMReading_Button.Name = "DynoNMReading_Button";
            this.DynoNMReading_Button.Size = new System.Drawing.Size(164, 22);
            this.DynoNMReading_Button.Text = "Dyno NM";
            this.DynoNMReading_Button.Click += new System.EventHandler(this.DynoNMReading_Button_Click);
            // 
            // AUX1Reading_Button
            // 
            this.AUX1Reading_Button.Name = "AUX1Reading_Button";
            this.AUX1Reading_Button.Size = new System.Drawing.Size(164, 22);
            this.AUX1Reading_Button.Text = "Dyno AUX1";
            this.AUX1Reading_Button.Click += new System.EventHandler(this.AUX1Reading_Button_Click);
            // 
            // AUX2Reading_Button
            // 
            this.AUX2Reading_Button.Name = "AUX2Reading_Button";
            this.AUX2Reading_Button.Size = new System.Drawing.Size(164, 22);
            this.AUX2Reading_Button.Text = "Dyno AUX2";
            this.AUX2Reading_Button.Click += new System.EventHandler(this.AUX2Reading_Button_Click);
            // 
            // AUX3Reading_Button
            // 
            this.AUX3Reading_Button.Name = "AUX3Reading_Button";
            this.AUX3Reading_Button.Size = new System.Drawing.Size(164, 22);
            this.AUX3Reading_Button.Text = "Dyno AUX3";
            this.AUX3Reading_Button.Click += new System.EventHandler(this.AUX3Reading_Button_Click);
            // 
            // THCReading_Button
            // 
            this.THCReading_Button.Name = "THCReading_Button";
            this.THCReading_Button.Size = new System.Drawing.Size(164, 22);
            this.THCReading_Button.Text = "Dyno THC";
            this.THCReading_Button.Click += new System.EventHandler(this.THCReading_Button_Click);
            // 
            // toolTunerMenu
            // 
            this.toolTunerMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolTunerMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyPrimarySecondaryToolStripMenuItem,
            this.scalarsToolStripMenuItem,
            this.toolStripSeparator10,
            this.toolTunerSmartTrack,
            this.toolTunerMapTrail,
            this.toolTunerFollowVtec,
            this.toolTunerFollowDualTables,
            this.autoAdjustSelectionToolStripMenuItem,
            this.toolStripSeparator9,
            this.graphClearShort,
            this.toolTunerClear,
            this.toolTunerClearAll,
            this.toolTunerClearTrail});
            this.toolTunerMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTunerMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTunerMenu.Name = "toolTunerMenu";
            this.toolTunerMenu.Size = new System.Drawing.Size(47, 22);
            this.toolTunerMenu.Text = "Tools";
            this.toolTunerMenu.DropDownOpening += new System.EventHandler(this.toolTunerMenu_DropDownOpening);
            // 
            // copyPrimarySecondaryToolStripMenuItem
            // 
            this.copyPrimarySecondaryToolStripMenuItem.Name = "copyPrimarySecondaryToolStripMenuItem";
            this.copyPrimarySecondaryToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.copyPrimarySecondaryToolStripMenuItem.Text = "Copy Primary/Secondary";
            this.copyPrimarySecondaryToolStripMenuItem.Click += new System.EventHandler(this.copyPrimarySecondaryToolStripMenuItem_Click);
            // 
            // scalarsToolStripMenuItem
            // 
            this.scalarsToolStripMenuItem.Name = "scalarsToolStripMenuItem";
            this.scalarsToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.scalarsToolStripMenuItem.Text = "Scalar Setup";
            this.scalarsToolStripMenuItem.Click += new System.EventHandler(this.scalarsToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(250, 6);
            // 
            // toolTunerSmartTrack
            // 
            this.toolTunerSmartTrack.CheckOnClick = true;
            this.toolTunerSmartTrack.Name = "toolTunerSmartTrack";
            this.toolTunerSmartTrack.Size = new System.Drawing.Size(253, 22);
            this.toolTunerSmartTrack.Text = "Smart Tracking";
            this.toolTunerSmartTrack.ToolTipText = "Smart track map trace cells";
            this.toolTunerSmartTrack.CheckedChanged += new System.EventHandler(this.toolTunerSmartTrack_CheckedChanged);
            // 
            // toolTunerMapTrail
            // 
            this.toolTunerMapTrail.CheckOnClick = true;
            this.toolTunerMapTrail.Name = "toolTunerMapTrail";
            this.toolTunerMapTrail.Size = new System.Drawing.Size(253, 22);
            this.toolTunerMapTrail.Text = "Map Trace Trail";
            this.toolTunerMapTrail.ToolTipText = "Map Trace Trail";
            this.toolTunerMapTrail.CheckedChanged += new System.EventHandler(this.toolTunerMapTrail_CheckedChanged);
            // 
            // toolTunerFollowVtec
            // 
            this.toolTunerFollowVtec.CheckOnClick = true;
            this.toolTunerFollowVtec.Name = "toolTunerFollowVtec";
            this.toolTunerFollowVtec.Size = new System.Drawing.Size(253, 22);
            this.toolTunerFollowVtec.Text = "Follow Vtec";
            this.toolTunerFollowVtec.CheckedChanged += new System.EventHandler(this.toolTunerFollowVtec_CheckedChanged);
            // 
            // toolTunerFollowDualTables
            // 
            this.toolTunerFollowDualTables.CheckOnClick = true;
            this.toolTunerFollowDualTables.Name = "toolTunerFollowDualTables";
            this.toolTunerFollowDualTables.Size = new System.Drawing.Size(253, 22);
            this.toolTunerFollowDualTables.Text = "Follow Secondary Maps";
            this.toolTunerFollowDualTables.CheckedChanged += new System.EventHandler(this.toolTunerFollowDualTables_CheckedChanged);
            // 
            // autoAdjustSelectionToolStripMenuItem
            // 
            this.autoAdjustSelectionToolStripMenuItem.Name = "autoAdjustSelectionToolStripMenuItem";
            this.autoAdjustSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.autoAdjustSelectionToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.autoAdjustSelectionToolStripMenuItem.Text = "Auto Adjust Selection";
            this.autoAdjustSelectionToolStripMenuItem.ToolTipText = "Adjust selection by average percentage";
            this.autoAdjustSelectionToolStripMenuItem.Click += new System.EventHandler(this.autoAdjustSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(250, 6);
            // 
            // graphClearShort
            // 
            this.graphClearShort.Name = "graphClearShort";
            this.graphClearShort.Size = new System.Drawing.Size(253, 22);
            this.graphClearShort.Text = "Clear Plots";
            this.graphClearShort.Click += new System.EventHandler(this.grphBtnClear_Click);
            // 
            // toolTunerClear
            // 
            this.toolTunerClear.Name = "toolTunerClear";
            this.toolTunerClear.Size = new System.Drawing.Size(253, 22);
            this.toolTunerClear.Text = "Clear Data";
            this.toolTunerClear.ToolTipText = "Clear all logged data";
            this.toolTunerClear.Click += new System.EventHandler(this.toolTunerClear_Click);
            // 
            // toolTunerClearAll
            // 
            this.toolTunerClearAll.Name = "toolTunerClearAll";
            this.toolTunerClearAll.Size = new System.Drawing.Size(253, 22);
            this.toolTunerClearAll.Text = "Clear Recordings";
            this.toolTunerClearAll.Click += new System.EventHandler(this.tunerClearAll_Click);
            // 
            // toolTunerClearTrail
            // 
            this.toolTunerClearTrail.Name = "toolTunerClearTrail";
            this.toolTunerClearTrail.Size = new System.Drawing.Size(253, 22);
            this.toolTunerClearTrail.Text = "Clear Map Trace Trail";
            this.toolTunerClearTrail.Click += new System.EventHandler(this.tunerClearMapTrails_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dGraphToolStripMenuItem,
            this.dGraphToolStripMenuItem1,
            this.graphSetupToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownButton1.Text = "Graph";
            // 
            // dGraphToolStripMenuItem
            // 
            this.dGraphToolStripMenuItem.Name = "dGraphToolStripMenuItem";
            this.dGraphToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.dGraphToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.dGraphToolStripMenuItem.Text = "2D Graph";
            this.dGraphToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton_1_Click);
            // 
            // dGraphToolStripMenuItem1
            // 
            this.dGraphToolStripMenuItem1.Name = "dGraphToolStripMenuItem1";
            this.dGraphToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F6)));
            this.dGraphToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.dGraphToolStripMenuItem1.Text = "3D Graph";
            this.dGraphToolStripMenuItem1.Click += new System.EventHandler(this.toolStripButton_2_Click);
            // 
            // graphSetupToolStripMenuItem
            // 
            this.graphSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.belowTableToolStripMenuItem,
            this.onlyNAViewToolStripMenuItem});
            this.graphSetupToolStripMenuItem.Name = "graphSetupToolStripMenuItem";
            this.graphSetupToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.graphSetupToolStripMenuItem.Text = "Graph Setup";
            // 
            // belowTableToolStripMenuItem
            // 
            this.belowTableToolStripMenuItem.Name = "belowTableToolStripMenuItem";
            this.belowTableToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F7)));
            this.belowTableToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.belowTableToolStripMenuItem.Text = "Below Table";
            this.belowTableToolStripMenuItem.Click += new System.EventHandler(this.belowTableToolStripMenuItem_Click);
            // 
            // onlyNAViewToolStripMenuItem
            // 
            this.onlyNAViewToolStripMenuItem.Name = "onlyNAViewToolStripMenuItem";
            this.onlyNAViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F8)));
            this.onlyNAViewToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.onlyNAViewToolStripMenuItem.Text = "Only N/A View";
            this.onlyNAViewToolStripMenuItem.Click += new System.EventHandler(this.onlyNAViewToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStripContainer2);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(484, 434);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // toolStripContainer2
            // 
            this.toolStripContainer2.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.ctrlMapGraph1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(92, 96);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(92, 96);
            this.toolStripContainer2.TabIndex = 3;
            this.toolStripContainer2.Text = "toolStripContainer2";
            this.toolStripContainer2.TopToolStripPanelVisible = false;
            // 
            // ctrlMapGraph1
            // 
            this.ctrlMapGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMapGraph1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlMapGraph1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMapGraph1.Name = "ctrlMapGraph1";
            this.ctrlMapGraph1.Size = new System.Drawing.Size(92, 96);
            this.ctrlMapGraph1.TabIndex = 1;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator8,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator12,
            this.toolStripMenuItem6,
            this.toolStripMenuItem12});
            this.contextMenuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(172, 170);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem1.Text = "Undo";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.contextUndo_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem2.Text = "Redo";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.contextRedo_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem3.Text = "Increase selection";
            this.toolStripMenuItem3.ToolTipText = "Increase selection";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolIncrease_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem4.Text = "Decrease selection";
            this.toolStripMenuItem4.ToolTipText = "Decrease selection";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolDecrease_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem5.Text = "Adjust selection";
            this.toolStripMenuItem5.ToolTipText = "Adjust selection";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolBtnAdjSel_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem6.Text = "Trace Method";
            this.toolStripMenuItem6.DropDownOpening += new System.EventHandler(this.ToolTunerTrace_DropDownOpening);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.CheckOnClick = true;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem7.Tag = "0";
            this.toolStripMenuItem7.Text = "Single Cell";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.CheckOnClick = true;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem8.Tag = "1";
            this.toolStripMenuItem8.Text = "Quad Cell";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.CheckOnClick = true;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem9.Tag = "2";
            this.toolStripMenuItem9.Text = "Single Cell->End Row";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.CheckOnClick = true;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem10.Tag = "3";
            this.toolStripMenuItem10.Text = "Single Cell->End Column";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.CheckOnClick = true;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem11.Tag = "4";
            this.toolStripMenuItem11.Text = "Single Cell->End Row&&Column";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.SingleCellToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem12.Text = "Trace Options";
            this.toolStripMenuItem12.DropDownOpening += new System.EventHandler(this.ToolTunerTraceOptions_DropDownOpening);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.CheckOnClick = true;
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(306, 22);
            this.toolStripMenuItem13.Text = "Follow selected cells on row/column header";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.FollowSelectedCellsOnRowcolumnHeaderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.CheckOnClick = true;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(306, 22);
            this.toolStripMenuItem14.Text = "Follow trace on row/column header";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.FollowTraceOnRowcolumnHeaderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.CheckOnClick = true;
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(306, 22);
            this.toolStripMenuItem15.Text = "Draw on cell trace the interpolation";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.DrawOnCellTraceTheInterpolationToolStripMenuItem_Click);
            // 
            // FrmGridChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 434);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(350, 150);
            this.Name = "FrmGridChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGridChart_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGridChart_FormClosed);
            this.Load += new System.EventHandler(this.FrmGridChart_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmGridChart_ResizeEnd);
            this.Click += new System.EventHandler(this.FrmGridChart_Click);
            this.Enter += new System.EventHandler(this.FrmGridChart_Enter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmGridChart_KeyDown);
            this.Resize += new System.EventHandler(this.FrmGridChart_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableEditToolStrip.ResumeLayout(false);
            this.tableEditToolStrip.PerformLayout();
            this.tableViewToolStrip.ResumeLayout(false);
            this.tableViewToolStrip.PerformLayout();
            this.tunerToolStrip.ResumeLayout(false);
            this.tunerToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    public void ReloadShortcuts()
    {
        if (this.class10_settings_0.GetKeySettings("Clear data live plot"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.graphClearShort.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Clear all recording"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.toolTunerClearAll.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Graph 2D View"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.dGraphToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Graph 3D View"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.dGraphToolStripMenuItem1.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Graph 2D/3D View - Bellow Table"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.belowTableToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class10_settings_0.GetKeySettings("Graph 2D/3D View - Only N/A"))
        {
            Keys CtrlKey = 0; if (this.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.onlyNAViewToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class10_settings_0.Shortcut_KeyPressed)));
        }
    }

    private void method_1(object sender, EventArgs e)
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        this.int_0 = this.ctrlGrid.method_10();
        if (cells.Count > 0)
        {
            int num = this.int_0[0];
            int num3 = this.int_0[1];
            int num2 = this.int_0[2];
            int num4 = this.int_0[3];
            this.double_0 = 0.0;
            this.double_2 = 0.0;
            this.double_4 = 0.0;
            int num5 = 0;
            if (cells.Count > 1)
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    this.object_0 = this.class12_afrT_0.method_17(cells[i].ColumnIndex, cells[i].RowIndex);
                    if (this.class10_settings_0.bool_49)
                    {
                        this.class12_afrT_0.method_6(cells[i].ColumnIndex, cells[i].RowIndex);
                    }
                    this.object_1 = this.class12_afrT_0.method_16(cells[i].ColumnIndex, cells[i].RowIndex);
                    if (((this.object_0 != null) && (this.object_0.ToString() != "-")) && ((this.object_1 != null) && (this.object_1.ToString() != "-")))
                    {
                        this.double_0 += (double)this.object_0;
                        this.double_2 += (double)this.object_1;
                        num5++;
                    }
                }
                if ((((double)num5) / ((double)cells.Count)) >= (((double)this.class10_settings_0.int_40) / 100.0))
                {
                    this.double_1 = this.double_0 / ((double)num5);
                    this.double_3 = this.double_2 / ((double)num5);
                    this.double_4 = -this.double_3 * this.class10_settings_0.double_15;
                    if (Math.Abs(this.double_4) < this.class10_settings_0.double_13)
                    {
                        this.double_4 = 0.0;
                    }
                }
            }
            else
            {
                this.double_4 = 0.0;
            }
            this.toolSmooth.Text = "Smooth Current Map  (Ctrl + Shift + M)";
            this.toolSmooth.ToolTipText = "Smooth Current Map  (Ctrl + Shift + M)";
            this.contextSmoothMap.Text = "Smooth Current Map";
            this.contextSmoothSelection.Enabled = false;
            this.frmMain_0.toolStripButtonSmoothMap.Enabled = false;
            this.frmMain_0.smoothMapsToolStripMenuItem.Enabled = false;
            if ((num2 - num) < 3)
            {
                if ((num4 - num3) < 3)
                {
                    this.toolSmooth.Text = "Smooth Current Map  (Ctrl + Shift + M)";
                    this.toolSmooth.ToolTipText = "Smooth Current Map  (Ctrl + Shift + M)";
                }
                else
                {
                    this.toolSmooth.Text = "Smooth Current Selection  (Ctrl + Shift + M)";
                    this.toolSmooth.ToolTipText = "Smooth Current Selection  (Ctrl + Shift + M)";
                    this.contextSmoothSelection.Enabled = true;
                    this.frmMain_0.toolStripButtonSmoothMap.Enabled = true;
                    this.frmMain_0.smoothMapsToolStripMenuItem.Enabled = true;
                }
            }
            else if ((num2 - num) < 3)
            {
                this.toolSmooth.Text = "Smooth Current Map  (Ctrl + Shift + M)";
                this.toolSmooth.ToolTipText = "Smooth Current Map  (Ctrl + Shift + M)";
            }
            else
            {
                this.toolSmooth.Text = "Smooth Current Selection  (Ctrl + Shift + M)";
                this.toolSmooth.ToolTipText = "Smooth Current Selection  (Ctrl + Shift + M)";
                this.contextSmoothSelection.Enabled = true;
                this.frmMain_0.toolStripButtonSmoothMap.Enabled = true;
                this.frmMain_0.smoothMapsToolStripMenuItem.Enabled = true;
            }
            this.contextInterpolateXYTool.Enabled = false;
            this.contextInterpolateColumnsTool.Enabled = false;
            this.contextInterpolateRowsTool.Enabled = false;

            this.interplotaeRToolStripButton.Enabled = false;
            this.interplolateCToolStripButton.Enabled = false;
            this.interpolateXYtoolStripButton.Enabled = false;

            this.frmMain_0.interpolateToolStripMenuItem.Enabled = false;
            this.frmMain_0.interpolateHorizontallyToolStripMenuItem.Enabled = false;
            this.frmMain_0.interpolateVerticallyToolStripMenuItem.Enabled = false;

            this.frmMain_0.toolStripButtonInterpolate.Enabled = false;
            this.frmMain_0.toolStripButtonInterpolateRow.Enabled = false;
            this.frmMain_0.toolStripButtonInterpolateColomn.Enabled = false;

            if (((num2 - num) >= 2))
            {
                this.contextInterpolateColumnsTool.Enabled = true;
                this.interplolateCToolStripButton.Enabled = true;
                this.frmMain_0.interpolateVerticallyToolStripMenuItem.Enabled = true;
                this.frmMain_0.toolStripButtonInterpolateColomn.Enabled = true;
            }
            if (((num4 - num3) >= 2))
            {
                this.interplotaeRToolStripButton.Enabled = true;
                this.contextInterpolateRowsTool.Enabled = true;
                this.frmMain_0.interpolateHorizontallyToolStripMenuItem.Enabled = true;
                this.frmMain_0.toolStripButtonInterpolateRow.Enabled = true;
            }
            if ((((num2 - num) >= 2) && ((num4 - num3) >= 2)))
            {
                this.contextInterpolateXYTool.Enabled = true;
                this.interpolateXYtoolStripButton.Enabled = true;
                this.frmMain_0.interpolateToolStripMenuItem.Enabled = true;
                this.frmMain_0.toolStripButtonInterpolate.Enabled = true;
            }
            //this.ctrlMapGraph1.Refresh();
        }
    }

    public void method_10()
    {
        this.ctrlGrid.method_8();
    }

    private void method_11(int int_3, bool bool_3)
    {
        if (bool_3)
        {
            for (int i = this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1; i > int_3; i--)
            {
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    if (!this.class18_0.method_39())
                    {
                        SelectedTable table = SelectedTable.fuel1_hi;
                        float num3 = this.class18_0.method_175((byte)(i - 1), (byte)j, table);
                        this.class18_0.method_177((byte)i, (byte)j, num3, table);
                        table = SelectedTable.ign1_hi;
                        num3 = this.class18_0.method_175((byte)(i - 1), (byte)j, table);
                        this.class18_0.method_177((byte)i, (byte)j, num3, table);
                        SelectedTable table2 = SelectedTable.fuel1_lo;
                        float num4 = this.class18_0.method_175((byte)(i - 1), (byte)j, table2);
                        this.class18_0.method_177((byte)i, (byte)j, num4, table2);
                        table2 = SelectedTable.ign1_lo;
                        num4 = this.class18_0.method_175((byte)(i - 1), (byte)j, table2);
                        this.class18_0.method_177((byte)i, (byte)j, num4, table2);
                    }
                    else
                    {
                        SelectedTable table3 = SelectedTable.fuel2_hi;
                        float num5 = this.class18_0.method_175((byte)(i - 1), (byte)j, table3);
                        this.class18_0.method_177((byte)i, (byte)j, num5, table3);
                        table3 = SelectedTable.ign2_hi;
                        num5 = this.class18_0.method_175((byte)(i - 1), (byte)j, table3);
                        this.class18_0.method_177((byte)i, (byte)j, num5, table3);
                        SelectedTable table4 = SelectedTable.fuel2_lo;
                        float num6 = this.class18_0.method_175((byte)(i - 1), (byte)j, table4);
                        this.class18_0.method_177((byte)i, (byte)j, num6, table4);
                        table4 = SelectedTable.ign2_lo;
                        num6 = this.class18_0.method_175((byte)(i - 1), (byte)j, table4);
                        this.class18_0.method_177((byte)i, (byte)j, num6, table4);
                        SelectedTable table5 = this.class18_0.method_4();
                        float num7 = this.class18_0.method_175((byte)(i - 1), (byte)j, table5);
                        this.class18_0.method_177((byte)i, (byte)j, num7, table5);
                    }
                }
            }
        }
        else
        {
            for (int k = this.class18_0.method_32_GetRPM_RowsNumber() - 1; k > int_3; k--)
            {
                for (int m = 0; m < this.class18_0.method_33(); m++)
                {
                    if (!this.class18_0.method_39())
                    {
                        if (this.class18_0.method_36())
                        {
                            SelectedTable table6 = SelectedTable.fuel1_hi;
                            float num10 = this.class18_0.method_175((byte)m, (byte)(k - 1), table6);
                            this.class18_0.method_177((byte)m, (byte)k, num10, table6);
                            table6 = SelectedTable.ign1_hi;
                            num10 = this.class18_0.method_175((byte)m, (byte)(k - 1), table6);
                            this.class18_0.method_177((byte)m, (byte)k, num10, table6);
                        }
                        else
                        {
                            SelectedTable table7 = SelectedTable.fuel1_lo;
                            float num11 = this.class18_0.method_175((byte)m, (byte)(k - 1), table7);
                            this.class18_0.method_177((byte)m, (byte)k, num11, table7);
                            table7 = SelectedTable.ign1_lo;
                            num11 = this.class18_0.method_175((byte)m, (byte)(k - 1), table7);
                            this.class18_0.method_177((byte)m, (byte)k, num11, table7);
                        }
                    }
                    else if (this.class18_0.method_36())
                    {
                        SelectedTable table8 = SelectedTable.fuel2_hi;
                        float num12 = this.class18_0.method_175((byte)m, (byte)(k - 1), table8);
                        this.class18_0.method_177((byte)m, (byte)k, num12, table8);
                        table8 = SelectedTable.ign2_hi;
                        num12 = this.class18_0.method_175((byte)m, (byte)(k - 1), table8);
                        this.class18_0.method_177((byte)m, (byte)k, num12, table8);
                    }
                    else
                    {
                        SelectedTable table9 = SelectedTable.fuel2_lo;
                        float num13 = this.class18_0.method_175((byte)m, (byte)(k - 1), table9);
                        this.class18_0.method_177((byte)m, (byte)k, num13, table9);
                        table9 = SelectedTable.ign2_lo;
                        num13 = this.class18_0.method_175((byte)m, (byte)(k - 1), table9);
                        this.class18_0.method_177((byte)m, (byte)k, num13, table9);
                    }
                }
            }
        }
    }

    private void method_12(int int_3, bool bool_3)
    {
        if (bool_3)
        {
            for (int i = int_3; i < (this.class18_0.method_33() - 1); i++)
            {
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    if (!this.class18_0.method_39())
                    {
                        if (this.class18_0.method_36())
                        {
                            SelectedTable table = SelectedTable.fuel1_hi;
                            float num3 = this.class18_0.method_175((byte)(i + 1), (byte)j, table);
                            this.class18_0.method_177((byte)i, (byte)j, num3, table);
                            table = SelectedTable.ign1_hi;
                            num3 = this.class18_0.method_175((byte)(i + 1), (byte)j, table);
                            this.class18_0.method_177((byte)i, (byte)j, num3, table);
                        }
                        else
                        {
                            SelectedTable table2 = SelectedTable.fuel1_lo;
                            float num4 = this.class18_0.method_175((byte)(i + 1), (byte)j, table2);
                            this.class18_0.method_177((byte)i, (byte)j, num4, table2);
                            table2 = SelectedTable.ign1_lo;
                            num4 = this.class18_0.method_175((byte)(i + 1), (byte)j, table2);
                            this.class18_0.method_177((byte)i, (byte)j, num4, table2);
                        }
                    }
                    else if (this.class18_0.method_36())
                    {
                        SelectedTable table3 = SelectedTable.fuel2_hi;
                        float num5 = this.class18_0.method_175((byte)(i + 1), (byte)j, table3);
                        this.class18_0.method_177((byte)i, (byte)j, num5, table3);
                        table3 = SelectedTable.ign2_hi;
                        num5 = this.class18_0.method_175((byte)(i + 1), (byte)j, table3);
                        this.class18_0.method_177((byte)i, (byte)j, num5, table3);
                    }
                    else
                    {
                        SelectedTable table4 = SelectedTable.fuel2_lo;
                        float num6 = this.class18_0.method_175((byte)(i + 1), (byte)j, table4);
                        this.class18_0.method_177((byte)i, (byte)j, num6, table4);
                        table4 = SelectedTable.ign2_lo;
                        num6 = this.class18_0.method_175((byte)(i + 1), (byte)j, table4);
                        this.class18_0.method_177((byte)i, (byte)j, num6, table4);
                    }
                }
            }
        }
        else
        {
            for (int k = int_3; k < (this.class18_0.method_32_GetRPM_RowsNumber() - 1); k++)
            {
                for (int m = 0; m < this.class18_0.method_33(); m++)
                {
                    if (!this.class18_0.method_39())
                    {
                        if (this.class18_0.method_36())
                        {
                            SelectedTable table5 = SelectedTable.fuel1_hi;
                            float num9 = this.class18_0.method_175((byte)m, (byte)(k + 1), table5);
                            this.class18_0.method_177((byte)m, (byte)k, num9, table5);
                            table5 = SelectedTable.ign1_hi;
                            num9 = this.class18_0.method_175((byte)m, (byte)(k + 1), table5);
                            this.class18_0.method_177((byte)m, (byte)k, num9, table5);
                        }
                        else
                        {
                            SelectedTable table6 = SelectedTable.fuel1_lo;
                            float num10 = this.class18_0.method_175((byte)m, (byte)(k + 1), table6);
                            this.class18_0.method_177((byte)m, (byte)k, num10, table6);
                            table6 = SelectedTable.ign1_lo;
                            num10 = this.class18_0.method_175((byte)m, (byte)(k + 1), table6);
                            this.class18_0.method_177((byte)m, (byte)k, num10, table6);
                        }
                    }
                    else if (this.class18_0.method_36())
                    {
                        SelectedTable table7 = SelectedTable.fuel2_hi;
                        float num11 = this.class18_0.method_175((byte)(m + 1), (byte)k, table7);
                        this.class18_0.method_177((byte)m, (byte)k, num11, table7);
                        table7 = SelectedTable.ign2_hi;
                        num11 = this.class18_0.method_175((byte)m, (byte)(k + 1), table7);
                        this.class18_0.method_177((byte)m, (byte)k, num11, table7);
                    }
                    else
                    {
                        SelectedTable table8 = SelectedTable.fuel2_lo;
                        float num12 = this.class18_0.method_175((byte)(m + 1), (byte)k, table8);
                        this.class18_0.method_177((byte)m, (byte)k, num12, table8);
                        table8 = SelectedTable.ign2_lo;
                        num12 = this.class18_0.method_175((byte)m, (byte)(k + 1), table8);
                        this.class18_0.method_177((byte)m, (byte)k, num12, table8);
                    }
                }
            }
        }
    }

    private void method_13(int int_3, bool bool_3)
    {
        byte num;
        byte num2;
        byte num3;
        byte num4;
        float num5 = 0f;
        float num6 = 0f;
        if (bool_3)
        {
            num = (byte)(int_3 - 1);
            if (num < 0)
            {
                num = 0;
            }
            num3 = 0;
            num2 = (byte)(int_3 + 1);
            if (num2 > (this.class18_0.method_33() - 1))
            {
                num2 = (byte)(this.class18_0.method_33() - 1);
            }
            num4 = (byte)(this.class18_0.method_32_GetRPM_RowsNumber() - 1);
            if (!this.class18_0.method_39())
            {
                for (int i = 1; i <= 4; i++)
                {
                    SelectedTable table = (SelectedTable)i;
                    if ((num2 - num) >= 2)
                    {
                        for (byte j = num3; j <= num4; j = (byte)(j + 1))
                        {
                            num5 = (this.class18_0.method_175(num2, j, table) - this.class18_0.method_175(num, j, table)) / ((float)(this.class18_0.method_166(num2, table) - this.class18_0.method_166(num, table)));
                            num6 = this.class18_0.method_175(num, j, table) - (num5 * this.class18_0.method_166(num, table));
                            for (byte k = (byte)(num + 1); k < num2; k = (byte)(k + 1))
                            {
                                this.class18_0.method_175(k, j, table);
                                float num10 = (num5 * this.class18_0.method_166(k, table)) + num6;
                                this.class18_0.method_177(k, j, num10, table);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int m = 5; m <= 8; m++)
                {
                    SelectedTable table2 = (SelectedTable)m;
                    if ((num2 - num) >= 2)
                    {
                        for (byte n = num3; n <= num4; n = (byte)(n + 1))
                        {
                            num5 = (this.class18_0.method_175(num2, n, table2) - this.class18_0.method_175(num, n, table2)) / ((float)(this.class18_0.method_166(num2, table2) - this.class18_0.method_166(num, table2)));
                            num6 = this.class18_0.method_175(num, n, table2) - (num5 * this.class18_0.method_166(num, table2));
                            for (byte num13 = (byte)(num + 1); num13 < num2; num13 = (byte)(num13 + 1))
                            {
                                this.class18_0.method_175(num13, n, table2);
                                float num14 = (num5 * this.class18_0.method_166(num13, table2)) + num6;
                                this.class18_0.method_177(num13, n, num14, table2);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            num = 0;
            num3 = (byte)(int_3 - 1);
            if (num3 < 0)
            {
                num3 = 0;
            }
            num2 = (byte)(this.class18_0.method_33() - 1);
            num4 = (byte)(int_3 + 1);
            if (num4 > (this.class18_0.method_32_GetRPM_RowsNumber() - 1))
            {
                num4 = (byte)(this.class18_0.method_32_GetRPM_RowsNumber() - 1);
            }
            if (!this.class18_0.method_39())
            {
                for (int num15 = 1; num15 <= 4; num15++)
                {
                    SelectedTable table3 = (SelectedTable)num15;
                    if ((num4 - num3) >= 2)
                    {
                        for (byte num16 = num; num16 <= num2; num16 = (byte)(num16 + 1))
                        {
                            num5 = (this.class18_0.method_175(num16, num4, table3) - this.class18_0.method_175(num16, num3, table3)) / ((float)(this.class18_0.method_166(num4, table3) - this.class18_0.method_166(num3, table3)));
                            num6 = this.class18_0.method_175(num16, num3, table3) - (num5 * this.class18_0.method_166(num3, table3));
                            for (byte num17 = (byte)(num3 + 1); num17 < num4; num17 = (byte)(num17 + 1))
                            {
                                this.class18_0.method_175(num16, num17, table3);
                                float num18 = (num5 * this.class18_0.method_166(num17, table3)) + num6;
                                this.class18_0.method_177(num16, num17, num18, table3);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int num19 = 5; num19 <= 8; num19++)
                {
                    SelectedTable table4 = (SelectedTable)num19;
                    if ((num2 - num) >= 2)
                    {
                        for (byte num20 = num; num20 <= num2; num20 = (byte)(num20 + 1))
                        {
                            num5 = (this.class18_0.method_175(num20, num4, table4) - this.class18_0.method_175(num20, num3, table4)) / ((float)(this.class18_0.method_166(num4, table4) - this.class18_0.method_166(num3, table4)));
                            num6 = this.class18_0.method_175(num20, num3, table4) - (num5 * this.class18_0.method_166(num3, table4));
                            for (byte num21 = (byte)(num3 + 1); num21 < num4; num21 = (byte)(num21 + 1))
                            {
                                this.class18_0.method_175(num20, num21, table4);
                                float num22 = (num5 * this.class18_0.method_166(num21, table4)) + num6;
                                this.class18_0.method_177(num20, num21, num22, table4);
                            }
                        }
                    }
                }
            }
        }
    }

    private void method_14()
    {
        string str2;
        int num = this.ctrlGrid.method_19();
        switch (num)
        {
            case -1:
                num = this.ctrlGrid.method_11();
                break;

            case 0:
                return;
        }
        int num2 = this.class18_0.method_163((byte)num);
        string str = this.class18_0.method_167((byte)num);
        if (num2 > this.class10_settings_0.int_6)
        {
            str = str + " " + this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_1);
        }
        else
        {
            str = str + " " + this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_0);
        }
        if (this.class18_0.method_39())
        {
            str2 = "secondary map";
        }
        else
        {
            str2 = "primary map";
        }
        if (MessageBox.Show(Form.ActiveForm, "This will insert a column before " + str + " and move all the columns to the right." + Environment.NewLine + " Both fuel and ignition map on the " + str2 + " will be changed." + Environment.NewLine + " Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        {
            str = string.Empty;
            str2 = string.Empty;
            byte num3 = (byte)(this.class10_settings_0.method_11_GetMAP_ColumnsNumber() + 1);
            if (num3 > 0x18)
            {
                num3 = 0x18;
            }
            if (num3 >= 10)
            {
                this.class18_0.method_155("Insert Column");
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, num3);
                for (int i = this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1; i > num; i--)
                {
                    this.class18_0.method_173((byte)i, this.class18_0.method_163((byte)(i - 1)));
                }
                int num5 = num - 1;
                double num6 = (this.class18_0.method_163((byte)num5) + this.class18_0.method_163((byte)(num + 1))) / 2;
                this.class18_0.method_173((byte)num, (int)num6);
                this.method_11(num, true);
                this.method_13(num, true);
                this.class18_0.method_153();
                this.class18_0.method_52();
            }
        }
    }

    private void method_15()
    {
        string str2;
        this.class18_0.method_155("Delete Column");
        int num = this.ctrlGrid.method_19();
        switch (num)
        {
            case -1:
                num = this.ctrlGrid.method_11();
                break;

            case 0x17:
                return;
        }
        int num2 = this.class18_0.method_163((byte)num);
        string str = this.class18_0.method_167((byte)num);
        if (num2 > this.class10_settings_0.int_6)
        {
            str = str + " " + this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_1);
        }
        else
        {
            str = str + " " + this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_0);
        }
        if (this.class18_0.method_39())
        {
            str2 = "secondary map";
        }
        else
        {
            str2 = "primary map";
        }
        if (MessageBox.Show(Form.ActiveForm, "This will delete the column " + str + " and move all the columns to the left." + Environment.NewLine + " Both fuel and ignition map on the " + str2 + " will be changed." + Environment.NewLine + " Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        {
            str = string.Empty;
            str2 = string.Empty;
            for (int i = num; i < (this.class18_0.method_33() - 1); i++)
            {
                int num4 = this.class18_0.method_163((byte)(i + 1));
                this.class18_0.method_173((byte)i, num4);
            }
            this.method_12(num, true);
            int num5 = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_75);
            if (num5 > 10)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, (byte)(num5 - 1));
                this.class18_0.method_52();
            }
            this.class18_0.method_153();
            this.class18_0.method_53();
        }
    }

    private void method_16()
    {
        string str2;
        this.class18_0.method_155("Insert Row");
        int num = (byte)this.ctrlGrid.method_20();
        switch (num)
        {
            case -1:
                num = (byte)this.ctrlGrid.method_12();
                break;

            case 0:
                return;
        }
        string str = this.class18_0.method_159((byte)num).ToString() + " rpm";
        if (this.class18_0.method_39())
        {
            str2 = "secondary map";
        }
        else
        {
            str2 = "primary map";
        }
        if (MessageBox.Show(Form.ActiveForm, "This will insert a row before " + str + " and move all the rows down." + Environment.NewLine + " Both fuel and ignition map on the " + str2 + " will be changed." + Environment.NewLine + " Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        {
            str = string.Empty;
            str2 = string.Empty;
            for (int i = this.class18_0.method_32_GetRPM_RowsNumber() - 1; i > num; i--)
            {
                this.class18_0.method_168((byte)i, this.class18_0.method_159((byte)(i - 1)));
            }
            int num3 = (this.class18_0.method_159((byte)(num - 1)) + this.class18_0.method_159((byte)(num + 1))) / 2;
            this.class18_0.method_168((byte)num, num3);
            this.method_11(num, false);
            this.method_13(num, false);
            this.class18_0.method_153();
            this.class18_0.method_53();
        }
    }

    private void method_17()
    {
        string str2;
        this.class18_0.method_155("Delete Row");
        int num = (byte)this.ctrlGrid.method_20();
        switch (num)
        {
            case -1:
                num = (byte)this.ctrlGrid.method_12();
                break;

            case 0x13:
                return;
        }
        string str = this.class18_0.method_159((byte)num).ToString() + " rpm";
        if (this.class18_0.method_39())
        {
            str2 = "secondary map";
        }
        else
        {
            str2 = "primary map";
        }
        if (MessageBox.Show(Form.ActiveForm, "This will delete the row " + str + " and move all the rows up." + Environment.NewLine + " Both fuel and ignition map on the " + str2 + " will be changed." + Environment.NewLine + " Continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        {
            str = string.Empty;
            str2 = string.Empty;
            for (int i = num; i < (this.class18_0.method_32_GetRPM_RowsNumber() - 1); i++)
            {
                int num3 = this.class18_0.method_159((byte)(i + 1));
                this.class18_0.method_168((byte)i, num3);
            }
            this.method_12(num, false);
            this.class18_0.method_153();
            this.class18_0.method_53();
        }
    }

    private void method_18(SelectedTable selectedTable_0)
    {
        this.method_24(selectedTable_0);
        this.ctrlGrid.method_31();
        this.ctrlMapGraph1.Invalidate();
    }

    private void method_19(FuelDisplayMode fuelDisplayMode_0)
    {
        this.FuelRawToolStripMenuItem.Checked = false;
        this.fuelInjDurToolStripMenuItem.Checked = false;
        this.FuelDutyToolStripMenuItem.Checked = false;
        switch (fuelDisplayMode_0)
        {
            case FuelDisplayMode.fuelRaw:
                this.FuelRawToolStripMenuItem.Checked = true;
                this.ctrlGrid.method_3(false);
                break;

            case FuelDisplayMode.fuelInjDur:
                this.fuelInjDurToolStripMenuItem.Checked = true;
                this.ctrlGrid.method_3(true);
                break;

            case FuelDisplayMode.fuelDuty:
                this.FuelDutyToolStripMenuItem.Checked = true;
                this.ctrlGrid.method_3(true);
                break;
        }
        this.ctrlGrid.method_31();
    }

    internal void method_2(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1, ref Class12_afrT class12_1, ref Class11_u class11_1, ref FrmMain frmMain_1)
    {
        this.class18_0 = class18_1;
        this.class10_settings_0 = class10_1;
        this.class17_0 = class17_1;
        this.class12_afrT_0 = class12_1;
        this.class11_u_0 = class11_1;
        this.frmMain_0 = frmMain_1;
        //this.method_0();

        ReloadShortcuts();

        this.ctrlGrid.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.class17_0, ref this.ctrlMapGraph1, ref this.class12_afrT_0);
        this.class18_0.delegate57_0 += new Class18.Delegate57(this.method_18);
        this.class18_0.delegate61_0 += new Class18.Delegate61(this.method_19);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_8);
        this.ctrlGrid.Resize += new EventHandler(this.ctrlGrid_Resize);
        this.ctrlMapGraph1.method_0(ref this.class18_0, ref this.class10_settings_0, ref this.ctrlGrid, ref this.FrmGridChart_0);
        this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_4);
        this.class17_0.delegate47_0 += new Class17.Delegate47(this.method_6);
        this.ctrlGrid.delegate44_0 += new CtrlGrid.Delegate44(this.method_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private int method_21(bool bool_3)
    {
        /*if (bool_3)
        {
            if (this.ignLoToolStripButton.Checked)
            {
                return 0;
            }
            if (this.ignHiToolStripButton.Checked)
            {
                return 1;
            }
            if (this.fuelLoToolStripButton.Checked)
            {
                return 2;
            }
            if (this.fuelHiToolStripButton.Checked)
            {
                return 3;
            }
        }
        else
        {*/
        if (toolStripButtonLowIgn.Checked || toolStripButtonLowFuel.Checked)
        {
            return 0;
        }
        if (toolStripButtonHighIgn.Checked || toolStripButtonHighFuel.Checked)
        {
            return 1;
        }
        //}
        return 0;
    }

    private int method_22()
    {
        if (this.class18_0.method_38())
        {
            return 9;
        }
        if (this.class18_0.method_39())
        {
            return 5;
        }
        return 1;
    }

    private void method_24(SelectedTable selectedTable_0)
    {
        this.ctrlGrid.ContextMenuStrip = this.contextMenuStrip1;
        this.Text = this.class18_0.method_23();

        string FVersion = " (v" + this.class18_0.RomVersion.ToString().Substring(0, 1) + "." + this.class18_0.RomVersion.ToString().Substring(1, 1) + "." + this.class18_0.RomVersion.ToString().Substring(2, 1) + ")";
        if (this.Text != "") this.Text = this.Text + FVersion;

        if (this.class18_0.method_45())
        {
            this.Text = this.Text + "*";
        }
        switch (selectedTable_0)
        {
            case SelectedTable.ve_lo:
                this.Text = this.Text + " - VE Low Map";
                this.ctrlGrid.ContextMenuStrip = this.contextMenuStrip2;
                break;

            case SelectedTable.ve_hi:
                this.ctrlGrid.ContextMenuStrip = this.contextMenuStrip2;
                this.Text = this.Text + " - VE Map";
                break;
        }
        if (this.class18_0.method_8() == TableOverlay.afTarget)
        {
            this.ctrlGrid.ContextMenuStrip = this.contextMenuStrip2;
            this.Text = this.Text + " - A/F Target";
        }
        else if (this.class18_0.method_8() == TableOverlay.afReading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - A/F Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.afDiff)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Fuel Differences";
        }
        else if (this.class18_0.method_8() == TableOverlay.analog1Reading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Analog1 Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.analog2Reading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Analog2 Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.analog3Reading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Analog3 Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.DynoWSReading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - DynoWS Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.DynoHPReading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - DynoHP Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.DynoNMReading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - DynoNM Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.AUX1Reading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Dyno AUX1 Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.AUX2Reading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Dyno AUX2 Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.AUX3Reading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Dyno AUX3 Reading";
        }
        else if (this.class18_0.method_8() == TableOverlay.THCReading)
        {
            this.ctrlGrid.ContextMenuStrip = null;
            this.Text = this.Text + " - Dyno THC Reading";
        }
    }

    private float method_28(float float_0, float float_1, float float_2, float float_3, float float_4)
    {
        return (float_3 + (((float_0 - float_1) * (float_4 - float_3)) / (float_2 - float_1)));
    }

    private void method_29_Smooth()
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        this.int_0 = this.ctrlGrid.method_10();
        if (cells.Count > 0)
        {
            float num5;
            float num6;
            float num7;
            int columnIndex = this.int_0[0];
            int rowIndex = this.int_0[1];
            int num2 = this.int_0[2];
            int num4 = this.int_0[3];
            if (((num4 - rowIndex) < 3) && ((num2 - columnIndex) < 3))
            {
                this.class18_0.method_155("Smooth Map: " + this.class18_0.method_4().ToString());
                rowIndex = 0;
                rowIndex++;
                num4 = this.class18_0.method_32_GetRPM_RowsNumber() - 1;
                num4--;
                columnIndex = 0;
                columnIndex++;
                num2 = this.class18_0.method_33() - 1;
                num2--;
                for (int i = columnIndex; i <= num2; i++)
                {
                    for (int j = rowIndex; j <= num4; j++)
                    {
                        num5 = this.class18_0.method_174((byte)i, (byte)j);
                        num6 = this.method_28((float)this.class18_0.method_159((byte)j), (float)this.class18_0.method_159((byte)(j - 1)), (float)this.class18_0.method_159((byte)(j + 1)), this.class18_0.method_174((byte)i, (byte)(j - 1)), this.class18_0.method_174((byte)i, (byte)(j + 1)));
                        num7 = num6 * this.class10_settings_0.float_6;
                        if (num5 < (num6 - num7))
                        {
                            this.class18_0.method_176((byte)i, (byte)j, num6 - num7);
                        }
                        else if (num5 > (num6 + num7))
                        {
                            this.class18_0.method_176((byte)i, (byte)j, num6 + num7);
                        }
                        if (this.class10_settings_0.bool_12)
                        {
                            num6 = this.method_28((float)this.class18_0.method_163((byte)i), (float)this.class18_0.method_163((byte)(i - 1)), (float)this.class18_0.method_163((byte)(i + 1)), this.class18_0.method_174((byte)(i - 1), (byte)j), this.class18_0.method_174((byte)(i + 1), (byte)j));
                            num7 = num6 * this.class10_settings_0.float_6;
                            if (num5 < (num6 - num7))
                            {
                                this.class18_0.method_176((byte)i, (byte)j, num6 - num7);
                            }
                            else if (num5 > (num6 + num7))
                            {
                                this.class18_0.method_176((byte)i, (byte)j, num6 + num7);
                            }
                        }
                    }
                }
                this.class18_0.method_53();
                this.class18_0.method_153();
                cells = null;
                columnIndex = 0;
                num2 = 0;
                rowIndex = 0;
                num4 = 0;
                num6 = 0f;
                num7 = 0f;
                num5 = 0f;
            }
            else
            {
                this.class18_0.method_155("Smooth Selection: " + this.class18_0.method_4().ToString());
                if ((num4 - rowIndex) >= 3)
                {
                    columnIndex = this.int_0[0];
                    rowIndex = this.int_0[1];
                    num2 = this.int_0[2];
                    num4 = this.int_0[3];
                    rowIndex++;
                    num4--;
                    for (int k = columnIndex; k <= num2; k++)
                    {
                        for (int m = rowIndex; m <= num4; m++)
                        {
                            num5 = this.class18_0.method_174((byte)k, (byte)m);
                            num6 = this.method_28((float)this.class18_0.method_159((byte)m), (float)this.class18_0.method_159((byte)(m - 1)), (float)this.class18_0.method_159((byte)(m + 1)), this.class18_0.method_174((byte)k, (byte)(m - 1)), this.class18_0.method_174((byte)k, (byte)(m + 1)));
                            num7 = num6 * this.class10_settings_0.float_6;
                            if (num5 < (num6 - num7))
                            {
                                this.class18_0.method_176((byte)k, (byte)m, num6 - num7);
                            }
                            else if (num5 > (num6 + num7))
                            {
                                this.class18_0.method_176((byte)k, (byte)m, num6 + num7);
                            }
                        }
                    }
                }
                if (((num2 - columnIndex) >= 3) && this.class10_settings_0.bool_12)
                {
                    columnIndex = cells[cells.Count - 1].ColumnIndex;
                    num2 = cells[0].ColumnIndex;
                    rowIndex = cells[cells.Count - 1].RowIndex;
                    num4 = cells[0].RowIndex;
                    columnIndex++;
                    num2--;
                    for (int n = columnIndex; n <= num2; n++)
                    {
                        for (int num13 = rowIndex; num13 <= num4; num13++)
                        {
                            num5 = this.class18_0.method_174((byte)n, (byte)num13);
                            num6 = this.method_28((float)this.class18_0.method_163((byte)n), (float)this.class18_0.method_163((byte)(n - 1)), (float)this.class18_0.method_163((byte)(n + 1)), this.class18_0.method_174((byte)(n - 1), (byte)num13), this.class18_0.method_174((byte)(n + 1), (byte)num13));
                            num7 = num6 * this.class10_settings_0.float_6;
                            if (num5 < (num6 - num7))
                            {
                                this.class18_0.method_176((byte)n, (byte)num13, num6 - num7);
                            }
                            else if (num5 > (num6 + num7))
                            {
                                this.class18_0.method_176((byte)n, (byte)num13, num6 + num7);
                            }
                        }
                    }
                }
                this.class18_0.method_153();
                this.class18_0.method_53();
                cells = null;
                columnIndex = 0;
                num2 = 0;
                rowIndex = 0;
                num4 = 0;
                num6 = 0f;
                num7 = 0f;
                num5 = 0f;
            }
        }
    }

    private void method_30()
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        this.int_0 = this.ctrlGrid.method_10();
        if (cells.Count > 0)
        {
            int num = this.int_0[0];
            int num3 = this.int_0[1];
            int num2 = this.int_0[2];
            int num4 = this.int_0[3];
            if (((num4 - num3) < 3) && ((num2 - num) < 3))
            {
                float num5;
                float num6;
                float num7;
                this.class18_0.method_155("Smooth Map: " + this.class18_0.method_4().ToString());
                num3 = 0;
                num3++;
                num4 = this.class18_0.method_32_GetRPM_RowsNumber() - 1;
                num4--;
                num = 0;
                num++;
                num2 = this.class18_0.method_33() - 1;
                num2--;
                for (int i = num; i <= num2; i++)
                {
                    for (int j = num3; j <= num4; j++)
                    {
                        num5 = this.class18_0.method_174((byte)i, (byte)j);
                        num6 = this.method_28((float)this.class18_0.method_159((byte)j), (float)this.class18_0.method_159((byte)(j - 1)), (float)this.class18_0.method_159((byte)(j + 1)), this.class18_0.method_174((byte)i, (byte)(j - 1)), this.class18_0.method_174((byte)i, (byte)(j + 1)));
                        num7 = num6 * this.class10_settings_0.float_6;
                        if (num5 < (num6 - num7))
                        {
                            this.class18_0.method_176((byte)i, (byte)j, num6 - num7);
                        }
                        else if (num5 > (num6 + num7))
                        {
                            this.class18_0.method_176((byte)i, (byte)j, num6 + num7);
                        }
                        if (this.class10_settings_0.bool_12)
                        {
                            num6 = this.method_28((float)this.class18_0.method_163((byte)i), (float)this.class18_0.method_163((byte)(i - 1)), (float)this.class18_0.method_163((byte)(i + 1)), this.class18_0.method_174((byte)(i - 1), (byte)j), this.class18_0.method_174((byte)(i + 1), (byte)j));
                            num7 = num6 * this.class10_settings_0.float_6;
                            if (num5 < (num6 - num7))
                            {
                                this.class18_0.method_176((byte)i, (byte)j, num6 - num7);
                            }
                            else if (num5 > (num6 + num7))
                            {
                                this.class18_0.method_176((byte)i, (byte)j, num6 + num7);
                            }
                        }
                    }
                }
                this.class18_0.method_53();
                this.class18_0.method_153();
                cells = null;
                num = 0;
                num2 = 0;
                num3 = 0;
                num4 = 0;
                num6 = 0f;
                num7 = 0f;
                num5 = 0f;
            }
        }
    }

    private void method_31()
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        this.int_0 = this.ctrlGrid.method_10();
        if (cells.Count > 0)
        {
            float num5;
            float num6;
            float num7;
            int columnIndex = this.int_0[0];
            int rowIndex = this.int_0[1];
            int num2 = this.int_0[2];
            int num4 = this.int_0[3];
            this.class18_0.method_155("Smooth Selection: " + this.class18_0.method_4().ToString());
            if ((num4 - rowIndex) >= 3)
            {
                columnIndex = this.int_0[0];
                rowIndex = this.int_0[1];
                num2 = this.int_0[2];
                num4 = this.int_0[3];
                rowIndex++;
                num4--;
                for (int i = columnIndex; i <= num2; i++)
                {
                    for (int j = rowIndex; j <= num4; j++)
                    {
                        num5 = this.class18_0.method_174((byte)i, (byte)j);
                        num6 = this.method_28((float)this.class18_0.method_159((byte)j), (float)this.class18_0.method_159((byte)(j - 1)), (float)this.class18_0.method_159((byte)(j + 1)), this.class18_0.method_174((byte)i, (byte)(j - 1)), this.class18_0.method_174((byte)i, (byte)(j + 1)));
                        num7 = num6 * this.class10_settings_0.float_6;
                        if (num5 < (num6 - num7))
                        {
                            this.class18_0.method_176((byte)i, (byte)j, num6 - num7);
                        }
                        else if (num5 > (num6 + num7))
                        {
                            this.class18_0.method_176((byte)i, (byte)j, num6 + num7);
                        }
                    }
                }
            }
            if (((num2 - columnIndex) >= 3) && this.class10_settings_0.bool_12)
            {
                columnIndex = cells[cells.Count - 1].ColumnIndex;
                num2 = cells[0].ColumnIndex;
                rowIndex = cells[cells.Count - 1].RowIndex;
                num4 = cells[0].RowIndex;
                columnIndex++;
                num2--;
                for (int k = columnIndex; k <= num2; k++)
                {
                    for (int m = rowIndex; m <= num4; m++)
                    {
                        num5 = this.class18_0.method_174((byte)k, (byte)m);
                        num6 = this.method_28((float)this.class18_0.method_163((byte)k), (float)this.class18_0.method_163((byte)(k - 1)), (float)this.class18_0.method_163((byte)(k + 1)), this.class18_0.method_174((byte)(k - 1), (byte)m), this.class18_0.method_174((byte)(k + 1), (byte)m));
                        num7 = num6 * this.class10_settings_0.float_6;
                        if (num5 < (num6 - num7))
                        {
                            this.class18_0.method_176((byte)k, (byte)m, num6 - num7);
                        }
                        else if (num5 > (num6 + num7))
                        {
                            this.class18_0.method_176((byte)k, (byte)m, num6 + num7);
                        }
                    }
                }
            }
            this.class18_0.method_153();
            this.class18_0.method_53();
            cells = null;
            columnIndex = 0;
            num2 = 0;
            rowIndex = 0;
            num4 = 0;
            num6 = 0f;
            num7 = 0f;
            num5 = 0f;
        }
    }

    private void method_32_InterpolateX()
    {
        this.ctrlGrid.method_9();
        float num5 = 0f;
        float num6 = 0f;
        byte num = (byte)this.ctrlGrid.method_10()[0];
        byte num3 = (byte)this.ctrlGrid.method_10()[1];
        byte num2 = (byte)this.ctrlGrid.method_10()[2];
        byte num4 = (byte)this.ctrlGrid.method_10()[3];
        if (((num2 - num) >= 2) || ((num4 - num3) >= 2))
        {
            this.class18_0.method_155("Interpolate");
            if ((num4 - num3) >= 2)
            {
                num5 = (this.class18_0.method_174(num, num4) - this.class18_0.method_174(num, num3)) / ((float)(this.class18_0.method_159(num4) - this.class18_0.method_159(num3)));
                num6 = this.class18_0.method_174(num, num3) - (num5 * this.class18_0.method_159(num3));
                for (byte i = (byte)(num3 + 1); i < num4; i = (byte)(i + 1))
                {
                    this.class18_0.method_174(num, i);
                    float num8 = (num5 * this.class18_0.method_159(i)) + num6;
                    this.class18_0.method_176(num, i, num8);
                }
                if (num < num2)
                {
                    num5 = (this.class18_0.method_174(num2, num4) - this.class18_0.method_174(num2, num3)) / ((float)(this.class18_0.method_159(num4) - this.class18_0.method_159(num3)));
                    num6 = this.class18_0.method_174(num2, num3) - (num5 * this.class18_0.method_159(num3));
                    for (byte j = (byte)(num3 + 1); j < num4; j = (byte)(j + 1))
                    {
                        this.class18_0.method_174(num2, j);
                        float num10 = (num5 * this.class18_0.method_159(j)) + num6;
                        this.class18_0.method_176(num2, j, num10);
                    }
                }
            }
            if ((num2 - num) >= 2)
            {
                for (byte k = num3; k <= num4; k = (byte)(k + 1))
                {
                    num5 = (this.class18_0.method_174(num2, k) - this.class18_0.method_174(num, k)) / ((float)(this.class18_0.method_165(num2) - this.class18_0.method_165(num)));
                    num6 = this.class18_0.method_174(num, k) - (num5 * this.class18_0.method_165(num));
                    for (byte m = (byte)(num + 1); m < num2; m = (byte)(m + 1))
                    {
                        this.class18_0.method_174(m, k);
                        float num13 = (num5 * this.class18_0.method_165(m)) + num6;
                        this.class18_0.method_176(m, k, num13);
                    }
                }
            }
            this.class18_0.method_153();
            this.class18_0.method_53();
        }
    }

    private void method_33()
    {
        this.ctrlGrid.method_9();
        float num5 = 0f;
        float num6 = 0f;
        byte num = (byte)this.ctrlGrid.method_10()[0];
        byte num3 = (byte)this.ctrlGrid.method_10()[1];
        byte num2 = (byte)this.ctrlGrid.method_10()[2];
        byte num4 = (byte)this.ctrlGrid.method_10()[3];
        if (((num4 - num3) >= 2) && ((num4 - num3) >= 2))
        {
            this.class18_0.method_155("Interpolate Rows");
            for (byte i = num; i <= num2; i = (byte)(i + 1))
            {
                num5 = (this.class18_0.method_174(i, num4) - this.class18_0.method_174(i, num3)) / ((float)(this.class18_0.method_159(num4) - this.class18_0.method_159(num3)));
                num6 = this.class18_0.method_174(i, num3) - (num5 * this.class18_0.method_159(num3));
                for (byte j = (byte)(num3 + 1); j < num4; j = (byte)(j + 1))
                {
                    this.class18_0.method_174(i, j);
                    float num9 = (num5 * this.class18_0.method_159(j)) + num6;
                    this.class18_0.method_176(i, j, num9);
                }
            }
            this.class18_0.method_153();
            this.class18_0.method_53();
        }
    }

    private void method_34()
    {
        this.ctrlGrid.method_9();
        float num5 = 0f;
        float num6 = 0f;
        byte num = (byte)this.ctrlGrid.method_10()[0];
        byte num3 = (byte)this.ctrlGrid.method_10()[1];
        byte num2 = (byte)this.ctrlGrid.method_10()[2];
        byte num4 = (byte)this.ctrlGrid.method_10()[3];
        if ((num2 - num) >= 2)
        {
            this.class18_0.method_155("Interpolate Columns");
            for (byte i = num3; i <= num4; i = (byte)(i + 1))
            {
                num5 = (this.class18_0.method_174(num2, i) - this.class18_0.method_174(num, i)) / ((float)(this.class18_0.method_165(num2) - this.class18_0.method_165(num)));
                num6 = this.class18_0.method_174(num, i) - (num5 * this.class18_0.method_165(num));
                for (byte j = (byte)(num + 1); j < num2; j = (byte)(j + 1))
                {
                    this.class18_0.method_174(j, i);
                    float num9 = (num5 * this.class18_0.method_165(j)) + num6;
                    this.class18_0.method_176(j, i, num9);
                }
            }
            this.class18_0.method_153();
            this.class18_0.method_53();
        }
    }

    /*private void method_39(object sender, EventArgs e)
    {
        this.class10_0.sensors_0 = (Sensors) int.Parse(((ToolStripMenuItem) sender).Tag.ToString());
        this.class12_0.method_32(TableOverlay.overlay1);
        this.ctrlGrid.method_31();
        this.bool_0 = false;
        this.method_24(this.class18_0.method_4());
    }*/

    private void method_4(Struct12 struct12_0)
    {
        if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[4]))
        {
            try
            {
                base.Invoke(new Delegate6(this.method_5), new object[] { struct12_0 });
            }
            catch { }
        }
    }

    private void method_5(Struct12 struct12_0)
    {
        if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && (DateTime.Now - LastCheck).TotalMilliseconds >= this.class10_settings_0.int_ActiveDatalog[4]))
        //if ((DateTime.Now - LastCheck).TotalMilliseconds >= 0)
        {
            //LastCheck = DateTime.Now;
            if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[4]))
            {
                if ((this.ctrlMapGraph1 != null) && (this.ctrlMapGraph1.mapGraphType_0 == MapGraphType.timePlot || this.ctrlMapGraph1.mapGraphType_0 == MapGraphType.custom))
                {
                    this.ctrlMapGraph1.method_19(struct12_0);
                }
            }
            LastCheck = DateTime.Now;
        }
    }

    private void method_6(Struct17 struct17_1)
    {
        try
        {
            base.Invoke(new Delegate7(this.method_7), new object[] { struct17_1 });
        }
        catch { }
    }

    private void method_7(Struct17 struct17_1)
    {
        this.struct17_0 = struct17_1;
        if (this.bool_2)
        {
            if (this.class10_settings_0.bool_44 && !this.class18_0.method_38())
            {
                if (struct17_1.bool_1 && !this.class18_0.method_39())
                {
                    this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() + 4);
                    this.ctrlGrid.method_31();
                }
                else if (!struct17_1.bool_1 && this.class18_0.method_39())
                {
                    this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() - 4);
                    this.ctrlGrid.method_31();
                }
            }
            bool Tssse = true;
            if (!this.class18_0.method_38() || !Tssse)
            {
                if (struct17_1.bool_0)
                {
                    if (!this.class18_0.method_36())
                    {
                        this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() + 1);
                        this.ctrlGrid.method_31();
                    }
                }
                else if (!struct17_1.bool_0 && !this.class18_0.method_35())
                {
                    this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() - 1);
                    this.ctrlGrid.method_31();
                }
            }
            this.ctrlGrid.method_15(this.struct17_0.struct24_0.int_1, this.struct17_0.struct24_0.int_0, true);
        }
        if (this.ctrlMapGraph1.mapGraphType_0 == MapGraphType.rpmPlot)
        {
            this.ctrlMapGraph1.method_20(struct17_1);
        }
    }

    private void method_8()
    {
        this.class17_0.frmMain_0.SpawnWaitingwindows();
        if (this.class18_0 == null)
        {
            this.ctrlGrid.Enabled = false;
            this.ctrlMapGraph1.Enabled = false;
            this.tunerToolStrip.Enabled = false;
            this.ctrlMapGraph1.Invalidate();
        }
        else if (this.class18_0.method_30_HasFileLoadedInBMTune() && !this.frmMain_0.CustomMenuLoaded)
        {
            this.ctrlGrid.Enabled = true;
            this.ctrlMapGraph1.Enabled = true;
            this.tunerToolStrip.Enabled = true;
            this.method_18(this.class18_0.method_4());
            this.method_19(this.class18_0.method_6());
            this.ctrlGrid.method_4();
            this.ctrlGrid.Width = this.ctrlGrid.method_5();
            this.splitContainer1.Panel2Collapsed = !this.class10_settings_0.bool_6;
            this.ctrlMapGraph1.mapGraphType_0 = (MapGraphType)this.class10_settings_0.int_2;
            if (this.class10_settings_0.bool_6)
            {
                switch (this.ctrlMapGraph1.mapGraphType_0)
                {
                    case MapGraphType.twoD:
                        this.dGraphToolStripMenuItem.Checked = true;
                        break;

                    case MapGraphType.threeD:
                        this.dGraphToolStripMenuItem1.Checked = true;
                        break;
                }
            }
            else
            {
                this.dGraphToolStripMenuItem.Checked = false;
                this.dGraphToolStripMenuItem1.Checked = false;
            }
            if (this.class10_settings_0.bool_15)
            {
                this.splitContainer1.Orientation = Orientation.Horizontal;
                this.splitContainer1.Panel1MinSize = 200;
                this.splitContainer1.Panel2MinSize = 180;
            }
            else
            {
                this.splitContainer1.Orientation = Orientation.Vertical;
                this.splitContainer1.Panel1MinSize = 350;
                this.splitContainer1.Panel2MinSize = 250;
            }
            if (!this.splitContainer1.Panel2Collapsed)
            {
                this.splitContainer1.SplitterDistance = this.class10_settings_0.SplitterDistance;
                this.ctrlMapGraph1.Invalidate();
                IsLoading = false;
            }
            //this.contextInterpolateColumnsTool.Enabled = true;
            //this.contextInterpolateRowsTool.Enabled = true;
            //this.contextInterpolateXYTool.Enabled = true;
            //this.contextSmoothMap.Enabled = true;
            //this.contextSmoothSelection.Enabled = true;
            //this.toolDecrease.Enabled = true;
            //this.toolIncrease.Enabled = true;
            //this.adjustSelectionToolStripMenuItem.Enabled = true;
            //this.toolSmooth.Enabled = true;
            this.toolTunerSmartTrack.Enabled = true;
            this.toolTunerMapTrail.Enabled = true;
            this.toolTunerClearTrail.Enabled = true;
            this.autoAdjustSelectionToolStripMenuItem.Enabled = true;

            analog1Reading_Button.Enabled = true;
            analog2Reading_Button.Enabled = true;
            analog3Reading_Button.Enabled = true;
        }
        //else if (!this.class18_0.method_30_HasFileLoadedInBMTune())
        else
        {
            this.ctrlGrid.Enabled = false;
            this.ctrlMapGraph1.Enabled = false;
            this.tunerToolStrip.Enabled = false;
            this.ctrlMapGraph1.Invalidate();
            this.ctrlGrid.method_4();
        }
        this.class17_0.frmMain_0.CloseWaitingwindows();
    }

    //This function trigger when 'Copy' items to clipboard
    public void method_9()
    {
        this.ctrlGrid.method_7();
    }

    public void FinishSelect()
    {
        CheckEditMode();

        this.bool_0 = true;
        this.ShowingVE = false;

        this.ctrlMapGraph1.Invalidate();
        //if not in fuel table, select fuel table
        if (!toolStripButtonLowFuel.Checked && !toolStripButtonHighFuel.Checked)
        {
            toolStripButtonLowFuel.Checked = true;
            if (toolStripButtonPrimary.Checked) this.class18_0.method_5_SetSelectedTable((SelectedTable)(3));
            else this.class18_0.method_5_SetSelectedTable((SelectedTable)(7));
        }

        EnableMappindButtons(true);

        SelectMap(GetMappingIndex());
        this.ctrlGrid.method_3(true);
        this.ctrlGrid.method_31();
        this.bool_0 = false;
        this.method_24(this.class18_0.method_4());
    }

    private int GetMappingIndex()
    {
        int ThisIndex = 0;
        if (toolStripButtonLowIgn.Checked) ThisIndex = 0;
        if (toolStripButtonHighIgn.Checked) ThisIndex = 1;
        if (toolStripButtonLowFuel.Checked) ThisIndex = 2;
        if (toolStripButtonHighFuel.Checked) ThisIndex = 3;

        if (toolStripButtonSecondary.Checked) ThisIndex += 4;
        return ThisIndex;
    }

    private void EnableMappindButtons(bool Enabled)
    {
        toolStripButtonPrimary.Enabled = Enabled;
        toolStripButtonSecondary.Enabled = Enabled;
        toolStripButtonLowIgn.Enabled = Enabled;
        toolStripButtonHighIgn.Enabled = Enabled;
        toolStripButtonLowFuel.Enabled = Enabled;
        toolStripButtonHighFuel.Enabled = Enabled;
    }

    private void EnableIgnMappingButtons(bool Enabled)
    {
        toolStripButtonLowIgn.Enabled = Enabled;
        toolStripButtonHighIgn.Enabled = Enabled;
    }

    public void SelectAFTarget()
    {
        FinishSelect();
        EnableIgnMappingButtons(false);
        toolStripButtonMapValue.Checked = false;
        toolStripButtonAFTarget.Checked = true;
        toolStripButtonAFReading.Checked = false;
        toolStripButtonAFDiff.Checked = false;
        toolStripButtonVE.Checked = false;
        analog1Reading_Button.Checked = false;
        analog2Reading_Button.Checked = false;
        analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.afTarget);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectAFReading()
    {
        FinishSelect();
        EnableIgnMappingButtons(false);
        toolStripButtonMapValue.Checked = false;
        toolStripButtonAFTarget.Checked = false;
        toolStripButtonAFReading.Checked = true;
        toolStripButtonAFDiff.Checked = false;
        toolStripButtonVE.Checked = false;
        analog1Reading_Button.Checked = false;
        analog2Reading_Button.Checked = false;
        analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.afReading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectAFDiff()
    {
        FinishSelect();
        EnableIgnMappingButtons(false);
        toolStripButtonMapValue.Checked = false;
        toolStripButtonAFTarget.Checked = false;
        toolStripButtonAFReading.Checked = false;
        toolStripButtonAFDiff.Checked = true;
        toolStripButtonVE.Checked = false;
        analog1Reading_Button.Checked = false;
        analog2Reading_Button.Checked = false;
        analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.afDiff);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectAnalog1Reading()
    {
        FinishSelect();
        EnableIgnMappingButtons(false);
        toolStripButtonMapValue.Checked = false;
        toolStripButtonAFTarget.Checked = false;
        toolStripButtonAFReading.Checked = false;
        toolStripButtonAFDiff.Checked = false;
        toolStripButtonVE.Checked = false;
        analog1Reading_Button.Checked = true;
        analog2Reading_Button.Checked = false;
        analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.analog1Reading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectAnalog2Reading()
    {
        FinishSelect();
        EnableIgnMappingButtons(false);
        toolStripButtonMapValue.Checked = false;
        toolStripButtonAFTarget.Checked = false;
        toolStripButtonAFReading.Checked = false;
        toolStripButtonAFDiff.Checked = false;
        toolStripButtonVE.Checked = false;
        analog1Reading_Button.Checked = false;
        analog2Reading_Button.Checked = true;
        analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.analog2Reading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectAnalog3Reading()
    {
        FinishSelect();
        EnableIgnMappingButtons(false);
        toolStripButtonMapValue.Checked = false;
        toolStripButtonAFTarget.Checked = false;
        toolStripButtonAFReading.Checked = false;
        toolStripButtonAFDiff.Checked = false;
        toolStripButtonVE.Checked = false;
        analog1Reading_Button.Checked = false;
        analog2Reading_Button.Checked = false;
        analog3Reading_Button.Checked = true;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.analog3Reading);
        this.frmMain_0.SetMapsPresetButtons();
    }


    public void SelectVE()
    {
        CheckEditMode();
        EnableIgnMappingButtons(false);
        this.ShowingVE = true;
        toolStripButtonMapValue.Checked = false;
        toolStripButtonAFTarget.Checked = false;
        toolStripButtonAFReading.Checked = false;
        toolStripButtonAFDiff.Checked = false;
        toolStripButtonVE.Checked = true;
        analog1Reading_Button.Checked = false;
        analog2Reading_Button.Checked = false;
        analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;

        EnableMappindButtons(false);
        //showGraph(false);
        this.ctrlMapGraph1.Invalidate();
        this.bool_0 = true;
        this.class18_0.method_9(TableOverlay.none);
        this.frmMain_0.SetMapsPresetButtons();

        this.ctrlGrid.method_3(false);
        this.class18_0.method_5_SetSelectedTable(SelectedTable.ve_hi);
        this.bool_0 = false;
    }

    public void SelectAUX1Reading()
    {
        this.FinishSelect();
        EnableIgnMappingButtons(false);
        this.toolStripButtonMapValue.Checked = false;
        this.toolStripButtonAFTarget.Checked = false;
        this.toolStripButtonAFReading.Checked = false;
        this.toolStripButtonAFDiff.Checked = false;
        this.toolStripButtonVE.Checked = false;
        this.analog1Reading_Button.Checked = false;
        this.analog2Reading_Button.Checked = false;
        this.analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = true;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.AUX1Reading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectAUX2Reading()
    {
        this.FinishSelect();
        EnableIgnMappingButtons(false);
        this.toolStripButtonMapValue.Checked = false;
        this.toolStripButtonAFTarget.Checked = false;
        this.toolStripButtonAFReading.Checked = false;
        this.toolStripButtonAFDiff.Checked = false;
        this.toolStripButtonVE.Checked = false;
        this.analog1Reading_Button.Checked = false;
        this.analog2Reading_Button.Checked = false;
        this.analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = true;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.AUX2Reading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectAUX3Reading()
    {
        this.FinishSelect();
        EnableIgnMappingButtons(false);
        this.toolStripButtonMapValue.Checked = false;
        this.toolStripButtonAFTarget.Checked = false;
        this.toolStripButtonAFReading.Checked = false;
        this.toolStripButtonAFDiff.Checked = false;
        this.toolStripButtonVE.Checked = false;
        this.analog1Reading_Button.Checked = false;
        this.analog2Reading_Button.Checked = false;
        this.analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = true;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.AUX3Reading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectDynoHPReading()
    {
        this.FinishSelect();
        EnableIgnMappingButtons(false);
        this.toolStripButtonMapValue.Checked = false;
        this.toolStripButtonAFTarget.Checked = false;
        this.toolStripButtonAFReading.Checked = false;
        this.toolStripButtonAFDiff.Checked = false;
        this.toolStripButtonVE.Checked = false;
        this.analog1Reading_Button.Checked = false;
        this.analog2Reading_Button.Checked = false;
        this.analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = true;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.DynoHPReading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectDynoNMReading()
    {
        this.FinishSelect();
        EnableIgnMappingButtons(false);
        this.toolStripButtonMapValue.Checked = false;
        this.toolStripButtonAFTarget.Checked = false;
        this.toolStripButtonAFReading.Checked = false;
        this.toolStripButtonAFDiff.Checked = false;
        this.toolStripButtonVE.Checked = false;
        this.analog1Reading_Button.Checked = false;
        this.analog2Reading_Button.Checked = false;
        this.analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = true;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.DynoNMReading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectDynoWSReading()
    {
        this.FinishSelect();
        EnableIgnMappingButtons(false);
        this.toolStripButtonMapValue.Checked = false;
        this.toolStripButtonAFTarget.Checked = false;
        this.toolStripButtonAFReading.Checked = false;
        this.toolStripButtonAFDiff.Checked = false;
        this.toolStripButtonVE.Checked = false;
        this.analog1Reading_Button.Checked = false;
        this.analog2Reading_Button.Checked = false;
        this.analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = true;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;
        this.class18_0.method_9(TableOverlay.DynoWSReading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectTHCReading()
    {
        this.FinishSelect();
        EnableIgnMappingButtons(false);
        this.toolStripButtonMapValue.Checked = false;
        this.toolStripButtonAFTarget.Checked = false;
        this.toolStripButtonAFReading.Checked = false;
        this.toolStripButtonAFDiff.Checked = false;
        this.toolStripButtonVE.Checked = false;
        this.analog1Reading_Button.Checked = false;
        this.analog2Reading_Button.Checked = false;
        this.analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = true;
        this.class18_0.method_9(TableOverlay.THCReading);
        this.frmMain_0.SetMapsPresetButtons();
    }

    public void SelectFuel()
    {
        CheckEditMode();
        EnableIgnMappingButtons(true);
        this.ShowingVE = false;
        toolStripButtonMapValue.Checked = true;
        toolStripButtonAFTarget.Checked = false;
        toolStripButtonAFReading.Checked = false;
        toolStripButtonAFDiff.Checked = false;
        toolStripButtonVE.Checked = false;
        analog1Reading_Button.Checked = false;
        analog2Reading_Button.Checked = false;
        analog3Reading_Button.Checked = false;
        this.DynoWSReading_Button.Checked = false;
        this.DynoHPReading_Button.Checked = false;
        this.DynoNMReading_Button.Checked = false;
        this.AUX1Reading_Button.Checked = false;
        this.AUX2Reading_Button.Checked = false;
        this.AUX3Reading_Button.Checked = false;
        this.THCReading_Button.Checked = false;

        EnableMappindButtons(true);
        //showGraph(false);
        this.ctrlMapGraph1.Invalidate();
        this.bool_0 = true;
        this.class18_0.method_9(TableOverlay.none);
        this.frmMain_0.SetMapsPresetButtons();

        this.ctrlGrid.method_3(false);
        SelectMap(GetMappingIndex());
        this.bool_0 = false;
    }

    private void showGraph(bool Show)
    {
        this.class10_settings_0.bool_6 = Show;
        this.splitContainer1.Panel2Collapsed = !this.class10_settings_0.bool_6;
        if (!this.splitContainer1.Panel2Collapsed)
        {
            //this.splitContainer1.SplitterDistance = this.class10_0.SplitterDistance;
            this.ctrlMapGraph1.Invalidate();
        }
        //else this.class10_0.SplitterDistance = this.splitContainer1.SplitterDistance;
    }

    public void toolBtnAdjSel_Click(object sender, EventArgs e)
    {
        DataGridViewSelectedCellCollection sel = this.ctrlGrid.method_9();
        frmGridSelectionAdj adj = new frmGridSelectionAdj(this.ctrlGrid.method_10(), ref sel, ref this.class10_settings_0, ref this.class18_0, this.class18_0.method_8() == TableOverlay.afTarget, ref this.class12_afrT_0);
        switch (adj.ShowDialog())
        {
            case DialogResult.OK:
            case DialogResult.Cancel:
                adj.Dispose();
                sel = null;
                adj = null;
                break;
        }
    }

    public void toolDecrease_Click(object sender, EventArgs e)
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        if (this.class18_0.method_8() == TableOverlay.afTarget)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                this.class12_afrT_0.method_14(cells[i].ColumnIndex, cells[i].RowIndex, this.class12_afrT_0.method_12(cells[i].ColumnIndex, cells[i].RowIndex) - this.class10_settings_0.float_4);
                this.ctrlGrid.method_34(cells[i].ColumnIndex, cells[i].RowIndex);
            }
        }
        else
        {
            byte rowIndex;
            byte columnIndex;
            float num2 = 0f;
            int[] numArray = this.ctrlGrid.method_10();
            int num5 = numArray[0];
            int num7 = numArray[1];
            int num6 = numArray[2];
            int num8 = numArray[3];
            this.class18_0.method_163((byte)num5);
            this.class18_0.method_163((byte)num6);
            this.class18_0.method_159((byte)num7);
            this.class18_0.method_159((byte)num8);
            if (this.class18_0.method_37())
            {
                string[] strArray = new string[] { this.class18_0.method_4().ToString(), " -@col", (num5 + 1).ToString(), "to", (num6 + 1).ToString(), " &row", (num7 + 1).ToString(), "to", (num8 + 1).ToString() };
                this.class18_0.method_155(string.Concat(strArray));
                for (int j = 0; j < cells.Count; j++)
                {
                    columnIndex = (byte)cells[j].ColumnIndex;
                    rowIndex = (byte)cells[j].RowIndex;
                    num2 = this.class18_0.method_174(columnIndex, rowIndex);
                    if (num2 >= this.class10_settings_0.float_3)
                    {
                        if ((num2 - ((num2 / 100f) * this.class10_settings_0.float_1)) >= 0f) this.class18_0.method_176(columnIndex, rowIndex, num2 - ((num2 / 100f) * this.class10_settings_0.float_1));
                        else this.class18_0.method_176(columnIndex, rowIndex, 0f);
                    }
                    else
                    {
                        if ((num2 - this.class10_settings_0.float_2) >= 0f) this.class18_0.method_176(columnIndex, rowIndex, num2 - this.class10_settings_0.float_2);
                        else this.class18_0.method_176(columnIndex, rowIndex, 0f);
                    }

                    //Check if editing are done correctly
                    if (num2 > 0f)
                    {
                        float num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                        float Multiplyer = 1.5f;
                        int TryCount = 0;
                        while (num2 == num2_new && TryCount < 3)
                        {
                            if (num2 >= this.class10_settings_0.float_3)
                            {
                                if ((num2 - ((num2 / 100f) * (this.class10_settings_0.float_1 * Multiplyer))) >= 0f) this.class18_0.method_176(columnIndex, rowIndex, num2 - ((num2 / 100f) * (this.class10_settings_0.float_1 * Multiplyer)));
                                else this.class18_0.method_176(columnIndex, rowIndex, 0f);
                            }
                            else
                            {
                                if ((num2 - (this.class10_settings_0.float_2 * Multiplyer)) >= 0f) this.class18_0.method_176(columnIndex, rowIndex, num2 - (this.class10_settings_0.float_2 * Multiplyer));
                                else this.class18_0.method_176(columnIndex, rowIndex, 0f);
                            }

                            num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                            Multiplyer += 0.5f;
                            TryCount++;
                            if (TryCount == 3) this.class18_0.method_155("Cannot decrease fuel value for Col:#" + columnIndex + " Row:#" + rowIndex);
                        }
                    }
                }
                this.class18_0.method_153();
            }
            else if (this.class18_0.method_40())
            {
                string[] strArray2 = new string[] { this.class18_0.method_4().ToString(), " -@col", (num5 + 1).ToString(), "to", (num6 + 1).ToString(), " &row", (num7 + 1).ToString(), "to", (num8 + 1).ToString() };
                this.class18_0.method_155(string.Concat(strArray2));
                for (int k = 0; k < cells.Count; k++)
                {
                    columnIndex = (byte)cells[k].ColumnIndex;
                    rowIndex = (byte)cells[k].RowIndex;
                    num2 = this.class18_0.method_174(columnIndex, rowIndex);
                    if ((num2 - this.class10_settings_0.float_0) >= -6f) this.class18_0.method_176(columnIndex, rowIndex, num2 - this.class10_settings_0.float_0);
                    else this.class18_0.method_176(columnIndex, rowIndex, -6f);

                    //Check if editing are done correctly
                    if (num2 > -6f)
                    {
                        float num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                        float Multiplyer = 1.5f;
                        int TryCount = 0;
                        while (num2 == num2_new && TryCount < 3)
                        {
                            if ((num2 - (this.class10_settings_0.float_0 * Multiplyer)) >= -6f) this.class18_0.method_176(columnIndex, rowIndex, num2 - (this.class10_settings_0.float_0 * Multiplyer));
                            else this.class18_0.method_176(columnIndex, rowIndex, -6f);

                            num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                            Multiplyer += 0.5f;
                            TryCount++;
                            if (TryCount == 3) this.class18_0.method_155("Cannot decrease ignition value for Col:#" + columnIndex + " Row:#" + rowIndex);
                        }
                    }
                }
                this.class18_0.method_153();
            }
            cells = null;
            rowIndex = 0;
            columnIndex = 0;
            this.ctrlGrid.method_35();
        }
    }

    public void toolIncrease_Click(object sender, EventArgs e)
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        if (this.class18_0.method_8() == TableOverlay.afTarget)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                this.class12_afrT_0.method_14(cells[i].ColumnIndex, cells[i].RowIndex, this.class12_afrT_0.method_12(cells[i].ColumnIndex, cells[i].RowIndex) + this.class10_settings_0.float_4);
                this.ctrlGrid.method_34(cells[i].ColumnIndex, cells[i].RowIndex);
            }
        }
        else
        {
            byte rowIndex;
            byte columnIndex;
            float num2 = 0f;
            int[] numArray = this.ctrlGrid.method_10();
            int num5 = numArray[0];
            int num7 = numArray[1];
            int num6 = numArray[2];
            int num8 = numArray[3];
            this.class18_0.method_163((byte)num5);
            this.class18_0.method_163((byte)num6);
            this.class18_0.method_159((byte)num7);
            this.class18_0.method_159((byte)num8);
            if (this.class18_0.method_37())
            {
                string[] strArray = new string[] { this.class18_0.method_4().ToString(), " -@col", (num5 + 1).ToString(), "to", (num6 + 1).ToString(), " &row", (num7 + 1).ToString(), "to", (num8 + 1).ToString() };
                this.class18_0.method_155(string.Concat(strArray));
                for (int j = 0; j < cells.Count; j++)
                {
                    columnIndex = (byte)cells[j].ColumnIndex;
                    rowIndex = (byte)cells[j].RowIndex;
                    num2 = this.class18_0.method_174(columnIndex, rowIndex);
                    if (num2 >= this.class10_settings_0.float_3) this.class18_0.method_176(columnIndex, rowIndex, num2 + ((num2 / 100f) * this.class10_settings_0.float_1));
                    else this.class18_0.method_176(columnIndex, rowIndex, num2 + this.class10_settings_0.float_2);

                    //Check if editing are done correctly
                    float num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                    float Multiplyer = 1.5f;
                    int TryCount = 0;
                    while (num2 == num2_new && TryCount < 3)
                    {
                        if (num2 >= this.class10_settings_0.float_3) this.class18_0.method_176(columnIndex, rowIndex, num2 + ((num2 / 100f) * (this.class10_settings_0.float_1 * Multiplyer)));
                        else this.class18_0.method_176(columnIndex, rowIndex, num2 + (this.class10_settings_0.float_2 * Multiplyer));

                        num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                        Multiplyer += 0.5f;
                        TryCount++;
                        if (TryCount == 3) this.class18_0.method_155("Cannot increase fuel value for Col:#" + columnIndex + " Row:#" + rowIndex);
                    }
                }
                this.class18_0.method_153();
            }
            else if (this.class18_0.method_40())
            {
                string[] strArray2 = new string[] { this.class18_0.method_4().ToString(), " -@col", (num5 + 1).ToString(), "to", (num6 + 1).ToString(), " &row", (num7 + 1).ToString(), "to", (num8 + 1).ToString() };
                this.class18_0.method_155(string.Concat(strArray2));
                for (int k = 0; k < cells.Count; k++)
                {
                    columnIndex = (byte)cells[k].ColumnIndex;
                    rowIndex = (byte)cells[k].RowIndex;
                    num2 = this.class18_0.method_174(columnIndex, rowIndex);
                    if (num2 + this.class10_settings_0.float_0 <= 60f) this.class18_0.method_176(columnIndex, rowIndex, num2 + this.class10_settings_0.float_0);
                    else this.class18_0.method_176(columnIndex, rowIndex, 60f);

                    //Check if editing are done correctly
                    if (num2 < 60f)
                    {
                        float num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                        float Multiplyer = 1.5f;
                        int TryCount = 0;
                        while (num2 == num2_new && TryCount < 3)
                        {
                            if (num2 + (this.class10_settings_0.float_0 * Multiplyer) <= 60f) this.class18_0.method_176(columnIndex, rowIndex, num2 + (this.class10_settings_0.float_0 * Multiplyer));
                            else this.class18_0.method_176(columnIndex, rowIndex, 60f);

                            num2_new = this.class18_0.method_174(columnIndex, rowIndex);
                            Multiplyer += 0.5f;
                            TryCount++;
                            if (TryCount == 3) this.class18_0.method_155("Cannot increase ignition value for Col:#" + columnIndex + " Row:#" + rowIndex);
                        }
                    }
                }
                this.class18_0.method_153();
            }
            cells = null;
            rowIndex = 0;
            columnIndex = 0;
            this.ctrlGrid.method_35();
        }
    }

    public void toolSmooth_Click(object sender, EventArgs e)
    {
        this.method_29_Smooth();
    }

    private void toolSmooth_MouseMove(object sender, MouseEventArgs e)
    {
    }

    private void toolStripButton_1_Click(object sender, EventArgs e)
    {
        bool Active = !this.class10_settings_0.bool_6;
        if (dGraphToolStripMenuItem1.Checked) Active = true;
        this.class10_settings_0.bool_6 = Active;
        //tablesToolStripMenuItem1.Checked = false;
        this.dGraphToolStripMenuItem.Checked = this.class10_settings_0.bool_6;
        this.dGraphToolStripMenuItem1.Checked = false;
        this.ctrlMapGraph1.mapGraphType_0 = MapGraphType.twoD;
        this.class10_settings_0.int_2 = (int)this.ctrlMapGraph1.mapGraphType_0;
        this.ctrlMapGraph1.Invalidate();
        showGraph(this.class10_settings_0.bool_6);
    }

    private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
    {
        if (!IsLoading)
        {
            this.class10_settings_0.SplitterDistance = this.splitContainer1.SplitterDistance;
        }
    }

    private void toolStripButton_2_Click(object sender, EventArgs e)
    {
        bool Active = !this.class10_settings_0.bool_6;
        if (dGraphToolStripMenuItem.Checked) Active = true;
        this.class10_settings_0.bool_6 = Active;
        //tablesToolStripMenuItem1.Checked = false;
        this.dGraphToolStripMenuItem.Checked = false;
        this.dGraphToolStripMenuItem1.Checked = this.class10_settings_0.bool_6;
        this.ctrlMapGraph1.mapGraphType_0 = MapGraphType.threeD;
        this.class10_settings_0.int_2 = (int)this.ctrlMapGraph1.mapGraphType_0;
        this.ctrlMapGraph1.Invalidate();
        showGraph(this.class10_settings_0.bool_6);
    }

    public void ClearDatalog()
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        if (cells.Count >= 2)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                this.class12_afrT_0.method_4(cells[i].ColumnIndex, cells[i].RowIndex);
                if (this.class18_0.method_8() != TableOverlay.none)
                {
                    this.ctrlGrid.method_34(cells[i].ColumnIndex, cells[i].RowIndex);
                }
            }
        }
        else
        {
            this.class12_afrT_0.method_3();
            if (this.class18_0.method_8() != TableOverlay.none)
            {
                this.ctrlGrid.method_31();
            }
        }
    }

    private void toolTunerClear_Click(object sender, EventArgs e)
    {
        ClearDatalog();
    }

    private void toolTunerFilterSelectedCells_Click(object sender, EventArgs e)
    {
        if (this.ctrlGrid.method_9().Count >= 4)
        {
            foreach (DataGridViewCell cell in this.ctrlGrid.method_9())
            {
                this.class12_afrT_0.method_6(cell.ColumnIndex, cell.RowIndex);
                this.ctrlGrid.method_34(cell.ColumnIndex, cell.RowIndex);
            }
        }
        else
        {
            for (int i = 0; i < this.class18_0.method_33(); i++)
            {
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    this.class12_afrT_0.method_6(i, j);
                }
            }
            if (this.class18_0.method_8() != TableOverlay.none)
            {
                this.ctrlGrid.method_31();
            }
        }
    }

    private void toolTunerMapTrail_CheckedChanged(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_43 = this.toolTunerMapTrail.Checked;
        this.ctrlGrid.method_31();
    }

    private void toolTunerMenu_DropDownOpening(object sender, EventArgs e)
    {
        DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
        this.toolTunerFollowVtec.Checked = this.class10_settings_0.bool_42;
        this.toolTunerMapTrail.Checked = this.class10_settings_0.bool_43;
        this.toolTunerFollowDualTables.Checked = this.class10_settings_0.bool_44;
        this.toolTunerSmartTrack.Checked = this.class10_settings_0.bool_45;
        this.toolTunerClearAll.Visible = true;
        this.toolTunerClear.Text = "Clear Selected Cells";
        this.copyPrimarySecondaryToolStripMenuItem.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        if (cells.Count >= 2)
        {
            this.toolTunerClear.Enabled = true;
        }
        else
        {
            this.toolTunerClear.Enabled = false;
        }
    }

    private void toolTunerSmartTrack_CheckedChanged(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_45 = this.toolTunerSmartTrack.Checked;
        //this.class10_0.bool_42 = this.toolTunerSmartTrack.Checked;
    }

    private bool IsAnalogOverlay()
    {
        bool IsAnalog = false;
        if (this.class18_0.method_8() == TableOverlay.analog1Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.analog2Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.analog3Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.DynoWSReading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.DynoHPReading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.DynoNMReading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.AUX1Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.AUX2Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.AUX3Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.THCReading) IsAnalog = true;
        return IsAnalog;
    }

    public void ClearRecording()
    {
        this.class12_afrT_0.method_3();
        this.ctrlMapGraph1.method_17();
        if (this.class18_0.method_8() != TableOverlay.none)
        {
            this.ctrlGrid.method_31();
        }
    }

    private void tunerClearAll_Click(object sender, EventArgs e)
    {
        ClearRecording();
    }

    public void ClearMapTrace()
    {
        this.class12_afrT_0.method_5();
        this.class18_0.method_53();
    }

    private void tunerClearMapTrails_Click(object sender, EventArgs e)
    {
        ClearMapTrace();
    }

    private void tunerFilter_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.class18_0.method_33(); i++)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                this.class12_afrT_0.method_6(i, j);
            }
        }
        if (this.class18_0.method_8() != TableOverlay.none)
        {
            this.ctrlGrid.method_31();
        }
    }

    private void CheckEditMode()
    {
        if (this.ctrlGrid.method_6())
        {
            MessageBox.Show(Form.ActiveForm, "cell is in edit mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    public void SelectMap(int Area)
    {
        //if (!this.class18_0.class13_0.bool_0 || !this.class18_0.method_38())
        //{
        this.bool_0 = true;
        if (ShowingVE) this.class18_0.method_5_SetSelectedTable((SelectedTable)(9 + this.method_21(false)));
        else this.class18_0.method_5_SetSelectedTable((SelectedTable)(1 + Area));

        if (toolStripButtonAFTarget.Checked || toolStripButtonAFReading.Checked || toolStripButtonAFDiff.Checked)
        {
            if (!toolStripButtonLowFuel.Checked && !toolStripButtonHighFuel.Checked)
            {
                toolStripButtonLowFuel.Checked = true;
                if (toolStripButtonPrimary.Checked) this.class18_0.method_5_SetSelectedTable((SelectedTable)(3));
                else this.class18_0.method_5_SetSelectedTable((SelectedTable)(7));
            }
        }
        SetMapsButtons();
        this.frmMain_0.SetMapsButtons();
        this.bool_0 = false;
        //}
    }

    private delegate void Delegate6(Struct12 struct12_0);

    private delegate void Delegate7(Struct17 struct17_0);

    private void aFToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SelectAFReading();
    }

    private void vETablesToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        SelectVE();
    }

    private void aFTargetToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        SelectAFTarget();
    }

    private void fuelDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SelectAFDiff();
    }

    private void mapValuesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SelectFuel();
    }

    private void toolTunerFollowDualTables_CheckedChanged(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_44 = this.toolTunerFollowDualTables.Checked;
    }

    private void toolTunerFollowVtec_CheckedChanged(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_42 = this.toolTunerFollowVtec.Checked;
    }

    private void onlyNAViewToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_6 = true;
        showGraph(this.class10_settings_0.bool_6);

        this.class10_settings_0.bool_20_ONLY_NA_VIEW = !this.class10_settings_0.bool_20_ONLY_NA_VIEW;
        onlyNAViewToolStripMenuItem.Checked = this.class10_settings_0.bool_20_ONLY_NA_VIEW;
        this.ctrlMapGraph1.Invalidate();
    }

    private void belowTableToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_6 = true;
        showGraph(this.class10_settings_0.bool_6);

        this.class10_settings_0.bool_15 = !this.class10_settings_0.bool_15;
        this.class18_0.method_52();
        this.belowTableToolStripMenuItem.Checked = this.class10_settings_0.bool_15;
    }

    private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //this.frmMain_0.SelectPage("Parameters");  //edit here
        //this.frmMain_0.parametersToolStripButton_Click(sender, e);
    }

    private void copyPrimarySecondaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmMain_0.copyPrimarySecondaryMaps_Click(sender, e);
    }

    private void boostTableToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmMain_0.bstTablesToolStripMenuItem_Click(sender, e);
    }

    private void FrmGridChart_Click(object sender, EventArgs e)
    {
        this.method_24(this.class18_0.method_4());
    }

    private void FrmGridChart_Enter(object sender, EventArgs e)
    {
        this.method_24(this.class18_0.method_4());
    }

    private void scalarsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmMain_0.OpenScalarMenu();
    }

    public void SetImageBackgrounds()
    {
        if (this.ctrlMapGraph1 != null) this.ctrlMapGraph1.SetImageBackgrounds();
    }

    private void FrmGridChart_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.tables_Location = base.Location;
        this.class10_settings_0.tunerToolStrip = this.tunerToolStrip.Location;
        this.class10_settings_0.tableEditToolStrip = this.tableEditToolStrip.Location;
        this.class10_settings_0.tableViewToolStrip = this.tableViewToolStrip.Location;
    }

    private void autoAdjustSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.double_4 != 0.0)
        {
            DataGridViewSelectedCellCollection cells = this.ctrlGrid.method_9();
            this.int_0 = this.ctrlGrid.method_10();
            float num7 = 0f;
            int num = this.int_0[0];
            int num3 = this.int_0[1];
            int num2 = this.int_0[2];
            int num4 = this.int_0[3];
            this.class18_0.method_163((byte)num);
            this.class18_0.method_163((byte)num2);
            this.class18_0.method_159((byte)num3);
            this.class18_0.method_159((byte)num4);
            string[] strArray = new string[] { this.class18_0.method_4().ToString(), " percent: ", this.double_4.ToString("0.0"), "@col", (num + 1).ToString(), "to", (num2 + 1).ToString(), " &row", (num3 + 1).ToString(), "to", (num4 + 1).ToString() };
            this.class18_0.method_155(string.Concat(strArray));
            for (int i = 0; i < cells.Count; i++)
            {
                byte columnIndex = (byte)cells[i].ColumnIndex;
                byte rowIndex = (byte)cells[i].RowIndex;
                num7 = this.class18_0.method_174(columnIndex, rowIndex);
                this.class18_0.method_176(columnIndex, rowIndex, num7 + ((num7 / 100f) * ((float)this.double_4)));
                this.class12_afrT_0.method_4(columnIndex, rowIndex);
                this.ctrlGrid.method_34(columnIndex, rowIndex);
            }
            this.class18_0.method_153();
        }
    }


    private void toolStripMenuItem6_Click(object sender, EventArgs e)
    {
        SelectAnalog1Reading();
    }

    private void analog2Reading_Button_Click(object sender, EventArgs e)
    {
        SelectAnalog2Reading();
    }
    private void analog1ReadingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SelectAnalog3Reading();
    }

    private void ToolStripButtonLowIgn_Click(object sender, EventArgs e)
    {
        int index = 0;
        if (toolStripButtonSecondary.Checked) index += 4;
        SelectMap(index);
    }

    private void ToolStripButtonHighIgn_Click(object sender, EventArgs e)
    {
        int index = 1;
        if (toolStripButtonSecondary.Checked) index += 4;
        SelectMap(index);
    }

    private void ToolStripButtonLowFuel_Click(object sender, EventArgs e)
    {
        int index = 2;
        if (toolStripButtonSecondary.Checked) index += 4;
        SelectMap(index);
    }

    private void ToolStripButtonHighFuel_Click(object sender, EventArgs e)
    {
        int index = 3;
        if (toolStripButtonSecondary.Checked) index += 4;
        SelectMap(index);
    }

    private void ToolStripButtonPrimary_Click(object sender, EventArgs e)
    {
        int num = (int)this.class18_0.method_4();
        if (num >= 5)
        {
            num -= 4;
            SelectMap(num - 1);
        }
        toolStripButtonPrimary.Checked = true;
    }

    private void ToolStripButtonSecondary_Click(object sender, EventArgs e)
    {
        int num = (int)this.class18_0.method_4();
        if (num < 5)
        {
            num += 4;
            SelectMap(num - 1);
        }
        toolStripButtonSecondary.Checked = true;
    }

    private void ToolStripButtonMapValue_Click(object sender, EventArgs e)
    {
        SelectFuel();
    }

    private void ToolStripButtonAFTarget_Click(object sender, EventArgs e)
    {
        SelectAFTarget();
    }

    private void ToolStripButtonAFReading_Click(object sender, EventArgs e)
    {
        SelectAFReading();
    }

    private void ToolStripButtonAFDiff_Click(object sender, EventArgs e)
    {
        SelectAFDiff();
    }

    private void ToolStripButtonVE_Click(object sender, EventArgs e)
    {
        SelectVE();
    }

    private void SetMapsButtons()
    {
        int num = (int)this.class18_0.method_4();

        if (num < 5)
        {
            toolStripButtonPrimary.Checked = true;
            toolStripButtonSecondary.Checked = false;
        }
        else
        {
            toolStripButtonPrimary.Checked = false;
            toolStripButtonSecondary.Checked = true;
        }

        if (num >= 5) num -= 4;
        if (num == 0) num = 1;

        if (num == 1)
        {
            toolStripButtonLowIgn.Checked = true;
            toolStripButtonHighIgn.Checked = false;
            toolStripButtonLowFuel.Checked = false;
            toolStripButtonHighFuel.Checked = false;
        }
        else if (num == 2)
        {
            toolStripButtonLowIgn.Checked = false;
            toolStripButtonHighIgn.Checked = true;
            toolStripButtonLowFuel.Checked = false;
            toolStripButtonHighFuel.Checked = false;
        }
        else if (num == 3)
        {
            toolStripButtonLowIgn.Checked = false;
            toolStripButtonHighIgn.Checked = false;
            toolStripButtonLowFuel.Checked = true;
            toolStripButtonHighFuel.Checked = false;
        }
        else if (num == 4)
        {
            toolStripButtonLowIgn.Checked = false;
            toolStripButtonHighIgn.Checked = false;
            toolStripButtonLowFuel.Checked = false;
            toolStripButtonHighFuel.Checked = true;
        }
    }

    private void ToolTunerTrace_DropDownOpening(object sender, EventArgs e)
    {
        this.singleCellEndcolumnRowToolStripMenuItem.Checked = false;
        this.singleCellToolStripMenuItem.Checked = false;
        this.quadCellToolStripMenuItem.Checked = false;
        this.singleCellRowToolStripMenuItem.Checked = false;
        this.singleCellEndcolumnToolStripMenuItem.Checked = false;
        switch (this.class10_settings_0.tunerSmartTrack)
        {
            case 0:
                this.singleCellToolStripMenuItem.Checked = true;
                return;

            case 1:
                this.quadCellToolStripMenuItem.Checked = true;
                return;

            case 2:
                this.singleCellRowToolStripMenuItem.Checked = true;
                return;

            case 3:
                this.singleCellEndcolumnToolStripMenuItem.Checked = true;
                return;

            case 4:
                this.singleCellEndcolumnRowToolStripMenuItem.Checked = true;
                return;
        }
    }

    private void SingleCellToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.tunerSmartTrack = int.Parse(((ToolStripMenuItem)sender).Tag.ToString());
        this.ctrlGrid.method_31();
        ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
    }

    private void FollowSelectedCellsOnRowcolumnHeaderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_10 = this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem.Checked;
    }

    private void FollowTraceOnRowcolumnHeaderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_11 = this.followTraceOnRowcolumnHeaderToolStripMenuItem.Checked;
    }

    private void DrawOnCellTraceTheInterpolationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_21 = this.drawOnCellTraceTheInterpolationToolStripMenuItem.Checked;
    }

    private void ToolTunerTraceOptions_DropDownOpening(object sender, EventArgs e)
    {
        this.followSelectedCellsOnRowcolumnHeaderToolStripMenuItem.Checked = this.class10_settings_0.bool_10;
        this.followTraceOnRowcolumnHeaderToolStripMenuItem.Checked = this.class10_settings_0.bool_11;
        this.drawOnCellTraceTheInterpolationToolStripMenuItem.Checked = this.class10_settings_0.bool_21;
    }

    private void DynoWSReading_Button_Click(object sender, EventArgs e)
    {
        this.SelectDynoWSReading();
    }

    private void DynoHPReading_Button_Click(object sender, EventArgs e)
    {
        this.SelectDynoHPReading();
    }

    private void DynoNMReading_Button_Click(object sender, EventArgs e)
    {
        this.SelectDynoNMReading();
    }

    private void AUX1Reading_Button_Click(object sender, EventArgs e)
    {
        this.SelectAUX1Reading();
    }

    private void AUX2Reading_Button_Click(object sender, EventArgs e)
    {
        this.SelectAUX2Reading();
    }

    private void AUX3Reading_Button_Click(object sender, EventArgs e)
    {
        this.SelectAUX3Reading();
    }

    private void THCReading_Button_Click(object sender, EventArgs e)
    {
        this.SelectTHCReading();
    }
}

