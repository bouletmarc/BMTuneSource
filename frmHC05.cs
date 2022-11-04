using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

internal class frmHC05 : Form
{
    private TableLayoutPanel tableLayoutPanel1;
    private Label label3;
    private Label label2;
    private Label label1;
    private Button button1;
    private Label label4;
    private Button button2;
    private MaskedTextBox maskedTextBox1;
    private Label label5;
    private Label label6;
    private Button button3;
    private Label label9;
    private Label label10;
    private Label label11;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private RadioButton radioButton3;
    private MaskedTextBox maskedTextBox4;
    private ComboBox comboBox1;
    private ComboBox comboBox2;
    private Button button4;
    private Button button5;
    private MaskedTextBox maskedTextBox5;
    private Label label12;
    private Label label8;
    private MaskedTextBox maskedTextBox3;
    private MaskedTextBox maskedTextBox2;
    private Label label7;
    private Label label13;
    private Label label14;
    private Button button6;
    private List<string> Coms = new List<string>();
    public static SerialPort HC05FlashPort = new SerialPort();
    private System.Windows.Forms.Timer timer1;
    private IContainer components;
    private static bool ATMOODE = false;
    private static int Steep = 0;
    private static int Failed = 0;
    private static string[] Read = new string[] { "", "", "", "", "", "" };
    private bool FSTART;
    private static bool JDY31 = false;

