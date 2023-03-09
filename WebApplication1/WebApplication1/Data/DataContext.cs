using Microsoft.EntityFrameworkCore;
using billdataRestAPIMySQL.Models;

namespace billdataRestAPIMySQL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<billdata> billdata { get; set; }

    }
}