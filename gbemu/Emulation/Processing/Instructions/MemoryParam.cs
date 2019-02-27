using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions
{
    /// <summary>
    /// Param representing a value in memory.
    /// </summary>
    internal class MemoryParam : IInstructionParam
    {
        private readonly Processor _processor;

        internal MemoryParam(Processor p, int address, int size)
        {
            _processor = p;
            Address = address;
            Size = size;
        }

        internal MemoryParam(Processor p, Register r)
        {
            _processor = p;
            Register = r;
            Address = Register.Value;
        }

        public int Address { get; set; }

        /// <summary>
        /// Size in bits
        /// </summary>
        public int Size { get; set; }
        public Register Register { get; set; }
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
            if (Register != null)
            {
                return $"0x{Address.ToString("X4")} [({Register.Name.ToString()})]";
            }

            return $"0x{Address.ToString("X4")} [d{Size}]";
        }
    }
}
