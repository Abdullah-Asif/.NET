using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public class BitCoinContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public BitCoinContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<BitCoinPrice>()
            //    .HasOne(p => p.bpi)
            //    .WithOne(b => b.BitCoinPrice);

               

            base.OnModelCreating(builder);
        }
        public virtual DbSet<BitCoinPrice> BitCoinPrice { get; set; }
    }
}
