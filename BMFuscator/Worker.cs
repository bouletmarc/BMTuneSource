using BMDevs.Runtime;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMDevs
{
    public class Worker
    {
        private Assembly OwnAssembly => this.GetType().Assembly;
        public Assembly Default_Assembly { get; set; }
        public AssemblyDef Assembly { get; set; }
        public ModuleDefMD Module { get; set; }
        public string Path { get; set; }
        public string Code { get; set; }

        public Worker(string path)
        {
            if (path != "")
            {
                Path = path.Replace("\"", "");
                LoadAssembly();
                LoadModuleDefMD();
                LoadObfuscations();
                LoadDependencies();
                RuntimeHelper.Importer = new Importer(Module);
            }
        }

        public void Watermark()
        {
            Console.WriteLine("Creating global .cctors...");
            TypeDef modType = Module.GlobalType;
            if (modType == null)
            {
                modType = new TypeDefUser("", "<Module>", null);
                modType.Attributes = dnlib.DotNet.TypeAttributes.AnsiClass;
                Module.Types.Add(modType);

                MethodDef cctor = modType.FindOrCreateStaticConstructor();
                modType.Methods.Add(cctor);
            }


            Console.WriteLine("Watermarking...");
            TypeRef attrRef = Module.CorLibTypes.GetTypeRef("System", "Attribute");
            var attrType = new TypeDefUser("", "BMDevsProtectedProperty", attrRef);
            Module.Types.Add(attrType);
            var ctor = new MethodDefUser(
                ".ctor",
                MethodSig.CreateInstance(Module.CorLibTypes.Void, Module.CorLibTypes.String),
                dnlib.DotNet.MethodImplAttributes.Managed,
                dnlib.DotNet.MethodAttributes.HideBySig | dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.SpecialName | dnlib.DotNet.MethodAttributes.RTSpecialName);
            ctor.Body = new CilBody();
            ctor.Body.MaxStack = 1;
            ctor.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
            ctor.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Module, ".ctor", MethodSig.CreateInstance(Module.CorLibTypes.Void), attrRef)));
            ctor.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
            attrType.Methods.Add(ctor);
            var attr = new CustomAttribute(ctor);
            attr.ConstructorArguments.Add(new CAArgument(Module.CorLibTypes.String, "BMDevs Protected Property"));
            Module.CustomAttributes.Add(attr);
        }

        public void ExecuteObfuscations(string param)
        {
            Code = param;
            //var shit = param.ToCharArray().ToList();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for ( int i = 0; i < Obfuscations.Count; i++)
            //foreach (var v in shit)
            {
                if (Obfuscations[i] == param)
                {
                    //int i = int.Parse(v.ToString()) - 1;
                    //Console.WriteLine("geseg " + Obfuscations[i]);
                    Logger.LogMessage("Executing ", Obfuscations[i], ConsoleColor.Magenta);
                    Type type = OwnAssembly.GetTypes().First(x => x.Name == Obfuscations[i]);
                    var instance = Activator.CreateInstance(type);
                    MethodInfo info = type.GetMethod("Execute");
                    try
                    {
                        info.Invoke(instance, new object[] { Module });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("Time taken: " + watch.Elapsed.ToString());
        }

        public void LoadAssembly()
        {
            //try
            //{
                Console.WriteLine("Loading assembly...");
                Default_Assembly = System.Reflection.Assembly.UnsafeLoadFrom(Path);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Loaded: ");
                Console.WriteLine(Default_Assembly.FullName);
                Console.ForegroundColor = ConsoleColor.White;
            /*}
            catch(Exception mess)
            {
                Console.WriteLine("CANT LOAD: " + mess);
            }*/
        }

        public void LoadModuleDefMD()
        {
            Console.WriteLine("Loading ModuleDefMD...");
            Module = ModuleDefMD.Load(Path);
            Assembly = Module.Assembly;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Loaded: ");
            Console.WriteLine(Module.FullName);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LoadDependencies()
        {
            Console.WriteLine("Resolving dependencies...");
            var asmResolver = new AssemblyResolver();
            ModuleContext modCtx = new ModuleContext(asmResolver);
            
            asmResolver.DefaultModuleContext = modCtx;

            asmResolver.EnableTypeDefCache = true;

            asmResolver.DefaultModuleContext = new ModuleContext(asmResolver);
            asmResolver.PostSearchPaths.Insert(0, Path);
            if (IsCosturaPresent(Module))
            {
                foreach (var asm in ExtractCosturaEmbeddedAssemblies(GetEmbeddedCosturaAssemblies(Module), Module))
                    asmResolver.AddToCache(asm);
            }

            foreach (var dependency in Module.GetAssemblyRefs())
            {
				try 
                {
                    AssemblyDef assembly = asmResolver.ResolveThrow(dependency, Module);
                    Console.WriteLine("Resolved " + dependency.Name);
                }
                catch (AssemblyResolveException ex)
                {
                    Console.WriteLine("Failed to resolve dependency of '" + dependency.Name + "'");
                }
            }
            /*foreach (var dependency in Module.GetAssemblyRefs().Select(asmRef => Tuple.Create(asmRef, Module)))
            {
				try 
                {
					AssemblyDef assembly = asmResolver.ResolveThrow(dependency.Item1, dependency.Item2);
                    Console.WriteLine("Resolved " + dependency.Item2.Name);
                }
				catch (AssemblyResolveException ex) 
                {
                    Console.WriteLine("Failed to resolve dependency of '" + dependency.Item2.Name + "':" + ex);
				}
            }*/

            Module.Context = modCtx;
        }

        public bool IsCosturaPresent(ModuleDef module) =>
            module.Types.FirstOrDefault(t => t.Name == "AssemblyLoader" && t.Namespace == "Costura") != null;

        public string[] GetEmbeddedCosturaAssemblies(ModuleDef module)
        {
            var list = new List<string>();

            var ctor = module.Types.Single(t => t.Name == "AssemblyLoader" && t.Namespace == "Costura").FindStaticConstructor();
            var instructions = ctor.Body.Instructions;
            for (var i = 1; i < instructions.Count; i++)
            {
                var curr = instructions[i];
                if (curr.OpCode != OpCodes.Ldstr || instructions[i - 1].OpCode != OpCodes.Ldstr)
                    continue;

                var resName = ((string)curr.Operand).ToLowerInvariant();
                if (resName.EndsWith(".pdb") || resName.EndsWith(".pdb.compressed"))
                {
                    i++;
                    continue;
                }

                list.Add((string)curr.Operand);
            }

            return list.ToArray();
        }

        public List<AssemblyDef> ExtractCosturaEmbeddedAssemblies(string[] assemblies, ModuleDef module)
        {
            var list = new List<AssemblyDef>();

            foreach (var assembly in assemblies)
            {
                var resource = module.Resources.FindEmbeddedResource(assembly.ToLowerInvariant());
                if (resource == null)
                    throw new Exception("Couldn't find Costura embedded assembly: " + assembly);

                if (resource.Name.EndsWith("_BMFuscator.exe"))
                {
                    list.Add(DecompressCosturaAssembly(resource.GetResourceStream()));
                    continue;
                }

                list.Add(AssemblyDef.Load(resource.GetResourceStream()));
            }

            return list;
        }

        public AssemblyDef DecompressCosturaAssembly(Stream resource)
        {
            using (var def = new DeflateStream(resource, CompressionMode.Decompress))
            {
                var ms = new MemoryStream();
                def.CopyTo(ms);
                ms.Position = 0;
                return AssemblyDef.Load(ms);
            }
        }

        public void Save()
        {
            Watermark();
            string NewPath = Path;
            if (!Path.Contains("_BMFuscator")) NewPath = Path.Substring(0, Path.Length - 4) + "_BMFuscator.exe";
            Logger.LogMessage("Saving as ", NewPath, ConsoleColor.Yellow);
            ModuleWriterOptions opts = new ModuleWriterOptions(Module);
            opts.Logger = DummyLogger.NoThrowInstance;
            Assembly.Write(NewPath, opts);
            Console.WriteLine("Saved.");
        }

        public void LoadObfuscations()
        {
            Obfuscations = new List<string>();
            var ass = this.GetType().Assembly;
            var types = ass.GetTypes();
            foreach (Type type in Enumerable.Where<Type>(types, (Type t) => t != null))
            {
                if (type.GetInterface("IObfuscation") != null)
                {
                    Obfuscations.Add(type.Name);
                    Console.WriteLine("Loaded Module: " + type.Name);
                }
            }
        }

        public List<string> Obfuscations { get; set; }
    }
}
