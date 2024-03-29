<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="LogisticsPlan.aspx.cs" Inherits="LogisticsPlan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>



<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
            
                <meta name="keywords" content="BizConnect, Supply Chain Management, Road Transports, Indian Road Transportation, Supply Demand Matching, Trucks Available, Trucks Wanted, Goods Transport, Logistics"  />
	<meta name="description" content="SCM Junction is an initiative from AARM SCM Solutions Pvt. Ltd., Bengaluru, India; to build a logistics open platform to match supply and demand of road transportation in India." />
	<meta name="author" content="AARM SCM Solutions Pvt. Ltd." />
	<meta name="robots" content="ALL"/>
	<meta name="revisit-after" content="1 days"/>
	<meta name="classification" content="Website, Corporate"/>
	<meta name="distribution" content="Global"/>
	<meta name="rating" content="General"/>
	<meta name="copyright" content="Copyright (C) 2010, AARM SCM Solutions Pvt. Ltd." />
	<meta name="language" content="English"/>
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
<%--    <script language="javascript" type="text/javascript" src="Scripts/dhtmlgoodies_calendar.js">
</script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
                           var xPos, yPos;
                           var prm = Sys.WebForms.PageRequestManager.getInstance();
                           prm.add_beginRequest(BeginRequestHandler);
                           prm.add_endRequest(EndRequestHandler);
                           function BeginRequestHandler(sender, args) {
                               xPos = $get('ctl00_ContentPlaceHolder1_PanelShipmentDetails').scrollLeft;
                               yPos = $get('ctl00_ContentPlaceHolder1_PanelShipmentDetails').scrollTop;
                           }
                           function EndRequestHandler(sender, args) {
                               $get('ctl00_ContentPlaceHolder1_PanelShipmentDetails').scrollLeft = xPos;
                               $get('ctl00_ContentPlaceHolder1_PanelShipmentDetails').scrollTop = yPos;
                           }
    </script>

<%--<link type="text/css" rel="stylesheet" href="Scripts/dhtmlgoodies_calendar.css?random=20051112" media="screen"></link>
--%>    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-left:350px">
           <table style=" width:50%; height:100%;">
                <tr>
                    <td align="right">
                      <%-- <asp:LinkButton ID="LinkButton2" runat="server">Multiple Posting</asp:LinkButton>--%>
                       <a href="multipleposting.aspx">Multiple Posting</a>
                    </td>
                </tr>
                <tr>
                    <td style="background-color:#FA0000">
                        <asp:Label ID="lblLogisticsPlanTitle" runat="server" Font-Bold="True" 
                            Font-Size="10pt" ForeColor="White" Text="Posting Logistics Plan" 
                            Width="139px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="PanelShipmentDetails" runat="server" BackColor="White" 
                            BorderColor="White" BorderWidth="1px" Font-Bold="True" 
                            GroupingText="Logistics Details" Height="630px" Width="682px">
                            <table style="width:665px; ">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLogisticsPlanNoTitle" runat="server" Font-Bold="False" 
                                            ForeColor="#000005" Text="Plan No" Width="46px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLogisticsPlaneNo" runat="server" Font-Bold="True" 
                                            ForeColor="Red" Text="0000" Width="242px"></asp:Label>
                                    </td>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lblLogisticsTypeTitle" runat="server" Font-Bold="False" 
                                            ForeColor="#000005" Text="Logistics Type" Width="100px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTripDateTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Trip Date" Width="56px"></asp:Label>
                                    </td>
                                    <td>
                                      <asp:TextBox ID="txtTravelDate" runat="server" BorderWidth="1px" 
                                            CssClass="txtbox" onKeyPress="return lock(event)" ValidationGroup="a" 
                                            Width="148px"></asp:TextBox>&nbsp;

