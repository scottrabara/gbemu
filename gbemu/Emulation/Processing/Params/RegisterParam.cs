using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Params
{
    /// <summary>
    /// Param representing a Register from the Gameboy CPU.
    /// </summary>
    internal class RegisterParam : IInstructionParam
    {
        public Processor Processor { get; set; }
        public RegisterEnum Register { get; set; }

        public RegisterParam(Processor p, RegisterEnum rEnum)
        {
            Processor = p;
            Register = rEnum;
        }

        public int Value
        {
            get
            {
                return Processor.Registers[Register].Value;
            }
            set
            {
                var temp = Processor.Registers[Register];
                temp.Value = value;
                Processor.Registers[Register] = temp;
            }
        }

        public override string ToString()
        {
            return $"0x{Value.ToString("X2")} [{Processor.Registers[Register].Name.ToString()}]";
        }
    }
}
