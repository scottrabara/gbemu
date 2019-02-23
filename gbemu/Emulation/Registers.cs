using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation
{
    public class Registers
    {
        private readonly Dictionary<Register, int> _registers;

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
        public int H { get; set; }
        public int L { get; set; }
        public int HL
        {
            get
            {
                return (H << 4) | L;
            }
            set
            {
                var left = value.GetLeftNibble();
                var right = value.GetRightNibble();
                H = left;
                L = right;
            }
        }
        public int BC { get; set; }
        public int DE { get; set; }
        public int AF { get; set; }

        public Registers()
        {
            _registers =
                new Dictionary<Register, int>
                {
                    [Register.A] = A,
                    [Register.B] = B,
                    [Register.C] = C,
                    [Register.D] = D,
                    [Register.E] = E,
                    [Register.H] = H,
                    [Register.L] = L,
                    [Register.HL] = HL
                };
        }

        public int this[Register r]
        {
            get { return _registers[r]; }
            set { _registers[r] = value; }
        }
    }

    public enum Register
    {
        B,
        C,
        D,
        E,
        H,
        L,
        HL,
        A
    }
}
