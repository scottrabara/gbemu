
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
        private Register _hl, _bc, _de, _af;

        internal Register A { get; set; }
        internal Register B { get; set; }
        internal Register C { get; set; }
        internal Register D { get; set; }
        internal Register E { get; set; }
        internal Register F { get; set; }
        internal Register H { get; set; }
        internal Register L { get; set; }
        
        internal Register HL { get { _hl.Value = GetPair(H, L); return _hl; } set { SetPair(HL, H, L); } }
        internal Register BC { get { _bc.Value = GetPair(B, C); return _bc; } set { SetPair(BC, B, C); } }
        internal Register DE { get { _de.Value = GetPair(D, E); return _de; } set { SetPair(DE, D, E); } }
        internal Register AF { get { _af.Value = GetPair(A, F); return _af; } set { SetPair(AF, A, F); } }

        internal Register SP { get; set; }
        internal Register PC { get; set; }

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
            _hl = new Register(RegisterEnum.HL, true);
            _bc = new Register(RegisterEnum.BC, true);
            _de = new Register(RegisterEnum.DE, true);
            _af = new Register(RegisterEnum.AF, true);
            SP = new Register(RegisterEnum.SP, true);
            PC = new Register(RegisterEnum.PC, true);
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
