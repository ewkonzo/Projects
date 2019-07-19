<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bandari_Sacco.Login1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-lg-3 col-sm-2 col-md-3 hidden-xs ">&nbsp;</div>
    <div class="col-sm-8 col-xs-12 col-md-6 col-lg-6">
            <div class = "panel panel-info">
                <div class="panel-heading text-center "><i class="fa fa-users fa-2x"></i>  Members Portal Login</div>
                <div class="panel-body">
                <div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>
                    <div class="row">
                        <div class="col-sm-4 hidden-xs">
                        <img src="images/bandari_logo.jpg" alt="bandari sacco ltd" />
                            </div>
                        <div class="col-sm-4 col-xs-12">
	                         <div class="form-group">
	                              <asp:Label ID="User_NoLabel" runat="server" AssociatedControlID="User_No"><span class="text-danger">Login ID.</span></asp:Label>
                                   <asp:TextBox ID="User_No" runat="server" CssClass="form-control" placeholder="Login No." ToolTip="Please enter your login ID"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="User_NoRequired" runat="server" ControlToValidate="User_No" 
                                            CssClass="failureNotification" ErrorMessage="Login ID is required." ToolTip="Login ID is required." 
                                            ValidationGroup="LoginUserValidationGroup"><span class="ui-state-error"><i class="fa fa-exclamation-circle"></i> Please enter your login ID.</span></asp:RequiredFieldValidator>

	                         </div> 
                           <div class="form-group">
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"><span class="text-danger passwordEntry">Password</span></asp:Label>
                            <asp:TextBox ID="Password" runat="server"  CssClass="form-control" TextMode="Password" placeholder="Password" ToolTip="please enter your password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                    ValidationGroup="LoginUserValidationGroup"><span class="ui-state-error"><i class="fa fa-exclamation-circle"></i> Please enter your password.</span></asp:RequiredFieldValidator>
                               </div>
                                <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-info" CommandName="Login" Text="Login" 
                                    ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click">
                                                </asp:Button>

                        </div>
                    </div>
                    </div>
            </div>
    </div>
    <div class="col-lg-3 col-sm-2 col-md-3 hidden-xs hidden-sm">&nbsp;</div>
</div>

</asp:Content>
