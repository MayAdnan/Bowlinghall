using System;

namespace Bowlinghall
{
    public class MatchLogger: ILogger
    {
        private static MatchLogger _instance;
        private static readonly object _lock = new object();
        private MatchLogger() { } // Privat konstruktor för Singleton

        public static MatchLogger GetInstance()
        {
            // Tråd-säker instansiering
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new MatchLogger();
                }
                return _instance;
            }
        }

        public void Log(string result)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Match result: {result}");
            Console.ResetColor();
        }
    }
}