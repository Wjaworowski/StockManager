namespace StockManager.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Practices.Unity;

    using StockManager.DAL;
    using StockManager.DAL.Repositories;
    using StockManager.Installers;
    using Xunit;

    /// <summary>
    /// Bootstrapper tests.
    /// </summary>
    public class BootstrapperTests
    {
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
            Assert.Equal(dbContext.GetType(), typeof(DatabaseContext));
        }

        /// <summary>
        /// Tests if the container can resolve IStockRepository.
        /// </summary>
        [StaFact]
        public void ContainerCanCreateStockRepository()
        {
            var stockRepository = this.bootstrapper.Container.Resolve<IStockRepository>();
            Assert.Equal(stockRepository.GetType(), typeof(StockRepository));
        }
    }
}
