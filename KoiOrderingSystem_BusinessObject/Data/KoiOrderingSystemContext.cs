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
        public DbSet<OrderKoiDetail> OrderDetailKois { get; set; }
        public DbSet<OrderKoi> OrderKois { get; set; }
        public DbSet<OrderTrip> OrderTrips { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Farm>()
                .HasOne(f => f.Manager)
                .WithMany(m => m.Farms)
                .HasForeignKey(f => f.ManagerId);
            modelBuilder.Entity<OrderTrip>()
                .HasOne(o => o.Consultant)
                .WithMany(u => u.OrderTrips)
                .HasForeignKey(o => o.ConsultantId);
            modelBuilder.Entity<Koi>()
                .HasOne(o => o.KoiType)
                .WithMany(u => u.Kois)
                .HasForeignKey(o => o.KoiTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderKoiDetail>()
                .HasOne(o => o.OrderKoi)
                .WithMany(u => u.OrderDetailKois)
                .HasForeignKey(o => o.OrderKoiId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderKoiDetail>()
                .HasOne(o => o.Koi)
                .WithOne(u => u.OrderDetailKoi)
                .HasForeignKey<OrderKoiDetail>(o => o.KoiId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderKoiDetail>()
                .HasOne(o => o.KoiByBatch)
                .WithOne(u => u.OrderDetailKoi)
                .HasForeignKey<OrderKoiDetail>(o => o.KoiByBatchId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     FullName = "Admin Johnson",
                     Email = "admin@gmail.com",
                     PhoneNumber = "123-456-7890",
                     Password = "123456",
                     Address = "123 Maple St, Springfield, IL",
                     Role = "Admin",
                     Avatar = "avatars/alice.jpg"
                 },
            new User
            {
                Id = 2,
                FullName = "Manager Smith",
                Email = "manager@gmail.com",
                PhoneNumber = "234-567-8901",
                Password = "securepass",
                Address = "456 Oak St, Springfield, IL",
                Role = "Manager",
                Avatar = "avatars/bob.jpg"
            },
            new User
            {
                Id = 3,
                FullName = "Staff Brown",
                Email = "staff@gmail.com",
                PhoneNumber = "345-678-9012",
                Password = "mypassword",
                Address = "789 Pine St, Springfield, IL",
                Role = "Staff",
                Avatar = "avatars/charlie.jpg"
            },
            new User
            {
                Id = 4,
                FullName = "Customer Prince",
                Email = "customer@gmail.com",
                PhoneNumber = "456-789-0123",
                Password = "123456",
                Address = "321 Cedar St, Springfield, IL",
                Role = "Customer",
                Avatar = "avatars/diana.jpg"
            },
            new User
            {
                Id = 5,
                FullName = "Ethan Hunt",
                Email = "ethan.hunt@example.com",
                PhoneNumber = "567-890-1234",
                Password = "missionimpossible",
                Address = "654 Birch St, Springfield, IL",
                Role = "Staff",
                Avatar = "avatars/ethan.jpg"
            }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=KoiOrderingSystem;User Id=sa;Password=1234567890;Integrated Security=True;TrustServerCertificate=True");
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
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
    }

}
