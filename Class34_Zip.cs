using Data;
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;

internal class Class34_Zip
{
    string _baseromPath = Environment.GetEnvironmentVariable("TEMP");
    string _zipPath = "";
    int CurrentFileIndex = 0;
    private Class10_settings Class10_0;
    bool CanLoadC10 = false;
    frmUnZIP frmUnZIP_0;

    public Class34_Zip()
    {

    }

    public void AddClass10(ref Class10_settings Class10_1)
    {
        Class10_0 = Class10_1;
        CanLoadC10 = true;
    }

    public void ExtractZip()
    {
        /*while (File.Exists(_zipPath))
        {
            CurrentFileIndex++;
            SetZipPath();
        }*/

        try
        {
            SetZipPath();
            int Chechh = GetPackgeChecksum();
            if (!CanLoadC10 || (CanLoadC10 && Chechh != this.Class10_0.LastPackageChecksum))
            {
                if (!File.Exists(_zipPath)) File.Create(_zipPath).Dispose();
                File.WriteAllBytes(_zipPath, Properties.Resources.Packages);
                if (CanLoadC10) this.Class10_0.LastPackageChecksum = Chechh;
            }
            //UnZip(_baseromPath);
        }
        catch
        {
            this.Class10_0.frmMain_0.LogThis("Unzipper - Unable to Overwrite Package.zip:");
        }
    }

    private int GetPackgeChecksum()
    {
        int ReturnSum = -1;
        if (File.Exists(_zipPath))
        {
            byte[] AllBytes = File.ReadAllBytes(_zipPath);

            for (int i = 0; i < AllBytes.Length; i++)
            {
                ReturnSum += AllBytes[i];
                if (ReturnSum > 65535) ReturnSum -= 65535;
            }
        }
        return ReturnSum;
    }

    void SetZipPath()
    {
        _zipPath = Environment.GetEnvironmentVariable("TEMP") + @"\Packages" + CurrentFileIndex + ".zip";
    }

    public void RemoveZip()
    {
        try
        {
            while (File.Exists(_zipPath))
            {
                File.Delete(_zipPath);
                if (CurrentFileIndex > 0) CurrentFileIndex--;
                SetZipPath();
            }
        }
        catch { }
    }

