﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delayed.aspx.cs" Inherits="Delayed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
<link href="css/animate.css" rel="stylesheet" />
<link href="css/bootstrap.min.css" rel="stylesheet" />
<link href="css/font-awesome.min.css" rel="stylesheet" />
<link href="css/jquery.sidr.dark.css" rel="stylesheet" />
<link href="css/main.css" rel="stylesheet" />
<link href="css/prettyPhoto.css" rel="stylesheet" />
<link href="css/reset.css" rel="stylesheet" />
<link href="css/responsive.css" rel="stylesheet" />
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
    
    <asp:SqlDataSource ID="ds_ProjectNo" runat="server" ConnectionString="<%$ ConnectionStrings:BizCon %>" SelectCommand="select distinct ProjectNo   from CollectionNote "></asp:SqlDataSource>
    
        <center><h2 class="title-one">Vehicle Not Loaded (Delayed)</h2></center>

    <table><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ProjectNo :</td></tr> 
        <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddl_ProjectNo" runat="server" AppendDataBoundItems="True" DataSourceID="ds_ProjectNo"  DataTextField="ProjectNo" DataValueField="ProjectNo" >
            <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList></td>
            <td>
               <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" /></td>
           <td>
               <asp:Button ID="Button1" runat="server" Text="Download" onclick="Button1_Click"  />
           </td>
           </tr>
           </table>
    
        <asp:GridView ID="grd_VehDelayed" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="Both">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
             <EmptyDataTemplate >
                <asp:Label ID ="lbl_Msg" runat ="server" ForeColor ="Red" Font-Bold ="true" Text ="No data found"></asp:Label>
            </EmptyDataTemplate>

        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
