<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="User_mapping.aspx.cs" Inherits="User_mapping"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 22px;
        }
        .style3
        {
            height: 31px;
        }
        .tblBdr
        {
            border: thin solid  #FF0000;
            background-color:White;
         color:Black;
         font-weight:bold;
	
        }
             
        .td_bgcolor
        {
      background-color:#FF0000;
      color:White;   
  
     font-weight: 700;
    }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:200px">
    <table  cellpadding="0" cellspacing="0" class="tblBdr" width="60%">
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <table align="left" class="tblBdr" width="100%">
                    <tr>
                        <td colspan="6" class="td_bgcolor">
                        User Details
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            EMail -ID</td>
                        <td>
                            User Name</td>
                        <td class="style2">
                            Designation</td>
                        <td>
                            Department</td>
                        <td>
                            Phone</td>
                        <td>
                            Mobile</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="Drp_email" runat="server" AutoPostBack="True"   onselectedindexchanged="Drp_email_SelectedIndexChanged" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbl_user" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_desg" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_dpt" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_phone" runat="server"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lbl_mobile" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="style3" style="text-align: center">
            <asp:Label ID="lbl_topmessage" runat="server" Font-Bold="True" 
                ForeColor="#009933"></asp:Label>
            </td></tr>
        <tr><td style="text-align: center">
            <asp:Button ID="btn_assign_ID" runat="server" Class="btn btn-primary" 
                onclick="btn_assign_ID_Click" Text="Assign" />
            <br />
&nbsp;</td></tr>
        <tr>
            <td>
                <table align="left" class="tblBdr" width="100%">
                    <tr>
                        <td class="td_bgcolor">
                            Service Portals
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:CheckBoxList ID="ChkLst_access" runat="server" 
                                RepeatDirection="Horizontal" Font-Size="X-Small">
                            </asp:CheckBoxList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
       
        <!--Tab Box Section Starts -->
                            <asp:Panel ID="Panel1" runat="server" width="800px" height="400px" ScrollBars="Vertical">
                            
                   <table width="85%" border="0" cellpadding="0" cellspacing="1" id="grid_view" class="tblBdr">
                <tr >
                    <td style="color: #000000">
                     
                        <asp:Label ID="lbladid" runat="server"></asp:Label>
                        
                        
                        <asp:Repeater id="parentRepeater" runat="server"  
                            onitemcreated="parentRepeater_ItemCreated"      
                            onitemdatabound="parentRepeater_ItemDataBound">
<itemtemplate>

<asp:checkbox ID="lbladid" runat="server" Text=' <%# Eval("ServicePortalName")%>' AutoPostBack="true" oncheckedchanged="lbladid_CheckedChanged"></asp:checkbox><br />
     <hr />
     <asp:Repeater id="childRepeater" runat="server" onitemcreated="childRepeater_ItemCreated" >
<itemtemplate>
&nbsp;&nbsp;&nbsp;<asp:checkbox ID="lblad" runat="server" Text=' <%# Eval("ServicePortalCategoryName")%>' AutoPostBack="true" oncheckedchanged="lblad_CheckedChanged"></asp:checkbox><br />
     <table cellpadding="0px" cellspacing="0px" width="100%" class="txtbox" >
     <tr><td><asp:Repeater id="childRepeater2" runat="server" onitemcreated="childRepeater2_ItemCreated" >
<itemtemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox ID="lblchild2" runat="server" Text=' <%# Eval("FeatureName")%>' AutoPostBack="true"  ForeColor="Black"  oncheckedchanged="lblchild2_CheckedChanged"></asp:checkbox><br />
<table cellpadding="0PX" cellspacing="0PX" align="center" width="70%">
                   <tr><td> <%-- <asp:Panel ID="Pnl_access" runat="server" width="800px" height="50px" ScrollBars="Horizontal">--%>
                      <asp:Repeater id="childRepeater_access" runat="server" >
<itemtemplate> 

&nbsp;&nbsp;<asp:checkbox ID="ChkLst_access"   runat="server" Text=' <%# Eval("AccessName")%>' ForeColor="Black" Width="200px"  AutoPostBack="true" oncheckedchanged="ChkLst_access_CheckedChanged"></asp:checkbox>
<%--<asp:checkbox ID="ChkLst_access" runat="server"  AutoPostBack="true" Width="150px" Text=' <%# Eval("AccessName")%>'    Font-Size="X-Small">
                            </asp:checkbox>--%>
 </itemtemplate>
</asp:Repeater><%--</asp:Panel>--%></td></tr>
                    </table>
</itemtemplate>
</asp:Repeater></td></tr>
     </table>  
     
</itemtemplate>
</asp:Repeater>
</itemtemplate>
</asp:Repeater>
                        
                        
                    </td>
                    
                   
                </tr>
                
            </table>   
          
    </asp:Panel>
    </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>

        </div>
    <br /><br /><br /><br /><br /><br />
</asp:Content>

