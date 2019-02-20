using Autofac;
using gbemu;
using System;
using System.IO;

namespace gb
{
    class Program
    {
        static void Main(string[] args)
        {

            var gameBoy = new Gameboy();

            using (var fileStream = File.Open(@"C:\Users\scott\source\repos\gbemu\assets\ld.gb", FileMode.Open))
            {
                byte[] rom = FileUtils.ReadFully(fileStream, 0);
                gameBoy.LoadRom(rom);
            }

            Console.Out.WriteLine($"Rom loaded. Game title: {gameBoy.GameLoaded}");
            Console.ReadKey();

            gameBoy.Start();
        }
    }
}
