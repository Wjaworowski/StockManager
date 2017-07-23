namespace StockManager.Common.Models
{
    /// <summary>
    /// Equity Stock Model.
    /// </summary>
    /// <seealso cref="StockManager.Common.Models.BaseStock" />
    public class EquityModel : BaseStock
    {
        /// <summary>
        /// Gets the commision percent of a Equity.
        /// </summary>
        /// <value>
        /// The commision percent.
        /// </value>
        public override double CommisionPercent => 0.005;
    }
}
