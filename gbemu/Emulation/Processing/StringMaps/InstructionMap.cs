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

        const string StringMapNOP =
            "8000000000000000000000000000000000000000000000000000000000000000";
        const string StringMapSTOP =
            "0000800000000000000000000000000000000000000000000000000000000000";
        const string StringMapHALT =
            "0000000000000000000000000000020000000000000000000000000000000000";
        const string StringMapLD =
            "6010601060106010FFFFFFFFFFFFFDFF000000000000000000000000A020A020";
        const string StringMapLDH =
            "";
        const string StringMapDEC =
            "0414041404140414000000000000000000000000000000000000000000000000";
        const string StringMapINC =
            "1808180818081808000000000000000000000000000000000000000000000000";
        const string StringMapADD =
            "00400040004000400000000000000000FF000000000000000200000000800000";
        const string StringMapADC =
            "";
        const string StringMapSUB =
            "000000000000000000000000000000000000FF00000000000000020000000000";
        const string StringMapSBC =
            "";
        const string StringMapAND =
            "0000000000000000000000000000000000000000FF0000000000000000000000";
        const string StringMapXOR =
            "000000000000000000000000000000000000000000FF00000000000000000000";
        const string StringMapOR =
            "00000000000000000000000000000000000000000000FF000000000000000000";
        const string StringMapCP =
            "0000000000000000000000000000000000000000000000FF0000000000000000";
        const string StringMapDI =
            "0000000000000000000000000000000000000000000000000000000000001000";
        const string StringMapEI =
            "0000000000000000000000000000000000000000000000000000000000000010";
        const string StringMapJP =
            "";
        const string StringMapJR =
            "";
        const string StringMapRST =
            "";
        const string StringMapRET =
            "";
        const string StringMapRETI =
            "";
        const string StringMapPUSH =
            "";
        const string StringMapPOP =
            "";
        const string StringMapCALL =
            "";
        const string StringMapRLCA =
            "";
        const string StringMapRLA =
            "";
        const string StringMapDAA =
            "";
        const string StringMapSCF =
            "";
        internal static Type GetInstruction(int opcode)
        {
            if (StringMapNOP.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionNOP);
            }
            if (StringMapSTOP.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionSTOP);
            }
            if (StringMapHALT.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionHALT);
            }
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
            if (StringMapAND.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionAND);
            }
            if (StringMapXOR.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionXOR);
            }
            if (StringMapOR.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionOR);
            }
            if (StringMapCP.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionCP);
            }
            if (StringMapDI.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionDI);
            }
            if (StringMapEI.ContainsBitCharInMap(opcode))
            {
                return typeof(InstructionEI);
            }
            return null;
        }

    }
}
