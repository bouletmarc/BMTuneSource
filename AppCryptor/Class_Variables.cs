using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AppCryptor
{
    public class Class_Variables
    {
        Form1 form1_0;

        public List<string> AllMethods = new List<string>();
        public List<string> AllMethodsCrypted = new List<string>();
        public List<bool> AllMethodsPublic = new List<bool>();
        public List<string> AllMethodsSource = new List<string>();

        private bool DoingEnum = false;
        private int CurlyCount = 0;

        public Class_Variables(ref Form1 Form1_1)
        {
            form1_0 = Form1_1;
        }

        //public void GetVariables()
        public void GetVariables(string ThisssClass, bool InDataFolder)
        {
            form1_0.ClearLogs();
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Getting variables in " + ThisssClass + "...");

            DoingEnum = false;
            CurlyCount = 0;

            form1_0.label6.Text = "Doing: " + ThisssClass + " (1/5)";
            form1_0.Refresh();

            if (AllMethods != null) AllMethods.Clear();
            AllMethods = new List<string>();

            if (AllMethodsPublic != null) AllMethodsPublic.Clear();
            AllMethodsPublic = new List<bool>();

            if (AllMethodsCrypted != null) AllMethodsCrypted.Clear();
            AllMethodsCrypted = new List<string>();

            if (AllMethodsSource != null) AllMethodsSource.Clear();
            AllMethodsSource = new List<string>();

            string pattern = @"\.cs$";
            var matches = Directory.GetFiles(form1_0.ProjectLocation, "*", SearchOption.AllDirectories).Where(path => Regex.Match(path, pattern).Success);

            //check in all '*.cs' files
            int currenn = 0;
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
                    && !file.Contains(@"\bin\")
                    && !file.Contains(@"\Debug\")
                    && ((InDataFolder && file.Contains(@"\Data\")) || (!InDataFolder))
                    && !file.Contains(@"\obj\")
                    && Path.GetFileName(file) == ThisssClass
                        //&& (file.Contains("Class15.cs")
                        //|| file.Contains("Class18_file.cs")
                        //|| file.Contains("FrmMain.cs")
                        //|| file.Contains("Class31.cs"))
                        )
                {
                    form1_0.AllCurrentClassLines = File.ReadAllLines(file);
                    form1_0.CurrentFile = file; //Path.GetFileName(file);

                    //if (form1_0.checkBox1.Checked) form1_0.LogThis2("Checking " + Path.GetFileName(form1_0.CurrentFile));

                    for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
                    {
                        if (InDataFolder)
                        {
                            if (form1_0.AllCurrentClassLines[i].Contains("public enum ")) DoingEnum = true;
                            if (form1_0.AllCurrentClassLines[i].Contains("internal enum ")) DoingEnum = true;
                            if (form1_0.AllCurrentClassLines[i].Contains("public static enum ")) DoingEnum = true;
                            if (form1_0.AllCurrentClassLines[i].Contains("internal static enum ")) DoingEnum = true;

                            if (DoingEnum && form1_0.AllCurrentClassLines[i].Contains("{")) CurlyCount++;
                            if (DoingEnum && CurlyCount > 0 && form1_0.AllCurrentClassLines[i].Contains("}")) CurlyCount--;
                        }

                        if (form1_0.AllCurrentClassLines[i].Contains("public ") || form1_0.AllCurrentClassLines[i].Contains("public static "))
                        {
                            if (!form1_0.AllCurrentClassLines[i].Contains("static ")) CheckPublicPrivate("public ", form1_0.AllCurrentClassLines[i].Substring(form1_0.AllCurrentClassLines[i].LastIndexOf("public ")));
                            else CheckPublicPrivate("public static ", form1_0.AllCurrentClassLines[i].Substring(form1_0.AllCurrentClassLines[i].LastIndexOf("public static ")));
                        }
                        else if (form1_0.AllCurrentClassLines[i].Contains("private ") || form1_0.AllCurrentClassLines[i].Contains("private static "))
                        {
                            if (!form1_0.AllCurrentClassLines[i].Contains("static ")) CheckPublicPrivate("private ", form1_0.AllCurrentClassLines[i].Substring(form1_0.AllCurrentClassLines[i].LastIndexOf("private ")));
                            else CheckPublicPrivate("private static ", form1_0.AllCurrentClassLines[i].Substring(form1_0.AllCurrentClassLines[i].LastIndexOf("private static ")));
                        }
                        else if (form1_0.AllCurrentClassLines[i].Contains("internal ") || form1_0.AllCurrentClassLines[i].Contains("internal static "))
                        {
                            if (!form1_0.AllCurrentClassLines[i].Contains("static ")) CheckPublicPrivate("internal ", form1_0.AllCurrentClassLines[i].Substring(form1_0.AllCurrentClassLines[i].LastIndexOf("internal ")));
                            else CheckPublicPrivate("internal static ", form1_0.AllCurrentClassLines[i].Substring(form1_0.AllCurrentClassLines[i].LastIndexOf("internal static ")));
                        }
                        else
                        {
                            CheckOthersVariables(form1_0.AllCurrentClassLines[i]);
                        }
                    }
                }

                currenn++;
            }

            //GetAllPublicVariables();
            //StartWaitProcess();

            form1_0.progressBar1.Value = 0;
        }

        public void CheckOthersVariables(string VLine)
        {
            if (DoingEnum)
            {
                VLine = VLine.Replace("\t", "");
                VLine = VLine.Replace(" ", "");

                if (VLine.Contains(","))
                {
                    string[] VLinSpl = VLine.Split(',');

                    for (int i = 0; i < VLinSpl.Length; i++)
                    {
                        string EndStringVariable = VLinSpl[i];

                        if (VLinSpl[i].Contains("="))
                        {
                            string[] VLinSplBuf = VLinSpl[i].Split('=');
                            EndStringVariable = VLinSplBuf[0];
                        }

                        AddThisVariable(EndStringVariable, "Enum", true);
                    }
                }
                else if (CurlyCount > 0)
                {
                    if (VLine != string.Empty)
                    {
                        string EndStringVariable = VLine;

                        if (VLine.Contains("="))
                        {
                            string[] VLinSplBuf = VLine.Split('=');
                            EndStringVariable = VLinSplBuf[0];
                        }

                        AddThisVariable(EndStringVariable, "Enum", true);
                    }
                }
            }
            else
            {
                if (VLine.Contains("(") && !VLine.Contains("for")) VLine = VLine.Substring(0, VLine.IndexOf("("));
                if (VLine.Contains(";")) VLine = VLine.Substring(0, VLine.IndexOf(";"));
                if (VLine.Contains("=")) VLine = VLine.Substring(0, VLine.IndexOf("="));
                if (VLine.Contains('\"')) VLine = VLine.Substring(0, VLine.IndexOf('\"'));

                if (VLine.Contains(" "))
                {
                    string[] VLinSpl = VLine.Split(' ');

                    for (int i = 0; i < VLinSpl.Length; i++)
                    {
                        if (IsParam(VLinSpl[i]) && VLinSpl.Length > i + 2)
                        {
                            AddThisVariable(VLinSpl[i + 1], "infile", false);
                        }
                    }
                }
            }
        }

        public void AddThisVariable(string ThisVariable, string StyleMode, bool IsPublic)
        {
            if (ThisVariable.Length > 0)
            {
                if (ThisVariable[0] == '(') ThisVariable = ThisVariable.Substring(1);

                if (!IsDigitsOnly(ThisVariable))
                {
                    if (IsCorrectName(ThisVariable) && IsCorrectMethod(ThisVariable))
                    {
                        if (!HadMethod(ThisVariable, Path.GetFileName(form1_0.CurrentFile)))
                        {
                            AllMethods.Add(ThisVariable);
                            AllMethodsPublic.Add(IsPublic);
                            AllMethodsSource.Add(Path.GetFileName(form1_0.CurrentFile));
                            AllMethodsCrypted.Add(form1_0.Class_Text_0.CreateCryptedText());

                            if (form1_0.checkBox1.Checked) form1_0.LogThis("Created " + StyleMode + " " + ThisVariable + " (" + Path.GetFileName(form1_0.CurrentFile) + ")");

                            //Console.WriteLine("Created " + StyleMode + " " + EndStringVariable + " (" + Path.GetFileName(form1_0.CurrentFile) + ")");
                        }
                    }
                }
            }
        }

        public bool IsDigitsOnly(string str)
        {
            bool IsDigitOnly = true;

            if (str.Length > 0)
            {

                if (str[0] == '-') return true;

                foreach (char c in str)
                {
                    if (c < '0' || c > '9') IsDigitOnly = false;
                }
            }

            return IsDigitOnly;
        }

        public bool IsCorrectName(string ThisM)
        {
            if (ThisM == "{") return false;
            if (ThisM == "}") return false;
            if (ThisM == "[") return false;
            if (ThisM == "]") return false;
            if (ThisM == " ") return false;
            if (ThisM == ")") return false;
            if (ThisM == "(") return false;
            if (ThisM == ";") return false;
            if (ThisM == ":") return false;
            if (ThisM == ",") return false;
            if (ThisM == ".") return false;
            if (ThisM == "<") return false;
            if (ThisM == ">") return false;
            if (ThisM == "=") return false;
            if (ThisM == "!") return false;
            if (ThisM == "-") return false;

            return true;
        }

        public bool IsParam(string ThisM)
        {
            bool InListss = false;
            for (int i = 0; i < form1_0.Class_Text_0.NotCryptedText.Count; i++)
            {
                if (form1_0.Class_Text_0.NotCryptedText[i] == "")
                {
                    InListss = true;
                    i++;
                }
                if (InListss && 
                    (form1_0.Class_Text_0.NotCryptedText[i] == ThisM
                    || "(" + form1_0.Class_Text_0.NotCryptedText[i] == ThisM
                    || "." + form1_0.Class_Text_0.NotCryptedText[i] == ThisM)) return true;
            }
            return false;
        }

        public void CheckPublicPrivate(string ThisCheck, string VLine)
        {
            //private string[] GetAllLinesFromBytes(byte[] AllBytesArr)
            //string[] GetAllLinesFromBytes(byte[] AllBytesArr)

            string VLineEnd = "";

            if (VLine.Contains("("))
            {
                VLineEnd = VLine.Substring(VLine.IndexOf("("));
                VLine = VLine.Substring(0, VLine.IndexOf("("));
            }

            if (VLine.Contains(" ") || VLineEnd.Contains(" "))
            {
                if (VLineEnd != "")
                {
                    string[] VLinSplEnd = VLineEnd.Split(' ');
                    for (int i = 0; i < VLinSplEnd.Length; i++)
                    {
                        if (IsParam(VLinSplEnd[i]) && VLinSplEnd.Length > i + 1)
                        {
                            VLinSplEnd[i + 1] = VLinSplEnd[i + 1].Replace(",", "");
                            VLinSplEnd[i + 1] = VLinSplEnd[i + 1].Replace(")", "");

                            AddThisVariable(VLinSplEnd[i + 1], "infile", false);
                        }
                    }
                }

                string[] VLinSpl = VLine.Split(' ');
                if (VLinSpl.Length >= 3)
                {
                    //Console.WriteLine(Path.GetFileName(CurrentFile) + "\t|" + ThisCheck + "|" + VLinSpl[2]);
                    VLinSpl[2] = VLinSpl[2].Replace(";", "");

                    if (!HadMethod(VLinSpl[2], Path.GetFileName(form1_0.CurrentFile)))
                    {
                        if (IsCorrectMethod(VLinSpl[2]))
                        {
                            bool IsPublic = false;
                            if (ThisCheck == "public " || ThisCheck == "internal ") IsPublic = true;

                            AddThisVariable(VLinSpl[2], ThisCheck.Replace(" ", ""), IsPublic);
                        }
                        else
                        {
                            if (VLinSpl.Length >= 4)
                            {
                                bool IsPublic = false;
                                if (ThisCheck == "public " || ThisCheck == "internal ") IsPublic = true;

                                AddThisVariable(VLinSpl[3], ThisCheck.Replace(" ", ""), IsPublic);
                            }
                            else
                            {
                                //if (VLinSpl[2] != Path.GetFileName(CurrentFile).Substring(0, Path.GetFileName(CurrentFile).Length - 3)) Console.WriteLine(Path.GetFileName(CurrentFile) + "\t|" + "*" + ThisCheck + "|" + VLinSpl[2]);
                            }
                        }
                    }
                }
                else if (VLinSpl.Length == 2)
                {
                    //if (VLinSpl[1] != Path.GetFileName(CurrentFile).Substring(0, Path.GetFileName(CurrentFile).Length - 3)) Console.WriteLine(Path.GetFileName(CurrentFile) + "\t|" + "***" + ThisCheck + "|" + VLine);
                }
                else
                {
                    //if (VLinSpl[0] != Path.GetFileName(CurrentFile).Substring(0, Path.GetFileName(CurrentFile).Length - 3)) Console.WriteLine(Path.GetFileName(CurrentFile) + "\t|" + "******" + ThisCheck + "|" + VLine);
                }
            }
            else
            {
                //if (VLine != Path.GetFileName(CurrentFile).Substring(0, Path.GetFileName(CurrentFile).Length - 3)) Console.WriteLine(Path.GetFileName(CurrentFile) + "\t|" + "*********" + ThisCheck + "|" + VLine);
            }
        }

        public bool IsCorrectMethod(string ThisM)
        {
            for (int i = 0; i < form1_0.Class_Text_0.NotCryptedText.Count; i++) if (form1_0.Class_Text_0.NotCryptedText[i] == ThisM) return false;
            for (int i = 0; i < form1_0.Class_Text_0.NotCryptedClassList.Count; i++) if (form1_0.Class_Text_0.NotCryptedClassList[i] == ThisM) return false;

            //same method name as the file name
            if (ThisM == Path.GetFileName(form1_0.CurrentFile).Substring(0, Path.GetFileName(form1_0.CurrentFile).Length - 3)) return false;

            return true;
        }

        public bool HadMethod(string ThisM, string ThisS)
        {
            for (int i = 0; i < AllMethods.Count; i++) if (AllMethods[i] == ThisM && AllMethodsSource[i] == ThisS) return true;
            return false;
        }
    }
}
