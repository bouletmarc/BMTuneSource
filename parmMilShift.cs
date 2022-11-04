using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmMilShift : UserControl
{
    private bool bool_0;
    private CheckBox chkEnable;
    private CheckBox chkGear;
    private Class18 class18_0;
    private ctrlAdvTable ctrlAdvTable;
    private ErrorProvider errorProvider_0;
    private GroupBox groupBox1;
    private GroupBox grpSettings;
    private IContainer icontainer_0;
    private Label label1;
    private IContainer components;
    private Label label5;
    private Label label3;
    private NumericUpDown txtbRpm;
    private Panel panel1;

    internal parmMilShift(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.InitializeComponent();
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_3);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_3);
        this.ctrlAdvTable.method_ColumnsNumber(5);
        this.ctrlAdvTable.method_HeaderGrayed(true);
        this.ctrlAdvTable.method_RowsNumber(2);
        this.ctrlAdvTable.method_HasHeader(false);
        this.ctrlAdvTable.int_2 = 40;
        this.ctrlAdvTable.method_1(ref this.class18_0);
        this.ctrlAdvTable.delegate4_0 += new ctrlAdvTable.Delegate4(this.method_2);
        this.ctrlAdvTable.delegate2_0 += new ctrlAdvTable.Delegate2(this.method_1);
        this.ctrlAdvTable.delegate1_0 += new ctrlAdvTable.Delegate1(this.method_0);
        this.ctrlAdvTable.method_Load();


        this.grpSettings.Enabled = true;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.bool_0)
        {
            if (this.chkGear.Checked)
            {
                this.ctrlAdvTable.Enabled = true;
            }
            else
            {
                this.ctrlAdvTable.Enabled = false;
            }
            if (this.chkGear.Checked && this.chkEnable.Checked)
            {
                this.txtbRpm.Enabled = false;
            }
            else if (this.chkGear.Checked && !this.chkEnable.Checked)
            {
                this.txtbRpm.Enabled = false;
            }
            else if (!this.chkGear.Checked && this.chkEnable.Checked)
            {
                this.txtbRpm.Enabled = true;
            }
            else if (!this.chkGear.Checked && !this.chkEnable.Checked)
            {
                this.txtbRpm.Enabled = false;
            }
            if (this.chkEnable.Checked)
            {
                this.chkGear.Enabled = true;
            }
            else
            {
                this.chkGear.Enabled = false;
            }
            this.method_4();
            this.parmMilShift_Load(null, null);
        }
    }

    private void chkGear_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkGear.Checked)
        {
            this.ctrlAdvTable.Enabled = true;
            this.txtbRpm.Enabled = false;
        }
        else
        {
            this.ctrlAdvTable.Enabled = false;
            this.txtbRpm.Enabled = true;
        }
        if (!this.bool_0)
        {
            this.method_4();
            this.parmMilShift_Load(null, null);
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

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbRpm = new System.Windows.Forms.NumericUpDown();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlAdvTable = new ctrlAdvTable();
            this.chkGear = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).BeginInit();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbRpm);
            this.groupBox1.Controls.Add(this.grpSettings);
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MIL Shiftlight";
            // 
            // txtbRpm
            // 
            this.txtbRpm.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtbRpm.Location = new System.Drawing.Point(90, 52);
            this.txtbRpm.Maximum = new decimal(new int[] {
            11050,
            0,
            0,
            0});
            this.txtbRpm.Name = "txtbRpm";
            this.txtbRpm.Size = new System.Drawing.Size(64, 20);
            this.txtbRpm.TabIndex = 3;
            this.txtbRpm.Click += new System.EventHandler(this.txtbRpm_Validated);
            this.txtbRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbRpm_KeyPress);
            this.txtbRpm.Validating += new System.ComponentModel.CancelEventHandler(this.txtbRpm_Validating);
            this.txtbRpm.Validated += new System.EventHandler(this.txtbRpm_Validated);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.label5);
            this.grpSettings.Controls.Add(this.label3);
            this.grpSettings.Controls.Add(this.ctrlAdvTable);
            this.grpSettings.Controls.Add(this.chkGear);
            this.grpSettings.Location = new System.Drawing.Point(7, 79);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(252, 95);
            this.grpSettings.TabIndex = 2;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Gear Based Shift Light";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "RPM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gear:";
            // 
            // ctrlAdvTable
            // 
            this.ctrlAdvTable.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdvTable.Location = new System.Drawing.Point(45, 42);
            this.ctrlAdvTable.Name = "ctrlAdvTable";
            this.ctrlAdvTable.Size = new System.Drawing.Size(201, 42);
            this.ctrlAdvTable.TabIndex = 2;
            // 
            // chkGear
            // 
            this.chkGear.AutoSize = true;
            this.chkGear.Location = new System.Drawing.Point(10, 19);
            this.chkGear.Name = "chkGear";
            this.chkGear.Size = new System.Drawing.Size(178, 18);
            this.chkGear.TabIndex = 1;
            this.chkGear.Text = "Enable Gear Based Shiftlight";
            this.chkGear.UseVisualStyleBackColor = true;
            this.chkGear.CheckedChanged += new System.EventHandler(this.chkGear_CheckedChanged);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(24, 26);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(114, 18);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "Enable Shiftlight";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shift RPM:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 198);
            this.panel1.TabIndex = 1;
            // 
            // parmMilShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmMilShift";
            this.Size = new System.Drawing.Size(295, 198);
            this.Load += new System.EventHandler(this.parmMilShift_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbRpm)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        this.class18_0.method_155("Mil shiftlight settings");
        this.class18_0.method_151(this.class18_0.class13_u_0.long_120 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2), this.class18_0.method_219(int.Parse(dataGridViewCellValueEventArgs_0.Value.ToString())));
        this.class18_0.method_153();
    }

    private void method_1(DataGridViewCellValueEventArgs dataGridViewCellValueEventArgs_0)
    {
        if (dataGridViewCellValueEventArgs_0.RowIndex == 0)
        {
            dataGridViewCellValueEventArgs_0.Value = dataGridViewCellValueEventArgs_0.ColumnIndex + 1;
        }
        else
        {
            dataGridViewCellValueEventArgs_0.Value = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_120 + (dataGridViewCellValueEventArgs_0.ColumnIndex * 2))).ToString();
        }
    }

    private void method_2(DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs_0)
    {
        if (dataGridViewCellValidatingEventArgs_0.RowIndex == 1)
        {
            dataGridViewCellValidatingEventArgs_0.Cancel = !this.class18_0.method_256(dataGridViewCellValidatingEventArgs_0.FormattedValue.ToString());
        }
        if (dataGridViewCellValidatingEventArgs_0.Cancel)
        {
            this.ctrlAdvTable.grid.CurrentCell.ErrorText = "Invalid input";
            dataGridViewCellValidatingEventArgs_0.Cancel = false;
        }
        else
        {
            this.ctrlAdvTable.grid.CurrentCell.ErrorText = "";
        }
    }

    private void method_3()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmMilShift_Load(null, null);
        }
    }

    private void method_4()
    {
        if (!this.bool_0)
        {
            this.class18_0.method_155("Mil shiftlight settings");
            if (this.chkGear.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_118, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_118, 0);
            }
            if (this.chkEnable.Checked)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_117, 0xff);
            }
            else
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_117, 0);
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_119, this.class18_0.method_219(int.Parse(this.txtbRpm.Text)));
            this.class18_0.method_153();
            this.parmMilShift_Load(null, null);
        }
    }

    private void parmMilShift_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.chkEnable.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_117) == 0xff;
        this.chkGear.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_118) == 0xff;
        this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_119)).ToString();
        if (this.chkGear.Checked)
        {
            this.ctrlAdvTable.Enabled = true;
        }
        else
        {
            this.ctrlAdvTable.Enabled = false;
        }
        if (this.chkGear.Checked && this.chkEnable.Checked)
        {
            this.txtbRpm.Enabled = false;
        }
        else if (this.chkGear.Checked && !this.chkEnable.Checked)
        {
            this.txtbRpm.Enabled = false;
        }
        else if (!this.chkGear.Checked && this.chkEnable.Checked)
        {
            this.txtbRpm.Enabled = true;
        }
        else if (!this.chkGear.Checked && !this.chkEnable.Checked)
        {
            this.txtbRpm.Enabled = false;
        }
        if (this.chkEnable.Checked)
        {
            this.chkGear.Enabled = true;
        }
        else
        {
            this.chkGear.Enabled = false;
        }
        this.ctrlAdvTable.method_DisableHeader();
        this.bool_0 = false;
    }

    private void txtbRpm_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            NumericUpDown control = (NumericUpDown) sender;
            this.groupBox1.Focus();
            if (this.errorProvider_0.GetError(control) == string.Empty)
            {
                this.method_4();
            }
            control.Focus();
        }
    }

    private void txtbRpm_Validated(object sender, EventArgs e)
    {
        this.method_4();
    }

    private void txtbRpm_Validating(object sender, CancelEventArgs e)
    {
        NumericUpDown control = (NumericUpDown) sender;
        if (!this.class18_0.method_256(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, integer required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void button5_Click(object sender, EventArgs e)
    {
        this.class18_0.method_151(this.class18_0.class13_u_0.long_119, this.class18_0.method_219(int.Parse(this.txtbRpm.Text) - 50));
        this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_119)).ToString();
        this.method_4();
    }

    private void button6_Click(object sender, EventArgs e)
    {
        this.class18_0.method_151(this.class18_0.class13_u_0.long_119, this.class18_0.method_219(int.Parse(this.txtbRpm.Text) + 50));
        this.txtbRpm.Text = this.class18_0.method_218(this.class18_0.method_152(this.class18_0.class13_u_0.long_119)).ToString();
        this.method_4();
    }
}

