using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using Infastructure.Data;
using Infastructure.Repository;
using Infastructure.Services;
using Microsoft.EntityFrameworkCore;
using MovieShop.WebMVC.Utility.CustomMiddleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Log/Exception&Filter.json"
    , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    , shared: true, rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information().WriteTo.File("Log/Exception&Filter.json"
    , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    , shared: true, rollingInterval: RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopApp"));
});
builder.Services.AddScoped<IMovieRepositoryAsync, MovieRepositoryAsync>();
builder.Services.AddScoped<IMovieServiceAsync, MovieServiceAsync>();

builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<IUserServiceAsync, UserServiceAsync>();

builder.Services.AddScoped<ICastRepositoryAsync, CastRepositoryAsync>();
builder.Services.AddScoped<ICastServiceAsync, CastServiceAsync>();

builder.Services.AddScoped<IGenreRepositoryAsync, GenreRepositoryAsync>();
builder.Services.AddScoped<IGenreServiceAsync, GenreServiceAsync>();

builder.Services.AddScoped<IAdminServiceAsync, AdminServiceAsync>();
builder.Services.AddScoped<IAccountServiceAsync, AccountServiceAsync>();

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

app.UseExceptionMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
