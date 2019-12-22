<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DispatchPlan_Report.aspx.cs" Inherits="DispatchPlan_Report" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .color {
     font-family: Arial, Helvetica, sans-serif;
     font-size: 2.0em;
     font-style: bold;
     color:Red;
 }
</style>
 <br /><br /><br /><br /><br /><br />
      <div style="margin-left:450px">
    <left><h2 class="title-one">Dispatch Plan Report</h2></left>
          </div>
    <asp:Panel ID="panel1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px">
<asp:GridView ID="GridDispatchplan" runat="server" BorderColor="Black" OnDataBound="GridDispatchplan_DataBound" BackColor="White" GridLines="Both" 
    CellPadding="4" ForeColor="#333333" 
         Width="70%" AutoGenerateColumns="True">
    <RowStyle BackColor="White" ForeColor="#333333" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#B70808" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
        </asp:Panel>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

