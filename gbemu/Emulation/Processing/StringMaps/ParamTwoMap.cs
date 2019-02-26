using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.StringMaps
{
    /// <summary>
    /// Map for representing all possibilities of an parameter given an opcode.
    /// Using a Hexadecimal representation of the 255 instruction set for the Gameboy CPU.
    /// Example: First four characters of A is 0020, opcode given is 11.
    ///     "0020" (hex string) = "0000000000100000" (binary string)
    /// Bit character at position 11 is 1. Use the A Register.
    /// </summary>
    static class ParamTwoMap
    {
        // TODO: Create maps for all registers given an opcode.
        #region Register Based Constants
        const string A =
            "";
        const string B =
            "";
        const string C =
            "";
        const string D =
            "";
        const string E =
            "";
        const string F =
            "";
        const string H =
            "";
        const string L =
            "";
        const string HL =
            "";
        const string BC =
            "";
        const string DE =
            "";
        const string AF =
            "";
        #endregion

        #region Memory Based Constants
        const string AddressAtBC =
            "";
        const string AddressAtDE =
            "";
        const string AddressAtHL =
            "";
        const string AddressAtC =
            "";
        const string Immediate16Bit =
            "";
        const string Immediate8Bit =
            "";
        #endregion

        // TODO: Hook up the StringMap checking
        public static IInstructionParam GetParamTwo(Processor processor, int opcode)
        {
            return null;
        }
    }
}
