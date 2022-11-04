using Krawk_Protector.Protections.Math.Functions;
using Krawk_Protector.Protections.Math.Utils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krawk_Protector.Utils;
namespace Krawk_Protector.Protections.Math
{
    public class MathProtection : IProtector
    {
            string IProtector.Name => "MathProtection";
           
            void IProtector.InjectPhase(Context krawk) { }

            void IProtector.ProtectionPhase(Context krawk)
            {
            Generator.Generator generator = new Generator.Generator();
            foreach (TypeDef tDef in krawk.ManifestModule.Types)
            {
                foreach (MethodDef mDef in tDef.Methods)
                {
                    if (!mDef.HasBody) continue;
                    for (int i = 0; i < mDef.Body.Instructions.Count; i++)
                    {
                        if (ArithmeticUtils.CheckArithmetic(mDef.Body.Instructions[i]))
                        {
                            if (mDef.Body.Instructions[i].GetLdcI4Value() < 0)
                            {
                                iFunction iFunction = Tasks[generator.Next(5)];
                                List<Instruction> lstInstr = GenerateBody(iFunction.Arithmetic(mDef.Body.Instructions[i], krawk.ManifestModule), krawk);
                                if (lstInstr == null) continue;
                                mDef.Body.Instructions[i].OpCode = OpCodes.Nop;
                                foreach (Instruction instr in lstInstr)
                                {
                                    mDef.Body.Instructions.Insert(i + 1, instr);
                                    i++;
                                }
                            }
                            else
                            {
                                iFunction iFunction = Tasks[generator.Next(Tasks.Count)];
                                List<Instruction> lstInstr = GenerateBody(iFunction.Arithmetic(mDef.Body.Instructions[i], krawk.ManifestModule),krawk);
                                if (lstInstr == null) continue;
                                mDef.Body.Instructions[i].OpCode = OpCodes.Nop;
                                foreach (Instruction instr in lstInstr)
                                {
                                    mDef.Body.Instructions.Insert(i + 1, instr);
                                    i++;
                                }
                            }

                        }
                    }
                }
            }
        }
        private static List<iFunction> Tasks = new List<iFunction>()
        {
            new Add(),
            new Sub(),
            new Div(),
            new Mul(),
            new Xor(),
            new Functions.Maths.Abs(),
            new Functions.Maths.Log(),
            new Functions.Maths.Log10(),
            new Functions.Maths.Sin(),
            new Functions.Maths.Cos(),
            new Functions.Maths.Floor(),
            new Functions.Maths.Round(),
            new Functions.Maths.Tan(),
            new Functions.Maths.Tanh(),
            new Functions.Maths.Sqrt(),
            new Functions.Maths.Ceiling(),
            new Functions.Maths.Truncate()
        };
        private static  List<Instruction> GenerateBody(ArithmeticVT arithmeticVTs, Context Krawk)
        {
            List<Instruction> instructions = new List<Instruction>();
            if (IsArithmetic(arithmeticVTs.GetArithmetic()))
            {
                instructions.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetX()));
                instructions.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetY()));

                if (arithmeticVTs.GetToken().GetOperand() != null)
                {
                    instructions.Add(new Instruction(OpCodes.Call, arithmeticVTs.GetToken().GetOperand()));
                }
                instructions.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
                instructions.Add(new Instruction(OpCodes.Call, Krawk.ManifestModule.Import(typeof(Convert).GetMethod("ToInt32", new Type[] { typeof(double) }))));
                //instructions.Add(new Instruction(OpCodes.Conv_I4));
            }
            else if (IsXor(arithmeticVTs.GetArithmetic()))
            {
                instructions.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetX()));
                instructions.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetY()));
                instructions.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
                instructions.Add(new Instruction(OpCodes.Conv_I4));
            }
            return instructions;
        }
        private static bool IsArithmetic(ArithmeticTypes arithmetic)
        {
            return arithmetic == ArithmeticTypes.Add || arithmetic == ArithmeticTypes.Sub || arithmetic == ArithmeticTypes.Div || arithmetic == ArithmeticTypes.Mul ||
                arithmetic == ArithmeticTypes.Abs || arithmetic == ArithmeticTypes.Log || arithmetic == ArithmeticTypes.Log10 || arithmetic == ArithmeticTypes.Truncate ||
                arithmetic == ArithmeticTypes.Sin || arithmetic == ArithmeticTypes.Cos || arithmetic == ArithmeticTypes.Floor || arithmetic == ArithmeticTypes.Round ||
                arithmetic == ArithmeticTypes.Tan || arithmetic == ArithmeticTypes.Tanh || arithmetic == ArithmeticTypes.Sqrt || arithmetic == ArithmeticTypes.Ceiling;
        }
        private static bool IsXor(ArithmeticTypes arithmetic)
        {
            return arithmetic == ArithmeticTypes.Xor;
        }
    }
}
