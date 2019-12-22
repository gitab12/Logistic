<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RcVsActual.aspx.cs" Inherits="RcVsActual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br /><br /> 
   <center><h2 class="title-one">RateContract Vs Actual Report</h2></center>
    <br />
     <center>
    <table >
        <tr>
            <td>

           Select Project No  :   <asp:DropDownList ID="ddl_ProjectNo" Width ="150px" runat="server" AutoPostBack ="true"  OnSelectedIndexChanged ="ddl_ProjectNo_SelectedIndexChanged" >
                </asp:DropDownList>

            </td>
             <td>

              &nbsp;&nbsp;

              Select WBS No :   <asp:DropDownList ID="ddl_WbsNo" Width ="150px" runat="server">
                 </asp:DropDownList>

            </td>
             <td>

                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                 <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" class="btn btn-primary" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btn_Download" runat="server" Text="Download To Excel" onclick="btn_Download_Click"  class="btn btn-primary"/>

            </td>
        </tr>
    </table>
         </center>
    <br />
     <asp:Panel ID="pnl_RcVsActual" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px" >
    <asp:GridView ID="grd_RcVsActual" runat="server"  AutoGenerateColumns ="false" DataKeyNames ="Serialno" 
          OnRowDataBound ="grd_RcVsActual_RowDataBound"  AllowPaging ="true" PageSize ="200" OnPageIndexChanging ="grd_RcVsActual_PageIndexChanging"
                        CellPadding="4" ForeColor="#333333" >
         <RowStyle BorderColor="Red" />
                        <Columns >
                             <asp:BoundField DataField="ProjectNo" HeaderText="ProjectNo" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="WBS" HeaderText="WBS" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="Qty" HeaderText="Quantity" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="PlaceofDespatch" HeaderText="Loading Point" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="PlaceofDelivery" HeaderText="Delivery point" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="TrucksPlanned" HeaderText="Vehicles required as per RC" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="TruckType" HeaderText="Trucktype"  HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="IndentAmount" HeaderText="Rate per vehicle" HeaderStyle-HorizontalAlign ="Left" />
                            <asp:BoundField DataField="TransitDays" HeaderText="Transitdays" HeaderStyle-HorizontalAlign ="Left" />
                              <asp:TemplateField HeaderText="Transporter" HeaderStyle-HorizontalAlign ="Left" >

                      <ItemTemplate>
                          <asp:Label ID="lbl_Transporter" runat ="server" Text ="-" ></asp:Label>
                          </ItemTemplate> 
                                 </asp:TemplateField> 
                              <asp:TemplateField HeaderText="CN Generated">

                      <ItemTemplate>
                          <asp:Label ID="lbl_CNGenerated" runat ="server" Text ="-" ></asp:Label>
                          </ItemTemplate> 
                                 </asp:TemplateField> 

                              <asp:TemplateField HeaderText="Vehicle Planned">

                      <ItemTemplate>
                          <asp:Label ID="lbl_VehPlanned" runat ="server" Text ="0" ></asp:Label>
                          </ItemTemplate> 
                                 </asp:TemplateField> 


                              <asp:TemplateField HeaderText="Vehicle Placed">

                      <ItemTemplate>
                          <asp:Label ID="lbl_VehPlaced" runat ="server" Text ="0" ></asp:Label>
                          </ItemTemplate> 
                                 </asp:TemplateField> 
                              <asp:TemplateField HeaderText="Balance Vehicles">

                      <ItemTemplate>
                          <asp:Label ID="lbl_BalVehicles" runat ="server" Text ="0" ></asp:Label>
                          </ItemTemplate> 
                                 </asp:TemplateField> 
                        </Columns>
          
         <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />

          <PagerSettings Position ="Top" Mode ="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
                    </asp:GridView>
         </asp:Panel>
</asp:Content>

