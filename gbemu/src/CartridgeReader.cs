using System;

namespace gbemu
{
    internal class CartridgeReader
    {
        /// <summary>
        /// Reference to the Memory map of the emulator.
        /// </summary>
        public Memory Memory { get; internal set; }

        /// <summary>
        /// Loads a ROM onto the Memory map.
        /// </summary>
        /// <param name="buffer"></param>
        internal void LoadRom(byte[] buffer)
        {
            Memory.LoadRom(buffer);
        }
    }
}