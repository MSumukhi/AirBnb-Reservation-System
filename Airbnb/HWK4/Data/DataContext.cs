using Airbnb.Models;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Data
{
    using Airbnb.Models;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Airbnb> Airbnb { get; set; }
        public DbSet<Airbnb_review> Airbnb_review { get;set; }
    }
}
