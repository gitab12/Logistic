<%@ Page Title="" Language="C#" MasterPageFile="~/scm/SCMBizconnect/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="scm_SCMBizconnect_test" %>

<%@ Register Src="~/scm/SCMBizconnect/UserControl/DashboardMenuBar.ascx" TagPrefix="uc1" TagName="DashboardMenuBar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
      <br />
      <br />
      <br />
      <br />
      <br />
    <uc1:DashboardMenuBar runat="server" ID="DashboardMenuBar" />
</asp:Content>

