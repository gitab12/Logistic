<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DeliveryReport.aspx.cs" Inherits="DeliveryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

    <style type ="text/css">
        /*.grid-header
        {
            font-weight: bold;
            font-family: Verdana;
            font-size: 11px;
            background-color: #556B2F;
            text-decoration: underline;
            color: White;
            text-align: left;
            position: relative;
            top: expression(this.parentNode.parentNode.parentNode.scrollTop-2);
            left: expression(this.parentNode.parentNode.parentNode.scrollLeft-1);
            right: 1px;
        }

         .header  {
    font-weight:bold;
    position:static ;
    background-color:White;
    font-weight:30;
    
  }*/

    </style>

     <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=Gridwindow.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /> <br /><br /> <br /><br />
    
<center><h2 class="title-one">Delivery Report</h2></center>
    <div style="margin-left:400px">
        &nbsp;
    ProjectNo : <asp:DropDownList ID="ddl_ProjectNo" runat="server" Height="20px" AutoPostBack ="true"  OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged" Width="104px"></asp:DropDownList>
    &nbsp;&nbsp;
    WBSNo : <asp:DropDownList ID="ddl_Wbsno" runat="server" Height="20px" Width="91px" AppendDataBoundItems="True"  >
        <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search"   Class="btn btn-primary" />
    &nbsp;<br />
       
       
 
  <asp:Label ID="lbl_msg" class="alert alert-danger fade in col-md-10"  runat="server" Text=""></asp:Label>     
    

   &nbsp;
    </div>
   
   <table>
   <tr>
   <td>
        
                <asp:Panel ID="pnl_Delivery" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px">
       <asp:GridView ID="Gridwindow" runat="server" 
              ForeColor="#333333" GridLines="Both" 
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="false" AllowPaging ="true" PageSize ="100"  OnPageIndexChanging ="Gridwindow_PageIndexChanging"
             >
        <RowStyle BorderColor="Red" />
       <Columns>
       <asp:TemplateField HeaderText="CN No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Width ="40px" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                         <asp:Label ID="lblplid" runat="server" Text='<%# Bind("plid") %>' ForeColor="White"></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="ProjectNo" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblProjectNo" Width ="70px" runat="server" Text='<%# Bind("ProjectNo") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtProjectNo" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="WBSNo" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblWBSNo" runat="server" Text='<%# Bind("WBSNo") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtWBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
       <asp:TemplateField HeaderText="FromLocation" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblFromLocation" Width ="90px" runat="server" Text='<%# Bind("FromLocation") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtFromLocation" runat="server" Text='<%# Bind("FromLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="ToLocation" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblToLocation" runat="server" Text='<%# Bind("ToLocation") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtToLocation" runat="server" Text='<%# Bind("ToLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                   <asp:TemplateField HeaderText="TravelDate" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblTravelDate" Width ="80px" runat="server" Text='<%# Bind("TravelDate") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTravelDate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="VehicleNo" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblVehicleNo" Width ="100px" runat="server" Text='<%# Bind("VehicleNo") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtVehicleNo" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                  
                  <asp:TemplateField HeaderText="DriverName" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblDriverName" runat="server" Text='<%# Bind("DriverName") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtDriverName" runat="server" Text='<%# Bind("DriverName") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="MobileNo" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblmobileNo" Width ="90px" runat="server" Text='<%# Bind("mobileNo") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtmobileNo" runat="server" Text='<%# Bind("mobileNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="ReleaseDateTime" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblReleaseDateTime" Width ="110px" runat="server" Text='<%# Bind("ReleaseDateTime") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtReleaseDateTime" runat="server" Text='<%# Bind("ReleaseDateTime") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="ReceivedDate" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblReceivedDate" Width ="50px" runat="server" Text='<%# Bind("ReceivedDate") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtReceivedDate" runat="server" Text='<%# Bind("ReceivedDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="UnLoadDateTime" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblUnLoadingDateTime" Width ="150px" runat="server" Text='<%# Bind("UnLoadingDateTime") %>'  ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtUnLoadingDateTime" runat="server" Text='<%# Bind("UnLoadingDateTime") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="TotalTime" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblTotalTravelTime" Width ="210px"  runat="server" Text='<%# Bind("TotalTravelTime") %>'  ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTotalTravelTime" runat="server" Text='<%# Bind("TotalTravelTime") %>'  Width="90px"></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="LRNO" HeaderStyle-HorizontalAlign="Left"  >
                      <ItemTemplate>
                          <asp:Label ID="lblLRNO" runat="server"  Text='<%# Bind("LRNO") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtLRNO" runat="server" Text='<%# Bind("LRNO") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Remarks" Visible ="false" >
                      <ItemTemplate>
                          <asp:Label ID="lblRemarks" runat="server"  Text='<%# Bind("Remarks") %>' ></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                      </EditItemTemplate>
                       
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" >
                      <ItemTemplate>
                          <asp:Label ID="lblStatus"  runat="server" Text='<%# Bind("Status") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtStatus" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                 <asp:TemplateField HeaderText="Vehicle Image of Loading Point" HeaderStyle-HorizontalAlign="Left" >
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <%-- <a href="BillPreview.aspx" onClick="return popup(this, 'notes')">  <asp:Image ID="Image1" runat="server" Height="43px" Width="119px"   ImageUrl='<%# Eval("BillSubmissionNo", "BillImage.ashx?ImageID={0}")%>'/></a>--%>
                          <asp:ImageButton ID="Image1" runat="server" Height="43px" Width="119px" 
                              ImageUrl='<%# Eval("AcceptanceID", "ImageHandler.ashx?ImageID={0}")%>' 
                             
                              /><br />
                         <asp:LinkButton ID="link_preview" runat="server" onclick="link_preview_Click"  Style="color:blue;text-decoration:underline"  >Four view of truck</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField> 
                  
                  
        <asp:TemplateField HeaderText="Vehicle Image of UnLoading Point" HeaderStyle-HorizontalAlign="Left" >
                     <%-- <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                      </EditItemTemplate>--%>
                      <ItemTemplate>
                       <%-- <a href="BillPreview.aspx" onClick="return popup(this, 'notes')">  <asp:Image ID="Image1" runat="server" Height="43px" Width="119px"   ImageUrl='<%# Eval("BillSubmissionNo", "BillImage.ashx?ImageID={0}")%>'/></a>--%>
                      <%--    <asp:ImageButton ID="Image2" runat="server" Height="43px" Width="119px" 
                              ImageUrl='<%# Eval("AcceptanceID", "ImageHandler.ashx?ImageID={0}")%>' />--%>
                         <%--<asp:LinkButton ID="link_preview1" runat="server" onclick="link_preview1_Click"  >Four view of truck</asp:LinkButton>--%>
                              <%-- <asp:ImageButton ID="ImageButton1" runat="server" Height="43px" Width="119px" ImageUrl='<%# Eval("ConfirmNo", "UnloadImageHandler.ashx?ImgID={0}")%>' ></asp:ImageButton>--%>
                          <asp:Label ID="lbl_UnloadConfirmNo" runat="server" Text='<%# Bind("AcceptanceID") %>' Visible="false" ></asp:Label>
                         <asp:LinkButton ID="link_Unloading" runat="server" Width="100px"  onclick="link_Unloading_Click"  Style="color:blue;text-decoration:underline">Truck image</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField> 
       </Columns>
              <%--<RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000"  Font-Bold="True" ForeColor="White" CssClass ="header" />
              <AlternatingRowStyle BackColor="White" />--%>
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
           <PagerSettings Position ="Bottom"  Mode ="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
          </asp:GridView>
             </asp:Panel> 
   </td>
   </tr>
   
   </table>
</asp:Content>

