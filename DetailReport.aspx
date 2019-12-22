<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DetailReport.aspx.cs" Inherits="DetailReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

       <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=grd_DetailReport.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br /><br /> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <div style="margin-left:450px"> 
       <h2 class="title-one">Detailed MIS Report</h2>
      </div>
       <div style="margin-left:350px"> 
  
      From : <asp:textbox id="txt_From" runat="server"></asp:textbox>
     <asp:ImageButton ID="imgFrom" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
     <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgFrom" TargetControlID="txt_From">                                                                     
    </ajaxtoolkit:calendarextender> &nbsp; To : <asp:textbox id ="txt_To" runat="server"></asp:textbox> &nbsp;
    <asp:ImageButton ID="imgTo" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
     <ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" 
                    PopupButtonID="imgTo" TargetControlID="txt_To">                                                                     
    </ajaxtoolkit:calendarextender>
    <asp:button id ="btn_Search" runat="server" text="Search" OnClick="btn_Search_Click" Class="btn btn-primary" />&nbsp; <asp:Button ID="Button1" runat="server" Text="Download" onclick="Button1_Click"  Class="btn btn-primary" /> </div>
    <br /> <br />
           <asp:Panel ID="pnl_Delivery" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" Visible="false">
         
         <asp:GridView ID="grd_DetailReport" runat="server" OnRowDataBound ="grd_DetailReport_RowDataBound" 
              ForeColor="#333333" 
             EnableModelValidation="True" BorderStyle="None"  >
        <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
          
        <EmptyDataTemplate>
         <asp:Label ID="lblEmptydata" runat="server" Text="No Records Found"></asp:Label>
        </EmptyDataTemplate>
          </asp:GridView>

              </asp:Panel> 
            
      <br /><br /><br /><br /><br /><br /> 
      <br /><br />
</asp:Content>

