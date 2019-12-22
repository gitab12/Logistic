<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" MaintainScrollPositionOnPostBack="true" AutoEventWireup="true" CodeFile="SMStoTransporter.aspx.cs" Inherits="SMStoTransporter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
     <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            |Supply Demand Matching|Trucks Available | Trucks Wanted | Goods Transport |
            Logistics </title>
     <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">
             <script src="https://maps.googleapis.com/maps/api/js?sensor=false&libraries=places" type="text/javascript"></script>
      <script type="text/javascript">

          function DestAutoComplete() {
              try {
                  var input = document.getElementById('txtCity');
                  var autocomplete = new google.maps.places.Autocomplete(input);
                  autocomplete.setTypes('changetype-geocode');
              }
              catch (err) {
                  // alert(err);
              }
          }


          google.maps.event.addDomListener(window, 'load', DestAutoComplete);
    </script>
    <script type="text/javascript">
        function Count(text) {
            //asp.net textarea maxlength doesnt work; do it by hand
            var maxlength = 140; //set your value here (or add a parm and pass it in)
            var object = document.getElementById(text.id)  //get your object
            if (object.value.length > maxlength) {
                object.focus(); //set focus to prevent jumping
                object.value = text.value.substring(0, maxlength); //truncate the value
                object.scrollTop = object.scrollHeight; //scroll to the end to prevent jumping
                return false;
            }
            return true;
        }

    </script>
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

      <style type="text/css">

        /*.mapouterdiv {
    /*margin:5px;*/
    /*padding:0;
    width :693px;
    height :175px;
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
        /*background:rgba(217, 211, 182, 0.30);*/
        /*background:rgba(248, 127, 10, 0.60);*/
    /*}
    .mapinnerdiv {
    margin:5px;
    padding:0;
     width :680px;
    height :165px;
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
        /*background:rgb(255, 255, 255);*/
    /*}**//**/

    /*.gridtable {
       
    margin:5px;
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:Black;
	/*border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;*/

    /*-webkit-border-radius: 8px;
    -moz-border-radius: 8px;
    overflow:hidden;
    border-radius: 10px;
    -pie-background: linear-gradient(#ece9d8, #E5ECD8);   
    box-shadow: #666 0px 2px 3px;
    behavior: url(Include/PIE.htc);
    overflow: hidden;
}*/

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
  <%--  <div class="row  text-center clearfix">
        <div class="col-sm-8 col-sm-offset-3"> --%>
     <div class="col-sm-12 col-sm-offset-1"> 

 <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
     
<table runat="server" id="TblAgreement" align="center">
<tr>
<td>
    
     Travel Date: <asp:TextBox ID="txttravelDate" runat="server"  Width="100px"></asp:TextBox>
   
<%--<asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/> --%>      
            <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px"  />
            <ajaxtoolkit:calendarextender ID="CalendarExtender3"  runat="server"  PopupButtonID="imgdate1" TargetControlID="txttravelDate" OnClientDateSelectionChanged="CheckForPastDate"></ajaxtoolkit:calendarextender><br />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txttravelDate" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter Date!"></asp:RequiredFieldValidator><br />
    <asp:RadioButton ID="radsingle" runat="server" Text="SinglePosting"  Checked="true" GroupName="a" AutoPostBack="true"  oncheckedchanged="radsingle_CheckedChanged"/>
    <asp:RadioButton ID="radmultiple" runat="server" Text="MultiplePosting" AutoPostBack="true" GroupName="a" oncheckedchanged="radmultiple_CheckedChanged" />
    &nbsp;&nbsp;
    <asp:RadioButton ID="rdb_BulkUpload" GroupName="a" runat="server" Text ="Bulk Upload" AutoPostBack="true" OnCheckedChanged ="rdb_BulkUpload_CheckedChanged" />
</td>
</tr>
</table>
<br />
  <%--  <div style="margin-left:150px">--%>
          <div class="container master-container">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
  
        <div class="panel panel-primary">
    <div class="panel-heading">Indent Upload</div>
    <div class="panel-body">

         <div class="col-lg-12"> 
  

          <div class="form-horizontal" role="form">
     <div class ="mapouterdiv" id="divouter" runat ="server" >
          <div class ="mapinnerdiv" id="divinner" runat ="server" >
