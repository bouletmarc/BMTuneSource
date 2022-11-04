namespace Controls
{
    using Data;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ctrlMapValue : UserControl
    {
        private bool bool_0;
        private byte byte_0;
        private Class18 class18_0;
        private ComboBox cmbT;
        private ErrorProvider errorProvider_0;
        private IContainer icontainer_0;
        private IContainer components;
        private TextBox textBox1;

        public event MapValueChangedDelegate mapValueChangedDelegate_0;

        public ctrlMapValue()
        {
            this.InitializeComponent();
        }

        private void cmbT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = null;
            int num = this.class18_0.method_206(this.rawValue);
            switch (this.cmbT.SelectedIndex)
            {
                case 0:
                    str = num.ToString();
                    break;

                case 1:
                    str = Math.Round((double) (((float) num) / 1000f), 3).ToString();
                    break;

                case 2:
                    str = this.class18_0.method_246(num).ToString();
                    break;

                case 3:
                    str = this.class18_0.method_245(num).ToString();
                    break;

                case 4:
                    str = this.class18_0.method_248(num).ToString();
                    break;
            }
            this.textBox1.Text = str;
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbT = new System.Windows.Forms.ComboBox();
            this.errorProvider_0 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_0)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // cmbT
            // 
            this.cmbT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbT.FormattingEnabled = true;
            this.cmbT.Items.AddRange(new object[] {
            "mBar",
            "Bar",
            "inHG",
            "PSI",
            "kPa"});
            this.cmbT.Location = new System.Drawing.Point(61, 0);
            this.cmbT.Name = "cmbT";
            this.cmbT.Size = new System.Drawing.Size(49, 21);
            this.cmbT.TabIndex = 1;
            this.cmbT.SelectedIndexChanged += new System.EventHandler(this.cmbT_SelectedIndexChanged);
            // 
            // errorProvider_0
            // 
            this.errorProvider_0.ContainerControl = this;
            // 
            // ctrlMapValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbT);
            this.Controls.Add(this.textBox1);
            this.Name = "ctrlMapValue";
            this.Size = new System.Drawing.Size(114, 24);
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TextBox control = (TextBox) sender;
                this.cmbT.Focus();
                if (this.errorProvider_0.GetError(control) == string.Empty)
                {
                    this.textBox1_Validated(null, null);
                }
                control.Focus();
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            int num = 0;
            float num2 = float.Parse(this.textBox1.Text);
            switch (this.cmbT.SelectedIndex)
            {
                case 0:
                    num = (int) num2;
                    break;

                case 1:
                    num = (int) (num2 * 1000f);
                    break;

                case 2:
                    num = this.class18_0.method_247(num2);
                    break;

                case 3:
                    num = this.class18_0.method_250(num2);
                    break;

                case 4:
                    num = this.class18_0.method_249(num2);
                    break;
            }
            if (this.mapValueChangedDelegate_0 != null)
            {
                this.mapValueChangedDelegate_0(this.class18_0.method_226(num));
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
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
                this.textBox1_Validated(null, null);
            }
        }

        public byte rawValue
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
                if (this.class18_0 != null)
                {
                    if (this.class18_0.method_206(this.byte_0) < this.class18_0.class10_settings_0.int_6)
                    {
                        switch (this.class18_0.class10_settings_0.mapSensorUnits_0)
                        {
                            case MapSensorUnits.mBar:
                                this.cmbT.SelectedIndex = 0;
                                break;

                            case MapSensorUnits.inHgG:
                                this.cmbT.SelectedIndex = 2;
                                break;

                            case MapSensorUnits.inHg:
                                this.cmbT.SelectedIndex = 2;
                                break;

                            case MapSensorUnits.psi:
                                this.cmbT.SelectedIndex = 3;
                                break;

                            case MapSensorUnits.kPa:
                                this.cmbT.SelectedIndex = 4;
                                break;
                        }
                    }
                    else
                    {
                        switch (this.class18_0.class10_settings_0.mapSensorUnits_1)
                        {
                            case MapSensorUnits.mBar:
                                this.cmbT.SelectedIndex = 0;
                                break;

                            case MapSensorUnits.Bar:
                                this.cmbT.SelectedIndex = 1;
                                break;

                            case MapSensorUnits.inHg:
                                this.cmbT.SelectedIndex = 2;
                                break;

                            case MapSensorUnits.psi:
                                this.cmbT.SelectedIndex = 3;
                                break;

                            case MapSensorUnits.kPa:
                                this.cmbT.SelectedIndex = 4;
                                break;
                        }
                    }
                    this.bool_0 = true;
                    this.cmbT_SelectedIndexChanged(null, null);
                    this.bool_0 = false;
                }
            }
        }

        public delegate void MapValueChangedDelegate(byte raw);
    }
}

