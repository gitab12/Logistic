<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="Mails.aspx.cs" Inherits="Mails" Title="Untitled Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br /><br /><br /><br /><br /><br />
    <div style="margin-left:500px"><asp:Button ID="ButMAIL" runat="server" Text="Send Routeprice Status" 
        onclick="ButMAIL_Click"  Class="btn btn-primary"/>
        <asp:Button ID="ButSendRebid" runat="server" onclick="ButSendRebid_Click" 
        Text="Mail for ReBid"  Class="btn btn-primary"/></div>
    <br /><br /><br /><br /><br /><br />
</asp:Content>


