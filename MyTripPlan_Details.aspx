<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="MyTripPlan_Details.aspx.cs" Inherits="MyTripPlan_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content-wrapper">
        
    <div class="container master-container" style="padding-top: 66px; margin-left: 100px;">
        <div class="panel panel-info">
            <div class="panel-heading panel-heading-custom">
                        <div class="panel-title">
                           Trip Plan
                        </div>
                </div><br />
            <div class="row"> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Logistic PlanNo</label>
                                <div class="col-md-9"> 
                                    <asp:Label ID="LblPlanno" runat="server"  ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">No Of Trucks Req.</label>
                                <div class="col-md-9"> 
                                    <asp:Label ID="Lblnooftrucks" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Product Name</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lblproductname" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Enclosure Type</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="lblEncl" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Weight</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lblweight" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="lbl_source" class="col-md-3 control-label">Source</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lblsource" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="lbl_source" class="col-md-3 control-label">Travel Type</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lbltraveltype" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="costpetruck" class="col-md-3 control-label">Cost Per Truck</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lblcostpertruck" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="width" class="col-md-3 control-label">Width</label>
                                <div class="col-md-9"> 
                                      <asp:Label ID="Lblwidth" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div>
                        </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="from_location" class="col-md-3 control-label">Travel Date :</label>
                             <div class="col-md-9"> 
                                    <asp:Label ID="Lbltraveldate" runat="server"  ForeColor="Red"></asp:Label>
                                    </div>
                        </div><br /><br />
                        <div class="form-group">
                            <label for="capacity" class="col-md-3 control-label">Truck Type/Capacity</label>
                                <div class="col-md-9"> 
                                    <asp:Label ID="LblTrucktype" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="quantity" class="col-md-3 control-label">Quantity</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="LblQuantity" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Transit Days</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="lblTransit" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="travel_date" class="col-md-3 control-label">Length</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lbllength" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="lbl_source" class="col-md-3 control-label">Destination</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="LblDesination" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="lbl_source" class="col-md-3 control-label">Posted On</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lblpostedon" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="costpetruck" class="col-md-3 control-label">Volume</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lblvolume" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div><br /><br />
                        <div class="form-group">
                            <label for="width" class="col-md-3 control-label">Height</label>
                                <div class="col-md-9"> 
                                     <asp:Label ID="Lblheight" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                            </div>
                    </div>

                 
                

                     

                </div>
            </div>
        </div>
        </div>
</asp:Content>

