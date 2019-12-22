<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BillStatusReport.aspx.cs" Inherits="BillStatusReport" EnableEventValidation ="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
<script type="text/javascript">
<!--
    function popup(mylink, windowname) {
        if (!window.focus) return true;
        var href;
        if (typeof (mylink) == 'string')
            href = mylink;
        else
            href = mylink.href;
        window.open(href, windowname, 'width=900,height=1000,scrollbars=yes');
        return false;
    }
//-->
</SCRIPT>

        <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=GridBillStatusReport.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /> <br /><br /> <br /><br />
    <center><h2 class="title-one">Bill Status Report</h2></center><br />
      <center><asp:Button ID="btn_Download" runat="server" Text="Download To Excel" onclick="btn_Download_Click"  Class="btn btn-primary" />  </center>
    <br />
    <br />

        <asp:Panel ID="pnl_BillStatus" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
   <asp:GridView ID="GridBillStatusReport" runat="server" 
              ForeColor="#333333" 
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="False" 
             >
       
              <RowStyle BorderColor="Red" />
          
              <Columns>
                  <asp:BoundField DataField="ProjectNo" HeaderText="ProjectNo" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="CollectionNoteNumber" HeaderText="CNNo" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="WBSNo" HeaderText="WBSNo"  HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="ConfirmNo" HeaderText="ConfirmNo" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="Transporter" HeaderText="Transporter" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="FromLocation" HeaderText="FromLocation" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="ToLocation" HeaderText="ToLocation" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="TravelDate" HeaderText="TravelDate" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="TruckType" HeaderText="TruckType" HeaderStyle-HorizontalAlign ="Left" />
                   <asp:BoundField DataField="LRNumber" HeaderText="LRNumber" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="LRDate" HeaderText="LRDate" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="BillSubmissionNo" HeaderText="BillSubmissionNo" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="BillNo" HeaderText="BillNo" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="BillValue" HeaderText="BillValue" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="BillDate" HeaderText="BillDate" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="TransporterPrice" HeaderText="TransporterPrice" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="ClientPrice" HeaderText="ClientPrice" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="Difference" HeaderText="Difference" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField="BillStatus" HeaderText="BillStatus" HeaderStyle-HorizontalAlign ="Left" />

                        
                 <asp:TemplateField HeaderText="BillImage">
<ItemTemplate>
<%--<asp:HyperLink ID="lnledit" runat="server"  Text="BillImage" NavigateUrl=<%# String.Format("javascript:void(window.open('BillStatusReportImage.aspx?BillID={0}',null,'right=362px, top=134px, width=1400px, height=1000px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("BillSubmissionNo")) %>></asp:HyperLink>--%>

    <asp:LinkButton id="lnk_Image" OnClick ="lnk_Image_Click"  runat="server" Style="color:blue;text-decoration:underline">BillImage</asp:LinkButton>
    <asp:Label ID="imgID" runat="server" Text='<%# Bind("BillSubmissionNo") %>'></asp:Label>

</ItemTemplate>

</asp:TemplateField>

                  <%--  <asp:TemplateField HeaderText="BillImage">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BillImage") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                      <a href="BillPreview.aspx" onClick="return popup(this, 'notes')">  <asp:Image ID="Image1" runat="server" Height="43px" Width="119px"   ImageUrl='<%# Eval("BillSubmissionNo", "BillImage.ashx?ImageID={0}")%>'/></a>
                        <asp:ImageButton ID="Image1" runat="server" Height="43px" Width="119px" 
                              ImageUrl='<%# Eval("BillSubmissionNo", "BillImage.ashx?ImageID={0}")%>' 
                              onclick="Image1_Click"/>
                          <asp:Label ID="imgID" runat="server" Text='<%# Bind("BillSubmissionNo") %>'></asp:Label>
          
                      </ItemTemplate>
                  </asp:TemplateField>--%>
              </Columns>
          
              <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
          </asp:GridView>
        </asp:Panel>
</asp:Content>

