using application.Interfaces;
using Application.Services;
using domain.Interfaces;
using infrastructure.Repositories;
using Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<ISysAdminService, SysAdminService>();
builder.Services.AddScoped<IBookingService, BookingService>();

// Repositories
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<ISysAdminRepository, SysAdminRepository>();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite("Data Source=DB-PPS.db", b => b.MigrationsAssembly("Infrastructure")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
