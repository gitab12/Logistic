<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="TripCancellation.aspx.cs" Inherits="TripCancellation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
           <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />

    <center><h2 class="title-one">Trip Cancellation</h2></center>

      <asp:Panel ID="panel1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="350px" Width="1100px" ScrollBars="Auto"  Style="margin-left:100px">
       <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
           <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000"  Font-Bold="True" ForeColor="White" CssClass ="header" />
              <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:TemplateField HeaderText="TripAssignID">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TripAssignID") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="lblTripID" runat="server" Text='<%# Bind("TripAssignID") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="FromLocation" HeaderText="FromLocation" />
               <asp:BoundField DataField="ToLocation" HeaderText="ToLocation" />
               <asp:BoundField DataField="Trucktype" HeaderText="TruckType" />
               <asp:BoundField DataField="EnclType" HeaderText="EnclType" />
               <asp:BoundField DataField="Capacity" HeaderText="Capacity" />
               <asp:BoundField DataField="Transporter" HeaderText="Transporter" />
               <asp:BoundField DataField="DecidePrice" HeaderText="DecidePrice" />
               <asp:BoundField DataField="NooftrucksReq" HeaderText="NooftrucksReq" />
               <asp:BoundField DataField="TripAssigned" HeaderText="TripAssigned" />
               <asp:BoundField DataField="TruckReqDate" HeaderText="TruckReqDate" />
               <asp:BoundField DataField="Status" HeaderText="Status" />
               <asp:TemplateField HeaderText="Cancel">
                   <ItemTemplate>
                    <asp:Button ID="ButSubmit" runat="server" Text="Cancel" onclick="ButSubmit_Click" />
                   </ItemTemplate>

               </asp:TemplateField>
           </Columns>
       </asp:GridView>
          </asp:Panel>
    <br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

