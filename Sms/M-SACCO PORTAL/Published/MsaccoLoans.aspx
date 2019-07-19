<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MsaccoLoans.aspx.cs" Inherits="HIMS.MsaccoLoans" %>
<%@ import namespace="Global.HIMS" %>
<%@Import Namespace="System.Web"%>
<%@Import Namespace="System.Web.UI"%>
<%@Import Namespace="System.Data"%>
<%@Import Namespace="System.Data.SqlClient"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Home_Master" runat="server">
<script type="text/javascript" charset="utf-8">
    function mypopup(DD1, DD2) {
        mywindow = window.open("PrintCombinedStatement.aspx?DD1=" + DD1 + "&DD2=" + DD2, "Statement ::  statement", "location=1,status=1,scrollbars=1,  width=800,height=800");

        mywindow.moveTo(300, 300);
    }

    $(function () {
        $('.date-pick').datePicker(
		{
		    startDate: '01/01/1970', //  01/01/1970    1970/01/01
		    endDate: (new Date()).asString()

		}
	);
    });

</script>




<% string Trade_Date, Owner_Personal_No, Bidder_Personal_No, Document_Date, Payment_Status,
         Posting_Date = "", Document_No = "", Description = "", EntryNo = "", SessionId = "", pagination = "", Search_PhoneNo="";

   double TotalBid_Price = 0, Total=0,
       Dr_Amount = 0, Cr_Amount = 0, Balance = 0,Price_Share=0,No_Shares=0;

    string startdate = "", enddate = "";

    if (Request.QueryString["Search_Pin_No"] != null)
    {
        Search_PhoneNo = Request.QueryString["Search_Pin_No"].Trim();

    }

    if (Request.QueryString["EntryNo"] != null)
   {
       EntryNo = Request.QueryString["EntryNo"].Trim();
      
   }
    if (Request.QueryString["SessionId"] != null)
    {
        SessionId = Request.QueryString["SessionId"].Trim();


        if (CommonUtilities.CancelPendingLoans(EntryNo, SessionId, true))
        {
            lblError.Text = "<div class='information'><img src='images/information.gif' width=20 height=20 border='none'>Loan succesfully cancelled session id: " + SessionId + "</div>";

        }
        else
        {
            lblError.Text = "<div class='warnig'><img src='images/warning.gif' width=20 height=20 border='none'>Loan Cancel Failed. Please retry.</div>";

        }
    }


   

    %>

<div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>

<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> LOANS </b> </h6>
</div>

 <center>
            <table class="MyStamentbls" width="50%" style="height:30px;padding-top:0px;">
            <tr>
            <td style="background-color:#EDF5FF;border:0px">Telephone</td>
            <td  style="background-color:#EDF5FF;border:0px"> 
            <asp:TextBox ID="Telephone" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid" 
            CssClass="textEntry"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Telephone" 
            CssClass="failureNotification" ErrorMessage="Pin_No is required." ToolTip="Pin_No is required." 
            ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span></asp:RequiredFieldValidator>
            </td>
            <td class="submitButton" style="background-color:#EDF5FF;border:0px">
            <asp:Button ID="Search" runat="server" CommandName="Go" Text="Search" 
            ValidationGroup="LoginUserValidationGroup" onclick="Search_Click"  />
            </td>

             <td class="submitButton" style="background-color:#EDF5FF;border:0px">
            <asp:Button ID="Button1" runat="server" CommandName="Reset" Text="Reset" 
            ValidationGroup="LoginUserValidationGroup" onclick="Button1_Click"  />
            </td>
            </tr>
            </table>
    </center>


