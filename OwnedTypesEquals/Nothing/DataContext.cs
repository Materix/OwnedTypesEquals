using Microsoft.EntityFrameworkCore;

namespace OwnedTypesEquals.Nothing
{
    public class DataContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entity>().OwnsOne(b => b.Name);
        }
    }
}