using Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

internal class ctrlMapGraph : UserControl
{
    //private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private Brush brush_0;
    private Class10_settings class10_settings_0;
    private Class16_u class16_u_0 = new Class16_u();
    private Class18 class18_0;
    private Class7_u[,] class7_u_0;
    //private Class7_u class7_1;
    private ToolStripMenuItem clearPlotsToolStripMenuItem1;
    private Color[] color_0 = new Color[4];
    private CtrlGrid ctrlGrid_0;
    private double double_0;
    private float float_0;
    private float float_1;
    private float float_10;
    private float float_11;
    private float float_12;
    private float float_13;
    private float float_14;
    private float float_15;
    private float float_16;
    private float float_17;
    private float float_18;
    private float float_19;
    private float float_2;
    private float float_20;
    private float float_21;
    private float float_22;
    private float float_23;
    private float float_24;
    private float float_25;
    private float float_26 = 0.5f;
    private float float_27 = 0.5f;
    private float float_3;
    private float float_4;
    private float float_5;
    private float float_6 = 8f;
    private float float_7;
    private float float_8;
    private float float_9;
    private FrmGridChart frmGridChart_0;
    private Graphics graphics_0;
    private IContainer icontainer_0;
    private int int_0;
    private int int_1;
    private int int_10 = 40;
    private int int_10_0 = 15;
    private int int_11 = 22;
    private int int_12;
    private int int_13;
    private int int_14;
    private int int_15;
    private int int_2;
    private int int_3;
    private int int_4;
    private int int_5;
    private int int_6;
    private int[,] int_7;
    private int int_8;
    private int int_9;
    private List<Class7_u> class7_u_1 = new List<Class7_u>();
    public MapGraphType mapGraphType_0;
    private Point point_0;
    private Point point_1;
    private Point point_2;
    private PointF[] pointF_0 = new PointF[4];
    private Rectangle rectangle_0;
    private Struct19[] struct19_0;
    private List<Struct12> Struct12_list_0;
    private IContainer components;
    private Struct19[,] struct19_2;

    private int Last_Used_Sensor = 0;

    private int Cint_Colomn = 14;
    private int Cint_Sensor = 0;

    private int custom_value_int;
    private float custom_value_float;

    public ctrlMapGraph()
    {
        this.InitializeComponent();
        //this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
    }

