<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="MultiplePosting.aspx.cs" Inherits="MultiplePosting" %>
<%--<%@ Register Src="~/UserControl/MenuBar.ascx" TagName="navi" TagPrefix="UC1" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<UC1:navi ID="navi1" runat="server" />--%>
<br />

 <script language="JavaScript" type="text/JavaScript">

     function callclick() {
         alert("a");
         var btn = document.getElementById("cmdUploadAndDisplay");
         alert(btn);
      

     }

 </script>
   
        <div class="col-sm-11 col-sm-offset-3">
  <a href="http://www.scmbizconnect.com/excel/logisticstripplan.xlsx" style="color:blue;text-decoration:underline">Download Trip Plan Format for multiple posting</a>
    </div>

            <br />
     <br />
     <div class="col-sm-11 col-sm-offset-3">
    <div class="row">
                
        <div class="col-sm-3 form-group">
             <asp:FileUpload ID="ExcelUpload" runat="server" />
            </div>
                <div class="col-sm-1 form-group">
                    <asp:Button ID="cmdUploadAndDisplay" runat="server"  Text="Validate"  onclick="cmdUploadAndDisplay_Click1"   class="btn btn-primary" />
                    </div>
                    <div class="col-sm-1 form-group">
                          <asp:Button ID="Upload" runat="server" Text="Upload" onclick="Upload_Click" Enabled="False"   class="btn btn-primary" />
            </div>
         <div class="col-sm-3 form-group">
             <asp:Button ID="ButSendMail" runat="server" Text="Send Mail" onclick="ButSendMail_Click" Visible="False"   class="btn btn-primary" />
             </div>
            </div>
        
    <br />
    <asp:Panel ID="Panel1" runat="server" Width ="70%" ScrollBars="Both" >
    
    <asp:GridView ID="UploadGridview" runat="server" Width="70%" CellPadding="4" 
        ForeColor="#333333" GridLines="None" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
      <asp:Label ID="lblRecordsFoundStatus" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
   <br />
    <asp:GridView ID="NotFoundGridview" runat="server" CellPadding="4" Width="70%" Caption=" Invalid Datas" onrowdatabound="NotFoundGridview_RowDataBound"
        ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
      <asp:Label ID="lblRecordsNotFoundStatus" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
    </asp:Panel>
    <br /><br /><br />  <br /><br /><br />  <br /><br /><br />
         </div>
  
</asp:Content>

