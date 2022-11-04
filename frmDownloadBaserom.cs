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

internal class frmDownloadBaserom : Form
{
    private Label label1;
    public ProgressBar progressBar1;
    private IContainer icontainer_0;
    private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label3;
    private TextBox textBox3;
    private Label label4;
    private TextBox textBox4;
    private Label label6;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Label label7;
    private TextBox textBox5;
    private ComboBox comboBox2;
    private ComboBox comboBox1;
    private string string_11_2 = "https://raw.githubusercontent.com/bouletmarc/BMTune_Server/master/";
    private string IPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\";
    private List<string> IList = new List<string>();
    private DataGridView dataGridView1;
    private Button button1;
    int TCount = 0;
    bool InitFiles = true;
    string UThis = "";
    private int IndexOfLastSelectedFile = 0;
    private TextBox textBox6;
    private Label label5;
    private DataGridViewTextBoxColumn ID;
    private DataGridViewTextBoxColumn Filename;
    private DataGridViewTextBoxColumn Description;
    private DataGridViewTextBoxColumn Owner;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private string DPath = Application.StartupPath + @"\Online\";
    private Class18 class18_0;

    public frmDownloadBaserom(ref Class18 class18_1)
    {
        this.InitializeComponent();

        class18_0 = class18_1;

        this.comboBox1.SelectedIndex = 0;
        this.comboBox2.SelectedIndex = 0;

        textBox6.Text = "";

        label1.Text = "Getting Files...";
        
        LoopTimer.Interval = 1000;
        LoopTimer.Tick += DoThisAllTheTime;
        LoopTimer.Start();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    void DoThisAllTheTime(object sender, EventArgs e)
    {
        LoopTimer.Stop();

        if (InitFiles)
        {
            InitFiles = false;
            UpdateFiles("FilesList.txt");
        }
        else
        {
            UpdateFiles(UThis);
        }
    }

    void ReturnBack(string path)
    {
        this.class18_0.method_60();
        this.class18_0.method_26_SetFilename(path);
        this.class18_0.method_24(Path.GetFileName(path));
        this.class18_0.method_5_SetSelectedTable(SelectedTable.fuel1_lo);
        this.class18_0.method_9(TableOverlay.none);
        int length;
        FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        if (stream.CanRead)
        {
            length = (int)stream.Length;
            //this.class18_0.byte_0 = new byte[length];
            this.class18_0.SetByteSize(length);
            byte[] Byte_XX = new byte[length];
            stream.Read(Byte_XX, 0, length);
            this.class18_0.SetAllByte(Byte_XX);
        }
        stream.Dispose();
        stream = null;
        length = 0;

        this.class18_0.method_90();
        if (this.class18_0.method_30_HasFileLoadedInBMTune()) this.class18_0.method_54();
        this.class18_0.class10_settings_0.method_28(path);


        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    void UpdateFiles(string Filename)
    {
        try
        {
            label1.Text = "Downloading...";
            
            string TPath = "";
            if (Filename == "FilesList.txt") {
                TPath = IPath + Filename;

                if (!Directory.Exists(IPath)) Directory.CreateDirectory(IPath);
            }
            else
            {
                string SaveFName = textBox1.Text;
                if (SaveFName.Length > 4 && SaveFName.Substring(SaveFName.Length - 4) != ".bin") SaveFName += ".bin";

                if (!Directory.Exists(DPath)) Directory.CreateDirectory(DPath);

                TPath = DPath + SaveFName;
            }

            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs e) { this.progressBar1.Value = e.ProgressPercentage; };
            webClient.DownloadFileAsync(new Uri(string_11_2 + Filename), TPath);
            while (webClient.IsBusy) { Application.DoEvents(); }

            this.progressBar1.Value = 0;
            label1.Text = "";

            if (Filename == "FilesList.txt") SpawnSearch(false);
            else ReturnBack(TPath);
        }
        catch
        {
            label1.Text = "Not Connected";
        }
    }

    private void SpawnSearch(bool Search)
    {
        IList.Clear();
        dataGridView1.Rows.Clear();

        label1.Text = "Searching...";

        string[] AllText = File.ReadAllLines(IPath + "FilesList.txt");
        if (AllText.Length > 0)
        {
            TCount = 0;

            for (int i = 0; i < AllText.Length; i++)
            {
                if (AllText[i].Contains("|"))
                {
                    //0 = filename
                    //1 = desc
                    //2 = owner
                    //3 = engine serie
                    //4 = baserom version
                    string[] SplitCMD = AllText[i].Split('|');

                    if (!Search)
                    {
                        AddThis(AllText[i], i);
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 0)
                        {
                            if (SplitCMD[0].ToLower().Contains(textBox5.Text) || SplitCMD[1].ToLower().Contains(textBox5.Text) || SplitCMD[2].ToLower().Contains(textBox5.Text))
                                if (IsSerie(SplitCMD[3])) AddThis(AllText[i], i);
                        }
                        if (comboBox1.SelectedIndex == 1)
                        {
                            if (SplitCMD[0].ToLower().Contains(textBox5.Text))
                                if (IsSerie(SplitCMD[3])) AddThis(AllText[i], i);
                        }
                        if (comboBox1.SelectedIndex == 2)
                        {
                            if (SplitCMD[1].ToLower().Contains(textBox5.Text))
                                if (IsSerie(SplitCMD[3])) AddThis(AllText[i], i);
                        }
                        if (comboBox1.SelectedIndex == 3)
                        {
                            if (SplitCMD[2].ToLower().Contains(textBox5.Text))
                                if (IsSerie(SplitCMD[3])) AddThis(AllText[i], i);
                        }
                    }
                }
            }

            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            dataGridView1.Enabled = true;

            label1.Text = TCount + "Found Results";
        }
    }

