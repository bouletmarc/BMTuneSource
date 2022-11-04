using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

internal class frmAdvTableAdd : Form
{
    private Button btnOk;
    private Class18 class18_0;
    private DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private int int_0;
    private Label lblAdj;
    private IContainer components;
    private TextBox textBox1;

    internal frmAdvTableAdd(DataGridViewSelectedCellCollection sel, ref Class18 rm)
    {
        this.dataGridViewSelectedCellCollection_0 = sel;
        this.class18_0 = rm;
        this.InitializeComponent();

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        switch (this.int_0)
        {
            case 1:
                foreach (DataGridViewCell cell in this.dataGridViewSelectedCellCollection_0)
                {
                    cell.Value = double.Parse(cell.Value.ToString()) + double.Parse(this.textBox1.Text);
                }
                break;

            case 2:
                foreach (DataGridViewCell cell2 in this.dataGridViewSelectedCellCollection_0)
                {
                    cell2.Value = double.Parse(cell2.Value.ToString()) + ((double.Parse(cell2.Value.ToString()) / 100.0) * double.Parse(this.textBox1.Text));
                }
                break;

            case 3:
                foreach (DataGridViewCell cell3 in this.dataGridViewSelectedCellCollection_0)
                {
                    cell3.Value = double.Parse(this.textBox1.Text);
                }
                break;

            default:
                return;
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

    private void frmAdvTableAdd_Load(object sender, EventArgs e)
    {
        if (base.Tag != null)
        {
            this.int_0 = int.Parse(base.Tag.ToString());
        }
        switch (this.int_0)
        {
            case 1:
                this.lblAdj.Text = "Add to selection:";
                return;

            case 2:
                this.lblAdj.Text = "Percentage change:";
                return;

            case 3:
                this.lblAdj.Text = "Set selection to";
                return;
        }
        this.lblAdj.Text = "error";
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvTableAdd));
            this.btnOk = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAdj = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(217, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Apply";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(61, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // lblAdj
            // 
            this.lblAdj.AutoSize = true;
            this.lblAdj.Location = new System.Drawing.Point(8, 14);
            this.lblAdj.Name = "lblAdj";
            this.lblAdj.Size = new System.Drawing.Size(116, 14);
            this.lblAdj.TabIndex = 0;
            this.lblAdj.Text = "Percentage change:";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // frmAdvTableAdd
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 42);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblAdj);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdvTableAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adjust Value";
            this.Load += new System.EventHandler(this.frmAdvTableAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private bool method_0(string string_0)
    {
        double num;
        return double.TryParse(Convert.ToString(string_0), NumberStyles.Any, (IFormatProvider) NumberFormatInfo.CurrentInfo, out num);
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.method_0(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

