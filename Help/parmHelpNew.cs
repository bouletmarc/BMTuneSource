namespace Help
{
    using System;
    using System.IO;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class parmHelpNew : UserControl
    {
        private IContainer icontainer_0;
        private IContainer components;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label label1;

        private int CurrentHeight = 0;
        private int CurrentSide = 30;

        private bool IsLoadingPage = false;

        public parmHelpNew(string FileName)
        {
            this.InitializeComponent();

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            LoadFile(FileName);
        }

        private void LoadFile(string FileName)
        {
            FileInfo info = new FileInfo(Application.StartupPath + @"\Help\" + FileName);
            if (info.Exists)
            {
                string[] AllLine = File.ReadAllLines(Application.StartupPath + @"\Help\" + FileName);

                for (int i = 0; i < AllLine.Length; i++)
                {
                    //if (AllLine[i].Contains("HEIGHT=")) this.panel1.Height = int.Parse(AllLine[i].Substring(AllLine[i].LastIndexOf('=') + 1));
                    if (AllLine[i].Contains("PAGE_DESCRIPTION_START_HERE")) IsLoadingPage = true;

                    if (IsLoadingPage)
                    {
                        if (AllLine[i] == "") CurrentHeight += 16;
                        else if (AllLine[i].Contains("IMG1=") || AllLine[i].Contains("IMG2=") || AllLine[i].Contains("IMG3=") || AllLine[i].Contains("IMG4=") || AllLine[i].Contains("IMG5=") || AllLine[i].Contains("IMG6="))
                        {
                            string IMGName = Application.StartupPath + @"\Help\Img\" + AllLine[i].Substring(AllLine[i].LastIndexOf('=') + 1);
                            Image ThisImage = Image.FromFile(IMGName);

                            if (AllLine[i].Contains("IMG1="))
                            {
                                pictureBox1.Visible = true;
                                pictureBox1.BackgroundImage = ThisImage;
                                pictureBox1.Height = ThisImage.Height;
                                pictureBox1.Width = ThisImage.Width;
                                pictureBox1.Location = new Point((panel1.Width/2) - (pictureBox1.Width / 2), CurrentHeight);
                            }
                            if (AllLine[i].Contains("IMG2="))
                            {
                                pictureBox2.Visible = true;
                                pictureBox2.BackgroundImage = ThisImage;
                                pictureBox2.Height = ThisImage.Height;
                                pictureBox2.Width = ThisImage.Width;
                                pictureBox2.Location = new Point((panel1.Width / 2) - (pictureBox2.Width / 2), CurrentHeight);
                            }
                            if (AllLine[i].Contains("IMG3="))
                            {
                                pictureBox3.Visible = true;
                                pictureBox3.BackgroundImage = ThisImage;
                                pictureBox3.Height = ThisImage.Height;
                                pictureBox3.Width = ThisImage.Width;
                                pictureBox3.Location = new Point((panel1.Width / 2) - (pictureBox3.Width / 2), CurrentHeight);
                            }
                            if (AllLine[i].Contains("IMG4="))
                            {
                                pictureBox4.Visible = true;
                                pictureBox4.BackgroundImage = ThisImage;
                                pictureBox4.Height = ThisImage.Height;
                                pictureBox4.Width = ThisImage.Width;
                                pictureBox4.Location = new Point((panel1.Width / 2) - (pictureBox4.Width / 2), CurrentHeight);
                            }
                            if (AllLine[i].Contains("IMG5="))
                            {
                                pictureBox5.Visible = true;
                                pictureBox5.BackgroundImage = ThisImage;
                                pictureBox5.Height = ThisImage.Height;
                                pictureBox5.Width = ThisImage.Width;
                                pictureBox5.Location = new Point((panel1.Width / 2) - (pictureBox5.Width / 2), CurrentHeight);
                            }
                            if (AllLine[i].Contains("IMG6="))
                            {
                                pictureBox6.Visible = true;
                                pictureBox6.BackgroundImage = ThisImage;
                                pictureBox6.Height = ThisImage.Height;
                                pictureBox6.Width = ThisImage.Width;
                                pictureBox6.Location = new Point((panel1.Width / 2) - (pictureBox6.Width / 2), CurrentHeight);
                            }

                            CurrentHeight += ThisImage.Height;
                        }
                        else if (AllLine[i].Contains("LABEL1=") || AllLine[i].Contains("LABEL2=") || AllLine[i].Contains("LABEL3=") || AllLine[i].Contains("LABEL4=") || AllLine[i].Contains("LABEL5=") || AllLine[i].Contains("LABEL6="))
                        {
                            int DoingThis = 1;
                            if (AllLine[i].Contains("LABEL1=")) DoingThis = 1;
                            if (AllLine[i].Contains("LABEL2=")) DoingThis = 2;
                            if (AllLine[i].Contains("LABEL3=")) DoingThis = 3;
                            if (AllLine[i].Contains("LABEL4=")) DoingThis = 4;
                            if (AllLine[i].Contains("LABEL5=")) DoingThis = 5;
                            if (AllLine[i].Contains("LABEL6=")) DoingThis = 6;

                            CurrentSide = 30;
                            if (AllLine[i].Contains("CENTER"))
                            {
                                if (DoingThis == 1) label1.TextAlign = ContentAlignment.TopCenter;
                                if (DoingThis == 2) label2.TextAlign = ContentAlignment.TopCenter;
                                if (DoingThis == 3) label3.TextAlign = ContentAlignment.TopCenter;
                                if (DoingThis == 4) label4.TextAlign = ContentAlignment.TopCenter;
                                if (DoingThis == 5) label5.TextAlign = ContentAlignment.TopCenter;
                                if (DoingThis == 6) label6.TextAlign = ContentAlignment.TopCenter;
                                CurrentSide = (panel1.Width / 2);
                            }

                            i++;
                            bool IsLabeling = true;
                            string LabelText = "";
                            int StartHeight = CurrentHeight;
                            while (IsLabeling)
                            {
                                if (AllLine[i].Contains("!LABEL")) IsLabeling = false;
                                else
                                {
                                    LabelText += AllLine[i] + Environment.NewLine;
                                    CurrentHeight += 16;
                                }
                                i++;
                            }

                            if (DoingThis == 1)
                            {
                                label1.Visible = true;
                                label1.Location = new Point(CurrentSide, StartHeight);
                                label1.Text = LabelText;
                            }
                            if (DoingThis == 2)
                            {
                                label2.Visible = true;
                                label2.Location = new Point(CurrentSide, StartHeight);
                                label2.Text = LabelText;
                            }
                            if (DoingThis == 3)
                            {
                                label3.Visible = true;
                                label3.Location = new Point(CurrentSide, StartHeight);
                                label3.Text = LabelText;
                            }
                            if (DoingThis == 4)
                            {
                                label4.Visible = true;
                                label4.Location = new Point(CurrentSide, StartHeight);
                                label4.Text = LabelText;
                            }
                            if (DoingThis == 5)
                            {
                                label5.Visible = true;
                                label5.Location = new Point(CurrentSide, StartHeight);
                                label5.Text = LabelText;
                            }
                            if (DoingThis == 6)
                            {
                                label6.Visible = true;
                                label6.Location = new Point(CurrentSide, StartHeight);
                                label6.Text = LabelText;
                            }
                        }
                        
                    }
                }

                this.panel1.Height = CurrentHeight + 20;
            }
            info = null;
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(51, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 507);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(345, 31);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(41, 40);
            this.pictureBox6.TabIndex = 10;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(285, 31);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(41, 40);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(226, 31);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(41, 40);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(167, 31);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 40);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(110, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 40);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // parmHelpNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "parmHelpNew";
            this.Size = new System.Drawing.Size(668, 564);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

