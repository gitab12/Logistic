<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BillMatching.aspx.cs" Inherits="BillMatching" %>
<%@ Register Src ="~/UserControl/ESignature.ascx" TagName="ESign" TagPrefix ="UES" %>
<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagPrefix="UES" TagName="DashboardMenuBar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
    <script src="Dropdownsearcable_link/jquery.min.js"></script>
    <script src="Dropdownsearcable_link/bootstrap.min.js"></script>
    <link href="Dropdownsearcable_link/bootstrap.min.css" rel="stylesheet" />
    <script src="Dropdownsearcable_link/bootstrap-select.min.js"></script>
    <link href="Dropdownsearcable_link/bootstrap-select.min.css" rel="stylesheet" />
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <style type="text/css">
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
        .style2
       {
           width: 282px;
           height: 21px;
       }
       .style3
       {
           height: 21px;
       }
        .style4
        {
            height: 21px;
            width: 183px;
        }
        </style>
  
   
<link rel="stylesheet" type="text/css" media="all" href="jss/jsDatePick_ltr.min.css" />

<script type="text/javascript" src="jss/jquery.1.4.2.js"></script>
<script type="text/javascript" src="jss/jsDatePick.jquery.min.1.3.js"></script>

<script type="text/javascript">
    window.onload = function() {
        new JsDatePick({
            useMode: 2,
            target: "inputField",
            dateFormat: "%d-%M-%Y"

        });
    };
</script>
 <script language="javascript" type="text/javascript">
//Calculation of Total Cost
function calculation(evt)
{

    var a = document.getElementById('<%=txtCNBascicFreight.ClientID%>').value;
    var b = document.getElementById('<%=txtCNLoadingDetention.ClientID%>').value;
    var c = document.getElementById('<%=txtCNunloadingdetention.ClientID%>').value;
    var d = document.getElementById('<%=txtCNLoadingCharges.ClientID%>').value;
    var e = document.getElementById('<%=txtCNUNLoadingCharges.ClientID%>').value;
    var f = document.getElementById('<%=txtCNOctroid.ClientID%>').value;
    var g = document.getElementById('<%=txtCNDimensionDiff.ClientID%>').value;
    var h = document.getElementById('<%=txtCNOtherClaims.ClientID%>').value;
    var ap = document.getElementById('<%=txtApprovedPRice.ClientID%>').value;

    var i = document.getElementById('<%=txtCNInsurance.ClientID%>').value;
    var j = document.getElementById('<%=txtCNDamages.ClientID%>').value;
    var k = document.getElementById('<%=txtCNShortages.ClientID%>').value;
    var l = document.getElementById('<%=txtCNOtherCharges.ClientID%>').value;

    var add = Math.floor(a) + Math.floor(b) + Math.floor(c) + Math.floor(d) + Math.floor(e) + Math.floor(f) + Math.floor(g) + Math.floor(h) + Math.floor(ap);
var less = Math.floor(i) + Math.floor(j)+ Math.floor(k )+ Math.floor(l);
var cal=(add )-(less );
var net = Math.floor(a) + Math.floor(ap);

document.getElementById('<%=txtCNBillValue.ClientID%>').value = cal;

    document.getElementById('<%=txtNetPrice.ClientID%>').value = net;
	return false;
	 return true;
}

     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode != 46 && charCode > 31
           && (charCode < 48 || charCode > 57))
             return false;

         return true;
     }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <br /><br /><br /><br /><br /><br />
    <div style="float:left">
    <UES:DashboardMenuBar runat="server" ID="DashboardMenuBar" />
        </div>

