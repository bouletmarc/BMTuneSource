using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

internal class frmActiveDatalog : Form
{
    private Class18 class18_0;
    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    private IContainer components;
    private Panel panel1;
    public Button btnPreset2;
    public Button btnPreset1;
    public bool loading = true;
    private ListView listView1;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    public Button button3;
    private TextBox textBox1;
    private Label label1;
    private Label label2;
    public Button button5;
    public Button button4;
    public Button btnPreset4;
    private Label label3;
    public Button btnPreset3;
    private CheckBox checkBox1;
    private ColumnHeader columnHeader3;

    internal frmActiveDatalog()
    {
        this.InitializeComponent();

    }

    internal void method_0(ref Class18 class18_1, ref FrmMain frmMain_1)
    {
        this.class18_0 = class18_1;
        this.frmMain_0 = frmMain_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        //LoopTimer.Interval = 1000;
        //LoopTimer.Tick += DoThisAllTheTime;
        //LoopTimer.Start();
    }

    void SpawnThreadList()
    {
        loading = true;

        this.textBox1.Text = "";
        this.panel1.Size = new Size(342, 54);

        this.checkBox1.Checked = this.frmMain_0.class10_settings_0.DatalogThreadEnabled;

        this.btnPreset1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.btnPreset2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.btnPreset3.ForeColor = System.Drawing.SystemColors.ControlText;
        this.btnPreset4.ForeColor = System.Drawing.SystemColors.ControlText;
        if (this.frmMain_0.class10_settings_0.DatalogCurrentPreset == 1) this.btnPreset1.ForeColor = System.Drawing.Color.Red;
        if (this.frmMain_0.class10_settings_0.DatalogCurrentPreset == 2) this.btnPreset2.ForeColor = System.Drawing.Color.Red;
        if (this.frmMain_0.class10_settings_0.DatalogCurrentPreset == 3) this.btnPreset3.ForeColor = System.Drawing.Color.Red;
        if (this.frmMain_0.class10_settings_0.DatalogCurrentPreset == 4) this.btnPreset4.ForeColor = System.Drawing.Color.Red;

        this.listView1.Items.Clear();
        this.listView1.Items.Add("");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add("AFR Target");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add(this.frmMain_0.class10_settings_0.int_ActiveDatalog[0].ToString());

        this.listView1.Items.Add("");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add("Sensors Graph");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add(this.frmMain_0.class10_settings_0.int_ActiveDatalog[1].ToString());

        this.listView1.Items.Add("");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add("Sensors Data");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add(this.frmMain_0.class10_settings_0.int_ActiveDatalog[2].ToString());

        this.listView1.Items.Add("");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add("Sensors Gauges");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add(this.frmMain_0.class10_settings_0.int_ActiveDatalog[3].ToString());

        this.listView1.Items.Add("");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add("Tables Grid");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add(this.frmMain_0.class10_settings_0.int_ActiveDatalog[4].ToString());

        this.listView1.Items.Add("");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add("Live Plots");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add(this.frmMain_0.class10_settings_0.int_ActiveDatalog[5].ToString());

        this.listView1.Items.Add("");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add("Tracing");
        this.listView1.Items[this.listView1.Items.Count - 1].SubItems.Add(this.frmMain_0.class10_settings_0.int_ActiveDatalog[6].ToString());

        for (int i = 0; i < listView1.Items.Count; i++) this.listView1.Items[i].Checked = this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i];

