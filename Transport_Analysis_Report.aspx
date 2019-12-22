<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Transport_Analysis_Report.aspx.cs" Inherits="Transport_Analysis_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

   <script type="text/javascript">
         function name()
       {  
             var frm = document.getElementsByName('contact-form')[0];
             frm.submit(); // Submit
             frm.reset();  // Reset
             return false; // Prevent page refresh
       }
   </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br /><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <div class="container master-container" style="padding-top: 66px; margin-left: 100px;">
           <div class="panel panel-info">
            <div class="panel-heading panel-heading-custom">
                        <div class="panel-title">
                           Report
                        </div>
                    </div>
                <div class="panel-body">
                    <div class="row">
                    <div class="col-md-4"></div>
                       <div class="col-md-7">
                        <label class="btn btn-default"><asp:RadioButton ID="rdb_monthwise" runat="server" Checked="true"  AutoPostBack="true" GroupName="A" Text="MonthWise" OnCheckedChanged="rdb_monthwise_CheckedChanged" ></asp:RadioButton></label>
                         <label class="btn btn-default"><asp:RadioButton ID="rdb_daywise" runat="server" GroupName="A" AutoPostBack="true" Text="DayWise" OnCheckedChanged="rdb_daywise_CheckedChanged" ></asp:RadioButton></label>
                         </div>
                    <div class="col-md-1"></div>
                 </div><br />
                    <div id="monthwise" runat="server" class="row">
                        <div class="col-md-4">
                            <asp:DropDownList ID ="ddl_month" runat="server" class="form-control" >
                            <asp:ListItem Value="0">--Select Month--</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID ="ddl_year" runat="server" class="form-control" >
                                 <asp:ListItem Value="2019">2019</asp:ListItem> 
                                <asp:ListItem Value="2018">2018</asp:ListItem> 
                               <asp:ListItem Value="2017">2017</asp:ListItem>  
                                <asp:ListItem Value="2016">2016</asp:ListItem>      
                                <asp:ListItem Value="2015">2015</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                        <div class="col-md-4">
                            <div class="col-md-4">
                                <asp:Button ID="btn_search1" runat="server" class="btn btn-primary" Text="Search" OnClick="btn_search1_Click" />
                            </div>
                            <div class="col-md-4">
                                
                            </div>
                            
                        </div>
                    </div><br />
                    <div id="daywise" runat="server" class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                        <asp:TextBox ID="txtFrom" runat="server" class="form-control" autocomplete="off"></asp:TextBox>
                        <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" Visible="false" />
                        <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server"  PopupButtonID="imgdate1" TargetControlID="txtFrom">                
                         </ajaxtoolkit:calendarextender>
                            </div>
                         <div class="col-md-4">
                              <div class="col-md-4">
                                <asp:Button ID="btn_search" runat="server" class="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                            </div>
                         </div>
                    </div><br />

                    <div id="gridview" runat="server" class="row">
                      
                                <asp:Button ID="btn_download1" runat="server" class="btn btn-primary pull-right" Text="Download" OnClick="btn_download1_Click" /><br /><br />
                                <div  class="col-lg-12 ">  
                                <div class="table-responsive" style="overflow-x:scroll;" >  
                                    <asp:GridView ID="gridview_details" runat="server" Width="100%"  CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"  ShowHeaderWhenEmpty="True" EmptyDataText="No records Found to Display!" OnRowDataBound="gridview_details_RowDataBound" EnableModelValidation="True" >  
                                         <Columns>
                                             

                                             <asp:TemplateField HeaderText ="TID" >
                                                 <ItemTemplate>
                                                      <%-- <asp:HyperLink ID="lnkDetails" runat="server"  style="color:blue;text-decoration:underline"  NavigateUrl=<%# String.Format("javascript:void(window.open('MyTripplan.aspx?TransporterID={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("rid")) %>>View</asp:HyperLink>--%>
                                                 <asp:Label ID="lbl_rid" runat="server" ForeColor="Black" Text='<%# Bind("rid") %>'  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>


                                             <asp:TemplateField HeaderText ="Transporter">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_transporter" runat="server" ForeColor="Black" Text='<%# Bind("Transporter") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_transporter1" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText ="No of AD Posted">
                                                 <ItemTemplate>
                                                  <%-- <asp:HyperLink ID="lnkDetails" runat="server"  style="color:blue;text-decoration:underline"  NavigateUrl=<%# String.Format("javascript:void(window.open('MyTripplan.aspx?TransporterID={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("rid")) %>>View</asp:HyperLink>--%>
                                                     <asp:Label ID="lbl_post" runat="server" ForeColor="Black" Text='<%# Bind("NoofADPosted") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_post1" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Participant">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_participant" runat="server" ForeColor="Black" Text='<%# Bind("Participant") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_participant1" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Acceptance">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_acceptance" runat="server" ForeColor="Black" Text='<%# Bind("Acceptance") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_acceptance1" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Level1">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_Replyid1" runat="server" ForeColor="Black" Text='<%# Bind("L1") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_Replyid11" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Level2">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_Replyid2" runat="server" ForeColor="Black" Text='<%# Bind("L2") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_Replyid12" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Level3">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_Replyid3" runat="server" ForeColor="Black" Text='<%# Bind("L3") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_Replyid13" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Level4">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_Replyid4" runat="server" ForeColor="Black" Text='<%# Bind("L4") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_Replyid14" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Level5">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_Replyid5" runat="server" ForeColor="Black" Text='<%# Bind("L5") %>'  ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_Replyid15" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText ="Placement Percentage">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_placement" runat="server" ForeColor="Black" Text='<%# Bind("Placement") %>'></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_placement1" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="PlacedDateTime">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_palcedtime" runat="server"  ></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_pdatetime" runat="server" Text='<%# Bind("LoadingDate") %>'></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dispatched Date & Time">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_dispatch" runat="server"  ></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_dispatch" runat="server" Text='<%# Bind("Dispatcheddatetime") %>'></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                           
                                            <%-- <asp:TemplateField HeaderText ="< 2hrs">
                                                 <ItemTemplate>
                                                 <asp:Label ID="lbl_placementlessthentwohours" runat="server" ForeColor="Black" Text='<%# Bind("Placement") %>'></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="lbl_lessthentwohours" runat="server" ForeColor="Black"  ></asp:Label>
                                              </ItemTemplate>
                                            </asp:TemplateField>--%>
                                             <asp:TemplateField HeaderText="Difference">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_difference" runat="server"  ></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_difference" runat="server" Text='<%# Bind("differenceredate") %>' ></asp:Label>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Placement Delay <2 / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delaylessthen2hours" runat="server" Text='<%# Bind("delaylesstwo1") %>' ></asp:Label>
                                                 </ItemTemplate>
                                              
                                             </asp:TemplateField>
                                             
                                              <asp:TemplateField HeaderText="Placement Delay < 2>4 / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delaylessthen4hours" runat="server" Text='<%# Bind("delaylesstwo") %>' ></asp:Label>
                                                 </ItemTemplate>
                                              
                                             </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Placement Delay < 4>6 / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delaylessthen6hours" runat="server" Text='<%# Bind("delaylessfour") %>' ></asp:Label>
                                                 </ItemTemplate>
                                              
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Placement Delay < 6>8 / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delaylessthen8hours" runat="server" Text='<%# Bind("delaylesseight") %>' ></asp:Label>
                                                 </ItemTemplate>
                                              
                                             </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Placement Delay < 8>12 / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delaylessthen12hours" runat="server" Text='<%# Bind("delaylesstwel") %>' ></asp:Label>
                                                 </ItemTemplate>     
                                             </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Placement Delay < 12>24 / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delaylessthen24hours" runat="server" Text='<%# Bind("delaylesstwe4") %>' ></asp:Label>
                                                 </ItemTemplate>     
                                             </asp:TemplateField>

                                              <asp:TemplateField HeaderText="ExpectedDeliveredDateTime">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_expdelivereddate" runat="server"  ></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_deliverdate" runat="server" Text='<%# Bind("DeliveryDate") %>' ></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             
                                             
                                              <asp:TemplateField HeaderText="ReceivedDateTime">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_receiveddate" runat="server"  ></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_Receiveddate" runat="server" Text='<%# Bind("ReceivedDate") %>' ></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Difference1">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_difference1" runat="server"  ></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_difference1" runat="server" Text='<%# Bind("differenceredate1") %>' ></asp:Label>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
<%--                                            <asp:TemplateField HeaderText="Delay">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="txt_delay" runat="server"  ></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delay" runat="server" Text='<%# Bind("delay") %>' ></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>--%>


                                            


                                             <asp:TemplateField HeaderText=" Delivered < 24 / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_deliverlessthen24hours" runat="server" Text='<%# Bind("delayless24") %>' ></asp:Label>
                                                 </ItemTemplate>
                                              
                                             </asp:TemplateField>


                                             <asp:TemplateField HeaderText=" Delivered >24 to <48hrs / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_deliverlessthen48hours" runat="server" Text='<%# Bind("delayless248") %>' ></asp:Label>
                                                 </ItemTemplate>
                                              
                                             </asp:TemplateField>
                                               <asp:TemplateField HeaderText=" Delivered >48hrs / (Hours)">                                                 
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl_delivergrtthen48hours" runat="server" Text='<%# Bind("delaygreater") %>' ></asp:Label>
                                                 </ItemTemplate>
                                              
                                             </asp:TemplateField>

                                         </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                        </asp:GridView>
                                    </div>
                    </div>
                    </div>
         
                    
                 



                </div><br /><br />
<br /> <br /> <br />  </div>
      </div>

</asp:Content>

