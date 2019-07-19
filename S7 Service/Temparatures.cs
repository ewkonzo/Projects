using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S7_Service
{
    class Temparatures
    {

        S7Entities db = new S7Entities();
        Setup setups;

        public void start()
        {
          Thread  _thread = new Thread(Gettmp);
            _thread.IsBackground = false; // true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();

        }


        public Temparatures()
        {
            try
            {
                setups = db.Setups.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
       public void Gettmp()
        {
            S7.Net.Plc plc;
            try {
               
                while (true)
                {
                    var setup = db.Temp_Setups.ToList();
                    foreach (Temp_Setup item in setup)
                    {
                        plc = connect(item);
                        if (plc.IsConnected)
                        {
                            var bytes = plc.Read(DataType.DataBlock, (int)item.Block_No, (int)item.Startat, (VarType) item.Type, 1);
                            Temparature t = new Temparature();
                            t.Name = item.Name;
                            t.Date = DateTime.Now.Date;
                            t.Time =DateTime.Now;
                            t.Value =Convert.ToDouble( bytes);
                            db.Temparatures.Add(t);
                            db.SaveChanges();
                        }
                    }
                    if (setup != null)
                        System.Threading.Thread.Sleep((int)setups.Pull_interval_Ms );
                }
                
            }
            catch (Exception ex)
            {

            }

        }
        public S7.Net.Plc connect(Temp_Setup item)
        {
            S7.Net.Plc plc= null;
            try
            {
                plc = new S7.Net.Plc(S7.Net.CpuType.S71200, item.Address, (short)item.Rack, (short)item.Slot);
                if (!plc.IsConnected)
                    plc.Open();

            }catch(Exception p)
            { }
            return plc;
        }
        class getdata {

        }

    }
    
}
