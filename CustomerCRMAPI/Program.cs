using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Entities;
using CustomerCRM.Infrastructure.Data;
using CustomerCRM.Infrastructure.Repository;
using CustomerCRM.Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//repository injection
builder.Services.AddScoped<IRegionRepositoryAsync, RegionRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();



//service injection
builder.Services.AddScoped<IRegionServiceAsync, RegionServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddScoped<IAccountServiceAsync, AccountServiceAsync>();

builder.Services.AddSqlServer<CustomerCrmDbContext>(builder.Configuration.GetConnectionString("CustomerCRM"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<CustomerCrmDbContext>().AddDefaultTokenProviders();
builder.Services.AddCors(options =>{
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin();
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secrete"]))
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
