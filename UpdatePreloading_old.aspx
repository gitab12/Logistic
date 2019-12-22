<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage2.master" AutoEventWireup="true" CodeFile="UpdatePreloading_old.aspx.cs" Inherits="UpdatePreloading" %>
<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagName="Navihome" TagPrefix="Uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
   <%-- <script src="http://code.jquery.com/jquery-latest.js"></script>--%>
<script type='text/javascript'>
    $(function () {
        // To disable f5
        $(document).bind("keydown", disableF5);
    });

    //Function to handle disabling F5
    function disableF5(e) {
        if ((e.which || e.keyCode) == 116)
            //alert("shyam");
            //window.open("http://viralpatel.net/blogs/", "mywindow", "status=1,toolbar=0");
            e.preventDefault();
    };
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <Uc4:Navihome ID="navihome1" runat="server" />
 <script src="JSP/jquery.1.4.2.js" type="text/javascript"></script>
  <link rel="Stylesheet" href="css/TimeCalendar.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <link href="uploadify.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.uploadify.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $('#<%=Gridwindow.ClientID %>').find('input:file[ID$="FileUpload1"]').uploadify({

                'swf': 'uploadify.swf',
                'uploader': 'Handler.ashx',
                'cancelImg': 'cancel.png',
                'buttonText': 'Select Files',
                'fileDesc': 'Image Files',
                'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
                'multi': true,
                'auto': true
            });

        })
    </script>
 
    
 <br />
 <br />
    <asp:ScriptManager ID ="Scriptmanager1" runat ="server" ></asp:ScriptManager>
    <br />
    <br />
     
    <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False"  OnRowCreated ="Gridwindow_RowCreated" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None">
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField HeaderText="Confirm No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                      </ItemTemplate>
                   
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Project No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="WBS No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblWBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="CN No"  >
                      <ItemTemplate>
                          <asp:Label ID="lbl_CNNo" runat="server" Text='<%# Bind("CollectionNoteNumber") %>'></asp:Label>
                         
                      </ItemTemplate>
                     
                  </asp:TemplateField>
                  

                  <asp:TemplateField HeaderText="From Location">
                      <ItemTemplate>
                          <asp:Label ID="lblFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="To Location">
                      <ItemTemplate>
                          <asp:Label ID="lbltoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                 
                   <asp:TemplateField HeaderText="Truck Type" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblTruck" runat="server" Text='<%# Bind("TruckType") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                    <asp:TemplateField HeaderText="Truck Requirement Date">
                      <ItemTemplate>
                          <asp:Label ID="lbldate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Transporter">
                      <ItemTemplate>
                          <asp:Label ID="lblTransporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                          <asp:TemplateField HeaderText="ClientID" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                       <asp:TemplateField HeaderText="ClientAdrID" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblclientadrID" runat="server" Text='<%# Bind("ClientAddressLocationID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
         
                  <asp:TemplateField HeaderText="VehicleNo">
                      <ItemTemplate>
                          <asp:Label ID="lblVehicleno" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Driver">
                      
                      <ItemTemplate>
                          <asp:Label ID="lblDriver" runat="server" Text='<%# Bind("DriverName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="MobileNo">
                      <ItemTemplate>
                          <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("mobileNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Buyer">
                    
                      <ItemTemplate>
                          <asp:Label ID="lblBuyer" runat="server" Text='<%# Bind("Buyer") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Reporting Datetime">
                      <ItemTemplate>
                          <asp:TextBox ID="txtReportTime" runat="server" Width="130px" class="TimeCalendar" ></asp:TextBox>
                           <%-- <asp:ImageButton ID="reportimg" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                           <ajaxtoolkit:calendarextender ID="Reporttimecalendar" runat="server"  OnClientDateSelectionChanged ="dt" 
                    PopupButtonID="reportimg" TargetControlID="txtReportTime">  </ajaxtoolkit:calendarextender>--%>
                          
 <script type="text/javascript">
     $(document).ready(function() {
         var dt1 = $("#txtTripTime");

         //These are all the options

         dt1.attr("minimumDate", "1 Jan 2010 10:04 am");
         dt1.attr("maximumDate", "1 Apr 2010 10:04 am");
         dt1.attr("showTime", true);
         dt1.attr("imagePath", "images/"); // The images have been copied to this folder to show how this option works
     });
    </script>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                     <asp:TemplateField HeaderText="Vehicle Loading DateTime">
                     <ItemTemplate> 
                      <asp:TextBox ID="lblLoadingDate" runat="server" Width="130px" class="TimeCalendar" ></asp:TextBox>
                          
 <script type="text/javascript">
     $(document).ready(function() {
         var dt1 = $("#txtTripTime");

         //These are all the options

         dt1.attr("minimumDate", "1 Jan 2010 10:04 am");
         dt1.attr("maximumDate", "1 Apr 2010 10:04 am");
         dt1.attr("showTime", true);
         dt1.attr("imagePath", "images/"); // The images have been copied to this folder to show how this option works
     });
    </script>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="LoadingTime" Visible="false">
                      <ItemTemplate>
                          <asp:TextBox ID="txtLoadingTime" runat="server" Width="150px" Text="0"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Vehicle Release DateTime">
                      <ItemTemplate>
                          <asp:TextBox ID="txtTripTime" runat="server" Width="130px" class="TimeCalendar" ></asp:TextBox>

                          <%-- <asp:ImageButton ID="releaseimg" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                           <ajaxtoolkit:calendarextender ID="releasecalendar" runat="server"   Enabled ="true" OnClientDateSelectionChanged ="dt"  
                    PopupButtonID="releaseimg" TargetControlID="txtTripTime">  </ajaxtoolkit:calendarextender>
                          --%>
 <script type="text/javascript">
     $(document).ready(function() {
     var dt1 = $("#txtTripTime");

         //These are all the options
        
        dt1.attr("minimumDate", "1 Jan 2010 10:04 am");
        dt1.attr("maximumDate", "1 Apr 2010 10:04 am");
        dt1.attr("showTime", true );
        dt1.attr("imagePath", "images/"); // The images have been copied to this folder to show how this option works
     });
    </script>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                      <asp:TemplateField HeaderText="TotalWt in Tons">
                      <ItemTemplate>
                          <asp:TextBox ID="txtweight" runat="server" Width="41px" onkeypress="return onlynumberwithDecimals(event)" Text ="0" ></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="ERoad Permit No./Way Bill No">
                      <ItemTemplate>
                            <asp:TextBox ID="TxtEroadNo" runat="server" Width="70px" Text="0"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="LR No.">
                      <ItemTemplate>
                            <asp:TextBox ID="TxtLRno" runat="server" Width="91px"></asp:TextBox>
                            LR Copy[scanned]
                            <asp:FileUpload ID="LRnoUpload" runat="server" EnableViewState="False"   />
                      </ItemTemplate>
                  </asp:TemplateField>
       
                  <asp:TemplateField HeaderText="Vehicle Image">
                      <ItemTemplate>
                          <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="False"   />
                      </ItemTemplate>
                  </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Speedometer Reading">
                      <ItemTemplate>
                          <asp:TextBox ID="txt_SpeedoMeter" runat="server" Width="60px" onkeypress="return onlynumber(event)" Text ="0" ></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Transit Days"  Visible="false">
                      <ItemTemplate>
                        <asp:Label ID="lblTransitDay" runat="server" Text='<%# Bind("Transitday") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText ="AgreedPrice" Visible ="false" >
                      <ItemTemplate >
                          <asp:Label ID="lblAgreedPrice" runat="server" Text='<%# Bind("AgreedPrice") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Expected DeliveryDate">
                      <ItemTemplate>
                             <asp:TextBox ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="71px"></asp:TextBox>
                                                                      <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="lblDeliverydate">  </ajaxtoolkit:calendarextender>
                               
                                   <asp:Label ID="lblAgreementRouteID" runat="server" Text='<%# Bind("AgreementRouteID") %>' ForeColor="White"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  
                  <asp:TemplateField HeaderText ="Submit"  >
                      <ItemTemplate >
                          <asp:Button ID="ButSubmit" runat="server" Text="Submit" onclick="ButSubmit_Click" />
                      </ItemTemplate>
                  </asp:TemplateField>

                 
                
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
        <EmptyDataTemplate >
          <center>  <asp:Label ID ="lbl_Msg" runat ="server" ForeColor ="Red" Font-Bold ="true" Text ="Plan already updated" ></asp:Label></center>
        </EmptyDataTemplate>
          </asp:GridView>

          <script type="text/javascript" src="JSP/TimeCalendar.js"></script>
   

</asp:Content>

