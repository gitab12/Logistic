<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="TruckAssignment.aspx.cs" Inherits="TruckAssignment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
            
                <link href="Stylesheet/style.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/> 
    <script language="javascript" type="text/javascript" src="Scripts/dhtmlgoodies_calendar.js">
    </script>
    <style type="text/css">
        .style1
        {
            width: 268px;
        }
        .style2
        {
            width: 100%;
        }
    </style>
</head>
<body>    
<link type="text/css" rel="stylesheet" href="Scripts/dhtmlgoodies_calendar.css?random=20051112" media="screen"></link>
    <form id="Form1" runat="server">
        <br /><br /><br />
        <div style="margin-left:500px">
            <h2 class="title-one">Truck Assignment</h2>
        </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <asp:Panel ID="MainPanel" runat="server" ScrollBars="Auto" Width="450px" Style="margin-left:50px">
       
         <table width="100%" style="background-color: #ffffcc; width: 100%;">
             <tr>
                 <td class="style1" >
                     Adid&nbsp; :<asp:Label ID="lblAdIDw" Font-Size="8" runat="server" Font-Bold="True" 
                         ForeColor="#990000" Width="200px" ></asp:Label></td>
                 <td>
                     Source :<asp:Label ID="lblFrom" runat="server" 
                         ForeColor="Red" Width="95px" Font-Bold="True"></asp:Label></td>
             </tr>
             <tr>
                 <td class="style1">
                     Logistics Plan No :<asp:Label ID="lblLogisticPlanNo" runat="server" ForeColor="Black" 
                         Width="165px" Font-Bold="True" Font-Size="8pt"></asp:Label></td>
                 <td >
                     Destination :<asp:Label ID="lblTo" runat="server" ForeColor="#009933" 
                         Width="100px" Font-Bold="True"></asp:Label></td>
             </tr>
             <tr>
                 <td class="style1">
                     Trucks Required :<asp:Label ID="lblTruckRequired" runat="server" 
                         ForeColor="Black" Width="100px" Font-Bold="True"></asp:Label></td>
                 <td>
                     Travel Date :<asp:Label ID="lblTraveldate" runat="server" Font-Bold="True" 
                         ForeColor="#003366" Width="100px"></asp:Label></td>
             </tr>
         </table>
         <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="450px" EnableModelValidation="True" >
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select"
                        AutoPostBack="True" oncheckedchanged="cbSelectAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                       &nbsp; <asp:CheckBox ID="ChkSelect" Width="16px" runat="server" Height="18px" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblQuoteIDTitle" runat="server" Text="QuoteID"></asp:Label> 
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblQuoteID" runat="server" Width="35px" 
                            Text='<%# Bind("QuoteID") %>' Font-Bold="True" ForeColor="Maroon"></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblNoOfTrucksTitle" runat="server" Text="No Of trucks"></asp:Label> 
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtTruckRequired" runat="server" Width="35" 
                            BackColor="Transparent" BorderWidth="0" Text='<%# Bind("TruckRequired") %>'></asp:TextBox>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblQuotedCostTitle" runat="server" Text="QuoteCost"></asp:Label> 
                    </HeaderTemplate>
                    <ItemTemplate>
                    <asp:Image ID="ImgQuotedCost" runat="server" Height="11px" ImageAlign="Bottom" 
                           ImageUrl="~/Images/INR.png" Width="8px" />
                        &nbsp;<asp:Label ID="lblQuoteCost" runat="server" Text='<%# Bind("QuotedCost") %>'
                            Font-Bold="True" Font-Size="10pt" ForeColor="Red"></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblAssignedTrucksTitle" runat="server" Text="Assigned Trucks"></asp:Label> 
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtAssignedTrucks" Width="35" BorderWidth="1"
                        onKeyPress="return onlynumber(event)"
                        onkeyup='<%# "TruckAssignValidation(" +((GridViewRow)Container).FindControl("txtTruckRequired").ClientID + "," +((GridViewRow)Container).FindControl("txtAssignedTrucks").ClientID + ")"%>' 
                         Text='<%# Bind("AssignedTrucks") %>' runat="server"></asp:TextBox>
                         &nbsp;<asp:Label ID="lblStatus" runat="server" Width="35px" 
                            Text="Waiting" Font-Bold="True" Font-Size="8" Visible="false" ForeColor="Red"></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField Visible="false">
                    <HeaderTemplate>
                        <asp:Label ID="lblPostReplyIDTitle" runat="server" Text="PostReplyID" Visible="true"></asp:Label> 
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPostReplyID" runat="server" Width="35px" 
                            Text='<%# Bind("PostReplyID") %>' Font-Bold="True" Visible="true" ForeColor="Maroon"></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField  Visible="false">
                    <HeaderTemplate>
                        <asp:Label ID="lblPostIDTitle" runat="server" Text="PostID" Visible="true"></asp:Label> 
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPostID" runat="server" Width="35px" 
                            Text='<%# Bind("PostID") %>' Font-Bold="True" Visible="true" ForeColor="Maroon"></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>  
         <table class="style2">
             <tr>
                 <td>
                     <br />
                     <asp:Button ID="ButAssign" runat="server" onclick="ButAssign_Click" onmouseup="showPleaseWait()"
                         Text="Send for Approval"  Class="btn btn-primary"/>
                     <asp:Button ID="Butclose" runat="server" Text="Close" 
                         onclick="Butclose_Click"   Class="btn btn-primary"/>
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                 <div class="helptext" id="PleaseWait" style="display: none; 
                                        text-align:right; color:White; vertical-align:top;">
                                        <table id="MyTable" bgcolor="#cf4342">
                                           <tr>
                                           <td><img src="images/ajax-loader.gif" /></td>                    
                                           <td>                        
                                           <b><font color="White"><strong><b>Please Wait...!</b></strong></font></b>                    
                                           </td>                
                                           </tr>            
                                        </table>        
                                        </div>
                     <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" 
                         Width="300px"></asp:Label>
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
         </table>
    </asp:Panel>
     </ContentTemplate>
    </asp:UpdatePanel> 
    </form>
    </body>
</html>



