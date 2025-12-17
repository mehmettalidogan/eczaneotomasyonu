using System;
using System.IO;

namespace EczaneOtomasyon.Business.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;
        private readonly object _lockObject = new object();

        public FileLogger()
        {
            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            _logFilePath = Path.Combine(logDirectory, $"eczane_{DateTime.Now:yyyyMMdd}.log");
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            lock (_lockObject)
            {
                try
                {
                    var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                    File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
                }
                catch
                {
                    // Logging hatalarını sessizce görmezden gel
                }
            }
        }

        public void LogInfo(string message)
        {
            Log(message, LogLevel.Info);
        }

        public void LogWarning(string message)
        {
            Log(message, LogLevel.Warning);
        }

        public void LogError(string message, Exception? exception = null)
        {
            var fullMessage = exception != null 
                ? $"{message} | Exception: {exception.Message} | StackTrace: {exception.StackTrace}"
                : message;
            Log(fullMessage, LogLevel.Error);
        }

        public void LogCritical(string message, Exception? exception = null)
        {
            var fullMessage = exception != null 
                ? $"{message} | Exception: {exception.Message} | StackTrace: {exception.StackTrace}"
                : message;
            Log(fullMessage, LogLevel.Critical);
        }
    }
}

