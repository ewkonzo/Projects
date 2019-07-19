using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    static class Program
    {
     
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //start s = new start();
            //s.sendsms();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Smss() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
