using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

internal class Binary_Files
{
    public List<byte[]> ThisBytesL = new List<byte[]>();
    public List<byte[]> ThisBytesL_NOMOD = new List<byte[]>();
    private List<bool> ThisStableL = new List<bool>();
    public Collection<Class1_Version> class1_Version_0 = new Collection<Class1_Version>();
    private int CurrentInt = 0;
    private Class18 Class18_0;
    public string Changelogs = "";
    private bool LoadFromFolder = true;

    public void Load(ref Class18 Class18_1)
    {
        Class18_0 = Class18_1;

        //######################################################################################
        //SET THIS TO TRUE TO LOAD CURRENT DEVELOPEMENT BINARY FROM FOLDER RATHER THAN INTERNAL
        LoadFromFolder = true;
        //this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.DeleteTEMPFolder("Baseroms");

        //#######################################
        //NO IGNITION CUT MODDED BASEROM LIST
        ThisBytesL_NOMOD.Clear();
        ThisBytesL_NOMOD.Add(new byte[] { });
        ThisBytesL_NOMOD.Add(new byte[] { });
        ThisBytesL_NOMOD.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.2_NO_MOD.bin"));
        ThisBytesL_NOMOD.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.3_NO_MOD.bin"));
        ThisBytesL_NOMOD.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.4_NO_MOD.bin"));
        ThisBytesL_NOMOD.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.5_NO_MOD.bin"));
        ThisBytesL_NOMOD.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.6_NO_MOD.bin"));
        ThisBytesL_NOMOD.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.7_NO_MOD.bin"));
        ThisBytesL_NOMOD.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.8_NO_MOD.bin"));
        //#######################################

        ThisBytesL.Clear();
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.0.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.1.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.2.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.3.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.4.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.5.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.6.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.7.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.8.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.0.9.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.0.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.1.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.2.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.3.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.4.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.5.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.6.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.7.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.8.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.1.9.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.2.0.bin"));
        ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.2.1.bin"));
        //ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.2.2.bin"));
        //ThisBytesL.Add(this.Class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Baseroms", "BMTune_V1.2.3.bin"));

        //#################################
        if (this.Class18_0.class15_0.string_CurrentID != null && this.Class18_0.class15_0.string_CurrentID == this.Class18_0.class15_0.BMIDDD)
        {
            if (LoadFromFolder)
            {
                ThisBytesL.RemoveAt(ThisBytesL.Count - 1);
                //ThisBytesL.Add(File.ReadAllBytes(Application.StartupPath + @"\TEST.bin"));
                ThisBytesL.Add(File.ReadAllBytes(@"C:\Users\boule\Desktop\BM Devs\asm-dasm662\BMTune Update\DONE\1.09\BMTune_V1.2.1.bin"));
            }
        }
        //#################################

        ThisStableL.Clear();
        ThisStableL.Add(true);      //1.00
        ThisStableL.Add(true);      //1.01
        ThisStableL.Add(true);      //1.02
        ThisStableL.Add(true);      //1.03
        ThisStableL.Add(false);      //1.04
        ThisStableL.Add(true);      //1.05
        ThisStableL.Add(true);      //1.06
        ThisStableL.Add(true);      //1.07
        ThisStableL.Add(true);      //1.08
        ThisStableL.Add(true);      //1.09
        ThisStableL.Add(true);      //1.10
        ThisStableL.Add(false);      //1.11
        ThisStableL.Add(false);      //1.12
        ThisStableL.Add(true);      //1.13
        ThisStableL.Add(true);      //1.14
        ThisStableL.Add(true);      //1.15
        ThisStableL.Add(true);      //1.16
        ThisStableL.Add(true);      //1.17
        ThisStableL.Add(true);      //1.18
        ThisStableL.Add(true);      //1.19
        ThisStableL.Add(true);      //1.20
        ThisStableL.Add(true);      //1.21
        //ThisStableL.Add(true);      //1.22
        //ThisStableL.Add(true);      //1.23

        ReloadVersion();

        Changelogs = "";
        Changelogs += "V1.00" + Environment.NewLine;
        Changelogs += "Original baserom of BMTune" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.01" + Environment.NewLine;
        Changelogs += "Added FTS VSS (Speed) condition to make it activated or not." + Environment.NewLine;
        Changelogs += "Without this condition, the FTS was activating over the FTL" + Environment.NewLine;
        Changelogs += "when trying to only use the FTL." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.02" + Environment.NewLine;
        Changelogs += "Added ECT, IAT and VSS Error Code Disabling" + Environment.NewLine;
        Changelogs += "The protocol to disable these errors aren't to the point." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "When you disable these errors, the sensor value will go directly" + Environment.NewLine;
        Changelogs += "at the desired choosen value even if the sensor are working. So" + Environment.NewLine;
        Changelogs += "do not disable these errors if you have the sensor inplace and working." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.03" + Environment.NewLine;
        Changelogs += "Added Ignition Cut Delay" + Environment.NewLine;
        Changelogs += "You can now choose the amount of milliseconds you want to cut the ignition" + Environment.NewLine;
        Changelogs += "on the rev limiter, the ftl, fts, etc." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "The Ignition Cut Delay has later been reported to cause wierd acting" + Environment.NewLine;
        Changelogs += "rev limiter has when we set the delay, we generally set it on neutral," + Environment.NewLine;
        Changelogs += "when the engine can rev easily. So when we are getting into gears," + Environment.NewLine;
        Changelogs += "with the force inertia it require to forward, it make the limiter act differently." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "If you intend to use this baserom, be advised that cutting the ignition" + Environment.NewLine;
        Changelogs += "over a time reset rather than a rpm reset aren't always acting as desired." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.04 - Unstable" + Environment.NewLine;
        Changelogs += "Added Antitheft code but the baserom has never been tested before getting" + Environment.NewLine;
        Changelogs += "released. The Fuel Cut and/or Ignition Cut doesn't works as intended." + Environment.NewLine;
        Changelogs += "You might not have FTS, FTL, Rev Limiter or anything that implement" + Environment.NewLine;
        Changelogs += "Fuel or Ignition Cut." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.05" + Environment.NewLine;
        Changelogs += "Fixed the Rev Limiter bug known under baserom V1.04." + Environment.NewLine;
        Changelogs += "No others additions has been implemented in this version." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.06" + Environment.NewLine;
        Changelogs += "Removed the Ignition Cut Delay due to the bug known in baserom V1.03." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "This baserom is basicly a restart from baserom V1.02 and including Antitheft." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.07" + Environment.NewLine;
        Changelogs += "New IAT and VSS Disable Error protocol" + Environment.NewLine;
        Changelogs += "Due to bugs known in baserom V1.02, the protocol to disable" + Environment.NewLine;
        Changelogs += "these errors codes has been redone." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "You can now disable these errors while having the sensor working" + Environment.NewLine;
        Changelogs += "and inplace. If the sensor are working, it should read from the sensor" + Environment.NewLine;
        Changelogs += "and if its not working, it wont display any CEL codes but it will" + Environment.NewLine;
        Changelogs += "set the value at the desired choosen value." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.08" + Environment.NewLine;
        Changelogs += "Added Ignition Strain Cut Delay for FTS" + Environment.NewLine;
        Changelogs += "With the Ignition Cut Delay bug occured in version V1.03, the delay" + Environment.NewLine;
        Changelogs += "has been removed in baserom V1.06 but was a good feature the the FTS." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "The Ignition Cut Delay has been re-implemented but only for the FTS." + Environment.NewLine;
        Changelogs += "It can also be enabled or disabled for even greater control on your FTS." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.09" + Environment.NewLine;
        Changelogs += "This is a reworked V1.06 baserom." + Environment.NewLine;
        Changelogs += "The Antitheft, ECT, IAT, VSS and Ignition Cut Delay codes as been recoded." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "The Ignition Cut Delay has been re-implemented back again for all kinds of" + Environment.NewLine;
        Changelogs += "cutting type (launch, fts, rev limiter, etc) and also now as static ignition" + Environment.NewLine;
        Changelogs += "feature when its cutting ignition and fuel enrichment too." + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.10" + Environment.NewLine;
        Changelogs += "Added FTS Antilag Static Ignition" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.11" + Environment.NewLine;
        Changelogs += "Added Flex Fuel" + Environment.NewLine;
        Changelogs += "Added TPS Error Disable" + Environment.NewLine;
        Changelogs += "Fixed Reset RPM when only on ignition cut" + Environment.NewLine;
        Changelogs += "Fixed ECT, IAT, VSS Disable" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.12" + Environment.NewLine;
        Changelogs += "Fixed Ignition Sync/Lock" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.13" + Environment.NewLine;
        Changelogs += "Added Ignition Cut Timers again" + Environment.NewLine;
        Changelogs += "Fixed Rev Limiter" + Environment.NewLine;
        Changelogs += "Fixed Fuel Cut" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.14" + Environment.NewLine;
        Changelogs += "New Ignition Cut Script" + Environment.NewLine;
        Changelogs += "Added 'Enable' Ign Cut Time Mod" + Environment.NewLine;
        Changelogs += "Fixed Possible Issue with Flex Fuel" + Environment.NewLine;
        Changelogs += "Fixed Password Protection" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.15" + Environment.NewLine;
        Changelogs += "New Ignition Cut Script" + Environment.NewLine;
        Changelogs += "Ignition should cut with RPM Reset Windows" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.16" + Environment.NewLine;
        Changelogs += "Added Flex Fuel Cranking Compensation" + Environment.NewLine;
        Changelogs += "Added CPR(Coil Pack Retrofit) Outputs" + Environment.NewLine;
        Changelogs += "Added IgnCut on Decel" + Environment.NewLine;
        Changelogs += "Compacted Rom for more space" + Environment.NewLine;
        Changelogs += "Compatibility Check" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.17" + Environment.NewLine;
        Changelogs += "Fixed Launch, FTS & Rev Limiter IGN Cut Time" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.18" + Environment.NewLine;
        Changelogs += "Added Input Selection for Ignition Cut" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.19" + Environment.NewLine;
        Changelogs += "Added MIL on Ignition Cut feature" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.20" + Environment.NewLine;
        Changelogs += "Added VTS Test Output" + Environment.NewLine;
        Changelogs += "Added Fuel Pump Test Output" + Environment.NewLine;
        Changelogs += "Added A10 Test Output" + Environment.NewLine;
        Changelogs += "Added AC Test Output" + Environment.NewLine;
        Changelogs += "Added PCS Test Output" + Environment.NewLine;
        Changelogs += "Added IAB Test Output" + Environment.NewLine;
        Changelogs += "Added FANC Test Output" + Environment.NewLine;
        Changelogs += "Added ALTC Test Output" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.21" + Environment.NewLine;
        Changelogs += "Fixed broken reference" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;

        /*Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.22" + Environment.NewLine;
        Changelogs += "xxx" + Environment.NewLine;
        Changelogs += "xxx" + Environment.NewLine;
        Changelogs += "xxx" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;*/

        /*Changelogs += "--------------------------------------------------" + Environment.NewLine;
        Changelogs += "V1.23" + Environment.NewLine;
        Changelogs += "xxx" + Environment.NewLine;
        Changelogs += "xxx" + Environment.NewLine;
        Changelogs += "xxx" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;
        Changelogs += "" + Environment.NewLine;*/

        Changelogs += "" + Environment.NewLine;
        Changelogs += "©BMTune, LLC (BMDevs) 2017-2021" + Environment.NewLine;
        
    }