<table class="MyStamentbl" width="100%">
<thead>

 <%
     string path = "";
     if (Search_PhoneNo.Trim() != "")
     {
          path = "MsaccoLoans.aspx?action=Loan&Show=False&Search_Pin_No=" + Search_PhoneNo+"&";
     }
     else
     {
          path = "MsaccoLoans.aspx?action=Loan&Show=False&";
     }
     
  

     double Listings_Per_Page,counter=0, total_pages = 0, adjacents = 2, page = 0, start, limit = 0, prev, next, lastpage, lpm1;

     Listings_Per_Page = Convert.ToDouble(CommonUtilities.getListingPerPage());

     double Total_No_Shares = 0, Total_Price_per_Shares = 0, Total_Debit_Amount = 0, Total_Credit_Amount = 0, Total_Balance_Amount = 0;
     
     limit = Listings_Per_Page;
     int i = 0;

     if (Request.QueryString["page"] != null)
     {
         page = Convert.ToInt32(Request.QueryString["page"].Trim());
         start = (page - 1) * limit;

         i = Convert.ToInt32(page-1) * Convert.ToInt32( Listings_Per_Page); 
     }
     else {
         start = 0;     
     }
      %>

<%
    using (SqlConnection mConn = new SqlConnection(CommonUtilities.ConnectionString))
    {
        mConn.Open();
        string CorporateNo = Session["CorporateNo"].ToString();
        string SQL = "";
        if (Search_PhoneNo.Trim() != "")
        {
            SQL = "SELECT COUNT([Entry No]) AS Num FROM [MSaccoSalaryAdvance] WHERE [Corporate No]=" + "'" + CorporateNo + "' AND Status<>'Failed' AND [Telephone No] LIKE '%" + Search_PhoneNo + "%'";
        }
        else {
            SQL = "SELECT COUNT([Entry No]) AS Num FROM [MSaccoSalaryAdvance] WHERE [Corporate No]=" + "'" + CorporateNo + "' AND Status<>'Failed'";
        }
        string SQL_2 = "";
        SqlDataReader dr2 = null;
        SqlCommand cmd23 = new SqlCommand(SQL, mConn);

        dr2 = cmd23.ExecuteReader();

        if (dr2.HasRows == true)
        {
        %>

  
    <tr>
    <th style="background-color:#64B044;color:#000;border-right:solid 1px black;">#</th>
    <th style="background-color:#64B044;color:#000">Telephone No</th>    
    <th style="background-color:#64B044;color:#000">Transaction Date</th>
    <th style="background-color:#64B044;color:#000">Loan Type </th>      
    <th style="background-color:#64B044;color:#000;">Amount</th>
    <th style="background-color:#64B044;color:#000">Status </th> 
    <th style="background-color:#64B044;color:#000">Session</th>    
     <th style="background-color:#64B044;color:#000">Action</th> 
    </tr>
</thead>
<tbody>

        
       <%
            dr2.Read();

            total_pages = Convert.ToInt32(dr2["Num"].ToString());

            SqlDataReader dr = null;
            string Loantype = "", RegDate = "", AccountName = "", TelephoneNo = "", MPESAReceiptNo = "", SentToJournal = "", NoPinAttempt = "", Action = "-", Id = "", SESSION_ID = "",Status="";
            string Datetime = "";
            Double Amount = 0, MpesaFloat = 0;

            if (Search_PhoneNo.Trim() != "")
            {

                SQL_2 = "WITH My_W AS (SELECT [Entry No], Status, [Account No], [Telephone No], Amount, Comments, SESSION_ID, [Transaction Date], [Sent To Journal], [Date Sent To Journal], " +
                      "[Time Sent To Journal], [Corporate No], [Member No], [Staff No], [Client Code], [Account Balance], [Repayment Period], [Mounthly Installments], [Processing fee], " +
                      "[Max Loan], [Min Loan], Type, [Net Pay], Recovery, Source, [Loan type], [Loan Name], KG, [Client Name], [Bonus based], [No of Guarantors], [KG Guaranteed], " +
                     " Remarks, [Loan Status], [KG Used], [G Appraised], Disbursed ," +
                       " ROW_NUMBER() OVER(ORDER BY [Entry No] DESC) AS row_number  FROM  [MSaccoSalaryAdvance] WHERE [Telephone No] LIKE '%" + Search_PhoneNo + "%' AND Status<>'Failed' AND [Corporate No]=" + "'" + CorporateNo + "') " +
                " SELECT * FROM My_W WHERE row_number BETWEEN @start AND @limit+@start ORDER BY [Entry No] DESC";

                SqlCommand cmd_data = new SqlCommand(SQL_2, mConn);
                cmd_data.Parameters.AddWithValue("@start", start);
                cmd_data.Parameters.AddWithValue("@limit", limit);
                cmd_data.Parameters.AddWithValue("@Search_PhoneNo", Search_PhoneNo);
                dr = cmd_data.ExecuteReader();
   
            }
            else
            {

          SQL_2 = "WITH My_W AS (SELECT [Entry No], Status, [Account No], [Telephone No], Amount, Comments, SESSION_ID, [Transaction Date], [Sent To Journal], [Date Sent To Journal], "+
                      "[Time Sent To Journal], [Corporate No], [Member No], [Staff No], [Client Code], [Account Balance], [Repayment Period], [Mounthly Installments], [Processing fee], "+
                      "[Max Loan], [Min Loan], Type, [Net Pay], Recovery, Source, [Loan type], [Loan Name], KG, [Client Name], [Bonus based], [No of Guarantors], [KG Guaranteed], "+
                     " Remarks, [Loan Status], [KG Used], [G Appraised], Disbursed ,"+
                       " ROW_NUMBER() OVER(ORDER BY [Entry No] DESC) AS row_number  FROM  [MSaccoSalaryAdvance] WHERE Status<>'Failed' AND [Corporate No]=" + "'" + CorporateNo + "') " +
                " SELECT * FROM My_W WHERE row_number BETWEEN @start AND @limit+@start ORDER BY [Entry No] DESC";
                
                  SqlCommand cmd_data = new SqlCommand(SQL_2, mConn);
                  cmd_data.Parameters.AddWithValue("@start", start);
                  cmd_data.Parameters.AddWithValue("@limit", limit);
                  dr = cmd_data.ExecuteReader();
            }
          
            

          

          
            while (dr.Read())
            {
                i++;
                Id = dr["Entry No"].ToString();
                RegDate = dr["Transaction Date"].ToString(); 
                TelephoneNo = dr["Telephone No"].ToString();
                Loantype = dr["Loan type"].ToString();
                if (string.IsNullOrEmpty(dr["Amount"].ToString()) == false)
                {
                    Amount = Convert.ToDouble(dr["Amount"].ToString());
                }
                SESSION_ID = dr["SESSION_ID"].ToString();
                Status = dr["Status"].ToString();

               

                if (i % 2 == 0)
                {%>

            <tr>
             <td style="background-color:#E3EAEB;border-right:solid 1px black;border-bottom:solid 0px black;"><%=i%></td>           
             <td style="background-color:#E3EAEB;border-bottom:solid 0px black;"><%=TelephoneNo%></td>
             <td style="background-color:#E3EAEB;border-bottom:solid 0px black;"><%=RegDate%></td>
             <td style="background-color:#E3EAEB;border-bottom:solid 0px black;"><%=Loantype%></td>
             <td style="background-color:#E3EAEB;border-bottom:solid 0px black;"><%=Amount%></td>
             <td style="background-color:#E3EAEB;border-bottom:solid 0px black;"><%=Status%></td>
             <td style="background-color:#E3EAEB;border-bottom:solid 0px black;"><%= SESSION_ID%></td>  
             <td style="background-color:#E3EAEB;border-bottom:solid 0px black;">
             
             <% if (Status == "Pending")
                { %>               
              <a href='MsaccoLoans.aspx?action=Loan&Show=False&Activate=True&EntryNo=<%=Id%>&Random=<%=TelephoneNo %>&SessionId=<%=SESSION_ID %>&option=Cancel' title="Cancel"  style='border:none;' onclick="return confirm('Are you sure you want to cancel loan for <%=TelephoneNo%> ?')" >
             <img src="images/remove2.png" alt="" style='border:none;'/>
             </a>  
             <%} %>

             </td>
            </tr>

           <% string GuarantorPhone = "",GuarantorStatus="";
               string Guarantors = "SELECT Id, [Loan Type], Source, Guarantor, Session, Amount, Status, Datetime, Corporate, G_Account, G_Account_Name, [Amount Guaranteed], Remarks,"+ 
                     " [G Phone No], [Sent Sms], [Guarantor Session], Posted, Comments, [Date Responded], [Date sms sent]"+
                        "FROM Guarantors WHERE Session=@Session ";
                SqlCommand cmd_Gurantor = new SqlCommand(Guarantors, mConn);
                cmd_Gurantor.Parameters.AddWithValue("@Session", SESSION_ID);
                SqlDataReader dr2_ = null;
                dr2_ = cmd_Gurantor.ExecuteReader();
                if (dr2_.HasRows)
                {

                    %> 
                <tr>
                <td style="background-color:#E3EAEB;border-right:solid 1px black;border-top:solid 0px black;"></td>
                <td style="background-color:#E3EAEB;border-right:solid 1px black;border-top:solid 0px black;" colspan="7">
                <center>
                <table style="width:50%;">
               <tr>
               <td style="background-color:#E3EAEB;border-bottom:solid 1px #bbb;border-top:solid 0px black;font-weight:bolder;">Guarontor Phone</td>
               <td style="background-color:#E3EAEB;border-bottom:solid 1px #bbb;border-top:solid 0px black;font-weight:bolder;">Status</td>
               </tr>
                <%  while (dr2_.Read())
                    {
                        GuarantorPhone = dr2_["Guarantor"].ToString();
                        GuarantorStatus = dr2_["Status"].ToString(); %>
                 <tr><td style="background-color:#E3EAEB;border-bottom:solid 1px #bbb;border-top:solid 0px black;"><%=GuarantorPhone%></td>
                <td style="background-color:#E3EAEB;border-bottom:solid 1px #bbb;border-top:solid 0px black;"><%=GuarantorStatus%></td> </tr>
                <%} %>
               
                </table></center>
                </td>
                               
                <%
                }
           %>
            


           <% }
                else
                {%>

         <tr>
             <td style="background-color:#FFFFFF;border-right:solid 1px black;border-bottom:solid 0px black;"><%=i%></td>
             <td style="background-color:#FFFFFF;border-bottom:solid 0px black;"><%=TelephoneNo%></td>             
             <td style="background-color:#FFFFFF;border-bottom:solid 0px black;"><%=RegDate%></td>            
             <td style="background-color:#FFFFFF;border-bottom:solid 0px black;"><%=Loantype%></td>
             <td style="background-color:#FFFFFF;border-bottom:solid 0px black;"><%=Amount%></td>
             <td style="background-color:#FFFFFF;border-bottom:solid 0px black;"><%= Status%></td>  
             <td style="background-color:#FFFFFF;border-bottom:solid 0px black;"><%= SESSION_ID%></td>    
             <td style="background-color:#FFFFFF;border-bottom:solid 0px black;">
               <% if (Status == "Pending")
                { %>               
              <a href='MsaccoLoans.aspx?action=Loan&Show=False&Activate=True&EntryNo=<%=Id%>&Random=<%=TelephoneNo %>&SessionId=<%=SESSION_ID %>&option=Activate' title="Cancel"  style='border:none;' onclick="return confirm('Are you sure you want to cancel loan for <%=TelephoneNo%> ?')" >
             <img src="images/remove2.png" alt="" style='border:none;'/>
             </a>  
             <%} %>
                </td> 
         </tr>
         
           <% string GuarantorPhone = "",GuarantorStatus="";
               string Guarantors = "SELECT Id, [Loan Type], Source, Guarantor, Session, Amount, Status, Datetime, Corporate, G_Account, G_Account_Name, [Amount Guaranteed], Remarks,"+ 
                     " [G Phone No], [Sent Sms], [Guarantor Session], Posted, Comments, [Date Responded], [Date sms sent]"+
                        "FROM Guarantors WHERE Session=@Session ";
                SqlCommand cmd_Gurantor = new SqlCommand(Guarantors, mConn);
                cmd_Gurantor.Parameters.AddWithValue("@Session", SESSION_ID);
                SqlDataReader dr2_ = null;
                dr2_ = cmd_Gurantor.ExecuteReader();
                if (dr2_.HasRows)
                {

                    %> 
                <tr>
                <td style="background-color:#FFFFFF;border-right:solid 1px black;border-top:solid 0px black;"></td>
                <td style="background-color:#FFFFFF;border-right:solid 1px black;border-top:solid 0px black;" colspan="7">
                <center>
                <table style="width:50%;">
                 <tr>
               <td style="background-color:#FFFFFF;border-bottom:solid 1px #bbb;border-top:solid 0px black;font-weight:bolder;">Guarontor Phone</td>
               <td style="background-color:#FFFFFF;border-bottom:solid 1px #bbb;border-top:solid 0px black;font-weight:bolder;">Status</td>
               </tr>
               
                <%  while (dr2_.Read())
                    {
                        GuarantorPhone = dr2_["Guarantor"].ToString();
                        GuarantorStatus = dr2_["Status"].ToString(); %>
                 <tr><td style="background-color:#FFFFFF;border-bottom:solid 1px #bbb;border-top:solid 0px black;"><%=GuarantorPhone%></td>
                <td style="background-color:#FFFFFF;border-bottom:solid 1px #bbb;border-top:solid 0px black;"><%=GuarantorStatus%></td> </tr>
                <%} %>
               
                </table></center>
                </td>
                               
                <%
                }
           %>



        <% }
            }

        }

    %>
 


 <%
        mConn.Close();
    }
  if (page == 0) page = 1;
        prev = page - 1;
        next = page + 1;
        lastpage =  Math.Ceiling(total_pages/limit);
        lpm1 = lastpage - 1;
        pagination = "";

        if(lastpage > 1)
        {
        pagination += "<div class='pagination'>";

        if (page > 1)
        pagination+= "<a href='"+path+"page="+prev+"'>&#171; previous</a>";
        else
        pagination+= "<span class='disabled'>&#171; previous</span>";

        if (lastpage < 7 + (adjacents * 2))
        {
        for ( counter = 1; counter <= lastpage; counter++)
        {
        if (counter == page)
        pagination+= "<span class='current'>"+counter+"</span>";
        else
        pagination+= "<a href='"+path+"page="+counter+"'>"+counter+"</a>";
        }  

        }
        else if (lastpage > 5 + (adjacents * 2))
        {
            if (page < 1 + (adjacents * 2))
            {
                for (counter = 1; counter < 4 + (adjacents * 2); counter++)
                {
                    if (counter == page)
                        pagination += "<span class='current'>"+counter+"</span>";
                    else
                        pagination += "<a href='" + path + "page=" + counter + "'>"+counter+"</a>";
                }
                pagination += "...";
                pagination += "<a href='" + path + "page=" + lpm1 + "'>"+lpm1+"</a>";
                pagination += "<a href='" + path + "page=" + lastpage + "'>"+lastpage+"</a>";
            }
            else if(lastpage - (adjacents * 2) > page && page > (adjacents * 2))
                {
                pagination+= "<a href='"+path+"page=1'>1</a>";
                pagination+= "<a href='"+path+"page=2'>2</a>";
                pagination+= "...";
                for ( counter = page - adjacents; counter <= page + adjacents; counter++)
                {
                if (counter == page)
                pagination+= "<span class='current'>"+counter+"</span>";
                else
                pagination+= "<a href='"+path+"page="+counter+"'>"+counter+"</a>";
                }
                pagination+= "..";
                pagination+= "<a href='"+path+"page="+lpm1+"'>"+lpm1+"</a>";
                pagination+= "<a href='"+path+"page="+lastpage+"'>"+lastpage+"</a>";
                }
            else
            {
            pagination+= "<a href='"+path+"page=1'>1</a>";
            pagination+= "<a href='"+path+"page=2'>2</a>";
            pagination+= "..";
            for (  counter = lastpage - (2 + (adjacents * 2)); counter <= lastpage; counter++)
            {
            if (counter == page)
            pagination+= "<span class='current'>"+counter+"</span>";
            else
            pagination+= "<a href='"+path+"page="+counter+"'>"+counter+"</a>";
            }
           }
        }

        if (page < counter - 1)
        pagination+= "<a href='"+path+"page="+next+"'>next &#187;</a>";
        else
        pagination+= "<span class='disabled'>next &#187;</span>";
        pagination+= "</div>\n";
    
        } 

 
         %>

<%--<%  if (Search_PhoneNo.Trim() == "")
    { %>--%>
        <tr>
        <td colspan="9">

        <%=pagination%>

        </td>
        </tr>
<%--<%} %>--%>

</table>
</asp:Content>
