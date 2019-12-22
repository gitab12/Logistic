<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BiddingStatus.aspx.cs" Inherits="BiddingStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
<meta http-equiv="Refresh" content="12" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
   <div style="margin-left:500px"> 
       <h2 class="title-one">Bidding Status</h2>
      <br /><br />
            <asp:Label ID="Label2" runat="server" Text="" Font-Size="17pt" 
            ForeColor="Maroon"></asp:Label>
           </div><br />
    <div>
        <asp:Panel ID="Panel1" runat="server"  Height="150px" Width="90%" ScrollBars="Auto"  Style="margin-left:200px" >
              <asp:GridView ID="GridViewSummary" runat="server" AutoGenerateColumns="true" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" ShowFooter ="true" 
        CellPadding="2" ForeColor="Black" Visible="true" OnRowDataBound="GridViewSummary_RowDataBound" >
        <Columns>
            <%--<asp:BoundField DataField="Transporter" HeaderText="Transporter" />
            <asp:BoundField DataField="FinalValue" HeaderText="Pre-Bid" />
            <asp:BoundField DataField="Level" HeaderText="Present Level" />
              <asp:BoundField DataField="Difference" HeaderText="Difference" Visible="false" />
              
              <asp:BoundField DataField="OriginalValue" HeaderText="Post-Bid" />
              <asp:BoundField DataField="Decrement" HeaderText="Decrement" />
              <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                   <asp:TemplateField HeaderText="CurrentStatus">
                                        <ItemTemplate>
                                    
<asp:HyperLink ID="lnkstatus" runat="server"  Text='<%#Eval("CurrentStatus")%>' ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    
                                     <asp:TemplateField HeaderText="Log">
                                        <ItemTemplate>
                                    
<asp:HyperLink ID="lnklog" runat="server"  Text='Log'  NavigateUrl=<%# String.Format("javascript:void(window.open('log.aspx?logID={0}',null,'right=362px, top=134px, width=800px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("Log")) %>></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                    
<asp:HyperLink ID="lnkDetailed" runat="server"  Text='Detailed'  NavigateUrl=<%# String.Format("javascript:void(window.open('Detailed.aspx?Reg={0}',null,'right=362px, top=134px, width=800px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("Region")) %>></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
            </asp:Panel>
        <br />
         <asp:Panel ID="pnl_1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="150px" Width="90%" ScrollBars="Auto"  Style="margin-left:200px" >
    <asp:GridView ID="GridRoutewiseLevel" runat="server" AutoGenerateColumns="false" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" ShowFooter ="true" 
        CellPadding="2" ForeColor="Black" Visible="true"  >
        <Columns>
            <asp:BoundField HeaderText ="FromLocation" DataField ="FromLocation" />
            <asp:BoundField HeaderText ="ToLocation" DataField ="ToLocation" />
            <asp:BoundField HeaderText ="Taurus (L1 Rate)" DataField ="Taurus" />
            <asp:BoundField HeaderText ="32Ft Container Multi Axle (L1 Rate)" DataField ="32Ft Container Multi Axle" />
              <asp:BoundField HeaderText ="Trailler (L1 Rate)" DataField ="Trailer" />
                  <asp:BoundField HeaderText ="19FT LPT (L1 Rate)" DataField ="19FT LPT" />                    
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
             </asp:Panel>
   <br /> <br /> <br />
        <div style="margin-left:300px">
            Enter Region for Search<asp:TextBox ID="txtfrom" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="Butsearch" runat="server" Text="Search" onclick="Butsearch_Click" Class="btn btn-primary" />&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Export to Excel" OnClick="Button1_Click"  Class="btn btn-primary"/>&nbsp;
     <a href ="http://www.scmbizconnect.com/QouteReceivedforClient.aspx?CltID=" target ="_blank" >View All Quotes</a>
            </div>
        <br />
        <asp:Panel ID="Panel2" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="150px" Width="90%" ScrollBars="Auto"  Style="margin-left:200px" >
<asp:GridView ID="GridQuotingLevel" runat="server" CellPadding="4" OnRowDataBound="GridQuotingLevel_RowDataBound"
        ForeColor="#333333" AutoGenerateColumns="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="Fromlocation" HeaderText="From" Visible ="false"  />
            <asp:BoundField DataField="Tolocation" HeaderText="To" />
            <asp:BoundField DataField="TruckType" HeaderText="Truck Type" />
            <asp:BoundField DataField="TruckCapacity" HeaderText="Capacity" />
             <asp:BoundField DataField="TrucksReq" HeaderText="TrucksReq" />
             <asp:BoundField DataField="ClientPrice" HeaderText="ClientPrice" />
            <asp:BoundField  HeaderText="Level1">
                <ItemStyle Font-Bold="true"  />
            </asp:BoundField>
              <asp:BoundField  HeaderText="Level2">
                 
                <ItemStyle Font-Bold="false"   />
            </asp:BoundField>
              <asp:BoundField  HeaderText="Level3">
                <ItemStyle Font-Bold="false" ForeColor="Goldenrod" />
            </asp:BoundField>
              <asp:BoundField  HeaderText="Level4">
                <ItemStyle Font-Bold="false"  />
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
    <br />
         <div style="margin-left:300px">
    Total No Of Transporters:<asp:Label ID="lbltotaltransporter" runat="server" Text="Label" Font-Bold="true" ForeColor="Red" ></asp:Label>
             </div>
        <asp:Panel ID="Panel3" runat="server"   Height="150px" Width="90%" ScrollBars="Auto"  Style="margin-left:200px" >
    <asp:GridView ID="grd_Display" runat="server" CellPadding="4" 
        ForeColor="#333333" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
            </asp:Panel>
        <br /><br /><br /><br /><br /><br />
        </div>
</asp:Content>

