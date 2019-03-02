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
        public Register Register { get; set; }
        public bool IsPair => Register.IsPair;
        public int Size => GetBytes();

        private int GetBytes()
        {
            if (IsPair)
            {
                return 2;
            }
            return 1;
        }

        public RegisterParam(Register r)
        {
            Register = r;
        }

        public int Value
        {
            get
            {
                return Register.Value;
            }
            set
            {
                Register.Value = value;
            }
        }

        public override string ToString()
        {
            return $"0x{Value.ToString("X2")} [{Register.Name.ToString()}]";
        }
    }
}
