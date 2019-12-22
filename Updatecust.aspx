<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updatecust.aspx.cs" Inherits="Updatecust" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
   <%--<script type="text/javascript">
//       function Showalert() {
//           alert('Changes saved successfully.');
//            if (alert) {
//                window.close();
//            }
//        }
    </script> --%>
 
       
</head>
<body onunload="opener.location=('rpt_route_price.aspx')">
    <form id="form1" runat="server">        
        <div>
    <asp:Panel ID="EditPanel" runat="server" Width="270px" Height="280px" 
                style="top: 71px; left: 113px; position: absolute">
<h5>UPDATE ROUTE PRICE ANNEXURE</h5>
<table>
<tr>
<td>
    <asp:Label ID="lbltransportname" runat="server" Text="Transporter_Name"></asp:Label>
</td>
<td>
    <asp:Label ID="UpdTransporter" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblSrc" runat="server" Text="Source"></asp:Label>
</td>
<td>
    <asp:Label ID="UpdSource" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lbldest" runat="server" Text="Destination"></asp:Label>
</td>
    <td>
        <asp:Label ID="UpdDestination" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lblcapa" runat="server" Text="Capacity"></asp:Label>
</td>
<td>
    <asp:Label ID="UpdCapacity" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblunt" runat="server" Text="Unit"></asp:Label>
</td>
<td>
    <asp:Label ID="Updunit" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lbloneway" runat="server" Text="Oneway_Price"></asp:Label>
</td>
<td>
    <asp:TextBox ID="Updtxtone" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lbltwo" runat="server" Text="Twoway_Price"></asp:Label>
</td>
<td>
    <asp:TextBox ID="Updtxttwo" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click"/>
</td>
<td>
  <asp:Button ID="btncancel" runat="server" Text="Cancel" 
        onclick="btncancel_Click" OnClientClick="window.close()" />
</td>
</tr>
</table>

</asp:Panel>
    </div>
    </form>
</body>
</html>
