using dnlib.DotNet;
using Krawk_Protector.Utils;
using System;
using System.Linq;

namespace Krawk_Protector.Protections
{
    class RenameAssembly : IProtector
    {
        string IProtector.Name => "RenameAssembly";
       
        void IProtector.InjectPhase(Context krawk) { }
        void IProtector.ProtectionPhase(Context krawk)
        {
            Random rnd = new Random();
            var ManifestModule = krawk.ManifestModule;
            const string chars = "糜級糠素絲絮綋維綖綰緊緌緌綅綟綣絡絇絈絋紭累糺糗糎粫粨粍粶粒籐籓籰米";
            string xD =  new string(Enumerable.Repeat(chars, 10)
      .Select(s => s[rnd.Next(s.Length)]).ToArray());
            string xD1 = new string(Enumerable.Repeat(chars, 10)
      .Select(s => s[rnd.Next(s.Length)]).ToArray());
            ManifestModule.Name = string.Format(" Krawk - {0} ",xD);
            ManifestModule.Assembly.Name = string.Format(" Krawk - {0} ", xD1);
        }

    }
}
