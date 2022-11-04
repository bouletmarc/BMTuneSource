using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

internal class frmLivePSetting : Form
{
    private Button btnOk;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private Label lblAdj;
    private IContainer components;
    private GroupBox groupBox2;
    private Label label1;
    private TextBox txtbRpmPlotMinTps;
    private Label label4;
    private TextBox txtbRpmBlock;
    private Label label2;
    private GroupBox groupBox1;
    private Label label3;
    private TextBox txtbTimePlotLength;

    private Class18 class18_0;

    internal frmLivePSetting()
    {
        this.InitializeComponent();
    }

    internal void method_0(ref Class18 rm)
    {
        this.class18_0 = rm;

        this.txtbTimePlotLength.Text = this.class18_0.class10_settings_0.int_5.ToString();
        this.txtbRpmPlotMinTps.Text = this.class18_0.class10_settings_0.int_4.ToString();
        this.txtbRpmBlock.Text = this.class18_0.class10_settings_0.int_3.ToString();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Live Plots Settings");
        this.class18_0.class10_settings_0.int_5 = int.Parse(this.txtbTimePlotLength.Text);
        this.class18_0.class10_settings_0.int_4 = int.Parse(this.txtbRpmPlotMinTps.Text);
        this.class18_0.class10_settings_0.int_3 = int.Parse(this.txtbRpmBlock.Text);
        this.Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLivePSetting));
            this.btnOk = new System.Windows.Forms.Button();
            this.txtbTimePlotLength = new System.Windows.Forms.TextBox();
            this.lblAdj = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtbRpmPlotMinTps = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbRpmBlock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(111, 142);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Apply";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtbTimePlotLength
            // 
            this.txtbTimePlotLength.Location = new System.Drawing.Point(93, 21);
            this.txtbTimePlotLength.Name = "txtbTimePlotLength";
            this.txtbTimePlotLength.Size = new System.Drawing.Size(34, 20);
            this.txtbTimePlotLength.TabIndex = 1;
            this.txtbTimePlotLength.Text = "200";
            // 
            // lblAdj
            // 
            this.lblAdj.AutoSize = true;
            this.lblAdj.Location = new System.Drawing.Point(6, 24);
            this.lblAdj.Name = "lblAdj";
            this.lblAdj.Size = new System.Drawing.Size(77, 14);
            this.lblAdj.TabIndex = 0;
            this.lblAdj.Text = "Time Length:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min TPS:";
            // 
            // txtbRpmPlotMinTps
            // 
            this.txtbRpmPlotMinTps.Location = new System.Drawing.Point(93, 21);
            this.txtbRpmPlotMinTps.Name = "txtbRpmPlotMinTps";
            this.txtbRpmPlotMinTps.Size = new System.Drawing.Size(34, 20);
            this.txtbRpmPlotMinTps.TabIndex = 4;
            this.txtbRpmPlotMinTps.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "RPM blocks:";
            // 
            // txtbRpmBlock
            // 
            this.txtbRpmBlock.Location = new System.Drawing.Point(93, 47);
            this.txtbRpmBlock.Name = "txtbRpmBlock";
            this.txtbRpmBlock.Size = new System.Drawing.Size(34, 20);
            this.txtbRpmBlock.TabIndex = 6;
            this.txtbRpmBlock.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Frames";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAdj);
            this.groupBox1.Controls.Add(this.txtbTimePlotLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 48);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time vs Afr";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtbRpmPlotMinTps);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtbRpmBlock);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(11, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 75);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RPM vs Afr/Boost";
            // 
            // LivePlots
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 175);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LivePlots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Live Plots Settings";
            this.Load += new System.EventHandler(this.frmAdvTableAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

    }
}

