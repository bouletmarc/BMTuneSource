using Data;
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

internal class Class33_Sensors
{
    private Class10_settings class10_settings_0;
    private Class18 class18_0;

    public int VSS;
    public int RPM;
    public double InjDurr;
    public long InjDuty;
    public double InjFV;
    public long Frame;
    public string Duration;
    public long Interval;
    public double IATFC;
    public double O2Short;
    public double O2Long;

    public int Gear;
    public double Map;
    public double Boost;
    public int PA;
    public int TPS;
    public double TPSV;
    public double IgnFinal;
    public double IgnTable;
    public int ECT;
    public int IAT;
    public double AFR;
    public double EcuO2V;
    public double WBV;
    public double BatV;
    public double ELDV;
    public double KnockV;
    public double MapV;
    public bool MIL;
    public double ECTFc;
    public double VEFc;
    public double ECTIc;
    public double IATIc;
    public double GearIc;
    public double GearFc;

    public bool PostFuel;
    public bool OutIAB;
    public bool OutVTS;
    public bool OutVTSM;
    public bool OutAC;
    public bool OutO2H;
    public bool OutMIL;
    public bool OutPurge;
    public bool OutFanC;
    public bool OutFPump;
    public bool OutFCut;
    public bool OutAltCtrl;

    public bool InPSP;
    public bool InSCC;
    public bool InACCs;
    public bool InBKSW;
    public bool InVTP;
    public bool InVTSFB;
    public bool InParkN;
    public bool InStartS;
    public bool InATShift1;
    public bool InATShift2;

    public bool SecMap;
    public bool InFTL;
    public bool ActiveFTL;
    public bool InFTS;
    public bool ActiveFTS;
    public bool ActiveBstCut;
    public bool ActiveOverHeat;
    public bool ActiveAntilag;
    public bool ICut;
    public bool SCCChecker;
    public bool InEBC;
    public bool InEBCHi;
    public bool ActiveEBC;

    public double EBCBaseDuty;
    public double EBCDuty;
    public double EBCTarget;
    public double EBCCurrent;

    public bool InGPO1;
    public bool OutGPO1;
    public bool InGPO2;
    public bool OutGPO2;
    public bool InGPO3;
    public bool OutGPO3;

    public bool FanC;
    public bool BSTS2;
    public bool BSTS3;
    public bool BSTS4;
    public bool ActiveBST;
    public bool InBST;
    public bool LeanProtect;

    public double Analog1;
    public double Analog2;
    public double Analog3;

    public int IACVDuty;

    public double AccelTime;
    public double FuelUsage;

    public double FlexFuel;

    public double EGRV;
    public double B6V;
    public double ECTV;
    public double IATV;

    public Class33_Sensors(ref Class18 class18_1)
    {
        class18_0 = class18_1;
        class10_settings_0 = class18_0.class10_settings_0;
        this.class18_0.class17_0.delegate54_0 += new Class17.Delegate54(this.LoadSensorsData);
    }

