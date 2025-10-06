var builder = WebApplication.CreateBuilder(args);

//Ben bu uygulamada MVC mimarisini kullanacaðým için gerekli yapýlandýrmayý ve ihtiyacým olan nesneleri builder'a ekliyorum:

builder.Services.AddControllersWithViews();



var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapControllerRoute("default", "{controller=Home}/{action=Index}");


app.Run();
