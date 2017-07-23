namespace StockManager.Tests.UnitTests
{
    using AutoMapper;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Practices.Unity;

    using StockManager.Automapper;
    using StockManager.DAL;
    using StockManager.DAL.Repositories;
    using StockManager.Installers;
    using Xunit;

    /// <summary>
    /// Bootstrapper tests.
    /// </summary>
    public class BootstrapperTests
    {
        /// <summary>
        /// The bootstrapper.
        /// </summary>
        private readonly Bootstrapper bootstrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapperTests"/> class.
        /// </summary>
        public BootstrapperTests()
        {
            this.bootstrapper = new Bootstrapper();
            this.bootstrapper.Run();
        }

        /// <summary>
        /// Tests if the container is created.
        /// </summary>
        [StaFact]
        public void ContainerInitialization()
        {
            Assert.NotNull(this.bootstrapper.Container);
        }

        /// <summary>
        /// Tests if the container can resolve DbContext.
        /// </summary>
        [StaFact]
        public void ContainerCanCreateDbContext()
        {
            var dbContext = this.bootstrapper.Container.Resolve<DbContext>();
            Assert.IsType(typeof(DatabaseContext), dbContext);
        }

        /// <summary>
        /// Tests if the container can resolve IStockRepository.
        /// </summary>
        [StaFact]
        public void ContainerCanCreateStockRepository()
        {
            var stockRepository = this.bootstrapper.Container.Resolve<IStockRepository>();
            Assert.IsType(typeof(StockRepository), stockRepository);
        }

        /// <summary>
        /// Tests if the container can resolve IMapper and if there are maps definied.
        /// </summary>
        [StaFact]
        public void ContainerCanCreateAutomapperWithConfig()
        {
            var mapper = this.bootstrapper.Container.Resolve<IMapper>();
            Assert.IsType(typeof(Mapper), mapper);
            Assert.True(mapper.ConfigurationProvider.GetAllTypeMaps().Length > 0);
        }
    }
}
