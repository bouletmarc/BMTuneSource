namespace Controls
{
    using Data;
    //using PropertiesRes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Threading;

    [DoNotObfuscate]
    public class ctrlLogGraph : UserControl
    {
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private Class10_settings class10_settings_0;
        private Class16_u class16_u_0 = new Class16_u();
        private Class17 class17_0;
        private Class18 class18_0;
        private Class33_Sensors Class33_Sensors_0;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editTemplatesToolStripMenuItem;
        private float float_0 = 1f;
        private float float_1 = 1f;
        private float float_2 = 4f;
        private Graphics graphics_0;
        private IContainer icontainer_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3 = 4;      //X spacing
        private int int_4 = 22;     //Y bottom offset
        private int int_right = 4;
        private int int_6;
        private int int_7;
        private Point[] point_0;
        private ToolStripMenuItem setEndToolStripMenuItem;
        private ToolStripMenuItem setStartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolTip toolTip_0;
        private ToolStripMenuItem zoomFullToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private IContainer components;
        private ToolStripMenuItem zoomOutToolStripMenuItem;

        public event plotChangeDelegate plotChangeDelegate_0;
        public event plotCursorChangeDelegate plotCursorChangeDelegate_0;
        public event requestEditTemplateDelegate requestEditTemplateDelegate_0;

        //############################################
        //live graph
        private List<int[]> struct_PosX;
        private List<int[]> struct_PosY;
        private List<Color[]> struct_Col;

        private int CurrentFrame_Live;
        private int CurrentSensor_Live;
        private int CurrentGraph_Live = 0;
        private int custom_value_int;
        private float custom_value_float;
        private int NumberOfSensors = 0;
        private int NumberOfFrames = 0;
        private int LastShown = 0;

        private DateTime LastCheck = DateTime.Now;

        public ctrlLogGraph()
        {
            this.InitializeComponent();
        }

        public void clearMarkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.class17_0.list_1.Clear();
            this.Refresh();
        }

        private void ClearMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.class17_0.list_1.RemoveAt(this.int_6);
            this.Refresh();
        }

        public void Close()
        {
            if (this.class17_0 != null)
            {
                this.class17_0.delegate54_0 -= new Class17.Delegate54(this.method_3);
                this.class17_0.delegate53_0 -= new Class17.Delegate53(this.method_4);
                this.class10_settings_0.delegate14_0 -= new Class10_settings.Delegate14(this.method_1);
                this.class10_settings_0.chartCollection_0.templateChangedDelegate_0 -= new ChartCollection.templateChangedDelegate(this.method_2);
                this.class17_0 = null;
            }
            if (this.class18_0 != null)
            {
                this.class18_0 = null;
            }
            if (this.class10_settings_0 != null)
            {
                this.class10_settings_0 = null;
            }
            if (this.point_0 != null)
            {
                this.point_0 = null;
            }
            if (this.class16_u_0 != null)
            {
                this.class16_u_0 = null;
            }
            /*if (this.backgroundWorker1 != null)
            {
                if (this.backgroundWorker1.IsBusy) this.backgroundWorker1.CancelAsync();
                this.backgroundWorker1.Dispose();
                this.backgroundWorker1 = null;
            }*/
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.zoomFullToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            this.zoomInToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            this.zoomOutToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            this.setEndToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            this.setStartToolStripMenuItem.Enabled = this.class17_0.method_63_HasLogsFileOpen();
            if (this.int_7 < (base.ClientRectangle.Left + this.int_3))
            {
                this.int_7 = base.ClientRectangle.Left + this.int_3;
            }
            if (this.int_7 > (base.ClientSize.Width - 4))
            {
                this.int_7 = base.ClientSize.Width - 4;
            }
            Math.Abs((float)(this.PlotStart + (((this.int_7 - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
            float num = Math.Abs((float)(this.PlotStart + ((((this.int_7 - 2f) - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
            float num2 = Math.Abs((float)(this.PlotStart + ((((this.int_7 + 2f) - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
        }

        private void ctrlLogGraph_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.class17_0 != null) && this.class17_0.method_63_HasLogsFileOpen())
            {
                if (this.class10_settings_0.GetKeyPressed(e, "Move datalog cursor left"))
                {
                    if ((this.PlotCursor - 5) >= 0)
                    {
                        this.PlotCursor -= 5;
                    }
                    else if ((this.PlotCursor - 1) >= 0)
                    {
                        this.PlotCursor--;
                    }
                    if (this.plotCursorChangeDelegate_0 != null)
                    {
                        this.plotCursorChangeDelegate_0(this.PlotCursor);
                    }
                    this.Invalidate();
                    //this.Refresh(); //this one disabled
                }
                else if (this.class10_settings_0.GetKeyPressed(e, "Move datalog cursor right"))
                {
                    if ((this.PlotCursor + 5) <= this.PlotEnd)
                    {
                        this.PlotCursor += 5;
                    }
                    else if ((this.PlotCursor + 1) <= this.PlotEnd)
                    {
                        this.PlotCursor++;
                    }
                    if (this.plotCursorChangeDelegate_0 != null)
                    {
                        this.plotCursorChangeDelegate_0(this.PlotCursor);
                    }
                    this.Invalidate();
                    //this.Refresh(); //this one disabled
                }
                else if (this.class10_settings_0.GetKeyPressed(e, "Move datalog cursor large step left"))
                {
                    if ((this.PlotCursor - 50) >= 0)
                    {
                        this.PlotCursor -= 50;
                    }
                    else if ((this.PlotCursor - 10) >= 0)
                    {
                        this.PlotCursor -= 10;
                    }
                    if (this.plotCursorChangeDelegate_0 != null)
                    {
                        this.plotCursorChangeDelegate_0(this.PlotCursor);
                    }
                    this.Invalidate();
                    //this.Refresh(); //this one disabled
                }
                else if (this.class10_settings_0.GetKeyPressed(e, "Move datalog cursor large step right"))
                {
                    if ((this.PlotCursor + 50) >= this.PlotEnd)
                    {
                        this.PlotCursor += 50;
                    }
                    else if ((this.PlotCursor + 10) >= this.PlotEnd)
                    {
                        this.PlotCursor += 10;
                    }
                    if (this.plotCursorChangeDelegate_0 != null)
                    {
                        this.plotCursorChangeDelegate_0(this.PlotCursor);
                    }
                    this.Invalidate();
                    //this.Refresh(); //this one disabled
                }
                else if (this.class10_settings_0.GetKeyPressed(e, "Zoom in"))
                {
                    this.zoomInToolStripMenuItem_Click(null, null);
                }
                else if (this.class10_settings_0.GetKeyPressed(e, "Zoom out"))
                {
                    this.zoomOutToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void ctrlLogGraph_Load(object sender, EventArgs e)
        {
        }

        private void ctrlLogGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if ((this.class17_0 != null) && this.class17_0.method_63_HasLogsFileOpen())
            {
                this.int_7 = e.X;
                int x = e.X;
                if (this.int_7 < (base.ClientRectangle.Left + this.int_3))
                {
                    this.int_7 = base.ClientRectangle.Left + this.int_3;
                }
                if (this.int_7 > (base.ClientSize.Width - 4))
                {
                    this.int_7 = base.ClientSize.Width - 4;
                }
                int num2 = this.method_9();
                float num3 = Math.Abs((float)(this.PlotStart + ((((x - 2f) - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
                float num4 = Math.Abs((float)(this.PlotStart + ((((x + 2f) - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
                for (int i = 0; i < this.class17_0.list_1.Count; i++)
                {
                    if ((this.class17_0.list_1[i].int_0 > num3) && (this.class17_0.list_1[i].int_0 < num4))
                    {
                        this.int_6 = i;
                        break;
                    }
                }
                this.setStartToolStripMenuItem.Text = "Start At: " + this.method_8((long)this.class17_0.method_77(SensorsX.duration, num2));
                this.setEndToolStripMenuItem.Text = "End At: " + this.method_8((long)this.class17_0.method_77(SensorsX.duration, num2));
                if (e.Button == MouseButtons.Right)
                {
                    this.bool_1 = false;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    this.bool_1 = true;
                    this.PlotCursor = num2;
                    if (this.plotCursorChangeDelegate_0 != null)
                    {
                        this.plotCursorChangeDelegate_0(this.PlotCursor);
                    }
                    this.Invalidate();
                    //this.Refresh(); //this one disabled
                }
            }
        }

        private void ctrlLogGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if ((this.class17_0 != null) && this.class17_0.method_63_HasLogsFileOpen())
            {
                int x = e.X;
                this.int_7 = e.X;
                if (x < (base.ClientRectangle.Left + this.int_3))
                {
                    x = base.ClientRectangle.Left + this.int_3;
                }
                if (x > (base.ClientSize.Width - 4))
                {
                    x = base.ClientSize.Width - 4;
                }
                float num2 = Math.Abs((float)(this.PlotStart + (((x - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
                float num3 = Math.Abs((float)(this.PlotStart + ((((x - 2f) - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
                float num4 = Math.Abs((float)(this.PlotStart + ((((x + 2f) - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
                for (int i = 0; i < this.class17_0.list_1.Count; i++)
                {
                    if ((this.class17_0.list_1[i].int_0 > num3) && (this.class17_0.list_1[i].int_0 < num4))
                    {
                        this.int_6 = i;
                        this.Cursor = Cursors.Hand;
                        this.toolTip_0.Active = true;
                        if (this.class17_0.list_1[i].string_0.Length < 250)
                        {
                            this.toolTip_0.Show(this.class17_0.list_1[i].string_0, this, e.X + 15, e.Y, 0x186a0);
                        }
                        else
                        {
                            this.toolTip_0.Show(this.class17_0.list_1[i].string_0.Remove(0xf9) + "....", this, e.X + 15, e.Y, 0x186a0);
                        }
                        if (this.class17_0.list_1[i].string_0 == string.Empty)
                        {
                            this.bool_2 = true;
                            base.Invalidate(new Rectangle(e.X - 5, base.ClientRectangle.Top, 30, base.Height));
                        }
                        else
                        {
                            this.bool_2 = false;
                            base.Invalidate(new Rectangle(e.X - 5, base.ClientRectangle.Top, 30, base.Height));
                        }
                        goto Label_0359;
                    }
                    this.toolTip_0.Active = false;
                    this.Cursor = Cursors.Cross;
                    if ((this.class17_0.list_1[i].string_0 == string.Empty) && this.bool_2)
                    {
                        this.bool_2 = false;
                        base.Invalidate(new Rectangle(e.X - 5, base.ClientRectangle.Top, 30, base.Height));
                    }
                }
                if (this.class17_0.list_1.Count == 0)
                {
                    this.toolTip_0.Active = false;
                    this.Cursor = Cursors.Cross;
                }
                Label_0359:
                if (this.bool_1)
                {
                    this.Cursor = Cursors.VSplit;
                }
                else if (this.Cursor == Cursors.Cross)
                {
                    if ((this.PlotCursor > num3) && (this.PlotCursor < num4))
                    {
                        this.Cursor = Cursors.VSplit;
                    }
                    else
                    {
                        this.Cursor = Cursors.Cross;
                    }
                }
                if (this.bool_1)
                {
                    this.PlotCursor = (int)num2;
                    if (this.plotCursorChangeDelegate_0 != null)
                    {
                        this.plotCursorChangeDelegate_0(this.PlotCursor);
                    }
                    base.Invalidate(false);
                }
            }
        }

        private void ctrlLogGraph_MouseUp(object sender, MouseEventArgs e)
        {
            this.bool_1 = false;
        }

        private void ctrlLogGraph_Resize(object sender, EventArgs e)
        {
            this.class16_u_0.method_1(base.CreateGraphics(), base.ClientRectangle.Width, base.ClientRectangle.Height);
            if ((this.class18_0 != null) && (this.class10_settings_0 != null))
            {
                this.method_17();
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.class16_u_0 = null;
            if (this.graphics_0 != null) this.graphics_0.Dispose();
            this.point_0 = null;
            this.class10_settings_0 = null;
            this.class17_0 = null;
            this.class18_0 = null;
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void editTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.requestEditTemplateDelegate_0 != null)
            {
                this.requestEditTemplateDelegate_0();
            }
        }

        ~ctrlLogGraph()
        {
            if (this.class17_0 != null)
            {
                this.class17_0.delegate54_0 -= new Class17.Delegate54(this.method_3);
                this.class17_0.delegate53_0 -= new Class17.Delegate53(this.method_4);
                this.class17_0 = null;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTemplatesToolStripMenuItem,
            this.toolStripSeparator3,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoomFullToolStripMenuItem,
            this.toolStripSeparator1,
            this.setStartToolStripMenuItem,
            this.setEndToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 148);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editTemplatesToolStripMenuItem
            // 
            this.editTemplatesToolStripMenuItem.Name = "editTemplatesToolStripMenuItem";
            this.editTemplatesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.editTemplatesToolStripMenuItem.Text = "Edit Graph";
            this.editTemplatesToolStripMenuItem.Click += new System.EventHandler(this.editTemplatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(126, 6);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // zoomFullToolStripMenuItem
            // 
            this.zoomFullToolStripMenuItem.Name = "zoomFullToolStripMenuItem";
            this.zoomFullToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomFullToolStripMenuItem.Text = "Zoom Full";
            this.zoomFullToolStripMenuItem.Click += new System.EventHandler(this.zoomFullToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // setStartToolStripMenuItem
            // 
            this.setStartToolStripMenuItem.Name = "setStartToolStripMenuItem";
            this.setStartToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.setStartToolStripMenuItem.Text = "Start At";
            this.setStartToolStripMenuItem.Click += new System.EventHandler(this.setStartToolStripMenuItem_Click);
            // 
            // setEndToolStripMenuItem
            // 
            this.setEndToolStripMenuItem.Name = "setEndToolStripMenuItem";
            this.setEndToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.setEndToolStripMenuItem.Text = "End At";
            this.setEndToolStripMenuItem.Click += new System.EventHandler(this.setEndToolStripMenuItem_Click);
            // 
            // toolTip_0
            // 
            this.toolTip_0.Active = false;
            this.toolTip_0.AutoPopDelay = 10000;
            this.toolTip_0.InitialDelay = 500;
            this.toolTip_0.ReshowDelay = 100;
            // 
            // ctrlLogGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Name = "ctrlLogGraph";
            this.Size = new System.Drawing.Size(349, 299);
            this.Load += new System.EventHandler(this.ctrlLogGraph_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ctrlLogGraph_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrlLogGraph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctrlLogGraph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctrlLogGraph_MouseUp);
            this.Resize += new System.EventHandler(this.ctrlLogGraph_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1)
        {
            this.class18_0 = class18_1;
            this.class10_settings_0 = class10_1;
            this.class10_settings_0.chartCollection_0.templateChangedDelegate_0 += new ChartCollection.templateChangedDelegate(this.method_2);
            this.class10_settings_0.delegate14_0 += new Class10_settings.Delegate14(this.method_1);
            this.class17_0 = class17_1;
            this.class17_0.delegate53_0 += new Class17.Delegate53(this.method_4);
            this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_3);

            this.Class33_Sensors_0 = this.class17_0.class33_Sensors;

            if (IsConnectedOrLogging())
            {
                this.int_0 = 0;
                this.PlotEnd = (int)this.class17_0.method_65();
            }

            this.BackColor = this.class10_settings_0.color_8;

            foreach (Control control in base.Controls)
            {
                float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
                control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
            }
        }

        private void method_1()
        {
            this.method_17();
        }

        private int method_10(float float_3)
        {
            return (int)Math.Abs((float)(this.PlotStart + (((float_3 - this.int_3) / ((float)(this.method_5() - 2))) * (this.PlotEnd - this.PlotStart))));
        }

        private void method_11(Point[] point_1, int int_8, int int_9, float float_3, float float_4, float float_5, int int_10)
        {
            int num = ((int_10 + 1) + (this.method_6() - 2)) - ((int)(((this.method_6() - 2) * (float_3 - float_4)) / (float_5 - float_4)));
            if (num < (int_10 + 1))
            {
                num = int_10 + 1;
            }
            point_1[int_8].X = this.int_3 + ((int)Math.Abs((float)((this.method_5() - 1 - int_right) * ((this.PlotStart - int_9) / (this.PlotEnd - this.PlotStart)))));
            point_1[int_8].Y = num + 20;
        }

        private void method_12()
        {
            if (this.class10_settings_0 != null)
            {
                Pen pen = new Pen(Color.Black, 1f);
                string text = string.Empty;
                int width = 0;
                Font font = new Font("Lucida Sans", 10f);
                SolidBrush brush = null;
                int y = 0;
                for (int j = 0; j < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; j++)
                {
                    y = this.method_7(j) + 20;
                    this.graphics_0.FillRectangle(new SolidBrush(this.class10_settings_0.color_7), base.ClientRectangle.X + this.int_3, y, base.ClientRectangle.Width - this.int_3 - int_right, this.method_6());
                    //Rectangle ThisRec = new Rectangle(base.ClientRectangle.X + this.int_3, y, base.ClientRectangle.Width - this.int_3 - int_right, this.method_6());
                    //this.graphics_0.DrawImageUnscaledAndClipped(global::Properties.Resources.Back_Full, ThisRec);
                    this.graphics_0.DrawLine(pen, base.ClientRectangle.Left + this.int_3, y, base.ClientRectangle.Left + this.int_3, y + this.method_6());
                    this.graphics_0.DrawLine(pen, base.ClientRectangle.Left + this.int_3, y + this.method_6(), base.ClientRectangle.Right - int_right, y + this.method_6());
                    this.graphics_0.DrawLine(pen, base.ClientRectangle.Right - int_right, y, base.ClientRectangle.Right - int_right, y + this.method_6());
                    this.graphics_0.DrawLine(pen, base.ClientRectangle.Left + this.int_3, y, base.ClientRectangle.Right - int_right, y);
                }
                y = 0;

                for (int m = 0; m < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; m++)
                {
                    int Increaser = 5; //starting offset
                    for (int n = 0; n < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[m].PlotLines; n++)
                    {
                        brush = new SolidBrush(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[m].colors[n]);
                        pen = new Pen(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[m].colors[n], 1f);
                        y = this.method_7(m);
                        text = this.class10_settings_0.method_13(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[m].Sensors_0[n]);
                        width = (int)this.graphics_0.MeasureString(text, font).Width;
                        if (n != 0)
                        {
                            string lasttext = this.class10_settings_0.method_13(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[m].Sensors_0[n - 1]);
                            Increaser += (int)this.graphics_0.MeasureString(lasttext, font).Width + 25;
                        }
                        this.graphics_0.DrawString(text, font, new SolidBrush(Color.Black), (float)(base.ClientRectangle.Left + this.int_3 + Increaser) + 12, (float)(y + 2));
                        this.graphics_0.FillRectangle(brush, (base.ClientRectangle.Left + this.int_3 + Increaser), y + 5, 10, 10);
                        pen = new Pen(Color.Black, 1f);
                        this.graphics_0.DrawRectangle(pen, (base.ClientRectangle.Left + this.int_3 + Increaser), y + 5, 10, 10);
                        pen.Dispose();
                        brush.Dispose();
                    }
                }
                if (brush != null)
                {
                    brush.Dispose();
                }
                brush = null;
                if (font != null)
                {
                    font.Dispose();
                }
                font = null;
            }
        }

        private void method_13()
        {
            if (this.class17_0 == null)
            {
                return;
            }
            if (!IsConnectedOrLogging())
            {
                return;
            }
            Pen pen = new Pen(Color.LightGray, 1f)
            {
                DashStyle = DashStyle.Dash
            };
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            Font font = new Font("Lucida Sans", 7f);

            for (int i = 0; i < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; i++)
            {
                num = this.method_7(i) + 20;
                num2 = 0;
                for (int j = (int)this.PlotStart; j < ((int)this.PlotEnd); j++)
                {
                    int num6 = (int)((this.PlotEnd - this.PlotStart) / 8f);
                    if (num6 <= 0)
                    {
                        num6 = 1;
                    }
                    if ((j % num6) == 0)
                    {
                        num3 = this.int_3 + ((int)Math.Abs((float)(((this.method_5() - int_right) * (this.PlotStart - j)) / (this.PlotEnd - this.PlotStart))));
                        this.graphics_0.DrawLine(pen, num3, num + 1, num3, (num + this.method_6()) - 1);
                        if (i == (this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt - 1))
                        {
                            string s = this.method_8((long)this.class17_0.method_77(SensorsX.duration, j));

                            if (j == (int)this.PlotStart) num3 += (int)(this.graphics_0.MeasureString(s, font).Width / 2f);
                            if (j == ((int)this.PlotEnd) - 1) num3 -= (int)(this.graphics_0.MeasureString(s, font).Width / 2f);

                            this.graphics_0.DrawString(s, font, new SolidBrush(Color.Black), num3 - (this.graphics_0.MeasureString(s, font).Width / 2f), (float)(base.ClientRectangle.Bottom - 20));
                        }
                    }
                    num2++;
                }
            }
            pen.Dispose();
            pen = null;
            new Pen(Color.LightGray, 1f);
            Struct18[] structArray = null;
            try
            {
                if ((((int)this.PlotEnd) - ((int)this.PlotStart)) <= 0)
                {
                    goto Label_0519;
                }
                int num7 = 0;
                for (int k = 0; k < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; k++)
                {
                    for (int num9 = 0; num9 < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[k].PlotLines; num9++)
                    {
                        num7++;
                    }
                }
                structArray = new Struct18[num7];
                int index = 0;
                int num11 = (((int)this.PlotEnd) - ((int)this.PlotStart)) / ((this.method_5()) * 3);
                if (num11 == 0)
                {
                    num11 = 1;
                }
                int num12 = ((((int)this.PlotEnd) - ((int)this.PlotStart)) / num11);
                for (int m = 0; m < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; m++)
                {
                    for (int num14 = 0; num14 < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[m].PlotLines; num14++)
                    {
                        structArray[index].point_0 = new Point[num12 + 1];
                        structArray[index].pen_0 = new Pen(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[m].colors[num14], 1f);
                        index++;
                    }
                }
                index = 0;
                int num15 = 0;
                try
                {
                    for (int num16 = (int)this.PlotStart; num16 <= ((int)this.PlotEnd); num16 += num11)
                    {
                        index = 0;
                        if (num15 >= structArray[index].point_0.Length)
                        {
                            goto Label_0439;
                        }
                        for (int num17 = 0; num17 < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; num17++)
                        {
                            for (int num18 = 0; num18 < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[num17].PlotLines; num18++)
                            {
                                SensorsX sensors = this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[num17].Sensors_0[num18];
                                this.method_11(structArray[index].point_0, num15, num16, this.class17_0.method_77(sensors, num16), this.class17_0.method_80(sensors)[0], this.class17_0.method_80(sensors)[1], this.method_7(num17));
                                index++;
                            }
                        }
                        num15++;
                    }
                }
                catch (Exception)
                {
                }
                Label_0439:
                index = 0;
                for (int n = 0; n < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; n++)
                {
                    for (int num20 = 0; num20 < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[n].PlotLines; num20++)
                    {
                        this.graphics_0.DrawLines(structArray[index].pen_0, structArray[index].point_0);
                        index++;
                    }
                }
            }
            catch (Exception)
            {
            }
            if (structArray != null)
            {
                for (int num21 = 0; num21 < structArray.Length; num21++)
                {
                    if (structArray[num21].pen_0 != null)
                    {
                        structArray[num21].pen_0.Dispose();
                    }
                    structArray[num21].pen_0 = null;
                    structArray[num21].point_0 = null;
                }
            }
        Label_0519:
            if (font != null)
            {
                font.Dispose();
            }
            if (pen != null)
            {
                pen.Dispose();
            }
            GC.Collect();
        }

        private void method_15(Graphics paintEventArgs_0)
        {
            if ((this.PlotCursor >= this.PlotStart) && (this.PlotCursor <= this.PlotEnd))
            {
                Pen pen = new Pen(Color.Black, 1f)
                {
                    DashStyle = DashStyle.Custom,
                    DashPattern = new float[] { 12f, 8f }
                };
                Font font = new Font("Lucida Sans", 7f, FontStyle.Bold);
                SolidBrush brush = null;
                string s = string.Empty;
                if (this.PlotEnd == 0) this.PlotEnd = 1;
                int num = this.int_3 + ((int)Math.Abs((float)(((this.method_5() - 2 - int_right) * (this.PlotStart - this.PlotCursor)) / (this.PlotEnd - this.PlotStart))));
                for (int i = 0; i < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; i++)
                {
                    for (int j = 0; j < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].PlotLines; j++)
                    {
                        int num2 = this.method_7(i) + 20;
                        brush = new SolidBrush(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[j]);
                        paintEventArgs_0.DrawLine(pen, num, num2, num, num2 + this.method_6());
                        s = this.class17_0.method_79(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[j], this.PlotCursor).ToString();
                        paintEventArgs_0.DrawString(s, font, brush, (float)num, (float)(num2 + (j * 10)));
                        if (brush != null)
                        {
                            brush.Dispose();
                        }
                        brush = null;
                    }
                }
                pen.Dispose();
                pen = null;
                if (font != null)
                {
                    font.Dispose();
                }
                font = null;
                if (brush != null)
                {
                    brush.Dispose();
                }
                brush = null;
            }
        }

        private void method_16(Graphics paintEventArgs_0)
        {
            //paint markers ??
            foreach (Struct22 struct2 in this.class17_0.list_1)
            {
                if ((struct2.int_0 >= this.PlotStart) && (struct2.int_0 <= this.PlotEnd))
                {
                    Pen pen = new Pen(Color.DarkGray, 1f);
                    SolidBrush brush = null;
                    Pen pen2 = null;
                    Font font = new Font("Lucida Sans", 7f, FontStyle.Bold);
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 6f, 3f };
                    if (this.PlotEnd == 0) this.PlotEnd = 1;
                    int num = (int)((this.int_3 + 1f) + Math.Abs((float)(((this.method_5() - 1 - int_right) * (this.PlotStart - struct2.int_0)) / (this.PlotEnd - this.PlotStart))));
                    int num2 = 0;
                    string s = string.Empty;
                    bool flag = false;
                    for (int i = 0; i < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; i++)
                    {
                        flag = (struct2.string_0 != string.Empty) && (i == 0);
                        for (int j = 0; j < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].PlotLines; j++)
                        {
                            brush = new SolidBrush(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[j]);
                            pen2 = new Pen(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[j], 1f);
                            num2 = this.method_7(i) + 20;
                            s = this.class17_0.method_79(this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[j], struct2.int_0).ToString();
                            paintEventArgs_0.DrawString(s, font, brush, (float)num, (float)(num2 + (j * 10)));
                            paintEventArgs_0.DrawLine(pen, num, num2, num, num2 + this.method_6());
                            if (pen2 != null)
                            {
                                pen2.Dispose();
                            }
                            pen2 = null;
                            if (brush != null)
                            {
                                brush.Dispose();
                            }
                            brush = null;
                        }
                    }
                    pen.Dispose();
                    pen = null;
                    if (font != null)
                    {
                        font.Dispose();
                    }
                    font = null;
                }
            }
        }

        private void method_17()
        {
            if (!this.bool_3)
            {
                this.bool_3 = true;
                if (this.class16_u_0 == null)
                {
                    this.class16_u_0 = new Class16_u();
                }
                if (!this.class16_u_0.method_0())
                {
                    this.class16_u_0.method_1(base.CreateGraphics(), base.ClientRectangle.Width, base.ClientRectangle.Height);
                }
                if (this.class16_u_0.method_3() != null)
                {
                    this.graphics_0 = this.class16_u_0.method_3();
                    this.graphics_0.SmoothingMode = SmoothingMode.HighQuality;
                    this.graphics_0.FillRectangle(new SolidBrush(this.class10_settings_0.color_8), base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width, base.ClientRectangle.Height);
                    this.method_12();
                    this.method_13();
                    this.Refresh();
                }
                this.bool_3 = false;
            }
        }

        private void method_2()
        {
            this.method_17();
        }

        private bool IsConnectedOrLogging()
        {
            if ((this.class17_0 != null) && (this.class17_0.method_63_HasLogsFileOpen() || this.class17_0.method_34_GetConnected())) return true;
            else return false;
        }

        public void Next_Live_Plots()
        {
            if (this.struct_PosY != null)
            {
                for (int i = 1; i < this.class10_settings_0.LiveGraph_Lenght; i++)
                {
                    //int CurrentInner = i * NumberOfSensors;
                    int CurrentInner = 0;
                    for (int k = 0; k < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; k++)
                    {
                        for (int num9 = 0; num9 < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[k].PlotLines; num9++)
                        {
                            //int_0 = X position, int_1 = Y position
                            if (this.struct_PosY.Count > i && this.struct_Col.Count > i)
                            {
                                if (this.struct_PosY[i].Length > CurrentInner && this.struct_Col[i].Length > CurrentInner)
                                {
                                    this.struct_PosY[i - 1][CurrentInner] = this.struct_PosY[i][CurrentInner];
                                    this.struct_Col[i - 1][CurrentInner] = this.struct_Col[i][CurrentInner];
                                    CurrentInner++;
                                }
                            }
                        }
                    }
                }
            }

            this.CurrentFrame_Live--;
            //this.Refresh();
        }


        private void LogThis(string string_1)
        {
            this.class17_0.frmMain_0.LogThis("Datalog Graph - " + string_1);
        }

        private void method_3(Struct12 struct12_0)
        {
            if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && (DateTime.Now - LastCheck).TotalMilliseconds >= this.class10_settings_0.int_ActiveDatalog[1]))
            {
                LastCheck = DateTime.Now;
                if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[1]))
                {
                    if (IsConnectedOrLogging())
                    {
                        if (this.class17_0.method_34_GetConnected() && !this.class17_0.method_63_HasLogsFileOpen())
                        {
                            if (this.class10_settings_0.LiveGraphing)
                            {
                                NumberOfSensors = 0;

                                for (int k = 0; k < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; k++)
                                {
                                    for (int num9 = 0; num9 < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[k].PlotLines; num9++)
                                    {
                                        NumberOfSensors++;
                                    }
                                }

                                if (this.struct_PosY == null) ResetGraphStruct();

                                if (NumberOfFrames != this.class10_settings_0.LiveGraph_Lenght) ResetGraphStruct();
                                if (this.CurrentFrame_Live == this.class10_settings_0.LiveGraph_Lenght) this.Next_Live_Plots();

                                callfor23();
                            }
                        }
                        else
                        {
                            if (((int)struct12_0.long_5) < ((int)this.PlotStart))
                            {
                                float num = this.PlotStart - struct12_0.long_5;
                                if (num >= 0f)
                                {
                                    this.PlotStart = num;
                                    float num2 = this.PlotEnd - this.PlotStart;
                                    this.PlotEnd = this.PlotStart + num2;
                                }
                                else
                                {
                                    this.PlotStart = 0f;
                                    float num3 = this.PlotEnd - this.PlotStart;
                                    this.PlotEnd = this.PlotStart + num3;
                                }
                            }
                            else if (((int)struct12_0.long_5) > ((int)this.PlotEnd))
                            {
                                float plotEnd = this.PlotEnd;
                                float num5 = this.PlotEnd - this.PlotStart;
                                this.PlotEnd += num5;
                                this.PlotStart = plotEnd;
                            }
                        }
                        this.int_2 = (int)struct12_0.long_5;
                        //this.Refresh();
                        if (!this.class17_0.method_34_GetConnected()) this.Refresh();
                        else this.Invalidate();
                    }
                }
            }
        }

        private void ResetGraphStruct()
        {
            this.CurrentFrame_Live = 0;
            this.struct_PosX = new List<int[]>();
            this.struct_PosY = new List<int[]>();
            this.struct_Col = new List<Color[]>();
            NumberOfFrames = this.class10_settings_0.LiveGraph_Lenght;
        }

        public void ClearGraphStruct()
        {
            this.CurrentFrame_Live = 0;
            if (this.struct_PosX != null) this.struct_PosX.Clear();
            if (this.struct_PosY != null) this.struct_PosY.Clear();
            if (this.struct_Col != null) this.struct_Col.Clear();
            NumberOfFrames = this.class10_settings_0.LiveGraph_Lenght;
        }

        private void method_4(long long_0, string string_0)
        {
            if (IsConnectedOrLogging())
            {
                this.int_0 = 0;
                this.PlotEnd = (int)this.class17_0.method_65();
                this.PlotCursor = 0;
            }
            this.Refresh();
        }

        private int method_5()
        {
            return ((base.ClientSize.Width - this.int_3) - ((int)this.float_0));
        }

        private int method_6()
        {
            if (this.class10_settings_0 == null)
            {
                MessageBox.Show(Form.ActiveForm, "chartheight is null", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return (((base.ClientSize.Height - (2 * this.int_4)) - ((int)((this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt - 1f) * this.int_4))) / this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt);
        }

        private int method_7(int int_8)
        {
            if (this.class10_settings_0 == null)
            {
                MessageBox.Show(Form.ActiveForm, "ChartTop is null", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return (((base.ClientRectangle.Height - this.int_4) / this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt) * int_8);
        }

        private string RoundingMS(int MSTr)
        {
            string RStr = "00";
            try
            {
                if (MSTr >= 100)
                {
                    RStr = Math.Floor(MSTr / 10f).ToString();
                }
            }
            catch { }

            return RStr;
        }

        private string method_8(long long_0)
        {
            try
            {
                TimeSpan span = TimeSpan.FromMilliseconds((double)long_0);
                if (span.Minutes <= 0)
                {
                    return (span.Seconds.ToString("00") + "." + RoundingMS(span.Milliseconds));
                    //return (span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + "." + span.Milliseconds.ToString("00"));
                }
                else if (span.Minutes > 0 && span.Hours <= 0)
                {
                    return (span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + "." + RoundingMS(span.Milliseconds));
                }
                else if (span.Hours > 0)
                {
                    return (span.Hours.ToString("00") + ":" + span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00") + "." + RoundingMS(span.Milliseconds));
                }
            }
            catch { }
            return "";
        }

        private int method_9()
        {
            return (int)Math.Abs((float)(this.PlotStart + ((((this.int_7 - this.int_3) + 1f) / ((float)(this.method_5() - 2 - int_right))) * (this.PlotEnd - this.PlotStart))));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //if (this.graphics_0 != null) this.graphics_0.Dispose();

            if (this.class18_0 == null)
            {
                if (this.class10_settings_0 != null)
                {
                    this.graphics_0 = pe.Graphics;
                    this.graphics_0.FillRectangle(new SolidBrush(this.class10_settings_0.color_8), pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
                    this.method_12();
                }
            }
            else if ((!this.class18_0.method_30_HasFileLoadedInBMTune() || !this.class16_u_0.method_0()) || (!this.class17_0.method_63_HasLogsFileOpen() && !this.class17_0.method_34_GetConnected()))
            {
                this.graphics_0 = pe.Graphics;
                this.graphics_0.SmoothingMode = SmoothingMode.None;
                this.graphics_0.FillRectangle(new SolidBrush(this.class10_settings_0.color_8), pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
                this.method_12();
            }
            else if (this.class16_u_0.method_0())
            {
                this.class16_u_0.method_2(pe.Graphics);
                if (this.class17_0.method_34_GetConnected())
                {
                    if (this.class10_settings_0.LiveGraphing)
                    {
                        this.method_27(pe.Graphics);
                    }
                }
                else
                {
                    this.method_15(pe.Graphics);
                    this.method_16(pe.Graphics);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pe)
        {
        }

        public void setEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float num = this.method_9();
            this.PlotEnd = num;
            if (this.plotChangeDelegate_0 != null)
            {
                this.plotChangeDelegate_0();
            }
            this.Refresh();
        }

        public void setMarkerCurrentCursor()
        {
            Struct22 item = new Struct22
            {
                int_0 = this.PlotCursor,
                string_0 = string.Empty
            };
            this.class17_0.list_1.Add(item);
            this.Refresh();
        }

        public void setMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Struct22 item = new Struct22
            {
                int_0 = this.method_9(),
                string_0 = string.Empty
            };
            this.class17_0.list_1.Add(item);
            this.Refresh();
        }

        public void SetPlotStartEnd(int start, int end)
        {
            if (IsConnectedOrLogging())
            {
                if (start < 0)
                {
                    start = 0;
                }
                this.int_0 = start;
                if (end > this.class17_0.method_65())
                {
                    end = (int)this.class17_0.method_65();
                }
                this.int_1 = end;
                this.method_17();
            }
        }

        public void SetPlotStartEndZoomIn(int start, int end)
        {
            if (IsConnectedOrLogging())
            {
                this.int_0 += start;
                if (this.int_0 < 0)
                {
                    this.int_0 = 0;
                }
                this.int_1 -= end;
                if (this.int_1 > this.class17_0.method_65())
                {
                    this.int_1 = (int)this.class17_0.method_65();
                }
                this.method_17();
            }
        }

        public void SetPlotStartEndZoomOut(int start, int end)
        {
            if (IsConnectedOrLogging())
            {
                this.int_0 -= start;
                if (this.int_0 < 0)
                {
                    this.int_0 = 0;
                }
                this.int_1 += end;
                if (this.int_1 > this.class17_0.method_65())
                {
                    this.int_1 = (int)this.class17_0.method_65();
                }
                this.method_17();
            }
        }

        public void setStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float num = this.method_9();
            this.PlotStart = num;
            if (this.plotChangeDelegate_0 != null)
            {
                this.plotChangeDelegate_0();
            }
            this.Refresh();
        }

        public void zoomFullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.float_1 = 1f;
            this.PlotEnd = this.class17_0.method_65();
            this.PlotStart = 0f;
            if (this.plotChangeDelegate_0 != null)
            {
                this.plotChangeDelegate_0();
            }
            this.Refresh();
        }

        public void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float num = 1f;
            float num2 = 1f;
            this.float_2 = 8f;
            if ((this.PlotCursor >= this.PlotStart) && (this.PlotCursor <= this.PlotEnd))
            {
                num = (this.PlotCursor - this.PlotStart) / (this.PlotEnd - this.PlotStart);
                num2 = (this.PlotEnd - this.PlotCursor) / (this.PlotEnd - this.PlotStart);
            }
            float plotStart = this.PlotStart;
            float plotEnd = this.PlotEnd;
            this.SetPlotStartEndZoomIn((int)((((float)(((int)this.PlotEnd) - ((int)this.PlotStart))) / (this.float_2 * this.float_1)) * num), (int)((((float)(((int)this.PlotEnd) - ((int)this.PlotStart))) / (this.float_2 * this.float_1)) * num2));
            if ((this.PlotEnd - this.PlotStart) < 200f)
            {
                this.SetPlotStartEnd((int)plotStart, (int)plotEnd);
            }
            if (this.PlotStart < 0f)
            {
                this.PlotStart = 0f;
            }
            if (this.PlotEnd > this.class17_0.method_65())
            {
                this.PlotEnd = this.class17_0.method_65();
            }
            if (this.plotChangeDelegate_0 != null)
            {
                this.plotChangeDelegate_0();
            }
            this.float_1 *= 0.85f;
            if (this.float_1 < 0.15f)
            {
                this.float_1 = 0.15f;
            }
            this.Refresh();
        }

        public void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float num = 1f;
            float num2 = 1f;
            this.float_2 = 8f;
            if ((this.PlotCursor >= this.PlotStart) && (this.PlotCursor <= this.PlotEnd))
            {
                num = (this.PlotCursor - this.PlotStart) / (this.PlotEnd - this.PlotStart);
                num2 = (this.PlotEnd - this.PlotCursor) / (this.PlotEnd - this.PlotStart);
            }
            this.SetPlotStartEndZoomOut((int)((((float)(((int)this.PlotEnd) - ((int)this.PlotStart))) / (this.float_2 * this.float_1)) * num), (int)((((float)(((int)this.PlotEnd) - ((int)this.PlotStart))) / (this.float_2 * this.float_1)) * num2));
            if (this.PlotStart < 0f)
            {
                this.PlotStart = 0f;
            }
            if (this.PlotEnd > this.class17_0.method_65())
            {
                this.PlotEnd = this.class17_0.method_65();
            }
            if (this.plotChangeDelegate_0 != null)
            {
                this.plotChangeDelegate_0();
            }
            this.float_1 *= 1.05f;
            if (this.float_1 > 1f)
            {
                this.float_1 = 1f;
            }
            this.Refresh();
        }

        public float LogScale
        {
            get
            {
                return this.float_1;
            }
        }

        public int PlotCursor
        {
            get
            {
                return this.int_2;
            }
            set
            {
                if (IsConnectedOrLogging())
                {
                    if (value < this.PlotStart)
                    {
                        float num = this.PlotEnd - this.PlotStart;
                        this.PlotStart -= num;
                        this.PlotEnd -= num;
                    }
                    else if (value > this.PlotEnd)
                    {
                        float plotEnd = this.PlotEnd;
                        float num3 = this.PlotEnd - this.PlotStart;
                        this.PlotEnd += num3;
                        this.PlotStart = plotEnd;
                    }
                    this.class17_0.method_69((long)value);
                }
            }
        }

        public float PlotEnd
        {
            get
            {
                return (float)this.int_1;
            }
            set
            {
                if (IsConnectedOrLogging())
                {
                    if (value > this.class17_0.method_65())
                    {
                        value = this.class17_0.method_65();
                    }
                    if ((this.int_1 != 0) && ((this.int_1 - this.int_0) <= 20))
                    {
                        if (this.class17_0.method_63_HasLogsFileOpen()) this.method_17();
                    }
                    else
                    {
                        this.int_1 = (int)value;
                        if (this.class17_0.method_63_HasLogsFileOpen()) this.method_17();
                    }
                }
            }
        }

        public float PlotStart
        {
            get
            {
                return (float)this.int_0;
            }
            set
            {
                if (IsConnectedOrLogging())
                {
                    if (value < 0f)
                    {
                        value = 0f;
                    }
                    if ((this.int_1 - this.int_0) <= 20)
                    {
                        if (this.class17_0.method_63_HasLogsFileOpen()) this.method_17();
                    }
                    else
                    {
                        this.int_0 = (int)value;
                        if (this.class17_0.method_63_HasLogsFileOpen()) this.method_17();
                    }
                }
            }
        }

        public delegate void plotChangeDelegate();

        public delegate void plotCursorChangeDelegate(int cursor);

        public delegate void requestEditTemplateDelegate();

        //#################################################################################################
        
        private void callfor23()
        {
            custom_value_int = 17596;
            custom_value_float = -9.68779f;

            CurrentSensor_Live = 0;
            CurrentGraph_Live = 0;
            
            this.struct_PosX.Add(new int[NumberOfSensors]);
            this.struct_PosY.Add(new int[NumberOfSensors]);
            this.struct_Col.Add(new Color[NumberOfSensors]);


            for (int i = 0; i < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartsEnableCnt; i++)
            {
                CurrentGraph_Live = i;
                //CurrentSensor_Live = 0;
                for (int k = 0; k < this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].PlotLines; k++)
                {
                    SensorsX sensors_0 = this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[k];
                    CallSensors(sensors_0);

                    if (custom_value_int != 17596) this.method_23_int(custom_value_int, int.Parse(this.class10_settings_0.method_24(sensors_0, "customMin")), int.Parse(this.class10_settings_0.method_24(sensors_0, "customMax")));
                    else if (custom_value_float != -9.68779f) this.method_23_float(custom_value_float, float.Parse(this.class10_settings_0.method_24(sensors_0, "customMin")), float.Parse(this.class10_settings_0.method_24(sensors_0, "customMax")));

                    this.struct_Col[this.CurrentFrame_Live][this.CurrentSensor_Live] = this.class10_settings_0.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[k];

                    this.CurrentSensor_Live++;
                    custom_value_int = 17596;
                    custom_value_float = -9.68779f;
                }
            }

            CurrentGraph_Live = 0;
            this.CurrentFrame_Live++;
        }

        private void method_23_int(int Valuee, int Minn, int Maxx)
        {
            int TopPos = (this.method_7(CurrentGraph_Live) + 20);
            int BottomPos = TopPos + this.method_6();
            int numY = BottomPos - ((int)((this.method_6() * (Valuee - Minn)) / (Maxx - Minn)));
            //Reset maximal value
            if (numY < TopPos) numY = TopPos;
            if (numY > BottomPos) numY = BottomPos;

            float PercentT = (float) (this.CurrentFrame_Live * 100f) / this.class10_settings_0.LiveGraph_Lenght;
            int numX = (int)((this.int_3 + 1f) + Math.Abs((float)(((this.method_5() - 1 - int_right) * (PercentT / 100)))));

            this.struct_PosX[this.CurrentFrame_Live][this.CurrentSensor_Live] = numX;
            this.struct_PosY[this.CurrentFrame_Live][this.CurrentSensor_Live] = numY;
            //this.CurrentSensor_Live++;
        }

        private void method_23_float(float Valuee, float Minn, float Maxx)
        {
            int TopPos = (this.method_7(CurrentGraph_Live) + 20);
            int BottomPos = TopPos + this.method_6();
            int numY = BottomPos - ((int)((this.method_6() * (Valuee - Minn)) / (Maxx - Minn)));
            //Reset maximal value
            if (numY < TopPos) numY = TopPos;
            if (numY > BottomPos) numY = BottomPos;

            float PercentT = (float)(this.CurrentFrame_Live * 100f) / this.class10_settings_0.LiveGraph_Lenght;
            int numX = (int)((this.int_3 + 1f) + Math.Abs((float)(((this.method_5() - 1 - int_right) * (PercentT/100)))));

            this.struct_PosX[this.CurrentFrame_Live][this.CurrentSensor_Live] = numX;
            this.struct_PosY[this.CurrentFrame_Live][this.CurrentSensor_Live] = numY;
            //this.CurrentSensor_Live++;
        }

        private void method_27(Graphics paintEventArgs_0)
        {
            Pen pen = new Pen(this.class10_settings_0.color_12, 2f);
            if (CurrentFrame_Live > 2)
            {
                for (int i = 0; i < (this.CurrentFrame_Live - 1); i++)
                {
                    for (int k = 0; k < NumberOfSensors; k++)
                    {
                        if (this.struct_Col.Count > i)
                        {
                            if (this.struct_Col[i].Length > k)
                            {
                                pen = new Pen(this.struct_Col[i][k], 1f);
                                paintEventArgs_0.DrawLine(pen, this.struct_PosX[i][k], this.struct_PosY[i][k], this.struct_PosX[i + 1][k], this.struct_PosY[i + 1][k]);
                            }
                        }
                    }
                }
            }
            LastShown = CurrentFrame_Live - 1; //unused
            pen.Dispose();
            pen = null;
        }

        private void CallSensors(SensorsX sensors_0)
        {
            switch (sensors_0)
            {
                case SensorsX.rpmX:
                    this.method_10(SensorsX.rpmX);
                    break;
                case SensorsX.ectX:
                    this.method_9(SensorsX.ectX);
                    break;
                case SensorsX.iatX:
                    this.method_9(SensorsX.iatX);
                    break;
                case SensorsX.tpsX:
                    this.method_9(SensorsX.tpsX);
                    break;
                case SensorsX.tpsV:
                    this.method_9(SensorsX.tpsV);
                    break;
                case SensorsX.ignFnl:
                    this.method_9(SensorsX.ignFnl);
                    break;
                case SensorsX.ignTbl:
                    this.method_9(SensorsX.ignTbl);
                    break;
                case SensorsX.vssX:
                    this.method_9(SensorsX.vssX);
                    break;
                case SensorsX.gearX:
                    this.method_9(SensorsX.gearX);
                    break;
                case SensorsX.injFV:
                    this.method_10(SensorsX.injFV);
                    break;
                case SensorsX.injDur:
                    this.method_10(SensorsX.injDur);
                    break;
                case SensorsX.injDuty:
                    this.method_10(SensorsX.injDuty);
                    break;
                case SensorsX.ecuO2V:
                    this.method_9(SensorsX.ecuO2V);
                    break;
                case SensorsX.wbO2V:
                    this.method_9(SensorsX.wbO2V);
                    break;
                case SensorsX.afr:
                    this.method_9(SensorsX.afr);
                    break;
                case SensorsX.mapV:
                    this.method_9(SensorsX.mapV);
                    break;
                case SensorsX.mapX:
                    this.method_9(SensorsX.mapX);
                    break;
                case SensorsX.boostX:
                    this.method_9(SensorsX.boostX);
                    break;
                case SensorsX.paX:
                    this.method_9(SensorsX.paX);
                    break;
                case SensorsX.frame:
                    this.method_10(SensorsX.frame);
                    break;
                case SensorsX.interval:
                    this.method_10(SensorsX.interval);
                    break;
                case SensorsX.duration:
                    this.method_10(SensorsX.duration);
                    break;
                case SensorsX.mil:
                    this.method_9(SensorsX.mil);
                    break;
                case SensorsX.batV:
                    this.method_9(SensorsX.batV);
                    break;
                case SensorsX.eldV:
                    this.method_9(SensorsX.eldV);
                    break;
                case SensorsX.outAc:
                    this.method_9(SensorsX.outAc);
                    break;
                case SensorsX.outPurge:
                    this.method_9(SensorsX.outPurge);
                    break;
                case SensorsX.outFanc:
                    this.method_9(SensorsX.outFanc);
                    break;
                case SensorsX.outFpump:
                    this.method_9(SensorsX.outFpump);
                    break;
                case SensorsX.outIab:
                    this.method_9(SensorsX.outIab);
                    break;
                case SensorsX.outAltCtrl:
                    this.method_9(SensorsX.outAltCtrl);
                    break;
                case SensorsX.outVtsX:
                    this.method_9(SensorsX.outVtsX);
                    break;
                case SensorsX.outMil:
                    this.method_9(SensorsX.outMil);
                    break;
                case SensorsX.outO2h:
                    this.method_9(SensorsX.outO2h);
                    break;
                case SensorsX.outVtsM:
                    this.method_9(SensorsX.outVtsM);
                    break;
                case SensorsX.inVtsFeedBack:
                    this.method_9(SensorsX.inVtsFeedBack);
                    break;
                case SensorsX.outFuelCut:
                    this.method_9(SensorsX.outFuelCut);
                    break;
                case SensorsX.inAccs:
                    this.method_9(SensorsX.inAccs);
                    break;
                case SensorsX.inVtp:
                    this.method_9(SensorsX.inVtp);
                    break;
                case SensorsX.inStartS:
                    this.method_9(SensorsX.inStartS);
                    break;
                case SensorsX.inBksw:
                    this.method_9(SensorsX.inBksw);
                    break;
                case SensorsX.inParkN:
                    this.method_9(SensorsX.inParkN);
                    break;
                case SensorsX.inAtShift1:
                    this.method_9(SensorsX.inAtShift1);
                    break;
                case SensorsX.inAtShift2:
                    this.method_9(SensorsX.inAtShift2);
                    break;
                case SensorsX.inPsp:
                    this.method_9(SensorsX.inPsp);
                    break;
                case SensorsX.inSCC:
                    this.method_9(SensorsX.inSCC);
                    break;
                case SensorsX.postFuel:
                    this.method_9(SensorsX.postFuel);
                    break;
                case SensorsX.ectFc:
                    this.method_9(SensorsX.ectFc);
                    break;
                case SensorsX.o2Short:
                    this.method_10(SensorsX.o2Short);
                    break;
                case SensorsX.o2Long:
                    this.method_10(SensorsX.o2Long);
                    break;
                case SensorsX.iatFc:
                    this.method_10(SensorsX.iatFc);
                    break;
                case SensorsX.veFc:
                    this.method_9(SensorsX.veFc);
                    break;
                case SensorsX.iatIc:
                    this.method_9(SensorsX.iatIc);
                    break;
                case SensorsX.ectIc:
                    this.method_9(SensorsX.ectIc);
                    break;
                case SensorsX.gearIc:
                    this.method_9(SensorsX.gearIc);
                    break;
                case SensorsX.gearFc:
                    this.method_9(SensorsX.gearFc);
                    break;
                case SensorsX.ftsClutchInput:
                    this.method_9(SensorsX.ftsClutchInput);
                    break;
                case SensorsX.ftlInput:
                    this.method_9(SensorsX.ftlInput);
                    break;
                case SensorsX.gpo1_in:
                    this.method_9(SensorsX.gpo1_in);
                    break;
                case SensorsX.gpo2_in:
                    this.method_9(SensorsX.gpo2_in);
                    break;
                case SensorsX.gpo3_in:
                    this.method_9(SensorsX.gpo3_in);
                    break;
                case SensorsX.bstInput:
                    this.method_9(SensorsX.bstInput);
                    break;
                case SensorsX.ftlActive:
                    this.method_9(SensorsX.ftlActive);
                    break;
                case SensorsX.ftsActive:
                    this.method_9(SensorsX.ftsActive);
                    break;
                case SensorsX.antilagActive:
                    this.method_9(SensorsX.antilagActive);
                    break;
                case SensorsX.boostcutActive:
                    this.method_9(SensorsX.boostcutActive);
                    break;
                case SensorsX.ignitionCut:
                    this.method_9(SensorsX.ignitionCut);
                    break;
                case SensorsX.sccChecker:
                    this.method_9(SensorsX.sccChecker);
                    break;
                case SensorsX.gpo1_out:
                    this.method_9(SensorsX.gpo1_out);
                    break;
                case SensorsX.gpo2_out:
                    this.method_9(SensorsX.gpo2_out);
                    break;
                case SensorsX.gpo3_out:
                    this.method_9(SensorsX.gpo3_out);
                    break;
                case SensorsX.bstStage2:
                    this.method_9(SensorsX.bstStage2);
                    break;
                case SensorsX.bstStage3:
                    this.method_9(SensorsX.bstStage3);
                    break;
                case SensorsX.bstStage4:
                    this.method_9(SensorsX.bstStage4);
                    break;
                case SensorsX.overheatActive:
                    this.method_9(SensorsX.overheatActive);
                    break;
                case SensorsX.leanProtection:
                    this.method_9(SensorsX.leanProtection);
                    break;
                case SensorsX.fanCtrl:
                    this.method_9(SensorsX.fanCtrl);
                    break;
                case SensorsX.bstActive:
                    this.method_9(SensorsX.bstActive);
                    break;
                case SensorsX.secMaps:
                    this.method_9(SensorsX.secMaps);
                    break;
                case SensorsX.ebcActive:
                    this.method_9(SensorsX.ebcActive);
                    break;
                case SensorsX.ebcInput:
                    this.method_9(SensorsX.ebcInput);
                    break;
                case SensorsX.ebcHiInput:
                    this.method_9(SensorsX.ebcHiInput);
                    break;
                case SensorsX.ebcDutyX:
                    this.method_9(SensorsX.ebcDutyX);
                    break;
                case SensorsX.ebcBaseDuty:
                    this.method_9(SensorsX.ebcBaseDuty);
                    break;
                case SensorsX.ebcCurrent:
                    this.method_9(SensorsX.ebcCurrent);
                    break;
                case SensorsX.ebcTarget:
                    this.method_9(SensorsX.ebcTarget);
                    break;
                case SensorsX.analog1:
                    this.method_9(SensorsX.analog1);
                    break;
                case SensorsX.analog2:
                    this.method_9(SensorsX.analog2);
                    break;
                case SensorsX.analog3:
                    this.method_9(SensorsX.analog3);
                    break;

                //##################################################################
                case SensorsX.fuelUsage:
                    this.method_9(SensorsX.fuelUsage);
                    break;
                case SensorsX.accelTime:
                    this.method_9(SensorsX.accelTime);
                    break;
                case SensorsX.flexFuel:
                    this.method_9(SensorsX.flexFuel);
                    break;
                case SensorsX.ectV:
                    this.method_9(SensorsX.ectV);
                    break;
                case SensorsX.iatV:
                    this.method_9(SensorsX.iatV);
                    break;

                default:
                    return;
            }
        }

        private void method_9(SensorsX sensors_0)
        {
            switch (sensors_0)
            {
                case SensorsX.vssX:
                    custom_value_int = this.Class33_Sensors_0.VSS;
                    return;

                case SensorsX.gearX:
                    custom_value_int = this.Class33_Sensors_0.Gear;
                    return;

                case SensorsX.mapX:
                    custom_value_float = (float) this.Class33_Sensors_0.Map;
                    return;

                case SensorsX.boostX:
                    custom_value_float = (float)this.Class33_Sensors_0.Boost;
                    return;

                case SensorsX.paX:
                    custom_value_int = this.Class33_Sensors_0.PA;
                    return;

                case SensorsX.tpsX:
                    custom_value_int = this.Class33_Sensors_0.TPS;
                    return;

                case SensorsX.tpsV:
                    custom_value_float = (float)this.Class33_Sensors_0.TPSV;
                    return;

                case SensorsX.ignFnl:
                    custom_value_float = (float)this.Class33_Sensors_0.IgnFinal;
                    return;

                case SensorsX.ignTbl:
                    custom_value_float = (float)this.Class33_Sensors_0.IgnTable;
                    return;

                case SensorsX.ectX:
                    custom_value_float = (float)this.Class33_Sensors_0.ECT;
                    return;

                case SensorsX.iatX:
                    custom_value_float = (float)this.Class33_Sensors_0.IAT;
                    return;

                case SensorsX.afr:
                    custom_value_float = (float)this.Class33_Sensors_0.AFR;
                    return;

                case SensorsX.ecuO2V:
                    custom_value_float = (float)this.Class33_Sensors_0.EcuO2V;
                    return;

                case SensorsX.wbO2V:
                    custom_value_float = (float)this.Class33_Sensors_0.WBV;
                    return;

                case SensorsX.batV:
                    custom_value_float = (float)this.Class33_Sensors_0.BatV;
                    return;

                case SensorsX.eldV:
                    custom_value_float = (float)this.Class33_Sensors_0.ELDV;
                    return;

                case SensorsX.knockV:
                    custom_value_float = (float)this.Class33_Sensors_0.KnockV;
                    return;

                case SensorsX.mapV:
                    custom_value_float = (float)this.Class33_Sensors_0.MapV;
                    return;

                case SensorsX.mil:
                    if (this.Class33_Sensors_0.MIL) custom_value_int = 1;
                    else custom_value_int = 0;
                    //custom_value_int = byte_0;
                    return;

                case SensorsX.ectFc:
                    custom_value_float = (float)this.Class33_Sensors_0.ECTFc;
                    return;

                case SensorsX.veFc:
                    custom_value_float = (float)this.Class33_Sensors_0.VEFc;
                    return;

                case SensorsX.ectIc:
                    custom_value_float = (float)this.Class33_Sensors_0.ECTIc;
                    return;

                case SensorsX.iatIc:
                    custom_value_float = (float)this.Class33_Sensors_0.IATIc;
                    return;

                case SensorsX.gearIc:
                    custom_value_float = (float)this.Class33_Sensors_0.GearIc;
                    return;

                case SensorsX.gearFc:
                    custom_value_float = (float)this.Class33_Sensors_0.GearFc;
                    return;

                case SensorsX.postFuel:
                    if (this.Class33_Sensors_0.PostFuel) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outIab:
                    if (this.Class33_Sensors_0.OutIAB) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outVtsX:
                    if (this.Class33_Sensors_0.OutVTS) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outVtsM:
                    if (this.Class33_Sensors_0.OutVTSM) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outAc:
                    if (this.Class33_Sensors_0.OutAC) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outO2h:
                    if (this.Class33_Sensors_0.OutO2H) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outMil:
                    if (this.Class33_Sensors_0.OutMIL) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outPurge:
                    if (this.Class33_Sensors_0.OutPurge) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outFanc:
                    if (this.Class33_Sensors_0.OutFanC) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outFpump:
                    if (this.Class33_Sensors_0.OutFPump) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outFuelCut:
                    if (this.Class33_Sensors_0.OutFCut) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.outAltCtrl:
                    if (this.Class33_Sensors_0.OutAltCtrl) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inPsp:
                    if (this.Class33_Sensors_0.InPSP) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inSCC:
                    if (this.Class33_Sensors_0.InSCC) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inAccs:
                    if (this.Class33_Sensors_0.InACCs) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inBksw:
                    if (this.Class33_Sensors_0.InBKSW) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inVtp:
                    if (this.Class33_Sensors_0.InVTP) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inVtsFeedBack:
                    if (this.Class33_Sensors_0.InVTSFB) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inParkN:
                    if (this.Class33_Sensors_0.InParkN) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inStartS:
                    if (this.Class33_Sensors_0.InStartS) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inAtShift1:
                    if (this.Class33_Sensors_0.InATShift1) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.inAtShift2:
                    if (this.Class33_Sensors_0.InATShift2) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.secMaps:
                    if (this.Class33_Sensors_0.SecMap) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ftlInput:
                    if (this.Class33_Sensors_0.InFTL) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ftlActive:
                    if (this.Class33_Sensors_0.ActiveFTL) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ftsClutchInput:
                    if (this.Class33_Sensors_0.InFTS) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ftsActive:
                    if (this.Class33_Sensors_0.ActiveFTS) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.boostcutActive:
                    if (this.Class33_Sensors_0.ActiveBstCut) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.overheatActive:
                    if (this.Class33_Sensors_0.ActiveOverHeat) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.antilagActive:
                    if (this.Class33_Sensors_0.ActiveAntilag) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ignitionCut:
                    if (this.Class33_Sensors_0.ICut) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.sccChecker:
                    if (this.Class33_Sensors_0.SCCChecker) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ebcInput:
                    if (this.Class33_Sensors_0.InEBC) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ebcHiInput:
                    if (this.Class33_Sensors_0.InEBCHi) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ebcActive:
                    if (this.Class33_Sensors_0.ActiveEBC) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.ebcBaseDuty:
                    custom_value_float = (float)this.Class33_Sensors_0.EBCBaseDuty;
                    return;

                case SensorsX.ebcDutyX:
                    custom_value_float = (float)this.Class33_Sensors_0.EBCDuty;
                    return;

                case SensorsX.ebcTarget:
                    custom_value_float = (float)this.Class33_Sensors_0.EBCTarget;
                    return;

                case SensorsX.ebcCurrent:
                    custom_value_float = (float)this.Class33_Sensors_0.EBCCurrent;
                    return;

                case SensorsX.gpo1_in:
                    if (this.Class33_Sensors_0.InGPO1) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.gpo1_out:
                    if (this.Class33_Sensors_0.OutGPO1) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.gpo2_in:
                    if (this.Class33_Sensors_0.InGPO2) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.gpo2_out:
                    if (this.Class33_Sensors_0.OutGPO2) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.gpo3_in:
                    if (this.Class33_Sensors_0.InGPO3) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.gpo3_out:
                    if (this.Class33_Sensors_0.OutGPO3) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.fanCtrl:
                    if (this.Class33_Sensors_0.FanC) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.bstStage2:
                    if (this.Class33_Sensors_0.BSTS2) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.bstStage3:
                    if (this.Class33_Sensors_0.BSTS3) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.bstStage4:
                    if (this.Class33_Sensors_0.BSTS4) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.bstActive:
                    if (this.Class33_Sensors_0.ActiveBST) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.bstInput:
                    if (this.Class33_Sensors_0.InBST) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.leanProtection:
                    if (this.Class33_Sensors_0.LeanProtect) custom_value_int = 1;
                    else custom_value_int = 0;
                    return;

                case SensorsX.fuelUsage:
                    custom_value_float = (float)this.Class33_Sensors_0.FuelUsage;
                    return;
                case SensorsX.accelTime:
                    custom_value_float = (float)this.Class33_Sensors_0.AccelTime;
                    return;
                case SensorsX.flexFuel:
                    custom_value_float = (float)this.Class33_Sensors_0.FlexFuel;
                    return;
                case SensorsX.ectV:
                    custom_value_float = (float)this.Class33_Sensors_0.ECTV;
                    return;
                case SensorsX.iatV:
                    custom_value_float = (float)this.Class33_Sensors_0.IATV;
                    return;

                default:
                    return;
            }
        }

        private void method_10(SensorsX sensors_0)
        {
            switch (sensors_0)
            {
                case SensorsX.rpmX:
                    custom_value_int = this.Class33_Sensors_0.RPM;
                    return;

                case SensorsX.injDur:
                    custom_value_float = (float)this.Class33_Sensors_0.InjDurr;
                    return;

                case SensorsX.injDuty:
                    custom_value_float = (float)this.Class33_Sensors_0.InjDuty;
                    return;

                case SensorsX.injFV:
                    custom_value_float = (float)this.Class33_Sensors_0.InjFV;
                    return;

                case SensorsX.frame:
                    custom_value_int = (int)this.Class33_Sensors_0.Frame;
                    return;

                case SensorsX.duration:
                    custom_value_float = float.Parse(this.Class33_Sensors_0.Duration);
                    break;

                case SensorsX.interval:
                    custom_value_int = (int)this.Class33_Sensors_0.Interval;
                    return;

                case SensorsX.iatFc:
                    custom_value_float = (float)this.Class33_Sensors_0.IATFC;
                    return;

                case SensorsX.o2Short:
                    custom_value_float = (float)this.Class33_Sensors_0.O2Short;
                    return;

                case SensorsX.o2Long:
                    custom_value_float = (float)this.Class33_Sensors_0.O2Long;
                    return;

                default:
                    return;
            }
        }
    }
}

