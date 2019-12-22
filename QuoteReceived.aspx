<%@ Page Language="VB" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="false" CodeFile="QuoteReceived.aspx.vb" Inherits="QuoteReceived"  %>
<%@ Register Src="~/UserControl/QuoteReceivedControl.ascx" TagName ="Trip" TagPrefix="UC1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%--<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br />
 <div style="margin-left:200px">
     <UC1:Trip ID="Trip1" runat="server" />
     </div>

    <br /><br /><br /><br />
</asp:Content>

