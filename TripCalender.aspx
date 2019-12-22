<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TripCalender.aspx.cs" Inherits="TripCalender"  EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br /><br /><br />
    <div style="margin-left:250px">
<script type="text/javascript">
 
     function ShowInfo(id) {  
         var div = document.getElementById(id);    
         div.style.display = "block";
     }
     function HideInfo(id) {  
         var div = document.getElementById(id);    
         div.style.display = "none";
     }
     </script>
    <asp:ScriptManager ID="ScriptManager2" runat="server" />
<asp:Calendar ID="Calendar1" runat="server" EnableTheming="True" BackColor="White" 
        BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" 
        Font-Size="9pt" ForeColor="Black" Height="100px" NextPrevFormat="ShortMonth" 
        Width="400px" ondayrender="Calendar1_DayRender" 
        onselectionchanged="Calendar1_SelectionChanged" BorderWidth="1px" >
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
    <br />
     Trips on 
    <asp:TextBox ID="txtDate" runat="server" BorderStyle="Solid" Width="250px" 
        ReadOnly="false" EnableViewState="True"></asp:TextBox>
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>   
           <br>
    <asp:Button ID="ButAssign" runat="server" Text="Submit" 
        onclick="ButAssign_Click"  Class="btn btn-primary"/>
          <br>
        </ContentTemplate>
        </asp:UpdatePanel>
     <asp:UpdateProgress DynamicLayout="false" ID="UpdateProgress2" runat="server">
          <ProgressTemplate>
              <img src="images/ajax-loader.gif" alt="Tripcalender"/> Assigning ...
          </ProgressTemplate>
    </asp:UpdateProgress>
        
            </div>
    <asp:Panel ID="panel_1" runat="server"   Height ="270px" ScrollBars="Auto" Width="93%" GroupingText="" Style="margin-left:250px">
         <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" 
        OnRowDataBound="Gridwindow_RowDataBound" >
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select"
                        AutoPostBack="True" oncheckedchanged="cbSelectAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                   <asp:CheckBox ID="ChkSelect" Width="16px" runat="server" Height="18px" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Logistics No">
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("LogisticsPlanID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("LogisticsPlanID") %>'></asp:TextBox>
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
                  <asp:TemplateField HeaderText="Truck Type">
                      <ItemTemplate>
                          <asp:Label ID="lblTrucktype" runat="server" Text='<%# Bind("Trucktype") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txttrucktype" runat="server" Text='<%# Bind("Trucktype") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Quoted Price">
                      <ItemTemplate>
                          <asp:Label ID="lblQuotedprice" runat="server" Text='<%# Bind("Quotedprice") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtQuotedPRice" runat="server" Text='<%# Bind("Quotedprice") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Decide Price">
                      <ItemTemplate>
                          <asp:Label ID="lblDecidePrice" runat="server" Text='<%# Bind("Decideprice") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtDecidePrice" runat="server" Text='<%# Bind("Decideprice") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Savings">
                      <ItemTemplate>
                          <asp:Label ID="lblSavings" runat="server" Text='<%# Bind("Savings") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtSavings" runat="server" Text='<%# Bind("Savings") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Transporter">
                      <ItemTemplate>
                          <asp:Label ID="lblTransporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTransporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                   <asp:TemplateField HeaderText="Email">
                      <ItemTemplate>
                          <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="TransporterID" Visible="false" >
                      <ItemTemplate>
                          <asp:Label ID="lblTransporterID" runat="server" Text='<%# Bind("TransporterID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTransporterID" runat="server" Text='<%# Bind("TransporterID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Status">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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

