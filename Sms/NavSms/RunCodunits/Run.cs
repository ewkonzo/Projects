using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunCodunits
{

    class RunThem
    {
       
        private Thread _thread;
        public static bool stop = false;
            public void onstart()
        {
            _thread = new Thread(start);
            _thread.IsBackground = false; // true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        public void start()
        {
            try
            {
                while (stop == false)
                {
                    run.Run();
                }
            }
            catch (Exception)
            {


            }
        }
    }
}
