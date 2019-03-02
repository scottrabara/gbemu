using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions

/// <summary>
/// Compare N with register A
/// set flags and throw away results
/// </summary>
{
    class InstructionCP : IInstruction
    {
        public string BaseInstruction { get; set; } = "Compare {0}, {1}";
        public IInstructionParam[] Params { get; set; }
        public IInstructionParam ParamOne => Params[0];
        public IInstructionParam ParamTwo => Params[1];
        public string ParsedInstruction => GetParsedInstruction();
        public int Ticks { get; set; }
        public int Opcode { get; set; }

        public Action Action => GetAction();

        private string GetParsedInstruction()
        {
            return string.Format(
                BaseInstruction,
                ParamOne == null ? "null" : ParamOne.ToString(),
                ParamTwo == null ? "null" : ParamTwo.ToString());
        }

        private Action GetAction()
        {
            return () =>
            {
                if (ParamOne != null && ParamTwo != null)
                {
                    // Set N flag
                    if (ParamOne.Value == ParamTwo.Value)
                    {
                        //set Z flag
                    }
                    else if (ParamOne.Value < ParamTwo.Value) // should be A < N
                    {
                        //set C flag
                    }
                    else {
                        //set H flag (need to confirm because specifically set if borrow from bit 4 so need to double check if this means A > N)
                    }

                }
            };
        }
    }
}