using hw.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


var app = builder.Build();


app.UseSession();
app.UseStaticFiles();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=GetMovies}/{id?}");


app.Run();
