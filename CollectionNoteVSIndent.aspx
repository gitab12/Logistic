<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CollectionNoteVSIndent.aspx.cs" Inherits="CollectionNoteVSIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

     <style type ="text/css">
        .grid-header
        {
            font-weight: bold;
            font-family: Verdana;
            font-size: 11px;
            background-color: #556B2F;
            text-decoration: underline;
            color: White;
            text-align: left;
            position: relative;
            top: expression(this.parentNode.parentNode.parentNode.scrollTop-2);
            left: expression(this.parentNode.parentNode.parentNode.scrollLeft-1);
            right: 1px;
        }

    </style>

     <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=GridReport.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:350px">
    <left><h2 class="title-one">CollectionNote vs Rate Contract</h2></left>
       </div>
    <div style="margin-left:400px">
     <br />
     ProjectNo : <asp:DropDownList ID="ddl_ProjectNo" runat="server" Height="20px" AutoPostBack ="true"  OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged" Width="104px"></asp:DropDownList>
    &nbsp;&nbsp;
    WBSNo : <asp:DropDownList ID="ddl_Wbsno" runat="server" Height="20px" Width="91px" AppendDataBoundItems="True"  >
        <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search"   Class="btn btn-primary" />
    &nbsp;<br />
        </div>
        <center> 
            <br />
   
          <asp:Panel ID="pnl_CNoteVsIndent" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px">
    <asp:GridView ID="GridReport" runat="server"  AllowPaging ="True" PageSize ="1000" OnPageIndexChanging ="GridReport_PageIndexChanging" onrowdatabound="GridReport_RowDataBound">
        <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
        <PagerSettings Position ="Top"  Mode ="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
    </asp:GridView>
          </asp:Panel> 
          </center>
</asp:Content>

