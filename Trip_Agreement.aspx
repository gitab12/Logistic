<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="Trip_Agreement.aspx.cs" Inherits="Trip_Agreement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
    <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <div class="container master-container" style="padding-top: 66px; margin-left: 100px;">
          <div class="panel panel-primary">
            <div class="panel-heading panel-heading-custom">
                        <div class="panel-title">
                           Trip Agreement
                        </div>
                    </div><br />
              <div class="row">
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-1 control-label"></label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                      <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                       <asp:DropDownList ID="ddl_client" runat="server"  class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_client_SelectedIndexChanged">
                                           <asp:ListItem>-Select Client-</asp:ListItem>
                                       </asp:DropDownList>
                                     
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-3">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-1 control-label"></label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                      <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>
                                       <asp:DropDownList ID="DDLClientAddrLoction" runat="server"  class="form-control" >
                                          

                                       </asp:DropDownList>
                                     
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-3">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-1 control-label"></label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                      <span class="input-group-addon"><i class="fa fa-truck"></i></span>
                                       <asp:DropDownList ID="DDLTransporter" runat="server" AutoPostBack="true"  class="form-control" OnSelectedIndexChanged="DDLTransporter_SelectedIndexChanged"
                                           ></asp:DropDownList>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-2">
                            <asp:LinkButton ID="btn_submit" runat="server" CssClass="btn btn-success pullright" OnClick="btn_submit_Click">Submit</asp:LinkButton>
                                 </div>
              </div><br />
              <div id="option" runat="server" class="row">
                   <div class="col-md-4"></div>
               <div class="col-md-7">
                <label class="btn btn-default"><asp:RadioButton ID="rdb_ftl" runat="server"  AutoPostBack="true" GroupName="A" Text="FTL" OnCheckedChanged="rdb_ftl_CheckedChanged"></asp:RadioButton></label>
                 <label class="btn btn-default"><asp:RadioButton ID="rdb_parcel" runat="server" GroupName="A" AutoPostBack="true" Text="Part/Parcel" OnCheckedChanged="rdb_parcel_CheckedChanged" ></asp:RadioButton></label>
                   <label class="btn btn-default"><asp:RadioButton ID="rdb_active" runat="server" GroupName="A" AutoPostBack="true" Text="Active Transporters" OnCheckedChanged="rdb_active_CheckedChanged" ></asp:RadioButton></label>
                 </div>
                <div class="col-md-1"></div>
                  

              </div><br /><br />
              <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
              <div id="div_ftl" runat="server" class="row">
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">From</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>
                                     <asp:TextBox ID="txt_ftlsource" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">To</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>
                                     <asp:TextBox ID="txt_ftlto" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Enclosure Type</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-briefcase"></i></span>
                                     <asp:DropDownList ID="DDLEnclType" runat="server"  class="form-control" ></asp:DropDownList>
                                      </div>
                                    </div>
                            </div>
                        </div><br />
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Truck Type</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="fa fa-truck"></i></span>
                                     <asp:DropDownList ID="DDLTruckType" runat="server"  class="form-control" ></asp:DropDownList>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">Capacity</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-briefcase"></i></span>
                                     <asp:TextBox ID="txt_capacity" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">Agreement Price</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="fa fa-inr"></i></span>
                                     <asp:TextBox ID="txt_agreement" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div><br />
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">Transit Days</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                     <asp:TextBox ID="txt_days" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">Email ID</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                     <asp:TextBox ID="txt_emailid" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                      <div class="col-md-6"></div>
                      <div class="col-md-1">
                        <div class="form-group ">
                            <asp:LinkButton ID="btn_add" runat="server" CssClass="btn btn-success" OnClick="btn_add_Click" ><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>&nbsp;&nbsp;Add</asp:LinkButton>
                            </div>
                          </div>
                        </div><br /><br />
                 
                  <div  class="col-md-12">  
                    <div class="table-responsive" >
                    <asp:GridView ID="gv_ftldetails" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"  >
                        <columns>
                             <asp:BoundField DataField="AgreementID" HeaderText="AgreementID" />
                             <asp:BoundField DataField="Client" HeaderText="Client" />
                             <asp:BoundField DataField="City" HeaderText="City" />
                             <asp:BoundField DataField="Transporter" HeaderText="Transporter" />
                             <asp:BoundField DataField="FromLocation" HeaderText="FromLocation" />
                            <asp:BoundField DataField="ToLocation" HeaderText="ToLocation" />
                             <asp:BoundField DataField="EnclosureType" HeaderText="EnclosureType" />
                             <asp:BoundField DataField="TruckType" HeaderText="TruckType" />
                             <asp:BoundField DataField="Capactiy" HeaderText="Capactiy" />
                             <asp:BoundField DataField="DecidedPrice" HeaderText="DecidedPrice" />
                            <asp:BoundField DataField="PostedDate" HeaderText="PostedDate" />

                            
                        </columns>
                    </asp:GridView>
                </div>
                    </div>
                      
                  
              </div><br />
              <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
              <div id="div_parcel" runat="server" class="row">
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">From</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>
                                     <asp:TextBox ID="txt_parcelsource" class="form-control" runat="server" data-validation="required" data-validation-error-msg=" "></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">To</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>
                                     <asp:TextBox ID="txt_partdest" class="form-control" runat="server" data-validation="required" data-validation-error-msg=" "></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Delivery Type</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-briefcase"></i></span>
                                     <asp:DropDownList ID="ddl_delv" runat="server"  class="form-control" >
                                         <asp:ListItem Value="">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Door Delivery</asp:ListItem>
                                        <asp:ListItem Value="2">Door Delivery against consignee copy</asp:ListItem>
                                        <asp:ListItem Value="3">Door Delivery against COD</asp:ListItem>
                                        <asp:ListItem Value="4">Godown Delivery</asp:ListItem>
                                     </asp:DropDownList>
                                      </div>
                                    </div>
                            </div>
                        </div><br />
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Packing Type</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="fa fa-gift"></i></span>
                                     <asp:DropDownList ID="ddl_packtype" runat="server"  class="form-control" >
                                         <asp:ListItem Value="">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Loose</asp:ListItem>
                                        <asp:ListItem Value="2">Gunny Bundles</asp:ListItem>
                                        <asp:ListItem Value="3">Poly Bags</asp:ListItem>
                                        <asp:ListItem Value="4">Cone Bundles</asp:ListItem>
                                        <asp:ListItem Value="5">Carton Boxes</asp:ListItem>
                                        <asp:ListItem Value="6">Wooden Boxes</asp:ListItem>
                                        <asp:ListItem Value="7">Wooden Crates</asp:ListItem>
                                        <asp:ListItem Value="8">Steel Barrels</asp:ListItem>
                                        <asp:ListItem Value="9">Plastic Barrels</asp:ListItem>
                                        <asp:ListItem Value="10">Carbouys</asp:ListItem>
                                        <asp:ListItem Value="11">Shrink Wrapped</asp:ListItem>
                                        <asp:ListItem Value="12">Wooden Pallets</asp:ListItem>
                                        <asp:ListItem Value="13">Plastic Pallets</asp:ListItem>
                                        <asp:ListItem Value="14">Others</asp:ListItem>
                                     </asp:DropDownList>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">No Of Units</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-briefcase"></i></span>
                                     <asp:TextBox ID="txt_units" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">Transit Days</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                     <asp:TextBox ID="txt_transitdays" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div><br />
                  <div class="col-md-4">
                      <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">Agreement Price(Per Kgs)</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="fa fa-inr"></i></span>
                                     <asp:TextBox ID="txt_partprice" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                      
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">Email ID</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                     <asp:TextBox ID="txt_partmail" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div>
                  <div class="col-md-4">
                        <div class="form-group">
                            <label for="lbl_from" class="col-md-3 control-label">CFT</label>
                                <div class="col-md-9"> 
                                    <div class="input-group">
                                     <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                     <asp:TextBox ID="txt_cft" class="form-control" runat="server" ></asp:TextBox>
                                      </div>
                                    </div>
                            </div>
                        </div><br /><br />
                  <div class="row">
                <div class="col-md-8"><br />

                    <div class="form-group">
                            <label for="inputcmp" class="col-sm-2 control-label">Size(in Ft.)</label>
                            <div class="col-lg-2">
                            <asp:TextBox ID="txtlen" runat="server" placeholder="L" class="form-control" data-validation="required" data-validation-error-msg=" "></asp:TextBox> 
                        </div>
                            <div class="col-lg-2">
                            <asp:TextBox ID="txtbdth" runat="server" placeholder="B" class="form-control" data-validation="required" data-validation-error-msg=" "></asp:TextBox>  
                        </div>
                            <div class="col-lg-2">
                            <asp:TextBox ID="txtwth" runat="server" placeholder="H" class="form-control" data-validation="required" data-validation-error-msg=" "></asp:TextBox>
                                
                        </div>
                            <div class="col-lg-2">
                            <asp:TextBox ID="txtwt" runat="server" placeholder="Wt" class="form-control" data-validation="required" data-validation-error-msg=" "></asp:TextBox>
                    
                        </div>
                            </div>
                    
               </div><br /><br />
                   <div class="col-md-4">
                       <div class="form-group">
                            <asp:LinkButton ID="btn_parcel_add" runat="server" CssClass="btn btn-success" OnClick="btn_parcel_add_Click"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>&nbsp;&nbsp;Add</asp:LinkButton>
                            </div>
                      
                      </div>
                      </div><br /><br />
                  
                          
                  
              <div  class="col-lg-12 ">  
                   <div class="table-responsive">
                    <asp:GridView ID="gv_parceldetails" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"  >
                        <columns>
                             <asp:BoundField DataField="AgreementID" HeaderText="AgreementID" />
                             <asp:BoundField DataField="Client" HeaderText="Client" />
                             <asp:BoundField DataField="City" HeaderText="City" />
                             <asp:BoundField DataField="Transporter" HeaderText="Transporter" />
                             <asp:BoundField DataField="FromLocation" HeaderText="FromLocation" />
                            <asp:BoundField DataField="ToLocation" HeaderText="ToLocation" />
                             <asp:BoundField DataField="DeliveryType" HeaderText="Delivery Type" />
                             <asp:BoundField DataField="PackingType" HeaderText="Packing Type" />
                             <asp:BoundField DataField="Capactiy" HeaderText="Capactiy" />
                             <asp:BoundField DataField="DecidedPrice" HeaderText="DecidedPrice" />
                            <asp:BoundField DataField="PostedDate" HeaderText="PostedDate" />
                             <asp:BoundField DataField="Comments" HeaderText="Size" />
                            
                        </columns>
                    </asp:GridView>
                </div>
                  </div>
                   
              </div>
              <div id="div_transporter" runat="server" >
                  <div class="table-responsive " >
                    <asp:GridView ID="gridview_trans_details" runat="server" Width="50%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"  >
                        <columns>
                             <asp:BoundField DataField="Transporter" HeaderText="Transporter" />
                             <asp:BoundField DataField="TransporterID" HeaderText="TransporterID" />
                             
                        </columns>
                    </asp:GridView>
                </div>
              </div>
              </div>
     </div>
     
        
</asp:Content>

