<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PostReBid.aspx.cs" Inherits="PostReBid"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table align="center"  class="tblBdr" cellpadding="0px" cellspacing="0px" 
        width ="50%"   >
        <tr>
            <td class="td_bgcolor" colspan="3">
                Posting Bids</td>
        </tr>
        <tr>
            <td class="style1" colspan="3" align="right">
                ( * ) Mandatory</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LblFrom" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="To" runat="server" Text="To"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LbTo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                Truck Type</td>
            <td>
                <asp:Label ID="Lbltrucktype" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                Capacity</td>
            <td>
                <asp:Label ID="Lblcapacity" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                Routeprice</td>
            <td>
                <asp:Label ID="Lblrouteprice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                Negotiable Price *</td>
            <td>
                <asp:TextBox ID="txtbidprice" runat="server" 
                    onkeypress="return onlynumber(event)" ValidationGroup="a" 
                    CssClass="txtbox"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtbidprice" ErrorMessage="Enter Bid Price" 
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                                No of Trucks req*</td>
            <td>
                <asp:TextBox ID="txttrucksreq" runat="server" 
                    onkeypress="return onlynumber(event)" ValidationGroup="a" 
                    CssClass="txtbox"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txttrucksreq" ErrorMessage="Enter no of trucks req." 
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                Remarks</td>
            <td>
                <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" 
                    CssClass="txtbox" Height="55px" Width="249px" MaxLength="1500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButSubmit" runat="server" Text="Submit" 
                    onclick="ButSubmit_Click" ValidationGroup="a" CssClass="btn" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

