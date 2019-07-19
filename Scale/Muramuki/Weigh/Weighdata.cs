using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Weigh
{
    public partial class AutoweighEntities
    {
        public static AutoweighEntities Db = new AutoweighEntities();
        public static Setting setup = Db.Settings.FirstOrDefault();
        public static User user = null;
        public static string Factory_Name;
        
       
        public  int SaveChanges(Boolean showmessage)
        {
            int s = 0;
            try
            {                
                s = base.SaveChanges();
                if (s != 0)
                    System.Windows.Forms.MessageBox.Show("Changes saved successfully");

            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

            }
            return s;
        }
        public static string GetMd5Hash(string input)
        {
            StringBuilder sBuilder = new StringBuilder();
            try
            {
                MD5 md5Hash = MD5.Create();

                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex); }
            return sBuilder.ToString();
        }
    }
    public enum usertype
    {
        Admin=0,
        Standard=1
    }
    public class Serial
    {    public static SerialPort mySerialPort = new SerialPort();
        public static SerialPort serial()
        {
            try
            {
                var settings = AutoweighEntities.Db.Settings.FirstOrDefault();
                if (!String.IsNullOrEmpty(settings.Com_Port)) { 
                mySerialPort.PortName = settings.Com_Port;
                mySerialPort.BaudRate = (int)settings.BaudRate;// 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.RtsEnable = true;
                mySerialPort.Open();
            }
            }catch(Exception ex) { Logging.Logging.ReportError(ex);
                throw;
            }
            return mySerialPort;
        }
    }
}
