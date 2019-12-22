<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MyQuotes.aspx.cs" Inherits="MyQuotes"  %>
<%@ Register Src="~/UserControl/MyQuotesControl.ascx" TagName="Quotes" TagPrefix="UCQ" %>
<%@ Register Src="~/UserControl/NavigationControlHome.ascx" TagPrefix="Uc4" TagName="DashboardMenuBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <br /><br /><br /><br /><br /><br />
   
            <Uc4:DashboardMenuBar runat="server" id="DashboardMenuBar" />
     <div style="margin-left:300px">
    <UCQ:Quotes runat="server" id="MyQuotesControl" />
        </div>

      <br /><br /><br /><br /><br /><br />
</asp:Content>