    public frmHC05()
    {
        this.InitializeComponent();
        //HC05FlashPort.DataReceived += new SerialDataReceivedEventHandler(frmHC05.HC05FlashPort_DataReceived);

        /*foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }*/
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (this.button1.Text != "Next")
        {
            this.Coms.Clear();
            this.button1.Text = "Next";
            this.timer1.Enabled = false;
        }
        else
        {
            MessageBox.Show(Form.ActiveForm, "Make sure the device is currenty unplugged", "BMTune");
            this.button1.Text = "Restart Steps";
            foreach (string str in SerialPort.GetPortNames())
            {
                this.Coms.Add(str);
            }
            MessageBox.Show(Form.ActiveForm, "Hold down the AT Mode Button on the HC05 and Plug usb in Or if using JDY-31 Make sure no bluetooth connections are currently made to device.\n\nWhen ready press OK and plug the device as suggested", "BMTune");

            Steep = 0;
            this.timer1.Enabled = true;
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.button2.Text = "Connecting..";
        this.button2.Enabled = false;
        this.Connect();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        this.FSTART = true;
        Steep = 1;
        this.button3.Enabled = false;
        this.button3.Text = "Reading..";
        this.timer1.Enabled = true;
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        this.button4.Text = "Flashing..";
        this.button4.Enabled = false;
        if (!JDY31)
        {
            HC05FlashPort.WriteLine("AT+NAME=" + this.maskedTextBox4.Text + "\r");
            //Thread.Sleep(500);
            HC05FlashPort_ReadBack();

            if (this.radioButton1.Checked)
            {
                HC05FlashPort.WriteLine("AT+ROLE=0\r");
            }
            else if (this.radioButton2.Checked)
            {
                HC05FlashPort.WriteLine("AT+ROLE=1\r");
            }
            else if (this.radioButton3.Checked)
            {
                HC05FlashPort.WriteLine("AT+ROLE=2\r");
            }
            //Thread.Sleep(500);
            HC05FlashPort_ReadBack();

            HC05FlashPort.WriteLine("AT+PSWD=" + this.maskedTextBox5.Text + "\r");
            //Thread.Sleep(500);
            HC05FlashPort_ReadBack();

            HC05FlashPort.WriteLine("AT+UART=" + this.comboBox1.Text + ",0,0\r");
            //Thread.Sleep(500);
            HC05FlashPort_ReadBack();
        }
        else
        {
            string str = "AT+NAME" + this.maskedTextBox4.Text + "\n\r";
            HC05FlashPort.Write(str);
            //Thread.Sleep(0x3e8);
            Thread.Sleep(500);
            HC05FlashPort_ReadBack();

            str = "AT+PIN" + this.maskedTextBox5.Text + "\n\r";
            HC05FlashPort.Write(str);
            //Thread.Sleep(0x3e8);
            Thread.Sleep(500);
            HC05FlashPort_ReadBack();

            string str2 = "4";
            if (this.comboBox1.Text == "19200")
            {
                str2 = "5";
            }
            if (this.comboBox1.Text == "38400")
            {
                str2 = "6";
            }
            if (this.comboBox1.Text == "57600")
            {
                str2 = "7";
            }
            if (this.comboBox1.Text == "115200")
            {
                str2 = "8";
            }
            if (this.comboBox1.Text == "128000")
            {
                str2 = "9";
            }
            str = "AT+BAUD" + str2 + "\n\r";
            HC05FlashPort.Write(str);
            HC05FlashPort_ReadBack();
        }
        Thread.Sleep(500);
        MessageBox.Show(Form.ActiveForm, "Sent flash command. Restart device now for settings to take effect.", "BMTune");
        this.button4.Text = "Flash";
    }

    private void Button5_Click(object sender, EventArgs e)
    {
        if (!JDY31)
        {
            HC05FlashPort.WriteLine("AT+RESET\r");
            HC05FlashPort_ReadBack();
            MessageBox.Show(Form.ActiveForm, "Restarting HC05 Unit.", "BMTune");
            this.failed();
        }
        else
        {
            string str = "AT+RESET\n\r";
            HC05FlashPort.Write(str);
            HC05FlashPort_ReadBack();
            MessageBox.Show(Form.ActiveForm, "Restarting JDY-31 Unit.", "BMTune");
            this.failed();
        }
    }

    private void Button6_Click(object sender, EventArgs e)
    {
        if (!JDY31)
        {
            HC05FlashPort.WriteLine("AT+ORGL\r");
            //Thread.Sleep(0x3e8);
            Thread.Sleep(500);
            HC05FlashPort_ReadBack();
            HC05FlashPort.WriteLine("AT+RESET\r");
            HC05FlashPort_ReadBack();
            MessageBox.Show(Form.ActiveForm, "Restored unit to factory settings.", "BMTune");
            this.failed();
        }
        else
        {
            string str = "AT+DEFAULT\n\r";
            HC05FlashPort.Write(str);
            //Thread.Sleep(0x3e8);
            Thread.Sleep(500);
            HC05FlashPort_ReadBack();
            str = "AT+RESET\n\r";
            HC05FlashPort.Write(str);
            HC05FlashPort_ReadBack();
            MessageBox.Show(Form.ActiveForm, "Restored unit to factory settings.", "BMTune");
            this.failed();
        }
    }

    public void Connect()
    {
        WorkThreadFunction();
        /*new Thread(delegate {
            Thread.CurrentThread.IsBackground = true;
            this.WorkThreadFunction();
        }).Start();*/
    }

    public void DoThisAllTheTime()
    {
        if (!JDY31)
        {
            switch (Steep)
            {
                case 0:
                    foreach (string str4 in SerialPort.GetPortNames())
                    {
                        if (!this.Coms.Contains(str4))
                        {
                            this.timer1.Enabled = false;
                            this.maskedTextBox1.Text = str4;
                            this.button2.Enabled = true;
                            this.button1.Text = "Restart Steps";
                        }
                    }
                    break;

                case 1:
                    HC05FlashPort.WriteLine("AT+VERSION?\r");
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 2:
                    HC05FlashPort.WriteLine("AT+ROLE?\r");
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 3:
                    HC05FlashPort.WriteLine("AT+ADDR?\r");
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 4:
                    HC05FlashPort.WriteLine("AT+PSWD?\r");
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 5:
                    HC05FlashPort.WriteLine("AT+UART?\r");
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 6:
                    HC05FlashPort.WriteLine("AT+NAME?\r");
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 7:
                {
                    this.timer1.Enabled = false;
                    this.button3.Enabled = true;
                    this.button3.Text = "Read";
                    if (Read[0] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Version from" + " HC05", "BMTune");
                    }
                    if (Read[1] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Role from" + " HC05, Setting default master.", "BMTune");
                        Read[1] = "0";
                    }
                    if (Read[2] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Address from" + " HC05", "BMTune");
                    }
                    if (Read[3] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Password from" + " HC05, Setting default 1234.", "BMTune");
                        Read[3] = "1234";
                    }
                    if (Read[4] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read BuadRate from" + " HC05, Setting default 38400.", "BMTune");
                        Read[4] = "38400,0,0";
                    }
                    if (Read[5] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Name from" + " HC05, Setting default HC05.", "BMTune");
                        Read[5] = "HC-05";
                    }
                    this.maskedTextBox2.Text = Read[0].Replace("\r", "");
                    int num4 = 0;
                    try
                    {
                        num4 = int.Parse(Read[1].Replace("\r", ""));
                    }
                    catch
                    {
                    }
                    if (num4 == 0)
                    {
                        this.radioButton1.Checked = true;
                    }
                    else if (num4 == 1)
                    {
                        this.radioButton2.Checked = true;
                    }
                    else if (num4 == 2)
                    {
                        this.radioButton3.Checked = true;
                    }
                    this.maskedTextBox4.Text = Read[5].Replace("\r", "");
                    this.maskedTextBox3.Text = Read[2].Replace("\r", "");
                    this.maskedTextBox5.Text = Read[3].Replace("\r", "");
                    char[] separator = new char[] { ',' };
                    Read[4] = Read[4].Replace("\r", "").Split(separator)[0];
                    this.comboBox1.Text = Read[4];
                    this.radioButton1.Enabled = true;
                    this.radioButton2.Enabled = true;
                    this.radioButton3.Enabled = true;
                    this.maskedTextBox4.Enabled = true;
                    this.comboBox1.Enabled = true;
                    this.comboBox2.Enabled = false;
                    this.maskedTextBox5.Enabled = true;
                    this.button4.Enabled = false;
                    this.FSTART = false;
                    break;
                }
                default:
                    break;
            }
        }
        else
        {
            string str;
            switch (Steep)
            {
                case 0:
                    foreach (string str2 in SerialPort.GetPortNames())
                    {
                        if (!this.Coms.Contains(str2))
                        {
                            this.timer1.Enabled = false;
                            this.maskedTextBox1.Text = str2;
                            this.button2.Enabled = true;
                            this.button1.Text = "Restart Steps";
                        }
                    }
                    break;

                case 1:
                    str = "AT+VERSION\n\r";
                    HC05FlashPort.Write(str);
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 2:
                    str = "AT+LADDR\n\r";
                    HC05FlashPort.Write(str);
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 3:
                    str = "AT+NAME\n\r";
                    HC05FlashPort.Write(str);
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 4:
                    str = "AT+BAUD\n\r";
                    HC05FlashPort.Write(str);
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 5:
                    str = "AT+PIN\n\r";
                    HC05FlashPort.Write(str);
                    HC05FlashPort_ReadBack();
                    Failed++;
                    break;

                case 6:
                {
                    this.timer1.Enabled = false;
                    this.button3.Enabled = true;
                    this.button3.Text = "Read";
                    if (Read[0] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Version from" + " JDY31", "BMTune");
                    }
                    if (Read[1] == "")
                    {
                        Read[1] = "0";
                    }
                    if (Read[2] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Password from" + " JDY31", "BMTune");
                    }
                    if (Read[3] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Password from" + " JDY31, Setting default 1234.", "BMTune");
                        Read[3] = "1234";
                    }
                    if (Read[4] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read BuadRate from" + " JDY31, Setting default 38400.", "BMTune");
                        Read[4] = "38400,0,0";
                    }
                    if (Read[5] == "")
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to read Name from" + " JDY31, Setting default JDY31.", "BMTune");
                        Read[5] = "HC-05";
                    }
                    this.maskedTextBox2.Text = Read[0].Replace("\r", "");
                    int num = 0;
                    try
                    {
                        num = int.Parse(Read[1].Replace("\r", ""));
                    }
                    catch
                    {
                    }
                    if (num == 0)
                    {
                        this.radioButton1.Checked = true;
                    }
                    else if (num == 1)
                    {
                        this.radioButton2.Checked = true;
                    }
                    else if (num == 2)
                    {
                        this.radioButton3.Checked = true;
                    }
                    this.maskedTextBox4.Text = Read[5].Replace("\r", "");
                    this.maskedTextBox3.Text = Read[2].Replace("\r", "");
                    this.maskedTextBox5.Text = Read[3].Replace("\r", "");
                    char[] separator = new char[] { ',' };
                    Read[4] = Read[4].Replace("\r", "").Split(separator)[0];
                    string str3 = Read[4];
                    if (str3 != null)
                    {
                        if (str3 == "4")
                        {
                            this.comboBox1.Text = "9600";
                        }
                        else if (str3 == "5")
                        {
                            this.comboBox1.Text = "19200";
                        }
                        else if (str3 == "6")
                        {
                            this.comboBox1.Text = "38400";
                        }
                        else if (str3 == "7")
                        {
                            this.comboBox1.Text = "57600";
                        }
                        else if (str3 == "8")
                        {
                            this.comboBox1.Text = "115200";
                        }
                        else if (str3 == "9")
                        {
                            this.comboBox1.Text = "128000";
                        }
                    }
                    this.radioButton1.Enabled = true;
                    this.radioButton2.Enabled = false;
                    this.radioButton3.Enabled = false;
                    this.maskedTextBox4.Enabled = true;
                    this.comboBox1.Enabled = true;
                    this.comboBox2.Enabled = false;
                    this.maskedTextBox5.Enabled = true;
                    this.button4.Enabled = false;
                    this.FSTART = false;
                    break;
                }
                default:
                    break;
            }
        }
        if (Failed == 10)
        {
            Failed = 0;
            Steep++;
        }
    }

