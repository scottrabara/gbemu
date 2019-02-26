using Autofac;
using GBEmu.Emulation.Processing;
using System;
using System.Collections.Generic;
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
            while (Processor.PC < 65535)
            {
                int ins = Processor.FetchIns();
                if (ins != -1)
                {
                    Action a = Processor.Decode(ins);
                    Processor.Execute(a);
                }
            }
        }
    }
}
