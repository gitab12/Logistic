<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="Receiving.aspx.cs" Inherits="Receiving" %>
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
    <br />
 <script src="JSP/jquery.1.4.2.js" type="text/javascript"></script>
  <link rel="Stylesheet" href="css/TimeCalendar.css" />

 <br />

<ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
<br />
    <div style="margin-left:350px">
    ProjectNo : <asp:DropDownList ID="ddl_ProjectNo" runat="server" Height="20px" AutoPostBack ="true"  OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged" Width="104px"></asp:DropDownList>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    WBSNo : <asp:DropDownList ID="ddl_Wbsno" runat="server" Height="20px" Width="91px" AppendDataBoundItems="True"  >
        <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList>
    &nbsp;&nbsp;
    <asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search" ToolTip="You can Search 1. by Selecting project no & wbs no (both Combination)  2.Enter Lr no only (no Project no & Wbs no)" Class="btn btn-primary"/>
    <br />
    <br />
Enter LR No For Search :&nbsp;&nbsp;
    <asp:TextBox ID="txt_Lrno" runat="server" Width="72px"></asp:TextBox>
</div>
    <br />
    <br />
 <asp:Panel ID="AarmsVehicleReport" runat="server"  ScrollBars="Auto" Width="50%" GroupingText="" Style="margin-left:150px">
  <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None"  
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                 
                  <asp:TemplateField HeaderText="Confirm No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                         <asp:Label ID="lblplid" runat="server" Text='<%# Bind("plid") %>' ForeColor="White"></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Project No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                         
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtProject" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="WBS No" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblWBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
                         
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtWBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:TextBox>
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
                 
                  <asp:TemplateField HeaderText="Truck Type" Visible="true" >
                      <ItemTemplate>
                          <asp:Label ID="lblTruck" runat="server" Text='<%# Bind("TruckType") %>'></asp:Label>
                         
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTruck" runat="server" Text='<%# Bind("TruckType") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                    <asp:TemplateField HeaderText="Travel Date">
                      <ItemTemplate>
                          <asp:Label ID="lbldate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
           
                   <asp:TemplateField HeaderText="LR No.">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("LRNumber") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                         <asp:Label ID="lblLRno" runat="server" Text='<%# Bind("LRNumber") %>'></asp:Label>
                      </ItemTemplate>
                    
                  </asp:TemplateField>
                  
                  
                  
                      <asp:TemplateField HeaderText="Exp.DeliveryDate">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                           <asp:Label ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:Label>
                            
                                 
                      </ItemTemplate>
                  </asp:TemplateField>
                 
                  
                          <asp:TemplateField HeaderText="ClientID" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                       <asp:TemplateField HeaderText="ClientAdrID" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblclientadrID" runat="server" Text='<%# Bind("ClientAddressLocationID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtclientadrID" runat="server" Text='<%# Bind("ClientAddressLocationID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
              
            <%--      <asp:TemplateField HeaderText="ClientEmail" >
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lblCEmail" runat="server" Text='<%# Bind("CorporateEmail") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                  <asp:TemplateField HeaderText="VehicleNo" Visible="false">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblVehicleno" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  
                    <%--<asp:TemplateField HeaderText="Vehicle Image">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                      
                          <asp:ImageButton ID="Image1" runat="server" Height="43px" Width="119px" 
                              ImageUrl='<%# Eval("AcceptanceID", "ImageHandler.ashx?ImageID={0}")%>' 
                             
                              onclick="Image1_Click"/>
                         
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                  <asp:TemplateField HeaderText="VehicleNo" >
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                            <asp:TextBox ID="txtvehicleNo" runat="server" width="70px"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
             
                  <asp:TemplateField HeaderText="Received Date/Time">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ReceivedDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtReceivedDate" runat="server"  class="TimeCalendar"  Enabled="true"></asp:TextBox>
                          <script type="text/javascript">
                              $(document).ready(function() {
                              var dt1 = $("#txtReceivedDate");

                                  //These are all the options

                                  dt1.attr("minimumDate", "1 Jan 2010 10:04 am");
                                  dt1.attr("maximumDate", "1 Apr 2010 10:04 am");
                                  dt1.attr("showTime", true);
                                  dt1.attr("imagePath", "images/"); // The images have been copied to this folder to show how this option works
                              });
    </script>
                           <%--<asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px"/>--%>
                   
                            <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtReceivedDate">                </ajaxToolkit:CalendarExtender>--%>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  
                   <asp:TemplateField HeaderText="UnLoading Date/Time">
                      <EditItemTemplate>
                          
                      </EditItemTemplate>
                      <ItemTemplate>
                         <asp:TextBox id ="dt1" type="text" class="TimeCalendar"  runat="server"/>
 <script type="text/javascript">
     $(document).ready(function() {
     var dt1 = $("#dt1");

         //These are all the options
        
        dt1.attr("minimumDate", "1 Jan 2010 10:04 am");
        dt1.attr("maximumDate", "1 Apr 2010 10:04 am");
        dt1.attr("showTime", true );
        dt1.attr("imagePath", "images/"); // The images have been copied to this folder to show how this option works
     });
    </script>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Speedometer" >
                      <EditItemTemplate>
                          <asp:TextBox ID="txt_Speedometer" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                            <asp:TextBox ID="txt_SpeedoMeter" runat="server" width="60px" Text ="0" onkeypress="return onlynumber(event)" ></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Remarks">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtRemarks" runat="server" Width="101px" TextMode="MultiLine" MaxLength="150"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                 
                   <asp:TemplateField HeaderText="Release Datetime" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblReleaseDateTime" runat="server" Text='<%# Bind("ReleaseDateTime") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                 <asp:TemplateField HeaderText="Submit">
                      <EditItemTemplate>
                         
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Button ID="ButSubmit" runat="server" Text="Submit" onclick="ButSubmit_Click" />
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
           <script type="text/javascript" src="JSP/TimeCalendar.js"></script>
    <br /><br /><br /><br /><br /><br />
</asp:Content>