<div runat="server" id="Table1" visible="true" align="center" class ="gridtable" >
     <div class="col-md-6" >
            <div class="form-group">
    <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>From</label>
<%--<asp:Label ID="labelfrom" runat="server"  Text="From:"></asp:Label>--%>
 <div class="col-lg-9"> 
<asp:TextBox ID="txtFrom" runat="server" placeholder="Enter Source" class="form-control"></asp:TextBox>
      </div>
                </div></div>
      <div class="col-md-6" >
            <div class="form-group">
    <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>To</label>
<%--<asp:Label ID="labelto" runat="server"  Text="To:"></asp:Label>--%>
 <div class="col-lg-9">
<asp:TextBox ID="txtto" runat="server" placeholder="Enter Destination" class="form-control"></asp:TextBox>
     </div>
                </div></div>

      <div class="form-horizontal" role="form">
              <div class="col-md-6" >
            <div class="form-group">
 <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>City</label>
<%--<asp:Label ID="lblCity" runat="server" ForeColor="Red" Text="City:"></asp:Label>--%>
<div class="col-lg-9">
 <asp:TextBox ID="txtCity" runat="server" placeholder="Enter City" class="form-control" ></asp:TextBox>
</div>
                </div>
        </div>


  
    <div class="col-md-6" >
            <div class="form-group">
<label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>No.of Truck</label>
<%--<asp:Label ID="labeltruck" runat="server" ForeColor="Red" Text="No.of Truck"></asp:Label>--%>

 <div class="col-lg-9">
 <asp:TextBox ID="txtnooftrucks" runat="server" placeholder="Enter No. of Truck" class="form-control" MaxLength="2" onkeypress="return onlynumber(event)"></asp:TextBox>

     </div>
     </div>
</div>
     
   </div>         
    <div class="form-horizontal" role="form">
     <div class="col-md-6" >
            <div class="form-group">
     <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>Encl.Type</label>
<%--<asp:Label ID="labelencl" runat="server" ForeColor="Red" Text="Encl.Type:"></asp:Label>--%>
<div class="col-lg-9">
    <asp:DropDownList ID="DDLEnclType" runat="server" class="form-control"> </asp:DropDownList> 
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ControlToValidate="DDLEnclType" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter Encl Type!"></asp:RequiredFieldValidator>
</div>
                </div>
                  </div>

<%--<td>
<label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>TravelDate</label>
<%--<asp:Label ID="labeldate" runat="server"  Text="TravelDate:"></asp:Label>--%>

<%--<td>  <asp:TextBox ID="txttravelDate" runat="server" ></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txttravelDate" OnClientDateSelectionChanged="CheckForPastDate">
</ajaxToolkit:CalendarExtender>  
<asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
    </td>--%>
<div class="col-md-6" >
            <div class="form-group">
    <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>Capacity</label>
<%--<asp:Label ID="labelcapacity" runat="server" ForeColor="Red" Text="Capacity:"></asp:Label>--%>
<div class="col-lg-9">
<asp:TextBox ID="txtCapacity" runat="server" placeholder="Enter Source" class="form-control"  onkeypress="return onlynumberwithDecimals(event)"></asp:TextBox>

</div>
                </div>
    </div>
        </div>
    <div class="form-horizontal" role="form">
<div class="col-md-6" >
            <div class="form-group">
<label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>TravelType</label>
<%--<asp:Label ID="labeltravelype" runat="server" ForeColor="Red" Text="TravelType:"></asp:Label>--%>
<div class="col-lg-9">
<asp:DropDownList ID="DDLTravelType" runat="server" class="form-control validate[required]"> </asp:DropDownList>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="DDLTravelType" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter Travel Type!"></asp:RequiredFieldValidator>
</div>
                </div>
    </div>
    <div class="col-md-6" >
            <div class="form-group">
    <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>TruckType</label>
<%--<asp:Label ID="labeltrucktype" runat="server" ForeColor="Red" Text="TruckType:"></asp:Label> --%>
<div class="col-lg-9">

    <asp:DropDownList ID="DDLTruckType" runat="server" class="form-control validate[required]"> </asp:DropDownList> 
       <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  runat="server" ControlToValidate="DDLTruckType" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter Truck Type!"></asp:RequiredFieldValidator>
