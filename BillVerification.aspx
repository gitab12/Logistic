<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="BillVerification.aspx.cs" Inherits="BillVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div style="margin-left:120px">
    <table >
        <tr>
            <td colspan ="4">
                <div style="margin-left:120px">
                 <center><h2 class="title-one">Bill Verification</h2></center> 
                    </div>
     <br />
            </td>
        </tr>
        
        <tr>
            <td>
             
         Transporter    <asp:DropDownList ID="ddl_Transporter" runat="server" Width ="180px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_Transporter_SelectedIndexChanged"  ></asp:DropDownList>

            &nbsp;&nbsp;&nbsp;&nbsp;

            </td>
            <td>
        Project No         <asp:DropDownList ID="ddl_Projectno" runat="server" Width ="150px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_Projectno_SelectedIndexChanged"  ></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
         Bill No        <asp:DropDownList ID="ddl_BillNo" runat="server" Width ="150px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_BillNo_SelectedIndexChanged"  ></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
           LR No      <asp:DropDownList ID="ddl_LrNo" runat="server" Width ="150px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_LrNo_SelectedIndexChanged"  ></asp:DropDownList>
            </td>
           
        </tr>
            
        </table>
      </div>
    <br />
    <br />
     <div style="margin-left:40px">
      <asp:Panel ID ="pnl_BillVerification" runat ="server" Width ="1300px" Height ="200px" ScrollBars ="Horizontal" Visible ="false"  >
   <asp:GridView ID="grd_BillVerification" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="False" 
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <Columns>
                  <asp:BoundField DataField="ProjectNo" HeaderText="ProjectNo" />
                  <asp:BoundField DataField="CollectionNoteNumber" HeaderText="CNNo" />
                  <asp:BoundField DataField="ConfirmNo" HeaderText="ConfirmNo" />
                  <asp:BoundField DataField="Transporter" HeaderText="Transporter" />
                  <asp:BoundField DataField="FromLocation" HeaderText="FromLocation" />
                  <asp:BoundField DataField="ToLocation" HeaderText="ToLocation" />
                  <asp:BoundField DataField="TravelDate" HeaderText="TravelDate" />
                  <asp:BoundField DataField="TruckType" HeaderText="TruckType" />
                   <asp:BoundField DataField="LRNumber" HeaderText="LRNumber" />
                  <asp:BoundField DataField="BillSubmissionNo" HeaderText="BillSubmissionNo" Visible ="false"  />
                  <asp:BoundField DataField="BillNo" HeaderText="BillNo" />
                  <asp:BoundField DataField="BillValue" HeaderText="BillValue" />
                  <asp:BoundField DataField="BillDate" HeaderText="BillDate" />
                  <asp:BoundField DataField="VehicleNo" HeaderText="VehicleNo" />
                  <asp:BoundField DataField="LoadingDate" HeaderText="LoadingDate" />
                  <asp:BoundField DataField="ReleaseDateTime" HeaderText="ReleaseDateTime" />
                   <asp:TemplateField HeaderText="Vehicle Image of Loading Point">

                      <ItemTemplate>
                        <%--   <asp:ImageButton ID="imgbtn_Vehicle" runat="server" Height="43px" Width="119px" ImageUrl='<%# Eval("ConfirmNo", "ImageHandler.ashx?ImageID={0}")%>' ></asp:ImageButton>--%>
                          <asp:Label ID="lbl_ConfirmNo" runat="server" Text='<%# Bind("ConfirmNo") %>' Visible="false" ></asp:Label>
                         <asp:LinkButton ID="link_preview" runat="server" Width="100px"  onclick="link_preview_Click">Four view of truck</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" />
                    <asp:TemplateField HeaderText="Vehicle Image of UnLoading Point">
                      <ItemTemplate>
                           <%-- <asp:ImageButton ID="ImageButton1" runat="server" Height="43px" Width="119px" ImageUrl='<%# Eval("ConfirmNo", "UnloadImageHandler.ashx?ImgID={0}")%>' ></asp:ImageButton>--%>
                          <asp:Label ID="lbl_UnloadConfirmNo" runat="server" Text='<%# Bind("ConfirmNo") %>' Visible="false" ></asp:Label>
                         <asp:LinkButton ID="link_Unloading" runat="server" Width="100px"  onclick="link_Unloading_Click">Truck image</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="BillImage">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BillImage") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <%-- <a href="BillPreview.aspx" onClick="return popup(this, 'notes')">  <asp:Image ID="Image1" runat="server" Height="43px" Width="119px"   ImageUrl='<%# Eval("BillSubmissionNo", "BillImage.ashx?ImageID={0}")%>'/></a>--%>
                        <asp:ImageButton ID="Image1" runat="server" Height="43px" Width="119px" 
                              ImageUrl='<%# Eval("BillSubmissionNo", "BillImage.ashx?ImageID={0}")%>' 
                              onclick="Image1_Click"/>
                          <asp:Label ID="imgID" runat="server" Text='<%# Bind("BillSubmissionNo") %>' Visible ="false" ></asp:Label>
          
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
         </div>
    <br /><br /><br />  <br /><br /><br />  <br /><br /><br /> <br /><br /><br />
</asp:Content>

