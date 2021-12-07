using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rokomari.Delivery.Contexts;
using Rokomari.Delivery.Entities;

namespace Rokomari.Delivery.Contexts
{
    public class DeliveryContext : Context, IDeliveryContext
    {
        public DeliveryContext(string connectionString, string migrationAssemblyName) 
            : base(connectionString, migrationAssemblyName)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookPublisher>()
                .HasOne(bp => bp.book)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.BookId);

            modelBuilder.Entity<BookPublisher>()
                .HasOne(bp => bp.publisher)
                .WithMany(p => p.PublisherBooks)
                .HasForeignKey(pb => pb.PublisherId);

            modelBuilder.Entity<BookPublisher>()
               .HasKey(bp => new { bp.BookId, bp.PublisherId });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Electronics> Electronics { get; set; }
    }
}
