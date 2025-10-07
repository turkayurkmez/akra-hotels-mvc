
using Microsoft.EntityFrameworkCore;
using miniEShop.Application.Services;
using miniEShop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<MiniEShopDbContext>(option => { option.UseSqlServer(connectionString); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

//.net 9.0'da varsayýlandýr. Yani .net 8.0 template'inde bu satýr yok.
app.MapStaticAssets();

//yerine bu satýr var:
// app.UseStaticFiles();




app.MapControllerRoute(
    name: "paginationWithCategory",
    pattern: "Kategori{category}/Sayfa{page}",
    defaults: new { controller = "Home", action = "Index", page = 1 }
    );

app.MapControllerRoute(
    name: "pagination",
    pattern: "Sayfa{page}",
    defaults: new { controller = "Home", action = "Index", page = 1 }
    );



//page olarak kullandýk
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets(); // Buradaki WithStaticAssets chaining Method da .net 9.0'a özel



app.Run();
