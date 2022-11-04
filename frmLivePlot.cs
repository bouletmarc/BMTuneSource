using Data;
using Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

internal class frmLivePlot : Form
{

    private ctrlPlotGraph ctrlMapGraph1;
    private frmLivePSetting frmLivePSetting_0;
    private Class18 class18_0;
    private FrmMain frmMain_0;
    //private Struct17 struct17_0;
    private IContainer icontainer_0;
    private IContainer components;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem timeVsAfrToolStripMenuItem;
    private ToolStripMenuItem rpmVsAfrBoostToolStripMenuItem;
    private ToolStripDropDownButton toolStripDropDownButton2;
    private ToolStripMenuItem editLivePlotsToolStripMenuItem;
    public bool loading = true;
    //private BackgroundWorker backgroundWorker1;
    //private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();

    private DateTime LastCheck = DateTime.Now;

    internal frmLivePlot()
    {
        this.InitializeComponent();

        /*this.backgroundWorker1.WorkerSupportsCancellation = true;
        this.backgroundWorker1.WorkerReportsProgress = false;
        this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
        this.backgroundWorker1.RunWorkerAsync();*/

        //LoopTimer.Interval = 50;
        //LoopTimer.Tick += DoThisAllTheTime;
        //LoopTimer.Start();
    }

    //void DoThisAllTheTime(object sender, EventArgs e)
    //{
    /*private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        while (!worker.CancellationPending)
        {
            if (this.ctrlMapGraph1 != null && class18_0 != null)
            {
                if (base.WindowState == FormWindowState.Normal)
                    if (this.class18_0.class17_0.method_34() || this.class18_0.class17_0.method_63())
                    {
                        this.ctrlMapGraph1.Invalidate();
                        //this.ctrlMapGraph1.Refresh();
                    }
            }

            Thread.Sleep(50);
        }
    }*/

    internal void method_0(ref Class18 class18_1, ref FrmMain frmMain_1)
    {
        this.class18_0 = class18_1;
        this.frmMain_0 = frmMain_1;

        //SetTimeVSAFR();

        /*if (this.ctrlMapGraph1 != null)
        {
            this.ctrlMapGraph1.Dispose();
            this.ctrlMapGraph1 = null;
        }*/

        //this.ctrlMapGraph1 = new ctrlPlotGraph();
        this.ctrlMapGraph1.method_0(ref this.class18_0, ref this.class18_0.class10_settings_0);

        this.class18_0.class17_0.delegate54_0 += new Class17.Delegate54(this.method_4);
        this.class18_0.class17_0.delegate47_0 += new Class17.Delegate47(this.method_6);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
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

    private void frmDebug_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.class18_0.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.LivePlot_Location = base.Location;

        if (this.ctrlMapGraph1 != null)
        {
            this.ctrlMapGraph1.Dispose();
            this.ctrlMapGraph1 = null;
        }

        if (this.frmMain_0.frmLivePlot_0 != null)
        {
            this.frmMain_0.frmLivePlot_0.Dispose();
            this.frmMain_0.frmLivePlot_0 = null;
        }
    }

    public void RefreshPage()
    {
        if (base.WindowState == FormWindowState.Normal)
        {
            this.Refresh();
            this.ctrlMapGraph1.Refresh();

            //this.Invalidate();
            //this.ctrlMapGraph1.Invalidate();
        }
    }

    private void method_4(Struct12 struct12_0)
    {
        if (!this.class18_0.class10_settings_0.DatalogThreadEnabled || (this.class18_0.class10_settings_0.DatalogThreadEnabled && (DateTime.Now - LastCheck).TotalMilliseconds >= this.class18_0.class10_settings_0.int_ActiveDatalog[5]))
        {
            LastCheck = DateTime.Now;
            if (!this.class18_0.class10_settings_0.DatalogThreadEnabled || (this.class18_0.class10_settings_0.DatalogThreadEnabled && this.class18_0.class10_settings_0.bool_ActiveDatalog[5]))
            {
                try
                {
                    base.Invoke(new Delegate6(this.method_5), new object[] { struct12_0 });
                }
                catch { }
            }
        }
    }

