# gbemu 

This is a Gameboy emulator written in C# and ASP.NET Core/Standard. If you are contributing to this, I highly recommend that you read through the Gameboy CPU Manual [here](http://marc.rawer.de/Gameboy/Docs/GBCPUman.pdf) as it is key to be intimately familiar with the Instruction Set of the Gameboy CPU.

### Current roadmap - 0.1.0
- Start Project!
  - Define Skeleton
  - Define methods of loading .gb files
  - Define modular components (Processor, GraphicsProcessor, Memory, etc)
- Create Processor Module
  - Fetch Opcodes from Memory
  - Decode Opcodes (technique on this is still in discussion; currently using Dictionary with opcode being the index, and returning an action to execute.
  - Implement all Flags and Register related functionality; i.e. Updating Flags and Registers, returning Paired Registers, etc
  - How do we test the Processor Module? [Here is a collection](https://github.com/retrio/gb-test-roms) of gb-test-roms that we may be able to leverage.
- Look into MemoryController and Memory management


All decisions are loosely made are open for discussion for improvement. Most decisions are based from the documentation of the Gameboy development cycle as well as the resources linked below.


### Some development resources

- [Awesome curated list of Emulator Development Resources](https://github.com/gbdev/awesome-gbdev#emulator-development)
