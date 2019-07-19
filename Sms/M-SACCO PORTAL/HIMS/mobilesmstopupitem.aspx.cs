using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;    

namespace HIMS
{
    public partial class mobilesmstopupitem : System.Web.UI.Page  
    {
        private long _idx = 0;
        private string str_idx = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            str_idx = Request.QueryString["idx"];
            bool b = long.TryParse(str_idx, out _idx);

            if (!IsPostBack) //to show the Data on runtime
            {
                frmview(); //calling  the function of formview
            }
        }

        private void frmview()  // to make a function of formview
        {
            try
            {
                DataTable dtMap = null;
                //string empno = SiteFunctions.CurrentUserID;

                dtMap = new admindesk.FUNCTIONCLASSES.mobileSmsTopup().GetTablemobileSmsTopup(_idx);
                 
                //Persist the table in the Session object.
                Session["dtMapTable"] = dtMap;

                //Bind the GridView control to the data source.
                this.fvMap.EmptyDataText = "No Records";
                this.fvMap.DataSource = Session["dtMapTable"];// dtMap;
                //this.fvMap.DataBind();

                if (_idx > 0)
                    fvMap.ChangeMode(FormViewMode.Edit);
                else
                    fvMap.ChangeMode(FormViewMode.Insert);

                this.fvMap.DataBind();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

        }

        protected void fvMap_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        {
            //Label id = ((Label)(fvMap.Row.FindControl("lbl_delete")));
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}

            //cmd = new SqlCommand("delete from tbformview where id=@id", con);
            //cmd.Parameters.AddWithValue("@id", id.Text);
            //cmd.ExecuteNonQuery();
            //cmd.Dispose();
            //con.Close();

            //fvMap.ChangeMode(FormViewMode.ReadOnly);
            //frmview();
        }
        protected void fvMap_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            //Label id = ((Label)(fvMap.Row.FindControl("lbl_edit")));
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //cmd = new SqlCommand("update tbformview set Name=@Name,Class=@Class,Address=@Address where id=@id", con);
            //cmd.Parameters.AddWithValue("@Name", ((TextBox)(fvMap.Row.FindControl("Txt_ename"))).Text);
            //cmd.Parameters.AddWithValue("@Class", ((TextBox)(fvMap.Row.FindControl("Txt_eclass"))).Text);
            //cmd.Parameters.AddWithValue("@Address", ((TextBox)(fvMap.Row.FindControl("Txt_eaddress"))).Text);
            //cmd.Parameters.AddWithValue("@id", id.Text);
            //cmd.ExecuteNonQuery();
            //cmd.Dispose();
            //fvMap.ChangeMode(FormViewMode.ReadOnly);
            //frmview();
            //con.Close();
        }
        protected void fvMap_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            fvMap.PageIndex = e.NewPageIndex; //paging
            frmview();
        }
        protected void fvMap_ModeChanging(object sender, FormViewModeEventArgs e)//mode of formsview
        {
            if (e.NewMode == FormViewMode.Edit)
                fvMap.ChangeMode(FormViewMode.Edit); //will change into Edit Mode
            else
                fvMap.ChangeMode(FormViewMode.ReadOnly); //Will Change into Template mode.
            frmview();
        }
        protected void fvMap_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName.ToLower())
                {
                    case "insert":
                        {
                            string _saccoCode =  SiteFunctions.GetFormViewDropDownListValue(this.fvMap, "ddlInsertSacco");
                            long _smsCount =long.Parse( SiteFunctions.GetFormViewTextBoxValue(this.fvMap, "txtInsertSmsCount"));
                            string _comments = SiteFunctions.GetFormViewTextBoxValue(this.fvMap, "txtInsertComments");

                            admindesk.FUNCTIONCLASSES.mobileSmsTopup _new = new admindesk.FUNCTIONCLASSES.mobileSmsTopup();
                            _new.sacco = _saccoCode;
                            _new.smscount = _smsCount;
                            _new.comments = _comments;
                            _new.userid = SiteFunctions.CurrentUserID;
                            _new.InsertRecord();

                            Response.Redirect("~/mobilesmstopup.aspx", false);

                            break;
                        }
                    case "update":
                        {
                            string _saccoCode =  SiteFunctions.GetFormViewDropDownListValue(this.fvMap, "ddlEditSacco");
                            long _smsCount =long.Parse( SiteFunctions.GetFormViewTextBoxValue(this.fvMap, "txtEdittSmsCount"));
                            string _comments = SiteFunctions.GetFormViewTextBoxValue(this.fvMap, "txtEditComments");

                            admindesk.FUNCTIONCLASSES.mobileSmsTopup m_map = new admindesk.FUNCTIONCLASSES.mobileSmsTopup().GetmobileSmsTopup(_idx);
                            m_map.sacco = _saccoCode;
                            m_map.smscount = _smsCount;
                            m_map.comments = _comments;
                            m_map.userid = SiteFunctions.CurrentUserID; //_userid;
                            m_map.UpdateRecord();

                            Response.Redirect("~/mobilesmstopup.aspx", false);

                            break;
                        }
                    case "cancelupdate":
                        {
                            Response.Redirect("~/mobilesmstopup.aspx", false);
                            break;
                        }
                    case "cancelinsert":
                        {
                            Response.Redirect("~/mobilesmstopup.aspx", false);
                            break;
                        }
                    default:
                        break;
                }
                // FOR THE MODE TO CHANGE CALL DATA BIND.
                fvMap.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
        protected void fvMap_ItemInserting(object sender, FormViewInsertEventArgs e)
        {

        }
        protected void fvMap_DataBound(object sender, EventArgs e)
        {
            switch (fvMap.CurrentMode)
            {
                case FormViewMode.Insert:
                    {
                        DropDownList ddlInsertSacco = (DropDownList)fvMap.FindControl("ddlInsertSacco");
                        DataTable dt2 = new admindesk.FUNCTIONCLASSES.SaccoInformation().GetTableSaccoInformation();
                        if (ddlInsertSacco != null)
                        {
                            ddlInsertSacco.DataSource = dt2;
                            ddlInsertSacco.DataTextField = "SaccoName";
                            ddlInsertSacco.DataValueField = "SaccoCode";
                            ddlInsertSacco.DataBind();
                        }                                                
                        break;
                    }
                case FormViewMode.Edit:
                    {
                        DropDownList ddlEditSacco = (DropDownList)fvMap.FindControl("ddlEditSacco");
                        bool isActive = true;
                        DataTable dt2 = new admindesk.FUNCTIONCLASSES.SaccoInformation().GetTableSaccoInformation();
                        if (ddlEditSacco != null)
                        {
                            ddlEditSacco.DataSource = dt2;
                            ddlEditSacco.DataTextField = "SaccoName";
                            ddlEditSacco.DataValueField = "SaccoCode";
                            ddlEditSacco.DataBind();
                            ddlEditSacco.SelectedValue = fvMap.DataKey.Values["Sacco"].ToString(); 
                        }
                        break;
                    }
            }
        }


    
    }

}