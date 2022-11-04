using Data;
using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class ctrlAdvTable : UserControl
{
    private ToolStripMenuItem adjSelectionToolStripMenuItem;
    private ToolStripMenuItem adjSelectionToolStripMenuItem1;
    private bool HeaderIsGrayed;
    private bool HasHeader;
    private bool DatalogEnabled;
    private bool bool_3 = true;
    private bool bool_4 = true;
    private Class17 class17_0;
    private Class18 class18_0;
    private Class33_Sensors class33_Sensors_0;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem copyToolStripMenuItem;
    private double double_0 = 1.0;
    public ErrorProvider errorProvider_0;
    //private ctrlAdvGraph ctrlAdvGraph_0;
    private Form form_0;
    public DataGridView grid;
    private IContainer icontainer_0;
    private int int_0;
    private int int_1;
    public int int_2 = 0x20;
    private int int_3 = -1;
    private ToolStripMenuItem pasteToolStripMenuItem;
    private SensorsX sensors_0;
    private ToolStripMenuItem setSelectionToolStripMenuItem;
    public string[] string_0;
    public string[] string_1;
    private IContainer components;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem showInGraphToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;

    private ctrlAdvTable ctrlAdvTable_0;
    private frmAdvancedGraph frmAdvancedGraph_0;

    public event Delegate2 delegate2_0;
    public event Delegate1 delegate1_0;
    public event Delegate4 delegate4_0;
    public event Delegate5 delegate5_0;
    //public event Delegate3 delegate3_0;

    private DateTime LastCheck = DateTime.Now;

    public ctrlAdvTable()
    {
        this.InitializeComponent();
        ctrlAdvTable_0 = this;
        this.grid.SelectionChanged += new EventHandler(this.grid_SelectionChanged);
        this.grid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
    }

    private void adjSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmAdvTableAdd add = new frmAdvTableAdd(this.grid.SelectedCells, ref this.class18_0) {
            Tag = 1
        };
        add.ShowDialog();
        add.Dispose();
        add = null;
    }

    private void adjSelectionToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        frmAdvTableAdd add = new frmAdvTableAdd(this.grid.SelectedCells, ref this.class18_0) {
            Tag = 2
        };
        add.ShowDialog();
        add.Dispose();
        add = null;
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune() && (this.grid.GetCellCount(DataGridViewElementStates.Selected) > 0))
        {
            try
            {
                Clipboard.SetDataObject(CopyToClipboard());
                /*if (this.grid.GetClipboardContent() != null)
                {
                    if (this.grid.GetClipboardContent().GetData(DataFormats.Text) != null)
                        Clipboard.SetDataObject(this.grid.GetClipboardContent().GetData(DataFormats.Text));
                }*/
            }
            catch (Exception)
            {
                this.class18_0.class17_0.frmMain_0.LogThis("Unable to copy content to Clipboard");
                //throw new Exception("Unable to set Clipboard Data");
            }
        }
    }

    private string CopyToClipboard()
    {
        string newline = "\n";
        string tab = "\t";
        StringBuilder clipboard_string = new StringBuilder();

        for (int i = 0; i < this.grid.Rows.Count; i++)
        {
            int TabCount = 0;
            for (int i2 = 0; i2 < this.grid.Rows[i].Cells.Count; i2++)
            {
                if (this.grid.Rows[i].Cells[i2].Selected)
                {
                    if (TabCount > 0) clipboard_string.Append(tab);
                    clipboard_string.Append(this.grid.Rows[i].Cells[i2].Value);
                    TabCount++;
                }

                if (i2 == (this.grid.Rows[i].Cells.Count - 1)) clipboard_string.Append(newline);
            }
        }

        return clipboard_string.ToString();
    }

    private void ctrlAdvTable_Load(object sender, EventArgs e)
    {

    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            ((DataGridView)sender).BeginEdit(true);
        }
        catch { }
    }

    private void grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (this.frmAdvancedGraph_0 != null)
        {
            this.frmAdvancedGraph_0.ctrlAdvTable_0 = this;
            this.frmAdvancedGraph_0.Invalidate();
        }

        if (this.delegate4_0 != null)
        {
            this.delegate4_0(e);
        }
    }

    private void grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        if (((this.class18_0 != null) && this.class18_0.method_30_HasFileLoadedInBMTune()) && (this.delegate2_0 != null))
        {
            this.delegate2_0(e);
        }
    }

    private void grid_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
    {
        if (string.IsNullOrEmpty(this.grid[e.ColumnIndex, e.RowIndex].ErrorText))
        {
            if (this.delegate1_0 != null)
            {
                this.delegate1_0(e);
            }
            /*if (this.ctrlAdvGraph_0 != null)
            {
                this.ctrlAdvGraph_0.Refresh();
            }*/
        }
    }

    private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is DataGridViewTextBoxEditingControl)
        {
            e.Control.KeyPress += new KeyPressEventHandler(this.method_34);
        }
    }

    private void grid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control)
        {
            e.SuppressKeyPress = true;
        }
        if (this.class18_0.class10_settings_0.GetKeyPressed(e, "Increase Selected Cells"))
        {
            foreach (DataGridViewCell cell in this.grid.SelectedCells)
            {
                if (cell.RowIndex != 0)
                {
                    this.grid[cell.ColumnIndex, cell.RowIndex].Value = double.Parse(cell.Value.ToString()) + this.method_12();
                    this.grid.InvalidateCell(cell.ColumnIndex, cell.RowIndex);
                }
            }
            e.SuppressKeyPress = true;
        }
        else if (this.class18_0.class10_settings_0.GetKeyPressed(e, "Increase Selected Cells #2"))
        {
            foreach (DataGridViewCell cell2 in this.grid.SelectedCells)
            {
                if (cell2.RowIndex != 0)
                {
                    this.grid[cell2.ColumnIndex, cell2.RowIndex].Value = double.Parse(cell2.Value.ToString()) + this.method_12();
                    this.grid.InvalidateCell(cell2.ColumnIndex, cell2.RowIndex);
                }
            }
            e.SuppressKeyPress = true;
        }
        else if (this.class18_0.class10_settings_0.GetKeyPressed(e, "Decrease Selected Cells"))
        {
            foreach (DataGridViewCell cell3 in this.grid.SelectedCells)
            {
                if (cell3.RowIndex != 0)
                {
                    this.grid[cell3.ColumnIndex, cell3.RowIndex].Value = double.Parse(cell3.Value.ToString()) - this.method_12();
                    this.grid.InvalidateCell(cell3.ColumnIndex, cell3.RowIndex);
                }
            }
            e.SuppressKeyPress = true;
        }
        else if (this.class18_0.class10_settings_0.GetKeyPressed(e, "Decrease Selected Cells #2"))
        {
            foreach (DataGridViewCell cell4 in this.grid.SelectedCells)
            {
                if (cell4.RowIndex != 0)
                {
                    this.grid[cell4.ColumnIndex, cell4.RowIndex].Value = double.Parse(cell4.Value.ToString()) - this.method_12();
                    this.grid.InvalidateCell(cell4.ColumnIndex, cell4.RowIndex);
                }
            }
            e.SuppressKeyPress = true;
        }
    }

    private void grid_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (((e.KeyChar == ',') || (e.KeyChar == '.')) || (((e.KeyChar == '-') || (e.KeyChar == ' ')) || this.class18_0.method_255(e.KeyChar.ToString())))
        {
            ((DataGridView) sender).BeginEdit(true);
            e.Handled = false;
        }
        else
        {
            ((DataGridView) sender).CancelEdit();
            e.Handled = true;
        }
    }

    public void grid_SelectionChanged(object sender, EventArgs e)
    {
        if (this.delegate5_0 != null)
        {
            this.delegate5_0(this.grid.SelectedCells);
        }
        /*if (this.ctrlAdvGraph_0 != null)
        {
            if (base.Name != this.ctrlAdvGraph_0.Tag.ToString())
            {
                this.showInGraphToolStripMenuItem_Click(null, null);
            }
            this.ctrlAdvGraph_0.Invalidate();
        }*/
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.grid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.setSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjSelectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showInGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.GridColor = System.Drawing.SystemColors.ControlText;
            this.errorProvider_0.SetIconAlignment(this.grid, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.ShowCellToolTips = false;
            this.grid.Size = new System.Drawing.Size(173, 94);
            this.grid.TabIndex = 0;
            this.grid.VirtualMode = true;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_CellValidating);
            this.grid.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.grid_CellValueNeeded);
            this.grid.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.grid_CellValuePushed);
            this.grid.EnabledChanged += new System.EventHandler(this.grid_EnabledChanged);
            this.grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.grid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grid_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator2,
            this.setSelectionToolStripMenuItem,
            this.adjSelectionToolStripMenuItem,
            this.adjSelectionToolStripMenuItem1,
            this.toolStripSeparator1,
            this.showInGraphToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 148);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // setSelectionToolStripMenuItem
            // 
            this.setSelectionToolStripMenuItem.Name = "setSelectionToolStripMenuItem";
            this.setSelectionToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.setSelectionToolStripMenuItem.Text = "Set Selection";
            this.setSelectionToolStripMenuItem.Click += new System.EventHandler(this.setSelectionToolStripMenuItem_Click);
            // 
            // adjSelectionToolStripMenuItem
            // 
            this.adjSelectionToolStripMenuItem.Name = "adjSelectionToolStripMenuItem";
            this.adjSelectionToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.adjSelectionToolStripMenuItem.Text = "Adjust Selection(-/+)";
            this.adjSelectionToolStripMenuItem.Click += new System.EventHandler(this.adjSelectionToolStripMenuItem_Click);
            // 
            // adjSelectionToolStripMenuItem1
            // 
            this.adjSelectionToolStripMenuItem1.Name = "adjSelectionToolStripMenuItem1";
            this.adjSelectionToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.adjSelectionToolStripMenuItem1.Text = "Adjust Selection(%)";
            this.adjSelectionToolStripMenuItem1.Click += new System.EventHandler(this.adjSelectionToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // showInGraphToolStripMenuItem
            // 
            this.showInGraphToolStripMenuItem.Name = "showInGraphToolStripMenuItem";
            this.showInGraphToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showInGraphToolStripMenuItem.Text = "Show in Graph";
            this.showInGraphToolStripMenuItem.Click += new System.EventHandler(this.showInGraphToolStripMenuItem_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // ctrlAdvTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.grid);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlAdvTable";
            this.Size = new System.Drawing.Size(173, 94);
            this.Load += new System.EventHandler(this.ctrlAdvTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);

    }

    private void ReloadShortcuts()
    {
        if (this.class18_0.class10_settings_0.GetKeySettings("Copy"))
        {
            Keys CtrlKey = 0; if (this.class18_0.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class18_0.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class18_0.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.copyToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class18_0.class10_settings_0.Shortcut_KeyPressed)));
        }
        if (this.class18_0.class10_settings_0.GetKeySettings("Paste"))
        {
            Keys CtrlKey = 0; if (this.class18_0.class10_settings_0.Shortcut_PressCTRL) CtrlKey = Keys.Control;
            Keys AltKey = 0; if (this.class18_0.class10_settings_0.Shortcut_PressALT) AltKey = Keys.Alt;
            Keys ShiftKey = 0; if (this.class18_0.class10_settings_0.Shortcut_PressSHIFT) ShiftKey = Keys.Shift;
            this.pasteToolStripMenuItem.ShortcutKeys = ((Keys)((CtrlKey | AltKey | ShiftKey | this.class18_0.class10_settings_0.Shortcut_KeyPressed)));
        }
    }

    internal void method_0(ref Class18 class18_1, ref Form form_1)
    {
        this.class18_0 = class18_1;
        this.class17_0 = this.class18_0.class17_0;
        this.class33_Sensors_0 = this.class17_0.class33_Sensors;
        ReloadShortcuts();
        this.class18_0.class17_0.delegate54_0 += new Class17.Delegate54(this.method_2);
        this.form_0 = form_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    internal void method_1(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;
        this.class17_0 = this.class18_0.class17_0;
        this.class33_Sensors_0 = this.class17_0.class33_Sensors;
        this.class18_0.class17_0.delegate54_0 += new Class17.Delegate54(this.method_2);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    public double method_10()
    {
        double num = 10000000.0;
        for (int i = 0; i < this.grid.Columns.Count; i++)
        {
            for (int j = 1; j < this.grid.Rows.Count; j++)
            {
                if (double.Parse(this.grid[i, j].Value.ToString()) < num)
                {
                    num = double.Parse(this.grid[i, j].Value.ToString());
                }
            }
        }
        return Math.Round(num, 0);
    }

    public string method_11()
    {
        return this.string_1[1];
    }

    public double method_12()
    {
        return this.double_0;
    }

    public void method_SetIncreaser(double double_1)
    {
        this.double_0 = double_1;
    }

    public double method_14(int int_4, int int_5)
    {
        return double.Parse(this.grid[int_4, int_5].Value.ToString());
    }

    public bool method_15(int int_4, int int_5)
    {
        return this.grid[int_4, int_5].Selected;
    }

    public bool method_16()
    {
        return this.HasHeader;
    }

    public void method_HasHeader(bool bool_5)
    {
        this.HasHeader = bool_5;
        this.grid.RowHeadersVisible = bool_5;
    }

    public bool method_GetHeaderGrayed()
    {
        return this.HeaderIsGrayed;
    }

    public void method_HeaderGrayed(bool bool_5)
    {
        this.HeaderIsGrayed = bool_5;
    }

    internal void method_2(Struct12 struct12_0)
    {
        if ((DateTime.Now - LastCheck).TotalMilliseconds >= this.class18_0.class10_settings_0.int_ActiveDatalog[4])
        {
            LastCheck = DateTime.Now;
            if ((this.method_20() & (this.grid.ColumnCount > 0)) & (this.grid.Rows.Count > 0))
            {
                double num2;
                int num = 0;
                double num3 = 0.0;
                double num4 = this.method_32(struct12_0, this.method_24());
                if (!this.bool_4)
                {
                    if (num4 <= double.Parse(this.grid[this.grid.ColumnCount - 1, 0].Value.ToString()))
                    {
                        num = this.grid.ColumnCount - 1;
                        this.method_31(num);
                    }
                    else if (num4 >= double.Parse(this.grid[0, 0].Value.ToString()))
                    {
                        num = 0;
                        this.method_31(num);
                    }
                    else
                    {
                        for (int i = this.grid.ColumnCount - 1; i > -1; i--)
                        {
                            num2 = double.Parse(this.grid[i, 0].Value.ToString());
                            if ((i - 1) > 0)
                            {
                                num3 = double.Parse(this.grid[i - 1, 0].Value.ToString());
                            }
                            if (num4 <= ((num2 + num3) / 2.0))
                            {
                                num = i;
                                this.method_31(num);
                                return;
                            }
                        }
                    }
                }
                else if (num4 <= double.Parse(this.grid[0, 0].Value.ToString()))
                {
                    num = 0;
                    this.method_31(num);
                }
                else if (num4 >= double.Parse(this.grid[this.grid.ColumnCount - 1, 0].Value.ToString()))
                {
                    num = this.grid.ColumnCount - 1;
                    this.method_31(num);
                }
                else
                {
                    for (int j = 0; j < this.grid.ColumnCount; j++)
                    {
                        num2 = double.Parse(this.grid[j, 0].Value.ToString());
                        if ((j + 1) < this.grid.ColumnCount)
                        {
                            num3 = double.Parse(this.grid[j + 1, 0].Value.ToString());
                        }
                        if (num4 <= ((num2 + num3) / 2.0))
                        {
                            num = j;
                            this.method_31(num);
                            return;
                        }
                    }
                }
            }
        }
    }

    public bool method_20()
    {
        return this.DatalogEnabled;
    }

    public void method_21(bool bool_5)
    {
        this.DatalogEnabled = bool_5;
    }

    public bool method_22()
    {
        return this.bool_4;
    }

    public void method_23(bool bool_5)
    {
        this.bool_4 = bool_5;
    }

    public SensorsX method_24()
    {
        return this.sensors_0;
    }

    public void method_SetSensor(SensorsX sensors_1)
    {
        this.sensors_0 = sensors_1;
    }

    public void method_DisableHeader()
    {
        this.grid.Invalidate();
        this.grid.ColumnHeadersVisible = false;
        /*if (this.ctrlAdvGraph_0 != null)
        {
            this.ctrlAdvGraph_0.Refresh();
        }*/
    }

    public int method_27()
    {
        int num = 0;
        return (num + ((this.grid.Columns.Count * this.grid.Columns[0].Width) + (this.grid.Columns.Count * 3)));
    }

    public void method_Load()
    {
        try
        {
            this.grid.ColumnHeadersVisible = false;
            this.grid.Rows.Clear();
            this.grid.Columns.Clear();
            for (int i = 0; i < this.method_3(); i++)
            {
                this.grid.Columns.Add("col" + i.ToString(), this.string_0[i]);
                this.grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.grid.Columns[i].Width = this.int_2;
            }
            for (int j = 0; j < this.method_5(); j++)
            {
                this.grid.Rows.Add();
                if (this.HasHeader)
                {
                    this.grid.Rows[j].HeaderCell.Value = this.string_1[j];
                }
                if (this.HeaderIsGrayed && (j == 0))
                {
                    this.grid.Rows[0].DefaultCellStyle.BackColor = SystemColors.Control;
                }
                this.grid.Rows[j].Height = 20;
            }
        }
        catch (Exception)
        {
        }
    }

    public bool method_29()
    {
        return this.bool_3;
    }

    public int method_3()
    {
        return this.int_0;
    }

    public void method_30(bool bool_5)
    {
        this.bool_3 = bool_5;
    }

    private void method_31(int int_4)
    {
        if (int_4 != this.int_3)
        {
            if (this.int_3 != -1)
            {
                for (int j = 1; j < this.grid.Rows.Count; j++)
                {
                    if (j == 0)
                    {
                        this.grid[this.int_3, j].Style.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        this.grid[this.int_3, j].Style.BackColor = Color.White;
                    }
                    this.grid.InvalidateCell(this.int_3, j);
                }
            }
            for (int i = 1; i < this.grid.Rows.Count; i++)
            {
                this.grid[int_4, i].Style.BackColor = this.class18_0.class10_settings_0.color_Trace;
                this.int_3 = int_4;
            }
        }
    }

    private double method_32(Struct12 struct12_0, SensorsX sensors_1)
    {
        switch (sensors_1)
        {
            /*case Sensors.rpm:
                return (double) this.class18_Sensors.GetSensors_VALUE(Sensors.rpm, struct12_0);

            case Sensors.gear:
                return (double)this.class18_Sensors.GetSensors_VALUE(Sensors.gear, struct12_0);

            case Sensors.boost:
                return (double) this.class18_0.method_245(this.class18_0.method_206(struct12_0.byte_4));

            case Sensors.ect:
                return this.class18_Sensors.GetSensors_VALUE(Sensors.ect, struct12_0);

            case Sensors.iat:
                return this.class18_Sensors.GetSensors_VALUE(Sensors.iat, struct12_0);

            case Sensors.batV:
                return this.class18_Sensors.GetSensors_VALUE(Sensors.batV, struct12_0);*/

            //###########################################################
            //###########################################################
            //###########################################################

            case SensorsX.rpmX:
                return (double) this.class33_Sensors_0.RPM;

            case SensorsX.gearX:
                return (double)this.class33_Sensors_0.Gear;

            case SensorsX.boostX:
                return (double) this.class18_0.method_245(this.class18_0.method_206(struct12_0.byte_4));

            case SensorsX.ectX:
                return this.class33_Sensors_0.ECT;

            case SensorsX.iatX:
                return this.class33_Sensors_0.IAT;

            case SensorsX.batV:
                return this.class33_Sensors_0.BatV;
        }
        return 0.0;
    }

    private void method_33(object sender, DataGridViewCellMouseEventArgs e)
    {
        ((DataGridView) sender).BeginEdit(true);
    }

    private void method_34(object sender, KeyPressEventArgs e)
    {
        if (((((e.KeyChar == ',') || (e.KeyChar == '.')) || ((e.KeyChar == '-') || (e.KeyChar == '1'))) || (((e.KeyChar == '2') || (e.KeyChar == '3')) || ((e.KeyChar == '4') || (e.KeyChar == '5')))) || ((((e.KeyChar == '6') || (e.KeyChar == '7')) || ((e.KeyChar == '8') || (e.KeyChar == '9'))) || ((e.KeyChar == '0') || (e.KeyChar == '\b'))))
        {
            e.Handled = false;
        }
        else
        {
            e.Handled = true;
        }
    }

    private int[] method_35()
    {
        DataGridViewSelectedCellCollection selectedCells = this.grid.SelectedCells;
        int columnIndex = 0xff;
        int num2 = 0;
        int rowIndex = 0xff;
        int num4 = 0;
        foreach (DataGridViewCell cell in selectedCells)
        {
            if (cell.ColumnIndex < columnIndex)
            {
                columnIndex = cell.ColumnIndex;
            }
            if (cell.RowIndex < rowIndex)
            {
                rowIndex = cell.RowIndex;
            }
        }
        foreach (DataGridViewCell cell2 in selectedCells)
        {
            if (cell2.ColumnIndex > num2)
            {
                num2 = cell2.ColumnIndex;
            }
            if (cell2.RowIndex > num4)
            {
                num4 = cell2.RowIndex;
            }
        }
        return new int[] { columnIndex, rowIndex, num2, num4 };
    }

    public void method_ColumnsNumber(int int_4)
    {
        this.int_0 = int_4;
        this.string_0 = new string[this.int_0];
    }

    public int method_5()
    {
        return this.int_1;
    }

    public void method_RowsNumber(int int_4)
    {
        this.int_1 = int_4;
        this.string_1 = new string[int_4];
    }

    public double method_7()
    {
        double num = 0.0;
        for (int i = 0; i < this.grid.Columns.Count; i++)
        {
            if (double.Parse(this.grid[i, 0].Value.ToString()) > num)
            {
                num = double.Parse(this.grid[i, 0].Value.ToString());
            }
        }
        if (num > Math.Round(num, 0))
        {
            num++;
        }
        if ((this.method_8() == 0.0) && (num == 0.0))
        {
            num = 1.0;
        }
        return num;
    }

    public double method_8()
    {
        double num = 1000000.0;
        for (int i = 0; i < this.grid.Columns.Count; i++)
        {
            if (double.Parse(this.grid[i, 0].Value.ToString()) < num)
            {
                num = double.Parse(this.grid[i, 0].Value.ToString());
            }
        }
        if (num < Math.Round(num, 0))
        {
            num--;
        }
        return num;
    }

    public double method_9()
    {
        double num = 0.0;
        for (int i = 0; i < this.grid.Columns.Count; i++)
        {
            for (int j = 1; j < this.grid.Rows.Count; j++)
            {
                if (double.Parse(this.grid[i, j].Value.ToString()) > num)
                {
                    num = double.Parse(this.grid[i, j].Value.ToString());
                }
            }
        }
        return Math.Round(num, 0);
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try {
            if (this.class18_0.method_30_HasFileLoadedInBMTune())
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
                    return;
                }
                string data = (string) dataObject.GetData(DataFormats.Text);
                if (!(data == string.Empty) && (data != null))
                {
                    DataGridViewSelectedCellCollection selectedCells = this.grid.SelectedCells;
                    int[] numArray = this.method_35();
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
                        this.class18_0.method_156("Advance Table Paste", true);
                        for (int i = numArray[1]; i <= numArray[3]; i++)
                        {
                            strArray2 = strArray[num3].Split(chArray2, StringSplitOptions.RemoveEmptyEntries);
                            index = 0;
                            for (int j = numArray[0]; j <= numArray[2]; j++)
                            {
                                this.grid[j, i].Value = strArray2[index];
                                index++;
                            }
                            num3++;
                        }
                        this.class18_0.method_154();
                        this.Invalidate();
                    }
                }
            }
        }
        catch
        {
            MessageBox.Show(Form.ActiveForm, "Unable to paste Clipboard Data");
        }
    }

    private void setSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmAdvTableAdd add = new frmAdvTableAdd(this.grid.SelectedCells, ref this.class18_0) {
            Tag = 3
        };
        add.ShowDialog();
        add.Dispose();
        add = null;
    }

    public delegate void Delegate1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0);

    public delegate void Delegate2(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0);
    
    public delegate void Delegate4(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0);

    public delegate void Delegate5(DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection_0);

    //public delegate void Delegate3(ctrlAdvGraph ctrlAdvGraph_0);

    private void showInGraphToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*this.ctrlAdvGraph_0 = new ctrlAdvGraph();
        float num = (float)this.method_10();
        if (num < 0f)
        {
            num -= (float)Math.Abs((double)(this.method_10() / 5.0));
        }
        else
        {
            num -= (float)(this.method_10() / 5.0);
        }
        this.ctrlAdvGraph_0.method_4((float)Math.Floor((double)num));
        this.ctrlAdvGraph_0.method_6((float)Math.Ceiling((double)(((float)this.method_9()) + ((float)(this.method_9() / 5.0)))));
        this.ctrlAdvGraph_0.method_8(this.method_11());
        this.ctrlAdvGraph_0.method_2(new ctrlAdvTable[] { this });
        this.ctrlAdvGraph_0.method_0(ref this.class18_0, ref this.class18_0.class10_0);
        this.ctrlAdvGraph_0.Tag = base.Name;
        if (this.delegate3_0 != null)
        {
            this.delegate3_0(this.ctrlAdvGraph_0);
        }*/

        ShowAdvancedGraph();
    }


    public void ShowAdvancedGraph()
    {
        if (this.frmAdvancedGraph_0 != null)
        {
            this.frmAdvancedGraph_0.Dispose();
            this.frmAdvancedGraph_0 = null;
        }

        this.frmAdvancedGraph_0 = new frmAdvancedGraph(ref this.class18_0, ref this.ctrlAdvTable_0);
        this.frmAdvancedGraph_0.Show();
        this.frmAdvancedGraph_0.Focus();
    }

    private void grid_EnabledChanged(object sender, EventArgs e)
    {
        if (!grid.Enabled) {
            grid.DefaultCellStyle.BackColor = SystemColors.Control;
            grid.DefaultCellStyle.ForeColor = SystemColors.GrayText;
            grid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
            grid.CurrentCell = null;
            grid.ReadOnly = true;
            grid.EnableHeadersVisualStyles = false;
        }
        else {
            grid.DefaultCellStyle.BackColor = SystemColors.Window;
            grid.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            grid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
            grid.ReadOnly = false;
            grid.EnableHeadersVisualStyles = true;
        }
    }
}

