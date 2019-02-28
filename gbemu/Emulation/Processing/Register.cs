using GBEmu.Utils;
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

        public Register(RegisterEnum registerEnum, bool isPair)
        {
            Name = registerEnum;
            IsPair = isPair;
        }

        internal int Value { get; set; }
        internal RegisterEnum Name { get; set; }
        internal bool IsPair { get; set; }

        public override string ToString()
        {
            if (IsPair)
            {
                var left = Value.GetLeftByte();
                var right = Value.GetRightByte();
                var result = $"0x{left.ToString("X2")}{right.ToString("X2")}";
                return result;
            }
            return $"0x{Value.ToString("X2")}";
        }
    }
}
