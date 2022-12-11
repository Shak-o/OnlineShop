using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.App;
using OnlineShop.App.Mapping;
using OnlineShop.App.Options;
using OnlineShop.Client.Data;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Products;
using OnlineShop.Persistence;
using OnlineShop.Persistence.Interfaces;
using OnlineShop.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddMediatR(typeof(Ref).Assembly);

builder.Services.AddScoped<IRepository<Customer>, BaseRepository<Customer>>();
builder.Services.AddScoped<IRepository<Address>, BaseRepository<Address>>();
builder.Services.AddScoped<IRepository<Product>, BaseRepository<Product>>();

builder.Services.AddScoped<ICustomerRepository, CustomersRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DbContext, ShopDbContext>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.Configure<PagingOptions>(builder.Configuration.GetSection("Paging"));

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