    bool IsSerie(string Serie)
    {
        bool IsSerie = false;
        if (comboBox2.SelectedIndex == 0) IsSerie = true;
        if (comboBox2.SelectedIndex == 1 && Serie == "Serie B") IsSerie = true;
        if (comboBox2.SelectedIndex == 2 && Serie == "Serie D") IsSerie = true;
        if (comboBox2.SelectedIndex == 3 && Serie == "Serie H") IsSerie = true;
        if (comboBox2.SelectedIndex == 4 && Serie == "Serie F") IsSerie = true;
        if (comboBox2.SelectedIndex == 5 && Serie == "Customs") IsSerie = true;
        return IsSerie;
    }

    void AddThis(string ALL, int TIndex)
    {
        string[] SplitCMD = ALL.Split('|');

        IList.Add(ALL);
        dataGridView1.Rows.Add(TIndex, SplitCMD[0], SplitCMD[1], SplitCMD[2], SplitCMD[3], SplitCMD[4]);
        TCount++;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadBaserom));
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(754, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "UPDATING !";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(10, 530);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(754, 11);
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
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(92, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 20);
            this.textBox1.TabIndex = 32;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(92, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(274, 20);
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
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(467, 7);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(274, 20);
            this.textBox3.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 35;
            this.label4.Text = "Owner:";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(467, 29);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(274, 20);
            this.textBox4.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 38;
            this.label6.Text = "Engine Serie:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(10, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 54);
            this.panel1.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(10, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 34);
            this.panel2.TabIndex = 41;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "All Engines",
            "Serie B",
            "Serie D",
            "Serie F",
            "Serie H",
            "Customs"});
            this.comboBox2.Location = new System.Drawing.Point(568, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(173, 22);
            this.comboBox2.TabIndex = 38;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Everything",
            "Filename",
            "Description",
            "Owner"});
            this.comboBox1.Location = new System.Drawing.Point(385, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 22);
            this.comboBox1.TabIndex = 36;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "Search:";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(92, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(274, 20);
            this.textBox5.TabIndex = 34;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(10, 490);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 40);
            this.panel3.TabIndex = 42;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(109, 10);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(41, 20);
            this.textBox6.TabIndex = 41;
            this.textBox6.Text = "1.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 14);
            this.label5.TabIndex = 40;
            this.label5.Text = "Baserom Version:";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(251, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Download File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Filename,
            this.Description,
            this.Owner,
            this.Column1,
            this.Column2});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(10, 120);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(754, 370);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // Filename
            // 
            this.Filename.HeaderText = "Filename";
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            this.Filename.Width = 190;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 215;
            // 
            // Owner
            // 
            this.Owner.HeaderText = "Owner";
            this.Owner.Name = "Owner";
            this.Owner.ReadOnly = true;
            this.Owner.Width = 120;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Engine Serie";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Version";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // frmDownloadBaserom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 551);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadBaserom";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baserom Downloader";
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

    }

    

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

    void Respawn()
    {
        if (textBox5.Text == "") SpawnSearch(false);
        else SpawnSearch(true);
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
        Respawn();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Respawn();
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Respawn();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
        textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
        textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString();
        textBox4.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString();
        textBox6.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[5].Value.ToString();

        IndexOfLastSelectedFile = dataGridView1.SelectedRows[0].Index;

        button1.Enabled = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string[] AllText = File.ReadAllLines(IPath + "FilesList.txt");
        if (AllText.Length > 0)
        {
            if (AllText[IndexOfLastSelectedFile].Contains("|"))
            {
                string[] SplitCMD = AllText[IndexOfLastSelectedFile].Split('|');
                UThis = SplitCMD[0];

                LoopTimer.Start();
            }
        }
    }
}

