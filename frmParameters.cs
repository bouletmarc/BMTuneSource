//using PropertiesRes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class frmParameters : Form
{
    private Class18 class18_0;
    private FrmMain frmMain_0;
    private IContainer icontainer_0;
    public SplitContainer splitContainer1;
    private TreeView treeView;
    private UserControl userControl_0;
    public bool loading = true;

    public frmParameters()
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

    private void frmParameters_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (this.class18_0.class10_settings_0.WindowedMode) this.class18_0.class10_settings_0.parameters_Location = base.Location;
        this.frmMain_0.frmParameters_0.Dispose();
        this.frmMain_0.frmParameters_0 = null;
    }

    private void frmParameters_Load(object sender, EventArgs e)
    {
        if (this.class18_0.class10_settings_0 != null)
        {
            if (this.class18_0.class10_settings_0.WindowedMode)
            {
                //this.FormBorderStyle = FormBorderStyle.Sizable;
                //this.Dock = DockStyle.None;
                base.Location = this.class18_0.class10_settings_0.parameters_Location;
                base.Size = this.class18_0.class10_settings_0.parameters_Size;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
            }
        }
        loading = false;

        try
        {
            if (((this.class18_0.class10_settings_0.parameterNode != null) && (this.class18_0 != null)) && this.class18_0.method_30_HasFileLoadedInBMTune())
            {
                string parameterNode = this.class18_0.class10_settings_0.parameterNode;
                foreach (TreeNode node in this.treeView.Nodes.Find(parameterNode, true))
                {
                    this.treeView.SelectedNode = node;
                    this.treeView.SelectedNode.EnsureVisible();
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(Form.ActiveForm, exception.Message);
        }
        if (this.class18_0 == null)
        {
            this.treeView.Enabled = false;
            this.splitContainer1.Panel2.Enabled = false;
            this.Text = "Parameters";
        }
        else if (!this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.treeView.Enabled = false;
            this.splitContainer1.Panel2.Enabled = false;
            this.Text = "Parameters";
        }
        else
        {
            this.treeView.Enabled = true;
            this.splitContainer1.Panel2.Enabled = true;
            this.Text = "Parameters";
            if (this.userControl_0 != null)
            {
                this.userControl_0.Dock = DockStyle.Fill;
                this.splitContainer1.Panel2.Controls.Add(this.userControl_0);
            }
        }
    }

    private void frmParameters_ResizeEnd(object sender, EventArgs e)
    {
        if (this.class18_0 != null)
        {
            if (this.class18_0.class10_settings_0 != null)
            {
                if (this.class18_0.class10_settings_0.WindowedMode && !loading)
                {
                    if (base.WindowState == FormWindowState.Normal)
                    {
                        try
                        {
                            if (frmMain_0.frmGridChart_0 != null) frmMain_0.frmGridChart_0.RefreshPage();
                        }
                        catch { }
                        this.class18_0.class10_settings_0.parameters_Size = base.Size;
                    }
                    this.class18_0.class10_settings_0.parameters_Location = base.Location;
                }
            }
        }
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Options/Sensors");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Idle Settings");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("VTEC Settings");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Rev Limits");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MIL ShiftLight");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Close Loop");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Map Sensor");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("TPS Sensor");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Fan Control");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Transmission");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Main Settings", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Injector Calibration");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Individual Cyl Trims");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Cranking Fuel");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("ECT Corrections");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("IAT Corrections");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Idle Ignition Corrections");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Tip-In Ignition Corrections");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("TPS Tip In&Out Corrections");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Gear Corrections");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Ignition Dwell");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Fuel/Ignition Corrections", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Launch Control");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Full Throttle Shift");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Burnout Control");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("3-Step Settings", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Boost Cut");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Boost Controller");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("PWM Setup");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("PWM Targets");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("PWM Corrections");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("PWM Closeloop");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Boost Settings", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Adjustments");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Output 1", new System.Windows.Forms.TreeNode[] {
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Adjustments");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Output 2", new System.Windows.Forms.TreeNode[] {
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Adjustments");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Output 3", new System.Windows.Forms.TreeNode[] {
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Outputs Settings", new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode37,
            treeNode39});
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Anti-Theft");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("ECT/Overheat");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Knock Protection");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Lean Protection");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Baserom Password");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Protections Settings", new System.Windows.Forms.TreeNode[] {
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45});
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Extras");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Coil on Plug Retrofit");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("AC Cutoff");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Fuel Cut Decel");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Popcorn Mod");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Flex Fuel");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Secondary Map");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Maps Indexing");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("IAB Activation");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Comments");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Extras Options", new System.Windows.Forms.TreeNode[] {
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56});
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("On Board Logging");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Onboard Datalogging", new System.Windows.Forms.TreeNode[] {
            treeNode58});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParameters));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            this.splitContainer1.Size = new System.Drawing.Size(567, 477);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.CausesValidation = false;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.FullRowSelect = true;
            this.treeView.Indent = 15;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "nRomOptions";
            treeNode1.Text = "Options/Sensors";
            treeNode2.Name = "nIdle";
            treeNode2.Text = "Idle Settings";
            treeNode3.Name = "nVtec";
            treeNode3.Text = "VTEC Settings";
            treeNode4.Name = "nRevLimit";
            treeNode4.Text = "Rev Limits";
            treeNode5.Name = "nMilShift";
            treeNode5.Text = "MIL ShiftLight";
            treeNode6.Name = "nCloseLoop";
            treeNode6.Text = "Close Loop";
            treeNode7.Name = "nBoostMapSensor";
            treeNode7.Text = "Map Sensor";
            treeNode8.Name = "nTpsSensor";
            treeNode8.Text = "TPS Sensor";
            treeNode9.Name = "nFan";
            treeNode9.Text = "Fan Control";
            treeNode10.Name = "nTrans";
            treeNode10.Text = "Transmission";
            treeNode11.Name = "Nœud0";
            treeNode11.Text = "Main Settings";
            treeNode12.Name = "nInjector";
            treeNode12.Text = "Injector Calibration";
            treeNode13.Name = "nCylinder";
            treeNode13.Text = "Individual Cyl Trims";
            treeNode14.Name = "nCrank";
            treeNode14.Text = "Cranking Fuel";
            treeNode15.Name = "nEct";
            treeNode15.Text = "ECT Corrections";
            treeNode16.Name = "nIat";
            treeNode16.Text = "IAT Corrections";
            treeNode17.Name = "nIdleIgn";
            treeNode17.Text = "Idle Ignition Corrections";
            treeNode18.Name = "nTpsRetard";
            treeNode18.Text = "Tip-In Ignition Corrections";
            treeNode19.Name = "nTpsFuel";
            treeNode19.Text = "TPS Tip In&Out Corrections";
            treeNode20.Name = "nGear";
            treeNode20.Text = "Gear Corrections";
            treeNode21.Name = "nIgnRpm";
            treeNode21.Text = "Ignition Dwell";
            treeNode22.Name = "Node1";
            treeNode22.Text = "Fuel/Ignition Corrections";
            treeNode23.Name = "nFtl";
            treeNode23.Text = "Launch Control";
            treeNode24.Name = "nFts";
            treeNode24.Text = "Full Throttle Shift";
            treeNode25.Name = "nBurnOut";
            treeNode25.Text = "Burnout Control";
            treeNode26.Name = "Node10";
            treeNode26.Text = "3-Step Settings";
            treeNode27.Name = "nBoostCut";
            treeNode27.Text = "Boost Cut";
            treeNode28.Name = "nBstManual";
            treeNode28.Text = "Boost Controller";
            treeNode29.Name = "nEbcSettings";
            treeNode29.Text = "PWM Setup";
            treeNode30.Name = "nEbcDutyLookup";
            treeNode30.Text = "PWM Targets";
            treeNode31.Name = "nEbcComp";
            treeNode31.Text = "PWM Corrections";
            treeNode32.Name = "nEbcClose";
            treeNode32.Text = "PWM Closeloop";
            treeNode33.Name = "Node30";
            treeNode33.Text = "Boost Settings";
            treeNode34.Name = "nGpo1Adj";
            treeNode34.Text = "Adjustments";
            treeNode35.Name = "nGpo1";
            treeNode35.Text = "Output 1";
            treeNode36.Name = "nGpo2Adj";
            treeNode36.Text = "Adjustments";
            treeNode37.Name = "nGpo2";
            treeNode37.Text = "Output 2";
            treeNode38.Name = "nGpo3Adj";
            treeNode38.Text = "Adjustments";
            treeNode39.Name = "nGpo3";
            treeNode39.Text = "Output 3";
            treeNode40.Name = "nOutputs";
            treeNode40.Text = "Outputs Settings";
            treeNode41.Name = "nAntitheft";
            treeNode41.Text = "Anti-Theft";
            treeNode42.Name = "nOverheatEct";
            treeNode42.Text = "ECT/Overheat";
            treeNode43.Name = "Nœknock";
            treeNode43.Text = "Knock Protection";
            treeNode44.Name = "nLeanProtect";
            treeNode44.Text = "Lean Protection";
            treeNode45.Name = "nFileProtect";
            treeNode45.Text = "Baserom Password";
            treeNode46.Name = "Nœud1";
            treeNode46.Text = "Protections Settings";
            treeNode47.Name = "nSCC";
            treeNode47.Text = "Extras";
            treeNode48.Name = "nCPR";
            treeNode48.Text = "Coil on Plug Retrofit";
            treeNode49.Name = "nAc";
            treeNode49.Text = "AC Cutoff";
            treeNode50.Name = "nFuelCut";
            treeNode50.Text = "Fuel Cut Decel";
            treeNode51.Name = "nPopcorn";
            treeNode51.Text = "Popcorn Mod";
            treeNode52.Name = "nFlexFuel";
            treeNode52.Text = "Flex Fuel";
            treeNode53.Name = "nDualMap";
            treeNode53.Text = "Secondary Map";
            treeNode54.Name = "nMap";
            treeNode54.Text = "Maps Indexing";
            treeNode55.Name = "nIab";
            treeNode55.Text = "IAB Activation";
            treeNode56.Name = "nComments";
            treeNode56.Text = "Comments";
            treeNode57.Name = "Node14";
            treeNode57.Text = "Extras Options";
            treeNode58.Name = "nOBL";
            treeNode58.Text = "On Board Logging";
            treeNode59.Name = "Nœud0";
            treeNode59.Text = "Onboard Datalogging";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode22,
            treeNode26,
            treeNode33,
            treeNode40,
            treeNode46,
            treeNode57,
            treeNode59});
            this.treeView.Size = new System.Drawing.Size(174, 473);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // frmParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 477);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmParameters";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parameters";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmParameters_FormClosed);
            this.Load += new System.EventHandler(this.frmParameters_Load);
            this.ResizeEnd += new System.EventHandler(this.frmParameters_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    internal void method_0(ref Class18 class18_1, ref FrmMain frmMain_1)
    {
        this.frmMain_0 = frmMain_1;
        this.class18_0 = class18_1;
        this.class18_0.delegate58_0 += new Class18.Delegate58(this.method_1);

        foreach (Control control in base.Controls)
        {
            float emSize = control.Font.Size * (class18_0.class10_settings_0.scaleRate / 100f);
            control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
        }
    }

    private void method_1()
    {
        if (this.class18_0.method_30_HasFileLoadedInBMTune())
        {
            this.treeView.Enabled = true;
            this.splitContainer1.Panel2.Enabled = true;
            this.Text = "Parameters";
            base.Invalidate();
        }
        else
        {
            this.treeView.Enabled = false;
            this.splitContainer1.Panel2.Enabled = false;
            base.Invalidate();
        }
    }

    private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        SelectPage(e.Node.Name, e.Node.Text);
    }

    public void SelectPage(string NodeName, string PageName)
    {
        this.Text = "Parameters - " + PageName;
        if (this.userControl_0 != null)
        {
            this.userControl_0.Dispose();
            this.userControl_0 = null;
        }
        this.class18_0.class10_settings_0.parameterNode = NodeName;
        switch (NodeName)
        {
            case "nComments":
                this.userControl_0 = new parmComments(ref this.class18_0);
                break;

            case "nRomOptions":
                this.userControl_0 = new parmRomOptions(ref this.class18_0);
                break;

            case "nMap":
                this.userControl_0 = new parmMap(ref this.class18_0);
                break;

            case "nRevLimit":
                this.userControl_0 = new parmRevLimit(ref this.class18_0);
                break;

            case "nInjector":
                this.userControl_0 = new parmInjector(ref this.class18_0);
                break;

            case "nVtec":
                this.userControl_0 = new parmVtec(ref this.class18_0);
                break;

            case "nCloseLoop":
                this.userControl_0 = new parmCloseLoop(ref this.class18_0);
                break;

            case "nIdle":
                this.userControl_0 = new parmIdleMain(ref this.class18_0);
                break;

            case "nFuelCut":
                this.userControl_0 = new parmFuelCut(ref this.class18_0);
                break;

            case "nIab":
                this.userControl_0 = new parmIAB(ref this.class18_0);
                break;

            case "nTpsSensor":
                this.userControl_0 = new parmTpsSensor(ref this.class18_0, ref this.class18_0.class17_0);
                break;

            case "nIat":
                this.userControl_0 = new parmIATcorr(ref this.class18_0);
                break;

            case "nEct":
                this.userControl_0 = new parmEctCorr(ref this.class18_0);
                break;

            case "nBoostMapSensor":
                this.userControl_0 = new parmBoostMapSensor(ref this.class18_0);
                break;

            case "nCrank":
                this.userControl_0 = new parmCrankFuel(ref this.class18_0);
                break;

            case "nCylinder":
                this.userControl_0 = new parmCylCorr(ref this.class18_0);
                break;

            case "nGear":
                this.userControl_0 = new parmGearCorr(ref this.class18_0);
                break;

            case "nSCC":
                this.userControl_0 = new parmSCC(ref this.class18_0);
                break;

            case "nFtl":
                this.userControl_0 = new parmFtl(ref this.class18_0);
                break;

            case "nFts":
                this.userControl_0 = new parmFts(ref this.class18_0);
                break;

            case "nAc":
                this.userControl_0 = new parmAc(ref this.class18_0);
                break;

            //case "nAntiLag":
            //    this.userControl_0 = new parmAntiLag(ref this.class18_0);
            //    break;

            case "nMilShift":
                this.userControl_0 = new parmMilShift(ref this.class18_0);
                break;

            case "nBoostCut":
                this.userControl_0 = new parmBoostCut(ref this.class18_0);
                break;

            case "nIgnRpm":
                this.userControl_0 = new parmDwell(ref this.class18_0);
                break;

            case "nEbcSettings":
                this.userControl_0 = new parmEbcSettings(ref this.class18_0);
                break;

            case "nDualMap":
                this.userControl_0 = new parmDualMap(ref this.class18_0);
                break;

            case "nFan":
                this.userControl_0 = new parmFanControl(ref this.class18_0);
                break;

            case "nGpo1":
                this.userControl_0 = new parmGPO1_a(ref this.class18_0);
                break;

            case "nGpo2":
                this.userControl_0 = new parmGPO2_a(ref this.class18_0);
                break;

            case "nGpo3":
                this.userControl_0 = new parmGPO3_a(ref this.class18_0);
                break;

            case "nBstManual":
                this.userControl_0 = new parmBstManual(ref this.class18_0);
                break;

            case "nGpo1Adj":
                this.userControl_0 = new parmGPO1_if(ref this.class18_0);
                break;

            case "nGpo2Adj":
                this.userControl_0 = new parmGPO2_if(ref this.class18_0);
                break;

            case "nGpo3Adj":
                this.userControl_0 = new parmGPO3_if(ref this.class18_0);
                break;

            case "nEbcDutyLookup":
                this.userControl_0 = new parmEbcDutyLook(ref this.class18_0);
                break;

            case "nOverheatEct":
                this.userControl_0 = new parmEctProtection(ref this.class18_0);
                break;

            case "nLeanProtect":
                this.userControl_0 = new parmLeanProtection(ref this.class18_0);
                break;

            case "nEbcComp":
                this.userControl_0 = new parmEbcCompensation(ref this.class18_0);
                break;

            case "nEbcClose":
                this.userControl_0 = new parmEbcCloseloop(ref this.class18_0);
                break;

            case "nTpsRetard":
                this.userControl_0 = new parmTpsRetard(ref this.class18_0);
                break;

            case "nIdleIgn":
                this.userControl_0 = new parmIdleIgnCorr(ref this.class18_0);
                break;

            case "nTrans":
                this.userControl_0 = new parmTransmission(ref this.class18_0);
                break;

            case "nBurnOut":
                this.userControl_0 = new parmBurnOut(ref this.class18_0);
                break;

            case "nAntitheft":
                this.userControl_0 = new parmAntiStart(ref this.class18_0);
                break;

            case "nFileProtect":
                this.userControl_0 = new parmFileProtection(ref this.class18_0);
                break;

            case "nTpsFuel":
                this.userControl_0 = new parmTipInOut(ref this.class18_0);
                break;

            case "nFlexFuel":
                this.userControl_0 = new parmFlexFuel(ref this.class18_0);
                break;

            case "nPopcorn":
                this.userControl_0 = new parmPopcorn(ref this.class18_0);
                break;

            case "Nœknock":
                this.userControl_0 = new parmKnockProtection(ref this.class18_0);
                break;

            case "nOBL":
                this.userControl_0 = new parmOBL(ref this.class18_0);
                break;

            case "nCPR":
                this.userControl_0 = new parmCPR(ref this.class18_0);
                break;


            default:
                return;
        }
        if (this.userControl_0 != null)
        {
            this.userControl_0.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(this.userControl_0);
            this.splitContainer1.Refresh();
        }
    }

    private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
    {
        this.class18_0.class10_settings_0.Parameter_Splitter = splitContainer1.SplitterDistance;
    }
}

