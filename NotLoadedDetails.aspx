<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotLoadedDetails.aspx.cs" Inherits="NotLoadedDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
	<!--<link href="css/font-awesome.min.css" rel="stylesheet"> -->
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblcount" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
    </div> 
        <div>
            <center><h2 class="title-one">Not Loaded Details</h2></center>

            <asp:GridView ID="GridView_NotLoaded" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="90%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="True" >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>

        </div>
    </form>
</body>
</html>
