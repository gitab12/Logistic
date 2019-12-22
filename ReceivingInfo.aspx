<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="ReceivingInfo.aspx.cs" Inherits="ReceivingInfo" %>
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
    <br /><br /><br />
    <div style="margin-left:150px">
<script src="JSP/jquery.1.4.2.js" type="text/javascript"></script>
  <link rel="Stylesheet" href="css/TimeCalendar.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <link href="uploadify.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.uploadify.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {

            $('#<%=Gridwindow.ClientID %>').find('input:file[ID$="FileUpload1"]').uploadify({

                'swf': 'uploadify.swf',
                'uploader': 'Handler.ashx',
                'cancelImg': 'cancel.png',
                'buttonText': 'Select Files',
                'fileDesc': 'Image Files',
                'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
                'multi': true,
                'auto': true
            });

        })
    </script>
 
    
 <br />
 <br />
<%--<Uc4:Navihome ID="navihome1" runat="server" />--%>
<ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
<table align="center">
<tr>
<td>
<b>Search by LRNumber:</b>
</td>
<td>
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" />
</td>
<td>
    <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
</tr>
</table><br /><br />
        <div class="row">
        <div class="col-md-3">
                <div id="demo" runat="server" class="form-control">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btn_Upload" class="form-control btn btn-primary"  runat="server" Text="Upload" OnClick="btn_Upload_Click" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btn_show" class="form-control btn btn-primary"  runat="server" Text="Show" OnClick="btn_show_Click"  />
            </div><br />
            <asp:Label ID="lbl_msg" runat="server" ForeColor="#FF3300"></asp:Label><br />
            <asp:Literal ID="ltEmbed" runat="server" />

        </div>
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
                          <%--<asp:TextBox ID="txtReceivedDate" runat="server" Width="66px" Enabled="true"></asp:TextBox>
                           <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px"/>
                   
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtReceivedDate">                </ajaxToolkit:CalendarExtender>--%>
                    <ItemTemplate>
                         <asp:TextBox id ="txtReceivedDate" type="text" class="TimeCalendar"  runat="server"/>
 <script type="text/javascript">
     $(document).ready(function() {
         var dt1 = $("#dt1");

         //These are all the options

         dt1.attr("minimumDate", "1 Jan 2010 10:04 am");
         dt1.attr("maximumDate", "1 Apr 2010 10:04 am");
         dt1.attr("showTime", true);
         dt1.attr("imagePath", "images/"); // The images have been copied to this folder to show how this option works
     });
    </script>
                      </ItemTemplate>
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
                  
                  <asp:TemplateField HeaderText="Remarks">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtRemarks" runat="server" Width="101px" TextMode="MultiLine" MaxLength="150"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                 
                 
                  <asp:TemplateField HeaderText="Vehicle Image">
                      <ItemTemplate>
                       <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="False"/>                       
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Truckimage") %>'></asp:TextBox>
                      </EditItemTemplate>
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
           <script type="text/javascript" src="JSP/TimeCalendar.js"></script>
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
        </div>
</asp:Content>

