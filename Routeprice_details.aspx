<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Routeprice_details.aspx.cs" Inherits="Routeprice_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="gv_RoutepriceDetails" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
       <Columns>
        <asp:BoundField DataField="LogisticsPlanID" HeaderText="LogisticsPlanID" />
        <asp:BoundField DataField="LogisticsPlanNo" HeaderText="LogisticsPlanNo" />
        <asp:BoundField DataField="FromLocation" HeaderText="From Location" />
        <asp:BoundField DataField="ToLocation" HeaderText="To Location" />
         <asp:BoundField DataField="Traveldate" HeaderText="TravelDate" />
        <asp:BoundField DataField="TruckType" HeaderText="Truck Type" />
        <asp:BoundField DataField="EnclosureType" HeaderText="Encl.Type" />
        <asp:BoundField DataField="Capactiy" HeaderText="Capacity" />
         <asp:BoundField DataField="EarlierQuote" HeaderText="Earlier Quote" />
        <asp:BoundField DataField="Oneway_Price" HeaderText="Route Price" />
        
         <asp:BoundField DataField="QuoteDate" HeaderText="Quoted Date" />
   
             <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
    </Columns>
      </asp:GridView>
    </div>
    </form>
</body>
</html>
