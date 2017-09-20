<%@ Page Title="" Language="C#" MasterPageFile="~/Top.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="GPSTracker.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .LoginPanel {
            width: 330px;
            background-color: white;
            color: black;
            border-width: 1px;
            border-color: black;
            border-style: solid;
            border-radius: 5px;
            box-shadow: 10px 10px 10px #000000;
            text-align: center;
            padding: 10px;
            padding-top: 0px;
        }

        .ModalBackground {
            background-color: darkgrey;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
    </style>
    <div style="display: none">
        <asp:Button Text="btnHidden" ID="btnHidden" runat="server" />
    </div>
    <div class="container">
        <asp:Panel runat="server" CssClass="LoginPanel" ID="pnlLoginPanel">
            <h3>Please log on</h3>
            <table style="width: 100%">
                <tr>
                    <td style="width: 100px; text-align: right;">Username</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" /></td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right;">Password</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" /></td>
                </tr>
            </table>
            <br />
            <table style="width: 100%;">
                <tr>
                    <td style="width: 50%; text-align: left;">
                        <asp:CheckBox Text="Remember me (for 24 hours)." Checked="true" runat="server" ID="chkRememberMe" /></td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: right;">
                        <asp:Button Text="Log In" runat="server" CssClass="btn btn-danger" ID="btnLogIn" OnClick="btnLogIn_Click" /></td>
                </tr>

            </table>
            <asp:Label Text="Username and/or password is incorrect." ID="lblMessage" ForeColor="Red" Visible="false" runat="server" />
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpeLogIn" PopupControlID="pnlLoginPanel" TargetControlID="btnHidden" BackgroundCssClass="ModalBackground" />
    </div>
</asp:Content>
