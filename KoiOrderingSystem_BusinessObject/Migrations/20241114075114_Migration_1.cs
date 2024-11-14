using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiOrderingSystem_BusinessObject.Migrations
{
    public partial class Migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KoiTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEndangered = table.Column<bool>(type: "bit", nullable: false),
                    IsBatch = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoiTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KoiByBatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KoiTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoiByBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KoiByBatches_KoiTypes_KoiTypeId",
                        column: x => x.KoiTypeId,
                        principalTable: "KoiTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    EstablishedYear = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farms_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KoiOderId = table.Column<int>(type: "int", nullable: true),
                    InsuranceId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmKoiTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    KoiTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmKoiTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmKoiTypes_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmKoiTypes_KoiTypes_KoiTypeId",
                        column: x => x.KoiTypeId,
                        principalTable: "KoiTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KoiTypeId = table.Column<int>(type: "int", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kois_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kois_KoiTypes_KoiTypeId",
                        column: x => x.KoiTypeId,
                        principalTable: "KoiTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KoiOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoiOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KoiOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTrips_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTrips_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTrips_Users_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    SalesStaffId = table.Column<int>(type: "int", nullable: true),
                    QuoteAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovalStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotes_Users_SalesStaffId",
                        column: x => x.SalesStaffId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KoiOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    KoiId = table.Column<int>(type: "int", nullable: true),
                    KoiByBatchId = table.Column<int>(type: "int", nullable: true),
                    KoiOrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoiOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KoiOrderDetails_KoiByBatches_KoiByBatchId",
                        column: x => x.KoiByBatchId,
                        principalTable: "KoiByBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KoiOrderDetails_KoiOrders_KoiOrderId",
                        column: x => x.KoiOrderId,
                        principalTable: "KoiOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KoiOrderDetails_Kois_KoiId",
                        column: x => x.KoiId,
                        principalTable: "Kois",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "KoiTypes",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsBatch", "IsDeleted", "IsEndangered", "Name", "Picture", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9671), null, true, false, false, "Kohaku", "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9672) },
                    { 2, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9677), null, false, false, true, "Showa Sanshoku", "https://cakoibienhoa.com/public/userfiles/products/ca-koi-showa-sanshoku-thumb.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9677) },
                    { 3, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9675), null, true, false, false, "Taisho Sanke", "https://thucancakoihikari.com/wp-content/uploads/2024/04/koi-taisho-sanke-1.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9675) },
                    { 4, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9678), null, true, false, false, "Shusui", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2qwYKPpE9yJJKYJ_npVzr3WzWvybWZK8-fQ&s", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9679) },
                    { 5, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9680), null, false, false, true, "Asagi", "https://hanoverkoifarms.com/wp-content/uploads/2017/01/best-asagi.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9680) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Avatar", "CreatedAt", "DeletedAt", "Email", "FullName", "IsDeleted", "Password", "PhoneNumber", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 Maple St, Springfield, IL", "avatars/alice.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9551), null, "admin@gmail.com", "Admin Johnson", false, "123456", "123-456-7890", "Admin", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9560) },
                    { 2, "456 Oak St, Springfield, IL", "avatars/bob.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9564), null, "manager@gmail.com", "Manager Smith", false, "securepass", "234-567-8901", "Manager", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9564) },
                    { 3, "789 Pine St, Springfield, IL", "avatars/charlie.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9566), null, "staff@gmail.com", "Staff Brown", false, "mypassword", "345-678-9012", "Staff", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9566) },
                    { 4, "321 Cedar St, Springfield, IL", "avatars/diana.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9568), null, "customer@gmail.com", "Customer Prince", false, "123456", "456-789-0123", "Customer", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9568) },
                    { 5, "654 Birch St, Springfield, IL", "avatars/ethan.jpg", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9570), null, "ethan.hunt@example.com", "Ethan Hunt", false, "missionimpossible", "567-890-1234", "Staff", new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9570) }
                });

            migrationBuilder.InsertData(
                table: "KoiByBatches",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "KoiTypeId", "Price", "Quantity", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9722), null, false, 1, 100.00m, 10, 5, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9723) },
                    { 2, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9726), null, false, 2, 150.00m, 15, 6, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9726) },
                    { 3, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9727), null, false, 3, 80.00m, 8, 4, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9727) },
                    { 4, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9728), null, false, 4, 120.00m, 12, 7, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9728) },
                    { 5, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9729), null, false, 5, 200.00m, 20, 10, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9729) }
                });

            migrationBuilder.InsertData(
                table: "Kois",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DateAdded", "DeletedAt", "Description", "FarmId", "HealthStatus", "IsDeleted", "KoiTypeId", "Picture", "Status", "UpdatedAt", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9695), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9693), null, "Bright orange koi with white spots.", null, "Healthy", false, 1, "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg", true, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9696), 2.3f },
                    { 2, new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9700), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9700), null, "Black and white koi with a smooth pattern.", null, "Healthy", false, 2, "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg", true, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9700), 3.1f },
                    { 3, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9703), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9702), null, "Golden koi with a shiny coat.", null, "Under observation", false, 3, "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg", true, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9703), 2.8f },
                    { 4, new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9704), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9704), null, "Small blue and orange koi.", null, "Healthy", false, 4, "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg", true, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9705), 1.9f },
                    { 5, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9706), new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9706), null, "Large white koi with orange spots.", null, "Healthy", false, 5, "https://hanoverkoifarms.com/wp-content/uploads/2017/01/great-kohaku-739x1024.jpg", false, new DateTime(2024, 11, 14, 14, 51, 14, 694, DateTimeKind.Local).AddTicks(9707), 4.2f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmKoiTypes_FarmId",
                table: "FarmKoiTypes",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmKoiTypes_KoiTypeId",
                table: "FarmKoiTypes",
                column: "KoiTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_ManagerId",
                table: "Farms",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_OrderId",
                table: "Feedbacks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_KoiByBatches_KoiTypeId",
                table: "KoiByBatches",
                column: "KoiTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_KoiOrderDetails_KoiByBatchId",
                table: "KoiOrderDetails",
                column: "KoiByBatchId",
                unique: true,
                filter: "[KoiByBatchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KoiOrderDetails_KoiId",
                table: "KoiOrderDetails",
                column: "KoiId");

            migrationBuilder.CreateIndex(
                name: "IX_KoiOrderDetails_KoiOrderId",
                table: "KoiOrderDetails",
                column: "KoiOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_KoiOrders_OrderId",
                table: "KoiOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Kois_FarmId",
                table: "Kois",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Kois_KoiTypeId",
                table: "Kois",
                column: "KoiTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InsuranceId",
                table: "Orders",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrips_ConsultantId",
                table: "OrderTrips",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrips_FarmId",
                table: "OrderTrips",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrips_OrderId",
                table: "OrderTrips",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurrencyId",
                table: "Payments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_OrderId",
                table: "Quotes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_SalesStaffId",
                table: "Quotes",
                column: "SalesStaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmKoiTypes");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "KoiOrderDetails");

            migrationBuilder.DropTable(
                name: "OrderTrips");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "KoiByBatches");

            migrationBuilder.DropTable(
                name: "KoiOrders");

            migrationBuilder.DropTable(
                name: "Kois");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "KoiTypes");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
