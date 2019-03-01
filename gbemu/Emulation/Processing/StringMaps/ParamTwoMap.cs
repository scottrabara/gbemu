using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Emulation.Processing.Params;
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
            "20002000200020000101010101010101010101010101000000000000A020A000";
        const string B =
            "0000000000000000808080808080808080808080808080800000000000000000";
        const string C =
            "0000000000000000404040404040404040404040404040400000000000000000";
        const string D =
            "0000000000000000202020202020202020202020202020200000000000000000";
        const string E =
            "0000000000000000101010101010101010101010101010100000000000000000";
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
            "4000400040004000000000000000000000000000000000000000000000000000";
        const string Immediate8Bit =
            "0202020202020202000000000000000000000000000000000202020202020202";
        #endregion

        // TODO: Hook up the StringMap checking
        public static IInstructionParam GetParamTwo(Processor processor, int opcode)
        {
            if (A.ContainsBitCharInMap(opcode))
                return new RegisterParam(processor.Registers.A);
            if (B.ContainsBitCharInMap(opcode))
                return new RegisterParam(processor.Registers.B);
            if (C.ContainsBitCharInMap(opcode))
                return new RegisterParam(processor.Registers.C);
            if (D.ContainsBitCharInMap(opcode))
                return new RegisterParam(processor.Registers.D);
            if (E.ContainsBitCharInMap(opcode))
                return new RegisterParam(processor.Registers.E);
            if (Immediate16Bit.ContainsBitCharInMap(opcode))
                return new MemoryParam(processor, processor.Immediate16Bits(), 16);
            if (Immediate8Bit.ContainsBitCharInMap(opcode))
                return new MemoryParam(processor, processor.Immediate8Bits(), 8);
            return null;
        }
    }
}
