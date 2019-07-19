using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        private static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Logging.Logging.logpath = @"C:\Logs\";
                Coffee.client.Db = "Autoweigh";
                Coffee.client.Server = ".";
                Coffee.client.IntegratedSecurity = true;
                Coffee.client.instance = "SQLEXPRESS";
                Coffee.client.IntegratedSecurity = false;
                Coffee.client.user = "Autoweigh";
                Coffee.client.password = "Mbanking12345*";
                var d = new Coffee.coffee();
                Coffee.coffee.Factory_Name = "MURAMUKI FCS";
                const string appName = "Weigh";
                bool createdNew;

                mutex = new Mutex(true, appName, out createdNew);

                if (!createdNew)
                {
                    //app is already running! Exiting the application  
                    return;
                }
            }
            catch (Exception ex) {
                Logging.Logging.ReportError(ex);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Coffee.Login());
        }
    }
}
