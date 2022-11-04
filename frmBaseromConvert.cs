using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

internal class frmBaseromConvert : Form
{
    private Class18 class18_0;
    private IContainer icontainer_0;
    private Label labelProductName;
    private Label label_Baserom;
    private DataGridView dataGridView1;
    private Label label6;
    private Button okButton;
    private Button button1;
    private Label label4;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column3;
    private Label label1;
    private Label label3;
    private Panel panel1;

    public frmBaseromConvert(ref Class18 class18_1)
    {
        this.InitializeComponent();
        this.class18_0 = class18_1;

        this.class18_0.Binary_Files_0.ReloadVersion();
        for (int i = this.class18_0.Binary_Files_0.class1_Version_0.Count - 1; i >= 0; i--)
        {
            Class1_Version class1_Version_1 = this.class18_0.Binary_Files_0.class1_Version_0[i];

            this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[0].Value = "V" + class1_Version_1.Version.ToString().Substring(0, 1) + "." + class1_Version_1.Version.ToString().Substring(1, 1) + class1_Version_1.Version.ToString().Substring(2, 1);
            this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[1].Value = class1_Version_1.Stable.ToString();
            this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[2].Value = class1_Version_1.Infos;
        }

        //Select last stable version
        if (this.dataGridView1.Rows.Count > 0)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells.Count >= 2)
                {
                    if (this.dataGridView1.Rows[i].Cells[1].Value.ToString() == "True")
                    {
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells[0];
                        this.dataGridView1.Rows[i].Selected = true;

                        string TVers = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                        TVers = TVers.Replace("V", "");
                        label4.Text = TVers;

                        i = this.dataGridView1.Rows.Count;
                    }
                }
            }
        }

        label_Baserom.Text = this.class18_0.RomVersion.ToString().Substring(0, 1) + "." + this.class18_0.RomVersion.ToString().Substring(1, 1) + this.class18_0.RomVersion.ToString().Substring(2, 1);

        SetRestoreText();

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

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseromConvert));
            this.labelProductName = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.label_Baserom = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.Location = new System.Drawing.Point(119, 10);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 18);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(165, 18);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Baserom Converter";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.AutoSize = true;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(262, 525);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(141, 25);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&Convert Baserom";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label_Baserom
            // 
            this.label_Baserom.AutoSize = true;
            this.label_Baserom.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Baserom.Location = new System.Drawing.Point(118, 6);
            this.label_Baserom.Name = "label_Baserom";
            this.label_Baserom.Size = new System.Drawing.Size(34, 15);
            this.label_Baserom.TabIndex = 27;
            this.label_Baserom.Text = "1.00";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(5, 109);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(398, 410);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Version";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Stable";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Infos";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(82, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "Convert the Baserom Version of BMTune";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(5, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "Cancel";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(118, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "1.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "Current Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "New Version:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label_Baserom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(111, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 44);
            this.panel1.TabIndex = 40;
            // 
            // frmBaseromConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaseromConvert";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Baserom Converter";
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void frmAboutBox_Load(object sender, EventArgs e)
    {

    }

    private void SetRestoreText()
    {
        string TVers = label4.Text;
        TVers = TVers.Replace(".", "");
        int VersionI = int.Parse(TVers);

        if (VersionI == this.class18_0.RomVersion) okButton.Text = "&Restore Baserom";
        else okButton.Text = "&Convert Baserom";
    }

    public void StartConvert()
    {
        bool DoingNormalConvert = true;

        string TVers = label4.Text;
        TVers = TVers.Replace(".", "");
        int VersionI = int.Parse(TVers);

        if (VersionI == this.class18_0.RomVersion)
        {
            if (MessageBox.Show(Form.ActiveForm, "Do you want to restore using the Calibration Export/Import method?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string ExportingPath = Environment.GetEnvironmentVariable("TEMP") + @"\ToImportCal.bmc";
                DoingNormalConvert = false;

                //################################################
                this.class18_0.method_73(ExportingPath); //Export
                //
                this.class18_0.OpenSilentBRom = true;
                this.class18_0.method_63(false, 100, Path.GetFileName(this.class18_0.method_25_GetFilename()));    //load V1.00 baserom
                this.class18_0.OpenSilentBRom = false;

                this.class18_0.ConvertBaseromVersionToVersion(VersionI);
                this.class18_0.RomVersion = VersionI;
                this.class18_0.ResetBaseromParameters();
                //
                this.class18_0.method_75(ExportingPath, false, 1);  //Import
                if (File.Exists(ExportingPath)) File.Delete(ExportingPath);
                //#######################################################
            }
        }

        if (DoingNormalConvert) this.class18_0.ConvertBaseromVersionToVersion(VersionI);

        //Add warning for emulator connected
        if (this.class18_0.class25_0.GetConnected()) MessageBox.Show(Form.ActiveForm, "You need to upload again 'baserom+calibration' to the emulator for it to refresh!", "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.Close();
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        StartConvert();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        string TVers = this.dataGridView1.Rows[this.dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
        TVers = TVers.Replace("V", "");
        label4.Text = TVers;

        SetRestoreText();
    }

    private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        StartConvert();
    }
}

