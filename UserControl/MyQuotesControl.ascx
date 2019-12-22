<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyQuotesControl.ascx.cs" Inherits="UserControl_MyQuotesControl" %>

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
<asp:Repeater ID="rptItems" runat="server" >
    <HeaderTemplate>
        <table width="658" border="0" cellpadding="0" cellspacing="1" id="grid_view1">
            <tr>
                <th width="61" scope="col">
                    Travel Date
                </th>
                <th width="120" scope="col">
                    Quote ID
                </th>
                <th width="120" scope="col">
                    Trip ID
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
                          <asp:Label ID="lbldate" runat="server" Text="26/Dec/2010"></asp:Label>
                    </td>
                    <td width="120" bgcolor="#c2ddeb">
                        <asp:Label ID="Label1" runat="server" Text="QTE-6734"></asp:Label>
                    </td>
                    
                    <td width="120" bgcolor="#c2ddeb">
                        <asp:Label ID="lbladid" runat="server" Text="ABC-1234"></asp:Label>
                    </td>
                    <td width="120" bgcolor="#c2ddeb">
                        <asp:Label ID="lblSource" runat="server" Text="Bangalore"> </asp:Label>
                    </td>
                    <td width="120" bgcolor="#c2ddeb">
                        <asp:Label ID="Label5" runat="server" Text="Pune"> </asp:Label>
                   
                    </td>
                    <td width="180" bgcolor="#c2ddeb">
                        <asp:Label ID="Label6" runat="server" Text="Rigid Trucks"></asp:Label>/<br />
                        <asp:Label ID="lblBoxCapacity" runat="server" Text="500 Tons"> </asp:Label>
                    </td>
                    <td width="50" bgcolor="#c2ddeb">
                        <asp:Label ID="lblBoxTruckCount" runat="server" Text="5"></asp:Label>
                    </td>
                    <td width="90" bgcolor="#c2ddeb">
                        <asp:Label ID="lbl_trvType" runat="server" Text="Two Way"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="8" bgcolor="#deebf2">
                        <%--Distance:<asp:Label ID="lbldist" runat="server" Text=' <%# Eval("Distance")%>'> </asp:Label>--%>
                       
                        Views:
                        <asp:Label ID="lblViewCount" runat="server" Text="2763"></asp:Label>|
                        No of Quotes:
                        <asp:Label ID="lblQuoteCount" runat="server" Text="50"></asp:Label>|
                        <strong>
                            <asp:Label ID="lblQuoteMinTitle" runat="server" Text="Min"></asp:Label>
                            <asp:Image ID="ImgMinRs" ImageUrl="~/Images/INR.png" Width="9" Height="9" runat="server" />
                            <asp:Label ID="lblQuoteMinPrice" runat="server" Text="30000"></asp:Label>&nbsp;
                            <asp:Label ID="lblQuoteMaxTitle" runat="server" Text="Max"></asp:Label>
                            <asp:Image ID="ImgMaxRs" ImageUrl="~/Images/INR.png" Width="9" Height="9" runat="server" />
                            <asp:Label ID="lblQuoteMaxPrice" runat="server" Text="36000"></asp:Label>
                            <asp:Label ID="lblavgtext" runat="server" Text="Avg"></asp:Label>
                             <asp:Label ID="lblavg" runat="server" Text="33000"></asp:Label>
                        </strong>
                                                 
                                            <span style="font-weight:bold; color:Black;" >Posted on:</span><asp:Label ID="lbl_posteddate" runat="server" ForeColor="black" Font-Bold="true" Text="22/Dec/2010"></asp:Label>
                       <a href="#"> <img src="images/detail_button.png" id="details" alt="details"/></a>
                    
                    </td>
                   <%-- <td bgcolor="#deebf2" style="background-image : ~/images/detail_button.png;">
                        <div class="">
                            <asp:LinkButton ID="LinkButtonViewNew" runat="server"><span></span></asp:LinkButton>
                        </div>
                    </td>--%>
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