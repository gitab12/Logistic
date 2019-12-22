<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportExportRegistration.aspx.cs" Inherits="ImportExport_ImportExportRegistration" %>

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
           width: 890px;
       }
table.gridtable th {
	border-width: 1px;
	padding: 6px;
	border-style: solid;
	border-color: #666666;
	background-color: #dedede;
}
table.gridtable td {
	border-width: 1px;
	padding: 6px;
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
</head>
<body>
    <form id="form1" runat="server" autocomplete ="off" >
    <div>
        <center>
     <asp:Panel ID ="pnl_Registration" CssClass="Panel" Visible ="false" runat ="server"  >
         <table align="center" cellpadding="3" class="gridtable" cellspacing="2" >
             <caption class ="caption"><b>Registration</b></caption>
             <tr>
                 <td>
                     <asp:RadioButton ID="rdb_FreightForwarders" runat="server" AutoPostBack ="true"  OnCheckedChanged ="rdb_FreightForwarders_CheckedChanged"  Text ="Freight Forwarders" GroupName ="Reg" Checked ="true"  />
                      
                 
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      
                 
                     <asp:RadioButton ID="rdb_CHA" runat="server" OnCheckedChanged ="rdb_CHA_CheckedChanged" AutoPostBack ="true"  Text ="CHA" GroupName ="Reg" />
                     </td>
                 </tr>
             <tr>
                 <td>
 <asp:Panel ID ="pnl_FreightForwarders" CssClass="Panel" Visible ="false" GroupingText ="Freight Forwarders" runat ="server"  >
                
             <table style="width: 864px">
                 <tr>
                     <td>
                         Company name : 
                     </td>
                     <td>
                         <asp:TextBox ID="txt_CompanyName" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_CompanyName" runat="server" ControlToValidate="txt_CompanyName" ErrorMessage="Enter company name" ValidationGroup="Freight" ></asp:RequiredFieldValidator>
                     </td>
                     <td>Address :</td>
                     <td>
                         <asp:TextBox ID="txt_Address" runat="server" TextMode ="MultiLine"  Width="173px" Height="52px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Name of promotor/MD/CEO :</td>
                     <td>
                         <br />
                         <br />
                         <asp:RadioButton ID="rdb_Promotor" runat="server" Text ="Promotor" Checked ="true"  GroupName ="Promotor" />
                        <asp:RadioButton ID="rdb_MD" runat="server" Text ="MD" GroupName ="Promotor" />
                        <asp:RadioButton ID="rdb_CEO" runat="server" Text ="CEO"  GroupName ="Promotor" />
                        
                         <br />
                         <asp:TextBox ID="txt_Contactperson" runat="server"></asp:TextBox>
                     </td>
                     <td>Marketing head :</td>
                     <td>
                         <asp:TextBox ID="txt_MarketHead" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Operational head :</td>
                     <td>
                         <asp:TextBox ID="txt_OperationHead" runat="server"></asp:TextBox>
                     </td>
                     <td>Mobile no :</td>
                     <td>
                         <asp:TextBox ID="txt_Mobileno" MaxLength ="10" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_Mobileno" runat="server" ControlToValidate="txt_Mobileno" ErrorMessage="Enter mobile no" ValidationGroup="Freight"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="mobileregexpresvali" runat="server" 
                       ControlToValidate="txt_Mobileno" 
                       ErrorMessage="Must be a valid 10 digit number" ValidationGroup="Freight" ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$"></asp:RegularExpressionValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>Board line :</td>
                     <td>
                         <asp:TextBox ID="txt_Boardline" runat="server"></asp:TextBox>
                     </td>
                     <td>Email id :</td>
                     <td>
                         <asp:TextBox ID="txt_EmailId" autocomplete="off" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_EmailId" runat="server" ControlToValidate="txt_EmailId" ErrorMessage="Enter email-id" ValidationGroup="Freight"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                       ControlToValidate="txt_EmailId" ErrorMessage="Invalid email-ID"  ValidationGroup="Freight"
                       ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                       Width="111px"></asp:RegularExpressionValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>Password :</td>
                     <td>
                         <asp:TextBox ID="txt_FreightForwarderPassword" autocomplete="off" TextMode ="Password"  runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_FreightForwarderPassword" runat="server" ControlToValidate="txt_FreightForwarderPassword"  ErrorMessage="Enter password" ValidationGroup="Freight"></asp:RequiredFieldValidator>
                     </td>
                     <td>Location of branches (India/Abroad) :</td>
                     <td>
                         <asp:RadioButton ID="rdb_India" runat="server" Text="India" />
                         <asp:RadioButton ID="rdb_Abroad" runat="server" Text="Abroad" />
                     </td>
                 </tr>
                 <tr>
                     <td>Whether own CHA licence ?</td>
                     <td>
                         <asp:RadioButton ID="rdb_CHALicenceYes" runat="server" GroupName="CHALicence" Text="Yes" />
                         <asp:RadioButton ID="rdb_CHALicenceNo" runat="server" GroupName="CHALicence" Text="No" />
                     </td>
                     <td>Your CHA licence no :</td>
                     <td>
                         <asp:TextBox ID="txt_CHALicenceno" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Whether IATA member :</td>
                     <td>
                         <asp:RadioButton ID="rdb_IATAYes" runat="server" GroupName="IATA" Text="Yes" />
                         <asp:RadioButton ID="rdb_IATANo" runat="server" GroupName="IATA" Text="No" />
                     </td>
                     <td>Whether you can issue AWB :</td>
                     <td>
                         <asp:RadioButton ID="rdb_AWBYes" runat="server" GroupName="AWB" Text="Yes" />
                         <asp:RadioButton ID="rdb_AWBNo" runat="server" GroupName="AWB" Text="No" />
                     </td>
                 </tr>
                 <tr>
                     <td>Your competitive sector (Air/Sea) :</td>
                     <td>
                         <asp:RadioButton ID="rdb_SectorAir" runat="server" Text="Air" />
                         <asp:RadioButton ID="rdb_SectoSea" runat="server" Text="Sea" />
                     </td>
                     <td>Do you do consolidation services?</td>
                     <td>
                         &nbsp;
                         <asp:RadioButton ID="rdb_ConsolidationYes" runat="server" GroupName="Consolidation" Text="Yes" />
                         <asp:RadioButton ID="rdb_ConsolidationNo" runat="server" GroupName="Consolidation" Text="No" />
                     </td>
                 </tr>
                 <tr>
                     <td>&nbsp;If yes, for which sector :</td>
                     <td>
                         &nbsp;&nbsp;<asp:TextBox ID="txt_Sectors" runat="server" Height="52px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     
                     <td colspan ="4" align="center" >
                         <asp:Button ID="btn_FreightSubmit" runat="server" Text="Submit" ValidationGroup="Freight" OnClick ="btn_FreightSubmit_Click"  />
                     </td>
                 </tr>
             </table>
     </asp:Panel> 
                 </td></tr>

              <tr>
                 <td>
 <asp:Panel ID ="pnl_CHA" CssClass="Panel" Visible ="false" GroupingText ="CHA" runat ="server"  >
                
             <table style="width: 849px">
                 <tr>
                     <td>
                         Company name : 
                     </td>
                     <td>
                         <asp:TextBox ID="txt_CHACompanyName" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_CHACompanyName" runat="server" ControlToValidate="txt_CHACompanyName" ErrorMessage="Enter company name" ValidationGroup="CHA"></asp:RequiredFieldValidator>
                     </td>
                     <td>Address :</td>
                     <td>
                         <asp:TextBox ID="txt_CHACompanyAddress" TextMode ="MultiLine"  Width="173px" Height="52px" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Name of promotor/MD/CEO :</td>
                     <td>
                         <br />
                         <br />
                         <asp:RadioButton ID="rdb_CHAPromotor" runat="server" Text ="Promotor" Checked ="true" GroupName ="CHAPromotor"  />
                         &nbsp;<asp:RadioButton ID="rdb_CHAMD" runat="server" Text ="MD" GroupName ="CHAPromotor" />
                         &nbsp;<asp:RadioButton ID="rdb_CHACEO" runat="server" Text ="CEO" GroupName ="CHAPromotor" />
                         <br />
                         <asp:TextBox ID="txt_CHAContactName" runat="server"></asp:TextBox>
                     </td>
                     <td>Marketing head:</td>
                     <td>
                         <asp:TextBox ID="txt_CHAMarketingHead" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <br />
                         Operational head:</td>
                     <td>
                         <asp:TextBox ID="txt_CHAOperationHead" runat="server"></asp:TextBox>
                     </td>
                     <td>Mobile no :</td>
                     <td>
                         <asp:TextBox ID="txt_CHAMobileno" MaxLength ="10" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_CHAMobileno" runat="server" ControlToValidate="txt_CHAMobileno" ErrorMessage="Enter mobile no" ValidationGroup="CHA"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                       ControlToValidate="txt_CHAMobileno" 
                       ErrorMessage="Must be a valid 10 digit number" ValidationGroup="CHA" ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$"></asp:RegularExpressionValidator>
                    
                     </td>
                 </tr>
                 <tr>
                     <td>Board line :</td>
                     <td>
                         <asp:TextBox ID="txt_CHABoardline" runat="server"></asp:TextBox>
                     </td>
                     <td>Email id :</td>
                     <td>
                         <asp:TextBox ID="txt_CHAEmailid" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_InvoiceNo6" runat="server" ControlToValidate="txt_CHAEmailid" ErrorMessage="Enter email-id" ValidationGroup="CHA"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="REV_Emailid" runat="server" 
                       ControlToValidate="txt_CHAEmailid" ErrorMessage="Invalid email-ID"  ValidationGroup="CHA"
                       ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                       Width="111px"></asp:RegularExpressionValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>Password :</td>
                     <td>
                         <asp:TextBox ID="txt_CHAPassword" TextMode ="Password" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_CHAPassword" runat="server" ControlToValidate="txt_CHAPassword" ErrorMessage="Enter password" ValidationGroup="CHA"></asp:RequiredFieldValidator>
                     </td>
                     <td>Location of branches (India/Abroad) :</td>
                     <td>
                         <asp:RadioButton ID="rdb_CHABranchesIndia" runat="server" Text="India" />
                         <asp:RadioButton ID="rdb_CHABranchesAbroad" runat="server" Text="Abroad" />
                     </td>
                 </tr>
                 <tr>
                     <td>Whether own CHA licence ?</td>
                     <td>
                         <asp:RadioButton ID="rdb_OwnCHALicenceYes" runat="server" GroupName="OwnCHALicence" Text="Yes" />
                         <asp:RadioButton ID="rdb_OwnCHALicenceNo" runat="server" GroupName="OwnCHALicence" Text="No" />
                     </td>
                     <td>&nbsp;&nbsp;Your CHA licence no :</td>
                     <td>
                         <asp:TextBox ID="txt_CHAlicencenum" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Specialized products :</td>
                     <td>
                         <asp:TextBox ID="txt_CHASpecilizedProducts" runat="server" Height="52px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                     </td>
                     <td>Can you handle both Air/Sea&nbsp; clearance :</td>
                     <td>
                         <asp:RadioButton ID="rdb_CHAClearanceYes" runat="server" GroupName="CHAClearance" Text="Yes" />
                         <asp:RadioButton ID="rdb_CHAClearanceNo" runat="server" GroupName="CHAClearance" Text="No" />
                     </td>
                 </tr>
                 <tr>
                     <td>Specialized services if any</td>
                     <td>
                         <asp:TextBox ID="txt_CHASpecilizedServices" runat="server" Height="52px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                     <td>
                         &nbsp;
                         </td>
                 </tr>
                 <tr>
                     
                     <td align="center" colspan ="4" >
                         <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" ValidationGroup="CHA" Text="Submit" />
                     </td>
                 </tr>
             </table>
     </asp:Panel> 
                 </td></tr>
             </table> 
         </asp:Panel> 
            </center>
    </div>
    </form>
</body>
</html>
