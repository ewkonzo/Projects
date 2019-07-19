<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PinReset.aspx.cs" Inherits="HIMS.PinReset" %>
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




<% 
    string CorporateNo = Session["CorporateNo"].ToString();
    
    string Trade_Date, Owner_Personal_No, Bidder_Personal_No, Document_Date, Payment_Status,
         Posting_Date = "", Document_No = "", Description = "", ResetPhoneNo = "", strMsg="";

   double TotalBid_Price = 0, Total=0,
       Dr_Amount = 0, Cr_Amount = 0, Balance = 0,Price_Share=0,No_Shares=0;

   string startdate = "", enddate = "", Search_PhoneNo="";

    if (Request.QueryString["Search_Pin_No"] != null)
    {
        Search_PhoneNo = Request.QueryString["Search_Pin_No"].Trim();
    }

    if (Request.QueryString["Activate"] != null && Request.QueryString["Activate"] == "True" && Request.QueryString["mid"] != null)
    {
        ResetPhoneNo = Request.QueryString["mid"].Trim();
        ResetPhoneNo = "+254" + ResetPhoneNo.Substring(ResetPhoneNo.Length - 9);

        if (CommonUtilities.sendSms_(ResetPhoneNo, "", CorporateNo, "Pin Reset",""))
        {
            strMsg = "Pin succesfully generated and sent to " + ResetPhoneNo;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(strMsg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());



            string CurrentPage = "PinReset.aspx?action=PinReset&Show=False&Search_Pin_No=" + ResetPhoneNo + "&Msg=Succesfull";
            Response.Redirect(CurrentPage, false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else {


            strMsg = "Pin reset has failed. Please retry ";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(strMsg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            string CurrentPage = "PinReset.aspx?action=PinReset&Show=False&Search_Pin_No=" + ResetPhoneNo + "&Msg=Failed";
            Response.Redirect(CurrentPage, false);
            Context.ApplicationInstance.CompleteRequest();
        
        }
        
    }

    if (Request.QueryString["Msg"] != null && Request.QueryString["Msg"] == "Succesfull")
    {
        lblError.Text = "<div class='information'><img src='images/information.gif' width=20 height=20 border='none'>New Pin succesfully generated and sent to phone " + Search_PhoneNo + "</div>";

    }
    
        
    if (Request.QueryString["Msg"] != null && Request.QueryString["Msg"] == "Failed")
    {
        lblError.Text = "<div class='warnig'><img src='images/warning.gif' width=20 height=20 border='none'>Pin reset failed. Please retry.</div>";

    }

    %>

<center><div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div></center>
<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> PIN RESET </b> </h6>
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
         path = "PinReset.aspx?action=PinReset&Show=False&Search_Pin_No=" + Search_PhoneNo + "&";
     }
     else
     {
         path = "PinReset.aspx?action=PinReset&Show=False&";
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
      


        //Shares Capital
        string SQL = "";
        if (Search_PhoneNo.Trim() != "")
        {
            SQL = "SELECT COUNT([Entry No]) AS Num FROM [Routing Table] WHERE [Corporate No]=" + "'" + CorporateNo + "'  AND [Telephone No] LIKE '%" + Search_PhoneNo + "%'";
        }
        else
        {
            SQL = "SELECT COUNT([Entry No]) AS Num FROM [Routing Table] WHERE [Corporate No]=" + "'" + CorporateNo + "' ";
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
     <th style="background-color:#64B044;color:#000">Registration Date</th>
     <th style="background-color:#64B044;color:#000">Telephone No</th>
    <th style="background-color:#64B044;color:#000">Last Login Date</th>
    <th style="background-color:#64B044;color:#000">No Pin Attempts </th>      
     <th style="background-color:#64B044;color:#000;">Status</th>
     <th style="background-color:#64B044;color:#000">Action</th>
   
    </tr>
</thead>
<tbody>

        
       <%
            dr2.Read();

            total_pages = Convert.ToInt32(dr2["Num"].ToString());

            SqlDataReader dr = null;

            string Status = "", RegDate = "", AccountName = "", TelephoneNo = "", MPESAReceiptNo = "", SentToJournal = "", NoPinAttempt = "", Action = "-", Id = "";
            string Datetime = "";
            Double Amount = 0, MpesaFloat = 0;
            if (Search_PhoneNo.Trim() != "")
            {
                SQL_2 = "WITH My_W AS ( SELECT [Entry No], [Telephone No], [Corporate No], [PIN No Changed], [Withdrawal Limit daily], [Withdrawal Limit Transaction], Status, Comments, DateRegistered, " +
                               "[Account No], [Language Code], Subscribed, PinChanged, GFEDHATest, IMEI, [Language Code 2], [SMS Code], [SMS Code Verified], [Is Agent], [No Pin Attempt], " +
                               "[Last Pin Change Date], [Date Blocked], [Last Login Date], " +
                                " ROW_NUMBER() OVER(ORDER BY [Entry No] DESC) AS row_number   FROM  [Routing Table] WHERE [Telephone No] LIKE '%"+Search_PhoneNo+"%' AND [Corporate No]=" + "'" + CorporateNo + "') " +
                         " SELECT * FROM My_W WHERE row_number BETWEEN @start AND @limit+@start ORDER BY [Entry No] DESC";

                SqlCommand cmd_data = new SqlCommand(SQL_2, mConn);
                cmd_data.Parameters.AddWithValue("@start", start);
                cmd_data.Parameters.AddWithValue("@limit", limit);
                dr = cmd_data.ExecuteReader();
            }
            else
            {

                SQL_2 = "WITH My_W AS ( SELECT [Entry No], [Telephone No], [Corporate No], [PIN No Changed], [Withdrawal Limit daily], [Withdrawal Limit Transaction], Status, Comments, DateRegistered, "+
                      "[Account No], [Language Code], Subscribed, PinChanged, GFEDHATest, IMEI, [Language Code 2], [SMS Code], [SMS Code Verified], [Is Agent], [No Pin Attempt], "+
                      "[Last Pin Change Date], [Date Blocked], [Last Login Date], " +
                       " ROW_NUMBER() OVER(ORDER BY [Entry No] DESC) AS row_number   FROM  [Routing Table] WHERE [Corporate No]=" + "'" + CorporateNo + "') " +
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
                Status = dr["Status"].ToString();
                RegDate = dr["DateRegistered"].ToString();
                TelephoneNo = dr["Telephone No"].ToString();                
                Datetime = dr["Last Login Date"].ToString();
                NoPinAttempt = dr["No Pin Attempt"].ToString();
                
                if (Convert.ToInt16(Status) == 0)
                {
                    Status = "In active";
                }
                else
                {
                    Status = "Active";
                }

                if (i % 2 == 0)
                {%>

            <tr>
             <td style="background-color:#E3EAEB;border-right:solid 1px black;"><%=i%></td>
            <td style="background-color:#E3EAEB"><%=RegDate%></td>
               <td style="background-color:#E3EAEB"><%=TelephoneNo%></td>
             <td style="background-color:#E3EAEB"><%=Datetime%></td>
            <td style="background-color:#E3EAEB"><%=NoPinAttempt%></td>
            <td style="background-color:#E3EAEB"><%=Status%></td>
            <% if ((Status == "In active") || (NoPinAttempt == "3"))
               {
                   Action = "Activate";%>
              <td style="background-color:#E3EAEB"> 
               <a href='PinReset.aspx?action=PinReset&Show=False&Activate=True&RefereeNo=<%=Id%>&Random=<%=NoPinAttempt %>&mid=<%=TelephoneNo %>&option=Activate' title="Activate"  style='border:none;' onclick="return confirm('Are you sure you want to activate and resend Pin to telephone No <%=TelephoneNo%> ?')" >
             <img src="images/edit.png" alt="" style='border:none;'/>
             </a>  
             </td>
              <%}
               else
               { %>
              <%-- -- <td style="background-color:#E3EAEB"> <%=Action%></td>--%>
               <td style="background-color:#E3EAEB"> 
               <a href='PinReset.aspx?action=PinReset&Show=False&Activate=True&RefereeNo=<%=Id%>&Random=<%=NoPinAttempt %>&mid=<%=TelephoneNo %>&option=Activate' title="Activate"  style='border:none;' onclick="return confirm('Are you sure you want to activate and resend Pin to telephone No <%=TelephoneNo%> ?')" >
             <img src="images/edit.png" alt="" style='border:none;'/>
             </a>  
             </td>

              <%} %>
        
                    
            </tr>
            
           <% }
                else
                {%>

         <tr>
          <td style="background-color:#FFFFFF;border-right:solid 1px black;"><%=i%></td>
         <td style="background-color:#FFFFFF"><%=RegDate%></td>
            <td style="background-color:#FFFFFF"><%=TelephoneNo%></td>
           <td style="background-color:#FFFFFF"><%=Datetime%></td>
            <td style="background-color:#FFFFFF"><%=NoPinAttempt%></td>
            <td style="background-color:#FFFFFF"><%=Status%></td>            
             <% if ((Status == "In active") || (NoPinAttempt=="3"))
               {
                   Action = "Activate";%>
              <td style="background-color:#FFFFFF">
          <a href='PinReset.aspx?action=PinReset&Show=False&Activate=True&RefereeNo=<%=Id%>&Random=<%=NoPinAttempt %>&mid=<%=TelephoneNo %>&option=Activate' title="Activate"  style='border:none;' onclick="return confirm('Are you sure you want to activate and resend Pin to telephone No <%=TelephoneNo%> ?')" >
             <img src="images/edit.png" alt="" style='border:none;'/>
             </a>     
              </td>
              <%}
               else
               { %>
                <%--<td style="background-color:#FFFFFF"> <%=Action%></td>--%>
                  <td style="background-color:#FFFFFF">
          <a href='PinReset.aspx?action=PinReset&Show=False&Activate=True&RefereeNo=<%=Id%>&Random=<%=NoPinAttempt %>&mid=<%=TelephoneNo %>&option=Activate' title="Activate"  style='border:none;' onclick="return confirm('Are you sure you want to activate and resend Pin to telephone No <%=TelephoneNo%> ?')" >
             <img src="images/edit.png" alt="" style='border:none;'/>
             </a>     
              </td>
              <%} %>
    
          
          
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

