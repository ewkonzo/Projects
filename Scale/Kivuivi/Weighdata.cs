using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Test
{
    public partial class AutoweighEntities
    {
       

        //public  int SaveChanges(Boolean showmessage)
        //{
        //    int s = 0;
        //    try
        //    {                
        //        s = base.SaveChanges();
        //        if (s != 0)
        //            System.Windows.Forms.MessageBox.Show("Changes saved successfully");

        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.Logging.ReportError(ex);

        //    }
        //    return s;
        //}
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
    public partial class Farmer
    {
    }
    public enum usertype
    {
        Admin=0,
        Standard=1
    }
    
}
