<%@ Page Title="" Language="C#" MasterPageFile="~/Top.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GPSTracker.Default" %>

<%@ Register Src="~/UserControls/BatteryGauge.ascx" TagPrefix="uc1" TagName="BatteryGauge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 60px;">
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Styling/Styles.css" rel="stylesheet" />
        <asp:GridView runat="server" ID="grdLastLogs" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" OnRowDataBound="grdLastLogs_RowDataBound">
            <Columns>

                <asp:TemplateField HeaderText="ID" Visible="false" HeaderStyle-BackColor="#999999" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:Label ID="lblID" Text='<%#Bind("device_id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Device" Visible="true" HeaderStyle-BackColor="#999999">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlDevice" Text='<%#Bind("device") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last log date (time) - (Days:Hours:Minutes:Seconds ago)" Visible="true" HeaderStyle-BackColor="#999999">
                    <ItemTemplate>
                        <asp:Label ID="lblLogDateTime" Text='<%#Bind("log_date_time") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Location provider" Visible="true" HeaderStyle-BackColor="#999999">
                    <ItemTemplate>
                        <asp:Label ID="lblLocationProvider" Text='<%#Bind("location_provider") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Battery" Visible="true" HeaderStyle-BackColor="#999999" HeaderStyle-Width="160">
                    <ItemTemplate>
                        <uc1:BatteryGauge runat="server" ID="BatteryGauge" BatteryCharge='<%#Bind("battery") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="History" Visible="true" HeaderStyle-BackColor="#999999" HeaderStyle-Width="100">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlHistory" runat="server" NavigateUrl='~/Pages/History.aspx?id=' Text="Show..." />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:HiddenField runat="server" ID="hfLongitudes" Value="" />
        <asp:HiddenField runat="server" ID="hfLatitudes" Value="" />
        <asp:HiddenField runat="server" ID="hfTitles" Value="" />
    </div>
    <style type="text/css">
        #map {
            height: 720px;
            width: 100%;
            border-style: solid;
            border-width: 1px;
            border-color: black;
            margin-bottom: 5px;
        }
    </style>

    <div class="container">
        <div id="map"></div>
    </div>
    
    <asp:Literal runat="server" ID="litMapScript"></asp:Literal>
    
</asp:Content>
