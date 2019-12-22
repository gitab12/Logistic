<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="AarmsTripplan.aspx.cs" Inherits="AarmsTripplan"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<br /><br /><br /><br /><br /><br /><br />
  <%--  <table>
        <tr>
            <td style="width: 70%">
            
<UC1:Trip ID="Trip1" runat="server" />
            </td>
        </tr>
    </table>
  --%>

    <div style="margin-left:400px">
        Show only by
<asp:DropDownList ID="DDLShow" runat="server" AutoPostBack="True" 
    onselectedindexchanged="DDLShow_SelectedIndexChanged">
    <asp:ListItem>Trip Date</asp:ListItem>
    <asp:ListItem>Client Name</asp:ListItem>
</asp:DropDownList>&nbsp;
<asp:DropDownList ID="DDLCategory" runat="server" Width="200px" 
    AutoPostBack="True" onselectedindexchanged="DDLCategory_SelectedIndexChanged">
   
</asp:DropDownList>
<asp:Button ID="DownLoad" runat="server" Text="Download" onclick="DownLoad_Click"  Class="btn btn-primary"/>
    </div>
<table>
<tr>
<td>


    </td>
</tr>
    
<tr>
        <td >
<br /><br />

<asp:Panel ID="pnl_clientplan" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
<asp:GridView ID="Gridclientplan" runat="server" AutoGenerateColumns="False" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" GridLines="Vertical" onrowdatabound="Gridclientplan_RowDataBound" >
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
        <asp:TemplateField HeaderText="Client">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("client") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Lblclient" runat="server" Text='<%# Bind("client") %>' Width="100px"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Source">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("source") %>' ></asp:TextBox>
            </EditItemTemplate>
     
            <ItemTemplate>
              <asp:Label ID="Label2" runat="server" Text='<%# Bind("source") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("designation") %>'></asp:TextBox>
            </EditItemTemplate>
            <%--<HeaderTemplate>
             <asp:Label ID="lbldesg" Text="Designation" runat="server" />
                <br />
                <asp:DropDownList ID="DDLdesignation" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
               
                    <asp:ListItem>Mumbai</asp:ListItem>
                    <asp:ListItem>New Delhi</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>--%>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("designation") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type/Capacity">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("truckcapacity") %>'></asp:TextBox>
            </EditItemTemplate>
            <%--<HeaderTemplate>
             <asp:Label ID="lblTrucktype" Text="Type/Capacity" runat="server" />
                <br />
                <asp:DropDownList ID="DDLtrucktype" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Rigid Truck/500tons</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>--%>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("truckcapacity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Type">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("traveltype") %>'></asp:TextBox>
            </EditItemTemplate>
           <%-- <HeaderTemplate>
             <asp:Label ID="lbltraveltype" Text="Travel Type" runat="server" />
                <br />
                <asp:DropDownList ID="DDLtraveltype" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>One Way</asp:ListItem>
                    <asp:ListItem>Two Way</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>--%>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("traveltype") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Required">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("truckreq") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("truckreq") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Budget Cost/Truck" >
            <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("budget") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("budget") %>'></asp:Label>
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
</td> 
</tr> 
</table>

</asp:Content>

