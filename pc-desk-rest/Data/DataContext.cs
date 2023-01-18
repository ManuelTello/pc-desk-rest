using Microsoft.EntityFrameworkCore;
using pc_desk_rest.Models;

namespace pc_desk_rest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
