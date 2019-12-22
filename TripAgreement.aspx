<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="TripAgreement.aspx.cs" Inherits="TripAgreement" %>
<%@ Register Src="~/UserControl/MenuBar.ascx" TagName="menu" TagPrefix="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
     <div class="row text-center clearfix">
								<div class="col-sm-9 col-sm-offset-3">
    <table >
        <tr>
            
            <td >
                <asp:DropDownList ID="DDLClient" runat="server" Width="245px" 
                    AutoPostBack="True" onselectedindexchanged="DDLClient_SelectedIndexChanged">
                    <asp:ListItem>-Select Client-</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
            </td>&nbsp;&nbsp;
            
            <td>
                <asp:DropDownList ID="DDLClientAddrLoction" runat="server" Width="165px">
                </asp:DropDownList>&nbsp;&nbsp;
            </td>&nbsp;&nbsp;
            <td>
                <asp:DropDownList ID="DDLTransporter" runat="server" Width="245px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DDLTransporter_SelectedIndexChanged">
                </asp:DropDownList>&nbsp;&nbsp;
            </td>&nbsp;&nbsp;
                <td>
                    <asp:Button ID="ButSubmit" runat="server" Text="Submit" 
                        onclick="ButSubmit_Click" class="btn btn-primary" />
               </td>&nbsp;&nbsp;&nbsp;
&nbsp;            <td><asp:Button ID="BtnActveTrans" runat="server" Text="Active Transporters"  class="btn btn-primary" OnClick="BtnActveTrans_Click"/></td>
        </tr>
    </table>
     <asp:Label ID="lblmsg" runat="server" Text="Agreement made successfully" Font-Bold="true" Visible="false" Font-Size="Large"></asp:Label>
    <asp:Label ID="lblmsg1" runat="server" Text="(Please enter the agreement routes)" Visible="false"></asp:Label>
<table runat="server" id="TblAgreement" visible="false">
<tr>
<td>From</td>
<td>To</td>
<td>Encl.Type</td>
<td>Truck Type</td>
<td>Capacity</td>
<td>AgreementPrice</td>
<td>TransitDays</td>
<td>EmailId</td>

</tr>
<tr>
<td><asp:TextBox ID="txtFrom" runat="server" Width="115px" ></asp:TextBox></td>
<td><asp:TextBox ID="txtto" runat="server" Width="115px"></asp:TextBox></td>
<td>
    <asp:DropDownList ID="DDLEnclType" runat="server" Width="115px"> </asp:DropDownList> </td>
<td> <asp:DropDownList ID="DDLTruckType" runat="server" Width="115px"> </asp:DropDownList> </td>
<td><asp:TextBox ID="txtCapacity" runat="server" Width="75px"></asp:TextBox></td>
<td><asp:TextBox ID="txtDecideprice" runat="server" Width="75px"></asp:TextBox></td>
   
<td><asp:TextBox ID="txttransitdays" runat="server" Width="55px" keypress="return onlynumber(event)"></asp:TextBox></td>
     <td><asp:TextBox ID="txtemailid" runat="server" Width="95px"></asp:TextBox></td>
<td><asp:Button ID="ButAssign" runat="server" Text="Add" 
        onclick="ButAssign_Click"  class="btn btn-primary"/></td>
                         
                         
</tr>
</table>
   
  <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="true" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" >

              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView> 
                                     
 <asp:Label ID="Lbl_msg" runat="server" Text="" ForeColor="Green"></asp:Label><br />
  <asp:GridView ID="Active_Transporter" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" EnableModelValidation="True">
      <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
      <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
      <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
      <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
      <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                    </div>
         </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />



</asp:Content>