</div>
                </div>
        </div>
        </div>

       <div class="form-horizontal" role="form">
           <div class="col-md-6" >
                <div class="form-group">
                    <label for="inputcmp" class="col-sm-3 control-label">Bid Start Time:</label>
                   
                       
                <div class="col-lg-3">

            <%--<asp:TextBox ID="txt_Cuttofftime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfq_CuttoffTime" runat="server" ControlToValidate ="txt_Cuttofftime" ValidationGroup ="aarms" ErrorMessage="Enter CuttoffTime"></asp:RequiredFieldValidator>--%>
                <asp:DropDownList ID="ddl_BidStartHours" runat="server" class="form-control">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                        </div>
                     <div class="col-lg-3">
                    <asp:DropDownList ID="ddl_BidStartMinutes" runat="server" class="form-control">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div class="col-lg-3">
                        <asp:DropDownList ID="ddl_BidStartAmpm" runat="server" class="form-control">
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
               </asp:DropDownList>
                    </div>
                 </div>
            </div>

       <div class="col-md-6" >
        <div class="form-group">
               <label for="inputcmp" class="col-sm-3 control-label">Cut Off Time:</label>
            
            
   <%-- <asp:Label ID="lblcutoff" runat="server" ForeColor="Red" Text="Cutoff Time"></asp:Label>--%>

    <%--<asp:TextBox ID="txtcutofftime" runat="server" Width="100px" Text="0"></asp:TextBox>--%>
       <div class="col-lg-3">
                <asp:DropDownList ID="ddl_Hours" runat="server" class="form-control">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                      </asp:DropDownList>
                </div>
                     <div class="col-lg-3">
                         <asp:DropDownList ID="ddl_Minutes" runat="server" class="form-control">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                </asp:DropDownList>
                </div>
                     <div class="col-lg-3">
                         <asp:DropDownList ID="ddl_Ampm" runat="server" class="form-control">
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                </asp:DropDownList>
                    </div>
                 </div>
            </div>

       </div>

   
 
<div class="form-horizontal" role="form">
            <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">Remarks:</label>
                     <div class="col-lg-9">
<%--Remarks:<asp:Label ID="labelRemarks" for="inputcmp" runat="server" class="col-sm-3 control-label"></asp:Label>--%>

    <asp:TextBox ID="txtremark" placeholder="Enter Remarks" class="form-control" runat="server"  TextMode="MultiLine"  MaxLength="140"  onKeyUp="javascript:Count(this);" onChange="javascript:Count(this);" ></asp:TextBox>
</div>
                    </div>
                    </div>
<%--<td>
    <asp:Button ID="btnadd" runat="server" Text="Add" onclick="btnadd_Click"/> 
</td>--%>
     <div class="col-md-6">
           <div class="col-lg-3">
    <asp:Button ID="Butsendsms" runat="server" Text="Submit" onclick="Butsendsms_Click" class="btn btn-success center-block"/> &nbsp;&nbsp;&nbsp; <asp:Button ID="btnadd" runat="server" Text="Add" onclick="btnadd_Click" class="btn btn-success center-block"/>
  </div>
