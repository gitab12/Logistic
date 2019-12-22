<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ImportExportMaster.master" AutoEventWireup="true" CodeFile="ImportExportInvoice.aspx.cs" Inherits="ImportExport_ImportExportInvoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:ScriptManager ID ="scriptmanager1" runat ="server"  EnablePartialRendering="true" ></asp:ScriptManager>
    <center >  <b style="font-family: Arial; font-size: medium; font-weight: bold; font-style: normal; color: #FF0000">Invoice</b></center><br />
   <table >
       <tr>
           <td>
                 <table align="left" cellpadding="3"  cellspacing="2" >
            <tr>
                <td>PO no</td>
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
               <asp:Panel ID ="pnl_Ordermanagement" CssClass="Panel" Visible ="false" runat ="server"  >
         <table align="left" cellpadding="3" class="gridtable" cellspacing="2" >
             <caption class ="caption"><b>PO Details</b></caption>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Podate" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Product" runat="server" ></asp:Label>
                 </td>

                 <td>
                     <asp:Label ID="lbl_Vendor" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Address" runat="server"></asp:Label>
                 </td>

             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Buyer" runat="server"></asp:Label></td>
                  <td>   
                      <asp:Label ID="lbl_BuyerAddress" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Incoterms" runat="server"></asp:Label></td>
                 <td><asp:Label ID="lbl_Creditterms" runat="server"></asp:Label></td>
                 
             </tr>
             <tr>
               <td> 
                   <asp:Label ID="lbl_Basicvalue" runat="server"></asp:Label>
                 </td> 
                 <td>
                     <asp:Label ID="lbl_Quantity" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Shipmentmode" runat="server"></asp:Label>
                 </td>
                 
                 <td>
                     <asp:Label ID="lbl_Paymentmode" runat="server"></asp:Label>
                 </td>
             </tr>
             </table> 
        </asp:Panel> 
     
           </td>
       </tr>
        <tr>
           <td>
               <asp:Panel ID ="pnl_Invoice"  GroupingText  ="Invoice" CssClass="Panel"  runat ="server" Width="785px"  >
     <table align="left" cellpadding="3"  cellspacing="2" >
            <tr>
                <td>Po no</td>
                <td>
                    <asp:Label ID="lbl_PoNo" runat="server" Text="Label"></asp:Label>
                </td>
                <td valign ="top" >

                    Invoice no</td> 
                <td valign ="top" >

                    <asp:TextBox ID="txt_InvoiceNo" cssclass="txtboxcss" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfv_InvoiceNo" ValidationGroup ="aarms" Display ="None"  runat="server" ControlToValidate ="txt_InvoiceNo" ErrorMessage="Enter invoice no"></asp:RequiredFieldValidator>

                    </td> 
                </tr> 
            <tr>
                <td>Invoice date</td>
                <td>
                    <asp:TextBox ID="txt_InvoiceDate"  cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format ="dd/MM/yyyy"
                    PopupButtonID="imgdate1" TargetControlID="txt_InvoiceDate">  </ajaxtoolkit:calendarextender>

                    <asp:RequiredFieldValidator ID="rfv_Invoicedate" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_InvoiceDate" ErrorMessage="Select invoice date"></asp:RequiredFieldValidator>

                </td>
                <td valign="top">Invoice amount</td>
                <td valign="top">
                    <asp:TextBox ID="txt_InvoiceAmount" onkeypress="return onlynumber(event)" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Invoiceamount" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_InvoiceAmount" ErrorMessage="Enter invoice amount"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Vessel name</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Vesselname" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Vesselname" runat="server" ControlToValidate="txt_Vesselname" Display="None" ErrorMessage="Enter vessel name" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>ETD (Estimated time of delivery)</td>
                <td>
                    <asp:TextBox ID="txt_ETD" runat="server" cssclass="txtboxcss" Width="140px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txt_ETD_calendarextender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgbtn_ETD" TargetControlID="txt_ETD">
                    </ajaxToolkit:CalendarExtender>
                    <asp:ImageButton ID="imgbtn_ETD" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_ETD" runat="server" ControlToValidate="txt_ETD" Display="None" ErrorMessage="Select estimated time of delivery" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">ETA (Estimated time of arrival)</td>
                <td valign="top">
                    <asp:TextBox ID="txt_ETA" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgbtn_ETA" TargetControlID="txt_ETA">
                    </ajaxToolkit:CalendarExtender>
                    <asp:ImageButton ID="imgbtn_ETA" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_ETA" runat="server" ControlToValidate="txt_ETA" Display="None" ErrorMessage="Select estimated time of arrival" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>Port of loading</td>
                <td>&nbsp;<asp:TextBox ID="txt_Loadingport" runat="server" cssclass="txtboxcss" onkeypress="return onlyalphawithspace(event)" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Loadingport" runat="server" ControlToValidate="txt_Loadingport" ErrorMessage="Enter loadingport " ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">Port of delivery</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Dischargeport" runat="server" cssclass="txtboxcss" onkeypress="return onlyalphawithspace(event)" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Dischargeport" runat="server" ControlToValidate="txt_Dischargeport" ErrorMessage="Enter dischargeport " ValidationGroup="InputValidate"></asp:RequiredFieldValidator>
                </td>
                <td valign ="top">N/N Doc Received </td>
                <td valign ="top">
                    <asp:RadioButton ID="rdb_Yes" runat="server" Text ="Yes" GroupName ="Doc" />
                    &nbsp;&nbsp; <asp:RadioButton ID="rdb_No" runat="server" Text ="No" GroupName ="Doc" />
                </td>
            </tr>
            <tr>
                <td valign="top">B/L or AWB no</td>
                <td valign="top">
                    <asp:TextBox ID="txt_BlOrAWBNo" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_BlorAWBNo" runat="server" ControlToValidate="txt_BlOrAWBNo" Display="None" ErrorMessage="Enter B/L (or) AWB no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>B/L or AWB Date</td>
                <td><asp:TextBox ID="txt_BlOrAWBDate" runat="server" cssclass="txtboxcss"></asp:TextBox>
                     <ajaxToolkit:CalendarExtender ID="Calendar_BlOrAWBDate" runat="server"  PopupButtonID="img_BlOrAWBDate" TargetControlID="txt_BlOrAWBDate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:ImageButton ID="img_BlOrAWBDate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_BlOrAWBDate" runat="server" ControlToValidate="txt_BlOrAWBDate" Display="None" ErrorMessage="Select Bl or AWB Date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">ORI.Doc courier AWB no</td>
                <td valign="top">
                    <asp:TextBox ID="txt_OriAWBNo" runat="server" cssclass="txtboxcss"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfv_OriAWBNo" runat="server" ControlToValidate="txt_OriAWBNo" Display="None" ErrorMessage="Enter ORI.Doc courier AWB no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td>ORI.Doc courier AWB date</td>
                <td>
                    <asp:TextBox ID="txt_OriAWBDate" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="Calendartxt_OriAWBDate" runat="server"  PopupButtonID="img_OriAWBDate" TargetControlID="txt_OriAWBDate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:ImageButton ID="img_OriAWBDate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_OriAWBDate" runat="server" ControlToValidate="txt_OriAWBDate" Display="None" ErrorMessage="Select ORI.Doc courier AWB date" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                
                </td>
            </tr>
            <tr>
                <td valign="top">&nbsp;</td>
                <td valign="top">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">&nbsp;</td>
                <td valign="top">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">(* Indicates mandatory fields)</td>
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
           </td>
       </tr>
   </table>
  
    
    
    
    

</asp:Content>

