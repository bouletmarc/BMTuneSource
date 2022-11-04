using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AppCryptor
{
    public partial class Form1 : Form
    {
        public int CryptedMinLenght = 8;
        public int CryptedMaxLenght = 15;

        //public int CryptedStringNumber = 99;

        bool RUN_FULL_LOOP = true;

        //########################################

        public Class_Text Class_Text_0;
        public Class_CreateFiles Class_CreateFiles_0;
        public Class_Variables Class_Variables_0;
        public Class_Crypter Class_Crypter_0;
        public Class_StringCrypter Class_StringCrypter_0;
        public Class_FileRenamer Class_FileRenamer_0;

        public string ProjectLocation = "";
        public string ProjectLocationCrypted = "";

        public string[] AllCurrentClassLines = new string[] { };
        public string CurrentClassName = "";

        public string CurrentFile = "";


        private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
        //private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();

        DateTime StartTime = DateTime.Now;


        Form1 form1_0;

        public Form1()
        {
            InitializeComponent();

            form1_0 = this;

            txt_ProjectLocation.Text = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2";
            txt_CryptedLocation.Text = txt_ProjectLocation.Text + "_Crypted";

            label6.Text = "";
            label7.Text = "";

            if (Class_Text_0 != null) Class_Text_0 = null;
            Class_Text_0 = new Class_Text(ref form1_0);
            Class_Text_0.CreateList();

            if (Class_CreateFiles_0 != null) Class_CreateFiles_0 = null;
            Class_CreateFiles_0 = new Class_CreateFiles(ref form1_0);

            if (Class_Variables_0 != null) Class_Variables_0 = null;
            Class_Variables_0 = new Class_Variables(ref form1_0);

            if (Class_Crypter_0 != null) Class_Crypter_0 = null;
            Class_Crypter_0 = new Class_Crypter(ref form1_0);

            if (Class_StringCrypter_0 != null) Class_StringCrypter_0 = null;
            Class_StringCrypter_0 = new Class_StringCrypter(ref form1_0);

            if (Class_FileRenamer_0 != null) Class_FileRenamer_0 = null;
            Class_FileRenamer_0 = new Class_FileRenamer(ref form1_0);

            LoopTimer.Interval = 5000;
            if (RUN_FULL_LOOP) LoopTimer.Interval = 10;
            LoopTimer.Tick += DoThisAllTheTime;
            LoopTimer.Start();

            if (RUN_FULL_LOOP)
            {
                this.checkBox1.Checked = false;
                this.checkBox4.Checked = false;

                //this.Visible = false;
                //this.Hide();
            }

            //this.backgroundWorker_0.WorkerSupportsCancellation = false;
            //this.backgroundWorker_0.WorkerReportsProgress = false;
            //this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
            //this.backgroundWorker_0.RunWorkerAsync();
        }

        /*private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
        {

        }*/

        void DoThisAllTheTime(object sender, EventArgs e)
        {
            if (RUN_FULL_LOOP)
            {
                //this.Visible = false;
                //this.Hide();
                StartTime = DateTime.Now;
                LoopTimer.Stop();

                RunFullLoop();
                //Encrypt();
                //EncryptAllInData();

                if (RUN_FULL_LOOP) Application.Exit();
            }

            LoopTimer.Stop();
        }

        public void RunFullLoop()
        {
            Encrypt();

            DoSingleClass("Class15.cs", false);
            DoSingleClass("Class22_startup.cs", false);
            DoSingleClass("Class31.cs", false);
            DoSingleClass("Enum4.cs", false);
            DoSingleClass("Enum6.cs", false);

            EncryptAllInData();

            Class_FileRenamer_0.RemadeAllFilenames();

            CreateFileInfos();

            progressBar1.Value = 0;
            label6.Text = "";
            label7.Text = "";
            LogThis("Done");
        }

        public void DoSingleClass(string ClassFileName, bool InDataFolder)
        {
            label6.Text = "Doing: " + ClassFileName;
            this.Refresh();

            Class_Variables_0.GetVariables(ClassFileName, InDataFolder);
            Class_Crypter_0.EncryptThisFile(ClassFileName, InDataFolder);
            if (checkBox5.Checked) Class_StringCrypter_0.EncryptStringInFile(ClassFileName, InDataFolder);

            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(Properties.Resources.alert2);
            snd.Play();
        }

        public void EncryptAllInData()
        {
            form1_0.ClearLogs();
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Encrypting all Data files...");

            form1_0.listBox2.Items.Clear();

            int currenn = 0;
            int currenn2 = 0;

            string pattern = @"\.cs$";
            var matches = Directory.GetFiles(form1_0.ProjectLocationCrypted, "*", SearchOption.AllDirectories).Where(path => Regex.Match(path, pattern).Success);

            //check in all '*.cs' files
            foreach (string file in matches)
            {
                form1_0.progressBar1.Value = (currenn * 100) / matches.Count<string>();

                if (!file.Contains("BMTune_Installer")
                    && !file.Contains("BMTune_Licenser")
                    && !file.Contains("BMTune_Server")
                    && !file.Contains("BMTune_Starter")
                    && !file.Contains("BMTune_Uploader")
                    && !file.Contains("BMTune_Encrypter")
                    && !file.Contains("AppCryptor")
                    && !file.Contains("Resources.Designer.cs")
                    && !file.Contains("ChartSetup.cs")
                    && !file.Contains("ChartTemplate.cs")
                    && !file.Contains("ChartCollection.cs")
                    && !file.Contains("DoNotObfuscate.cs")
                    && !file.Contains("MapSensorUnits.cs")

                    && !file.Contains("MapSensorUnits.cs")
                    && !file.Contains("TemperatureUnits.cs")
                    && !file.Contains("VoltUnits.cs")
                    && !file.Contains("VssUnits.cs")
                    && !file.Contains("EmulatorVendorOstrich.cs")
                    && !file.Contains("EmulatorVendorDemon.cs")
                    && !file.Contains("DatalogLedTypes.cs")
                    && !file.Contains("DatalogDisplayTypes.cs")
                    && !file.Contains("DatalogButtonsTypes.cs")
                    && !file.Contains("CorrectionUnits.cs")
                    && !file.Contains("AirFuelUnits.cs")
                    && !file.Contains("DatalogLedTypes.cs")
                    && file.Contains("BMTuneVersions.cs")   //################
                    && !file.Contains("ArduinoModel.cs")
                    && !file.Contains("SensorsX.cs")
                    && !file.Contains(@"\bin\")
                    && !file.Contains(@"\Debug\")
                    && !file.Contains(@"\obj\")
                    && file.Contains(@"\Data\"))
                {
                    label7.Text = (currenn2 + 1) + "/" + 34;

                    form1_0.label6.Text = "Doing: " + Path.GetFileName(file);
                    form1_0.Refresh();

                    DoSingleClass(Path.GetFileName(file), true);

                    currenn2++;
                    //if (!RUN_FULL_LOOP && currenn >= 1) break;
                }

                currenn++;
            }

            label6.Text = "";
            label7.Text = "";

            form1_0.progressBar1.Value = 0;
            form1_0.Refresh();
        }

        public void ClearLogs()
        {
            textBox3.Text = "";
            this.Refresh();
        }

        public void LogThis(string ThisStr)
        {
            textBox3.AppendText(ThisStr + " - " + GetTimeString() + Environment.NewLine);
        }

        public string GetTimeString()
        {
            string MinuteTime = (DateTime.Now - StartTime).TotalMinutes.ToString("00.00");
            string[] SplitTime = MinuteTime.Split(',');

            int Minutes = int.Parse(SplitTime[0]);
            int Seconds = map(int.Parse(SplitTime[1]), 0, 100, 0, 60);

            return Minutes + ":" + Seconds.ToString("00");
        }

        int map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public void Encrypt()
        {
            ProjectLocation = txt_ProjectLocation.Text;
            //ProjectLocationCrypted = txt_CryptedLocation.Text;

            ProjectLocationCrypted = ProjectLocation;
            ProjectLocationCrypted = ProjectLocationCrypted.Replace(@"\BMTune2", @"\BMTune2_Crypted");

            Class_Crypter_0.AllClassSaved = new List<string>();

            if (!Directory.Exists(ProjectLocationCrypted)) Directory.CreateDirectory(ProjectLocationCrypted);

            if (checkBox2.Checked)
            {
                Class_CreateFiles_0.RemoveFiles();
                Class_CreateFiles_0.MakeFiles();
            }
            GenerateAllClassFilename();
            /*if (checkBox3.Checked)
            {
                GetVariables();
                DoAllClass();
                CreateFileInfos();
            }*/

            progressBar1.Value = 0;
            label6.Text = "";
            label7.Text = "";
            LogThis("Done");
        }

        public void GenerateAllClassFilename()
        {
            listBox1.Items.Clear();

            string pattern = @"\.cs$";
            var matches = Directory.GetFiles(ProjectLocation, "*", SearchOption.AllDirectories).Where(path => Regex.Match(path, pattern).Success);

            //check in all '*.cs' files
            foreach (string file in matches)
            {
                if (!file.Contains("BMTune_Installer")
                    && !file.Contains("BMTune_Licenser")
                    && !file.Contains("BMTune_Server")
                    && !file.Contains("BMTune_Starter")
                    && !file.Contains("BMTune_Uploader")
                    && !file.Contains("BMTune_Encrypter")
                    && !file.Contains("AppCryptor")
                    && !file.Contains(@"\bin\")
                    && !file.Contains(@"\Debug\")
                    && !file.Contains(@"\obj\")
                    && !file.Contains("Resources.Designer.cs")
                        //&& (file.Contains("Class15.cs")
                        //|| file.Contains("Class18_file.cs")
                        //|| file.Contains("FrmMain.cs")
                        //|| file.Contains("Class31.cs"))
                        )
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                    this.Class_Text_0.NotCryptedText.Add(Path.GetFileNameWithoutExtension(file));
                }
            }

            //this.Invalidate(true);
            this.Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartTime = DateTime.Now;
            Encrypt();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox4_Validated(object sender, EventArgs e)
        {
            try
            {
                CryptedMaxLenght = int.Parse(textBox4.Text);
            }
            catch { }
        }

        private void TextBox2_Validated(object sender, EventArgs e)
        {
            try
            {
                CryptedMinLenght = int.Parse(textBox2.Text);
            }
            catch { }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Seeef = false;
            if (listBox1.SelectedIndex >= 0)
            {
                Seeef = true;
                Class_Variables_0.GetVariables(listBox1.Items[listBox1.SelectedIndex].ToString(), false);
                Class_Crypter_0.EncryptThisFile(listBox1.Items[listBox1.SelectedIndex].ToString(), false);
                if (checkBox5.Checked) Class_StringCrypter_0.EncryptStringInFile(listBox1.Items[listBox1.SelectedIndex].ToString(), false);

                CreateFileInfos();
            }

            if (Seeef)
            {
                CreateFileInfos();

                progressBar1.Value = 0;
                label6.Text = "";
                label7.Text = "";
                LogThis("Done");
            }
        }

        private void CreateFileInfos()
        {
            string SaveStr = "";
            for (int i = 0; i < Class_Variables_0.AllMethods.Count; i++) SaveStr += Class_Variables_0.AllMethods[i] + "=" + Class_Variables_0.AllMethodsCrypted[i] + Environment.NewLine;

            File.Create(Application.StartupPath + @"\LocationsInfos.txt").Dispose();
            File.WriteAllText(Application.StartupPath + @"\LocationsInfos.txt", SaveStr);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartTime = DateTime.Now;

            Class_FileRenamer_0.RemadeAllFilenames();
        }
    }
}
