using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Krawk_Protector.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krawk_Protector.Protections.Constants
{
    class NumbersMutation : IProtector

    {
        string IProtector.Name => "NumbersMutation";
        
        private CilBody body;
       void IProtector.InjectPhase(Context krawk) { }


      void IProtector.ProtectionPhase(Context krawk)
        {
            foreach (ModuleDef module in krawk.Assembly.Modules)
            {
                foreach (TypeDef type in module.Types)
                {
                    if (type.Namespace.Contains(".My")) continue;
                    foreach (MethodDef method in type.Methods)
                    {
                        if (!method.HasBody) continue;
                        if (method.Name.Contains("Krawk_Protector_N")) continue;
                        if (method.HasBody) if (!method.Body.HasInstructions) continue;

                        body = method.Body;
                        for (int i = 0; i < body.Instructions.Count; i++)
                        {
                            if (body.Instructions[i].OpCode == OpCodes.Ldc_I4)
                            {
                                Mutate(krawk, method, i);
                                i += 2;
                            }

                        }
                        body.SimplifyBranches();
                        body.OptimizeBranches();

                    }
                }
            }
        }
    
        private void Mutate(Context krawk, MethodDef method, int i)
        {
            body = method.Body;
            int rndkey = Utils.Generator.RandomInt(0, int.MaxValue);
            int newoperand = body.Instructions[i].GetLdcI4Value() + rndkey;
            body.Instructions[i] = Instruction.CreateLdcI4(newoperand);
            body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(rndkey));
            body.Instructions.Insert(i + 2, OpCodes.Sub.ToInstruction());

        }


    }
}
