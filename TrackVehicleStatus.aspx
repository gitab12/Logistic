<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrackVehicleStatus.aspx.cs" Inherits="TrackVehicleStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta charset="utf-8" />
   <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" rel="stylesheet" />
   
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
            <br />
            <div class="row">
                 <asp:HiddenField ID="hf_startvalue" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hf_endvalue" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hf_track_no" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hf_gpsno" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hf_waypoints" runat="server"></asp:HiddenField>
             <div class="col-md-4">
                      <div id ="directionpanel"  style="height:500px;overflow: auto" ></div>
                    </div>
                    <div class="col-md-8 ">
                       <asp:Label ID="lbl_Live_Tracking_of" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Green" Text=""></asp:Label> <br /><br />
                       <div id ="map" style="height:480px; width:754px"></div> 
                    </div>
               
    
               
            </div>
        <br />
        <div class="row">
               <div class="col-md-3" ></div>
              <div class="col-md-9" >
                <div class="form-group">
              <asp:Label ID="lbl_address" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Green" Text=""></asp:Label>
                    </div>
                 
              </div>
            </div> 
        <div>
            <br />
           <div class="col-md-4" ></div>
              <div class="col-md-8" >
            <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns ="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" EnableModelValidation="True">
                 <Columns>
                     <asp:TemplateField HeaderText ="Source">
                         <ItemTemplate>
                            <asp:Label ID="lbl_source" runat="server"  Text='<%# Bind("source") %>' ForeColor="Black"  ></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText ="Destination">
                         <ItemTemplate>
                            <asp:Label ID="lbl_dest" runat="server"  Text='<%# Bind("destination") %>'  ForeColor="Black"  ></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText ="Device Number">
                         <ItemTemplate>
                            <asp:Label ID="lbl_no" runat="server"  Text='<%# Bind("sim_no") %>' ForeColor="Black"  ></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText ="Device Number" Visible="false">
                         <ItemTemplate>
                            <asp:Label ID="lbl_no1" runat="server"  Text='<%# Bind("DestinationLatLng") %>' ForeColor="Black"  ></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                 </Columns>
                 <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                 <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                 <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                 <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                 <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
                  </div>
        </div>
        </div>
    </form>
</body>
     <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCagf7QcmHfe9JEzLVRHrav2xyHnx7GPmQ&sensor=false"></script>
    <script language="javascript" type="text/javascript">
        var directionsDisplay;
        var directionsService = new google.maps.DirectionsService();

        function InitializeMap() {
            directionsDisplay = new google.maps.DirectionsRenderer();
            var latlng = new google.maps.LatLng(-34.397, 150.644);
            var myOptions =
        {
            zoom: 8,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
            var map = new google.maps.Map(document.getElementById("map"), myOptions);

            directionsDisplay.setMap(map);
            //calcRoute();
            calculateAndDisplayRoute(directionsService, directionsDisplay);

        }



        function calcRoute() {

            var start = document.getElementById('<%=hf_startvalue.ClientID%>').value;
            var end = document.getElementById('<%=hf_endvalue.ClientID%>').value;
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
        function calculateAndDisplayRoute(directionsService, directionsDisplay) {
            var _start = document.getElementById('<%=hf_startvalue.ClientID%>').value;
            var _end = document.getElementById('<%=hf_endvalue.ClientID%>').value;
            var waypts = [];
            var checkboxArray = document.getElementById('<%=hf_waypoints.ClientID%>').value;
            waypts.push({
                location: checkboxArray, //checkboxArray[i].value,
                stopover: true
            });

            directionsService.route({
                origin: _start,
                destination: _end,
                waypoints: waypts,
                optimizeWaypoints: true,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                    var route = response.routes[0];
                    //var summaryPanel = document.getElementById('directions-panel');
                    directionsDisplay.setPanel(document.getElementById('directionpanel'));

                    var control = document.getElementById('control');
                    control.style.display = 'block';

                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
        window.onload = InitializeMap;
    </script>
</html>
