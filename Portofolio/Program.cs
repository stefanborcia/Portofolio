using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Portofolio;
using Portofolio.Data;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration); // My custom startup class.
startup.ConfigureServices(builder.Services); // Add services to the container.


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();
startup.Configure(app, app.Environment); // Configure the HTTP request pipeline.

var connectionString = builder.Configuration.GetConnectionString("AppDb");
//builder.Services.AddDbContext<DbContext>(x => x.UseSqlServer(connectionString)); Connect to Sql Server


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

app.Run();
