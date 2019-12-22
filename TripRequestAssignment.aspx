<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="TripRequestAssignment.aspx.cs" Inherits="TripRequestAssignment" %>
<%--<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagName="Navihome" TagPrefix="Uc4" %>--%>

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
   
        

     
<%-- <Uc4:Navihome ID="navihome1" runat="server" />--%>
 <asp:ScriptManager ID="ScriptManager2" runat="server" />
        <section class="content">
      <div class="row">
        <div class="col-xs-12 col-md-offset-1">
          <div class="box">
                 <div class="box-body">
    <table id="example2" class="table table-bordered table-hover">
        <tr>
            <td>
  <asp:DropDownList ID="DrpProject" runat="server" Width="295px">
    </asp:DropDownList><br />
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
                <asp:Panel ID ="pnl_Trucks" runat ="server" ScrollBars="Auto" Width ="780px" Height ="320px">
                 <asp:GridView ID="grd_TrucksRequired" runat="server" 
             CellPadding="4" ForeColor="#333333" BorderStyle="None" GridLines="Both" 
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
        </ContentTemplate>
        </asp:UpdatePanel>
     <asp:UpdateProgress DynamicLayout="false" ID="UpdateProgress2" runat="server">
          <ProgressTemplate>
              <img src="images/ajax-loader.gif" alt="Tripcalender"/> Assigning ...
          </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
         <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" 
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
                  
                   <asp:TemplateField HeaderText="LogPlanID">
                      <ItemTemplate>
                          <asp:Label ID="lblLogPlanID" runat="server" Text='<%# Bind("LogisticsPlanID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtLogPlanID" runat="server" Text='<%# Bind("LogisticsPlanID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>  
          </ContentTemplate>
              </asp:UpdatePanel>
       </div>
    </div>
    </div>
          </div>
            </section>
</asp:Content>


