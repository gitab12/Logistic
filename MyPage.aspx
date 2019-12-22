<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="MyPage.aspx.cs" Inherits="MyPage"  %>
<%--<%@ Register Src="~/UserControl/MenuBar.ascx" TagName="Menu" TagPrefix="Menu" %>--%>
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
    <div style="margin-left:80px">
        <link href="css/Reports_Styles.css" rel="stylesheet" />
<%--<div class="Rpt_submenu">
    <ul>
         <li>ConsolidatedReports</li>
     </ul>
  </div>--%>
  <%--<Menu:Menu ID="Menu" runat="server" />--%>
  <br />
<table width="54%" align="center">

  <tr  style="text-align:center">
      <td style="font-size:22px;color:Red" colspan ="2">
          <h2 class="title-one">Reports</h2>

      </td>

  </tr>
        <tr style="height:55px;">
            <td>
                <div class="Rpt_submenuin">
    <ul>
         <li><a href="TripAssignAcceptanceReport.aspx" target="_blank"><span>Trip Assign/Acceptance Report</span></a></li>
     </ul>
  </div>
            </td>
            <td>
  <div class="Rpt_submenuin">
    <ul>
                    <li><a href="LoadingStatus.aspx" target="_blank"><span>Loading Status Report</span></a></li>
     </ul>

  </div>               
            </td>   
         
        </tr>
   <tr style="height:55px;">
            <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="ConsignmentStatus.aspx" target="_blank"><span>TripAssign Vs TripAcceptance Vs Placed</span></a></li>
     </ul>
  </div></td>
            <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="DelayStatusReport.aspx" target="_blank"><span>Delay Status Report</span></a></li>
     </ul>
               
               </td>
        </tr>
        <tr style="height:55px;">
            <td>
  <div class="Rpt_submenuin">
    <ul>
              <li><a href="DeliveryReport.aspx" target="_blank"><span>Delivery Report</span></a></li>
     </ul>
  </div>
            </td>
            <td>
  <div class="Rpt_submenuin">
    <ul>
              <li><a href="BillStatusReport.aspx" target="_blank"><span>Bill Status Report</span></a></li>
     </ul>
  </div>
            </td>
        </tr>
       
        <tr style="height:55px;">
            <td>
  <div class="Rpt_submenuin">
    <ul>
          <li><a href="CollectionStatusReport.aspx" target="_blank"><span>Collection Note Status Report</span></a></li>
     </ul>
  </div>
            </td>
            <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="CollectionNoteVSIndent.aspx" target="_blank"><span>Collection Note VS Rate Contract</span></a></li>
     </ul>
  </div></td>
        </tr>
        <tr style="height:55px;">
            <td>
               <div class="Rpt_submenuin">
    <ul>
          <li><a href="ViewDetails.aspx" target="_blank"><span>WorkFlow Snapshot</span></a></li>
     </ul>
  </div></td>
            <td>
             <div class="Rpt_submenuin">
    <ul>
          <li><a href="DispatchPlan_Report.aspx" target="_blank"><span>Dispatch Plan</span></a></li>
     </ul>
  </div>
                </td>
        </tr>
        
        <tr style="height:55px;">
                 <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="MIS_Report.aspx" target="_blank"><span>Thermax MIS Report</span></a></li>
     </ul>
               
               </td>
            <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="ReBidLog.aspx" target="_blank"><span>ReBidLog Report</span></a></li>
     </ul>
               </td>   
            
        </tr>
        <%--<tr style="height:55px;">
            <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="AlternateTransporterReport.aspx" target="_blank"><span>Alternate Transporter Report</span></a></li>
     </ul>
               
               </td>
            <td>
                  <div class="Rpt_submenuin">
    <ul>
          <li><a href="DetailReport.aspx" target="_blank"><span>Detailed MIS Report</span></a></li>
     </ul>
               
                </td>
        </tr>--%>
     <tr style="height:55px;">
            <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="QuickView.aspx" target="_blank"><span>Quick View</span></a></li>
     </ul>
               
               </td>
            <td>
                 <div class="Rpt_submenuin">
    <ul>
          <li><a href="RcVsActual.aspx" target="_blank"><span>Rate Contract vs Actual</span></a></li>
     </ul>  
                </td>
        </tr>
    <%--<tr style="height:55px;">
            <td>
                <div class="Rpt_submenuin">
    <ul>
          <li><a href="Transporteranalytics.aspx" target="_blank"><span>Transporter Analysis</span></a></li>
     </ul>
               
               </td>
        <td>
                 <div class="Rpt_submenuin">
    <ul>
          <li><a href="QouteReceivedforClient.aspx" target="_blank"><span>Quotes Received </span></a></li>
     </ul>  
                </td>
        <%--    <td>
                 <div class="Rpt_submenuin">
    <ul>
          <li><a href="RcVsActual.aspx" target="_blank"><span>Rate Contract vs Actual</span></a></li>
     </ul>  
                </td>--%>
        <%--</tr>--%>
		 <tr style="height:55px;">
         <td>
                 <div class="Rpt_submenuin">
    <ul>
          <li><a href="ParcelTrackReport.aspx" target="_blank"><span>Parcel Track Report</span></a></li>
     </ul> 
                     </td> 
					 <td>
                 <div class="Rpt_submenuin">
    <ul>
          <li><a href="Detailed_Report.aspx" target="_blank"><span>Detailed Report</span></a></li>
     </ul> 
                     </td> 
        </tr>
		 <tr style="height:55px;">
        <td>
            <div class="Rpt_submenuin">
                <ul>
                      <li><a href="Location_VehicleType_Report.aspx" target="_blank"><span>Location Vehicle Report</span></a></li>
                 </ul> 
       </div> </td>
             <td>
                 <div class="Rpt_submenuin">
    <ul>
          <li><a href="Transport_Analysis_Report.aspx" target="_blank"><span>Transporter Report</span></a></li>
     </ul> 
                     </td> 
    </tr>
        </table>
    <br /><br /><br /><br /><br /><br /><br /><br />
        </div>
</asp:Content>

