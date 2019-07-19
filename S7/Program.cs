using S7.Net;
using System;

namespace S7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                S7.Net.Plc plc = new S7.Net.Plc(CpuType.S71200, "192.168.0.1", 0, 1);
                // open the plc S7300-type
                plc.Open();
                // set bit 0 in marker-byte 20
                var bytes = plc.Read(DataType.DataBlock, 2, 0, VarType.Real, 1);
                var bytess = plc.Read(DataType.DataBlock, 2, 4, VarType.Real, 1);
                var d = plc.Read("MD22");
                // read the word-value in DataBlock 100 Word-Position 40
                UInt16 b1 = (UInt16)plc.Read("DB100.DBW40");
                // close the plc
                plc.Close();
            }
            catch (S7.Net.PlcException d)
            {
                var s = d.Data;
            }
        }
    }
}
