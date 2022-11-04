using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krawk_Protector.Protections.Math.Utils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Protector.Protections.Math.Functions
{
    public class Div : iFunction
    {
        public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Div;
        public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
        {
            Generator.Generator generator = new Generator.Generator();
            if (!ArithmeticUtils.CheckArithmetic(instruction)) return null;
            ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
            return (new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Div), ArithmeticTypes));
        }
    }
}
