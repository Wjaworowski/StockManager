namespace StockManager.Tests.UnitTests
{
    using AutoMapper;

    using DeepEqual.Syntax;

    using StockManager.Automapper;
    using StockManager.Common.Enums;
    using StockManager.Common.Models;
    using StockManager.DAL.Entities;

    using Xunit;

    /// <summary>
    /// Automapper tests.
    /// </summary>
    public class AutomapperTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutomapperTests"/> class.
        /// </summary>
        public AutomapperTests()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        /// <summary>
        /// Tests the Mapping of stock entity to bond model.
        /// </summary>
        [Fact]
        public void MapStockEntityToBondModel()
        {
            var stockEntity = new Stock
                                  {
                                      CommisionPercent = 0.02,
                                      Price = new decimal(19.3),
                                      Quantity = 121,
                                      StockType = StockType.Bond,
                                      Id = 18
                                  };
            var bondModel = new BondModel() { Quantity = 121, Price = new decimal(19.3) };

            var mappedStock = Mapper.Map<BondModel>(stockEntity);

            Assert.True(mappedStock.IsDeepEqual(bondModel));
        }

        /// <summary>
        /// Tests the Mapping of stock entity to equity model.
        /// </summary>
        [Fact]
        public void MapStockEntityToEquityModel()
        {
            var stockEntity = new Stock
            {
                CommisionPercent = 0.005,
                Price = new decimal(92.13),
                Quantity = 11,
                StockType = StockType.Equity,
                Id = 2
            };
            var equityModel = new EquityModel() { Quantity = 11, Price = new decimal(92.13) };

            var mappedStock = Mapper.Map<EquityModel>(stockEntity);

            Assert.True(mappedStock.IsDeepEqual(equityModel));
        }

        /// <summary>
        /// Tests the Mapping of bond model to stock entity.
        /// </summary>
        [Fact]
        public void MapBondModelToStockEntity()
        {
            var bondModel = new BondModel() { Quantity = 3, Price = new decimal(1.82) };

            var stockEntity = new Stock
            {
                CommisionPercent = 0.02,
                Price = new decimal(1.82),
                Quantity = 3,
                StockType = StockType.Bond
            };

            var mappedBondModel = Mapper.Map<Stock>(bondModel);

            Assert.True(mappedBondModel.IsDeepEqual(stockEntity));
        }

        /// <summary>
        /// Tests the Mapping of equity model to stock entity.
        /// </summary>
        [Fact]
        public void MapEquityModelToStockEntity()
        {
            var equityModel = new EquityModel() { Quantity = 1, Price = new decimal(15) };

            var stockEntity = new Stock
            {
                CommisionPercent = 0.005,
                Price = new decimal(15),
                Quantity = 1,
                StockType = StockType.Equity
            };

            var mappedEquityModel = Mapper.Map<Stock>(equityModel);

            Assert.True(mappedEquityModel.IsDeepEqual(stockEntity));
        }
    }
}
