using GBEmu.Emulation.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Emulation.Processing.Instructions
{
    public class InstructionLD : IInstruction
    {
        public string BaseInstruction { get; set; } = "LD {0}, {1}";
        public IInstructionParam[] Params { get; set; }
        public IInstructionParam ParamOne => Params[0];
        public IInstructionParam ParamTwo => Params[1];
        public string ParsedInstruction => GetParsedInstruction();

        public Action Action => GetAction();

        private string GetParsedInstruction()
        {
            return string.Format(
                BaseInstruction, 
                ParamOne.ToString(), 
                ParamTwo.ToString());
        }

        private Action GetAction()
        {
            return () =>
            {
                if (ParamOne != null && ParamTwo != null)
                {
                    ParamOne.Value = ParamTwo.Value;
                }
            };
        }
    }
}