    private void method_5(Struct12 struct12_0)
    {
        if (!this.class18_0.class10_settings_0.DatalogThreadEnabled || (this.class18_0.class10_settings_0.DatalogThreadEnabled && this.class18_0.class10_settings_0.bool_ActiveDatalog[2]))
        {
            if ((this.ctrlMapGraph1 != null) && (this.ctrlMapGraph1.mapGraphType_0 == MapGraphType.timePlot || this.ctrlMapGraph1.mapGraphType_0 == MapGraphType.custom))
            {
                this.ctrlMapGraph1.method_19(struct12_0);
            }
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
        if (this.ctrlMapGraph1.mapGraphType_0 == MapGraphType.rpmPlot)
        {
            this.ctrlMapGraph1.method_20(struct17_1);
        }
    }

    private void frmDebug_Load(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.Dock = DockStyle.None;
                    base.Location = this.class18_0.class10_settings_0.LivePlot_Location;
                    base.Size = this.class18_0.class10_settings_0.LivePlot_Size;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Dock = DockStyle.Fill;
                }
            }
        }

        this.ctrlMapGraph1.mapGraphType_0 = (MapGraphType) this.class18_0.class10_settings_0.int_2_LivePlot;
        this.timeVsAfrToolStripMenuItem.Checked = false;
        this.rpmVsAfrBoostToolStripMenuItem.Checked = false;
        //this.customVsTimeToolStripMenuItem.Checked = false;
        switch (this.ctrlMapGraph1.mapGraphType_0)
        {
            case MapGraphType.rpmPlot:
                this.rpmVsAfrBoostToolStripMenuItem.Checked = true;
                break;

            case MapGraphType.timePlot:
                this.timeVsAfrToolStripMenuItem.Checked = true;
                break;
            case MapGraphType.custom:
                //this.customVsTimeToolStripMenuItem.Checked = true;
                break;
        }
        this.ctrlMapGraph1.Refresh();

        loading = false;
    }

    private void frmDebug_Move(object sender, EventArgs e)
    {
    }

    private void frmDebug_Resize(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode && !loading)
                {
                    if (base.WindowState == FormWindowState.Normal)
                    {
                        this.class18_0.class10_settings_0.LivePlot_Size = base.Size;
                    }
                    this.class18_0.class10_settings_0.LivePlot_Location = base.Location;
                }
            }
        }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLivePlot));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.timeVsAfrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rpmVsAfrBoostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.editLivePlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            //this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ctrlMapGraph1 = new ctrlPlotGraph();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator6,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(541, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeVsAfrToolStripMenuItem,
            this.rpmVsAfrBoostToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "Style";
            // 
            // timeVsAfrToolStripMenuItem
            // 
            this.timeVsAfrToolStripMenuItem.CheckOnClick = true;
            this.timeVsAfrToolStripMenuItem.Name = "timeVsAfrToolStripMenuItem";
            this.timeVsAfrToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F7)));
            this.timeVsAfrToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.timeVsAfrToolStripMenuItem.Text = "Afr vs Time";
            this.timeVsAfrToolStripMenuItem.Click += new System.EventHandler(this.timeVsAfrToolStripMenuItem_Click);
            // 
            // rpmVsAfrBoostToolStripMenuItem
            // 
            this.rpmVsAfrBoostToolStripMenuItem.CheckOnClick = true;
            this.rpmVsAfrBoostToolStripMenuItem.Name = "rpmVsAfrBoostToolStripMenuItem";
            this.rpmVsAfrBoostToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F8)));
            this.rpmVsAfrBoostToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.rpmVsAfrBoostToolStripMenuItem.Text = "Map/Afr vs Rpm";
            this.rpmVsAfrBoostToolStripMenuItem.Click += new System.EventHandler(this.rpmVsAfrBoostToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editLivePlotsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(40, 22);
            this.toolStripDropDownButton2.Text = "Edit";
            // 
            // editLivePlotsToolStripMenuItem
            // 
            this.editLivePlotsToolStripMenuItem.Name = "editLivePlotsToolStripMenuItem";
            this.editLivePlotsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editLivePlotsToolStripMenuItem.Text = "Time/Rpm vs Afr";
            this.editLivePlotsToolStripMenuItem.Click += new System.EventHandler(this.editLivePlotsToolStripMenuItem_Click);
            // 
            // ctrlMapGraph1
            // 
            this.ctrlMapGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMapGraph1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlMapGraph1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMapGraph1.Name = "ctrlMapGraph1";
            this.ctrlMapGraph1.Size = new System.Drawing.Size(541, 429);
            this.ctrlMapGraph1.TabIndex = 1;
            // 
            // frmLivePlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 429);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ctrlMapGraph1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLivePlot";
            this.Text = "Live Plots";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLivePlot_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDebug_FormClosed);
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.ResizeEnd += new System.EventHandler(this.frmLivePlot_ResizeEnd);
            this.Click += new System.EventHandler(this.FrmLivePlot_Click);
            this.Move += new System.EventHandler(this.frmDebug_Move);
            this.Resize += new System.EventHandler(this.frmDebug_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void frmLivePlot_ResizeEnd(object sender, EventArgs e)
    {
        RefreshPage();
    }

    private void editLivePlotsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmLivePSetting_0 = new frmLivePSetting();
        this.frmLivePSetting_0.method_0(ref this.class18_0);
        this.frmLivePSetting_0.ShowDialog();
        this.frmLivePSetting_0.Close();
        this.frmLivePSetting_0.Dispose();
        this.frmLivePSetting_0 = null;
    }

    private void SetTimeVSAFR()
    {
        this.timeVsAfrToolStripMenuItem.Checked = true;
        this.rpmVsAfrBoostToolStripMenuItem.Checked = false;
        //this.customVsTimeToolStripMenuItem.Checked = false;
        this.ctrlMapGraph1.mapGraphType_0 = MapGraphType.timePlot;
        this.class18_0.class10_settings_0.int_2_LivePlot = (int)this.ctrlMapGraph1.mapGraphType_0;
        this.ctrlMapGraph1.Refresh();
    }

    private void timeVsAfrToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetTimeVSAFR();
    }

    private void rpmVsAfrBoostToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.timeVsAfrToolStripMenuItem.Checked = false;
        this.rpmVsAfrBoostToolStripMenuItem.Checked = true;
        //this.customVsTimeToolStripMenuItem.Checked = false;
        this.ctrlMapGraph1.mapGraphType_0 = MapGraphType.rpmPlot;
        this.class18_0.class10_settings_0.int_2_LivePlot = (int)this.ctrlMapGraph1.mapGraphType_0;
        this.ctrlMapGraph1.Refresh();
    }

    private void customVsTimeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.timeVsAfrToolStripMenuItem.Checked = false;
        this.rpmVsAfrBoostToolStripMenuItem.Checked = false;
        //this.customVsTimeToolStripMenuItem.Checked = true;
        this.ctrlMapGraph1.mapGraphType_0 = MapGraphType.custom;
        this.class18_0.class10_settings_0.int_2_LivePlot = (int)this.ctrlMapGraph1.mapGraphType_0;
        this.ctrlMapGraph1.Refresh();
    }

    private delegate void Delegate6(Struct12 struct12_0);

    private delegate void Delegate7(Struct17 struct17_0);

    private void frmLivePlot_FormClosing(object sender, FormClosingEventArgs e)
    {
        /*if (this.backgroundWorker1 != null)
        {
            if (this.backgroundWorker1.IsBusy) this.backgroundWorker1.CancelAsync();
            this.backgroundWorker1.Dispose();
            this.backgroundWorker1 = null;
        }*/
    }

    private void FrmLivePlot_Click(object sender, EventArgs e)
    {

    }
}

