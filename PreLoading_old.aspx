<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage2.master" AutoEventWireup="true" CodeFile="PreLoading_old.aspx.cs" Inherits="PreLoading"  %>
<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagName="Navihome" TagPrefix="Uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <script src="http://code.jquery.com/jquery-latest.js"></script>
<script type='text/javascript'>
    $(function () {
        // To disable f5
        $(document).bind("keydown", disableF5);
    });

    //Function to handle disabling F5
    function disableF5(e) {
        if ((e.which || e.keyCode) == 116)
            e.preventDefault();
    };


    function dt(sender, args) {
        var calendarBehavior1 = $('#<%=Gridwindow.ClientID %>').find("releasecalendar");

         var hours = new Date().getHours();
         var minutes = new Date().getMinutes();
         var suffix;
         if (hours >= 12 && hours < 24) {
             suffix = "PM";
         }
         else {
             suffix = "AM";
         }
         hours = ((hours + 11) % 12 + 1);

         if (hours <= 9) {
             hours = '0' + hours;
         }
         if (minutes <= 9) {
             minutes = '0' + minutes;
         }
         // set the date back to the current date
         sender._textbox.set_Value(sender._selectedDate.format(sender._format) + " " + hours + ":" + minutes + " " + suffix)
     }


</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <Uc4:Navihome ID="navihome1" runat="server" />
 <br />
 <br />
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
 <br />
    ProjectNo : <asp:DropDownList ID="ddl_ProjectNo" runat="server" Height="20px" AutoPostBack ="true"  OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged" Width="104px"></asp:DropDownList>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    WBSNo : <asp:DropDownList ID="ddl_Wbsno" runat="server" Height="20px" Width="91px" AppendDataBoundItems="True"  >
        <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList>
    &nbsp;&nbsp;
    <asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search" />
    <br />
    <br />
   
     Filter by confirmation date
   <table>
        <tr>
            <td>
                From: 
            </td>
            <td>
                 <asp:TextBox ID="txtFromDate" runat="server" ></asp:TextBox>
                <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txtFromDate">
 </ajaxToolkit:CalendarExtender>
            </td>
            <td>
                To:
            </td>
            <td>
                 <asp:TextBox ID="txtToDate" runat="server" ></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtToDate">
 </ajaxToolkit:CalendarExtender>
            </td>
           
            <td>
                   <asp:Button ID="btnsubmit" runat="server" Text="Search" OnClick="btnsubmit_Click"/>
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Download To Excel" 
            onclick="Button2_Click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"  OnRowCreated ="Gridwindow_RowCreated" 
             EnableModelValidation="True" BorderStyle="None"> 
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>

                  <asp:BoundField HeaderText ="Confirm No" DataField ="AcceptanceID" />
                  <asp:BoundField HeaderText ="ConfirmDate" DataField ="ConfirmDate" />
                  <asp:BoundField HeaderText ="Project No" DataField ="ProjectNo" />
                  <asp:BoundField HeaderText ="WBS No" DataField ="WBSNo" />
                  <asp:BoundField HeaderText ="CN No" DataField ="CollectionNoteNumber" />
                  <asp:BoundField HeaderText ="FromLocation" DataField ="FromLocation" />
                  <asp:BoundField HeaderText ="ToLocation" DataField ="ToLocation" />
                  <asp:BoundField HeaderText ="TruckType" DataField ="TruckType" />
                  <asp:BoundField HeaderText ="Truck Requirement Date" DataField ="TravelDate" />
                  <asp:BoundField HeaderText ="Transporter" DataField ="Transporter" />
                  <asp:BoundField HeaderText ="VehicleNo" DataField ="VehicleNo" />
                  <asp:BoundField HeaderText ="Driver" DataField ="DriverName" />
                  <asp:BoundField HeaderText ="MobileNo" DataField ="mobileNo" />
                  <asp:BoundField HeaderText ="Buyer" DataField ="Buyer" />

                  <%--<asp:TemplateField HeaderText="Confirm No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Confirm Date" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblcdate" runat="server" Text='<%# Bind("ConfirmDate") %>'></asp:Label>
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
                   <asp:TemplateField HeaderText="Reporting Datetime" Visible ="false" >
                      <ItemTemplate>
                          <asp:TextBox ID="txtReportTime" runat="server" Width="130px" ></asp:TextBox>
                            <asp:ImageButton ID="reportimg" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                           <ajaxtoolkit:calendarextender ID="Reporttimecalendar" runat="server"  OnClientDateSelectionChanged ="dt" 
                    PopupButtonID="reportimg" TargetControlID="txtReportTime">  </ajaxtoolkit:calendarextender>
                      </ItemTemplate>
                  </asp:TemplateField>
                     <asp:TemplateField HeaderText="Vehicle Loading DateTime" Visible ="false" >
                     <ItemTemplate> 
                      <asp:TextBox ID="lblLoadingDate" runat="server" Width="130px" ></asp:TextBox>
                         <asp:ImageButton ID="loadingimg" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                           <ajaxtoolkit:calendarextender ID="loadingcalendar" runat="server" OnClientDateSelectionChanged ="dt"  
                    PopupButtonID="loadingimg" TargetControlID="lblLoadingDate">  </ajaxtoolkit:calendarextender>
      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="LoadingTime" Visible="false">
                      <ItemTemplate>
                          <asp:TextBox ID="txtLoadingTime" runat="server" Width="150px" Text="0"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Vehicle Release DateTime" Visible ="false" >
                      <ItemTemplate>
                          <asp:TextBox ID="txtTripTime" runat="server" Width="130px" ></asp:TextBox>
                           <asp:ImageButton ID="releaseimg" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                           <ajaxtoolkit:calendarextender ID="releasecalendar" runat="server"   Enabled ="true" OnClientDateSelectionChanged ="dt"  
                    PopupButtonID="releaseimg" TargetControlID="txtTripTime">  </ajaxtoolkit:calendarextender>
                      </ItemTemplate>
                  </asp:TemplateField>
                      <asp:TemplateField HeaderText="TotalWt in Tons" Visible ="false"   >
                      <ItemTemplate>
                          <asp:TextBox ID="txtweight" runat="server" Width="41px" onkeypress="return onlynumberwithDecimals(event)" ></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="ERoad Permit No./Way Bill No" Visible ="false" >
                      <ItemTemplate>
                            <asp:TextBox ID="TxtEroadNo" runat="server" Width="70px" Text="0"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="LR No." Visible ="false" >
                      <ItemTemplate>
                            <asp:TextBox ID="TxtLRno" runat="server" Width="91px"></asp:TextBox>
                            LR Copy[scanned]
                            <asp:FileUpload ID="LRnoUpload" runat="server" EnableViewState="False"   />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Vehicle Image" Visible ="false" >
                      <ItemTemplate>
                      </ItemTemplate>
                  </asp:TemplateField>
        <asp:TemplateField HeaderText="Speedometer Reading" Visible ="false" >
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
                  <asp:TemplateField HeaderText="Expected DeliveryDate" Visible ="false" >
                      <ItemTemplate>
                             <asp:TextBox ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="71px"></asp:TextBox>
                                                                      <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="lblDeliverydate">  </ajaxtoolkit:calendarextender>
                               <asp:Button ID="ButSubmit" runat="server" Text="Submit" onclick="ButSubmit_Click" />
                                   <asp:Label ID="lblAgreementRouteID" runat="server" Text='<%# Bind("AgreementRouteID") %>' ForeColor="White"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                 <asp:TemplateField HeaderText="Update Info">
<ItemTemplate>
<asp:HyperLink ID="lnledit" runat="server" Text="Update" NavigateUrl=<%# String.Format("javascript:void(window.open('UpdatePreloading.aspx?AcptID={0}',null,'right=362px, top=134px, width=1400px, height=1000px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("AcceptanceID")) %>></asp:HyperLink>
</ItemTemplate>
</asp:TemplateField>
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
</asp:Content>

