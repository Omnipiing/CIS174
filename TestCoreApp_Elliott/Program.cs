using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestCoreApp_Elliott.Models;
using TestCoreApp_Elliott.Models.OlympicGames;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OlympicsContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("CountryContext")));

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
	name: "olympics",
	pattern: "Olympics/{controller=Olympics}/{action=Index}/cat/{activeCat}/game/{activeGame}");

app.MapControllerRoute(
    name: "assignment",
    pattern: "Assignment/{controller=Assignment6_1}/{action=Assignment6_1}/{accessLevel?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
