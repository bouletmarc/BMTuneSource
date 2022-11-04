using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmInjectorOverallCalc : Form
{
    private Button btnOk;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox txtbPresNew;
    private IContainer components;
    private Label label5;
    private Label label6;
    private TextBox txtbPresOld;
    public bool IsLastDisplacement = false;
    public bool ChangeDone = false;

   /* public int FuelPressureStart = 45;
    public int FuelPressureEnd = 45;
    public int DisplacementStart = 1595;
    public int DisplacementEnd = 1595;*/
    
    private ComboBox comboBox1;
    private ComboBox comboBox2;

    internal frmInjectorOverallCalc()
    {
        this.InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Injector Overall Calculation");
        double num = 0.0;
        if (!IsLastDisplacement && ChangeDone)
        {
            num = Math.Sqrt(double.Parse(this.txtbPresNew.Text) / double.Parse(this.txtbPresOld.Text));
            if (this.class18_0.class10_settings_0.correctionUnits_0 == CorrectionUnits.multi)
            {
                num--;
                num = 1.0 - num;
                num *= 1.015;
                num = Math.Round(num, 2);
            }
            else
            {
                num--;
                num *= 100.0;
                num *= -1.0;
                num *= 0.85;
                num = Math.Floor(num);
            }
        }
        else if (IsLastDisplacement && ChangeDone)
        {
            num = Math.Sqrt(double.Parse(comboBox2.Text) / double.Parse(comboBox1.Text));
        }
        else
        {
            num = double.Parse(this.class18_0.method_203(this.class18_0.method_152(this.class18_0.class13_u_0.long_39), Enum6.const_0).ToString(""));
        }
        base.Tag = num.ToString();


        /*FuelPressureStart = int.Parse(txtbPresOld.Text);
        FuelPressureEnd = int.Parse(txtbPresNew.Text);
        DisplacementStart = int.Parse(comboBox1.Text);
        DisplacementEnd = int.Parse(comboBox2.Text);*/
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbPresOld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbPresNew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fuel Pressure (psi):";
            // 
            // txtbPresOld
            // 
            this.txtbPresOld.Location = new System.Drawing.Point(23, 27);
            this.txtbPresOld.Name = "txtbPresOld";
            this.txtbPresOld.Size = new System.Drawing.Size(58, 20);
            this.txtbPresOld.TabIndex = 1;
            this.txtbPresOld.Text = "45";
            this.txtbPresOld.TextChanged += new System.EventHandler(this.txtbPresOld_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Old";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "New";
            // 
            // txtbPresNew
            // 
            this.txtbPresNew.Location = new System.Drawing.Point(23, 52);
            this.txtbPresNew.Name = "txtbPresNew";
            this.txtbPresNew.Size = new System.Drawing.Size(58, 20);
            this.txtbPresNew.TabIndex = 4;
            this.txtbPresNew.Text = "45";
            this.txtbPresNew.TextChanged += new System.EventHandler(this.txtbPresNew_TextChanged);
            this.txtbPresNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPresNew_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Displacement (cc):";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(23, 164);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(91, 25);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "New";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Old";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1595",
            "1678",
            "1797",
            "1834",
            "1972"});
            this.comboBox1.Location = new System.Drawing.Point(23, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(58, 22);
            this.comboBox1.TabIndex = 13;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1595",
            "1678",
            "1797",
            "1834",
            "1972"});
            this.comboBox2.Location = new System.Drawing.Point(23, 128);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(58, 22);
            this.comboBox2.TabIndex = 14;
            // 
            // frmInjectorOverallCalc
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(136, 195);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbPresNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbPresOld);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInjectorOverallCalc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Overall Fuel Trim";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    //internal void method_0(ref Class18_file class18_1, int FOld, int FNew, int DOld, int DNew)
    internal void method_0(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;


        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        /*txtbPresOld.Text = FOld.ToString();
        txtbPresNew.Text = FNew.ToString();
        comboBox1.Text = DOld.ToString();
        comboBox2.Text = DNew.ToString();*/

        comboBox1.SelectedIndex = 0;
        comboBox2.SelectedIndex = 0;
    }

    private void txtbPresNew_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbPresOld_TextChanged(object sender, EventArgs e)
    {
        IsLastDisplacement = false;
        ChangeDone = true;
    }

    private void txtbPresNew_TextChanged(object sender, EventArgs e)
    {
        IsLastDisplacement = false;
        ChangeDone = true;
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        IsLastDisplacement = true;
        ChangeDone = true;
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {
        IsLastDisplacement = true;
        ChangeDone = true;
    }
}

