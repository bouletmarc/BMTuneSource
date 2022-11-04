using Data;
using System;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text.RegularExpressions;

internal class frmSettings : Form
{
    private bool bool_0 = true;
    private bool bool_1;
    private Button btnDispBack;
    private Button btnDispText;
    private Button btnLedOff;
    private Button btnLedOn;
    private Button btnSave;
    private Button btnSetPrimAfr;
    private Button btnSetSecAfr;
    private CheckBox chkRateRecording;
    private CheckBox chkWbDirectInput;
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private Class25 class25_0;
    private FrmMain FrmMain_0;
    private ComboBox cmbGasType;
    private ComboBox cmbWidebandSerialPort;
    private ColorDialog colorDialog_0;
    private ErrorProvider errorProvider_0;
    private FontDialog fontDialog_0;
    private GroupBox groupBox_2;
    private GroupBox groupBox_20;
    private GroupBox groupBox_24;
    private GroupBox groupBox_25;
    private GroupBox groupBox_7;
    private GroupBox groupBox2;
    private GroupBox groupBox5;
    private GroupBox groupBox6;
    private GroupBox groupBox7;
    private GroupBox groupBox8;
    private GroupBox grpWbDeff;
    private GroupBox grpWbEcuInput;
    private IContainer icontainer_0;
    private Label label135;
    private Label label18;
    private Label label19;
    private Label label27;
    private Label label28;
    private Label label29;
    private Label label30;
    private Label label34;
    private Label label36;
    private Label label37;
    private Label label38;
    private Label label43;
    private Label label55;
    private Label label59;
    private Label label61;
    private Label label62;
    private Label label64;
    private Label label85;
    private Label lblTargetAfrL;
    private Label lblWbOffset;
    private ComboBox lstDtBaud;
    private ComboBox lstDtComm;
    private ComboBox lstQuickLambda;
    private RadioButton rAfr;
    private RadioButton rBoostBar;
    private RadioButton rBoostKpa;
    private RadioButton rBoostMbar;
    private RadioButton rBoostPsi;
    private RadioButton rCelcuis;
    private RadioButton rFarhenheit;
    private RadioButton rKph;
    private RadioButton rLambda;
    private RadioButton rMph;
    private RadioButton rMulti;
    private RadioButton rPercentage;
    private string string_0;
    private TabControl tabControl1;
    private TabPage tabDatalogDisplay;
    private TabPage tabDatalogging;
    private TabPage tabOverlayAfr;
    private TabPage tabUnits;
    private TabPage tabWideband;
    private TextBox textBox_0;
    private TextBox textBox_1;
    private TextBox textBox3;
    private TextBox textBox4;
    private ToolTip toolTip_0;
    private TrackBar trkSamplingRate;
    private TextBox txtbAfrTHigh;
    private TextBox txtbAfrTHighMbar;
    private TextBox txtbAfrTLowMbar;
    private TextBox txtbDtRetries;
    private TextBox txtbDtTimout;
    private TextBox txtbGas;
    private TextBox txtbSampleRate;
    private IContainer components;
    private Label label20;
    private Label label82;
    private Label label35;
    private Button btnSelectedColor;
    private Button btnTrailColor;
    private Button btnTraceColor;
    private DataGridView gridWb;
    private ComboBox comboBoxEcuInput;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private CheckBox chkEmuAuto;
    private Label label17;
    private ComboBox lstEmulator;
    private GroupBox grpEmuCommAdv;
    private ComboBox lstEmuBaud;
    private Label label24;
    private ComboBox lstEmuPort;
    private Label label25;
    private CheckBox chkEmuAlwaysRt;
    private Label labelemurt;
    private CheckBox chkRecordOnConnection;
    private GroupBox groupBox1;
    private Label lblTargetAfr;
    private Label label72;
    private Label label40;
    private TextBox txtbAdjVe;
    private Label label39;
    private Label label7;
    private Label label6;
    private Label label5;
    private TextBox txtbAdjTargetAf;
    private Label label4;
    private TextBox txtbAdjFuelTableFv;
    private TextBox txtbAdjFuelTableSwitch;
    private Label label3;
    private TextBox txtbAdjFuelTablePrecent;
    private Label label2;
    private TextBox txtbAdjIgnTable;
    private Label label1;
    private TextBox txtbWbOffset;
    private GroupBox groupBox_9;
    private TrackBar trkSmooth;
    private TextBox txtbSmooth;
    private Label label69;
    private CheckBox chkSmoothRows;
    private GroupBox groupBox_23;
    private RadioButton rbSelNodeSquare;
    private RadioButton rbSelNodeFill;
    private TabPage tabAnalog1;
    private GroupBox groupBox_13;
    private TextBox txtbAnalog1Dec;
    private Label label91;
    private TextBox txtbAnalog1Val;
    private Label label160;
    private CheckBox chkAnalog1Enable;
    private Label label157;
    private DataGridView gridAnalog1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private GroupBox groupBox10;
    private DataGridView gridAnalog3;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private TextBox txtbAnalog3Dec;
    private Label label13;
    private TextBox txtbAnalog3Val;
    private Label label16;
    private CheckBox chkAnalog3Enable;
    private Label label21;
    private GroupBox groupBox9;
    private DataGridView gridAnalog2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private TextBox txtbAnalog2Dec;
    private Label label8;
    private TextBox txtbAnalog2Val;
    private Label label9;
    private CheckBox chkAnalog2Enable;
    private Button button2;
    private Button button4;
    private Label label22;
    private Button button3;
    private Label label10;

    private float StartScaleRate = 100;

    private Color last_color1Dark;
    private Color last_color1;
    private Color last_color2;
    private Color last_color3;
    private Color last_color4;
    private Color last_color5;
    private Color last_color6;
    private Color last_color7;
    private Color last_color8;
    private Color last_color9;
    private Color last_color10;
    private Color last_color11;
    private Color last_color12;
    private Color last_color13;
    private Color last_color14;
    private Color last_color15;

    private Color last_color20;
    private Color last_color21;
    private Color last_color22;
    private Color last_color23;
    private Color last_color30;
    private Color last_color31;
    private Color last_color32;
    private Color last_color33;
    private Color last_color40;
    private Color last_color41;
    private string last_Percent1;
    private string last_Percent2;
    private string last_PercentIgn;

    private bool ColorMenuOpened = false;
    private Button button5;
    private Label label26;
    private Button button6;
    private Label label31;
    private GroupBox grpVacumn;
    private RadioButton rVacumnKpa;
    private RadioButton rVacumnPsi;
    private RadioButton rVacumnMbar;
    private RadioButton rVacumnBar;
    private Label label32;
    private TabPage tabAutoAdjust;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private GroupBox groupBox_1;
    private Label label14;
    private TextBox txtbSelectioAvgNeeded;
    private Label label12;
    private CheckBox chkTunerFilterAuto;
    private TextBox txtbSTD;
    private Label label11;
    private Label label68;
    private Label label67;
    private TextBox txtbFuelAjdP;
    private Label label66;
    private TextBox txtbFuelAjdMax;
    private TextBox txtbFuelAdjMin;
    private Label label65;
    private Label label15;
    private GroupBox groupBox11;
    private CheckBox gear0;
    private CheckBox gear5;
    private CheckBox gear4;
    private CheckBox gear3;
    private CheckBox gear2;
    private CheckBox gear1;
    private CheckBox chkCheckFuelCut;
    private Label label46;
    private CheckBox chkLastSampleDiffo2;
    private Label lblIat;
    private TextBox txtbIatMax;
    private Label label56;
    private TextBox txtbIatMin;
    private Label label57;
    private Label lblEct;
    private TextBox txtbEctMax;
    private Label label53;
    private TextBox txtbEctMin;
    private Label label54;
    private Label label49;
    private TextBox txtbMapMax;
    private Label label50;
    private TextBox txtbMapMin;
    private Label label51;
    private TextBox txtbRpmMax;
    private Label label47;
    private TextBox txtbRpmMin;
    private Label label48;
    private TextBox txtbAfrMax;
    private Label label44;
    private TextBox txtbAfrMin;
    private Label label45;
    private TextBox txtbTpsMax;
    private Label label58;
    private TextBox txtbTpsMin;
    private Label label60;
    private Label label33;
    private TextBox txtbHitDelay;
    private Label label42;
    private RadioButton rVacumnInHgG;
    private RadioButton rBoostInHg;
    private GroupBox groupBox12;
    private TextBox txtFuel1;
    private Label label52;
    private Label label41;
    private Button btnIgn4;
    private Button btnFuel4;
    private Button btnIgn3;
    private Button btnIgn2;
    private Button btnFuel3;
    private Button btnFuel2;
    private Button btnFuel1;
    private Label label74;
    private Button btnIgn1;
    private Label label75;
    private Label label76;
    private Label label77;
    private TextBox txtIgn;
    private Label label78;
    private Label label80;
    private Label label81;
    private Label label73;
    private Label label70;
    private TextBox txtFuel2;
    private Label label71;
    private Label label63;
    private Label label79;
    private Button btnVE2;
    private Button btnVE1;
    private Label label86;
    private Label label83;
    private Button button7;
    private Button button1;
    private ComboBox cmbWbDirectType;
    private CheckBox chkUsePa;
    private Label label84;
    private TextBox txtbSeaLevel;
    private Label label23;
    private Label label87;
    private Button button8;
    private Label label88;
    private GroupBox groupBox14;
    private GroupBox groupBox13;
    private Label label89;
    private Button button9;
    private Button button10;
    private Label label90;
    private PictureBox pictureBox2;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    private OpenFileDialog openFileDialog2;
    private Button button12;
    private Button button11;
    private PictureBox pictureBox1;
    private Button button13;
    private Label label92;
    private CheckBox chkDisableOverCond;
    private CheckBox chkStackFilter;
    private TextBox txtbMinSampVariance;
    private Label label93;
    private TextBox txtbStackSize;
    private Label label94;
    private CheckBox chkDtAuto;
    private CheckBox chkBluetooth;
    private GroupBox groupBox16;
    private GroupBox groupBox15;
    private GroupBox groupBox17;
    private CheckBox chk_LiveGraphing;
    private Label label97;
    private Label label98;
    private TextBox txt_LiveGraph_Lenght;
    private Button button_LedDark;
    private Label label99;
    private frmSensorSetup frmSensorSetup_0;
    private GroupBox groupBox18;
    private RadioButton rbTracingRowColumn;
    private RadioButton rbTracingColumn;
    private RadioButton rbTracingRow;
    private RadioButton rbTracingQuad;
    private RadioButton rbTracingSingle;
    private CheckBox chkEmuVendor;
    private Button button14;
    private LinkLabel linkLabel1;
    private Button button16;
    private Button button15;
    private SaveFileDialog saveFileDialog2;
    private OpenFileDialog openFileDialog3;
    private TextBox txtFontScale;
    private Label label95;
    private CheckBox checkBoxJ12;
    private Label labelDemonSelected;
    private TabPage tabBurner;
    private GroupBox groupBox19;
    private Label label96;
    private Label labelBurnerDesc;
    private LinkLabel linkLabel2;
    private Label label101;
    private ComboBox comboBoxBurner;
    private LinkLabel linkLabelBurner;
    private Label labelLinkBurnerName;
    private TextBox textBoxBurnerLocation;
    private Label labelBurnerLocation;
    private OpenFileDialog openFileDialog4;
    private TemperatureUnits Unit_Temperature_Load;

    public frmSettings()
    {
        this.InitializeComponent();
        this.gridWb.Rows.Add(17);
        this.gridAnalog1.Rows.Add(10);
        this.gridAnalog2.Rows.Add(10);
        this.gridAnalog3.Rows.Add(10);

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        base.Close();
        this.class10_settings_0.method_15();
    }

