namespace Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ctrlMapSensor : UserControl
    {
        private bool bool_0;
        private Class18 class18_0;
        private ErrorProvider errorProvider_0;
        private IContainer icontainer_0;
        private int int_1 = 10;                      //Map Sensors available Number
        private int[,] int_0 = new int[10, 2];       //Map Sensors Parameters array (10x sensors of 2x values, Min and Max Values)
        private Label label2;
        private Label label3;
        private Label label6;
        private ComboBox lstMapSensor;
        private IContainer components;
        private Label label1;
        private NumericUpDown txtScalar;
        private NumericUpDown txtbMapMinMbar;
        private NumericUpDown txtbMapMaxMbar;
        private TextBox txtMapKoeo;

        public event MapSensorChangedDelegate mapSensorChangedDelegate_0;

        public ctrlMapSensor()
        {
            this.InitializeComponent();
        }

        private void ctrlMapSensor_Load(object sender, EventArgs e)
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstMapSensor = new System.Windows.Forms.ComboBox();
            this.txtMapKoeo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtScalar = new System.Windows.Forms.NumericUpDown();
            this.txtbMapMaxMbar = new System.Windows.Forms.NumericUpDown();
            this.txtbMapMinMbar = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMapMaxMbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMapMinMbar)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMapSensor
            // 
            this.lstMapSensor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lstMapSensor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lstMapSensor.FormattingEnabled = true;
            this.lstMapSensor.Items.AddRange(new object[] {
            "Stock 1.75Bar",
            "GM 2Bar",
            "GM 3Bar",
            "Motorola 2.5Bar",
            "AEM 3.5Bar",
            "AEM 5Bar",
            "Xenocron/Omni 3Bar",
            "Xenocron/Omni 4Bar",
            "Sparkks Racing 3Bar",
            "Custom"});
            this.lstMapSensor.Location = new System.Drawing.Point(0, 3);
            this.lstMapSensor.Name = "lstMapSensor";
            this.lstMapSensor.Size = new System.Drawing.Size(156, 21);
            this.lstMapSensor.TabIndex = 1;
            this.lstMapSensor.SelectedIndexChanged += new System.EventHandler(this.lstMapSensor_SelectedIndexChanged);
            // 
            // txtMapKoeo
            // 
            this.txtMapKoeo.Location = new System.Drawing.Point(102, 94);
            this.txtMapKoeo.Name = "txtMapKoeo";
            this.txtMapKoeo.ReadOnly = true;
            this.txtMapKoeo.Size = new System.Drawing.Size(51, 20);
            this.txtMapKoeo.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Engine Off Volt:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "mBar at 5V:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "mBar at 0V (offset):";
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "mBar/Volt Scalar:";
            // 
            // txtScalar
            // 
            this.txtScalar.Location = new System.Drawing.Point(102, 72);
            this.txtScalar.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtScalar.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.txtScalar.Name = "txtScalar";
            this.txtScalar.Size = new System.Drawing.Size(51, 20);
            this.txtScalar.TabIndex = 11;
            this.txtScalar.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.txtScalar.ValueChanged += new System.EventHandler(this.txtbScalar_TextChanged);
            this.txtScalar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMapMinMbar_Validating);
            this.txtScalar.Validated += new System.EventHandler(this.txtbScalar_Validated);
            // 
            // txtbMapMaxMbar
            // 
            this.txtbMapMaxMbar.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtbMapMaxMbar.Location = new System.Drawing.Point(102, 50);
            this.txtbMapMaxMbar.Maximum = new decimal(new int[] {
            6500,
            0,
            0,
            0});
            this.txtbMapMaxMbar.Minimum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.txtbMapMaxMbar.Name = "txtbMapMaxMbar";
            this.txtbMapMaxMbar.Size = new System.Drawing.Size(51, 20);
            this.txtbMapMaxMbar.TabIndex = 12;
            this.txtbMapMaxMbar.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.txtbMapMaxMbar.ValueChanged += new System.EventHandler(this.txtbMapMinMbar_TextChanged);
            this.txtbMapMaxMbar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMapMinMbar_Validating);
            this.txtbMapMaxMbar.Validated += new System.EventHandler(this.txtbMapMinMbar_Validated);
            // 
            // txtbMapMinMbar
            // 
            this.txtbMapMinMbar.Location = new System.Drawing.Point(102, 28);
            this.txtbMapMinMbar.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.txtbMapMinMbar.Minimum = new decimal(new int[] {
            700,
            0,
            0,
            -2147483648});
            this.txtbMapMinMbar.Name = "txtbMapMinMbar";
            this.txtbMapMinMbar.Size = new System.Drawing.Size(51, 20);
            this.txtbMapMinMbar.TabIndex = 13;
            this.txtbMapMinMbar.Value = new decimal(new int[] {
            700,
            0,
            0,
            -2147483648});
            this.txtbMapMinMbar.ValueChanged += new System.EventHandler(this.txtbMapMinMbar_TextChanged);
            this.txtbMapMinMbar.Validating += new System.ComponentModel.CancelEventHandler(this.txtbMapMinMbar_Validating);
            this.txtbMapMinMbar.Validated += new System.EventHandler(this.txtbMapMinMbar_Validated);
            // 
            // ctrlMapSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbMapMinMbar);
            this.Controls.Add(this.txtbMapMaxMbar);
            this.Controls.Add(this.txtScalar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMapSensor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMapKoeo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Name = "ctrlMapSensor";
            this.Size = new System.Drawing.Size(158, 117);
            this.Load += new System.EventHandler(this.ctrlMapSensor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMapMaxMbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbMapMinMbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lstMapSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.lstMapSensor.SelectedIndex;
            if (selectedIndex < this.int_1)
            {
                this.bool_0 = true;
                this.txtbMapMinMbar.Text = this.int_0[selectedIndex, 0].ToString();
                this.txtbMapMaxMbar.Text = this.int_0[selectedIndex, 1].ToString();
                this.txtMapKoeo.Text = this.method_3(int.Parse(this.txtbMapMinMbar.Text), int.Parse(this.txtbMapMaxMbar.Text)).ToString("0.00");
                this.txtScalar.Text = ((double.Parse(this.txtbMapMaxMbar.Text) - double.Parse(this.txtbMapMinMbar.Text)) / 5.0).ToString();
                this.bool_0 = false;
            }
            else
            {
                this.txtMapKoeo.Text = "";
            }
            if (((this.errorProvider_0.GetError(this.txtbMapMaxMbar) == string.Empty) && (this.errorProvider_0.GetError(this.txtbMapMinMbar) == string.Empty)) && (this.mapSensorChangedDelegate_0 != null))
            {
                this.mapSensorChangedDelegate_0(this.getMinMbar, this.getMaxMbar, this.lstMapSensor.SelectedIndex + 2);
            }
        }

        internal void method_0(ref Class18 class18_1)
        {
            this.class18_0 = class18_1;
            this.bool_0 = true;
            this.lstMapSensor.SelectedIndex = 0;
            this.bool_0 = false;

            foreach (Control control in base.Controls)
            {
                float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
                control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
            }
        }

        private void method_2()
        {
            //Minimum and Maximum mBar values for each available MAP Sensors

            //Stock 1.75Bar"
            this.int_0[0, 0] = -70;
            this.int_0[0, 1] = 1790;

            //GM 2Bar
            this.int_0[1, 0] = 8;
            this.int_0[1, 1] = 2041;

            //GM 3Bar
            this.int_0[2, 0] = 11;
            this.int_0[2, 1] = 3155;

            //Motorola 2.5Bar
            this.int_0[3, 0] = 70;
            this.int_0[3, 1] = 2590;

            //AEM 3.5Bar
            this.int_0[4, 0] = -431;
            this.int_0[4, 1] = 3844;

            //AEM 5Bar
            this.int_0[5, 0] = -625;
            this.int_0[5, 1] = 5625;

            //Xenocron/Omni 3Bar
            this.int_0[6, 0] = 11;
            this.int_0[6, 1] = 3040;

            //Xenocron/Omni 4Bar
            this.int_0[7, 0] = 35;
            this.int_0[7, 1] = 4180;

            //Sparkks Racing 3Bar
            this.int_0[8, 0] = -132;
            this.int_0[8, 1] = 3163;

            //Custom Map Sensor
            this.int_0[9, 0] = -70;
            this.int_0[9, 1] = 1790;
        }

        private double method_3(int int_2, int int_3)
        {
            double num = 5.0 / (int_3 + Math.Abs((double) int_2));
            double num2 = this.class18_0.class10_settings_0.int_6 - int_2;
            return (num * num2);
        }

        private void method_4(NumericUpDown textBox_0)
        {
            textBox_0.Focus();
            textBox_0.Focus();
        }

        public void setMapSensor(int min, int max, int index)
        {
            this.bool_0 = true;
            this.txtbMapMinMbar.Text = min.ToString();
            this.txtbMapMaxMbar.Text = max.ToString();
            this.lstMapSensor.SelectedIndex = index;
            this.txtMapKoeo.Text = this.method_3(min, max).ToString("0.00");
            int IntegerVal = (int)((double.Parse(this.txtbMapMaxMbar.Text) - double.Parse(this.txtbMapMinMbar.Text)) / 5.0);
            this.txtScalar.Text = IntegerVal.ToString();
            this.bool_0 = false;
        }

        private void txtbMapMinMbar_TextChanged(object sender, EventArgs e)
        {
            if (!this.bool_0)
            {
                this.method_4((NumericUpDown)sender);

                //select 'custom' map sensor in the sensors list
                if (this.lstMapSensor.SelectedIndex != this.int_1)
                {
                    string PreviousText1 = this.txtbMapMinMbar.Text;
                    string PreviousText2 = this.txtbMapMaxMbar.Text;

                    this.bool_0 = true;
                    this.lstMapSensor.SelectedIndex = this.int_1 - 1;
                    this.txtbMapMinMbar.Text = PreviousText1;
                    this.txtbMapMaxMbar.Text = PreviousText2;
                    this.bool_0 = false;
                }

                txtbMapMinMbar_Validated(sender, e);
            }
        }

        private void txtbScalar_TextChanged(object sender, EventArgs e)
        {
            if (!this.bool_0)
            {
                this.method_4((NumericUpDown)sender);

                //select 'custom' map sensor in the sensors list
                if (this.lstMapSensor.SelectedIndex != this.int_1)
                {
                    string PreviousText1 = this.txtbMapMinMbar.Text;
                    string PreviousText2 = this.txtScalar.Text;

                    this.bool_0 = true;
                    this.lstMapSensor.SelectedIndex = this.int_1 - 1;
                    this.txtbMapMinMbar.Text = PreviousText1;
                    this.txtScalar.Text = PreviousText2;
                    this.bool_0 = false;
                }

                txtbScalar_Validated(sender, e);
            }
        }

        private void txtbMapMinMbar_Validated(object sender, EventArgs e)
        {
            if ((!this.bool_0 && (this.txtbMapMinMbar.Text != "")) && (this.txtbMapMaxMbar.Text != ""))
            {
                this.bool_0 = true;
                this.txtMapKoeo.Text = this.method_3(int.Parse(this.txtbMapMinMbar.Text), int.Parse(this.txtbMapMaxMbar.Text)).ToString("0.00");
                this.txtScalar.Text = ((double.Parse(this.txtbMapMaxMbar.Text) - double.Parse(this.txtbMapMinMbar.Text)) / 5.0).ToString();
                this.bool_0 = false;

                if (this.mapSensorChangedDelegate_0 != null)
                {
                    this.mapSensorChangedDelegate_0(this.getMinMbar, this.getMaxMbar, this.lstMapSensor.SelectedIndex + 2);
                }
                this.Invalidate();
            }
        }

        private void txtbScalar_Validated(object sender, EventArgs e)
        {
            if ((!this.bool_0 && (this.txtbMapMinMbar.Text != "")) && (this.txtbMapMaxMbar.Text != ""))
            {
                this.bool_0 = true;
                this.txtbMapMaxMbar.Text = ((double.Parse(this.txtScalar.Text) * 5.0) + double.Parse(this.txtbMapMinMbar.Text)).ToString();

                this.txtMapKoeo.Text = this.method_3(int.Parse(this.txtbMapMinMbar.Text), int.Parse(this.txtbMapMaxMbar.Text)).ToString("0.00");
                this.txtScalar.Text = ((double.Parse(this.txtbMapMaxMbar.Text) - double.Parse(this.txtbMapMinMbar.Text)) / 5.0).ToString();
                this.bool_0 = false;

                if (this.mapSensorChangedDelegate_0 != null)
                {
                    this.mapSensorChangedDelegate_0(this.getMinMbar, this.getMaxMbar, this.lstMapSensor.SelectedIndex + 2);
                }
                this.Invalidate();
            }
        }

        private void txtbMapMinMbar_Validating(object sender, CancelEventArgs e)
        {
            /*NumericUpDown control = (NumericUpDown) sender;
            if (!this.class18_0.method_255(control.Text.ToString()))
            {
                this.errorProvider_0.SetError(control, "Invalid input, integer required");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider_0.SetError(control, "");
            }*/
        }

        public int getMaxMbar
        {
            get
            {
                return int.Parse(this.txtbMapMaxMbar.Text);
            }
        }

        public int getMinMbar
        {
            get
            {
                return int.Parse(this.txtbMapMinMbar.Text);
            }
        }

        public delegate void MapSensorChangedDelegate(int MbarMin, int MbarMax, int Index);
    }
}

