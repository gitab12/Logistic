<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TransporterReport.aspx.cs" Inherits="TransporterReport"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br />
     <div style="margin-left:350px">
           <h2 class="title-one">TRANSPORTER REPORT</h2></div>
           <div style="margin-left:300px">
 <asp:DropDownList ID="DDLEnclType" runat="server" Width="145px">
        <asp:ListItem Value="0">--All Encl.Type--</asp:ListItem>
        <asp:ListItem Value="1">Open</asp:ListItem>
        <asp:ListItem Value="2">Closed</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DDLTruckType" runat="server" Width="145px">
    </asp:DropDownList>
    <asp:DropDownList ID="DDLCapacity" runat="server" Width="145px">
    </asp:DropDownList>
    <asp:Button ID="ButSearch" runat="server" Text="Search" 
        onclick="ButSearch_Click" Class="btn btn-primary" />

               <asp:Button ID="ButDownload" runat="server" 
        Text="Download" onclick="ButDownload_Click"  Class="btn btn-primary" />
                  </div>
    <br />
     <asp:Panel ID="pnl_1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="400px" Width="900px" ScrollBars="Auto"  Style="margin-left:100px" >
<asp:GridView ID="GridRouteprice" runat="server" AutoGenerateColumns="False" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" 
        onrowdatabound="GridRouteprice_RowDataBound"  Width="70%">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
        <Columns>
      
    
            <asp:BoundField DataField="Tcode" HeaderText="TCode" />
      
    
            <asp:BoundField DataField="transporter" HeaderText="Transporter" />
            <asp:BoundField DataField="trucktype" HeaderText="TruckType" />
            <asp:BoundField DataField="encltype" HeaderText="Encl.Type" />
            <asp:BoundField DataField="capacity" HeaderText="Capacity" />
            <asp:BoundField DataField="quotedprice" HeaderText="Quoted Price" />
            <asp:BoundField DataField="decideprice" HeaderText="Decide Price" />
            <asp:BoundField DataField="savings" HeaderText="Savings" />
      
    
            <asp:BoundField DataField="client" HeaderText="Client" />
      
    
            <asp:TemplateField HeaderText="From">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Fromloc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Fromloc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ToLoc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Toloc") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Toloc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
      
    
            <asp:TemplateField HeaderText="Distance">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Distance") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Distance") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
      
    
       </Columns>
     
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>

 </asp:Panel>

    <br /><br /><br /><br /><br />
            
</asp:Content>

