using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation
{
    internal class Registers
    {
        private readonly Dictionary<Register, int> _registers;

        internal int A => _registers[Register.A];
        internal int B => _registers[Register.B];
        internal int C => _registers[Register.C];
        internal int D => _registers[Register.D];
        internal int E => _registers[Register.E];
        internal int F => _registers[Register.F];
        internal int H => _registers[Register.H];
        internal int L => _registers[Register.L];

        internal int HL => _registers[Register.HL];
        internal int BC => _registers[Register.BC];
        internal int DE => _registers[Register.DE];
        internal int AF => _registers[Register.AF];

        internal int SP => _registers[Register.SP];
        internal int PC => _registers[Register.PC];

        internal Registers()
        {
            _registers =
                new Dictionary<Register, int>
                {
                    [Register.A] = 0,
                    [Register.B] = 0,
                    [Register.C] = 0,
                    [Register.D] = 0,
                    [Register.E] = 0,
                    [Register.F] = 0,
                    [Register.H] = 0,
                    [Register.L] = 0,
                    [Register.HL] = 0,
                    [Register.BC] = 0,
                    [Register.DE] = 0,
                    [Register.AF] = 0,
                    [Register.SP] = 0,
                    [Register.PC] = 0
                };
        }

        internal int this[Register r]
        {
            get
            {
                switch (r)
                {
                    case Register.HL:
                        return GetPair(_registers[Register.H], _registers[Register.L]);
                    case Register.BC:
                        return GetPair(_registers[Register.B], _registers[Register.C]);
                    case Register.DE:
                        return GetPair(_registers[Register.D], _registers[Register.E]);
                    case Register.AF:
                        return GetPair(_registers[Register.A], _registers[Register.F]);
                }
                return _registers[r];
            }
            set
            {
                switch (r)
                {
                    case Register.HL:
                        SetPair(value, Register.H, Register.L);
                        break;
                    case Register.BC:
                        SetPair(value, Register.B, Register.C);
                        break;
                    case Register.DE:
                        SetPair(value, Register.D, Register.E);
                        break;
                    case Register.AF:
                        SetPair(value, Register.A, Register.F);
                        break;
                }
                _registers[r] = value;
            }
        }

        private int GetPair(int r1, int r2)
        {
            return (r1 << 8) | r2;
        }

        private void SetPair(int value, Register r1, Register r2)
        {
            var left = value.GetLeftByte();
            var right = value.GetRightByte();
            _registers[r1] = left;
            _registers[r2] = right;
        }
    }

    internal enum Register
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
