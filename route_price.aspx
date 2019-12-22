<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="route_price.aspx.cs" Inherits="route_price"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style8
        {
            width: 85%;
        }
        .style12
        {
            background-color: #B70808;
            color: White;
            font-weight: 700;
            height: 28px;
            font-size: medium;
        }
        .style13
        {
           width:220px;
        }
        .style14
        {
            color: #FF0000;
           
        }
        .style15
        {
            color: #FF3300;
            text-align: right;
        }
        .style24
        {
            width: 96px;
        }
        .style25
        {
            height: 31px;
        }
        .style26
        {
            width: 113px;
        }
        .tblBdr
            {
                border: thin solid  #FF0000;
                background-color:White;
             color:Black;
             font-weight:bold;
	
            }
        .txtbox
            {
                border: 1px solid #FF0000;
                padding: 1px;
                    font-size: x-small;
                 font-family: Tahoma;
                 background-color: #ffffff;
                    font-weight: 700;
            }
        .btn
        {
   
          border-style: none;
         border-color: inherit;
         border-width: medium;
           color:Black;
         font-weight: 700;
        }
            </style>
    
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br/><br /><br />
    <div style="margin-left:200px">

    <table cellpadding="0px" cellspacing ="0px" width=400%" align="center"   class="tblBdr" >
<tr>
<td colspan="5"  class="style12">&nbsp; Route Price</td>
</tr>

<tr>
<td  colspan="5" style="text-align: right"   >
<a href="MultipleRoutePriceUpload.aspx" style="color:blue">Multiple Route Price Upload</a>

<span class="style15">(</span>
    <span>*</span><span class="style15"> ) Fields are Mandatory</span></td>
</tr>

<tr>
<td class="style25" colspan="5" style="text-align: center"   >
    <asp:Label ID="lbl_message" runat="server" 
        style="color: #009900; font-size: medium"></asp:Label>
    </td>
</tr>

<tr>
<td colspan="4" style="width:80px;">Transporter<span class="style14" style="width:80px;">*</span></td>
    <td>
    <asp:DropDownList ID="Drp_transportname" runat="server" CssClass="txtbox" Width="180px" >
    </asp:DropDownList>
    </td>
</tr>

<tr>
<td class="style13" colspan="4" >From <span class="style14">*</span></td>
    <td >
    <%--<asp:TextBox ID="txt_from" runat="server" CssClass="txtbox"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="Req_from" runat="server" 
        ControlToValidate="txt_from" ErrorMessage="From should not e mpty" 
        ValidationGroup="a"></asp:RequiredFieldValidator>--%>
         <asp:DropDownList ID="ddlfrom" runat="server" Width="180px" CssClass="txtbox">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td class="style13"  >&nbsp;</td>
<td class="style13" colspan="3"  >To <span class="style14">*</span></td>
    <td>
    <%--<asp:TextBox ID="txt_to" runat="server" CssClass="txtbox"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="Req_from0" runat="server" 
        ControlToValidate="txt_to" ErrorMessage="To should not empty" 
        ValidationGroup="a"></asp:RequiredFieldValidator>--%>
           <asp:DropDownList ID="ddlto" runat="server" Width="180px" CssClass="txtbox"
                                            onselectedindexchanged="ddlto_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList>
    </td>
</tr>
<tr>
<td class="style13">&nbsp;</td>
<td class="style13" colspan="3" >Travel Distance</td>
<td>
    <asp:TextBox ID="txtdist" runat="server" CssClass="txtbox" Width="180px">0</asp:TextBox>

</td>
</tr>

<tr>
<td class="style13" >&nbsp;</td>
<td class="style13" colspan="3">Truck type <span class="style14">*</span></td>
    <td >
    <asp:DropDownList ID="Drp_trucktype" runat="server" CssClass="txtbox" Width="180px">
    </asp:DropDownList>
    <br />
    <asp:RequiredFieldValidator ID="Req_trucktype" runat="server" 
        ControlToValidate="Drp_trucktype" ErrorMessage="Select Truck type" 
        ValidationGroup="a"  style="color:#FF0000"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td class="style13"  >&nbsp;</td>
