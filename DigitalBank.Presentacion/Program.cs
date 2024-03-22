using Microsoft.EntityFrameworkCore;
using DigitalBank.Datos.DataContext;
using DigitalBank.Datos.Respositories;
using DigitalBank.Modelos;
using DigitalBank.Negocio.Service;
using DigitalBank.Negocio.ServiceWFC;
using Microsoft.AspNetCore.Hosting;
using DigitalBank.Presentacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DigitalBankContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings"));
});

//builder.Services.AddScoped<IGenericRepository<Usuario>, UsuarioRepository>();
//builder.Services.AddScoped<IUsuarioService, UsuarioService>();

Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
