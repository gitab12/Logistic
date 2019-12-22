<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Analysis.aspx.cs" Inherits="Analysis" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
table.gridtable {
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:Black;
	border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;
}
table.gridtable th {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #dedede;
}
table.gridtable td {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #ffffff;
}
        .style2
       {
           width: 282px;
           height: 21px;
       }
       .style3
       {
           height: 21px;
       }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:500px">
        <h2 class="title-one"><i>Analysis</i></h2>

    </div>
    <div  style="margin-left:200px">
     <table >
            <tr>
                <td>
                    <br />
                    <table class="auto-style1">
                        <tr>
                            <td>&nbsp;To Location :</td>
                            <td>From Location :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Despatch PlanNo &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdb_Weight" runat="server" Text ="Weight Analysis" Checked ="true"  GroupName ="Analysis" />
&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdb_Volume" runat="server" Text ="Volume Analysis" GroupName ="Analysis" /> 

                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddl_ToLoc" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddl_ToLoc_SelectedIndexChanged">
                                </asp:DropDownList>
                                <br />
                                <br />
                            </td>
                            <td>
                                &nbsp;
                                <asp:DropDownList ID="ddl_FromLoc" runat="server" Width="150px"  >
                                </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                 <asp:DropDownList ID="ddl_PlanNo" runat="server" Width="100px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_PlanNo_SelectedIndexChanged" >
                                </asp:DropDownList>

                                <br />
                                <br />
                            </td>
                            <td> 
                                 &nbsp;</td>
                        </tr>
                        <tr>
                            <td> <asp:Button ID ="btn_ExportToExcel" runat ="server" Text ="Download To Excel" OnClick="btn_ExportToExcel_Click"  Class="btn btn-primary"/></td>
                            <td>
                            <asp:Button ID ="btn_Analysis" Text ="Analysis" Visible ="false"  runat ="server" OnClick="btn_Analysis_Click"   Class="btn btn-primary"/>

                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Analysis"  Class="btn btn-primary"/>
                                &nbsp;&nbsp;<asp:Button ID="btn_TrucksSummary" runat="server" Text="Summary" OnClick="btn_TrucksSummary_Click"  Class="btn btn-primary" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Summary" runat="server" Text="Optimization" OnClick="btn_Summary_Click"   Class="btn btn-primary"/>
                            &nbsp;
                            <asp:Button ID ="btn_Despatchplan" Text ="Despatchplan" runat ="server" OnClick="btn_Despatchplan_Click" Visible ="false"   Class="btn btn-primary" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_GtnOptimization" runat="server" Text="GTN Optimization" OnClick ="btn_GtnOptimization_Click"   Class="btn btn-primary" />
                                 </td>
                            <td>
               <asp:Label ID ="lbl_Capacity"  runat ="server" Font-Bold ="true" ></asp:Label> </td>
                        </tr>
                        </table>
                </td>
            </tr>
            <td>
                <asp:Panel ID="pnl_Summary" runat="server" Visible ="false" >
                    <table >
                        <tr>
                            <td>
                                
                            
                                 Enter cost/truck&nbsp;&nbsp;&nbsp;
                                
                            
                                 <asp:TextBox ID="txt_FTL" BorderColor ="#990000" runat="server" Width="45px" Text ="0" ToolTip ="Enter FTL cost" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                            
                                 &nbsp;&nbsp;&nbsp;
                                 <asp:TextBox ID="txt_Taurus" runat="server" BorderColor="#990000" BorderStyle="Solid" BorderWidth="1px" Text="0" ToolTip="Enter Taurus cost" Width="45px"></asp:TextBox>
                                 &nbsp;&nbsp;&nbsp;&nbsp;

                            
                                 <asp:TextBox ID="txt_32ftsa" BorderColor ="#990000" runat="server" Width="45px" Text ="0" ToolTip ="Enter 32ftsa cost" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>

                            
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            
                                 <asp:TextBox ID="txt_32ftma" BorderColor ="#990000" runat="server" Width="45px" Text ="0" ToolTip ="Enter 32ftma cost" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>


                                 <br />
                                 <br />
                                 Enter SOP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:TextBox ID="txt_FTLSop"   BorderColor ="#990000" runat="server" Width="25px" Text ="0" ToolTip ="Enter FTL cost" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>

                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:TextBox ID="txt_TaurusSop" runat="server" BorderColor="#990000" BorderStyle="Solid" BorderWidth="1px" Text="0" ToolTip="Enter FTL cost" Width="25px"></asp:TextBox>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:TextBox ID="txt_32ftsaSop" runat="server" BorderColor="#990000" BorderStyle="Solid" BorderWidth="1px" Text="0" ToolTip="Enter FTL cost" Width="25px"></asp:TextBox>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:TextBox ID="txt_32ftmaSop" runat="server" BorderColor="#990000" BorderStyle="Solid" BorderWidth="1px" Text="0" ToolTip="Enter FTL cost" Width="25px"></asp:TextBox>


                            </td>
                             
                        </tr>
                        <tr>
                            <td colspan ="5">

                 <asp:GridView ID="grd_Summary" runat="server" CellPadding="4"   ForeColor="#333333" ShowHeader ="true"  EnableModelValidation="True" >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:GridView>
     </td>
                        </tr>

                    </table>


                </asp:Panel>

                 <asp:GridView ID="grd_Analysis" runat="server" CellPadding="4" AutoGenerateColumns ="false" Visible ="false" 
                      ForeColor="#333333" GridLines="Both"  >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     <Columns >
                          <asp:TemplateField HeaderText ="FromLocation" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Fromlocation" Text ='<%#Eval ("FromLocation") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="ToLocation" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ToLocation" Text ='<%#Eval ("ToLocation") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="PlanNo" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_PlanNo" Text ='<%#Eval ("PlanNo") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText ="TravelDate" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Traveldate" Text ='<%#Eval ("TravelDate") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Length" Visible ="false" >
                       <EditItemTemplate>
                                 <asp:TextBox ID ="txt_Length" runat ="server" Text ='<%#Eval ("Length") %>' Width ="30px" ></asp:TextBox>
                           </EditItemTemplate>
                             <ItemTemplate >
                                      <asp:Label ID ="lbl_Length" Text ='<%#Eval ("Length") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" Visible ="false" >
                               <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Breadth" runat ="server" Text ='<%#Eval ("Width") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Breadth" Text ='<%#Eval ("Width") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" Visible ="false" >
                              <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Height" runat ="server" Text ='<%#Eval ("Height") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_Height" Text ='<%#Eval ("Height") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Weight" >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_Weight" runat ="server" Text ='<%#Eval ("Weight") %>' Width ="30px"   ></asp:TextBox>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="FeetConversion" Visible ="false" >
                              <EditItemTemplate>
                                  <asp:TextBox ID ="txt_FeetCon" runat ="server" Text ='<%#Eval ("FeetConversion") %>' Width ="30px"   ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FeetCon" Text ='<%#Eval ("FeetConversion") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Length" Visible ="false" >
                              
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_OPTLength" runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" Visible ="false" >
                             
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTBreadth" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" Visible ="false" >
                              
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTHeight" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="CFT" Visible ="false">
                              
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTCFT" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                          <asp:TemplateField HeaderText ="Loading Boxes With Space Constrain in FTL" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxesFtl" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Space Constrain in Taurus" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxesTaurus" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Space Constrain in 32ft S/A" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxes32sa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Space Constrain in 32ft M/A" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxes32ma" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In FTL" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesFTL" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In Taurus" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesTaurus" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In 32ft S/A" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxes32ftsa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In 32ft M/A" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxes32ftma" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="FTL Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_Ftl" runat ="server" Text ="FTL Cost per Box"></asp:Label><br /><br />
                                 <asp:TextBox ID="txt_Ftl" runat ="server" Width="40px" ></asp:TextBox>
                             </HeaderTemplate>
                            <ItemTemplate >
                              <asp:Label ID ="lbl_CostforFTL" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Tauras Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_Tauras" runat ="server" Text ="Tauras Cost per Box"></asp:Label><br /><br />
                                 <asp:TextBox ID="txt_Tauras" runat ="server" Width="40px" ></asp:TextBox>
                             </HeaderTemplate>
                             <ItemTemplate >
                              <asp:Label ID ="lbl_CostforTaurus" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft S/A Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_32ftsa" runat ="server" Text ="32ft S/A Cost per Box"></asp:Label><br /><br />
                                 <asp:TextBox ID="txt_32ftsa" runat ="server" Width="40px" ></asp:TextBox>
                             </HeaderTemplate>
                             <ItemTemplate >
                              <asp:Label ID ="lbl_Costfor32ftsa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft M/A Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_32ftma" runat ="server" Text ="32ft M/A Cost per Box"></asp:Label><br />
                                 <asp:TextBox ID="txt_32ftma" runat ="server" Width="40px" ></asp:TextBox>
                             </HeaderTemplate>
                             <ItemTemplate >
                              <asp:Label ID ="lbl_Costfor32ftma" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
        </asp:GridView>


                 <br />

                 <asp:Panel ID ="pnl_OptSummary" runat ="server" Width ="1100px" Visible ="false"  >
        <table class="gridtable" >
      <tr>
          <td>
              Plan ID
              <br />
              <asp:Label ID="lbl_PlanID" runat ="server" ></asp:Label>
          </td>
           <td>
               From Loc
               <br />
               <asp:Label ID="lbl_FroLoc" runat ="server" ></asp:Label>
          </td>
           <td>
