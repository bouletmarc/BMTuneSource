namespace Data
{
    using System;
    using System.Drawing;

    //[Serializable, DoNotObfuscate]
    [DoNotObfuscate]
    public class ChartSetup
    {
        [DoNotObfuscate]
        public Color[] colors = new Color[5];
        [DoNotObfuscate]
        public bool[] plotLinesEnable = new bool[5];
        [DoNotObfuscate]
        public SensorsX[] Sensors_0 = new SensorsX[5];

        [DoNotObfuscate]
        public int PlotLines
        {
            get
            {
                int num = 0;
                for (int i = 0; i < this.plotLinesEnable.Length; i++)
                {
                    if (this.plotLinesEnable[i])
                    {
                        num++;
                    }
                }
                return num;
            }
        }
    }
}

