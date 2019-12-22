<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Detailed_Report.aspx.cs" Inherits="Detailed_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
    <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico" />
    <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <%-- <script src="http://code.jquery.com/jquery-latest.js"></script>--%>
    <script src="bokking_date_time_picker/js/jquery-ui.min.js"></script>
    <script src="bokking_date_time_picker/js/jquery-ui.js"></script>
     <link href="plugins/timepicker/bootstrap-timepicker.min.css" rel="stylesheet" />
            <link href="plugins/timepicker/bootstrap-timepicker.css" rel="stylesheet" />
                <script src="plugins/timepicker/bootstrap-timepicker.js"></script>
    <script src="bokking_date_time_picker/src/jquery-ui-timepicker-addon.js"></script>
  <%--  <script src="bokking_date_time_picker/dist/i18n/jquery-ui-timepicker-addon-i18n.min.js"></script>--%>
    <script src="bokking_date_time_picker/dist/i18n/jquery-ui-timepicker-addon.min.js"></script>
    <script src="bokking_date_time_picker/js/jquery-1.11.1.min.js"></script>
    <script src="bokking_date_time_picker/dist/jquery-ui-sliderAccess.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
     <script src="JSP/jquery.1.4.2.js"  type="text/javascript" ></script>
    
    <link href="css/TimeCalendar.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <link href="uploadify.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.uploadify.js" type="text/javascript"></script>
    <div class="container master-container" style="padding-top: 66px; margin-left: 100px;">
        <div class="panel panel-info">
            <div class="panel-heading" align="center" style="padding: 5px;">
                <h4>Detailed Report</h4>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                         <div class="form-group">
                        <label for="lblfrom" class="col-sm-3 control-label">From:</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_datefrom" runat="server" placeholder="MM/DD/YYYY" class="form-control"></asp:TextBox>
                       <%-- <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txt_datefrom">  </ajaxtoolkit:calendarextender>--%>
                        </div>
                    </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                        <label for="lblto" class="col-sm-3 control-label">To:</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_dateto" runat="server" placeholder="MM/DD/YYYY" class="form-control"></asp:TextBox>
                        <%--<asp:ImageButton ID="imgdate2" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" 
                    PopupButtonID="imgdate2" TargetControlID="txt_dateto">  </ajaxtoolkit:calendarextender>--%>
                        </div>
                    </div>
                        
                    </div>

                    <div class="col-md-4">
                        <%--<asp:LinkButton ID="btn_delivery" runat="server" CssClass="btn btn-success"><span class="fa fa-bar-chart" aria-hidden="true"></span>&nbsp;Report</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success"><span class="fa fa-bar-chart" aria-hidden="true"></span>&nbsp;All Report</asp:LinkButton>--%>
                        
                            <asp:LinkButton ID="btn_search" runat="server" CssClass="btn btn-success" OnClick="btn_search_Click" ><span class="fa fa-search" aria-hidden="true"></span>&nbsp;Search</asp:LinkButton>
                        
                     
                    </div>

                </div>
                <br />
                <br />
                <div class="col-md-2 pull-right">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success " OnClick="LinkButton1_Click"><span class="fa fa-bar-chart" aria-hidden="true"></span>&nbsp;All Report Download</asp:LinkButton>
                        </div><br /><br />
                <div class="col-lg-12 ">

                     

                    <div class="table-responsive">
                        <asp:GridView ID="gv_detailed" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="Date" EmptyDataText="There are no data records to display.">
                            <Columns>
                                <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
                                <asp:BoundField DataField="Source" HeaderText="Source" SortExpression="Source" />
                                <asp:BoundField DataField="Destination" HeaderText="Destination" SortExpression="Destination" />
                                <asp:BoundField DataField="TransporterName" HeaderText="TransporterName" SortExpression="TransporterName" />
                                <asp:BoundField DataField="AssignedDateTime" HeaderText="Assigned Date & Time" SortExpression="AssignedDateTime" />
                                <asp:BoundField DataField="Confirmdatetime" HeaderText="Confirm Date & Time" SortExpression="Confirmdatetime" />
                                <asp:BoundField DataField="Reportingdatetime" HeaderText="Reporting Date & Time" SortExpression="Reportingdatetime" />
                                <asp:BoundField DataField="loadingdate" HeaderText="Loading Date & Time" SortExpression="loadingdate" />
                                <asp:BoundField DataField="Dispatcheddatetime" HeaderText="Dispatched Date & Time" SortExpression="Dispatcheddatetime" />
                                <asp:BoundField DataField="LRNumber" HeaderText="LR Number" SortExpression="LRNumber" />
                                <asp:BoundField DataField="Weight" HeaderText="Goods Desc" SortExpression="Weight" />
                                <asp:BoundField DataField="Deliverydate" HeaderText="Expected Delivery Date" SortExpression="Deliverydate" />
                                <asp:BoundField DataField="UnloadingDate" HeaderText="Unloading Date & Time" SortExpression="UnloadingDate" />
                                <asp:BoundField DataField="DelayDays" HeaderText="Delay Days" SortExpression="Delay Days" />
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>

    </div>




    <%--<div class="panel panel-info">
             <div class="panel-body">
                <div class="col-lg-12 ">
                   
                    <div class="table-responsive">
                        <asp:GridView ID="gridview_details" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="Date" EmptyDataText="There are no data records to display." >
                            <Columns>
                                <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
                                <asp:BoundField DataField="Source" HeaderText="Source" SortExpression="Source" />
                                <asp:BoundField DataField="Destination" HeaderText="Destination" SortExpression="Destination" />
                                <asp:BoundField DataField="AssignedDateTime" HeaderText="Assigned Date & Time" SortExpression="AssignedDateTime" />
                                <asp:BoundField DataField="Confirmdatetime" HeaderText="Confirm Date & Time" SortExpression="Confirmdatetime" />
                                <asp:BoundField DataField="Reportingdatetime" HeaderText="Reporting Date & Time" SortExpression="Reportingdatetime" />
                                <asp:BoundField DataField="loadingdate" HeaderText="Loading Date" SortExpression="loadingdate" />
                                <asp:BoundField DataField="Dispatcheddatetime" HeaderText="Dispatched Date & Time" SortExpression="Dispatcheddatetime" />
                                <asp:BoundField DataField="LRNumber" HeaderText="LR Number" SortExpression="LRNumber" />
                                <asp:BoundField DataField="Capacity" HeaderText="Capacity" SortExpression="Capacity" />
                                <asp:BoundField DataField="Deliverydate" HeaderText="Delivery Date" SortExpression="Deliverydate" />
                                <asp:BoundField DataField="unloadingdatetime" HeaderText="Unloading Date & Time" SortExpression="unloadingdatetime" />
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                            </Columns>
                        </asp:GridView>
                        </div>
                    </div>
                 </div>
        </div>--%>

      
       <<%--<%--script>
           $(document).ready(function () {
               $('#<%=txt_dateto.ClientID%>').datetimepicker({
                  controlType: 'select',
                  oneLine: true,
                  timeFormat: 'hh:mm:tt'

              });
          });
    </script>
    <script>
        $(document).ready(function () {
            $('#<%=txt_datefrom.ClientID%>').datetimepicker({
                   controlType: 'select',
                   oneLine: true,
                    timeFormat: 'hh:mm:tt'

               });
           });
    </script>--%>


</asp:Content>

