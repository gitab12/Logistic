<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Register Src="~/UserControl/LeftControl.ascx" TagName="left" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link1" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
            
    <meta name="keywords" content="BizConnect, Supply Chain Management, Road Transports, Indian Road Transportation, Supply Demand Matching, Trucks Available, Trucks Wanted, Goods Transport, Logistics"  />
	<meta name="description" content="SCM Junction is an initiative from AARM SCM Solutions Pvt. Ltd., Bengaluru, India; to build a logistics open platform to match supply and demand of road transportation in India." />
	<meta name="author" content="AARM SCM Solutions Pvt. Ltd." />
	<meta name="robots" content="ALL"/>
	<meta name="revisit-after" content="1 days"/>
	<meta name="classification" content="Website, Corporate"/>
	<meta name="distribution" content="Global"/>
	<meta name="rating" content="General"/>
	<meta name="copyright" content="Copyright (C) 2011, AARM SCM Solutions Pvt. Ltd." />
	<meta name="language" content="English"/>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<script type="text/javascript" src="himagefall/picture-fall.js"></script>--%>


<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-36299508-1']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>
<uc1:left ID="left1" runat="server" />
</asp:Content>

