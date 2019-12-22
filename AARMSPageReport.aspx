<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AARMSPageReport.aspx.cs" Inherits="AARMSPageReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
<title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport | Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br />
<div style="margin-left:500px"> 
     <asp:Button ID="Butexporttoexcel" runat="server" Text="Export To Excel" onclick="Butexporttoexcel_Click"  Class="btn btn-primary" />
    </div>
    <br />
    <asp:Panel ID="AarmsVehicleReport" runat="server"  BorderColor="#0000" BorderStyle="Solid" Font-Bold="false" Height ="310px" ScrollBars="Auto" Width="73%" GroupingText="" Style="margin-left:200px">
<asp:GridView ID="grd_AarmsReport" runat="server" CellPadding="4" 
                    ForeColor="#333333">
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>

    </asp:Panel>
    <br /><br /><br /><br /><br />
</asp:Content>

