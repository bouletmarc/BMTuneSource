using Data;
//using PropertiesRes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmDataGrid : Form
{
    private Class10_settings class10_settings_0;
    private Class17 class17_0;
    public CtrlSensorGrid ctrlSensorGrid1;
    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    private IContainer components;

    public bool loading = true;

    internal frmDataGrid()
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

    private void frmDataGrid_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.class10_settings_0.WindowedMode) this.class10_settings_0.logGrid_Location = base.Location;
        this.ctrlSensorGrid1.method_0();
        this.frmMain_0.frmDataGrid_0.Dispose();
        this.frmMain_0.frmDataGrid_0 = null;
        base.Dispose();
    }

    private void frmDataGrid_Load(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Dock = DockStyle.None;
                base.Location = this.class10_settings_0.logGrid_Location;
                base.Size = this.class10_settings_0.logGrid_Size;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
            }
        }
        loading = false;
    }

    private void frmDataGrid_Resize(object sender, EventArgs e)
    {
        if (this.class10_settings_0 != null)
        {
            if (this.class10_settings_0.WindowedMode && !loading)
            {
                if (base.WindowState == FormWindowState.Normal)
                {
                    this.class10_settings_0.logGrid_Size = base.Size;
                }
                this.class10_settings_0.logGrid_Location = base.Location;
            }
        }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataGrid));
            this.ctrlSensorGrid1 = new CtrlSensorGrid();
            this.SuspendLayout();
            // 
            // ctrlSensorGrid1
            // 
            this.ctrlSensorGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSensorGrid1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlSensorGrid1.Location = new System.Drawing.Point(0, 0);
            this.ctrlSensorGrid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrlSensorGrid1.Name = "ctrlSensorGrid1";
            this.ctrlSensorGrid1.Size = new System.Drawing.Size(185, 464);
            this.ctrlSensorGrid1.TabIndex = 0;
            // 
            // frmDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 464);
            this.Controls.Add(this.ctrlSensorGrid1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDataGrid";
            this.Text = "Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDataGrid_FormClosed);
            this.Load += new System.EventHandler(this.frmDataGrid_Load);
            this.Resize += new System.EventHandler(this.frmDataGrid_Resize);
            this.ResumeLayout(false);

    }

    internal void method_0(ref Class18 class18_0, ref Class10_settings class10_1, ref Class17 class17_1, ref FrmMain frmMain_1)
    {
        this.frmMain_0 = frmMain_1;
        this.class10_settings_0 = class10_1;
        this.class17_0 = class17_1;
        this.ctrlSensorGrid1.method_1(ref class18_0, ref class10_1, ref class17_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    public void method_2()
    {
        this.ctrlSensorGrid1.method_4();
    }
}

