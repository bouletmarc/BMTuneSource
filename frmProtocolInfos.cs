using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmProtocolInfos : Form
{
    private IContainer icontainer_0;
    private Label label1;
    private Label label2;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Column3;
    private DataGridView dataGridView2;
    private DataGridViewTextBoxColumn Column4;
    private DataGridViewTextBoxColumn Column5;
    private DataGridViewTextBoxColumn Column6;
    public Button button1;

    internal frmProtocolInfos()
    {
        this.InitializeComponent();

        this.dataGridView1.Rows.Clear();
        this.dataGridView1.Rows.Add("Get All Sensors Datas", "Send 1 Byte -> 0x30", "Receive 52 Bytes as responce");
        this.dataGridView1.Rows.Add("Reset MIL Codes", "Send 1 Byte -> 0x50", "Receive 1 Byte as responce -> 0x50");
        this.dataGridView1.Rows.Add("Get J12/J4 Resistor Cut", "Send 1 Byte -> 0x10", "Receive 1 Byte as responce -> 0xCD");

        this.dataGridView2.Rows.Clear();
        this.dataGridView2.Rows.Add("0", "ECT", "0D9h");
        this.dataGridView2.Rows.Add("1", "IAT", "003CCh");
        this.dataGridView2.Rows.Add("2", "O2", "003CAh");
        this.dataGridView2.Rows.Add("3", "BARO", "0BCh");
        this.dataGridView2.Rows.Add("4", "MAP", "0BBh");
        this.dataGridView2.Rows.Add("5", "TPS", "003A4h");
        this.dataGridView2.Rows.Add("6", "RPM BYTE1", "0C4h");
        this.dataGridView2.Rows.Add("7", "RPM BYTE2", "0C4h");
        this.dataGridView2.Rows.Add("8", "ACTIVE OPTIONS #1", "003B1h");
            this.dataGridView2.Rows.Add("    .0", "POST FUEL", "003B1h.0");
            this.dataGridView2.Rows.Add("    .1", "SCC CHECKER", "003B1h.1");
            this.dataGridView2.Rows.Add("    .2", "IGNITION CUT", "003B1h.2");
            this.dataGridView2.Rows.Add("    .3", "VTEC MAP SWITCH(VTSM)", "003B1h.3");
            this.dataGridView2.Rows.Add("    .4", "FUEL CUT #1", "003B1h.4");
            this.dataGridView2.Rows.Add("    .5", "FUEL CUT #2", "003B1h.5");
            this.dataGridView2.Rows.Add("    .6", "AT TRANS SHIFT1", "003B1h.6");
            this.dataGridView2.Rows.Add("    .7", "AT TRANS SHIFT2", "003B1h.7");
        this.dataGridView2.Rows.Add("9", "COLUMN RELATED", "001E7h");
        this.dataGridView2.Rows.Add("10", "ROW RELATED", "001E8h");
        this.dataGridView2.Rows.Add("11", "COL/ROW RELATED", "001DFh");
        this.dataGridView2.Rows.Add("12", "MIL BYTE1", "0011Ah");
        this.dataGridView2.Rows.Add("13", "MIL BYTE2", "0011Bh");
        this.dataGridView2.Rows.Add("14", "MIL BYTE3", "0011Ch");
        this.dataGridView2.Rows.Add("15", "MIL BYTE4", "0011Dh");
        this.dataGridView2.Rows.Add("16", "VSS", "0CCh");
        this.dataGridView2.Rows.Add("17", "INJ BYTE1", "0019Eh");
        this.dataGridView2.Rows.Add("18", "INJ BYTE2", "0019Eh");
        this.dataGridView2.Rows.Add("19", "IGN FINAL", "0035Bh");
        this.dataGridView2.Rows.Add("20", "IGN TABLE", "00246h");
        this.dataGridView2.Rows.Add("21", "INPUTS #2", "003B0h");
            this.dataGridView2.Rows.Add("    .0", "PARK NEUTRAL", "003B0h.0");
            this.dataGridView2.Rows.Add("    .1", "BRAKE SWITCH", "003B0h.1");
            this.dataGridView2.Rows.Add("    .2", "ACC SWITCH", "003B0h.2");
            this.dataGridView2.Rows.Add("    .3", "VTEC PRESSURE SWITCH", "003B0h.3");
            this.dataGridView2.Rows.Add("    .4", "STARTER SIGNAL", "003B0h.4");
            this.dataGridView2.Rows.Add("    .5", "SCC", "003B0h.5");
            this.dataGridView2.Rows.Add("    .6", "VTEC FEEDBACK", "003B0h.6");
            this.dataGridView2.Rows.Add("    .7", "POWER STEERING PRESSURE SWITCH", "003B0h.7");
        this.dataGridView2.Rows.Add("22", "OUTPUTS #1", "003B2h");
            this.dataGridView2.Rows.Add("    .0", "FUEL PUMP(MAIN RELAY)", "003B2h.0");
            this.dataGridView2.Rows.Add("    .1", "", "003B2h.1");  //#################################
            this.dataGridView2.Rows.Add("    .2", "INTAKE AIR BUTTERFLY(IAB)", "003B2h.2");
            this.dataGridView2.Rows.Add("    .3", "", "003B2h.3");  //#################################
            this.dataGridView2.Rows.Add("    .4", "FAN CONTROL(FANC)", "003B2h.4");
            this.dataGridView2.Rows.Add("    .5", "ALTERNATOR CONTROL(ALTC)", "003B2h.5");
            this.dataGridView2.Rows.Add("    .6", "PURGE VALVE", "003B2h.6");
            this.dataGridView2.Rows.Add("    .7", "AC CONTROL", "003B2h.7");
        this.dataGridView2.Rows.Add("23", "ACTIVE OPTIONS #2", "003B3h");
            this.dataGridView2.Rows.Add("    .0", "", "003B3h.0");  //#################################
            this.dataGridView2.Rows.Add("    .1", "", "003B3h.1");  //#################################
            this.dataGridView2.Rows.Add("    .2", "", "003B3h.2");  //#################################
            this.dataGridView2.Rows.Add("    .3", "", "003B3h.3");  //#################################
            this.dataGridView2.Rows.Add("    .4", "", "003B3h.4");  //#################################
            this.dataGridView2.Rows.Add("    .5", "MALFUNCTION INDICATOR LIGHT(MIL)", "003B3h.5");
            this.dataGridView2.Rows.Add("    .6", "O2 HEATER", "003B3h.6");
            this.dataGridView2.Rows.Add("    .7", "VTEC SENSOR", "003B3h.7");
        this.dataGridView2.Rows.Add("24", "ELD VOLT", "003D2h");
        this.dataGridView2.Rows.Add("25", "BATTERY VOLT", "003D1h");
        this.dataGridView2.Rows.Add("26", "ECT FUEL CORRECTION", "00168h");
        this.dataGridView2.Rows.Add("27", "O2 SHORT BYTE1", "00158h");
        this.dataGridView2.Rows.Add("28", "O2 SHORT BYTE2", "00158h");
        this.dataGridView2.Rows.Add("29", "O2 LONG BYTE1", "00304h");
        this.dataGridView2.Rows.Add("30", "O2 LONG BYTE2", "00304h");
        this.dataGridView2.Rows.Add("31", "IAT FUEL CORRECTION BYTE1", "0015Ch");
        this.dataGridView2.Rows.Add("32", "IAT FUEL CORRECTION BYTE2", "0015Ch");
        this.dataGridView2.Rows.Add("33", "VE FUEL CORRECTION", "00162h");
        this.dataGridView2.Rows.Add("34", "ECT IGNITION CORRECTION", "00412h");
        this.dataGridView2.Rows.Add("35", "IAT IGNITION CORRECTION", "00252h");
        this.dataGridView2.Rows.Add("36", "GEAR IGNITION CORRECTION", "00253h");
        this.dataGridView2.Rows.Add("37", "GEAR FUEL CORRECTION", "0023Bh");
        this.dataGridView2.Rows.Add("38", "INPUTS ACTIVE #1", "00408h");
            this.dataGridView2.Rows.Add("    .0", "LAUNCH CONTROL", "00408h.0");
            this.dataGridView2.Rows.Add("    .1", "FULL THROTTLE SHIFT", "00408h.1");
            this.dataGridView2.Rows.Add("    .2", "ELECTRONIC BOOST CONTROLLER", "00408h.2");
            this.dataGridView2.Rows.Add("    .3", "ELECTRONIC BOOST CONTROLLER HI", "00408h.3");
            this.dataGridView2.Rows.Add("    .4", "GENERAL PURPOSE OUTPUT #1(GPO1)", "00408h.4");
            this.dataGridView2.Rows.Add("    .5", "GENERAL PURPOSE OUTPUT #2(GPO2)", "00408h.5");
            this.dataGridView2.Rows.Add("    .6", "GENERAL PURPOSE OUTPUT #3(GPO3)", "00408h.6");
            this.dataGridView2.Rows.Add("    .7", "MANUAL BOOST CONTROLLER", "00408h.7");
        this.dataGridView2.Rows.Add("39", "ACTIVE OPTIONS #3", "00409h");
            this.dataGridView2.Rows.Add("    .0", "LAUNCH CONTROL", "00409h.0");
            this.dataGridView2.Rows.Add("    .1", "ANTILAG", "00409h.1");
            this.dataGridView2.Rows.Add("    .2", "FULL THROTTLE SHIFT", "00409h.2");
            this.dataGridView2.Rows.Add("    .3", "BOOST CUT", "00409h.3");
            this.dataGridView2.Rows.Add("    .4", "ELECTRONIC BOOST CONTROLLER", "00409h.4");
            this.dataGridView2.Rows.Add("    .5", "SECONDARY MAPS", "00409h.5");
            this.dataGridView2.Rows.Add("    .6", "FAN CONTROL", "00409h.6");
            this.dataGridView2.Rows.Add("    .7", "MANUAL BOOST CONTROLLER", "00409h.7");
        this.dataGridView2.Rows.Add("40", "ELECTRONIC BOOST CONTROLLER BASE DUTY", "0041Bh");
        this.dataGridView2.Rows.Add("41", "ELECTRONIC BOOST CONTROLLER DUTY", "0041Ch");
        this.dataGridView2.Rows.Add("42", "ELECTRONIC BOOST CONTROLLER TARGET", "0041Ah");
        this.dataGridView2.Rows.Add("43", "ACTIVE OPTIONS #4", "00410h");
            this.dataGridView2.Rows.Add("    .0", "GENERAL PURPOSE OUTPUT #1(GPO1)", "00410h.0");
            this.dataGridView2.Rows.Add("    .1", "GENERAL PURPOSE OUTPUT #2(GPO2)", "00410h.1");
            this.dataGridView2.Rows.Add("    .2", "GENERAL PURPOSE OUTPUT #3(GPO3)", "00410h.2");
            this.dataGridView2.Rows.Add("    .3", "MANUAL BOOST CONTROLLER STAGE2", "00410h.3");
            this.dataGridView2.Rows.Add("    .4", "MANUAL BOOST CONTROLLER STAGE3", "00410h.4");
            this.dataGridView2.Rows.Add("    .5", "MANUAL BOOST CONTROLLER STAGE4", "00410h.5");
            this.dataGridView2.Rows.Add("    .6", "OVERHEAT PROTECTION", "00410h.6");
            this.dataGridView2.Rows.Add("    .7", "LEAN PROTECTION", "00410h.7");
        this.dataGridView2.Rows.Add("44", "EGR VOLT", "0067h");
        this.dataGridView2.Rows.Add("45", "B6 VOLT", "003D5h");
        this.dataGridView2.Rows.Add("46", "", "001EAh");  //#################################
        this.dataGridView2.Rows.Add("47", "", "001ECh");  //#################################
        this.dataGridView2.Rows.Add("48", "", "001E2h");  //#################################
        this.dataGridView2.Rows.Add("49", "IACV DUTY BYTE1", "00382h");
        this.dataGridView2.Rows.Add("50", "IACV DUTY BYTE2", "00382h");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmProtocolInfos_FormClosed(object sender, FormClosedEventArgs e)
    {

    }

    private void frmProtocolInfos_Load(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProtocolInfos));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(211, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ISR V3 Datalog Protocol Informations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(106, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(492, 88);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Command Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Send";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 57;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Receive";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 72;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView2.Location = new System.Drawing.Point(12, 196);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(492, 389);
            this.dataGridView2.TabIndex = 5;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Byte";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 53;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Reference";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 82;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Code in .bin";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 88;
            // 
            // frmProtocolInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 615);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmProtocolInfos";
            this.Text = "ISR V3 Datalog Protocol Informations";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProtocolInfos_FormClosed);
            this.Load += new System.EventHandler(this.frmProtocolInfos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}

