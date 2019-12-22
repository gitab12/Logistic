
<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDetails.aspx.cs" Inherits="ViewDetails" %>
<%@ Register Src="~/UserControl/MenuBar.ascx" TagName="menu" TagPrefix="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
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


       
          .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    Width :810px;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        background:rgba(217, 211, 182, 0.30);
        /*background:rgba(248, 127, 10, 0.60);*/
    }
    .mapinnerdiv {
    margin:5px;

    padding:0;
    Width :800px;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        /*background:rgba(26, 154, 228, 0.87);*/
        background:rgb(255, 255, 255);
    }


        </style>
        
       <script type="text/javascript">
<!--
           function popup(mylink, windowname) {
               if (!window.focus) return true;
               var href;
               if (typeof (mylink) == 'string')
                   href = mylink;
               else
                   href = mylink.href;
               window.open(href, windowname, 'width=900,height=1000,scrollbars=yes');
               return false;
           }
//-->
</SCRIPT>
<style type="text/css">
    .color {
     font-family: Arial, Helvetica, sans-serif;
     font-size: 2.0em;
     font-style: bold;
     color:Red;
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
<div style="margin-left:450px"><h2 class="title-one">View Confirmation Details</h2></div>
<%--<menu:menu ID="Menu" runat="server" />
<br />
<br />--%>
    <div style="margin-left:250px">
     <div class ="mapouterdiv" >
              <div class ="mapinnerdiv" >
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
                                           
            &nbsp;</td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red;font:bolder" >
                                                        Trip Details</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="lblConfirm" runat="server" Text="Cofirm No" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                     <%--<asp:TextBox ID="txtCofirmNo" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>--%>
                                                             <asp:DropDownList ID="ddlConfirmNo" runat="server" Width="125px" AutoPostBack="true" onselectedindexchanged="ddlConfirmNo_SelectedIndexChanged">
                                                             </asp:DropDownList> 
<br />                                    
                     </td>
                                                                <td class="style3"  >
                                                                    Client 
                                                                    <asp:TextBox ID="txtclient" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                                <td class="style3"   >
                                                                    Transporter<br />  <asp:TextBox ID="txtTransporter" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                    <span >Assigned Date<br />
                                                                    </span><asp:TextBox ID="txtassignedDate" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
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
                                                                    Truck type <br />
                                                                    <asp:TextBox ID="txttrucktype" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Enclosure Type<br />
                                                                    <asp:TextBox ID="txtEnclosure" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    Capacity<br />
                                                                    <asp:TextBox ID="txtcapacity" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                     </td>
                                                                <td class="style3">
                                                                    Truck Image<br />
                                                                    <a href="TruckImage.aspx" onClick="return popup(this, 'notes')"> 
 <asp:Image ID="TruckImage" runat="server"  Width="150px" Height="60px" /></a>
                                              </td>
                                                               <td class="style3">
                                                                   <br />
                                                                     </td>
                                                                <td class="style3">
                                                                   <asp:Button ID="ButShow" runat="server" onclick="ButShow_Click" Visible="false" Text="Show" />
                                                                    </td>
                                                            </tr>
       
                                                                
                                                        </table>
                                                    </td>
                                                </tr>
                                                
               
    </table>
    </table>
    
    
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
                                           
            &nbsp;</td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                        Shipping Details</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="Label1" runat="server" Text="Cofirm No" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                    <asp:Label ID="lblshippingConfirmNo" runat="server" Text="" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:Label>                                     
                     </td>
                                                                <td class="style3"  >
                                                                    ConFirmationDate 
                                                                    <asp:TextBox ID="txtCofirmDate" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                                <td class="style3"   >
                                                                    TravelDate<br />  <asp:TextBox ID="txttravelDate" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                    <span >Vehicle No<br />
                                                                    </span><asp:TextBox ID="txtVehicleNo" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    DriverName<br />
                                                                    <asp:TextBox ID="txtDriverName" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    LoadingStatus<br />
                                                                    <asp:TextBox ID="txtLoadingStatus" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    Loading Time <br />
                                                                    <asp:TextBox ID="txtLoadingtime" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                   Trip Time<br />
                                                                    <asp:TextBox ID="txtTripTime" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    LR Number<br />
                                                                    <asp:TextBox ID="txtLRNumber" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                     </td>
                                                                <td class="style3">
                                                                    Delivery Date<br />
                                                                    <asp:Label ID="lbldeliverydate" runat="server" Text=""></asp:Label>
                                                                     </td>
                                                               <td class="style3">
                                                                   Received Date<br />
                                                                    <asp:Label ID="lblReceiveddate" runat="server" Text=""></asp:Label>
                                                                     </td>
                                                                <td class="style3">
                                                                    &nbsp;</td>
                                                            </tr>
       
                                                                
                                                        </table>
                                                    </td>
                                                </tr>
                                                
               
    </table>
    </table>
    
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
                                           
            &nbsp;</td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                        Bill Submission</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="lblBillsub" runat="server" Text="Cofirm No" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                    <asp:Label ID="lblBillSubConfirmNo" runat="server" Text="" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:Label>                                     
                     </td>
                                                                <td class="style3"  >
                                                                    BillNo 
                                                                    <asp:TextBox ID="txtSbillNo" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                                <td class="style3"   >
                                                                    Bill Value<br />  <asp:TextBox ID="txtSBillValue" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                    <span >Bill Date<br />
                                                                    </span><asp:TextBox ID="txtSBillDate" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Remarks<br />
                                                                    <asp:TextBox ID="txtSRemarks" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    <br />
                                                                    
                                                                     </td>
                                                               <td class="style3">
                                                                      <br />
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                     <br />
                                                                    
                                                                     </td>
                                                            </tr>
                                                            
                                                           
                                                                
                                                        </table>
                                                    </td>
                                                </tr>
                                                
               
    </table>
    </table>
    
    
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
                                           
            &nbsp;</td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                        Bill Payment</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="Label2" runat="server" Text="Cofirm No" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                    <asp:Label ID="lblBPConfirmNo" runat="server" Text="" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:Label>                                     
                     </td>
                                                                <td class="style3"  >
                                                                    BillNo 
                                                                    <asp:TextBox ID="txtbpBillno" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                                <td class="style3"   >
                                                                    Bill Payment Value<br />  <asp:TextBox ID="txtBillPaid" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                    <span >Payment Date<br />
                                                                    </span><asp:TextBox ID="txtPaymentdate" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Mode of Payment<br />
                                                                    <asp:TextBox ID="txtBPModeofpayment" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Cheque No<br />
                                                                    <asp:TextBox ID="txtBPChequeno" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                     Cheque Date <br />
                                                                    <asp:TextBox ID="txtBPChequeDate" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                     Remarks<br />
                                                                    <asp:TextBox ID="txtBPRemarks" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                           
                                                                
                                                        </table>
                                                    </td>
                                                </tr>
                                                
               
    </table>
    </table>
           
                  </div> </div> 
        </div>
    <br /><br /><br />    <br /><br /><br />

</asp:Content>