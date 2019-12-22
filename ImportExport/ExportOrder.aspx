<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportOrder.aspx.cs" Inherits="ImportExport_ExportOrder" %>
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
        //validate password length
        function validateLength(oSrc, args) {
            args.IsValid = (args.Value.length >= 6);
        }
        //Calculation of XWKSTotalcalculation
        function XWKSTotalcalculation(evt) {
            var a = document.getElementById('<%=txt_XwksCostofinlandtransport.ClientID%>').value;
            var b = document.getElementById('<%=txt_XwksOceanfreight.ClientID%>').value;
            var c = document.getElementById('<%=txt_XwksCustomduty.ClientID%>').value;
            var d = document.getElementById('<%=txt_XWKSInsurance.ClientID%>').value;
            var e = document.getElementById('<%=txt_XwksLocalTransportcost.ClientID%>').value;
            var add = Math.floor(a) + Math.floor(b) + Math.floor(c) + Math.floor(d) + Math.floor(e);
            document.getElementById('<%=txt_XwksLandedcost.ClientID%>').value = add;
            return false;
            return true;
        }
        //Calculation of FOBTotalcalculation
        function FOBTotalcalculation(evt) {
            var a = document.getElementById('<%=txt_FOBFreight.ClientID%>').value;
            var b = document.getElementById('<%=txt_FOBInsurance.ClientID%>').value;
            var c = document.getElementById('<%=txt_FOBCustomduty.ClientID%>').value;
            var d = document.getElementById('<%=txt_FOBLocaltransport.ClientID%>').value;

            var add = Math.floor(a) + Math.floor(b) + Math.floor(c) + Math.floor(d);
            document.getElementById('<%=txt_FOBLandedcost.ClientID%>').value = add;
            return false;
            return true;
        }
        //Calculation of CANDFTotalcalculation
        function CANDFTotalcalculation(evt) {
            var a = document.getElementById('<%=txt_CANDFInsurance.ClientID%>').value;
            var b = document.getElementById('<%=txt_CANDFCusotmduty.ClientID%>').value;
            var c = document.getElementById('<%=txt_CANDFLocaltransport.ClientID%>').value;

            var add = Math.floor(a) + Math.floor(b) + Math.floor(c);
            document.getElementById('<%=txt_CANDFLandedcost.ClientID%>').value = add;
            return false;
            return true;
        }
        //Calculation of CIFTotalcalculation
        function CIFTotalcalculation(evt) {
            var a = document.getElementById('<%=txt_CifCustomduty.ClientID%>').value;
            var b = document.getElementById('<%=txt_CIifLocaltransport.ClientID%>').value;

            var add = Math.floor(a) + Math.floor(b);
            document.getElementById('<%=txt_CifLandedcost.ClientID%>').value = add;
            return false;
            return true;
        }
        function DateValidation(sender, args) {
            var td = new Date();
            td.setMinutes(59);
            td.setSeconds(59);
            td.setHours(23);
            //to move back one day
            td.setDate(td.getDate() - 1);

            if (sender._selectedDate < td) {
                alert("You can't select day from the past! ");
                document.getElementById('<%= txt_Podate.ClientID  %>').value = "";
                //y.value = "";
            }
        }

