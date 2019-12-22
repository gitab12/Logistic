<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="ListProduct.aspx.cs" Inherits="ListProduct"  %>
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
    <br />
     <div style="margin-left:200px">
     <div style="margin-left:250px">
    <asp:Label ID="lblstatus" runat="server" Font-Bold="True" Font-Names="Arial" 
           Font-Size="12pt" ForeColor="Red" Text="Select Product Status :" Width="202px"></asp:Label>
       <asp:DropDownList ID="ddlstatus" runat="server" Height="29px" Width="189px" 
           AutoPostBack="True" onselectedindexchanged="ddlstatus_SelectedIndexChanged">
           <asp:ListItem Value="0">Active Products</asp:ListItem>
           <asp:ListItem Value="1">Deactivated Products</asp:ListItem>
       </asp:DropDownList>
       <br />
       <br />
        </div>
    <div style="width:675px;float:left; " >
     <asp:Panel ID="Panel1" runat="server" GroupingText="Product List" Font-Bold="true" ScrollBars="Auto">
        <asp:Label ID="DispTbl" runat="server" ForeColor="#404040"></asp:Label>
             <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="70px" Visible="false"></asp:Label>
              <asp:Panel ID="Panel9" runat="server" ScrollBars="Auto" Font-Bold="false">
               <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" onrowdatabound="GridView1_RowDataBound" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black">
               <RowStyle Height="30px" />
                 <Columns>
                 <asp:BoundField DataField="ProductID" HeaderText="ID" />
                 <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                 <asp:BoundField DataField="ProductType" HeaderText="ProductType" />
                 <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
                 <asp:BoundField DataField="StockKeepingUnitID" HeaderText="StockID" />
                 <asp:BoundField DataField="TransportationCost" HeaderText="TransportationCost" />
              
                  <asp:TemplateField Visible="False">
	               
	               <ItemTemplate>
	                 <asp:LinkButton ID="linkbtn1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false" CommandArgument ='<%#Eval("ProductID") %>'>View</asp:LinkButton>
	               </ItemTemplate>
	               </asp:TemplateField>  
               
                 <asp:CommandField ShowDeleteButton="true" DeleteText="Deactivate"/>
                 </Columns>
                  <FooterStyle BackColor="ControlDarkDark" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                  <HeaderStyle BackColor="ControlDarkDark" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
               
           
               <br />
            </asp:Panel>
       </asp:Panel>
    </div>
         </div>
    <br /><br /><br /><br /><br /><br />
</asp:Content>

