<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControl_Header" %>

<link href="../css/animate.css" rel="stylesheet" />
<link href="../css/bootstrap.min.css" rel="stylesheet" />
<link href="../css/font-awesome.min.css" rel="stylesheet" />
<link href="../css/jquery.sidr.dark.css" rel="stylesheet" />
<link href="../css/main.css" rel="stylesheet" />
<link href="../css/prettyPhoto.css" rel="stylesheet" />
<link href="../css/reset.css" rel="stylesheet" />
<link href="../css/responsive.css" rel="stylesheet" />
<link rel="shortcut icon" href="../images/ico/images.png"> 
	<!--[if lt IE 9]> <script src="js/html5shiv.js"></script> 
	<script src="js/respond.min.js"></script> <![endif]--> 
	<link rel="shortcut icon" href="www.scmbizconnect.com/scm/scm/bizconnect/images/ico/images.png"> 
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
    <header id="navigation"> 
		<div class="navbar navbar-inverse navbar-fixed-top" role="banner"> 
			<div class="container"> 
				<div class="navbar-header"> 
					<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> 
						<span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> 
					</button> 
					<a class="navbar-brand" href="index.html"><h1><img src="images/logo.jpg" alt="logo" /></h1></a> 
				</div> 
				<div class="collapse navbar-collapse"> 
					<ul class="nav navbar-nav navbar-right"> 
						<li><a href="index.html">Home</a></li> 
						<li><a href="knowabtscm.aspx" >About Us</a></li> 
						<li><a href="http://www.scmbizconnect.com/bizWorkFlow/bizUserGuideIndex.htm"  target="_blank">WORKFLOW</a></li> 
						<li><a href="readmore.aspx" >B2B</a></li> 
						<li><a href="Ideasandsuuggestions.aspx" >IDEAS AND SUGGESTIONS</a></li> 
						<li><a href="Contactus.aspx" >Contact Us</a></li> 
						<li><a data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-lock"></span> Login</a></li> 
                        <%-- <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>
						<!--<li class="scroll"><a href="#contact">Contact</a></li> -->
					</ul> 
				</div> 
			</div> 
            <%--<marquee style=" background-color: rgb(30, 30, 146); color:#fff;height: 25px;font-family:Roboto,sans-serif;font-size: medium; border-bottom: medium none rgb(186, 186, 186);">BIZCONNECT IS A POWERFUL IDEA, THAT ASSURES PRICE PRODUCTIVITY, COST REDUCTION, SLA ADHERANCE, THROUGH COMMITMENT, CONSOLIDATION, CROSS LOGISTICS, EXTENDED COMPETITION AND MICRO MANAGEMENT</marquee>--%>
		</div><!--/navbar-->
        <body onload="checkCookie()">
        <div class="container">
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
      <div class="modal-dialog modal-sm">
      <div class="modal-content" style="border-radius: 1px;">
        <div class="modal-header">
            <img src="images/logo.jpg"  width="200" alt="Logo"/>
            <button type="button" class="close" data-dismiss="modal">&times;</button>
           <%-- <span class="modalTextLog">Login access to BizConnect</span>--%>
          <!--<h4 class="modal-title"> Login access to BizConnect</h4>-->
        </div>
        <div class="modal-body">
           <div class="modal-body">
          <form role="form"  >
              
              
                  <div class="form-group">
                    <div class="input-group">
                      <!--  <label for="uLogin" class="input-group-addon"><img src="images/userIcon.png"></label>-->
							 <%--<input type="text" class="form-control" id="exampleInputEmail1" placeholder="Enter EmailID" required>--%>
               <asp:TextBox ID="txtUserID" runat="server" class="form-control" placeholder="Enter EmailID" ></asp:TextBox>
						</div>
                     
                  </div>
                  <div class="form-group">
                     <div class="input-group">
                       <!--  <label for="uPwd" class="input-group-addon"><img src="images/password-key.png"></label>-->
							<%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Enter Password" onkeypress="return searchKeyPress(event);" required>--%>
                  <asp:TextBox ID="txtPassword" runat="server" class="form-control"  placeholder="Enter Password" onkeypress="return searchKeyPress(event);"  TextMode="Password"></asp:TextBox>
							
						</div>
                       </div>
                  <div class="checkbox">
                    <label>
                        <input type="checkbox" id="remember" checked="checked" runat="server"/> Remember Me
                    </label>
                  </div>
               
                  
              <%--<button id="login" class="btn btn-primary" type="button" value="Login" onclick="submitlogin()" ><span class="glyphicon glyphicon-off"></span> Login</button>--%>

              

               <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click"   class="btn btn-primary" />
               <div>
                        <br />         <p>Not registered yet? <a href="ClientCreation.aspx">Click here</a></p>
                   </div>
               <div>
                        <br />         <p><a href="Registration_Digitized.aspx">E-Signature Registration</a></p>
                   </div>
              <div id="load">
                <!--  <img src="images/loadd.GIF"  title="PleaseWait..." />-->

               </div>
                </form>
        </div>

        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default btn-default pull-left" data-dismiss="modal">Close</button>
                <p>Forgot <a href="RecoverPassword.aspx">Password?</a></p>
            <!--<a data-toggle="modal" data-target="#divpwd" href="#" >Forgot Passaword</a>-->
        </div>
      </div>
    </div>
  </div>
