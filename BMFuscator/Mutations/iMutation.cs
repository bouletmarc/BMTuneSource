using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;

namespace BMDevs.Mutations
{
    public interface iMutation
    {
        void Process(MethodDef method, ref int index);
        void Prepare(TypeDef type);
        bool Supported(Instruction instr);
    }
}
