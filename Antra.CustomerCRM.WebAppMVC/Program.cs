using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Infrastructure.Data;
using CustomerCRM.Infrastructure.Repository;
using CustomerCRM.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddScoped<IRegionRepositoryAsync, RegionRepositoryAsync>();
builder.Services.AddScoped<IRegionServiceAsync, RegionServiceAsync>();

builder.Services.AddSqlServer<CustomerCrmDbContext>(builder.Configuration.GetConnectionString("CustomerCRM"));
/*
builder.Services.AddDbContext<CustomerCrmDbContext>(
    option => {
        option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerCRM"));
    }
    );
*/


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
