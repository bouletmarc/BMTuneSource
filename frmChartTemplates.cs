using Data;
using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmChartTemplates : Form
{
    private bool bool_0;
    private Button button_0;
    private Button button_1;
    private Button button_2;
    private Button button_3;
    private Button button_4;
    private ChartCollection chartCollection_0;
    private Class10_settings class10_settings_0;
    private Class18 class18_0;
    private ColorDialog colorDialog_0;
    private IContainer icontainer_0;
    private int int_0;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private ComboBox plot1;
    private ComboBox plot2;
    private ComboBox plot3;
    private ComboBox plot4;
    private ComboBox plot5;
    private Panel pnlGraphSetup;
    private TabControl tabGraphs;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private Label label1;
    private ComboBox comboBox1;
    private Button button1;
    private Button button2;
    private SaveFileDialog saveFileDialog1;
    private OpenFileDialog openFileDialog1;
    private TabPage tabPage4;
    private bool IsLoading = true;

    internal frmChartTemplates()
    {
        this.InitializeComponent();

    }

    private void button_4_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
            ((Button) sender).BackColor = this.colorDialog_0.Color;
    }

    public void ResetSelected()
    {
        try
        {
            this.tabGraphs.TabPages.Remove(this.tabPage2);
            this.tabGraphs.TabPages.Remove(this.tabPage3);
            this.tabGraphs.TabPages.Remove(this.tabPage4);

            this.chartCollection_0.getSelectedTemplate().ChartsEnable[1] = false;
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[2] = false;
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[3] = false;
        }
        catch { }

        if (comboBox1.SelectedIndex == 1)
        {
            this.tabGraphs.TabPages.Add(this.tabPage2);
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[1] = true;
        }
        if (comboBox1.SelectedIndex == 2)
        {
            this.tabGraphs.TabPages.Add(this.tabPage2);
            this.tabGraphs.TabPages.Add(this.tabPage3);
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[1] = true;
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[2] = true;
        }
        if (comboBox1.SelectedIndex == 3)
        {
            this.tabGraphs.TabPages.Add(this.tabPage2);
            this.tabGraphs.TabPages.Add(this.tabPage3);
            this.tabGraphs.TabPages.Add(this.tabPage4);
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[1] = true;
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[2] = true;
            this.chartCollection_0.getSelectedTemplate().ChartsEnable[3] = true;
        }
        if (this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0 != null)
        {
            if (this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0.ctrlLogGraph1 != null)
            {
                this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0.ctrlLogGraph1.ClearGraphStruct();
                this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0.ctrlLogGraph1.Refresh();
            }
        }
    }


    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsLoading) ResetSelected();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmChartTemplates_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.class18_0.method_155("Graph Presets Settings");
        this.method_3(this.tabGraphs.SelectedIndex);
        this.class10_settings_0.chartCollection_0 = this.chartCollection_0;
        this.chartCollection_0.throwEvent();
        if (this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0 != null)
        {
            if (this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0.ctrlLogGraph1 != null)
            {
                this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0.ctrlLogGraph1.ClearGraphStruct();
                this.class18_0.class17_0.frmMain_0.frmDatalogGraphs_0.ctrlLogGraph1.Refresh();
            }
        }
    }

    private void frmChartTemplates_Load(object sender, EventArgs e)
    {
        this.plot1.Items.Clear();
        this.plot1.Items.Add("");
        this.plot2.Items.Clear();
        this.plot2.Items.Add("");
        this.plot3.Items.Clear();
        this.plot3.Items.Add("");
        this.plot4.Items.Clear();
        this.plot4.Items.Add("");
        this.plot5.Items.Clear();
        this.plot5.Items.Add("");
        for (int i = 0; i < this.class10_settings_0.int_0; i++)
        {
            SensorsX sensors = (SensorsX) i;
            this.plot1.Items.Add(this.class10_settings_0.method_13(sensors));
            this.plot2.Items.Add(this.class10_settings_0.method_13(sensors));
            this.plot3.Items.Add(this.class10_settings_0.method_13(sensors));
            this.plot4.Items.Add(this.class10_settings_0.method_13(sensors));
            this.plot5.Items.Add(this.class10_settings_0.method_13(sensors));
        }
        this.method_4();
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChartTemplates));
            this.tabGraphs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlGraphSetup = new System.Windows.Forms.Panel();
            this.button_0 = new System.Windows.Forms.Button();
            this.button_1 = new System.Windows.Forms.Button();
            this.button_2 = new System.Windows.Forms.Button();
            this.button_3 = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.plot5 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.plot4 = new System.Windows.Forms.ComboBox();
            this.plot3 = new System.Windows.Forms.ComboBox();
            this.plot2 = new System.Windows.Forms.ComboBox();
            this.plot1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.colorDialog_0 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabGraphs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlGraphSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGraphs
            // 
            this.tabGraphs.Controls.Add(this.tabPage1);
            this.tabGraphs.Location = new System.Drawing.Point(14, 76);
            this.tabGraphs.Name = "tabGraphs";
            this.tabGraphs.SelectedIndex = 0;
            this.tabGraphs.Size = new System.Drawing.Size(253, 180);
            this.tabGraphs.TabIndex = 2;
            this.tabGraphs.SelectedIndexChanged += new System.EventHandler(this.tabGraphs_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlGraphSetup);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(245, 153);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graph 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlGraphSetup
            // 
            this.pnlGraphSetup.Controls.Add(this.button_0);
            this.pnlGraphSetup.Controls.Add(this.button_1);
            this.pnlGraphSetup.Controls.Add(this.button_2);
            this.pnlGraphSetup.Controls.Add(this.button_3);
            this.pnlGraphSetup.Controls.Add(this.button_4);
            this.pnlGraphSetup.Controls.Add(this.plot5);
            this.pnlGraphSetup.Controls.Add(this.label9);
            this.pnlGraphSetup.Controls.Add(this.plot4);
            this.pnlGraphSetup.Controls.Add(this.plot3);
            this.pnlGraphSetup.Controls.Add(this.plot2);
            this.pnlGraphSetup.Controls.Add(this.plot1);
            this.pnlGraphSetup.Controls.Add(this.label8);
            this.pnlGraphSetup.Controls.Add(this.label7);
            this.pnlGraphSetup.Controls.Add(this.label6);
            this.pnlGraphSetup.Controls.Add(this.label5);
            this.pnlGraphSetup.Location = new System.Drawing.Point(0, 0);
            this.pnlGraphSetup.Name = "pnlGraphSetup";
            this.pnlGraphSetup.Size = new System.Drawing.Size(244, 152);
            this.pnlGraphSetup.TabIndex = 1;
            // 
            // button_0
            // 
            this.button_0.Location = new System.Drawing.Point(210, 122);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(24, 23);
            this.button_0.TabIndex = 20;
            this.button_0.UseVisualStyleBackColor = true;
            this.button_0.Click += new System.EventHandler(this.button_4_Click);
            // 
            // button_1
            // 
            this.button_1.Location = new System.Drawing.Point(210, 94);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(24, 23);
            this.button_1.TabIndex = 19;
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.Click += new System.EventHandler(this.button_4_Click);
            // 
            // button_2
            // 
            this.button_2.Location = new System.Drawing.Point(210, 65);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(24, 23);
            this.button_2.TabIndex = 18;
            this.button_2.UseVisualStyleBackColor = true;
            this.button_2.Click += new System.EventHandler(this.button_4_Click);
            // 
            // button_3
            // 
            this.button_3.Location = new System.Drawing.Point(210, 36);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(24, 23);
            this.button_3.TabIndex = 17;
            this.button_3.UseVisualStyleBackColor = true;
            this.button_3.Click += new System.EventHandler(this.button_4_Click);
            // 
            // button_4
            // 
            this.button_4.Location = new System.Drawing.Point(210, 6);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(24, 23);
            this.button_4.TabIndex = 16;
            this.button_4.UseVisualStyleBackColor = true;
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // plot5
            // 
            this.plot5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plot5.FormattingEnabled = true;
            this.plot5.Location = new System.Drawing.Point(63, 122);
            this.plot5.Name = "plot5";
            this.plot5.Size = new System.Drawing.Size(139, 22);
            this.plot5.TabIndex = 15;
            this.plot5.SelectedIndexChanged += new System.EventHandler(this.plot1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 14);
            this.label9.TabIndex = 14;
            this.label9.Text = "Value5:";
            // 
            // plot4
            // 
            this.plot4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plot4.FormattingEnabled = true;
            this.plot4.Location = new System.Drawing.Point(63, 94);
            this.plot4.Name = "plot4";
            this.plot4.Size = new System.Drawing.Size(139, 22);
            this.plot4.TabIndex = 8;
            this.plot4.SelectedIndexChanged += new System.EventHandler(this.plot1_SelectedIndexChanged);
            // 
            // plot3
            // 
            this.plot3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plot3.FormattingEnabled = true;
            this.plot3.Location = new System.Drawing.Point(63, 65);
            this.plot3.Name = "plot3";
            this.plot3.Size = new System.Drawing.Size(139, 22);
            this.plot3.TabIndex = 7;
            this.plot3.SelectedIndexChanged += new System.EventHandler(this.plot1_SelectedIndexChanged);
            // 
            // plot2
            // 
            this.plot2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plot2.FormattingEnabled = true;
            this.plot2.Location = new System.Drawing.Point(63, 36);
            this.plot2.Name = "plot2";
            this.plot2.Size = new System.Drawing.Size(139, 22);
            this.plot2.TabIndex = 6;
            this.plot2.SelectedIndexChanged += new System.EventHandler(this.plot1_SelectedIndexChanged);
            // 
            // plot1
            // 
            this.plot1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plot1.FormattingEnabled = true;
            this.plot1.Location = new System.Drawing.Point(63, 6);
            this.plot1.Name = "plot1";
            this.plot1.Size = new System.Drawing.Size(139, 22);
            this.plot1.TabIndex = 5;
            this.plot1.SelectedIndexChanged += new System.EventHandler(this.plot1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 4;
            this.label8.Text = "Value4:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Value3:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "Value2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Value1:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(243, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graph 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(243, 203);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Graph 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(243, 203);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Graph 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // colorDialog_0
            // 
            this.colorDialog_0.SolidColorOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Graphs:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(162, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(69, 22);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bmg";
            this.saveFileDialog1.Filter = "BMTune Graph|*.bmg";
            this.saveFileDialog1.Title = "Save BMTune Graph Settings";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bmg";
            this.openFileDialog1.Filter = "BMTune Graph|*.bmg";
            this.openFileDialog1.Title = "Open BMTune Graph Settings";
            // 
            // frmChartTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 263);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabGraphs);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChartTemplates";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Graph Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChartTemplates_FormClosing);
            this.Load += new System.EventHandler(this.frmChartTemplates_Load);
            this.tabGraphs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlGraphSetup.ResumeLayout(false);
            this.pnlGraphSetup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1)
    {
        this.class10_settings_0 = class10_1;
        this.class18_0 = class18_1;
        this.chartCollection_0 = this.class10_settings_0.chartCollection_0;
        this.bool_0 = true;
        this.bool_0 = false;
        this.chartCollection_0.templateChangedDelegate_0 += new ChartCollection.templateChangedDelegate(this.method_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1()
    {
        this.method_4();
    }

    private void method_3(int int_1)
    {
        this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[0] = this.plot1.SelectedIndex != 0;
        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[0])
        {
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].Sensors_0[0] = (SensorsX) (this.plot1.SelectedIndex - 1);
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].colors[0] = this.button_4.BackColor;
        }
        this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[1] = this.plot2.SelectedIndex != 0;
        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[1])
        {
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].Sensors_0[1] = (SensorsX) (this.plot2.SelectedIndex - 1);
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].colors[1] = this.button_3.BackColor;
        }
        this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[2] = this.plot3.SelectedIndex != 0;
        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[2])
        {
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].Sensors_0[2] = (SensorsX) (this.plot3.SelectedIndex - 1);
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].colors[2] = this.button_2.BackColor;
        }
        this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[3] = this.plot4.SelectedIndex != 0;
        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[3])
        {
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].Sensors_0[3] = (SensorsX) (this.plot4.SelectedIndex - 1);
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].colors[3] = this.button_1.BackColor;
        }
        this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[4] = this.plot5.SelectedIndex != 0;
        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].plotLinesEnable[4])
        {
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].Sensors_0[4] = (SensorsX) (this.plot5.SelectedIndex - 1);
            this.chartCollection_0.getSelectedTemplate().ChartSetup[int_1].colors[4] = this.button_0.BackColor;
        }
    }

    private void method_4()
    {
        LoadTabs(0);

        IsLoading = false;

        int Index = 0;
        if (this.chartCollection_0.getSelectedTemplate().ChartsEnable[1]) Index = 1;
        if (this.chartCollection_0.getSelectedTemplate().ChartsEnable[2]) Index = 2;
        if (this.chartCollection_0.getSelectedTemplate().ChartsEnable[3]) Index = 3;
        this.comboBox1.SelectedIndex = Index;
    }

    private void LoadTabs(int selectedIndex)
    {
        this.button_4.BackColor = this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].colors[0];
        this.button_3.BackColor = this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].colors[1];
        this.button_2.BackColor = this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].colors[2];
        this.button_1.BackColor = this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].colors[3];
        this.button_0.BackColor = this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].colors[4];

        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].plotLinesEnable[0]) this.plot1.SelectedIndex = ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].Sensors_0[0]) + 1;
        else this.plot1.SelectedIndex = 0;

        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].plotLinesEnable[1]) this.plot2.SelectedIndex = ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].Sensors_0[1]) + 1;
        else this.plot2.SelectedIndex = 0;

        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].plotLinesEnable[2]) this.plot3.SelectedIndex = ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].Sensors_0[2]) + 1;
        else this.plot3.SelectedIndex = 0;

        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].plotLinesEnable[3]) this.plot4.SelectedIndex = ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].Sensors_0[3]) + 1;
        else this.plot4.SelectedIndex = 0;

        if (this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].plotLinesEnable[4]) this.plot5.SelectedIndex = ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[selectedIndex].Sensors_0[4]) + 1;
        else this.plot5.SelectedIndex = 0;
    }

    private void plot1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox[] boxArray = new ComboBox[] { this.plot1, this.plot2, this.plot3, this.plot4, this.plot5 };
        for (int i = 0; i < boxArray.Length; i++)
        {
            if (boxArray[i].SelectedIndex != 0)
            {
                for (int j = 0; j < boxArray.Length; j++)
                {
                    if ((boxArray[i].SelectedIndex == boxArray[j].SelectedIndex) && (i != j))
                    {
                        boxArray[j].SelectedIndex = 0;
                    }
                }
            }
            if (((boxArray[i].SelectedIndex == 0) && (boxArray[0].SelectedIndex != 0)) && ((i < (boxArray.Length - 1)) && (boxArray[i + 1].SelectedIndex != 0)))
            {
                boxArray[i].SelectedIndex = boxArray[i + 1].SelectedIndex;
            }
        }
    }

    private void tabGraphs_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedIndex = this.tabGraphs.SelectedIndex;
        this.tabGraphs.TabPages[this.tabGraphs.SelectedIndex].Controls.Clear();
        this.tabGraphs.TabPages[this.tabGraphs.SelectedIndex].Controls.Add(this.pnlGraphSetup);
        if (this.int_0 != -1) this.method_3(this.int_0);
        LoadTabs(selectedIndex);
        
        this.int_0 = this.tabGraphs.SelectedIndex;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult result = saveFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            SaveSet(saveFileDialog1.FileName);
        }
    }

    public void SaveSet(string TPath)
    {
        try
        {
            string Line = "";
            Line += comboBox1.SelectedIndex + Environment.NewLine;

            for (int i = 0; i < (comboBox1.SelectedIndex + 1); i++)
            {
                if (this.chartCollection_0.getSelectedTemplate().ChartSetup[i].plotLinesEnable[0])
                    Line += "0#" + i + "#" + this.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[0].ToArgb().ToString() + "#" + ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[0]) + Environment.NewLine;
                else Line += "0#" + i + "#Disabled" + Environment.NewLine;

                if (this.chartCollection_0.getSelectedTemplate().ChartSetup[i].plotLinesEnable[1])
                    Line += "1#" + i + "#" + this.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[1].ToArgb().ToString() + "#" + ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[1]) + Environment.NewLine;
                else Line += "1#" + i + "#Disabled" + Environment.NewLine;

                if (this.chartCollection_0.getSelectedTemplate().ChartSetup[i].plotLinesEnable[2])
                    Line += "2#" + i + "#" + this.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[2].ToArgb().ToString() + "#" + ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[2]) + Environment.NewLine;
                else Line += "2#" + i + "#Disabled" + Environment.NewLine;

                if (this.chartCollection_0.getSelectedTemplate().ChartSetup[i].plotLinesEnable[3])
                    Line += "3#" + i + "#" + this.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[3].ToArgb().ToString() + "#" + ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[3]) + Environment.NewLine;
                else Line += "3#" + i + "#Disabled" + Environment.NewLine;

                if (this.chartCollection_0.getSelectedTemplate().ChartSetup[i].plotLinesEnable[4])
                    Line += "4#" + i + "#" + this.chartCollection_0.getSelectedTemplate().ChartSetup[i].colors[4].ToArgb().ToString() + "#" + ((int)this.chartCollection_0.getSelectedTemplate().ChartSetup[i].Sensors_0[4]) + Environment.NewLine;
                else Line += "4#" + i + "#Disabled" + Environment.NewLine;
            }

            StreamWriter writer = new StreamWriter(TPath, false);
            writer.Write(Line);
            writer.Close();
            writer.Dispose();
            writer = null;
        }
        catch (Exception Message)
        {
            MessageBox.Show(Form.ActiveForm, "Unable to save graph settings!\n" + Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    public void LoadSet(string TPath)
    {
        try
        {
            string[] AllLines = File.ReadAllLines(TPath);
            comboBox1.SelectedIndex = int.Parse(AllLines[0]);
            for (int i = 0; i < AllLines.Length - 2; i++)
            {
                string[] SeparetedLines = AllLines[i + 1].Split('#');
                if (SeparetedLines[2] != "Disabled")
                {
                    this.chartCollection_0.getSelectedTemplate().ChartSetup[int.Parse(SeparetedLines[1])].plotLinesEnable[int.Parse(SeparetedLines[0])] = true;
                    this.chartCollection_0.getSelectedTemplate().ChartSetup[int.Parse(SeparetedLines[1])].colors[int.Parse(SeparetedLines[0])] = Color.FromArgb((Int32)Convert.ToInt32(SeparetedLines[2]));
                    this.chartCollection_0.getSelectedTemplate().ChartSetup[int.Parse(SeparetedLines[1])].Sensors_0[int.Parse(SeparetedLines[0])] = (SensorsX)int.Parse(SeparetedLines[3]);
                }
                else
                {
                    this.chartCollection_0.getSelectedTemplate().ChartSetup[int.Parse(SeparetedLines[1])].plotLinesEnable[int.Parse(SeparetedLines[0])] = false;
                    this.chartCollection_0.getSelectedTemplate().ChartSetup[int.Parse(SeparetedLines[1])].colors[int.Parse(SeparetedLines[0])] = Color.Transparent;
                    this.chartCollection_0.getSelectedTemplate().ChartSetup[int.Parse(SeparetedLines[1])].Sensors_0[int.Parse(SeparetedLines[0])] = 0;
                }
            }
            LoadTabs(this.tabGraphs.SelectedIndex);
        }
        catch (Exception Message)
        {
            MessageBox.Show(Form.ActiveForm, "Unable to open graph settings!\n" + Message, "BMTune", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK) LoadSet(openFileDialog1.FileName);
    }
}

