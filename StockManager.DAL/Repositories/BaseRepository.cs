namespace StockManager.DAL.Repositories
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Base repository.
    /// </summary>
    public abstract class BaseRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        protected BaseRepository(DbContext context)
        {
            this.DbContext = context;
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        protected DbContext DbContext { get; private set; }
    }
}
