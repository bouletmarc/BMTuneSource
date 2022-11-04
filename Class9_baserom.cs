using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;

internal class Class9_baserom
{
    public Collection<Class8_u> class8_u_0 = new Collection<Class8_u>();
    public Collection<Class8_v> class8_v_0 = new Collection<Class8_v>();
    public Collection<Class1_u> class1_u_0 = new Collection<Class1_u>();
    private Class18 class18_0;

    public Class9_baserom(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;

        //this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.DeleteTEMPFolder("ECUS");
        //this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.DeleteTEMPFolder("Calibrations");

        this.method_0();
        this.method_1();

        ClearBMTuneFolder();
    }

    public void ClearBMTuneFolder()
    {
        if (Directory.Exists(Application.StartupPath + "\\Baseroms")) Directory.Delete(Application.StartupPath + "\\Baseroms", true);
        if (Directory.Exists(Application.StartupPath + "\\Calibrations")) Directory.Delete(Application.StartupPath + "\\Calibrations", true);
        if (Directory.Exists(Application.StartupPath + "\\ECUS")) Directory.Delete(Application.StartupPath + "\\ECUS", true);

        string FPath = "";
        /*for (int i = 0; i < this.class8_v_0.Count; i++)
        {
            FPath = Application.StartupPath + "\\Baseroms\\" + this.class8_v_0[i].string_4 + ".bin";
            FileInfo info = new FileInfo(FPath);
            if (info.Exists) info.Delete();
            info = null;
        }
        for (int i = 0; i < this.class8_u_0.Count; i++)
        {
            FPath = Application.StartupPath + "\\Baseroms\\" + this.class8_u_0[i].string_4 + ".bin";
            FileInfo info = new FileInfo(FPath);
            if (info.Exists) info.Delete();
            info = null;
        }*/

        FPath = Application.StartupPath + "New baserom.bin";
        FileInfo info2 = new FileInfo(FPath);
        if (info2.Exists) info2.Delete();
        info2 = null;
    }

