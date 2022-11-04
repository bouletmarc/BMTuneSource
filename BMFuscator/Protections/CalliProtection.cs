using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Krawk_Protector.Utils;
using Krawk.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krawk.Helpers;

namespace Krawk_Protector.Protections
{
    class CalliProtection : IProtector
    {
        string IProtector.Name => "CalliProtection";
       
        private MethodDef decryptionmethod;
        void IProtector.InjectPhase(Context krawk) {
            ModuleDefMD typeModule = ModuleDefMD.Load(typeof(CalliRuntime).Module);
            TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(CalliRuntime).MetadataToken));
            IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, krawk.GlobalType, krawk.ManifestModule);

            decryptionmethod = (MethodDef)members.Single(method => method.Name == "ResolveToken");
        }
        public static int token2 = 0;
        public static List<MemberRef> listmember = new List<MemberRef>();
        public static List<int> listtoken = new List<int>();
        void IProtector.ProtectionPhase(Context krawk)
        {
            var module = krawk.ManifestModule;
           
            foreach (TypeDef type in module.Types.ToArray())
            {
                if (type.Namespace.Contains(".My")) continue;
                foreach (MethodDef method in type.Methods.ToArray())
                {
                    if (method.Equals(decryptionmethod))
                    {

                    }
                    else
                    {
                        if (type.IsGlobalModuleType) continue;
                               if (method.ToString().Contains("Program")) continue;
                        if (method.HasBody)
                        {
                            if (method.Body.HasInstructions)
                            {
                                for (int i = 0; i < method.Body.Instructions.Count - 1; i++)
                                {
                                    try
                                    {
                                        if (method.Body.Instructions[i].OpCode == OpCodes.Call || method.Body.Instructions[i].OpCode == OpCodes.Callvirt || method.Body.Instructions[i].OpCode == OpCodes.Ldloc_S)
                                        {
                                            try
                                            {
                                             
                                                MemberRef membertocalli = (MemberRef)method.Body.Instructions[i].Operand;
                                                token2 = membertocalli.MDToken.ToInt32();
                                                if (!membertocalli.ToString().Contains("ResolveToken"))

                                                {
                                                    if (!membertocalli.HasThis)
                                                    {

                                                        if (listmember.Contains(membertocalli))
                                                        {

                                                            method.Body.Instructions[i].OpCode = OpCodes.Calli;
                                                            method.Body.Instructions[i].Operand = listmember[listmember.IndexOf(membertocalli)].MethodSig;
                                                            method.Body.Instructions.Insert(i, Instruction.Create(OpCodes.Call, decryptionmethod));
                                                            method.Body.Instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I8, (long)(listtoken[listmember.IndexOf(membertocalli)])));
                                                        }
                                                        else
                                                        {
                                                            MethodSig MethodSign = membertocalli.MethodSig;
                                                            method.Body.Instructions[i].OpCode = OpCodes.Calli;
                                                            method.Body.Instructions[i].Operand = MethodSign;
                                                            method.Body.Instructions.Insert(i, Instruction.Create(OpCodes.Call, decryptionmethod));
                                                            method.Body.Instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I8,(long)token2));
                                                            listmember.Add(membertocalli);
                                                            listtoken.Add(token2);
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                string str = ex.Message;
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }

                                }
                            }
                            else
                            {

                            }
                        }

                    }
                }
                foreach (MethodDef md in module.GlobalType.Methods)
                {
                    if (md.Name == ".ctor")
                    {
                        module.GlobalType.Remove(md);
                        break;
                    }

                }
            }
        }
    }
    }



