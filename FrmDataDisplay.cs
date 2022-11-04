using Controls;
using Data;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

internal class FrmDataDisplay : Form
{
    private ToolStripMenuItem addLedDisplayToolStripMenuItem;
    private ToolStripMenuItem addToolStripMenuItem;
    private bool bool_0;
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private ContextMenuStrip contextMenuStrip1;
    private Collection<CtrlDisplayItemText> collection_0 = new Collection<CtrlDisplayItemText>();
    private CtrlDisplayItemText ctrlDisplayItem_0;
    private DisplayItemsStripped displayItemsStripped_0 = new DisplayItemsStripped();
    private FrmMain frmMain_0;
    private IContainer components;
    private IContainer icontainer_0;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem editWarningsToolStripMenuItem;
    private ToolStripMenuItem addBarsGraphToolStripMenuItem;
    private ToolStripMenuItem addGaugeToolStripMenuItem;
    private ToolStripMenuItem loadPresetToolStripMenuItem;
    private ToolStripMenuItem savePresetToolStripMenuItem;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    private ToolStripMenuItem addSensorToolStripMenuItem;
    private ToolStripMenuItem addTextToolStripMenuItem;
    private ToolStripMenuItem addButtonToolStripMenuItem;
    private ToolStripMenuItem unlockPositionSizingToolStripMenuItem;
    public bool loading = true;
    public bool LockedPositionAndSize = true;

    private DateTime LastCheck = DateTime.Now;

    internal FrmDataDisplay()
    {
        this.InitializeComponent();

        this.unlockPositionSizingToolStripMenuItem.Checked = LockedPositionAndSize;

    }

