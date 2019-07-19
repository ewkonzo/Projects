﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Deposits.aspx.cs" Inherits="HIMS.Reservation" %>
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
         Posting_Date = "", Document_No = "", Description = "", Search_PhoneNo="";

   double TotalBid_Price = 0, Total=0,
       Dr_Amount = 0, Cr_Amount = 0, Balance = 0,Price_Share=0,No_Shares=0;

    string startdate = "", enddate = "";

    if (Request.QueryString["Search_Pin_No"] != null)
    {
        Search_PhoneNo = Request.QueryString["Search_Pin_No"].Trim();

    }


    %>

<div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>

<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> DEPOSITS </b> </h6>
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
     string pagination = "";

     string path = "";
     if (Search_PhoneNo.Trim() != "")
     {
         path = "Deposits.aspx?action=Deposits&Show=False&Search_Pin_No=" + Search_PhoneNo + "&";
     }
     else
     {
         path = "Deposits.aspx?action=Deposits&Show=False&";
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

         i = Convert.ToInt32(page - 1) * Convert.ToInt32(Listings_Per_Page);
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
            SQL = "SELECT COUNT([Entry No]) AS Num FROM [Mobile Transactions] WHERE [Corporate No]=" + "'" + CorporateNo + "' AND Status<>'Failed' AND [MSISDN] LIKE '%" + Search_PhoneNo + "%'";
        }
        else
        {
            SQL = "SELECT COUNT([Entry No]) AS Num FROM [Mobile Transactions] WHERE [Corporate No]=" + "'" + CorporateNo + "' AND Status<>'Failed'";
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
     <th style="background-color:#64B044;color:#000;">Status</th>
      <th style="background-color:#64B044;color:#000">Transaction Date</th>
    <th style="background-color:#64B044;color:#000;">Account No</th>
    <th style="background-color:#64B044;color:#000">Description</th>
    <th style="background-color:#64B044;color:#000">Telephone No</th>
    <th style="background-color:#64B044;color:#000">Amount</th>
    <th style="background-color:#64B044;color:#000">Receipt No </th>
     <th style="background-color:#64B044;color:#000">M-PESA Float</th>
    <th style="background-color:#64B044;color:#000">Sent To Server</th>
   
    </tr>
</thead>
<tbody>

        
       <%
            dr2.Read();

            total_pages = Convert.ToInt32(dr2["Num"].ToString());

            SqlDataReader dr = null;

            string Status = "", AccountNo = "", AccountName = "", TelephoneNo = "", MPESAReceiptNo = "", SentToJournal = "";
            DateTime Datetime;
            Double Amount = 0, MpesaFloat = 0;
            
            if (Search_PhoneNo.Trim() != "")
            {
                SQL_2 = "WITH My_W AS ( SELECT [Entry No],Status,[Account No],[Description] ,[MSISDN],[Trans Amount],[Org Account Balance],[Receipt No],[Sent to Journal],[Date Received], " +
                                " ROW_NUMBER() OVER(ORDER BY [Entry No] DESC) AS row_number   FROM  [Mobile Transactions] WHERE MSISDN LIKE '%"+Search_PhoneNo+"%' AND [Corporate No]=" + "'" + CorporateNo + "') " +
                         " SELECT * FROM My_W WHERE row_number BETWEEN @start AND @limit+@start ORDER BY [Entry No] DESC";

                SqlCommand cmd_data = new SqlCommand(SQL_2, mConn);
                cmd_data.Parameters.AddWithValue("@start", start);
                cmd_data.Parameters.AddWithValue("@limit", limit);
                dr = cmd_data.ExecuteReader();
            }
            else
            {


                SQL_2 = "WITH My_W AS ( SELECT [Entry No],Status,[Account No],[Description] ,[MSISDN],[Trans Amount],[Org Account Balance],[Receipt No],[Sent to Journal],[Date Received], " +
                      " ROW_NUMBER() OVER(ORDER BY [Entry No] DESC) AS row_number   FROM  [Mobile Transactions] WHERE [Corporate No]=" + "'" + CorporateNo + "') " +
               " SELECT * FROM My_W WHERE row_number BETWEEN @start AND @limit+@start ORDER BY [Entry No] DESC";
                
                SqlCommand cmd_data = new SqlCommand(SQL_2, mConn);
                cmd_data.Parameters.AddWithValue("@start", start);
                cmd_data.Parameters.AddWithValue("@limit", limit);
                dr = cmd_data.ExecuteReader();
            }
          
            

         

            //int i = 0;
            while (dr.Read())
            {

                i++;

                Status = dr["Status"].ToString();
                AccountNo = dr["Account No"].ToString();
                AccountName = dr["Description"].ToString();
                TelephoneNo = dr["MSISDN"].ToString();
                Amount = Math.Round(Convert.ToDouble(dr["Trans Amount"].ToString()), 2);
                double MPESAFloatAmount=0;
                if (string.IsNullOrEmpty(dr["Org Account Balance"].ToString()))
                {
                    MPESAFloatAmount = 0;
                }
                else {
                    MPESAFloatAmount = Math.Round(Convert.ToDouble(dr["Org Account Balance"].ToString()), 2);
                }
                    
               // MpesaFloat = Math.Round(Convert.ToDouble(dr["MPESA Float Amount"].ToString()), 2);
                MPESAReceiptNo = dr["Receipt No"].ToString();
                SentToJournal = dr["Sent to Journal"].ToString();
                Datetime = Convert.ToDateTime(dr["Date Received"].ToString());

                if (i % 2 == 0)
                {%>

            <tr>
             <td style="background-color:#E3EAEB;border-right:solid 1px black;"><%=i%></td>
            <td style="background-color:#E3EAEB"><%=Status%></td>
                <td style="background-color:#E3EAEB"><%=Datetime%></td>
             <td style="background-color:#E3EAEB"><%=AccountNo%></td>
            <td style="background-color:#E3EAEB"><%=AccountName%></td>
            <td style="background-color:#E3EAEB"><%=TelephoneNo%></td>
            <td style="background-color:#E3EAEB"><%=String.Format("{0:0,0.00}", Amount)%></td>
            <td style="background-color:#E3EAEB"><%=MPESAReceiptNo%></td>
             <td style="background-color:#E3EAEB"><%=String.Format("{0:0,0.00}", MPESAFloatAmount)%></td>
            <td style="background-color:#E3EAEB"> <%=SentToJournal%></td>
        
                    
            </tr>
            
           <% }
                else
                {%>

         <tr>
          <td style="background-color:#FFFFFF;border-right:solid 1px black;"><%=i%></td>
         <td style="background-color:#FFFFFF"><%=Status%></td>
            <td style="background-color:#FFFFFF"><%=Datetime%></td>
           <td style="background-color:#FFFFFF"><%=AccountNo%></td>
            <td style="background-color:#FFFFFF"><%=AccountName%></td>
            <td style="background-color:#FFFFFF"><%=TelephoneNo%></td>
            <td style="background-color:#FFFFFF"><%=String.Format("{0:0,0.00}", Amount)%></td>
            <td style="background-color:#FFFFFF"><%=MPESAReceiptNo%></td>
             <td style="background-color:#FFFFFF"><%=String.Format("{0:0,0.00}", MPESAFloatAmount)%></td>
            <td style="background-color:#FFFFFF"> <%=SentToJournal%></td>
    
          
          
                  </tr>

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



<tr>
<td colspan="9">

<%=pagination %>

</td>
</tr>

</table>


</asp:Content>

<asp:Content ID="Content_Sidebar" ContentPlaceHolderID="SideBar_Master" runat="server">

</asp:Content>


