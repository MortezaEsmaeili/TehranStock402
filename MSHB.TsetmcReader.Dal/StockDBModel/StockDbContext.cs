using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MSHB.TsetmcReader.Dal
{
    public partial class StockDbContext : DbContext
    {
        public StockDbContext()
            : base("name=StockDbConnString")
        {
        }

        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<Type1Stock> Type1Stock { get; set; }
        public virtual DbSet<InstrumentHistory> InstrumentHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type1Stock>()
                .Property(e => e.LastPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Type1Stock>()
                .Property(e => e.SupportPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Type1Stock>()
                .Property(e => e.TargetPrice1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Type1Stock>()
                .Property(e => e.TargetPrice2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Type1Stock>()
                .Property(e => e.TargetPrice3)
                .HasPrecision(18, 0);
        }
    }
}