<asp:ImageButton ID="imgdate1" runat="server" 
                                            ImageUrl="~/images/Calendar_scheduleHS.png" width="17px" height= "17px" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgdate1" TargetControlID="txtTravelDate">                
                                            </ajaxToolkit:CalendarExtender></td>
                                    <td>
                                        <asp:RadioButton ID="RadioButtonSale" runat="server" AutoPostBack="True" 
                                            Font-Bold="False" oncheckedchanged="RadioButtonSale_CheckedChanged" 
                                            Text="Sale" GroupName="a" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButtonTransfer" runat="server" AutoPostBack="True" 
                                            Font-Bold="False" oncheckedchanged="RadioButtonTransfer_CheckedChanged" 
                                            Text="Transfer" GroupName="a" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblMessageTop" runat="server" ForeColor="Red" Width="320px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="false">
                                            <ProgressTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                                                <img src="images/ajax-loader.gif" />
                                                <font color="red">Loading...</font>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="background-color: #003980">
                                        <asp:Label ID="lblShipmentFromTitle" runat="server" Font-Bold="True" 
                                            ForeColor="White" style="margin-left: 0px" Text="Shipment From" Width="127px"></asp:Label>
                                    </td>
                                    <td align="center" colspan="2" style="background-color: #003980">
                                        <asp:Label ID="lblShipmentToTitle" runat="server" Font-Bold="True" 
                                            ForeColor="White" Text="Shipment To" Width="106px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="365px" 
                                            Width="313px">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCode1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Code" Width="33px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCode1" runat="server" Font-Bold="True" Font-Size="10pt" 
                                                            ForeColor="#003366" style="margin-left: 0px" Width="150px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblName1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Name" Width="36px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpName1" runat="server" AutoPostBack="True" 
                                                            Width="176px" >
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLocationType1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Location" Width="50px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpLocationType1" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationType1_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLocation1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="City" Width="51px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpLocationCity1" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationCity1_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtLocationCity1" runat="server" BorderWidth="1px" 
                                                            MaxLength="50" onKeyPress="return onlyalpha(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLocationAddress1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Address" Width="46px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpLocationAddress1" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationAddress1_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtLocationAddress1" runat="server" BorderWidth="1px" 
                                                            Height="23px" MaxLength="500" TextMode="MultiLine" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLocationState1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Height="19px" Text="State" Width="32px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLocationState1" runat="server" BorderWidth="1px" 
                                                            onKeyPress="return onlyalpha(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLocationCountry1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Country" Width="47px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLocationCountry1" runat="server" BorderWidth="1px" 
                                                            onKeyPress="return onlyalpha(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLocationPinCode1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Pin Code" Width="60px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLocationPinCode1" runat="server" BorderWidth="1px" 
                                                            MaxLength="7" onKeyPress="return onlynumber(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBoardNo1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Board No" Width="56px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBoardNo1" runat="server" BorderWidth="1px" MaxLength="11" 
                                                            onKeyPress="return onlynumber(event)" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFaxNo1Title" runat="server" Font-Bold="False"
                                                            ForeColor="Black" Text="Fax No" Width="56px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFaxNo1" runat="server" BorderWidth="1px" MaxLength="11" 
                                                            onKeyPress="return onlynumber(event)" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Label ID="lblCorporateEmail1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Corporate Email" Width="88px"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                            ControlToValidate="txtCorporateEmail1" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                            Width="45px"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td class="style4">
                                                        <asp:TextBox ID="txtCorporateEmail1" runat="server" BorderWidth="1px" 
                                                            MaxLength="50" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblContactPerson1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Contact Person" Width="88px"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ContactPerson1Validator" runat="server" 
                                                            ControlToValidate="txtContactPerson1" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" Width="50px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContactPerson1" runat="server" BorderWidth="1px" onKeyPress="return  onlyalphawithspace(event)" 
                                                            MaxLength="50" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDesignation1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Designation" Width="68px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpDesignation1" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationAddress1_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtDesignation1" runat="server" BorderWidth="1px" onKeyPress="return  onlyalphawithspace(event)"
                                                            MaxLength="50" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMobileNumber1Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Mobile Number" Width="90px"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="MobileNumber1Validator" runat="server" 
                                                            ControlToValidate="txtMobileNumber1" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" Width="50px"></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <asp:TextBox ID="txtMobileNumber1" runat="server" BorderWidth="1px" onKeyPress="return onlynumber(event)"
                                                            MaxLength="11" ValidationGroup="a" Width="175px"></asp:TextBox>

                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td colspan="2">
                                        <asp:Panel ID="Panel2" runat="server" Height="365px" Width="313">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblCode2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Code" Width="35px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCode2" runat="server" Font-Bold="True" Font-Size="10pt" 
                                                            ForeColor="#003366" style="margin-left: 0px" Width="150px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblName2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Name" Width="37px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpName2" runat="server" AutoPostBack="True" 
                                                            Width="176px" onselectedindexchanged="drpName2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblLocationType2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Location" Width="50px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpLocationType2" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationType2_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblLocation2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="City" Width="54px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpLocationCity2" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationCity2_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtLocationCity2" runat="server" BorderWidth="1px" 
                                                            MaxLength="50" onKeyPress="return onlyalpha(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblLocationAddress2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Address" Width="49px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpLocationAddress2" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationAddress2_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtLocationAddress2" runat="server" BorderWidth="1px" 
                                                            Height="23px" MaxLength="500" TextMode="MultiLine" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblLocationState2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Height="19px" Text="State" Width="35px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLocationState2" runat="server" BorderWidth="1px" 
                                                            MaxLength="50" onKeyPress="return onlyalpha(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblLocationCountry2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Country" Width="51px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLocationCountry2" runat="server" BorderWidth="1px" 
                                                            MaxLength="50" onKeyPress="return onlyalpha(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblLocationPinCode2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Pin Code" Width="51px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLocationPinCode2" runat="server" BorderWidth="1px" 
                                                            MaxLength="7" onKeyPress="return onlynumber(event)" ValidationGroup="a" 
                                                            Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblBoardNo2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Board No" Width="76px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBoardNo2" runat="server" BorderWidth="1px" MaxLength="11" 
                                                            onKeyPress="return onlynumber(event)" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblFaxNo2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Fax No" Width="56px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFaxNo2" runat="server" BorderWidth="1px" MaxLength="11" 
                                                            onKeyPress="return onlynumber(event)" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCorporateEmail2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Corporate Email" Width="90px"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                            ControlToValidate="txtCorporateEmail2" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" Height="16px" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                            Width="50px"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCorporateEmail2" runat="server" BorderWidth="1px" 
                                                            MaxLength="50" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblContactPerson2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Contact Person" Width="100px"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ContactPerson2Validator" runat="server" 
                                                            ControlToValidate="txtContactPerson2" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" Width="48px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContactPerson2" runat="server" BorderWidth="1px" onKeyPress="return  onlyalphawithspace(event)" 
                                                            MaxLength="50" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblDesignation2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Designation" Width="94px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpDesignation2" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpLocationAddress2_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtDesignation2" runat="server" BorderWidth="1px" onKeyPress="return  onlyalphawithspace(event)"
                                                            MaxLength="50" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 142px;">
                                                        <asp:Label ID="lblMobileNumber2Title" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Mobile Number" Width="90px"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="MobileNumber2Validator" runat="server" 
                                                            ControlToValidate="txtMobileNumber2" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" Width="50px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMobileNumber2" runat="server" BorderWidth="1px" onKeyPress="return onlynumber(event)"
                                                            MaxLength="11" ValidationGroup="a" Width="175px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="Panel3" runat="server" Height="94px">
                                            <table style="width:100%; ">
                                                <tr>
                                                    <td style="width: 115px;">
                                                         <br /><br /> <br /><br />
                                                        <asp:Label ID="lblLastDateForReceivingQuoteTitle" runat="server" 
                                                            Font-Bold="False" ForeColor="Black" Text="Last Date for Receiving Quotes" 
                                                            Width="125px"></asp:Label>
                                                    </td>
                                                    <td colspan="2"> <br /><br /> <br /><br />
                                                        <asp:TextBox ID="txtLastDateForReceivingQuotes" runat="server" 
                                                            BorderWidth="1px" CssClass="txtbox" onKeyPress="return lock(event)" 
                                                            ValidationGroup="a" Width="148px"></asp:TextBox>
                                                        &nbsp;
