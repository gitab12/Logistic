<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="UpdateLoadingInfo.aspx.cs" Inherits="UploadMultiple_UpdateLoadingInfo" %>
<%--<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagName="Navihome" TagPrefix="Uc4" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%-- <Uc4:Navihome ID="navihome1" runat="server" />--%>
 <br />
   <div style="margin-left:0px">
       <div style="margin-left:450px">
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <br />
    ProjectNo : <asp:DropDownList ID="ddl_ProjectNo" runat="server" Height="20px" AutoPostBack ="true"  OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged" Width="104px"></asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    WBSNo : <asp:DropDownList ID="ddl_Wbsno" runat="server" Height="20px" Width="91px" AppendDataBoundItems="True"  >
        <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList>
    &nbsp;&nbsp;
    <asp:Button ID="btn_Search" runat="server"  Text="Search" OnClick ="btn_Search_Click"  class="btn btn-primary" />
               
  </div>
    <br />
    <br />
       <asp:Panel ID="panel1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="300px" Width="1200px" ScrollBars="Auto"  Style="margin-left:100px">
    <div style="margin-left:1px">
    <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" OnRowCreated ="Gridwindow_RowCreated"  
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>

                   <asp:BoundField HeaderText ="Preload ID" DataField ="PLid" />
                  <asp:BoundField HeaderText ="Confirm No" DataField ="AcceptanceID" />
                  <asp:BoundField HeaderText ="ProjectNo" DataField ="ProjectNo" />
                  <asp:BoundField HeaderText ="WBSNo" DataField ="WBSNo" />
                  <asp:BoundField HeaderText ="CN No" DataField ="CollectionNoteNumber" />
                  <asp:BoundField HeaderText ="FromLocation" DataField ="FromLocation" />
                  <asp:BoundField HeaderText ="ToLocation" DataField ="ToLocation" />
                  <asp:BoundField HeaderText ="Truck Requirement Date" DataField ="TravelDate" />
                  <asp:BoundField HeaderText ="Transporter" DataField ="Transporter" />
                  <asp:BoundField HeaderText ="TruckType" DataField ="TruckType" />
                  <asp:BoundField HeaderText ="TotalWt in Tons" DataField ="TotalWeight" />
                  <asp:BoundField HeaderText ="ERoad Permit No./Way Bill No" DataField ="ERoadNo" />
                  <asp:BoundField HeaderText ="DeliveryDate" DataField ="DeliveryDate" />

                 <%-- <asp:TemplateField HeaderText="Preload ID" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblPLid" runat="server" Text='<%# Bind("PLid") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Confirm No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="ProjectNo"  >
                      <ItemTemplate>
                          <asp:Label ID="lbl_ProjectNo" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="WBSNo"  >
                      <ItemTemplate>
                          <asp:Label ID="lbl_Wbsno" runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="CN No"  >
                      <ItemTemplate>
                          <asp:Label ID="lbl_CNNo" runat="server" Text='<%# Bind("CollectionNoteNumber") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="From Location">
                      <ItemTemplate>
                          <asp:Label ID="lblFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="To Location">
                      <ItemTemplate>
                          <asp:Label ID="lbltoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="Truck Requirement Date">
                      <ItemTemplate>
                          <asp:Label ID="lbldate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Transporter">
                      <ItemTemplate>
                          <asp:Label ID="lblTransporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField> 
               <asp:TemplateField HeaderText="TruckType">
                      <ItemTemplate>
                          <asp:Label ID="lblTruckType" runat="server" Text='<%# Bind("TruckType") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>                
                      <asp:TemplateField HeaderText="TotalWt in Tons" >
                      <ItemTemplate>
                          <asp:TextBox ID="txtweight" runat="server" Width="41px" onkeypress="return onlynumberwithDecimals(event)" Text='<%# Bind("TotalWeight") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="ERoad Permit No./Way Bill No">
                      <ItemTemplate>
                            <asp:TextBox ID="TxtEroadNo" runat="server" Width="70px" Text='<%# Bind("ERoadNo") %>'></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>       
                  <asp:TemplateField HeaderText="DeliveryDate"  >
                      <ItemTemplate>
                             <asp:TextBox ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="71px"></asp:TextBox>
                                                                      <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="lblDeliverydate">  </ajaxtoolkit:calendarextender>
                               <asp:Button ID="Btnupdate" runat="server" Text="Update" onclick="Btnupdate_Click" />
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                      <asp:TemplateField HeaderText="Submit">
<ItemTemplate>
<asp:HyperLink ID="lnledit" runat="server" Text="Submit" Style="text-decoration:underline;color:blue" NavigateUrl=<%# String.Format("javascript:void(window.open('UpdateLoadingInformation.aspx?AcceptID={0}',null,'right=362px, top=134px, width=1400px, height=1000px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("AcceptanceID")) %>></asp:HyperLink>
</ItemTemplate>
</asp:TemplateField>
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
      </div>
           </asp:Panel>
          </div>
</asp:Content>

