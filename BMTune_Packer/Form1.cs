using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Runtime;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BMTune_Uploader
{
    public partial class Form1 : Form
    {
        private string pathStarterProject = "";
        private string pathBM = "";
        private string pathStarter = "";
        private string pathVersion = "";
        private string pathInstaller = "";
        private string projectName = @"BMTune_Starter";
        //private string pathSave = "";
        private string pathObj = "";
        private string pathStarterSource = "";
        private string pathCryptor = "";
        private string pathAppCryptor = "";

        //private string msbuild_path =           @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe";
        private string msbuild_path = @"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe";

        private bool Loading = false;
        private System.Windows.Forms.Timer LoadTimer = new System.Windows.Forms.Timer();
        //private byte[] AllByte = new byte[] { };

        private int EncryptedCount = 0;
        private bool BMTuneDo = false;

        //refer to 'FCID1.txt'
        private int NumberOfUnpackFiles = 16;
        private int MAXNumberOfUnpackFiles = 64;
        private int CurrentFile = 1;

        private FileStream fileStream_0;
        private BinaryReader binaryReader_0;

        //refer to BMTune.exe being Starter (how much time we repack starter)
        private int NumberPackedStarted = 5;
        private bool DoAllAtOnce = true;

        //Encryption
        private int EncryptEnd = 126;
        private int Encrypt1 = 11;
        private int Encrypt2 = 33;
        private int Encrypt3 = 48;
        private int Encrypt4 = 66;
        private int Encrypt5 = 80;

        private int Encrypt6 = 1;

        private DateTime BufferTime = DateTime.Now;

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            string FolderLocation = Application.StartupPath;
            FolderLocation = Path.GetDirectoryName(FolderLocation);
            FolderLocation = Path.GetDirectoryName(FolderLocation);

            textBox3.Text = FolderLocation;
            textBox2.Text = NumberPackedStarted.ToString();

            //label1.Visible = false;
            label1.Text = "";
            NumberOfUnpackFiles = rnd.Next(27, MAXNumberOfUnpackFiles);

            LoadLocations();

            EncryptEnd = rnd.Next(43, 217); //126;
            Encrypt1 = rnd.Next(7, 17); //11;
            Encrypt2 = rnd.Next(18, 36); //33;
            Encrypt3 = rnd.Next(37, 56); //48;
            Encrypt4 = rnd.Next(57, 74); //66;
            Encrypt5 = rnd.Next(75, 99); //80;

            Encrypt6 = rnd.Next(1, MAXNumberOfUnpackFiles - 1); //80;

            LoadTimer.Interval = 500;
            LoadTimer.Tick += LoadingThread;
            LoadTimer.Start();

            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;

            if (File.Exists(pathVersion))
            {
                double CurrentVersion = double.Parse(File.ReadAllText(pathVersion).Substring(1).Replace(".", ""));
                if (CurrentVersion > 1000) CurrentVersion = CurrentVersion / 10;
                txtBuildVersion.Text = "V" + CurrentVersion.ToString().Substring(0, 1) + "." + CurrentVersion.ToString().Substring(1).Replace(",", ".");
            }
            else
            {
                LogThis("CAN'T Load Version.txt");
                LogThis("File not existant at path:");
                LogThis(pathVersion);
            }
            //Loading = true;
        }

        void LoadLocations()
        {
            pathStarterProject = textBox3.Text + @"\BMTune.sln";
            pathBM = textBox3.Text + @"\bin\Debug\BMTune.exe";
            pathStarter = textBox3.Text + @"\bin\Debug\Starter\BMTune.exe";
            pathVersion = textBox3.Text + @"\bin\Debug\Starter\Version.txt";
            pathInstaller = textBox3.Text + @"\bin\Debug\Starter\Setup_Installer\setup.iss";
            projectName = @"BMTune_Starter";
            //pathSave = textBox3.Text + @"\BMTune_Starter\FCID";
            pathObj = textBox3.Text + @"\BMTune_Starter\obj";
            pathStarterSource = textBox3.Text + @"\BMTune_Starter\";
            //pathCryptor =           textBox3.Text + @"\BMTune_Encrypter\bin\Debug\BMFuscator.exe";
            //pathCryptor =           @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\BMTune_Encrypter\bin\Debug\BMFuscator.exe";
            pathCryptor = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\Krawk-Protector-master\bin\Debug\BM Protector.exe";
            pathAppCryptor = textBox3.Text + @"\AppCryptor\bin\Debug\AppCryptor.exe";
        }

        void LoadCryptedLocation()
        {
            pathStarterProject = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\BMTune.sln";
            pathBM = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\bin\Debug\BMTune.exe";
            pathStarter = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\bin\Debug\Starter\BMTune.exe";
            pathVersion = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\bin\Debug\Starter\Version.txt";
            pathInstaller = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\bin\Debug\Starter\Setup_Installer\setup.iss";
            projectName = @"BMTune_Starter";
            //pathSave = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\BMTune_Starter\FCID";
            pathObj = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\BMTune_Starter\obj";
            pathStarterSource = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\BMTune_Starter\";
            //pathCryptor =           @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\BMTune_Encrypter\bin\Debug\BMFuscator.exe";
            //pathAppCryptor =        @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\AppCryptor\bin\Debug\AppCryptor.exe";

        }

        void LoadingThread(object sender, EventArgs e)
        {
            if (Loading)
            {
                Loading = false;

                //Save version
                if (File.Exists(pathVersion))
                {
                    File.Create(pathVersion).Dispose();
                    File.WriteAllText(pathVersion, txtBuildVersion.Text + Environment.NewLine);
                }

                LoadLocations();
                NumberPackedStarted = int.Parse(textBox2.Text);
                int LoopSize = NumberPackedStarted;
                if (!DoAllAtOnce) LoopSize = 1;
                progressBar2.Value = 0;
                progressBar3.Value = 0;

                LaunchAppCryptorBM();
                LoadCryptedLocation();

                projectName = @"BMTune";
                string pathobjback = pathObj;
                pathObj = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\obj";

                BuildSolution();

                projectName = @"BMTune_Starter";
                pathObj = pathobjback;

                BMTuneDo = true;

                string buffffpath = pathStarter;
                if (BMTuneDo) buffffpath = pathBM;

                //pathCryptor =         @"C:\Users\boule\Documents\Visual Studio 2019\Projects\Krawk-Protector-master\bin\Debug\BMFuscator.exe";
                pathCryptor = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\BMFuscator\bin\Debug\BMFuscator.exe";
                LaunchAppCryptor(buffffpath);
                pathCryptor = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\Krawk-Protector-master\bin\Debug\BM Protector.exe";
                LaunchAppCryptor(buffffpath);


                LaunchBMPacker();


                Environment.Exit(0);

                //Launching Inno setup
                //DialogResult result = MessageBox.Show("Do you want to launch Inno Setup Installer?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes) LaunchInno();
            }
        }

        private void LaunchAppCryptor(string ThisFileToCrypt)
        {
            label1.Text = "Crypting .exe";
            LogThis("Crypting...");

            Process process = new Process();
            process.StartInfo.FileName = pathCryptor;
            process.StartInfo.Arguments = @"""" + ThisFileToCrypt + @"""";
            process.Start();
            process.WaitForExit();

            if (!ThisFileToCrypt.Contains("_BMFuscator.exe")) ThisFileToCrypt = ThisFileToCrypt.Substring(0, ThisFileToCrypt.Length - 4) + "_BMFuscator.exe";

            RenameEncrypted(ThisFileToCrypt);

        }

        private void LaunchAppCryptorBM()
        {
            label1.Text = "AppCrypting .exe";
            LogThis("AppCrypting...");

            Process process = new Process();
            process.StartInfo.FileName = pathAppCryptor;
            process.Start();
            process.WaitForExit();

            //if (!ThisFileToCrypt.Contains("_BMFuscator.exe")) ThisFileToCrypt = ThisFileToCrypt.Substring(0, ThisFileToCrypt.Length - 4) + "_BMFuscator.exe";
            //RenameEncrypted(ThisFileToCrypt);
        }

        public void LaunchBMPacker()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\bin\Debug\BMTune PACKER.exe";
            process.StartInfo.Arguments = this.txtBuildVersion.Text;
            process.Start();
        }

        private void RenameEncrypted(string ThisFileToCrypt)
        {
            label1.Text = "Renaming crypted .exe";
            LogThis("Renaming crypted...");

            if (File.Exists(ThisFileToCrypt))
            {
                if (ThisFileToCrypt.Contains("_BMFuscator.exe"))
                {
                    string TFile = ThisFileToCrypt;
                    string Name = ThisFileToCrypt.Substring(0, ThisFileToCrypt.Length - 15) + ".exe";

                    File.Create(Name).Dispose();
                    File.WriteAllBytes(Name, File.ReadAllBytes(TFile));

                    bool Retrying = true;
                    while (Retrying)
                    {
                        try
                        {
                            File.Delete(TFile);
                            Retrying = false;
                        }
                        catch
                        {
                            DialogResult result = MessageBox.Show("Can't Delete file:\n" + TFile + "\nDo you want to retry?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.No) Retrying = false;
                        }
                    }
                }
            }
        }

        private void RedoSettings()
        {
            if (File.Exists(pathStarterSource + "Program.cs"))
            {
                string[] AllInstallerLines = File.ReadAllLines(pathStarterSource + "Program.cs");
                for (int i = 0; i < AllInstallerLines.Length; i++)
                {
                    if (AllInstallerLines[i].Contains("        private int Ȩ̨̛̙̩̖̗̫̝̙̘͚̱̹͇̋ͯ̂ͧ̈ͮ̿̓ͯ̀̕Ẍ̷̭͚̱̮̝͕̻̞̯̫͔̭̫̹͆͆ͪ̂̐ͤ̒͐͋̈ͭͥͭ̒̍̀̚͜͡ͅW̛͕͉̬̖̳̳̞̎͒ͫ̀ͧ͟Ę̵̵̭̹̭͖̲̰̐̇̍͌̽ͮͫ͋̂͛̋͊ͬ̓͝3̶̧̢͉͎̳̱̪͚̫̝ͨ̈́ͣ̿̕2̷̢̨̜̺͉̗̱̠͇̭̖̙̲̈́̋̎̈̎̂ͫ̎̑̆̌̎̃͂̑ͪ̀̚ͅ = ")) AllInstallerLines[i] = "        private int Ȩ̨̛̙̩̖̗̫̝̙̘͚̱̹͇̋ͯ̂ͧ̈ͮ̿̓ͯ̀̕Ẍ̷̭͚̱̮̝͕̻̞̯̫͔̭̫̹͆͆ͪ̂̐ͤ̒͐͋̈ͭͥͭ̒̍̀̚͜͡ͅW̛͕͉̬̖̳̳̞̎͒ͫ̀ͧ͟Ę̵̵̭̹̭͖̲̰̐̇̍͌̽ͮͫ͋̂͛̋͊ͬ̓͝3̶̧̢͉͎̳̱̪͚̫̝ͨ̈́ͣ̿̕2̷̢̨̜̺͉̗̱̠͇̭̖̙̲̈́̋̎̈̎̂ͫ̎̑̆̌̎̃͂̑ͪ̀̚ͅ = " + NumberOfUnpackFiles + ";";

                    if (AllInstallerLines[i].Contains("        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅF̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = ")) AllInstallerLines[i] = "        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅF̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = " + EncryptEnd + ";";

                    if (AllInstallerLines[i].Contains("        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅF̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = ")) AllInstallerLines[i] = "        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅF̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = " + Encrypt1 + ";";
                    if (AllInstallerLines[i].Contains("        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞F̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = ")) AllInstallerLines[i] = "        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞F̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = " + Encrypt2 + ";";
                    if (AllInstallerLines[i].Contains("        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅG̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = ")) AllInstallerLines[i] = "        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅG̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = " + Encrypt3 + ";";
                    if (AllInstallerLines[i].Contains("        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅG̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞F̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = ")) AllInstallerLines[i] = "        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅG̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞F̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = " + Encrypt4 + ";";
                    if (AllInstallerLines[i].Contains("        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅF̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = ")) AllInstallerLines[i] = "        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̸̈́͌͆͌̓̅͌̊ͭ̐̇̿̚͠͏͔̤̪̳̦͚̻͚̫̤͉̼̥̰̜͕̼̠̱͠F̲̤̟̤͙̞̰̰͍͈͉̀ͪ̄̋͋̃͠ͅͅF̵̶̴͚̻̦̫̰̹̮͇̙̺̼͚͍̜̊ͦ̓̐̓̅̔̉̈́͗̉ͥ̏̾͛͒ͦ̀̕B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ẕ̴̱̰̝̻̺̗͈̞̣͇̤̖̝̦ͮ̆̃͋̀̔̏̈́̿̀ͬ͋ͬͮ̓̀̚͝͡G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = " + Encrypt5 + ";";
                    if (AllInstallerLines[i].Contains("        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = ")) AllInstallerLines[i] = "        private int E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ = " + Encrypt6 + ";";
                    //E̸̟̤͈̠͈̦̮͍͔͎͚̭͕͇͇̩͚̓͊̈́̋̾̾̌͗̽̇͌͛̇͒̽̎̓̍͜G̨̞͈̼͉̱̠̓ͫ͋̇̈̽̿̿ͤͩ̐̃̋̕͜B̶̹̻̦͚̗̆ͨ̍̾́̕͞Ḫ̸̵̡̫̖͇̞̦̞̣̱͇͔̫͙̳̠̜͇ͦͮ̈̈̓̏̚͢͜ͅͅ
                }

                File.Create(pathStarterSource + "Program.cs").Dispose();
                File.WriteAllLines(pathStarterSource + "Program.cs", AllInstallerLines);
            }
        }

        private void RedoCSPROJ()
        {
            if (File.Exists(pathStarterSource + "BMTune_Starter.csproj"))
            {
                List<string> RemadeLine = new List<string>();

                bool InItemGroup = false;
                string[] AllInstallerLines = File.ReadAllLines(pathStarterSource + "BMTune_Starter.csproj");
                for (int i = 0; i < AllInstallerLines.Length; i++)
                {
                    if (InItemGroup && AllInstallerLines[i].Contains("</ItemGroup>")) InItemGroup = false;
                    if (!InItemGroup) RemadeLine.Add(AllInstallerLines[i]);
                    //if (!AllInstallerLines[i].Contains("<EmbeddedResource Include=")) RemadeLine.Add(AllInstallerLines[i]);

                    if (AllInstallerLines[i].Contains("Content Include="))
                    {
                        InItemGroup = true;
                        for (int i2 = 0; i2 < NumberOfUnpackFiles; i2++)
                        {
                            RemadeLine.Add("    <EmbeddedResource Include=\"FCID" + (i2 + 1) + ".txt\" />");
                        }
                    }
                }

                string[] AllNeessf = new string[RemadeLine.Count];
                for (int i = 0; i < RemadeLine.Count; i++) AllNeessf[i] = RemadeLine[i];

                File.Create(pathStarterSource + "BMTune_Starter.csproj").Dispose();
                File.WriteAllLines(pathStarterSource + "BMTune_Starter.csproj", AllNeessf);
            }
        }

        public void LaunchInno()
        {
            //causing issue / error here need to launch .iss file from another method
            Process process = new Process();
            process.StartInfo.FileName = pathInstaller;
            process.Start();
        }

        public void LogThis(string ThisText)
        {
            this.textBox1.Text += ThisText + Environment.NewLine;
            this.Invalidate();
        }

        private void BuildSolution()
        {
            label1.Text = "Buiding .exe";
            LogThis("Buiding...");

            progressBar2.Value = 50;

            if (Directory.Exists(pathObj)) Directory.Delete(pathObj, true);
            //if (Directory.Exists(pathObj)) Directory.Delete(pathObj, true);

            Process process = new Process();
            process.StartInfo.FileName = msbuild_path;
            process.StartInfo.Arguments = @"""" + pathStarterProject + @"""" + " /t:" + projectName + " /tv:14.0 /p:Configuration=Debug /p:Platform=x86 /p:BuildProjectReferences=true";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();

            //progressBar2.Value = 0;
        }

        /*private void DeleteAllPackedFiles()
        {
            for (int i = 0; i < MAXNumberOfUnpackFiles; i++)
            {
                if (File.Exists(pathSave + i + ".txt")) File.Delete(pathSave + i + ".txt");
            }
        }

        private void PackThisPart()
        {
            byte[] LBytesX = new byte[this.binaryReader_0.BaseStream.Length / NumberOfUnpackFiles];
            if (CurrentFile != 1 && CurrentFile != NumberOfUnpackFiles) LBytesX = new byte[((this.binaryReader_0.BaseStream.Length / NumberOfUnpackFiles) * CurrentFile) - ((this.binaryReader_0.BaseStream.Length / NumberOfUnpackFiles) * (CurrentFile - 1))];
            if (CurrentFile == NumberOfUnpackFiles) LBytesX = new byte[this.binaryReader_0.BaseStream.Length - ((this.binaryReader_0.BaseStream.Length / NumberOfUnpackFiles) * (CurrentFile - 1))];

            label1.Text = "Reading: " + CurrentFile + "/" + NumberOfUnpackFiles;
            //LogThis("Reading: " + CurrentFile + "/" + NumberOfUnpackFiles);
            for (int i = 0; i < LBytesX.Length; i++)
            {
                progressBar1.Value = (i * 100) / LBytesX.Length;
                LBytesX[i] = this.binaryReader_0.ReadByte();
            }

            //LogThis("Compacting...");
            label1.Text = "Compacting: 1/3";
            //LogThis("   Compacting: 1/3");
            progressBar1.Value = (1 * 100) / 3;
            LBytesX = method_92_INT(LBytesX);

            label1.Text = "Compacting: 2/3";
            //LogThis("   Compacting: 2/3");
            progressBar1.Value = (2 * 100) / 3;
            LBytesX = method_92(LBytesX);

            label1.Text = "Compacting: 3/3";
            //LogThis("   Compacting: 3/3");
            progressBar1.Value = (3 * 100) / 3;
            LBytesX = method_inv(LBytesX);

            FileStream stream;
            FileInfo info = new FileInfo(pathSave + CurrentFile + ".txt");
            if (info.Exists) stream = new FileStream(pathSave + CurrentFile + ".txt", FileMode.Truncate, FileAccess.Write);
            else stream = new FileStream(pathSave + CurrentFile + ".txt", FileMode.CreateNew, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(stream);

            label1.Text = "Saving: " + CurrentFile + "/" + NumberOfUnpackFiles;
            //LogThis("Saving: " + CurrentFile + "/" + NumberOfUnpackFiles);
            for (int i = 0; i < LBytesX.Length; i++)
            {
                progressBar1.Value = (i * 100) / LBytesX.Length;
                writer.Write(LBytesX[i]);
            }
            writer.Close();
            writer.Dispose();
            writer = null;
            stream.Close();
            stream.Dispose();
            stream = null;
            LBytesX = null;
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers(); // wait until GC has finished its work
            GC.Collect(GC.MaxGeneration);

            //LogThis("---------------------------------------");

            CurrentFile++;
        }

        byte[] method_inv(byte[] byte_01) {
            byte[] byte_02 = new byte[byte_01.Length];
            for (int i = 0; i < byte_01.Length; i++) byte_02[byte_01.Length - 1 - i] = byte_01[i];

            byte_01 = byte_02;
            byte_02 = null;
            return byte_01;
        }*/

        /*byte method_92_c(byte[] byte_01)
        {
            int int_92_0 = 0;
            for (int i = 0; i < byte_01.Length; i++)
            {
                int_92_0 = int_92_0 + (int)byte_01[i];
                if (int_92_0 > 255) int_92_0 = int_92_0 - 256;
            }
            return (byte)int_92_0;
        }

        byte[] method_92(byte[] byte_01)
        {
            byte byte92 = method_92_c(byte_01);
            byte[] byte_02 = new byte[byte_01.Length + 1];
            for (int i = 0; i < byte_01.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    int int_01 = (int)byte_01[i] + byte92;
                    if (int_01 > 255) int_01 -= 256;
                    byte_02[i] = (byte)int_01;
                }
                else
                {
                    int int_01 = (int)byte_01[i] - byte92;
                    if (int_01 < 0) int_01 += 256;
                    byte_02[i] = (byte)int_01;
                }
            }
            byte_02[byte_01.Length] = byte92;
            byte_02 = method_942(byte_02);

            byte_01 = byte_02;
            byte_02 = null;
            return byte_01;
        }

        byte[] method_942(byte[] byte_01)
        {
            byte byte92 = method_92_c(byte_01);
            byte[] byte_02 = new byte[byte_01.Length + 9];
            int int_99 = 0;
            for (int i = 0; i < byte_01.Length; i++)
            {
                int int_01 = (int)byte_01[i] - byte92;
                if (int_01 < 0) int_01 += 256;
                byte_02[int_99] = (byte)int_01;

                int int_02 = i + 1;
                if (int_02 == Encrypt1 || int_02 == Encrypt2 || int_02 == Encrypt3 || int_02 == Encrypt4 || int_02 == Encrypt5)
                {
                    int_99++;
                    byte_02[int_99] = byte92;
                    byte92 = method_92_c(byte_02);
                }
                int_99++;
            }
            byte_02[byte_02.Length - 1] = byte92;

            byte_01 = byte_02;
            byte_02 = null;
            return byte_01;
        }

        //Compress
        byte[] method_92_INT(byte[] byte_01)
        {
            byte[] byte_02 = new byte[byte_01.Length];

            for (int i = 0; i < byte_01.Length; i++)
            {
                int int_01 = (int)byte_01[i] - EncryptEnd;
                if (int_01 < 0) int_01 += 256;
                byte_02[i] = (byte)int_01;
            }

            byte_01 = byte_02;
            byte_02 = null;
            return byte_01;
        }*/

        private void Button1_Click(object sender, EventArgs e)
        {
            EncryptedCount = 0;
            label1.Text = "";
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            Loading = true;
            BMTuneDo = true;
            BufferTime = DateTime.Now;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            Loading = true;
            BMTuneDo = false;
            BufferTime = DateTime.Now;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process.Start(pathStarterProject);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            DoAllAtOnce = checkBox1.Checked;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            LoadLocations();
            RedoSettings();
            RedoCSPROJ();
            BuildSolution();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.Refresh();
        }


        /*public string GetExecutingFileHash()
        {
            return MD5(GetSelfBytes());
        }

        private string MD5(byte[] input)
        {
            return MD5(ASCIIEncoding.ASCII.GetString(input));
        }

        private string MD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }

        private byte[] GetSelfBytes()
        {
            FileStream running = File.OpenRead(pathStarter);

            byte[] exeBytes = new byte[running.Length];
            running.Read(exeBytes, 0, exeBytes.Length);

            running.Close();

            return exeBytes;
        }*/

        //###################################################################

        /*byte[] method_93(byte[] byte_01, int Ver)
        {
            byte_01 = method_95(byte_01, Ver);

            byte byte92 = byte_01[byte_01.Length - 1];
            byte[] byte_02 = new byte[byte_01.Length - 1];
            for (int i = 0; i < byte_02.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    int int_01 = (int)byte_01[i] - byte92;
                    if (int_01 < 0) int_01 += 256;
                    byte_02[i] = (byte)int_01;
                }
                else
                {
                    int int_01 = (int)byte_01[i] + byte92;
                    if (int_01 > 255) int_01 -= 256;
                    byte_02[i] = (byte)int_01;
                }
            }
            return byte_02;
        }

        byte[] method_95(byte[] byte_01, int Ver)
        {
            byte byte92_1 = byte_01[16];
            byte byte92_2 = byte_01[32 + 1];
            byte byte92_3 = byte_01[48 + 2];
            byte byte92_4 = byte_01[64 + 3];
            byte byte92_5 = byte_01[80 + 4];
            //byte byte92_6 = byte_01[96 + 5];
            if (Ver == 1)
            {
                byte92_1 = byte_01[15];
                byte92_2 = byte_01[25 + 1];
                byte92_3 = byte_01[53 + 2];
                byte92_4 = byte_01[67 + 3];
                byte92_5 = byte_01[78 + 4];
            }
            if (Ver == 2)
            {
                byte92_1 = byte_01[17];
                byte92_2 = byte_01[35 + 1];
                byte92_3 = byte_01[45 + 2];
                byte92_4 = byte_01[63 + 3];
                byte92_5 = byte_01[82 + 4];
            }
            byte byte92_9 = byte_01[byte_01.Length - 1];
            byte byte92 = 0;
            byte[] byte_02 = new byte[byte_01.Length - 9];
            int int_99 = 0;
            for (int i = 0; i < byte_02.Length; i++)
            {
                //if (i < 96) byte92 = byte92_6;
                if (Ver == 0)
                {
                    if (i < 80) byte92 = byte92_5;
                    if (i < 64) byte92 = byte92_4;
                    if (i < 48) byte92 = byte92_3;
                    if (i < 32) byte92 = byte92_2;
                    if (i < 16) byte92 = byte92_1;

                    if (i >= 80) byte92 = byte92_9;
                    if (i == 16 || i == 32 || i == 48 || i == 64 || i == 80) int_99++;
                }
                if (Ver == 1)
                {
                    if (i < 78) byte92 = byte92_5;
                    if (i < 67) byte92 = byte92_4;
                    if (i < 53) byte92 = byte92_3;
                    if (i < 25) byte92 = byte92_2;
                    if (i < 15) byte92 = byte92_1;

                    if (i >= 78) byte92 = byte92_9;
                    if (i == 15 || i == 25 || i == 53 || i == 67 || i == 78) int_99++;
                }
                if (Ver == 2)
                {
                    if (i < 82) byte92 = byte92_5;
                    if (i < 63) byte92 = byte92_4;
                    if (i < 45) byte92 = byte92_3;
                    if (i < 35) byte92 = byte92_2;
                    if (i < 17) byte92 = byte92_1;

                    if (i >= 82) byte92 = byte92_9;
                    if (i == 17 || i == 35 || i == 45 || i == 63 || i == 82) int_99++;
                }

                int int_01 = (int)byte_01[int_99] + byte92;
                if (int_01 > 255) int_01 -= 256;
                byte_02[i] = (byte)int_01;

                int_99++;
            }
            return byte_02;
        }

        //Decompress
        byte[] method_93_INT(byte[] byte_01, int Ver)
        {
            byte[] byte_02 = new byte[byte_01.Length];

            for (int i = 0; i < byte_01.Length; i++)
            {
                int TConute = 33;
                if (Ver == 1) TConute = 47;
                if (Ver == 2) TConute = 55;
                int int_01 = (int)byte_01[i] + TConute;
                if (int_01 > 255) int_01 -= 256;
                byte_02[i] = (byte)int_01;
            }

            return byte_02;
        }*/
    }
    }
