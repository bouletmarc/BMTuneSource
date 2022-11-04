using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

internal class frmIgnitionSync : Form
{
    private bool bool_0;
    private bool bool_1;
    private Class18 class18_0;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private Label label2;
    private Label label4;
    private Label label5;
    private Label lblStatus;
    private System.Timers.Timer timer_0 = new System.Timers.Timer(150.0);
    private TextBox txtbBase;
    private IContainer components;
    private Button btnSync;
    private CheckBox chkCust;
    private TextBox txtbSync;

    internal frmIgnitionSync()
    {
        this.InitializeComponent();
        this.timer_0.AutoReset = true;
        this.timer_0.Elapsed += new ElapsedEventHandler(this.timer_0_Elapsed);

    }

    private void btnSync_Click(object sender, EventArgs e)
    {
        this.bool_0 = !this.bool_0;
        if (this.bool_0)
        {
            this.timer_0.Start();
            this.btnSync.Text = "End Sync";
            this.lblStatus.Visible = true;
            this.lblStatus.Text = "Ignition lock at " + this.txtbSync.Text + "\x00b0";
            this.class18_0.method_155("Ignition Sync Start");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_100, 0xff);
            this.class18_0.method_153();
        }
        else
        {
            this.timer_0.Stop();
            this.btnSync.Text = "Sync";
            this.lblStatus.Visible = false;
            this.class18_0.method_155("Ignition Sync End");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_100, 0);
            this.class18_0.method_153();
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

    private void frmIgnitionSync_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.bool_0)
        {
            e.Cancel = true;
            MessageBox.Show(Form.ActiveForm, "Can't close while syncing ignition");
        }
    }

    private void frmIgnitionSync_Load(object sender, EventArgs e)
    {
        this.bool_1 = true;
        if ((this.class18_0.class13_u_0.long_102 == 0L) || (this.class18_0.class13_u_0.long_101 == 0L))
        {
            base.Close();
        }
        this.class18_0.method_155("Ignition Sync First Time");
        if ((this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_102) == 0) || (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_102) == 0xff))
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_102, 0x58);
        }
        if ((this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_101) == 0) || (this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_101) == 0xff))
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_101, 90);
        }
        this.class18_0.method_153();
        this.txtbBase.Text = ((this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_102) * 0.25f) - 6f).ToString();
        this.txtbSync.Text = ((this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_101) * 0.25f) - 6f).ToString();

        if (this.class18_0.class13_u_0.long_116 != 0L) this.chkCust.Checked = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_116) != 0;
        this.chkCust.Enabled = this.class18_0.class13_u_0.long_116 != 0L;

        this.bool_1 = false;
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIgnitionSync));
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbBase = new System.Windows.Forms.TextBox();
            this.txtbSync = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkCust = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.IndianRed;
            this.lblStatus.Location = new System.Drawing.Point(0, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(174, 24);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Ignition lock at 16.5°";
            this.lblStatus.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Base Timing:";
            // 
            // txtbBase
            // 
            this.txtbBase.Location = new System.Drawing.Point(79, 4);
            this.txtbBase.Name = "txtbBase";
            this.txtbBase.Size = new System.Drawing.Size(39, 20);
            this.txtbBase.TabIndex = 2;
            this.txtbBase.Text = "16";
            this.txtbBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbSync_KeyPress);
            this.txtbBase.Leave += new System.EventHandler(this.txtbSync_Leave);
            this.txtbBase.Validating += new System.ComponentModel.CancelEventHandler(this.txtbSync_Validating);
            // 
            // txtbSync
            // 
            this.txtbSync.Location = new System.Drawing.Point(261, 4);
            this.txtbSync.Name = "txtbSync";
            this.txtbSync.Size = new System.Drawing.Size(39, 20);
            this.txtbSync.TabIndex = 4;
            this.txtbSync.Text = "16.5";
            this.txtbSync.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbSync_KeyPress);
            this.txtbSync.Leave += new System.EventHandler(this.txtbSync_Leave);
            this.txtbSync.Validating += new System.ComponentModel.CancelEventHandler(this.txtbSync_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "°";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "°";
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSync.Location = new System.Drawing.Point(235, 32);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 7;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // chkCust
            // 
            this.chkCust.AutoSize = true;
            this.chkCust.Location = new System.Drawing.Point(155, 6);
            this.chkCust.Name = "chkCust";
            this.chkCust.Size = new System.Drawing.Size(102, 17);
            this.chkCust.TabIndex = 8;
            this.chkCust.Text = "Lock Ignition at:";
            this.chkCust.UseVisualStyleBackColor = true;
            this.chkCust.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmIgnitionSync
            // 
            this.AcceptButton = this.btnSync;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(317, 58);
            this.Controls.Add(this.chkCust);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbSync);
            this.Controls.Add(this.txtbBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIgnitionSync";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sync Ignition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIgnitionSync_FormClosing);
            this.Load += new System.EventHandler(this.frmIgnitionSync_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    internal void method_0(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1()
    {
        if (!this.bool_1)
        {
            this.class18_0.method_155("Ignition Sync Settings");
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_101, (byte) ((float.Parse(this.txtbSync.Text) + 6f) * 4f));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_102, (byte) ((float.Parse(this.txtbBase.Text) + 6f) * 4f));
            if (this.chkCust.Checked) this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_116, 0xff);
            else this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_116, 0);
            this.class18_0.method_153();
        }
    }

    private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
    {
        this.lblStatus.Visible = !this.lblStatus.Visible;
    }

    private void txtbSync_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            this.method_1();
            this.frmIgnitionSync_Load(null, null);
            this.class18_0.method_53();
        }
    }

    private void txtbSync_Leave(object sender, EventArgs e)
    {
        this.method_1();
    }

    private void txtbSync_Validating(object sender, CancelEventArgs e)
    {
        TextBox control = (TextBox) sender;
        if (!this.class18_0.method_252(control.Text.ToString()))
        {
            this.errorProvider_0.SetError(control, "Invalid input, double required");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider_0.SetError(control, "");
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        this.method_1();
    }
}

