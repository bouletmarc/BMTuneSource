using Controls;
using Data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class parmBoostMapSensor : UserControl
{
    private bool bool_0;
    private Button btnSave;
    private Class18 class18_0;
    private Controls.ctrlMapSensor ctrlMapSensor;
    private ErrorProvider errorProvider_0;
    private IContainer icontainer_0;
    private int[,] int_0 = new int[10, 2];
    private int[] int_1 = new int[0x18];
    private int[] int_2 = new int[0x18];
    private int int_3;
    private int int_4;
    private IContainer components;
    private GroupBox groupBox1;
    private frmBoostTableSetup frmBoostTableSetup_0;
    private Panel panel1;
    private int int_5 = 2;

    internal parmBoostMapSensor(ref Class18 rm)
    {
        this.class18_0 = rm;
        this.class18_0.delegate55_0 += new Class18.Delegate55(this.method_1);
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_1);
        this.InitializeComponent();
        this.ctrlMapSensor.method_0(ref this.class18_0);
        this.ctrlMapSensor.mapSensorChangedDelegate_0 += new Controls.ctrlMapSensor.MapSensorChangedDelegate(this.method_0);
        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        this.class18_0.method_155("Map Sensor Setting");

        if (MessageBox.Show(Form.ActiveForm, "Do you want to reset Map Scalars?", "Map Sensor Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            for (int k = 0; k < 0x18; k++)
            {
                this.int_1[k] = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_6 + k));
                this.int_2[k] = this.class18_0.method_206(this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_18 + k));
            }
            this.class18_0.method_151(this.class18_0.class13_u_0.long_0, (long)(this.int_3 + 0x8000));
            this.class18_0.method_151(this.class18_0.class13_u_0.long_1, (long)(this.int_4 + 0x8000));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_2, (byte)this.int_5);
            for (int m = 0; m < 0x18; m++)
            {
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_6 + m, this.class18_0.method_226(this.int_1[m]));
                this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_18 + m, this.class18_0.method_226(this.int_2[m]));
            }
        }
        if (MessageBox.Show(Form.ActiveForm, "Do you want to reset 'Boost options' setting to default? This reset:\n-Boostcut parameters\n-Ign corr. above load (mBar)\n-Openloop above load (mBar)\n-Fuel cut under load (mBar)\n-Vtec above load (mBar)\n-Etc..", "Map Sensor Settings", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_207, this.class18_0.method_226(750));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_53, this.class18_0.method_226(200));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_181, this.class18_0.method_226(0x406));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_127, this.class18_0.method_226(0xdac));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_128, this.class18_0.method_226(0xdac));
            this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_227, this.class18_0.method_226(100));
        }
        byte num4 = 0;
        byte num5 = 0;
        num4 = this.class18_0.method_226(0x400);
        num5 = 0xff;
        byte num3 = (byte)((num5 - num4) / 9);
        byte num6 = 0;
        double[] numArray = new double[10];
        for (int i = 0; i < 10; i++)
        {
            numArray[i] = Math.Round((double)this.class18_0.method_245(this.class18_0.method_206(num4)), 0);
            num4 = (byte)(num4 + num3);
        }
        for (int j = 0; j <= 10; j++)
        {
            switch (j)
            {
                case 0:
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (j * 2), 0xff);
                    break;

                case 10:
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (j * 2), 0);
                    break;

                default:
                    num6 = this.class18_0.method_226(this.class18_0.method_250((float)numArray[9 - j]));
                    this.class18_0.method_149_SetByte(this.class18_0.class13_u_0.long_262 + (j * 2), num6);
                    break;
            }
        }

        
        /*if (this.class18_0.method_150(this.class18_0.class13_0.long_75) > 10)
        {
            if (MessageBox.Show(Form.ActiveForm, "Do you want to reset the boost columns\nscalars with the new map sensor?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                float num12 = -1f;
                float num13 = -1f;
                float num14 = -1f;
                float num15 = -1f;
                int num16 = (this.class18_0.class10_0.method_11_GetMAP_ColumnsNumber() - 1) - 10;
                num12 = 2f;
                num15 = this.class18_0.method_245(this.class18_0.method_206(0xff));
                num13 = (num15 - num12) / ((float)num16);
                for (int num17 = 10; num17 < this.class18_0.class10_0.method_11_GetMAP_ColumnsNumber(); num17++)
                {
                    if (num14 < 0f) num14 = num12;
                    this.class18_0.method_171((byte)num17, this.class18_0.method_226(this.class18_0.method_250(num14)), SelectedTable.fuel1_hi);
                    this.class18_0.method_171((byte)num17, this.class18_0.method_226(this.class18_0.method_250(num14)), SelectedTable.fuel2_hi);
                    num14 += num13;
                }
                for (int num18 = this.class18_0.class10_0.method_11_GetMAP_ColumnsNumber(); num18 < this.class18_0.method_33(); num18++)
                {
                    this.class18_0.method_171((byte)num18, 0xff, SelectedTable.fuel1_hi);
                    this.class18_0.method_171((byte)num18, 0xff, SelectedTable.fuel2_hi);
                }

                if (MessageBox.Show(Form.ActiveForm, "Do you want to open the boost table tool\nto redo the fuel and ignition tables?", "BMTune", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (this.frmBoostTableSetup_0 != null)
                    {
                        this.frmBoostTableSetup_0.Focus();
                    }
                    else
                    {
                        this.frmBoostTableSetup_0 = new frmBoostTableSetup();
                        this.frmBoostTableSetup_0.method_0(ref this.class18_0);
                        this.frmBoostTableSetup_0.ShowDialog();
                        this.frmBoostTableSetup_0.Dispose();
                        this.frmBoostTableSetup_0 = null;
                    }
                }
            }
        }*/

        this.class18_0.method_153();
        this.class18_0.method_52();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlMapSensor = new Controls.ctrlMapSensor();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(49, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlMapSensor);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Sensor Settings";
            // 
            // ctrlMapSensor
            // 
            this.ctrlMapSensor.Location = new System.Drawing.Point(6, 19);
            this.ctrlMapSensor.Name = "ctrlMapSensor";
            this.ctrlMapSensor.Size = new System.Drawing.Size(182, 125);
            this.ctrlMapSensor.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 301);
            this.panel1.TabIndex = 3;
            // 
            // parmBoostMapSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmBoostMapSensor";
            this.Size = new System.Drawing.Size(220, 301);
            this.Load += new System.EventHandler(this.parmBoostMapSensor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void method_0(int int_6, int int_7, int int_8)
    {
        this.int_3 = int_6;
        this.int_4 = int_7;
        this.int_5 = int_8;
    }

    private void method_1()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.parmBoostMapSensor_Load(null, null);
        }
    }

    private void parmBoostMapSensor_Load(object sender, EventArgs e)
    {
        this.bool_0 = true;
        this.int_3 = (int) (this.class18_0.method_152(this.class18_0.class13_u_0.long_0) - 0x8000L);  //Min
        this.int_4 = (int) (this.class18_0.method_152(this.class18_0.class13_u_0.long_1) - 0x8000L);  //Max
        this.int_5 = this.class18_0.GetByteAt(this.class18_0.class13_u_0.long_2);                    //Index
        this.ctrlMapSensor.setMapSensor(this.int_3, this.int_4, this.int_5 - 2);
        this.bool_0 = false;
    }
}

