using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmMap : UserControl
{
    private bool bool_0;
    private CheckBox chkHighCamOnly;
    private CheckBox chkSecMaps;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox groupBox4;
    private GroupBox groupBox5;
    private IContainer icontainer_0;
    private RadioButton rbPrimMap;
    private RadioButton rbPrimTps;
    private RadioButton rbSecMap;
    private RadioButton rbSecTps;
    private RadioButton rbSecAlpha;
    private RadioButton rbPrimAlpha;
    private GroupBox grpAlphaN;
    private Label label1;
    private Label label14;
    private Label label13;
    private Label label7;
    private Label label12;
    private Label label9;
    private Label label10;
    private Label label6;
    private Label label5;
    private Label label3;
    private Panel panel1;
    private NumericUpDown txtbMapCross;
    private NumericUpDown txtbAlpha100mBar;
    private NumericUpDown txtbTpsCross;
    private NumericUpDown txtbAlpha0mBar;
    private NumericUpDown txtbAlpha100tps;
    private NumericUpDown txtbAlpha0Tps;
    private IContainer components;

    internal parmMap(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

        this.groupBox4.Enabled = true;
        this.groupBox5.Enabled = true;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkHighCamOnly_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
        this.parmMap_Load(null, null);
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbSecAlpha = new System.Windows.Forms.RadioButton();
            this.rbSecTps = new System.Windows.Forms.RadioButton();
            this.rbSecMap = new System.Windows.Forms.RadioButton();
            this.chkSecMaps = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbPrimAlpha = new System.Windows.Forms.RadioButton();
            this.rbPrimTps = new System.Windows.Forms.RadioButton();
            this.rbPrimMap = new System.Windows.Forms.RadioButton();
            this.chkHighCamOnly = new System.Windows.Forms.CheckBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpAlphaN = new System.Windows.Forms.GroupBox();
            this.txtbMapCross = new System.Windows.Forms.NumericUpDown();
            this.txtbAlpha100mBar = new System.Windows.Forms.NumericUpDown();
            this.txtbTpsCross = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbAlpha0mBar = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txtbAlpha100tps = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbAlpha0Tps = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.grpAlphaN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMapCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha100mBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha0mBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha100tps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha0Tps)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.chkSecMaps);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.chkHighCamOnly);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maps Indexing";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbSecAlpha);
            this.groupBox5.Controls.Add(this.rbSecTps);
            this.groupBox5.Controls.Add(this.rbSecMap);
            this.groupBox5.Location = new System.Drawing.Point(3, 168);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(198, 91);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Secondary Map Load";
            // 
            // rbSecAlpha
            // 
            this.rbSecAlpha.AutoSize = true;
            this.rbSecAlpha.Enabled = false;
            this.rbSecAlpha.Location = new System.Drawing.Point(21, 66);
            this.rbSecAlpha.Name = "rbSecAlpha";
            this.rbSecAlpha.Size = new System.Drawing.Size(66, 18);
            this.rbSecAlpha.TabIndex = 7;
            this.rbSecAlpha.Text = "Alpha-N";
            this.rbSecAlpha.UseVisualStyleBackColor = true;
            this.rbSecAlpha.Click += new System.EventHandler(this.rbSecMap_Click);
            // 
            // rbSecTps
            // 
            this.rbSecTps.AutoSize = true;
            this.rbSecTps.Enabled = false;
            this.rbSecTps.Location = new System.Drawing.Point(21, 42);
            this.rbSecTps.Name = "rbSecTps";
            this.rbSecTps.Size = new System.Drawing.Size(45, 18);
            this.rbSecTps.TabIndex = 2;
            this.rbSecTps.Text = "TPS";
            this.rbSecTps.UseVisualStyleBackColor = true;
            this.rbSecTps.Click += new System.EventHandler(this.rbSecMap_Click);
            // 
            // rbSecMap
            // 
            this.rbSecMap.AutoSize = true;
            this.rbSecMap.Checked = true;
            this.rbSecMap.Location = new System.Drawing.Point(21, 17);
            this.rbSecMap.Name = "rbSecMap";
            this.rbSecMap.Size = new System.Drawing.Size(47, 18);
            this.rbSecMap.TabIndex = 2;
            this.rbSecMap.TabStop = true;
            this.rbSecMap.Text = "Map";
            this.rbSecMap.UseVisualStyleBackColor = true;
            this.rbSecMap.Click += new System.EventHandler(this.rbSecMap_Click);
            // 
            // chkSecMaps
            // 
            this.chkSecMaps.AutoSize = true;
            this.chkSecMaps.Location = new System.Drawing.Point(16, 44);
            this.chkSecMaps.Name = "chkSecMaps";
            this.chkSecMaps.Size = new System.Drawing.Size(139, 18);
            this.chkSecMaps.TabIndex = 1;
            this.chkSecMaps.Text = "Secondary Map Only";
            this.chkSecMaps.UseVisualStyleBackColor = true;
            this.chkSecMaps.CheckedChanged += new System.EventHandler(this.chkHighCamOnly_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbPrimAlpha);
            this.groupBox4.Controls.Add(this.rbPrimTps);
            this.groupBox4.Controls.Add(this.rbPrimMap);
            this.groupBox4.Location = new System.Drawing.Point(3, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(198, 91);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Primary Map Load";
            // 
            // rbPrimAlpha
            // 
            this.rbPrimAlpha.AutoSize = true;
            this.rbPrimAlpha.Enabled = false;
            this.rbPrimAlpha.Location = new System.Drawing.Point(21, 66);
            this.rbPrimAlpha.Name = "rbPrimAlpha";
            this.rbPrimAlpha.Size = new System.Drawing.Size(66, 18);
            this.rbPrimAlpha.TabIndex = 6;
            this.rbPrimAlpha.Text = "Alpha-N";
            this.rbPrimAlpha.UseVisualStyleBackColor = true;
            this.rbPrimAlpha.Click += new System.EventHandler(this.rbPrimMap_Click);
            // 
            // rbPrimTps
            // 
            this.rbPrimTps.AutoSize = true;
            this.rbPrimTps.Enabled = false;
            this.rbPrimTps.Location = new System.Drawing.Point(21, 42);
            this.rbPrimTps.Name = "rbPrimTps";
            this.rbPrimTps.Size = new System.Drawing.Size(45, 18);
            this.rbPrimTps.TabIndex = 5;
            this.rbPrimTps.Text = "TPS";
            this.rbPrimTps.UseVisualStyleBackColor = true;
            this.rbPrimTps.Click += new System.EventHandler(this.rbPrimMap_Click);
            // 
            // rbPrimMap
            // 
            this.rbPrimMap.AutoSize = true;
            this.rbPrimMap.Checked = true;
            this.rbPrimMap.Location = new System.Drawing.Point(21, 17);
            this.rbPrimMap.Name = "rbPrimMap";
            this.rbPrimMap.Size = new System.Drawing.Size(47, 18);
            this.rbPrimMap.TabIndex = 2;
            this.rbPrimMap.TabStop = true;
            this.rbPrimMap.Text = "Map";
            this.rbPrimMap.UseVisualStyleBackColor = true;
            this.rbPrimMap.Click += new System.EventHandler(this.rbPrimMap_Click);
            // 
            // chkHighCamOnly
            // 
            this.chkHighCamOnly.AutoSize = true;
            this.chkHighCamOnly.Location = new System.Drawing.Point(16, 23);
            this.chkHighCamOnly.Name = "chkHighCamOnly";
            this.chkHighCamOnly.Size = new System.Drawing.Size(143, 18);
            this.chkHighCamOnly.TabIndex = 0;
            this.chkHighCamOnly.Text = "High Cams Maps Only";
            this.chkHighCamOnly.UseVisualStyleBackColor = true;
            this.chkHighCamOnly.CheckedChanged += new System.EventHandler(this.chkHighCamOnly_CheckedChanged);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // grpAlphaN
            // 
            this.grpAlphaN.Controls.Add(this.txtbMapCross);
            this.grpAlphaN.Controls.Add(this.txtbAlpha100mBar);
            this.grpAlphaN.Controls.Add(this.txtbTpsCross);
            this.grpAlphaN.Controls.Add(this.label1);
            this.grpAlphaN.Controls.Add(this.txtbAlpha0mBar);
            this.grpAlphaN.Controls.Add(this.label14);
            this.grpAlphaN.Controls.Add(this.txtbAlpha100tps);
            this.grpAlphaN.Controls.Add(this.label13);
            this.grpAlphaN.Controls.Add(this.txtbAlpha0Tps);
            this.grpAlphaN.Controls.Add(this.label7);
            this.grpAlphaN.Controls.Add(this.label12);
            this.grpAlphaN.Controls.Add(this.label9);
            this.grpAlphaN.Controls.Add(this.label10);
            this.grpAlphaN.Controls.Add(this.label6);
            this.grpAlphaN.Controls.Add(this.label5);
            this.grpAlphaN.Controls.Add(this.label3);
            this.grpAlphaN.Location = new System.Drawing.Point(3, 268);
            this.grpAlphaN.Name = "grpAlphaN";
            this.grpAlphaN.Size = new System.Drawing.Size(210, 169);
            this.grpAlphaN.TabIndex = 4;
            this.grpAlphaN.TabStop = false;
            this.grpAlphaN.Text = "Alpha-N Settings";
            // 
            // txtbMapCross
            // 
            this.txtbMapCross.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtbMapCross.Location = new System.Drawing.Point(72, 141);
            this.txtbMapCross.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbMapCross.Name = "txtbMapCross";
            this.txtbMapCross.Size = new System.Drawing.Size(60, 20);
            this.txtbMapCross.TabIndex = 121;
            this.txtbMapCross.Click += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            this.txtbMapCross.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbAlpha0mBar_KeyPress);
            this.txtbMapCross.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlpha0mBar_Validating);
            this.txtbMapCross.Validated += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            // 
            // txtbAlpha100mBar
            // 
            this.txtbAlpha100mBar.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtbAlpha100mBar.Location = new System.Drawing.Point(102, 67);
            this.txtbAlpha100mBar.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbAlpha100mBar.Name = "txtbAlpha100mBar";
            this.txtbAlpha100mBar.Size = new System.Drawing.Size(60, 20);
            this.txtbAlpha100mBar.TabIndex = 125;
            this.txtbAlpha100mBar.Click += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            this.txtbAlpha100mBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbAlpha0mBar_KeyPress);
            this.txtbAlpha100mBar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlpha0mBar_Validating);
            this.txtbAlpha100mBar.Validated += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            // 
            // txtbTpsCross
            // 
            this.txtbTpsCross.Location = new System.Drawing.Point(72, 115);
            this.txtbTpsCross.Name = "txtbTpsCross";
            this.txtbTpsCross.Size = new System.Drawing.Size(60, 20);
            this.txtbTpsCross.TabIndex = 120;
            this.txtbTpsCross.Click += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            this.txtbTpsCross.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbAlpha0mBar_KeyPress);
            this.txtbTpsCross.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlpha0mBar_Validating);
            this.txtbTpsCross.Validated += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Crossover:";
            // 
            // txtbAlpha0mBar
            // 
            this.txtbAlpha0mBar.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtbAlpha0mBar.Location = new System.Drawing.Point(102, 41);
            this.txtbAlpha0mBar.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtbAlpha0mBar.Name = "txtbAlpha0mBar";
            this.txtbAlpha0mBar.Size = new System.Drawing.Size(60, 20);
            this.txtbAlpha0mBar.TabIndex = 124;
            this.txtbAlpha0mBar.Click += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            this.txtbAlpha0mBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbAlpha0mBar_KeyPress);
            this.txtbAlpha0mBar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlpha0mBar_Validating);
            this.txtbAlpha0mBar.Validated += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(77, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 14);
            this.label14.TabIndex = 18;
            this.label14.Text = "%";
            // 
            // txtbAlpha100tps
            // 
            this.txtbAlpha100tps.Location = new System.Drawing.Point(14, 67);
            this.txtbAlpha100tps.Name = "txtbAlpha100tps";
            this.txtbAlpha100tps.Size = new System.Drawing.Size(57, 20);
            this.txtbAlpha100tps.TabIndex = 123;
            this.txtbAlpha100tps.Click += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            this.txtbAlpha100tps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbAlpha0mBar_KeyPress);
            this.txtbAlpha100tps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlpha0mBar_Validating);
            this.txtbAlpha100tps.Validated += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(77, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 14);
            this.label13.TabIndex = 16;
            this.label13.Text = "%";
            // 
            // txtbAlpha0Tps
            // 
            this.txtbAlpha0Tps.Location = new System.Drawing.Point(14, 41);
            this.txtbAlpha0Tps.Name = "txtbAlpha0Tps";
            this.txtbAlpha0Tps.Size = new System.Drawing.Size(57, 20);
            this.txtbAlpha0Tps.TabIndex = 122;
            this.txtbAlpha0Tps.Click += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            this.txtbAlpha0Tps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbAlpha0mBar_KeyPress);
            this.txtbAlpha0Tps.Validating += new System.ComponentModel.CancelEventHandler(this.txtbAlpha0mBar_Validating);
            this.txtbAlpha0Tps.Validated += new System.EventHandler(this.txtbAlpha0mBar_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "mbar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "Map:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(139, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 14);
            this.label10.TabIndex = 9;
            this.label10.Text = "TPS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "mbar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "mbar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "MAP value with tps:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grpAlphaN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 458);
            this.panel1.TabIndex = 5;
            // 
            // parmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmMap";
            this.Size = new System.Drawing.Size(256, 458);
            this.Load += new System.EventHandler(this.parmMap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.grpAlphaN.ResumeLayout(false);
            this.grpAlphaN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMapCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha100mBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbTpsCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha0mBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha100tps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbAlpha0Tps)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmMap_Load(null, null);
        }
    }

    private void method_1()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Fuel & Ign Table Settings");
            if (this.chkHighCamOnly.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_24, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_24, 0);
            }
            if (this.chkSecMaps.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_25, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_25, 0);
            }


            if (this.grpAlphaN.Enabled)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_370, this.class18_0.method_228(int.Parse(this.txtbTpsCross.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_371, this.class18_0.method_226(int.Parse(this.txtbMapCross.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_373 + 2L, this.class18_0.method_228(int.Parse(this.txtbAlpha0Tps.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_373, this.class18_0.method_228(int.Parse(this.txtbAlpha100tps.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_373 + 3L, this.class18_0.method_226(int.Parse(this.txtbAlpha0mBar.Text)));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_373 + 1L, this.class18_0.method_226(int.Parse(this.txtbAlpha100mBar.Text)));
            }

            byte num = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_372);
            if (this.rbPrimMap.Checked)
            {
                num = this.class18_0.method_261(num, 0, false);
                num = this.class18_0.method_261(num, 1, false);
            }
            else if (this.rbPrimAlpha.Checked)
            {
                num = this.class18_0.method_261(num, 0, true);
                num = this.class18_0.method_261(num, 1, false);
            }
            else if (this.rbPrimTps.Checked)
            {
                num = this.class18_0.method_261(num, 0, false);
                num = this.class18_0.method_261(num, 1, true);
            }


            if (this.rbSecMap.Checked)
            {
                num = this.class18_0.method_261(num, 2, false);
                num = this.class18_0.method_261(num, 3, false);
            }
            else if (this.rbSecAlpha.Checked)
            {
                num = this.class18_0.method_261(num, 2, true);
                num = this.class18_0.method_261(num, 3, false);
            }
            else if (this.rbSecTps.Checked)
            {
                num = this.class18_0.method_261(num, 2, false);
                num = this.class18_0.method_261(num, 3, true);
            }

            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_372, num);
            this.class18_0.method_153();
            this.parmMap_Load(null, null);
        }
    }

    private void parmMap_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.chkHighCamOnly.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_24) == 0xff;
        this.chkSecMaps.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_25) == 0xff;
        this.rbPrimAlpha.Enabled = this.class18_0.class13_u_0.long_372 != 0L;
        this.rbPrimTps.Enabled = this.class18_0.class13_u_0.long_372 != 0L;
        this.rbSecAlpha.Enabled = this.class18_0.class13_u_0.long_372 != 0L;
        this.rbSecTps.Enabled = this.class18_0.class13_u_0.long_372 != 0L;
        if (this.class18_0.class13_u_0.long_372 != 0L)
        {
            byte num = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_372);
            if ((this.class18_0.method_258(num, 0) && !this.class18_0.method_258(num, 1)) && !this.rbPrimAlpha.Checked)
            {
                this.rbPrimAlpha.Checked = true;
            }
            else if ((!this.class18_0.method_258(num, 0) && this.class18_0.method_258(num, 1)) && !this.rbPrimTps.Checked)
            {
                this.rbPrimTps.Checked = true;
            }
            else if ((!this.class18_0.method_258(num, 0) && !this.class18_0.method_258(num, 1)) && !this.rbPrimMap.Checked)
            {
                this.rbPrimMap.Checked = true;
            }

            if ((this.class18_0.method_258(num, 2) && !this.class18_0.method_258(num, 3)) && !this.rbSecAlpha.Checked)
            {
                this.rbSecAlpha.Checked = true;
            }
            else if ((!this.class18_0.method_258(num, 2) && this.class18_0.method_258(num, 3)) && !this.rbSecTps.Checked)
            {
                this.rbSecTps.Checked = true;
            }
            else if ((!this.class18_0.method_258(num, 2) && !this.class18_0.method_258(num, 3)) && !this.rbSecMap.Checked)
            {
                this.rbSecMap.Checked = true;
            }
        }

        bool AlphaEnabled = this.class18_0.method_265(new long[] { this.class18_0.class13_u_0.long_373, this.class18_0.class13_u_0.long_371, this.class18_0.class13_u_0.long_370 });
        if (AlphaEnabled && !this.rbPrimAlpha.Checked && !this.rbSecAlpha.Checked) AlphaEnabled = false;

        this.grpAlphaN.Enabled = AlphaEnabled;
        {
            this.txtbAlpha0Tps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_373 + 2L)).ToString();
            this.txtbAlpha100tps.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_373)).ToString();
            this.txtbAlpha0mBar.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_373 + 3L)).ToString();
            this.txtbAlpha100mBar.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_373 + 1L)).ToString();
            this.txtbTpsCross.Text = this.class18_0.method_198(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_370)).ToString();
            this.txtbMapCross.Text = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_371)).ToString();
        }
        this.bool_0 = false;
    }

    private void rbPrimMap_Click(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void rbSecMap_Click(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbAlpha0mBar_KeyPress(object sender, KeyPressEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (e.KeyChar == '\r')
        {
            control = (NumericUpDown)sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_1();
            }
            control.Focus();
        }
    }

    private void txtbAlpha0mBar_Validated(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbAlpha0mBar_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown)sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

