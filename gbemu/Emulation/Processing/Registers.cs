
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing
{
    /// <summary>
    /// Registers object for the Gameboy CPU. Represents the entire collection of Registers.
    /// </summary>
    internal class Registers
    {
        internal Register A { get; set; }
        internal Register B { get; set; }
        internal Register C { get; set; }
        internal Register D { get; set; }
        internal Register E { get; set; }
        internal Register F { get; set; }
        internal Register H { get; set; }
        internal Register L { get; set; }
        internal Register HL { get; set; }
        internal Register BC { get; set; }
        internal Register DE { get; set; }
        internal Register AF { get; set; }

        internal Register SP;
        internal Register PC;

        internal Registers()
        {
            A = new Register(RegisterEnum.A);
            B = new Register(RegisterEnum.B);
            C = new Register(RegisterEnum.C);
            D = new Register(RegisterEnum.D);
            E = new Register(RegisterEnum.E);
            F = new Register(RegisterEnum.F);
            H = new Register(RegisterEnum.H);
            L = new Register(RegisterEnum.L);
            HL = new Register(RegisterEnum.HL);
            BC = new Register(RegisterEnum.BC);
            DE = new Register(RegisterEnum.DE);
            AF = new Register(RegisterEnum.AF);
        }

        private int GetPair(Register r1, Register r2)
        {
            return (r1.Value << 8) | r2.Value;
        }

        private void SetPair(int value, Register r1, Register r2)
        {
            var left = value.GetLeftByte();
            var right = value.GetRightByte();
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
