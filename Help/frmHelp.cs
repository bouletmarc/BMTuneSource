namespace Help
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class frmHelp : Form
    {
        private IContainer icontainer_0;
        private Panel panel1;
        private TreeView treeView;
        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private LinkLabel linkLabel2;
        private UserControl userControl_0;

        public frmHelp()
        {
            this.InitializeComponent();

            LoadHelp();
        }

        private void LoadHelp()
        {
            treeView.Nodes.Clear();

            string[] AllFilesNames = Directory.GetFiles(Application.StartupPath + @"\Help\", "*.txt");
            for (int i = 0; i < AllFilesNames.Length; i++)
            {
                string[] AllLines = File.ReadAllLines(AllFilesNames[i]);

                for (int i2 = 0; i2 < AllLines.Length; i2++)
                {
                    if (AllLines[i2].Contains("CATEGORY=")) SearchAndAdd(AllLines[i2].Substring(9), Path.GetFileName(AllFilesNames[i]));
                }
            }
        }

        public void SearchAndAdd(string ThisNode, string FileName)
        {
            string[] AllNodes = ThisNode.Split('\\');

            for (int iLoop = 0; iLoop < AllNodes.Length; iLoop++)
            {
                bool Found1 = false;
                for (int i = 0; i < treeView.Nodes.Count; i++)
                {
                    if (treeView.Nodes[i].Text == AllNodes[0])
                    {
                        Found1 = true;

                        if (AllNodes.Length > 1)
                        {
                            bool Found2 = false;
                            for (int i2 = 0; i2 < treeView.Nodes[i].Nodes.Count; i2++)
                            {
                                if (treeView.Nodes[i].Nodes[i2].Text == AllNodes[1])
                                {
                                    Found2 = true;

                                    if (AllNodes.Length > 2)
                                    {
                                        bool Found3 = false;
                                        for (int i3 = 0; i3 < treeView.Nodes[i].Nodes[i2].Nodes.Count; i3++)
                                        {
                                            if (treeView.Nodes[i].Nodes[i2].Nodes[i3].Text == AllNodes[2]) Found3 = true;
                                        }

                                        if (!Found3)
                                        {
                                            treeView.Nodes[i].Nodes[i2].Nodes.Add(AllNodes[2]);
                                            if (AllNodes.Length == 3) treeView.Nodes[i].Nodes[i2].Nodes[treeView.Nodes[i].Nodes[i2].Nodes.Count - 1].Tag = FileName;
                                        }
                                    }
                                }
                            }

                            if (!Found2)
                            {
                                treeView.Nodes[i].Nodes.Add(AllNodes[1]);
                                if (AllNodes.Length == 2) treeView.Nodes[i].Nodes[treeView.Nodes[i].Nodes.Count - 1].Tag = FileName;
                            }
                        }
                    }
                }

                if (!Found1)
                {
                    treeView.Nodes.Add(AllNodes[0]);
                    if (AllNodes.Length == 1) treeView.Nodes[treeView.Nodes.Count - 1].Tag = FileName;
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp));
            this.treeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(11, 13);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(171, 443);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(191, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 564);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "If you have a specific question\r\nand this menu doesn\'t help,\r\nYou can:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(7, 515);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(148, 14);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ask on the facebook page";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ask bouletmarc@hotmail.com";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(7, 553);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(153, 14);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Ask on the facebook group";
            this.linkLabel2.Visible = false;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 590);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BMTune Help";
            this.Load += new System.EventHandler(this.frmHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.userControl_0 != null)
            {
                this.userControl_0.Dispose();
                this.userControl_0 = null;
            }

            if (e.Node != null)
            {
                if (e.Node.Tag != null)
                {
                    if (e.Node.Tag.ToString().Contains(".txt"))
                    {
                        this.userControl_0 = new parmHelpNew(e.Node.Tag.ToString());
                    }
                }
            }

            frmHelp_Load(sender, e);
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            if (this.userControl_0 != null)
            {
                this.userControl_0.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(this.userControl_0);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/BMTuneSoftware/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/groups/BMTune/");
        }
    }
}