</div>
            </body>
	</header>
   <script type="text/javascript" src="js/jquery.js"></script> 
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script type="text/javascript" src="js/smoothscroll.js"></script> 
	<script type="text/javascript" src="js/jquery.isotope.min.js"></script>
	<script type="text/javascript" src="js/jquery.prettyPhoto.js"></script> 
	<script type="text/javascript" src="js/jquery.parallax.js"></script> 
	<script type="text/javascript" src="js/main.js"></script>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
      <script type="text/javascript">
          $(function () {
              $("#delay").hide();
          });
          function send() {
              $("#delay").show();
              var emailidpwd = document.getElementById('PwdText').value;
              if (emailidpwd == "") {
                  alert('Please Enter Email ID!');
                  $("#delay").hide();
                  return false;
              }
              else {
                  $.ajax({
                      type: "POST",
                      url: "Forgotpwd_Methedcall.aspx/send",
                      // url: "Login.aspx/login",
                      data: '{emailid: "' + emailidpwd.toString() + '" }',//;typeofcall:"'+typeofcall+'"
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {
                          $("#delay").hide();
                          if (response.d == 'done') {
                              var emailidpwd;

                              emailidpwd = document.getElementById('PwdText').value = "";
                              alert('Your password is sent to your specified Email ID')

                              //window.location = "http://localhost:55944/W2WConnect/index.html";
                          }
                          else {
                              $("#delay").hide();
                              alert('Please Check Your Mail Id')
                          }
                      },


                  });

              }

          }
          function searchKeyPress(e) {
              // look for window.event in case event isn't passed in
              e = e || window.event;
              if (e.keyCode == 13) {
                  document.getElementById('login').click();
                  return false;
              }
              return true;
          }
          function regKeyPress(e) {
              // look for window.event in case event isn't passed in
              e = e || window.event;
              if (e.keyCode == 13) {
                  document.getElementById('btn').click();
                  return false;
              }
              return true;
          }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#load").hide();
        });

        function submitlogin() {
            $("#load").show();
            var emailid = document.getElementById('exampleInputEmail1').value;

            var Password = document.getElementById('exampleInputPassword1').value;

            putCookie();

            if (emailid == "" || Password == "") {
                alert('Please Enter Correct UserName and password !');
                $("#load").hide();
                return false;
            }

            //alert('kk')
            //alert(name.toString() + '/' + emailid.toString() + '/' + '/' + mobileno.toString() + '/' + '/' + profession.toString() + '/' + '/' + specialization.toString() + '/' + '/' + area.toString() + '/' + '/' + city.toString() + '/' + '/' + state.toString() + '/');
            $.ajax({
                type: "POST",
                url: "~Login.aspx/log",
                // url: "Login.aspx/login",
                data: '{emailid: "' + emailid.toString() + '",Password: "' + Password.toString() + '" }',//;typeofcall:"'+typeofcall+'"
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#load").hide();
                    if (response.d == 'done') {
                        window.location = "http://localhost:55495/SCM Bizconnect/MasterPage/Default.aspx";
                        //alert(' successfully Logged in')
                    }
                    else { alert('Sorry.You have not activated your account.Please SignUp first') }
                },
                failurelogin: function (response) {
                    $("#load").hide();
                    alert(response.d);
                }
            });
            //data: '{name: "' + name.toString() + '",emailid: "' + emailid.toString() + '",mobileno: "' + mobileno.toString() + '",profession: "' + profession.toString() + '",specialization: "' + specialization.toString() + '",area: "' + area.toString() + '",city: "' + city.toString() + '",state: "' + state.toString() + '" }',//;typeofcall:"'+typeofcall+'"

            function OnSuccess() {
                alert(response.d.toString());
                //if (response.d === 'done') { alert('Success') }
                //  else { alert('fail') }
            }
        }

    </script> 
<script>

    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toGMTString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }

    function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }

    function checkCookie() {

        var user = getCookie("username");
        var pwd = getCookie("password");
        if (user != "" && pwd != "") {
            document.getElementById('exampleInputEmail1').value = user;
            document.getElementById('exampleInputPassword1').value = pwd;
        } else {

        }
    }

    function putCookie() {
        alert('test');
        var user = document.getElementById('exampleInputEmail1').value;
        var pwd = document.getElementById('exampleInputPassword1').value;
        if (remember.checked == true) {
            if (user != "" && user != null) {
                setCookie("username", user, 1);
                setCookie("password", pwd, 1);
            }
        }
        else {
            if (user != "" && user != null) {
                setCookie("username", user, -1);
                setCookie("password", pwd, -1);

            }

        }

    }
</script>