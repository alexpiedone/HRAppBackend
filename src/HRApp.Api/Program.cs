using HRApp.Api;
using HRApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("HRApp.Infrastructure")
    )
);

// Register controllers
builder.Services.AddControllers();

// Swagger & OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI pentru Infrastructure
InfrastructureServices.AddInfrastructure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable routing & controller support
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // <- important pentru controller-based API

app.Run();
