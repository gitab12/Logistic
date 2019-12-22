<%@ Control Language="VB" AutoEventWireup="false" CodeFile="QuoteReceivedControl.ascx.vb" Inherits="UserControl_QuoteReceivedrControl" %>

<table width="70%" >
<tr>
<td>
<asp:Button ID="btnexport" runat="server" Text="Export to Excel" Visible="false"  />
</td>
</tr>
    <tr>
        <td >
            <asp:GridView ID="GridQuote" runat="server" width="100px" AutoGenerateColumns="False" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" GridLines="Vertical" onrowdatabound="GridQuote_RowDataBound" AllowSorting="True" >
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
       <asp:TemplateField HeaderText="AdID">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Adid") %>' ></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
              <asp:Label ID="lblAdIDheader" Text="AdID" runat="server" Width="10px"/>
                <br />
                
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblAdID" runat="server" Text='<%# Bind("Adid") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    
    
    
        <asp:TemplateField HeaderText="Source">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("source") %>' ></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
              <asp:Label ID="lblsource" Text="Source" runat="server" Width="10px"/>
                <br />
                <asp:DropDownList ID="DDLsource" runat="server" Width="50px" style="color:#000;">
               
                    <asp:ListItem style="color:#000;" >All</asp:ListItem>
                    <asp:ListItem  style="color:#000;" >Mumbai</asp:ListItem>
                    <asp:ListItem style="color:#000;" >New Delhi</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblsource" runat="server" Text='<%# Bind("source") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("designation") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lbldesg" Text="Designation" runat="server" />
                <br />
                <asp:DropDownList ID="DDLdesignation" runat="server" Width="50px" style="color:#000;">
                    <asp:ListItem Style="color:#000;" >All</asp:ListItem>
               
                    <asp:ListItem Style="color:#000;" >Mumbai</asp:ListItem>
                    <asp:ListItem Style="color:#000;" >New Delhi</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("designation") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type/Capacity">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("truckcapacity") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lblTrucktype" Text="Type/Capacity" runat="server" />
                <br />
                <asp:DropDownList ID="DDLtrucktype" runat="server" Width="50px" style="color:#000;">
                    <asp:ListItem style="color:#000;" >All</asp:ListItem>
                    <asp:ListItem style="color:#000;">Rigid Truck/500tons</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("truckcapacity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Type">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("traveltype") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lbltraveltype" Text="Travel Type" runat="server" />
                <br />
               <%-- <asp:DropDownList ID="DDLtraveltype" runat="server" Width="50px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>One Way</asp:ListItem>
                    <asp:ListItem>Two Way</asp:ListItem>
                </asp:DropDownList>--%>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("traveltype") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QuoteID">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("quoteid") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("quoteid") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("trans") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("trans") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Trucks Req.">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("trucksreqed") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label8" runat="server" Text='<%# Bind("trucksreqed") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Trucks offered">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("truckreq") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("truckreq") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Offered Cost">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cost") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("cost") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10px" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Quoted Date">
            <EditItemTemplate>
                 <asp:Label ID="Lbledtquoteddate" runat="server" Text='<%# Bind("QuotedDate") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblQuotedDate" runat="server" Text='<%# Bind("QuotedDate") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10px" />
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
