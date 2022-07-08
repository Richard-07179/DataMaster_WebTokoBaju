using Microsoft.EntityFrameworkCore;
using WebTokoBaju.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Set connection string
var conString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MysqlDBContext>(options => options.UseMySql(conString, ServerVersion.AutoDetect(conString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
