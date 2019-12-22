<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ParcelTrackReport.aspx.cs" Inherits="ParcelTrackReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="container master-container" style="padding-top: 66px; margin-left: 100px;">
        <div class="panel panel-info">
            <div class="panel-heading" align="center" style="padding: 5px;">
                <h4>Track Report</h4>
            </div>
            <br />
            <div class="panel-body">
                <div class="col-md-4">
                    
                  
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txt_id" Style="width: 50%; display: inline-block;" class="form-control" placeholder="Enter TrackID" runat="server"></asp:TextBox>
                    <%-- <asp:Button ID="btn_insert"  runat="server" Text="Search" CssClass="btn btn-success" OnClick="btn_insert_Click" />--%>
                    <asp:LinkButton ID="btn_insert" runat="server" CssClass="btn btn-success" OnClick="btn_insert_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>&nbsp;Search</asp:LinkButton>
                </div>


                <div class="col-md-4">
                    
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-6">

                    <div class="form-group">
                     <label for="inputcmp" class="col-sm-3 control-label">From:</label>
                    <div class="col-lg-9">
                    <asp:TextBox ID="txt_delfrom" runat="server" placeholder="MM/DD/YYYY" class="form-control"></asp:TextBox>
                      </div>
                        </div><br />&nbsp;

                    <div class="form-group">
                        <label for="inputcmp" class="col-sm-3 control-label">To:</label>
                    <div class="col-lg-9">
                    <asp:TextBox ID="txt_delto" runat="server" placeholder="MM/DD/YYYY" class="form-control"></asp:TextBox>
                </div><br /><br />

                       
                    </div>

                     <div class="form-group">
                     <label for="inputcmp" class="col-sm-3 control-label"></label>
                    <div class="col-lg-4">
                    <asp:Button ID="Btn_delrep" runat="server" Text="Search Report DateWise" class="btn btn-success center-block" OnClick="Btn_delrep_Click" />
                   
                      </div> 
                     <div class="col-lg-5" style="padding-left: 50px;">
                     <asp:LinkButton ID="btn_delivery" runat="server" CssClass="btn btn-success" OnClick="btn_delivery_Click" ><span class="fa fa-truck" aria-hidden="true"></span>&nbsp;All Delivery Report</asp:LinkButton>
                      </div>

                        </div>

                    </div>

                <div class="col-md-6 ">

                    <div class="form-group">
                     <label for="inputcmp" class="col-sm-3 control-label">From:</label>
                    <div class="col-lg-9">
                    <asp:TextBox ID="txt_infrom" runat="server" placeholder="MM/DD/YYYY" class="form-control"></asp:TextBox>
                    </div>
                         </div><br />&nbsp;

                    <div class="form-group">
                        <label for="inputcmp" class="col-sm-3 control-label">To:</label>
                    <div class="col-lg-9">
                    <asp:TextBox ID="txt_into" runat="server" placeholder="MM/DD/YYYY" class="form-control"></asp:TextBox>
                </div>
                    </div><br /><br />

                    
                    <div class="form-group">
                     <label for="inputcmp" class="col-sm-3 control-label"></label>
                    <div class="col-lg-4">
                    <asp:Button ID="btn_inrep" runat="server" Text="Search Report Datewise" class="btn btn-success center-block " OnClick="btn_inrep_Click" />
                   
                      </div> 
                     <div class="col-lg-5" style="padding-left: 50px;">
                     <asp:LinkButton ID="btn_transit" runat="server" CssClass="btn btn-success" OnClick="btn_transit_Click" ><span class="fa fa-truck" aria-hidden="true"></span>&nbsp;All InTransit Status</asp:LinkButton>
                      </div>

                        </div>

                    </div>

            </div>
        </div>
   
        <div id="div1" runat="server" class="panel panel-info">
        <div  class="panel-body">
        <div  class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="gridview_details" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="PostID"  EmptyDataText="There are no data records to display." OnRowCommand="gridview_details_RowCommand">  
                                        <Columns>  
                                            <asp:BoundField DataField="PostID" HeaderText="Track ID" ReadOnly="True" SortExpression="PostID" />  
                                            <asp:BoundField DataField="FromLocation" HeaderText="Source" SortExpression="FromLocation" />  
                                            <asp:BoundField DataField="ToLocation" HeaderText="Destination" SortExpression="ToLocation"/> 
                                            <asp:BoundField DataField="PickUpdate" HeaderText="Pick Update" SortExpression="PickUpdate"/> 
                                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"/> 
                                            <asp:buttonfield  buttontype="button" HeaderText="View" Text="Details" commandname="Details"  /> 
                                        </Columns>  
                                       
                                    </asp:GridView>  
                                </div>  
                            </div> 
            </div>
            </div>
        <div id="div2" runat="server" class="panel panel-info">
        <div  class="panel-body">
         <div  class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="gv_trackdetails" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="Deliverydate"  EmptyDataText="There are no data records to display.">  
                                        <Columns>  
                                            <asp:BoundField DataField="Deliverydate" HeaderText="Date" ReadOnly="True" SortExpression="Deliverydate" />  
                                            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />  
                                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"/> 
                                           
                                            
                                        </Columns>  
                                       
                                    </asp:GridView>  
                                </div>  
                            </div> 
         </div>
            </div>

         <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>

        <div id="div3" runat="server" class="panel panel-info">
            <div  class="panel-body">
             <div  class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="gv_deliverydetails" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"  EmptyDataText="There are no data records to display.">  
                                        <Columns>  
                                            
                                            <asp:BoundField DataField="FromLocation" HeaderText="Source" SortExpression="FromLocation" />  
                                            <asp:BoundField DataField="ToLocation" HeaderText="Destination" SortExpression="ToLocation"/> 
                                            <asp:BoundField DataField="LoadingDate" HeaderText="Loading Date" SortExpression="LoadingDate"/> 
                                            <asp:BoundField DataField="UnloadingDate" HeaderText="Unloading Date" SortExpression="UnloadingDate"/> 
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />  
                                        </Columns>  
                                    </asp:GridView>  
                                </div>  
                            </div> 
         </div>
            </div>
        <div id="div4" runat="server" class="panel panel-info">
            <div  class="panel-body">
             <div  class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="gv_intransit" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"   EmptyDataText="There are no data records to display.">  
                                        <Columns>  
                                            
                                            <asp:BoundField DataField="FromLocation" HeaderText="Source" SortExpression="FromLocation" />  
                                            <asp:BoundField DataField="ToLocation" HeaderText="Destination" SortExpression="ToLocation"/> 
                                            <asp:BoundField DataField="LoadingDate" HeaderText="Loading Date" SortExpression="LoadingDate"/> 
                                            <asp:BoundField DataField="Location" HeaderText="Current Location" SortExpression="Location"/> 
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                        </Columns>  
                                       
                                    </asp:GridView>  
                                </div>  
                            </div> 
                  </div>
            </div>
        </div>


    <script type="text/javascript">
        $(function () {
            $('#txt_date').datetimepicker();
        });
        </script>
</asp:Content>

