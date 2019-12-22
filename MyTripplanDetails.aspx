<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="false" CodeFile="MyTripplanDetails.aspx.vb" Inherits="MyTripplanDetails"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br><br /><br>
<div style="margin-left:400px">              
    <table Width="70%" >
        <tr>
            <td style="color:red">
                Logistic PlanNo</td>
            <td >
                <asp:Label ID="LblPlanno" runat="server"  ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Travel Date</td>
            <td>
                <asp:Label ID="Lbltraveldate" runat="server"  ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="color:red">
                No of Trucks Req.</td>
            <td >
                <asp:Label ID="Lblnooftrucks" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Truck Type/Capacity</td>
            <td>
                <asp:Label ID="LblTrucktype" runat="server" ForeColor="Red"></asp:Label>
            </td>
                       </tr>
                       <tr>
                           <td style="color:red">
                               Product Name</td>
            <td >
                <asp:Label ID="Lblproductname" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Quantity</td>
            <td>
                <asp:Label ID="LblQuantity" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        
        <tr>
                           <td style="color:red">
                              Enclosure Type</td>
            <td >
                <asp:Label ID="lblEncl" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Transit Days</td>
            <td>
                <asp:Label ID="lblTransit" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        
        
        <tr>
            <td style="color:red">
                Weight</td>
            <td >
                <asp:Label ID="Lblweight" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Length</td>
            <td>
                <asp:Label ID="Lbllength" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="color:red">
                Source</td>
            <td >
                <asp:Label ID="Lblsource" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Destination</td>
            <td>
                <asp:Label ID="LblDesination" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="color:red">
                Travel Type</td>
            <td >
                <asp:Label ID="Lbltraveltype" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Posted On</td>
            <td>
                               <asp:Label ID="Lblpostedon" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="color:red">
                Cost per Truck</td>
            <td >
                <asp:Label ID="Lblcostpertruck" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Volume</td>
            <td>
                <asp:Label ID="Lblvolume" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="color:red">
                Width</td>
            <td >
                <asp:Label ID="Lblwidth" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="color:red">
                Height</td>
            <td>
               <asp:Label ID="Lblheight" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    <br><br /><br><br><br /><br>
</asp:Content>

