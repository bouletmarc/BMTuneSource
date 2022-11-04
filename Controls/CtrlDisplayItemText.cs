namespace Controls
{
    using Data;
    //using PropertiesRes;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Threading;
    using System.Timers;

    //[Serializable]
    internal class CtrlDisplayItemText : UserControl
    {
        private int _DataDisplayType = 0;
        private bool _SecData = true;
        //private bool canInvoke;
        private IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private Collection<CtrlDisplayItemText> DisplayItems;
        private byte mapvalue;
        private Graphics graphics_0;
        private ToolStripMenuItem menuItemRemove;
        private ToolStripMenuItem menuItemRestore;
        private ToolStripMenuItem menuItemSetType;
        private ToolStripMenuItem menuItemShowSecondaryData;
        private ToolStripMenuItem menuItemWarningColor;
        private ToolStripMenuItem menuItmClearPeak;
        private ToolStripMenuItem menuItmShowPeak;
        private Class17 class17_0;
        private Class18 Class18_0;
        private Class33_Sensors Class33_Sensors_0;
        private FrmMain FrmMain_0;

        private DatalogDisplayTypes DatalogDisplayTypes_0;
        private DatalogLedTypes DatalogLedTypes_0;
        private SensorsX SensorsX_0;
        private DatalogButtonsTypes DatalogButtonsTypes_0;

        private double peakVal;
        public double DataMain2 = 0;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem editWarningsToolStripMenuItem;
        private ToolStripMenuItem editSpeedConditionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private frmAccelTimeSetting frmAccelTimeSetting_0;
        public frmGaugesEditor frmGaugesEditor_0;
        private ToolStripMenuItem menuItemTextVertical;
        private CtrlDisplayItemText CtrlDisplayItemText_0;

        public event DelegateButton AddButtonRequest;
        public event DelegateSensor AddSensorRequest;
        public event DelegateGauge AddGaugeRequest;
        public event DelegateGraph AddGraphRequest;
        public event Delegate18 AddLedRequest;
        public event Delegate20 AddRequest;
        public event Delegate19 DefaultsRequest;
        public event Delegate17 MoveLeftRequest;
        public event Delegate21 MoveRightRequest;
        public event Delegate16 RemoveRequest;

        private bool InEditMode = false;
        private bool IsDragging = false;
        private int iClickX = 0;
        private int iClickY = 0;
        private bool IsLEDActivated = false;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem menuItemSetTypeDisplay;
        private ToolStripMenuItem setAsDataDisplayToolStripMenuItem;
        private ToolStripMenuItem setAsBarsGraphToolStripMenuItem;
        private ToolStripMenuItem setAsGaugeToolStripMenuItem;
        public bool _IsTextVertical = false;

        private bool ButtonClicked = false;

        public Color ColorBack = Color.Black;
        public Color ColorMainText = Color.Black;
        public Color ColorSecText = Color.Black;
        public Color ColorNameText = Color.Black;
        public string DataMain = "";
        public string DataSec = "";
        public string DataType = "";
        private ToolStripMenuItem loadPresetToolStripMenuItem;
        private ToolStripMenuItem savePresetToolStripMenuItem;
        private ToolStripMenuItem editDisplayManuallyToolStripMenuItem;
        private ToolStripMenuItem addDisplayTypeToolStripMenuItem;
        private ToolStripMenuItem menuItemAddDataDisplay;
        private ToolStripMenuItem menuItemAddLedDisplay;
        private ToolStripMenuItem addBarsGraphToolStripMenuItem;
        private ToolStripMenuItem addGaugeToolStripMenuItem;
        private ToolStripMenuItem addSensorToolStripMenuItem;
        private ToolStripMenuItem setAsSensorToolStripMenuItem;
        public string SensorName = "";
        public ToolStripMenuItem lockPositionSizingToolStripMenuItem;

        //private System.Timers.Timer timer_0 = new System.Timers.Timer(200.0);

        private DateTime LastCheck = DateTime.Now;

        internal CtrlDisplayItemText(ref Class17 myDt, ref Class18 rm, ref Collection<CtrlDisplayItemText> Itms, ref FrmMain FrmMain_1)
        {
            this.InitializeComponent();
            this.class17_0 = myDt;
            this.Class18_0 = rm;
            this.DisplayItems = Itms;
            this.FrmMain_0 = FrmMain_1;
            this.Class33_Sensors_0 = this.class17_0.class33_Sensors;
            this.Class18_0.delegate58_0 += new Class18.Delegate58(this.Class18_0_RomReload);
            this.class17_0.delegate53_0 += new Class17.Delegate53(this.myDatalogger_DatalogFileOpened);
            this.class17_0.delegate54_0 += new Class17.Delegate54(this.myDataloggerUpdateInvoke);
            //this.myDatalogger.delegate48_0 += new Class17_dtl.Delegate48(this.myDatalogger_DataloggingFrameReceivedPeak);

            base.HandleCreated += new EventHandler(this.CtrlDisplayItemText_HandleCreated);
            base.HandleDestroyed += new EventHandler(this.CtrlDisplayItemText_HandleDestroyed);

            this.BackColor = this.Class18_0.class10_settings_0.color_8;
            this.ColorMainText = this.Class18_0.class10_settings_0.color_4;
            this.ColorSecText = this.Class18_0.class10_settings_0.color_4;
            this.ColorBack = this.Class18_0.class10_settings_0.color_7;
            this.ColorNameText = this.Class18_0.class10_settings_0.color_4;

            lockPositionSizingToolStripMenuItem.Checked = this.FrmMain_0.frmDataDisplay_0.LockedPositionAndSize;

            //this.timer_0.Elapsed += new ElapsedEventHandler(this.timer_0_Elapsed);

            CtrlDisplayItemText_0 = this;

            foreach (Control control in base.Controls)
            {
                float emSize = control.Font.Size * (Class18_0.class10_settings_0.scaleRate / 100f);
                control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
            }
        }

        /*private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
        {
            ButtonClicked = false;
            this.Invalidate();
        }*/

        private bool addDisplayTolist(DatalogDisplayTypes typ)
        {
            switch (typ)
            {
                case DatalogDisplayTypes.nEw:
                    return true;

                case DatalogDisplayTypes.rpm:
                    return true;

                case DatalogDisplayTypes.map:
                    return true;

                case DatalogDisplayTypes.boost:
                    return true;

                case DatalogDisplayTypes.O2:
                    return true;

                case DatalogDisplayTypes.tps:
                    return true;

                case DatalogDisplayTypes.inj:
                    return true;

                case DatalogDisplayTypes.ign:
                    return true;

                case DatalogDisplayTypes.iat:
                    return true;

                case DatalogDisplayTypes.ect:
                    return true;

                case DatalogDisplayTypes.bat:
                    return true;

                case DatalogDisplayTypes.bstctrl:
                    return true;

                case DatalogDisplayTypes.vss:
                    return true;

                case DatalogDisplayTypes.gear:
                    return true;

                case DatalogDisplayTypes.o2Trim:
                    return true;

                case DatalogDisplayTypes.analog1:
                    return true;

                case DatalogDisplayTypes.analog2:
                    return true;

                case DatalogDisplayTypes.analog3:
                    return true;

                case DatalogDisplayTypes.accelTime:
                    return true;
                case DatalogDisplayTypes.fuelUsage:
                    return true;
                case DatalogDisplayTypes.flexFuel:
                    return true;
                case DatalogDisplayTypes.ectV:
                    return true;
                case DatalogDisplayTypes.iatV:
                    return true;
            }
            return false;
        }

        private void AddLedDisplay_Click(object sender, EventArgs e)
        {
            if (this.AddLedRequest != null)
            {
                this.AddLedRequest(this);
            }
        }

        private void AddGraphDisplay_Click(object sender, EventArgs e)
        {
            if (this.AddGraphRequest != null)
            {
                this.AddGraphRequest(this);
            }
        }

        private void AddGaugeDisplay_Click(object sender, EventArgs e)
        {
            if (this.AddGaugeRequest != null)
            {
                this.AddGaugeRequest(this);
            }
        }

        private void AddSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AddSensorRequest != null)
            {
                this.AddSensorRequest(this);
            }
        }

        private void AddButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AddButtonRequest != null)
            {
                this.AddButtonRequest(this);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AddRequest != null)
            {
                this.AddRequest(this);
            }
        }

        private void SetAsLedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataDisplayType = 1;
            this.Invalidate();
        }

        public void ClearPeak()
        {
            foreach (CtrlDisplayItemText item in this.DisplayItems)
            {
                item.peakVal = 0.0;
                item.mapvalue = 0;
                item.Invalidate();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool IsDataMenu = (this.DataDisplayType == 0 || this.DataDisplayType == 2 || this.DataDisplayType == 3);
            this.menuItmClearPeak.Visible = IsDataMenu;
            this.menuItmShowPeak.Visible = IsDataMenu;
            this.menuItemRestore.Visible = IsDataMenu;
            this.toolStripSeparator3.Visible = IsDataMenu;
            this.toolStripSeparator4.Visible = IsDataMenu;
            this.menuItemShowSecondaryData.Visible = IsDataMenu;

            this.menuItemTextVertical.Visible = (this.DataDisplayType == 1);

            if (this.DataDisplayType != 1 && this.DataDisplayType != 5) this.menuItemRemove.Text = "Remove " + this.SensorName;
            else if (this.DataDisplayType == 5) this.menuItemRemove.Text = "Remove Button";
            else this.menuItemRemove.Text = "Remove Led";

            if (this.hasSecData && IsDataMenu)
            {
                this.menuItemShowSecondaryData.Enabled = true;
                this.menuItemShowSecondaryData.Checked = this.SecData;
            }
            else
            {
                this.menuItemShowSecondaryData.Checked = false;
                this.menuItemShowSecondaryData.Enabled = false;
            }

            //Warning Colors
            if (this.DataDisplayType == 0 || this.DataDisplayType == 2 || this.DataDisplayType == 3 || this.DataDisplayType == 4)
            {
                this.menuItemWarningColor.Checked = this.Class18_0.class10_settings_0.bool_24 && IsDataMenu;
                if ((this.Type == DatalogDisplayTypes.O2) && IsDataMenu) this.menuItemWarningColor.Visible = false;
                else this.menuItemWarningColor.Visible = IsDataMenu;
            }

            this.menuItemSetType.DropDownItems.Clear();
            if (DataDisplayType == 0 || DataDisplayType == 2 || DataDisplayType == 3)
            {
                for (int i = 1; i < 26; i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(((DatalogDisplayTypes)i).ToString()) { Tag = i };
                    item.Click += new EventHandler(this.itm_Click);
                    if (this.addDisplayTolist((DatalogDisplayTypes)i)) this.menuItemSetType.DropDownItems.Add(item);
                }
            }
            else if (DataDisplayType == 1)
            {
                for (int i = 1; i < (0x17 + 26); i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(((DatalogLedTypes)i).ToString()) { Tag = i };
                    item.Click += new EventHandler(this.itm_LED_Click);
                    this.menuItemSetType.DropDownItems.Add(item);
                }
            }
            else if (DataDisplayType == 4)
            {
                for (int i = 0; i < this.Class18_0.class10_settings_0.int_0; i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(((SensorsX)i).ToString()) { Tag = i };
                    item.Click += new EventHandler(this.itm_ALL_Click);
                    this.menuItemSetType.DropDownItems.Add(item);
                }
            }
            else if (DataDisplayType == 5)
            {
                for (int i = 0; i < this.Class18_0.class10_settings_0.int_0; i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(((DatalogButtonsTypes)i).ToString()) { Tag = i };
                    item.Click += new EventHandler(this.itm_BUTTON_Click);
                    this.menuItemSetType.DropDownItems.Add(item);
                }
            }
            this.menuItmShowPeak.Checked = this.Class18_0.class10_settings_0.dtPeakShown & IsDataMenu;
        }

        private void CtrlDisplayItemText_HandleCreated(object sender, EventArgs e)
        {
            //this.canInvoke = true;
        }

        private void CtrlDisplayItemText_HandleDestroyed(object sender, EventArgs e)
        {
            //this.canInvoke = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.graphics_0 != null) this.graphics_0.Dispose();
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDisplayTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddDataDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddLedDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.addBarsGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGaugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsDataDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetTypeDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsBarsGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsGaugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTextVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lockPositionSizingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemWarningColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowSecondaryData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItmShowPeak = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItmClearPeak = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editSpeedConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editWarningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDisplayManuallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDisplayTypeToolStripMenuItem,
            this.menuItemSetType,
            this.toolStripMenuItem1,
            this.menuItemRemove,
            this.menuItemTextVertical,
            this.toolStripSeparator1,
            this.lockPositionSizingToolStripMenuItem,
            this.menuItemRestore,
            this.toolStripSeparator4,
            this.menuItemWarningColor,
            this.menuItemShowSecondaryData,
            this.menuItmShowPeak,
            this.menuItmClearPeak,
            this.toolStripSeparator3,
            this.editSpeedConditionsToolStripMenuItem,
            this.editWarningsToolStripMenuItem,
            this.editDisplayManuallyToolStripMenuItem,
            this.loadPresetToolStripMenuItem,
            this.savePresetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 374);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addDisplayTypeToolStripMenuItem
            // 
            this.addDisplayTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddDataDisplay,
            this.menuItemAddLedDisplay,
            this.addBarsGraphToolStripMenuItem,
            this.addGaugeToolStripMenuItem,
            this.addSensorToolStripMenuItem});
            this.addDisplayTypeToolStripMenuItem.Name = "addDisplayTypeToolStripMenuItem";
            this.addDisplayTypeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addDisplayTypeToolStripMenuItem.Text = "Add Display Type";
            // 
            // menuItemAddDataDisplay
            // 
            this.menuItemAddDataDisplay.Name = "menuItemAddDataDisplay";
            this.menuItemAddDataDisplay.Size = new System.Drawing.Size(156, 22);
            this.menuItemAddDataDisplay.Text = "Add Data";
            this.menuItemAddDataDisplay.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // menuItemAddLedDisplay
            // 
            this.menuItemAddLedDisplay.Name = "menuItemAddLedDisplay";
            this.menuItemAddLedDisplay.Size = new System.Drawing.Size(156, 22);
            this.menuItemAddLedDisplay.Text = "Add Led";
            this.menuItemAddLedDisplay.Click += new System.EventHandler(this.AddLedDisplay_Click);
            // 
            // addBarsGraphToolStripMenuItem
            // 
            this.addBarsGraphToolStripMenuItem.Name = "addBarsGraphToolStripMenuItem";
            this.addBarsGraphToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addBarsGraphToolStripMenuItem.Text = "Add Bars Graph";
            this.addBarsGraphToolStripMenuItem.Click += new System.EventHandler(this.AddGraphDisplay_Click);
            // 
            // addGaugeToolStripMenuItem
            // 
            this.addGaugeToolStripMenuItem.Name = "addGaugeToolStripMenuItem";
            this.addGaugeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addGaugeToolStripMenuItem.Text = "Add Gauge";
            this.addGaugeToolStripMenuItem.Click += new System.EventHandler(this.AddGaugeDisplay_Click);
            // 
            // addSensorToolStripMenuItem
            // 
            this.addSensorToolStripMenuItem.Name = "addSensorToolStripMenuItem";
            this.addSensorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addSensorToolStripMenuItem.Text = "Add Sensor";
            this.addSensorToolStripMenuItem.Click += new System.EventHandler(this.AddSensorToolStripMenuItem_Click);
            // 
            // menuItemSetType
            // 
            this.menuItemSetType.Name = "menuItemSetType";
            this.menuItemSetType.Size = new System.Drawing.Size(190, 22);
            this.menuItemSetType.Text = "Set Sensor";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsDataDisplayToolStripMenuItem,
            this.menuItemSetTypeDisplay,
            this.setAsBarsGraphToolStripMenuItem,
            this.setAsGaugeToolStripMenuItem,
            this.setAsSensorToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem1.Text = "Set Display Type";
            // 
            // setAsDataDisplayToolStripMenuItem
            // 
            this.setAsDataDisplayToolStripMenuItem.Name = "setAsDataDisplayToolStripMenuItem";
            this.setAsDataDisplayToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setAsDataDisplayToolStripMenuItem.Text = "Set As Data";
            this.setAsDataDisplayToolStripMenuItem.Click += new System.EventHandler(this.SetAsDataDisplayToolStripMenuItem_Click);
            // 
            // menuItemSetTypeDisplay
            // 
            this.menuItemSetTypeDisplay.Name = "menuItemSetTypeDisplay";
            this.menuItemSetTypeDisplay.Size = new System.Drawing.Size(166, 22);
            this.menuItemSetTypeDisplay.Text = "Set As Led";
            this.menuItemSetTypeDisplay.Click += new System.EventHandler(this.SetAsLedToolStripMenuItem_Click);
            // 
            // setAsBarsGraphToolStripMenuItem
            // 
            this.setAsBarsGraphToolStripMenuItem.Name = "setAsBarsGraphToolStripMenuItem";
            this.setAsBarsGraphToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setAsBarsGraphToolStripMenuItem.Text = "Set As Bars Graph";
            this.setAsBarsGraphToolStripMenuItem.Click += new System.EventHandler(this.SetAsBarsGraphToolStripMenuItem_Click);
            // 
            // setAsGaugeToolStripMenuItem
            // 
            this.setAsGaugeToolStripMenuItem.Name = "setAsGaugeToolStripMenuItem";
            this.setAsGaugeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setAsGaugeToolStripMenuItem.Text = "Set As Gauge";
            this.setAsGaugeToolStripMenuItem.Click += new System.EventHandler(this.SetAsGaugeToolStripMenuItem_Click);
            // 
            // setAsSensorToolStripMenuItem
            // 
            this.setAsSensorToolStripMenuItem.Name = "setAsSensorToolStripMenuItem";
            this.setAsSensorToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setAsSensorToolStripMenuItem.Text = "Set As Sensor";
            this.setAsSensorToolStripMenuItem.Click += new System.EventHandler(this.SetAsSensorToolStripMenuItem_Click);
            // 
            // menuItemRemove
            // 
            this.menuItemRemove.Name = "menuItemRemove";
            this.menuItemRemove.Size = new System.Drawing.Size(190, 22);
            this.menuItemRemove.Text = "Remove";
            this.menuItemRemove.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // menuItemTextVertical
            // 
            this.menuItemTextVertical.Name = "menuItemTextVertical";
            this.menuItemTextVertical.Size = new System.Drawing.Size(190, 22);
            this.menuItemTextVertical.Text = "Set Text Vertical";
            this.menuItemTextVertical.Click += new System.EventHandler(this.MenuItemTextVertical_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // lockPositionSizingToolStripMenuItem
            // 
            this.lockPositionSizingToolStripMenuItem.CheckOnClick = true;
            this.lockPositionSizingToolStripMenuItem.Name = "lockPositionSizingToolStripMenuItem";
            this.lockPositionSizingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.lockPositionSizingToolStripMenuItem.Text = "Lock Position/Sizing";
            this.lockPositionSizingToolStripMenuItem.Click += new System.EventHandler(this.LockPositionSizingToolStripMenuItem_Click);
            // 
            // menuItemRestore
            // 
            this.menuItemRestore.Name = "menuItemRestore";
            this.menuItemRestore.Size = new System.Drawing.Size(190, 22);
            this.menuItemRestore.Text = "Restore Defaults";
            this.menuItemRestore.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(187, 6);
            // 
            // menuItemWarningColor
            // 
            this.menuItemWarningColor.CheckOnClick = true;
            this.menuItemWarningColor.Name = "menuItemWarningColor";
            this.menuItemWarningColor.Size = new System.Drawing.Size(190, 22);
            this.menuItemWarningColor.Text = "Show Warning Colors";
            this.menuItemWarningColor.CheckedChanged += new System.EventHandler(this.WarningColorToolStripMenuItem_CheckedChanged);
            // 
            // menuItemShowSecondaryData
            // 
            this.menuItemShowSecondaryData.CheckOnClick = true;
            this.menuItemShowSecondaryData.Name = "menuItemShowSecondaryData";
            this.menuItemShowSecondaryData.Size = new System.Drawing.Size(190, 22);
            this.menuItemShowSecondaryData.Text = "Show Secondary Data";
            this.menuItemShowSecondaryData.Click += new System.EventHandler(this.showSecondaryDataToolStripMenuItem_Click);
            // 
            // menuItmShowPeak
            // 
            this.menuItmShowPeak.CheckOnClick = true;
            this.menuItmShowPeak.Name = "menuItmShowPeak";
            this.menuItmShowPeak.Size = new System.Drawing.Size(190, 22);
            this.menuItmShowPeak.Text = "Show Peaks";
            this.menuItmShowPeak.Click += new System.EventHandler(this.menuItmShowPeak_Click);
            // 
            // menuItmClearPeak
            // 
            this.menuItmClearPeak.Name = "menuItmClearPeak";
            this.menuItmClearPeak.Size = new System.Drawing.Size(190, 22);
            this.menuItmClearPeak.Text = "Clear Peaks";
            this.menuItmClearPeak.Click += new System.EventHandler(this.menuItmClearPeak_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // editSpeedConditionsToolStripMenuItem
            // 
            this.editSpeedConditionsToolStripMenuItem.Name = "editSpeedConditionsToolStripMenuItem";
            this.editSpeedConditionsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editSpeedConditionsToolStripMenuItem.Text = "Edit Speed Conditions";
            this.editSpeedConditionsToolStripMenuItem.Visible = false;
            this.editSpeedConditionsToolStripMenuItem.Click += new System.EventHandler(this.editSpeedConditionsToolStripMenuItem_Click);
            // 
            // editWarningsToolStripMenuItem
            // 
            this.editWarningsToolStripMenuItem.Name = "editWarningsToolStripMenuItem";
            this.editWarningsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editWarningsToolStripMenuItem.Text = "Edit Limits/Warnings";
            this.editWarningsToolStripMenuItem.ToolTipText = "Edit Sensors Min/Max Limit and Warnings";
            this.editWarningsToolStripMenuItem.Click += new System.EventHandler(this.editWarningsToolStripMenuItem_Click);
            // 
            // editDisplayManuallyToolStripMenuItem
            // 
            this.editDisplayManuallyToolStripMenuItem.Name = "editDisplayManuallyToolStripMenuItem";
            this.editDisplayManuallyToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editDisplayManuallyToolStripMenuItem.Text = "Edit Display Manually";
            this.editDisplayManuallyToolStripMenuItem.Click += new System.EventHandler(this.EditDisplayManuallyToolStripMenuItem_Click);
            // 
            // loadPresetToolStripMenuItem
            // 
            this.loadPresetToolStripMenuItem.Name = "loadPresetToolStripMenuItem";
            this.loadPresetToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loadPresetToolStripMenuItem.Text = "Load Preset";
            this.loadPresetToolStripMenuItem.Click += new System.EventHandler(this.LoadPresetToolStripMenuItem_Click);
            // 
            // savePresetToolStripMenuItem
            // 
            this.savePresetToolStripMenuItem.Name = "savePresetToolStripMenuItem";
            this.savePresetToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.savePresetToolStripMenuItem.Text = "Save Preset";
            this.savePresetToolStripMenuItem.Click += new System.EventHandler(this.SavePresetToolStripMenuItem_Click);
            // 
            // CtrlDisplayItemText
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CausesValidation = false;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "CtrlDisplayItemText";
            this.Size = new System.Drawing.Size(135, 100);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtrlDisplayItemText_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtrlDisplayItemText_MouseDown);
            this.MouseLeave += new System.EventHandler(this.CtrlDisplayItemText_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlDisplayItemText_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtrlDisplayItemText_MouseUp);
            this.Resize += new System.EventHandler(this.CtrlDisplayItemText_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private bool IsInUse(DatalogDisplayTypes typ)
        {
            foreach (CtrlDisplayItemText item in this.DisplayItems)
            {
                if (typ == item.Type)
                {
                    return true;
                }
            }
            return false;
        }

        private void itm_Click(object sender, EventArgs e)
        {
            this.Type = (DatalogDisplayTypes)((ToolStripMenuItem)sender).Tag;
            this.peakVal = 0.0;
            this.Invalidate();
        }

        private void itm_LED_Click(object sender, EventArgs e)
        {
            this.TypeLED = (DatalogLedTypes)((ToolStripMenuItem)sender).Tag;
            this.Invalidate();
        }

        private void itm_ALL_Click(object sender, EventArgs e)
        {
            this.TypeALL = (SensorsX)((ToolStripMenuItem)sender).Tag;
            //this.SetSensorData();
            this.ResetSensorData();
            this.Invalidate();
        }

        private void itm_BUTTON_Click(object sender, EventArgs e)
        {
            this.TypeBUTTON = (DatalogButtonsTypes)((ToolStripMenuItem)sender).Tag;
            this.SetButtonData();
            this.Invalidate();
        }

        private void menuItmClearPeak_Click(object sender, EventArgs e)
        {
            this.ClearPeak();
        }

        private void menuItmShowPeak_Click(object sender, EventArgs e)
        {
            this.ShowPeak();
        }

        private void moveLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MoveLeftRequest != null)
            {
                this.MoveLeftRequest(this);
            }
        }

        private void moveRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MoveRightRequest != null)
            {
                this.MoveRightRequest(this);
            }
        }

        private void myDatalogger_DatalogFileOpened(long frameMax, string MaxDuration)
        {
            if (!this.class17_0.method_63_HasLogsFileOpen())
            {
                this.Class18_0_RomReload();
            }
        }

        public void myDataloggerUpdateInvoke(Struct12 frm)
        {
            if (!this.Class18_0.class10_settings_0.DatalogThreadEnabled || (this.Class18_0.class10_settings_0.DatalogThreadEnabled && (DateTime.Now - LastCheck).TotalMilliseconds >= this.Class18_0.class10_settings_0.int_ActiveDatalog[3]))
            {
                LastCheck = DateTime.Now;

                if (!this.Class18_0.class10_settings_0.DatalogThreadEnabled || (this.Class18_0.class10_settings_0.DatalogThreadEnabled && this.Class18_0.class10_settings_0.bool_ActiveDatalog[3]))
                {
                    int num2;

                    this.ColorMainText = this.Class18_0.class10_settings_0.color_4;
                    this.ColorSecText = this.Class18_0.class10_settings_0.color_4;
                    this.ColorBack = this.Class18_0.class10_settings_0.color_7;
                    this.ColorNameText = this.Class18_0.class10_settings_0.color_4;

                    //For Led Type only read/refer to sensor corresponding for leds
                    if (DataDisplayType == 1)
                    {
                        InvokeDataLED(frm);
                        goto Label_13B9;
                    }
                    if (DataDisplayType == 4)
                    {
                        InvokeDataALL(frm);
                        goto Label_13B9;
                    }
                    if (DataDisplayType == 5)
                    {
                        InvokeDataBUTTON();
                        goto Label_13B9;
                    }

                    this.DataMain2 = 0;

                    int num = this.Class18_0.method_218((long)frm.ushort_0_E6_7);
                    switch (this.DatalogDisplayTypes_0)
                    {
                        case DatalogDisplayTypes.rpm:
                            this.DataMain2 = this.Class33_Sensors_0.RPM;
                            this.DataMain = this.DataMain2.ToString("0");
                            if (this.Class33_Sensors_0.RPM > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.RPM;
                            }
                            this.DataType = "rpm";
                            if (this.Class18_0.class10_settings_0.bool_24)
                            {
                                this.ColorMainText = this.Class18_0.method_235((double)this.Class18_0.method_218((long)frm.ushort_0_E6_7), (double)this.Class18_0.class10_settings_0.method_20(SensorsX.rpmX), (double)this.Class18_0.class10_settings_0.method_22(SensorsX.rpmX));
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.accelTime:
                            this.editSpeedConditionsToolStripMenuItem.Visible = true;
                            this.DataMain2 = this.Class33_Sensors_0.AccelTime;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = "sec";
                            if (this.Class33_Sensors_0.AccelTime > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.AccelTime;
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.fuelUsage:
                            this.DataMain2 = this.Class33_Sensors_0.FuelUsage;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = "L/100km";
                            if (this.Class33_Sensors_0.FuelUsage > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.FuelUsage;
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.flexFuel:
                            this.DataMain2 = this.Class33_Sensors_0.FlexFuel;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = "sec";
                            if (this.Class33_Sensors_0.FlexFuel > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.FlexFuel;
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.ectV:
                            this.DataMain2 = this.Class33_Sensors_0.ECTV;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = "V";
                            if (this.Class33_Sensors_0.ECTV > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.ECTV;
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.iatV:
                            this.DataMain2 = this.Class33_Sensors_0.IATV;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = "V";
                            if (this.Class33_Sensors_0.IATV > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.IATV;
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.map:
                            num2 = this.Class18_0.method_206(frm.byte_4);
                            if (!this.SecData)
                            {
                                this.DataSec = "";
                                break;
                            }
                            this.DataSec = this.Class33_Sensors_0.MapV.ToString("0.00") + " V";
                            break;

                        case DatalogDisplayTypes.boost:
                            num2 = this.Class18_0.method_206(frm.byte_4);
                            this.DataSec = "";
                            if (num2 <= this.Class18_0.class10_settings_0.int_6)
                            {
                                this.DataMain2 = 0;
                                this.DataMain = "0";
                                this.DataType = this.Class18_0.class10_settings_0.mapSensorUnits_1.ToString();
                            }
                            else
                            {
                                if (this.Class18_0.class10_settings_0.mapSensorUnits_1 != MapSensorUnits.mBar)
                                {
                                    this.DataMain2 = this.Class33_Sensors_0.Boost;
                                    this.DataMain = this.DataMain2.ToString("0.00");
                                    if (frm.byte_4 > this.mapvalue)
                                    {
                                        this.mapvalue = frm.byte_4;
                                        this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 2);
                                    }
                                }
                                else
                                {
                                    this.DataMain2 = this.Class33_Sensors_0.Boost;
                                    this.DataMain = this.DataMain2.ToString("0");
                                    if (frm.byte_4 > this.mapvalue)
                                    {
                                        this.mapvalue = frm.byte_4;
                                        this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 0);
                                    }
                                }
                                this.DataType = this.Class18_0.class10_settings_0.mapSensorUnits_1.ToString();
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.O2:
                            this.DataMain2 = this.Class18_0.method_200(frm.byte_43);
                            this.DataMain = this.DataMain2.ToString("0.00");
                            if (this.peakVal == 0.0)
                            {
                                this.peakVal = Math.Round(this.Class18_0.method_200(frm.byte_2), 2);
                            }
                            if (this.Class18_0.method_200(frm.byte_2) < this.peakVal)
                            {
                                this.peakVal = Math.Round(this.Class18_0.method_200(frm.byte_2), 2);
                            }
                            if (this.SecData)
                            {
                                switch (this.Class18_0.class10_settings_0.wbinput_0)
                                {
                                    case WBinput.o2Input:
                                        this.DataSec = this.Class33_Sensors_0.EcuO2V.ToString("0.00") + " V";
                                        break;

                                    case WBinput.eldInput:
                                        this.DataSec = this.Class33_Sensors_0.ELDV.ToString("0.00") + " V";
                                        break;

                                    case WBinput.egrInput:
                                        this.DataSec = this.Class33_Sensors_0.EGRV.ToString("0.00") + " V";
                                        break;

                                    case WBinput.b6Input:
                                        this.DataMain2 = this.Class33_Sensors_0.B6V;
                                        this.DataMain = this.DataMain2.ToString("0.00") + " V";
                                        break;
                                }
                            }
                            else
                            {
                                this.DataSec = "";
                            }
                            if (this.Class18_0.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                            {
                                this.DataType = "afr";
                            }
                            else
                            {
                                this.DataType = "λ";
                            }
                            this.ColorMainText = this.Class18_0.class10_settings_0.color_4;
                            this.ColorBack = this.Class18_0.method_239(this.Class18_0.method_200(frm.byte_43));
                            goto Label_13B9;

                        case DatalogDisplayTypes.tps:
                            this.DataMain2 = this.Class33_Sensors_0.TPS;
                            this.DataMain = this.DataMain2 + " %";
                            if (this.Class33_Sensors_0.TPS > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.TPS;
                            }
                            if (this.SecData)
                            {
                                this.DataSec = this.Class33_Sensors_0.TPSV.ToString("0.00") + " V";
                            }
                            else
                            {
                                this.DataSec = "";
                            }
                            if (this.Class18_0.class10_settings_0.bool_24)
                            {
                                this.ColorMainText = this.Class18_0.method_235((double)this.Class18_0.method_198(frm.byte_5), (double)this.Class18_0.class10_settings_0.method_20(SensorsX.tpsX), (double)this.Class18_0.class10_settings_0.method_22(SensorsX.tpsX));
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.inj:
                            this.DataMain2 = this.Class33_Sensors_0.InjDuty;
                            this.DataMain = this.DataMain2 + " %";
                            if (this.Class33_Sensors_0.InjDuty > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.InjDuty;
                            }
                            if (this.SecData)
                            {
                                this.DataSec = this.Class33_Sensors_0.InjDurr.ToString("0.00") + " ms";
                            }
                            else
                            {
                                this.DataSec = "";
                            }
                            if (this.Class18_0.class10_settings_0.bool_24)
                            {
                                this.ColorMainText = this.Class18_0.method_235((double)this.Class18_0.method_225(frm.ushort_1_E17_18, num, 0), (double)this.Class18_0.class10_settings_0.method_20(SensorsX.injDuty), (double)this.Class18_0.class10_settings_0.method_22(SensorsX.injDuty));
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.ign:
                            this.DataMain2 = this.Class33_Sensors_0.IgnFinal;
                            this.DataMain = this.DataMain2.ToString("0.00") + " \x00b0";
                            if (!this.SecData)
                            {
                                this.DataSec = "";
                            }
                            else
                            {
                                this.DataSec = "Tbl: " + this.Class33_Sensors_0.IgnTable.ToString("0.00") + " \x00b0";
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.iat:
                            this.DataMain2 = this.Class33_Sensors_0.IAT;
                            this.DataMain = this.DataMain2.ToString("0");
                            if (this.Class33_Sensors_0.IAT > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.IAT;
                            }
                            this.DataType = "\x00b0" + this.Class18_0.class10_settings_0.temperatureUnits_0.ToString();
                            if (this.Class18_0.class10_settings_0.bool_24)
                            {
                                this.ColorMainText = this.Class18_0.method_235(this.Class18_0.method_191(frm.byte_1), (double)this.Class18_0.class10_settings_0.method_20(SensorsX.iatX), (double)this.Class18_0.class10_settings_0.method_22(SensorsX.iatX));
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.ect:
                            this.DataMain2 = this.Class33_Sensors_0.ECT;
                            this.DataMain = this.DataMain2.ToString("0");
                            if (this.Class33_Sensors_0.ECT > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.ECT;
                            }
                            this.DataType = "\x00b0" + this.Class18_0.class10_settings_0.temperatureUnits_0.ToString();
                            if (this.Class18_0.class10_settings_0.bool_24)
                            {
                                this.ColorMainText = this.Class18_0.method_235(this.Class18_0.method_191(frm.byte_0), (double)this.Class18_0.class10_settings_0.method_20(SensorsX.ectX), (double)this.Class18_0.class10_settings_0.method_22(SensorsX.ectX));
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.bat:
                            this.DataMain2 = this.Class33_Sensors_0.BatV;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = "V";
                            if (this.peakVal == 0.0)
                            {
                                this.peakVal = 15.0;
                            }
                            if (this.Class33_Sensors_0.BatV < this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.BatV;
                            }
                            if (this.Class18_0.class10_settings_0.bool_24)
                            {
                                this.ColorMainText = this.Class18_0.method_235(this.Class18_0.method_208(frm.byte_27_E25), (double)this.Class18_0.class10_settings_0.method_20(SensorsX.batV), (double)this.Class18_0.class10_settings_0.method_22(SensorsX.batV));
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.bstctrl:
                            this.DataMain2 = this.Class33_Sensors_0.EBCDuty;
                            this.DataMain = this.DataMain2.ToString("0.0") + "%";
                            if (this.Class33_Sensors_0.EBCDuty > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.EBCDuty;
                            }
                            this.DataType = "";
                            if ((this.Class33_Sensors_0.EBCTarget <= this.Class18_0.class10_settings_0.int_6) || !this.SecData)
                            {
                                if ((this.Class33_Sensors_0.EBCTarget <= this.Class18_0.class10_settings_0.int_6) && this.SecData)
                                {
                                    if (this.Class18_0.class10_settings_0.mapSensorUnits_0 != MapSensorUnits.mBar)
                                    {
                                        this.DataSec = "T: " + this.Class33_Sensors_0.EBCTarget.ToString("0.0");
                                    }
                                    else
                                    {
                                        this.DataSec = "T: " + this.Class33_Sensors_0.EBCTarget.ToString("0");
                                    }
                                    this.DataSec = this.DataSec + " " + this.Class18_0.class10_settings_0.mapSensorUnits_0.ToString();
                                }
                                else
                                {
                                    this.DataSec = "";
                                }
                            }
                            else
                            {
                                if (this.Class18_0.class10_settings_0.mapSensorUnits_0 != MapSensorUnits.mBar)
                                {
                                    this.DataSec = "T: " + this.Class33_Sensors_0.EBCTarget.ToString("0.0");
                                }
                                else
                                {
                                    this.DataSec = "T: " + this.Class33_Sensors_0.EBCTarget.ToString("0");
                                }
                                this.DataSec = this.DataSec + " " + this.Class18_0.class10_settings_0.mapSensorUnits_1.ToString();
                            }
                            if (this.Class18_0.class10_settings_0.bool_24)
                            {
                                this.ColorMainText = this.Class18_0.method_235(this.Class18_0.method_207(frm.byte_38_E41), (double)this.Class18_0.class10_settings_0.method_20(SensorsX.ebcDutyX), (double)this.Class18_0.class10_settings_0.method_22(SensorsX.ebcDutyX));
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.vss:
                            this.DataMain2 = this.Class33_Sensors_0.VSS;
                            this.DataMain = this.DataMain2.ToString("0");
                            if (this.Class33_Sensors_0.VSS > this.peakVal)
                            {
                                this.peakVal = this.Class33_Sensors_0.VSS;
                            }
                            this.DataType = this.Class18_0.class10_settings_0.vssUnits_0.ToString();
                            if (this.SecData)
                            {
                                this.DataSec = "G: " + this.Class33_Sensors_0.Gear.ToString();
                            }
                            else
                            {
                                this.DataSec = "";
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.gear:
                            this.DataMain2 = this.Class33_Sensors_0.Gear;
                            this.DataMain = this.DataMain2.ToString("0");
                            goto Label_13B9;

                        case DatalogDisplayTypes.o2Trim:
                            this.DataMain2 = this.Class33_Sensors_0.O2Short;
                            if (this.Class18_0.class10_settings_0.correctionUnits_0 != CorrectionUnits.percentage)
                            {
                                this.DataMain = this.DataMain2.ToString("0.00");
                            }
                            else
                            {
                                this.DataMain = this.DataMain2.ToString();
                            }
                            if (this.Class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
                            {
                                this.DataType = "M";
                            }
                            else
                            {
                                this.DataType = "%";
                            }
                            if (this.SecData)
                            {
                                if (this.Class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.percentage)
                                {
                                    this.DataSec = "LT: " + this.Class33_Sensors_0.O2Long.ToString("0");
                                }
                                else
                                {
                                    this.DataSec = "LT: " + this.Class33_Sensors_0.O2Long.ToString("0.00");
                                }
                            }
                            else
                            {
                                this.DataSec = "";
                            }
                            goto Label_13B9;

                        case DatalogDisplayTypes.analog1:
                            if (this.Class33_Sensors_0.Analog1 > this.peakVal) this.peakVal = this.Class33_Sensors_0.Analog1;
                            this.DataMain2 = this.Class33_Sensors_0.Analog1;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = this.Class18_0.class10_settings_0.string_4;
                            goto Label_13B9;

                        case DatalogDisplayTypes.analog2:
                            if (this.Class33_Sensors_0.Analog2 > this.peakVal) this.peakVal = this.Class33_Sensors_0.Analog2;
                            this.DataMain2 = this.Class33_Sensors_0.Analog2;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataType = this.Class18_0.class10_settings_0.string_5;
                            goto Label_13B9;

                        case DatalogDisplayTypes.analog3:
                            if (this.Class33_Sensors_0.Analog3 > this.peakVal) this.peakVal = this.Class33_Sensors_0.Analog3;
                            this.DataMain2 = this.Class33_Sensors_0.Analog3;
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.DataMain = this.Class18_0.method_201(AnalogInputs.analog3, frm.byte_42).ToString();
                            this.DataType = this.Class18_0.class10_settings_0.string_6;
                            goto Label_13B9;

                        default:
                            goto Label_13B9;
                    }
                    if (frm.byte_4 > this.mapvalue)
                    {
                        this.mapvalue = frm.byte_4;
                    }
                    this.DataMain2 = this.Class18_0.method_193(frm.byte_4);
                    if (num2 > this.Class18_0.class10_settings_0.int_6)
                    {
                        if (this.Class18_0.class10_settings_0.mapSensorUnits_1 == MapSensorUnits.mBar)
                        {
                            this.DataMain = this.DataMain2.ToString("0");
                            this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 0);
                        }
                        else
                        {
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 2);
                        }
                        this.DataType = this.Class18_0.class10_settings_0.mapSensorUnits_1.ToString();
                    }
                    else
                    {
                        if (this.Class18_0.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.mBar)
                        {
                            this.DataMain = this.DataMain2.ToString("0");
                            this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 0);
                        }
                        else
                        {
                            this.DataMain = this.DataMain2.ToString("0.00");
                            this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 2);
                        }
                        this.DataType = this.Class18_0.class10_settings_0.mapSensorUnits_0.ToString();
                    }
                Label_13B9:
                    this.Invalidate();
                    //return;
                    /*if (this.Class18_0.class10_0.dtPeakShown)
                    {
                        this.lblPeak.Text = this.peakVal.ToString();
                        this.lblPeak.Refresh();
                    }*/
                }
            }
        }

        private void InvokeDataLED(Struct12 frm)
        {
            switch (this.DatalogLedTypes_0)
            {
                case DatalogLedTypes.nEw:
                    break;

                case DatalogLedTypes.secMaps:
                    this.IsLEDActivated = this.Class33_Sensors_0.SecMap;
                    return;

                case DatalogLedTypes.Fuelcut:
                        this.IsLEDActivated = this.Class33_Sensors_0.OutFCut;
                        return;

                case DatalogLedTypes.IgnCut:
                    this.IsLEDActivated = this.Class33_Sensors_0.ICut;
                    return;

                case DatalogLedTypes.FuelPump:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutFPump;
                    return;

                case DatalogLedTypes.VtsMaps:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutVTSM;
                    return;

                case DatalogLedTypes.Vtec:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutVTS;
                    return;

                case DatalogLedTypes.PostFuel:
                    this.IsLEDActivated = this.Class33_Sensors_0.PostFuel;
                    return;

                case DatalogLedTypes.Mil:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutMIL;
                    return;

                case DatalogLedTypes.BoostCut:
                    this.IsLEDActivated = this.Class33_Sensors_0.ActiveBstCut;
                    return;

                case DatalogLedTypes.Overheat:
                    this.IsLEDActivated = this.Class33_Sensors_0.ActiveOverHeat;
                    return;

                case DatalogLedTypes.LeanProtect:
                    this.IsLEDActivated = this.Class33_Sensors_0.LeanProtect;
                    return;

                case DatalogLedTypes.FanControl:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutFanC;
                    return;

                case DatalogLedTypes.FltInput:
                    this.IsLEDActivated = this.Class33_Sensors_0.InFTL;
                    return;

                case DatalogLedTypes.FtlActive:
                    this.IsLEDActivated = this.Class33_Sensors_0.ActiveFTL;
                    return;

                case DatalogLedTypes.AntiLag:
                    this.IsLEDActivated = this.Class33_Sensors_0.ActiveAntilag;
                    return;

                case DatalogLedTypes.FtsInput:
                    this.IsLEDActivated = this.Class33_Sensors_0.InFTS;
                    return;

                case DatalogLedTypes.FtsActive:
                    this.IsLEDActivated = this.Class33_Sensors_0.ActiveFTS;
                    return;

                case DatalogLedTypes.EbcActive:
                    this.IsLEDActivated = this.Class33_Sensors_0.ActiveEBC;
                    return;

                case DatalogLedTypes.EbcHi:
                    this.IsLEDActivated = this.Class33_Sensors_0.InEBCHi;
                    return;

                case DatalogLedTypes.EbcInput:
                    this.IsLEDActivated = this.Class33_Sensors_0.InEBC;
                    return;

                case DatalogLedTypes.GPO1Input:
                    this.IsLEDActivated = this.Class33_Sensors_0.InGPO1;
                    return;

                case DatalogLedTypes.GPO2Input:
                    this.IsLEDActivated = this.Class33_Sensors_0.InGPO2;
                    return;

                case DatalogLedTypes.GPO3Input:
                    this.IsLEDActivated = this.Class33_Sensors_0.InGPO3;
                    return;

                case DatalogLedTypes.GPO1Output:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutGPO1;
                    return;

                case DatalogLedTypes.GPO2Output:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutGPO2;
                    return;

                case DatalogLedTypes.GPO3Output:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutGPO3;
                    return;

                case DatalogLedTypes.BSTS2:
                    this.IsLEDActivated = this.Class33_Sensors_0.BSTS2;
                    return;

                case DatalogLedTypes.BSTS3:
                    this.IsLEDActivated = this.Class33_Sensors_0.BSTS3;
                    return;

                case DatalogLedTypes.BSTS4:
                    this.IsLEDActivated = this.Class33_Sensors_0.BSTS4;
                    return;

                case DatalogLedTypes.BSTInput:
                    this.IsLEDActivated = this.Class33_Sensors_0.InBST;
                    return;

                case DatalogLedTypes.BSTActive:
                    this.IsLEDActivated = this.Class33_Sensors_0.ActiveBST;
                    return;

                case DatalogLedTypes.outIab:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutIAB;
                    return;

                case DatalogLedTypes.outAc:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutAC;
                    return;

                case DatalogLedTypes.outO2h:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutO2H;
                    return;

                case DatalogLedTypes.outPurge:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutPurge;
                    return;

                case DatalogLedTypes.outAltCtrl:
                    this.IsLEDActivated = this.Class33_Sensors_0.OutAltCtrl;
                    return;

                case DatalogLedTypes.inPsp:
                    this.IsLEDActivated = this.Class33_Sensors_0.InPSP;
                    return;

                case DatalogLedTypes.inSCC:
                    this.IsLEDActivated = this.Class33_Sensors_0.InSCC;
                    return;

                case DatalogLedTypes.inAccs:
                    this.IsLEDActivated = this.Class33_Sensors_0.InACCs;
                    return;

                case DatalogLedTypes.inBksw:
                    this.IsLEDActivated = this.Class33_Sensors_0.InBKSW;
                    return;

                case DatalogLedTypes.inVtp:
                    this.IsLEDActivated = this.Class33_Sensors_0.InVTP;
                    return;

                case DatalogLedTypes.inVtsFeedBack:
                    this.IsLEDActivated = this.Class33_Sensors_0.InVTSFB;
                    return;

                case DatalogLedTypes.inParkN:
                    this.IsLEDActivated = this.Class33_Sensors_0.InParkN;
                    return;

                case DatalogLedTypes.inStartS:
                    this.IsLEDActivated = this.Class33_Sensors_0.InStartS;
                    return;

                case DatalogLedTypes.inAtShift1:
                    this.IsLEDActivated = this.Class33_Sensors_0.InATShift1;
                    return;

                case DatalogLedTypes.inAtShift2:
                    this.IsLEDActivated = this.Class33_Sensors_0.InATShift2;
                    return;

                default:
                    return;
            }
        }

        //######################################################
        //######################################################
        //######################################################

        private void InvokeDataALL(Struct12 frm)
        {
            SetSensorData(frm);
        }

        public void SetSensorData(Struct12 frm)
        {
            this.DataMain = this.Class33_Sensors_0.GetSensors_STRING(this.SensorsX_0);
            //this.DataMain = this.class18_Sensors.GetSensors_STRING(this.myTypeALL, frm);
            this.SensorName = this.Class18_0.class10_settings_0.method_13(this.SensorsX_0);

            if (this.Class18_0.class10_settings_0.bool_24) this.ColorMainText = this.Class33_Sensors_0.GetSensorColor(this.SensorsX_0);
            //if (this.Class18_0.class10_0.bool_24) this.ColorMainText = this.class18_Sensors.GetSensorColor(this.myTypeALL, frm);
            else this.ColorMainText = this.Class18_0.class10_settings_0.color_4;

            if (this.ColorMainText == this.Class18_0.class10_settings_0.color_4) this.ColorBack = this.Class18_0.class10_settings_0.color_7;
            else this.ColorBack = this.ColorMainText;
        }

        public void ResetSensorData()
        {
            this.DataMain = "";
            this.SensorName = this.Class18_0.class10_settings_0.method_13(this.SensorsX_0);

            this.ColorMainText = this.Class18_0.class10_settings_0.color_4;
            this.ColorBack = this.Class18_0.class10_settings_0.color_7;
        }

        //######################################################

        private void InvokeDataBUTTON()
        {
            SetButtonData();
        }

        public void SetButtonData()
        {
            //this.IsLEDActivated = this.FrmMain_0.GetButtonEnabled((int)this.TypeBUTTON);
        }

        public void Refresh_EnableButton(bool Enabled)
        {
            this.IsLEDActivated = Enabled;
            this.Invalidate();
        }

        //######################################################
        //######################################################
        //######################################################

        private void myDataloggerUpdateInvokePeak(Struct12 frm)
        {
            if (DataDisplayType != 1 && DataDisplayType != 4)
            {
                int num2;
                int num = this.Class18_0.method_218((long)frm.ushort_0_E6_7);
                switch (this.DatalogDisplayTypes_0)
                {
                    case DatalogDisplayTypes.rpm:
                        if (this.Class18_0.method_218((long)frm.ushort_0_E6_7) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = Math.Round((double)this.Class18_0.method_218((long)frm.ushort_0_E6_7), 0);
                        return;

                    case DatalogDisplayTypes.accelTime:
                        if (this.Class18_0.AccelTime(this.Class18_0.method_197(frm.byte_14_E16)) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = this.Class18_0.AccelTime(this.Class18_0.method_197(frm.byte_14_E16));
                        return;

                    case DatalogDisplayTypes.fuelUsage:
                        int Speed = frm.byte_14_E16;
                        int RPM = this.Class18_0.method_218((long)frm.ushort_0_E6_7);
                        if (this.Class18_0.GetInstantConsumption(Speed, RPM, frm.ushort_1_E17_18) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = this.Class18_0.GetInstantConsumption(Speed, RPM, frm.ushort_1_E17_18);
                        return;

                    case DatalogDisplayTypes.flexFuel:
                        double FFValue = (this.Class18_0.method_196(this.Class33_Sensors_0.GetFlexFuelByte(frm)) * 100.0) / 5.0;
                        if (FFValue <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = FFValue;
                        return;

                    case DatalogDisplayTypes.map:
                        num2 = this.Class18_0.method_206(frm.byte_4);
                        if (frm.byte_4 > this.mapvalue)
                        {
                            this.mapvalue = frm.byte_4;
                        }
                        this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 0);
                        return;

                    case DatalogDisplayTypes.boost:
                        num2 = this.Class18_0.method_206(frm.byte_4);
                        this.DataSec = "";
                        if ((num2 > this.Class18_0.class10_settings_0.int_6) && (frm.byte_4 > this.mapvalue))
                        {
                            this.mapvalue = frm.byte_4;
                        }
                        this.peakVal = Math.Round((double)this.Class18_0.method_193(this.mapvalue), 2);
                        return;

                    case DatalogDisplayTypes.O2:
                        if (this.peakVal == 0.0)
                        {
                            this.peakVal = Math.Round(this.Class18_0.method_200(frm.byte_2), 2);
                        }
                        if (this.Class18_0.method_200(frm.byte_2) >= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = Math.Round(this.Class18_0.method_200(frm.byte_2), 2);
                        return;

                    case DatalogDisplayTypes.tps:
                        if (this.Class18_0.method_198(frm.byte_5) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = Math.Round((double)this.Class18_0.method_198(frm.byte_5), 0);
                        return;

                    case DatalogDisplayTypes.inj:
                        if (this.Class18_0.method_225(frm.ushort_1_E17_18, num, 0) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = Math.Round((double)this.Class18_0.method_225(frm.ushort_1_E17_18, num, 0), 0);
                        return;

                    case DatalogDisplayTypes.ign:
                    case DatalogDisplayTypes.gear:
                    case DatalogDisplayTypes.o2Trim:
                        break;

                    case DatalogDisplayTypes.iat:
                        if (this.Class18_0.method_191(frm.byte_1) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = Math.Round(this.Class18_0.method_191(frm.byte_1), 0);
                        return;

                    case DatalogDisplayTypes.ect:
                        if (this.Class18_0.method_191(frm.byte_0) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = Math.Round(this.Class18_0.method_191(frm.byte_0), 0);
                        return;

                    case DatalogDisplayTypes.bat:
                        if (this.peakVal == 0.0)
                        {
                            this.peakVal = 15.0;
                        }
                        if (this.Class18_0.method_208(frm.byte_27_E25) < this.peakVal)
                        {
                            this.peakVal = this.Class18_0.method_208(frm.byte_27_E25);
                        }
                        break;

                    case DatalogDisplayTypes.bstctrl:
                        if (this.Class18_0.method_207(frm.byte_38_E41) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = Math.Round(this.Class18_0.method_207(frm.byte_38_E41), 1);
                        return;

                    case DatalogDisplayTypes.vss:
                        if (this.Class18_0.method_197(frm.byte_14_E16) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = this.Class18_0.method_197(frm.byte_14_E16);
                        return;

                    case DatalogDisplayTypes.analog1:
                        if (this.Class18_0.method_201(AnalogInputs.analog1, frm.byte_40) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = this.Class18_0.method_201(AnalogInputs.analog1, frm.byte_40);
                        return;

                    case DatalogDisplayTypes.analog2:
                        if (this.Class18_0.method_201(AnalogInputs.analog2, frm.byte_41) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = this.Class18_0.method_201(AnalogInputs.analog2, frm.byte_41);
                        return;

                    case DatalogDisplayTypes.analog3:
                        if (this.Class18_0.method_201(AnalogInputs.analog3, frm.byte_42) <= this.peakVal)
                        {
                            break;
                        }
                        this.peakVal = this.Class18_0.method_201(AnalogInputs.analog3, frm.byte_42);
                        return;

                    default:
                        return;
                }
            }
        }

        private void Class18_0_RomReload()
        {
            this.DataSec = "";
            this.DataMain = "";
            this.DataType = "";
            this.ColorMainText = this.Class18_0.class10_settings_0.color_4;
            this.ColorSecText = this.Class18_0.class10_settings_0.color_4;
            this.ColorBack = this.Class18_0.class10_settings_0.color_7;
            this.ColorNameText = this.Class18_0.class10_settings_0.color_4;
            this.IsLEDActivated = false;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.RemoveRequest != null)
            {
                this.RemoveRequest(this);
            }
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DefaultsRequest != null)
            {
                this.DefaultsRequest(this);
            }
        }

        public void ShowPeak()
        {
            foreach (CtrlDisplayItemText item in this.DisplayItems)
            {
                if (item._DataDisplayType == 0 || item._DataDisplayType == 2 || item._DataDisplayType == 3)
                {
                    item.Invalidate();
                }
            }
            this.Class18_0.class10_settings_0.dtPeakShown = !this.Class18_0.class10_settings_0.dtPeakShown;
        }

        private void showSecondaryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SecData = this.menuItemShowSecondaryData.Checked;
        }

        private void WarningColorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.Class18_0.class10_settings_0.bool_24 = this.menuItemWarningColor.Checked;
        }

        private bool hasPeak
        {
            get
            {
                switch (this.Type)
                {
                    case DatalogDisplayTypes.nEw:
                    case DatalogDisplayTypes.O2:
                    case DatalogDisplayTypes.ign:
                    case DatalogDisplayTypes.gear:
                    case DatalogDisplayTypes.o2Trim:
                        return false;

                    case DatalogDisplayTypes.rpm:
                        return true;

                    case DatalogDisplayTypes.map:
                        return true;

                    case DatalogDisplayTypes.boost:
                        return true;

                    case DatalogDisplayTypes.tps:
                        return true;

                    case DatalogDisplayTypes.inj:
                        return true;

                    case DatalogDisplayTypes.iat:
                        return true;

                    case DatalogDisplayTypes.ect:
                        return true;

                    case DatalogDisplayTypes.bat:
                        return true;

                    case DatalogDisplayTypes.bstctrl:
                        return true;

                    case DatalogDisplayTypes.vss:
                        return true;

                    case DatalogDisplayTypes.analog1:
                        return true;

                    case DatalogDisplayTypes.analog2:
                        return true;

                    case DatalogDisplayTypes.analog3:
                        return true;

                    case DatalogDisplayTypes.fuelUsage:
                        return true;

                    case DatalogDisplayTypes.flexFuel:
                        return true;

                    case DatalogDisplayTypes.accelTime:
                        return true;

                    case DatalogDisplayTypes.ectV:
                        return true;

                    case DatalogDisplayTypes.iatV:
                        return true;
                }
                return false;
            }
        }

        private bool hasSecData
        {
            get
            {
                bool flag = false;
                switch (this.Type)
                {
                    case DatalogDisplayTypes.nEw:
                    case DatalogDisplayTypes.rpm:
                    case DatalogDisplayTypes.boost:
                    case DatalogDisplayTypes.iat:
                    case DatalogDisplayTypes.ect:
                    case DatalogDisplayTypes.bat:
                    case DatalogDisplayTypes.gear:
                    case DatalogDisplayTypes.accelTime:
                    case DatalogDisplayTypes.fuelUsage:
                    case DatalogDisplayTypes.flexFuel:
                    case DatalogDisplayTypes.ectV:
                    case DatalogDisplayTypes.iatV:
                    case DatalogDisplayTypes.analog1:
                    case DatalogDisplayTypes.analog2:
                    case DatalogDisplayTypes.analog3:
                        return flag;

                    case DatalogDisplayTypes.map:
                        return true;

                    case DatalogDisplayTypes.O2:
                        return true;

                    case DatalogDisplayTypes.tps:
                        return true;

                    case DatalogDisplayTypes.inj:
                        return true;

                    case DatalogDisplayTypes.ign:
                        return true;

                    case DatalogDisplayTypes.bstctrl:
                        return true;

                    case DatalogDisplayTypes.vss:
                        return true;

                    case DatalogDisplayTypes.o2Trim:
                        return true;
                }
                return flag;
            }
        }

        [DefaultValue(typeof(int), "true"), Category("Display"), Description("Data Display")]
        public int DataDisplayType
        {
            get
            {
                return this._DataDisplayType;
            }
            set
            {
                this._DataDisplayType = value;
                if (value == 0)
                {
                    //this.menuItemSetTypeDisplay.Text = "Set As Led Display";
                    this.setAsDataDisplayToolStripMenuItem.Enabled = false;
                    this.menuItemSetTypeDisplay.Enabled = true;
                    this.setAsBarsGraphToolStripMenuItem.Enabled = true;
                    this.setAsGaugeToolStripMenuItem.Enabled = true;
                    this.setAsSensorToolStripMenuItem.Enabled = true;
                }
                else if(value == 1)
                {
                    //this.menuItemSetTypeDisplay.Text = "Set As Data Display";
                    this.setAsDataDisplayToolStripMenuItem.Enabled = true;
                    this.menuItemSetTypeDisplay.Enabled = false;
                    this.setAsBarsGraphToolStripMenuItem.Enabled = true;
                    this.setAsGaugeToolStripMenuItem.Enabled = true;
                    this.setAsSensorToolStripMenuItem.Enabled = true;
                }
                else if (value == 2)
                {
                    this.setAsDataDisplayToolStripMenuItem.Enabled = true;
                    this.menuItemSetTypeDisplay.Enabled = true;
                    this.setAsBarsGraphToolStripMenuItem.Enabled = false;
                    this.setAsGaugeToolStripMenuItem.Enabled = true;
                    this.setAsSensorToolStripMenuItem.Enabled = true;
                }
                else if (value == 3)
                {
                    this.setAsDataDisplayToolStripMenuItem.Enabled = true;
                    this.menuItemSetTypeDisplay.Enabled = true;
                    this.setAsBarsGraphToolStripMenuItem.Enabled = true;
                    this.setAsGaugeToolStripMenuItem.Enabled = false;
                    this.setAsSensorToolStripMenuItem.Enabled = true;
                }
                else if (value == 4)
                {
                    this.setAsDataDisplayToolStripMenuItem.Enabled = true;
                    this.menuItemSetTypeDisplay.Enabled = true;
                    this.setAsBarsGraphToolStripMenuItem.Enabled = true;
                    this.setAsGaugeToolStripMenuItem.Enabled = true;
                    this.setAsSensorToolStripMenuItem.Enabled = false;
                }
                this.Invalidate(true);
            }
        }

        [Category("Display"), DefaultValue(typeof(bool), "true"), Description("Secondary Data")]
        public bool SecData
        {
            get
            {
                return this._SecData;
            }
            set
            {
                this._SecData = value;
                this.Invalidate(true);
            }
        }

        [Category("Display"), DefaultValue(typeof(bool), "true"), Description("Vertical Text")]
        public bool IsTextVertical
        {
            get
            {
                return this._IsTextVertical;
            }
            set
            {
                this._IsTextVertical = value;
                this.Invalidate(true);
            }
        }

        [DefaultValue(typeof(DatalogDisplayTypes), ""), Description("Type"), Category("Display")]
        public DatalogDisplayTypes Type
        {
            get
            {
                return this.DatalogDisplayTypes_0;
            }
            set
            {
                this.Class18_0_RomReload();
                this.DatalogDisplayTypes_0 = value;
                if (value != DatalogDisplayTypes.analog1 && value != DatalogDisplayTypes.analog2 && value != DatalogDisplayTypes.analog3) this.SensorName = this.DatalogDisplayTypes_0.ToString().ToUpper();
                else
                {
                    if (value == DatalogDisplayTypes.analog1) this.SensorName = "ANLG1";
                    if (value == DatalogDisplayTypes.analog2) this.SensorName = "ANLG2";
                    if (value == DatalogDisplayTypes.analog3) this.SensorName = "ANLG3";
                }
                this.Invalidate(true);
            }
        }

        [DefaultValue(typeof(SensorsX), ""), Description("Type"), Category("Display")]
        public SensorsX TypeALL
        {
            get
            {
                return this.SensorsX_0;
            }
            set
            {
                this.Class18_0_RomReload();
                this.SensorsX_0 = value;
                if (value != SensorsX.analog1 && value != SensorsX.analog2 && value != SensorsX.analog3 && value != SensorsX.accelTime && value != SensorsX.flexFuel) this.SensorName = this.Class18_0.class10_settings_0.method_13(this.SensorsX_0);
                else
                {
                    if (value == SensorsX.analog1) this.SensorName = "ANLG1";
                    if (value == SensorsX.analog2) this.SensorName = "ANLG2";
                    if (value == SensorsX.analog3) this.SensorName = "ANLG3";

                    if (value == SensorsX.accelTime) this.SensorName = "A-TIME";
                    if (value == SensorsX.flexFuel) this.SensorName = "F-FUEL";
                }
                this.Invalidate(true);
            }
        }

        [DefaultValue(typeof(DatalogButtonsTypes), ""), Description("Type"), Category("Display")]
        public DatalogButtonsTypes TypeBUTTON
        {
            get
            {
                return this.DatalogButtonsTypes_0;
            }
            set
            {
                this.Class18_0_RomReload();
                this.DatalogButtonsTypes_0 = value;
                this.SensorName = this.DatalogButtonsTypes_0.ToString().Replace("_", " ");
                this.Invalidate(true);
            }
        }

        [Description("Type"), DefaultValue(typeof(DatalogLedTypes), ""), Category("Display")]
        public DatalogLedTypes TypeLED
        {
            get
            {
                return this.DatalogLedTypes_0;
            }
            set
            {
                string str;
                this.Class18_0_RomReload();
                this.DatalogLedTypes_0 = value;
                switch (this.DatalogLedTypes_0)
                {
                    case DatalogLedTypes.nEw:
                        str = "undef";
                        break;

                    case DatalogLedTypes.secMaps:
                        str = "SecM";
                        break;

                    case DatalogLedTypes.Fuelcut:
                        str = "FCut";
                        break;

                    case DatalogLedTypes.IgnCut:
                        str = "ICut";
                        break;

                    case DatalogLedTypes.FuelPump:
                        str = "FuelP";
                        break;

                    case DatalogLedTypes.VtsMaps:
                        str = "VTSM";
                        break;

                    case DatalogLedTypes.Vtec:
                        str = "VTS";
                        break;

                    case DatalogLedTypes.PostFuel:
                        str = "PostFl";
                        break;

                    case DatalogLedTypes.Mil:
                        str = "MIL";
                        break;

                    case DatalogLedTypes.BoostCut:
                        str = "BstCut";
                        break;

                    case DatalogLedTypes.Overheat:
                        str = "OvrH";
                        break;

                    case DatalogLedTypes.LeanProtect:
                        str = "LeanP";
                        break;

                    case DatalogLedTypes.FanControl:
                        str = "FanC";
                        break;

                    case DatalogLedTypes.FltInput:
                        str = "FtlIn";
                        break;

                    case DatalogLedTypes.FtlActive:
                        str = "FTL";
                        break;

                    case DatalogLedTypes.AntiLag:
                        str = "AntiL";
                        break;

                    case DatalogLedTypes.FtsInput:
                        str = "FtsIn";
                        break;

                    case DatalogLedTypes.FtsActive:
                        str = "FTS";
                        break;

                    case DatalogLedTypes.EbcActive:
                        str = "EBC";
                        break;

                    case DatalogLedTypes.EbcHi:
                        str = "EbcHi";
                        break;

                    case DatalogLedTypes.EbcInput:
                        str = "EbcIn";
                        break;

                    case DatalogLedTypes.GPO1Input:
                        str = "GPO1I";
                        break;

                    case DatalogLedTypes.GPO2Input:
                        str = "GPO2I";
                        break;

                    case DatalogLedTypes.GPO3Input:
                        str = "GPO3I";
                        break;

                    case DatalogLedTypes.GPO1Output:
                        str = "GPO1O";
                        break;

                    case DatalogLedTypes.GPO2Output:
                        str = "GPO2O";
                        break;

                    case DatalogLedTypes.GPO3Output:
                        str = "GPO3O";
                        break;

                    case DatalogLedTypes.BSTS2:
                        str = "BST2";
                        break;

                    case DatalogLedTypes.BSTS3:
                        str = "BST3";
                        break;

                    case DatalogLedTypes.BSTS4:
                        str = "BST4";
                        break;

                    case DatalogLedTypes.BSTInput:
                        str = "BSTIn";
                        break;

                    case DatalogLedTypes.BSTActive:
                        str = "BST";
                        break;

                    case DatalogLedTypes.outIab:
                        str = "IAB";
                        break;

                    case DatalogLedTypes.outAc:
                        str = "AC";
                        break;

                    case DatalogLedTypes.outO2h:
                        str = "O2H";
                        break;

                    case DatalogLedTypes.outPurge:
                        str = "Purge";
                        break;

                    case DatalogLedTypes.outAltCtrl:
                        str = "Alt";
                        break;

                    case DatalogLedTypes.inPsp:
                        str = "PSP";
                        break;

                    case DatalogLedTypes.inSCC:
                        str = "SCC";
                        break;

                    case DatalogLedTypes.inAccs:
                        str = "ACCS";
                        break;

                    case DatalogLedTypes.inBksw:
                        str = "BKSW";
                        break;

                    case DatalogLedTypes.inVtp:
                        str = "VTP";
                        break;

                    case DatalogLedTypes.inVtsFeedBack:
                        str = "VTSFB";
                        break;

                    case DatalogLedTypes.inParkN:
                        str = "PARK";
                        break;

                    case DatalogLedTypes.inStartS:
                        str = "STS";
                        break;

                    case DatalogLedTypes.inAtShift1:
                        str = "ATS1";
                        break;

                    case DatalogLedTypes.inAtShift2:
                        str = "ATS2";
                        break;


                    default:
                        str = "undef";
                        break;
                }
                this.SensorName = str;
                this.Invalidate(true);
            }
        }

        private delegate void Delegate15(Struct12 struct12_0);
        public delegate void Delegate16(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void Delegate17(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void Delegate18(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void Delegate19(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void Delegate20(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void Delegate21(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void DelegateGraph(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void DelegateGauge(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void DelegateSensor(CtrlDisplayItemText CtrlDisplayItemText_0);
        public delegate void DelegateButton(CtrlDisplayItemText CtrlDisplayItemText_0);

        private void editWarningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FrmMain_0.SensorWarning_Click(sender, e);
        }

        private void editSpeedConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.frmAccelTimeSetting_0 != null)
            {
                this.frmAccelTimeSetting_0.Dispose();
                this.frmAccelTimeSetting_0 = null;
            }
            this.frmAccelTimeSetting_0 = new frmAccelTimeSetting();
            this.frmAccelTimeSetting_0.method_0(ref this.Class18_0);
            this.frmAccelTimeSetting_0.ShowDialog();
            this.frmAccelTimeSetting_0.Dispose();
            this.frmAccelTimeSetting_0 = null;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            try
            {
                //Gauge1_Radial.Visible = false;

                float FontS = (base.ClientRectangle.Width + base.ClientRectangle.Width) / 10f;
                Font font = new Font("Trebuchet MS", (FontS / 1.75f), FontStyle.Regular);
                Font fontSmall = new Font("Trebuchet MS", (FontS / 2.4f), FontStyle.Bold);
                Font fontB = new Font("Lucida Sans", FontS, FontStyle.Bold);
                Brush brushTxtColor = new SolidBrush(ColorNameText);
                //Brush brushBackColor = new SolidBrush(this.Class18_0.class10_0.color_7);
                Brush brushBackColor = new SolidBrush(ColorBack);
                Brush brushRed = new SolidBrush(this.Class18_0.class10_settings_0.color_Off);
                Brush brushBlack = new SolidBrush(Color.Black);
                Pen penBlack = new Pen(Color.Black);
                StringFormat formatVertical = new StringFormat();
                if (IsTextVertical) formatVertical = new StringFormat(StringFormatFlags.DirectionVertical);
                int XMid = (base.ClientRectangle.Width / 2);
                int YMid = (base.ClientRectangle.Height / 2);

                //if (this.graphics_0 != null) this.graphics_0.Dispose();

                this.graphics_0 = pe.Graphics;
                //this.graphics_0.SmoothingMode = SmoothingMode.None;
                this.graphics_0.FillRectangle(brushBackColor, base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width, base.ClientRectangle.Height);
                this.graphics_0.DrawRectangle(penBlack, base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);

                //Sensors Infos (Displays)
                if (DataDisplayType == 0)
                {
                    brushTxtColor = new SolidBrush(ColorNameText);
                    this.graphics_0.DrawString(this.SensorName, font, brushTxtColor, 1, 1);
                    brushTxtColor = new SolidBrush(ColorSecText);
                    this.graphics_0.DrawString(this.DataType, font, brushTxtColor, base.ClientRectangle.Right - graphics_0.MeasureString(this.DataType, font).Width - 1, 1);
                    brushTxtColor = new SolidBrush(ColorMainText);
                    this.graphics_0.DrawString(this.DataMain, fontB, brushTxtColor, XMid - (graphics_0.MeasureString(this.DataMain, fontB).Width / 2), YMid - (fontB.Height / 2));
                    brushTxtColor = new SolidBrush(ColorSecText);
                    this.graphics_0.DrawString(this.DataSec, font, brushTxtColor, 1, base.ClientRectangle.Bottom - font.Height - 1);

                    if (this.Class18_0.class10_settings_0.dtPeakShown && this.hasPeak)
                    {
                        this.graphics_0.FillRectangle(brushRed, XMid, base.ClientRectangle.Bottom - (font.Height + 2), XMid - 1, (font.Height + 1));
                        this.graphics_0.DrawString(this.peakVal.ToString(), font, brushTxtColor, base.ClientRectangle.Right - graphics_0.MeasureString(this.peakVal.ToString(), font).Width - 1, base.ClientRectangle.Bottom - font.Height - 1);
                    }
                }
                //LED Graphic
                else if (DataDisplayType == 1)
                {
                    Color ThisColor = Color.IndianRed;
                    if (this.IsLEDActivated) ThisColor = this.Class18_0.class10_settings_0.color_On;
                    else ThisColor = this.Class18_0.class10_settings_0.color_Off;
                    Brush brushLED = new SolidBrush(ThisColor);
                    this.graphics_0.FillRectangle(brushLED, base.ClientRectangle.X + 1, base.ClientRectangle.Y + 1, base.ClientRectangle.Width - 2, base.ClientRectangle.Height - 2);
                    this.graphics_0.DrawString(this.SensorName, font, brushTxtColor, XMid - (graphics_0.MeasureString(this.SensorName, font).Width / 2), YMid - (font.Height / 2), formatVertical);
                    if (brushLED != null) brushLED.Dispose();
                }
                //Bar Graph
                else if (DataDisplayType == 2)
                {
                    Pen penLineLarge = new Pen(ColorNameText, 2f);
                    int StartX = (int)(base.ClientRectangle.X + (base.ClientRectangle.Width / 2.2));
                    int StartY = base.ClientRectangle.Y + (1 + font.Height) + 6;    //6 = offset
                    int EndY = base.ClientRectangle.Bottom - 6;                     //6 = offset
                    if (this.DataSec != null && this.DataSec != "") StartY += fontSmall.Height + 2;
                    int SizeY = EndY - StartY;

                    //Draw separator
                    int MinValue = this.Class18_0.class10_settings_0.method_20_Min(ConvertDisplayTypeToSensor());
                    int MaxValue = this.Class18_0.class10_settings_0.method_22_Max(ConvertDisplayTypeToSensor());
                    bool IsInteger = this.Class18_0.class10_settings_0.method_22_IsInt(ConvertDisplayTypeToSensor());
                    int WarnMinValue = this.Class18_0.class10_settings_0.method_20(ConvertDisplayTypeToSensor());
                    int WarnMaxValue = this.Class18_0.class10_settings_0.method_22(ConvertDisplayTypeToSensor());

                    //if (WarnMinValue > MinValue) WarnMinValue = MinValue;
                    //if (WarnMaxValue > MaxValue) WarnMaxValue = MaxValue;

                    if (WarnMinValue != 0 || WarnMaxValue != 0)
                    {
                        Pen penLineLargeRed = new Pen(this.Class18_0.class10_settings_0.color_Off, 15f);
                        int PercentY = (int)MapThis(WarnMinValue, MinValue, MaxValue, 0, SizeY);
                        this.graphics_0.DrawLine(penLineLargeRed, StartX + 8, EndY - PercentY, StartX + 8, StartY);
                        if (penLineLargeRed != null) penLineLargeRed.Dispose();
                    }

                    //Draw Peak
                    if (this.Class18_0.class10_settings_0.dtPeakShown)
                    {
                        Pen penLineTrail = new Pen(this.Class18_0.class10_settings_0.color_Trail, 15f);
                        double BufVal = this.peakVal;
                        if (BufVal < MinValue) BufVal = MinValue;
                        if (BufVal > MaxValue) BufVal = MaxValue;

                        //Console.WriteLine(this.peakVal);
                        //Console.WriteLine(MinValue);
                        //Console.WriteLine(MaxValue);

                        int TrailPercentY = (int)MapThis(this.peakVal, MinValue, MaxValue, 0, SizeY);
                        this.graphics_0.DrawLine(penLineTrail, StartX + 8, EndY, StartX + 8, EndY - TrailPercentY);
                        //this.graphics_0.DrawLine(penLineTrail, StartX + 8, EndY - TrailPercentY, StartX + 8, StartY);
                        if (penLineTrail != null) penLineTrail.Dispose();
                    }

                    //Draw Sensor Tracing
                    Pen penLineTrace = new Pen(this.Class18_0.class10_settings_0.color_Trace, 15f);
                    Pen penLineArrow = new Pen(ColorNameText, 2f);
                    int TracePercentY = (int)MapThis(this.DataMain2, MinValue, MaxValue, 0, SizeY);
                    this.graphics_0.DrawLine(penLineTrace, StartX + 8, EndY, StartX + 8, EndY - TracePercentY);

                    this.graphics_0.DrawLine(penLineArrow, StartX - 15, EndY - TracePercentY, StartX - 5, EndY - TracePercentY);
                    this.graphics_0.DrawLine(penLineArrow, StartX - 8, EndY - TracePercentY - 5, StartX - 5, EndY - TracePercentY + 1);
                    this.graphics_0.DrawLine(penLineArrow, StartX - 8, EndY - TracePercentY + 4, StartX - 5, EndY - TracePercentY - 1);
                    this.graphics_0.DrawString(this.DataMain, font, brushTxtColor, StartX - 15 - graphics_0.MeasureString(this.DataMain, font).Width, (float)(EndY - TracePercentY - (font.Height / 1.5)));

                    //Draw the long black line for the graph
                    this.graphics_0.DrawString(this.SensorName, font, brushTxtColor, XMid - (graphics_0.MeasureString(this.SensorName, font).Width / 2), 1);
                    if (this.DataSec != null && this.DataSec != "")
                    {
                        this.graphics_0.DrawString(this.DataSec, fontSmall, brushTxtColor, XMid - (graphics_0.MeasureString(this.DataSec, fontSmall).Width / 2), 1 + font.Height + 3);
                    }
                    this.graphics_0.DrawLine(penLineLarge, StartX, StartY, StartX, EndY);
                    this.graphics_0.DrawLine(penLineLarge, StartX + 17, StartY, StartX + 17, EndY);

                    //draw all rows
                    int Divider = 20;
                    //if (myType == DatalogDisplayTypes.gear) Divider = 5;
                    for (int i = 0; i < Divider; i++)
                    {
                        int PercentY = (i * SizeY) / Divider;
                        double ThisValue = RoundThis((double)(((double)(i * 10.0) * (double)(MaxValue - MinValue)) / (Divider * 10.0)) + MinValue);
                        if (DatalogDisplayTypes_0 == DatalogDisplayTypes.gear) ThisValue = i;
                        int XLenght = 3;
                        Pen penLine = new Pen(ColorNameText);
                        if (i == 0)
                        {
                            XLenght = 18;
                            penLine = new Pen(ColorNameText, 2f);
                        }
                        if (DatalogDisplayTypes_0 != DatalogDisplayTypes.gear)
                        {
                            if (i == Divider / 2)
                            {
                                //XLenght = 17;
                                penLine = new Pen(ColorNameText, 2f);
                            }
                            if (i % 5 == 0) XLenght = 17;
                        }

                        if (i % 5 == 0) this.graphics_0.DrawString(ThisValue.ToString(), fontSmall, brushTxtColor, StartX + 20, (float)(EndY - PercentY - (fontSmall.Height / 1.5)));
                        this.graphics_0.DrawLine(penLine, StartX - 1, EndY - PercentY, StartX + XLenght, EndY - PercentY);
                        //if (i % 5 == 1) this.graphics_0.DrawLine(penLine, StartX - 1 + 17, EndY - PercentY, StartX - XLenght + 17, EndY - PercentY);
                        this.graphics_0.DrawLine(penLine, StartX - 1 + 16, EndY - PercentY, StartX - XLenght + 16, EndY - PercentY);

                        if (penLine != null) penLine.Dispose();
                    }
                    //draw the missing top line that didnt spawned for the loop just above
                    this.graphics_0.DrawString(MaxValue.ToString(), fontSmall, brushTxtColor, StartX + 20, (float)(StartY - (fontSmall.Height / 1.5)));
                    this.graphics_0.DrawLine(penLineLarge, StartX - 1, StartY, StartX + 18, StartY);

                    if (penLineLarge != null) penLineLarge.Dispose();
                    if (penLineTrace != null) penLineTrace.Dispose();
                    if (penLineArrow != null) penLineArrow.Dispose();
                }
                //Draw Gauge
                else if (DataDisplayType == 3)
                {
                    int StartX = XMid;
                    int StartY = YMid;
                    int OffsetX = 14;
                    int OffsetY = 14;
                    int TxtIncrement = (base.ClientRectangle.Height / 2) / 3;
                    int TxtIncrementUnder = (base.ClientRectangle.Height / 2) / 2;
                    int MinValue = this.Class18_0.class10_settings_0.method_20_Min(ConvertDisplayTypeToSensor());
                    int MaxValue = this.Class18_0.class10_settings_0.method_22_Max(ConvertDisplayTypeToSensor());
                    bool IsInteger = this.Class18_0.class10_settings_0.method_22_IsInt(ConvertDisplayTypeToSensor());
                    int WarnMinValue = this.Class18_0.class10_settings_0.method_20(ConvertDisplayTypeToSensor());
                    int WarnMaxValue = this.Class18_0.class10_settings_0.method_22(ConvertDisplayTypeToSensor());

                    /*Gauge1_Radial.Visible = true;
                    Gauge1_Radial.Gauges[0].Minimum = MinValue;
                    Gauge1_Radial.Gauges[0].Maximum = MaxValue;
                    if (WarnMinValue != 0 || WarnMaxValue != 0)
                    {
                        int Range = WarnMaxValue - WarnMinValue;
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[0].Value = WarnMinValue;
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[1].Value = WarnMinValue + (Range / 4);
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[2].Value = WarnMinValue + ((Range / 4) * 2);
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[3].Value = WarnMinValue + ((Range / 4) * 3);
                    }
                    else
                    {
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[0].Value = MaxValue;
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[1].Value = MaxValue;
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[2].Value = MaxValue;
                        Gauge1_Radial.Gauges[0].Decorators[0].ValueColors[3].Value = MaxValue;
                    }
                    Gauge1_Radial.Gauges[0].Value = this.DataMain2;*/


                    //Draw value
                    this.graphics_0.DrawString(this.SensorName, fontSmall, brushTxtColor, XMid - (graphics_0.MeasureString(this.SensorName, fontSmall).Width / 2), YMid - TxtIncrement - (fontSmall.Height / 2));
                    this.graphics_0.DrawString(this.DataMain, fontB, brushTxtColor, XMid - (graphics_0.MeasureString(this.DataMain, fontB).Width / 2), YMid + TxtIncrementUnder - (fontB.Height / 2));
                    if (this.DataSec != null && this.DataSec != "")
                    {
                        this.graphics_0.DrawString(this.DataSec, fontSmall, brushTxtColor, XMid - (graphics_0.MeasureString(this.DataSec, fontSmall).Width / 2), YMid - (fontSmall.Height / 2));
                    }

                    Pen penLineLarge = new Pen(ColorNameText, (float)(FontS / 1.4));
                    this.graphics_0.DrawArc(penLineLarge, base.ClientRectangle.X + OffsetX, base.ClientRectangle.Y + OffsetY, (float)(base.ClientRectangle.Width - (OffsetY * 2)), (float)(base.ClientRectangle.Height / 1.2), 178, 184);

                    if (WarnMinValue != 0 || WarnMaxValue != 0)
                    {
                        int PercentY = (int)MapThis(WarnMinValue, MinValue, MaxValue, 0, 180);
                        Pen penLineLargeRed = new Pen(this.Class18_0.class10_settings_0.color_Off, (float)(FontS / 1.65));
                        this.graphics_0.DrawArc(penLineLargeRed, base.ClientRectangle.X + OffsetX, base.ClientRectangle.Y + OffsetY, (float)(base.ClientRectangle.Width - (OffsetY * 2)), (float)(base.ClientRectangle.Height / 1.2), 180 + PercentY, 180 - PercentY);
                        if (penLineLargeRed != null) penLineLargeRed.Dispose();
                    }

                    //Draw Peak
                    if (this.Class18_0.class10_settings_0.dtPeakShown)
                    {
                        int TrailPercentY = (int)MapThis(this.peakVal, MinValue, MaxValue, 0, 180);
                        Pen penLineTrail = new Pen(this.Class18_0.class10_settings_0.color_Trail, (float)(FontS / 1.75));
                        this.graphics_0.DrawArc(penLineTrail, base.ClientRectangle.X + OffsetX, base.ClientRectangle.Y + OffsetY, (float)(base.ClientRectangle.Width - (OffsetY * 2)), (float)(base.ClientRectangle.Height / 1.2), 180, TrailPercentY);
                        if (penLineTrail != null) penLineTrail.Dispose();
                    }

                    //Draw Sensor Tracing
                    int TracePercentY = (int)MapThis(this.DataMain2, MinValue, MaxValue, 0, 180);
                    Pen penLineTrace = new Pen(this.Class18_0.class10_settings_0.color_Trace, (float)(FontS / 1.75));
                    this.graphics_0.DrawArc(penLineTrace, base.ClientRectangle.X + OffsetX, base.ClientRectangle.Y + OffsetY, (float)(base.ClientRectangle.Width - (OffsetY * 2)), (float)(base.ClientRectangle.Height / 1.2), 180, TracePercentY);

                    if (penLineLarge != null) penLineLarge.Dispose();
                    if (penLineTrace != null) penLineTrace.Dispose();
                }
                //Sensor Graphic
                else if (DataDisplayType == 4)
                {
                    Brush brushLED = new SolidBrush(ColorBack);
                    this.graphics_0.FillRectangle(brushLED, base.ClientRectangle.X + 1, base.ClientRectangle.Y + 1, base.ClientRectangle.Width - 2, base.ClientRectangle.Height - 2);
                    this.graphics_0.DrawString(this.SensorName, font, brushTxtColor, XMid - (graphics_0.MeasureString(this.SensorName, font).Width / 2), YMid - (font.Height / 2) - (YMid / 3), formatVertical);
                    this.graphics_0.DrawString(this.DataMain, font, brushTxtColor, XMid - (graphics_0.MeasureString(this.DataMain, font).Width / 2), YMid - (font.Height / 2) + (YMid / 3), formatVertical);

                    if (brushLED != null) brushLED.Dispose();
                }
                //Button Graphic
                else if (DataDisplayType == 5)
                {
                    Color ColorDisabled = Color.FromArgb(0, 0, 0, 0);
                    if (!IsLEDActivated) ColorDisabled = Color.FromArgb(50, 0, 0, 0);
                    if (ButtonClicked) ColorBack = this.Class18_0.class10_settings_0.color_On;

                    Brush brushDisabled = new SolidBrush(ColorDisabled);
                    Brush brushLED = new SolidBrush(ColorBack);

                    this.graphics_0.FillRectangle(brushLED, base.ClientRectangle.X + 1, base.ClientRectangle.Y + 1, base.ClientRectangle.Width - 2, base.ClientRectangle.Height - 2);
                    this.graphics_0.DrawString(this.SensorName, font, brushTxtColor, XMid - (graphics_0.MeasureString(this.SensorName, font).Width / 2), YMid - (font.Height / 2) - (YMid / 3), formatVertical);
                    this.graphics_0.DrawString(this.DataMain, font, brushTxtColor, XMid - (graphics_0.MeasureString(this.DataMain, font).Width / 2), YMid - (font.Height / 2) + (YMid / 3), formatVertical);
                    this.graphics_0.FillRectangle(brushDisabled, base.ClientRectangle.X + 1, base.ClientRectangle.Y + 1, base.ClientRectangle.Width - 2, base.ClientRectangle.Height - 2);

                    /*if (ButtonClicked)
                    {
                        this.timer_0.Start();
                        this.Invalidate();
                    }*/

                    if (brushDisabled != null) brushDisabled.Dispose();
                    if (brushLED != null) brushLED.Dispose();
                }

                if (InEditMode && !this.FrmMain_0.frmDataDisplay_0.LockedPositionAndSize)
                {
                    var rc = new Rectangle(this.ClientSize.Width - grab, this.ClientSize.Height - grab, grab, grab);
                    ControlPaint.DrawSizeGrip(pe.Graphics, this.BackColor, rc);
                }

                if (font != null) font.Dispose();
                if (fontSmall != null) fontSmall.Dispose();
                if (fontB != null) fontB.Dispose();
                if (brushTxtColor != null) brushTxtColor.Dispose();
                if (brushBackColor != null) brushBackColor.Dispose();
                if (brushRed != null) brushRed.Dispose();
                if (brushBlack != null) brushBlack.Dispose();
                if (penBlack != null) penBlack.Dispose();
                if (formatVertical != null) formatVertical.Dispose();

                //LastCheck = DateTime.Now;
            }
            catch (Exception mess)
            {
                this.FrmMain_0.LogThis("Gauges - Unable to Paint Gauges for Sensor:" + this.SensorName + " with error:" + Environment.NewLine + mess);
            }
        }

        private double MapThis(double x, double in_min, double in_max, double out_min, double out_max)
        {
            if (in_min == in_max) in_max++;
            if (out_min == out_max) out_max++;

            double ThisInt = ((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
            if (ThisInt < out_min) ThisInt = out_min;
            if (ThisInt > out_max) ThisInt = out_max;
            return ThisInt;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                var pos = this.PointToClient(new Point(m.LParam.ToInt32()));
                if (pos.X >= this.ClientSize.Width - grab && pos.Y >= this.ClientSize.Height - grab)
                    m.Result = new IntPtr(17);  // HT_BOTTOMRIGHT
            }
        }

        private const int grab = 10;

        private void CtrlDisplayItemText_MouseLeave(object sender, EventArgs e)
        {
            InEditMode = false;
            this.Invalidate();
        }

        private void CtrlDisplayItemText_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < this.MinimumSize.Width) this.Size = new Size(this.MinimumSize.Width, this.Size.Height);
            if (this.Size.Height < this.MinimumSize.Height) this.Size = new Size(this.Size.Width, this.MinimumSize.Height);
            if (this.Size.Width > this.MaximumSize.Width) this.Size = new Size(this.MaximumSize.Width, this.Size.Height);
            if (this.Size.Height > this.MaximumSize.Height) this.Size = new Size(this.Size.Width, this.MaximumSize.Height);

            this.Invalidate();
        }

        private void CtrlDisplayItemText_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.FrmMain_0.frmDataDisplay_0.LockedPositionAndSize)
            {
                InEditMode = true;

                if (IsDragging)
                {
                    Point p = new Point();
                    p.X = e.X + this.Left;
                    p.Y = e.Y + this.Top;
                    this.Left = p.X - iClickX;
                    this.Top = p.Y - iClickY;
                }
            }

            this.Invalidate();
        }

        private void CtrlDisplayItemText_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.FrmMain_0.frmDataDisplay_0.LockedPositionAndSize)
                {
                    iClickX = e.X;
                    iClickY = e.Y;

                    IsDragging = true;
                }
                else
                {
                    /*if (DataDisplayType == 5)
                    {
                        this.FrmMain_0.ClickButtonFormGraph((int)TypeBUTTON);
                        ButtonClicked = true;
                        this.Invalidate();
                    }*/
                }
            }
        }

        private void CtrlDisplayItemText_MouseUp(object sender, MouseEventArgs e)
        {
            IsDragging = false;
        }

        private Point ConvertFromChildToForm(int x, int y, Control control)
        {
            Point p = new Point(x, y);
            control.Location = p;
            return p;
        }

        private void MenuItemTextVertical_Click(object sender, EventArgs e)
        {
            IsTextVertical = !IsTextVertical;
            this.Invalidate();
        }

        private void SetAsDataDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataDisplayType = 0;
            this.Invalidate();
        }

        private void SetAsBarsGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataDisplayType = 2;
            this.Invalidate();
        }

        public SensorsX ConvertDisplayTypeToSensor()
        {
            SensorsX ThisSensor = 0;
            if (Type == DatalogDisplayTypes.analog1) ThisSensor = SensorsX.analog1;
            if (Type == DatalogDisplayTypes.analog2) ThisSensor = SensorsX.analog2;
            if (Type == DatalogDisplayTypes.analog3) ThisSensor = SensorsX.analog3;
            if (Type == DatalogDisplayTypes.bat) ThisSensor = SensorsX.batV;
            if (Type == DatalogDisplayTypes.boost) ThisSensor = SensorsX.boostX;
            if (Type == DatalogDisplayTypes.bstctrl) ThisSensor = SensorsX.bstActive;
            if (Type == DatalogDisplayTypes.ect) ThisSensor = SensorsX.ectX;
            if (Type == DatalogDisplayTypes.gear) ThisSensor = SensorsX.gearX;
            if (Type == DatalogDisplayTypes.iat) ThisSensor = SensorsX.iatX;
            if (Type == DatalogDisplayTypes.ign) ThisSensor = SensorsX.ignFnl;
            if (Type == DatalogDisplayTypes.inj) ThisSensor = SensorsX.injDuty;
            if (Type == DatalogDisplayTypes.map) ThisSensor = SensorsX.mapX;
            if (Type == DatalogDisplayTypes.O2) ThisSensor = SensorsX.ecuO2V;
            if (Type == DatalogDisplayTypes.o2Trim) ThisSensor = SensorsX.o2Short;
            if (Type == DatalogDisplayTypes.rpm) ThisSensor = SensorsX.rpmX;
            if (Type == DatalogDisplayTypes.tps) ThisSensor = SensorsX.tpsX;
            if (Type == DatalogDisplayTypes.vss) ThisSensor = SensorsX.vssX;
            if (Type == DatalogDisplayTypes.accelTime) ThisSensor = SensorsX.accelTime;
            if (Type == DatalogDisplayTypes.fuelUsage) ThisSensor = SensorsX.fuelUsage;
            if (Type == DatalogDisplayTypes.flexFuel) ThisSensor = SensorsX.flexFuel;
            if (Type == DatalogDisplayTypes.ectV) ThisSensor = SensorsX.ectV;
            if (Type == DatalogDisplayTypes.iatV) ThisSensor = SensorsX.iatV;

            return ThisSensor;
        }

        private double RoundThis(double ThisValue)
        {
            double ThisD = 0;
            if (Type == DatalogDisplayTypes.analog1) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.analog2) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.analog3) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.bat) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.boost) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.bstctrl) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.ect) ThisD = RoundValue(ThisValue, 0);
            if (Type == DatalogDisplayTypes.gear) ThisD = RoundValue(ThisValue, 0);
            if (Type == DatalogDisplayTypes.iat) ThisD = RoundValue(ThisValue, 0);
            if (Type == DatalogDisplayTypes.ign) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.inj) ThisD = RoundValue(ThisValue, 0);
            if (Type == DatalogDisplayTypes.map) ThisD = RoundOverValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.O2) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.o2Trim) ThisD = RoundValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.rpm) ThisD = RoundOverValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.tps) ThisD = RoundValue(ThisValue, 0);
            if (Type == DatalogDisplayTypes.vss) ThisD = RoundValue(ThisValue, 0);
            if (Type == DatalogDisplayTypes.accelTime) ThisD = RoundOverValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.fuelUsage) ThisD = RoundOverValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.flexFuel) ThisD = RoundOverValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.ectV) ThisD = RoundOverValue(ThisValue, 2);
            if (Type == DatalogDisplayTypes.iatV) ThisD = RoundOverValue(ThisValue, 2);

            return ThisD;
        }

        private double RoundValue(double ThisValue, int Decimals)
        {
            return Math.Round(ThisValue, Decimals);
        }

        private double RoundOverValue(double ThisValue, int Decimals)
        {
            int Reduced = (int)(ThisValue / (10 * Decimals));
            return Reduced * (10 * Decimals);
        }
        private void SetAsSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataDisplayType = 4;
            this.Invalidate();
        }
        private void SetAsButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataDisplayType = 5;
            this.Invalidate();
        }

        private void SetAsGaugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataDisplayType = 3;
            this.Invalidate();
        }

        private void LoadPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FrmMain_0.frmDataDisplay_0.LoadSettingsBox();
        }

        private void SavePresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FrmMain_0.frmDataDisplay_0.SaveSettingsBox();
        }

        private void CtrlDisplayItemText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (!e.Shift)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        if (this.Location.X > 0) this.Location = new Point(this.Location.X - 1, this.Location.Y);
                        this.Invalidate();
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        if (this.Location.X < (this.FrmMain_0.frmDataDisplay_0.Size.Width - this.Size.Width)) this.Location = new Point(this.Location.X + 1, this.Location.Y);
                        this.Invalidate();
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        if (this.Location.Y > 0) this.Location = new Point(this.Location.X, this.Location.Y - 1);
                        this.Invalidate();
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        if (this.Location.Y < (this.FrmMain_0.frmDataDisplay_0.Size.Height - this.Size.Height)) this.Location = new Point(this.Location.X, this.Location.Y + 1);
                        this.Invalidate();
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        if (this.Size.Width > this.MinimumSize.Width) this.Size = new Size(this.Size.Width - 1, this.Size.Height);
                        this.Invalidate();
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        if (this.Size.Width < this.MaximumSize.Width) this.Size = new Size(this.Size.Width + 1, this.Size.Height);
                        this.Invalidate();
                    }

                    else if (e.KeyCode == Keys.Up)
                    {
                        if (this.Size.Height > this.MinimumSize.Height) this.Size = new Size(this.Size.Width, this.Size.Height - 1);
                        this.Invalidate();
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        if (this.Size.Height < this.MaximumSize.Height) this.Size = new Size(this.Size.Width, this.Size.Height + 1);
                        this.Invalidate();
                    }
                }
            }
        }

        private void EditDisplayManuallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.frmGaugesEditor_0 != null)
            {
                this.frmGaugesEditor_0.Dispose();
                this.frmGaugesEditor_0 = null;
            }

            this.frmGaugesEditor_0 = new frmGaugesEditor(ref this.FrmMain_0, ref this.Class18_0, ref CtrlDisplayItemText_0);
            this.frmGaugesEditor_0.Show();
            this.frmGaugesEditor_0.Focus();
        }

        private void LockPositionSizingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FrmMain_0.frmDataDisplay_0.LockedPositionAndSize = !this.FrmMain_0.frmDataDisplay_0.LockedPositionAndSize;
            lockPositionSizingToolStripMenuItem.Checked = this.FrmMain_0.frmDataDisplay_0.LockedPositionAndSize;
        }
    }
}