    public void LoadSensorsData(Struct12 struct12_0)
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.method_10(SensorsX.rpmX, (long)struct12_0.ushort_0_E6_7);
            this.method_9(SensorsX.ectX, struct12_0.byte_0);
            this.method_9(SensorsX.iatX, struct12_0.byte_1);
            this.method_9(SensorsX.tpsX, struct12_0.byte_5);
            this.method_9(SensorsX.tpsV, struct12_0.byte_5);
            this.method_9(SensorsX.ignFnl, struct12_0.byte_15_E19);
            this.method_9(SensorsX.ignTbl, struct12_0.byte_16_E20);
            this.method_9(SensorsX.vssX, struct12_0.byte_14_E16);
            this.method_9(SensorsX.gearX, struct12_0.byte_20);
            this.method_10(SensorsX.injFV, (long)struct12_0.ushort_1_E17_18);
            this.method_10(SensorsX.injDur, (long)struct12_0.ushort_1_E17_18);
            this.method_10(SensorsX.injDuty, (long)struct12_0.ushort_1_E17_18);
            this.method_9(SensorsX.ecuO2V, struct12_0.byte_2);
            this.method_9(SensorsX.wbO2V, struct12_0.byte_43);
            this.method_9(SensorsX.afr, struct12_0.byte_43);
            this.method_9(SensorsX.mapV, struct12_0.byte_4);
            this.method_9(SensorsX.mapX, struct12_0.byte_4);
            this.method_9(SensorsX.boostX, struct12_0.byte_4);
            this.method_9(SensorsX.paX, struct12_0.byte_3);
            this.method_10(SensorsX.frame, struct12_0.long_5);
            this.method_10(SensorsX.interval, struct12_0.long_4);
            this.method_10(SensorsX.duration, struct12_0.long_3);
            this.method_9(SensorsX.mil, struct12_0.byte_19);
            this.method_9(SensorsX.batV, struct12_0.byte_27_E25);
            this.method_9(SensorsX.eldV, struct12_0.byte_24_E24);
            this.method_9(SensorsX.outAc, struct12_0.byte_22_E22);
            this.method_9(SensorsX.outPurge, struct12_0.byte_22_E22);
            this.method_9(SensorsX.outFanc, struct12_0.byte_22_E22);
            this.method_9(SensorsX.outFpump, struct12_0.byte_22_E22);
            this.method_9(SensorsX.outIab, struct12_0.byte_22_E22);
            this.method_9(SensorsX.outAltCtrl, struct12_0.byte_22_E22);
            this.method_9(SensorsX.outVtsX, struct12_0.byte_23_E23);
            this.method_9(SensorsX.outMil, struct12_0.byte_23_E23);
            this.method_9(SensorsX.outO2h, struct12_0.byte_23_E23);
            this.method_9(SensorsX.outVtsM, struct12_0.byte_6_E8);
            this.method_9(SensorsX.inVtsFeedBack, struct12_0.byte_21_E21);
            this.method_9(SensorsX.outFuelCut, struct12_0.byte_6_E8);
            this.method_9(SensorsX.inAccs, struct12_0.byte_21_E21);
            this.method_9(SensorsX.inVtp, struct12_0.byte_21_E21);
            this.method_9(SensorsX.inStartS, struct12_0.byte_21_E21);
            this.method_9(SensorsX.inBksw, struct12_0.byte_21_E21);
            this.method_9(SensorsX.inParkN, struct12_0.byte_21_E21);
            this.method_9(SensorsX.inAtShift1, struct12_0.byte_6_E8);
            this.method_9(SensorsX.inAtShift2, struct12_0.byte_6_E8);
            this.method_9(SensorsX.inPsp, struct12_0.byte_21_E21);
            this.method_9(SensorsX.inSCC, struct12_0.byte_21_E21);
            this.method_10(SensorsX.iacvDuty, struct12_0.ushort_2_E49_50);
            this.method_9(SensorsX.postFuel, struct12_0.byte_6_E8);
            this.method_9(SensorsX.ectFc, struct12_0.byte_28_E26);
            this.method_10(SensorsX.o2Short, struct12_0.long_0_E27_28);
            this.method_10(SensorsX.o2Long, struct12_0.long_1_E29_30);
            this.method_10(SensorsX.iatFc, struct12_0.long_2_E31_32);
            this.method_9(SensorsX.veFc, struct12_0.byte_29_E33);
            this.method_9(SensorsX.iatIc, struct12_0.byte_30_E34);
            this.method_9(SensorsX.ectIc, struct12_0.byte_31_E35);
            this.method_9(SensorsX.gearIc, struct12_0.byte_32_E36);
            this.method_9(SensorsX.gearFc, struct12_0.byte_33_E37);
            this.method_9(SensorsX.ftsClutchInput, struct12_0.byte_34_E38);
            this.method_9(SensorsX.ftlInput, struct12_0.byte_34_E38);
            this.method_9(SensorsX.gpo1_in, struct12_0.byte_34_E38);
            this.method_9(SensorsX.gpo2_in, struct12_0.byte_34_E38);
            this.method_9(SensorsX.gpo3_in, struct12_0.byte_34_E38);
            this.method_9(SensorsX.bstInput, struct12_0.byte_34_E38);
            this.method_9(SensorsX.ftlActive, struct12_0.byte_35_E39);
            this.method_9(SensorsX.ftsActive, struct12_0.byte_35_E39);
            this.method_9(SensorsX.antilagActive, struct12_0.byte_35_E39);
            this.method_9(SensorsX.boostcutActive, struct12_0.byte_35_E39);
            this.method_9(SensorsX.ignitionCut, struct12_0.byte_6_E8);
            this.method_9(SensorsX.sccChecker, struct12_0.byte_6_E8);
            this.method_9(SensorsX.gpo1_out, struct12_0.byte_36_E43);
            this.method_9(SensorsX.gpo2_out, struct12_0.byte_36_E43);
            this.method_9(SensorsX.gpo3_out, struct12_0.byte_36_E43);
            this.method_9(SensorsX.bstStage2, struct12_0.byte_36_E43);
            this.method_9(SensorsX.bstStage3, struct12_0.byte_36_E43);
            this.method_9(SensorsX.bstStage4, struct12_0.byte_36_E43);
            this.method_9(SensorsX.overheatActive, struct12_0.byte_36_E43);
            this.method_9(SensorsX.leanProtection, struct12_0.byte_36_E43);
            this.method_9(SensorsX.fanCtrl, struct12_0.byte_35_E39);
            this.method_9(SensorsX.bstActive, struct12_0.byte_35_E39);
            this.method_9(SensorsX.secMaps, struct12_0.byte_35_E39);
            this.method_9(SensorsX.ebcActive, struct12_0.byte_35_E39);
            this.method_9(SensorsX.ebcInput, struct12_0.byte_34_E38);
            this.method_9(SensorsX.ebcHiInput, struct12_0.byte_34_E38);
            this.method_9(SensorsX.ebcDutyX, struct12_0.byte_38_E41);
            this.method_9(SensorsX.ebcBaseDuty, struct12_0.byte_37_E40);
            this.method_9(SensorsX.ebcCurrent, struct12_0.byte_4);
            this.method_9(SensorsX.ebcTarget, struct12_0.byte_39_E42);
            this.method_9(SensorsX.analog1, struct12_0.byte_40);
            this.method_9(SensorsX.analog2, struct12_0.byte_41);
            this.method_9(SensorsX.analog3, struct12_0.byte_42);
            this.method_9(SensorsX.accelTime, struct12_0.byte_14_E16);
            this.method_10(SensorsX.fuelUsage, struct12_0.ushort_1_E17_18);
            this.method_9(SensorsX.egrV, struct12_0.byte_25_E44);
            this.method_9(SensorsX.b6V, struct12_0.byte_26_E45);
            this.method_9(SensorsX.ectV, struct12_0.byte_0);
            this.method_9(SensorsX.iatV, struct12_0.byte_1);

