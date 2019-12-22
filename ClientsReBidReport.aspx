<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ClientsReBidReport.aspx.cs" Inherits="ClientsReBidReport" Title="Clients ReBidReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <br /><br /><br /><br /><br /><br />
      <div style="margin-left:450px">
          <h2  class="title-one">CLIENTS REBID REPORT</h2></div>  
   
     <div style="margin-left:200px">
    <asp:Button ID="ButDownload" runat="server" Text="Download To Excel" onclick="ButDownload_Click"  Class="btn btn-primary" />
          <br /> <br />
<asp:GridView ID="GridRouteprice" runat="server" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" 
         Width="70%" AutoGenerateColumns="true">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    
    
     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
         <br /><br /><br /><br /><br />
</asp:Content>

