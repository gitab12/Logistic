<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="Parcel_Part.aspx.cs" Inherits="Parcel_Part" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>


<asp:Content ID="Content_Head" ContentPlaceHolderID="head" Runat="Server">
     <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
     <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            |Supply Demand Matching|Trucks Available | Trucks Wanted | Goods Transport |
            Logistics </title>

   
     
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">
        
    
    
    <script type="text/javascript">
        function CheckForPastDate(sender, args) {
            var selectedDate = new Date();
            selectedDate = sender._selectedDate;
            var todayDate = new Date();
            if (selectedDate.getDateOnly() < todayDate.getDateOnly()) {
                sender._selectedDate = todayDate;
                sender._textbox.set_Value(sender._selectedDate.format(sender._format));
                alert("You cannot select a day earlier than today!");
            }

        }
</script>
    
    
 

</asp:Content>

<asp:Content ID="Content_Body" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <br />
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <br />
        <div class="row text-center clearfix">
		<table width="70%">
       <tr>
       <td>
        Travel Date: <asp:TextBox ID="txt_traveldate" runat="server"  Width="100px"></asp:TextBox>
          
            <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px"  />
            <ajaxtoolkit:calendarextender ID="CalendarExtender1"  runat="server"  PopupButtonID="imgdate1" TargetControlID="txt_traveldate" OnClientDateSelectionChanged="CheckForPastDate"></ajaxtoolkit:calendarextender><br />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_traveldate" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter Date!"></asp:RequiredFieldValidator><br />

           <asp:RadioButton ID="radsingle" runat="server" Text="SinglePosting"  Checked="true" GroupName="a" AutoPostBack="true"  oncheckedchanged="radsingle_CheckedChanged"/>&nbsp;&nbsp;
           <asp:RadioButton ID="radmultiple" runat="server" Text="MultiplePosting" AutoPostBack="true" GroupName="a" OnCheckedChanged="radmultiple_CheckedChanged" />
          
          
    <div class="container master-container" style=" padding-top: 66px;margin-left: 146px; ">
        <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
   <%-- <ul class="breadcrumb">
       
    </ul>--%>



   <div class="panel panel-primary" >
    <div class="panel-heading">Parcel Details</div>
    <div class="panel-body">
       
        
  <div class="col-lg-12"> 
      <div class="panel-body">
        <div class="form-horizontal" role="form">
  
         <div class="col-md-6" >
            <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>From :</label>
                <div class="col-lg-9">     
                    <%--<input id="autocomplete" name="autocomplete"  type="text"  class="form-control" placeholder="Source*" />--%>
                    <asp:TextBox ID="txt_source" runat="server" placeholder="Enter Source" class="form-control"></asp:TextBox>
                </div>
                </div></div>
             <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>Pick Up:</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtpick" runat="server" placeholder="Enter PickUp" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpick" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter PickUp!"></asp:RequiredFieldValidator>


                </div>
                    </div>
                </div>
             </div>
          <div class="form-horizontal" role="form">
              <div class="col-md-6" >
            <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label"><span style="color:red;">*</span>To:</label>
                <div class="col-lg-9">
                    <%--<input id="autocomplete1" name="autocomplete1"  type="text"  class="form-control validate[required]" placeholder="Destination*" />--%>
                    <asp:textbox id="txt_dest" runat="server" placeholder="enter destination" class="form-control validate[required]"></asp:textbox>
                </div>
                </div></div>
          <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">City:</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtcity" runat="server" placeholder="Enter City" class="form-control validate[required]"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcity" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter City!"></asp:RequiredFieldValidator>
                </div>
                    </div>
                </div></div>
          <div class="form-horizontal" role="form">
                  
            <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">Delivery Type:</label>
                <div class="col-lg-9">
                    <asp:DropDownList ID="ddl_type" runat="server"  class="form-control" >
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Door Delivery</asp:ListItem>
                        <asp:ListItem Value="2">Door Delivery against consignee copy</asp:ListItem>
                        <asp:ListItem Value="3">Door Delivery against COD</asp:ListItem>
                        <asp:ListItem Value="4">Godown Delivery</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0" ControlToValidate="ddl_type" ValidationGroup="NewValidationGroup" ErrorMessage="Please select Type!"></asp:RequiredFieldValidator>
                 
                    
                </div></div></div>
            <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">No. Of Units:</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtunits" runat="server" placeholder="Enter Units" class="form-control validate[required]"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtunits" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter Units!"></asp:RequiredFieldValidator>
                </div>
                    </div>
                </div>
                  </div>
          <div class="form-horizontal" role="form">
             <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">Packing Type:</label>
                <div class="col-lg-9">
                    <asp:DropDownList ID="ddlpacktype" runat="server"  class="form-control validate[required]" >
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                        <asp:ListItem Value="Loose">Loose</asp:ListItem>
                        <asp:ListItem Value="Gunny Bundles">Gunny Bundles</asp:ListItem>
                        <asp:ListItem Value="Poly Bags">Poly Bags</asp:ListItem>
                        <asp:ListItem Value="Cone Bundles">Cone Bundles</asp:ListItem>
                        <asp:ListItem Value="Carton Boxes">Carton Boxes</asp:ListItem>
                        <asp:ListItem Value="Wooden Boxes">Wooden Boxes</asp:ListItem>
                        <asp:ListItem Value="Wooden Crates">Wooden Crates</asp:ListItem>
                        <asp:ListItem Value="Steel Barrels">Steel Barrels</asp:ListItem>
                        <asp:ListItem Value="Plastic Barrels">Plastic Barrels</asp:ListItem>
                        <asp:ListItem Value="Carbouys">Carbouys</asp:ListItem>
                        <asp:ListItem Value="Shrink Wrapped">Shrink Wrapped</asp:ListItem>
                        <asp:ListItem Value="Wooden Pallets">Wooden Pallets</asp:ListItem>
                        <asp:ListItem Value="Plastic Pallets">Plastic Pallets</asp:ListItem>
                        <asp:ListItem Value="Otherss">Others</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  runat="server" ControlToValidate="ddlpacktype" ValidationGroup="NewValidationGroup" ErrorMessage="Please enter Packing Type!"></asp:RequiredFieldValidator>
                    
                </div>
                    </div>
                 </div>
          
            <div class="col-md-6">
                <div class="form-group">
                <label for="inputcmp" class="col-sm-4 control-label">Size(in Ft.):</label>
                    <div class="col-lg-2">
                    <asp:TextBox ID="txtlen" runat="server" placeholder="L" class="form-control validate[required]"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtlen" ValidationGroup="NewValidationGroup" ErrorMessage="Length*"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-lg-2">
                    <asp:TextBox ID="txtbdth" runat="server" placeholder="B" class="form-control validate[required]"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbdth" ValidationGroup="NewValidationGroup" ErrorMessage="Breadth*"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-lg-2">
                    <asp:TextBox ID="txtwth" runat="server" placeholder="H" class="form-control validate[required]"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtwth" ValidationGroup="NewValidationGroup" ErrorMessage="Width*"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-lg-2">
                    <asp:TextBox ID="txtwt" runat="server" placeholder="Wt" class="form-control validate[required]"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtwt" ValidationGroup="NewValidationGroup" ErrorMessage="Weight*"></asp:RequiredFieldValidator>
                </div>
                    
                 <%-- <asp:Panel ID="pnlTextBoxes" runat="server">
                    </asp:Panel>
                    <hr />
                    <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="AddTextBox" />
                    <asp:Button ID="btnGet" runat="server" Text="Get Values" OnClick="GetTextBoxValues" />
                --%>
                  <button type="button" class="btn btn-info btn-sm"  id="btn_moresize" >
                     <span class="glyphicon glyphicon-plus"></span> Add More Size
                 </button>
                  <button type="button" class="btn btn-info btn-sm" id="btn_removesize" >
                      <span class="glyphicon glyphicon-minus"></span> Remove Size
                  </button>
                </div>
                <div class="form-group" id="moresize">
                <label for="inputcmp" class="col-sm-4 control-label"></label>
                    <div class="col-lg-2">
                    L<asp:TextBox ID="txt_L1" runat="server" placeholder="L" class="form-control">0</asp:TextBox>
                    
                </div>
                    <div class="col-lg-2">
                    B<asp:TextBox ID="txt_B1" runat="server" placeholder="B" class="form-control">0</asp:TextBox>
                       
                </div>
                    <div class="col-lg-2">
                    H<asp:TextBox ID="txt_H1" runat="server" placeholder="H" class="form-control">0</asp:TextBox>
                       
                </div>
                    <div class="col-lg-2">
                    Wt<asp:TextBox ID="txt_wt1" runat="server" placeholder="Wt" class="form-control">0</asp:TextBox>
                        
                </div>
                    
                 <%-- <asp:Panel ID="pnlTextBoxes" runat="server">
                    </asp:Panel>
                    <hr />
                    <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="AddTextBox" />
                    <asp:Button ID="btnGet" runat="server" Text="Get Values" OnClick="GetTextBoxValues" />
                --%>
                 
                </div>
                </div></div>
          <div class="form-horizontal" role="form">
           <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">Bid Start Time:</label>
                   
                       
                <div class="col-lg-3">
                    <asp:DropDownList ID="ddl_hours" runat="server"  class="form-control validate[required]" >
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </div>
                     <div class="col-lg-3">
                    <asp:DropDownList ID="ddl_minutes" runat="server"  class="form-control validate[required]" >
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    </asp:DropDownList>

                </div>
                    <div class="col-lg-3">
                    <asp:DropDownList ID="ddl_am_pm" runat="server"  class="form-control validate[required]" >
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                 </div>
            </div>

       <div class="col-md-6" >
        <div class="form-group">
               <label for="inputcmp" class="col-sm-3 control-label">Cut Off Time:</label>
            
                <div class="col-lg-3">
                    <asp:DropDownList ID="ddlhours" runat="server"  class="form-control validate[required]" >
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </div>
                     <div class="col-lg-3">
                    <asp:DropDownList ID="ddlminutes" runat="server"  class="form-control validate[required]" >
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    </asp:DropDownList>

                </div>
            <div class="col-lg-3">
                    <asp:DropDownList ID="ddlampm" runat="server"  class="form-control validate[required]" >
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                 </div>
            </div></div>
          <div class="form-horizontal" role="form">
            <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">Remarks:</label>
                     <div class="col-lg-9">
                    <asp:TextBox ID="txtrem" runat="server" row="1" TextMode="MultiLine" Width="200px" MaxLength="140"  onKeyUp="javascript:Count(this);" onChange="javascript:Count(this);" ></asp:TextBox>
                    </div>
                    </div>
                    </div>

                
     
    
       <div class="col-md-6">
           <div class="col-lg-3">
                
                  <asp:Button ID="Btn_add" runat="server" Text="Add"  ValidationGroup="NewValidationGroup" onclick="Btn_add_click" class="btn btn-success center-block" />
               </div>
            <div class="col-lg-3">
                
                  <asp:Button ID="btn_submit" runat="server" Text="Submit"  ValidationGroup="NewValidationGroup"  class="btn btn-success center-block" OnClick="btn_submit_Click" />
               </div>

           </div>

       </div>
        </div>
      </div>
        </div>
            </div>        
   <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCQOxByRV0s-YkzRerTMsQgU1HHRdnk6mU&libraries=places&callback=initAutocomplete"async defer></script>
     
        
        <br />
        <div>

            <%--<asp:GridView ID="gv_parceldetails" runat="server"></asp:GridView>--%>
            <asp:GridView ID="gv_parceldetails" runat="server" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" 
         Width="80%" AutoGenerateColumns="False">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
    <asp:TemplateField HeaderText="All">
         <HeaderTemplate>
                    <asp:CheckBox ID="checkAll" runat="server"  AutoPostBack="True" Checked="true" Text="All" oncheckedchanged="ChkAll_CheckedChanged" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server"  AutoPostBack="false" Checked="true" ForeColor="#CCFFCC" 
                         Text="." Width="25px"  />
                </ItemTemplate>                
               
            </asp:TemplateField>   
                     <asp:TemplateField HeaderText="From">
                        <ItemTemplate>
                            <asp:Label ID="lblfrom" runat="server" ForeColor="Black" 
                                Text='<%# Bind("source_from") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PickUp">
                        <ItemTemplate>
                            <asp:Label ID="lblpickup" runat="server" ForeColor="Black" Text='<%# Bind("source_pickup") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>

         <asp:TemplateField HeaderText="To">
                        <ItemTemplate>
                            <asp:Label ID="lblTo" runat="server" ForeColor="Black" Text='<%# Bind("destination_to") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lblcity" runat="server" ForeColor="Black" Text='<%# Bind("destination_city") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DeliveryType">
                        <ItemTemplate>
                            <asp:Label ID="lbldeltype" runat="server" ForeColor="Black" Text='<%# Bind("delivery_type") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No.OfUnits">
                        <ItemTemplate>
                            <asp:Label ID="lblunits" runat="server" ForeColor="Black" Text='<%# Bind("no_of_units") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PackingType">
                        <ItemTemplate>
                            <asp:Label ID="lblpacktype" runat="server" ForeColor="Black" Text='<%# Bind("packing_type") %>' ></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size">
                        <ItemTemplate>
                            <asp:Label ID="lblsize" runat="server" ForeColor="Black" Text='<%# Bind("size") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>    
              <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblremarks" runat="server" ForeColor="Black" Text='<%# Bind("remarks") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>  
              <asp:TemplateField HeaderText="TravelDate">
                        <ItemTemplate>
                            <asp:Label ID="lbltraveldate" runat="server" ForeColor="Black" Text='<%# Bind("travel_date") %>'></asp:Label>
                        </ItemTemplate>
            </asp:TemplateField>        
            
    </Columns>
    
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
        </div>
 
