
<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TripAssignConfirmationWindow.aspx.cs" Inherits="TripAssignConfirmationWindow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
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
        </style>
    <script src="http://code.jquery.com/jquery-latest.js"></script>
<script type='text/javascript'>
    $(function () {
        // To disable f5
        $(document).bind("keydown", disableF5);
    });

    //Function to handle disabling F5
    function disableF5(e) {
        if ((e.which || e.keyCode) == 116)
            //alert("shyam");
            //window.open("http://viralpatel.net/blogs/", "mywindow", "status=1,toolbar=0");
            e.preventDefault();
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <br /><br /><br /><br /><br />
    <div style="margin-left:300px">
  <asp:ScriptManager ID="ScriptManager1" runat="server">

   
    </asp:ScriptManager>
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
                                                        Collection Note</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="lblConfirm" runat="server" Text="Project No" Font-Bold="true"></asp:Label><br />
                                                                    <asp:TextBox ID="txtprojectNo" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ReadOnly="true"></asp:TextBox> 
                        &nbsp;<br />
                                                                    </td>
                                                                <td class="style3"  >
                                                                    WBS No<br />
                                                                    <asp:TextBox ID="txtwbsNo" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>                            
                                                                  </td>
                                                                <td class="style3"   >
                                                                    CNote Number<br />
                                                                    <asp:TextBox ID="txtautonumber" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                    <span >Transporter<br />
                                                                    </span><asp:TextBox ID="txtTransporter" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"  ></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Project Name<br />
                                                                    <asp:TextBox ID="txtproject" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Description<br />
                                                                    <asp:TextBox ID="txtDescription" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    Truck type <br />
                                                                    <asp:TextBox ID="txttrucktype" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Tansit Days<br />
                                                                    <asp:TextBox ID="txttransit" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                From<br />
                                                                    <asp:TextBox ID="txtFrom" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                To<br />
                                                                    <asp:TextBox ID="txtTo" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                               DateofIssue<br />
                                                                    <asp:TextBox ID="txtDateofIssue" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                Trucks Planned<br />
                                                                    <asp:TextBox ID="txtTruckPlanned" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    Length<br />
                                                                    <asp:TextBox ID="txtlength" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    <br />
                                                                     </td>
                                                                <td class="style3">
                                                                    width<br />
                                                                    <asp:TextBox ID="txtwidth" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                   Height<br />
                                                                    <asp:TextBox ID="txtheight" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    TotalWeight<br />
                                                                    <asp:TextBox ID="txtweight" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Vendor<br />
                                                                    <asp:TextBox ID="txtBuyer" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Contact Person<br />
                                                                    <asp:TextBox ID="txtContactperson" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                   Contact Number
                                                                   <asp:TextBox ID="txtcontactno" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                                <td class="style3">
                                                                    Remarks
                                                                   <asp:TextBox ID="txtremarks" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    Buyer<br />
                                                                    <asp:TextBox ID="txt_Buyername" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Buyer Contact No<br />
                                                                    <asp:TextBox ID="txt_Buyerno" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                   Project Manager<br />
                                                                    <asp:TextBox ID="txt_Projectmanagername" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Project Manager No<br />
                                                                    <asp:TextBox ID="txt_Projectmanagerno" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    Date of Vehicle Placement<br />
                                                                    <asp:TextBox ID="txtdate" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>                                          <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px" 
                />           <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtdate">                
    </ajaxtoolkit:calendarextender>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                Agreed Price<br />
                                                                    <asp:TextBox ID="txtagreedprice" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    <asp:Label ID="lbl_CnGeneratedBy" runat="server" Visible="false" Font-Bold="true" ></asp:Label>
                                                                    <br /></td>
                                                                <td class="style3">
                                                                    <asp:Button ID="But_Submit" runat="server" Text="Confirm" 
                                                                        onclick="But_Submit_Click" />
                                                                    <br />
                                                                    <asp:Button ID="But_Abandoned" runat="server" Text="Amendment" 
                                                                      onclick="But_Abandoned_Click"  Visible="false"  />
                                                                     </td>
                                                            </tr>
                                                                        </table>
                                                    </td>
                                                </tr>
               
    </table>
    </table>
        </div>

    <br /><br /><br />
</asp:Content>