using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmMapScalar : Form
{
    private Button btnApply;
    private Button button1;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private RadioButton rbDiv;
    private RadioButton rbIncr;
    private TextBox txtbDivCol;
    private TextBox txtbDivEnd;
    private TextBox txtbDivStart;
    private TextBox txtbIncrAmt;
    private TextBox txtbIncrCol;
    private IContainer components;
    private GroupBox groupBox4;
    private Label label19;
    private TextBox txtbAlphanTpsCross;
    private Label label20;
    private Label label21;
    private TextBox txtbAlphaMapCross;
    private Label label22;
    private TextBox txtbAlphaTpsColS;
    private Label label23;
    private GroupBox groupBox5;
    private Label label24;
    private TextBox txtbIncrStartTPS;
    private Label label25;
    private GroupBox groupBox3;
    private TextBox txtbIncrRow;
    private Label label26;
    private TextBox txtbDivEndRPM;
    private Label label27;
    private TextBox txtbDivStartRPM;
    private Label label28;
    private RadioButton rbDivRPM;
    private TextBox txtbDivRow;
    private Label label29;
    private TextBox txtbIncrAmtRPM;
    private Label label30;
    private TextBox txtbIncrStartRPM;
    private Label label31;
    private RadioButton rbIncrRPM;
    private Label label32;
    private ComboBox comboBox1;
    private Label label35;
    private GroupBox groupBox2;
    private Label label33;
    private TextBox txtbIncrColBoost;
    private Label label10;
    private Label label11;
    private TextBox txtbDivEndBoost;
    private Label label12;
    private Label label13;
    private TextBox txtbDivStartBoost;
    private Label label14;
    private RadioButton rbDivBoost;
    private TextBox txtbDivColBoost;
    private Label label15;
    private TextBox txtbIncrAmtBoost;
    private Label label16;
    private Label label17;
    private TextBox txtbIncrStartBoost;
    private Label label18;
    private RadioButton rbIncrBoost;
    private Label label34;
    private Label label36;
    private Label label37;
    private TextBox txtbIncrEndTPS;
    private TextBox txtbIncrStart;
    public bool IsLoading = false;

    public frmMapScalar()
    {
        IsLoading = true;
        this.InitializeComponent();

        this.Width = 258;
        this.Height = 332;

        comboBox1.SelectedIndex = 2;
        LoadRPM();

        IsLoading = false;
    }

    public void ApplyNA()
    {
        float num = -1f;
        float num2 = -1f;
        float num3 = -1f;
        int num5 = -1;

        string str;
        if (this.class18_0.method_39())
        {
            str = "Secondary Maps";
        }
        else
        {
            str = "Pimary Maps";
        }
        this.class18_0.method_156(str + " new map scalar", true);
        if (this.rbIncr.Checked)
        {
            if (int.Parse(this.txtbIncrCol.Text) > 0x18)
            {
                this.txtbIncrCol.Text = "24";
            }
            if (int.Parse(this.txtbIncrCol.Text) != 0)
            {
                num5 = int.Parse(this.txtbIncrCol.Text) - 1;
            }
            else
            {
                num5 = int.Parse(this.txtbIncrCol.Text);
            }
            num = float.Parse(this.txtbIncrStart.Text);
            num2 = float.Parse(this.txtbIncrAmt.Text);
            if (num <= num2)
            {
                num = num2;
            }
            for (int j = 0; j <= num5; j++)
            {
                if (num3 < 0f)
                {
                    num3 = num;
                }
                this.class18_0.method_173((byte)j, (int)num3);
                num3 += num2;
            }
        }
        else if (this.rbDiv.Checked)
        {
            if (int.Parse(this.txtbDivCol.Text) > 0x18)
            {
                this.txtbDivCol.Text = "24";
            }
            if (int.Parse(this.txtbDivCol.Text) != 0)
            {
                num5 = int.Parse(this.txtbDivCol.Text) - 1;
            }
            else
            {
                num5 = 10;
            }
            int num7 = num5;
            num = float.Parse(this.txtbDivStart.Text);
            num2 = (float.Parse(this.txtbDivEnd.Text) - num) / ((float)num7);
            num2 = (float)Math.Floor((double)num2);
            for (int k = 0; k <= num5; k++)
            {
                if (num3 < 0f)
                {
                    num3 = num;
                }
                this.class18_0.method_173((byte)k, (int)num3);
                num3 += num2;
            }
        }
        for (int i = num5; i < this.class18_0.method_33(); i++)
        {
            if (this.class18_0.method_39())
            {
                this.class18_0.method_171((byte)i, 0xff, SelectedTable.fuel1_hi);
            }
            else
            {
                this.class18_0.method_171((byte)i, 0xff, SelectedTable.fuel2_hi);
            }
        }
        int num10 = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_75);
        if (num10 < 10)
        {
            num10 = 10;
        }
        if ((num10 != num5) & (num5 != -1))
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_75, (byte)(num5 + 1));
        }
        this.class18_0.method_154();
        this.class18_0.method_53();
        if (num10 != num5)
        {
            this.class18_0.method_52();
        }
    }

    public void ApplyBoost()
    {
        float num = -1f;
        float num2 = -1f;
        float num3 = -1f;
        string str;
        if (this.class18_0.method_39())
        {
            str = "Secondary Maps";
        }
        else
        {
            str = "Pimary Maps";
        }
        this.class18_0.method_156(str + " new map scalar", true);
        if (this.rbIncrBoost.Checked)
        {
            int num5;
            if (int.Parse(this.txtbDivColBoost.Text) != 0)
            {
                num5 = int.Parse(this.txtbIncrColBoost.Text) - 1;
            }
            else
            {
                num5 = int.Parse(this.txtbIncrColBoost.Text);
            }
            num = float.Parse(this.txtbIncrStartBoost.Text);
            num2 = float.Parse(this.txtbIncrAmtBoost.Text);
            if (num <= num2)
            {
                num = num2;
            }
            for (int i = num5; i < this.class18_0.method_33(); i++)
            {
                if (num3 < 0f)
                {
                    num3 = num;
                }
                this.class18_0.method_173((byte)i, this.class18_0.method_250(num3));
                num3 += num2;
            }
        }
        else if (this.rbDivBoost.Checked)
        {
            int num8;
            if (int.Parse(this.txtbDivColBoost.Text) != 0)
            {
                num8 = int.Parse(this.txtbDivColBoost.Text) - 1;
            }
            else
            {
                num8 = int.Parse(this.txtbDivColBoost.Text);
            }
            int num7 = (this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1) - num8;
            num = float.Parse(this.txtbDivStartBoost.Text);
            num2 = (float.Parse(this.txtbDivEndBoost.Text) - num) / ((float)num7);
            for (int j = num8; j < this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber(); j++)
            {
                if (num3 < 0f)
                {
                    num3 = num;
                }
                this.class18_0.method_173((byte)j, this.class18_0.method_250(num3));
                num3 += num2;
            }
            for (int k = this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber(); k < this.class18_0.method_33(); k++)
            {
                if (this.class18_0.method_39())
                {
                    this.class18_0.method_171((byte)k, 0xff, SelectedTable.fuel1_hi);
                }
                else
                {
                    this.class18_0.method_171((byte)k, 0xff, SelectedTable.fuel2_hi);
                }
            }
        }
        this.class18_0.method_154();
        this.class18_0.method_53();
    }

    public void ApplyRPM()
    {
        float num = -1f;
        float num2 = -1f;
        float num3 = -1f;
        string str;
        if (this.class18_0.method_39())
        {
            str = "Secondary Maps";
        }
        else
        {
            str = "Pimary Maps";
        }
        this.class18_0.method_156(str + " new map scalar", true);

        if (this.rbIncrRPM.Checked)
        {
            int num5;
            if (int.Parse(this.txtbDivRow.Text) != 0)
            {
                num5 = int.Parse(this.txtbIncrRow.Text) - 1;
            }
            else
            {
                num5 = int.Parse(this.txtbIncrRow.Text);
            }
            num = float.Parse(this.txtbIncrStartRPM.Text);
            num2 = float.Parse(this.txtbIncrAmtRPM.Text);
            if (num <= num2)
            {
                num = num2;
            }
            for (int i = num5; i < this.class18_0.method_32_GetRPM_RowsNumber(); i++)
            {
                if (num3 < 0f)
                {
                    num3 = num;
                }
                this.class18_0.method_168((byte)i, (int)num3);
                num3 += num2;
            }
        }
        else if (this.rbDivRPM.Checked)
        {
            int num8;
            if (int.Parse(this.txtbDivRow.Text) != 0)
            {
                num8 = int.Parse(this.txtbDivRow.Text) - 1;
            }
            else
            {
                num8 = int.Parse(this.txtbDivRow.Text);
            }
            int num7 = (this.class18_0.method_32_GetRPM_RowsNumber() - 1) - num8;
            num = float.Parse(this.txtbDivStartRPM.Text);
            num2 = (float.Parse(this.txtbDivEndRPM.Text) - num) / ((float)num7);
            for (int j = num8; j < this.class18_0.method_32_GetRPM_RowsNumber(); j++)
            {
                if (num3 < 0f)
                {
                    num3 = num;
                }
                this.class18_0.method_168((byte)j, (int)num3);
                num3 += num2;
            }
        }
        this.class18_0.method_154();
        this.class18_0.method_53();
    }

    public void ApplyTPS()
    {
        int num = this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1;
        double num2 = 0.0;
        num2 = double.Parse(this.txtbIncrStartTPS.Text);
        double num4 = (double.Parse(this.txtbIncrEndTPS.Text) - num2) / ((double)num);
        double num5 = num2;
        this.class18_0.method_155("TPS scalar setup");
        for (int i = 0; i < this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber(); i++)
        {
            this.class18_0.method_171((byte)i, this.class18_0.method_228((int)num5), this.class18_0.method_4());
            num5 += num4;
        }
        this.class18_0.method_153();
        this.class18_0.method_53();
    }

    public void ApplyAlphaN()
    {
        if ((int.Parse(this.txtbAlphaTpsColS.Text) - 1) >= this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber())
        {
            MessageBox.Show(Form.ActiveForm, "TPS colum start should be less then map width");
        }
        else
        {
            this.class18_0.method_155("Alpha-N Scalar setup");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_371, this.class18_0.method_226(int.Parse(this.txtbAlphaMapCross.Text)));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_370, this.class18_0.method_228(int.Parse(this.txtbAlphanTpsCross.Text)));
            int num = int.Parse(this.txtbAlphaTpsColS.Text) - 1;
            int num2 = num;
            int num3 = this.class18_0.method_163(0);
            int num4 = int.Parse(this.txtbAlphaMapCross.Text);
            int num5 = -1;
            int num6 = (num4 - num3) / num2;
            for (int i = 0; i <= num2; i++)
            {
                if (num5 < 0)
                {
                    num5 = num3;
                }
                this.class18_0.method_173((byte)i, num5);
                num5 += num6;
            }
            num5 = -1;
            num2 = (this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1) - num;
            int num8 = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_373 + 1L));
            num6 = (num8 - num4) / num2;
            for (int j = num; j < this.class18_0.method_33(); j++)
            {
                if (num5 < 0)
                {
                    num5 = num4;
                }
                if (j == (this.class18_0.class10_settings_0.method_11_GetMAP_ColumnsNumber() - 1))
                {
                    num5 = num8;
                }
                this.class18_0.method_173((byte)j, num5);
                num5 += num6;
            }
            this.class18_0.method_153();
            this.class18_0.method_53();
        }
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 0) ApplyNA();
        else if (comboBox1.SelectedIndex == 1) ApplyBoost();
        else if (comboBox1.SelectedIndex == 2) ApplyRPM();
        else if (comboBox1.SelectedIndex == 3) ApplyAlphaN();
        else if (comboBox1.SelectedIndex == 4) ApplyTPS();
        
        base.DialogResult = DialogResult.OK;
        base.Close();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    public void LoadNA()
    {
        this.groupBox1.Visible = true;
        this.groupBox2.Visible = false;
        this.groupBox3.Visible = false;
        this.groupBox4.Visible = false;
        this.groupBox5.Visible = false;

        this.groupBox1.Location = new Point(3,38);

        this.rbDiv.Checked = true;
    }

    public void LoadBoost()
    {
        this.groupBox1.Visible = false;
        this.groupBox2.Visible = true;
        this.groupBox3.Visible = false;
        this.groupBox4.Visible = false;
        this.groupBox5.Visible = false;

        this.groupBox2.Location = new Point(3, 38);

        this.rbDivBoost.Checked = true;

        float num = this.class18_0.method_245(this.class18_0.method_206(0xff));
        if (float.Parse(this.txtbDivEndBoost.Text) > num)
        {
            this.txtbDivEndBoost.Text = num.ToString();
        }
    }

    public void LoadRPM()
    {
        this.groupBox1.Visible = false;
        this.groupBox2.Visible = false;
        this.groupBox3.Visible = true;
        this.groupBox4.Visible = false;
        this.groupBox5.Visible = false;

        this.groupBox3.Location = new Point(3, 38);

        this.rbDivRPM.Checked = true;
    }

    public void LoadTPS()
    {
        this.groupBox1.Visible = false;
        this.groupBox2.Visible = false;
        this.groupBox3.Visible = false;
        this.groupBox4.Visible = true;
        this.groupBox5.Visible = false;

        this.groupBox4.Location = new Point(3, 38);

        //this.groupBox1.Enabled = this.class18_0.method_42();
        //this.btnApply.Enabled = this.class18_0.method_42();
    }

    public void LoadAlphaN()
    {
        this.groupBox1.Visible = false;
        this.groupBox2.Visible = false;
        this.groupBox3.Visible = false;
        this.groupBox4.Visible = false;
        this.groupBox5.Visible = true;

        this.groupBox5.Location = new Point(3, 38);

        //this.groupBox1.Enabled = this.class18_0.method_265(new long[] { this.class18_0.class13_0.long_373, this.class18_0.class13_0.long_371, this.class18_0.class13_0.long_370 });
        this.txtbAlphanTpsCross.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_370)).ToString();
        this.txtbAlphaMapCross.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_371)).ToString();
    }

    private void frmMapScalarNa_Load(object sender, EventArgs e)
    {
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtbIncrCol = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbDivEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbDivStart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbDiv = new System.Windows.Forms.RadioButton();
            this.txtbDivCol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbIncrAmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbIncrStart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbIncr = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtbAlphanTpsCross = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtbAlphaMapCross = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtbAlphaTpsColS = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtbIncrEndTPS = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtbIncrStartTPS = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtbIncrRow = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtbDivEndRPM = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtbDivStartRPM = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.rbDivRPM = new System.Windows.Forms.RadioButton();
            this.txtbDivRow = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtbIncrAmtRPM = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtbIncrStartRPM = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.rbIncrRPM = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtbIncrColBoost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbDivEndBoost = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbDivStartBoost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbDivBoost = new System.Windows.Forms.RadioButton();
            this.txtbDivColBoost = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbIncrAmtBoost = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtbIncrStartBoost = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rbIncrBoost = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.txtbIncrCol);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtbDivEnd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbDivStart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rbDiv);
            this.groupBox1.Controls.Add(this.txtbDivCol);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbIncrAmt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtbIncrStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbIncr);
            this.groupBox1.Location = new System.Drawing.Point(3, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NA Scalar Setup:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(25, 87);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(103, 14);
            this.label32.TabIndex = 17;
            this.label32.Text = "Ending at column:";
            // 
            // txtbIncrCol
            // 
            this.txtbIncrCol.Enabled = false;
            this.txtbIncrCol.Location = new System.Drawing.Point(136, 84);
            this.txtbIncrCol.Name = "txtbIncrCol";
            this.txtbIncrCol.Size = new System.Drawing.Size(35, 20);
            this.txtbIncrCol.TabIndex = 7;
            this.txtbIncrCol.Text = "10";
            this.txtbIncrCol.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivCol_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ending at column:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "mBar";
            // 
            // txtbDivEnd
            // 
            this.txtbDivEnd.Enabled = false;
            this.txtbDivEnd.Location = new System.Drawing.Point(136, 169);
            this.txtbDivEnd.Name = "txtbDivEnd";
            this.txtbDivEnd.Size = new System.Drawing.Size(47, 20);
            this.txtbDivEnd.TabIndex = 9;
            this.txtbDivEnd.Text = "1039";
            this.txtbDivEnd.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivEnd_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "End pressure:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "mBar";
            // 
            // txtbDivStart
            // 
            this.txtbDivStart.Enabled = false;
            this.txtbDivStart.Location = new System.Drawing.Point(136, 147);
            this.txtbDivStart.Name = "txtbDivStart";
            this.txtbDivStart.Size = new System.Drawing.Size(47, 20);
            this.txtbDivStart.TabIndex = 8;
            this.txtbDivStart.Text = "100";
            this.txtbDivStart.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrStart_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Start pressure:";
            // 
            // rbDiv
            // 
            this.rbDiv.AutoSize = true;
            this.rbDiv.Location = new System.Drawing.Point(14, 128);
            this.rbDiv.Name = "rbDiv";
            this.rbDiv.Size = new System.Drawing.Size(144, 18);
            this.rbDiv.TabIndex = 2;
            this.rbDiv.TabStop = true;
            this.rbDiv.Text = "New NA Scalar(Divide)";
            this.rbDiv.UseVisualStyleBackColor = true;
            this.rbDiv.CheckedChanged += new System.EventHandler(this.rbDiv_CheckedChanged);
            // 
            // txtbDivCol
            // 
            this.txtbDivCol.Enabled = false;
            this.txtbDivCol.Location = new System.Drawing.Point(136, 191);
            this.txtbDivCol.Name = "txtbDivCol";
            this.txtbDivCol.Size = new System.Drawing.Size(37, 20);
            this.txtbDivCol.TabIndex = 10;
            this.txtbDivCol.Text = "10";
            this.txtbDivCol.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivCol_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "mBar";
            // 
            // txtbIncrAmt
            // 
            this.txtbIncrAmt.Enabled = false;
            this.txtbIncrAmt.Location = new System.Drawing.Point(136, 62);
            this.txtbIncrAmt.Name = "txtbIncrAmt";
            this.txtbIncrAmt.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrAmt.TabIndex = 6;
            this.txtbIncrAmt.Text = "0";
            this.txtbIncrAmt.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrStart_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Increase:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "mBar";
            // 
            // txtbIncrStart
            // 
            this.txtbIncrStart.Enabled = false;
            this.txtbIncrStart.Location = new System.Drawing.Point(136, 40);
            this.txtbIncrStart.Name = "txtbIncrStart";
            this.txtbIncrStart.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrStart.TabIndex = 5;
            this.txtbIncrStart.Text = "100";
            this.txtbIncrStart.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrStart_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start pressure:";
            // 
            // rbIncr
            // 
            this.rbIncr.AutoSize = true;
            this.rbIncr.Location = new System.Drawing.Point(14, 21);
            this.rbIncr.Name = "rbIncr";
            this.rbIncr.Size = new System.Drawing.Size(164, 18);
            this.rbIncr.TabIndex = 1;
            this.rbIncr.TabStop = true;
            this.rbIncr.Text = "New NA Scalar(Increment)";
            this.rbIncr.UseVisualStyleBackColor = true;
            this.rbIncr.CheckedChanged += new System.EventHandler(this.rbIncr_CheckedChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(21, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(146, 262);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(76, 25);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtbAlphanTpsCross);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txtbAlphaMapCross);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txtbAlphaTpsColS);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Location = new System.Drawing.Point(729, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 218);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Alpha-N Scalar Setup:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(198, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 14);
            this.label19.TabIndex = 31;
            this.label19.Text = "%";
            // 
            // txtbAlphanTpsCross
            // 
            this.txtbAlphanTpsCross.Location = new System.Drawing.Point(143, 49);
            this.txtbAlphanTpsCross.Name = "txtbAlphanTpsCross";
            this.txtbAlphanTpsCross.Size = new System.Drawing.Size(47, 20);
            this.txtbAlphanTpsCross.TabIndex = 3;
            this.txtbAlphanTpsCross.Text = "0";
            this.txtbAlphanTpsCross.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlphaMapCross_Validating);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 14);
            this.label20.TabIndex = 30;
            this.label20.Text = "Alpha-N Tps Cross:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(198, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 14);
            this.label21.TabIndex = 28;
            this.label21.Text = "mBar";
            // 
            // txtbAlphaMapCross
            // 
            this.txtbAlphaMapCross.Location = new System.Drawing.Point(143, 26);
            this.txtbAlphaMapCross.Name = "txtbAlphaMapCross";
            this.txtbAlphaMapCross.Size = new System.Drawing.Size(47, 20);
            this.txtbAlphaMapCross.TabIndex = 2;
            this.txtbAlphaMapCross.Text = "0";
            this.txtbAlphaMapCross.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlphaMapCross_Validating);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 14);
            this.label22.TabIndex = 25;
            this.label22.Text = "Alpha-N Map Cross:";
            // 
            // txtbAlphaTpsColS
            // 
            this.txtbAlphaTpsColS.Location = new System.Drawing.Point(159, 72);
            this.txtbAlphaTpsColS.Name = "txtbAlphaTpsColS";
            this.txtbAlphaTpsColS.Size = new System.Drawing.Size(31, 20);
            this.txtbAlphaTpsColS.TabIndex = 4;
            this.txtbAlphaTpsColS.Text = "5";
            this.txtbAlphaTpsColS.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlphaTpsColS_Validating);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 75);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(144, 14);
            this.label23.TabIndex = 18;
            this.label23.Text = "Alpha-N Tps start column:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Controls.Add(this.txtbIncrEndTPS);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.txtbIncrStartTPS);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Location = new System.Drawing.Point(971, 38);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(236, 218);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TPS Scalar Setup:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(50, 46);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(53, 14);
            this.label36.TabIndex = 11;
            this.label36.Text = "End Tps:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(173, 46);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(14, 14);
            this.label37.TabIndex = 13;
            this.label37.Text = "%";
            // 
            // txtbIncrEndTPS
            // 
            this.txtbIncrEndTPS.Location = new System.Drawing.Point(118, 43);
            this.txtbIncrEndTPS.Name = "txtbIncrEndTPS";
            this.txtbIncrEndTPS.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrEndTPS.TabIndex = 12;
            this.txtbIncrEndTPS.Text = "105";
            this.txtbIncrEndTPS.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrEnd_Validating);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(173, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 14);
            this.label24.TabIndex = 7;
            this.label24.Text = "%";
            // 
            // txtbIncrStartTPS
            // 
            this.txtbIncrStartTPS.Location = new System.Drawing.Point(118, 20);
            this.txtbIncrStartTPS.Name = "txtbIncrStartTPS";
            this.txtbIncrStartTPS.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrStartTPS.TabIndex = 6;
            this.txtbIncrStartTPS.Text = "-5";
            this.txtbIncrStartTPS.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrEnd_Validating);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(45, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 14);
            this.label25.TabIndex = 5;
            this.label25.Text = "Start Tps:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.txtbIncrRow);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.txtbDivEndRPM);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.txtbDivStartRPM);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.rbDivRPM);
            this.groupBox3.Controls.Add(this.txtbDivRow);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.txtbIncrAmtRPM);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.txtbIncrStartRPM);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.rbIncrRPM);
            this.groupBox3.Location = new System.Drawing.Point(487, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 218);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rpm Scalar Setup:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(22, 87);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 14);
            this.label34.TabIndex = 33;
            this.label34.Text = "Starting at row:";
            // 
            // txtbIncrRow
            // 
            this.txtbIncrRow.Enabled = false;
            this.txtbIncrRow.Location = new System.Drawing.Point(125, 84);
            this.txtbIncrRow.Name = "txtbIncrRow";
            this.txtbIncrRow.Size = new System.Drawing.Size(35, 20);
            this.txtbIncrRow.TabIndex = 6;
            this.txtbIncrRow.Text = "0";
            this.txtbIncrRow.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivRow_Validating);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(22, 194);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 14);
            this.label26.TabIndex = 32;
            this.label26.Text = "Starting at row:";
            // 
            // txtbDivEndRPM
            // 
            this.txtbDivEndRPM.Enabled = false;
            this.txtbDivEndRPM.Location = new System.Drawing.Point(125, 169);
            this.txtbDivEndRPM.Name = "txtbDivEndRPM";
            this.txtbDivEndRPM.Size = new System.Drawing.Size(47, 20);
            this.txtbDivEndRPM.TabIndex = 9;
            this.txtbDivEndRPM.Text = "0";
            this.txtbDivEndRPM.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrRPMStart_Validating);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(57, 172);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 14);
            this.label27.TabIndex = 29;
            this.label27.Text = "End rpm:";
            // 
            // txtbDivStartRPM
            // 
            this.txtbDivStartRPM.Enabled = false;
            this.txtbDivStartRPM.Location = new System.Drawing.Point(125, 147);
            this.txtbDivStartRPM.Name = "txtbDivStartRPM";
            this.txtbDivStartRPM.Size = new System.Drawing.Size(47, 20);
            this.txtbDivStartRPM.TabIndex = 8;
            this.txtbDivStartRPM.Text = "0";
            this.txtbDivStartRPM.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrRPMStart_Validating);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(52, 150);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 14);
            this.label28.TabIndex = 26;
            this.label28.Text = "Start rpm:";
            // 
            // rbDivRPM
            // 
            this.rbDivRPM.AutoSize = true;
            this.rbDivRPM.Location = new System.Drawing.Point(14, 128);
            this.rbDivRPM.Name = "rbDivRPM";
            this.rbDivRPM.Size = new System.Drawing.Size(152, 18);
            this.rbDivRPM.TabIndex = 7;
            this.rbDivRPM.TabStop = true;
            this.rbDivRPM.Text = "New Rpm Scalar(Divide)";
            this.rbDivRPM.UseVisualStyleBackColor = true;
            this.rbDivRPM.CheckedChanged += new System.EventHandler(this.rbDivRPM_CheckedChanged);
            // 
            // txtbDivRow
            // 
            this.txtbDivRow.Enabled = false;
            this.txtbDivRow.Location = new System.Drawing.Point(125, 191);
            this.txtbDivRow.Name = "txtbDivRow";
            this.txtbDivRow.Size = new System.Drawing.Size(37, 20);
            this.txtbDivRow.TabIndex = 10;
            this.txtbDivRow.Text = "1";
            this.txtbDivRow.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivRow_Validating);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(178, 65);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 14);
            this.label29.TabIndex = 23;
            this.label29.Text = "rpm";
            // 
            // txtbIncrAmtRPM
            // 
            this.txtbIncrAmtRPM.Enabled = false;
            this.txtbIncrAmtRPM.Location = new System.Drawing.Point(125, 62);
            this.txtbIncrAmtRPM.Name = "txtbIncrAmtRPM";
            this.txtbIncrAmtRPM.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrAmtRPM.TabIndex = 5;
            this.txtbIncrAmtRPM.Text = "0";
            this.txtbIncrAmtRPM.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrRPMStart_Validating);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(53, 65);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(57, 14);
            this.label30.TabIndex = 21;
            this.label30.Text = "Increase:";
            // 
            // txtbIncrStartRPM
            // 
            this.txtbIncrStartRPM.Enabled = false;
            this.txtbIncrStartRPM.Location = new System.Drawing.Point(125, 40);
            this.txtbIncrStartRPM.Name = "txtbIncrStartRPM";
            this.txtbIncrStartRPM.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrStartRPM.TabIndex = 4;
            this.txtbIncrStartRPM.Text = "0";
            this.txtbIncrStartRPM.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrRPMStart_Validating);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(52, 43);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(58, 14);
            this.label31.TabIndex = 18;
            this.label31.Text = "Start rpm:";
            // 
            // rbIncrRPM
            // 
            this.rbIncrRPM.AutoSize = true;
            this.rbIncrRPM.Location = new System.Drawing.Point(14, 21);
            this.rbIncrRPM.Name = "rbIncrRPM";
            this.rbIncrRPM.Size = new System.Drawing.Size(172, 18);
            this.rbIncrRPM.TabIndex = 3;
            this.rbIncrRPM.TabStop = true;
            this.rbIncrRPM.Text = "New Rpm Scalar(Increment)";
            this.rbIncrRPM.UseVisualStyleBackColor = true;
            this.rbIncrRPM.CheckedChanged += new System.EventHandler(this.rbIncrRPM_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.txtbIncrColBoost);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtbDivEndBoost);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtbDivStartBoost);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.rbDivBoost);
            this.groupBox2.Controls.Add(this.txtbDivColBoost);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtbIncrAmtBoost);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtbIncrStartBoost);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.rbIncrBoost);
            this.groupBox2.Location = new System.Drawing.Point(245, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 218);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Boost Scalar Setup:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(15, 87);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(108, 14);
            this.label33.TabIndex = 18;
            this.label33.Text = "Starting at column:";
            // 
            // txtbIncrColBoost
            // 
            this.txtbIncrColBoost.Enabled = false;
            this.txtbIncrColBoost.Location = new System.Drawing.Point(132, 84);
            this.txtbIncrColBoost.Name = "txtbIncrColBoost";
            this.txtbIncrColBoost.Size = new System.Drawing.Size(35, 20);
            this.txtbIncrColBoost.TabIndex = 7;
            this.txtbIncrColBoost.Text = "11";
            this.txtbIncrColBoost.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivBoostCol_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "Starting at column:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 14);
            this.label11.TabIndex = 15;
            this.label11.Text = "PSI";
            // 
            // txtbDivEndBoost
            // 
            this.txtbDivEndBoost.Enabled = false;
            this.txtbDivEndBoost.Location = new System.Drawing.Point(136, 169);
            this.txtbDivEndBoost.Name = "txtbDivEndBoost";
            this.txtbDivEndBoost.Size = new System.Drawing.Size(47, 20);
            this.txtbDivEndBoost.TabIndex = 9;
            this.txtbDivEndBoost.Text = "20";
            this.txtbDivEndBoost.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivBoostEnd_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "End pressure:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(191, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 14);
            this.label13.TabIndex = 12;
            this.label13.Text = "PSI";
            // 
            // txtbDivStartBoost
            // 
            this.txtbDivStartBoost.Enabled = false;
            this.txtbDivStartBoost.Location = new System.Drawing.Point(136, 147);
            this.txtbDivStartBoost.Name = "txtbDivStartBoost";
            this.txtbDivStartBoost.Size = new System.Drawing.Size(47, 20);
            this.txtbDivStartBoost.TabIndex = 8;
            this.txtbDivStartBoost.Text = "0";
            this.txtbDivStartBoost.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrBoostStart_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(37, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 14);
            this.label14.TabIndex = 10;
            this.label14.Text = "Start pressure:";
            // 
            // rbDivBoost
            // 
            this.rbDivBoost.AutoSize = true;
            this.rbDivBoost.Location = new System.Drawing.Point(14, 128);
            this.rbDivBoost.Name = "rbDivBoost";
            this.rbDivBoost.Size = new System.Drawing.Size(160, 18);
            this.rbDivBoost.TabIndex = 2;
            this.rbDivBoost.TabStop = true;
            this.rbDivBoost.Text = "New Boost Scalar(Divide)";
            this.rbDivBoost.UseVisualStyleBackColor = true;
            this.rbDivBoost.CheckedChanged += new System.EventHandler(this.rbDivBoost_CheckedChanged);
            // 
            // txtbDivColBoost
            // 
            this.txtbDivColBoost.Enabled = false;
            this.txtbDivColBoost.Location = new System.Drawing.Point(136, 191);
            this.txtbDivColBoost.Name = "txtbDivColBoost";
            this.txtbDivColBoost.Size = new System.Drawing.Size(37, 20);
            this.txtbDivColBoost.TabIndex = 10;
            this.txtbDivColBoost.Text = "11";
            this.txtbDivColBoost.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDivBoostCol_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(187, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 14);
            this.label15.TabIndex = 7;
            this.label15.Text = "PSI";
            // 
            // txtbIncrAmtBoost
            // 
            this.txtbIncrAmtBoost.Enabled = false;
            this.txtbIncrAmtBoost.Location = new System.Drawing.Point(132, 62);
            this.txtbIncrAmtBoost.Name = "txtbIncrAmtBoost";
            this.txtbIncrAmtBoost.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrAmtBoost.TabIndex = 6;
            this.txtbIncrAmtBoost.Text = "0";
            this.txtbIncrAmtBoost.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrBoostStart_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(66, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 14);
            this.label16.TabIndex = 5;
            this.label16.Text = "Increase:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(186, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 14);
            this.label17.TabIndex = 4;
            this.label17.Text = "PSI";
            // 
            // txtbIncrStartBoost
            // 
            this.txtbIncrStartBoost.Enabled = false;
            this.txtbIncrStartBoost.Location = new System.Drawing.Point(131, 40);
            this.txtbIncrStartBoost.Name = "txtbIncrStartBoost";
            this.txtbIncrStartBoost.Size = new System.Drawing.Size(47, 20);
            this.txtbIncrStartBoost.TabIndex = 5;
            this.txtbIncrStartBoost.Text = "0";
            this.txtbIncrStartBoost.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIncrBoostStart_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(37, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 14);
            this.label18.TabIndex = 2;
            this.label18.Text = "Start pressure:";
            // 
            // rbIncrBoost
            // 
            this.rbIncrBoost.AutoSize = true;
            this.rbIncrBoost.Location = new System.Drawing.Point(14, 21);
            this.rbIncrBoost.Name = "rbIncrBoost";
            this.rbIncrBoost.Size = new System.Drawing.Size(180, 18);
            this.rbIncrBoost.TabIndex = 1;
            this.rbIncrBoost.TabStop = true;
            this.rbIncrBoost.Text = "New Boost Scalar(Increment)";
            this.rbIncrBoost.UseVisualStyleBackColor = true;
            this.rbIncrBoost.CheckedChanged += new System.EventHandler(this.rbIncrBoost_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 12);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(76, 14);
            this.label35.TabIndex = 34;
            this.label35.Text = "Scalar Mode:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "NA",
            "Boost",
            "RPM",
            "Alpha-N",
            "TPS"});
            this.comboBox1.Location = new System.Drawing.Point(92, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 22);
            this.comboBox1.TabIndex = 35;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmMapScalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 293);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMapScalar";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scalar Setup";
            this.Load += new System.EventHandler(this.frmMapScalarNa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_0(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1(object sender, EventArgs e)
    {
        this.rbIncr.Checked = true;
    }

    private void method_2(object sender, EventArgs e)
    {
        this.rbDiv.Checked = true;
    }

    private void rbDiv_CheckedChanged(object sender, EventArgs e)
    {
        this.txtbDivCol.Enabled = this.rbDiv.Checked;
        this.txtbDivEnd.Enabled = this.rbDiv.Checked;
        this.txtbDivStart.Enabled = this.rbDiv.Checked;
    }

    private void rbIncr_CheckedChanged(object sender, EventArgs e)
    {
        this.txtbIncrAmt.Enabled = this.rbIncr.Checked;
        this.txtbIncrCol.Enabled = this.rbIncr.Checked;
        this.txtbIncrStart.Enabled = this.rbIncr.Checked;
    }

    private void txtbDivCol_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        int num = int.Parse(((TextBox) sender).Text);
        if (num < 1)
        {
            ((TextBox) sender).Text = "1";
        }
        else if (num > 0x18)
        {
            ((TextBox) sender).Text = "24";
        }
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbDivEnd_Validating(object sender, CancelEventArgs e)
    {
        float num = 1039f;
        if (float.Parse(((TextBox) sender).Text) > num)
        {
            ((TextBox) sender).Text = num.ToString();
        }
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbIncrStart_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbAlphaMapCross_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_255(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbAlphaTpsColS_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        int num = int.Parse(((TextBox)sender).Text);
        if (num < 1)
        {
            ((TextBox)sender).Text = "1";
        }
        else if (num > 0x18)
        {
            ((TextBox)sender).Text = "10";
        }
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void rbDivBoost_CheckedChanged(object sender, EventArgs e)
    {
        this.txtbDivColBoost.Enabled = this.rbDivBoost.Checked;
        this.txtbDivEndBoost.Enabled = this.rbDivBoost.Checked;
        this.txtbDivStartBoost.Enabled = this.rbDivBoost.Checked;
    }

    private void rbIncrBoost_CheckedChanged(object sender, EventArgs e)
    {
        this.txtbIncrAmtBoost.Enabled = this.rbIncrBoost.Checked;
        this.txtbIncrColBoost.Enabled = this.rbIncrBoost.Checked;
        this.txtbIncrStartBoost.Enabled = this.rbIncrBoost.Checked;
    }

    private void txtbDivBoostCol_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        int num = int.Parse(((TextBox)sender).Text);
        if (num < 1)
        {
            ((TextBox)sender).Text = "1";
        }
        else if (num > 0x18)
        {
            ((TextBox)sender).Text = "24";
        }
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbDivBoostEnd_Validating(object sender, CancelEventArgs e)
    {
        float num = this.class18_0.method_245(this.class18_0.method_206(0xff));
        if (float.Parse(((TextBox)sender).Text) > num)
        {
            ((TextBox)sender).Text = num.ToString();
        }
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbIncrBoostStart_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }



    private void rbDivRPM_CheckedChanged(object sender, EventArgs e)
    {
        this.txtbDivRow.Enabled = this.rbDivRPM.Checked;
        this.txtbDivEndRPM.Enabled = this.rbDivRPM.Checked;
        this.txtbDivStartRPM.Enabled = this.rbDivRPM.Checked;
    }

    private void rbIncrRPM_CheckedChanged(object sender, EventArgs e)
    {
        this.txtbIncrRow.Enabled = this.rbIncrRPM.Checked;
        this.txtbIncrAmtRPM.Enabled = this.rbIncrRPM.Checked;
        this.txtbIncrStartRPM.Enabled = this.rbIncrRPM.Checked;
    }

    private void txtbDivRow_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        int num = int.Parse(((TextBox)sender).Text);
        if (num < 1)
        {
            ((TextBox)sender).Text = "1";
        }
        else if (num > 0x18)
        {
            ((TextBox)sender).Text = "20";
        }
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbIncrRPMStart_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_254(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, int required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    

    private void txtbIncrEnd_Validating(object sender, CancelEventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
        this.alphanScalarMenuItem.Enabled = this.class18_0.method_41();
        this.tpsScalarToolStripItem.Enabled = this.class18_0.method_42();
        this.boostScalarToolStripMenuItem.Enabled = !this.class18_0.method_41() && !this.class18_0.method_42();
        this.nATablesToolStripMenuItem.Enabled = !this.class18_0.method_41() && !this.class18_0.method_42();*/

        if (!IsLoading)
        {
            IsLoading = true;
            if (comboBox1.SelectedIndex == 0)
            {
                if (!this.class18_0.method_41() && !this.class18_0.method_42()) LoadNA();
                else
                {
                    MessageBox.Show(Form.ActiveForm, "Can't change NA scalar", "BMTune");
                    comboBox1.SelectedIndex = 2;
                    LoadRPM();
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                if (!this.class18_0.method_41() && !this.class18_0.method_42()) LoadBoost();
                else
                {
                    MessageBox.Show(Form.ActiveForm, "Can't change Boost scalar", "BMTune");
                    comboBox1.SelectedIndex = 2;
                    LoadRPM();
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                LoadRPM();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                if (this.class18_0.method_41()) LoadAlphaN();
                else
                {
                    MessageBox.Show(Form.ActiveForm, "Can't change Alpha-N scalar", "BMTune");
                    comboBox1.SelectedIndex = 2;
                    LoadRPM();
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                if (this.class18_0.method_42()) LoadTPS();
                else
                {
                    MessageBox.Show(Form.ActiveForm, "Can't change TPS scalar", "BMTune");
                    comboBox1.SelectedIndex = 2;
                    LoadRPM();
                }
            }

            IsLoading = false;
        }
    }
}