</td>
</tr>
<tr align="center">
<td>
   
    <asp:Button ID="btnsubmit" runat="server"  Text="Submit"  class="btn btn-primary" OnClick="btnsubmit_Click"/>
</td>
</tr>
</table>
         <br /><br /><br /><br /><br />
                    </div>

        <script>
            $(document).ready(function () {
                $("#moresize").hide();
                $("#btn_moresize").hide();
                $("#<%=txt_L1.ClientID%>").val("0");
                $("#<%=txt_wt1.ClientID%>").val("0");
                $("#<%=txt_H1.ClientID%>").val("0");
                $("#<%=txt_B1.ClientID%>").val("0");
                $("#btn_removesize").hide();
                $("#btn_moresize").click(function () {
                    $("#moresize").show();
                    $("#btn_moresize").hide();
                    $("#btn_removesize").show();

                });

                $("#btn_removesize").click(function () {
                    $("#moresize").hide();
                    $("#btn_moresize").show();
                    $("#btn_removesize").hide();
                    $("#<%=txt_L1.ClientID%>").val("0");
                   $("#<%=txt_wt1.ClientID%>").val("0");
                   $("#<%=txt_H1.ClientID%>").val("0");
                   $("#<%=txt_B1.ClientID%>").val("0");
               });

           });
       </script>
   
      </asp:Content>