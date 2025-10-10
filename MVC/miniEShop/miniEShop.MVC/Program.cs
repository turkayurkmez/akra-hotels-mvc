
using Microsoft.EntityFrameworkCore;
using miniEShop.Application.Contracts;
using miniEShop.Application.Services;
using miniEShop.Infrastructure.Data;
using miniEShop.Infrastructure.Repositories;
using miniEShop.MVC.Extensions;
using miniEShop.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    opt.CacheProfiles.Add("Default45", new CacheProfile { Duration = 45 });
});
                



var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDatabaseResources(connectionString);



builder.Services.AddSession(option =>
{
    //Session'un boþta geçen süresi: 20 dakika olarak ayarlandý:
    option.IdleTimeout = TimeSpan.FromMinutes(20);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Users/Login"; //Accounts/Login
                    option.ReturnUrlParameter = "gidilecekUrl";//returnUrl
                    option.AccessDeniedPath = "/Users/AccessDenied"; //Accounts/AccessDenied
                    option.ExpireTimeSpan = TimeSpan.FromHours(8); //24 
                    option.SlidingExpiration = true; // false
                    option.Cookie.Name = "MyDomainCookieAuth"; //Encoding-Random
                    option.Cookie.HttpOnly = true; // false
                    option.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; //None
                });

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("Admin", "Editor");
    });

    option.AddPolicy("Client", policy => policy.RequireRole("Client","Admin","Editor"));
});


builder.Services.AddMemoryCache();


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

app.UseSession();

app.UseAuthentication();
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
