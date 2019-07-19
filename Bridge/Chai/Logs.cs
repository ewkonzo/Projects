using System;

namespace Server
{
    static class Logs
    {
        public static string ValidateEntry(string Entry)
        {
            string r = Entry;
            try
            {
                string s = "'";//sql illegal entry characters

                Entry = Entry.Trim();

                foreach (char c in s.ToCharArray())
                    Entry = Entry.Replace(c.ToString(), "'" + c.ToString());

                r = Entry;
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }
            return r;
        }

        public static string TitleCase(string sentence)
        {
            try
            {
                string[] s = sentence.Split(" ".ToCharArray());

                sentence = "";

                foreach (string s2 in s)
                    sentence +=
                        s2.Substring(0, 1).ToUpper() +
                        s2.Substring(1).ToLower() + " ";
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }

            return sentence.Trim();
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
                Logs.ReportError(ex);
            }
            return b;
        }

        public static string FormatNumber(double Number2Format)
        {
            return FormatNumber(Number2Format.ToString());
        }

        public static string FormatNumber(string Number2Format)
        {
            if (Number2Format.Contains("(") || Number2Format.Contains(")"))
                Number2Format = Number2Format.Substring(1, Number2Format.Length - 2);

            double d = Convert.ToDouble(Number2Format);//remove non-numeric characters

            string s = d.ToString();//revert to string

            string wholeNumber = "";
            string decimalPoint = "";

            bool negativeNumber = Number2Format.ToString().Contains("-");

            if (negativeNumber)
                s = s.Substring(1);

            try
            {
                int i, j, k;

                if (s.Contains(".") == false)
                    s += ".00";

                i = s.IndexOf(".");

                decimalPoint = s.Substring(i + 1);

                if (decimalPoint.Length == 1)
                    decimalPoint = decimalPoint + "0";
                else if (decimalPoint.Length > 2)
                    decimalPoint = decimalPoint.Substring(0, 2);

                k = 0;
                for (j = (i - 1); j >= 0; j--)
                {
                    wholeNumber = s.Substring(j, 1) + wholeNumber;

                    k++;
                    if (k == 3)
                    {
                        k = 0;

                        if (j > 0) wholeNumber = "," + wholeNumber;
                    }
                }
            }
            catch (Exception ex)
            {

                Logs.ReportError(ex);
            }

            if (negativeNumber) s = "(" + wholeNumber + "." + decimalPoint + ")";
            else s = wholeNumber + "." + decimalPoint;

            return s;
        }

        public static string FormatDate(DateTime Date2Format)
        {
            string s = "";

            try
            {
                Date2Format = Date2Format.AddHours(-3);
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

                s = y + m + d + " " + hr + ":" + mn + ":" + sc;
            }
            catch (Exception ex)
            {

                Logs.ReportError(ex);
            }

            return s;
        }

        public static string FormatDateWithoutSymbols(DateTime Date2Format)
        {
            string s = "";

            try
            {
                string y, m, d, hr, mn, sc;

                y = Date2Format.Year.ToString().Substring(2, 2);

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

                s = y + m + d + hr + mn + sc;
            }
            catch (Exception ex)
            {

                Logs.ReportError(ex);
            }

            return s;
        }

        public static string FormatDate(DateTime Date2Format, bool excludeTime)
        {
            string s = "";

            try
            {
                string y, m, d;

                y = Date2Format.Year.ToString();

                m = Date2Format.Month.ToString();
                if (m.Length == 1) m = "0" + m;

                d = Date2Format.Day.ToString();
                if (d.Length == 1) d = "0" + d;

                if (excludeTime)
                    s = y + m + d;
                else
                    s = FormatDate(Date2Format);
            }
            catch (Exception ex)
            {

                Logs.ReportError(ex);
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

                Logs.ReportError(ex);
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

                Logs.ReportError(ex);
            }

            return s;
        }

        public static int FormatDateDifference(string Number2Format)
        {
            int str = 0;

            try
            {
                if (Number2Format.Contains("."))
                    str = Convert.ToInt32(Number2Format.Substring(0, (Number2Format.IndexOf("."))));
            }
            catch (Exception ex)
            {

                Logs.ReportError(ex);
            }
            //str = str * (1000 * 60 * 60 * 24);//convert to days (default is milli-seconds).

            return str;
        }

        public static string LogFileName
        {
            get
            {
                if (!System.IO.Directory.Exists(@"C:\ATM Logs"))
                    System.IO.Directory.CreateDirectory(@"C:\ATM Logs");
                return @"C:\ATM Logs\ATM Logs - " + DateToday3 + ".txt";
            }
        }

        private static string DateToday3
        {
            get
            {
                string dateToday = "";

                try
                {
                    string y, m, d;

                    y = DateTime.Now.Year.ToString();

                    m = DateTime.Now.Month.ToString();

                    if (m.Length == 1)
                        m = "0" + m;

                    d = DateTime.Now.Day.ToString();

                    if (d.Length == 1)
                        d = "0" + d;

                    dateToday = y + "-" + m + "-" + d;
                }
                catch (Exception ex)
                {
                    Logs.ReportError(ex);
                }
                return dateToday;
            }
        }
        public static void ReportError(Exception ex)
        {
            LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Message));
            if (ex.InnerException != null)
            {
                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.InnerException.Message));
            }
            LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.StackTrace));
            LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Source));
        }
        public static void LogEntryOnFile(string clientRequest)
        {
            try
            {
                if (!System.IO.File.Exists(LogFileName)) System.IO.File.Create(LogFileName);

                System.IO.File.AppendAllText(LogFileName, DateTime.Now + ":" + clientRequest + @"\");
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }
        }

       

    }
}