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

        const string StringMapLD = 
            "6010601060106010FFFFFFFFFFFFFFFF000000000000000000000000A020A020";
        const string StringMapDEC =
            "0414041404140414000000000000000000000000000000000000000000000000";
        const string StringMapINC =
            "1808180818081808000000000000000000000000000000000000000000000000";
        const string StringMapADD =
            "00400040004000400000000000000000FF000000000000000200000000800000";
        const string StringMapSUB =
            "000000000000000000000000000000000000FF00000000000000020000000000"; 

        internal static Type GetInstruction(int opcode)
        {
            if (StringMapLD.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionLD);
            }
            if (StringMapDEC.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionDEC);
            }
            if (StringMapINC.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionINC);
            }
            if (StringMapADD.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionADD);
            }
            if (StringMapSUB.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionSUB);
            }
            return null;
        }

    }
}
