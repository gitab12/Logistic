<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AARMSPage.aspx.cs" Inherits="AARMSPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
   <script type="text/javascript">
       function onlynumber(evt) {
           var charCode = (evt.which) ? evt.which : event.keyCode
           if ((charCode < 48 || charCode > 57) && (charCode != 8))
               return false;
           return true;
       }
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br />
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div  style="margin-left:200px">
         <div  style="margin-left:200px">
    <table>
    <tr>
    <td>
        <asp:RadioButton ID="radmarketing" runat="server" Text="Marketing" 
            Checked="true" GroupName="t" ValidationGroup="d" AutoPostBack="True" 
            oncheckedchanged="radmarketing_CheckedChanged" />
    </td>
    <td>
        <asp:RadioButton ID="radoperations" runat="server" Text="Operations" 
            GroupName="t" ValidationGroup="d" AutoPostBack="True" 
            oncheckedchanged="radoperations_CheckedChanged"  />
    </td>
    </tr>
    </table>
</div>
 <div  style="margin-left:200px">
    <asp:Panel ID="pnlmarket" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Bold="True" GroupingText="Marketing" Height="340px" Width="450px">    
    <table>
        <tr>
            <td colspan="2" style="font-family: Arial; font-size: large; color: #FF0000">
                Daily Status Entry</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Client Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtclient" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Location"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlocation" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Industry"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtindustry" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="ContactPerson"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcontactperson" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Mobile"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="EmailID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtemail" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Department"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDept" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Appointment Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtappdate" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="227px" ></asp:TextBox>  
                    <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px" 
                />
            </td>
        </tr>
         <tr>
        <td>
        <asp:Label ID="Label17" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Action"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlActionList" runat="server" Width="243px">
            <asp:ListItem>--Choose--</asp:ListItem>
            <asp:ListItem>Interested</asp:ListItem>
            <asp:ListItem>Not Interested</asp:ListItem>
            <asp:ListItem>Meeting Fixed</asp:ListItem>
            <asp:ListItem>Contact Later</asp:ListItem>
            <asp:ListItem>Trip Plan Received</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>     
         <tr>
            <td>
                <asp:Label ID="lblrem" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Remarks"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtremarks" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>          
        <tr>
            <td>
                &nbsp;</td>
            <td>
                   <br />
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                    Width="125px" Class="btn btn-primary" />
                     <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtappdate">                
    </ajaxtoolkit:calendarextender> 
                <asp:Button ID="Butstatus" runat="server" Text="Status Update" onclick="Butstatus_Click"  Class="btn btn-primary" />
            </td>
        </tr>
    </table>
       
    </asp:Panel> 
        
     </div>
         <div  style="margin-left:200px">
    <asp:Panel ID="pnloperate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Bold="True" GroupingText="Operations" Height="400px" Width="450px">
    <table>
    <tr>
    <td>
   <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Date of Calendar"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtcalendar" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="215"></asp:TextBox>
        <asp:ImageButton ID="Imgcalendar" runat="server"  ImageUrl="~/images/calendar_icon.gif" Width="16px" />
         <ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" 
                    PopupButtonID="Imgcalendar" TargetControlID="txtcalendar">                
    </ajaxtoolkit:calendarextender>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Client Name"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txtclientname" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="214px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Trip Plan Received Date"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txttripdate" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="215"></asp:TextBox>
        <asp:ImageButton ID="imgtripdate" runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px" />
         <ajaxtoolkit:calendarextender ID="CalendarExtender3" runat="server" 
                    PopupButtonID="imgtripdate" TargetControlID="txttripdate">                
    </ajaxtoolkit:calendarextender>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label12" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Target Transporter"></asp:Label>
    </td>
    <td>
        <asp:Panel ID="Panel1" runat="server" ScrollBars ="Vertical" Height="164px"
            width="217px" >
            <asp:CheckBoxList ID="chkbl_Transporter" runat="server" Width="170px" >
            </asp:CheckBoxList>
        </asp:Panel>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label13" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="No.of Quotes received"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txtquotereceived" runat="server" MaxLength="20" BorderColor="Black" onkeypress="return onlynumber(event)"
                    BorderStyle="Solid" BorderWidth="1px" Width="214px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label14" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Report sent for Action Date"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txtactiondate" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="215px"></asp:TextBox>
        <asp:ImageButton ID="imgaction" runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px" />
         <ajaxtoolkit:calendarextender ID="CalendarExtender4" runat="server" 
                    PopupButtonID="imgaction" TargetControlID="txtactiondate">                
    </ajaxtoolkit:calendarextender>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label15" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Rebid Request"></asp:Label>
    </td>
    <td>
        <asp:RadioButton ID="radYes" runat="server"  Text="Yes" GroupName="a" AutoPostBack="true" />
        <asp:RadioButton ID="radNo" runat="server" Checked="true" Text="No" GroupName="a" AutoPostBack="true"/>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label16" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Marketing Action"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtaction" runat="server" TextMode="MultiLine" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="214px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    
    </td>
    <td>
        <br />
        <asp:Button ID="btnsave" runat="server" Text="Enter" Width="130px" 
            onclick="btnsave_Click"  Class="btn btn-primary"/>
            <asp:Button ID="btn_Report" runat="server" onclick="btn_Report_Click" 
            Text="Report" Class="btn btn-primary" />
    </td>
    </tr>
    </table>
    </asp:Panel>  
             <br /><br /><br /><br />
        </div>
        </div>
</asp:Content>

