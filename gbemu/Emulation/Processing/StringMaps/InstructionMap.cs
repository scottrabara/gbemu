using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.StringMaps
{
    /// <summary>
    /// Map for representing all possibilities of an instruction given an opcode.
    /// Using a Hexadecimal representation of the 255 instruction set for the Gameboy CPU.
    /// Example: First four characters of StringMapLD is 7010, opcode given is 2.
    ///     "7010" (hex string) = "0111000000010000" (binary string)
    /// Bit character at position 2 is 1. Use the LD instruction.
    /// </summary>
    internal static class InstructionMap
    {
        // TODO: Create maps for all instruction types given an opcode.

        const string StringMapLD = "6010601060106010FFFFFFFFFFFFFFFF000000000000000000000000A020A020";

        internal static Type GetInstruction(int opcode)
        {
            if (StringMapLD.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionLD);
            }
            return null;
        }

    }
}
