<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PreRequestApproval.aspx.cs" Inherits="UserControl_PreRequestApproval"  %>
<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagPrefix="uc1" TagName="DashboardMenuBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link id="Linl1" rel="shortcut icon"  runat="server"   type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
//Calculation for saving
function calculation(evt)
{

    var a = document.getElementById('ctl00_ContentPlaceHolder1_GridAssign_ctl06_Txtcost').value;
   
    alert(a);
    alert("b");
    alert("c");

	return false;
	 return true;
}


</script>
  <br /><br /><br /><br /><br /><br />
    <uc1:DashboardMenuBar runat="server" ID="DashboardMenuBar" />
&nbsp;<br />
    <div style="margin-left:330px">

    <table width="70%">
        <tr>
            <td style="width: 100px; height: 205px;">
                <br />
                <asp:Label ID="Lblmsg" runat="server" ForeColor="Red" Text="Trips Approved" 
                    Visible="False"></asp:Label>
    <asp:GridView ID="GridAssign" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="Vertical" Width="69%" Font-Names="Arial" 
                    Font-Size="10pt" onrowdatabound="GridAssign_RowDataBound" 
                 >
        <RowStyle BackColor="#C2DDEB" ForeColor="#333333" BorderStyle="None" Width="70%" />
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="Check" runat="server" Text="."/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trip ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("adid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbladid" runat="server" Text='<%# Bind("adid") %>' Width="100px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="From">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("From") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("From") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("To") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("To") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type/Capacity" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("trucktype") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("trucktype") %>' Width="80px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trucks Req.">
            
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("trucks") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("trucks") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Budget Cost">
             
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Bcost") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Lblbudgetcost" runat="server" Text='<%# Bind("Bcost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trucks Assigned">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("assigned") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                <asp:TextBox ID="Txtassign" runat="server" Text='<%# Bind("assigned") %>' Width="50px" onkeyup="return calculation(event)">></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted Cost/Truck">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("cost") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    &nbsp;<asp:TextBox ID="Txtcost" runat="server" Text='<%# Bind("cost") %>' Width="50px" onkeyup="return calculation(event)">></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Saving">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("saving") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("saving") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("PreAssid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LblID" runat="server" Text='<%# Bind("PreAssid") %>'></asp:Label>
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
                <br />
                <asp:Button ID="Butapprove" runat="server" Text="Approved" OnClick="Butapprove_Click"  Class="btn btn-primary" /></td>
        </tr>
    </table>
</div>
</asp:Content>