            this.method_9(SensorsX.flexFuel, GetFlexFuelByte(struct12_0));
        }
    }

    public byte GetFlexFuelByte(Struct12 struct12_0)
    {
        switch (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_466))
        {
            case 0xff:
                return 0;

            case 0:
                return 0;

            case 2:
                return struct12_0.byte_24_E24;

            case 3:
                return struct12_0.byte_25_E44;

            case 4:
                return struct12_0.byte_26_E45;
        }
        return 0;
    }

    private double ConvertBooltoDouble(bool IsActivated)
    {
        double RDouble = 0;
        if (IsActivated) RDouble = 1;
        return RDouble;
    }

    private void method_10(SensorsX sensors_0, long long_0)
    {
        try
        {
            if (sensors_0 == SensorsX.iacvDuty) IACVDuty = (int)((((long_0 / 32768.0) * 100.0) - 100.0));
            if (sensors_0 == SensorsX.rpmX) RPM = this.class18_0.method_218(long_0);
            if (sensors_0 == SensorsX.injDur) InjDurr = (double)this.class18_0.method_224((int)long_0);
            if (sensors_0 == SensorsX.injDuty) InjDuty = (long)this.class18_0.method_225((int)long_0, RPM, 0);
            if (sensors_0 == SensorsX.injFV) InjFV = this.class18_0.method_223((int)long_0);
            if (sensors_0 == SensorsX.frame) Frame = long_0;
            if (sensors_0 == SensorsX.duration)
            {
                Duration = TimeSpan.FromMilliseconds((double)long_0).ToString();
                if (Duration.Length <= 8)
                {
                    Duration = Duration + ".000";
                    return;
                }
                Duration = Duration.Remove(Duration.Length - 5, 5);
            }
            if (sensors_0 == SensorsX.interval) Interval = long_0;
            if (sensors_0 == SensorsX.iatFc) IATFC = this.class18_0.method_203(long_0, Enum6.const_0);
            if (sensors_0 == SensorsX.o2Short) O2Short = this.class18_0.method_203(long_0, Enum6.const_0);
            if (sensors_0 == SensorsX.o2Long) O2Long = this.class18_0.method_203(long_0, Enum6.const_0);
            if (sensors_0 == SensorsX.fuelUsage) FuelUsage = this.class18_0.GetInstantConsumption(VSS, RPM, (int)long_0);
        }
        catch { }
    }

    private void method_9(SensorsX sensors_0, byte byte_0)
    {
        try
        {
            if (sensors_0 == SensorsX.vssX) VSS = this.class18_0.method_197(byte_0);
            if (sensors_0 == SensorsX.gearX) Gear = byte_0;
            if (sensors_0 == SensorsX.mapX) Map = this.class18_0.method_193(byte_0);
            if (sensors_0 == SensorsX.boostX) {
                if (this.class18_0.method_206(byte_0) <= this.class10_settings_0.int_6) Boost = 0;
                else Boost = this.class18_0.method_193(byte_0);
            }
            if (sensors_0 == SensorsX.paX) PA = (int)Math.Round((double)((((byte_0 / 2) + 0x18) * 7.221) - 59.0), 0);
            if (sensors_0 == SensorsX.tpsX) TPS = this.class18_0.method_198(byte_0);
            if (sensors_0 == SensorsX.tpsV) TPSV = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.ignFnl) IgnFinal = this.class18_0.method_188(byte_0);
            if (sensors_0 == SensorsX.ignTbl) IgnTable = this.class18_0.method_188(byte_0);
            if (sensors_0 == SensorsX.ectX) ECT = (int) this.class18_0.method_191(byte_0);
            if (sensors_0 == SensorsX.iatX) IAT = (int) this.class18_0.method_191(byte_0);
            if(sensors_0 == SensorsX.afr) AFR = this.class18_0.method_200(byte_0);
            if (sensors_0 == SensorsX.ecuO2V) EcuO2V = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.wbO2V) WBV = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.batV) BatV = this.class18_0.method_208(byte_0);
            if (sensors_0 == SensorsX.eldV) ELDV = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.knockV) KnockV = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.mapV) MapV = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.mil) MIL = (byte_0 == 1);
            if (sensors_0 == SensorsX.ectFc) ECTFc = this.class18_0.method_205(byte_0, Enum6.const_1);
            if (sensors_0 == SensorsX.veFc) VEFc = this.class18_0.method_205(byte_0, Enum6.const_1);
            if (sensors_0 == SensorsX.ectIc) ECTIc = this.class18_0.method_189(byte_0);
            if (sensors_0 == SensorsX.iatIc) IATIc = this.class18_0.method_189(byte_0);
            if (sensors_0 == SensorsX.gearIc) GearIc = this.class18_0.method_189(byte_0);
            if (sensors_0 == SensorsX.gearFc) GearFc = this.class18_0.method_205(byte_0, Enum6.const_1);
            if (sensors_0 == SensorsX.postFuel) PostFuel = this.class18_0.method_258(byte_0, 0);
            if (sensors_0 == SensorsX.outIab) OutIAB = this.class18_0.method_258(byte_0, 2);
            if (sensors_0 == SensorsX.outVtsX) OutVTS = this.class18_0.method_258(byte_0, 7);
            if (sensors_0 == SensorsX.outVtsM) OutVTSM = this.class18_0.method_258(byte_0, 3);
            if (sensors_0 == SensorsX.outAc) OutAC = this.class18_0.method_258(byte_0, 7);
            if (sensors_0 ==  SensorsX.outO2h) OutO2H = this.class18_0.method_258(byte_0, 6);
            if (sensors_0 ==  SensorsX.outMil) OutMIL = this.class18_0.method_258(byte_0, 5);
            if (sensors_0 ==  SensorsX.outPurge) OutPurge = this.class18_0.method_258(byte_0, 6);
            if (sensors_0 ==  SensorsX.outFanc) OutFanC = this.class18_0.method_258(byte_0, 4);
            if (sensors_0 ==  SensorsX.outFpump) OutFPump = this.class18_0.method_258(byte_0, 0);
            if (sensors_0 ==  SensorsX.outFuelCut) OutFCut = (this.class18_0.method_258(byte_0, 4) || this.class18_0.method_258(byte_0, 5));
            if (sensors_0 ==  SensorsX.outAltCtrl) OutAltCtrl = this.class18_0.method_258(byte_0, 5);
            if (sensors_0 ==  SensorsX.inPsp) InPSP = this.class18_0.method_258(byte_0, 7);
            if (sensors_0 ==  SensorsX.inSCC) InSCC = this.class18_0.method_258(byte_0, 5);
            if (sensors_0 ==  SensorsX.inAccs) InACCs = this.class18_0.method_258(byte_0, 2);
            if (sensors_0 ==  SensorsX.inBksw) InBKSW = this.class18_0.method_258(byte_0, 1);
            if (sensors_0 ==  SensorsX.inVtp) InVTP = this.class18_0.method_258(byte_0, 3);
            if (sensors_0 ==  SensorsX.inVtsFeedBack) InVTSFB = this.class18_0.method_258(byte_0, 6);
            if (sensors_0 ==  SensorsX.inParkN) InParkN = this.class18_0.method_258(byte_0, 0);
            if (sensors_0 ==  SensorsX.inStartS) InStartS = this.class18_0.method_258(byte_0, 4);
            if (sensors_0 ==  SensorsX.inAtShift1) InATShift1 = this.class18_0.method_258(byte_0, 6);
            if (sensors_0 ==  SensorsX.inAtShift2) InATShift2 = this.class18_0.method_258(byte_0, 7);
            if (sensors_0 ==  SensorsX.secMaps) SecMap = this.class18_0.method_258(byte_0, 5);
            if (sensors_0 ==  SensorsX.ftlInput) InFTL = this.class18_0.method_258(byte_0, 0);
            if (sensors_0 ==  SensorsX.ftlActive) ActiveFTL = this.class18_0.method_258(byte_0, 0);
            if (sensors_0 ==  SensorsX.ftsClutchInput) InFTS = this.class18_0.method_258(byte_0, 1);
            if (sensors_0 ==  SensorsX.ftsActive) ActiveFTS = this.class18_0.method_258(byte_0, 2);
            if (sensors_0 ==  SensorsX.boostcutActive) ActiveBstCut = this.class18_0.method_258(byte_0, 3);
            if (sensors_0 ==  SensorsX.overheatActive) ActiveOverHeat = this.class18_0.method_258(byte_0, 6);
            if (sensors_0 ==  SensorsX.antilagActive) ActiveAntilag = this.class18_0.method_258(byte_0, 1);
            if (sensors_0 ==  SensorsX.ignitionCut) ICut = this.class18_0.method_258(byte_0, 2);
            if (sensors_0 ==  SensorsX.sccChecker) SCCChecker = this.class18_0.method_258(byte_0, 1);
            if (sensors_0 ==  SensorsX.ebcInput) InEBC = this.class18_0.method_258(byte_0, 2);
            if (sensors_0 ==  SensorsX.ebcHiInput) InEBCHi = this.class18_0.method_258(byte_0, 3);
            if (sensors_0 ==  SensorsX.ebcActive) ActiveEBC = this.class18_0.method_258(byte_0, 4);
            if (sensors_0 ==  SensorsX.ebcBaseDuty) EBCBaseDuty = this.class18_0.method_207(byte_0);
            if (sensors_0 ==  SensorsX.ebcDutyX) EBCDuty = this.class18_0.method_207(byte_0);
            if (sensors_0 ==  SensorsX.ebcTarget) EBCTarget = this.class18_0.method_245(this.class18_0.method_206(byte_0));
            if (sensors_0 ==  SensorsX.ebcCurrent) EBCCurrent = this.class18_0.method_245(this.class18_0.method_206(byte_0));
            if (sensors_0 ==  SensorsX.gpo1_in) InGPO1 = this.class18_0.method_258(byte_0, 4);
            if (sensors_0 ==  SensorsX.gpo1_out) OutGPO1 = this.class18_0.method_258(byte_0, 0);
            if (sensors_0 ==  SensorsX.gpo2_in) InGPO2 = this.class18_0.method_258(byte_0, 5);
            if (sensors_0 ==  SensorsX.gpo2_out) OutGPO2 = this.class18_0.method_258(byte_0, 1);
            if (sensors_0 ==  SensorsX.gpo3_in) InGPO3 = this.class18_0.method_258(byte_0, 6);
            if (sensors_0 ==  SensorsX.gpo3_out) OutGPO3 = this.class18_0.method_258(byte_0, 2);
            if (sensors_0 ==  SensorsX.fanCtrl) FanC = this.class18_0.method_258(byte_0, 6);
            if (sensors_0 ==  SensorsX.bstStage2) BSTS2 = this.class18_0.method_258(byte_0, 3);
            if (sensors_0 ==  SensorsX.bstStage3) BSTS3 = this.class18_0.method_258(byte_0, 4);
            if (sensors_0 ==  SensorsX.bstStage4) BSTS4 = this.class18_0.method_258(byte_0, 5);
            if (sensors_0 ==  SensorsX.bstActive) ActiveBST = this.class18_0.method_258(byte_0, 7);
            if (sensors_0 ==  SensorsX.bstInput) InBST = this.class18_0.method_258(byte_0, 7);
            if (sensors_0 ==  SensorsX.leanProtection) LeanProtect = this.class18_0.method_258(byte_0, 7);
            if ((this.class10_settings_0.bool_36) && sensors_0 == SensorsX.analog1) Analog1 = this.class18_0.method_201(AnalogInputs.analog1, byte_0);
            if ((this.class10_settings_0.bool_38) && sensors_0 == SensorsX.analog2) Analog2 = this.class18_0.method_201(AnalogInputs.analog2, byte_0);
            if ((this.class10_settings_0.bool_40) && sensors_0 == SensorsX.analog3) Analog3 = this.class18_0.method_201(AnalogInputs.analog3, byte_0);
            if (sensors_0 == SensorsX.accelTime) AccelTime = this.class18_0.AccelTime(this.class18_0.method_197(byte_0));
            if (sensors_0 == SensorsX.egrV) EGRV = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.b6V) B6V = this.class18_0.method_196(byte_0);
            if (sensors_0 == SensorsX.ectV)
            {
                ECTV = (5.0 - ((this.class18_0.method_191_GetTempInC(byte_0) + 40.0) / 36.0));
                //################
                //Calc Difference from 3.72v
                double Diff372v = ECTV - 3.72;
                if (Diff372v > 0) ECTV += (Diff372v / 3.2);
                if (Diff372v < 0) ECTV -= (-Diff372v / 4.2);
                //################
            }
            if (sensors_0 == SensorsX.iatV)
            {
                IATV = (5.0 - ((this.class18_0.method_191_GetTempInC(byte_0) + 40.0) / 36.0));
                //################
                //Calc Difference from 3.72v
                double Diff372v = IATV - 3.72;
                if (Diff372v > 0) IATV += (Diff372v / 3.2);
                if (Diff372v < 0) IATV -= (-Diff372v / 4.2);
                //################
            }

            if (sensors_0 == SensorsX.flexFuel) FlexFuel = (this.class18_0.method_196(byte_0) * 100.0) / 5.0;
        }
        catch { }
    }

    public double GetSensors_VALUE(SensorsX sensors_0)
    {
        double ThisValue = 0;
        if (sensors_0 == SensorsX.iacvDuty) ThisValue = IACVDuty;
        if (sensors_0 == SensorsX.rpmX) ThisValue = RPM;
        if (sensors_0 == SensorsX.injDur) ThisValue = InjDurr;
        if (sensors_0 == SensorsX.injDuty) ThisValue = InjDuty;
        if (sensors_0 == SensorsX.injFV) ThisValue = InjFV;
        if (sensors_0 == SensorsX.frame) ThisValue = Frame;
        if (sensors_0 == SensorsX.interval) ThisValue = Interval;
        if (sensors_0 == SensorsX.iatFc) ThisValue = IATFC;
        if (sensors_0 == SensorsX.o2Short) ThisValue = O2Short;
        if (sensors_0 == SensorsX.o2Long) ThisValue = O2Long;
        if (sensors_0 == SensorsX.fuelUsage) ThisValue = FuelUsage;
        if (sensors_0 == SensorsX.vssX) ThisValue = VSS;
        if (sensors_0 == SensorsX.gearX) ThisValue = Gear;
        if (sensors_0 == SensorsX.mapX) ThisValue = Map;
        if (sensors_0 == SensorsX.boostX) ThisValue = Boost;
        if (sensors_0 == SensorsX.paX) ThisValue = PA;
        if (sensors_0 == SensorsX.tpsX) ThisValue = TPS;
        if (sensors_0 == SensorsX.tpsV) ThisValue = TPSV;
        if (sensors_0 == SensorsX.ignFnl) ThisValue = IgnFinal;
        if (sensors_0 == SensorsX.ignTbl) ThisValue = IgnTable;
        if (sensors_0 == SensorsX.ectX) ThisValue = ECT;
        if (sensors_0 == SensorsX.iatX) ThisValue = IAT;
        if (sensors_0 == SensorsX.afr) ThisValue = AFR;
        if (sensors_0 == SensorsX.ecuO2V) ThisValue = EcuO2V;
        if (sensors_0 == SensorsX.wbO2V) ThisValue = WBV;
        if (sensors_0 == SensorsX.batV) ThisValue = BatV;
        if (sensors_0 == SensorsX.eldV) ThisValue = ELDV;
        if (sensors_0 == SensorsX.knockV) ThisValue = KnockV;
        if (sensors_0 == SensorsX.mapV) ThisValue = MapV;
        if (sensors_0 == SensorsX.mil) ThisValue = ConvertBooltoDouble(MIL);
        if (sensors_0 == SensorsX.ectFc) ThisValue = ECTFc;
        if (sensors_0 == SensorsX.veFc) ThisValue = VEFc;
        if (sensors_0 == SensorsX.ectIc) ThisValue = ECTIc;
        if (sensors_0 == SensorsX.iatIc) ThisValue = IATIc;
        if (sensors_0 == SensorsX.gearIc) ThisValue = GearIc;
        if (sensors_0 == SensorsX.gearFc) ThisValue = GearFc;
        if (sensors_0 == SensorsX.postFuel) ThisValue = ConvertBooltoDouble(PostFuel);
        if (sensors_0 == SensorsX.outIab) ThisValue = ConvertBooltoDouble(OutIAB);
        if (sensors_0 == SensorsX.outVtsX) ThisValue = ConvertBooltoDouble(OutVTS);
        if (sensors_0 == SensorsX.outVtsM) ThisValue = ConvertBooltoDouble(OutVTSM);
        if (sensors_0 == SensorsX.outAc) ThisValue = ConvertBooltoDouble(OutAC);
        if (sensors_0 == SensorsX.outO2h) ThisValue = ConvertBooltoDouble(OutO2H);
        if (sensors_0 == SensorsX.outMil) ThisValue = ConvertBooltoDouble(OutMIL);
        if (sensors_0 == SensorsX.outPurge) ThisValue = ConvertBooltoDouble(OutPurge);
        if (sensors_0 == SensorsX.outFanc) ThisValue = ConvertBooltoDouble(OutFanC);
        if (sensors_0 == SensorsX.outFpump) ThisValue = ConvertBooltoDouble(OutFPump);
        if (sensors_0 == SensorsX.outFuelCut) ThisValue = ConvertBooltoDouble(OutFCut);
        if (sensors_0 == SensorsX.outAltCtrl) ThisValue = ConvertBooltoDouble(OutAltCtrl);
        if (sensors_0 == SensorsX.inPsp) ThisValue = ConvertBooltoDouble(InPSP);
        if (sensors_0 == SensorsX.inSCC) ThisValue = ConvertBooltoDouble(InSCC);
        if (sensors_0 == SensorsX.inAccs) ThisValue = ConvertBooltoDouble(InACCs);
        if (sensors_0 == SensorsX.inBksw) ThisValue = ConvertBooltoDouble(InBKSW);
        if (sensors_0 == SensorsX.inVtp) ThisValue = ConvertBooltoDouble(InVTP);
        if (sensors_0 == SensorsX.inVtsFeedBack) ThisValue = ConvertBooltoDouble(InVTSFB);
        if (sensors_0 == SensorsX.inParkN) ThisValue = ConvertBooltoDouble(InParkN);
        if (sensors_0 == SensorsX.inStartS) ThisValue = ConvertBooltoDouble(InStartS);
        if (sensors_0 == SensorsX.inAtShift1) ThisValue = ConvertBooltoDouble(InATShift1);
        if (sensors_0 == SensorsX.inAtShift2) ThisValue = ConvertBooltoDouble(InATShift2);
        if (sensors_0 == SensorsX.secMaps) ThisValue = ConvertBooltoDouble(SecMap);
        if (sensors_0 == SensorsX.ftlInput) ThisValue = ConvertBooltoDouble(InFTL);
        if (sensors_0 == SensorsX.ftlActive) ThisValue = ConvertBooltoDouble(ActiveFTL);
        if (sensors_0 == SensorsX.ftsClutchInput) ThisValue = ConvertBooltoDouble(InFTS);
        if (sensors_0 == SensorsX.ftsActive) ThisValue = ConvertBooltoDouble(ActiveFTS);
        if (sensors_0 == SensorsX.boostcutActive) ThisValue = ConvertBooltoDouble(ActiveBstCut);
        if (sensors_0 == SensorsX.overheatActive) ThisValue = ConvertBooltoDouble(ActiveOverHeat);
        if (sensors_0 == SensorsX.antilagActive) ThisValue = ConvertBooltoDouble(ActiveAntilag);
        if (sensors_0 == SensorsX.ignitionCut) ThisValue = ConvertBooltoDouble(ICut);
        if (sensors_0 == SensorsX.sccChecker) ThisValue = ConvertBooltoDouble(SCCChecker);
        if (sensors_0 == SensorsX.ebcInput) ThisValue = ConvertBooltoDouble(InEBC);
        if (sensors_0 == SensorsX.ebcHiInput) ThisValue = ConvertBooltoDouble(InEBCHi);
        if (sensors_0 == SensorsX.ebcActive) ThisValue = ConvertBooltoDouble(ActiveEBC);
        if (sensors_0 == SensorsX.ebcBaseDuty) ThisValue = EBCBaseDuty;
        if (sensors_0 == SensorsX.ebcDutyX) ThisValue = EBCDuty;
        if (sensors_0 == SensorsX.ebcTarget) ThisValue = EBCTarget;
        if (sensors_0 == SensorsX.ebcCurrent) ThisValue = EBCCurrent;
        if (sensors_0 == SensorsX.gpo1_in) ThisValue = ConvertBooltoDouble(InGPO1);
        if (sensors_0 == SensorsX.gpo1_out) ThisValue = ConvertBooltoDouble(OutGPO1);
        if (sensors_0 == SensorsX.gpo2_in) ThisValue = ConvertBooltoDouble(InGPO2);
        if (sensors_0 == SensorsX.gpo2_out) ThisValue = ConvertBooltoDouble(OutGPO2);
        if (sensors_0 == SensorsX.gpo3_in) ThisValue = ConvertBooltoDouble(InGPO3);
        if (sensors_0 == SensorsX.gpo3_out) ThisValue = ConvertBooltoDouble(OutGPO3);
        if (sensors_0 == SensorsX.fanCtrl) ThisValue = ConvertBooltoDouble(FanC);
        if (sensors_0 == SensorsX.bstStage2) ThisValue = ConvertBooltoDouble(BSTS2);
        if (sensors_0 == SensorsX.bstStage3) ThisValue = ConvertBooltoDouble(BSTS3);
        if (sensors_0 == SensorsX.bstStage4) ThisValue = ConvertBooltoDouble(BSTS4);
        if (sensors_0 == SensorsX.bstActive) ThisValue = ConvertBooltoDouble(ActiveBST);
        if (sensors_0 == SensorsX.bstInput) ThisValue = ConvertBooltoDouble(InBST);
        if (sensors_0 == SensorsX.leanProtection) ThisValue = ConvertBooltoDouble(LeanProtect);
        if ((this.class10_settings_0.bool_36) && sensors_0 == SensorsX.analog1) ThisValue = Analog1;
        if ((this.class10_settings_0.bool_38) && sensors_0 == SensorsX.analog2) ThisValue = Analog2;
        if ((this.class10_settings_0.bool_40) && sensors_0 == SensorsX.analog3) ThisValue = Analog3;
        if (sensors_0 == SensorsX.accelTime) ThisValue = AccelTime;
        if (sensors_0 == SensorsX.egrV) ThisValue = EGRV;
        if (sensors_0 == SensorsX.b6V) ThisValue = B6V;
        if (sensors_0 == SensorsX.ectV) ThisValue = ECTV;
        if (sensors_0 == SensorsX.iatV) ThisValue = IATV;

        if (sensors_0 == SensorsX.flexFuel) ThisValue = FlexFuel;

        return ThisValue;
    }

    public Color GetSensorColor(SensorsX sensors_0)
    {
        return this.class18_0.method_234(GetSensors_VALUE(sensors_0), (double)this.class10_settings_0.method_20(sensors_0), (double)this.class10_settings_0.method_22(sensors_0));
    }

    public string GetSensors_STRING(SensorsX sensors_0)
    {
        string RString = "";
        double SensorValue = GetSensors_VALUE(sensors_0);

        if (sensors_0 == SensorsX.iacvDuty) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.rpmX) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.injDur) RString = SensorValue.ToString("0.00") + " ms";
        if (sensors_0 == SensorsX.injDuty) RString = SensorValue + " %";
        if (sensors_0 == SensorsX.injFV) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.frame) RString = SensorValue.ToString("0");
        //if (sensors_0 == Sensors.duration) RString = Get_Sensors_Long_STRING(sensors_0, struct12_0.long_3);
        if (sensors_0 == SensorsX.duration) RString = Duration;
        if (sensors_0 == SensorsX.interval) RString = SensorValue + " mS";
        if (sensors_0 == SensorsX.iatFc)
        {
            if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi) RString = SensorValue.ToString("0");
            else RString = SensorValue.ToString("0.00");
        }
        if (sensors_0 == SensorsX.o2Short)
        {
            if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi) RString = SensorValue.ToString("0");
            else RString = SensorValue.ToString("0.00");
        }
        if (sensors_0 == SensorsX.o2Long)
        {
            if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi) RString = SensorValue.ToString("0");
            else RString = SensorValue.ToString("0.00");
        }
        if (sensors_0 == SensorsX.fuelUsage) RString = SensorValue.ToString("0.00");

        //###########################################################################

        if (sensors_0 == SensorsX.vssX) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.gearX) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.mapX)
        {
            if (this.class10_settings_0.mapSensorUnits_0 != MapSensorUnits.mBar) RString = SensorValue.ToString("0.00") + this.class10_settings_0.mapSensorUnits_0.ToString();
            else RString = SensorValue.ToString("0") + this.class10_settings_0.mapSensorUnits_0.ToString();
        }
        if (sensors_0 == SensorsX.boostX)
        {
            if (this.class10_settings_0.mapSensorUnits_1 != MapSensorUnits.mBar) RString = SensorValue.ToString("0.00") + this.class10_settings_0.mapSensorUnits_1.ToString();
            else RString = SensorValue.ToString("0") + this.class10_settings_0.mapSensorUnits_1.ToString();
        }
        if (sensors_0 == SensorsX.paX) RString = SensorValue.ToString("0") + " mBar";
        if (sensors_0 == SensorsX.tpsX) RString = SensorValue.ToString("0") + " %";
        if (sensors_0 == SensorsX.tpsV) RString = SensorValue.ToString("0.00") + " V";
        if (sensors_0 == SensorsX.ignFnl) RString = SensorValue.ToString("0.00") + " \x00b0";
        if (sensors_0 == SensorsX.ignTbl) RString = SensorValue.ToString("0.00") + " \x00b0";
        if (sensors_0 == SensorsX.ectX) RString = SensorValue.ToString("0.00") + " \x00b0" + this.class10_settings_0.temperatureUnits_0.ToString();
        if (sensors_0 == SensorsX.iatX) RString = SensorValue.ToString("0.00") + " \x00b0" + this.class10_settings_0.temperatureUnits_0.ToString();
        if (sensors_0 == SensorsX.afr) RString = SensorValue.ToString("0.00") + " " + this.class10_settings_0.airFuelUnits_0.ToString();
        if (sensors_0 == SensorsX.ecuO2V) RString = SensorValue.ToString("0.00") + " V";
        if (sensors_0 == SensorsX.wbO2V) RString = SensorValue.ToString("0.00") + " V";
        if (sensors_0 == SensorsX.batV) RString = SensorValue.ToString("0.00") + " V";
        if (sensors_0 == SensorsX.eldV) RString = SensorValue.ToString("0.00") + " V";
        if (sensors_0 == SensorsX.knockV) RString = SensorValue.ToString("0.00") + " V";
        if (sensors_0 == SensorsX.mapV) RString = SensorValue.ToString("0.00") + " V";
        if (sensors_0 == SensorsX.mil) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ectFc)
        {
            if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi) RString = SensorValue.ToString("0");
            else RString = SensorValue.ToString("0.00");
        }
        if (sensors_0 == SensorsX.veFc)
        {
            if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi) RString = SensorValue.ToString("0");
            else RString = SensorValue.ToString("0.00");
        }
        if (sensors_0 == SensorsX.ectIc) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.iatIc) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.gearIc) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.gearFc)
        {
            if (this.class10_settings_0.correctionUnits_0 != CorrectionUnits.multi) RString = SensorValue.ToString("0");
            else RString = SensorValue.ToString("0.00");
        }
        if (sensors_0 == SensorsX.postFuel) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outIab) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outVtsX) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outVtsM) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outAc) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outO2h) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outMil) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outPurge) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outFanc) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outFpump) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outFuelCut) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.outAltCtrl) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inPsp) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inSCC) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inAccs) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inBksw) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inVtp) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inVtsFeedBack) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inParkN) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inStartS) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inAtShift1) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.inAtShift2) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.secMaps) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ftlInput) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ftlActive) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ftsClutchInput) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ftsActive) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.boostcutActive) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.overheatActive) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.antilagActive) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ignitionCut) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.sccChecker) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ebcInput) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ebcHiInput) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ebcActive) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.ebcBaseDuty) RString = SensorValue.ToString("0.00") + " %";
        if (sensors_0 == SensorsX.ebcDutyX) RString = SensorValue.ToString("0.00") + " %";
        if (sensors_0 == SensorsX.ebcTarget) RString = SensorValue.ToString("0.00") + " psi";
        if (sensors_0 == SensorsX.ebcCurrent) RString = SensorValue.ToString("0.00") + " psi";
        if (sensors_0 == SensorsX.gpo1_in) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.gpo1_out) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.gpo2_in) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.gpo2_out) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.gpo3_in) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.gpo3_out) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.fanCtrl) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.bstStage2) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.bstStage3) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.bstStage4) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.bstActive) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.bstInput) RString = SensorValue.ToString("0");
        if (sensors_0 == SensorsX.leanProtection) RString = SensorValue.ToString("0");
        if ((this.class10_settings_0.bool_36) && sensors_0 == SensorsX.analog1) RString = SensorValue.ToString("0.00");
        if ((this.class10_settings_0.bool_38) && sensors_0 == SensorsX.analog2) RString = SensorValue.ToString("0.00");
        if ((this.class10_settings_0.bool_40) && sensors_0 == SensorsX.analog3) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.accelTime) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.egrV) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.b6V) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.ectV) RString = SensorValue.ToString("0.00");
        if (sensors_0 == SensorsX.iatV) RString = SensorValue.ToString("0.00");

        if (sensors_0 == SensorsX.flexFuel) RString = SensorValue.ToString("0.00") + " %";

        return RString;
    }
}

