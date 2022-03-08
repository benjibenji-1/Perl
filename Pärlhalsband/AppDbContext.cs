﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace PearlNecklace
{
    internal class AddDbContext : DbContext
    {
        public DbSet<Pearl> Pearls { get; set; }
        public DbSet<Necklace> Necklaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=DESKTOP-GIUVD3P;Initial Catalog=PearlNecklaceDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
    }
}
