<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DashboardVehiclePlaced.aspx.cs" Inherits="DashboardVehiclePlaced" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:350px">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    &nbsp;&nbsp; FromDate :&nbsp;
    <asp:TextBox ID ="txt_FromDate" runat="server" ></asp:TextBox>
    <asp:ImageButton ID="img_Fromdate" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
    <ajaxToolkit:CalendarExtender ID ="cal_Fromdate" runat ="server" TargetControlID ="txt_FromDate" PopupButtonID ="img_Fromdate" ></ajaxToolkit:CalendarExtender>

    &nbsp;&nbsp;&nbsp;&nbsp;ToDate :&nbsp;

    <asp:TextBox ID ="txt_ToDate" runat="server" ></asp:TextBox>   <asp:ImageButton ID="img_Todate" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
        <ajaxToolkit:CalendarExtender ID ="cal_Todate" runat ="server" TargetControlID ="txt_ToDate" PopupButtonID ="img_Todate" ></ajaxToolkit:CalendarExtender>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Button ID="btn_Search" runat ="server" Text ="Search" OnClick="btn_Search_Click" Class="btn btn-primary"/>
        </div>
<br />
    <br />
    <asp:Panel ID="Panel1" runat="server"  Height="500px" Width="60%" ScrollBars="Auto"  Style="margin-left:100px" >
<asp:GridView ID="grd_DashboardVehicle" runat="server" CellPadding="4" 
                    ForeColor="#333333"  onrowdatabound="grd_DashboardVehicle_RowDataBound" ShowFooter="true" >
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333"  />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
        </asp:Panel>
     <br /><br /><br /><br /><br /><br />
</asp:Content>

