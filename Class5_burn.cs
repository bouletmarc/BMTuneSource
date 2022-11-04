//using PropertiesRes;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

internal class Class5_burn
{
    private BackgroundWorker backgroundWorker_0;
    private BackgroundWorker backgroundWorker_1;
    private BackgroundWorker backgroundWorker_2;
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private bool bool_SST256;
    private byte[] byte_0;
    private byte[] byte_1;
    private byte[] byte_2;
    private byte byte_3;
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    private Class18 class18_0;
    private int int_0;
    private long long_0;
    private string BMBurnerTitle = "";
    private string BMBurnerDesc = "";
    private SerialPort serialPort_0;
    public frmBurner frmBurner_0;

    private int FirmwareNumber = 0;
    private bool IsBMBurner = false;

    public byte[] byte_ALL = new byte[] { };
    private bool SecondPass = false;

    public event Delegate8 delegate8_0;

    public event Delegate9 delegate9_0;

    internal Class5_burn(ref Class18 rm, ref Class10_settings cfg, ref Class17 dt, ref FrmMain frmM)
    {
        this.class10_settings_0 = cfg;
        this.class17_0 = dt;
        this.class18_0 = rm;
    }

    private byte GetByteAt(long Location)
    {
        byte RByte= 0;
        if (byte_ALL.Length >= Location + 1) RByte = byte_ALL[Location];
        return RByte;
    }

    private string GetConnectedTitleString()
    {
        if (BMBurnerTitle != "")
        {
            if (this.bool_2) return " Connected";
            return " Disconnected";
        }
        return "Connecting Burner...";
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        this.bool_2 = false;
        this.int_0 = 1;
        BMBurnerDesc = "Detecting burner";
        UpdateTileText();
        try
        {
            if (this.class10_settings_0.burnCommCache != 0)
            {
                this.int_0 = this.class10_settings_0.burnCommCache;
                this.bool_2 = false;
                if (this.serialPort_0 != null)
                {
                    if (this.serialPort_0.IsOpen) this.serialPort_0.Close();
                    this.serialPort_0.Dispose();
                    this.serialPort_0 = null;
                }
                if (this.method_5())
                {
                    this.bool_2 = true;
                    return;
                }
            }
        }
        catch
        {
        }
        this.int_0 = 1;
    Label_00A0:
        try
        {
            if (this.int_0 == 41)
            {
                LogThis("Burner NOT found!");
                this.bool_2 = false;
                if (this.serialPort_0 != null)
                {
                    if (this.serialPort_0.IsOpen) this.serialPort_0.Close();
                    this.serialPort_0.Dispose();
                    this.serialPort_0 = null;
                }

                BMBurnerDesc = "Device not found!";
                UpdateTileText();
            }
            else if (this.method_5())
            {
                LogThis("Burner found on COM" + this.int_0);
                this.class10_settings_0.burnCommCache = this.int_0;
                this.bool_2 = true;

                BMBurnerDesc = "Device found!";
                UpdateTileText();
            }
            else
            {
                this.int_0++;
                goto Label_00A0;
            }
        }
        catch (Exception)
        {
            if (this.serialPort_0 != null)
            {
                this.serialPort_0.Dispose();
                this.serialPort_0 = null;
            }
            this.int_0++;
            goto Label_00A0;
        }
    }

