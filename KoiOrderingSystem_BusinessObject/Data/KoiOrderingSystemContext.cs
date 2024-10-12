using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject.Data
{
    public class KoiOrderingSystemContext : DbContext
    {
        public KoiOrderingSystemContext() { }   
        public KoiOrderingSystemContext(DbContextOptions<KoiOrderingSystemContext> options)
        : base(options)
        {

        }

        DbSet<Currency> Currencies { get; set; }
        DbSet<Farm> Farms { get; set; }
        DbSet<Koi> Kois { get; set; }
        DbSet<KoiByBatch> KoiByBatches { get; set; }
        DbSet<KoiType> KoiTypes { get; set; }
        DbSet<FarmKoiType> FarmKoiTypes { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<Insurance> Insurances { get; set;}
        DbSet<User> Users { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetailKoi> OrderDetails { get; set; }
        DbSet<OrderKoi> OrderKois { get; set; }
        DbSet<OrderTrip> OrderTrips { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer) 
                .WithMany(u => u.Orders) 
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Farm>()
                .HasOne(o => o.Manager)
                .WithMany()
                .HasForeignKey(o => o.ManagerId);
            modelBuilder.Entity<OrderTrip>()
                .HasOne(o => o.Consultant)
                .WithMany(u => u.OrderTrips)
                .HasForeignKey(o => o.ConsultantId);
            modelBuilder.Entity<Koi>()
                .HasOne(o => o.KoiType)
                .WithMany(u => u.Kois)
                .HasForeignKey(o => o.KoiTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderDetailKoi>()
                .HasOne(o => o.OrderKoi)
                .WithMany(u => u.OrderDetailKois) 
                .HasForeignKey(o => o.OrderKoiId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderDetailKoi>()
                .HasOne(o => o.Koi)
                .WithOne(u => u.OrderDetailKoi)
                .HasForeignKey<OrderDetailKoi>(o => o.KoiId)
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<OrderDetailKoi>()
                .HasOne(o => o.KoiByBatch)
                .WithOne(u => u.OrderDetailKoi)
                .HasForeignKey<OrderDetailKoi>(o => o.KoiByBatchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
