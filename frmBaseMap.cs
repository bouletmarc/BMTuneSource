using Controls;
using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmBaseMap : Form
{
    private bool bool_0;
    private Button btnCancel;
    private Button btnNext;
    private Button btnPrev;
    private byte byte_0;
    private byte[] byte_1;
    private CheckBox chkBoostCut;
    private Class1_u class1_u_0;
    private Class1_Version class1_Version_0;
    private Class18 class18_0;
    private FrmMain FrmMain_0;
    private Class8_u class8_u_0;
    private Class8_v class8_v_0;
    private Class9_baserom class9_baserom_0;
    private ctrlBatteryOffset ctrlBatteryOffset_0 = new ctrlBatteryOffset();
    private ctrlMapSensor ctrlMapSensor_0 = new ctrlMapSensor();
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;
    private double[] double_0;
    private double[] double_1;
    private ErrorProvider errorProvider_0;
    private DataGridView grid;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private IContainer icontainer_0;
    private int int_0 = 0;
    private int int_1;
    private int int_2;
    private int int_3;
    private int[] int_4 = new int[0x18];
    private int[] int_5 = new int[0x18];
    private Label label1;
    private Label label12;
    private Label label13;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label8;
    private Label lblState;
    private Label lblVersion;
    private ComboBox lstGear;
    private Panel pnlGrid;
    private Panel pnlMap;
    private ToolTip toolTip_0;
    private TextBox txtbBoostcut;
    private TextBox txtbBoostFuel;
    private TextBox txtbBoostRetard;
    private TextBox txtbCols;
    private TextBox txtbInjecNew;
    private IContainer components;
    private GroupBox groupBox4;
    private Label label2;
    private TextBox textBox1;
    private TextBox txtbTipin;
    private Label label7;
    private TextBox txtbPostfuel;
    private Label label10;
    private TextBox txtbCrank;
    private Label label16;
    private CheckBox checkBox1;
    private Label label3;
    private Label label9;
    private Label label19;
    private Label label18;
    private Label label17;
    private Label label15;
    private Label label14;
    private Label label11;
    private Label label20;
    private ImageList imageList1;
    private TextBox txtbOverall;
    string LastMultiplier = "";
    private CheckBox checkBox5;
    private CheckBox checkBox6;
    private CheckBox checkBox7;
    private CheckBox checkBox4;
    private CheckBox checkBox3;
    private CheckBox checkBox2;
    private Panel pnlRomOptions2;
    private CheckBox checkBox8;
    private TextBox textBox3;
    private Label label22;
    private TextBox textBox2;
    private Label label21;
    public bool CalSelected = false;
    private TreeView treeView;
    private Panel pnlName;
    private TextBox txtDesc;
    private Label label24;
    private TextBox txtName;
    private Label label23;
    public bool Reloading = false;
    public bool IsOBD0 = false;

    private bool IsPremade = false;
    private bool IsInternet = false;
    private int CalIndex = 0;
    //private ProgressBar progressBar1;
    private string string_11_2 = "https://raw.githubusercontent.com/bouletmarc/BMTune_Server/master/";
    private string IPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\";
    private System.Windows.Forms.Timer LoopTimer = new System.Windows.Forms.Timer();
    private GroupBox groupBox6;
    private ComboBox comboBox1;
    private LinkLabel link_Changelog;
    private frmDownloadBaserom frmDownloadBaserom_0;
    private Panel panel1;
    private Button buttonStartInternet;
    private Button button2;
    private Button button1;
    private Button button3;
    private Button button4;
    private frmChangelog frmChangelog_0;

    //private List<string> IList = new List<string>();
    //private byte[] IByte = new byte[] { };

    //private Button btnUpload;

    internal frmBaseMap(ref Class18 class18_1, ref FrmMain FrmMain_1)
    {
        this.ctrlBatteryOffset_0 = new ctrlBatteryOffset();
        this.InitializeComponent();
        this.ctrlMapSensor_0.mapSensorChangedDelegate_0 += new ctrlMapSensor.MapSensorChangedDelegate(this.method_5);
        this.txtbBoostRetard.Text = 1.25f.ToString();
        this.class18_0 = class18_1;
        this.FrmMain_0 = FrmMain_1;

        class9_baserom_0 = new Class9_baserom(ref class18_0);

        treeView.Enabled = false;
        link_Changelog.Visible = false;
        this.txtDesc.Enabled = false;

        LoopTimer.Interval = 100;
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
        UpdateFiles("FilesList.txt");
    }

    void UpdateFiles(string Filename)
    {
        try
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri(string_11_2 + Filename), IPath + Filename);
            while (webClient.IsBusy) { Application.DoEvents(); }

            FileInfo info = new FileInfo(IPath + Filename);
            if (info.Exists && Filename == "FilesList.txt") SpawnInternet();
            info = null;
        }
        catch
        {
        }
        treeView.Enabled = true;
    }

    private void CheckClass9Exist()
    {
        if (class9_baserom_0 == null)
        {
            class9_baserom_0 = new Class9_baserom(ref class18_0);
        }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        bool CanGoNext = true;

        if (this.int_0 == 0)
        {
            CalSelected = false;
            if (!IsInternet)
            {
                if (IsPremade)
                {
                    CheckClass9Exist();
                    this.class8_v_0 = this.class9_baserom_0.class8_v_0[CalIndex];
                    CalSelected = true;
                }
            }
            else
            {
                //Load Internet no need to go furter
                this.frmDownloadBaserom_0 = new frmDownloadBaserom(ref this.class18_0);
                DialogResult result = this.frmDownloadBaserom_0.ShowDialog();
                if (result == DialogResult.OK) base.Close();
            }
        }
        else if (this.int_0 == 1)
        {
            this.class1_Version_0 = this.class18_0.Binary_Files_0.class1_Version_0[this.grid.CurrentCell.RowIndex];

            string TVers = this.grid.Rows[this.grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            TVers = TVers.Replace("V", "");
            TVers = TVers.Replace(".", "");
            this.class1_Version_0.Version = int.Parse(TVers);

            //Load Calibration no need to go furter
            if (CalSelected)
            {
                this.method_7();
                base.Close();
            }
        }
        else if (this.int_0 == 2)
        {
            try
            {
                this.class18_0.class10_settings_0.BoostFuel = int.Parse(txtbBoostFuel.Text);
            }
            catch
            {
                this.class18_0.class10_settings_0.BoostFuel = 120;
            }
            try
            {
                this.class18_0.class10_settings_0.BoostRetard = float.Parse(txtbBoostRetard.Text);
            }
            catch
            {
                this.class18_0.class10_settings_0.BoostRetard = 1;
            }

            //Rom Options
            CheckClass9Exist();
            this.class1_u_0 = this.class9_baserom_0.class1_u_0[this.comboBox1.SelectedIndex];
            this.class1_u_0.IsELD = !this.checkBox2.Checked;
            this.class1_u_0.IsBaro = !this.checkBox3.Checked;
            this.class1_u_0.IsInjTest = !this.checkBox4.Checked;
            this.class1_u_0.IsKnock = !this.checkBox5.Checked;
            this.class1_u_0.IsO2H = !this.checkBox6.Checked;
            this.class1_u_0.IsIAB = !this.checkBox7.Checked;
        }
        else if (this.int_0 == 4)
        {
            CheckClass9Exist();
            this.class8_u_0 = this.class9_baserom_0.class8_u_0[this.grid.CurrentCell.RowIndex];
            
            this.class8_u_0.IsVTEC = this.checkBox8.Checked;
            this.class8_u_0.VtcHigh = int.Parse(textBox2.Text);
            this.class8_u_0.VtcLow = int.Parse(textBox2.Text) + 200;

            this.class8_u_0.RpmLowSet = int.Parse(textBox3.Text);
            this.class8_u_0.RpmLowReset = int.Parse(textBox3.Text) - 70;
            this.class8_u_0.RpmHighSet = int.Parse(textBox3.Text);
            this.class8_u_0.RpmHighReset = int.Parse(textBox3.Text) - 70;
        }

        //Apply Next
        if (CanGoNext)
        {
            if ((this.int_0 == 4))
            {
                this.method_7();
                //base.Close();
                this.Close();
            }
            else
            {
                if (!IsInternet)
                {
                    this.int_0++;
                    //RomOptions page no more exist
                    if (this.int_0 == 3) this.int_0++;
                    this.method_1();
                }
            }
        }
    }

    /*private void btnOverallCalc_Click(object sender, EventArgs e)
    {
        frmInjectorOverallCalc calc = new frmInjectorOverallCalc();
        calc.method_0(ref this.class18_0);
        if (calc.ShowDialog() == DialogResult.OK)
        {
            this.txtbOverall.Text = double.Parse(calc.Tag.ToString()).ToString();
        }
        calc.Close();
        calc.Dispose();
        calc = null;
    }*/

    private void btnPrev_Click(object sender, EventArgs e)
    {
        //already on page0
        if (this.int_0 == 0)
        {
            IsPremade = false;
            IsInternet = false;
            this.panel1.Visible = true;
            this.treeView.Visible = false;
            this.btnPrev.Enabled = false;
        }

        this.int_0--;
        if (this.int_0 < 0) this.int_0 = 0;
        if (this.int_0 == 0) CalSelected = false;
        //RomOptions page no more exist
        if (this.int_0 == 3) this.int_0--;

        this.method_1();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmBaseMap_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.class9_baserom_0 != null)
        {
            this.class9_baserom_0.method_5();
            this.class9_baserom_0 = null;
        }
        GC.Collect();
    }

    private void frmBaseMap_Load(object sender, EventArgs e)
    {
        this.ctrlMapSensor_0.method_0(ref this.class18_0);
        this.ctrlBatteryOffset_0.method_0(ref this.class18_0);
        this.ctrlBatteryOffset_0.method_1(1);
        if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi) this.txtbOverall.Text = 1.ToString();
        else this.txtbOverall.Text = 0.ToString();
        this.lstGear.SelectedIndex = 0;
        //this.comboBox1.SelectedIndex = 0;
        this.method_1();

        LastMultiplier = (float.Parse(this.textBox1.Text) / float.Parse(this.txtbInjecNew.Text)).ToString("0.000");
        this.btnNext.Focus();
    }

    private void grid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            this.btnNext_Click(null, null);
        }
    }

    public void ReloadOption()
    {
        if (this.int_0 == 2)
        {
            if (!CalSelected)
            {
                CheckClass9Exist();
                this.class1_u_0 = this.class9_baserom_0.class1_u_0[this.comboBox1.SelectedIndex];

                if (this.class1_u_0.bool_7)
                {
                    this.checkBox2.Checked = true;
                    this.checkBox3.Checked = true;
                    this.checkBox4.Checked = true;
                    this.checkBox5.Checked = true;
                    this.checkBox6.Checked = true;
                    this.checkBox7.Checked = true;
                }
                else
                {
                    this.checkBox2.Checked = !this.class1_u_0.IsELD;
                    this.checkBox3.Checked = !this.class1_u_0.IsBaro;
                    this.checkBox4.Checked = !this.class1_u_0.IsInjTest;
                    this.checkBox5.Checked = !this.class1_u_0.IsKnock;
                    this.checkBox6.Checked = !this.class1_u_0.IsO2H;
                    this.checkBox7.Checked = !this.class1_u_0.IsIAB;
                }
            }
        }
        if (this.int_0 == 4)
        {
            CheckClass9Exist();
            this.class8_u_0 = this.class9_baserom_0.class8_u_0[this.grid.CurrentCell.RowIndex];

            this.checkBox8.Checked = this.class8_u_0.IsVTEC;
            this.textBox2.Enabled = this.class8_u_0.IsVTEC;
            if (this.class8_u_0.IsVTEC) this.textBox2.Text = this.class8_u_0.VtcHigh.ToString();
            else this.textBox2.Text = "5400";
            this.textBox3.Text = this.class8_u_0.RpmHighSet.ToString();
        }

        Reloading = false;
    }

    private void grid_SelectionChanged(object sender, EventArgs e)
    {
        if (!Reloading) ReloadOption();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!Reloading) ReloadOption();
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMap));
            this.ctrlMapSensor_0 = new Controls.ctrlMapSensor();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lstGear = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbTipin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtbPostfuel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbCrank = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbInjecNew = new System.Windows.Forms.TextBox();
            this.txtbOverall = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkBoostCut = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbBoostRetard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbBoostFuel = new System.Windows.Forms.TextBox();
            this.txtbBoostcut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbCols = new System.Windows.Forms.TextBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.treeView = new System.Windows.Forms.TreeView();
            this.lblState = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlRomOptions2 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.pnlName = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.link_Changelog = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonStartInternet = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlMap.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.pnlRomOptions2.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlBatteryOffset_0
            // 
            this.ctrlBatteryOffset_0.Location = new System.Drawing.Point(23, 112);
            this.ctrlBatteryOffset_0.Name = "ctrlBatteryOffset_0";
            this.ctrlBatteryOffset_0.Size = new System.Drawing.Size(261, 23);
            this.ctrlBatteryOffset_0.TabIndex = 8;
            this.ctrlBatteryOffset_0.delegate64_0 += new ctrlBatteryOffset.Delegate64(this.method_10);
            // 
            // ctrlMapSensor_0
            // 
            this.ctrlMapSensor_0.Location = new System.Drawing.Point(10, 14);
            this.ctrlMapSensor_0.Name = "ctrlMapSensor_0";
            this.ctrlMapSensor_0.Size = new System.Drawing.Size(182, 127);
            this.ctrlMapSensor_0.TabIndex = 18;
            // 
            // pnlMap
            // 
            this.pnlMap.Controls.Add(this.groupBox6);
            this.pnlMap.Controls.Add(this.groupBox4);
            this.pnlMap.Controls.Add(this.groupBox3);
            this.pnlMap.Controls.Add(this.groupBox2);
            this.pnlMap.Controls.Add(this.groupBox1);
            this.pnlMap.Location = new System.Drawing.Point(12, 29);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(464, 342);
            this.pnlMap.TabIndex = 9;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBox1);
            this.groupBox6.Controls.Add(this.checkBox5);
            this.groupBox6.Controls.Add(this.checkBox6);
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Controls.Add(this.checkBox7);
            this.groupBox6.Controls.Add(this.checkBox3);
            this.groupBox6.Controls.Add(this.checkBox4);
            this.groupBox6.Location = new System.Drawing.Point(319, 152);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(138, 185);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sensors/Options";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 350;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 22);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(14, 44);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(103, 18);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Disable Knock";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(14, 136);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(93, 18);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Text = "Disable O2H";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(14, 67);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 18);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Disable ELD";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(14, 159);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(86, 18);
            this.checkBox7.TabIndex = 3;
            this.checkBox7.Text = "Disable IAB";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(14, 90);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(82, 18);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Disable PA";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(14, 113);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(109, 18);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Disable Inj Test";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ctrlMapSensor_0);
            this.groupBox4.Location = new System.Drawing.Point(5, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 147);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Map Sensor";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lstGear);
            this.groupBox3.Location = new System.Drawing.Point(5, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 42);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transmission";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "Transmission:";
            // 
            // lstGear
            // 
            this.lstGear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstGear.DropDownWidth = 300;
            this.lstGear.FormattingEnabled = true;
            this.lstGear.Items.AddRange(new object[] {
            "Civic/Delsol y21/y80/s80 JDM",
            "Civic/Delsol y21/y80/s80 EDM",
            "ITR s80 JDM 96-97",
            "ITR s80 JDM 98-01",
            "ITR s80 USDM 97-01",
            "Civic/Delsol d16z6(92-95)/d16y8(96-00)",
            "Integra GSR USDM 94+",
            "Integra GSR JDM 93+ SiR-G",
            "Integra LS/RS/GS/SE 94+",
            "Prelude H22 USDM 92-96",
            "Prelude H22 JDM 92-96",
            "Prelude H23 USDM 92-96",
            "Prelude H23 JDM 92-96",
            "Civic D16Y7 96-00"});
            this.lstGear.Location = new System.Drawing.Point(99, 13);
            this.lstGear.Name = "lstGear";
            this.lstGear.Size = new System.Drawing.Size(195, 22);
            this.lstGear.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtbTipin);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtbPostfuel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.ctrlBatteryOffset_0);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtbCrank);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtbInjecNew);
            this.groupBox2.Controls.Add(this.txtbOverall);
            this.groupBox2.Location = new System.Drawing.Point(5, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 142);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Injector Setup";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(285, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 14);
            this.label19.TabIndex = 32;
            this.label19.Text = "%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(104, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 14);
            this.label14.TabIndex = 19;
            this.label14.Text = "cc";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(285, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 14);
            this.label18.TabIndex = 31;
            this.label18.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(104, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "cc";
            // 
            // txtbTipin
            // 
            this.txtbTipin.Location = new System.Drawing.Point(241, 66);
            this.txtbTipin.Name = "txtbTipin";
            this.txtbTipin.Size = new System.Drawing.Size(38, 20);
            this.txtbTipin.TabIndex = 27;
            this.txtbTipin.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(285, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 14);
            this.label15.TabIndex = 29;
            this.label15.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tps Tip-in:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(104, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 14);
            this.label17.TabIndex = 30;
            this.label17.Text = "%";
            // 
            // txtbPostfuel
            // 
            this.txtbPostfuel.Location = new System.Drawing.Point(241, 43);
            this.txtbPostfuel.Name = "txtbPostfuel";
            this.txtbPostfuel.Size = new System.Drawing.Size(38, 20);
            this.txtbPostfuel.TabIndex = 25;
            this.txtbPostfuel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Old Inj:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(173, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 14);
            this.label10.TabIndex = 26;
            this.label10.Text = "Post Start:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(173, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 14);
            this.label16.TabIndex = 24;
            this.label16.Text = "Cranking:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(38, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "240";
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(83, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "Injectors Battery Offset:";
            // 
            // txtbCrank
            // 
            this.txtbCrank.Location = new System.Drawing.Point(241, 20);
            this.txtbCrank.Name = "txtbCrank";
            this.txtbCrank.Size = new System.Drawing.Size(38, 20);
            this.txtbCrank.TabIndex = 23;
            this.txtbCrank.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "New Inj:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "Overall:";
            // 
            // txtbInjecNew
            // 
            this.txtbInjecNew.Location = new System.Drawing.Point(61, 43);
            this.txtbInjecNew.Name = "txtbInjecNew";
            this.txtbInjecNew.Size = new System.Drawing.Size(38, 20);
            this.txtbInjecNew.TabIndex = 4;
            this.txtbInjecNew.Text = "240";
            this.txtbInjecNew.TextChanged += new System.EventHandler(this.txtbInjecNew_TextChanged);
            this.txtbInjecNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtbInjecNew_Validating);
            // 
            // txtbOverall
            // 
            this.txtbOverall.Location = new System.Drawing.Point(61, 66);
            this.txtbOverall.Name = "txtbOverall";
            this.txtbOverall.Size = new System.Drawing.Size(38, 20);
            this.txtbOverall.TabIndex = 13;
            this.txtbOverall.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.chkBoostCut);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbBoostRetard);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbBoostFuel);
            this.groupBox1.Controls.Add(this.txtbBoostcut);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbCols);
            this.groupBox1.Location = new System.Drawing.Point(211, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 147);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boost";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(209, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 14);
            this.label20.TabIndex = 22;
            this.label20.Text = "°";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(209, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "psi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "%";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 18);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Rescale For Boost";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.rbNa_CheckedChanged);
            // 
            // chkBoostCut
            // 
            this.chkBoostCut.AutoSize = true;
            this.chkBoostCut.Enabled = false;
            this.chkBoostCut.Location = new System.Drawing.Point(16, 43);
            this.chkBoostCut.Name = "chkBoostCut";
            this.chkBoostCut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkBoostCut.Size = new System.Drawing.Size(135, 18);
            this.chkBoostCut.TabIndex = 13;
            this.chkBoostCut.Text = "Enable Boost Cut At:";
            this.chkBoostCut.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Retard Per PSI:";
            // 
            // txtbBoostRetard
            // 
            this.txtbBoostRetard.Enabled = false;
            this.txtbBoostRetard.Location = new System.Drawing.Point(162, 118);
            this.txtbBoostRetard.Name = "txtbBoostRetard";
            this.txtbBoostRetard.Size = new System.Drawing.Size(41, 20);
            this.txtbBoostRetard.TabIndex = 9;
            this.txtbBoostRetard.Text = "1.25";
            this.txtbBoostRetard.Validating += new System.ComponentModel.CancelEventHandler(this.txtbBoostRetard_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fuel Per PSI:";
            // 
            // txtbBoostFuel
            // 
            this.txtbBoostFuel.Enabled = false;
            this.txtbBoostFuel.Location = new System.Drawing.Point(162, 93);
            this.txtbBoostFuel.Name = "txtbBoostFuel";
            this.txtbBoostFuel.Size = new System.Drawing.Size(41, 20);
            this.txtbBoostFuel.TabIndex = 7;
            this.txtbBoostFuel.Text = "120";
            this.txtbBoostFuel.Validating += new System.ComponentModel.CancelEventHandler(this.txtbCols_Validating);
            // 
            // txtbBoostcut
            // 
            this.txtbBoostcut.Enabled = false;
            this.txtbBoostcut.Location = new System.Drawing.Point(162, 41);
            this.txtbBoostcut.Name = "txtbBoostcut";
            this.txtbBoostcut.Size = new System.Drawing.Size(42, 20);
            this.txtbBoostcut.TabIndex = 4;
            this.txtbBoostcut.Text = "3";
            this.txtbBoostcut.Validating += new System.ComponentModel.CancelEventHandler(this.txtbCols_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Boost Columns:";
            // 
            // txtbCols
            // 
            this.txtbCols.Enabled = false;
            this.txtbCols.Location = new System.Drawing.Point(162, 68);
            this.txtbCols.Name = "txtbCols";
            this.txtbCols.Size = new System.Drawing.Size(41, 20);
            this.txtbCols.TabIndex = 2;
            this.txtbCols.Text = "6";
            this.txtbCols.Validating += new System.ComponentModel.CancelEventHandler(this.txtbCols_Validating);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.Location = new System.Drawing.Point(12, 59);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(464, 312);
            this.pnlGrid.TabIndex = 1;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle1;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.GridColor = System.Drawing.Color.Black;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowCellToolTips = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(464, 312);
            this.grid.TabIndex = 1;
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            this.grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.CausesValidation = false;
            this.treeView.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.FullRowSelect = true;
            this.treeView.Indent = 15;
            this.treeView.Location = new System.Drawing.Point(12, 59);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(464, 312);
            this.treeView.TabIndex = 10;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.DoubleClick += new System.EventHandler(this.treeView_DoubleClick);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(14, 10);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(91, 14);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "Select Options:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 429);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(11, 13);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = " ";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // toolTip_0
            // 
            this.toolTip_0.AutoPopDelay = 10000;
            this.toolTip_0.InitialDelay = 500;
            this.toolTip_0.ReshowDelay = 100;
            this.toolTip_0.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(388, 377);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(87, 25);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(294, 377);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(87, 25);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(200, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlRomOptions2
            // 
            this.pnlRomOptions2.Controls.Add(this.textBox3);
            this.pnlRomOptions2.Controls.Add(this.label22);
            this.pnlRomOptions2.Controls.Add(this.textBox2);
            this.pnlRomOptions2.Controls.Add(this.label21);
            this.pnlRomOptions2.Controls.Add(this.checkBox8);
            this.pnlRomOptions2.Location = new System.Drawing.Point(12, 29);
            this.pnlRomOptions2.Name = "pnlRomOptions2";
            this.pnlRomOptions2.Size = new System.Drawing.Size(464, 31);
            this.pnlRomOptions2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(385, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(58, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(299, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 14);
            this.label22.TabIndex = 4;
            this.label22.Text = "Rev Limit RPM:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(188, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(58, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(122, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 14);
            this.label21.TabIndex = 2;
            this.label21.Text = "Vtec RPM:";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(10, 8);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(93, 18);
            this.checkBox8.TabIndex = 1;
            this.checkBox8.Text = "Enable VTEC";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // pnlName
            // 
            this.pnlName.Controls.Add(this.txtDesc);
            this.pnlName.Controls.Add(this.label24);
            this.pnlName.Controls.Add(this.txtName);
            this.pnlName.Controls.Add(this.label23);
            this.pnlName.Location = new System.Drawing.Point(12, 29);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(464, 30);
            this.pnlName.TabIndex = 11;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(223, 5);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(235, 20);
            this.txtDesc.TabIndex = 7;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(179, 8);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 14);
            this.label24.TabIndex = 6;
            this.label24.Text = "Desc:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(49, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 20);
            this.txtName.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 14);
            this.label23.TabIndex = 4;
            this.label23.Text = "Name:";
            // 
            // link_Changelog
            // 
            this.link_Changelog.AutoSize = true;
            this.link_Changelog.Location = new System.Drawing.Point(14, 382);
            this.link_Changelog.Name = "link_Changelog";
            this.link_Changelog.Size = new System.Drawing.Size(151, 14);
            this.link_Changelog.TabIndex = 12;
            this.link_Changelog.TabStop = true;
            this.link_Changelog.Text = "See Baseroms Changelogs";
            this.link_Changelog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Changelog_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.buttonStartInternet);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 312);
            this.panel1.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(57, 216);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(337, 46);
            this.button4.TabIndex = 18;
            this.button4.Text = "Create New VW/Audi/BMW Basemap";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Green;
            this.button3.Location = new System.Drawing.Point(57, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(337, 46);
            this.button3.TabIndex = 17;
            this.button3.Text = "Create New Honda/Acura OBD0 Basemap";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonStartInternet
            // 
            this.buttonStartInternet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartInternet.Location = new System.Drawing.Point(57, 161);
            this.buttonStartInternet.Name = "buttonStartInternet";
            this.buttonStartInternet.Size = new System.Drawing.Size(337, 46);
            this.buttonStartInternet.TabIndex = 16;
            this.buttonStartInternet.Text = "Start from a Premade Honda/Acura Calibration\r\n(select a calibration from internet" +
    " vault)";
            this.buttonStartInternet.UseVisualStyleBackColor = true;
            this.buttonStartInternet.Click += new System.EventHandler(this.ButtonStartInternet_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(57, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(337, 46);
            this.button2.TabIndex = 15;
            this.button2.Text = "Start from a Premade Honda/Acura Calibration\r\n(select a calibration already integ" +
    "rated)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(57, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(337, 46);
            this.button1.TabIndex = 14;
            this.button1.Text = "Create New Honda/Acura OBD1 Basemap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // frmBaseMap
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(490, 407);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.link_Changelog);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.pnlName);
            this.Controls.Add(this.pnlRomOptions2);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblState);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaseMap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Basemap Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseMap_FormClosing);
            this.Load += new System.EventHandler(this.frmBaseMap_Load);
            this.pnlMap.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.pnlRomOptions2.ResumeLayout(false);
            this.pnlRomOptions2.PerformLayout();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void method_1()
    {
        Reloading = true;

        if (this.int_0 == 2)
        {
            this.pnlGrid.Visible = false;
            this.pnlMap.Visible = true;
            this.pnlName.Visible = false;
            this.treeView.Visible = false;
            this.panel1.Visible = false;
            this.lblState.Text = "Options: ";
            
            txtbBoostFuel.Text = this.class18_0.class10_settings_0.BoostFuel.ToString();
            txtbBoostRetard.Text = this.class18_0.class10_settings_0.BoostRetard.ToString();
        }
        //else if ((this.int_0 == 0) || (this.int_0 == 1) || (this.int_0 == 3) || (this.int_0 == 4))
        else if ((this.int_0 == 1) || (this.int_0 == 3) || (this.int_0 == 4))
        {
            this.pnlGrid.Visible = true;
            this.pnlMap.Visible = false;
            this.pnlName.Visible = false;
            this.treeView.Visible = false;
            this.panel1.Visible = false;
        }
        else if (this.int_0 == 0)
        {
            this.pnlGrid.Visible = false;
            this.pnlName.Visible = true;
            this.treeView.Visible = false;
            this.panel1.Visible = true;

            this.txtName.Text = "New Baserom";
            this.txtDesc.Text = "Create a new baserom";
        }

        if (this.int_0 == 1)
        {
            this.pnlGrid.Height = 308;
            this.pnlGrid.Location = new Point(12,29);
            this.grid.Height = 308;
            this.grid.Location = new Point(0, 0);
        }
        else if (this.int_0 == 4)
        {
            this.pnlGrid.Height = 276;
            this.pnlGrid.Location = new Point(12, 61);
            this.grid.Height = 276;
            this.grid.Location = new Point(0, 0);
        }
        else if (this.int_0 == 0)
        {
            this.pnlGrid.Height = 281;
            this.pnlGrid.Location = new Point(12, 56);
            this.grid.Height = 281;
            this.grid.Location = new Point(0, 0);
        }
        else
        {
            this.pnlGrid.Height = 261;
            this.pnlGrid.Location = new Point(12, 76);
            this.grid.Height = 261;
            this.grid.Location = new Point(0, 0);
        }

        //Set Rom Option Panel
        if (this.int_0 == 4) this.pnlRomOptions2.Visible = true;
        else this.pnlRomOptions2.Visible = false;

        //Set Next Button
        if (this.int_0 == 0) this.btnPrev.Enabled = false;
        else this.btnPrev.Enabled = true;

        if (this.int_0 == 4 || CalSelected) this.btnNext.Text = "Finish";
        else this.btnNext.Text = "Next";
        
        //Baseroms Changelogs
        if (this.int_0 == 1) link_Changelog.Visible = true;
        else link_Changelog.Visible = false;

        //Page 0
        if (this.int_0 == 0)
        {
            this.lblState.Text = "Select Calibration: ";
            this.method_3(this.int_0);
        }

        //Page 1
        if (this.int_0 == 1)
        {
            this.lblState.Text = "Select Baserom Version: ";
            this.grid.Columns.Clear();
            this.grid.Rows.Clear();
            DataGridViewColumn column2 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Version",
                ReadOnly = true,
                Width = 60,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column2);

            column2 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Stable",
                ReadOnly = true,
                Width = 50,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column2);

            DataGridViewColumn column3 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Infos",
                ReadOnly = true,
                Width = 325,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column3);

            this.method_3(this.int_0);
            this.grid.Focus();
        }

        //Page 3
        if (this.int_0 == 2) this.method_3(this.int_0);

        //Page 4
        if (this.int_0 == 4)
        {
            this.lblState.Text = "Use Maps From: ";
            this.grid.Columns.Clear();
            this.grid.Rows.Clear();
            DataGridViewColumn column2 = new DataGridViewTextBoxColumn {
                HeaderText = "ECU",
                ReadOnly = true,
                Width = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column2);
            column2 = new DataGridViewTextBoxColumn
            {
                HeaderText = "ROM",
                ReadOnly = true,
                Width = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column2);
            column2 = new DataGridViewTextBoxColumn {
                HeaderText = "Country",
                ReadOnly = true,
                Width = 60,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column2);
            column2 = new DataGridViewTextBoxColumn {
                HeaderText = "Engine",
                ReadOnly = true,
                Width = 90,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column2);
            column2 = new DataGridViewTextBoxColumn {
                HeaderText = "Additional Info",
                ReadOnly = true,
                Width = 205,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            this.grid.Columns.Add(column2);
            this.method_3(this.int_0);
            this.grid.Focus();
        }

        //ReloadOption();
    }

    private void method_10(byte[] byte_2, double[] double_2, double[] double_3, int int_6, string string_0)
    {
        this.double_0 = double_2;
        this.double_1 = double_3;
        this.byte_0 = (byte) int_6;
        this.bool_0 = true;
    }

    private void method_2(object sender, EventArgs e)
    {
        int num = int.Parse(((RadioButton)sender).Tag.ToString());
        this.lblVersion.Text = ((RadioButton)sender).Text;
        this.lblVersion.Tag = num;
    }

    private void SpawnInternet()
    {
        string[] AllText = File.ReadAllLines(IPath + "FilesList.txt");
        if (AllText.Length > 0)
        {
            int TCount = 0;

            for (int i=0; i < AllText.Length; i++)
            {
                if (AllText[i].Contains("|"))
                {
                    //0 = filename
                    //1 = desc
                    //3 = dyno tuned
                    //4 = engine serie
                    //IList.Add(AllText[i]);
                    //string[] SplitCMD = AllText[i].Split('|');
                    //treeView.Nodes[2].Nodes.Add(SplitCMD[0]);
                    TCount++;
                }
            }

            buttonStartInternet.Text = "Start from a Premade Calibration\n(from internet(" + TCount + "))";
        }
    }

    private void method_3(int int_6)
    {
        if (int_6 == 0)
        {
            int TCount = 0;

            CheckClass9Exist();
            foreach (Class8_v class8_v_1 in this.class9_baserom_0.class8_v_0)
            {
                if (class8_v_1.string_2 != "") treeView.Nodes.Add(class8_v_1.string_4 + " (" + class8_v_1.string_2 + ")");
                else treeView.Nodes.Add(class8_v_1.string_4);
                TCount++;
            }
            //treeView.Nodes[1].Text = "Premade Calibrations (" + TCount + ")";

            //Select create new
            //treeView.SelectedNode = treeView.Nodes[0];
        }
        else if (int_6 == 1)
        {
            //try
            //{
                this.class18_0.Binary_Files_0.ReloadVersion();
                for (int i = this.class18_0.Binary_Files_0.class1_Version_0.Count - 1; i >= 0; i--)
                {
                    Class1_Version class1_Version_1 = this.class18_0.Binary_Files_0.class1_Version_0[i];

                    this.grid.Rows.Add();
                    this.grid.Rows[this.grid.RowCount - 1].Cells[0].Value = "V" + class1_Version_1.Version.ToString().Substring(0, 1) + "." + class1_Version_1.Version.ToString().Substring(1, 1) + class1_Version_1.Version.ToString().Substring(2, 1);
                    this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value = class1_Version_1.Stable.ToString();
                    this.grid.Rows[this.grid.RowCount - 1].Cells[2].Value = class1_Version_1.Infos;
                }

                //Select last stable version
                if (this.grid.Rows.Count > 0)
                {
                    for (int i = 0; i < this.grid.Rows.Count; i++)
                    {
                        if (this.grid.Rows[i].Cells.Count >= 2)
                        {
                            if (this.grid.Rows[i].Cells[1].Value.ToString() == "True")
                            {
                                this.grid.Rows[i].Selected = true;
                                i = this.grid.Rows.Count;
                            }
                        }
                    }
                }
            //}
            //catch { }
        }
        else if (int_6 == 2)
        {
            if (!CalSelected)
            {
                CheckClass9Exist();
                foreach (Class1_u Class1_u_1 in this.class9_baserom_0.class1_u_0)
                {
                    if (Class1_u_1.string_2 != "") this.comboBox1.Items.Add(Class1_u_1.string_0 + "-" + Class1_u_1.string_1 + "-" + Class1_u_1.string_2);
                    else this.comboBox1.Items.Add(Class1_u_1.string_0 + "-" + Class1_u_1.string_1);
                }

                //Select first row
                this.comboBox1.SelectedIndex = 0;
            }
        }
        else if (int_6 == 4)
        {
            CheckClass9Exist();
            foreach (Class8_u class8_u_1 in this.class9_baserom_0.class8_u_0)
            {
                this.grid.Rows.Add();
                this.grid.Rows[this.grid.RowCount - 1].Cells[0].Value = class8_u_1.string_0;
                this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value = class8_u_1.string_1;
                this.grid.Rows[this.grid.RowCount - 1].Cells[2].Value = class8_u_1.string_3;
                this.grid.Rows[this.grid.RowCount - 1].Cells[3].Value = class8_u_1.string_4;

                string Infos = "";
                Infos += class8_u_1.RpmHighSet.ToString() + "rpm, ";
                if (class8_u_1.IsVTEC) Infos += "Vtec(" + class8_u_1.VtcHigh.ToString() + "), ";
                Infos += class8_u_1.string_2;
                this.grid.Rows[this.grid.RowCount - 1].Cells[4].Value = Infos;
            }
            
            //Select first row
            this.grid.Rows[0].Selected = true;
        }
        
        ReloadOption();
    }

    private void method_4(object sender, EventArgs e)
    {
        this.pnlGrid.Visible = true;
        this.pnlMap.Visible = false;
    }

    private void method_5(int int_6, int int_7, int int_8)
    {
        this.int_1 = int_6;
        this.int_2 = int_7;
        this.int_3 = int_8;
    }

    private void method_6()
    {
        long num;
        long num2;
        long num3;
        long num4 = 0L;
        switch (this.lstGear.SelectedIndex)
        {
            case 0:
                num = 70L;
                num2 = 0x67L;
                num3 = 0x8eL;
                num4 = 0xb8L;
                break;

            case 1:
                num = 70L;
                num2 = 0x67L;
                num3 = 0x8eL;
                num4 = 0xb8L;
                break;

            case 2:
                num = 70L;
                num2 = 0x67L;
                num3 = 0x8eL;
                num4 = 0xb8L;
                break;

            case 3:
                num = 0x42L;
                num2 = 0x5dL;
                num3 = 0x87L;
                num4 = 0xb6L;
                break;

            case 4:
                num = 70L;
                num2 = 100L;
                num3 = 0x91L;
                num4 = 0xb8L;
                break;

            case 5:
                num = 0x48L;
                num2 = 0x71L;
                num3 = 170L;
                num4 = 0xe3L;
                break;

            case 6:
                num = 70L;
                num2 = 110L;
                num3 = 0x9aL;
                num4 = 0xc4L;
                break;

            case 7:
                num = 70L;
                num2 = 110L;
                num3 = 0x9aL;
                num4 = 0xc4L;
                break;

            case 8:
                num = 0x48L;
                num2 = 0x71L;
                num3 = 0xb2L;
                num4 = 0xd6L;
                break;

            case 9:
                num = 0x47L;
                num2 = 110L;
                num3 = 0x9eL;
                num4 = 0xc3L;
                break;

            case 10:
                num = 0x47L;
                num2 = 110L;
                num3 = 0x9eL;
                num4 = 0xc9L;
                break;

            case 11:
                num = 0x47L;
                num2 = 110L;
                num3 = 0x9eL;
                num4 = 0xc9L;
                break;

            case 12:
                num = 0x4aL;
                num2 = 0x7bL;
                num3 = 0xafL;
                num4 = 0xe0L;
                break;

            case 13:
                num = 0x4bL;
                num2 = 0x7dL;
                num3 = 0xbcL;
                num4 = 0xedL;
                break;

            default:
                num = 70L;
                num2 = 0x67L;
                num3 = 0x8eL;
                num4 = 0xb8L;
                this.class18_0.class17_0.frmMain_0.LogThis("Gear ratio error");
                break;
                //throw new Exception("Gear ratio error");
        }
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63, num);
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 2L, num2);
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 4L, num3);
        this.class18_0.method_151(this.class18_0.class13_u_0.long_63 + 6L, num4);
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_64, (byte) this.lstGear.SelectedIndex);
    }

    private void method_7()
    {
        bool flag = this.class18_0.class10_settings_0.bool_32;
        this.class18_0.class10_settings_0.bool_32 = false;

        this.class18_0.method_29(true);

        //Get Version to load
        int VersionI = int.Parse(this.class1_Version_0.Version.ToString());

        this.class18_0.OpenSilentBRom = true;
        this.class18_0.method_63(false, 100, this.txtName.Text);    //load V1.00 baserom
        this.class18_0.OpenSilentBRom = false;

        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            //Load Calibration tuned maps otherwise load normal maps  CalSelected
            if (CalSelected)
            {
                byte[] byte_99_0 = this.class18_0.method_93(this.class8_v_0.byte_0);
                this.class18_0.method_76(byte_99_0, true);

                //convert to choosen baserom
                this.class18_0.ConvertBaseromVersionToVersion(VersionI);

                this.class18_0.RomVersion = VersionI;
                this.class18_0.ResetBaseromParameters();
            }
            else
            {
                //Decrypt before Load
                //if (this.class8_u_0.IsCrypted) this.class8_u_0.byte_0 = this.class18_0.method_93(this.class8_u_0.byte_0);

                this.class18_0.ImportTableBytes(this.class8_u_0.byte_0);

                //convert to choosen baserom
                this.class18_0.ConvertBaseromVersionToVersion(VersionI);

                double num2 = 0.0;
                if ((this.class8_u_0.int_0 < 90) && !this.bool_0)
                {
                    num2 = 240.0 / ((double)this.class8_u_0.int_1);
                    if (this.class18_0.class13_u_0.long_41 != 0L) this.class18_0.method_51_SetOLDInjectorSize(this.class8_u_0.int_1);
                    if (this.class18_0.class13_u_0.long_39 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_39, (long)(((this.class8_u_0.int_3 + 100.0) / 100.0) * 32768.0));
                }
                else
                {
                    num2 = ((double)this.class8_u_0.int_1) / double.Parse(this.txtbInjecNew.Text);
                }
                this.class18_0.method_151(this.class18_0.class13_u_0.long_33, this.class18_0.method_229(num2));
                if (this.class18_0.class13_u_0.long_41 != 0L) this.class18_0.method_51_SetOLDInjectorSize(this.class8_u_0.int_2);
                if ((this.class8_u_0.int_0 < 90) && !this.bool_0)
                {
                    this.ctrlBatteryOffset_0.method_1((byte)this.class8_u_0.int_0);
                    this.byte_0 = (byte)this.class8_u_0.int_0;
                }
                for (int i = 0; i < 7; i++)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_185 + (i * 3), this.class18_0.method_209((float)this.ctrlBatteryOffset_0.method_3()[i]));
                    this.class18_0.method_151((this.class18_0.class13_u_0.long_185 + (i * 3)) + 1L, (long)((this.ctrlBatteryOffset_0.method_4()[i] * 1000.0) / 3.2));
                }
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_81, this.byte_0);
                if (this.class18_0.class13_u_0.long_39 != 0L)
                {
                    this.class18_0.method_151(this.class18_0.class13_u_0.long_39, this.class18_0.method_231(double.Parse(this.txtbOverall.Text), Enum6.const_0));
                }
                for (int j = 0; j < 0x18; j++)
                {
                    this.int_4[j] = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_6 + j));
                    this.int_5[j] = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_18 + j));
                }
                this.class18_0.method_151(this.class18_0.class13_u_0.long_0, (long)(this.int_1 + 0x8000));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_1, (long)(this.int_2 + 0x8000));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_2, (byte)this.int_3);
                for (int k = 0; k < 0x18; k++)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_6 + k, this.class18_0.method_226(this.int_4[k]));
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_18 + k, this.class18_0.method_226(this.int_5[k]));
                }
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_207, this.class18_0.method_226(750));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_53, this.class18_0.method_226(200));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_181, this.class18_0.method_226(0x406));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_127, this.class18_0.method_226(0xdac));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_128, this.class18_0.method_226(0xdac));
                if (this.class18_0.class13_u_0.long_227 != 0L)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_227, this.class18_0.method_226(100));
                }
                byte num7 = 0;
                byte num8 = 0;
                num7 = this.class18_0.method_226(0x400);
                num8 = 0xff;
                byte num6 = (byte)((num8 - num7) / 9);
                byte num9 = 0;
                double[] numArray = new double[10];
                for (int m = 0; m < 10; m++)
                {
                    numArray[m] = Math.Round((double)this.class18_0.method_245(this.class18_0.method_206(num7)), 0);
                    num7 = (byte)(num7 + num6);
                }
                for (int n = 0; n <= 10; n++)
                {
                    switch (n)
                    {
                        case 0:
                            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (n * 2), 0xff);
                            break;

                        case 10:
                            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (n * 2), 0);
                            break;

                        default:
                            num9 = this.class18_0.method_226(this.class18_0.method_250((float)numArray[9 - n]));
                            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (n * 2), num9);
                            break;
                    }
                }
                if (this.checkBox1.Checked)
                {
                    if (int.Parse(this.txtbCols.Text) < 5)
                    {
                        this.txtbCols.Text = "5";
                    }
                    if (int.Parse(this.txtbCols.Text) > 14)
                    {
                        this.txtbCols.Text = "14";
                    }
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, (byte)(10 + byte.Parse(this.txtbCols.Text)));
                    if (this.chkBoostCut.Checked)
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_131, 0xff);
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_126, 0xff);
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_127, this.class18_0.method_226(this.class18_0.method_250(float.Parse(this.txtbBoostcut.Text))));
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_128, this.class18_0.method_226(this.class18_0.method_250(float.Parse(this.txtbBoostcut.Text))));
                    }
                    float num12 = -1f;
                    float num13 = -1f;
                    float num14 = -1f;
                    float num15 = -1f;
                    int num16 = (this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1) - 10;
                    num12 = 2f;
                    num15 = this.class18_0.method_245(this.class18_0.method_206(0xff));
                    num13 = (num15 - num12) / ((float)num16);
                    for (int num17 = 10; num17 < this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber(); num17++)
                    {
                        if (num14 < 0f)
                        {
                            num14 = num12;
                        }
                        this.class18_0.method_171((byte)num17, this.class18_0.method_226(this.class18_0.method_250(num14)), SelectedTable.fuel1_hi);
                        this.class18_0.method_171((byte)num17, this.class18_0.method_226(this.class18_0.method_250(num14)), SelectedTable.fuel2_hi);
                        num14 += num13;
                    }
                    for (int num18 = this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber(); num18 < this.class18_0.method_33(); num18++)
                    {
                        this.class18_0.method_171((byte)num18, 0xff, SelectedTable.fuel1_hi);
                        this.class18_0.method_171((byte)num18, 0xff, SelectedTable.fuel2_hi);
                    }
                    this.method_8(SelectedTable.fuel1_hi);
                    this.method_8(SelectedTable.fuel1_lo);
                    this.method_8(SelectedTable.fuel2_hi);
                    this.method_8(SelectedTable.fuel2_lo);
                    this.method_9(SelectedTable.ign1_hi);
                    this.method_9(SelectedTable.ign1_lo);
                    this.method_9(SelectedTable.ign2_hi);
                    this.method_9(SelectedTable.ign2_lo);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, 10);
                }
                if (this.class1_u_0.bool_7)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_50, 0);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_234, 0);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_48, 0);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_51, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_47, 0);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_49, 0);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_80, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_206, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_31, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_218, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_223, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_225, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_224, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_220, 0xff);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_219, 0xff);

                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_103, 0xff);   //Purge

                    //disable Automatic B signal code #31
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413, 0x95);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413 + 1, 0xcb);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_413 + 2, 0x1d);

                    //disable JDM Traction code #36
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414, 0x95);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414 + 1, 0xcb);
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_414 + 2, 0x28);
                }
                else
                {
                    if (this.class1_u_0.IsBaro)
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_50, 0xff);
                    }
                    else
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_50, 0);
                    }
                    if (this.class1_u_0.IsELD)
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_48, 0xff);
                    }
                    else
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_48, 0);
                    }
                    if (this.class1_u_0.IsIAB)
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_234, 0xff);
                    }
                    else
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_234, 0);
                    }
                    if (this.class1_u_0.IsInjTest)
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_51, 0);
                    }
                    else
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_51, 0xff);
                    }
                    if (this.class1_u_0.IsKnock)
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_47, 0xff);
                    }
                    else
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_47, 0);
                    }
                    if (this.class1_u_0.IsO2H)
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_49, 0xff);
                    }
                    else
                    {
                        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_49, 0);
                    }
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_31, 0xff);
                }
                if (this.class8_u_0.IsVTEC)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_218, 0xff);
                }
                else
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_218, 0);
                }
                this.class18_0.method_151(this.class18_0.class13_u_0.long_52 + 6L, this.class18_0.method_219(this.class8_u_0.RpmLowSet));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_52, this.class18_0.method_219(this.class8_u_0.RpmLowReset));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_52 + 0x12L, this.class18_0.method_219(this.class8_u_0.RpmHighSet));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_52 + 12L, this.class18_0.method_219(this.class8_u_0.RpmHighReset));
                if (this.class8_u_0.IsVTEC)
                {
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_221 + 1L, this.class18_0.method_216(this.class8_u_0.VtcLow));
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_221 + 3L, this.class18_0.method_216(this.class8_u_0.VtcHigh));
                }


                this.class18_0.method_151(this.class18_0.class13_u_0.long_35, this.class18_0.method_231(double.Parse(this.txtbCrank.Text), Enum6.const_0));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_36, this.class18_0.method_231(double.Parse(this.txtbPostfuel.Text), Enum6.const_0));
                this.class18_0.method_151(this.class18_0.class13_u_0.long_38, this.class18_0.method_231(double.Parse(this.txtbTipin.Text), Enum6.const_0));
                if (this.class18_0.class13_u_0.long_39 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_39, this.class18_0.method_231(double.Parse(this.txtbOverall.Text), Enum6.const_0));

                ResetParameterToOEM();
            }

            this.method_6();
            this.class18_0.method_65();
            this.class18_0.method_29(false);
            this.class18_0.SetFileLoaded(true);
            this.class18_0.method_80();
            this.class18_0.class10_settings_0.bool_32 = flag;
        }
    }

    public void ResetParameterToOEM()
    {
        //Reset Version Byte just in case
        if (!this.class18_0.ConvertedToStable)
        {
            this.class18_0.method_149_SetByte(0x7fefL, byte.Parse(this.class1_Version_0.Version.ToString().Substring(0, 1)));
            this.class18_0.method_149_SetByte(0x7ff0L, byte.Parse(this.class1_Version_0.Version.ToString().Substring(1, 1)));
            this.class18_0.method_149_SetByte(0x7ff1L, byte.Parse(this.class1_Version_0.Version.ToString().Substring(2, 1)));
        }
        //####################################################
        /*if (!this.class18_0.ConvertedToStable)
        {
            this.class18_0.method_149_SetByte(0x7fefL, byte.Parse(this.class1_Version_0.Version.ToString().Substring(0, 1)));
            this.class18_0.method_149_SetByte(0x7ff0L, byte.Parse(this.class1_Version_0.Version.ToString().Substring(1, 1)));
            this.class18_0.method_149_SetByte(0x7ff1L, byte.Parse(this.class1_Version_0.Version.ToString().Substring(2, 1)));
        }*/
        //####################################################

        //Set BMTune Baserom Parameter just in case
        this.class18_0.GetRomVersion();
        this.class18_0.ResetBaseromParameters();

        //Reset parameters to default
        if (this.class18_0.class13_u_0.long_34 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_34, 0L); //Injector Deadtime (injector offset)
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_80, 0xff); //Alternator control disabled
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_72, 0); //Fuel Cut Active
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_71, 0); //Ignition Cut Disabled
        this.class18_0.method_151(this.class18_0.class13_u_0.long_241, 0L);   //Idle IACV Duty
        if (this.class18_0.class13_u_0.long_242 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_242, 0L); //Idle IACV AC Duty
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_243, 0);    //Do not disable IACV Error
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_105, 0xff); // Enable Fan Control Default

        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_144, this.class18_0.method_233(9)); //FTL under 9km/h
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_137, 0); //Disable FTL default
        this.class18_0.method_151(this.class18_0.class13_u_0.long_143, this.class18_0.method_219(4000)); //Set FTL to 4000rpm default
        this.class18_0.method_151(this.class18_0.class13_u_0.long_136, this.class18_0.method_219(0xfa0 - 9) - this.class18_0.method_219(0xfa0)); //Set FTL Cut delay to 9rpm
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_157, 0); //Disable FTL Antilag default
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_162, 0xff); //FTL Antilag Static by default
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_160, (byte)(float.Parse("-4") * 4f));   //FTL Antilag IGN to -4
        this.class18_0.method_151(this.class18_0.class13_u_0.long_159, (long)(float.Parse("15") * 4f));   //FTL Antilag Fuel to 15FV
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_163, this.class18_0.method_220(float.Parse("-4"))); //FTL Antilag IGN to -4

        if (this.class18_0.class13_u_0.long_151 != 0L) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_151, this.class18_0.method_228(75));  //FTS above TPS
        if (this.class18_0.RomVersion > 100) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_402, this.class18_0.method_233(9)); //Set FTS speed above
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_153, 0); //FTS set Fixed RPM
        if (this.class18_0.class13_u_0.long_150 != 0L) this.class18_0.method_151(this.class18_0.class13_u_0.long_150, this.class18_0.method_219(3500)); //Set FTS 3500rpm
        else this.class18_0.method_151(this.class18_0.class13_u_0.long_149, this.class18_0.method_219(3500)); //Set FTS 3500rpm
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_154, 0xff); //FTS Antilag Enabled
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_156, (byte)(float.Parse("45") * 4f));   //FTS igntion retard to 45
        this.class18_0.method_151(this.class18_0.class13_u_0.long_155, (long)(float.Parse("15") * 4f));   //FTS fuel to 15FV
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_147, 0); //Disable FTS default

        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_117, 0); //Disable Shiftlight by default
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_112, 0);            //Disable custom TPS by default
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113 + 2L, 0x18);    //Set TPS Value1 by default
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_113, 0xe8);         //Set TPS Value2 by default
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_58, (byte)(60));    //Set Fuel cut delay to 600ms
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_215, 0);            //Disable wideband by default

        //Wideband default setting (reset to narrowband)
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_208, this.class18_0.method_227(0.47f));
        this.class18_0.method_151(this.class18_0.class13_u_0.long_212, this.class18_0.method_231(47.0, Enum6.const_0));
        this.class18_0.method_151(this.class18_0.class13_u_0.long_211, this.class18_0.method_231(-30.0, Enum6.const_0));
        this.class18_0.method_151(this.class18_0.class13_u_0.long_37, this.class18_0.method_231(0, Enum6.const_0));

        //Set default idle setting
        this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (0 * 3)) + 1L, this.class18_0.method_219(1500));
        this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (0 * 3)) + 1L, this.class18_0.method_219(1550));
        this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (1 * 3)) + 1L, this.class18_0.method_219(1500));
        this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (1 * 3)) + 1L, this.class18_0.method_219(1550));
        this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (2 * 3)) + 1L, this.class18_0.method_219(1400));
        this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (2 * 3)) + 1L, this.class18_0.method_219(1450));
        this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (3 * 3)) + 1L, this.class18_0.method_219(1200));
        this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (3 * 3)) + 1L, this.class18_0.method_219(1300));
        this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (4 * 3)) + 1L, this.class18_0.method_219(1000));
        this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (4 * 3)) + 1L, this.class18_0.method_219(1100));
        this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (5 * 3)) + 1L, this.class18_0.method_219(850));
        this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (5 * 3)) + 1L, this.class18_0.method_219(1000));
        this.class18_0.method_151((this.class18_0.class13_u_0.long_245 + (6 * 3)) + 1L, this.class18_0.method_219(800));
        this.class18_0.method_151(((this.class18_0.class13_u_0.long_245 + 0x15L) + (6 * 3)) + 1L, this.class18_0.method_219(900));
        
        this.class18_0.method_151(this.class18_0.class13_u_0.long_244, this.class18_0.method_219(850));   //Set Target Idle
        
        this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_85, 0); //MIL Flashes

        if (this.class18_0.class15_0.string_CurrentID != null && this.class18_0.class15_0.string_CurrentID == this.class18_0.class15_0.BMIDDD) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_243, 0xff); //IACV Error

        if (this.class18_0.RomVersion >= 103 && this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_420) >= 100) this.class18_0.SetByteAt(this.class18_0.class13_u_0.long_420, 0x05);

        if (this.class18_0.RomVersion >= 109)
        {
            //if (GetByteAt(this.class13_u_0.long_420) >= 100) this.method_149_SetByte(this.class13_u_0.long_420, 0x05); //ign cut delay
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_421) >= 100) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_421, 0x05); //ign cut ftl delay
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_422) >= 100) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_422, 0x05); //ign cut fts delay
            if (this.class18_0.method_223(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_423)) >= 241) this.class18_0.method_151(this.class18_0.class13_u_0.long_423, (long)(100f * 4f)); //ign cut Enrichment 100FV
            if (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_424) >= 241) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_424, 0x00); //ign cut Retard
        }

        if (this.class18_0.RomVersion >= 111)
        {
            if (this.class18_0.class13_u_0.long_403 != 0xf005L) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_403, 0x00);   //ect code
            if (this.class18_0.class13_u_0.long_405 != 0xf001L) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_405, 0x00);   //iat code
            if (this.class18_0.class13_u_0.long_401 != 0xf006L) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_401, 0x00);   //vss code
        }
    }

    private void method_8(SelectedTable selectedTable_0)
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        float num4 = 0f;
        float num5 = float.Parse(this.txtbBoostFuel.Text) / 100f;
        double num6 = 0.0;
        while (this.class18_0.method_164((byte) num, selectedTable_0) <= (this.class18_0.class10_settings_0.int_6 + 40))
        {
            num++;
        }
        num2 = num - 1;
        num3 = num;
        for (int i = num3; i < this.class18_0.method_33(); i++)
        {
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                num4 = this.class18_0.method_175((byte) num2, (byte) j, selectedTable_0);
                num6 = this.class18_0.method_163((byte) i) - this.class18_0.method_163((byte) num2);
                num4 += (num4 * (((float) num6) / 1000f)) * num5;
                this.class18_0.method_177((byte) i, (byte) j, num4, selectedTable_0);
            }
        }
    }

    private void method_9(SelectedTable selectedTable_0)
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        float num4 = 0f;
        float num5 = float.Parse(this.txtbBoostRetard.Text);
        float num6 = 0f;
        while (this.class18_0.method_164((byte) num, selectedTable_0) <= (this.class18_0.class10_settings_0.int_6 + 40))
        {
            num++;
        }
        num2 = num - 1;
        num3 = num;
        for (int i = num3; i < this.class18_0.method_33(); i++)
        {
            num6 = this.class18_0.method_245(this.class18_0.method_164((byte) i, selectedTable_0));
            for (int j = 0; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                num4 = this.class18_0.method_175((byte) num2, (byte) j, selectedTable_0) - (num6 * num5);
                if (num4 < 0f)
                {
                    num4 = 0f;
                }
                this.class18_0.method_177((byte) i, (byte) j, num4, selectedTable_0);
            }
        }
    }

    private void rbNa_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.checkBox1.Checked)
        {
            this.txtbBoostcut.Enabled = false;
            this.txtbBoostFuel.Enabled = false;
            this.txtbBoostRetard.Enabled = false;
            this.txtbCols.Enabled = false;
            this.chkBoostCut.Enabled = false;
        }
        else
        {
            this.txtbBoostcut.Enabled = true;
            this.txtbBoostFuel.Enabled = true;
            this.txtbBoostRetard.Enabled = true;
            this.txtbCols.Enabled = true;
            this.chkBoostCut.Enabled = true;
        }
    }

    private void txtbBoostRetard_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbCols_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void ResetTrims()
    {
        //Reset Trims
        string txtbMultiplier = (float.Parse(this.textBox1.Text) / float.Parse(this.txtbInjecNew.Text)).ToString("0.000");
        if (txtbMultiplier != LastMultiplier)
        {
            if (MessageBox.Show(Form.ActiveForm, "Would you like BMTune to calculate base trim values for the TPS Tip-In and Cranking?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                int Trims = (int)((1 - (float.Parse(this.textBox1.Text) / float.Parse(this.txtbInjecNew.Text))) * 100);
                txtbCrank.Text = (-Trims).ToString();
                txtbTipin.Text = (-Trims).ToString();
            }
        }

        LastMultiplier = txtbMultiplier;
    }

    private void txtbInjecNew_TextChanged(object sender, EventArgs e)
    {
        this.bool_0 = true;
    }

    private void txtbInjecNew_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_257(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
            ResetTrims();
        }
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_257(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
            ResetTrims();
        }
    }

    private void checkBox8_CheckedChanged(object sender, EventArgs e)
    {
        this.textBox2.Enabled = checkBox8.Checked;
    }

    private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node != null)
        {
            IsPremade = true;
            IsInternet = false;
            CalIndex = e.Node.Index;
            CheckClass9Exist();
            this.txtName.Text = this.class9_baserom_0.class8_v_0[e.Node.Index].string_4;
            this.txtDesc.Text = this.class9_baserom_0.class8_v_0[e.Node.Index].string_2;
        }
    }

    private void treeView_DoubleClick(object sender, EventArgs e)
    {
        this.btnNext_Click(null, null);
    }

    private void grid_DoubleClick(object sender, EventArgs e)
    {
        this.btnNext_Click(null, null);
    }

    private void btnUpload_Click(object sender, EventArgs e)
    {

    }

    private void link_Changelog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        this.frmChangelog_0 = new frmChangelog(ref this.class18_0);
        DialogResult result = this.frmChangelog_0.ShowDialog();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        IsPremade = false;
        IsInternet = false;
        IsOBD0 = false;
        this.btnNext_Click(null, null);
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        IsPremade = true;
        IsInternet = false;
        IsOBD0 = false;
        this.panel1.Visible = false;
        this.treeView.Visible = true;
        this.btnPrev.Enabled = true;
    }

    private void ButtonStartInternet_Click(object sender, EventArgs e)
    {
        IsPremade = false;
        IsInternet = true;
        IsOBD0 = false;
        this.btnNext_Click(null, null);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        //this.FrmMain_0.OpenOBD0Menu();
        //base.Close();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        //this.FrmMain_0.OpenOBD2Menu();
        //base.Close();
    }
}

