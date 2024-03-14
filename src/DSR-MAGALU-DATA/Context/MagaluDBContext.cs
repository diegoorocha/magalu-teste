using DSR_MAGALU_DATA.Context.MappingTables;
using DSR_MAGALU_DATA.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSR_MAGALU_DATA.Context
{
    public class MagaluDBContext : DbContext
    {
        public MagaluDBContext(DbContextOptions<MagaluDBContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TABELAS MAPEAMENTOS

            modelBuilder.ApplyConfiguration(new ClienteMapping());

            #endregion TABELAS MAPEAMENTOS

            base.OnModelCreating(modelBuilder);
        }
    }
}
