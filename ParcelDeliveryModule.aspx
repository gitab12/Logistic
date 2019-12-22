<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ParcelDeliveryModule.aspx.cs" Inherits="ParcelDeliveryModule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

    <style type="text/css">
        .auto-style1 {
            width: 56%;
        }
        .auto-style2 {
            width: 280px;
        }
        .auto-style3 {
            width: 146px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br /><br /><br /><br /><br />
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div style="margin-left:150px"> 
    <table class="auto-style1">
        <tr>
            <td class="auto-style2"  >From</td>
            <td class="auto-style3">To</td>
            <td>Transporter</td>
            <td >
              <asp:Button ID="butGetDetails" runat="server" Text="Get Details" OnClick="butGetDetails_Click"  Class="btn btn-primary"/>
                </td>
                <td style="width:500px;text-align:right">
               <asp:Button ID="butcal" runat="server" Text="Calculate" OnClick="butcal_Click" Class="btn btn-primary" />  
                     
            </td>
            
        </tr>
        <tr>
            <br />  
            <td class="auto-style2">
                <asp:DropDownList ID="DDLFrom" runat="server" Height="18px" Width="218px">
                </asp:DropDownList>
            </td>
            <td class="auto-style3">
                <asp:DropDownList ID="DDLTo" runat="server" Height="18px" Width="218px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DDLTransporter" runat="server" Height="18px" Width="218px" OnSelectedIndexChanged="DDLTransporter_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList> <br /> 
            </td>
            <td>&nbsp;<br /> &nbsp;&nbsp; 
                <asp:Button ID="butsave" runat="server" Text="Save" Enabled="false" OnClick="butsave_Click"  Class="btn btn-primary" /> <br />
                &nbsp;
             <br />
                &nbsp;<asp:Button ID="btn_View" runat="server" OnClick="btn_View_Click" Text="View"  Class="btn btn-primary"/>
               
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
    Bill No<br />
    <asp:TextBox ID="txtBillNo" runat="server" ></asp:TextBox>
    </td>
            <td class="auto-style3">
                 
                Bill Date<br />
                
                <asp:TextBox ID="txtBillDate" runat="server" ></asp:TextBox>
                <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" 
                />
                 <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtBillDate">                
    </ajaxtoolkit:calendarextender>

            </td>
            <td>
               
                </td>
            <td>
               
                 
            </td>
           
        </tr>
    </table>
         </div>
   <br />

   <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" 
             Caption="Select the Check box and Quantity and Weight " Style="margin-left:50px" >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              <Columns>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select"
                        AutoPostBack="True" Enabled="false" />
                    </HeaderTemplate>
                    <ItemTemplate>
                   <asp:CheckBox ID="ChkSelect" Width="16px" runat="server" Height="18px" 
                            oncheckedchanged="ChkSelect_CheckedChanged"  AutoPostBack="True" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Agreement RouteNo" Visible="false" >
                      <ItemTemplate>
                        
                           <asp:Label ID="lblTransID" runat="server" Text='<%# Bind("rid") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                        
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="From Location">
                      <ItemTemplate>
                          <asp:Label ID="lblFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="To Location">
                      <ItemTemplate>
                          <asp:Label ID="lbltoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txttoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Transporter">
                      <ItemTemplate>
                          <asp:Label ID="lblTransporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTransporter" runat="server" Text='<%# Bind("Transporter") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Rate/KG/KM">
                      <ItemTemplate>
                          <asp:Label ID="lblRateperKG" runat="server" Text='<%# Bind("RateperKG") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtRateperKG" runat="server" Text='<%# Bind("RateperKG") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
            <asp:TemplateField HeaderText="KM">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("KM") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtkm" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="true" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="LR Number">
                      <ItemTemplate>
                          <br />
                          <asp:TextBox ID="txtLRNumber" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true"  Width="53px"  BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red" ></asp:TextBox>
                      </ItemTemplate>
                      <EditItemTemplate>
                        
                           <asp:Label ID="lblLRNo" runat="server"  ></asp:Label>
                      </EditItemTemplate>
                  </asp:TemplateField>





                    <asp:TemplateField HeaderText="LR Date">
                      <ItemTemplate>
                          <br />
                          <asp:TextBox ID="txtLRdate" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true"  Width="53px"  BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red" ></asp:TextBox>
                      </ItemTemplate>
                      <EditItemTemplate>
                        
                           <asp:Label ID="lblLRdate" runat="server"  ></asp:Label>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Weight">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtweight" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Quantity">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                      <br />
                          <asp:TextBox ID="txtqty" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true"  Width="53px"  BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red" ></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="InvoiceValue">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtinvvalue" runat="server" BorderStyle="Solid"  text="0"
                              BorderWidth="1px" Enabled="True" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
<asp:TemplateField HeaderText="Transporter Basic Freight(A)">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtbasic" runat="server" Text='<%# Bind("basic") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtTbasic" runat="server" BorderStyle="Solid" Text="0"
                              BorderWidth="1px" Enabled="True" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Transporter's OtherCharges (B)">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtTOtherCharges" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true" Height="22px" Width="63px" BorderColor="Black" Text="0"
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                   

                  
                  <asp:TemplateField HeaderText="Basic Freight">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtbasice" runat="server" Text='<%# Bind("basic") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtbasic" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="FSV in %">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("FSV") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                            <asp:Label ID="lblFsv" runat="server" Text='<%# Bind("fsc") %>'></asp:Label>
                          <asp:TextBox ID="txtfsv" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>

                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="DHC in %">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("dhc") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                           <asp:Label ID="lbldhc" runat="server" Text='<%# Bind("dhc") %>'></asp:Label>
                          <asp:TextBox ID="txtdhc" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                   

                   <asp:TemplateField HeaderText="VSC in %">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("vsc") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                           <asp:Label ID="lblvsc" runat="server" Text='<%# Bind("vsc") %>'></asp:Label>
                          <asp:TextBox ID="txtvsc" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>



                  <asp:TemplateField HeaderText="Door Delivery Charges">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DoorDeliverycharges") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtddcharges" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>


                  <asp:TemplateField HeaderText="Handling Charges">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("handlingcharges") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txthandlingcharges" runat="server" BorderStyle="Solid" 
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
    <asp:TemplateField HeaderText="LR Charges">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("LRCharges") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtLRcharges" runat="server" BorderStyle="Solid" Text='<%# Bind("LRCharges") %>'
                              BorderWidth="1px" Enabled="False" EnableTheming="True" Width="53px" 
                              BorderColor="Black" Font-Bold="True" Font-Names="Arial" ForeColor="Red" onkeypress="return onlynumber(event)"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Total">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtTotal" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true" Height="22px" Width="63px" BorderColor="Black" Text="0"
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>

<asp:TemplateField HeaderText="TransporterTotal(A+B)">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <br />
                          <asp:TextBox ID="txtTTotal" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                              Enabled="true" Height="22px" Width="63px" BorderColor="Black" 
                              Font-Bold="True" Font-Names="Arial" ForeColor="Red"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>


              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
       

<asp:GridView ID="grd_BillEntry" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="90%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="True" Style="margin-left:50px">
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
   
     <br /><br /><br /><br /><br /><br />

</asp:Content>

