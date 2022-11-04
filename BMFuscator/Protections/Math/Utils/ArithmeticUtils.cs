using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krawk_Protector.Protections.Math.Utils
{
    public class ArithmeticUtils
    {
        public static bool CheckArithmetic(Instruction instruction)
        {
            if (!instruction.IsLdcI4())
                return false;
            if (instruction.GetLdcI4Value() == 1)
                return false;
            if (instruction.GetLdcI4Value() == 0)
                return false;
            return true;
        }
        public static double GetY(double x) => (x / 2);
        public static System.Reflection.MethodInfo GetMethod(ArithmeticTypes mathType)
        {
            switch (mathType)
            {
                case ArithmeticTypes.Abs:
                    return ((typeof(System.Math).GetMethod("Abs", new Type[] { typeof(double) })));
                case ArithmeticTypes.Round:
                    return ((typeof(System.Math).GetMethod("Round", new Type[] { typeof(double) })));
                case ArithmeticTypes.Sin:
                    return ((typeof(System.Math).GetMethod("Sin", new Type[] { typeof(double) })));
                case ArithmeticTypes.Cos:
                    return ((typeof(System.Math).GetMethod("Cos", new Type[] { typeof(double) })));
                case ArithmeticTypes.Log:
                    return ((typeof(System.Math).GetMethod("Log", new Type[] { typeof(double) })));
                case ArithmeticTypes.Log10:
                    return ((typeof(System.Math).GetMethod("Log10", new Type[] { typeof(double) })));
                case ArithmeticTypes.Sqrt:
                    return ((typeof(System.Math).GetMethod("Sqrt", new Type[] { typeof(double) })));
                case ArithmeticTypes.Ceiling:
                    return ((typeof(System.Math).GetMethod("Ceiling", new Type[] { typeof(double) })));
                case ArithmeticTypes.Floor:
                    return ((typeof(System.Math).GetMethod("Floor", new Type[] { typeof(double) })));
                case ArithmeticTypes.Tan:
                    return ((typeof(System.Math).GetMethod("Tan", new Type[] { typeof(double) })));
                case ArithmeticTypes.Tanh:
                    return ((typeof(System.Math).GetMethod("Tanh", new Type[] { typeof(double) })));
                case ArithmeticTypes.Truncate:
                    return ((typeof(System.Math).GetMethod("Truncate", new Type[] { typeof(double) })));
            }
            return null;
        }
        public static OpCode GetOpCode(ArithmeticTypes arithmetic)
        {
            switch (arithmetic)
            {
                case ArithmeticTypes.Add:
                    return OpCodes.Add;
                case ArithmeticTypes.Sub:
                    return OpCodes.Sub;
            }
            return null;
        }
    }
}
