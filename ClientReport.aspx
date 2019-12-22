<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ClientReport.aspx.cs" Inherits="ClientReport" %>
<%@ Register Src="~/UserControl/MenuBar.ascx" TagName="Menu" TagPrefix="Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
 
<Menu:Menu ID="MenuBar" runat="server" />
<br />
       <div style="margin-left:450px">
    <table width="50%">
   <tr align="right" ><td style="font-size:22px;color:Red ">Reports</td><td></td></tr>
        <tr>
            <td>
                <div class="submenuin">
    <ul>
          <%--<li><a href="#"><span><img alt="RoutePrice" src="Buttons/Price Chart.jpg"/></span></a></li>--%>
          <li><a href="RoutePrice.aspx" ><span>Bid Matches</span></a></li>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
          <li><a href="TripAssignAcceptanceReport.aspx" target="_blank" ><span>Trip Assign/Acceptance Report</span></a></li>
     </ul>
  </div>
            </td>
        </tr>
      <tr>
            <td>
                <div class="submenuin">
    <ul>
          <%--<li><a href="#"><span><img alt="RoutePrice" src="Buttons/Price Chart.jpg"/></span></a></li>--%>
          <li><a href="LoadingStatus.aspx" target="_blank"  ><span>Loading Status Report</span></a></li>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
          <li><a href="DeliveryReport.aspx" target="_blank"  ><span>Delivery Report</span></a></li>
     </ul>
  </div>
            </td>
        </tr>
        
        <tr>
            <td>
                <div class="submenuin">
    <ul>
          <%--<li><a href="#"><span><img alt="RoutePrice" src="Buttons/Price Chart.jpg"/></span></a></li>--%>
          <li><a href="BidLogReport.aspx" target="_blank" ><span>BidLog Report</span></a></li>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
          <li><a href="BillStatusReport.aspx"  target="_blank"><span>Bill Status Report</span></a></li>
     </ul>
  </div>
            </td>
        </tr>
        
        
        <tr>
            <td>
                <div class="submenuin">
    <ul>
          <%--<li><a href="#"><span><img alt="RoutePrice" src="Buttons/Price Chart.jpg"/></span></a></li>--%>
          <li><a href="CollectionStatusReport.aspx" target="_blank" ><span>Collection Note Status Report</span></a></li>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
          <li><a href="CollectionNoteVSIndent.aspx" target="_blank" ><span>Collection Note VS Indent</span></a></li>
     </ul>
  </div>
            </td>
        </tr>
        
        
         <tr>
            <td>
                <div class="submenuin">
    <ul>
         
          <li><a href="ViewDetails.aspx"  target="_blank"><span>WorkFlow Snapshot</span></li>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
          <li></li>
     </ul>
  </div>
            </td>
        </tr>
        
        
            </table>
</div>
       <br /><br /><br /><br /><br /><br />
</asp:Content>

