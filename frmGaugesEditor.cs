using Data;
using Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

internal class frmGaugesEditor : Form
{
    private Class18 class18_0;
    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    private IContainer components;
    private NumericUpDown numericSizeY;
    private NumericUpDown numericSizeX;
    private Label label2;
    private NumericUpDown numericPosY;
    private NumericUpDown numericPosX;
    private Button buttonRestore;
    private ComboBox comboBoxSensors;
    private Label label3;
    private Label label4;
    private ComboBox comboBoxDisplayType;
    private Label label1;
    private CtrlDisplayItemText CtrlDisplayItemText_0;
    private bool Loading = true;

    private Point DefaultPos = new Point();
    private Size DefaultSize = new Size();
    private int Default_DataDisplayType;
    private int Default_SensorType;

    private int Default_WarnMin = -789;
    private int Default_WarnMax = -789;
    private int Default_SensorMin = -789;
    private int Default_SensorMax = -789;

    private Label label5;
    private TextBox txtbValueMax;
    private TextBox txtbValueMin;
    private Label label7;
    private TextBox txtbWarnMax;
    private TextBox txtbWarnMin;
    private GroupBox groupBoxRange;
    private Label label11;
    private Label label6;
    private ErrorProvider errorProvider_0;

    internal frmGaugesEditor(ref FrmMain frmMain_1, ref Class18 class18_1, ref CtrlDisplayItemText CtrlDisplayItemText_1)
    {
        this.InitializeComponent();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }

        frmMain_0 = frmMain_1;
        class18_0 = class18_1;
        CtrlDisplayItemText_0 = CtrlDisplayItemText_1;

        DefaultPos = this.CtrlDisplayItemText_0.Location;
        DefaultSize = this.CtrlDisplayItemText_0.Size;
        int DataDisplayType = this.CtrlDisplayItemText_0.DataDisplayType;
        Default_DataDisplayType = DataDisplayType;

        int SensorType = 0;
        if (DataDisplayType == 1) SensorType = (int)this.CtrlDisplayItemText_0.TypeLED;
        else if (DataDisplayType == 4) SensorType = (int)this.CtrlDisplayItemText_0.TypeALL;
        else if (DataDisplayType == 5) SensorType = (int)this.CtrlDisplayItemText_0.TypeBUTTON;
        else SensorType = (int)this.CtrlDisplayItemText_0.Type;

        Default_SensorType = SensorType;

        this.comboBoxDisplayType.SelectedIndex = DataDisplayType;

        this.numericPosX.Maximum = this.frmMain_0.frmDataDisplay_0.Size.Width - this.CtrlDisplayItemText_0.Size.Width;
        this.numericPosY.Maximum = this.frmMain_0.frmDataDisplay_0.Size.Height - this.CtrlDisplayItemText_0.Size.Height;

        this.numericSizeX.Minimum = this.CtrlDisplayItemText_0.MinimumSize.Width;
        this.numericSizeY.Minimum = this.CtrlDisplayItemText_0.MinimumSize.Height;

        this.numericSizeX.Maximum = this.CtrlDisplayItemText_0.MaximumSize.Width;
        this.numericSizeY.Maximum = this.CtrlDisplayItemText_0.MaximumSize.Height;

        this.numericPosX.Value = DefaultPos.X;
        this.numericPosY.Value = DefaultPos.Y;
        this.numericSizeX.Value = DefaultSize.Width;
        this.numericSizeY.Value = DefaultSize.Height;

        ReloadSensorList();

