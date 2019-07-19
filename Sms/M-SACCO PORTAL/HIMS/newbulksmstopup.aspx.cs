using System;
using System.Data;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Global.HIMS;

namespace HIMS
{
    public partial class newbulksmstopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                    return;
                }

                Fill_DropSacco();
                //Fill_DropDownCountry();
                //Fill_DropDownPhysicalCountry();
                
            }

        }


        //public void Fill_DropDownCountry()
        //{
        //    using (SqlConnection connToNAV = MyClass.getconnToNAV())
        //    {
        //        string sqlStmt = null;
        //        sqlStmt = "spGetCountryList";
        //        SqlCommand cmdCountry = new SqlCommand();
        //        cmdCountry.CommandText = sqlStmt;
        //        cmdCountry.Connection = connToNAV;
        //        cmdCountry.CommandType = CommandType.StoredProcedure;
        //        cmdCountry.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = MyClass.Company_Name;
        //        using (SqlDataReader sqlReaderCountry = cmdCountry.ExecuteReader())
        //       {
        //            if (sqlReaderCountry.HasRows)
        //            {
        //                DropDownCountry.DataSource = sqlReaderCountry;
        //                DropDownCountry.DataTextField = "Name";
        //                DropDownCountry.DataValueField = "Code";
        //                DropDownCountry.DataBind();
        //            }
        //        }
        //        connToNAV.Close();
        //    }
        //}

        //public void Fill_DropDownPhysicalCountry()
        //{
        //    using (SqlConnection connToNAV = MyClass.getconnToNAV())
        //    {
        //        string sqlStmt = null;
        //        sqlStmt = "spGetCountryList";
        //        SqlCommand cmdCountry = new SqlCommand();
        //        cmdCountry.CommandText = sqlStmt;
        //        cmdCountry.Connection = connToNAV;
        //        cmdCountry.CommandType = CommandType.StoredProcedure;
        //        cmdCountry.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = MyClass.Company_Name;
        //        using (SqlDataReader sqlReaderCountry = cmdCountry.ExecuteReader())
        //        {
        //            if (sqlReaderCountry.HasRows)
        //            {
        //                //PysicalLocationCountryDropDownCountry.DataSource = sqlReaderCountry;
        //                //PysicalLocationCountryDropDownCountry.DataTextField = "Name";
        //                //PysicalLocationCountryDropDownCountry.DataValueField = "Code";
        //                //PysicalLocationCountryDropDownCountry.DataBind();
        //            }
        //        }
        //        connToNAV.Close();
        //    }
        //}

        public void Fill_DropSacco()
        {
            using (SqlConnection mConn = new SqlConnection(CommonUtilities.ConnectionString))
            {
                mConn.Open();
                string CorporateNo = Session["CorporateNo"].ToString();

                string SQL = "SELECT  [Corporate No], [Sacco Name 1] FROM [Source Information] WHERE (Active = 1)ORDER BY [Sacco Name 1]";
                
                SqlCommand cmd = new SqlCommand(SQL, mConn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null)
                    {
                        if (dr.HasRows == true)
                        {
                            DropSacco.DataSource = dr;
                            DropSacco.DataTextField = "Sacco Name 1";
                            DropSacco.DataValueField = "Corporate No";
                            DropSacco.DataBind();
                        }
                    }
                    dr.Close();
                }
                mConn.Close();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {

            string CurrentPage = "bulksmstopup.aspx";
            Response.Redirect(CurrentPage);
        }
        protected void SaveButton_Click(object sender, EventArgs e)
        {
//            try
//            {
       

//            if (Password.Text == txtConfirmPassword.Text)
//            {
                
//                using( SqlConnection conn = MyClass.getconnection()){

//                SqlDataReader dr25 = null;
//                SqlCommand cmd4 = new SqlCommand();
//                cmd4.CommandText = "spCheckIfPin_NoIsTaken";
//                cmd4.CommandType = CommandType.StoredProcedure;
//                cmd4.Connection = conn;
//                cmd4.Parameters.Add("@Pin_No", SqlDbType.VarChar).Value = Pin_No.Text;
         
//                dr25 = cmd4.ExecuteReader();

//                if (dr25.HasRows == true)
//                {

//                    lblError.Text = "<div class='warnig'><img src='images/warning.gif' width=20 height=20 border='none' style='padding-right:10px;float:left;'>Pin No already taken. Please try another one !</div>";

//                }
//                else
//                {
                    

//                    SqlDataReader dr255 = null;
//                    SqlCommand cmd45 = new SqlCommand();
//                    cmd45.CommandText = "spCheckIfCompanyNameIsTaken";
//                    cmd45.CommandType = CommandType.StoredProcedure;
//                    cmd45.Connection = conn;
//                    cmd45.Parameters.Add("@LegalFirmName", SqlDbType.VarChar).Value = LegalFirmName.Text.Trim().ToUpper();
//                    dr255 = cmd45.ExecuteReader();

//                    if (dr255.HasRows == true)
//                    {

//                        lblError.Text = "<div class='warnig'><img src='images/warning.gif' width=20 height=20 border='none' style='padding-right:10px;float:left;'>Legal name of firm is already taken.Please try another one !</div>";

//                    }
//                    else{

//                     string Vendor_Email = Email.Text;

            
//                 string SQL_ = String.Format("SELECT Supplier_Id FROM [Suppliers] WHERE [Email]='{0}'", Vendor_Email);
//                 SqlCommand cmd23_ = new SqlCommand(SQL_, conn);

//                 //Response.Write(SQL_);
//                 using( SqlDataReader dr255__ = cmd23_.ExecuteReader())
//                 {

//                 if (dr255__.HasRows == false)
//                 {

//                     #region SAVE To Portal

//                     SqlCommand cmds = new SqlCommand();
//                     cmds.CommandType = CommandType.StoredProcedure;
//                     cmds.Connection = conn;
//                     cmds.CommandText = "spAddSupplier";
//                     cmds.Parameters.Add("@LegalFirmName", SqlDbType.VarChar).Value = MyClass.convertQuotes(LegalFirmName.Text.Trim().ToUpper());
//                     cmds.Parameters.Add("@PoBox", SqlDbType.VarChar).Value = PoBox.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@PostCode", SqlDbType.VarChar).Value = PostCode.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@CityTown", SqlDbType.VarChar).Value = DropSacco.SelectedItem.Value.Trim().ToUpper();
//                     cmds.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = DropDownCountry.SelectedItem.Value.Trim().ToUpper();
//                     cmds.Parameters.Add("@Physical_Location", SqlDbType.VarChar).Value = Physical_Location.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@PysicalLocationTownCity", SqlDbType.VarChar).Value = DropSacco.SelectedItem.Value.Trim().ToUpper();
//                     cmds.Parameters.Add("@Building", SqlDbType.VarChar).Value = Building.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@PysicalLocationCountryCode", SqlDbType.VarChar).Value = DropDownCountry.SelectedItem.Value.Trim().ToUpper();
//                     cmds.Parameters.Add("@Street", SqlDbType.VarChar).Value = Street.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@PlotNo", SqlDbType.VarChar).Value = PlotNo.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email.Text;

//                     cmds.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar).Value = TelephoneNumber.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Fax.Text.Trim().ToUpper();

//                     string OutOfHours_Phone = OutOfHoursPhone.Text.Trim();
//                     OutOfHours_Phone = OutOfHours_Phone.Replace("'", "");

//                     cmds.Parameters.Add("@OutOfHoursPhone", SqlDbType.VarChar).Value = OutOfHours_Phone.ToUpper();
//                     cmds.Parameters.Add("@ContactPerson", SqlDbType.VarChar).Value = ContactPerson.Text.Trim().ToUpper();


//                     string Usertype = "User";
//                     cmds.Parameters.Add("@Usertype", SqlDbType.VarChar).Value = Usertype;
//                     cmds.Parameters.Add("@PinNo", SqlDbType.VarChar).Value = Pin_No.Text.Trim().ToUpper();
//                     cmds.Parameters.Add("@Password", SqlDbType.VarChar).Value = MyClass.GetMd5Hash(Password.Text);

//                     cmds.ExecuteNonQuery();

//#endregion

//                     #region Save To NAV

//                     using (SqlConnection connNAV = MyClass.getconnToNAV())
//                     {
//                         SqlCommand cmdSectionOne = new SqlCommand();


//                         //SqlCommand cmd_4 = new SqlCommand();
//                         //cmd_4.CommandText = "spGetTenderSectionsInformations";
//                         //cmd_4.CommandType = CommandType.StoredProcedure;
//                         //cmd_4.Connection = connNAV;
//                         //cmd_4.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = MyClass.Company_Name;
//                         //cmd_4.Parameters.Add("@Pin_No", SqlDbType.VarChar).Value = String.Format("'{0}'", Pin_No.Text.Trim().ToUpper());

//                         //using (SqlDataReader dr_25 = cmd4.ExecuteReader())
//                         //{
//                         //    if (dr_25.HasRows == true)
//                         //    {
//                         //        cmdSectionOne.CommandText = "spUpdateTenderInformationsSectionOne";
//                         //    }
//                         //    else
//                         //    {

                                
//                         //    }
//                         //}


//                         cmdSectionOne.CommandText = "spSaveTenderInformationsSectionOne";

//                         string FirmLegalName = "";
//                         FirmLegalName = String.Format("'{0}'", LegalFirmName.Text);


//                         cmdSectionOne.CommandType = CommandType.StoredProcedure;
//                         cmdSectionOne.Connection = connNAV;
//                         cmdSectionOne.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = MyClass.Company_Name;
//                         cmdSectionOne.Parameters.Add("@Pin_No", SqlDbType.VarChar).Value = "'" + Pin_No.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@LegalFirmName", SqlDbType.VarChar).Value = "'" + MyClass.convertQuotes(LegalFirmName.Text.Trim().ToUpper()) + "'";
//                         cmdSectionOne.Parameters.Add("@PoBox", SqlDbType.VarChar).Value = "'" + PoBox.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@PostCode", SqlDbType.VarChar).Value = "'" + PostCode.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@CityTown", SqlDbType.VarChar).Value = "'" + DropSacco.SelectedItem.Value.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = "'" + DropDownCountry.SelectedItem.Value.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@Physical_Location", SqlDbType.VarChar).Value = "'" + Physical_Location.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@PysicalLocationTownCity", SqlDbType.VarChar).Value = "'" + DropSacco.SelectedItem.Value.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@Building", SqlDbType.VarChar).Value = "'" + Building.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@PysicalLocationCountryCode", SqlDbType.VarChar).Value = "'" + DropDownCountry.SelectedItem.Value.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@Street", SqlDbType.VarChar).Value = "'" + Street.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@PlotNo", SqlDbType.VarChar).Value = "'" + PlotNo.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@Phone", SqlDbType.VarChar).Value = "'" + Phone.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@Email", SqlDbType.VarChar).Value = "'" + Email.Text.Trim() + "'";
//                         cmdSectionOne.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar).Value = "'" + TelephoneNumber.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@Fax", SqlDbType.VarChar).Value = "'" + Fax.Text.Trim().ToUpper() + "'";      
//                         cmdSectionOne.Parameters.Add("@OutOfHoursPhone", SqlDbType.VarChar).Value = "'" + OutOfHours_Phone.ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@ContactPerson", SqlDbType.VarChar).Value = "'" + ContactPerson.Text.Trim().ToUpper() + "'";
//                         cmdSectionOne.Parameters.Add("@CurrentTradeLicenceNo", SqlDbType.VarChar).Value = "'" + "'";
//                         cmdSectionOne.Parameters.Add("@ExpiryDate", SqlDbType.VarChar).Value = "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
//                         cmdSectionOne.Parameters.Add("@Title", SqlDbType.VarChar).Value = "'" + "M" + "'";
//                         cmdSectionOne.Parameters.Add("@MaximumValue", SqlDbType.VarChar).Value = "'" + "0" + "'";
//                         cmdSectionOne.Parameters.Add("@MyRecId", SqlDbType.VarChar).Value = "'" + "124XX" + "'";
//                         cmdSectionOne.ExecuteNonQuery();
//                         connNAV.Close();

//                     }
//                     #endregion

//                     string Supplier_Id = "";

//                     string SQL = String.Format("SELECT Supplier_Id FROM [Suppliers] WHERE [Email]='{0}'", Vendor_Email);
//                     SqlCommand cmd23 = new SqlCommand(SQL, conn);
//                     using (SqlDataReader dr2_ = cmd23.ExecuteReader())
//                     {
//                         if (dr2_.HasRows)
//                         {
//                             dr2_.Read();
//                             Supplier_Id = dr2_["Supplier_Id"].ToString();
//                         }
//                     }



//                     //lblError.Text = "<div class='information' style='color:green;'><img src='images/information.gif' width=20 height=20 border='none' style='padding-right:10px;float:left;'>Company information succesfully saved.<br/>Please wait for your account to be activated!<br/> You will receive an email once this is done.</div>";
//                     lblError.Text = String.Format("<div class='information' style='color:green;'><img src='images/information.gif' width=20 height=20 border='none' style='padding-right:10px;float:left;'>Company information succesfully submitted.<br/>An email address with instructions on how to activate your account have been sent to <b> {0}</b><br/> Thankyou.</div>", Vendor_Email);

//                     SendEmailToGCHOnSupplierRegistration();

//                     if (string.IsNullOrEmpty(Supplier_Id) == false)
//                     {

//                         string msg = "<div style='color:black;'>Dear " + LegalFirmName.Text.Trim().ToUpper() + ",  <br/><br/>" +

//                     " <b>Gertrude's Children's Hospital e-Tender Portal access Instructions</b> <br/> <br/> " +

//                     " 1.	Click the link: http://41.217.221.90:8443/e-tender/Account_Activation.aspx?action=activate&email_id=" + Supplier_Id + " to activate your account<br/> " +
//                     " 2.	Enter the company pin number and the password you used during registration to login.<br/><br/> <br/><br/>" +
//                     " 	    If you do encounter any problems contact us through" +
//                     "       Email: info@gerties.org  <br/> " +
//                     "       Mobile: 0733-666053 / 0731-344044 / 0733-639444 / 0771-573752 <br/> " +

//                     "<br/> Thank you.</div>";

//                         string body = msg;
//                         string recepient = Vendor_Email;
//                         const string subject = "Gertrude's Children's Hospital E-Tender Portal";
//                         MyClass.SendEmailAlert(body, recepient, subject, "");
//                     }

//                     LegalFirmName.Text = "";
//                     PoBox.Text = "";
//                     PostCode.Text = "";
//                     Physical_Location.Text = "";
//                     Building.Text = "";
//                     Street.Text = "";
//                     PlotNo.Text = "";
//                     Phone.Text = "";
//                     Email.Text = "";
//                     Fax.Text = "";
//                     TelephoneNumber.Text = "";
//                     OutOfHoursPhone.Text = "";
//                     ContactPerson.Text = "";
//                     Pin_No.Text = "";
//                     Password.Text = "";

//                     string CurrentPage = "";

//                     CurrentPage = "Login.aspx?option=Login&action=Login";

//                    Response.AddHeader("REFRESH", "60;URL=" + CurrentPage);

//                 }
//                 else
//                 {
//                     lblError.Text = "<div class='warnig'><img src='images/warning.gif' width=20 height=20 border='none' style='padding-right:10px;float:left;'>Email address is already taken. Please try another one !</div>";

//                 }
//                    }

                        
//                }
//                }
//                conn.Close();

//            }
//            }
//            else {

//                lblError.Text = "<div class='warning'><img src='images/warning.gif' width=20 height=20 border='none' style='padding-right:10px;float:left;'>Passwords do not match, please Retype </div>";
            
//            }

//            }
//            catch (Exception ex)
//            {
//                ex.Data.Clear();
//            }

        
    }

        void SendEmailToGCHOnSupplierRegistration()
        {
            //string body, subject;
            //string recepient = MyClass.GCH_Email_Recipient_Email;
            //subject = "New Supplier On Getrudes E-Tender System";
            //body = "A new supplier has created an account on E-Tender System at " + DateTime.Now;
            //MyClass.SendEmailAlert(body, recepient, subject, "");

        }
    }
}