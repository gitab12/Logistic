<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head> 
	<meta charset="utf-8"/> 
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
	<meta name="description" content="Creative One Page Parallax Template"/>
	<meta name="keywords" content="Creative, Onepage, Parallax, HTML5, Bootstrap, Popular, custom, personal, portfolio" /> 
	<meta name="author" content=""/> 
	<title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <%-- <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
  <link href="https://fortawesome.github.io/Font-Awesome/assets/font-awesome/css/font-awesome.css" rel="stylesheet"/> --%>
	<link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
	<link href="css/font-awesome.min.css" rel="stylesheet"/> 
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/> 
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
</head><!--/head-->
<body>
	
	<header id="navigation"> 
		<div class="navbar navbar-inverse navbar-fixed-top" role="banner"> 
			<div class="container"> 
				<div class="navbar-header"> 
					<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> 
						<span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> 
					</button> 
					<a class="navbar-brand" href="index.html"><img src="images/logo.jpg" alt="logo" /></a> 
				</div> 
				<div class="collapse navbar-collapse"> 
					<ul class="nav navbar-nav navbar-right"> 
						<li><a href="#navigation">Home</a></li> 
						<li><a href="http://www.scmbizconnect.com/knowabtscm.aspx"  target="_blank">About Us</a></li> 
						<li><a href="http://www.scmbizconnect.com/bizWorkFlow/bizUserGuideIndex.htm"  target="_blank">WORKFLOW</a></li> 
						<li><a href="http://www.scmbizconnect.com/readmore.aspx" target="_blank">B2B</a></li> 
						<li><a href="http://www.scmbizconnect.com/Ideasandsuuggestions.aspx" target="_blank">IDEAS AND SUGGESTIONS</a></li> 
                        <li class="scroll"><a style="text-decoration :none  "> <asp:Label ID="lblName" runat="server" Text=""></asp:Label></a></li>
                         <li class="scroll"><a href="logout.aspx"><span class="glyphicon glyphicon-lock"></span>LogOut</a></li> 
						<!--<li class="scroll"><a href="#contact">Contact</a></li> -->
					</ul> 
				</div> 
			</div> 
		</div><!--/navbar-->
       
	</header> <!--/#navigation--> 
    
	<section id="home">
		<div class="home-pattern"></div>
		<div id="main-carousel" class="carousel slide" data-ride="carousel"> 
			<ol class="carousel-indicators">
				<li data-target="#main-carousel" data-slide-to="0" class="active"></li>
				<li data-target="#main-carousel" data-slide-to="1"></li>
				<li data-target="#main-carousel" data-slide-to="2"></li>
			</ol>
			<div class="carousel-inner">
				<div class="item active" style="background-image: url(images/slider/slide3.jpg);height:350px"> 
					<div class="carousel-caption"> 
						<div> 
							<!--<h2 class="heading animated bounceInDown">'Himu' Onepage HTML Template</h2> 
							<p class="animated bounceInUp">Fully Professional one page template</p> -->
							<!--<a class="btn btn-default slider-btn animated fadeIn" href="#">Get Started</a> -->
						</div> 
					</div> 
				</div>
				<div class="item" style="background-image: url(images/slider/slide2.jpg);height:350px"> 
					<div class="carousel-caption"> <div> 
						<h2 class="heading animated bounceInDown">Get Truck, transportation</h2> 
						<h1 class="animated bounceInUp">Everything is outstanding </h1>
                       <!--  <a class="btn btn-default slider-btn animated fadeIn" href="#">Get Started</a> -->
					</div> 
				</div> 
			</div> 
			<div class="item" style="background-image: url(images/slider/slide1.jpg);height:350px"> 
				<div class="carousel-caption"> 
					<div> 
						<h2 class="heading animated bounceInRight">logistics</h2> 
						<h1 class="animated bounceInLeft">100% Delivery of goods logistics and transportation.</h1> 
						<!--<a class="btn btn-default slider-btn animated bounceInUp" href="#">Get Started</a> -->
					</div> 
				</div> 
			</div>
		</div>

		<a class="carousel-left member-carousel-control hidden-xs" href="#main-carousel" data-slide="prev"><i class="fa fa-angle-left"></i></a>
		<a class="carousel-right member-carousel-control hidden-xs" href="#main-carousel" data-slide="next"><i class="fa fa-angle-right"></i></a>
	</div> 

