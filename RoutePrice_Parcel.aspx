<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="RoutePrice_Parcel.aspx.cs" Inherits="RoutePrice_Parcel" %>
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
      <asp:Button ID="btnsearch" runat="server" Text="Search"  class="btn btn-primary" OnClick="btnsearch_Click" />
                   </td>
           </tr>
        <tr>
            <td style="text-align: center">
                  <br />
 <asp:Button ID="Button1" runat="server" Text="Download as Excel"  class="btn btn-primary" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_DownloadtoPDF" runat="server" Text="Download as PDF"    class="btn btn-primary" OnClick="btn_DownloadtoPDF_Click" />
&nbsp;&nbsp;
    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            
          </td>
        </tr>
    </table>
              </div>

    <div id="div2" runat="server" class="row" style="padding-top: 66px; margin-left: 100px;">
           <div  class="panel panel-info" >
                <div  class="panel-body">
                <div  class="col-lg-12 ">  
                                <div class="table-responsive" style="overflow-x:scroll;" >  
                                    <asp:GridView ID="GridRouteprice" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="Planid"  EmptyDataText="There are no data records to display.">  
                                         <Columns>
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
                                                  <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                             </Columns>
                                        </asp:GridView>
                                    </div>
                    </div>
                    </div>
               </div>
        </div>
</asp:Content>

