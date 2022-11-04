using Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Management;
using System.Windows.Forms;

internal class Class15
{
    private FrmMain frmMain_0;
    private BMTuneVersions BMTuneVersions_0 = BMTuneVersions.Free;
    internal string string_CurrentID;
    private string DPath;
    private Class15 Class15_0;
    internal string BMIDDD;

    //UPDATE SETTING
    internal string CurrentBMTuneVersion;

    public Class15(ref FrmMain FrmMain_1)
    {
        Class15_0 = this;
        frmMain_0 = FrmMain_1;

        string TeasteStr4 = "6E3-FEBF-BAF3-33C4-FBFF";
        string TeasteStr6 = "V1.97";

        DPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\";
        BMIDDD = TeasteStr4;
        CurrentBMTuneVersion = TeasteStr6;

        this.AdminRelauncher();
        this.BMTuneVersions_0 = BMTuneVersions.Tuner;
        if (!Directory.Exists(DPath)) Directory.CreateDirectory(DPath);
        this.method_getversion();
        this.GetUserID();

        //################
        //Check for updates
        if (File.Exists(Application.StartupPath + @"\README.md")) File.Delete(Application.StartupPath + @"\README.md");
        if (File.Exists(Application.StartupPath + @"\BMTuneUpdate" + ".exe")) File.Delete(Application.StartupPath + @"\BMTuneUpdate" + ".exe");
        this.CheckForUpdate(false);
        //################
    }

