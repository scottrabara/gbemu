using GBEmu.Emulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Utils
{
    public static class RegisterOperators
    {
        public static int Assign(this int a, int b)
        {
            a = b;
            return a;
        }
    }
}
