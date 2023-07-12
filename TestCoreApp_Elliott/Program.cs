using Microsoft.EntityFrameworkCore;
using TestCoreApp_Elliott.Models.OlympicGames;
using TestCoreApp_Elliott.Areas.ToDoList.Models;

var builder = WebApplication.CreateBuilder(args);

// MUST BE CALLED before AddControllersWithViews
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OlympicsContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("OlympicsContext")));

builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoContext")));

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

// MUST BE CALLED before UseEndpoints
app.UseSession();

// This will catch:
//	https://localhost:7044/Assignment6_1/Assignment6_1/Assignment6_1/
//	https://localhost:7044/Assignment6_1/Assignment6_1/Assignment6_1/9
app.MapControllerRoute(
	name: "assignment61",
	pattern: "{area:exists}/{controller=Assignment6_1}/{action=Assignment6_1}/{accessLevel?}");

// This will catch:
//	https://localhost:7044/olympics/home/index/cat/all/game/all
app.MapControllerRoute(
	name: "olympics",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/cat/{activeCat}/game/{activeGame}");

// This will catch:
//	https://localhost:7044/Olympics
//	https://localhost:7044/Olympics/Home
//	https://localhost:7044/Olympics/Home/Index
app.MapControllerRoute(
	name: "olympicsHome",
	pattern: "{area:exists}/{controller=Home}/{action=Index}");

// This will catch:
//	https://localhost:7044/
//	https://localhost:7044/Home
//	https://localhost:7044/Home/Index
//	https://localhost:7044/Home/Index/1
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
