<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="readmore.aspx.cs" Inherits="readmore" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br /><br /><br />
 
<meta charset="utf-8"/> 
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
	<meta name="description" content="Creative One Page Parallax Template"/>
	<meta name="keywords" content="Creative, Onepage, Parallax, HTML5, Bootstrap, Popular, custom, personal, portfolio" /> 
	<meta name="author" content=""/> 
	<link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
	<link href="css/font-awesome.min.css" rel="stylesheet"//> 
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/>
    <link href="css/accordion.css" rel="stylesheet" />
     <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
	<!--[if lt IE 9]> <script src="js/html5shiv.js"></script> 
	<script src="js/respond.min.js"></script> <![endif]--> 
	<link rel="shortcut icon" href="images/ico/images.png"/> 
	<link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144-precomposed.png"/> 
	<link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114-precomposed.png"/> 
	<link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/ico/apple-touch-icon-72-precomposed.png"/> 
	<link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57-precomposed.png"/>
    <style>
    .modalTextLog {
    color: #000000;
    float: right;
    font-size: 18px;
    font-weight: 400;
    padding-top: 15px;
    text-transform: none;
     font-family: 'Roboto',sans-serif;   
        }
        </style>

    <!--marquee -->
    <style>
        .marquee 
        {
            background-color: rgb(30, 30, 146);
            color: rgb(255, 255, 255);
            height: 25px;
            font-family: "Roboto",sans-serif;
            font-size: medium;
            border-bottom: medium none rgb(186, 186, 186);
        }
    </style>


    <!-- Latest compiled and minified Bootstrap CSS -->

<div class="container" style="margin-left:120px">
 <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-2">
									<h2 class="title-one">Bizconnect B2B</h2>
									<!--<p class="blog-heading">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>-->
								</div>
							</div> 

  <div class="panel-group" id="accordion">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
        <a class="accordion-toggle" style="color: rgb(183, 8, 8);"  data-toggle="collapse" data-parent="#accordion" href="#collapseOne" >
         <strong> What is SCM BizConnect</strong>
        </a>
      </h4>
      </div>
      <div id="collapseOne" class="panel-collapse collapse in">
      <div class="panel-body">
       SCM BIZCONNECT is the first Service Oriented online B2B initiative, in India. This initiative is being showcased by AARM SCM SOLUTIONS private Limited, which Redefines the Supply Chain  management in India. This Web based software, aims at a complete Logistics Management, which minimises Transport Cost, and Maximises Profit. The portal also interconnects the Warehouse Availability Vs required. The emphasis is to manage SCM by TRUST, TRANSPARENT COST MANAGEMENT, and defined process through latest SOFTWARE AND MOBILE TECHNOLOGY.SCM BIZCONNECT also connects the other subsequent Supply Chain Activities, like DOCUMENT MANAGEMENT, AR FOCUSED(ACCOUNTS RECEIVABLES), GST WORKFLOW(GOODS & SERVICES TAX), CST MANAGEMENT, and CUSTOMER SUPPORT. 
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a class="accordion-toggle" style="color: rgb(183, 8, 8);" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
           <strong>About SCM BizConnect </strong>
        </a>
      </h4>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse">
      <div class="panel-body">
       <p> SCMBIZCONNECT is a Service oriented SUPPLY CHAIN SOLUTIONS portal, which aims at PROFESSIONAL MANAGEMENT OF INBOUND & OUTBOUND LOGISTICS, DOCUMENT MANAGEMENT, AR FOCUSED, WAREHOUSE MANAGEMENT, C-FORM MANAGEMENTS, GST WORKFLOW, CUSTOMER SUPPORT.</p>

<p>SCM BIZCONNECT aims at Transaction Based Pricing, which is a paradigm shift of the existing management of Logistics, based on a few transport providers and annual frozen cost. The Redefined Process, brings the best of the Competitive Pricing, SLA ADHERANCE, and enhances the productivity of CENTRALISED MANAGEMENT, through Outsourced Model.</p>

<p>SCMBIZCONNECT brings in VALUE CHAIN productivity, by CONSOLIDATION and TRANSACTION BASED PRICE bidding, Transparent Pricing, Negotiation, use of SOFTWARE TECHNOLOGY, ENHANCED REALTIME COMMUNICATION MANAGEMENT, SERVICE LEVEL ADHERANCE, COST PLANNING AND CONTROL.</p>

