<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="smsmsg.aspx.cs" Inherits="HIMS.smsmsg" %>
<%@import namespace="Global.HIMS" %>
<%@Import Namespace="System.Web"%>
<%@Import Namespace="System.Web.UI"%>
<%@Import Namespace="System.Data"%>
<%@Import Namespace="System.Data.SqlClient"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Home_Master" runat="server">


<style type="text/css">
 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:10.0pt;
	font-family:"Times New Roman","serif";
	    margin-left: 0in;
        margin-right: 0in;
        margin-top: 0in;
    }
p.MsoBodyTextIndent
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Garamond","serif";
	    margin-left: 0in;
        margin-right: 0in;
        margin-top: 0in;
    }
p.MsoBodyTextIndent3
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	text-align:justify;
	font-size:12.0pt;
	font-family:"Garamond","serif";
	}
    .style1
    {
        text-align: left;
    }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            color: #6699FF;
        }
        .style4
        {
            text-decoration: underline;
        }
        .style5
        {
            color: red;
            font-size: larger;
        }
        .style6
        {
            font-family: "Palatino Linotype";
        }
        .style7
        {
            background-color: #0066FF;
        }
        .style8
        {
            color: white;
        }
        .style11
        {
            background-color: #33CC33;
            color: #FFFFFF;
        }
        .style12
        {
            background-color: #FFCC00;
        }
        .style13
        {
            font-size: medium;
        }
        .style14
        {
            color: red;
        }
    </style>

<div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</div>

<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> NEW BULK SMS </b> </h6>
</div>

<br/>
<center>
<table class="regTable1" width="60%"  style="border: thin ridge #C0C0C0;">
    <tr>
        <td style="padding-left:30px;" colspan="2">
            <br />
            <asp:Label ID="Label1" runat="server">Upload phone numbers:</asp:Label>
            <asp:FileUpload ID="FileUploadToServer" Width="350px" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                ValidationGroup="vg" style="width: 99px" />
            <br /><br />
        </td>
    </tr>

    <tr>
        <td style="padding-left:30px; border-bottom-width:0; " colspan="2">
            <br />
            <asp:Label ID="lbltxtmsg" runat="server">SMS message:</asp:Label>
        </td>
    </tr>

    <tr>
        <td style="padding-left:30px; border-top-width:0; border-bottom-width:0; " colspan="2">
            <asp:TextBox ID="txtMsg" TextMode="MultiLine" runat="server" Height="50" Width="90%" BorderColor="#999999" BorderStyle="Solid"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMsg" 
                ErrorMessage="SMS message is mandatory." ToolTip="SMS message is mandatory." 
                ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span>
            </asp:RequiredFieldValidator> 
        </td>
    </tr>

    <tr>
        <td class="submitButton2" style="padding-left:30px; border-top-width:0;" colspan="2">
            <asp:Button style="" ID="Send" runat="server" 
                CommandName="Save" Text="Send" Width="65px"   
                ValidationGroup="LoginUserValidationGroup" onclick="save_Click"/>
            <br />
            <br />
        </td>
    </tr>

    <tr>
        <td style="padding-left:30px;border-top-width:0;border-bottom-width:0;" colspan="2">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Text=""></asp:Label>
        </td>
    </tr>

    <tr>
        <td style="padding-left:30px;border-top-width:0;" colspan="2">        
            <asp:Label ID="lblSMSMsgInfo" runat="server" ForeColor="green" Text=""></asp:Label>
        </td>
    </tr>

    <%--<tr>
        <td style="padding-left:30px;">
            <br />
            <asp:Label ID="Label2" runat="server"><span class="label">Message to send:</span></asp:Label>
        </td>
        <td style="padding-left:30px;">
            <asp:Label ID="lblSMSMsg" runat="server" ForeColor="blue" Text=""></asp:Label>
            <br />
        </td>
    </tr>--%>
    <tr style="border: thin ridge #C0C0C0;" >

        <td style="padding-left:30px;border-top-width:0;border-bottom-width:0;" colspan="2">        

            <%--<asp:Label ID="Label1" runat="server"><span class="label">Message Recipients (To send the SMS scroll to the bottom of the page and click send button):</span></asp:Label>--%>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No phone numbers found." 
                Height="25px">
                <RowStyle Width="175px" />
                <EmptyDataRowStyle BackColor="Silver" BorderColor="#999999" BorderStyle="Solid" 
                    BorderWidth="1px" ForeColor="#003300" />
                <HeaderStyle BackColor="#6699FF" BorderColor="#333333" BorderStyle="Solid" 
                    BorderWidth="1px" VerticalAlign="Top" Width="200px"  Wrap="True" />
              
            </asp:GridView>
   
        </td>
    </tr>


</table>
</center>

</asp:Content>
