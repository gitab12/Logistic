<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="OptDispatchPlan.aspx.cs" Inherits="OptDispatchPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:320px">
 Select  From Location : <asp:DropDownList ID="ddl_FromLocation" runat="server" Width="120px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_FromLocation_SelectedIndexChanged" >
                                </asp:DropDownList>
        <br />
        <br />
                                 GTNNo :    <asp:DropDownList ID="ddl_GTNNo" runat="server" Width="120px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_GTNN0_SelectedIndexChanged" >
                                </asp:DropDownList> &nbsp;  <asp:Button ID ="btn_Search" Text ="Search" runat ="server" OnClick="btn_Search_Click"  Class="btn btn-primary"/>
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Optimization" runat="server" OnClick="btn_Optimization_Click" Text="Optimization" Class="btn btn-primary"/>
                                 &nbsp;&nbsp; <asp:Button ID="btn_Summary" runat="server" Text="Summary" OnClick="btn_Summary_Click" Class="btn btn-primary"/>
     &nbsp;&nbsp; 
    <asp:Button ID="Button1" runat="server" Text="DownloadToExcel" onclick="Button1_Click"  Class="btn btn-primary"/>
                            <br />
    <br />
  
   <asp:Label ID="lbl_FromLocName" runat="server" Text="From Location :" visible ="false"></asp:Label>
&nbsp;<asp:Label ID="lbl_FromLoc" runat="server" Text="Label" visible ="false" ForeColor="red"></asp:Label>
&nbsp;
                                 <asp:Label ID="lbl_ToLocName" runat="server" Text="To Location :" visible ="false"></asp:Label>
