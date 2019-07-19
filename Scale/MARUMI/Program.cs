﻿using System;
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
            
            string path = "Settings.xml";
            Coffee.settings s = new Coffee.settings().loadsettings(path);
            Logging.Logging.logpath = s.logpath;
            Coffee.client.Db = s.database;
            Coffee.client.Server = s.Serverip;
            Coffee.client.IntegratedSecurity = s.IntegratedSecurity;
            Coffee.client.instance = s.Instance;
            Coffee.client.user = s.Username;
            Coffee.client.password = s.pass;
            Coffee.client.connectedtomain = false;
            var d = new Coffee.coffee();
            Coffee.coffee.Factory_Name = "MARUMI FCS";

            const string appName = "Weigh";
            bool createdNew;
          
            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                return;
            }  

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Coffee.Login());
        }
    }
}