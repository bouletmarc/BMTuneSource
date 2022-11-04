using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace AppCryptor
{
    public class Class_Crypter
    {
        Form1 form1_0;

        public List<string> AllMethodsPublicAlreadyDone = new List<string>();
        public List<string> AllMethodsPublicAlreadyDoneCrypted = new List<string>();

        public List<string> AllClassSaved = new List<string>();


        public List<string> AllClassRelocation = new List<string>();
        public List<string> AllClassRelocationArray = new List<string>();

        bool InDataFolder = false;
        bool PublicFound = false;

        public Class_Crypter(ref Form1 Form1_1)
        {
            form1_0 = Form1_1;
        }

        public void EncryptThisFile(string ThisssClass, bool InDataFolder1)
        {
            InDataFolder = InDataFolder1;
            PublicFound = false;

            if (AllMethodsPublicAlreadyDone != null) AllMethodsPublicAlreadyDone.Clear();
            AllMethodsPublicAlreadyDone = new List<string>();

            if (AllMethodsPublicAlreadyDoneCrypted != null) AllMethodsPublicAlreadyDoneCrypted.Clear();
            AllMethodsPublicAlreadyDoneCrypted = new List<string>();

            if (AllClassRelocation != null) AllClassRelocation.Clear();
            AllClassRelocation = new List<string>();

            if (AllClassRelocationArray != null) AllClassRelocationArray.Clear();
            AllClassRelocationArray = new List<string>();

            form1_0.ClearLogs();
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Encrypting file " + ThisssClass + "...");

            form1_0.label6.Text = "Doing: " + ThisssClass + " (2/5)";
            form1_0.Refresh();

            string pattern = @"\.cs$";
            var matches = Directory.GetFiles(form1_0.ProjectLocationCrypted, "*", SearchOption.AllDirectories).Where(path => Regex.Match(path, pattern).Success);

            //check in all '*.cs' files
            foreach (string file in matches)
            {
                if (Path.GetFileName(file) == ThisssClass)
                {
                    form1_0.AllCurrentClassLines = File.ReadAllLines(file);
                    form1_0.CurrentFile = file;
                    form1_0.CurrentClassName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 3);

                    //if (form1_0.checkBox1.Checked) form1_0.LogThis("Encrypting " + Path.GetFileName(form1_0.CurrentFile));

                    DoAllThisFile();
                    DoAllPublicAtOnce();
                    //RelocateMethodInFile();
                    if (PublicFound) RedoAllFileForCurrentClassMethod();
                }
            }
        }

        public void DoAllThisFile()
        {
            int currenn = 0;

            for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
            {
                form1_0.progressBar1.Value = (currenn * 100) / form1_0.AllCurrentClassLines.Length;

                for (int i2 = 0; i2 < form1_0.Class_Variables_0.AllMethods.Count; i2++)
                {
                    if (form1_0.Class_Variables_0.AllMethodsSource[i2] == Path.GetFileName(form1_0.CurrentFile) && form1_0.AllCurrentClassLines[i].Contains(form1_0.Class_Variables_0.AllMethods[i2]))
                    {
                        //LogThis("Testing (" + AllMethods[i2] + ") in " + CurrentClassName + ".cs" + " Line:" + (i + 1));

                        string LineStart = form1_0.AllCurrentClassLines[i];
                        form1_0.AllCurrentClassLines[i] = SearchAndReplace(form1_0.AllCurrentClassLines[i], form1_0.Class_Variables_0.AllMethods[i2], form1_0.Class_Variables_0.AllMethodsCrypted[i2], form1_0.Class_Variables_0.AllMethodsPublic[i2]);
                        if (form1_0.checkBox4.Checked) if (LineStart != form1_0.AllCurrentClassLines[i]) form1_0.LogThis("Replaced (" + form1_0.Class_Variables_0.AllMethods[i2] + ") in " + form1_0.CurrentClassName + ".cs" + " Line:" + (i + 1));
                    }
                }

                currenn++;
            }

            form1_0.progressBar1.Value = 0;

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

        public string SearchAndReplace(string ThisLine, string StrFrom, string StrTo, bool IsPublic)
        {
            string StartLine = ThisLine;

            //ThisLine = ThisLine.Replace(StrFrom, StrTo);
            ThisLine = ThisLine.Replace(" " + StrFrom + " ", " " + StrTo + " ");
            ThisLine = ThisLine.Replace(" " + StrFrom + ".", " " + StrTo + ".");
            ThisLine = ThisLine.Replace(" " + StrFrom + "[", " " + StrTo + "[");
            ThisLine = ThisLine.Replace(" " + StrFrom + "]", " " + StrTo + "]");
            ThisLine = ThisLine.Replace(" " + StrFrom + "(", " " + StrTo + "(");
            ThisLine = ThisLine.Replace(" " + StrFrom + ")", " " + StrTo + ")");
            ThisLine = ThisLine.Replace(" " + StrFrom + ";", " " + StrTo + ";");
            ThisLine = ThisLine.Replace(" " + StrFrom + ",", " " + StrTo + ",");
            ThisLine = ThisLine.Replace(" " + StrFrom + "-", " " + StrTo + "-");
            ThisLine = ThisLine.Replace(" " + StrFrom + "+", " " + StrTo + "+");

            ThisLine = ThisLine.Replace("\t" + StrFrom + " ", "\t" + StrTo + " ");
            ThisLine = ThisLine.Replace("\t" + StrFrom + ".", "\t" + StrTo + ".");
            ThisLine = ThisLine.Replace("\t" + StrFrom + "[", "\t" + StrTo + "[");
            ThisLine = ThisLine.Replace("\t" + StrFrom + "]", "\t" + StrTo + "]");
            ThisLine = ThisLine.Replace("\t" + StrFrom + "(", "\t" + StrTo + "(");
            ThisLine = ThisLine.Replace("\t" + StrFrom + ")", "\t" + StrTo + ")");
            ThisLine = ThisLine.Replace("\t" + StrFrom + ";", "\t" + StrTo + ";");
            ThisLine = ThisLine.Replace("\t" + StrFrom + ",", "\t" + StrTo + ",");
            ThisLine = ThisLine.Replace("\t" + StrFrom + "-", "\t" + StrTo + "-");
            ThisLine = ThisLine.Replace("\t" + StrFrom + "+", "\t" + StrTo + "+");

            ThisLine = ThisLine.Replace("this." + StrFrom + " ", "this." + StrTo + " ");
            ThisLine = ThisLine.Replace("this." + StrFrom + ".", "this." + StrTo + ".");
            ThisLine = ThisLine.Replace("this." + StrFrom + "[", "this." + StrTo + "[");
            ThisLine = ThisLine.Replace("this." + StrFrom + "]", "this." + StrTo + "]");
            ThisLine = ThisLine.Replace("this." + StrFrom + "(", "this." + StrTo + "(");
            ThisLine = ThisLine.Replace("this." + StrFrom + ")", "this." + StrTo + ")");
            ThisLine = ThisLine.Replace("this." + StrFrom + ";", "this." + StrTo + ";");
            ThisLine = ThisLine.Replace("this." + StrFrom + ",", "this." + StrTo + ",");
            ThisLine = ThisLine.Replace("this." + StrFrom + "-", "this." + StrTo + "-");
            ThisLine = ThisLine.Replace("this." + StrFrom + "+", "this." + StrTo + "+");

            ThisLine = ThisLine.Replace("(" + StrFrom + " ", "(" + StrTo + " ");
            ThisLine = ThisLine.Replace("(" + StrFrom + ".", "(" + StrTo + ".");
            ThisLine = ThisLine.Replace("(" + StrFrom + "[", "(" + StrTo + "[");
            ThisLine = ThisLine.Replace("(" + StrFrom + "]", "(" + StrTo + "]");
            ThisLine = ThisLine.Replace("(" + StrFrom + "(", "(" + StrTo + "(");
            ThisLine = ThisLine.Replace("(" + StrFrom + ")", "(" + StrTo + ")");
            ThisLine = ThisLine.Replace("(" + StrFrom + ";", "(" + StrTo + ";");
            ThisLine = ThisLine.Replace("(" + StrFrom + ",", "(" + StrTo + ",");
            ThisLine = ThisLine.Replace("(" + StrFrom + "-", "(" + StrTo + "-");
            ThisLine = ThisLine.Replace("(" + StrFrom + "+", "(" + StrTo + "+");

            ThisLine = ThisLine.Replace("!" + StrFrom + " ", "!" + StrTo + " ");
            ThisLine = ThisLine.Replace("!" + StrFrom + ".", "!" + StrTo + ".");
            ThisLine = ThisLine.Replace("!" + StrFrom + "[", "!" + StrTo + "[");
            ThisLine = ThisLine.Replace("!" + StrFrom + "]", "!" + StrTo + "]");
            ThisLine = ThisLine.Replace("!" + StrFrom + "(", "!" + StrTo + "(");
            ThisLine = ThisLine.Replace("!" + StrFrom + ")", "!" + StrTo + ")");
            ThisLine = ThisLine.Replace("!" + StrFrom + ";", "!" + StrTo + ";");
            ThisLine = ThisLine.Replace("!" + StrFrom + ",", "!" + StrTo + ",");
            ThisLine = ThisLine.Replace("!" + StrFrom + "-", "!" + StrTo + "-");
            ThisLine = ThisLine.Replace("!" + StrFrom + "+", "!" + StrTo + "+");

            ThisLine = ThisLine.Replace("{" + StrFrom + " ", "{" + StrTo + " ");
            ThisLine = ThisLine.Replace("{" + StrFrom + ".", "{" + StrTo + ".");
            ThisLine = ThisLine.Replace("{" + StrFrom + "[", "{" + StrTo + "[");
            ThisLine = ThisLine.Replace("{" + StrFrom + "]", "{" + StrTo + "]");
            ThisLine = ThisLine.Replace("{" + StrFrom + "(", "{" + StrTo + "(");
            ThisLine = ThisLine.Replace("{" + StrFrom + ")", "{" + StrTo + ")");
            ThisLine = ThisLine.Replace("{" + StrFrom + ";", "{" + StrTo + ";");
            ThisLine = ThisLine.Replace("{" + StrFrom + ",", "{" + StrTo + ",");
            ThisLine = ThisLine.Replace("{" + StrFrom + "-", "{" + StrTo + "-");
            ThisLine = ThisLine.Replace("{" + StrFrom + "+", "{" + StrTo + "+");

            ThisLine = ThisLine.Replace("[" + StrFrom + " ", "[" + StrTo + " ");
            ThisLine = ThisLine.Replace("[" + StrFrom + ".", "[" + StrTo + ".");
            ThisLine = ThisLine.Replace("[" + StrFrom + "[", "[" + StrTo + "[");
            ThisLine = ThisLine.Replace("[" + StrFrom + "]", "[" + StrTo + "]");
            ThisLine = ThisLine.Replace("[" + StrFrom + "(", "[" + StrTo + "(");
            ThisLine = ThisLine.Replace("[" + StrFrom + ")", "[" + StrTo + ")");
            ThisLine = ThisLine.Replace("[" + StrFrom + ";", "[" + StrTo + ";");
            ThisLine = ThisLine.Replace("[" + StrFrom + ",", "[" + StrTo + ",");
            ThisLine = ThisLine.Replace("[" + StrFrom + "-", "[" + StrTo + "-");
            ThisLine = ThisLine.Replace("[" + StrFrom + "+", "[" + StrTo + "+");

            ThisLine = ThisLine.Replace(")" + StrFrom + " ", ")" + StrTo + " ");
            ThisLine = ThisLine.Replace(")" + StrFrom + ".", ")" + StrTo + ".");
            ThisLine = ThisLine.Replace(")" + StrFrom + "[", ")" + StrTo + "[");
            ThisLine = ThisLine.Replace(")" + StrFrom + "]", ")" + StrTo + "]");
            ThisLine = ThisLine.Replace(")" + StrFrom + "(", ")" + StrTo + "(");
            ThisLine = ThisLine.Replace(")" + StrFrom + ")", ")" + StrTo + ")");
            ThisLine = ThisLine.Replace(")" + StrFrom + ";", ")" + StrTo + ";");
            ThisLine = ThisLine.Replace(")" + StrFrom + ",", ")" + StrTo + ",");
            ThisLine = ThisLine.Replace(")" + StrFrom + "-", ")" + StrTo + "-");
            ThisLine = ThisLine.Replace(")" + StrFrom + "+", ")" + StrTo + "+");

            ThisLine = ThisLine.Replace("-" + StrFrom + " ", "-" + StrTo + " ");
            ThisLine = ThisLine.Replace("-" + StrFrom + ".", "-" + StrTo + ".");
            ThisLine = ThisLine.Replace("-" + StrFrom + "[", "-" + StrTo + "[");
            ThisLine = ThisLine.Replace("-" + StrFrom + "]", "-" + StrTo + "]");
            ThisLine = ThisLine.Replace("-" + StrFrom + "(", "-" + StrTo + "(");
            ThisLine = ThisLine.Replace("-" + StrFrom + ")", "-" + StrTo + ")");
            ThisLine = ThisLine.Replace("-" + StrFrom + ";", "-" + StrTo + ";");
            ThisLine = ThisLine.Replace("-" + StrFrom + ",", "-" + StrTo + ",");
            ThisLine = ThisLine.Replace("-" + StrFrom + "-", "-" + StrTo + "-");
            ThisLine = ThisLine.Replace("-" + StrFrom + "+", "-" + StrTo + "+");

            if (ThisLine == StartLine && InDataFolder && ThisLine.Contains(StrFrom))
            {
                ThisLine = ThisLine.Replace(StrFrom, StrTo);
            }

            //check already done
            bool AllreadyDoneThisOne = false;
            for (int i = 0; i < AllMethodsPublicAlreadyDone.Count; i++) if (AllMethodsPublicAlreadyDone[i] == StrFrom) AllreadyDoneThisOne = true;
            if (AllreadyDoneThisOne) IsPublic = false;

            //the reference is public then change within all files
            if (IsPublic)
            {
                AllMethodsPublicAlreadyDone.Add(StrFrom);
                AllMethodsPublicAlreadyDoneCrypted.Add(StrTo);
            }

            return ThisLine;
        }

        private void DoAllPublicAtOnce()
        {
            form1_0.ClearLogs();
            form1_0.LogThis("----------------------------------------------");
            form1_0.LogThis("Encrypting public variables from " + form1_0.CurrentClassName + ".cs...");

            form1_0.label6.Text = "Doing: " + form1_0.CurrentClassName + ".cs (3/5)";
            form1_0.Refresh();

            int currenn = 0;

            string pattern = @"\.cs$";
            var matches = Directory.GetFiles(form1_0.ProjectLocationCrypted, "*", SearchOption.AllDirectories).Where(path => Regex.Match(path, pattern).Success);

            //check in all '*.cs' files
            foreach (string file in matches)
            {
                form1_0.progressBar1.Value = (currenn * 100) / matches.Count<string>();

                //dont check in class13 since this is where we declare long variable
                if (Path.GetFileName(file) != form1_0.CurrentClassName + ".cs")
                {
                    string[] ClassLines = File.ReadAllLines(file);

                    bool Changed = false;

                    int CurlyCount = 0;
                    int CurlyLine = 0;

                    for (int i = 0; i < ClassLines.Length; i++)
                    {
                        string TestCheck1 = "ImpossibleStringMatch98124";
                        string TestCheck2 = "ImpossibleStringMatch98124";
                        if (form1_0.CurrentClassName.Contains("_"))
                        {
                            TestCheck1 = form1_0.CurrentClassName.Split('_')[0];
                            TestCheck2 = TestCheck1[0].ToString().ToLower() + TestCheck1.Substring(1);
                        }

                        if (ClassLines[i].Contains(form1_0.CurrentClassName)
                            || ClassLines[i].Contains(form1_0.CurrentClassName[0].ToString().ToLower() + form1_0.CurrentClassName.Substring(1))
                            || ClassLines[i].Contains(form1_0.CurrentClassName[0].ToString().ToUpper() + form1_0.CurrentClassName.Substring(1))
                            || ClassLines[i].Contains(TestCheck1)
                            || ClassLines[i].Contains(TestCheck2)
                            || (ClassLines[i].Contains("new " + form1_0.CurrentClassName) && (ClassLines[i].Contains("{") || ClassLines[i + 1].Contains("{")))
                            || CurlyCount > 0)
                        {
                            for (int i2 = 0; i2 < AllMethodsPublicAlreadyDone.Count; i2++)
                            {
                                string StrFrom = AllMethodsPublicAlreadyDone[i2];
                                string StrTo = AllMethodsPublicAlreadyDoneCrypted[i2];

                                string LineStart = ClassLines[i];

                                //exemple (this is doing array): new class { xval1, xval2, xval3, ... }
                                if (ClassLines[i].Contains("new " + form1_0.CurrentClassName) && (ClassLines[i].Contains("{") || ClassLines[i + 1].Contains("{")))
                                {
                                    CurlyCount = 1;
                                    CurlyLine = i;
                                    if (!ClassLines[i].Contains("{") && ClassLines[i + 1].Contains("{")) CurlyLine++;
                                }

                                if (CurlyCount > 0)
                                {
                                    //Console.WriteLine("searching in:" + Path.GetFileName(file) + " Line:" + (i + 1));

                                    if (ClassLines[i].Contains(StrFrom))
                                    {
                                        ClassLines[i] = ClassLines[i].Replace(" " + StrFrom + " ", " " + StrTo + " ");
                                        ClassLines[i] = ClassLines[i].Replace("\t" + StrFrom + " ", "\t" + StrTo + " ");

                                        ClassLines[i] = ClassLines[i].Replace(" " + StrFrom + ";", " " + StrTo + ";");
                                        ClassLines[i] = ClassLines[i].Replace("\t" + StrFrom + ";", "\t" + StrTo + ";");

                                        ClassLines[i] = ClassLines[i].Replace(" " + StrFrom + ",", " " + StrTo + ",");
                                        ClassLines[i] = ClassLines[i].Replace("\t" + StrFrom + ",", "\t" + StrTo + ",");

                                        ClassLines[i] = ClassLines[i].Replace("." + StrFrom + ";", "." + StrTo + ";");
                                        ClassLines[i] = ClassLines[i].Replace("." + StrFrom + ";", "." + StrTo + ";");

                                        ClassLines[i] = ClassLines[i].Replace("." + StrFrom + ",", "." + StrTo + ",");
                                        ClassLines[i] = ClassLines[i].Replace("." + StrFrom + ",", "." + StrTo + ",");

                                        ClassLines[i] = ClassLines[i].Replace("." + StrFrom + " ", "." + StrTo + " ");
                                        ClassLines[i] = ClassLines[i].Replace("." + StrFrom + " ", "." + StrTo + " ");

                                        //aray (exemple class20_0[i].Int1)
                                        /*if ((ClassLines[i].Contains(CurrentClassName + "_0[") && ClassLines[i].Contains("]." + StrFrom))
                                            || (ClassLines[i].Contains(CurrentClassName + "_1[") && ClassLines[i].Contains("]." + StrFrom)))
                                        {
                                            ClassLines[i] = ClassLines[i].Replace("]." + StrFrom, "]." + StrTo);
                                        }*/
                                    }

                                    if (i != CurlyLine && CurlyCount > 0 && ClassLines[i].Contains("{")) CurlyCount++;
                                    if (CurlyCount > 0 && ClassLines[i].Contains("}")) CurlyCount--;
                                }

                                string bufCName = form1_0.CurrentClassName;
                                ClassLines[i] = ReplaceThisLine(ClassLines[i], StrFrom, StrTo);
                                form1_0.CurrentClassName = form1_0.CurrentClassName[0].ToString().ToLower() + form1_0.CurrentClassName.Substring(1);
                                ClassLines[i] = ReplaceThisLine(ClassLines[i], StrFrom, StrTo);
                                form1_0.CurrentClassName = form1_0.CurrentClassName[0].ToString().ToUpper() + form1_0.CurrentClassName.Substring(1);
                                ClassLines[i] = ReplaceThisLine(ClassLines[i], StrFrom, StrTo);

                                if (form1_0.CurrentClassName.Contains("_"))
                                {
                                    string[] splitttt = form1_0.CurrentClassName.Split('_');
                                    form1_0.CurrentClassName = splitttt[0];
                                    ClassLines[i] = ReplaceThisLine(ClassLines[i], StrFrom, StrTo);
                                    form1_0.CurrentClassName = form1_0.CurrentClassName[0].ToString().ToLower() + form1_0.CurrentClassName.Substring(1);
                                    ClassLines[i] = ReplaceThisLine(ClassLines[i], StrFrom, StrTo);
                                }

                                if (LineStart != ClassLines[i])
                                {
                                    Changed = true;
                                    if (form1_0.checkBox4.Checked) form1_0.LogThis("Replaced (" + StrFrom + ") in " + Path.GetFileName(file) + " Line:" + (i + 1));
                                }

                                form1_0.CurrentClassName = bufCName;
                            }
                        }
                    }

                    if (Changed)
                    {
                        PublicFound = true;

                        bool IsSaved = false;
                        while (!IsSaved)
                        {
                            try
                            {
                                File.Create(file).Dispose();
                                File.WriteAllLines(file, ClassLines);
                                IsSaved = true;
                            }
                            catch
                            {
                                form1_0.LogThis("CANT SAVE " + Path.GetFileName(file));
                                Thread.Sleep(500);
                            }
                        }

                        bool AlreadySaved = false;
                        for (int i = 0; i < AllClassSaved.Count; i++) if (Path.GetFileName(file) == AllClassSaved[i]) AlreadySaved = true;

                        if (!AlreadySaved) AllClassSaved.Add(Path.GetFileName(file));
                    }
                }

                currenn++;
            }

            form1_0.progressBar1.Value = 0;
        }


        private string ReplaceThisLine(string ClassLines, string StrFrom, string StrTo)
        {
            if (StrFrom.Contains("Delegate") || StrFrom.Contains("delegate"))
            {
                ClassLines = testreplace(ClassLines, form1_0.CurrentClassName + "." + StrFrom, form1_0.CurrentClassName + "." + StrTo);
            }
            else
            {
                ClassLines = testreplace(ClassLines, form1_0.CurrentClassName + "_0." + StrFrom, form1_0.CurrentClassName + "_0." + StrTo);
                ClassLines = testreplace(ClassLines, form1_0.CurrentClassName + "_1." + StrFrom, form1_0.CurrentClassName + "_1." + StrTo);
                ClassLines = testreplace(ClassLines, form1_0.CurrentClassName + "_2." + StrFrom, form1_0.CurrentClassName + "_2." + StrTo);

                if (InDataFolder) ClassLines = testreplace(ClassLines, form1_0.CurrentClassName + "." + StrFrom, form1_0.CurrentClassName + "." + StrTo);

                //class7_u_0[i, j].method_10(
                //aray (exemple class20_0[i].Int1)
                if ((ClassLines.Contains(form1_0.CurrentClassName + "_0[") && ClassLines.Contains("]." + StrFrom))
                    || (ClassLines.Contains(form1_0.CurrentClassName + "_1[") && ClassLines.Contains("]." + StrFrom))
                    || (ClassLines.Contains(form1_0.CurrentClassName + "_2[") && ClassLines.Contains("]." + StrFrom)))
                {
                    if (IsCorrectAfter(ClassLines.Substring(ClassLines.LastIndexOf("]." + StrFrom) + ("]." + StrFrom).Length)))
                    {
                        string bufTest = ClassLines;

                        ClassLines = testreplace(ClassLines, "]." + StrFrom, "]." + StrTo);
                        if (ClassLines == bufTest) ClassLines = ClassLines.Replace("]." + StrFrom, "]." + StrTo);
                    }
                }

                //stack
                if (ClassLines.Contains(form1_0.CurrentClassName + "_0.Peek()." + StrFrom)
                    || ClassLines.Contains(form1_0.CurrentClassName + "_1.Peek()." + StrFrom)
                    || ClassLines.Contains(form1_0.CurrentClassName + "_2.Peek()." + StrFrom))
                {
                    ClassLines = testreplace(ClassLines, ")." + StrFrom, ")." + StrTo);
                }
            }

            return ClassLines;
        }

        private void RelocateMethodInFile()
        {
            int currenn = 0;

            string[] RemadeLines = new string[form1_0.AllCurrentClassLines.Length];

            int CurrentLine = 0;
            int CurlyCount = 0;
            bool HasFoundClassName = false;

            for (int i = 0; i < form1_0.AllCurrentClassLines.Length; i++)
            {
                form1_0.progressBar1.Value = (currenn * 100) / form1_0.AllCurrentClassLines.Length;

                if (!HasFoundClassName)
                {
                    if (form1_0.AllCurrentClassLines[i] != string.Empty)
                    {
                        RemadeLines[CurrentLine] = form1_0.AllCurrentClassLines[i];
                        CurrentLine++;

                        if (form1_0.AllCurrentClassLines[i].Contains("{"))
                        {
                            CurlyCount++;
                            HasFoundClassName = true;
                        }
                    }
                }
                else
                {
                    //if (form1_0.AllCurrentClassLines[i].Contains("{")) CurlyCount++;

                    if (form1_0.AllCurrentClassLines[i].Contains("public ")
                        || form1_0.AllCurrentClassLines[i].Contains("private ")
                        || form1_0.AllCurrentClassLines[i].Contains("internal ")
                        || form1_0.AllCurrentClassLines[i].Contains("void ")
                        || form1_0.AllCurrentClassLines[i].Contains("string ")
                        || form1_0.AllCurrentClassLines[i].Contains("byte ")
                        || form1_0.AllCurrentClassLines[i].Contains("bool ")
                        || form1_0.AllCurrentClassLines[i].Contains("double ")
                        || form1_0.AllCurrentClassLines[i].Contains("int ")
                        || form1_0.AllCurrentClassLines[i].Contains("long ")
                        || form1_0.AllCurrentClassLines[i].Contains("long ")
                        || form1_0.AllCurrentClassLines[i].Contains("DateTime "))
                    {
                        if (form1_0.AllCurrentClassLines[i].Contains("{") || form1_0.AllCurrentClassLines[i + 1].Contains("{"))
                        {
                            if (form1_0.AllCurrentClassLines[i].Contains("{"))
                            {
                                //Console.WriteLine("add:" + form1_0.AllCurrentClassLines[i]);
                                AllClassRelocationArray.Add(form1_0.AllCurrentClassLines[i] + "­~");
                                CurlyCount++;
                                i++;
                            }
                            else if (form1_0.AllCurrentClassLines[i + 1].Contains("{"))
                            {
                                //Console.WriteLine("add:" + form1_0.AllCurrentClassLines[i]);
                                //Console.WriteLine("add:" + form1_0.AllCurrentClassLines[i + 1]);
                                AllClassRelocationArray.Add(form1_0.AllCurrentClassLines[i] + "­~");
                                AllClassRelocationArray.Add(form1_0.AllCurrentClassLines[i + 1] + "­~");
                                CurlyCount++;
                                i++;
                                i++;
                            }

                            int StartCount = CurlyCount;
                            while (CurlyCount >= StartCount)
                            {
                                if (form1_0.AllCurrentClassLines[i] != string.Empty)
                                {
                                    //Console.WriteLine("add:" + form1_0.AllCurrentClassLines[i]);
                                    AllClassRelocationArray.Add(form1_0.AllCurrentClassLines[i] + "­~");
                                }

                                if (form1_0.AllCurrentClassLines[i].Contains("{")) CurlyCount++;
                                if (form1_0.AllCurrentClassLines[i].Contains("}")) CurlyCount--;
                                i++;
                            }
                            //Console.WriteLine("add:" + form1_0.AllCurrentClassLines[i]);
                            //Console.WriteLine("------------------------------------------------------");
                            //AllClassRelocationArray.Add(form1_0.AllCurrentClassLines[i]);
                        }
                        else
                        {
                            //Console.WriteLine("add:" + form1_0.AllCurrentClassLines[i]);
                            AllClassRelocation.Add(form1_0.AllCurrentClassLines[i]);
                        }

                    }
                    else
                    {
                        if (form1_0.AllCurrentClassLines[i] != string.Empty)
                        {
                            RemadeLines[CurrentLine] = form1_0.AllCurrentClassLines[i];
                            CurrentLine++;
                        }
                    }

                    if (CurlyCount > 0 && form1_0.AllCurrentClassLines[i].Contains("}"))
                    {
                        CurlyCount--;

                        if (CurlyCount == 0)
                        {
                            //CurrentLine--;
                            string LastLine = RemadeLines[CurrentLine];

                            Console.WriteLine(LastLine);

                            for (int i2 = 0; i2 < AllClassRelocation.Count; i2++)
                            {
                                RemadeLines[CurrentLine] = AllClassRelocation[i2];
                                //Console.WriteLine("test1:" + AllClassRelocation[i2]);
                                CurrentLine++;
                            }
                            for (int i2 = 0; i2 < AllClassRelocationArray.Count; i2++)
                            {
                                string[] SplitArray = AllClassRelocationArray[i2].Split('~');

                                for (int i3 = 0; i3 < SplitArray.Length; i3++)
                                {
                                    if (SplitArray[i3] != string.Empty)
                                    {
                                        RemadeLines[CurrentLine] = SplitArray[i3];
                                        Console.WriteLine("test1:" + SplitArray[i3]);
                                        CurrentLine++;
                                    }
                                }
                            }

                            RemadeLines[CurrentLine] = LastLine;
                            CurrentLine++;
                        }
                    }
                }

                currenn++;
            }

            string[] Remade2 = new string[RemadeLines.Length];
            for (int i = 0; i < RemadeLines.Length; i++) Remade2[i] = RemadeLines[i];

            form1_0.progressBar1.Value = 0;

            if (InDataFolder)
            {
                File.Create(form1_0.ProjectLocationCrypted + @"\Data\" + form1_0.CurrentClassName + ".cs").Dispose();
                File.WriteAllLines(form1_0.ProjectLocationCrypted + @"\Data\" + form1_0.CurrentClassName + ".cs", Remade2);
            }
            else
            {
                File.Create(form1_0.ProjectLocationCrypted + @"\" + form1_0.CurrentClassName + ".cs").Dispose();
                File.WriteAllLines(form1_0.ProjectLocationCrypted + @"\" + form1_0.CurrentClassName + ".cs", Remade2);
            }
        }

        private bool IsCorrectAfter(string ClassLines)
        {
            bool Correct = true;

            if (ClassLines.Length > 0)
            {
                //Console.WriteLine(ClassLines);
                if (ClassLines[0] == '0') Correct = false;
                if (ClassLines[0] == '1') Correct = false;
                if (ClassLines[0] == '2') Correct = false;
                if (ClassLines[0] == '3') Correct = false;
                if (ClassLines[0] == '4') Correct = false;
                if (ClassLines[0] == '5') Correct = false;
                if (ClassLines[0] == '6') Correct = false;
                if (ClassLines[0] == '7') Correct = false;
                if (ClassLines[0] == '8') Correct = false;
                if (ClassLines[0] == '9') Correct = false;
                if (ClassLines[0] == '_') Correct = false;
            }
            //else Correct = false;

            return Correct;
        }

        private string testreplace(string ClassLines, string StrFrom, string StrTo)
        {
            ClassLines = ClassLines.Replace(StrFrom + " ", StrTo + " ");
            ClassLines = ClassLines.Replace(StrFrom + ".", StrTo + ".");
            ClassLines = ClassLines.Replace(StrFrom + "[", StrTo + "[");
            ClassLines = ClassLines.Replace(StrFrom + "]", StrTo + "]");
            ClassLines = ClassLines.Replace(StrFrom + "(", StrTo + "(");
            ClassLines = ClassLines.Replace(StrFrom + ")", StrTo + ")");
            ClassLines = ClassLines.Replace(StrFrom + ";", StrTo + ";");
            ClassLines = ClassLines.Replace(StrFrom + ",", StrTo + ",");
            ClassLines = ClassLines.Replace(StrFrom + "{", StrTo + "{");
            ClassLines = ClassLines.Replace(StrFrom + "}", StrTo + "}");
            ClassLines = ClassLines.Replace(StrFrom + "!", StrTo + "!");
            ClassLines = ClassLines.Replace(StrFrom + ":", StrTo + ":");

            return ClassLines;
        }

        public void RedoAllFileForCurrentClassMethod()
        {
            //form1_0.ClearLogs();
            //form1_0.LogThis("----------------------------------------------");
            //form1_0.LogThis("Encrypting Filename variables from " + form1_0.CurrentClassName + ".cs...");

            int currenn = 0;
            bool Changed = false;

            form1_0.label6.Text = "Doing: " + form1_0.CurrentClassName + ".cs (4/5)";
            form1_0.Refresh();

            string pattern = @"\.cs$";
            var matches = Directory.GetFiles(form1_0.ProjectLocationCrypted, "*", SearchOption.AllDirectories).Where(path => Regex.Match(path, pattern).Success);

            //check in all '*.cs' files
            foreach (string file in matches)
            {
                form1_0.progressBar1.Value = (currenn * 100) / matches.Count<string>();

                string[] ClassLines = File.ReadAllLines(file);

                string TestCheck1 = "ImpossibleStringMatch98124";
                string TestCheck2 = "ImpossibleStringMatch98124";
                if (form1_0.CurrentClassName.Contains("_"))
                {
                    TestCheck1 = form1_0.CurrentClassName.Split('_')[0];
                    TestCheck2 = TestCheck1[0].ToString().ToLower() + TestCheck1.Substring(1);
                }

                for (int i = 0; i < ClassLines.Length; i++)
                {
                    string LineStart = ClassLines[i];

                    if (ClassLines[i].Contains(form1_0.CurrentClassName)
                        || ClassLines[i].Contains(form1_0.CurrentClassName[0].ToString().ToLower() + form1_0.CurrentClassName.Substring(1))
                        || ClassLines[i].Contains(form1_0.CurrentClassName[0].ToString().ToUpper() + form1_0.CurrentClassName.Substring(1))
                        || ClassLines[i].Contains(TestCheck1)
                        || ClassLines[i].Contains(TestCheck2))
                    {
                        for (int i2 = 0; i2 < form1_0.Class_Text_0.NotCryptedClassList.Count; i2++)
                        {
                            if (form1_0.Class_Text_0.NotCryptedClassList[i2].Contains(form1_0.CurrentClassName)
                                || form1_0.Class_Text_0.NotCryptedClassList[i2].Contains(form1_0.CurrentClassName[0].ToString().ToLower() + form1_0.CurrentClassName.Substring(1))
                                || form1_0.Class_Text_0.NotCryptedClassList[i2].Contains(form1_0.CurrentClassName[0].ToString().ToUpper() + form1_0.CurrentClassName.Substring(1)))
                            {
                                ClassLines[i] = ClassLines[i].Replace(form1_0.Class_Text_0.NotCryptedClassList[i2], form1_0.Class_Text_0.NotCryptedClassListCrypted[i2]);

                                if (LineStart != ClassLines[i])
                                {
                                    Changed = true;
                                    if (form1_0.checkBox4.Checked) form1_0.LogThis("Replaced (" + form1_0.Class_Text_0.NotCryptedClassList[i2] + ") in " + Path.GetFileName(file) + " Line:" + (i + 1));
                                }
                            }
                        }
                    }
                }

                if (Changed)
                {
                    bool IsSaved = false;
                    while (!IsSaved)
                    {
                        try
                        {
                            File.Create(file).Dispose();
                            File.WriteAllLines(file, ClassLines);
                            IsSaved = true;
                        }
                        catch
                        {
                            form1_0.LogThis("CANT SAVE " + Path.GetFileName(file));
                            Thread.Sleep(500);
                        }
                    }
                }

                currenn++;
            }

            form1_0.progressBar1.Value = 0;
        }


    }
}
