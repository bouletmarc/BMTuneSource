using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmErrorCodes : Form
{
    private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();
    private Class17 class17_0;
    private Class18 class18_0;
    private ToolStripMenuItem clearErrorCodesToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip1;
    private FrmMain frmMain_0;
    private DataGridView grid;
    private IContainer icontainer_0;
    private IContainer components;
    private Panel panel1;
    public Button button1;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column3;
    private Struct20 struct20_0 = new Struct20();

    public bool loading = true;

    internal frmErrorCodes()
    {
        this.InitializeComponent();
        this.backgroundWorker_0.WorkerReportsProgress = false;
        this.backgroundWorker_0.WorkerSupportsCancellation = false;
        this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);

    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        this.method_2((Struct20) e.Argument);
    }

    private void clearErrorCodesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Clear CEL Codes");
        this.class17_0.method_30();
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        this.clearErrorCodesToolStripMenuItem.Enabled = this.class17_0.method_34_GetConnected();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmErrorCodes_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.class18_0.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.errorCodes_Location = base.Location;
        this.frmMain_0.frmErrorCodes_0.Dispose();
        this.frmMain_0.frmErrorCodes_0 = null;
    }

    private void frmErrorCodes_Load(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.Dock = DockStyle.None;
                    base.Location = this.class18_0.class10_settings_0.errorCodes_Location;
                    base.Size = this.class18_0.class10_settings_0.errorCodes_Size;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Dock = DockStyle.Fill;
                }
            }
        }
        loading = false;

        this.grid.Rows.Clear();
        ((VScrollBar)this.grid.Controls[1]).Enabled = true;
        ((VScrollBar)this.grid.Controls[1]).Visible = true;
        ((HScrollBar)this.grid.Controls[0]).Enabled = true;
        ((HScrollBar)this.grid.Controls[0]).Visible = true;
        this.method_2(this.struct20_0);
    }

    private void frmErrorCodes_Move(object sender, EventArgs e)
    {
    }

    private void frmErrorCodes_Resize(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode && !loading)
                {
                    if (base.WindowState == FormWindowState.Normal)
                    {
                        this.class18_0.class10_settings_0.errorCodes_Size = base.Size;
                    }
                    this.class18_0.class10_settings_0.errorCodes_Location = base.Location;
                }
            }
        }
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrorCodes));
            this.grid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearErrorCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3});
            this.grid.ContextMenuStrip = this.contextMenuStrip1;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowCellToolTips = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(342, 167);
            this.grid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 70F;
            this.Column1.HeaderText = "CEL Code";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 70;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearErrorCodesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // clearErrorCodesToolStripMenuItem
            // 
            this.clearErrorCodesToolStripMenuItem.Name = "clearErrorCodesToolStripMenuItem";
            this.clearErrorCodesToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearErrorCodesToolStripMenuItem.Text = "Clear";
            this.clearErrorCodesToolStripMenuItem.Click += new System.EventHandler(this.clearErrorCodesToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 27);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clear CEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmErrorCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 167);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmErrorCodes";
            this.Text = "Error Codes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmErrorCodes_FormClosed);
            this.Load += new System.EventHandler(this.frmErrorCodes_Load);
            this.Move += new System.EventHandler(this.frmErrorCodes_Move);
            this.Resize += new System.EventHandler(this.frmErrorCodes_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    internal void method_0(ref Class18 class18_1, ref Class17 class17_1, ref FrmMain frmMain_1)
    {
        this.class18_0 = class18_1;
        this.frmMain_0 = frmMain_1;
        this.class17_0 = class17_1;
        this.class17_0.delegate45_0 += new Class17.Delegate45(this.method_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1(Struct20 struct20_1)
    {
        if (((struct20_1.byte_0 != this.struct20_0.byte_0) || (struct20_1.byte_1 != this.struct20_0.byte_1)) || ((struct20_1.byte_2 != this.struct20_0.byte_2) || (struct20_1.byte_3 != this.struct20_0.byte_3)))
        {
            this.struct20_0 = struct20_1;
            this.grid.Rows.Clear();
            this.backgroundWorker_0.RunWorkerAsync(this.struct20_0);
        }
    }

    private void method_2(Struct20 struct20_1)
    {
        if (this.class18_0 != null)
        {
            int num = 0;
            for (int i = 1; i <= 8; i++)
            {
                num++;
                if (this.class18_0.method_258(struct20_1.byte_0, i - 1))
                {
                    this.method_5(this.method_3(i), this.method_4(this.method_3(i)));
                }
            }
            for (int j = 1; j <= 8; j++)
            {
                num++;
                if (this.class18_0.method_258(struct20_1.byte_1, j - 1))
                {
                    this.method_5(this.method_3(j + 8), this.method_4(this.method_3(j + 8)));
                }
            }
            for (int k = 1; k <= 8; k++)
            {
                num++;
                if (this.class18_0.method_258(struct20_1.byte_2, k - 1))
                {
                    this.method_5(this.method_3((k + 8) + 8), this.method_4(this.method_3((k + 8) + 8)));
                }
            }
            for (int m = 1; m <= 8; m++)
            {
                num++;
                if (this.class18_0.method_258(struct20_1.byte_3, m - 1))
                {
                    this.method_5(this.method_3(((m + 8) + 8) + 8), this.method_4(this.method_3(((m + 8) + 8) + 8)));
                }
            }
        }
    }

    private int method_3(int int_0)
    {
        switch (int_0)
        {
            case 24:
                return 30;

            case 25:
                return 31;

            case 26:
                return 36;

            case 27:
                return 41;

            case 28:
                return 43;

            case 29:
                return 45;
        }
        if (int_0 > 29)
        {
            this.class18_0.class17_0.frmMain_0.LogThis("Error: Bitlocation did not convert to errorcode");
            //throw new Exception("Bitlocation did not convert to errorcode");
        }
        return int_0;
    }

    private string method_4(int int_0)
    {
        switch (int_0)
        {
            case 1:
                return "O2A - Oxygen Sensor #1";

            case 2:
                return "O2B - Oxygen Sensor #2";

            case 3:
                return "MAP - Manifold Absolute Pressure Sensor";

            case 4:
                return "CKP - Crank Position Sensor";

            case 5:
                return "MAP - Manifold Absolute Pressure Sensor";

            case 6:
                return "ECT - Engine Coolant Sensor";

            case 7:
                return "TPS - Throttle Position Sensor";

            case 8:
                return "TDC - Top Dead Center Sensor";

            case 9:
                return "CYP - Cylinder/Cam Sensor";

            case 10:
                return "IAT - Intake Air Temperature Sensor";

            case 12:
                return "EGR - Exhaust Gas Recirculation Lift Valve";

            case 13:
                return "BARO - Atmospheric Pressure Sensor";

            case 14:
                return "IAC - Idle Air Control Valve";

            case 15:
                return "ICM - Ignition Control Module";

            case 16:
                return "Fuel Injectors";

            case 17:
                return "VSS - Vehicule Speed Sensor";

            case 19:
                return "Automatic Transmission Lockup Control Valve";

            case 20:
                return "ELD - Electrical Load Detector";

            case 21:
                return "VTS - VTEC Solenoid";

            case 22:
                return "VTP - VTEC Pressure Valve";

            case 23:
                return "Knock Sensor";

            case 30:
                return "Automatic Transmission A Signal";

            case 31:
                return "Automatic Transmission B Signal";

            case 36:
                return "Traction Control";

            case 41:
                return "PO2H - Primary Oxygen Sensor Heater";

            case 43:
                return "Fuel Supply System";

            case 45:
                return "Fuel System too Rich or Lean";
        }
        return "Unknow error";
    }

    private void method_5(int int_0, string string_0)
    {
        if (this.grid.ColumnCount != 0)
        {
            this.grid.Rows.Add();
            this.grid.Rows[this.grid.Rows.Count - 1].Cells[0].Value = int_0;
            this.grid.Rows[this.grid.Rows.Count - 1].Cells[1].Value = string_0;
            this.grid.Rows[this.grid.Rows.Count - 1].Height = 0x12;
            this.grid.Invalidate();
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.class17_0.method_30();
    }
}

