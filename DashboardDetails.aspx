<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashboardDetails.aspx.cs" Inherits="DashboardDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</head>
<body>
    <form id="form1" runat="server">
    
     <ContentTemplate>
          <asp:ScriptManager ID ="scriptmanager1" runat ="server"  EnablePartialRendering="true" ></asp:ScriptManager>
      <asp:GridView ID="GridView" runat="server" BorderColor="#E0E0E0" OnRowDataBound ="GridView_RowDataBound" 
    CellPadding="4" ForeColor="#333333" 
         Width="100%" AutoGenerateColumns="False">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
   
    <Columns>
        
        <asp:TemplateField HeaderText="PlanID" Visible="false" >
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
                          <asp:Label ID="lblcapacity" runat="server" Text='<%# Bind("Capacity") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtcapacity" runat="server" Text='<%# Bind("Capacity") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>

        

                  <asp:TemplateField HeaderText="Quoted Price">
                      <ItemTemplate>
                          <asp:Label ID="lblDecidePrice" runat="server" Text='<%# Bind("DecidedPrice") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtDecidePrice" runat="server" Text='<%# Bind("DecidedPrice") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>

                <asp:TemplateField HeaderText="Decide Price">
                      <EditItemTemplate>
                          <asp:TextBox ID="txt_cost" runat="server" Text='<%# Bind("QuotedPrice") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                    
                          <asp:TextBox ID="txt_negcost" Width ="40px" runat="server" Text='<%# Bind("QuotedPrice") %>'></asp:TextBox>
                          <%--<asp:Label ID="txtTruckreq" runat="server" Text='<%# Bind("nooftrucks") %>'></asp:Label>--%>
                          
                      </ItemTemplate>
                  </asp:TemplateField>
             

              <asp:TemplateField HeaderText="Travel Date">
                      <ItemTemplate>
                          <asp:Label ID="lbldate1" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate1" runat="server" Text='<%# Bind("TravelDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                    <asp:TemplateField HeaderText="Posted Date">
                      <ItemTemplate>
                          <asp:Label ID="lbldate" runat="server" Text='<%# Bind("PostedDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate" runat="server" Text='<%# Bind("PostedDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Email" Visible="false" >
                      <ItemTemplate>
                          <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                 
                  
                  <asp:TemplateField HeaderText="No of Truck Req">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nooftrucks") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                    
                          <asp:TextBox ID="txt_TrucksReq" Width ="40px" runat="server" Text='<%# Bind("nooftrucks") %>'></asp:TextBox>
                          <%--<asp:Label ID="txtTruckreq" runat="server" Text='<%# Bind("nooftrucks") %>'></asp:Label>--%>
                          
                      </ItemTemplate>
                  </asp:TemplateField>
                  

         <asp:TemplateField HeaderText="Truck Placement datetime" >
     <ItemStyle Width ="20%" />
                      <ItemTemplate>
                          <asp:TextBox ID="txt_TrucksReqDatetime" Width ="80px" runat="server" ></asp:TextBox>
                           <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format ="dd/MM/yyyy"
                    PopupButtonID="imgdate1" TargetControlID="txt_TrucksReqDatetime">  </ajaxtoolkit:calendarextender>
                         <asp:DropDownList ID="ddl_Hours" runat="server">
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
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                </asp:DropDownList> 
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="TransporterName">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TransporterName") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                                           
                          <asp:Label ID="txtname" runat="server" Text='<%# Bind("TransporterName") %>'></asp:Label>
                          
                      </ItemTemplate>
                  </asp:TemplateField>
        
         <asp:TemplateField HeaderText="SSG PlanID">
                      <EditItemTemplate>
                          <asp:TextBox ID="Textssgs" runat="server" Text='<%# Bind("AgreementRouteID") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                    
                          <asp:TextBox ID="txt_sgs" Width ="40px" runat="server" Text='<%# Bind("AgreementRouteID") %>'></asp:TextBox>
                          <%--<asp:Label ID="txtTruckreq" runat="server" Text='<%# Bind("nooftrucks") %>'></asp:Label>--%>
                           <asp:RegularExpressionValidator ID="regUnitsInStock" runat="server" ControlToValidate="txt_sgs" ErrorMessage="Only numbers allowed" ValidationExpression="(^([0-9]*\d*\d{1}?\d*)$)" Display="Dynamic"></asp:RegularExpressionValidator>
                      </ItemTemplate>
                  </asp:TemplateField>
		<asp:TemplateField HeaderText="Remarks">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtrem" Width ="40px" runat="server" TextMode="MultiLine" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                                           
                 <asp:TextBox ID="txt_remarks" Width ="40px"  runat="server" TextMode="MultiLine" ></asp:TextBox>
                           <asp:Label ID="txt_remarks1" runat="server" ></asp:Label>
                          
                      </ItemTemplate>
                  </asp:TemplateField>

      
        <asp:TemplateField HeaderText="Confirm">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ReplyByID") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblTransID" runat="server" Text='<%# Bind("ReplyByID") %>'></asp:Label>
                <asp:Label ID="lblTripAssignID" runat="server" Text='<%# Bind("TripAssignID") %>' Visible="false"></asp:Label>
                <br />
                <asp:Button ID="ButAssign" runat="server" onclick="ButAssign_Click" 
                    Text="Confirm" />
					<asp:Button ID="btn_cancel" runat="server" onclick="btn_cancel_Click" CssClass="btn btn-default" Text="Cancel"  />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataNavigateUrlFields="bidlink" DataTextField="Bid"  Visible="false" 
            HeaderText="BID" />
    </Columns>
    
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
     </ContentTemplate>
    </form>
</body>
</html>
