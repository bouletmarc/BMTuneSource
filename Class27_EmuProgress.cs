using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class Class27_EmuProgress
{
    private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();
    private Class25 class25_0;
    private FrmMain frmMain_0;
    private int int_0;

    internal Class27_EmuProgress()
    {
        this.backgroundWorker_0.WorkerReportsProgress = false;
        this.backgroundWorker_0.WorkerSupportsCancellation = false;
        this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
    }

    private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
    {
        this.frmMain_0.stutasEmulatorProgress.Value = this.int_0;
    }

    internal void method_0(ref Class25 class25_1, ref FrmMain frmMain_1)
    {
        this.class25_0 = class25_1;
        this.frmMain_0 = frmMain_1;
        this.class25_0.delegate66_0 += new Class25.Delegate66(this.method_1);
    }

    private void method_1(int int_1)
    {
        this.int_0 = int_1;
        if (!this.backgroundWorker_0.IsBusy)
        {
            this.backgroundWorker_0.RunWorkerAsync();
        }
    }
}

