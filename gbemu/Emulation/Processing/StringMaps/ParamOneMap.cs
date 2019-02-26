using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.StringMaps
{
    public static class ParamOneMap
    {
        const string A =
            "002000200020002000000000000000FFFFFFFFFFFFFFFFFF090909090909A222";
        const string BC =
            "7010701070107010000000000000000000000000000000000000000000004410";

        public static IInstructionParam GetParamOne(Processor processor, int opcode)
        {
            if (A.ToBinary()[opcode] == '1')
            {
                return new RegisterParam(processor.Registers.A);
            }
            if (BC.ToBinary()[opcode] == '1')
            {
                return new RegisterParam(processor.Registers.BC);
            }
            return null;
        }
    }
}
