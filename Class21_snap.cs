using Dal;
using Data;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

internal class Class21_snap
{
    private Class18 class18_0;
    private QuickSaveListObjects quickSaveListObjects_0 = new QuickSaveListObjects();
    private string string_0;

    public event Delegate63 delegate63_0;

    internal void method_0(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_1);
    }

    private void method_1()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            if (!string.IsNullOrEmpty(this.class18_0.method_27()))
            {
                this.string_0 = this.class18_0.method_27() + @"\snapshots\";
            }
            this.method_8();
            this.quickSaveListObjects_0.QuickSaveItem_0.Clear();
            this.method_7();
        }
    }

    public void method_2()
    {
        if (!this.class18_0.method_47() && !this.class18_0.method_48())
        {
            this.class18_0.method_155("Save Snapshot");
            string str = string.Empty;
            frmQuickSaveDesc desc = new frmQuickSaveDesc();
            desc.ShowDialog();
            if (desc.Tag == null)
            {
                desc.Dispose();
                desc = null;
            }
            else
            {
                str = desc.Tag.ToString();
                QuickSaveItem QuickSaveItem_1 = new QuickSaveItem {
                    description = str,
                    time = DateTime.Now,
                    filename = "snp" + this.quickSaveListObjects_0.QuickSaveItem_0.Count.ToString() + ".bin"
                    //filename = "snp" + this.quickSaveListObjects_0.quickSaveList.Count.ToString() + ".bml"
                };
                //this.class18_0.method_73(this.string_0 + item.filename); //save calibration .bml

                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(this.string_0 + QuickSaveItem_1.filename))) Directory.CreateDirectory(Path.GetDirectoryName(this.string_0 + QuickSaveItem_1.filename));
                    File.Create(this.string_0 + QuickSaveItem_1.filename).Dispose();
                    File.WriteAllBytes(this.string_0 + QuickSaveItem_1.filename, this.class18_0.GetAllByte());
                }
                catch (Exception exception)
                {
                    MessageBox.Show(Form.ActiveForm, exception.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

                this.quickSaveListObjects_0.QuickSaveItem_0.Add(QuickSaveItem_1);
                if (this.delegate63_0 != null)
                {
                    this.delegate63_0();
                }
            }
        }
    }

    public void method_3()
    {
        this.class18_0.method_155("Clear Snapshots");
        this.quickSaveListObjects_0.QuickSaveItem_0.Clear();
        FileInfo info = new FileInfo(this.string_0);
        if (info.Directory.Exists)
        {
            foreach (FileInfo info2 in info.Directory.GetFiles())
            {
                info2.Delete();
            }
        }
        DirectoryInfo info3 = new DirectoryInfo(this.string_0);
        if (info3.Exists)
        {
            info3.Delete();
        }
        info3 = null;
        if (this.delegate63_0 != null)
        {
            this.delegate63_0();
        }
    }

    public Collection<QuickSaveItem> method_5()
    {
        return this.quickSaveListObjects_0.QuickSaveItem_0;
    }

    public void method_6(int int_1)
    {
        this.class18_0.method_155("Load Snapshot");
        this.class18_0.method_75(this.string_0 + this.quickSaveListObjects_0.QuickSaveItem_0[int_1].filename, false, 1);
        this.class18_0.method_65();
    }

    internal void method_7()
    {
        string fileName = this.string_0 + @"\snplist.pref";
        //IFormatter formatter = new BinaryFormatter();
        //Stream serializationStream = null;
        FileInfo info = new FileInfo(fileName);
        if (!info.Exists)
        {
            this.quickSaveListObjects_0 = new QuickSaveListObjects();
        }
        else
        {
            try
            {
                this.quickSaveListObjects_0 = new QuickSaveListObjects();

                string[] AllLines = File.ReadAllLines(fileName);
                if (AllLines.Length > 0)
                {
                    for (int i = 0; i < AllLines.Length; i++)
                    {
                        if (AllLines[i].Contains("List"))
                        {
                            QuickSaveItem QuickSaveItem_0 = new QuickSaveItem();

                            string[] SplitCMD = AllLines[i].Split(',');
                            string[] SplitIndexEnc = SplitCMD[0].Split('=');
                            string[] SplitCmdEnc = SplitCMD[1].Split('=');

                            string[] SplitCMDDesc = AllLines[i + 1].Split(',');
                            string[] SplitCmdDescEnc = SplitCMDDesc[1].Split('=');

                            string[] SplitCMDTime = AllLines[i + 2].Split(',');
                            string[] SplitCmdTimeEnc = SplitCMDTime[1].Split('=');

                            if (SplitCmdEnc[0].Contains("filename")) QuickSaveItem_0.filename = SplitCmdEnc[1];
                            if (SplitCmdDescEnc[0].Contains("description")) QuickSaveItem_0.description = SplitCmdDescEnc[1];
                            try
                            {
                                if (SplitCmdTimeEnc[0].Contains("time")) QuickSaveItem_0.time = DateTime.ParseExact(SplitCmdTimeEnc[1], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            }
                            catch { }

                            this.quickSaveListObjects_0.QuickSaveItem_0.Add(QuickSaveItem_0);
                            i += 2;
                        }
                    }
                }


                //################
                //serializationStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                //this.quickSaveListObjects_0 = (QuickSaveListObjects) formatter.Deserialize(serializationStream);
            }
            catch (Exception)
            {
                this.quickSaveListObjects_0 = new QuickSaveListObjects();
                //method_8();
            }
            /*if (serializationStream != null)
            {
                serializationStream.Close();
                serializationStream.Dispose();
                serializationStream = null;
            }
            formatter = null;*/
            info = null;
            if (this.delegate63_0 != null) this.delegate63_0();
        }
    }

    public void method_8()
    {
        string fileName = this.string_0 + @"\snplist.pref";
        FileInfo info = new FileInfo(fileName);
        if (info.Exists)
        {
            info.Delete();
        }
        if (this.quickSaveListObjects_0.QuickSaveItem_0.Count != 0)
        {
            string SaveStr = "";
            for (int i = 0; i < this.quickSaveListObjects_0.QuickSaveItem_0.Count; i++)
            {
                SaveStr += "List=" + i + ",filename=" + this.quickSaveListObjects_0.QuickSaveItem_0[i].filename + Environment.NewLine;
                SaveStr += "List=" + i + ",description=" + this.quickSaveListObjects_0.QuickSaveItem_0[i].description + Environment.NewLine;
                SaveStr += "List=" + i + ",time=" + this.quickSaveListObjects_0.QuickSaveItem_0[i].time.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) + Environment.NewLine;
            }

            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(SaveStr);
            writer.Close();
            writer.Dispose();
            writer = null;

            //####################
            /*IFormatter formatter = new BinaryFormatter();
            Stream serializationStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(serializationStream, this.quickSaveListObjects_0);
            serializationStream.Close();
            serializationStream.Dispose();
            formatter = null;*/
            info = null;
            this.quickSaveListObjects_0.QuickSaveItem_0.Clear();
            if (this.delegate63_0 != null) this.delegate63_0();
        }
    }

    public delegate void Delegate63();
}

