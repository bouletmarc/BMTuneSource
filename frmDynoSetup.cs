using Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

internal class frmDynoSetup : Form
{
    private Label labelDLCom;
    public ComboBox comboBoxDLCOM;
    private Label label1;
    private Label label2;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label10;
    private ComboBox comboBox1;
    private ComboBox comboBox2;
    private ComboBox comboBox3;
    private MaskedTextBox maskedTextBox1;
    private MaskedTextBox maskedTextBox4;
    private MaskedTextBox maskedTextBox5;
    private MaskedTextBox maskedTextBox6;
    private MaskedTextBox maskedTextBox7;
    private MaskedTextBox maskedTextBox8;
    private MaskedTextBox maskedTextBox9;
    private MaskedTextBox maskedTextBox10;
    private MaskedTextBox maskedTextBox11;
    private MaskedTextBox maskedTextBox12;
    private MaskedTextBox maskedTextBox13;
    private MaskedTextBox maskedTextBox14;
    private Label label8;
    private Label label9;
    private Label label11;
    private Label label12;
    private Class10_settings class10_settings_0;
    private Button buttonRefreshDLCom;
    public static bool Dyno_Connected;

    public frmDynoSetup(ref Class10_settings class10_1)
    {
        this.InitializeComponent();

        class10_settings_0 = class10_1;
        this.RefreshPorts();
        this.comboBoxDLCOM.Text = class10_settings_0.Dyno_COMPORTDyno;
        this.comboBox1.Text = class10_settings_0.Dyno_AUX1Type;
        this.comboBox2.Text = class10_settings_0.Dyno_AUX2Type;
        this.comboBox3.Text = class10_settings_0.Dyno_AUX3Type;
        this.maskedTextBox1.Text = class10_settings_0.Dyno_AUXMIN1V;
        this.maskedTextBox7.Text = class10_settings_0.Dyno_AUXMIN2V;
        this.maskedTextBox11.Text = class10_settings_0.Dyno_AUXMIN3V;
        this.maskedTextBox4.Text = class10_settings_0.Dyno_AUXMAX1V;
        this.maskedTextBox8.Text = class10_settings_0.Dyno_AUXMAX2V;
        this.maskedTextBox12.Text = class10_settings_0.Dyno_AUXMAX3V;
        this.maskedTextBox5.Text = class10_settings_0.Dyno_AUXMIN1O;
        this.maskedTextBox9.Text = class10_settings_0.Dyno_AUXMIN2O;
        this.maskedTextBox13.Text = class10_settings_0.Dyno_AUXMIN3O;
        this.maskedTextBox6.Text = class10_settings_0.Dyno_AUXMAX1O;
        this.maskedTextBox10.Text = class10_settings_0.Dyno_AUXMAX2O;
        this.maskedTextBox14.Text = class10_settings_0.Dyno_AUXMAX3O;

        /*foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }*/
    }

    private void AUX1Change(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUX1Type = this.comboBox1.Text;
    }

    private void AUX2Change(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUX2Type = this.comboBox2.Text;
    }

    private void AUX3Change(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUX3Type = this.comboBox3.Text;
    }

    private void AUXMAX1O(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMAX1O = this.maskedTextBox6.Text;
    }

    private void AUXMAX1V(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMAX1V = this.maskedTextBox4.Text;
    }

    private void AUXMAX2O(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMAX2O = this.maskedTextBox10.Text;
    }

    private void AUXMAX2V(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMAX2V = this.maskedTextBox8.Text;
    }

    private void AUXMAX3O(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMAX3O = this.maskedTextBox14.Text;
    }

    private void AUXMAX3V(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMAX3V = this.maskedTextBox12.Text;
    }

    private void AUXMIN1O(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMIN1O = this.maskedTextBox5.Text;
    }

    private void AUXMIN1V(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMIN1V = this.maskedTextBox1.Text;
    }

    private void AUXMIN2O(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMIN2O = this.maskedTextBox9.Text;
    }

    private void AUXMIN2V(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMIN2V = this.maskedTextBox7.Text;
    }

    private void AUXMIN3O(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMIN3O = this.maskedTextBox13.Text;
    }

    private void AUXMIN3V(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_AUXMIN3V = this.maskedTextBox11.Text;
    }

    private void ButtonRefreshDLCom_Click(object sender, EventArgs e)
    {
        this.RefreshPorts();
    }

