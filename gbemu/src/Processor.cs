using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace gbemu
{
    /// <summary>
    /// This is the main processing unit for the gb emulator. 
    /// Responsible for fetching, decoding, and executing instructions.
    /// </summary>
    public class Processor
    {
        public MemoryController MemoryController { get; set; }

        // Flags
        internal bool ZeroFlag,       // Z
                      AddSubFlag,     // N
                      HalfCarryFlag,  // H
                      CarryFlag;      // C

        // Registers
        internal int A, B, C, D, E, F, H, L, SP, PC;

        internal int AF
        {
            get
            {
                string hexRep = A.ToString() + F.ToString();
                return int.Parse(hexRep, System.Globalization.NumberStyles.HexNumber);
            }
        }

        internal int BC
        {
            get
            {
                string hexRep = B.ToString() + C.ToString();
                return int.Parse(hexRep, System.Globalization.NumberStyles.HexNumber);
            }
        }

        internal int DE
        {
            get
            {
                string hexRep = D.ToString() + E.ToString();
                return int.Parse(hexRep, System.Globalization.NumberStyles.HexNumber);
            }
        }

        internal int HL
        {
            get
            {
                string hexRep = H.ToString() + L.ToString();
                return int.Parse(hexRep, System.Globalization.NumberStyles.HexNumber);
            }
        }

        public Processor()
        {
            PC = 0;
        }

        internal void UpdateFlags(int value)
        {
            ZeroFlag = (value == 0);

            // TODO: AddSubFlag

            // TODO: HalfCarryFlag

            // TODO: CarryFlag
        }

        #region Opcode Table

        internal void ExecuteInstruction(int opcode)
        {
            //Debug.WriteLine("Opcode: " + Convert.ToString(opcode, 2));

            int temp = 0;
            int index = opcode / 4;
            int bitmask = opcode % 4;
            //Debug.WriteLine("Bitmask: " + Convert.ToString(bitmask, 2));
            int bitmaskRightShift = 1 << bitmask;

            //Debug.WriteLine("Bitmask Right Shift: " + Convert.ToString(bitmaskRightShift, 2));

            if ((DecodeHex("0080008000800080000570000000000000000000000000000000000000000000"[index]) & bitmaskRightShift) != 0)
            {
                temp = A;
            }
            if ((DecodeHex("0000000000000000000010000000000000000000000000000000000000000000"[index]) & bitmaskRightShift) != 0)
            {
                temp += B;
            }

        }

        private int DecodeHex(char v)
        {
            int value = int.Parse(v.ToString(), System.Globalization.NumberStyles.HexNumber);
            return value;
        }
        #endregion

        internal int ReadByte(int address)
        {
            var value = MemoryController.Memory.MemoryMap[address];
            return value;
        }

        internal void WriteByte(int address, int value)
        {
            MemoryController.Memory.MemoryMap[address] = value;
        }

        internal int FetchIns()
        {
            var value = ReadByte(PC);
            PC++;
            return value;
        }

        // LD nn,n  
        // Loads n into nn (8-bit immediate address)
        internal Dictionary<int, Action<Processor>> EightBitLoadsImmediate = new Dictionary<int, Action<Processor>>
        {
            [0x06] = (p) => { p.WriteByte(p.FetchIns(), p.B); },
            [0x0E] = (p) => { p.WriteByte(p.FetchIns(), p.C); },
            [0x16] = (p) => { p.WriteByte(p.FetchIns(), p.D); },
            [0x1E] = (p) => { p.WriteByte(p.FetchIns(), p.E); },
            [0x26] = (p) => { p.WriteByte(p.FetchIns(), p.H); },
            [0x2E] = (p) => { p.WriteByte(p.FetchIns(), p.L); },
        };

        // LD r1,r2
        // Loads r2 into r1
        internal Dictionary<int, Action<Processor>> EightBitLoadsRegisters = new Dictionary<int, Action<Processor>>
        {
            [0x41] = (p) => { p.B = p.C; },
            [0x42] = (p) => { p.B = p.D; },
            [0x43] = (p) => { p.B = p.E; },
            [0x44] = (p) => { p.B = p.H; },
            [0x45] = (p) => { p.B = p.L; },
            [0x46] = (p) => { p.B = p.ReadByte(p.H & p.L); },

            [0x48] = (p) => { p.C = p.B; },
            [0x4A] = (p) => { p.C = p.D; },
            [0x4B] = (p) => { p.C = p.E; },
            [0x4C] = (p) => { p.C = p.H; },
            [0x4D] = (p) => { p.C = p.L; },
            [0x4E] = (p) => { p.C = p.ReadByte(p.H & p.L); },

            [0x50] = (p) => { p.D = p.B; },
            [0x51] = (p) => { p.D = p.C; },
            [0x53] = (p) => { p.D = p.E; },
            [0x54] = (p) => { p.D = p.H; },
            [0x55] = (p) => { p.D = p.L; },
            [0x56] = (p) => { p.D = p.ReadByte(p.H & p.L); },

            [0x58] = (p) => { p.E = p.B; },
            [0x59] = (p) => { p.E = p.C; },
            [0x5A] = (p) => { p.E = p.D; },
            [0x5C] = (p) => { p.E = p.H; },
            [0x5D] = (p) => { p.E = p.L; },
            [0x5E] = (p) => { p.E = p.ReadByte(p.H & p.L); },

            [0x60] = (p) => { p.H = p.B; },
            [0x61] = (p) => { p.H = p.C; },
            [0x62] = (p) => { p.H = p.D; },
            [0x63] = (p) => { p.H = p.E; },
            [0x65] = (p) => { p.H = p.L; },
            [0x66] = (p) => { p.H = p.ReadByte(p.H & p.L); },

            [0x68] = (p) => { p.L = p.B; },
            [0x69] = (p) => { p.L = p.C; },
            [0x6A] = (p) => { p.L = p.D; },
            [0x6B] = (p) => { p.L = p.E; },
            [0x6C] = (p) => { p.L = p.H; },
            [0x6E] = (p) => { p.L = p.ReadByte(p.H & p.L); },

            [0x70] = (p) => { p.WriteByte(p.H & p.L, p.B); },
            [0x71] = (p) => { p.WriteByte(p.H & p.L, p.B); },
            [0x72] = (p) => { p.WriteByte(p.H & p.L, p.B); },
            [0x73] = (p) => { p.WriteByte(p.H & p.L, p.B); },
            [0x74] = (p) => { p.WriteByte(p.H & p.L, p.B); },
            [0x75] = (p) => { p.WriteByte(p.H & p.L, p.B); },
        };

        // LD A,n
        // Loads n into A
        internal Dictionary<int, Action<Processor>> EightBitLoadsToA = new Dictionary<int, Action<Processor>>
        {
            [0x78] = (p) => { p.A = p.B; },
            [0x79] = (p) => { p.A = p.C; },
            [0x7A] = (p) => { p.A = p.D; },
            [0x7B] = (p) => { p.A = p.E; },
            [0x7C] = (p) => { p.A = p.H; },
            [0x7D] = (p) => { p.A = p.L; },
            [0x0A] = (p) => { p.A = p.ReadByte(p.B & p.C); },
            [0x1A] = (p) => { p.A = p.ReadByte(p.D & p.E); },
            [0x7E] = (p) => { p.A = p.ReadByte(p.H & p.L); },
            [0xFA] = (p) => { p.A = p.ReadByte(p.ImmediateTwoByteLS()); },
            [0x3E] = (p) => { p.A = p.FetchIns(); },
        };

        // LD n,A
        // Loads A into n
        internal Dictionary<int, Action<Processor>> EightBitLoadsFromA = new Dictionary<int, Action<Processor>>
        {
            [0x78] = (p) => { p.B = p.A; },
            [0x79] = (p) => { p.C = p.A; },
            [0x7A] = (p) => { p.D = p.A; },
            [0x7B] = (p) => { p.E = p.A; },
            [0x7C] = (p) => { p.H = p.A; },
            [0x7D] = (p) => { p.L = p.A; },
            [0x0A] = (p) => { p.WriteByte(p.B & p.C, p.A); },
            [0x1A] = (p) => { p.WriteByte(p.D & p.E, p.A); },
            [0x7E] = (p) => { p.WriteByte(p.H & p.L, p.A); },
            [0xFA] = (p) => { p.WriteByte(p.B & p.C, p.A); },
            [0x3E] = (p) => { p.WriteByte(p.ImmediateTwoByteLS(), p.A); },
        };

        // LD Specials
        internal Dictionary<int, Action<Processor>> EightBitLoadsSpecial = new Dictionary<int, Action<Processor>>
        {
            [0xF2] = (p) => { p.A = p.ReadByte(0xFF00 & p.C); },
            [0xE2] = (p) => { p.WriteByte(0xFF00 & p.C, p.A); },
            [0x3A] = (p) => { p.A = p.ReadByte(p.H & p.L); p.DecHL(); }, // LDD A,(HL)
            [0x7B] = (p) => { p.E = p.A; },
            [0x7C] = (p) => { p.H = p.A; },
            [0x7D] = (p) => { p.L = p.A; },
            // Finish LD specials
        };

        private void DecHL()
        {
            string hexRep = H.ToString() + L.ToString();
            var intRep = int.Parse(hexRep, System.Globalization.NumberStyles.HexNumber) - 1;
            hexRep = intRep.ToString();
            string h = hexRep.Substring(0, 2);
            string l = hexRep.Substring(2, 2);
            H = int.Parse(h, System.Globalization.NumberStyles.HexNumber);
            L = int.Parse(l, System.Globalization.NumberStyles.HexNumber);
        }

        private int ImmediateTwoByteLS()
        {
            var a = FetchIns();
            var b = FetchIns();
            if (a < b)
            {
                return a & b;
            }
            return b & a;
        }

        internal Action<Processor> Decode(int b)
        {
            Action<Processor> action;

            if (EightBitLoadsImmediate.TryGetValue(b, out action))
            {
                return action;
            }

            if (EightBitLoadsRegisters.TryGetValue(b, out action))
            {
                return action;
            }

            if (EightBitLoadsToA.TryGetValue(b, out action))
            {
                return action;
            }

            if (EightBitLoadsFromA.TryGetValue(b, out action))
            {
                return action;
            }
            return null;
        }

        internal void Execute(Action<Processor> a)
        {
            if (a != null)
            {
                a.Invoke(this);
            }
        }
    }
}
