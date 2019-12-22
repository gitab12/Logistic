<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DashboardMenuBar.ascx.cs" Inherits="UserControl_DashboardMenuBar" %>
<!DOCTYPE html>
<html lang="en">
<head>
</head>
<body>

<div class="container">
  <h3></h3>
       <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-2">
  <ul class="nav nav-pills">
   <li class="active">
      <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#B70808">My Master <span class="caret" style="border-width:8px;"></span></a>
      <ul class="dropdown-menu">
         <li><a href="DashBoard.aspx">Dash Board</a></li>
		<li><a href="MyTripplan.aspx">My Trip Plan</a></li>
		<li><a href="ProjectMaster.aspx">Project Creation</a></li>
		<li><a href="Tripschedule.aspx">Rate Contract</a></li>
		<li><a href="CollectionNote.aspx">CollectionNote</a></li>
        <li><a href="~/PBudget.aspx" runat="server" id="mypb">Project Budget</a></li>
		<li><a href="Trip_Agreement.aspx">TripAgreement</a></li>
		<li><a href="TripAssign.aspx">Trip Assignment</a></li>
        <li><a href="TripRequestAssignment.aspx">Trip ReqAssignment</a></li>
		<li><a href="PreLoading.aspx">Loading Info.</a></li>
		<li><a href="UpdateLoadingInfo.aspx">Edit Loading Info.</a></li>
		<li><a href="ReceivingInfo.aspx">Receiving Info.</a></li>
		<li><a href="ConfirmQuoted.aspx">Confirmed Quote</a></li>
		<li><a href="DetailedTrack.aspx">Intransit Updation</a></li>
                    
       </ul>
   </li>
    <li class="active">
      <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#B70808">Trip Plan <span class="caret" style="border-width:8px;"></span></a>
      <ul class="dropdown-menu">
          <%--<li><a href="PostTripPlan.aspx">Post Trip plan</a></li>--%>
		  <%--<li><a href="MultiplePosting.aspx">Bulk Upload</a></li>--%>
		 
		  
		  <li><a href="CutOffTime.aspx">Cutoff Time</a></li>
          <li><a href="TripCancellation.aspx">Trip Cancellation</a></li>
          <li class="dropdown-submenu">
             <a  class="test" tabindex="-1" href="">RFQ<span class="caret"></span></a>
               <ul class="dropdown-menu" style="position: absolute;left: 160px;">
                   <li><a tabindex="-1" href="SMStoTransporter.aspx">FTL </a></li>
                 <li><a tabindex="-1" href="Parcel_Part.aspx">Parcel/Part</a></li>
               </ul>
		  </li>
           <%--<li><a href="Despatchplan.aspx">Despatch Plan</a></li>
          <li><a href="MultipleConfirmation.aspx">Multiple Confirm</a></li>--%>                       
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
            <li><a href="AddUser.aspx">Add User</a></li>
        </ul>

    </li>
    <li class="active">
        <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#B70808">Billing Module <span class="caret" style="border-width:8px;"></span></a>
        <ul class="dropdown-menu">
            <li><a href="Billmatching.aspx"><span>Bill Matching</span></a></li>
        <li><a href="BillApproval.aspx"><span>Bill Approval</span></a></li>
   <li><a href="BillPayment.aspx"><span>Bill Payment</span></a></li>
        <li><a href="BillVerification.aspx"><span>Bill Verification</span></a></li>
       <li><a href="Bill_Deletion.aspx"><span>Bill Edit/Delete</span></a></li>
        </ul>
    </li>
      <li class="active"><a href="MyPage.aspx" style="background-color:#B70808">Report</a></li>
  </ul>
                                    </div>
           </div>
</div>


 <script>


        $(document).ready(function () {
           // alert("Hi");
            $('.dropdown-submenu a.test').on("click", function (e) {
                $(this).next('ul').toggle();
                e.stopPropagation();
                e.preventDefault();
            });
        });
</script>

</body>
</html>

   




