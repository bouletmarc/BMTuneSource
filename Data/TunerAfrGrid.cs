namespace Data
{
    using System;

    //[Serializable]
    [DoNotObfuscate]
    public class TunerAfrGrid
    {
        [DoNotObfuscate]
        public bool[,] fuel_high_1_Lock;
        public bool[,] fuel_high_2_Lock;
        public bool[,] fuel_low_1_Lock;
        public bool[,] fuel_low_2_Lock;
        public double[,] targetAfr_hi_1;
        public double[,] targetAfr_hi_2;
        public double[,] targetAfr_lo_1;
        public double[,] targetAfr_lo_2;
    }
}

