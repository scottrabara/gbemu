using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace GBEmu.Emulation
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

        // int based registers
        internal int SP, PC;

        // Registers
        internal Registers Registers { get; set; }

        public Processor()
        {
            PC = 0;
            Registers = new Registers();
        }

        internal void UpdateFlags(int value)
        {
            ZeroFlag = (value == 0);

            // TODO: AddSubFlag

            // TODO: HalfCarryFlag

            // TODO: CarryFlag
        }

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

        internal int Immediate16Bits()
        {
            var left = FetchIns();
            var right = FetchIns();
            var result = (left << 8) | right;
            return result;
        }

        internal int Immediate8Bits()
        {
            return FetchIns();
        }

        // LD r1,r2
        // Loads r2 into r1
        internal Dictionary<int, Action<Processor, int>> Instructions = new Dictionary<int, Action<Processor, int>>
        {
            [0x0] = (p, o) => 
            {
                Register r1 = 0;
                var right = o.GetRightNibble();
                switch (right)
                {
                    case 1:
                    case 2:
                    case 3:
                        {
                            r1 = Register.BC;
                            break;
                        }
                    case 4:
                    case 5:
                    case 6:
                        {
                            r1 = Register.B;
                            break;
                        }
                    case 7:
                    case 8:
                        {
                            r1 = Register.SP;
                            break;
                        }
                    case 9:
                    case 10:
                    case 11:
                        {
                            r1 = Register.BC;
                            break;
                        }
                    case 12:
                    case 13:
                    case 14:
                        {
                            r1 = Register.C;
                            break;
                        }
                    case 15:
                    default:
                        break;
                }
                p.LD_LD_INC_DEC_LD(o, r1);
            },
            [0x1] = (p, o) => { },
            [0x2] = (p, o) => { },
            [0x3] = (p, o) => { },

            // 0x4X
            // LD B, n
            // LD C, n
            [0x4] = (p, o) => 
            {
                p.LD_UpdateRegister(o, Register.B);
            },

            // 0x5X
            // LD D, n
            // LD E, n
            [0x5] = (p, o) =>
            {
                p.LD_UpdateRegister(o, Register.D);
            },

            // 0x6X
            // LD H, n
            // LD L, n
            [0x6] = (p, o) =>
            {
                p.LD_UpdateRegister(o, Register.H);
            },

            // 0x7X
            // LD (HL), n
            // LD A, n
            [0x7] = (p, o) =>
            {
                p.LD_UpdateMemoryFromRegisterPair(o, Register.HL);
            },
            [0x8] = (p, o) => { },
            [0x9] = (p, o) => { },
            [0xA] = (p, o) => { },
            [0xB] = (p, o) => { },
            [0xC] = (p, o) => { },
            [0xD] = (p, o) => { },
            [0xE] = (p, o) => { },
            [0xF] = (p, o) => { }
        };

        internal Action<Processor, int> Decode(int b)
        {
            Action<Processor, int> action;
            int left = b.GetLeftNibble();
            if (Instructions.TryGetValue(left, out action))
            {
                return action;
            }
            return null;
        }

        internal void Execute(Action<Processor, int> a, int param)
        {
            if (a != null)
            {
                a.Invoke(this, param);
            }
        }

        internal void LD_UpdateRegister(int value, Register r1)
        {
            var right = value.GetRightNibble();
            Register operandOne = r1;

            if (right > 7)
            {
                right = right - 8;
                operandOne++;
            }

            Register operandTwo = (Register) right;
            if (operandTwo == Register.HL)
            {
                var memLocation = Registers.HL;
                Registers[operandOne] = ReadByte(memLocation);
            }
            else
            {
                Registers[operandOne] = Registers[operandTwo];
            }
        }

        internal void LD_UpdateMemoryFromRegisterPair(int value, Register r1)
        {
            var right = value.GetRightNibble();

            if (right > 7)
            {
                // 0x78 and above, update register A
                LD_UpdateRegister(value, r1);
                return;
            }

            Register operandTwo = (Register)right;

            if (operandTwo == Register.HL && operandTwo == r1)
            {
                return;
            }

            var memLocation = Registers[r1];
            WriteByte(memLocation, Registers[operandTwo]);
        }

        // Instruction sets from 0x-3x
        internal void LD_LD_INC_DEC_LD(int value, Register r1)
        {
            var right = value.GetRightNibble();
            switch (right)
            {
                // LD rr, d16
                case 1:
                    {
                        Registers[r1] = Immediate16Bits();
                        break;
                    }
                // LD (rr), A
                case 2:
                    {
                        Registers[r1] = Registers.A;
                        break;
                    }
                // INC rr
                case 3:
                    {
                        Registers[r1]++;
                        break;
                    }
                // INC r
                case 4:
                    {
                        Registers[r1]++;
                        break;
                    }
                // DEC r
                case 5:
                    {
                        Registers[r1]--;
                        break;
                    }
                // LD r, d8
                case 6:
                    {
                        Registers[r1] = Immediate8Bits();
                        break;
                    }
                // RLCA
                case 7:
                    {
                        break;
                    }
                // LD (a16), SP
                case 8:
                    {
                        Registers[r1]--;
                        break;
                    }
                // ADD HL, rr
                case 9:
                    {
                        Registers[r1]--;
                        break;
                    }
                // LD A, (rr)
                case 10:
                    {
                        Registers[Register.A] = ReadByte(Registers[r1]);
                        break;
                    }
                // DEC rr
                case 11:
                    {
                        Registers[r1]--;
                        break;
                    }
                // INC r
                case 12:
                    {
                        Registers[r1]++;
                        break;
                    }
                // DEC r
                case 13:
                    {
                        Registers[r1]--;
                        break;
                    }
                // LD r, d8
                case 14:
                    {
                        Registers[r1] = Immediate8Bits();
                        break;
                    }
                // DEC r
                case 15:
                    {
                        Registers[r1]--;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