    public void ReloadVersion()
    {
        class1_Version_0.Clear();
        CurrentInt = 0;

        Class1_Version class1_Version_1 = new Class1_Version { Version = 100, Stable = ThisStableL[CurrentInt], Infos = "Original Baserom" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 101, Stable = ThisStableL[CurrentInt], Infos = "Added FTS Speed Condition" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 102, Stable = ThisStableL[CurrentInt], Infos = "Added ECT, IAT, VSS Error" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 103, Stable = ThisStableL[CurrentInt], Infos = "Added Ignition Cut Delay" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 104, Stable = ThisStableL[CurrentInt], Infos = "UNSTABLE Anti-Theft(no rev limiter)" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 105, Stable = ThisStableL[CurrentInt], Infos = "Added/Fixed Anti-Theft" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 106, Stable = ThisStableL[CurrentInt], Infos = "Ignition Cut Delay Excluded" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 107, Stable = ThisStableL[CurrentInt], Infos = "New IAT and VSS Disable Error Code" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 108, Stable = ThisStableL[CurrentInt], Infos = "Added Ignition Cut Delay for FTS ONLY" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 109, Stable = ThisStableL[CurrentInt], Infos = "Reworked Baserom" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 110, Stable = ThisStableL[CurrentInt], Infos = "Added FTS Antilag Static Ignition" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 111, Stable = ThisStableL[CurrentInt], Infos = "Added Flex Fuel, TPS Disable" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 112, Stable = ThisStableL[CurrentInt], Infos = "Fixed Ignition Sync/Lock" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 113, Stable = ThisStableL[CurrentInt], Infos = "Fixed Rev Limiter" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 114, Stable = ThisStableL[CurrentInt], Infos = "Added 'Enable' Ign Cut Time Mod" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 115, Stable = ThisStableL[CurrentInt], Infos = "New Ignition Cut (Reset RPM fix)" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 116, Stable = ThisStableL[CurrentInt], Infos = "Reworked Baserom" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 117, Stable = ThisStableL[CurrentInt], Infos = "Fixed Launch, FTS & Rev Limiter IGN Cut Time" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 118, Stable = ThisStableL[CurrentInt], Infos = "Added Input Selection For Ignition Cut" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 119, Stable = ThisStableL[CurrentInt], Infos = "Added MIL on Ignition Cut feature" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 120, Stable = ThisStableL[CurrentInt], Infos = "Added severals Test Outputs" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        class1_Version_1 = new Class1_Version { Version = 121, Stable = ThisStableL[CurrentInt], Infos = "Fixed broken reference" };
        this.class1_Version_0.Add(class1_Version_1);
        CurrentInt++;

        //class1_Version_1 = new Class1_Version { Version = 122, Stable = ThisStableL[CurrentInt], Infos = "" };
        //this.class1_Version_0.Add(class1_Version_1);
        //CurrentInt++;

        //class1_Version_1 = new Class1_Version { Version = 123, Stable = ThisStableL[CurrentInt], Infos = "" };
        //this.class1_Version_0.Add(class1_Version_1);
        //CurrentInt++;
    }

    public int GetLastStable()
    {
        int Stable_Version_LAST = 0;
        for (int i = 0; i < ThisStableL.Count; i++)
            if (ThisStableL[i] == true) Stable_Version_LAST = i;

        return Stable_Version_LAST;
    }

    public bool IsStable(int TVersion)
    {
        bool ISAStable = true;

        if (TVersion <= ThisStableL.Count - 1) ISAStable = ThisStableL[TVersion];
        return ISAStable;
    }

    public byte[] ThisBytes109_Reload = new byte[]
    {
        0xFF, 0x8C, 0x00, 0xFF, 0x8C, 0x00, 0xFF, 0x8C,
        0x00, 0xD9, 0x8C, 0x00, 0x26, 0x00, 0x00, 0x00,
        0x00, 0x00,

        0xFF, 0xD9, 0xD9, 0xD9, 0x26, 0x26, 0x00, 0x00,

        0xFF, 0x18, 0xFF, 0x18, 0xFF, 0x18, 0xD9, 0x18,
        0x26, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF
    };

    public byte[] ThisBytes116_Reload = new byte[]
    {
        0xFF, 0x00, 0x00, 0xD9, 0x00, 0x00, 0x99, 0x00,
        0x00, 0x4C, 0x00, 0x00, 0x19, 0x00, 0x00, 0x00,
        0x00, 0x00
    };
}