using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using OnlineShop.App;
using OnlineShop.App.Mapping;
using OnlineShop.App.Options;
using OnlineShop.Client.Areas.Identity;
using OnlineShop.Client.Data;
using OnlineShop.Domain.Accounts;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Persistence;
using OnlineShop.Persistence.Interfaces;
using OnlineShop.Persistence.Repositories;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("log.txt")
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        sinkOptions: new MSSqlServerSinkOptions { TableName = "ErrorLog" }, restrictedToMinimumLevel:LogEventLevel.Warning)
    .CreateLogger();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Host.UseSerilog(); //
builder.Services.AddMediatR(typeof(Ref).Assembly);

builder.Services.AddScoped<IRepository<Customer>, BaseRepository<Customer>>();
builder.Services.AddScoped<IRepository<Address>, BaseRepository<Address>>();
builder.Services.AddScoped<IRepository<ProductModel>, BaseRepository<ProductModel>>();
builder.Services.AddScoped<IRepository<SalesOrderHeader>, BaseRepository<SalesOrderHeader>>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomersRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//
// builder.Services.AddDefaultIdentity<Account>(options =>
//     {
//         options.SignIn.RequireConfirmedAccount = false;
//         options.SignIn.RequireConfirmedEmail = false;
//         options.SignIn.RequireConfirmedPhoneNumber = false;
//     })
//     .AddEntityFrameworkStores<ShopDbContext>();
//

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.Configure<PagingOptions>(builder.Configuration.GetSection("Paging"));
//
// builder.Host.ConfigureLogging(logging =>
// {
//     logging.ClearProviders();
//     logging.AddConsole();
// });

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<Account>>();
builder.Services.AddDefaultIdentity<Account>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
    })
    //.AddPasswordValidator<Account>()
    .AddEntityFrameworkStores<ShopDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication(); ;

app.Run();

Log.CloseAndFlush();