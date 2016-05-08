using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Belatrix.Utilities
{
    public class JobLogger
    {
        private enum LogType { Message = 1, Warning = 2, Error = 3 }

        public static void LogMessage(string message, bool logToDatabase, bool logToTextfile, bool logToConsole)
        {
            Log(message, LogType.Message, logToDatabase, logToTextfile, logToConsole);
        }

        public static void LogWarning(string message, bool logToDatabase, bool logToTextfile, bool logToConsole)
        {
            Log(message, LogType.Warning, logToDatabase, logToTextfile, logToConsole);
        }

        public static void LogError(string message, bool logToDatabase, bool logToTextfile, bool logToConsole)
        {
            Log(message, LogType.Error, logToDatabase, logToTextfile, logToConsole);
        }

        private static void Log(string message, LogType type, bool logToDatabase, bool logToTextfile, bool logToConsole)
        {
            if (string.IsNullOrEmpty(message)) message = "[Empty message]"; else message.Trim();

            if (logToDatabase) { LogToDatabase(message, type); }

            if (logToTextfile) { LogToTextfile(message, type); }

            if (logToConsole) { LogToConsole(message, type); }
        }

        private static void LogToDatabase(string message, LogType type)
        {
            try
            {
                string cadena = ConfigurationManager.ConnectionStrings["ConnBelatrix"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    using (SqlCommand comando = new SqlCommand("INSERT INTO LOG VALUES('" + message + "', " + ((int)type).ToString() + ")", conexion))
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch
            {
                throw new Exception("Error en la conexión con la base de datos.");
            }
        }

        private static void LogToTextfile(string message, LogType type)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                StringBuilder sb = new StringBuilder();

                if (File.Exists(filePath)) sb.AppendLine(File.ReadAllText(filePath));

                sb.AppendFormat("{0} - {1} : {2}", DateTime.Now.ToString(), Enum.GetName(typeof(LogType), (int)type).ToUpper(), message);

                File.WriteAllText(filePath, sb.ToString());
            }
            catch
            {
                throw new Exception("Error en la ubicación del archivo log de text");
            }
        }

        private static void LogToConsole(string message, LogType type)
        {
            try
            {
                if (LogType.Message == type) { Console.ForegroundColor = ConsoleColor.White; }

                else if (LogType.Warning == type) { Console.ForegroundColor = ConsoleColor.Yellow; }

                else if (LogType.Error == type) { Console.ForegroundColor = ConsoleColor.Red; }

                Console.WriteLine(DateTime.Now.ToShortDateString() + ": " + message);
            }
            catch
            {
                throw new Exception("Error en el registro del Log vía Consola.");
            }
        }
    }
}