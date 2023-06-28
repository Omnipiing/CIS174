using Microsoft.EntityFrameworkCore;
using MDPwebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DI
builder.Services.AddDbContext<RequestContext>(options =>
     options.UseSqlServer(
         builder.Configuration.GetConnectionString("RequestContext")));

// update the URLs to be lowercase and have a trailing slash
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

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

// default router for the Admin Area
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

// default router for the Approver Area
app.MapAreaControllerRoute(
    name: "approver",
    areaName: "Approver",
    pattern: "approver/{controller=Home}/{action=Index}/{id?}");

// alternate default route for the Requestor
app.MapControllerRoute(
    name: "materialRoute",
    pattern: "{controller=Home}/{action=Index}/request/{id?}/material/{slug?}");

// default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
