using Microsoft.EntityFrameworkCore;
using TestBackgroundApis.Models;

namespace TestBackgroundApis
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Fake> Fakes { get; set; }

    }
}