        this.Invalidate();
        loading = false;
    }


    private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        if (!loading)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems.Count >= 3)
                {
                    if (listView1.Items[i].SubItems[1].Text == "AFR Target") this.frmMain_0.class10_settings_0.bool_ActiveDatalog[0] = listView1.Items[i].Checked;
                    if (listView1.Items[i].SubItems[1].Text == "Sensors Graph") this.frmMain_0.class10_settings_0.bool_ActiveDatalog[1] = listView1.Items[i].Checked;
                    if (listView1.Items[i].SubItems[1].Text == "Sensors Data") this.frmMain_0.class10_settings_0.bool_ActiveDatalog[2] = listView1.Items[i].Checked;
                    if (listView1.Items[i].SubItems[1].Text == "Sensors Gauges") this.frmMain_0.class10_settings_0.bool_ActiveDatalog[3] = listView1.Items[i].Checked;
                    if (listView1.Items[i].SubItems[1].Text == "Tables Grid") this.frmMain_0.class10_settings_0.bool_ActiveDatalog[4] = listView1.Items[i].Checked;
                    if (listView1.Items[i].SubItems[1].Text == "Live Plots") this.frmMain_0.class10_settings_0.bool_ActiveDatalog[5] = listView1.Items[i].Checked;
                    if (listView1.Items[i].SubItems[1].Text == "Tracing") this.frmMain_0.class10_settings_0.bool_ActiveDatalog[6] = listView1.Items[i].Checked;
                }
            }
        }
    }

    private void BtnPreset1_Click(object sender, EventArgs e)
    {
        int NewPreset = int.Parse(((Button)sender).Tag.ToString());
        int OldPreset = this.frmMain_0.class10_settings_0.DatalogCurrentPreset;

        if (NewPreset != OldPreset)
        {
            //Save The Preset to the buffer before loading the current preset from the buffer
            for (int i = 0; i < this.frmMain_0.class10_settings_0.int_ActiveDatalog.Length; i++)
            {
                if (OldPreset == 1)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset1[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset1[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog[i];
                }
                else if (OldPreset == 2)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset2[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset2[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog[i];
                }
                else if (OldPreset == 3)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset3[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset3[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog[i];
                }
                else if (OldPreset == 4)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset4[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset4[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog[i];
                }
            }

            //loading the current preset from the buffer
            this.frmMain_0.class10_settings_0.DatalogCurrentPreset = NewPreset;

            for (int i = 0; i < this.frmMain_0.class10_settings_0.int_ActiveDatalog.Length; i++)
            {
                if (NewPreset == 1)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset1[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset1[i];
                }
                else if (NewPreset == 2)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset2[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset2[i];
                }
                else if (NewPreset == 3)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset3[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset3[i];
                }
                else if (NewPreset == 4)
                {
                    this.frmMain_0.class10_settings_0.bool_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.bool_ActiveDatalog_Preset4[i];
                    this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog_Preset4[i];
                }
            }

            SpawnThreadList();
        }
    }

    private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.listView1.SelectedItems.Count > 0)
        {
            this.textBox1.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
            this.panel1.Size = new Size(342, 82);
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        //Apply/Set new refresh delay
        if (this.listView1.SelectedItems.Count > 0)
        {
            this.listView1.SelectedItems[0].SubItems[2].Text = this.textBox1.Text;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems.Count >= 3)
                {
                    if (listView1.Items[i].SubItems[1].Text == "AFR Target") this.frmMain_0.class10_settings_0.int_ActiveDatalog[0] = int.Parse(listView1.Items[i].SubItems[2].Text);
                    if (listView1.Items[i].SubItems[1].Text == "Sensors Graph") this.frmMain_0.class10_settings_0.int_ActiveDatalog[1] = int.Parse(listView1.Items[i].SubItems[2].Text);
                    if (listView1.Items[i].SubItems[1].Text == "Sensors Data") this.frmMain_0.class10_settings_0.int_ActiveDatalog[2] = int.Parse(listView1.Items[i].SubItems[2].Text);
                    if (listView1.Items[i].SubItems[1].Text == "Sensors Gauges") this.frmMain_0.class10_settings_0.int_ActiveDatalog[3] = int.Parse(listView1.Items[i].SubItems[2].Text);
                    if (listView1.Items[i].SubItems[1].Text == "Tables Grid") this.frmMain_0.class10_settings_0.int_ActiveDatalog[4] = int.Parse(listView1.Items[i].SubItems[2].Text);
                    if (listView1.Items[i].SubItems[1].Text == "Live Plots") this.frmMain_0.class10_settings_0.int_ActiveDatalog[5] = int.Parse(listView1.Items[i].SubItems[2].Text);
                    if (listView1.Items[i].SubItems[1].Text == "Tracing") this.frmMain_0.class10_settings_0.int_ActiveDatalog[6] = int.Parse(listView1.Items[i].SubItems[2].Text);
                }
            }

            SpawnThreadList();
        }
    }



    private void Button5_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.frmMain_0.class10_settings_0.int_ActiveDatalog.Length; i++)
        {
            this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] + 5;
        }

        SpawnThreadList();
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.frmMain_0.class10_settings_0.int_ActiveDatalog.Length; i++)
        {
            this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] = this.frmMain_0.class10_settings_0.int_ActiveDatalog[i] - 5;
        }

        SpawnThreadList();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmActiveDatalog_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.class18_0.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.ActiveDatalog_Location = base.Location;
        this.frmMain_0.frmActiveDatalog_0.Dispose();
        this.frmMain_0.frmActiveDatalog_0 = null;
    }

    private void frmActiveDatalog_Load(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.Dock = DockStyle.None;
                    base.Location = this.class18_0.class10_settings_0.ActiveDatalog_Location;
                    base.Size = this.class18_0.class10_settings_0.ActiveDatalog_Size;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Dock = DockStyle.Fill;
                }
            }
        }
        SpawnThreadList();
    }

    private void frmActiveDatalog_Resize(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode && !loading)
                {
                    if (base.WindowState == FormWindowState.Normal)
                    {
                        this.class18_0.class10_settings_0.ActiveDatalog_Size = base.Size;
                    }
                    this.class18_0.class10_settings_0.ActiveDatalog_Location = base.Location;
                }
            }
        }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActiveDatalog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnPreset4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPreset3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreset1 = new System.Windows.Forms.Button();
            this.btnPreset2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnPreset4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnPreset3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPreset1);
            this.panel1.Controls.Add(this.btnPreset2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 82);
            this.panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Enable DTL Threads";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnPreset4
            // 
            this.btnPreset4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreset4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPreset4.Location = new System.Drawing.Point(113, 26);
            this.btnPreset4.Name = "btnPreset4";
            this.btnPreset4.Size = new System.Drawing.Size(16, 23);
            this.btnPreset4.TabIndex = 10;
            this.btnPreset4.Tag = "4";
            this.btnPreset4.Text = "4";
            this.btnPreset4.UseVisualStyleBackColor = true;
            this.btnPreset4.Click += new System.EventHandler(this.BtnPreset1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Presets:";
            // 
            // btnPreset3
            // 
            this.btnPreset3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreset3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPreset3.Location = new System.Drawing.Point(94, 26);
            this.btnPreset3.Name = "btnPreset3";
            this.btnPreset3.Size = new System.Drawing.Size(16, 23);
            this.btnPreset3.TabIndex = 8;
            this.btnPreset3.Tag = "3";
            this.btnPreset3.Text = "3";
            this.btnPreset3.UseVisualStyleBackColor = true;
            this.btnPreset3.Click += new System.EventHandler(this.BtnPreset1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ms";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(188, 26);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(16, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(169, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(16, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(89, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(38, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Delay:";
            // 
            // btnPreset1
            // 
            this.btnPreset1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreset1.Location = new System.Drawing.Point(56, 26);
            this.btnPreset1.Name = "btnPreset1";
            this.btnPreset1.Size = new System.Drawing.Size(16, 23);
            this.btnPreset1.TabIndex = 1;
            this.btnPreset1.Tag = "1";
            this.btnPreset1.Text = "1";
            this.btnPreset1.UseVisualStyleBackColor = true;
            this.btnPreset1.Click += new System.EventHandler(this.BtnPreset1_Click);
            // 
            // btnPreset2
            // 
            this.btnPreset2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreset2.ForeColor = System.Drawing.Color.Red;
            this.btnPreset2.Location = new System.Drawing.Point(75, 26);
            this.btnPreset2.Name = "btnPreset2";
            this.btnPreset2.Size = new System.Drawing.Size(16, 23);
            this.btnPreset2.TabIndex = 0;
            this.btnPreset2.Tag = "2";
            this.btnPreset2.Text = "2";
            this.btnPreset2.UseVisualStyleBackColor = true;
            this.btnPreset2.Click += new System.EventHandler(this.BtnPreset1_Click);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 82);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(342, 218);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView1_ItemChecked);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 23;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Thread Name";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Refresh(ms)";
            this.columnHeader3.Width = 80;
            // 
            // frmActiveDatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 300);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmActiveDatalog";
            this.Text = "Active Datalog Threads";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmActiveDatalog_FormClosed);
            this.Load += new System.EventHandler(this.frmActiveDatalog_Load);
            this.Resize += new System.EventHandler(this.frmActiveDatalog_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (!loading)
        {
            this.frmMain_0.class10_settings_0.DatalogThreadEnabled = this.checkBox1.Checked;
            SpawnThreadList();
        }
    }
}

