using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<PackageService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventPackageRepository, EventPackageRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();

var app = builder.Build();

app.UseCors(options =>
{
  options.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
});

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
