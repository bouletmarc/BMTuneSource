using Data;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmQuickSaveMain : Form
{
    private ToolStripButton btnClear;
    private ToolStripButton btnLoad;
    private ToolStripButton btnSave;
    private Class18 class18_0;
    private Class21_snap class21_snap_0;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridView grid;
    private IContainer icontainer_0;
    private ToolStrip toolStrip1;
    public bool loading = true;

    public frmQuickSaveMain()
    {
        this.InitializeComponent();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        this.class21_snap_0.method_3();
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        if (this.grid.SelectedCells.Count > 0)
        {
            this.class21_snap_0.method_6((int) this.grid.SelectedCells[0].Tag);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        this.class21_snap_0.method_2();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmQuickSave_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.class18_0.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.snapShots_Location = base.Location;
    }

    private void frmQuickSave_Load(object sender, EventArgs e)
    {
        if (this.class18_0.class10_settings_0.WindowedMode)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Dock = DockStyle.None;
            base.Location = this.class18_0.class10_settings_0.snapShots_Location;
        }
        else
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
        this.grid.Rows.Clear();
        ((VScrollBar) this.grid.Controls[1]).Enabled = false;
        ((VScrollBar) this.grid.Controls[1]).Visible = false;
        ((HScrollBar) this.grid.Controls[0]).Enabled = true;
        ((HScrollBar) this.grid.Controls[0]).Visible = true;
        this.method_2();
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_4();
        }
        loading = false;
    }

    private void frmQuickSave_Move(object sender, EventArgs e)
    {
    }

    private void frmQuickSave_Resize(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode && !loading)
                {
                    this.class18_0.class10_settings_0.snapShots_Location = base.Location;
                }
            }
        }
    }

    private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (this.grid.SelectedCells.Count > 0)
            {
                this.class21_snap_0.method_6((int) this.grid[this.grid.SelectedCells[0].ColumnIndex, this.grid.SelectedCells[0].RowIndex].Tag);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message);
        }
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuickSaveMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnLoad,
            this.btnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(39, 137);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 19);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(36, 19);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(36, 19);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(47, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowCellToolTips = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(334, 137);
            this.grid.TabIndex = 2;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 120F;
            this.Column1.HeaderText = "Date/Time";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.FillWeight = 139F;
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmQuickSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 137);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmQuickSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Snapshot List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuickSave_FormClosed);
            this.Load += new System.EventHandler(this.frmQuickSave_Load);
            this.Move += new System.EventHandler(this.frmQuickSave_Move);
            this.Resize += new System.EventHandler(this.frmQuickSave_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_0(ref Class21_snap class21_snap_1, ref Class18 class18_1)
    {
        this.class21_snap_0 = class21_snap_1;
        this.class21_snap_0.delegate63_0 += new Class21_snap.Delegate63(this.method_3);
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_2);
        this.class18_0.class11_u_0.delegate32_0 += new Class11_u.Delegate32(this.method_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1()
    {
    }

    private void method_2()
    {
        this.btnClear.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.btnLoad.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.btnSave.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
        this.grid.Enabled = this.class18_0.method_30_HasFileLoadedInBMTune();
    }

    private void method_3()
    {
        if (this.grid.ColumnCount > 0)
        {
            this.method_4();
        }
    }

    private void method_4()
    {
        this.grid.Rows.Clear();
        Collection<QuickSaveItem> QuickSaveItem_1 = this.class21_snap_0.method_5();
        for (int i = QuickSaveItem_1.Count - 1; i >= 0; i--)
        {
            this.grid.Rows.Add();
            this.grid.Rows[this.grid.Rows.Count - 1].Cells[0].Value = QuickSaveItem_1[i].time.ToShortTimeString();
            this.grid.Rows[this.grid.Rows.Count - 1].Cells[0].Tag = i;
            this.grid.Rows[this.grid.Rows.Count - 1].Cells[1].Value = QuickSaveItem_1[i].description;
            this.grid.Rows[this.grid.Rows.Count - 1].Height = 0x10;
        }
    }
}

