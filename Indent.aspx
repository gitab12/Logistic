<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Indent.aspx.cs" Inherits="Indent" %>
<%@ Register Src="~/UserControl/NavigationControlHome.ascx" TagPrefix="Uc4" TagName="DashboardMenuBar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br />
    <Uc4:DashboardMenuBar runat="server" id="DashboardMenuBar" />
    <br /><br />
  <div style="margin-left:350px">
  <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
<table id="tbl">

<tr>
<td>

</td>
<td>
 Project Name
   <asp:Panel ID="Panel2" runat="server" Height="125px" ScrollBars="Vertical" Width="125px">
     <asp:CheckBoxList ID="ChkProject" runat="server">
        </asp:CheckBoxList>
    <asp:Button ID="ButWbs" runat="server" Text="Show WBS" onclick="ButWbs_Click"  Class="btn btn-primary"/>
    </asp:Panel>
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
<td>
    <asp:Button ID="ButDisplay" runat="server" Text="Show Indent" 
        onclick="ButDisplay_Click" Class="btn btn-primary" /><br />
          <asp:Button ID="Buttripschedule" runat="server" Text="Show Trip Schedule" 
        onclick="Buttripschedule_Click"  Class="btn btn-primary"/>
</td>
</tr>
</table>
      </div>
       <asp:Panel ID="pnl_1" runat="server"   Height="400px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
  <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" 
             onrowediting="Gridwindow_RowEditing" 
                    onrowcancelingedit="Gridwindow_RowCancelingEdit" 
                    onrowupdating="Gridwindow_RowUpdating" >
        
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField HeaderText="IndentID" Visible="false">
                      <EditItemTemplate>
                       <asp:Label ID="LblEIndentID" runat="server" Text='<%# Bind("IndentID") %>'></asp:Label>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="LblIndentID" runat="server" Text='<%# Bind("IndentID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                         <asp:TemplateField HeaderText="WBS" Visible="True">
                      <EditItemTemplate>
                       <asp:Label ID="LblEwbs" runat="server" Text='<%# Bind("wbs") %>'></asp:Label>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Lblwbs" runat="server" Text='<%# Bind("wbs") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Product">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtproduct" runat="server" Text='<%# Bind("Product") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Bind("Product") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Quantity">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("Qty") %>' Width="45px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Bind("Qty") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Unit">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtunit" runat="server" Text='<%# Bind("Unit") %>' Width="45px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="PlaceofDespatch">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtFrom" runat="server" Text='<%# Bind("Despatch") %>' Width="100px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label5" runat="server" Text='<%# Bind("Despatch") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="PlaceofDelievery" Visible="false">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTo" runat="server" Text='<%# Bind("Delivery") %>' Width="100px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label6" runat="server" Text='<%# Bind("Delivery") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Wt in Tons">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTotalWeight" runat="server" Text='<%# Bind("Totweight") %>' Width="45px" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label7" runat="server" Text='<%# Bind("Totweight") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Length(M)">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtlength" runat="server" Text='<%# Bind("Length") %>' Width="45px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label8" runat="server" Text='<%# Bind("Length") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Width(M)">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtwidth" runat="server" Text='<%# Bind("Width") %>' Width="45px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label9" runat="server" Text='<%# Bind("Width") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Height(M)">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtheight" runat="server" Text='<%# Bind("Height") %>' Width="45px"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label10" runat="server" Text='<%# Bind("Height") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                       <asp:TemplateField HeaderText="EstmDate">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate" runat="server"  Width="60px" Text='<%#Bind("Estmdate") %>'></asp:TextBox>
                          <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txtdate">
                </ajaxToolkit:CalendarExtender>
                      </EditItemTemplate>
                      <ItemTemplate>
                             <asp:TextBox ID="txtdate" runat="server"  Width="60px" Text='<%#Bind("Estmdate") %>'></asp:TextBox>
                          <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txtdate">
                </ajaxToolkit:CalendarExtender>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                  
                                                       <asp:TemplateField HeaderText="AuditTrail">
                                        <ItemTemplate>
                                    
<asp:HyperLink ID="lnkaduit" runat="server"  Text='AuditTrail'  NavigateUrl=<%# String.Format("javascript:void(window.open('AuditTrial.aspx?logID={0}',null,'right=362px, top=134px, width=800px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("IndentID")) %>></asp:HyperLink>
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
    <br /><br /><br /><br /><br /><br />
</asp:Content>

