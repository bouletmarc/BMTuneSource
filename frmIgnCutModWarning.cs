using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmIgnCutModWarning : Form
{
    private Button btnApply;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private IContainer components;
    private ComboBox comboBox1;
    private Label label35;
    private PictureBox pictureBox1;
    private Label label1;
    private Label label2;
    private CheckBox checkBox1;
    private Panel panel1;
    public bool InstallMod = false;

    public frmIgnCutModWarning(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;

        this.InitializeComponent();

        comboBox1.SelectedIndex = 0;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 1) InstallMod = true;

        if (checkBox1.Checked)
        {
            if (comboBox1.SelectedIndex == 0) this.class18_0.class10_settings_0.ICutModInstall = "false";
            else if (comboBox1.SelectedIndex == 1) this.class18_0.class10_settings_0.ICutModInstall = "true";
        }
        
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

    private void frmIgnCutModWarningNa_Load(object sender, EventArgs e)
    {
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.btnApply = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label35 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(107, 325);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(76, 25);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Ok";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(42, 216);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 14);
            this.label35.TabIndex = 34;
            this.label35.Text = "Include Mod:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.comboBox1.Location = new System.Drawing.Point(124, 211);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 22);
            this.comboBox1.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 54);
            this.label1.TabIndex = 36;
            this.label1.Text = "Do you want the\r\nIgnition Cut Mod\r\nInstalled on this baserom ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.BMTune_IGNCut_Mod;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 130);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 132);
            this.panel1.TabIndex = 38;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(41, 233);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(241, 18);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "Don\'t show again this box (save choice)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 56);
            this.label2.TabIndex = 40;
            this.label2.Text = "Including the mod on this baserom version can\r\nprobably create unwanted result. I" +
    " would install\r\nonly if you want 2step (ignition cut) and add\r\nsome customizatio" +
    "n to the ignition cut feature.";
            // 
            // frmIgnCutModWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 358);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.btnApply);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIgnCutModWarning";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Install Ignition Cut Mod?";
            this.Load += new System.EventHandler(this.frmIgnCutModWarningNa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}

