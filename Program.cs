using aspNetCoreEscuela.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Conexion Memory Database
// builder.Services.AddDbContext<EscuelaContext>(
//     options => options.UseInMemoryDatabase(databaseName: "testDB")
// );
#endregion

string conString = ConfigurationExtensions.GetConnectionString(builder.Configuration, "AzureConnectionString");

builder.Services.AddDbContext<EscuelaContext>(
    options => options.UseSqlServer(conString)
);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Escuela}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    try
    {
        var context = services.GetRequiredService<EscuelaContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ha ocurrido un error al crear Base de Datos.");
    }
}

app.Run();
