<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="UpdatePreloading.aspx.cs" Inherits="UpdatePreloading" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
    <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico" />
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
        jQuery(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_Gridwindow_ctl02_ddl_senderno").change(function () {
                $.ajax({
                    url: '<%=ResolveUrl("UpdatePreloading.aspx/Getcurrentlocation") %>',
                    data: "{ 'TrackNo': '" + $("#ctl00_ContentPlaceHolder1_Gridwindow_ctl02_ddl_senderno option:selected").val() + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //alert(data.d);
                        calc(data.d);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });

                function calc(res) {

                    var splited = res.split('+', 13);



                    if (parseInt(splited[4]) < 40) {
                        if (confirm('Battery Percentage is Less than 40%, Do want to still create plan ?')) {
                            alert('Thank You For confirmation !!!');
                            $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("YES");
                        }
                        else {
                            alert('select another TrackNo');
                            $("#ctl00_ContentPlaceHolder1_Gridwindow_ctl02_ddl_senderno").val("0");
                            $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("No");
                        }
                    }
                    else {
                        $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("YES");
                        alert('Battery :' + splited[4] + '  (%)');

                    }

                }



                //    $("#ctl00_ContentPlaceHolder1_Gridwindow_ctl02_ddl_senderno").change(function () {

                //        $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("No");
                //        var value = $("#ctl00_ContentPlaceHolder1_Gridwindow_ctl02_ddl_senderno option:selected").val();
                //        var splited = value.split(',', 5);
                //        var battery = splited[1];
                //        //alert(value);
                //        $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("YES");
                //        if (parseInt(battery) < 40) {            
                //            if (confirm('Battery Percentage is Less than 40%, Do want to still create plan ?'))
                //            {                   
                //                alert('Thank You For confirmation !!!');
                //                $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("YES");
                //            }
                //            else {
                //                alert('select another TrackNo');
                //                $("#ctl00_ContentPlaceHolder1_Gridwindow_ctl02_ddl_senderno").val("0");
                //                $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("No") ;
                //            }
                //        }
                //        var plan = splited[3];
                //        if (parseInt(plan) === 1) {
                //            if (confirm('Plan Existing on Selected TrackNo ,Do You Want To Close ?')) {
                //                alert('Thank You Allowing To Close The Plan !!');
                //                if ($("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val() === "YES")
                //                {
                //                    $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("YES");
                //                }
                //            }
                //            else {
                //                alert('select another TrackNo');
                //                $("#ctl00_ContentPlaceHolder1_Gridwindow_ctl02_ddl_senderno").val("0") ;
                //                $("#ctl00_ContentPlaceHolder1_HiddenField_yesnoforplancreate").val("No");
                //            }
                //        }          
                //    });
            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br /><br/><br/><br/><br/><br />
    <div class="col-sm-11 col-sm-offset-3">
									<h2 class="title-one">Update Loading</h2>
        </div>
<%--   <div style="left:0px">
       
    <uc1:DashboardMenuBar runat="server" ID="DashboardMenuBar" />
    </div>--%>
  
    <script src="JSP/jquery.1.4.2.js"  type="text/javascript" ></script>
    
    <link href="css/TimeCalendar.css" rel="stylesheet" />
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
    <div style="left:0px">
    
    <br />
    <br />
    <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
     <asp:Panel ID="Panel1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Font-Bold="false" Height ="300px" ScrollBars="Both" Width="97%" GroupingText="" Style="margin-left:5px">

    <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" OnRowCreated="Gridwindow_RowCreated"
        CellPadding="4" ForeColor="#333333" Width="70%"
        EnableModelValidation="True" BorderStyle="None">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>

            <asp:TemplateField HeaderText="Confirm No" Visible="true">
                <ItemTemplate>
                    <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Project No" Visible="true">
                <ItemTemplate>
                    <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="WBS No" Visible="true">
                <ItemTemplate>
                    <asp:Label ID="lblWBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CN No">
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

            <asp:TemplateField HeaderText="Truck Type" Visible="true">
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
                    <asp:TextBox ID="txtReportTime" runat="server" Width="130px" class="TimeCalendar" autocomplete="off"></asp:TextBox>
                    <%-- <asp:ImageButton ID="reportimg" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                           <ajaxtoolkit:calendarextender ID="Reporttimecalendar" runat="server"  OnClientDateSelectionChanged ="dt" 
                    PopupButtonID="reportimg" TargetControlID="txtReportTime">  </ajaxtoolkit:calendarextender>--%>

                    <script type="text/javascript">
                        $(document).ready(function () {
                            var dt1 = $("#txtReportTime");

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
                    <asp:TextBox ID="lblLoadingDate" runat="server" Width="130px" class="TimeCalendar" autocomplete="off"></asp:TextBox>

                    <script type="text/javascript">
                        $(document).ready(function () {
                            var dt1 = $("#lblLoadingDate");

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
                    <asp:TextBox ID="txtTripTime" runat="server" Width="130px" class="TimeCalendar" autocomplete="off"></asp:TextBox>

                    <%-- <asp:ImageButton ID="releaseimg" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                           <ajaxtoolkit:calendarextender ID="releasecalendar" runat="server"   Enabled ="true" OnClientDateSelectionChanged ="dt"  
                    PopupButtonID="releaseimg" TargetControlID="txtTripTime">  </ajaxtoolkit:calendarextender>
                    --%>
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
                <ItemTemplate>
                    <asp:TextBox ID="txtweight" runat="server" Width="41px" onkeypress="return onlynumberwithDecimals(event)" Text="0"></asp:TextBox>
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
                            <asp:FileUpload ID="LRnoUpload" runat="server" EnableViewState="False" />
                </ItemTemplate>
            </asp:TemplateField>


           

            <asp:TemplateField HeaderText="Vehicle Image">
                <ItemTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="False" />
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="Speedometer Reading">
                <ItemTemplate>
                    <asp:TextBox ID="txt_SpeedoMeter" runat="server" Width="60px" onkeypress="return onlynumber(event)" Text="0"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
			
			 

            <asp:TemplateField HeaderText="Transit Days" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblTransitDay" runat="server" Text='<%# Bind("Transitday") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="AgreedPrice" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblAgreedPrice" runat="server" Text='<%# Bind("AgreedPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Expected DeliveryDate">
                <ItemTemplate>
                   <asp:TextBox ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="71px"></asp:TextBox>
                                                                      <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="lblDeliverydate">  </ajaxtoolkit:calendarextender>
                    <%-- <script type="text/javascript">
                         $(document).ready(function () {
                             var dt1 = $("#lblDeliverydate");

                             //These are all the options

                             dt1.attr("minimumDate", "1 Jan 2010 10:04 am");
                             dt1.attr("maximumDate", "1 Apr 2010 10:04 am");
                             dt1.attr("showTime", true);
                             dt1.attr("imagePath", "images/"); // The images have been copied to this folder to show how this option works
                         });
                    </script>--%>
                    <asp:Label ID="lblAgreementRouteID" runat="server" Text='<%# Bind("AgreementRouteID") %>' ForeColor="White"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="TrackNo">
                <ItemTemplate>
                    <asp:DropDownList ID="ddl_senderno" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddl_senderno_SelectedIndexChanged" />
                    <asp:Label ID="lbldevmsg" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Submit">
                <ItemTemplate>
                    <asp:Button ID="ButSubmit" runat="server" Text="Submit" OnClick="ButSubmit_Click" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <EmptyDataTemplate>
            <center>
                <asp:Label ID="lbl_Msg" runat="server" ForeColor="Red" Font-Bold="true" Text="Plan already updated"></asp:Label></center>
        </EmptyDataTemplate>
    </asp:GridView>
         </asp:Panel>
        </div>
    <asp:HiddenField ID="HiddenField_yesnoforplancreate" runat="server" />
    <script src="JSP/TimeCalendar.js" type="text/javascript"></script>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

