<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ads_Portal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link href="~/Content/bootstrap.min.css" rel="stylesheet" /> 
    <link href="~/Content/Site.css" rel="stylesheet" /> 
    <title>
        ADS Nyanza Login

    </title>
</head>
<body>
     <div class="center-div">
         <form runat="server">
   <dx:BootstrapFormLayout runat="server">
    <Items>
        <dx:BootstrapLayoutItem Caption="User Name" ColSpanMd="6">
            <ContentCollection>
                <dx:ContentControl>
                    <dx:BootstrapTextBox runat="server"  />
                </dx:ContentControl>
            </ContentCollection>
        </dx:BootstrapLayoutItem>
        <dx:BootstrapLayoutItem Caption="Password" ColSpanMd="6">
            <ContentCollection>
                <dx:ContentControl>
                    <dx:BootstrapTextBox runat="server" Password="true"   />
                </dx:ContentControl>
            </ContentCollection>
        </dx:BootstrapLayoutItem>
        <dx:BootstrapLayoutItem Caption="" ColSpanMd="6" HorizontalAlign="Center">
            <ContentCollection>
                <dx:ContentControl>
                    <dx:BootstrapButton runat="server" Text="Login"/>
                    <dx:BootstrapButton runat="server" Text="Login"/>
                </dx:ContentControl>
            </ContentCollection>
        </dx:BootstrapLayoutItem>  
       
    </Items>
</dx:BootstrapFormLayout>

         </form>
            </div>
</body>
</html>
