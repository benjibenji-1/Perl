using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PearlNecklaceDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Necklace>()
                .Property(b => b.ID)
                .ValueGeneratedOnAdd();
        }

    }
}
