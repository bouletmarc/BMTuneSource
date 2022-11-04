//using Dal;
using Data;
using System;
using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

internal class Class12_afrT
{
    private bool[,] bool_0;
    private bool[,] bool_1;
    private bool[,] bool_2;
    private bool[,] bool_3;
    private byte[,,] byte_0;

    /*public static byte[,] byte_0_DemonA1 = new byte[26, 20];
    public static byte[,] byte_0_DemonA2 = new byte[26, 20];
    public static byte[,] byte_0_DemonA3 = new byte[26, 20];
    public static byte[,] byte_0_DemonA4 = new byte[26, 20];
    public static byte[,] byte_0_DemonA5 = new byte[26, 20];
    public static byte[,] byte_0_Analog1 = new byte[26, 20];
    public static byte[,] byte_0_Analog2 = new byte[26, 20];
    public static byte[,] byte_0_Analog3 = new byte[26, 20];
    public static float[,] byte_0_IAT = new float[26, 20];
    public static float[,] byte_0_ECT = new float[26, 20];
    public static float[,] byte_0_Fign = new float[26, 20];
    public static float[,] byte_0_Fuelusage = new float[26, 20];
    public static float[,] byte_0_inj = new float[26, 20];
    public static float[,] byte_0_bat = new float[26, 20];
    public static float[,] byte_0_D14 = new float[26, 20];
    public static byte[,] byte_0_VTS = new byte[26, 20];
    public static float[,] byte_0_BSTDC = new float[26, 20];
    public static float[,] byte_0_TPS = new float[26, 20];
    public static float FuelUsage = 0f;
    private long[,] byte_0_DynoWS;
    private long[,] byte_0_DynoHP;
    private long[,] byte_0_DynoNM;
    private long[,] byte_0_AUX1;
    private long[,] byte_0_AUX2;
    private long[,] byte_0_AUX3;
    private long[,] byte_0_THC;*/

    private byte[,] byte_0_Analog1;
    private byte[,] byte_0_Analog2;
    private byte[,] byte_0_Analog3;

    private byte[,,] byte_1;
    private byte[,,] byte_2;
    private byte[,,] byte_3;
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    private Class18 class18_0;
    /*private float[,,] float_0;
    private float[,,] float_1;
    private float[,,] float_10;
    private float[,,] float_11;
    private float[,,] float_2;
    private float[,,] float_3;
    private float[,,] float_4;
    private float[,,] float_5;
    private float[,,] float_6;
    private float[,,] float_7;
    private float[,,] float_8;
    private float[,,] float_9;*/
    private int int_0;
    private int int_1;
    /*private int int_2;
    private int int_3;
    private int int_4;*/
    private Struct17 struct17_0;
    private TunerAfrGrid tunerAfrGrid_0;
    private string ThPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Target_AFR.txt";

    private DateTime LastCheck = DateTime.Now;

    public Class12_afrT()
    {
        
    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1)
    {
        this.class10_settings_0 = class10_1;
        this.class10_settings_0.delegate13_0 += new Class10_settings.Delegate13(this.method_1);
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_19);
        this.class17_0 = class17_1;
        this.class17_0.delegate47_0 += new Class17.Delegate47(this.method_21);
        this.class17_0.delegate53_0 += new Class17.Delegate53(this.method_2);
        this.class17_0.delegate54_0 += new Class17.Delegate54(this.method_21_Analog);

        //this.class17_0.delegate48_0 += new Class17_dtl.Delegate48(this.method_21_Analog);

