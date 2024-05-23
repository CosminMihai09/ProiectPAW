using ProiectPAW.Data;
using System.Data.Entity;

namespace ProiectPAW
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LoanContext>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}