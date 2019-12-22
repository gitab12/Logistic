<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ImportExportMaster.master" AutoEventWireup="true" CodeFile="CHADeliveryChallan.aspx.cs" Inherits="ImportExport_CHADeliveryChallan" %>

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
         invoicepanel {
             margin-top :-1000px;
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
  <center >   <b style="font-family: Arial; font-size: medium; font-weight: bold; font-style: normal; color: #FF0000">CHA Delivery Challan</b></center>
   
    <table>
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
                <table>
        <tr>
            <td valign ="top" >
                 <asp:Panel ID ="pnl_Po" CssClass="Panel" Visible ="false" runat ="server"  >
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
            <td valign ="top" >
                <br />
                 <asp:Panel ID ="pnl_Invoice" CssClass="Panel" Visible ="false" runat ="server"  >
         <table align="left" cellpadding="3" class="gridtable" cellspacing="2" >
              <caption class ="caption"><b>Invoice Details</b></caption>
             <tr>
                 <td>
                     <asp:Label ID="lbl_InvoiceNo" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_InvoiceDate" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_InvoiceAmount" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Vessel" runat="server"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="lbl_ETD" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_ETA" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_BlOrAWBNo" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Portofloading" runat="server" ></asp:Label>
                 </td>
             </tr>
              <tr>
                  <td>
                      <asp:Label ID="lbl_Portofdischarge" runat="server" ></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_Docsent" runat="server" ></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_BlOrAWBDate" runat="server" ></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_ORIAWBno" runat="server" ></asp:Label>
                  </td>
              </tr>
             </table> 
        </asp:Panel> 
            </td>
 </tr>
        <tr>            <td valign ="top" >
            <br />

                <asp:Panel ID ="pnl_CustomDocument" CssClass="Panel" Visible ="false" runat ="server"  >
         <table align="left" cellpadding="3" class="gridtable" cellspacing="2" >
              <caption class ="caption"><b>Custom Document</b></caption>
             <tr>
                 <td>
                     <asp:Label ID="lbl_FRTFWD" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_CHAName" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_IGM" runat="server" ></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Billentrytype" runat="server" ></asp:Label>
                 </td>
             </tr>
              <tr>
                  <td>
                      <asp:Label ID="lbl_Homebillentryno" runat="server"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_Billentryno" runat="server"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_Billentrydate" runat="server"></asp:Label>
                      
                  </td>
                  <td>
                       <asp:Label ID="lbl_Exchrate" runat="server"></asp:Label>
                      
                  </td>
              </tr>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Assesablevalue" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_Dutystructure" runat="server"></asp:Label>
                     
                 </td>
                 <td>
                     <asp:Label ID="lbl_Totalduty" runat="server"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="lbl_CVD" runat="server"></asp:Label>
                 </td>
             </tr>
              <tr>
                  <td>
                      <asp:Label ID="lbl_Dutypaymentorderno" runat="server"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_Dutypaymentorderdate" runat="server"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_Dutypaidon" runat="server"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_Licence" runat="server"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="lbl_Basicduty" runat="server"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_Educess" runat="server"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lbl_ServiceCharge" runat="server"></asp:Label>
                      
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
             </table> 
        </asp:Panel> 
                </td> 
        </tr>
    </table>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Panel ID ="pnl_CHADelivery"  GroupingText  ="CHA Delivery Challan"  CssClass="Panel"  runat ="server" Width="621px" >
     <table align="left" cellpadding="3"  cellspacing="2" >
            <tr>
                <td>Po no</td>
                <td>
                    <asp:Label ID="lbl_PoNo" runat="server" Text="Label"></asp:Label>
                </td>
                <td valign ="top" >

                    Delivery challan no</td> 
                <td valign ="top" >

                    <asp:TextBox ID="txt_Deliverychallanno" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Deliverychallanno" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_Deliverychallanno" ErrorMessage="Enter delivery challan no"></asp:RequiredFieldValidator>

                    </td> 
                </tr> 
             
            <tr>
                <td>Delivery challan date</td>
                <td>
                    <asp:TextBox ID="txt_Deliverychallandate"  runat="server" cssclass="txtboxcss"></asp:TextBox>
                     <asp:ImageButton ID="imgbtn_Deliverychallandate" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format ="dd/MM/yyyy" 
                    PopupButtonID="imgbtn_Deliverychallandate" TargetControlID="txt_Deliverychallandate">  </ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Deliverychallandate" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_Deliverychallandate" ErrorMessage="Select delivery challan date "></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Transporter</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Transporter" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Vehicle no</td>
                <td>
                    <asp:TextBox ID="txt_Vehicleno" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
                <td valign="top">LR no </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Lrno" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>LR date </td>
                <td>
                    <asp:TextBox ID="txt_Lrdate" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgbtn_Lrdate" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" Format ="dd/MM/yyyy" 
                    PopupButtonID="imgbtn_Lrdate" TargetControlID="txt_Lrdate">  </ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfvtxt_Lrdate" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_Lrdate" ErrorMessage="Select LR date "></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Delivery on </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Deliveryon"  cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgbtn_Deliveryon" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender3" runat="server" Format ="dd/MM/yyyy" 
                    PopupButtonID="imgbtn_Deliveryon" TargetControlID="txt_Deliveryon">  </ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Deliveryon" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_Deliveryon" ErrorMessage="Select delivery challan date "></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>CHA bill no </td>
                <td>
                    <asp:TextBox ID="txt_Chabillno" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
                <td valign="top">CHA date </td>
                <td valign="top">
                    <asp:TextBox ID="txt_Chadate" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgbtn_Chadate" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender4" runat="server" Format ="dd/MM/yyyy" 
                    PopupButtonID="imgbtn_Chadate" TargetControlID="txt_Chadate">  </ajaxtoolkit:calendarextender>
                    <asp:RequiredFieldValidator ID="rfv_Chadate" ValidationGroup ="aarms" Display ="None" runat="server" ControlToValidate ="txt_Chadate" ErrorMessage="Select delivery challan date "></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>CHA amount</td>
                <td>
                    <asp:TextBox ID="txt_Chaamount" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
                <td valign="top">CHA bill payment detail</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Chabillpaymentdetail" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Shipment clearance cost</td>
                <td>
                    <asp:TextBox ID="txt_Shipmentclearancecost" runat="server" cssclass="txtboxcss" onkeypress="return onlynumber(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Shipmentclearancecost" runat="server" ControlToValidate="txt_Shipmentclearancecost" Display="None" ErrorMessage="Enter shipment clearance cost " ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">&nbsp;</td>
                <td valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td valign="top">
                    <asp:ValidationSummary ID ="val_Summay" ValidationGroup ="aarms" runat ="server" ShowMessageBox ="true" ShowSummary ="false"  />
                    <asp:Button ID="btn_Submit" runat="server" ValidationGroup ="aarms" Text="Submit" OnClick ="btn_Submit_Click"  />
                </td>
                <td valign="top">&nbsp;</td>
            </tr>
         </table> 
          </asp:Panel> 

            </td>
        </tr>
    </table>
</asp:Content>

