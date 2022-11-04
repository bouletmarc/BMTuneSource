using Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

internal class ctrlPlotGraph : UserControl
{
    private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();
    private Brush brush_0;
    private Class10_settings class10_0;
    private Class16_u class16_u_0 = new Class16_u();
    private Class33_Sensors class33_Sensors_0;
    private Class18 class18_0;
    private Class7_u[,] class7_u_0;
    private ToolStripMenuItem clearPlotsToolStripMenuItem1;
    private Color[] color_0 = new Color[4];
    private float float_0;
    private float float_1;
    private float float_2;
    private float float_4;
    private Graphics graphics_0;
    private IContainer icontainer_0;
    private int int_0;
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
    private List<Class7_u> list_0 = new List<Class7_u>();
    public MapGraphType mapGraphType_0;
    private PointF[] pointF_0 = new PointF[4];
    private Struct19[] struct19_0;
    private List<Struct12> Struct12_list_0;
    private Struct19[,] struct19_2;

    private int Last_Used_Sensor = 0;

    private int Cint_Colomn = 14;
    private int Cint_Sensor = 0;

    private int custom_value_int;
    private float custom_value_float;

    public ctrlPlotGraph()
    {
        this.InitializeComponent();
    }

    private void clearPlotsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        this.method_17();
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
                    for (int i = 0; i < this.class10_0.int_5; i++)
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
            this.Refresh();
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
            // ctrlPlotGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlPlotGraph";
            this.Size = new System.Drawing.Size(126, 112);
            this.Load += new System.EventHandler(this.ctrlMapGraph_Load);
            this.Resize += new System.EventHandler(this.ctrlMapGraph_Resize);
            this.ResumeLayout(false);

    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1)
    {
        try
        {
            this.class18_0 = class18_1;
            this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
            this.class10_0 = class10_1;
            this.class10_0.delegate14_0 += new Class10_settings.Delegate14(this.method_1);

            this.class33_Sensors_0 = this.class18_0.class17_0.class33_Sensors;

            foreach (Control control in base.Controls)
            {
                float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
                control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
            }

            this.Refresh();
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

    private void method_12(string string_0, float float_28, float float_29, bool bool_5)
    {
        if (bool_5)
        {
            this.graphics_0.FillRectangle(new SolidBrush(Color.LightGreen), (float) (float_28 - 5f), (float) (float_29 - 20f), (float) 35f, (float) 15f);
        }
        else
        {
            this.graphics_0.FillRectangle(new SolidBrush(Color.Red), (float) (float_28 - 5f), (float) (float_29 - 20f), (float) 35f, (float) 15f);
        }
        this.graphics_0.DrawString(string_0, new Font("Lucida Sans", 7f, FontStyle.Regular), new SolidBrush(this.class10_0.color_11), (float) (float_28 - 5f), (float) (float_29 - 20f));
    }

    private void method_13(string string_0, float float_28, float float_29)
    {
        this.graphics_0.FillRectangle(new SolidBrush(Color.White), (float) (float_28 - 5f), (float) (float_29 - 20f), (float) (this.graphics_0.MeasureString(string_0, new Font("Lucida Sans", 7f, FontStyle.Regular)).Width + 2f), (float) 15f);
        this.graphics_0.DrawString(string_0, new Font("Lucida Sans", 7f, FontStyle.Regular), new SolidBrush(this.class10_0.color_11), (float) (float_28 - 5f), (float) (float_29 - 20f));
    }

    public void Reset_Struct_Sensor()
    {
        if (this.struct19_0 == null) this.struct19_0 = new Struct19[this.class10_0.int_5];

        if (this.Struct12_list_0 != null)
        {
            while (this.Struct12_list_0.Count > this.class10_0.int_5) this.Struct12_list_0.RemoveAt(0);

            this.int_6 = 0;

            for (int i = 0; i < this.Struct12_list_0.Count; i++)
            {
                if (this.mapGraphType_0 == MapGraphType.timePlot)
                    this.method_23(this.class10_0.int_5, this.Struct12_list_0[i].byte_43, (float)this.class18_0.method_200(this.Struct12_list_0[i].byte_43), this.float_0, this.float_1);
                else if (this.mapGraphType_0 == MapGraphType.custom)
                    callfor23(this.Struct12_list_0[i]);
            }
        }
        //this.Refresh();
    }

    public void Next_Live_Plots()
    {
        if (this.struct19_0 != null)
        {
            for (int i = 1; i < this.class10_0.int_5; i++)
            {
                //int_0 = X position, int_1 = Y position
                this.struct19_0[i - 1].int_0 = this.struct19_0[i - 1].int_0;
                this.struct19_0[i - 1].int_1 = this.struct19_0[i].int_1;
            }
        }

        if (this.Struct12_list_0 != null && this.Struct12_list_0.Count > 0) this.Struct12_list_0.RemoveAt(0);

        this.int_6--;
        //this.Refresh();
    }

    //Reset Live Plots Functions
    public void method_17()
    {
        this.int_6 = 0;
        if (this.struct19_0 != null)
        {
            for (int i = 0; i < this.class10_0.int_5; i++)
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

    public void method_19(Struct12 struct12_0)
    {
        if (this.mapGraphType_0 == MapGraphType.timePlot || this.mapGraphType_0 == MapGraphType.custom)
        {
            if (this.struct19_0 == null)
            {
                this.struct19_0 = new Struct19[this.class10_0.int_5];
                this.Struct12_list_0 = new List<Struct12>();
            }
            if (this.struct19_0.Length != this.class10_0.int_5)
            {
                this.int_6 = 0;
                this.struct19_0 = new Struct19[this.class10_0.int_5];
                this.Struct12_list_0 = new List<Struct12>();
            }
            if (this.int_6 == this.class10_0.int_5)
            {
                this.Next_Live_Plots();
            }

            //Store full datalog array
            this.Struct12_list_0.Add(struct12_0);

            if (this.mapGraphType_0 == MapGraphType.timePlot)
                this.method_23(this.class10_0.int_5, struct12_0.byte_43, (float)this.class18_0.method_200(struct12_0.byte_43), this.float_0, this.float_1);
            else
                callfor23(struct12_0);

            this.Invalidate();
        }
    }

    public void method_20(Struct17 struct17_0)
    {
        if ((this.mapGraphType_0 == MapGraphType.rpmPlot) && (this.class18_0.method_198(struct17_0.byte_1) >= this.class10_0.int_4))
        {
            if (this.int_7 == null)
            {
                this.int_7 = new int[0x2ee0 / this.class10_0.int_3, 3];
            }
            if (this.struct19_2 == null)
            {
                this.struct19_2 = new Struct19[0x2ee0 / this.class10_0.int_3, 2];
            }
            int num = this.class18_0.method_218(struct17_0.long_1) / this.class10_0.int_3;
            this.int_7[num, 0] += struct17_0.byte_0;
            this.int_7[num, 1] += struct17_0.byte_2;
            this.int_7[num, 2]++;

            this.Invalidate();
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


            //##################################################################
            case SensorsX.fuelUsage:
                this.method_9(SensorsX.fuelUsage, struct12_0.byte_14_E16);
                break;
            case SensorsX.accelTime:
                this.method_9(SensorsX.accelTime, struct12_0.byte_14_E16);
                break;
            case SensorsX.flexFuel:
                this.method_9(SensorsX.flexFuel, this.class33_Sensors_0.GetFlexFuelByte(struct12_0));
                break;
            case SensorsX.ectV:
                this.method_9(SensorsX.ectV, struct12_0.byte_0);
                break;
            case SensorsX.iatV:
                this.method_9(SensorsX.iatV, struct12_0.byte_1);
                break;
        }

        if (custom_value_int != 17596) //this.class10_0.int_5 ... byte_43 ..... 
            this.method_23_int(custom_value_int, int.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMin")), int.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMax")));

        if (custom_value_float != -9.68779f)
            this.method_23_float(custom_value_float, float.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMin")), float.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMax")));


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
                if (this.class18_0.method_206(byte_0) <= this.class10_0.int_6)
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


            case SensorsX.fuelUsage:
                custom_value_float = (float) this.class33_Sensors_0.FuelUsage;
                return;
            case SensorsX.accelTime:
                custom_value_float = (float) this.class33_Sensors_0.AccelTime;
                return;
            case SensorsX.flexFuel:
                custom_value_float = (float) this.class33_Sensors_0.FlexFuel;
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
                custom_value_float = (float) ECTVoltageValue;
                return;
            case SensorsX.iatV:
                double ThisTempInCelcius2 = this.class18_0.method_191_GetTempInC(byte_0);
                double IATVoltageValue = 5.0 - ((ThisTempInCelcius2 + 40.0) / 36.0);
                //################
                //Calc Difference from 3.72v
                double Diff372v2 = IATVoltageValue - 3.72;
                if (Diff372v2 > 0) IATVoltageValue += (Diff372v2 / 3.2);
                if (Diff372v2 < 0) IATVoltageValue -= (-Diff372v2 / 4.2);
                //################
                custom_value_float = (float)IATVoltageValue;
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
        this.struct19_0[this.int_6].int_0 = this.int_5 + ((int)Math.Abs((float)(this.method_22() * (((float)this.int_6) / ((float) this.class10_0.int_5)))));
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
        this.struct19_0[this.int_6].int_0 = this.int_5 + ((int)Math.Abs((float)(this.method_22() * (((float)this.int_6) / ((float)this.class10_0.int_5)))));
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
        Pen pen = new Pen(this.class10_0.color_11);
        Font font = new Font("Lucida Sans", 10f, FontStyle.Regular);
        Font font2 = new Font("Lucida Sans", 12f, FontStyle.Bold);
        Brush brush = new SolidBrush(this.class10_0.color_11);
        //StringFormat format = new StringFormat {
        //    FormatFlags = StringFormatFlags.DirectionVertical
        //};
        int OffsetLeft = 15;
        int OffsetTop = 30;
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Top + this.int_4 + OffsetTop, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4);
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4, base.ClientRectangle.Width - this.int_3, base.ClientRectangle.Bottom - this.int_4);
        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_0.color_12);
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
        if (this.class10_0.airFuelUnits_0 == AirFuelUnits.afr)
            str = "AFR";
        else
            str = "Lambda";
        //this.graphics_0.DrawString(str, font2, brush, (float) (base.ClientRectangle.Left + 3), (float) ((base.ClientRectangle.Height / 2) - 40), format);
        this.graphics_0.DrawString(str, font2, brush, (float)((base.ClientRectangle.Width / 2) - 10 - (this.graphics_0.MeasureString(str, font).Width / 2)), (float)(base.ClientRectangle.Top + 25));
        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_0.color_11);
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
        int OffsetTop = 30;
        Pen pen = new Pen(this.class10_0.color_12, 2f);
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
        Pen pen = new Pen(this.class10_0.color_11);
        Font font = new Font("Lucida Sans", 10f, FontStyle.Regular);
        Font font2 = new Font("Lucida Sans", 12f, FontStyle.Bold);
        Brush brush = new SolidBrush(this.class10_0.color_11);
        /*StringFormat format = new StringFormat
        {
            FormatFlags = StringFormatFlags.DirectionVertical
        };*/
        int OffsetLeft = 24;
        int OffsetTop = 20;
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Top + this.int_4 + OffsetTop, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4);
        this.graphics_0.DrawLine(pen, this.int_5 - OffsetLeft, base.ClientRectangle.Bottom - this.int_4, base.ClientRectangle.Width - this.int_3, base.ClientRectangle.Bottom - this.int_4);
        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_0.color_12);
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
                bool IsINT = bool.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customINT"));
                if (!IsINT)
                {
                    this.float_0 = float.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMin"));
                    this.float_1 = float.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMax"));
                    str = Math.Round((double)(((this.float_1 - this.float_0) * (((float)i) / Cint_Colomn)) + this.float_0), 2).ToString();
                }
                else
                {
                    int ThatI1 = int.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMin"));
                    int ThatI2 = int.Parse(this.class10_0.method_24((SensorsX)this.Cint_Sensor, "customMax"));
                    str = ((int)(((ThatI2 - ThatI1) * (((float)i) / Cint_Colomn)) + ThatI1)).ToString();
                }
                this.graphics_0.DrawString(str, font, brush, (float)(num2 - this.graphics_0.MeasureString(str, font).Width - 2f), (float)(num - (this.graphics_0.MeasureString(str, font).Height / 2f) + OffsetTop));
            }
            str = this.class10_0.method_13((SensorsX)Cint_Sensor).ToString();
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
        this.graphics_0.DrawString(str, font2, brush, (float)((base.ClientRectangle.Width / 2) - 10 - (this.graphics_0.MeasureString(str, font).Width / 2)), (float)(base.ClientRectangle.Top + 25));

        brush.Dispose();
        brush = null;
        brush = new SolidBrush(this.class10_0.color_11);
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
        int OffsetTop = 20;
        Pen pen = new Pen(this.class10_0.color_12, 2f);
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
        Pen pen = new Pen(this.class10_0.color_11);
        Font font = new Font("Lucida Sans", 8f, FontStyle.Bold);
        Font font2 = new Font("Lucida Sans", 10f, FontStyle.Bold);
        Brush brush = new SolidBrush(this.class10_0.color_13);
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
        brush = new SolidBrush(this.class10_0.color_12);
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
        brush = new SolidBrush(this.class10_0.color_11);
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
        if (this.class10_0 != null)
        {
            int num2 = 0;
            Pen pen = new Pen(this.class10_0.color_13, 2f);
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
                        (this.struct19_2[i, 0]) = this.method_25(i * this.class10_0.int_3, 0x2af8, (float)this.class18_0.method_200(num4), this.float_0, this.float_1);
                        (this.struct19_2[i, 1]) = this.method_25(i * this.class10_0.int_3, 0x2af8, (float)this.class18_0.method_206(num5), 0f, (float)this.class18_0.method_206(0xff));
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
                pen = new Pen(this.class10_0.color_12, 2f);
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

    protected override void OnPaint(PaintEventArgs pe)
    {
        //if (this.graphics_0 != null) this.graphics_0.Dispose();

        if (this.class10_0 == null)
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.FillRectangle(new SolidBrush(SystemColors.ControlDark), pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            return;
        }

        //Load Settings
        this.int_13 = base.ClientRectangle.Width - (this.int_10 + this.int_10_0);
        this.int_12 = base.ClientRectangle.Height - (2 * this.int_11);
        this.brush_0 = new SolidBrush(this.class10_0.color_3);
        Rectangle ThisRec = new Rectangle(pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);

        Image ThisI;
        FileInfo info = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp");
        if (info.Exists) ThisI = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp");
        else ThisI = null;
        info = null;

        //Apply Graphics
        if (this.class18_0 == null)
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.FillRectangle(this.brush_0, pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            //this.graphics_0.DrawImageUnscaledAndClipped(ThisI, ThisRec);
            if (ThisI != null) this.graphics_0.DrawImage(ThisI, ThisRec);

            if (ThisI != null)
            {
                ThisI.Dispose();
                ThisI = null;
            }
            return;
        }
        if (this.class18_0.class17_0.frmMain_0.frmLivePlot_0 == null)
        {
            this.graphics_0 = pe.Graphics;
            this.graphics_0.FillRectangle(new SolidBrush(SystemColors.ControlDark), pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            return;
        }
        if (!this.class10_0.bool_6)
        {
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
        if (this.class10_0.bool_20_ONLY_NA_VIEW)
        {
            int num = 0;
            for (int i = 0; i < this.class10_0.method_11_GetMAP_ColumnsNumber(); i++)
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
            this.int_2 = this.class10_0.method_11_GetMAP_ColumnsNumber();
        }
        switch (this.mapGraphType_0)
        {
            case MapGraphType.timePlot:
                if (this.class10_0.airFuelUnits_0 != AirFuelUnits.lambda)
                {
                    this.float_0 = (float)this.class18_0.method_241(0.68);
                    break;
                }
                this.float_0 = 0.68f;

                if (Last_Used_Sensor != 999) Reset_Struct_Sensor();

                Last_Used_Sensor = 999;
                break;

            case MapGraphType.rpmPlot:
                if (this.class10_0.airFuelUnits_0 != AirFuelUnits.lambda)
                {
                    this.float_0 = (float)this.class18_0.method_241(0.68);
                }
                else
                {
                    this.float_0 = 0.68f;
                }
                if (this.class10_0.airFuelUnits_0 == AirFuelUnits.lambda)
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
                this.Cint_Colomn = this.class10_0.int_GraphColumns;
                this.int_3 = 20;
                this.int_4 = 30;
                this.int_5 = 80;

                if (this.class10_0.int_GraphSensor >= 0)
                {
                    this.Cint_Sensor = this.class10_0.int_GraphSensor;
                    if (this.Cint_Sensor != Last_Used_Sensor) Reset_Struct_Sensor();
                    Last_Used_Sensor = this.Cint_Sensor;
                }

                this.method_26_2();
                this.method_27_2();
                goto Label_044C;

            default:
                goto Label_044C;
        }
        if (this.class10_0.airFuelUnits_0 == AirFuelUnits.lambda)
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
        /*if (this.bool_3)
        {
            using (List<Class7_u>.Enumerator enumerator = this.list_0.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Class7_u current = enumerator.Current;
                    this.method_12(Math.Round(this.double_0, 0).ToString() + " %", (float) this.point_1.X, (float) this.point_1.Y, this.double_0 > 0.0);
                }
                goto Label_05C0;
            }
        }
        if (this.bool_1 && !this.bool_0)
        {
            string str2 = string.Empty;
            if (this.class18_0.method_163((byte) this.int_0) > this.class10_0.int_6)
            {
                str2 = str2 + this.class18_0.method_167((byte) this.int_0) + " " + this.class10_0.mapSensorUnits_1.ToString();
            }
            else
            {
                str2 = str2 + this.class18_0.method_167((byte) this.int_0) + " " + this.class10_0.mapSensorUnits_0.ToString();
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
        }*/
        this.class16_u_0.method_2(pe.Graphics);
        this.pointF_0 = null;
    }

    protected override void OnPaintBackground(PaintEventArgs pe)
    {
    }
}

