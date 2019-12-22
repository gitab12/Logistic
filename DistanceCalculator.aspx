<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistanceCalculator.aspx.cs" Inherits="DistanceCalculator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<br />
<br />
<center>
    <asp:Label ID="lblheader" runat="server" Text="Distance Calculator" Font-Bold="true" Font-Size="Medium"></asp:Label>
    <br />
    <br />
    
<asp:Label ID="lbltitle" runat="server" Text="Select Location To Calculate Distance" Font-Size="13px"></asp:Label>
<br />
<br />
    <asp:Label ID="lblfrtitle" runat="server" Text="From Location"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Label ID="lbltotitle" runat="server" Text="To Location"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlfrom" runat="server" Width="170px">
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

<asp:DropDownList ID="ddlto" runat="server" Width="170px">
</asp:DropDownList>
<br />
<br />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<center>     <asp:ImageButton ID="imggo" runat="server" 
        ImageUrl="~/images/imagesCAB6GIIH.jpg" onclick="imggo_Click"   /></center>
        <%--<asp:Button ID="ImageButtonPostAds" runat="server" 
                                             CssClass="formbtn" Text="Submit" onmouseup="showPleaseWait()"
                                            ValidationGroup="a" onclick="ImageButtonPostAds_Click" />--%>
                <br />
                <br />
            
    <asp:Label ID="lbldist" runat="server" Visible="false" Font-Bold="true" Font-Size="Larger"></asp:Label>
          </center>      
   </div>
    </form>
</body>
</html>


