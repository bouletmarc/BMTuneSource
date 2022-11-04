using dnlib.DotNet;

namespace BMDevs.Protections
{
    class AntiILDasmProtection : IObfuscation
    {
        public void Execute(ModuleDefMD ManifestModule)
        {
            TypeRef supressref = ManifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressIldasmAttribute"); 
            var ctorRef = new MemberRefUser(ManifestModule, ".ctor", MethodSig.CreateInstance(ManifestModule.CorLibTypes.Void), supressref);
            var supressattribute = new CustomAttribute(ctorRef);
            ManifestModule.CustomAttributes.Add(supressattribute);

            TypeRef supressref2 = ManifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "UnsafeValueTypeAttribute");
            var ctorRef2 = new MemberRefUser(ManifestModule, ".ctor", MethodSig.CreateInstance(ManifestModule.CorLibTypes.Void), supressref2);
            var supressattribute2 = new CustomAttribute(ctorRef2);
            ManifestModule.CustomAttributes.Add(supressattribute2);

            TypeRef supressref3 = ManifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "RuntimeWrappedException");
            var ctorRef3 = new MemberRefUser(ManifestModule, ".ctor", MethodSig.CreateInstance(ManifestModule.CorLibTypes.Void), supressref3);
            var supressattribute3 = new CustomAttribute(ctorRef3);
            ManifestModule.CustomAttributes.Add(supressattribute3);

            TypeRef supressref4 = ManifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "UnverifiableCodeAttribute");
            var ctorRef4 = new MemberRefUser(ManifestModule, ".ctor", MethodSig.CreateInstance(ManifestModule.CorLibTypes.Void), supressref4);
            var supressattribute4 = new CustomAttribute(ctorRef4);
            ManifestModule.CustomAttributes.Add(supressattribute4);

            TypeRef supressref5 = ManifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressUnmanagedCodeSecurity");
            var ctorRef5 = new MemberRefUser(ManifestModule, ".ctor", MethodSig.CreateInstance(ManifestModule.CorLibTypes.Void), supressref5);
            var supressattribute5 = new CustomAttribute(ctorRef5);
            ManifestModule.CustomAttributes.Add(supressattribute5);

            TypeRef supressref6 = ManifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "ProtectedByBMDevs");
            var ctorRef6 = new MemberRefUser(ManifestModule, ".ctor", MethodSig.CreateInstance(ManifestModule.CorLibTypes.Void), supressref6);
            var supressattribute6 = new CustomAttribute(ctorRef6);
            ManifestModule.CustomAttributes.Add(supressattribute6);

            /*TypeRef supressref7 = ManifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "BMDevsProperties");
            var ctorRef7 = new MemberRefUser(ManifestModule, ".ctor", MethodSig.CreateInstance(ManifestModule.CorLibTypes.Void), supressref7);
            var supressattribute7 = new CustomAttribute(ctorRef7);
            ManifestModule.CustomAttributes.Add(supressattribute7);*/
        }
    }
}
