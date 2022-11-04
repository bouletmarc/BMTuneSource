using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmSensorSetup : Form
{
    private Button btnSave;
    private Class10_settings class10_settings_0;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private DataGridView grid;
    private IContainer icontainer_0;
    private int int_0;
    private Label label3;
    private Label label4;
    private ToolTip toolTip_0;
    private TextBox txtbWarnMax;
    private DataGridViewTextBoxColumn Column2;
    private IContainer components;
    private TextBox txtbWarnMin;
    private Label label2;
    private Label label5;
    private TextBox txtbValueMax;
    private TextBox txtbValueMin;
    private Label label6;
    private Label label1;
    private List<int> IndexList;

    internal frmSensorSetup()
    {
        this.InitializeComponent();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        this.method_2();
    }

    private void cmbUnit_Leave(object sender, EventArgs e)
    {
        this.method_2();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmSensorSetup_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void frmSensorSetup_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.method_2();
        this.class10_settings_0.method_15();
    }

    private void frmSensorSetup_Load(object sender, EventArgs e)
    {
        this.IndexList = new List<int>();
        for (int i=0; i < this.class10_settings_0.int_0; i++)
        {
            //if (Class19_u.smethod_0((Sensors)i))
            //{
                this.grid.Rows.Add();
                this.IndexList.Add(i);
            //}
        }
        for (int i = 0; i < this.grid.Rows.Count; i++)
        {
            this.grid.Rows[i].Height = 0x12;
        }
        this.grid.CellValueNeeded += new DataGridViewCellValueEventHandler(this.grid_CellValueNeeded);
    }

    private void grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        /*if (e.ColumnIndex == 0)
        {
            e.Value = ((Sensors) e.RowIndex).ToString();
        }
        else if (e.ColumnIndex == 1)
        {*/
        e.Value = this.class10_settings_0.method_13((SensorsX) this.IndexList[e.RowIndex]);
        /*}
        else if (e.ColumnIndex == 2)
        {
            e.Value = this.class10_0.method_16((Sensors) e.RowIndex);
        }*/
    }

    private void grid_SelectionChanged(object sender, EventArgs e)
    {
        if (this.int_0 != this.grid.CurrentCell.RowIndex)
        {
            this.method_2();
        }
        this.method_1();
        this.int_0 = this.grid.CurrentCell.RowIndex;
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSensorSetup));
            this.grid = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbWarnMax = new System.Windows.Forms.TextBox();
            this.txtbWarnMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtbValueMax = new System.Windows.Forms.TextBox();
            this.txtbValueMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.ColumnHeadersVisible = false;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.GridColor = System.Drawing.Color.Black;
            this.grid.Location = new System.Drawing.Point(14, 9);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(149, 219);
            this.grid.TabIndex = 0;
            this.grid.VirtualMode = true;
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // Column2
            // 
            this.Column2.FillWeight = 122F;
            this.Column2.HeaderText = "Display Name";
            this.Column2.Name = "Column2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "Max:";
            this.toolTip_0.SetToolTip(this.label4, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            // 
            // txtbWarnMax
            // 
            this.txtbWarnMax.Location = new System.Drawing.Point(209, 55);
            this.txtbWarnMax.Name = "txtbWarnMax";
            this.txtbWarnMax.Size = new System.Drawing.Size(75, 20);
            this.txtbWarnMax.TabIndex = 22;
            this.toolTip_0.SetToolTip(this.txtbWarnMax, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            this.txtbWarnMax.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            this.txtbWarnMax.Validated += new System.EventHandler(this.TxtbWarnMin_Validated);
            // 
            // txtbWarnMin
            // 
            this.txtbWarnMin.Location = new System.Drawing.Point(209, 29);
            this.txtbWarnMin.Name = "txtbWarnMin";
            this.txtbWarnMin.Size = new System.Drawing.Size(75, 20);
            this.txtbWarnMin.TabIndex = 21;
            this.toolTip_0.SetToolTip(this.txtbWarnMin, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            this.txtbWarnMin.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            this.txtbWarnMin.Validated += new System.EventHandler(this.TxtbWarnMin_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "Warnings";
            this.toolTip_0.SetToolTip(this.label3, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(174, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 25);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 28;
            this.label5.Text = "Max:";
            this.toolTip_0.SetToolTip(this.label5, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            // 
            // txtbValueMax
            // 
            this.txtbValueMax.Location = new System.Drawing.Point(209, 138);
            this.txtbValueMax.Name = "txtbValueMax";
            this.txtbValueMax.Size = new System.Drawing.Size(75, 20);
            this.txtbValueMax.TabIndex = 27;
            this.toolTip_0.SetToolTip(this.txtbValueMax, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            this.txtbValueMax.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            this.txtbValueMax.Validated += new System.EventHandler(this.TxtbWarnMin_Validated);
            // 
            // txtbValueMin
            // 
            this.txtbValueMin.Location = new System.Drawing.Point(209, 112);
            this.txtbValueMin.Name = "txtbValueMin";
            this.txtbValueMin.Size = new System.Drawing.Size(75, 20);
            this.txtbValueMin.TabIndex = 26;
            this.toolTip_0.SetToolTip(this.txtbValueMin, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            this.txtbValueMin.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            this.txtbValueMin.Validated += new System.EventHandler(this.TxtbWarnMin_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "Value Range";
            this.toolTip_0.SetToolTip(this.label6, "Warning min from this value the background of the cell\r\nwill become orange and wi" +
        "ll be red when warning max is reached.");
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "Min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "Min:";
            // 
            // frmSensorSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSave;
            this.ClientSize = new System.Drawing.Size(292, 241);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbValueMax);
            this.Controls.Add(this.txtbValueMin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbWarnMax);
            this.Controls.Add(this.txtbWarnMin);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSensorSetup";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Warning Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSensorSetup_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSensorSetup_FormClosed);
            this.Load += new System.EventHandler(this.frmSensorSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_0(ref Class18 class18_1, ref Class10_settings class10_1)
    {
        this.class10_settings_0 = class10_1;
        this.class18_0 = class18_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1()
    {
        //if (Class19.smethod_0((Sensors) this.grid.CurrentCell.RowIndex))
        //{
        //this.txtbWarnMin.Enabled = true;
        //this.txtbWarnMax.Enabled = true;
        try
        {
            this.txtbWarnMin.Text = this.class10_settings_0.method_20((SensorsX)this.IndexList[this.grid.CurrentCell.RowIndex]).ToString();
            this.txtbWarnMax.Text = this.class10_settings_0.method_22((SensorsX)this.IndexList[this.grid.CurrentCell.RowIndex]).ToString();
            this.txtbValueMin.Text = this.class10_settings_0.method_20_Min((SensorsX)this.IndexList[this.grid.CurrentCell.RowIndex]).ToString();
            this.txtbValueMax.Text = this.class10_settings_0.method_22_Max((SensorsX)this.IndexList[this.grid.CurrentCell.RowIndex]).ToString();
        }
        catch { }
        //}
    }

    private void method_2()
    {
        this.class18_0.method_155("Sensor Settings");
        if ((this.txtbWarnMax.Text != string.Empty) && (this.txtbWarnMin.Text != string.Empty))
        {
            this.class10_settings_0.method_21((SensorsX)this.IndexList[this.int_0], int.Parse(this.txtbWarnMin.Text));
            this.class10_settings_0.method_23((SensorsX)this.IndexList[this.int_0], int.Parse(this.txtbWarnMax.Text));
        }
        if ((this.txtbValueMin.Text != string.Empty) && (this.txtbValueMax.Text != string.Empty))
        {
            this.class10_settings_0.method_21_Min((SensorsX)this.IndexList[this.int_0], int.Parse(this.txtbValueMin.Text));
            this.class10_settings_0.method_23_Max((SensorsX)this.IndexList[this.int_0], int.Parse(this.txtbValueMax.Text));
        }
    }

    private void textBox2_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void TxtbWarnMin_Validated(object sender, EventArgs e)
    {
        this.method_2();
    }
}

