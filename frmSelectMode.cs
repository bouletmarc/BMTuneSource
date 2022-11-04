using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmSelectMode : Form
{
    private Class10_settings class10_0;
    private IContainer icontainer_0;
    private Button btnOK;
    private RadioButton radioWindowed;
    private RadioButton radioDocked;
    private TextBox tbDescription;
    private PictureBox pbWindowed;
    private PictureBox pbDocked;

    public frmSelectMode()
    {
        this.InitializeComponent();
    }

    public frmSelectMode(ref Class10_settings class6_1)
    {
        this.InitializeComponent();
        this.class10_0 = class6_1;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        MessageBox.Show("You can always change the layout later by selecting Tools->Windowed Mode", "Notification", MessageBoxButtons.OK);
        if (this.radioDocked.Checked)
        {
            this.class10_0.WindowedMode = false;
        }
        else if (this.radioWindowed.Checked)
        {
            this.class10_0.WindowedMode = true;
        }
        this.class10_0.ShownDockedMode = true;
        base.Close();
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectMode));
            this.btnOK = new System.Windows.Forms.Button();
            this.radioWindowed = new System.Windows.Forms.RadioButton();
            this.radioDocked = new System.Windows.Forms.RadioButton();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.pbWindowed = new System.Windows.Forms.PictureBox();
            this.pbDocked = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWindowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocked)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(864, 375);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 37);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Accept";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // radioWindowed
            // 
            this.radioWindowed.AutoSize = true;
            this.radioWindowed.Location = new System.Drawing.Point(494, 384);
            this.radioWindowed.Name = "radioWindowed";
            this.radioWindowed.Size = new System.Drawing.Size(106, 17);
            this.radioWindowed.TabIndex = 10;
            this.radioWindowed.Text = "Windowed Mode";
            this.radioWindowed.UseVisualStyleBackColor = true;
            // 
            // radioDocked
            // 
            this.radioDocked.AutoSize = true;
            this.radioDocked.Checked = true;
            this.radioDocked.Location = new System.Drawing.Point(12, 384);
            this.radioDocked.Name = "radioDocked";
            this.radioDocked.Size = new System.Drawing.Size(93, 17);
            this.radioDocked.TabIndex = 9;
            this.radioDocked.TabStop = true;
            this.radioDocked.Text = "Docked Mode";
            this.radioDocked.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbDescription.Location = new System.Drawing.Point(2, 4);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(958, 65);
            this.tbDescription.TabIndex = 8;
            this.tbDescription.Text = "Thank you for choosing BMTune\r\nBefore we get started Which layout would you like " +
    "to use?\r\n\r\n";
            this.tbDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbWindowed
            // 
            this.pbWindowed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbWindowed.Image = global::Properties.Resources.windowed_mode;
            this.pbWindowed.Location = new System.Drawing.Point(494, 69);
            this.pbWindowed.Name = "pbWindowed";
            this.pbWindowed.Size = new System.Drawing.Size(466, 294);
            this.pbWindowed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWindowed.TabIndex = 7;
            this.pbWindowed.TabStop = false;
            // 
            // pbDocked
            // 
            this.pbDocked.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbDocked.Image = global::Properties.Resources.docked_mode;
            this.pbDocked.Location = new System.Drawing.Point(12, 69);
            this.pbDocked.Name = "pbDocked";
            this.pbDocked.Size = new System.Drawing.Size(466, 294);
            this.pbDocked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDocked.TabIndex = 6;
            this.pbDocked.TabStop = false;
            // 
            // frmSelectMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 417);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.radioWindowed);
            this.Controls.Add(this.radioDocked);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.pbWindowed);
            this.Controls.Add(this.pbDocked);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectMode";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Select Default Layout";
            ((System.ComponentModel.ISupportInitialize)(this.pbWindowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }
}

