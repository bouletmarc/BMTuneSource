using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace AppCryptor
{
    public class Class_StringCrypter
    {
        Form1 form1_0;

        bool HasFoundString = false;
        bool IsStaticClass = false;

        Random rnd = new Random();

        int CryptedStringNumber = 0;
        int CryptedStringNumber2 = 0;

        public Class_StringCrypter(ref Form1 Form1_1)
        {
            form1_0 = Form1_1;
        }

        public void EncryptStringInFile(string ThisssClass, bool InDataFolder)
        {
            form1_0.ClearLogs();
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Encrypting string in file " + ThisssClass + "...");

            CryptedStringNumber = rnd.Next(15, 189);
            CryptedStringNumber2 = rnd.Next(15, 189);

            form1_0.label6.Text = "Doing: " + ThisssClass + ".cs (5/5)";
            form1_0.Refresh();

            HasFoundString = false;
            IsStaticClass = false;
            form1_0.listBox2.Items.Clear();

            string pattern = @"\.cs$";
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
                    && !file.Contains("Resources.Designer.cs")
                    && Path.GetFileName(file) == ThisssClass
                    && ((InDataFolder && file.Contains(@"\Data\")) || (!InDataFolder))
                    && !file.Contains(@"\bin\")
                    && !file.Contains(@"\Debug\")
                    && !file.Contains(@"\obj\"))
                {
                    form1_0.AllCurrentClassLines = File.ReadAllLines(file);
                    form1_0.CurrentClassName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 3);

                    for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
                    {
                        if (form1_0.AllCurrentClassLines[i].Contains("internal static class " + form1_0.CurrentClassName)) IsStaticClass = true;

                        form1_0.progressBar1.Value = (i * 100) / form1_0.AllCurrentClassLines.Length;
                        form1_0.AllCurrentClassLines[i] = ConvertStringToCrypting(form1_0.AllCurrentClassLines[i]);
                    }

                    form1_0.progressBar1.Value = 0;

                    if (HasFoundString) CreateCryptingStringMethod();

                    if (InDataFolder)
                    {
                        File.Create(form1_0.ProjectLocationCrypted + @"\Data\" + form1_0.CurrentClassName + ".cs").Dispose();
                        File.WriteAllLines(form1_0.ProjectLocationCrypted + @"\Data\" + form1_0.CurrentClassName + ".cs", form1_0.AllCurrentClassLines);
                    }
                    else
                    {
                        File.Create(form1_0.ProjectLocationCrypted + @"\" + form1_0.CurrentClassName + ".cs").Dispose();
                        File.WriteAllLines(form1_0.ProjectLocationCrypted + @"\" + form1_0.CurrentClassName + ".cs", form1_0.AllCurrentClassLines);
                    }
                }
            }

            form1_0.Refresh();
        }

        private string ConvertStringToCrypting(string ThisLine)
        {
            if (ThisLine.Contains(@""""))
            {
                string[] splitcmdds = ThisLine.Split('"');
                //1,3,5,7... = entry
                for (int i = 1; i < splitcmdds.Length; i += 2)
                {
                    string checkbefore = splitcmdds[i - 1];

                    string CurrentCheck = splitcmdds[i];

                    bool CanGo = true;
                    if (checkbefore.Length > 0) if (checkbefore[checkbefore.Length - 1] == '@') CanGo = false;
                    if (ThisLine.Contains("ManagementObject(")) CanGo = false;
                    if (ThisLine.Contains("@echo off")) CanGo = false;
                    if (HasUndesiredChar(CurrentCheck)) CanGo = false;
                    if (CurrentCheck == "") CanGo = false;
                    if (CurrentCheck.Length > 1)
                    {
                        if (CurrentCheck[0] == '\\' && CurrentCheck[1] == 'n' && CurrentCheck.Length == 2) ThisLine = ThisLine.Replace(@"""" + CurrentCheck + @"""", "Environment.NewLine");

                        //if (CurrentCheck[0] == '\\' && CurrentCheck[1] == 'n') CanGo = false;       //  \n
                        //if (CurrentCheck[0] == '\\' && CurrentCheck[1] == 'r') CanGo = false;      //  \r
                    }
                    /*if (CurrentCheck.Length > 3)
                    {
                        if (CurrentCheck[0] == '\\' && CurrentCheck[1] == 'r' && CurrentCheck[3] == '\\' && CurrentCheck[4] == 'n') CanGo = false;    //  \r\n
                        if (CurrentCheck[0] == '\\' && CurrentCheck[1] == 'n' && CurrentCheck[3] == '\\' && CurrentCheck[4] == 'r') CanGo = false;    //  \n\r
                    }*/

                    if (CanGo)
                    {
                        string OnlyCrypted = GetString(CurrentCheck);
                        string Encrypted = "";
                        for (int i2 = 0; i2 < OnlyCrypted.Length - 1; i2++)
                        {
                            string DoNowww = OnlyCrypted[i2].ToString() + OnlyCrypted[i2 + 1].ToString();
                            if (i2 != 0) Encrypted += " + ";
                            Encrypted += @"Thatteee(""" + DoNowww + @""")";

                            i2++;
                        }
                        ThisLine = ThisLine.Replace(@"""" + CurrentCheck + @"""", Encrypted);
                        form1_0.listBox2.Items.Add(CurrentCheck);
                        HasFoundString = true;
                    }
                }
            }

            return ThisLine;
        }

        public bool HasUndesiredChar(string str)
        {
            char LastChar = ' ';
            bool Undesired = false;

            foreach (char c in str)
            {
                if (LastChar == '\\' && c == 'n') Undesired = true;
                if (LastChar == '\\' && c == 't') Undesired = true;
                if (LastChar == '\\' && c == 'r') Undesired = true;

                LastChar = c;
            }

            return Undesired;
        }

        public string GetString(string ThisString)
        {
            //ThisString = GetString2(ThisString);
            int[] ThisArray = new int[ThisString.Length];

            for (int i = 0; i < ThisArray.Length; i++)
            {
                //ThisArray[i] = (Int32)ThisString[i];

                ThisArray[i] = CryptedStringNumber2;
                //ThisArray[i] = (Int32)ThisString[i] + CryptedStringNumber2;
                if (ThisArray[i] > 255) ThisArray[i] -= 256;


                ThisArray[i] += (Int32)ThisString[i];
                if (ThisArray[i] > 255) ThisArray[i] -= 256;
                ThisArray[i] += CryptedStringNumber;
                if (ThisArray[i] > 255) ThisArray[i] -= 256;
            }

            string ReturnText = "";
            for (int i = 0; i < ThisArray.Length; i++)
            {
                ReturnText += ThisArray[i].ToString("X2");
            }

            return ReturnText;
        }

        /*public string GetString2(string ThisString)
        {
            int[] ThisArray = new int[ThisString.Length];

            for (int i = 0; i < ThisArray.Length; i++)
            {
                ThisArray[i] = (Int32)ThisString[i];
                ThisArray[i] -= CryptedStringNumber2;
                if (ThisArray[i] < 0) ThisArray[i] += 256;
            }

            string ReturnText = "";
            for (int i = 0; i < ThisArray.Length; i++)
            {
                ReturnText += ThisArray[i].ToString("X2");
            }

            return ReturnText;
        }*/

        private void RepackWithEncryptedString()
        {
            string CrypteddString1 = form1_0.Class_Text_0.CreateCryptedText();
            string CrypteddString2 = form1_0.Class_Text_0.CreateCryptedText();
            string CrypteddString3 = form1_0.Class_Text_0.CreateCryptedText();
            string CrypteddString4 = form1_0.Class_Text_0.CreateCryptedText();
            //string CrypteddString5 = form1_0.Class_Text_0.CreateCryptedText();
            //string CrypteddString6 = form1_0.Class_Text_0.CreateCryptedText();

            for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
            {
                form1_0.AllCurrentClassLines[i] = form1_0.Class_Crypter_0.SearchAndReplace(form1_0.AllCurrentClassLines[i], "Thatteee", CrypteddString1, false);
                form1_0.AllCurrentClassLines[i] = form1_0.Class_Crypter_0.SearchAndReplace(form1_0.AllCurrentClassLines[i], "Returningere", CrypteddString2, false);
                form1_0.AllCurrentClassLines[i] = form1_0.Class_Crypter_0.SearchAndReplace(form1_0.AllCurrentClassLines[i], "Thistere", CrypteddString3, false);
                form1_0.AllCurrentClassLines[i] = form1_0.Class_Crypter_0.SearchAndReplace(form1_0.AllCurrentClassLines[i], "Hexefsfe", CrypteddString4, false);
                //form1_0.AllCurrentClassLines[i] = form1_0.Class_Crypter_0.SearchAndReplace(form1_0.AllCurrentClassLines[i], "Thatnertee", CrypteddString5, false);
                //form1_0.AllCurrentClassLines[i] = form1_0.Class_Crypter_0.SearchAndReplace(form1_0.AllCurrentClassLines[i], "Henrdfe", CrypteddString6, false);
            }
        }

        private void CreateCryptingStringMethod()
        {
            List<string> RemadeAllLines = new List<string>();

            for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
            {
                RemadeAllLines.Add(form1_0.AllCurrentClassLines[i]);

                if (i == form1_0.AllCurrentClassLines.Length - 3)
                {
                    RemadeAllLines.Add("");
                    if (!IsStaticClass) RemadeAllLines.Add("    private string Thatteee(string Hexefsfe)");
                    else RemadeAllLines.Add("    private static string Thatteee(string Hexefsfe)");
                    RemadeAllLines.Add("    {");
                    RemadeAllLines.Add(@"        string Returningere = """";");
                    RemadeAllLines.Add(@"        while (Hexefsfe != """")");
                    RemadeAllLines.Add("        {");
                    RemadeAllLines.Add("            try");
                    RemadeAllLines.Add("            {");
                    RemadeAllLines.Add("                int Thistere = Int32.Parse(Hexefsfe.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier) - " + CryptedStringNumber + ";");
                    RemadeAllLines.Add("                if (Thistere < 0) Thistere = 256 + Thistere;");
                    RemadeAllLines.Add("                Thistere -= " + CryptedStringNumber2 + ";");
                    RemadeAllLines.Add("                if (Thistere < 0) Thistere = 256 + Thistere;");
                    RemadeAllLines.Add("                Returningere += Convert.ToChar(Thistere).ToString();");
                    RemadeAllLines.Add("                Hexefsfe = Hexefsfe.Substring(2);");
                    RemadeAllLines.Add("            }");
                    RemadeAllLines.Add(@"            catch { Hexefsfe = """"; }");
                    RemadeAllLines.Add("        }");
                    RemadeAllLines.Add("        return Returningere;");
                    //RemadeAllLines.Add("        return Thatnertee(Returningere);");
                    RemadeAllLines.Add("    }");


                    /*if (!IsStaticClass) RemadeAllLines.Add("    private string Thatnertee(string Henrdfe)");
                    else RemadeAllLines.Add("    private static string Thatnertee(string Henrdfe)");
                    RemadeAllLines.Add("    {");
                    RemadeAllLines.Add(@"        string Returningere = """";");
                    RemadeAllLines.Add(@"        while (Henrdfe != """")");
                    RemadeAllLines.Add("        {");
                    RemadeAllLines.Add("            try");
                    RemadeAllLines.Add("            {");
                    RemadeAllLines.Add("                int Thistere = Int32.Parse(Henrdfe.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier) + " + CryptedStringNumber2 + ";");
                    RemadeAllLines.Add("                if (Thistere > 255) Thistere = 0;");
                    RemadeAllLines.Add("                Returningere += Convert.ToChar(Thistere).ToString();");
                    RemadeAllLines.Add("                Henrdfe = Henrdfe.Substring(2);");
                    RemadeAllLines.Add("            }");
                    RemadeAllLines.Add(@"            catch { Henrdfe = """"; }");
                    RemadeAllLines.Add("        }");
                    RemadeAllLines.Add("        return Returningere;");
                    RemadeAllLines.Add("    }");*/
                }
            }

            form1_0.AllCurrentClassLines = new string[RemadeAllLines.Count];
            for (int i = 0; i < RemadeAllLines.Count; i++) form1_0.AllCurrentClassLines[i] = RemadeAllLines[i];

            RepackWithEncryptedString();
        }
    }
}
