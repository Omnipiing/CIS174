using Microsoft.EntityFrameworkCore;
using TestCoreApp_Elliott.Models.OlympicGames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OlympicsContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("OlympicsContext")));

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

app.MapAreaControllerRoute(
	name: "olympics",
    areaName: "olympics",
	pattern: "{controller=Olympics}/{action=Index}/cat/{activeCat}/game/{activeGame}");

app.MapControllerRoute(
    name: "assignment",
    pattern: "Assignment/{area=Assignment6_1}/{controller=Assignment6_1}/{action=Assignment6_1}/{accessLevel?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
