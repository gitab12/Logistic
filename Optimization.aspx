<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Optimization.aspx.cs" Inherits="Optimization" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:150px">
    <table >
        <div style="margin-left:450px"> 
              <table class="auto-style1" style="margin-left:250px">
                        <tr>
                            <td>From Location :</td>
                            <td>&nbsp;To Location :</td>
                            <td>&nbsp;Select Truck Type :</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddl_FromLoc" runat="server" Width="150px">
                                </asp:DropDownList>&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_ToLoc" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddl_ToLoc_SelectedIndexChanged" >
                                </asp:DropDownList>&nbsp;
                            </td>
                            <td> <asp:dropdownlist ID="ddl_TruckType" runat="server" Width="170px"  AutoPostBack="True" OnSelectedIndexChanged="ddl_TruckType_SelectedIndexChanged" >
                                       </asp:dropdownlist>
                            </td>
                        </tr>
                        <tr>
                           
                            <td> <br /><asp:Button ID ="btn_ExportToExcel" runat ="server" Text ="Download To Excel" OnClick="btn_ExportToExcel_Click" class="btn btn-primary"/> </td>
                            <td> <br />
                            <asp:Button ID ="btn_Search" Text ="Calculate" runat ="server" OnClick="btn_Search_Click"  class="btn btn-primary"/>
                             </td>
                             <td> <br />
                             <a href ="Analysis.aspx" target="_blank">Analysis</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:HyperLink ID ="hyp_OptDispatchplan" runat ="server" Target ="_blank" NavigateUrl ="optDispatchplan.aspx" Text ="Despatch Plan"   ></asp:HyperLink>
                             <%--<a id="opt_Dispatchplan" href ="optDispatchplan.aspx" target="_blank" runat ="server" >Despatch Plan</a>--%>
                             </td>
                            <td>
               <asp:Label ID ="lbl_Capacity"  runat ="server" Font-Bold ="true" ForeColor="Red" ></asp:Label> </td>
                        </tr>
                        <tr>
                            <td>  <br /> Lowest Quote :<asp:TextBox ID="txt_LowestQuote" runat="server" Font-Bold="True"  Width="50px"></asp:TextBox>
                            </td>
                            <td>  <br /> Transporter Name :
                                <asp:Label ID="lbl_TransporterName" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table></div> 
                <%--<td>
                
                    Select Truck Type : <asp:dropdownlist ID="ddl_TruckType" runat="server" Width="210px"  AutoPostBack="True" OnSelectedIndexChanged="ddl_TruckType_SelectedIndexChanged" >
                                       </asp:dropdownlist>
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID ="btn_Search" Text ="Calculate" runat ="server" OnClick="btn_Search_Click" />
              <asp:Button ID ="btn_ExportToExcel" runat ="server" Text ="Download To Excel" OnClick="btn_ExportToExcel_Click" />
               <asp:Label ID ="lbl_Capacity"  runat ="server" Font-Bold ="true" ForeColor="Red" ></asp:Label> 
                </td>--%>
            </tr>
            <td>
                <br /><br />
              <asp:Panel ID="panel_1" runat="server"   Height ="270px" ScrollBars="Auto" Width="93%" GroupingText="" Style="margin-left:250px">
                     <asp:GridView ID="grd_Optimization" runat="server" CellPadding="4" AutoGenerateColumns ="false" ForeColor="#333333" GridLines="Both" >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     <Columns >
                          <asp:TemplateField HeaderText ="ParentCode" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ParentCode" Text ='<%#Eval ("ParentCode") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="ParentDesc" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ParentDesc" Text ='<%#Eval ("ParentDesc") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Brand" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Brand" Text ='<%#Eval ("Brand") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         
                      
                         
                         <asp:TemplateField HeaderText ="Length" >
                             <ItemTemplate >
                                                        
                                 <asp:TextBox ID ="txt_Length" runat ="server" Text ='<%#Eval ("Length") %>' Width ="30px" ></asp:TextBox>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_Breadth" runat ="server" Text ='<%#Eval ("Breadth") %>' Width ="30px" ></asp:TextBox>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" >
                             <ItemTemplate >
                                   <asp:TextBox ID ="txt_Height" runat ="server" Text ='<%#Eval ("Height") %>' Width ="30px" ></asp:TextBox>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Weight" >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_Weight" runat ="server" Text ='<%#Eval ("Weight") %>' Width ="30px"   ></asp:TextBox>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Unit" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Unit"  Text ='<%#Eval ("Unit") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="FeetConversion" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FeetCon" Text ='<%#Eval ("FeetConversion") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Length" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_OPTLength" runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" >
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTBreadth" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" >
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTHeight" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="CFT" >
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTCFT" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                          <asp:TemplateField HeaderText ="Loading Boxes with Space Constrain" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_OPTNoOfBoxes" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes with Weight Constrain" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_OPTLoadBoxes" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         
                        
                         
                         <asp:TemplateField HeaderText ="Cost Per Box"  ControlStyle-Width="30px">
                              <ItemTemplate >
                              <asp:Label ID ="lbl_Cost" runat ="server" with="30px" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
        </asp:GridView> 
                  </asp:Panel> 
                <br /><br /><br /><br /><br /><br /><br /><br /><br />
            </td>
             <td>
   
            </td>
        </tr>
    </table>
</div>

</asp:Content>

