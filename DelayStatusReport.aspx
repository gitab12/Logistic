<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DelayStatusReport.aspx.cs" Inherits="DelayStatusReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics
        </title>

      <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=GridReport.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<center> 
    <center><h2 class="title-one">Delay Status Report</h2></center>
    <div style="margin-left:250px"> 
           <br />Travel Date From
    <asp:TextBox ID="txtFromdate" runat="server" Enabled="True"></asp:TextBox>
    <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                                                 <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtFromdate">                                                                     
    </ajaxtoolkit:calendarextender>
   Travel Date  To <asp:TextBox ID="txtTodate" runat="server" Enabled="True"></asp:TextBox>
    <asp:ImageButton ID="imgdate2" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                                                 <ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" 
                    PopupButtonID="imgdate2" TargetControlID="txtTodate">                                                                     
    </ajaxtoolkit:calendarextender>
    &nbsp; ProjectNo :&nbsp;
                <asp:DropDownList ID="ddl_ProjectNo" runat="server" Width="104px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      <asp:Button ID="btnsearch" runat="server" Text="Search" onclick="btnsearch_Click"  Class="btn btn-primary"/>
        <asp:Button ID="Button1" runat="server" Text="Download" onclick="Button1_Click"  Class="btn btn-primary" />
     <br /> <br />
     
    </div>

 <asp:Panel ID="pnl_Delivery" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px">

    <asp:GridView ID="GridReport" runat="server" OnRowDataBound ="GridReport_RowDataBound" >
        <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
    </asp:GridView>
         </asp:Panel> 
         </center>
</asp:Content>

