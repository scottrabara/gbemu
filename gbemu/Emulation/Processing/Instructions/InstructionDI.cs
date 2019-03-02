using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions
{
    /// <summary>
    /// Disable Interrupts after the next instruction is executed
    /// </summary>

    public class InstructionDI : IInstruction
    {
        public string BaseInstruction { get; set; } = "Disable Interrupts";
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
            { };  //Needs implementation 
        }
    }
}
    

