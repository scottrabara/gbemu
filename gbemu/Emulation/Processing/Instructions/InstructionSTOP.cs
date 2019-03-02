using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions
{
    /// <summary>
    /// Halt CPU and LCD Display until button is pressed
    /// </summary>
    public class InstructionSTOP : IInstruction
    {
        public string BaseInstruction { get; set; } = "Halt CPU and LCD Display until button is pressed";
        public IInstructionParam[] Params { get; set; }
        public string ParsedInstruction => GetParsedInstruction();
        public int Ticks { get; set; }
        public int Opcode { get; set; }

        public Action Action => GetAction();

        private string GetParsedInstruction()
        {
            return string.Format(
                BaseInstruction);
        }

        private Action GetAction()
        {
            return () =>
            { };
        }
    }
}