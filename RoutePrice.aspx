<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="RoutePrice.aspx.cs" Inherits="RoutePrice"  %>

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
    <br /><br />
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<%--<menu:menu ID="Menu" runat="server" />--%>
     <div style="margin-left:90px"> 
    <table align="center" >
        <tr>
            <td>
Search Quote Received by TravelDate:
<asp:TextBox ID="txtsearch" runat="server" Enabled="True"></asp:TextBox>
    <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
                                                 <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtsearch">                                                                     
    </ajaxtoolkit:calendarextender>
        </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <br />
                CuttOff Time :
            <%--<asp:TextBox ID="txt_Cuttofftime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfq_CuttoffTime" runat="server" ControlToValidate ="txt_Cuttofftime" ValidationGroup ="aarms" ErrorMessage="Enter CuttoffTime"></asp:RequiredFieldValidator>--%>
                <asp:DropDownList ID="ddl_Hours" runat="server">
                    <asp:ListItem>Select Hour</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>:<asp:DropDownList ID="ddl_Minutes" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddl_Ampm" runat="server">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList>
            </td>
             </tr>
        <tr>
            <td style="text-align: center">
                  <br />
      <asp:Button ID="btnsearch" runat="server" Text="Search" onclick="btnsearch_Click"   class="btn btn-primary" />
                   </td>
           </tr>
        <tr>
            <td style="text-align: center">
                  <br />
 <asp:Button ID="Button1" runat="server" Text="Download as Excel" onclick="Button1_Click"     class="btn btn-primary" />
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_DownloadtoPDF" runat="server" Text="Download as PDF" OnClick ="btn_DownloadtoPDF_Click"    class="btn btn-primary" />
&nbsp;&nbsp;
    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            
          </td>
        </tr>
    </table>
              </div>
    <br />
     <div style="margin-left:220px"> 


<asp:GridView ID="GridRouteprice" runat="server" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" 
         Width="70%" AutoGenerateColumns="False">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
   
    <Columns>
        <asp:TemplateField HeaderText = "SN." ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
                  </asp:TemplateField>
        <asp:BoundField DataField="Planid" HeaderText="LogisticsPlanID" />
        <asp:BoundField DataField="Planno" HeaderText="LogisticsPlanNo" />
        <asp:BoundField DataField="From" HeaderText="From Location" />
        <asp:BoundField DataField="To" HeaderText="To Location" />
         <asp:BoundField DataField="TravelDate" HeaderText="TravelDate" />
        <asp:BoundField DataField="Trucktype" HeaderText="Truck Type" />
        <asp:BoundField DataField="Encl.type" HeaderText="Encl.Type" />
        <asp:BoundField DataField="Capacity" HeaderText="Capacity" />
         <asp:BoundField DataField="EarlierQuote" HeaderText="Earlier Quote" />
        <asp:BoundField DataField="Routeprice" HeaderText="Route Price" />
        <asp:TemplateField HeaderText="TransID">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Transid") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblTransID" runat="server" Text='<%# Bind("Transid") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField DataField="QuoteDate" HeaderText="Quoted Date" />
    <%--    <asp:HyperLinkField DataNavigateUrlFields="bidlink" DataTextField="Bid"  Visible="false" 
            HeaderText="BID" />--%>
             <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
    </Columns>
    
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>

          </div> 
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br />
    <div class="col-md-12" style="display:none;">
         <div class="box box-success">
            <div class="box-header">
              <h3 class="box-title">Your Data </h3>             
            </div>
            <!-- /.box-header -->
            <div class="box-body table-responsive no-padding">
             <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
              <asp:GridView ID="gv_exceldatadisplay" class="table table-hover" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="4">
               <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "SN." ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
                  </asp:TemplateField>
                <asp:TemplateField HeaderText="LogisticsPlanID">
                <ItemTemplate>
                    <asp:Label ID="lbl_Planid" runat="server" Text='<%# Eval("Planid") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LogisticsPlanNo">
                <ItemTemplate>
                    <asp:Label ID="lbl_Planno" runat="server" Text='<%# Eval("Planno") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                              
                <asp:TemplateField HeaderText="From Location">
                <ItemTemplate>
                    <asp:Label ID="lbl_From" runat="server" Text='<%# Eval("From") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="To Location">
                <ItemTemplate>
                    <asp:Label ID="lbl_To" runat="server" Width="150" Text='<%# Eval("To") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TravelDate">
                <ItemTemplate>
                    <asp:Label ID="lbl_TravelDate" runat="server" Text='<%# Eval("TravelDate") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Truck Type">
                <ItemTemplate>
                    <asp:Label ID="lbl_Trucktype" runat="server" Text='<%# Eval("Trucktype") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Encl.type" HeaderText="Encl.Type" />
                <asp:TemplateField HeaderText="Capacity">
                <ItemTemplate>
                    <asp:Label ID="lbl_Capacity" runat="server" Text='<%# Eval("Capacity") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EarlierQuote">
                <ItemTemplate>
                    <asp:Label ID="lbl_EarlierQuote" runat="server" Text='<%# Eval("EarlierQuote") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Routeprice">
                <ItemTemplate>
                    <asp:Label ID="lbl_Routeprice" runat="server" Text='<%# Eval("Routeprice") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transid">
                <ItemTemplate>
                    <asp:Label ID="lbl_Transid" runat="server" Text='<%# Eval("Transid") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QuoteDate">
                <ItemTemplate>
                    <asp:Label ID="lbl_QuoteDate" runat="server" Text='<%# Eval("QuoteDate") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <asp:Label ID="lbl_Remarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>                                    
                </ItemTemplate>
                </asp:TemplateField>
                                      
            </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
              </asp:GridView>
             </asp:Panel>              
            </div>
            <!-- /.box-body -->
              <div class="box-footer">
                <button type="submit" class="btn btn-default">Cancel</button>
                <asp:Button ID="btn_btnExport"  class="btn btn-info pull-right" OnClick="ExportToPDF"  runat="server" Text="Export To PDF"  />                
              </div>
          </div>
        </div>
   

</asp:Content>


