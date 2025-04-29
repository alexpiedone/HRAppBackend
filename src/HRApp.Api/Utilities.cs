using HRApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;
using System.Collections.ObjectModel;
using System.Data;
using Serilog.Context;
using System.Security.Claims;
using System;

namespace HRApp.Api;

public static class Utilities
{
    public static void RunAutoMigration(IServiceProvider serviceProvider)
    {
        var migrationName = $"AutoMigration_{DateTime.Now:yyyyMMdd_HHmmss}";
        var outputDir = "TempMigrations";

        var solutionDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../"));

        var infraProjectPath = Path.Combine(solutionDirectory, "HRApp.Infrastructure", "HRApp.Infrastructure.csproj");
        var apiProjectPath = Path.Combine(solutionDirectory, "HRApp.Api", "HRApp.Api.csproj");
        Console.WriteLine("Building projects...");

        bool BuildProject(string projectPath)
        {
            var buildProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"build \"{projectPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            buildProcess.Start();
            string output = buildProcess.StandardOutput.ReadToEnd();
            string error = buildProcess.StandardError.ReadToEnd();
            buildProcess.WaitForExit();

            Console.WriteLine(output);
            if (!string.IsNullOrWhiteSpace(error))
            {
                Console.WriteLine("Build Error:\n" + error);
            }

            return buildProcess.ExitCode == 0;
        }

        if (!BuildProject(infraProjectPath) || !BuildProject(apiProjectPath))
        {
            Console.WriteLine("Build failed. Migration aborted.");
            return;
        }

        var migrationCmd = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"ef migrations add {migrationName} --project \"{infraProjectPath}\" --startup-project \"{apiProjectPath}\" --output-dir {outputDir}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = Process.Start(migrationCmd))
        {
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrWhiteSpace(error))
            {
                Console.WriteLine(" EF Error:\n" + error);
            }
            else
            {
                Console.WriteLine(output);
            }
        }

        Console.WriteLine("Applying migration to database...");

        using (var scope = serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }

        Console.WriteLine(" Auto-migration completed.");
    }

    public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        return hostBuilder.UseSerilog((context, services, loggerConfiguration) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            loggerConfiguration
                .ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", "HRApp")
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentName()
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .WriteTo.MSSqlServer(
                    connectionString: connectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",
                        AutoCreateSqlTable = true,
                        SchemaName = "dbo",
                        BatchPostingLimit = 1000,
                        BatchPeriod = TimeSpan.FromSeconds(5)
                    },
                    columnOptions: GetColumnOptions(),
                    restrictedToMinimumLevel: LogEventLevel.Warning);

            loggerConfiguration.WriteTo.Logger(subLc => subLc
                    .WriteTo.Console()
                    .Filter.ByIncludingOnly(logEvent => 
                        logEvent.MessageTemplate.Text.StartsWith("HTTP_REQUEST"))
                    .WriteTo.MSSqlServer(
                        connectionString: connectionString,
                        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = false },
                        columnOptions: GetColumnOptions(),
                        restrictedToMinimumLevel: LogEventLevel.Information
                    )
                );
        });
    }

    public static IApplicationBuilder CustomEnrichSerilog(this IApplicationBuilder app)
    {
        return app.Use(async (context, next) =>
        {
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "anonymous";
            LogContext.PushProperty("UserId", userId);
            LogContext.PushProperty("RequestPath", context.Request.Path.Value ?? "unknown");
            LogContext.PushProperty("HttpMethod", context.Request.Method);

            var correlationId = context.TraceIdentifier;
            LogContext.PushProperty("CorrelationId", correlationId);

            var sw = Stopwatch.StartNew();
            await next.Invoke();
            sw.Stop();
            LogContext.PushProperty("ElapsedMs", sw.Elapsed.TotalMilliseconds);
        });
    }

    private static ColumnOptions GetColumnOptions()
    {
        var columnOptions = new ColumnOptions
        {
            AdditionalColumns = new Collection<SqlColumn>
        {
            new("ApplicationName", SqlDbType.NVarChar, true, 50),
            new("MachineName", SqlDbType.NVarChar, true, 50),
            new("UserId", SqlDbType.NVarChar, true, 50),
            new("RequestPath", SqlDbType.NVarChar, true, 512),
            new("HttpMethod", SqlDbType.NVarChar, true, 16),
            new("Environment", SqlDbType.NVarChar, true, 50),
            new("CorrelationId", SqlDbType.NVarChar, true, 128),
            new("ElapsedMs", SqlDbType.Float)
        }
        };

        columnOptions.Store.Remove(StandardColumn.Properties);
        columnOptions.Store.Remove(StandardColumn.MessageTemplate);

        return columnOptions;
    }

}