</div>
    </div>
        </div> 
       </div> 
              </div>
       </div>  
  <%--  </div>  --%>
    <div class="col-sm-12"> 
     <div id="tbl_BulkUpload" runat ="server" >
      <div class="form-horizontal">
            <div class="form-group">
               <div class="row">
              <div class="well well-lg">
        <div class="col-sm-6 form-group">
            <div align="center">
             <a href ="http://www.scmbizconnect.com/Excel/UploadBulkIndent.xlsx" style="color:blue;text-decoration:underline">Download the Template For Bulk Upload </a><br />
            
            </div>
           </div>
    
         <br />
          </div>
          </div>
         
              
            <div class="form-horizontal" role="form">
                <div class="well well-lg">
         
                <div class="col-md-6" >
                <div class="form-group">
                     <label for="inputcmp" class="col-lg-3 control-label">Bid Start Time</label>              
                <div class="col-lg-3">
                <asp:DropDownList ID="ddl_BulkStartHours" runat="server" class="form-control">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                    <asp:DropDownList ID="ddl_BulkStartMins" runat="server" class="form-control">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                </asp:DropDownList>
                        </div>
                    <div class="col-lg-3">
                    <asp:DropDownList ID="ddl_BulkStartAmPm" runat="server" class="form-control">
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                </asp:DropDownList> 
                        </div>
                 </div>
            </div>

 <div class="col-md-6" >
      
     <div class="form-group">
               <label for="inputcmp" class="col-sm-3 control-label">Cut Off Time:</label>
            
                <div class="col-lg-3">
                 <asp:DropDownList ID="ddl_BulkEndHours" runat="server" class="form-control">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                    </div>
             <div class="col-lg-3">
            <asp:DropDownList ID="ddl_BulkEndMins" runat="server" class="form-control">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                </asp:DropDownList>
                 </div>
                  <div class="col-lg-3">
                 <asp:DropDownList ID="ddl_BulkEndAmPm" runat="server" class="form-control">
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                </asp:DropDownList>
              
                    </div>
                 </div>
            </div><br />
       
         </div>
        </div>
          
       
    
          
          <div class="well well-lg">
          <div class="row">
              
        <div class="col-sm-4 form-group">
              <asp:FileUpload ID="ExcelUpload" class="form-control" ValidationGroup="btn_uploaddd" runat="server" />
            </div>
                                 
        <div class="col-sm-4 form-group">
               <asp:Button ID="btn_UploadAndDisplay" runat="server" Text="Validate"  onclick="btn_UploadAndDisplay_Click1"  class="btn btn-primary"/>
            </div>
                                  
        <div class="col-sm-4 form-group">
           <asp:Button ID="btn_UploadWithMail"  runat="server" ToolTip ="Uploading same indent again after indent uploaded with out sending mail" Text="Upload same indent without mail" OnClick ="btn_UploadWithMail_Click"  class="btn btn-primary"/>
        </div>
        </div>  
              </div>
      </div>
    
  <div class="row" style="display:none;"> 
   <div class="panel panel-primary">
    <div class="panel-heading">
        <h3 class="panel-title">Upload File</h3>
    </div>
    <div class="panel-body">
        <div class="form-horizontal">
    
            <div class="form-group">
                <label class="control-label col-sm-4" for="file">Select File</label>
                <div class="form-group">         
                   <div class="col-sm-6 input-group">
                    <div class="input-group-addon">
                     <i class="fa fa-cloud-upload"></i>
                    </div>
                     <asp:FileUpload ID="FileUpload1" class="form-control" ValidationGroup="btn_uploaddd" runat="server" />                                                             
                   </div>
                </div>                
            </div>

            <div class="form-group">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="control-label col-sm-4" ControlToValidate="FileUpload1" ValidationGroup="btn_uploaddd" runat="server" ErrorMessage="Please Select File"></asp:RequiredFieldValidator>            
            <div class="form-group">
                <div class="col-sm-6 input-group">
                    <div class="input-group-addon">
                     <i class="fa fa-upload"></i>
                    </div>
                     <asp:Button ID="btn_uploads" style="background-color: #001f3f !important;" class="btn btn-labeled btn-success" ValidationGroup="btn_uploaddd" runat="server" Text="Please Validate" OnClick="btn_uploads_Click" />                                                            
                 </div>
               
            </div>
           </div>
            <div class="form-group">
                <div class="col-sm-10">
                    <asp:Label ID="lbl_msg" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>
      </div>               
         
    </div>
      </div>
    <div class="col-sm-12 col-sm-offset-1"> 

