<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

  <link href="../Stylesheet/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div style="margin-left:600px">
        <h2 class="title-one">Reports</h2>
    </div>
    <div style="margin-left:400px">
   <table width="50%">
   <tr align="right" ><td ></td><td></td></tr>
  
        <tr>
            <td>
                <div class="submenuin">
    <ul>
          <a href="RoutePriceReport.aspx" target="_blank"><span><img alt="RoutePrice" src="Buttons/Price Chart.png"/></span></a>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
         <a href="AllRoutePrices.aspx" target="_blank"><span><img alt="RoutePrice" src="Buttons/Bid Mgnt Report(All Route).png"/></span></a>
     </ul>
  </div>
            </td>
        </tr>
        
             <tr>
            <td>
                <div class="submenuin">
    <ul>
          <a href="TransporterReport.aspx" target="_blank"><span><img alt="RoutePrice" src="Buttons/Transporters Report.png"/></span></a>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
          <a href="Fleetmaster.aspx" target="_blank"><span><img alt="RoutePrice" src="Buttons/Fleet Master.png"/></span></a>
     </ul>
  </div>
            </td>
        </tr>
           <tr>
            <td>
                <div class="submenuin">
    <ul>
          <a href="Clientsrebidreport.aspx" target="_blank"><span><img alt="RoutePrice" src="Buttons/Client ReBid Report.png"/></span></a>
     </ul>
  </div>
            </td>
            <td>
  <div class="submenuin">
    <ul>
          <a href="Distance.htm" target="_blank"><span><img alt="RoutePrice" src="Buttons/Distance Calculator.png"/></span></a>
     </ul>
  </div>
            </td>
        </tr>
        
        
        
               <tr>
            <td>
                <div class="submenuin">
    <ul>
         
           <a href="ViewDetails.aspx" target="_blank"><span><img alt="View Details<" src="Buttons/ViewDetails.png"/></span></a>
     </ul>
  </div>
            </td>
            
            <td>
  <div class="submenuin">
    <ul>
         <a href="LevelwiseReport.aspx" target="_blank"><span><img alt="Levelwise Report<" src="Buttons/LevelWise.png"/></span>
          
     </ul>
  </div>
            </td>
        </tr>

         <tr>
            <td>
                <div class="submenuin">
    <ul>
         
           <a href="AarmsAttachedVechicleReport.aspx" target="_blank"><span><img alt="View Details<" src="Buttons/Aarms Attached Vehicle Report.png"/></span></a>
     </ul>
  </div>
            </td>
            
            <td>
   <div class="submenuin">
    <ul>
         
           <a href="BillingStatusReport.aspx" target="_blank"><span><img alt="Bill Status Report<" src="Buttons/Bill Status Report.png"/></span></a>
     </ul>
  </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="submenuin">
    <ul>
         
           <a href="AgreementReport.aspx" target="_blank"><span><img alt="View Details<" src="Buttons/Agreement Report.png"/></span></a>
     </ul>
  </div>
            </td>
            </tr> 

            </table>
  	</div>
    <br /><br /><br />
</asp:Content>

