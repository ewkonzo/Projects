// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.CUtilities
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace M_SACCO_Webservice
{
  internal class CUtilities
  {
    private static Collection<string> logs = new Collection<string>();
    private static AutoResetEvent ar = new AutoResetEvent(false);
    public static string logpath;

    public static string LogFileName
    {
      get
      {
        if (!Directory.Exists(CUtilities.logpath))
          Directory.CreateDirectory(CUtilities.logpath);
        return CUtilities.logpath + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
      }
    }

    private static string DateToday3
    {
      get
      {
        string str1 = "";
        try
        {
          string str2 = DateTime.Now.Year.ToString();
          string str3 = DateTime.Now.Month.ToString();
          if (str3.Length == 1)
            str3 = "0" + str3;
          string str4 = DateTime.Now.Day.ToString();
          if (str4.Length == 1)
            str4 = "0" + str4;
          str1 = str2 + "-" + str3 + "-" + str4;
        }
        catch (Exception ex)
        {
          ex.Data.Clear();
        }
        return str1;
      }
    }

    private CUtilities()
    {
    }

    public static string ValidateEntry(string Entry)
    {
      string str1 = Entry;
      try
      {
        if (Entry.Length > 250)
          Entry = Entry.Substring(1, 250);
        string str2 = "'";
        Entry = Entry.Trim();
        foreach (char ch in str2.ToCharArray())
          Entry = Entry.Replace(ch.ToString(), "'" + ch.ToString());
        str1 = Entry;
      }
      catch (Exception ex)
      {
      }
      return str1;
    }

    public static string ddMMyyyy(DateTime dt)
    {
      return dt.Day.ToString().PadLeft(2, '0') + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Year.ToString();
    }

    public static string FormatDate(DateTime Date2Format)
    {
      string str1 = "";
      try
      {
        string str2 = Date2Format.Year.ToString();
        string str3 = Date2Format.Month.ToString();
        if (str3.Length == 1)
          str3 = "0" + str3;
        string str4 = Date2Format.Day.ToString();
        if (str4.Length == 1)
          str4 = "0" + str4;
        string str5 = Date2Format.Hour.ToString();
        if (str5.Length == 1)
          str5 = "0" + str5;
        string str6 = Date2Format.Minute.ToString();
        if (str6.Length == 1)
          str6 = "0" + str6;
        string str7 = Date2Format.Second.ToString();
        if (str7.Length == 1)
          str7 = "0" + str7;
        str1 = string.Format("{0}-{1}-{2} {3}:{4}:{5}", (object) str2, (object) str3, (object) str4, (object) str5, (object) str6, (object) str7);
      }
      catch (Exception ex)
      {
      }
      return str1;
    }

    public static string FormatDate(object Date2Format)
    {
      string str = "";
      try
      {
        str = CUtilities.FormatDate((DateTime) Date2Format);
      }
      catch (Exception ex)
      {
      }
      return str;
    }

    public static string ValidateDate(string dateString)
    {
      try
      {
        if (dateString.Trim().Length > 0)
        {
          dateString = CUtilities.FormatDate(Convert.ToDateTime(dateString));
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
      bool flag = false;
      try
      {
        Convert.ToDouble(number);
        flag = true;
      }
      catch (Exception ex)
      {
        ex.Data.Clear();
      }
      return flag;
    }

    public static string FormatNumber(string Number2Format)
    {
      if (Number2Format.Contains("(") || Number2Format.Contains(")"))
        Number2Format = Number2Format.Substring(1, Number2Format.Length - 2);
      string str1 = Convert.ToDouble(Number2Format).ToString();
      string str2 = "";
      string str3 = "";
      bool flag = Number2Format.ToString().Contains("-");
      if (flag)
        str1 = str1.Substring(1);
      try
      {
        if (!str1.Contains("."))
          str1 += ".00";
        int num1 = str1.IndexOf(".");
        str3 = str1.Substring(num1 + 1);
        if (str3.Length == 1)
          str3 += "0";
        else if (str3.Length > 2)
          str3 = str3.Substring(0, 2);
        int num2 = 0;
        int startIndex = num1 - 1;
        while (startIndex >= 0)
        {
          str2 = str1.Substring(startIndex, 1) + str2;
          ++num2;
          if (num2 == 3)
          {
            num2 = 0;
            if (startIndex > 0)
              str2 = "," + str2;
          }
          startIndex += -1;
        }
      }
      catch (Exception ex)
      {
        ex.Data.Clear();
      }
      string str4;
      if (flag)
        str4 = "(" + str2 + "." + str3 + ")";
      else
        str4 = str2 + "." + str3;
      return str4;
    }

    public static string FormahtDate(DateTime Date2Format)
    {
      string str = Date2Format.Year.ToString();
      return Date2Format.Month.ToString() + "/" + Date2Format.Day.ToString() + "/" + str;
    }

    public static string FormatDateWithoutSymbols(DateTime Date2Format)
    {
      string str1 = "";
      try
      {
        string str2 = Date2Format.Year.ToString().Substring(2, 2);
        string str3 = Date2Format.Month.ToString();
        if (str3.Length == 1)
          str3 = "0" + str3;
        string str4 = Date2Format.Day.ToString();
        if (str4.Length == 1)
          str4 = "0" + str4;
        string str5 = Date2Format.Hour.ToString();
        if (str5.Length == 1)
          str5 = "0" + str5;
        string str6 = Date2Format.Minute.ToString();
        if (str6.Length == 1)
          str6 = "0" + str6;
        string str7 = Date2Format.Second.ToString();
        if (str7.Length == 1)
          str7 = "0" + str7;
        str1 = str2 + str3 + str4 + str5 + str6 + str7;
      }
      catch (Exception ex)
      {
        ex.Data.Clear();
      }
      return str1;
    }

    public static string FormatDate(DateTime Date2Format, bool excludeTime)
    {
      string str1 = "";
      try
      {
        string str2 = Date2Format.Year.ToString();
        string str3 = Date2Format.Month.ToString();
        if (str3.Length == 1)
          str3 = "0" + str3;
        string str4 = Date2Format.Day.ToString();
        if (str4.Length == 1)
          str4 = "0" + str4;
        str1 = !excludeTime ? CUtilities.FormatDate(Date2Format) : str2 + str3 + str4;
      }
      catch (Exception ex)
      {
        ex.Data.Clear();
      }
      return str1;
    }

    public static string FDate(DateTime Date2Format)
    {
      string str1 = "";
      try
      {
        string str2 = Date2Format.Year.ToString();
        string str3 = Date2Format.Month.ToString();
        if (str3.Length == 1)
          str3 = "0" + str3;
        string str4 = Date2Format.Day.ToString();
        if (str4.Length == 1)
          str4 = "0" + str4;
        str1 = str4 + "-" + str3 + "-" + str2;
      }
      catch (Exception ex)
      {
        ex.Data.Clear();
      }
      return str1;
    }

    public static string FormatDate(object Date2Format, bool excludeTime)
    {
      string str = "";
      try
      {
        str = CUtilities.FormatDate((DateTime) Date2Format, true);
      }
      catch (Exception ex)
      {
        ex.Data.Clear();
      }
      return str;
    }

    public static int FormatDateDifference(string Number2Format)
    {
      int num = 0;
      try
      {
        if (Number2Format.Contains("."))
          num = Convert.ToInt32(Number2Format.Substring(0, Number2Format.IndexOf(".")));
      }
      catch (Exception ex)
      {
        ex.Data.Clear();
      }
      return num;
    }

    public static void LogEntryOnFile(string clientRequest)
    {
      File.AppendAllText(CUtilities.LogFileName, clientRequest + "\n");
    }
  }
}
