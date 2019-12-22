<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="User_map.aspx.cs" Inherits="User_map"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br />
    <div style="margin-left:300px">
<asp:Repeater id="parentRepeater" runat="server" 
        onitemcreated="parentRepeater_ItemCreated" 
        onitemdatabound="parentRepeater_ItemDataBound">
<itemtemplate>

<asp:Label ID="lbladid" runat="server" Text=' <%# Eval("ServicePortalName")%>'></asp:Label><br />
     <hr />
     <asp:Repeater id="childRepeater" runat="server">
<itemtemplate>
&nbsp;&nbsp;&nbsp;<asp:Label ID="lblad" runat="server" Text=' <%# Eval("ServicePortalCategoryName")%>'></asp:Label><br />
     <asp:Repeater id="childRepeater2" runat="server">
<itemtemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblchild2" runat="server" Text=' <%# Eval("FeatureName")%>'></asp:Label><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table cellpadding="0PX" cellspacing="0PX" align="center">
                    <tr><td width="150px">Read</td><td width="150px">Write</td><td width="150px">Download</td><td width="150px">Copy</td></tr>
                    <tr><td><asp:CheckBox ID="Chk_read" runat="server"/></td><td><asp:CheckBox ID="Chk_write" runat="server" /></td><td><asp:CheckBox ID="Chk_download" runat="server" /></td><td><asp:CheckBox ID="Chk_copy" runat="server" /></td></tr>
                    </table>
</itemtemplate>
</asp:Repeater>
</itemtemplate>
</asp:Repeater>
</itemtemplate>
</asp:Repeater>
</div>
     <br /><br /><br /><br /><br />
</asp:Content>

