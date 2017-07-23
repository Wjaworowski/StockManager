namespace StockManager.Installers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Practices.Unity;

    using StockManager.DAL;
    using StockManager.DAL.Repositories;

    /// <summary>
    /// Installer for DAL layer.
    /// </summary>
    public static class DalInstaller
    {
        /// <summary>
        /// Installers for DAL.
        /// </summary>
        /// <param name="container">The IoC container.</param>
        public static void Install(IUnityContainer container)
        {
            container.RegisterType<DbContext, DatabaseContext>(new ContainerControlledLifetimeManager(), new InjectionConstructor());
            container.RegisterType<IStockRepository, StockRepository>();
        }
    }
}
