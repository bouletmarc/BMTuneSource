using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;

namespace BMDevs
{
    public class RenameObfuscation : IObfuscation
    {
        public void Execute(ModuleDefMD md)
        {
            foreach (var type in md.Types)
            {
                foreach (var method in type.Methods.Where(x => !x.IsConstructor && !x.IsVirtual && !x.IsManaged))
                {
                    //Console.WriteLine(method.Name);
                    if (method.Name != "Main")
                    {
                        Renamer.Rename(method, Renamer.RenameMode.Invalid2, 3);

                        //Renamer.Rename(method, Renamer.RenameMode.Logical, 3);

                    }
                }

                bool CanGo = true;
                foreach (var method in type.CustomAttributes)
                {
                    //Console.WriteLine(method.ToString());
                    //if (method.ToString().Contains("DoNotObfuscate") || method.TypeFullName.ToString().Contains("DoNotObfuscate")) CanGo = false;
                    if (method.ToString().Contains("DoNotObfuscate")) CanGo = false;
                    continue;
                }


                if (CanGo)
                {
                    foreach (var method in type.NestedTypes)
                    {
                        //Console.WriteLine(method.Name);
                        Renamer.Rename(method, Renamer.RenameMode.Invalid2, 3);
                    }

                    foreach (var method in type.Fields.Where(x => !x.IsAssembly))
                    {
                        if (method.DeclaringType == method.Module.GlobalType)
                        {
                            //Console.WriteLine(method.Name);
                            return;
                        }
                        //Console.WriteLine(method.Name);

                        Renamer.Rename(method, Renamer.RenameMode.Invalid2, 3);
                    }

                    /*foreach (var method in type.Events)
                    {
                        Renamer.Rename(method, Renamer.RenameMode.Invalid2, 3);
                    }
                    foreach (var method in type.Properties)
                    {
                        Renamer.Rename(method, Renamer.RenameMode.Invalid2, 3);
                    }*/
                }
            }
        }
    }
}
