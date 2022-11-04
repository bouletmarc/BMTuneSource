using Krawk_Protector.Protections.Math.Utils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krawk_Protector.Protections.Math.Functions.Maths
{
    public class Tanh : iFunction
    {
        public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Tanh;
        public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
        {
            Generator.Generator generator = new Generator.Generator();
            if (!ArithmeticUtils.CheckArithmetic(instruction)) return null;
            List<ArithmeticTypes> arithmeticTypes = new List<ArithmeticTypes>() { ArithmeticTypes.Add, ArithmeticTypes.Sub };
            ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
            return (new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmeticTypes), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes));
        }
    }
}
