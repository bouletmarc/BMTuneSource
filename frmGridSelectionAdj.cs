using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmGridSelectionAdj : Form
{
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private Button btnCancel;
    private Button btnOk;
    private Class10_settings class10_settings_0;
    private Class12_afrT class12_afrT_0;
    private Class18 class18_0;
    private DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection_0;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private double double_4;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private int[] int_0;
    private int int_1;
    private object object_0;
    private object object_1;
    private RadioButton rbAdd;
    private RadioButton rbPercent;
    private RadioButton rbSet;
    private TextBox txtbAdd;
    private TextBox txtbPercent;
    private IContainer components;
    private TextBox txtbSet;

    internal frmGridSelectionAdj(int[] _selborders, ref DataGridViewSelectedCellCollection sel, ref Class10_settings cfg, ref Class18 rom, bool isTargetAfr, ref Class12_afrT te)
    {
        this.InitializeComponent();
        this.dataGridViewSelectedCellCollection_0 = sel;
        this.int_0 = _selborders;
        this.class18_0 = rom;
        this.class10_settings_0 = cfg;
        this.bool_2 = isTargetAfr;
        this.class12_afrT_0 = te;
        if (this.bool_2)
        {
            this.rbPercent.Enabled = false;
            this.txtbPercent.Enabled = false;
        }
        else if (!this.class18_0.method_40())
        {
            for (int i = 0; i < sel.Count; i++)
            {
                this.object_0 = this.class12_afrT_0.method_17(sel[i].ColumnIndex, sel[i].RowIndex);
                if (this.class10_settings_0.bool_49)
                {
                    this.class12_afrT_0.method_6(sel[i].ColumnIndex, sel[i].RowIndex);
                }
                this.object_1 = this.class12_afrT_0.method_16(sel[i].ColumnIndex, sel[i].RowIndex);
                if (((this.object_0 != null) && (this.object_0.ToString() != "-")) && ((this.object_1 != null) && (this.object_1.ToString() != "-")))
                {
                    this.double_0 += (double) this.object_0;
                    this.double_2 += (double) this.object_1;
                    this.int_1++;
                }
            }
            if ((this.int_1 > 0) && ((((double) this.int_1) / ((double) sel.Count)) >= (((double) this.class10_settings_0.int_40) / 100.0)))
            {
                this.double_1 = this.double_0 / ((double) this.int_1);
                this.double_3 = this.double_2 / ((double) this.int_1);
                this.double_4 = -this.double_3 * this.class10_settings_0.double_15;
                this.bool_0 = true;

                this.txtbPercent.Text = "0";
                if ((Math.Abs(this.double_4) >= this.class10_settings_0.double_13) && (Math.Abs(this.double_4) <= this.class10_settings_0.double_14))
                {
                    //this.txtbPercent.Text = this.double_4.ToString("0.00");
                    this.bool_1 = true;
                }
                else if (Math.Abs(this.double_4) > this.class10_settings_0.double_14)
                {
                    if (this.double_4 >= 0.0)
                    {
                        //this.txtbPercent.Text = this.class10_settings_0.double_14.ToString();
                        this.bool_1 = true;
                    }
                    else if (this.double_4 < 0.0)
                    {
                        //this.txtbPercent.Text = (-1.0 * this.class10_settings_0.double_14).ToString();
                        this.bool_1 = true;
                    }
                }
            }
        }

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtbAdd.Text = "0";
        this.txtbPercent.Text = "0";
        this.txtbSet.Text = "0";
        this.dataGridViewSelectedCellCollection_0 = null;
        this.double_4 = 0.0;
        GC.Collect(3);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Grid Selection Adjustement");
        byte rowIndex;
        byte columnIndex;
        float num3 = 0f;
        double num4 = 0.0;
        int num5 = this.int_0[0];
        int num7 = this.int_0[1];
        int num6 = this.int_0[2];
        int num8 = this.int_0[3];
        this.class18_0.method_163((byte) num5);
        this.class18_0.method_163((byte) num6);
        this.class18_0.method_159((byte) num7);
        this.class18_0.method_159((byte) num8);
        if (this.rbPercent.Checked)
        {
            if (this.txtbPercent.Text == string.Empty)
            {
                return;
            }
            string[] strArray = new string[] { this.class18_0.method_4().ToString(), " percent: ", this.txtbPercent.Text, "@ col ", (num5 + 1).ToString(), " to ", (num6 + 1).ToString(), " & row ", (num7 + 1).ToString(), " to ", (num8 + 1).ToString() };
            this.class18_0.method_155(string.Concat(strArray));
            for (int i = 0; i < this.dataGridViewSelectedCellCollection_0.Count; i++)
            {
                columnIndex = (byte) this.dataGridViewSelectedCellCollection_0[i].ColumnIndex;
                rowIndex = (byte) this.dataGridViewSelectedCellCollection_0[i].RowIndex;
                num3 = this.class18_0.method_174(columnIndex, rowIndex);
                this.class18_0.method_176(columnIndex, rowIndex, num3 + ((num3 / 100f) * float.Parse(this.txtbPercent.Text)));
                if (this.bool_1)
                {
                    this.class12_afrT_0.method_4(columnIndex, rowIndex);
                }
            }
            this.class18_0.method_153();
        }
        else if (this.rbAdd.Checked)
        {
            if (this.txtbAdd.Text == string.Empty)
            {
                return;
            }
            string[] strArray3 = new string[] { this.class18_0.method_4().ToString(), " add: ", this.txtbAdd.Text, "@ col ", (num5 + 1).ToString(), " to ", (num6 + 1).ToString(), " & row ", (num7 + 1).ToString(), " to ", (num8 + 1).ToString() };
            this.class18_0.method_155(string.Concat(strArray3));
            for (int k = 0; k < this.dataGridViewSelectedCellCollection_0.Count; k++)
            {
                columnIndex = (byte) this.dataGridViewSelectedCellCollection_0[k].ColumnIndex;
                rowIndex = (byte) this.dataGridViewSelectedCellCollection_0[k].RowIndex;
                if (!this.bool_2)
                {
                    num3 = this.class18_0.method_174(columnIndex, rowIndex);
                    this.class18_0.method_176(columnIndex, rowIndex, num3 + float.Parse(this.txtbAdd.Text));
                }
                else
                {
                    num3 = (float) this.class12_afrT_0.method_13(columnIndex, rowIndex);
                    if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                    {
                        num4 = this.class18_0.method_240(double.Parse(this.txtbAdd.Text));
                    }
                    else
                    {
                        num4 = double.Parse(this.txtbAdd.Text);
                    }
                    this.class12_afrT_0.method_15(columnIndex, rowIndex, num3 + num4);
                }
            }
            this.class18_0.method_153();
        }
        else if (this.rbSet.Checked)
        {
            if (this.txtbSet.Text == string.Empty)
            {
                return;
            }
            string[] strArray4 = new string[] { this.class18_0.method_4().ToString(), " set: ", this.txtbSet.Text, "@ col ", (num5 + 1).ToString(), " to ", (num6 + 1).ToString(), " & row ", (num7 + 1).ToString(), " to ", (num8 + 1).ToString() };
            this.class18_0.method_155(string.Concat(strArray4));
            for (int m = 0; m < this.dataGridViewSelectedCellCollection_0.Count; m++)
            {
                columnIndex = (byte) this.dataGridViewSelectedCellCollection_0[m].ColumnIndex;
                rowIndex = (byte) this.dataGridViewSelectedCellCollection_0[m].RowIndex;
                if (!this.bool_2)
                {
                    this.class18_0.method_176(columnIndex, rowIndex, float.Parse(this.txtbSet.Text));
                }
                else
                {
                    if (this.class10_settings_0.airFuelUnits_0 == AirFuelUnits.afr)
                    {
                        num4 = this.class18_0.method_240(double.Parse(this.txtbSet.Text));
                    }
                    else
                    {
                        num4 = double.Parse(this.txtbSet.Text);
                    }
                    this.class12_afrT_0.method_15(columnIndex, rowIndex, num4);
                }
            }
            this.class18_0.method_153();
        }
        this.dataGridViewSelectedCellCollection_0 = null;
        this.double_4 = 0.0;
        num3 = 0f;
        this.class18_0.method_53();
        GC.Collect(3);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmGridSelectionAdj_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridSelectionAdj));
            this.txtbSet = new System.Windows.Forms.TextBox();
            this.txtbAdd = new System.Windows.Forms.TextBox();
            this.txtbPercent = new System.Windows.Forms.TextBox();
            this.rbSet = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbPercent = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbSet
            // 
            this.txtbSet.Location = new System.Drawing.Point(140, 62);
            this.txtbSet.Name = "txtbSet";
            this.txtbSet.Size = new System.Drawing.Size(49, 20);
            this.txtbSet.TabIndex = 7;
            this.txtbSet.Text = "0";
            this.txtbSet.Enter += new System.EventHandler(this.txtbSet_Enter);
            this.txtbSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbPercent_KeyPress);
            this.txtbSet.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPercent_Validating);
            // 
            // txtbAdd
            // 
            this.txtbAdd.Location = new System.Drawing.Point(140, 38);
            this.txtbAdd.Name = "txtbAdd";
            this.txtbAdd.Size = new System.Drawing.Size(49, 20);
            this.txtbAdd.TabIndex = 6;
            this.txtbAdd.Text = "0";
            this.txtbAdd.Enter += new System.EventHandler(this.txtbAdd_Enter);
            this.txtbAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbPercent_KeyPress);
            this.txtbAdd.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPercent_Validating);
            // 
            // txtbPercent
            // 
            this.txtbPercent.Location = new System.Drawing.Point(141, 13);
            this.txtbPercent.Name = "txtbPercent";
            this.txtbPercent.Size = new System.Drawing.Size(49, 20);
            this.txtbPercent.TabIndex = 5;
            this.txtbPercent.Text = "0";
            this.txtbPercent.Enter += new System.EventHandler(this.txtbPercent_Enter);
            this.txtbPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbPercent_KeyPress);
            this.txtbPercent.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPercent_Validating);
            // 
            // rbSet
            // 
            this.rbSet.AutoSize = true;
            this.rbSet.Location = new System.Drawing.Point(14, 62);
            this.rbSet.Name = "rbSet";
            this.rbSet.Size = new System.Drawing.Size(94, 18);
            this.rbSet.TabIndex = 3;
            this.rbSet.TabStop = true;
            this.rbSet.Text = "Direct Value:";
            this.rbSet.UseVisualStyleBackColor = true;
            this.rbSet.Click += new System.EventHandler(this.rbSet_Click);
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Location = new System.Drawing.Point(14, 38);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(107, 18);
            this.rbAdd.TabIndex = 2;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add Value (+/-):";
            this.rbAdd.UseVisualStyleBackColor = true;
            this.rbAdd.Click += new System.EventHandler(this.rbAdd_Click);
            // 
            // rbPercent
            // 
            this.rbPercent.AutoSize = true;
            this.rbPercent.Location = new System.Drawing.Point(14, 13);
            this.rbPercent.Name = "rbPercent";
            this.rbPercent.Size = new System.Drawing.Size(115, 18);
            this.rbPercent.TabIndex = 1;
            this.rbPercent.TabStop = true;
            this.rbPercent.Text = "Percentage (+/-):";
            this.rbPercent.UseVisualStyleBackColor = true;
            this.rbPercent.Click += new System.EventHandler(this.rbPercent_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(105, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(13, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // frmGridSelectionAdj
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(199, 126);
            this.Controls.Add(this.txtbSet);
            this.Controls.Add(this.txtbAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtbPercent);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rbSet);
            this.Controls.Add(this.rbPercent);
            this.Controls.Add(this.rbAdd);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGridSelectionAdj";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Adjustments";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGridSelectionAdj_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void rbAdd_Click(object sender, EventArgs e)
    {
        this.txtbAdd.Focus();
    }

    private void rbPercent_Click(object sender, EventArgs e)
    {
        this.txtbPercent.Focus();
    }

    private void rbSet_Click(object sender, EventArgs e)
    {
        this.txtbSet.Focus();
    }

    private void txtbAdd_Enter(object sender, EventArgs e)
    {
        this.rbAdd.Checked = true;
    }

    private void txtbPercent_Enter(object sender, EventArgs e)
    {
        this.rbPercent.Checked = true;
    }

    private void txtbPercent_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\x001b')
        {
            TextBox box = (TextBox) sender;
            box.Text = "0";
        }
    }

    private void txtbPercent_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (control.Text != string.Empty)
        {
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
    }

    private void txtbSet_Enter(object sender, EventArgs e)
    {
        this.rbSet.Checked = true;
    }
}

