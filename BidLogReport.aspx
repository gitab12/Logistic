<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BidLogReport.aspx.cs" Inherits="BidLogReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br /><br /><br />
<div  style="margin-left:400px"><h2 class="title-one">BidLog Report</h2>
   <br />
    <asp:Button ID="ButDownload" runat="server" Text="Download" onclick="ButDownload_Click"  Class="btn btn-primary"/>

    </div>
     <asp:Panel ID="pnl_1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
<asp:GridView ID="GridQuotingLevel" runat="server" CellPadding="4" OnRowDataBound="GridQuotingLevel_RowDataBound"
        ForeColor="#333333" AutoGenerateColumns="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
         <asp:BoundField DataField="adid" HeaderText="AD ID" />
            <asp:BoundField DataField="Fromlocation" HeaderText="From" />
            <asp:BoundField DataField="Tolocation" HeaderText="To" />
            <asp:BoundField DataField="TruckType" HeaderText="Truck Type" />
            <asp:BoundField DataField="TruckCapacity" HeaderText="Capacity" />
             
            <asp:BoundField  HeaderText="Level1">
               
                <ItemStyle Font-Bold="true"   />
              
            </asp:BoundField>
              <asp:BoundField  HeaderText="Level2">
                <ItemStyle Font-Bold="false"  />
            </asp:BoundField>
              <asp:BoundField  HeaderText="Level3">
                <ItemStyle Font-Bold="false" ForeColor="Goldenrod" />
            </asp:BoundField>
              <asp:BoundField  HeaderText="Level4">
                <ItemStyle Font-Bold="false"  />
            </asp:BoundField>
            
            <asp:BoundField  HeaderText="ReplyDateTime">
               <ItemStyle Font-Bold="true"   />
              </asp:BoundField>
              
            
            <asp:TemplateField HeaderText="PostID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PostID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPostID" runat="server" Text='<%# Bind("PostID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
         </asp:Panel>
    <br /><br /><br /><br /><br /><br /><br />
</asp:Content>

