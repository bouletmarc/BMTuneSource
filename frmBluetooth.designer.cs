
partial class frmBluetooth
{
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Uart = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_Bind = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmb_Role = new System.Windows.Forms.ComboBox();
            this.txt_Version = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_BuffVersion = new System.Windows.Forms.TextBox();
            this.txt_BuffPass = new System.Windows.Forms.TextBox();
            this.txt_BuffBind = new System.Windows.Forms.TextBox();
            this.txt_BuffID = new System.Windows.Forms.TextBox();
            this.txt_BuffUart = new System.Windows.Forms.TextBox();
            this.txt_BuffName = new System.Windows.Forms.TextBox();
            this.txt_BuffRole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.checkBoxAutoProgram = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(350, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.DropDown += new System.EventHandler(this.ComboBox1_DropDown);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "4800",
            "9600",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.comboBox2.Location = new System.Drawing.Point(231, 55);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(118, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(142, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Port :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(142, 153);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 24);
            this.button4.TabIndex = 23;
            this.button4.Text = "Set as Slave (ECU/CN2)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(142, 178);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(176, 24);
            this.button5.TabIndex = 24;
            this.button5.Text = "Set as Master (BMDatalogger)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Baud/Uart:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Role:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "ID Addresse:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Bind Addresse:";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(90, 23);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(137, 20);
            this.txt_Name.TabIndex = 30;
            // 
            // txt_Uart
            // 
            this.txt_Uart.Location = new System.Drawing.Point(90, 67);
            this.txt_Uart.Name = "txt_Uart";
            this.txt_Uart.Size = new System.Drawing.Size(137, 20);
            this.txt_Uart.TabIndex = 31;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(90, 111);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(137, 20);
            this.txt_ID.TabIndex = 33;
            // 
            // txt_Bind
            // 
            this.txt_Bind.Location = new System.Drawing.Point(90, 133);
            this.txt_Bind.Name = "txt_Bind";
            this.txt_Bind.Size = new System.Drawing.Size(137, 20);
            this.txt_Bind.TabIndex = 34;
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Blue;
            this.button6.Location = new System.Drawing.Point(17, 153);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 24);
            this.button6.TabIndex = 35;
            this.button6.Text = "Get Adapter Infos";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "HC05",
            "JDY-31",
            "ZS-040/HC06",
            "HC06 Old"});
            this.comboBox4.Location = new System.Drawing.Point(96, 80);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(131, 21);
            this.comboBox4.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(124, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(219, 24);
            this.label16.TabIndex = 37;
            this.label16.Text = "Bluetooth Programmer";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(90, 155);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(137, 20);
            this.txt_Pass.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 158);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Password:";
            // 
            // cmb_Role
            // 
            this.cmb_Role.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Role.FormattingEnabled = true;
            this.cmb_Role.Items.AddRange(new object[] {
            "Slave",
            "Master",
            "Slave Loop"});
            this.cmb_Role.Location = new System.Drawing.Point(90, 89);
            this.cmb_Role.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Role.Name = "cmb_Role";
            this.cmb_Role.Size = new System.Drawing.Size(137, 21);
            this.cmb_Role.TabIndex = 40;
            // 
            // txt_Version
            // 
            this.txt_Version.Location = new System.Drawing.Point(90, 45);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.Size = new System.Drawing.Size(137, 20);
            this.txt_Version.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Version:";
            // 
            // txt_BuffVersion
            // 
            this.txt_BuffVersion.Location = new System.Drawing.Point(18, 45);
            this.txt_BuffVersion.Name = "txt_BuffVersion";
            this.txt_BuffVersion.ReadOnly = true;
            this.txt_BuffVersion.Size = new System.Drawing.Size(137, 20);
            this.txt_BuffVersion.TabIndex = 56;
            // 
            // txt_BuffPass
            // 
            this.txt_BuffPass.Location = new System.Drawing.Point(18, 155);
            this.txt_BuffPass.Name = "txt_BuffPass";
            this.txt_BuffPass.ReadOnly = true;
            this.txt_BuffPass.Size = new System.Drawing.Size(137, 20);
            this.txt_BuffPass.TabIndex = 53;
            // 
            // txt_BuffBind
            // 
            this.txt_BuffBind.Location = new System.Drawing.Point(18, 133);
            this.txt_BuffBind.Name = "txt_BuffBind";
            this.txt_BuffBind.ReadOnly = true;
            this.txt_BuffBind.Size = new System.Drawing.Size(137, 20);
            this.txt_BuffBind.TabIndex = 51;
            // 
            // txt_BuffID
            // 
            this.txt_BuffID.Location = new System.Drawing.Point(18, 111);
            this.txt_BuffID.Name = "txt_BuffID";
            this.txt_BuffID.Size = new System.Drawing.Size(137, 20);
            this.txt_BuffID.TabIndex = 50;
            // 
            // txt_BuffUart
            // 
            this.txt_BuffUart.Location = new System.Drawing.Point(18, 67);
            this.txt_BuffUart.Name = "txt_BuffUart";
            this.txt_BuffUart.ReadOnly = true;
            this.txt_BuffUart.Size = new System.Drawing.Size(137, 20);
            this.txt_BuffUart.TabIndex = 49;
            // 
            // txt_BuffName
            // 
            this.txt_BuffName.Location = new System.Drawing.Point(18, 23);
            this.txt_BuffName.Name = "txt_BuffName";
            this.txt_BuffName.ReadOnly = true;
            this.txt_BuffName.Size = new System.Drawing.Size(137, 20);
            this.txt_BuffName.TabIndex = 48;
            // 
            // txt_BuffRole
            // 
            this.txt_BuffRole.Location = new System.Drawing.Point(18, 89);
            this.txt_BuffRole.Name = "txt_BuffRole";
            this.txt_BuffRole.ReadOnly = true;
            this.txt_BuffRole.Size = new System.Drawing.Size(137, 20);
            this.txt_BuffRole.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Adapter :";
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(17, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 24);
            this.button3.TabIndex = 61;
            this.button3.Text = "Reset to Defaults";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_BuffName);
            this.groupBox1.Controls.Add(this.txt_BuffUart);
            this.groupBox1.Controls.Add(this.txt_BuffID);
            this.groupBox1.Controls.Add(this.txt_BuffBind);
            this.groupBox1.Controls.Add(this.txt_BuffRole);
            this.groupBox1.Controls.Add(this.txt_BuffPass);
            this.groupBox1.Controls.Add(this.txt_BuffVersion);
            this.groupBox1.Location = new System.Drawing.Point(291, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 184);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last Adapter Infos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.txt_Name);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txt_Version);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txt_Uart);
            this.groupBox2.Controls.Add(this.cmb_Role);
            this.groupBox2.Controls.Add(this.txt_ID);
            this.groupBox2.Controls.Add(this.txt_Pass);
            this.groupBox2.Controls.Add(this.txt_Bind);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(10, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 184);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Adapter Infos";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(228, 154);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(37, 21);
            this.button14.TabIndex = 71;
            this.button14.Text = "Set";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(228, 132);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(37, 21);
            this.button13.TabIndex = 70;
            this.button13.Text = "Set";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(228, 88);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(37, 21);
            this.button11.TabIndex = 68;
            this.button11.Text = "Set";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(228, 66);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(37, 21);
            this.button10.TabIndex = 67;
            this.button10.Text = "Set";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(228, 22);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(37, 21);
            this.button8.TabIndex = 65;
            this.button8.Text = "Set";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(319, 178);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 24);
            this.button7.TabIndex = 64;
            this.button7.Text = "Set as Last Adapter";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(470, 9);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(269, 392);
            this.textBox2.TabIndex = 43;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(319, 153);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(128, 24);
            this.button9.TabIndex = 65;
            this.button9.Text = "Clear Logs";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // checkBoxAutoProgram
            // 
            this.checkBoxAutoProgram.AutoSize = true;
            this.checkBoxAutoProgram.Location = new System.Drawing.Point(233, 82);
            this.checkBoxAutoProgram.Name = "checkBoxAutoProgram";
            this.checkBoxAutoProgram.Size = new System.Drawing.Size(116, 17);
            this.checkBoxAutoProgram.TabIndex = 66;
            this.checkBoxAutoProgram.Text = "Autoprogram each:";
            this.checkBoxAutoProgram.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "sec";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(354, 81);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown1.TabIndex = 68;
            this.numericUpDown1.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // frmBluetooth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(744, 408);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxAutoProgram);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBluetooth";
            this.ShowIcon = false;
            this.Text = "Bluetooth Programmer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox txt_Name;
    private System.Windows.Forms.TextBox txt_Uart;
    private System.Windows.Forms.TextBox txt_ID;
    private System.Windows.Forms.TextBox txt_Bind;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.ComboBox comboBox4;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox txt_Pass;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.ComboBox cmb_Role;
    private System.Windows.Forms.TextBox txt_Version;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.TextBox txt_BuffVersion;
    private System.Windows.Forms.TextBox txt_BuffPass;
    private System.Windows.Forms.TextBox txt_BuffBind;
    private System.Windows.Forms.TextBox txt_BuffID;
    private System.Windows.Forms.TextBox txt_BuffUart;
    private System.Windows.Forms.TextBox txt_BuffName;
    private System.Windows.Forms.TextBox txt_BuffRole;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button button14;
    private System.Windows.Forms.Button button13;
    private System.Windows.Forms.Button button11;
    private System.Windows.Forms.Button button10;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;
    private System.Windows.Forms.CheckBox checkBoxAutoProgram;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
}

