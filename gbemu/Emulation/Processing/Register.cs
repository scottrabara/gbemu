using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing
{
    /// <summary>
    /// Struct representing a register in the Gameboy CPU
    /// </summary>
    internal class Register
    {
        internal int Value { get; set; }
        internal RegisterEnum Name { get; set; }

        /// <summary>
        /// Create a register instance based on a RegisterEnum.
        /// </summary>
        /// <param name="registerEnum"></param>
        public Register(RegisterEnum registerEnum)
        {
            Name = registerEnum;
            Value = 0;
        }
        
        public override string ToString()
        {
            return $"0x{Value.ToString("X2")}";
        }
    }
}
