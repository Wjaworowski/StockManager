﻿namespace StockManager.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using StockManager.DAL.Entities;

    /// <summary>
    /// Concrete repository to access Stocks in database.
    /// </summary>
    /// <seealso cref="StockManager.DAL.Repositories.BaseRepository" />
    /// <seealso cref="StockManager.DAL.Repositories.IStockRepository" />
    public class StockRepository : BaseRepository, IStockRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public StockRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets all stocks.
        /// </summary>
        /// <returns>
        /// Collection of stocks.
        /// </returns>
        public ICollection<Stock> GetAllStocks()
        {
            return this.DbContext.Set<Stock>().ToList();
        }

        /// <summary>
        /// Inserts the stock.
        /// </summary>
        /// <param name="stock">The stock entity.</param>
        public void InsertStock(Stock stock)
        {
            this.DbContext.Add(stock);
            this.DbContext.SaveChanges();
        }
    }
}
