using Entity.Data;
using Entity.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

using Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SajidConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=Home}/{id?}");
//dotnet ef database update --project "D:\dotnet\projects\SajidStore\Entity" --startup-project "D:\dotnet\projects\SajidStore\SajidStore"
//dotnet ef migrations add CreateDb --project "D:\dotnet\projects\SajidGithub\SajidStore\Entity" --startup-project "D:\dotnet\projects\SajidGithub\SajidStore\SajidStore"
app.Run();
