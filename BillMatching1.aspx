<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BillMatching1.aspx.cs" Inherits="BillMatching1" %>

<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagPrefix="uc1" TagName="DashboardMenuBar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
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
    window.onload = function () {
        new JsDatePick({
            useMode: 2,
            target: "inputField",
            dateFormat: "%d-%M-%Y"

        });
    };
</script>
<script language="javascript" type="text/javascript">
     //Calculation of Total Cost
     function calculation(evt) {

         var a = document.getElementById('<%=txtbasicfreightc.ClientID%>').value; 
    var b = document.getElementById('<%=txtloadingdetentionc.ClientID%>').value;
    var c = document.getElementById('<%=txtunloadingdetentionc.ClientID%>').value;
    var d = document.getElementById('<%=txtLoadingChargesc.ClientID%>').value;
    var e = document.getElementById('<%=txtunloadingChargesc.ClientID%>').value;
    var f = document.getElementById('<%=txtoctroidc.ClientID%>').value;
    var g = document.getElementById('<%=txtDimensionDiffc.ClientID%>').value;
    var h = document.getElementById('<%=txtOtherClaimsc.ClientID%>').value;
         var ap = 0;

    var i = document.getElementById('<%=txtinsurancec.ClientID%>').value;
    var j = document.getElementById('<%=txtDamagesc.ClientID%>').value;
    var k = document.getElementById('<%=txtshortagesc.ClientID%>').value;
    var l = document.getElementById('<%=txtOtherChargesc.ClientID%>').value;

    var add = Math.floor(a) + Math.floor(b) + Math.floor(c) + Math.floor(d) + Math.floor(e) + Math.floor(f) + Math.floor(g) + Math.floor(h) + Math.floor(ap);
    var less = Math.floor(i) + Math.floor(j) + Math.floor(k) + Math.floor(l);
    var cal = (add) - (less);

    document.getElementById('<%=txtbillvaluec.ClientID%>').value = cal;
return false;
return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br /><br />
    <div style="float:left">
        <uc1:DashboardMenuBar runat="server" ID="DashboardMenuBar" />
        </div>
    <br />
    <br />
    <table >
          <br />
<tr>
<td>
<table  cellpadding="0px" cellspacing="0px" align="center" width="695px">
        
        <tr>
            <td colspan="3" align="center">
                 <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
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
                                                        Transporter Bill Details </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
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
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                   </td>
                                                                <td class="style4"   >
                                                                    <br />
                                                                    Confirm No<br />
                                                                    <asp:TextBox ID="txtConfirmno" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                    <br />
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Truck type <br />
                                                                    <asp:TextBox ID="txttrucktype" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    LR Number<br />
                                                                    <asp:TextBox ID="txtLRNo" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    
                                                                     LR Date<br />
                                                                    <asp:TextBox ID="txtLRDate" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    
                                                                    Vehicle<br />
                                                                    <asp:TextBox ID="txtRCDate" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    From<br />
                                                                    <asp:TextBox ID="txtfrom" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> 
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    To<br />
                                                                    <asp:TextBox ID="txtto" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Submission Address<br />
                                                                    <asp:TextBox ID="txtaddress" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" TextMode ="MultiLine" Height="45px" 
                                                                        Width="122px"></asp:TextBox>

                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Remarks<br />
                                                                    <asp:TextBox ID="txtRemarks" runat="server"  BorderColor="Black" 
                                                                         BorderStyle="Solid" BorderWidth="1px" TextMode ="MultiLine" Height="43px" 
                                                                         Width="124px" ></asp:TextBox>

                                                                    

                                                                     </td>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Basic Freight<br />
                                                                     <asp:TextBox ID="txtbasicfreight" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Loading Detention<br />
                                                                     <asp:TextBox ID="txtloadingdetention" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                   Unloading Detention<br />
                                                                     <asp:TextBox ID="txtunloadingdetention" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                         Loading Charges<br />
                                                                     <asp:TextBox ID="txtLoadingCharges" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Unloading Charges<br />
                                                                     <asp:TextBox ID="txtunloadingCharges" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Octroid<br />
                                                                     <asp:TextBox ID="txtoctroid" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Dimension Difference<br />
                                                                     <asp:TextBox ID="txtDimensionDiff" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)"  onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                       Other Claims<br />
                                                                     <asp:TextBox ID="txtOtherClaims" runat="server" 
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
                                                                    <asp:TextBox ID="txtinsurance" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    

                                                                    
                                                                    <br />
                                                                    

                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Demages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtDamages" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                </td>
                                                               
                                                                <td class="style4">
                                                                    Shortages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtshortages" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                        
                                                                         <asp:Label ID="lblclientID" runat="server" ForeColor="White" Text="Label"></asp:Label>
                                                                    
                                                                         </td>
                                                                     <td class="style3">
                                                                    

                                                                    OtherCharges<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtOtherCharges" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>

                                                                    
                                                                     </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
                                                                    BillImage<br />
                                                                       <a href="BillPreview.aspx" onClick="return popup(this, 'notes')"> 
 <asp:Image ID="BillImage" runat="server"  Width="150px" Height="60px" /></a>
                                                                   
