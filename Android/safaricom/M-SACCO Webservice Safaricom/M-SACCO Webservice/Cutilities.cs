using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;

namespace M_SACCO_Webservice
{
    class CUtilities
    {
      static Collection<string> logs = new Collection<string>();

       public  static string logpath;
        private CUtilities()
        {
        }
        public static string ValidateEntry(string Entry)
        {
            string r = Entry;
            try
            {
                if (Entry.Length > 250) Entry = Entry.Substring(1, 250);

                string s = "'";//sql illegal entry characters

                Entry = Entry.Trim();

                foreach (char c in s.ToCharArray())
                    Entry = Entry.Replace(c.ToString(), "'" + c.ToString());

                r = Entry;
            }
            catch (Exception ex)
            {

            }
            return r;
        }
        public static string ddMMyyyy(DateTime dt)
        {
             string s = "";
             s = dt.Day.ToString().PadLeft(2, '0') + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Year.ToString();
             return s;
        }
        public static string FormatDate(DateTime Date2Format)
        {
            string s = "";

            try
            {
                string y, m, d, hr, mn, sc;

                y = Date2Format.Year.ToString();

                m = Date2Format.Month.ToString();
                if (m.Length == 1) m = "0" + m;

                d = Date2Format.Day.ToString();
                if (d.Length == 1) d = "0" + d;

                hr = Date2Format.Hour.ToString();
                if (hr.Length == 1) hr = "0" + hr;

                mn = Date2Format.Minute.ToString();
                if (mn.Length == 1) mn = "0" + mn;

                sc = Date2Format.Second.ToString();
                if (sc.Length == 1) sc = "0" + sc;

                s = String.Format("{0}-{1}-{2} {3}:{4}:{5}", y, m, d, hr, mn, sc);
            }
            catch (Exception ex)
            {

            }

            return s;
        }
        public static string FormatDate(object Date2Format)
        {
            string s = "";

            try
            {
                s = FormatDate((DateTime)Date2Format);
            }
            catch (Exception ex)
            {

            }

            return s;
        }
        public static string ValidateDate(string dateString)
        {
            try
            {
                if (dateString.Trim().Length > 0)
                {
                    dateString = FormatDate(Convert.ToDateTime(dateString));

                    if (Convert.ToDateTime(dateString) < Convert.ToDateTime("1900-01-01"))
                        dateString = Convert.ToDateTime("1900-01-01").ToShortDateString();
                }
                else
                    dateString = Convert.ToDateTime("1900-01-01").ToShortDateString();
            }
            catch (Exception ex)
            {

                dateString = Convert.ToDateTime("1900-01-01").ToShortDateString();
            }
            return dateString;
        }
        public static bool IsNumberValid(string number)
        {

            bool b = false;
            try
            {
                double d = Convert.ToDouble(number);
                b = true;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return b;
        }



        public static string FormatNumber(string Number2Format)
        {
            if (Number2Format.Contains("(") || Number2Format.Contains(")"))
            {
                Number2Format = Number2Format.Substring(1, Number2Format.Length - 2);
            }

            double d = Convert.ToDouble(Number2Format);
            //remove non-numeric characters
            string s = d.ToString();
            //revert to string
            string wholeNumber = "";
            string decimalPoint = "";

            bool negativeNumber = Number2Format.ToString().Contains("-");

            if (negativeNumber)
            {
                s = s.Substring(1);
            }

            try
            {
                int i = 0;
                int j = 0;
                int k = 0;

                if (s.Contains(".") == false)
                {
                    s += ".00";
                }

                i = s.IndexOf(".");

                decimalPoint = s.Substring(i + 1);

                if (decimalPoint.Length == 1)
                {
                    decimalPoint = decimalPoint + "0";
                }
                else if (decimalPoint.Length > 2)
                {
                    decimalPoint = decimalPoint.Substring(0, 2);
                }

                k = 0;
                for (j = (i - 1); j >= 0; j += -1)
                {
                    wholeNumber = s.Substring(j, 1) + wholeNumber;

                    k += 1;
                    if (k == 3)
                    {
                        k = 0;

                        if (j > 0)
                        {
                            wholeNumber = "," + wholeNumber;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            if (negativeNumber)
            {
                s = "(" + wholeNumber + "." + decimalPoint + ")";
            }
            else
            {
                s = wholeNumber + "." + decimalPoint;
            }

            return s;
        }

        public static string FormahtDate(DateTime Date2Format)//mm/dd/yyyy
        {
            string s = "";


            string y = null;
            string m = null;
            string d = null;
            y = Date2Format.Year.ToString();
            m = Date2Format.Month.ToString();
            d = Date2Format.Day.ToString();
            s = m + "/" + d + "/" + y;



            return s;
        }

        public static string FormatDateWithoutSymbols(DateTime Date2Format)
        {
            string s = "";

            try
            {
                string y = null;
                string m = null;
                string d = null;
                string hr = null;
                string mn = null;
                string sc = null;

                y = Date2Format.Year.ToString().Substring(2, 2);

                m = Date2Format.Month.ToString();
                if (m.Length == 1)
                {
                    m = "0" + m;
                }

                d = Date2Format.Day.ToString();
                if (d.Length == 1)
                {
                    d = "0" + d;
                }

                hr = Date2Format.Hour.ToString();
                if (hr.Length == 1)
                {
                    hr = "0" + hr;
                }

                mn = Date2Format.Minute.ToString();
                if (mn.Length == 1)
                {
                    mn = "0" + mn;
                }

                sc = Date2Format.Second.ToString();
                if (sc.Length == 1)
                {
                    sc = "0" + sc;
                }

                s = y + m + d + hr + mn + sc;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }

        public static string FormatDate(DateTime Date2Format, bool excludeTime)
        {
            string s = "";

            try
            {
                string y = null;
                string m = null;
                string d = null;

                y = Date2Format.Year.ToString();

                m = Date2Format.Month.ToString();
                if (m.Length == 1)
                {
                    m = "0" + m;
                }

                d = Date2Format.Day.ToString();
                if (d.Length == 1)
                {
                    d = "0" + d;
                }

                if (excludeTime)
                {
                    s = y + m + d;
                }
                else
                {
                    s = FormatDate(Date2Format);
                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }
        public static string FDate(DateTime Date2Format)
        {
            string s = "";

            try
            {
                string y = null;
                string m = null;
                string d = null;

                y = Date2Format.Year.ToString();

                m = Date2Format.Month.ToString();
                if (m.Length == 1)
                {
                    m = "0" + m;
                }

                d = Date2Format.Day.ToString();
                if (d.Length == 1)
                {
                    d = "0" + d;
                }


                s = d + "-" + m + "-" + y;



            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }


        public static string FormatDate(object Date2Format, bool excludeTime)
        {
            string s = "";

            try
            {
                s = FormatDate((DateTime)Date2Format, true);

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }

        public static int FormatDateDifference(string Number2Format)
        {
            int str = 0;

            try
            {
                if (Number2Format.Contains("."))
                {
                    str = Convert.ToInt32(Number2Format.Substring(0, (Number2Format.IndexOf("."))));
                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            //str = str * (1000 * 60 * 60 * 24);//convert to days (default is milli-seconds).

            return str;
        }

        public static string LogFileName
        {
            get
            {
                if (!Directory.Exists(logpath ))
                    Directory.CreateDirectory(logpath);
                return logpath  + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            }
        }

        private static string DateToday3
        {
            get
            {
                string dateToday = "";

                try
                {
                    string y = null;
                    string m = null;
                    string d = null;

                    y = DateTime.Now.Year.ToString();

                    m = DateTime.Now.Month.ToString();

                    if (m.Length == 1)
                    {
                        m = "0" + m;
                    }

                    d = DateTime.Now.Day.ToString();

                    if (d.Length == 1)
                    {
                        d = "0" + d;
                    }

                    dateToday = y + "-" + m + "-" + d;
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                return dateToday;
            }
        }
        static AutoResetEvent ar = new AutoResetEvent(false);
        public static void LogEntryOnFile(string clientRequest)
        {

            File.AppendAllText(LogFileName, clientRequest + "\n");

        }

    }
}

