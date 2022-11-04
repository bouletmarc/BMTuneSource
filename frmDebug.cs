using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

internal class frmDebug : Form
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
    private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    private RichTextBox richTextBox1;
    //private BackgroundWorker backgroundWorker1;
    public bool loading = true;
    public bool loading2 = true;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem logsAdvancedDatasToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private CheckBox checkBoxLogDatetime;
    private int SavedLines = 0;

    internal frmDebug()
    {
        this.InitializeComponent();
    }

    internal void method_0(ref Class18 class18_1, ref FrmMain frmMain_1)
    {
        this.class18_0 = class18_1;
        this.frmMain_0 = frmMain_1;

        LoopTimer.Interval = 100;
        //LoopTimer.Interval = 1000;
        LoopTimer.Tick += DoThisAllTheTime;
        LoopTimer.Start();

        loading2 = true;
        this.logsAdvancedDatasToolStripMenuItem.Checked = this.class18_0.class10_settings_0.LogAdvancedDatas;
        checkBoxLogDatetime.Checked = class18_0.class10_settings_0.LogDatetime;
        loading2 = false;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        /*this.backgroundWorker1.WorkerSupportsCancellation = true;
        this.backgroundWorker1.WorkerReportsProgress = false;
        this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
        this.backgroundWorker1.RunWorkerAsync();*/
    }

    private void ApplyLogs()
    {
        if (!loading)
        {
            if (frmMain_0.DebugLogs.Count > SavedLines)
            {
                LoopTimer.Stop();

                while (frmMain_0.DebugLogs.Count > SavedLines)
                {
                    if (checkBoxLogDatetime.Checked) this.richTextBox1.Text += DateTime.Now.ToString("H:mm:ss") + " - ";
                    this.richTextBox1.Text += frmMain_0.DebugLogs[SavedLines] + Environment.NewLine;
                    try
                    {
                        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                        this.richTextBox1.ScrollToCaret();
                    }
                    catch { }
                    SavedLines++;
                    //this.richTextBox1.Invalidate();
                }

                LoopTimer.Start();
            }
        }
    }

    void DoThisAllTheTime(object sender, EventArgs e)
    //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        ApplyLogs();
    }

    private void frmDebug_FormClosing(object sender, FormClosingEventArgs e)
    {
        //if (this.backgroundWorker1.IsBusy) this.backgroundWorker1.CancelAsync();
        //this.backgroundWorker1.Dispose();
        //this.backgroundWorker1 = null;
    }

    public void Clear()
    {
        frmMain_0.ClearLogs();
        this.richTextBox1.Clear();
        SavedLines = 0;
    }

    private void clearErrorCodesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Clear();
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
        if (this.class18_0.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.Debug_Location = base.Location;
        this.frmMain_0.frmDebug_0.Dispose();
        this.frmMain_0.frmDebug_0 = null;
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
                    base.Location = this.class18_0.class10_settings_0.Debug_Location;
                    base.Size = this.class18_0.class10_settings_0.Debug_Size;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Dock = DockStyle.Fill;
                }
            }
        }
        this.richTextBox1.Clear();

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
                        this.class18_0.class10_settings_0.Debug_Size = base.Size;
                    }
                    this.class18_0.class10_settings_0.Debug_Location = base.Location;
                }
            }
        }
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebug));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logsAdvancedDatasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearErrorCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxLogDatetime = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsAdvancedDatasToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearErrorCodesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 82);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // logsAdvancedDatasToolStripMenuItem
            // 
            this.logsAdvancedDatasToolStripMenuItem.CheckOnClick = true;
            this.logsAdvancedDatasToolStripMenuItem.Name = "logsAdvancedDatasToolStripMenuItem";
            this.logsAdvancedDatasToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.logsAdvancedDatasToolStripMenuItem.Text = "Logs Advanced Datas";
            this.logsAdvancedDatasToolStripMenuItem.CheckedChanged += new System.EventHandler(this.logsAdvancedDatasToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // clearErrorCodesToolStripMenuItem
            // 
            this.clearErrorCodesToolStripMenuItem.Name = "clearErrorCodesToolStripMenuItem";
            this.clearErrorCodesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.clearErrorCodesToolStripMenuItem.Text = "Clear";
            this.clearErrorCodesToolStripMenuItem.Click += new System.EventHandler(this.clearErrorCodesToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Controls.Add(this.checkBoxLogDatetime);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 33);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxLogDatetime
            // 
            this.checkBoxLogDatetime.AutoSize = true;
            this.checkBoxLogDatetime.Checked = true;
            this.checkBoxLogDatetime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLogDatetime.Location = new System.Drawing.Point(158, 9);
            this.checkBoxLogDatetime.Name = "checkBoxLogDatetime";
            this.checkBoxLogDatetime.Size = new System.Drawing.Size(89, 17);
            this.checkBoxLogDatetime.TabIndex = 2;
            this.checkBoxLogDatetime.Text = "Log Datetime";
            this.checkBoxLogDatetime.UseVisualStyleBackColor = true;
            this.checkBoxLogDatetime.CheckedChanged += new System.EventHandler(this.checkBoxLogDatetime_CheckedChanged);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(6, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Export Logs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(100, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Log Text File|*.txt";
            this.saveFileDialog1.Title = "Save Debug Log";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 33);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(342, 267);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 300);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDebug";
            this.Text = "Debug Logs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDebug_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDebug_FormClosed);
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmDebug_KeyUp);
            this.Move += new System.EventHandler(this.frmDebug_Move);
            this.Resize += new System.EventHandler(this.frmDebug_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    private void button1_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult result = saveFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            string ThisTxt = "";
            ThisTxt = this.richTextBox1.Text;

            StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false);
            writer.Write(ThisTxt);
            writer.Close();
            writer.Dispose();
            writer = null;
        }
    }

    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        /*if (this.frmMain_0.class10_settings_0.GetKeyPressed(e, "Copy"))
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            this.frmMain_0.LogThis("Logs copied to clipboard");
        }*/
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(richTextBox1.SelectedText);
        this.frmMain_0.LogThis("Logs copied to clipboard");
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        copyToolStripMenuItem.Enabled = true;
        if (richTextBox1.SelectedText == "" || richTextBox1.SelectedText == null) copyToolStripMenuItem.Enabled = false;
    }

    public void CopyLogToClip()
    {
        if (richTextBox1.SelectedText != null)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            this.frmMain_0.LogThis("Logs copied to clipboard");
        }
    }

    public void frmDebug_KeyUp(object sender, KeyEventArgs e)
    {
        if (this.frmMain_0.class10_settings_0.GetKeyPressed(e, "Copy"))
        //else if ((e.KeyCode == (Keys) Enum.Parse(typeof(Keys), "C")) && e.Control && (!e.Shift && !e.Alt))
        {
            CopyLogToClip();
        }
        else
        {
            e.Handled = false;
        }
    }

    private void logsAdvancedDatasToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        if (!loading2) this.class18_0.class10_settings_0.LogAdvancedDatas = this.logsAdvancedDatasToolStripMenuItem.Checked;
    }

    private void checkBoxLogDatetime_CheckedChanged(object sender, EventArgs e)
    {
        if (!loading2) this.class18_0.class10_settings_0.LogDatetime = this.checkBoxLogDatetime.Checked;
    }
}

