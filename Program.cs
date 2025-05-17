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
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
        options.EnableDetailedErrors = true;
    });


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
    var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
    var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");

    if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
    {
        throw new Exception("Thiếu biến môi trường SUPABASE_URL hoặc SUPABASE_KEY");
    }

    var supabase = new Supabase.Client(supabaseUrl, supabaseKey);
    supabase.InitializeAsync().Wait();
    return supabase;
});
builder.Services.AddResponseCaching();

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
app.UseResponseCaching();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
// Apply migrations at startup
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    dbContext.Database.Migrate();
//}
app.Run();
