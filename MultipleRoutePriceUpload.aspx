<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="MultipleRoutePriceUpload.aspx.cs" Inherits="MultipleRoutePriceUpload" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br /><br /><br />
    <div style="margin-left:550px">
<a href="http://www.scmbizconnect.com/excel/RoutePrice.xls" style="color:blue;text-decoration:underline;">Download Route Price Template for Multiple Upload</a><br />
    <asp:FileUpload ID="ExcelUpload" runat="server" />
        <br />
    <asp:Button ID="cmdUploadAndDisplay" runat="server" 
       Text="Validate"  onclick="cmdUploadAndDisplay_Click1"  Class="btn btn-primary"/>
    <asp:Button ID="Upload" runat="server" Text="Upload" onclick="Upload_Click" 
        Enabled="False"   Class="btn btn-primary"/>
        </div>
      <asp:Panel ID="pnl_1" runat="server"   Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:350px" >
        <asp:GridView ID="UploadGridview" runat="server" Width="70%" 
        ForeColor="#333333" GridLines="both" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
        </asp:Panel>
    <br />    <br /><br /><br /><br /><br /><br />
</asp:Content>

