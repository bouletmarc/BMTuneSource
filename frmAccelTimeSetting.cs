using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

internal class frmAccelTimeSetting : Form
{
    private Button btnOk;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private IContainer components;
    private Label label1;
    private TextBox txt_MinSpeed;
    private Label label4;
    private TextBox txt_MaxSpeed;
    private Label label2;
    private Label label5;
    private Class18 class18_0;

    internal frmAccelTimeSetting()
    {
        this.InitializeComponent();

    }

    internal void method_0(ref Class18 rm)
    {
        this.class18_0 = rm;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        this.txt_MinSpeed.Text = this.class18_0.class10_settings_0.AccelTimerSpeedStart.ToString();
        this.txt_MaxSpeed.Text = this.class18_0.class10_settings_0.AccelTimerSpeedEnd.ToString();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Live Plots Settings");
        try
        {
            this.class18_0.class10_settings_0.AccelTimerSpeedStart = int.Parse(this.txt_MinSpeed.Text);
            this.class18_0.class10_settings_0.AccelTimerSpeedEnd = int.Parse(this.txt_MaxSpeed.Text);
            this.Close();
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

    private void frmAdvTableAdd_Load(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccelTimeSetting));
            this.btnOk = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MinSpeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaxSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(94, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Apply";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min Speed to Start timer:";
            // 
            // txt_MinSpeed
            // 
            this.txt_MinSpeed.Location = new System.Drawing.Point(168, 15);
            this.txt_MinSpeed.Name = "txt_MinSpeed";
            this.txt_MinSpeed.Size = new System.Drawing.Size(43, 20);
            this.txt_MinSpeed.TabIndex = 4;
            this.txt_MinSpeed.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max Speed to End timer:";
            // 
            // txt_MaxSpeed
            // 
            this.txt_MaxSpeed.Location = new System.Drawing.Point(168, 43);
            this.txt_MaxSpeed.Name = "txt_MaxSpeed";
            this.txt_MaxSpeed.Size = new System.Drawing.Size(43, 20);
            this.txt_MaxSpeed.TabIndex = 6;
            this.txt_MaxSpeed.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "km/h";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "km/h";
            // 
            // frmAccelTimeSetting
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 116);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_MinSpeed);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MaxSpeed);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccelTimeSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Accel Time Settings";
            this.Load += new System.EventHandler(this.frmAdvTableAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}

