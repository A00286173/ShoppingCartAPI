using ShoppingCart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core contexts:
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ShoppingCartDb"));  // using an in-memory database

builder.Services.AddDbContext<AppSecurityDbContext>(options =>
    options.UseInMemoryDatabase("ShoppingCartAuthDb"));  // in-memory database for Identity


builder.Services.AddIdentityApiEndpoints<IdentityUser>()
       .AddEntityFrameworkStores<AppSecurityDbContext>();

//  Add authorization services
builder.Services.AddAuthorization();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();   // enable authentication middleware

app.UseAuthorization();

// Map the built-in Identity minimal API endpoints
app.MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();
