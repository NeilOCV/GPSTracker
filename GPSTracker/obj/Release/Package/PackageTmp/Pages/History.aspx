<%@ Page Title="" Language="C#" MasterPageFile="~/Top.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="GPSTracker.Pages.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 60px;">
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
        <script>
            function UpdateFrom() {
                $('#btnSetFrom').click()
            }
            function UpdateTo() {
                $('#btnSetTo').click()
            }
        </script>


        <h2>Device History</h2>
        <div class="container">
            <%--<asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
                    <table>
                        <tr>
                            <td style="text-align: right">From date</td>
                            <td style="width: 10px;"></td>
                            <td style="width: 300px;">
                                <asp:TextBox runat="server" ID="txtFrom" CssClass="form-control" Width="100%" OnTextChanged="txtFrom_TextChanged" AutoPostBack="true" />
                                <ajaxToolkit:CalendarExtender runat="server" ID="ceFrom" TargetControlID="txtFrom" Format="dddd, d MMMM yyyy" Animated="true" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">To date</td>
                            <td style="width: 10px;"></td>
                            <td style="width: 300px;">
                                <asp:TextBox runat="server" ID="txtTo" CssClass="form-control" Width="100%" OnTextChanged="txtTo_TextChanged" AutoPostBack="true" />
                                <ajaxToolkit:CalendarExtender runat="server" ID="ceTo" TargetControlID="txtTo" Format="dddd, d MMMM yyyy" Animated="true" />
                            </td>
                        </tr>
                    </table>

                    <asp:GridView runat="server" AutoGenerateColumns="false" ID="grdDetail" CssClass="table table-bordered table-hover">
                        <Columns>

                            <asp:TemplateField HeaderText="Setting" HeaderStyle-BackColor="#999999" HeaderStyle-ForeColor="White" ControlStyle-Width="250">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Bind("setting") %>' ID="lblSetting" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Value" HeaderStyle-BackColor="#999999" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Bind("value") %>' ID="lblSetting" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                <div class="container">
        <div id="map" style="width:100%; height:720px; border-style:solid; border-width:1px; border-color:black; margin-top:5px; margin-bottom:5px;"></div>
    </div>








        <%--<script>
            function initMap() { var map = new google.maps.Map(document.getElementById('map'), { 
                zoom: 6, 
                center:  { lat: -28.212796400, lng: 26.904865000 }, 
                mapTypeId: 'terrain' 
            }); 

                var DrivePathCoords = [
                {lat: -25.834490200, lng: 28.294502500}, 
                {lat: -25.831008600, lng: 28.297254900}, 
                {lat: -25.826718400, lng: 28.303087900}, 
                {lat: -30.555421200, lng: 25.493900200}, 
                {lat: -30.555421200, lng: 25.493900200}
                ];
                var drivePath = new google.maps.Polyline({ 
                    path: DrivePathCoords, 
                    geodesic: true, 
                    strokeColor: '#FF0000', 
                    strokeOpacity: 1.0, 
                    strokeWeight: 2 
                }); 

                drivePath.setMap(map);
            }
</script>--%>

















    <asp:Literal runat="server" ID="litMapScript"></asp:Literal>
    <script async="async" defer="defer" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBtqD8g8Bv8e5XzuAirIcXErXfN_aECOeo&callback=initMap"></script>

                <%--</ContentTemplate>

            </asp:UpdatePanel>--%>
        </div>



    </div>
</asp:Content>
