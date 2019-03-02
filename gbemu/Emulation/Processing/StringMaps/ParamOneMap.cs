using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing.Instructions;
using GBEmu.Emulation.Processing.Params;
using GBEmu.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.StringMaps
{
    /// <summary>
    /// Map for representing all possibilities of the first parameter given an opcode.
    /// Using a Hexadecimal representation of the 255 instruction set for the Gameboy CPU.
    /// Example: First four characters of A is 0020, opcode given is 11.
    ///     "0020" (hex string) = "0000000000100000" (binary string)
    /// Bit character at position 11 is 1. Use the A Register.
    /// </summary>
    public static class ParamOneMap
    {
        // TODO: Create maps for all registers given an opcode.

        #region Register Based Constants
        const string A =
            "002000200020002000000000000000FFFFFFFFFFFFFFFFFF0202020202029222";
        const string B =
            "0E00000000000000FF0000000000000000000000000000000000000000000000";
        const string C =
            "000E00000000000000FF00000000000000000000000000000000000000000000";
        const string D =
            "00000E00000000000000FF000000000000000000000000000000000000000000";
        const string E =
            "0000000E00000000000000FF0000000000000000000000000000000000000000";
        const string H =
            "000000000E00000000000000FF00000000000000000000000000000000000000";
        const string L =
            "00000000000E00000000000000FF000000000000000000000000000000000000";
        const string BC =
            "5010000000000000000000000000000000000000000000004410000000000000";
        const string DE =
            "0000501000000000000000000000000000000000000000000000441000000000";
        const string HL =
            "0000000050100000000000000000000000000000000000000000000044000080";
        const string AF =
            "0000000000000000000000000000000000000000000000000000000000004400";
        const string SP =
            "0000000000005010000000000000000000000000000000000000000000800040";
        #endregion

        #region Memory Based Constants
        const string AddressAtBC =
            "20002E00000000000000FF000000000000000000000000000000000000000000";
        const string AddressAtDE =
            "000020002E00000000000000FF00000000000000000000000000000000000000";
        const string AddressAtHL = 
            "0000000020002E00000000000000FF0000000000000000000000000000400000";
        const string AddressAtC =
            "0000000000000000000000000000000000000000000000000000000020000000";
        #endregion

        public static IInstructionParam GetParamOne(Processor processor, int opcode)
        {
            if (A.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.A);
            }
            if (B.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.B);
            }
            if (C.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.C);
            }
            if (D.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.D);
            }
            if (E.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.E);
            }
            if (H.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.H);
            }
            if (L.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.L);
            }
            if (BC.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.BC);
            }
            if (DE.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.DE);
            }
            if (HL.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.HL);
            }
            if (AF.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.AF);
            }
            if (SP.ContainsBitCharInMap(opcode))
            {
                return new RegisterParam(processor.Registers.SP);
            }
            if (AddressAtC.ContainsBitCharInMap(opcode))
            {
                return new MemoryParam(processor, processor.Registers.C);
            }
            if (AddressAtBC.ContainsBitCharInMap(opcode))
            {
                return new MemoryParam(processor, processor.Registers.BC);
            }
            if (AddressAtDE.ContainsBitCharInMap(opcode))
            {
                return new MemoryParam(processor, processor.Registers.DE);
            }
            if (AddressAtHL.ContainsBitCharInMap(opcode))
            {
                return new MemoryParam(processor, processor.Registers.HL);
            }
            // TODO: Create exception ParamNotFound
            // For now return null
            return null;
        }
    }
}
