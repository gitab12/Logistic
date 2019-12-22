<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportPreShipment.aspx.cs" Inherits="ImportExport_ExportPreShipment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <style type ="text/css" >    

        .design {
             background: #ADD8E6;
             padding: 25px;
             border: 2px solid #fff;
             box-shadow: 0px -4px 5px rgba(0,0,0,0.3);
             color: #000;          
             padding-bottom: 15px;
             min-width: 400px;
             min-height: 200px;
             max-height: 550px;
             max-width: 900px;
           
        }



        table.gridtable {
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:Black;
	border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;
}
table.gridtable th {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #dedede;
}
table.gridtable td {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #ffffff;
}



        .txtboxcss
        {
            border-bottom-right-radius: 8em;
            border-top-right-radius: 20px;
            border-bottom-left-radius: 20px;
            border-bottom-right-radius: 20px;
            border: 1px solid gray;
 padding: 1px;
 /*font-size: x-small;*/
     font-family: Tahoma;
     background-color: #ffffff;
        }


         .txtmultilineboxcss
        {
            border-bottom-right-radius: 8em;
            border-top-right-radius: 20px;
            border-bottom-left-radius: 20px;
            border-bottom-right-radius: 20px;
            border: 1px solid gray;
 padding: 1px;
 /*font-size: x-small;*/
 font-size:small;
     font-family: Tahoma;
     background-color: #ffffff;
        }


         .Panel legend
{
color:Maroon;
 font-weight:bold; 
 font-size :15px;
}

         .promotion_btn {
        -moz-box-shadow: inset 0px 1px 0px 0px #efdcfb;
        -webkit-box-shadow: inset 0px 1px 0px 0px #efdcfb;
        box-shadow: inset 0px 1px 0px 0px #efdcfb;
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #FFFFF), color-stop(1, #BCC6CC));
        background: -moz-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: -webkit-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: -o-linear-gradient(top,#FFFFF 5%, #BCC6CC 100%);
        background: -ms-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: linear-gradient(to bottom, #FFFFF 5%, #BCC6CC 100%);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFF', endColorstr='#BCC6CC',GradientType=0);
        background-color: #fff;
        -moz-border-radius: 10px;
        -webkit-border-radius: 10px;
        border-radius: 10px;
        border: 1px solid #c584f3;
        display: inline-block;
        cursor: pointer;
        color: black;
        font-family: arial;
        font-size: 15px;
        font-weight: bold;
        padding: 7px 25px;
        text-decoration: none;
        text-shadow: 0px 1px 0px #9752cc;
    }
    .promotion_btn:hover {
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #BCC6CC), color-stop(1, #FFFFF));
        background: -moz-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -webkit-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -o-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -ms-linear-gradient(top,#FFFFF 5%, #FFFFF 100%);
        background: linear-gradient(to bottom, #FFFFF 5%, #FFFFF 100%);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFF', endColorstr='#FFFFF',GradientType=0);
        background-color: #BCC6CC;
    }
    .promotion_btn:active {
        position: relative;
        top: 1px;
    }
        .Panel {}

        caption {
color: black;
background:lightgray;
 text-align: center;
}
            
        </style>

</head>
<body>

      <script type="text/javascript">
          //Only Numbers
          function onlynumber(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if ((charCode < 48 || charCode > 57) && (charCode != 8))
                  return false;
              return true;
          }
          //only alphabetical with space
          function onlyalphawithspace(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 8) && (charCode != 32))

                  return false;
              return true;
          }


          function ETDDateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_ETD.ClientID  %>').value = "";
                //y.value = "";
            }
        }


        function ETADateValidation(sender, args) {
            var td = new Date();
            td.setMinutes(59);
            td.setSeconds(59);
            td.setHours(23);
            //to move back one day
            td.setDate(td.getDate() - 1);

            if (sender._selectedDate < td) {
                alert("You can't select day from the past! ");
                document.getElementById('<%= txt_ETA.ClientID  %>').value = "";
                //y.value = "";
            }
        }


        function DeliverydateValidation(sender, args) {
            var td = new Date();
            td.setMinutes(59);
            td.setSeconds(59);
            td.setHours(23);
            //to move back one day
            td.setDate(td.getDate() - 1);

            if (sender._selectedDate < td) {
                alert("You can't select day from the past! ");
                document.getElementById('<%= txt_Deliverydate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function InspectionDateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_InspectionDate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function StuffingdateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Stuffingdate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function PreshipmentinvoicedateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Preshipmentinvoicedate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function ETDdetailtocustomeronValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_ETDdetailtocustomeron.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function PreshipmentdocsenttochaonDateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Preshipmentdocsenttochaon.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function ShippingbilldateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Shippingbilldate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function CargohadedovertolineronDateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Cargohadedovertolineron.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function CargoonboardValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Cargoonboard.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function ActialetdValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Actialetd.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
          function COOGSPappliedonValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_COOGSPappliedon.ClientID  %>').value = "";
                  //y.value = "";
              }
          }
        </script>
    <form id="form1" runat="server">
    <div>
    
         <asp:ScriptManager ID ="scriptmanager1" runat ="server"  EnablePartialRendering="true" ></asp:ScriptManager>
    <br /><br /><br />
    <center >  <b style="font-family: Arial;margin-right:600px; font-size: medium; font-weight: bold; font-style: normal; color: #FF0000">Export Pre Shipment</b></center><br />
   
        <table >
            <tr>
                <td>
                    <table align="left" cellpadding="3"  cellspacing="2" >
            <tr>
                <td>Po no</td>
                <td>
                    <asp:DropDownList ID="ddl_PoNo" cssclass="txtboxcss" AutoPostBack ="true"  runat="server" Width="140px" OnSelectedIndexChanged="ddl_PoNo_SelectedIndexChanged" >
                    </asp:DropDownList>
                </td>
                </tr> 
       </table> 
                </td>
            </tr>
            <tr>
                <td>
                     <asp:Panel ID ="pnl_ExportOrder" CssClass="Panel" Visible ="false" runat ="server"  >
         <table align="left" cellpadding="3" class="gridtable" cellspacing="2" >
             <caption class ="caption"><b>Export Po Details</b></caption>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Buyername" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Buyercountry" runat="server" ></asp:Label>
                 </td>

                 <td>
                     <asp:Label ID="lbl_PoNumber" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Podate" runat="server"></asp:Label>
                 </td>

             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Itemdesc" runat="server"></asp:Label></td>
                  <td>  
                       <asp:Label ID="lbl_Quantity" runat="server"></asp:Label> 
                 </td>
                 <td>
                      <asp:Label ID="lbl_Creditterms" runat="server"></asp:Label></td> 
                 <td>
                      <asp:Label ID="lbl_Paymentterms" runat="server"></asp:Label>
                 </td>
                 
             </tr>
             <tr>
               <td> 
                    <asp:Label ID="lbl_Currency" runat="server"></asp:Label>
                 </td> 
                 <td>
                     <asp:Label ID="lbl_Povalue" runat="server"></asp:Label>
                 </td>
                 <td>
                       <asp:Label ID="lbl_Shipmentmode" runat="server"></asp:Label>
                 </td>
                 
                 <td>
                 <asp:Label ID="lbl_Loadingport" runat="server"></asp:Label>
                 </td>
             </tr>

              <tr>
                 
                 <td>
                     <asp:Label ID="lbl_Dischargeport" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Internalworksorder" runat="server"></asp:Label>
                     
                 </td>
                  <td></td>
                  <td></td>
             </tr>

             </table> 
        </asp:Panel> 
                </td>
            </tr>
            <tr>
                <td>

    <asp:Panel ID ="pnl_Preshipment"  GroupingText  ="Pre Shipment" CssClass="Panel" Visible ="false" runat ="server" Width="854px"  >
     <table align="left" cellpadding="3"  cellspacing="2" style="width: 856px" >
            <tr>
                <td>Po no</td>
                <td>
                    <asp:Label ID="lbl_PoNo" runat="server" Text="Label"></asp:Label>
                </td>
                <td valign ="top" >

                    Delivery date</td> 
                <td valign ="top" >

                    <asp:TextBox ID="txt_Deliverydate" cssclass="txtboxcss" runat="server"></asp:TextBox>

                    <asp:ImageButton ID="img_Deliverydate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="cal_Deliverydate" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="DeliverydateValidation"
                                       PopupButtonID="img_Deliverydate" TargetControlID="txt_Deliverydate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Deliverydate" ValidationGroup ="aarms" Display ="None"  runat="server" ControlToValidate ="txt_Deliverydate" ErrorMessage="Select delivery date"></asp:RequiredFieldValidator>

                    </td> 
                </tr> 
            <tr>
                <td>3rd party inspection date</td>
                <td>
                    <asp:TextBox ID="txt_InspectionDate" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_InspectionDate" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="cal_InspectioDate" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="InspectionDateValidation"
                                       PopupButtonID="img_InspectionDate" TargetControlID="txt_InspectionDate"></ajaxtoolkit:calendarextender>

                    <asp:RequiredFieldValidator ID="rfv_Invoicedate" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_InspectionDate" ErrorMessage="Select invoice date"></asp:RequiredFieldValidator>

                </td>
                <td valign="top">Stuffing date</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Stuffingdate"  cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_Stuffingdate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_Stuffingdate" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="StuffingdateValidation"
                                       PopupButtonID="img_Stuffingdate" TargetControlID="txt_Stuffingdate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_BlOrAWBDate11" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_Stuffingdate" ErrorMessage="Select Bl or AWB Date"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" >CHA name</td>
                <td>
                    <asp:TextBox ID="txt_CHAname" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Vesselname" runat="server" ControlToValidate="txt_CHAname" Display="None" ErrorMessage="Enter CHA name" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Freight forwarder name</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Freightforwardername" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Freightforwardername" runat="server" ControlToValidate="txt_Freightforwardername" Display="None" ErrorMessage="Enter Freight forwarder name" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Vehicle no</td>
                <td>
                    <asp:TextBox ID="txt_Vehicleno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Vehicleno" runat="server" ControlToValidate="txt_Vehicleno" Display="None" ErrorMessage="Enter vehicle no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">LOT size </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Lotsize" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">Vessel name</td>
                <td>
                    <asp:TextBox ID="txt_Vesselname" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
                <td valign="top">ETD</td>
                <td valign="top">
                    <asp:TextBox ID="txt_ETD" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_ETD" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_ETD" runat="server" ControlToValidate="txt_ETD" Display="None" ErrorMessage="Select ETD" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">&nbsp;ETA</td>
                <td>
                    <ajaxtoolkit:calendarextender ID="Cal_ETD" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ETDDateValidation"
                                       PopupButtonID="img_ETD" TargetControlID="txt_ETD"></ajaxtoolkit:calendarextender>
                    <asp:TextBox ID="txt_ETA" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_ETA" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_ETA" runat="server" ControlToValidate="txt_ETA" Display="None" ErrorMessage="Enter ETA" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Pre shipment invoice no</td>
                <td valign="top">
                    <ajaxtoolkit:calendarextender ID="Cal_ETA" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ETADateValidation"
                                       PopupButtonID="img_ETA" TargetControlID="txt_ETA"></ajaxtoolkit:calendarextender>
                    <asp:TextBox ID="txt_Preshipmentinvoiceno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_txt_Preshipmentinvoiceno" runat="server" ControlToValidate="txt_Preshipmentinvoiceno" Display="None" ErrorMessage="Enter Pre shipment invoice no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">&nbsp;Pre shipment invoice date</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Preshipmentinvoicedate" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_Preshipmentinvoicedate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_Preshipmentinvoicedate" runat="server" ControlToValidate="txt_Preshipmentinvoicedate" Display="None" ErrorMessage="Select Bl or AWB Date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>Invoice amount</td>
                <td>
                    <ajaxtoolkit:calendarextender ID="Cal_Preshipmentinvoicedate" runat="server" Format ="dd/MM/yyyy"  OnClientDateSelectionChanged="PreshipmentinvoicedateValidation"
                                       PopupButtonID="img_Preshipmentinvoicedate" TargetControlID="txt_Preshipmentinvoicedate"></ajaxtoolkit:calendarextender>
                      <asp:TextBox ID="txt_Invoiceamount" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Invoiceamount" runat="server" ControlToValidate="txt_Invoiceamount" Display="None" ErrorMessage="Enter invoice amount" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Net weight</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Netweight" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
                <td>ETD detail to customer on</td>
                <td>
                    <asp:TextBox ID="txt_ETDdetailtocustomeron" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_ETDdetailtocustomeron" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_ETDdetailtocustomeron" runat="server" ControlToValidate="txt_ETDdetailtocustomeron" Display="None" ErrorMessage="Select ETD detail to customer on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">&nbsp;Pre shipment doc sent to CHA on </td>
                <td valign="top">
                    <ajaxtoolkit:calendarextender ID="Cal_ETDdetailtocustomeron" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ETDdetailtocustomeronValidation"
                                       PopupButtonID="img_ETDdetailtocustomeron" TargetControlID="txt_ETDdetailtocustomeron"></ajaxtoolkit:calendarextender>
                    <asp:TextBox ID="txt_Preshipmentdocsenttochaon" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_Preshipmentdocsenttochaon" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_Preshipmentdocsenttochaon" runat="server" ControlToValidate="txt_Preshipmentdocsenttochaon" Display="None" ErrorMessage="Select Pre shipment doc sent to cha on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>Shipping bill no</td>
                <td>
                    <ajaxtoolkit:calendarextender ID="Cal_Preshipmentdocsenttochaon" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="PreshipmentdocsenttochaonDateValidation"
                                       PopupButtonID="img_Preshipmentdocsenttochaon" TargetControlID="txt_Preshipmentdocsenttochaon"></ajaxtoolkit:calendarextender>
                    <asp:TextBox ID="txt_Shippingbillno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">&nbsp;Shipping bill date</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Shippingbilldate" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_Shippingbilldate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_Shippingbilldate" runat="server" ControlToValidate="txt_Shippingbilldate" Display="None" ErrorMessage="Select shipping bill date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>Scheme</td>
                <td>
                    <ajaxtoolkit:calendarextender ID="Cal_Shippingbilldate" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ShippingbilldateValidation"
                                       PopupButtonID="img_Shippingbilldate" TargetControlID="txt_Shippingbilldate"></ajaxtoolkit:calendarextender>
                    <asp:TextBox ID="txt_Scheme" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">Cargo handed over to liner on </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Cargohadedovertolineron" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_Cargohadedovertolineron" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_Cargohadedovertolineron" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="CargohadedovertolineronDateValidation"
                                       PopupButtonID="img_Cargohadedovertolineron" TargetControlID="txt_Cargohadedovertolineron"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Cargohadedovertolineron" runat="server" ControlToValidate="txt_Cargohadedovertolineron" Display="None" ErrorMessage="Select cargo haded over to liner on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>Cargo on board</td>
                <td>
                    <asp:TextBox ID="txt_Cargoonboard" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_Cargoonboard" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_Cargoonboard" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="CargoonboardValidation"
                                       PopupButtonID="img_Cargoonboard" TargetControlID="txt_Cargoonboard"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Cargoonboard" runat="server" ControlToValidate="txt_Cargoonboard" Display="None" ErrorMessage="Select cargo on board" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Actual ETD</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Actialetd" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_Actialetd" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_Actialetd" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ActialetdValidation"
                                       PopupButtonID="img_Actialetd" TargetControlID="txt_Actialetd"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Actialetd" runat="server" ControlToValidate="txt_Actialetd" Display="None" ErrorMessage="Select actual ETD" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>C.O.O /GSP applied on </td>
                <td>
                    <asp:TextBox ID="txt_COOGSPappliedon" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_COOGSPappliedon" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Calendarextender11" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="COOGSPappliedonValidation"
                                       PopupButtonID="img_COOGSPappliedon" TargetControlID="txt_COOGSPappliedon"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_COOGSPappliedon" runat="server" ControlToValidate="txt_COOGSPappliedon" Display="None" ErrorMessage="Select C.O.O/GSP applied on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Doc submitted to consulate</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Docsubmittedtoconsulate" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Docsubmittedtoconsulate" runat="server" ControlToValidate="txt_Docsubmittedtoconsulate" Display="None" ErrorMessage="Enter doc submitted to consulate" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td valign="top"></td>
                <td valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>
                    <asp:ValidationSummary ID ="val_Summay" ValidationGroup ="aarms" runat ="server" ShowMessageBox ="true" ShowSummary ="false"  />
                    <asp:Button ID="btn_Submit" runat="server" ValidationGroup ="aarms" OnClick="btn_Submit_Click" Text="Submit" />
                </td>
                <td>&nbsp;</td>
            </tr>
         </table> 
        </asp:Panel> 
<br /><br /><br /><br /><br />
 </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
