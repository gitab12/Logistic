<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="AARMSDashboard.aspx.cs" Inherits="AARMSDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/>
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div style="margin-left:400px">
<table width="70%">
   <tr>
   <td>
   <br />
       <br />
       Select ClientName : <asp:DropDownList ID="ddl_ClientName" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="ddl_ClientName_SelectedIndexChanged"></asp:DropDownList>
       <br />
       <br />
  </div>
    <asp:Panel ID="pnl_TransportAnalysis" runat="server"    Height="600px" Width="600px" ScrollBars="Auto"  Style="margin-left:1px" >     
    <asp:GridView ID="Gridwindow" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="False" 
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <Columns>
                  <asp:TemplateField HeaderText="Sno">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextSno" runat="server" Text='<%# Bind("Sno") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="LabelSno" runat="server" Text='<%# Bind("Sno") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="ClientName">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="ClientID" Visible="False">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ClientID") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="NoofAdPosted">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NoofAdPosted") %>'  Style="color:blue;text-decoration:underline"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:HyperLink ID="postadLink" runat="server"  Text='<%#Eval("NoofAdPosted")%>'  NavigateUrl=<%# String.Format("javascript:void(window.open('PostedAdByClient.aspx?CltID={0}',null,'right=362px, top=134px, width=1000px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ClientID")) %> Style="color:blue;text-decoration:underline"></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="NoofQuotesReceived">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" 
                              Text='<%# Bind("QuoteReceived") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:HyperLink ID="QuotesLink" runat="server" Text='Click to view quotes'  NavigateUrl=<%# String.Format("javascript:void(window.open('QouteReceivedforClient.aspx?CltID={0}',null,'right=362px, top=134px, width=1000px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ClientID")) %> Style="color:blue;text-decoration:underline"></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="TripsRequested">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TripsRequested") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:HyperLink ID="TripRequestlink" runat="server" Text='<%#Eval("TripsRequested")%>'  NavigateUrl=<%# String.Format("javascript:void(window.open('TripRequest.aspx?CltID={0}',null,'right=362px, top=134px, width=1000px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ClientID")) %> Style="color:blue;text-decoration:underline"></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="TripsConfirmed">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TripsConfirmed") %>' ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:HyperLink ID="tripConfirmedLink" runat="server" Text='<%#Eval("TripsConfirmed")%>'  NavigateUrl=<%# String.Format("javascript:void(window.open('TripConfirmed.aspx?CltID={0}',null,'right=362px, top=134px, width=1000px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ClientID")) %> Style="color:blue;text-decoration:underline"></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
         </td>
   </tr>
   
   </table>
      
         </asp:Panel>
      <br />  <br />  <br />  <br />  <br />  <br />  <br />
</asp:Content>

