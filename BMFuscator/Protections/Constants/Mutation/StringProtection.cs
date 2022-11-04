using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Microsoft.VisualBasic;
using Krawk.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using Krawk_Protector.Utils;
namespace Krawk_Protector.Protections.Constants
{
    class StringProtection : IProtector
    {
        string IProtector.Name => "StringProtection";
     
        public void InjectPhase(Context Krawk)
        {
        }
        public void ProtectionPhase(Context Krawk)
        {
        }

    }





}
