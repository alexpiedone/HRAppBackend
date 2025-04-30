using HRApp.Api;
using HRApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("HRApp.Infrastructure")
    )
    .ConfigureWarnings(warnings => 
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
    )
);

builder.Host.ConfigureSerilog(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

InfrastructureServices.AddInfrastructure(builder.Services);

var app = builder.Build();

app.MigrateDatabase();
Utilities.CustomEnrichSerilog(app);

app.UseMiddleware<RequestLoggingMiddleware>();

//Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();
//app.UseAuthentication(); 
app.UseAuthorization();


app.MapControllers(); 

app.Run();