        if (!File.Exists(ThPath))
        {
            this.tunerAfrGrid_0 = new TunerAfrGrid();
            this.method_9(false);
            this.method_9(true);
            method_Save();
        }
    }

    private void method_1(bool bool_4)
    {
        this.method_9(bool_4);
        method_Save();
    }

    public bool method_10(int int_5, int int_6)
    {
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                return this.tunerAfrGrid_0.fuel_low_1_Lock[int_5, int_6];
            }
            return this.tunerAfrGrid_0.fuel_high_1_Lock[int_5, int_6];
        }
        if (!this.class18_0.method_36())
        {
            return this.tunerAfrGrid_0.fuel_low_2_Lock[int_5, int_6];
        }
        return this.tunerAfrGrid_0.fuel_high_2_Lock[int_5, int_6];
    }

    private bool IsAnalogOverlay()
    {
        bool IsAnalog = false;
        if (this.class18_0.method_8() == TableOverlay.analog1Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.analog2Reading) IsAnalog = true;
        if (this.class18_0.method_8() == TableOverlay.analog3Reading) IsAnalog = true;
        return IsAnalog;
    }

    public object method_11(int int_5, int int_6)       //Get afr at (row, column)
    {
        if (!IsAnalogOverlay())
        {
            if (this.method_10(int_5, int_6))
            {
                return "-";
            }
        }
        switch (this.class18_0.method_8())
        {
            case TableOverlay.none:
                return null;

            case TableOverlay.afTarget:
                return this.method_12(int_5, int_6);

            case TableOverlay.afReading:
                return this.method_17(int_5, int_6);

            case TableOverlay.afDiff:
                if (this.method_16(int_5, int_6) == null) return null;
                return (((double) this.method_16(int_5, int_6)) * -1.0);

            case TableOverlay.analog1Reading:
                return this.method_17_Analog(int_5, int_6);

            case TableOverlay.analog2Reading:
                return this.method_17_Analog(int_5, int_6);

            case TableOverlay.analog3Reading:
                return this.method_17_Analog(int_5, int_6);
        }
        return null;
    }

    public double method_12(int int_5, int int_6)
    {
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                {
                    return this.class18_0.method_241(this.tunerAfrGrid_0.targetAfr_lo_1[int_5, int_6]);
                }
                return this.tunerAfrGrid_0.targetAfr_lo_1[int_5, int_6];
            }
            if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
            {
                return this.class18_0.method_241(this.tunerAfrGrid_0.targetAfr_hi_1[int_5, int_6]);
            }
            return this.tunerAfrGrid_0.targetAfr_hi_1[int_5, int_6];
        }
        if (!this.class18_0.method_36())
        {
            if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
            {
                return this.class18_0.method_241(this.tunerAfrGrid_0.targetAfr_lo_2[int_5, int_6]);
            }
            return this.tunerAfrGrid_0.targetAfr_lo_2[int_5, int_6];
        }
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
        {
            return this.class18_0.method_241(this.tunerAfrGrid_0.targetAfr_hi_2[int_5, int_6]);
        }
        return this.tunerAfrGrid_0.targetAfr_hi_2[int_5, int_6];
    }

    public double method_13(int int_5, int int_6)
    {
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                return this.tunerAfrGrid_0.targetAfr_lo_1[int_5, int_6];
            }
            return this.tunerAfrGrid_0.targetAfr_hi_1[int_5, int_6];
        }
        if (!this.class18_0.method_36())
        {
            return this.tunerAfrGrid_0.targetAfr_lo_2[int_5, int_6];
        }
        return this.tunerAfrGrid_0.targetAfr_hi_2[int_5, int_6];
    }

    public void method_14(int int_5, int int_6, double double_0)    //set value
    {
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
        {
            double_0 = this.class18_0.method_240(double_0);
        }
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                this.tunerAfrGrid_0.targetAfr_lo_1[int_5, int_6] = double_0;
            }
            else
            {
                this.tunerAfrGrid_0.targetAfr_hi_1[int_5, int_6] = double_0;
            }
        }
        else if (!this.class18_0.method_36())
        {
            this.tunerAfrGrid_0.targetAfr_lo_2[int_5, int_6] = double_0;
        }
        else
        {
            this.tunerAfrGrid_0.targetAfr_hi_2[int_5, int_6] = double_0;
        }

        method_Save();
    }

    public void method_15(int int_5, int int_6, double double_0)    //set value
    {
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                this.tunerAfrGrid_0.targetAfr_lo_1[int_5, int_6] = double_0;
            }
            else
            {
                this.tunerAfrGrid_0.targetAfr_hi_1[int_5, int_6] = double_0;
            }
        }
        else if (!this.class18_0.method_36())
        {
            this.tunerAfrGrid_0.targetAfr_lo_2[int_5, int_6] = double_0;
        }
        else
        {
            this.tunerAfrGrid_0.targetAfr_hi_2[int_5, int_6] = double_0;
        }

        method_Save();
    }

    public object method_16(int int_5, int int_6)   //used for AF - difference
    {
        object obj2 = this.method_17(int_5, int_6);
        if (obj2 == null)
        {
            return null;
        }
        return (((this.method_12(int_5, int_6) / ((double) obj2)) * 100.0) - 100.0);
    }

    public double method_17_Analog(int int_5, int int_6)    //get analog value at
    {
        byte num = 0;
        if (this.class18_0.method_8() == TableOverlay.analog1Reading)
        {
            num = this.method_23_Analog(this.byte_0_Analog1, int_5, int_6);
            if (num == 0) return num;
            return this.class18_0.method_201(AnalogInputs.analog1, num);
        }
        if (this.class18_0.method_8() == TableOverlay.analog2Reading)
        {
            num = this.method_23_Analog(this.byte_0_Analog2, int_5, int_6);
            if (num == 0) return num;
            return this.class18_0.method_201(AnalogInputs.analog2, num);
        }
        if (this.class18_0.method_8() == TableOverlay.analog3Reading)
        {
            num = this.method_23_Analog(this.byte_0_Analog3, int_5, int_6);
            if (num == 0) return num;
            return this.class18_0.method_201(AnalogInputs.analog3, num);
        }
        return 0;
    }

    public object method_17(int int_5, int int_6)       //Get fuel value at (row, column)
    {
        byte num = 0;
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                num = this.method_23(this.byte_0, int_5, int_6);
            }
            else
            {
                num = this.method_23(this.byte_1, int_5, int_6);
            }
        }
        else if (!this.class18_0.method_36())
        {
            num = this.method_23(this.byte_2, int_5, int_6);
        }
        else
        {
            num = this.method_23(this.byte_3, int_5, int_6);
        }
        if (num == 0)
        {
            return null;
        }
        return this.class18_0.method_200(num);
    }

    public bool method_18(int int_5, int int_6)
    {
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                return this.bool_0[int_5, int_6];
            }
            return this.bool_1[int_5, int_6];
        }
        if (!this.class18_0.method_36())
        {
            return this.bool_2[int_5, int_6];
        }
        return this.bool_3[int_5, int_6];
    }

    public void method_Save()
    {
        if (File.Exists(ThPath)) File.Delete(ThPath);

        if (this.tunerAfrGrid_0 != null)
        {
            string SaveStr = "";
            for (int i = 0; i < this.class18_0.method_33(); i++)
            {
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    SaveStr += "Column=" + i + ";Row=" + j + ";targetAfr_lo_1=" + this.tunerAfrGrid_0.targetAfr_lo_1[i, j].ToString() + Environment.NewLine;
                    SaveStr += "Column=" + i + ";Row=" + j + ";targetAfr_hi_1=" + this.tunerAfrGrid_0.targetAfr_hi_1[i, j].ToString() + Environment.NewLine;
                    SaveStr += "Column=" + i + ";Row=" + j + ";targetAfr_lo_2=" + this.tunerAfrGrid_0.targetAfr_lo_2[i, j].ToString() + Environment.NewLine;
                    SaveStr += "Column=" + i + ";Row=" + j + ";targetAfr_hi_2=" + this.tunerAfrGrid_0.targetAfr_hi_2[i, j].ToString() + Environment.NewLine;

                    SaveStr += "Column=" + i + ";Row=" + j + ";fuel_low_1_Lock=" + this.tunerAfrGrid_0.fuel_low_1_Lock[i, j].ToString() + Environment.NewLine;
                    SaveStr += "Column=" + i + ";Row=" + j + ";fuel_high_1_Lock=" + this.tunerAfrGrid_0.fuel_high_1_Lock[i, j].ToString() + Environment.NewLine;
                    SaveStr += "Column=" + i + ";Row=" + j + ";fuel_low_2_Lock=" + this.tunerAfrGrid_0.fuel_low_2_Lock[i, j].ToString() + Environment.NewLine;
                    SaveStr += "Column=" + i + ";Row=" + j + ";fuel_high_2_Lock=" + this.tunerAfrGrid_0.fuel_high_2_Lock[i, j].ToString() + Environment.NewLine;
                }
            }
            StreamWriter writer = new StreamWriter(ThPath, false);
            writer.Write(SaveStr);
            writer.Close();
            writer.Dispose();
            writer = null;
        }
    }

    private void method_19()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            if (!File.Exists(ThPath))
            {
                this.tunerAfrGrid_0 = new TunerAfrGrid();
                this.method_9(false);
                this.method_9(true);
                method_Save();
            }
            else
            {
                try
                {
                    bool DoneAnything = false;

                    string[] AllLines = File.ReadAllLines(ThPath);
                    if (AllLines.Length > 0)
                    {
                        this.tunerAfrGrid_0 = new TunerAfrGrid();
                        this.tunerAfrGrid_0.targetAfr_lo_1 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                        this.tunerAfrGrid_0.targetAfr_hi_1 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                        this.tunerAfrGrid_0.targetAfr_lo_2 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                        this.tunerAfrGrid_0.targetAfr_hi_2 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];

                        this.tunerAfrGrid_0.fuel_low_1_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                        this.tunerAfrGrid_0.fuel_high_1_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                        this.tunerAfrGrid_0.fuel_low_2_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                        this.tunerAfrGrid_0.fuel_high_2_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];

                        for (int i = 0; i < AllLines.Length; i++)
                        {
                            if (AllLines[i].Contains("Row") && AllLines[i].Contains("Column"))
                            {
                                DoneAnything = true;
                                string[] SplitCMD = AllLines[i].Split(';');
                                string[] SplitColumnEnc = SplitCMD[0].Split('=');
                                string[] SplitRowEnc = SplitCMD[1].Split('=');
                                string[] SplitCmdEnc = SplitCMD[2].Split('=');

                                int ThisColumn = int.Parse(SplitColumnEnc[1]);
                                int ThisRow = int.Parse(SplitRowEnc[1]);
                                if (SplitCmdEnc[0].Contains("targetAfr_lo_1")) this.tunerAfrGrid_0.targetAfr_lo_1[ThisColumn, ThisRow] = double.Parse(SplitCmdEnc[1]);
                                if (SplitCmdEnc[0].Contains("targetAfr_hi_1")) this.tunerAfrGrid_0.targetAfr_hi_1[ThisColumn, ThisRow] = double.Parse(SplitCmdEnc[1]);
                                if (SplitCmdEnc[0].Contains("targetAfr_lo_2")) this.tunerAfrGrid_0.targetAfr_lo_2[ThisColumn, ThisRow] = double.Parse(SplitCmdEnc[1]);
                                if (SplitCmdEnc[0].Contains("targetAfr_hi_2")) this.tunerAfrGrid_0.targetAfr_hi_2[ThisColumn, ThisRow] = double.Parse(SplitCmdEnc[1]);

                                if (SplitCmdEnc[0].Contains("fuel_low_1_Lock")) this.tunerAfrGrid_0.fuel_low_1_Lock[ThisColumn, ThisRow] = bool.Parse(SplitCmdEnc[1]);
                                if (SplitCmdEnc[0].Contains("fuel_high_1_Lock")) this.tunerAfrGrid_0.fuel_high_1_Lock[ThisColumn, ThisRow] = bool.Parse(SplitCmdEnc[1]);
                                if (SplitCmdEnc[0].Contains("fuel_low_2_Lock")) this.tunerAfrGrid_0.fuel_low_2_Lock[ThisColumn, ThisRow] = bool.Parse(SplitCmdEnc[1]);
                                if (SplitCmdEnc[0].Contains("fuel_high_2_Lock")) this.tunerAfrGrid_0.fuel_high_2_Lock[ThisColumn, ThisRow] = bool.Parse(SplitCmdEnc[1]);
                            }
                        }
                    }

                    if (!DoneAnything)
                    {
                        this.tunerAfrGrid_0 = new TunerAfrGrid();
                        this.method_9(false);
                        this.method_9(true);
                        method_Save();
                    }

                    //#######################################
                    /*serializationStream = new FileStream(ThPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    if (this.tunerAfrGrid_0 == null)
                    {
                        this.tunerAfrGrid_0 = (TunerAfrGrid) formatter.Deserialize(serializationStream);
                        if (((this.tunerAfrGrid_0.targetAfr_hi_1 == null) || (this.tunerAfrGrid_0.targetAfr_hi_2 == null)) || ((this.tunerAfrGrid_0.targetAfr_lo_1 == null) || (this.tunerAfrGrid_0.targetAfr_lo_2 == null)))
                        {
                            if (serializationStream != null)
                            {
                                serializationStream.Close();
                                serializationStream.Dispose();
                                serializationStream = null;
                            }
                            formatter = null;

                            this.method_9(false);
                            this.method_9(true);
                        }
                    }*/
                }
                catch (Exception mess)
                {
                    LogThis("Error while loading AFR Layout:" + Environment.NewLine + "" + mess);

                    this.tunerAfrGrid_0 = new TunerAfrGrid();
                    this.method_9(false);
                    this.method_9(true);
                    method_Save();
                }
            }
            if (this.byte_0 == null)
            {
                this.byte_0 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.byte_0_Analog1 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_0_Analog2 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_0_Analog3 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_1 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.bool_0 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.bool_1 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_2 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.byte_3 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.bool_2 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.bool_3 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
            }
            else if (((this.byte_0.GetUpperBound(0) != (this.class18_0.method_33() - 1)) || (this.byte_0.GetUpperBound(1) != (this.class18_0.method_32_GetRPM_RowsNumber() - 1))) || (this.byte_0.GetUpperBound(2) != (this.class10_settings_0.int_36 - 1)))
            {
                this.byte_0 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.byte_0_Analog1 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_0_Analog2 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_0_Analog3 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_1 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.bool_0 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.bool_1 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.byte_2 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.byte_3 = new byte[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber(), this.class10_settings_0.int_36];
                this.bool_2 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.bool_3 = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
            }
            this.method_3();
            this.method_5();
        }
    }

    private void LogThis(string string_8)
    {
        this.class17_0.frmMain_0.LogThis("AFR Target - " + string_8);
    }

    private void method_2(long long_0, string string_0)
    {
        if (long_0 == 0L)
        {
            this.method_3();
            this.method_5();
        }
    }

    private void method_20(string string_0, string string_1, string string_2)
    {
    }

    private void method_21_Analog(Struct12 struct12_1)
    {
        if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && (DateTime.Now - LastCheck).TotalMilliseconds >= this.class10_settings_0.int_ActiveDatalog[0]))
        {
            LastCheck = DateTime.Now;
            if (!this.class10_settings_0.DatalogThreadEnabled || (this.class10_settings_0.DatalogThreadEnabled && this.class10_settings_0.bool_ActiveDatalog[0]))
            {
                this.byte_0_Analog1[struct12_1.struct24_0.int_1, struct12_1.struct24_0.int_0] = struct12_1.byte_40;
                this.byte_0_Analog2[struct12_1.struct24_0.int_1, struct12_1.struct24_0.int_0] = struct12_1.byte_41;
                this.byte_0_Analog3[struct12_1.struct24_0.int_1, struct12_1.struct24_0.int_0] = struct12_1.byte_42;
            }
        }
    }

    private void method_21(Struct17 struct17_1)
    {
        if (this.method_22(struct17_1))
        {
            this.method_8(struct17_1);
            if (struct17_1 != this.struct17_0)
            {
                this.int_0 = 0;
                this.struct17_0 = struct17_1;
            }
            else if (this.int_0 == this.class10_settings_0.int_37)
            {
                this.int_1++;
                if (this.class10_settings_0.bool_47)
                {
                    if (this.struct17_0.byte_0 != struct17_1.byte_0)
                    {
                        this.method_27(struct17_1); //set afr bytes
                    }
                    this.struct17_0 = struct17_1;
                    this.int_1 = 0;
                }
                else
                {
                    this.method_27(struct17_1); //set afr bytes
                    this.struct17_0 = struct17_1;
                    this.int_1 = 0;
                }
            }
            else
            {
                this.int_0++;
                this.int_1 = 0;
                this.struct17_0 = struct17_1;
            }
        }
    }

    private bool method_22(Struct17 struct17_1)
    {
        if (struct17_1.bool_2)
        {
            return false;
        }
        int num = this.class18_0.method_218(struct17_1.long_1);
        int num2 = this.class18_0.method_206(struct17_1.byte_2);
        this.class18_0.method_198(struct17_1.byte_1);
        this.class18_0.method_191(struct17_1.byte_3);
        this.class18_0.method_191(struct17_1.byte_4);
        double num3 = this.class18_0.method_200(struct17_1.byte_0);
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
        {
            num3 = this.class18_0.method_240(num3);
        }
        bool flag = this.class10_settings_0.bool_46[struct17_1.byte_5];
        //return true;
        if (this.class10_settings_0.OverlayConditionsDisabled) return true;
        else return ((((((num >= this.class10_settings_0.int_28) && (num <= this.class10_settings_0.int_29)) && ((num2 >= this.class10_settings_0.int_30) && (num2 <= this.class10_settings_0.int_31))) && (((struct17_1.byte_1 >= this.class10_settings_0.int_26) && (struct17_1.byte_1 <= this.class10_settings_0.int_27)) && ((struct17_1.byte_3 <= this.class10_settings_0.int_32) && (struct17_1.byte_3 >= this.class10_settings_0.int_33)))) && (((struct17_1.byte_4 <= this.class10_settings_0.int_34) && (struct17_1.byte_4 >= this.class10_settings_0.int_35)) && ((num3 >= this.class10_settings_0.double_7) && (num3 <= this.class10_settings_0.double_8)))) && flag);
    }

    private byte method_23(byte[,,] byte_4, int int_5, int int_6)
    {
        int num = 0;
        int num2 = 0;
        for (int i = 0; i < this.class10_settings_0.int_36; i++)
        {
            if (byte_4[int_5, int_6, i] != 0)
            {
                num2 += byte_4[int_5, int_6, i];
                num++;
            }
        }
        if (num == 0)
        {
            return 0;
        }
        return (byte) Math.Round((double) (((float) num2) / ((float) num)), 0);
    }

    private byte method_23_Analog(byte[,] byte_4, int int_5, int int_6)
    {
        byte RByte = 0;
        try
        {
            RByte = byte_4[int_5, int_6];
        }
        catch { }
        return RByte;
    }

    private byte method_24(byte[,,] byte_4, int int_5, int int_6)
    {
        int num = this.method_23(byte_4, int_5, int_6);
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        for (int i = 0; i < this.class10_settings_0.int_36; i++)
        {
            if (byte_4[int_5, int_6, i] != 0)
            {
                num2 = byte_4[int_5, int_6, i] - num;
                num3 = Math.Abs(num2);
                num4 += num3;
                num5++;
            }
        }
        double d = ((float) num4) / ((float) (num5 - 1));
        return (byte) Math.Round(d, 0);
    }

    private void method_25(byte[,,] byte_4, int int_5, int int_6)
    {
        for (int i = 0; i < byte_4.GetUpperBound(2); i++)
        {
            byte_4[int_5, int_6, i] = byte_4[int_5, int_6, i + 1];
        }
        byte_4[int_5, int_6, byte_4.GetUpperBound(2)] = 0;
    }

    private int method_26(byte[,,] byte_4, int int_5, int int_6)
    {
        int num = 0;
        for (int i = 0; i < this.class10_settings_0.int_36; i++)
        {
            if (byte_4[int_5, int_6, i] != 0)
            {
                num++;
            }
        }
        return num;
    }

    private void method_27(Struct17 struct17_1)
    {
        byte[,,] buffer;
        bool[,] flagArray;
        int num = 0;
        byte num2 = 0;
        byte num3 = 0;
        if (!struct17_1.bool_1)
        {
            if (!struct17_1.bool_0)
            {
                buffer = this.byte_0;
                flagArray = this.tunerAfrGrid_0.fuel_low_1_Lock;
            }
            else
            {
                buffer = this.byte_1;
                flagArray = this.tunerAfrGrid_0.fuel_high_1_Lock;
            }
        }
        else if (!struct17_1.bool_0)
        {
            buffer = this.byte_2;
            flagArray = this.tunerAfrGrid_0.fuel_low_2_Lock;
        }
        else
        {
            buffer = this.byte_3;
            flagArray = this.tunerAfrGrid_0.fuel_high_2_Lock;
        }

        byte num4 = 0;
        if (!flagArray[struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0])
        {
            num = this.method_26(buffer, struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0);
            num3 = this.method_23(buffer, struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0);
            if ((num >= this.class10_settings_0.int_41) && this.class10_settings_0.bool_51)
            {
                num2 = this.method_24(buffer, struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0);
                if ((struct17_1.byte_0 >= (num3 + num2)) || (struct17_1.byte_0 <= (num3 - num2)))
                {
                    goto Label_021E;
                }
            }
            if (num >= (this.class10_settings_0.int_36 - 1))
            {
                this.method_25(buffer, struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0);
                num--;
            }
            num4 = struct17_1.byte_0;
            if (num3 != 0 && !struct17_1.method_0(struct17_1.struct15_0.struct24_0))
            {
                num4 = (byte) ((struct17_1.byte_0 * 0.2) + (num3 * 0.8));
            }
            buffer[struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0, num] = num4;
        }
    Label_021E:
        if (!flagArray[struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0])
        {
            num = this.method_26(buffer, struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0);
            num3 = this.method_23(buffer, struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0);
            if ((num >= this.class10_settings_0.int_41) && this.class10_settings_0.bool_51)
            {
                num2 = this.method_24(buffer, struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0);
                if ((struct17_1.byte_0 >= (num3 + num2)) || (struct17_1.byte_0 <= (num3 - num2)))
                {
                    goto Label_03BD;
                }
            }
            if (num == (this.class10_settings_0.int_36 - 1))
            {
                this.method_25(buffer, struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0);
                num--;
            }
            num4 = struct17_1.byte_0;
            if (num3 != 0 && !struct17_1.method_0(struct17_1.struct15_0.struct24_1))
            {
                num4 = (byte) ((struct17_1.byte_0 * 0.2) + (num3 * 0.8));
            }
            buffer[struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0, num] = num4;
        }
    Label_03BD:
        if (!flagArray[struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0])
        {
            num = this.method_26(buffer, struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0);
            num3 = this.method_23(buffer, struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0);
            if ((num >= this.class10_settings_0.int_41) && this.class10_settings_0.bool_51)
            {
                num2 = this.method_24(buffer, struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0);
                if ((struct17_1.byte_0 >= (num3 + num2)) || (struct17_1.byte_0 <= (num3 - num2)))
                {
                    goto Label_055C;
                }
            }
            if (num == (this.class10_settings_0.int_36 - 1))
            {
                this.method_25(buffer, struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0);
                num--;
            }
            num4 = struct17_1.byte_0;
            if (num3 != 0 && !struct17_1.method_0(struct17_1.struct15_0.struct24_2))
            {
                num4 = (byte) ((struct17_1.byte_0 * 0.2) + (num3 * 0.8));
            }
            buffer[struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0, num] = num4;
        }
    Label_055C:
        if (!flagArray[struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0])
        {
            num = this.method_26(buffer, struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0);
            num3 = this.method_23(buffer, struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0);
            if ((num >= this.class10_settings_0.int_41) && this.class10_settings_0.bool_51)
            {
                num2 = this.method_24(buffer, struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0);
                if ((struct17_1.byte_0 >= (num3 + num2)) || (struct17_1.byte_0 <= (num3 - num2)))
                {
                    goto Label_06FB;
                }
            }
            if (num == (this.class10_settings_0.int_36 - 1))
            {
                this.method_25(buffer, struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0);
                num--;
            }
            num4 = struct17_1.byte_0;
            if (num3 != 0 && !struct17_1.method_0(struct17_1.struct15_0.struct24_3))
            {
                num4 = (byte) ((struct17_1.byte_0 * 0.2) + (num3 * 0.8));
            }
            buffer[struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0, num] = num4;
        }
    Label_06FB:
        struct17_1.byte_0 = 0;
    }

    private void method_28(Struct12 struct12_1)
    {
    }

    public void method_3()      //clear recordings
    {
        for (int i = 0; i < this.class18_0.method_33(); i++)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                for (int k = 0; k < this.class10_settings_0.int_36; k++)
                {
                    this.byte_0[i, j, k] = 0;
                    this.byte_1[i, j, k] = 0;
                    this.byte_2[i, j, k] = 0;
                    this.byte_3[i, j, k] = 0;
                }
                this.byte_0_Analog1[i, j] = 0;
                this.byte_0_Analog2[i, j] = 0;
                this.byte_0_Analog3[i, j] = 0;
            }
        }
        this.method_5();
        this.class18_0.method_53();
    }

    /*public void method_4_Analog(int int_5, int int_6)
    {
        this.byte_0_Analog1[int_5, int_6] = 0;
        this.byte_0_Analog2[int_5, int_6] = 0;
        this.byte_0_Analog3[int_5, int_6] = 0;
    }*/

    public void method_4(int int_5, int int_6)
    {
        for (int i = 0; i < this.class10_settings_0.int_36; i++)
        {
            if (!this.class18_0.method_39())
            {
                if (!this.class18_0.method_36())
                {
                    this.byte_0[int_5, int_6, i] = 0;
                }
                else
                {
                    this.byte_1[int_5, int_6, i] = 0;
                }
            }
            else if (!this.class18_0.method_36())
            {
                this.byte_0[int_5, int_6, i] = 0;
            }
            else
            {
                this.byte_1[int_5, int_6, i] = 0;
            }
        }
        this.byte_0_Analog1[int_5, int_6] = 0;
        this.byte_0_Analog2[int_5, int_6] = 0;
        this.byte_0_Analog3[int_5, int_6] = 0;
    }

    public void method_5()
    {
        for (int i = 0; i < this.class18_0.method_33(); i++)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                for (int k = 0; k < this.class10_settings_0.int_36; k++)
                {
                    this.bool_0[i, j] = false;
                    this.bool_1[i, j] = false;
                    this.bool_2[i, j] = false;
                    this.bool_3[i, j] = false;
                }
            }
        }
        this.class18_0.method_53();
    }

    public void method_6(int int_5, int int_6)  //filter unaceptable value
    {
        byte[,,] buffer;
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                buffer = this.byte_0;
            }
            else
            {
                buffer = this.byte_1;
            }
        }
        else if (!this.class18_0.method_36())
        {
            buffer = this.byte_2;
        }
        else
        {
            buffer = this.byte_3;
        }
        double num = this.class18_0.method_200(this.method_23(buffer, int_5, int_6));
        double num2 = 0.0;
        byte num3 = 0;
        for (int i = 0; i < this.class10_settings_0.int_36; i++)
        {
            if (buffer[int_5, int_6, i] != 0)
            {
                num2 = this.class18_0.method_200(buffer[int_5, int_6, i]);
                if (num2 < (num - this.class10_settings_0.double_9))
                {
                    num3 = this.class18_0.method_213(num - this.class10_settings_0.double_9);
                    buffer[int_5, int_6, i] = num3;
                }
                else if (num2 > (num + 1.5))
                {
                    num3 = this.class18_0.method_213(num + this.class10_settings_0.double_9);
                    buffer[int_5, int_6, i] = num3;
                }
            }
        }
    }

    /*public void method_7(int int_5, int int_6)
    {
        if (!this.class18_0.method_39())
        {
            if (!this.class18_0.method_36())
            {
                this.tunerAfrGrid_0.fuel_low_1_Lock[int_5, int_6] = !this.tunerAfrGrid_0.fuel_low_1_Lock[int_5, int_6];
            }
            else
            {
                this.tunerAfrGrid_0.fuel_high_1_Lock[int_5, int_6] = !this.tunerAfrGrid_0.fuel_low_1_Lock[int_5, int_6];
            }
        }
        else if (!this.class18_0.method_36())
        {
            this.tunerAfrGrid_0.fuel_low_2_Lock[int_5, int_6] = !this.tunerAfrGrid_0.fuel_low_2_Lock[int_5, int_6];
        }
        else
        {
            this.tunerAfrGrid_0.fuel_high_2_Lock[int_5, int_6] = !this.tunerAfrGrid_0.fuel_low_2_Lock[int_5, int_6];
        }
    }*/

    private void method_8(Struct17 struct17_1)
    {
        if (!struct17_1.bool_1)
        {
            if (struct17_1.bool_0)
            {
                this.bool_1[struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0] = true;
                this.bool_1[struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0] = true;
                this.bool_1[struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0] = true;
                this.bool_1[struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0] = true;
            }
            else
            {
                this.bool_0[struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0] = true;
                this.bool_0[struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0] = true;
                this.bool_0[struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0] = true;
                this.bool_0[struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0] = true;
            }
        }
        else if (struct17_1.bool_0)
        {
            this.bool_3[struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0] = true;
            this.bool_3[struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0] = true;
            this.bool_3[struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0] = true;
            this.bool_3[struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0] = true;
        }
        else
        {
            this.bool_2[struct17_1.struct15_0.struct24_0.int_1, struct17_1.struct15_0.struct24_0.int_0] = true;
            this.bool_2[struct17_1.struct15_0.struct24_1.int_1, struct17_1.struct15_0.struct24_1.int_0] = true;
            this.bool_2[struct17_1.struct15_0.struct24_2.int_1, struct17_1.struct15_0.struct24_2.int_0] = true;
            this.bool_2[struct17_1.struct15_0.struct24_3.int_1, struct17_1.struct15_0.struct24_3.int_0] = true;
        }
    }

    public void method_9(bool bool_4)
    {
        if (this.tunerAfrGrid_0 != null)
        {
            if (!bool_4)
            {
                this.tunerAfrGrid_0.targetAfr_lo_1 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.tunerAfrGrid_0.targetAfr_hi_1 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.tunerAfrGrid_0.fuel_low_1_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.tunerAfrGrid_0.fuel_high_1_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
            }
            else
            {
                this.tunerAfrGrid_0.targetAfr_lo_2 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.tunerAfrGrid_0.targetAfr_hi_2 = new double[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.tunerAfrGrid_0.fuel_low_2_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
                this.tunerAfrGrid_0.fuel_high_2_Lock = new bool[this.class18_0.method_33(), this.class18_0.method_32_GetRPM_RowsNumber()];
            }
            for (int i = 0; i < this.class18_0.method_33(); i++)
            {
                double num2;
                int num = this.class18_0.method_163((byte) i);
                if (num <= this.class10_settings_0.int_38)
                {
                    num2 = this.class10_settings_0.double_10;        //get Low AFR
                }
                else if ((num > this.class10_settings_0.int_38) && (num < this.class10_settings_0.int_39))
                {
                    num2 = this.class10_settings_0.double_11;        //get Mid AFR
                }
                else
                {
                    if (num < this.class10_settings_0.int_39)
                    {
                        this.class18_0.class17_0.frmMain_0.LogThis("set target afr error");
                        return;
                        //throw new Exception("set target afr error");
                    }
                    num2 = this.class10_settings_0.double_12;        //get High AFR
                }
                for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
                {
                    if (!bool_4)
                    {
                        this.tunerAfrGrid_0.targetAfr_lo_1[i, j] = num2;
                        this.tunerAfrGrid_0.targetAfr_hi_1[i, j] = num2;
                    }
                    else
                    {
                        this.tunerAfrGrid_0.targetAfr_lo_2[i, j] = num2;
                        this.tunerAfrGrid_0.targetAfr_hi_2[i, j] = num2;
                    }
                }
            }

            this.class18_0.method_53();
        }
    }
}