<table >
<tr>
<td>
<table  cellpadding="0px" cellspacing="0px" align="center" width="695px">
        
        <tr>
            <td colspan="3" align="center">
                
                        &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;
                
                        </td>
                        
                      
  
        </tr>
        <tr><td align="center">
                                          
            </td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                        Transporter Bill Details</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                             <tr>
                                                                <td> Project Name :
                                                                   
                                                                     <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="243px"  Visible="false" ></asp:TextBox>
                                                                    <asp:DropDownList ID="ddl_ProjectName"  class="selectpicker" data-live-search-style="begins" data-live-search="true" Width="150px"  AutoPostBack ="true" runat="server" OnSelectedIndexChanged="ddl_ProjectName_SelectedIndexChanged"></asp:DropDownList>
                                                                
                                                                </td>
                                                                 <td> Project No :
                                                                     <asp:DropDownList ID="ddl_ProjectNo" Width="150px" AutoPostBack ="true"  runat="server" OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="lblBillNo" runat="server" Text="Bill No" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                    <asp:DropDownList ID="ddlBillNo" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddlBillNo_SelectedIndexChanged" > 
                          
                        </asp:DropDownList></td>
                                                                <td class="style3"  >
                                                                    BillDate<br />
                                                                    <asp:TextBox ID="txtdate" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" Enabled="false"></asp:TextBox>
                                                                     <br />
                                                                   </td>
                                                                <td class="style4"   >
                                                                    <br />
                                                                    Confirm No<br />
                                                                    <asp:TextBox ID="txtConfirmno" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" Enabled="false"></asp:TextBox>
                                                                    
</td>
                                                                 <td class="style3">
                                                                    <br />
                                                                    Transporter<br />
                                                                    <asp:TextBox ID="txt_Transporter" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" Enabled="false"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Vehicle Type <br />
                                                                    <asp:TextBox ID="txttrucktype" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    LR Number<br />
                                                                    <asp:TextBox ID="txtLRNo" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    
                                                                     LR Date<br />
                                                                    <asp:TextBox ID="txtLRDate" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    
                                                                    Vehicle No<br />
                                                                    <asp:TextBox ID="txtRCDate" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    From<br />
                                                                    <asp:TextBox ID="txtfrom" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> 
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    To<br />
                                                                    <asp:TextBox ID="txtto" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Submission Address<br />
                                                                    <asp:TextBox ID="txtaddress" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px" TextMode ="MultiLine" Height="45px" 
                                                                        Width="122px"></asp:TextBox>

                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Remarks<br />
                                                                    <asp:TextBox ID="txtRemarks" runat="server"  BorderColor="Black" Enabled="false"
                                                                         BorderStyle="Solid" BorderWidth="1px" TextMode ="MultiLine" Height="43px" 
                                                                         Width="124px" ></asp:TextBox>

                                                                    

                                                                     </td>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Contract Price<br />
                                                                     <asp:TextBox ID="txtbasicfreight" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                     Detention at Loading (charges)<br />
                                                                     <asp:TextBox ID="txtloadingdetention" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Detention at Unloading (charges)<br />
                                                                     <asp:TextBox ID="txtunloadingdetention" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                         Loading Charges<br />
                                                                     <asp:TextBox ID="txtLoadingCharges" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Unloading Charges<br />
                                                                     <asp:TextBox ID="txtunloadingCharges" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    RTO<br />
                                                                     <asp:TextBox ID="txtoctroid" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Dimension Difference<br />
                                                                     <asp:TextBox ID="txtDimensionDiff" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)"  onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                       Other Claims<br />
                                                                     <asp:TextBox ID="txtOtherClaims" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    <asp:Label ID="Label1" runat="server" Font-Size="8pt" ForeColor="Red" 
                                                                        Text="LESS"></asp:Label>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    
<asp:Label ID="lblBillID" runat="server" ForeColor="White"></asp:Label>
                                                                </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    &nbsp;</td>
                                                                     <td class="style3">
                                                                    

                                                                         &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    Insurance<br />
                                                                    <asp:TextBox ID="txtinsurance" runat="server" BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    

                                                                    
                                                                    <br />
                                                                    

                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Damages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtDamages" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                </td>
                                                               
                                                                <td class="style4">
                                                                    Shortages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtshortages" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                        
                                                                         <asp:Label ID="lblclientID" runat="server" ForeColor="White" Text="Label"></asp:Label>
                                                                    
                                                                         </td>
                                                                     <td class="style3">
                                                                    

                                                                    OtherCharges<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtOtherCharges" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>

                                                                    
                                                                     </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
                                                                    BillImage<br />
                                                                       <a href="BillPreview.aspx" onClick="return popup(this, 'notes') " target="_blank"> 
 <asp:Image ID="BillImage" runat="server"  Width="150px" Height="60px"  /></a>
                                                                   
