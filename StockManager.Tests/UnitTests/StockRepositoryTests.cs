namespace StockManager.Tests.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;

    using DeepEqual.Syntax;

    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;

    using StockManager.Common.Enums;
    using StockManager.DAL;
    using StockManager.DAL.Entities;
    using StockManager.DAL.Repositories;

    using Xunit;

    /// <summary>
    /// Stock repository tests.
    /// </summary>
    public class StockRepositoryTests
    {
        /// <summary>
        /// Tests the insert operation.
        /// </summary>
        [Fact]
        public void InsertTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            try
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite(connection).Options;
                using (var context = new DatabaseContext(options))
                {
                    context.Database.EnsureCreated();
                }

                var stock = new Stock
                                {
                                    Price = new decimal(12.32),
                                    Quantity = 7,
                                    StockType = StockType.Bond,
                                    CommisionPercent = 2.0
                                };

                using (var context = new DatabaseContext(options))
                {
                    var repository = new StockRepository(context);
                    repository.InsertStock(stock);
                }

                using (var context = new DatabaseContext(options))
                {
                    Assert.Equal(1, context.Stocks.Count());
                    Assert.True(stock.IsDeepEqual(context.Stocks.Single()));
                }
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Tests the get all stocks operation.
        /// </summary>
        [Fact]
        public void GetAllTests()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            try
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite(connection).Options;
                using (var context = new DatabaseContext(options))
                {
                    context.Database.EnsureCreated();
                }

                var stockCollection = new List<Stock>
                                      {
                                          new Stock
                                              {
                                                  Price = new decimal(12.32),
                                                  Quantity = 7,
                                                  StockType = StockType.Bond,
                                                  CommisionPercent = 2.0
                                              },
                                          new Stock
                                              {
                                                  Price = new decimal(72.11),
                                                  Quantity = 96,
                                                  StockType = StockType.Equity,
                                                  CommisionPercent = 0.5
                                              }
                                      };
                using (var context = new DatabaseContext(options))
                {
                    foreach (var stock in stockCollection)
                    {
                        context.Stocks.Add(stock);
                    }

                    context.SaveChanges();
                }

                using (var context = new DatabaseContext(options))
                {
                    var repository = new StockRepository(context);
                    var stocks = repository.GetAllStocks().ToList();
                    Assert.Equal(2, stocks.Count);
                    Assert.True(stocks.IsDeepEqual(stockCollection));
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
