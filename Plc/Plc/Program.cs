using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using S7.Net;

namespace Plc
{
    class Program
    {
        static void Main(string[] args)
        {
            S7.Net.Plc plc = new S7.Net.Plc(CpuType.S71500, "192.168.0.7", 0, 1);
            plc.Open();
            
            if (plc.IsAvailable && plc.IsConnected)
            {
            var d=    plc.Read(DataType.Output, 42, 20,  VarType.StringEx, 16);
               // var c = plc.Read("Trigger");


            }


        }


        
    }
    //public class Plc
    //{
    //    public Plc(CpuType cpu, string ip, Int16 rack, Int16 slot)
    //    { }

    //}
    //public enum CpuType
    //{
    //    S7200 = 0,
    //    S7300 = 10,
    //    S7400 = 20,
    //    S71200 = 30,
    //    S71500 = 40,
    //}
}
