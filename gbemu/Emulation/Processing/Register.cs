using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing
{
    internal class Register
    {
        public Register(RegisterEnum registerEnum)
        {
            Name = registerEnum;
        }

        internal int Value { get; set; }
        internal RegisterEnum Name { get; set; }
    }
}