&nbsp;<asp:Label ID="lbl_ToLoc" runat="server" Text="Label" visible ="false" ForeColor="red"  ></asp:Label>
                                 <br />
                                 <asp:RadioButton ID="rdb_WeightCon" runat="server" GroupName ="aarms" Checked ="true" Text ="Weight Constraint"  />&nbsp; 
    <asp:RadioButton ID="rdb_SpaceCon" runat="server" GroupName ="aarms" Text ="Space Constraint"  /> <br />
        </div>
 <div style="margin-left:20px"> 
    <asp:GridView ID="grd_DispatchPlan" runat="server" CellPadding="4"  ForeColor="#333333" GridLines="Both" >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     
        </asp:GridView>
         <br />
    <asp:GridView ID="grd_Analysis" runat="server" CellPadding="4"  ForeColor="#333333"  EnableModelValidation="True" >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:GridView>
   
   
                                 <br />
    <br />
    <asp:GridView ID="grd_Optimization" runat="server" CellPadding="4" AutoGenerateColumns ="false" ShowFooter ="true"
         Caption ="Weight Constraint"   ForeColor="#333333" GridLines="Both"  >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     <Columns >
                          <asp:TemplateField HeaderText ="GTNNo" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ParentCode" Text ='<%#Eval ("GTNNo") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Invoiceno" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ParentDesc" Text ='<%#Eval ("InvoiceNo") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Plantname" Visible ="false" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Plantname" Text ='<%#Eval ("PlantName") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="RecplantCode" Visible ="false" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Recplantcode" Text ='<%#Eval ("ReceivingPlantCode") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="RecPlantname" Visible ="false"  >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Recplantname" Text ='<%#Eval ("ReceivingPlantName") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Materialcode" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Materialcode" Text ='<%#Eval ("MaterialCode") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="MaterialDesc" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Materialdesc" Text ='<%#Eval ("MaterialDescription") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_total" runat="server" Text ="Total :" />
                                </FooterTemplate>
                         </asp:TemplateField>

 <asp:TemplateField HeaderText ="Quantity" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Quantity" Text ='<%#Eval ("DispatchQuantity") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_TotalQty" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="DespatchWeight" >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_Weight" runat ="server" Text ='<%#Eval ("Weight") %>' Width ="40px"   ></asp:TextBox>
                             </ItemTemplate>
                             
                         </asp:TemplateField>
                          <asp:TemplateField HeaderText ="Total Weight" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_TotalWeight"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                                <FooterTemplate>
                                 <asp:Label ID="lbl_TotWeight" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In FTL" Visible ="false">
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesFTL" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In Taurus"  Visible ="false">
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesTaurus" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In 32ft S/A" Visible ="false" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxes32ftsa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In 32ft M/A" Visible ="false" >
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
                         <asp:TemplateField HeaderText ="FTL Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FTLCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_FTLtotal" runat="server" />
                                </FooterTemplate>
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
                         <asp:TemplateField HeaderText ="Taurus Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_TaurusCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_Taurustotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft S/A Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_32ftsa" runat ="server" Text ="32ft S/A Cost per Box"></asp:Label><br /><br />
                                 <asp:TextBox ID="txt_32ftsa" runat ="server" Width="40px"  ></asp:TextBox>
                             </HeaderTemplate>
                             <ItemTemplate >
                              <asp:Label ID ="lbl_Costfor32ftsa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                                  
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft S/A Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FT32saCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_FT32satotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft M/A Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_32ftma" runat ="server" Text ="32ft M/A Cost per Box"></asp:Label><br /><br />
                                 <asp:TextBox ID="txt_32ftma" runat ="server" Width="40px" ></asp:TextBox>
                             </HeaderTemplate>
                             <ItemTemplate >
                              <asp:Label ID ="lbl_Costfor32ftma" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                                  
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft M/A Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FT32maCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_FT32matotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                     </Columns>
        </asp:GridView>
        
        <br />
    <asp:GridView ID="grd_SpaceConstraint" runat="server" CellPadding="4" AutoGenerateColumns ="false" ShowFooter ="true" Caption ="Space Constraint"
                      ForeColor="#333333" GridLines="Both"  >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     <Columns >
                          <asp:TemplateField HeaderText ="GTNNo" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ParentCode" Text ='<%#Eval ("GTNNo") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Invoiceno" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_ParentDesc" Text ='<%#Eval ("InvoiceNo") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Plantname" Visible ="false" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Plantname" Text ='<%#Eval ("PlantName") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="RecplantCode" Visible ="false" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Recplantcode" Text ='<%#Eval ("ReceivingPlantCode") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="RecPlantname" Visible ="false"  >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Recplantname" Text ='<%#Eval ("ReceivingPlantName") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Materialcode" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Materialcode" Text ='<%#Eval ("MaterialCode") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="MaterialDesc" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Materialdesc" Text ='<%#Eval ("MaterialDescription") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<right><asp:Label ID="lbl_total" runat="server" Text ="Total :" /></right>
                                </FooterTemplate>
                         </asp:TemplateField>

 <asp:TemplateField HeaderText ="Quantity" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_Quantity" Text ='<%#Eval ("DispatchQuantity") %>' runat ="server" ></asp:Label>
                             </ItemTemplate>
     <FooterTemplate>
                                 <asp:Label ID="lbl_TotalQty" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText ="DespatchWeight" Visible ="false"  >
                             <ItemTemplate >
                                 <asp:TextBox ID ="txt_Weight" runat ="server" Text ='<%#Eval ("Weight") %>' Width ="40px"   ></asp:TextBox>
                             </ItemTemplate>
                             
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Total Weight" Visible ="false" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_TotalWeight"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                                <FooterTemplate>
                                 <asp:Label ID="lbl_TotWeight" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In FTL" Visible ="false">
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesFTL" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In Taurus"  Visible ="false">
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxesTaurus" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In 32ft S/A" Visible ="false" >
                              <ItemTemplate >
                              <asp:Label ID ="lbl_LoadBoxes32ftsa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Loading Boxes With Weight Constrain In 32ft M/A" Visible ="false" >
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
                         <asp:TemplateField HeaderText ="FTL Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FTLCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_FTLtotal" runat="server" />
                                </FooterTemplate>
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
                         <asp:TemplateField HeaderText ="Taurus Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_TaurusCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbl_Taurustotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft S/A Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_32ftsa" runat ="server" Text ="32ft S/A Cost per Box"></asp:Label><br /><br />
                                 <asp:TextBox ID="txt_32ftsa" runat ="server" Width="40px"  ></asp:TextBox>
                             </HeaderTemplate>
                             <ItemTemplate >
                              <asp:Label ID ="lbl_Costfor32ftsa" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                                 
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft S/A Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FT32saCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_FT32satotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft M/A Cost per Box" >
                             <HeaderTemplate>
                                 <asp:Label ID="lbl_32ftma" runat ="server" Text ="32ft M/A Cost per Box"></asp:Label><br /><br />
                                 <asp:TextBox ID="txt_32ftma" runat ="server" Width="40px" ></asp:TextBox>
                             </HeaderTemplate>
                             <ItemTemplate >
                              <asp:Label ID ="lbl_Costfor32ftma" runat ="server" ></asp:Label>
                                  </ItemTemplate>
                                 
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText ="32ft M/A Cost" >
                             <ItemTemplate >
                                 <asp:Label ID ="lbl_FT32maCost"  runat ="server" ></asp:Label>
                             </ItemTemplate>
                              <FooterTemplate>
                                 <asp:Label ID="lbl_FT32matotal" runat="server" />
                                </FooterTemplate>
                         </asp:TemplateField>
                     </Columns>
        </asp:GridView>

        
         <asp:HiddenField ID ="FTLTruckCost" runat ="server" />
    <asp:HiddenField ID ="TaurusTruckCost" runat ="server" />
    <asp:HiddenField ID ="Ft32SaTruckCost" runat ="server" />
    <asp:HiddenField ID ="Ft32MaTruckCost" runat ="server" />
    </div>
    <br /><br /><br />
</asp:Content>

