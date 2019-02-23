using GBEmu.Emulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Utils
{
    public class Disassembler
    {
        public void Disassemble(Memory memory)
        {
            foreach (int i in memory.CartridgeRomBank_0)
            {
                var left = i << 4;
                var right = i >> 4;
            }
        }
    }
}
