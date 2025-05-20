using Microsoft.Data.SqlClient;
using HuellitasPaginaWEB.Data;
using HuellitasPaginaWEB.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

Console.WriteLine("Configuración cargada:");
Console.WriteLine($"ConnectionString: {builder.Configuration.GetConnectionString("HuellitasDB")}");

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IServicioEmail, ServicioEmailGmail>();
builder.Services.AddScoped<PerritoRepository>();

// SQL Server
builder.Services.AddTransient<SqlConnection>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var connString = config.GetConnectionString("HuellitasDB");

    if (string.IsNullOrEmpty(connString))
    {
        throw new InvalidOperationException("Connection string 'HuellitasDB' not found in configuration");
    }

    return new SqlConnection(connString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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