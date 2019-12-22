<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="DespatchPlan.aspx.cs" Inherits="DespatchPlan" %>
<%--<%@ Register Src="~/UserControl/MenuBar.ascx" TagName="menu" TagPrefix="menu" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
  <style type="text/css">
table.gridtable {
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:Black;
	/*border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;*/

    
    -webkit-border-radius: 8px;
    -moz-border-radius: 8px;
    overflow:hidden;
    border-radius: 10px;
    -pie-background: linear-gradient(#ece9d8, #E5ECD8);   
    box-shadow: #666 0px 2px 3px;
    behavior: url(Include/PIE.htc);
    overflow: hidden;

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


        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :650px;
    height :500px;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        background:rgba(217, 211, 182, 0.30);
        /*background:rgba(248, 127, 10, 0.60);*/
    }
    .mapinnerdiv {
    margin:5px;
    padding:0;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        /*background:rgba(26, 154, 228, 0.87);*/
        background:rgb(255, 255, 255);
    }


        </style>
        
    <script language="javascript" type="text/javascript">
        //Calculation of Total Cost
        function calculation(evt) {

            var a = document.getElementById('<%=txtweight.ClientID%>').value;
    var b = document.getElementById('<%=txtqty.ClientID%>').value;
    var cal = (a * b);
    var netcal = cal;
    document.getElementById('<%=txtTotTons.ClientID%>').value = Math.round(netcal);
return false;
return true;
}
</script>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div style="margin-left:350px" >
       
				<div class="col-sm-8 col-sm-offset-2">
					<h2 class="title-one">Despatch Plan</h2>
					<!--<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>-->
				</div>

         </div>
                           
           <div style="margin-left:150px" >          
 
<table  cellpadding="0px" cellspacing="0px" align="left" >
        
        <tr>
            <td colspan="3" align="center">
                        &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;
                        </td>
        </tr>
        <tr><td align="center">
                                           
            &nbsp;</td></tr>
        <tr><td valign="top" colspan="2" align="left">
       
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  class="gridtable" >
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                                                                From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <br />
                                                                    <asp:DropDownList ID="ddl_From" runat="server" Width="169px">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate ="ddl_From" InitialValue ="0" runat="server" ErrorMessage="Select from location" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                     &nbsp;&nbsp;</td>
                                                                <td class="style3"  >
                                                                    &nbsp;&nbsp;To
                                                                    <br />
                                                                    <asp:DropDownList ID="ddl_To" runat="server" Width="169px">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate ="ddl_To" InitialValue ="0" runat="server" ErrorMessage="Select to location" ForeColor="Red"></asp:RequiredFieldValidator>


                                                                <br />


                                                                  </td>
                                                                <td class="style3">
                                                                    Despatch Plan No<br />
                                                                    <asp:TextBox ID="txtPlanNo" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Enabled="false"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style2" >
                                                        <asp:Label ID="lbl_ProductCode" runat="server" Font-Bold="true" Text="Product Code"  ></asp:Label>
                                                        &nbsp;
                                                                    <br />
                                                        <asp:DropDownList ID="ddl_ProductCode" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddl_ProductCode_SelectedIndexChanged" Width="150px">
                                                        </asp:DropDownList>
                                                                    &nbsp;&nbsp;</td>
                                                                <td class="style3"  >
                                                                    <asp:Label ID="lblConfirm" runat="server" Text="Product" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                    <asp:DropDownList ID="ddlProduct" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddlProduct_SelectedIndexChanged" 
                            >
                        </asp:DropDownList>
                                                                    
                                                                  </td>
                                                                <td class="style3">
                                                        Total KGs Plan to Despatch <br />
                                                        <asp:TextBox ID="txtTotTons" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                  <asp:RequiredFieldValidator ID="rfv_TotalKgs" ControlToValidate ="txtTotTons" BorderStyle ="None" BorderWidth ="0" runat="server" ErrorMessage="Enter total kgs" ForeColor="Red"></asp:RequiredFieldValidator>   
                                                                    &nbsp;&nbsp;&nbsp;<br />
                                                                    
</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style2" >
                                                                   No of Carton Box<br />
                                                                    <asp:TextBox ID="txtqty" runat="server"  BorderColor="Black" onkeyup="return calculation(event)"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="rfv_Cartonbox" ControlToValidate ="txtqty" runat="server" ErrorMessage="Enter no of carton box" ForeColor="Red"></asp:RequiredFieldValidator>


                                                                  </td>
                                                                <td class="style3"  >
                                                                    Quantity<br />
                                                                    <asp:TextBox ID="txtnoofqty" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfv_Quantity" ControlToValidate ="txtnoofqty" runat="server" ErrorMessage="Enter quantity" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    
                                                                  </td>
                                                                <td class="style3">
                                                                    Stock Keeping Unit
                                                                    <br />
                                                                    <asp:TextBox ID="txtSKU" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"  ></asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="rfv_Stockunit" ControlToValidate ="txtSKU" runat="server" ErrorMessage="Enter stock keeping unit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    
</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    <span >Despatch Date</span><br />  
                                                                    <asp:TextBox ID="txtdate" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" Width="111px"></asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="rfv_Traveldate" ControlToValidate ="txtdate" runat="server" ErrorMessage="Enter travel date" ForeColor="Red"></asp:RequiredFieldValidator>


                                                                       <%-- <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/cal.gif" Width="16px" 
                />           <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                    PopupButtonID="imgdate1" TargetControlID="txtdate">                
    </ajaxtoolkit:calendarextender>                                    --%>                                

                                                                     </td>
                                                                <td class="style3">
                                                                                                                                        Weight per Carton<br />
                                                                    <asp:TextBox ID="txtweight" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate ="txtweight" runat="server" ErrorMessage="Enter weignt per carton" ForeColor="Red"></asp:RequiredFieldValidator>


                                                                    </span>


                                                                     </td>
                                                               <td class="style3">
                                                                    &nbsp;
                                                                    <asp:Button ID="ButAdd" runat="server" Text="Add" onclick="ButAdd_Click" 
                                                                        style="height: 26px" />


                                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                             
                                                                    <asp:Button ID="btn_Analysis" runat="server" ValidationGroup ="abc" Text="Analysis" OnClick ="btn_Analysis_Click" />
                                                                    <br />
                                                                    <br />
                                                                    <asp:Button ID="btnexport" runat="server" Text="Export To Excel" Width="106px" ValidationGroup="C"
                                              style="height: 26px" OnClick="btnexport_Click" />    
                                                                    

                                                                     <br />
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3" colspan="3">
                                                                    <asp:GridView ID="GridViewPlan" runat="server">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Check">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Check") %>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="Check" runat="server" Checked="True" Text=" " />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <br />
                                                                    <asp:GridView ID="GridMail" runat="server" ForeColor="#333333" Visible="False" 
                                                                        AutoGenerateColumns="False" CellPadding="4" GridLines="None">
                                                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                                    <Columns>
                                                                    <asp:BoundField HeaderText="PlanNo" DataField="PlanNo"/>
                                                                    <asp:BoundField HeaderText="Product" DataField="ProductName" />
                                                                    <asp:BoundField HeaderText="SKU" DataField="SKU"/>
                                                                    <asp:BoundField HeaderText="TravelDate" DataField="TravelDate"/>
                                                                    <asp:BoundField HeaderText="Weight of Carton" DataField="TotalWeightinTons"/>
                                                                    <asp:BoundField HeaderText="From" DataField="FromLocation"/>
                                                                    <asp:BoundField HeaderText="To" DataField="ToLocation"/>
                                                                    <asp:BoundField HeaderText="No of Cartons" DataField="NumberofCartons"/>
                                                                    <asp:BoundField HeaderText="Qty" DataField="Quantity"/>
                                                                    <asp:BoundField HeaderText="Total Weight" DataField="TotalWeight"/>
                                                                    </Columns>
                                                                    
                                                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    
                                                                    </asp:GridView>
                                                                     <asp:Button ID="ButSubmit" runat="server" Text="Submit" Enabled="False" 
                                                                        onclick="ButSubmit_Click" />
                                                                     <asp:Label ID="lbltotalton" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                                        Font-Size="12pt" ForeColor="Red" Text="Total Tons :"></asp:Label>
                                                                    <asp:Label ID="lblton" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                                        Font-Size="12pt" ForeColor="Red" Text="0"></asp:Label>
                                                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID ="lbl_Boxes" Text ="Total Boxes :" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" ForeColor="Red" runat ="server" ></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_TotalBoxes" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" ForeColor="Red" Text="0"></asp:Label>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                    
                                                                    <br />
                                                                     
                                                                    
                                                                     </td>
                                                            </tr>
                                                           
                                                            </table>
                                                    </td>
                                                </tr>
               
    </table>

             <asp:GridView ID="grd_ExportToexcel" runat="server"  
        BorderColor="#99CC00" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
        ForeColor="#333333" GridLines="Both"  >
        <RowStyle BackColor="White" />
        </asp:GridView> 
    
    </table>
                
        </div>

  
  <br /><br /><br />  <br /><br /><br />  <br /><br /><br />  
</asp:Content>


