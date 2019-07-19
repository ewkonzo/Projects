using System;
using System.IO;
using System.Data;
using System.Text;
using System.Web;
using System.Net;
using System.Collections.Generic;
using System.Net.Mail;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Security;
using System.Security.Cryptography;
using System.Threading;
using System.Web.SessionState;

using System.Data.SqlClient;

public static class SiteFunctions
{
    public const int maxLogins = 3;
    
    public static string ConnectionString = string.Empty;// @"Data Source=.\;Initial Catalog='HRIS';User ID=coretec;Password='123Team';Timeout=60";
    
    public static string smtp_server
    {
        get
        {
            string s = string.Empty;

            try
            {
                //HRS.SMTP_Mail_Setup _SMTP_Mail_Setup = new HRS.SMTP_Mail_SetupData().GetSMTP_Mail_Setup();
                //s = _SMTP_Mail_Setup.SMTP_Server;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }
    }

    public static string CurrentUserID
    {
        get
        {
            string d = "";
            try
            {
                d = HttpContext.Current.Session["UserID"].ToString().ToUpper();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        set
        {
            try
            {
                HttpContext.Current.Session["UserID"] = value.ToUpper();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
    }
    public static string CurrentUserSessionID
    {
        get
        {
            string d = "";
            try
            {
                d = HttpContext.Current.Session["UserSessionID"].ToString();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        set
        {
            try
            {
                HttpContext.Current.Session["UserSessionID"] = value;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
    }
    public static int LoginAttempt
    {
        get
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(HttpContext.Current.Session["LoginAttempt"]);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        set
        {
            try
            {
                HttpContext.Current.Session["LoginAttempt"] = value.ToString();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
    }
    public static void SendErrorToDeveloper(Exception ex)
    {
        try
        {
            //string s = "<span style='font:verdana;font-size:9px;font-weight:normal'><hr/><p/>An error occured for IRA - WEB PORTAL";
            //s += "<hr/><p>ERROR DETAILS:</p>";
            //s += "<p/>Date: " + DateTime.Now.ToLongDateString();
            //s += "<p/>Time: " + DateTime.Now.ToLocalTime().ToString();
            //s += "<p/>Error Message: " + ex.Message;
            //s += "<p/>Error Source: " + ex.Source;
            //s += "<p/>Stack Trace: " + ex.StackTrace;
            //s += "<p/>Target Site - Name: " + ex.TargetSite.Name;
            //s += "<p/>Target Site - Module: " + ex.TargetSite.Module.FullyQualifiedName;
            //s += "</span>";

            //HRS.CEmail eml = new HRS.CEmail();
            //eml.Body = s;
            //eml.From = "randomfeaturesbin@gmail.com";
            //eml.Subject = "ISSUES IN THE WEB PORTAL";
            //string[] _strtoadddress = new string[1];
            //_strtoadddress[0] = "randomfeaturesbin@gmail.com";
            //eml.To = _strtoadddress;
            ////eml.SendMail();

        }
        catch (Exception ex2)
        {
            ex2.Data.Clear();
        }
    }
    public static void SendEmailAlert(string strToAddress, string strSubject, string strBody)
    {
        try
        {
            string s = strBody;

            //HRS.CEmail eml = new HRS.CEmail();// new cEmail( new cEmail(strsmtp_server);

            //eml.From = SiteFunctions.EmployeeEmail(SiteFunctions.CurrentUserID);

            //eml.Body = s;

            //eml.Subject = strSubject;

            //string[] _strtoadddress = new string[1];
            //_strtoadddress[0] = strToAddress;
            //eml.To = _strtoadddress;// strToAddress;// "x.x@x.co.ke";
            //eml.SendMail();

        }
        catch (Exception ex2)
        {
            ex2.Data.Clear();
        }
    }
    public static int SiteHit
    {
        get
        {
            int i = 1;
            try
            {
                string s = "SELECT COUNT([UserName]) AS [Site Hit] FROM [tbl_Sys_Session];";

                SqlDataReader dr = new CONNECT().ReadDB(s);

                if (dr.HasRows)
                    while (dr.Read())
                        i = Convert.ToInt32(dr["Site Hit"]);

                dr.Close();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return i;
        }
    }
    public static bool ChangedPassword
    {
        get
        {
            bool b = false;

            //try
            //{
            //    SqlDataReader dr = new CONNECT().ReadDB(
            //        "SELECT [Changed Password]" +
            //        " FROM [tbl_Sys_Map]" +
            //        " WHERE [UserName] = '" + SiteFunctions.ValidateEntry(SiteFunctions.CurrentUserID) + "'" +
            //        " and [ChangedPassword] = 1;"
            //        );

            //    b = dr.HasRows;

            //    dr.Close();
            //}
            //catch (Exception ex)
            //{
            //    ex.Data.Clear();
            //}
            return b;
        }
    }
    public static int SiteHitPersonal
    {
        get
        {
            int i = 1;

            try
            {
                string s = "";
                s = "SELECT COUNT([UserName]) AS [SiteHit]" +
                    " FROM tbl_Sys_Session" +
                    " WHERE [UserName] = '" + SiteFunctions.ValidateEntry(SiteFunctions.CurrentUserID) + "'";

                SqlDataReader dr = new CONNECT().ReadDB(s);

                if (dr.HasRows)
                    while (dr.Read())
                        i = Convert.ToInt32(dr["Site Hit"]);

                dr.Close();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return i;
        }
    }
    public static string ValidateEntry(string Entry)
    {
        string r = Entry.Trim();
        try
        {
            //Entry = (Entry.Trim().Length > 250 ? Entry.Trim().Substring(0, 250) : Entry.Trim());
            Entry = Entry.Replace("'", "\'");
            Entry = Entry.Replace("--", string.Empty);

            r = Entry;
        }
        catch (Exception e)
        {
            throw;
        }
        return r;
    }

    public static bool IsValidEmail(string Email)
    {
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        System.Text.RegularExpressions.Regex _Regex = new System.Text.RegularExpressions.Regex(strRegex);
        if (_Regex.IsMatch(Email))
            return (true);
        else
            return (false);
    }

    ///// <summary>
    ///// Trim all sql and other illegal characters
    ///// </summary>
    ///// <param name="Entry"></param>
    ///// <returns></returns>
    //private static string ValidateNumber(string Entry)
    //{
    //    string r = Entry;

    //    try
    //    {
    //        Entry = ValidateEntry(Entry);
    //        Entry = Entry.Replace(",", "").Replace("(", "").Replace(")", "");

    //        r = Convert.ToDouble(Entry).ToString();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //    return r;
    //}

    ///// <summary>
    ///// Trim all sql and other illegal characters
    ///// </summary>
    ///// <param name="Number2Unformat"></param>
    ///// <returns></returns>
    //public static double UnformatNumber(string Number2Unformat)
    //{
    //    double d = 0;

    //    try
    //    {
    //        d = Convert.ToDouble(ValidateNumber(Number2Unformat));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Data.Clear();
    //    }

    //    return d;
    //}

    ///// <summary>
    ///// check if number is real
    ///// </summary>
    ///// <param name="numberToValidate"></param>
    ///// <returns></returns>
    //public static bool ValidNumber(string numberToValidate)
    //{
    //    bool b = false;

    //    try
    //    {
    //        numberToValidate = ValidateNumber(numberToValidate);

    //        if (numberToValidate.Length > 0)
    //        {
    //            //throw exception if not double number.
    //            double d = Convert.ToDouble(numberToValidate);

    //            //success/valid double number
    //            b = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Data.Clear();
    //    }

    //    return b;
    //}

    //public static string FormatNumber(double Number2Format)
    //{
    //    return SiteFunctions.FormatNumber(Number2Format.ToString());
    //}

    //public static string FormatNumber(string Number2Format)
    //{
    //    if (Number2Format.Contains("(") || Number2Format.Contains(")"))
    //        Number2Format = Number2Format.Substring(1, Number2Format.Length - 2);

    //    double d = Convert.ToDouble(Number2Format);//remove non-numeric characters

    //    string s = d.ToString();//revert to string

    //    string wholeNumber = "";
    //    string decimalPoint = "";

    //    bool negativeNumber;

    //    if (Convert.ToDouble(Number2Format) < 0)
    //        negativeNumber = true;
    //    else
    //        negativeNumber = false;

    //    if (negativeNumber)
    //        s = s.Substring(1);

    //    try
    //    {
    //        int i, j, k;

    //        if (s.Contains(".") == false)
    //            s += ".00";

    //        i = s.IndexOf(".");

    //        decimalPoint = s.Substring(i + 1);

    //        if (decimalPoint.Length == 1)
    //            decimalPoint = decimalPoint + "0";
    //        else if (decimalPoint.Length > 2)
    //            decimalPoint = decimalPoint.Substring(0, 2);

    //        k = 0;
    //        for (j = (i - 1); j >= 0; j--)
    //        {
    //            wholeNumber = s.Substring(j, 1) + wholeNumber;

    //            k++;
    //            if (k == 3)
    //            {
    //                k = 0;

    //                if (j > 0) wholeNumber = "," + wholeNumber;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SiteFunctions.SendErrorToDeveloper(ex);
    //        ex.Data.Clear();
    //    }

    //    //if (negativeNumber) s = "(" + wholeNumber + "." + decimalPoint + ")";
    //    if (negativeNumber) s = "-" + wholeNumber + "." + decimalPoint;

    //    else s = wholeNumber + "." + decimalPoint;

    //    return s;
    //}
    
    public static void WriteLog(string transactionDescription)
    {
        try
        {
            string s = "insert into tbl_Sys_Log " +
                " ([UserID],[UserSessionID],[Action])values(" +
                " '" + SiteFunctions.CurrentUserID.ToUpper() + "'," +
                " '" + SiteFunctions.CurrentUserSessionID + "'," +
                " '" + SiteFunctions.ValidateEntry(transactionDescription) + "')";
            
            new CONNECT().WriteDB(s);
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
    }
    public static void ShowAlert(Page currentPage, string message)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("alert('");
        sb.Append(message);
        sb.Append("');");
        
        currentPage.ClientScript.RegisterStartupScript(typeof(SiteFunctions), "showalert", sb.ToString(), true);
    }
    public static void ShowAlert(string message)
    {
        Page currentPage = HttpContext.Current.Handler as Page;
        if (currentPage != null)
            ShowAlert(currentPage, message);
    }


    //========================================================
    
    public static string GetGridViewRowLabelValue(GridViewRow row, string sControlName)
    {
        string sFieldValue = string.Empty;

        Label _ctl = (Label)row.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetGridViewRowLabelValue: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.Text.Trim();
        return sFieldValue;
    }    
    public static string GetGridViewRowTextValue(GridViewRow row, string sControlName)
    {
        string sFieldValue = string.Empty;

        TextBox _ctl = (TextBox)row.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetGridViewRowTextValue: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.Text.Trim();
        return sFieldValue;
    }    
    public static DateTime GetGridViewRowDateValue(GridViewRow row, string sControlName)
    {
        DateTime sFieldValue = DateTime.Now;

        //SlimeeLibrary.DatePicker _ctl = (SlimeeLibrary.DatePicker)row.FindControl(sControlName);
        //if (_ctl == null)
        //{
        //    throw new Exception("GetGridViewRowDateValue: could not find " + sControlName + " control!");
        //}

        //sFieldValue = _ctl.SelectedDate;
        return sFieldValue;
    }    
    public static string GetGridViewRowDropDownListText(GridViewRow row, string sControlName)
    {
        string sFieldValue = string.Empty;

        DropDownList _ctl = (DropDownList)row.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetGridViewRowDropDownListText: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.SelectedItem.Text; //Console.WriteLine(_ctl.SelectedValue); 
        return sFieldValue;
    }    
    public static string GetGridViewRowDropDownListValue(GridViewRow row, string sControlName)
    {
        string sFieldValue = string.Empty;

        DropDownList _ctl = (DropDownList)row.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetGridViewRowDropDownListValue: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.SelectedValue; Console.WriteLine(_ctl.SelectedItem);
        return sFieldValue;
    }    
    public static bool GetGridViewRowCheckBoxValue(GridViewRow row, string sControlName)
    {
        bool bFieldValue = false;

        CheckBox _ctl = (CheckBox)row.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetGridViewRowCheckBoxValue: could not find " + sControlName + " control!");
        }

        bFieldValue = _ctl.Checked;
        return bFieldValue;
    }

    //========================================================

    public static string GetFormViewLabelValue(FormView formView, string sControlName)
    {
        string sFieldValue = string.Empty;

        Label _ctl = (Label)formView.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetFormViewLabelValue: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.Text.Trim();
        return sFieldValue;
    }
    public static string GetFormViewTextBoxValue(FormView formView, string sControlName)
    {

        string sFieldValue = string.Empty;

        TextBox _ctl = (TextBox)formView.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetFormViewTextBox: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.Text.Trim();
        return sFieldValue;
    }   
    public static DateTime GetFormViewTimeValue(FormView formView, string sControlName)
    {
        DateTime sFieldValue = DateTime.Now;

        //MKB.TimePicker.TimeSelector _ctl = (MKB.TimePicker.TimeSelector)formView.FindControl(sControlName);
        //if (_ctl == null)
        //{
        //    throw new Exception("GetFormViewTimeValue: could not find " + sControlName + " control!");
        //}
        //int hr = _ctl.Hour;
        //int mn = _ctl.Minute;
        //sFieldValue = new DateTime(1900, 01, 01, hr, mn, 0);
        return sFieldValue;
    }    
    public static DateTime GetFormViewDateValue(FormView formView, string sControlName)
    {
        DateTime sFieldValue = DateTime.Now;

        //SlimeeLibrary.DatePicker _ctl = (SlimeeLibrary.DatePicker)formView.FindControl(sControlName);
        //if (_ctl == null)
        //{
        //    throw new Exception("GetFormViewDateValue: could not find " + sControlName + " control!");
        //}

        //sFieldValue = _ctl.SelectedDate;
        return sFieldValue;
    }   
    public static string GetFormViewDropDownListText(FormView formView, string sControlName)
    {
        string sFieldValue = string.Empty;

        DropDownList _ctl = (DropDownList)formView.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetFormViewDropDownListText: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.SelectedItem.Text;
        return sFieldValue;
    }
    public static string GetFormViewDropDownListValue(FormView formView, string sControlName)
    {
        string sFieldValue = string.Empty;

        DropDownList _ctl = (DropDownList)formView.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetFormViewDropDownListValue: could not find " + sControlName + " control!");
        }

        sFieldValue = _ctl.SelectedValue; Console.WriteLine(_ctl.SelectedItem);
        return sFieldValue;
    }
    public static bool GetFormViewCheckBoxValue(FormView formView, string sControlName)
    {
        bool bFieldValue = false;

        CheckBox _ctl = (CheckBox)formView.FindControl(sControlName);
        if (_ctl == null)
        {
            throw new Exception("GetFormViewCheckBoxValue: could not find " + sControlName + " control!");
        }

        bFieldValue = _ctl.Checked;
        return bFieldValue;
    }

    public static string CurrentActiveFunction
    {
        get
        {
            string d = "";
            try
            {
                d = HttpContext.Current.Session["ActiveFunction"].ToString().ToUpper();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        set
        {
            try
            {
                HttpContext.Current.Session["ActiveFunction"] = value.ToUpper();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
    }

    public static string CurrentDefaultURL
    {
        get
        {
            string d = "";
            try
            {
                d = HttpContext.Current.Session["DefaultURL"].ToString().ToLower();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        set
        {
            try
            {
                HttpContext.Current.Session["DefaultURL"] = value.ToLower();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
    }

    public static DateTime CurrentDate
    {
        get
        {
            DateTime d = DateTime.Now;
            try
            {
                d =DateTime.Parse ( HttpContext.Current.Session["CurrDate"].ToString());
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        set
        {
            try
            {
                HttpContext.Current.Session["CurrDate"] = value;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
    }
}
