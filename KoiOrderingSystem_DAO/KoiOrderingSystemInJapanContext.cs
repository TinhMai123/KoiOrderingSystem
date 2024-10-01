using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace KoiOrderingSystem_DAO
{
    public partial class KoiOrderingSystemInJapanContext : DbContext
    {
        public KoiOrderingSystemInJapanContext()
        {
        }

        public KoiOrderingSystemInJapanContext(DbContextOptions<KoiOrderingSystemInJapanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<AnimalVariety> AnimalVarieties { get; set; } = null!;
        public virtual DbSet<CheckIn> CheckIns { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerSupport> CustomerSupports { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Farm> Farms { get; set; } = null!;
        public virtual DbSet<FarmAnimal> FarmAnimals { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderCancellation> OrderCancellations { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderProcess> OrderProcesses { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

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
            return configuration.GetConnectionString("DbConnect") ?? string.Empty;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.Color).HasMaxLength(200);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.HealthStatus).HasMaxLength(200);

                entity.Property(e => e.IsAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.AnimalVariety)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.AnimalVarietyId)
                    .HasConstraintName("FK__Animals__AnimalV__5165187F");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__Animals__FarmID__52593CB8");
            });

            modelBuilder.Entity<AnimalVariety>(entity =>
            {
                entity.Property(e => e.CareDifficulty).HasMaxLength(100);

                entity.Property(e => e.ColorPattern).HasMaxLength(300);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Diet).HasMaxLength(300);

                entity.Property(e => e.Habitat).HasMaxLength(300);

                entity.Property(e => e.IsEndangered).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScientificName).HasMaxLength(200);

                entity.Property(e => e.TypeName).HasMaxLength(200);
            });

            modelBuilder.Entity<CheckIn>(entity =>
            {
                entity.Property(e => e.CheckInId).HasColumnName("CheckInID");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CheckInStatus).HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CheckIns)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CheckIns__Custom__114A936A");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.CheckIns)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__CheckIns__TripID__10566F31");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CheckIns)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CheckIns__UserID__17F790F9");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.UserId, "UQ__Customer__1788CC4DADCDA270")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.IsVerified).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.LoyaltyPoints).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PreferredPaymentMethod).HasMaxLength(50);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalSpent).HasColumnType("money");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.UserId)
                    .HasConstraintName("FK__Customers__UserI__45F365D3");
            });

            modelBuilder.Entity<CustomerSupport>(entity =>
            {
                entity.HasKey(e => e.SupportId)
                    .HasName("PK__Customer__D82DBC6C71F00442");

                entity.ToTable("CustomerSupport");

                entity.Property(e => e.SupportId).HasColumnName("SupportID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequestDescription).HasMaxLength(500);

                entity.Property(e => e.ResponseDate).HasColumnType("datetime");

                entity.Property(e => e.ResponseDescription).HasMaxLength(500);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSupports)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerS__Custo__17036CC0");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(300);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryNote).HasMaxLength(500);

                entity.Property(e => e.DeliveryStatus).HasMaxLength(100);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Deliverie__Order__0B91BA14");
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.ContactEmail).HasMaxLength(100);

                entity.Property(e => e.ContactPhone).HasMaxLength(20);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FarmName).HasMaxLength(200);

                entity.Property(e => e.IsCertified).HasDefaultValueSql("((0))");

                entity.Property(e => e.Location).HasMaxLength(300);

                entity.Property(e => e.OwnerName).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FarmAnimal>(entity =>
            {
                entity.HasKey(e => new { e.FarmId, e.AnimalVarietyId })
                    .HasName("PK__FarmAnim__E9B7AC6DD7E4F5B5");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.CareInstructions).HasMaxLength(500);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsInStock).HasDefaultValueSql("((1))");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AnimalVariety)
                    .WithMany(p => p.FarmAnimals)
                    .HasForeignKey(d => d.AnimalVarietyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FarmAnima__Anima__5812160E");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.FarmAnimals)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FarmAnima__FarmI__571DF1D5");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FeedbackDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsVerified).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(300)
                    .HasColumnName("PhotoURL");

                entity.Property(e => e.Reply).HasMaxLength(500);

                entity.Property(e => e.WouldRecommend).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Feedbacks__Custo__75A278F5");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Feedbacks__Order__76969D2E");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ActualDeliveryDate).HasColumnType("date");

                entity.Property(e => e.CancellationStatus)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Not Canceled')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ExpectedDeliveryDate).HasColumnType("date");

                entity.Property(e => e.GiftMessage).HasMaxLength(300);

                entity.Property(e => e.IsGift).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShippingAddress).HasMaxLength(300);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__628FA481");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__Orders__TripID__6383C8BA");
            });

            modelBuilder.Entity<OrderCancellation>(entity =>
            {
                entity.HasKey(e => e.CancellationId)
                    .HasName("PK__OrderCan__6A2D9A1A4CD50212");

                entity.Property(e => e.CancellationId).HasColumnName("CancellationID");

                entity.Property(e => e.CancellationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.RefundAmount).HasColumnType("money");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderCancellations)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderCanc__Order__07C12930");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepositAmount).HasColumnType("money");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.TaxAmount).HasColumnType("money");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AnimalVariety)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.AnimalVarietyId)
                    .HasConstraintName("FK__OrderDeta__Anima__68487DD7");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__6754599E");
            });

            modelBuilder.Entity<OrderProcess>(entity =>
            {
                entity.ToTable("OrderProcess");

                entity.Property(e => e.ActualCompletionDate).HasColumnType("date");

                entity.Property(e => e.AssignedTo).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpectedCompletionDate).HasColumnType("date");

                entity.Property(e => e.IsCompleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.ProcessStep).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StepDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProcesses)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderProc__Order__7C4F7684");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderProcesses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__OrderProc__UserI__7D439ABD");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency).HasMaxLength(10);

                entity.Property(e => e.PaymentAmount).HasColumnType("money");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.PaymentNote).HasMaxLength(300);

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.ProcessedBy).HasMaxLength(200);

                entity.Property(e => e.RefundAmount).HasColumnType("money");

                entity.Property(e => e.TransactionId).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payments__OrderI__6D0D32F4");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsArchived).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastAccessed).HasColumnType("datetime");

                entity.Property(e => e.ReportName).HasMaxLength(200);

                entity.Property(e => e.ReportStatus).HasMaxLength(50);

                entity.Property(e => e.ReportType).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TotalSales).HasColumnType("money");

                entity.Property(e => e.TotalViews).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Reports__Created__02FC7413");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160318D1636")
                    .IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RoleName).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Duration)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.IncludedServices).HasMaxLength(500);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.MeetingLocation).HasMaxLength(300);

                entity.Property(e => e.NotIncludedServices).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SpecialInstructions).HasMaxLength(500);

                entity.Property(e => e.Transportation).HasMaxLength(200);

                entity.Property(e => e.TripDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__Trips__FarmID__5CD6CB2B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534EF960DDD")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleId__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
