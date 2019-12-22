<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceBillReport.aspx.cs" Inherits="InvoiceBillReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <center><h2 style="color: #FF0000">Invoice Bill Report</h2></center>
<br />
        <asp:Button ID="btn_Download" runat="server" Text="Download" onclick="btn_Download_Click"/><br /><br />

        <asp:GridView ID="grd_BillReport" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="Both" OnRowDataBound ="grd_BillReport_RowDataBound" >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:GridView>
    </form>
</body>
</html>
