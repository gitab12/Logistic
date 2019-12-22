<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ImportExportMaster.master" AutoEventWireup="true" CodeFile="CustomDocument.aspx.cs" Inherits="ImportExport_CustomDocument" %>

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

 <center >  <b style="font-family: Arial; font-size: medium; font-weight: bold; font-style: normal; color: #FF0000">Custom Document</b></center><br />
      
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
    </table>
            </td>
        </tr>
         <tr>
            <td>
                  <asp:Panel ID ="pnl_CustomDocument"  GroupingText  ="Custom Document" CssClass="Panel"  runat ="server" Width="780px" >
     <table align="left" cellpadding="3"  cellspacing="2" >
            <tr>
                <td>Po no</td>
                <td>
                    <asp:Label ID="lbl_PoNo" runat="server" Text="Label"></asp:Label>
                </td>
                <td valign ="top" >

                    FRT FWD name</td> 
                <td valign ="top" >

                    <asp:TextBox ID="txt_FRTFWDname" cssclass="txtboxcss" runat="server"></asp:TextBox>

                    </td> 
                </tr> 
             
            <tr>
                <td>CHA name</td>
                <td>
                    <asp:TextBox ID="txt_Chaname" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
                <td valign="top">IGM</td>
                <td valign="top">
                    <asp:TextBox ID="txt_IGM" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>HS Code no</td>
                <td>
                    <asp:TextBox ID="txt_HSCodeno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_HSCodeno" runat="server" ControlToValidate="txt_HSCodeno" Display="None" ErrorMessage="Enter HS Code no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Bill of entry type</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Billentrytype" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;Home bill of entry no</td>
                <td>
                    <asp:TextBox ID="txt_Homebillentryno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
                <td valign="top">Bond bill of entry no</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Billentryno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Billentryno" runat="server" ControlToValidate="txt_Billentryno" Display="None" ErrorMessage="Enter bond bill of entry no" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
             
            <tr>
                <td>Bill of entry date</td>
                <td>
                    <asp:TextBox ID="txt_Billentrydate" runat="server" cssclass="txtboxcss"></asp:TextBox> <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format ="dd/MM/yyyy" 
                    PopupButtonID="imgbtn_Billentrydate" TargetControlID="txt_Billentrydate">  </ajaxtoolkit:calendarextender>
                    <asp:ImageButton ID="imgbtn_Billentrydate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_Billentrydate" runat="server" ControlToValidate="txt_Billentrydate" Display="None" ErrorMessage="Select Billentrydate" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Exch.rate</td>
                <td valign="top">
              
                    <asp:TextBox ID="txt_Exchrate" runat="server" cssclass="txtboxcss" onkeypress="return onlynumber(event)" Text="0"></asp:TextBox>
              
                </td>
            </tr>
            <tr>
                <td>Assessable value</td>
                <td>
                    <asp:TextBox ID="txt_Assessablevalue" runat="server" cssclass="txtboxcss" onkeypress="return onlynumber(event)" Text="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Assessablevalue" runat="server" ControlToValidate="txt_Assessablevalue" Display="None" ErrorMessage="Enter assessable value" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Duty sctructure</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Dutystructure" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Dutystructure" runat="server" ControlToValidate="txt_Dutystructure" Display="None" ErrorMessage="Enter Duty structure " ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Total duty amount</td>
                <td>
                    <asp:TextBox ID="txt_Totalduty" runat="server" cssclass="txtboxcss" onkeypress="return onlynumber(event)" Text="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Totalduty" runat="server" ControlToValidate="txt_Totalduty" Display="None" ErrorMessage="Enter Totalduty" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">CVD amount</td>
                <td valign="top">
                    <asp:TextBox ID="txt_CVD" runat="server" cssclass="txtboxcss" onkeypress="return onlynumber(event)" Text="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_CVD" runat="server" ControlToValidate="txt_CVD" Display="None" ErrorMessage="Enter CVD" ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Duty payment pay-order no</td>
                <td>
                    <asp:TextBox ID="txt_payorderno" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_payorderno" runat="server" ControlToValidate="txt_payorderno" Display="None" ErrorMessage="Enter Duty payment pay-order no " ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">Duty payment pay-order date</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Payorderdate" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgbtn_Payorderdate" TargetControlID="txt_Payorderdate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:ImageButton ID="imgbtn_Payorderdate" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_Payorderdate" runat="server" ControlToValidate="txt_Payorderdate" Display="None" ErrorMessage="Select Duty payment pay-order date " ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Duty paid on</td>
                <td>
                    <asp:TextBox ID="txt_Dutypaidon" runat="server" cssclass="txtboxcss"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgbtn_Dutypaidon" TargetControlID="txt_Dutypaidon">
                    </ajaxToolkit:CalendarExtender>
                    <asp:ImageButton ID="imgbtn_Dutypaidon" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                    <asp:RequiredFieldValidator ID="rfv_Dutypaidon" runat="server" ControlToValidate="txt_Dutypaidon" Display="None" ErrorMessage="Select Duty paid on " ValidationGroup="aarms"></asp:RequiredFieldValidator>
                </td>
                <td valign="top">&nbsp;Licence detail</td>
                <td valign="top">
                    <asp:TextBox ID="txt_Licence" runat="server" cssclass="txtboxcss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td valign="top">&nbsp;</td>
                <td valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td valign="top">
                    <asp:ValidationSummary ID ="val_Summay" ValidationGroup ="aarms" runat ="server" ShowMessageBox ="true" ShowSummary ="false"  />
                    <asp:Button ID="btn_Submit" runat="server" ValidationGroup ="aarms" OnClick="btn_Submit_Click" Text="Submit" />
                </td>
                <td valign="top">&nbsp;</td>
            </tr>
             
         </table> 
        </asp:Panel> 
            </td>
        </tr>
         <tr>
            <td>

            </td>
        </tr>
    </table>
</asp:Content>

