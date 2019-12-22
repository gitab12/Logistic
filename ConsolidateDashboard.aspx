<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="ConsolidateDashboard.aspx.cs" Inherits="ConsolidateDashboard" Title="ConsolidateDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />
<table >
<tr>
<td style="color: #FF0000" align="center">
<strong > Trip Plan Posted</strong>
    <asp:Button ID="But_Trip" runat="server" onclick="But_Trip_Click"  Text="Download"  Class="btn btn-primary"/>
</td>
<td style="color: #FF0000" align="center">
<strong> Route Price Received</strong>
    <asp:Button ID="But_RoutePrice" runat="server" onclick="But_RoutePrice_Click"   Text="Download"  Class="btn btn-primary" />
</td>
</tr>

<tr>
      
<td>
    <br />
 <asp:Panel ID="pnl_clientplan" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1000px" ScrollBars="Auto"  Style="margin-left:10px" >
 <asp:GridView ID="LogisticsPlanGrid" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical">
     <RowStyle BackColor="#F7F7DE" />
     <FooterStyle BackColor="#CCCC99" />
     <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
     <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
      </asp:Panel>
</td>
  

<td>

     <asp:Panel ID="Panel2" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1000px" ScrollBars="Auto">
<asp:GridView ID="QuoteReceivedGrid" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="Vertical" >
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
    
    </asp:GridView>
          </asp:Panel>
  </td>
</tr>

</table>
   
</asp:Content>

