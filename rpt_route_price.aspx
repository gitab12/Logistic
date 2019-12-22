<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="rpt_route_price.aspx.cs" Inherits="rpt_route_price" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

    <style type="text/css">
        .style2
        {
            width: 80%;
        }
        .style4
        {
            width: 161px;
        }
         .tblBdr
            {
                border: thin solid  #FF0000;
                background-color:White;
             color:Black;
             font-weight:bold;
	
            }
        .txtbox
            {
                border: 1px solid #FF0000;
                padding: 1px;
                    font-size: x-small;
                 font-family: Tahoma;
                 background-color: #ffffff;
                    font-weight: 700;
            }
        .btn
        {
   
          border-style: none;
         border-color: inherit;
         border-width: medium;
           color:Black;
         font-weight: 700;
        }
    </style>     


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<asp:Panel ScrollBars ="Both" Height ="40%"  Width ="70%" runat="server" >
    <br /><br /><br /><br /><br /><br /><br />

    <table align="left"  width="50%" cellpadding="0px" cellspacing="0px" class="tblBdr">
        <tr>
            <td class="td_bgcolor">
                Route Price Annexure</td>
        </tr>
        <tr>
            <td>
                <table align="center" class="style2">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btn_export" runat="server" CssClass="btn" 
                                 Text="Export to Excel" onclick="btn_export_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style4">
                        Search by Transporter Name
                        </td>
                        <td>
                       <asp:TextBox ID="txtsearch" runat="server" ontextchanged="txtsearch_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnsearch" runat="server" Text="Search" 
                                onclick="btnsearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:GridView ID="Grid_cform" runat="server" CssClass="btn" Width="60%" 
                    AutoGenerateColumns="false" onrowediting="Grid_cform_RowEditing" 
                    onrowcancelingedit="Grid_cform_RowCancelingEdit" 
                    onrowupdating="Grid_cform_RowUpdating" 
                    onrowupdated="Grid_cform_RowUpdated" 
                    onselectedindexchanged="Grid_cform_SelectedIndexChanged">
                  <Columns>
                   <asp:TemplateField HeaderText="Route_ID" Visible="false">
                     <ItemTemplate>
                         <asp:Label ID="lblRoute_ID" runat="server" Text='<%#Eval("Route_ID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Transporter_Name">
                     <ItemTemplate>
                         <asp:Label ID="lblTransporter_Name" runat="server" Text='<%#Eval("Transporter_Name")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
         
                    
                    <asp:TemplateField HeaderText="Source">
                     <ItemTemplate>
                         <asp:Label ID="lblSource" runat="server" Text='<%#Eval("Source")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Destination">
                     <ItemTemplate>
                         <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("Destination")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Capacity">
                     <ItemTemplate>
                         <asp:Label ID="lblCapacity" runat="server" Text='<%#Eval("Capacity")%>'></asp:Label>
                      </ItemTemplate>
                       <EditItemTemplate>
                        <asp:TextBox ID="txtCapacity" runat="server" Width="40px" Text='<%#Eval("Capacity")%>'></asp:TextBox>
                       </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Unit">
                     <ItemTemplate>
                         <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Unit")%>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                       <asp:TextBox ID="txtUnit" runat="server" Text='<%#Eval("Unit")%>' Width="40px"></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Oneway_Price">
                     <ItemTemplate>
                         <asp:Label ID="lblOneway_Price" runat="server" Text='<%#Eval("Oneway_Price")%>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                      <asp:TextBox ID="txtOneway_Price" runat="server" Text='<%#Eval("Oneway_Price")%>' Width="40px"></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Twoway_price">
                     <ItemTemplate>
                         <asp:Label ID="lblTwoway_price" runat="server" Text='<%#Eval("Twoway_price")%>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                       <asp:TextBox ID="txtTwoway_price" runat="server" Text='<%#Eval("Twoway_price")%>' Width="40px"></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>
                                                  
                  <asp:TemplateField HeaderText="Post_date">
                     <ItemTemplate>
                         <asp:Label ID="lblPost_date" runat="server" Text='<%#Eval("Post_date")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:CommandField EditText="Edit\Update" HeaderText="Action" ShowEditButton="True"/> --%>
                    <asp:TemplateField>
<ItemTemplate>
<asp:HyperLink ID="lnkEdit" runat="server" Text="Edit\Update" NavigateUrl=<%# String.Format("javascript:void(window.open('Updatecust.aspx?Route_ID={0}',null,'right=362px, top=134px, width=500px, height=500px, status=no,resizable= yes, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("Route_ID")) %>></asp:HyperLink>
</ItemTemplate>
</asp:TemplateField>                      
                  </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Panel>
</asp:Content>

