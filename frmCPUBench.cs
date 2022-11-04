using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmCPUBench : Form
{
    public static string string_0 = "";
    public static string string_1;
    public static string string_2;
    public static int int_0 = 0;
    public long long_0;
    public long long_1;
    public long long_2;
    public int int_1 = 0x3a98;
    private const int int_2 = 0x200;
    private IContainer icontainer_0;
    private Button button1;
    private Label label1;
    private Label label2;
    private ProgressBar progressBar1;
    private ProgressBar progressBar2;
    private ProgressBar progressBar3;
    private ProgressBar progressBar4;
    private Label label3;
    private Button button2;
    private Label label4;
    private Label label5;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label6;

    internal frmCPUBench(ref Class17 Class17_1)
    {
        this.InitializeComponent();

        /*foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }*/
    }

    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Your Laptop may stop responding for 10-20 sec this is normal as the CPU 100% loaded");
        this.long_0 = 0L;
        this.Text = "Laptop Benchmark Tool - Benchmark in progress";
        this.method_2();
        this.long_1 = smethod_00(DateTime.Now);
        this.long_2 = this.long_1 + 10L;
        this.method_3();
        this.method_4();
        this.method_5();
        this.method_6();
        if (Environment.ProcessorCount >= 8)
        {
            this.method_7();
            this.method_8();
            this.method_9();
            this.method_10();
        }
    }

    public long smethod_00(DateTime dateTime_0) {
        return ((long)(dateTime_0 - new DateTime(0x7b2, 1, 1, 0, 0, 0)).TotalSeconds);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        base.Close();
    }

    private void CPUBench_Load(object sender, EventArgs e)
    {
        //this.progressBar1.GEnum19_0 = GEnum19.CustomText;
        //this.progressBar2.GEnum19_0 = GEnum19.CustomText;
        //this.progressBar3.GEnum19_0 = GEnum19.CustomText;
        //this.progressBar4.GEnum19_0 = GEnum19.CustomText;
        string_0 = "";
        this.method_0();
        this.method_1();
        string[] textArray1 = new string[] { string_0, Environment.NewLine, "Dot Net frameworks found on system:", Environment.NewLine, Class22_startup.string_8 };
        this.label2.Text = string.Concat(textArray1);
        if (int.Parse(string_2) < 4)
        {
            MessageBox.Show("CPU thead count is less than recommended spec of 4 threads." + Environment.NewLine + "The program is designed to use 1 thread per task, Emulation/datalogging/Table tracing/GUI Updates", "Under Min Spec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            int_0 += 0x7d0;
        }
        if (int.Parse(string_1) < 4)
        {
            int_0 += 0x7d0;
            MessageBox.Show("RAM is less than recommended spec of 4GB." + Environment.NewLine + "You may not have any issues but the test team has found 4GB to be optimum", "Under Min Spec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCPUBench));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Benchmark";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Details:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(10, 214);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(340, 16);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPU Bench Score: 0000";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(10, 234);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(340, 16);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 5;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(10, 254);
            this.progressBar3.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(340, 16);
            this.progressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar3.TabIndex = 6;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(10, 274);
            this.progressBar4.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(340, 16);
            this.progressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar4.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(376, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 43);
            this.button2.TabIndex = 8;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(453, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "GOOD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(461, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "OK";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(456, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "BAD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 216);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "GUI thread:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 236);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Emulator thread:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 256);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Datalogging thread:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(362, 276);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Table Editing thread:";
            // 
            // frmCPUBench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 296);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCPUBench";
            this.Text = "Laptop Benchmark Tool";
            this.Load += new System.EventHandler(this.CPUBench_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    public void method_0()
    {
        foreach (ManagementObject obj2 in new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get())
        {
            if (obj2["Caption"] != null)
            {
                string_0 = string_0 + "Operating System Name  :  " + obj2["Caption"].ToString() + Environment.NewLine;
            }
            if (obj2["OSArchitecture"] != null)
            {
                string_0 = string_0 + "Operating System Architecture  :  " + obj2["OSArchitecture"].ToString() + Environment.NewLine;
            }
            if (obj2["CSDVersion"] != null)
            {
                string_0 = string_0 + "Operating System Service Pack   :  " + obj2["CSDVersion"].ToString() + Environment.NewLine;
            }
            if (obj2["TotalVisibleMemorySize"] != null)
            {
                string_1 = (int.Parse(obj2["TotalVisibleMemorySize"].ToString()) / 0x100000).ToString("0");
                string[] textArray1 = new string[] { string_0, "Total RAM   :  ", string_1, " GB", Environment.NewLine };
                string_0 = string.Concat(textArray1);
            }
        }
    }

    public void method_1()
    {
        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", (RegistryKeyPermissionCheck) RegistryKeyPermissionCheck.ReadSubTree);
        if ((key != null) && (key.GetValue("ProcessorNameString") != null))
        {
            string text1;
            object obj1 = key.GetValue("ProcessorNameString");
            if (obj1 != null)
            {
                text1 = obj1.ToString();
            }
            else
            {
                object local1 = obj1;
                text1 = null;
            }
            string_0 = string_0 + text1 + Environment.NewLine;
        }
        string_2 = Environment.ProcessorCount.ToString();
        string_0 = string_0 + "CPU Threads: " + Environment.ProcessorCount.ToString() + Environment.NewLine;
    }

    private void method_10()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_30);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_31);
        worker.RunWorkerAsync();
    }

    public long method_11(int int_3)
    {
        int num = 0;
        long num2 = 2L;
        while (num < int_3)
        {
            long num3 = 2L;
            int num4 = 1;
            while (true)
            {
                if ((num3 * num3) <= num2)
                {
                    if ((num2 % num3) != 0)
                    {
                        num3 += 1L;
                        continue;
                    }
                    num4 = 0;
                }
                if (num4 > 0)
                {
                    num++;
                }
                num2 += 1L;
                break;
            }
        }
        return (num2 -= 1L);
    }

    private void method_12(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_13(object sender, ProgressChangedEventArgs e)
    {
        int num = smethod_0(0x3e8, 20, 10, 0x63, int.Parse(e.ProgressPercentage.ToString()));
        if (num >= 100)
        {
            num = 0x63;
        }
        if (num <= 10)
        {
            num = 10;
        }
        this.progressBar1.Value = num;
        this.label3.Text = "CPU Bench Score: " + e.ProgressPercentage.ToString() + " ms";
        if (this.progressBar1.Value >= 70)
        {
            label7.Text = "GUI thread: GOOD";
            label7.ForeColor = Color.Green;
        }
        else if ((this.progressBar1.Value > 0x45) || (this.progressBar1.Value < 40))
        {
            label7.Text = "GUI thread: BAD";
            label7.ForeColor = Color.DarkRed;
        }
        else
        {
            label7.Text = "GUI thread: OK";
            label7.ForeColor = Color.GreenYellow;
        }
    }

    private void method_14(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
        this.button1.Text = "Benchmark";
        this.Text = "Laptop Benchmark Tool";
        this.button1.Enabled = true;
        this.button2.Enabled = true;
    }

    private void method_15(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_16(object sender, ProgressChangedEventArgs e)
    {
        int num = smethod_0(0x3e8, 20, 10, 0x63, int.Parse(e.ProgressPercentage.ToString()));
        if (num >= 100)
        {
            num = 0x63;
        }
        if (num <= 10)
        {
            num = 10;
        }
        this.progressBar2.Value = num;
        if (this.progressBar2.Value >= 70)
        {
            label8.Text = "Emulator thread: GOOD";
            label8.ForeColor = Color.Green;
        }
        else if ((this.progressBar2.Value > 0x45) || (this.progressBar2.Value < 40))
        {
            label8.Text = "Emulator thread: BAD";
            label8.ForeColor = Color.DarkRed;
        }
        else
        {
            label8.Text = "Emulator thread: OK";
            label8.ForeColor = Color.GreenYellow;
        }
    }

    private void method_17(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
    }

    private void method_18(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_19(object sender, ProgressChangedEventArgs e)
    {
        int num = smethod_0(0x3e8, 20, 10, 0x63, int.Parse(e.ProgressPercentage.ToString()));
        if (num >= 100)
        {
            num = 0x63;
        }
        if (num <= 10)
        {
            num = 10;
        }
        this.progressBar3.Value = num;
        if (this.progressBar3.Value >= 70)
        {
            label9.Text = "Datalogging thread: GOOD";
            label9.ForeColor = Color.Green;
        }
        else if ((this.progressBar3.Value > 0x45) || (this.progressBar3.Value < 40))
        {
            label9.Text = "Datalogging thread: BAD";
            label9.ForeColor = Color.DarkRed;
        }
        else
        {
            label9.Text = "Datalogging thread: OK";
            label9.ForeColor = Color.GreenYellow;
        }
    }

    private void method_2()
    {
        this.button1.Text = "Working";
        this.button2.Enabled = false;
        this.button1.Enabled = false;
    }

    private void method_20(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
    }

    private void method_21(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_22(object sender, ProgressChangedEventArgs e)
    {
        int num = smethod_0(0x3e8, 20, 10, 0x63, int.Parse(e.ProgressPercentage.ToString()));
        if (num >= 100)
        {
            num = 0x63;
        }
        if (num <= 10)
        {
            num = 10;
        }
        this.progressBar4.Value = num;
        if (this.progressBar4.Value >= 70)
        {
            label10.Text = "Table Editing thread: GOOD";
            label10.ForeColor = Color.Green;
        }
        else if ((this.progressBar4.Value > 0x45) || (this.progressBar4.Value < 40))
        {
            label10.Text = "Table Editing thread: BAD";
            label10.ForeColor = Color.DarkRed;
        }
        else
        {
            label10.Text = "Table Editing thread: OK";
            label10.ForeColor = Color.GreenYellow;
        }
    }

    private void method_23(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
    }

    private void method_24(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_25(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
    }

    private void method_26(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_27(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
    }

    private void method_28(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_29(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
    }

    private void method_3()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_12);
        worker.ProgressChanged += new ProgressChangedEventHandler(this.method_13);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_14);
        worker.RunWorkerAsync();
    }

    private void method_30(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool flag = false;
        while (!flag)
        {
            this.long_0 += 1L;
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.method_11(this.int_1);
            stopwatch.Stop();
            worker.ReportProgress((int) stopwatch.ElapsedMilliseconds);
            this.long_1 = smethod_00(DateTime.Now);
            if (this.long_1 >= this.long_2)
            {
                flag = true;
            }
        }
    }

    private void method_31(object sender, RunWorkerCompletedEventArgs e)
    {
        this.label3.Text = "CPU Bench Score: " + this.long_0.ToString();
    }

    private void method_4()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_15);
        worker.ProgressChanged += new ProgressChangedEventHandler(this.method_16);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_17);
        worker.RunWorkerAsync();
    }

    private void method_5()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_18);
        worker.ProgressChanged += new ProgressChangedEventHandler(this.method_19);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_20);
        worker.RunWorkerAsync();
    }

    private void method_6()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_21);
        worker.ProgressChanged += new ProgressChangedEventHandler(this.method_22);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_23);
        worker.RunWorkerAsync();
    }

    private void method_7()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_24);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_25);
        worker.RunWorkerAsync();
    }

    private void method_8()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_26);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_27);
        worker.RunWorkerAsync();
    }

    private void method_9()
    {
        BackgroundWorker worker = new BackgroundWorker {
            WorkerReportsProgress = true
        };
        worker.DoWork += new DoWorkEventHandler(this.method_28);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_29);
        worker.RunWorkerAsync();
    }

    public int smethod_0(int int_3, int int_4, int int_5, int int_6, int int_7)
    {
        double num = ((double) (int_6 - int_5)) / ((double) (int_4 - int_3));
        return (int_5 + ((int) ((int_7 - int_3) * num)));
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams createParams = base.CreateParams;
            createParams.ClassStyle |= 0x200;
            return createParams;
        }
    }
}

