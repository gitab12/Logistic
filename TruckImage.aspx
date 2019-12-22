<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TruckImage.aspx.cs" Inherits="TruckImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
     <link href="Stylesheet/style.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/> 
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</head>
<body>
    <form id="form1" runat="server">
        <br />
        <center>       <asp:Button runat="server" ID="btnZoomIn" OnClick="ChangeSize" Text="ZoomIn" CommandName="ZI"  Class="btn btn-primary"/>
        <asp:Button runat="server" ID="btnZoomOut" OnClick="ChangeSize" Text="ZoomOut" CommandName="ZO" Class="btn btn-primary" /> <br />
        <br />
    <asp:Image ID="TruckImagebox" runat="server" Height="300px" Width="300px" /><br />
            </center>

    </form>
</body>
</html>
