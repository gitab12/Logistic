<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TripAcceptance1.aspx.cs" Inherits="TripAcceptance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <script src="http://code.jquery.com/jquery-latest.js"></script>
<script type='text/javascript'>
    $(function () {
        // To disable f5
        $(document).bind("keydown", disableF5);
    });

    //Function to handle disabling F5
    function disableF5(e) {
        if ((e.which || e.keyCode) == 116)
            //alert("shyam");
            //window.open("http://viralpatel.net/blogs/", "mywindow", "status=1,toolbar=0");
            e.preventDefault();
    };
</script>
    <link href="css/animate.css" rel="stylesheet" />
<link href="css/bootstrap.min.css" rel="stylesheet" />
<link href="css/font-awesome.min.css" rel="stylesheet" />
<link href="css/jquery.sidr.dark.css" rel="stylesheet" />
<link href="css/main.css" rel="stylesheet" />
<link href="css/prettyPhoto.css" rel="stylesheet" />
<link href="css/reset.css" rel="stylesheet" />
<link href="css/responsive.css" rel="stylesheet" />
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br /><br /><br /><br /><br />
<%--<UMB:Menu ID="Menu" runat="server" />--%>
<br />
    <div style="margin-left:400px">
    <strong style="color:red"> Select the Check box and Enter the Vechile No(*),Driver,MobileNo</strong>
       
    <br />
          <br />
         <asp:Label ID ="lbl_Transporter" runat ="server" Font-Bold ="true" Font-Size ="16px" ForeColor ="Red"  ></asp:Label>&nbsp;
         <asp:Button ID="ButAcceptance" runat="server" Text="Confirm Acceptance"  onclick="ButAcceptance_Click"  Class="btn btn-primary"/>
        </div>
    <br />
    <div  Style="margin-left:50px" >
<asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" OnRowDataBound="Gridwindow_RowDataBound"> 
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select"
                        AutoPostBack="True" Enabled="false" />
                    </HeaderTemplate>
                    <ItemTemplate>
                   <asp:CheckBox ID="ChkSelect" Width="16px" runat="server" Height="18px" 
                             AutoPostBack="false" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Agreement RouteNo" Visible="false" >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("tripassignId") %>'></asp:Label>
                         
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("tripassignId") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="CNote No">
                      <ItemTemplate>
                          <asp:Label ID="lbl_CNoteNo" runat="server" Text='<%# Bind("CollectionNoteNumber") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Project No">
                      <ItemTemplate>
                          <asp:Label ID="lbl_ProjectNo" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="WBSNo">
                      <ItemTemplate>
                          <asp:Label ID="lbl_WBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
                      </ItemTemplate>
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
                          <asp:Label ID="lbltoloc" runat="server" Text='<%# Bind("tolocation") %>'></asp:Label>
                          <asp:Label ID="lbl_IndentID" runat="server" Text='<%# Bind("IndentID") %>' Visible ="false" ></asp:Label>
<asp:HyperLink ID="lnkIndent" runat="server" NavigateUrl=<%# String.Format("javascript:void(window.open('IndentDetails.aspx?IndentID={0}',null,'right=10px, top=134px, width=1050px, height=430px, status=no,resizable= No, scrollbars=No, toolbar=no, location=no, menubar=no'))",Eval("IndentID")) %>>IndentDetails</asp:HyperLink>

                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txttoloc" runat="server" Text='<%# Bind("tolocation") %>'></asp:TextBox>
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
                          <asp:Label ID="lblEncltype" runat="server" Text='<%# Bind("encltype") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtencltype" runat="server" Text='<%# Bind("encltype") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Capacity">
                      <ItemTemplate>
                          <asp:Label ID="lblcapacity" runat="server" Text='<%# Bind("capacity") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtcapacity" runat="server" Text='<%# Bind("capacity") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Decide Price" Visible="true">
                      <ItemTemplate>
                          <asp:Label ID="lblDecidePrice" runat="server" Text='<%# Bind("decideprice") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtDecidePrice" runat="server" Text='<%# Bind("decideprice") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
             <asp:TemplateField HeaderText="No of Trucks Req.">
                      <ItemTemplate>
                          <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("NooftrucksReq") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("NooftrucksReq") %>'></asp:TextBox>
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
                  
                  
                  <asp:TemplateField HeaderText="Travel Time">
                      <ItemTemplate>
                          <asp:Label ID="lbltime" runat="server" Text='<%# Bind("traveltime") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txttime" runat="server" Text='<%# Bind("traveltime") %>'></asp:TextBox>
                      </EditItemTemplate>
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
                  
                  <asp:TemplateField HeaderText="Vehicle No">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtvehicleno" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true" Height="22px" Width="63px" BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                      <asp:TemplateField HeaderText="Driver">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtDriver" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true" Height="22px" Width="63px" BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                       <asp:TemplateField HeaderText="Mobile No">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:TextBox ID="txtmobileno" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true" Height="22px" Width="73px" BorderColor="Black" MaxLength="10" onkeypress="return onlynumber(event)"
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>


                  <asp:TemplateField HeaderText="Vehicle Placement DateTime">
                      <ItemTemplate>
                          <asp:TextBox ID="txtTripTime" runat="server"  Width="156px"  ></asp:TextBox>
                          (* format should be like 28/11/2014 05:48 PM)
                      </ItemTemplate>
                  </asp:TemplateField>


                      <asp:TemplateField HeaderText="Status">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="TransporterEmail" Visible="false">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lblTEmail" runat="server" Text='<%# Bind("TransporterEmail") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                     </asp:TemplateField>
                  <asp:TemplateField HeaderText="ClientEmail" Visible="false">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lblCEmail" runat="server" Text='<%# Bind("CorporateEmail") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="ClientMobile" Visible="false">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>


              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>  
   </div>
    </div>
    </form>
</body>
</html>
