using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

internal class frmAdvancedGraph : Form
{
    //private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();

    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    public Graphics graphics_0;
    private Brush brush_0;
    public ctrlAdvTable ctrlAdvTable_0;
    
    private Class18 class18_0;
    private Class10_settings class10_settings_0;

    private double double_0;
    private double double_1;

    private int TopOffset = 30;
    private int BottomOffset = 50;
    private int LeftOffset = 40;
    private int RightOffset = 20;
    private int TWidht = 0;
    private int THeight = 0;

    private int MaxColumns = 0;
    private int MaxRows = 0;

    private double MaxValueY = 0;
    private double MaxValueX = 0;
    private double MinValueY = 0;
    private double MinValueX = 0;

    //private bool bool_1 = false;
    //private bool bool_4 = false;
    //private bool bool_2 = false;
    //private bool SingleChange = false;
    private bool IsSelected = false;
    //private bool Dragging = false;

    private int RowSelected = 0;
    private int ColumnSelected = 0;

    private Point point_0;
    private Point point_1;
    private Point point_2;

    private Rectangle rectangle_0;

    private List<double> TitleList = new List<double>();
    private List<double[]> ValuesList = new List<double[]>();

    private List<int[]> Xposs = new List<int[]>();
    private List<int[]> Yposs = new List<int[]>();
    private List<bool[]> EditingList = new List<bool[]>();

    private bool EditMain = false;

    private List<int> Xposs2 = new List<int>();
    private List<int> Yposs2 = new List<int>();
    private List<bool> EditingList2 = new List<bool>();

