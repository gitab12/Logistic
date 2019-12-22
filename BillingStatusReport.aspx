<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BillingStatusReport.aspx.cs" Inherits="BillingStatusReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br />
      <div style="margin-left:450px"><h2 class="title-one">Bill Status Report</h2>
      </div><br />
    <div style="margin-left:450px">
      Select Client : <asp:DropDownList ID="ddl_Client" runat="server" AutoPostBack ="true"  OnSelectedIndexChanged ="ddl_Client_SelectedIndexChanged" ></asp:DropDownList><br /><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:RadioButton ID="rdb_Submitted" runat="server" Text ="Submitted" GroupName ="Aarms" AutoPostBack ="true" OnCheckedChanged ="rdb_Submitted_CheckedChanged"/>
&nbsp;
      <asp:RadioButton ID="rdb_NotSubmitted" runat="server" Text ="Not Submitted" GroupName ="Aarms" AutoPostBack ="true" OnCheckedChanged ="rdb_NotSubmitted_CheckedChanged"/>
    &nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Download" onclick="Button1_Click"  CssClass="btn btn-primary" />
        <br />
        <div style="margin-left:100px"><asp:Label ID ="lbl_Count" runat ="server" Font-Bold ="true"  ForeColor ="red"></asp:Label></div>
        </div>
        <br />
    <asp:Panel ID="pnl_1" runat="server"  Height="400px" Width="1200px" ScrollBars="Auto"  Style="margin-left:100px" >
     <asp:GridView ID="grd_BillingReport" runat="server" BorderColor="#E0E0E0"  OnRowDataBound="grd_BillingReport_RowDataBound"
    CellPadding="4" ForeColor="#333333" >
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Panel>

</asp:Content>

