<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoanStatus.aspx.cs" Inherits="Bandari_Sacco.LoanStatus" %>
 <%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Bandari_Sacco.controller" %>
<%@ Import Namespace="Bandari_Sacco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset>
<legend>Loan Status Trail</legend>
<div class="Home_Master">


<table class="table table-striped"> <!--class="MyStamentbls" style="padding-top: 50px;" width="100%"-->
<thead>
<tr>
<th colspan="" style="border-right: 0px solid #DDD;">#</th>
<th>Product No</th>
<th>Product Type</th>
<th>Application Date</th>
<th>Date Approved</th>
<th>Issued Date</th>
<th>Disbursement Date</th>
</tr>
</thead>
<tbody>

<%
    string Loan_No = "", Loan_Type = "", Application_Date = "", Status = "", Date_Approved = "", Issued_Date = "", Loan_Disbursement_Date="";

    string Member_No_ = Session["Member_No"].ToString();

    using (SqlConnection conn = MyClass.getconnToNAV())
    {
        string s = "select a.[Loan  No_],replace(CONVERT(VARCHAR,a.[Application Date],103),'/','-') as [Application Date]," +
    " replace(CONVERT(VARCHAR,a.[Date Approved],103),'/','-') as [Date Approved] ,replace(CONVERT(VARCHAR,a.[Issued Date],103),'/','-') as [Issued Date]" +
    ",replace(CONVERT(VARCHAR,a.[Loan Disbursement Date],103),'/','-') as [Loan Disbursement Date]," +
    "a.[Loan Status],b.[Product Description] FROM [" + MyClass.CompanyName + "$Loans] a,[" + MyClass.CompanyName + "$Loan Product Types] b" +
                " WHERE (a.[Member No_] = @Member_No  )" +
                        " AND Posted=0 AND a.[Loan Status]<>'2' ;";

        SqlCommand command = new SqlCommand(s, conn);
        command.Parameters.AddWithValue("@Member_No", Member_No_);

        using (SqlDataReader dr = command.ExecuteReader())
        {

            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    i++;
                    Loan_No = dr["Loan  No_"].ToString();
                    Loan_Type = dr["Product Description"].ToString();
                    Application_Date = dr["Application Date"].ToString();
                    Date_Approved = dr["Date Approved"].ToString();
                    Issued_Date = dr["Issued Date"].ToString();
                    Loan_Disbursement_Date = dr["Loan Disbursement Date"].ToString();
                    Status = dr["Loan Status"].ToString();

                    if (Date_Approved == "01-01-1753")
                    {
                        Date_Approved = "-";
                    }

                    if (Issued_Date == "01-01-1753")
                    {
                        Issued_Date = "-";
                    }

                    if (Loan_Disbursement_Date == "01-01-1753")
                    {
                        Loan_Disbursement_Date = "-";
                    }

                    switch (Status)
                    {
                        case "0":
                            Status = "Application";
                            break;
                        case "1":
                            Status = "Appraisal";
                            break;
                        case "2":
                            Status = "Rejected";
                            break;
                        case "3":
                            Status = "Approved";
                            break;
                        case "4":
                            Status = "Committe";
                            break;
                        default:
                            Status = "Application";
                            break;
                    }

                    if (i % 2 == 0)
                    {                          
                          %> 
                          
            <tr>
             <td class="eventd"><%=i%></td>
             <td class="eventd"><%=Loan_No%></td>
             <td class="eventd"><%=Loan_Type%></td>
             <td class="eventd"><%=Application_Date%></td>
             <td class="eventd"><%=Date_Approved%></td>
             <td class="eventd"><%=Issued_Date%></td>
             <td class="eventd"><%=Loan_Disbursement_Date%></td>
  
            </tr>   
            <%}
                    else
                    { %> 
            <tr>
              <td class="oddtd"><%=i%></td>
              <td class="oddtd"><%=Loan_No%></td>
              <td class="oddtd"><%=Loan_Type%></td>
              <td class="oddtd"><%=Application_Date%></td>
              <td class="oddtd"><%=Date_Approved%></td>
              <td class="oddtd"><%=Issued_Date%></td>
              <td class="oddtd"><%=Loan_Disbursement_Date%></td>
              
            </tr>                    
                      
                     <% }
                }

            }
            else
            { %>
                <tr>
                <td colspan='7'>
              <center style='color:Red;'> No record</center>
                
                </td>
                </tr>  
                  
                  
                 <% }

        }
        conn.Close();
    }

                
                
                %>

</tbody>
</table>
</div>
</fieldset>
</asp:Content>
