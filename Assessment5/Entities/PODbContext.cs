using Microsoft.EntityFrameworkCore;

namespace Assessment5.Entities
{
    public class PODbContext : DbContext
    {
        private IConfiguration _configuration;
        public PODbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<POMaster> POMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PODbConnection"));
        }
    }
}
