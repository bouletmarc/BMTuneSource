using BMDevs.Runtime;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.PE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMDevs.Mutations
{
    public class BytesToModuleReference : IObfuscation
    {
        public ModuleDef Module { get; set; }

        public Dictionary<long, FieldDef> Numbers { get; set; }

        public void Execute(ModuleDefMD md)
        {
            Numbers = new Dictionary<long, FieldDef>();
            Module = md;
            foreach (var type in md.Types.Where(x => x != md.GlobalType))
                foreach (var method in type.Methods.Where(x => !x.IsConstructor && x.HasBody && x.Body.HasInstructions))
                    ExecuteMethod(method);
        }

        public FieldDef AddNumberField(long num)
        {
            var cstype = RuntimeHelper.GetRuntimeType("BMDevs.Runtime.BytesToModule");
            FieldDef field = cstype.FindField("val");
            Renamer.Rename(field, Renamer.RenameMode.Invalid2, 2);
            //Renamer.Rename(field, Renamer.RenameMode.Base64, 2);
            field.DeclaringType = null;
            Module.GlobalType.Fields.Add(field);

            var method = Module.GlobalType.FindOrCreateStaticConstructor();
            method.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4, num));
            method.Body.Instructions.Insert(1, new Instruction(OpCodes.Stsfld, field));
            return field;
        }

        //thanks to mighty
        public void ExecuteMethod(MethodDef method)
        {
            for (int i = 0; i < method.Body.Instructions.Count; i++)
            {
                var instr = method.Body.Instructions[i];
                //if (instr.IsLdloc())
                //{
                if (Module.GlobalType.Fields.Count < 65000)
                {
                    var val = instr.GetLdcI4Value();
                    if (val != -1)
                    {
                        if (val.GetType() == typeof(long))
                        {
                            FieldDef fld;
                            if (!Numbers.TryGetValue((long)val, out fld))
                            {
                                fld = AddNumberField((long)val);
                                Numbers.Add((long)val, fld);
                                Console.WriteLine("ByteModule: " + val);
                            }
                            instr.OpCode = OpCodes.Ldsfld;
                            instr.Operand = fld;
                        }
                    }
                }
                //}
            }
        }
    }
}
