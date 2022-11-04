using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmPassword : Form
{
    private Class18 class18_0;
    private IContainer icontainer_0;
    private IContainer components;
    private TextBox textBox1;
    private Label label1;
    public Button button1;

    internal frmPassword()
    {
        this.InitializeComponent();
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

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmPassword_FormClosed(object sender, FormClosedEventArgs e)
    {
        SetPassword();
    }

    private void frmPassword_Load(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPassword));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(63, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter the Password :";
            // 
            // frmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 97);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPassword";
            this.Text = "Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPassword_FormClosed);
            this.Load += new System.EventHandler(this.frmPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    void SetPassword() {
        string ThisReseted = textBox1.Text;
        if (textBox1.Text.Length > 16)
            for (int i = 0; i < 16; i++)
                ThisReseted += textBox1.Text.Substring(i, 1);

        this.class18_0.class10_settings_0.Password = ThisReseted;
        this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        SetPassword();
    }
}

