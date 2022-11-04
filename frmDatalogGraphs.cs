using Controls;
using Data;
//using PropertiesRes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class frmDatalogGraphs : Form
{
    private bool bool_0 = true;
    private bool bool_1;
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private ContextMenuStrip contextMenuStrip;
    public ctrlLogGraph ctrlLogGraph1;
    private ToolStripMenuItem editTemplatesToolStripMenuItem;
    private frmDatalogGraphs frmDatalogGraphs_0;
    private FrmMain frmMain_0;
    private HScrollBar hScrollBar;
    private IContainer icontainer_0;
    private ToolStripButton toolEditTemplate;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolZoomIn;
    private ToolStripButton toolZoomOut;
    private ToolStripButton toolZoomFull;
    private Panel panel1;
    private Panel panel2;
    private IContainer components;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripButton toolStripButton1;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem maxDataSizeToolStripMenuItem;
    private ToolStripTextBox toolStripTextBox2;
    public bool loading = true;

    internal frmDatalogGraphs()
    {
        this.InitializeComponent();
        this.frmDatalogGraphs_0 = this;
        base.HandleDestroyed += new EventHandler(this.frmDatalogGraphs_HandleDestroyed);

        this.ctrlLogGraph1.Width = base.Width - 8;
        this.ctrlLogGraph1.Height = base.Height - 0x41;

        this.hScrollBar.Visible = false;

    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmDatalogGraphs_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.frmMain_0.frmDatalogGraphs_0.Dispose();
        this.frmMain_0.frmDatalogGraphs_0 = null;
        if (this.class17_0 != null)
        {
            this.class17_0.delegate53_0 -= new Class17.Delegate53(this.method_9);
            this.class17_0 = null;
        }
        if (this.ctrlLogGraph1 != null)
        {
            this.ctrlLogGraph1.Dispose();
            this.ctrlLogGraph1 = null;
        }
    }

    private void frmDatalogGraphs_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.ctrlLogGraph1 != null)
        {
            this.ctrlLogGraph1.Close();
            this.ctrlLogGraph1.Dispose();
            this.ctrlLogGraph1 = null;
        }
        if (this.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.logGraphs_Location = base.Location;
    }

    private void frmDatalogGraphs_HandleDestroyed(object sender, EventArgs e)
    {
        this.bool_0 = false;
    }

    private void frmDatalogGraphs_Load(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Dock = DockStyle.None;
                base.Location = this.class18_0.class10_settings_0.logGraphs_Location;
                base.Size = this.class18_0.class10_settings_0.logGraphs_Size;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
            }
        }
        loading = false;

        if (this.class17_0 != null)
        {
            if (this.class17_0.method_63_HasLogsFileOpen())
            {
                this.hScrollBar.Minimum = 0;
                this.hScrollBar.Maximum = (int)this.class17_0.method_65();
                this.hScrollBar.LargeChange = (int)this.class17_0.method_65();
                this.ctrlLogGraph1.Refresh();
            }
            this.ctrlLogGraph1.Focus();
            this.toolZoomFull.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            this.toolZoomIn.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            this.toolZoomOut.Enabled = this.class17_0.method_63_HasLogsFileOpen();
        }
    }

    private void frmDatalogGraphs_Move(object sender, EventArgs e)
    {
    }

    private void frmDatalogGraphs_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
    }

    private void frmDatalogGraphs_Resize(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode && !loading)
            {
                if (base.WindowState == FormWindowState.Normal)
                {
                    this.class18_0.class10_settings_0.logGraphs_Size = base.Size;
                }
                this.class18_0.class10_settings_0.logGraphs_Location = base.Location;
            }
        }
    }

    private void hScrollBar_KeyDown(object sender, KeyEventArgs e)
    {
        if ((e.Modifiers == Keys.Control) || (e.Modifiers == Keys.ControlKey))
        {
            this.ctrlLogGraph1.Focus();
        }
    }

    private void hScrollBar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
    }

    private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        if ((e.OldValue != e.NewValue) && this.class17_0.method_63_HasLogsFileOpen())
        {
            this.ctrlLogGraph1.SetPlotStartEnd(e.NewValue, e.NewValue + this.hScrollBar.LargeChange);
            this.ctrlLogGraph1.Refresh();
        }
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatalogGraphs));
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolEditTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.maxDataSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolZoomFull = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlLogGraph1 = new Controls.ctrlLogGraph();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar
            // 
            this.hScrollBar.CausesValidation = false;
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.LargeChange = 100;
            this.hScrollBar.Location = new System.Drawing.Point(0, 416);
            this.hScrollBar.Maximum = 1000;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(835, 16);
            this.hScrollBar.SmallChange = 100;
            this.hScrollBar.TabIndex = 1;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            this.hScrollBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hScrollBar_KeyDown);
            this.hScrollBar.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.hScrollBar_PreviewKeyDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTemplatesToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(130, 26);
            // 
            // editTemplatesToolStripMenuItem
            // 
            this.editTemplatesToolStripMenuItem.Name = "editTemplatesToolStripMenuItem";
            this.editTemplatesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.editTemplatesToolStripMenuItem.Text = "Edit Graph";
            this.editTemplatesToolStripMenuItem.Click += new System.EventHandler(this.toolEditTemplate_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolEditTemplate,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolZoomIn,
            this.toolZoomOut,
            this.toolZoomFull});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(835, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolEditTemplate
            // 
            this.toolEditTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolEditTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditTemplate.Name = "toolEditTemplate";
            this.toolEditTemplate.Size = new System.Drawing.Size(66, 22);
            this.toolEditTemplate.Text = "Edit Graph";
            this.toolEditTemplate.Click += new System.EventHandler(this.toolEditTemplate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.maxDataSizeToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(93, 22);
            this.toolStripDropDownButton1.Text = "Live Graphing";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(125, 19);
            this.toolStripButton1.Text = "Disable Live Graphing";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(182, 6);
            // 
            // maxDataSizeToolStripMenuItem
            // 
            this.maxDataSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.maxDataSizeToolStripMenuItem.Name = "maxDataSizeToolStripMenuItem";
            this.maxDataSizeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.maxDataSizeToolStripMenuItem.Text = "Max Data Size";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox2.TextChanged += new System.EventHandler(this.ToolStripTextBox2_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolZoomIn
            // 
            this.toolZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomIn.Image = global::Properties.Resources.magnifier__plus;
            this.toolZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomIn.Name = "toolZoomIn";
            this.toolZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolZoomIn.Text = "Zoom in";
            this.toolZoomIn.Click += new System.EventHandler(this.toolZoomIn_Click);
            // 
            // toolZoomOut
            // 
            this.toolZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomOut.Image = global::Properties.Resources.magnifier__minus;
            this.toolZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomOut.Name = "toolZoomOut";
            this.toolZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolZoomOut.Text = "Zoom out";
            this.toolZoomOut.Click += new System.EventHandler(this.toolZoomOut_Click);
            // 
            // toolZoomFull
            // 
            this.toolZoomFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomFull.Image = global::Properties.Resources.magnifier_history;
            this.toolZoomFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomFull.Name = "toolZoomFull";
            this.toolZoomFull.Size = new System.Drawing.Size(23, 22);
            this.toolZoomFull.Text = "Zoom Full";
            this.toolZoomFull.Click += new System.EventHandler(this.toolZoomFull_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 10);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(835, 381);
            this.panel2.TabIndex = 5;
            // 
            // ctrlLogGraph1
            // 
            this.ctrlLogGraph1.BackColor = System.Drawing.Color.LightBlue;
            this.ctrlLogGraph1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ctrlLogGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLogGraph1.Location = new System.Drawing.Point(0, 35);
            this.ctrlLogGraph1.Name = "ctrlLogGraph1";
            this.ctrlLogGraph1.PlotCursor = 0;
            this.ctrlLogGraph1.PlotEnd = 0F;
            this.ctrlLogGraph1.PlotStart = 0F;
            this.ctrlLogGraph1.Size = new System.Drawing.Size(835, 381);
            this.ctrlLogGraph1.TabIndex = 0;
            // 
            // frmDatalogGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(835, 432);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.ctrlLogGraph1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDatalogGraphs";
            this.Text = "Datalog Graphs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatalogGraphs_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDatalogGraphs_FormClosed);
            this.Load += new System.EventHandler(this.frmDatalogGraphs_Load);
            this.Move += new System.EventHandler(this.frmDatalogGraphs_Move);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmDatalogGraphs_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.frmDatalogGraphs_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_1(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1, ref FrmMain frmMain_1)
    {
        this.frmMain_0 = frmMain_1;
        this.class10_settings_0 = class10_1;
        this.class17_0 = class17_1;
        this.class18_0 = class18_1;

        this.ctrlLogGraph1.method_0(ref class18_1, ref class10_1, ref class17_1);
        this.ctrlLogGraph1.plotChangeDelegate_0 += new ctrlLogGraph.plotChangeDelegate(this.method_8);
        this.ctrlLogGraph1.plotCursorChangeDelegate_0 += new ctrlLogGraph.plotCursorChangeDelegate(this.method_7);
        this.ctrlLogGraph1.requestEditTemplateDelegate_0 += new ctrlLogGraph.requestEditTemplateDelegate(this.method_3);

        this.class17_0.delegate53_0 += new Class17.Delegate53(this.method_9);

        if (this.class10_settings_0.LiveGraphing) toolStripButton1.Text = "Disable Live Graphing";
        else toolStripButton1.Text = "Enable Live Graphing";
        toolStripTextBox2.Text = this.class10_settings_0.LiveGraph_Lenght.ToString();

        this.BackColor = this.class10_settings_0.color_8;
        this.ctrlLogGraph1.BackColor = this.class10_settings_0.color_8;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private string method_10(long long_0)
    {
        TimeSpan span = TimeSpan.FromMilliseconds((double) long_0);
        int num = (int) Math.Floor((double) (((float) span.Milliseconds) / 10f));
        if (span.Minutes <= 0)
        {
            return (span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + ":" + num.ToString("00"));
        }
        if (span.Minutes > 0)
        {
            return (span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + ":" + num.ToString("00"));
        }
        if (span.Hours > 0)
        {
            return (span.Hours.ToString("00") + ":" + span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + ":" + num.ToString("00"));
        }
        return "";
    }

    private void method_3()
    {
        this.toolEditTemplate_Click(null, null);
    }

    private void method_7(int int_0)
    {
        string str = TimeSpan.FromMilliseconds((double) this.class17_0.method_77(SensorsX.duration, int_0)).ToString();
        if (str.Length > 8)
        {
            str = str.Remove(str.Length - 4, 4);
        }
    }

    private void method_8()
    {
        this.hScrollBar.LargeChange = ((int) this.ctrlLogGraph1.PlotEnd) - ((int) this.ctrlLogGraph1.PlotStart);
        this.hScrollBar.Maximum = (int) this.class17_0.method_65();
        this.hScrollBar.Value = (int) this.ctrlLogGraph1.PlotStart;
    }

    private void method_9(long long_0, string string_0)
    {
        try
        {
            if (this.class17_0 != null)
            {
                this.hScrollBar.Visible = this.class17_0.method_63_HasLogsFileOpen();
                if (this.class17_0.method_63_HasLogsFileOpen())
                {
                    this.hScrollBar.Minimum = 0;
                    this.hScrollBar.Maximum = (int) this.class17_0.method_65();
                    this.hScrollBar.LargeChange = (int) this.class17_0.method_65();
                }
                this.toolZoomFull.Enabled = this.class17_0.method_63_HasLogsFileOpen();
                this.toolZoomIn.Enabled = this.class17_0.method_63_HasLogsFileOpen();
                this.toolZoomOut.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            }
        }
        catch (Exception)
        {
        }
    }

    private void toolClearMarker_Click(object sender, EventArgs e)
    {
        this.ctrlLogGraph1.clearMarkersToolStripMenuItem_Click(sender, e);
    }

    private void toolEditTemplate_Click(object sender, EventArgs e)
    {
        this.frmMain_0.graphsSetupToolStripMenuItem_Click(sender, e);
    }

    private void toolSetEnd_Click(object sender, EventArgs e)
    {
        this.ctrlLogGraph1.setEndToolStripMenuItem_Click(sender, e);
    }

    private void toolSetMarker_Click(object sender, EventArgs e)
    {
        this.ctrlLogGraph1.setMarkerCurrentCursor();
    }

    private void toolSetStart_Click(object sender, EventArgs e)
    {
        this.ctrlLogGraph1.setStartToolStripMenuItem_Click(sender, e);
    }

    private void toolZoomFull_Click(object sender, EventArgs e)
    {
        this.ctrlLogGraph1.zoomFullToolStripMenuItem_Click(sender, e);
    }

    private void toolZoomIn_Click(object sender, EventArgs e)
    {
        this.ctrlLogGraph1.zoomInToolStripMenuItem_Click(sender, e);
    }

    private void toolZoomOut_Click(object sender, EventArgs e)
    {
        this.ctrlLogGraph1.zoomOutToolStripMenuItem_Click(sender, e);
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        if (this.class10_settings_0.LiveGraphing)
        {
            this.class10_settings_0.LiveGraphing = false;
            toolStripButton1.Text = "Enable Live Graphing";
        }
        else
        {
            this.class10_settings_0.LiveGraphing = true;
            toolStripButton1.Text = "Disable Live Graphing";
        }
    }

    private void ToolStripTextBox2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.class10_settings_0.LiveGraph_Lenght = int.Parse(toolStripTextBox2.Text);
            toolStripTextBox2.Text = this.class10_settings_0.LiveGraph_Lenght.ToString();
        }
        catch
        {

        }
    }
}

