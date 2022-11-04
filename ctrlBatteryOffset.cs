using System;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class ctrlBatteryOffset : UserControl
{
    private bool bool_0;
    private Class18 class18_0;
    private IContainer icontainer_0;
    private ComboBox lst;

    public event Delegate64 delegate64_0;

    internal ctrlBatteryOffset()
    {
        this.InitializeComponent();
    }

    private void ctrlBatteryOffset_Load(object sender, EventArgs e)
    {
        //this.method_2();
        //foreach (Class24_u class2 in this.class18_0.Inj_collection) this.lst.Items.Add(class2.string_0);
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
            this.lst = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lst.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.DropDownHeight = 325;
            this.lst.DropDownWidth = 340;
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst.FormattingEnabled = true;
            this.lst.IntegralHeight = false;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(282, 21);
            this.lst.TabIndex = 0;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // ctrlBatteryOffset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst);
            this.Name = "ctrlBatteryOffset";
            this.Size = new System.Drawing.Size(282, 21);
            this.Load += new System.EventHandler(this.ctrlBatteryOffset_Load);
            this.ResumeLayout(false);

    }

    private void lst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.bool_0 && (this.delegate64_0 != null))
        {
            this.delegate64_0(null, this.class18_0.class24_u_0[this.lst.SelectedIndex].double_0, this.class18_0.class24_u_0[this.lst.SelectedIndex].double_1, this.lst.SelectedIndex, this.class18_0.class24_u_0[this.lst.SelectedIndex].string_0);
        }
    }

    public void method_0(ref Class18 class18_1)
    {
        this.class18_0 = class18_1;
        foreach (Class24_u class24_u_1 in this.class18_0.class24_u_0) this.lst.Items.Add(class24_u_1.string_0);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    public void method_1(byte byte_0)
    {
        this.bool_0 = true;
        this.lst.SelectedIndex = byte_0;
        this.bool_0 = false;
    }

    /*private void method_2()
    {
        Class24_u item = null;
        item = new Class24_u {
            string_0 = "Acura Integra (92-96 VTEC) 240cc (23lb) 12ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.11, 8.09, 0.0 },
            double_1 = new double[] { 0.29, 0.29, 0.4, 0.56, 0.79, 1.22, 1.22 }
        };
        this.class18_0.Inj_collection.Add(item);
        item = new Class24_u {
            string_0 = "Honda Civic (92-00 EX/SI) 240cc (23lb) 12ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.11, 8.09, 0.0 },
            double_1 = new double[] { 0.32, 0.33, 0.47, 0.62, 1.09, 2.05, 2.05 }
        };
        this.class18_0.Inj_collection.Add(item);

        item = new Class24_u
        {
            string_0 = "Honda Civic (92-00 LX/DX/HX) 190cc (18lb) 12ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 13.0, 12.0, 10.0, 8.0 },
            double_1 = new double[] { 0.31, 0.34, 0.46, 0.60, 0.80, 1.17, 1.82 }
        };
        this.class18_0.Inj_collection.Add(item);
        //################################################################################################
    }*/

    public double[] method_3()
    {
        return this.class18_0.class24_u_0[this.lst.SelectedIndex].double_0;
    }

    public double[] method_4()
    {
        return this.class18_0.class24_u_0[this.lst.SelectedIndex].double_1;
    }

    public delegate void Delegate64(byte[] byte_0, double[] double_0, double[] double_1, int int_0, string string_0);
}

