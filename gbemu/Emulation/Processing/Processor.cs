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

        // Registers
        internal Registers Registers { get; set; }

        public Processor()
        {
            // TODO: This can get added to DI call in GameboyComponentRegistration
            Registers = new Registers();
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

        internal int FetchOpcode()
        {
            var value = ReadByte(Registers.PC.Value);
            Registers.PC.Value++;
            return value;
        }

        internal int Immediate16Bits()
        {
            var left = FetchOpcode();
            var right = FetchOpcode();
            var result = (left << 8) | right;
            return result;
        }

        internal int Immediate8Bits()
        {
            return FetchOpcode();
        }

        #region Instructions Method
        internal IInstruction Instruction(int opcode)
        {
            // Get instruction with params via opcode (etc: LD n, n)
            // using maps in InstructionMap
            Type type = InstructionMap.GetInstruction(opcode);

            if (type != null)
            {
                // If instruction is found, create instruction instance as Instruction
                var instruction = Activator.CreateInstance(type) as IInstruction;

                // Fetch params using maps in ParamOneMap and ParamTwoMap
                var instructionParams = ParamMap.GetParams(this, opcode);
                instruction.Params = instructionParams;

                // Return Action from defined Instruction type
                // TODO: Return action, or invoke right away?
                return instruction;
            }
            // If no instruction is found, throw missing opcode exception
            // TODO: Create Missing Opcode Exception, for now return null
            return null;
        }
        #endregion

        internal IInstruction Decode(int opcode)
        {
            // Given an opcode, fetch action to execute
            IInstruction ins = Instruction(opcode);
            return ins;
        }
        
        internal void Execute(IInstruction ins)
        {
            if (ins != null)
            {
                ins.Action.Invoke();
            }
        }
    }
}
