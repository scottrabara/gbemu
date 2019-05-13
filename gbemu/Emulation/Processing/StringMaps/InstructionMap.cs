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
    internal static class InstructionMap
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
    }
}
