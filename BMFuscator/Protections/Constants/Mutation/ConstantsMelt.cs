using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Krawk_Protector.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Krawk_Protector.Protections.Constants
{
    class ConstantsMelt : IProtector

    {
        string IProtector.Name => "ConstantsMelt";
        
        private CilBody body;
        void IProtector.InjectPhase(Context krawk) { }


        void IProtector.ProtectionPhase(Context krawk)
        {
            foreach (ModuleDef module in krawk.Assembly.Modules)
            {
                foreach (TypeDef type in module.Types)
                {
                    foreach (MethodDef method in type.Methods)
                    {
                        if (!method.HasBody) continue;
                        if (method.HasBody) if (!method.Body.HasInstructions) continue;

                        body = method.Body;
                        for (int i = 0; i < body.Instructions.Count; i++)
                        {
                            if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                            {
                                Mutate(krawk, method, i, "String");
                                i += 2;
                            }
                            if(method.Body.Instructions[i].IsLdcI4())
                            {
                                Mutate(krawk, method, i, "Int");
                            }
                           
                        }
                        body.SimplifyBranches();
                        body.OptimizeBranches();

                    }
                }
            }
        }
  
        private void Mutate(Context krawk, MethodDef method, int i, string type)
        {
            {
                //faltou umas local!
                Local local = null;
                if (type == "String")
                {
                    local = new Local(krawk.ManifestModule.CorLibTypes.String);
                }
                else if (type == "Int")
                {
                    local = new Local(krawk.ManifestModule.CorLibTypes.Int32);
                }
                    method.Body.Variables.Add(local);
                method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Stloc_S, local));
                method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldloc_S, local));


                //Inicio
                //
            }
        }
    }
}