<table align="center">
<tr>
<td>
<asp:GridView ID="GridRouteplan" runat="server" BorderColor="#E0E0E0" CellPadding="4" ForeColor="#333333" Width="80%" AutoGenerateColumns="False">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
    <asp:TemplateField HeaderText="All">
                <ItemTemplate>
                    <asp:CheckBox ID="Checkplan" runat="server" AutoPostBack="false" 
                        Checked="true" ForeColor="#CCFFCC" 
                         Text="." Width="25px"  />
                </ItemTemplate>                
                <HeaderTemplate>
                    <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="True" Checked="true" Text="All" oncheckedchanged="ChkAll_CheckedChanged"/>
                </HeaderTemplate>
            </asp:TemplateField>   
                     <asp:TemplateField HeaderText="From">
                        <ItemTemplate>
                            <asp:Label ID="lblfrom" runat="server" ForeColor="Black" 
                                Text='<%# Bind("From") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To">
                        <ItemTemplate>
                            <asp:Label ID="lblTo" runat="server" ForeColor="Black" Text='<%# Bind("To") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>

         <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lblcity" runat="server" ForeColor="Black" Text='<%# Bind("City") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="TravelDate">
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" ForeColor="Black" Text='<%# Bind("TravelDate") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No.ofTrucks">
                        <ItemTemplate>
                            <asp:Label ID="lbltruck" runat="server" ForeColor="Black" Text='<%# Bind("NoofTrucks") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EnclosureType">
                        <ItemTemplate>
                            <asp:Label ID="lblenctype" runat="server" ForeColor="Black" Text='<%# Bind("EnclosureType") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TruckType">
                        <ItemTemplate>
                            <asp:Label ID="lbltrucktype" runat="server" ForeColor="Black" Text='<%# Bind("TruckType") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Capacity">
                        <ItemTemplate>
                            <asp:Label ID="lblcapacity" runat="server" ForeColor="Black" Text='<%# Bind("Capacity") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>    
              <asp:TemplateField HeaderText="TravelType">
                        <ItemTemplate>
                            <asp:Label ID="lbltraveltype" runat="server" ForeColor="Black" Text='<%# Bind("TravelType") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>  
              <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblremarks" runat="server" ForeColor="Black" Text='<%# Bind("Remarks") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>        
            <asp:TemplateField HeaderText="EnclosureID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblEnclosureID" runat="server" ForeColor="Black" Text='<%# Bind("EnclosureTypeID") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="TruckID" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lblTruckID" runat="server" ForeColor="Black" Text='<%# Bind("TruckTypeID") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="TravelID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblTravelID" runat="server" ForeColor="Black" Text='<%# Bind("TravelTypeID") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
    </Columns>
    
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</td>
</tr>
<tr align="center">
<td>
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" onclick="btnsubmit_Click"  class="btn btn-primary"/>
</td>
</tr>
</table>
         <br /><br /><br /><br /><br />
                    </div>
   <div class="container" runat="server" visible="false" id="upload_gid_div">
    <div class="row">
     <%--<div class="col-sm-12 col-sm-offset-1"> --%>
     <div class="col-md-12">
         <div class="panel panel-primary">            
           <div class="panel-heading">
            <h3 class="panel-title">Please Check then upload</h3>
           </div>
            <div class="panel-body table-responsive no-padding">
             <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
              <asp:GridView ID="gv_exceldatadisplay" class="table table-hover" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="4">
               <Columns>
                <asp:TemplateField HeaderText="FromLocation">
                <ItemTemplate>
                    <asp:Label ID="lbl_FromLocation" runat="server" Text='<%# Eval("FromLocation") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ToLocation">
                <ItemTemplate>
                    <asp:Label ID="lbl_ToLocation" runat="server" Text='<%# Eval("ToLocation") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                              
                <asp:TemplateField HeaderText="City">
                <ItemTemplate>
                    <asp:Label ID="lbl_City" runat="server" Text='<%# Eval("City") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TravelDate">
                <ItemTemplate>
                    <asp:Label ID="lbl_TravelDate" runat="server" Width="150" Text='<%# Eval("TravelDate") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="NoofTrucks">
                <ItemTemplate>
                    <asp:Label ID="lbl_NoofTrucks" runat="server" Text='<%# Eval("NoofTrucks") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="EnclosureType">
                <ItemTemplate>
                    <asp:Label ID="lbl_EnclosureType" runat="server" Text='<%# Eval("EnclosureType") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TruckType">
                <ItemTemplate>
                    <asp:Label ID="lbl_TruckType" runat="server" Width="150" Text='<%# Eval("TruckType") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Capacity">
                <ItemTemplate>
                    <asp:Label ID="lbl_Capacity" runat="server" Width="150" Text='<%# Eval("Capacity") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TravelType">
                <ItemTemplate>
                    <asp:Label ID="lbl_TravelType" runat="server" Width="150" Text='<%# Eval("TravelType") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <asp:Label ID="lbl_Remarks" runat="server" Width="150" Text='<%# Eval("Remarks") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>                      
            </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
              </asp:GridView>
             </asp:Panel>              
            </div>
            <!-- /.box-body -->
              
          </div>
        </div>
    <%--</div>--%>
    </div>
   </div>
    </div>
             </div>
        </div>
            </div>
       </div>   
         </div>   
</asp:Content>

