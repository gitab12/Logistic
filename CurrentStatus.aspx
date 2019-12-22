<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CurrentStatus.aspx.cs" Inherits="CurrentStatus" %>
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
    <div style="margin-left:300px">
<table align="center">
<tr>
<td>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="lblsrch" runat="server" Text="Search Quotes by Travel Date:" Font-Bold="true" ForeColor="red"></asp:Label>
    
    <asp:TextBox ID="txtsearch" runat="server" Enabled="true"></asp:TextBox>
    <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                                                 <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtsearch">                                                                     
    </ajaxtoolkit:calendarextender>
      <asp:Button ID="btnsearch" runat="server" Text="Search" 
        onclick="btnsearch_Click"  Class="btn btn-primary"/> 
 <asp:Button ID="btnexport" runat="server" Text="Download" 
        onclick="btnexport_Click" Class="btn btn-primary"/>
    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
<asp:Label ID="lblcount" runat="server" ForeColor="#009933"></asp:Label>
</td>
</tr>
</table>
<table align="center">
<tr>
<td>
<asp:GridView ID="GridRouteprice" runat="server" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" 
         Width="95%" AutoGenerateColumns="False">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
   
    <Columns>
        <asp:BoundField DataField="Planid" HeaderText="LogisticsPlanID" />
        <asp:BoundField DataField="Planno" HeaderText="LogisticsPlanNo" />
        <asp:BoundField DataField="From" HeaderText="From Location" />
        <asp:BoundField DataField="To" HeaderText="To Location" />
         <asp:BoundField DataField="TravelDate" HeaderText="TravelDate" />
        <asp:BoundField DataField="Trucktype" HeaderText="Truck Type" />
        <asp:BoundField DataField="Encl.type" HeaderText="Encl.Type" />
        <asp:BoundField DataField="Capacity" HeaderText="Capacity" />
        <asp:BoundField DataField="Routeprice" HeaderText="Route Price" />
        <asp:TemplateField HeaderText="TransID">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Transid") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblTransID" runat="server" Text='<%# Bind("Transid") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    <%--    <asp:HyperLinkField DataNavigateUrlFields="bidlink" DataTextField="Bid"  Visible="false" 
            HeaderText="BID" />--%>
            
    </Columns>
    
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</td>
</tr>

</table>
    <br /><br /><br /><br /><br /><br />
          <br /><br /><br /><br /><br /><br />
        </div>
</asp:Content>

