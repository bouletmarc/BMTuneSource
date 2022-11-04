using dnlib.DotNet;

namespace BMDevs.Protections
{
    class AntiDe4dotProtection : IObfuscation
    {
        public void Execute(ModuleDefMD md)
        {
            InterfaceImpl interfaceM = new InterfaceImplUser(md.GlobalType);

            TypeDef typeDef1 = new TypeDefUser("", "Form", md.CorLibTypes.GetTypeRef("System", "Attribute"));
            InterfaceImpl item1 = new InterfaceImplUser(typeDef1);
            md.Types.Add(typeDef1);
            typeDef1.Interfaces.Add(item1);

            TypeDef typeDef2 = new TypeDefUser("", "Program", md.CorLibTypes.GetTypeRef("System", "Attribute"));
            InterfaceImpl item2 = new InterfaceImplUser(typeDef2);
            md.Types.Add(typeDef2);
            typeDef2.Interfaces.Add(item2);

            for (int i = 1; i < 55; i++)
            {
                typeDef1 = new TypeDefUser("", "Form" + i.ToString(), md.CorLibTypes.GetTypeRef("System", "Attribute"));
                item1 = new InterfaceImplUser(typeDef1);
                md.Types.Add(typeDef1);
                typeDef1.Interfaces.Add(item1);
            }
            for (int i = 1; i < 34; i++)
            {
                typeDef1 = new TypeDefUser("", "class" + i.ToString(), md.CorLibTypes.GetTypeRef("System", "Attribute"));
                item1 = new InterfaceImplUser(typeDef1);
                md.Types.Add(typeDef1);
                typeDef1.Interfaces.Add(item1);
            }
            for (int i = 1; i < 70; i++)
            {
                typeDef1 = new TypeDefUser("", "parm" + i.ToString(), md.CorLibTypes.GetTypeRef("System", "Attribute"));
                item1 = new InterfaceImplUser(typeDef1);
                md.Types.Add(typeDef1);
                typeDef1.Interfaces.Add(item1);
            }
            for (int i = 1; i < 10; i++)
            {
                typeDef1 = new TypeDefUser("", "struct" + i.ToString(), md.CorLibTypes.GetTypeRef("System", "Attribute"));
                item1 = new InterfaceImplUser(typeDef1);
                md.Types.Add(typeDef1);
                typeDef1.Interfaces.Add(item1);
            }
            for (int i = 1; i < 20; i++)
            {
                typeDef1 = new TypeDefUser("", "ctrl" + i.ToString(), md.CorLibTypes.GetTypeRef("System", "Attribute"));
                item1 = new InterfaceImplUser(typeDef1);
                md.Types.Add(typeDef1);
                typeDef1.Interfaces.Add(item1);
            }
            for (int i = 1; i < 40; i++)
            {
                typeDef1 = new TypeDefUser("", "Data" + i.ToString(), md.CorLibTypes.GetTypeRef("System", "Attribute"));
                item1 = new InterfaceImplUser(typeDef1);
                md.Types.Add(typeDef1);
                typeDef1.Interfaces.Add(item1);
            }
        }
    }
}
