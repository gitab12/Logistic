<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Contactus.aspx.cs" Inherits="Contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        //Only Charcters
        function onlyalpha(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 8))

                return false;
            return true;
        }

        //Only Numbers
        function onlynumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 48 || charCode > 57) && (charCode != 8))
                return false;
            return true;
        }
        //Only Letter,numbers no space
        function nospace1(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode == 32))


                return false;
            return true;


        }
        //Only numbers with Decimals
        function onlynumberwithDecimals(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 48 || charCode > 57) && (charCode != 8) && (charCode != 46))
                return false;
            return true;
        }


        //Only Charcters with space
        function onlyalphawithspace(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 8) && (charCode != 32))

                return false;
            return true;
        }
        //validate password length
        function validateLength(oSrc, args) {
            args.IsValid = (args.Value.length >= 6);
        }
 </script>
    <!-- Add Google Maps -->
<script src="http://maps.googleapis.com/maps/api/js"></script>
<script>
    //var myCenter = new google.maps.LatLng(12.926019, 77.516795);

    //function initialize() {
    //    var mapProp = {
    //        center: myCenter,
    //        zoom: 12,
    //        scrollwheel: false,
    //        draggable: false,
    //        mapTypeId: google.maps.MapTypeId.ROADMAP
    //    };

    //    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

    //    var marker = new google.maps.Marker({
    //        position: myCenter,
    //    });

    //    marker.setMap(map);
    //}

    //google.maps.event.addDomListener(window, 'load', initialize);
    function initialize() {
        var myLatlng = new google.maps.LatLng(12.920313, 77.517680);
        var mapOptions = {
            zoom: 18,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }
        var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: 'Contact'
        }
                                           );
    }
    google.maps.event.addDomListener(window, 'load', initialize);
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br />
     <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <div class="container" style="margin-left:100px;">
      <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-2">
									<h2 class="title-one">CONTACT WITH US</h2>
									<!--<p class="blog-heading">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>-->
								</div>
							</div> 
 <div class="container-fluid bg-grey" style=" margin-left: 335px;">
  <h2 class="text-center"></h2>
     <h3> <asp:Label ID="lblcommnt" runat="server" style="color: rgb(183, 8, 8);"></asp:Label></h3>
  <div class="row">
  
    <div class="col-sm-7">
      <div class="row">
        <div class="col-sm-6 form-group">
          
               <asp:TextBox  ID="TxtName" runat="server" placeholder="Name"  onkeypress="return onlyalphawithspace(event)"  class="form-control"></asp:TextBox> 
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" Enter Name" ControlToValidate="TxtName" Style="color:#003366;font-size:12px;" Display="dynamic" ValidationGroup="myprf" />   
        </div>
        <div class="col-sm-6 form-group">
          <asp:TextBox  ID="TextCompanyName" runat="server" placeholder=" Company Name" class="form-control" onKeyPress="return onlyalpha(event)" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage=" Enter Company Name" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf"  ControlToValidate="TextCompanyName"/>
        </div>
           <div class="col-sm-6 form-group">
          <asp:TextBox  ID="TxtCompanyWebsite" runat="server" AutoCompleteType="none" placeholder="Company Website" class="form-control"></asp:TextBox>
                                eg:.www.bizconnect.com
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter valid URL" ControlToValidate="TxtCompanyWebsite" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            
        </div>
        <div class="col-sm-6 form-group">
          <asp:TextBox  ID="TxtEmail" runat="server" placeholder="Email" class="form-control"   ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmail" ValidationGroup="myprf" Style="color:#003366;font-size:12px;"  Display="dynamic"  />   
                
        </div>
           <div class="col-sm-6 form-group">
          <asp:TextBox  ID="TxtMobile" runat="server"  placeholder=" Mobile Number" class="form-control" MaxLength="10" onkeypress="return onlynumber(event)"></asp:TextBox>
                               
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage=" Enter Mobile Number" ControlToValidate="TxtMobile" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            <br/>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="TxtMobile" ErrorMessage="Invalid Contact Number" Style="color:#003366;font-size:12px;"  ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="myprf"></asp:RegularExpressionValidator>
                           
        </div>
           <div class="col-sm-6 form-group">
         
        </div>
            <div class="col-sm-11 form-group" >
                <h3 style="color: rgb(183, 8, 8);" >Websites<span style="color: #ff0000"> *</span></h3>
                              <asp:CheckBox ID="CheckBox1" runat="server" Text="Logistics" style="color: rgb(183, 8, 8);" />
                                </div>
                              <div class="col-sm-6 form-group" >
                              <asp:CheckBox ID="CheckBox2" runat="server" Text="AR Focussed"  style="color: rgb(183, 8, 8);" />
                                    </div> 
               <div class="col-sm-6 form-group" >
                              <asp:CheckBox ID="CheckBox3" runat="server" Text="C-Form Management" style="color: rgb(183, 8, 8);"  />
       </div>  <div class="col-sm-6 form-group" >
                              <asp:CheckBox ID="CheckBox4" runat="server" Text="Document Digitised" style="color: rgb(183, 8, 8);" />
              </div><div class="col-sm-6 form-group" >
                              <asp:CheckBox ID="CheckBox5" runat="server" Text="GST Workflow" style="color: rgb(183, 8, 8);" />
                    </div><div class="col-sm-6 form-group" >
                              <asp:CheckBox ID="CheckBox6" runat="server" Text="Bizconnect" style="color: rgb(183, 8, 8);" />
                                
                            </div>
      </div>
      
         <asp:TextBox  ID="TextComment1" runat="server" placeholder="Comment" class="form-control"  onkeypress="return only_alpha_with_space(event)"  TextMode="MultiLine" rows="5" ></asp:TextBox> 
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" Enter Comments" ControlToValidate="TextComment1" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" /> <br/>  
                            
      <div class="row">
        <div class="col-sm-12 form-group">
       <%--   <button class="btn btn-default pull-right" type="submit">Send</button>--%>
             <asp:Button ID="Button2" runat="server"   Text="Send" OnClick="Button2_Click"  ValidationGroup="myprf" class="btn btn-primary pull-right" ></asp:Button>
           
<br/>
        </div>
      </div>
    </div>
        <div class="col-sm-5">
            <h2 style="color: rgb(183, 8, 8);" >Corporate Address</h2>
      <p>Contact us and we'll get back to you within 24 hours.</p>
      <p><span class="glyphicon glyphicon-map-marker"></span> #211,Temple Street, 9th Main Road, BEML III Stage, Rajarajeswarinagar,, Remco Bhel Layout, Ideal Homes Twp, RR Nagar, Bengaluru, Karnataka 560098</p>
      <p><span class="glyphicon glyphicon-phone"></span> 098454 97950</p>
      <p><span class="glyphicon glyphicon-envelope"></span>  g.jagan@aarmsvaluechain.com </p>
    </div>
  </div>
</div>
 <!-- Set height and width with CSS -->
 <div id="map-canvas" style="width: 100%; height: 400px">
        </div>
        </div>




</asp:Content>

