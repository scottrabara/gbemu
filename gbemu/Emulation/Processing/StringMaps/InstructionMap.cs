using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.StringMaps
{
    static class InstructionMap
    {
        const string StringMapLD = "7010701070107010FFFFFFFFFFFFFFFF000000000000000000000000A020A020";

        public static Type GetInstruction(int opcode)
        {
            if (StringMapLD.ToBinary()[opcode] == '1')
            {
                return typeof(InstructionLD);
            }
            return null;
        }

    }
}
