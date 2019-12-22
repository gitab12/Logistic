<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="PostTripPlan.aspx.cs" Inherits="PostTripPlan" %>
<%--<%@ Register Src="~/UserControl/MenuBar.ascx" TagName="menu" TagPrefix="menu" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
           <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

<script type="text/javascript">
    function CheckForPastDate(sender, args) {
        var selectedDate = new Date();
        selectedDate = sender._selectedDate;
        var todayDate = new Date();
        if (selectedDate.getDateOnly() < todayDate.getDateOnly()) {
            sender._selectedDate = todayDate;
            sender._textbox.set_Value(sender._selectedDate.format(sender._format));
            alert("Date Cannot be in the past");
        }

    }
</script>

    <%--<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAaczGkYJhz_uP1Xo03sWxYnBB7R1NXzZE&sensor=false&libraries=places&language=eng&types=establishment"></script>--%>

<script language="javascript" type="text/javascript">
    function SearchAddressByGoogle(ControlName, e) {//this function will use to get search address from google
        var options = {
            // types: ['(cities)'],
            componentRestrictions: {}
        };
        var control = document.getElementById(ControlName);
        var autocomplete = new google.maps.places.Autocomplete(control, options);
    }

    var directionsDisplay;
    var directionsService = new google.maps.DirectionsService();
    function InitializeMap() {
        directionsDisplay = new google.maps.DirectionsRenderer();
        var latlng = new google.maps.LatLng(17.425503, 78.47497);
        var myOptions = {
            zoom: 13,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        var control = document.getElementById('TblAgreement');
        control.style.display = 'block';
    }

    function calcRoute() {//this function will use to get direction
        var start = document.getElementById('txtfrom').value;
        var end = document.getElementById('txtTo').value;
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
            }
        });
    }

    function btnDirections_onclick() {
        calcRoute();
    }

    window.onload = InitializeMap;//Load defult map
</script>

     <style type="text/css">

        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :650px;
    height :360px;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        background:rgba(217, 211, 182, 0.30);
        /*background:rgba(248, 127, 10, 0.60);*/
    }
    .mapinnerdiv {
    margin:5px;
    padding:0;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        /*background:rgba(26, 154, 228, 0.87);*/
        background:rgb(255, 255, 255);
    }
         
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<menu:menu ID="Menu" runat="server" />
<br />--%>
<br />
 
        <div class="col-sm-8 col-sm-offset-3">
 <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
 <table width="650px">
    <tr>
                    <td>
                        <div class="row text-center">
				<div class="col-sm-8 col-sm-offset-2">
					<h2 class="title-one">Single Trip Plan</h2>
					<!--<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>-->
				</div>
                            </div>
                    </td>
                </tr>
 </table>
    <br />
     <div class ="mapouterdiv" >
    <asp:Panel ID="paneltrip" runat="server"  Font-Bold="True"  Height="400px" Width="650px">      
  <div class ="mapinnerdiv" >
        
        <table runat="server" id="TblAgreement" align="center"> 
 <tr>
 <td>
 From:
 </td>
 <td>
     <ajaxToolkit:AutoCompleteExtender ID ="auto_FromLoc" runat ="server" TargetControlID="txtfrom"
            MinimumPrefixLength="1" EnableCaching="false" CompletionSetCount="10" CompletionInterval="100"  
             ServiceMethod="GetFromLocation" FirstRowSelected ="false" >
        </ajaxToolkit:AutoCompleteExtender>

     <asp:TextBox ID="txtfrom" runat="server" onkeypress="return onlyalphawithspace(event)"></asp:TextBox>
     <asp:RequiredFieldValidator ID="reqdfrom" runat="server" ErrorMessage="*" ControlToValidate="txtfrom" ForeColor="Red"></asp:RequiredFieldValidator>
 </td>
 </tr>
 <tr>
 <td>
 To:
 </td>
 <td>
     <ajaxToolkit:AutoCompleteExtender ID ="auto_ToLoc" runat ="server" TargetControlID="txtTo"
            MinimumPrefixLength="1" EnableCaching="false" CompletionSetCount="10" CompletionInterval="100"  
             ServiceMethod="GetToLocation" FirstRowSelected ="false" >
        </ajaxToolkit:AutoCompleteExtender>

 <asp:TextBox ID="txtTo" runat="server" onkeypress="return onlyalphawithspace(event)"></asp:TextBox>
 <asp:RequiredFieldValidator ID="reqdto" runat="server" ErrorMessage="*" ControlToValidate="txtTo" ForeColor="Red"></asp:RequiredFieldValidator>
 </td>
 </tr>
 <tr>
 <td>
 Travel Date
 </td>
 <td>
 <asp:TextBox ID="txttravelDate" runat="server" ></asp:TextBox>
<asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txttravelDate" OnClientDateSelectionChanged="CheckForPastDate">
 </ajaxToolkit:CalendarExtender>
 </td>
 </tr>
 <tr>
 <td>
 No.of Trucks:
 </td>
 <td>
 <asp:TextBox ID="txtnooftruck" runat="server" MaxLength="4" onkeypress="return onlynumber(event)"></asp:TextBox>
 <asp:RequiredFieldValidator ID="reqdsource" runat="server" ErrorMessage="*" ControlToValidate="txtnooftruck" ForeColor="Red"></asp:RequiredFieldValidator>
 </td>
 </tr>
 <tr>
 <td>
 Goods Type:
 </td>
 <td>
     <asp:TextBox ID="txtgoods" runat="server" onkeypress="return onlyalphawithspace(event)"></asp:TextBox>
 </td>
 </tr>
 <tr>
 <td>
 Enclosure Type:
 </td>
 <td>
     <asp:DropDownList ID="DDLEnclType" runat="server" Width="140px">
     </asp:DropDownList>
 </td>
 </tr>
 <tr>
 <td>
 Truck Type:
 </td>
 <td>
     <asp:DropDownList ID="DDLTruckType" runat="server" Width="140px">
     </asp:DropDownList>
 </td>
 </tr>
 <tr>
 <td>
 Capacity:
 </td>
 <td>
     <asp:TextBox ID="txtcapacity" runat="server" onkeypress="return onlynumber(event)" MaxLength="2"></asp:TextBox>
 </td>
 </tr>
  <tr>
         <td>
             Target Price per Truck:
         </td>
         <td>
             <asp:TextBox ID="txtprice" runat="server" onkeypress="return onlynumber(event)" Text="0"></asp:TextBox>
         </td>
     </tr>
  <tr>
 <td>
 Remarks:
 </td>
 <td>
     <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine"></asp:TextBox>
 </td>
 </tr>
 <tr>
 <td>
 </td>
 <td>
     <br />
     <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
         onclick="btnsubmit_Click"  class="btn btn-primary" />
     <br />
     <br />
 </td>
 <td>
     <br />
     <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
     <br />
 </td>
 </tr>
 </table>
        </div> 
   </asp:Panel>
         </div>
 <br /><br /><br /> <br /><br /><br />  <br /><br /><br />     
   
  
</asp:Content>

