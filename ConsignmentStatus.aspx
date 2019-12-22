<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ConsignmentStatus.aspx.cs" Inherits="ConsignmentStatus" %>

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
        $('#<%=GridConsignmentReport.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br /><br />
   
           <div style="margin-left:300px">
    <left><h2 class="title-one">Trip Assign Vs Trip Acceptance Vs Trip Placed</h2></left>
               </div>
         <br />
      <div style="margin-left:400px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ProjectNo :&nbsp;
    <asp:DropDownList ID="ddl_ProjectNo" runat="server"></asp:DropDownList>
    &nbsp;&nbsp;
    <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" Class="btn btn-primary" />
    &nbsp;&nbsp; <asp:Button ID="btnexport" runat="server" Text="Download" 
        onclick="btnexport_Click"  Class="btn btn-primary"/>
         </div>

    <br />
<center>    
  
          <asp:Panel ID="pnl_Consignment" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px">
    <asp:GridView ID="GridConsignmentReport" runat="server"  OnRowDataBound="GridConsignmentReport_RowDataBound"
        ForeColor="#333333" GridLines="Both"   EnableModelValidation="True" BorderStyle="None" >
        <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
       <%-- <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />--%>
    </asp:GridView>
          </asp:Panel> 
</center>
<br />
<br />

</asp:Content>

