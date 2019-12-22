<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CollectionNotePrint.aspx.cs" Inherits="CollectionNotePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</head>
<body>
    <form id="form1" runat="server">
  <%--<asp:Button ID="Print" runat="server" Text="Print Collection Note" />--%>
     <input type="button" value="Print This Page" onclick="window.print()" />
    <br />
        <center>
    <asp:Image ID="BillImage" runat="server" Height="1000px" Width="900px" />
            </center>
    </form>
</body>
</html>
