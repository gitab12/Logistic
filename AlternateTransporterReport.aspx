<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AlternateTransporterReport.aspx.cs" Inherits="AlternateTransporterReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
     <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=grid_AlternateTransporter.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />   
    <center><h2 class="title-one">Alternate Transporter Report</h2></center>

    
          <asp:Panel ID="pnl_Delivery" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
    <asp:GridView ID="grid_AlternateTransporter" runat="server" OnRowDataBound ="grid_AlternateTransporter_RowDataBound"
              ForeColor="#333333" 
             EnableModelValidation="True" BorderStyle="None">
       
             <RowStyle BorderColor="Red" />
          
             
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
          </asp:GridView>
         </asp:Panel> 
</asp:Content>

