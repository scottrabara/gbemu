using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions

/// <summary>
/// Base instruction for all OR instructions.
/// All OR instructions have two operORs.
/// Logically OR n with register A, result in A
/// </summary>
{
    class InstructionOR : IInstruction
    {
        public string BaseInstruction { get; set; } = "OR {0}, {1}";
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
                    ParamOne.Value |= ParamTwo.Value;
                }
            };
        }
    }
}