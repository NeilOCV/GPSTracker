<%@ Page Title="" Language="C#" MasterPageFile="~/Top.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="GPSTracker.Pages.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hfSelectedDate" Value="NothingSelectedYet" />
    <div class="container" style="margin-top: 55px;">
        <h2>Device History</h2>
        <asp:Panel runat="server" Width="100%" Height="50px" ScrollBars="Auto" ID="pnlDeviceStats">
        </asp:Panel>

        <table>
            <tr>
                <td>Show history for: </td>
                <td style="width: 5px"></td>
                <td style="width: 300px;">
                    <asp:TextBox runat="server" ID="txtHistoryDate" CssClass="form-control" Width="100%" OnTextChanged="txtHistoryDate_TextChanged" AutoPostBack="true"  ViewStateMode="Enabled" EnableViewState="true"   />
                    <ajaxToolkit:CalendarExtender runat="server" ID="ceHistoryDate" Format="dddd, d MMMM yyyy" TargetControlID="txtHistoryDate" ViewStateMode="Enabled" EnableViewState="true"  />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
