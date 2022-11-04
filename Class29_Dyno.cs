using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

internal class Class29_Dyno
{
    public SerialPort ComPort = new SerialPort();
    public SerialPort ComPortBC = new SerialPort();
    public readonly byte[] DynoPoll = new byte[] { 0x45 };
    public readonly byte[] DynoRPMUP = new byte[] { 70 };
    public readonly byte[] DynoRPMDOWN = new byte[] { 0x47 };
    public readonly byte[] DynoBRAKE = new byte[] { 0x48 };
    public long HP = 0L;
    public long NM = 0L;
    public long AUX1 = 0L;
    public long AUX2 = 0L;
    public long AUX3 = 0L;
    public long THC = 0L;
    public long WS = 0L;
    public long RPM = 0L;
    public string[] _Data;
    public string COMPORTDyno;

    public static string[] Data;

    Class18 class18_0;

    public Class29_Dyno(ref Class18 class18_1)
    {
        class18_0 = class18_1;
        COMPORTDyno = class18_0.class10_settings_0.Dyno_COMPort;

        ComPort.DataReceived += new SerialDataReceivedEventHandler(DLCOM_DataReceived);
    }

    public void Connect()
    {
        if (this.class18_0.class10_settings_0.Dyno_COMPort == null)
        {
            MessageBox.Show(Form.ActiveForm, "You Need to select a comport for the Dyno in Dyno settings!", "BMTune");
        }
        else
        {
            ComPort.ReadBufferSize = 0x34;
            ComPort.BaudRate = 0x9600;
            ComPort.PortName = Convert.ToString(this.class18_0.class10_settings_0.Dyno_COMPort);
            this.WorkThreadFunction();
        }
    }

    public void Disconnect()
    {
        try
        {
            ComPort.Close();
        }
        catch
        {
        }
    }

    public void DLCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (ComPort.IsOpen)
        {
            try
            {
                ProcessPacket(ComPort.ReadLine());
                ComPort.Write(DynoPoll, 0, DynoPoll.Length);
            }
            catch
            {
                HP = 0L;
                NM = 0L;
                AUX1 = 0L;
                AUX2 = 0L;
                AUX3 = 0L;
                THC = 0L;
                WS = 0L;
            }
        }
    }

    public void ProcessPacket(string packet)
    {
        char[] separator = new char[] { ':' };
        Data = packet.Replace("PUT-", "").Split(separator);
        if (Data.Length == 8)
        {
            try
            {
                HP = (long)Math.Round((double)float.Parse(Data[0]), 4);
            }
            catch
            {
                HP = 0L;
            }
            try
            {
                NM = (long)float.Parse(Data[1]);
            }
            catch
            {
                NM = 0L;
            }
            try
            {
                AUX1 = (long)float.Parse(Data[2]);
            }
            catch
            {
                AUX1 = 0L;
            }
            try
            {
                AUX2 = (long)float.Parse(Data[3]);
            }
            catch
            {
                AUX2 = 0L;
            }
            try
            {
                AUX3 = (long)float.Parse(Data[4]);
            }
            catch
            {
                AUX3 = 0L;
            }
            try
            {
                THC = (long)float.Parse(Data[5]);
            }
            catch
            {
                THC = 0L;
            }
            try
            {
                WS = (long)(((float.Parse(Data[6]) / 100f) / ((float)RPM)) * 100f);
            }
            catch
            {
                WS = 0L;
            }
            try
            {
                frmDynoControl.BrakeA = Data[7];
            }
            catch
            {
                frmDynoControl.BrakeA = "0000";
            }
        }
    }

    /*public string SL(string lan)
    {
        string str;
        return (!Class22_startup.sl.TryGetValue(lan, out str) ? "No Lang File" : Regex.Replace(str, "<NL>", Environment.NewLine));
    }*/

    public void WorkThreadFunction()
    {
        try
        {
            ComPort.BaudRate = 0x9600;
            ComPort.Open();
            while (ComPort.IsOpen)
            {
                ComPort.Write(DynoPoll, 0, DynoPoll.Length);
                Thread.Sleep(100);
            }
        }
        catch
        {
            frmDynoSetup.Dyno_Connected = false;
            this.class18_0.class17_0.frmMain_0.connectToolStripMenuItem.ForeColor = Color.FromArgb(0xd7, 120, 120);
            this.class18_0.class17_0.frmMain_0.connectToolStripMenuItem.Text = "Connect";
            this.class18_0.class17_0.frmMain_0.dynoToolStripMenuItem.ForeColor = Color.FromArgb(0xd7, 120, 120);
            this.class18_0.class17_0.frmMain_0.controlToolStripMenuItem.Enabled = false;
            MessageBox.Show(Form.ActiveForm, "Failed to connect to dyno", "BMTune");
            this.class18_0.class17_0.frmMain_0.statusDyno.Text = "Dyno:Disconnected";
            this.class18_0.class17_0.frmMain_0.statusDyno.ForeColor = Color.FromArgb(0xd7, 120, 120);
        }
    }
}

