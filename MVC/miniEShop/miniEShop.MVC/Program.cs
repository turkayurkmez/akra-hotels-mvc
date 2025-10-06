var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//.net 9.0'da varsay�land�r. Yani .net 8.0 template'inde bu sat�r yok.
app.MapStaticAssets();

//yerine bu sat�r var:
// app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{page?}")
    .WithStaticAssets(); // Buradaki WithStaticAssets chaining Method da .net 9.0'a �zel


app.Run();
