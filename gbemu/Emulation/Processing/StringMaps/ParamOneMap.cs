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
    public static class ParamOneMap
    {
        // TODO: Create maps for all registers given an opcode.

        const string A =
            "002000200020002000000000000000FFFFFFFFFFFFFFFFFF090909090909A222";
        const string BC =
            "7010701070107010000000000000000000000000000000000000000000004410";

        public static IInstructionParam GetParamOne(Processor processor, int opcode)
        {
            if (A.ToBinary()[opcode] == '1')
            {
                return new RegisterParam(processor.Registers.A);
            }
            if (BC.ToBinary()[opcode] == '1')
            {
                return new RegisterParam(processor.Registers.BC);
            }
            return null;
        }
    }
}
