using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instruction;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.StringMaps
{
    /// <summary>
    /// Map for representing all possibilities of an instruction given an opcode.
    /// </summary>
    internal static class Lookup
    {
        internal static readonly Type[] Ins = new Type[]
        {
            typeof(InstructionNOP),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionINC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionRLCA),
            typeof(InstructionLD),typeof(InstructionADD),typeof(InstructionLD),typeof(InstructionDEC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionRRCA),

            typeof(InstructionSTOP),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionINC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionRLA),
            typeof(InstructionJR),typeof(InstructionADD),typeof(InstructionLD),typeof(InstructionDEC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionRRA),

            typeof(InstructionJR),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionINC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionDAA),
            typeof(InstructionJR),typeof(InstructionADD),typeof(InstructionLD),typeof(InstructionDEC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionCPL),

            typeof(InstructionJR),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionINC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionSCF),
            typeof(InstructionJR),typeof(InstructionADD),typeof(InstructionLD),typeof(InstructionDEC),
            typeof(InstructionINC),typeof(InstructionDEC),typeof(InstructionLD),typeof(InstructionCCF),

            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),

            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),

            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),

            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionHALT),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),

            typeof(InstructionADD),typeof(InstructionADD),typeof(InstructionADD),typeof(InstructionADD),
            typeof(InstructionADD),typeof(InstructionADD),typeof(InstructionADD),typeof(InstructionADD),
            typeof(InstructionADC),typeof(InstructionADC),typeof(InstructionADC),typeof(InstructionADC),
            typeof(InstructionADC),typeof(InstructionADC),typeof(InstructionADC),typeof(InstructionADC),

            typeof(InstructionSUB),typeof(InstructionSUB),typeof(InstructionSUB),typeof(InstructionSUB),
            typeof(InstructionSUB),typeof(InstructionSUB),typeof(InstructionSUB),typeof(InstructionSUB),
            typeof(InstructionSBC),typeof(InstructionSBC),typeof(InstructionSBC),typeof(InstructionSBC),
            typeof(InstructionSBC),typeof(InstructionSBC),typeof(InstructionSBC),typeof(InstructionSBC),

            typeof(InstructionAND),typeof(InstructionAND),typeof(InstructionAND),typeof(InstructionAND),
            typeof(InstructionAND),typeof(InstructionAND),typeof(InstructionAND),typeof(InstructionAND),
            typeof(InstructionXOR),typeof(InstructionXOR),typeof(InstructionXOR),typeof(InstructionXOR),
            typeof(InstructionXOR),typeof(InstructionXOR),typeof(InstructionXOR),typeof(InstructionXOR),

            typeof(InstructionOR),typeof(InstructionOR),typeof(InstructionOR),typeof(InstructionOR),
            typeof(InstructionOR),typeof(InstructionOR),typeof(InstructionOR),typeof(InstructionOR),
            typeof(InstructionCP),typeof(InstructionCP),typeof(InstructionCP),typeof(InstructionCP),
            typeof(InstructionCP),typeof(InstructionCP),typeof(InstructionCP),typeof(InstructionCP),

            typeof(InstructionRET),typeof(InstructionPOP),typeof(InstructionJP),typeof(InstructionJP),
            typeof(InstructionCALL),typeof(InstructionPUSH),typeof(InstructionADD),typeof(InstructionRST),
            typeof(InstructionRET),typeof(InstructionRET),typeof(InstructionJP),typeof(InstructionPREFIX),
            typeof(InstructionCALL),typeof(InstructionCALL),typeof(InstructionADC),typeof(InstructionRST),

            typeof(InstructionRET),typeof(InstructionPOP),typeof(InstructionJP), null,
            typeof(InstructionCALL),typeof(InstructionPUSH),typeof(InstructionSUB),typeof(InstructionRST),
            typeof(InstructionRET),typeof(InstructionRETI),typeof(InstructionJP),null,
            typeof(InstructionCALL),null,typeof(InstructionSBC),typeof(InstructionRST),

            typeof(InstructionLDH),typeof(InstructionPOP),typeof(InstructionLD),null,
            null,typeof(InstructionPUSH),typeof(InstructionAND),typeof(InstructionRST),
            typeof(InstructionADD),typeof(InstructionJP),typeof(InstructionLD),null,
            null,null,typeof(InstructionXOR),typeof(InstructionRST),

            typeof(InstructionLDH),typeof(InstructionPOP),typeof(InstructionLD),typeof(InstructionDI),
            null,typeof(InstructionPUSH),typeof(InstructionOR),typeof(InstructionRST),
            typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionLD),typeof(InstructionEI),
            null,null,typeof(InstructionCP),typeof(InstructionRST)
        };

        internal static readonly int[] Ticks = new int[]
        {
            4, 12,   8,  8,  4,  4,  8, 4, 20,  8,  8,  8, 4,  4,  8, 4, //0x
            4, 12,   8,  8,  4,  4,  8, 4, 12,  8,  8,  8, 4,  4,  8, 4, //1x
            8, 12,   8,  8,  4,  4,  8, 4,  8,  8,  8,  8, 4,  4,  8, 4, //2x
            8, 12,   8,  8, 12, 12, 12, 4,  8,  8,  8,  8, 4,  4,  8, 4, //3x
            4,  4,   4,  4,  4,  4,  8, 4,  4,  4,  4,  4, 4,  4,  8, 4, //4x
            4,  4,   4,  4,  4,  4,  8, 4,  4,  4,  4,  4, 4,  4,  8, 4, //5x
            4,  4,   4,  4,  4,  4,  8, 4,  4,  4,  4,  4, 4,  4,  8, 4, //6x
            8,  8,   8,  8,  8,  8,  4, 8,  4,  4,  4,  4, 4,  4,  8, 4, //7x
            4,  4,   4,  4,  4,  4,  8, 4,  4,  4,  4,  4, 4,  4,  8, 4, //8x
            4,  4,   4,  4,  4,  4,  8, 4,  4,  4,  4,  4, 4,  4,  8, 4, //9x
            4,  4,   4,  4,  4,  4,  8, 4,  4,  4,  4,  4, 4,  4,  8, 4, //Ax
            4,  4,   4,  4,  4,  4,  8, 4,  4,  4,  4,  4, 4,  4,  8, 4, //Bx
            8,  12, 12, 16, 12, 16, 8, 16,  8, 16, 12, 4, 12, 24, 8, 16, //Cx
            8,  12, 12,  0, 12, 16, 8, 16,  8, 16, 12, 0, 12,  0, 8, 16, //Dx
            12, 12,  8,  0,  0, 16, 8, 16, 16,  4, 16, 0,  0,  0, 8, 16, //Ex
            12, 12,  8,  4,  0, 16, 8, 16, 12,  8, 16, 4,  0,  0, 8, 16  //Fx
        };
    }
}