    private void btnDispBack_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnDispBack.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnDispBack.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnDispText_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnDispText.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnDispText.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnLedOff_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnLedOff.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnLedOff.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnLedOn_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnLedOn.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnLedOn.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        DialogResult result = saveFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            File.Create(saveFileDialog1.FileName).Dispose();
            File.WriteAllBytes(saveFileDialog1.FileName, File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\SettingsV2.xml"));
        }
    }

    private void btnSelectedColor_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnTrailColor.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnSelectedColor.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnSetPrimAfr_Click(object sender, EventArgs e)
    {
        this.method_2();
        this.class10_settings_0.method_4(false);
    }

    private void btnSetSecAfr_Click(object sender, EventArgs e)
    {
        this.method_2();
        this.class10_settings_0.method_4(true);
    }

    private void btnTraceColor_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnTraceColor.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnTraceColor.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnTrailColor_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnTrailColor.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnTrailColor.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void checkBox_6_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_2();
            this.method_1();
        }
    }

    private void chkDtAuto_CheckedChanged(object sender, EventArgs e)
    {
        if (this.class10_settings_0.dataloggingMode_0 != DataloggingMode.datalogDemon)
        {
            this.lstDtComm.Enabled = !this.chkDtAuto.Checked;
            this.lstDtBaud.Enabled = !this.chkDtAuto.Checked;
        }
        if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP) chkEmuAuto.Checked = chkDtAuto.Checked;
    }

    private void chkEmuAuto_CheckedChanged(object sender, EventArgs e)
    {
        if (this.class10_settings_0.emulatorMode_0 != EmulatorMode.PGMFI_RTP)
        {
            this.lstEmuPort.Enabled = !this.chkEmuAuto.Checked;
            this.lstEmuBaud.Enabled = !this.chkEmuAuto.Checked;
        }
        if (this.class10_settings_0.dataloggingMode_0 == DataloggingMode.datalogDemon) chkDtAuto.Checked = chkEmuAuto.Checked;
    }

    private void chkWbDirectInput_CheckedChanged(object sender, EventArgs e)
    {
        this.grpWbEcuInput.Enabled = !this.chkWbDirectInput.Checked;
        this.grpWbDeff.Enabled = !this.chkWbDirectInput.Checked;
        this.gridWb.Enabled = !this.chkWbDirectInput.Checked;
        this.lstQuickLambda.SelectedIndex = 0;
        this.class10_settings_0.int_8 = 0;
        this.class10_settings_0.double_0 = this.method_4(3);
        this.method_3();
        this.txtbWbOffset.Text = "0";
        if (!this.bool_0)
        {
            this.method_2();
        }
    }

    private void cmbGasType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.bool_1 = true;
        switch (this.cmbGasType.SelectedIndex)
        {
            case 1:
                this.txtbGas.Text = 14.7.ToString();
                break;

            case 2:
                this.txtbGas.Text = 14.6.ToString();
                break;

            case 3:
                this.txtbGas.Text = 1.0.ToString();
                break;

            case 4:
                this.txtbGas.Text = 6.4.ToString();
                break;

            case 5:
                this.txtbGas.Text = 9.0.ToString();
                break;

            case 6:
                this.txtbGas.Text = 11.5.ToString();
                break;

            case 7:
                this.txtbGas.Text = 11.7.ToString();
                break;

            case 8:
                this.txtbGas.Text = 12.1.ToString();
                break;

            case 9:
                this.txtbGas.Text = 13.74.ToString();
                break;
        }
        this.class10_settings_0.int_9 = this.cmbGasType.SelectedIndex;
        this.class10_settings_0.double_3 = double.Parse(this.txtbGas.Text);
        this.method_1();
        this.bool_1 = false;
    }

    private void cmbWbDirectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.method_2();
            this.class17_0.class2_serialWB_0.method_0();
            this.method_1();
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

    public void ReloadDefaultColor()
    {
        this.last_color1Dark = this.button_LedDark.BackColor;
        this.last_color1 = this.btnLedOn.BackColor;
        this.last_color2 = this.btnLedOff.BackColor;
        this.last_color3 = this.btnDispBack.BackColor;
        this.last_color4 = this.btnDispText.BackColor;
        this.last_color5 = this.btnTrailColor.BackColor;
        this.last_color6 = this.btnTraceColor.BackColor;
        this.last_color7 = this.btnSelectedColor.BackColor;
        this.last_color8 = this.button3.BackColor;
        this.last_color9 = this.button4.BackColor;
        this.last_color10 = this.button6.BackColor;
        this.last_color11 = this.button5.BackColor;
        this.last_color12 = this.button8.BackColor;
        this.last_color13 = this.button9.BackColor;
        this.last_color14 = this.button10.BackColor;
        this.last_color15 = this.button13.BackColor;

        this.last_color20 = this.btnFuel1.BackColor;
        this.last_color21 = this.btnFuel2.BackColor;
        this.last_color22 = this.btnFuel3.BackColor;
        this.last_color23 = this.btnFuel4.BackColor;
        this.last_color30 = this.btnIgn1.BackColor;
        this.last_color31 = this.btnIgn2.BackColor;
        this.last_color32 = this.btnIgn3.BackColor;
        this.last_color33 = this.btnIgn4.BackColor;
        this.last_color40 = this.btnVE1.BackColor;
        this.last_color41 = this.btnVE2.BackColor;
        this.last_Percent1 = this.txtFuel1.Text;
        this.last_Percent2 = this.txtFuel2.Text;
        this.last_PercentIgn = this.txtIgn.Text;
    }

    private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
    {
        GC.Collect(3, GCCollectionMode.Forced);
    }

    private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.method_2();
        this.class10_settings_0.method_2();
        this.class10_settings_0.method_15();

        bool HasReloadedWindowsAlready = false;

        if (ColorMenuOpened)
        {
            bool Changed = false;
            if (this.last_color1Dark != this.button_LedDark.BackColor) Changed = true;
            if (this.last_color1 != this.btnLedOn.BackColor) Changed = true;
            if (this.last_color2 != this.btnLedOff.BackColor) Changed = true;
            if (this.last_color3 != this.btnDispBack.BackColor) Changed = true;
            if (this.last_color4 != this.btnDispText.BackColor) Changed = true;
            if (this.last_color5 != this.btnTrailColor.BackColor) Changed = true;
            if (this.last_color6 != this.btnTraceColor.BackColor) Changed = true;
            if (this.last_color7 != this.btnSelectedColor.BackColor) Changed = true;
            if (this.last_color8 != this.button3.BackColor) Changed = true;
            if (this.last_color9 != this.button4.BackColor) Changed = true;
            if (this.last_color10 != this.button6.BackColor) Changed = true;
            if (this.last_color11 != this.button5.BackColor) Changed = true;
            if (this.last_color12 != this.button8.BackColor) Changed = true;
            if (this.last_color13 != this.button9.BackColor) Changed = true;
            if (this.last_color14 != this.button10.BackColor) Changed = true;
            if (this.last_color15 != this.button13.BackColor) Changed = true;

            if (this.last_color20 != this.btnFuel1.BackColor) Changed = true;
            if (this.last_color21 != this.btnFuel2.BackColor) Changed = true;
            if (this.last_color22 != this.btnFuel3.BackColor) Changed = true;
            if (this.last_color23 != this.btnFuel4.BackColor) Changed = true;
            if (this.last_color30 != this.btnIgn1.BackColor) Changed = true;
            if (this.last_color31 != this.btnIgn2.BackColor) Changed = true;
            if (this.last_color32 != this.btnIgn3.BackColor) Changed = true;
            if (this.last_color33 != this.btnIgn4.BackColor) Changed = true;
            if (this.last_color40 != this.btnVE1.BackColor) Changed = true;
            if (this.last_color41 != this.btnVE2.BackColor) Changed = true;
            if (this.last_Percent1 != this.txtFuel1.Text) Changed = true;
            if (this.last_Percent2 != this.txtFuel2.Text) Changed = true;
            if (this.last_PercentIgn != this.txtIgn.Text) Changed = true;

            if (Changed)
            {
                MessageBox.Show(Form.ActiveForm, "Color settings has changed!" + Environment.NewLine + "Windows will be reloading" + Environment.NewLine + "this may take some times.", "BMTune");
                this.CloseWindows();
                this.ReopenWindows(sender, e);
                HasReloadedWindowsAlready = true;
                ReloadDefaultColor();
            }
        }

        //Check for units changed
        if (this.class10_settings_0.scaleRate != this.StartScaleRate)
        {
            if (!HasReloadedWindowsAlready)
            {
                MessageBox.Show(Form.ActiveForm, "Text/Font Scale has changed!" + Environment.NewLine + "Windows will be reloading this may take some times." + Environment.NewLine + "WE STRONGLY recommand to restart BMTune to fully reload Text/Font scale everywhere!", "BMTune");
                this.CloseWindows();
                this.ReopenWindows(sender, e);
            }
            else
            {
                MessageBox.Show(Form.ActiveForm, "Text/Font Scale has changed!" + Environment.NewLine + "WE STRONGLY recommand to restart BMTune to fully reload Text/Font scale everywhere!", "BMTune");
            }
        }

        if (this.class10_settings_0.temperatureUnits_0 != Unit_Temperature_Load)
        {
            if (MessageBox.Show(Form.ActiveForm, "Temperature unit has changed!" + Environment.NewLine + "Do you want to reset sensors min/max value range aswell as there warnings values with the new unit?" + Environment.NewLine + "**This reset value in 'Edit Limits/Warnings'**", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                for (int i = 0; i < 2; i++)
                {
                    SensorsX ThisSensor = SensorsX.ectX;
                    if (i == 1) ThisSensor = SensorsX.iatX;
                    if (this.class10_settings_0.temperatureUnits_0 == TemperatureUnits.F)
                    {
                        this.class10_settings_0.method_21(ThisSensor, (int)this.class18_0.method_242(this.class10_settings_0.method_20(ThisSensor)));
                        this.class10_settings_0.method_23(ThisSensor, (int)this.class18_0.method_242(this.class10_settings_0.method_22(ThisSensor)));
                        this.class10_settings_0.method_21_Min(ThisSensor, (int)this.class18_0.method_242(this.class10_settings_0.method_20_Min(ThisSensor)));
                        this.class10_settings_0.method_23_Max(ThisSensor, (int)this.class18_0.method_242(this.class10_settings_0.method_22_Max(ThisSensor)));
                    }
                    else
                    {
                        this.class10_settings_0.method_21(ThisSensor, (int)this.class18_0.method_243(this.class10_settings_0.method_20(ThisSensor)));
                        this.class10_settings_0.method_23(ThisSensor, (int)this.class18_0.method_243(this.class10_settings_0.method_22(ThisSensor)));
                        this.class10_settings_0.method_21_Min(ThisSensor, (int)this.class18_0.method_243(this.class10_settings_0.method_20_Min(ThisSensor)));
                        this.class10_settings_0.method_23_Max(ThisSensor, (int)this.class18_0.method_243(this.class10_settings_0.method_22_Max(ThisSensor)));
                    }
                }
            }
        }
    }

    private void frmSettings_Load(object sender, EventArgs e)
    {
        if (this.class17_0.class2_serialWB_0 == null)
        {
            this.class17_0.class2_serialWB_0 = new Class2_serialWB(ref this.class18_0, ref this.FrmMain_0);
            this.class17_0.class2_serialWB_0.method_0();
        }
        this.string_0 = this.tabControl1.SelectedTab.Name;

        this.grpWbDeff.Enabled = true;
        this.groupBox3.Enabled = true;
        this.groupBox_24.Enabled = true;

        this.groupBox12.Enabled = true;
        this.groupBox13.Enabled = true;
        this.groupBox14.Enabled = true;
        this.groupBox_20.Enabled = true;

        this.method_1();
        //lstEmulator_SelectedIndexChanged(sender, e);
    }

    private void gridWb_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        this.lstQuickLambda.SelectedIndex = 0;
        this.class10_settings_0.int_8 = this.lstQuickLambda.SelectedIndex;
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
            this.trkSamplingRate = new System.Windows.Forms.TrackBar();
            this.label34 = new System.Windows.Forms.Label();
            this.txtbSampleRate = new System.Windows.Forms.TextBox();
            this.btnLedOff = new System.Windows.Forms.Button();
            this.btnLedOn = new System.Windows.Forms.Button();
            this.btnDispText = new System.Windows.Forms.Button();
            this.btnDispBack = new System.Windows.Forms.Button();
            this.grpWbEcuInput = new System.Windows.Forms.GroupBox();
            this.comboBoxEcuInput = new System.Windows.Forms.ComboBox();
            this.grpWbDeff = new System.Windows.Forms.GroupBox();
            this.gridWb = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWbOffset = new System.Windows.Forms.Label();
            this.txtbWbOffset = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lstQuickLambda = new System.Windows.Forms.ComboBox();
            this.cmbGasType = new System.Windows.Forms.ComboBox();
            this.btnTraceColor = new System.Windows.Forms.Button();
            this.btnTrailColor = new System.Windows.Forms.Button();
            this.btnSelectedColor = new System.Windows.Forms.Button();
            this.chkRecordOnConnection = new System.Windows.Forms.CheckBox();
            this.trkSmooth = new System.Windows.Forms.TrackBar();
            this.chkSmoothRows = new System.Windows.Forms.CheckBox();
            this.gridAnalog1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnalog2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnalog3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtbSelectioAvgNeeded = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkTunerFilterAuto = new System.Windows.Forms.CheckBox();
            this.txtbSTD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.txtbFuelAjdP = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.txtbFuelAjdMax = new System.Windows.Forms.TextBox();
            this.txtbFuelAdjMin = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtbHitDelay = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.gear0 = new System.Windows.Forms.CheckBox();
            this.gear5 = new System.Windows.Forms.CheckBox();
            this.gear4 = new System.Windows.Forms.CheckBox();
            this.gear3 = new System.Windows.Forms.CheckBox();
            this.gear2 = new System.Windows.Forms.CheckBox();
            this.gear1 = new System.Windows.Forms.CheckBox();
            this.chkCheckFuelCut = new System.Windows.Forms.CheckBox();
            this.label46 = new System.Windows.Forms.Label();
            this.chkLastSampleDiffo2 = new System.Windows.Forms.CheckBox();
            this.txtbAfrMax = new System.Windows.Forms.TextBox();
            this.txtbAfrMin = new System.Windows.Forms.TextBox();
            this.txtbTpsMax = new System.Windows.Forms.TextBox();
            this.txtbTpsMin = new System.Windows.Forms.TextBox();
            this.btnIgn4 = new System.Windows.Forms.Button();
            this.btnFuel4 = new System.Windows.Forms.Button();
            this.btnIgn3 = new System.Windows.Forms.Button();
            this.btnIgn2 = new System.Windows.Forms.Button();
            this.btnFuel3 = new System.Windows.Forms.Button();
            this.btnFuel2 = new System.Windows.Forms.Button();
            this.btnFuel1 = new System.Windows.Forms.Button();
            this.btnIgn1 = new System.Windows.Forms.Button();
            this.btnVE2 = new System.Windows.Forms.Button();
            this.btnVE1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.txtbStackSize = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.txtbMinSampVariance = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.chkStackFilter = new System.Windows.Forms.CheckBox();
            this.chkDisableOverCond = new System.Windows.Forms.CheckBox();
            this.label97 = new System.Windows.Forms.Label();
            this.txt_LiveGraph_Lenght = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button_LedDark = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabelBurner = new System.Windows.Forms.LinkLabel();
            this.textBoxBurnerLocation = new System.Windows.Forms.TextBox();
            this.chkDtAuto = new System.Windows.Forms.CheckBox();
            this.chkEmuAuto = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDatalogging = new System.Windows.Forms.TabPage();
            this.labelDemonSelected = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.chk_LiveGraphing = new System.Windows.Forms.CheckBox();
            this.label98 = new System.Windows.Forms.Label();
            this.grpEmuCommAdv = new System.Windows.Forms.GroupBox();
            this.checkBoxJ12 = new System.Windows.Forms.CheckBox();
            this.chkEmuVendor = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.lstDtComm = new System.Windows.Forms.ComboBox();
            this.lstDtBaud = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.lstEmuPort = new System.Windows.Forms.ComboBox();
            this.lstEmuBaud = new System.Windows.Forms.ComboBox();
            this.chkBluetooth = new System.Windows.Forms.CheckBox();
            this.txtbDtRetries = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtbDtTimout = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.chkEmuAlwaysRt = new System.Windows.Forms.CheckBox();
            this.labelemurt = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lstEmulator = new System.Windows.Forms.ComboBox();
            this.label135 = new System.Windows.Forms.Label();
            this.groupBox_7 = new System.Windows.Forms.GroupBox();
            this.chkRateRecording = new System.Windows.Forms.CheckBox();
            this.tabBurner = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.labelBurnerLocation = new System.Windows.Forms.Label();
            this.labelLinkBurnerName = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.labelBurnerDesc = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.comboBoxBurner = new System.Windows.Forms.ComboBox();
            this.tabUnits = new System.Windows.Forms.TabPage();
            this.txtFontScale = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.rbTracingRowColumn = new System.Windows.Forms.RadioButton();
            this.rbTracingColumn = new System.Windows.Forms.RadioButton();
            this.rbTracingRow = new System.Windows.Forms.RadioButton();
            this.rbTracingQuad = new System.Windows.Forms.RadioButton();
            this.rbTracingSingle = new System.Windows.Forms.RadioButton();
            this.chkUsePa = new System.Windows.Forms.CheckBox();
            this.label84 = new System.Windows.Forms.Label();
            this.txtbSeaLevel = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.grpVacumn = new System.Windows.Forms.GroupBox();
            this.rVacumnInHgG = new System.Windows.Forms.RadioButton();
            this.rVacumnKpa = new System.Windows.Forms.RadioButton();
            this.rVacumnPsi = new System.Windows.Forms.RadioButton();
            this.rVacumnMbar = new System.Windows.Forms.RadioButton();
            this.rVacumnBar = new System.Windows.Forms.RadioButton();
            this.groupBox_9 = new System.Windows.Forms.GroupBox();
            this.txtbSmooth = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.groupBox_23 = new System.Windows.Forms.GroupBox();
            this.rbSelNodeSquare = new System.Windows.Forms.RadioButton();
            this.rbSelNodeFill = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTargetAfr = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtbAdjVe = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbAdjTargetAf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbAdjFuelTableFv = new System.Windows.Forms.TextBox();
            this.txtbAdjFuelTableSwitch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbAdjFuelTablePrecent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbAdjIgnTable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rBoostInHg = new System.Windows.Forms.RadioButton();
            this.rBoostKpa = new System.Windows.Forms.RadioButton();
            this.rBoostPsi = new System.Windows.Forms.RadioButton();
            this.rBoostMbar = new System.Windows.Forms.RadioButton();
            this.rBoostBar = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rMph = new System.Windows.Forms.RadioButton();
            this.rKph = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rPercentage = new System.Windows.Forms.RadioButton();
            this.rMulti = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rCelcuis = new System.Windows.Forms.RadioButton();
            this.rFarhenheit = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rAfr = new System.Windows.Forms.RadioButton();
            this.rLambda = new System.Windows.Forms.RadioButton();
            this.tabDatalogDisplay = new System.Windows.Forms.TabPage();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button12 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.txtIgn = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.txtFuel2 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.txtFuel1 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.groupBox_20 = new System.Windows.Forms.GroupBox();
            this.label99 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tabWideband = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox_25 = new System.Windows.Forms.GroupBox();
            this.label87 = new System.Windows.Forms.Label();
            this.cmbWidebandSerialPort = new System.Windows.Forms.ComboBox();
            this.cmbWbDirectType = new System.Windows.Forms.ComboBox();
            this.chkWbDirectInput = new System.Windows.Forms.CheckBox();
            this.groupBox_24 = new System.Windows.Forms.GroupBox();
            this.txtbGas = new System.Windows.Forms.TextBox();
            this.tabOverlayAfr = new System.Windows.Forms.TabPage();
            this.groupBox_2 = new System.Windows.Forms.GroupBox();
            this.btnSetSecAfr = new System.Windows.Forms.Button();
            this.btnSetPrimAfr = new System.Windows.Forms.Button();
            this.label62 = new System.Windows.Forms.Label();
            this.txtbAfrTHighMbar = new System.Windows.Forms.TextBox();
            this.txtbAfrTHigh = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.textBox_1 = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.lblTargetAfrL = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtbAfrTLowMbar = new System.Windows.Forms.TextBox();
            this.textBox_0 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tabAutoAdjust = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblIat = new System.Windows.Forms.Label();
            this.txtbIatMax = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.txtbIatMin = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.lblEct = new System.Windows.Forms.Label();
            this.txtbEctMax = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtbEctMin = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtbMapMax = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtbMapMin = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtbRpmMax = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtbRpmMin = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.groupBox_1 = new System.Windows.Forms.GroupBox();
            this.tabAnalog1 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtbAnalog3Dec = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbAnalog3Val = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkAnalog3Enable = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtbAnalog2Dec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbAnalog2Val = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkAnalog2Enable = new System.Windows.Forms.CheckBox();
            this.groupBox_13 = new System.Windows.Forms.GroupBox();
            this.txtbAnalog1Dec = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.txtbAnalog1Val = new System.Windows.Forms.TextBox();
            this.label160 = new System.Windows.Forms.Label();
            this.chkAnalog1Enable = new System.Windows.Forms.CheckBox();
            this.label157 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorDialog_0 = new System.Windows.Forms.ColorDialog();
            this.fontDialog_0 = new System.Windows.Forms.FontDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button14 = new System.Windows.Forms.Button();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamplingRate)).BeginInit();
            this.grpWbEcuInput.SuspendLayout();
            this.grpWbDeff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalog2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalog3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDatalogging.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.grpEmuCommAdv.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox_7.SuspendLayout();
            this.tabBurner.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.tabUnits.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.grpVacumn.SuspendLayout();
            this.groupBox_9.SuspendLayout();
            this.groupBox_23.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabDatalogDisplay.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox_20.SuspendLayout();
            this.tabWideband.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_25.SuspendLayout();
            this.groupBox_24.SuspendLayout();
            this.tabOverlayAfr.SuspendLayout();
            this.groupBox_2.SuspendLayout();
            this.tabAutoAdjust.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox_1.SuspendLayout();
            this.tabAnalog1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox_13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(411, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Export Settings File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolTip_0
            // 
            this.toolTip_0.AutoPopDelay = 40000;
            this.toolTip_0.InitialDelay = 100;
            this.toolTip_0.IsBalloon = true;
            this.toolTip_0.ReshowDelay = 50;
            this.toolTip_0.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_0.ToolTipTitle = "Quick Help";
            // 
            // trkSamplingRate
            // 
            this.trkSamplingRate.AutoSize = false;
            this.trkSamplingRate.BackColor = System.Drawing.Color.White;
            this.trkSamplingRate.Location = new System.Drawing.Point(167, 40);
            this.trkSamplingRate.Maximum = 30;
            this.trkSamplingRate.Name = "trkSamplingRate";
            this.trkSamplingRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trkSamplingRate.Size = new System.Drawing.Size(152, 17);
            this.trkSamplingRate.TabIndex = 2;
            this.trkSamplingRate.TickFrequency = 3;
            this.trkSamplingRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip_0.SetToolTip(this.trkSamplingRate, "Note: To much samples in a log file can be difficult to analyze.");
            this.trkSamplingRate.ValueChanged += new System.EventHandler(this.trkSamplingRate_ValueChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(10, 41);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(76, 14);
            this.label34.TabIndex = 4;
            this.label34.Text = "Sample Rate:";
            this.toolTip_0.SetToolTip(this.label34, "The amount of sample that will be skipped before UI update.");
            // 
            // txtbSampleRate
            // 
            this.txtbSampleRate.Location = new System.Drawing.Point(115, 39);
            this.txtbSampleRate.Name = "txtbSampleRate";
            this.txtbSampleRate.Size = new System.Drawing.Size(31, 20);
            this.txtbSampleRate.TabIndex = 1;
            this.toolTip_0.SetToolTip(this.txtbSampleRate, "The amount of sample that will be skipped before UI update.");
            this.txtbSampleRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbSampleRate_KeyUp);
            this.txtbSampleRate.Leave += new System.EventHandler(this.txtbSampleRate_Leave);
            this.txtbSampleRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // btnLedOff
            // 
            this.btnLedOff.Location = new System.Drawing.Point(92, 59);
            this.btnLedOff.Name = "btnLedOff";
            this.btnLedOff.Size = new System.Drawing.Size(22, 19);
            this.btnLedOff.TabIndex = 1;
            this.toolTip_0.SetToolTip(this.btnLedOff, "Set the color of led Off.");
            this.btnLedOff.UseVisualStyleBackColor = true;
            this.btnLedOff.Click += new System.EventHandler(this.btnLedOff_Click);
            // 
            // btnLedOn
            // 
            this.btnLedOn.Location = new System.Drawing.Point(92, 19);
            this.btnLedOn.Name = "btnLedOn";
            this.btnLedOn.Size = new System.Drawing.Size(22, 19);
            this.btnLedOn.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.btnLedOn, "Set the color of led On.");
            this.btnLedOn.UseVisualStyleBackColor = true;
            this.btnLedOn.Click += new System.EventHandler(this.btnLedOn_Click);
            // 
            // btnDispText
            // 
            this.btnDispText.Location = new System.Drawing.Point(92, 119);
            this.btnDispText.Name = "btnDispText";
            this.btnDispText.Size = new System.Drawing.Size(22, 19);
            this.btnDispText.TabIndex = 3;
            this.toolTip_0.SetToolTip(this.btnDispText, "Set the color of datalog display text color.");
            this.btnDispText.UseVisualStyleBackColor = true;
            this.btnDispText.Click += new System.EventHandler(this.btnDispText_Click);
            // 
            // btnDispBack
            // 
            this.btnDispBack.Location = new System.Drawing.Point(92, 16);
            this.btnDispBack.Name = "btnDispBack";
            this.btnDispBack.Size = new System.Drawing.Size(22, 19);
            this.btnDispBack.TabIndex = 2;
            this.toolTip_0.SetToolTip(this.btnDispBack, "Set the color of datalog display backcolor.");
            this.btnDispBack.UseVisualStyleBackColor = true;
            this.btnDispBack.Click += new System.EventHandler(this.btnDispBack_Click);
            // 
            // grpWbEcuInput
            // 
            this.grpWbEcuInput.Controls.Add(this.comboBoxEcuInput);
            this.grpWbEcuInput.Location = new System.Drawing.Point(8, 16);
            this.grpWbEcuInput.Name = "grpWbEcuInput";
            this.grpWbEcuInput.Size = new System.Drawing.Size(229, 46);
            this.grpWbEcuInput.TabIndex = 0;
            this.grpWbEcuInput.TabStop = false;
            this.grpWbEcuInput.Text = "Ecu Input";
            this.toolTip_0.SetToolTip(this.grpWbEcuInput, "Select which input is used for wideband logging");
            // 
            // comboBoxEcuInput
            // 
            this.comboBoxEcuInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEcuInput.FormattingEnabled = true;
            this.comboBoxEcuInput.Items.AddRange(new object[] {
            "Eld (D10)",
            "O2 (D14)",
            "B6(B6)",
            "Egr Lift In(D12)"});
            this.comboBoxEcuInput.Location = new System.Drawing.Point(17, 18);
            this.comboBoxEcuInput.Name = "comboBoxEcuInput";
            this.comboBoxEcuInput.Size = new System.Drawing.Size(195, 22);
            this.comboBoxEcuInput.TabIndex = 4;
            // 
            // grpWbDeff
            // 
            this.grpWbDeff.Controls.Add(this.gridWb);
            this.grpWbDeff.Controls.Add(this.lblWbOffset);
            this.grpWbDeff.Controls.Add(this.txtbWbOffset);
            this.grpWbDeff.Controls.Add(this.label19);
            this.grpWbDeff.Controls.Add(this.label18);
            this.grpWbDeff.Controls.Add(this.lstQuickLambda);
            this.grpWbDeff.Location = new System.Drawing.Point(252, 4);
            this.grpWbDeff.Name = "grpWbDeff";
            this.grpWbDeff.Size = new System.Drawing.Size(280, 219);
            this.grpWbDeff.TabIndex = 3;
            this.grpWbDeff.TabStop = false;
            this.grpWbDeff.Text = "Voltage / Lambda Coversion";
            this.toolTip_0.SetToolTip(this.grpWbDeff, "Select which wideband is in use");
            // 
            // gridWb
            // 
            this.gridWb.AllowUserToAddRows = false;
            this.gridWb.AllowUserToDeleteRows = false;
            this.gridWb.AllowUserToOrderColumns = true;
            this.gridWb.AllowUserToResizeColumns = false;
            this.gridWb.AllowUserToResizeRows = false;
            this.gridWb.BackgroundColor = System.Drawing.Color.White;
            this.gridWb.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.gridWb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridWb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridWb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridWb.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridWb.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridWb.GridColor = System.Drawing.Color.Black;
            this.gridWb.Location = new System.Drawing.Point(7, 75);
            this.gridWb.MultiSelect = false;
            this.gridWb.Name = "gridWb";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridWb.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridWb.RowHeadersVisible = false;
            this.gridWb.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridWb.ShowCellToolTips = false;
            this.gridWb.ShowRowErrors = false;
            this.gridWb.Size = new System.Drawing.Size(266, 131);
            this.gridWb.TabIndex = 5;
            this.gridWb.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridWb_CellBeginEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Voltage";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 95;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Lambda";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblWbOffset
            // 
            this.lblWbOffset.AutoSize = true;
            this.lblWbOffset.Location = new System.Drawing.Point(197, 24);
            this.lblWbOffset.Name = "lblWbOffset";
            this.lblWbOffset.Size = new System.Drawing.Size(14, 14);
            this.lblWbOffset.TabIndex = 4;
            this.lblWbOffset.Text = "V";
            // 
            // txtbWbOffset
            // 
            this.txtbWbOffset.Location = new System.Drawing.Point(138, 20);
            this.txtbWbOffset.Name = "txtbWbOffset";
            this.txtbWbOffset.Size = new System.Drawing.Size(54, 20);
            this.txtbWbOffset.TabIndex = 1;
            this.toolTip_0.SetToolTip(this.txtbWbOffset, "Use offset to dial in your wideband.\r\nIf your wideband read 14.6 and BMTune read " +
        "14.3 use an offset of 0.3.");
            this.txtbWbOffset.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 14);
            this.label19.TabIndex = 2;
            this.label19.Text = "Offset Correction:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 1;
            this.label18.Text = "Wideband:";
            // 
            // lstQuickLambda
            // 
            this.lstQuickLambda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstQuickLambda.DropDownWidth = 125;
            this.lstQuickLambda.FormattingEnabled = true;
            this.lstQuickLambda.Items.AddRange(new object[] {
            "Custom",
            "Stock",
            "AEM",
            "PLX M Series",
            "FJO CW0002",
            "Innovate LC-1/LM-1",
            "Techedge",
            "Zeitronix",
            "Motec PLM",
            "JAW",
            "AEM NEW"});
            this.lstQuickLambda.Location = new System.Drawing.Point(80, 45);
            this.lstQuickLambda.Name = "lstQuickLambda";
            this.lstQuickLambda.Size = new System.Drawing.Size(193, 22);
            this.lstQuickLambda.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.lstQuickLambda, "Select which wideband is in use");
            this.lstQuickLambda.SelectedIndexChanged += new System.EventHandler(this.lstQuickLambda_SelectedIndexChanged);
            // 
            // cmbGasType
            // 
            this.cmbGasType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGasType.DropDownWidth = 140;
            this.cmbGasType.FormattingEnabled = true;
            this.cmbGasType.Items.AddRange(new object[] {
            "Custom",
            "Gasoline 14.7",
            "Gasoline w/ additive, 14.6",
            "Lambda, 1.0",
            "Methanol, 6.4",
            "Ethanol,  9.0",
            "Toluene, 11.5",
            "MTBE, 11.7",
            "ETBE/TAME, 12.1",
            "Gasoline & Toluene(70/30), 13,74"});
            this.cmbGasType.Location = new System.Drawing.Point(97, 20);
            this.cmbGasType.Name = "cmbGasType";
            this.cmbGasType.Size = new System.Drawing.Size(140, 22);
            this.cmbGasType.TabIndex = 1;
            this.toolTip_0.SetToolTip(this.cmbGasType, "Select the gas type you use.");
            this.cmbGasType.SelectedIndexChanged += new System.EventHandler(this.cmbGasType_SelectedIndexChanged);
            // 
            // btnTraceColor
            // 
            this.btnTraceColor.Location = new System.Drawing.Point(227, 19);
            this.btnTraceColor.Name = "btnTraceColor";
            this.btnTraceColor.Size = new System.Drawing.Size(22, 19);
            this.btnTraceColor.TabIndex = 26;
            this.toolTip_0.SetToolTip(this.btnTraceColor, "Set the map trace color.");
            this.btnTraceColor.UseVisualStyleBackColor = true;
            this.btnTraceColor.Click += new System.EventHandler(this.btnTraceColor_Click);
            // 
            // btnTrailColor
            // 
            this.btnTrailColor.Location = new System.Drawing.Point(227, 39);
            this.btnTrailColor.Name = "btnTrailColor";
            this.btnTrailColor.Size = new System.Drawing.Size(22, 19);
            this.btnTrailColor.TabIndex = 27;
            this.toolTip_0.SetToolTip(this.btnTrailColor, "Set the map trail color.");
            this.btnTrailColor.UseVisualStyleBackColor = true;
            this.btnTrailColor.Click += new System.EventHandler(this.btnTrailColor_Click);
            // 
            // btnSelectedColor
            // 
            this.btnSelectedColor.Location = new System.Drawing.Point(92, 79);
            this.btnSelectedColor.Name = "btnSelectedColor";
            this.btnSelectedColor.Size = new System.Drawing.Size(22, 19);
            this.btnSelectedColor.TabIndex = 28;
            this.toolTip_0.SetToolTip(this.btnSelectedColor, "Graph node select color");
            this.btnSelectedColor.UseVisualStyleBackColor = true;
            this.btnSelectedColor.Click += new System.EventHandler(this.btnSelectedColor_Click);
            // 
            // chkRecordOnConnection
            // 
            this.chkRecordOnConnection.AutoSize = true;
            this.chkRecordOnConnection.Location = new System.Drawing.Point(496, 31);
            this.chkRecordOnConnection.Name = "chkRecordOnConnection";
            this.chkRecordOnConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRecordOnConnection.Size = new System.Drawing.Size(15, 14);
            this.chkRecordOnConnection.TabIndex = 1;
            this.toolTip_0.SetToolTip(this.chkRecordOnConnection, "Selecting this option will start datalogging recording on new datalogging connect" +
        "ion");
            this.chkRecordOnConnection.UseVisualStyleBackColor = true;
            // 
            // trkSmooth
            // 
            this.trkSmooth.AutoSize = false;
            this.trkSmooth.BackColor = System.Drawing.Color.White;
            this.trkSmooth.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trkSmooth.Location = new System.Drawing.Point(10, 63);
            this.trkSmooth.Maximum = 100;
            this.trkSmooth.Name = "trkSmooth";
            this.trkSmooth.Size = new System.Drawing.Size(108, 22);
            this.trkSmooth.TabIndex = 3;
            this.trkSmooth.TickFrequency = 10;
            this.trkSmooth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip_0.SetToolTip(this.trkSmooth, "Smoothing threshold.");
            this.trkSmooth.ValueChanged += new System.EventHandler(this.trkSmooth_ValueChanged);
            // 
            // chkSmoothRows
            // 
            this.chkSmoothRows.AutoSize = true;
            this.chkSmoothRows.Location = new System.Drawing.Point(8, 17);
            this.chkSmoothRows.Name = "chkSmoothRows";
            this.chkSmoothRows.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSmoothRows.Size = new System.Drawing.Size(96, 18);
            this.chkSmoothRows.TabIndex = 0;
            this.chkSmoothRows.Text = "Smooth rows";
            this.toolTip_0.SetToolTip(this.chkSmoothRows, "Selecting this option will smooth rows. Colums are always smoothend.\r\n");
            this.chkSmoothRows.UseVisualStyleBackColor = true;
            // 
            // gridAnalog1
            // 
            this.gridAnalog1.AllowUserToAddRows = false;
            this.gridAnalog1.AllowUserToDeleteRows = false;
            this.gridAnalog1.AllowUserToOrderColumns = true;
            this.gridAnalog1.AllowUserToResizeColumns = false;
            this.gridAnalog1.AllowUserToResizeRows = false;
            this.gridAnalog1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAnalog1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridAnalog1.BackgroundColor = System.Drawing.Color.White;
            this.gridAnalog1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalog1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridAnalog1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAnalog1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAnalog1.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridAnalog1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridAnalog1.GridColor = System.Drawing.Color.Black;
            this.gridAnalog1.Location = new System.Drawing.Point(5, 68);
            this.gridAnalog1.MultiSelect = false;
            this.gridAnalog1.Name = "gridAnalog1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalog1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridAnalog1.RowHeadersVisible = false;
            this.gridAnalog1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAnalog1.ShowCellToolTips = false;
            this.gridAnalog1.ShowRowErrors = false;
            this.gridAnalog1.Size = new System.Drawing.Size(159, 135);
            this.gridAnalog1.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.gridAnalog1, "Table used for calculating real life values for analog input.");
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Voltage";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridAnalog2
            // 
            this.gridAnalog2.AllowUserToAddRows = false;
            this.gridAnalog2.AllowUserToDeleteRows = false;
            this.gridAnalog2.AllowUserToOrderColumns = true;
            this.gridAnalog2.AllowUserToResizeColumns = false;
            this.gridAnalog2.AllowUserToResizeRows = false;
            this.gridAnalog2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAnalog2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridAnalog2.BackgroundColor = System.Drawing.Color.White;
            this.gridAnalog2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalog2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridAnalog2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAnalog2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAnalog2.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridAnalog2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridAnalog2.GridColor = System.Drawing.Color.Black;
            this.gridAnalog2.Location = new System.Drawing.Point(5, 68);
            this.gridAnalog2.MultiSelect = false;
            this.gridAnalog2.Name = "gridAnalog2";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalog2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridAnalog2.RowHeadersVisible = false;
            this.gridAnalog2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAnalog2.ShowCellToolTips = false;
            this.gridAnalog2.ShowRowErrors = false;
            this.gridAnalog2.Size = new System.Drawing.Size(159, 135);
            this.gridAnalog2.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.gridAnalog2, "Table used for calculating real life values for analog input.");
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Voltage";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridAnalog3
            // 
            this.gridAnalog3.AllowUserToAddRows = false;
            this.gridAnalog3.AllowUserToDeleteRows = false;
            this.gridAnalog3.AllowUserToOrderColumns = true;
            this.gridAnalog3.AllowUserToResizeColumns = false;
            this.gridAnalog3.AllowUserToResizeRows = false;
            this.gridAnalog3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAnalog3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridAnalog3.BackgroundColor = System.Drawing.Color.White;
            this.gridAnalog3.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalog3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridAnalog3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAnalog3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAnalog3.DefaultCellStyle = dataGridViewCellStyle11;
            this.gridAnalog3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridAnalog3.GridColor = System.Drawing.Color.Black;
            this.gridAnalog3.Location = new System.Drawing.Point(5, 68);
            this.gridAnalog3.MultiSelect = false;
            this.gridAnalog3.Name = "gridAnalog3";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalog3.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridAnalog3.RowHeadersVisible = false;
            this.gridAnalog3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAnalog3.ShowCellToolTips = false;
            this.gridAnalog3.ShowRowErrors = false;
            this.gridAnalog3.Size = new System.Drawing.Size(159, 135);
            this.gridAnalog3.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.gridAnalog3, "Table used for calculating real life values for analog input.");
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Voltage";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(227, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 19);
            this.button3.TabIndex = 29;
            this.toolTip_0.SetToolTip(this.button3, "Set the color of datalog display text color.");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(227, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 19);
            this.button4.TabIndex = 31;
            this.toolTip_0.SetToolTip(this.button4, "Set the color of datalog display text color.");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(227, 99);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(22, 19);
            this.button5.TabIndex = 35;
            this.toolTip_0.SetToolTip(this.button5, "Set the color of datalog display text color.");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(92, 99);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(22, 19);
            this.button6.TabIndex = 34;
            this.toolTip_0.SetToolTip(this.button6, "Graph node select color");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(208, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 52;
            this.label14.Text = "% req";
            this.toolTip_0.SetToolTip(this.label14, "Percentage of selected cells required for a valid average fuel change.");
            // 
            // txtbSelectioAvgNeeded
            // 
            this.txtbSelectioAvgNeeded.Location = new System.Drawing.Point(160, 178);
            this.txtbSelectioAvgNeeded.Name = "txtbSelectioAvgNeeded";
            this.txtbSelectioAvgNeeded.Size = new System.Drawing.Size(40, 20);
            this.txtbSelectioAvgNeeded.TabIndex = 4;
            this.toolTip_0.SetToolTip(this.txtbSelectioAvgNeeded, "Percentage of selected cells required for a valid average fuel change.");
            this.txtbSelectioAvgNeeded.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(58, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 14);
            this.label12.TabIndex = 50;
            this.label12.Text = "Selection Avg:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip_0.SetToolTip(this.label12, "Percentage of selected cells required for a valid average fuel change.");
            // 
            // chkTunerFilterAuto
            // 
            this.chkTunerFilterAuto.AutoSize = true;
            this.chkTunerFilterAuto.Location = new System.Drawing.Point(28, 23);
            this.chkTunerFilterAuto.Name = "chkTunerFilterAuto";
            this.chkTunerFilterAuto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTunerFilterAuto.Size = new System.Drawing.Size(108, 18);
            this.chkTunerFilterAuto.TabIndex = 5;
            this.chkTunerFilterAuto.Text = "Filter Selection";
            this.chkTunerFilterAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip_0.SetToolTip(this.chkTunerFilterAuto, "By selecting this option the selected cells will be filtered\r\nbefore calculating " +
        "an average fuel change.");
            this.chkTunerFilterAuto.UseVisualStyleBackColor = true;
            // 
            // txtbSTD
            // 
            this.txtbSTD.Location = new System.Drawing.Point(160, 83);
            this.txtbSTD.Name = "txtbSTD";
            this.txtbSTD.Size = new System.Drawing.Size(40, 20);
            this.txtbSTD.TabIndex = 3;
            this.toolTip_0.SetToolTip(this.txtbSTD, "Standard deviation done on deep stack for filtering out static/bad values.");
            this.txtbSTD.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 14);
            this.label11.TabIndex = 48;
            this.label11.Text = "STD deviation:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip_0.SetToolTip(this.label11, "Standard deviation(filtering) done on deep stack for filtering out static/bad val" +
        "ues.");
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(280, 62);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(14, 14);
            this.label68.TabIndex = 47;
            this.label68.Text = "%";
            this.toolTip_0.SetToolTip(this.label68, "The maxium fuel change that the tuner engine will recommend.");
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(208, 62);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(14, 14);
            this.label67.TabIndex = 46;
            this.label67.Text = "<";
            this.toolTip_0.SetToolTip(this.label67, "The minium fuel change that the tuner engine will recommend.");
            // 
            // txtbFuelAjdP
            // 
            this.txtbFuelAjdP.Location = new System.Drawing.Point(160, 202);
            this.txtbFuelAjdP.Name = "txtbFuelAjdP";
            this.txtbFuelAjdP.Size = new System.Drawing.Size(40, 20);
            this.txtbFuelAjdP.TabIndex = 2;
            this.toolTip_0.SetToolTip(this.txtbFuelAjdP, "This is P control for the (Target Afr- Average Afr)* P.\r\nExample (12.5-13.0)*0.75" +
        "=2.88% fuel adjustment.\r\nLowering this below 1.0 prevents overshoots.");
            this.txtbFuelAjdP.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(44, 205);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(100, 14);
            this.label66.TabIndex = 44;
            this.label66.Text = "Target-Current*P:";
            this.toolTip_0.SetToolTip(this.label66, "This is P control for the (Target Afr- Avg Afr)* P.\r\nExample (12.5-13.0)*0.75=2.8" +
        "8% fuel adjustment.\r\nLowering this below 1.0 prevents overshoots.");
            // 
            // txtbFuelAjdMax
            // 
            this.txtbFuelAjdMax.Location = new System.Drawing.Point(232, 59);
            this.txtbFuelAjdMax.Name = "txtbFuelAjdMax";
            this.txtbFuelAjdMax.Size = new System.Drawing.Size(40, 20);
            this.txtbFuelAjdMax.TabIndex = 1;
            this.toolTip_0.SetToolTip(this.txtbFuelAjdMax, "The maxium fuel change that the tuner engine will recommend.");
            this.txtbFuelAjdMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // txtbFuelAdjMin
            // 
            this.txtbFuelAdjMin.Location = new System.Drawing.Point(160, 59);
            this.txtbFuelAdjMin.Name = "txtbFuelAdjMin";
            this.txtbFuelAdjMin.Size = new System.Drawing.Size(40, 20);
            this.txtbFuelAdjMin.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.txtbFuelAdjMin, "The minium fuel change that the tuner engine will recommend.");
            this.txtbFuelAdjMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(140, 62);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(14, 14);
            this.label65.TabIndex = 1;
            this.label65.Text = ">";
            this.toolTip_0.SetToolTip(this.label65, "The maxium fuel change that the tuner engine will recommend.");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 14);
            this.label15.TabIndex = 0;
            this.label15.Text = "Min/Max fuel change:";
            this.toolTip_0.SetToolTip(this.label15, "The minium fuel change that the tuner engine will recommend.");
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(208, 110);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(27, 14);
            this.label33.TabIndex = 9;
            this.label33.Text = "hits";
            this.toolTip_0.SetToolTip(this.label33, "Number of sample hits before a hit is valid. ");
            // 
            // txtbHitDelay
            // 
            this.txtbHitDelay.Location = new System.Drawing.Point(160, 107);
            this.txtbHitDelay.Name = "txtbHitDelay";
            this.txtbHitDelay.Size = new System.Drawing.Size(40, 20);
            this.txtbHitDelay.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.txtbHitDelay, "Number of sample hits before a hit is valid. \r\nThis is curtial for wideband delay" +
        " and preventing the tip-in correction to log.\r\nTry a value between 5-30.");
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(61, 110);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(83, 14);
            this.label42.TabIndex = 1;
            this.label42.Text = "Update Delay:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip_0.SetToolTip(this.label42, "Number of sample hits before a hit is valid. ");
            // 
            // gear0
            // 
            this.gear0.Location = new System.Drawing.Point(70, 152);
            this.gear0.Name = "gear0";
            this.gear0.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gear0.Size = new System.Drawing.Size(30, 20);
            this.gear0.TabIndex = 12;
            this.gear0.Text = "0";
            this.toolTip_0.SetToolTip(this.gear0, "Select in which gear recording is allowed");
            this.gear0.UseVisualStyleBackColor = true;
            // 
            // gear5
            // 
            this.gear5.Location = new System.Drawing.Point(158, 171);
            this.gear5.Name = "gear5";
            this.gear5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gear5.Size = new System.Drawing.Size(30, 20);
            this.gear5.TabIndex = 17;
            this.gear5.Text = "5";
            this.toolTip_0.SetToolTip(this.gear5, "Select in which gear recording is allowed");
            this.gear5.UseVisualStyleBackColor = true;
            // 
            // gear4
            // 
            this.gear4.Location = new System.Drawing.Point(158, 153);
            this.gear4.Name = "gear4";
            this.gear4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gear4.Size = new System.Drawing.Size(30, 20);
            this.gear4.TabIndex = 16;
            this.gear4.Text = "4";
            this.toolTip_0.SetToolTip(this.gear4, "Select in which gear recording is allowed");
            this.gear4.UseVisualStyleBackColor = true;
            // 
            // gear3
            // 
            this.gear3.Location = new System.Drawing.Point(114, 171);
            this.gear3.Name = "gear3";
            this.gear3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gear3.Size = new System.Drawing.Size(30, 20);
            this.gear3.TabIndex = 15;
            this.gear3.Text = "3";
            this.toolTip_0.SetToolTip(this.gear3, "Select in which gear recording is allowed");
            this.gear3.UseVisualStyleBackColor = true;
            // 
            // gear2
            // 
            this.gear2.Location = new System.Drawing.Point(114, 153);
            this.gear2.Name = "gear2";
            this.gear2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gear2.Size = new System.Drawing.Size(30, 20);
            this.gear2.TabIndex = 14;
            this.gear2.Text = "2";
            this.toolTip_0.SetToolTip(this.gear2, "Select in which gear recording is allowed");
            this.gear2.UseVisualStyleBackColor = true;
            // 
            // gear1
            // 
            this.gear1.Location = new System.Drawing.Point(70, 171);
            this.gear1.Name = "gear1";
            this.gear1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gear1.Size = new System.Drawing.Size(30, 20);
            this.gear1.TabIndex = 13;
            this.gear1.Text = "1";
            this.toolTip_0.SetToolTip(this.gear1, "Select in which gear recording is allowed");
            this.gear1.UseVisualStyleBackColor = true;
            // 
            // chkCheckFuelCut
            // 
            this.chkCheckFuelCut.Location = new System.Drawing.Point(37, 195);
            this.chkCheckFuelCut.Name = "chkCheckFuelCut";
            this.chkCheckFuelCut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCheckFuelCut.Size = new System.Drawing.Size(151, 17);
            this.chkCheckFuelCut.TabIndex = 18;
            this.chkCheckFuelCut.Text = "Update during FuelCut";
            this.chkCheckFuelCut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip_0.SetToolTip(this.chkCheckFuelCut, "This option will prevent recording during fuelCut.\r\n");
            this.chkCheckFuelCut.UseVisualStyleBackColor = true;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(20, 163);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(35, 14);
            this.label46.TabIndex = 40;
            this.label46.Text = "Gear:";
            this.toolTip_0.SetToolTip(this.label46, "Select in which gear recording is allowed");
            // 
            // chkLastSampleDiffo2
            // 
            this.chkLastSampleDiffo2.Location = new System.Drawing.Point(30, 216);
            this.chkLastSampleDiffo2.Name = "chkLastSampleDiffo2";
            this.chkLastSampleDiffo2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLastSampleDiffo2.Size = new System.Drawing.Size(163, 20);
            this.chkLastSampleDiffo2.TabIndex = 20;
            this.chkLastSampleDiffo2.Text = "Update only if o2 change";
            this.chkLastSampleDiffo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip_0.SetToolTip(this.chkLastSampleDiffo2, "By selecting this option the recorded afr is only send to the stack if\r\nthe curre" +
        "nt afr from the current cell changed.");
            this.chkLastSampleDiffo2.UseVisualStyleBackColor = true;
            // 
            // txtbAfrMax
            // 
            this.txtbAfrMax.Location = new System.Drawing.Point(129, 38);
            this.txtbAfrMax.Name = "txtbAfrMax";
            this.txtbAfrMax.Size = new System.Drawing.Size(41, 20);
            this.txtbAfrMax.TabIndex = 3;
            this.toolTip_0.SetToolTip(this.txtbAfrMax, "Maximum AFR  for a valid recording");
            // 
            // txtbAfrMin
            // 
            this.txtbAfrMin.Location = new System.Drawing.Point(63, 38);
            this.txtbAfrMin.Name = "txtbAfrMin";
            this.txtbAfrMin.Size = new System.Drawing.Size(41, 20);
            this.txtbAfrMin.TabIndex = 2;
            this.toolTip_0.SetToolTip(this.txtbAfrMin, "Minimum AFR  for a valid recording");
            // 
            // txtbTpsMax
            // 
            this.txtbTpsMax.Location = new System.Drawing.Point(129, 15);
            this.txtbTpsMax.Name = "txtbTpsMax";
            this.txtbTpsMax.Size = new System.Drawing.Size(41, 20);
            this.txtbTpsMax.TabIndex = 1;
            this.toolTip_0.SetToolTip(this.txtbTpsMax, "Maximum tps  for a valid recording");
            // 
            // txtbTpsMin
            // 
            this.txtbTpsMin.Location = new System.Drawing.Point(63, 15);
            this.txtbTpsMin.Name = "txtbTpsMin";
            this.txtbTpsMin.Size = new System.Drawing.Size(41, 20);
            this.txtbTpsMin.TabIndex = 0;
            this.toolTip_0.SetToolTip(this.txtbTpsMin, "Minimum Tps for a valid recording");
            // 
            // btnIgn4
            // 
            this.btnIgn4.Location = new System.Drawing.Point(147, 89);
            this.btnIgn4.Name = "btnIgn4";
            this.btnIgn4.Size = new System.Drawing.Size(22, 19);
            this.btnIgn4.TabIndex = 51;
            this.toolTip_0.SetToolTip(this.btnIgn4, "Set the color of datalog display text color.");
            this.btnIgn4.UseVisualStyleBackColor = true;
            this.btnIgn4.Click += new System.EventHandler(this.btnIgn4_Click);
            // 
            // btnFuel4
            // 
            this.btnFuel4.Location = new System.Drawing.Point(28, 89);
            this.btnFuel4.Name = "btnFuel4";
            this.btnFuel4.Size = new System.Drawing.Size(22, 19);
            this.btnFuel4.TabIndex = 50;
            this.toolTip_0.SetToolTip(this.btnFuel4, "Graph node select color");
            this.btnFuel4.UseVisualStyleBackColor = true;
            this.btnFuel4.Click += new System.EventHandler(this.btnFuel4_Click);
            // 
            // btnIgn3
            // 
            this.btnIgn3.Location = new System.Drawing.Point(147, 70);
            this.btnIgn3.Name = "btnIgn3";
            this.btnIgn3.Size = new System.Drawing.Size(22, 19);
            this.btnIgn3.TabIndex = 47;
            this.toolTip_0.SetToolTip(this.btnIgn3, "Set the color of datalog display text color.");
            this.btnIgn3.UseVisualStyleBackColor = true;
            this.btnIgn3.Click += new System.EventHandler(this.btnIgn3_Click);
            // 
            // btnIgn2
            // 
            this.btnIgn2.Location = new System.Drawing.Point(147, 51);
            this.btnIgn2.Name = "btnIgn2";
            this.btnIgn2.Size = new System.Drawing.Size(22, 19);
            this.btnIgn2.TabIndex = 45;
            this.toolTip_0.SetToolTip(this.btnIgn2, "Set the color of datalog display text color.");
            this.btnIgn2.UseVisualStyleBackColor = true;
            this.btnIgn2.Click += new System.EventHandler(this.btnIgn2_Click);
            // 
            // btnFuel3
            // 
            this.btnFuel3.Location = new System.Drawing.Point(28, 70);
            this.btnFuel3.Name = "btnFuel3";
            this.btnFuel3.Size = new System.Drawing.Size(22, 19);
            this.btnFuel3.TabIndex = 44;
            this.toolTip_0.SetToolTip(this.btnFuel3, "Graph node select color");
            this.btnFuel3.UseVisualStyleBackColor = true;
            this.btnFuel3.Click += new System.EventHandler(this.btnFuel3_Click);
            // 
            // btnFuel2
            // 
            this.btnFuel2.Location = new System.Drawing.Point(28, 51);
            this.btnFuel2.Name = "btnFuel2";
            this.btnFuel2.Size = new System.Drawing.Size(22, 19);
            this.btnFuel2.TabIndex = 38;
            this.toolTip_0.SetToolTip(this.btnFuel2, "Set the color of led Off.");
            this.btnFuel2.UseVisualStyleBackColor = true;
            this.btnFuel2.Click += new System.EventHandler(this.btnFuel2_Click);
            // 
            // btnFuel1
            // 
            this.btnFuel1.Location = new System.Drawing.Point(28, 32);
            this.btnFuel1.Name = "btnFuel1";
            this.btnFuel1.Size = new System.Drawing.Size(22, 19);
            this.btnFuel1.TabIndex = 37;
            this.toolTip_0.SetToolTip(this.btnFuel1, "Set the color of led On.");
            this.btnFuel1.UseVisualStyleBackColor = true;
            this.btnFuel1.Click += new System.EventHandler(this.btnFuel1_Click);
            // 
            // btnIgn1
            // 
            this.btnIgn1.Location = new System.Drawing.Point(147, 32);
            this.btnIgn1.Name = "btnIgn1";
            this.btnIgn1.Size = new System.Drawing.Size(22, 19);
            this.btnIgn1.TabIndex = 39;
            this.toolTip_0.SetToolTip(this.btnIgn1, "Set the color of datalog display text color.");
            this.btnIgn1.UseVisualStyleBackColor = true;
            this.btnIgn1.Click += new System.EventHandler(this.btnIgn1_Click);
            // 
            // btnVE2
            // 
            this.btnVE2.Location = new System.Drawing.Point(148, 116);
            this.btnVE2.Name = "btnVE2";
            this.btnVE2.Size = new System.Drawing.Size(22, 19);
            this.btnVE2.TabIndex = 69;
            this.toolTip_0.SetToolTip(this.btnVE2, "Set the color of led Off.");
            this.btnVE2.UseVisualStyleBackColor = true;
            this.btnVE2.Click += new System.EventHandler(this.btnVE2_Click);
            // 
            // btnVE1
            // 
            this.btnVE1.Location = new System.Drawing.Point(126, 116);
            this.btnVE1.Name = "btnVE1";
            this.btnVE1.Size = new System.Drawing.Size(22, 19);
            this.btnVE1.TabIndex = 68;
            this.toolTip_0.SetToolTip(this.btnVE1, "Set the color of led On.");
            this.btnVE1.UseVisualStyleBackColor = true;
            this.btnVE1.Click += new System.EventHandler(this.btnVE1_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(92, 36);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(22, 19);
            this.button8.TabIndex = 37;
            this.toolTip_0.SetToolTip(this.button8, "Set the color of datalog display text color.");
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(227, 16);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(22, 19);
            this.button9.TabIndex = 41;
            this.toolTip_0.SetToolTip(this.button9, "Set the color of datalog display text color.");
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(227, 36);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(22, 19);
            this.button10.TabIndex = 39;
            this.toolTip_0.SetToolTip(this.button10, "Set the color of datalog display backcolor.");
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(92, 56);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(22, 19);
            this.button13.TabIndex = 43;
            this.toolTip_0.SetToolTip(this.button13, "Set the color of datalog display text color.");
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // txtbStackSize
            // 
            this.txtbStackSize.Location = new System.Drawing.Point(160, 131);
            this.txtbStackSize.Name = "txtbStackSize";
            this.txtbStackSize.Size = new System.Drawing.Size(40, 20);
            this.txtbStackSize.TabIndex = 53;
            this.toolTip_0.SetToolTip(this.txtbStackSize, "The size of the deep stack(where recordings per cell are stored).\r\nUse a size fro" +
        "m 25-150.");
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(77, 134);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(67, 14);
            this.label94.TabIndex = 54;
            this.label94.Text = "Stack Size:";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip_0.SetToolTip(this.label94, "Number of sample hits before a hit is valid. ");
            // 
            // txtbMinSampVariance
            // 
            this.txtbMinSampVariance.Location = new System.Drawing.Point(160, 154);
            this.txtbMinSampVariance.Name = "txtbMinSampVariance";
            this.txtbMinSampVariance.Size = new System.Drawing.Size(40, 20);
            this.txtbMinSampVariance.TabIndex = 55;
            this.toolTip_0.SetToolTip(this.txtbMinSampVariance, "Minimum amount of sample required before new values are filtered before adding th" +
        "em to the stack.");
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(9, 157);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(135, 14);
            this.label93.TabIndex = 56;
            this.label93.Text = "Min Samples(start filter):";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip_0.SetToolTip(this.label93, "Number of sample hits before a hit is valid. ");
            // 
            // chkStackFilter
            // 
            this.chkStackFilter.AutoSize = true;
            this.chkStackFilter.Location = new System.Drawing.Point(171, 23);
            this.chkStackFilter.Name = "chkStackFilter";
            this.chkStackFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStackFilter.Size = new System.Drawing.Size(86, 18);
            this.chkStackFilter.TabIndex = 57;
            this.chkStackFilter.Text = "Stack Filter";
            this.chkStackFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip_0.SetToolTip(this.chkStackFilter, "Stack Filter:\r\nThis enables/disables the standard deviation or absolute filter on" +
        " the recorded values.\r\nThis is to filter out unacceptable values.");
            this.chkStackFilter.UseVisualStyleBackColor = true;
            // 
            // chkDisableOverCond
            // 
            this.chkDisableOverCond.AutoSize = true;
            this.chkDisableOverCond.Location = new System.Drawing.Point(370, 5);
            this.chkDisableOverCond.Name = "chkDisableOverCond";
            this.chkDisableOverCond.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDisableOverCond.Size = new System.Drawing.Size(128, 18);
            this.chkDisableOverCond.TabIndex = 7;
            this.chkDisableOverCond.Text = "Disable Conditions";
            this.chkDisableOverCond.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip_0.SetToolTip(this.chkDisableOverCond, "By selecting this option all the condition are not\r\nconsidered. It will always up" +
        "date.");
            this.chkDisableOverCond.UseVisualStyleBackColor = true;
            this.chkDisableOverCond.CheckedChanged += new System.EventHandler(this.chkDisableOverCond_CheckedChanged);
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(8, 42);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(89, 14);
            this.label97.TabIndex = 9;
            this.label97.Text = "Retain Data for:";
            this.toolTip_0.SetToolTip(this.label97, "The amount of sample that will be skipped before UI update.");
            // 
            // txt_LiveGraph_Lenght
            // 
            this.txt_LiveGraph_Lenght.Location = new System.Drawing.Point(104, 39);
            this.txt_LiveGraph_Lenght.Name = "txt_LiveGraph_Lenght";
            this.txt_LiveGraph_Lenght.Size = new System.Drawing.Size(37, 20);
            this.txt_LiveGraph_Lenght.TabIndex = 8;
            this.toolTip_0.SetToolTip(this.txt_LiveGraph_Lenght, "The amount of sample that will be skipped before UI update.");
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(333, 234);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(156, 25);
            this.button7.TabIndex = 14;
            this.button7.Text = "Edit Limits/Warnings";
            this.toolTip_0.SetToolTip(this.button7, "Edit Sensors Min/Max Limit and Warnings");
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button_LedDark
            // 
            this.button_LedDark.Location = new System.Drawing.Point(92, 39);
            this.button_LedDark.Name = "button_LedDark";
            this.button_LedDark.Size = new System.Drawing.Size(22, 19);
            this.button_LedDark.TabIndex = 37;
            this.toolTip_0.SetToolTip(this.button_LedDark, "Set the color of led On.");
            this.button_LedDark.UseVisualStyleBackColor = true;
            this.button_LedDark.Click += new System.EventHandler(this.Button14_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(273, 24);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(73, 14);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "FTDI Drivers";
            this.toolTip_0.SetToolTip(this.linkLabel1, "Clic here to download the FTDI drivers usable with most emulators and datalog dev" +
        "ices");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(388, 24);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(73, 14);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "FTDI Drivers";
            this.toolTip_0.SetToolTip(this.linkLabel2, "Clic here to download the FTDI drivers usable with most emulators and datalog dev" +
        "ices");
            // 
            // linkLabelBurner
            // 
            this.linkLabelBurner.AutoSize = true;
            this.linkLabelBurner.Location = new System.Drawing.Point(84, 101);
            this.linkLabelBurner.Name = "linkLabelBurner";
            this.linkLabelBurner.Size = new System.Drawing.Size(225, 14);
            this.linkLabelBurner.TabIndex = 17;
            this.linkLabelBurner.TabStop = true;
            this.linkLabelBurner.Text = "http://support.moates.net/flash-n-burn/";
            this.toolTip_0.SetToolTip(this.linkLabelBurner, "Clic here to redirrect to the Burner software download page.");
            this.linkLabelBurner.Visible = false;
            // 
            // textBoxBurnerLocation
            // 
            this.textBoxBurnerLocation.Location = new System.Drawing.Point(87, 123);
            this.textBoxBurnerLocation.Name = "textBoxBurnerLocation";
            this.textBoxBurnerLocation.Size = new System.Drawing.Size(436, 20);
            this.textBoxBurnerLocation.TabIndex = 19;
            this.toolTip_0.SetToolTip(this.textBoxBurnerLocation, "Double Clic to Open/Select file location");
            this.textBoxBurnerLocation.Visible = false;
            this.textBoxBurnerLocation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDoubleClick);
            // 
            // chkDtAuto
            // 
            this.chkDtAuto.AutoSize = true;
            this.chkDtAuto.Location = new System.Drawing.Point(12, 17);
            this.chkDtAuto.Name = "chkDtAuto";
            this.chkDtAuto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDtAuto.Size = new System.Drawing.Size(105, 18);
            this.chkDtAuto.TabIndex = 1;
            this.chkDtAuto.Text = "Auto-Scan Port";
            this.chkDtAuto.UseVisualStyleBackColor = true;
            this.chkDtAuto.CheckedChanged += new System.EventHandler(this.chkDtAuto_CheckedChanged);
            // 
            // chkEmuAuto
            // 
            this.chkEmuAuto.AutoSize = true;
            this.chkEmuAuto.Location = new System.Drawing.Point(12, 17);
            this.chkEmuAuto.Name = "chkEmuAuto";
            this.chkEmuAuto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEmuAuto.Size = new System.Drawing.Size(105, 18);
            this.chkEmuAuto.TabIndex = 4;
            this.chkEmuAuto.Text = "Auto-Scan Port";
            this.chkEmuAuto.UseVisualStyleBackColor = true;
            this.chkEmuAuto.CheckedChanged += new System.EventHandler(this.chkEmuAuto_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDatalogging);
            this.tabControl1.Controls.Add(this.tabBurner);
            this.tabControl1.Controls.Add(this.tabUnits);
            this.tabControl1.Controls.Add(this.tabDatalogDisplay);
            this.tabControl1.Controls.Add(this.tabWideband);
            this.tabControl1.Controls.Add(this.tabOverlayAfr);
            this.tabControl1.Controls.Add(this.tabAutoAdjust);
            this.tabControl1.Controls.Add(this.tabAnalog1);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 296);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabDatalogging
            // 
            this.tabDatalogging.Controls.Add(this.labelDemonSelected);
            this.tabDatalogging.Controls.Add(this.groupBox17);
            this.tabDatalogging.Controls.Add(this.grpEmuCommAdv);
            this.tabDatalogging.Controls.Add(this.groupBox4);
            this.tabDatalogging.Controls.Add(this.label135);
            this.tabDatalogging.Controls.Add(this.groupBox_7);
            this.tabDatalogging.Location = new System.Drawing.Point(4, 23);
            this.tabDatalogging.Name = "tabDatalogging";
            this.tabDatalogging.Size = new System.Drawing.Size(535, 269);
            this.tabDatalogging.TabIndex = 4;
            this.tabDatalogging.Text = "Emulator";
            this.tabDatalogging.UseVisualStyleBackColor = true;
            // 
            // labelDemonSelected
            // 
            this.labelDemonSelected.AutoSize = true;
            this.labelDemonSelected.ForeColor = System.Drawing.Color.Red;
            this.labelDemonSelected.Location = new System.Drawing.Point(63, 49);
            this.labelDemonSelected.Name = "labelDemonSelected";
            this.labelDemonSelected.Size = new System.Drawing.Size(403, 14);
            this.labelDemonSelected.TabIndex = 5;
            this.labelDemonSelected.Text = "When the Demon are selected as emulator, you cannot datalog on a Chip!";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.chk_LiveGraphing);
            this.groupBox17.Controls.Add(this.label97);
            this.groupBox17.Controls.Add(this.label98);
            this.groupBox17.Controls.Add(this.txt_LiveGraph_Lenght);
            this.groupBox17.Location = new System.Drawing.Point(335, 202);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(197, 65);
            this.groupBox17.TabIndex = 8;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Live Graphing(can be slow)";
            // 
            // chk_LiveGraphing
            // 
            this.chk_LiveGraphing.AutoSize = true;
            this.chk_LiveGraphing.Location = new System.Drawing.Point(30, 19);
            this.chk_LiveGraphing.Name = "chk_LiveGraphing";
            this.chk_LiveGraphing.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_LiveGraphing.Size = new System.Drawing.Size(140, 18);
            this.chk_LiveGraphing.TabIndex = 11;
            this.chk_LiveGraphing.Text = "Enable Live Graphing";
            this.chk_LiveGraphing.UseVisualStyleBackColor = true;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(147, 42);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(43, 14);
            this.label98.TabIndex = 10;
            this.label98.Text = "frames";
            // 
            // grpEmuCommAdv
            // 
            this.grpEmuCommAdv.Controls.Add(this.checkBoxJ12);
            this.grpEmuCommAdv.Controls.Add(this.chkEmuVendor);
            this.grpEmuCommAdv.Controls.Add(this.groupBox16);
            this.grpEmuCommAdv.Controls.Add(this.groupBox15);
            this.grpEmuCommAdv.Controls.Add(this.chkBluetooth);
            this.grpEmuCommAdv.Controls.Add(this.txtbDtRetries);
            this.grpEmuCommAdv.Controls.Add(this.label28);
            this.grpEmuCommAdv.Controls.Add(this.txtbDtTimout);
            this.grpEmuCommAdv.Controls.Add(this.label24);
            this.grpEmuCommAdv.Controls.Add(this.label27);
            this.grpEmuCommAdv.Controls.Add(this.label25);
            this.grpEmuCommAdv.Location = new System.Drawing.Point(3, 73);
            this.grpEmuCommAdv.Name = "grpEmuCommAdv";
            this.grpEmuCommAdv.Size = new System.Drawing.Size(529, 123);
            this.grpEmuCommAdv.TabIndex = 6;
            this.grpEmuCommAdv.TabStop = false;
            this.grpEmuCommAdv.Text = "Serial Port";
            // 
            // checkBoxJ12
            // 
            this.checkBoxJ12.AutoSize = true;
            this.checkBoxJ12.Location = new System.Drawing.Point(351, 50);
            this.checkBoxJ12.Name = "checkBoxJ12";
            this.checkBoxJ12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxJ12.Size = new System.Drawing.Size(160, 18);
            this.checkBoxJ12.TabIndex = 10;
            this.checkBoxJ12.Text = "Allow datalog with J12/J4";
            this.checkBoxJ12.UseVisualStyleBackColor = true;
            // 
            // chkEmuVendor
            // 
            this.chkEmuVendor.AutoSize = true;
            this.chkEmuVendor.Location = new System.Drawing.Point(336, 14);
            this.chkEmuVendor.Name = "chkEmuVendor";
            this.chkEmuVendor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEmuVendor.Size = new System.Drawing.Size(175, 18);
            this.chkEmuVendor.TabIndex = 9;
            this.chkEmuVendor.Text = "Check Emu Serial/VendorID";
            this.chkEmuVendor.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.lstDtComm);
            this.groupBox16.Controls.Add(this.lstDtBaud);
            this.groupBox16.Controls.Add(this.chkDtAuto);
            this.groupBox16.Location = new System.Drawing.Point(189, 18);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(132, 98);
            this.groupBox16.TabIndex = 8;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Datalog";
            // 
            // lstDtComm
            // 
            this.lstDtComm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDtComm.FormattingEnabled = true;
            this.lstDtComm.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30",
            "COM31",
            "COM32",
            "COM33",
            "COM34",
            "COM35",
            "COM36",
            "COM37",
            "COM38",
            "COM39",
            "COM40"});
            this.lstDtComm.Location = new System.Drawing.Point(5, 41);
            this.lstDtComm.Name = "lstDtComm";
            this.lstDtComm.Size = new System.Drawing.Size(120, 22);
            this.lstDtComm.TabIndex = 0;
            this.lstDtComm.DropDown += new System.EventHandler(this.lstDtComm_DropDown);
            this.lstDtComm.SelectedIndexChanged += new System.EventHandler(this.lstDtComm_SelectedIndexChanged);
            // 
            // lstDtBaud
            // 
            this.lstDtBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDtBaud.FormattingEnabled = true;
            this.lstDtBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "921600"});
            this.lstDtBaud.Location = new System.Drawing.Point(5, 68);
            this.lstDtBaud.Name = "lstDtBaud";
            this.lstDtBaud.Size = new System.Drawing.Size(120, 22);
            this.lstDtBaud.TabIndex = 1;
            this.lstDtBaud.SelectedIndexChanged += new System.EventHandler(this.lstDtBaud_SelectedIndexChanged);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.chkEmuAuto);
            this.groupBox15.Controls.Add(this.lstEmuPort);
            this.groupBox15.Controls.Add(this.lstEmuBaud);
            this.groupBox15.Location = new System.Drawing.Point(51, 18);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(132, 98);
            this.groupBox15.TabIndex = 7;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Emulator";
            // 
            // lstEmuPort
            // 
            this.lstEmuPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstEmuPort.FormattingEnabled = true;
            this.lstEmuPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30",
            "COM31",
            "COM32",
            "COM33",
            "COM34",
            "COM35",
            "COM36",
            "COM37",
            "COM38",
            "COM39",
            "COM40"});
            this.lstEmuPort.Location = new System.Drawing.Point(7, 41);
            this.lstEmuPort.Name = "lstEmuPort";
            this.lstEmuPort.Size = new System.Drawing.Size(118, 22);
            this.lstEmuPort.TabIndex = 0;
            this.lstEmuPort.DropDown += new System.EventHandler(this.lstEmuPort_DropDown);
            this.lstEmuPort.SelectedIndexChanged += new System.EventHandler(this.lstEmuPort_SelectedIndexChanged);
            // 
            // lstEmuBaud
            // 
            this.lstEmuBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstEmuBaud.FormattingEnabled = true;
            this.lstEmuBaud.Items.AddRange(new object[] {
            "38400",
            "115200",
            "921600"});
            this.lstEmuBaud.Location = new System.Drawing.Point(7, 68);
            this.lstEmuBaud.Name = "lstEmuBaud";
            this.lstEmuBaud.Size = new System.Drawing.Size(118, 22);
            this.lstEmuBaud.TabIndex = 1;
            this.lstEmuBaud.SelectedIndexChanged += new System.EventHandler(this.lstEmuBaud_SelectedIndexChanged);
            // 
            // chkBluetooth
            // 
            this.chkBluetooth.AutoSize = true;
            this.chkBluetooth.Location = new System.Drawing.Point(388, 32);
            this.chkBluetooth.Name = "chkBluetooth";
            this.chkBluetooth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBluetooth.Size = new System.Drawing.Size(123, 18);
            this.chkBluetooth.TabIndex = 5;
            this.chkBluetooth.Text = "Bluetooth Datalog";
            this.chkBluetooth.UseVisualStyleBackColor = true;
            // 
            // txtbDtRetries
            // 
            this.txtbDtRetries.Location = new System.Drawing.Point(462, 72);
            this.txtbDtRetries.Name = "txtbDtRetries";
            this.txtbDtRetries.Size = new System.Drawing.Size(44, 20);
            this.txtbDtRetries.TabIndex = 1;
            this.txtbDtRetries.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(373, 75);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(81, 14);
            this.label28.TabIndex = 1;
            this.label28.Text = "Serial Retries:";
            // 
            // txtbDtTimout
            // 
            this.txtbDtTimout.Location = new System.Drawing.Point(462, 97);
            this.txtbDtTimout.Name = "txtbDtTimout";
            this.txtbDtTimout.Size = new System.Drawing.Size(44, 20);
            this.txtbDtTimout.TabIndex = 0;
            this.txtbDtTimout.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 91);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 14);
            this.label24.TabIndex = 3;
            this.label24.Text = "Baud:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(346, 100);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(108, 14);
            this.label27.TabIndex = 0;
            this.label27.Text = "Serial Timeout(ms):";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 14);
            this.label25.TabIndex = 2;
            this.label25.Text = "Port:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.chkRecordOnConnection);
            this.groupBox4.Controls.Add(this.chkEmuAlwaysRt);
            this.groupBox4.Controls.Add(this.labelemurt);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.lstEmulator);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(529, 64);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Emulator Settings";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(359, 30);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(130, 14);
            this.label32.TabIndex = 13;
            this.label32.Text = "Record on Connection";
            // 
            // chkEmuAlwaysRt
            // 
            this.chkEmuAlwaysRt.AutoSize = true;
            this.chkEmuAlwaysRt.Location = new System.Drawing.Point(496, 12);
            this.chkEmuAlwaysRt.Name = "chkEmuAlwaysRt";
            this.chkEmuAlwaysRt.Size = new System.Drawing.Size(15, 14);
            this.chkEmuAlwaysRt.TabIndex = 8;
            this.chkEmuAlwaysRt.UseVisualStyleBackColor = true;
            // 
            // labelemurt
            // 
            this.labelemurt.AutoSize = true;
            this.labelemurt.Location = new System.Drawing.Point(359, 12);
            this.labelemurt.Name = "labelemurt";
            this.labelemurt.Size = new System.Drawing.Size(95, 14);
            this.labelemurt.TabIndex = 9;
            this.labelemurt.Text = "Realtime Update";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 14);
            this.label17.TabIndex = 3;
            this.label17.Text = "Emulator:";
            // 
            // lstEmulator
            // 
            this.lstEmulator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstEmulator.DropDownWidth = 240;
            this.lstEmulator.FormattingEnabled = true;
            this.lstEmulator.Items.AddRange(new object[] {
            "Moates Ostrich/Hondavert v1.5+",
            "Moates Demon",
            "Xtronic ROMulator",
            "PGMFI RTP",
            "CobraRTP",
            "Vitaprog/Hondavert OLD",
            "BMulator",
            "ECU-Tamer"});
            this.lstEmulator.Location = new System.Drawing.Point(72, 19);
            this.lstEmulator.Name = "lstEmulator";
            this.lstEmulator.Size = new System.Drawing.Size(184, 22);
            this.lstEmulator.TabIndex = 2;
            this.lstEmulator.SelectedIndexChanged += new System.EventHandler(this.lstEmulator_SelectedIndexChanged);
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(269, 289);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(0, 14);
            this.label135.TabIndex = 4;
            // 
            // groupBox_7
            // 
            this.groupBox_7.Controls.Add(this.label34);
            this.groupBox_7.Controls.Add(this.txtbSampleRate);
            this.groupBox_7.Controls.Add(this.chkRateRecording);
            this.groupBox_7.Controls.Add(this.trkSamplingRate);
            this.groupBox_7.Location = new System.Drawing.Point(3, 202);
            this.groupBox_7.Name = "groupBox_7";
            this.groupBox_7.Size = new System.Drawing.Size(326, 65);
            this.groupBox_7.TabIndex = 3;
            this.groupBox_7.TabStop = false;
            this.groupBox_7.Text = "Datalog Sampling Rate";
            // 
            // chkRateRecording
            // 
            this.chkRateRecording.AutoSize = true;
            this.chkRateRecording.Location = new System.Drawing.Point(90, 19);
            this.chkRateRecording.Name = "chkRateRecording";
            this.chkRateRecording.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRateRecording.Size = new System.Drawing.Size(130, 18);
            this.chkRateRecording.TabIndex = 0;
            this.chkRateRecording.Text = "Priorty in recording";
            this.chkRateRecording.UseVisualStyleBackColor = true;
            // 
            // tabBurner
            // 
            this.tabBurner.Controls.Add(this.groupBox19);
            this.tabBurner.Location = new System.Drawing.Point(4, 23);
            this.tabBurner.Name = "tabBurner";
            this.tabBurner.Size = new System.Drawing.Size(535, 269);
            this.tabBurner.TabIndex = 9;
            this.tabBurner.Text = "Burner";
            this.tabBurner.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.textBoxBurnerLocation);
            this.groupBox19.Controls.Add(this.labelBurnerLocation);
            this.groupBox19.Controls.Add(this.linkLabelBurner);
            this.groupBox19.Controls.Add(this.labelLinkBurnerName);
            this.groupBox19.Controls.Add(this.label96);
            this.groupBox19.Controls.Add(this.labelBurnerDesc);
            this.groupBox19.Controls.Add(this.linkLabel2);
            this.groupBox19.Controls.Add(this.label101);
            this.groupBox19.Controls.Add(this.comboBoxBurner);
            this.groupBox19.Location = new System.Drawing.Point(3, 3);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(529, 153);
            this.groupBox19.TabIndex = 6;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Burner Settings";
            // 
            // labelBurnerLocation
            // 
            this.labelBurnerLocation.AutoSize = true;
            this.labelBurnerLocation.Location = new System.Drawing.Point(7, 126);
            this.labelBurnerLocation.Name = "labelBurnerLocation";
            this.labelBurnerLocation.Size = new System.Drawing.Size(57, 14);
            this.labelBurnerLocation.TabIndex = 18;
            this.labelBurnerLocation.Text = "Location:";
            this.labelBurnerLocation.Visible = false;
            // 
            // labelLinkBurnerName
            // 
            this.labelLinkBurnerName.AutoSize = true;
            this.labelLinkBurnerName.Location = new System.Drawing.Point(7, 101);
            this.labelLinkBurnerName.Name = "labelLinkBurnerName";
            this.labelLinkBurnerName.Size = new System.Drawing.Size(32, 14);
            this.labelLinkBurnerName.TabIndex = 16;
            this.labelLinkBurnerName.Text = "Link:";
            this.labelLinkBurnerName.Visible = false;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(7, 51);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(73, 14);
            this.label96.TabIndex = 15;
            this.label96.Text = "Description:";
            // 
            // labelBurnerDesc
            // 
            this.labelBurnerDesc.AutoSize = true;
            this.labelBurnerDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelBurnerDesc.Location = new System.Drawing.Point(86, 51);
            this.labelBurnerDesc.Name = "labelBurnerDesc";
            this.labelBurnerDesc.Size = new System.Drawing.Size(224, 14);
            this.labelBurnerDesc.TabIndex = 7;
            this.labelBurnerDesc.Text = "This uses the internal chip burner code.";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(7, 24);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(46, 14);
            this.label101.TabIndex = 3;
            this.label101.Text = "Burner:";
            // 
            // comboBoxBurner
            // 
            this.comboBoxBurner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBurner.DropDownWidth = 240;
            this.comboBoxBurner.FormattingEnabled = true;
            this.comboBoxBurner.Items.AddRange(new object[] {
            "Integrated (BMBurner/Burn2)",
            "Moates Flash & Burn 2",
            "Mini Pro"});
            this.comboBoxBurner.Location = new System.Drawing.Point(87, 19);
            this.comboBoxBurner.Name = "comboBoxBurner";
            this.comboBoxBurner.Size = new System.Drawing.Size(257, 22);
            this.comboBoxBurner.TabIndex = 2;
            this.comboBoxBurner.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabUnits
            // 
            this.tabUnits.Controls.Add(this.txtFontScale);
            this.tabUnits.Controls.Add(this.label95);
            this.tabUnits.Controls.Add(this.groupBox18);
            this.tabUnits.Controls.Add(this.chkUsePa);
            this.tabUnits.Controls.Add(this.label84);
            this.tabUnits.Controls.Add(this.txtbSeaLevel);
            this.tabUnits.Controls.Add(this.label23);
            this.tabUnits.Controls.Add(this.grpVacumn);
            this.tabUnits.Controls.Add(this.groupBox_9);
            this.tabUnits.Controls.Add(this.groupBox_23);
            this.tabUnits.Controls.Add(this.groupBox1);
            this.tabUnits.Controls.Add(this.groupBox2);
            this.tabUnits.Controls.Add(this.groupBox6);
            this.tabUnits.Controls.Add(this.groupBox8);
            this.tabUnits.Controls.Add(this.groupBox7);
            this.tabUnits.Controls.Add(this.groupBox5);
            this.tabUnits.Location = new System.Drawing.Point(4, 23);
            this.tabUnits.Name = "tabUnits";
            this.tabUnits.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnits.Size = new System.Drawing.Size(535, 269);
            this.tabUnits.TabIndex = 1;
            this.tabUnits.Text = "Units";
            this.tabUnits.UseVisualStyleBackColor = true;
            // 
            // txtFontScale
            // 
            this.txtFontScale.Location = new System.Drawing.Point(123, 10);
            this.txtFontScale.Name = "txtFontScale";
            this.txtFontScale.Size = new System.Drawing.Size(36, 20);
            this.txtFontScale.TabIndex = 16;
            this.txtFontScale.Text = "100";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.Red;
            this.label95.Location = new System.Drawing.Point(10, 13);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(106, 12);
            this.label95.TabIndex = 15;
            this.label95.Text = "Text/Font Scale:";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.rbTracingRowColumn);
            this.groupBox18.Controls.Add(this.rbTracingColumn);
            this.groupBox18.Controls.Add(this.rbTracingRow);
            this.groupBox18.Controls.Add(this.rbTracingQuad);
            this.groupBox18.Controls.Add(this.rbTracingSingle);
            this.groupBox18.Location = new System.Drawing.Point(415, 37);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(117, 114);
            this.groupBox18.TabIndex = 3;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Trace Cells";
            // 
            // rbTracingRowColumn
            // 
            this.rbTracingRowColumn.AutoSize = true;
            this.rbTracingRowColumn.Location = new System.Drawing.Point(6, 89);
            this.rbTracingRowColumn.Name = "rbTracingRowColumn";
            this.rbTracingRowColumn.Size = new System.Drawing.Size(90, 18);
            this.rbTracingRowColumn.TabIndex = 4;
            this.rbTracingRowColumn.Text = "Single->R/C";
            this.rbTracingRowColumn.UseVisualStyleBackColor = true;
            this.rbTracingRowColumn.CheckedChanged += new System.EventHandler(this.RbTracingSingle_CheckedChanged);
            // 
            // rbTracingColumn
            // 
            this.rbTracingColumn.AutoSize = true;
            this.rbTracingColumn.Location = new System.Drawing.Point(6, 71);
            this.rbTracingColumn.Name = "rbTracingColumn";
            this.rbTracingColumn.Size = new System.Drawing.Size(110, 18);
            this.rbTracingColumn.TabIndex = 3;
            this.rbTracingColumn.Text = "Single->Column";
            this.rbTracingColumn.UseVisualStyleBackColor = true;
            this.rbTracingColumn.CheckedChanged += new System.EventHandler(this.RbTracingSingle_CheckedChanged);
            // 
            // rbTracingRow
            // 
            this.rbTracingRow.AutoSize = true;
            this.rbTracingRow.Location = new System.Drawing.Point(6, 53);
            this.rbTracingRow.Name = "rbTracingRow";
            this.rbTracingRow.Size = new System.Drawing.Size(92, 18);
            this.rbTracingRow.TabIndex = 2;
            this.rbTracingRow.Text = "Single->Row";
            this.rbTracingRow.UseVisualStyleBackColor = true;
            this.rbTracingRow.CheckedChanged += new System.EventHandler(this.RbTracingSingle_CheckedChanged);
            // 
            // rbTracingQuad
            // 
            this.rbTracingQuad.AutoSize = true;
            this.rbTracingQuad.Location = new System.Drawing.Point(6, 35);
            this.rbTracingQuad.Name = "rbTracingQuad";
            this.rbTracingQuad.Size = new System.Drawing.Size(54, 18);
            this.rbTracingQuad.TabIndex = 1;
            this.rbTracingQuad.Text = "Quad";
            this.rbTracingQuad.UseVisualStyleBackColor = true;
            this.rbTracingQuad.CheckedChanged += new System.EventHandler(this.RbTracingSingle_CheckedChanged);
            // 
            // rbTracingSingle
            // 
            this.rbTracingSingle.AutoSize = true;
            this.rbTracingSingle.Location = new System.Drawing.Point(6, 17);
            this.rbTracingSingle.Name = "rbTracingSingle";
            this.rbTracingSingle.Size = new System.Drawing.Size(59, 18);
            this.rbTracingSingle.TabIndex = 0;
            this.rbTracingSingle.Text = "Single";
            this.rbTracingSingle.UseVisualStyleBackColor = true;
            this.rbTracingSingle.CheckedChanged += new System.EventHandler(this.RbTracingSingle_CheckedChanged);
            // 
            // chkUsePa
            // 
            this.chkUsePa.AutoSize = true;
            this.chkUsePa.Location = new System.Drawing.Point(386, 11);
            this.chkUsePa.Name = "chkUsePa";
            this.chkUsePa.Size = new System.Drawing.Size(133, 18);
            this.chkUsePa.TabIndex = 14;
            this.chkUsePa.Text = "Use PA(baro) sensor";
            this.chkUsePa.UseVisualStyleBackColor = true;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(343, 12);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(33, 14);
            this.label84.TabIndex = 13;
            this.label84.Text = "mBar";
            // 
            // txtbSeaLevel
            // 
            this.txtbSeaLevel.Location = new System.Drawing.Point(293, 9);
            this.txtbSeaLevel.Name = "txtbSeaLevel";
            this.txtbSeaLevel.Size = new System.Drawing.Size(43, 20);
            this.txtbSeaLevel.TabIndex = 12;
            this.txtbSeaLevel.Text = "1010";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(180, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(111, 14);
            this.label23.TabIndex = 11;
            this.label23.Text = "Sea level pressure:";
            // 
            // grpVacumn
            // 
            this.grpVacumn.Controls.Add(this.rVacumnInHgG);
            this.grpVacumn.Controls.Add(this.rVacumnKpa);
            this.grpVacumn.Controls.Add(this.rVacumnPsi);
            this.grpVacumn.Controls.Add(this.rVacumnMbar);
            this.grpVacumn.Controls.Add(this.rVacumnBar);
            this.grpVacumn.Location = new System.Drawing.Point(3, 37);
            this.grpVacumn.Name = "grpVacumn";
            this.grpVacumn.Size = new System.Drawing.Size(75, 114);
            this.grpVacumn.TabIndex = 10;
            this.grpVacumn.TabStop = false;
            this.grpVacumn.Text = "Vacuum";
            // 
            // rVacumnInHgG
            // 
            this.rVacumnInHgG.AutoSize = true;
            this.rVacumnInHgG.Location = new System.Drawing.Point(10, 50);
            this.rVacumnInHgG.Name = "rVacumnInHgG";
            this.rVacumnInHgG.Size = new System.Drawing.Size(64, 18);
            this.rVacumnInHgG.TabIndex = 5;
            this.rVacumnInHgG.TabStop = true;
            this.rVacumnInHgG.Tag = "2";
            this.rVacumnInHgG.Text = "InHg G.";
            this.rVacumnInHgG.UseVisualStyleBackColor = true;
            // 
            // rVacumnKpa
            // 
            this.rVacumnKpa.AutoSize = true;
            this.rVacumnKpa.Location = new System.Drawing.Point(10, 69);
            this.rVacumnKpa.Name = "rVacumnKpa";
            this.rVacumnKpa.Size = new System.Drawing.Size(43, 18);
            this.rVacumnKpa.TabIndex = 1;
            this.rVacumnKpa.TabStop = true;
            this.rVacumnKpa.Tag = "5";
            this.rVacumnKpa.Text = "kPa";
            this.rVacumnKpa.UseVisualStyleBackColor = true;
            // 
            // rVacumnPsi
            // 
            this.rVacumnPsi.AutoSize = true;
            this.rVacumnPsi.Location = new System.Drawing.Point(10, 88);
            this.rVacumnPsi.Name = "rVacumnPsi";
            this.rVacumnPsi.Size = new System.Drawing.Size(41, 18);
            this.rVacumnPsi.TabIndex = 4;
            this.rVacumnPsi.TabStop = true;
            this.rVacumnPsi.Tag = "4";
            this.rVacumnPsi.Text = "psi";
            this.rVacumnPsi.UseVisualStyleBackColor = true;
            // 
            // rVacumnMbar
            // 
            this.rVacumnMbar.AutoSize = true;
            this.rVacumnMbar.Location = new System.Drawing.Point(10, 13);
            this.rVacumnMbar.Name = "rVacumnMbar";
            this.rVacumnMbar.Size = new System.Drawing.Size(51, 18);
            this.rVacumnMbar.TabIndex = 0;
            this.rVacumnMbar.TabStop = true;
            this.rVacumnMbar.Tag = "0";
            this.rVacumnMbar.Text = "mBar";
            this.rVacumnMbar.UseVisualStyleBackColor = true;
            // 
            // rVacumnBar
            // 
            this.rVacumnBar.AutoSize = true;
            this.rVacumnBar.Location = new System.Drawing.Point(10, 31);
            this.rVacumnBar.Name = "rVacumnBar";
            this.rVacumnBar.Size = new System.Drawing.Size(50, 18);
            this.rVacumnBar.TabIndex = 3;
            this.rVacumnBar.TabStop = true;
            this.rVacumnBar.Tag = "3";
            this.rVacumnBar.Text = "InHg";
            this.rVacumnBar.UseVisualStyleBackColor = true;
            // 
            // groupBox_9
            // 
            this.groupBox_9.Controls.Add(this.trkSmooth);
            this.groupBox_9.Controls.Add(this.txtbSmooth);
            this.groupBox_9.Controls.Add(this.label69);
            this.groupBox_9.Controls.Add(this.chkSmoothRows);
            this.groupBox_9.Location = new System.Drawing.Point(399, 157);
            this.groupBox_9.Name = "groupBox_9";
            this.groupBox_9.Size = new System.Drawing.Size(133, 90);
            this.groupBox_9.TabIndex = 9;
            this.groupBox_9.TabStop = false;
            this.groupBox_9.Text = "Smoothing";
            // 
            // txtbSmooth
            // 
            this.txtbSmooth.Location = new System.Drawing.Point(77, 37);
            this.txtbSmooth.Name = "txtbSmooth";
            this.txtbSmooth.ReadOnly = true;
            this.txtbSmooth.Size = new System.Drawing.Size(35, 20);
            this.txtbSmooth.TabIndex = 2;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(8, 40);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(65, 14);
            this.label69.TabIndex = 14;
            this.label69.Text = "Threshold:";
            // 
            // groupBox_23
            // 
            this.groupBox_23.Controls.Add(this.rbSelNodeSquare);
            this.groupBox_23.Controls.Add(this.rbSelNodeFill);
            this.groupBox_23.Location = new System.Drawing.Point(320, 37);
            this.groupBox_23.Name = "groupBox_23";
            this.groupBox_23.Size = new System.Drawing.Size(89, 54);
            this.groupBox_23.TabIndex = 8;
            this.groupBox_23.TabStop = false;
            this.groupBox_23.Text = "Node Type:";
            // 
            // rbSelNodeSquare
            // 
            this.rbSelNodeSquare.AutoSize = true;
            this.rbSelNodeSquare.Location = new System.Drawing.Point(11, 32);
            this.rbSelNodeSquare.Name = "rbSelNodeSquare";
            this.rbSelNodeSquare.Size = new System.Drawing.Size(63, 18);
            this.rbSelNodeSquare.TabIndex = 1;
            this.rbSelNodeSquare.TabStop = true;
            this.rbSelNodeSquare.Text = "Square";
            this.rbSelNodeSquare.UseVisualStyleBackColor = true;
            this.rbSelNodeSquare.CheckedChanged += new System.EventHandler(this.rbSelNodeFill_CheckedChanged);
            // 
            // rbSelNodeFill
            // 
            this.rbSelNodeFill.AutoSize = true;
            this.rbSelNodeFill.Location = new System.Drawing.Point(11, 14);
            this.rbSelNodeFill.Name = "rbSelNodeFill";
            this.rbSelNodeFill.Size = new System.Drawing.Size(72, 18);
            this.rbSelNodeFill.TabIndex = 0;
            this.rbSelNodeFill.TabStop = true;
            this.rbSelNodeFill.Text = "Fill Node";
            this.rbSelNodeFill.UseVisualStyleBackColor = true;
            this.rbSelNodeFill.CheckedChanged += new System.EventHandler(this.rbSelNodeFill_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTargetAfr);
            this.groupBox1.Controls.Add(this.label72);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.txtbAdjVe);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbAdjTargetAf);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbAdjFuelTableFv);
            this.groupBox1.Controls.Add(this.txtbAdjFuelTableSwitch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbAdjFuelTablePrecent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtbAdjIgnTable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Adjustements";
            // 
            // lblTargetAfr
            // 
            this.lblTargetAfr.AutoSize = true;
            this.lblTargetAfr.Location = new System.Drawing.Point(351, 20);
            this.lblTargetAfr.Name = "lblTargetAfr";
            this.lblTargetAfr.Size = new System.Drawing.Size(14, 14);
            this.lblTargetAfr.TabIndex = 16;
            this.lblTargetAfr.Text = "%";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(351, 44);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(14, 14);
            this.label72.TabIndex = 15;
            this.label72.Text = "%";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(158, 66);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(113, 14);
            this.label40.TabIndex = 14;
            this.label40.Text = "FV  -->        Then +/-:";
            // 
            // txtbAdjVe
            // 
            this.txtbAdjVe.Location = new System.Drawing.Point(285, 40);
            this.txtbAdjVe.Name = "txtbAdjVe";
            this.txtbAdjVe.Size = new System.Drawing.Size(55, 20);
            this.txtbAdjVe.TabIndex = 5;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(216, 42);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 14);
            this.label39.TabIndex = 12;
            this.label39.Text = "VE Table:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "FV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "°";
            // 
            // txtbAdjTargetAf
            // 
            this.txtbAdjTargetAf.Location = new System.Drawing.Point(285, 17);
            this.txtbAdjTargetAf.Name = "txtbAdjTargetAf";
            this.txtbAdjTargetAf.Size = new System.Drawing.Size(55, 20);
            this.txtbAdjTargetAf.TabIndex = 4;
            this.txtbAdjTargetAf.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Target A/F:";
            // 
            // txtbAdjFuelTableFv
            // 
            this.txtbAdjFuelTableFv.Location = new System.Drawing.Point(285, 64);
            this.txtbAdjFuelTableFv.Name = "txtbAdjFuelTableFv";
            this.txtbAdjFuelTableFv.Size = new System.Drawing.Size(55, 20);
            this.txtbAdjFuelTableFv.TabIndex = 3;
            this.txtbAdjFuelTableFv.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // txtbAdjFuelTableSwitch
            // 
            this.txtbAdjFuelTableSwitch.Location = new System.Drawing.Point(93, 63);
            this.txtbAdjFuelTableSwitch.Name = "txtbAdjFuelTableSwitch";
            this.txtbAdjFuelTableSwitch.Size = new System.Drawing.Size(55, 20);
            this.txtbAdjFuelTableSwitch.TabIndex = 2;
            this.txtbAdjFuelTableSwitch.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "If FV is lower:";
            // 
            // txtbAdjFuelTablePrecent
            // 
            this.txtbAdjFuelTablePrecent.Location = new System.Drawing.Point(93, 39);
            this.txtbAdjFuelTablePrecent.Name = "txtbAdjFuelTablePrecent";
            this.txtbAdjFuelTablePrecent.Size = new System.Drawing.Size(55, 20);
            this.txtbAdjFuelTablePrecent.TabIndex = 1;
            this.txtbAdjFuelTablePrecent.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fuel Table:";
            // 
            // txtbAdjIgnTable
            // 
            this.txtbAdjIgnTable.Location = new System.Drawing.Point(93, 16);
            this.txtbAdjIgnTable.Name = "txtbAdjIgnTable";
            this.txtbAdjIgnTable.Size = new System.Drawing.Size(55, 20);
            this.txtbAdjIgnTable.TabIndex = 0;
            this.txtbAdjIgnTable.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ignition Table:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rBoostInHg);
            this.groupBox2.Controls.Add(this.rBoostKpa);
            this.groupBox2.Controls.Add(this.rBoostPsi);
            this.groupBox2.Controls.Add(this.rBoostMbar);
            this.groupBox2.Controls.Add(this.rBoostBar);
            this.groupBox2.Location = new System.Drawing.Point(84, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(70, 114);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Boost";
            // 
            // rBoostInHg
            // 
            this.rBoostInHg.AutoSize = true;
            this.rBoostInHg.Location = new System.Drawing.Point(15, 87);
            this.rBoostInHg.Name = "rBoostInHg";
            this.rBoostInHg.Size = new System.Drawing.Size(50, 18);
            this.rBoostInHg.TabIndex = 5;
            this.rBoostInHg.TabStop = true;
            this.rBoostInHg.Tag = "3";
            this.rBoostInHg.Text = "InHg";
            this.rBoostInHg.UseVisualStyleBackColor = true;
            // 
            // rBoostKpa
            // 
            this.rBoostKpa.AutoSize = true;
            this.rBoostKpa.Location = new System.Drawing.Point(15, 68);
            this.rBoostKpa.Name = "rBoostKpa";
            this.rBoostKpa.Size = new System.Drawing.Size(43, 18);
            this.rBoostKpa.TabIndex = 1;
            this.rBoostKpa.TabStop = true;
            this.rBoostKpa.Tag = "5";
            this.rBoostKpa.Text = "kPa";
            this.rBoostKpa.UseVisualStyleBackColor = true;
            // 
            // rBoostPsi
            // 
            this.rBoostPsi.AutoSize = true;
            this.rBoostPsi.Location = new System.Drawing.Point(15, 49);
            this.rBoostPsi.Name = "rBoostPsi";
            this.rBoostPsi.Size = new System.Drawing.Size(41, 18);
            this.rBoostPsi.TabIndex = 4;
            this.rBoostPsi.TabStop = true;
            this.rBoostPsi.Tag = "4";
            this.rBoostPsi.Text = "psi";
            this.rBoostPsi.UseVisualStyleBackColor = true;
            // 
            // rBoostMbar
            // 
            this.rBoostMbar.AutoSize = true;
            this.rBoostMbar.Location = new System.Drawing.Point(15, 13);
            this.rBoostMbar.Name = "rBoostMbar";
            this.rBoostMbar.Size = new System.Drawing.Size(51, 18);
            this.rBoostMbar.TabIndex = 0;
            this.rBoostMbar.TabStop = true;
            this.rBoostMbar.Tag = "0";
            this.rBoostMbar.Text = "mBar";
            this.rBoostMbar.UseVisualStyleBackColor = true;
            // 
            // rBoostBar
            // 
            this.rBoostBar.AutoSize = true;
            this.rBoostBar.Location = new System.Drawing.Point(15, 31);
            this.rBoostBar.Name = "rBoostBar";
            this.rBoostBar.Size = new System.Drawing.Size(42, 18);
            this.rBoostBar.TabIndex = 3;
            this.rBoostBar.TabStop = true;
            this.rBoostBar.Tag = "1";
            this.rBoostBar.Text = "Bar";
            this.rBoostBar.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rMph);
            this.groupBox6.Controls.Add(this.rKph);
            this.groupBox6.Location = new System.Drawing.Point(160, 37);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(61, 54);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Speed";
            // 
            // rMph
            // 
            this.rMph.AutoSize = true;
            this.rMph.Location = new System.Drawing.Point(8, 33);
            this.rMph.Name = "rMph";
            this.rMph.Size = new System.Drawing.Size(48, 18);
            this.rMph.TabIndex = 1;
            this.rMph.TabStop = true;
            this.rMph.Text = "Mph";
            this.rMph.UseVisualStyleBackColor = true;
            // 
            // rKph
            // 
            this.rKph.AutoSize = true;
            this.rKph.Location = new System.Drawing.Point(8, 15);
            this.rKph.Name = "rKph";
            this.rKph.Size = new System.Drawing.Size(46, 18);
            this.rKph.TabIndex = 0;
            this.rKph.TabStop = true;
            this.rKph.Text = "Kph";
            this.rKph.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rPercentage);
            this.groupBox8.Controls.Add(this.rMulti);
            this.groupBox8.Location = new System.Drawing.Point(160, 97);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(130, 54);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Fuel Correction";
            // 
            // rPercentage
            // 
            this.rPercentage.AutoSize = true;
            this.rPercentage.Location = new System.Drawing.Point(8, 32);
            this.rPercentage.Name = "rPercentage";
            this.rPercentage.Size = new System.Drawing.Size(87, 18);
            this.rPercentage.TabIndex = 1;
            this.rPercentage.TabStop = true;
            this.rPercentage.Text = "Percentage";
            this.rPercentage.UseVisualStyleBackColor = true;
            // 
            // rMulti
            // 
            this.rMulti.AutoSize = true;
            this.rMulti.Location = new System.Drawing.Point(8, 14);
            this.rMulti.Name = "rMulti";
            this.rMulti.Size = new System.Drawing.Size(75, 18);
            this.rMulti.TabIndex = 0;
            this.rMulti.TabStop = true;
            this.rMulti.Text = "Multiplier";
            this.rMulti.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rCelcuis);
            this.groupBox7.Controls.Add(this.rFarhenheit);
            this.groupBox7.Location = new System.Drawing.Point(296, 97);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(113, 54);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Temperature";
            // 
            // rCelcuis
            // 
            this.rCelcuis.AutoSize = true;
            this.rCelcuis.Location = new System.Drawing.Point(10, 33);
            this.rCelcuis.Name = "rCelcuis";
            this.rCelcuis.Size = new System.Drawing.Size(66, 18);
            this.rCelcuis.TabIndex = 1;
            this.rCelcuis.Text = "Celcius";
            this.rCelcuis.UseVisualStyleBackColor = true;
            this.rCelcuis.CheckedChanged += new System.EventHandler(this.rCelcuis_CheckedChanged);
            // 
            // rFarhenheit
            // 
            this.rFarhenheit.AutoSize = true;
            this.rFarhenheit.Location = new System.Drawing.Point(10, 15);
            this.rFarhenheit.Name = "rFarhenheit";
            this.rFarhenheit.Size = new System.Drawing.Size(83, 18);
            this.rFarhenheit.TabIndex = 0;
            this.rFarhenheit.Text = "Farhenheit";
            this.rFarhenheit.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rAfr);
            this.groupBox5.Controls.Add(this.rLambda);
            this.groupBox5.Location = new System.Drawing.Point(227, 37);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(87, 54);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "O2";
            // 
            // rAfr
            // 
            this.rAfr.AutoSize = true;
            this.rAfr.Location = new System.Drawing.Point(6, 33);
            this.rAfr.Name = "rAfr";
            this.rAfr.Size = new System.Drawing.Size(74, 18);
            this.rAfr.TabIndex = 1;
            this.rAfr.TabStop = true;
            this.rAfr.Text = "A/F Ratio";
            this.rAfr.UseVisualStyleBackColor = true;
            this.rAfr.CheckedChanged += new System.EventHandler(this.rLambda2_CheckedChanged);
            // 
            // rLambda
            // 
            this.rLambda.AutoSize = true;
            this.rLambda.Location = new System.Drawing.Point(6, 13);
            this.rLambda.Name = "rLambda";
            this.rLambda.Size = new System.Drawing.Size(66, 18);
            this.rLambda.TabIndex = 0;
            this.rLambda.TabStop = true;
            this.rLambda.Text = "Lambda";
            this.rLambda.UseVisualStyleBackColor = true;
            this.rLambda.CheckedChanged += new System.EventHandler(this.rLambda2_CheckedChanged);
            // 
            // tabDatalogDisplay
            // 
            this.tabDatalogDisplay.Controls.Add(this.button16);
            this.tabDatalogDisplay.Controls.Add(this.button15);
            this.tabDatalogDisplay.Controls.Add(this.groupBox14);
            this.tabDatalogDisplay.Controls.Add(this.groupBox13);
            this.tabDatalogDisplay.Controls.Add(this.button7);
            this.tabDatalogDisplay.Controls.Add(this.groupBox12);
            this.tabDatalogDisplay.Controls.Add(this.groupBox_20);
            this.tabDatalogDisplay.Location = new System.Drawing.Point(4, 23);
            this.tabDatalogDisplay.Name = "tabDatalogDisplay";
            this.tabDatalogDisplay.Size = new System.Drawing.Size(535, 269);
            this.tabDatalogDisplay.TabIndex = 6;
            this.tabDatalogDisplay.Text = "Colors";
            this.tabDatalogDisplay.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(149, 234);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(125, 25);
            this.button16.TabIndex = 42;
            this.button16.Text = "Export Colors";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(18, 234);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(125, 25);
            this.button15.TabIndex = 41;
            this.button15.Text = "Import Colors";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.button11);
            this.groupBox14.Controls.Add(this.pictureBox1);
            this.groupBox14.Controls.Add(this.button12);
            this.groupBox14.Controls.Add(this.pictureBox2);
            this.groupBox14.Location = new System.Drawing.Point(293, 147);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(239, 79);
            this.groupBox14.TabIndex = 40;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Background Image";
            // 
            // button11
            // 
            this.button11.ForeColor = System.Drawing.Color.Red;
            this.button11.Location = new System.Drawing.Point(87, 22);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(21, 21);
            this.button11.TabIndex = 5;
            this.button11.Text = "X";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 45);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // button12
            // 
            this.button12.ForeColor = System.Drawing.Color.Red;
            this.button12.Location = new System.Drawing.Point(206, 22);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(21, 21);
            this.button12.TabIndex = 3;
            this.button12.Text = "X";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(134, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 45);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.button13);
            this.groupBox13.Controls.Add(this.label92);
            this.groupBox13.Controls.Add(this.label89);
            this.groupBox13.Controls.Add(this.button9);
            this.groupBox13.Controls.Add(this.button10);
            this.groupBox13.Controls.Add(this.label90);
            this.groupBox13.Controls.Add(this.label85);
            this.groupBox13.Controls.Add(this.button8);
            this.groupBox13.Controls.Add(this.btnDispBack);
            this.groupBox13.Controls.Add(this.label88);
            this.groupBox13.Location = new System.Drawing.Point(2, 147);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(284, 79);
            this.groupBox13.TabIndex = 39;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "2D/3D/Plots Colors";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(9, 58);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(79, 14);
            this.label92.TabIndex = 44;
            this.label92.Text = "Text/Line#2:";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(169, 18);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(48, 14);
            this.label89.TabIndex = 40;
            this.label89.Text = "Plot #1:";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(169, 38);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(48, 14);
            this.label90.TabIndex = 42;
            this.label90.Text = "Plot #2:";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(9, 18);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(36, 14);
            this.label85.TabIndex = 12;
            this.label85.Text = "Back:";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(9, 38);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(79, 14);
            this.label88.TabIndex = 38;
            this.label88.Text = "Text/Line#1:";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label83);
            this.groupBox12.Controls.Add(this.label79);
            this.groupBox12.Controls.Add(this.btnVE2);
            this.groupBox12.Controls.Add(this.btnVE1);
            this.groupBox12.Controls.Add(this.label86);
            this.groupBox12.Controls.Add(this.label76);
            this.groupBox12.Controls.Add(this.label77);
            this.groupBox12.Controls.Add(this.txtIgn);
            this.groupBox12.Controls.Add(this.label78);
            this.groupBox12.Controls.Add(this.label80);
            this.groupBox12.Controls.Add(this.label81);
            this.groupBox12.Controls.Add(this.label73);
            this.groupBox12.Controls.Add(this.label70);
            this.groupBox12.Controls.Add(this.txtFuel2);
            this.groupBox12.Controls.Add(this.label71);
            this.groupBox12.Controls.Add(this.label63);
            this.groupBox12.Controls.Add(this.txtFuel1);
            this.groupBox12.Controls.Add(this.label52);
            this.groupBox12.Controls.Add(this.label41);
            this.groupBox12.Controls.Add(this.btnIgn4);
            this.groupBox12.Controls.Add(this.btnFuel4);
            this.groupBox12.Controls.Add(this.btnIgn3);
            this.groupBox12.Controls.Add(this.btnIgn2);
            this.groupBox12.Controls.Add(this.btnFuel3);
            this.groupBox12.Controls.Add(this.btnFuel2);
            this.groupBox12.Controls.Add(this.btnFuel1);
            this.groupBox12.Controls.Add(this.label74);
            this.groupBox12.Controls.Add(this.btnIgn1);
            this.groupBox12.Controls.Add(this.label75);
            this.groupBox12.Location = new System.Drawing.Point(293, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(239, 143);
            this.groupBox12.TabIndex = 3;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Tables Colors";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(213, 75);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(11, 14);
            this.label83.TabIndex = 75;
            this.label83.Text = "°";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(257, 176);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(14, 14);
            this.label79.TabIndex = 74;
            this.label79.Text = "%";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(64, 118);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(56, 14);
            this.label86.TabIndex = 70;
            this.label86.Text = "VE Table:";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(171, 93);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(38, 14);
            this.label76.TabIndex = 67;
            this.label76.Text = "at 60°";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(239, 65);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(11, 14);
            this.label77.TabIndex = 66;
            this.label77.Text = "°";
            // 
            // txtIgn
            // 
            this.txtIgn.Location = new System.Drawing.Point(191, 72);
            this.txtIgn.Name = "txtIgn";
            this.txtIgn.Size = new System.Drawing.Size(21, 20);
            this.txtIgn.TabIndex = 65;
            this.txtIgn.Text = "30";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(171, 75);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(17, 14);
            this.label78.TabIndex = 64;
            this.label78.Text = "at";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(171, 53);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(31, 14);
            this.label80.TabIndex = 61;
            this.label80.Text = "at 0°";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(171, 34);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(34, 14);
            this.label81.TabIndex = 60;
            this.label81.Text = "at -6°";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(52, 93);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(41, 14);
            this.label73.TabIndex = 59;
            this.label73.Text = "at 80%";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(96, 75);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(14, 14);
            this.label70.TabIndex = 58;
            this.label70.Text = "%";
            // 
            // txtFuel2
            // 
            this.txtFuel2.Location = new System.Drawing.Point(72, 72);
            this.txtFuel2.Name = "txtFuel2";
            this.txtFuel2.Size = new System.Drawing.Size(21, 20);
            this.txtFuel2.TabIndex = 57;
            this.txtFuel2.Text = "38";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(52, 75);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(17, 14);
            this.label71.TabIndex = 56;
            this.label71.Text = "at";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(96, 53);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(14, 14);
            this.label63.TabIndex = 55;
            this.label63.Text = "%";
            // 
            // txtFuel1
            // 
            this.txtFuel1.Location = new System.Drawing.Point(72, 50);
            this.txtFuel1.Name = "txtFuel1";
            this.txtFuel1.Size = new System.Drawing.Size(21, 20);
            this.txtFuel1.TabIndex = 54;
            this.txtFuel1.Text = "8";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(52, 53);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(17, 14);
            this.label52.TabIndex = 53;
            this.label52.Text = "at";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(52, 34);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(34, 14);
            this.label41.TabIndex = 52;
            this.label41.Text = "at 0%";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(18, 16);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(72, 14);
            this.label74.TabIndex = 40;
            this.label74.Text = "Fuel Tables:";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(131, 16);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(90, 14);
            this.label75.TabIndex = 42;
            this.label75.Text = "Ignition Tables:";
            // 
            // groupBox_20
            // 
            this.groupBox_20.Controls.Add(this.button_LedDark);
            this.groupBox_20.Controls.Add(this.label99);
            this.groupBox_20.Controls.Add(this.button5);
            this.groupBox_20.Controls.Add(this.label26);
            this.groupBox_20.Controls.Add(this.button6);
            this.groupBox_20.Controls.Add(this.label31);
            this.groupBox_20.Controls.Add(this.button4);
            this.groupBox_20.Controls.Add(this.label22);
            this.groupBox_20.Controls.Add(this.button3);
            this.groupBox_20.Controls.Add(this.label10);
            this.groupBox_20.Controls.Add(this.btnSelectedColor);
            this.groupBox_20.Controls.Add(this.btnTrailColor);
            this.groupBox_20.Controls.Add(this.btnTraceColor);
            this.groupBox_20.Controls.Add(this.label20);
            this.groupBox_20.Controls.Add(this.label82);
            this.groupBox_20.Controls.Add(this.label35);
            this.groupBox_20.Controls.Add(this.btnLedOff);
            this.groupBox_20.Controls.Add(this.label38);
            this.groupBox_20.Controls.Add(this.btnLedOn);
            this.groupBox_20.Controls.Add(this.label37);
            this.groupBox_20.Controls.Add(this.btnDispText);
            this.groupBox_20.Controls.Add(this.label36);
            this.groupBox_20.Location = new System.Drawing.Point(2, 3);
            this.groupBox_20.Name = "groupBox_20";
            this.groupBox_20.Size = new System.Drawing.Size(285, 143);
            this.groupBox_20.TabIndex = 1;
            this.groupBox_20.TabStop = false;
            this.groupBox_20.Text = "Generals Colors";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(9, 39);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(76, 14);
            this.label99.TabIndex = 38;
            this.label99.Text = "Led On Dark:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(169, 101);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(36, 14);
            this.label26.TabIndex = 36;
            this.label26.Text = "Logs:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 99);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(30, 14);
            this.label31.TabIndex = 33;
            this.label31.Text = "RTP:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(169, 81);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 14);
            this.label22.TabIndex = 32;
            this.label22.Text = "Back #2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 30;
            this.label10.Text = "Back #1:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 14);
            this.label20.TabIndex = 25;
            this.label20.Text = "Graph Dot:";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(169, 41);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(33, 14);
            this.label82.TabIndex = 24;
            this.label82.Text = "Trail:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(169, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(41, 14);
            this.label35.TabIndex = 23;
            this.label35.Text = "Trace:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(9, 59);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(50, 14);
            this.label38.TabIndex = 10;
            this.label38.Text = "Led Off:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(9, 19);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(49, 14);
            this.label37.TabIndex = 8;
            this.label37.Text = "Led On:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 119);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 14);
            this.label36.TabIndex = 14;
            this.label36.Text = "Text:";
            // 
            // tabWideband
            // 
            this.tabWideband.Controls.Add(this.groupBox3);
            this.tabWideband.Controls.Add(this.groupBox_24);
            this.tabWideband.Controls.Add(this.grpWbDeff);
            this.tabWideband.Location = new System.Drawing.Point(4, 23);
            this.tabWideband.Name = "tabWideband";
            this.tabWideband.Size = new System.Drawing.Size(535, 269);
            this.tabWideband.TabIndex = 5;
            this.tabWideband.Text = "Wideband";
            this.tabWideband.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grpWbEcuInput);
            this.groupBox3.Controls.Add(this.groupBox_25);
            this.groupBox3.Location = new System.Drawing.Point(3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 165);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input Settings";
            // 
            // groupBox_25
            // 
            this.groupBox_25.Controls.Add(this.label87);
            this.groupBox_25.Controls.Add(this.cmbWidebandSerialPort);
            this.groupBox_25.Controls.Add(this.cmbWbDirectType);
            this.groupBox_25.Controls.Add(this.chkWbDirectInput);
            this.groupBox_25.Location = new System.Drawing.Point(8, 62);
            this.groupBox_25.Name = "groupBox_25";
            this.groupBox_25.Size = new System.Drawing.Size(229, 96);
            this.groupBox_25.TabIndex = 1;
            this.groupBox_25.TabStop = false;
            this.groupBox_25.Text = "Serial Input";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(5, 67);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(31, 14);
            this.label87.TabIndex = 3;
            this.label87.Text = "Port:";
            // 
            // cmbWidebandSerialPort
            // 
            this.cmbWidebandSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWidebandSerialPort.FormattingEnabled = true;
            this.cmbWidebandSerialPort.Location = new System.Drawing.Point(52, 67);
            this.cmbWidebandSerialPort.Name = "cmbWidebandSerialPort";
            this.cmbWidebandSerialPort.Size = new System.Drawing.Size(160, 22);
            this.cmbWidebandSerialPort.TabIndex = 2;
            // 
            // cmbWbDirectType
            // 
            this.cmbWbDirectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWbDirectType.DropDownWidth = 175;
            this.cmbWbDirectType.FormattingEnabled = true;
            this.cmbWbDirectType.Items.AddRange(new object[] {
            "Innovate LC-1/LM-1",
            "FJO",
            "Tech-Edge(frame formate 2.0 and above)",
            "Zeitronix",
            "AEM",
            "PLX R-series, AFR link to a4(r-500)",
            "JAW"});
            this.cmbWbDirectType.Location = new System.Drawing.Point(17, 40);
            this.cmbWbDirectType.Name = "cmbWbDirectType";
            this.cmbWbDirectType.Size = new System.Drawing.Size(195, 22);
            this.cmbWbDirectType.TabIndex = 1;
            this.cmbWbDirectType.SelectedIndexChanged += new System.EventHandler(this.cmbWbDirectType_SelectedIndexChanged);
            // 
            // chkWbDirectInput
            // 
            this.chkWbDirectInput.AutoSize = true;
            this.chkWbDirectInput.Location = new System.Drawing.Point(66, 17);
            this.chkWbDirectInput.Name = "chkWbDirectInput";
            this.chkWbDirectInput.Size = new System.Drawing.Size(114, 18);
            this.chkWbDirectInput.TabIndex = 0;
            this.chkWbDirectInput.Text = "Enable Serial WB";
            this.chkWbDirectInput.UseVisualStyleBackColor = true;
            this.chkWbDirectInput.CheckedChanged += new System.EventHandler(this.chkWbDirectInput_CheckedChanged);
            // 
            // groupBox_24
            // 
            this.groupBox_24.Controls.Add(this.cmbGasType);
            this.groupBox_24.Controls.Add(this.txtbGas);
            this.groupBox_24.Location = new System.Drawing.Point(3, 169);
            this.groupBox_24.Name = "groupBox_24";
            this.groupBox_24.Size = new System.Drawing.Size(243, 54);
            this.groupBox_24.TabIndex = 4;
            this.groupBox_24.TabStop = false;
            this.groupBox_24.Text = "Gas Type/Stoichiometric:";
            // 
            // txtbGas
            // 
            this.txtbGas.Location = new System.Drawing.Point(10, 20);
            this.txtbGas.Name = "txtbGas";
            this.txtbGas.Size = new System.Drawing.Size(69, 20);
            this.txtbGas.TabIndex = 0;
            this.txtbGas.TextChanged += new System.EventHandler(this.txtbGas_TextChanged);
            this.txtbGas.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // tabOverlayAfr
            // 
            this.tabOverlayAfr.Controls.Add(this.groupBox_2);
            this.tabOverlayAfr.Location = new System.Drawing.Point(4, 23);
            this.tabOverlayAfr.Name = "tabOverlayAfr";
            this.tabOverlayAfr.Size = new System.Drawing.Size(535, 269);
            this.tabOverlayAfr.TabIndex = 2;
            this.tabOverlayAfr.Text = "Overlay(afr)";
            this.tabOverlayAfr.UseVisualStyleBackColor = true;
            // 
            // groupBox_2
            // 
            this.groupBox_2.Controls.Add(this.btnSetSecAfr);
            this.groupBox_2.Controls.Add(this.btnSetPrimAfr);
            this.groupBox_2.Controls.Add(this.label62);
            this.groupBox_2.Controls.Add(this.txtbAfrTHighMbar);
            this.groupBox_2.Controls.Add(this.txtbAfrTHigh);
            this.groupBox_2.Controls.Add(this.label64);
            this.groupBox_2.Controls.Add(this.textBox_1);
            this.groupBox_2.Controls.Add(this.label61);
            this.groupBox_2.Controls.Add(this.label59);
            this.groupBox_2.Controls.Add(this.lblTargetAfrL);
            this.groupBox_2.Controls.Add(this.label43);
            this.groupBox_2.Controls.Add(this.txtbAfrTLowMbar);
            this.groupBox_2.Controls.Add(this.textBox_0);
            this.groupBox_2.Controls.Add(this.label55);
            this.groupBox_2.Location = new System.Drawing.Point(3, 3);
            this.groupBox_2.Name = "groupBox_2";
            this.groupBox_2.Size = new System.Drawing.Size(529, 131);
            this.groupBox_2.TabIndex = 0;
            this.groupBox_2.TabStop = false;
            this.groupBox_2.Text = "Target AFR";
            // 
            // btnSetSecAfr
            // 
            this.btnSetSecAfr.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSetSecAfr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetSecAfr.Location = new System.Drawing.Point(319, 74);
            this.btnSetSecAfr.Name = "btnSetSecAfr";
            this.btnSetSecAfr.Size = new System.Drawing.Size(171, 25);
            this.btnSetSecAfr.TabIndex = 7;
            this.btnSetSecAfr.Text = "Apply to secondary maps";
            this.btnSetSecAfr.UseVisualStyleBackColor = false;
            this.btnSetSecAfr.Click += new System.EventHandler(this.btnSetSecAfr_Click);
            // 
            // btnSetPrimAfr
            // 
            this.btnSetPrimAfr.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSetPrimAfr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPrimAfr.Location = new System.Drawing.Point(319, 40);
            this.btnSetPrimAfr.Name = "btnSetPrimAfr";
            this.btnSetPrimAfr.Size = new System.Drawing.Size(171, 25);
            this.btnSetPrimAfr.TabIndex = 6;
            this.btnSetPrimAfr.Text = "Apply to primary maps";
            this.btnSetPrimAfr.UseVisualStyleBackColor = false;
            this.btnSetPrimAfr.Click += new System.EventHandler(this.btnSetPrimAfr_Click);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(191, 74);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(35, 14);
            this.label62.TabIndex = 29;
            this.label62.Text = "High:";
            // 
            // txtbAfrTHighMbar
            // 
            this.txtbAfrTHighMbar.Location = new System.Drawing.Point(231, 70);
            this.txtbAfrTHighMbar.Name = "txtbAfrTHighMbar";
            this.txtbAfrTHighMbar.Size = new System.Drawing.Size(47, 20);
            this.txtbAfrTHighMbar.TabIndex = 5;
            this.txtbAfrTHighMbar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // txtbAfrTHigh
            // 
            this.txtbAfrTHigh.Location = new System.Drawing.Point(105, 98);
            this.txtbAfrTHigh.Name = "txtbAfrTHigh";
            this.txtbAfrTHigh.Size = new System.Drawing.Size(47, 20);
            this.txtbAfrTHigh.TabIndex = 4;
            this.txtbAfrTHigh.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(7, 97);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(61, 14);
            this.label64.TabIndex = 25;
            this.label64.Text = "High load:";
            // 
            // textBox_1
            // 
            this.textBox_1.Location = new System.Drawing.Point(105, 70);
            this.textBox_1.Name = "textBox_1";
            this.textBox_1.Size = new System.Drawing.Size(47, 20);
            this.textBox_1.TabIndex = 3;
            this.textBox_1.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(7, 73);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(55, 14);
            this.label61.TabIndex = 22;
            this.label61.Text = "Mid load:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(200, 20);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(71, 14);
            this.label59.TabIndex = 21;
            this.label59.Text = "Load (mbar):";
            // 
            // lblTargetAfrL
            // 
            this.lblTargetAfrL.AutoSize = true;
            this.lblTargetAfrL.Location = new System.Drawing.Point(84, 20);
            this.lblTargetAfrL.Name = "lblTargetAfrL";
            this.lblTargetAfrL.Size = new System.Drawing.Size(68, 14);
            this.lblTargetAfrL.TabIndex = 20;
            this.lblTargetAfrL.Text = "Target (afr):";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(191, 46);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(32, 14);
            this.label43.TabIndex = 19;
            this.label43.Text = "Low:";
            // 
            // txtbAfrTLowMbar
            // 
            this.txtbAfrTLowMbar.Location = new System.Drawing.Point(231, 42);
            this.txtbAfrTLowMbar.Name = "txtbAfrTLowMbar";
            this.txtbAfrTLowMbar.Size = new System.Drawing.Size(47, 20);
            this.txtbAfrTLowMbar.TabIndex = 2;
            this.txtbAfrTLowMbar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // textBox_0
            // 
            this.textBox_0.Location = new System.Drawing.Point(105, 42);
            this.textBox_0.Name = "textBox_0";
            this.textBox_0.Size = new System.Drawing.Size(47, 20);
            this.textBox_0.TabIndex = 1;
            this.textBox_0.Validating += new System.ComponentModel.CancelEventHandler(this.txtbGas_Validating);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(7, 45);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(58, 14);
            this.label55.TabIndex = 15;
            this.label55.Text = "Low load:";
            // 
            // tabAutoAdjust
            // 
            this.tabAutoAdjust.Controls.Add(this.chkDisableOverCond);
            this.tabAutoAdjust.Controls.Add(this.groupBox11);
            this.tabAutoAdjust.Controls.Add(this.groupBox_1);
            this.tabAutoAdjust.Location = new System.Drawing.Point(4, 23);
            this.tabAutoAdjust.Name = "tabAutoAdjust";
            this.tabAutoAdjust.Size = new System.Drawing.Size(535, 269);
            this.tabAutoAdjust.TabIndex = 8;
            this.tabAutoAdjust.Text = "Auto Adjust";
            this.tabAutoAdjust.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.gear0);
            this.groupBox11.Controls.Add(this.gear5);
            this.groupBox11.Controls.Add(this.gear4);
            this.groupBox11.Controls.Add(this.gear3);
            this.groupBox11.Controls.Add(this.gear2);
            this.groupBox11.Controls.Add(this.gear1);
            this.groupBox11.Controls.Add(this.chkCheckFuelCut);
            this.groupBox11.Controls.Add(this.label46);
            this.groupBox11.Controls.Add(this.chkLastSampleDiffo2);
            this.groupBox11.Controls.Add(this.lblIat);
            this.groupBox11.Controls.Add(this.txtbIatMax);
            this.groupBox11.Controls.Add(this.label56);
            this.groupBox11.Controls.Add(this.txtbIatMin);
            this.groupBox11.Controls.Add(this.label57);
            this.groupBox11.Controls.Add(this.lblEct);
            this.groupBox11.Controls.Add(this.txtbEctMax);
            this.groupBox11.Controls.Add(this.label53);
            this.groupBox11.Controls.Add(this.txtbEctMin);
            this.groupBox11.Controls.Add(this.label54);
            this.groupBox11.Controls.Add(this.label49);
            this.groupBox11.Controls.Add(this.txtbMapMax);
            this.groupBox11.Controls.Add(this.label50);
            this.groupBox11.Controls.Add(this.txtbMapMin);
            this.groupBox11.Controls.Add(this.label51);
            this.groupBox11.Controls.Add(this.txtbRpmMax);
            this.groupBox11.Controls.Add(this.label47);
            this.groupBox11.Controls.Add(this.txtbRpmMin);
            this.groupBox11.Controls.Add(this.label48);
            this.groupBox11.Controls.Add(this.txtbAfrMax);
            this.groupBox11.Controls.Add(this.label44);
            this.groupBox11.Controls.Add(this.txtbAfrMin);
            this.groupBox11.Controls.Add(this.label45);
            this.groupBox11.Controls.Add(this.txtbTpsMax);
            this.groupBox11.Controls.Add(this.label58);
            this.groupBox11.Controls.Add(this.txtbTpsMin);
            this.groupBox11.Controls.Add(this.label60);
            this.groupBox11.Location = new System.Drawing.Point(313, 27);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(221, 239);
            this.groupBox11.TabIndex = 5;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Conditions";
            // 
            // lblIat
            // 
            this.lblIat.AutoSize = true;
            this.lblIat.Location = new System.Drawing.Point(180, 88);
            this.lblIat.Name = "lblIat";
            this.lblIat.Size = new System.Drawing.Size(14, 14);
            this.lblIat.TabIndex = 39;
            this.lblIat.Text = "%";
            // 
            // txtbIatMax
            // 
            this.txtbIatMax.Location = new System.Drawing.Point(129, 84);
            this.txtbIatMax.Name = "txtbIatMax";
            this.txtbIatMax.Size = new System.Drawing.Size(41, 20);
            this.txtbIatMax.TabIndex = 11;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(111, 87);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(10, 14);
            this.label56.TabIndex = 37;
            this.label56.Text = "-";
            // 
            // txtbIatMin
            // 
            this.txtbIatMin.Location = new System.Drawing.Point(63, 84);
            this.txtbIatMin.Name = "txtbIatMin";
            this.txtbIatMin.Size = new System.Drawing.Size(41, 20);
            this.txtbIatMin.TabIndex = 10;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(12, 87);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(23, 14);
            this.label57.TabIndex = 35;
            this.label57.Text = "Iat:";
            // 
            // lblEct
            // 
            this.lblEct.AutoSize = true;
            this.lblEct.Location = new System.Drawing.Point(180, 111);
            this.lblEct.Name = "lblEct";
            this.lblEct.Size = new System.Drawing.Size(14, 14);
            this.lblEct.TabIndex = 34;
            this.lblEct.Text = "%";
            // 
            // txtbEctMax
            // 
            this.txtbEctMax.Location = new System.Drawing.Point(129, 107);
            this.txtbEctMax.Name = "txtbEctMax";
            this.txtbEctMax.Size = new System.Drawing.Size(41, 20);
            this.txtbEctMax.TabIndex = 9;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(111, 110);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(10, 14);
            this.label53.TabIndex = 32;
            this.label53.Text = "-";
            // 
            // txtbEctMin
            // 
            this.txtbEctMin.Location = new System.Drawing.Point(63, 107);
            this.txtbEctMin.Name = "txtbEctMin";
            this.txtbEctMin.Size = new System.Drawing.Size(41, 20);
            this.txtbEctMin.TabIndex = 8;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(12, 110);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(27, 14);
            this.label54.TabIndex = 30;
            this.label54.Text = "Ect:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(180, 134);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(33, 14);
            this.label49.TabIndex = 29;
            this.label49.Text = "mBar";
            // 
            // txtbMapMax
            // 
            this.txtbMapMax.Location = new System.Drawing.Point(129, 130);
            this.txtbMapMax.Name = "txtbMapMax";
            this.txtbMapMax.Size = new System.Drawing.Size(41, 20);
            this.txtbMapMax.TabIndex = 7;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(111, 133);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(10, 14);
            this.label50.TabIndex = 27;
            this.label50.Text = "-";
            // 
            // txtbMapMin
            // 
            this.txtbMapMin.Location = new System.Drawing.Point(63, 130);
            this.txtbMapMin.Name = "txtbMapMin";
            this.txtbMapMin.Size = new System.Drawing.Size(41, 20);
            this.txtbMapMin.TabIndex = 6;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(12, 133);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(36, 14);
            this.label51.TabIndex = 25;
            this.label51.Text = "Load:";
            // 
            // txtbRpmMax
            // 
            this.txtbRpmMax.Location = new System.Drawing.Point(129, 61);
            this.txtbRpmMax.Name = "txtbRpmMax";
            this.txtbRpmMax.Size = new System.Drawing.Size(41, 20);
            this.txtbRpmMax.TabIndex = 5;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(111, 64);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(10, 14);
            this.label47.TabIndex = 22;
            this.label47.Text = "-";
            // 
            // txtbRpmMin
            // 
            this.txtbRpmMin.Location = new System.Drawing.Point(63, 61);
            this.txtbRpmMin.Name = "txtbRpmMin";
            this.txtbRpmMin.Size = new System.Drawing.Size(41, 20);
            this.txtbRpmMin.TabIndex = 4;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(12, 64);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(33, 14);
            this.label48.TabIndex = 20;
            this.label48.Text = "Rpm:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(111, 41);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(10, 14);
            this.label44.TabIndex = 17;
            this.label44.Text = "-";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(12, 41);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(25, 14);
            this.label45.TabIndex = 15;
            this.label45.Text = "Afr:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(111, 18);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(10, 14);
            this.label58.TabIndex = 12;
            this.label58.Text = "-";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(12, 18);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(30, 14);
            this.label60.TabIndex = 0;
            this.label60.Text = "Tps:";
            // 
            // groupBox_1
            // 
            this.groupBox_1.Controls.Add(this.chkStackFilter);
            this.groupBox_1.Controls.Add(this.txtbMinSampVariance);
            this.groupBox_1.Controls.Add(this.label93);
            this.groupBox_1.Controls.Add(this.txtbStackSize);
            this.groupBox_1.Controls.Add(this.label94);
            this.groupBox_1.Controls.Add(this.label14);
            this.groupBox_1.Controls.Add(this.txtbSelectioAvgNeeded);
            this.groupBox_1.Controls.Add(this.label12);
            this.groupBox_1.Controls.Add(this.chkTunerFilterAuto);
            this.groupBox_1.Controls.Add(this.txtbSTD);
            this.groupBox_1.Controls.Add(this.label33);
            this.groupBox_1.Controls.Add(this.label11);
            this.groupBox_1.Controls.Add(this.label68);
            this.groupBox_1.Controls.Add(this.txtbHitDelay);
            this.groupBox_1.Controls.Add(this.label67);
            this.groupBox_1.Controls.Add(this.txtbFuelAjdP);
            this.groupBox_1.Controls.Add(this.label42);
            this.groupBox_1.Controls.Add(this.label66);
            this.groupBox_1.Controls.Add(this.txtbFuelAjdMax);
            this.groupBox_1.Controls.Add(this.txtbFuelAdjMin);
            this.groupBox_1.Controls.Add(this.label65);
            this.groupBox_1.Controls.Add(this.label15);
            this.groupBox_1.Location = new System.Drawing.Point(3, 3);
            this.groupBox_1.Name = "groupBox_1";
            this.groupBox_1.Size = new System.Drawing.Size(302, 263);
            this.groupBox_1.TabIndex = 4;
            this.groupBox_1.TabStop = false;
            this.groupBox_1.Text = "Filtering";
            this.groupBox_1.Enter += new System.EventHandler(this.groupBox_1_Enter);
            // 
            // tabAnalog1
            // 
            this.tabAnalog1.Controls.Add(this.groupBox10);
            this.tabAnalog1.Controls.Add(this.groupBox9);
            this.tabAnalog1.Controls.Add(this.groupBox_13);
            this.tabAnalog1.Location = new System.Drawing.Point(4, 23);
            this.tabAnalog1.Name = "tabAnalog1";
            this.tabAnalog1.Size = new System.Drawing.Size(535, 269);
            this.tabAnalog1.TabIndex = 7;
            this.tabAnalog1.Text = "Analog Inputs";
            this.tabAnalog1.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.gridAnalog3);
            this.groupBox10.Controls.Add(this.txtbAnalog3Dec);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Controls.Add(this.txtbAnalog3Val);
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.chkAnalog3Enable);
            this.groupBox10.Controls.Add(this.label21);
            this.groupBox10.Location = new System.Drawing.Point(355, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(170, 263);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Analog Input 3";
            // 
            // txtbAnalog3Dec
            // 
            this.txtbAnalog3Dec.Location = new System.Drawing.Point(64, 235);
            this.txtbAnalog3Dec.Name = "txtbAnalog3Dec";
            this.txtbAnalog3Dec.Size = new System.Drawing.Size(100, 20);
            this.txtbAnalog3Dec.TabIndex = 5;
            this.txtbAnalog3Dec.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 14);
            this.label13.TabIndex = 6;
            this.label13.Text = "Decimals:";
            // 
            // txtbAnalog3Val
            // 
            this.txtbAnalog3Val.Location = new System.Drawing.Point(64, 209);
            this.txtbAnalog3Val.Name = "txtbAnalog3Val";
            this.txtbAnalog3Val.Size = new System.Drawing.Size(100, 20);
            this.txtbAnalog3Val.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 14);
            this.label16.TabIndex = 4;
            this.label16.Text = "Units:";
            // 
            // chkAnalog3Enable
            // 
            this.chkAnalog3Enable.AutoSize = true;
            this.chkAnalog3Enable.Location = new System.Drawing.Point(34, 22);
            this.chkAnalog3Enable.Name = "chkAnalog3Enable";
            this.chkAnalog3Enable.Size = new System.Drawing.Size(102, 18);
            this.chkAnalog3Enable.TabIndex = 0;
            this.chkAnalog3Enable.Text = "Enable B6 (B6)";
            this.chkAnalog3Enable.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Lucida Sans", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(42, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Remove R2 and R3";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.gridAnalog2);
            this.groupBox9.Controls.Add(this.txtbAnalog2Dec);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.txtbAnalog2Val);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.chkAnalog2Enable);
            this.groupBox9.Location = new System.Drawing.Point(179, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(170, 263);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Analog Input 2";
            // 
            // txtbAnalog2Dec
            // 
            this.txtbAnalog2Dec.Location = new System.Drawing.Point(64, 235);
            this.txtbAnalog2Dec.Name = "txtbAnalog2Dec";
            this.txtbAnalog2Dec.Size = new System.Drawing.Size(100, 20);
            this.txtbAnalog2Dec.TabIndex = 5;
            this.txtbAnalog2Dec.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "Decimals:";
            // 
            // txtbAnalog2Val
            // 
            this.txtbAnalog2Val.Location = new System.Drawing.Point(64, 209);
            this.txtbAnalog2Val.Name = "txtbAnalog2Val";
            this.txtbAnalog2Val.Size = new System.Drawing.Size(100, 20);
            this.txtbAnalog2Val.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 4;
            this.label9.Text = "Units:";
            // 
            // chkAnalog2Enable
            // 
            this.chkAnalog2Enable.AutoSize = true;
            this.chkAnalog2Enable.Location = new System.Drawing.Point(28, 22);
            this.chkAnalog2Enable.Name = "chkAnalog2Enable";
            this.chkAnalog2Enable.Size = new System.Drawing.Size(117, 18);
            this.chkAnalog2Enable.TabIndex = 0;
            this.chkAnalog2Enable.Text = "Enable EGR (D12)";
            this.chkAnalog2Enable.UseVisualStyleBackColor = true;
            // 
            // groupBox_13
            // 
            this.groupBox_13.Controls.Add(this.gridAnalog1);
            this.groupBox_13.Controls.Add(this.txtbAnalog1Dec);
            this.groupBox_13.Controls.Add(this.label91);
            this.groupBox_13.Controls.Add(this.txtbAnalog1Val);
            this.groupBox_13.Controls.Add(this.label160);
            this.groupBox_13.Controls.Add(this.chkAnalog1Enable);
            this.groupBox_13.Controls.Add(this.label157);
            this.groupBox_13.Location = new System.Drawing.Point(3, 3);
            this.groupBox_13.Name = "groupBox_13";
            this.groupBox_13.Size = new System.Drawing.Size(170, 263);
            this.groupBox_13.TabIndex = 2;
            this.groupBox_13.TabStop = false;
            this.groupBox_13.Text = "Analog Input 1";
            // 
            // txtbAnalog1Dec
            // 
            this.txtbAnalog1Dec.Location = new System.Drawing.Point(64, 235);
            this.txtbAnalog1Dec.Name = "txtbAnalog1Dec";
            this.txtbAnalog1Dec.Size = new System.Drawing.Size(100, 20);
            this.txtbAnalog1Dec.TabIndex = 5;
            this.txtbAnalog1Dec.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmuTimeOut_Validating);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(5, 238);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(59, 14);
            this.label91.TabIndex = 6;
            this.label91.Text = "Decimals:";
            // 
            // txtbAnalog1Val
            // 
            this.txtbAnalog1Val.Location = new System.Drawing.Point(64, 209);
            this.txtbAnalog1Val.Name = "txtbAnalog1Val";
            this.txtbAnalog1Val.Size = new System.Drawing.Size(100, 20);
            this.txtbAnalog1Val.TabIndex = 1;
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(21, 212);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(38, 14);
            this.label160.TabIndex = 4;
            this.label160.Text = "Units:";
            // 
            // chkAnalog1Enable
            // 
            this.chkAnalog1Enable.AutoSize = true;
            this.chkAnalog1Enable.Location = new System.Drawing.Point(28, 22);
            this.chkAnalog1Enable.Name = "chkAnalog1Enable";
            this.chkAnalog1Enable.Size = new System.Drawing.Size(116, 18);
            this.chkAnalog1Enable.TabIndex = 0;
            this.chkAnalog1Enable.Text = "Enable ELD (D10)";
            this.chkAnalog1Enable.UseVisualStyleBackColor = true;
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Font = new System.Drawing.Font("Lucida Sans", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(31, 48);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(111, 13);
            this.label157.TabIndex = 2;
            this.label157.Text = "Remove R136 and R138";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(70, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(43, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(70, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(43, 20);
            this.textBox4.TabIndex = 2;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 54);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(43, 13);
            this.label29.TabIndex = 1;
            this.label29.Text = "Retries:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 27);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Timeout:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // colorDialog_0
            // 
            this.colorDialog_0.AllowFullOpen = false;
            this.colorDialog_0.AnyColor = true;
            this.colorDialog_0.SolidColorOnly = true;
            // 
            // fontDialog_0
            // 
            this.fontDialog_0.ShowEffects = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(4, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "Reset Default";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(280, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 25);
            this.button1.TabIndex = 15;
            this.button1.Text = "Import Settings File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "XML Settings|*.xml";
            this.openFileDialog1.Title = "Load Settings File";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.DereferenceLinks = false;
            this.saveFileDialog1.Filter = "XML Settings|*.xml";
            this.saveFileDialog1.Title = "Save Settings File";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Title = "Open Image";
            // 
            // button14
            // 
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(149, 298);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(125, 25);
            this.button14.TabIndex = 16;
            this.button14.Text = "Open Settings File";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click_1);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "txt";
            this.saveFileDialog2.Filter = "Settings Text File|*.txt";
            this.saveFileDialog2.Title = "Save Settings Text File";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.DefaultExt = "txt";
            this.openFileDialog3.Filter = "Settings File|*.txt";
            this.openFileDialog3.Title = "Open Settings Text File";
            // 
            // openFileDialog4
            // 
            this.openFileDialog4.DefaultExt = "exe";
            this.openFileDialog4.Filter = "Burner Software|*.exe";
            this.openFileDialog4.Title = "Select Burner software file location";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 327);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSettings_FormClosed);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkSamplingRate)).EndInit();
            this.grpWbEcuInput.ResumeLayout(false);
            this.grpWbDeff.ResumeLayout(false);
            this.grpWbDeff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalog2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalog3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDatalogging.ResumeLayout(false);
            this.tabDatalogging.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.grpEmuCommAdv.ResumeLayout(false);
            this.grpEmuCommAdv.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox_7.ResumeLayout(false);
            this.groupBox_7.PerformLayout();
            this.tabBurner.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.tabUnits.ResumeLayout(false);
            this.tabUnits.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.grpVacumn.ResumeLayout(false);
            this.grpVacumn.PerformLayout();
            this.groupBox_9.ResumeLayout(false);
            this.groupBox_9.PerformLayout();
            this.groupBox_23.ResumeLayout(false);
            this.groupBox_23.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabDatalogDisplay.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox_20.ResumeLayout(false);
            this.groupBox_20.PerformLayout();
            this.tabWideband.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox_25.ResumeLayout(false);
            this.groupBox_25.PerformLayout();
            this.groupBox_24.ResumeLayout(false);
            this.groupBox_24.PerformLayout();
            this.tabOverlayAfr.ResumeLayout(false);
            this.groupBox_2.ResumeLayout(false);
            this.groupBox_2.PerformLayout();
            this.tabAutoAdjust.ResumeLayout(false);
            this.tabAutoAdjust.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox_1.ResumeLayout(false);
            this.groupBox_1.PerformLayout();
            this.tabAnalog1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox_13.ResumeLayout(false);
            this.groupBox_13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);

    }

    private void lstEmulator_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            this.lstEmuPort.Enabled = !this.chkEmuAuto.Checked;
            this.lstEmuBaud.Enabled = !this.chkEmuAuto.Checked;
            this.chkEmuAuto.Enabled = true;

            if (this.lstEmulator.SelectedIndex == 0)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.Ostrich;
                this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                this.lstEmuBaud.SelectedIndex = 2;
            }
            else if (this.lstEmulator.SelectedIndex == 1)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.Demon;
                this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                this.lstEmuBaud.SelectedIndex = 2;
            }
            else if (this.lstEmulator.SelectedIndex == 2)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.ROMulator;
                this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                this.lstEmuBaud.SelectedIndex = 1;
            }
            else if (this.lstEmulator.SelectedIndex == 3)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.PGMFI_RTP;
                this.lstEmuPort.Enabled = false;
                this.lstEmuBaud.Enabled = false;
                this.chkEmuAuto.Enabled = false;
                this.lstEmuPort.SelectedIndex = this.lstDtComm.SelectedIndex;
                this.lstEmuBaud.SelectedIndex = 0;
            }
            else if (this.lstEmulator.SelectedIndex == 4)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.CobraRTP;
                this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                this.lstEmuBaud.SelectedIndex = 2;
            }
            else if (this.lstEmulator.SelectedIndex == 5)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.Vitaprog;
                this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                this.lstEmuBaud.SelectedIndex = 1;
            }
            else if (this.lstEmulator.SelectedIndex == 6)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.BMulator;
                this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                this.lstEmuBaud.SelectedIndex = 2;
            }
            else if (this.lstEmulator.SelectedIndex == 7)
            {
                this.class10_settings_0.emulatorMode_0 = EmulatorMode.ECUTamer;
                this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                this.lstEmuBaud.SelectedIndex = 1;
            }

            //final apply
            SetDemon(this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon);
            LoadDemon(this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon);

            this.txtbDtRetries.Text = this.class10_settings_0.int_21.ToString();
            this.txtbDtTimout.Text = this.class10_settings_0.int_20.ToString();


            labelDemonSelected.Visible = (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon);
        }
    }

    private void lstQuickLambda_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.lstQuickLambda.SelectedIndex != 0)
        {
            this.class10_settings_0.double_0 = this.method_4(this.lstQuickLambda.SelectedIndex);
        }
        this.method_3();
        this.class10_settings_0.int_8 = this.lstQuickLambda.SelectedIndex;
    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1, ref Class17 class17_1, ref Class25 class25_1, ref FrmMain FrmMain_1)
    {
        this.FrmMain_0 = FrmMain_1;
        this.class10_settings_0 = class10_1;
        this.class18_0 = class18_1;
        this.class17_0 = class17_1;
        this.class25_0 = class25_1;

        this.StartScaleRate = this.class10_settings_0.scaleRate;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void SetDemon(bool IsDemon)
    {
        if (IsDemon)
        {
            this.class10_settings_0.dataloggingMode_0 = DataloggingMode.datalogDemon;
            this.class10_settings_0.Emulator_Baud = 921600;
            this.class10_settings_0.string_1 = this.class10_settings_0.string_2;              //lstDtComm
            this.class10_settings_0.Datalog_Baud = this.class10_settings_0.Emulator_Baud;
            this.class10_settings_0.bool_31 = true;
            this.class10_settings_0.bool_27 = this.class10_settings_0.Emu_AutoScan;
        }
        else
        {
            this.class10_settings_0.dataloggingMode_0 = DataloggingMode.datalogMultiByteT;
            this.class10_settings_0.Datalog_Baud = 38400;
            if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP) this.class10_settings_0.bool_31 = true;
            else this.class10_settings_0.bool_31 = false;
            this.class10_settings_0.bool_27 = this.chkDtAuto.Checked;
        }
    }

    private void LoadDemon(bool IsDemon)
    {
        if (IsDemon)
        {
            this.lstDtComm.Enabled = false;
            this.lstDtBaud.Enabled = false;
        }
        else
        {
            this.lstDtComm.Enabled = !this.class10_settings_0.bool_27;
            this.lstDtBaud.Enabled = !this.class10_settings_0.bool_27;
        }
        this.chkDtAuto.Enabled = !IsDemon;
        this.chkDtAuto.Checked = this.class10_settings_0.bool_27;
        this.lstDtComm.SelectedIndex = this.lstDtComm.FindString(this.class10_settings_0.string_1);
        this.lstDtBaud.SelectedIndex = this.lstDtBaud.FindString(this.class10_settings_0.Datalog_Baud.ToString());
    }

    internal void method_1()
    {
        this.bool_0 = true;

        Unit_Temperature_Load = this.class10_settings_0.temperatureUnits_0;

        if (!(this.tabControl1.SelectedTab.Name == this.tabUnits.Name))
        {
            if (this.tabControl1.SelectedTab.Name == this.tabDatalogDisplay.Name)
            {
                this.button_LedDark.BackColor = this.class10_settings_0.color_OnDark;
                this.btnLedOn.BackColor = this.class10_settings_0.color_On;
                this.btnLedOff.BackColor = this.class10_settings_0.color_Off;
                this.btnDispBack.BackColor = this.class10_settings_0.color_3;
                this.btnDispText.BackColor = this.class10_settings_0.color_4;
                this.btnTrailColor.BackColor = this.class10_settings_0.color_Trail;
                this.btnTraceColor.BackColor = this.class10_settings_0.color_Trace;
                this.btnSelectedColor.BackColor = this.class10_settings_0.color_2;
                this.button3.BackColor = this.class10_settings_0.color_7;
                this.button4.BackColor = this.class10_settings_0.color_8;
                this.button6.BackColor = this.class10_settings_0.color_9;
                this.button5.BackColor = this.class10_settings_0.color_10;
                this.button8.BackColor = this.class10_settings_0.color_11;
                this.button9.BackColor = this.class10_settings_0.color_12;
                this.button10.BackColor = this.class10_settings_0.color_13;
                this.button13.BackColor = this.class10_settings_0.color_14;

                this.btnFuel1.BackColor = this.class10_settings_0.color_20;
                this.btnFuel2.BackColor = this.class10_settings_0.color_21;
                this.btnFuel3.BackColor = this.class10_settings_0.color_22;
                this.btnFuel4.BackColor = this.class10_settings_0.color_23;
                this.btnIgn1.BackColor = this.class10_settings_0.color_30;
                this.btnIgn2.BackColor = this.class10_settings_0.color_31;
                this.btnIgn3.BackColor = this.class10_settings_0.color_32;
                this.btnIgn4.BackColor = this.class10_settings_0.color_33;
                this.btnVE1.BackColor = this.class10_settings_0.color_40;
                this.btnVE2.BackColor = this.class10_settings_0.color_41;
                this.txtFuel1.Text = this.class10_settings_0.PercentColor1.ToString();
                this.txtFuel2.Text = this.class10_settings_0.PercentColor2.ToString();
                this.txtIgn.Text = ((this.class10_settings_0.PercentColorIgn * 60) / 100).ToString();


                FileInfo info = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back1.bmp");
                if (info.Exists)
                {
                    Bitmap ThisB = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back1.bmp");
                    this.pictureBox1.BackgroundImage = new Bitmap(ThisB);
                    ThisB.Dispose();
                    ThisB = null;
                }
                info = null;

                info = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp");
                if (info.Exists)
                {
                    Bitmap ThisB = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp");
                    this.pictureBox2.BackgroundImage = new Bitmap(ThisB);
                    ThisB.Dispose();
                    ThisB = null;
                }
                info = null;

                ReloadDefaultColor();

                ColorMenuOpened = true;

                goto Label_1DDF;
            }
            if (!(this.tabControl1.SelectedTab.Name == this.tabWideband.Name))
            {
                if (this.tabControl1.SelectedTab.Name == this.tabDatalogging.Name)
                {
                    //SetDemon(this.class10_0.emulatorMode_0 == EmulatorMode.Demon);
                    LoadDemon(this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon);

                    //emulator
                    if (!this.class10_settings_0.bool_31 && this.class10_settings_0.emulatorMode_0 != EmulatorMode.Demon)
                    {
                        this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_2);
                        this.lstEmuBaud.SelectedIndex = this.lstEmuBaud.FindString(this.class10_settings_0.Emulator_Baud.ToString());
                    }
                    else
                    {
                        this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.class10_settings_0.string_1);
                        this.lstEmuBaud.SelectedIndex = this.lstEmuBaud.FindString(this.class10_settings_0.Emulator_Baud.ToString());
                    }

                    //reload
                    this.chkRecordOnConnection.Checked = this.class10_settings_0.bool_8;
                    this.lstEmulator.SelectedIndex = (int)this.class10_settings_0.emulatorMode_0;
                    this.trkSamplingRate.Value = this.class10_settings_0.int_25;
                    this.txtbSampleRate.Text = this.class10_settings_0.int_25.ToString();
                    this.txtbDtRetries.Text = this.class10_settings_0.int_21.ToString();
                    this.txtbDtTimout.Text = this.class10_settings_0.int_20.ToString();

                    labelDemonSelected.Visible = (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon);

                    this.chk_LiveGraphing.Checked = this.class10_settings_0.LiveGraphing;
                    this.txt_LiveGraph_Lenght.Text = this.class10_settings_0.LiveGraph_Lenght.ToString();

                    this.chkBluetooth.Checked = this.class10_settings_0.IsBluetooth;
                    this.checkBoxJ12.Checked = this.class10_settings_0.bool_CheckJ12;
                    this.chkEmuAuto.Checked = this.class10_settings_0.Emu_AutoScan;
                    this.chkEmuAlwaysRt.Checked = this.class10_settings_0.Emu_AlwaysRT;
                    this.chkEmuAlwaysRt.Enabled = true;
                    this.chkEmuVendor.Checked = this.class10_settings_0.chkEmuVendor;

                    this.lstEmulator.Enabled = true;
                }
                else if (this.tabControl1.SelectedTab.Name == this.tabBurner.Name)
                {
                    string LocationBuffer = this.class10_settings_0.BurnerLocation;
                    this.comboBoxBurner.SelectedIndex = this.class10_settings_0.BurnerSoftware;
                    this.textBoxBurnerLocation.Text = LocationBuffer;
                }
                else if (this.tabControl1.SelectedTab.Name == this.tabAnalog1.Name)
                {
                    for (int i = 0; i < this.gridAnalog1.Rows.Count; i++)
                    {
                        this.gridAnalog1.Rows[i].Cells[0].Value = null;
                        this.gridAnalog1.Rows[i].Cells[1].Value = null;
                        this.gridAnalog2.Rows[i].Cells[0].Value = null;
                        this.gridAnalog2.Rows[i].Cells[1].Value = null;
                        this.gridAnalog3.Rows[i].Cells[0].Value = null;
                        this.gridAnalog3.Rows[i].Cells[1].Value = null;
                    }
                    int index = 0;
                    int num4 = 0;
                    for (num4 = 0; num4 < (this.class10_settings_0.double_4.Length / 2); num4++)
                    {
                        index = 2 * num4;
                        this.gridAnalog1.Rows[num4].Cells[0].Value = this.class10_settings_0.double_4[index];
                        this.gridAnalog1.Rows[num4].Cells[1].Value = this.class10_settings_0.double_4[index + 1];
                    }
                    this.chkAnalog1Enable.Checked = this.class10_settings_0.bool_36;
                    this.txtbAnalog1Val.Text = this.class10_settings_0.string_4;
                    this.txtbAnalog1Dec.Text = this.class10_settings_0.int_22.ToString();
                    for (num4 = 0; num4 < (this.class10_settings_0.double_5.Length / 2); num4++)
                    {
                        index = 2 * num4;
                        this.gridAnalog2.Rows[num4].Cells[0].Value = this.class10_settings_0.double_5[index];
                        this.gridAnalog2.Rows[num4].Cells[1].Value = this.class10_settings_0.double_5[index + 1];
                    }
                    this.chkAnalog2Enable.Checked = this.class10_settings_0.bool_38;
                    this.txtbAnalog2Val.Text = this.class10_settings_0.string_5;
                    this.txtbAnalog2Dec.Text = this.class10_settings_0.int_23.ToString();
                    for (num4 = 0; num4 < (this.class10_settings_0.double_6.Length / 2); num4++)
                    {
                        index = 2 * num4;
                        this.gridAnalog3.Rows[num4].Cells[0].Value = this.class10_settings_0.double_6[index];
                        this.gridAnalog3.Rows[num4].Cells[1].Value = this.class10_settings_0.double_6[index + 1];
                    }
                    this.chkAnalog3Enable.Checked = this.class10_settings_0.bool_40;
                    this.txtbAnalog3Val.Text = this.class10_settings_0.string_6;
                    this.txtbAnalog3Dec.Text = this.class10_settings_0.int_24.ToString();
                }
                else if (this.tabControl1.SelectedTab.Name == this.tabOverlayAfr.Name)
                {
                    this.txtbAfrTHighMbar.Text = this.class10_settings_0.int_39.ToString();
                    this.txtbAfrTLowMbar.Text = this.class10_settings_0.int_38.ToString();
                    this.lblTargetAfrL.Text = this.class10_settings_0.airFuelUnits_0.ToString() + ":";

                    if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                    {
                        this.textBox_0.Text = this.class18_0.method_241(this.class10_settings_0.double_10).ToString();
                        this.textBox_1.Text = this.class18_0.method_241(this.class10_settings_0.double_11).ToString();
                        this.txtbAfrTHigh.Text = this.class18_0.method_241(this.class10_settings_0.double_12).ToString();
                    }
                    else
                    {
                        this.textBox_0.Text = this.class10_settings_0.double_10.ToString();
                        this.textBox_1.Text = this.class10_settings_0.double_11.ToString();
                        this.txtbAfrTHigh.Text = this.class10_settings_0.double_12.ToString();
                    }
                }
                else if (this.tabControl1.SelectedTab.Name == this.tabAutoAdjust.Name)
                {
                    //Auto Adjustments
                    this.txtbSTD.Text = this.class10_settings_0.double_9.ToString();
                    this.txtbFuelAdjMin.Text = this.class10_settings_0.double_13.ToString();
                    this.txtbFuelAjdMax.Text = this.class10_settings_0.double_14.ToString();
                    this.txtbFuelAjdP.Text = this.class10_settings_0.double_15.ToString();
                    this.txtbSelectioAvgNeeded.Text = this.class10_settings_0.int_40.ToString();
                    this.chkTunerFilterAuto.Checked = this.class10_settings_0.bool_49;
                    this.txtbStackSize.Text = this.class10_settings_0.int_36.ToString();
                    this.txtbMinSampVariance.Text = this.class10_settings_0.int_41.ToString();
                    this.chkStackFilter.Checked = this.class10_settings_0.bool_51;

                    //Conditions
                    this.chkDisableOverCond.Checked = this.class10_settings_0.OverlayConditionsDisabled;
                    groupBox11.Enabled = !this.chkDisableOverCond.Checked;
                    this.txtbTpsMin.Text = this.class18_0.method_198(byte.Parse(this.class10_settings_0.int_26.ToString())).ToString();
                    this.txtbTpsMax.Text = this.class18_0.method_198(byte.Parse(this.class10_settings_0.int_27.ToString())).ToString();
                    if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                    {
                        this.txtbAfrMin.Text = this.class18_0.method_241(this.class10_settings_0.double_7).ToString();
                        this.txtbAfrMax.Text = this.class18_0.method_241(this.class10_settings_0.double_8).ToString();
                    }
                    else
                    {
                        this.txtbAfrMin.Text = this.class10_settings_0.double_7.ToString();
                        this.txtbAfrMax.Text = this.class10_settings_0.double_8.ToString();
                    }
                    this.txtbMapMin.Text = this.class10_settings_0.int_30.ToString();
                    this.txtbMapMax.Text = this.class10_settings_0.int_31.ToString();
                    this.txtbRpmMin.Text = this.class10_settings_0.int_28.ToString();
                    this.txtbRpmMax.Text = this.class10_settings_0.int_29.ToString();
                    this.txtbEctMin.Text = this.class18_0.method_191(byte.Parse(this.class10_settings_0.int_32.ToString())).ToString("0");
                    this.txtbEctMax.Text = this.class18_0.method_191(byte.Parse(this.class10_settings_0.int_33.ToString())).ToString("0");
                    this.txtbIatMin.Text = this.class18_0.method_191(byte.Parse(this.class10_settings_0.int_34.ToString())).ToString("0");
                    this.txtbIatMax.Text = this.class18_0.method_191(byte.Parse(this.class10_settings_0.int_35.ToString())).ToString("0");
                    this.lblEct.Text = this.class10_settings_0.temperatureUnits_0.ToString();
                    this.lblIat.Text = this.class10_settings_0.temperatureUnits_0.ToString();
                    this.gear0.Checked = this.class10_settings_0.bool_46[0];
                    this.gear1.Checked = this.class10_settings_0.bool_46[1];
                    this.gear2.Checked = this.class10_settings_0.bool_46[2];
                    this.gear3.Checked = this.class10_settings_0.bool_46[3];
                    this.gear4.Checked = this.class10_settings_0.bool_46[4];
                    this.gear5.Checked = this.class10_settings_0.bool_46[5];
                    this.txtbHitDelay.Text = this.class10_settings_0.int_37.ToString();
                    this.chkLastSampleDiffo2.Checked = this.class10_settings_0.bool_47;
                    this.chkCheckFuelCut.Checked = !this.class10_settings_0.bool_48;
                }
                goto Label_1DDF;
            }
            switch (this.class10_settings_0.airFuelUnits_0)
            {
                case AirFuelUnits.afr:
                    this.rAfr.Checked = true;
                    break;

                case AirFuelUnits.lambda:
                    this.rLambda.Checked = true;
                    break;
            }
        }
        else
        {
            this.txtFontScale.Text = (this.class10_settings_0.scaleRate).ToString();
            this.grpWbDeff.Enabled = true;
            this.groupBox3.Enabled = true;
            this.groupBox_24.Enabled = true;
            if (this.class10_settings_0.mapGraphSelect_0 == MapGraphSelect.fill)
            {
                this.rbSelNodeFill.Checked = true;
            }
            else
            {
                this.rbSelNodeSquare.Checked = true;
            }
            this.chkSmoothRows.Checked = this.class10_settings_0.bool_12;
            this.txtbSmooth.Text = (this.class10_settings_0.float_6 * 10f).ToString("0.00");
            float num7 = this.class10_settings_0.float_6 * 1000f;
            this.trkSmooth.Value = (int)float.Parse(num7.ToString());
            this.txtbAdjIgnTable.Text = this.class10_settings_0.float_0.ToString();
            this.txtbAdjFuelTablePrecent.Text = this.class10_settings_0.float_1.ToString();
            this.txtbAdjFuelTableSwitch.Text = this.class10_settings_0.float_3.ToString();
            this.txtbAdjFuelTableFv.Text = this.class10_settings_0.float_2.ToString();
            if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
            {
                this.txtbAdjTargetAf.Text = this.class18_0.method_241((double)this.class10_settings_0.float_4).ToString();
            }
            else
            {
                this.txtbAdjTargetAf.Text = this.class10_settings_0.float_4.ToString();
            }
            this.lblTargetAfr.Text = this.class10_settings_0.airFuelUnits_0.ToString();
            this.txtbAdjVe.Text = this.class10_settings_0.float_5.ToString();
            switch (this.class10_settings_0.mapSensorUnits_0)
            {
                case MapSensorUnits.mBar:
                    this.rVacumnMbar.Checked = true;
                    break;

                case MapSensorUnits.inHgG:
                    this.rVacumnInHgG.Checked = true;
                    break;

                case MapSensorUnits.inHg:
                    this.rVacumnBar.Checked = true;
                    break;

                case MapSensorUnits.psi:
                    this.rVacumnPsi.Checked = true;
                    break;

                case MapSensorUnits.kPa:
                    this.rVacumnKpa.Checked = true;
                    break;
            }
            switch (this.class10_settings_0.mapSensorUnits_1)
            {
                case MapSensorUnits.mBar:
                    this.rBoostMbar.Checked = true;
                    break;

                case MapSensorUnits.Bar:
                    this.rBoostBar.Checked = true;
                    break;

                case MapSensorUnits.inHg:
                    this.rBoostInHg.Checked = true;
                    break;

                case MapSensorUnits.psi:
                    this.rBoostPsi.Checked = true;
                    break;

                case MapSensorUnits.kPa:
                    this.rBoostKpa.Checked = true;
                    break;
            }
            switch (this.class10_settings_0.vssUnits_0)
            {
                case VssUnits.kmh:
                    this.rKph.Checked = true;
                    break;

                case VssUnits.mph:
                    this.rMph.Checked = true;
                    break;
            }
            switch (this.class10_settings_0.temperatureUnits_0)
            {
                case TemperatureUnits.F:
                    this.rFarhenheit.Checked = true;
                    break;

                case TemperatureUnits.C:
                    this.rCelcuis.Checked = true;
                    break;
            }
            switch (this.class10_settings_0.correctionUnits_0)
            {
                case CorrectionUnits.multi:
                    this.rMulti.Checked = true;
                    break;

                case CorrectionUnits.percentage:
                    this.rPercentage.Checked = true;
                    break;
            }
            switch (this.class10_settings_0.airFuelUnits_0)
            {
                case AirFuelUnits.afr:
                    this.rAfr.Checked = true;
                    break;

                case AirFuelUnits.lambda:
                    this.rLambda.Checked = true;
                    break;
            }

            this.txtbSeaLevel.Text = this.class10_settings_0.int_6.ToString();
            this.chkUsePa.Checked = this.class10_settings_0.bool_23;


            if (this.class10_settings_0.tunerSmartTrack == 0) this.rbTracingSingle.Checked = true;
            else if (this.class10_settings_0.tunerSmartTrack == 1) this.rbTracingQuad.Checked = true;
            else if (this.class10_settings_0.tunerSmartTrack == 2) this.rbTracingRow.Checked = true;
            else if (this.class10_settings_0.tunerSmartTrack == 3) this.rbTracingColumn.Checked = true;
            else if (this.class10_settings_0.tunerSmartTrack == 4) this.rbTracingRowColumn.Checked = true;

            goto Label_1DDF;
        }
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
        {
            this.txtbWbOffset.Text = this.class18_0.method_241(this.class10_settings_0.double_2).ToString("0.00");
            this.lblWbOffset.Text = "Afr";
        }
        else
        {
            this.txtbWbOffset.Text = this.class10_settings_0.double_2.ToString("0.00");
            this.lblWbOffset.Text = "λ";
        }
        this.lstQuickLambda.SelectedIndex = this.class10_settings_0.int_8;
        this.lstQuickLambda_SelectedIndexChanged(null, null);
        this.txtbGas.Text = this.class10_settings_0.double_3.ToString("0.00");
        this.cmbGasType.SelectedIndex = this.class10_settings_0.int_9;
        switch (this.class10_settings_0.wbinput_0)
        {
            case WBinput.o2Input:
                comboBoxEcuInput.SelectedIndex = 1;
                break;

            case WBinput.eldInput:
                comboBoxEcuInput.SelectedIndex = 0;
                break;

            case WBinput.egrInput:
                comboBoxEcuInput.SelectedIndex = 3;
                break;

            case WBinput.b6Input:
                comboBoxEcuInput.SelectedIndex = 2;
                break;

            default:
                this.class18_0.class17_0.frmMain_0.LogThis("Error wideband input out of range; config says: " + this.class10_settings_0.wbinput_0.ToString());
                break;
                //throw new Exception("Error wideband input out of range; config says: " + this.class10_settings_0.wbinput_0.ToString());
        }
        if (this.class17_0.class2_serialWB_0 != null)
        {
            this.cmbWidebandSerialPort.Items.Clear();
            for (int j = 0; j < this.class17_0.class2_serialWB_0.string_0.Length; j++)
            {
                this.cmbWidebandSerialPort.Items.Add(this.class17_0.class2_serialWB_0.string_0[j]);
            }
            try
            {
                this.cmbWidebandSerialPort.SelectedIndex = this.class10_settings_0.int_10;
            }
            catch (Exception)
            {
            }
        }
        this.chkWbDirectInput.Checked = this.class10_settings_0.bool_25;
        try
        {
            //int SIndex = (int)this.class10_settings_0.wideband_Serial_0 - 1;
            //if (SIndex < 0) SIndex = 0;
            //this.cmbWbDirectType.SelectedIndex = SIndex;
            this.cmbWbDirectType.SelectedIndex = (int)this.class10_settings_0.wideband_Serial_0;
        }
        catch
        {
            this.cmbWbDirectType.SelectedIndex = 0;
        }
    Label_1DDF:
        this.checkBox_6_CheckedChanged(null, null);
        this.bool_0 = false;
    }

    internal void method_2()
    {
        if (this.string_0 == this.tabUnits.Name)
        {
            try
            {
                try
                {
                    this.class10_settings_0.scaleRate = float.Parse(this.txtFontScale.Text);
                }
                catch
                {
                    try
                    {
                        this.class10_settings_0.scaleRate = int.Parse(this.txtFontScale.Text);
                    }
                    catch
                    {
                        this.class10_settings_0.scaleRate = 100;
                    }
                }
                this.class10_settings_0.bool_3 = true;
                this.class10_settings_0.float_0 = float.Parse(this.txtbAdjIgnTable.Text);
                this.class10_settings_0.float_1 = float.Parse(this.txtbAdjFuelTablePrecent.Text);
                this.class10_settings_0.float_3 = float.Parse(this.txtbAdjFuelTableSwitch.Text);
                this.class10_settings_0.float_2 = float.Parse(this.txtbAdjFuelTableFv.Text);
                this.class10_settings_0.bool_12 = this.chkSmoothRows.Checked;
                this.class10_settings_0.float_6 = float.Parse(this.txtbSmooth.Text) / 10f;
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                {
                    this.class10_settings_0.float_4 = (float)this.class18_0.method_240(double.Parse(this.txtbAdjTargetAf.Text));
                }
                else
                {
                    this.class10_settings_0.float_4 = float.Parse(this.txtbAdjTargetAf.Text);
                }
                this.class10_settings_0.float_5 = float.Parse(this.txtbAdjVe.Text);

                RadioButton button;
                for (int i = 0; i < this.grpVacumn.Controls.Count; i++)
                {
                    if (this.grpVacumn.Controls[i].GetType() == typeof(RadioButton))
                    {
                        button = (RadioButton)this.grpVacumn.Controls[i];
                        if (button.Checked)
                        {
                            this.class10_settings_0.mapSensorUnits_0 = (MapSensorUnits)int.Parse(button.Tag.ToString());
                        }
                    }
                }
                for (int j = 0; j < this.groupBox2.Controls.Count; j++)
                {
                    if (this.groupBox2.Controls[j].GetType() == typeof(RadioButton))
                    {
                        button = (RadioButton)this.groupBox2.Controls[j];
                        if (button.Checked)
                        {
                            this.class10_settings_0.mapSensorUnits_1 = (MapSensorUnits)int.Parse(button.Tag.ToString());
                        }
                    }
                }
                if (this.rFarhenheit.Checked)
                {
                    this.class10_settings_0.temperatureUnits_0 = TemperatureUnits.F;
                }
                else
                {
                    this.class10_settings_0.temperatureUnits_0 = TemperatureUnits.C;
                }
                if (this.rKph.Checked)
                {
                    this.class10_settings_0.vssUnits_0 = VssUnits.kmh;
                }
                else
                {
                    this.class10_settings_0.vssUnits_0 = VssUnits.mph;
                }
                if (this.rMulti.Checked)
                {
                    this.class10_settings_0.correctionUnits_0 = CorrectionUnits.multi;
                }
                else
                {
                    this.class10_settings_0.correctionUnits_0 = CorrectionUnits.percentage;
                }

                try
                {
                    this.class10_settings_0.int_6 = int.Parse(this.txtbSeaLevel.Text);
                }
                catch
                {
                    this.class10_settings_0.int_6 = 0x3f2;
                }
                this.class10_settings_0.bool_23 = this.chkUsePa.Checked;
            }
            catch (Exception exception3)
            {
                MessageBox.Show(Form.ActiveForm, "Settings/Units error: " + exception3.Message);
                throw;
            }
        }
        if (this.string_0 == this.tabDatalogDisplay.Name)
        {
            try
            {
                this.class10_settings_0.bool_24 = true;
                this.class10_settings_0.color_Trace = this.btnTraceColor.BackColor;
                this.class10_settings_0.color_Trail = this.btnTrailColor.BackColor;
                this.class10_settings_0.color_2 = this.btnSelectedColor.BackColor;
                this.class10_settings_0.color_3 = this.btnDispBack.BackColor;
                this.class10_settings_0.color_4 = this.btnDispText.BackColor;
                this.class10_settings_0.color_OnDark = this.button_LedDark.BackColor;
                this.class10_settings_0.color_On = this.btnLedOn.BackColor;
                this.class10_settings_0.color_Off = this.btnLedOff.BackColor;
                this.class10_settings_0.color_7 = this.button3.BackColor;
                this.class10_settings_0.color_8 = this.button4.BackColor;
                this.class10_settings_0.color_9 = this.button6.BackColor;
                this.class10_settings_0.color_10 = this.button5.BackColor;
                this.class10_settings_0.color_11 = this.button8.BackColor;
                this.class10_settings_0.color_12 = this.button9.BackColor;
                this.class10_settings_0.color_13 = this.button10.BackColor;
                this.class10_settings_0.color_14 = this.button13.BackColor;

                this.class10_settings_0.color_20 = this.btnFuel1.BackColor;
                this.class10_settings_0.color_21 = this.btnFuel2.BackColor;
                this.class10_settings_0.color_22 = this.btnFuel3.BackColor;
                this.class10_settings_0.color_23 = this.btnFuel4.BackColor;
                this.class10_settings_0.color_30 = this.btnIgn1.BackColor;
                this.class10_settings_0.color_31 = this.btnIgn2.BackColor;
                this.class10_settings_0.color_32 = this.btnIgn3.BackColor;
                this.class10_settings_0.color_33 = this.btnIgn4.BackColor;
                this.class10_settings_0.color_40 = this.btnVE1.BackColor;
                this.class10_settings_0.color_41 = this.btnVE2.BackColor;
                this.class10_settings_0.PercentColor1 = int.Parse(this.txtFuel1.Text);
                this.class10_settings_0.PercentColor2 = int.Parse(this.txtFuel2.Text);
                this.class10_settings_0.PercentColorIgn = (int.Parse(this.txtIgn.Text) * 100) / 60;

                //this.class10_0.bool_21 = false;
            }
            catch (Exception exception4)
            {
                MessageBox.Show(Form.ActiveForm, "Settings/Colors error: " + exception4.Message);
                throw;
            }
        }
        if (this.string_0 == this.tabOverlayAfr.Name)
        {
            try
            {
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                {
                    this.class10_settings_0.double_10 = this.class18_0.method_240(double.Parse(this.textBox_0.Text));
                    this.class10_settings_0.double_11 = this.class18_0.method_240(double.Parse(this.textBox_1.Text));
                    this.class10_settings_0.double_12 = this.class18_0.method_240(double.Parse(this.txtbAfrTHigh.Text));
                }
                else
                {
                    this.class10_settings_0.double_10 = double.Parse(this.textBox_0.Text);
                    this.class10_settings_0.double_11 = double.Parse(this.textBox_1.Text);
                    this.class10_settings_0.double_12 = double.Parse(this.txtbAfrTHigh.Text);
                }
                this.class10_settings_0.int_38 = int.Parse(this.txtbAfrTLowMbar.Text);
                this.class10_settings_0.int_39 = int.Parse(this.txtbAfrTHighMbar.Text);
            }
            catch (Exception exception5)
            {
                MessageBox.Show(Form.ActiveForm, "Settings/Overlay(afr) error: " + exception5.Message);
            }
        }
        if (this.string_0 == this.tabAutoAdjust.Name)
        {
            try
            {
                //Auto Adjustments
                this.class10_settings_0.double_9 = double.Parse(this.txtbSTD.Text);
                this.class10_settings_0.double_13 = double.Parse(this.txtbFuelAdjMin.Text);
                this.class10_settings_0.double_14 = double.Parse(this.txtbFuelAjdMax.Text);
                this.class10_settings_0.double_15 = double.Parse(this.txtbFuelAjdP.Text);
                this.class10_settings_0.int_40 = int.Parse(this.txtbSelectioAvgNeeded.Text);
                this.class10_settings_0.bool_49 = this.chkTunerFilterAuto.Checked;
                this.class10_settings_0.int_36 = int.Parse(this.txtbStackSize.Text);
                this.class10_settings_0.int_41 = int.Parse(this.txtbMinSampVariance.Text);
                this.class10_settings_0.bool_51 = this.chkStackFilter.Checked;

                //Conditions
                this.class10_settings_0.OverlayConditionsDisabled = chkDisableOverCond.Checked;
                groupBox11.Enabled = !this.chkDisableOverCond.Checked;
                this.class10_settings_0.int_26 = this.class18_0.method_228(int.Parse(this.txtbTpsMin.Text));
                this.class10_settings_0.int_27 = this.class18_0.method_228(int.Parse(this.txtbTpsMax.Text));
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                {
                    this.class10_settings_0.double_7 = this.class18_0.method_240(double.Parse(this.txtbAfrMin.Text));
                    this.class10_settings_0.double_8 = this.class18_0.method_240(double.Parse(this.txtbAfrMax.Text));
                }
                else
                {
                    this.class10_settings_0.double_7 = double.Parse(this.txtbAfrMin.Text);
                    this.class10_settings_0.double_8 = double.Parse(this.txtbAfrMax.Text);
                }
                this.class10_settings_0.int_30 = int.Parse(this.txtbMapMin.Text);
                this.class10_settings_0.int_31 = int.Parse(this.txtbMapMax.Text);
                this.class10_settings_0.int_28 = int.Parse(this.txtbRpmMin.Text);
                this.class10_settings_0.int_29 = int.Parse(this.txtbRpmMax.Text);
                this.class10_settings_0.int_32 = this.class18_0.method_230(double.Parse(this.txtbEctMin.Text));
                this.class10_settings_0.int_33 = this.class18_0.method_230(double.Parse(this.txtbEctMax.Text));
                this.class10_settings_0.int_34 = this.class18_0.method_230(double.Parse(this.txtbIatMin.Text));
                this.class10_settings_0.int_35 = this.class18_0.method_230(double.Parse(this.txtbIatMax.Text));
                this.class10_settings_0.bool_46[0] = this.gear0.Checked;
                this.class10_settings_0.bool_46[1] = this.gear1.Checked;
                this.class10_settings_0.bool_46[2] = this.gear2.Checked;
                this.class10_settings_0.bool_46[3] = this.gear3.Checked;
                this.class10_settings_0.bool_46[4] = this.gear4.Checked;
                this.class10_settings_0.bool_46[5] = this.gear5.Checked;
                this.class10_settings_0.int_37 = int.Parse(this.txtbHitDelay.Text);
                this.class10_settings_0.bool_47 = this.chkLastSampleDiffo2.Checked;
                this.class10_settings_0.bool_48 = !this.chkCheckFuelCut.Checked;
            }
            catch (Exception exception5)
            {
                MessageBox.Show(Form.ActiveForm, "Settings/Auto Adjust error: " + exception5.Message);
            }
        }
        if (this.string_0 == this.tabWideband.Name)
        {
            try
            {
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                {
                    this.class10_settings_0.double_2 = this.class18_0.method_240(double.Parse(this.txtbWbOffset.Text));
                }
                else
                {
                    this.class10_settings_0.double_2 = double.Parse(this.txtbWbOffset.Text);
                }
                this.class10_settings_0.double_3 = double.Parse(this.txtbGas.Text);
                this.class10_settings_0.double_0 = this.method_5();
                this.class10_settings_0.method_30();
                if (comboBoxEcuInput.SelectedIndex == 1)
                {
                    this.class10_settings_0.wbinput_0 = WBinput.o2Input;
                }
                else if (comboBoxEcuInput.SelectedIndex == 0)
                {
                    this.class10_settings_0.wbinput_0 = WBinput.eldInput;
                }
                else if (comboBoxEcuInput.SelectedIndex == 3)
                {
                    this.class10_settings_0.wbinput_0 = WBinput.egrInput;
                }
                else if (comboBoxEcuInput.SelectedIndex == 2)
                {
                    this.class10_settings_0.wbinput_0 = WBinput.b6Input;
                }
                this.class10_settings_0.bool_25 = this.chkWbDirectInput.Checked;
                //this.class10_settings_0.wideband_Serial_0 = (Wideband_Serial)this.cmbWbDirectType.SelectedIndex + 1;
                this.class10_settings_0.wideband_Serial_0 = (Wideband_Serial)this.cmbWbDirectType.SelectedIndex;
                this.class10_settings_0.int_10 = this.cmbWidebandSerialPort.SelectedIndex;
            }
            catch (Exception exception6)
            {
                MessageBox.Show(Form.ActiveForm, "Settings/Wideband error: " + exception6.Message);
            }
        }
        if (this.string_0 == this.tabAnalog1.Name)
        {
            try
            {
                this.class10_settings_0.double_4 = this.method_6(this.gridAnalog1);
                this.class10_settings_0.bool_36 = this.chkAnalog1Enable.Checked;
                this.class10_settings_0.string_4 = this.txtbAnalog1Val.Text;
                this.class10_settings_0.int_22 = int.Parse(this.txtbAnalog1Dec.Text);
                this.class10_settings_0.double_5 = this.method_6(this.gridAnalog2);
                this.class10_settings_0.bool_38 = this.chkAnalog2Enable.Checked;
                this.class10_settings_0.string_5 = this.txtbAnalog2Val.Text;
                this.class10_settings_0.int_23 = int.Parse(this.txtbAnalog2Dec.Text);
                this.class10_settings_0.double_6 = this.method_6(this.gridAnalog3);
                this.class10_settings_0.bool_40 = this.chkAnalog3Enable.Checked;
                this.class10_settings_0.string_6 = this.txtbAnalog3Val.Text;
                this.class10_settings_0.int_24 = int.Parse(this.txtbAnalog3Dec.Text);
            }
            catch (Exception exception7)
            {
                MessageBox.Show(Form.ActiveForm, "Settings/Analog inputs error: " + exception7.Message);
            }
        }
        if (this.string_0 == this.tabDatalogging.Name)
        {
            try
            {
                //emulator
                //ApplyEmuCOMtoSettings();
                //ApplyDatalogCOMtoSettings();
                this.class10_settings_0.string_2 = this.lstEmuPort.SelectedItem.ToString();
                this.class10_settings_0.string_1 = this.lstDtComm.SelectedItem.ToString();
                //##############
                this.class10_settings_0.Emulator_Baud = int.Parse(this.lstEmuBaud.SelectedItem.ToString());
                this.class10_settings_0.Datalog_Baud = int.Parse(this.lstDtBaud.SelectedItem.ToString());

                //Reload
                this.class10_settings_0.int_25 = this.trkSamplingRate.Value;
                this.class10_settings_0.bool_8 = this.chkRecordOnConnection.Checked;
                this.class10_settings_0.emulatorMode_0 = (EmulatorMode)this.lstEmulator.SelectedIndex;
                SetDemon(this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon);
                this.class10_settings_0.int_21 = int.Parse(this.txtbDtRetries.Text);
                this.class10_settings_0.int_20 = int.Parse(this.txtbDtTimout.Text);
                this.class10_settings_0.Emu_AutoScan = this.chkEmuAuto.Checked;
                //this.class10_0.bool_27 = this.chkDtAuto.Checked;
                this.class10_settings_0.Emu_AlwaysRT = this.chkEmuAlwaysRt.Checked;
                this.class10_settings_0.IsBluetooth = this.chkBluetooth.Checked;
                this.class10_settings_0.bool_CheckJ12 = this.checkBoxJ12.Checked;
                this.class10_settings_0.chkEmuVendor = this.chkEmuVendor.Checked;
                this.class10_settings_0.bool_33 = false;

                if (this.class10_settings_0.Emu_AlwaysRT) this.class10_settings_0.bool_32 = true;
                else this.class10_settings_0.bool_32 = false;

                this.class10_settings_0.LiveGraphing = this.chk_LiveGraphing.Checked;
                this.class10_settings_0.LiveGraph_Lenght = int.Parse(this.txt_LiveGraph_Lenght.Text);
            }
            catch (Exception exception8)
            {
                MessageBox.Show(Form.ActiveForm, "Settings/Emulator error: " + exception8.Message);
            }
        }
    }

    private void method_3()
    {
        int index = 0;
        for (int i = 0; i < this.gridWb.Rows.Count; i++)
        {
            this.gridWb.Rows[i].Cells[0].Value = null;
            this.gridWb.Rows[i].Cells[1].Value = null;
        }
        if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
        {
            this.gridWb.Columns[1].HeaderText = AirFuelUnits.lambda.ToString();
        }
        else
        {
            this.gridWb.Columns[1].HeaderText = AirFuelUnits.afr.ToString();
        }
        if (this.class10_settings_0.double_0 != null)
        {
            for (int j = 0; j < (this.class10_settings_0.double_0.Length / 2); j++)
            {
                index = 2 * j;
                this.gridWb.Rows[j].Cells[0].Value = Math.Round(this.class10_settings_0.double_0[index], 2);
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.lambda)
                {
                    this.gridWb.Rows[j].Cells[1].Value = Math.Round(this.class10_settings_0.double_0[index + 1], 2);
                }
                else
                {
                    this.gridWb.Rows[j].Cells[1].Value = Math.Round((double)(this.class10_settings_0.double_0[index + 1] * 14.7), 2);
                }
            }
        }
    }

    private double[] method_4(int int_0)
    {
        switch (int_0)
        {
            case 1:
                return new double[] { 0.0, 1.3, 0.3, 1.0, 0.7, 1.0, 1.0, 0.71 };

            case 2:
                return new double[] {
                    0.5, 0.75, 0.75, 0.785, 1.0, 0.819, 1.25, 0.852, 1.5, 0.887, 1.75, 0.921, 2.0, 0.955, 2.25, 0.99,
                    2.5, 1.024, 2.75, 1.057, 3.0, 1.092, 3.38, 1.143
                 };

            case 3:
                return new double[] { 0.0, 0.68, 5.0, 1.36 };

            case 4:
                return new double[] {
                    0.85, 0.68, 1.2, 0.75, 1.6, 0.82, 1.95, 0.88, 2.3, 0.95, 2.5, 1.0, 2.65, 1.09, 2.8, 1.16,
                    3.1, 1.36
                 };

            case 5:
                return new double[] { 0.0, 0.509, 5.0, 1.523 };

            case 6:
                return new double[] { 0.0, 0.61, 5.0, 1.29 };

            case 7:
                return new double[] {
                    0.15, 0.65, 0.5, 0.69, 1.0, 0.73, 1.25, 0.77, 1.5, 0.81, 1.7, 0.84, 2.0, 0.89, 2.25, 0.93,
                    2.5, 1.01, 2.7, 1.09, 3.0, 1.27, 3.47, 1.51
                 };

            case 8:
                return new double[] {
                    0.0, 0.50340136054421769, 0.5, 0.6149659863945578, 1.0, 0.726530612244898, 1.25, 0.78231292517006812, 1.5, 0.83809523809523812, 1.75, 0.89387755102040822, 2.0, 0.94965986394557833, 2.5, 1.0612244897959184,
                    3.0, 1.1727891156462584, 3.5, 1.2843537414965986, 4.0, 1.3959183673469389, 4.5, 1.504761904761905
                 };

            case 9:
                return new double[] {
                    1.02, 0.69, 1.08, 0.73, 1.16, 0.79, 1.22, 0.83, 1.28, 0.87, 1.32, 0.9, 1.4, 0.95, 1.47, 1.0,
                    1.65, 1.12, 1.82, 1.26, 2.02, 1.37, 2.21, 1.5
                 };

            case 10:
                return new double[] {
                    0.5, 0.58,
                    0.75, 0.62,
                    1.0, 0.66,
                    1.25, 0.7,
                    1.5, 0.74,
                    1.75, 0.78,
                    2.0, 0.82,
                    2.25, 0.86,
                    2.5, 0.9,
                    2.75, 0.94,
                    3.0, 0.99,
                    3.25, 1.03,
                    3.5, 1.07,
                    3.75, 1.11,
                    4.0, 1.15,
                    4.25, 1.19,
                    4.5, 1.23
                 };
        }
        return new double[0];
    }

    private double[] method_5()
    {
        double num2;
        int num = 0;
        for (int i = 0; i < this.gridWb.Rows.Count; i++)
        {
            if ((this.gridWb.Rows[i].Cells[0].Value != null) && double.TryParse(this.gridWb.Rows[i].Cells[0].Value.ToString(), out num2))
            {
                num++;
            }
        }
        double[] numArray = new double[num * 2];
        int index = 0;
        for (int j = 0; j < this.gridWb.Rows.Count; j++)
        {
            if ((this.gridWb.Rows[j].Cells[0].Value != null) && double.TryParse(this.gridWb.Rows[j].Cells[0].Value.ToString(), out num2))
            {
                index = j * 2;
                numArray[index] = double.Parse(this.gridWb.Rows[j].Cells[0].FormattedValue.ToString());
                if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                {
                    numArray[index + 1] = double.Parse(this.gridWb.Rows[j].Cells[1].FormattedValue.ToString()) / 14.7;
                }
                else
                {
                    numArray[index + 1] = double.Parse(this.gridWb.Rows[j].Cells[1].FormattedValue.ToString());
                }
            }
        }
        return numArray;
    }

    private double[] method_6(DataGridView dataGridView_0)
    {
        int num = 0;
        for (int i = 0; i < dataGridView_0.Rows.Count; i++)
        {
            if (((dataGridView_0.Rows[i].Cells[0].Value != null) && (dataGridView_0.Rows[i].Cells[1].Value != null)) && ((dataGridView_0.Rows[i].Cells[0].Value.ToString() != "") && (dataGridView_0.Rows[i].Cells[1].Value.ToString() != "")))
            {
                if (i == 0)
                {
                    num++;
                }
                else if ((double.Parse(dataGridView_0.Rows[i].Cells[0].Value.ToString()) != 0.0) && (double.Parse(dataGridView_0.Rows[i].Cells[1].Value.ToString()) != 0.0))
                {
                    num++;
                }
            }
        }
        double[] numArray = new double[num * 2];
        int index = 0;
        for (int j = 0; j < dataGridView_0.Rows.Count; j++)
        {
            if (((dataGridView_0.Rows[j].Cells[0].Value != null) && (dataGridView_0.Rows[j].Cells[1].Value != null)) && ((dataGridView_0.Rows[j].Cells[0].Value.ToString() != "") && (dataGridView_0.Rows[j].Cells[1].Value.ToString() != "")))
            {
                if (j == 0)
                {
                    index = j * 2;
                    numArray[index] = double.Parse(dataGridView_0.Rows[j].Cells[0].FormattedValue.ToString());
                    numArray[index + 1] = double.Parse(dataGridView_0.Rows[j].Cells[1].FormattedValue.ToString());
                }
                else if ((double.Parse(dataGridView_0.Rows[j].Cells[0].FormattedValue.ToString()) != 0.0) && (double.Parse(dataGridView_0.Rows[j].Cells[1].FormattedValue.ToString()) != 0.0))
                {
                    index = j * 2;
                    numArray[index] = double.Parse(dataGridView_0.Rows[j].Cells[0].FormattedValue.ToString());
                    numArray[index + 1] = double.Parse(dataGridView_0.Rows[j].Cells[1].FormattedValue.ToString());
                }
            }
        }
        return numArray;
    }

    private void rbSelNodeFill_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbSelNodeFill.Checked)
        {
            this.class10_settings_0.mapGraphSelect_0 = MapGraphSelect.fill;
        }
        else
        {
            this.class10_settings_0.mapGraphSelect_0 = MapGraphSelect.sqaure;
        }
    }

    private void rCelcuis_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            TemperatureUnits units = this.class10_settings_0.temperatureUnits_0;
            if (units == TemperatureUnits.C)
            {
                this.class10_settings_0.temperatureUnits_0 = TemperatureUnits.F;
            }
            else
            {
                this.class10_settings_0.temperatureUnits_0 = TemperatureUnits.C;
            }
        }
    }

    private void rLambda2_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            if (this.rAfr.Checked)
            {
                this.class10_settings_0.airFuelUnits_0 = AirFuelUnits.afr;
            }
            else
            {
                this.class10_settings_0.airFuelUnits_0 = AirFuelUnits.lambda;
            }
            this.method_1();
        }
    }

    public void OpenThisTab(string TabName)
    {
        if (TabName == "Wideband") this.tabControl1.SelectTab(this.tabWideband.Name);
        if (TabName == "Datalogging") this.tabControl1.SelectTab(this.tabDatalogging.Name);
        if (TabName == "Analogs") this.tabControl1.SelectTab(this.tabAnalog1.Name);
        if (TabName == "Overlay") this.tabControl1.SelectTab(this.tabOverlayAfr.Name);
        if (TabName == "AutoAdjust") this.tabControl1.SelectTab(this.tabAutoAdjust.Name);
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.method_2();
        this.string_0 = this.tabControl1.SelectedTab.Name;
        this.method_1();
    }

    private void trkSamplingRate_ValueChanged(object sender, EventArgs e)
    {
        this.txtbSampleRate.Text = this.trkSamplingRate.Value.ToString();
    }

    private void trkSmooth_ValueChanged(object sender, EventArgs e)
    {
        this.txtbSmooth.Text = (((float)this.trkSmooth.Value) / 100f).ToString("0.00");
    }

    private void txtbEmuTimeOut_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_255(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbGas_TextChanged(object sender, EventArgs e)
    {
        if (!this.bool_1 && !this.bool_0)
        {
            this.cmbGasType.SelectedIndex = 0;
        }
    }

    private void txtbGas_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox)sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, Interger required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void txtbSampleRate_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            this.trkSamplingRate.Value = int.Parse(this.txtbSampleRate.Text);
        }
    }

    private void txtbSampleRate_Leave(object sender, EventArgs e)
    {
        this.trkSamplingRate.Value = int.Parse(this.txtbSampleRate.Text);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(Form.ActiveForm, "Are you sure you want to reset settings?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
        {
            this.class18_0.method_68();
            this.CloseWindows();
            this.class10_settings_0.Reset_Default();
            this.class10_settings_0.ResetOtherSettings();
            this.ReopenWindows(sender, e);
        }
    }

    private void CloseWindows()
    {
        if (this.FrmMain_0.frmSettings_0 != null) this.FrmMain_0.frmSettings_0.Dispose();
        this.FrmMain_0.frmSettings_0 = null;
        if (this.FrmMain_0.frmDataDisplay_0 != null) this.FrmMain_0.frmDataDisplay_0.Close();
        this.FrmMain_0.frmDataDisplay_0 = null;
        if (this.FrmMain_0.frmDataGrid_0 != null) this.FrmMain_0.frmDataGrid_0.Close();
        this.FrmMain_0.frmDataGrid_0 = null;
        if (this.FrmMain_0.frmDatalogGraphs_0 != null) this.FrmMain_0.frmDatalogGraphs_0.Close();
        this.FrmMain_0.frmDatalogGraphs_0 = null;
        if (this.FrmMain_0.frmErrorCodes_0 != null) this.FrmMain_0.frmErrorCodes_0.Close();
        this.FrmMain_0.frmErrorCodes_0 = null;
        if (this.FrmMain_0.frmParameters_0 != null) this.FrmMain_0.frmParameters_0.Close();
        this.FrmMain_0.frmParameters_0 = null;
        if (this.FrmMain_0.frmGridChart_0 != null) this.FrmMain_0.frmGridChart_0.Close();
        this.FrmMain_0.frmGridChart_0 = null;
    }

    private void ReopenWindows(object sender, EventArgs e)
    {
        //this.FrmMain_0.displayToolStripButton_Click(sender, e);
        //this.FrmMain_0.sensorToolStripButton_Click(sender, e);
        //this.FrmMain_0.SerialMenuToolStripMenuItem_Click(sender, e);
        //this.FrmMain_0.tablesToolStripButton_Click(sender, e);

        this.FrmMain_0.LoadPages();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button3.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button3.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void button4_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button4.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button4.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void button6_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button6.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button6.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void button5_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button5.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button5.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void lstDtComm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP)
        {
            this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.lstDtComm.Text);
            this.lstEmuBaud.SelectedIndex = this.lstEmuBaud.FindString(this.lstDtBaud.Text);
        }
    }

    private void lstDtBaud_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.PGMFI_RTP)
        {
            this.lstEmuPort.SelectedIndex = this.lstEmuPort.FindString(this.lstDtComm.Text);
            this.lstEmuBaud.SelectedIndex = this.lstEmuBaud.FindString(this.lstDtBaud.Text);
        }
    }

    private void btnFuel1_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnFuel1.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnFuel1.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnFuel2_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnFuel2.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnFuel2.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnFuel3_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnFuel3.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnFuel3.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnFuel4_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnFuel4.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnFuel4.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnIgn1_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnIgn1.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnIgn1.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnIgn2_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnIgn2.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnIgn2.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnIgn3_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnIgn3.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnIgn3.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnIgn4_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnIgn4.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnIgn4.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnVE1_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnVE1.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnVE1.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void btnVE2_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.btnVE2.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.btnVE2.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void button7_Click(object sender, EventArgs e)
    {
        this.FrmMain_0.SensorWarning_Click(sender, e);
    }

    private void button8_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button8.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button8.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
        openFileDialog2 = new OpenFileDialog();
        openFileDialog2.Filter = "";

        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        string sep = string.Empty;

        foreach (var c in codecs)
        {
            string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
            openFileDialog2.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog2.Filter, sep, codecName, c.FilenameExtension);
            sep = "|";
        }
        openFileDialog2.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog2.Filter, sep, "All Files", "*.*");
        openFileDialog2.DefaultExt = ".png";

        DialogResult result = openFileDialog2.ShowDialog();
        if (result == DialogResult.OK)
        {
            Image myimage = new Bitmap(openFileDialog2.FileName);
            this.pictureBox2.BackgroundImage = new Bitmap(myimage);
            myimage.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp", ImageFormat.Bmp);
            this.FrmMain_0.SetImageBackgrounds();
            myimage.Dispose();
        }
    }

    private void button12_Click(object sender, EventArgs e)
    {
        FileInfo info = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back2.bmp");
        if (info.Exists) info.Delete();
        info = null;
        this.pictureBox2.BackgroundImage = null;
        this.FrmMain_0.SetImageBackgrounds();
    }

    private void button9_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button9.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button9.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void button10_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button10.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button10.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            this.class10_settings_0.LoadSettings(openFileDialog1.FileName);
        }
    }

    private void pictureBox1_Click_1(object sender, EventArgs e)
    {
        openFileDialog2 = new OpenFileDialog();
        openFileDialog2.Filter = "";

        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        string sep = string.Empty;

        foreach (var c in codecs)
        {
            string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
            openFileDialog2.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog2.Filter, sep, codecName, c.FilenameExtension);
            sep = "|";
        }
        openFileDialog2.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog2.Filter, sep, "All Files", "*.*");
        openFileDialog2.DefaultExt = ".png";

        DialogResult result = openFileDialog2.ShowDialog();
        if (result == DialogResult.OK)
        {
            Image myimage = new Bitmap(openFileDialog2.FileName);
            this.pictureBox1.BackgroundImage = new Bitmap(myimage);
            myimage.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back1.bmp", ImageFormat.Bmp);
            this.FrmMain_0.SetImageBackgrounds();
            myimage.Dispose();
        }
    }

    private void button11_Click_1(object sender, EventArgs e)
    {
        FileInfo info = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BMTune\Back1.bmp");
        if (info.Exists) info.Delete();
        info = null;
        this.pictureBox1.BackgroundImage = null;
        this.FrmMain_0.SetImageBackgrounds();
    }

    private void button13_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button13.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button13.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void groupBox_1_Enter(object sender, EventArgs e)
    {

    }

    private void chkDisableOverCond_CheckedChanged(object sender, EventArgs e)
    {
        groupBox11.Enabled = !this.chkDisableOverCond.Checked;
    }

    private void lstEmuPort_DropDown(object sender, EventArgs e)
    {
        /*lstEmuPort.Items.Clear();
        if (this.class10_0.AllPorts)
        {
            for (int i = 0; i < 40; i++)
            {
                lstEmuPort.Items.Add("COM" + (i + 1));
            }
        }
        else
        {
            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                lstEmuPort.Items.Add("COM1");
            }
            else
            {
                for (int i = 1; i <= 40; i++)
                {
                    for (int i2 = 0; i2 < portNames.Length; i2++)
                    {
                        string SearchStr = "COM" + i;
                        string SearchStr2 = "COM" + i + " (Bluetooth)";

                        if (!IsEnglish(portNames[i2])) portNames[i2] = portNames[i2].Substring(0, portNames[i2].Length - 1) + " (Bluetooth)";

                        if (portNames[i2] == SearchStr || portNames[i2] == SearchStr2)
                        {
                            lstEmuPort.Items.Add(portNames[i2]);
                        }
                    }
                }
            }
        }*/
    }


    private void lstDtComm_DropDown(object sender, EventArgs e)
    {
        /*lstDtComm.Items.Clear();
        if (this.class10_0.AllPorts)
        {
            for (int i = 0; i < 40; i++)
            {
                lstDtComm.Items.Add("COM" + (i + 1));
            }
        }
        else
        {
            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                lstDtComm.Items.Add("COM1");
            }
            else
            {
                for (int i = 1; i <= 40; i++)
                {
                    for (int i2 = 0; i2 < portNames.Length; i2++)
                    {
                        string SearchStr = "COM" + i;
                        string SearchStr2 = "COM" + i + " (Bluetooth)";

                        if (!IsEnglish(portNames[i2])) portNames[i2] = portNames[i2].Substring(0, portNames[i2].Length - 1) + " (Bluetooth)";

                        if (portNames[i2] == SearchStr || portNames[i2] == SearchStr2)
                        {
                            lstDtComm.Items.Add(portNames[i2]);
                        }
                    }
                }
            }
        }*/
    }

    private bool IsEnglish(string inputstring)
    {
        Regex regex = new Regex(@"[A-Za-z0-9 .,-=+(){}\[\]\\]");
        MatchCollection matches = regex.Matches(inputstring);

        if (matches.Count.Equals(inputstring.Length))
            return true;
        else
            return false;
    }

    /*private void ApplyEmuCOMtoSettings()
    {
        string ApplyTxt = "COM1";
        if (this.lstEmuPort.SelectedItem != null)
        {
            if (this.lstEmuPort.SelectedItem.ToString() != "")
            {
                ApplyTxt = this.lstEmuPort.SelectedItem.ToString();
                if (ApplyTxt.Contains("Bluetooth")) ApplyTxt = ApplyTxt.Substring(0, ApplyTxt.Length - 12);
            }
        }
        this.class10_0.string_2 = ApplyTxt;
    }

    private void ApplyDatalogCOMtoSettings()
    {
        string ApplyTxt = "COM1";
        if (this.lstDtComm.SelectedItem != null)
        {
            if (this.lstDtComm.SelectedItem.ToString() != "")
            {
                ApplyTxt = this.lstDtComm.SelectedItem.ToString();
                if (ApplyTxt.Contains("Bluetooth")) ApplyTxt = ApplyTxt.Substring(0, ApplyTxt.Length - 12);
            }
        }
        this.class10_0.string_1 = ApplyTxt;
    }*/

    private void lstEmuPort_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
        {
            this.lstDtComm.SelectedIndex = this.lstDtComm.FindString(this.lstEmuPort.Text);
            this.lstDtBaud.SelectedIndex = this.lstDtBaud.FindString(this.lstEmuBaud.Text);
        }
    }

    private void lstEmuBaud_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.class10_settings_0.emulatorMode_0 == EmulatorMode.Demon)
        {
            this.lstDtComm.SelectedIndex = this.lstDtComm.FindString(this.lstEmuPort.Text);
            this.lstDtBaud.SelectedIndex = this.lstDtBaud.FindString(this.lstEmuBaud.Text);
        }
    }

    private void Button14_Click(object sender, EventArgs e)
    {
        this.colorDialog_0 = new ColorDialog();
        this.colorDialog_0.AllowFullOpen = true;
        this.colorDialog_0.AnyColor = true;
        this.colorDialog_0.Color = this.button_LedDark.BackColor;
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.button_LedDark.BackColor = this.colorDialog_0.Color;
        }
        this.colorDialog_0.Dispose();
        this.colorDialog_0 = null;
    }

    private void RbTracingSingle_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbTracingSingle.Checked) this.class10_settings_0.tunerSmartTrack = 0;
        else if (this.rbTracingQuad.Checked) this.class10_settings_0.tunerSmartTrack = 1;
        else if (this.rbTracingRow.Checked) this.class10_settings_0.tunerSmartTrack = 2;
        else if (this.rbTracingColumn.Checked) this.class10_settings_0.tunerSmartTrack = 3;
        else if (this.rbTracingRowColumn.Checked) this.class10_settings_0.tunerSmartTrack = 4;
    }

    private void button14_Click_1(object sender, EventArgs e)
    {
        this.FrmMain_0.ExecuteNotAsAdmin(this.class10_settings_0.path);
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start("http://www.ftdichip.com/Drivers/CDM/CDM21228_Setup.zip");
    }

    private void button16_Click(object sender, EventArgs e)
    {
        string SaveFileStr = "";
        SaveFileStr += "Color1=" + GetColorStringFromColor(this.class10_settings_0.color_OnDark) + Environment.NewLine;
        SaveFileStr += "Color2=" + GetColorStringFromColor(this.class10_settings_0.color_On) + Environment.NewLine;
        SaveFileStr += "Color3=" + GetColorStringFromColor(this.class10_settings_0.color_Off) + Environment.NewLine;
        SaveFileStr += "Color4=" + GetColorStringFromColor(this.class10_settings_0.color_3) + Environment.NewLine;
        SaveFileStr += "Color5=" + GetColorStringFromColor(this.class10_settings_0.color_4) + Environment.NewLine;
        SaveFileStr += "Color6=" + GetColorStringFromColor(this.class10_settings_0.color_Trail) + Environment.NewLine;
        SaveFileStr += "Color7=" + GetColorStringFromColor(this.class10_settings_0.color_Trace) + Environment.NewLine;
        SaveFileStr += "Color8=" + GetColorStringFromColor(this.class10_settings_0.color_2) + Environment.NewLine;
        SaveFileStr += "Color9=" + GetColorStringFromColor(this.class10_settings_0.color_7) + Environment.NewLine;
        SaveFileStr += "Color10=" + GetColorStringFromColor(this.class10_settings_0.color_8) + Environment.NewLine;
        SaveFileStr += "Color11=" + GetColorStringFromColor(this.class10_settings_0.color_9) + Environment.NewLine;
        SaveFileStr += "Color12=" + GetColorStringFromColor(this.class10_settings_0.color_10) + Environment.NewLine;
        SaveFileStr += "Color13=" + GetColorStringFromColor(this.class10_settings_0.color_11) + Environment.NewLine;
        SaveFileStr += "Color14=" + GetColorStringFromColor(this.class10_settings_0.color_12) + Environment.NewLine;
        SaveFileStr += "Color15=" + GetColorStringFromColor(this.class10_settings_0.color_13) + Environment.NewLine;
        SaveFileStr += "Color16=" + GetColorStringFromColor(this.class10_settings_0.color_14) + Environment.NewLine;
        SaveFileStr += "Color17=" + GetColorStringFromColor(this.class10_settings_0.color_20) + Environment.NewLine;
        SaveFileStr += "Color18=" + GetColorStringFromColor(this.class10_settings_0.color_21) + Environment.NewLine;
        SaveFileStr += "Color19=" + GetColorStringFromColor(this.class10_settings_0.color_22) + Environment.NewLine;
        SaveFileStr += "Color20=" + GetColorStringFromColor(this.class10_settings_0.color_23) + Environment.NewLine;
        SaveFileStr += "Color21=" + GetColorStringFromColor(this.class10_settings_0.color_30) + Environment.NewLine;
        SaveFileStr += "Color22=" + GetColorStringFromColor(this.class10_settings_0.color_31) + Environment.NewLine;
        SaveFileStr += "Color23=" + GetColorStringFromColor(this.class10_settings_0.color_32) + Environment.NewLine;
        SaveFileStr += "Color24=" + GetColorStringFromColor(this.class10_settings_0.color_33) + Environment.NewLine;
        SaveFileStr += "Color25=" + GetColorStringFromColor(this.class10_settings_0.color_40) + Environment.NewLine;
        SaveFileStr += "Color26=" + GetColorStringFromColor(this.class10_settings_0.color_41) + Environment.NewLine;
        SaveFileStr += "Color27=" + this.class10_settings_0.PercentColor1.ToString() + Environment.NewLine;
        SaveFileStr += "Color28=" + this.class10_settings_0.PercentColor2.ToString() + Environment.NewLine;
        SaveFileStr += "Color29=" + this.class10_settings_0.PercentColorIgn.ToString() + Environment.NewLine;

        DialogResult result = saveFileDialog2.ShowDialog();
        if (result == DialogResult.OK)
        {
            File.Create(saveFileDialog2.FileName).Dispose();
            File.WriteAllText(saveFileDialog2.FileName, SaveFileStr);
        }
    }

    private string GetColorStringFromColor(Color ThisColorsToConvert)
    {
        return ThisColorsToConvert.R + "," + ThisColorsToConvert.G + "," + ThisColorsToConvert.B;
    }

    private Color GetColorFromString(string ThisStr)
    {
        Color returningColor = Color.FromArgb(0, 0, 0);
        if (ThisStr.Contains(","))
        {
            string[] SplitColorStr = ThisStr.Split(',');
            returningColor = Color.FromArgb(int.Parse(SplitColorStr[0]), int.Parse(SplitColorStr[1]), int.Parse(SplitColorStr[2]));
        }
        return returningColor;
    }

    private void button15_Click(object sender, EventArgs e)
    {

        DialogResult result = openFileDialog3.ShowDialog();
        if (result == DialogResult.OK)
        {
            string[] AllLines = File.ReadAllLines(openFileDialog3.FileName);
            if (AllLines.Length > 0)
            {
                for (int i = 0; i < AllLines.Length; i++)
                {
                    if (AllLines[i].Contains("=")) 
                    {
                        string[] ColorStrSplit = AllLines[i].Split('=');

                        if (AllLines[i].Contains("Color1=")) this.class10_settings_0.color_OnDark = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color2=")) this.class10_settings_0.color_On = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color3=")) this.class10_settings_0.color_Off = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color4=")) this.class10_settings_0.color_3 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color5=")) this.class10_settings_0.color_4 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color6=")) this.class10_settings_0.color_Trail = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color7=")) this.class10_settings_0.color_Trace = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color8=")) this.class10_settings_0.color_2 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color9=")) this.class10_settings_0.color_7 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color10=")) this.class10_settings_0.color_8 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color11=")) this.class10_settings_0.color_9 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color12=")) this.class10_settings_0.color_10 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color13=")) this.class10_settings_0.color_11 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color14=")) this.class10_settings_0.color_12 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color15=")) this.class10_settings_0.color_13 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color16=")) this.class10_settings_0.color_14 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color17=")) this.class10_settings_0.color_20 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color18=")) this.class10_settings_0.color_21 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color19=")) this.class10_settings_0.color_22 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color20=")) this.class10_settings_0.color_23 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color21=")) this.class10_settings_0.color_30 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color22=")) this.class10_settings_0.color_31 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color23=")) this.class10_settings_0.color_32 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color24=")) this.class10_settings_0.color_33 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color25=")) this.class10_settings_0.color_40 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color26=")) this.class10_settings_0.color_41 = GetColorFromString(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color27=")) this.class10_settings_0.PercentColor1 = int.Parse(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color28=")) this.class10_settings_0.PercentColor2 = int.Parse(ColorStrSplit[1]);
                        if (AllLines[i].Contains("Color29=")) this.class10_settings_0.PercentColorIgn = int.Parse(ColorStrSplit[1]);
                    }
                }

                this.method_1();
            }
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.comboBoxBurner.Text == "Integrated (BMBurner/Burn2)")
        {
            this.linkLabelBurner.Visible = false;
            this.labelLinkBurnerName.Visible = false;
            this.textBoxBurnerLocation.Visible = false;
            this.labelBurnerLocation.Visible = false;
            this.textBoxBurnerLocation.Text = "";    //Assembly.GetEntryAssembly().Location;
            this.labelBurnerDesc.Text = "This uses the internal chip burner code.";
            this.class10_settings_0.BurnerSoftware = 0;
            this.class10_settings_0.BurnerLocation = "";
            return;
        }
        if (this.comboBoxBurner.Text == "Moates Flash & Burn 2")
        {
            this.labelBurnerDesc.Text = "Offical Flash && Burn software by Moates." + Environment.NewLine + "Used with the Burn1 and Burn2 EEPROM burners," + Environment.NewLine + "as well as the Autoprom (APU1).";
            this.linkLabelBurner.Visible = true;
            this.labelLinkBurnerName.Visible = true;
            this.textBoxBurnerLocation.Visible = true;
            this.labelBurnerLocation.Visible = true;
            this.linkLabelBurner.Text = "http://support.moates.net/flash-n-burn/";
            this.class10_settings_0.BurnerSoftware = 1;
            if (File.Exists("C:\\Program Files (x86)\\Flash N Burn\\FlashBurn.exe"))
            {
                this.textBoxBurnerLocation.Text = "C:\\Program Files (x86)\\Flash N Burn\\FlashBurn.exe";
                this.class10_settings_0.BurnerLocation = this.textBoxBurnerLocation.Text;
                return;
            }
            if (File.Exists("C:\\Program Files\\Flash N Burn\\FlashBurn.exe"))
            {
                this.textBoxBurnerLocation.Text = "C:\\Program Files\\Flash N Burn\\FlashBurn.exe";
                this.class10_settings_0.BurnerLocation = this.textBoxBurnerLocation.Text;
                return;
            }
            if (!File.Exists(this.textBoxBurnerLocation.Text) && !this.textBoxBurnerLocation.Text.Contains("FlashBurn.exe"))
            {
                DialogResult dialogResult = MessageBox.Show("Unable to locate Flash & Burn Software, Do you want to manually select it?", "Flash & Burn Location:", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    this.comboBoxBurner.SelectedIndex = 0;
                    return;
                }
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "FlashBurn.exe|FlashBurn.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
                {
                    this.textBoxBurnerLocation.Text = openFileDialog.FileName;
                    this.class10_settings_0.BurnerLocation = this.textBoxBurnerLocation.Text;
                    return;
                }
            }
        }
        else if (this.comboBoxBurner.Text == "Mini Pro")
        {
            this.linkLabelBurner.Visible = true;
            this.labelLinkBurnerName.Visible = true;
            this.textBoxBurnerLocation.Visible = true;
            this.labelBurnerLocation.Visible = true;
            this.linkLabelBurner.Text = "http://www.autoelectric.cn/en/tl866_main.html";
            this.class10_settings_0.BurnerSoftware = 2;
            this.labelBurnerDesc.Text = "This uses the MiniPro software" + Environment.NewLine + "Well-designed cheap professional programmer";
            if (File.Exists("D:\\MiniPro\\MiniPro.exe"))
            {
                this.textBoxBurnerLocation.Text = "D:\\MiniPro\\MiniPro.exe";
                this.class10_settings_0.BurnerLocation = this.textBoxBurnerLocation.Text;
                return;
            }
            if (File.Exists("C:\\MiniPro\\MiniPro.exe"))
            {
                this.textBoxBurnerLocation.Text = "C:\\MiniPro\\MiniPro.exe";
                this.class10_settings_0.BurnerLocation = this.textBoxBurnerLocation.Text;
                return;
            }
            if (!File.Exists(this.textBoxBurnerLocation.Text) && !this.textBoxBurnerLocation.Text.Contains("MiniPro.exe"))
            {
                DialogResult dialogResult2 = MessageBox.Show("Unable to locate MiniPro Software, Do you want to manually select it?", "MiniPro Location:", MessageBoxButtons.YesNo);
                if (dialogResult2 != DialogResult.Yes)
                {
                    this.comboBoxBurner.SelectedIndex = 0;
                    return;
                }
                OpenFileDialog openFileDialog2 = new OpenFileDialog();
                openFileDialog2.Filter = "MiniPro.exe|MiniPro.exe";
                if (openFileDialog2.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog2.FileName))
                {
                    this.textBoxBurnerLocation.Text = openFileDialog2.FileName;
                    this.class10_settings_0.BurnerLocation = this.textBoxBurnerLocation.Text;
                    return;
                }
            }
        }
        else
        {
            this.comboBoxBurner.SelectedIndex = 0;
        }
    }

    private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        DialogResult result = openFileDialog4.ShowDialog();
        if (result == DialogResult.OK)
        {
            this.textBoxBurnerLocation.Text = openFileDialog4.FileName;
        }
    }
}

