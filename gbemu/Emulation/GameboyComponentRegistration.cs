using Autofac;
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
                .OnActivated(e => e.Instance.CartridgeReader = e.Context.Resolve<CartridgeReader>());

            builder.RegisterType<CartridgeReader>()
                .InstancePerLifetimeScope()
                .OnActivated(e => e.Instance.Memory = e.Context.Resolve<Memory>());

            builder.RegisterType<Memory>()
                .InstancePerLifetimeScope();

            // TODO: Register rest of types

            var container = builder.Build();
           
            var gboy = container.Resolve<Gameboy>();
        }
    }
}