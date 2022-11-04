using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMDevs
{
    class Program
    {

        public static Worker Worker { get; set; }
        public static string path = "";

        public static void Main(string[] args)
        {
            FileInfo info;
            //path = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\BMTune_Encrypter\bin\Debug\BMTune.exe";
            //path = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\bin\Debug\BMTune.exe";
            //path = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2_Crypted\bin\Debug\BMTune.exe";
            //if (path != "") DoLoop();

            for (int i = 0; i < args.Length; i++)
            {
                //Console.WriteLine(args[i]);
                info = new FileInfo(args[i]);
                if (((info.Extension == ".exe")) && info.Exists)
                {
                    path = args[i];
                    DoLoop();
                }
            }

            if (path == "")
            {
                bool TestReload = true;
                int ObCount = 0;
                while (TestReload)
                {
                    Console.WriteLine("BMDevs Obfuscator.");
                    if (path == "")
                    {
                        Console.Write("Input an assembly: ");
                        path = Console.ReadLine();
                    }
                    Worker = new Worker(path);
                    Console.WriteLine("Choose options to obfuscate: ");

                    for (int i = 0; i < Worker.Obfuscations.Count; i++) Console.WriteLine(i + 1 + ") " + Worker.Obfuscations[i]);
                    string opts = Console.ReadLine();
                    Worker.ExecuteObfuscations(opts);
                    //Worker.Save();
                    //Console.ReadLine();

                    ObCount++;
                    Console.WriteLine("Do you want to reload: y\\n?");
                    string CommandContinu = Console.ReadLine();
                    if (CommandContinu == "n") TestReload = false;
                }


                Worker.Save();
            }

            //Console.ReadLine();
        }

        public static void RemakeNameToOriginal()
        {
            if (File.Exists(path))
            {
                if (!path.Contains("_BMFuscator")) path = path.Substring(0, path.Length - 4) + "_BMFuscator.exe";

                string TFile = path;
                string Name = path.Substring(0, path.Length - 15) + ".exe";

                File.Create(Name).Dispose();
                File.WriteAllBytes(Name, File.ReadAllBytes(TFile));


                File.Delete(TFile);
            }
        }

        public static void DoLoop()
        {
            Worker = new Worker(path);
            DoSingle("ControlFlowObfuscation");
            //DoSingle("JunkProtection");
            //DoSingle("BoolsToModuleReference"); //Little Slow
            //DoSingle("BytesToModuleReference"); //Little Slow
            //DoSingle("NumbersToModuleReference"); //Little Slow

            //DoSingle("ConstantsEncoding");        //Create very big delay
            DoSingle("MutationObf");
            //DoSingle("ReferenceProxy");           //app doesnt start

            //DoSingle("HiddenNamespace");
            DoSingle("RenameObfuscation");
            //DoSingle("ModuleRenaming");
            DoSingle("NumbersToModuleReference"); //Little Slow
            //DoSingle("AntiDe4dotProtection");
            //DoSingle("AntiILDasmProtection");
            Worker.Save();
            Worker = null;
            //RemakeNameToOriginal();
        }

        public static void DoSingle(string opts)
        {
            /*1) ConstantsEncoding
            2) ModuleRenaming
            3) HiddenNamespace
            4) ReferenceProxy
            5) RenameObfuscation
            6) MutationObf
            7) NumbersToModuleReference
            8) JunkProtection
            9) ControlFlowObfuscation*/

            Worker.ExecuteObfuscations(opts);

            /*int retrunr = 0;
            if (opts == "ConstantsEncoding") retrunr = 1;
            if (opts == "ModuleRenaming") retrunr = 2;
            if (opts == "HiddenNamespace") retrunr = 3;
            if (opts == "ReferenceProxy") retrunr = 4;
            if (opts == "RenameObfuscation") retrunr = 5;
            if (opts == "MutationObf") retrunr = 6;
            if (opts == "NumbersToModuleReference") retrunr = 7;
            if (opts == "JunkProtection") retrunr = 8;
            if (opts == "ControlFlowObfuscation") retrunr = 9;
            if (opts == "BoolsToModuleReference") retrunr = 10;
            if (opts == "BytesToModuleReference") retrunr = 11;

            Worker.ExecuteObfuscations(retrunr.ToString());*/
        }
    }
}