    private void addLedDisplayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CtrlDisplayItemText item = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0)
        {
            DataDisplayType = 1
        };
        AddDisplay(item, 1);
        SpawnDisplays();
    }

    private void addToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CtrlDisplayItemText item = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0)
        {
            DataDisplayType = 0
        };
        AddDisplay(item, 0);
        SpawnDisplays();
    }

    private void addGraphDisplayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CtrlDisplayItemText item = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0)
        {
            DataDisplayType = 2
        };
        AddDisplay(item, 2);
        SpawnDisplays();
    }

    private void AddGaugeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CtrlDisplayItemText item = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0)
        {
            DataDisplayType = 3
        };
        AddDisplay(item, 3);
        SpawnDisplays();
    }

    private void AddSensorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CtrlDisplayItemText item = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0)
        {
            DataDisplayType = 4
        };
        AddDisplay(item, 4);
        SpawnDisplays();
    }

    private void AddButtonToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CtrlDisplayItemText item = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0)
        {
            DataDisplayType = 5
        };
        AddDisplay(item, 5);
        SpawnDisplays();
    }

    private void AddTextToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CtrlDisplayItemText item = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0)
        {
            DataDisplayType = 6
        };
        AddDisplay(item, 6);
        SpawnDisplays();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void FrmDataDisplay_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.method_10();
        //this.class17_0.delegate54_0 -= new Class17_dtl.Delegate54(this.method_5);
        this.class17_0.delegate53_0 -= new Class17.Delegate53(this.method_3);
        this.class18_0.delegate58_0 -= new Class18.Delegate58(this.method_4);
        this.frmMain_0.frmDataDisplay_0.Dispose();
        this.frmMain_0.frmDataDisplay_0 = null;
        base.Dispose();
    }

    private void FrmDataDisplay_HandleCreated(object sender, EventArgs e)
    {
        this.bool_0 = true;
    }

    private void FrmDataDisplay_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.class10_settings_0.WindowedMode) this.class10_settings_0.Display_Location = base.Location;
    }

    private void FrmDataDisplay_HandleDestroyed(object sender, EventArgs e)
    {
        this.bool_0 = false;
    }

    private void FrmDataDisplay_Load(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Dock = DockStyle.None;

                base.Location = this.class10_settings_0.Display_Location;
                base.Size = this.class10_settings_0.Display_Size;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
            }
        }

        this.method_9();
        loading = false;
    }

    private void FrmDataDisplay_Move(object sender, EventArgs e)
    {
    }

    private void FrmDataDisplay_Resize(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode && !loading)
            {
                if (base.WindowState == FormWindowState.Normal)
                {
                    this.class10_settings_0.Display_Size = base.Size;
                }
                this.class10_settings_0.Display_Location = base.Location;
            }
        }
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataDisplay));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLedDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBarsGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGaugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.unlockPositionSizingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editWarningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addLedDisplayToolStripMenuItem,
            this.addBarsGraphToolStripMenuItem,
            this.addGaugeToolStripMenuItem,
            this.addSensorToolStripMenuItem,
            this.addButtonToolStripMenuItem,
            this.addTextToolStripMenuItem,
            this.toolStripSeparator1,
            this.unlockPositionSizingToolStripMenuItem,
            this.editWarningsToolStripMenuItem,
            this.loadPresetToolStripMenuItem,
            this.savePresetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 274);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addToolStripMenuItem.Text = "Add Data";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addLedDisplayToolStripMenuItem
            // 
            this.addLedDisplayToolStripMenuItem.Name = "addLedDisplayToolStripMenuItem";
            this.addLedDisplayToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addLedDisplayToolStripMenuItem.Text = "Add Led";
            this.addLedDisplayToolStripMenuItem.Click += new System.EventHandler(this.addLedDisplayToolStripMenuItem_Click);
            // 
            // addBarsGraphToolStripMenuItem
            // 
            this.addBarsGraphToolStripMenuItem.Name = "addBarsGraphToolStripMenuItem";
            this.addBarsGraphToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addBarsGraphToolStripMenuItem.Text = "Add Bars Graph";
            this.addBarsGraphToolStripMenuItem.Click += new System.EventHandler(this.addGraphDisplayToolStripMenuItem_Click);
            // 
            // addGaugeToolStripMenuItem
            // 
            this.addGaugeToolStripMenuItem.Name = "addGaugeToolStripMenuItem";
            this.addGaugeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addGaugeToolStripMenuItem.Text = "Add Gauge";
            this.addGaugeToolStripMenuItem.Click += new System.EventHandler(this.AddGaugeToolStripMenuItem_Click);
            // 
            // addSensorToolStripMenuItem
            // 
            this.addSensorToolStripMenuItem.Name = "addSensorToolStripMenuItem";
            this.addSensorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addSensorToolStripMenuItem.Text = "Add Sensor";
            this.addSensorToolStripMenuItem.Click += new System.EventHandler(this.AddSensorToolStripMenuItem_Click);
            // 
            // addButtonToolStripMenuItem
            // 
            this.addButtonToolStripMenuItem.Name = "addButtonToolStripMenuItem";
            this.addButtonToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addButtonToolStripMenuItem.Text = "Add Button";
            this.addButtonToolStripMenuItem.Visible = false;
            this.addButtonToolStripMenuItem.Click += new System.EventHandler(this.AddButtonToolStripMenuItem_Click);
            // 
            // addTextToolStripMenuItem
            // 
            this.addTextToolStripMenuItem.Name = "addTextToolStripMenuItem";
            this.addTextToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addTextToolStripMenuItem.Text = "Add Text";
            this.addTextToolStripMenuItem.Visible = false;
            this.addTextToolStripMenuItem.Click += new System.EventHandler(this.AddTextToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // unlockPositionSizingToolStripMenuItem
            // 
            this.unlockPositionSizingToolStripMenuItem.CheckOnClick = true;
            this.unlockPositionSizingToolStripMenuItem.Name = "unlockPositionSizingToolStripMenuItem";
            this.unlockPositionSizingToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.unlockPositionSizingToolStripMenuItem.Text = "Lock Position/Sizing";
            this.unlockPositionSizingToolStripMenuItem.Click += new System.EventHandler(this.UnlockPositionSizingToolStripMenuItem_Click);
            // 
            // editWarningsToolStripMenuItem
            // 
            this.editWarningsToolStripMenuItem.Name = "editWarningsToolStripMenuItem";
            this.editWarningsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editWarningsToolStripMenuItem.Text = "Edit Limits/Warnings";
            this.editWarningsToolStripMenuItem.ToolTipText = "Edit Sensors Min/Max Limit and Warnings";
            this.editWarningsToolStripMenuItem.Click += new System.EventHandler(this.editWarningsToolStripMenuItem_Click);
            // 
            // loadPresetToolStripMenuItem
            // 
            this.loadPresetToolStripMenuItem.Name = "loadPresetToolStripMenuItem";
            this.loadPresetToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.loadPresetToolStripMenuItem.Text = "Load Preset";
            this.loadPresetToolStripMenuItem.ToolTipText = "Load Gauges Preset";
            this.loadPresetToolStripMenuItem.Click += new System.EventHandler(this.LoadPresetToolStripMenuItem_Click);
            // 
            // savePresetToolStripMenuItem
            // 
            this.savePresetToolStripMenuItem.Name = "savePresetToolStripMenuItem";
            this.savePresetToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.savePresetToolStripMenuItem.Text = "Save Preset";
            this.savePresetToolStripMenuItem.ToolTipText = "Save Gauges Preset";
            this.savePresetToolStripMenuItem.Click += new System.EventHandler(this.SavePresetToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "preset";
            this.openFileDialog1.Filter = "BMTune Gauges Preset|*.txt";
            this.openFileDialog1.Title = "Open Gauges Preset";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "preset";
            this.saveFileDialog1.Filter = "BMTune Gauges Preset|*.txt";
            this.saveFileDialog1.Title = "Save Gauges Preset";
            // 
            // FrmDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(882, 92);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmDataDisplay";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gauges";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDataDisplay_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDataDisplay_FormClosed);
            this.Load += new System.EventHandler(this.FrmDataDisplay_Load);
            this.Move += new System.EventHandler(this.FrmDataDisplay_Move);
            this.Resize += new System.EventHandler(this.FrmDataDisplay_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1, ref FrmMain frmMain_1)
    {
        this.class10_settings_0 = class10_1;
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_4);
        this.class17_0 = class17_1;
        //this.class17_0.delegate54_0 += new Class17_dtl.Delegate54(this.method_5);
        this.class17_0.delegate53_0 += new Class17.Delegate53(this.method_3);
        base.HandleCreated += new EventHandler(this.FrmDataDisplay_HandleCreated);
        base.HandleDestroyed += new EventHandler(this.FrmDataDisplay_HandleDestroyed);
        this.frmMain_0 = frmMain_1;
        this.BackColor = this.class10_settings_0.color_8;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    internal void method_1()
    {
        this.collection_0[0].ShowPeak();
    }

    public void SaveSettings(string ThisPath)
    {
        FileInfo info = new FileInfo(ThisPath);
        if (info.Exists) info.Delete();

        this.displayItemsStripped_0.options = new string[this.collection_0.Count, 8];
        for (int i = 0; i < this.collection_0.Count; i++)
        {
            if (this.collection_0[i].DataDisplayType == 1) this.displayItemsStripped_0.options[i, 0] = ((int)this.collection_0[i].TypeLED).ToString();
            else if (this.collection_0[i].DataDisplayType == 4) this.displayItemsStripped_0.options[i, 0] = ((int)this.collection_0[i].TypeALL).ToString();
            else if (this.collection_0[i].DataDisplayType == 5) this.displayItemsStripped_0.options[i, 0] = ((int)this.collection_0[i].TypeBUTTON).ToString();
            else this.displayItemsStripped_0.options[i, 0] = ((int)this.collection_0[i].Type).ToString();

            this.displayItemsStripped_0.options[i, 1] = this.collection_0[i].SecData.ToString();
            this.displayItemsStripped_0.options[i, 2] = this.collection_0[i].DataDisplayType.ToString();
            this.displayItemsStripped_0.options[i, 3] = this.collection_0[i].Size.Width.ToString();
            this.displayItemsStripped_0.options[i, 4] = this.collection_0[i].Size.Height.ToString();
            this.displayItemsStripped_0.options[i, 5] = this.collection_0[i].Location.X.ToString();
            this.displayItemsStripped_0.options[i, 6] = this.collection_0[i].Location.Y.ToString();
            this.displayItemsStripped_0.options[i, 7] = this.collection_0[i].IsTextVertical.ToString();
        }

        string SaveStr = "";
        for (int i = 0; i < this.collection_0.Count; i++)
        {
            string SaveName = "Gauge";
            SaveStr += SaveName + "=" + i + ",Sensor=" + this.displayItemsStripped_0.options[i, 0] + Environment.NewLine;
            SaveStr += SaveName + "=" + i + ",SecData=" + this.displayItemsStripped_0.options[i, 1] + Environment.NewLine;
            SaveStr += SaveName + "=" + i + ",DataDisplayType=" + this.displayItemsStripped_0.options[i, 2] + Environment.NewLine;
            SaveStr += SaveName + "=" + i + ",Size.Width=" + this.displayItemsStripped_0.options[i, 3] + Environment.NewLine;
            SaveStr += SaveName + "=" + i + ",Size.Height=" + this.displayItemsStripped_0.options[i, 4] + Environment.NewLine;
            SaveStr += SaveName + "=" + i + ",Location.X=" + this.displayItemsStripped_0.options[i, 5] + Environment.NewLine;
            SaveStr += SaveName + "=" + i + ",Location.Y=" + this.displayItemsStripped_0.options[i, 6] + Environment.NewLine;
            SaveStr += SaveName + "=" + i + ",IsTextVertical=" + this.displayItemsStripped_0.options[i, 7] + Environment.NewLine;
            SaveStr += Environment.NewLine;
        }
        StreamWriter writer = new StreamWriter(ThisPath, false);
        writer.Write(SaveStr);
        writer.Close();
        writer.Dispose();
        writer = null;
    }

    public void LoadSettings(string ThisPath)
    {
        FileInfo info = new FileInfo(ThisPath);
        if (!info.Exists)
        {
            this.method_7();
        }
        else
        {
            try
            {
                string[] AllLines = File.ReadAllLines(ThisPath);
                if (AllLines.Length > 0)
                {
                    //Get Count
                    int CollectionCount = -1;
                    for (int i = 0; i < AllLines.Length; i++)
                    {
                        if (AllLines[i].Contains("Gauge"))
                        {
                            string[] SplitCMD = AllLines[i].Split(',');
                            string[] SplitIndexEnc = SplitCMD[0].Split('=');
                            CollectionCount = int.Parse(SplitIndexEnc[1]) + 1;
                        }
                    }

                    if (CollectionCount > -1)
                    {
                        //Set Array
                        this.displayItemsStripped_0.options = new string[CollectionCount, 8];

                        //Load
                        for (int i = 0; i < AllLines.Length; i++)
                        {
                            if (AllLines[i].Contains("Gauge"))
                            {
                                string[] SplitCMD = AllLines[i].Split(',');
                                string[] SplitIndexEnc = SplitCMD[0].Split('=');
                                string[] SplitCmdEnc = SplitCMD[1].Split('=');

                                if (SplitCmdEnc[0].Contains("Sensor")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 0] = SplitCmdEnc[1];
                                if (SplitCmdEnc[0].Contains("SecData")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 1] = SplitCmdEnc[1];
                                if (SplitCmdEnc[0].Contains("DataDisplayType")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 2] = SplitCmdEnc[1];
                                if (SplitCmdEnc[0].Contains("Size.Width")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 3] = SplitCmdEnc[1];
                                if (SplitCmdEnc[0].Contains("Size.Height")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 4] = SplitCmdEnc[1];
                                if (SplitCmdEnc[0].Contains("Location.X")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 5] = SplitCmdEnc[1];
                                if (SplitCmdEnc[0].Contains("Location.Y")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 6] = SplitCmdEnc[1];
                                if (SplitCmdEnc[0].Contains("IsTextVertical")) this.displayItemsStripped_0.options[int.Parse(SplitIndexEnc[1]), 7] = SplitCmdEnc[1];
                            }
                        }

                        this.collection_0.Clear();
                        //for (int i = 0; i < this.displayItemsStripped_0.options.GetLength(0); i++)
                        for (int i = 0; i < CollectionCount; i++)
                        {
                            this.ctrlDisplayItem_0 = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0);

                            this.ctrlDisplayItem_0.DataDisplayType = int.Parse(this.displayItemsStripped_0.options[i, 2]);

                            if (this.ctrlDisplayItem_0.DataDisplayType == 1) this.ctrlDisplayItem_0.TypeLED = (DatalogLedTypes)int.Parse(this.displayItemsStripped_0.options[i, 0]);
                            else if (this.ctrlDisplayItem_0.DataDisplayType == 4) this.ctrlDisplayItem_0.TypeALL = (SensorsX)int.Parse(this.displayItemsStripped_0.options[i, 0]);
                            else if (this.ctrlDisplayItem_0.DataDisplayType == 5) this.ctrlDisplayItem_0.TypeBUTTON = (DatalogButtonsTypes)int.Parse(this.displayItemsStripped_0.options[i, 0]);
                            else this.ctrlDisplayItem_0.Type = (DatalogDisplayTypes)int.Parse(this.displayItemsStripped_0.options[i, 0]);

                            this.ctrlDisplayItem_0.SecData = bool.Parse(this.displayItemsStripped_0.options[i, 1]);
                            this.ctrlDisplayItem_0.Size = new Size(int.Parse(this.displayItemsStripped_0.options[i, 3]), int.Parse(this.displayItemsStripped_0.options[i, 4]));
                            this.ctrlDisplayItem_0.Location = new Point(int.Parse(this.displayItemsStripped_0.options[i, 5]), int.Parse(this.displayItemsStripped_0.options[i, 6]));
                            this.ctrlDisplayItem_0.IsTextVertical = bool.Parse(this.displayItemsStripped_0.options[i, 7]);
                            AddDisplay(this.ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);
                        }
                        this.ReloadDisplay();
                    }
                    else
                    {
                        this.method_7();
                    }
                }
                else 
                {
                    this.method_7();
                }
            }
            catch (Exception mess)
            {
                LogThis("Error while loading Gauge Layout:\n" + mess);
                this.method_7();
            }
        }
    }

    private void LogThis(string string_8)
    {
        this.frmMain_0.LogThis("Gauges - " + string_8);
    }

    private void method_10()
    {
        SaveSettings(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\display.txt");
    }

    private int method_11(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        for (int i = 0; i < this.collection_0.Count; i++)
        {
            if (ctrlDisplayItem_1 == this.collection_0[i])
            {
                return i;
            }
        }
        return 0;
    }

    private void AddDisplay(CtrlDisplayItemText ctrlDisplayItem_1, int ThisType)
    {
        int index = this.method_11(ctrlDisplayItem_1);
        CtrlDisplayItemText ctrlDisplayItem_BCK = ctrlDisplayItem_1;

        ctrlDisplayItem_1 = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0);
        ctrlDisplayItem_1.DataDisplayType = ThisType;
        ctrlDisplayItem_1.Type = ctrlDisplayItem_BCK.Type;

        if (ctrlDisplayItem_1.DataDisplayType == 1) ctrlDisplayItem_1.TypeLED = ctrlDisplayItem_BCK.TypeLED;
        if (ctrlDisplayItem_1.DataDisplayType == 4) ctrlDisplayItem_1.TypeALL = ctrlDisplayItem_BCK.TypeALL;
        if (ctrlDisplayItem_1.DataDisplayType == 5) ctrlDisplayItem_1.TypeBUTTON = ctrlDisplayItem_BCK.TypeBUTTON;


        ctrlDisplayItem_1.SecData = ctrlDisplayItem_BCK.SecData;
        ctrlDisplayItem_1.Size = new Size(ctrlDisplayItem_BCK.Size.Width, ctrlDisplayItem_BCK.Size.Height);
        ctrlDisplayItem_1.Location = new Point(ctrlDisplayItem_BCK.Location.X, ctrlDisplayItem_BCK.Location.Y);
        ctrlDisplayItem_1.IsTextVertical = ctrlDisplayItem_BCK.IsTextVertical;
        ctrlDisplayItem_1.RemoveRequest += new CtrlDisplayItemText.Delegate16(this.method_15);
        ctrlDisplayItem_1.AddRequest += new CtrlDisplayItemText.Delegate20(this.method_12);
        ctrlDisplayItem_1.MoveLeftRequest += new CtrlDisplayItemText.Delegate17(this.method_14);
        ctrlDisplayItem_1.MoveRightRequest += new CtrlDisplayItemText.Delegate21(this.method_13);
        ctrlDisplayItem_1.DefaultsRequest += new CtrlDisplayItemText.Delegate19(this.method_16);
        ctrlDisplayItem_1.AddLedRequest += new CtrlDisplayItemText.Delegate18(this.method_17);
        ctrlDisplayItem_1.AddGraphRequest += new CtrlDisplayItemText.DelegateGraph(this.AddGraph);
        ctrlDisplayItem_1.AddGaugeRequest += new CtrlDisplayItemText.DelegateGauge(this.AddGauge);
        this.collection_0.Insert(index, ctrlDisplayItem_1);
        //SpawnDisplays();
    }

    private void method_12(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        AddDisplay(ctrlDisplayItem_1, 0);
        SpawnDisplays();
    }

    private void method_13(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        for (int i = 0; i < this.collection_0.Count; i++)
        {
            if ((ctrlDisplayItem_1 == this.collection_0[i]) && (i < (this.collection_0.Count - 2)))
            {
                this.collection_0.RemoveAt(i);
                this.collection_0.Insert(i + 1, ctrlDisplayItem_1);
                break;
            }
        }
        this.ReloadDisplay();
    }

    private void method_14(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        for (int i = 0; i < this.collection_0.Count; i++)
        {
            if ((ctrlDisplayItem_1 == this.collection_0[i]) && (i > 0))
            {
                this.collection_0.RemoveAt(i);
                this.collection_0.Insert(i - 1, ctrlDisplayItem_1);
                break;
            }
        }
        this.ReloadDisplay();
    }

    private void method_15(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        this.collection_0.Remove(ctrlDisplayItem_1);
        this.Controls.Remove(ctrlDisplayItem_1);
    }

    private void method_16(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        this.method_7();
    }

    private void SpawnDisplays()
    {
        this.Controls.Clear();
        for (int i = 0; i < this.collection_0.Count; i++) this.Controls.Add(this.collection_0[i]);
    }

    public void LoadHints()
    {
        //hints
        if (!loading)
        {
            if (!this.class10_settings_0.ShownHint_Gauges)
            {
                for (int i = this.collection_0.Count / 3; i < this.collection_0.Count; i++)
                {
                    string ThisHint = "You can Customize the gauges layout" + Environment.NewLine + "the sensors, position and sizing!";

                    frmHints frmHints_0 = new frmHints(ThisHint, true, 10, new Point(400, 145));
                    //frmHints frmHints_0 = new frmHints(ThisHint, true, 10, new Point(this.collection_0[i].Location.X + 15, this.collection_0[i].Location.Y + 15));
                    DialogResult result = frmHints_0.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.class10_settings_0.ShownHint_Gauges = true;
                    }

                    i = this.collection_0.Count + 1;
                }
            }

            if (!this.class10_settings_0.ShownHint_Colors)
            {
                for (int i = 0; i < this.collection_0.Count; i++)
                {
                    string ThisHint = "You can Customize the colors layout" + Environment.NewLine + "go in the 'Settings' to do so!";
                    //int LocX = this.collection_0[i].PointToScreen(new Point(int.Parse(this.displayItemsStripped_0.options[i, 5]), 0)).X + 440;
                    //int LocY = this.collection_0[i].PointToScreen(new Point(0, int.Parse(this.displayItemsStripped_0.options[i, 6]))).Y;

                    frmHints frmHints_0 = new frmHints(ThisHint, true, 10, new Point(400, 145));
                    //frmHints frmHints_0 = new frmHints(ThisHint, true, 10, new Point(LocX, LocY));
                    DialogResult result = frmHints_0.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.class10_settings_0.ShownHint_Colors = true;
                    }

                    i = this.collection_0.Count + 1;
                }
            }
        }
    }

    private void method_17(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        AddDisplay(ctrlDisplayItem_1, 1);
        SpawnDisplays();
    }

    private void AddGraph(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        AddDisplay(ctrlDisplayItem_1, 2);
        SpawnDisplays();
    }

    private void AddGauge(CtrlDisplayItemText ctrlDisplayItem_1)
    {
        AddDisplay(ctrlDisplayItem_1, 3);
        SpawnDisplays();
    }

    internal void method_2()
    {
        this.collection_0[0].ClearPeak();
    }

    private void method_3(long long_0, string string_0)
    {
        if (!this.class17_0.method_63_HasLogsFileOpen())
        {
            this.method_4();
        }
    }

    private void method_4()
    {
        base.Invalidate();
    }

    /*private void method_5(Struct12 struct12_0)
    {
        if (this.class10_0.bool_ActiveDatalog[3])
        {
            if (this.bool_0)
            {
                try
                {
                    base.Invoke(new Delegate0(this.method_6), new object[] { struct12_0 });
                }
                catch { }
            }
        }
    }

    private void method_6(Struct12 struct12_0)
    {
        if ((DateTime.Now - LastCheck).TotalMilliseconds >= this.class10_0.int_ActiveDatalog[3])
        //if ((DateTime.Now - LastCheck).TotalMilliseconds >= 0)
        {
            //LastCheck = DateTime.Now;
            if (this.class10_0.bool_ActiveDatalog[3])
            {
                if (this.class18_0.method_30_HasFileLoadedInBMTune())
                {
                    foreach (CtrlDisplayItemText item in this.collection_0)
                    {
                        item.myDataloggerUpdateInvoke(struct12_0);
                    }
                }
            }

            LastCheck = DateTime.Now;
        }
    }*/

    private void method_7()
    {
        this.collection_0.Clear();
        this.ctrlDisplayItem_0 = new CtrlDisplayItemText(ref this.class17_0, ref this.class18_0, ref this.collection_0, ref this.frmMain_0);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.Mil;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(0, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.VtsMaps;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(0, 20);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.Fuelcut;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(0, 40);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.IgnCut;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(0, 60);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.FuelPump;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 20);
        this.ctrlDisplayItem_0.Location = new Point(0, 80);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);
        //#####
        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.FtlActive;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(60, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.FtsActive;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(60, 20);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.AntiLag;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(60, 40);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.FanControl;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 21);
        this.ctrlDisplayItem_0.Location = new Point(60, 60);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.TypeLED = DatalogLedTypes.secMaps;
        this.ctrlDisplayItem_0.DataDisplayType = 1;
        this.ctrlDisplayItem_0.Size = new Size(61, 20);
        this.ctrlDisplayItem_0.Location = new Point(60, 80);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);
        //#####
        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.map;
        this.ctrlDisplayItem_0.DataDisplayType = 0;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(120, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.rpm;
        this.ctrlDisplayItem_0.DataDisplayType = 3;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(220, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.tps;
        this.ctrlDisplayItem_0.DataDisplayType = 2;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(320, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.O2;
        this.ctrlDisplayItem_0.DataDisplayType = 3;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(420, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.iat;
        this.ctrlDisplayItem_0.DataDisplayType = 2;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(520, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.ect;
        this.ctrlDisplayItem_0.DataDisplayType = 2;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(620, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.ign;
        this.ctrlDisplayItem_0.DataDisplayType = 3;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(720, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.inj;
        this.ctrlDisplayItem_0.DataDisplayType = 0;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(820, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.vss;
        this.ctrlDisplayItem_0.DataDisplayType = 3;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(920, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.flexFuel;
        this.ctrlDisplayItem_0.DataDisplayType = 0;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(1020, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.accelTime;
        this.ctrlDisplayItem_0.DataDisplayType = 0;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(1120, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.ctrlDisplayItem_0.Type = DatalogDisplayTypes.fuelUsage;
        this.ctrlDisplayItem_0.DataDisplayType = 0;
        this.ctrlDisplayItem_0.Size = new Size(101, 100);
        this.ctrlDisplayItem_0.Location = new Point(1220, 0);
        AddDisplay(ctrlDisplayItem_0, this.ctrlDisplayItem_0.DataDisplayType);

        this.method_10(); //Save Settings

        this.ReloadDisplay();
    }

    private void ReloadDisplay()
    {
        SpawnDisplays();
    }

    private void method_9()
    {
        LoadSettings(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\display.txt");
    }

    private delegate void Delegate0(Struct12 struct12_0);

    private void editWarningsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmMain_0.SensorWarning_Click(sender, e);
    }

    public void LoadSettingsBox()
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            LoadSettings(openFileDialog1.FileName);
        }
    }

    public void SaveSettingsBox()
    {
        DialogResult result = saveFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            SaveSettings(saveFileDialog1.FileName);
        }
    }

    private void LoadPresetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LoadSettingsBox();
    }

    private void SavePresetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SaveSettingsBox();
    }

    private void UnlockPositionSizingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LockedPositionAndSize = !LockedPositionAndSize;
        this.unlockPositionSizingToolStripMenuItem.Checked = LockedPositionAndSize;

        foreach (CtrlDisplayItemText item in this.collection_0)
        {
            item.lockPositionSizingToolStripMenuItem.Checked = LockedPositionAndSize;
        }
    }

    /*public void SetButtonsEnabled(int ThisTag, bool Enabled)
    {
        foreach (CtrlDisplayItemText item in this.collection_0)
        {
            if (item.DataDisplayType == 5 && (int)item.TypeBUTTON == ThisTag)
            {
                item.IsLEDActivated = Enabled;
                item.Invalidate();
            }
        }
    }*/
}