<asp:ImageButton ID="imgdate2" runat="server" 
                                            ImageUrl="~/images/Calendar_scheduleHS.png" width="17px" height= "17px" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgdate2" TargetControlID="txtLastDateForReceivingQuotes">                
                                            </ajaxToolkit:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <br /><br /> <br /><br />
                                                        <asp:Label ID="lblLastDateForClosingDealTitle" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Last Date for Closing Deal" Width="79px"></asp:Label>
                                                    </td>
                                                    <td>
                                                         <br /><br /> <br /><br />
                                                        <asp:TextBox ID="txtLastDateForClosingDeal" runat="server" BorderWidth="1px" 
                                                            CssClass="txtbox" onKeyPress="return lock(event)" ValidationGroup="a" 
                                                            Width="148px"></asp:TextBox>
                                                        &nbsp;
<asp:ImageButton ID="imgdate3" runat="server" 
                                            ImageUrl="~/images/Calendar_scheduleHS.png" width="17px" height= "17px" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="imgdate3" TargetControlID="txtLastDateForClosingDeal">                
                                            </ajaxToolkit:CalendarExtender></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="width: 135px;">
                                                    <asp:RequiredFieldValidator ID="LastDateForQuoteValidator" runat="server" 
                                                            ControlToValidate="txtLastDateForReceivingQuotes" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" Font-Size="8pt" Width="293px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:RequiredFieldValidator ID="LastDateForClosingValidator" runat="server" 
                                                            ControlToValidate="txtLastDateForClosingDeal" ErrorMessage="Invalid...!" 
                                                            Font-Bold="False" Font-Size="8pt" Width="278px"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 125px;">
                                                        <asp:Label ID="lblTraveldistanceTitle" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Travel Distance" Width="84px"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="TravelDistanceValidator" runat="server" 
                                                            ControlToValidate="txtTravelDistance" ErrorMessage="Invalid" Font-Bold="False" 
                                                            Font-Size="8pt" Width="32px"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTravelDistance" runat="server" BorderWidth="1px" 
                                                            MaxLength="5" onKeyPress="return onlynumber(event)" ValidationGroup="a" 
                                                            Width="38px">0</asp:TextBox>
                                                            <asp:LinkButton ID="lnkcalc" runat="server" Font-Bold="true" 
                                            ForeColor="black" 
                                            OnClientClick="javascript:window.open('DistanceCalculator.aspx','','left=250px, top=245px, width=600px, height=280px, scrollbars=yes, toolbar=no, menubar=no, status=no, resizable=no');return false;" 
                                            Text="Distance Calculator" Width="54px"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpTravelDistanceUnit" runat="server" Font-Size="8pt" 
                                                            Width="62px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 115px;">
                                                        <asp:Label ID="lblRouteTypeTitle" runat="server" Font-Bold="False" 
                                                            ForeColor="Black" Text="Route Type" Width="65px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpTravelType" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="drpTravelType_SelectedIndexChanged" Width="176px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br /><br /><br /> <br /><br /> <br /><br />
                        <asp:Panel ID="PanelProductAndPackingMethodDetails" runat="server" 
                            BackColor="White" Font-Bold="True" 
                            GroupingText="Product/Packing Method Details" Height="175px" Width="680px">
                            <table style="width:100%;">
                                <tr>
                                    <td >
                                        <asp:Label ID="lblProductTypeTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Product Type" Width="130px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpProductType" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drpProductType_SelectedIndexChanged" Width="176px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductCategoryTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Category" Width="50px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpProductCategory" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drpProductCategory_SelectedIndexChanged" Width="176px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblProductNameTitle" runat="server" BorderStyle="None" 
                                            Font-Bold="False" ForeColor="Black" Text="Name" Width="40px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="ProductNameValidator" runat="server" 
                                            ControlToValidate="txtOtherProductName" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="43px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpProductName" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drpProductName_SelectedIndexChanged" Width="176px">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtOtherProductName" runat="server" BorderWidth="1px" 
                                            MaxLength="20" onKeyPress="return alphawithspace(event)" 
                                            ValidationGroup="a" Width="175px"></asp:TextBox>
                                    </td>
                                    <td style="width: 85px;">
                                        <asp:Label ID="lblProductPackingMethodTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Packing Method" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        <asp:DropDownList ID="drpPackingMethod1" runat="server" AutoPostBack="True" 
                                            Font-Size="8pt" onselectedindexchanged="drpPackingMethod1_SelectedIndexChanged" 
                                            Width="90px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpPackingMethod2" runat="server" AutoPostBack="True" 
                                            Font-Size="8pt" onselectedindexchanged="drpPackingMethod2_SelectedIndexChanged" 
                                            Width="90px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblProductWidthTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Width" Width="33px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="WidthValidator" runat="server" 
                                            ControlToValidate="txtProductWidth" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="49px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProductWidth" runat="server" BorderWidth="1px" 
                                            MaxLength="6" onKeyPress="return onlynumberwithdecimal(event)" 
                                            ValidationGroup="a" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductWidthUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="25px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpProductWidthUnit" runat="server" Font-Size="8pt" 
                                            Width="62px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:Label ID="lblQuantityTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Quantity" Width="51px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="QuantityValidator" runat="server" 
                                            ControlToValidate="txtQuantity" ErrorMessage="Invalid...!" Font-Bold="False" 
                                            Font-Size="8pt" style="margin-right: 0px" Width="47px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtQuantity" runat="server" BorderWidth="1px" MaxLength="5" 
                                            onKeyPress="return onlynumber(event)" ValidationGroup="a" Width="75px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQuantityUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="21px"></asp:Label>&nbsp;<asp:DropDownList ID="drpQuantityUnit" runat="server" Font-Size="8pt" 
                                            Width="62px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblProductLengthTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Length" Width="50px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="LengthValidator" runat="server" 
                                            ControlToValidate="txtProductLength" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Height="19px" Width="47px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProductLength" runat="server" BorderWidth="1px" 
                                            MaxLength="6" onKeyPress="return onlynumberwithdecimal(event)" 
                                            ValidationGroup="a" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductLengthUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="25px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpProductLengthUnit" runat="server" Font-Size="8pt" 
                                            Width="62px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 95px;">
                                        <asp:Label ID="lblProductWeightTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Weight" Width="41px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="WeightValidator" runat="server" 
                                            ControlToValidate="txtProductWeight" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="49px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="style1">
                                        <asp:TextBox ID="txtProductWeight" runat="server" BorderWidth="1px" 
                                            MaxLength="6" onKeyPress="return onlynumberwithdecimal(event)" 
                                            ValidationGroup="a" Width="75px"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="lblProductWeightUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="21px"></asp:Label>
                                        <asp:DropDownList ID="drpProductWeightUnit" runat="server" Font-Size="8pt" 
                                            Width="62px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblProductHeightTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Height" Width="49px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="HeightValidator" runat="server" 
                                            ControlToValidate="txtProductWeight" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="47px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProductHeight" runat="server" BorderWidth="1px" 
                                            MaxLength="6" onKeyPress="return onlynumberwithdecimal(event)" 
                                            ValidationGroup="a" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductHeightUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="25px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpProductHeightUnit" runat="server" Font-Size="8pt" 
                                            Width="62px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 95px;">
                                        <asp:Label ID="lblProductVolumeTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Volume" Width="39px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="VolumeValidator" runat="server" 
                                            ControlToValidate="txtProductVolume" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Height="16px" Width="47px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="style1">
                                        <asp:TextBox ID="txtProductVolume" runat="server" BorderWidth="1px" 
                                            MaxLength="6" onKeyPress="return onlynumberwithdecimal(event)" 
                                            ValidationGroup="a" Width="75px">0</asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="lblProductVolumeUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="21px"></asp:Label>
                                        <asp:DropDownList ID="drpProductVolumeUnit" runat="server" Font-Size="8pt" 
                                            Width="62px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="PanelTruckDetails" runat="server" BackColor="White" 
                            BorderColor="White" BorderWidth="1px" Font-Bold="True" 
                            GroupingText="Truck Estimate Details" Height="170px" Width="680px">
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTruckEstimateTypeTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Truck Estimate Type" Width="115px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButton ID="RadioButtonEvaluate" runat="server" AutoPostBack="True" 
                                            Font-Bold="False" oncheckedchanged="RadioButtonEvaluate_CheckedChanged" 
                                            Text="Evaluate" Width="75px" />
                                        <asp:RadioButton ID="RadioButtonManual" runat="server" AutoPostBack="True" 
                                            Font-Bold="False" oncheckedchanged="RadioButtonManual_CheckedChanged" 
                                            Text="Manual" Width="75px" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTruckTypeTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Truck Type" Width="67px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpTruckType" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drpTruckType_SelectedIndexChanged" Width="176px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEnclosureTypeTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Enclosure Type" Width="86px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpEnclosureType" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drpEnclosureType_SelectedIndexChanged" Width="176px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTruckBrandTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Truck Brand" Width="70px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpTruckBrand" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drpTruckBrand_SelectedIndexChanged" Width="176px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTruckModelTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Truck Model" Width="72px"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpTruckModel" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="drpTruckModel_SelectedIndexChanged" Width="176px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTruckCapacityTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Truck Capacity" Width="83px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="TruckCapacityValidator" runat="server" 
                                            ControlToValidate="txtTruckCapacity" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="35px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTruckCapacity" runat="server" BorderWidth="1px" 
                                            MaxLength="6" onKeyPress="return onlynumberwithdecimal(event)" 
                                            onkeyup="return TotalCostCalculationForLiquidContainer(event)" 
                                            ValidationGroup="a" Width="75px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTruckCapacityUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="24px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpTruckCapacityUnit" runat="server" AutoPostBack="True" 
                                            Font-Size="8pt" ontextchanged="drpTruckCapacityUnit_TextChanged" Width="65px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblQtyPerTruckTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Qty Per Truck" Width="85px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="QuantityPerTruckValidator" runat="server" 
                                            ControlToValidate="txtQuantityPerTruck" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="48px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuantityPerTruck" runat="server" BorderWidth="1px" 
                                            MaxLength="5" onKeyPress="return onlynumber(event)" 
                                            onkeyup="return TotalCostCalculation(event)" ValidationGroup="a" Width="74px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblQuantityPerTruckUnitTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Unit" Width="25px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpQuantityPerTruck" runat="server" Font-Size="8pt" 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="drpQuantityPerTruck_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNoOfTrucksTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Trucks Required" Width="100px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="NoOfTrucksValidator" runat="server" 
                                            ControlToValidate="txtTruckRequired" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="36px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtTruckRequired" runat="server" BorderWidth="1px" 
                                            MaxLength="3" onKeyPress="return onlynumber(event)" Width="175px" 
                                            Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCostPerTruckTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Budgeted Cost" Width="83px"></asp:Label>
                                        <asp:RequiredFieldValidator ID="CostPerTruckValidator" runat="server" 
                                            ControlToValidate="txtCostPerTruck" ErrorMessage="Invalid...!" 
                                            Font-Bold="False" Font-Size="8pt" Width="35px"></asp:RequiredFieldValidator>
                                        <asp:Image ID="ImgINRCost" runat="server" Height="13px" 
                                            ImageUrl="~/images/INR.png" Width="12" />
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtCostPerTruck" runat="server" BorderWidth="1px" 
                                            MaxLength="7" onKeyPress="return onlynumber(event)" ValidationGroup="a" 
                                            Width="176px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br /><br /><br /><br /> <br /><br />
                        <asp:Panel ID="PanelAdditionalInformation" runat="server" BackColor="White" 
                            Font-Bold="True" GroupingText="Additional Information" Height="110px" 
                            Width="680px">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAdditionalInformationTitle" runat="server" Font-Bold="False" 
                                            ForeColor="Black" Text="Information" Width="115px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAdditionalInformation" runat="server" BackColor="White" 
                                            BorderWidth="1px" CssClass="txtbox" Height="44px" TextMode="MultiLine" 
                                            ValidationGroup="a" Width="287px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="false">
                                            <ProgressTemplate>
                                                <img src="images/ajax-loader.gif" />
                                                <font color="red">Loading...</font>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td>
                                        <asp:Button ID="cmdSubmit" runat="server" Text="Submit" 
                                            onclick="cmdSubmit_Click"  Class="btn btn-primary"/><%-- onmouseup="showPleaseWait()"--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                    <div class="helptext" id="PleaseWait" style="display: none; 
                                        text-align:right; color:White; vertical-align:top;">
                                        <table id="MyTable" bgcolor="red">
                                           <tr>                    
                                           <td>                        
                                           <b><font color="white">Please Wait...!</font></b>                    
                                           </td>                
                                           </tr>            
                                        </table>        
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="600px"></asp:Label>
                    </td>
                </tr>
            </table>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        <br /><br /><br /><br /><br /><br />
</asp:Content>

