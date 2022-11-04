using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMDevs.Utils
{


    interface IProtector
    {
        string Name { get; }
        void InjectPhase(Context krawk);
        void ProtectionPhase(Context krawk);
        

    }
}

