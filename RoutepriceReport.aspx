<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RoutepriceReport.aspx.cs" Inherits="UserControl_RoutepriceReport"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br /><br /><br /><br /><br />

    <div style="margin-left:500px"><h2  class="title-one">ROUTE PRICE CHART</h2></div>
    <br />
       <div style="margin-left:450px">
<asp:RadioButton ID="RadOptionTransport" runat="server"  GroupName="a" Text="TransporterWise" Checked="true" /><asp:RadioButton
           ID="RadOptionClient" runat="server"  GroupName="a" Text="ClientWise" runat="server"     />
    <asp:Button
               ID="ButShow" runat="server" Text="Show" onclick="ButShow_Click"  Class="btn btn-primary" />
                   <asp:Button ID="ButExcel" runat="server" Text="Download to Excel" onclick="ButExcel_Click"   Class="btn btn-primary" />
    
</div>
    <br />
 
    <div style="margin-left:150px">

<asp:GridView ID="GridRouteprice" runat="server" AutoGenerateColumns="False" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" 
        onrowdatabound="GridRouteprice_RowDataBound"  Width="70%">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
   
        <asp:TemplateField>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("transporter") %>'></asp:TextBox>
            </EditItemTemplate>
      <%--      <HeaderTemplate>
                <asp:DropDownList ID="DDLTransporter" runat="server" AutoPostBack="True" 
                    Height="23px" onselectedindexchanged="DDLTransporter_SelectedIndexChanged" 
                    Width="156px">
                </asp:DropDownList>
            </HeaderTemplate>--%>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("transporter") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
     
        <asp:BoundField DataField="From" />
        <asp:BoundField DataField="To" />
        <asp:BoundField DataField="TruckType" />
        <asp:BoundField DataField="Encltype" />
        <asp:BoundField DataField="Capacity" />
        <asp:BoundField DataField="Oneway" />
        <asp:BoundField DataField="Twoway" />
        <asp:TemplateField>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Client") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Client") %>'></asp:Label>
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
    </div>
    <br /><br /><br /><br /><br />
</asp:Content>

