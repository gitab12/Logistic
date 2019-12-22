<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillvalidatedbyAarms.aspx.cs" Inherits="BillvalidatedbyAarms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title></head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server"  Height="500px" Width="80%" ScrollBars="Auto"  Style="margin-left:100px;margin-top:50px;" >
    <asp:GridView ID="grd_Billvalidated" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="90%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="True" GridLines ="Both">
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