</td>
                                                                <td class="style3">
                                                                    
                                                                    <asp:Label ID="lblbillValue" runat="server" Font-Names="Arial" Font-Size="15pt" 
                                                                        ForeColor="Red" Text="Net Bill Value"></asp:Label>
                                                                    <br />
                                                                    
                                                                     <asp:TextBox ID="txtbillvalue" runat="server" 
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
                        </td>
                        
                      
  
        </tr>
        <tr><td align="center">
                                           
            </td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                        Client Bill Details <br /> <p style="color:black">Multiple LR</p> <asp:CheckBoxList ID="chkbl_MultipleLR" runat ="server" ForeColor ="Black" >
                                                           
                                                                                                    </asp:CheckBoxList></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="lblBillNoc" runat="server" Text="Bill No" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                    <asp:TextBox ID="txtBillNoc" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                </td>
                                                                <td class="style3"  >
                                                                    BillDate<br />
                                                                    <asp:TextBox ID="txtdatec" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                   </td>
                                                                <td class="style4"   >
                                                                    Confirm No<br />
                                                                    <asp:TextBox ID="txtConfirmnoc" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                   InvoiceNo/CollectionNote Number <br />
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Truck type <br />
                                                                    <asp:TextBox ID="txttrucktypec" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    LR Number<br />
                                                                    <asp:TextBox ID="txtLRNoc" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    
                                                                     LR Date<br />
                                                                    <asp:TextBox ID="txtLRDatec" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    
                                                                   Vehicle<br />
                                                                    <asp:TextBox ID="txtRCDatec" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    From<br />
                                                                    <asp:TextBox ID="txtfromc" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> 
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    To<br />
                                                                    <asp:TextBox ID="txttoc" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Submission Address<br />
                                                                    <asp:TextBox ID="txtaddressc" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" TextMode ="MultiLine" Height="45px" 
                                                                        Width="122px"></asp:TextBox>

                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Remarks<br />
                                                                    <asp:TextBox ID="txtRemarksc" runat="server"  BorderColor="Black" 
                                                                         BorderStyle="Solid" BorderWidth="1px" TextMode ="MultiLine" Height="43px" 
                                                                         Width="124px" ></asp:TextBox>

                                                                    

                                                                     </td>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Basic Freight<br />
                                                                     <asp:TextBox ID="txtbasicfreightc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Loading Detention<br />
                                                                     <asp:TextBox ID="txtloadingdetentionc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                   Unloading Detention<br />
                                                                     <asp:TextBox ID="txtunloadingdetentionc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                         Loading Charges<br />
                                                                     <asp:TextBox ID="txtLoadingChargesc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Unloading Charges<br />
                                                                     <asp:TextBox ID="txtunloadingChargesc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Octroid<br />
                                                                     <asp:TextBox ID="txtoctroidc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Dimension Difference<br />
                                                                     <asp:TextBox ID="txtDimensionDiffc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)"  onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                       Other Claims<br />
                                                                     <asp:TextBox ID="txtOtherClaimsc" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    <asp:Label ID="Label2" runat="server" Font-Size="8pt" ForeColor="Red" 
                                                                        Text="LESS"></asp:Label>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    
<asp:Label ID="lblBillIDc" runat="server" ForeColor="White"></asp:Label>
                                                                </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    &nbsp;</td>
                                                                     <td class="style3">
                                                                    

                                                                         &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    Insurance<br />
                                                                    <asp:TextBox ID="txtinsurancec" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    

                                                                    
                                                                    <br />
                                                                    

                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Demages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtDamagesc" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                </td>
                                                               
                                                                <td class="style4">
                                                                    Shortages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtshortagesc" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                        
                                                                         <asp:Label ID="lblclientIDc" runat="server" ForeColor="White" Text="Label"></asp:Label>
                                                                    
                                                                         </td>
                                                                     <td class="style3">
                                                                    

                                                                    OtherCharges<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtOtherChargesc" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>

                                                                    
                                                                     </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
                                                                    <asp:Label ID="lblbillValuec" runat="server" Font-Names="Arial" Font-Size="15pt" 
                                                                        ForeColor="Red" Text="Net Bill Value"></asp:Label>
                                                                    <br />
                                                                    
                                                                     <asp:TextBox ID="txtbillvaluec" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                    

                                                                    
</td>
                                                                <td class="style3">
                                                                    AARMS Remarks
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
                                                                    
                                                                    Checked by AARMS
                                                                     <asp:TextBox ID="txtcheckedby" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                        </td>
                                                                     <td class="style3">
                                                                    

                                                                         <asp:Button ID="ButValidated" runat="server" Text="Submit" OnClick="ButValidated_Click" />
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


