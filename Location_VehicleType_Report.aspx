<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/RakeshMasterPage.master" AutoEventWireup="true" CodeFile="Location_VehicleType_Report.aspx.cs" Inherits="Location_VehicleType_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
    
    <div class="container master-container" style="padding-top: 66px; margin-left: 100px;">
        <div class="panel panel-info">
            <div class="panel-heading panel-heading-custom">
                        <div class="panel-title">
                           Report
                        </div>
                    </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="From_date" class="col-md-4 control-label">From Date</label>
                                <div class="col-md-8"> 
                                    <div class="input-group">
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    <asp:TextBox ID="txt_startdate" class="form-control" runat="server" data-validation="required" data-validation-error-msg=" "></asp:TextBox>
                                </div>
                                    </div>
                        </div>
                        </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="To_date" class="col-md-4 control-label">To Date</label>
                                <div class="col-md-8"> 
                                    <div class="input-group">
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    <asp:TextBox ID="txt_todate" class="form-control" runat="server"   data-validation="required" data-validation-error-msg=" "></asp:TextBox>
                                </div>
                                    </div>
                        </div>
                    </div>

                    <div class="col-md-4">

                        <div class="form-group">
                            <label for="vehicle" class="col-md-4 control-label">Type Of Vehicle</label>
                            <div class="col-md-8">   
                                     <div class="input-group">
                                  <span class="input-group-addon"><i class="fa fa-truck"></i></span>                               
                                    <asp:DropDownList ID="ddl_vehicletype" class="form-control" runat="server"   data-validation="required" data-validation-error-msg=" "></asp:DropDownList>
                                         </div>
                                </div>
                        </div>
                    </div>
                     </div><br /><br />
                    <div class="col-md-6">

                    </div>
                      
                        <div class="col-md-6">
                        <div class="form-group">
                            <label for="vehicle" class="col-md-4 control-label"></label>
                            <div class="col-md-8">   
                              <div class="col-md-12">
                                  <div class="col-md-6">
                                    <div class="form-group" >
                                      <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btn_search_Click" />
                                   </div>
                                  </div>
                                  <div class="col-md-6">
                                    <div class="form-group" >
                                      <asp:Button ID="btn_download" runat="server" Text="Download" CssClass="btn btn-success" OnClick="btn_download_Click" />
                                   </div>
                                  </div>
                              </div>     
                            </div>
                        </div>
                      
                    </div>
               <br />
                <br />

                 <div  class="col-lg-12 ">  
                   <div class="table-responsive" >
                    <asp:GridView ID="gridview_details" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"  >
                        <columns>
                             <asp:BoundField DataField="Date" HeaderText="Date" />
                             <asp:BoundField DataField="FromLocation" HeaderText="Source" />
                             <asp:BoundField DataField="ToLocation" HeaderText="Destination" />
                             <asp:BoundField DataField="Freezeamount" HeaderText="Freeze Amount" />
                             <asp:BoundField DataField="" HeaderText="Delivery Date" />
                            
                        </columns>
                    </asp:GridView>
                </div>
                    </div>
                
                

                
            </div>
            <br />
                <br />
            
               
                    </div>
                

            </div>
        </div>

    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= txt_startdate.ClientID %>').datepicker({
                controlType: 'select',
                oneLine: true,
                timeFormat: 'hh:mm tt',
                //minDate: 0,
                maxDate: 0
            });
        });

           
  </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= txt_todate.ClientID %>').datepicker({
                 controlType: 'select',
                 oneLine: true,
                 timeFormat: 'hh:mm tt',
                 //minDate: 0,
                 maxDate: 0
             });

         });
    </script>


</asp:Content>

