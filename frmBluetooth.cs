using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class frmBluetooth : Form
{
    //private bool JDY31 = false;


    public SerialPort serial;                                    //Create a new serial slot
    public List<string> AvailablePorts = new List<string>();     //Available COM Ports List
    public bool SerialConnected = false;                         //is serial connected ?
    public bool IsReceiving = false;
    public bool HasBTInfos = false;
    public bool CopiedInfos = false;

    public System.Windows.Forms.Timer SerialTimer = new System.Windows.Forms.Timer();
    private static string[] Read = new string[] { "", "", "", "", "", "" };

    public bool InfosReading = false;
    public int InfosState = 0;
    public int CurrentAutoProgramTime = 0;
    public int CurrentAutoProgramTime2 = 0;


    public frmBluetooth()
    {
        InitializeComponent();

        GetPortName();
        //comboBox1.SelectedIndex = 0;
        comboBox2.SelectedIndex = 2;
        //comboBox3.SelectedIndex = 0;

        SerialTimer.Interval = 100;
        SerialTimer.Tick += Loop;
        SerialTimer.Start();

        comboBox4.SelectedIndex = 0;

        /*foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }*/
    }

    public void Loop(object sender, EventArgs e)
    {
        //SerialTimer.Interval = 5000;
        //SerialConnect();
        //GetPortName();

        if (checkBoxAutoProgram.Checked)
        {
            CurrentAutoProgramTime2++;
            if (CurrentAutoProgramTime2 >= 10)
            {
                CurrentAutoProgramTime++; //1sec has passed
                CurrentAutoProgramTime2 = 0;
            }

            if (CurrentAutoProgramTime >= (int) numericUpDown1.Value)
            {
                //#######################
                //Read Adapter infos
                //MessageBox.Show(Form.ActiveForm, "Reading Bluetooth Adapter infos...", "BMTune");
                /*ClearInfos();
                InfosState = 0;
                InfosReading = true;*/
                //#######################
                //Set Adapter as Slave
                //MessageBox.Show(Form.ActiveForm, "Setting Bluetooth Adapter as Slave...", "BMTune");
                LogsBT("Autoprogramming adapter...");
                ClearInfos();
                SetSettings(true);
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(Properties.Resources.alert2);
                snd.Play();
                LogsBT("Autoprogramming adapter done!");
                //MessageBox.Show(Form.ActiveForm, "Bluetooth Adapter Set as Slave!", "BMTune");
                //#######################

                CurrentAutoProgramTime = 0;
                CurrentAutoProgramTime2 = 0;
            }
        }


        if (SerialConnected)
        {
            button2.Text = "Stop";
            this.Text = "Bluetooth Programmer - " + comboBox1.Text + " Connected";

            /*while (serial.BytesToRead > 0)
            {
                byte This = ReadByte();
                textBox3.AppendText("0x" + This.ToString("X2") + ",");
                textBox4.AppendText(Convert.ToChar(This).ToString() + ",");
                textBox7.AppendText(((int)This).ToString() + ",");
                IsReceiving = true;
            }

            if (IsReceiving)
            {
                textBox3.AppendText(Environment.NewLine);
                textBox4.AppendText(Environment.NewLine);
                textBox7.AppendText(Environment.NewLine);
                IsReceiving = false;
            }*/

            if (InfosReading)
            {
                if (InfosState == 0)
                {
                    SendStringCommand("AT+NAME");
                    serial_ReadBack("Get Name");
                    serial_ReadBack("Get Name #2");
                    InfosState++;
                }
                else if (InfosState == 1)
                {
                    SendStringCommand("AT+VERSION");
                    serial_ReadBack("Get Version");
                    serial_ReadBack("Get Version #2");
                    InfosState++;
                }
                else if (InfosState == 2)
                {
                    SendStringCommand("AT+ROLE");
                    serial_ReadBack("Get Role");
                    serial_ReadBack("Get Role #2");
                    InfosState++;
                }
                else if (InfosState == 3)
                {
                    SendStringCommand("AT+ADDR");
                    serial_ReadBack("Get Addr");
                    serial_ReadBack("Get Addr #2");
                    InfosState++;
                }
                else if (InfosState == 4)
                {
                    SendStringCommand("AT+PSWD");
                    serial_ReadBack("Get Pswd");
                    serial_ReadBack("Get Pswd #2");
                    InfosState++;
                }
                else if (InfosState == 5)
                {
                    SendStringCommand("AT+UART");
                    serial_ReadBack("Get Uart");
                    serial_ReadBack("Get Uart #2");
                    InfosState++;
                }
                else if (InfosState == 6)
                {
                    SendStringCommand("AT+BIND");
                    serial_ReadBack("Get Bind");
                    serial_ReadBack("Get Bind #2");
                    InfosState++;
                }
                else if (InfosState == 7)
                {
                    HasBTInfos = true;
                    InfosReading = false;
                    InfosState = 0;
                }
            }
        }
        else
        {
            button2.Text = "Start";
            this.Text = "Bluetooth Programmer";
        }
    }

    private bool CheckConnected()
    {
        bool IsFinallyConnected = false;
        try
        {
            if (serial != null)
            {
                if (serial.IsOpen)
                {
                    IsFinallyConnected = true;
                    //serial.Close();
                    //serial.Dispose();
                }
                else
                {
                    SerialConnected = false;
                    button2.Text = "Connect";
                }
            }
            else
            {
                SerialConnected = false;
                button2.Text = "Connect";
            }
        }
        catch 
        {
            SerialConnected = false;
            button2.Text = "Connect";
        }

        return IsFinallyConnected;
    }

    private void SendStringCommand(string ThisStr)
    {
        try
        {
            //This function serve to retreive bluetooth adapter infos
            string CommandEnd = "\n\r";
            if (comboBox4.SelectedIndex == 1) CommandEnd = "?\r";

            if (CheckConnected()) serial.WriteLine(ThisStr + CommandEnd);
        }
        catch { }
    }

    private void SendStringCommandParameter(string ThisStrCMD, string ThisStrParameters)
    {
        try
        {
            //This function serve to apply bluetooth adapter parameters
            string CommandEqual = "=";
            string CommandEnd = "\n\r";
            if (comboBox4.SelectedIndex == 1) CommandEnd = "\r";
            if (comboBox4.SelectedIndex == 2) CommandEqual = "";

            if (CheckConnected()) serial.WriteLine(ThisStrCMD + CommandEqual + ThisStrParameters + CommandEnd);
        }
        catch { }
    }


    private void SerialConnect()
    {
        //Close before Setting Values
        if (serial != null)
        {
            if (serial.IsOpen)
            {
                serial.Close();
                serial.Dispose();
            }
        }

        if (AvailablePorts.Count > 0)
        {
            try
            {
                if (serial != null)
                {
                    if (serial.IsOpen) serial.Close();
                    serial.Dispose();
                    serial = null;
                }

                serial = new SerialPort();
                serial.PortName = AvailablePorts[comboBox1.SelectedIndex];
                serial.ReadTimeout = 1500;
                serial.WriteTimeout = 800;

                serial.BaudRate = int.Parse(comboBox2.Text);
                serial.Open();
                SerialConnected = true;
                button2.Text = "Close";

                InfosState = 0;
                InfosReading = true;
                //ReadInfos();

                /*if (TryConnectAdapter())
                {
                    SerialConnected = true;
                    button2.Text = "Close";
                    ReadInfos();
                }*/
            }
            catch { }
        }
    }

    public bool TryConnectAdapter()
    {
        //try0 = user default settings
        //try1 = 38400 test
        //try2 = 9600 test

        int BTTest = 0;
        comboBox4.SelectedIndex = 0;

        while (BTTest < 3)
        {
            if (serial != null)
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                    serial.Dispose();
                }
            }

            serial = null;
            serial = new SerialPort();
            serial.PortName = AvailablePorts[comboBox1.SelectedIndex];
            //serial.ReadTimeout = 800;
            //serial.WriteTimeout = 400;
            serial.ReadTimeout = 250;
            serial.WriteTimeout = 200;

            if (BTTest == 0) serial.BaudRate = int.Parse(comboBox2.Text);
            if (BTTest == 1) serial.BaudRate = 38400;
            if (BTTest == 2) serial.BaudRate = 9600;
            serial.Open();

            serial.DiscardInBuffer();
            serial.DiscardOutBuffer();

            LogsBT("Trying on baudrate: " + serial.BaudRate);

            //+BAUD=6
            //OK

            string str = "";
            serial.WriteLine("AT\n\r");
            Thread.Sleep(serial.ReadTimeout);
            if (serial.BytesToRead > 0) str = serial.ReadLine();

            if (str == "")
            {
                serial.Write("AT?\n\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();

                if (str.Contains("OK")) comboBox4.SelectedIndex = 2;
            }
            if (str == "")
            {
                serial.Write("AT?\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();
            }
            if (str == "")
            {
                serial.Write("AT\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();
            }
            /*if (str == "")
            {
                serial.Write("AT+VERSION\n\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();
            }
            if (str == "")
            {
                serial.Write("AT+VERSION?\n\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();
            }
            if (str == "")
            {
                serial.Write("AT+VERSION?\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();
            }*/

            if (str.Contains("OK"))
            //if (str != "")
            {
                if (BTTest == 1)
                {
                    comboBox2.Text = "38400";
                }
                if (BTTest == 2)
                {
                    bool BaudChanged = false;
                    comboBox2.Text = "9600";
                    MessageBox.Show(Form.ActiveForm, "We detected that the default baudrate is set at 9600!\n\nBMTune will try to set the baudrate to 38400", "BMTune");

                    serial.WriteLine("AT+BAUD6\n\r");
                    Thread.Sleep(serial.ReadTimeout);
                    if (serial.BytesToRead > 0) str = serial.ReadLine();
                    if (str.Contains("+BAUD="))
                    {
                        Read[4] = str.Replace("+BAUD=", "");
                        if (Read[4] == "6") Reconnect38400();
                        BaudChanged = true;
                    }
                    //######################
                    if (!BaudChanged)
                    {
                        serial.WriteLine("AT+BAUD=6\n\r");
                        Thread.Sleep(serial.ReadTimeout);
                        if (serial.BytesToRead > 0) str = serial.ReadLine();
                        if (str.Contains("+BAUD="))
                        {
                            Read[4] = str.Replace("+BAUD=", "");
                            if (Read[4] == "6")
                            {
                                Reconnect38400();
                                BaudChanged = true;
                            }
                        }
                    }
                    //######################
                    if (!BaudChanged)
                    {
                        serial.WriteLine("AT+UART=38400,0,0\n\r");
                        Thread.Sleep(serial.ReadTimeout);
                        if (serial.BytesToRead > 0) str = serial.ReadLine();
                        if (str.Contains("+UART="))
                        {
                            Read[4] = str.Replace("+UART=", "");
                            if (Read[4].Contains("38400"))
                            {
                                Reconnect38400();
                                BaudChanged = true;
                            }
                        }
                        if (str.Contains("+UART:"))
                        {
                            Read[4] = str.Replace("+UART:", "");
                            if (Read[4].Contains("38400"))
                            {
                                Reconnect38400();
                                BaudChanged = true;
                            }
                        }
                    }
                    //######################
                    if (!BaudChanged)
                    {
                        serial.WriteLine("AT+UART=38400,0,0\r");
                        Thread.Sleep(serial.ReadTimeout);
                        if (serial.BytesToRead > 0) str = serial.ReadLine();
                        if (str.Contains("+UART="))
                        {
                            Read[4] = str.Replace("+UART=", "");
                            if (Read[4].Contains("38400"))
                            {
                                Reconnect38400();
                                BaudChanged = true;
                            }
                        }
                        if (str.Contains("+UART:"))
                        {
                            Read[4] = str.Replace("+UART:", "");
                            if (Read[4].Contains("38400"))
                            {
                                Reconnect38400();
                                BaudChanged = true;
                            }
                        }
                    }
                }

                //###########################################
                //###########################################
                //###########################################
                serial.WriteLine("AT+VERSION?\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();
                //Console.WriteLine("received " + str);
                if (str.Contains("+VERSION="))
                {
                    if (comboBox4.SelectedIndex == 0) comboBox4.SelectedIndex = 1;    //JDY-MCU
                    BTTest = 99;
                    return true;
                }

                serial.WriteLine("AT+VERSION\n\r");
                Thread.Sleep(serial.ReadTimeout);
                if (serial.BytesToRead > 0) str = serial.ReadLine();
                //Console.WriteLine("received " + str);
                if (str.Contains("+VERSION:"))
                {
                    comboBox4.SelectedIndex = 0;    //HC05
                    BTTest = 99;
                    return true;
                }
                /*if (str.Contains("+VERSION="))
                {
                    comboBox4.SelectedIndex = 2;    //ZS-040
                    BTTest = 99;
                    return true;
                }*/
            }

            BTTest++;
        }
        

        return false;
    }

    public void Reconnect38400()
    {
        if (serial.IsOpen)
        {
            serial.Close();
            serial.Dispose();
        }
        MessageBox.Show(Form.ActiveForm, "Baudrate has changed, restart the adapter if it's not in AT+MODE\n\nBMTune will reconnect at baudrate 38400", "BMTune");
        serial.BaudRate = 38400;
        serial.Open();
    }

    public void GetPortName()
    {
        AvailablePorts.Clear();
        comboBox1.Items.Clear();


        foreach (string s in SerialPort.GetPortNames())
        {
            AvailablePorts.Add(s);
            comboBox1.Items.Add(s);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        HasBTInfos = false;
        if (!SerialConnected)
        {
            ClearInfos();
            SerialConnect();
        }
        else
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                    serial.Dispose();
                }
            }
            catch { }
            SerialConnected = false;
            button2.Text = "Connect";
        }
    }

    public void Write(byte[] Bytes)
    {
        try
        {
            try
            {
                serial.Write(Bytes, 0, Bytes.Length);
            }
            catch { }
        }
        catch (TimeoutException)
        {
            try
            {
                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();
            }
            catch { }

        }
    }

    public byte ReadByte()
    {
        int Timeout = 0;

        try
        {
            try
            {
                //Timeout Loop if bytes is not availables
                int TimeoutTime = 600;
                while (serial.BytesToRead < 1 & Timeout < TimeoutTime)
                {
                    Thread.Sleep(1);
                    Timeout++;
                }

                //Check Timeout is out of time
                if (Timeout >= TimeoutTime)
                    return 255;
                else
                    return (byte)serial.ReadByte();
            }
            catch
            {
                return 255;
            }
        }
        catch (TimeoutException)
        {
            return 255;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        /*if (SerialConnected)
        {
            string Text = textBox1.Text;
            byte[] ThisMessage = new byte[Text.Length];
            if (comboBox3.SelectedIndex >= 1) ThisMessage = new byte[Text.Length + 1];
            if (comboBox3.SelectedIndex == 3) ThisMessage = new byte[Text.Length + 2];

            for (int i = 0; i < Text.Length; i++) ThisMessage[i] = Convert.ToByte(Text[i]);

            //Add final
            if (comboBox3.SelectedIndex == 1) ThisMessage[Text.Length] = Convert.ToByte('\n');
            if (comboBox3.SelectedIndex == 2) ThisMessage[Text.Length] = Convert.ToByte('\r');
            if (comboBox3.SelectedIndex == 3) { ThisMessage[Text.Length] = Convert.ToByte('\n'); ThisMessage[Text.Length + 1] = Convert.ToByte('\r'); }

            //Set Textbox Display
            for (int i = 0; i < ThisMessage.Length; i++)
            {
                textBox2.AppendText("0x" + ThisMessage[i].ToString("X2") + ",");
                textBox5.AppendText(Convert.ToChar(ThisMessage[i]).ToString() + ",");
                textBox6.AppendText(((int)ThisMessage[i]).ToString() + ",");
            }
            textBox2.AppendText(Environment.NewLine);
            textBox5.AppendText(Environment.NewLine);
            textBox6.AppendText(Environment.NewLine);

            //Write
            Write(ThisMessage);
        }*/
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        ClearInfos();
        SetSettings(true);
        CurrentAutoProgramTime = 0;
        CurrentAutoProgramTime2 = 0;
        MessageBox.Show(Form.ActiveForm, "Bluetooth Adapter Set as Slave!", "BMTune");
    }

    private void LogsBT(string logT)
    {
        textBox2.AppendText(logT + Environment.NewLine);
    }

    private void SetSettings(bool Slave)
    {
        if (Slave) txt_Name.Text = "BMLogger-ECU";
        else txt_Name.Text = "BMDatalogger";

        //string CommandEqual = "=";
        //string CommandEnd = "\n\r";
        //if (comboBox4.SelectedIndex == 1) CommandEnd = "\r";
        //if (comboBox4.SelectedIndex == 2) CommandEqual = "";

        SendStringCommandParameter("AT+NAME", txt_Name.Text);
        serial_ReadBack("Set Name");

        if (txt_Pass.Text != "1234")
        {

            if (comboBox4.SelectedIndex == 2 || comboBox4.SelectedIndex == 3) SendStringCommandParameter("AT+PIN", "1234");
            else SendStringCommandParameter("AT+PSWD", "1234");
            serial_ReadBack("Set Pswd");
        }

        if (txt_Uart.Text != "38400,0,0")
        {
            if (comboBox4.SelectedIndex == 2 || comboBox4.SelectedIndex == 3) SendStringCommandParameter("AT+BAUD", "6");
            else SendStringCommandParameter("AT+UART", "38400,0,0");
            serial_ReadBack("Set Uart");
        }

        if (Slave)
        {
            SendStringCommand("AT+ADDR");
            serial_ReadBack("Get Addr");
            serial_ReadBack("Get Addr #2");
        }
        else
        {
            if (comboBox4.SelectedIndex != 2 && comboBox4.SelectedIndex != 3)
            {
                if (comboBox4.SelectedIndex == 0) if (CheckConnected()) serial.WriteLine("AT+RMAAD\n\r");
                if (comboBox4.SelectedIndex == 1) if (CheckConnected()) serial.WriteLine("AT+RMAAD\r");
                serial_ReadBack("RMAAD");

                if (comboBox4.SelectedIndex == 0) if (CheckConnected()) serial.WriteLine("AT+CMODE=0\n\r");
                if (comboBox4.SelectedIndex == 1) if (CheckConnected()) serial.WriteLine("AT+CMODE=0\r");
                serial_ReadBack("Set CMode");
            }

            SendStringCommandParameter("AT+BIND", txt_BuffID.Text);
            serial_ReadBack("Set Bind");
        }

        if (Slave)
        {
            if (cmb_Role.SelectedIndex != 0)
            {
                SendStringCommandParameter("AT+ROLE", "0");
                serial_ReadBack("Set Role");
            }
        }
        else
        {
            if (cmb_Role.SelectedIndex != 1)
            {
                SendStringCommandParameter("AT+ROLE", "1");
                serial_ReadBack("Set Role");
            }
        }

        if (Slave)
        {
            InfosState = 0;
            InfosReading = true;
        }
        //ReadInfos();
    }

    public void serial_ReadBack(string CMDS)
    {
        if (CheckConnected())
        {
            if (serial.IsOpen && serial.ReadBufferSize > 0)
            {
                try
                {
                    string str = serial.ReadLine();
                    //Console.WriteLine("received " + str);
                    /*if (str.Contains("OK"))
                    {
                        ATMOODE = true;
                    }*/
                    if (str.Contains("+VERSION="))
                    {
                        //ATMOODE = true;
                        //JDY31 = true;
                        comboBox4.SelectedIndex = 1;
                        Read[0] = str.Replace("+VERSION=", "");
                        txt_Version.Text = Read[0].Replace("\r", "");
                    }
                    if (str.Contains("+ADDR="))
                    {
                        Read[2] = str.Replace("+ADDR=", "");
                        txt_ID.Text = Read[2].Replace("\r", "");
                        RedoAddr();
                    }
                    if (str.Contains("+PIN="))
                    {
                        Read[3] = str.Replace("+PIN=", "");
                        Read[3] = Read[3].Replace("\"", "");
                        txt_Pass.Text = Read[3].Replace("\r", "");
                    }
                    if (str.Contains("+PSWD="))
                    {
                        Read[3] = str.Replace("+PSWD=", "");
                        Read[3] = Read[3].Replace("\"", "");
                        txt_Pass.Text = Read[3].Replace("\r", "");
                    }
                    if (str.Contains("+BAUD="))
                    {
                        Read[4] = str.Replace("+BAUD=", "");
                        if (Read[4] == "1") txt_Uart.Text = "1200,0,0";
                        if (Read[4] == "2") txt_Uart.Text = "2400,0,0";
                        if (Read[4] == "3") txt_Uart.Text = "4800,0,0";
                        if (Read[4] == "4") txt_Uart.Text = "9600,0,0";
                        if (Read[4] == "5") txt_Uart.Text = "19200,0,0";
                        if (Read[4] == "6") txt_Uart.Text = "38400,0,0";
                        if (Read[4] == "7") txt_Uart.Text = "57600,0,0";
                        if (Read[4] == "8") txt_Uart.Text = "115200,0,0";
                        if (Read[4] == "9") txt_Uart.Text = "230400,0,0";
                        if (Read[4] == "A") txt_Uart.Text = "460800,0,0";
                        if (Read[4] == "B") txt_Uart.Text = "921600,0,0";
                        if (Read[4] == "C") txt_Uart.Text = "1382400,0,0";
                    }
                    if (str.Contains("+UART="))
                    {
                        Read[4] = str.Replace("+UART=", "");
                        txt_Uart.Text = Read[4].Replace("\r", "");
                    }
                    if (str.Contains("+BIND="))
                    {
                        Read[0] = str.Replace("+BIND=", "");
                        txt_Bind.Text = Read[0].Replace("\r", "");
                    }
                    if (str.Contains("+NAME="))
                    {
                        Read[5] = str.Replace("+NAME=", "");
                        txt_Name.Text = Read[5].Replace("\r", "");
                    }
                    if (str.Contains("+ROLE="))
                    {
                        Read[1] = str.Replace("+ROLE=", "");
                        try
                        {
                            cmb_Role.SelectedIndex = int.Parse(Read[1].Replace("\r", ""));
                        }
                        catch { }
                    }

                    //#########################
                    if (str.Contains("+NAME:"))
                    {
                        Read[5] = str.Replace("+NAME:", "");
                        txt_Name.Text = Read[5].Replace("\r", "");
                    }
                    if (str.Contains("+VERSION:"))
                    {
                        Read[0] = str.Replace("+VERSION:", "");
                        txt_Version.Text = Read[0].Replace("\r", "");
                    }
                    if (str.Contains("+ROLE:"))
                    {
                        Read[1] = str.Replace("+ROLE:", "");
                        //textBox10.Text = Read[1].Replace("\r", "");
                        try
                        {
                            cmb_Role.SelectedIndex = int.Parse(Read[1].Replace("\r", ""));
                        }
                        catch { }
                    }
                    if (str.Contains("+ADDR:"))
                    {
                        Read[2] = str.Replace("+ADDR:", "");
                        txt_ID.Text = Read[2].Replace("\r", "");
                        RedoAddr();
                    }
                    if (str.Contains("+PIN:"))
                    {
                        Read[3] = str.Replace("+PIN:", "");
                        Read[3] = Read[3].Replace("\"", "");
                        txt_Pass.Text = Read[3].Replace("\r", "");
                    }
                    if (str.Contains("+PSWD:"))
                    {
                        Read[3] = str.Replace("+PSWD:", "");
                        txt_Pass.Text = Read[3].Replace("\r", "");
                    }
                    if (str.Contains("+UART:"))
                    {
                        Read[4] = str.Replace("+UART:", "");
                        txt_Uart.Text = Read[4].Replace("\r", "");
                    }
                    if (str.Contains("+BIND:"))
                    {
                        Read[0] = str.Replace("+BIND:", "");
                        txt_Bind.Text = Read[0].Replace("\r", "");
                    }


                    if (str.Contains("ERROR:"))
                    {
                        //Failed++;
                        LogsBT(CMDS + " " + str);
                    }
                }
                catch
                {
                    LogsBT("unable to read for command: " + CMDS);
                    //Failed++;
                }
            }
            else
            {
                LogsBT("unable to read for command: " + CMDS);
            }
        }
        else
        {
            LogsBT("unable to read for command: " + CMDS);
        }
    }

    private void RedoAddr()
    {
        string addrbuf = txt_ID.Text;
        if (addrbuf.Contains(":"))
        {
            addrbuf = addrbuf.Replace(":", ",");
            string[] splite = addrbuf.Split(',');
            if (splite[0].Length != 4)
            {
                int Adddd = 4 - splite[0].Length;

                while (Adddd > 0)
                {
                    splite[0] = "0" + splite[0];
                    Adddd--;
                }
            }
            if (splite[1].Length != 2)
            {
                int Adddd = 2 - splite[1].Length;

                while (Adddd > 0)
                {
                    splite[1] = "0" + splite[1];
                    Adddd--;
                }
            }

            if (splite[2].Length != 6)
            {
                int Adddd = 6 - splite[2].Length;

                while (Adddd > 0)
                {
                    splite[2] = "0" + splite[2];
                    Adddd--;
                }
            }

            string reammdf = "";
            for (int i = 0; i < splite[0].Length; i++) reammdf += splite[0][i];
            reammdf += ",";
            for (int i = 0; i < splite[1].Length; i++) reammdf += splite[1][i];
            reammdf += ",";
            for (int i = 0; i < splite[2].Length; i++) reammdf += splite[2][i];

            txt_ID.Text = reammdf;
        }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
        if (!CopiedInfos || (CopiedInfos && txt_BuffRole.Text.Contains("Master")) || !HasBTInfos) MessageBox.Show(Form.ActiveForm, "You need to connect a slave adapter first that you want the master\nto pair to and set the slave adapter info in 'Last Adapter Infos'", "BMTune");

        if (!SerialConnected) MessageBox.Show(Form.ActiveForm, "You need to connect a device first!", "BMTune");
        else
        {
            if (CopiedInfos)
            {
                if (txt_BuffID.Text == "") MessageBox.Show(Form.ActiveForm, "The Slave ID in 'Last Adapter Infos' aren't recogniable", "BMTune");

                if (HasBTInfos && txt_BuffID.Text != "")
                {
                    MessageBox.Show(Form.ActiveForm, "This will Bind/Pair the Master with the the ID of the 'Last Adapter Infos'", "BMTune");
                    ClearInfos();
                    SetSettings(false);
                }
            }
        }
        MessageBox.Show(Form.ActiveForm, "Bluetooth Adapter Set as Master!", "BMTune");
    }

    private void Button6_Click(object sender, EventArgs e)
    {
        ClearInfos();
        InfosState = 0;
        InfosReading = true;
        //ReadInfos();
    }

    /*private void ReadInfos()
    {
        if (comboBox4.SelectedIndex == 1)
        {
            serial.WriteLine("AT+NAME?\r");
            serial_ReadBack("Get Name");
            serial_ReadBack("Get Name #2");

            serial.WriteLine("AT+VERSION?\r");
            serial_ReadBack("Get Version");
            serial_ReadBack("Get Version #2");

            serial.WriteLine("AT+ROLE?\r");
            serial_ReadBack("Get Role");
            serial_ReadBack("Get Role #2");

            serial.WriteLine("AT+ADDR?\r");
            serial_ReadBack("Get Addr");
            serial_ReadBack("Get Addr #2");

            serial.WriteLine("AT+PSWD?\r");
            serial_ReadBack("Get Pswd");
            serial_ReadBack("Get Pswd #2");

            serial.WriteLine("AT+UART?\r");
            serial_ReadBack("Get Uart");
            serial_ReadBack("Get Uart #2");

            serial.WriteLine("AT+BIND?\r");
            serial_ReadBack("Get Bind");
            serial_ReadBack("Get Bind #2");
        }
        else
        {
            serial.WriteLine("AT+NAME\n\r");
            //serial.WriteLine("AT+NAME\r");
            //Thread.Sleep(500);
            serial_ReadBack("Get Name");
            serial_ReadBack("Get Name #2");

            serial.WriteLine("AT+VERSION\n\r");
            //serial.WriteLine("AT+VERSION\r");
            serial_ReadBack("Get Version");
            serial_ReadBack("Get Version #2");

            serial.WriteLine("AT+PSWD\n\r");
            //serial.WriteLine("AT+PSWD\r");
            serial_ReadBack("Get Pswd");
            serial_ReadBack("Get Pswd #2");

            serial.WriteLine("AT+UART\n\r");
            //serial.WriteLine("AT+UART\r");
            serial_ReadBack("Get Uart");
            serial_ReadBack("Get Uart #2");

            serial.WriteLine("AT+ADDR\n\r");
            //serial.WriteLine("AT+ADDR\r");
            serial_ReadBack("Get Addr");
            serial_ReadBack("Get Addr #2");

            serial.WriteLine("AT+BIND\n\r");
            //serial.WriteLine("AT+BIND\r");
            serial_ReadBack("Get Bind");
            serial_ReadBack("Get Bind #2");

            serial.WriteLine("AT+ROLE\n\r");
            //serial.WriteLine("AT+ROLE\r");
            serial_ReadBack("Get Role");
            serial_ReadBack("Get Role #2");
        }

        HasBTInfos = true;
    }*/

    private void ComboBox1_DropDown(object sender, EventArgs e)
    {
        GetPortName();
    }

    private void Button7_Click(object sender, EventArgs e)
    {
        CopyBuffer();
    }

    private void CopyBuffer()
    {
        if (HasBTInfos)
        {
            txt_BuffName.Text = txt_Name.Text;
            txt_BuffUart.Text = txt_Uart.Text;
            txt_BuffVersion.Text = txt_Version.Text;
            txt_BuffBind.Text = txt_Bind.Text;
            txt_BuffID.Text = txt_ID.Text;
            txt_BuffPass.Text = txt_Pass.Text;
            txt_BuffRole.Text = cmb_Role.Text;
            CopiedInfos = true;
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        if (comboBox4.SelectedIndex == 1)   //JDY31
        {
            serial.WriteLine("AT+ORGL\r");
            serial_ReadBack("Set ORGL");
            MessageBox.Show(Form.ActiveForm, "Restored unit to default settings.", "BMTune");
        }
        else if (comboBox4.SelectedIndex == 2 && comboBox4.SelectedIndex == 3)   //HC06 ZS-040
        {
            serial.WriteLine("AT+DEFAULT\n\r");
            serial_ReadBack("Set ORGL");
            MessageBox.Show(Form.ActiveForm, "Restored unit to default settings.", "BMTune");
        }
        else
        {
            //serial.WriteLine("AT+DEFAULT\n\r");
            //serial.WriteLine("AT+RESET\n\r");
            serial.WriteLine("AT+ORGL\n\r");
            serial_ReadBack("Set ORGL");
            MessageBox.Show(Form.ActiveForm, "Restored unit to default settings.", "BMTune");
        }
    }

    private void button8_Click(object sender, EventArgs e)
    {
        string CommandEqual = "=";
        string CommandEnd = "\n\r";
        if (comboBox4.SelectedIndex == 1) CommandEnd = "\r";
        if (comboBox4.SelectedIndex == 2) CommandEqual = "";

        serial.WriteLine("AT+NAME" + CommandEqual + txt_Name.Text + CommandEnd);
        serial_ReadBack("Set Name");

        MessageBox.Show(Form.ActiveForm, "Bluetooth adapter name changed", "BMTune");
    }

    private void button10_Click(object sender, EventArgs e)
    {
        string CommandEqual = "=";
        string CommandEnd = "\n\r";
        if (comboBox4.SelectedIndex == 1) CommandEnd = "\r";
        if (comboBox4.SelectedIndex == 2) CommandEqual = "";

        if (comboBox4.SelectedIndex == 2 || comboBox4.SelectedIndex == 3) serial.WriteLine("AT+BAUD" + CommandEqual + "6" + CommandEnd);
        else serial.WriteLine("AT+UART" + CommandEqual + txt_Uart.Text + CommandEnd);
        serial_ReadBack("Set Uart");

        MessageBox.Show(Form.ActiveForm, "Bluetooth adapter uart changed", "BMTune");
    }

    private void button11_Click(object sender, EventArgs e)
    {
        string CommandEqual = "=";
        string CommandEnd = "\n\r";
        if (comboBox4.SelectedIndex == 1) CommandEnd = "\r";
        if (comboBox4.SelectedIndex == 2) CommandEqual = "";

        serial.WriteLine("AT+ROLE" + CommandEqual + cmb_Role.SelectedIndex + CommandEnd);
        serial_ReadBack("Set Role");

        MessageBox.Show(Form.ActiveForm, "Bluetooth adapter role changed", "BMTune");
    }

    private void button13_Click(object sender, EventArgs e)
    {
        string CommandEqual = "=";
        string CommandEnd = "\n\r";
        if (comboBox4.SelectedIndex == 1) CommandEnd = "\r";
        if (comboBox4.SelectedIndex == 2) CommandEqual = "";

        serial.WriteLine("AT+BIND" + CommandEqual + txt_BuffID.Text + CommandEnd);
        serial_ReadBack("Set Bind");

        MessageBox.Show(Form.ActiveForm, "Bluetooth adapter bind changed", "BMTune");
    }

    private void button14_Click(object sender, EventArgs e)
    {
        string CommandEqual = "=";
        string CommandEnd = "\n\r";
        if (comboBox4.SelectedIndex == 1) CommandEnd = "\r";
        if (comboBox4.SelectedIndex == 2) CommandEqual = "";

        if (comboBox4.SelectedIndex == 2 || comboBox4.SelectedIndex == 3) serial.WriteLine("AT+PIN" + CommandEqual + txt_Pass.Text + CommandEnd);
        else serial.WriteLine("AT+PSWD" + CommandEqual + txt_Pass.Text + CommandEnd);
        serial_ReadBack("Set Pswd");

        MessageBox.Show(Form.ActiveForm, "Bluetooth adapter pswd changed", "BMTune");
    }

    private void button9_Click(object sender, EventArgs e)
    {
        textBox2.Text = "";
    }

    void ClearInfos()
    {
        txt_Name.Text = "";
        txt_Bind.Text = "";
        txt_ID.Text = "";
        txt_Pass.Text = "";
        txt_Uart.Text = "";
        txt_Version.Text = "";
        cmb_Role.Text = "";
    }
}
