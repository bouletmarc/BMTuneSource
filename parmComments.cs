using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmComments : UserControl
{
    private Class18 class18_0;
    private GroupBox groupBox1;
    private IContainer icontainer_0;
    private Panel panel1;
    private TextBox txtbComment;

    internal parmComments(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_0);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_0);
        this.InitializeComponent();

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

    private void InitializeComponent()
    {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbComment = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtbComment);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comments";
            // 
            // txtbComment
            // 
            this.txtbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbComment.BackColor = System.Drawing.SystemColors.Window;
            this.txtbComment.Location = new System.Drawing.Point(20, 31);
            this.txtbComment.Multiline = true;
            this.txtbComment.Name = "txtbComment";
            this.txtbComment.Size = new System.Drawing.Size(259, 144);
            this.txtbComment.TabIndex = 1;
            this.txtbComment.TextChanged += new System.EventHandler(this.txtbComment_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 210);
            this.panel1.TabIndex = 1;
            // 
            // parmComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmComments";
            this.Size = new System.Drawing.Size(324, 210);
            this.Load += new System.EventHandler(this.parmComments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void method_0()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmComments_Load(null, null);
        }
    }

    private void parmComments_Load(object sender, EventArgs e)
    {
        this.txtbComment.Text = this.class18_0.method_88_GetComments();
    }

    private void txtbComment_TextChanged(object sender, EventArgs e)
    {
        this.class18_0.method_87_SetComments(this.txtbComment.Text);
    }
}