        Loading = false;
    }

    private void ReloadSensorList()
    {
        int DataDisplayType = this.CtrlDisplayItemText_0.DataDisplayType;
        int SensorType = 0;
        if (DataDisplayType == 1) SensorType = (int)this.CtrlDisplayItemText_0.TypeLED;
        else if (DataDisplayType == 4) SensorType = (int)this.CtrlDisplayItemText_0.TypeALL;
        else if (DataDisplayType == 5) SensorType = (int)this.CtrlDisplayItemText_0.TypeBUTTON;
        else SensorType = (int)this.CtrlDisplayItemText_0.Type;

        this.comboBoxSensors.Items.Clear();
        if (DataDisplayType == 0 || DataDisplayType == 2 || DataDisplayType == 3 || DataDisplayType == 4)
        {
            groupBoxRange.Enabled = true;
            comboBoxDisplayType.Enabled = true;

            if (DataDisplayType != 4)
            {
                for (int i = 1; i < 26; i++) if (addDisplayTolist((DatalogDisplayTypes)i)) this.comboBoxSensors.Items.Add(((DatalogDisplayTypes)i).ToString());
            }
            else
            {
                for (int i = 0; i < this.class18_0.class10_settings_0.int_0; i++) this.comboBoxSensors.Items.Add(((SensorsX)i).ToString());
            }

            //load range
            try
            {
                this.txtbWarnMin.Text = this.frmMain_0.class10_settings_0.method_20(GetTheSensor()).ToString();
                this.txtbWarnMax.Text = this.frmMain_0.class10_settings_0.method_22(GetTheSensor()).ToString();
                this.txtbValueMin.Text = this.frmMain_0.class10_settings_0.method_20_Min(GetTheSensor()).ToString();
                this.txtbValueMax.Text = this.frmMain_0.class10_settings_0.method_22_Max(GetTheSensor()).ToString();

                Default_WarnMin = this.frmMain_0.class10_settings_0.method_20(GetTheSensor());
                Default_WarnMax = this.frmMain_0.class10_settings_0.method_22(GetTheSensor());
                Default_SensorMin = this.frmMain_0.class10_settings_0.method_20_Min(GetTheSensor());
                Default_SensorMax = this.frmMain_0.class10_settings_0.method_22_Max(GetTheSensor());
            }
            catch { }
        }
        else if (DataDisplayType == 1)
        {
            groupBoxRange.Enabled = false;
            comboBoxDisplayType.Enabled = false;

            for (int i = 1; i < (0x17 + 26); i++)
            {
                this.comboBoxSensors.Items.Add(((DatalogLedTypes)i).ToString());
            }
        }
        else if (DataDisplayType == 5)
        {
            groupBoxRange.Enabled = false;
            comboBoxDisplayType.Enabled = false;

            try
            {
                for (int i = 0; i < 250; i++)
                {
                    this.comboBoxSensors.Items.Add(((DatalogButtonsTypes)i).ToString());
                }
            }
            catch { }
        }
        this.comboBoxSensors.SelectedIndex = (SensorType - 1);
    }

    private bool addDisplayTolist(DatalogDisplayTypes typ)
    {
        switch (typ)
        {
            case DatalogDisplayTypes.nEw:
                return true;

            case DatalogDisplayTypes.rpm:
                return true;

            case DatalogDisplayTypes.map:
                return true;

            case DatalogDisplayTypes.boost:
                return true;

            case DatalogDisplayTypes.O2:
                return true;

            case DatalogDisplayTypes.tps:
                return true;

            case DatalogDisplayTypes.inj:
                return true;

            case DatalogDisplayTypes.ign:
                return true;

            case DatalogDisplayTypes.iat:
                return true;

            case DatalogDisplayTypes.ect:
                return true;

            case DatalogDisplayTypes.bat:
                return true;

            case DatalogDisplayTypes.bstctrl:
                return true;

            case DatalogDisplayTypes.vss:
                return true;

            case DatalogDisplayTypes.gear:
                return true;

            case DatalogDisplayTypes.o2Trim:
                return true;

            case DatalogDisplayTypes.analog1:
                return true;

            case DatalogDisplayTypes.analog2:
                return true;

            case DatalogDisplayTypes.analog3:
                return true;
            case DatalogDisplayTypes.accelTime:
                return true;
            case DatalogDisplayTypes.fuelUsage:
                return true;
            case DatalogDisplayTypes.flexFuel:
                return true;
        }
        return false;
    }

    private SensorsX GetTheSensor()
    {
        if (this.CtrlDisplayItemText_0.DataDisplayType == 0 && this.CtrlDisplayItemText_0.DataDisplayType == 2 && this.CtrlDisplayItemText_0.DataDisplayType == 3)
        {
            return this.CtrlDisplayItemText_0.ConvertDisplayTypeToSensor();
        }
        else if (this.CtrlDisplayItemText_0.DataDisplayType == 4)
        {
            return this.CtrlDisplayItemText_0.TypeALL;
        }
        else
        {
            return SensorsX.test0;
        }
    }

    private void ApplySensorsSettings()
    {
        if (GetTheSensor() != SensorsX.test0)
        {
            if ((this.txtbWarnMax.Text != string.Empty) && (this.txtbWarnMin.Text != string.Empty))
            {
                this.frmMain_0.class10_settings_0.method_21(GetTheSensor(), int.Parse(this.txtbWarnMin.Text));
                this.frmMain_0.class10_settings_0.method_23(GetTheSensor(), int.Parse(this.txtbWarnMax.Text));
            }
            if ((this.txtbValueMin.Text != string.Empty) && (this.txtbValueMax.Text != string.Empty))
            {
                this.frmMain_0.class10_settings_0.method_21_Min(GetTheSensor(), int.Parse(this.txtbValueMin.Text));
                this.frmMain_0.class10_settings_0.method_23_Max(GetTheSensor(), int.Parse(this.txtbValueMax.Text));
            }
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

    private void frmDebug_Load(object sender, EventArgs e)
    {
        
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGaugesEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.numericPosX = new System.Windows.Forms.NumericUpDown();
            this.numericPosY = new System.Windows.Forms.NumericUpDown();
            this.numericSizeY = new System.Windows.Forms.NumericUpDown();
            this.numericSizeX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.comboBoxSensors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDisplayType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbValueMax = new System.Windows.Forms.TextBox();
            this.txtbValueMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbWarnMax = new System.Windows.Forms.TextBox();
            this.txtbWarnMin = new System.Windows.Forms.TextBox();
            this.groupBoxRange = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSizeX)).BeginInit();
            this.groupBoxRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position:";
            // 
            // numericPosX
            // 
            this.numericPosX.Location = new System.Drawing.Point(99, 57);
            this.numericPosX.Name = "numericPosX";
            this.numericPosX.Size = new System.Drawing.Size(65, 20);
            this.numericPosX.TabIndex = 1;
            this.numericPosX.ValueChanged += new System.EventHandler(this.NumericPosX_ValueChanged);
            // 
            // numericPosY
            // 
            this.numericPosY.Location = new System.Drawing.Point(167, 57);
            this.numericPosY.Name = "numericPosY";
            this.numericPosY.Size = new System.Drawing.Size(65, 20);
            this.numericPosY.TabIndex = 2;
            this.numericPosY.ValueChanged += new System.EventHandler(this.NumericPosX_ValueChanged);
            // 
            // numericSizeY
            // 
            this.numericSizeY.Location = new System.Drawing.Point(167, 79);
            this.numericSizeY.Name = "numericSizeY";
            this.numericSizeY.Size = new System.Drawing.Size(65, 20);
            this.numericSizeY.TabIndex = 5;
            this.numericSizeY.ValueChanged += new System.EventHandler(this.NumericSizeX_ValueChanged);
            // 
            // numericSizeX
            // 
            this.numericSizeX.Location = new System.Drawing.Point(99, 79);
            this.numericSizeX.Name = "numericSizeX";
            this.numericSizeX.Size = new System.Drawing.Size(65, 20);
            this.numericSizeX.TabIndex = 4;
            this.numericSizeX.ValueChanged += new System.EventHandler(this.NumericSizeX_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size:";
            // 
            // buttonRestore
            // 
            this.buttonRestore.ForeColor = System.Drawing.Color.Red;
            this.buttonRestore.Location = new System.Drawing.Point(71, 189);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(134, 23);
            this.buttonRestore.TabIndex = 8;
            this.buttonRestore.Text = "Restore Changes";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.ButtonRestore_Click);
            // 
            // comboBoxSensors
            // 
            this.comboBoxSensors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSensors.FormattingEnabled = true;
            this.comboBoxSensors.Location = new System.Drawing.Point(99, 9);
            this.comboBoxSensors.Name = "comboBoxSensors";
            this.comboBoxSensors.Size = new System.Drawing.Size(133, 21);
            this.comboBoxSensors.TabIndex = 6;
            this.comboBoxSensors.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSensors_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sensor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Type:";
            // 
            // comboBoxDisplayType
            // 
            this.comboBoxDisplayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplayType.FormattingEnabled = true;
            this.comboBoxDisplayType.Items.AddRange(new object[] {
            "Data",
            "LED",
            "Bar Graph",
            "Gauge",
            "Sensor"});
            this.comboBoxDisplayType.Location = new System.Drawing.Point(99, 33);
            this.comboBoxDisplayType.Name = "comboBoxDisplayType";
            this.comboBoxDisplayType.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDisplayType.TabIndex = 9;
            this.comboBoxDisplayType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDisplayType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "to:";
            // 
            // txtbValueMax
            // 
            this.txtbValueMax.Location = new System.Drawing.Point(184, 23);
            this.txtbValueMax.Name = "txtbValueMax";
            this.txtbValueMax.Size = new System.Drawing.Size(69, 20);
            this.txtbValueMax.TabIndex = 37;
            this.txtbValueMax.Validating += new System.ComponentModel.CancelEventHandler(this.TxtbValueMin_Validating);
            this.txtbValueMax.Validated += new System.EventHandler(this.TxtbValueMin_Validated);
            // 
            // txtbValueMin
            // 
            this.txtbValueMin.Location = new System.Drawing.Point(84, 23);
            this.txtbValueMin.Name = "txtbValueMin";
            this.txtbValueMin.Size = new System.Drawing.Size(69, 20);
            this.txtbValueMin.TabIndex = 36;
            this.txtbValueMin.Validating += new System.ComponentModel.CancelEventHandler(this.TxtbValueMin_Validating);
            this.txtbValueMin.Validated += new System.EventHandler(this.TxtbValueMin_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Range from:";
            // 
            // txtbWarnMax
            // 
            this.txtbWarnMax.Location = new System.Drawing.Point(184, 49);
            this.txtbWarnMax.Name = "txtbWarnMax";
            this.txtbWarnMax.Size = new System.Drawing.Size(69, 20);
            this.txtbWarnMax.TabIndex = 32;
            this.txtbWarnMax.Validating += new System.ComponentModel.CancelEventHandler(this.TxtbValueMin_Validating);
            this.txtbWarnMax.Validated += new System.EventHandler(this.TxtbValueMin_Validated);
            // 
            // txtbWarnMin
            // 
            this.txtbWarnMin.Location = new System.Drawing.Point(84, 49);
            this.txtbWarnMin.Name = "txtbWarnMin";
            this.txtbWarnMin.Size = new System.Drawing.Size(69, 20);
            this.txtbWarnMin.TabIndex = 31;
            this.txtbWarnMin.Validating += new System.ComponentModel.CancelEventHandler(this.TxtbValueMin_Validating);
            this.txtbWarnMin.Validated += new System.EventHandler(this.TxtbValueMin_Validated);
            // 
            // groupBoxRange
            // 
            this.groupBoxRange.Controls.Add(this.label11);
            this.groupBoxRange.Controls.Add(this.label6);
            this.groupBoxRange.Controls.Add(this.label7);
            this.groupBoxRange.Controls.Add(this.label5);
            this.groupBoxRange.Controls.Add(this.txtbValueMin);
            this.groupBoxRange.Controls.Add(this.txtbWarnMax);
            this.groupBoxRange.Controls.Add(this.txtbValueMax);
            this.groupBoxRange.Controls.Add(this.txtbWarnMin);
            this.groupBoxRange.Location = new System.Drawing.Point(7, 106);
            this.groupBoxRange.Name = "groupBoxRange";
            this.groupBoxRange.Size = new System.Drawing.Size(260, 77);
            this.groupBoxRange.TabIndex = 40;
            this.groupBoxRange.TabStop = false;
            this.groupBoxRange.Text = "Sensors Warnings/Range";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(159, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "to:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Warning from:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // frmGaugesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 217);
            this.Controls.Add(this.groupBoxRange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDisplayType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.comboBoxSensors);
            this.Controls.Add(this.numericSizeY);
            this.Controls.Add(this.numericPosY);
            this.Controls.Add(this.numericSizeX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericPosX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGaugesEditor";
            this.Text = "Gauges Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGaugesEditor_FormClosed);
            this.Load += new System.EventHandler(this.frmDebug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSizeX)).EndInit();
            this.groupBoxRange.ResumeLayout(false);
            this.groupBoxRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void SetPos()
    {
        this.CtrlDisplayItemText_0.Location = new Point((int) this.numericPosX.Value, (int) this.numericPosY.Value);
        this.CtrlDisplayItemText_0.Invalidate();
    }

    private void SetSize()
    {
        this.CtrlDisplayItemText_0.Size = new Size((int)this.numericSizeX.Value, (int)this.numericSizeY.Value);
        this.CtrlDisplayItemText_0.Invalidate();
    }

    private void NumericPosX_ValueChanged(object sender, EventArgs e)
    {
        if (!Loading) SetPos();
    }

    private void NumericSizeX_ValueChanged(object sender, EventArgs e)
    {
        if (!Loading) SetSize();
    }

    private void ComboBoxSensors_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!Loading)
        {
            if (this.CtrlDisplayItemText_0.DataDisplayType == 1) this.CtrlDisplayItemText_0.TypeLED = (DatalogLedTypes) (comboBoxSensors.SelectedIndex + 1);
            else if (this.CtrlDisplayItemText_0.DataDisplayType == 4) this.CtrlDisplayItemText_0.TypeALL = (SensorsX) comboBoxSensors.SelectedIndex;
            else this.CtrlDisplayItemText_0.Type = (DatalogDisplayTypes) (comboBoxSensors.SelectedIndex + 1);

            //if (this.CtrlDisplayItemText_0.DataDisplayType == 4) this.CtrlDisplayItemText_0.SetSensorData();
            if (this.CtrlDisplayItemText_0.DataDisplayType == 4) this.CtrlDisplayItemText_0.ResetSensorData();

            this.CtrlDisplayItemText_0.Invalidate();
        }
    }

    private void ComboBoxDisplayType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!Loading)
        {
            if (this.CtrlDisplayItemText_0.DataDisplayType != 1 && comboBoxDisplayType.SelectedIndex == 1) comboBoxDisplayType.SelectedIndex = 0;

            this.CtrlDisplayItemText_0.DataDisplayType = comboBoxDisplayType.SelectedIndex;
            ReloadSensorList();
            this.CtrlDisplayItemText_0.Invalidate();
        }
    }

    private void ButtonRestore_Click(object sender, EventArgs e)
    {
        Loading = true;

        comboBoxSensors.SelectedIndex = Default_SensorType;
        comboBoxDisplayType.SelectedIndex = Default_DataDisplayType;

        if (Default_DataDisplayType == 1) this.CtrlDisplayItemText_0.TypeLED = (DatalogLedTypes)Default_SensorType;
        else if (Default_DataDisplayType == 4) this.CtrlDisplayItemText_0.TypeALL = (SensorsX)Default_SensorType;
        else if (Default_DataDisplayType == 5) this.CtrlDisplayItemText_0.TypeBUTTON = (DatalogButtonsTypes)Default_SensorType;
        else this.CtrlDisplayItemText_0.Type = (DatalogDisplayTypes)Default_SensorType;


        this.CtrlDisplayItemText_0.DataDisplayType = Default_DataDisplayType;

        this.CtrlDisplayItemText_0.Location = new Point(DefaultPos.X, DefaultPos.Y);
        this.CtrlDisplayItemText_0.Size = new Size(DefaultSize.Width, DefaultSize.Height);

        if (GetTheSensor() != SensorsX.test0)
        {
            if ((this.Default_WarnMin != -789) && (this.Default_WarnMax != -789))
            {
                this.frmMain_0.class10_settings_0.method_21(GetTheSensor(), this.Default_WarnMin);
                this.frmMain_0.class10_settings_0.method_23(GetTheSensor(), this.Default_WarnMax);
            }
            if ((this.Default_SensorMin != -789) && (this.Default_SensorMax != -789))
            {
                this.frmMain_0.class10_settings_0.method_21_Min(GetTheSensor(), this.Default_SensorMin);
                this.frmMain_0.class10_settings_0.method_23_Max(GetTheSensor(), this.Default_SensorMax);
            }
        }

        this.CtrlDisplayItemText_0.Invalidate();

        Loading = false;
    }

    private void FrmGaugesEditor_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.CtrlDisplayItemText_0.frmGaugesEditor_0 = null;
    }

    private void TxtbValueMin_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void TxtbValueMin_Validated(object sender, EventArgs e)
    {
        ApplySensorsSettings();
    }
}