<td class="style13" colspan="3"  >Enclosure type <span class="style14">*</span></td>
    <td >
        <asp:DropDownList ID="Drp_enclosure" runat="server" Width="180px" CssClass="txtbox" >
        </asp:DropDownList>
        <br />
    <asp:RequiredFieldValidator ID="Req_enclosure" runat="server" 
        ControlToValidate="Drp_enclosure" ErrorMessage="Select Enclosure type" 
        ValidationGroup="a"  style="color:#FF0000"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td class="style13"  >&nbsp;</td>
<td class="style13" colspan="3" >Truck Capacity <span class="style14">*</span></td>
    <td >
    <asp:TextBox ID="txt_capacity" runat="server" CssClass="txtbox" Width="180px"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="Req_truckcapcity" runat="server" 
        ControlToValidate="txt_capacity" ErrorMessage="Truck Capacity should not be empty" 
        ValidationGroup="a"  style="color:#FF0000"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td class="style13"  >&nbsp;</td>
<td class="style13" colspan="3"  >Unit <span class="style14">*</span></td>
    <td >
    <asp:DropDownList ID="Drp_capacity" runat="server" CssClass="txtbox" Width="180px">
        <asp:ListItem Value="0">Select</asp:ListItem>
        <asp:ListItem Value="1">Tons</asp:ListItem>
        <asp:ListItem Value="2">Feet</asp:ListItem>
        <asp:ListItem Value="3">MT</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:RequiredFieldValidator ID="Req_truckcapcity0" runat="server" 
        ControlToValidate="Drp_capacity" ErrorMessage="Truck unit should not be empty" 
        ValidationGroup="a"  style="color:#FF0000"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td class="style13" colspan="4"  >One way Price <span class="style14">*</span></td>
    <td class="style8">
    <asp:TextBox ID="txt_oneway" runat="server" CssClass="txtbox" Width="180px"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="Req_truckcapcity1" runat="server" 
        ControlToValidate="txt_oneway" ErrorMessage="One way Price should not be empty" 
        ValidationGroup="a"  style="color:#FF0000"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td class="style13" colspan="4"  >Two way Price <span class="style14">* </span></td>
    <td class="style8"> 
    <asp:TextBox ID="txt_twowayprice" runat="server" CssClass="txtbox" Width="180px"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="Req_truckcapcity2" runat="server" 
        ControlToValidate="txt_twowayprice" ErrorMessage="Two way Price should not be empty" 
        ValidationGroup="a"  style="color:#FF0000"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td class="style13" colspan="5"  >&nbsp;</td>
</tr>
<tr>
<td class="style1">
    &nbsp;</td>
<td class="style1">
    &nbsp;</td>
<td style="text-align: center">
    &nbsp;</td>
<td colspan="2" style="text-align: center">
    <asp:Button ID="btn_submit" runat="server" CssClass="btn" Text="Submit" 
        onclick="btn_submit_Click" ValidationGroup="a" />
    &nbsp;<asp:Button ID="btn_view" runat="server" CssClass="btn" 
        onclick="btn_view_Click" Text="View Report" />
    </td>
</tr>
<tr>
<td class="style13"  >&nbsp;</td>
<td class="style13"  >&nbsp;</td>
<td class="style24"  >&nbsp;</td>
<td class="style26"  >&nbsp;</td><td class="style8">&nbsp;</td>
</tr>
<tr>
<td class="style13"  >&nbsp;</td>
<td class="style13"  >&nbsp;</td>
<td class="style24"  >&nbsp;</td>
<td class="style26"  >&nbsp;</td><td class="style8">&nbsp;</td>
</tr>

</table> 

        </div>
    <br />/<br /><br /><br />
</asp:Content>

