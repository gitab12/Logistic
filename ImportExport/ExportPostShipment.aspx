<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportPostShipment.aspx.cs" Inherits="ImportExport_ExportPostShipment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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


          function OriginalshippingdocreceivedonValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Originalshippingdocreceivedon.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function txt_nnsenttocustomeronValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_nnsenttocustomeron.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function CommerdoclodgedbankonValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Commerdoclodgedbankon.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function LodgementrefdateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Lodgementrefdate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function PaymentduedateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Paymentduedate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function TTremittancedateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_TTremittancedate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function DisburseadvisesenttobankValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Disburseadvisesenttobank.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function TransactionadvisedateValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Transactionadvisedate.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function BRCuploadedonValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_BRCuploadedon.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function DutydrawbackreceivedonValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Dutydrawbackreceivedon.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function ProofofexportdocreceivedonValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Proofofexportdocreceivedon.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function ProofofexportdocsenttofactoryValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Proofofexportdocsenttofactory.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

          function ProofofexportdocsenttolicencedeptonValidation(sender, args) {
              var td = new Date();
              td.setMinutes(59);
              td.setSeconds(59);
              td.setHours(23);
              //to move back one day
              td.setDate(td.getDate() - 1);

              if (sender._selectedDate < td) {
                  alert("You can't select day from the past! ");
                  document.getElementById('<%= txt_Proofofexportdocsenttolicencedepton.ClientID  %>').value = "";
                  //y.value = "";
              }
          }

        </script>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID ="scriptmanager1" runat ="server"  EnablePartialRendering="true" ></asp:ScriptManager>
    <br /><br /><br />
    <center >  <b style="font-family: Arial;margin-right:600px; font-size: medium; font-weight: bold; font-style: normal; color: #FF0000">Export Post Shipment</b></center><br />
   
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
                     <asp:Panel ID ="pnl_Preshipment" CssClass="Panel" Visible ="false" runat ="server"  >
         <table align="left" cellpadding="3" class="gridtable" cellspacing="2" >
             <caption class ="caption"><b>Export pre shipment details</b></caption>
             <tr>
                 <td>
                     <asp:Label ID="lbl_deliverydate" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_3rdpartyinspection" runat="server" ></asp:Label>
                 </td>

                 <td>
                     <asp:Label ID="lbl_Stuffingdate" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Chaname" runat="server"></asp:Label>
                 </td>

             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Freightforwardedname" runat="server"></asp:Label></td>
                  <td>  
                       <asp:Label ID="lbl_Vehicleno" runat="server"></asp:Label> 
                 </td>
                 <td>
                      <asp:Label ID="lbl_Vesselname" runat="server"></asp:Label></td> 
                 <td>
                      <asp:Label ID="lbl_Etd" runat="server"></asp:Label>
                 </td>
                 
             </tr>
             <tr>
               <td> 
                    <asp:Label ID="lbl_Eta" runat="server"></asp:Label>
                 </td> 
                 <td>
                     <asp:Label ID="lbl_Preshipmentinvoiceno" runat="server"></asp:Label>
                 </td>
                 <td>
                       <asp:Label ID="lbl_Preshipmentinvoicedate" runat="server"></asp:Label>
                 </td>
                 
                 <td>
                 <asp:Label ID="lbl_Invoiceamount" runat="server"></asp:Label>
                 </td>
             </tr>

              <tr>
                 
                 <td>
                     <asp:Label ID="lbl_Cha" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_ETDdetailstocustomeron" runat="server"></asp:Label>
                     
                 </td>
                  <td> <asp:Label ID="lbl_Preshipmentdocsenttocha" runat="server"></asp:Label></td>
                  <td> <asp:Label ID="lbl_Shippingbillno" runat="server"></asp:Label></td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Shippingbilldate" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Cargohandedovertoliner" runat="server"></asp:Label>
                     
                 </td>
                  <td> <asp:Label ID="lbl_Cargoonboard" runat="server"></asp:Label></td>
                  <td> <asp:Label ID="lbl_Actualetd" runat="server"></asp:Label></td>
             </tr>
              <tr>
                 <td>
                     <asp:Label ID="lbl_COOGSPAppliedon" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Docsubmittedtoconsulate" runat="server"></asp:Label>
                 </td>
                  <td> 
                       <asp:Label ID="lbl_Netweight" runat="server"></asp:Label>
                  </td>
                  <td> 
                       <asp:Label ID="lbl_Scheme" runat="server"></asp:Label>
                  </td>
             </tr>

             </table> 
        </asp:Panel> 
                </td>
            </tr>

            <tr>
                <td>

    <asp:Panel ID ="pnl_Postshipment"  GroupingText  ="Post Shipment" CssClass="Panel" Visible ="false" runat ="server" Width="927px"  >
     <table align="left" cellpadding="3"  cellspacing="2" style="width: 929px" >
            <tr>
                <td>Po no</td>
                <td>
                    <asp:Label ID="lbl_PoNo" runat="server" Text="Label"></asp:Label>
                </td>
                <td valign ="top" >

                    Original shipping doc. received on </td> 
                <td valign ="top" >

                    <asp:TextBox ID="txt_Originalshippingdocreceivedon" cssclass="txtboxcss" runat="server"></asp:TextBox>

                    <asp:ImageButton ID="img_txt_Originalshippingdocreceivedon" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="cal_Originalshippingdocreceivedon" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="OriginalshippingdocreceivedonValidation"
                                       PopupButtonID="img_txt_Originalshippingdocreceivedon" TargetControlID="txt_Originalshippingdocreceivedon"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Originalshippingdocreceivedon" ValidationGroup ="aarms" Display ="None"  runat="server" ControlToValidate ="txt_Originalshippingdocreceivedon" ErrorMessage="Select original shipping doc received on "></asp:RequiredFieldValidator>

                    </td> 
                </tr> 
            <tr>
                <td>N/N sent to customer on </td>
                <td>
                    <asp:TextBox ID="txt_nnsenttocustomeron" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_nnsenttocustomeron" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="cal_nnsenttocustomeron" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="txt_nnsenttocustomeronValidation"
                                       PopupButtonID="img_nnsenttocustomeron" TargetControlID="txt_nnsenttocustomeron"></ajaxtoolkit:calendarextender>

                    <asp:RequiredFieldValidator ID="rfv_nnsenttocustomeron" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_nnsenttocustomeron" ErrorMessage="Select  N/N sent to customer on "></asp:RequiredFieldValidator>

                </td>
                <td valign="top">Commercial doc. lodged with bank on </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Commerdoclodgedbankon"  cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_Commerdoclodgedbankon" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_Commerdoclodgedbankon" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="CommerdoclodgedbankonValidation"
                                       PopupButtonID="img_Commerdoclodgedbankon" TargetControlID="txt_Commerdoclodgedbankon"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Commerdoclodgedbankon" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_Commerdoclodgedbankon" ErrorMessage="Select commercial doc lodged with bank on"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" >Lodgement ref. no</td>
                <td>
                    <asp:TextBox ID="txt_Lodgementrefno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Lodgementrefno" runat="server" ControlToValidate="txt_Lodgementrefno" Display="None" ErrorMessage="Enter lodgement ref no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Lodgement ref. date</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Lodgementrefdate" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Calendarextender1" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="LodgementrefdateValidation"
                                       PopupButtonID="ImageButton1" TargetControlID="txt_Lodgementrefdate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Lodgementrefdate" runat="server" ControlToValidate="txt_Lodgementrefdate" Display="None" ErrorMessage="Select lodgement ref date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Payment due date</td>
                <td>
                    <asp:TextBox ID="txt_Paymentduedate" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Calendarextender2" runat="server" Format ="dd/MM/yyyy"  OnClientDateSelectionChanged="PaymentduedateValidation"
                                       PopupButtonID="ImageButton2" TargetControlID="txt_Paymentduedate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Paymentduedate" runat="server" ControlToValidate="txt_Paymentduedate" Display="None" ErrorMessage="Select payment due date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">TT remittance no</td>
                <td valign="top">
                    <asp:TextBox ID="txt_TTremittanceno" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">TT remittance date </td>
                <td>
                    <asp:TextBox ID="txt_TTremittancedate" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_txt_TTremittancedate"  runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_TTremittancedate" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="TTremittancedateValidation"
                                       PopupButtonID="img_txt_TTremittancedate" TargetControlID="txt_TTremittancedate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_TTremittancedate" runat="server" ControlToValidate="txt_TTremittancedate" Display="None" ErrorMessage="Select TT remittance date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Disbursement advise sent to bank on </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Disburseadvisesenttobank" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_Disburseadvisesenttobank" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_ETA" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="DisburseadvisesenttobankValidation"
                                       PopupButtonID="img_Disburseadvisesenttobank" TargetControlID="txt_Disburseadvisesenttobank"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Disburseadvisesenttobank" runat="server" ControlToValidate="txt_Disburseadvisesenttobank" Display="None" ErrorMessage="Select disbursement advise sent to bank on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Transaction advise date</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Transactionadvisedate" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="img_Transactionadvisedate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Calendarextender3" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="TransactionadvisedateValidation"
                                       PopupButtonID="img_Transactionadvisedate" TargetControlID="txt_Transactionadvisedate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Transactionadvisedate" runat="server" ControlToValidate="txt_Transactionadvisedate" Display="None" ErrorMessage="Select transaction advise date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>BRC uploaded on</td>
                <td>
                    <asp:TextBox ID="txt_BRCuploadedon" runat="server" cssclass="txtboxcss"></asp:TextBox>
                      <asp:ImageButton ID="img_BRCuploadedon" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_BRCuploadedon" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="BRCuploadedonValidation"
                                       PopupButtonID="img_BRCuploadedon" TargetControlID="txt_BRCuploadedon"></ajaxtoolkit:calendarextender>
                      <asp:RequiredFieldValidator ID="rfv_BRCuploadedon" runat="server" ControlToValidate="txt_BRCuploadedon" Display="None" ErrorMessage="Select BRC uploaded on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Duty drawback received on </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Dutydrawbackreceivedon" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Calendarextender4" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="DutydrawbackreceivedonValidation"
                                       PopupButtonID="ImageButton4" TargetControlID="txt_Dutydrawbackreceivedon"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Dutydrawbackreceivedon" runat="server" ControlToValidate="txt_Dutydrawbackreceivedon" Display="None" ErrorMessage="Select duty drawback received on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>Proof of export doc. received on </td>
                <td>
                    <asp:TextBox ID="txt_Proofofexportdocreceivedon" cssclass="txtboxcss"  runat="server"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Calendarextender5" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ProofofexportdocreceivedonValidation"
                                       PopupButtonID="ImageButton5" TargetControlID="txt_Proofofexportdocreceivedon"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Proofofexportdocreceivedon" Display="None" ErrorMessage="Select proof of export doc. received on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Proof of export doc. sent to factory on </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Proofofexportdocsenttofactory" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_Proofofexportdocsenttofactory" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_Proofofexportdocsenttofactory" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ProofofexportdocsenttofactoryValidation"
                                       PopupButtonID="img_Proofofexportdocsenttofactory" TargetControlID="txt_Proofofexportdocsenttofactory"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Proofofexportdocsenttofactory" runat="server" ControlToValidate="txt_Proofofexportdocsenttofactory" Display="None" ErrorMessage="Select proof of export doc. sent to factory on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>Proof of export doc. sent to licence department on</td>
                <td>
                    <asp:TextBox ID="txt_Proofofexportdocsenttolicencedepton" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_Proofofexportdocsenttolicencedepton" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Cal_Proofofexportdocsenttolicencedepton" runat="server" Format ="dd/MM/yyyy" OnClientDateSelectionChanged="ProofofexportdocsenttolicencedeptonValidation"
                                       PopupButtonID="img_Proofofexportdocsenttolicencedepton" TargetControlID="txt_Proofofexportdocsenttolicencedepton"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Preshipmentdocsenttochaon" runat="server" ControlToValidate="txt_Proofofexportdocsenttolicencedepton" Display="None" ErrorMessage="Select proof of export doc. sent to licence dept on" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>

          <tr>
                <td valign="top">CHA billl no</td>
                <td valign="top">
                    <asp:TextBox ID="txt_CHAbillno" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_CHAbillno" runat="server" ControlToValidate="txt_CHAbillno" Display="None" ErrorMessage="Enter CHA bill no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>CHA bill date</td>
                <td>
                    <asp:TextBox ID="txt_CHAbilldate" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="img_CHAbilldate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <ajaxtoolkit:calendarextender ID="Calendarextender6" runat="server" Format ="dd/MM/yyyy" 
                                       PopupButtonID="img_CHAbilldate" TargetControlID="txt_CHAbilldate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_CHAbilldate" runat="server" ControlToValidate="txt_CHAbilldate" Display="None" ErrorMessage="Select CHA bill date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">CHA bill amount</td>
                <td valign="top">
                    <asp:TextBox ID="txt_CHAbillamount" cssclass="txtboxcss" Text ="0" runat="server"></asp:TextBox>
                </td>
                <td>Freight amount Rs.</td>
                <td>
                    <asp:TextBox ID="txt_Freightamount" cssclass="txtboxcss" Text ="0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">Detention charges</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Detention" cssclass="txtboxcss" Text ="0" runat="server"></asp:TextBox>
                </td>
                <td>W/H charges</td>
                <td>
                    <asp:TextBox ID="txt_whCharges" cssclass="txtboxcss" Text ="0" runat="server"></asp:TextBox>
                </td>
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
