using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppCryptor
{
    public class Class_CreateFiles
    {
        Form1 form1_0;

        public Class_CreateFiles(ref Form1 Form1_1)
        {
            form1_0 = Form1_1;
        }

        public void RemoveFiles()
        {
            form1_0.ClearLogs();
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Removing files at encrypted location...");

            form1_0.Class_Text_0.ClearRemake();

            int currenn = 0;

            var matches = Directory.GetFiles(form1_0.ProjectLocationCrypted, "*", SearchOption.AllDirectories);
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
                    //&& !file.Contains(@"\bin\")
                    //&& !file.Contains(@"\Debug\")
                    //&& !file.Contains(@"\obj\")
                    && (Path.GetExtension(file) == ".cs"
                        || Path.GetExtension(file) == ".resx"
                        || Path.GetExtension(file) == ".resources"
                        || Path.GetExtension(file) == ".csproj"
                        || Path.GetExtension(file) == ".zip"))
                {
                    File.Delete(file);
                    if (form1_0.checkBox1.Checked) form1_0.LogThis("Removed: " + Path.GetFileName(file));
                }

                currenn++;
            }

            form1_0.progressBar1.Value = 0;
        }

        public void MakeFiles()
        {
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Copying files to encrypted location...");

            int currenn = 0;

            string AllFilesListSave = "";

            var matches = Directory.GetFiles(form1_0.ProjectLocation, "*", SearchOption.AllDirectories);
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
                    //&& !file.Contains(@"\bin\")
                    //&& !file.Contains(@"\Debug\")
                    && !file.Contains(@"\obj\")
                    && (Path.GetExtension(file) == ".cs"
                        || Path.GetExtension(file) == ".resx"
                        || Path.GetExtension(file) == ".resources"
                        || Path.GetExtension(file) == ".csproj"
                        || Path.GetExtension(file) == ".zip"))
                {

                    bool IsSaved = false;
                    while (!IsSaved)
                    {
                        string newfile = file.Replace(@"\BMTune2", @"\BMTune2_Crypted");
                        try
                        {
                            File.Create(newfile).Dispose();
                            File.WriteAllBytes(newfile, File.ReadAllBytes(file));
                            IsSaved = true;

                            if (form1_0.checkBox1.Checked) form1_0.LogThis("Created: " + Path.GetFileName(newfile));


                            AllFilesListSave += Path.GetFileName(newfile) + Environment.NewLine;

                            if (Path.GetExtension(file) == ".cs")
                            {
                                string CheckNamee = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 3);

                                form1_0.Class_Text_0.AddToNotEncrypt(CheckNamee);
                                form1_0.Class_Text_0.AddToNotEncryptClass(CheckNamee[0].ToString().ToLower() + CheckNamee.Substring(1) + "_0", form1_0.Class_Text_0.CreateCryptedText());
                                form1_0.Class_Text_0.AddToNotEncryptClass(CheckNamee[0].ToString().ToLower() + CheckNamee.Substring(1) + "_1", form1_0.Class_Text_0.CreateCryptedText());
                                form1_0.Class_Text_0.AddToNotEncryptClass(CheckNamee[0].ToString().ToUpper() + CheckNamee.Substring(1) + "_0", form1_0.Class_Text_0.CreateCryptedText());
                                form1_0.Class_Text_0.AddToNotEncryptClass(CheckNamee[0].ToString().ToUpper() + CheckNamee.Substring(1) + "_1", form1_0.Class_Text_0.CreateCryptedText());


                                if (CheckNamee.Contains("_"))
                                {
                                    string TestCheck1 = CheckNamee.Split('_')[0];
                                    CheckAndAddNotEncrypt(TestCheck1[0].ToString().ToLower() + CheckNamee.Substring(1) + "_0");
                                    CheckAndAddNotEncrypt(TestCheck1[0].ToString().ToLower() + CheckNamee.Substring(1) + "_1");
                                    CheckAndAddNotEncrypt(TestCheck1[0].ToString().ToUpper() + CheckNamee.Substring(1) + "_0");
                                    CheckAndAddNotEncrypt(TestCheck1[0].ToString().ToUpper() + CheckNamee.Substring(1) + "_1");
                                }
                            }
                        }
                        catch (Exception mess)
                        {
                            form1_0.LogThis("CANT SAVE " + Path.GetFileName(file) + Environment.NewLine + mess);
                            Thread.Sleep(2000);
                        }
                    }
                }

                currenn++;
            }


            File.Create(Application.StartupPath + @"\FilesInfos.txt").Dispose();
            File.WriteAllText(Application.StartupPath + @"\FilesInfos.txt", AllFilesListSave);

            form1_0.progressBar1.Value = 0;
        }

        private void CheckAndAddNotEncrypt(string ThisCheck)
        {
            bool FoundIt = false;
            for (int i = 0; i < form1_0.Class_Text_0.NotCryptedClassList.Count; i++)
            {
                if (form1_0.Class_Text_0.NotCryptedClassList[i] == ThisCheck) FoundIt = true;
            }

            if (!FoundIt) form1_0.Class_Text_0.AddToNotEncryptClass(ThisCheck, form1_0.Class_Text_0.CreateCryptedText());
        }
    }
}
