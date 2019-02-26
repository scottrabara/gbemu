using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions
{
    internal class MemoryParam : IInstructionParam
    {
        private readonly Processor _processor;

        internal MemoryParam(Processor p)
        {
            _processor = p;
        }

        internal MemoryParam(Processor p, int address)
        {
            _processor = p;
            Address = address;
        }

        public int Address { get; set; }
        public int Value
        {
            get
            {
                return _processor.ReadByte(Address);
            }
            set
            {
                _processor.WriteByte(Address, value);
            }

        }

        public override string ToString()
        {
            return Value.ToString("X4");
        }
    }
}
