<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TripPlanControl.ascx.cs" Inherits="UserControl_TripPlanControl" %>
<%--<ContentTemplate>--%>
<!--Page Top Pagination Section Starts -->
<div class="pagination">
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
        <asp:Repeater ID="ToprptPages" runat="server" >
            <HeaderTemplate>
                <asp:Label ID="lblShow" runat="server" Text="Show"></asp:Label>
                <asp:DropDownList ID="drpShow" AutoPostBack="true" 
                    runat="server">
                </asp:DropDownList>
                <asp:Label ID="lblShow2" runat="server" Text=" Records per Page "></asp:Label>
                <asp:Label ID="lblLink" runat="server" Text=" |Page "></asp:Label>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="TopbtnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                    runat="server" ToolTip="Page No"><%# Container.DataItem %>
                </asp:LinkButton>
            </ItemTemplate>
            <FooterTemplate>
                </td> </tr> </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
</div>
<!--Page Top Pagination Section Ends -->
<!--Content Section Starts -->
<%--<div class="tab_content">--%>
<div class="tab_box">
</div>
<asp:Repeater ID="rptItems" runat="server" 
    onitemcommand="rptItems_ItemCommand"  >
 
    <HeaderTemplate>
        <table width="658" border="0" cellpadding="0" cellspacing="1" id="grid_view1">
            <tr>
                <th width="61" scope="col">
                    Travel Date
                </th>
                <th width="120" scope="col">
             AD ID
                </th>
                <th width="120" scope="col">
                    Source
                </th>
                <th width="120" scope="col">
                    Destination
                </th>
                <th width="180" scope="col">
                    Type of truck/<br />
                    Capacity(Kg)
                </th>
                <th width="50" scope="col">
                    Number of Trucks
                </th>
                <th width="90" scope="col">
                   Travel Type
                </th>
                <th width="90" scope="col" visible="false">
                  PlanID
                </th>
            </tr>
        </table>
    </HeaderTemplate>
  <ItemTemplate>
        <!--Tab Box Section Starts -->
        <div class="tab_box">
            <table width="658" border="0" cellpadding="0" cellspacing="1" id="grid_view">
                <tr>
                    <td width="61" rowspan="1" bgcolor="#c2ddeb">
                     <%--   <div class="date_hd" style="width: 61px; height: 66px; background: url(Images/hot_deals_date_bg.gif) no-repeat;
                            text-align: center;">
                            <h3>
                                <asp:Label ID="Label3" runat="server" Text="26 " ForeColor ="Black">
                                </asp:Label></h3>
                            <h4>
                                <asp:Label ID="Label1" runat="server" Text="Dec" ForeColor ="white">
                                </asp:Label>
                                <asp:Label ID="Label2" runat="server" Text="2010" ForeColor ="white">
                                </asp:Label></h4>
                        </div>--%>
                          <asp:Label ID="lbldate" runat="server" Text=' <%# Eval("TravelDate") %> ' Width="80px"></asp:Label>
                    </td>
                    <td width="120" bgcolor="#c2ddeb">
                        <asp:Label ID="lblplanno" runat="server" Text=' <%# Eval("Planno") %> '></asp:Label>
                    </td>
                    <td width="120" bgcolor="#c2ddeb">
                        <asp:Label ID="lblSource" runat="server" Text=' <%# Eval("Source") %> '> </asp:Label>
                    </td>
                    <td width="120" bgcolor="#c2ddeb">
                        <asp:Label ID="lbldesination" runat="server" Text=' <%# Eval("Desination") %> '> </asp:Label>
                   
                    </td>
                    <td width="180" bgcolor="#c2ddeb">
                        <asp:Label ID="lbltrucktype" runat="server" Text=' <%# Eval("TruckType") %> '></asp:Label>/<br />
                      
                    </td>
                    <td width="50" bgcolor="#c2ddeb">
                        <asp:Label ID="lblBoxTruckCount" runat="server" Text=' <%# Eval("Truckcount") %> '></asp:Label>
                    </td>
                    <td width="90" bgcolor="#c2ddeb">
                        <asp:Label ID="lbl_trvType" runat="server" Text=' <%# Eval("Traveltype") %> '></asp:Label>
                    </td>
                    
                    <td width="90" bgcolor="#c2ddeb" visible="false">
                        <asp:Label ID="lbl_logisticsPlanid" runat="server" Text=' <%# Eval("LogisticsPlanID") %> '></asp:Label>
                    </td>
                </tr>
                <tr>
                 <td colspan="7" bgcolor="#deebf2">
                        <%--Distance:<asp:Label ID="lbldist" runat="server" Text=' <%# Eval("Distance")%>'> </asp:Label>--%>
                      
                       
                      <%--  No of Quotes:
                        <asp:Label ID="lblQuoteCount" runat="server" Text="50"></asp:Label>|
                        <strong>
                            <asp:Label ID="lblQuoteMinTitle" runat="server" Text="Min"></asp:Label>
                            <asp:Image ID="ImgMinRs" ImageUrl="~/Images/INR.png" Width="9" Height="9" runat="server" />
                            <asp:Label ID="lblQuoteMinPrice" runat="server" Text="300000"></asp:Label>&nbsp;
                            <asp:Label ID="lblQuoteMaxTitle" runat="server" Text="Max"></asp:Label>
                            <asp:Image ID="ImgMaxRs" ImageUrl="~/Images/INR.png" Width="9" Height="9" runat="server" />
                            <asp:Label ID="lblQuoteMaxPrice" runat="server" Text="360000"></asp:Label>
                            <asp:Label ID="lblavgtext" runat="server" Text="Avg"></asp:Label>
                             <asp:Label ID="lblavg" runat="server" Text="330000"></asp:Label>
                             --%>
                        </strong>
                                            <span style="font-weight:bold; color:Black;" >Posted on:</span><asp:Label ID="lbl_posteddate" runat="server" ForeColor="black" Font-Bold="true" Text=' <%# Eval("Postedon") %> '></asp:Label><a href='MyTripplan_Details.aspx?LPid=<%# Eval("LogisticsPlanID") %>'><img src="images/detail_button.png" id="details" alt="details"/></a>
                    </td>
                    <td bgcolor="#deebf2" style="background-image :: ~/images/detail_button.png;">
                        <div class="">
                            <asp:LinkButton ID="LinkButtonViewNew" runat="server"><span></span></asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
         
            <!--Box Content Section Starts -->
          
            </p>
         
            <!--Box Content Section Ends -->
            <!--Tab Button Section Starts -->
             <!--<asp:HiddenField ID="index_HF" Value="<%#Container.ItemIndex %>" runat="server" />-->
            <!--Tab Button Section Ends -->
            <!--Tab Box Section Ends -->
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="clearall">
</div>
<!--Page Bottom Pagination Section Starts -->
<div class="pagination">
    <asp:Repeater ID="BottomrptPages" runat="server">
        <HeaderTemplate>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:LinkButton ID="BottombtnPage" CommandName="Page" CommandArgument="<%#
                                 Container.DataItem %>" runat="server"><%# Container.DataItem %> </asp:LinkButton>
        </ItemTemplate>
        <FooterTemplate>
            </td> </tr> </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<!--Page Bottom Pagination Section Ends -->
<%--  </div>--%>
<!--Content Section Ends -->
<!--Wrap Section Starts -->
<div class="tab_wrap">
</div>
<br />
<!--Wrap Section Ends -->
<%--</ContentTemplate> --%>