using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation
{
    internal class Registers
    {
        private readonly Dictionary<Register, int> _registers;

        internal int A { get; set; }
        internal int B { get; set; }
        internal int C { get; set; }
        internal int D { get; set; }
        internal int E { get; set; }
        internal int F { get; set; }
        internal int H { get; set; }
        internal int L { get; set; }

        internal int HL
        {
            get { return GetPair(H, L); }
            set { SetPair(value, Register.H, Register.L); }
        }
        internal int BC
        {
            get { return GetPair(B, C); }
            set { SetPair(value, Register.B, Register.C); }
        }
        internal int DE
        {
            get { return GetPair(D, E); }
            set { SetPair(value, Register.D, Register.E); }
        }
        internal int AF
        {
            get { return GetPair(A, F); }
            set { SetPair(value, Register.A, Register.F); }
        }

        internal Registers()
        {
            _registers =
                new Dictionary<Register, int>
                {
                    [Register.A] = A,
                    [Register.B] = B,
                    [Register.C] = C,
                    [Register.D] = D,
                    [Register.E] = E,
                    [Register.F] = F,
                    [Register.H] = H,
                    [Register.L] = L,
                    [Register.HL] = HL,
                    [Register.BC] = BC,
                    [Register.DE] = DE,
                    [Register.AF] = AF
                };
        }

        internal int this[Register r]
        {
            get { return _registers[r]; }
            set { _registers[r] = value; }
        }

        internal int GetPair(int r1, int r2)
        {
            return (r1 << 4) | r2;
        }

        internal void SetPair(int value, Register r1, Register r2)
        {
            var left = value.GetLeftNibble();
            var right = value.GetRightNibble();
            this[r1] = left;
            this[r2] = right;
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
        AF
    }
}
