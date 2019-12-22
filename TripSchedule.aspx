<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="TripSchedule.aspx.cs" Inherits="TripSchedule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
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


 <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
<center><table id="tbl">
<tr>
<td>
&nbsp;</td>
<td>
Select Project<br />
    <asp:DropDownList ID="DrpProject" runat="server" Width="150px" 
        AutoPostBack="True" onselectedindexchanged="DrpProject_SelectedIndexChanged">
    </asp:DropDownList>
</td>
<td>
Select WBS
    <asp:Panel ID="Panel1" runat="server" Height="125px" ScrollBars="Vertical" Width="125px">
        <asp:CheckBox ID="Checkall" runat="server" Text ="All" AutoPostBack="True" 
            oncheckedchanged="Checkall_CheckedChanged"/>
        <asp:CheckBoxList ID="chkWBS" runat="server">
        </asp:CheckBoxList>
    </asp:Panel>

</td>
    <br />
<td >&nbsp;&nbsp;
    <asp:Button ID="ButDisplay" runat="server" Text="Show"  Width="160PX"
        onclick="ButDisplay_Click" class="btn btn-primary"/>
    
    <br /><br />
    &nbsp;&nbsp;<asp:Button ID="ButPostAd" runat="server" Text="Place Vehicle"  Visible="false"
        onclick="ButPostAd_Click" class="btn btn-primary"/>
        <asp:Button ID="btn_uploadindent" runat="server" Text="Upload Rate Contract"  
        onclick="btn_uploadindent_Click"  class="btn btn-primary"/>
    
</td>
</tr>
</table></center>
    <br />
     <asp:Panel ID="panel2" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="300px" Width="1200px" ScrollBars="Auto"  Style="margin-left:100px" Visible="false">
    <div style="margin-left:100px">
<asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" 
             onrowediting="Gridwindow_RowEditing" 
                    onrowcancelingedit="Gridwindow_RowCancelingEdit" 
                    onrowupdating="Gridwindow_RowUpdating" onrowdatabound="Gridwindow_RowDataBound" >
        
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
              
                 <%-- <asp:TemplateField HeaderText="Unit">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtunit" runat="server" Text='<%# Bind("UoM") %>' Width="15px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="txtunit" runat="server" Text='<%# Bind("UoM") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                  <%--<asp:TemplateField HeaderText="To">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTo" runat="server" Text='<%# Bind("Delivery") %>' Width="100px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="txtTo" runat="server" Text='<%# Bind("Delivery") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                  <%-- <asp:TemplateField HeaderText="Total Wt in Tons">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTotalWeight" runat="server" Text='<%# Bind("weight") %>' Width="45px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="txtTotalWeight" runat="server" Text='<%# Bind("weight") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                     <asp:TemplateField HeaderText="Length">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtLength" runat="server" Text='<%# Bind("Length_M") %>' Width="15px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblLength" runat="server" Text='<%# Bind("Length_M") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                    <asp:TemplateField HeaderText="Width">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtWidth" runat="server" Text='<%# Bind("Width_M") %>' Width="15px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblWidth" runat="server" Text='<%# Bind("Width_M") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                       <asp:TemplateField HeaderText="Height">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtHeight" runat="server" Text='<%# Bind("Height_M") %>' Width="15px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblHeight" runat="server" Text='<%# Bind("Height_M") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  --%>
                  
             
                  
                                 <%-- <asp:TemplateField HeaderText="Encl.Type">
                      <EditItemTemplate>
                         
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:DropDownList ID="DDLEnclType" runat="server" width="80Px" >
                              <asp:ListItem Value="0">Open</asp:ListItem>
                              <asp:ListItem Value="1">Close</asp:ListItem>
                          </asp:DropDownList>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                
                 <asp:TemplateField HeaderText="IndentID" Visible="True">
                      
                      <HeaderTemplate>
                             <asp:CheckBox ID="ChkAll" runat="server"  Text= "ALL"/>
                         </HeaderTemplate>
                      <ItemTemplate>
                         <asp:CheckBox ID="ChkAll" runat="server" Text='<%# Bind("IndentID") %>' />
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                 <asp:TemplateField HeaderText="ProjectNo">
                      
                         <ItemTemplate>
                             
                              <asp:Label ID="lblProjectNo" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                         </ItemTemplate>
                         
                          <EditItemTemplate>
                              
                              <asp:Label ID="lblProjectNo" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                         </EditItemTemplate>
                         
                     </asp:TemplateField>
              
              
                     <asp:TemplateField HeaderText="WBS">
                         <EditItemTemplate>
                                <asp:Label ID="lblWbs" runat="server" Text='<%# Bind("wbs") %>'></asp:Label>
                         </EditItemTemplate>
                         
                         <ItemTemplate>
                             
                              <asp:Label ID="lblWbs" runat="server" Text='<%# Bind("wbs") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                              
                  
                  <asp:TemplateField HeaderText="Description">
                      <EditItemTemplate>
                        <asp:Label ID="txtproduct" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="txtproduct" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Qty">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("Qty") %>' Width="15px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="txtQty" runat="server" Text='<%# Bind("Qty") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="LoadingPoint">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtFrom" runat="server" Text='<%# Bind("LoadingPoint") %>' Width="100px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="txtFrom" runat="server" Text='<%# Bind("LoadingPoint") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
              <asp:TemplateField HeaderText="DeliveryPoint">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtaddress" runat="server" BorderColor="Black" 
                              BorderStyle="Solid" BorderWidth="1px" Height="53px" Text="0" 
                              TextMode="MultiLine" Width="109px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lbldeliverypoint" runat="server" Text='<%# Bind("DeliveryPoint") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                                 <asp:TemplateField HeaderText="PlannedNoofVehicles" >
                      <EditItemTemplate>
                    <asp:TextBox ID="txtPlannedNoofVehicles"  runat="server" Text='<%# Bind("PlannedNoofVehicles") %>' Width="15px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="LblTruckPlanned" runat="server" Text='<%# Bind("PlannedNoofVehicles") %>' Width="15px" ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                      
                  <asp:TemplateField HeaderText="TypeofVehicle">
                      <EditItemTemplate>
                          <asp:DropDownList ID="DDLTruckType" runat="server" Width="80px">
                          </asp:DropDownList>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="LblTypeofVehicle" runat="server" Text='<%# Bind("TypeofVehicle") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  
                     <asp:TemplateField HeaderText="TotalAmount">
                      <EditItemTemplate>
                         <asp:TextBox ID="txtTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>' Width="85px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="LblTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                     <asp:TemplateField HeaderText="TransitDays">
                      <EditItemTemplate>
                      <asp:TextBox ID="txtTransitDays" runat="server" Text='<%# Bind("TransitDays") %>' Width="85px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="LblTransitDays" runat="server" Text='<%# Bind("TransitDays") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  
                    <asp:TemplateField HeaderText="Transporter">
                      <EditItemTemplate>
                      <asp:TextBox ID="txtTransporter" runat="server" Text='<%# Bind("Transporter") %>' Width="85px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="LblTransporter" runat="server" Text='<%# Bind("Transporter") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
              <%--<asp:TemplateField HeaderText="TravelDate">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate" runat="server"  Width="60px" Text="9/10/2012"></asp:TextBox>
                          <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txtdate">
                </ajaxToolkit:CalendarExtender>
                      </EditItemTemplate>
                      <ItemTemplate>
                             <asp:TextBox ID="txtdate" runat="server"  Width="60px" Text='<%# Bind("ScheduleDate") %>' ></asp:TextBox>
                          <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txtdate">
                </ajaxToolkit:CalendarExtender>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                 
                 <%-- <asp:CommandField HeaderText="Create/Edit" ShowEditButton="True" />--%>
               </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
       </div>

</asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />  
    </asp:Content>