    private void EnableFlash(object sender, EventArgs e)
    {
        bool flag = false;
        if (!this.FSTART)
        {
            if (this.comboBox1.Text.Length == 0)
            {
                MessageBox.Show(Form.ActiveForm, "Baud rate cant be blank.", "BMTune");
                flag = true;
            }
            if (this.maskedTextBox4.Text.Length == 0)
            {
                MessageBox.Show(Form.ActiveForm, "Name can't be blank.", "BMTune");
                flag = true;
            }
            if (this.maskedTextBox5.Text.Length != 4)
            {
                flag = true;
                if ((this.maskedTextBox5.Text.Length > 4) || (this.maskedTextBox5.Text.Length == 0))
                {
                    MessageBox.Show(Form.ActiveForm, "Pin must be 4 numbers long.", "BMTune");
                }
            }
        }
        this.button4.Enabled = !flag;
    }

    private void failed()
    {
        this.button2.Enabled = false;
        this.button2.Text = "Connect";
        this.maskedTextBox1.Text = "";
        this.button3.Enabled = false;
        this.button4.Enabled = false;
        this.button5.Enabled = false;
        this.button6.Enabled = false;
        this.radioButton1.Enabled = false;
        this.radioButton2.Enabled = false;
        this.radioButton3.Enabled = false;
        this.maskedTextBox4.Enabled = false;
        this.comboBox1.Enabled = false;
        this.comboBox2.Enabled = true;
        this.maskedTextBox5.Enabled = false;
    }

