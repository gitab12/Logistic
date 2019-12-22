<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Tracking.aspx.cs" Inherits="Tracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
 <table align="center">
        <tr>
            <td>
                Choose Client:
            </td>
            <td>
                <asp:DropDownList ID="ddlClient" runat="server" Width="125px">

                </asp:DropDownList>
            </td>
            <td>&nbsp;
                Month:
            </td>
            <td>
                 <asp:DropDownList ID="ddlMonth" runat="server" Width="125px">
                     <asp:ListItem>--Month--</asp:ListItem>
                     <asp:ListItem Value="1">January</asp:ListItem>
                     <asp:ListItem Value="2">February</asp:ListItem>
                     <asp:ListItem Value="3">March</asp:ListItem>
                     <asp:ListItem Value="4">April</asp:ListItem>
                     <asp:ListItem Value="5">May</asp:ListItem>
                     <asp:ListItem Value="6">June</asp:ListItem>
                     <asp:ListItem Value="7">July</asp:ListItem>
                     <asp:ListItem Value="8">August</asp:ListItem>
                     <asp:ListItem Value="9">September</asp:ListItem>
                     <asp:ListItem Value="10">October</asp:ListItem>
                     <asp:ListItem Value="11">November</asp:ListItem>
                     <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;
                <asp:Button ID="btnreport" runat="server" Text="GetReport" OnClick="btnreport_Click"  Class="btn btn-primary"/>
            </td>
           
        </tr>
    </table>
    <br />
    <br />
     <asp:Panel ID="panel_1" runat="server"   Height ="270px" ScrollBars="Auto" Width="83%" GroupingText="" Style="margin-left:100px">
    <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" OnRowDataBound="Gridwindow_RowDataBound">
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                 
                  <asp:TemplateField HeaderText="Confirm No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                         
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Client" >
                      <ItemTemplate>
                          <asp:Label ID="Label18" runat="server" Text='<%# Bind("Client") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox37" runat="server" Text='<%# Bind("Client") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                       <asp:TemplateField HeaderText="Transporter" Visible="True">
                      <ItemTemplate>
                          <asp:Label ID="Label19" runat="server" Text='<%# Bind("Transporter") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox38" runat="server" Text='<%# Bind("Transporter") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>


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
                 
                   <asp:TemplateField HeaderText="LoadingDate">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtloadingdate" runat="server" Text=''></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblLoadingDate" runat="server" Text='<%# Bind("LoadingDate") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Expected DeliveryDate">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                           <asp:Label ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:Label>
                            
                                  
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Transit Days">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("TransitDays") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lblTransitDay" runat="server" Text='<%# Bind("TransitDays") %>'></asp:Label>
                     
                      </ItemTemplate>
                  </asp:TemplateField>
                 
                 
                  <asp:TemplateField HeaderText="Delay Days">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdelay" runat="server" Text='<%# Bind("DelayDays") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lbldelayday" runat="server" Text='<%# Bind("DelayDays") %>'></asp:Label>
                     
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                
                  <asp:TemplateField HeaderText="VehicleNo">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblVehicleno" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Driver">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DriverName") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblDriver" runat="server" Text='<%# Bind("DriverName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="MobileNo">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("mobileNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("mobileNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Remarks">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("mobileNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtRemarks" runat="server" Height="37px" TextMode="MultiLine" Width="171px"  ></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="TransportEmail" Visible="false">
                      <EditItemTemplate>
                          <asp:TextBox ID="txt_transEmail" runat="server" Text='<%# Bind("TransporterEmailID") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                           <asp:Label ID="lbltransporteremail" runat="server" Text='<%# Bind("TransporterEmailID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   
                       <asp:TemplateField HeaderText="Submit">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                      
                          &nbsp; <asp:Button ID="ButSubmit" runat="server" Text="Submit" OnClick="ButSubmit_Click"></asp:Button>
                         
                           &nbsp;<asp:Button ID="ButDelivered" runat="server" Text="Delivered" OnClick="ButDelivered_Click" ></asp:Button>
                        
                            &nbsp;<asp:Button ID="btnDelay" runat="server" Text="Delay" Enabled="false" OnClick="btnDelay_Click" ></asp:Button>
                        
                     <asp:Label ID="lblPLid" runat="server" Text='<%# Bind("PLid") %>' forecolor="white"></asp:Label>
                         
                      </ItemTemplate>
                  </asp:TemplateField>
                
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
 </asp:Panel>
</asp:Content>

