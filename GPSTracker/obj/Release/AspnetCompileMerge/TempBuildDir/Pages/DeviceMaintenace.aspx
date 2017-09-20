<%@ Page Title="" Language="C#" MasterPageFile="~/Top.Master" AutoEventWireup="true" CodeBehind="DeviceMaintenace.aspx.cs" Inherits="GPSTracker.Pages.DeviceMaintenace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:60px;">
        
        <table style="width:100%;">
            <tr>
                <td style="width:25%; text-align:right;">Device</td>
                <td style="width:10px;"></td>
                <td><asp:DropDownList runat="server" ID="ddlDevices" CssClass="form-control" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlDevices_SelectedIndexChanged" /></td>
            </tr>
        </table>









    </div>
</asp:Content>