    private void adjustSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.frmGridChart_0.toolBtnAdjSel_Click(sender, e);
    }

    /*private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        while (this.bool_2)
        {
            int x;
            int num2;
            int y;
            int num4;
            int num5;
            int num6;
            MouseEventArgs argument = (MouseEventArgs) e.Argument;
            if (argument.X > this.point_0.X)
            {
                x = argument.X;
                num2 = this.point_0.X;
                num5 = this.point_0.X;
            }
            else
            {
                x = this.point_0.X;
                num2 = argument.X;
                num5 = argument.X;
            }
            if (argument.Y > this.point_0.Y)
            {
                y = argument.Y;
                num4 = this.point_0.Y;
                num6 = this.point_0.Y;
            }
            else
            {
                y = this.point_0.Y;
                num4 = argument.Y;
                num6 = argument.Y;
            }
            this.rectangle_0 = new Rectangle(num5, num6, x - num2, y - num4);
            this.bool_2 = true;
            for (int i = 0; i < this.int_2; i++)
            {
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    if (this.class7_0[i, j] != null)
                    {
                        Class7_u class7_u_0 = this.class7_0[i, j];
                        if (this.rectangle_0.Contains((int) class7_u_0.method_8(), (int) class7_u_0.method_10()))
                        {
                            this.class7_0[i, j].bool_1 = true;
                            this.ctrlGrid_0.method_15(i, j, true);
                            base.Invalidate(false);
                            base.Update();
                            return;
                        }
                    }
                }
            }
            this.Refresh();
        }
    }*/

    private void clearPlotsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        this.method_17();
    }

    private void ctrlMapGraph_KeyDown(object sender, KeyEventArgs e)
    {
        this.bool_4 = e.Control;
        /*if (this.class10_0.GetKeyPressed(e, "Increase Selected Cells"))
        {
            this.frmGridChart_0.toolIncrease_Click(null, null);
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        else if (this.class10_0.GetKeyPressed(e, "Decrease Selected Cells"))
        {
            this.frmGridChart_0.toolDecrease_Click(null, null);
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        else */
        if (this.class10_settings_0.GetKeyPressed(e, "Press escape to cancel the current dragging"))
        {
            this.bool_3 = false;
        }
        else
        {
            e.Handled = false;
        }
    }

    private void ctrlMapGraph_Load(object sender, EventArgs e)
    {
        this.int_14 = base.ClientRectangle.Height;
        this.int_15 = base.ClientRectangle.Width;
        try
        {
            this.class16_u_0.method_1(null, base.ClientRectangle.Width, base.ClientRectangle.Height);
            this.method_3();
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message + " " + exception.Source);
            throw;
        }
    }

    private void ctrlMapGraph_MouseDown(object sender, MouseEventArgs e)
    {
        if ((this.mapGraphType_0 != MapGraphType.rpmPlot) && (this.mapGraphType_0 != MapGraphType.timePlot))
        {
            try
            {
                this.point_0.X = e.X;
                this.point_0.Y = e.Y;
                this.point_1.Y = e.Y;
                this.point_1.X = e.X;
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < this.int_2; i++)
                    {
                        for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                        {
                            if (this.class7_u_0[i, j] != null)
                            {
                                Class7_u class7_u_0 = this.class7_u_0[i, j];
                                Rectangle rectangle = new Rectangle(((int)class7_u_0.method_8()) - 4, ((int)class7_u_0.method_10()) - 4, 8, 8);
                                Point p = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                                p = base.PointToClient(p);
                                if (rectangle.Contains(p.X, p.Y) && !this.class7_u_0[i, j].bool_1)
                                {
                                    if (!this.bool_4)
                                    {
                                        this.ctrlGrid_0.method_17_ClearSelection();
                                        this.class7_u_1.Clear();
                                    }
                                    this.class7_u_0[i, j].bool_1 = true;
                                    this.ctrlGrid_0.method_15(i, j, this.bool_4);
                                    base.Invalidate();
                                    //this.Refresh(); // this one disabled
                                    return;
                                }
                                if (rectangle.Contains(p.X, p.Y) && this.class7_u_0[i, j].bool_1)
                                {
                                    this.bool_3 = true;
                                }
                                else
                                {
                                    this.bool_0 = true;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }

    private void ctrlMapGraph_MouseEnter(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Cross;
    }

    private void ctrlMapGraph_MouseHover(object sender, EventArgs e)
    {
        base.Focus();
    }

    private void ctrlMapGraph_MouseLeave(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Default;
    }

    private void ctrlMapGraph_MouseMove(object sender, MouseEventArgs e)
    {
        if ((this.mapGraphType_0 != MapGraphType.rpmPlot) && (this.mapGraphType_0 != MapGraphType.timePlot))
        {
            try
            {
                this.point_1.X = e.X;
                this.point_1.Y = e.Y;
                if (this.bool_3)
                {
                    foreach (Class7_u class7_u_0 in this.class7_u_1)
                    {
                        this.double_0 = -((float) (e.Y - this.point_0.Y) / (float) (this.int_12 - this.point_0.Y)) * 100.0;
                    }
                    base.Invalidate();
                    //this.Refresh(); // this one disabled
                }
                else if (this.bool_0 && !this.bool_3)
                {
                    int x;
                    int num5;
                    int y;
                    int num7;
                    int num8;
                    int num9;
                    MouseEventArgs args = e;
                    if (args.X > this.point_0.X)
                    {
                        x = args.X;
                        num5 = this.point_0.X;
                        num8 = this.point_0.X;
                    }
                    else
                    {
                        x = this.point_0.X;
                        num5 = args.X;
                        num8 = args.X;
                    }
                    if (args.Y > this.point_0.Y)
                    {
                        y = args.Y;
                        num7 = this.point_0.Y;
                        num9 = this.point_0.Y;
                    }
                    else
                    {
                        y = this.point_0.Y;
                        num7 = args.Y;
                        num9 = args.Y;
                    }
                    this.rectangle_0 = new Rectangle(num8, num9, x - num5, y - num7);
                    this.bool_2 = true;
                    for (int i = 0; i < this.int_2; i++)
                    {
                        for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                        {
                            if (this.class7_u_0[i, j] != null)
                            {
                                if (this.rectangle_0.Contains((int)this.class7_u_0[i, j].method_8(), (int)this.class7_u_0[i, j].method_10()))
                                {
                                    if (!this.class7_u_0[i, j].bool_1)
                                    {
                                        this.class7_u_0[i, j].bool_1 = true;
                                        this.ctrlGrid_0.method_15(i, j, true);
                                    }
                                }
                                else
                                {
                                    this.class7_u_0[i, j].bool_1 = false;
                                    this.ctrlGrid_0.method_16(i, j);
                                }
                            }
                        }
                    }
                    base.Invalidate();
                    //this.Refresh(); // this one disabled
                }
                else
                {
                    for (int k = 0; k < this.int_2; k++)
                    {
                        for (int m = 0; m < this.class18_0.method_32_GetRPM_RowsNumber(); m++)
                        {
                            if (this.class7_u_0[k, m] != null)
                            {
                                Class7_u class7_u_0 = this.class7_u_0[k, m];
                                Rectangle rectangle = new Rectangle(((int)class7_u_0.method_8()) - 4, ((int)class7_u_0.method_10()) - 4, 8, 8);
                                Point p = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                                p = base.PointToClient(p);
                                if (rectangle.Contains(p.X, p.Y) && class7_u_0.bool_1)
                                {
                                    if (!this.bool_1)
                                    {
                                        this.bool_1 = true;
                                        this.int_0 = k;
                                        this.int_1 = m;
                                    }
                                    break;
                                }
                                this.bool_1 = false;
                            }
                        }
                    }
                    base.Invalidate();
                    //this.Refresh(); // this one disabled
                }
                this.point_2.X = e.X;
                this.point_2.Y = e.Y;
            }
            catch { }
        }
    }

    private void ctrlMapGraph_MouseUp(object sender, MouseEventArgs e)
    {
        this.bool_0 = false;
        this.bool_2 = false;
        if (this.bool_3)
        {
            this.class18_0.method_155("Table : " + this.class18_0.method_4().ToString() + " graph adjustments");
            foreach (Class7_u class7_u_0 in this.class7_u_1)
            {
                try
                {
                    float num = this.class18_0.method_174((byte) class7_u_0.method_0(), (byte) class7_u_0.method_2());
                    this.class18_0.method_176((byte) class7_u_0.method_0(), (byte) class7_u_0.method_2(), num + (num * ((float) (Math.Round(this.double_0, 0) / 100.0))));
                    this.ctrlGrid_0.method_34(class7_u_0.method_0(), class7_u_0.method_2());
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            this.class18_0.method_153();
            this.bool_3 = false;
        }
        this.Refresh();
    }

    private void ctrlMapGraph_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.bool_0 = false;
            this.bool_3 = false;
            base.Invalidate();
        }
        if (e.Shift)
        {
            if (e.Shift && (e.KeyCode == Keys.Right))
            {
                for (int i = 0; i < this.int_2; i++)
                {
                    for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                    {
                        if (this.class7_u_0[i, j] != null)
                        {
                            byte num3 = (byte) this.ctrlGrid_0.method_10()[0];
                            byte num5 = (byte) this.ctrlGrid_0.method_10()[1];
                            byte num4 = (byte) this.ctrlGrid_0.method_10()[2];
                            byte num6 = (byte) this.ctrlGrid_0.method_10()[3];
                            if ((this.class7_u_0[i, j].bool_1 && (i == num4)) && ((j == num6) && (j < (this.class18_0.method_32_GetRPM_RowsNumber() - 1))))
                            {
                                this.ctrlGrid_0.method_15(i, j + 1, true);
                                num3 = (byte) this.ctrlGrid_0.method_10()[0];
                                num5 = (byte) this.ctrlGrid_0.method_10()[1];
                                num4 = (byte) this.ctrlGrid_0.method_10()[2];
                                num6 = (byte) this.ctrlGrid_0.method_10()[3];
                                this.ctrlGrid_0.method_17_ClearSelection();
                                for (int k = num3; k <= i; k++)
                                {
                                    for (int m = num5; m <= (j + 1); m++)
                                    {
                                        this.ctrlGrid_0.method_15(k, m, true);
                                    }
                                }
                                base.Invalidate();
                                //this.Refresh(); // this one disabled
                                return;
                            }
                        }
                    }
                }
            }
            else if (e.Shift && (e.KeyCode == Keys.Left))
            {
                for (int n = 0; n < this.int_2; n++)
                {
                    for (int num10 = 0; num10 < this.class18_0.method_32_GetRPM_RowsNumber(); num10++)
                    {
                        if (this.class7_u_0[n, num10] != null)
                        {
                            byte num11 = (byte) this.ctrlGrid_0.method_10()[0];
                            byte num13 = (byte) this.ctrlGrid_0.method_10()[1];
                            byte num12 = (byte) this.ctrlGrid_0.method_10()[2];
                            byte num14 = (byte) this.ctrlGrid_0.method_10()[3];
                            if (((this.class7_u_0[n, num10].bool_1 && (n == num12)) && ((num10 == num14) && (num10 <= this.class18_0.method_32_GetRPM_RowsNumber()))) && (num10 > 0))
                            {
                                this.ctrlGrid_0.method_15(n, num10 - 1, e.Shift);
                                num11 = (byte) this.ctrlGrid_0.method_10()[0];
                                num13 = (byte) this.ctrlGrid_0.method_10()[1];
                                num12 = (byte) this.ctrlGrid_0.method_10()[2];
                                num14 = (byte) this.ctrlGrid_0.method_10()[3];
                                this.ctrlGrid_0.method_17_ClearSelection();
                                for (int num15 = num11; num15 <= n; num15++)
                                {
                                    for (int num16 = num13; num16 <= (num10 - 1); num16++)
                                    {
                                        this.ctrlGrid_0.method_15(num15, num16, true);
                                    }
                                }
                                base.Invalidate();
                                //this.Refresh(); // this one disabled
                                return;
                            }
                        }
                    }
                }
            }
            else if (e.Shift && (e.KeyCode == Keys.Down))
            {
                for (int num17 = 0; num17 < this.int_2; num17++)
                {
                    for (int num18 = 0; num18 < this.class18_0.method_32_GetRPM_RowsNumber(); num18++)
                    {
                        if (this.class7_u_0[num17, num18] != null)
                        {
                            byte num19 = (byte) this.ctrlGrid_0.method_10()[0];
                            byte num21 = (byte) this.ctrlGrid_0.method_10()[1];
                            byte num20 = (byte) this.ctrlGrid_0.method_10()[2];
                            byte num22 = (byte) this.ctrlGrid_0.method_10()[3];
                            if ((this.class7_u_0[num17, num18].bool_1 && (num17 == num20)) && (num18 == num22))
                            {
                                if (this.class18_0.method_40())
                                {
                                    if ((num17 < (this.int_2 - 1)) && (num17 >= 0))
                                    {
                                        this.ctrlGrid_0.method_15(num17 + 1, num18, e.Shift);
                                        num19 = (byte) this.ctrlGrid_0.method_10()[0];
                                        num21 = (byte) this.ctrlGrid_0.method_10()[1];
                                        num20 = (byte) this.ctrlGrid_0.method_10()[2];
                                        num22 = (byte) this.ctrlGrid_0.method_10()[3];
                                        this.ctrlGrid_0.method_17_ClearSelection();
                                        for (int num23 = num19; num23 <= num20; num23++)
                                        {
                                            for (int num24 = num21; num24 <= num22; num24++)
                                            {
                                                this.ctrlGrid_0.method_15(num23, num24, true);
                                            }
                                        }
                                        base.Invalidate();
                                        //this.Refresh(); // this one disabled
                                        return;
                                    }
                                }
                                else if ((!this.class18_0.method_40() && (num17 <= (this.int_2 - 1))) && (num17 > 0))
                                {
                                    this.ctrlGrid_0.method_15(num17 - 1, num18, e.Shift);
                                    num19 = (byte) this.ctrlGrid_0.method_10()[0];
                                    num21 = (byte) this.ctrlGrid_0.method_10()[1];
                                    num20 = (byte) this.ctrlGrid_0.method_10()[2];
                                    num22 = (byte) this.ctrlGrid_0.method_10()[3];
                                    this.ctrlGrid_0.method_17_ClearSelection();
                                    for (int num25 = num19; num25 <= num20; num25++)
                                    {
                                        for (int num26 = num21; num26 <= num22; num26++)
                                        {
                                            this.ctrlGrid_0.method_15(num25, num26, true);
                                        }
                                    }
                                    base.Invalidate();
                                    //this.Refresh(); // this one disabled
                                    return;
                                }
                                if (num17 < (this.class18_0.method_32_GetRPM_RowsNumber() - 2))
                                {
                                }
                            }
                        }
                    }
                }
            }
            else if (e.Shift && (e.KeyCode == Keys.Up))
            {
                for (int num27 = 0; num27 < this.int_2; num27++)
                {
                    for (int num28 = 0; num28 < this.class18_0.method_32_GetRPM_RowsNumber(); num28++)
                    {
                        if (this.class7_u_0[num27, num28] != null)
                        {
                            byte num29 = (byte) this.ctrlGrid_0.method_10()[0];
                            byte num31 = (byte) this.ctrlGrid_0.method_10()[1];
                            byte num30 = (byte) this.ctrlGrid_0.method_10()[2];
                            byte num32 = (byte) this.ctrlGrid_0.method_10()[3];
                            if ((this.class7_u_0[num27, num28].bool_1 && (num27 == num30)) && (num28 == num32))
                            {
                                if (this.class18_0.method_40())
                                {
                                    if (num27 > 0)
                                    {
                                        this.ctrlGrid_0.method_15(num27 - 1, num28, e.Shift);
                                        num29 = (byte) this.ctrlGrid_0.method_10()[0];
                                        num31 = (byte) this.ctrlGrid_0.method_10()[1];
                                        num30 = (byte) this.ctrlGrid_0.method_10()[2];
                                        num32 = (byte) this.ctrlGrid_0.method_10()[3];
                                        this.ctrlGrid_0.method_17_ClearSelection();
                                        for (int num33 = num29; num33 <= num30; num33++)
                                        {
                                            for (int num34 = num31; num34 <= num32; num34++)
                                            {
                                                this.ctrlGrid_0.method_15(num33, num34, true);
                                            }
                                        }
                                        base.Invalidate();
                                        //this.Refresh(); // this one disabled
                                        return;
                                    }
                                }
                                else if (!this.class18_0.method_40() && (num27 < (this.int_2 - 1)))
                                {
                                    this.ctrlGrid_0.method_15(num27 + 1, num28, e.Shift);
                                    num29 = (byte) this.ctrlGrid_0.method_10()[0];
                                    num31 = (byte) this.ctrlGrid_0.method_10()[1];
                                    num30 = (byte) this.ctrlGrid_0.method_10()[2];
                                    num32 = (byte) this.ctrlGrid_0.method_10()[3];
                                    this.ctrlGrid_0.method_17_ClearSelection();
                                    for (int num35 = num29; num35 <= (num27 + 1); num35++)
                                    {
                                        for (int num36 = num31; num36 <= num28; num36++)
                                        {
                                            this.ctrlGrid_0.method_15(num35, num36, true);
                                        }
                                    }
                                    base.Invalidate();
                                    //this.Refresh(); // this one disabled
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (!e.Shift && !e.Control)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int num37 = 0; num37 < this.int_2; num37++)
                {
                    for (int num38 = 0; num38 < this.class18_0.method_32_GetRPM_RowsNumber(); num38++)
                    {
                        if ((this.class7_u_0[num37, num38] != null) && this.class7_u_0[num37, num38].bool_1)
                        {
                            if (num38 < (this.class18_0.method_32_GetRPM_RowsNumber() - 1))
                            {
                                this.ctrlGrid_0.method_15(num37, num38 + 1, false);
                                base.Invalidate();
                                //this.Refresh(); // this one disabled
                            }
                            return;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                for (int num39 = 0; num39 < this.int_2; num39++)
                {
                    for (int num40 = 0; num40 < this.class18_0.method_32_GetRPM_RowsNumber(); num40++)
                    {
                        if ((this.class7_u_0[num39, num40] != null) && this.class7_u_0[num39, num40].bool_1)
                        {
                            if ((num40 <= this.class18_0.method_32_GetRPM_RowsNumber()) && (num40 > 0))
                            {
                                this.ctrlGrid_0.method_15(num39, num40 - 1, false);
                                base.Invalidate();
                                //this.Refresh(); // this one disabled
                            }
                            return;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                for (int num41 = 0; num41 < this.int_2; num41++)
                {
                    for (int num42 = 0; num42 < this.class18_0.method_32_GetRPM_RowsNumber(); num42++)
                    {
                        if ((this.class7_u_0[num41, num42] != null) && this.class7_u_0[num41, num42].bool_1)
                        {
                            if (!this.class18_0.method_40())
                            {
                                if (!this.class18_0.method_40())
                                {
                                    if (num41 >= (this.int_2 - 1))
                                    {
                                        continue;
                                    }
                                    this.ctrlGrid_0.method_15(num41 + 1, num42, false);
                                    base.Invalidate();
                                    //this.Refresh(); // this one disabled
                                }
                                return;
                            }
                            if (num41 > 0)
                            {
                                this.ctrlGrid_0.method_15(num41 - 1, num42, false);
                                base.Invalidate();
                                //this.Refresh(); // this one disabled
                                return;
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                for (int num43 = 0; num43 < this.int_2; num43++)
                {
                    for (int num44 = 0; num44 < this.class18_0.method_32_GetRPM_RowsNumber(); num44++)
                    {
                        if ((this.class7_u_0[num43, num44] != null) && this.class7_u_0[num43, num44].bool_1)
                        {
                            if (!this.class18_0.method_40())
                            {
                                if (!this.class18_0.method_40())
                                {
                                    if ((num43 > (this.int_2 - 1)) || (num43 <= 0))
                                    {
                                        continue;
                                    }
                                    this.ctrlGrid_0.method_15(num43 - 1, num44, false);
                                    base.Invalidate();
                                    //this.Refresh(); // this one disabled
                                }
                                return;
                            }
                            if ((num43 < (this.int_2 - 1)) && (num43 >= 0))
                            {
                                this.ctrlGrid_0.method_15(num43 + 1, num44, false);
                                base.Invalidate();
                                //this.Refresh(); // this one disabled
                                return;
                            }
                        }
                    }
                }
            }
        }
    }

    private void ctrlMapGraph_Resize(object sender, EventArgs e)
    {
        try
        {
            this.class16_u_0.method_1(base.CreateGraphics(), base.ClientRectangle.Width, base.ClientRectangle.Height);
            if ((this.int_14 != 0) && (this.int_15 != 0))
            {
                float num = ((float) base.ClientRectangle.Height) / ((float) this.int_14);
                float num2 = ((float) base.ClientRectangle.Width) / ((float) this.int_15);
                if (this.struct19_0 != null)
                {
                    for (int i = 0; i < this.class10_settings_0.int_5; i++)
                    {
                        this.struct19_0[i].int_0 = ((int) ((this.struct19_0[i].int_0 - this.int_5) * num2)) + this.int_5;
                        this.struct19_0[i].int_1 = (int) (this.struct19_0[i].int_1 * num);
                    }
                }
            }
            else
            {
                this.method_17();
            }
            this.int_15 = base.ClientRectangle.Width;
            this.int_14 = base.ClientRectangle.Height;
            this.Refresh(); // this one disabled
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message + " " + exception.Source);
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

    private void hideGraphMenuItem_Click(object sender, EventArgs e)
    {
        this.class10_settings_0.bool_6 = !this.class10_settings_0.bool_6;
        //this.frmGridChart_0.splitContainer1.Panel2Collapsed = !this.class10_0.bool_6;
        base.Invalidate();
    }

    private void InitializeComponent()
    {
            this.clearPlotsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // clearPlotsToolStripMenuItem1
            // 
            this.clearPlotsToolStripMenuItem1.Name = "clearPlotsToolStripMenuItem1";
            this.clearPlotsToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.clearPlotsToolStripMenuItem1.Text = "Clear Plots";
            this.clearPlotsToolStripMenuItem1.Click += new System.EventHandler(this.clearPlotsToolStripMenuItem1_Click);
            // 
            // ctrlMapGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlMapGraph";
            this.Size = new System.Drawing.Size(126, 112);
            this.Load += new System.EventHandler(this.ctrlMapGraph_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ctrlMapGraph_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrlMapGraph_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ctrlMapGraph_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ctrlMapGraph_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ctrlMapGraph_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctrlMapGraph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctrlMapGraph_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ctrlMapGraph_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.ctrlMapGraph_Resize);
            this.ResumeLayout(false);

    }

    /*private void Item2D_Click(object sender, EventArgs e)
    {
        this.mapGraphType_0 = MapGraphType.twoD;
        this.class10_0.int_2 = (int) this.mapGraphType_0;
        this.method_18();
        base.Invalidate();
    }

    private void item3d_Click(object sender, EventArgs e)
    {
        this.mapGraphType_0 = MapGraphType.threeD;
        this.class10_0.int_2 = (int) this.mapGraphType_0;
        this.method_18();
        base.Invalidate();
    }*/

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1, ref CtrlGrid ctrlGrid_1, ref FrmGridChart frmGridChart_1)
    {
        try
        {
            this.class18_0 = class18_1;
            this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
            this.class10_settings_0 = class10_1;
            this.ctrlGrid_0 = ctrlGrid_1;
            this.frmGridChart_0 = frmGridChart_1;
            this.ctrlGrid_0.delegate44_0 += new CtrlGrid.Delegate44(this.method_2);
            this.class10_settings_0.delegate14_0 += new Class10_settings.Delegate14(this.method_1);

            foreach (Control control in base.Controls)
            {
                float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
                control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message + " " + exception.Source);
            throw;
        }
    }

    private void method_1()
    {
        base.Invalidate();
    }

    private void method_10()
    {
        float num;
        string str;
        Pen pen = new Pen(this.class10_settings_0.color_11, 1f);
        Pen pen2 = new Pen(this.class10_settings_0.color_14, 1f);
        Font font = new Font("Lucida Sans", 8f, FontStyle.Regular);
        Font font2 = new Font("Lucida Sans", 8f, FontStyle.Regular);
        SolidBrush brush2 = new SolidBrush(this.class10_settings_0.color_11);
        float num2 = 0f;
        StringFormat format = new StringFormat {
            FormatFlags = StringFormatFlags.DirectionVertical
        };

        //Rpm
        this.graphics_0.DrawString("RPM\n*1000", font, brush2, (float)(base.ClientRectangle.Left + 2), (float)(base.ClientRectangle.Bottom - (this.int_11 - (font.Height / 8)) - 7));
        for (float i = 0f; i <= (this.float_4 / this.float_2); i++)
        {
            num = this.int_10 + ((i * this.int_13) / (this.float_4 / this.float_2));
            str = (num2 / 1000).ToString();
            if (i != 0)
                this.graphics_0.DrawString(str, font, brush2, num - (this.graphics_0.MeasureString(str, font).Width / 2f), (float) (base.ClientRectangle.Bottom - (this.int_11 - (font.Height / 8)) + 5));
            if (i != 0 && i != (this.float_4 / this.float_2))
                this.graphics_0.DrawLine(pen2, base.ClientRectangle.Left + num, (float) (base.ClientRectangle.Bottom - this.int_11), base.ClientRectangle.Left + num, (float) (base.ClientRectangle.Top + this.int_11));
            else
                this.graphics_0.DrawLine(pen, base.ClientRectangle.Left + num, (float)(base.ClientRectangle.Bottom - this.int_11), base.ClientRectangle.Left + num, (float)(base.ClientRectangle.Top + this.int_11));
            num2 += this.float_2;
        }
        num2 = 0f;

        //Fuel Value
        for (float j = 0f; j <= (this.float_5 / this.float_3); j++)
        {
            num = this.int_11 + ((j * this.int_12) / (this.float_5 / this.float_3));
            if (num2 != 0f)
            {
                this.graphics_0.DrawString((num2).ToString("N0"), font2, brush2, (float) (base.ClientRectangle.Left + 2), (float) (base.ClientRectangle.Bottom - num - 5));
            }
            if (j != 0 && j != (this.float_5 / this.float_3))
                this.graphics_0.DrawLine(pen2, (float) (base.ClientRectangle.Left + this.int_10), base.ClientRectangle.Bottom - num, base.ClientRectangle.Right - this.int_10_0, base.ClientRectangle.Bottom - num);
            else
                this.graphics_0.DrawLine(pen, (float)(base.ClientRectangle.Left + this.int_10), base.ClientRectangle.Bottom - num, base.ClientRectangle.Right - this.int_10_0, base.ClientRectangle.Bottom - num);
            num2 += this.float_3;
        }
        
        pen.Dispose();
        font.Dispose();
        brush2.Dispose();
        format.Dispose();
        format = null;
        pen = null;
        font = null;
        brush2 = null;
    }

    private void method_11()
    {
        try {
            SolidBrush brush = new SolidBrush(Color.Red);
            Pen pen = new Pen(Color.Red, 2f);
            Pen pen2 = new Pen(this.class10_settings_0.color_2, 1f);
            Pen pen3 = new Pen(this.class18_0.class10_settings_0.color_Trace, 1f);
            Pen pen4 = new Pen(this.class10_settings_0.color_2);
            SolidBrush brush2 = new SolidBrush(this.class18_0.class10_settings_0.color_Trace);
            Font font = new Font("Lucida Sans", 6.5f, FontStyle.Bold);
            SolidBrush brush3 = new SolidBrush(Color.White);
            Class7_u class7_u_0 = null;
            Class7_u class7_u_1 = null;
            //this.class7_1 = null;
            int green = 0;
            int row = 0;
            float num3 = 0f;
            for (int i = 0; i < this.int_2; i++)
            {
                row = 0;
                class7_u_0 = null;
                class7_u_1 = null;
                green = (0xff - ((((0xff * i) + 1) / this.int_2) + 1)) % 0xff;
                if (green < 0)
                {
                    green *= -1;
                }
                row = 0;
                while (row < this.class18_0.method_32_GetRPM_RowsNumber())
                {
                    pen.Color = this.class18_0.method_236((double)this.class18_0.method_174((byte)i, (byte)row));
                    brush.Color = this.class18_0.method_236((double)this.class18_0.method_174((byte)i, (byte)row));
                    num3 = this.class18_0.method_174((byte)i, (byte)row);
                    if (num3 < 0f)
                    {
                        num3 = 0f;
                    }
                    float yChart = (this.int_12 - ((this.int_12 * num3) / this.float_5)) + this.int_11;
                    float xChart = this.int_10 + ((((float)this.class18_0.method_159((byte)row)) / this.float_4) * this.int_13);
                    if (this.class7_u_0[i, row] == null)
                    {
                        this.class7_u_0[i, row] = new Class7_u(xChart, yChart, (float)this.class18_0.method_159((byte)row), this.class18_0.method_174((byte)i, (byte)row), i, row);
                        this.class7_u_0[i, row].bool_1 = this.ctrlGrid_0.method_13(i, row);
                        this.class7_u_0[i, row].bool_2 = this.ctrlGrid_0.method_14(i, row);
                    }
                    else if (!this.bool_3)
                    {
                        this.class7_u_0[i, row].method_9(xChart);
                        this.class7_u_0[i, row].method_11(yChart);
                        this.class7_u_0[i, row].float_4 = yChart;
                        this.class7_u_0[i, row].method_7(this.class18_0.method_174((byte)i, (byte)row));
                        this.class7_u_0[i, row].bool_1 = this.ctrlGrid_0.method_13(i, row);
                        this.class7_u_0[i, row].bool_2 = this.ctrlGrid_0.method_14(i, row);
                    }
                    class7_u_1 = this.class7_u_0[i, row];
                    this.graphics_0.FillRectangle(brush, (float)(class7_u_1.method_8() - 2f), (float)(class7_u_1.method_10() - 2f), (float)5f, (float)5f);
                    if (class7_u_0 != null)
                    {
                        /*if (i > 0 && row > 0)
                        {
                            try
                            {
                                this.pointF_0 = new PointF[4];
                                this.pointF_0[0].X = this.class7_0[i, row].method_8();
                                this.pointF_0[0].Y = this.class7_0[i, row].method_10();
                                this.pointF_0[1].X = this.class7_0[i - 1, row].method_8();
                                this.pointF_0[1].Y = this.class7_0[i - 1, row].method_10();
                                this.pointF_0[2].X = this.class7_0[i - 1, row - 1].method_8();
                                this.pointF_0[2].Y = this.class7_0[i - 1, row - 1].method_10();
                                this.pointF_0[3].X = this.class7_0[i, row - 1].method_8();
                                this.pointF_0[3].Y = this.class7_0[i, row - 1].method_10();
                                this.graphics_0.FillPolygon(brush, pointF_0);
                            }
                            catch (Exception Message) { Console.WriteLine(Message); }
                        }
                        pen.Color = Color.Black;*/
                        this.graphics_0.DrawLine(pen, class7_u_0.method_8(), class7_u_0.method_10(), class7_u_1.method_8(), class7_u_1.method_10());
                        if (class7_u_0.bool_2 && !this.class10_settings_0.bool_45)
                        {
                            switch (this.class10_settings_0.mapGraphSelect_0)
                            {
                                case MapGraphSelect.sqaure:
                                    this.graphics_0.DrawRectangle(pen3, (float)(class7_u_0.method_8() - 4f), (float)(class7_u_0.method_10() - 3.5f), (float)8f, (float)8f);
                                    break;

                                case MapGraphSelect.fill:
                                    {
                                        SolidBrush brush4 = new SolidBrush(this.class10_settings_0.color_Trace);
                                        this.graphics_0.FillRectangle(brush4, (float)(class7_u_0.method_8() - 2f), (float)(class7_u_0.method_10() - 4f), (float)8f, (float)8f);
                                        brush4.Dispose();
                                        brush4 = null;
                                        break;
                                    }
                            }
                        }
                        if (class7_u_0.bool_1)
                        {
                            switch (this.class10_settings_0.mapGraphSelect_0)
                            {
                                case MapGraphSelect.sqaure:
                                    this.graphics_0.DrawRectangle(pen4, (float)(class7_u_0.method_8() - 4f), (float)(class7_u_0.method_10() - 3.5f), (float)8f, (float)8f);
                                    break;

                                case MapGraphSelect.fill:
                                    {
                                        SolidBrush brush5 = new SolidBrush(this.class10_settings_0.color_2);
                                        this.graphics_0.FillRectangle(brush5, (float)(class7_u_0.method_8() - 4f), (float)(class7_u_0.method_10() - 3.5f), (float)8f, (float)8f);
                                        brush5.Dispose();
                                        brush5 = null;
                                        break;
                                    }
                            }
                        }
                    }
                    if ((row != 0) && this.class7_u_0[i, row - 1].bool_1)
                    {
                        this.graphics_0.DrawRectangle(pen2, (float)(this.class7_u_0[i, row - 1].method_8() - 4f), (float)(this.class7_u_0[i, row - 1].method_10() - 3.5f), (float)8f, (float)8f);
                    }
                    if (this.class7_u_0[i, row].bool_2 && !this.class10_settings_0.bool_45)
                    {
                        switch (this.class10_settings_0.mapGraphSelect_0)
                        {
                            case MapGraphSelect.sqaure:
                                this.graphics_0.DrawRectangle(pen3, (float)(this.class7_u_0[i, row].method_8() - 4f), (float)(this.class7_u_0[i, row].method_10() - 3.5f), (float)8f, (float)8f);
                                break;

                            case MapGraphSelect.fill:
                                {
                                    SolidBrush brush6 = new SolidBrush(this.class10_settings_0.color_Trace);
                                    this.graphics_0.FillRectangle(brush6, (float)(this.class7_u_0[i, row].method_8() - 2f), (float)(this.class7_u_0[i, row].method_10() - 4f), (float)8f, (float)8f);
                                    brush6.Dispose();
                                    brush6 = null;
                                    break;
                                }
                        }
                    }
                    if ((row != 0) && this.class7_u_0[i, row - 1].bool_2)
                    {
                        bool flag1 = this.class10_settings_0.bool_45;
                    }
                    if (this.class7_u_0[i, row].bool_1)
                    {
                        switch (this.class10_settings_0.mapGraphSelect_0)
                        {
                            case MapGraphSelect.sqaure:
                                this.graphics_0.DrawRectangle(pen4, (float)(this.class7_u_0[i, row].method_8() - 4f), (float)(this.class7_u_0[i, row].method_10() - 3.5f), (float)8f, (float)8f);
                                break;

                            case MapGraphSelect.fill:
                                {
                                    SolidBrush brush7 = new SolidBrush(this.class10_settings_0.color_2);
                                    this.graphics_0.FillRectangle(brush7, (float)(this.class7_u_0[i, row].method_8() - 4f), (float)(this.class7_u_0[i, row].method_10() - 3.5f), (float)8f, (float)8f);
                                    brush7.Dispose();
                                    brush7 = null;
                                    break;
                                }
                        }
                    }
                    class7_u_0 = class7_u_1;
                    row++;
                }

                //mBar value
                /*if (this.class10_0.bool_17)
                {
                    if (this.class10_0.bool_18)
                    {
                        this.graphics_0.DrawString(this.class18_0.method_163((byte) i).ToString(), font, brush3, (float) (this.class7_0[i, row - 1].method_8() + 5f), (float) (this.class7_0[i, row - 1].method_10() - 6f));
                    }
                    else
                    {
                        this.graphics_0.DrawString(this.class18_0.method_167((byte) i), font, brush3, (float) (this.class7_0[i, row - 1].method_8() + 5f), (float) (this.class7_0[i, row - 1].method_10() - 6f));
                    }
                }*/
            }
            pen.Dispose();
            pen = null;
            pen4.Dispose();
            pen4 = null;
            pen3.Dispose();
            pen3 = null;
            pen2.Dispose();
            pen2 = null;
            font.Dispose();
            font = null;
            brush3.Dispose();
            brush3 = null;
            brush.Dispose();
            brush = null;
            brush2.Dispose();
            brush2 = null;
        }
        catch{ }
    }

    //Mouse Move drag +/- edit value percentage
    private void method_12(string string_0, float float_28, float float_29, bool bool_5)
    {
        if (bool_5)
        {
            this.graphics_0.FillRectangle(new SolidBrush(Color.FromArgb(20, 190, 20)), (float) (float_28 - 5f), (float) (float_29 - 20f), (float) 35f, (float) 15f);
        }
        else
        {
            this.graphics_0.FillRectangle(new SolidBrush(Color.FromArgb(215, 120, 120)), (float) (float_28 - 5f), (float) (float_29 - 20f), (float) 35f, (float) 15f);
        }
        this.graphics_0.DrawString(string_0, new Font("Lucida Sans", 7f, FontStyle.Regular), new SolidBrush(this.class10_settings_0.color_11), (float) (float_28 - 5f), (float) (float_29 - 20f));
    }

    private void method_13(string string_0, float float_28, float float_29)
    {
        this.graphics_0.FillRectangle(new SolidBrush(Color.White), (float) (float_28 - 5f), (float) (float_29 - 20f), (float) (this.graphics_0.MeasureString(string_0, new Font("Lucida Sans", 7f, FontStyle.Regular)).Width + 2f), (float) 15f);
        this.graphics_0.DrawString(string_0, new Font("Lucida Sans", 7f, FontStyle.Regular), new SolidBrush(this.class10_settings_0.color_11), (float) (float_28 - 5f), (float) (float_29 - 20f));
    }

    private void method_14(bool Inverted)
    {
        try
        {
            if (!this.bool_3)
            {
                int OffsetDoubling = 10;
                if (this.class18_0.method_40()) OffsetDoubling = 8;
                if (this.class18_0.method_38()) OffsetDoubling = 8;

                this.float_26 = 0.25f;   //0.4  .. 0.35
                this.float_27 = 0.1f;   //0.3
                this.float_6 = 10f;
                this.float_7 = 5f; //30  XOffset
                this.float_8 = 25f;  //20   YOffset from bottom
                this.float_11 = this.method_6();
                this.float_10 = this.method_7();
                float TopOffset = 20f; //top YOffset
                this.float_12 = this.float_7 + (base.ClientRectangle.Width * this.float_26);
                this.float_13 = (base.ClientRectangle.Height - this.float_8) - this.float_6;
                this.float_14 = this.float_7 * OffsetDoubling; // double xOffset on left side
                this.float_15 = ((base.ClientRectangle.Height - this.float_8) - this.float_6) - ((this.float_12 * this.float_27) * 8); // *2
                this.float_16 = (base.ClientRectangle.Width - this.float_7) - this.float_6;
                this.float_17 = ((base.ClientRectangle.Height - this.float_8) - this.float_6) - (((this.float_16 - this.float_12) * this.float_27) / 4); //not "/4"
                this.float_18 = this.float_14 - this.float_12;
                this.float_19 = this.float_15 - this.float_13;
                this.float_20 = this.float_16 - this.float_12;
                this.float_21 = this.float_17 - this.float_13;
                for (int i = 0; i < this.int_2; i++)
                {
                    for (int k = 0; k < this.class18_0.method_32_GetRPM_RowsNumber(); k++)
                    {
                        //if (this.class18_0.method_40())
                        if (Inverted)
                            this.float_22 = ((float)(this.class18_0.method_163((byte)(this.int_2 - 1)) - this.class18_0.method_163((byte)i))) / ((float)(this.class18_0.method_163((byte)(this.int_2 - 1)) - this.class18_0.method_165(0)));
                        else
                            this.float_22 = ((float)(this.class18_0.method_163((byte)i) - this.class18_0.method_163(0))) / ((float)(this.class18_0.method_163((byte)(this.int_2 - 1)) - this.class18_0.method_165(0)));

                        this.float_23 = ((float)(this.class18_0.method_159((byte)k) - this.class18_0.method_159(0))) / (this.float_10 - this.class18_0.method_159(0));

                        if (this.class7_u_0[i, k] == null) this.class7_u_0[i, k] = new Class7_u();
                        if (!this.bool_3)
                        {
                            this.class7_u_0[i, k].method_1(i);
                            this.class7_u_0[i, k].method_3(k);
                            this.class7_u_0[i, k].method_9((float)((int)((this.float_12 + (this.float_18 * this.float_22)) + (this.float_20 * this.float_23))));
                            this.class7_u_0[i, k].method_11((float)((int)((this.float_13 + (this.float_19 * this.float_22)) + (this.float_21 * this.float_23))));
                            this.class7_u_0[i, k].float_4 = this.class7_u_0[i, k].method_10();
                            this.class7_u_0[i, k].method_7((float)((int)((this.float_13 + (this.float_19 * this.float_22)) + (this.float_21 * this.float_23))));
                            this.class7_u_0[i, k].method_13(this.class18_0.method_174((byte)i, (byte)k));
                            this.class7_u_0[i, k].bool_1 = this.ctrlGrid_0.method_13(i, k);
                            this.class7_u_0[i, k].bool_2 = this.ctrlGrid_0.method_14(i, k);
                        }
                    }
                }
                if (this.class18_0.method_40())
                {
                    this.float_24 = (base.ClientRectangle.Top - this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6()) + TopOffset;
                }
                else
                {
                    this.float_24 = (base.ClientRectangle.Top - this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6()) + TopOffset;
                }
                float num3 = 0f;
                for (int j = 0; j < this.int_2; j++)
                {
                    for (int m = 0; m < this.class18_0.method_32_GetRPM_RowsNumber(); m++)
                    {
                        if (!this.bool_3)
                        {
                            num3 = this.class18_0.method_174((byte)j, (byte)m);
                            if (num3 < 0f)
                            {
                                num3 = 0f;
                            }
                            this.float_25 = num3 / this.float_11;
                            Class7_u class7_u_0 = this.class7_u_0[j, m];
                            class7_u_0.method_11(class7_u_0.method_10() + (this.float_24 * this.float_25));
                        }
                    }
                }
            }
        }
        catch { }
    }

    private void method_15()
    {
        try
        {
            Pen pen = new Pen(this.class10_settings_0.color_11);
            Font font = new Font("Lucida Sans", 7f, FontStyle.Bold);
            Font font2 = new Font("Lucida Sans", 14f, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(this.class10_settings_0.color_11);
            SolidBrush brush2 = new SolidBrush(this.class10_settings_0.color_14);
            StringFormat format = new StringFormat
            {
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };
            StringFormat format2 = new StringFormat
            {
                FormatFlags = StringFormatFlags.DirectionVertical
            };
            string s = null;
            
            int ColumnsN = ((base.ClientRectangle.Width + base.ClientRectangle.Height) / 90);

            //Get Maximum
            float XMax = 0;
            float YMax = 9999;
            float NMax = 0;
            for (int i = this.int_2 - 1; i > 0; i--)
            {
                for (int j = this.class18_0.method_32_GetRPM_RowsNumber() - 1; j > 0; j--)
                {
                    if (this.class7_u_0[i, j].method_8() > XMax) XMax = this.class7_u_0[i, j].method_8();
                    if (this.class7_u_0[i, j].method_10() < YMax) YMax = this.class7_u_0[i, j].method_10();
                    if (this.class18_0.method_174((byte)i, (byte)j) > NMax) NMax = this.class18_0.method_174((byte)i, (byte)j);
                }
            }

            //Fill bottom Rectangle before loading lines
            this.pointF_0[0].X = this.class7_u_0[0, 0].method_8();
            this.pointF_0[0].Y = this.class7_u_0[0, 0].method_6();
            this.pointF_0[1].X = this.class7_u_0[this.int_2 - 1, 0].method_8();
            this.pointF_0[1].Y = this.class7_u_0[this.int_2 - 1, 0].method_6();
            this.pointF_0[2].X = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
            this.pointF_0[2].Y = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();
            this.pointF_0[3].X = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
            this.pointF_0[3].Y = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();
            this.graphics_0.FillPolygon(brush2, this.pointF_0);

            this.pointF_0[0].X = this.class7_u_0[0, 0].method_8();
            this.pointF_0[0].Y = this.class7_u_0[0, 0].method_6();
            this.pointF_0[1].X = this.class7_u_0[this.int_2 - 1, 0].method_8();
            this.pointF_0[1].Y = this.class7_u_0[this.int_2 - 1, 0].method_6();
            this.pointF_0[2].X = this.class7_u_0[this.int_2 - 1, 0].method_8();
            this.pointF_0[2].Y = this.class7_u_0[this.int_2 - 1, 0].method_6() + 8;
            this.pointF_0[3].X = this.class7_u_0[0, 0].method_8();
            this.pointF_0[3].Y = this.class7_u_0[0, 0].method_6() + 8;
            this.graphics_0.FillPolygon(brush2, this.pointF_0);

            this.pointF_0[0].X = this.class7_u_0[0, 0].method_8();
            this.pointF_0[0].Y = this.class7_u_0[0, 0].method_6();
            this.pointF_0[1].X = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
            this.pointF_0[1].Y = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();
            this.pointF_0[2].X = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
            this.pointF_0[2].Y = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6() + 8;
            this.pointF_0[3].X = this.class7_u_0[0, 0].method_8();
            this.pointF_0[3].Y = this.class7_u_0[0, 0].method_6() + 8;
            this.graphics_0.FillPolygon(brush2, this.pointF_0);

            //Fill Top Rectangle before loading lines
            float X1 = this.class7_u_0[0, 0].method_8();
            float X2 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
            float X3 = this.class7_u_0[this.int_2 - 1, 0].method_8();
            float X4 = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();

            float Y1 = this.class7_u_0[0, 0].method_6();
            float Y2 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();
            float Y3 = this.class7_u_0[this.int_2 - 1, 0].method_6();
            float Y4 = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();

            int iryrt = 0;
            if (iryrt == 0)
            {

                this.pointF_0[0].X = X4;
                this.pointF_0[0].Y = YMax - 5;
                this.pointF_0[1].X = X2;
                this.pointF_0[1].Y = Y2 + ((0 * ((Y4 - Y2) / (ColumnsN - 1))) - (Y4 - YMax)) - 5;
                this.pointF_0[2].X = X2;
                this.pointF_0[2].Y = Y2;
                this.pointF_0[3].X = X4;
                this.pointF_0[3].Y = Y4;
                this.graphics_0.FillPolygon(brush2, this.pointF_0);
                
                X2 = this.class7_u_0[this.int_2 - 1, 0].method_8();
                X3 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
                Y2 = this.class7_u_0[this.int_2 - 1, 0].method_6();
                Y3 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();

                this.pointF_0[0].X = X2;
                this.pointF_0[0].Y = YMax - 5;
                this.pointF_0[1].X = X4;
                this.pointF_0[1].Y = YMax - 5;
                this.pointF_0[2].X = X4;
                this.pointF_0[2].Y = Y4;
                this.pointF_0[3].X = X2;
                this.pointF_0[3].Y = Y2;
                this.graphics_0.FillPolygon(brush2, this.pointF_0);
            }

            //###########################################
            X1 = this.class7_u_0[0, 0].method_8();
            X2 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
            X3 = this.class7_u_0[this.int_2 - 1, 0].method_8();
            X4 = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();

            Y1 = this.class7_u_0[0, 0].method_6();
            Y2 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();
            Y3 = this.class7_u_0[this.int_2 - 1, 0].method_6();
            Y4 = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();
            

            this.pointF_0[1].X = this.class7_u_0[((this.int_2 - 1) / 2), 0].method_8();
            this.pointF_0[1].Y = this.class7_u_0[((this.int_2 - 1) / 2), 0].method_6();
            s = "MAP";
            //this.graphics_0.DrawString(s, font2, brush, (float)(this.pointF_0[1].X - this.graphics_0.MeasureString(s, font2).Width) - 30, (float)(this.pointF_0[1].Y + 6));
            this.graphics_0.DrawString(s, font2, brush, (float)(this.pointF_0[1].X - this.graphics_0.MeasureString(s, font2).Width) - 8, (float)(this.pointF_0[1].Y + 8), format2);


            int ColumnsN2 = ((base.ClientRectangle.Width + base.ClientRectangle.Height) / 120);

            //Draw Maps rows
            for (int i = ColumnsN2-1; i > 0; i--)
            {
                this.pointF_0[0].X = X1 + (i * ((X3 - X1) / (ColumnsN2 - 1)));
                this.pointF_0[0].Y = Y1 + (i * ((Y3 - Y1) / (ColumnsN2 - 1)));
                this.pointF_0[1].X = X2 + (i * ((X4 - X2) / (ColumnsN2 - 1)));
                this.pointF_0[1].Y = Y2 + (i * ((Y4 - Y2) / (ColumnsN2 - 1)));

                //Draw Rows
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);
                
                //Draw Name
                int irtt = (i * this.int_2) / (ColumnsN2 - 1);
                s = this.class18_0.method_163((byte)irtt).ToString();

                //if (this.class18_0.method_4() == SelectedTable.fuel1_lo || this.class18_0.method_4() == SelectedTable.fuel1_hi || this.class18_0.method_4() == SelectedTable.fuel2_lo || this.class18_0.method_4() == SelectedTable.fuel2_hi)
                //{
                //    if (this.class18_0.method_206(byte.Parse(s)) <= this.class10_0.int_6)
                //        s = 0.ToString("0.00") + " psi";
                //    else
                //        s = this.class18_0.method_193(byte.Parse(s)).ToString("0.00") + this.class10_0.mapSensorUnits_1.ToString();
                //}
                //this.graphics_0.DrawString(s, font, brush, this.pointF_0[0].X + 0f, this.pointF_0[0].Y + 6f, format);
                if (i != 0 && i != ColumnsN2 - 1)
                    this.graphics_0.DrawString(s, font, brush, this.pointF_0[0].X - 6, this.pointF_0[0].Y + 11, format2);

                //Extra 3D
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[0].X, this.pointF_0[0].Y + 8);
                if (i == 0) this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y + 8, this.pointF_0[1].X, this.pointF_0[1].Y + 8);
                
                //Draw Top Lines
                this.pointF_0[0].X = X2 + (i * ((X4 - X2) / (ColumnsN2 - 1)));
                this.pointF_0[0].Y = Y2 + (i * ((Y4 - Y2) / (ColumnsN2 - 1)));
                this.pointF_0[1].X = X2 + (i * ((X4 - X2) / (ColumnsN2 - 1)));
                this.pointF_0[1].Y = Y2 + (i * ((Y4 - Y2) / (ColumnsN2 - 1))) - (Y4 - YMax) - 5;
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);

                if (i != 0)
                {
                    this.pointF_0[0].X = X4;
                    this.pointF_0[0].Y = YMax - 5;
                    this.pointF_0[1].X = X2;
                    this.pointF_0[1].Y = Y2 + ((0 * ((Y4 - Y2) / (ColumnsN2 - 1))) - (Y4 - YMax)) - 5;
                    this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);
                }
            }

            //Previous Maps rows
            /*for (int i = 0; i < this.int_2; i++)
            {
                this.pointF_0[0].X = this.class7_0[i, 0].method_8();
                this.pointF_0[0].Y = this.class7_0[i, 0].method_6();
                this.pointF_0[1].X = this.class7_0[i, this.class18_0.method_32() - 1].method_8();
                this.pointF_0[1].Y = this.class7_0[i, this.class18_0.method_32() - 1].method_6();
                //this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);

                float Divider = 1f;
                if (this.int_2 > 8) Divider = 2f;
                if (this.int_2 > 15) Divider = 3f;
                if (this.int_2 > 20) Divider = 4f;
                if ((((((float)i) % Divider) == 0f) || (i == (this.int_2 - 1))) && i != this.int_2 - 2)
                {
                    s = this.class18_0.method_163((byte)i).ToString();
                    if (i != 0)
                        this.graphics_0.DrawString(s, font, brush, this.pointF_0[0].X + 0f, this.pointF_0[0].Y + 6f, format);
                    this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);

                    //Extra 3D
                    this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[0].X, this.pointF_0[0].Y + 8);
                    if (i == 0) this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y + 8, this.pointF_0[1].X, this.pointF_0[1].Y + 8);
                }
            }*/
            brush.Dispose();
            brush = null;
            brush = new SolidBrush(this.class10_settings_0.color_11);

            /*if (this.class18_0.method_40())
            {
                this.pointF_0[0].X = this.class7_0[this.int_2 - 1, 0].method_8();
                this.pointF_0[0].Y = this.class7_0[this.int_2 - 1, 0].method_6();
                this.pointF_0[1].X = this.class7_0[this.int_2 - 1, this.class18_0.method_32() - 1].method_8();
                this.pointF_0[1].Y = this.class7_0[this.int_2 - 1, ((this.class18_0.method_32() / 4) * 3)].method_6();
            }
            else
                this.pointF_0[1].Y = this.class7_0[0, ((this.class18_0.method_32() / 4) * 3)].method_6();*/
            this.pointF_0[1].Y = this.class7_u_0[0, ((this.class18_0.method_32_GetRPM_RowsNumber() / 4) * 3)].method_6();
            s = "RPM";
            this.graphics_0.DrawString(s, font2, brush, ((base.ClientRectangle.Width / 4) * 3), this.pointF_0[1].Y + 17f);

            //###########################################
            X1 = this.class7_u_0[0, 0].method_8();
            X2 = this.class7_u_0[this.int_2 - 1, 0].method_8();
            X3 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();
            X4 = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_8();

            Y1 = this.class7_u_0[0, 0].method_6();
            Y2 = this.class7_u_0[this.int_2 - 1, 0].method_6();
            Y3 = this.class7_u_0[0, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();
            Y4 = this.class7_u_0[this.int_2 - 1, this.class18_0.method_32_GetRPM_RowsNumber() - 1].method_6();

            //Draw RPM Columns
            for (int i = 0; i < ColumnsN; i++)
            {
                this.pointF_0[0].X = X1 + (i * ((X3 - X1) / (ColumnsN - 1)));
                this.pointF_0[0].Y = Y1 + (i * ((Y3 - Y1) / (ColumnsN - 1)));

                this.pointF_0[1].X = X2 + (i * ((X4 - X2) / (ColumnsN - 1)));
                this.pointF_0[1].Y = Y2 + (i * ((Y4 - Y2) / (ColumnsN - 1)));

                //Draw Columns
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);

                //Draw Name
                if (i != 0)
                {
                    int irtt = (i * this.class18_0.method_32_GetRPM_RowsNumber()) / (ColumnsN - 1);
                    s = this.class18_0.method_159((byte)irtt).ToString();

                    this.graphics_0.DrawString(s, font, brush, this.pointF_0[0].X + 10, this.pointF_0[0].Y + 10, format);
                }

                //Extra 3D
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[0].X, this.pointF_0[0].Y + 8);
                if (i == 0) this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y + 8, this.pointF_0[1].X, this.pointF_0[1].Y + 8);

                //Draw Top lines
                this.pointF_0[0].X = X2 + (i * ((X4 - X2) / (ColumnsN - 1)));
                this.pointF_0[0].Y = Y2 + (i * ((Y4 - Y2) / (ColumnsN - 1)));
                this.pointF_0[1].X = X2 + (i * ((X4 - X2) / (ColumnsN - 1)));
                this.pointF_0[1].Y = YMax - 5;
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);
            }

            //Previous rpm columns
            /*for (int j = 0; j < this.class18_0.method_32(); j++)
            {
                if (this.class18_0.method_40())
                {
                    this.pointF_0[0].X = this.class7_0[this.int_2 - 1, j].method_8();
                    this.pointF_0[0].Y = this.class7_0[this.int_2 - 1, j].method_6();
                }
                else
                {
                    this.pointF_0[0].X = this.class7_0[0, j].method_8();
                    this.pointF_0[0].Y = this.class7_0[0, j].method_6();
                }
                this.pointF_0[1].X = this.class7_0[this.int_2 - 1, j].method_8();
                this.pointF_0[1].Y = this.class7_0[this.int_2 - 1, j].method_6();
                //this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);
                if (((j % 3) == 0) || (j == (this.class18_0.method_32() - 1)))
                {
                    s = this.class18_0.method_159((byte)j).ToString();
                    if (j != 0)
                        this.graphics_0.DrawString(s, font, brush, this.pointF_0[0].X + 10, this.pointF_0[0].Y + 10, format);

                    if (this.class18_0.method_40())
                    {
                        this.pointF_0[0].X = this.class7_0[0, j].method_8();
                        this.pointF_0[0].Y = this.class7_0[0, j].method_6();
                    }
                    this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);
                    
                    //Extra 3D
                    this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[0].X, this.pointF_0[0].Y + 8);
                    if (j == 0) this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y + 8, this.pointF_0[1].X, this.pointF_0[1].Y + 8);
                }
            }*/

            //Draw maps/igntion "values" bars
            for (int i2 = 1; i2 < ColumnsN; i2++)
            {
                this.pointF_0[0].X = X2;
                this.pointF_0[0].Y = Y2 + (i2 * ((YMax - 5 - Y2) / (ColumnsN - 1)));
                this.pointF_0[1].X = X4;
                this.pointF_0[1].Y = Y4 + (i2 * ((YMax - 5 - Y4) / (ColumnsN - 1)));
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);
                
                s = ((int) (i2 * (NMax / (ColumnsN - 1)))).ToString();
                this.graphics_0.DrawString(s, font, brush, this.pointF_0[0].X - 3, this.pointF_0[0].Y - 5, format);

                this.pointF_0[0].X = X4;
                this.pointF_0[0].Y = Y4 + (i2 * ((YMax - 5 - Y4) / (ColumnsN - 1)));
                this.pointF_0[1].X = X3;
                this.pointF_0[1].Y = Y3 + (i2 * ((YMax - 5 - Y4) / (ColumnsN - 1)));
                this.graphics_0.DrawLine(pen, this.pointF_0[0].X, this.pointF_0[0].Y, this.pointF_0[1].X, this.pointF_0[1].Y);
            }

            s = "Fuel Value";
            if (this.class18_0.method_40()) s = "Ignition";
            if (this.class18_0.method_38()) s = "VE%";
            this.graphics_0.DrawString(s, font2, brush, base.ClientRectangle.Left + 1, (base.ClientRectangle.Height / 4), format2);

            //Reinvert for igntion graph
            if (this.class18_0.method_40()) this.method_14(true);
            
            pen.Dispose();
            pen = null;
            brush.Dispose();
            brush = null;
            brush2.Dispose();
            brush2 = null;
            font.Dispose();
            font = null;
            font2.Dispose();
            font2 = null;
            format.Dispose();
            format = null;
            s = null;
        }
        catch { }
    }

    private void method_16()
    {
        try
        {
            SolidBrush brush = null;
            Pen pen = null;
            for (int i = this.int_2 - 1; i > 0; i--)
            {
                for (int j = this.class18_0.method_32_GetRPM_RowsNumber() - 1; j > 0; j--)
                {
                    this.pointF_0[0].X = this.class7_u_0[i, j].method_8();
                    this.pointF_0[0].Y = this.class7_u_0[i, j].method_10();
                    this.pointF_0[1].X = this.class7_u_0[i - 1, j].method_8();
                    this.pointF_0[1].Y = this.class7_u_0[i - 1, j].method_10();
                    this.pointF_0[2].X = this.class7_u_0[i - 1, j - 1].method_8();
                    this.pointF_0[2].Y = this.class7_u_0[i - 1, j - 1].method_10();
                    this.pointF_0[3].X = this.class7_u_0[i, j - 1].method_8();
                    this.pointF_0[3].Y = this.class7_u_0[i, j - 1].method_10();
                    if ((this.class7_u_0[i, j].bool_2 && this.class7_u_0[i - 1, j].bool_2) && (this.class7_u_0[i - 1, j - 1].bool_2 && this.class7_u_0[i, j - 1].bool_2))
                    {
                        brush = new SolidBrush(Color.FromArgb(0xff, 0x69, 180));
                        this.graphics_0.FillPolygon(brush, this.pointF_0);
                    }
                    else
                    {
                        this.float_9 = (((this.class7_u_0[i, j].method_12() + this.class7_u_0[i - 1, j].method_12()) + this.class7_u_0[i - 1, j - 1].method_12()) + this.class7_u_0[i, j - 1].method_12()) / 4f;
                        brush = new SolidBrush(this.method_9(this.float_9));
                        this.graphics_0.FillPolygon(brush, this.pointF_0);
                        if (brush != null)
                        {
                            brush.Dispose();
                            brush = null;
                        }
                    }
                    pen = new Pen(Color.Black, 0.5f);
                    this.graphics_0.DrawPolygon(pen, this.pointF_0);
                    if (brush != null)
                    {
                        brush.Dispose();
                        brush = null;
                    }
                    pen.Dispose();
                    pen = null;
                    brush = new SolidBrush(this.class10_settings_0.color_2);
                    pen = new Pen(this.class10_settings_0.color_2);
                    if (this.class7_u_0[i, j].bool_1)
                    {
                        this.graphics_0.FillRectangle(brush, (float)(this.class7_u_0[i, j].method_8() - 3f), (float)(this.class7_u_0[i, j].method_10() - 3f), (float)6f, (float)6f);
                        if (i > 0)
                        {
                            this.graphics_0.DrawLine(pen, this.class7_u_0[i, j].method_8(), this.class7_u_0[i, j].method_10(), this.class7_u_0[i - 1, j].method_8(), this.class7_u_0[i - 1, j].method_10());
                        }
                        if (j > 0)
                        {
                            this.graphics_0.DrawLine(pen, this.class7_u_0[i, j].method_8(), this.class7_u_0[i, j].method_10(), this.class7_u_0[i, j - 1].method_8(), this.class7_u_0[i, j - 1].method_10());
                        }
                        if (i < (this.int_2 - 1))
                        {
                            this.graphics_0.DrawLine(pen, this.class7_u_0[i, j].method_8(), this.class7_u_0[i, j].method_10(), this.class7_u_0[i + 1, j].method_8(), this.class7_u_0[i + 1, j].method_10());
                        }
                        if (j < (this.class18_0.method_32_GetRPM_RowsNumber() - 1))
                        {
                            this.graphics_0.DrawLine(pen, this.class7_u_0[i, j].method_8(), this.class7_u_0[i, j].method_10(), this.class7_u_0[i, j + 1].method_8(), this.class7_u_0[i, j + 1].method_10());
                        }
                    }
                }
            }
            if (brush != null)
            {
                brush.Dispose();
                brush = null;
            }
            pen.Dispose();
            pen = null;
        }
        catch { }
    }

    public void Reset_Struct_Sensor()
    {
        if (this.struct19_0 == null) this.struct19_0 = new Struct19[this.class10_settings_0.int_5];

        if (this.Struct12_list_0 != null)
        {
            while (this.Struct12_list_0.Count > this.class10_settings_0.int_5) this.Struct12_list_0.RemoveAt(0);

            this.int_6 = 0;

            for (int i = 0; i < this.Struct12_list_0.Count; i++)
            {
                if (this.mapGraphType_0 == MapGraphType.timePlot)
                    this.method_23(this.class10_settings_0.int_5, this.Struct12_list_0[i].byte_43, (float)this.class18_0.method_200(this.Struct12_list_0[i].byte_43), this.float_0, this.float_1);
                else if (this.mapGraphType_0 == MapGraphType.custom)
                    callfor23(this.Struct12_list_0[i]);
            }
        }
    }

    public void Next_Live_Plots()
    {
        if (this.struct19_0 != null)
        {
            for (int i = 1; i < this.class10_settings_0.int_5; i++)
            {
                //int_0 = X position, int_1 = Y position
                this.struct19_0[i - 1].int_0 = this.struct19_0[i - 1].int_0;
                this.struct19_0[i - 1].int_1 = this.struct19_0[i].int_1;
            }
        }

        if (this.Struct12_list_0 != null && this.Struct12_list_0.Count > 0) this.Struct12_list_0.RemoveAt(0);

        this.int_6--;
    }

    //Reset Live Plots Functions
    public void method_17()
    {
        this.int_6 = 0;
        if (this.struct19_0 != null)
        {
            for (int i = 0; i < this.class10_settings_0.int_5; i++)
            {
                this.struct19_0[i].int_0 = 0;
                this.struct19_0[i].int_1 = 0;
            }
        }
        if (this.Struct12_list_0 != null) this.Struct12_list_0.Clear();

        this.int_7 = null;
        this.struct19_2 = null;
        this.Refresh();
        GC.Collect();
    }

    public void method_18()
    {
        this.struct19_0 = null;
    }
    public void method_19(Struct12 struct12_0)
    {
        if (this.mapGraphType_0 == MapGraphType.timePlot || this.mapGraphType_0 == MapGraphType.custom)
        {
            if (this.struct19_0 == null)
            {
                this.struct19_0 = new Struct19[this.class10_settings_0.int_5];
                this.Struct12_list_0 = new List<Struct12>();
            }
            if (this.struct19_0.Length != this.class10_settings_0.int_5)
            {
                this.int_6 = 0;
                this.struct19_0 = new Struct19[this.class10_settings_0.int_5];
                this.Struct12_list_0 = new List<Struct12>();
            }
            if (this.int_6 == this.class10_settings_0.int_5)
            {
                this.Next_Live_Plots();
            }

            //Store full datalog array
            this.Struct12_list_0.Add(struct12_0);

            if (this.mapGraphType_0 == MapGraphType.timePlot)
                this.method_23(this.class10_settings_0.int_5, struct12_0.byte_43, (float)this.class18_0.method_200(struct12_0.byte_43), this.float_0, this.float_1);
            else
                callfor23(struct12_0);
        }
    }

    private void callfor23(Struct12 struct12_0)
    {
        custom_value_int = 17596;
        custom_value_float = -9.68779f;

        SensorsX sensors_0 = (SensorsX)this.Cint_Sensor;
        switch (sensors_0)
        {
            case SensorsX.rpmX:
                this.method_10(SensorsX.rpmX, struct12_0.ushort_0_E6_7);
                break;
            case SensorsX.ectX:
                this.method_9(SensorsX.ectX, struct12_0.byte_0);
                break;
            case SensorsX.iatX:
                this.method_9(SensorsX.iatX, struct12_0.byte_1);
                break;
            case SensorsX.tpsX:
                this.method_9(SensorsX.tpsX, struct12_0.byte_5);
                break;
            case SensorsX.tpsV:
                this.method_9(SensorsX.tpsV, struct12_0.byte_5);
                break;
            case SensorsX.ignFnl:
                this.method_9(SensorsX.ignFnl, struct12_0.byte_15_E19);
                break;
            case SensorsX.ignTbl:
                this.method_9(SensorsX.ignTbl, struct12_0.byte_16_E20);
                break;
            case SensorsX.vssX:
                this.method_9(SensorsX.vssX, struct12_0.byte_14_E16);
                break;
            case SensorsX.gearX:
                this.method_9(SensorsX.gearX, struct12_0.byte_20);
                break;
            case SensorsX.injFV:
                this.method_10(SensorsX.injFV, (long)struct12_0.ushort_1_E17_18);
                break;
            case SensorsX.injDur:
                this.method_10(SensorsX.injDur, (long)struct12_0.ushort_1_E17_18);
                break;
            case SensorsX.injDuty:
                this.method_10(SensorsX.injDuty, (long)struct12_0.ushort_1_E17_18);
                break;
            case SensorsX.ecuO2V:
                this.method_9(SensorsX.ecuO2V, struct12_0.byte_2);
                break;
            case SensorsX.wbO2V:
                this.method_9(SensorsX.wbO2V, struct12_0.byte_43);
                break;
            case SensorsX.afr:
                this.method_9(SensorsX.afr, struct12_0.byte_43);
                break;
            case SensorsX.mapV:
                this.method_9(SensorsX.mapV, struct12_0.byte_4);
                break;
            case SensorsX.mapX:
                this.method_9(SensorsX.mapX, struct12_0.byte_4);
                break;
            case SensorsX.boostX:
                this.method_9(SensorsX.boostX, struct12_0.byte_4);
                break;
            case SensorsX.paX:
                this.method_9(SensorsX.paX, struct12_0.byte_3);
                break;
            case SensorsX.frame:
                this.method_10(SensorsX.frame, struct12_0.long_5);
                break;
            case SensorsX.interval:
                this.method_10(SensorsX.interval, struct12_0.long_4);
                break;
            case SensorsX.duration:
                this.method_10(SensorsX.duration, struct12_0.long_3);
                break;
            case SensorsX.mil:
                this.method_9(SensorsX.mil, struct12_0.byte_19);
                break;
            case SensorsX.batV:
                this.method_9(SensorsX.batV, struct12_0.byte_27_E25);
                break;
            case SensorsX.eldV:
                this.method_9(SensorsX.eldV, struct12_0.byte_24_E24);
                break;
            case SensorsX.outAc:
                this.method_9(SensorsX.outAc, struct12_0.byte_22_E22);
                break;
            case SensorsX.outPurge:
                this.method_9(SensorsX.outPurge, struct12_0.byte_22_E22);
                break;
            case SensorsX.outFanc:
                this.method_9(SensorsX.outFanc, struct12_0.byte_22_E22);
                break;
            case SensorsX.outFpump:
                this.method_9(SensorsX.outFpump, struct12_0.byte_22_E22);
                break;
            case SensorsX.outIab:
                this.method_9(SensorsX.outIab, struct12_0.byte_22_E22);
                break;
            case SensorsX.outAltCtrl:
                this.method_9(SensorsX.outAltCtrl, struct12_0.byte_22_E22);
                break;
            case SensorsX.outVtsX:
                this.method_9(SensorsX.outVtsX, struct12_0.byte_23_E23);
                break;
            case SensorsX.outMil:
                this.method_9(SensorsX.outMil, struct12_0.byte_23_E23);
                break;
            case SensorsX.outO2h:
                this.method_9(SensorsX.outO2h, struct12_0.byte_23_E23);
                break;
            case SensorsX.outVtsM:
                this.method_9(SensorsX.outVtsM, struct12_0.byte_6_E8);
                break;
            case SensorsX.inVtsFeedBack:
                this.method_9(SensorsX.inVtsFeedBack, struct12_0.byte_21_E21);
                break;
            case SensorsX.outFuelCut:
                this.method_9(SensorsX.outFuelCut, struct12_0.byte_6_E8);
                break;
            case SensorsX.inAccs:
                this.method_9(SensorsX.inAccs, struct12_0.byte_21_E21);
                break;
            case SensorsX.inVtp:
                this.method_9(SensorsX.inVtp, struct12_0.byte_21_E21);
                break;
            case SensorsX.inStartS:
                this.method_9(SensorsX.inStartS, struct12_0.byte_21_E21);
                break;
            case SensorsX.inBksw:
                this.method_9(SensorsX.inBksw, struct12_0.byte_21_E21);
                break;
            case SensorsX.inParkN:
                this.method_9(SensorsX.inParkN, struct12_0.byte_21_E21);
                break;
            case SensorsX.inAtShift1:
                this.method_9(SensorsX.inAtShift1, struct12_0.byte_6_E8);
                break;
            case SensorsX.inAtShift2:
                this.method_9(SensorsX.inAtShift2, struct12_0.byte_6_E8);
                break;
            case SensorsX.inPsp:
                this.method_9(SensorsX.inPsp, struct12_0.byte_21_E21);
                break;
            case SensorsX.inSCC:
                this.method_9(SensorsX.inSCC, struct12_0.byte_21_E21);
                break;
            case SensorsX.postFuel:
                this.method_9(SensorsX.postFuel, struct12_0.byte_6_E8);
                break;
            case SensorsX.ectFc:
                this.method_9(SensorsX.ectFc, struct12_0.byte_28_E26);
                break;
            case SensorsX.o2Short:
                this.method_10(SensorsX.o2Short, struct12_0.long_0_E27_28);
                break;
            case SensorsX.o2Long:
                this.method_10(SensorsX.o2Long, struct12_0.long_1_E29_30);
                break;
            case SensorsX.iatFc:
                this.method_10(SensorsX.iatFc, struct12_0.long_2_E31_32);
                break;
            case SensorsX.veFc:
                this.method_9(SensorsX.veFc, struct12_0.byte_29_E33);
                break;
            case SensorsX.iatIc:
                this.method_9(SensorsX.iatIc, struct12_0.byte_30_E34);
                break;
            case SensorsX.ectIc:
                this.method_9(SensorsX.ectIc, struct12_0.byte_31_E35);
                break;
            case SensorsX.gearIc:
                this.method_9(SensorsX.gearIc, struct12_0.byte_32_E36);
                break;
            case SensorsX.gearFc:
                this.method_9(SensorsX.gearFc, struct12_0.byte_33_E37);
                break;
            case SensorsX.ftsClutchInput:
                this.method_9(SensorsX.ftsClutchInput, struct12_0.byte_34_E38);
                break;
            case SensorsX.ftlInput:
                this.method_9(SensorsX.ftlInput, struct12_0.byte_34_E38);
                break;
            case SensorsX.gpo1_in:
                this.method_9(SensorsX.gpo1_in, struct12_0.byte_34_E38);
                break;
            case SensorsX.gpo2_in:
                this.method_9(SensorsX.gpo2_in, struct12_0.byte_34_E38);
                break;
            case SensorsX.gpo3_in:
                this.method_9(SensorsX.gpo3_in, struct12_0.byte_34_E38);
                break;
            case SensorsX.bstInput:
                this.method_9(SensorsX.bstInput, struct12_0.byte_34_E38);
                break;
            case SensorsX.ftlActive:
                this.method_9(SensorsX.ftlActive, struct12_0.byte_35_E39);
                break;
            case SensorsX.ftsActive:
                this.method_9(SensorsX.ftsActive, struct12_0.byte_35_E39);
                break;
            case SensorsX.antilagActive:
                this.method_9(SensorsX.antilagActive, struct12_0.byte_35_E39);
                break;
            case SensorsX.boostcutActive:
                this.method_9(SensorsX.boostcutActive, struct12_0.byte_35_E39);
                break;
            case SensorsX.ignitionCut:
                this.method_9(SensorsX.ignitionCut, struct12_0.byte_6_E8);
                break;
            case SensorsX.sccChecker:
                this.method_9(SensorsX.sccChecker, struct12_0.byte_6_E8);
                break;
            case SensorsX.gpo1_out:
                this.method_9(SensorsX.gpo1_out, struct12_0.byte_36_E43);
                break;
            case SensorsX.gpo2_out:
                this.method_9(SensorsX.gpo2_out, struct12_0.byte_36_E43);
                break;
            case SensorsX.gpo3_out:
                this.method_9(SensorsX.gpo3_out, struct12_0.byte_36_E43);
                break;
            case SensorsX.bstStage2:
                this.method_9(SensorsX.bstStage2, struct12_0.byte_36_E43);
                break;
            case SensorsX.bstStage3:
                this.method_9(SensorsX.bstStage3, struct12_0.byte_36_E43);
                break;
            case SensorsX.bstStage4:
                this.method_9(SensorsX.bstStage4, struct12_0.byte_36_E43);
                break;
            case SensorsX.overheatActive:
                this.method_9(SensorsX.overheatActive, struct12_0.byte_36_E43);
                break;
            case SensorsX.leanProtection:
                this.method_9(SensorsX.leanProtection, struct12_0.byte_36_E43);
                break;
            case SensorsX.fanCtrl:
                this.method_9(SensorsX.fanCtrl, struct12_0.byte_35_E39);
                break;
            case SensorsX.bstActive:
                this.method_9(SensorsX.bstActive, struct12_0.byte_35_E39);
                break;
            case SensorsX.secMaps:
                this.method_9(SensorsX.secMaps, struct12_0.byte_35_E39);
                break;
            case SensorsX.ebcActive:
                this.method_9(SensorsX.ebcActive, struct12_0.byte_35_E39);
                break;
            case SensorsX.ebcInput:
                this.method_9(SensorsX.ebcInput, struct12_0.byte_34_E38);
                break;
            case SensorsX.ebcHiInput:
                this.method_9(SensorsX.ebcHiInput, struct12_0.byte_34_E38);
                break;
            case SensorsX.ebcDutyX:
                this.method_9(SensorsX.ebcDutyX, struct12_0.byte_38_E41);
                break;
            case SensorsX.ebcBaseDuty:
                this.method_9(SensorsX.ebcBaseDuty, struct12_0.byte_37_E40);
                break;
            case SensorsX.ebcCurrent:
                this.method_9(SensorsX.ebcCurrent, struct12_0.byte_4);
                break;
            case SensorsX.ebcTarget:
                this.method_9(SensorsX.ebcTarget, struct12_0.byte_39_E42);
                break;
            case SensorsX.analog1:
                this.method_9(SensorsX.analog1, struct12_0.byte_40);
                break;
            case SensorsX.analog2:
                this.method_9(SensorsX.analog2, struct12_0.byte_41);
                break;
            case SensorsX.analog3:
                this.method_9(SensorsX.analog3, struct12_0.byte_42);
                break;
        }

        if (custom_value_int != 17596) //this.class10_0.int_5 ... byte_43 ..... 
            this.method_23_int(custom_value_int, int.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMin")), int.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMax")));

        if (custom_value_float != -9.68779f)
            this.method_23_float(custom_value_float, float.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMin")), float.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMax")));


    }



    private void method_9(SensorsX sensors_0, byte byte_0)
    {
        switch (sensors_0)
        {
            case SensorsX.rpmX:
            case SensorsX.injDur:
            case SensorsX.injDuty:
            case SensorsX.injFV:
            case SensorsX.frame:
            case SensorsX.duration:
            case SensorsX.interval:
            case SensorsX.iatFc:
            case SensorsX.o2Short:
            case SensorsX.o2Long:
            case SensorsX.loadType:
            case SensorsX.test0:
            case SensorsX.analog1:
            case SensorsX.analog2:
            case SensorsX.analog3:
            case SensorsX.iacvDuty:
                return;

            case SensorsX.vssX:
                custom_value_int = this.class18_0.method_197(byte_0);
                return;

            case SensorsX.gearX:
                custom_value_int = byte_0;
                return;

            case SensorsX.mapX:
                custom_value_float = this.class18_0.method_193(byte_0);
                return;

            case SensorsX.boostX:
                if (this.class18_0.method_206(byte_0) <= this.class10_settings_0.int_6)
                {
                    custom_value_float = 0;
                    return;
                }
                custom_value_float = this.class18_0.method_193(byte_0);
                return;

            case SensorsX.paX:
                custom_value_int = ((int)Math.Round((double)((((byte_0 / 2) + 0x18) * 7.221) - 59.0), 0));
                return;

            case SensorsX.tpsX:
                custom_value_int = this.class18_0.method_198(byte_0);
                return;

            case SensorsX.tpsV:
                custom_value_float = (float) this.class18_0.method_196(byte_0);
                return;

            case SensorsX.ignFnl:
                custom_value_float = this.class18_0.method_188(byte_0);
                return;

            case SensorsX.ignTbl:
                custom_value_float = this.class18_0.method_188(byte_0);
                return;

            case SensorsX.ectX:
                custom_value_float = (float) this.class18_0.method_191(byte_0);
                return;

            case SensorsX.iatX:
                custom_value_float = (float) this.class18_0.method_191(byte_0);
                return;

            case SensorsX.afr:
                custom_value_float = (float)this.class18_0.method_200(byte_0);
                return;

            case SensorsX.ecuO2V:
                custom_value_float = (float)this.class18_0.method_196(byte_0);
                return;

            case SensorsX.wbO2V:
                custom_value_float = (float)this.class18_0.method_196(byte_0);
                return;

            case SensorsX.batV:
                custom_value_float = (float)this.class18_0.method_208(byte_0);
                return;

            case SensorsX.eldV:
                custom_value_float = (float)this.class18_0.method_196(byte_0);
                return;

            case SensorsX.knockV:
                custom_value_float = (float)this.class18_0.method_196(byte_0);
                return;

            case SensorsX.mapV:
                custom_value_float = (float)this.class18_0.method_196(byte_0);
                return;

            case SensorsX.mil:
                custom_value_int = byte_0;
                return;

            case SensorsX.ectFc:
                custom_value_float = (float)this.class18_0.method_205(byte_0, Enum6.const_1);
                return;

            case SensorsX.veFc:
                custom_value_float = (float)this.class18_0.method_205(byte_0, Enum6.const_1);
                return;

            case SensorsX.ectIc:
                custom_value_float = this.class18_0.method_189(byte_0);
                return;

            case SensorsX.iatIc:
                custom_value_float = this.class18_0.method_189(byte_0);
                return;

            case SensorsX.gearIc:
                custom_value_float = this.class18_0.method_189(byte_0);
                return;

            case SensorsX.gearFc:
                custom_value_float = (float)this.class18_0.method_205(byte_0, Enum6.const_1);
                return;

            case SensorsX.postFuel:
                if (this.class18_0.method_258(byte_0, 0)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outIab:
                if (this.class18_0.method_258(byte_0, 2)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outVtsX:
                if (this.class18_0.method_258(byte_0, 7)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outVtsM:
                if (this.class18_0.method_258(byte_0, 3)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outAc:
                if (this.class18_0.method_258(byte_0, 7)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outO2h:
                if (this.class18_0.method_258(byte_0, 6)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outMil:
                if (this.class18_0.method_258(byte_0, 5)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outPurge:
                if (this.class18_0.method_258(byte_0, 6)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outFanc:
                if (this.class18_0.method_258(byte_0, 4)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outFpump:
                if (this.class18_0.method_258(byte_0, 0)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outFuelCut:
                if (this.class18_0.method_258(byte_0, 4) || this.class18_0.method_258(byte_0, 5)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.outAltCtrl:
                if (this.class18_0.method_258(byte_0, 5)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inPsp:
                if (this.class18_0.method_258(byte_0, 7)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inSCC:
                if (this.class18_0.method_258(byte_0, 5)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inAccs:
                if (this.class18_0.method_258(byte_0, 2)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inBksw:
                if (this.class18_0.method_258(byte_0, 1)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inVtp:
                if (this.class18_0.method_258(byte_0, 3)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inVtsFeedBack:
                if (this.class18_0.method_258(byte_0, 6)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inParkN:
                if (this.class18_0.method_258(byte_0, 0)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inStartS:
                if (this.class18_0.method_258(byte_0, 4)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inAtShift1:
                if (this.class18_0.method_258(byte_0, 6)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.inAtShift2:
                if (this.class18_0.method_258(byte_0, 7)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.secMaps:
                if (this.class18_0.method_258(byte_0, 5)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ftlInput:
                if (this.class18_0.method_258(byte_0, 0)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ftlActive:
                if (this.class18_0.method_258(byte_0, 0)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ftsClutchInput:
                if (this.class18_0.method_258(byte_0, 1)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ftsActive:
                if (this.class18_0.method_258(byte_0, 2)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.boostcutActive:
                if (this.class18_0.method_258(byte_0, 3)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.overheatActive:
                if (this.class18_0.method_258(byte_0, 6)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.antilagActive:
                if (this.class18_0.method_258(byte_0, 1)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ignitionCut:
                if (this.class18_0.method_258(byte_0, 2)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.sccChecker:
                if (this.class18_0.method_258(byte_0, 1)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ebcInput:
                if (this.class18_0.method_258(byte_0, 2)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ebcHiInput:
                if (this.class18_0.method_258(byte_0, 3)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ebcActive:
                if (this.class18_0.method_258(byte_0, 4)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.ebcBaseDuty:
                custom_value_float = (float)this.class18_0.method_207(byte_0);
                return;

            case SensorsX.ebcDutyX:
                custom_value_float = (float)this.class18_0.method_207(byte_0);
                return;

            case SensorsX.ebcTarget:
                custom_value_float = this.class18_0.method_245(this.class18_0.method_206(byte_0));
                return;

            case SensorsX.ebcCurrent:
                custom_value_float = this.class18_0.method_245(this.class18_0.method_206(byte_0));
                return;

            case SensorsX.gpo1_in:
                if (this.class18_0.method_258(byte_0, 4)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.gpo1_out:
                if (this.class18_0.method_258(byte_0, 0)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.gpo2_in:
                if (this.class18_0.method_258(byte_0, 5)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.gpo2_out:
                if (this.class18_0.method_258(byte_0, 1)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.gpo3_in:
                if (this.class18_0.method_258(byte_0, 6)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.gpo3_out:
                if (this.class18_0.method_258(byte_0, 2)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.fanCtrl:
                if (this.class18_0.method_258(byte_0, 6)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.bstStage2:
                if (this.class18_0.method_258(byte_0, 3)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.bstStage3:
                if (this.class18_0.method_258(byte_0, 4)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.bstStage4:
                if (this.class18_0.method_258(byte_0, 5)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.bstActive:
                if (this.class18_0.method_258(byte_0, 7)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.bstInput:
                if (this.class18_0.method_258(byte_0, 7)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            case SensorsX.leanProtection:
                if (this.class18_0.method_258(byte_0, 7)) custom_value_int = 1;
                else custom_value_int = 0;
                return;

            default:
                return;
        }
    }

    private void method_10(SensorsX sensors_0, long long_0)
    {
        string str;
        switch (sensors_0)
        {
            case SensorsX.rpmX:
                custom_value_int = this.class18_0.method_218(long_0);
                return;

            case SensorsX.vssX:
            case SensorsX.gearX:
            case SensorsX.mapX:
            case SensorsX.boostX:
            case SensorsX.paX:
            case SensorsX.tpsX:
            case SensorsX.tpsV:
            case SensorsX.ignFnl:
            case SensorsX.ignTbl:
            case SensorsX.ectX:
            case SensorsX.iatX:
            case SensorsX.afr:
            case SensorsX.ecuO2V:
            case SensorsX.wbO2V:
            case SensorsX.batV:
            case SensorsX.eldV:
            case SensorsX.knockV:
            case SensorsX.mapV:
            case SensorsX.mil:
            case SensorsX.ectFc:
            case SensorsX.veFc:
            case SensorsX.ectIc:
            case SensorsX.iatIc:
            case SensorsX.gearIc:
            case SensorsX.gearFc:
            case SensorsX.postFuel:
            case SensorsX.outIab:
            case SensorsX.outVtsX:
            case SensorsX.outVtsM:
            case SensorsX.outAc:
            case SensorsX.outO2h:
            case SensorsX.outMil:
            case SensorsX.outPurge:
            case SensorsX.outFanc:
            case SensorsX.outFpump:
            case SensorsX.outFuelCut:
            case SensorsX.outAltCtrl:
            case SensorsX.inPsp:
            case SensorsX.inSCC:
            case SensorsX.inAccs:
            case SensorsX.inBksw:
            case SensorsX.inVtp:
            case SensorsX.inVtsFeedBack:
            case SensorsX.inParkN:
                return;

            case SensorsX.injDur:
                custom_value_float = (float) this.class18_0.method_224((int)long_0);
                return;

            case SensorsX.injDuty:
                custom_value_float = (float) this.class18_0.method_225((int)long_0, this.int_0, 0);
                return;

            case SensorsX.injFV:
                custom_value_float = (float) this.class18_0.method_223((int)long_0);
                return;

            case SensorsX.frame:
                custom_value_int = (int) long_0;
                return;

            case SensorsX.duration:
                str = TimeSpan.FromMilliseconds((double)long_0).ToString();
                if (str.Length <= 8)
                {
                    str = str + ".000";
                    custom_value_float = float.Parse(str);
                    break;
                }
                str = str.Remove(str.Length - 5, 5);
                custom_value_float = float.Parse(str);
                break;

            case SensorsX.interval:
                custom_value_int = (int) long_0;
                return;

            case SensorsX.iatFc:
                custom_value_float = (float) this.class18_0.method_203(long_0, Enum6.const_0);
                return;

            case SensorsX.o2Short:
                custom_value_float = (float)this.class18_0.method_203(long_0, Enum6.const_0);
                return;

            case SensorsX.o2Long:
                custom_value_float = (float) this.class18_0.method_203(long_0, Enum6.const_0);
                return;

            default:
                return;
        }
    }

    private void method_2(object sender, EventArgs e)
    {
        try
        {
            if (this.class7_u_0 != null)
            {
                this.class7_u_1.Clear();
                for (int i = 0; i < this.int_2; i++)
                {
                    for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                    {
                        if ((this.class7_u_0[i, j] != null) && this.ctrlGrid_0.method_13(i, j))
                        {
                            this.class7_u_1.Add(this.class7_u_0[i, j]);
                        }
                    }
                }
            }
        }
        catch { }
    }

    public void method_20(Struct17 struct17_0)
    {
        if ((this.mapGraphType_0 == MapGraphType.rpmPlot) && (this.class18_0.method_198(struct17_0.byte_1) >= this.class10_settings_0.int_4))
        {
            if (this.int_7 == null)
            {
                this.int_7 = new int[0x2ee0 / this.class10_settings_0.int_3, 3];
            }
            if (this.struct19_2 == null)
            {
                this.struct19_2 = new Struct19[0x2ee0 / this.class10_settings_0.int_3, 2];
            }
            int num = this.class18_0.method_218(struct17_0.long_1) / this.class10_settings_0.int_3;
            this.int_7[num, 0] += struct17_0.byte_0;
            this.int_7[num, 1] += struct17_0.byte_2;
            this.int_7[num, 2]++;
        }
    }

    private int method_21()
    {
        return (base.ClientRectangle.Height - (2 * this.int_4));
    }

    private int method_22()
    {
        return ((base.ClientRectangle.Width - this.int_5) - this.int_3);
    }

    private void method_23(int int_18, byte byte_0, float float_28, float float_29, float float_30)
    {
        int num = ((base.ClientRectangle.Top + this.int_4) + this.method_21()) - ((int) ((this.method_21() * (float_28 - float_29)) / (float_30 - float_29)));
        if (num < (base.ClientRectangle.Top + this.int_4))
        {
            num = base.ClientRectangle.Top + this.int_4;
        }
        this.struct19_0[this.int_6].int_0 = this.int_5 + ((int) Math.Abs((float) (this.method_22() * (((float) this.int_6) / ((float) int_18)))));
        this.struct19_0[this.int_6].int_1 = num;
        this.struct19_0[this.int_6].int_2 = this.int_6;
        this.struct19_0[this.int_6].byte_0 = byte_0;
        this.int_6++;
    }

    private void method_23_int(int Valuee, int Minn, int Maxx)
    {
        int num = ((base.ClientRectangle.Top + this.int_4) + this.method_21()) - ((int)((this.method_21() * (Valuee - Minn)) / (Maxx - Minn)));
        if (num < (base.ClientRectangle.Top + this.int_4))
        {
            num = base.ClientRectangle.Top + this.int_4;
        }
        this.struct19_0[this.int_6].int_0 = this.int_5 + ((int)Math.Abs((float)(this.method_22() * (((float)this.int_6) / ((float) this.class10_settings_0.int_5)))));
        this.struct19_0[this.int_6].int_1 = num;
        this.struct19_0[this.int_6].int_2 = this.int_6;
        //this.struct19_0[this.int_6].byte_0 = 175;
        this.int_6++;
    }

    private void method_23_float(float Valuee, float Minn, float Maxx)
    {
        int num = ((base.ClientRectangle.Top + this.int_4) + this.method_21()) - ((int)((this.method_21() * (Valuee - Minn)) / (Maxx - Minn)));
        if (num < (base.ClientRectangle.Top + this.int_4))
        {
            num = base.ClientRectangle.Top + this.int_4;
        }
        this.struct19_0[this.int_6].int_0 = this.int_5 + ((int)Math.Abs((float)(this.method_22() * (((float)this.int_6) / ((float)this.class10_settings_0.int_5)))));
        this.struct19_0[this.int_6].int_1 = num;
        this.struct19_0[this.int_6].int_2 = this.int_6;
        //this.struct19_0[this.int_6].byte_0 = byte_0;
        this.int_6++;
    }

    private Struct19 method_25(int int_16, int int_17, float float_28, float float_29, float float_30)
    {
        Struct19 struct2 = new Struct19();
        int num = ((base.ClientRectangle.Top + this.int_4) + this.method_21()) - ((int) ((this.method_21() * (float_28 - float_29)) / (float_30 - float_29)));
        if (num < (base.ClientRectangle.Top + this.int_4))
        {
            num = base.ClientRectangle.Top + this.int_4;
        }
        struct2.int_0 = this.int_5 + ((int) Math.Abs((float) (this.method_22() * (((float) int_16) / ((float) int_17)))));
        struct2.int_1 = num;
        return struct2;
    }

    private void method_26()
    {
        string str;
        Pen pen = new Pen(this.class10_settings_0.color_11);
        Font font = new Font("Lucida Sans", 10f, FontStyle.Regular);
        Font font2 = new Font("Lucida Sans", 12f, FontStyle.Bold);
        Brush brush = new SolidBrush(this.class10_settings_0.color_11);
        //StringFormat format = new StringFormat {
        //    FormatFlags = StringFormatFlags.DirectionVertical
        //};
        int OffsetLeft = 15;
        int OffsetTop = 10;
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Top + this.int_4 + OffsetTop, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4);
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4, base.ClientRectangle.Width - this.int_3, base.ClientRectangle.Bottom - this.int_4);
        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_settings_0.color_12);
        pen.DashStyle = DashStyle.Dash;
        pen.DashPattern = new float[] { 10f, 4f };
        float num = 0f;
        float num2 = this.int_5 - OffsetLeft;
        float num3 = base.ClientRectangle.Width - this.int_3;
        float num4 = (base.ClientRectangle.Height - this.int_4) - this.int_4;
        for (int i = 0; i <= 14; i++)
        {
            num = (this.int_4 + (num4 - OffsetTop)) - ((i * (num4 - OffsetTop)) / 14f);
            this.graphics_0.DrawLine(pen, num2, num + OffsetTop, num3, num + OffsetTop);
            str = Math.Round((double) (((this.float_1 - this.float_0) * (((float) i) / 14f)) + this.float_0), 2).ToString();
            this.graphics_0.DrawString(str, font, brush, (float) (num2 - this.graphics_0.MeasureString(str, font).Width - 2f), (float) (num - (this.graphics_0.MeasureString(str, font).Height / 2f) + OffsetTop));
        }
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
            str = "AFR";
        else
            str = "Lambda";
        //this.graphics_0.DrawString(str, font2, brush, (float) (base.ClientRectangle.Left + 3), (float) ((base.ClientRectangle.Height / 2) - 40), format);
        this.graphics_0.DrawString(str, font2, brush, (float)((base.ClientRectangle.Width / 2) - 10 - (this.graphics_0.MeasureString(str, font).Width / 2)), (float)(base.ClientRectangle.Top + 5));
        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_settings_0.color_11);
        str = "Time (frames)";
        this.graphics_0.DrawString(str, font2, brush, (float) ((base.ClientRectangle.Width / 2) - 10 - (this.graphics_0.MeasureString(str, font).Width / 2)), (float) (base.ClientRectangle.Bottom - 20));
        pen.Dispose();
        pen = null;
        brush.Dispose();
        brush = null;
        font.Dispose();
        font = null;
        font2.Dispose();
        font2 = null;
        //format.Dispose();
        //format = null;
        str = null;
    }

    private void method_27()
    {
        int OffsetLeft = 15;
        int OffsetTop = 10;
        Pen pen = new Pen(this.class10_settings_0.color_12, 2f);
        for (int i = 0; i < (this.int_6 - 1); i++)
        {
            this.graphics_0.DrawLine(pen, this.struct19_0[i].int_0 - OffsetLeft, this.struct19_0[i].int_1 + OffsetTop, this.struct19_0[i + 1].int_0 - OffsetLeft, this.struct19_0[i + 1].int_1 + OffsetTop);
        }
        pen.Dispose();
        pen = null;
    }

    private void method_26_2()
    {
        string str;
        Pen pen = new Pen(this.class10_settings_0.color_11);
        Font font = new Font("Lucida Sans", 10f, FontStyle.Regular);
        Font font2 = new Font("Lucida Sans", 12f, FontStyle.Bold);
        Brush brush = new SolidBrush(this.class10_settings_0.color_11);
        /*StringFormat format = new StringFormat
        {
            FormatFlags = StringFormatFlags.DirectionVertical
        };*/
        int OffsetLeft = 24;
        int OffsetTop = 10;
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Top + this.int_4 + OffsetTop, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4);
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4, base.ClientRectangle.Width - this.int_3, base.ClientRectangle.Bottom - this.int_4);
        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_settings_0.color_12);
        pen.DashStyle = DashStyle.Dash;
        pen.DashPattern = new float[] { 10f, 4f };
        float num = 0f;
        float num2 = this.int_5 - OffsetLeft;
        float num3 = base.ClientRectangle.Width - this.int_3;
        float num4 = (base.ClientRectangle.Height - this.int_4) - this.int_4;
        
        if (this.Cint_Sensor >= 0)
        {
            for (int i = 0; i <= Cint_Colomn; i++)
            {
                num = (this.int_4 + (num4 - OffsetTop)) - ((i * (num4 - OffsetTop)) / Cint_Colomn);
                this.graphics_0.DrawLine(pen, num2, num + OffsetTop, num3, num + OffsetTop);
                //Console.WriteLine(this.class10_0.method_24((Sensors)this.Cint_Sensor, "customINT"));
                bool IsINT = bool.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customINT"));
                if (!IsINT)
                {
                    this.float_0 = float.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMin"));
                    this.float_1 = float.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMax"));
                    str = Math.Round((double)(((this.float_1 - this.float_0) * (((float)i) / Cint_Colomn)) + this.float_0), 2).ToString();
                }
                else
                {
                    int ThatI1 = int.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMin"));
                    int ThatI2 = int.Parse(this.class10_settings_0.method_24((SensorsX)this.Cint_Sensor, "customMax"));
                    str = ((int)(((ThatI2 - ThatI1) * (((float)i) / Cint_Colomn)) + ThatI1)).ToString();
                }
                this.graphics_0.DrawString(str, font, brush, (float)(num2 - this.graphics_0.MeasureString(str, font).Width - 2f), (float)(num - (this.graphics_0.MeasureString(str, font).Height / 2f) + OffsetTop));
            }
            str = this.class10_settings_0.method_13((SensorsX)Cint_Sensor).ToString();
        }
        else
        {
            for (int i = 0; i <= Cint_Colomn; i++)
            {
                num = (this.int_4 + (num4 - OffsetTop)) - ((i * (num4 - OffsetTop)) / Cint_Colomn);
                this.graphics_0.DrawLine(pen, num2 - OffsetLeft, num + OffsetTop, num3, num + OffsetTop);
            }
            str = "INVALID SENSOR";
        }
        
        //this.graphics_0.DrawString(str, font2, brush, (float)(base.ClientRectangle.Left + 3), (float)((base.ClientRectangle.Height / 2) - 40), format);
        this.graphics_0.DrawString(str, font2, brush, (float)((base.ClientRectangle.Width / 2) - 10 - (this.graphics_0.MeasureString(str, font).Width / 2)), (float)(base.ClientRectangle.Top + 15));

        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_settings_0.color_11);
        str = "Time (frames)";
        this.graphics_0.DrawString(str, font2, brush, (float)((base.ClientRectangle.Width / 2) - 55), (float)(base.ClientRectangle.Bottom - 25));

        
        pen.Dispose();
        pen = null;
        brush.Dispose();
        brush = null;
        font.Dispose();
        font = null;
        font2.Dispose();
        font2 = null;
        //format.Dispose();
        //format = null;
        str = null;
    }

    private void method_27_2()
    {
        int OffsetLeft = 24;
        int OffsetTop = 10;
        Pen pen = new Pen(this.class10_settings_0.color_12, 2f);
        for (int i = 0; i < (this.int_6 - 1); i++)
        {
            this.graphics_0.DrawLine(pen, this.struct19_0[i].int_0 - OffsetLeft, this.struct19_0[i].int_1 + OffsetTop, this.struct19_0[i + 1].int_0 - OffsetLeft, this.struct19_0[i + 1].int_1 + OffsetTop);
        }
        pen.Dispose();
        pen = null;
    }

    private void method_28()
    {
        string str;
        Pen pen = new Pen(this.class10_settings_0.color_11);
        Font font = new Font("Lucida Sans", 8f, FontStyle.Bold);
        Font font2 = new Font("Lucida Sans", 10f, FontStyle.Bold);
        Brush brush = new SolidBrush(this.class10_settings_0.color_13);
        StringFormat format = new StringFormat {
            FormatFlags = StringFormatFlags.DirectionVertical
        };
        this.graphics_0.DrawLine(pen, this.int_5 + 5, base.ClientRectangle.Top + this.int_4, this.int_5 + 5, base.ClientRectangle.Bottom - this.int_4);
        this.graphics_0.DrawLine(pen, this.int_5 + 5, base.ClientRectangle.Bottom - this.int_4, base.ClientRectangle.Width - this.int_3, base.ClientRectangle.Bottom - this.int_4);
        pen.DashStyle = DashStyle.Dash;
        pen.DashPattern = new float[] { 10f, 4f };
        float num = 0f;
        float num2 = this.int_5;
        float num3 = base.ClientRectangle.Width - this.int_3;
        float num4 = (base.ClientRectangle.Height - this.int_4) - this.int_4;
        for (int i = 0; i <= 14; i++)
        {
            num = (this.int_4 + num4) - ((i * num4) / 14f);
            this.graphics_0.DrawLine(pen, num2 + 5, num, num3, num);
            str = Math.Round((double) (((this.float_1 - this.float_0) * (((float) i) / 14f)) + this.float_0), 2).ToString();
            this.graphics_0.DrawString(str, font, brush, (float) (num2 - this.graphics_0.MeasureString(str, font).Width), (float) (num - (this.graphics_0.MeasureString(str, font).Height / 2f)));
        }
        str = "AFR";
        this.graphics_0.DrawString(str, font2, brush, (float) (base.ClientRectangle.Left + 45), (float) (base.ClientRectangle.Top + 4));



        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_settings_0.color_12);
        for (int j = 0; j <= 14; j++)
        {
            num = (this.int_4 + num4) - ((j * num4) / 14f);
            this.graphics_0.DrawLine(pen, num2 + 5, num, num3, num);
            str = Math.Round((double) this.class18_0.method_193((int) (255f * (((float) j) / 14f))), 2).ToString();
            this.graphics_0.DrawString(str, font, brush, (float) ((num2 - this.graphics_0.MeasureString(str, font).Width) - (this.int_5 - 40)), (float) (num - (this.graphics_0.MeasureString(str, font).Height / 2f)));
        }
        str = "MAP";
        this.graphics_0.DrawString(str, font2, brush, (float) (base.ClientRectangle.Left + 2), (float) (base.ClientRectangle.Top + 4));



        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_settings_0.color_11);
        str = "RPM X 1000";
        this.graphics_0.DrawString(str, font2, brush, (float) ((base.ClientRectangle.Width / 2) - 40), (float) (base.ClientRectangle.Bottom - 20));
        float num7 = 0f;
        float num8 = 0f;
        for (float k = 0f; k <= (this.float_4 / this.float_2); k++)
        {
            num7 = this.int_5 + ((k * this.method_22()) / (this.float_4 / this.float_2));
            string s = (num8 / 1000f).ToString();
            this.graphics_0.DrawString(s, font, brush, num7 - (this.graphics_0.MeasureString(s, font).Width / 2f) + 5f, (float) (base.ClientRectangle.Bottom - 30));
            num8 += this.float_2;
        }


        pen.Dispose();
        pen = null;
        brush.Dispose();
        brush = null;
        font.Dispose();
        font = null;
        font2.Dispose();
        font2 = null;
        format.Dispose();
        format = null;
        str = null;
    }

    private void method_29()
    {
        if (this.class10_settings_0 != null)
        {
            int num2 = 0;
            Pen pen = new Pen(this.class10_settings_0.color_13, 2f);
            if (this.int_7 != null)
            {
                int num;
                for (int i = 0; i <= this.int_7.GetUpperBound(0); i++)
                {
                    if (this.int_7[i, 0] != 0)
                    {
                        byte num4 = (byte) (this.int_7[i, 0] / this.int_7[i, 2]);
                        byte num5 = (byte) (this.int_7[i, 1] / this.int_7[i, 2]);
                        //*(this.struct19_2[i, 0]) = this.method_25(i * this.class10_0.int_3, 0x2af8, (float) this.class18_0.method_200(num4), this.float_0, this.float_1);
                        //*(this.struct19_2[i, 1]) = this.method_25(i * this.class10_0.int_3, 0x2af8, (float) this.class18_0.method_206(num5), 0f, (float) this.class18_0.method_206(0xff));
                        (this.struct19_2[i, 0]) = this.method_25(i * this.class10_settings_0.int_3, 0x2af8, (float)this.class18_0.method_200(num4), this.float_0, this.float_1);
                        (this.struct19_2[i, 1]) = this.method_25(i * this.class10_settings_0.int_3, 0x2af8, (float)this.class18_0.method_206(num5), 0f, (float)this.class18_0.method_206(0xff));
                    }
                }
                for (int j = 0; j < (this.int_7.GetUpperBound(0) - 1); j++)
                {
                    if ((this.struct19_2[j, 0].int_1 != 0) && (this.struct19_2[j, 1].int_1 != 0))
                    {
                        if (this.struct19_2[j + 1, 0].int_1 != 0)
                        {
                            this.graphics_0.DrawLine(pen, this.struct19_2[j, 0].int_0 + 5, this.struct19_2[j, 0].int_1, this.struct19_2[j + 1, 0].int_0 + 5, this.struct19_2[j + 1, 0].int_1);
                        }
                        continue;
                    }
                    if (j != 0)
                    {
                        num = j;
                        num2 = j;
                        while (this.struct19_2[num, 0].int_1 == 0)
                        {
                            num--;
                            if (num <= 0)
                            {
                                break;
                            }
                        }
                        while (this.struct19_2[num2, 0].int_1 == 0)
                        {
                            num2++;
                            if (num2 == (this.int_7.GetUpperBound(0) - 1))
                            {
                                break;
                            }
                        }
                        if (((num > 0) && (num2 > 0)) && ((this.struct19_2[num, 0].int_1 != 0) && (this.struct19_2[num2, 0].int_1 != 0)))
                        {
                            this.graphics_0.DrawLine(pen, this.struct19_2[num, 0].int_0 + 5, this.struct19_2[num, 0].int_1, this.struct19_2[num2, 0].int_0 + 5, this.struct19_2[num2, 0].int_1);
                        }
                    }
                }
                pen.Dispose();
                pen = null;
                pen = new Pen(this.class10_settings_0.color_12, 2f);
                for (int k = 0; k < (this.int_7.GetUpperBound(0) - 1); k++)
                {
                    if ((this.struct19_2[k, 0].int_1 != 0) && (this.struct19_2[k, 1].int_1 != 0))
                    {
                        if (this.struct19_2[k + 1, 1].int_1 != 0)
                        {
                            this.graphics_0.DrawLine(pen, this.struct19_2[k, 1].int_0 + 5, this.struct19_2[k, 1].int_1, this.struct19_2[k + 1, 1].int_0 + 5, this.struct19_2[k + 1, 1].int_1);
                        }
                        continue;
                    }
                    if (k != 0)
                    {
                        num = k;
                        num2 = k;
                        while (this.struct19_2[num, 1].int_1 == 0)
                        {
                            num--;
                            if (num <= 0)
                            {
                                break;
                            }
                        }
                        while (this.struct19_2[num2, 1].int_1 == 0)
                        {
                            num2++;
                            if (num2 == (this.int_7.GetUpperBound(0) - 1))
                            {
                                break;
                            }
                        }
                        if (((num > 0) && (num2 > 0)) && ((this.struct19_2[num, 1].int_1 != 0) && (this.struct19_2[num2, 1].int_1 != 0)))
                        {
                            this.graphics_0.DrawLine(pen, this.struct19_2[num, 1].int_0 + 5, this.struct19_2[num, 1].int_1, this.struct19_2[num2, 1].int_0 + 5, this.struct19_2[num2, 1].int_1);
                        }
                    }
                }
                pen.Dispose();
                pen = null;
            }
        }
    }

    private void method_3()
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.method_30_HasFileLoadedInBMTune())
            {
                this.class7_u_0 = new Class7_u[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
            }
        }
    }

    private int method_5()
    {
        double num = 0.0;
        for (int i = 0; i < this.int_2; i++)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                if (this.class18_0.method_174((byte) i, (byte) j) > num)
                {
                    num = this.class18_0.method_174((byte) i, (byte) j);
                }
            }
        }
        if (this.class18_0.method_37())
        {
            num = Math.Ceiling((double) (num / 50.0)) * 50.0;
            num += 50.0;
        }
        else if (this.class18_0.method_40())
        {
            num = Math.Ceiling((double) (num / 5.0)) * 5.0;
            num += 5.0;
        }
        else if (this.class18_0.method_38())
        {
            num = Math.Ceiling((double) (num / 25.0)) * 25.0;
        }
        return (int) num;
    }

    private float method_6()
    {
        double num = 0.0;
        for (int i = 0; i < this.int_2; i++)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                if (this.class18_0.method_174((byte) i, (byte) j) > num)
                {
                    num = this.class18_0.method_174((byte) i, (byte) j);
                }
            }
        }
        return (float) num;
    }

    private int method_7()
    {
        int num = 0;
        for (int i = 0; i < this.class18_0.method_32_GetRPM_RowsNumber(); i++)
        {
            if (this.class18_0.method_159((byte) i) > num)
            {
                num = this.class18_0.method_159((byte) i);
            }
        }
        return num;
    }

    private int method_8()
    {
        int num = 0;
        double num2 = 0.0;
        double num3 = 0.0;
        for (int i = 0; i < this.class18_0.method_32_GetRPM_RowsNumber(); i++)
        {
            if (this.class18_0.method_159((byte) i) > num)
            {
                num = this.class18_0.method_159((byte) i);
            }
        }
        num3 = num % 0x3e8;
        if (num3 < 500.0)
        {
            num2 = Math.Floor((double) (((double) num) / 1000.0));
        }
        else
        {
            num2 = Math.Ceiling((double) (((double) num) / 1000.0));
        }
        return (int) (num2 * 1000.0);
    }

    private Color method_9(float float_28)
    {
        return this.class18_0.method_236((double)float_28);
        /*if (this.class18_0.method_40())
        {
            return this.class18_0.method_236((double) float_28);
        }
        if (this.class18_0.method_38())
        {
            return this.class18_0.method_236((double) float_28);
        }
        if (this.class18_0.method_37())
        {
            float num = Math.Abs((float) (float_28 / this.float_11));
            return Color.FromArgb((int) (255f * num), 0xff - ((int) (255f * num)), 0);
        }
        return Color.FromArgb(0xff, 0, 0);*/
    }

    public void SetImageBackgrounds()
    {
        this.Refresh();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        //if (this.graphics_0 != null) this.graphics_0.Dispose();

        if (this.frmGridChart_0 == null)
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.FillRectangle(new SolidBrush(SystemColors.ControlDark), pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            return;
        }
        if (!this.class10_settings_0.bool_6)
        {
            return;
        }
        this.int_13 = base.ClientRectangle.Width - (this.int_10 + this.int_10_0);
        this.int_12 = base.ClientRectangle.Height - (2 * this.int_11);
        this.brush_0 = new SolidBrush(this.class10_settings_0.color_3);
        Rectangle ThisRec = new Rectangle(pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);

        Image ThisI;
        FileInfo info = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp");
        if (info.Exists) ThisI = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp");
        else ThisI = null;
        info = null;

        if (this.class18_0 == null)
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.FillRectangle(this.brush_0, pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            //this.graphics_0.DrawImageUnscaledAndClipped(ThisI, ThisRec);
            if (ThisI != null)
            {
                this.graphics_0.DrawImage(ThisI, ThisRec);
                ThisI.Dispose();
                ThisI = null;
            }
            return;
        }
        if (!this.class18_0.method_30_HasFileLoadedInBMTune() || !this.class16_u_0.method_0())
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.SmoothingMode = SmoothingMode.None;
            this.graphics_0.FillRectangle(this.brush_0, pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            //this.graphics_0.DrawImageUnscaledAndClipped(ThisI, ThisRec);
            if (ThisI != null)
            {
                this.graphics_0.DrawImage(ThisI, ThisRec);
                ThisI.Dispose();
                ThisI = null;
            }
            return;
        }
        if (!this.class16_u_0.method_0())
        {
            return;
        }
        this.graphics_0 = this.class16_u_0.method_3();
        this.graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
        this.graphics_0.FillRectangle(this.brush_0, pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
        //this.graphics_0.DrawImageUnscaledAndClipped(ThisI, ThisRec);
        if (ThisI != null)
        {
            this.graphics_0.DrawImage(ThisI, ThisRec);
            ThisI.Dispose();
            ThisI = null;
        }
        if (this.class10_settings_0.bool_20_ONLY_NA_VIEW)
        {
            int num = 0;
            for (int i = 0; i < this.class10_settings_0.method_11_GetMAP_ColumnsNumber(); i++)
            {
                if (this.class18_0.method_163((byte) i) < 0x41a)
                {
                    num++;
                }
            }
            this.int_2 = num;
        }
        else
        {
            this.int_2 = this.class10_settings_0.method_11_GetMAP_ColumnsNumber();
        }
        switch (this.mapGraphType_0)
        {
            case MapGraphType.twoD:
                this.float_4 = this.method_8();
                this.float_5 = this.method_5();
                this.float_3 = this.float_5 / 4f;
                this.float_2 = 1000f;
                this.method_10();
                this.method_11();
                goto Label_044C;

            case MapGraphType.threeD:
                this.pointF_0 = new PointF[4];
                this.method_14(false);
                this.method_15();
                this.method_16();
                goto Label_044C;

            case MapGraphType.timePlot:
                if (this.class10_settings_0.airFuelUnits_0 != AirFuelUnits.lambda)
                {
                    this.float_0 = (float)this.class18_0.method_241(0.68);
                    break;
                }
                this.float_0 = 0.68f;

                if (Last_Used_Sensor != 999) Reset_Struct_Sensor();

                Last_Used_Sensor = 999;
                break;

            case MapGraphType.rpmPlot:
                if (this.class10_settings_0.airFuelUnits_0 != AirFuelUnits.lambda)
                {
                    this.float_0 = (float)this.class18_0.method_241(0.68);
                }
                else
                {
                    this.float_0 = 0.68f;
                }
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
                {
                    this.float_1 = 1.36f;
                }
                else
                {
                    this.float_1 = (float)this.class18_0.method_241(1.36);
                }
                this.int_3 = 20;
                this.int_4 = 30;
                this.float_2 = 1000f;
                this.float_4 = 11000f;
                this.int_5 = 80;
                this.method_28();
                this.method_29();
                goto Label_044C;

            case MapGraphType.custom:
                //this.float_0 = frmGridChart_0.CustomMin;
                //this.float_1 = frmGridChart_0.CustomMax;
                this.Cint_Colomn = this.class10_settings_0.int_GraphColumns;
                this.int_3 = 20;
                this.int_4 = 30;
                this.int_5 = 80;

                if (this.class10_settings_0.int_GraphSensor >= 0)
                {
                    this.Cint_Sensor = this.class10_settings_0.int_GraphSensor;
                    if (this.Cint_Sensor != Last_Used_Sensor) Reset_Struct_Sensor();
                    Last_Used_Sensor = this.Cint_Sensor;
                }

                this.method_26_2();
                this.method_27_2();
                goto Label_044C;

            default:
                goto Label_044C;
        }
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
        {
            this.float_1 = 1.36f;
        }
        else
        {
            this.float_1 = (float) this.class18_0.method_241(1.36);
        }
        this.int_3 = 20;
        this.int_4 = 20;
        this.int_5 = 60;
        this.method_26();
        this.method_27();
    Label_044C:
        if (this.bool_3)
        {
            using (List<Class7_u>.Enumerator enumerator = this.class7_u_1.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Class7_u class7_u_0 = enumerator.Current;
                    this.method_12(Math.Round(this.double_0, 0).ToString() + " %", (float) this.point_1.X, (float) this.point_1.Y, this.double_0 > 0.0);
                }
                goto Label_05C0;
            }
        }
        if (this.bool_1 && !this.bool_0)
        {
            string str2 = string.Empty;
            if (this.class18_0.method_163((byte) this.int_0) > this.class10_settings_0.int_6)
            {
                str2 = str2 + this.class18_0.method_167((byte) this.int_0) + " " + this.class10_settings_0.mapSensorUnits_1.ToString();
            }
            else
            {
                str2 = str2 + this.class18_0.method_167((byte) this.int_0) + " " + this.class10_settings_0.mapSensorUnits_0.ToString();
            }
            str2 = str2 + "/" + this.class18_0.method_159((byte) this.int_1);
            this.method_13(str2, (float) this.point_1.X, (float) this.point_1.Y);
        }
    Label_05C0:
        if (this.bool_2)
        {
            Pen pen = new Pen(Color.White, 1f) {
                DashStyle = DashStyle.Dash
            };
            this.graphics_0.DrawRectangle(pen, this.rectangle_0);
            pen.Dispose();
            pen = null;
        }
        this.class16_u_0.method_2(pe.Graphics);
        this.pointF_0 = null;
    }

    protected override void OnPaintBackground(PaintEventArgs pe)
    {
    }
}

