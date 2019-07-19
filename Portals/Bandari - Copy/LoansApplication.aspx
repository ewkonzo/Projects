<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoansApplication.aspx.cs" Inherits="Bandari_Sacco.LoansApplication" %>
<%@Import Namespace="System.Web"%>
<%@Import Namespace="System.Web.UI"%>
<%@Import Namespace="System.Data"%>
<%@Import Namespace="System.IO"%>
<%@Import Namespace="System.Data.SqlClient"%>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Bandari_Sacco.controller" %> 
<%@ Import Namespace="Bandari_Sacco" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="col-xs-12">
                 <div class="panel panel-default">
                <div class="panel-heading"><i class="fa fa-pencil-square-o"></i> Loan Application</div>
                <div class="panel-body">
  <table class="table table-responsive table-condensed">
           <tr>
            <td>Loan Type:</td>
          
            <td>
                <asp:DropDownList ID="ddlLoanTypes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLoanTypes_SelectedIndexChanged" 
                    CssClass="form-control">
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Basic Pay:"></asp:Label>
            </td>
            <td><asp:TextBox ID="txtBasicPay" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBasicPay" 
CssClass="failureNotification" ErrorMessage="Basic Pay required." ToolTip="Basic Pay is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">Required</span></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBasicPay" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

                    </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Loan Amount:" Width="100px"></asp:Label></td>
         
            <td>
                <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoanAmount" 
CssClass="failureNotification" ErrorMessage="Loan Amount required." ToolTip="Loan amount is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">Required</span></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLoanAmount" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

            </td>
            <td>
                Total Allowances:</td>
            <td>
                <asp:TextBox ID="txtTotalAllowances" runat="server" CssClass="form-control"></asp:TextBox>

     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTotalAllowances" 
CssClass="failureNotification" ErrorMessage="Total Allowances required." ToolTip="Total Allowances is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">Required</span></asp:RequiredFieldValidator>

         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTotalAllowances" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td>
                Repayment Period (<em><strong>in months</strong></em>):</td>
          
            <td>
                <asp:DropDownList ID="ddlRepaymentPeriod" runat="server" CssClass="form-control">
                </asp:DropDownList>

                  <asp:Label ID="lblRepaymentPeriod" Visible="false" runat="server"></asp:Label>
            </td>
            <td>
                Total Deductions:</td>
            <td>
                <asp:TextBox ID="txtTotalDeductions" runat="server" CssClass="form-control"></asp:TextBox>

      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTotalDeductions" 
