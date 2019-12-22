<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostedAdByClient.aspx.cs" Inherits="PostedAdByClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    	<link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/> 
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="ButDownload" runat="server" Text="Download" 
            onclick="ButDownload_Click"  class="btn btn-primary" />
            &nbsp;&nbsp;
        <asp:Button ID="btn_Update" runat="server" Text="Update" onclick="btn_Update_Click"  class="btn btn-primary"/>
        <br /> <br /> 

       <asp:GridView ID="Gridwindow" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="90%" DataKeyNames ="LogisticsPlanID"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="false">
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
              <Columns>
              <asp:BoundField DataField ="AdID" HeaderText ="AdID" />
              <asp:BoundField DataField ="FromLocation" HeaderText ="FromLocation" />
              <asp:BoundField DataField ="ToLocation" HeaderText ="ToLocation" />
              <asp:BoundField DataField ="TravelDate" HeaderText ="TravelDate" />
              <asp:BoundField DataField ="ProductName" HeaderText ="ProductName" />
              <asp:TemplateField HeaderText ="ClientPrice">
              <ItemTemplate >
              <asp:TextBox ID="txt_DecidePrice" runat ="server" BackColor ="Khaki"  Text ='<%#Eval("DecidePrice") %>' Width ="50px" ></asp:TextBox>
              </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField HeaderText ="CostperTruck">
              <ItemTemplate >
              <asp:TextBox ID="txt_CostPerTruck" runat ="server" BackColor ="Khaki"  Text ='<%#Eval("CostPerTruck") %>' Width ="50px" ></asp:TextBox>
              </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField ="NoOfTrucks" HeaderText ="NoOfTrucks" />
              <asp:BoundField DataField ="TruckType" HeaderText ="TruckType" />
              <asp:BoundField DataField ="EnclosureType" HeaderText ="EnclosureType" />
              <asp:BoundField DataField ="TruckCapacity" HeaderText ="TruckCapacity" />
              <asp:BoundField DataField ="TransitDay" HeaderText ="TransitDay" />
              <asp:BoundField DataField ="PostedDate" HeaderText ="PostedDate" />
              </Columns>
          </asp:GridView>
    </form>
</body>
</html>
