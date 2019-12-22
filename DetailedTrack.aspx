<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="DetailedTrack.aspx.cs" Inherits="DetailedTrack" %>

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
    <br />
    <br />
    
     <div class="container master-container" style="padding-top: 66px; margin-left: 100px;" >
          <div class="panel panel-primary">
            <div class="panel-heading panel-heading-custom">
                        <div class="panel-title">
                           Track Details
                        </div>
                    </div><br />

              <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
               <div id="option" runat="server" class="row">
                     <div class="col-md-4"></div>
                    <div class="col-md-7">
                    <label class="btn btn-default"><asp:RadioButton ID="rdb_normal" runat="server"  AutoPostBack="true" GroupName="A" Text="RFQ Track" OnCheckedChanged="rdb_normal_CheckedChanged" ></asp:RadioButton></label>
                     <label class="btn btn-default"><asp:RadioButton ID="rdb_agreement" runat="server" GroupName="A" AutoPostBack="true" Text="Agreement Track" OnCheckedChanged="rdb_agreement_CheckedChanged"  ></asp:RadioButton></label>
                   
                 </div>
                <div class="col-md-1"></div>
               </div><br /><br />
              
             
              
            <div id="rfqoption" runat="server" style ="height:500px; width:100%;overflow:scroll;">
            
             <asp:GridView ID="gridview_details" class="table table-responsive" runat="server"  AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" OnRowDataBound="gridview_details_RowDataBound">
              <Columns>
                

                  <asp:TemplateField >
                     <ItemTemplate>
                         <asp:Image ID="Image1" runat="server" Height="20px" />                        
                      </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Track ID" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblid" runat="server" Text='<%#Eval("PostID")%>'></asp:Label>                        
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Source" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblfrom" runat="server" Text='<%#Eval("FromLocation")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="Destination">
                     <ItemTemplate>
                         <asp:Label ID="lblto" runat="server" Text='<%#Eval("ToLocation")%>'></asp:Label>
                      </ItemTemplate>
                   
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Driver No">
                     <ItemTemplate>
                         <asp:Label ID="lblmobileNo" runat="server" Text='<%#Eval("mobileNo")%>'></asp:Label>
                      </ItemTemplate>
                   
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="LR Number">
                     <ItemTemplate>
                         <asp:Label ID="lblnumber" runat="server" Text='<%#Eval("LRNumber")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Transporter" >
                     <ItemTemplate>
                         <asp:Label ID="lbltransporter" runat="server" Text='<%#Eval("TransporterName")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Vehicle Loaded">
                     <ItemTemplate>
                         <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Loadingdate")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="AcceptanceID" Visible="false">
                     <ItemTemplate>
                         <asp:Label ID="lblAcceptanceID" runat="server" Text='<%#Eval("AcceptanceID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="TripAssignID" Visible="false">
                     <ItemTemplate>
                         <asp:Label ID="lblTripAssignID" runat="server" Text='<%#Eval("TripAssignID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Expected Delivery Date">
                     <ItemTemplate>
                         <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Track Vehicle" HeaderStyle-HorizontalAlign ="Left" >
                      <ItemTemplate>
                          <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/UpdateDailyTrack.aspx?PostID={0}&&LRNumber={1}&&AcceptanceID={2}&&TripAssignID={3}", HttpUtility.UrlEncode(Eval("PostID").ToString()),HttpUtility.UrlEncode(Eval("LRNumber").ToString()),HttpUtility.UrlEncode(Eval("AcceptanceID").ToString()),HttpUtility.UrlEncode(Eval("TripAssignID").ToString())) %>'>Update</asp:HyperLink>--%>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/UpdateDailyTrack.aspx?PostID={0}&&LRNumber={1}&&AcceptanceID={2}&&TripAssignID={3}&&mobileNo={4}", HttpUtility.UrlEncode(Eval("PostID").ToString()),HttpUtility.UrlEncode(Eval("LRNumber").ToString()),HttpUtility.UrlEncode(Eval("AcceptanceID").ToString()),HttpUtility.UrlEncode(Eval("TripAssignID").ToString()),HttpUtility.UrlEncode(Eval("mobileNo").ToString())) %>'>Update</asp:HyperLink>
                      </ItemTemplate>
                     
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                     
                  </asp:TemplateField>  

              </Columns>
                 <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                 <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                 <RowStyle BackColor="White" ForeColor="#330099" />
                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                 </asp:GridView>
            
            </div>
              <div id="agreementoption" runat="server" style ="height:500px; width:100%;overflow:scroll;">
             <asp:GridView ID="grid_agreement" class="table table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" OnRowDataBound="grid_agreement_RowDataBound">
              <Columns>
                  <asp:TemplateField >
                     <ItemTemplate>
                         <asp:Image ID="Image1" runat="server" Height="20px" />                        
                      </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Track ID" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblid" runat="server" Text='<%#Eval("PostID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Source" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblfrom" runat="server" Text='<%#Eval("FromLocation")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="Destination">
                     <ItemTemplate>
                         <asp:Label ID="lblto" runat="server" Text='<%#Eval("ToLocation")%>'></asp:Label>
                      </ItemTemplate>
                   
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Driver No">
                     <ItemTemplate>
                         <asp:Label ID="lbltomobileNo" runat="server" Text='<%#Eval("mobileNo")%>'></asp:Label>
                      </ItemTemplate>
                   
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="LR Number">
                     <ItemTemplate>
                         <asp:Label ID="lblnumber" runat="server" Text='<%#Eval("LRNumber")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Transporter" >
                     <ItemTemplate>
                         <asp:Label ID="lbltransporter" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                  

                  <asp:TemplateField HeaderText="Vehicle Loaded">
                     <ItemTemplate>
                         <asp:Label ID="lbldateLoadingdate" runat="server" Text='<%#Eval("Loadingdate")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="AcceptanceID" Visible="false">
                     <ItemTemplate>
                         <asp:Label ID="lbldateAcceptanceID" runat="server" Text='<%#Eval("AcceptanceID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="TripAssignID" Visible="false">
                     <ItemTemplate>
                         <asp:Label ID="lbldateTripAssignID" runat="server" Text='<%#Eval("TripAssignID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Expected Delivery Date">
                     <ItemTemplate>
                         <asp:Label ID="lbldelDeliveryDate" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Track Vehicle" HeaderStyle-HorizontalAlign ="Left" >
                      <ItemTemplate>
                          <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/UpdateDailyTrack.aspx?PostID={0}&&LRNumber={1}&&AcceptanceID={2}&&TripAssignID={3}", HttpUtility.UrlEncode(Eval("PostID").ToString()),HttpUtility.UrlEncode(Eval("LRNumber").ToString()),HttpUtility.UrlEncode(Eval("AcceptanceID").ToString()),HttpUtility.UrlEncode(Eval("TripAssignID").ToString())) %>'>Update</asp:HyperLink>--%>
                           <asp:HyperLink ID="HyperLink1"   AutoPostBack="true" runat="server" NavigateUrl='<%# string.Format("~/UpdateDailyTrack.aspx?PostID={0}&&LRNumber={1}&&AcceptanceID={2}&&TripAssignID={3}&&mobileNo={4}", HttpUtility.UrlEncode(Eval("PostID").ToString()),HttpUtility.UrlEncode(Eval("LRNumber").ToString()),HttpUtility.UrlEncode(Eval("AcceptanceID").ToString()),HttpUtility.UrlEncode(Eval("TripAssignID").ToString()),HttpUtility.UrlEncode(Eval("mobileNo").ToString())) %>'>Update</asp:HyperLink>
                      </ItemTemplate>
                     
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                     
                  </asp:TemplateField>
                 

                 




              </Columns>
                 <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                 <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                 <RowStyle BackColor="White" ForeColor="#330099" />
                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                 </asp:GridView>
                 </div>
                 </div>
             </div>



             
         
</asp:Content>