    //Burn Write Chip
    private void backgroundWorker_1_DoWork(object sender, DoWorkEventArgs e)
    {
        ChangeAccTime();

        DialogResult result = DialogResult.OK;
        if (IsBurnerV2())
        {
            if (this.frmBurner_0.ChipSelectBox.Text == "W27C512 (Fake Winbond SST)" || this.frmBurner_0.ChipSelectBox.Text == "W27E512") result = MessageBox.Show(Form.ActiveForm, "Set the BMBurner on 14v then press OK", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (this.frmBurner_0.ChipSelectBox.Text == "27SF512") result = MessageBox.Show(Form.ActiveForm, "Set the BMBurner on 12v then press OK", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            if (this.frmBurner_0.ChipSelectBox.Text == "W27C512 (Fake Winbond SST)" || this.frmBurner_0.ChipSelectBox.Text == "W27E512")
            {
                if (IsBMBurner) result = MessageBox.Show(Form.ActiveForm, "This version of BMBurner CANNOT change voltage to 14v" + Environment.NewLine + Environment.NewLine + "It's possible the chip won't erase correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else result = MessageBox.Show(Form.ActiveForm, "The Burn2 CANNOT change voltage to 14v" + Environment.NewLine + Environment.NewLine + "It's possible the chip won't erase correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        if (result != DialogResult.OK) return;

        byte num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        this.byte_1 = new byte[0x106];
        if (this.backgroundWorker_1.CancellationPending)
        {
            goto Label_02F7;
        }
        long num = 0L;
        num3 = 0;

        //chip index
        if (bool_SST256)
        {
            num4 = 0x36;
        }
        else
        {
            if (!this.bool_4)
            {
                num4 = 0x35;
            }
            else
            {
                num4 = 50;
            }
        }

    Label_0043:
        this.serialPort_0.ReadTimeout = 0x7d0;
        this.serialPort_0.WriteTimeout = 110;
        if (num5 == 3)
        {
            LogThis("Failed to erase SST after " + this.class10_settings_0.int_21.ToString() + " tries");
            MessageBox.Show(Form.ActiveForm, "Failed to erase SST");
            return;
        }
        if (num4 == 53)
        {
            LogThis("Erasing chip");
            BMBurnerDesc = "Erasing chip";
            UpdateTileText();
            this.byte_1[0] = (byte) num4;
            this.byte_1[1] = 0x45;
            this.byte_1[2] = this.method_10(this.byte_1, 0, 2);
            try
            {
                this.method_7(this.byte_1, 0, 3);
                num2 = this.method_9();
            }
            catch (Exception)
            {
                num5++;
                goto Label_0043;
            }
            if (num2 != 0x4f)
            {
                num5++;
                goto Label_0043;
            }
        }
        this.serialPort_0.ReadTimeout = 1000;
        this.serialPort_0.WriteTimeout = 500;

        if (IsBurnerV2() && this.frmBurner_0.ChipSelectBox.Text == "W27C512 (Fake Winbond SST)" || this.frmBurner_0.ChipSelectBox.Text == "W27E512") result = MessageBox.Show(Form.ActiveForm, "Set the BMBurner on 12v then press OK", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        Label_010B:
        if ((num3 - 1) == this.class10_settings_0.int_21)
        {
            LogThis("Uploading failed after " + this.class10_settings_0.int_21.ToString() + " tries");
            MessageBox.Show(Form.ActiveForm, "Uploading failed after " + this.class10_settings_0.int_21.ToString() + " on Burner", "Burner Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
            if (num < 0x8000L)
            {
                //LogThis("Writing chip at 0x" + num.ToString("X4"));
                if (SecondPass) 
                {
                    BMBurnerDesc = "Writing 2nd 2Timer chip";
                    UpdateTileText();
                }
                else
                {
                    BMBurnerDesc = "Writing chip";
                    UpdateTileText();
                }
                this.backgroundWorker_1.ReportProgress((int) ((((double) num) / 32768.0) * 100.0));
                try
                {
                    this.byte_1[0] = (byte) num4;
                    this.byte_1[1] = 0x57;
                    this.byte_1[2] = 0;
                    if (!SecondPass)
                    {
                        this.byte_1[3] = this.class18_0.method_148(this.long_0 + num);
                        this.byte_1[4] = this.class18_0.method_147(this.long_0 + num);
                    }
                    else
                    {
                        this.byte_1[3] = this.class18_0.method_148(this.long_0 + num + 0x8000L);
                        this.byte_1[4] = this.class18_0.method_147(this.long_0 + num + 0x8000L);
                    }
                    for (int i = 0; i < 0x100; i++)
                    {
                        if (!SecondPass) this.byte_1[5 + i] = GetByteAt(num + i);
                        else this.byte_1[5 + i] = GetByteAt(num + i + 32768);
                        //this.byte_1[5 + i] = this.class18_0.method_150(num + i);
                    }
                    this.byte_1[0x105] = this.method_10(this.byte_1, 0, 0x105);
                    this.method_7(this.byte_1, 0, 0x106);
                    if (this.method_9() == 0x4f)
                    {
                        num += 0xffL;
                        num += 1L;

                        if (frmBurner_0.Is2Timer && num >= 0x8000L)
                        {
                            if (!SecondPass)
                            {
                                num = 0L;
                                SecondPass = true;
                                LogThis("Writing 2nd 2Timer chip");
                            }
                            else
                            {
                                SecondPass = false;
                            }
                        }
                    }
                    else
                    {
                        num3++;
                    }
                    goto Label_010B;
                }
                catch
                {
                    num3++;
                    goto Label_010B;
                }
            }
        }
        Label_02F7:
        if (this.backgroundWorker_1 != null) this.backgroundWorker_1.ReportProgress(100);
        num = 0L;
    }

    private void backgroundWorker_1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.delegate8_0 != null)
        {
            this.delegate8_0(e.ProgressPercentage);
        }
    }

    private void backgroundWorker_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.backgroundWorker_1.Dispose();
        this.backgroundWorker_1 = null;
        this.byte_1 = null;
        this.byte_2 = null;
        this.byte_0 = null;
        this.method_18(frmBurner_0, false);
        this.serialPort_0.Close();
        this.serialPort_0.Dispose();
        this.serialPort_0 = null;
        this.bool_2 = false;
        this.bool_0 = false;
        UpdateTileText();
        GC.Collect();
    }

    private void backgroundWorker_2_DoWork(object sender, DoWorkEventArgs e)
    {
        int num2 = 0;
        this.byte_1 = new byte[7];
        this.byte_2 = new byte[260];
        int num3 = 0;

        if (bool_SST256)
        {
            num3 = 0x36;
        }
        else
        {
            if (!this.bool_4)
            {
                num3 = 0x35;
            }
            else
            {
                num3 = 50;
            }
        }

        this.serialPort_0.ReadTimeout = 1000;
        this.serialPort_0.WriteTimeout = 500;
        if (this.backgroundWorker_2.CancellationPending)
        {
            goto Label_0238;
        }
        long num = 0L;
        num2 = 0;
    Label_005A:
        if ((num2 - 1) == 3)
        {
            this.bool_3 = true;
            LogThis("Burner failed to read");
            MessageBox.Show(Form.ActiveForm, "Burner failed to read", "Burner Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else if (num < 0x8000L)
        {
            //LogThis("Reading chip at 0x" + num.ToString("X4"));
            if (SecondPass)
            {
                BMBurnerDesc = "Verifying 2nd 2Timer chip";
                UpdateTileText();
            }

            this.backgroundWorker_2.ReportProgress((int) ((((double) num) / 32768.0) * 100.0));
            this.method_12();
            this.byte_1[0] = (byte) num3;
            this.byte_1[1] = 0x52;
            this.byte_1[2] = 0;
            if (!SecondPass)
            {
                this.byte_1[3] = this.class18_0.method_148(this.long_0 + num);
                this.byte_1[4] = this.class18_0.method_147(this.long_0 + num);
            }
            else
            {
                this.byte_1[3] = this.class18_0.method_148(this.long_0 + num + 0x8000L);
                this.byte_1[4] = this.class18_0.method_147(this.long_0 + num + 0x8000L);
            }
            this.byte_1[5] = this.method_10(this.byte_1, 0, 5);
            try
            {
                this.method_7(this.byte_1, 0, 6);
                int Tries = 0;
                while (this.serialPort_0.BytesToRead < 0x100 && Tries < 5)
                {
                    Application.DoEvents();
                    int Tries_Fast = 0;
                    while (this.serialPort_0.BytesToRead < 0x100 && Tries_Fast < 50)
                    {
                        Thread.Sleep(1);
                        Tries_Fast++;
                    }
                    if (this.serialPort_0.BytesToRead < 0x100)
                    {
                        if (Tries >= 3) this.method_7(this.byte_1, 0, 6);
                        Thread.Sleep(50);
                        Tries++;
                    }
                }
                this.serialPort_0.Read(this.byte_2, 0, 0x100);
                if (num == 0L)
                {
                    for (int i = 0; i < 0x100; i++)
                    {
                    }
                }
                this.method_14(this.byte_2, 0x100);
                byte num5 = this.method_9();
                if (this.method_11() != num5)
                {
                    this.serialPort_0.DiscardInBuffer();
                    this.bool_3 = true;
                    num2++;
                }
                else
                {
                    if (!SecondPass) this.method_15(this.byte_2, (int) num, 0x100);
                    else this.method_15(this.byte_2, (int)num + 32768, 0x100);
                    num += 0xffL;
                    num += 1L;
                    this.bool_3 = false;
                    if (frmBurner_0.Is2Timer && num >= 0x8000L)
                    {
                        if (!SecondPass)
                        {
                            num = 0L;
                            SecondPass = true;
                            LogThis("Reading 2nd 2Timer chip");
                        }
                        else
                        {
                            SecondPass = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (this.serialPort_0 != null)
                    if (this.serialPort_0.IsOpen) this.serialPort_0.DiscardInBuffer();
                num2++;
            }
            goto Label_005A;
        }
    Label_0238:
        this.backgroundWorker_2.ReportProgress(100);
        this.byte_1 = null;
        this.byte_2 = null;
        num2 = 0;
        num = 0L;
    }

    private void backgroundWorker_2_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.delegate8_0 != null)
        {
            this.delegate8_0(e.ProgressPercentage);
        }
    }

    private void backgroundWorker_2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (!this.bool_1)
        {
            if (!this.bool_3)
            {
                this.class18_0.method_67(this.byte_0, false);
            }
            this.backgroundWorker_2.Dispose();
            this.backgroundWorker_2 = null;
            this.bool_2 = false;
            this.bool_0 = false;
            //this.byte_0 = null;
            this.serialPort_0.Close();
            this.serialPort_0.Dispose();
            this.serialPort_0 = null;

            if (!this.bool_3)
            {
                if (!this.class18_0.method_30_HasFileLoadedInBMTune()) FailRead();
                else
                {
                    LogThis("Chip succesfully read");
                    BMBurnerDesc = "Succesfully read";
                    UpdateTileText();
                }
            }
            else
            {
                FailRead();
            }
        }
        this.byte_1 = null;
        this.byte_2 = null;
        GC.Collect();
    }

    private void FailRead()
    {
        LogThis("Chip failed to read");
        BMBurnerDesc = "Failed to read";
        UpdateTileText();

        if (MessageBox.Show(Form.ActiveForm, "Do you want to save a copy of the file?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
        {
            this.class18_0.SetAllByte(this.byte_0);
            this.class18_0.method_70();
            this.class18_0.SetByteNull();
            this.byte_0 = null;
        }
    }

    internal bool method_0()
    {
        return this.bool_4;
    }

    internal void method_1(bool bool_5)
    {
        this.bool_4 = bool_5;
    }

    internal bool method_0_SST256()
    {
        return this.bool_SST256;
    }

    internal void method_1_SST256(bool bool_5)
    {
        this.bool_SST256 = bool_5;
    }

    private byte method_10(byte[] byte_4, int int_1, int int_2)
    {
        byte num = 0;
        for (int i = 0; i < int_2; i++)
        {
            num = (byte) (num + byte_4[i]);
        }
        return num;
    }

    private byte method_11()
    {
        return this.byte_3;
    }

    private void method_12()
    {
        this.byte_3 = 0;
    }

    private void method_13(byte byte_4)
    {
        this.byte_3 = (byte) (this.byte_3 + byte_4);
    }

    private void method_14(byte[] byte_4, int int_1)
    {
        for (int i = 0; i < int_1; i++)
        {
            this.byte_3 = (byte) (this.byte_3 + byte_4[i]);
        }
    }

    private void method_15(byte[] byte_4, int int_1, int int_2)
    {
        for (int i = 0; i < int_2; i++)
        {
            this.byte_0[int_1 + i] = byte_4[i];
        }
    }

    public void method_16(frmBurner TFRM)
    {
        frmBurner_0 = TFRM;
        if (!this.method_4())
        {
            this.bool_0 = false;
        }
        else
        {
            LogThis("Writing chip");
            this.backgroundWorker_1 = new BackgroundWorker();
            this.backgroundWorker_1.WorkerReportsProgress = true;
            this.backgroundWorker_1.WorkerSupportsCancellation = true;
            this.backgroundWorker_1.DoWork += new DoWorkEventHandler(this.backgroundWorker_1_DoWork);
            this.backgroundWorker_1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_1_RunWorkerCompleted);
            this.backgroundWorker_1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_1_ProgressChanged);
            this.backgroundWorker_1.RunWorkerAsync();
            while (this.backgroundWorker_1 != null && this.backgroundWorker_1.IsBusy)
            {
                Application.DoEvents();
            }
            if (this.backgroundWorker_1 != null)
            {
                this.backgroundWorker_1.Dispose();
                this.backgroundWorker_1 = null;
            }
        }
    }

    public void method_17(frmBurner TFRM)
    {
        frmBurner_0 = TFRM;
        this.class18_0.method_68();
        if (!this.method_4())
        {
            this.bool_0 = false;
        }
        else
        {
            this.byte_0 = new byte[0x8000];
            if (!this.bool_1)
            {
                LogThis("Reading chip");
                BMBurnerDesc = "Reading chip";
                UpdateTileText();
            }
            this.backgroundWorker_2 = new BackgroundWorker();
            this.backgroundWorker_2.WorkerSupportsCancellation = true;
            this.backgroundWorker_2.WorkerReportsProgress = true;
            this.backgroundWorker_2.DoWork += new DoWorkEventHandler(this.backgroundWorker_2_DoWork);
            this.backgroundWorker_2.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_2_ProgressChanged);
            this.backgroundWorker_2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_2_RunWorkerCompleted);
            this.backgroundWorker_2.RunWorkerAsync();
            while (this.backgroundWorker_2 != null && this.backgroundWorker_2.IsBusy)
            {
                Application.DoEvents();
            }
            if (this.backgroundWorker_2 != null)
            {
                this.backgroundWorker_2.Dispose();
                this.backgroundWorker_2 = null;
            }
        }
    }

    public void method_18(frmBurner TFRM, bool bool_5)
    {
        frmBurner_0 = TFRM;
        if (bool_5 && !this.method_4())
        {
            this.bool_0 = false;
        }
        else
        {
            int ThisLenght = 32768;
            if (frmBurner_0.Is2Timer) ThisLenght = ThisLenght * 2;

            this.byte_0 = new byte[ThisLenght];
            this.bool_1 = true;
            LogThis("Verifying chip");
            BMBurnerDesc = "Chip verifying";
            UpdateTileText();
            this.backgroundWorker_2 = new BackgroundWorker();
            this.backgroundWorker_2.WorkerSupportsCancellation = true;
            this.backgroundWorker_2.WorkerReportsProgress = true;
            this.backgroundWorker_2.DoWork += new DoWorkEventHandler(this.backgroundWorker_2_DoWork);
            this.backgroundWorker_2.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_2_ProgressChanged);
            this.backgroundWorker_2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_2_RunWorkerCompleted);
            this.backgroundWorker_2.RunWorkerAsync();
            while (this.backgroundWorker_2 != null && this.backgroundWorker_2.IsBusy)
            {
                Application.DoEvents();
            }
            if (this.backgroundWorker_2 != null)
            {
                this.backgroundWorker_2.Dispose();
                this.backgroundWorker_2 = null;
            }
            for (int i = 0; i < ThisLenght; i++)
            {
                if (this.byte_0[i] != GetByteAt((long)i))
                //if (this.byte_0[i] != this.class18_0.method_150((long) i))
                {
                    LogThis("Chip NOT verified!");
                    BMBurnerDesc = "Chip NOT verified!";
                    UpdateTileText();
                    return;
                }
            }
            LogThis("Chip verified");
            BMBurnerDesc = "Chip verified";
            UpdateTileText();
            this.byte_0 = null;
            this.bool_1 = false;
            GC.Collect();
        }
    }

    private void UpdateTileText()
    {
        if (this.delegate9_0 != null)
        {
            this.delegate9_0(BMBurnerTitle + GetConnectedTitleString() + " - " + BMBurnerDesc);
        }
    }

    private void LogThis(string string_1)
    {
        this.class17_0.frmMain_0.LogThis("Burner - " + string_1);
    }

    internal long method_2()
    {
        return this.long_0;
    }

    internal void method_3(long long_1)
    {
        this.long_0 = long_1;
    }

    internal bool method_4()
    {
        LogThis("Detecting Burner");
        BMBurnerTitle = "";
        this.backgroundWorker_0 = new BackgroundWorker();
        this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
        this.backgroundWorker_0.WorkerReportsProgress = false;
        this.backgroundWorker_0.WorkerSupportsCancellation = false;
        this.backgroundWorker_0.RunWorkerAsync();
        while (this.backgroundWorker_0.IsBusy)
        {
            Application.DoEvents();
        }
        this.bool_0 = false;
        if (!this.bool_2 && this.frmBurner_0 != null) this.frmBurner_0.button1.Enabled = true;
        return this.bool_2;
    }

    private bool method_5()
    {
        int num = 3;
        int num2 = 0;
        if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen)
        {
            this.serialPort_0.Close();
        }
        if (this.serialPort_0 != null)
        {
            this.serialPort_0.Dispose();
            this.serialPort_0 = null;
        }
        this.serialPort_0 = new SerialPort("COM" + this.int_0.ToString(), 0x1c200);
        this.serialPort_0.ReadTimeout = 1000;
        this.serialPort_0.WriteTimeout = 500;
        this.serialPort_0.Encoding = Encoding.Default;
        this.serialPort_0.Open();

        this.LogThis("------------------------------");
        this.LogThis("Port open:COM" + this.int_0.ToString() + " (Baud:115200)");
        //this.byte_1 = new byte[5];
        this.byte_1 = new byte[2];
        this.byte_2 = new byte[3];
    Label_00B8:
        if ((num2 + 1) != num)
        {
            this.byte_1 = new byte[2];
            this.byte_1[0] = 0x56;
            this.byte_1[1] = 0x56;
            try
            {
                this.method_7(this.byte_1, 0, 2);
                for (int i = 0; i < 3; i++)
                {
                    this.byte_2[i] = this.method_9();
                }
                if (this.byte_2[0] == 5)
                {
                    TestBMBurner();
                    if (BMBurnerTitle == "") BMBurnerTitle = "Moates Burn1/2";
                    return true;
                }
            }
            catch
            {
                this.serialPort_0.DiscardInBuffer();
                try
                {
                    this.byte_1 = new byte[3];
                    this.byte_1[0] = 0x53;
                    this.byte_1[1] = 0;
                    this.byte_1[2] = 0x53;
                    this.method_7(this.byte_1, 0, 3);
                    this.serialPort_0.DiscardInBuffer();
                    this.serialPort_0.Close();
                    this.serialPort_0 = new SerialPort("COM" + this.int_0.ToString(), 0xe1000);
                    this.serialPort_0.ReadTimeout = 1000;
                    this.serialPort_0.WriteTimeout = 500;
                    this.serialPort_0.Open();
                    this.LogThis("Port open:COM" + this.int_0.ToString() + " (Baud:921600)");
                    this.byte_1 = new byte[2];
                    this.byte_1[0] = 0x56;
                    this.byte_1[1] = 0x56;
                    try
                    {
                        this.method_7(this.byte_1, 0, 2);
                        for (int j = 0; j < 3; j++)
                        {
                            this.byte_2[j] = this.method_9();
                        }
                        if (this.byte_2[0] == 5)
                        {
                            TestBMBurner();
                            if (BMBurnerTitle == "") BMBurnerTitle = "Moates Burn1/2";
                            return true;
                        }
                        this.LogThis("Can't dectect Burner on COM" + this.int_0.ToString());
                    }
                    catch
                    {
                        this.LogThis("Can't dectect Burner on COM" + this.int_0.ToString());
                        num2++;
                    }
                }
                catch
                {
                    this.LogThis("Can't dectect Burner on COM" + this.int_0.ToString());
                    num2++;
                }
                goto Label_00B8;
            }
        }
        this.serialPort_0.Close();
        this.serialPort_0.Dispose();
        this.serialPort_0 = null;
        return false;
    }

    public void ChangeAccTime()
    {
        if (IsBurnerV2())
        {
            this.LogThis("Changing chip Access Time to: " + frmBurner_0.LastAccessTime + "ns");
            byte[] Commands = new byte[2];
            Commands[0] = Convert.ToByte('A');
            Commands[1] = (byte)frmBurner_0.LastAccessTime;
            byte num2 = 0;
            try
            {

                this.method_7(Commands, 0, 2);
                num2 = this.method_9();
            }
            catch { }
            if (num2 == 0x4f)
            {
                this.LogThis("Chip Access Time changed succesfully");
            }
            else
            {
                this.LogThis("Error when changing chip Access Time");
                //MessageBox.Show(Form.ActiveForm, "Error when changing chip Access Time", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            if (IsBMBurner)
            {
                if ((this.frmBurner_0.LastAccessTime != 70 && this.frmBurner_0.ChipSelectBox.Text != "AT29C256")
                    || (this.frmBurner_0.LastAccessTime != 20)) MessageBox.Show(Form.ActiveForm, "This version of BMBurner CANNOT change AccessTime" + Environment.NewLine + Environment.NewLine + "It's possible the chip won't write correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((this.frmBurner_0.LastAccessTime != 20 && this.frmBurner_0.ChipSelectBox.Text == "SST27SF512")
                    || (this.frmBurner_0.LastAccessTime != 70 && this.frmBurner_0.ChipSelectBox.Text == "SST27SF512 (Fake 70ns)")
                    || (this.frmBurner_0.LastAccessTime != 70 && this.frmBurner_0.ChipSelectBox.Text == "AT29C256")) MessageBox.Show(Form.ActiveForm, "The Burn2 CANNOT change AccessTime" + Environment.NewLine + Environment.NewLine + "It's possible the chip won't write correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void TestBMBurner()
    {
        byte[] BurnerVersion = this.byte_2;
        int int_1 = BurnerVersion[0];
        int int_2 = BurnerVersion[1];
        string string_V = char.ConvertFromUtf32(BurnerVersion[2]);
        byte[] BurnerVersionFirmware = new byte[2];

        if (this.serialPort_0.IsOpen) this.serialPort_0.DiscardInBuffer();
        if (this.serialPort_0.IsOpen) this.serialPort_0.DiscardOutBuffer();
        IsBMBurner = false;
        //try
        //{
            this.byte_1 = new byte[2];
            this.byte_1[0] = Convert.ToByte('F');
            this.byte_1[1] = Convert.ToByte('F');

            this.method_7(this.byte_1, 0, 2);
            for (int j = 0; j < 2; j++) BurnerVersionFirmware[j] = this.method_9();



            if (BurnerVersionFirmware[0] < 50)
            {
                IsBMBurner = true;
            }
            //Console.WriteLine("firmware V" + BurnerVersionFirmware[0] + "." + BurnerVersionFirmware[1]);
        //}
        //catch {
            /*try
            {
                //##########################
                //testing old bmburner function
                this.byte_1 = new byte[2];
                this.byte_1[0] = Convert.ToByte('F');
                this.byte_1[1] = Convert.ToByte('F');

                this.method_7(this.byte_1, 0, 2);
                for (int j = 0; j < 2; j++) BurnerVersionFirmware[j] = this.method_9();
                IsBMBurner = true;
                //##########################
            }
            catch
            {

            }*/
        //}

        if (IsBMBurner)
        {
            FirmwareNumber = (BurnerVersionFirmware[0] * 10) + BurnerVersionFirmware[1];

            if (FirmwareNumber >= 13)
            {
                this.LogThis("BMBurner V2.X (firmware V" + BurnerVersionFirmware[0] + "." + BurnerVersionFirmware[1] + ")");
                BMBurnerTitle = "BMBurner V2.X";
            }
            else
            {
                if (this.serialPort_0.BaudRate == 115200)
                {
                    this.LogThis("BMBurner V1.0 (firmware V" + BurnerVersionFirmware[0] + "." + BurnerVersionFirmware[1] + ")");
                    BMBurnerTitle = "BMBurner V1.0";
                }
                else if (this.serialPort_0.BaudRate == 921600)
                {
                    this.LogThis("BMBurner V1.1 (firmware V" + BurnerVersionFirmware[0] + "." + BurnerVersionFirmware[1] + ")");
                    BMBurnerTitle = "BMBurner V1.1";
                }
            }
        }
        else
        {
            this.LogThis("Moates Burn1/2 (V" + int_1 + "." + int_2 + "." + string_V + ")");
            BMBurnerTitle = "Moates Burn1/2";
            IsBMBurner = false;
        }
    }

    private bool IsBurnerV2()
    {
        if (IsBMBurner)
        {
            if (FirmwareNumber >= 13) return true;
            else return false;
        }
        return false;
    }

    private void method_6(byte byte_4)
    {
        this.serialPort_0.Write(((char) byte_4).ToString());
    }

    private void method_7(byte[] byte_4, int int_1, int int_2)
    {
        this.serialPort_0.Write(byte_4, int_1, int_2);
    }

    private void method_8(string string_0)
    {
        this.serialPort_0.Write(string_0);
    }

    private byte method_9()
    {
        return (byte) this.serialPort_0.ReadByte();
    }

    public delegate void Delegate8(int int_0);

    public delegate void Delegate9(string string_0);
}

