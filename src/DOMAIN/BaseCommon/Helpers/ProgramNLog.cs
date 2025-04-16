using NLog.Config;
using NLog.Targets;
using LogLevel = NLog.LogLevel;

namespace MenphisSI.WebApi.BaseCommon.Helpers;

public static class ProgramNLog
{
    public static Logger ConfigureNLog()
    {
        var logDirectory = Path.Combine(AppContext.BaseDirectory, "logs");

        var logConfig = new LoggingConfiguration();
        logConfig.AddRule(LogLevel.Error, LogLevel.Fatal, new FileTarget("logfile") { FileName = Path.Combine(logDirectory, $"logError{DateTime.Now.Date:yyyy-MM-dd}.log") });
        logConfig.AddRule(LogLevel.Info, LogLevel.Warn, new FileTarget("logfile") { FileName = Path.Combine(logDirectory, $"logInfo{DateTime.Now.Date:yyyy-MM-dd}.log") });


        LogManager.Configuration = logConfig;
        var logger = LogManager.GetCurrentClassLogger();
        return logger;
    }

    public static Logger ConfigureHealthCheckNLog()
    {
        var config = new LoggingConfiguration();
        var logfile = new FileTarget("logfile")
        {
            FileName = "${when:when='${date:format=HH}'=='00':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_00}" +
                      "${when:when='${date:format=HH}'=='01':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_00}" +
                      "${when:when='${date:format=HH}'=='02':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_00}" +
                      "${when:when='${date:format=HH}'=='03':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_03}" +
                      "${when:when='${date:format=HH}'=='04':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_03}" +
                      "${when:when='${date:format=HH}'=='05':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_03}" +
                      "${when:when='${date:format=HH}'=='06':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_06}" +
                      "${when:when='${date:format=HH}'=='07':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_06}" +
                      "${when:when='${date:format=HH}'=='08':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_06}" +
                      "${when:when='${date:format=HH}'=='09':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_09}" +
                      "${when:when='${date:format=HH}'=='10':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_09}" +
                      "${when:when='${date:format=HH}'=='11':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_09}" +
                      "${when:when='${date:format=HH}'=='12':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_12}" +
                      "${when:when='${date:format=HH}'=='13':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_12}" +
                      "${when:when='${date:format=HH}'=='14':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_12}" +
                      "${when:when='${date:format=HH}'=='15':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_15}" +
                      "${when:when='${date:format=HH}'=='16':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_15}" +
                      "${when:when='${date:format=HH}'=='17':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_15}" +
                      "${when:when='${date:format=HH}'=='18':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_18}" +
                      "${when:when='${date:format=HH}'=='19':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_18}" +
                      "${when:when='${date:format=HH}'=='20':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_18}" +
                      "${when:when='${date:format=HH}'=='21':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_21}" +
                      "${when:when='${date:format=HH}'=='22':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_21}" +
                      "${when:when='${date:format=HH}'=='23':inner=logs/logFileHealthCheck${date:format=yyyy-MM-dd}_21}.log",
            Layout = "${longdate} ${uppercase:${level}} ${message} ${exception:format=ToString}",
            ArchiveFileName = "logs/archive/logFileHealthCheck_{#}.log",
            ArchiveEvery = FileArchivePeriod.Day,
            ArchiveNumbering = ArchiveNumberingMode.Date,
            MaxArchiveFiles = 7, // Mantém logs por 7 dias
            ArchiveOldFileOnStartup = true,
            CreateDirs = true,
            ConcurrentWrites = true,
            KeepFileOpen = false
        };

        config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);
        LogManager.Configuration = config;
        return LogManager.GetCurrentClassLogger();
    }
}
