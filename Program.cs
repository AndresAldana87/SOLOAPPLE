using Microsoft.EntityFrameworkCore;
using ReactVentas.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBREACT_VENTAContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "ClientApp";
        spa.UseReactDevelopmentServer(npmScript: "start");
    });
}

app.UseStaticFiles();
app.UseRouting();



app.MapControllerRoute(
    name: "default",



    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
