<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="UploadIndent.aspx.cs" Inherits="UploadIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br /><br /><br />
    <%--<asp:LinkButton ID ="lnk_TripIndent" runat ="server" ></asp:LinkButton>--%>
    <div style="margin-left:350px">
    
    <a href ="http://www.scmbizconnect.com/Excel/IndentTemplate.xlsx">Download Rate Contract Template For Multiple Upload</a><br />
    <asp:FileUpload ID="ExcelUpload" runat="server" />
    <asp:Button ID="btn_UploadAndDisplay" runat="server" 
       Text="Validate"  onclick="btn_UploadAndDisplay_Click1" />
    <asp:Button ID="btn_Upload" runat="server" Text="Upload" onclick="btn_Upload_Click" 
        Enabled="False" />
        </div>
      
         <asp:Panel ID ="pnl_Indent" runat ="server" >
        <asp:GridView ID="grd_DisplayUploadfile" runat="server" Width="70%" 
        ForeColor="#333333" GridLines="both" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br /><br /><br /><br /><br /><br /><br />
         </asp:Panel> 
</asp:Content>

