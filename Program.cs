using hw.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddControllersWithViews();

var app = builder.Build();



app.UseStaticFiles();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=GetMovies}/{id?}");


app.Run();
