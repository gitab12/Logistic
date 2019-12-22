<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AarmsNavigationControl.ascx.cs" Inherits="UserControl_AarmsNavigationControl" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <style>
.dropbtn {
    background-color: #4CAF50;
    color: white;
    padding: 16px;
    font-size: 16px;
    border: none;
    cursor: pointer;
}

.dropdown {
    position: relative;
    display: inline-block;
}

.dropdown-content {
      margin:1px -350px;
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 500px;
    box-shadow: 5px 5px 16px 5px rgba(0,0,0,0.2);
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: table-cell;
}

.dropdown-content a:hover {background-color:#808080}

.dropdown:hover .dropdown-content {
    display: block;
}

.dropdown:hover .dropbtn {
    background-color: #3e8e41;
}
</style>
 <style type="text/css">
        .Tripplan
        {
            height: 20px;
            padding-top: 8px;
            padding-left: 10px;
            padding-right: 20px;
            top: 30px;
        }
      
    </style>
</head>
<body>

<div class="container">
  <h3></h3>
       <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-3">
  <ul class="nav nav-pills">
   <li class="active">
      <a href="Aarmstripplan.aspx" style="background-color:#B70808"> Client Trip Plan </a>
   </li>
    <li class="active">
      <a href="Consolidateplan.aspx" style="background-color:#B70808">Consolidate Plan </a>
    </li>
    <%--<li class="active">
        <a  href="AarmsAds.aspx" style="background-color:#B70808">Aarms Ads</a>
    </li>--%>
       <li class="dropdown">
     <a  href="AarmsAds.aspx" style="background-color:#B70808;color:white">Aarms Ads</a>
    <div class="dropdown-content">
      <a href="AarmsAds.aspx" style="color:black">Posted Ads</a>
      <a href="Quotereceived.aspx" style="color:black">Quote Received</a>
      <a href="PreAssignment.aspx" style="color:black">PreAssignment</a>
      <a href="TripAgreement.aspx" style="color:black">TripAgreement</a>
      <a href="Tracking.aspx" style="color:black">TrackingLog</a>
      <a href="Invoice.aspx" style="color:black">Billing</a>
      <a href="route_price.aspx" style="color:black">Route Price</a>
        
    </div>
  </li>
    <li class="active">
        <a  href="ConsolidateDashboard.aspx" style="background-color:#B70808">Dashboard</a>
    </li>
      <li class="active"><a href="Reports.aspx" style="background-color:#B70808">Report</a></li>
  </ul>
                                    </div>
           </div>
</div>

</body>
</html>