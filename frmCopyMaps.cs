using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmCopyMaps : Form
{
    private Button btnOk;
    private Button button2;
    private CheckBox chkLoad;
    private CheckBox chkRpm;
    private Class18 class18_0;
    private IContainer icontainer_0;
    private Label label1;
    private ListBox listBox1;
    private int int_0;

    internal frmCopyMaps()
    {
        this.InitializeComponent();

    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Copy Maps Settings");
        if (this.int_0 == 1)
        {
            this.class18_0.method_266(this.chkLoad.Checked, this.chkRpm.Checked);
        }
        else
        {
            this.class18_0.method_267(this.chkLoad.Checked, this.chkRpm.Checked);
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

    private void frmCopyMaps_Load(object sender, EventArgs e)
    {
        if (!this.class18_0.method_39()) this.listBox1.SelectedIndex = 0;
        else this.listBox1.SelectedIndex = 1;
        this.int_0 = this.listBox1.SelectedIndex + 1;

        try
        {
            if (base.Tag != null)
            {
                if (base.Tag.ToString() != "")
                {
                    if (int.Parse(base.Tag.ToString()) > 0)
                    {
                        this.int_0 = int.Parse(base.Tag.ToString());
                        if (this.int_0 == 1) this.listBox1.SelectedIndex = 0;
                        else this.listBox1.SelectedIndex = 1;
                    }
                }
            }
        }
        catch { }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopyMaps));
            this.chkLoad = new System.Windows.Forms.CheckBox();
            this.chkRpm = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // chkLoad
            // 
            this.chkLoad.AutoSize = true;
            this.chkLoad.Location = new System.Drawing.Point(36, 73);
            this.chkLoad.Name = "chkLoad";
            this.chkLoad.Size = new System.Drawing.Size(84, 18);
            this.chkLoad.TabIndex = 0;
            this.chkLoad.Text = "Map Scalar";
            this.chkLoad.UseVisualStyleBackColor = true;
            // 
            // chkRpm
            // 
            this.chkRpm.AutoSize = true;
            this.chkRpm.Location = new System.Drawing.Point(36, 98);
            this.chkRpm.Name = "chkRpm";
            this.chkRpm.Size = new System.Drawing.Size(84, 18);
            this.chkRpm.TabIndex = 1;
            this.chkRpm.Text = "RPM Scalar";
            this.chkRpm.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(24, 127);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Copy";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(24, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "From/To:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Items.AddRange(new object[] {
            "Primary to Secondary",
            "Secondary to Primary"});
            this.listBox1.Location = new System.Drawing.Point(15, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(143, 32);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // frmCopyMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 195);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkRpm);
            this.Controls.Add(this.chkLoad);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCopyMaps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copy Primay / Secondary";
            this.Load += new System.EventHandler(this.frmCopyMaps_Load);
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

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.int_0 = this.listBox1.SelectedIndex + 1;
    }
}