</td>
                                                                <td class="style3">
                                                                    
                                                                    <asp:Label ID="lblbillValue" runat="server" Font-Names="Arial" Font-Size="15pt" 
                                                                        ForeColor="Red" Text="Net Bill Value"></asp:Label>
                                                                    <br />
                                                                    
                                                                     <asp:TextBox ID="txtbillvalue" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                    

                                                                    
                                                                </td>
                                                               
                                                                <td class="style4">
                                                                    
                                                                     &nbsp;</td>
                                                                     <td class="style3">
                                                                    

                                                                         &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
               
    </table>
    </table>
 </td>
 <td>
 <table  cellpadding="0px" cellspacing="0px" align="center" width="695px">
        
        <tr>
            <td colspan="3" align="center">
                        &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;
                        </td>
                        
                      
  
        </tr>
        <tr><td align="center">
                                           
            </td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                       Bill Matching Process By Client  </td>
                    
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                                                                    ConfirmNo&nbsp;<br />
                                                                    <asp:TextBox ID="TxtCNconfirmno" runat="server" BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    <br />
                                                                    </td>
                                                                <td class="style3"  >
                                                                    CollectionNote No<br />
                                                                    <asp:TextBox ID="txtCNNumber" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                   </td>
                                                                <td class="style4"   >
                                                                    CollectionNote Date<br />
                                                                    <asp:TextBox ID="txtCNDate" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                    
</td>
                                                                <td class="style3">
                                                                    AutoNumber<br />
                                                                    <asp:TextBox ID="txtautonumber" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    <br />
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Project No<br />
                                                                    <asp:TextBox ID="txtprojectno" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    WBS&nbsp; Number<br />
                                                                    <asp:TextBox ID="txtwbsno" runat="server" Enabled="false"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    
                                                                     Description<br />
                                                                    <asp:TextBox ID="txtdescription" runat="server" Enabled="false"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    
                                                                    Transit Days<br />
                                                                    <asp:TextBox ID="txttransitdays" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     <br />
                                                                    
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    From<br />
                                                                    <asp:TextBox ID="txtCNfrom" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> 
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    To<br />
                                                                    <asp:TextBox ID="txtCNTO" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Vehicle Type<br />
                                                                    <asp:TextBox ID="txtCNTruckType" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Vehicle Planned (nos)<br />
                                                                    <asp:TextBox ID="txtCNVehiclePlanned" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" 
                                                                             BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                                                                        
                                                            <tr>
                                                                <td class="style3">
                                                                    Length-RC<br />
                                                                    <asp:TextBox ID="txtLength" runat="server" Enabled="false" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Width-RC<br />
                                                                    <asp:TextBox ID="txtWidth" runat="server" Enabled="false" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Height-RC<br />
                                                                    <asp:TextBox ID="txtHeight" runat="server" Enabled="false" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Total Weight-RC<br />
                                                                    <asp:TextBox ID="txtTotalWeight" runat="server" Enabled="false"  BorderColor="Black" BorderStyle="Solid" 
                                                                             BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                                                                        
                                                            <tr>
                                                                <td class="style3">
                                                                    Consignor Name<br />
                                                                    <asp:TextBox ID="txtBuyer" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Consignor Contact Person<br />
                                                                    <asp:TextBox ID="txtContactPerson" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Consignor Contact No<br />
                                                                    <asp:TextBox ID="txtContactNo" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                 <td class="style3">
                                                                         Transporter<br />
                                                                    <asp:TextBox ID="txt_CliTransporter" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>

                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Contract Price (A) <br />
                                                                     <asp:TextBox ID="txtCNBascicFreight" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Enabled="false" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Increase Price (B)<br />
                                                                     <asp:TextBox ID="txtApprovedPRice" runat="server"  Enabled="true"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                                                        onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Revised Price (A+B)<br />
                                                                     <asp:TextBox ID="txtNetPrice" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                                                        onkeypress="return onlynumber(event)" onkeyup="return calculation(event)" ReadOnly="true"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                         
                                                                         Length-Actual<br />
                                                                         <asp:TextBox ID="txt_ActLength" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                                                         <br />
                                                                         Width-Actual<br />
                                                                         <asp:TextBox ID="txt_ActWidth" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                                                    
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Detention at Loading (charges)<br />
                                                                     <asp:TextBox ID="txtCNLoadingDetention" runat="server" Enabled="true" Text ="0"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Detention at Unloading (charges) <br />
                                                                     <asp:TextBox ID="txtCNunloadingdetention" runat="server" Enabled="true" Text ="0"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Loading Charges<br />
                                                                     <asp:TextBox ID="txtCNLoadingCharges" runat="server" Enabled="true" Text ="0"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    
                                                                         Height-Actual<br />
                                                                         <asp:TextBox ID="txt_ActHeight" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                                                         <br />
                                                                         Total Weight-Actual<br />
                                                                         <asp:TextBox ID="txt_ActTotWeight" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Unloading Charges<br />
                                                                     <asp:TextBox ID="txtCNUNLoadingCharges" runat="server" Enabled="True" Text ="0"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    RTO<br />
                                                                     <asp:TextBox ID="txtCNOctroid" runat="server"  Text ="0"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Dimension Difference<br />
                                                                     <asp:TextBox ID="txtCNDimensionDiff" runat="server"  Text ="0"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)"  onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                       Other Claims<br />
                                                                     <asp:TextBox ID="txtCNOtherClaims" runat="server"  Text ="0"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    <asp:Label ID="lblless" runat="server" Font-Size="8pt" ForeColor="Red" 
                                                                        Text="LESS DEDUCTION"></asp:Label>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    
