
using GBEmu.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing
{
    /// <summary>
    /// Registers object for the Gameboy CPU. Represents the entire collection of Registers.
    /// </summary>
    internal class Registers
    {
        internal Register[] _registers =
            new Register[] 
            {
                new Register(RegisterEnum.B),
                new Register(RegisterEnum.C),
                new Register(RegisterEnum.D),
                new Register(RegisterEnum.E),
                new Register(RegisterEnum.H),
                new Register(RegisterEnum.L),
                new Register(RegisterEnum.HL),
                new Register(RegisterEnum.A),
                new Register(RegisterEnum.F),
                new Register(RegisterEnum.BC),
                new Register(RegisterEnum.DE),
                new Register(RegisterEnum.AF),
                new Register(RegisterEnum.SP),
                new Register(RegisterEnum.PC)
            };

        internal Registers()
        {

        }

        internal Register this[RegisterEnum r]
        {
            get
            {
                var individuals = GetRegisterEnumFromPair(r);
                if (individuals != null)
                {
                    GetPair(
                        _registers[(int)individuals[0]], 
                        _registers[(int)individuals[1]]
                    );
                }
                return _registers[(int) r];
            }
            set
            {
                var individuals = GetRegisterEnumFromPair(r);
                if (individuals != null)
                {
                    SetPair(
                        value,
                        _registers[(int)individuals[0]],
                        _registers[(int)individuals[1]]
                    );
                }
                _registers[(int)r] = value;
            }
        }

        private RegisterEnum[] GetRegisterEnumFromPair(RegisterEnum r)
        {
            switch (r)
            {
                case RegisterEnum.HL:
                    return new [] { RegisterEnum.H, RegisterEnum.L };
                case RegisterEnum.BC:
                    return new [] { RegisterEnum.B, RegisterEnum.C };
                case RegisterEnum.DE:
                    return new [] { RegisterEnum.D, RegisterEnum.E };
                case RegisterEnum.AF:
                    return new [] { RegisterEnum.A, RegisterEnum.F };
            }
            return null;
        }

        private int GetPair(Register r1, Register r2)
        {
            return (r1.Value << 8) | r2.Value;
        }

        private void SetPair(Register origin, Register r1, Register r2)
        {
            var left = origin.Value.GetLeftByte();
            var right = origin.Value.GetRightByte();
            r1.Value = left;
            r2.Value = right;
        }
    }

    internal enum RegisterEnum
    {
        // 0 - 7
        B,
        C,
        D,
        E,
        H,
        L,
        HL,
        A,

        // 8 and above
        F,
        BC,
        DE,
        AF,

        SP,
        PC
    }
}
