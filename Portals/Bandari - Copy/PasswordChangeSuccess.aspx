<%@ Page Title="Password Changed" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="PasswordChangeSuccess.aspx.cs" Inherits="Bandari_Sacco.PasswordChangeSuccess" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-3 col-sm-2 col-md-3 hidden-xs ">&nbsp;</div>
        <div class="col-sm-8 col-xs-12 col-md-6 col-lg-6">
            <div class="panel panel-info">
                <div class="panel-heading"><i class="fa fa-key fa-2x"></i> Bandari Sacco Portal</div>
                <div class="panel-body">

                    <div class="col-sm-8 col-xs-12">
                        <div class="form-group">
                            <asp:Label ID="lblConfirmation" runat="server" Text="Label" CssClass="alert alert-success"></asp:Label>

                                <asp:Button ID="btnRedirect" runat="server" Text="Go To Login" CssClass="btn btn-info" OnClick="btnRedirect_Click" />
                      

                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
