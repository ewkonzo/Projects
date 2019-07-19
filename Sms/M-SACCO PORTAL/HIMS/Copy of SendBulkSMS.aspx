<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SendBulkSMS.aspx.cs" Inherits="HIMS.SendBulkSMS" %>
<%@ import namespace="Global.HIMS" %>
<%@Import Namespace="System.Web"%>
<%@Import Namespace="System.Web.UI"%>
<%@Import Namespace="System.Data"%>
<%@Import Namespace="System.Data.SqlClient"%>
<%@Import Namespace="System.Data.Oledb"%>

<asp:Content ID="Content2" ContentPlaceHolderID="Home_Master" runat="server">
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



<div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>

 <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>

</asp:Content>
