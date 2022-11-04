using Krawk_Protector.Utils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krawk_Protector.Utils;
namespace Krawk_Protector.Protections.ControlFlow
{
    public class ControlFlow : IProtector
    {
        string IProtector.Name => "ControlFlow";
    
        void IProtector.InjectPhase(Context krawk) { }
        void IProtector.ProtectionPhase(Context mode)
        {
            Executer(mode, mode);

        }
        void Executer(Context mode, Context krawk)
        {
            CFHelper cFHelper = new CFHelper();
            foreach (TypeDef type in krawk.ManifestModule.Types)
            {
               if (type.IsGlobalModuleType) continue;
                foreach (MethodDef method in type.Methods)
                {
                    if (method.HasBody && method.Body.Instructions.Count > 0 && !method.IsConstructor)
                    {
                        if (!cFHelper.HasUnsafeInstructions(method))
                        {
                            if (DnlibUtils.Simplify(method))
                            {
                                Blocks blocks = cFHelper.GetBlocks(method);
                                if (blocks.blocks.Count != 1)
                                {

                                    toDoBody(cFHelper, method, blocks, krawk);

                                }
                            }
                            DnlibUtils.Optimize(method);
                        }
                    }
                }

            }
        }
    
        
     
         void toDoBody(CFHelper cFHelper, MethodDef method, Blocks blocks, Context pandaContext)
        {
            blocks.Scramble(out blocks);
            method.Body.Instructions.Clear();
            Local local = new Local(pandaContext.ManifestModule.CorLibTypes.Int32);
            method.Body.Variables.Add(local);
            Instruction target = Instruction.Create(OpCodes.Nop);
            Instruction instr = Instruction.Create(OpCodes.Br, target);
            foreach (Instruction instruction in cFHelper.Calc(0))
                method.Body.Instructions.Add(instruction);
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instr));
            method.Body.Instructions.Add(target);
            foreach (Block block in blocks.blocks)
            {
                if (block != blocks.getBlock((blocks.blocks.Count - 1)))
                {
                    method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
                    foreach (Instruction instruction in cFHelper.Calc(block.ID))
                        method.Body.Instructions.Add(instruction);
                    method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
                    Instruction instruction4 = Instruction.Create(OpCodes.Nop);
                         method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction4));
                    foreach (Instruction instruction in block.instructions)
                        method.Body.Instructions.Add(instruction);
                    foreach (Instruction instruction in cFHelper.Calc(block.nextBlock))
                        method.Body.Instructions.Add(instruction);

                    method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
                    method.Body.Instructions.Add(instruction4);
                }
            }
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
            foreach (Instruction instruction in cFHelper.Calc(blocks.blocks.Count - 1))
                method.Body.Instructions.Add(instruction);
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instr));
            method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.getBlock((blocks.blocks.Count - 1)).instructions[0]));
            method.Body.Instructions.Add(instr);
            foreach (Instruction lastBlock in blocks.getBlock((blocks.blocks.Count - 1)).instructions)
                method.Body.Instructions.Add(lastBlock);

        }
    }

    public class ObfuscationMethodUtil
    {

        public static bool canObfuscate(MethodDef methodDef)
        {
            if (!methodDef.HasBody)
                return false;
            if (!methodDef.Body.HasInstructions)
                return false;
            if (methodDef.DeclaringType.IsGlobalModuleType)
                return false;

            return true;

        }
    }
    class DnlibUtils
    {
        public static IEnumerable<IDnlibDef> FindDefinitions(ModuleDef module)
        {
            yield return module;
            foreach (TypeDef type in module.GetTypes())
            {
                yield return type;
                foreach (MethodDef method in type.Methods)
                    yield return method;

                foreach (FieldDef field in type.Fields)
                    yield return field;
                foreach (PropertyDef prop in type.Properties)
                    yield return prop;
                foreach (EventDef evt in type.Events)
                    yield return evt;
            }
        }
        public static IEnumerable<IDnlibDef> FindDefinitions(TypeDef typeDef)
        {
            yield return typeDef;
            foreach (TypeDef nestedType in typeDef.NestedTypes)
                yield return nestedType;
            foreach (MethodDef method in typeDef.Methods)
                yield return method;
            foreach (FieldDef field in typeDef.Fields)
                yield return field;
            foreach (PropertyDef prop in typeDef.Properties)
                yield return prop;
            foreach (EventDef evt in typeDef.Events)
                yield return evt;
        }
        public static bool IsDelegate(TypeDef type)
        {
            if (type.BaseType == null)
                return false;
            string fullName = type.BaseType.FullName;
            return fullName == "System.Delegate" || fullName == "System.MulticastDelegate";
        }
        public static bool HasInstructions(MethodDef method)
        {
            if (method == null)
                new ArgumentNullException("method is null");
            if (method.Body.HasInstructions)
                return true;
            else
                return false;
        }
        public static bool HasVariables(MethodDef method)
        {
            if (method == null)
                new ArgumentNullException("method is null");
            if (method.Body.HasVariables)
                return true;
            else
                return false;
        }
        public static bool Simplify(MethodDef methodDef)
        {
            if (methodDef.Parameters == null)
                return false;
            methodDef.Body.SimplifyMacros(methodDef.Parameters);
            return true;
        }
        public static bool Optimize(MethodDef methodDef)
        {
            if (methodDef.Body == null)
                return false;
            methodDef.Body.OptimizeMacros();
            methodDef.Body.OptimizeBranches();
            return true;
        }
        public static bool hasExceptionHandlers(MethodDef methodDef)
        {
            if (methodDef.Body.HasExceptionHandlers)
                return true;
            return false;
        }
    }
}
