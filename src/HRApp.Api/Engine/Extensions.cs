namespace HRApp.Api;

public static class Extensions
{
    public static void Log(this ILogger logger, string messageTemplate)
    {
        logger.Log(LogLevel.Information, "cst" + messageTemplate);
    }
}