    public Shell32.Folder GetShell32NameSpaceFolder(Object folder)
    {
        Type shellAppType = Type.GetTypeFromProgID("Shell.Application");

        Object shell = Activator.CreateInstance(shellAppType);
        return (Shell32.Folder)shellAppType.InvokeMember("NameSpace",
        System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folder });
    }

    public void UnZipFile(string folderPath)
    {
        try
        {
            if (!File.Exists(_zipPath))
            {
                throw new FileNotFoundException();
            }
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(folderPath);
            Shell32.Folder sourceFile = GetShell32NameSpaceFolder(_zipPath);

            foreach (var file in sourceFile.Items())
            {
                destinationFolder.CopyHere(file, 4 | 16);
            }
        }
        catch { }
    }

    public void UnZipFile(string folderPath, string Filename)
    {
        try
        {
            if (!File.Exists(_zipPath))
            {
                throw new FileNotFoundException();
            }
            if (!Directory.Exists(folderPath + @"\" + Filename)) Directory.CreateDirectory(folderPath + @"\" + Filename);

            if (CanLoadC10) 
            {
                frmUnZIP_0 = new frmUnZIP();
                frmUnZIP_0.Show();
                frmUnZIP_0.TopMost = true;
            }

            Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(folderPath);
            Shell32.Folder sourceFile = GetShell32NameSpaceFolder(_zipPath);

            bool FoundFile = false;
            int MaxItems = sourceFile.Items().Count;
            int CurrentIndex = 0;

            foreach (Shell32.FolderItem file in sourceFile.Items())
            {
                int Percent = (int) (((double) CurrentIndex * 100.0) / (double) MaxItems);
                if (CanLoadC10) frmUnZIP_0.SetPercent(Percent);
                if (file.Name != null)
                {
                    if (file.Name != string.Empty && Filename != string.Empty)
                    {
                        if (file.Name == Filename)
                        {
                            destinationFolder.CopyHere(file, 4 | 16);
                            FoundFile = true;
                        }
                    }
                }

                CurrentIndex++;
            }

            if (!FoundFile) throw new FileNotFoundException();
        }
        catch { }

        if (CanLoadC10)
        {
            if (frmUnZIP_0 != null)
            {
                frmUnZIP_0.Dispose();
                frmUnZIP_0 = null;
            }
        }
    }

    public byte[] UnZipSilent(string FilenameInZIP, string FnameExtracted)
    {
        byte[] ReturningByte = new byte[] { };
        string BufFilePath = Application.StartupPath + @"\" + FilenameInZIP + @"\" + FnameExtracted;

        //Unzip First if file do no exist
        if (!File.Exists(BufFilePath)) UnZipFile(Application.StartupPath, FilenameInZIP);

        //Get Datas
        if (File.Exists(BufFilePath))
        {
            ReturningByte = File.ReadAllBytes(BufFilePath);
        }
        else
        {
            Console.WriteLine("NOT loaded:" + FnameExtracted);
            throw new FileNotFoundException();
        }

        return ReturningByte;
    }

    public void ZipFile(string ThisFile, string NameInZIP)
    {
        try
        {
            if (!File.Exists(ThisFile))
            {
                throw new FileNotFoundException();
            }

            //Create Empty folder that only have the specific file in it
            string Zippingfolder = Application.StartupPath + @"\ZippingFolder";
            if (!Directory.Exists(Zippingfolder)) Directory.CreateDirectory(Zippingfolder);

            //Copy File to Empty Zipping Folder
            File.Create(Zippingfolder + @"\" + NameInZIP).Dispose();
            File.WriteAllBytes(Zippingfolder + @"\" + NameInZIP, File.ReadAllBytes(ThisFile));

            // Create empty archive
            if (!File.Exists(_zipPath))
            {
                //File.Create(_zipPath).Dispose();
                byte[] emptyArchiveContent = new byte[] { 80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                FileStream fs = File.Create(_zipPath);
                fs.Write(emptyArchiveContent, 0, emptyArchiveContent.Length);
                fs.Flush();
                fs.Close();
                fs = null;
            }

            Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(Zippingfolder);
            Shell32.Folder sourceFile = GetShell32NameSpaceFolder(_zipPath);
            sourceFile.CopyHere(destinationFolder.Items(), 4 | 16);

            int Tries = 0;
            bool FileIsZipped = false;
            while (!FileIsZipped && Tries < (10 * 15))
            {
                foreach (Shell32.FolderItem file in sourceFile.Items())
                {
                    if (file.Name == NameInZIP) FileIsZipped = true;
                }
                Thread.Sleep(100);
                Tries++;
            }

            if (Directory.Exists(Zippingfolder)) Directory.Delete(Zippingfolder, true);
        }
        catch (Exception mess)
        {
            MessageBox.Show("ERROR: Could not ZIP File: " + Environment.NewLine + mess);
        }
    }

    public void UnZipFileFromThisZIP(string ThisFile, string ThisZIP)
    {
        try
        {
            if (!File.Exists(ThisZIP))
            {
                throw new FileNotFoundException();
            }
            Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(Application.StartupPath);
            Shell32.Folder sourceFile = GetShell32NameSpaceFolder(ThisZIP);

            foreach (Shell32.FolderItem file in sourceFile.Items())
            {
                if (file.Name == ThisFile) destinationFolder.CopyHere(file, 4 | 16);
            }
        }
        catch (Exception mess)
        {
            MessageBox.Show("ERROR: Could not UNZIP File: " + Environment.NewLine + mess);
        }
    }

    public string[] GetXDFInternalList()
    {
        string[] AllXDFFiles = new string[] { };

        try
        {
            if (!File.Exists(_zipPath)) throw new FileNotFoundException();

            Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(Application.StartupPath);
            Shell32.Folder sourceFile = GetShell32NameSpaceFolder(_zipPath);
            foreach (Shell32.FolderItem file in sourceFile.Items())
            {
                if (file.Name == "XDF_Files")
                {
                    destinationFolder.CopyHere(file, 4 | 16);
                }
            }

            if (Directory.Exists(Application.StartupPath + @"\XDF_Files"))
            {
                AllXDFFiles = Directory.GetFiles(Application.StartupPath + @"\XDF_Files", "*.*", SearchOption.AllDirectories);
                Directory.Delete(Application.StartupPath + @"\XDF_Files", true);
            }
        }
        catch (Exception mess)
        {
            MessageBox.Show("ERROR: Could not get XDF files list: " + Environment.NewLine + mess);
        }

        return AllXDFFiles;
    }

    public string[] GetBINInternalList()
    {
        string[] AllXDFFiles = new string[] { };

        try
        {
            if (!File.Exists(_zipPath)) throw new FileNotFoundException();

            Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(Application.StartupPath);
            Shell32.Folder sourceFile = GetShell32NameSpaceFolder(_zipPath);
            foreach (Shell32.FolderItem file in sourceFile.Items())
            {
                if (file.Name == "VW_BIN_Files")
                {
                    destinationFolder.CopyHere(file, 4 | 16);
                }
            }

            if (Directory.Exists(Application.StartupPath + @"\VW_BIN_Files"))
            {
                AllXDFFiles = Directory.GetFiles(Application.StartupPath + @"\VW_BIN_Files", "*.*", SearchOption.AllDirectories);
                Directory.Delete(Application.StartupPath + @"\VW_BIN_Files", true);
            }
        }
        catch (Exception mess)
        {
            MessageBox.Show("ERROR: Could not get BIN files list: " + Environment.NewLine + mess);
        }

        return AllXDFFiles;
    }
}

