namespace StockManager.Common.Models
{
    /// <summary>
    /// Base clack to a stock
    /// </summary>
    public abstract class BaseStock
    {
        /// <summary>
        /// Gets the commision percent of a stock.
        /// </summary>
        /// <value>
        /// The commision percent.
        /// </value>
        public abstract double CommisionPercent { get; }

        /// <summary>
        /// Gets or sets the price of a stock.
        /// </summary>
        /// <value>
        /// The price of a stock.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of a stock.
        /// </summary>
        /// <value>
        /// The quantity of a stock.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the market value of a stock.
        /// </summary>
        /// <value>
        /// The market value, dynamically calculated.
        /// </value>
        public decimal MarketValue => this.Price * this.Quantity;

        /// <summary>
        /// Gets the transaction cost of a stock.
        /// </summary>
        /// <value>
        /// The transaction cost, dynamically calculated.
        /// </value>
        public decimal TransactionCost => this.MarketValue * (decimal)this.CommisionPercent;
    }
}
