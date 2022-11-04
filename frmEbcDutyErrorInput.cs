using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmEbcDutyErrorInput : Form
{
    private Button btnOk;
    private Button button2;
    private Class18 class18_0;
    private float float_0;
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private TextBox textBox1;

    internal frmEbcDutyErrorInput()
    {
        this.InitializeComponent();

    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("EBC Duty Input Error Settings");
        float num = this.class18_0.method_244(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_274));
        this.float_0 = float.Parse(this.textBox1.Text);
        if (num > this.float_0)
        {
            MessageBox.Show(Form.ActiveForm, "Deadband error cannot be larger then this table. Deadband error will be set to value:" + this.textBox1.Text + ".");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_274, this.class18_0.method_210(this.float_0));
        }
        base.Tag = this.float_0;
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
        this.label1 = new Label();
        this.textBox1 = new TextBox();
        this.btnOk = new Button();
        this.button2 = new Button();
        this.label2 = new Label();
        base.SuspendLayout();
        this.label1.AutoSize = true;
        this.label1.Location = new Point(-2, 12);
        this.label1.Name = "label1";
        this.label1.Size = new Size(0x6a, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Maximum Load Error:";
        this.textBox1.Location = new Point(110, 9);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new Size(0x25, 20);
        this.textBox1.TabIndex = 1;
        this.textBox1.Text = "4";
        this.btnOk.DialogResult = DialogResult.OK;
        this.btnOk.Location = new Point(12, 0x23);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new Size(0x4b, 0x17);
        this.btnOk.TabIndex = 2;
        this.btnOk.Text = "Ok";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new EventHandler(this.btnOk_Click);
        this.button2.DialogResult = DialogResult.Cancel;
        this.button2.Location = new Point(0x5f, 0x23);
        this.button2.Name = "button2";
        this.button2.Size = new Size(0x4b, 0x17);
        this.button2.TabIndex = 3;
        this.button2.Text = "Cancel";
        this.button2.UseVisualStyleBackColor = true;
        this.label2.AutoSize = true;
        this.label2.Location = new Point(0x99, 12);
        this.label2.Name = "label2";
        this.label2.Size = new Size(20, 13);
        this.label2.TabIndex = 4;
        this.label2.Text = "psi";
        base.AcceptButton = this.btnOk;
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.ClientSize = new Size(0xb6, 0x43);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.button2);
        base.Controls.Add(this.btnOk);
        base.Controls.Add(this.textBox1);
        base.Controls.Add(this.label1);
        base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        base.Name = "frmEbcDutyErrorInput";
        base.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Input";
        base.ResumeLayout(false);
        base.PerformLayout();
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
}