    private void ChangeCOMPort(object sender, EventArgs e)
    {
        class10_settings_0.Dyno_COMPort = this.comboBoxDLCOM.Text;
        class10_settings_0.Dyno_COMPORTDyno = class10_settings_0.Dyno_COMPort;
    }

    private void FrmDyno_Load(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDynoSetup));
        this.maskedTextBox14 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox13 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox12 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox11 = new System.Windows.Forms.MaskedTextBox();
        this.label10 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.maskedTextBox7 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox8 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox9 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox10 = new System.Windows.Forms.MaskedTextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.label7 = new System.Windows.Forms.Label();
        this.comboBox2 = new System.Windows.Forms.ComboBox();
        this.label6 = new System.Windows.Forms.Label();
        this.comboBox3 = new System.Windows.Forms.ComboBox();
        this.label11 = new System.Windows.Forms.Label();
        this.label12 = new System.Windows.Forms.Label();
        this.labelDLCom = new System.Windows.Forms.Label();
        this.comboBoxDLCOM = new System.Windows.Forms.ComboBox();
        this.buttonRefreshDLCom = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // maskedTextBox14
        // 
        this.maskedTextBox14.Location = new System.Drawing.Point(322, 241);
        this.maskedTextBox14.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox14.Mask = "0000";
        this.maskedTextBox14.Name = "maskedTextBox14";
        this.maskedTextBox14.Size = new System.Drawing.Size(78, 20);
        this.maskedTextBox14.TabIndex = 30;
        this.maskedTextBox14.Text = "100";
        this.maskedTextBox14.TextChanged += new System.EventHandler(this.AUXMAX3O);
        // 
        // maskedTextBox13
        // 
        this.maskedTextBox13.Location = new System.Drawing.Point(243, 241);
        this.maskedTextBox13.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox13.Mask = "0000";
        this.maskedTextBox13.Name = "maskedTextBox13";
        this.maskedTextBox13.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox13.TabIndex = 29;
        this.maskedTextBox13.Text = "0";
        this.maskedTextBox13.TextChanged += new System.EventHandler(this.AUXMIN3O);
        // 
        // maskedTextBox12
        // 
        this.maskedTextBox12.Location = new System.Drawing.Point(164, 241);
        this.maskedTextBox12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox12.Mask = "0.00";
        this.maskedTextBox12.Name = "maskedTextBox12";
        this.maskedTextBox12.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox12.TabIndex = 28;
        this.maskedTextBox12.Text = "500";
        this.maskedTextBox12.TextChanged += new System.EventHandler(this.AUXMAX3V);
        // 
        // maskedTextBox11
        // 
        this.maskedTextBox11.Location = new System.Drawing.Point(85, 241);
        this.maskedTextBox11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox11.Mask = "0.00";
        this.maskedTextBox11.Name = "maskedTextBox11";
        this.maskedTextBox11.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox11.TabIndex = 27;
        this.maskedTextBox11.Text = "000";
        this.maskedTextBox11.TextChanged += new System.EventHandler(this.AUXMIN3V);
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(11, 244);
        this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(61, 13);
        this.label10.TabIndex = 13;
        this.label10.Text = "Aux3 Scale";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(11, 219);
        this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(61, 13);
        this.label5.TabIndex = 12;
        this.label5.Text = "Aux2 Scale";
        // 
        // maskedTextBox7
        // 
        this.maskedTextBox7.Location = new System.Drawing.Point(85, 217);
        this.maskedTextBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox7.Mask = "0.00";
        this.maskedTextBox7.Name = "maskedTextBox7";
        this.maskedTextBox7.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox7.TabIndex = 23;
        this.maskedTextBox7.Text = "000";
        this.maskedTextBox7.TextChanged += new System.EventHandler(this.AUXMIN2V);
        // 
        // maskedTextBox8
        // 
        this.maskedTextBox8.Location = new System.Drawing.Point(164, 217);
        this.maskedTextBox8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox8.Mask = "0.00";
        this.maskedTextBox8.Name = "maskedTextBox8";
        this.maskedTextBox8.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox8.TabIndex = 24;
        this.maskedTextBox8.Text = "500";
        this.maskedTextBox8.TextChanged += new System.EventHandler(this.AUXMAX2V);
        // 
        // maskedTextBox9
        // 
        this.maskedTextBox9.Location = new System.Drawing.Point(243, 217);
        this.maskedTextBox9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox9.Mask = "0000";
        this.maskedTextBox9.Name = "maskedTextBox9";
        this.maskedTextBox9.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox9.TabIndex = 25;
        this.maskedTextBox9.Text = "0";
        this.maskedTextBox9.TextChanged += new System.EventHandler(this.AUXMIN2O);
        // 
        // maskedTextBox10
        // 
        this.maskedTextBox10.Location = new System.Drawing.Point(322, 217);
        this.maskedTextBox10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox10.Mask = "0000";
        this.maskedTextBox10.Name = "maskedTextBox10";
        this.maskedTextBox10.Size = new System.Drawing.Size(78, 20);
        this.maskedTextBox10.TabIndex = 26;
        this.maskedTextBox10.Text = "100";
        this.maskedTextBox10.TextChanged += new System.EventHandler(this.AUXMAX2O);
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(11, 196);
        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(61, 13);
        this.label2.TabIndex = 4;
        this.label2.Text = "Aux1 Scale";
        // 
        // maskedTextBox1
        // 
        this.maskedTextBox1.Location = new System.Drawing.Point(85, 193);
        this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox1.Mask = "0.00";
        this.maskedTextBox1.Name = "maskedTextBox1";
        this.maskedTextBox1.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox1.TabIndex = 19;
        this.maskedTextBox1.Text = "000";
        this.maskedTextBox1.TextChanged += new System.EventHandler(this.AUXMIN1V);
        // 
        // maskedTextBox4
        // 
        this.maskedTextBox4.Location = new System.Drawing.Point(164, 193);
        this.maskedTextBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox4.Mask = "0.00";
        this.maskedTextBox4.Name = "maskedTextBox4";
        this.maskedTextBox4.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox4.TabIndex = 20;
        this.maskedTextBox4.Text = "500";
        this.maskedTextBox4.TextChanged += new System.EventHandler(this.AUXMAX1V);
        // 
        // maskedTextBox5
        // 
        this.maskedTextBox5.Location = new System.Drawing.Point(243, 193);
        this.maskedTextBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox5.Mask = "0000";
        this.maskedTextBox5.Name = "maskedTextBox5";
        this.maskedTextBox5.Size = new System.Drawing.Size(75, 20);
        this.maskedTextBox5.TabIndex = 21;
        this.maskedTextBox5.Text = "10";
        this.maskedTextBox5.TextChanged += new System.EventHandler(this.AUXMIN1O);
        // 
        // maskedTextBox6
        // 
        this.maskedTextBox6.Location = new System.Drawing.Point(322, 193);
        this.maskedTextBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox6.Mask = "0000";
        this.maskedTextBox6.Name = "maskedTextBox6";
        this.maskedTextBox6.Size = new System.Drawing.Size(78, 20);
        this.maskedTextBox6.TabIndex = 22;
        this.maskedTextBox6.Text = "20";
        this.maskedTextBox6.TextChanged += new System.EventHandler(this.AUXMAX1O);
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(126, 178);
        this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(34, 13);
        this.label8.TabIndex = 31;
        this.label8.Text = "Min V";
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(202, 178);
        this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(37, 13);
        this.label9.TabIndex = 32;
        this.label9.Text = "Max V";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(95, 94);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(61, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Aux1 Type:";
        // 
        // comboBox1
        // 
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Items.AddRange(new object[] {
        "Voltage",
        "AFR",
        "MAP",
        "Percent"});
        this.comboBox1.Location = new System.Drawing.Point(175, 90);
        this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(129, 21);
        this.comboBox1.TabIndex = 15;
        this.comboBox1.Text = "AFR";
        this.comboBox1.TextChanged += new System.EventHandler(this.AUX1Change);
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(95, 119);
        this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(61, 13);
        this.label7.TabIndex = 6;
        this.label7.Text = "Aux2 Type:";
        // 
        // comboBox2
        // 
        this.comboBox2.FormattingEnabled = true;
        this.comboBox2.Items.AddRange(new object[] {
        "Voltage",
        "AFR",
        "MAP",
        "Percent"});
        this.comboBox2.Location = new System.Drawing.Point(175, 115);
        this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.comboBox2.Name = "comboBox2";
        this.comboBox2.Size = new System.Drawing.Size(129, 21);
        this.comboBox2.TabIndex = 16;
        this.comboBox2.Text = "Voltage";
        this.comboBox2.TextChanged += new System.EventHandler(this.AUX2Change);
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(95, 144);
        this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(61, 13);
        this.label6.TabIndex = 8;
        this.label6.Text = "Aux3 Type:";
        // 
        // comboBox3
        // 
        this.comboBox3.FormattingEnabled = true;
        this.comboBox3.Items.AddRange(new object[] {
        "Voltage",
        "AFR",
        "MAP",
        "Percent"});
        this.comboBox3.Location = new System.Drawing.Point(175, 140);
        this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.comboBox3.Name = "comboBox3";
        this.comboBox3.Size = new System.Drawing.Size(129, 21);
        this.comboBox3.TabIndex = 17;
        this.comboBox3.Text = "Voltage";
        this.comboBox3.TextChanged += new System.EventHandler(this.AUX3Change);
        // 
        // label11
        // 
        this.label11.AutoSize = true;
        this.label11.Location = new System.Drawing.Point(259, 178);
        this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(59, 13);
        this.label11.TabIndex = 33;
        this.label11.Text = "Min Output";
        // 
        // label12
        // 
        this.label12.AutoSize = true;
        this.label12.Location = new System.Drawing.Point(338, 178);
        this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(62, 13);
        this.label12.TabIndex = 34;
        this.label12.Text = "Max Output";
        // 
        // labelDLCom
        // 
        this.labelDLCom.AutoSize = true;
        this.labelDLCom.Location = new System.Drawing.Point(95, 16);
        this.labelDLCom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.labelDLCom.Name = "labelDLCom";
        this.labelDLCom.Size = new System.Drawing.Size(56, 13);
        this.labelDLCom.TabIndex = 0;
        this.labelDLCom.Text = "COM Port:";
        // 
        // comboBoxDLCOM
        // 
        this.comboBoxDLCOM.FormattingEnabled = true;
        this.comboBoxDLCOM.Location = new System.Drawing.Point(175, 13);
        this.comboBoxDLCOM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.comboBoxDLCOM.Name = "comboBoxDLCOM";
        this.comboBoxDLCOM.Size = new System.Drawing.Size(129, 21);
        this.comboBoxDLCOM.TabIndex = 1;
        this.comboBoxDLCOM.TextChanged += new System.EventHandler(this.ChangeCOMPort);
        // 
        // buttonRefreshDLCom
        // 
        this.buttonRefreshDLCom.Location = new System.Drawing.Point(135, 42);
        this.buttonRefreshDLCom.Margin = new System.Windows.Forms.Padding(2);
        this.buttonRefreshDLCom.Name = "buttonRefreshDLCom";
        this.buttonRefreshDLCom.Size = new System.Drawing.Size(130, 22);
        this.buttonRefreshDLCom.TabIndex = 8;
        this.buttonRefreshDLCom.Text = "Refresh Ports";
        this.buttonRefreshDLCom.UseVisualStyleBackColor = true;
        // 
        // frmDyno
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(419, 275);
        this.Controls.Add(this.maskedTextBox14);
        this.Controls.Add(this.buttonRefreshDLCom);
        this.Controls.Add(this.maskedTextBox13);
        this.Controls.Add(this.labelDLCom);
        this.Controls.Add(this.maskedTextBox12);
        this.Controls.Add(this.maskedTextBox11);
        this.Controls.Add(this.comboBoxDLCOM);
        this.Controls.Add(this.label10);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.maskedTextBox7);
        this.Controls.Add(this.comboBox3);
        this.Controls.Add(this.maskedTextBox8);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.maskedTextBox9);
        this.Controls.Add(this.comboBox2);
        this.Controls.Add(this.maskedTextBox10);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.maskedTextBox1);
        this.Controls.Add(this.label12);
        this.Controls.Add(this.maskedTextBox4);
        this.Controls.Add(this.label11);
        this.Controls.Add(this.maskedTextBox5);
        this.Controls.Add(this.label9);
        this.Controls.Add(this.maskedTextBox6);
        this.Controls.Add(this.label8);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmDyno";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Dyno Setup";
        this.Load += new System.EventHandler(this.FrmDyno_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private void RefreshPorts()
    {
        this.comboBoxDLCOM.Items.Clear();
        foreach (string str in SerialPort.GetPortNames())
        {
            this.comboBoxDLCOM.Items.Add(str);
        }
    }
}

