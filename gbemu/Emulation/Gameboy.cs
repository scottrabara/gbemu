using Autofac;
using GBEmu.Emulation.Abstractions;
using GBEmu.Emulation.Processing;
using GBEmu.Emulation.Processing.StringMaps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GBEmu.Emulation
{
    // Core emulation of the gameboy. 
    // This contains references to all major components. This also handles creation and "wiring" up of the components

    // TODO: Processor
    // TODO: MemoryController
    // TODO: GraphicsProcessor
    // TODO: Input
    // TODO: Interrupts

    public class Gameboy
    {
        /// <summary>
        /// Returns the currently loaded ROM's title.
        /// </summary>
        public string GameLoaded => MemoryController.Memory.GameTitle;

        /// <summary>
        /// 
        /// </summary>
        internal Processor Processor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal MemoryController MemoryController { get; set; }

        /// <summary>
        /// Responsible for reading a ROM.
        /// </summary>
        public CartridgeReader CartridgeReader { get; set; }

        public Gameboy()
        {
            // Resolve module dependencies via Property Injection
            GameboyComponentRegistration.Register(this);
        }

        /// <summary>
        /// Loads a ROM onto the Memory map.
        /// </summary>
        /// <param name="buffer"></param>
        public void LoadRom(byte[] buffer)
        {
            CartridgeReader.LoadRom(buffer);
        }

        public void Start()
        {
            var sw = new Stopwatch();
            List<string> executedInstructions = new List<string>();
            try
            {
                while (Processor.Registers[RegisterEnum.PC].Value < 65535)
                {
                    sw.Start();
                    string startPC = Processor.Registers[RegisterEnum.PC].ToString();
                    int opcode = Processor.FetchOpcode();
                    if (opcode != -1)
                    {
                        IInstruction a = Processor.Decode(opcode);
                        if (a != null)
                        {
                            executedInstructions.Add($"[{startPC}] - {a.ParsedInstruction} - {sw.ElapsedMilliseconds}ms");
                            Processor.Execute(a);
                        }
                        else
                        {
                            var ins = Lookup.Ins[opcode];
                            if (ins != null)
                                executedInstructions.Add($"[{startPC}] - NOT IMPLEMENTED {ins.Name} - {sw.ElapsedMilliseconds}ms");
                        }
                    }
                    sw.Reset();
                }
                sw.Stop();
            }
            finally
            {
                using (TextWriter tw = new StreamWriter("ExecutedInstructions.txt"))
                {
                    tw.WriteLine($"Elapsed time {sw.ElapsedMilliseconds}ms");
                    foreach (string s in executedInstructions)
                        tw.WriteLine(s);

                    tw.Flush();
                }
            }
        }
    }
}
