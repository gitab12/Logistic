<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MISReport.aspx.cs" Inherits="MISReport" %>

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
        $('#<%=grd_MsiReport.ClientID %>').Scrollable();
    }
)
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <br /><br /><br /><br /><br /><br />
 <style type="text/css">
        .auto-style1 {
            color: #B70808;

        }
    </style>
    <div style="margin-left:550px"><h2 class="title-one">MIS Report</h2></div>
  <div style="margin-left:250px">
      <asp:Panel ID="panelcontent" runat="server">
       <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
    <table>
        <caption>
            <h2 style="color:#B70808"><center>Advanced Search:</center></h2>
            <tr align="left" >
            <td class="auto-style1" style="color:#B70808;font-size:22px;width: 450px;">Search By ProjecNo and WBSNo :</></td>
                <td class="auto-style1"  align="left">Collection Note Status</td>
                <td class="auto-style1"><center> Trip Status </center></td>
                <td class="auto-style1">Loading Status</td>
            </tr>
           <br />
            <br />
            <tr>
            <td>
                 <asp:updatepanel id="Updatepanel1" runat="server" UpdateMode ="Conditional" ChildrenAsTriggers ="true" >
          <ContentTemplate>
                    ProjectNo : <asp:DropDownList ID="ddl_ProjectNo" runat="server" Height="20px" AutoPostBack ="true"  OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged" Width="104px"></asp:DropDownList>
    &nbsp;&nbsp;
    WBSNo : <asp:DropDownList ID="ddl_Wbsno" runat="server" Height="20px" Width="91px" AppendDataBoundItems="True"  >
        <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList> &nbsp;&nbsp;
              </ContentTemplate>
           </asp:updatepanel>
                <br />
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search" Class="btn btn-primary" />
                </td>
                 <td  align="left"> &nbsp;&nbsp;
                   <asp:CheckBoxList ID="chkCNstatus" runat="server">
                        <asp:ListItem Value="1">Confirmed</asp:ListItem>
                        <asp:ListItem Value="0">Not Confirmed</asp:ListItem>
                        <asp:ListItem Value="2">Amendment</asp:ListItem>
                        <asp:ListItem Value="4">Need Approval</asp:ListItem>
                        <asp:ListItem Value="3">Cancelled</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                
                <td  align="left"> &nbsp;&nbsp;
                    <asp:CheckBoxList ID="chkTripconfirm" runat="server">
                        <asp:ListItem Value="1"> &nbsp;&nbsp;Trip Confirm</asp:ListItem>
                        <asp:ListItem Value="0"> &nbsp;&nbsp;Trip Not Confirm</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
               
                <td  align="left"> &nbsp;&nbsp;
                    <asp:CheckBoxList ID="chkloadedstatus" runat="server">
                        <asp:ListItem Value="1"> &nbsp;&nbsp;Loaded</asp:ListItem>
                        <asp:ListItem Value="0"> &nbsp;&nbsp;Not Loaded</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
              
                <td> &nbsp;&nbsp;
                     &nbsp;&nbsp;<asp:Button ID="btn_DownloadFullMIS" runat="server" Visible ="false"  Text="Direct Download to Excel" OnClick ="btn_DownloadFullMIS_Click"  Class="btn btn-primary"/>
                     <br />
                    <br />
                      &nbsp;&nbsp;<asp:Button ID="btnsearch" runat="server" Text="AdvancedSearch" OnClick="btnsearch_Click" Class="btn btn-primary"/>
  &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Download To Excel" 
            onclick="Button2_Click" Class="btn btn-primary"/>
                </td>
            </tr>
        </caption>
     
            </table>
      </asp:Panel></div>
  
         <asp:Panel ID="pnl_MisReport" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" Visible="false">
    <asp:GridView ID="grd_MsiReport" runat="server" >

    <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
    </asp:GridView>

             

  </asp:Panel>
    <br />
             <br />
             <br />
             <br />
             <br />
    <br />
             <br />
             <br />
             <br />
</asp:Content>

