using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;

namespace BMDevs
{
    public class ModuleRenaming : IObfuscation
    {
        public void Execute(ModuleDefMD md)
        {
            string shit = Renamer.GetFuckedString2(4);
            //string shit = Renamer.GetRandomName();
            Logger.LogMessage("Renaming module to ", shit, ConsoleColor.Red);
            md.Name = shit;
        }
    }
}
