<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RFIDDemo.aspx.cs" Inherits="RFIDDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/> 

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="margin-left:200px">
        <br /><br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
         <br />
        <asp:Button ID="Button1" runat="server" Text="Click Me" OnClick="Button1_Click"  Class="btn btn-primary" />
       
        <br /><br />
        <asp:Button ID="Button2" runat="server" Text="Click Me" OnClick="Button2_Click" Class="btn btn-primary" />
        <br /> <br />
        <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    </div>
        </div>
    </form>
</body>
</html>
