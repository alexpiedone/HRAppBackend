using HRApp.Api;
using HRApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("HRApp.Infrastructure")
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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();
    
    dbContext.Database.Migrate(); 
}
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
