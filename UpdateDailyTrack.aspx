<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateDailyTrack.aspx.cs" Inherits="UpdateDailyTrack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.1/css/font-awesome.min.css" />
    <title></title>
    <link href="bokking_date_time_picker/src/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
        <link href="bokking_date_time_picker/css/Newjquery-ui.css" rel="stylesheet" type="text/css" />

        <script src="bokking_date_time_picker/js/jquery-1.11.1.min.js"></script>        
        <script src="bokking_date_time_picker/js/jquery-ui.js" type="text/javascript"></script>
        <script src="bokking_date_time_picker/src/jquery-ui-timepicker-addon.js" type="text/javascript"></script> 
        <script src="bokking_date_time_picker/dist/i18n/jquery-ui-timepicker-addon-i18n.min.js" type="text/javascript"></script>   
        <script src="bokking_date_time_picker/dist/jquery-ui-sliderAccess.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div class="padding100">

   <div class="container">
    <asp:Panel ID="Panel1" runat="server">
           <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
             <div id="div3" runat="server" class="row">
       <div id="Div5" style="margin-top: 5px;" class="mainbox col-md-12 margin-left: 0%;">
                <div class="panel panel-default">
                    <div class="panel-heading panel-heading-custom">
                        <div class="panel-title" align="center" >
                           <h4>Vehicle Details</h4>
                        </div>
                    </div>
             
            <!-- /.box-header -->
            <div class="box-body table-responsive no-padding">
              <table class="table table-bordered">
                  <thead>
                <tr>
                  <th>TrackId</th> 
                       <th>LR Number</th> 
                    <th>TripAssignID</th>  
                    <th>AcceptanceID</th>
                    <th>DriverNumber</th>
                   </tr>
                      </thead>
                  <tbody>
                      <tr class="active">       
                  <td><asp:Label ID="Label1" runat="server" Text="Label" class = 'control-label' ></asp:Label></td>
                   <td><asp:Label ID="Label2" runat="server" Text="Label" class = 'control-label' ></asp:Label></td>
                <td><asp:Label ID="Label3" runat="server" Text="Label" class = 'control-label' ></asp:Label></td>
                           <td><asp:Label ID="Label4" runat="server" Text="Label" class = 'control-label' ></asp:Label></td>
                           <td><asp:Label ID="Label5" runat="server" Text="Label" class = 'control-label' ></asp:Label></td>
              </tr>
                    </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
      </div>
        </div>    </div>
          
        </div>
    </section>
         
                               
    </asp:Panel>
        <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
       <div id="div1" runat="server" class="row">
       <div id="loginbox" style="margin-top: 5px;" class="mainbox col-md-12 margin-left: 0%;">
                <div class="panel panel-default">
                    <div class="panel-heading panel-heading-custom">
                        <div class="panel-title" align="center">
                           Track Details
                        </div>
                    </div>
                    <div style="padding-top: 30px" class="panel-body">                        
                        <div id="loginform" class="form-horizontal" role="form">
                        <div class="row">
                          <div class="col-md-6">
                           
                              <div class="form-group">
                                <label for="date" class="col-md-4 control-label">Date</label>
                                <div class="col-md-8">                                  
                                   <div class="input-group">
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                     <asp:TextBox ID="txt_date" class="form-control" placeholder="Enter Date" runat="server" autocomplete="off"></asp:TextBox> 
                             
                                 </div> 
                                </div>
                            </div>  
                              
                              <div id="divloc" runat="server" class="form-group">
                                <label for="id" class="col-md-4 control-label">Location</label>
                                <div class="col-md-8">   
                                     <div class="input-group">
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-map-marker"></i></span>                               
                                    <asp:TextBox ID="txt_location" runat="server" placeholder="Enter Address" class="form-control"></asp:TextBox>
                                         </div>
                                </div>
                            </div> 
                             
                          </div>
                          <div class="col-md-6">
                               <div class="form-group">
                                <label for="id" class="col-md-4 control-label">Status</label>
                                <div class="col-md-8">   
                                     <div class="input-group">
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-bell"></i></span>                               
                                    <asp:DropDownList ID="ddl_status" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_status_SelectedIndexChanged">
                                     <asp:ListItem Value="0">--Select Status--</asp:ListItem>
                                     <asp:ListItem Value="1">In Transit</asp:ListItem>
                                     <asp:ListItem Value="2">Delivered</asp:ListItem>
                                    </asp:DropDownList>
                                         </div>
                                </div>
                            </div> 
                               
                               <div id="divrem" runat="server" class="form-group">
                                <label for="id" class="col-md-4 control-label">Remarks</label>
                                <div class="col-md-8">   
                                     <div class="input-group">
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>                               
                                    <asp:TextBox ID="txt_remarks" runat="server" placeholder="Enter Remarks" class="form-control"></asp:TextBox>
                                         </div>
                                </div>
                            </div> 
                                 
                              
                          </div>
                        </div>
                        
                       
                         <div class="col-md-6">
                                                    
                         </div>
                         <div class="col-md-4">
                                                  
                         </div>
                         <div class="col-md-2">
                             <div class="form-group" align="center">
                                <!-- Button -->
                                <div class="col-sm-12 controls">
                                    <asp:Button ID="btn_insert" runat="server" Text="Submit" 
                                        CssClass="btn btn-success" OnClick="btn_insert_Click"   />
                                </div>
                            </div> 
                                                 
                         </div>
                       
                        </div>
                    </div>
                    </div>
           </div>
           </div>
        <div  class="col-md-6">
                                                    
                         </div>
                         <div class="col-md-4">
                                                  
                         </div>
                         <div id="div4" runat="server" class="col-md-2">
                             <div class="form-group" align="center">
                                <!-- Button -->
                                <div class="col-sm-12 controls">
                                    <asp:Button ID="btn_dash" runat="server" Text="Dashboard" 
                                        CssClass="btn btn-success" OnClick="btn_dash_Click"    />
                                </div>
                            </div> 
                                                 
                         </div>
       <div id="div2" runat="server" class="row">
           <div  class="panel panel-info" >
        <div  class="panel-body">
        <div  class="col-lg-12 ">  
                                <div class="table-responsive" style="overflow-x:scroll;" >  
                                    <asp:GridView ID="gridview_details" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="AcceptanceID" AllowPaging="true" EmptyDataText="There are no data records to display." OnRowCommand="gridview_details_RowCommand">  
                                        <Columns>  
                                             <asp:TemplateField HeaderText="Confirm No" Visible="true" >
                                              <ItemTemplate>
                                                  <asp:Label ID="lblplanID" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                                              </ItemTemplate>
                                                 <EditItemTemplate>
                                                      <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:TextBox>
                                                     
                                                  </EditItemTemplate>
                                          </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PLID" Visible="false" >
                                              <ItemTemplate>
                                                 <asp:Label ID="lblplid" runat="server" Text='<%# Bind("plid") %>' ></asp:Label>
                                              </ItemTemplate>
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txtplid" runat="server" Text='<%# Bind("plid") %>'></asp:TextBox>
                                                 </EditItemTemplate>
                                          </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Project No" Visible="false" >
                                              <ItemTemplate>
                                                  <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                  
                                          <asp:TemplateField HeaderText="WBS No" Visible="false" >
                                              <ItemTemplate>
                                                  <asp:Label ID="lblWBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                  
                                          <asp:TemplateField HeaderText="From Location">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>

                                          <asp:TemplateField HeaderText="To Location">
                                              <ItemTemplate>
                                                  <asp:Label ID="lbltoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                  
                                          <asp:TemplateField HeaderText="Truck Type" Visible="true" >
                                              <ItemTemplate>
                                                  <asp:Label ID="lblTruck" runat="server" Text='<%# Bind("TruckType") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                  
                                            <asp:TemplateField HeaderText="Travel Date">
                                              <ItemTemplate>
                                                  <asp:Label ID="lbldate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                  
                                           <asp:TemplateField HeaderText="LR No.">
                                              <ItemTemplate>
                                                 <asp:Label ID="lblLRno" runat="server" Text='<%# Bind("LRNumber") %>'></asp:Label>
                                              </ItemTemplate>
                                               <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("LRNumber") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                          </asp:TemplateField>
                  
                                          <asp:TemplateField HeaderText="Exp.DeliveryDate">
                                              <ItemTemplate>
                                                   <asp:Label ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                 
                                           <asp:TemplateField HeaderText="ClientID" Visible="false">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                  
                  
                                            <asp:TemplateField HeaderText="ClientAdrID" Visible="false">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblclientadrID" runat="server" Text='<%# Bind("ClientAddressLocationID") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>

                                            <asp:TemplateField HeaderText="VehicleNo" >
                                                  <EditItemTemplate>
                                                      <asp:TextBox ID="TextBox1" runat="server" class="form-control" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                        <asp:TextBox ID="txtvehicleNo"  runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                                                  </ItemTemplate>
                                              </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Received Date/Time">
                                                  <EditItemTemplate>
                                                      <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ReceivedDate") %>'></asp:TextBox>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                        <asp:TextBox ID="txt_date"  placeholder="MM/DD/YYYY HH:MM" runat="server"></asp:TextBox> 
                                                </ItemTemplate>
                                             </asp:TemplateField>

                                             <asp:TemplateField HeaderText="UnLoading Date/Time">
                                                  <EditItemTemplate>
                          
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                      <asp:TextBox ID="txt_date1"  placeholder="MM/DD/YYYY HH:MM" runat="server"></asp:TextBox> 
                                                   </ItemTemplate>
                                                 </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remarks">
                                                  <EditItemTemplate>
                                                      <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                                  </EditItemTemplate>
                                                  <ItemTemplate>
                                                      <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"  placeholder="Enter Remarks" ></asp:TextBox>
                                                  </ItemTemplate>
                                              </asp:TemplateField>

                                            <asp:buttonfield  buttontype="button" HeaderText="Submit" Text="Submit" commandname="Details"  />

                                            
                                           
                                            
                                        </Columns>  
                                    </asp:GridView>  
                                </div>  
                            </div> 
            </div>
            </div>
            </div>
      
     
       
 </div>

         
        </div>
          

        
        <script type="text/javascript">
            $(document).ready(function () {
                $('#<%= txt_date.ClientID %>').datetimepicker({
                controlType: 'select',
                oneLine: true,
                timeFormat: 'hh:mm tt'
                //minDate: 0,
                //maxDate: 30
            });
        });
  </script>
    </form>
</body>
</html>