CssClass="failureNotification" ErrorMessage="Total Deductions required." ToolTip="Total Deductions is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">Required</span></asp:RequiredFieldValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTotalDeductions" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td>Interest Rate (<strong><em>per month</em></strong>):</td>
           
            <td><asp:Label ID="lblInterestRate" runat="server"></asp:Label>
                        <asp:Label ID="lblError" runat="server" CssClass="label label-warning"></asp:Label>

            </td>
            <td>Net Income:</td>
            <td>
                <asp:Label ID="lblNetIncome" runat="server" CssClass="form-control"></asp:Label>
            </td>
        </tr>
      <tr><td></td><td></td><td></td><td>
          <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="btn btn-info" OnClick="btnCalculate_Click" />
          </td></tr>
        <tr>

        <% 
      
        string LoanApplicationNo = string.Empty;

        if (Request.QueryString["LNo"] != null)
        {
            LoanApplicationNo = Request.QueryString["LNo"];
        }
        
        string Question = "", Answer = "", Id="";

     //string Random = Mwalimu_Sacco.controller.MyClass.getRandomString().ToUpper();

     string Description = "";

     string Pin_No = "";

     string Files_Id = "", Document_Name = "", File_Url = "", Uploaded_By = "", Date_Uploaded = "";

     if (Request.QueryString["option"] == "ViewDocument" && Request.QueryString["Url"] != null && Request.QueryString["Desc"] != null)
     {
         string filepath, file_download = "";
         file_download = Request.QueryString["Url"];
         filepath = file_download;
         string filename = Path.GetFileName(filepath);
         System.IO.Stream stream = null;
         Response.Write(file_download);

         try
         {
             string Filepath = file_download;
             if (null != Filepath)
             {
                 if (File.Exists(Filepath))
                 {
                     String FileName = Path.GetFileName(Filepath);

                     Response.Clear();
                     Response.ContentType = "Application/octet-stream";
                     Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                     Response.WriteFile(Filepath);
                     Response.End();
                 }
             }

         }
         catch (Exception ex)
         {
             // Response.Write(ex.Message);
         }
         finally
         {
             if (stream != null)
             {
                 stream.Close();
             }
         }
     }

     if (Request.QueryString["option"] == "RemoveDocument" && Request.QueryString["Url"] != null && Request.QueryString["mid"] != null)
     {
         string Document_Path = "", ID = "";

         Document_Path = Request.QueryString["Url"];
         ID = Request.QueryString["mid"].ToString().Trim();

         using (SqlConnection conn =MyClass.getconnToNAV())
         {
             SqlCommand cmdDeleteFileType = new SqlCommand();
             cmdDeleteFileType.CommandText = "DELETE FROM [" + MyClass.CompanyName + "$Online Documents] WHERE [Entry No]=@Files_Id";
             cmdDeleteFileType.CommandType = CommandType.Text;
             cmdDeleteFileType.Connection = conn;
             cmdDeleteFileType.Parameters.Add("@Files_Id", SqlDbType.Int).Value = ID;
             cmdDeleteFileType.ExecuteNonQuery();

             conn.Close();

             string filename = Path.GetFileName(Document_Path);

             if (File.Exists(Document_Path))
             {
                 try
                 {
                     File.Delete(Document_Path);

                 }
                 catch (Exception ex)
                 {

                 }
             }
         }
         Response.Redirect("NewLoanApplication.aspx?option=NewLoanApplication&action=Downloads&action=LoanApplication&LNo=" + LoanApplicationNo);
        
         
     }
    
            
            using (SqlConnection conn = MyClass.getconnToNAV())
            {

                string s_G = String.Format("SELECT * FROM [{0}$Online Documents] WHERE [Loan Application No] = @LoanApplicationNo ", MyClass.CompanyName);
                SqlCommand command_G = new SqlCommand(s_G, conn);
                command_G.Parameters.AddWithValue("@LoanApplicationNo", LoanApplicationNo);
                using (SqlDataReader drDownloads = command_G.ExecuteReader())
                {
                    if (drDownloads.HasRows)
                    {

                        drDownloads.Read();
                        Files_Id = drDownloads["Entry No"].ToString();
                        Document_Name = drDownloads["File Name"].ToString();
                        File_Url = drDownloads["File Url"].ToString();
                        Uploaded_By = drDownloads["Uploaded By"].ToString();
                        Date_Uploaded = drDownloads["Date Uploaded"].ToString();
                        
                        %>
                    <td>Pay Slip </td>
                   <td><i class="fa fa-file-pdf-o"></i> <%=Document_Name%></td>
                   <td>
               <span>   
             <a href='NewLoanApplication.aspx?action=LoanApplication&option=ViewDocument&mid=<%=Files_Id%>&Url=<%=File_Url%>&Desc=<%=Document_Name %>' title="Open"><i class="fa fa-download"></i> Download</a>
               </span>    
               </td>
                   <td>               
                      <span style="padding-top:3px;">   
                 <a href='NewLoanApplication.aspx?action=LoanApplication&option=RemoveDocument&mid=<%=Files_Id%>&Url=<%=File_Url%>&Desc=<%=Document_Name %>&LNo=<%=LoanApplicationNo %>' title="Remove"><i class="fa fa-remove"></i> Remove</a>
                   </span>           
                    </td>
                    

                        <%
                        
                    }
                    else
                    {
                        %>
                 <td>Latest Payslip</td>
        <td>
            <asp:FileUpload ID="FileUploadDownloads" runat="server"  />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUploadDownloads" 
            CssClass="failureNotification" ErrorMessage="Total Deductions required." ToolTip="Total Deductions is required." 
            ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">Required</span></asp:RequiredFieldValidator>
        </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
                            
                    <%}
                }
                conn.Close();
            }
            
             %>

   

        </tr>

        <tr>
        <td colspan="4">

        <table class="table table-bordered table-responsive table-condensed">
        <tr>
        <th>#</th>
        <th>Member No</th>
        <th>Member Name</th>
        <th>Phone</th>
          <th>Status</th>
        </tr><%
                    string Guarontor_No = "";
                    string Guarontor_Name = "";
                    string Phone = "";
                    string GuarontorStatus = "";

                    using (SqlConnection conn = MyClass.getconnToNAV())
                    {

                        string s_G = String.Format("SELECT [Member No],Names,Telephone,[Approval Status] as Approved FROM [{0}$Online Loan Guarantors] WHERE [Loan Application No] = @LoanApplicationNo ", MyClass.CompanyName);
                        SqlCommand command_G = new SqlCommand(s_G, conn);
                        command_G.Parameters.AddWithValue("@LoanApplicationNo", LoanApplicationNo);
                        using (SqlDataReader dr1_G = command_G.ExecuteReader())
                        {
                            if (dr1_G.HasRows)
                            {
                                int i = 0;
                                while (dr1_G.Read())
                                {
                                    i++;
                                    Guarontor_No = dr1_G["Member No"].ToString();
                                    Guarontor_Name = dr1_G["Names"].ToString();
                                    Phone = dr1_G["Telephone"].ToString();
                                    GuarontorStatus = dr1_G["Approved"].ToString();
                    %>
                    <tr>
                     <td><%=i%></td>
                    <td><%=Guarontor_No%></td>
                    <td><%=Guarontor_Name%></td>
                    <td><%=Phone%></td>
                    <td><%=GuarontorStatus%></td>
                    </tr>
                    <%
                                }
                            }
                        }

                        conn.Close();

                    }
        
                    %>

        <tr>      
            <td colspan="4">
            <asp:Button ID="BtnAddNewPartner" runat="server" Text="Add a New Guarantor"  CssClass="btn btn-warning"
            ValidationGroup="LoginUserValidationGroup" onclick="BtnAddNewPartner_Click"   />
                <asp:Button ID="btnApplyLoan" runat="server" Visible="False" Text="Apply Loan" CssClass="btn btn-success" ValidationGroup="LoginUserValidationGroup" OnClick="btnApplyLoan_Click"
                 />
            </td>
        </tr>

        </table>     
        </td>
          </tr>
         <tr>
            <td 
                valign="bottom" align="left" style="border-bottom:3px;">
                &nbsp;</td>
            <td valign="bottom" align="right" style="border-bottom:3px;">
                &nbsp;</td>
        </tr>

         <tr>
            <td 
                valign="bottom" align="left" style="border-bottom:3px;">
                &nbsp;</td>
            <td valign="bottom" align="right" style="border-bottom:3px;">
                &nbsp;</td>
        </tr>

    </table>      

</div>
                     </div>
        </div>
</asp:Content>
