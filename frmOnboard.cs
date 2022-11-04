using Data;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public class frmOnboard : Form
{
    public Button button1;
    public ComboBox comboBox1;
    public Button button3;
    public Button button5;
    public Button button4;
    public Button button2;
    public static bool bool_0;
    private Class17 class17_0;
    private static Class17 class17_2;
    private Class10_settings class10_0;
    public int int_0;
    private Label label8;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    public Button button8;
    private ProgressBar ProgressBar1;
    private ListView listView1;
    private ColumnHeader columnHeader_0;
    private ColumnHeader columnHeader_1;
    private ColumnHeader columnHeader_2;
    private ColumnHeader columnHeader_3;
    private ColumnHeader columnHeader_4;
    public bool bool_1;
    public string[] string_0 = new string[0xff];
    private IContainer icontainer_0;
    private System.Timers.Timer timer_0;

    internal frmOnboard(ref Class17 class11_1, ref Class10_settings class10_1 )
    {
        this.class17_0 = class11_1;
        this.class10_0 = class10_1;
        this.InitializeComponent();

        class17_2 = class17_0;

        this.timer_0 = new System.Timers.Timer();
        this.timer_0.Interval = 10;

        //this.ProgressBar1.String_0 = "";
        //this.ProgressBar1.Color_1 = Color.LightGreen;
        //this.ProgressBar1.Color_0 = Color.Black;
        //this.ProgressBar1.Font_0 = new Font("Times New Roman", 11f, FontStyle.Italic | FontStyle.Bold);
        //this.ProgressBar1.GEnum19_0 = GEnum19.CurrProgress;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class10_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.button1.Enabled = false;
        this.method_7();
        this.button1.Enabled = true;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (class17_0.serialPort_0.IsOpen)
        {
            this.method_6(true);
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        this.method_8();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        this.method_3();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        this.method_4();
    }

    private void frmOnboard_Load(object sender, EventArgs e)
    {
        bool flag = false;
        if (class10_0.emulatorMode_0 != EmulatorMode.Demon)
        {
            MessageBox.Show("This only works when connected to Moates Demon", "BMTune");
            base.Close();
        }
        else
        {
            try
            {
                /*if (class17_0.serialPort_0.IsOpen)
                {
                    this.ProgressBar1.GEnum19_0 = GEnum19.CustomText;
                }*/
                flag = true;
            }
            catch
            {
                MessageBox.Show("This only works when connected to Moates Demon", "BMTune");
                base.Close();
            }
        }
        if (flag)
        {
            this.method_1();
        }
    }

    private void InitializeComponent()
    {
        this.icontainer_0 = new Container();
        ComponentResourceManager manager = new ComponentResourceManager(typeof(frmOnboard));
        this.button1 = new Button();
        this.comboBox1 = new ComboBox();
        this.button3 = new Button();
        this.button5 = new Button();
        this.button4 = new Button();
        this.button2 = new Button();
        this.label8 = new Label();
        this.label5 = new Label();
        this.label4 = new Label();
        this.label3 = new Label();
        this.label2 = new Label();
        this.label1 = new Label();
        this.button8 = new Button();
        this.listView1 = new ListView();
        this.columnHeader_0 = new ColumnHeader();
        this.columnHeader_1 = new ColumnHeader();
        this.columnHeader_2 = new ColumnHeader();
        this.columnHeader_3 = new ColumnHeader();
        this.columnHeader_4 = new ColumnHeader();
        this.ProgressBar1 = new ProgressBar();
        base.SuspendLayout();
        this.button1.Location = new Point(0x39b, 0x18e);
        this.button1.Margin = new Padding(2);
        this.button1.Name = "button1";
        this.button1.Size = new Size(0x9a, 0x3e);
        this.button1.TabIndex = 70;
        this.button1.Text = "Dump";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new EventHandler(this.button1_Click);
        this.comboBox1.FormattingEnabled = true;
        object[] items = new object[] { "20ms (8min)", "40ms (16min)", "80ms (32min)", "100ms (40min)", "125ms (50min)" };
        this.comboBox1.Items.AddRange(items);
        this.comboBox1.Location = new Point(0x39f, 0xc5);
        this.comboBox1.Margin = new Padding(2);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new Size(150, 0x20);
        this.comboBox1.TabIndex = 0x44;
        this.comboBox1.Text = "20ms (8min)";
        this.button3.Location = new Point(0x39f, 11);
        this.button3.Margin = new Padding(6);
        this.button3.Name = "button3";
        this.button3.Size = new Size(150, 0x2e);
        this.button3.TabIndex = 0x42;
        this.button3.Text = "Scan";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new EventHandler(this.button3_Click);
        this.button5.Location = new Point(0x39b, 0xf4);
        this.button5.Margin = new Padding(2);
        this.button5.Name = "button5";
        this.button5.Size = new Size(0x9a, 0x30);
        this.button5.TabIndex = 0x3a;
        this.button5.Text = "Erase";
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new EventHandler(this.button5_Click);
        this.button4.Location = new Point(0x39f, 0x41);
        this.button4.Margin = new Padding(2);
        this.button4.Name = "button4";
        this.button4.Size = new Size(150, 0x34);
        this.button4.TabIndex = 0x39;
        this.button4.Text = "Compression";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new EventHandler(this.button4_Click);
        this.button2.Location = new Point(0x39f, 0x80);
        this.button2.Margin = new Padding(2);
        this.button2.Name = "button2";
        this.button2.Size = new Size(150, 0x37);
        this.button2.TabIndex = 0x38;
        this.button2.Text = "Enable OB";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new EventHandler(this.button2_Click);
        this.label8.AutoSize = true;
        this.label8.Location = new Point(0x28c, 0x1b0);
        this.label8.Margin = new Padding(2, 0, 2, 0);
        this.label8.Name = "label8";
        this.label8.Size = new Size(0x86, 0x19);
        this.label8.TabIndex = 0x4c;
        this.label8.Text = "Compression:";
        this.label5.AutoSize = true;
        this.label5.Location = new Point(0x296, 0x18b);
        this.label5.Margin = new Padding(2, 0, 2, 0);
        this.label5.Name = "label5";
        this.label5.Size = new Size(0x7c, 0x19);
        this.label5.TabIndex = 0x4b;
        this.label5.Text = "Total Space:";
        this.label4.AutoSize = true;
        this.label4.Location = new Point(0x151, 0x1b0);
        this.label4.Margin = new Padding(2, 0, 2, 0);
        this.label4.Name = "label4";
        this.label4.Size = new Size(160, 0x19);
        this.label4.TabIndex = 0x4a;
        this.label4.Text = "Space Available:";
        this.label3.AutoSize = true;
        this.label3.Location = new Point(0x173, 0x18b);
        this.label3.Margin = new Padding(2, 0, 2, 0);
        this.label3.Name = "label3";
        this.label3.Size = new Size(0x7e, 0x19);
        this.label3.TabIndex = 0x49;
        this.label3.Text = "Space Used:";
        this.label2.AutoSize = true;
        this.label2.Location = new Point(0x20, 0x1b0);
        this.label2.Margin = new Padding(2, 0, 2, 0);
        this.label2.Name = "label2";
        this.label2.Size = new Size(0x92, 0x19);
        this.label2.TabIndex = 0x48;
        this.label2.Text = "Logs Available:";
        this.label1.AutoSize = true;
        this.label1.Location = new Point(0x1c, 0x18b);
        this.label1.Margin = new Padding(2, 0, 2, 0);
        this.label1.Name = "label1";
        this.label1.Size = new Size(150, 0x19);
        this.label1.TabIndex = 0x47;
        this.label1.Text = "Recorded Logs:";
        this.button8.Location = new Point(0x39b, 0x131);
        this.button8.Margin = new Padding(2);
        this.button8.Name = "button8";
        this.button8.Size = new Size(0x9a, 0x30);
        this.button8.TabIndex = 0x4d;
        this.button8.Text = "Write";
        this.button8.UseVisualStyleBackColor = true;
        ColumnHeader[] values = new ColumnHeader[] { this.columnHeader_0, this.columnHeader_1, this.columnHeader_2, this.columnHeader_3, this.columnHeader_4 };
        this.listView1.Columns.AddRange(values);
        this.listView1.HideSelection = false;
        this.listView1.Location = new Point(0x12, 11);
        this.listView1.Margin = new Padding(2);
        this.listView1.Name = "listView1";
        this.listView1.Size = new Size(0x37c, 0x176);
        this.listView1.TabIndex = 0x4f;
        this.listView1.UseCompatibleStateImageBehavior = false;
        this.listView1.View = View.Details;
        this.listView1.DoubleClick += new EventHandler(this.listView1_DoubleClick);
        this.columnHeader_0.Text = "LOG#";
        this.columnHeader_0.Width = 0x84;
        this.columnHeader_1.Text = "Size";
        this.columnHeader_1.Width = 80;
        this.columnHeader_2.Text = "Samples";
        this.columnHeader_2.Width = 80;
        this.columnHeader_3.Text = "Duration";
        this.columnHeader_3.Width = 90;
        this.columnHeader_4.Text = "Compressed";
        this.columnHeader_4.Width = 0x66;
        this.ProgressBar1.Location = new Point(0x12, 0x1dc);
        this.ProgressBar1.Name = "ProgressBar1";
        this.ProgressBar1.Size = new Size(0x423, 0x29);
        this.ProgressBar1.TabIndex = 0x4e;
        base.AutoScaleDimensions = new SizeF(11f, 24f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.ClientSize = new Size(0x445, 0x214);
        base.Controls.Add(this.listView1);
        base.Controls.Add(this.ProgressBar1);
        base.Controls.Add(this.button8);
        base.Controls.Add(this.label8);
        base.Controls.Add(this.label5);
        base.Controls.Add(this.label4);
        base.Controls.Add(this.label3);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.label1);
        base.Controls.Add(this.button1);
        base.Controls.Add(this.comboBox1);
        base.Controls.Add(this.button3);
        base.Controls.Add(this.button5);
        base.Controls.Add(this.button4);
        base.Controls.Add(this.button2);
        base.FormBorderStyle = FormBorderStyle.FixedDialog;
        base.Margin = new Padding(4);
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.Name = "frmOnboard";
        this.Text = "Onboard Datalogging";
        base.Load += new EventHandler(this.frmOnboard_Load);
        base.ResumeLayout(false);
        base.PerformLayout();
    }

    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        this.method_9();
    }

    public byte[] method_0(byte[] byte_0)
    {
        byte num = 0;
        foreach (byte num3 in byte_0)
        {
            num = (byte) (num + num3);
        }
        byte[] buffer = new byte[byte_0.Length + 1];
        byte_0.CopyTo(buffer, 0);
        buffer[buffer.Length - 1] = num;
        return buffer;
    }

    public void method_1()
    {
        class17_0.serialPort_0.DiscardInBuffer();
        class17_0.serialPort_0.DiscardOutBuffer();
        byte[] buffer = new byte[0x20];
        byte[] buffer2 = this.method_0(new byte[] { 0x44, 0x4f, 0x4c, 0x4e });
        class17_0.serialPort_0.Write(buffer2, 0, buffer2.Length);
        Thread.Sleep(20);
        class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
        if (buffer[0] == 0x4f)
        {
            byte[] buffer3 = this.method_0(new byte[] { 0x44, 0x4f, 0x4c, 110 });
            class17_0.serialPort_0.Write(buffer3, 0, buffer3.Length);
            Thread.Sleep(20);
            class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
            if (buffer[0] == 0x4f)
            {
                byte[] buffer4 = this.method_0(new byte[] { 0x44, 0x4f, 0x4c, 0x49 });
                class17_0.serialPort_0.Write(buffer4, 0, buffer4.Length);
                Thread.Sleep(20);
                class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
                byte num = buffer[1];
                byte num2 = buffer[2];
                byte num3 = buffer[3];
                byte num14 = buffer[14];
                byte num15 = buffer[15];
                this.bool_1 = buffer[12] == 0x59;
                int num17 = 0;
                if (num15 == 0)
                {
                    num17 = 0x100;
                }
                else if (num15 == 1)
                {
                    num17 = 0x200;
                }
                else if (num15 == 3)
                {
                    num17 = 0x200;
                }
                if (num14 == 7)
                {
                    this.int_0 = 0xfa000;
                }
                else if (num14 == 15)
                {
                    this.int_0 = 0x3e8000;
                }
                else if (num14 == 0x1f)
                {
                    this.int_0 = 0x3e8000;
                }
                float num18 = ((float) (((num2 << 8) | num3) * num17)) / 1000f;
                this.label1.Text = "Recorded Logs: " + num.ToString();
                this.label2.Text = "Logs Available: " + (0xff - num).ToString();
                this.label3.Text = "Space Used: " + num18.ToString() + "KB";
                this.label4.Text = "Space Available: " + ((this.int_0 / 0x3e8) - num18).ToString() + "KB";
                this.label5.Text = "Total Space: " + (this.int_0 / 0x3e8).ToString() + "KB";
                this.label8.Text = "Compression: " + this.bool_1.ToString();
                if ((num != 0) && (MessageBox.Show("New Onboard Datalogs," + Environment.NewLine + "Do you want to scan them?", "Onboard", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    this.method_8();
                }
            }
        }
    }

    private void method_10(object sender, ProgressChangedEventArgs e)
    {
        float num2 = (((float) int.Parse(e.ProgressPercentage.ToString())) / ((float) this.int_0)) * 100f;
        //this.ProgressBar1.String_0 = "Dumping Rom: " + num2.ToString() + " %";
        this.Text = "Onboard Datalogging - Dumping Rom: " + num2.ToString() + " % ";
        this.ProgressBar1.Value = (int) num2;
    }

    private byte[] method_2(params byte[][] byte_0)
    {
        byte[] buffer = new byte[byte_0.Sum<byte[]>(TestOnBoardClass.TestInt ?? (TestOnBoardClass.TestInt = new Func<byte[], int>(frmOnboard.TestOnBoardClass.TestValue.method_0)))];
        int num = 0;
        foreach (byte[] buffer2 in byte_0)
        {
            Buffer.BlockCopy(buffer2, 0, buffer, num, buffer2.Length);
            num += buffer2.Length;
        }
        return buffer;
    }

    public void method_3()
    {
        if (class17_0.serialPort_0.IsOpen)
        {
            class17_0.serialPort_0.DiscardInBuffer();
            class17_0.serialPort_0.DiscardOutBuffer();
            byte[] buffer = new byte[0x40];
            DialogResult dialogResult = MessageBox.Show(string.Concat(new string[]
            {
                "Compression is set to ",
                this.bool_1.ToString(),
                Environment.NewLine,
                "Do you want to set it to ",
                (!this.bool_1).ToString()
            }), "Onboard Compression", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.bool_1)
                {
                    byte[] buffer2 = this.method_0(new byte[] { 0x44, 0x4f, 0x43, 0x4e });
                    class17_0.serialPort_0.Write(buffer2, 0, buffer2.Length);
                    Thread.Sleep(20);
                    class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
                }
                else
                {
                    byte[] buffer3 = this.method_0(new byte[] { 0x44, 0x4f, 0x43, 0x59 });
                    class17_0.serialPort_0.Write(buffer3, 0, buffer3.Length);
                    Thread.Sleep(20);
                    class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
                }
                if (buffer[0] == 0x4f)
                {
                    MessageBox.Show("Change Set.");
                    this.method_1();
                }
            }
        }
    }

    public void method_4()
    {
        if (class17_0.serialPort_0.IsOpen)
        {
            byte[] buffer = new byte[0x40];
            string[] textArray1 = new string[] { "Do you want to erase all onboard logs?", Environment.NewLine, "**** Warning ****", Environment.NewLine, "It takes 10 sec for memory to be erase" };
            if (MessageBox.Show(string.Concat(textArray1), "Onboard Erase", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                byte[] buffer2 = this.method_0(new byte[] { 0x44, 0x4f, 0x45 });
                class17_0.serialPort_0.DiscardInBuffer();
                class17_0.serialPort_0.DiscardOutBuffer();
                class17_0.serialPort_0.Write(buffer2, 0, buffer2.Length);
                for (byte i = 0; (buffer[0] == 0) && (i <= 12); i = (byte) (i + 1))
                {
                    class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
                    if (buffer[0] == 0x4f)
                    {
                        MessageBox.Show("Onboard erased.");
                        this.method_1();
                        return;
                    }
                    Thread.Sleep(0x3e8);
                }
            }
        }
    }

    public int method_5(int int_1, int int_2)
    {
        while (int_2 != 0)
        {
            int num = ~int_1 & int_2;
            int_1 ^= int_2;
            int_2 = num << 1;
        }
        return int_1;
    }

    private void method_6(bool bool_2)
    {
        byte[] buffer = new byte[0x20];
        byte[] buffer2 = new byte[8];
        if (bool_2)
        {
            buffer2 = this.method_0(new byte[] { 0x44, 0x4f, 0x4c, 0x59 });
            class17_0.serialPort_0.Write(buffer2, 0, buffer2.Length);
            Thread.Sleep(50);
            class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
            if (buffer[0] == 0x4f)
            {
                buffer2 = this.method_0(new byte[] { 0x44, 0x4f, 0x4c, 0x79 });
                class17_0.serialPort_0.Write(buffer2, 0, buffer2.Length);
                Thread.Sleep(50);
                class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
                if (buffer[0] == 0x4f)
                {
                    this.button2.Text = "Disable OB";
                }
            }
        }
        else
        {
            buffer2 = this.method_0(new byte[] { 0x44, 0x4f, 0x4c, 0x4e });
            class17_0.serialPort_0.Write(buffer2, 0, buffer2.Length);
            Thread.Sleep(50);
            class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
            if (buffer[0] == 0x4f)
            {
                buffer2 = this.method_0(new byte[] { 0x44, 0x4f, 0x4c, 110 });
                class17_0.serialPort_0.Write(buffer2, 0, buffer2.Length);
                Thread.Sleep(50);
                class17_0.serialPort_0.Read(buffer, 0, class17_0.serialPort_0.BytesToRead);
                if (buffer[0] == 0x4f)
                {
                    this.button2.Text = "Enable OB";
                }
            }
        }
    }

    private void method_7()
    {
        if (class17_0.serialPort_0.IsOpen)
        {
            Class45 class2 = new Class45 {
                frmOnboard_0 = this,
                byte_0 = new byte[1]
            };
            if (MessageBox.Show("Do you want to dump the complete onboard memory of your demon?", "Dump Demon", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                class2.dialogResult_0 = MessageBox.Show("Only dump written zones?", "Dump Demon", MessageBoxButtons.YesNo);
                class2.int_0 = 0;
                BackgroundWorker worker = new BackgroundWorker {
                    WorkerReportsProgress = true
                };
                worker.DoWork += new DoWorkEventHandler(class2.method_0);
                worker.ProgressChanged += new ProgressChangedEventHandler(this.method_10);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(class2.method_1);
                worker.RunWorkerAsync();
            }
        }
    }

    private void method_8()
    {
        Class46 class2 = new Class46 {
            frmOnboard_0 = this
        };
        this.listView1.Items.Clear();
        class2.byte_0 = new byte[1];
        if (class17_0.serialPort_0.IsOpen)
        {
            Class47 class3 = new Class47 {
                class46_0 = class2,
                int_0 = 0
            };
            BackgroundWorker worker = new BackgroundWorker {
                WorkerReportsProgress = true
            };
            worker.DoWork += new DoWorkEventHandler(class3.method_0);
            worker.ProgressChanged += new ProgressChangedEventHandler(class3.class46_0.method_0);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(class3.class46_0.method_1);
            worker.RunWorkerAsync();
        }
    }

    private void method_9()
    {
        int index = this.listView1.SelectedIndices[0] + 1;
        SaveFileDialog dialog = new SaveFileDialog {
            Filter = "Demon Datalog|*.log",
            Title = "Save Demon Onboard Datalog"
        };
        dialog.ShowDialog();
        if (dialog.FileName != "")
        {
            if (File.Exists(dialog.FileName))
            {
                File.Delete(dialog.FileName);
            }
            using (Stream stream = (Stream) File.OpenWrite(dialog.FileName))
            {
                byte[] buffer = smethod_0(this.string_0[index]);
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }

    public static byte[] smethod_0(string string_1)
    {
        int length = string_1.Length;
        byte[] buffer = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            buffer[i / 2] = Convert.ToByte(string_1.Substring(i, 2), 0x10);
        }
        return buffer;
    }

    public static string smethod_1(byte[] byte_0)
    {
        return BitConverter.ToString(byte_0).Replace("-", "");
    }

    private sealed class TestOnBoardClass
    {
        public static readonly frmOnboard.TestOnBoardClass TestValue = new frmOnboard.TestOnBoardClass();
        public static Func<byte[], int> TestInt;

        internal int method_0(byte[] byte_0)
        {
            return byte_0.Length;
        }
    }

    private sealed class Class45
    {
        public byte[] byte_0;
        public DialogResult dialogResult_0;
        public int int_0;
        public frmOnboard frmOnboard_0;

        internal void method_0(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool flag = false;
            byte[] array = new byte[2];
            bool flag2 = false;
            while (this.byte_0.Length <= this.frmOnboard_0.int_0 && !flag2)
            {
                frmOnboard frmOnboard = this.frmOnboard_0;
                byte[] array2 = new byte[]
                {
                    68,
                    79,
                    82,
                    0,
                    0,
                    5
                };
                array2[3] = array[0];
                array2[4] = array[1];
                byte[] array3 = frmOnboard.method_0(array2);
                switch (array[1])
                {
                    case 251:
                        flag = true;
                        break;
                    case 252:
                        flag = true;
                        break;
                    case 253:
                        flag = true;
                        break;
                    case 254:
                        flag = true;
                        break;
                    case 255:
                        flag = true;
                        break;
                }
                byte[] array4 = array;
                int num = 1;
                array4[num] += 5;
                if (flag)
                {
                    byte[] array5 = array;
                    int num2 = 0;
                    array5[num2] += 1;
                    flag = false;
                }
                class17_2.serialPort_0.Write(array3, 0, array3.Length);
                Thread.Sleep(45);
                byte[] array6 = new byte[this.frmOnboard_0.method_5(class17_2.serialPort_0.BytesToRead, 1)];
                byte[] array7 = new byte[array6.Length + 1];
                class17_2.serialPort_0.Read(array7, 0, array7.Length);
                byte b = 0;
                int num3 = 0;
                foreach (byte b2 in array7)
                {
                    num3++;
                    if (num3 != array7.Length)
                    {
                        b += b2;
                    }
                }
                if (b == array7[array6.Length])
                {
                    Array.Copy(array7, array6, array6.Length);
                    this.byte_0 = this.frmOnboard_0.method_2(new byte[][]
                    {
                        this.byte_0,
                        array6
                    });
                    backgroundWorker.ReportProgress(this.byte_0.Length);
                }
                else
                {
                    MessageBox.Show("Checksum fault!", "error");
                    flag2 = true;
                }
                if (this.dialogResult_0 == DialogResult.Yes && array6[2] == 255 && array6[3] == 255 && array6[4] == 255 && array6[5] == 255 && array6[6] == 255 && array6[array6.Length - 8] == 255 && array6[array6.Length - 4] == 255 && array6[array6.Length - 2] == 255)
                {
                    byte[] array9 = new byte[this.frmOnboard_0.int_0 - this.byte_0.Length];
                    for (int j = 0; j < array9.Length; j++)
                    {
                        array9[j] = byte.MaxValue;
                    }
                    this.byte_0 = this.frmOnboard_0.method_2(new byte[][]
                    {
                        this.byte_0,
                        array9
                    });
                    flag2 = true;
                }
            }
            this.int_0 = (int)stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Stop();
        }

        internal void method_1(object sender, RunWorkerCompletedEventArgs e)
        {
            string str = (this.int_0 / 60).ToString() + ":" + (this.int_0 % 60).ToString();
            //this.frmOnboard_0.ProgressBar1.String_0 = "Completed in: " + str;
            this.frmOnboard_0.Text = "Onboard Datalogging - Completed in: " + str;

            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Demon Dump|*.DD",
                Title = "Save Demon Onboard Memory"
            };
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                if (File.Exists(dialog.FileName))
                {
                    File.Delete(dialog.FileName);
                }
                using (Stream stream = (Stream) File.OpenWrite(dialog.FileName))
                {
                    stream.Write(this.byte_0, 0, this.byte_0.Length);
                }
            }
        }
    }

    private sealed class Class46
    {
        public frmOnboard frmOnboard_0;
        public byte[] byte_0;

        internal void method_0(object sender, ProgressChangedEventArgs e)
        {
            float num2 = (((float) int.Parse(e.ProgressPercentage.ToString())) / ((float) this.frmOnboard_0.int_0)) * 100f;
            //this.frmOnboard_0.ProgressBar1.String_0 = "Scanning Dataloggs Total Rom Read: " + num2.ToString() + " %";
            this.frmOnboard_0.Text = "Onboard Datalogging - Scanning Dataloggs Total Rom Read: " + num2.ToString() + " %";
            this.frmOnboard_0.ProgressBar1.Value = (int) num2;
        }

        internal void method_1(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.frmOnboard_0.ProgressBar1.String_0 = "Finished Scanning.";
            this.frmOnboard_0.Text = "Onboard Datalogging - Finished Scanning.";
            string @string = Encoding.UTF8.GetString(this.byte_0);
            string[] array = @string.Split(new string[]
            {
                "<S>"
            }, StringSplitOptions.None);
            this.frmOnboard_0.string_0 = frmOnboard.smethod_1(this.byte_0).Replace("3C2F533E", "").Split(new string[]
            {
                "3C533E"
            }, StringSplitOptions.None);
            int num = 1;
            int num2 = 50;
            foreach (string text in array)
            {
                try
                {
                    if (!text.Substring(0, 2).Contains("\0"))
                    {
                        string[] array3 = text.Split(new string[]
                        {
                            "<D>"
                        }, StringSplitOptions.None);
                        TimeSpan timeSpan = TimeSpan.FromSeconds((double)(num2 * array3.Length / 1000));
                        string[] array4 = new string[5];
                        array4[0] = "Onboard Log " + num++.ToString();
                        array4[1] = (array3.Length * 71 / 1000).ToString() + " KB";
                        array4[2] = array3.Length.ToString();
                        array4[3] = timeSpan.ToString();
                        if (array4[1] == "0 KB")
                        {
                            array4[4] = "True";
                        }
                        else
                        {
                            array4[4] = "False";
                        }
                        ListViewItem value = new ListViewItem(array4);
                        this.frmOnboard_0.listView1.Items.Add(value);
                    }
                }
                catch
                {
                }
            }
        }
    }

    private sealed class Class47
    {
        public int int_0;
        public frmOnboard.Class46 class46_0;

        internal void method_0(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool flag = false;
            byte[] array = new byte[2];
            bool flag2 = true;
            while (flag2)
            {
                frmOnboard frmOnboard_ = this.class46_0.frmOnboard_0;
                byte[] array2 = new byte[]
                {
                    68,
                    79,
                    82,
                    0,
                    0,
                    5
                };
                array2[3] = array[0];
                array2[4] = array[1];
                byte[] array3 = frmOnboard_.method_0(array2);
                switch (array[1])
                {
                    case 251:
                        flag = true;
                        break;
                    case 252:
                        flag = true;
                        break;
                    case 253:
                        flag = true;
                        break;
                    case 254:
                        flag = true;
                        break;
                    case 255:
                        flag = true;
                        break;
                }
                byte[] array4 = array;
                int num = 1;
                array4[num] += 5;
                if (flag)
                {
                    byte[] array5 = array;
                    int num2 = 0;
                    array5[num2] += 1;
                    flag = false;
                }
                class17_2.serialPort_0.Write(array3, 0, array3.Length);
                Thread.Sleep(45);
                byte[] array6 = new byte[this.class46_0.frmOnboard_0.method_5(class17_2.serialPort_0.BytesToRead, 1)];
                byte[] array7 = new byte[array6.Length + 1];
                class17_2.serialPort_0.Read(array7, 0, array7.Length);
                byte b = 0;
                int num3 = 0;
                foreach (byte b2 in array7)
                {
                    num3++;
                    if (num3 != array7.Length)
                    {
                        b += b2;
                    }
                }
                if (b == array7[array6.Length])
                {
                    Array.Copy(array7, array6, array6.Length);
                    this.class46_0.byte_0 = this.class46_0.frmOnboard_0.method_2(new byte[][]
                    {
                        this.class46_0.byte_0,
                        array6
                    });
                    backgroundWorker.ReportProgress(this.class46_0.byte_0.Length);
                }
                else
                {
                    flag2 = false;
                }
                if (array6[2] == 255 && array6[3] == 255 && array6[4] == 255 && array6[5] == 255 && array6[6] == 255 && array6[array6.Length - 8] == 255 && array6[array6.Length - 4] == 255 && array6[array6.Length - 2] == 255)
                {
                    flag2 = false;
                }
            }
            this.int_0 = ((int) stopwatch.ElapsedMilliseconds) / 0x3e8;
            stopwatch.Stop();
        }
    }
}

