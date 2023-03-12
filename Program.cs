using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectForm());

            if(DatabaseSingleton.status == DatabaseSingleton.Status.Success)
            {
                Application.Run(new DEFUForm());
            }
        }
    }
}