    private void method_0()
    {
        //#########################
        /*item = new Class8_u
        {
            string_1 = "231",
            string_0 = "P05",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "D15B8",
            IsVTEC = false,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,
            IsCrypted = false,

            int_0 = 1,
            byte_0 = new byte[] {
                0x00, 0x00
            }
        };
        this.collection_0.Add(item);*/
        //#########################

        //THIS IS ALL ORIGNAL/OEM ECU TABLES

        Class8_u class8_u_1 = new Class8_u
        {
            string_1 = "231",
            string_0 = "P05",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "D15B8",
            IsVTEC = false,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,

            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);


        class8_u_1 = new Class8_u {
            string_1 = "313",
            string_0 = "P06",
            string_3 = "EDM",
            string_2 = "",
            string_4 = "D15B7",
            IsVTEC = false,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,
            
            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u {
            string_1 = "301",
            string_0 = "P06",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "D15B7",
            IsVTEC = false,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,
            
            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "303",
            string_0 = "P07",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "D15Z1 Vtec-e",
            IsVTEC = true,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,

            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################


        class8_u_1 = new Class8_u {
            string_1 = "237",
            string_0 = "P08",
            string_3 = "JDM",
            string_2 = "",
            string_4 = "D15B Vtec",
            IsVTEC = true,
            RpmLowSet = 0x1cf3,
            RpmLowReset = 0x1c8f,
            RpmHighSet = 0x1cf3,
            RpmHighReset = 0x1c8f,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,
            
            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u
        {
            string_1 = "",
            string_0 = "P13",
            string_3 = "",
            string_2 = "290cc",
            string_4 = "H22 97+",
            IsVTEC = true,
            RpmLowSet = 0x1cf3,
            RpmLowReset = 0x1c8f,
            RpmHighSet = 0x1cf3,
            RpmHighReset = 0x1c8f,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 7,
            int_1 = 290,
            int_2 = 290,
            int_3 = 4,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u
        {
            string_1 = "",
            string_0 = "P13",
            string_3 = "",
            string_2 = "330cc",
            string_4 = "H22 92-96",
            IsVTEC = true,
            RpmLowSet = 0x1cf3,
            RpmLowReset = 0x1c8f,
            RpmHighSet = 0x1cf3,
            RpmHighReset = 0x1c8f,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 6,
            int_1 = 330,
            int_2 = 330,
            int_3 = 2,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u
        {
            string_1 = "",
            string_0 = "P14",
            string_3 = "",
            string_2 = "",
            string_4 = "H23A 92-95",
            IsVTEC = true,
            RpmLowSet = 0x1cf3,
            RpmLowReset = 0x1c8f,
            RpmHighSet = 0x1cf3,
            RpmHighReset = 0x1c8f,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 6,
            int_1 = 330,
            int_2 = 330,
            int_3 = 2,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u {
            string_1 = "304",
            string_0 = "P28",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "D16Z6",
            IsVTEC = true,
            RpmLowSet = 0x1cf3,
            RpmLowReset = 0x1c8f,
            RpmHighSet = 0x1cf3,
            RpmHighReset = 0x1c8f,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,
            
            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);


        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "202",
            string_0 = "P29",
            string_3 = "USDM",
            string_2 = "DOHC",
            string_4 = "D16A-ZC",
            IsVTEC = false,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,

            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################

        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "224",
            string_0 = "P29",
            string_3 = "EDM",
            string_2 = "DOHC",
            string_4 = "D16A9-ZC",
            IsVTEC = false,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,

            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################


        class8_u_1 = new Class8_u {
            string_1 = "203",
            string_0 = "P30",
            string_3 = "JDM",
            string_2 = "",
            string_4 = "B16A",
            IsVTEC = true,
            RpmLowSet = 0x2068,
            RpmLowReset = 0x2004,
            RpmHighSet = 0x2068,
            RpmHighReset = 0x2004,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u {
            string_1 = "209",
            string_0 = "P30",
            string_3 = "EDM",
            string_2 = "",
            string_4 = "B16A",
            IsVTEC = true,
            RpmLowSet = 0x1fb4,
            RpmLowReset = 0x1f50,
            RpmHighSet = 0x1fb4,
            RpmHighReset = 0x1f50,
            VtcLow = 0x16f3,
            VtcHigh = 0x14ff,
            
            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);


        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "215",
            string_0 = "P61",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "B17A",
            IsVTEC = true,
            RpmLowSet = 0x2198,
            RpmLowReset = 0x214a,
            RpmHighSet = 0x2198,
            RpmHighReset = 0x214a,
            VtcLow = 0x130b,
            VtcHigh = 0x130b,

            int_0 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################

        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "259",
            string_0 = "P70",
            string_3 = "JDM",
            string_2 = "SOHC-Domani",
            string_4 = "D16A-ZC",
            IsVTEC = true,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,

            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################

        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "269",
            string_0 = "P72",
            string_3 = "JDM",
            string_2 = "",
            string_4 = "B18C4",
            IsVTEC = true,
            RpmLowSet = 0x2198,
            RpmLowReset = 0x214a,
            RpmHighSet = 0x2198,
            RpmHighReset = 0x214a,
            VtcLow = 0x130b,
            VtcHigh = 0x130b,

            int_0 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################

        class8_u_1 = new Class8_u {
            string_1 = "273",
            string_0 = "P72",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "B18C1-3",
            IsVTEC = true,
            RpmLowSet = 0x2198,
            RpmLowReset = 0x214a,
            RpmHighSet = 0x2198,
            RpmHighReset = 0x214a,
            VtcLow = 0x130b,
            VtcHigh = 0x130b,
            
            int_0 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u
        {
            string_1 = "",
            string_0 = "P73",
            string_3 = "",
            string_2 = "",
            string_4 = "B18C-R",
            IsVTEC = true,
            RpmLowSet = 0x22e0,
            RpmLowReset = 0x228c,
            RpmHighSet = 0x22e0,
            RpmHighReset = 0x228c,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);


        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "232",
            string_0 = "P75",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "B18B",
            IsVTEC = false,
            RpmLowSet = 0x1b58,
            RpmLowReset = 0x1af4,
            RpmHighSet = 0x1b58,
            RpmHighReset = 0x1af4,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,

            int_0 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################


        class8_u_1 = new Class8_u {
            string_1 = "274",
            string_0 = "P75",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "B18A",
            IsVTEC = false,
            RpmLowSet = 0x1b58,
            RpmLowReset = 0x1af4,
            RpmHighSet = 0x1b58,
            RpmHighReset = 0x1af4,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        class8_u_1 = new Class8_u {
            string_1 = "270",
            string_0 = "P75",
            string_3 = "JDM",
            string_2 = "",
            string_4 = "B18A",
            IsVTEC = false,
            RpmLowSet = 0x1b58,
            RpmLowReset = 0x1af4,
            RpmHighSet = 0x1b58,
            RpmHighReset = 0x1af4,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "253",
            string_0 = "P91",
            string_3 = "JDM",
            string_2 = "SOHC",
            string_4 = "D16A-ZC",
            IsVTEC = true,
            RpmLowSet = 0x19f8,
            RpmLowReset = 0x1994,
            RpmHighSet = 0x19f8,
            RpmHighReset = 0x1994,
            VtcLow = 0x12cd,
            VtcHigh = 0x157c,

            int_0 = 1,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);
        //#########################


        class8_u_1 = new Class8_u {
            string_1 = "",
            string_0 = "P0A",
            string_3 = "USDM",
            string_2 = "",
            string_4 = "F22B1",
            IsVTEC = false,
            RpmLowSet = 0x1cf3,
            RpmLowReset = 0x1c8f,
            RpmHighSet = 0x1cf3,
            RpmHighReset = 0x1c8f,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,
            
            int_0 = 7,
            int_1 = 290,
            int_2 = 290,
            int_3 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        //#########################
        class8_u_1 = new Class8_u
        {
            string_1 = "",
            string_0 = "",
            string_3 = "",
            string_2 = "Stock B20 Dyno Tuned",
            string_4 = "B20",
            IsVTEC = false,
            RpmLowSet = 0x1b58,
            RpmLowReset = 0x1af4,
            RpmHighSet = 0x1b58,
            RpmHighReset = 0x1af4,
            VtcLow = 0x16f3,
            VtcHigh = 0x15f9,

            int_0 = 0,
            byte_0 = new byte[] { }
        };
        class8_u_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("ECUS", class8_u_1.string_0 + "-" + class8_u_1.string_3 + "-" + class8_u_1.string_4 + ".rom");
        this.class8_u_0.Add(class8_u_1);

        //#############################################################################################################################################
        //#############################################################################################################################################
        //#############################################################################################################################################
        //THIS IS ALL PREMADE CALIBRATION

        Class8_v class8_v_1 = new Class8_v
        {
            string_2 = "B16A with 2Step, FTS",
            string_4 = "B16A",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "B16B Tune Type-R",
            string_4 = "B16B",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "B18B1 with B16A head",
            string_4 = "B18B LS/Vtec",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "B20 with B16A Head",
            string_4 = "B20 LS/Vtec",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "172WHP",
            string_4 = "B20B LS/Vtec",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "Stock JDM Type-R",
            string_4 = "B18C-R",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "Stock JDM GSR",
            string_4 = "B18C-GSR",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "Stock JDM B20B",
            string_4 = "B20B",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "B20 with B16A head, CBR1000RR ITB",
            string_4 = "B20 Vtec ITB",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "D15B no-vtec with 2Step, FTS",
            string_4 = "D15B",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "",
            string_4 = "D16Z6",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "D16Y7 with 2Step, FTS",
            string_4 = "D16Y7",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "60ar, 1000cc, Stock B16",
            string_4 = "B16A Turbo",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "50ar, 1000cc, Stock B18",
            string_4 = "B18B Turbo",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "50ar, 1000cc, Stock B18, GM 3Bar",
            string_4 = "B18B Turbo",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "50ar, 750cc, Stock B18, Motorola 2.5Bar",
            string_4 = "B18B Turbo",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "60ar, 450cc, Stock B18 with B16A head",
            string_4 = "B18B Vtec Turbo",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "50ar, 450cc, B20 Vtec, 2bar",
            string_4 = "B20V Turbo",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "50ar, 450cc, B18 Vtec, 2bar",
            string_4 = "B18 LS-V Turbo",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);

        class8_v_1 = new Class8_v
        {
            string_2 = "",
            string_4 = "F20B",
            IsCalibration = true,
            byte_0 = new byte[] { }
        };
        class8_v_1.byte_0 = this.class18_0.class10_settings_0.frmMain_0.Class34_Zip_0.UnZipSilent("Calibrations", RedoName(class8_v_1.string_2) + "-" + RedoName(class8_v_1.string_4) + ".bmc");
        this.class8_v_0.Add(class8_v_1);
    }

    private string RedoName(string ThisName)
    {
        ThisName = ThisName.Replace(@"\", "-");
        ThisName = ThisName.Replace(",", "-");
        ThisName = ThisName.Replace("/", "-");

        return ThisName;
    }

    //#############################################################################################################################################
    //#############################################################################################################################################
    //#############################################################################################################################################

    private void method_1()
    {
        //THIS IS ALL ORIGINAL/OEM ECU SENSORS ENABLED
        Class1_u class1_u_1 = new Class1_u {
            string_0 = "All Disabled",
            string_1 = "NONE",
            string_2 = "",
            bool_7 = true,
        };
        this.class1_u_0.Add(class1_u_1);

        class1_u_1 = new Class1_u {
            string_0 = "P06",
            string_1 = "USDM",
            string_2 = "ELD, O2H, PA, Inj Test",
            IsELD = true,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P06",
            string_1 = "EDM",
            string_2 = "O2H",
            IsELD = false,
            IsBaro = false,
            IsInjTest = false,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P06",
            string_1 = "CDM",
            string_2 = "O2H, PA, Inj Test",
            IsELD = false,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P28",
            string_1 = "EDM",
            string_2 = "O2H",
            IsELD = false,
            IsBaro = false,
            IsInjTest = false,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P28",
            string_1 = "USDM",
            string_2 = "ELD, O2H, PA, Inj Test",
            IsELD = true,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P28",
            string_1 = "CDM",
            string_2 = "O2H, PA, Inj Test",
            IsELD = false,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P30",
            string_1 = "USDM",
            string_2 = "ELD, O2H, PA, Inj Test, Knock",
            IsELD = true,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = true,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P30",
            string_1 = "JDM",
            string_2 = "O2H",
            IsELD = false,
            IsBaro = false,
            IsInjTest = false,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P30",
            string_1 = "EDM",
            string_2 = "O2H",
            IsELD = false,
            IsBaro = false,
            IsInjTest = false,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P61",
            string_1 = "USDM",
            string_2 = "O2H, PA, Inj Test, Knock",
            IsELD = false,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = true,
            IsO2H = true,
            IsIAB = true,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P72",
            string_1 = "JDM",
            string_2 = "ELD, O2H, PA, inj Test, Knock, IAB",
            IsELD = true,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = true,
            IsO2H = true,
            IsIAB = true,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P72",
            string_1 = "USDM",
            string_2 = "ELD, O2H, PA, inj Test, Knock, IAB",
            IsELD = true,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = true,
            IsO2H = true,
            IsIAB = true,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "P75",
            string_1 = "USDM",
            string_2 = "ELD, O2H, PA, Inj Test",
            IsELD = true,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "PR3",
            string_1 = "JDM",
            string_2 = "ELD, O2H",
            IsELD = true,
            IsBaro = false,
            IsInjTest = false,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
        class1_u_1 = new Class1_u {
            string_0 = "PR4",
            string_1 = "USDM",
            string_2 = "O2H, PA, Inj Test",
            IsELD = false,
            IsBaro = true,
            IsInjTest = true,
            IsKnock = false,
            IsO2H = true,
            IsIAB = false,
        };
        this.class1_u_0.Add(class1_u_1);
    }

    public void method_5()
    {
        for (int i = 0; i < this.class8_v_0.Count; i++)
        {
            this.class8_v_0[i] = null;
        }
        for (int i = 0; i < this.class8_u_0.Count; i++)
        {
            this.class8_u_0[i] = null;
        }
        for (int j = 0; j < this.class1_u_0.Count; j++)
        {
            this.class1_u_0[j] = null;
        }
        GC.Collect(3);
    }
}

