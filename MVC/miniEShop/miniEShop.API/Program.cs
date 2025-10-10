using Microsoft.EntityFrameworkCore;
using miniEShop.Application.Contracts;
using miniEShop.Application.Services;
using miniEShop.Infrastructure.Data;
using miniEShop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

/*
 * A�a��daki gibi copy-paste yerine; MVC projesinde yer alan ExtensionMethod �rne�in Common isimli bir class library i�inde yer alabilirdi. Sadece buradan referans al�p ayn� extension method �a�r�labildi.
 */

builder.Services.AddDbContext<MiniEShopDbContext>(option => { option.UseSqlServer(connectionString); });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserSevice, UserService>();

builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
