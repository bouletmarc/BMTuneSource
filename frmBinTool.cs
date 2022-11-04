using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class frmBinTool : Form
{
    public FileStream fs;
    private Class10_settings class10_settings_0;
    private Class18 class18_0;
    private IContainer components;
    private Label label2;
    private Label label3;
    private TextBox textBox2;
    private TextBox textBox3;
    private Button button2;
    private Button button3;
    private Button button5;
    private OpenFileDialog openFileDialog1;
    private Button button1;
    private Label label1;

    internal frmBinTool(ref Class10_settings cfg, ref Class18 class18_1)
    {
        this.class10_settings_0 = cfg;
        this.class18_0 = class18_1;
        this.InitializeComponent();

        /*foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }*/
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.textBox2.Text = "BLANK";
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if ((this.openFileDialog1.ShowDialog() == DialogResult.OK) && ((this.openFileDialog1.FileName != "openFileDialog1") || (this.openFileDialog1.FileName != "")))
            {
                this.textBox3.Text = this.openFileDialog1.FileName;
                this.fs = new FileStream(this.textBox3.Text, FileMode.Open, FileAccess.Read);
                if (((int) this.fs.Length) == 0x8000)
                {
                    string fileName = Path.GetFileName(this.textBox3.Text);
                }
                else
                {
                    MessageBox.Show(Form.ActiveForm, "invalid file size");
                    this.textBox3.Text = "";
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, "EXCEPTION:" + exception);
        }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            if ((this.openFileDialog1.ShowDialog() == DialogResult.OK) && ((this.openFileDialog1.FileName != "openFileDialog1") || (this.openFileDialog1.FileName != "")))
            {
                this.textBox2.Text = this.openFileDialog1.FileName;
                this.fs = new FileStream(this.textBox2.Text, FileMode.Open, FileAccess.Read);
                if (((int) this.fs.Length) == 0x8000)
                {
                    string fileName = Path.GetFileName(this.textBox2.Text);
                }
                else
                {
                    MessageBox.Show(Form.ActiveForm, "invalid file size");
                    this.textBox2.Text = "";
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, "EXCEPTION:" + exception);
        }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
        if ((this.textBox2.Text == "") || (this.textBox3.Text == ""))
        {
            MessageBox.Show(Form.ActiveForm, "Select MAP 1 and MAP 2 to fill the bin file.", "Error");
        }
        else
        {
            string[] tmpfiles = new string[] { this.textBox2.Text, this.textBox3.Text };
            if (this.MergeFile(tmpfiles))
            {
                MessageBox.Show(Form.ActiveForm, "File Saved!", "Warning");
            }
            else
            {
                MessageBox.Show(Form.ActiveForm, "Error Saving File!", "Error");
            }
        }
    }

    public static byte[] Combine(byte[] first, byte[] second)
    {
        byte[] dst = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, dst, 0, first.Length);
        Buffer.BlockCopy(second, 0, dst, first.Length, second.Length);
        return dst;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void FrmBinTool_Load(object sender, EventArgs e)
    {
        if (this.class18_0.method_25_GetFilename() != null)
        {
            this.textBox3.Text = this.class10_settings_0.romFilePath + @"\" + Path.GetFileName(this.class18_0.method_25_GetFilename());
        }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBinTool));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MAP 1: 0000-7FFFF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "MAP 2: 80000-FFFFF:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(33, 29);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(184, 29);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(146, 20);
            this.textBox3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 22);
            this.button2.TabIndex = 7;
            this.button2.Text = "Select File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 53);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 22);
            this.button3.TabIndex = 8;
            this.button3.Text = "Select File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(33, 105);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(296, 47);
            this.button5.TabIndex = 10;
            this.button5.Text = "Save/Create Bin File";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(106, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 22);
            this.button1.TabIndex = 11;
            this.button1.Text = "Unload Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "Note:\nBy default the ecu will read a 512k bin from the 8000-FFFF Zone.\nUsing a ma" +
    "p switcher device you can read 0000-7FFFF Zone.";
            // 
            // frmBinTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBinTool";
            this.Text = "Create 2Timer Bin (512kb file)";
            this.Load += new System.EventHandler(this.FrmBinTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    public bool MergeFile(string[] tmpfiles)
    {
        bool flag = false;
        try
        {
            if (tmpfiles[0] == "BLANK")
            {
                tmpfiles[0] = "tempblank.bin";
                File.WriteAllBytes(tmpfiles[0], new byte[0x8000]);
            }
            FileStream stream = new FileStream(tmpfiles[0], FileMode.Open, FileAccess.Read);
            if (!stream.CanRead)
            {
                MessageBox.Show(Form.ActiveForm, "Couldnt open Section 0000-7fff.");
                flag = false;
            }
            else
            {
                int length = (int) stream.Length;
                byte[] buffer = new byte[length];
                stream.Read(buffer, 0, length);
                FileStream stream2 = new FileStream(tmpfiles[1], FileMode.Open, FileAccess.Read);
                if (!stream2.CanRead)
                {
                    MessageBox.Show(Form.ActiveForm, "Couldnt open Section 8000-ffff.");
                    flag = false;
                }
                else
                {
                    int count = (int) stream2.Length;
                    byte[] buffer2 = new byte[count];
                    stream2.Read(buffer2, 0, count);
                    SaveFileDialog dialog = new SaveFileDialog {
                        Filter = "Bin|*.bin",
                        Title = "Save an 512K Bin File"
                    };
                    dialog.ShowDialog();
                    if ((dialog.FileName != "") && ((length + count) == 0x10000))
                    {
                        using (FileStream stream3 = new FileStream(dialog.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                        {
                            using (BinaryWriter writer = new BinaryWriter(stream3))
                            {
                                writer.Write(Combine(buffer, buffer2));
                                return true;
                            }
                        }
                    }
                    MessageBox.Show(Form.ActiveForm, "Something went wrong, Resulting file wouldn't of been 65536 bytes!", "Error");
                    flag = false;
                }
            }
        }
        catch
        {
            flag = false;
        }
        return flag;
    }
}

