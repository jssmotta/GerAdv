namespace MenphisSI.WebApi.BaseCommon.Helpers;
public static class LoggerExtensions
{
    public static void LogInfo(this Logger logger, string tableName, string action, params object[]? args)
    =>
        logger.Info($"{tableName}: {action} called with {(args == null ? "": string.Join(", ", args))}");
    

    public static void LogWarn(this Logger logger, string tableName, string action, params object[]? args)
    =>
        logger.Warn($"{tableName}: {action} - {(args == null ? "": string.Join(", ", args))}");
    

    public static void LogError(this Logger logger, string tableName, string action, params object[]? args)
    =>
        logger.Warn($"{tableName}: {action} - {(args == null ? "" : string.Join(", ", args))}");
    
}