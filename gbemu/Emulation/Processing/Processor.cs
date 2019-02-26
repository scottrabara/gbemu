using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Emulation.Processing.StringMaps;
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace GBEmu.Emulation.Processing
{
    /// <summary>
    /// This is the main processing unit for the gb emulator. 
    /// Responsible for fetching, decoding, and executing instructions.
    /// </summary>
    public class Processor
    {
        public MemoryController MemoryController { get; set; }

        // int based registers
        // TODO: Should these live in Registers as well?
        internal int PC;

        // Registers
        internal Registers Registers { get; set; }

        public Processor()
        {
            PC = 0;
            Registers = new Registers();
        }

        internal void UpdateFlags(int value)
        {
            // TODO: This needs to live in the Registers class and manipulate the F register
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

        #region New Instructions Method
        internal Action Instruction(int opcode)
        {
            // Get instruction with params (LD n, n)
            Type type = InstructionMap.GetInstruction(opcode);

            if (type != null)
            {
                var instruction = Activator.CreateInstance(type) as IInstruction;
                var instructionParams = ParamMap.GetParams(this, opcode);
                instruction.Params = instructionParams;

                return instruction.Action;
            }
            // else return instruction not implemented
            return null;
        }
        #endregion

        internal Action Decode(int b)
        {
            Action action = Instruction(b);
            return action;
        }
        
        internal void Execute(Action a)
        {
            if (a != null)
            {
                a.Invoke();
            }
        }
    }
}
