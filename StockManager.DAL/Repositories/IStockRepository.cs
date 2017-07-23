namespace StockManager.DAL.Repositories
{
    using System.Collections.Generic;

    using StockManager.DAL.Entities;

    /// <summary>
    /// Repository to access Stocks in database.
    /// </summary>
    public interface IStockRepository
    {
        /// <summary>
        /// Gets all stocks.
        /// </summary>
        /// <returns>Collection of stocks.</returns>
        ICollection<Stock> GetAllStocks();

        /// <summary>
        /// Inserts the stock.
        /// </summary>
        /// <param name="stock">The stock entity.</param>
        void InsertStock(Stock stock);
    }
}
