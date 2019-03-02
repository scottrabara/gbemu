﻿using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions

/// <summary>
/// Base instruction for all XOR instructions.
/// All XOR instructions have two operXORs.
/// Logically XOR n with register A, result in A
/// </summary>
{
    class InstructionXOR : IInstruction
    {
        public string BaseInstruction { get; set; } = "XOR {0}, {1}";
        public IInstructionParam[] Params { get; set; }
        public IInstructionParam ParamOne => Params[0];
        public IInstructionParam ParamTwo => Params[1];
        public string ParsedInstruction => GetParsedInstruction();
        public int Ticks { get; set; }
        public int Opcode { get; set; }

        public Action Action => GetAction();

        private string GetParsedInstruction()
        {
            return string.Format(
                BaseInstruction,
                ParamOne == null ? "null" : ParamOne.ToString(),
                ParamTwo == null ? "null" : ParamTwo.ToString());
        }

        private Action GetAction()
        {
            return () =>
            {
                if (ParamOne != null && ParamTwo != null)
                {
                    ParamOne.Value ^= ParamTwo.Value;
                }
            };
        }
    }
}