    private void FrmDyno_Load(object sender, EventArgs e)
    {
        this.button2.Enabled = false;
        this.maskedTextBox1.Text = "";
        this.button3.Enabled = false;
        this.button4.Enabled = false;
        this.button5.Enabled = false;
        this.button6.Enabled = false;
        this.radioButton1.Enabled = false;
        this.radioButton2.Enabled = false;
        this.radioButton3.Enabled = false;
        this.maskedTextBox4.Enabled = false;
        this.comboBox1.Enabled = false;
        this.comboBox2.Enabled = true;
        this.maskedTextBox5.Enabled = false;
    }

    //public static void HC05FlashPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    public void HC05FlashPort_ReadBack()
    {
        //Thread.Sleep(200);
        if (HC05FlashPort.IsOpen)
        {
            //Console.WriteLine("testt ");
            try
            {
                string str = HC05FlashPort.ReadLine();
                //Console.WriteLine("received " + str);
                if (str.Contains("OK"))
                {
                    ATMOODE = true;
                }
                if (str.Contains("+VERSION="))
                {
                    ATMOODE = true;
                    JDY31 = true;
                    Read[0] = str.Replace("+VERSION=", "");
                    Steep = 2;
                }
                if (str.Contains("+LADDR="))
                {
                    Read[2] = str.Replace("+LADDR=", "");
                    Steep = 3;
                }
                if (str.Contains("+NAME="))
                {
                    Read[5] = str.Replace("+NAME=", "");
                    Steep = 4;
                }
                if (str.Contains("+BAUD="))
                {
                    Read[4] = str.Replace("+BAUD=", "");
                    Steep = 5;
                }
                if (str.Contains("+PIN="))
                {
                    Read[3] = str.Replace("+PIN=", "");
                    Steep = 6;
                }
                if (str.Contains("+VERSION:"))
                {
                    ATMOODE = true;
                    Read[0] = str.Replace("+VERSION:", "");
                    Steep = 2;
                }
                if (str.Contains("+ROLE:"))
                {
                    Read[1] = str.Replace("+ROLE:", "");
                    Steep = 3;
                }
                if (str.Contains("+ADDR:"))
                {
                    Read[2] = str.Replace("+ADDR:", "");
                    Steep = 4;
                }
                if (str.Contains("+PSWD:"))
                {
                    Read[3] = str.Replace("+PSWD:", "");
                    Steep = 5;
                }
                if (str.Contains("+UART:"))
                {
                    Read[4] = str.Replace("+UART:", "");
                    Steep = 6;
                }
                if (str.Contains("+NAME:"))
                {
                    Read[5] = str.Replace("+NAME:", "");
                    Steep = 7;
                }
                if (str.Contains("ERROR:"))
                {
                    Failed++;
                }
            }
            catch
            {
                Failed++;
            }
        }
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHC05));
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.button6 = new System.Windows.Forms.Button();
        this.label3 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.button1 = new System.Windows.Forms.Button();
        this.label4 = new System.Windows.Forms.Label();
        this.button2 = new System.Windows.Forms.Button();
        this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.button3 = new System.Windows.Forms.Button();
        this.label10 = new System.Windows.Forms.Label();
        this.label11 = new System.Windows.Forms.Label();
        this.radioButton1 = new System.Windows.Forms.RadioButton();
        this.radioButton2 = new System.Windows.Forms.RadioButton();
        this.radioButton3 = new System.Windows.Forms.RadioButton();
        this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.comboBox2 = new System.Windows.Forms.ComboBox();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
        this.label12 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
        this.label7 = new System.Windows.Forms.Label();
        this.label13 = new System.Windows.Forms.Label();
        this.label14 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.tableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 4;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanel1.Controls.Add(this.button6, 0, 7);
        this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
        this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
        this.tableLayoutPanel1.Controls.Add(this.button2, 2, 1);
        this.tableLayoutPanel1.Controls.Add(this.maskedTextBox1, 3, 1);
        this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
        this.tableLayoutPanel1.Controls.Add(this.button3, 2, 2);
        this.tableLayoutPanel1.Controls.Add(this.label10, 2, 4);
        this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
        this.tableLayoutPanel1.Controls.Add(this.radioButton1, 1, 5);
        this.tableLayoutPanel1.Controls.Add(this.radioButton2, 2, 5);
        this.tableLayoutPanel1.Controls.Add(this.radioButton3, 3, 5);
        this.tableLayoutPanel1.Controls.Add(this.maskedTextBox4, 1, 4);
        this.tableLayoutPanel1.Controls.Add(this.comboBox1, 3, 4);
        this.tableLayoutPanel1.Controls.Add(this.comboBox2, 3, 0);
        this.tableLayoutPanel1.Controls.Add(this.button4, 2, 7);
        this.tableLayoutPanel1.Controls.Add(this.button5, 3, 7);
        this.tableLayoutPanel1.Controls.Add(this.maskedTextBox5, 3, 6);
        this.tableLayoutPanel1.Controls.Add(this.label12, 2, 6);
        this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
        this.tableLayoutPanel1.Controls.Add(this.maskedTextBox3, 1, 6);
        this.tableLayoutPanel1.Controls.Add(this.maskedTextBox2, 3, 3);
        this.tableLayoutPanel1.Controls.Add(this.label7, 2, 3);
        this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
        this.tableLayoutPanel1.Controls.Add(this.label14, 1, 3);
        this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 8;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 337);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // button6
        // 
        this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button6.Location = new System.Drawing.Point(2, 296);
        this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button6.Name = "button6";
        this.button6.Size = new System.Drawing.Size(154, 39);
        this.button6.TabIndex = 31;
        this.button6.Text = "Factory Reset";
        this.button6.UseVisualStyleBackColor = true;
        this.button6.Click += new System.EventHandler(this.Button6_Click);
        // 
        // label3
        // 
        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold);
        this.label3.Location = new System.Drawing.Point(108, 42);
        this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(48, 13);
        this.label3.TabIndex = 4;
        this.label3.Text = "Step 2:";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(160, 0);
        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(137, 26);
        this.label2.TabIndex = 1;
        this.label2.Text = "Unplug USB connected to Bluetooth, Then Press Next";
        // 
        // label1
        // 
        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(108, 0);
        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(48, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Step 1:";
        // 
        // button1
        // 
        this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button1.Location = new System.Drawing.Point(318, 2);
        this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(154, 38);
        this.button1.TabIndex = 3;
        this.button1.Text = "Next";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.Button1_Click);
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(160, 42);
        this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(97, 13);
        this.label4.TabIndex = 6;
        this.label4.Text = "Connect to device.";
        // 
        // button2
        // 
        this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button2.Location = new System.Drawing.Point(318, 44);
        this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(154, 38);
        this.button2.TabIndex = 5;
        this.button2.Text = "Connect";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.Button2_Click);
        // 
        // maskedTextBox1
        // 
        this.maskedTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.maskedTextBox1.Location = new System.Drawing.Point(476, 62);
        this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox1.Name = "maskedTextBox1";
        this.maskedTextBox1.ReadOnly = true;
        this.maskedTextBox1.Size = new System.Drawing.Size(155, 20);
        this.maskedTextBox1.TabIndex = 7;
        // 
        // label5
        // 
        this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold);
        this.label5.Location = new System.Drawing.Point(108, 84);
        this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(48, 13);
        this.label5.TabIndex = 8;
        this.label5.Text = "Step 3:";
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(160, 84);
        this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(111, 13);
        this.label6.TabIndex = 9;
        this.label6.Text = "Read Current Settings";
        // 
        // button3
        // 
        this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button3.Location = new System.Drawing.Point(318, 86);
        this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(154, 38);
        this.button3.TabIndex = 10;
        this.button3.Text = "Read";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.Button3_Click);
        // 
        // label10
        // 
        this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(437, 168);
        this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(35, 13);
        this.label10.TabIndex = 16;
        this.label10.Text = "Baud:";
        // 
        // label11
        // 
        this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label11.AutoSize = true;
        this.label11.Location = new System.Drawing.Point(119, 210);
        this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(37, 13);
        this.label11.TabIndex = 17;
        this.label11.Text = "Mode:";
        // 
        // radioButton1
        // 
        this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.radioButton1.AutoSize = true;
        this.radioButton1.Location = new System.Drawing.Point(262, 212);
        this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.radioButton1.Name = "radioButton1";
        this.radioButton1.Size = new System.Drawing.Size(52, 17);
        this.radioButton1.TabIndex = 18;
        this.radioButton1.TabStop = true;
        this.radioButton1.Text = "Slave";
        this.radioButton1.UseVisualStyleBackColor = true;
        this.radioButton1.CheckedChanged += new System.EventHandler(this.EnableFlash);
        // 
        // radioButton2
        // 
        this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.radioButton2.AutoSize = true;
        this.radioButton2.Location = new System.Drawing.Point(415, 212);
        this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.radioButton2.Name = "radioButton2";
        this.radioButton2.Size = new System.Drawing.Size(57, 17);
        this.radioButton2.TabIndex = 19;
        this.radioButton2.TabStop = true;
        this.radioButton2.Text = "Master";
        this.radioButton2.UseVisualStyleBackColor = true;
        this.radioButton2.CheckedChanged += new System.EventHandler(this.EnableFlash);
        // 
        // radioButton3
        // 
        this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.radioButton3.AutoSize = true;
        this.radioButton3.Location = new System.Drawing.Point(552, 212);
        this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.radioButton3.Name = "radioButton3";
        this.radioButton3.Size = new System.Drawing.Size(79, 17);
        this.radioButton3.TabIndex = 20;
        this.radioButton3.TabStop = true;
        this.radioButton3.Text = "Slave Loop";
        this.radioButton3.UseVisualStyleBackColor = true;
        this.radioButton3.CheckedChanged += new System.EventHandler(this.EnableFlash);
        // 
        // maskedTextBox4
        // 
        this.maskedTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.maskedTextBox4.Location = new System.Drawing.Point(160, 170);
        this.maskedTextBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox4.Name = "maskedTextBox4";
        this.maskedTextBox4.Size = new System.Drawing.Size(154, 20);
        this.maskedTextBox4.TabIndex = 22;
        this.maskedTextBox4.TextChanged += new System.EventHandler(this.EnableFlash);
        // 
        // comboBox1
        // 
        this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Items.AddRange(new object[] {
        "1200",
        "2400",
        "4800",
        "9600",
        "19200",
        "38400",
        "57600",
        "115200"});
        this.comboBox1.Location = new System.Drawing.Point(476, 170);
        this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(155, 21);
        this.comboBox1.TabIndex = 24;
        this.comboBox1.TextChanged += new System.EventHandler(this.EnableFlash);
        // 
        // comboBox2
        // 
        this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.comboBox2.FormattingEnabled = true;
        this.comboBox2.Items.AddRange(new object[] {
        "HC05",
        "JDY-31"});
        this.comboBox2.Location = new System.Drawing.Point(476, 2);
        this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.comboBox2.Name = "comboBox2";
        this.comboBox2.Size = new System.Drawing.Size(155, 21);
        this.comboBox2.TabIndex = 32;
        this.comboBox2.Text = "HC05";
        // 
        // button4
        // 
        this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button4.Location = new System.Drawing.Point(318, 296);
        this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(154, 39);
        this.button4.TabIndex = 25;
        this.button4.Text = "Flash Changes";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(this.Button4_Click);
        // 
        // button5
        // 
        this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button5.Location = new System.Drawing.Point(476, 296);
        this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(155, 39);
        this.button5.TabIndex = 26;
        this.button5.Text = "Restart Bluetooth";
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new System.EventHandler(this.Button5_Click);
        // 
        // maskedTextBox5
        // 
        this.maskedTextBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.maskedTextBox5.Location = new System.Drawing.Point(476, 254);
        this.maskedTextBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox5.Name = "maskedTextBox5";
        this.maskedTextBox5.Size = new System.Drawing.Size(155, 20);
        this.maskedTextBox5.TabIndex = 23;
        this.maskedTextBox5.TextChanged += new System.EventHandler(this.EnableFlash);
        // 
        // label12
        // 
        this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label12.AutoSize = true;
        this.label12.Location = new System.Drawing.Point(416, 252);
        this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(56, 13);
        this.label12.TabIndex = 21;
        this.label12.Text = "Password:";
        // 
        // label8
        // 
        this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(108, 252);
        this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(48, 13);
        this.label8.TabIndex = 13;
        this.label8.Text = "Address:";
        // 
        // maskedTextBox3
        // 
        this.maskedTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.maskedTextBox3.Location = new System.Drawing.Point(160, 254);
        this.maskedTextBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox3.Name = "maskedTextBox3";
        this.maskedTextBox3.ReadOnly = true;
        this.maskedTextBox3.Size = new System.Drawing.Size(154, 20);
        this.maskedTextBox3.TabIndex = 14;
        // 
        // maskedTextBox2
        // 
        this.maskedTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.maskedTextBox2.Location = new System.Drawing.Point(476, 128);
        this.maskedTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.maskedTextBox2.Name = "maskedTextBox2";
        this.maskedTextBox2.ReadOnly = true;
        this.maskedTextBox2.Size = new System.Drawing.Size(155, 20);
        this.maskedTextBox2.TabIndex = 12;
        // 
        // label7
        // 
        this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(427, 126);
        this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(45, 13);
        this.label7.TabIndex = 11;
        this.label7.Text = "Version:";
        // 
        // label13
        // 
        this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label13.AutoSize = true;
        this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold);
        this.label13.Location = new System.Drawing.Point(108, 126);
        this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(48, 13);
        this.label13.TabIndex = 28;
        this.label13.Text = "Step 4:";
        // 
        // label14
        // 
        this.label14.AutoSize = true;
        this.label14.Location = new System.Drawing.Point(160, 126);
        this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(139, 26);
        this.label14.TabIndex = 29;
        this.label14.Text = "Make desired changes and Flash onto Bluetooth";
        // 
        // label9
        // 
        this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(118, 168);
        this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(38, 13);
        this.label9.TabIndex = 15;
        this.label9.Text = "Name:";
        // 
        // timer1
        // 
        this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
        // 
        // frmHC05
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(633, 337);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmHC05";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Bluetooth Programer";
        this.Load += new System.EventHandler(this.FrmDyno_Load);
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);

    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        this.DoThisAllTheTime();
    }

    public void WorkThreadFunction()
    {
        try
        {
            if (HC05FlashPort.IsOpen) HC05FlashPort.Close();

            HC05FlashPort.PortName = Convert.ToString(this.maskedTextBox1.Text);
            HC05FlashPort.BaudRate = (this.comboBox2.Text != "HC05") ? 0x2580 : 0x9600;
            HC05FlashPort.ReadTimeout = 600;
            HC05FlashPort.WriteTimeout = 300;
            HC05FlashPort.Open();
            int num = 0;
            while (HC05FlashPort.IsOpen && !ATMOODE)
            {
                num++;
                Thread.Sleep(100);
                if (num >= 7)
                {
                    HC05FlashPort.Close();
                    if (this.comboBox2.Text == "HC05")
                    {
                        this.failed();
                        MessageBox.Show(Form.ActiveForm, "Failed to enter AT mode, Make sure you held the button down when you powered up the HC05 and that the LED is blinking slowly.", "BMTune");
                    }
                    else if (HC05FlashPort.BaudRate == 0x2580)
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to connect to JDY-31 on Baud" + " 9600 trying 19200.");
                        HC05FlashPort.BaudRate = 0x4b00;
                        HC05FlashPort.Open();
                        num = 0;
                    }
                    else if (HC05FlashPort.BaudRate == 0x4b00)
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to connect to JDY-31 on Baud" + " 19200 trying 38400.");
                        HC05FlashPort.BaudRate = 0x9600;
                        HC05FlashPort.Open();
                        num = 0;
                    }
                    else if (HC05FlashPort.BaudRate == 0x9600)
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to connect to JDY-31 on Baud" + " 38400 trying 57600.");
                        HC05FlashPort.BaudRate = 0xe100;
                        HC05FlashPort.Open();
                        num = 0;
                    }
                    else if (HC05FlashPort.BaudRate == 0xe100)
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to connect to JDY-31 on Baud" + " 57600 trying 115200.");
                        HC05FlashPort.BaudRate = 0x1c200;
                        HC05FlashPort.Open();
                        num = 0;
                    }
                    else if (HC05FlashPort.BaudRate == 0x1c200)
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to connect to JDY-31 on Baud" + " 115200 trying 128000.");
                        HC05FlashPort.BaudRate = 0x1f400;
                        HC05FlashPort.Open();
                        num = 0;
                    }
                    else if (HC05FlashPort.BaudRate == 0x1f400)
                    {
                        MessageBox.Show(Form.ActiveForm, "Failed to connect to JDY-31 on Baud 128000 Check the wiring is correct and nothing have been connected over bluetooth.");
                        this.failed();
                    }
                }
                string str = "AT+VERSION\n\r";
                HC05FlashPort.Write(str);
                HC05FlashPort_ReadBack();
            }
        }
        catch
        {
            this.failed();
        }
        if (!ATMOODE)
        {
            this.failed();
        }
        else
        {
            this.button2.Text = "Connected";
            this.button3.Enabled = true;
            this.button5.Enabled = true;
            this.button6.Enabled = true;
        }
    }
}

