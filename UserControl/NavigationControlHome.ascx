<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationControlHome.ascx.cs" Inherits="UserControl_NavigationControlHome" %>
<!DOCTYPE html>
<html lang="en">
<head>
</head>
<body>

<div class="container">
  <h3></h3>
       <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-3">
  <ul class="nav nav-pills">
   <li class="active">
      <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#B70808">My Master <span class="caret" style="border-width:8px;"></span></a>
      <ul class="dropdown-menu">
         <li><a href="DashBoard.aspx">Dash Board</a></li>
		<li><a href="MyTripplan.aspx">My Trip Plan</a></li>
		<li><a href="ProjectMaster.aspx">Project Creation</a></li>
		<li><a href="Tripschedule.aspx">Rate Contract</a></li>
		<li><a href="TripAgreement.aspx">TripAgreement</a></li>
		<li><a href="TripAssign.aspx">Trip Assignment</a></li>
		<li><a href="PreLoading.aspx">Loading Info.</a></li>
		<li><a href="Receiving.aspx">Receiving Info.</a></li>
		<li><a href="ConfirmQuoted.aspx">Confirmed Quote</a></li>          
       </ul>
   </li>
    <li class="active">
      <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#B70808">New Trip Plan <span class="caret" style="border-width:8px;"></span></a>
      <ul class="dropdown-menu">
          <li><a href="LogisticsPlan.aspx">New Trip plan</a></li>
		  <li><a href="MultiplePosting.aspx">Bulk Upload</a></li>
		  <li><a href="SMStoTransporter.aspx">RFQ</a></li>
		                        
      </ul>
    </li>
    <li class="active">
        <a  class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#B70808">Info Management <span class="caret" style="border-width:8px;"></span></a>
        <ul class="dropdown-menu">
            <li><a href="customerCreation.aspx">New Customer </a></li>
           <li><a href="productCreation.aspx">Product Creation</a></li>
           <li><a href="listcustomer.aspx">List Customer</a></li>
           <li><a href="ListProduct.aspx">List Product </a></li>
           <li><a href="AddBranches.aspx">Add Branches </a></li>
           <li><a href="Transporter.aspx">Add Transporter</a></li>
            <li><a href="#">Add User</a></li>

        </ul>

    </li>
    <li class="active">
        <a  href="BillPayment.aspx" style="background-color:#B70808">Billing Payment</a>
       
    </li>
      <li class="active"><a href="ClientReport.aspx" style="background-color:#B70808">Report</a></li>
  </ul>
                                    </div>
           </div>
</div>

</body>
</html>