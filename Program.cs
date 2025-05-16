using BlazorApp1.Common;
using BlazorApp1.Data;
using BlazorApp1.Data.DbContext;
using BlazorApp1.Services;
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

builder.Services.AddSingleton<ProductsService>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<NewsService>();
builder.Services.AddSingleton<OkrServices>();


builder.Services.AddSingleton(provider =>
{
    var url = "https://upxiewszyidukkcpiyjb.supabase.co";
    var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InVweGlld3N6eWlkdWtrY3BpeWpiIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDU5MTE4NzcsImV4cCI6MjA2MTQ4Nzg3N30.Lvgdur2KxwYfWNuYCOwdNdAHbY6MTBfw_j-qi_x53ng";

    var supabase = new Supabase.Client(url, key);
    supabase.InitializeAsync().Wait();
    return supabase;
});
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
