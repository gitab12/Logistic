<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AArmsAdsControl.ascx.cs" Inherits="UserControl_AArmsAdsControl" %>

<table width="70%">
    <tr>
        <td >
         <asp:GridView ID="Gridclientplan" runat="server" width="70%" AutoGenerateColumns="False" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" GridLines="Vertical" onrowdatabound="Gridclientplan_RowDataBound"  >
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
       <asp:TemplateField HeaderText="AdID">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Adid") %>' ></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
              <asp:Label ID="lblAdIDheader" Text="AdID" runat="server" Width="150px"/>
                <br />
                
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblAdID" runat="server" Text='<%# Bind("Adid") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    
        <asp:TemplateField HeaderText="Source">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FromLocation") %>' ></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
              <asp:Label ID="lblsource" Text="Source" runat="server" Width="80px"/>
                <br />
                <asp:DropDownList ID="DDLsource" runat="server" Width="80px">
               
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Mumbai</asp:ListItem>
                    <asp:ListItem>New Delhi</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblsource" runat="server" Text='<%# Bind("FromLocation") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ToLocation") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lbldesg" Text="Designation" runat="server" />
                <br />
                <asp:DropDownList ID="DDLdesignation" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
               <asp:ListItem>Mumbai</asp:ListItem>
                    <asp:ListItem>New Delhi</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ToLocation") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type/Capacity">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Capacity") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lblTrucktype" Text="Type/Capacity" runat="server"  Width="120px" />
                <br />
                <asp:DropDownList ID="DDLtrucktype" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Rigid Truck/500tons</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Capacity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Type">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TravelType") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lbltraveltype" Text="Travel Type" runat="server"/>
                <br />
                <asp:DropDownList ID="DDLtraveltype" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>One Way</asp:ListItem>
                    <asp:ListItem>Two Way</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("TravelType") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Required">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TruckCount") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("TruckCount") %>'></asp:Label>
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
        </td>
    </tr>
</table>
