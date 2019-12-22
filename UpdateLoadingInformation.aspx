<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateLoadingInformation.aspx.cs" Inherits="UpdateLoadingInformation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br /><br />
    <div class="col-sm-7 col-sm-offset-3">
			<h2 class="title-one">Update PreLoading</h2>
        </div>
       <script src="JSP/jquery.1.4.2.js" type="text/javascript"></script>
  <link rel="Stylesheet" href="css/TimeCalendar.css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <br />
    <br />
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
       <asp:Panel ID="Panel1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Font-Bold="false" Height ="210px" ScrollBars="Auto" Width="50%" GroupingText="" Style="margin-left:10px">

    <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" OnRowCreated ="Gridwindow_RowCreated"  
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" >
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField HeaderText="Preload ID" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblPLid" runat="server" Text='<%# Bind("PLid") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Confirm No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                    <asp:TemplateField HeaderText="ProjectNo"  >
                      <ItemTemplate>
                          <asp:Label ID="lbl_ProjectNo" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                    <asp:TemplateField HeaderText="WBSNo"  >
                      <ItemTemplate>
                          <asp:Label ID="lbl_Wbsno" runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
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
                  
               <asp:TemplateField HeaderText="TruckType">
                      <ItemTemplate>
                          <asp:Label ID="lblTruckType" runat="server" Text='<%# Bind("TruckType") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>        
                          
                  <asp:TemplateField HeaderText="VehicleNo">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="lblVehicleno" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Driver">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DriverName") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="lblDriver" runat="server" Text='<%# Bind("DriverName") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="MobileNo">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("mobileNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="lblMobile" runat="server" Text='<%# Bind("mobileNo") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Reporting Datetime">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Reportdate") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtReportTime" runat="server" Width="205px"  class="TimeCalendar"  Text='<%# Bind("ReportDate") %>'></asp:TextBox>
                        
 <script type="text/javascript">
     $(document).ready(function () {
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
                     <EditItemTemplate>
                          <asp:TextBox ID="txtloadingdate" runat="server" Text=''></asp:TextBox>
                      </EditItemTemplate>
                     <ItemTemplate> 
                      <asp:TextBox ID="lblLoadingDate" runat="server" Width="156px" class="TimeCalendar" Text='<%# Bind("LoadingDate") %>'></asp:TextBox>

 <script type="text/javascript">
     $(document).ready(function () {
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
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("LoadingTime") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtLoadingTime" runat="server" Width="56px" Text="0"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Vehicle Release DateTime">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TripTime") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtTripTime" runat="server" class="TimeCalendar" Width="156px"  Text='<%# Bind("ReleaseDate") %>'></asp:TextBox>
 <script type="text/javascript">
     $(document).ready(function () {
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
                  
                      <asp:TemplateField HeaderText="TotalWt in Tons">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("weight") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtweight" runat="server" Width="41px" onkeypress="return onlynumberwithDecimals(event)" Text='<%# Bind("TotalWeight") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="ERoad Permit No./Way Bill No">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("[ERoadNo]") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                            <asp:TextBox ID="TxtEroadNo" runat="server" Width="70px" Text='<%# Bind("ERoadNo") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>       
                  
                  <asp:TemplateField HeaderText="LRNo">
                      <EditItemTemplate>
                          <asp:TextBox ID="LRNo" runat="server" Text='<%# Bind("[LRNumber]") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                            <asp:TextBox ID="txt_LRNo" runat="server" Width="70px" Text='<%# Bind("LRNumber") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>               
                  
                  <asp:TemplateField HeaderText="Vehicle Image">
                      <ItemTemplate>                        
                          <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="False"   />                     
                      </ItemTemplate>                     
                  </asp:TemplateField>        
                         
                  <asp:TemplateField HeaderText="DeliveryDate">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                             <asp:TextBox ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="71px"></asp:TextBox>
                                                                      <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="lblDeliverydate">  </ajaxtoolkit:calendarextender>
                             
                             <%--      <asp:Label ID="lblAgreementRouteID" runat="server" Text='<%# Bind("AgreementRouteID") %>' ForeColor="White"></asp:Label>--%>
                      </ItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Update Info">
                      <ItemTemplate>                        
                         <asp:Button ID="Btnupdate" runat="server" Text="Update" onclick="Btnupdate_Click" />                  
                      </ItemTemplate>                     
                  </asp:TemplateField> 

              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />

         <AlternatingRowStyle BackColor="White" />
        <EmptyDataTemplate >
          <center>  <asp:Label ID ="lbl_Msg" runat ="server" ForeColor ="Red" Font-Bold ="true" Text ="Already Updated" ></asp:Label></center>
        </EmptyDataTemplate>
          </asp:GridView>
   
           <script type="text/javascript" src="JSP/TimeCalendar.js"></script>
             </asp:Panel>
    <br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>




