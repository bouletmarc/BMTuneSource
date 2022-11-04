namespace Data
{
    using System;
    using System.Drawing;
    using System.Reflection;

    //[Serializable, DoNotObfuscate]
    [DoNotObfuscate]
    public class ChartTemplate
    {
        [DoNotObfuscate]
        private Data.ChartSetup[] ChartSetup_0 = new Data.ChartSetup[4];
        [DoNotObfuscate]
        private bool[] charts = new bool[4];
        [DoNotObfuscate]
        public string templateName;

        [DoNotObfuscate]
        public Color GetPlotColor(int chart, int line)
        {
            return this.ChartSetup_0[chart].colors[line];
        }

        [DoNotObfuscate]
        public void setDefault()
        {
            this.ChartSetup_0[0] = new Data.ChartSetup();
            this.ChartSetup_0[1] = new Data.ChartSetup();
            this.ChartSetup_0[2] = new Data.ChartSetup();
            this.ChartSetup_0[3] = new Data.ChartSetup();
            this.charts[0] = true;
            this.charts[1] = false;
            this.charts[2] = false;
            this.charts[3] = false;
            this.templateName = "Default";
            this.ChartSetup_0[0].Sensors_0[0] = SensorsX.rpmX;
            this.ChartSetup_0[0].colors[0] = Color.Red;
            this.ChartSetup_0[0].Sensors_0[1] = SensorsX.tpsX;
            this.ChartSetup_0[0].colors[1] = Color.Blue;
            this.ChartSetup_0[0].Sensors_0[2] = SensorsX.iatX;
            this.ChartSetup_0[0].colors[2] = Color.Orange;
            this.ChartSetup_0[0].Sensors_0[3] = SensorsX.ectX;
            this.ChartSetup_0[0].colors[3] = Color.Green;
            this.ChartSetup_0[0].plotLinesEnable[0] = true;
            this.ChartSetup_0[0].plotLinesEnable[1] = true;
            this.ChartSetup_0[0].plotLinesEnable[2] = true;
            this.ChartSetup_0[0].plotLinesEnable[3] = true;
        }

        [DoNotObfuscate]
        public bool[] ChartsEnable
        {
            get
            {
                return this.charts;
            }
            set
            {
                this.charts = value;
            }
        }

        [DoNotObfuscate]
        public int ChartsEnableCnt
        {
            get
            {
                int num = 0;
                for (int i = 0; i < this.charts.Length; i++)
                {
                    if (this.charts[i])
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        [DoNotObfuscate]
        public Data.ChartSetup[] ChartSetup
        {
            get
            {
                return this.ChartSetup_0;
            }
            set
            {
                this.ChartSetup_0 = value;
            }
        }

        [DoNotObfuscate]
        public Data.ChartSetup this[int index]
        {
            get
            {
                return this.ChartSetup_0[index];
            }
        }
    }
}

