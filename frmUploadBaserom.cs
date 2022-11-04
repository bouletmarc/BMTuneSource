using Data;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;

internal class frmUploadBaserom : Form
{
    private Label label1;
    public ProgressBar progressBar1;
    private IContainer icontainer_0;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label3;
    private TextBox textBox3;
    private Label label4;
    private Label label6;
    private Panel panel1;
    private Panel panel3;
    private Button button1;
    private TextBox textBox6;
    private Label label5;
    private ComboBox comboBox2;
    private OpenFileDialog openFileDialog1;
    private Class18 class18_0;
    private string ErrorString = "";
    private byte[] FileBytes = new byte[] { };
    private string FilePath = "";
    private string NewPath = "";
    private string string_11_2 = "https://raw.githubusercontent.com/bouletmarc/BMTune_Server/master/";
    private string IPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\";
    private Label label7;
    private string FTPSite = "ftp://files.000webhost.com/All/bins/";

    public frmUploadBaserom(ref Class18 class18_1)
    {
        this.InitializeComponent();

        class18_0 = class18_1;
        button1.Enabled = false;
        this.comboBox2.SelectedIndex = 0;

        if (!Directory.Exists(IPath)) Directory.CreateDirectory(IPath);

        textBox6.Text = "";
        label1.Text = "Select a File";

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadBaserom));
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "UPDATING !";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(10, 221);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(417, 11);
            this.progressBar1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 31;
            this.label2.Text = "Filename:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 20);
            this.textBox1.TabIndex = 32;
            this.textBox1.Text = "DOUBLE CLIC TO SELECT YOUR FILE";
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(113, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(292, 20);
            this.textBox2.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 33;
            this.label3.Text = "Description:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(113, 51);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(164, 20);
            this.textBox3.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 35;
            this.label4.Text = "Owner:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 38;
            this.label6.Text = "Engine Serie:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 122);
            this.panel1.TabIndex = 40;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(113, 97);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(41, 20);
            this.textBox6.TabIndex = 41;
            this.textBox6.Text = "1.00";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Customs",
            "Serie B",
            "Serie D",
            "Serie F",
            "Serie H"});
            this.comboBox2.Location = new System.Drawing.Point(113, 73);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(164, 22);
            this.comboBox2.TabIndex = 38;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 14);
            this.label5.TabIndex = 40;
            this.label5.Text = "Baserom Version:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 61);
            this.panel3.TabIndex = 42;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(150, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Upload File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.bin";
            this.openFileDialog1.Filter = "BMTune Binary|*.bin";
            this.openFileDialog1.Title = "Open BMtune baserom (.bin)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(11, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(394, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "** NO MORE AVAILABLE, FTP CONNECTION DISABLED SINCE V1.95 **";
            // 
            // frmUploadBaserom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 242);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUploadBaserom";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baserom Uploader";
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

    }
    

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
        /*this.progressBar1.Value = 5;
        label1.Text = "Checking Errors";
        string ThisError = "";
        if (!textBox1.Text.Contains(".bin")) textBox1.Text += ".bin";
        if (textBox1.Text == "") ThisError = "Empty Filename";
        if (textBox1.Text.Length < 8) ThisError = "Filename too short";
        if (textBox1.Text.Length > 40) ThisError = "Filename too long";
        if (textBox1.Text.Contains("|")) ThisError = "Filename cannot contain char '|'";

        if (textBox2.Text == "") ThisError = "Empty Description";
        if (textBox2.Text.Length < 10) ThisError = "Description too short";
        if (textBox2.Text.Length > 60) ThisError = "Description too long";
        if (textBox2.Text.Contains("|")) ThisError = "Description cannot contain char '|'";

        if (textBox3.Text == "") textBox3.Text = "ANONYMOUS";
        if (textBox3.Text.Length < 5) ThisError = "Owner name too short";
        if (textBox3.Text.Length > 20) ThisError = "Owner name too long";
        if (textBox3.Text.Contains("|")) ThisError = "Owner cannot contain char '|'";

        if (textBox1.Text.Length > 4 && textBox1.Text.Substring(textBox1.Text.Length - 4) != ".bin") textBox1.Text = textBox1.Text + ".bin";

        this.progressBar1.Value = 10;

        if (IsFileExistant()) ThisError = "File already exist online";
        else if (label1.Text == "Not Connected") ThisError = "Not Connected to internet";

        this.progressBar1.Value = 15;

        if (ThisError != "")
        {
            MessageBox.Show(Form.ActiveForm, ThisError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            label1.Text = "Error Found";
        }
        else
        {
            label1.Text = "Uploading";
            this.progressBar1.Value = 25;

            string FTPList = "";

            try
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("bmtune", "BNIKs7wx@EuPu$yqwXBa");
                client.DownloadFile(FTPSite + "FTPList.txt", IPath + "FTPList.txt");

                StreamReader reader = new StreamReader(IPath + "FTPList.txt");
                FTPList = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                reader = null;

                FileInfo info = new FileInfo(IPath + "FTPList.txt");
                if (info.Exists) info.Delete();
                info = null;
            }
            catch { }

            this.progressBar1.Value = 50;

            //Create .bin copy
            NewPath = IPath + textBox1.Text;
            File.Create(NewPath).Dispose();
            File.WriteAllBytes(NewPath, File.ReadAllBytes(FilePath));

            //Create description .txt infos
            FTPList += textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + comboBox2.Text + "|" + textBox6.Text + Environment.NewLine;

            string DescPath = IPath + "FTPList.txt";
            StreamWriter writer = new StreamWriter(DescPath, false);
            writer.Write(FTPList);
            writer.Close();
            writer.Dispose();
            writer = null;

            //send files
            SendFTP(NewPath);
            this.progressBar1.Value = 75;
            SendFTP(DescPath);

            FileInfo info2 = new FileInfo(NewPath);
            if (info2.Exists) info2.Delete();
            info2 = null;

            info2 = new FileInfo(DescPath);
            if (info2.Exists) info2.Delete();
            info2 = null;

            if ( label1.Text == "Uploaded") MessageBox.Show(Form.ActiveForm, "File correctly sent!\nAllow some time to the server to upload it", "BMtune", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        this.progressBar1.Value = 0;*/
    }

    /*bool IsFileExistant()
    {
        bool ExistOnline = false;

        try
        {
            label1.Text = "Checking Existence";

            string TPath = IPath + "FilesList.txt";

            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs e) { this.progressBar1.Value = e.ProgressPercentage; };
            webClient.DownloadFileAsync(new Uri(string_11_2 + "FilesList.txt"), TPath);
            while (webClient.IsBusy) { Application.DoEvents(); }

            this.progressBar1.Value = 0;
            label1.Text = "";

            string[] AllText = File.ReadAllLines(IPath + "FilesList.txt");
            if (AllText.Length > 0)
            {
                for (int i = 0; i < AllText.Length; i++)
                {
                    if (AllText[i].Contains("|"))
                    {
                        string[] SplitCMD = AllText[i].Split('|');
                        if (SplitCMD[0] == textBox1.Text) ExistOnline = true;
                    }
                }
            }
        }
        catch
        {
            label1.Text = "Not Connected";
        }

        return ExistOnline;
    }

    void SendFTP(string FilepathT)
    {
        try
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("bmtune", "BNIKs7wx@EuPu$yqwXBa");
            client.UploadFile(FTPSite + Path.GetFileName(FilepathT), FilepathT);

            label1.Text = "Uploaded";
        }
        catch
        {
            label1.Text = "Can't Upload";
        }
    }*/

    private void CheckCompatibility(string ThisFilePath)
    {
        try
        {
            FileBytes = File.ReadAllBytes(ThisFilePath);
            if (CanUploadFile())
            {
                label1.Text = "File Compatible";
                FilePath = ThisFilePath;
                textBox1.Text = Path.GetFileName(ThisFilePath);
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox2.Enabled = true;
                //button1.Enabled = true;
            }
            else
            {
                label1.Text = "File Not Compatible";
                textBox1.Text = "DOUBLE CLIC TO SELECT YOUR FILE";
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox2.Enabled = false;
                button1.Enabled = false;
            }
        }
        catch
        {
            label1.Text = "File Not Compatible";
            textBox1.Text = "DOUBLE CLIC TO SELECT YOUR FILE";
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = false;
        }
    }

    private void textBox1_DoubleClick(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            this.progressBar1.Value = 5;
            CheckCompatibility(openFileDialog1.FileName);
            this.progressBar1.Value = 0;
        }
    }



    public bool CanUploadFile()
    {
        label1.Text = "Getting Compatibility";
        bool CanUpload = false;
        ErrorString = "";

        if (FileBytes.Length < 32768)
        {
            ErrorString = "Incomplete baserom";
        }
        else {
            if ((FileBytes[0x7ffaL] == 0x42) && (FileBytes[0x7ffbL] == 0x4d) && (FileBytes[0x7ffcL] == 0x54) && (FileBytes[0x7ffdL] == 0x75) && (FileBytes[0x7ffeL] == 0x6e) && (FileBytes[0x7fffL] == 0x65))
            {
                if (FileBytes[0x7ff1L] != 0xff)
                {
                    string VStr = ((int)(FileBytes[0x7fefL])).ToString() + ((int)(FileBytes[0x7ff0L])).ToString() + ((int)(FileBytes[0x7ff1L])).ToString();
                    int RomVersion = int.Parse(VStr);

                    //unstable baserom
                    //this.class18_0.LoadBinaryFiles();
                    if (!this.class18_0.Binary_Files_0.IsStable(RomVersion - 100)) ErrorString = "Unstable baserom";
                    //this.class18_0.CloseBinaryFiles();

                    //Get Protection
                    bool Protected = false;
                    for (int i = 0; i < 32; i++) if (FileBytes[0x5ea6L + i] != 0xff) Protected = true;
                    if (Protected) ErrorString = "Protected baserom";
                    else
                    {
                        if (ErrorString == "")
                        {
                            textBox6.Text = "1.";
                            if (RomVersion - 100 < 10) textBox6.Text += "0";
                            textBox6.Text += (RomVersion - 100).ToString();

                            ErrorString = "Correct";
                        }
                    }
                }
                else
                {
                    ErrorString = "Free baserom";
                }
            }
        }

        //Is Loaded ?
        if (ErrorString != "Correct")
        {
            string ThisError = ErrorString;
            if (ErrorString == "") ThisError = GetFileType();
            MessageBox.Show(Form.ActiveForm, ThisError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
            CanUpload = true;
        }

        return CanUpload;
    }

    private string GetFileType()
    {
        //0x0210 = 528	...	eCtune=196, P30=71, Gold=137, P72=228, Neptune=16, P28=212
        //Get Other Softwares
        string Error_Str = "";
        if (FileBytes[528] == 0x2e && FileBytes[529] == 0xf9 && FileBytes[530] == 0x7d) Error_Str = "Crome P30 baserom";
        else if (FileBytes[528] == 228 && FileBytes[529] == 0xf8 && FileBytes[530] == 0xa2) Error_Str = "Crome P72 baserom";
        else if (FileBytes[528] == 212 && FileBytes[529] == 0x1a && FileBytes[530] == 0x02) Error_Str = "Crome P28 baserom";
        else if (FileBytes[528] == 137 && FileBytes[529] == 0xc6 && FileBytes[530] == 0xab) Error_Str = "Crome Gold baserom";
        else if (FileBytes[528] == 19) Error_Str = "Hondata S200 baserom";
        else if (FileBytes[528] == 16 && FileBytes[529] == 0x8a && FileBytes[530] == 0xc4) Error_Str = "Neptune baserom";
        if (FileBytes[0x7fef] == 0x65 && FileBytes[0x7ff0] == 43 && FileBytes[0x7ff1] == 0x74 && FileBytes[0x7ff2] == 0xA9) Error_Str = "eCtune baserom";
        if (Error_Str == "") Error_Str = "Can't load the file!";
        return Error_Str;
    }
}

