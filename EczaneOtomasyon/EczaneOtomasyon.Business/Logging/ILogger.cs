using System;

namespace EczaneOtomasyon.Business.Logging
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Critical
    }

    public interface ILogger
    {
        void Log(string message, LogLevel level = LogLevel.Info);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception? exception = null);
        void LogCritical(string message, Exception? exception = null);
    }
}

