<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="ListCustomer.aspx.cs" Inherits="ListCustomer"  %>
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
           Font-Size="12pt" ForeColor="Red" Text="Select Customer Status :" Width="202px"></asp:Label>
       <asp:DropDownList ID="ddlstatus" runat="server" Height="29px" Width="189px" 
           AutoPostBack="True" onselectedindexchanged="ddlstatus_SelectedIndexChanged">
           <asp:ListItem Value="0">Active Customers</asp:ListItem>
           <asp:ListItem Value="1">Deactivated customers</asp:ListItem>
       </asp:DropDownList>
       <br />
       <br />
     </div>
         <div style="width:875px;float:left; " >
     <asp:Panel ID="Panel1" runat="server"  Font-Bold="false" Height ="450px" ScrollBars="Auto" Width="110%" GroupingText="Customer List">
        <asp:Label ID="DispTbl" runat="server" ForeColor="#404040"></asp:Label>
            <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="70px"></asp:Label>
            <br />
               <asp:Panel ID="Panel9" runat="server" ScrollBars="Auto" Font-Bold="false">
               <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" onrowdatabound="GridView1_RowDataBound" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black">
               <RowStyle Height="30px" />
                 <Columns>
                 <asp:BoundField DataField="CustomerID" HeaderText="ID" />
                 <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
                 <asp:BoundField DataField="WebsiteURL" HeaderText="URL" />
                 <asp:BoundField DataField="CorporateEmail" HeaderText="CorporateEmail" />
                 <asp:BoundField DataField="ContactPerson" HeaderText="ContactPerson" />
                 <asp:BoundField DataField="BoardNo" HeaderText="BoardNo" />
                 <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" />
                 <asp:BoundField DataField="LocationType" HeaderText="Location" />
                 <asp:TemplateField>
	               
	               <ItemTemplate>
	                 <asp:LinkButton ID="linkbtn1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false" CommandArgument ='<%#Eval("CustomerID") %>'>Edit</asp:LinkButton>
	               </ItemTemplate>
	               
	               
	               </asp:TemplateField>  
               
                 <asp:CommandField ShowDeleteButton="true" DeleteText="Deactivate"  />
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
              <br /><br /><br /><br /><br /><br />
    </div>
        </div>
   
</asp:Content>

