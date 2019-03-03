using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Params
{
    /// <summary>
    /// Param representing a value in memory.
    /// </summary>
    internal class MemoryParam : IInstructionParam
    {
        private readonly Processor _processor;
        public int Address { get; set; }
        /// <summary>
        /// Size in bits
        /// </summary>
        public int Size { get; set; }
        public RegisterEnum Register { get; set; }

        internal MemoryParam(Processor p, int address, int size)
        {
            _processor = p;
            Address = address;
            Size = size;
        }

        internal MemoryParam(Processor p, RegisterEnum r)
        {
            _processor = p;
            Register = r;
            Address = _processor.Registers[Register].Value;
        }
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
            if (Register > 0)
            {
                return $"0x{Address.ToString("X4")} [({_processor.Registers[Register].Name.ToString()})]";
            }

            return $"0x{Address.ToString("X4")} [d{Size}]";
        }
    }
}