    public frmAdvancedGraph(ref Class18 class18_1, ref ctrlAdvTable ctrlAdvTable_1)
    {
        this.InitializeComponent();

        class18_0 = class18_1;
        class10_settings_0 = this.class18_0.class10_settings_0;
        ctrlAdvTable_0 = ctrlAdvTable_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        //this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
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
            MouseEventArgs argument = (MouseEventArgs)e.Argument;
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
            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxColumns; j++)
                {
                    try
                    {
                        if (this.rectangle_0.Contains(this.Xposs[i][j], this.Yposs[i][j]))
                        {
                            this.EditingList[i][j] = true;
                            this.ctrlAdvTable_0.grid.ClearSelection();
                            this.ctrlAdvTable_0.grid[i, j].Selected = true;
                            base.Invalidate(false);
                            base.Update();
                            return;
                        }
                    }
                    catch { }
                }
            }
            this.Invalidate();
        }
    }*/

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvancedGraph));
            this.SuspendLayout();
            // 
            // frmAdvancedGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 430);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAdvancedGraph";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Table Graph";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmAdvancedGraph_MouseDown);
            this.MouseEnter += new System.EventHandler(this.frmAdvancedGraph_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.frmAdvancedGraph_MouseLeave);
            this.MouseHover += new System.EventHandler(this.frmAdvancedGraph_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmAdvancedGraph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmAdvancedGraph_MouseUp);
            this.Resize += new System.EventHandler(this.frmAdvancedGraph_Resize);
            this.ResumeLayout(false);

    }

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        this.graphics_0 = pe.Graphics;
        this.graphics_0.SmoothingMode = SmoothingMode.None;

        //Rectangle ThisRec = new Rectangle(pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
        //this.graphics_0.DrawImage(ThisI, ThisRec);
        Pen pen = new Pen(this.class10_settings_0.color_11);
        Pen pen2 = new Pen(this.class10_settings_0.color_14, 1f);
        this.brush_0 = new SolidBrush(this.class10_settings_0.color_3);

        TWidht = base.ClientRectangle.Width - LeftOffset - RightOffset;
        THeight = base.ClientRectangle.Height - TopOffset - BottomOffset;

        this.graphics_0.FillRectangle(this.brush_0, 0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height);

        this.graphics_0.DrawLine(pen, LeftOffset, base.ClientRectangle.Top + TopOffset, LeftOffset, base.ClientRectangle.Bottom - BottomOffset);       //left
        this.graphics_0.DrawLine(pen, LeftOffset, base.ClientRectangle.Bottom - BottomOffset, base.ClientRectangle.Width - RightOffset, base.ClientRectangle.Bottom - BottomOffset); //down
        this.graphics_0.DrawLine(pen, base.ClientRectangle.Width - RightOffset, base.ClientRectangle.Top + TopOffset, base.ClientRectangle.Width - RightOffset, base.ClientRectangle.Bottom - BottomOffset); //right
        this.graphics_0.DrawLine(pen, LeftOffset, base.ClientRectangle.Top + TopOffset, base.ClientRectangle.Width - RightOffset, base.ClientRectangle.Top + TopOffset); //top

        string str = "";
        SolidBrush brush2 = new SolidBrush(this.class10_settings_0.color_12);

        MaxColumns = ctrlAdvTable_0.method_3();
        MaxRows = ctrlAdvTable_0.method_5();

        //if (!this.Dragging && !this.SingleChange && !this.IsSelected)
        if (!this.IsSelected)
        {
            TitleList.Clear();
            ValuesList.Clear();
            this.Xposs.Clear();
            this.Yposs.Clear();
            this.EditingList.Clear();
            this.Xposs2.Clear();
            this.Yposs2.Clear();
            this.EditingList2.Clear();

            //Get values and max/min values
            for (int i = 0; i < MaxRows; i++)
            {
                //add to list
                double[] NewD = new double[MaxColumns];

                for (int i2 = 0; i2 < MaxColumns; i2++)
                {
                    //Calculate max Y (first rows only)
                    if (i == 0)
                    {
                        double ThisV = double.Parse(ctrlAdvTable_0.grid.Rows[i].Cells[i2].Value.ToString());
                        if (i2 == 0)
                        {
                            MaxValueY = ThisV;
                            MinValueY = ThisV;
                        }
                        if (ThisV > MaxValueY) MaxValueY = ThisV;
                        if (ThisV < MinValueY) MinValueY = ThisV;

                        TitleList.Add(double.Parse(ctrlAdvTable_0.grid.Rows[i].Cells[i2].Value.ToString()));
                    }
                    else
                    {
                        double ThisV = double.Parse(ctrlAdvTable_0.grid.Rows[i].Cells[i2].Value.ToString());
                        if (i == 1 && i2 == 0)
                        {
                            MaxValueX = ThisV;
                            MinValueX = ThisV;
                        }
                        if (ThisV > MaxValueX) MaxValueX = ThisV;
                        if (ThisV < MinValueX) MinValueX = ThisV;

                        NewD[i2] = double.Parse(ctrlAdvTable_0.grid.Rows[i].Cells[i2].Value.ToString());
                    }
                }

                //add to list
                if (i != 0) ValuesList.Add(NewD);
            }
        }

        //Console.WriteLine(MaxValueX);
        //Console.WriteLine(MinValueX);

        //Spawn Graph
        Font font = new Font("Lucida Sans", 12f, FontStyle.Bold);
        str = this.ctrlAdvTable_0.method_24().ToString();
        this.graphics_0.DrawString(str, font, brush2, LeftOffset + (TWidht / 2) - (this.graphics_0.MeasureString(str, font).Width / 2f), base.ClientRectangle.Bottom - 20);

        font = new Font("Lucida Sans", 8f, FontStyle.Regular);
        
        for (int i = 0; i < MaxColumns; i++)
        {
            double ThisVal = TitleList[i];
            double Ypercent = (((ThisVal - MinValueY) * 100) / (MaxValueY - MinValueY)) / 100;

            str = ThisVal.ToString();
            int YPos = (int)(LeftOffset + (Ypercent * TWidht));

            this.graphics_0.DrawString(str, font, brush2, YPos - (this.graphics_0.MeasureString(str, font).Width / 2f), base.ClientRectangle.Bottom - BottomOffset + 4);

            if (this.IsSelected && this.EditingList2[i] == true) pen = new Pen(Color.FromArgb(0, 0, 200));
            else pen = new Pen(this.class10_settings_0.color_11);

            this.graphics_0.DrawLine(pen, YPos, base.ClientRectangle.Bottom - BottomOffset + 20, YPos, base.ClientRectangle.Bottom - BottomOffset + 30);

            if (this.IsSelected && EditMain && ColumnSelected == i)
            {
                pen = new Pen(this.class10_settings_0.color_11, 2f);
                this.graphics_0.DrawLine(pen, this.point_1.X, base.ClientRectangle.Bottom - BottomOffset + 20, this.point_1.X, base.ClientRectangle.Bottom - BottomOffset + 32);
            }

            //if (!this.Dragging && !this.SingleChange && !this.IsSelected)
            if (!this.IsSelected)
            {
                Xposs2.Add(YPos);
                Yposs2.Add(base.ClientRectangle.Bottom - BottomOffset + 20);
                EditingList2.Add(false);
            }
            //pen = new Pen(this.class10_0.color_11);
            if (i != 0 && i != MaxColumns - 1) this.graphics_0.DrawLine(pen2, YPos, base.ClientRectangle.Bottom - BottomOffset, YPos, base.ClientRectangle.Top + TopOffset); //down
        }
        for (int i = 0; i < MaxRows - 1; i++)
        {
            int XLast = 0;
            int YLast = 0;

            int XLastEdit = 0;
            int YLastEdit = 0;

            //pen = new Pen(Color.FromArgb(200 - (i * 50), 255, 200 - (i * 50)));
            //this.brush_0 = new SolidBrush(Color.FromArgb(200 - (i * 50), 255, 200 - (i * 50)));

            //if (!this.Dragging && !this.SingleChange && !this.IsSelected)
            if (!this.IsSelected)
            {
                this.Xposs.Add(new int[MaxColumns]);
                this.Yposs.Add(new int[MaxColumns]);
                this.EditingList.Add(new bool[MaxColumns]);
            }

            for (int i2 = 0; i2 < MaxColumns; i2++)
            {
                double Thistitle = TitleList[i2];
                double ThisVal = ValuesList[i][i2];
                str = ThisVal.ToString();

                double Ypercent = 0;
                double Xpercent = 0;

                if (MinValueY != MaxValueY) Ypercent = (((Thistitle - MinValueY) * 100) / (MaxValueY - MinValueY)) / 100;
                if (MinValueX != MaxValueX) Xpercent = (((ThisVal - MinValueX) * 100) / (MaxValueX - MinValueX)) / 100;

                if (Ypercent < 0) Ypercent = 0;
                if (Ypercent > 1) Ypercent = 1;
                if (Xpercent < 0) Xpercent = 0;
                if (Xpercent > 1) Xpercent = 1;

                int YPos = (int)(LeftOffset + 2 + (Ypercent * (TWidht - 2)));
                int Xpos = (int)(BottomOffset + (Xpercent * (THeight)));

                pen = new Pen(Color.FromArgb(200 - (i * 50), 255, 200 - (i * 50)));
                //if ((this.Dragging || this.SingleChange || this.IsSelected) && this.EditingList[i][i2] == true) this.brush_0 = new SolidBrush(Color.FromArgb(0, 0, 200));
                if (this.IsSelected && this.EditingList[i][i2] == true) this.brush_0 = new SolidBrush(Color.FromArgb(0, 0, 200));
                else this.brush_0 = new SolidBrush(Color.FromArgb(200 - (i * 50), 255, 200 - (i * 50)));
                
                //line from last spot to current
                if (i2 != 0) this.graphics_0.DrawLine(pen, YLast, base.ClientRectangle.Bottom - XLast, YPos, base.ClientRectangle.Bottom - Xpos);

                if (i2 != 0 && !EditMain)
                {
                    if (IsSelected && ((RowSelected == i && ColumnSelected == i2) || (RowSelected == i && ColumnSelected == i2-1)))
                    {
                        pen = new Pen(this.class10_settings_0.color_11, 2f);
                        pen.DashStyle = DashStyle.Dash;
                        if (RowSelected == i && ColumnSelected == i2)
                        {
                            this.graphics_0.DrawLine(pen, YLast, base.ClientRectangle.Bottom - XLast, YPos, this.point_1.Y);
                            XLastEdit = YPos;
                            YLastEdit = this.point_1.Y;
                        }
                        if (RowSelected == i && ColumnSelected == i2 - 1)
                        {
                            this.graphics_0.DrawLine(pen, XLastEdit, YLastEdit, YPos, base.ClientRectangle.Bottom - Xpos);
                        }
                    }
                }

                //draw square at current position
                this.graphics_0.FillRectangle(this.brush_0, YPos - 3, base.ClientRectangle.Bottom - Xpos - 3, 6, 6);

                //if (!this.Dragging && !this.SingleChange && !this.IsSelected)
                if (!this.IsSelected)
                {
                    this.Xposs[i][i2] = YPos;
                    this.Yposs[i][i2] = base.ClientRectangle.Bottom - Xpos;
                    this.EditingList[i][i2] = false;
                }

                brush2 = new SolidBrush(this.class10_settings_0.color_13);
                this.graphics_0.DrawString(str, font, brush2, 5, base.ClientRectangle.Bottom - Xpos - 8);

                XLast = Xpos;
                YLast = YPos;
            }
        }

        if (this.IsSelected)
        {
            this.method_12(Math.Round(this.double_1, 2).ToString() + "(" + Math.Round(this.double_0, 0).ToString() + "%)", (float)this.point_1.X, (float)this.point_1.Y, this.double_0 > 0.0);
        }
    }

    private void method_12(string string_0, float float_28, float float_29, bool bool_5)
    {
        if (bool_5) this.graphics_0.FillRectangle(new SolidBrush(Color.FromArgb(20, 190, 20)), (float)(float_28 - 5f), (float)(float_29 - 20f), (float)55f, (float)15f);
        else this.graphics_0.FillRectangle(new SolidBrush(Color.FromArgb(215, 120, 120)), (float)(float_28 - 5f), (float)(float_29 - 20f), (float)55f, (float)15f);
        this.graphics_0.DrawString(string_0, new Font("Lucida Sans", 7f, FontStyle.Regular), new SolidBrush(this.class10_settings_0.color_11), (float)(float_28 - 5f), (float)(float_29 - 20f));
    }

    private void frmAdvancedGraph_Resize(object sender, EventArgs e)
    {
        if (base.WindowState == FormWindowState.Normal)
        {
            //this.Invalidate();
            this.Refresh();
        }
    }



    private void frmAdvancedGraph_MouseEnter(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Cross;
    }

    private void frmAdvancedGraph_MouseHover(object sender, EventArgs e)
    {
        base.Focus();
    }

    private void frmAdvancedGraph_MouseLeave(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Default;
    }

    private void frmAdvancedGraph_MouseMove(object sender, MouseEventArgs e)
    {
        if (IsSelected)
        {
            this.point_1.X = e.X;
            this.point_1.Y = e.Y;

            if (!EditMain)
            {
                this.double_0 = ((float)(base.ClientRectangle.Bottom - BottomOffset - e.Y) / (float)(this.THeight)) * 100.0;
                this.double_1 = MinValueX + ((this.double_0 * (MaxValueX - MinValueX)) / 100);
            }
            else
            {
                this.double_0 = ((float)(base.ClientRectangle.Width - RightOffset - e.X) / (float)(this.TWidht)) * 100.0;
                this.double_1 = MaxValueY + ((this.double_0 * (MinValueY - MaxValueY)) / 100);
            }

            base.Invalidate();
        }
        //try
        //{
            /*this.point_1.X = e.X;
            this.point_1.Y = e.Y;
            if (this.SingleChange)
            {
                this.double_0 = -((float)(e.Y - this.point_0.Y) / (float)(this.THeight - this.point_0.Y)) * 100.0;
                base.Invalidate();
            }
            else if (this.Dragging && !this.SingleChange)
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
                for (int i = 0; i < MaxRows-1; i++)
                {
                    for (int j = 0; j < MaxColumns; j++)
                    {
                        //Refresh
                        if (this.rectangle_0.Contains(this.Xposs[i][j], this.Yposs[i][j]))
                        {
                            if (!this.EditingList[i][j])
                            {
                                this.EditingList[i][j] = true;

                                //method15 replacement
                                this.ctrlAdvTable_0.grid.ClearSelection();
                                this.ctrlAdvTable_0.grid[j, i+1].Selected = true;
                            }
                        }
                        else
                        {
                            this.EditingList[i][j] = false;
                            this.ctrlAdvTable_0.grid[j, i+1].Selected = false;
                        }
                    }
                }
                this.Refresh();
            }
            else
            {
                for (int k = 0; k < MaxRows - 1; k++)
                {
                    for (int m = 0; m < MaxColumns; m++)
                    {
                        Rectangle rectangle = new Rectangle((this.Xposs[k][m]) - 4, (this.Yposs[k][m]) - 4, 8, 8);
                        Point p = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                        p = base.PointToClient(p);
                        if (rectangle.Contains(p.X, p.Y) && this.EditingList[k][m])
                        {
                            if (!this.bool_1)
                            {
                                this.bool_1 = true;
                                base.Invalidate();
                            }
                            break;
                        }
                        this.bool_1 = false;
                    }
                    //base.Invalidate();
                }
            }
            this.point_2.X = e.X;
            this.point_2.Y = e.Y;*/
        //}
        //catch { }
    }

    private void frmAdvancedGraph_MouseDown(object sender, MouseEventArgs e)
    {
        this.point_0.X = e.X;
        this.point_0.Y = e.Y;
        this.point_1.Y = e.Y;
        this.point_1.X = e.X;
        IsSelected = false;
        if (e.Button == MouseButtons.Left)
        {
            for (int i = 0; i < MaxRows - 1; i++)
            {
                for (int j = 0; j < MaxColumns; j++)
                {
                    Rectangle rectangle = new Rectangle(this.Xposs[i][j] - 4, this.Yposs[i][j] - 4, 8, 8);
                    Point p = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                    p = base.PointToClient(p);
                    if (rectangle.Contains(p.X, p.Y) && !this.EditingList[i][j])
                    {
                        RowSelected = i;
                        ColumnSelected = j;
                        EditMain = false;
                        this.ctrlAdvTable_0.grid.ClearSelection();
                        IsSelected = true;
                        this.EditingList[i][j] = true;
                        this.ctrlAdvTable_0.grid[j, i + 1].Selected = true;
                        this.Refresh();
                        return;
                    }
                    //if (!rectangle.Contains(p.X, p.Y) && this.EditingList[i][j]) this.EditingList[i][j] = false;

                    //if (rectangle.Contains(p.X, p.Y) && this.EditingList[i][j]) this.SingleChange = true;
                    //else this.Dragging = true;
                }
            }
            for (int j = 0; j < MaxColumns; j++)
            {
                Rectangle rectangle = new Rectangle(this.Xposs2[j] - 1, this.Yposs2[j] - 1, 3, 12);
                Point p = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                p = base.PointToClient(p);
                if (rectangle.Contains(p.X, p.Y) && !this.EditingList2[j])
                {
                    ColumnSelected = j;
                    EditMain = true;
                    this.ctrlAdvTable_0.grid.ClearSelection();
                    IsSelected = true;
                    this.EditingList2[j] = true;
                    this.ctrlAdvTable_0.grid[j, 0].Selected = true;
                    this.Refresh();
                    return;
                }
            }
        }
    }

    private void frmAdvancedGraph_MouseUp(object sender, MouseEventArgs e)
    {
        //this.Dragging = false;
        this.Refresh();
        if (this.IsSelected)
        {
            this.class18_0.method_155("ADV Table : " + this.class18_0.method_4().ToString() + " graph adjustments");

            try
            {
                if (!EditMain) this.ctrlAdvTable_0.grid[ColumnSelected, RowSelected + 1].Value = this.double_1;
                else this.ctrlAdvTable_0.grid[ColumnSelected, 0].Value = this.double_1;
            }
            catch { }

            //foreach (Class7_u class2 in this.list_0)
            //{
            //    try
            //    {
            //float num = this.class18_0.method_174((byte)class2.method_0(), (byte)class2.method_2());
            //this.class18_0.method_176((byte)class2.method_0(), (byte)class2.method_2(), num + (num * ((float)(Math.Round(this.double_0, 0) / 100.0))));
            //this.ctrlGrid_0.method_34(class2.method_0(), class2.method_2());
            //    }
            //    catch (Exception exception)
            //    {
            //        throw exception;
            //    }
            //}
            this.class18_0.method_153();
            this.IsSelected = false;
            this.Refresh();
        }
    }

    /*private void frmAdvancedGraph_KeyUp(object sender, KeyEventArgs e)
    {
        this.bool_4 = e.Control;
    }

    private void frmAdvancedGraph_KeyDown(object sender, KeyEventArgs e)
    {
        this.bool_4 = e.Control;
        if (((e.KeyCode == Keys.Up) && e.Control))
        {
            //this.frmGridChart_0.toolIncrease_Click(null, null);
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        else if (((e.KeyCode == Keys.Down) && e.Control))
        {
            //this.frmGridChart_0.toolDecrease_Click(null, null);
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        else if (e.KeyCode == Keys.Escape)
        {
            this.SingleChange = false;
        }
        else
        {
            e.Handled = false;
        }
    }

    private void frmAdvancedGraph_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Dragging = false;
            this.SingleChange = false;
            base.Invalidate();
        }
    }*/
}

