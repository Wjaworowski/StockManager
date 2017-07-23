namespace StockManager.Installers
{
    using AutoMapper;

    using Microsoft.Practices.Unity;

    using StockManager.Automapper;

    /// <summary>
    /// Installer for Automapper.
    /// </summary>
    public static class AutomapperInstaller
    {
        /// <summary>
        /// Sets the config for automapper and registers automapper.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Install(IUnityContainer container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            container.RegisterInstance(config.CreateMapper(), new ContainerControlledLifetimeManager());
        }
    }
}
