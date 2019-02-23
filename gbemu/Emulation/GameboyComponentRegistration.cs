﻿using Autofac;
using System;

namespace GBEmu.Emulation
{
    public static class GameboyComponentRegistration
    {
        public static void Register(Gameboy gameboy)
        {
            var builder = new ContainerBuilder();

            // Register the passed instance of gameboy
            builder.RegisterInstance(gameboy)
                .OnActivated(e =>
                {
                    e.Instance.CartridgeReader = e.Context.Resolve<CartridgeReader>();
                    e.Instance.MemoryController = e.Context.Resolve<MemoryController>();
                    e.Instance.Processor = e.Context.Resolve<Processor>();
                });

            builder.RegisterType<CartridgeReader>()
                .InstancePerLifetimeScope()
                .OnActivated(e => e.Instance.Memory = e.Context.Resolve<Memory>());

            builder.RegisterType<MemoryController>()
                .InstancePerLifetimeScope()
                .OnActivated(e => 
                {
                    e.Instance.Memory = e.Context.Resolve<Memory>();
                    e.Instance.GraphicsProcessor = e.Context.Resolve<GraphicsProcessor>();
                    e.Instance.Processor = e.Context.Resolve<Processor>();
                });

            builder.RegisterType<Processor>()
                .InstancePerLifetimeScope()
                .OnActivated(e => e.Instance.MemoryController = e.Context.Resolve<MemoryController>());

            builder.RegisterType<Memory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GraphicsProcessor>()
                .InstancePerLifetimeScope();

            var container = builder.Build();
           
            var gboy = container.Resolve<Gameboy>();
        }
    }
}