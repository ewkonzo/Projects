<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HIMS.Home1" %>
<%@ import namespace="Global.HIMS" %>
<%@Import Namespace="System.Web"%>
<%@Import Namespace="System.Web.UI"%>
<%@Import Namespace="System.Data"%>
<%@Import Namespace="System.Data.SqlClient"%>

<asp:Content ID="Content_Main" ContentPlaceHolderID="Home_Master" runat="server">
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
    %>
 
 <center><div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div></center>
<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> DASHBOARD </b> </h6>
</div>
<center>
<table class="MyStamentbl" width="50%">
<thead>
<tr>
<th style="padding-left:10px;">M-PESA FLOAT</th>
<th style="padding-left:10px;">MOBILE SMS BAL</th>
<th style="padding-left:10px;">BULK SMS BAL</th>
</tr>
</thead>
    <tr>
    <td style="padding-left:30px;color:Blue;font-weight:bold;"><%=String.Format("{0:0,0.00}",CommonUtilities.GetMpesaFloat(CorporateNo)) %></td>
    <td style="padding-left:30px;color:Blue;font-weight:bold;"><%= String.Format("{0:0,0.00}",CommonUtilities.GetMobileSMSFloat(CorporateNo))%></td>
    <td style="padding-left:30px;color:Blue;font-weight:bold;"><%= String.Format("{0:0,0.00}",CommonUtilities.GetBulkSMSFloat(CorporateNo))%></td>
    </tr>
</table>
</center>
</asp:Content>