</script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID ="scriptmanager1" runat ="server"  EnablePartialRendering="true" ></asp:ScriptManager>
        <div>
 <br /><br /><br />
    <center >  <b style="font-family: Arial;margin-right:600px; font-size: medium; font-weight: bold; font-style: normal; color: #FF0000">Export Order</b></center><br />
   
    <asp:Panel ID ="pnl_Ordermanagement" GroupingText ="Export Order" CssClass="Panel"  runat ="server" Width="987px" >
        <table >
            <tr>
                <td>
        <table align="left" cellpadding="3" cellspacing="2" style="width: 978px">
            <tr>
                <td valign ="top"  class="auto-style4">Buyer name</td>
                <td valign ="top" >
                    <asp:TextBox ID="txt_Buyer" onkeypress="return onlyalphawithspace(event)" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Buyer" runat="server" ControlToValidate="txt_Buyer" ErrorMessage="Enter buyer name" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
                <td valign ="top" class="auto-style22">Buyer country</td>
                <td valign ="top" class="auto-style8">
                     <asp:DropDownList ID="ddl_Country" runat="server" cssclass="txtboxcss" Width="140px">
                         <asp:ListItem>--Select--</asp:ListItem>
                         <asp:ListItem>India</asp:ListItem>
                         <asp:ListItem>China</asp:ListItem>
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfv_Contry" runat="server" ControlToValidate="ddl_Country" ErrorMessage="Select vendor contry" InitialValue="--Select--" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
                <td valign ="top" class="auto-style26">Po number</td>
                <td valign ="top" class="auto-style6">
             
                    <asp:TextBox ID="txt_Pono" runat="server" cssclass="txtboxcss" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Pono" runat="server" ControlToValidate="txt_Pono" ErrorMessage="Enter po no" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" valign="top">Po date</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Podate" runat="server" cssclass="txtboxcss" ></asp:TextBox>
                    <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                      <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" OnClientDateSelectionChanged ="DateValidation"
                    PopupButtonID="imgdate1" TargetControlID="txt_Podate"></ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Podate" runat="server" ControlToValidate="txt_Podate" ErrorMessage="Select po date" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style22" valign="top">Items description</td>
                <td class="auto-style8" valign="top">
                    <asp:TextBox ID="txt_ItemDesc" runat="server" CssClass="txtmultilineboxcss" TextMode="MultiLine" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_ItemDesc" runat="server" ControlToValidate="txt_ItemDesc" ErrorMessage="Enter item description" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style26" valign="top">UOM</td>
                <td class="auto-style6" valign="top">
                    <asp:DropDownList ID="ddl_Uom" runat="server" cssclass="txtboxcss" Width="140px">
                        <asp:ListItem>Centimeters</asp:ListItem>
                        <asp:ListItem>Meters</asp:ListItem>
                        <asp:ListItem>Inches</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_Uom" runat="server" ControlToValidate="ddl_Uom" ErrorMessage="*" InitialValue="--Select--" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
               <td valign ="top" >
                   Credit terms</td>
                <td valign ="top" >
                    <asp:TextBox ID="txt_Creditterms" runat="server" cssclass="txtmultilineboxcss" TextMode="MultiLine" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Creditterms" runat="server" ControlToValidate="txt_Creditterms" ErrorMessage="Enter credit terms" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
               </td>
                <td valign ="top" >
                    Payment terms<br /> </td>
                <td valign ="top">
                    <asp:TextBox ID="txt_Paymentterms" runat="server" cssclass="txtmultilineboxcss" TextMode="MultiLine" Width="140px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Paymentterms" runat="server" ControlToValidate="txt_Paymentterms" ErrorMessage="Enter payment terms" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                    <br />
               </td>
                <td valign ="top" >
                    Inco terms</td>
                <td valign ="top">
                    <asp:DropDownList ID="ddl_Incoterms" runat="server" AutoPostBack="true" cssclass="txtboxcss" OnSelectedIndexChanged="ddl_Incoterms_SelectedIndexChanged" Width="140px">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>XWKS</asp:ListItem>
                        <asp:ListItem>FOB</asp:ListItem>
                        <asp:ListItem>C&amp;F</asp:ListItem>
                        <asp:ListItem>CIF</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_IncoTerms" runat="server" ControlToValidate="ddl_Incoterms" ErrorMessage="Select at least one INCO Terms" InitialValue="--Select--" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
           </tr>
            <tr>
                <td valign ="top" >Quantity</td>
                <td valign ="top">
                    <asp:TextBox ID="txt_Quantity" runat="server" cssclass="txtboxcss" onkeypress="return onlynumber(event)" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Quantity" runat="server" ControlToValidate="txt_Quantity" ErrorMessage="Enter quantity" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
                <td valign ="top">Currency</td>
                <td valign ="top" >
                    <asp:TextBox ID="txt_Currency" runat="server" cssclass="txtboxcss" ></asp:TextBox>
                </td>
                <td valign ="top" >PO value</td>
                <td valign ="top" >
                    <asp:TextBox ID="txt_Povalue" runat="server" cssclass="txtboxcss" onkeypress="return onlynumber(event)" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Povalue" runat="server" ControlToValidate="txt_Povalue" ErrorMessage="Enter PO value" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Mode of shipment</td>
                <td valign ="top">
                    <asp:DropDownList ID="ddl_Shipmentmode" runat="server" cssclass="txtboxcss" Width="140px">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Air freight </asp:ListItem>
                        <asp:ListItem>Ocean freight</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_Shipmentmode" runat="server" ControlToValidate="ddl_Shipmentmode" ErrorMessage="Select mode of shipment" InitialValue="--Select--" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                   </td>
                <td valign="top">Port of loading</td>
                <td>
                    <asp:TextBox ID="txt_Portofloading" onkeypress="return onlyalphawithspace(event)" runat="server" cssclass="txtboxcss" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Portofloading" runat="server" ControlToValidate="txt_Portofloading" ErrorMessage="Enter port of loading" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Port of delivery</td>
                <td>
                    <asp:TextBox ID="txt_Portofdelivery" onkeypress="return onlyalphawithspace(event)" runat="server" cssclass="txtboxcss" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Portofdelivery" runat="server" ControlToValidate="txt_Portofdelivery" ErrorMessage="Enter port of delivery" ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
                <td valign ="top" class="auto-style4"  >Internal works order</td>
                <td valign="top" >
                    <asp:TextBox ID="txt_Internalworksorder" runat="server" cssclass="txtboxcss" ></asp:TextBox>
                </td>
                <td valign ="top" >Scan PO</td>
                <td  valign="top" class="auto-style8">
                    <asp:FileUpload ID="FileUpload1" runat="server" cssclass="txtboxcss" Width="140px" />
                </td>
                <td valign ="top" >&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
            </tr>
             </table>
                    </td>
            </tr>
            <tr>
                <td><center >
                     <asp:Label ID ="lbl_Msg" runat ="server" Visible ="false" ForeColor ="Red" Font-Bold ="true"  ></asp:Label>
                    </center> 
                </td>
            </tr>
        <tr>
            <td>
           <center >
                    <asp:Panel ID="pnl_XWKS" runat="server" CssClass ="panelxwks" GroupingText="XWKS" Visible ="false"  Height="161px" Width="478px">
                       <table cellpadding="3" cellspacing="2" align="center" >
                            <tr>
                                <td class="auto-style17">Nominate pick up&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_Nominatepickup" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Cost of inland transport&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_XwksCostofinlandtransport" onkeyup="return XWKSTotalcalculation(event)" runat="server" onkeypress="return onlynumber(event)" Text ="0" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Ocean freight&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_XwksOceanfreight" onkeyup="return XWKSTotalcalculation(event)" runat="server" Text ="0" onkeypress="return onlynumber(event)" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Custom duty&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_XwksCustomduty" onkeyup="return XWKSTotalcalculation(event)" Text ="0" runat="server" onkeypress="return onlynumber(event)" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                <td class="auto-style17">Insurance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_XWKSInsurance" onkeyup="return XWKSTotalcalculation(event)" runat="server" onkeypress="return onlynumber(event)" Text ="0" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style17">Local transport cost&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_XwksLocalTransportcost" onkeyup="return XWKSTotalcalculation(event)" onkeypress="return onlynumber(event)" runat="server" Text ="0" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Landed cost&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_XwksLandedcost" onkeyup="return XWKSTotalcalculation(event)" onkeypress="return onlynumber(event)" runat="server" Text ="0" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
               </center>
                 </td>
            </tr>
        <tr>
            <td>
           <center >
                    <asp:Panel ID="pnl_FOB" Visible ="false" CssClass ="panelfob"  runat="server" GroupingText="FOB" Height="141px" Width="479px" >
                        <table cellpadding="3" cellspacing="2" align="center" >
                            <tr>
                                <td class="auto-style17">Freight&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_FOBFreight" onkeyup="return FOBTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Insurance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_FOBInsurance" onkeyup="return FOBTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Custom duty&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_FOBCustomduty" onkeyup="return FOBTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0"  runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Local transport&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_FOBLocaltransport" onkeyup="return FOBTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Landed cost&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_FOBLandedcost" onkeyup="return FOBTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
               </center>
                 </td>
            </tr>
        <tr>
            <td>
           <center >
                    <asp:Panel ID="pnl_CandF" Visible ="false" CssClass ="panelcandf"  runat="server" GroupingText="C&amp;F" Height="116px" Width="478px" >
                        <table cellpadding="3" cellspacing="2" align="center" >
                            <tr>
                                <td class="auto-style18">Insurance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_CANDFInsurance" onkeyup="return CANDFTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18">Custom duty&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td> 
                                    <asp:TextBox ID="txt_CANDFCusotmduty" onkeyup="return CANDFTotalcalculation(event)" onkeypress="return onlynumber(event)" runat="server" Text ="0" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18">Local transport&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_CANDFLocaltransport" onkeyup="return CANDFTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18">Landed cost&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_CANDFLandedcost" onkeyup="return CANDFTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" cssclass="txtboxcss" runat="server" Width="140px"></asp:TextBox>

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
               </center>
                 </td>
            </tr>
        <tr>
            <td>
                <center >
                    <asp:Panel ID="pnl_CIF"  Visible ="false" CssClass="panelcif"  runat="server" GroupingText="CIF" Height="110px" Width="478px">
                        <table cellpadding="3" cellspacing="2" align="center" >
                            <tr>
                                <td class="auto-style17">Custom duty&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_CifCustomduty" onkeyup="return CIFTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Local transport&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_CIifLocaltransport" onkeyup="return CIFTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Landed cost&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td>
                                    <asp:TextBox ID="txt_CifLandedcost" onkeyup="return CIFTotalcalculation(event)" onkeypress="return onlynumber(event)" Text ="0" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel></center>
                 </td>
            </tr>
            <tr>
                <td>
                    <br /><br /><br /><br />
                    <center >
                        <asp:Button ID="btn_Submit" runat="server" class="promotion_btn" OnClick="btn_Submit_Click"  ValidationGroup="InputValidate"  Text="Submit" />
                                     
                        </center>
                </td>
            </tr>
        </table> 
        </asp:Panel>
    </div>
    </form>
</body>
</html>
