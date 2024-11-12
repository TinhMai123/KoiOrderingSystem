﻿// <auto-generated />
using System;
using KoiOrderingSystem_BusinessObject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KoiOrderingSystem_BusinessObject.Migrations
{
    [DbContext(typeof(KoiOrderingSystemContext))]
    partial class KoiOrderingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Farm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<string>("FarmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.FarmKoiType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FarmId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KoiTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.HasIndex("KoiTypeId");

                    b.ToTable("FarmKoiTypes");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Koi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FarmId")
                        .HasColumnType("int");

                    b.Property<string>("HealthStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KoiTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDetailKoiId")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.HasIndex("KoiTypeId");

                    b.ToTable("Kois");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.KoiByBatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KoiTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDetailKoiId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KoiTypeId");

                    b.ToTable("KoiByBatches");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.KoiType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsBatch")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsEndangered")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KoiTypes");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderKoiId")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InsuranceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.OrderDetailKoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("KoiByBatchId")
                        .HasColumnType("int");

                    b.Property<int?>("KoiId")
                        .HasColumnType("int");

                    b.Property<int>("OrderKoiId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isValid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KoiByBatchId")
                        .IsUnique()
                        .HasFilter("[KoiByBatchId] IS NOT NULL");

                    b.HasIndex("KoiId")
                        .IsUnique()
                        .HasFilter("[KoiId] IS NOT NULL");

                    b.HasIndex("OrderKoiId");

                    b.ToTable("OrderDetailKois");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.OrderKoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShippingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderKois");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.OrderTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ConsultantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FarmId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TripEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TripStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConsultantId");

                    b.HasIndex("FarmId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderTrips");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrencyId1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId1")
                        .HasColumnType("int");

                    b.Property<decimal?>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId1");

                    b.HasIndex("OrderId1");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ApprovalStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("QuoteAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SalesStaffId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FarmId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Farm", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.FarmKoiType", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.Farm", "Farm")
                        .WithMany("FarmKoiTypes")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KoiOrderingSystem_BusinessObject.KoiType", "KoiType")
                        .WithMany("FarmKoiTypes")
                        .HasForeignKey("KoiTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");

                    b.Navigation("KoiType");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Feedback", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Koi", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.Farm", null)
                        .WithMany("Kois")
                        .HasForeignKey("FarmId");

                    b.HasOne("KoiOrderingSystem_BusinessObject.KoiType", "KoiType")
                        .WithMany("Kois")
                        .HasForeignKey("KoiTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("KoiType");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.KoiByBatch", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.KoiType", "KoiType")
                        .WithMany()
                        .HasForeignKey("KoiTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KoiType");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Order", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.User", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("KoiOrderingSystem_BusinessObject.Insurance", null)
                        .WithMany("Orders")
                        .HasForeignKey("InsuranceId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.OrderDetailKoi", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.KoiByBatch", "KoiByBatch")
                        .WithOne("OrderDetailKoi")
                        .HasForeignKey("KoiOrderingSystem_BusinessObject.OrderDetailKoi", "KoiByBatchId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KoiOrderingSystem_BusinessObject.Koi", "Koi")
                        .WithOne("OrderDetailKoi")
                        .HasForeignKey("KoiOrderingSystem_BusinessObject.OrderDetailKoi", "KoiId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KoiOrderingSystem_BusinessObject.OrderKoi", "OrderKoi")
                        .WithMany("OrderDetailKois")
                        .HasForeignKey("OrderKoiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Koi");

                    b.Navigation("KoiByBatch");

                    b.Navigation("OrderKoi");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.OrderKoi", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.Order", "Order")
                        .WithMany("OrderKois")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.OrderTrip", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.User", "Consultant")
                        .WithMany("OrderTrips")
                        .HasForeignKey("ConsultantId");

                    b.HasOne("KoiOrderingSystem_BusinessObject.Farm", "Farm")
                        .WithMany("OrderTrips")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KoiOrderingSystem_BusinessObject.Order", "Order")
                        .WithMany("Trips")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultant");

                    b.Navigation("Farm");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Payment", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.Currency", "Currency")
                        .WithMany("Payments")
                        .HasForeignKey("CurrencyId1");

                    b.HasOne("KoiOrderingSystem_BusinessObject.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId1");

                    b.Navigation("Currency");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Quote", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.Order", "Order")
                        .WithMany("Quotes")
                        .HasForeignKey("OrderId");

                    b.HasOne("KoiOrderingSystem_BusinessObject.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId");

                    b.Navigation("Order");

                    b.Navigation("SalesStaff");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.User", b =>
                {
                    b.HasOne("KoiOrderingSystem_BusinessObject.Farm", "Farm")
                        .WithMany()
                        .HasForeignKey("FarmId");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Currency", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Farm", b =>
                {
                    b.Navigation("FarmKoiTypes");

                    b.Navigation("Kois");

                    b.Navigation("OrderTrips");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Insurance", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Koi", b =>
                {
                    b.Navigation("OrderDetailKoi");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.KoiByBatch", b =>
                {
                    b.Navigation("OrderDetailKoi");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.KoiType", b =>
                {
                    b.Navigation("FarmKoiTypes");

                    b.Navigation("Kois");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.Order", b =>
                {
                    b.Navigation("OrderKois");

                    b.Navigation("Payments");

                    b.Navigation("Quotes");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.OrderKoi", b =>
                {
                    b.Navigation("OrderDetailKois");
                });

            modelBuilder.Entity("KoiOrderingSystem_BusinessObject.User", b =>
                {
                    b.Navigation("OrderTrips");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
