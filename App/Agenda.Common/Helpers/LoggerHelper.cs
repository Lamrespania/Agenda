namespace Agenda.Common.Helpers;

public static class LoggerHelper
{
    /// <summary>
    /// Configure Serilog from appsettings.json.
    /// </summary>
    public static void ConfigureLogger(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();
    }

    /// <summary>
    /// Configure Serilog manually.
    /// </summary>
    public static void ConfigureLogger(this ServiceCollection services, string logName, int logDaysDuration)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .MinimumLevel.Override("Agenda", LogEventLevel.Information)
            .WriteTo.Console()
            .WriteTo.File(
                path: Path.Combine("..", "logs", $"{logName}-.log"),
                rollingInterval: RollingInterval.Day,
                retainedFileTimeLimit: TimeSpan.FromDays(logDaysDuration),
                retainedFileCountLimit: null)
            .CreateLogger();

        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog();
        });
    }
}