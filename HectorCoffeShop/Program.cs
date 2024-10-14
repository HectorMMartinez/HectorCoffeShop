using Microsoft.EntityFrameworkCore;
using HectorCoffeShop.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<HectorCoffeShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// Añadir servicios de controladores con vistas
builder.Services.AddControllersWithViews();

// Añadir servicios de autenticación y autorización (opcional si los usas)
builder.Services.AddAuthentication("CookieAuth") // Ejemplo de autenticación por cookies
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Home/Privacy"; // Ruta de ejemplo para login
    });

builder.Services.AddAuthorization(); // Agregar servicios de autorización

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middleware de autenticación y autorización
app.UseAuthentication();  // Asegúrate de que este esté antes de UseAuthorization()
app.UseAuthorization();

 app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
