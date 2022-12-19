namespace low_office
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            //Application.Run(new Departments());
            //Application.Run(new Clients());
            //Application.Run(new lowyers());
            //Application.Run(new legals());
            Application.Run(new login());
        }
    }
}