namespace timer_winforms
{
    internal static class Program
    {
        public static string pathToSave = "G:\\Projects\\Sharping\\Timer (cons)\\savefiles\\timerhistory.txt";
        public static List<(DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage)> history = new List<(DateTime, DateTime, TimeSpan, string, string, string)>();
        public static string[] fields = new string[6] { "Time started:\t", "Time ended:\t", "Duration:\t", "Field:\t\t", "Subject:\t", "Stage:\t\t" };



        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindowForm());

            
        }
    }
}