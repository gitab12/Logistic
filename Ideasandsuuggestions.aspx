<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Ideasandsuuggestions.aspx.cs" Inherits="Ideasandsuuggestions" %>

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
        <script type ="text/javascript" >
            //only alphabetical with space
            function onlyalphawithspace(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 8) && (charCode != 32))

                    return false;
                return true;
            }

    </script>
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
      <style>
        .form-control1 {
    display: block;
    width: 200%;
    height: 34px;
    padding: 6px 12px;
    font-size: 14px;
    line-height: 1.42857143;
    color: #555;
    background-color: #fff;
    background-image: none;
    border: 1px solid #ccc;
    border-radius: 4px;
    -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
    box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
    -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
    -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
    transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
}
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
  <div class="container" style="margin-left:100px;">
      <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-2">
									<h2 class="title-one">IDEAS AND SUGGESTIONS</h2>
									<!--<p class="blog-heading">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>-->
								</div>
							</div> 
      <div class="panel-group">
    <div class="panel panel-default">
      <div class="panel-heading"><h3 style="color: rgb(183, 8, 8);" >Ideas/Suggestions</h3></div>
      <div class="panel-body">
                    <div class="row">

                            <div class="col-sm-2 form-group">
                                 
                                  <label for="inputFirstName" style="color: rgb(183, 8, 8);" > Name </label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TxtName" runat="server" placeholder="Name" class="form-first-name form-control1"  onkeypress="return onlyalphawithspace(event)"  ></asp:TextBox> 
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" Enter Name" ControlToValidate="TxtName" Style="color:#003366;font-size:12px;" Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                            <div class="col-sm-5 form-group">
                               
                            </div>
                          <div class="col-sm-2 form-group">
                                       <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Occuption</label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TxtOccuption" runat="server" placeholder="Occuption" class="form-first-name form-control1" onKeyPress="return onlyalpha(event)" ></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage=" EnterOccuption" ControlToValidate="TxtOccuption" Style="color:#003366;font-size:12px;" Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                         <div class="col-sm-11 form-group" >
                               
                               
                            </div>

                         <div class="col-sm-2 form-group">
                                 <label for="inputFirstName" style="color: rgb(183, 8, 8);">CompanyName</label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TextCompanyName" runat="server" placeholder=" CompanyName" class="form-first-name form-control1" onKeyPress="return onlyalpha(event)" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage=" Enter CompanyName" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf"  ControlToValidate="TextCompanyName"/>  
                         </div>
                        <div class="col-sm-5 form-group" >
                               
                              
                         </div>
                              
                            <div class="col-sm-2 form-group">
                            <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Company Website</label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TxtCompanyWebsite" runat="server" AutoCompleteType="none" placeholder="Company Website" class="form-first-name form-control1"  ></asp:TextBox>
                                eg:.www.bizconnect.com
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter valid URL" ControlToValidate="TxtCompanyWebsite" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                            <div class="col-sm-11 form-group" >
                               
                               
                            </div>
                         <div class="col-sm-2 form-group">
                                
                                  <label for="inputFirstName" style="color: rgb(183, 8, 8);">Email Address</label><span style="color: #ff0000"> *</span>
                             <asp:TextBox  ID="TxtEmail" runat="server" placeholder="Email Address" class="form-first-name form-control1"   ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmail" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
               
                            
                            </div>
                                 <div class="col-sm-5 form-group" >
                               
                                
                            </div>
                            <div class="col-sm-2 form-group">
                            <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Location</label><span style="color: #ff0000"> *</span>
                           
                             <asp:TextBox ID="TextLocation" runat="server"  placeholder="Location" class="form-first-name form-control1" onKeyPress="return onlyalpha(event)" >
                               
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter Location name" ControlToValidate="TextLocation" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                         <div class="col-sm-11 form-group" >
                               
                                
                            </div>
                        

                            <div class="col-sm-2 form-group">
                                
                                  <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Mobile</label><span style="color: #ff0000"> *</span>
                             <asp:TextBox  ID="TxtMobile" runat="server"  placeholder=" Mobile Number" class="form-first-name form-control1" MaxLength="10" onkeypress="return onlynumber(event)"></asp:TextBox>
                               
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage=" Enter Mobile Number" ControlToValidate="TxtMobile" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            <br/>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="TxtMobile" ErrorMessage="Invalid Contact Number" Style="color:#003366;font-size:12px;"  ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="myprf"></asp:RegularExpressionValidator>
                            </div>
                                 <div class="col-sm-5 form-group" >
                               
                                
                            </div>
                            <div class="col-sm-2 form-group">
                                 <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Phone Number</label><span style="color: #ff0000"> *</span>
                               <asp:TextBox  ID="TxtPhNum" runat="server" placeholder=" Phone Number" class="form-first-name form-control1" onkeypress="return onlynumber(event)" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage=" Enter  Phone Number" ControlToValidate="TxtPhNum" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                       
                         <div class="col-sm-11 form-group" >
                               
                                
                            </div>
            </div>
      </div>
         <div class="panel-heading"><h3 style="color: rgb(183, 8, 8);" >Websites<span style="color: #ff0000"> *</span></h3></div>
      <div class="panel-body">
          <div class="row">

                            <div class="col-sm-2 form-group" >
                              <asp:CheckBox ID="CheckBox1" runat="server" Text="Logistics" style="color: rgb(183, 8, 8);" />
                                </div>
                              <div class="col-sm-2 form-group" >
                              <asp:CheckBox ID="CheckBox2" runat="server" Text="AR Focussed"  style="color: rgb(183, 8, 8);" />
                                    </div> 
               <div class="col-sm-3 form-group" >
                              <asp:CheckBox ID="CheckBox3" runat="server" Text="C-Form Management" style="color: rgb(183, 8, 8);"  />
       </div>  <div class="col-sm-3 form-group" >
                              <asp:CheckBox ID="CheckBox4" runat="server" Text="Document Digitised" style="color: rgb(183, 8, 8);" />
              </div><div class="col-sm-2 form-group" >
                              <asp:CheckBox ID="CheckBox5" runat="server" Text="GST Workflow" style="color: rgb(183, 8, 8);" />
                    </div><div class="col-sm-2 form-group" >
                              <asp:CheckBox ID="CheckBox6" runat="server" Text="Bizconnect" style="color: rgb(183, 8, 8);" />
                                
                            </div>


      </div>
          </div>
         <div class="panel-heading"><h3 style="color: rgb(183, 8, 8);">Give Your Comments</h3></div>
      <div class="panel-body">
           <div class="row">

                            <div class="col-sm-2 form-group">
                                 
                                  <label for="inputFirstName" style="color: rgb(183, 8, 8);" > Site Architeture </label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TextComment1" runat="server" placeholder="Comments" class="form-first-name form-control1"  onkeypress="return only_alpha_with_space(event)"  TextMode="MultiLine" Height="50px" ></asp:TextBox> 
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" Enter Comments" ControlToValidate="TextComment1" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                            <div class="col-sm-5 form-group" >
                               
                            </div>
                          <div class="col-sm-2 form-group">
                                       <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Look</label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TextComment2" runat="server" placeholder="Comments" class="form-first-name form-control1" TextMode="MultiLine" Height="50px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" Enter Comments" ControlToValidate="TextComment2" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                         <div class="col-sm-11 form-group" >
                               
                               
                            </div>

                         <div class="col-sm-2 form-group">
                                 <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Design</label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TextComment3" runat="server" placeholder="Comments" class="form-first-name form-control1" TextMode="MultiLine" Height="50px" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" Enter Comments" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf"  ControlToValidate="TextComment3"/>  
                         </div>
                        <div class="col-sm-5 form-group" >
                               
                              
                         </div>
                              
                            <div class="col-sm-2 form-group">
                            <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Language</label><span style="color: #ff0000"> *</span>
                                <asp:TextBox  ID="TextComment4" runat="server" placeholder="Comments" class="form-first-name form-control1" onkeypress="return only_alpha_with_space(event)"  TextMode="MultiLine" Height="50px" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage=" Enter Comments" ControlToValidate="TextComment4" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                            <div class="col-sm-11 form-group" >
                               
                               
                            </div>
                         <div class="col-sm-2 form-group">
                                
                                  <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Concept</label><span style="color: #ff0000"> *</span>
                             <asp:TextBox  ID="TextComment5" runat="server" placeholder="Comments" class="form-first-name form-control1"  TextMode="MultiLine" Height="50px" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage=" Enter  Comments" ControlToValidate="TextComment5" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
               
                            
                            </div>
                                 <div class="col-sm-5 form-group" >
                               
                                
                            </div>
                            <div class="col-sm-2 form-group">
                            <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Additional Information</label><span style="color: #ff0000"> *</span>
                           
                             <asp:TextBox ID="TextComment6" runat="server"  placeholder="Comments" class="form-first-name form-control1" onkeypress="return_nothing(event)"  TextMode="MultiLine" Height="50px">
                               
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage=" Enter  Comments" ControlToValidate="TextComment6" Style="color:#003366;font-size:12px;"  Display="dynamic" ValidationGroup="myprf" />   
                            </div>
                         <div class="col-sm-11 form-group" >
                               
                                
                            </div>
                        

                            <div class="col-sm-2 form-group">
                                
                                  <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Related Business Ideas</label>
                             <asp:TextBox  ID="TextComment7" runat="server"  placeholder="Enter Comments" class="form-first-name form-control1"  TextMode="MultiLine" MaxLength="500" Height="50px"></asp:TextBox>
                            </div>
                                 <div class="col-sm-5 form-group" >
                               
                                
                            </div>
                            <div class="col-sm-2 form-group">
                                 <label for="inputFirstName" style="color: rgb(183, 8, 8);" >Please Provide Some B2BReferrals</label>
                               <asp:TextBox  ID="TextComment8" runat="server" placeholder="Enter Comments" class="form-first-name form-control1"  TextMode="MultiLine"  MaxLength="500" Height="50px"></asp:TextBox>
                           </div>
                       
                         <div class="col-sm-11 form-group" >
                               
                                
                            </div>
            </div>

                 <div class="col-sm-5 form-group" >
                       <asp:Button ID="But_Submit" runat="server" Text="Submit"  OnClick="But_Submit_Click"  ValidationGroup="myprf" class="btn btn-primary" />
                      <asp:Button ID="Button1" runat="server"  Text="Cancel" OnClick="Button1_Click"  class="btn btn-primary" />
                     <br />

                     <asp:Label ID="lblcommnt" runat="server" style="color: rgb(183, 8, 8);"></asp:Label>
                    <%--  <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following error occurs:" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" ValidationGroup="myprf" />--%>
             
                    </div>
            

      </div>

        
    </div>
</div>
  </div>
            
                  </ContentTemplate>
       


          <Triggers>
  <asp:PostBackTrigger ControlID="Button1" />  
     <asp:PostBackTrigger ControlID="But_Submit"/>   
 </Triggers>
    </asp:UpdatePanel>
</asp:Content>

