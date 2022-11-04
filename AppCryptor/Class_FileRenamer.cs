using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace AppCryptor
{
    public class Class_FileRenamer
    {
        Form1 form1_0;

        public List<string> AllFilenameDone = new List<string>();
        public List<string> AllFilenameDoneCrypted = new List<string>();
        public string ClassStarterDefault = "Class22_startup";
        public string ClassStarter = "";

        public Class_FileRenamer(ref Form1 Form1_1)
        {
            form1_0 = Form1_1;
        }

        public void RemadeAllFilenames()
        {
            form1_0.ClearLogs();
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Renaming Files names...");

            if (AllFilenameDone != null) AllFilenameDone.Clear();
            AllFilenameDone = new List<string>();

            if (AllFilenameDoneCrypted != null) AllFilenameDoneCrypted.Clear();
            AllFilenameDoneCrypted = new List<string>();

            int currenn = 0;

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
                    && !file.Contains("BMFuscator")
                    && !file.Contains("BMTune_Packer")
                    && !file.Contains("AppCryptor")
                    && !file.Contains("Resources.Designer.cs")
                    && !file.Contains("AssemblyInfo.cs")
                    && !file.Contains("DoNotObfuscate.cs")
                    && !file.Contains("WebClient.cs")
                    && !file.Contains(@"\bin\")
                    && !file.Contains(@"\Debug\")
                    && !file.Contains(@"\obj\")
                    && !file.Contains(@".zip"))
                {

                    string PreviousFName = Path.GetFileNameWithoutExtension(file);
                    string NewFName = form1_0.Class_Text_0.CreateCryptedTextNumber(4, 5);

                    if (file.Contains(ClassStarterDefault)) ClassStarter = NewFName;

                    while (HasThisFileName(NewFName))
                    {
                        NewFName = form1_0.Class_Text_0.CreateCryptedTextNumber(4, 5);
                    }

                    form1_0.AllCurrentClassLines = File.ReadAllLines(file);
                    form1_0.CurrentClassName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 3);

                    if (form1_0.checkBox1.Checked) form1_0.LogThis("Renaming File: " + Path.GetFileName(file));

                    for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
                    {
                        form1_0.AllCurrentClassLines[i] = form1_0.AllCurrentClassLines[i].Replace(" " + PreviousFName, " " + NewFName);
                    }

                    string Dirrr = new DirectoryInfo(Path.GetDirectoryName(file)).Name;
                    if (Dirrr == "BMTune2_Crypted") Dirrr = "";

                    string FilenameSave = form1_0.ProjectLocationCrypted + @"\" + NewFName;
                    if (Dirrr != "") FilenameSave = form1_0.ProjectLocationCrypted + @"\" + Dirrr + @"\" + NewFName;
                    if (Dirrr == "Settings") FilenameSave = form1_0.ProjectLocationCrypted + @"\Dal\" + Dirrr + @"\" + NewFName;

                    string FilenameOldSave = form1_0.ProjectLocationCrypted + @"\" + PreviousFName;
                    if (Dirrr != "") FilenameOldSave = form1_0.ProjectLocationCrypted + @"\" + Dirrr + @"\" + PreviousFName;
                    if (Dirrr == "Settings") FilenameOldSave = form1_0.ProjectLocationCrypted + @"\Dal\" + Dirrr + @"\" + PreviousFName;

                    File.Create(FilenameSave + ".cs").Dispose();
                    File.WriteAllLines(FilenameSave + ".cs", form1_0.AllCurrentClassLines);

                    if (File.Exists(FilenameOldSave + ".resx"))
                    {
                        File.Create(FilenameSave + ".resx").Dispose();
                        File.WriteAllBytes(FilenameSave + ".resx", File.ReadAllBytes(FilenameOldSave + ".resx"));

                        File.Delete(FilenameOldSave + ".resx");
                    }

                    if (File.Exists(FilenameOldSave + ".cs")) File.Delete(FilenameOldSave + ".cs");

                    /*PreviousFName2 = PreviousFName;
                    NewFName2 = NewFName;
                    
                    BackgroundWorker buffworker = new BackgroundWorker();
                    buffworker.WorkerSupportsCancellation = false;
                    buffworker.WorkerReportsProgress = false;
                    buffworker.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
                    buffworker.RunWorkerAsync();*/

                    AllFilenameDone.Add(PreviousFName);
                    AllFilenameDoneCrypted.Add(NewFName);

                    this.form1_0.Class_Variables_0.AllMethods.Add(PreviousFName);
                    this.form1_0.Class_Variables_0.AllMethodsCrypted.Add(NewFName);

                    //RenameInAllFiles(" " + PreviousFName, " " + NewFName);
                    //RenameIncsproj(PreviousFName, NewFName);
                }

                currenn++;
            }

            form1_0.progressBar1.Value = 0;

            RenameInAllFiles();
            RenameIncsproj();
        }

        public bool HasThisFileName(string ThisM)
        {
            for (int i = 0; i < AllFilenameDone.Count; i++) if (AllFilenameDone[i] == ThisM) return true;
            return false;
        }

        //private void RenameInAllFiles(string OldStr, string NewStr)
        private void RenameInAllFiles()
        {
            int currenn = 0;

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
                    && !file.Contains("BMFuscator")
                    && !file.Contains("BMTune_Packer")
                    && !file.Contains("AppCryptor")
                    && !file.Contains(@"\bin\")
                    && !file.Contains(@"\Debug\")
                    && !file.Contains(@"\obj\")
                    && !file.Contains(@".zip"))
                {
                    //try
                    if (Path.GetFileName(file) != form1_0.CurrentClassName + ".cs")
                    {
                        form1_0.AllCurrentClassLines = File.ReadAllLines(file);

                        for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
                        {
                            if (form1_0.AllCurrentClassLines[i] != string.Empty
                                || form1_0.AllCurrentClassLines[i].Replace("\t", "") != string.Empty
                                || form1_0.AllCurrentClassLines[i].Replace("\t", "") != "{"
                                || form1_0.AllCurrentClassLines[i].Replace("\t", "") != "}"
                                || form1_0.AllCurrentClassLines[i].Replace(" ", "") != string.Empty)
                            {
                                for (int i2 = 0; i2 < AllFilenameDone.Count; i2++)
                                {
                                    string StartLine = form1_0.AllCurrentClassLines[i];

                                    string OldStr = AllFilenameDone[i2];
                                    string NewStr = AllFilenameDoneCrypted[i2];
                                    form1_0.AllCurrentClassLines[i] = form1_0.AllCurrentClassLines[i].Replace(OldStr, NewStr);

                                    if (form1_0.AllCurrentClassLines[i] != StartLine) if (form1_0.checkBox4.Checked) form1_0.LogThis("Changed Filename: " + OldStr);
                                }
                            }
                        }

                        File.Create(file).Dispose();
                        File.WriteAllLines(file, form1_0.AllCurrentClassLines);
                    }
                    //catch { }
                }

                currenn++;
            }

            form1_0.progressBar1.Value = 0;
        }

        //private void RenameIncsproj(string OldStr, string NewStr)
        private void RenameIncsproj()
        {
            string pattern = @"\.csproj$";
            var matches = Directory.GetFiles(form1_0.ProjectLocationCrypted, "*", SearchOption.AllDirectories).Where(path => Regex.Match(path, pattern).Success);

            //check in all '*.cs' files
            foreach (string file in matches)
            {
                if (!file.Contains("BMTune_Installer")
                    && !file.Contains("BMTune_Licenser")
                    && !file.Contains("BMTune_Server")
                    && !file.Contains("BMTune_Starter")
                    && !file.Contains("BMTune_Uploader")
                    && !file.Contains("BMTune_Encrypter")
                    && !file.Contains("BMFuscator")
                    && !file.Contains("BMTune_Packer")
                    && !file.Contains("AppCryptor")
                    && !file.Contains(@"\bin\")
                    && !file.Contains(@"\Debug\")
                    && !file.Contains(@"\obj\")
                    && !file.Contains(@".zip"))
                {
                    form1_0.AllCurrentClassLines = File.ReadAllLines(file);

                    for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
                    {
                        if (form1_0.AllCurrentClassLines[i] != string.Empty
                                || form1_0.AllCurrentClassLines[i].Replace("\t", "") != string.Empty
                                || form1_0.AllCurrentClassLines[i].Replace("\t", "") != "{"
                                || form1_0.AllCurrentClassLines[i].Replace("\t", "") != "}"
                                || form1_0.AllCurrentClassLines[i].Replace(" ", "") != string.Empty)
                        {
                            for (int i2 = 0; i2 < AllFilenameDone.Count; i2++)
                            {
                                string OldStr = AllFilenameDone[i2];
                                string NewStr = AllFilenameDoneCrypted[i2];
                                form1_0.AllCurrentClassLines[i] = form1_0.AllCurrentClassLines[i].Replace(OldStr + ".cs", NewStr + ".cs");
                                form1_0.AllCurrentClassLines[i] = form1_0.AllCurrentClassLines[i].Replace(OldStr + ".resx", NewStr + ".resx");
                            }
                            form1_0.AllCurrentClassLines[i] = form1_0.AllCurrentClassLines[i].Replace("<StartupObject>" + ClassStarterDefault, "<StartupObject>" + ClassStarter);
                        }
                    }

                    File.Create(file).Dispose();
                    File.WriteAllLines(file, form1_0.AllCurrentClassLines);
                }
            }
        }
    }
}
