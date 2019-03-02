using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions
{
    /// <summary>
    /// Base instruction for all DEC instruction.
    /// All DEC instructions have one operand.
    /// </summary>
    public class InstructionDEC : IInstruction
    {
        public string BaseInstruction { get; set; } = "DEC {0}";
        public IInstructionParam[] Params { get; set; }
        public IInstructionParam ParamOne => Params[0];
        public string ParsedInstruction => GetParsedInstruction();
        public int Ticks { get; set; }
        public int Opcode { get; set; }

        public Action Action => GetAction();

        private string GetParsedInstruction()
        {
            return string.Format(
                BaseInstruction,
                ParamOne == null ? "null" : ParamOne.ToString());
        }

        private Action GetAction()
        {
            return () =>
            {
                if (ParamOne != null)
                {
                    ParamOne.Value = ParamOne.Value == 0 ? 0 : ParamOne.Value - 1;
                }
            };
        }
    }
}
