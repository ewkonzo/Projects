<%@ Page Title="Guarantors" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Guarantors.aspx.cs" Inherits="Bandari_Sacco.Guarantors" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Bandari_Sacco.controller" %>
<%@ Import Namespace="Bandari_Sacco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: silver thin ridge;width:90%;">
<tr>
<th colspan="8" style="border-bottom:1px solid #bbb">
  <div style="font-weight:bold;text-transform:uppercase;"><center>GUARANTORS</center></div>
</th>
</tr>
<tr>
<th style="border-right:1px solid #BBB;width:10px;">
#
</th>
<th>
Loan No
</th>
<th>
Loan Type
</th>
<th>
Issue Date
</th>
<th>
Term (Months)
</th>
<th>
End Date
</th>
<th>
Approved Amount
</th>
<th>
Outstanding Balance
</th>
</tr>



            <%
                string Loan_No_ = "", Loan_Type = "", Issue_Date = "", Term = "", End_Date = "", Approved_Amount = "0", Outstanding_Balance = "0";
                string MemberNo_ = "", GuarantorName = "";
                double Amont_Guaranteed = 0;
                DateTime End_Date_ = DateTime.Now;

                double Approved_Amount_ = 0, Outstanding_Balance_ = 0;
                //string CompanyName = "PostBank Sacco Society Ltd";
                //string query2 = "SELECT a.[Loan  No_],a.[Issued Date],a.[Application Date],a.Installments,a.[Approved Amount],b.[Product Description]" +
                //" FROM [" + Controller.CompanyName + "$Loans] a,[" + Controller.CompanyName + "$Loan Product Types] b" +
                //" WHERE [Member No_]=@Member_No AND a.[Loan Product Type]=b.[Code] ORDER BY [Application Date] DESC";

                string query2 = "SELECT a.[Loan  No_],a.[Loan Disbursement Date],a.[Application Date],a.Installments,a.[Approved Amount],b.[Product Description]" +
               " FROM [" + Controller.CompanyName + "$Loans] a,[" + Controller.CompanyName + "$Product Factory] b" +
               " WHERE [Member No_]=@Member_No AND AND a.[Loan Product Type]=b.[Product ID] ORDER BY [Application Date] DESC"; 
                
                try
                {
                    SqlDataReader dataReader = new CRUD().extractData(CRUD.getconnToNAV(), query2);
                    if (dataReader.HasRows)
                {
                    int i = 0;
                    while (dataReader.Read())
                    {
                        i++;

                        Loan_No_ = dataReader["Loan  No_"].ToString();
                        DateTime dt = DateTime.Now;

                        //if (dataReader["Issued Date"] != null)
                        //{
                        //    dt = Convert.ToDateTime(dataReader["Issued Date"]);
                        //}

                        if (dataReader["Loan Disbursement Date"] != null)
                        {
                            dt = Convert.ToDateTime(dataReader["Loan Disbursement Date"]);
                        }
                        else if (dataReader["Application Date"] != null)
                        {
                            dt = Convert.ToDateTime(dataReader["Application Date"]);
                        }
                        Loan_Type = dataReader["Product Description"].ToString().ToUpper();
                        Issue_Date = dt.ToString("dd-MM-yyyy");
                        Term = dataReader["Installments"].ToString();
                        End_Date_ = Convert.ToDateTime(dt.AddMonths(Convert.ToInt32(dataReader["Installments"])).ToShortDateString());
                        End_Date = End_Date_.ToString("dd-MM-yyyy");
                        Approved_Amount_ = Convert.ToDouble(dataReader["Approved Amount"].ToString());
                        Outstanding_Balance_ = MyClass.OutstandingSpecificLoanBalanceWithConnection(Loan_No_, CRUD.getconnToNAV());

                        if (Outstanding_Balance_ > 0.1)
                        {

                            if (i % 2 == 0)
                            {

                            
                      %>  
                       <tr>
                       <td style="border-right:1px solid #BBB;width:10px;" class="eventd"><%=i%></td>
                       <td class="eventd"><%=Loan_No_%></td>
                        <td class="eventd"><%=Loan_Type%></td>
                       <td class="eventd"><%=Issue_Date%></td>
                       <td class="eventd"><%=Term%></td>
                       <td class="eventd"><%=End_Date%></td>
                       <td class="eventd"><%=String.Format("{0:0,0.00}", Approved_Amount_)%></td>
                       <td class="eventd"><%=String.Format("{0:0,0.00}", Outstanding_Balance_)%></td>
                       </tr>

                       <tr>
                       <td class="eventd" style="border-right:1px solid #BBB;width:10px;"></td>
                       <td class="eventd" colspan="7">
                       <table style="width:100%">
                       <tr>
                  <td class="eventd" style="font-weight:bold;" colspan="4">LOAN <%=Loan_No_%> GUARANTORS</td>
                       </tr>
                       <tr>
                     <td style="font-weight:bold;border-right:1px solid #BBB;width:10px;">#</td>
                     <td style="font-weight:bold;">Member No</td>
                     <td style="font-weight:bold;">Member Name</td>
                     <td style="font-weight:bold;">Amount Guaranteed</td>
                       </tr>
                       <%                             
                                

                                string Q = "SELECT  b.[Member No],b.Name,b.[Amont Guaranteed] FROM  [" + Controller.CompanyName + "$Loans] a,[" + Controller.CompanyName + "$Loan Guarantors] b WHERE a.[Loan  No_]=b.[Loan No]" +
                                 " AND a.[Loan  No_]=@Loan_No_ AND b.[Amont Guaranteed]>0";
                                try
                                {
                                    SqlDataReader dataReader1 = new CRUD().extractData(CRUD.getconnToNAV(), Q);
                                    if (dataReader1.HasRows)
                                    {
                                        int b = 0;
                                        while (dataReader1.Read())
                                        {
                                            b++;
                                            MemberNo_ = dataReader1["Member No"].ToString();
                                            GuarantorName = dataReader1["Name"].ToString();
                                            Amont_Guaranteed = Convert.ToDouble(dataReader1["Amont Guaranteed"].ToString());                      
                        %>
                    <tr>
                    <td style="border-right:1px solid #BBB;width:10px;" class="eventd"><%=b%></td> 
                    <td class="eventd"><%=MemberNo_%></td>
                    <td class="eventd"><%=GuarantorName%></td> 
                    <td class="eventd"><%=String.Format("{0:0,0.00}", Amont_Guaranteed)%></td>
                    </tr>

                   <% }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    ex.Data.Clear();
                                }
            %>
            </table>
            </td>
                 </tr>

                   <% 
                            }
                            else
                            {%>

                          <tr>
                       <td style="border-right:1px solid #BBB;width:10px;" class="oddtd"><%=i%></td>
                       <td class="oddtd"><%=Loan_No_%></td>
                        <td class="oddtd" style="border-bottom:0px solid red;"><%=Loan_Type%></td>
                       <td class="oddtd"><%=Issue_Date%></td>
                       <td class="oddtd"><%=Term%></td>
                       <td class="oddtd"><%=End_Date%></td>
                       <td class="oddtd"><%=String.Format("{0:0,0.00}", Approved_Amount_)%></td>
                       <td class="oddtd"><%=String.Format("{0:0,0.00}", Outstanding_Balance_)%></td>
                       </tr>

                     <tr>
                     <td class="oddtd" style="border-right:1px solid #BBB;width:10px;"></td>
                       <td class="oddtd" colspan="7">
                       <table style="width:100%">
                       <tr>
                       <td class="oddtd" style="font-weight:bold;" colspan="4">LOAN <%=Loan_No_%> GUARANTORS</td>
                       </tr>
                          <tr>
                     <td style="font-weight:bold;border-right:1px solid #BBB;width:10px;">#</td>
                     <td style="font-weight:bold;">Member No</td>
                     <td style="font-weight:bold;">Member Name</td>
                     <td style="font-weight:bold;">Amount Guaranteed</td>
                       </tr>
                       <%     


                                string A = "SELECT  b.[Member No],b.Name,b.[Amont Guaranteed] FROM  [" + Controller.CompanyName + "$Loans] a,[" + Controller.CompanyName + "$Loan Guarantors] b WHERE a.[Loan  No_]=b.[Loan No]" +
                                 " AND a.[Loan  No_]=@Loan_No_ AND b.[Amont Guaranteed]>0";
                                try
                                {
                                    SqlDataReader dataReader2 = new CRUD().extractData(CRUD.getconnToNAV(), A);
                                    if (dataReader2.HasRows)
                                    {
                                        int b = 0;
                                        while (dataReader2.Read())
                                        {
                                            b++;
                                            MemberNo_ = dataReader2["Member No"].ToString();
                                            GuarantorName = dataReader2["Name"].ToString();
                                            Amont_Guaranteed = Convert.ToDouble(dataReader2["Amont Guaranteed"].ToString());                      
                        %>
                    <tr>
                    <td style="border-right:1px solid #BBB;width:10px;" class="oddtd"><%=b%></td> 
                    <td class="oddtd"><%=MemberNo_%></td>
                    <td class="oddtd"><%=GuarantorName%></td> 
                    <td class="oddtd"><%=String.Format("{0:0,0.00}", Amont_Guaranteed)%></td>
                    </tr>

                   <% }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    ex.Data.Clear();
                                }
            %>
            </table>
            </td>
                 </tr>
                            
                        <%}
                        }
                        else {
                            i--;
                        }
                    }
                }
                
                else { %>
             <tr>
             <td colspan="8"><center><center style='color:Red;'> No record</center></center></td>
             </tr>  
                
               <% }


                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                
                 %>


</table>
</asp:Content>