<p>SCM BIZCONNECT is extended to all Clients who will be Registered as Clients in the Website.</p> 
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a class="accordion-toggle" style="color: rgb(183, 8, 8);" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
          <strong>Process : </strong>
        </a>
      </h4>
    </div>
    <div id="collapseThree" class="panel-collapse collapse">
      <div class="panel-body">
       <ul><li> Every Registered Client will login into Website using Login & pw.</li></ul>
	 <ul><li>The clients will give Trip Plan on weekly basis.</li></ul>
	 <ul><li>The relevant masters like, Product Master, Customer master and Facility masters along with the Budgeted Routewise Trip cost will be uploaded into the Server.</li></ul>
	 <ul><li>The Trip Plan will be uploaded into the Software.</li></ul>
	 <ul><li>The consolidated Trip plan for all clients will be consolidated, and Advertisement will be published into the SCM JUNCTION.</li></ul>
	 <ul><li>Instant SMS alert, Auto Mail, will be sent to the Registered Transport contractors across the country, will be triggered, inviting Bids for the Advertisements.</li></ul>
	 <ul><li>The AARMS FACILITATION executives, will analyse the Bids and prepare the PRE-ASSIGNMENT STATEMENT, and alert the client.</li></ul>
	 <ul><li>The client can approve assignment, with a revised Bid.</li></ul>
	 <ul><li>The Assignment will be automatically mailed to the Responded Transporter.</li></ul>
	 <ul><li>On acceptance of the Assignment, the Deal done Statement and the Release Purchase order will be Auto-generated and communicated to both the clients and the Transporters.</li></ul>
	 <ul><li>The Transporter will pick up the goods and deliver to the customer / destination, specified in the Order.</li></ul>
	 <ul><li>AARMS FACILITATION TEAM, will track the delivery and Grade the performance and communicate to the Client .</li></ul>
	 <ul><li>The relevant Documents, including the Acknowledged Lorry Receipt will be Scanned, and published into the DOCUMENT DIGITISED SITE.</li></ul>
	 <ul><li>INTEGRATED APPROACH, will generate a Auto Generated Transaction ID, which will be triggered to the AR FOCUSED AND THE GST WORKFLOW, for further follow-up of AR on the due date, and C-forms / H/I forms as applicable.</li></ul>
      </div>
    </div>
  </div>
      <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a class="accordion-toggle" style="color: rgb(183, 8, 8);"  data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
          <strong> Benifits to the clients : </strong>
        </a>
      </h4>
    </div>
    <div id="collapseFour" class="panel-collapse collapse">
      <div class="panel-body">
        <ul><li>Client is assured of the Best Pricing, due to extended competition.</li></ul>
	 <ul><li>Managing of Logistics is managed centralised , and the SLA adherence can be dictated, according to Needs and situation.</li></ul>
	 <ul><li>Pricing is Transparent.</li></ul>
	 <ul><li>Alerts, Mails and Communication System is through Software and Mobile technology.</li></ul>
	 <ul><li>Cost and Savings is captured Online, and is displayed through a DASH BOARD.</li></ul>
	 <ul><li>The Process, triggers Integrated solutions for the AR, C-forms, Indirect Taxes, and Customer delight through Customer Support.</li></ul>
	 <ul><li>SCMBIZCONNECT manages through SIX SIGMA APPROACH.</li></ul>
	 <ul><li>Managing Cost to AARMSCM SOLUTIONS, is based on Profit Sharing approach, hence Price Productivity is guaranteed.</li></ul>
	 <ul><li>Planning, Management, Tracking of goods, Documents, AR, Indirect Tax management, is simplified and Professionally managed.</li></ul>
	 <ul><li>Clients can also Advertise and promote the products, wherein other clients, customers can integrate with the customers.</li></ul>
	 <ul><li>SCM BIZCONNECT is fully secured, and can be displayed only by Registered members.</li></ul>
      </div>
    </div>
  </div>
</div>
  
  
</div> <!-- end container -->

<!-- Latest compiled and minified JavaScript -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>

</asp:Content>


