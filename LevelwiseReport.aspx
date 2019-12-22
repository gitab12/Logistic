<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="LevelwiseReport.aspx.cs" Inherits="LevelwiseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br />

    <style type="text/css">
    .color {
     font-family: Arial, Helvetica, sans-serif;
     font-size: 2.0em;
     font-style: bold;
     color:Red;
 }
</style>
    <div style="margin-left:450px"><h2 class="title-one"> Levelwise Report</h2></div>
     <div style="margin-left:200px">
                   &nbsp;<asp:Button ID="ButExcel" runat="server" Text="Download to Excel"  onclick="ButExcel_Click" Class="btn btn-primary" /> 

    <br /><br />
         </div>
   <asp:Panel ID="pnl_1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
    <asp:GridView ID="grd_LevelWiseReport" runat="server" BorderColor="#E0E0E0" 
    CellPadding="4" ForeColor="#333333" 
         Width="70%" AutoGenerateColumns="False">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
   
    <Columns>
                  <asp:TemplateField HeaderText="From Location">
                      <ItemTemplate>
                          <asp:Label ID="lblFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="To Location">
                      <ItemTemplate>
                          <asp:Label ID="lbltoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txttoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                              
                  
                  <asp:TemplateField HeaderText="Truck Type">
                      <ItemTemplate>
                          <asp:Label ID="lblTrucktype" runat="server" Text='<%# Bind("Trucktype") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txttrucktype" runat="server" Text='<%# Bind("Trucktype") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
            <asp:TemplateField HeaderText="QuoteDate">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtQuoteDate" runat="server" Text='<%# Bind("QuoteDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          
                          <asp:Label ID="lblQuoteDate" runat="server" Text='<%# Bind("QuoteDate") %>'></asp:Label>
                          
                      </ItemTemplate>
                                    
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="QuotePrice">
                      <ItemTemplate>
                          <asp:Label ID="lbl_QuotePrice" runat="server" Text='<%# Bind("QuotePrice") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txt_QuotePrice" runat="server" Text='<%# Bind("QuotePrice") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
         <asp:TemplateField HeaderText="Transporter">
                      <EditItemTemplate>
                          <asp:TextBox ID="txt_Transporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          
                          <asp:Label ID="lbl_Transporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:Label>
                          
                      </ItemTemplate>
                      
                       
                  </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Level" ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Red" >
                      <EditItemTemplate>
                          <asp:TextBox ID="txt_Level" runat="server" Text='<%# Bind("level") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>  
                          <asp:Label ID="lbl_Level" runat="server" Text='<%# Bind("level") %>' Font-Bold ="true" ForeColor ="Red" ></asp:Label> 
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
      
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
     <br /><br /><br /><br /><br />

</asp:Content>

