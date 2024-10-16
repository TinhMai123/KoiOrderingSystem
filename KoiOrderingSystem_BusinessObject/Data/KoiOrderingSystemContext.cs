using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Koi> Kois { get; set; }
        public DbSet<KoiByBatch> KoiByBatches { get; set; }
        public DbSet<KoiType> KoiTypes { get; set; }
        public DbSet<FarmKoiType> FarmKoiTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetailKoi> OrderDetails { get; set; }
        public DbSet<OrderKoi> OrderKois { get; set; }
        public DbSet<OrderTrip> OrderTrips { get; set; }
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
