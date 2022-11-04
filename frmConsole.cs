using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

internal class frmConsole : Form
{
    private Class18 class18_0;
    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    private IContainer components;
    public Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Label label8;
    private Label label9;
    private Label label10;
    private ListBox cmd_List;
    private TextBox txt_Logs;
    private Label label11;
    private Label label12;
    private TextBox textBox1;

    internal frmConsole(ref FrmMain frmMain_1, ref Class18 class18_1)
    {
        this.InitializeComponent();

        frmMain_0 = frmMain_1;
        class18_0 = class18_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
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

    private void frmDebug_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.frmMain_0.frmConsole_0.Dispose();
        this.frmMain_0.frmConsole_0 = null;
    }

    private void frmDebug_Load(object sender, EventArgs e)
    {
        
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsole));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmd_List = new System.Windows.Forms.ListBox();
            this.txt_Logs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(226, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Commands List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rom_Location=Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(79, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "**Add 0x for values in HEX**";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(113, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "0x5F26=0xFF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(213, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "16768=0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Exemples:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Set Rom Byte:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(2, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 25);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(2, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(149, 55);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(150, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(149, 55);
            this.panel3.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Cmd Description:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Cmd Writing:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(105, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 24);
            this.label10.TabIndex = 15;
            this.label10.Text = "Console";
            // 
            // cmd_List
            // 
            this.cmd_List.FormattingEnabled = true;
            this.cmd_List.Location = new System.Drawing.Point(1, 226);
            this.cmd_List.Name = "cmd_List";
            this.cmd_List.Size = new System.Drawing.Size(298, 108);
            this.cmd_List.TabIndex = 16;
            this.cmd_List.SelectedIndexChanged += new System.EventHandler(this.Cmd_List_SelectedIndexChanged);
            // 
            // txt_Logs
            // 
            this.txt_Logs.Location = new System.Drawing.Point(1, 340);
            this.txt_Logs.Multiline = true;
            this.txt_Logs.Name = "txt_Logs";
            this.txt_Logs.ReadOnly = true;
            this.txt_Logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Logs.Size = new System.Drawing.Size(298, 163);
            this.txt_Logs.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Get Rom Byte:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(7, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Rom_Location";
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 506);
            this.Controls.Add(this.txt_Logs);
            this.Controls.Add(this.cmd_List);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConsole";
            this.Text = "Developper Console";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDebug_FormClosed);
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void button1_Click(object sender, EventArgs e)
    {
        string CMDString = textBox1.Text;
        textBox1.Text = "";
        cmd_List.Items.Add(CMDString);
        if (CMDString.Length > 0)
        {
            //set bytes
            if (CMDString.Contains("="))
            {
                string[] CMDS = CMDString.Split('=');
                if (CMDS.Length == 2)
                {
                    if (CMDS[0] != "" && CMDS[1] != "")
                    {
                        try
                        {
                            long Location = 0;
                            int ByteN = 0;
                            if (CMDS[0].Contains("0x") || CMDS[0].Contains("0X"))
                            {
                                CMDS[0] = CMDS[0].Substring(2);
                                Location = long.Parse(CMDS[0], System.Globalization.NumberStyles.HexNumber);
                            }
                            else Location = long.Parse(CMDS[0]);

                            if (CMDS[1].Contains("0x") || CMDS[0].Contains("0X"))
                            {
                                CMDS[1] = CMDS[1].Substring(2);
                                ByteN = int.Parse(CMDS[1], System.Globalization.NumberStyles.HexNumber);
                            }
                            else ByteN = int.Parse(CMDS[1]);

                            this.class18_0.SetByteAt(Location, (byte) ByteN);

                            this.txt_Logs.AppendText("SetByte: 0x" + Location.ToString("X4") + "=" + "0x" + ByteN.ToString("X2") + "            " + Location + "=" + ((int)ByteN).ToString() + Environment.NewLine);
                        }
                        catch { }
                    }
                }
            }
            else
            {
                //get byte
                if (CMDString != "")
                {
                    try
                    {
                        long Location = 0;
                        int ByteN = 0;
                        if (CMDString.Contains("0x") || CMDString.Contains("0X"))
                        {
                            CMDString = CMDString.Substring(2);
                            Location = long.Parse(CMDString, System.Globalization.NumberStyles.HexNumber);
                        }
                        else Location = long.Parse(CMDString);

                        this.class18_0.GetByteAt(Location);
                        this.txt_Logs.AppendText("GetByte: 0x" + Location.ToString("X4") + "=" + "0x" + this.class18_0.GetByteAt(Location).ToString("X2") + "            " + Location + "=" + ((int) this.class18_0.GetByteAt(Location)).ToString() + Environment.NewLine);
                    }
                    catch { }
                }
            }
        }
    }

    private void Cmd_List_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmd_List.SelectedIndex >= 0)
        {
            textBox1.Text = cmd_List.Items[cmd_List.SelectedIndex].ToString();
        }
    }
}

