using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace gbemu
{
    public class Memory
    {
        public MemoryController MemoryController { get; internal set; }
        public GraphicsProcessor GraphicsProcessor { get; internal set; }

        public string GameTitle { get; set; }

        // Represents the entire memory map of the gameboy system
        // Not sure if we want this to be explicitly created or as a function
        // returning all the memory components below as a new array
        internal int[] MemoryMap { get; set; } = new int[65535];

        internal int[] RestartInterruptVectors { get; set; } = new int[256];
        internal int[] CartridgeHeader { get; set; } = new int[80];
        internal int[] CartridgeRomBank_0 { get; set; } = new int[16048];
        internal int[] CartridgeRomBank_n { get; set; } = new int[16384];
        internal int[] CharacterRam { get; set; } = new int[6144];
        internal int[] BgMapData_1 { get; set; } = new int[1024];
        internal int[] BgMapData_2 { get; set; } = new int[256];
        internal int[] CartridgeRam { get; set; } = new int[256];
        internal int[] CpuRam { get; set; } = new int[256];
        internal int[] ReservedArea { get; set; } = new int[256];
        internal int[] Sprites { get; set; } = new int[256];
        internal int[] HighRam { get; set; } = new int[256];

        internal void LoadRom(byte[] rom)
        {
            int romPos = 0;

            // Read the Restart and Interrupt Vector Table of ROM
            Array.Copy(rom, romPos, RestartInterruptVectors, 0, RestartInterruptVectors.Length);
            romPos += RestartInterruptVectors.Length;

            // Read the header of the Rom
            Array.Copy(rom, romPos, CartridgeHeader, 0, CartridgeHeader.Length);
            romPos += CartridgeHeader.Length;

            // Read the remaining 16KB of data. This is a fixed bank.
            Array.Copy(rom, romPos, CartridgeRomBank_0, 0, CartridgeRomBank_0.Length);
            romPos += CartridgeRomBank_0.Length;

            // Read the next 16KB of data. This is a switchable bank.
            Array.Copy(rom, romPos, CartridgeRomBank_n, 0, CartridgeRomBank_n.Length);
            romPos += CartridgeRomBank_n.Length;

            SetMemoryMap(rom);

            SetTitle();
        }

        private void SetMemoryMap(byte[] rom)
        {
            rom.CopyTo(MemoryMap, 0);
        }

        private void SetTitle()
        {
            StringBuilder sbTitle = new StringBuilder();

            for (int i = 0x0034; i < 0x003F; i++)
            {
                if (CartridgeHeader[i] == 0)
                {
                    break;
                }
                sbTitle.Append((char)CartridgeHeader[i]);
            }

            GameTitle = sbTitle.ToString();
        }
    }
}
