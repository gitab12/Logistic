<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ParcelModule.aspx.cs" Inherits="ParcelModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

    <style type="text/css">
        .auto-style2 {
            width: 127px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div Style="margin-left:300px">
    <table >
        <tr>
            
            <td >
                <asp:DropDownList ID="DDLClient" runat="server" Width="245px" 
                    AutoPostBack="True" onselectedindexchanged="DDLClient_SelectedIndexChanged">
                    <asp:ListItem>-Select Client-</asp:ListItem>
                </asp:DropDownList>
            </td>
            
            <td >
                <asp:DropDownList ID="DDLClientAddrLoction" runat="server" Width="117px" Height="19px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DDLTransporter" runat="server" Width="239px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DDLTransporter_SelectedIndexChanged" Height="34px">
                </asp:DropDownList></td>
                <td>
                    &nbsp;</td>
        </tr>
        <tr>
            
            <td >
                Basic Charges</td>
            
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
                <td>
                    &nbsp;</td>
        </tr>
        <tr>
            
            <td >
                Freight Surcharges(FSC) in %<br />
                <asp:TextBox ID="txtFSCpercent" runat="server" Width="96px" text="0"></asp:TextBox>
            </td>
            
            <td >
                Value Surcharges(VSC) in %<br />
                <asp:TextBox ID="txtVSCpercent" runat="server" Width="96px" text="0"></asp:TextBox>
                <br />
            </td>
            <td>
                Freight on Value (FOV) in %<br />
                <asp:TextBox ID="txtFOVpercent" runat="server" Width="96px" text="0"></asp:TextBox>
                    <br />
                    </td>
                <td>
                    &nbsp;</td>
        </tr>
        <tr>
            
            <td >
                Document Hiring Charge(DHC)<br />
                <asp:TextBox ID="txtDHC" runat="server" Width="96px" text="0"></asp:TextBox>
            </td>
            
            <td >
                Intimation Charges<br />
                <asp:TextBox ID="txtinitimation" runat="server" Width="96px" text="0"></asp:TextBox>
            </td>
            <td>
                    Minimum Charges<br />
                    <asp:TextBox ID="txtminimumbasic" runat="server" Width="85px" text="0"></asp:TextBox></td>
                <td>
                    <asp:Button ID="ButSubmit" runat="server" Text="Submit" 
                        onclick="ButSubmit_Click" Width="81px" Class="btn btn-primary"/>
               </td>
        </tr>
         <tr>
            
            <td >
                LR Charges<br />
                <asp:TextBox ID="txtLRcharges" runat="server" Width="96px" text="0"></asp:TextBox>
            </td>
            
            <td >
                &nbsp;</td>
            <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
        </tr>
        <tr>
            
            <td >
                <strong>Door Delivery Charges</strong></td>
            
            <td >
                No of Boxes<br />
    <asp:DropDownList ID="ddl_CotonBox" runat="server" width="67px" Height="16px">
       
         <asp:ListItem>--No of Boxes--</asp:ListItem>
         <asp:ListItem>1</asp:ListItem>
         <asp:ListItem>2</asp:ListItem>
           <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
    </asp:DropDownList>
            </td>
            <td>
                Charges<br />
                <asp:TextBox ID="txtDoordeliverycharges" runat="server" Width="96px" text="0"></asp:TextBox>
            </td>
                <td>
                    <asp:Button ID="ButAddslab" runat="server" Text="Add Slab" OnClick="ButAddslab_Click" Class="btn btn-primary"/></td>
        </tr>
    </table>
        </div>
     <div Style="margin-left:300px">
     <asp:Label ID="lblmsg" runat="server" Text="Agreement made successfully" Font-Bold="true" Visible="false" Font-Size="Large"></asp:Label>
    <asp:Label ID="lblmsg1" runat="server" Text="(Please enter the agreement routes)" Visible="false"></asp:Label>
         </div>
     <div Style="margin-left:350px">
    <table runat="server" id="TblAgreement" visible="false">
<tr>
<td>From</td>
<td>To</td>
<td>UOM</td>
<td>Rupees/Basic</td>
<td>TransitDays</td>
<td></td>
</tr>
<tr>
<td><asp:TextBox ID="txtFrom" runat="server" ></asp:TextBox></td>
<td><asp:TextBox ID="txtto" runat="server"></asp:TextBox></td>

<td>
    <asp:DropDownList ID="ddl_UOM" runat="server" width="67px" Height="16px">
       
         <asp:ListItem>KG</asp:ListItem>
         <asp:ListItem>KM</asp:ListItem>
         <asp:ListItem>Nos</asp:ListItem>
    </asp:DropDownList>
            </td>
<td><asp:TextBox ID="txtDecideprice" runat="server" Width="75px"></asp:TextBox></td>
<td><asp:TextBox ID="txttransitdays" runat="server" Width="75px" keypress="return onlynumber(event)"></asp:TextBox></td>
<td><asp:Button ID="ButAssign" runat="server" Text="Add"  onclick="ButAssign_Click" Class="btn btn-primary" /></td>
                         
</tr>
</table>
    </div>
      <asp:Panel ID="panel_1" runat="server"   Height ="270px" ScrollBars="Auto" Width="93%" GroupingText="" Style="margin-left:300px">
  <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="true" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True"  Style="margin-left:150px">

              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>  
</asp:Panel>
     <br /><br /><br /><br /><br /><br />
</asp:Content>

