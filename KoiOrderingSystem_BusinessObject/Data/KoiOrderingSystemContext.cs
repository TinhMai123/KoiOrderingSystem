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
        public DbSet<KoiOrderDetail> KoiOrderDetails { get; set; }
        public DbSet<KoiOrder> KoiOrders { get; set; }
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
            modelBuilder.Entity<KoiOrderDetail>()
                .HasOne(o => o.KoiOrder)
                .WithMany(u => u.KoiOrderDetails)
                .HasForeignKey(o => o.KoiOrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<KoiOrderDetail>()
                .HasOne(o => o.KoiByBatch)
                .WithOne(u => u.OrderDetailKoi)
                .HasForeignKey<KoiOrderDetail>(o => o.KoiByBatchId)
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
            modelBuilder.Entity<KoiType>()
                .HasData
                (
                new KoiType { Id = 1, Name = "Kohaku", IsEndangered = false, IsBatch = true, Picture = "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg" },
            new KoiType { Id = 3, Name = "Taisho Sanke", IsEndangered = false, IsBatch = true, Picture = "https://thucancakoihikari.com/wp-content/uploads/2024/04/koi-taisho-sanke-1.jpg" },
            new KoiType { Id = 2, Name = "Showa Sanshoku", IsEndangered = true, IsBatch = false, Picture = "https://cakoibienhoa.com/public/userfiles/products/ca-koi-showa-sanshoku-thumb.jpg" },
            new KoiType { Id = 4, Name = "Shusui", IsEndangered = false, IsBatch = true, Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2qwYKPpE9yJJKYJ_npVzr3WzWvybWZK8-fQ&s" },
            new KoiType { Id = 5, Name = "Asagi", IsEndangered = true, IsBatch = false, Picture = "https://hanoverkoifarms.com/wp-content/uploads/2017/01/best-asagi.jpg" }
                );
            modelBuilder.Entity<Koi>().HasData
                (
                new Koi
                {
                    Id = 1,
                    Weight = 2.3f,
                    Description = "Bright orange koi with white spots.",
                    HealthStatus = "Healthy",
                    BirthDate = new DateTime(2021, 3, 15),
                    Status = true,
                    Picture = "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg",
                    KoiTypeId = 1,
                    FarmId = 1
                },
            new Koi
            {
                Id = 2,
                Weight = 3.1f,
                Description = "Black and white koi with a smooth pattern.",
                HealthStatus = "Healthy",
                BirthDate = new DateTime(2020, 7, 22),
                Status = true,
                Picture = "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg",
                KoiTypeId = 2,
                FarmId = 1
            },
            new Koi
            {
                Id = 3,
                Weight = 2.8f,
                Description = "Golden koi with a shiny coat.",
                HealthStatus = "Under observation",
                BirthDate = new DateTime(2021, 1, 10),
                Status = true,
                Picture = "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg",
                KoiTypeId = 3,
                FarmId = 1
            },
            new Koi
            {
                Id = 4,
                Weight = 1.9f,
                Description = "Small blue and orange koi.",
                HealthStatus = "Healthy",
                BirthDate = new DateTime(2022, 5, 30),
                Status = true,
                Picture = "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg",
                KoiTypeId = 4,
                FarmId = 1
            },
            new Koi
            {
                Id = 5,
                Weight = 4.2f,
                Description = "Large white koi with orange spots.",
                HealthStatus = "Healthy",
                BirthDate = new DateTime(2019, 11, 5),
                Status = false,
                Picture = "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg",
                KoiTypeId = 5,
                FarmId = 1
            }
                );
            modelBuilder.Entity<KoiByBatch>().HasData
                (
                 new KoiByBatch { Id = 1, Quantity = 10, Size = 5, Price = 100.00m, KoiTypeId = 1 },
            new KoiByBatch { Id = 2, Quantity = 15, Size = 6, Price = 150.00m, KoiTypeId = 2 },
            new KoiByBatch { Id = 3, Quantity = 8, Size = 4, Price = 80.00m, KoiTypeId = 3 },
            new KoiByBatch { Id = 4, Quantity = 12, Size = 7, Price = 120.00m, KoiTypeId = 4 },
            new KoiByBatch { Id = 5, Quantity = 20, Size = 10, Price = 200.00m, KoiTypeId = 5 }
                );
            modelBuilder.Entity<Farm>().HasData(
                 new Farm
                 {
                     Id = 1,
                     FarmName = "Serenity Koi Farm",
                     Location = "Kyoto",
                     Description = "A tranquil farm specializing in high-quality koi fish.",
                     ManagerId = 2,
                     EstablishedYear = 2005
                 },
            new Farm
            {
                Id = 2,
                FarmName = "Golden Pond Koi Farm",
                Location = "Osaka",
                Description = "Known for its vibrant and colorful koi varieties.",
                ManagerId = 2,
                EstablishedYear = 2010
            },
            new Farm
            {
                Id = 3,
                FarmName = "Harmony Koi Farm",
                Location = "Tokyo",
                Description = "A family-owned farm with a rich history in koi breeding.",
                ManagerId = 2,
                EstablishedYear = 2000
            },
            new Farm
            {
                Id = 4,
                FarmName = "Lotus Koi Farm",
                Location = "Hiroshima",
                Description = "Specializes in rare koi breeds and sustainable farming practices.",
                ManagerId = 2,
                EstablishedYear = 2015
            },
            new Farm
            {
                Id = 5,
                FarmName = "Peaceful Waters Koi Farm",
                Location = "Nara",
                Description = "Offers a serene environment and expert koi care.",
                ManagerId = 2,
                EstablishedYear = 2018
            }
            );
            modelBuilder.Entity<FarmKoiType>().HasData(
                 new FarmKoiType { Id = 1, FarmId = 1, KoiTypeId = 1, Price = 20.00m },
            new FarmKoiType { Id = 2, FarmId = 1, KoiTypeId = 2, Price = 25.00m },
            new FarmKoiType { Id = 3, FarmId = 1, KoiTypeId = 3, Price = 30.00m },
            new FarmKoiType { Id = 4, FarmId = 1, KoiTypeId = 4, Price = 35.00m },
            new FarmKoiType { Id = 5, FarmId = 1, KoiTypeId = 5, Price = 40.00m },
            new FarmKoiType { Id = 6, FarmId = 2, KoiTypeId = 1, Price = 22.00m },
            new FarmKoiType { Id = 7, FarmId = 2, KoiTypeId = 2, Price = 27.00m },
            new FarmKoiType { Id = 8, FarmId = 2, KoiTypeId = 3, Price = 32.00m },
            new FarmKoiType { Id = 9, FarmId = 2, KoiTypeId = 4, Price = 37.00m },
            new FarmKoiType { Id = 10, FarmId = 2, KoiTypeId = 5, Price = 42.00m },
            new FarmKoiType { Id = 11, FarmId = 3, KoiTypeId = 1, Price = 24.00m },
            new FarmKoiType { Id = 12, FarmId = 3, KoiTypeId = 2, Price = 29.00m },
            new FarmKoiType { Id = 13, FarmId = 3, KoiTypeId = 3, Price = 34.00m },
            new FarmKoiType { Id = 14, FarmId = 3, KoiTypeId = 4, Price = 39.00m },
            new FarmKoiType { Id = 15, FarmId = 3, KoiTypeId = 5, Price = 44.00m },
            new FarmKoiType { Id = 16, FarmId = 4, KoiTypeId = 1, Price = 26.00m },
            new FarmKoiType { Id = 17, FarmId = 4, KoiTypeId = 2, Price = 31.00m },
            new FarmKoiType { Id = 18, FarmId = 4, KoiTypeId = 3, Price = 36.00m },
            new FarmKoiType { Id = 19, FarmId = 4, KoiTypeId = 4, Price = 41.00m },
            new FarmKoiType { Id = 20, FarmId = 4, KoiTypeId = 5, Price = 46.00m },
            new FarmKoiType { Id = 21, FarmId = 5, KoiTypeId = 1, Price = 28.00m },
            new FarmKoiType { Id = 22, FarmId = 5, KoiTypeId = 2, Price = 33.00m },
            new FarmKoiType { Id = 23, FarmId = 5, KoiTypeId = 3, Price = 38.00m },
            new FarmKoiType { Id = 24, FarmId = 5, KoiTypeId = 4, Price = 43.00m },
            new FarmKoiType { Id = 25, FarmId = 5, KoiTypeId = 5, Price = 48.00m }
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
