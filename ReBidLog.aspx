<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ReBidLog.aspx.cs" Inherits="ReBidLog" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br /><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin-left:450px">
     <h2 class="title-one">ReBidLog Report</h2>
        </div>
    <br />
    <div style="margin-left:450px">
  Bid Date :  <asp:TextBox ID ="txt_Biddate" runat ="server" Width ="80px" ></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID ="cal_ReqDate" TargetControlID ="txt_Biddate" PopupButtonID ="imgdate1" runat ="server" ></ajaxToolkit:CalendarExtender>
    <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
    &nbsp;
    <asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search" />
        </div>
    <br />
    <br />
    <asp:Panel ID="pnl_MisReport" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
    <asp:GridView ID="grd_Rebidlog" runat="server" >
        <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
    </asp:GridView>
        </asp:Panel>

       <br /><br /><br /><br /><br /><br />    <br /><br /><br /><br /><br /><br />
</asp:Content>

