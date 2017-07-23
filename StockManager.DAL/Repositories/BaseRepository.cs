namespace StockManager.DAL.Repositories
{
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseRepository
    {
        protected BaseRepository(DbContext context)
        {
            this.DbContext = context;
        }

        protected DbContext DbContext { get; private set; }
    }
}
