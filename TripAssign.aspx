<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="TripAssign.aspx.cs" Inherits="TripAssign" %>


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
 <asp:ScriptManager ID="ScriptManager2" runat="server" />
     
                                    <br />
    
    
      <section class="content">
      <div class="row">
        <div class="col-xs-12 col-md-offset-1">
          <div class="box">
            <!--<div class="box-header">
              <h3 class="box-title">Hover Data Table</h3>
            </div>-->
            <!-- /.box-header -->
            <div class="box-body">
              <table id="example2" class="table table-bordered table-hover">
    <%--<div class="col-md-12 col-md-offset-1">--%>
        
    <%-- <table >--%>
                
        <tr>
            <td>
  <asp:DropDownList ID="DrpProject" runat="server" Width="295px">
    </asp:DropDownList>
                <br />
<asp:Calendar ID="Calendar1" runat="server" EnableTheming="True" BackColor="White" 
        BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" 
        Font-Size="9pt" ForeColor="Black" Height="100px" NextPrevFormat="ShortMonth" 
        Width="400px"
        onselectionchanged="Calendar1_SelectionChanged" BorderWidth="1px"  OnDayRender="Calendar1_DayRender" >
    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
    <TodayDayStyle BackColor="#999999" ForeColor="White" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <DayStyle BackColor="#FFF0F0" />
    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="Black" />
    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333"  BackColor="White"
        Height="8pt" HorizontalAlign="Left" />
    <TitleStyle BackColor="Red" BorderStyle="Solid" Font-Bold="True" 
        Font-Size="9pt" ForeColor="Black" Height="10pt" />
    </asp:Calendar>
    </td>
            <td>
                <asp:Panel ID ="pnl_Trucks" runat ="server" ScrollBars ="Vertical" Width ="780px" Height ="320px">
                 <asp:GridView ID="grd_TrucksRequired" runat="server" 
             CellPadding="4" ForeColor="#333333" 
             EnableModelValidation="True" >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                     <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView> 
                    </asp:Panel>
            </td>
        </tr>
    </table>
     Trips on 
    <asp:TextBox ID="txtDate" runat="server" BorderStyle="Solid" Width="250px" 
        ReadOnly="false" EnableViewState="True"></asp:TextBox>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>   
    <asp:Button ID="ButAssign" runat="server" Text="Assign" onclick="ButAssign_Click" Enabled="False" class="btn btn-primary" />
          <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Size="15pt" 
              ForeColor="Red" Text="Trip Assigned Successfully" Visible="False"></asp:Label>
           <asp:Button ID="btn_assignparcel" runat="server" Text="Assign"  Enabled="False" class="btn btn-primary" OnClick="btn_assignparcel_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
     <asp:UpdateProgress DynamicLayout="false" ID="UpdateProgress2" runat="server">
          <ProgressTemplate>
              <img src="images/ajax-loader.gif" alt="Tripcalender"/> Assigning ...
          </ProgressTemplate>
    </asp:UpdateProgress>

         <div id="option" runat="server" class="row">
            <label class="btn btn-default"><asp:RadioButton ID="rdb_ftl" runat="server"  AutoPostBack="true" GroupName="A" Text="FTL" OnCheckedChanged="rdb_ftl_CheckedChanged" ></asp:RadioButton></label>
                 <label class="btn btn-default"><asp:RadioButton ID="rdb_parcel" runat="server" GroupName="A" AutoPostBack="true" Text="Part/Parcel" OnCheckedChanged="rdb_parcel_CheckedChanged" ></asp:RadioButton></label>
             <%--<label class="btn btn-default"><asp:RadioButton ID="rdb_upload" runat="server"  AutoPostBack="true" GroupName="A" Text="Bulk Upload" ></asp:RadioButton></label>--%>
        </div><br />

        <%--<div id="bulkupload" class="row">
            <div class="col-md-4">
            <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
            </div>
            <div class="col-md-4">
                <div class="col-md-4">
                    <asp:Button ID="btn_show" runat="server" class="btn btn-primary"  Text ="Show" OnClick="btn_show_Click" />
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btn_upload" runat="server" class="btn btn-primary" Text ="Upload" OnClick="btn_upload_Click" />
                </div>
                
            </div>
        </div>--%>

        <asp:TextBox ID="txt_source" runat="server" Placeholder="From Location" style="color: black;" AutoPostback="true" OnTextChanged="txt_source_TextChanged1"  ></asp:TextBox>
        <asp:TextBox ID="txt_destination" runat="server" Placeholder="To Location" style="color: black;" AutoPostback="true" OnTextChanged="txt_destination_TextChanged" ></asp:TextBox>
        <asp:TextBox ID="txt_transporter" runat="server" Placeholder="Transporter" style="color: black;" AutoPostback="true" OnTextChanged="txt_transporter_TextChanged"></asp:TextBox>
        <asp:TextBox ID="txt_trucktype" runat="server" Placeholder="Truck Type" style="color: black;" AutoPostback="true" OnTextChanged="txt_trucktype_TextChanged"></asp:TextBox>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
       <asp:GridView ID="grid_parcel" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333"   Width ="50px"
             EnableModelValidation="True"  Caption="Select the Check box and Enter the No. of Trucks Required and Time for  Trip Assignment"  >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="checkall" runat="server" Text="All" 
                        AutoPostBack="True" Enabled="false" />
                    </HeaderTemplate>
                    <ItemTemplate>
                   <asp:CheckBox ID="ChkSelect" Width="16px" runat="server" Height="18px" OnCheckedChanged="checkall_CheckedChanged"
                             AutoPostBack="True" />
                    </ItemTemplate>
                  </asp:TemplateField>
         <asp:TemplateField HeaderText="Agreement RouteNo" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AgreementRouteID") %>'></asp:Label>
                          <asp:Label ID="lblTransID" runat="server" Text='<%# Bind("TransID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("AgreementRouteID") %>'></asp:TextBox>
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
                  <asp:TemplateField HeaderText="Transporter">
                      <ItemTemplate>
                          <asp:Label ID="lblTransporter" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTransporter" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="Packing Type">
                      <ItemTemplate>
                          <asp:Label ID="lblpckingtype" runat="server" Text='<%# Bind("PackingType") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtpckingtype" runat="server" Text='<%# Bind("PackingType") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
             <asp:TemplateField HeaderText="Delivery Type">
                      <ItemTemplate>
                          <asp:Label ID="lbldeliverytype" runat="server" Text='<%# Bind("DeliveryType") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdeliverytype" runat="server" Text='<%# Bind("DeliveryType") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Capacity">
                      <ItemTemplate>
                          <asp:Label ID="lblcapacity" runat="server" Text='<%# Bind("Capactiy") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtcapacity" runat="server" Text='<%# Bind("Capactiy") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Agreed Price">
                      <ItemTemplate>
                          <asp:Label ID="lblDecidePrice" runat="server" Text='<%# Bind("DecidedPrice") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtDecidePrice" runat="server" Text='<%# Bind("DecidedPrice") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Dimensions">
                      <ItemTemplate>
                          <asp:Label ID="lbl_dimensions" runat="server" Text='<%# Bind("Comments") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txt_dimensions" runat="server" Text='<%# Bind("Comments") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
            
                  
                    <asp:TemplateField HeaderText="Agreement Date" >
                      <ItemTemplate>
                          <asp:Label ID="lbldate" runat="server" Text='<%# Bind("PostedDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate" runat="server" Text='<%# Bind("PostedDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Email" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                 
                  
                  <asp:TemplateField HeaderText="No of Units.">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nooftrucks") %>' onKeyPress="return onlynumber(event)"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txt_truckreq" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="43px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onKeyPress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Time">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Time") %>' ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txt_time" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="False" Height="22px" Width="43px" BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Remarks">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Remarks") %>' ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txt_remarks" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="False" Height="50px" Width="63px" BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                 
                  
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
         <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="65%"
             EnableModelValidation="True"  Caption="Select the Check box and Enter the No. of Trucks Required and Time for  Trip Assignment" >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbSelectAll" runat="server" Text="All"
                        AutoPostBack="True" Enabled="false" />
                    </HeaderTemplate>
                    <ItemTemplate>
                   <asp:CheckBox ID="ChkSelect" Width="16px" runat="server" Height="18px" 
                            oncheckedchanged="ChkSelect_CheckedChanged"  AutoPostBack="True" />
                    </ItemTemplate>
                  </asp:TemplateField>
         <asp:TemplateField HeaderText="Agreement RouteNo" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AgreementRouteID") %>'></asp:Label>
                          <asp:Label ID="lblTransID" runat="server" Text='<%# Bind("TransID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("AgreementRouteID") %>'></asp:TextBox>
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
                  <asp:TemplateField HeaderText="Transporter">
                      <ItemTemplate>
                          <asp:Label ID="lblTransporter" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTransporter" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
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
             <asp:TemplateField HeaderText="Enclosure Type">
                      <ItemTemplate>
                          <asp:Label ID="lblEncltype" runat="server" Text='<%# Bind("Enclosuretype") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtencltype" runat="server" Text='<%# Bind("Enclosuretype") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Capacity">
                      <ItemTemplate>
                          <asp:Label ID="lblcapacity" runat="server" Text='<%# Bind("Capactiy") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtcapacity" runat="server" Text='<%# Bind("Capactiy") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Agreed Price">
                      <ItemTemplate>
                          <asp:Label ID="lblDecidePrice" runat="server" Text='<%# Bind("DecidedPrice") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtDecidePrice" runat="server" Text='<%# Bind("DecidedPrice") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
            
                  
                    <asp:TemplateField HeaderText="Agreement Date" >
                      <ItemTemplate>
                          <asp:Label ID="lbldate" runat="server" Text='<%# Bind("PostedDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate" runat="server" Text='<%# Bind("PostedDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Email" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                 
                  
                  <asp:TemplateField HeaderText="No of Truck Req">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nooftrucks") %>' onKeyPress="return onlynumber(event)"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtTruckreq" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="43px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onKeyPress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Time">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Time") %>' ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txttime" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="False" Height="22px" Width="43px" BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Remarks">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Remarks") %>' ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtremarks" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="False" Height="50px" Width="63px" BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  
                 
                  
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>  

      <asp:GridView ID="GridView1" runat="server"></asp:GridView>

          </ContentTemplate>
              </asp:UpdatePanel>
    </div>
   </div>
            </div>
          </div>
          </section>
</asp:Content>

