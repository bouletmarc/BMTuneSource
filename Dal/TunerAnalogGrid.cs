namespace Dal
{
    using System;

    [Serializable]
    public class TunerAnalogGrid
    {
        public bool[,] analog1_Lock;
        public bool[,] analog2_Lock;
        public bool[,] analog3_Lock;
        public double[,] analog1;
        public double[,] analog2;
        public double[,] analog3;
    }
}

