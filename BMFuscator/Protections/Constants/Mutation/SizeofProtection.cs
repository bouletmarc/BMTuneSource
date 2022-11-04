using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Krawk_Protector.Utils;
using System;

namespace Krawk_Protector.Protections.Constants
{
    class SizeofProtection : IProtector
    {
        string IProtector.Name => "SizeofProtection";
   
        private CilBody body;
        private static Random rndx = new Random();
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
                        if (method.HasBody && method.Body.HasInstructions)
                        {
                            if (method.Name.Contains("Krawk_Protector_N")) continue;
                            for (int i = 0; i < method.Body.Instructions.Count; i++)
                            {
                                if (method.Body.Instructions[i].OpCode == OpCodes.Ldc_I4)
                                {
                                    body = method.Body;
                                    int atual = body.Instructions[i].GetLdcI4Value();
                                    int sub = rndx.Next(1, 3);
                                    int calculado = atual - sub;
                                    body.Instructions[i].Operand = calculado;
                                    Start(i, sub, calculado, krawk, method);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Start(int i, int sub, int calculado, Context krawk, MethodDef method)
        {
            switch (sub)
            {
                case 1:
                    //CORRECT
                    Local local_1 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    Local local_2 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    Local local_3 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    Local local_4 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    method.Body.Variables.Add(local_1);
                    method.Body.Variables.Add(local_2);
                    method.Body.Variables.Add(local_3);
                    method.Body.Variables.Add(local_4);
                    body.Instructions.Insert(i + 1, new Instruction(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(GCNotificationStatus))));
                    body.Instructions.Insert(i + 2, new Instruction(OpCodes.Stloc_S, local_1));
                    body.Instructions.Insert(i + 3, new Instruction(OpCodes.Ldloc_S, local_1));
                    body.Instructions.Insert(i + 4, OpCodes.Add.ToInstruction());
                    body.Instructions.Insert(i + 5, new Instruction(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(SByte))));
                    body.Instructions.Insert(i + 6, new Instruction(OpCodes.Stloc_S, local_2));
                    body.Instructions.Insert(i + 7, new Instruction(OpCodes.Ldloc_S, local_2));
                    body.Instructions.Insert(i + 8, OpCodes.Sub.ToInstruction());
                    body.Instructions.Insert(i + 9, new Instruction(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(SByte))));
                    body.Instructions.Insert(i + 10, new Instruction(OpCodes.Stloc_S, local_3));
                    body.Instructions.Insert(i + 11, new Instruction(OpCodes.Ldloc_S, local_3));
                    body.Instructions.Insert(i + 12, OpCodes.Sub.ToInstruction());
                    body.Instructions.Insert(i + 13, new Instruction(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(SByte))));
                    body.Instructions.Insert(i + 14, new Instruction(OpCodes.Stloc_S, local_4));
                    body.Instructions.Insert(i + 15, new Instruction(OpCodes.Ldloc_S, local_4));
                    body.Instructions.Insert(i + 16, OpCodes.Sub.ToInstruction());
                    break;
                case 2:
                    //CORRECT
                    local_1 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    method.Body.Variables.Add(local_1);

                    body.Instructions.Insert(i +1, new Instruction(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(char))));
                    body.Instructions.Insert(i +2, new Instruction(OpCodes.Stloc_S, local_1));
                    body.Instructions.Insert(i + 3, new Instruction(OpCodes.Ldloc_S, local_1));
                    body.Instructions.Insert(i + 4, OpCodes.Add.ToInstruction());
                    break;
                case 3:
                    local_1 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    local_2 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    method.Body.Variables.Add(local_1);
                    method.Body.Variables.Add(local_2);
                    body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(System.Int32))));
                    body.Instructions.Insert(i + 2, new Instruction(OpCodes.Stloc_S, local_1));
                    body.Instructions.Insert(i + 3, new Instruction(OpCodes.Ldloc_S, local_1));
                    body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(byte))));
                    body.Instructions.Insert(i + 5, new Instruction(OpCodes.Stloc_S, local_2));
                    body.Instructions.Insert(i + 6, new Instruction(OpCodes.Ldloc_S, local_2));
                    body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Sub));
                    body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Add));
                    break;
                case 4:
                    local_1 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    local_2 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    local_3 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    local_4 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    method.Body.Variables.Add(local_1);
                    method.Body.Variables.Add(local_2);
                    method.Body.Variables.Add(local_3);
                    method.Body.Variables.Add(local_4);
                    body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Add));
                    body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(System.Decimal))));
                    body.Instructions.Insert(i + 3, new Instruction(OpCodes.Stloc_S, local_1));
                    body.Instructions.Insert(i + 4, new Instruction(OpCodes.Ldloc_S, local_1));
                    body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(System.GCCollectionMode))));
                    body.Instructions.Insert(i + 6, new Instruction(OpCodes.Stloc_S, local_2));
                    body.Instructions.Insert(i + 7, new Instruction(OpCodes.Ldloc_S, local_2));
                    body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Sub));
                    body.Instructions.Insert(i + 9, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(System.Int32))));
                    body.Instructions.Insert(i + 10, new Instruction(OpCodes.Stloc_S, local_3));
                    body.Instructions.Insert(i + 11, new Instruction(OpCodes.Ldloc_S, local_3));
                    body.Instructions.Insert(i + 12, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(byte))));
                    body.Instructions.Insert(i + 13, new Instruction(OpCodes.Stloc_S, local_4));
                    body.Instructions.Insert(i + 14, new Instruction(OpCodes.Ldloc_S, local_4));
                    body.Instructions.Insert(i + 15, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(byte))));
                    body.Instructions.Insert(i + 16, new Instruction(OpCodes.Stloc_S, local_1));
                    body.Instructions.Insert(i + 17, new Instruction(OpCodes.Ldloc_S, local_1));
                    body.Instructions.Insert(i + 18, Instruction.Create(OpCodes.Sub));
                    body.Instructions.Insert(i + 19, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(byte))));
                    body.Instructions.Insert(i + 20, new Instruction(OpCodes.Stloc_S, local_2));
                    body.Instructions.Insert(i + 21, new Instruction(OpCodes.Ldloc_S, local_2));
                    body.Instructions.Insert(i + 22, Instruction.Create(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(byte))));
                    body.Instructions.Insert(i + 23, new Instruction(OpCodes.Stloc_S, local_2));
                    body.Instructions.Insert(i + 24, new Instruction(OpCodes.Ldloc_S, local_2));
                    body.Instructions.Insert(i + 25, Instruction.Create(OpCodes.Add));
                    break;
                case 5:
                    local_1 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    local_2 = new Local(krawk.ManifestModule.CorLibTypes.Object);
                    method.Body.Variables.Add(local_1);
                    method.Body.Variables.Add(local_2);
                    body.Instructions.Insert(i + 1, new Instruction(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(System.EnvironmentVariableTarget))));
                    body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Stloc_S, local_1));
                    body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldloc_S, local_1));
                    body.Instructions.Insert(i + 4, OpCodes.Add.ToInstruction());
                    body.Instructions.Insert(i + 5, new Instruction(OpCodes.Sizeof, krawk.ManifestModule.Import(typeof(SByte))));
                    body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Stloc_S, local_2));
                    body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Ldloc_S, local_2));
                    body.Instructions.Insert(i + 9, OpCodes.Add.ToInstruction());
                    break;

            }
        }

    }
}
