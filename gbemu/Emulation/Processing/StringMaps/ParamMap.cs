using System;
using System.Collections.Generic;
using System.Text;
using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Utils;

namespace GBEmu.Emulation.Processing.StringMaps
{
    /// <summary>
    /// Map of when to use Registers
    /// Each string represents the 255 instructions in hex
    /// When compared to opcode as binary, we can tell whether a register is used
    /// </summary>
    static class ParamMap
    {
        public static IInstructionParam[] GetParams(Processor processor, int opcode)
        {
            var paramOne = ParamOneMap.GetParamOne(processor, opcode);
            var paramTwo = ParamTwoMap.GetParamTwo(processor, opcode);
            var instructionParams = new[] { paramOne, paramTwo };

            return instructionParams;
        }
    }
}
