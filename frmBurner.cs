//using PropertiesRes;
using System;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmBurner : Form
{
    public Button button1;
    private Button button2;
    private Class18 class18_0;
    private Class5_burn class5_burn_0;
    private IContainer icontainer_0;
    private int int_0;
    public ListBox ChipSelectBox;
    private ListBox listBox2;
    private Label label2;
    private Label label3;
    private GroupBox groupBox1;
    private Label label6;
    private CheckBox checkBox1;
    private Button button3;
    private Label label5;
    private Label label4;
    private Label label1;
    private ProgressBar progressBar1;
    public byte[] SecondBytes = new byte[] { };
    public bool Is2Timer = false;
    public bool Inverted = false;
    private OpenFileDialog openFileDialog1;
    private Button btnAlternative;
    private Label label7;
    private Label lblBinFilename;
    private bool IsLoading = true;
    private bool CustomFile = false;
    public TextBox txtAccess;
    public Label label10;
    private byte[] CustomBytes = new byte[] { };
    public Label label8;
    private Label label9;
    private Label label11;
    public int LastAccessTime = 20;

    public frmBurner()
    {
        this.InitializeComponent();

        lblBinFilename.Text = "";

    }

    private void button1_Click(object sender, EventArgs e)
    {
        //if (this.class18_0.class15_0.method_5(Enum4.const_4))
        //{
            if (this.int_0 == 1)
            {
                //Reset First Byte
                //this.class18_0.byte_0[0] = this.class18_0.StartByte;
                Is2Timer = false;
                bool CanGo = true;
                Inverted = checkBox1.Checked;
                if (this.listBox2.SelectedIndex == 2)
                {
                    if (label5.Text == "NO FILE SELECTED")
                    {
                        CanGo = false;
                        MessageBox.Show(Form.ActiveForm, "Error!\n2Timer don't have 2nd file selected!");
                    }
                    /*if (SecondBytes.Length < 0x8000)
                    {
                        CanGo = false;
                        MessageBox.Show(Form.ActiveForm, "Error!\n2Timer 2nd file are too short!");
                    }*/
                    Is2Timer = true;
                }
                if (CanGo)
                {
                    SetIndex();
                    this.button1.Enabled = false;
                    SetBytess();
                    this.class5_burn_0.method_16(this);
                }
            }
            else if (this.int_0 == 2)
            {
                this.button1.Enabled = false;
                SetBytess();
                this.class5_burn_0.method_17(this);
            }
            else if (this.int_0 == 3)
            {
                this.button1.Enabled = false;
                SetBytess();
                this.class5_burn_0.method_18(this, true);
            }
        //}
    }

    private void SetBytess()
    {
        int FSize = 32768;
        if (ChipSelectBox.SelectedIndex == 0 && this.listBox2.SelectedIndex == 2) FSize = FSize * 2;
        this.class5_burn_0.byte_ALL = new byte[FSize];

        //Set bytes at location #1
        for (int i = 0; i < 32768; i++)
        {
            if (ChipSelectBox.SelectedIndex == 0 && this.listBox2.SelectedIndex == 2)
            {
                if (!Inverted) this.class5_burn_0.byte_ALL[i] = this.SecondBytes[i];
                if (Inverted) this.class5_burn_0.byte_ALL[i] = GetBinFileByteAt(i);
                //if (Inverted) this.class5_burn_0.byte_ALL[i] = this.class18_0.GetByteAt(i);
            }
            else
            {
                this.class5_burn_0.byte_ALL[i] = this.class18_0.GetByteAt(i);
            }
        }
        //Set bytes at location #2
        if (ChipSelectBox.SelectedIndex == 0 && this.listBox2.SelectedIndex == 2)
        {
            for (int i = 0; i < 32768; i++)
            {
                if (Inverted) this.class5_burn_0.byte_ALL[i + 32768] = this.SecondBytes[i];
                if (!Inverted) this.class5_burn_0.byte_ALL[i + 32768] = GetBinFileByteAt(i);
                //if (!Inverted) this.class5_burn_0.byte_ALL[i + 32768] = this.class18_0.GetByteAt(i);
            }
        }
    }

    private byte GetBinFileByteAt(int Index)
    {
        if (!CustomFile) return this.class18_0.GetByteAt(Index);
        else return CustomBytes[Index];
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmBurner_Load(object sender, EventArgs e)
    {
        label5.Text = "NO FILE SELECTED";
        label1.Visible = (label5.Text == "NO FILE SELECTED");

        //if (this.class18_0.class15_0.method_5(Enum4.const_4))
        //{
        this.int_0 = int.Parse(base.Tag.ToString());
            if (this.int_0 == 1) this.button1.Text = "Write";
            else if (this.int_0 == 2) this.button1.Text = "Read";
            else if (this.int_0 == 3) this.button1.Text = "Verify";

            if (this.int_0 != 1)
            {
                label10.Visible = false;
                txtAccess.Visible = false;
                label8.Visible = false;
            }
            
            try
            {
                //int ChipIndex = Settings.Default.burnChipIndex;
                int ChipIndex = this.class18_0.class10_settings_0.burnChipIndex;
                int ChipBrand = 0;
                int ChipRegion = 1;
                bool Locked = false;

                if (ChipIndex == 0 || ChipIndex == 1 || ChipIndex == 6) ChipBrand = 0;
                if (ChipIndex == 1) ChipRegion = 0;
                if (ChipIndex == 6) ChipRegion = 2;

                if (ChipIndex == 2) { ChipBrand = 1; ChipRegion = 0; Locked = true; }
                if (ChipIndex == 3) { ChipBrand = 2; ChipRegion = 0; Locked = true; }

                if (ChipIndex == 4 | ChipIndex == 5) ChipBrand = 3;
                if (ChipIndex == 5) ChipRegion = 0;

                this.ChipSelectBox.SelectedIndex = ChipBrand;
                this.listBox2.SelectedIndex = ChipRegion;
                this.listBox2.Enabled = !Locked;

                Load2TimerBox();
            }
            catch
            {
                this.ChipSelectBox.SelectedIndex = 0;
                //Settings.Default.burnChipIndex = 0;
                this.class18_0.class10_settings_0.burnChipIndex = 0;
                this.listBox2.SelectedIndex = 1;
                this.listBox2.Enabled = true;
            }
        /*}
        else
        {
            base.Enabled = false;
            this.button1.Enabled = false;
            base.Close();
        }*/

        label6.Visible = checkBox1.Checked;

        IsLoading = false;
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBurner));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ChipSelectBox = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAlternative = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBinFilename = new System.Windows.Forms.Label();
            this.txtAccess = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(0, 325);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(517, 19);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(395, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Do";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(289, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ChipSelectBox
            // 
            this.ChipSelectBox.FormattingEnabled = true;
            this.ChipSelectBox.ItemHeight = 14;
            this.ChipSelectBox.Items.AddRange(new object[] {
            "SST27SF512",
            "SST27SF512 (Fake 70ns)",
            "SST27SF256",
            "W27C512 (Fake Winbond SST)",
            "W27E512",
            "AT29C256",
            "27C256(read only)",
            "27C512(read only)",
            "61256/61C256",
            "62256/62C256",
            "DS1230"});
            this.ChipSelectBox.Location = new System.Drawing.Point(14, 58);
            this.ChipSelectBox.Name = "ChipSelectBox";
            this.ChipSelectBox.Size = new System.Drawing.Size(243, 158);
            this.ChipSelectBox.TabIndex = 5;
            this.ChipSelectBox.SelectedIndexChanged += new System.EventHandler(this.lstChip_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Items.AddRange(new object[] {
            "0000-7FFF (32kb chip)",
            "8000-FFFF (64kb chip)",
            "0000-FFFF (2Timer on 64kb chip)"});
            this.listBox2.Location = new System.Drawing.Point(263, 58);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(243, 46);
            this.listBox2.TabIndex = 6;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.lstRegion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Chip Region:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Chip:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(263, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 150);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2Timer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(28, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "when using invert, this 2nd file\r\nare used when the 2Timer are OFF\r\n";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 89);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 18);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Invert Files Location";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(73, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 22);
            this.button3.TabIndex = 3;
            this.button3.Text = "Select File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the 2nd file for the 2Timer";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bin";
            this.openFileDialog1.Filter = "Binary File|*.bin";
            this.openFileDialog1.Title = "Open 2nd file for 2Timer";
            // 
            // btnAlternative
            // 
            this.btnAlternative.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAlternative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlternative.Location = new System.Drawing.Point(6, 5);
            this.btnAlternative.Name = "btnAlternative";
            this.btnAlternative.Size = new System.Drawing.Size(163, 25);
            this.btnAlternative.TabIndex = 11;
            this.btnAlternative.Text = "Load Alternative .bin File";
            this.btnAlternative.UseVisualStyleBackColor = true;
            this.btnAlternative.Click += new System.EventHandler(this.BtnAlternative_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "File:";
            // 
            // lblBinFilename
            // 
            this.lblBinFilename.AutoSize = true;
            this.lblBinFilename.Location = new System.Drawing.Point(212, 10);
            this.lblBinFilename.Name = "lblBinFilename";
            this.lblBinFilename.Size = new System.Drawing.Size(73, 14);
            this.lblBinFilename.TabIndex = 13;
            this.lblBinFilename.Text = "filename.bin";
            // 
            // txtAccess
            // 
            this.txtAccess.Location = new System.Drawing.Point(101, 220);
            this.txtAccess.Name = "txtAccess";
            this.txtAccess.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtAccess.Size = new System.Drawing.Size(31, 20);
            this.txtAccess.TabIndex = 15;
            this.txtAccess.Text = "20";
            this.txtAccess.Validated += new System.EventHandler(this.txtAccess_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 14);
            this.label10.TabIndex = 14;
            this.label10.Text = "Access Time:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "ns";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(16, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = "**ONLY with BMBurner V2++ : **";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(21, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 56);
            this.label11.TabIndex = 17;
            this.label11.Text = "-W27C512 (Fake Winbond SST)\r\n-W27E512\r\n-SST27SF256\r\n-SST27SF512 (Fake 70ns)";
            // 
            // frmBurner
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(517, 344);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAccess);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblBinFilename);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAlternative);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.ChipSelectBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBurner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Burner";
            this.Load += new System.EventHandler(this.frmBurner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void lstChip_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshSelectedChip();
    }

    void RefreshSelectedChip()
    {
        txtAccess.Text = "70";
        if (this.ChipSelectBox.Text == "SST27SF512") txtAccess.Text = "20";
        if (this.ChipSelectBox.Text == "W27E512") txtAccess.Text = "150";
        if (this.ChipSelectBox.Text == "DS1230") txtAccess.Text = "120";
        if (this.ChipSelectBox.Text == "61256/61C256") txtAccess.Text = "45";
        if (this.ChipSelectBox.Text == "62256/62C256") txtAccess.Text = "45";
        ChangeAccessTime();

        bool Locked = false;
        if (!Is512k())
        {
            this.class5_burn_0.method_1(true);      //chip index = 2
            if (this.ChipSelectBox.Text == "SST27SF256") this.class5_burn_0.method_1_SST256(true);
            this.listBox2.SelectedIndex = 0;  //select 256k region
            Locked = true;  //lock 2timer feature
        }
        else
        {
            this.class5_burn_0.method_1(false);     //chip index = 5
            this.listBox2.SelectedIndex = 1;  //select 512k region
        }

        //enable write
        if (!CanWrite() && (this.int_0 == 1)) this.button1.Enabled = false;
        else this.button1.Enabled = true;

        SetIndex();

        //2timer lock
        this.listBox2.Enabled = !Locked;
    }

    public bool Is512k()
    {
        if (this.ChipSelectBox.Text.Contains("512")) return true;
        return false;
    }

    public bool CanWrite()
    {
        if (!this.ChipSelectBox.Text.Contains("(read only)")) return true;
        return false;
    }

    public void SetIndex()
    {
        //if SST and 2Timer selected, switch to read last area
        if (Is512k() && this.listBox2.SelectedIndex == 2 && this.int_0 == 2)
        {
            Is2Timer = false;
            if (!IsLoading) MessageBox.Show(Form.ActiveForm, "You cannot read the full 2Timer area\nYou can't open 2x files on the same BMTune", "Burner Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.listBox2.SelectedIndex = 1;
        }

        if (!Is512k()) this.class5_burn_0.method_3(0L);
        else this.class5_burn_0.method_3(0x8000L);

        if (Is2Timer)
        {
            this.class5_burn_0.method_3(0L);
        }


        int ChipIndex = this.ChipSelectBox.SelectedIndex;
        int ChipRegion = this.listBox2.SelectedIndex;
        int BurnIndex = 0;
        if (ChipIndex == 0 && ChipRegion == 1) BurnIndex = 0;
        if (ChipIndex == 0 && ChipRegion == 0) BurnIndex = 1;
        if (ChipIndex == 1 && ChipRegion == 0) BurnIndex = 2;
        if (ChipIndex == 3 && ChipRegion == 0) BurnIndex = 3;
        if (ChipIndex == 4 && ChipRegion == 1) BurnIndex = 4;
        if (ChipIndex == 4 && ChipRegion == 0) BurnIndex = 5;
        if (ChipIndex == 0 && ChipRegion == 2) BurnIndex = 6;
        //Settings.Default.burnChipIndex = BurnIndex;
        this.class18_0.class10_settings_0.burnChipIndex = BurnIndex;

        Load2TimerBox();
    }

    void Load2TimerBox()
    {
        if (Is512k())
        {
            if (this.int_0 != 2)
            {
                if (this.listBox2.SelectedIndex == 2)
                {
                    this.groupBox1.Enabled = true;
                    //this.Size = new Size(287, 512);
                }
                else
                {
                    SetSmall();
                }
            }
            else
            {
                Is2Timer = false;
                this.listBox2.SelectedIndex = 1;
                SetSmall();
            }
        }
        else
        {
            this.listBox2.SelectedIndex = 0;
            SetSmall();
        }
    }

    void SetSmall()
    {
        this.groupBox1.Enabled = false;
        //this.Size = new Size(287, 357);
    }

    private void lstRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetIndex();
    }

    public void method_0(ref Class5_burn class5_1, ref Class18 class18_1)
    {
        this.class18_0 = class18_1;
        this.class5_burn_0 = class5_1;
        this.class5_burn_0.delegate8_0 += new Class5_burn.Delegate8(this.method_2);
        this.class5_burn_0.delegate9_0 += new Class5_burn.Delegate9(this.SetBurnerTitle);

        RefreshSelectedChip();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        if (this.class18_0.method_30_HasFileLoadedInBMTune()) this.lblBinFilename.Text = Path.GetFileName(this.class18_0.method_25_GetFilename());
    }

    private void SetBurnerTitle(string string_0)
    {
        this.Text = "Burner: " + string_0;
        if (string_0.Contains("Chip not verified") || string_0.Contains("Failed to read"))
        {
            this.button1.BackColor = this.class18_0.class10_settings_0.color_Off;
        }
        else if (string_0.Contains("Chip verified") || string_0.Contains("Succesfully read"))
        {
            this.button1.BackColor = this.class18_0.class10_settings_0.color_On;
        }
        else
        {
            this.button1.BackColor = SystemColors.Control;
        }
        this.Refresh();
    }

    private void method_2(int int_1)
    {
        this.progressBar1.Value = int_1;
        if (int_1 != 100)
        {
            this.button1.Enabled = false;
        }
        else
        {
            this.button1.Enabled = true;
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            byte[] BuffBytes = File.ReadAllBytes(openFileDialog1.FileName);
            if (BuffBytes.Length < 0x8000)
            {
                MessageBox.Show(Form.ActiveForm, "Error!\nSelected file are too short, this is not a 32kb file!");
            }
            else if (BuffBytes.Length > 0x8000)
            {
                if (MessageBox.Show(Form.ActiveForm, "Error!\nSelected file are too long, this is not a 32kb file!" + Environment.NewLine + "Only the first 32kb will be burn" + Environment.NewLine + "Do you want to continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    Set2Timer();
                }
            }
            else
            {
                Set2Timer();
            }
        }
    }

    private void Set2Timer()
    {
        this.label5.Text = Path.GetFileName(openFileDialog1.FileName);
        this.SecondBytes = File.ReadAllBytes(openFileDialog1.FileName);
        label1.Visible = (label5.Text == "NO FILE SELECTED");
    }

    private void BtnAlternative_Click(object sender, EventArgs e)
    {
        string BackupTitle = openFileDialog1.Title;
        openFileDialog1.Title = "Open any binary file";

        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            CustomBytes = File.ReadAllBytes(openFileDialog1.FileName);
            if (CustomBytes.Length < 0x8000)
            {
                MessageBox.Show(Form.ActiveForm, "Error!\nSelected file are too short, this is not a 32kb file!");
            }
            else if (CustomBytes.Length > 0x8000)
            {
                if (MessageBox.Show(Form.ActiveForm, "Error!\nSelected file are too long, this is not a 32kb file!" + Environment.NewLine + "Only the first 32kb will be burn" + Environment.NewLine + "Do you want to continue?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    SetCustom();
                }
            }
            else {
                SetCustom();
            }
        }

        openFileDialog1.Title = BackupTitle;
    }

    private void SetCustom()
    {

        CustomFile = true;
        this.lblBinFilename.Text = Path.GetFileName(openFileDialog1.FileName);
    }

    private void txtAccess_Validated(object sender, EventArgs e)
    {
        ChangeAccessTime();
    }

    private void ChangeAccessTime()
    {
        try
        {
            int AccT = int.Parse(txtAccess.Text);
            if (AccT > 0 && AccT < 255)
            {
                if (AccT != LastAccessTime)
                {
                    //Log_This("Changing AccessTime to: " + AccT + "ns");
                    //Serial.ChangeAccTime(AccT);
                    LastAccessTime = AccT;
                }
            }
            else
            {
                MessageBox.Show(Form.ActiveForm, "ERROR : AccessTime not correctly set");
            }
        }
        catch
        {
            MessageBox.Show(Form.ActiveForm, "ERROR : AccessTime not correctly set");
        }
    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        label6.Visible = checkBox1.Checked;
    }
}

