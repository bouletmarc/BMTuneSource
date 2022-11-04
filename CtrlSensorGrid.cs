using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class CtrlSensorGrid : UserControl
{
    private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();
    private bool bool_0;
    private bool bool_1;
    private int int_0;
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private Class33_Sensors class33_Sensors_0;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridView grid;
    private IContainer icontainer_0;

    public event Delegate68 delegate68_0;

    private DateTime LastCheck = DateTime.Now;

    public CtrlSensorGrid()
    {
        this.InitializeComponent();
        this.grid.DataError += new DataGridViewDataErrorEventHandler(this.grid_DataError);
        base.Resize += new EventHandler(this.CtrlSensorGrid_Resize);
        base.HandleCreated += new EventHandler(this.CtrlSensorGrid_HandleCreated);
        base.HandleDestroyed += new EventHandler(this.CtrlSensorGrid_HandleDestroyed);
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        Struct12 argument = (Struct12) e.Argument;
        this.method_10(SensorsX.rpmX, (long)argument.ushort_0_E6_7);
        this.method_9(SensorsX.ectX, argument.byte_0);
        this.method_9(SensorsX.iatX, argument.byte_1);
    }

    private void CtrlSensorGrid_HandleCreated(object sender, EventArgs e)
    {
        this.bool_1 = true;
    }

    private void CtrlSensorGrid_HandleDestroyed(object sender, EventArgs e)
    {
        this.bool_1 = false;
    }

    private void CtrlSensorGrid_Load(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if ((this.grid.Rows.Count > 0) && (this.grid.Columns.Count > 0))
            {
                this.grid.Rows.Clear();
            }
            this.method_8(true);
        }
    }

    private void CtrlSensorGrid_Resize(object sender, EventArgs e)
    {
        this.method_3();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    ~CtrlSensorGrid()
    {
        this.class18_0.delegate58_0 -= new Class18.Delegate58(this.method_12);
        this.class10_settings_0.delegate14_0 -= new Class10_settings.Delegate14(this.method_7);
        this.class17_0.delegate54_0 -= new Class17.Delegate54(this.method_5);
        this.class10_settings_0 = null;
        this.class18_0 = null;
        this.class17_0 = null;
        this.grid.Dispose();
        this.grid = null;
    }

    private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if ((this.method_11(SensorsX.mil) == e.RowIndex) && (this.delegate68_0 != null))
        {
            this.delegate68_0();
        }
        if (this.class17_0.method_63_HasLogsFileOpen() && (e.RowIndex != -1))
        {
            if (this.method_11(SensorsX.frame) == e.RowIndex)
            {
                this.grid[0, e.RowIndex].ReadOnly = true;
                this.grid[1, e.RowIndex].ReadOnly = false;
                this.grid.ReadOnly = false;
            }
            else
            {
                this.grid[1, e.RowIndex].ReadOnly = true;
                this.grid.ReadOnly = true;
            }
        }
    }

    private void grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (this.grid.CurrentCell.IsInEditMode)
        {
            if (!this.class18_0.method_252(e.FormattedValue.ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Form.ActiveForm, "Please enter a valid frame index", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                e.Cancel = false;
                if (this.class17_0.method_63_HasLogsFileOpen())
                {
                    long num = long.Parse(e.FormattedValue.ToString());
                    if (num <= this.class17_0.method_65())
                    {
                        this.class17_0.method_69(num);
                    }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show(Form.ActiveForm, "Please enter a valid frame index. Max frame:" + this.class17_0.method_65().ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }
    }

    private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        this.backgroundWorker_0.WorkerReportsProgress = false;
        this.backgroundWorker_0.WorkerSupportsCancellation = false;
        this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grid.ColumnHeadersHeight = 25;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.DefaultCellStyle = dataGridViewCellStyle6;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grid.GridColor = System.Drawing.Color.Silver;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(178, 483);
            this.grid.TabIndex = 0;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_CellValidating);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 85F;
            this.Column1.HeaderText = "Data";
            this.Column1.MinimumWidth = 85;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 85;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 65F;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CtrlSensorGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtrlSensorGrid";
            this.Size = new System.Drawing.Size(178, 483);
            this.Load += new System.EventHandler(this.CtrlSensorGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

    }

    public void method_0()
    {
        this.class18_0.delegate58_0 -= new Class18.Delegate58(this.method_12);
        this.class10_settings_0.delegate14_0 -= new Class10_settings.Delegate14(this.method_7);
        this.class17_0.delegate54_0 -= new Class17.Delegate54(this.method_5);
        this.class17_0.delegate53_0 -= new Class17.Delegate53(this.method_2);
    }

    internal void method_1(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1)
    {
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_12);
        this.class10_settings_0 = class10_1;
        this.class10_settings_0.delegate14_0 += new Class10_settings.Delegate14(this.method_7);
        this.class17_0 = class17_1;
        this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_5);
        this.class17_0.delegate53_0 += new Class17.Delegate53(this.method_2);

        this.class33_Sensors_0 = this.class17_0.class33_Sensors;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private Color SetColor(int rows, double Value1, double Value2, double Value3)
    {
        Color ThisColor = this.class18_0.method_234(Value1, Value2, Value3);
        if (ThisColor == Color.White)
            return this.grid.Rows[rows].Cells[0].Style.BackColor;

        return ThisColor;
    }

    private void method_10(SensorsX sensors_0, long long_0)
    {
        string str;
        switch (sensors_0)
        {
            /*case Sensors.rpm:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.RPM;
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)this.class18_Sensors.RPM, (double) this.class10_0.method_20(sensors_0), (double) this.class10_0.method_22(sensors_0));
                return;

            case Sensors.injDur:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.InjDurr.ToString("0.00") + " ms";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double) this.class18_0.method_224((int) long_0), (double) this.class10_0.method_20(sensors_0), (double) this.class10_0.method_22(sensors_0));
                return;

            case Sensors.injDuty:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.InjDuty + " %";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double) this.class18_0.method_225((int) long_0, this.class18_Sensors.RPM, 0), (double) this.class10_0.method_20(sensors_0), (double) this.class10_0.method_22(sensors_0));
                return;

            case Sensors.injFV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.InjFV.ToString("0.00");
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double) ((int) this.class18_0.method_223((int) long_0)), (double) this.class10_0.method_20(sensors_0), (double) this.class10_0.method_22(sensors_0));
                return;

            case Sensors.frame:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.Frame;
                return;

            case Sensors.duration:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.Duration;
                return;

            case Sensors.interval:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.Interval + " mS";
                return;

            case Sensors.iatFc:
                if (this.class10_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.IATFC.ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.IATFC.ToString("0.00");
                return;

            case Sensors.o2Short:
                if (this.class10_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.O2Short.ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.O2Short.ToString("0.00");
                return;

            case Sensors.o2Long:
                if (this.class10_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.O2Long.ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_Sensors.O2Long.ToString("0.00");
                return;*/


            //#################################################

            case SensorsX.rpmX:
                this.int_0 = this.class18_0.method_218(long_0);
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.int_0;
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)this.int_0, (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.injDur:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = Math.Round((double)this.class18_0.method_224((int)long_0), 2).ToString("0.00") + " ms";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)this.class18_0.method_224((int)long_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.injDuty:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = Math.Round((double)this.class18_0.method_225((int)long_0, this.int_0, 0), 0) + " %";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)this.class18_0.method_225((int)long_0, this.int_0, 0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.injFV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_223((int)long_0).ToString("0.00");
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)((int)this.class18_0.method_223((int)long_0)), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.frame:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = long_0;
                return;

            case SensorsX.duration:
                str = TimeSpan.FromMilliseconds((double)long_0).ToString();
                if (str.Length <= 8)
                {
                    str = str + ".000";
                    break;
                }
                str = str.Remove(str.Length - 5, 5);
                break;

            case SensorsX.interval:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = long_0 + " mS";
                return;

            case SensorsX.iatFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_203(long_0, Enum6.const_0).ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_203(long_0, Enum6.const_0).ToString("0.00");
                return;

            case SensorsX.o2Short:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_203(long_0, Enum6.const_0).ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_203(long_0, Enum6.const_0).ToString("0.00");
                return;

            case SensorsX.o2Long:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_203(long_0, Enum6.const_0).ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_203(long_0, Enum6.const_0).ToString("0.00");
                return;

            default:
                return;
        }
        this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = str;
    }

    private int method_11(SensorsX sensors_0)
    {
        for (int i = 0; i < this.grid.Rows.Count; i++)
        {
            if ((this.grid.Rows[i].Cells[0].Tag != null) && (((int) this.grid.Rows[i].Cells[0].Tag) == (int) sensors_0))
            {
                return i;
            }
        }
        this.class18_0.class17_0.frmMain_0.LogThis("Error: Can't find the row for sensor '" + sensors_0.ToString() + "'");
        return 0;
        //throw new Exception("Can't find the row for sensor: " + sensors_0.ToString());
    }

    private int method_11_2(int sensors_0)
    {
        for (int i = 0; i < this.grid.Rows.Count; i++)
        {
            if ((this.grid.Rows[i].Cells[0].Tag != null) && (((int)this.grid.Rows[i].Cells[0].Tag) == sensors_0))
            {
                return i;
            }
        }
        this.class18_0.class17_0.frmMain_0.LogThis("Error: Can't find the row for sensor '" + sensors_0.ToString() + "'");
        return 0;
        //throw new Exception("Can't find the row for sensor: " + sensors_0.ToString());
    }

    private void method_12()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.CtrlSensorGrid_Load(null, null);
        }
    }

    private void method_2(long long_0, string string_0)
    {
        if (!this.class17_0.method_63_HasLogsFileOpen())
        {
            this.CtrlSensorGrid_Load(null, null);
        }
    }

    internal void method_3()
    {
        this.grid.AutoResizeColumns();
    }

    internal void method_4()
    {
        this.CtrlSensorGrid_Load(null, null);
    }

    private void method_5(Struct12 struct12_0)
    {
        if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && (DateTime.Now - LastCheck).TotalMilliseconds >= this.class10_settings_0.int_ActiveDatalog[2]))
        {
            LastCheck = DateTime.Now;
            if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[2]))
            {
                if (this.bool_1)
                {
                    try
                    {
                        base.Invoke(new Delegate69(this.method_6), new object[] { struct12_0 });
                    }
                    catch { }
                }
            }
        }
    }

    private bool IsInRange(SensorsX ThisS)
    {
        int StartAt = (this.grid.VerticalScrollingOffset / this.grid.Rows[0].Height);
        int VisibleCount = (this.grid.Height / this.grid.Rows[0].Height);
        int EndAt = (StartAt + VisibleCount);

        if (StartAt <= this.method_11(ThisS) && EndAt >= this.method_11(ThisS)) return true;
        return false;
    }

    private void method_6(Struct12 struct12_0)
    {
        if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[2]))
        {
            if (class17_0.frmMain_0.IsPageFocused("Datalog"))
            {
                if (this.class18_0.method_30_HasFileLoadedInBMTune() && (this.grid.RowCount >= 60))
                {
                    if (IsInRange(SensorsX.rpmX)) this.method_10(SensorsX.rpmX, (long)struct12_0.ushort_0_E6_7);
                    if (IsInRange(SensorsX.ectX)) this.method_9(SensorsX.ectX, struct12_0.byte_0);
                    if (IsInRange(SensorsX.iatX)) this.method_9(SensorsX.iatX, struct12_0.byte_1);
                    if (IsInRange(SensorsX.tpsX)) this.method_9(SensorsX.tpsX, struct12_0.byte_5);
                    if (IsInRange(SensorsX.tpsV)) this.method_9(SensorsX.tpsV, struct12_0.byte_5);
                    if (IsInRange(SensorsX.ignFnl)) this.method_9(SensorsX.ignFnl, struct12_0.byte_15_E19);
                    if (IsInRange(SensorsX.ignTbl)) this.method_9(SensorsX.ignTbl, struct12_0.byte_16_E20);
                    if (IsInRange(SensorsX.vssX)) this.method_9(SensorsX.vssX, struct12_0.byte_14_E16);
                    if (IsInRange(SensorsX.gearX)) this.method_9(SensorsX.gearX, struct12_0.byte_20);
                    if (IsInRange(SensorsX.injFV)) this.method_10(SensorsX.injFV, (long)struct12_0.ushort_1_E17_18);
                    if (IsInRange(SensorsX.injDur)) this.method_10(SensorsX.injDur, (long)struct12_0.ushort_1_E17_18);
                    if (IsInRange(SensorsX.injDuty)) this.method_10(SensorsX.injDuty, (long)struct12_0.ushort_1_E17_18);
                    if ((this.class10_settings_0.wbinput_0 != WBinput.o2Input) || this.class10_settings_0.bool_25)
                        if (IsInRange(SensorsX.ecuO2V)) this.method_9(SensorsX.ecuO2V, struct12_0.byte_2);
                    if ((this.class10_settings_0.wbinput_0 != WBinput.o2Input) && !this.class10_settings_0.bool_25)
                        if (IsInRange(SensorsX.wbO2V)) this.method_9(SensorsX.wbO2V, struct12_0.byte_43);
                    if (IsInRange(SensorsX.afr)) this.method_9(SensorsX.afr, struct12_0.byte_43);
                    if (IsInRange(SensorsX.mapV)) this.method_9(SensorsX.mapV, struct12_0.byte_4);
                    if (IsInRange(SensorsX.mapX)) this.method_9(SensorsX.mapX, struct12_0.byte_4);
                    if (IsInRange(SensorsX.boostX)) this.method_9(SensorsX.boostX, struct12_0.byte_4);
                    if (IsInRange(SensorsX.paX)) this.method_9(SensorsX.paX, struct12_0.byte_3);
                    if (IsInRange(SensorsX.frame)) this.method_10(SensorsX.frame, struct12_0.long_5);
                    if (IsInRange(SensorsX.interval)) this.method_10(SensorsX.interval, struct12_0.long_4);
                    if (IsInRange(SensorsX.duration)) this.method_10(SensorsX.duration, struct12_0.long_3);
                    if (IsInRange(SensorsX.mil)) this.method_9(SensorsX.mil, struct12_0.byte_19);
                    if (IsInRange(SensorsX.batV)) this.method_9(SensorsX.batV, struct12_0.byte_27_E25);
                    if (IsInRange(SensorsX.eldV)) this.method_9(SensorsX.eldV, struct12_0.byte_24_E24);
                    if (IsInRange(SensorsX.egrV)) this.method_9(SensorsX.egrV, struct12_0.byte_25_E44);
                    if (IsInRange(SensorsX.b6V)) this.method_9(SensorsX.b6V, struct12_0.byte_26_E45);
                    if (IsInRange(SensorsX.outAc)) this.method_9(SensorsX.outAc, struct12_0.byte_22_E22);
                    if (IsInRange(SensorsX.outPurge)) this.method_9(SensorsX.outPurge, struct12_0.byte_22_E22);
                    if (IsInRange(SensorsX.outFanc)) this.method_9(SensorsX.outFanc, struct12_0.byte_22_E22);
                    if (IsInRange(SensorsX.outFpump)) this.method_9(SensorsX.outFpump, struct12_0.byte_22_E22);
                    if (IsInRange(SensorsX.outIab)) this.method_9(SensorsX.outIab, struct12_0.byte_22_E22);
                    if (IsInRange(SensorsX.outAltCtrl)) this.method_9(SensorsX.outAltCtrl, struct12_0.byte_22_E22);
                    if (IsInRange(SensorsX.outVtsX)) this.method_9(SensorsX.outVtsX, struct12_0.byte_23_E23);
                    if (IsInRange(SensorsX.outMil)) this.method_9(SensorsX.outMil, struct12_0.byte_23_E23);
                    if (IsInRange(SensorsX.outO2h)) this.method_9(SensorsX.outO2h, struct12_0.byte_23_E23);
                    if (IsInRange(SensorsX.outVtsM)) this.method_9(SensorsX.outVtsM, struct12_0.byte_6_E8);
                    if (IsInRange(SensorsX.inVtsFeedBack)) this.method_9(SensorsX.inVtsFeedBack, struct12_0.byte_21_E21);
                    if (IsInRange(SensorsX.outFuelCut)) this.method_9(SensorsX.outFuelCut, struct12_0.byte_6_E8);
                    if (IsInRange(SensorsX.inAccs)) this.method_9(SensorsX.inAccs, struct12_0.byte_21_E21);
                    if (IsInRange(SensorsX.inVtp)) this.method_9(SensorsX.inVtp, struct12_0.byte_21_E21);
                    if (IsInRange(SensorsX.inStartS)) this.method_9(SensorsX.inStartS, struct12_0.byte_21_E21);
                    if (IsInRange(SensorsX.inBksw)) this.method_9(SensorsX.inBksw, struct12_0.byte_21_E21);
                    if (IsInRange(SensorsX.inParkN)) this.method_9(SensorsX.inParkN, struct12_0.byte_21_E21);
                    if (IsInRange(SensorsX.inAtShift1)) this.method_9(SensorsX.inAtShift1, struct12_0.byte_6_E8);
                    if (IsInRange(SensorsX.inAtShift2)) this.method_9(SensorsX.inAtShift2, struct12_0.byte_6_E8);
                    if (IsInRange(SensorsX.inPsp)) this.method_9(SensorsX.inPsp, struct12_0.byte_21_E21);
                    if (IsInRange(SensorsX.inSCC)) this.method_9(SensorsX.inSCC, struct12_0.byte_21_E21);

                    if (IsInRange(SensorsX.iacvDuty))
                    {
                        double num = ((double)struct12_0.ushort_2_E49_50) / 32768.0;
                        this.grid.Rows[this.method_11_2(0x5b)].Cells[1].Value = (((num * 100.0) - 100.0)).ToString("0") + " %";
                    }
                    if (IsInRange(SensorsX.loadType))
                    {
                        string str = "Map sensor";
                        if (!this.class18_0.method_41() && !this.class18_0.method_42()) str = "Map sensor";
                        else if (this.class18_0.method_42()) str = "Tps sensor";
                        else if (this.class18_0.method_41()) str = "Alpha-N Indexing";
                        this.grid.Rows[this.method_11_2(0x3a)].Cells[1].Value = str;
                    }

                    if (IsInRange(SensorsX.postFuel)) this.method_9(SensorsX.postFuel, struct12_0.byte_6_E8);
                    if (IsInRange(SensorsX.ectFc)) this.method_9(SensorsX.ectFc, struct12_0.byte_28_E26);
                    if (IsInRange(SensorsX.o2Short)) this.method_10(SensorsX.o2Short, struct12_0.long_0_E27_28);
                    if (IsInRange(SensorsX.o2Long)) this.method_10(SensorsX.o2Long, struct12_0.long_1_E29_30);
                    if (IsInRange(SensorsX.iatFc)) this.method_10(SensorsX.iatFc, struct12_0.long_2_E31_32);
                    if (IsInRange(SensorsX.veFc)) this.method_9(SensorsX.veFc, struct12_0.byte_29_E33);
                    if (IsInRange(SensorsX.iatIc)) this.method_9(SensorsX.iatIc, struct12_0.byte_30_E34);
                    if (IsInRange(SensorsX.ectIc)) this.method_9(SensorsX.ectIc, struct12_0.byte_31_E35);
                    if (IsInRange(SensorsX.gearIc)) this.method_9(SensorsX.gearIc, struct12_0.byte_32_E36);
                    if (IsInRange(SensorsX.gearFc)) this.method_9(SensorsX.gearFc, struct12_0.byte_33_E37);
                    if (IsInRange(SensorsX.ftsClutchInput)) this.method_9(SensorsX.ftsClutchInput, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.ftlInput)) this.method_9(SensorsX.ftlInput, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.gpo1_in)) this.method_9(SensorsX.gpo1_in, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.gpo2_in)) this.method_9(SensorsX.gpo2_in, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.gpo3_in)) this.method_9(SensorsX.gpo3_in, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.bstInput)) this.method_9(SensorsX.bstInput, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.ftlActive)) this.method_9(SensorsX.ftlActive, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.ftsActive)) this.method_9(SensorsX.ftsActive, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.antilagActive)) this.method_9(SensorsX.antilagActive, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.boostcutActive)) this.method_9(SensorsX.boostcutActive, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.ignitionCut)) this.method_9(SensorsX.ignitionCut, struct12_0.byte_6_E8);
                    if (IsInRange(SensorsX.sccChecker)) this.method_9(SensorsX.sccChecker, struct12_0.byte_6_E8);
                    if (IsInRange(SensorsX.gpo1_out)) this.method_9(SensorsX.gpo1_out, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.gpo2_out)) this.method_9(SensorsX.gpo2_out, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.gpo3_out)) this.method_9(SensorsX.gpo3_out, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.bstStage2)) this.method_9(SensorsX.bstStage2, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.bstStage3)) this.method_9(SensorsX.bstStage3, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.bstStage4)) this.method_9(SensorsX.bstStage4, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.overheatActive)) this.method_9(SensorsX.overheatActive, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.leanProtection)) this.method_9(SensorsX.leanProtection, struct12_0.byte_36_E43);
                    if (IsInRange(SensorsX.fanCtrl)) this.method_9(SensorsX.fanCtrl, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.bstActive)) this.method_9(SensorsX.bstActive, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.secMaps)) this.method_9(SensorsX.secMaps, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.ebcActive)) this.method_9(SensorsX.ebcActive, struct12_0.byte_35_E39);
                    if (IsInRange(SensorsX.ebcInput)) this.method_9(SensorsX.ebcInput, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.ebcHiInput)) this.method_9(SensorsX.ebcHiInput, struct12_0.byte_34_E38);
                    if (IsInRange(SensorsX.ebcDutyX)) this.method_9(SensorsX.ebcDutyX, struct12_0.byte_38_E41);
                    if (IsInRange(SensorsX.ebcBaseDuty)) this.method_9(SensorsX.ebcBaseDuty, struct12_0.byte_37_E40);
                    if (IsInRange(SensorsX.ebcCurrent)) this.method_9(SensorsX.ebcCurrent, struct12_0.byte_4);
                    if (IsInRange(SensorsX.ebcTarget)) this.method_9(SensorsX.ebcTarget, struct12_0.byte_39_E42);
                    if (this.class10_settings_0.bool_36)
                        if (IsInRange(SensorsX.analog1)) this.grid.Rows[this.method_11_2(0x58)].Cells[1].Value = this.class33_Sensors_0.Analog1 + " " + this.class10_settings_0.string_4;
                    if (this.class10_settings_0.bool_38)
                        if (IsInRange(SensorsX.analog2)) this.grid.Rows[this.method_11_2(0x59)].Cells[1].Value = this.class33_Sensors_0.Analog2 + " " + this.class10_settings_0.string_5;
                    if (this.class10_settings_0.bool_40)
                        if (IsInRange(SensorsX.analog3)) this.grid.Rows[this.method_11_2(90)].Cells[1].Value = this.class33_Sensors_0.Analog3 + " " + this.class10_settings_0.string_6;

                    if (IsInRange(SensorsX.fuelUsage)) this.method_9(SensorsX.fuelUsage, struct12_0.byte_14_E16);
                    if (IsInRange(SensorsX.accelTime)) this.method_9(SensorsX.accelTime, struct12_0.byte_14_E16);
                    if (IsInRange(SensorsX.flexFuel)) this.method_9(SensorsX.flexFuel, this.class33_Sensors_0.GetFlexFuelByte(struct12_0));
                    if (IsInRange(SensorsX.ectV)) this.method_9(SensorsX.ectV, struct12_0.byte_0);
                    if (IsInRange(SensorsX.iatV)) this.method_9(SensorsX.iatV, struct12_0.byte_1);
                }
            }
        }
    }

    private void method_7()
    {
        this.CtrlSensorGrid_Load(null, null);
    }

    private void method_8(bool bool_2)
    {
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 3;
        //this.grid[1, this.grid.Rows.Count - 1].Value = this.class10_0.mapSensorUnits_0.ToString();
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 4;
        //this.grid[1, this.grid.Rows.Count - 1].Value = this.class10_0.mapSensorUnits_1.ToString();
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 5;
        //this.grid[1, this.grid.Rows.Count - 1].Value = "mBar";
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 1;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = this.class10_0.vssUnits_0.ToString();
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 2;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 6;
        //this.grid[1, this.grid.Rows.Count - 1].Value = " %";
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 7;
        //this.grid[1, this.grid.Rows.Count - 1].Value = " V";
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 8;
        //this.grid[1, this.grid.Rows.Count - 1].Value = " ms";
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 9;
        //this.grid[1, this.grid.Rows.Count - 1].Value = " %";
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x5b;
        //this.grid[1, this.grid.Rows.Count - 1].Value = " %";
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 10;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 11;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, 11].Value = " \x00b0";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 12;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 13;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " \x00b0" + this.class10_0.temperatureUnits_0.ToString();
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 14;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " \x00b0" + this.class10_0.temperatureUnits_0.ToString();
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 15;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = this.class10_0.airFuelUnits_0.ToString();
        if ((this.class10_settings_0.wbinput_0 != WBinput.o2Input) || this.class10_settings_0.bool_25)
        {
            this.grid.Rows.Add();
            this.grid[0, this.grid.Rows.Count - 1].Tag = 0x10;
            this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
            //this.grid[1, this.grid.Rows.Count - 1].Value = " V";
        }
        if (!this.class10_settings_0.bool_25)
        {
            this.grid.Rows.Add();
            this.grid[0, this.grid.Rows.Count - 1].Tag = 0x11;
            this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
            //this.grid[1, this.grid.Rows.Count - 1].Value = " V";
        }
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x12;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " V";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x13;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " V";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x15;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " V";
        //#################################################################################################################################################
        //EGR-V then B6-V
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 106;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 107;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));

        //ECT Voltage
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 109;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //IAT Voltage
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 110;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));

        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 108;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //#################################################################################################################################################
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x16;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x17;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x19;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " ms";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x18;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //#################################################################################################################################################
        //Fuel Usage the Accel Time
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 105;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 104;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //#################################################################################################################################################
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "Special Features";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x39;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x3a;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x2d;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x42;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x3f;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x43;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x40;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x52;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x5c;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "3-Step";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x3b;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 60;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x41;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x3d;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x3e;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        
        this.class18_0.class15_0.method_22();

        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "Analog Inputs";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x58;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x59;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 90;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));

        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "Outputs";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x25;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x26;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x27;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 40;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x29;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x2a;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x2b;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x2c;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x24;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x2e;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "Inputs";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x2f;
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x36;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x35;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x37;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x38;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x30;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x31;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 50;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x33;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x34;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "INJ/IGN correct";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x23;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x1c;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x1d;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 30;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x22;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x1a;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x1b;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x1f;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x20;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x21;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX)int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "Elec Boost Ctrl";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x44;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x45;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 70;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x47;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " %";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x48;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " %";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x49;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " psi";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x4a;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        //this.grid[1, this.grid.Rows.Count - 1].Value = " psi";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "Manual Boost Ctrl";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x57;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x56;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x53;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x54;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x55;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "General Purpose Outputs";
        this.grid.Rows.Add();
        this.grid[0, this.grid.Rows.Count - 1].Value = "------------------------";
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x4c;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x4d;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x4e;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x4f;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 80;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        this.grid.Rows.Add();
        this.grid[1, this.grid.Rows.Count - 1] = new DataGridViewCheckBoxCell();
        this.grid[0, this.grid.Rows.Count - 1].Tag = 0x51;
        this.grid[0, this.grid.Rows.Count - 1].Value = this.class10_settings_0.method_13((SensorsX) int.Parse(this.grid[0, this.grid.Rows.Count - 1].Tag.ToString()));
        for (int i = 0; i < this.grid.Rows.Count; i++)
        {
            this.grid.Rows[i].Height = 0x12;
            if (this.grid.Rows[i].Cells[0].Tag != null)
            {
                this.grid.Rows[i].Cells[0].ToolTipText = this.class10_settings_0.method_16((SensorsX) int.Parse(this.grid[0, i].Tag.ToString()));
                this.grid.Rows[i].Cells[1].ToolTipText = this.class10_settings_0.method_16((SensorsX) int.Parse(this.grid[0, i].Tag.ToString()));
            }
        }
    }

    private void method_9(SensorsX sensors_0, byte byte_0)
    {
        switch (sensors_0)
        {
            case SensorsX.fuelUsage:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class33_Sensors_0.FuelUsage.ToString("0.00") + "L/100km";
                return;
            case SensorsX.accelTime:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class33_Sensors_0.AccelTime.ToString("0.00") + "s";
                return;

            case SensorsX.flexFuel:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class33_Sensors_0.FlexFuel.ToString("0.00") + "%";
                return;

            case SensorsX.ectV:
                double ThisTempInCelcius = this.class18_0.method_191_GetTempInC(byte_0);
                double ECTVoltageValue = 5.0 - ((ThisTempInCelcius + 40.0) / 36.0);
                //################
                //Calc Difference from 3.72v
                double Diff372v = ECTVoltageValue - 3.72;
                if (Diff372v > 0) ECTVoltageValue += (Diff372v / 3.2);
                if (Diff372v < 0) ECTVoltageValue -= (-Diff372v / 4.2);
                //################
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = "~" + ECTVoltageValue.ToString("0.00") + " V";
                return;

            case SensorsX.iatV:
                double ThisTempInCelcius2 = this.class18_0.method_191_GetTempInC(byte_0);
                double IATVoltageValue = 5.0 - ((ThisTempInCelcius2 + 40.0) / 36.0);
                //################
                //Calc Difference from 3.72v
                double Diff372vI = IATVoltageValue - 3.72;
                if (Diff372vI > 0) IATVoltageValue += (Diff372vI / 3.2);
                if (Diff372vI < 0) IATVoltageValue -= (-Diff372vI / 4.2);
                //################
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = "~" + IATVoltageValue.ToString("0.00") + " V";
                return;

            //######################################################################

            case SensorsX.vssX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_197(byte_0) + " " + this.class10_settings_0.vssUnits_0.ToString();
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)this.class18_0.method_197(byte_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.gearX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = byte_0;
                return;

            case SensorsX.mapX:
                if (this.class18_0.method_206(byte_0) <= this.class10_settings_0.int_6)
                {
                    if (this.class10_settings_0.mapSensorUnits_0 != MapSensorUnits.mBar)
                    {
                        this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_193(byte_0).ToString("0.00");
                    }
                    else
                    {
                        this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_193(byte_0).ToString("0");
                    }
                    DataGridViewCell cell2 = this.grid.Rows[this.method_11(sensors_0)].Cells[1];
                    cell2.Value = cell2.Value + " " + this.class10_settings_0.mapSensorUnits_0.ToString();
                    return;
                }
                if ((this.class10_settings_0.mapSensorUnits_0 == MapSensorUnits.mBar) && (this.class10_settings_0.mapSensorUnits_1 == MapSensorUnits.mBar))
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_193(byte_0).ToString("0");
                    break;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_193(byte_0).ToString("0.00");
                break;

            case SensorsX.boostX:
                if (this.class18_0.method_206(byte_0) <= this.class10_settings_0.int_6)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = 0.ToString("0.00") + " psi";
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_193(byte_0).ToString("0.00") + this.class10_settings_0.mapSensorUnits_1.ToString();
                return;

            case SensorsX.paX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = ((int)Math.Round((double)((((byte_0 / 2) + 0x18) * 7.221) - 59.0), 0)) + " mBar";
                return;

            case SensorsX.tpsX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_198(byte_0).ToString("0") + " %";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)this.class18_0.method_198(byte_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.tpsV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_196(byte_0).ToString("0.00") + " V";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), this.class18_0.method_196(byte_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.ignFnl:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_188(byte_0).ToString("0.00") + " \x00b0";
                return;

            case SensorsX.ignTbl:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_188(byte_0).ToString("0.00") + " \x00b0";
                return;

            case SensorsX.ectX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_191(byte_0).ToString("0.00") + " \x00b0" + this.class10_settings_0.temperatureUnits_0.ToString();
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), this.class18_0.method_191(byte_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.iatX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_191(byte_0).ToString("0.00") + " \x00b0" + this.class10_settings_0.temperatureUnits_0.ToString();
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), this.class18_0.method_191(byte_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.afr:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_200(byte_0).ToString("0.00") + " " + this.class10_settings_0.airFuelUnits_0.ToString();
                return;

            case SensorsX.ecuO2V:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_196(byte_0).ToString("0.00") + " V";
                return;

            case SensorsX.wbO2V:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_196(byte_0).ToString("0.00") + " V";
                return;

            case SensorsX.batV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_208(byte_0).ToString("0.00") + " V";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), this.class18_0.method_208(byte_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                return;

            case SensorsX.eldV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_196(byte_0).ToString("0.00") + " V";
                return;

            case SensorsX.egrV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class33_Sensors_0.EGRV.ToString("0.00") + " V";
                return;

            case SensorsX.b6V:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class33_Sensors_0.B6V.ToString("0.00") + " V";
                return;

            case SensorsX.knockV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_196(byte_0).ToString("0.00") + " V";
                return;

            case SensorsX.mapV:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_196(byte_0).ToString("0.00") + " V";
                return;

            case SensorsX.mil:
                if (byte_0 != 1)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = "OFF";
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = this.grid.Rows[this.method_11(sensors_0)].Cells[0].Style.BackColor;
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = "ON";
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = Color.Red;
                return;

            case SensorsX.ectFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_205(byte_0, Enum6.const_1).ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_205(byte_0, Enum6.const_1).ToString("0.00");
                return;

            case SensorsX.veFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_205(byte_0, Enum6.const_1).ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_205(byte_0, Enum6.const_1).ToString("0.00");
                return;

            case SensorsX.ectIc:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_189(byte_0).ToString("0.00");
                return;

            case SensorsX.iatIc:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_189(byte_0).ToString("0.00");
                return;

            case SensorsX.gearIc:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_189(byte_0).ToString("0.00");
                return;

            case SensorsX.gearFc:
                if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi)
                {
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_205(byte_0, Enum6.const_1).ToString("0");
                    return;
                }
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_205(byte_0, Enum6.const_1).ToString("0.00");
                return;

            case SensorsX.postFuel:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 0);
                return;

            case SensorsX.outIab:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 2);
                return;

            case SensorsX.outVtsX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 7);
                return;

            case SensorsX.outVtsM:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 3);
                return;

            case SensorsX.outAc:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 7);
                return;

            case SensorsX.outO2h:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 6);
                return;

            case SensorsX.outMil:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 5);
                return;

            case SensorsX.outPurge:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 6);
                return;

            case SensorsX.outFanc:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 4);
                return;

            case SensorsX.outFpump:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 0);
                return;

            case SensorsX.outFuelCut:
                {
                    bool flag = this.class18_0.method_258(byte_0, 4) || this.class18_0.method_258(byte_0, 5);
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = flag;
                    this.grid.Rows[this.method_11(sensors_0)].Cells[1].Style.BackColor = SetColor(this.method_11(sensors_0), (double)Convert.ToByte(flag), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
                    return;
                }
            case SensorsX.outAltCtrl:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 5);
                return;

            case SensorsX.inPsp:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 7);
                return;

            case SensorsX.inSCC:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 5);
                return;

            case SensorsX.inAccs:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 2);
                return;

            case SensorsX.inBksw:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 1);
                return;

            case SensorsX.inVtp:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 3);
                return;

            case SensorsX.inVtsFeedBack:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 6);
                return;

            case SensorsX.inParkN:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 0);
                return;

            case SensorsX.inStartS:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 4);
                return;

            case SensorsX.inAtShift1:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 6);
                return;

            case SensorsX.inAtShift2:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 7);
                return;

            case SensorsX.secMaps:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 5);
                return;

            case SensorsX.ftlInput:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 0);
                return;

            case SensorsX.ftlActive:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 0);
                return;

            case SensorsX.ftsClutchInput:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 1);
                return;

            case SensorsX.ftsActive:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 2);
                return;

            case SensorsX.boostcutActive:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 3);
                return;

            case SensorsX.overheatActive:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 6);
                return;

            case SensorsX.antilagActive:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 1);
                return;

            case SensorsX.ignitionCut:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 2);
                return;

            case SensorsX.sccChecker:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 1);
                return;

            case SensorsX.ebcInput:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 2);
                return;

            case SensorsX.ebcHiInput:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 3);
                return;

            case SensorsX.ebcActive:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 4);
                return;

            case SensorsX.ebcBaseDuty:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_207(byte_0).ToString("0.00") + " %";
                return;

            case SensorsX.ebcDutyX:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_207(byte_0).ToString("0.00") + " %";
                return;

            case SensorsX.ebcTarget:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_245(this.class18_0.method_206(byte_0)).ToString("0.00") + " psi";
                return;

            case SensorsX.ebcCurrent:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_245(this.class18_0.method_206(byte_0)).ToString("0.00") + " psi";
                return;

            case SensorsX.gpo1_in:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 4);
                return;

            case SensorsX.gpo1_out:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 0);
                return;

            case SensorsX.gpo2_in:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 5);
                return;

            case SensorsX.gpo2_out:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 1);
                return;

            case SensorsX.gpo3_in:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 6);
                return;

            case SensorsX.gpo3_out:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 2);
                return;

            case SensorsX.fanCtrl:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 6);
                return;

            case SensorsX.bstStage2:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 3);
                return;

            case SensorsX.bstStage3:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 4);
                return;

            case SensorsX.bstStage4:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 5);
                return;

            case SensorsX.bstActive:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 7);
                return;

            case SensorsX.bstInput:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 7);
                return;

            case SensorsX.leanProtection:
                this.grid.Rows[this.method_11(sensors_0)].Cells[1].Value = this.class18_0.method_258(byte_0, 7);
                return;

            default:
                return;
        }
        DataGridViewCell cell1 = this.grid.Rows[this.method_11(sensors_0)].Cells[1];
        cell1.Value = cell1.Value + " " + this.class10_settings_0.mapSensorUnits_1.ToString();
    }

    public delegate void Delegate68();

    private delegate void Delegate69(Struct12 struct12_0);
    
}