<asp:Label ID="Label4" runat="server" ForeColor="White"></asp:Label>
                                                                </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                  <asp:LinkButton ID="LinkHistory" runat="server" onclick="LinkHistory_Click">View WorkFlow</asp:LinkButton></td>
                                                                     <td class="style3">
                                                                    

                                                                         &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    Insurance<br />
                                                                    <asp:TextBox ID="txtCNInsurance" runat="server" BorderColor="Black"  Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    

                                                                    
                                                                    <br />
                                                                    

                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Damages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtCNDamages" runat="server"  BorderColor="Black"  Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                </td>
                                                               
                                                                <td class="style4">
                                                                    Shortages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtCNShortages" runat="server"  BorderColor="Black"  Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                        
                                                                         <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Label"></asp:Label>
                                                                    
                                                                         </td>
                                                                     <td class="style3">
                                                                    

                                                                    OtherCharges<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtCNOtherCharges" runat="server"  BorderColor="Black"  Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>

                                                                    
                                                                     </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
                                                                     <asp:Label ID="lblCNBillValue" runat="server" Font-Names="Arial" Font-Size="15pt" 
                                                                        ForeColor="Red" Text="Net Bill Value"></asp:Label>
                                                                    <br />
                                                                    
                                                                     <asp:TextBox ID="txtCNBillValue" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                    

                                                                   
</td>
                                                                <td class="style3">
                                                                    
                                                                    Thermax Logistics Remarks
                                                                  <br />
                    <asp:CheckBoxList ID="ChkAARMSRemarks" runat="server" Height="44px">
                    <asp:ListItem Value="0" Text="Bill Matched"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Loading and Unloading Photos Matched"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Discrepancy in Bill"></asp:ListItem>
                    
                    
                    </asp:CheckBoxList>
                                                                   
                                                                   <br />
                                                                    <asp:TextBox ID="txtaarmsRemarks" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                                                                    
                                                                </td>
                                                               
                                                                <td class="style4">
                                                                    
                                                                    Checked by
                                                                     <asp:TextBox ID="txtcheckedby" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
                                                                           &nbsp;<asp:Button ID="ButValidated" runat="server" Text="Submit" OnClick="ButValidated_Click" />
                                                                        </td>
                                                                     <td class="style3">
                                                                    

                                                                         
                                                                         <UES:ESign ID="Esign" runat="server" />
                                                                         
                                                                         
                                                                         </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
               
    </table>
    </table>
 
 </td>
 </tr>
 </table>
</asp:Content>


