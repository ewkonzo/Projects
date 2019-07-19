<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="smstopupbulk.aspx.cs" Inherits="HIMS.smstopupbulk" %>
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
         Posting_Date = "", Document_No = "", Description = "";

   double TotalBid_Price = 0, Total=0,
       Dr_Amount = 0, Cr_Amount = 0, Balance = 0,Price_Share=0,No_Shares=0;

    string startdate = "", enddate = "";

   if (Request.QueryString["DD1"] != null && Request.QueryString["DD2"] != null)
   {
       startdate = Request.QueryString["DD1"].Trim();
       enddate = Request.QueryString["DD2"].Trim();
   }


    %>

<div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>
<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> BULK SMS TOPUP </b> </h6>
</div>


<li>
	<a href="smstopupbulknew.aspx?action=bulksmstopup&Show=False">
		<img alt="Click to topup" src="images/icons/adduser.png"/>
		<span></span>
	</a>
</li>

<table class="MyStamentbl" width="100%">
<thead>

 <%
     string path = "smstopupbulk.aspx?action=bulksmstopup&Show=False&", pagination = "";

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


        ////Shares Capital
        //string SQL = "SELECT COUNT([Entry No]) AS Num FROM [MSacco Portal Users] WHERE [Corporate No]='" + CorporateNo + "'";
        //string SQL = "SELECT [Id],[Sacco],[SmsCount],[Datetime],[Comments],[UserID] FROM [Sacco].[dbo].[Sacco Bulksms Topup] where [Sacco]='" + CorporateNo + "'";
        //string SQL = "SELECT COUNT([Id]) AS Num FROM [Sacco].[dbo].[Sacco Bulksms Topup] where [Sacco]='" + CorporateNo + "'";
        string SQL = "SELECT COUNT([Id]) AS Num FROM [Sacco].[dbo].[Sacco Bulksms Topup]";
        string SQL_2 = "";
        SqlDataReader dr2 = null;
        SqlCommand cmd23 = new SqlCommand(SQL, mConn);

        dr2 = cmd23.ExecuteReader();

        if (dr2.HasRows == true)
        {
        %>

  
    <tr>
    <th style="background-color:#64B044;color:#000;border-right:solid 1px black;">#</th>
    <th style="background-color:#64B044;color:#000;"> Corporate No</th>
    <th style="background-color:#64B044;color:#000"> Name</th>
    <th style="background-color:#64B044;color:#000"> Date</th>
    <th style="background-color:#64B044;color:#000;"> Topup Figure</th>
    <th style="background-color:#64B044;color:#000"> Comments</th>   
    <th style="background-color:#64B044;color:#000"> User</th>  
    </tr>
</thead>
<tbody>

        
       <%
            dr2.Read();

            total_pages = Convert.ToInt32(dr2["Num"].ToString());

            SqlDataReader dr = null;

            if (startdate != "" && enddate != "")
            {
   
            }
            else
            {                
                SQL_2 = "WITH My_W AS ( " +	
	                "SELECT a.[Id],a.[Sacco][Client Code],b.[Sacco Name 1] [Client Name],ISNULL(a.[SmsCount],0)[SmsCount]" +
		                ",a.[Datetime][Date],ISNULL(a.[Comments],'')[Comments],ISNULL(a.[UserID],'')[UserID] " +
		                ",ROW_NUMBER()OVER(ORDER BY a.[Id] DESC) AS ROW_NUMBER " +
                    "FROM [Sacco].[dbo].[Sacco Bulksms Topup] a " +
                    "INNER JOIN [Sacco].[dbo].[Source Information] b ON a.Sacco=b.[Corporate No]) " + 
                "SELECT * FROM My_W WHERE ROW_NUMBER BETWEEN @start AND @limit + @start ORDER BY [Id] DESC";
    
                SqlCommand cmd_data = new SqlCommand(SQL_2, mConn);
                cmd_data.Parameters.AddWithValue("@start", start);
                cmd_data.Parameters.AddWithValue("@limit", limit);
                dr = cmd_data.ExecuteReader();
                
            }

            //string corporate = "", firstname = "", lastname = "", username = "";
            string corporate = "", clientname = "", date = "", smscount = "0", comments = "", userid = "";
            
            DateTime Datetime;
            Double Amount = 0,MpesaFloat=0;           

            //SqlCommand cmd_data = new SqlCommand(SQL_2, mConn);
            //cmd_data.Parameters.AddWithValue("@corporate", CorporateNo);
            //dr = cmd_data.ExecuteReader();

          
            while (dr.Read())
            {
                i++;

                corporate = dr["Client Code"].ToString();
                clientname = dr["Client Name"].ToString();
                date = dr["Date"].ToString();
                smscount = "0"+dr["SmsCount"].ToString();
                comments = dr["Comments"].ToString();
                userid = dr["UserID"].ToString();

                if (i % 2 == 0)
                {
                 %>
                    <tr>
                    <td style="background-color:#E3EAEB;border-right:solid 1px black;"><%=i%></td>
                    <td style="background-color:#E3EAEB"><%=corporate%></td>
                    <td style="background-color:#E3EAEB"><%=clientname%></td>
                    <td style="background-color:#E3EAEB"><%=date%></td>
                    <td style="background-color:#E3EAEB"><%=smscount%></td> 
                    <td style="background-color:#E3EAEB"><%=comments%></td> 
                    <td style="background-color:#E3EAEB"><%=userid%></td>
                    </tr>            
                <% 
                }
                else
                {
                    %>

                <tr>
                <td style="background-color:#E3EAEB;border-right:solid 1px black;"><%=i%></td>
                <td style="background-color:#E3EAEB"><%=corporate%></td>
                <td style="background-color:#E3EAEB"><%=clientname%></td>
                <td style="background-color:#E3EAEB"><%=date%></td>
                <td style="background-color:#E3EAEB"><%=smscount%></td> 
                <td style="background-color:#E3EAEB"><%=comments%></td> 
                <td style="background-color:#E3EAEB"><%=userid%></td>          
                </tr>

                <%  
                }
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
