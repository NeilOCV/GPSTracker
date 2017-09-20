<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BatteryGauge.ascx.cs" Inherits="GPSTracker.UserControls.BatteryGauge" %>
<style type="text/css">
    .TotalPanel {
        width: 102px;
        height: 20px;
        background-color: white;
        border-style: solid;
        border-width: 1px;
        border-color: black;
    }

    .ValuePanel {
        height: 100%;
        border-style: solid;
        border-width: 1px;
        border-color: black;
    }

    .Above75 {
        background-color: green;
    }

    .Above50 {
        background-color: yellow;
    }

    .Above25 {
        background-color: orange;
    }

    .Above0 {
        background-color: red;
    }
</style>
<table>
    <tr>
        <td>
            <asp:Panel runat="server" ID="pnlTotalPanel" class="TotalPanel">
                <asp:Panel runat="server" ID="pnlValuePanel" CssClass="ValuePanel"></asp:Panel>
            </asp:Panel>
        </td>
        <td style="width:5px;"></td>
        <td>
            <asp:Label Text="text" ID="lblCharge" runat="server" />
        </td>
    </tr>
</table>

