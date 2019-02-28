using GBEmu.Emulation.Processing;

namespace GBEmu.Emulation
{
    public class MemoryController
    {
        public Memory Memory { get; set; }
        public Processor Processor { get; internal set; }
        public GraphicsProcessor GraphicsProcessor { get; internal set; }
    }
}