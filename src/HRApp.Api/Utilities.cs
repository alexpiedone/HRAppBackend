using HRApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
}
