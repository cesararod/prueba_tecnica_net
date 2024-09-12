using Microsoft.EntityFrameworkCore;
using prueba_tecnica_net_Cesar_Rodriguez.Models;

namespace prueba_tecnica_net_Cesar_Rodriguez.Data
{
    public class MbaDbContext : DbContext
    {
        public DbSet<CountryDAO> Countries { get; set; }
        public DbSet<MbaDAO> Mbas { get; set; }
        public MbaDbContext(DbContextOptions<MbaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryDAO>()
                .HasMany(x => x.Mbas)
                .WithOne(y => y.Country)
                .HasForeignKey(y => y.CountryFk);

            modelBuilder.Entity<CountryDAO>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<MbaDAO>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
