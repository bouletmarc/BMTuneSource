using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmFileProtection : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private IContainer components;
    private GroupBox groupBox4;
    private CheckBox checkBox2;
    private Label label7;
    private TextBox textBox1;
    private CheckBox checkBox1;
    private Panel panel1;
    private int MaxPasswordSize = 64;

    public parmFileProtection(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

        this.groupBox4.Enabled = true;

        this.textBox1.Text = this.class18_0.class10_settings_0.Password;
        this.checkBox1.Checked = this.class18_0.class10_settings_0.Protect;
        checkBox2.Checked = this.class18_0.class10_settings_0.PasswordHiden;
        textBox1.UseSystemPasswordChar = checkBox2.Checked;
        //if (this.class18_0.RomVersion <= 110) MaxPasswordSize = 64;
        //else MaxPasswordSize = 16;

        if (this.class18_0.RomVersion == 113) groupBox4.Enabled = false;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
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

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 104);
            this.panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 87);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File Protection";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(164, 39);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox2.Size = new System.Drawing.Size(51, 18);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Hide";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Password:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(69, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 18);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Protect Tune";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // parmFileProtection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmFileProtection";
            this.Size = new System.Drawing.Size(246, 104);
            this.Load += new System.EventHandler(this.parmEctProtection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmEctProtection_Load(null, null);
        }
    }

    private void method_1()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_156("File Protection", false);
            this.class18_0.class10_settings_0.Protect = this.checkBox1.Checked;
            this.class18_0.class10_settings_0.Password = this.textBox1.Text;
            this.class18_0.class10_settings_0.PasswordHiden = checkBox2.Checked;
            textBox1.UseSystemPasswordChar = checkBox2.Checked;
            SetProtect();
            this.class18_0.method_153();
            this.parmEctProtection_Load(null, null);
        }
    }

    private void parmEctProtection_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;

        this.textBox1.Text = this.class18_0.class10_settings_0.Password;
        checkBox1.Checked = this.class18_0.class10_settings_0.Protect;
        checkBox2.Checked = this.class18_0.class10_settings_0.PasswordHiden;
        textBox1.UseSystemPasswordChar = checkBox2.Checked;

        this.textBox1.Enabled = checkBox1.Checked;
        this.checkBox2.Enabled = checkBox1.Checked;

        SetProtect();

        this.bool_0 = false;
    }

    private void SetProtect()
    {
        if (this.class18_0.class10_settings_0.Protect)
        {
            if (this.class18_0.class10_settings_0.Password.Length > 1)
            {
                this.class18_0.GetPWLocation(this.class18_0.RomVersion);
                MaxPasswordSize = this.class18_0.GetPWLenght(this.class18_0.RomVersion);

                byte[] PasswordByte = new byte[this.class18_0.class10_settings_0.Password.Length];
                for (int i = 0; i < this.class18_0.class10_settings_0.Password.Length; i++) PasswordByte[i] = Convert.ToByte(this.class18_0.class10_settings_0.Password[i]);
                byte[] PasswordByte2 = this.class18_0.method_92(PasswordByte);

                if (PasswordByte2.Length > MaxPasswordSize)
                {
                    MessageBox.Show(Form.ActiveForm, "Password is too long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    for (int i = 0; i < MaxPasswordSize; i++) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_4PASS + i, 0xff);
                }
                else
                {
                    for (int i = 0; i < PasswordByte2.Length; i++) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_4PASS + i, PasswordByte2[i]);
                }
            }
            else
            {
                //long_403
                //No Password = Unprotect
                for (int i = 0; i < MaxPasswordSize; i++) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_4PASS + i, 0xff);
            }
        }
        else
        {
            //Not Protected = Unprotect
            for (int i = 0; i < MaxPasswordSize; i++) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_4PASS + i, 0xff);
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        method_1();
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        method_1();
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {

    }

    private void textBox1_Validated(object sender, EventArgs e)
    {
        method_1();
    }
}

