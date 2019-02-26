using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions
{
    internal class RegisterParam : IInstructionParam
    {
        public Register Register { get; set; }

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
            return $"{Register.Name.ToString()} ({Value.ToString("X2")})";
        }
    }
}
