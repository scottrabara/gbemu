﻿using GBEmu.Utils;
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

        // LD r1,r2
        // Loads r2 into r1
        internal Dictionary<int, Action<Processor, int>> Instructions = new Dictionary<int, Action<Processor, int>>
        {
            [0x0] = (p, o) => { },
            [0x1] = (p, o) => { },
            [0x2] = (p, o) => { },
            [0x3] = (p, o) => { },

            // 0x4X
            // LD B, n
            // LD C, n
            [0x4] = (p, o) => 
            {
                var right = o.GetRightNibble();
                Register operandOne = Register.B;

                if (right > 7)
                {
                    right = right - 8;
                    operandOne = Register.C;
                }

                Register operandTwo = (Register) right;
                p.Registers[operandOne] = p.Registers[operandTwo];
            },

            // 0x5X
            // LD D, n
            // LD E, n
            [0x5] = (p, o) =>
            {
                var right = o.GetRightNibble();
                Register operandOne = Register.D;

                if (right > 7)
                {
                    right = right - 8;
                    operandOne = Register.E;
                }

                Register operandTwo = (Register)right;
                p.Registers[operandOne] = p.Registers[operandTwo];
            },

            // 0x6X
            // LD H, n
            // LD L, n
            [0x6] = (p, o) =>
            {
                var right = o.GetRightNibble();
                Register operandOne = Register.H;

                if (right > 7)
                {
                    right = right - 8;
                    operandOne = Register.L;
                }

                Register operandTwo = (Register)right;
                p.Registers[operandOne] = p.Registers[operandTwo];
            },

            // 0x7X
            // LD HL, n
            // LD A, n
            [0x7] = (p, o) =>
            {
                var right = o.GetRightNibble();
                Register operandOne = Register.HL;

                if (right > 7)
                {
                    right = right - 8;
                    operandOne = Register.A;
                }

                if (operandOne == (Register)right)
                {
                    return;
                }

                Register operandTwo = (Register)right;

                if (operandOne == Register.HL)
                {
                    var memLocation = p.Registers[Register.HL];
                    p.WriteByte(memLocation, p.Registers[operandTwo]);
                }
                else
                {
                    p.Registers[operandOne] = p.Registers[operandTwo];
                }
            },
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
    }
}
