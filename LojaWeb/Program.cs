using LojaWeb.Data;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using LojaWeb.Services;
using LojaWeb.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEntityFrameworkMySQL()
    .AddDbContext<VsproContext>(options =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("SmartContext"));
    });
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDepartamentoService, DepartamentoService>();
builder.Services.AddTransient<IVendedorService, VendedorService>();
var app = builder.Build();
//Injeção SeedingService
//Used for seeding database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedingService.Initialize(services);
}
//Injeção Serviços



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
