using Data;
//using PropertiesRes;
using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class CtrlGrid : UserControl
{
    private bool bool_0;
    private bool bool_1;
    private bool bool_3;
    private bool bool_4;
    private char char_0;
    private Class10_settings class10_settings_0;
    private Class12_afrT class12_afrT_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private ctrlMapGraph ctrlMapGraph_0;
    private float float_0 = 99f;
    private float float_1 = 99f;
    private DataGridView grid;
    private DataGridView gridMbar;
    private DataGridView gridRpm;
    private IContainer icontainer_0;
    private int int_0;
    private int int_1;
    private Label lblMapHeader;
    public Struct23 struct23_0 = new Struct23();
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Column3;
    private Struct23 struct23_1 = new Struct23();

    public event Delegate44 delegate44_0;

    private DateTime LastCheck = DateTime.Now;

    public CtrlGrid()
    {
        this.InitializeComponent();
        base.HandleCreated += new EventHandler(this.CtrlGrid_HandleCreated);
        base.HandleDestroyed += new EventHandler(this.CtrlGrid_HandleDestroyed);
        this.grid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.gridRpm_EditingControlShowing);
        this.grid.CellPainting += new DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
        this.gridMbar.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.gridRpm_EditingControlShowing);
        this.gridRpm.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.gridRpm_EditingControlShowing);
    }

    private void CtrlGrid_HandleCreated(object sender, EventArgs e)
    {
        this.bool_4 = true;
    }

    private void CtrlGrid_HandleDestroyed(object sender, EventArgs e)
    {
        this.bool_4 = false;
    }

    private void CtrlGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.class10_settings_0.GetKeyPressed(e, "Paste"))
        {
            e.Handled = true;
        }
        else if (this.class10_settings_0.GetKeyPressed(e, "Copy"))
        {
            e.Handled = true;
        }
    }

    private void CtrlGrid_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void CtrlGrid_Load(object sender, EventArgs e)
    {
        this.grid.ColumnAdded += new DataGridViewColumnEventHandler(this.grid_ColumnAdded);
        this.grid.RowsAdded += new DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
        this.grid.CellValueNeeded += new DataGridViewCellValueEventHandler(this.grid_CellValueNeeded);
        this.grid.CellValuePushed += new DataGridViewCellValueEventHandler(this.grid_CellValuePushed);
        this.grid.CellFormatting += new DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
        this.grid.Scroll += new ScrollEventHandler(this.grid_Scroll);
        this.grid.SelectionChanged += new EventHandler(this.grid_SelectionChanged);
        this.grid.CellValidating += new DataGridViewCellValidatingEventHandler(this.grid_CellValidating);
        this.gridMbar.CellValueNeeded += new DataGridViewCellValueEventHandler(this.gridMbar_CellValueNeeded);
        this.gridMbar.CellValuePushed += new DataGridViewCellValueEventHandler(this.gridMbar_CellValuePushed);
        this.gridMbar.CellValidating += new DataGridViewCellValidatingEventHandler(this.gridMbar_CellValidating);
        this.gridMbar.CellFormatting += new DataGridViewCellFormattingEventHandler(this.gridMbar_CellFormatting);
        this.gridRpm.CellValueNeeded += new DataGridViewCellValueEventHandler(this.gridRpm_CellValueNeeded);
        this.gridRpm.CellValuePushed += new DataGridViewCellValueEventHandler(this.gridRpm_CellValuePushed);
        this.gridRpm.CellFormatting += new DataGridViewCellFormattingEventHandler(this.gridRpm_CellFormatting);
        this.gridRpm.CellValidating += new DataGridViewCellValidatingEventHandler(this.gridRpm_CellValidating);
    }

    private void CtrlGrid_MouseMove(object sender, MouseEventArgs e)
    {
        base.Focus();
    }

    private void CtrlGrid_Resize(object sender, EventArgs e)
    {
        this.bool_0 = this.gridRpm.Height != this.grid.Height;
        if (((HScrollBar) this.grid.Controls[0]).Visible && !this.bool_0)
        {
            this.gridRpm.Height -= ((HScrollBar) this.grid.Controls[0]).Height;
        }
        else if (!((HScrollBar) this.grid.Controls[0]).Visible)
        {
            this.gridRpm.Height = this.grid.Height;
        }
        this.bool_1 = this.gridMbar.Width != this.grid.Width;
        if (((VScrollBar) this.grid.Controls[1]).Visible && !this.bool_1)
        {
            this.gridMbar.Width -= ((VScrollBar) this.grid.Controls[1]).Width;
        }
        else if (!((VScrollBar) this.grid.Controls[1]).Visible)
        {
            this.gridMbar.Width = this.grid.Width;
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

    private void grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        ((DataGridView) sender).BeginEdit(true);
    }

    private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        bool isCurrentCellInEditMode = false;
        if (((this.grid.CurrentCell.ColumnIndex == e.ColumnIndex) && (this.grid.CurrentCell.RowIndex == e.RowIndex)) && this.grid.IsCurrentCellInEditMode)
        {
            isCurrentCellInEditMode = this.grid.IsCurrentCellInEditMode;
        }
        if (isCurrentCellInEditMode)
        {
            e.CellStyle.BackColor = Color.White;
        }
        else
        {
            if ((this.class10_settings_0.bool_43 && this.class12_afrT_0.method_18(e.ColumnIndex, e.RowIndex)) && ((this.class18_0.method_8() == TableOverlay.none) && !this.class18_0.method_38()))
            {
                e.CellStyle.BackColor = this.class10_settings_0.color_Trail;
            }
            else if (this.class18_0.method_8() == TableOverlay.none)
            {
                e.CellStyle.BackColor = this.class18_0.method_236((double) this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex));
            }
            else
            {
                object obj2;
                if (((this.class18_0.method_8() == TableOverlay.afDiff) || (this.class18_0.method_8() == TableOverlay.afTarget)) || (this.class18_0.method_8() == TableOverlay.afReading))
                {
                    obj2 = this.class12_afrT_0.method_11(e.ColumnIndex, e.RowIndex);
                    if ((obj2 != null) && (obj2.ToString() != "-")) e.CellStyle.BackColor = this.class18_0.method_237((double) obj2);
                }
                else if (IsAnalogOverlay())
                {
                    obj2 = this.class12_afrT_0.method_11(e.ColumnIndex, e.RowIndex);
                    if ((obj2 != null) && (obj2.ToString() != "-")) e.CellStyle.BackColor = this.class18_0.method_237_Analog(this.class18_0.method_8(), (double)obj2);
                }
            }
            bool Tsse = true;
            if (((!Tsse || !this.class18_0.method_38()) || (!this.class17_0.method_34_GetConnected() && !this.class17_0.method_63_HasLogsFileOpen())) || this.class10_settings_0.bool_45)
            {
                if ((((this.struct23_0.bool_0 == this.class18_0.method_36()) && (this.class18_0.method_39() == this.struct23_0.bool_1)) && (this.class17_0.method_34_GetConnected() || this.class17_0.method_63_HasLogsFileOpen())) && !this.class10_settings_0.bool_45)
                {
                    switch (this.class10_settings_0.tunerSmartTrack)
                    {
                        case 0:
                            if ((e.RowIndex == this.struct23_0.struct24_1.int_0) && (e.ColumnIndex == this.struct23_0.struct24_1.int_1))
                            {
                                e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                            }
                            return;

                        case 1:
                            if (((e.RowIndex != this.struct23_0.struct24_1.int_0) || (e.ColumnIndex != this.struct23_0.struct24_1.int_1)))
                            {
                                if ((e.RowIndex == this.struct23_0.struct15_0.struct24_0.int_0) && (e.ColumnIndex == this.struct23_0.struct15_0.struct24_0.int_1))
                                {
                                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                                    return;
                                }
                                if ((e.RowIndex == this.struct23_0.struct15_0.struct24_1.int_0) && (e.ColumnIndex == this.struct23_0.struct15_0.struct24_1.int_1))
                                {
                                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                                    return;
                                }
                                if ((e.RowIndex == this.struct23_0.struct15_0.struct24_2.int_0) && (e.ColumnIndex == this.struct23_0.struct15_0.struct24_2.int_1))
                                {
                                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                                    return;
                                }
                                if ((e.RowIndex == this.struct23_0.struct15_0.struct24_3.int_0) && (e.ColumnIndex == this.struct23_0.struct15_0.struct24_3.int_1))
                                {
                                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                                }
                                return;
                            }
                            e.CellStyle.BackColor = Color.White;
                            return;
                    }
                }
            }
            else
            {
                switch (this.class10_settings_0.tunerSmartTrack)
                {
                    case 0:
                        if ((e.RowIndex != this.struct23_0.struct24_1.int_0) || (e.ColumnIndex != this.struct23_0.struct24_1.int_1))
                        {
                            break;
                        }
                        e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                        return;

                    case 1:
                        if (((e.RowIndex != this.struct23_0.struct24_1.int_0) || (e.ColumnIndex != this.struct23_0.struct24_1.int_1)))
                        {
                            if ((e.RowIndex == this.struct23_0.struct15_0.struct24_0.int_0) && (e.ColumnIndex == this.struct23_0.struct15_0.struct24_0.int_1))
                            {
                                e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                                return;
                            }
                            if ((e.RowIndex == this.struct23_0.struct15_0.struct24_1.int_0) && (e.ColumnIndex == this.struct23_0.struct15_0.struct24_1.int_1))
                            {
                                e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                                return;
                            }
                            if ((e.RowIndex == this.struct23_0.struct15_0.struct24_2.int_0) && (e.ColumnIndex == this.struct23_0.struct15_0.struct24_2.int_1))
                            {
                                e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                                return;
                            }
                            if ((e.RowIndex != this.struct23_0.struct15_0.struct24_3.int_0) || (e.ColumnIndex != this.struct23_0.struct15_0.struct24_3.int_1))
                            {
                                break;
                            }
                            e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                            return;
                        }
                        e.CellStyle.BackColor = Color.White;
                        return;

                    default:
                        return;
                }
            }
        }
    }

    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (this.class10_settings_0.bool_21 && (this.class18_0 != null))
        {
            try
            {
                float num = (float) Math.Round((double) this.struct23_0.float_0, 2);
                float num2 = (float) Math.Round((double) this.struct23_0.float_1, 2);
                this.float_1 = num2;
                this.float_0 = num;
                bool flag = false;
                int num3 = this.struct23_0.struct24_1.int_1;
                int num4 = this.struct23_0.struct24_1.int_0;
                if (num2 > 0.5f)
                {
                    flag = true;
                    num3 = this.struct23_0.struct15_0.struct24_1.int_1;
                }
                if (num > 0.5f)
                {
                    flag = true;
                    num4 = this.struct23_0.struct15_0.struct24_2.int_0;
                }
                if (num2 >= 1f)
                {
                    num2 = 0.99f;
                }
                if (num >= 1f)
                {
                    num = 0.99f;
                }
                if (this.class10_settings_0.tunerSmartTrack == 0)
                {
                    if ((((this.class18_0.method_36() == this.struct23_0.bool_0) && (this.struct23_0.struct24_1.int_1 == e.ColumnIndex)) && (this.struct23_0.struct24_1.int_0 == e.RowIndex)) && (this.class17_0.method_34_GetConnected() || this.class17_0.method_63_HasLogsFileOpen()))
                    {
                        Pen pen;
                        Rectangle clipBounds = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                        if (this.class10_settings_0.bool_45 || this.method_13(this.struct23_0.struct24_1.int_1, this.struct23_0.struct24_1.int_0))
                        {
                            pen = new Pen(Color.White, 2f);
                        }
                        else
                        {
                            pen = new Pen(Color.Black, 2f);
                        }
                        float num5 = ((e.CellBounds.Height - 2f) * 1f) * num;
                        float num6 = ((e.CellBounds.Width - 2f) * 1f) * num2;
                        float single1 = ((float) e.CellBounds.Width) / 5f;
                        float single2 = ((float) e.CellBounds.Height) / 5f;
                        e.PaintBackground(clipBounds, true);
                        e.PaintContent(clipBounds);
                        e.Graphics.DrawRectangle(pen, (float) ((e.CellBounds.X + 1f) + (num6 - 0.5f)), (float) (e.CellBounds.Top + 1f), (float) 1f, (float) 1f);
                        e.Graphics.DrawRectangle(pen, (float) (e.CellBounds.X + 1f), (float) ((e.CellBounds.Top + 1f) + (num5 - 0.5f)), (float) 1f, (float) 1f);
                        pen.Dispose();
                        pen = null;
                        e.Handled = true;
                    }
                }
                else
                {
                    float num7 = ((e.CellBounds.Height - 2f) * 2f) * num;
                    float num8 = ((e.CellBounds.Width - 2f) * 2f) * num2;
                    if (num > 0.5f)
                    {
                        num7 -= e.CellBounds.Height - 2f;
                    }
                    if (num2 > 0.5f)
                    {
                        num8 -= e.CellBounds.Width - 2f;
                    }
                    if (((!flag && (this.class18_0.method_36() == this.struct23_0.bool_0)) && ((this.class18_0.method_39() == this.struct23_0.bool_1) && (this.struct23_0.struct15_0.struct24_0.int_1 == e.ColumnIndex))) && ((this.struct23_0.struct15_0.struct24_0.int_0 == e.RowIndex) && (this.class17_0.method_34_GetConnected() || this.class17_0.method_63_HasLogsFileOpen())))
                    {
                        Pen pen2;
                        Rectangle rectangle2 = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                        if (this.class10_settings_0.bool_45 || this.method_13(this.struct23_0.struct15_0.struct24_0.int_1, this.struct23_0.struct15_0.struct24_0.int_0))
                        {
                            pen2 = new Pen(Color.White, 2f);
                        }
                        else
                        {
                            pen2 = new Pen(Color.Black, 2f);
                        }
                        e.PaintBackground(rectangle2, true);
                        e.PaintContent(rectangle2);
                        e.Graphics.DrawRectangle(pen2, (float) (e.CellBounds.X + 1f), (float) ((e.CellBounds.Top + 1f) + (num7 - 0.5f)), (float) 1f, (float) 1f);
                        e.Graphics.DrawRectangle(pen2, (float) ((e.CellBounds.X + 1f) + (num8 - 0.5f)), (float) (e.CellBounds.Top + 1f), (float) 1f, (float) 1f);
                        pen2.Dispose();
                        pen2 = null;
                        e.Handled = true;
                    }
                    else if ((((this.class18_0.method_36() == this.struct23_0.bool_0) && (this.class18_0.method_39() == this.struct23_0.bool_1)) && ((this.struct23_0.struct15_0.struct24_0.int_1 == e.ColumnIndex) && (num4 == e.RowIndex))) && (this.class17_0.method_34_GetConnected() || this.class17_0.method_63_HasLogsFileOpen()))
                    {
                        Pen pen3;
                        Rectangle rectangle3 = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                        if (this.class10_settings_0.bool_45 || this.method_13(this.struct23_0.struct15_0.struct24_0.int_1, num4))
                        {
                            pen3 = new Pen(Color.White, 2f);
                        }
                        else
                        {
                            pen3 = new Pen(Color.Black, 2f);
                        }
                        e.PaintBackground(rectangle3, true);
                        e.PaintContent(rectangle3);
                        e.Graphics.DrawRectangle(pen3, (float) (e.CellBounds.X + 1f), (float) ((e.CellBounds.Top + 1f) + (num7 - 0.5f)), (float) 1f, (float) 1f);
                        pen3.Dispose();
                        pen3 = null;
                        e.Handled = true;
                    }
                    else if ((((this.class18_0.method_36() == this.struct23_0.bool_0) && (this.class18_0.method_39() == this.struct23_0.bool_1)) && ((num3 == e.ColumnIndex) && (this.struct23_0.struct15_0.struct24_0.int_0 == e.RowIndex))) && (this.class17_0.method_34_GetConnected() || this.class17_0.method_63_HasLogsFileOpen()))
                    {
                        Pen pen4;
                        Rectangle rectangle4 = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                        if (this.class10_settings_0.bool_45 || this.method_13(num3, this.struct23_0.struct15_0.struct24_0.int_0))
                        {
                            pen4 = new Pen(Color.White, 2f);
                        }
                        else
                        {
                            pen4 = new Pen(Color.Black, 2f);
                        }
                        e.PaintBackground(rectangle4, true);
                        e.PaintContent(rectangle4);
                        e.Graphics.DrawRectangle(pen4, (float) ((e.CellBounds.X + 1f) + (num8 - 0.5f)), (float) (e.CellBounds.Top + 1f), (float) 1f, (float) 1f);
                        pen4.Dispose();
                        pen4 = null;
                        e.Handled = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    private void grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (!this.class18_0.method_252(e.FormattedValue.ToString()) && ((DataGridView) sender).IsCurrentCellInEditMode)
        {
            e.Cancel = true;
            MessageBox.Show(Form.ActiveForm, "Invalid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private bool IsAnalogOverlay()
    {
        bool IsAnalog = false;
        if (this.class18_0.method_8() == TableOverlay.analog1Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.analog2Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.analog3Reading) IsAnalog = true;
        return IsAnalog;
    }

    private void grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        bool isCurrentCellInEditMode = false;
        object obj2 = null;
        double num = 0.0;
        if (((this.grid.CurrentCell.ColumnIndex == e.ColumnIndex) && (this.grid.CurrentCell.RowIndex == e.RowIndex)) && this.grid.IsCurrentCellInEditMode)
        {
            isCurrentCellInEditMode = this.grid.IsCurrentCellInEditMode;
        }
        if (!isCurrentCellInEditMode)
        {
            if (!this.class18_0.method_37())
            {
                if (this.class18_0.method_40())
                {
                    e.Value = this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex).ToString("0.00");
                }
                else if (this.class18_0.method_38())
                {
                    e.Value = this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex).ToString("0") + "%";
                }
                else
                {
                    e.Value = this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex).ToString("0");
                }
            }
            else if (this.class18_0.method_8() != TableOverlay.none)
            {
                obj2 = this.class12_afrT_0.method_11(e.ColumnIndex, e.RowIndex);
                if (obj2 != null)
                {
                    if (obj2.ToString() == "-")
                    {
                        e.Value = "--";
                    }
                    else
                    {
                        num = double.Parse(obj2.ToString());
                        e.Value = num.ToString("0.00");
                        if (this.class18_0.method_8() == TableOverlay.afDiff)
                        {
                            e.Value = num.ToString("0");
                            e.Value = e.Value + " %";
                        }

                        if (IsAnalogOverlay() && num == 0)
                        {
                            e.Value = "";
                        }
                    }
                }
            }
            else if (this.class18_0.method_6() == FuelDisplayMode.fuelInjDur)
            {
                e.Value = this.class18_0.method_224((int) ((this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex) * 4f) * this.class18_0.method_49())).ToString("0.00");
            }
            else if (this.class18_0.method_6() == FuelDisplayMode.fuelDuty)
            {
                e.Value = this.class18_0.method_225((int) ((this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex) * 4f) * this.class18_0.method_49()), 0, (byte) e.RowIndex).ToString("0") + "%";
            }
            else if (this.class18_0.method_6() == FuelDisplayMode.fuelRaw)
            {
                e.Value = this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex).ToString("0");
            }
        }
        else
        {
            e.Value = this.class18_0.method_174((byte) e.ColumnIndex, (byte) e.RowIndex).ToString("0.00");
        }
    }

    private void grid_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
    {
        if (this.class18_0.method_8() == TableOverlay.afTarget)
        {
            this.class12_afrT_0.method_14(e.ColumnIndex, e.RowIndex, double.Parse(e.Value.ToString()));
        }
        else
        {
            if (!IsAnalogOverlay())
            {
                this.class18_0.method_155("Table: " + this.class18_0.method_4().ToString() + " edit");
                this.class18_0.method_176((byte)e.ColumnIndex, (byte)e.RowIndex, float.Parse(e.Value.ToString()));
                if (!this.bool_3)
                {
                    this.ctrlMapGraph_0.Invalidate();
                }
                this.class18_0.method_153();
            }
        }
    }

    private void grid_Click(object sender, EventArgs e)
    {
        if (this.class18_0.method_8() == TableOverlay.none)
        {
            this.method_3(false);
        }
        else
        {
            this.method_3(true);
        }
        this.ctrlMapGraph_0.Invalidate();
    }

    private void grid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
    {
        if (e.Column.Index < 10)
        {
            e.Column.HeaderText = ((e.Column.Index * 100) + 100).ToString();
        }
        else
        {
            e.Column.HeaderText = (1.3 + ((e.Column.Index - 9) * 2)).ToString();
        }
    }

    private void grid_KeyDown(object sender, KeyEventArgs e)
    {
        if (this.class18_0.method_8() == TableOverlay.none) this.method_3(false);
        else this.method_3(true);

        /*if (this.class10_0.GetKeyPressed(e, "Increase Selected Cells"))
        {
                e.SuppressKeyPress = true;
                this.method_35();
        }
        else if (this.class10_0.GetKeyPressed(e, "Decrease Selected Cells"))
        {
            this.method_35();
            e.SuppressKeyPress = true;
        }
        else if (this.class10_0.GetKeyPressed(e, "Increase map size width"))
        {
            e.SuppressKeyPress = true;
            byte num = (byte) (this.class10_0.method_11_GetMAP_ColumnsNumber() + 1);
            if ((num >= 10) && (num <= 0x18))
            {
                this.class18_0.method_155("Fuel & Ign Table Settings");
                this.class18_0.method_149(this.class18_0.class13_0.long_75, num);
                this.class18_0.method_153();
                this.class18_0.method_52();
            }
        }
        else if (this.class10_0.GetKeyPressed(e, "Decrease map size width"))
        {
            e.SuppressKeyPress = true;
            byte num2 = (byte) (this.class10_0.method_11_GetMAP_ColumnsNumber() - 1);
            if ((num2 >= 10) && (num2 <= 0x18))
            {
                this.class18_0.method_155("Fuel & Ign Table Settings");
                this.class18_0.method_149(this.class18_0.class13_0.long_75, num2);
                this.class18_0.method_153();
                this.class18_0.method_52();
            }
        }
        else */
        if ((e.Shift || (e.KeyData == Keys.Up)) || (((e.KeyData == Keys.Down) || (e.KeyData == Keys.Left)) || (e.KeyData == Keys.Right)))
        {
            e.SuppressKeyPress = true;
            this.ctrlMapGraph_0.Invalidate();
        }
    }

    private void grid_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((this.class18_0.method_255(e.KeyChar.ToString()) || (e.KeyChar == ',')) || (((e.KeyChar == '.') || (e.KeyChar == '-')) || (e.KeyChar == ' ')))
        {
            ((DataGridView) sender).BeginEdit(true);
            this.char_0 = e.KeyChar;
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        else
        {
            ((DataGridView) sender).CancelEdit();
            e.Handled = true;
        }
    }

    private void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        if (e.RowIndex == 0)
        {
            this.grid.Rows[e.RowIndex].HeaderCell.Value = "1000";
        }
        else if (this.grid.Rows[e.RowIndex].HeaderCell.Value == null)
        {
            this.grid.Rows[e.RowIndex].HeaderCell.Value = (int.Parse(this.grid.Rows[e.RowIndex - 1].HeaderCell.Value.ToString()) + (e.RowIndex * 750)).ToString();
        }
    }

    private void grid_Scroll(object sender, ScrollEventArgs e)
    {
        if (((HScrollBar) this.grid.Controls[0]).Visible)
        {
            this.gridMbar.HorizontalScrollingOffset = this.grid.HorizontalScrollingOffset;
        }
        if (((VScrollBar) this.grid.Controls[1]).Visible)
        {
            this.gridRpm.FirstDisplayedScrollingRowIndex = this.grid.FirstDisplayedScrollingRowIndex;
        }
    }

    private void grid_SelectionChanged(object sender, EventArgs e)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune() && this.class10_settings_0.bool_10)
        {
            for (int i = 0; i < this.gridMbar.ColumnCount; i++)
            {
                this.gridMbar[i, 0].Selected = false;
            }
            for (int j = 0; j < this.gridRpm.RowCount; j++)
            {
                this.gridRpm[0, j].Selected = false;
            }
            foreach (DataGridViewCell cell in this.grid.SelectedCells)
            {
                this.gridMbar[cell.ColumnIndex, 0].Selected = true;
                this.gridRpm[0, cell.RowIndex].Selected = true;
                this.gridRpm.InvalidateColumn(0);
                this.gridMbar.InvalidateRow(0);
            }
        }
    }

    private void grid_SelectionChanged_1(object sender, EventArgs e)
    {
        if (this.delegate44_0 != null)
        {
            this.delegate44_0(sender, e);
        }
    }


    private void gridMbar_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        this.grid.ClearSelection();
        for (int i = 0; i < this.grid.Rows.Count; i++)
        {
            this.grid[e.ColumnIndex, i].Selected = true;
        }
        this.gridMbar.EndEdit();
        this.ctrlMapGraph_0.Invalidate();
    }

    private void gridMbar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        this.gridMbar.BeginEdit(false);
    }

    private void gridMbar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (!this.gridMbar.IsCurrentCellInEditMode)
        {
            e.CellStyle.BackColor = Color.White;
            if ((this.class10_settings_0.bool_11 && (this.class17_0.method_34_GetConnected() || this.class17_0.method_63_HasLogsFileOpen())) && (this.struct23_0.bool_0 == this.class18_0.method_36()))
            {
                if (e.ColumnIndex == this.struct23_0.struct15_0.struct24_0.int_1)
                {
                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                }
                else if (e.ColumnIndex == this.struct23_0.struct15_0.struct24_3.int_1)
                {
                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                }
            }
        }
        else
        {
            e.CellStyle.BackColor = Color.White;
        }
    }

    private void gridMbar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (!this.class18_0.method_252(e.FormattedValue.ToString()) && ((DataGridView) sender).IsCurrentCellInEditMode)
        {
            e.Cancel = true;
            MessageBox.Show(Form.ActiveForm, "Invalid value\nPlease enter load value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void gridMbar_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        bool isCurrentCellInEditMode = false;
        if (((this.gridMbar.CurrentCell != null) && (this.gridMbar.CurrentCell.ColumnIndex == e.ColumnIndex)) && this.gridMbar.IsCurrentCellInEditMode)
        {
            isCurrentCellInEditMode = this.gridMbar.IsCurrentCellInEditMode;
        }
        if (this.class18_0.method_43(this.class18_0.method_163((byte) e.ColumnIndex)))
        {
            this.gridMbar.Columns[e.ColumnIndex].HeaderText = "TP" + ((e.ColumnIndex + 1)).ToString();
        }
        else if (this.class18_0.method_163((byte) e.ColumnIndex) <= this.class10_settings_0.int_6)
        {
            this.gridMbar.Columns[e.ColumnIndex].HeaderText = (e.ColumnIndex + 1).ToString();
        }
        else if (this.class18_0.method_163((byte) e.ColumnIndex) > this.class10_settings_0.int_6)
        {
            this.gridMbar.Columns[e.ColumnIndex].HeaderText = "B" + ((e.ColumnIndex + 1)).ToString();
        }
        if (!isCurrentCellInEditMode)
        {
            e.Value = this.class18_0.method_167((byte) e.ColumnIndex);
        }
        else if (this.class18_0.method_42())
        {
            e.Value = this.class18_0.method_198((byte) this.class18_0.method_165((byte) e.ColumnIndex));
        }
        else if (this.class18_0.method_41())
        {
            e.Value = this.class18_0.method_163((byte) e.ColumnIndex);
        }
        else
        {
            e.Value = this.class18_0.method_167((byte) e.ColumnIndex);
        }
    }

    private void gridMbar_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
    {
        this.class18_0.method_155("Load scalar adjustment, column:" + e.ColumnIndex.ToString());
        if (this.class18_0.method_42())
        {
            this.class18_0.method_171((byte) e.ColumnIndex, this.class18_0.method_228(int.Parse(e.Value.ToString())), this.class18_0.method_4());
        }
        else if (this.class18_0.method_41())
        {
            this.class18_0.method_173((byte) e.ColumnIndex, int.Parse(e.Value.ToString()));
        }
        else
        {
            this.class18_0.method_172((byte) e.ColumnIndex, float.Parse(e.Value.ToString()), this.class18_0.method_165((byte) e.ColumnIndex));
        }
        if (!this.bool_3)
        {
            this.ctrlMapGraph_0.Invalidate();
        }
        this.class18_0.method_153();
    }

    private void gridRpm_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
    }

    private void gridRpm_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        this.grid.ClearSelection();
        for (int i = 0; i < this.grid.Columns.Count; i++)
        {
            this.grid[i, e.RowIndex].Selected = true;
        }
        this.ctrlMapGraph_0.Invalidate();
        this.gridRpm.EndEdit();
    }

    private void gridRpm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        this.gridRpm.BeginEdit(false);
    }

    private void gridRpm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (!this.gridRpm.IsCurrentCellInEditMode)
        {
            e.CellStyle.BackColor = Color.White;
            if ((this.class10_settings_0.bool_11 && (this.class17_0.method_34_GetConnected() || this.class17_0.method_63_HasLogsFileOpen())) && (this.struct23_0.bool_0 == this.class18_0.method_36()))
            {
                if (e.RowIndex == this.struct23_0.struct15_0.struct24_0.int_0)
                {
                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                }
                else if (e.RowIndex == this.struct23_0.struct15_0.struct24_2.int_0)
                {
                    e.CellStyle.BackColor = this.class10_settings_0.color_Trace;
                }
            }
        }
        else
        {
            e.CellStyle.BackColor = e.CellStyle.BackColor = Color.White;
        }
    }

    private void gridRpm_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (!this.class18_0.method_256(e.FormattedValue.ToString()) && ((DataGridView) sender).IsCurrentCellInEditMode)
        {
            e.Cancel = true;
            MessageBox.Show(Form.ActiveForm, "Invalid value\nPlease enter rpm value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void gridRpm_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        e.Value = this.class18_0.method_159((byte) e.RowIndex);
    }

    private void gridRpm_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
    {
        this.class18_0.method_155("Rpm scalar adjustment, row:" + e.ColumnIndex.ToString());
        this.class18_0.method_168((byte) e.RowIndex, int.Parse(e.Value.ToString()));
        if (!this.bool_3)
        {
            this.ctrlMapGraph_0.Invalidate();
        }
        this.class18_0.method_153();
    }

    private void gridRpm_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is DataGridViewTextBoxEditingControl)
        {
            e.Control.KeyPress += new KeyPressEventHandler(this.method_36);
        }
    }

    private void gridRpm_MouseMove(object sender, MouseEventArgs e)
    {
        this.int_1 = e.Y;
        this.int_0 = e.X;
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridMbar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRpm = new System.Windows.Forms.DataGridView();
            this.lblMapHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRpm)).BeginInit();
            this.SuspendLayout();
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
            this.grid.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 22;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.GridColor = System.Drawing.Color.Black;
            this.grid.Location = new System.Drawing.Point(68, 18);
            this.grid.Name = "grid";
            this.grid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 70;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowCellToolTips = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(439, 495);
            this.grid.TabIndex = 0;
            this.grid.VirtualMode = true;
            this.grid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridRpm_CellBeginEdit);
            this.grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentDoubleClick);
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentDoubleClick);
            this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged_1);
            this.grid.Click += new System.EventHandler(this.grid_Click);
            this.grid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grid_KeyPress);
            this.grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.grid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridRpm_MouseMove);
            // 
            // gridMbar
            // 
            this.gridMbar.AllowUserToAddRows = false;
            this.gridMbar.AllowUserToDeleteRows = false;
            this.gridMbar.AllowUserToResizeColumns = false;
            this.gridMbar.AllowUserToResizeRows = false;
            this.gridMbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMbar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridMbar.BackgroundColor = System.Drawing.Color.White;
            this.gridMbar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridMbar.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMbar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridMbar.ColumnHeadersHeight = 20;
            this.gridMbar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridMbar.ColumnHeadersVisible = false;
            this.gridMbar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMbar.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridMbar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridMbar.GridColor = System.Drawing.Color.Black;
            this.gridMbar.Location = new System.Drawing.Point(69, -1);
            this.gridMbar.Name = "gridMbar";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMbar.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridMbar.RowHeadersVisible = false;
            this.gridMbar.RowHeadersWidth = 70;
            this.gridMbar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMbar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.gridMbar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridMbar.ShowCellErrors = false;
            this.gridMbar.ShowCellToolTips = false;
            this.gridMbar.ShowEditingIcon = false;
            this.gridMbar.ShowRowErrors = false;
            this.gridMbar.Size = new System.Drawing.Size(437, 44);
            this.gridMbar.TabIndex = 1;
            this.gridMbar.VirtualMode = true;
            this.gridMbar.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridRpm_CellBeginEdit);
            this.gridMbar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMbar_CellClick);
            this.gridMbar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMbar_CellDoubleClick);
            this.gridMbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridRpm_MouseMove);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // gridRpm
            // 
            this.gridRpm.AllowUserToAddRows = false;
            this.gridRpm.AllowUserToDeleteRows = false;
            this.gridRpm.AllowUserToResizeColumns = false;
            this.gridRpm.AllowUserToResizeRows = false;
            this.gridRpm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridRpm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRpm.BackgroundColor = System.Drawing.Color.White;
            this.gridRpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridRpm.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gridRpm.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRpm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridRpm.ColumnHeadersHeight = 22;
            this.gridRpm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridRpm.ColumnHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRpm.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridRpm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRpm.GridColor = System.Drawing.Color.Black;
            this.gridRpm.Location = new System.Drawing.Point(-1, 18);
            this.gridRpm.Name = "gridRpm";
            this.gridRpm.RowHeadersVisible = false;
            this.gridRpm.RowHeadersWidth = 65;
            this.gridRpm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.gridRpm.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gridRpm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRpm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridRpm.ShowCellErrors = false;
            this.gridRpm.ShowCellToolTips = false;
            this.gridRpm.ShowEditingIcon = false;
            this.gridRpm.ShowRowErrors = false;
            this.gridRpm.Size = new System.Drawing.Size(94, 494);
            this.gridRpm.TabIndex = 2;
            this.gridRpm.VirtualMode = true;
            this.gridRpm.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridRpm_CellBeginEdit);
            this.gridRpm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRpm_CellClick);
            this.gridRpm.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRpm_CellDoubleClick);
            this.gridRpm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridRpm_MouseMove);
            // 
            // lblMapHeader
            // 
            this.lblMapHeader.BackColor = System.Drawing.SystemColors.Control;
            this.lblMapHeader.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapHeader.Location = new System.Drawing.Point(-3, -1);
            this.lblMapHeader.Name = "lblMapHeader";
            this.lblMapHeader.Size = new System.Drawing.Size(72, 20);
            this.lblMapHeader.TabIndex = 3;
            this.lblMapHeader.Text = "mBar/psi";
            this.lblMapHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lblMapHeader);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.gridRpm);
            this.Controls.Add(this.gridMbar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtrlGrid";
            this.Size = new System.Drawing.Size(507, 513);
            this.Load += new System.EventHandler(this.CtrlGrid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CtrlGrid_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CtrlGrid_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlGrid_MouseMove);
            this.Resize += new System.EventHandler(this.CtrlGrid_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRpm)).EndInit();
            this.ResumeLayout(false);

    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1, ref ctrlMapGraph ctrlMapGraph_1, ref Class12_afrT class12_afrT_1)
    {
        this.class18_0 = class18_1;
        this.class18_0.delegate57_0 += new Class18.Delegate57(this.method_27);
        //this.class18_0.delegate55_0 += new Class18_file.Delegate55(this.method_26);
        this.class18_0.delegate60_0 += new Class18.Delegate60(this.method_25);
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_22);
        this.class10_settings_0 = class10_1;
        this.class17_0 = class17_1;
        this.class17_0.delegate49_0 += new Class17.Delegate49(this.method_23);
        this.class17_0.delegate53_0 += new Class17.Delegate53(this.method_1);
        this.ctrlMapGraph_0 = ctrlMapGraph_1;
        this.class12_afrT_0 = class12_afrT_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1(long long_0, string string_0)
    {
        this.struct23_0 = new Struct23();
        this.struct23_1 = new Struct23();
    }

    public int[] method_10()
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
        if (num2 > (this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
        {
            num2 = this.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1;
        }
        return new int[] { columnIndex, rowIndex, num2, num4 };
    }

    public int method_11()
    {
        int num = this.method_10()[0];
        return num;
    }

    public int method_12()
    {
        int num = this.method_10()[1];
        return num;
    }

    public bool method_13(int int_2, int int_3)
    {
        foreach (DataGridViewCell cell in this.grid.SelectedCells)
        {
            if ((cell.ColumnIndex == int_2) && (cell.RowIndex == int_3))
            {
                return true;
            }
        }
        return false;
    }

    public bool method_14(int int_2, int int_3)
    {
        if (!this.class18_0.method_38())
        {
            if (this.class10_settings_0.tunerSmartTrack == 0)
            {
                return (((this.class18_0.method_36() == this.struct23_0.bool_0) && (this.struct23_0.struct24_1.int_1 == int_2)) && (this.struct23_0.struct24_1.int_0 == int_3));
            }
            if (((((this.class18_0.method_36() != this.struct23_0.bool_0) || (this.struct23_0.struct15_0.struct24_0.int_1 != int_2)) || (this.struct23_0.struct15_0.struct24_0.int_0 != int_3)) && (((this.class18_0.method_36() != this.struct23_0.bool_0) || (this.struct23_0.struct15_0.struct24_1.int_1 != int_2)) || (this.struct23_0.struct15_0.struct24_1.int_0 != int_3))) && (((this.class18_0.method_36() != this.struct23_0.bool_0) || (this.struct23_0.struct15_0.struct24_2.int_1 != int_2)) || (this.struct23_0.struct15_0.struct24_2.int_0 != int_3)))
            {
                return (((this.class18_0.method_36() == this.struct23_0.bool_0) && (this.struct23_0.struct15_0.struct24_3.int_1 == int_2)) && (this.struct23_0.struct15_0.struct24_3.int_0 == int_3));
            }
            return true;
        }
        if (!this.class18_0.method_38())
        {
            return false;
        }
        return ((this.struct23_0.struct24_2.int_1 == int_2) && (this.struct23_0.struct24_2.int_0 == int_3));
    }

    public void method_15(int int_2, int int_3, bool bool_5)
    {
        if (!bool_5)
        {
            this.grid.ClearSelection();
        }
        this.grid[int_2, int_3].Selected = true;
    }

    public void method_16(int int_2, int int_3)
    {
        this.grid[int_2, int_3].Selected = false;
    }

    public void method_17_ClearSelection()
    {
        this.grid.ClearSelection();
    }

    public void method_18()
    {
        //this.class18_0.delegate55_0 -= new Class18_file.Delegate55(this.method_26);
        this.class18_0.delegate60_0 -= new Class18.Delegate60(this.method_25);
        this.class18_0.delegate55_0 -= new Class18.Delegate55(this.method_22);
        this.class17_0.delegate49_0 -= new Class17.Delegate49(this.method_23);
        this.class17_0.delegate49_0 -= new Class17.Delegate49(this.method_23);
        this.class17_0.delegate53_0 -= new Class17.Delegate53(this.method_1);
        base.Dispose();
    }

    public int method_19()
    {
        return this.grid.HitTest(this.int_0, this.int_1).ColumnIndex;
    }

    public bool method_2()
    {
        return this.grid.ReadOnly;
    }

    public int method_20()
    {
        return this.grid.HitTest(this.int_0, this.int_1).RowIndex;
    }

    private void method_21()
    {
        if ((this.class18_0 != null) && this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.grid.Rows.Clear();
            this.grid.Columns.Clear();
            this.gridRpm.Rows.Clear();
            this.gridRpm.Columns.Clear();
            this.gridMbar.Rows.Clear();
            this.gridMbar.Columns.Clear();
            if (this.class18_0.method_42())
            {
                this.lblMapHeader.Text = "tps%";
            }
            else if (this.class18_0.method_41())
            {
                this.lblMapHeader.Text = this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_0) + "/tps%";
            }
            else
            {
                this.lblMapHeader.Text = this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_0) + "/" + this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_1);
            }
            this.gridRpm.ColumnCount = 1;
            this.gridRpm.Rows.Add();
            this.gridRpm.Rows.AddCopies(0, this.class18_0.method_32_GetRPM_RowsNumber() - 1);
            int ColumnCount = this.class10_settings_0.method_11_GetMAP_ColumnsNumber();
            if (ColumnCount == 0) ColumnCount = 1;
            this.gridMbar.ColumnCount = ColumnCount;
            for (int i = 0; i < this.gridMbar.ColumnCount; i++)
            {
                this.gridMbar.Columns[i].Width = 0x26;
            }
            this.gridMbar.Rows.Add();
            for (int j = 0; j < ColumnCount; j++)
            {
                int num4 = j + 1;
                this.grid.Columns.Add(num4.ToString(), "");
                this.grid.Columns[j].Width = 39;
                this.gridMbar.Columns[j].Width = 39;
            }
            for (int k = 0; k < this.class18_0.method_32_GetRPM_RowsNumber(); k++)
            {
                this.grid.Rows.Add();
                this.grid.Rows[k].Height = 0x10;
                this.gridRpm.Rows[k].Height = 0x10;
            }
            if (!this.class10_settings_0.bool_10)
            {
                this.gridRpm.DefaultCellStyle.SelectionBackColor = Color.White;
                this.gridRpm.DefaultCellStyle.SelectionForeColor = Color.Black;
                this.gridMbar[0, 0].Selected = false;
                this.gridMbar.DefaultCellStyle.SelectionBackColor = Color.White;
                this.gridMbar.DefaultCellStyle.SelectionForeColor = Color.Black;
                this.gridRpm[0, 0].Selected = false;
            }
        }
    }

    private void method_22()
    {
        this.method_31();
        //this.gridRpm.Invalidate();
        //this.gridMbar.Invalidate();
    }

    private void method_23(Struct23 struct23_2)
    {
        if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && (DateTime.Now - LastCheck).TotalMilliseconds >= this.class10_settings_0.int_ActiveDatalog[6]))
        {
            LastCheck = DateTime.Now;
            if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[6]))
            {
                if (this.bool_4)
                {
                    try
                    {
                        base.Invoke(new Delegate43(this.method_24), new object[] { struct23_2 });
                    }
                    catch
                    {
                    }
                }
            }
        }
    }

    private void method_24(Struct23 struct23_2)
    {
        if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[6]))
        {
            this.struct23_0 = struct23_2;
            if (this.class18_0.method_38())
            {
                this.struct23_0.method_0(this.struct23_0.struct24_2, ref this.class10_settings_0);
            }
            if (this.class10_settings_0.bool_44 && !this.class18_0.method_38())
            {
                if (struct23_2.bool_1 && !this.class18_0.method_39())
                {
                    this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() + 4);
                    this.method_31();
                }
                else if (!struct23_2.bool_1 && this.class18_0.method_39())
                {
                    this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() - 4);
                    this.method_31();
                }
            }
            bool Tssse = true;
            if (this.class10_settings_0.bool_42 && (!this.class18_0.method_38() || !Tssse))
            {
                if (struct23_2.bool_0)
                {
                    if (!this.class18_0.method_36())
                    {
                        this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() + 1);
                        this.method_31();
                    }
                }
                else if (!struct23_2.bool_0 && !this.class18_0.method_35())
                {
                    this.class18_0.method_5_SetSelectedTable(this.class18_0.method_4() - 1);
                    this.method_31();
                }
            }
            try
            {
                if (this.class10_settings_0.bool_45)
                {
                    this.method_29(this.struct23_1);
                }
                else
                {
                    this.method_28(this.struct23_1);
                }
                this.struct23_1 = this.struct23_0;
                if (this.class10_settings_0.bool_45)
                {
                    this.method_30(this.struct23_0);
                }
                else
                {
                    this.method_28(this.struct23_0);
                }
            }
            catch (Exception)
            {
                this.struct23_1 = this.struct23_0;
            }
            //this.method_31();
            this.ctrlMapGraph_0.Invalidate();
        }
    }

    private void method_25(int int_2)
    {
        if (!this.class18_0.method_28())
        {
            if (this.grid != null)
            {
                if (this.grid.Columns.Count > int_2)
                {
                    this.grid.InvalidateColumn(int_2);
                }
            }
        }
    }

    private void method_27(SelectedTable selectedTable_0)
    {
        if (this.class18_0.method_42())
        {
            this.lblMapHeader.Text = "tps%";
        }
        else if (this.class18_0.method_41())
        {
            this.lblMapHeader.Text = this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_0) + "/tps%";
        }
        else
        {
            this.lblMapHeader.Text = this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_0) + "/" + this.class18_0.method_251(this.class10_settings_0.mapSensorUnits_1);
        }
        this.grid.Invalidate();
        this.gridMbar.Invalidate();
        this.gridRpm.Invalidate();
    }

    private void method_28(Struct23 struct23_2)
    {
        if (((struct23_2.bool_0 == this.class18_0.method_36()) && !this.class18_0.method_38()) && (struct23_2.bool_1 == this.class18_0.method_39()))
        {
            this.grid.InvalidateCell(struct23_2.struct15_0.struct24_0.int_1, struct23_2.struct15_0.struct24_0.int_0);
            this.grid.InvalidateCell(struct23_2.struct15_0.struct24_1.int_1, struct23_2.struct15_0.struct24_1.int_0);
            this.grid.InvalidateCell(struct23_2.struct15_0.struct24_2.int_1, struct23_2.struct15_0.struct24_2.int_0);
            this.grid.InvalidateCell(struct23_2.struct15_0.struct24_3.int_1, struct23_2.struct15_0.struct24_3.int_0);
            if (this.class10_settings_0.bool_11)
            {
                this.gridMbar.InvalidateCell(struct23_2.struct15_0.struct24_0.int_1, 0);
                this.gridMbar.InvalidateCell(struct23_2.struct15_0.struct24_3.int_1, 0);
                this.gridRpm.InvalidateCell(0, struct23_2.struct15_0.struct24_0.int_0);
                this.gridRpm.InvalidateCell(0, struct23_2.struct15_0.struct24_2.int_0);
            }
        }
    }

    private void method_29(Struct23 struct23_2)
    {
        this.grid.ClearSelection();
    }

    public void method_3(bool bool_5)
    {
        this.grid.ReadOnly = bool_5;
    }

    private void method_30(Struct23 struct23_2)
    {
        switch (this.class10_settings_0.tunerSmartTrack)
        {
            case 0:
                this.grid[struct23_2.struct24_1.int_1, struct23_2.struct24_1.int_0].Selected = true;
                return;

            case 1:
                this.grid[struct23_2.struct15_0.struct24_0.int_1, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                this.grid[struct23_2.struct15_0.struct24_1.int_1, struct23_2.struct15_0.struct24_1.int_0].Selected = true;
                this.grid[struct23_2.struct15_0.struct24_2.int_1, struct23_2.struct15_0.struct24_2.int_0].Selected = true;
                this.grid[struct23_2.struct15_0.struct24_3.int_1, struct23_2.struct15_0.struct24_3.int_0].Selected = true;
                return;

            case 2:
            {
                int num = struct23_2.struct15_0.struct24_0.int_1;
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                num++;
                if (num >= this.class18_0.method_33())
                {
                    break;
                }
                this.grid[num, struct23_2.struct15_0.struct24_0.int_0].Selected = true;
                return;
            }
            case 3:
                for (int i = struct23_2.struct15_0.struct24_0.int_0; i < this.class18_0.method_32_GetRPM_RowsNumber(); i++)
                {
                    this.grid[struct23_2.struct15_0.struct24_0.int_1, i].Selected = true;
                }
                return;

            case 4:
                for (int j = struct23_2.struct15_0.struct24_0.int_1; j < this.class18_0.method_33(); j++)
                {
                    for (int k = struct23_2.struct15_0.struct24_0.int_0; k < this.class18_0.method_32_GetRPM_RowsNumber(); k++)
                    {
                        this.grid[j, k].Selected = true;
                    }
                }
                break;

            default:
                return;
        }
    }

    public void method_31()
    {
        this.grid.Invalidate();
        this.gridMbar.Invalidate();
        this.gridRpm.Invalidate();
        this.ctrlMapGraph_0.Invalidate();
    }

    /*public void method_32(int int_2)
    {
        this.grid.InvalidateRow(int_2);
        this.ctrlMapGraph_0.Invalidate();
    }

    public void method_33(int int_2)
    {
        this.grid.InvalidateColumn(int_2);
        this.ctrlMapGraph_0.Invalidate();
    }*/

    public void method_34(int int_2, int int_3)
    {
        this.grid.InvalidateCell(int_2, int_3);
        if (this.class18_0.method_8() == TableOverlay.none)
        {
            this.ctrlMapGraph_0.Invalidate();
        }
    }

    public void method_35()
    {
        DataGridViewSelectedCellCollection selectedCells = this.grid.SelectedCells;
        for (int i = 0; i < selectedCells.Count; i++)
        {
            this.grid.InvalidateCell(selectedCells[i].ColumnIndex, selectedCells[i].RowIndex);
        }
        this.ctrlMapGraph_0.Invalidate();
    }

    private void method_36(object sender, KeyPressEventArgs e)
    {
        if ((this.class18_0.method_252(e.KeyChar.ToString()) || (e.KeyChar == ',')) || (((e.KeyChar == '.') || (e.KeyChar == '-')) || (e.KeyChar == '\b')))
        {
            e.Handled = false;
        }
        else
        {
            e.Handled = true;
        }
    }

    private void method_37(object sender, DataGridViewCellMouseEventArgs e)
    {
        ((DataGridView) sender).BeginEdit(true);
    }

    public void method_4()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_21();
            this.CtrlGrid_Resize(null, null);
            this.grid.Invalidate();
        }
        else
        {
            this.gridMbar.EndEdit();
            this.gridRpm.EndEdit();
            this.grid.EndEdit();
            this.grid.Rows.Clear();
            this.grid.Columns.Clear();
            this.gridRpm.Rows.Clear();
            this.gridRpm.Columns.Clear();
            this.gridMbar.Rows.Clear();
            this.gridMbar.Columns.Clear();
        }
    }

    public int method_5()
    {
        return ((0x156 + this.gridRpm.Width) + 10);
    }

    public bool method_6()
    {
        return this.grid.IsCurrentCellInEditMode;
    }

    public void method_7()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune() && (this.grid.GetCellCount(DataGridViewElementStates.Selected) > 0 || this.gridMbar.GetCellCount(DataGridViewElementStates.Selected) > 0 || this.gridRpm.GetCellCount(DataGridViewElementStates.Selected) > 0))
        {
            try
            {
                Clipboard.SetDataObject(CopyToClipboard());
                this.class17_0.frmMain_0.LogThis("Table copied to clipboard");
            }
            catch (Exception)
            {
                this.class17_0.frmMain_0.LogThis("Unable to copy Grid content to Clipboard");
            }
        }
    }

    private string CopyToClipboard()
    {
        string newline = "\n";
        string tab = "\t";
        StringBuilder clipboard_string = new StringBuilder();

        DataGridView gridBuf = (DataGridView) this.ActiveControl;
        //Console.WriteLine(this.ActiveControl.GetType().ToString());
        //Console.WriteLine(this.ActiveControl.Name);

        for (int i = 0; i < gridBuf.Rows.Count; i++)
        {
            int TabCount = 0;
            for (int i2 = 0; i2 < gridBuf.Rows[i].Cells.Count; i2++)
            {
                if (gridBuf.Rows[i].Cells[i2].Selected)
                {
                    if (TabCount > 0) clipboard_string.Append(tab);
                    clipboard_string.Append(gridBuf.Rows[i].Cells[i2].Value);
                    TabCount++;
                }

                if (i2 == (gridBuf.Rows[i].Cells.Count - 1)) clipboard_string.Append(newline);
            }
        }

        return clipboard_string.ToString();
    }

    public void method_8()
    {
        try
        {
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
                string data = (string)dataObject.GetData(DataFormats.Text);
                if (!(data == string.Empty) && (data != null))
                {
                    DataGridView gridBuf = (DataGridView)this.ActiveControl;
                    DataGridViewSelectedCellCollection selectedCells = gridBuf.SelectedCells;

                    int[] numArray = this.method_10();
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
                        this.bool_3 = true;
                        this.class18_0.method_156("Clipboard paste in table: " + this.class18_0.method_4().ToString(), true);
                        for (int i = numArray[1]; i <= numArray[3]; i++)
                        {
                            strArray2 = strArray[num3].Split(chArray2, StringSplitOptions.RemoveEmptyEntries);
                            index = 0;
                            for (int j = numArray[0]; j <= numArray[2]; j++)
                            {
                                gridBuf[j, i].Value = strArray2[index];
                                index++;
                            }
                            num3++;
                        }
                        this.class18_0.method_154();
                        this.bool_3 = false;
                        this.ctrlMapGraph_0.Invalidate();
                    }
                }
            }
        }
        catch
        {
            MessageBox.Show(Form.ActiveForm, "Unable to paste Clipboard content to the Grid");
        }
    }

    public DataGridViewSelectedCellCollection method_9()
    {
        return this.grid.SelectedCells;
    }

    private delegate void Delegate43(Struct23 struct23_0);

    public delegate void Delegate44(object sender, EventArgs e);
}

