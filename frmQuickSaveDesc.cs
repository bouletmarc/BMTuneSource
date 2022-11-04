using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmQuickSaveDesc : Form
{
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private Label label1;
    private IContainer components;
    private Label label2;
    private TextBox txtbDesc;

    public frmQuickSaveDesc()
    {
        this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void frmQuickSaveDesc_Load(object sender, EventArgs e)
    {
        this.txtbDesc.Focus();
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbDesc = new System.Windows.Forms.TextBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desc:";
            // 
            // txtbDesc
            // 
            this.txtbDesc.Location = new System.Drawing.Point(50, 43);
            this.txtbDesc.Name = "txtbDesc";
            this.txtbDesc.Size = new System.Drawing.Size(168, 20);
            this.txtbDesc.TabIndex = 1;
            this.txtbDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDesc_KeyPress);
            this.txtbDesc.Validating += new System.ComponentModel.CancelEventHandler(this.txtbDesc_Validating);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(56, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Add a description\r\nfor your snapshot";
            // 
            // frmQuickSaveDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 67);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbDesc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmQuickSaveDesc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Snapshot Description";
            this.Load += new System.EventHandler(this.frmQuickSaveDesc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void txtbDesc_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            base.Tag = this.txtbDesc.Text;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }
    }

    private void txtbDesc_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (control.Text == string.Empty)
        {
            this.errorProvider_0.SetError(control, "Please enter description");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }
}

