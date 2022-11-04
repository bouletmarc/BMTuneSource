using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmShortKeys : Form
{
    private ColumnHeader columnHeader_0;
    private ColumnHeader columnHeader_1;
    private IContainer icontainer_0;
    private ListView listView;
    private Label label1;
    private Label label2;
    private CheckBox chk_CTRL;
    private Label label3;
    private CheckBox chk_ALT;
    private CheckBox chk_SHIFT;
    private ComboBox comboBox1;
    private Button button1;
    private TreeView treeView;
    private FrmMain frmMain_0;

    public frmShortKeys(ref FrmMain frmMain_1)
    {
        this.InitializeComponent();
        label3.Text = "";
        this.frmMain_0 = frmMain_1;

        for (int i = 0; i < this.frmMain_0.class28_Shortcuts_0.KeysList.Count; i++) this.comboBox1.Items.Add(this.frmMain_0.class28_Shortcuts_0.KeysList[i]);
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Fuel & Ignition Tables");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Emulator");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Datalogging");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Datalogging Graphs/Display");
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "test",
            "dfa"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShortKeys));
            this.treeView = new System.Windows.Forms.TreeView();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader_0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_CTRL = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_ALT = new System.Windows.Forms.CheckBox();
            this.chk_SHIFT = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(14, 61);
            this.treeView.Name = "treeView";
            treeNode1.Name = "main";
            treeNode1.Text = "General";
            treeNode2.Name = "table";
            treeNode2.Text = "Fuel & Ignition Tables";
            treeNode3.Name = "emulator";
            treeNode3.Text = "Emulator";
            treeNode4.Name = "datalog";
            treeNode4.Text = "Datalogging";
            treeNode5.Name = "datalogG";
            treeNode5.Text = "Datalogging Graphs/Display";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(193, 257);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_0,
            this.columnHeader_1});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView.Location = new System.Drawing.Point(215, 61);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(424, 257);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // columnHeader_0
            // 
            this.columnHeader_0.Text = "Keys";
            this.columnHeader_0.Width = 130;
            // 
            // columnHeader_1
            // 
            this.columnHeader_1.Text = "Description";
            this.columnHeader_1.Width = 270;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Shortcut Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shortcut Keys:";
            // 
            // chk_CTRL
            // 
            this.chk_CTRL.AutoSize = true;
            this.chk_CTRL.Location = new System.Drawing.Point(160, 32);
            this.chk_CTRL.Name = "chk_CTRL";
            this.chk_CTRL.Size = new System.Drawing.Size(54, 18);
            this.chk_CTRL.TabIndex = 4;
            this.chk_CTRL.Text = "CTRL";
            this.chk_CTRL.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // chk_ALT
            // 
            this.chk_ALT.AutoSize = true;
            this.chk_ALT.Location = new System.Drawing.Point(220, 32);
            this.chk_ALT.Name = "chk_ALT";
            this.chk_ALT.Size = new System.Drawing.Size(46, 18);
            this.chk_ALT.TabIndex = 6;
            this.chk_ALT.Text = "ALT";
            this.chk_ALT.UseVisualStyleBackColor = true;
            // 
            // chk_SHIFT
            // 
            this.chk_SHIFT.AutoSize = true;
            this.chk_SHIFT.Location = new System.Drawing.Point(272, 32);
            this.chk_SHIFT.Name = "chk_SHIFT";
            this.chk_SHIFT.Size = new System.Drawing.Size(57, 18);
            this.chk_SHIFT.TabIndex = 7;
            this.chk_SHIFT.Text = "SHIFT";
            this.chk_SHIFT.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(335, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 22);
            this.comboBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(565, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // frmShortKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 331);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chk_SHIFT);
            this.Controls.Add(this.chk_ALT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk_CTRL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.treeView);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShortKeys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shortcut Keys";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        switch (e.Node.Name)
        {
            case "main":
                this.listView.Items.Clear();
                this.listView.Items.Add("Ctrl + N");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("New Basemap");
                this.listView.Items.Add("Ctrl + O");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open File");
                this.listView.Items.Add("Ctrl + S");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Save File As");
                this.listView.Items.Add("Alt + S");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Save File");
                this.listView.Items.Add("Ctrl + Q");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Quit");
                this.listView.Items.Add("Ctrl + C");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Copy");
                this.listView.Items.Add("Ctrl + V");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Paste");
                this.listView.Items.Add("Ctrl + Z");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Undo");
                this.listView.Items.Add("Ctrl + Y");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Redo");
                this.listView.Items.Add("Ctrl + T");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open Tables");
                this.listView.Items.Add("Ctrl + P");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open Parameters");
                this.listView.Items.Add("Ctrl + E");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open Error Code");
                this.listView.Items.Add("Ctrl + I");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open Timing Sync");
                this.listView.Items.Add("Ctrl + B");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open Boost Table");
                this.listView.Items.Add("Ctrl + Q");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open Snapshots List");
                this.listView.Items.Add("Ctrl + Alt + T");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open TPS Calibration");
                this.listView.Items.Add("Ctrl + K");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Kill Injectors");
                this.listView.Items.Add("Ctrl + F");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Kill Fuel Pump (Off)");
                ResetKeyValue();
                return;

            case "table":
                this.listView.Items.Clear();
                this.listView.Items.Add("F1");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Primary Low Ignition");
                this.listView.Items.Add("F2");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Primary High Ignition");
                this.listView.Items.Add("F3");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Primary Low Fuel");
                this.listView.Items.Add("F4");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Primary High Fuel");
                this.listView.Items.Add("Shift + F1");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Secondary Low Ignition");
                this.listView.Items.Add("Shift + F2");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Secondary High Ignition");
                this.listView.Items.Add("Shift + F3");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Secondary Low Fuel");
                this.listView.Items.Add("Shift + F4");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Secondary High Fuel");
                this.listView.Items.Add("F5");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show Map Values");
                this.listView.Items.Add("F6");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show A/F Target");
                this.listView.Items.Add("F7");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show A/F Reading");
                this.listView.Items.Add("F8");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show Fuel Difference");
                this.listView.Items.Add("F9");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show VE Table");
                this.listView.Items.Add("F10");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show Raw Fuel Value");
                this.listView.Items.Add("F11");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show Fuel Duty Cycle");
                this.listView.Items.Add("F12");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Show Injector Duration");
                this.listView.Items.Add("Shift + F5");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Graph 2D View");
                this.listView.Items.Add("Shift + F6");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Graph 3D View");
                this.listView.Items.Add("Shift + F7");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Graph 2D/3D View - Bellow Table");
                this.listView.Items.Add("Shift + F8");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Graph 2D/3D View - Only N/A");
                this.listView.Items.Add("Ctrl + Up");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Increase Selected Cells");
                this.listView.Items.Add("Ctrl + Down");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Decrease Selected Cells");
                this.listView.Items.Add("Ctrl + J");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Adjust Selection");
                this.listView.Items.Add("Page Up");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Increase Selected Cells #2");
                this.listView.Items.Add("Page Down");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Decrease Selected Cells #2");
                this.listView.Items.Add("Ctrl + Shift + G");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Clear Current Selection");
                this.listView.Items.Add("Ctrl + Shift + M");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Smooth current selection/map");
                this.listView.Items.Add("Ctrl + Shift + R");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Interpolate rows");
                this.listView.Items.Add("Ctrl + Shift + C");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Interpolate columns");
                this.listView.Items.Add("Ctrl + Shift + I");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Interpolate All X & Y");
                this.listView.Items.Add("Shift + Alt + Left");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Increase map size width");
                this.listView.Items.Add("Shift + Alt + Right");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Decrease map size width");
                this.listView.Items.Add("Alt + M");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Map trail toggle");
                this.listView.Items.Add("Ctrl + Alt + C");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Clear all recording");
                this.listView.Items.Add("Shift + F10");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Clear live plot");
                this.listView.Items.Add("Alt + V");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Follow Vtec");
                this.listView.Items.Add("Alt + D");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Follow Secondary Map");

                this.listView.Items.Add("2D/3D Editing:");
                this.listView.Items.Add("Right Clic + Move");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Select cells in visual mode");
                this.listView.Items.Add("Left Clic + Move");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Adjust selected cells in visual mode");
                this.listView.Items.Add("Escape");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Press escape to cancel the current dragging");
                ResetKeyValue();
                return;

            case "emulator":
                this.listView.Items.Clear();
                this.listView.Items.Add("Ctrl + Shift + E");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Connect to emulator");
                this.listView.Items.Add("Ctrl + Shift + P");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Upload Rom");
                this.listView.Items.Add("Ctrl + Shift + G");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Get Rom");
                this.listView.Items.Add("Ctrl + Shift + V");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Verify Rom");
                this.listView.Items.Add("Ctrl + Shift + C");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Upload calibration");
                this.listView.Items.Add("Ctrl + Shift + T");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Realtime update toggle");
                ResetKeyValue();
                return;

            case "datalog":
                this.listView.Items.Clear();
                this.listView.Items.Add("Ctrl + Alt + D");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Connect to ecu/datalogging");
                this.listView.Items.Add("Ctrl + Alt + L");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Open datalog file");
                this.listView.Items.Add("Ctrl + Alt + S");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Save datalog file");
                this.listView.Items.Add("Ctrl + Alt + Up");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Play datalog file");
                this.listView.Items.Add("Ctrl + Alt + Down");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Pause datalog file");
                this.listView.Items.Add("Ctrl + L");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Scroll tru datalog file");
                this.listView.Items.Add("Alt + T");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Smart track toggle");
                this.listView.Items.Add("Alt + M");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Map trail toggle");
                this.listView.Items.Add("Ctrl + D");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Datalog Display");
                this.listView.Items.Add("Ctrl + S");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Datalog Data");
                this.listView.Items.Add("Ctrl + G");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Datalog Graphs");
                ResetKeyValue();
                return;

            case "datalogG":
                this.listView.Items.Clear();
                this.listView.Items.Add("Ctrl + Left");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Move datalog cursor left");
                this.listView.Items.Add("Ctrl + Right");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Move datalog cursor right");
                this.listView.Items.Add("Ctrl + Shift + Left");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Move datalog cursor large step left");
                this.listView.Items.Add("Ctrl + Shift + Right");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Move datalog cursor large step right");
                this.listView.Items.Add("Ctrl + Shift + Up");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Zoom in");
                this.listView.Items.Add("Ctrl + Shift + Down");
                this.listView.Items[this.listView.Items.Count - 1].SubItems.Add("Zoom out");
                ResetKeyValue();
                return;
        }
    }

    private void ResetKeyValue()
    {
        for (int i = 0; i < this.listView.Items.Count; i++)
        {
            if (this.listView.Items[i].SubItems.Count > 1)
            //if (this.listView.SelectedItems[0].SubItems.Count > 1)
            {
                if (this.frmMain_0.class10_settings_0.GetKeySettings(this.listView.Items[i].SubItems[1].Text))
                //if (this.frmMain_0.class10_settings_0.GetKeySettings(this.listView.SelectedItems[0].SubItems[1].Text))
                {
                    string KeyValue = "";
                    if (this.frmMain_0.class10_settings_0.Shortcut_PressCTRL) KeyValue += "Ctrl + ";
                    if (this.frmMain_0.class10_settings_0.Shortcut_PressALT) KeyValue += "Alt + ";
                    if (this.frmMain_0.class10_settings_0.Shortcut_PressSHIFT) KeyValue += "Shift + ";
                    KeyValue += this.frmMain_0.class10_settings_0.Shortcut_KeyName;

                    this.listView.Items[i].SubItems[0].Text = KeyValue;
                    //this.listView.SelectedItems[0].SubItems[0].Text = KeyValue;
                }
            }
        }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        if (label3.Text != "")
        {
            string ShortcutString = "";
            ShortcutString += this.chk_CTRL.Checked.ToString() + "~";
            ShortcutString += this.chk_ALT.Checked.ToString() + "~";
            ShortcutString += this.chk_SHIFT.Checked.ToString() + "~";
            ShortcutString += this.comboBox1.Text + "~";
            ShortcutString += label3.Text;
            this.frmMain_0.class10_settings_0.SaveThisShortcuts(ShortcutString);
        }
    }

    private void ListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.listView.SelectedItems.Count > 0)
        {
            if (this.listView.SelectedItems[0].SubItems.Count > 1)
            {
                string Desc = this.listView.SelectedItems[0].SubItems[1].Text;

                for (int i = 0; i < this.frmMain_0.class10_settings_0.ShortcutsKeys.Count; i++)
                {
                    if (this.frmMain_0.class10_settings_0.ShortcutsKeys[i].Contains("~"))
                    {
                        string[] SplittedCMD2 = this.frmMain_0.class10_settings_0.ShortcutsKeys[i].Split('~');
                        if (Desc == SplittedCMD2[4])
                        {
                            //find exact string
                            int ThisIndex = this.comboBox1.FindStringExact(SplittedCMD2[3]);
                            if (ThisIndex != -1)
                            {
                                this.chk_CTRL.Checked = bool.Parse(SplittedCMD2[0]);
                                this.chk_ALT.Checked = bool.Parse(SplittedCMD2[1]);
                                this.chk_SHIFT.Checked = bool.Parse(SplittedCMD2[2]);
                                this.comboBox1.SelectedIndex = ThisIndex;
                                this.label3.Text = SplittedCMD2[4];
                            }
                            else
                            {
                                //not founf find possible match
                                ThisIndex = this.comboBox1.FindString(SplittedCMD2[3]);
                            }
                            if (ThisIndex != -1)
                            {
                                this.chk_CTRL.Checked = bool.Parse(SplittedCMD2[0]);
                                this.chk_ALT.Checked = bool.Parse(SplittedCMD2[1]);
                                this.chk_SHIFT.Checked = bool.Parse(SplittedCMD2[2]);
                                this.comboBox1.SelectedIndex = ThisIndex;
                                this.label3.Text = SplittedCMD2[4];

                            }

                            i = this.frmMain_0.class10_settings_0.ShortcutsKeys.Count;
                        }
                    }
                }
            }
        }
    }
}

