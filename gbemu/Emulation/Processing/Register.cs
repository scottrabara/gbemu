using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing
{
    /// <summary>
    /// Class representing a register in the Gameboy CPU
    /// </summary>
    internal class Register
    {
        /// <summary>
        /// Create a register instance based on a RegisterEnum.
        /// </summary>
        /// <param name="registerEnum"></param>
        public Register(RegisterEnum registerEnum)
        {
            Name = registerEnum;
        }

        internal int Value { get; set; }
        internal RegisterEnum Name { get; set; }
    }
}
