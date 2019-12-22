<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="UserControl_Control" %>
<link href="../css/animate.css" rel="stylesheet" />
<link href="../css/bootstrap.min.css" rel="stylesheet" />
<link href="../css/font-awesome.min.css" rel="stylesheet" />
<link href="../css/jquery.sidr.dark.css" rel="stylesheet" />
<link href="../css/main.css" rel="stylesheet" />
<link href="../css/prettyPhoto.css" rel="stylesheet" />
<link href="../css/reset.css" rel="stylesheet" />
<link href="../css/responsive.css" rel="stylesheet" />
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
<section id="our-team">
			<div class="container">
				<div class="row text-center">
					<div class="col-sm-8 col-sm-offset-2">
						<h2 class="title-one"  style="color: rgb(183, 8, 8);" >Our Clients</h2>
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
									<img src="images/our-team/member1.JPG" alt="team member" />
                                   
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
									<img src="images/our-team/member2.JPG" alt="team member" />
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
									<img src="images/our-team/member1.JPG" alt="team member" />
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
									<img src="images/our-team/member2.JPG" alt="team member" />
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
		</section>
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
                                        
										<a href="http://www.scmjunction.com"><img style=" height:80px;" src="images/blog/1.png" alt="" /></a>
										<h2>Scm Junction</h2>
										<!--<ul class="post-meta">
											<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
											<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
										</ul>-->
										<div class="blog-content">
											<p>Innovative management through Partnerships, Competitions, Communication and transparent pricing model, which enhances value chain productivity.</p>
										</div>
									<!--	<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-detail">Read More</a>-->
									</div>
									<div class="modal fade" id="blog-detail" tabindex="-1" role="dialog" aria-hidden="true">
										<div class="modal-dialog">
											<div class="modal-content">
												<div class="modal-body">
													<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
													<img src="images/blog/3.png" alt="" />
													<h2>Lorem ipsum dolor sit amet</h2>
													<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
												</div> 
											</div>
										</div>
									</div>
								</div>
								<div class="col-sm-4">
									<div class="single-blog">
										<a href="http://www.aaumconnect.com/" target="_blank"><img style=" height:80px;" src="images/blog/3.png" alt="" /></a>
										<h2>Aaumconnect</h2>
										<!--<ul class="post-meta">
											<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
											<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
										</ul>-->
										<div class="blog-content">
											<p>Aaumconnect is a vehicle tracking device which ensures real-time tracking of vehicles.Aaumconnect aims at providing a cost effective solution.</p>
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
										<a href="http://www.arfocused.com/" target="_blank"><img style="height:80px;" src="images/blog/2.png" alt="" /></a>
										<h2>AR Focused</h2>
									<!--	<ul class="post-meta">
											<li><i class="fa fa-pencil-square-o"></i><strong> Posted By:</strong> John</li>
											<li><i class="fa fa-clock-o"></i><strong> Posted On:</strong> Apr 15 2014</li>
										</ul>-->
										<div class="blog-content">
											<p>Focussed follow up management, aimed at improving cash-flows, enhancing sales team productivity and prevent bad debt shocks by escalations.</p>
										</div>
										<!--<a href="" class="btn btn-primary" data-toggle="modal" data-target="#blog-three">Read More</a>-->
									</div>
									<div class="modal fade" id="blog-three" tabindex="-1" role="dialog" aria-hidden="true">
										<div class="modal-dialog">
											<div class="modal-content">
												<div class="modal-body">
													<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
													<img style="width:245px; height:80px;" src="../images/blog/2.jpg" alt="" />
													<h2>Lorem ipsum dolor sit amet</h2>
													<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
												</div> 
											</div>
										</div>
									</div>
								</div>
								<div class="col-sm-4">
									<div class="single-blog">
										<a href="http://www.documentsdigitized.com/" target="_blank"><img src="images/blog/4.png" alt="" /></a>
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
											<a href="http://www.gstworkflow.com/" target="_blank"><img src="images/blog/5.png" alt="" /></a>
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
														<img src="../images/blog/3.jpg" alt="" />
														<h2>Lorem ipsum dolor sit amet</h2>
														<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
													</div> 
												</div>
											</div>
										</div>
									</div>

									<div class="col-sm-4">
										<div class="single-blog">
											<a href="http://www.b2bcustomersupport.com/" target="_blank"><img src="images/blog/6.png" alt="" /></a>
											<h2>B2B Customer Services</h2>
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
						</section>