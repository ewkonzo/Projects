using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OGL;
using SQL_ICAP = System.Data.SqlClient;
using System.Data.SqlClient;
using System.Globalization;
using Bandari_Sacco.controller;


namespace Bandari_Sacco
{
    public partial class Leave : System.Web.UI.Page
    {
        private string seriesCode = "LVAPP";
        private string newDocNo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
         try
        {
            this.lblError.Text = "";

            MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                this.LoadResponsibilityCenters();
                this.LoadAppraisers();
                this.LoadLeaveRelievers();

                this.gvPending.EmptyDataText =
                    cSite.UserName + ", you have no pending leave application(s).";

                this.gvApproved.EmptyDataText =
                    cSite.UserName + ", you have no approved leave application(s).";

                this.gvRejected.EmptyDataText =
                    cSite.UserName + ", you have no rejected leave application(s).";

                this.gvApprove2.EmptyDataText =
                    cSite.UserName + ", you have no leave application(s) awaiting your approval.";

                this.calStartDate.SelectedDate = DateTime.Now;

                this.LoadLeaveTypes();
                this.ddlLeaveTypes_SelectedIndexChanged1(null, null);

                this.lblNo.Text = cSite.ExternalUserID;
                this.lblNames.Text = cSite.UserName;
                this.lblApplicationCode.Text = "Auto Generated";
                SetInitialRow();
                //this.gvApproved_PageIndexChanging(null, null);
                //this.gvPending_PageIndexChanging(null, null);
                //this.gvRejected_PageIndexChanging(null, null);
                //this.gvApprove2_PageIndexChanging(null, null);
            }
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }


    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("EmployeeNo", typeof(string)));

        dt.Columns.Add(new DataColumn("Column2", typeof(string)));

        dt.Columns.Add(new DataColumn("Column3", typeof(string)));

        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["EmployeeNo"] = this.lblNo.Text;

        dr["Column2"] = string.Empty;

        dr["Column3"] = string.Empty;

        dt.Rows.Add(dr);

        //dr = dt.NewRow();



        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;

        LoadLeaveRelievers2();

        Gridview1.DataSource = dt;

        Gridview1.DataBind();

    }

    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

                    //extract the TextBox values

                    //TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");


                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                    DropDownList box3 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    drCurrentRow["EmployeeNo"] = this.lblNo.Text;


                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;

                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;


                    rowIndex++;

                }

                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;

                LoadLeaveRelievers2();

                Gridview1.DataSource = dtCurrentTable;

                Gridview1.DataBind();

            }

        }

        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks

        SetPreviousData();

    }

    private void SetPreviousData()
    {

        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {



                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                    DropDownList box3 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");





                    box2.Text = dt.Rows[i]["Column2"].ToString();

                    box3.Text = dt.Rows[i]["Column3"].ToString();



                    rowIndex++;

                }

            }

        }

    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        if (this.Gridview1.Rows.Count == 1)
        {
            return;
        }



        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["CurrentTable"];

        //dt.Rows[0].Delete();

        dt.Rows[e.RowIndex].Delete();
        ViewState["CurrentTable"] = dt;

        LoadLeaveRelievers2();


        Gridview1.DataSource = dt;

        Gridview1.DataBind();

        SetPreviousData();
    }

    protected void LoadLeaveRelievers2()
    {

        try
        {
            string strConnString = cConnect.conStr;

            using (SqlConnection con = new SqlConnection(strConnString))
            {

                string strQuery = "select '' as [No_], '' as Names union all select [No_],[First Name]+ ' ' + [Middle Name] + ' ' + [Last Name] as Names from [" + cSite.company_name + "$HR Employees]" +
                " where [First Name]<>'' and [Status]=0 order by [Names];";

                SqlCommand cmd = new SqlCommand(strQuery);

                cmd.Connection = con;
                con.Open();


                this.relieverData1.ConnectionString = strConnString;
                this.relieverData2.ConnectionString = strConnString;
                this.relieverData1.SelectCommand = strQuery;
                this.relieverData2.SelectCommand = strQuery;
                this.relieverData1.DataBind();
                this.relieverData2.DataBind();

            }
        }
        catch (System.Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();

        }

    }


    protected void ddlLeaveTypes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void lbNew_Click(object sender, EventArgs e)
    {
        try
        {
            this.MultiView1.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void lbPending_Click(object sender, EventArgs e)
    {
        try
        {
            this.gvPending_PageIndexChanging(null, null);

            this.MultiView1.ActiveViewIndex = 1;

        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void lbApproved_Click(object sender, EventArgs e)
    {
        try
        {
            this.gvApproved_PageIndexChanging(null, null);

            this.MultiView1.ActiveViewIndex = 2;
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void lbRejected_Click(object sender, EventArgs e)
    {
        try
        {
            this.gvRejected_PageIndexChanging(null, null);

            this.MultiView1.ActiveViewIndex = 3;
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void lbApprove2_Click(object sender, EventArgs e)
    {
        try
        {
            //this.gvApprove2_PageIndexChanging(null, null);
            this.gvLeaveApprovals_PageIndexChanging(null, null);
            //this.MultiView1.ActiveViewIndex = 5;
            this.MultiView1.SetActiveView(View6);
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void calStartDate_SelectedDateChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.calStartDate.SelectedDate < DateTime.Now.Date)
            {
                this.calStartDate.SelectedDate = DateTime.Now;

                this.lblError.Text =
                    "The start date of your leave cannot be before today." +
                    " Please select today or a future date.";

                RegisterStartupScript("Validation",
                    "<script>alert('" +
                    this.lblError.Text +
                    "')</script>");

                return;
            }

            if (
                this.calStartDate.SelectedDate.DayOfWeek == DayOfWeek.Saturday ||
                this.calStartDate.SelectedDate.DayOfWeek == DayOfWeek.Sunday
                )
            {
                this.calStartDate.SelectedDate = DateTime.Now;

                this.lblError.Text =
                    "The start date of your leave cannot be on a weekend.";

                RegisterStartupScript("Validation",
                    "<script>alert('" +
                    this.lblError.Text +
                    "')</script>");

                return;
            }

            this.lblReturnDate.Text = cSite.AddWorkingDays(
                this.calStartDate.SelectedDate,
                Convert.ToInt32(this.ddlDaysApplied.SelectedItem.Text)
                ).ToShortDateString();

            this.Panel1.UpdateAfterCallBack = true;
            
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }
    protected static string Right(string value, int length)
    {
        return value.Substring(value.Length - length);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.ValidateEntries)
            {
                //string temp = (this.LeaveNo).ToString();

                //string temp2 = "000000" + temp;
                ////if (temp2 < 4)
                ////    for (int j = 0; j < 4; j++)
                //temp = Right(temp2, 5);
                //this.lblApplicationCode.Text = "OLA-" + temp;

                newDocNo = cSite.Get_NextNumberSeries(seriesCode);
                //Session["Doc_No"] = newDocNo;
                //this.lblApplicationCode.Text = newDocNo;

                int daysapplied = Convert.ToInt32(this.ddlDaysApplied.SelectedItem.Text);
                DateTime AddWorkDays = cSite.AddWorkingDays(this.calStartDate.SelectedDate, daysapplied);
                //string AddWorkDays = cSite.FormatDate(cSite.AddWorkingDays(this.calStartDate.SelectedDate,
                //                      daysapplied), true);


                //string AddWorkDays =
                //    cSite.FormatDate(cSite.AddWorkingDays(this.calStartDate.SelectedDate,
                //    Convert.ToInt32(this.ddlDaysApplied.SelectedItem.Text)), true);

                DateTime returnDate = Convert.ToDateTime(AddWorkDays);

                DateTime endDate = this.calStartDate.SelectedDate.AddDays(Convert.ToDouble(this.ddlDaysApplied.SelectedItem.Text));

                DateTime startDate = this.calStartDate.SelectedDate;

                DateTime applicationDate = DateTime.Now;
                //DateTime endDate = Convert.ToDateTime(cSite.FormatDate(
                //    this.calStartDate.SelectedDate.AddDays(Convert.ToDouble(this.ddlDaysApplied.SelectedItem.Text)), true));
                //DateTime startDate = Convert.ToDateTime(cSite.FormatDate(this.calStartDate.SelectedDate, true));
                //DateTime applicationDate = Convert.ToDateTime(cSite.FormatDate(DateTime.Now, true));

                string approver = this.ddlAppraisers.SelectedValue;
                string empNum = cSite.ExternalUserID; 
                string userName = cSite.UserName;
                string userID = cSite.Employee_UserId();
                string leaveType = this.ddlLeaveTypes.SelectedValue; 
                string daysApplied = this.ddlDaysApplied.SelectedItem.Text;
                string approverName = this.ddlAppraisers.SelectedItem.Text;
                //string approverName = "";
                string reliever = this.ddlReliever.SelectedValue;
                string relieverName = this.ddlReliever.SelectedItem.Text;
                string applicantComments = this.txtComments.Text;
                string respCenter = this.ddlresponibilitycentres.SelectedValue;
                Boolean requestLeaveAllowance = this.cbLeaveAllowance.Checked;
                decimal days = 0;
                int status = 0;
                if (cSite.ValidNumber(daysApplied) == true)
                {
                    days = Convert.ToDecimal(daysApplied);
                }
                
                //string q =
                //    "insert into [" + cSite.company_name + "$HR Leave Application]" +
                //    " ([Employee No],[Names],[Application Code],[Leave Type]," +
                //    "[Days Applied],[Start Date],[Return Date],[Application Date]," +
                //    "[Status]," +
                //    "[End Date],[User ID]) values(" +
                //    " '" + empNum + "'," +
                //    " '" + userName + "'," +
                //    " '" + newDocNo + "'," +
                //    " '" + leaveType + "'," +
                //    " " + days + "," +
                //    " '" + startDate + "'," +
                //    " '" + returnDate + "'," +
                //    " '" + cSite.FormatDate(DateTime.Now, true) + "'," + 
                //    "'1'," +                    
                //    " '" + endDate + "'," +
                //    " '" + empNum + "' " + 
                //    ");";

                newDocNo = cSite.Bandari_WebService.HRLeaveAppInsert
                    (empNum, userName, leaveType, days, startDate, returnDate, applicationDate
                    , status, endDate, empNum, applicantComments, respCenter, requestLeaveAllowance);

                Session["Doc_No"] = newDocNo;
                this.lblApplicationCode.Text = newDocNo;

                bool insert = AddpendingAssignments(newDocNo); //save relievers

                //new cConnect().WriteDB(q);

                cSite.Bandari_WebService.SendLeaveForApproval(newDocNo);

                //this.LeaveNo = this.LeaveNo;
                string empEmail = cSite.EmployeeEmail(cSite.ExternalUserID);
                string approverEmail = cSite.EmployeeEmail(this.ddlAppraisers.SelectedValue);

                this.lblError.Text =
                    cSite.UserName +
                    ", Your leave application was successfuly received." +
                    "<br>Your application code is " + this.lblApplicationCode.Text;

                Messaging.ShowAlert(this.lblError.Text);
                //send receipt email to applicant
                string body =
                    "You received this alert to confirm" +
                    " receipt of your leave application at Bandari Sacco";

                cSite.send_user_mail(body, empEmail, "Leave Application Receipt");

                body = "";

                //send notification email to approver
                body =
                    "You have a pending leave application from " + cSite.UserName;

                cSite.send_user_mail(body, approverEmail, "Leave Application Approval Notification");

                //cSite.SendAlert(
                //  "Employee " + cSite.UserName + " Will be proceeding on leave for </br> " + this.ddlDaysApplied.SelectedValue + "From : "
                //   + this.calStartDate.SelectedDate.ToString("dd/MM/yyyy") + " To: " + this.lblReturnDate.Text,
                //  cSite.EmployeeEmail(cSite.RDEmpNo(cSite.ExternalUserID))
                //  );

            }
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }

    }

    protected void calStartDate_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.calStartDate.SelectedDate < DateTime.Now.Date)
            {
                this.calStartDate.SelectedDate = DateTime.Now;

                this.lblError.Text =
                    "The start date of your leave cannot be before today." +
                    " Please select today or a future date.";

                RegisterStartupScript("Validation",
                    "<script>alert('" +
                    this.lblError.Text +
                    "')</script>");

                return;
            }


            if (
                this.calStartDate.SelectedDate.DayOfWeek == DayOfWeek.Saturday ||
                this.calStartDate.SelectedDate.DayOfWeek == DayOfWeek.Sunday
                )
            {
                this.calStartDate.SelectedDate = DateTime.Now;

                this.lblError.Text =
                    "The start date of your leave cannot be on a weekend.";

                RegisterStartupScript("Validation",
                    "<script>alert('" +
                    this.lblError.Text +
                    "')</script>");

                return;
            }

            this.lblReturnDate.Text = cSite.AddWorkingDays(
                this.calStartDate.SelectedDate,
                Convert.ToInt32(this.ddlDaysApplied.SelectedItem.Text)
                ).ToShortDateString();

            this.Panel1.UpdateAfterCallBack = true;
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }
    protected void RemoveRow(object sender, EventArgs e)
    {
    }

    protected void gvPending_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            new cConnect().WriteDB(
                "delete from [" + cSite.company_name + "$HR Leave Application]" +
                " where [Application Code] = '" + cSite.ValidateEntry(this.gvPending.SelectedRow.Cells[2].Text) + "' "
                );

            this.lblError.Text =
                cSite.UserName +
                ", Your leave application [" +
                this.gvPending.SelectedRow.Cells[1].Text +
                "] was successfuly canceled.";

            RegisterStartupScript("Validation",
                "<script>alert('" +
                this.lblError.Text +
                "')</script>");

            this.gvPending_PageIndexChanging(null, null);

        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void gvPending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string query = "";
            string applNo = ""; int docType = 21; string userID = ""; string courseDesc = "";
            DataKey Id;
            int index = Convert.ToInt32(string.IsNullOrEmpty(e.CommandArgument.ToString()) == true ? "0" : e.CommandArgument);
            if (index < 0 || index > gvPending.Rows.Count - 1)
            {
                return;
            }
            GridView myview = (GridView)e.CommandSource;
            GridViewRow row = myview.Rows[index];

            Id = gvPending.DataKeys[row.RowIndex];
            string entryNo = Id.Value.ToString();
            applNo = Id.Value.ToString();
            //applNo = this.TrainingAppNo(entryNo);
            //courseDesc = this.TrainingCourseDesc(entryNo);

            if (e.CommandName == "btncancel")
            {
                //HttpContext.Current.Session["viewingTrainAppNo"] = applNo;
                userID = cSite.GetUserID;
                //applNo = HttpContext.Current.Session["viewingTrainAppNo"].ToString();
                //cSite.Bandari_WebService.CancelDocument(applNo, userID);

                query =
                    "delete from [" + cSite.company_name + "$HR Leave Application]" +
               " where [Application Code] = '" + applNo + "' ";
                new cConnect().WriteDB(query);

                Messaging.ShowAlert(String.Format("Leave application for application number: {0} cancelled successfully", applNo));
                lbPending_Click(null, null);
            }
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
        }
    }



    protected void gvPending_PageIndexChanging_Old(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.dsPending.SelectCommand =
                "SELECT [Entry No],[Application Code],[Leave Code]," +
                "convert(varchar(15),[Application Date],106) as [Application Date]," +
                "convert(decimal(38,0),[Days Applied]) as [Days Applied]," +
                "convert(varchar(15),[Start Date],106) as [Start Date]," +
                "convert(varchar(15),[Return Date],106) as [Return Date], " +
                " CASE [Status] " +
                " WHEN '0' THEN 'New' " +
                " WHEN '1' THEN 'Pending Approval' " +
                " WHEN '2' THEN 'Approved' " +
                " WHEN '3' THEN 'Rejected' " +
                " WHEN '4' THEN 'Cancelled' " +
                " ELSE 'New' END  as [Status] " +
                " FROM [" + cSite.company_name + "$HR Leave Application]" +
                " where " +
                //" ([Status] <=3) and  " +
                " [Employee No] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "'" +
                " order by [Application Date] desc,[Application Code];";

            this.dsPending.DataBind();
            this.gvPending.DataBind();
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }


    protected void gvPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        SqlConnection con = null;
        try
        {
            string userNo = cSite.ExternalUserID;
            //String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

            con = new SqlConnection(strConnString);
            //cConnect cn = new cConnect();
            //SqlConnection con = new SqlConnection(cn);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "Get_My_LeaveApplications_List";

            cmd.Parameters.Add("@UserNo", SqlDbType.VarChar, 100).Value = userNo;
            cmd.Parameters.Add("@Company_Name", SqlDbType.VarChar, 100).Value = cSite.company_name;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 1;

            cmd.Connection = con;

            con.Open();

            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            gvPending.DataSource = dt;

            gvPending.EmptyDataText = "No records found";

            //gvPending.DataSource = cmd.ExecuteReader();

            //gvPending.PageIndex = e.NewPageIndex;
            gvPending.DataBind();

        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    protected void gvPending_Sorting(object sender, GridViewSortEventArgs e)
    {
        this.gvPending_PageIndexChanging(null, null);
    }

    protected void gvApproved_PageIndexChangingOLD(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.dsApproved.SelectCommand =
                "SELECT [Application Code],[Leave Code]," +
                "convert(varchar(15),[Application Date],106) as [Application Date],convert(decimal(32,2),[Days Applied]) as [Days Applied]," +
                "convert(varchar(15),[Start Date],106) as [Start Date]," +
                "convert(varchar(15),[Return Date],106) as [Return Date],[Comments]" +
                " FROM [" + cSite.company_name + "$HR Leave Application]" +
                " where [Status] = 6" +
                " and [Employee No] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "'" +
                " order by [Application Date] desc,[Application Code];";

            this.dsApproved.DataBind();
            this.gvApproved.DataBind();
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void gvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        SqlConnection con = null;
        try
        {
            string userNo = cSite.ExternalUserID;
            //String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

            con = new SqlConnection(strConnString);
            //cConnect cn = new cConnect();
            //SqlConnection con = new SqlConnection(cn);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "Get_My_LeaveApplications_List";

            cmd.Parameters.Add("@UserNo", SqlDbType.VarChar, 100).Value = userNo;
            cmd.Parameters.Add("@Company_Name", SqlDbType.VarChar, 100).Value = cSite.company_name;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 2;

            cmd.Connection = con;

            con.Open();

            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            gvApproved.DataSource = dt;

            gvApproved.EmptyDataText = "No records found";

            //gvPending.DataSource = cmd.ExecuteReader();

            //gvPending.PageIndex = e.NewPageIndex;
            gvApproved.DataBind();

        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    protected void gvApproved_Sorting(object sender, GridViewSortEventArgs e)
    {
        this.gvApproved_PageIndexChanging(null, null);
    }

    protected void gvRejected_PageIndexChangingOLD(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.dsRejected.SelectCommand =
                "SELECT [Application Code],[Leave Code]," +
                "convert(varchar(15),[Application Date],106) as [Application Date],convert(decimal(32,0),[Days Applied])as [Days Rejected]," +
                "convert(varchar(15),[Start Date],106) as [Start Date]," +
                "convert(varchar(15),[Return Date],106) as [Return Date],[Approver Comment]" +
                " FROM [" + cSite.company_name + "$HR Leave Application]" +
                " where ([Status] = 4 or Status = 5)" +
                " and [Employee No] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "'" +
                " order by [Application Date] desc,[Application Code];";

            this.dsRejected.DataBind();
            this.gvRejected.DataBind();
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void gvRejected_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        SqlConnection con = null;
        try
        {
            string userNo = cSite.ExternalUserID;
            //String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

            con = new SqlConnection(strConnString);
            //cConnect cn = new cConnect();
            //SqlConnection con = new SqlConnection(cn);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "Get_My_LeaveApplications_List";

            cmd.Parameters.Add("@UserNo", SqlDbType.VarChar, 100).Value = userNo;
            cmd.Parameters.Add("@Company_Name", SqlDbType.VarChar, 100).Value = cSite.company_name;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 3;

            cmd.Connection = con;

            con.Open();

            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            gvRejected.DataSource = dt;

            gvRejected.EmptyDataText = "No records found";

            //gvPending.DataSource = cmd.ExecuteReader();

            //gvPending.PageIndex = e.NewPageIndex;
            gvRejected.DataBind();

        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    protected void gvRejected_Sorting(object sender, GridViewSortEventArgs e)
    {
        this.gvRejected_PageIndexChanging(null, null);
    }

    protected void gvApprove2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            string s = "SELECT [Application Code],[Names],[Description]," +
                "convert(varchar(15),[Application Date],106) as [Application Date],convert(decimal(32,2),[Days Applied]) as [Days Applied]," +
                "convert(varchar(15),[Start Date],106) as [Start Date]," +
                "convert(varchar(15),[Return Date],106) as [Return Date],[Comments]" +
                " FROM [" + cSite.company_name + "$HR Leave Application],[" + cSite.company_name + "$HR Leave Type]" +
                " where [Status] <= 1" +
                " and Code=[Leave Code]" +
                " and [Approver] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "'" +
                " order by [Application Date] desc,[Application Code];";



            this.dsApprove2.SelectCommand =
                "SELECT [Application Code],[Names],[" + cSite.company_name + "$HR Leave Type].[Description]," +
                "convert(varchar(15),[Application Date],106) as [Application Date],convert(decimal(32,2),[Days Applied]) as [Days Applied]," +
                "convert(varchar(15),[Start Date],106) as [Start Date]," +
                "convert(varchar(15),[Return Date],106) as [Return Date],[Comments]" +
                " FROM [" + cSite.company_name + "$HR Leave Application],[" + cSite.company_name + "$HR Leave Type]" +
                " where [Status] <= 1" +
                " and Code=[Leave Code]" +
                " and [Approver] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "'" +
                " order by [Application Date] desc,[Application Code];";

            this.dsApprove2.DataBind();
            this.gvApprove2.DataBind();

            if (this.gvApprove2.Rows.Count == 0) this.btnApprove.Visible = false;
            else this.btnApprove.Visible = true;

        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void gvLeaveApprovals_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string approverID = cSite.Employee_UserId();
        String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

        SqlConnection con = null;
        try
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "GetLeaveApprovalList";
            //approverID="CRAKENYA\ERP.ADMIN";
            cmd.Parameters.Add("@ApproverID", SqlDbType.VarChar, 100).Value = approverID;
            cmd.Parameters.Add("@Company_Name", SqlDbType.VarChar, 100).Value = cSite.company_name;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 1;

            con = new SqlConnection(strConnString);
            cmd.Connection = con;

            con.Open();

            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            gvLeaveApprovals.DataSource = dt;
            gvLeaveApprovals.EmptyDataText = "No records for approval found";

            //gvLeaveApprovals.DataSource = cmd.ExecuteReader();

            gvLeaveApprovals.DataBind();
        }

        catch (Exception ex)
        {
            ex.Data.Clear();
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }


    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvr in this.gvApprove2.Rows)
            {
                RadioButtonList choice = (RadioButtonList)(cSite.FindControlRecursive(gvr, "rblApprove"));
                TextBox comments = (TextBox)(cSite.FindControlRecursive(gvr, "txtcomments"));
                if (choice.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(comments.Text))
                    {
                        RegisterStartupScript("Validation",
             "<script>alert('Comments required while rejecting any application')</script>");
                        return;
                    }
                    new cConnect().WriteDB(
                        "update [" + cSite.company_name + "$HR Leave Application] set" +
                        " [Approved Days] = '" + cSite.ValidateEntry(gvr.Cells[4].Text) + "'," +
                        " [HOD Approved Days] = '" + cSite.ValidateEntry(gvr.Cells[4].Text) + "'," +
                        " [Approval Date] = '" + cSite.FormatDate(DateTime.Now, true) + "'," +
                        " [Taken] = 1,[Rejected]=1,[Status]=4,[Approver Comment]='" + cSite.ValidateEntry(comments.Text) + "'" +

                        " where [Application Code] = '" + cSite.ValidateEntry(gvr.Cells[0].Text) + "';"
                        );

                    cSite.SendAlert(
                        "Your leave application has been approved by " + cSite.UserName,
                        cSite.EmployeeEmail(cSite.GetEmployeeNo(cSite.ValidateEntry(gvr.Cells[0].Text)))
                        );
                    cSite.SendAlert(
                "Leave application for Employee No" + cSite.GetEmployeeNo(gvr.Cells[0].Text) + " have been approved by " + cSite.UserName,
                cSite.EmployeeEmail(cSite.RDEmpNo(cSite.GetEmployeeNo(gvr.Cells[0].Text))));


                }
                else
                    if (choice.SelectedIndex == 0)
                    {
                        new cConnect().WriteDB(
                            "update [" + cSite.company_name + "$HR Leave Application] set" +
                            " [Approved Days] = '" + cSite.ValidateEntry(gvr.Cells[4].Text) + "'," +
                            " [HOD Approved Days] = '" + cSite.ValidateEntry(gvr.Cells[4].Text) + "'," +
                            " [Approval Date] = '" + cSite.FormatDate(DateTime.Now, true) + "'," +
                            " [Taken] = 0,[Status]=2 ,[Approver Comment]='" + cSite.ValidateEntry(comments.Text) + "'" +
                            " where [Application Code] = '" + cSite.ValidateEntry(gvr.Cells[0].Text) + "';"
                            );

                        cSite.SendAlert(
                            "Your leave application has been rejected by " + cSite.UserName,
                           cSite.EmployeeEmail(cSite.GetEmployeeNo(cSite.ValidateEntry(gvr.Cells[0].Text)))
                            );

                        cSite.SendAlert(
                        "Leave application for Employee No" + cSite.GetEmployeeNo(gvr.Cells[0].Text) + " have been rejected by " + cSite.UserName,
                        cSite.EmployeeEmail(cSite.RDEmpNo(cSite.GetEmployeeNo(gvr.Cells[0].Text))));


                    }
            }

            this.lblError.Text =
                cSite.UserName +
                ", The leave application(s) were successfuly approved/rejected.";

            RegisterStartupScript("Validation",
                "<script>alert('" +
                this.lblError.Text +
                "')</script>");

            //this.gvApprove2_PageIndexChanging(null, null);
            this.gvLeaveApprovals_PageIndexChanging(null, null);
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void gvApprove2_Sorting(object sender, GridViewSortEventArgs e)
    {
        //this.gvApprove2_PageIndexChanging(null, null);
        this.gvLeaveApprovals_PageIndexChanging(null, null);
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            this.lblReturnDate.Text = cSite.AddWorkingDays(
                this.calStartDate.SelectedDate,
                Convert.ToInt32(this.ddlDaysApplied.SelectedItem.Text)
                ).ToShortDateString();

            //this.lblReturnDate.Visible = false;
            this.Panel1.UpdateAfterCallBack = true;
            //this.Panel1.UpdateAfterCallBack = true;
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void LoadLeaveTypes()
    {
        try
        {
            string gender;
            if (cSite.EmployeeGender == "1")
            {
                gender = "2";
            }
            else
            {
                gender = "1";
            }

            this.ddlLeaveTypes.Items.Clear();

            SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                "select * from [" + cSite.company_name + "$HR Leave Types]" +
                " where (Gender = 0 or Gender = " + gender + ")" +
                " order by Description;"
                );

            ListItem li = null;

            if (dr.HasRows)
                while (dr.Read())
                {
                    li = new ListItem(
                        dr["Description"].ToString(),
                        dr["Code"].ToString()
                        );

                    this.ddlLeaveTypes.Items.Add(li);
                }
            dr.Close();
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected int LeaveNo
    {

        get
        {
            int i = 0;

            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select [Leave No]" +
                    " from [" + cSite.company_name + "$Online Setup];"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        i = Convert.ToInt32(dr["Leave No"]);

                dr.Close();




            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }

            return i + 1;
        }

        set
        {
            try
            {
                new cConnect().WriteDB(
                    " update [" + cSite.company_name + "$Online Setup]" +
                    " set [Leave No] = " + value.ToString()
                    );
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
        }

    }

    protected double MaxLeaveDaysPerType
    {
        get
        {
            double i = 0;

            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select [Days]" +
                    " from [" + cSite.company_name + "$HR Leave Types]" +
                    " where (Code = '" + cSite.ValidateEntry(this.ddlLeaveTypes.SelectedValue) + "');"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        i = Convert.ToDouble(dr["Days"]);

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }

            //if (i == 0) i = 1000;

            //if (this.IsCarryForward) i += this.ReimbersedLeaveDays;

            return i;
        }
    }

    protected double MaximumLeaveDays
    {
        get
        {
            double i = 0;

            try
            {

                //SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                //    "select [Leave Days]" +
                //    " from [" + cSite.company_name + "$HR Job Category_Grade]" +
                //    " where (Code = '" + cSite.ValidateEntry(this.ddlLeaveTypes.SelectedValue) + "')" +
                //    " and [Type] = 1"
                //    );
                if (this.ddlLeaveTypes.SelectedValue == "ANNUAL")
                {

                    SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                        "select case when [Allocated Leave Days] is null then 0 else [Allocated Leave Days] end + case when [Reimbursed Leave Days] is null then 0 else [Reimbursed Leave Days] end" +
                        " from [" + cSite.company_name + "$HR Employees]" +
                        " where ([No_] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "');"
                        );

                    if (dr.HasRows)
                        while (dr.Read())
                            i = Convert.ToDouble(dr[0]);
                    dr.Close();

                }
                else
                {

                    SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                        "select [Days]" +
                        " from [" + cSite.company_name + "$HR Leave Type]" +
                        " where (Code = '" + cSite.ValidateEntry(this.ddlLeaveTypes.SelectedValue) + "');"
                        );

                    if (dr.HasRows)
                        while (dr.Read())
                            i = Convert.ToDouble(dr["Days"]);

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }

            if (i == 0) i = 1000;

            if (this.IsCarryForward) i += this.ReimbersedLeaveDays;

            return i;
        }
    }

    protected double TotalLeaveTaken
    {
        get
        {
            double i = 0;

            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select [Approved Days]" +
                    " from [" + cSite.company_name + "$HR Leave Application]" +
                    " where [Employee No] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "'" +
                    " and [Leave Code] = '" + cSite.ValidateEntry(this.ddlLeaveTypes.SelectedValue) + "'" +
                    " and Taken = 1" +
                    " and [Start Date] between '" + DateTime.Now.Year.ToString() +
                    "/01/01/' and '" + DateTime.Now.Year.ToString() + "/12/31';"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["Approved Days"] != null)
                        {
                            i += Convert.ToDouble(dr["Approved Days"]);
                        }
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }

    protected double TotalLeaveTakenAdjusted
    {
        get
        {
            double i = 0;

            try
            {
                SqlDataReader dr = new cConnect().ReadDB(
                    "select ([Leave Taken Adjusted])" +
                    " from [" + cSite.company_name + "$HR Employees]" +
                    " where ([No_] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "');"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        i += Convert.ToDouble(dr["Leave Taken Adjusted"]);

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }

    protected double BalanceBF
    {
        get
        {
            double i = 0;
            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select ([Leave Balance])" +
                    " from [" + cSite.company_name + "$HR Employees]" +
                    " where ([No_] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "');"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["Leave Balance"] != null)
                        {
                            i += Convert.ToDouble(dr["Leave Balance"]);
                        }
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }

    protected double ReimbersedLeaveDays
    {
        get
        {
            double i = 0;

            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select ([Reimbursed Leave Days])" +
                    " from [" + cSite.company_name + "$HR Employees]" +
                    " where ([No_] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "');"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["Reimbursed Leave Days"] != null)
                        {
                            i += Convert.ToDouble(dr["Reimbursed Leave Days"]);
                        }
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }

    protected double Ledger_ReimbersedLeaveDays
    {
        get
        {
            double i = 0; string num = cSite.ExternalUserID;
            string leaveType = this.ddlLeaveTypes.SelectedValue;

            try
            {
                string query =
                   "select SUM([No_ of days]) as days" +
                       " from [" + cSite.company_name + "$HR Leave Ledger Entries]" +
                       " where [Staff No_] = '" + num + "' " +
                       " and [Leave Entry Type] = '2' " + //Reimbursed option Type
                    //" and [Leave Type] = '" + leaveType + "' " +
                       " and [Closed] = '0' " +
                       " ;";
                SqlDataReader dr = new cConnect().ReadDB(query);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["days"] != null)
                        {
                            i += Convert.ToDouble(dr["days"]);
                        }
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }

    protected double Ledger_Total_Leave_Taken_ByLeaveType
    {
        get
        {
            double i = 0; string num = cSite.ExternalUserID;
            string leaveType = this.ddlLeaveTypes.SelectedValue;

            try
            {
                string query =
                   "select SUM([No_ of days]) as days" +
                       " from [" + cSite.company_name + "$HR Leave Ledger Entries]" +
                       " where [Staff No_] = '" + num + "' " +
                       " and [Leave Entry Type] = '1' " + //Reimbursed option Type
                       " and [Leave Type] = '" + leaveType + "' " +
                       " and [Closed] = '0' " +
                       " ;";
                SqlDataReader dr = new cConnect().ReadDB(query);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["days"] != null)
                        {
                            i += Convert.ToDouble(dr["days"]);
                        }
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }


    protected double Ledger_Allocated_Days
    {
        get
        {
            double i = 0; string num = cSite.ExternalUserID;
            string leaveType = this.ddlLeaveTypes.SelectedValue;

            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select SUM([No_ of days]) as days" +
                    " from [" + cSite.company_name + "$HR Leave Ledger Entries]" +
                    " where [Staff No_] = '" + num + "' " +
                    " and [Leave Entry Type] = '0' " + //Positive option Type
                    " and [Closed] = '0' " +
                    " ;"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["days"] != null)
                        {
                            i += Convert.ToDouble(dr["days"]);
                        }
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }

    protected double Ledger_Total_Taken_Days
    {
        get
        {
            double i = 0; string num = cSite.ExternalUserID;
            string leaveType = this.ddlLeaveTypes.SelectedValue;

            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select SUM([No_ of days]) as days" +
                    " from [" + cSite.company_name + "$HR Leave Ledger Entries]" +
                    " where [Staff No_] = '" + num + "' " +
                    " and [Leave Entry Type] = '1' " + //Negative option Type
                    " and [Leave Type] = '" + leaveType + "' " +
                    " and [Closed] = '0' " +
                    " ;"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["days"] != null)
                        {
                            i += Convert.ToDouble(dr["days"]);
                        }
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return i;
        }
    }


    protected bool ValidateEntries
    {
        get
        {
            bool b = false;

            try
            {
                if (this.ddlLeaveTypes.Items.Count <= 0)
                {
                    this.lblError.Text =
                        cSite.UserName +
                        ", You are required to select a leave type first. ";

                    Messaging.ShowAlert(this.lblError.Text);

                    return b;
                }

                if (this.ddlDaysApplied.Items.Count <= 0)
                {
                    this.lblError.Text =
                        cSite.UserName +
                        ", You cannot apply for a leave of type " +
                        this.ddlLeaveTypes.SelectedItem.Text +
                        ", as you have already taken all your leave days for the year " +
                        DateTime.Now.Year.ToString();

                    Messaging.ShowAlert(this.lblError.Text);

                    return b;
                }

                if (this.calStartDate.SelectedDate < (DateTime.Now))
                {
                    this.lblError.Text =
                        cSite.UserName +
                        ", The leave start date has to be from tomorrow or later, but not today.";

                    Messaging.ShowAlert(this.lblError.Text);

                    return b;
                }

                b = true;
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }

            return b;
        }
    }

    protected bool IsCarryForward
    {
        get
        {
            bool b = false;

            try
            {
                SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                    "select Balance" +
                    " from [" + cSite.company_name + "$HR Leave Type1]" +
                    " where [Code] = '" + cSite.ValidateEntry(this.ddlLeaveTypes.SelectedValue) + "'" +
                    "  and Balance = 1;"
                    );

                b = dr.HasRows;

                dr.Close();
            }
            catch (Exception ex)
            {
                cSite.SendErrorToDeveloper(ex);
                ex.Data.Clear();
            }
            return b;
        }
    }

    protected void LoadLeaveRelievers()
    {
        try
        {
            this.ddlReliever.Items.Clear();

            ListItem li = null;
            li = new ListItem("Select Reliever", "");
            this.ddlReliever.Items.Add(li);

            string query =
                "select * from [" + cSite.company_name + "$HR Employees]" +
                " where [First Name] <> '' and [Status] = 0  order by [First Name];";

            SqlDataReader dr = new cConnect().ReadDB(query);

            if (dr.HasRows)
                while (dr.Read())
                {
                    li = new ListItem(dr["First Name"].ToString() + " " + dr["Middle Name"].ToString() + " " + dr["Last Name"].ToString(), dr["No_"].ToString());
                    this.ddlReliever.Items.Add(li);
                }

            dr.Close();
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void LoadAppraisers()
    {
        try
        {
            this.ddlAppraisers.Items.Clear();

            SQL_ICAP.SqlDataReader dr = new cConnect().ReadDB(
                "select [No_],[First Name],[Middle Name],[Last Name]" +
                " from [" + cSite.company_name + "$HR Employees]" +
                " where  [Status]=0 and not ([No_] = '" + cSite.ValidateEntry(cSite.ExternalUserID) + "')" +
                " order by [First Name];"
                //" order by [Last Name],[Middle Name],[First Name] (Approver = 1) and;"
                );

            ListItem li = null;

            if (dr.HasRows)
                while (dr.Read())
                {
                    li = new ListItem(

                        dr["First Name"].ToString() + " " +
                        dr["Middle Name"].ToString() + " " +
                        dr["Last Name"].ToString() + " ",
                        dr["No_"].ToString()
                        );

                    this.ddlAppraisers.Items.Add(li);

                }
            dr.Close();

        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void LoadResponsibilityCenters()
    {
        try
        {
            this.ddlresponibilitycentres.Items.Clear();

            SqlDataReader dr = new cConnect().ReadDB(
                "select *" +
                " from [" + cSite.company_name + "$Responsibility Center BR] order by [Name];"
                );
            ListItem li = null;
            li = new ListItem("*******PLEASE SELECT******", ""); this.ddlresponibilitycentres.Items.Add(li);
            if (dr.HasRows)
                while (dr.Read())
                {
                    li = new ListItem(
                        dr["Name"].ToString(),
                        dr["Code"].ToString()
                        );

                    this.ddlresponibilitycentres.Items.Add(li);

                }
            dr.Close();

        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void ddlLeaveTypes_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddlLeaveTypes_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            string monthNumber = DateTime.Now.Month.ToString();
            Double monthValue = Convert.ToDouble(monthNumber);

            //string max = cSite.FormatNumber(this.MaximumLeaveDays);
            string max = cSite.FormatNumber(this.MaxLeaveDaysPerType);
            //now to get the leave days earned by current month as per the 1.75 days rate monthly

            Double perMonth = Convert.ToDouble(max) / 12;
            Double montlyEarnedMax = perMonth * monthValue;

            string Reimbursed = cSite.FormatNumber(this.Ledger_ReimbersedLeaveDays);

            Double totalLeaveDays = Convert.ToDouble(max) + Convert.ToDouble(Reimbursed);
            Double totalLeaveTakenByLeaveTypeSelected = this.Ledger_Total_Leave_Taken_ByLeaveType;
            Double remainingLeaveByType = totalLeaveDays - totalLeaveTakenByLeaveTypeSelected;

            this.ddlDaysApplied.Items.Clear();

            //this.lblInfo.Text = "Maximum Leave Days: " + max  +
            //    "<br>Total Leave Taken: " + taken +
            //    "<br>Remaining Leave Days: " +
            //    cSite.FormatNumber(Convert.ToDouble(max) - Convert.ToDouble(taken));

            //for (int i = 1; i <= (Convert.ToDouble(max) - Convert.ToDouble(taken)); i++)
            //    this.ddlDaysApplied.Items.Add(i.ToString());

            //this.ddlDaysApplied.SelectedIndex = Convert.ToInt32(Convert.ToDouble(max) - Convert.ToDouble(taken) - 1);

            //if (ddlLeaveTypes.SelectedValue == "ANNUAL")
            //{
            this.lblInfo.Text = "<b>Maximum Leave Days:</b> " + max +
                "&nbsp;&nbsp;&nbsp;&nbsp; <b>Reimbursed Leave Days:</b> " + Reimbursed +
                "&nbsp;&nbsp;&nbsp;&nbsp;<b>Total Leave Days:</b> " + totalLeaveDays +
                "<br /> <hr /> <b>Total Leave Taken:</b> " + totalLeaveTakenByLeaveTypeSelected +
                "&nbsp;&nbsp;&nbsp;&nbsp;<b>Leave Balance:</b> " +
                cSite.FormatNumber(remainingLeaveByType) +
                "<br /><br />";

            for (int i = 1; i <= (remainingLeaveByType); i++)
            {
                this.ddlDaysApplied.Items.Add(i.ToString());
            }

            this.ddlDaysApplied.SelectedIndex = Convert.ToInt32(remainingLeaveByType - 1);

            if (ddlLeaveTypes.SelectedValue != "TOIL")
            {
                if (this.ddlDaysApplied.Items.Count <= 0)
                {
                    this.lblError.Text =
                        cSite.UserName +
                        ", You cannot apply for a leave of type " +
                        this.ddlLeaveTypes.SelectedItem.Text +
                        ", as you have already taken all your leave days for the year " +
                        DateTime.Now.Year.ToString();

                    Messaging.ShowAlert(this.lblError.Text);
                }
            }
            //}
            //else
            //{
            //            this.lblInfo.Text = "Maximum Leave Days: " + max +
            //"<br>Total Leave Taken: " + taken +
            //"<br>Remaining Leave Days: " +
            //cSite.FormatNumber(max);

            //            ddlDaysApplied.Items.Clear();
            //            for (int i = 1; i <= (Convert.ToDouble(max)); i++)
            //                this.ddlDaysApplied.Items.Add(i.ToString());

            //            this.ddlDaysApplied.SelectedIndex = Convert.ToInt32(Convert.ToDouble(max) - 1);
            //            if (ddlLeaveTypes.SelectedValue != "TOIL")
            //            {
            //                if (this.ddlDaysApplied.Items.Count <= 0)
            //                {
            //                    this.lblError.Text =
            //                        cSite.UserName +
            //                        ", You cannot apply for a leave of type " +
            //                        this.ddlLeaveTypes.SelectedItem.Text +
            //                        ", as you have already taken all your leave days for the year " +
            //                        DateTime.Now.Year.ToString();

            //                    Messaging.ShowAlert(this.lblError.Text);
            //                }
            //            }
            //}

        }
        catch (Exception ex)
        {
           // lblInvalid.Text = ex.Message;
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
    }

    protected void gvLeaveApprovals_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string query = "";
            DataKey Id;
            int index = Convert.ToInt32(string.IsNullOrEmpty(e.CommandArgument.ToString()) == true ? "0" : e.CommandArgument);
            if (index < 0 || index > gvLeaveApprovals.Rows.Count - 1)
            {
                return;
            }
            GridView myview = (GridView)e.CommandSource;
            GridViewRow row = myview.Rows[index];

            Id = gvLeaveApprovals.DataKeys[row.RowIndex];
            string keyID = Id.Value.ToString();

            if (e.CommandName == "btnView")
            {
                MultiView1.ActiveViewIndex = 6;
                ViewLeaveDetails(keyID);
            }
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
        }
    }

    void ViewLeaveDetails(string LeaveEntryNo)
    {
        string query = ""; string t = ""; string applNo = ""; DateTime appDate, from, to = DateTime.Now;
        string empName = ""; string daysApplied = ""; Decimal days = 0; Boolean isNumber = false;
        string leaveType = "";
        try
        {
            applNo = this.LeaveAppNo(LeaveEntryNo);
            HttpContext.Current.Session["viewingLeaveAppNo"] = applNo;

            query =
               "select *, " +
               " (CASE [Status] WHEN 0 THEN 'New' WHEN 1 THEN 'Pending Approval' WHEN 2 THEN 'Approved' WHEN 3 THEN 'Rejected' " +
               " WHEN 4 THEN 'Cancelled' ELSE 'New' END) [Status Description] " +
               " from [" + cSite.company_name + "$HR Leave Application]" +
               " where [Application Code] = '" + applNo + "' ";

            SqlDataReader dr = new cConnect().ReadDB(query);

            if (dr.HasRows)
            {
                t = "<br /> <table id='trainAppDetails' style='border: silver thin ridge; width: 80%;'>";
                while (dr.Read())
                {
                    appDate = Convert.ToDateTime(dr["Application Date"].ToString());
                    leaveType = dr["Leave Type"].ToString();
                    from = Convert.ToDateTime(dr["Start Date"].ToString());
                    to = Convert.ToDateTime(dr["End Date"].ToString());
                    //empName = cSite.EmployeeNames(dr["Employee Name"].ToString());
                    daysApplied = dr["Days Applied"].ToString();
                    if (cSite.ValidNumber(daysApplied))
                    {
                        days = Convert.ToDecimal(daysApplied);
                        days = Math.Round(days, 2);
                        daysApplied = days.ToString();
                    }



                    t += "<tr><td>Application Date.:</td><td> <strong>" + appDate.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) + "</strong></td>";
                    t += "<td width='10px'> &nbsp; &nbsp; &nbsp; </td>";
                    t += "<tr><td>Employee Name:</td><td> <strong>" + dr["Names"].ToString() + "</strong></td>";
                    t += "</tr>";

                    t += "<tr><td>Days Applied:</td><td><strong>" + daysApplied + "</strong></td>";
                    t += "<td width='10px'> &nbsp; &nbsp; &nbsp; </td>";
                    t += "<tr><td>Status:</td><td><strong>" + dr["Status Description"].ToString() + "</strong></td>";
                    t += "</tr>";

                    t += "<tr><td>Leave Type:</td><td><strong>" + leaveType + "</strong></td>";
                    t += "<td width='10px'> &nbsp; &nbsp; &nbsp; </td>";
                    t += "<tr><td>Applicant Comments:</td><td><strong>" + dr["Applicant Comments"].ToString() + "</strong></td>";
                    t += "</tr>";

                    t += "<tr><td>From Date:</td><td> <strong>" + from.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) + "</strong></td>";
                    t += "<td width='10px'> &nbsp; &nbsp; &nbsp; </td>";
                    t += "<tr><td>To Date:</td><td><strong>" + to.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) + "</strong></td>";
                    t += "</tr>";

                    //t += "<tr><td>Station Name:</td><td> <strong>" + dr["Station Name"].ToString() + "</strong></td>";
                    //t += "<td width='10px'> &nbsp; &nbsp; &nbsp; </td>";
                    //t += "<tr><td>Provider Name:</td><td><strong>" + dr["Provider Name"].ToString() + "</strong></td>";
                    //t += "</tr>";

                    //t += "<tr><td>Location:</td><td> <strong>" + dr["Location"].ToString() + "</strong></td>";
                    //t += "<td width='10px'> &nbsp; &nbsp; &nbsp; </td>";
                    //t += "<tr><td>Purpose of Training:</td><td><strong>" + dr["Purpose of Training"].ToString() + "</strong></td>";
                    //t += "</tr>";

                    //t += "<tr><td>Financial Year:</td><td> <strong>" + dr["Financial Year"].ToString() + "</strong></td>";
                    //t += "<td width='10px'> &nbsp; &nbsp; &nbsp; </td>";
                    //t += "<tr><td>Directorate Name:</td><td><strong>" + dr["Directorate Name"].ToString() + "</strong></td>";
                    //t += "</tr>";
                }
                t = t + "</table>";
                this.gvRelieverView_PageIndexChanging(null, null);
            }
            else
            {
                t = "<br /> Training details view not available at the moment.";
            }

            this.litViewTraining.Text = t;
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
    }

    protected string LeaveAppNo(string EntryNo)
    {
        string i = "";

        try
        {
            string sqlQuery =
                "select [Document No_]" +
                " from [" + cSite.company_name + "$Approval Entry]" +
                " where ([Entry No] = '" + EntryNo + "' " +
                " and [Status] = 1 " +
                " );";

            SqlDataReader dr = new cConnect().ReadDB(sqlQuery);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["Document No_"] != null)
                    {
                        i = dr["Document No_"].ToString();
                    }
                }
            }
            else
            {
                i = "NOT SPECIFIED";
            }

            dr.Close();
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }

        return i;
    }

    protected void btnApproveLeave_Click(object sender, EventArgs e)
    {
        string applNo = ""; int docType = 21; string approverID = "";
        try
        {
            approverID = cSite.GetUserID;
            applNo = HttpContext.Current.Session["viewingLeaveAppNo"].ToString();
            cSite.Bandari_WebService.ApproveDocument(applNo, approverID);
            InsertApproverComments(applNo);

            Messaging.ShowAlert(String.Format("Leave request for application number: {0} approved successfully", applNo));
            lbApprove2_Click(null, null);
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
    }

    protected void btnRejectLeave_Click(object sender, EventArgs e)
    {
        string applNo = ""; int docType = 21; string approverID = ""; string approverComments = "";
        try
        {
            approverID = cSite.GetUserID;
            applNo = HttpContext.Current.Session["viewingLeaveAppNo"].ToString();
            approverComments = this.txtApproverComment.Text.Trim();
            if (approverComments == String.Empty || approverComments == "" || approverComments == null)
            {
                Messaging.ShowAlert("Kindly provide comments while rejecting");
                this.txtApproverComment.Focus();
                return;
            }

            cSite.Bandari_WebService.RejectDocument(applNo, approverID);
            InsertApproverComments(applNo);

            Messaging.ShowAlert(String.Format("Leave request for application number: {0} rejected successfully", applNo));
            lbApprove2_Click(null, null);
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
    }

    protected void InsertApproverComments(string applicationCode)
    {
        string query = ""; string approverComment = ""; string userID = cSite.Employee_UserId(); string empNum = cSite.ExternalUserID;
        try
        {
            approverComment = this.txtApproverComment.Text.Trim();
            if (approverComment.Length > 250)
            {
                Messaging.ShowAlert("Your comments have exceeded the maximum number of 250 chracters. Kindly review and send again.");
                return;
            }
            //query =
            //    "update [" + cSite.company_name + "$HR Comment Lines] set" +
            //            " [Approver Comments] = '" + approverComment + "'," +
            //            " where [Application Code] = '" + applicationCode + "';";
            cSite.Bandari_WebService.HR_Comments_Lines(applicationCode, approverComment, userID, empNum);

            cConnect cnt = new cConnect();
            cnt.WriteDB(query);
            cnt.Dispose();
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
    }

    protected void gvPending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string approverID = ""; string approverName = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // loop all data rows
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = (ImageButton)control;
                        if (button.CommandName == "btncancel")
                        {
                            button.OnClientClick = "if (!confirm('Are you sure you want to cancel this leave application?')) return;";
                        }
                    }
                }

                //Literal litApprover = (Literal)e.Row.FindControl("litApprover");
                //approverID = ((DataRowView)e.Row.DataItem)["Approver ID"].ToString();
                //approverName = cSite.EmployeeNames_By_UserID(approverID);

                //if (approverID != "" && approverID != string.Empty && approverID != null)
                //{
                //    litApprover.Text = approverName;
                //}
                //else
                //{
                //    litApprover.Text = "Undefined";
                //}

            }
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
    }

    protected Boolean AddpendingAssignments(string DocumentNo)
    {
        Boolean insert = false;
        try
        {
            foreach (GridViewRow oItem in this.Gridview1.Rows)
            {
                TextBox box2 = (TextBox)oItem.Cells[1].FindControl("TextBox2");
                DropDownList box3 = (DropDownList)oItem.Cells[3].FindControl("TextBox3");

                string documentNo = DocumentNo;
                string pendingAssignments = box2.Text;
                string relieverNo = box3.SelectedValue;
                string relieverName = box3.SelectedItem.Text;
                string applicantNo = cSite.ExternalUserID;

                cSite.Bandari_WebService.HR_Leave_Relievers
                    (documentNo, pendingAssignments, relieverNo, relieverName, applicantNo);

                //new cConnect().WriteDB(
                //  "insert into [" + cSite.company_name + "$HR Leave Relievers]" +
                //  " ([Applicant No],[Document No],[Pending Assignment],[Reliever No]," +
                //  "[Reliever Name]) values(" +
                //  " '" + cSite.ValidateEntry(this.lblNo.Text) + "'," +
                //  " '" + cSite.ValidateEntry(this.lblApplicationCode.Text) + "'," +
                //  " '" + cSite.ValidateEntry(box2.Text) + "'," +
                //  " '" + cSite.ValidateEntry(box3.SelectedValue) + "'," +
                //  " '" + cSite.ValidateEntry(box3.SelectedItem.Text) + "'" +
                //  ");"
                //  );

                insert = true;
            }
        }
        catch (Exception ex)
        {
            cSite.SendErrorToDeveloper(ex);
            ex.Data.Clear();
        }
        return insert;
    }
    
    protected void gvRelieverView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        String strConnString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        string leaveApplicationNo = "";
        SqlConnection con = null;
        try
        {
            if (HttpContext.Current.Session["viewingLeaveAppNo"] != null)
            {
                leaveApplicationNo = HttpContext.Current.Session["viewingLeaveAppNo"].ToString();
            }

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "Get_Leave_Relievers_List";
            cmd.Parameters.Add("@LeaveApplicationNo", SqlDbType.VarChar, 20).Value = leaveApplicationNo;

            con = new SqlConnection(strConnString);
            cmd.Connection = con;

            con.Open();

            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            gvRelieverView.DataSource = dt;
            gvRelieverView.EmptyDataText = "No Leave Relievers found for this document.";

            gvRelieverView.DataBind();
        }

        catch (Exception ex)
        {
            ex.Data.Clear();
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }


}


        }