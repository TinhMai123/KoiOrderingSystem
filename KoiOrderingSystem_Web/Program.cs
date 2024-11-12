
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Repository.Repo;
using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_Service.Service;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddScoped<ICurrencyRepo, CurrencyRepo>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddScoped<IFarmKoiTypeRepo, FarmKoiTypeRepo>();
builder.Services.AddScoped<IFarmKoiTypeService, FarmKoiTypeService>();

builder.Services.AddScoped<IFarmRepo, FarmRepo>();
builder.Services.AddScoped<IFarmService, FarmService>();

builder.Services.AddScoped<IFeedbackRepo, FeedbackRepo>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

builder.Services.AddScoped<IInsuranceRepo, InsuranceRepo>();
builder.Services.AddScoped<IInsuranceService, InsuranceService>();

builder.Services.AddScoped<IKoiByBatchRepo, KoiByBatchRepo>();
builder.Services.AddScoped<IKoiByBatchService, KoiByBatchService>();

builder.Services.AddScoped<IKoiRepo, KoiRepo>();
builder.Services.AddScoped<IKoiService, KoiService>();

builder.Services.AddScoped<IKoiTypeRepo, KoiTypeRepo>();
builder.Services.AddScoped<IKoiTypeService, KoiTypeService>();

builder.Services.AddScoped<IOrderDetailKoiRepo, OrderDetailKoiRepo>();
builder.Services.AddScoped<IOrderDetailKoiService, OrderDetailKoiService>();

builder.Services.AddScoped<IOrderKoiRepo, OrderKoiRepo>();
builder.Services.AddScoped<IOrderKoiService, OrderKoiService>();

builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderTripRepo, OrderTripRepo>();
builder.Services.AddScoped<IOrderTripService, OrderTripService>();

builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IQuoteRepo, QuoteRepo>();
builder.Services.AddScoped<IQuoteService, QuoteService>();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddDbContext<KoiOrderingSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
