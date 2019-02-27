using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Abstractions
{
    public interface IInstruction
    {
        string BaseInstruction { get; set; }
        string ParsedInstruction { get; }
        IInstructionParam[] Params { get; set; }
        Action Action { get; }
        int Ticks { get; set; }
        int Opcode { get; set; }
    }
}
