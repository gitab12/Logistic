<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Loading_Info.aspx.cs" Inherits="Loading_Info" Title="Loading_Info" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <br /><br /><br /><br /><br /><br />
 <script src="JSP/jquery.1.4.2.js" type="text/javascript"></script>
  <link rel="Stylesheet" href="css/TimeCalendar.css" />
 <br />
 <br />
 <asp:ScriptManager ID="ScriptManager2" runat="server" />
   <asp:Panel ID="pnl_1" runat="server"   Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:150px" >
    <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None"  
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                 
                 <asp:BoundField HeaderText ="Confirm No" DataField ="AcceptanceID" />
                  <asp:BoundField HeaderText ="From Location" DataField ="FromLocation" />
                  <asp:BoundField HeaderText ="To Location" DataField ="ToLocation" />
                  <asp:BoundField HeaderText ="Truck Requirement Date" DataField ="TravelDate" />
                  <asp:BoundField HeaderText ="Vehicle No" DataField ="VehicleNo" />
                  <asp:BoundField HeaderText ="Driver" DataField ="DriverName" />
                  <asp:BoundField HeaderText ="Mobile No" DataField ="mobileNo" />
                  <asp:BoundField HeaderText ="Delivery Date" DataField ="DeliveryDate" />
                          
                  <asp:TemplateField HeaderText="Update Info">
                      <ItemTemplate>
                          <asp:HyperLink ID="lnledit" runat="server" Text="Update" NavigateUrl=<%# String.Format("javascript:void(window.open('UpdatePreloading.aspx?AcptID={0}&CLiID={1}&CLiAddLID={2}',null,'right=362px, top=134px, width=1400px, height=1000px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("AcceptanceID"),Eval ("ClientID"),Eval ("ClientAddressLocationID")) %>></asp:HyperLink>

                               <%--<asp:Button ID="ButSubmit" runat="server" Text="Submit" onclick="ButSubmit_Click" />--%>
                      </ItemTemplate>
                  </asp:TemplateField>
                
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
       </asp:Panel>
           <script type="text/javascript" src="JSP/TimeCalendar.js"></script>

    <br /><br /><br /><br /><br /><br />
 </asp:Content>

