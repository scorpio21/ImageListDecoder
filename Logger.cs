using System;
using System.IO;

namespace ImageListDecoder
{
    public static class Logger
    {
        private static string _logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");

        public static void Log(string message, Exception ex = null)
        {
            try
            {
                string logContent = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}\n";
                if (ex != null)
                {
                    logContent += $"Excepción: {ex.GetType().Name}\n";
                    logContent += $"Mensaje: {ex.Message}\n";
                    logContent += $"StackTrace: {ex.StackTrace}\n";
                }
                logContent += new string('-', 50) + "\n";

                File.AppendAllText(_logPath, logContent);
            }
            catch
            {
                // Si falla el log, no queremos que la app se cierre
            }
        }
    }
}