To Loc
               <br />
               <asp:Label ID="lbl_ToLoc" runat ="server" ></asp:Label>
          </td>
          <td>&nbsp;</td>
           <td>
               Despatch Date
               <br />
               <asp:Label ID="lbl_Traveldate" runat ="server" ></asp:Label>
          </td>
          <td></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>
            <tr>
                <td>Truck</td>
                <td>Capacity (In KGS)</td>
                <td>OPtimized Despatch (In KGS)</td>
                <td>No Of Cartons</td>
                <td>Noof Trucks<br /> Required</td>
                <td>Cost/Truck</td>
                <td>Total Cost</td>
                <td>Cost/Carton</td>
                <td>Cost/Ton</td>
                <td>Request for truck</td>
                <td>Approval</td>
            </tr>
            <tr>
                <td>FTL</td>
                <td>9000</td>
                <td>
                    <asp:Label ID="lbl_FtlWeight" runat="server"></asp:Label>
                </td>
                  <td>
                    <asp:Label ID="lbl_FTLNoofCartons" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_FtlTrucksReq" runat="server"></asp:Label>
                </td>
                 <td>
                    <asp:TextBox ID="txt_FtlCost" runat="server" Width ="45px" Text ="0" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lbl_FtlTotCost" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_FTLCostPerCarton" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_FTLCostPerton" runat="server" ></asp:Label>
                </td>
                <td><a href ="">Request for truck</a></td>
                <td><a href ="">Approval</a></td>
            </tr>
            <tr>
                <td>Taurus</td>
                <td>15000</td>
                <td>
                    <asp:Label ID="lbl_TaurusWeight" runat="server"></asp:Label>
                </td>
                  <td>
                    <asp:Label ID="lbl_TaurusNoofCartons" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_TaurusTrucksReq" runat="server"></asp:Label>
                </td>
               <td>
                    <asp:TextBox ID="txt_TaurusCost" runat="server" Width ="45px" Text ="0" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lbl_TaurusTotCost" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_TaurusCostPerCarton" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_TaurusCostPerton" runat="server" ></asp:Label>
                </td>
                <td><a href ="">Request for truck</a></td>
                <td><a href ="">Approval</a></td>
            </tr>
            <tr>
                <td>32ftsa</td>
                <td>7000</td>
                <td>
                    <asp:Label ID="lbl_32saWeight" runat="server"></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="lbl_SaNoofCartons" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_32saTrucksReq" runat="server"></asp:Label>
                </td>
                 <td>
                    <asp:TextBox ID="txt_SaCost" runat="server" Width ="45px" Text ="0" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lbl_SaTotCost" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_SaCostPerCarton" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_SaCostPerton" runat="server" ></asp:Label>
                </td>
                <td><a href ="">Request for truck</a></td>
                <td><a href ="">Approval</a></td>
            </tr>
            <tr>
                <td>32ftma</td>
                <td>15000</td>
                <td>
                    <asp:Label ID="lbl_32maWeight" runat="server"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lbl_MaNoofCartons" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_32maTrucksReq" runat="server"></asp:Label>
                </td>
                 <td>
                    <asp:TextBox ID="txt_MaCost" runat="server" Width ="45px" Text ="0" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lbl_MaTotCost" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_MaCostPerCarton" runat="server" ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_MaCostPerton" runat="server" ></asp:Label>
                </td>
                <td><a href ="">Request for truck</a></td>
                <td><a href ="">Approval</a></td>
            </tr>
    </table>
    </asp:Panel>
                <br />



                <asp:GridView ID="grd_WeightAnalysis" runat="server" CellPadding="4" ShowFooter ="true"  AutoGenerateColumns ="false" Visible ="false"  Caption ="Weight Analysis"
                      ForeColor="#333333" GridLines="Both"  >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     <Columns >
                          <asp:TemplateField HeaderText ="FromLocation" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Fromlocation" Text ='<%#Eval ("FromLocation") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="ToLocation" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ToLocation" Text ='<%#Eval ("ToLocation") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="PlanNo" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_PlanNo" Text ='<%#Eval ("PlanNo") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText ="Traveldate" Visible ="false"  >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_TravelDate" Text ='<%#Eval ("TravelDate") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Length" Visible ="false" >
                       <EditItemTemplate>
                                 <asp:TextBox ID ="txt_Length" runat ="server" Text ='<%#Eval ("Length") %>' Width ="30px" ></asp:TextBox>
                           </EditItemTemplate>
                             <ItemTemplate >
                                      <asp:Label ID ="lbl_Length" Text ='<%#Eval ("Length") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" Visible ="false" >
                               <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Breadth" runat ="server" Text ='<%#Eval ("Width") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Breadth" Text ='<%#Eval ("Width") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" Visible ="false" >
                              <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Height" runat ="server" Text ='<%#Eval ("Height") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_Height" Text ='<%#Eval ("Height") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Weight" Visible ="false" >
                              <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Weight" runat ="server" Text ='<%#Eval ("Weight") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_Weight" Text ='<%#Eval ("Weight") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="ProductCode" Visible ="false" >
                               <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Code" runat ="server" Text ='<%#Eval ("ProductCode") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Code" Text ='<%#Eval ("ProductCode") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText ="Product "  >
                              <ItemTemplate >
                                  <asp:Label ID ="lbl_Product" Text ='<%#Eval ("ProductName") %>'  runat ="server" ></asp:Label>
                             </ItemTemplate>
                                <FooterTemplate>
                                 <center style ="padding-left :150px"><asp:Label ID="lbl_total" runat="server" Text ="Total :" /></center>
                                </FooterTemplate>
                         </asp:TemplateField>

                           <asp:TemplateField HeaderText ="NumberofCartons"  >
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_NumberofCartons" Text ='<%#Eval ("NumberofCartons") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                                <FooterTemplate>
                                 <asp:Label ID="lbl_NoofCartonsTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText ="Lot Size" >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_Lotsize" runat ="server" Text ='<%#Eval ("NumberofCartons") %>' Width ="45px"   ></asp:TextBox>
                             </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_Lotsize" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Total weight in KGS" >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_TotalWeight" runat ="server" Text ='<%#Eval ("TotalWeight") %>' Width ="45px"   ></asp:TextBox>
                             </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_TotalWeight" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText ="Total CFT" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_TotalCFT" runat ="server" ></asp:Label>
                             </ItemTemplate>
                                <FooterTemplate>
                                 <asp:Label ID="lbl_TotalCFTtotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="FeetConversion" Visible ="false" >
                              <EditItemTemplate>
                                  <asp:TextBox ID ="txt_FeetCon" runat ="server" Text ='<%#Eval ("FeetConversion") %>' Width ="30px"   ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FeetCon" Text ='<%#Eval ("FeetConversion") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Length" Visible ="false" >
                              
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_OPTLength" runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" Visible ="false" >
                             
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTBreadth" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" Visible ="false" >
                              
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTHeight" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="CFT" Visible ="false">
                              
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTCFT" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                          <asp:TemplateField HeaderText ="FTL " Visible ="false"  >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesFTL" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                               <FooterTemplate>
                                 <asp:Label ID="lbl_FtlTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText ="Taurus" Visible ="false"  >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesTaurus" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_TarusTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                       
                         <asp:TemplateField HeaderText ="32ft S/A " Visible ="false"  >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxes32ftsa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_32saTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText ="32ft M/A " Visible ="false"  >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxes32ftma" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_32MaTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Select Truck " >
                              <ItemTemplate >
                                  <asp:DropDownList ID="ddl_Truck" runat="server">
                                      <asp:ListItem>--Select--</asp:ListItem>
                                      <asp:ListItem>FTL</asp:ListItem>
                                      <asp:ListItem>Taurus</asp:ListItem>
                                      <asp:ListItem>32ftsa</asp:ListItem>
                                      <asp:ListItem>32ftma</asp:ListItem>
                                  </asp:DropDownList>
                                  </ItemTemplate>
                         </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText ="Actual Truck " >
                              <ItemTemplate >
                                  <asp:DropDownList ID="ddl_ActualTruck" runat="server">
                                      <asp:ListItem>--Select--</asp:ListItem>
                                      <asp:ListItem>FTL</asp:ListItem>
                                      <asp:ListItem>Taurus</asp:ListItem>
                                      <asp:ListItem>32ftsa</asp:ListItem>
                                      <asp:ListItem>32ftma</asp:ListItem>
                                  </asp:DropDownList>
                                  </ItemTemplate>
                         </asp:TemplateField>
                        
                         
                          <asp:TemplateField HeaderText ="Quantity" >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_Quantity" runat ="server"  Width ="45px"   ></asp:TextBox>
                             </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_Quantity" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                     </Columns>
        </asp:GridView>



                   <br />

                <asp:GridView ID="grd_VolumeAnalysis" runat="server" CellPadding="4" ShowFooter ="true"  AutoGenerateColumns ="false" Visible ="false" Caption ="Volume Analysis" 
                      ForeColor="#333333" GridLines="Both"  >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     <Columns >
                          <asp:TemplateField HeaderText ="FromLocation" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Fromlocation" Text ='<%#Eval ("FromLocation") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="ToLocation" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ToLocation" Text ='<%#Eval ("ToLocation") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="PlanNo" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_PlanNo" Text ='<%#Eval ("PlanNo") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Length" Visible ="false" >
                       <EditItemTemplate>
                                 <asp:TextBox ID ="txt_Length" runat ="server" Text ='<%#Eval ("Length") %>' Width ="30px" ></asp:TextBox>
                           </EditItemTemplate>
                             <ItemTemplate >
                                      <asp:Label ID ="lbl_Length" Text ='<%#Eval ("Length") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" Visible ="false" >
                               <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Breadth" runat ="server" Text ='<%#Eval ("Width") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Breadth" Text ='<%#Eval ("Width") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" Visible ="false" >
                              <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Height" runat ="server" Text ='<%#Eval ("Height") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_Height" Text ='<%#Eval ("Height") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Weight" Visible ="false" >
                              <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Weight" runat ="server" Text ='<%#Eval ("Weight") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_Weight" Text ='<%#Eval ("Weight") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="ProductCode" Visible ="false" >
                               <EditItemTemplate>
                                   <asp:TextBox ID ="txt_Code" runat ="server" Text ='<%#Eval ("ProductCode") %>' Width ="30px" ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Code" Text ='<%#Eval ("ProductCode") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText ="Product "  >
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_Product" Text ='<%#Eval ("ProductName") %>'  runat ="server" ></asp:Label>
                             </ItemTemplate>
                              <FooterTemplate>
                                 <center style ="padding-left :150px"><asp:Label ID="lbl_total" runat="server" Text ="Total :" /></center>
                                </FooterTemplate>
                         </asp:TemplateField>

                           <asp:TemplateField HeaderText ="TotalCartons"  >
                             <ItemTemplate >
                                  <asp:Label ID ="lbl_NumberofCartons" Text ='<%#Eval ("NumberofCartons") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                                 <FooterTemplate>
                                 <asp:Label ID="lbl_NoofCartonsTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="Total CFT" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_TotalCFT" runat ="server" ></asp:Label>
                             </ItemTemplate>
                                <FooterTemplate>
                                 <asp:Label ID="lbl_TotalCFTtotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="FeetConversion" Visible ="false" >
                              <EditItemTemplate>
                                  <asp:TextBox ID ="txt_FeetCon" runat ="server" Text ='<%#Eval ("FeetConversion") %>' Width ="30px"   ></asp:TextBox>
                                     </EditItemTemplate>
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FeetCon" Text ='<%#Eval ("FeetConversion") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Length" Visible ="false" >
                              
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_OPTLength" runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Breadth" Visible ="false" >
                             
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTBreadth" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Height" Visible ="false" >
                              
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTHeight" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="CFT" Visible ="false">
                              
                             <ItemTemplate >
                             <asp:Label ID ="lbl_OPTCFT" runat ="server" ></asp:Label>
                                 </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="FTL " >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxesFtl" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                               <FooterTemplate>
                                 <asp:Label ID="lbl_FtlTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Taurus " >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxesTaurus" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_TarusTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft S/A " >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxes32sa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_32saTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft M/A " >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_NoofBoxes32ma" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_32MaTotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                        
                      
                        
                        
                     </Columns>
        </asp:GridView>

            </td>
             <td>
   
            </td>
        </tr>
    </table>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