</section><!--/#home-->

<section id="about-us">
	<div class="container">
		<div class="text-center">
			<div class="col-sm-8 col-sm-offset-2">
				<h2 class="title-one">What is SCM BizConnect ?</h2>
				<p style="text-align: justify;">SCM BIZCONNECT is the first service oriented online,B2B initiative in India.This initiative is being showcased by AARM SCM SOLUTIONS Pvt.Ltd which redefines the supply chain management in India.This web based software aims at logistics management, warehouse management which minimises Transportation cost and maximises Profit.The portal also interconnects the AR indirect tax management and other functions.</p>
                <a class="navbar-brand" href="index.html"><img src="images/power_ideas.gif" alt="Progressus HTML5 template"></a></h3>
				<p style="text-align: justify;">When Jagannathan started his business nearly six years ago, his startup handled supply chain management dealing with receivables and C-forms. After his participation in The Power of Ideas, it is now and end-to-end supply chain management solutions company handling all inbound and outbound dispatches of a B2B nature.</p>
			</div>
		</div>
		<!--<div class="about-us">
			<div class="row">
				<div class="col-sm-6">
					<h3>Why with us?</h3>
					<ul class="nav nav-tabs">
						<li class="active"><a href="#about" data-toggle="tab"><i class="fa fa-chain-broken"></i> About</a></li>
						<li><a href="#mission" data-toggle="tab"><i class="fa fa-th-large"></i> Mission</a></li>
						<li><a href="#community" data-toggle="tab"><i class="fa fa-users"></i> Community</a></li>
					</ul>
					<div class="tab-content">
						<div class="tab-pane fade in active" id="about">
							<div class="media">
								<img class="pull-left media-object" src="images/about-us/about.jpg" alt="about us"> 
								<div class="media-body">
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
								</div>
							</div>
						</div>
						<div class="tab-pane fade" id="mission">
							<div class="media">
								<img class="pull-left media-object" src="images/about-us/mission.jpg" alt="Mission"> 
								<div class="media-body">
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci </p>
								</div>
							</div>
						</div>
						<div class="tab-pane fade" id="community">
							<div class="media">
								<img class="pull-left media-object" src="images/about-us/community.jpg" alt="Community"> 
								<div class="media-body">
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. </p>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-sm-6">
					<h3>Our Skills</h3>
					<div class="skill-bar">
						<div class="skillbar clearfix " data-percent="90%">
							<div class="skillbar-title">
								<span>HTML5 &amp; CSS3</span>
							</div>
							<div class="skillbar-bar"></div>
							<div class="skill-bar-percent">90%</div>
						</div> 
						<div class="skillbar clearfix" data-percent="85%">
							<div class="skillbar-title"><span>UI Design</span></div>
							<div class="skillbar-bar"></div>
							<div class="skill-bar-percent">85%</div>
						</div> 
						<div class="skillbar clearfix " data-percent="70%">
							<div class="skillbar-title"><span>jQuery</span></div>
							<div class="skillbar-bar"></div>
							<div class="skill-bar-percent">70%</div>
						</div> 
						<div class="skillbar clearfix " data-percent="60%">
							<div class="skillbar-title"><span>PHP</span></div>
							<div class="skillbar-bar"></div>
							<div class="skill-bar-percent">60%</div>
						</div> 
						<div class="skillbar clearfix " data-percent="75%">
							<div class="skillbar-title"><span>Wordpress</span></div>
							<div class="skillbar-bar"></div>
							<div class="skill-bar-percent">75%</div>
						</div></div>
					</div>
				</div>
			</div>-->
		</div>
    
	</section><!--/#about-us-->

	<section id="services" class="parallax-section">
		<div class="container">
			<div class="row text-center">
				<div class="col-sm-8 col-sm-offset-2">
					<h2 class="title-one">SCM MANAGED</h2>
					<!--<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>-->
				</div>
			</div>
			<div class="row">
				<div class="col-sm-12">
					<div class="our-service">
						<div class="services row">
							<div class="col-sm-4">
								<div class="single-service">
									<i class="fa fa-th"></i>
									<h2>Operational</h2>
									<p>Information Sharing to Extend,Demand to  Wider,Supply Based,Minimize Cost,Eliminate Idle Time,Assure Profits,Track Delivery.</p>
								</div>
							</div>
							<div class="col-sm-4">
								<div class="single-service">
									<i class="fa fa-location-arrow"></i>
									<h2>Transactional</h2>
									<p> Delivery Forecast,Assign lowest bids,Release delivery order,Track vechicle & delivery,Digitise documents,Focus accounts receivable,Manage transport. </p>
								</div>
							</div>
							<div class="col-sm-4">
								<div class="single-service">
									<i class="fa fa-users"></i>
									<h2> Organization</h2>
									<p>Institute & refine organization methods among internal and external value chain members, -Linked performance metrics,-co-ordinated Business Plans,-Joint Problem Resolutions.</p>
								</div>
							</div></div>
						</div>
					</div>
				</div>
			</div>
		</section><!--/#service-->

		<section id="our-team">
			<div class="container">
				<div class="row text-center">
					<div class="col-sm-8 col-sm-offset-2">
						<h2 class="title-one">Our Clients</h2>
						<!--<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit.</p>-->
					</div>
				</div>
				<div id="team-carousel" class="carousel slide" data-interval="false">
					<a class="member-left" href="#team-carousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a>
					<a class="member-right" href="#team-carousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
					<div class="carousel-inner team-members">
						<div class="row item active">
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member1.jpg" alt="team member" />
							<!--		<h4>William Hurt</h4>
									<h5>Sr. Web Developer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>-->
									<!--<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member2.jpg" alt="team member" />
									<!--<h4>Alekjandra Jony</h4>
									<h5>Creative Designer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>
									<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member3.png" alt="team member" />
									<!--<h4>Paul Johnson</h4>
									<h5>Skilled Programmer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>
									<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member4.png" alt="team member" />
									<!--<h4>John Richerds</h4>
									<h5>Marketing Officer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>
									<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
						</div>
						<div class="row item">
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member5.png" alt="team member" />
								<!--	<h4>William Hurt</h4>
									<h5>Sr. Web Developer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>
									<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member6.jpg" alt="team member" />
									<!--<h4>Paul Johnson</h4>
									<h5>Skilled Programmer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>
									<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member1.jpg" alt="team member" />
									<!--<h4>Alekjandra Jony</h4>
									<h5>Creative Designer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>
									<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="single-member">
									<img src="images/our-team/member2.jpg" alt="team member" />
								<!--	<h4>John Richerds</h4>
									<h5>Marketing Officer</h5>
									<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod</p>
									<div class="socials">
										<a href="#"><i class="fa fa-facebook"></i></a>
										<a href="#"><i class="fa fa-twitter"></i></a>
										<a href="#"><i class="fa fa-google-plus"></i></a>
										<a href="#"><i class="fa fa-dribbble"></i></a>
										<a href="#"><i class="fa fa-linkedin"></i></a>
									</div>-->
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</section><!--/#Our-Team-->

		<!--<section id="portfolio">
			<div class="container">
				<div class="row text-center">
					<div class="col-sm-8 col-sm-offset-2">
						<h2 class="title-one">Portfolio</h2>
						<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit.</p>
					</div>
				</div>
				<ul class="portfolio-filter text-center">
					<li><a class="btn btn-default active" href="#" data-filter="*">All</a></li>
					<li><a class="btn btn-default" href="#" data-filter=".html">Html</a></li>
					<li><a class="btn btn-default" href="#" data-filter=".wordpress">Wordpress</a></li>
					<li><a class="btn btn-default" href="#" data-filter=".joomla">Joomla</a></li>
					<li><a class="btn btn-default" href="#" data-filter=".megento">Megento</a></li>
				</ul>
				<div class="portfolio-items">
					<div class="col-sm-3 col-xs-12 portfolio-item html">
						<div class="view efffect">
							<div class="portfolio-image">
								<img src="images/portfolio/1.jpg" alt=""></div> 
								<div class="mask text-center">
									<h3>Novel</h3>
									<h4>Lorem ipsum dolor sit amet consectetur</h4>
									<a href="#"><i class="fa fa-link"></i></a>
									<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
								</div>
							</div>
						</div>
						<div class="col-sm-3 col-xs-12 portfolio-item jooma">
							<div class="view efffect" >
								<div class="portfolio-image">
									<img src="images/portfolio/2.jpg" alt="">
								</div> 
								<div class="mask text-center">
									<h3>Novel</h3>
									<h4>Lorem ipsum dolor sit amet consectetur</h4>
									<a href="#"><i class="fa fa-link"></i></a>
									<a href="images/portfolio/big-item4.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
								</div>
							</div>
						</div>
						<div class="col-sm-3 col-xs-12 portfolio-item wordpress">
							<div class="view efffect">
								<div class="portfolio-image">
									<img src="images/portfolio/3.jpg" alt="">
								</div> 
								<div class="mask text-center">
								<h3>Novel</h3>
								<h4>Lorem ipsum dolor sit amet consectetur</h4>
								<a href="#"><i class="fa fa-link"></i></a>
								<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
							</div>
						</div>
					</div>
					<div class="col-sm-3 col-xs-12 portfolio-item megento">
						<div class="view efffect">
							<div class="portfolio-image">
								<img src="images/portfolio/4.jpg" alt="">
							</div> 
							<div class="mask text-center">
								<h3>Novel</h3>
								<h4>Lorem ipsum dolor sit amet consectetur</h4>
								<a href="#"><i class="fa fa-link"></i></a>
								<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
							</div>
						</div>
					</div>
					<div class="col-sm-3 col-xs-12 portfolio-item html">
						<div class="view efffect">
							<div class="portfolio-image">
								<img src="images/portfolio/5.jpg" alt="">
							</div> <div class="mask text-center">
							<h3>Novel</h3>
							<h4>Lorem ipsum dolor sit amet consectetur</h4>
							<a href="#"><i class="fa fa-link"></i></a>
							<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
						</div>
					</div>
				</div>
				<div class="col-sm-3 col-xs-12 portfolio-item wordpress">
					<div class="view efffect">
						<div class="portfolio-image">
							<img src="images/portfolio/6.jpg" alt="">
						</div> 
						<div class="mask text-center">
							<h3>Novel</h3>
							<h4>Lorem ipsum dolor sit amet consectetur</h4>
							<a href="#"><i class="fa fa-link"></i></a>
							<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
						</div>
					</div>
				</div>
				<div class="col-sm-3 col-xs-12 portfolio-item html">
					<div class="view efffect">
						<div class="portfolio-image">
							<img src="images/portfolio/7.jpg" alt="">
						</div> 
						<div class="mask text-center">
							<h3>Novel</h3>
							<h4>Lorem ipsum dolor sit amet consectetur</h4>
							<a href="#"><i class="fa fa-link"></i></a>
							<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
						</div>
					</div>
				</div>
				<div class="col-sm-3 col-xs-12 portfolio-item joomla">
					<div class="view efffect">
						<div class="portfolio-image">
							<img src="images/portfolio/8.jpg" alt=""></div> 
							<div class="mask text-center">
								<h3>Novel</h3>
								<h4>Lorem ipsum dolor sit amet consectetur</h4>
								<a href="#"><i class="fa fa-link"></i></a>
								<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
							</div>
						</div>
					</div>
					<div class="col-sm-3 col-xs-12 portfolio-item html">
						<div class="view efffect">
							<div class="portfolio-image">
								<img src="images/portfolio/9.jpg" alt="">
							</div> 
							<div class="mask text-center">
								<h3>Novel</h3>
								<h4>Lorem ipsum dolor sit amet consectetur</h4>
								<a href="#"><i class="fa fa-link"></i></a>
								<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
							</div>
						</div>
					</div>
					<div class="col-sm-3 col-xs-12 portfolio-item wordpress">
						<div class="view efffect">
							<div class="portfolio-image">
								<img src="images/portfolio/10.jpg" alt=""></div> 
								<div class="mask text-center">
									<h3>Novel</h3>
									<h4>Lorem ipsum dolor sit amet consectetur</h4>
									<a href="#"><i class="fa fa-link"></i></a>
									<a href="images/portfolio/big-item.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
								</div>
							</div>
						</div>
						<div class="col-sm-3 col-xs-12 portfolio-item joomla">
							<div class="view efffect">
								<div class="portfolio-image">
									<img src="images/portfolio/11.jpg" alt=""></div> 
									<div class="mask text-center">
										<h3>Novel</h3>
										<h4>Lorem ipsum dolor sit amet consectetur</h4>
										<a href="#"><i class="fa fa-link"></i></a>
										<a href="images/portfolio/big-item3.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
									</div>
								</div>
							</div>
							<div class="col-sm-3 col-xs-12 portfolio-item megento">
								<div class="view efffect">
									<div class="portfolio-image">
										<img src="images/portfolio/12.jpg" alt=""></div> 
										<div class="mask text-center">
											<h3>Novel</h3>
											<h4>Lorem ipsum dolor sit amet consectetur</h4>
											<a href="#"><i class="fa fa-link"></i></a>
											<a href="images/portfolio/big-item4.jpg" data-gallery="prettyPhoto"><i class="fa fa-search-plus"></i></a>
										</div>
									</div>
								</div>
							</div>
						</div> 

					</section>--> 

					<!--<section id="clients" class="parallax-section">
						<div class="container">
							<div class="clients-wrapper">
								<div class="row text-center">
									<div class="col-sm-8 col-sm-offset-2">
										<h2 class="title-one">Clients Say About Us</h2>
										<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit</p>
									</div>
								</div>
								<div id="clients-carousel" class="carousel slide" data-ride="carousel"> 
									<ol class="carousel-indicators">
										<li data-target="#clients-carousel" data-slide-to="0" class="active"></li>
										<li data-target="#clients-carousel" data-slide-to="1"></li>
										<li data-target="#clients-carousel" data-slide-to="2"></li>
									</ol> 
									<div class="carousel-inner">
										<div class="item active">
											<div class="single-client">
												<div class="media">
													<img class="pull-left" src="images/clients/client1.jpg" alt="">
													<div class="media-body">
														<blockquote><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p><small>Someone famous in Source Title</small><a href="">www.yourwebsite.com</a></blockquote>
													</div>
												</div>
											</div>
										</div>
										<div class="item">
											<div class="single-client">
												<div class="media">
													<img class="pull-left" src="images/clients/client3.jpg" alt="">
													<div class="media-body">
														<blockquote><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p><small>Someone famous in Source Title</small><a href="">www.yourwebsite.com</a></blockquote>
													</div>
												</div>
											</div>
										</div>
										<div class="item">
											<div class="single-client">
												<div class="media">
													<img class="pull-left" src="images/clients/client2.jpg" alt="">
													<div class="media-body">
														<blockquote><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p><small>Someone famous in Source Title</small><a href="">www.yourwebsite.com</a></blockquote>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</section>-->

					<section id="blog"> 
						<div class="container">
							<div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-2">
									<h2 class="title-one">Our Services</h2>
									<!--<p class="blog-heading">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>-->
								</div>
							</div> 
							<div class="row">
								<div class="col-sm-4">
									<div class="single-blog">
										<img style=" height:80px;" src="images/blog/1.png" alt="" />
										<h2>Aaum Comnnect</h2>
										<!--<ul class="post-meta">
											<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
											<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
										</ul>-->
										<div class="blog-content">
											<p>Aaumconnect is a vehicle tracking device which ensures real-time tracking of vehicles.Aaumconnect aims at providing a cost effective solution.</p>
										</div>
									<!--	<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-detail">Read More</a>-->
									</div>
									<div class="modal fade" id="blog-detail" tabindex="-1" role="dialog" aria-hidden="true">
										<div class="modal-dialog">
											<div class="modal-content">
												<div class="modal-body">
													<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
													<img src="images/blog/3.jpg" alt="" />
													<h2>Lorem ipsum dolor sit amet</h2>
													<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
												</div> 
											</div>
										</div>
									</div>
								</div>
								<div class="col-sm-4">
									<div class="single-blog">
										<img style=" height:80px;" src="images/blog/3.jpg" alt="" />
										<h2>C-Form Mangement</h2>
										<!--<ul class="post-meta">
											<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
											<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
										</ul>-->
										<div class="blog-content">
											<p>C-Form collection and upload into software is managed effectively by focussed follow-up and better co-ordination with customers.</p>
										</div>
										<!--<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-two">Read More</a>-->
									</div>
									<div class="modal fade" id="blog-two" tabindex="-1" role="dialog" aria-hidden="true">
										<div class="modal-dialog">
											<div class="modal-content">
												<div class="modal-body">
													<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
													<img style="width:245px; height:80px;" src="images/blog/2.jpg" alt="" />
													<h2>Lorem ipsum dolor sit amet</h2>
													<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
												</div>
											</div>
										</div>
									</div>
								</div>
								<div class="col-sm-4">
									<div class="single-blog">
										<img style="height:80px;" src="images/blog/2.png" alt="" />
										<h2>AR Focused</h2>
									<!--	<ul class="post-meta">
											<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
											<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
										</ul>-->
										<div class="blog-content">
											<p>Focussed follow up management, aimed at improving cash-flows, enhancing sales team productivity and prevent bad debt shocks by escalations, and co-ordinations.</p>
										</div>
										<!--<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-three">Read More</a>-->
									</div>
									<div class="modal fade" id="blog-three" tabindex="-1" role="dialog" aria-hidden="true">
										<div class="modal-dialog">
											<div class="modal-content">
												<div class="modal-body">
													<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
													<img style="width:245px; height:80px;" src="images/blog/2.jpg" alt="" />
													<h2>Lorem ipsum dolor sit amet</h2>
													<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
												</div> 
											</div>
										</div>
									</div>
								</div>
								<div class="col-sm-4">
									<div class="single-blog">
										<img src="images/blog/4.jpg" alt="" />
										<h2>Document Digisitzed</h2>
										<!--<ul class="post-meta">
											<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
											<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
										</ul>-->
										<div class="blog-content">
											<p>Document Management improves the storage and retrieval of all related documents on a real time.This supports logistics, AR, AP, C-Form, GST and all workflows on the supplychain.</p>
										</div>
										<!--<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-four">Read More</a>-->
                                            </div>
										<div class="modal fade" id="blog-four" tabindex="-1" role="dialog" aria-hidden="true">
											<div class="modal-dialog">
												<div class="modal-content">
													<div class="modal-body">
														<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
														<img src="images/blog/3.jpg" alt="" />
														<h2>Lorem ipsum dolor sit amet</h2>
														<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
													</div> 
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="single-blog">
											<img src="images/blog/5.jpg" alt="" />
											<h2>GST Workflow</h2>
											<!--<ul class="post-meta">
												<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
												<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
											</ul>-->
											<div class="blog-content">
												<p>Focus on effective management of credits in CGST, LGST, IGST from the plan stage.Compliance of filing returns, Appeals etc. Interactive chat room, facilitates exchange of concepts & concerns.</p>
											</div>
											<!--<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-six">Read More</a>-->
										</div>
										<div class="modal fade" id="blog-six" tabindex="-1" role="dialog" aria-hidden="true">
											<div class="modal-dialog">
												<div class="modal-content">
													<div class="modal-body">
														<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
														<img src="images/blog/3.jpg" alt="" />
														<h2>Lorem ipsum dolor sit amet</h2>
														<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
													</div> 
												</div>
											</div>
										</div>
									</div>

									<div class="col-sm-4">
										<div class="single-blog">
											<img src="images/blog/4.jpg" alt="" />
											<h2>Customer Services</h2>
											<div class="blog-content">
												<p> Customer Services LogiticsFacilitates Customer Relationship managemnet by one point help desk for all complaints on product, service, commercial and other B3B customers.</p>
											</div>
											<!--<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-seven">Read More</a>-->
										</div>
										<div class="modal fade" id="blog-seven" tabindex="-1" role="dialog" aria-hidden="true">
											<div class="modal-dialog">
												<div class="modal-content">
													<div class="modal-body">
														<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
														<img src="images/blog/1.jpg" alt="" />
														<h2>Lorem ipsum dolor sit amet</h2>
														<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
													</div> 
												</div>
											</div>
										</div>
									</div> 
								</div> 
							</div> 
						</section> <!--/#blog-->

						<!--<section id="contact">
							<div class="container">
								<div class="row text-center clearfix">
									<div class="col-sm-8 col-sm-offset-2">
										<div class="contact-heading">
											<h2 class="title-one">Contact With Us</h2>
											<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit</p>
										</div>
									</div>
								</div>
							</div>
							<div class="container">
								<div class="contact-details">
									<div class="pattern"></div>
									<div class="row text-center clearfix">
										<div class="col-sm-6">
											<div class="contact-address"><address><p><span>Devs</span>Cluster</p><strong>36 North Kafrul<br>Dhaka Cantonment Area<br> Dhaka-1206, Bangladesh</strong><br><small>( Lorem ipsum dolor sit amet, consectetuer adipiscing elit )</small></address>
												<div class="social-icons">
													<a href="#"><i class="fa fa-facebook"></i></a><a href="#"><i class="fa fa-twitter"></i></a>
													<a href="#"><i class="fa fa-google-plus"></i></a><a href="#"><i class="fa fa-dribbble"></i></a>
													<a href="#"><i class="fa fa-linkedin"></i></a>
												</div>
											</div>
										</div>
										<div class="col-sm-6"> 
											<div id="contact-form-section">
												<div class="status alert alert-success" style="display: none"></div>
												<form id="contact-form" class="contact" name="contact-form" method="post" action="send-mail.php">
													<div class="form-group">
														<input type="text" name="name" class="form-control name-field" required="required" placeholder="Your Name"></div>
														<div class="form-group">
															<input type="email" name="email" class="form-control mail-field" required="required" placeholder="Your Email">
														</div> 
														<div class="form-group">
															<textarea name="message" id="message" required="required" class="form-control" rows="8" placeholder="Message"></textarea>
														</div> 
														<div class="form-group">
															<button type="submit" class="btn btn-primary">Send</button>
														</div>
													</form> 
												</div>
											</div>
										</div>
									</div>
								</div> 
							</section>-->
  <div class="container">
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
      <div class="modal-dialog modal-sm">
      <div class="modal-content" style="border-radius: 1px;">
        <div class="modal-header">
            <img src="images/logo.jpg" width="200">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <span class="modalTextLog">Login access to BizConnect</span>
          <!--<h4 class="modal-title"> Login access to BizConnect</h4>-->
        </div>
        <div class="modal-body">
           <div class="modal-body">
          <form role="form"  >
              
                  <div class="form-group">
                    <div class="input-group">
                      <!--  <label for="uLogin" class="input-group-addon"><img src="images/userIcon.png"></label>-->
							 <input type="text" class="form-control" id="exampleInputEmail1" placeholder="Enter EmailID" required>
							
						</div>
                     
                  </div>
                  <div class="form-group">
                     <div class="input-group">
                       <!--  <label for="uPwd" class="input-group-addon"><img src="images/password-key.png"></label>-->
							<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Enter Password" onkeypress="return searchKeyPress(event);" required>
                 
							
						</div>
                       </div>
                  <div class="checkbox">
                    <label>
                        <input type="checkbox"/> Remember Me
                    </label>
                  </div>
                  
              <button id="login" class="btn btn-primary" type="button" value="Login" onclick="submitlogin()" ><span class="glyphicon glyphicon-off"></span> Login</button>
               
              <div id="load">
                <!--  <img src="images/loadd.GIF"  title="PleaseWait..." />-->

               </div>
                </form>
        </div>

        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default btn-default pull-left" data-dismiss="modal">Close</button>
                <p>Forgot <a href="#">Password?</a></p>
            <!--<a data-toggle="modal" data-target="#divpwd" href="#" >Forgot Passaword</a>-->
        </div>
      </div>
    </div>
  </div>
</div>

	<footer id="footer"> 
		<div class="container"> 
			<div class="text-center"> 
				<p>Copyright &copy; 2016 - <a href="http://www.aarmsvaluechain.com//">AARMS ValueChain Pvt.Ltd</a> | All Rights Reserved</p> 
			</div> 
		</div> 
	</footer> <!--/#footer--> 

	<script type="text/javascript" src="js/jquery.js"></script> 
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script type="text/javascript" src="js/smoothscroll.js"></script> 
	<script type="text/javascript" src="js/jquery.isotope.min.js"></script>
	<script type="text/javascript" src="js/jquery.prettyPhoto.js"></script> 
	<script type="text/javascript" src="js/jquery.parallax.js"></script> 
	<script type="text/javascript" src="js/main.js"></script>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
</body>
</html>
