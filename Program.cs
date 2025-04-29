using BlazorApp1.Common;
using BlazorApp1.Data;
using BlazorApp1.Data.DbContext;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


// Add DbContext
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")
//    )
//);
// Thêm dịch vụ Global
//GlobalHelper.RegisterServices(builder.Services);

<<<<<<< HEAD
builder.Services.AddSingleton<WeatherForecastService>(); 
builder.Services.AddSingleton<ProductsService>();
=======
builder.Services.AddSingleton<WeatherForecastService>();
>>>>>>> 7e2fb0bff8c1c90ba9839e522a766f0fd0b2bd04

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
// Apply migrations at startup
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    dbContext.Database.Migrate();
//}
app.Run();