    private void AdminRelauncher()
    {
        if (!IsRunAsAdmin())
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            try
            {
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;
            }
            catch
            {
                proc.FileName = Application.ExecutablePath;
            }

            proc.Verb = "runas";

            try
            {
                Process.Start(proc);
            }
            catch { }
            Environment.Exit(0);
        }
    }

    private bool IsRunAsAdmin()
    {
        WindowsIdentity id = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(id);

        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    private void GetUserID()
    {
        this.string_CurrentID = "";
        string RSTRING = GSEEET(Path.GetPathRoot(Environment.SystemDirectory).Substring(0, 1));
        for (int i = 0; i < RSTRING.Length; i++)
        {
            this.string_CurrentID += RSTRING[i];
            if (i == 2 || i == 6 || i == 10 || i == 14) this.string_CurrentID += "-";
        }
    }
    private string GSEEET(string F323F)
    {
        if (F323F.EndsWith(":\\")) F323F = F323F.Substring(0, F323F.Length - 2);
        string SBSEEB = G233G3(F323F);
        string G23G = HH2333S();
        return G23G.Substring(13) + G23G.Substring(1, 4) + SBSEEB + G23G.Substring(4, 4);
    }

    private string G233G3(string DSEGESEG)
    {
        ManagementObject SDFV = new ManagementObject(@"win32_logicaldisk.deviceid=""" + DSEGESEG + @":""");
        SDFV.Get();
        string VSVESV = SDFV["VolumeSerialNumber"].ToString();
        SDFV.Dispose();
        return VSVESV;
    }

    private string HH2333S()
    {
        string VESEVE = "";
        ManagementClass BANR = new ManagementClass("win32_processor");
        ManagementObjectCollection NRDDR = BANR.GetInstances();
        foreach (ManagementObject RDMRRD in NRDDR)
        {
            if (VESEVE == "")
            {
                VESEVE = RDMRRD.Properties["processorID"].Value.ToString();
                break;
            }
        }
        return VESEVE;
    }

    //####
    private void method_getversion()
    {
        if (File.Exists(Application.StartupPath + @"\VersionV2.txt")) File.Delete(Application.StartupPath + @"\VersionV2.txt");

        if (File.Exists(Application.StartupPath + @"\Version.txt"))
        {
            File.Create(DPath + "Version.txt").Dispose();
            File.WriteAllBytes(DPath + "Version.txt", File.ReadAllBytes(Application.StartupPath + @"\Version.txt"));
            try
            {
                File.Delete(Application.StartupPath + @"\Version.txt");
            }
            catch
            {
                LogTtheee("Unable to remove Version File at location:" + Environment.NewLine + "" + Application.StartupPath + @"\Version.txt");
            }
        }

        if (File.Exists(Application.StartupPath + @"\VersionBETA.txt")) File.Delete(Application.StartupPath + @"\VersionBETA.txt");

        if (File.Exists(DPath + "Version.txt")) CurrentBMTuneVersion = File.ReadAllText(DPath + "Version.txt");
        else
        {
            File.Create(DPath + "Version.txt").Dispose();
            File.WriteAllText(DPath + "Version.txt", CurrentBMTuneVersion);
        }
    }

    private void LogTtheee(string string_8)
    {
        this.frmMain_0.LogThis("Loading - " + string_8);
    }

    private string DLStringFromURL(string ThisURL)
    {
        string String_00 = "";

        //###########################################################
        //Using HttpWebRequest
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ThisURL);
            request.Timeout = 6000;
            request.ReadWriteTimeout = 6000;
            WebResponse wresp = (HttpWebResponse)request.GetResponse();
            Stream memoryStream = wresp.GetResponseStream();
            StreamReader streamReader = new StreamReader(memoryStream);
            String_00 = streamReader.ReadToEnd();
        }
        catch
        {

        }

        //###########################################################
        //###########################################################
        //###########################################################
        //Using WebClient
        /*using (var webpage = new WebClient())
        {
            //webpage.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:25.0;  WOW64) Gecko/20100101 Firefox/25.0 AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            webpage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:25.0;  WOW64) Gecko/20100101 Firefox/25.0 AppleWebKit/535.2 (KHTML, like Gecko)  Chrome/15.0.874.121 Safari/535.2");
            //webpage.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            try
            {
                String_00 = webpage.DownloadString(ThisURL);

            }
            catch (Exception mess) 
            {
                Console.WriteLine("Cant get Text from URL with error:" + mess);
            }

            webpage.Dispose();
        }*/


        //if (String_00 != "") Console.WriteLine("Managed to get internet version from:" + Environment.NewLine + ThisURL);
        return String_00;
    }

    public void CheckForUpdate(bool ShowWarning)
    {
        bool BMTuneUpdated = true;
        //XXXX();
        try
        {
            string String_00 = "";
            //if (String_00 == "") String_00 = this.frmMain_0.class31_0.GetFTPBMTuneVersion("Version.txt");
            if (String_00 == "") String_00 = DLStringFromURL("https://raw.githubusercontent.com/MarcDevs/bmbuild/master/Version.txt");
            if (String_00 == "") String_00 = DLStringFromURL("http://www.bmtune.com/build/Version.txt");

            if (String_00 != "")
            {
                double LastVersion = double.Parse(String_00.Substring(1).Replace(".", ""));
                if (LastVersion > 1000) LastVersion = LastVersion / 10;

                double CurrentVersion = double.Parse(this.CurrentBMTuneVersion.Substring(1).Replace(".", ""));
                if (CurrentVersion > 1000) CurrentVersion = CurrentVersion / 10;

                if (CurrentVersion < LastVersion) BMTuneUpdated = false;

                if (!BMTuneUpdated)
                {
                    DialogResult result = DialogResult.Yes;
                    result = MessageBox.Show(Form.ActiveForm, "New update available!" + Environment.NewLine + "Version: " + String_00 + Environment.NewLine + "Do you want to update?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes) this.UpdateBMTune();
                }
                //InternetConnected = true;
            }
        }
        catch {
            if (ShowWarning) ShowManualUpdate();
        }
    }

    public void ShowManualUpdate()
    {
        DialogResult result = MessageBox.Show(Form.ActiveForm, "Can't update BMTune" + Environment.NewLine + "Do you want to download BMTune manually?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
        if (result == DialogResult.Yes) Process.Start("http://www.bmtune.com/");
    }

    private void UpdateBMTune()
    {
        frmDownloadUpdate frmDownloadUpdate_0 = new frmDownloadUpdate(ref this.frmMain_0, ref Class15_0);
        DialogResult result = frmDownloadUpdate_0.ShowDialog();

        if (result == DialogResult.Cancel) ShowManualUpdate();
    }

    internal BMTuneVersions method_22()
    {
        return this.BMTuneVersions_0;
    }

    internal bool method_5(Enum4 enum4_0)
    {
        return true;

        /*switch (enum4_0)
        {
            case Enum4.const_0:
                return (this.BMTuneVersions_0 == BMTuneVersions.datalogger);

            case Enum4.const_1:
                return (this.BMTuneVersions_0 == BMTuneVersions.Free);

            case Enum4.const_2:
                return (this.BMTuneVersions_0 == BMTuneVersions.Pro_Demon);

            case Enum4.const_3:
                return (this.BMTuneVersions_0 == BMTuneVersions.Tuner);

            case Enum4.const_11:
                return (this.BMTuneVersions_0 == BMTuneVersions.Dev || this.BMTuneVersions_0 == BMTuneVersions.Tuner);

            case Enum4.const_12:
                return (this.BMTuneVersions_0 == BMTuneVersions.Dev);

        }
        return false;*/
    }

    private string That(string Hex)
    {
        string Left = Hex;
        string Returning = "";
        while (Left != "")
        {
            try
            {
                int This = Int32.Parse(Left.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier) - 40;
                if (This < 0) This = 256 + This;
                Returning += Convert.ToChar(This).ToString();
                Left = Left.Substring(2);
            }
            catch { Left = ""; }
        }

        return Returning;
    }
}

