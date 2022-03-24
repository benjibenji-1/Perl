using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContextLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace PearlNecklace
{
    public class NecklaceDb : DbContext
    {
        public DbSet<Pearl> Pearls { get; set; }
        public DbSet<Necklace> Necklaces { get; set; }

        public NecklaceDb() { }
        public NecklaceDb(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = DBConnection.ConfigurationRoot.GetConnectionString("SQLServer_necklaceDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Necklace>()
                .Property(b => b.ID)
                .ValueGeneratedOnAdd();
        }

    }
}
