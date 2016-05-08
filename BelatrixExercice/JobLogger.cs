using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace BelatrixExercice
{
    public class JobLogger
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        private static bool _logToDatabase;
        private bool _initialized; // unused

        public JobLogger()
        {
            _logError = false;
            _logMessage = false;
            _logWarning = false;
            _logToDatabase = false;
            _logToFile = false;
            _logToConsole = false;
        }

        public JobLogger (bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        {
            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;
        }

        public static void LogMessage (string message, bool isMessage, bool isWarning, bool isError)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("The message is empty");
            }

            message.Trim();

            if (!_logToConsole && !_logToFile && !_logToDatabase)
            {
                throw new Exception("Invalid configuration");
            }
            if ((!_logError && !_logMessage && !_logWarning) || (!isMessage && !isWarning && !isError))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }

            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();

            int t = 0;

            if (isMessage && _logMessage)
            {
                t = 1;
            }
            if (isError && _logError)
            {
                t = 2;
            }
            if (isWarning && _logWarning)
            {
                t = 3;
            }

            SqlCommand command = new SqlCommand("Insert into Log Values('" + message + "', " + t.ToString() + ")");
            command.ExecuteNonQuery();
            
            string l = string.Empty;

            if (!File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
            {
                l = File.ReadAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt");
            }

            if (isError && _logError)
            {
                l = l + DateTime.Now.ToShortDateString() + message;
            }
            if (isWarning && _logWarning)
            {
                l = l + DateTime.Now.ToShortDateString() + message;
            }
            if (isMessage && _logMessage)
            {
                l = l + DateTime.Now.ToShortDateString() + message;
            }

            File.WriteAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt", l);

            if (isError && _logError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (isWarning && _logWarning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (isMessage && _logMessage)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}
