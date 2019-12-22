<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AllRoutePrices.aspx.cs" Inherits="AllRoutePrices" Title="RoutePrices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br /><br />
       <div style="margin-left:350px">
           <h2 class="title-one">BID MANAGEMENT REPORT</h2>

       </div>
     <div style="margin-left:300px">  
    <asp:Button ID="QuoteReceived" runat="server" Text="Quote Received" onclick="QuoteReceived_Click" Visible="false" />
        <asp:DropDownList ID="DDLFromLoc" runat="server" Width="150px">
    </asp:DropDownList>
     <asp:DropDownList ID="DDLClient" runat="server" Width="150px">
    </asp:DropDownList> 
     <asp:DropDownList ID="DDLTransporter" runat="server" Width="150px">
    </asp:DropDownList> 
    <asp:Button ID="ButSearch" runat="server" Text="Search" 
        onclick="ButSearch_Click"  Class="btn btn-primary"/>
          <asp:Button ID="But_Download" runat="server" Text="Export to Excel" 
        onclick="But_Download_Click"  Class="btn btn-primary"/>
          </div> 
    <br />

  <asp:Panel ID="pnl_1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:10px" >
    <asp:GridView ID="GridRoutePrice" runat="server"  BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" 
         Width="95%" AutoGenerateColumns="true">
  
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
      </asp:Panel>
</asp:Content>