using System;
using System.Collections.Generic;
using System.Text;

namespace gbemu
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
        public string GameLoaded => Memory.GameTitle;

        /// <summary>
        /// 
        /// </summary>
        internal Processor Processor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal MemoryController MemoryController { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal Memory Memory { get; set; }

        /// <summary>
        /// Responsible for reading a ROM.
        /// </summary>
        internal CartridgeReader CartridgeReader { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal EmulatedInput Input { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal GraphicsProcessor GraphicsProcessor { get; set; }

        public Gameboy()
        {
            // Initialize internal components
            Processor = new Processor();
            MemoryController = new MemoryController();
            Memory = new Memory();
            CartridgeReader = new CartridgeReader();
            Input = new EmulatedInput();
            GraphicsProcessor = new GraphicsProcessor();

            // Wire up dependencies
            // Dependency Injection may be good here
            MemoryController.Memory = Memory;
            MemoryController.Processor = Processor;
            MemoryController.GraphicsProcessor = GraphicsProcessor;

            Processor.MemoryController = MemoryController;

            // Stack pointer initialized to this position
            Processor.SP = Memory.MemoryMap[0xEFFF];

            Memory.MemoryController = MemoryController;
            Memory.GraphicsProcessor = GraphicsProcessor;

            Input.MemoryController = MemoryController;

            CartridgeReader.Memory = Memory;
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
            while (Processor.PC != -1)
            {
                int ins = Processor.FetchIns();
                Action<Processor> a = Processor.Decode(ins);
                Processor.Execute(a);
            }
        }
    }
}
