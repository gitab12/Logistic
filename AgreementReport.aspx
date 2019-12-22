<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AgreementReport.aspx.cs" Inherits="AgreementReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br />
      <div style="margin-left:450px"><h2 class="title-one">Agreement Report</h2>
        </div> <br/>
     <div style="margin-left:450px">
     &nbsp;
 Search by client :  <asp:DropDownList ID ="ddl_Client" AutoPostBack ="true"  runat ="server" OnSelectedIndexChanged ="ddl_Client_SelectedIndexChanged" Width="222px" ></asp:DropDownList>
</div>
     <br />   <br />
     <asp:Panel ID="pnl_1" runat="server"  Height="400px" Width="1200px" ScrollBars="Auto"  Style="margin-left:100px" >
     <asp:GridView ID="grd_AgreementReport" runat="server" BorderColor="#E0E0E0" 
    CellPadding="4" ForeColor="#333333"  >
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
         </asp:Panel>
         <br /><br /><br /><br /><br /><br /><br />
</asp:Content>

