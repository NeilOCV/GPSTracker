<%@ Page Title="" Language="C#" MasterPageFile="~/Top.Master" AutoEventWireup="true" CodeBehind="DeviceStats.aspx.cs" Inherits="GPSTracker.Pages.DeviceStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:60px;">
    <h2>Device stats</h2>
    <div class="container">
        
        <asp:GridView runat="server" AutoGenerateColumns="false" ID="grdDetail" CssClass="table table-bordered table-hover" >
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
        

    </div>
    
        </div>
</asp:Content>
