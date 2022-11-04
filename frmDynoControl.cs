using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmDynoControl : Form
{
    private Class18 class18_0;
    private ToolStripMenuItem clearErrorCodesToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip1;
    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    private IContainer components;
    private Panel panel1;
    public Button button1;
    public Button button2;
    private SaveFileDialog saveFileDialog1;
    private Timer LoopTimer = new Timer();
    public bool loading = true;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    public Button button3;
    private Class10_settings class10_settings_0;
    public static string BrakeA = "0000";

    internal frmDynoControl()
    {
        this.InitializeComponent();

    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (this.frmMain_0.class29_Dyno_0.ComPort.IsOpen)
        {
            this.frmMain_0.class29_Dyno_0.ComPort.Write(this.frmMain_0.class29_Dyno_0.DynoBRAKE, 0, 1);
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        if (this.frmMain_0.class29_Dyno_0.ComPort.IsOpen)
        {
            this.frmMain_0.class29_Dyno_0.ComPort.Write(this.frmMain_0.class29_Dyno_0.DynoRPMUP, 0, 1);
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        if (this.frmMain_0.class29_Dyno_0.ComPort.IsOpen)
        {
            this.frmMain_0.class29_Dyno_0.ComPort.Write(this.frmMain_0.class29_Dyno_0.DynoRPMDOWN, 0, 1);
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

    private void DoThisAllTheTime(object sender, EventArgs e)
    {
        bool isOpen = this.frmMain_0.class29_Dyno_0.ComPort.IsOpen;
        this.button1.Enabled = isOpen;
        this.button2.Enabled = isOpen;
        this.button3.Enabled = isOpen;
        this.button1.Text = "Brake (" + BrakeA + ")";
    }

    private void frmFormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.class18_0.class10_settings_0.WindowedMode)
        {
            this.class18_0.class10_settings_0.Debug_Location = base.Location;
        }
        this.frmMain_0.frmDynoControl_0.Dispose();
        this.frmMain_0.frmDynoControl_0 = null;
    }

    private void frmFormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void frmLoad(object sender, EventArgs e)
    {
        if ((this.class18_0 != null) && (this.class18_0.class10_settings_0 != null))
        {
            if (!this.class18_0.class10_settings_0.WindowedMode)
            {
                base.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
            }
            else
            {
                base.FormBorderStyle = FormBorderStyle.Sizable;
                this.Dock = DockStyle.None;
                base.Location = this.class18_0.class10_settings_0.DynoC_Location;
                base.Size = this.class18_0.class10_settings_0.DynoC_Size;
            }
        }
        this.loading = false;
    }

    private void frmResize(object sender, EventArgs e)
    {
        if (((this.class18_0 != null) && ((this.class18_0.class10_settings_0 != null) && this.class18_0.class10_settings_0.WindowedMode)) && !this.loading)
        {
            if (base.WindowState == FormWindowState.Normal)
            {
                this.class18_0.class10_settings_0.DynoC_Size = base.Size;
            }
            this.class18_0.class10_settings_0.DynoC_Location = base.Location;
        }
    }

    private void InitializeComponent()
    {
        this.components = new Container();
        ComponentResourceManager manager = new ComponentResourceManager(typeof(frmDynoControl));
        this.contextMenuStrip1 = new ContextMenuStrip(this.components);
        this.copyToolStripMenuItem = new ToolStripMenuItem();
        this.toolStripSeparator1 = new ToolStripSeparator();
        this.clearErrorCodesToolStripMenuItem = new ToolStripMenuItem();
        this.panel1 = new Panel();
        this.button3 = new Button();
        this.button2 = new Button();
        this.button1 = new Button();
        this.saveFileDialog1 = new SaveFileDialog();
        this.contextMenuStrip1.SuspendLayout();
        this.panel1.SuspendLayout();
        base.SuspendLayout();
        this.contextMenuStrip1.ImageScalingSize = new Size(0x1c, 0x1c);
        ToolStripItem[] toolStripItems = new ToolStripItem[] { this.copyToolStripMenuItem, this.toolStripSeparator1, this.clearErrorCodesToolStripMenuItem };
        this.contextMenuStrip1.Items.AddRange(toolStripItems);
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.Size = new Size(0x86, 0x52);
        this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        this.copyToolStripMenuItem.Size = new Size(0x85, 0x24);
        this.copyToolStripMenuItem.Text = "Copy";
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new Size(130, 6);
        this.clearErrorCodesToolStripMenuItem.Name = "clearErrorCodesToolStripMenuItem";
        this.clearErrorCodesToolStripMenuItem.Size = new Size(0x85, 0x24);
        this.panel1.ContextMenuStrip = this.contextMenuStrip1;
        this.panel1.Controls.Add(this.button3);
        this.panel1.Controls.Add(this.button2);
        this.panel1.Controls.Add(this.button1);
        this.panel1.Dock = DockStyle.Top;
        this.panel1.Location = new Point(0, 0);
        this.panel1.Margin = new Padding(6);
        this.panel1.Name = "panel1";
        this.panel1.Size = new Size(0xff, 180);
        this.panel1.TabIndex = 1;
        this.button3.FlatStyle = FlatStyle.Flat;
        this.button3.Location = new Point(0x23, 0x41);
        this.button3.Margin = new Padding(6);
        this.button3.Name = "button3";
        this.button3.Size = new Size(0xb8, 0x2a);
        this.button3.TabIndex = 2;
        this.button3.Text = "RPM Down";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new EventHandler(this.Button3_Click);
        this.button2.FlatStyle = FlatStyle.Flat;
        this.button2.Location = new Point(0x23, 11);
        this.button2.Margin = new Padding(6);
        this.button2.Name = "button2";
        this.button2.Size = new Size(0xb8, 0x2a);
        this.button2.TabIndex = 1;
        this.button2.Text = "RPM Up";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new EventHandler(this.Button2_Click);
        this.button1.FlatStyle = FlatStyle.Flat;
        this.button1.ForeColor = Color.Red;
        this.button1.Location = new Point(0x23, 0x77);
        this.button1.Margin = new Padding(6);
        this.button1.Name = "button1";
        this.button1.Size = new Size(0xb8, 0x2a);
        this.button1.TabIndex = 0;
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new EventHandler(this.Button1_Click);
        this.saveFileDialog1.DefaultExt = "txt";
        this.saveFileDialog1.Filter = "Log Text File|*.txt";
        this.saveFileDialog1.Title = "Save Debug Log";
        base.AutoScaleDimensions = new SizeF(11f, 24f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.ClientSize = new Size(0xff, 0xc4);
        base.Controls.Add(this.panel1);
        base.Margin = new Padding(6);
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.Name = "frmDynoC";
        this.Text = "Dyno Control";
        base.FormClosing += new FormClosingEventHandler(this.frmFormClosing);
        base.FormClosed += new FormClosedEventHandler(this.frmFormClosed);
        base.Load += new EventHandler(this.frmLoad);
        base.Resize += new EventHandler(this.frmResize);
        this.contextMenuStrip1.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        base.ResumeLayout(false);
    }

    internal void method_0(ref Class18 class18_1, ref FrmMain frmMain_1)
    {
        this.class18_0 = class18_1;
        this.frmMain_0 = frmMain_1;
        if (this.frmMain_0.class29_Dyno_0 == null)
        {
            this.frmMain_0.class29_Dyno_0 = new Class29_Dyno(ref this.class18_0);
        }
        this.LoopTimer.Interval = 0x3e8;
        this.LoopTimer.Tick += new EventHandler(this.DoThisAllTheTime);
        this.LoopTimer.Start();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }
}

