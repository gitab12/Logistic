<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WelcomeControl.ascx.cs" Inherits="UserControl_WelcomeControl" %>
   <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/>

<link href="../css/animate.css" rel="stylesheet" />
<link href="../css/bootstrap.min.css" rel="stylesheet" />
<link href="../css/font-awesome.min.css" rel="stylesheet" />
<link href="../css/jquery.sidr.dark.css" rel="stylesheet" />
<link href="../css/main.css" rel="stylesheet" />
<link href="../css/prettyPhoto.css" rel="stylesheet" />
<link href="../css/reset.css" rel="stylesheet" />
<link href="../css/responsive.css" rel="stylesheet" />
<link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/>
	<!--[if lt IE 9]> <script src="js/html5shiv.js"></script> 
	<script src="js/respond.min.js"></script> <![endif]--> 
	<link rel="shortcut icon" href="images/ico/images.png"> 
	<link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144-precomposed.png"> 
	<link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114-precomposed.png"> 
	<link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/ico/apple-touch-icon-72-precomposed.png"> 
	<link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57-precomposed.png">
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
            color:#000000;
            height: 25px;
            font-family: "Roboto",sans-serif;
            font-size: medium;
            border-bottom: medium none rgb(186, 186, 186);
        }
    </style>
    <header id="navigation" style=> 
		<div class="navbar navbar-inverse navbar-fixed-top" role="banner"> 
			<div class="container"> 
				<div class="navbar-header"> 
					<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> 
						<span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> 
					</button> 
					<a class="navbar-brand" href="index.html"><h1><img src="images/logo.jpg" alt="logo" /></h1></a> 
				</div> 
				<div class="collapse navbar-collapse"> 
					<ul class="nav navbar-nav navbar-right" style="padding: 6px 10px;"> 
						
						<%--<li><a href="knowabtscm.aspx" >About Us</a></li> 
						<li><a href="bizWorkFlow/bizUserGuideIndex.htm"  target="_blank">WORKFLOW</a></li> 
						<li><a href="readmore.aspx" >B2B</a></li> 
						<li><a href="http://www.scmbizconnect.com/Ideasandsuuggestions.aspx" target="_blank">IDEAS AND SUGGESTIONS</a></li> --%>
						 <li><a> <asp:Label ID="lblName" runat="server" Text=""></asp:Label></a></li>
                        <li><a href="Dashboard.aspx"><span class="fa-stack fa-lg pull-left" style="margin-top: -9px"><i class="fa fa-dashboard fa-stack-1x "></i></span>Dashboard</a></li> 
                         <li class="scroll"><a class="" data-toggle="dropdown" style="background-color:white;color:black;" href="#"><span class="glyphicon glyphicon-cog"></span>
        <span class="caret"></span></a>
        <ul class="dropdown-menu" style="background-color:#fff">
            <br />
          <li><a href="EditClient.aspx" style="background-color:#B70808;color:white">Edit Profile</a></li>
            <br />
          <li><a href="Registration_Digitized.aspx" style="background-color:#B70808;color:white">E-Signature Registration</a></li>
         <br />
        </ul></li> 
                         <li class="scroll"><a href="logout.aspx"><span class="glyphicon glyphicon-lock"></span>LogOut</a></li> 
                        <%-- <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>
						<!--<li class="scroll"><a href="#contact">Contact</a></li> -->
					</ul> 
				</div> 
			</div> 
            <%--<marquee style=" background-color: rgb(30, 30, 146); color:#fff;height: 25px;font-family:Roboto,sans-serif;font-size: medium; border-bottom: medium none rgb(186, 186, 186);">BIZCONNECT IS A POWERFUL IDEA, THAT ASSURES PRICE PRODUCTIVITY, COST REDUCTION, SLA ADHERANCE, THROUGH COMMITMENT, CONSOLIDATION, CROSS LOGISTICS, EXTENDED COMPETITION AND MICRO MANAGEMENT</marquee>--%>
		</div><!--/navbar-->
        <div class="container">
  <!-- Modal -->
 
</div>
	</header>