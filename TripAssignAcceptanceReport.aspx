<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TripAssignAcceptanceReport.aspx.cs" Inherits="TripAssignAcceptanceReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <style type ="text/css">
        /*.grid-header
        {
            font-weight: bold;
            font-family: Verdana;
            font-size: 11px;
            background-color: #556B2F;
            text-decoration: underline;
            color: White;
            text-align: left;
            position: relative;
            top: expression(this.parentNode.parentNode.parentNode.scrollTop-2);
            left: expression(this.parentNode.parentNode.parentNode.scrollLeft-1);
            right: 1px;
        }*/

    </style>

     <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=Gridwindow.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /> <br /><br /> <br /><br />
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin-left:400px">
<h2 class="title-one">TripAssign/Acceptance Report</h2>
        </div>
<div style="margin-left:100px">
    <table >
   <tr>
   <td>
    
    &nbsp;Truck Required Date&nbsp;&nbsp;<asp:TextBox ID ="txt_ReqDate" runat ="server" Width ="80px" ></asp:TextBox><ajaxToolkit:CalendarExtender ID ="cal_ReqDate" TargetControlID ="txt_ReqDate" PopupButtonID ="imgdate1" runat ="server" ></ajaxToolkit:CalendarExtender><asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" 
                />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Status&nbsp;
       <asp:DropDownList ID="ddl_Status" runat="server" AppendDataBoundItems ="true" >
           <asp:ListItem>--Select--</asp:ListItem>
           <asp:ListItem>Confirmed</asp:ListItem>
           <asp:ListItem>Not Yet Confirm</asp:ListItem>
       </asp:DropDownList>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Project No :
       <asp:DropDownList ID="ddl_ProjectNo" runat="server" AppendDataBoundItems ="true" >
       </asp:DropDownList>
       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 Year: &nbsp;
       <asp:DropDownList ID="ddlYear" runat="server" Width="66px" AutoPostBack="true"  >
                      <asp:ListItem Value="2019">2019</asp:ListItem>                     
                      <asp:ListItem Value="2018">2018</asp:ListItem>
                       <asp:ListItem Value="2017">2017</asp:ListItem>
                     <asp:ListItem Value="2016">2016</asp:ListItem>
                     <asp:ListItem Value="2015">2015</asp:ListItem>
                    
                </asp:DropDownList>
       

       &nbsp;&nbsp;&nbsp;&nbsp;Month:&nbsp;
        <asp:DropDownList ID="ddlMonth" runat="server" Width="90px" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                     <asp:ListItem>--Month--</asp:ListItem>
                     <asp:ListItem Value="1">January</asp:ListItem>
                     <asp:ListItem Value="2">February</asp:ListItem>
                     <asp:ListItem Value="3">March</asp:ListItem>
                     <asp:ListItem Value="4">April</asp:ListItem>
                     <asp:ListItem Value="5">May</asp:ListItem>
                     <asp:ListItem Value="6">June</asp:ListItem>
                     <asp:ListItem Value="7">July</asp:ListItem>
                     <asp:ListItem Value="8">August</asp:ListItem>
                     <asp:ListItem Value="9">September</asp:ListItem>
                     <asp:ListItem Value="10">October</asp:ListItem>
                     <asp:ListItem Value="11">November</asp:ListItem>
                     <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click"  class="btn btn-primary"  />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="Button1" runat="server" Text="Download" onclick="Button1_Click"  class="btn btn-primary"  />
          </td>
   </tr>
   
   </table>
    </div>
    <br />
  <%-- <asp:GridView ID="Gridwindow" runat="server" 
             CellPadding="4" ForeColor="#333333" 
             EnableModelValidation="True" BorderStyle="None">
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" CssClass ="grid-header" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>--%>
     <div align="center"><asp:Label ID="lbl_msg" runat="server" ForeColor="Green" ></asp:Label></div>
    <br />
    <asp:Panel ID="panel1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="350px" Width="1200px" ScrollBars="Auto"  Style="margin-left:50px">
     <asp:GridView ID="Gridwindow" runat="server" 
              ForeColor="#333333" GridLines="Both"  OnRowDataBound="Gridwindow_RowDataBound"
             EnableModelValidation="True" BorderStyle="None">
       <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
          </asp:GridView>
       </asp:Panel> 

      
</asp:Content>

